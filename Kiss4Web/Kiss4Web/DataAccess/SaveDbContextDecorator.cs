using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Pipeline;

namespace Kiss4Web.DataAccess
{
    public class SaveDbContextDecorator<TCommand> : RootCommandHandlerDecorator<TCommand>
        where TCommand : IMessage
    {
        private readonly TypedMessageHandler<TCommand> _decorated;
        private readonly IDbContext _dbContext;

        public SaveDbContextDecorator(TypedMessageHandler<TCommand> decorated,
                                      IDbContext dbContext,
                                      IRootProcessRegistrator rootProcessRegistrator)
            : base(decorated, rootProcessRegistrator)
        {
            _decorated = decorated;
            _dbContext = dbContext;
        }

        protected override async Task HandleRootCommand(TCommand command)
        {
            await _decorated.Handle(command);
            await _dbContext.SaveChangesAsync();
            // don't dispose UoW here, the container disposes it at the end of the web request
        }
    }
}