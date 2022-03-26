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
    partial class LayerPanel : UserControl
    {
        public const string HiddenText = "Hidden";
        public const string VisibleText = "Visible";
        public LayerPanel()
        {
            InitializeComponent();

            IsHidden = false;
        }

        public double LayerOpacity
        {
            set => opacityLabel.Text = $"{value:.00}% opacity";
        }

        public Image Image
        {
            get => imageBox.Image;
            set => imageBox.Image = value;
        }

        public bool IsHidden
        {
            get => hiddenLabel.Text == HiddenText;
            set => hiddenLabel.Text = value ? HiddenText : VisibleText;
        }

        public string LayerName
        {
            get => nameLabel.Text;
            set => nameLabel.Text = value;
        }

        public void ProcessLayer(PsdLayer layer, int psdWidth, int psdHeight)
        {
            backgroundWorker.RunWorkerAsync(new Tuple<PsdLayer, int, int>(layer, psdWidth, psdHeight));
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Tuple<PsdLayer, int, int> args = (Tuple<PsdLayer, int, int>)e.Argument;
            PsdLayer layer = args.Item1;
            int psdWidth = args.Item2;
            int psdHeight = args.Item3;
            Image displayImage = new Bitmap(psdWidth, psdHeight);
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
                }
            }
            averageTransparency /= totalPixels;
            averageTransparency *= 100;
            transparent += (psdWidth * psdHeight) - (layer.Bounds.Width * layer.Bounds.Height);
        
            e.Result = new Tuple<Image, int, double, int, double>(displayImage, totalPixels, weightedPixels, transparent, averageTransparency);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Tuple<Image, int, double, int, double> args = (Tuple<Image, int, double, int, double>)e.Result;
            imageBox.Image = args.Item1;
            totalLabel.Text = $"{args.Item2} image pixels";
            weightedLabel.Text = $"{args.Item3:.00} weighted pixels";
            transparentLabel.Text = $"{args.Item4} fully transparent pixels";
            averageLabel.Text = $"{args.Item5:.00}% average transparency";
        }
    }
}
