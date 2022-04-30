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
            public int Width { get; set; }
            public int Height { get; set; }
            public Image Image { get; set; }
            public int TotalPixels { get; set; }
            public double WeightedPixels { get; set; }
            public int TransparentPixels { get; set; }
            public double AverageTransparancy { get; set; }
        }

        private Details details;

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
            pictureBox.Image = details.Image;
            AddDetail($"Total Pixels: {details.TotalPixels}");
            AddDetail($"Weighted Pixels: {details.WeightedPixels:.00}");
            AddDetail($"Transparent Pixels: {details.TransparentPixels}");
            AddDetail($"Average Transparency: {details.AverageTransparancy:.00}%");
            CalcHeight();
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
            PsdLayer layer = details.Layer;
            Image displayImage = new Bitmap(details.Width, details.Height);
            Bitmap layerImage = layer.GetBitmap();

            int totalPixels = 0;
            double weightedPixels = 0;
            int transparent = 0;
            double averageTransparency = 0;

            if (layerImage != null)
            {
                using (Graphics g = Graphics.FromImage(displayImage))
                {
                    g.FillRectangle(Brushes.Gray, 0, 0, displayImage.Width, displayImage.Height);
                    g.DrawImage(layerImage, layer.Bounds);
                }

                for (int x = 0; x < layerImage.Width; x++)
                {
                    for (int y = 0; y < layerImage.Height; y++)
                    {
                        Color pixel = layerImage.GetPixel(x, y);
                        if (pixel.A == 0)
                        {
                            transparent++;
                        }
                        else
                        {
                            averageTransparency += pixel.A / 255d;
                            totalPixels++;
                            weightedPixels += pixel.A / 255d;
                        }
                    }

                    detailsWorker.ReportProgress(x);
                }
            }
            averageTransparency /= totalPixels;
            averageTransparency *= 100;
            transparent += (details.Width * details.Height) - (layer.Bounds.Width * layer.Bounds.Height);

            // put the details in the cache
            details.Image = displayImage;
            details.TotalPixels = totalPixels;
            details.WeightedPixels = weightedPixels;
            details.TransparentPixels = transparent;
            details.AverageTransparancy = averageTransparency;
            details.Filled = true;
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
    }
}
