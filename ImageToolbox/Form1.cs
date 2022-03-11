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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Output(object line)
        {
            outputTextBox.AppendText(line.ToString() + Environment.NewLine);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PsdFile file = new PsdFile(@"Puggle_200.psd");
            Output("==========");
            Output($"Signature: {file.Signature}");
            Output($"Version: {file.Version}");
            Output($"Channels: {file.Channels}");
            Output($"Size: {file.Width} x {file.Height}");
            Output($"Depth: {file.Depth}");
            Output($"Color Mode: {file.ColorMode}");
            Output("==========");
            Output($"Color Mode Data Length: {file.ColorModeData.Length}");
            Output("==========");
            foreach (PsdImageResource resource in file.ImageResources)
            {
                Output($"{resource.Signature} {resource.Id:x4} {resource.Name} {resource.Data.Length}: {string.Join(" ", resource.Data.Select(b => $"{b:x2}"))}");
            }
            Output("==========");
            foreach (PsdLayer layer in file.Layers)
            {
                Output($"{layer.Name}");
            }
            Output("==========");
            //pictureBox1.Image = file.Bitmap;
            pictureBox1.Image = file.Layers[5].GetBitmap();
        }
    }
}
