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

        public string FolderName
        {
            get => nameLabel.Text;
            set => nameLabel.Text = value;
        }
    }
}
