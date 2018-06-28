using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Model;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.DataAccess
{
    public class VerifyDbModelQueryDecorator<TQuery, TResult> : TypedMessageHandler<TQuery, TResult>
        where TQuery : IMessage<TResult>
    {
        private readonly IDbModelVerifier _dbModelVerifier;
        private readonly TypedMessageHandler<TQuery, TResult> _decorated;

        public VerifyDbModelQueryDecorator(TypedMessageHandler<TQuery, TResult> decorated, IDbModelVerifier dbModelVerifier)
        {
            _decorated = decorated;
            _dbModelVerifier = dbModelVerifier;
        }

        public override Task<TResult> Handle(TQuery query)
        {
            _dbModelVerifier.VerifyModelAgainstDatabase();
            return _decorated.Handle(query);
        }
    }
}