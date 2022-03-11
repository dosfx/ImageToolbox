using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToolbox
{
    enum PsdChannelId : short
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        TransparencyMask = -1,
        UserSuppliedMask = -2,
        RealUserMask = -3
    }
}
