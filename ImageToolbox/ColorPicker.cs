using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToolbox
{
    public partial class ColorPicker : Form
    {
        private readonly PathGradientBrush squareBrush;
        private readonly PathGradientBrush barBrush;

        public ColorPicker()
        {
            InitializeComponent();

            Rectangle square = new Rectangle(20, 20, 400, 400);
            squareBrush = new PathGradientBrush(new Point[] {
                new Point(square.Left, square.Top),
                new Point(square.Right, square.Top),
                new Point(square.Right, square.Bottom),
                new Point(square.Left, square.Bottom),
            });
            Rectangle bar = new Rectangle(square.Right + 40, square.Top, 40, square.Height);
            barBrush = new PathGradientBrush(new Point[] {
                new Point(bar.Left, bar.Top),
                new Point(bar.Right, bar.Top),
                new Point(bar.Right, bar.Bottom),
                new Point(bar.Left, bar.Bottom),
            });

            squareBrush.CenterColor = Color.FromArgb(255, 128, 0, 0);
            squareBrush.SurroundColors = new Color[] { Color.White, Color.Red, Color.Black, Color.Black };

            barBrush.CenterColor = Color.FromArgb(255, 128, 128, 128);
            barBrush.SurroundColors = new Color[] {
                Color.FromArgb(255, 0, 128, 128),
                Color.FromArgb(255, 0, 128, 128),
                Color.FromArgb(255, 255, 128, 128),
                Color.FromArgb(255, 255, 128, 128),
            };
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            if (squareBrush.Rectangle.IntersectsWith(e.ClipRectangle))
            {
                e.Graphics.FillRectangle(squareBrush, squareBrush.Rectangle);
            }

            if (barBrush.Rectangle.IntersectsWith(e.ClipRectangle))
            {
                e.Graphics.FillRectangle(barBrush, barBrush.Rectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
