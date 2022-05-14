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
    public partial class RecolorLayerPanel : UserControl
    {
        public RecolorLayerPanel()
        {
            InitializeComponent();
        }

        public event EventHandler DownClick;
        public event EventHandler RemoveClick;
        public event EventHandler UpClick;

        public bool DownEnabled
        {
            set => downLabel.Enabled = value;
        }

        internal PsdLayer Layer { get; set; }

        public Image LayerIamge
        {
            set => pictureBox.Image = value;
        }

        public string LayerName
        {
            set => nameLabel.Text = value;
        }

        public bool UpEnabled
        {
            set => upLabel.Enabled = value;
        }

        private void DownLabel_Click(object sender, EventArgs e)
        {
            DownClick?.Invoke(this, e);
        }

        private void RemoveLabel_Click(object sender, EventArgs e)
        {
            RemoveClick?.Invoke(this, e);
        }

        private void UpLabel_Click(object sender, EventArgs e)
        {
            UpClick?.Invoke(this, e);
        }
    }
}
