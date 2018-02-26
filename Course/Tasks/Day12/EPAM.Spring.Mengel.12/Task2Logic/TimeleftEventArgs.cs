using System;

namespace Task2Logic
{
    public class TimeleftEventArgs : EventArgs
    {
        public int Seconds { get; private set; }

        public TimeleftEventArgs(int seconds)
        {
            Seconds = seconds;
        }
    }
}