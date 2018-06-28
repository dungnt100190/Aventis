using System;

namespace Kiss4Web.Infrastructure.Mediator
{
    public interface IMessage
    {
        Guid MessageId { get; }
    }

    public interface IMessage<TResponse> : IMessage, IRight
    {
    }
}