namespace ImageToolbox
{
    class PsdLayerInfo
    {
        public static PsdLayerInfo ParseLayerInfo(PsdBinaryReader reader)
        {
            string signature = reader.ReadString(4);
            Check.Equals(nameof(Signature), signature, "8BIM");
            string key = reader.ReadString(4);
            PsdLayerInfo layerInfo;
            switch (key)
            {
                case "lsct":
                    layerInfo = new SectionDivider();
                    break;
                default:
                    layerInfo = new PsdLayerInfo();
                    break;
            }

            layerInfo.Signature = signature;
            layerInfo.Key = key;
            layerInfo.Length = reader.ReadInt32();
            layerInfo.ParseData(reader);
            return layerInfo;
        }

        public string Signature { get; private set; }
        public string Key { get; private set; }
        public int Length { get; private set; }

        public int DataLength => 12 + Length; // 4 byte signature + 4 byte key + 4 byte int length + actual data

        protected virtual void ParseData(PsdBinaryReader reader)
        {
            // just skip ahead
            reader.ReadBytes(Length);
        }

        public class SectionDivider : PsdLayerInfo
        {
            public enum Type : int
            {
                AnyLayer = 0,
                OpenFolder = 1,
                ClosedFolder = 2,
                BoundingSection = 3
            }

            public Type DividerType { get; private set; }
            public string DataSignature { get; private set; }
            public string BlendMode { get; private set; }

            protected override void ParseData(PsdBinaryReader reader)
            {
                DividerType = (Type)reader.ReadInt32();
                int dataCount = 4;
                if (Length >= 12)
                {
                    DataSignature = reader.ReadString(4);
                    BlendMode = reader.ReadString(4);
                    dataCount += 8;
                }
                Check.Equals(nameof(dataCount), dataCount, Length);
            }
        }
    }
}
