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
    partial class LayerFolderPanel : UserControl
    {
        private const string OpenButtonText = "-";
        private const string ClosedButtonText = "+";

        public LayerFolderPanel()
        {
            InitializeComponent();
            collapseButton.Text = OpenButtonText;
        }

        public event EventHandler IsOpenChanged;

        public string FolderName
        {
            get => nameLabel.Text;
            set => nameLabel.Text = value;
        }

        public bool IsOpen
        {
            get => collapseButton.Text == OpenButtonText;
            set
            {
                collapseButton.Text = value ? OpenButtonText : ClosedButtonText;
                IsOpenChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void CollapseButton_Click(object sender, EventArgs e)
        {
            IsOpen = !IsOpen;
        }
    }
}
