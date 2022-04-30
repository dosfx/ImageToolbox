using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToolbox
{
    public partial class ImageToolbox : Form
    {
        private PsdFile psdFile;
        private LayerPanel selectedLayer;
        private readonly Dictionary<PsdLayer, LayerDetailsPanel.Details> layerDetails;

        public ImageToolbox()
        {
            InitializeComponent();

            layerDetails = new Dictionary<PsdLayer, LayerDetailsPanel.Details>();
        }

        private void OpenPsdMenuItem_Click(object sender, EventArgs e)
        {
            if (openPsdDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openPsdDialog.FileName);
            }
        }

        private void OpenFile(string path)
        {
            layersPanel.Controls.Clear();
            layerDetails.Clear();
            pathLabel.Text = "Loading...";
            pathLabel.Tag = path;
            sizeLabel.Text = string.Empty;
            mainPictureBox.Image = null;
            openFileProgressBar.Value = 0;
            openFileProgressBar.Visible = true;
            SelectLayer(null);
            openFileWorker.RunWorkerAsync(path);
        }

        private void OpenFileWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = (string)e.Argument;
            using (Stream fileStream = File.OpenRead(path))
            using (ProgressStream stream = new ProgressStream(fileStream))
            {
                stream.ProgressChanged += OpenFileStream_ProgressChanged;
                openFileWorker.ReportProgress(0, 100);
                PsdFile file = new PsdFile(stream);
                e.Result = file;
                openFileWorker.ReportProgress(0, file.Layers.Length);
                int progress = 0;
                Parallel.For(0, file.Layers.Length, i =>
                {
                    file.Layers[i].GetBitmap();
                    openFileWorker.ReportProgress(Interlocked.Increment(ref progress));
                });
            }
        }

        private void OpenFileStream_ProgressChanged(object sender, ProgressEventArgs e)
        {
            openFileWorker.ReportProgress(e.Percentage);
        }

        private void OpenFileWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int? newMax = e.UserState as int?;
            if (newMax != null)
            {
                openFileProgressBar.Maximum = (int)newMax;
            }

            openFileProgressBar.Value = e.ProgressPercentage;
        }

        private void OpenFileWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                pathLabel.Text = "Error, but you can try another PSD.";
                MessageBox.Show(this, "Error occured while parsing the PSD, please send the PSD to Dos for correction.", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            openFileProgressBar.Visible = false;
            psdFile = (PsdFile)e.Result;
            pathLabel.Text = (string)pathLabel.Tag;
            sizeLabel.Text = $"{psdFile.Width} x {psdFile.Height}";
            mainPictureBox.Image = psdFile.Bitmap;
            layersPanel.SuspendLayout();
            layersPanel.Visible = false;
            Stack<LayerFolderPanel> folderStack = new Stack<LayerFolderPanel>();
            foreach (PsdLayer layer in psdFile.Layers.Reverse())
            {
                Control row;
                Control.ControlCollection currentLevel = folderStack.Count == 0 ? layersPanel.Controls : folderStack.Peek().LayerControls;
                if (layer.IsFolderBegin)
                {
                    LayerFolderPanel folder = new LayerFolderPanel()
                    {
                        Dock = DockStyle.Top,
                        FolderName = layer.Name,
                        IsHidden = layer.IsHidden,
                        IsOpen = layer.IsOpen
                    };
                    folderStack.Push(folder);
                    row = folder;
                }
                else if (layer.IsFolderEnd)
                {
                    folderStack.Pop();
                    continue;
                }
                else
                {
                    Image displayImage = new Bitmap(psdFile.Width, psdFile.Height);
                    Bitmap layerImage = layer.GetBitmap();
                    if (layerImage != null)
                    {
                        using (Graphics g = Graphics.FromImage(displayImage))
                        {
                            g.FillRectangle(Brushes.Gray, 0, 0, displayImage.Width, displayImage.Height);
                            g.DrawImage(layerImage, layer.Bounds);
                        }
                    }

                    LayerPanel layerPanel = new LayerPanel()
                    {
                        Dock = DockStyle.Top,
                        Image = displayImage,
                        IsHidden = layer.IsHidden,
                        LayerName = layer.Name,
                        LayerOpacity = (layer.Opacity / 255d) * 100,
                        Tag = layer,
                    };
                    layerPanel.SelectedChanged += LayerPanel_SelectedChanged;
                    row = layerPanel;
                }
                currentLevel.Add(row);
                currentLevel.SetChildIndex(row, 0);
            }
            layersPanel.ResumeLayout();
            layersPanel.Visible = true;
        }

        private void LayerPanel_SelectedChanged(object sender, EventArgs e)
        {
            // sender is the layer panel
            LayerPanel newSelected = (LayerPanel)sender;
            SelectLayer(newSelected.Selected ? newSelected : null);
        }

        private void SelectLayer(LayerPanel newSelected)
        {
            // blow it all away
            splitContainer.Panel2.Controls.Clear();

            if (selectedLayer != null)
            {
                // first deselect the old one
                selectedLayer.SelectedChanged -= LayerPanel_SelectedChanged;
                selectedLayer.Selected = false;
                selectedLayer.SelectedChanged += LayerPanel_SelectedChanged;
            }

            selectedLayer = newSelected;
            if (selectedLayer != null)
            {
                PsdLayer layer = selectedLayer.Tag as PsdLayer;
                if (!layerDetails.TryGetValue(layer, out LayerDetailsPanel.Details details))
                {
                    details = new LayerDetailsPanel.Details()
                    {
                        Layer = layer,
                        Width = psdFile.Width,
                        Height = psdFile.Height
                    };
                    layerDetails.Add(layer, details);
                }
                splitContainer.Panel2.Controls.Add(new LayerDetailsPanel()
                {
                    Dock = DockStyle.Top,
                    IsHidden = layer.IsHidden,
                    LayerDetails = details,
                    LayerName = layer.Name,
                    LayerOpacity = (layer.Opacity / 255d) * 100
                });
            }
            else
            {
                splitContainer.Panel2.Controls.Add(noDetailsLabel);
            }
        }
    }
}
