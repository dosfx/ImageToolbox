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
        public LayerDetailsPanel()
        {
            InitializeComponent();
        }

        public string LayerName
        {
            set => nameLabel.Text = value;
        }

        public bool IsHidden
        {
            set => hiddenLabel.Text = value ? LayerPanel.HiddenText : LayerPanel.VisibleText;
        }

        public Image LayerImage
        {
            set => pictureBox.Image = value;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            pictureBox.Size = new Size(pictureBox.Size.Width, pictureBox.Size.Width);
            Height = Controls.Cast<Control>().Sum(c => c.Height + c.Padding.Top + c.Padding.Bottom);
        }

        private void ProcessLayerWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
