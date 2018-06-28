using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Pipeline
{
    public abstract class RootCommandHandlerDecorator<TMessage> : TypedMessageHandler<TMessage>
        where TMessage : IMessage
    {
        private readonly TypedMessageHandler<TMessage> _decorated;
        private readonly IRootProcessRegistrator _rootProcessRegistrator;

        protected RootCommandHandlerDecorator(TypedMessageHandler<TMessage> decorated, IRootProcessRegistrator rootProcessRegistrator)
        {
            _decorated = decorated;
            _rootProcessRegistrator = rootProcessRegistrator;
        }

        public override Task Handle(TMessage command)
        {
            if (_rootProcessRegistrator.RegisterRoot(command))
            {
                return HandleRootCommand(command);
            }
            if (command is IChildMessage childmessage && childmessage.ParentRequestId == null)
            {
                childmessage.ParentRequestId = _rootProcessRegistrator.RootProcessId;
            }

            // be transparent if it's not the root command
            return _decorated.Handle(command);
        }

        protected abstract Task HandleRootCommand(TMessage command);
    }
}