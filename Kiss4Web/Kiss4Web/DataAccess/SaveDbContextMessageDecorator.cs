using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Pipeline;

namespace Kiss4Web.DataAccess
{
    public class SaveDbContextMessageDecorator<TCommand, TResult> : RootQueryHandlerDecorator<TCommand, TResult>
        where TCommand : IMessage<TResult>
    {
        private readonly IDbContext _dbContext;
        private readonly TypedMessageHandler<TCommand, TResult> _decorated;

        public SaveDbContextMessageDecorator(TypedMessageHandler<TCommand, TResult> decorated,
                                      IDbContext dbContext,
                                      IRootProcessRegistrator rootProcessRegistrator)
            : base(decorated, rootProcessRegistrator)
        {
            _decorated = decorated;
            _dbContext = dbContext;
        }

        protected override async Task<TResult> HandleRootQuery(TCommand command)
        {
            var result = await _decorated.Handle(command);
            await _dbContext.SaveChangesAsync();
            return result;
            // don't dispose UoW here, the container disposes it at the end of the web request
        }
    }
}