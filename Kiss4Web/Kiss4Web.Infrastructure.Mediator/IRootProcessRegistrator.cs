using System;

namespace Kiss4Web.Infrastructure.Mediator
{
    public interface IRootProcessRegistrator
    {
        Guid? RootProcessId { get; }

        bool IsRootProcess(IMessage process);

        bool RegisterRoot(IMessage process);
    }
}