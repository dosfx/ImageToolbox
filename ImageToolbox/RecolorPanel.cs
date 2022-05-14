using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToolbox
{
    public partial class RecolorPanel : UserControl
    {
        private readonly HashSet<PsdLayer> layers = new HashSet<PsdLayer>();

        public RecolorPanel()
        {
            InitializeComponent();
        }

        public Size ImageSize { get; set; }

        internal void AddLayer(PsdLayer layer)
        {
            if (layers.Contains(layer)) return;
            layers.Add(layer);
            Bitmap bitmap = new Bitmap(ImageSize.Width, ImageSize.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.Gray, 0, 0, ImageSize.Width, ImageSize.Height);
                g.DrawImage(layer.GetBitmap(), layer.Bounds.Left, layer.Bounds.Top);
            }

            RecolorLayerPanel layerPanel = new RecolorLayerPanel()
            {
                Dock = DockStyle.Top,
                Layer = layer,
                LayerIamge = bitmap,
                LayerName = layer.Name,
            };
            layerPanel.DownClick += LayerPanel_DownClick;
            layerPanel.RemoveClick += LayerPanel_RemoveClick;
            layerPanel.UpClick += LayerPanel_UpClick;
            layersPanel.Controls.Add(layerPanel);
            LayersChanged();
        }

        public void Clear()
        {
            layers.Clear();
            layersPanel.Controls.Clear();
            previewPanel.Controls.Clear();
            previewPanel.Controls.Add(addRecolorLabel);
        }

        private void LayerPanel_DownClick(object sender, EventArgs e)
        {
            if (!(sender is RecolorLayerPanel layerPanel)) return;
            int index = layersPanel.Controls.GetChildIndex(layerPanel);
            if (index == 0) return;
            layersPanel.Controls.SetChildIndex(layerPanel, index - 1);
            LayersChanged();
        }

        private void LayerPanel_RemoveClick(object sender, EventArgs e)
        {
            if (!(sender is RecolorLayerPanel layerPanel)) return;
            layers.Remove(layerPanel.Layer);
            layersPanel.Controls.Remove(layerPanel);
            LayersChanged();
        }

        private void LayerPanel_UpClick(object sender, EventArgs e)
        {
            if (!(sender is RecolorLayerPanel layerPanel)) return;
            int index = layersPanel.Controls.GetChildIndex(layerPanel);
            if (index == layersPanel.Controls.Count - 1) return;
            layersPanel.Controls.SetChildIndex(layerPanel, index + 1);
            LayersChanged();
        }

        private void LayersChanged()
        {
            // make all the updown buttons enabled
            foreach (RecolorLayerPanel panel in layersPanel.Controls)
            {
                panel.DownEnabled = true;
                panel.UpEnabled = true;
            }

            // disable the top and bottom buttons
            if (layersPanel.Controls.Count > 0)
            {
                ((RecolorLayerPanel)layersPanel.Controls[0]).DownEnabled = false;
                ((RecolorLayerPanel)layersPanel.Controls[layersPanel.Controls.Count - 1]).UpEnabled = false;
            }

            colorsPanel.Invalidate();
        }

        private void AddRecolorLabel_Click(object sender, EventArgs e)
        {
            previewPanel.Controls.Add(new PictureBox()
            {
                Dock = DockStyle.Left,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = 200,
            });
            LayersChanged();
        }

        private void ColorsPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(Point.Empty, colorsPanel.Size));
        }
    }
}
