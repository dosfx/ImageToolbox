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
        public LayerFolderPanel()
        {
            InitializeComponent();
        }

        public string FolderName
        {
            get => nameLabel.Text;
            set => nameLabel.Text = value;
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
    }
}
