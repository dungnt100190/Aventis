using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Pipeline
{
    public class RootQueryDecorator<TMessage, TResponse> : TypedMessageHandler<TMessage, TResponse>
       where TMessage : IMessage
    {
        private readonly TypedMessageHandler<TMessage, TResponse> _decoratee;
        private readonly IRootProcessRegistrator _rootProcessRegistrator;

        public RootQueryDecorator(TypedMessageHandler<TMessage, TResponse> decoratee, IRootProcessRegistrator rootProcessRegistrator)
        {
            _decoratee = decoratee;
            _rootProcessRegistrator = rootProcessRegistrator;
        }

        public override Task<TResponse> Handle(TMessage query)
        {
            _rootProcessRegistrator.RegisterRoot(query);
            return _decoratee.Handle(query);
        }
    }
}