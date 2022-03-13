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
        public LayerPanel()
        {
            InitializeComponent();
        }

        public Image Image
        {
            get => imageBox.Image;
            set => imageBox.Image = value;
        }

        public string LayerName
        {
            get => nameLabel.Text;
            set => nameLabel.Text = value;
        }
    }
}
