using System;

namespace KiSS4.Pendenzen.Monitor
{
    interface IMonitor
    {
        event EventHandler<EventArgs> Detected;

        void Start();
        void Stop();
        void Execute();
        void LookUp();
    }
}
