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
    public partial class ImageToolbox : Form
    {
        private const int FolderIndent = 30;

        private PsdFile psdFile;

        public ImageToolbox()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            OpenFile(@"C:\dev\ImageToolbox\ImageToolbox\bin\Debug\Puggle_200.psd");
        }

        public void OpenFile(string path)
        {
            psdFile = new PsdFile(path);
            pathLabel.Text = path;
            mainPictureBox.Image = psdFile.Bitmap;
            int column = 0;
            foreach (PsdLayer layer in psdFile.Layers.Reverse())
            {
                Control row;
                if (layer.IsFolderBegin)
                {
                    row = new LayerFolderPanel()
                    {
                        Dock = DockStyle.Top,
                        FolderName = layer.Name,
                        Padding = new Padding(column * FolderIndent, 0, 0, 10)
                    };
                    column++;
                }
                else if (layer.IsFolderEnd)
                {
                    column--;
                    continue;
                }
                else
                {
                    row = new LayerPanel()
                    {
                        Dock = DockStyle.Top,
                        LayerName = layer.Name,
                        Padding = new Padding(column * FolderIndent, 0, 0, 10)
                    };
                }
                layersPanel.Controls.Add(row);
                layersPanel.Controls.SetChildIndex(row, 0);
            }
        }

        private void OpenPsdMenuItem_Click(object sender, EventArgs e)
        {
            if (openPsdDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openPsdDialog.FileName);
            }
        }
    }
}
