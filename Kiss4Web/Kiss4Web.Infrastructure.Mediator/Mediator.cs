using System.Threading.Tasks;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.Mediator
{
    public class Mediator : IMediator
    {
        private readonly Container _container;

        public Mediator(Container container)
        {
            _container = container;
        }

        public Task<TResponse> Process<TResponse>(IMessage<TResponse> message)
        {
            var messageHandler = GetMessageHandler(message);
            return messageHandler.Handle(message);
        }

        public Task Process(IMessage message)
        {
            var messageHandler = GetMessageHandler(message);
            return messageHandler.Handle(message);
        }

        private IMessageHandler<TResponse> GetMessageHandler<TResponse>(IMessage<TResponse> message)
        {
            var messageHandlerType = typeof(TypedMessageHandler<,>).MakeGenericType(message.GetType(), typeof(TResponse));
            return (IMessageHandler<TResponse>)_container.GetInstance(messageHandlerType);
        }

        private IMessageHandler GetMessageHandler(IMessage message)
        {
            var messageHandlerType = typeof(TypedMessageHandler<>).MakeGenericType(message.GetType());
            return (IMessageHandler)_container.GetInstance(messageHandlerType);
        }
    }
}