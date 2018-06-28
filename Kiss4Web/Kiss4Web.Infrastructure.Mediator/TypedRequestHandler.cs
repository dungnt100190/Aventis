using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.Mediator
{
    public abstract class TypedMessageHandler<TMessage, TResponse> : IMessageHandler<TResponse>
    {
        public abstract Task<TResponse> Handle(TMessage message);

        public Task<TResponse> Handle(IMessage<TResponse> message)
        {
            return Handle((TMessage)message);
        }
    }

    public abstract class TypedMessageHandler<TMessage> : IMessageHandler
    {
        public Task Handle(IMessage message)
        {
            return Handle((TMessage)message);
        }

        public abstract Task Handle(TMessage message);
    }
}