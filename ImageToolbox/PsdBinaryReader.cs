using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToolbox
{
    class PsdBinaryReader : BinaryReader
    {
        public PsdBinaryReader(Stream stream) : base(stream) { }

        public string ReadString(int count) => new string(ReadChars(count));

        public string ReadNullString()
        {
            // read chars until we get a null char
            List<char> chars = new List<char>();
            for (char c = ReadChar(); c != 0; c = ReadChar())
            {
                chars.Add(c);
            }

            return new string(chars.ToArray());
        }

        public string ReadPascalString()
        {
            byte count = ReadByte();
            return ReadString(count);
        }

        public new short ReadInt16() => BitConverter.ToInt16(ReadEndianAware(2), 0);

        public new int ReadInt32() => BitConverter.ToInt32(ReadEndianAware(4), 0);

        public new long ReadInt64() => BitConverter.ToInt64(ReadEndianAware(8), 0);

        public new ushort ReadUInt16() => (ushort)ReadInt16();

        public new uint ReadUInt32() => (uint)ReadInt32();

        public new long ReadUInt64() => (long)ReadInt64();

        public Rectangle ReadRectangle()
        {
            int top = ReadInt32();
            int left = ReadInt32();
            int bottom = ReadInt32();
            int right = ReadInt32();
            return Rectangle.FromLTRB(left, top, right, bottom);
        }

        public byte[] ReadRleBlock(int lines)
        {
            List<byte> bytes = new List<byte>();
            int[] lineLengths = new int[lines];
            for (int i = 0; i < lines; i++)
            {
                lineLengths[i] = ReadInt16();
            }

            for (int i = 0; i < lines; i++)
            {
                bytes.AddRange(ReadRle(lineLengths[i]));
            }

            return bytes.ToArray();
        }

        public byte[] ReadRle(int count)
        {
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < count; i++)
            {
                sbyte header = (sbyte)ReadByte();
                if (header == -128)
                {
                    // nop
                    continue;
                }
                else if (header < 0)
                {
                    // repeat next byte (1 - header) times
                    byte repeat = ReadByte();
                    i++; // extra increment for the read
                    bytes.AddRange(Enumerable.Repeat(repeat, 1 - header));
                }
                else
                {
                    // read the next (header + 1) bytes direct to output
                    bytes.AddRange(ReadBytes(header + 1));
                    i += header + 1;
                }
            }
            return bytes.ToArray();
        }

        private byte[] ReadEndianAware(int count)
        {
            byte[] data = ReadBytes(count);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(data);
            }

            return data;
        }
    }
}
