using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToolbox
{
    public struct HslColor
    {
        public float Hue { get; private set; }
        public float Saturation { get; private set; }
        public float Brightness { get; private set; }

        public Color ToColor()
        {
            double c = (1 - Math.Abs(Brightness + Brightness - 1)) * Saturation;
            double h = Hue / 60f;
            double x = c * (1 - Math.Abs((h % 2) - 1));
            double m = Brightness - (c / 2);
            double r = 0;
            double g = 0;
            double b = 0;
            if (0 <= h && h < 1)
            {
                r = c;
                g = x;
            }
            else if (1 <= h && h < 2)
            {
                r = x;
                g = c;
            }
            else if (2 <= h && h < 3)
            {
                g = c;
                b = x;
            }
            else if (3 <= h && h < 4)
            {
                g = x;
                b = c;
            }
            else if (4 <= h && h < 5)
            {
                r = x;
                b = c;
            }
            else
            {
                r = c;
                b = x;
            }

            return Color.FromArgb((int)Math.Round((r + m) * 255), (int)Math.Round((g + m) * 255), (int)Math.Round((b + m) * 255));
        }

        public void Invert()
        {
            Hue += 180;
            Hue %= 360;
            Brightness = 1 - Brightness;
        }

        public override string ToString()
        {
            return $"HslColor [H={Hue}, S={Saturation}, L={Brightness}]";
        }

        public static HslColor FromHsl(float hue, float saturation, float brightness)
        {
            return new HslColor()
            {
                Hue = hue,
                Saturation = saturation,
                Brightness = brightness
            };
        }

        public static HslColor FromColor(Color color)
        {
            return new HslColor()
            {
                Hue = color.GetHue(),
                Saturation = color.GetSaturation(),
                Brightness = color.GetBrightness()
            };
        }

        public static Color InvertColor(Color color)
        {
            HslColor hsl = HslColor.FromColor(color);
            hsl.Invert();
            return hsl.ToColor();
        }
    }
}
