using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToolbox
{
    public partial class ColorPicker : Form
    {
        private const int hueRingWidth = 32;
        private const double hueOffsetRadians = Math.PI + (Math.PI / 6);
        private readonly Rectangle pickerBounds;
        private readonly Rectangle squareBounds;
        private readonly Rectangle newColorBounds;
        private readonly Rectangle oldColorBounds;
        private readonly Image squareBackgrounds;
        private readonly PathGradientBrush hueBrush;
        private readonly SolidBrush oldColorBrush;
        private readonly SolidBrush newColorBrush;
        private readonly Pen borderPen;
        private readonly Pen selectionPen;

        private bool ringDrag;
        private bool squareDrag;
        private HsvColor hsvColor;

        public ColorPicker()
        {
            InitializeComponent();

            // number of points for the gradient, 24 seems to be good smoothness
            const int points = 24;

            // get bounds from the placeholders
            GetBoundsFromPlaceholder(ref pickerLabel, ref pickerBounds);
            GetBoundsFromPlaceholder(ref newColorLabel, ref newColorBounds);
            GetBoundsFromPlaceholder(ref oldColorLabel, ref oldColorBounds);

            // get the image from the placeholder
            GetImageFromPlaceholder(ref squareImage, ref squareBackgrounds);

            // radius is slightly bigger to account for the corners of the gradiant path
            double radius = (pickerBounds.Width / 2) / Math.Cos(Math.PI / points);

            // fudge it one bigger to smooth out a little more
            radius += 1;

            // center is pretty simple
            PointF center = Center(pickerBounds);
            hueBrush = new PathGradientBrush(Enumerable.Range(0, points).Select(i =>
            {
                // convert index into degrees into radians
                double rad = ToRadians(i * (360d / points));

                // shift around to get red in the right spot
                rad += hueOffsetRadians;

                // trig out the coords
                return new PointF((float)(Math.Cos(rad) * radius) + center.X, (float)(Math.Sin(rad) * radius) + center.Y);
            }).ToArray());

            // math out the bounds of the inner square want the corner to just touch the inside of the 
            float size = (float)(((pickerBounds.Width / 2) - hueRingWidth - 1) * Math.Cos(Math.PI / 4)) - 4;
            squareBounds = CenterSquare(Point.Truncate(center), (int)size);

            // pick the most average color for the center
            hueBrush.CenterColor = Color.FromArgb(255, 128, 128, 128);

            // distribute the colors around the points
            hueBrush.SurroundColors = Enumerable.Range(0, points).Select(i =>
            {
                return HslColor.FromHsl(i * (360f / points), 1, 0.5f).ToColor();
            }).ToArray();

            newColorBrush = new SolidBrush(default);
            oldColorBrush = new SolidBrush(default);
            borderPen = new Pen(Color.FromArgb(255, 100, 100, 100));
            selectionPen = new Pen(default(Color), 4);
            Color = Color.Red;
        }

        ~ColorPicker()
        {
            squareBackgrounds.Dispose();
            hueBrush.Dispose();
            newColorBrush.Dispose();
            oldColorBrush.Dispose();
            borderPen.Dispose();
            selectionPen.Dispose();
        }

        public Color Color
        {
            get => newColorBrush.Color;
            set
            {
                newColorBrush.Color = value;
                oldColorBrush.Color = value;
                hsvColor = HsvColor.FromColor(value);
                CalcHueChange();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // broad contains somewhere in the square around the ring
            if (pickerBounds.Contains(e.Location))
            {
                if (PointInsideRing(e.Location))
                {
                    // inside the ring
                    ringDrag = true;
                    SetHueFromPoint(e.Location);
                }
                else if (squareBounds.Contains(e.Location))
                {
                    // inside the inner square
                    squareDrag = true;
                    SetColorFromPoint(e.Location);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (ringDrag)
            {
                // update the color
                SetHueFromPoint(e.Location);
            }
            else if (squareDrag)
            {
                // update the color, which also updates the little selection ring
                SetColorFromPoint(e.Location);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            ringDrag = false;
            squareDrag = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rectangle = pickerBounds;
            if (rectangle.IntersectsWith(e.ClipRectangle))
            {
                // draw the ring
                g.FillEllipse(hueBrush, rectangle);

                // draw a circle over the center to convert the hue circle into a ring
                using (SolidBrush brush = new SolidBrush(BackColor))
                {
                    rectangle.Inflate(-hueRingWidth, -hueRingWidth);
                    g.FillEllipse(brush, rectangle);
                }
            }

            // draw the picker square
            g.DrawImage(squareBackgrounds, squareBounds, new Rectangle(GetBackgroundPointFromHue(hsvColor.Hue), squareBounds.Size), GraphicsUnit.Pixel);

            // draw the selections
            g.DrawEllipse(selectionPen, CenterSquare(SatValToPoint(hsvColor.Saturation, hsvColor.Value), 10));
            g.DrawEllipse(selectionPen, CenterSquare(HueToPoint(hsvColor.Hue), 10));

            g.SmoothingMode = SmoothingMode.None;
            // draw the new/old palettes
            g.FillRectangle(newColorBrush, newColorBounds);
            g.FillRectangle(oldColorBrush, oldColorBounds);
            g.DrawRectangle(borderPen, Rectangle.Union(newColorBounds, oldColorBounds));
        }

        private void CalcHueChange()
        {
            // selection color is the inverted hue
            selectionPen.Color = HsvColor.FromHsv((hsvColor.Hue + 180) % 360, 1, 1).ToColor();
            Invalidate();
        }

        private void DisposePlaceholder<T>(ref T placeholder) where T : Control
        {
            Controls.Remove(placeholder);
            placeholder.Dispose();
            placeholder = null;
        }

        private void GetImageFromPlaceholder(ref PictureBox placeholer, ref Image image)
        {
            image = placeholer.Image;
            DisposePlaceholder(ref placeholer);
        }

        private void GetBoundsFromPlaceholder(ref Label placeholder, ref Rectangle bounds)
        {
            bounds = placeholder.Bounds;
            DisposePlaceholder(ref placeholder);
        }

        private Point GetBackgroundPointFromHue(float hue)
        {
            const int gridWidth = 20;
            return new Point((int)Math.Floor(hue % gridWidth) * squareBounds.Width, (int)Math.Floor(hue / gridWidth) * squareBounds.Height);
        }

        private bool PointInsideRing(Point p)
        {
            // calc the inner and out radii of the ring
            double outerRadius = pickerBounds.Width / 2d;
            double innerRadius = outerRadius - hueRingWidth;

            // square them to save a sqrt below
            outerRadius *= outerRadius;
            innerRadius *= innerRadius;

            // figure out the distance from the center
            PointF center = Center(pickerBounds);
            double radius2 = Math.Pow(p.Y - center.Y, 2) + Math.Pow(p.X - center.X, 2);
            
            // check the range
            return innerRadius <= radius2 && radius2 <= outerRadius;
        }

        private float PointToHue(Point p)
        {
            PointF center = Center(pickerBounds);
            double rad = Math.Atan2(p.Y - center.Y, p.X - center.X);

            // shift around to get red in the right spot
            rad -= hueOffsetRadians;

            double deg = ToDegrees(rad);

            // bring into range
            deg = (deg + 720) % 360;
            return (float)deg;
        }

        private float PointToSat(Point p)
        {
            return (p.X - (float)squareBounds.X) / squareBounds.Width;
        }

        private float PointToVal(Point p)
        {
            return 1 - ((p.Y - (float)squareBounds.Y) / squareBounds.Height);
        }

        private PointF HueToPoint(float hue)
        {
            // radius of the middle of the ring
            double radius = pickerBounds.Width / 2;
            radius -= hueRingWidth / 2;
            PointF center = Center(pickerBounds);
            double rad = ToRadians(hue);
            rad += hueOffsetRadians;
            return new PointF((float)(Math.Cos(rad) * radius) + center.X, (float)(Math.Sin(rad) * radius) + center.Y);
        }

        private PointF SatValToPoint(float sat, float val)
        {
            return new PointF((sat * squareBounds.Width) + squareBounds.X,
                ((1 - val) * squareBounds.Height) + squareBounds.Y);
        }

        private void SetColorFromPoint(Point p)
        {
            // clamp into the square
            p.X = Math.Min(Math.Max(squareBounds.Left, p.X), squareBounds.Right);
            p.Y = Math.Min(Math.Max(squareBounds.Top, p.Y), squareBounds.Bottom);

            // math out the sat and val
            hsvColor = HsvColor.FromHsv(hsvColor.Hue, PointToSat(p), PointToVal(p));
            newColorBrush.Color = hsvColor.ToColor();
            Invalidate();
        }

        private void SetHueFromPoint(Point p)
        {
            hsvColor = HsvColor.FromHsv(PointToHue(p), hsvColor.Saturation, hsvColor.Value);
            newColorBrush.Color = hsvColor.ToColor();

            // also invalidates
            CalcHueChange();
        }

        private static PointF Center(Rectangle rect)
        {
            return PointF.Add(rect.Location, new SizeF(rect.Width / 2f, rect.Height / 2f));
        }

        private static Rectangle CenterSquare(Point center, int size)
        {
            return Rectangle.Round(CenterSquare((PointF)center, size));
        }

        private static RectangleF CenterSquare(PointF center, float size)
        {
            SizeF s = new SizeF(size, size);
            return new RectangleF(PointF.Subtract(center, s), s + s);
        }

        private static double ToDegrees(double rad)
        {
            return rad * (180 / Math.PI);
        }

        private static double ToRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }
}
