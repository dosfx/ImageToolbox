using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToolbox
{
    public struct HsvColor
    {
        public float Hue { get; private set; }
        public float Saturation { get; private set; }
        public float Value { get; private set; }

        public HslColor ToHslColor()
        {
            // new sat is dependant on luminance to calc it outside
            float l = Value * (1 - (Saturation / 2));
            return HslColor.FromHsl(Hue, (l == 0 || l == 1) ? 0 : ((Value - l) / Math.Min(l, 1 - l)), l);
        }

        public Color ToColor()
        {
            // going through hsl since there's built in convertion
            return ToHslColor().ToColor();
        }

        public static HsvColor FromHsv(float hue, float saturation, float value)
        {
            return new HsvColor() { Hue = hue, Saturation = saturation, Value = value };
        }

        public static HsvColor FromColor(HslColor hsl)
        {
            // alias luminance since we use it a lot
            float l = hsl.Brightness;

            // new sat is dependant on value so calc it outside
            float v = l + (hsl.Saturation * Math.Min(l, 1 - l));

            // build our new color
            return FromHsv(hsl.Hue, v == 0 ? 0 : (2 * (1 - (l / v))), v);
        }

        public static HsvColor FromColor(Color color)
        {
            // going through hsl since there's built in convertion
            return FromColor(HslColor.FromColor(color));
        }
    }
}
