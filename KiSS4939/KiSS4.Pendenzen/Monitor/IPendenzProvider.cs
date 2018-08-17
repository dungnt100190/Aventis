using System;
using System.Collections;

namespace KiSS4.Pendenzen.Monitor
{
    public interface IPendenzProvider : IEnumerable
    {
        void LookUp();
        Int32 Count { get; }
    }
}
