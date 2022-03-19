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
                    LayerFolderPanel folder = new LayerFolderPanel()
                    {
                        Dock = DockStyle.Top,
                        FolderName = layer.Name,
                        Padding = new Padding(column * FolderIndent, 0, 0, 10)
                    };
                    folder.IsOpenChanged += LayerFolder_IsOpenChanged;
                    row = folder;
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

        private void LayerFolder_IsOpenChanged(object sender, EventArgs e)
        {
            layersPanel.SuspendLayout();
            Stack<LayerFolderPanel> folderStack = new Stack<LayerFolderPanel>();
            LayerFolderPanel changingFolder = (LayerFolderPanel)sender;
            folderStack.Push(changingFolder);
            for (int i = layersPanel.Controls.GetChildIndex(changingFolder) - 1; i >= 0; i--)
            {
                Control row = layersPanel.Controls[i];
                int indentDiff = (row.Padding.Left - folderStack.Peek().Padding.Left) / FolderIndent;
                if (indentDiff <= 0)
                {
                    for (int p = 0; p >= indentDiff && folderStack.Count > 0; p--)
                    {
                        folderStack.Pop();
                    }
                    if (folderStack.Count == 0)
                    {
                        break;
                    }
                }
                row.Visible = changingFolder.IsOpen && folderStack.Peek().IsOpen;
                if (row is LayerFolderPanel folder)
                {
                    folderStack.Push(folder);
                }
            }
            layersPanel.ResumeLayout(true);
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
