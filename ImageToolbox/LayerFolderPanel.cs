using System;
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

        public bool IsOpen
        {
            get => collapseButton.Text == OpenButtonText;
            set
            {
                collapseButton.Text = value ? OpenButtonText : ClosedButtonText;
                SuspendLayout();
                layersPanel.Visible = IsOpen;
                ResumeLayout();
            }
        }

        public ControlCollection LayerControls => layersPanel.Controls;

        private void CollapseButton_Click(object sender, EventArgs e)
        {
            IsOpen = !IsOpen;
        }
    }
}
