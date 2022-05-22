using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace GradGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int size = 236;
            Bitmap[] bitmaps = new Bitmap[360];
            Parallel.For(0, bitmaps.Length, i =>
            {
                Bitmap current = new Bitmap(size, size);
                // draw the picker gradient based on the hue
                BitmapData bitmapData = current.LockBits(new Rectangle(Point.Empty, new Size(size, size)), ImageLockMode.ReadWrite, current.PixelFormat);
                byte[] data = new byte[bitmapData.Stride * bitmapData.Height];
                for (int x = 0; x < current.Width; x++)
                {
                    for (int y = 0; y < current.Height; y++)
                    {
                        Color color = ImageToolbox.HsvColor.FromHsv(i * (360 / bitmaps.Length), x / (float)current.Width, 1 - (y / (float)current.Height)).ToColor();
                        data[(y * bitmapData.Stride) + (x * 4) + 3] = color.A;
                        data[(y * bitmapData.Stride) + (x * 4) + 2] = color.R;
                        data[(y * bitmapData.Stride) + (x * 4) + 1] = color.G;
                        data[(y * bitmapData.Stride) + (x * 4) + 0] = color.B;
                    }
                }
                Marshal.Copy(data, 0, bitmapData.Scan0, data.Length);
                current.UnlockBits(bitmapData);
                bitmaps[i] = current;
            });
            const int gridWidth = 20;
            const int gridHeight = 18;
            Bitmap main = new Bitmap(size * gridWidth, size * gridHeight);
            using (Graphics graphics = Graphics.FromImage(main))
            {
                for (int i = 0; i < bitmaps.Length; i++)
                {
                    Point p = new Point((i % gridWidth) * size, (i / gridWidth) * size);
                    graphics.DrawImageUnscaled(bitmaps[i], p);
                    // graphics.DrawString(i.ToString(), new Font("arial", 20), Brushes.Black, p);
                }
            }
            main.Save("gradients.png", ImageFormat.Png);
        }
    }
}
