using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToolbox
{
    public partial class ImageToolbox : Form
    {
        private PsdFile psdFile;
        private LayerPanel selectedLayer;

        public ImageToolbox()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void OpenFile(string path)
        {
            layersPanel.Controls.Clear();
            pathLabel.Text = "Loading...";
            pathLabel.Tag = path;
            sizeLabel.Text = string.Empty;
            openFileProgressBar.Value = 0;
            openFileProgressBar.Visible = true;
            openFileWorker.RunWorkerAsync(path);
        }

        private void OpenFileWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string path = (string)e.Argument;
            using (Stream fileStream = File.OpenRead(path))
            using (ProgressStream stream = new ProgressStream(fileStream))
            {
                stream.ProgressChanged += OpenFileStream_ProgressChanged;
                e.Result = new PsdFile(stream);
            }
        }

        private void OpenFileStream_ProgressChanged(object sender, ProgressEventArgs e)
        {
            openFileWorker.ReportProgress(e.Percentage);
        }

        private void OpenFileWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
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
                    LayerPanel layerPanel = new LayerPanel()
                    {
                        Dock = DockStyle.Top,
                        IsHidden = layer.IsHidden,
                        LayerName = layer.Name,
                        LayerOpacity = (layer.Opacity / 255d) * 100,
                        Tag = layer,
                    };
                    layerPanel.ProcessLayer(layer, psdFile.Width, psdFile.Height);
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
                splitContainer.Panel2.Controls.Add(new LayerDetailsPanel()
                {
                    Dock = DockStyle.Top,
                    IsHidden = selectedLayer.IsHidden,
                    LayerImage = selectedLayer.Image,
                    LayerName = selectedLayer.LayerName
                });
            }
            else
            {
                splitContainer.Panel2.Controls.Add(noDetailsLabel);
            }

        }

        private void OpenPsdMenuItem_Click(object sender, EventArgs e)
        {
            if (openPsdDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openPsdDialog.FileName);
            }
        }
    }
}
