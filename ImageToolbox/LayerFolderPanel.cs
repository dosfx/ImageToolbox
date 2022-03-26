using System;
using System.Windows.Forms;

namespace ImageToolbox
{
    partial class LayerFolderPanel : UserControl
    {

        public LayerFolderPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public string FolderName
        {
            get => nameLabel.Text;
            set => nameLabel.Text = value;
        }

        public bool IsHidden
        {
            get => hiddenLabel.Text == LayerPanel.HiddenText;
            set => hiddenLabel.Text = value ? LayerPanel.HiddenText : LayerPanel.VisibleText;
        }

        private bool _isOpen;
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                folderBox.Image = value ? Properties.Resources.FolderMinusSolid : Properties.Resources.FolderPlusSolid;
                SuspendLayout();
                layersPanel.Visible = IsOpen;
                ResumeLayout();
            }
        }

        public ControlCollection LayerControls => layersPanel.Controls;

        private void FolderBox_Click(object sender, EventArgs e)
        {
            IsOpen = !IsOpen;
        }
    }
}
