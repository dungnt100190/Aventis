using System;

namespace Kiss4Web.Infrastructure.Mediator
{
    public interface IChildMessage : IMessage
    {
        Guid? ParentRequestId { get; set; }
    }
}