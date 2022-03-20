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

        public int TotalPixels
        {
            set => totalLabel.Text = $"{value} image pixels";
        }

        public int FullyTransparentPixels
        {
            set => transparentLabel.Text = $"{value} fully transparent pixels";
        }

        public double WeightedPixels
        {
            set => weightedLabel.Text = $"{value:.00} weighted pixels";
        }

        public double AverageTransparency
        {
            set => averageLabel.Text = $"{value:.00}% average transparency";
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
    }
}
