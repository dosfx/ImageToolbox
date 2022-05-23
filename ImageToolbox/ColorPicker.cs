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
        private readonly PathGradientBrush hueRingBrush;
        private readonly TextureBrush alphaBackBrush;
        private readonly LinearGradientBrush alphaBrush;
        private readonly LinearGradientBrush redBrush;
        private readonly LinearGradientBrush greenBrush;
        private readonly LinearGradientBrush blueBrush;
        private readonly LinearGradientBrush hueBrush;
        private readonly LinearGradientBrush satBrush;
        private readonly LinearGradientBrush valBrush;
        private readonly SolidBrush oldColorBrush;
        private readonly SolidBrush newColorBrush;
        private readonly SolidBrush textBrush;
        private readonly Pen borderPen;
        private readonly Pen selectionPen;

        private HsvColor hsvColor;
        private int alpha;
        private bool ringDrag;
        private bool squareDrag;
        private bool alphaDrag;
        private bool redDrag;
        private bool greenDrag;
        private bool blueDrag;
        private bool hueDrag;
        private bool satDrag;
        private bool valDrag;

        public ColorPicker()
        {
            InitializeComponent();

            // number of points for the gradient, 24 seems to be good smoothness
            const int points = 24;

            // get bounds from the placeholders
            pickerBounds = GetBoundsFromPlaceholder(ref pickerLabel);
            newColorBounds = GetBoundsFromPlaceholder(ref newColorLabel);
            oldColorBounds = GetBoundsFromPlaceholder(ref oldColorLabel);

            // radius is slightly bigger to account for the corners of the gradiant path
            double radius = (pickerBounds.Width / 2) / Math.Cos(Math.PI / points);

            // fudge it one bigger to smooth out a little more
            radius += 1;

            // center is pretty simple
            PointF center = Center(pickerBounds);
            hueRingBrush = new PathGradientBrush(Enumerable.Range(0, points).Select(i =>
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
            squareBackgrounds = Properties.Resources.Gradients;

            // pick the most average color for the center
            hueRingBrush.CenterColor = Color.FromArgb(255, 128, 128, 128);

            // distribute the colors around the points
            hueRingBrush.SurroundColors = Enumerable.Range(0, points).Select(i =>
            {
                return HslColor.FromHsl(i * (360f / points), 1, 0.5f).ToColor();
            }).ToArray();

            using (Bitmap alphaBackground = new Bitmap(10, 10))
            using (Graphics g = Graphics.FromImage(alphaBackground))
            {
                g.Clear(Color.White);
                g.FillRectangle(Brushes.LightGray, 5, 0, 5, 5);
                g.FillRectangle(Brushes.LightGray, 0, 5, 5, 5);

                alphaBackBrush = new TextureBrush(alphaBackground);
            }

            alphaBrush = new LinearGradientBrush(GetBoundsFromPlaceholder(ref alphaLabel), default, default, LinearGradientMode.Horizontal);
            redBrush = new LinearGradientBrush(GetBoundsFromPlaceholder(ref redLabel), default, default, LinearGradientMode.Horizontal);
            greenBrush = new LinearGradientBrush(GetBoundsFromPlaceholder(ref greenLabel), default, default, LinearGradientMode.Horizontal);
            blueBrush = new LinearGradientBrush(GetBoundsFromPlaceholder(ref blueLabel), default, default, LinearGradientMode.Horizontal);
            hueBrush = new LinearGradientBrush(GetBoundsFromPlaceholder(ref hueLabel), default, default, LinearGradientMode.Horizontal)
            {
                InterpolationColors = new ColorBlend()
                {
                    Colors = Enumerable.Range(0, 7).Select(i => HsvColor.FromHsv((i / 6f) * 360, 1, 1).ToColor()).ToArray(),
                    Positions = Enumerable.Range(0, 7).Select(i => i / 6f).ToArray(),
                }
            };
            satBrush = new LinearGradientBrush(GetBoundsFromPlaceholder(ref satLabel), default, default, LinearGradientMode.Horizontal);
            valBrush = new LinearGradientBrush(GetBoundsFromPlaceholder(ref valLabel), default, default, LinearGradientMode.Horizontal);
            newColorBrush = new SolidBrush(default);
            oldColorBrush = new SolidBrush(default);
            textBrush = new SolidBrush(ForeColor);
            borderPen = new Pen(Color.FromArgb(255, 100, 100, 100));
            selectionPen = new Pen(default(Color), 4);
            alpha = 255;
            Color = default;
        }

        ~ColorPicker()
        {
            hueRingBrush.Dispose();
            alphaBackBrush.Dispose();
            alphaBrush.Dispose();
            redBrush.Dispose();
            greenBrush.Dispose();
            blueBrush.Dispose();
            hueBrush.Dispose();
            satBrush.Dispose();
            valBrush.Dispose();
            newColorBrush.Dispose();
            oldColorBrush.Dispose();
            textBrush.Dispose();
            borderPen.Dispose();
            selectionPen.Dispose();
        }

        public Color Color
        {
            get => newColorBrush.Color;
            set
            {
                oldColorBrush.Color = value;
                SetColor(value);
            }
        }

        private void CancelLabel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkLabel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode ==  Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
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
                    SetHueFromRing(e.Location);
                }
                else if (squareBounds.Contains(e.Location))
                {
                    // inside the inner square
                    squareDrag = true;
                    SetSatValFromSquare(e.Location);
                }
            }
            else if (alphaBrush.Rectangle.Contains(e.Location))
            {
                alphaDrag = true;
                SetAlphaFromBar(e.Location);
            }
            else if (redBrush.Rectangle.Contains(e.Location))
            {
                redDrag = true;
                SetRedFromBar(e.Location);
            }
            else if (greenBrush.Rectangle.Contains(e.Location))
            {
                greenDrag = true;
                SetGreenFromBar(e.Location);
            }
            else if (blueBrush.Rectangle.Contains(e.Location))
            {
                blueDrag = true;
                SetBlueFromBar(e.Location);
            }
            else if (hueBrush.Rectangle.Contains(e.Location))
            {
                hueDrag = true;
                SetHueFromBar(e.Location);
            }
            else if (satBrush.Rectangle.Contains(e.Location))
            {
                satDrag = true;
                SetSatFromBar(e.Location);
            }
            else if (valBrush.Rectangle.Contains(e.Location))
            {
                valDrag = true;
                SetValFromBar(e.Location);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (ringDrag)
            {
                // update the color
                SetHueFromRing(e.Location);
            }
            else if (squareDrag)
            {
                // update the color, which also updates the little selection ring
                SetSatValFromSquare(e.Location);
            }
            else if (alphaDrag)
            {
                SetAlphaFromBar(e.Location);
            }
            else if (redDrag)
            {
                SetRedFromBar(e.Location);
            }
            else if (greenDrag)
            {
                SetGreenFromBar(e.Location);
            }
            else if (blueDrag)
            {
                SetBlueFromBar(e.Location);
            }
            else if (hueDrag)
            {
                SetHueFromBar(e.Location);
            }
            else if (satDrag)
            {
                SetSatFromBar(e.Location);
            }
            else if (valDrag)
            {
                SetValFromBar(e.Location);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            ringDrag = false;
            squareDrag = false;
            alphaDrag = false;
            redDrag = false;
            greenDrag = false;
            blueDrag = false;
            hueDrag = false;
            satDrag = false;
            valDrag = false;
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
                g.FillEllipse(hueRingBrush, rectangle);

                // draw a circle over the center to convert the hue circle into a ring
                using (SolidBrush brush = new SolidBrush(BackColor))
                {
                    rectangle.Inflate(-hueRingWidth, -hueRingWidth);
                    g.FillEllipse(brush, rectangle);
                }
            }

            g.SmoothingMode = SmoothingMode.None;

            // draw the picker square
            g.DrawImage(squareBackgrounds, squareBounds, new Rectangle(GetBackgroundPointFromHue(hsvColor.Hue), squareBounds.Size), GraphicsUnit.Pixel);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // draw the selections
            g.DrawEllipse(selectionPen, CenterSquare(SatValToPoint(hsvColor.Saturation, hsvColor.Value), 10));
            g.DrawEllipse(selectionPen, CenterSquare(HueToPoint(hsvColor.Hue), 10));

            g.SmoothingMode = SmoothingMode.None;

            // draw the new/old palettes
            g.FillRectangle(alphaBackBrush, Rectangle.Union(newColorBounds, oldColorBounds));
            g.FillRectangle(newColorBrush, newColorBounds);
            g.FillRectangle(oldColorBrush, oldColorBounds);
            g.DrawRectangle(borderPen, Rectangle.Union(newColorBounds, oldColorBounds));

            // bars
            g.FillRectangle(alphaBackBrush, alphaBrush.Rectangle);
            DrawBar(g, alphaBrush, "A", Color.A.ToString(), Color.A / 255f);
            DrawBar(g, redBrush, "R", Color.R.ToString(), Color.R / 255f);
            DrawBar(g, greenBrush, "G", Color.G.ToString(), Color.G / 255f);
            DrawBar(g, blueBrush, "B", Color.B.ToString(), Color.B / 255f);
            DrawBar(g, hueBrush, "H", hsvColor.Hue.ToString("0°"), hsvColor.Hue / 360f);
            DrawBar(g, satBrush, "S", hsvColor.Saturation.ToString("0%"), hsvColor.Saturation);
            DrawBar(g, valBrush, "V", hsvColor.Value.ToString("0%"), hsvColor.Value);
        }

        private int BarValueToX(float value, RectangleF bounds)
        {
            return (int)((value * bounds.Width) + bounds.Left);
        }

        private void DrawBar(Graphics g, LinearGradientBrush brush, string label, string valueStr, float value)
        {
            Rectangle bounds = Rectangle.Round(brush.Rectangle);
            GraphicsState state = g.Save();
            g.SmoothingMode = SmoothingMode.None;

            // draw the bar and border
            g.FillRectangle(brush, bounds);
            g.DrawRectangle(borderPen, bounds);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // label
            g.DrawString(label, Font, textBrush, new RectangleF(brush.Rectangle.Location - new Size(20, 0), new Size(20, 20)),
                new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            // convert the value into bar bounds
            value = BarValueToX(value, brush.Rectangle);

            // value label
            g.DrawString(valueStr, Font, textBrush, new RectangleF(brush.Rectangle.Location + new SizeF(brush.Rectangle.Width, 0), new Size(40, 20)),
                new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            // value ticks
            g.FillRectangle(textBrush, CenterSquare(new PointF(value, brush.Rectangle.Top - 2), 3));
            g.FillRectangle(textBrush, CenterSquare(new PointF(value, brush.Rectangle.Bottom + 2), 3));

            g.Restore(state);
        }

        private Rectangle GetBoundsFromPlaceholder(ref Label placeholder)
        {
            Rectangle bounds = placeholder.Bounds;
            Controls.Remove(placeholder);
            placeholder.Dispose();
            placeholder = null;
            return bounds;
        }

        private Point GetBackgroundPointFromHue(float hue)
        {
            const int gridWidth = 20;
            return new Point((int)Math.Floor(hue % gridWidth) * squareBounds.Width, (int)Math.Floor(hue / gridWidth) * squareBounds.Height);
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

        private float PointToBar(Point p, RectangleF bounds)
        {
            // clamp into the bar
            int x = Math.Min(Math.Max((int)bounds.Left, p.X), (int)bounds.Right);

            // math
            return (x - bounds.Left) / bounds.Width;
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

        private PointF SatValToPoint(float sat, float val)
        {
            return new PointF((sat * squareBounds.Width) + squareBounds.X,
                ((1 - val) * squareBounds.Height) + squareBounds.Y);
        }

        private void SetAlphaFromBar(Point p)
        {
            alpha = (int)(PointToBar(p, alphaBrush.Rectangle) * 255);

            // "set" the color to itself to get it to notice the new alpha
            SetColor(hsvColor);
        }

        private void SetBlueFromBar(Point p)
        {
            SetColor(SetBlue(Color, (int)(PointToBar(p, blueBrush.Rectangle) * 255)));
        }

        private void SetColor(Color color)
        {
            SetColor(HsvColor.FromColor(color));
        }

        private void SetColor(HsvColor hsv)
        {
            hsvColor = hsv;
            Color color = Color.FromArgb(alpha, hsv.ToColor());
            newColorBrush.Color = color;
            alphaBrush.LinearColors = new[] { SetAlpha(color, 0), SetAlpha(color, 255) };
            Color noAlpha = SetAlpha(color, 255);
            redBrush.LinearColors = new[] { SetRed(noAlpha, 0), SetRed(noAlpha, 255) };
            greenBrush.LinearColors = new[] { SetGreen(noAlpha, 0), SetGreen(noAlpha, 255) };
            blueBrush.LinearColors = new[] { SetBlue(noAlpha, 0), SetBlue(noAlpha, 255) };
            satBrush.LinearColors = new[] { SetSaturation(hsvColor, 0), SetSaturation(hsvColor, 1) };
            valBrush.LinearColors = new[] { SetValue(hsvColor, 0), SetValue(hsvColor, 1) };

            // selection color is the inverted hue
            selectionPen.Color = HsvColor.FromHsv((hsvColor.Hue + 180) % 360, 1, 1).ToColor();
            Invalidate();
        }

        private void SetGreenFromBar(Point p)
        {
            SetColor(SetGreen(Color, (int)(PointToBar(p, greenBrush.Rectangle) * 255)));
        }

        private void SetHueFromBar(Point p)
        {
            SetColor(HsvColor.FromHsv(PointToBar(p, hueBrush.Rectangle) * 360, hsvColor.Saturation, hsvColor.Value));
        }

        private void SetHueFromRing(Point p)
        {
            // no clamping needed
            SetColor(HsvColor.FromHsv(PointToHue(p), hsvColor.Saturation, hsvColor.Value));
        }

        private void SetRedFromBar(Point p)
        {
            SetColor(SetRed(Color, (int)(PointToBar(p, redBrush.Rectangle) * 255)));
        }

        private void SetSatFromBar(Point p)
        {
            SetColor(SetSaturation(hsvColor, PointToBar(p, satBrush.Rectangle)));
        }

        private void SetSatValFromSquare(Point p)
        {
            // clamp into the square
            p.X = Math.Min(Math.Max(squareBounds.Left, p.X), squareBounds.Right);
            p.Y = Math.Min(Math.Max(squareBounds.Top, p.Y), squareBounds.Bottom);

            // math out the sat and val
            SetColor(HsvColor.FromHsv(hsvColor.Hue, PointToSat(p), PointToVal(p)));
        }

        private void SetValFromBar(Point p)
        {
            SetColor(SetValue(hsvColor, PointToBar(p, valBrush.Rectangle)));
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

        private static Color SetAlpha(Color color, int alpha)
        {
            return Color.FromArgb(alpha, color.R, color.G, color.B);
        }

        private static Color SetBlue(Color color, int blue)
        {
            return Color.FromArgb(color.A, color.R, color.G, blue);
        }

        private static Color SetGreen(Color color, int green)
        {
            return Color.FromArgb(color.A, color.R, green, color.B);
        }

        private static Color SetRed(Color color, int red)
        {
            return Color.FromArgb(color.A, red, color.G, color.B);
        }

        private static Color SetSaturation(HsvColor color, float saturation)
        {
            return HsvColor.FromHsv(color.Hue, saturation, color.Value).ToColor();
        }

        private static Color SetValue(HsvColor color, float value)
        {
            return HsvColor.FromHsv(color.Hue, color.Saturation, value).ToColor();
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
