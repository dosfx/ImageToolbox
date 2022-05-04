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
    public partial class LayerDetailsPanel : UserControl
    {
        public class Details
        {
            public bool Filled { get; set; }
            internal PsdLayer Layer { get; set; }
            internal PsdLayer BaseLayer { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int TotalPixels { get; set; }
            public double WeightedPixels { get; set; }
            public int TransparentPixels { get; set; }
            public double AverageTransparancy { get; set; }
            public int BaseInsidePixels { get; set; }
            public int BaseOutsidePixels { get; set; }
            public Bitmap BaseInsideImage { get; set; }
            public Bitmap BaseOutsideImage { get; set; }
        }

        private Details details;
        private bool baseInsideChecked;
        private bool baseOutsideChecked;

        public LayerDetailsPanel()
        {
            InitializeComponent();

            CalcHeight();
        }

        public string LayerName
        {
            set => nameLabel.Text = value;
        }

        public bool IsHidden
        {
            set => detailLabel.Text = value ? LayerPanel.HiddenText : LayerPanel.VisibleText;
        }

        public double LayerOpacity
        {
            set => opacityLabel.Text = $"Opacity: {value:.00}%";
        }

        public Details LayerDetails
        {
            set
            {
                details = value;
                if (details.Filled)
                {
                    FillDetails();
                }
                else
                {
                    progressBar.Visible = true;
                    progressBar.Maximum = details.Layer.Bounds.Width;
                    detailsWorker.RunWorkerAsync();
                    CalcHeight();
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            pictureBox.Size = new Size(pictureBox.Size.Width, pictureBox.Size.Width);
            CalcHeight();
        }

        private void CalcHeight()
        {
            Height = Controls.Cast<Control>().Where(c => c.Visible).Sum(c => c.Height) + Padding.Top + Padding.Bottom;
        }

        private void FillDetails()
        {
            DrawImage();
            totalLabel.Text = $"Total Pixels: {details.TotalPixels}";
            weightedLabel.Text = $"Weighted Pixels: {details.WeightedPixels:.00}";
            transparentLabel.Text = $"Transparent Pixels: {details.TransparentPixels}";
            averageLabel.Text = $"Average Transparency: {details.AverageTransparancy:.00}%";
            if (details.BaseLayer != null)
            {
                insideCheckBox.Text = $"Pixels Inside Base: {details.BaseInsidePixels}";
                insidePanel.Visible = true;
                outsideCheckBox.Text = $"Pixels Outside Base: {details.BaseOutsidePixels}";
                outsidePanel.Visible = true;
            }

            CalcHeight();
        }

        private void DrawImage()
        {
            Bitmap displayImage = new Bitmap(details.Width, details.Height);
            using (Graphics g = Graphics.FromImage(displayImage))
            {
                g.FillRectangle(Brushes.Gray, 0, 0, displayImage.Width, displayImage.Height);
                g.DrawImage(details.Layer.GetBitmap(), details.Layer.Bounds);

                if (baseInsideChecked)
                {
                    g.DrawImage(details.BaseInsideImage, details.Layer.Bounds);
                }

                if (baseOutsideChecked)
                {
                    g.DrawImage(details.BaseOutsideImage, details.Layer.Bounds);
                }
            }

            pictureBox.Image = displayImage;
        }

        private void AddDetail(string text)
        {
            Label label = new Label()
            {
                BorderStyle = detailLabel.BorderStyle,
                Dock = detailLabel.Dock,
                Height = detailLabel.Height,
                Text = text,
                TextAlign = detailLabel.TextAlign
            };
            Controls.Add(label);
            Controls.SetChildIndex(label, 0);
        }

        private void DetailsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap layerImage = details.Layer.GetBitmap();
            Bitmap baseLayerImage = details.BaseLayer?.GetBitmap();
            if (layerImage != null)
            {
                if (baseLayerImage != null)
                {
                    details.BaseInsideImage = new Bitmap(layerImage.Width, layerImage.Height);
                    details.BaseOutsideImage = new Bitmap(layerImage.Width, layerImage.Height);
                }

                for (int x = 0; x < layerImage.Width; x++)
                {
                    for (int y = 0; y < layerImage.Height; y++)
                    {
                        Color pixel = layerImage.GetPixel(x, y);
                        if (pixel.A == 0)
                        {
                            details.TransparentPixels++;
                        }
                        else
                        {
                            details.AverageTransparancy += pixel.A / 255d;
                            details.TotalPixels++;
                            details.WeightedPixels += pixel.A / 255d;

                            if (baseLayerImage != null)
                            {
                                // translate x,y from layer coords to baselayer coords
                                int baseX = x - details.Layer.Bounds.Left + details.BaseLayer.Bounds.Left;
                                int baseY = y - details.Layer.Bounds.Top + details.BaseLayer.Bounds.Top;
                                Color invert = HslColor.InvertColor(pixel);

                                // if x,y outside the layer bounds or the pixel is transparent
                                if (!(0 <= baseX && baseX < baseLayerImage.Width && 0 <= baseY && baseY < baseLayerImage.Height) ||
                                    baseLayerImage.GetPixel(baseX, baseY).A == 0)
                                {
                                    details.BaseOutsidePixels++;
                                    details.BaseOutsideImage.SetPixel(x, y, Color.Magenta);
                                }
                                else
                                {
                                    details.BaseInsidePixels++;
                                    details.BaseInsideImage.SetPixel(x, y, Color.Magenta);
                                }
                            }
                        }
                    }

                    detailsWorker.ReportProgress(x);
                }
            }

            // mark as filled
            details.Filled = true;

            // little bit of final tweaks to numbers
            details.AverageTransparancy /= details.TotalPixels;
            details.AverageTransparancy *= 100;
            details.TransparentPixels += (details.Width * details.Height) - (details.Layer.Bounds.Width * details.Layer.Bounds.Height);
        }

        private void DetailsWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void DetailsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(this, "Error occured while processing the layer, please send the PSD to Dos for correction.", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            progressBar.Visible = false;
            FillDetails();
        }

        private void InsideCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            baseInsideChecked = insideCheckBox.Checked;
            DrawImage();
        }

        private void OutsideCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            baseOutsideChecked = outsideCheckBox.Checked;
            DrawImage();
        }
    }
}
