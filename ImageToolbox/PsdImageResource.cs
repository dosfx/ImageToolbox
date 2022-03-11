namespace ImageToolbox
{
    struct PsdImageResource
    {
        public PsdImageResource(PsdBinaryReader reader)
        {
            Signature = reader.ReadString(4);
            Check.Equals(nameof(Signature), Signature, "8BIM");
            Id = reader.ReadInt16();
            // pads to even length with another null if the data is odd long
            Name = reader.ReadPascalString();
            // if string is even long then data is odd long due to length byte
            if (Name.Length % 2 == 0)
            {
                // read the extra byte
                Check.NullPadding(reader, 1);
            }

            Data = reader.ReadBytes(reader.ReadInt32());
        }

        public string Signature { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public byte[] Data { get; private set; }

        public int DataLength => Signature.Length
            + 2 // Id 2 bytes
            + Name.Length + (Name.Length % 2 == 0 ? 2 : 1) // name is padded with 1 or 2 nulls to make the data even long
            + 4 // 4 data length bytes
            + Data.Length;
    }
}
