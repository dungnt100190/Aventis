using System;

namespace KiSS4.Pendenzen.Monitor
{
    public interface IPendenz
    {
        Int32 Id { get; set; }
        Int32 Type { get; set; }
        Int32 State { get; set; }
        DateTime CreationDate { get; set; }
        DateTime StartDate { get; set; }
        DateTime ExpirationDate { get; set; }
        String Subject { get; set; }
        String Description { get; set; }
    }
}
