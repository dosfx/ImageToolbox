using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToolbox
{
    public enum PsdColorMode : short
    {
        Bitmap = 0,
        Grayscale = 1,
        Indexed = 2,
        Rgb = 3,
        Cmyk = 4,
        Multichannel = 7,
        Duotone = 8,
        Lab = 9
    }
}