using System;
using System.IO;

namespace ImageToolbox
{
    class ProgressStream : Stream
    {
        private readonly Stream stream;
        private readonly double length;
        private long position;
        private int lastPercentage;

        public ProgressStream(Stream stream)
        {
            this.stream = stream;
            length = stream.Length;
            position = 0;
            lastPercentage = -1;
        }

        public event EventHandler<ProgressEventArgs> ProgressChanged;

        public override bool CanRead => stream.CanRead;

        public override bool CanSeek => stream.CanSeek;

        public override bool CanWrite => stream.CanWrite;

        public override long Length => (long)length;

        public override long Position
        { 
            get => position;
            set
            {
                stream.Position = value;
                position = value;
            }
        }

        public override void Flush()
        {
            stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int read = stream.Read(buffer, offset, count);
            position += read;
            int percent = (int)((position / length) * 100);
            if (percent != lastPercentage)
            {
                ProgressChanged?.Invoke(this, new ProgressEventArgs(percent));
                lastPercentage = percent;
            }
            return read;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer, offset, count);
        }
    }
}
