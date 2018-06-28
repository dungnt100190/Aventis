using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Pipeline
{
    public class RootCommandDecorator<TMessage> : TypedMessageHandler<TMessage>
       where TMessage : IMessage
    {
        private readonly TypedMessageHandler<TMessage> _decoratee;
        private readonly IRootProcessRegistrator _rootProcessRegistrator;

        public RootCommandDecorator(TypedMessageHandler<TMessage> decoratee, IRootProcessRegistrator rootProcessRegistrator)
        {
            _decoratee = decoratee;
            _rootProcessRegistrator = rootProcessRegistrator;
        }

        public override Task Handle(TMessage query)
        {
            _rootProcessRegistrator.RegisterRoot(query);
            return _decoratee.Handle(query);
        }
    }
}