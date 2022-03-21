using System;

namespace ImageToolbox
{
    class ProgressEventArgs : EventArgs
    {
        public ProgressEventArgs(int percentage)
        {
            Percentage = percentage;
        }

        public int Percentage { get; private set; }
    }
}
