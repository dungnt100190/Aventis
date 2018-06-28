using System;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Pipeline
{
    public class RootProcessRegistrator : IRootProcessRegistrator
    {
        public Guid? RootProcessId { get; private set; }

        public bool IsRootProcess(IMessage process)
        {
            return RootProcessId != null && RootProcessId.Value == process.MessageId;
        }

        public bool RegisterRoot(IMessage process)
        {
            if (RootProcessId.HasValue)
            {
                return RootProcessId == process.MessageId;
            }
            RootProcessId = process.MessageId;
            return true;
        }
    }
}