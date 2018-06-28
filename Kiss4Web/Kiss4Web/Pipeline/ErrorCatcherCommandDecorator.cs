using System;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Infrastructure.Messaging;

namespace Kiss4Web.Pipeline
{
    public class ErrorCatcherCommandDecorator<TCommand> : RootCommandHandlerDecorator<TCommand>
        where TCommand : IMessage
    {
        private readonly TypedMessageHandler<TCommand> _decorated;
        private readonly IEventBus _eventBus;

        public ErrorCatcherCommandDecorator(TypedMessageHandler<TCommand> decorated,
                                            IEventBus eventBus,
                                            IRootProcessRegistrator rootProcessRegistrator)
            : base(decorated, rootProcessRegistrator)
        {
            _decorated = decorated;
            _eventBus = eventBus;
        }

        protected override Task HandleRootCommand(TCommand command)
        {
            try
            {
                return _decorated.Handle(command);
            }
            catch (Exception ex)
            {
                //_eventBus.Publish(new CommandExceptionEvent { Exception = ex, Command = command });
                throw;
            }
        }
    }
}