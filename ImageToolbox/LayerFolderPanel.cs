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

        public bool IsOpen
        {
            get => collapseButton.Text == OpenButtonText;
            set
            {
                collapseButton.Text = value ? OpenButtonText : ClosedButtonText;
                for (int i = 1; i < tableLayoutPanel.RowCount - 1; i++)
                {
                    tableLayoutPanel.RowStyles[i].Height = 0;
                    tableLayoutPanel.RowStyles[i].SizeType = value ? SizeType.AutoSize : SizeType.Absolute;
                }
            }
        }

        public bool IsRoot
        {
            get => tableLayoutPanel.RowStyles[0].SizeType == SizeType.Absolute;
            set
            {
                tableLayoutPanel.RowStyles[0].Height = 0;
                tableLayoutPanel.RowStyles[0].SizeType = value ? SizeType.Absolute : SizeType.AutoSize;
            }
        }

        public void AddLayer(Control layer)
        {
            layer.Dock = DockStyle.Fill;
            tableLayoutPanel.RowCount++;
            tableLayoutPanel.RowStyles.Insert(tableLayoutPanel.RowCount - 2, new RowStyle() { SizeType = SizeType.AutoSize });
            tableLayoutPanel.Controls.Add(layer, 1, tableLayoutPanel.RowCount - 2);
        }

        private void CollapseButton_Click(object sender, EventArgs e)
        {
            IsOpen = !IsOpen;
        }
    }
}
