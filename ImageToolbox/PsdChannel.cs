namespace ImageToolbox
{
    class PsdChannel
    {
        public PsdChannel(PsdBinaryReader reader)
        {
            Id = (PsdChannelId)reader.ReadInt16();
            Length = reader.ReadInt32();
            Compression = PsdCompression.RawData;
        }
        public PsdChannelId Id { get; private set; }
        public PsdCompression Compression { get; private set; }
        public int Length { get; private set; }
        public byte[] LayerData { get; private set; }

        public int DataLength => 6; // 6 bytes read in ctor

        public void ParseChannelData(PsdBinaryReader reader, int height)
        {
            // count the data as we go, starts with reading compression
            long streamPos = reader.BaseStream.Position;
            Compression = (PsdCompression)reader.ReadInt16();
            Check.Equals(nameof(Compression), Compression, PsdCompression.RawData, PsdCompression.Rle);
            switch (Compression)
            {
                case PsdCompression.RawData:
                    LayerData = reader.ReadBytes(Length - 2);
                    break;
                case PsdCompression.Rle:
                    LayerData = reader.ReadRleBlock(height);
                    break;
            }
            // make sure the correct amount was read
            Check.Equals("Read Data", reader.BaseStream.Position - streamPos, (long)Length);
        }
    }
}
