using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.Mediator
{
    public interface IMessageHandler
    {
        Task Handle(IMessage message);
    }

    public interface IMessageHandler<TResponse>
    {
        Task<TResponse> Handle(IMessage<TResponse> message);
    }
}