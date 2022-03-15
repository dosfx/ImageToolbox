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
            Stack<LayerFolderPanel> currentFolder = new Stack<LayerFolderPanel>();
            currentFolder.Push(new LayerFolderPanel() { FolderName = "Root" });
            foreach (PsdLayer layer in psdFile.Layers.Reverse())
            {
                if (layer.IsFolderBegin)
                {
                    currentFolder.Push(new LayerFolderPanel()
                    {
                        FolderName = layer.Name
                    });
                }
                else if (layer.IsFolderEnd)
                {
                    LayerFolderPanel folder = currentFolder.Pop();
                    currentFolder.Peek().AddLayer(folder);
                }
                else
                {
                    currentFolder.Peek().AddLayer(new LayerPanel()
                    {
                        Image = layer.GetBitmap(),
                        LayerName = layer.Name
                    });
                }
            }
            LayerFolderPanel root = currentFolder.Pop();
            root.Dock = DockStyle.Top;
            root.IsRoot = true;
            layersPanel.Controls.Add(root);
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
