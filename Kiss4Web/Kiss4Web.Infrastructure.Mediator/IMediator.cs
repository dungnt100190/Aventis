using System.Threading.Tasks;

namespace Kiss4Web.Infrastructure.Mediator
{
    public interface IMediator
    {
        Task<TResponse> Process<TResponse>(IMessage<TResponse> message);

        Task Process(IMessage message);
    }
}