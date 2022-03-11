using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ImageToolbox
{
    class PsdLayer
    {
        private Bitmap bitmap;

        public PsdLayer(PsdBinaryReader reader)
        {
            Bounds = reader.ReadRectangle();
            Channels = new PsdChannel[reader.ReadInt16()];
            for (int i = 0; i < Channels.Length; i++)
            {
                Channels[i] = new PsdChannel(reader);
            }

            Signature = reader.ReadString(4);
            Check.Equals(nameof(Signature), Signature, "8BIM");
            BlendModeKey = reader.ReadString(4);
            Opacity = reader.ReadByte();
            Clipping = reader.ReadByte() > 0;
            Flags = (PsdLayerFlags)reader.ReadByte();
            Check.NullPadding(reader, 1);
            int extraLength = reader.ReadInt32();
            DataLength = 16 + // bounds
                2 + // read num channels
                Channels.Sum(c => c.DataLength) + 
                Signature.Length + 
                BlendModeKey.Length + 
                4 + // 4 single byte reads
                4 + // extraLength
                extraLength;
            int maskLength = reader.ReadInt32();
            extraLength -= maskLength + 4;
            if (maskLength > 0)
            {
                MaskBounds = reader.ReadRectangle();
                maskLength -= 16;
                DefaultColor = reader.ReadByte();
                maskLength -= 1;
            }
            else
            {
                MaskBounds = Rectangle.Empty;
                DefaultColor = 0;
            }
            Check.Equals(nameof(maskLength), maskLength, 0);
            int blendLength = reader.ReadInt32();
            extraLength -= blendLength + 4;
            Check.Equals(nameof(blendLength), blendLength, 0);
            Name = reader.ReadPascalString();
            int namePad = (4 - (Name.Length + 1) % 4) % 4;
            Check.NullPadding(reader, namePad);
            extraLength -= Name.Length + 1 + namePad;
            ExtraData = reader.ReadBytes(extraLength);
            extraLength -= extraLength;
            Check.Equals(nameof(extraLength), extraLength, 0);
        }

        public Rectangle Bounds { get; private set; }
        public PsdChannel[] Channels { get; private set; }
        public string Signature { get; private set; }
        public string BlendModeKey { get; private set; }
        public byte Opacity { get; private set; }
        public bool Clipping { get; private set; }
        public PsdLayerFlags Flags { get; private set; }
        public Rectangle MaskBounds { get; private set; }
        public byte DefaultColor { get; private set; }
        public string Name { get; private set; }
        public byte[] ExtraData { get; private set; }

        public int DataLength { get; private set; }

        public Bitmap GetBitmap()
        {
            if (bitmap == null)
            {
                PsdChannel alpha = Channels.First(c => c.Id == PsdChannelId.TransparencyMask);
                PsdChannel red = Channels.First(c => c.Id == PsdChannelId.Red);
                PsdChannel green = Channels.First(c => c.Id == PsdChannelId.Green);
                PsdChannel blue = Channels.First(c => c.Id == PsdChannelId.Blue);
                bitmap = new Bitmap(Bounds.Width, Bounds.Height);
                for (int x = 0; x < Bounds.Width; x++)
                {
                    for (int y = 0; y < Bounds.Height; y++)
                    {
                        bitmap.SetPixel(x, y, Color.FromArgb(
                            alpha.LayerData[(y * Bounds.Width) + x],
                            red.LayerData[(y * Bounds.Width) + x],
                            green.LayerData[(y * Bounds.Width) + x],
                            blue.LayerData[(y * Bounds.Width) + x]
                        ));
                    }
                }
            }

            return bitmap;
        }

        public void ParseChannels(PsdBinaryReader reader)
        {
            foreach (PsdChannel channel in Channels)
            {
                channel.ParseChannelData(reader, Bounds.Height);
            }
        }
    }
}
