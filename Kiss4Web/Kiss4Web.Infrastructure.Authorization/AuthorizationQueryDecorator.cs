using System;
using System.Reflection;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.Authorization
{
    public class AuthorizationQueryDecorator<TQuery, TResult> : TypedMessageHandler<TQuery, TResult>
        where TQuery : Message<TResult>
    {
        private readonly TypedMessageHandler<TQuery, TResult> _decorated;
        private readonly IAuthorizationChecker _authorizationChecker;
        private readonly IRootProcessRegistrator _rootProcessRegistrator;
        //private readonly RightTranslator _rightTranslator;

        public AuthorizationQueryDecorator(
            TypedMessageHandler<TQuery, TResult> decorated,
            IAuthorizationChecker authorizationChecker,
            IRootProcessRegistrator rootProcessRegistrator
            //RightTranslator rightTranslator,
            )
        {
            _decorated = decorated;
            _authorizationChecker = authorizationChecker;
            _rootProcessRegistrator = rootProcessRegistrator;
            //_rightTranslator = rightTranslator;
        }

        public override async Task<TResult> Handle(TQuery query)
        {
            if (_rootProcessRegistrator.IsRootProcess(query))
            {
                var rights = query.GetType().GetCustomAttributes<Kiss4RightAttribute>();
                if (!await _authorizationChecker.UserHasRights(rights))
                {
                    throw new UnauthorizedAccessException(string.Format(AuthorizationResources.Unauthorized, query.GetType().Name));
                }
            }

            return await _decorated.Handle(query);
        }
    }
}