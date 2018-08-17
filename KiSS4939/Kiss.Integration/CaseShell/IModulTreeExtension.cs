using System;

namespace Kiss.Integration.CaseShell
{
    public interface IModulTreeExtension : IDisposable
    {
        void Initialize(int baPersonId, int faFallId);
    }
}