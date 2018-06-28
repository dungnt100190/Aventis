using System;

namespace Kiss4Web.Infrastructure.Mediator
{
    public class Message<TResponse> : Message, IMessage<TResponse>
    {
    }

    public class Message : IMessage
    {
        public Guid MessageId { get; } = Guid.NewGuid();
    }
}