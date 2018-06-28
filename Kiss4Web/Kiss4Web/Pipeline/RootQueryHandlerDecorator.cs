using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Pipeline
{
    public abstract class RootQueryHandlerDecorator<TMessage, TResult> : TypedMessageHandler<TMessage, TResult>
        where TMessage : IMessage<TResult>
    {
        private readonly TypedMessageHandler<TMessage, TResult> _decorated;
        private readonly IRootProcessRegistrator _rootProcessRegistrator;

        protected RootQueryHandlerDecorator(TypedMessageHandler<TMessage, TResult> decorated, IRootProcessRegistrator rootProcessRegistrator)
        {
            _decorated = decorated;
            _rootProcessRegistrator = rootProcessRegistrator;
        }

        public override Task<TResult> Handle(TMessage query)
        {
            if (_rootProcessRegistrator.RegisterRoot(query))
            {
                return HandleRootQuery(query);
            }
            if (query is IChildMessage childmessage && childmessage.ParentRequestId == null)
            {
                childmessage.ParentRequestId = _rootProcessRegistrator.RootProcessId;
            }

            // be transparent if it's not the root query
            return _decorated.Handle(query);
        }

        protected abstract Task<TResult> HandleRootQuery(TMessage query);
    }
}