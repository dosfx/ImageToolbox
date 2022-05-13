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
    public partial class ImageToolboxForm : Form
    {
        private PsdFile psdFile;
        private LayerPanel baseLayer;
        private LayerPanel selectedLayer;
        private object selectedTab;
        private LayerDetailsPanel layerDetailsPanel;
        private readonly Dictionary<PsdLayer, LayerDetailsPanel.Details> layerDetails;

        public ImageToolboxForm()
        {
            InitializeComponent();

            layerDetails = new Dictionary<PsdLayer, LayerDetailsPanel.Details>();
            SelectTab(detailsTabLabel);
        }

        private bool DetailsTabSelected => selectedTab == detailsTabLabel;
        private bool RecolorTabSelected => selectedTab == recolorTabLabel;

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
            recolorPanel.Clear();
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
            recolorPanel.ImageSize = new Size(psdFile.Width, psdFile.Height);
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
                        RightArrowVisible = RecolorTabSelected,
                        Tag = layer,
                    };
                    layerPanel.BaseLayerCheckedChanged += LayerPanel_BaseLayerCheckedChanged;
                    layerPanel.RightArrowClick += LayerPanel_RightArrowClick;
                    layerPanel.SelectedChanged += LayerPanel_SelectedChanged;
                    row = layerPanel;
                }
                currentLevel.Add(row);
                currentLevel.SetChildIndex(row, 0);
            }
            layersPanel.ResumeLayout();
            layersPanel.Visible = true;
        }

        private void LayerPanel_BaseLayerCheckedChanged(object sender, EventArgs e)
        {
            // sender is the layer panel
            LayerPanel layerPanel = (LayerPanel)sender;
            SelectBaseLayer(layerPanel.BaseLayerChecked ? layerPanel : null);
        }

        private void LayerPanel_RightArrowClick(object sender, EventArgs e)
        {
            if (sender is LayerPanel panel && panel.Tag is PsdLayer layer)
            {
                recolorPanel.AddLayer(layer);
            }
        }

        private void SelectBaseLayer(LayerPanel newBaseLayer)
        {
            if (baseLayer != null)
            {
                // first uncheck the old one
                baseLayer.BaseLayerCheckedChanged -= LayerPanel_BaseLayerCheckedChanged;
                baseLayer.BaseLayerChecked = false;
                baseLayer.BaseLayerCheckedChanged += LayerPanel_BaseLayerCheckedChanged;
            }

            baseLayer = newBaseLayer;
            if (baseLayer != null)
            {
                // clear all the details stuff
                SelectLayer(null);
                layerDetails.Clear();
            }
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
            detailsPanel.Controls.Clear();

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
                        BaseLayer = baseLayer?.Tag as PsdLayer,
                        Layer = layer,
                        Width = psdFile.Width,
                        Height = psdFile.Height
                    };
                    layerDetails.Add(layer, details);
                }

                if (layerDetailsPanel == null)
                {
                    layerDetailsPanel = new LayerDetailsPanel() { Dock = DockStyle.Top };
                }

                detailsPanel.Controls.Add(layerDetailsPanel);
                layerDetailsPanel.IsHidden = layer.IsHidden;
                layerDetailsPanel.LayerDetails = details;
                layerDetailsPanel.LayerName = layer.Name;
                layerDetailsPanel.LayerOpacity = (layer.Opacity / 255d) * 100;
            }
            else
            {
                detailsPanel.Controls.Add(noDetailsLabel);
            }
        }

        private void TabLabel_Click(object sender, EventArgs e)
        {
            SelectTab(sender);
        }

        private void SelectTab(object key)
        {
            selectedTab = key;
            foreach (Control control in tabsLayoutPanel.Controls)
            {
                control.Font = new Font(Font, control == key ? FontStyle.Bold : FontStyle.Regular);
                control.Margin = new Padding(control.Margin.Left, control == key ? 0 : 2, control.Margin.Right, control.Margin.Bottom);
                control.Padding = new Padding(control.Padding.Left, control.Padding.Top, control.Padding.Right, control == key ? 8 : 5);
            }

            if (DetailsTabSelected)
            {
                splitContainer.Panel2.Controls.SetChildIndex(detailsPanel, 0);
            }
            else if (RecolorTabSelected)
            {
                splitContainer.Panel2.Controls.SetChildIndex(recolorPanel, 0);
            }

            // show or hide the right arrows on the layers
            foreach (LayerPanel panel in layersPanel.Controls.OfType<LayerPanel>())
            {
                panel.RightArrowVisible = RecolorTabSelected;
            }
        }
    }
}
