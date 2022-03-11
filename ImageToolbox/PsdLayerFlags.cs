using System;

namespace ImageToolbox
{
    [Flags]
    enum PsdLayerFlags : byte
    {
        TransparencyProtected = 0x01,
        Visible = 0x02,
        Obsolete = 0x04,
        Ps5OrLater = 0x08,
        PixelDataIrrelevant = 0x10
    }
}
