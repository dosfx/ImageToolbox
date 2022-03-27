using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ImageToolbox
{
    class PsdFile
    {
        public PsdFile(Stream stream)
        {
            using (PsdBinaryReader reader = new PsdBinaryReader(stream))
            {
                ParseHeader(reader);
                ParseColorModeData(reader);
                ParseImageResourceData(reader);
                ParseLayerAndMaskData(reader);
                ParseImageData(reader);
            }
        }

        public string Signature { get; private set; }
        public int Version { get; private set; }
        public int Channels { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int Depth { get; private set; }
        public PsdColorMode ColorMode { get; private set; }
        public byte[] ColorModeData { get; private set; }
        public PsdImageResource[] ImageResources { get; private set; }
        public PsdLayer[] Layers { get; private set; }
        public byte[] GlobalMaskData { get; private set; }
        public PsdLayerInfo[] AdditionalInfo { get; private set; }
        public Bitmap Bitmap { get; private set; }

        public bool IsPsb => Version == 2;

        private void ParseHeader(PsdBinaryReader reader)
        {
            Signature = reader.ReadString(4);
            Check.Equals(nameof(Signature), Signature, "8BPS");
            Version = reader.ReadInt16();
            Check.Equals(nameof(Version), Version, 1, 1);
            // skip 6 bytes
            Check.NullPadding(reader, 6);
            Channels = reader.ReadInt16();
            Height = reader.ReadInt32();
            Width = reader.ReadInt32();
            Depth = reader.ReadInt16();
            ColorMode = (PsdColorMode)reader.ReadUInt16();
        }

        private void ParseColorModeData(PsdBinaryReader reader)
        {
            ColorModeData = reader.ReadBytes(reader.ReadInt32());
        }

        private void ParseImageResourceData(PsdBinaryReader reader)
        {
            List<PsdImageResource> resources = new List<PsdImageResource>();
            int length = reader.ReadInt32();
            while (length > 0)
            {
                PsdImageResource resource = new PsdImageResource(reader);
                resources.Add(resource);
                length -= resource.DataLength;
            }
            Check.Equals(nameof(length), length, 0);
            ImageResources = resources.ToArray();
        }

        private void ParseLayerAndMaskData(PsdBinaryReader reader)
        {
            long totalLength = IsPsb ? reader.ReadInt64() : reader.ReadInt32();
            long layerLength = IsPsb ? reader.ReadInt64() : reader.ReadInt32();
            totalLength -= 4;
            totalLength -= layerLength;
            short layerCount = reader.ReadInt16();
            layerLength -= 2;
            Layers = new PsdLayer[Math.Abs(layerCount)];
            for (int i = 0; i < Layers.Length; i++)
            {
                Layers[i] = new PsdLayer(reader);
                layerLength -= Layers[i].DataLength;
            }
            foreach (PsdLayer layer in Layers)
            {
                layer.ParseChannels(reader);
                int channelLength = layer.Channels.Sum(c => c.Length);
                layerLength -= channelLength;
            }

            if (layerLength < 4)
            {
                Check.NullPadding(reader, (int)layerLength);
                layerLength -= layerLength;
            }
            Check.Equals(nameof(layerLength), layerLength, 0L);

            if (totalLength > 0)
            {
                int globalLength = reader.ReadInt32();
                totalLength -= globalLength + 4;
                GlobalMaskData = reader.ReadBytes(globalLength);
                globalLength -= globalLength;
                Check.Equals(nameof(globalLength), globalLength, 0);
                List<PsdLayerInfo> addiInfo = new List<PsdLayerInfo>();
                while (totalLength > 0)
                {
                    PsdLayerInfo layerInfo = PsdLayerInfo.ParseLayerInfo(reader);
                    addiInfo.Add(layerInfo);
                    totalLength -= layerInfo.DataLength;
                }
                AdditionalInfo = addiInfo.ToArray();
            }
            Check.Equals(nameof(totalLength), totalLength, 0L);
        }

        private void ParseImageData(PsdBinaryReader reader)
        {
            PsdCompression compression = (PsdCompression)reader.ReadInt16();
            // assumptions for parsing the image
            Check.Equals(nameof(compression), compression, PsdCompression.Rle);
            Check.Equals(nameof(Depth), Depth, 8);
            Check.Equals(nameof(ColorMode), ColorMode, PsdColorMode.Rgb);
            Check.Equals(nameof(Channels), Channels, 3, 4);
            Bitmap = new Bitmap(Width, Height);
            byte[] imageData = reader.ReadRleBlock(Height * Channels);
            Check.Equals($"{nameof(imageData)}.Length", imageData.Length, Channels * Height * Width);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Bitmap.SetPixel(x, y, Color.FromArgb(
                        Channels == 3 ? 255 : imageData[(Height * Width * 3) + (Width * y) + x],
                        imageData[(Height * Width * 0) + (Width * y) + x],
                        imageData[(Height * Width * 1) + (Width * y) + x],
                        imageData[(Height * Width * 2) + (Width * y) + x]
                    ));
                }
            }
        }
    }
}
