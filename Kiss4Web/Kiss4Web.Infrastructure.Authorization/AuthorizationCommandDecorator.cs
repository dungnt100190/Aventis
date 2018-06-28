using System;
using System.Reflection;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.Authorization
{
    public class AuthorizationCommandDecorator<TCommand> : TypedMessageHandler<TCommand>
        where TCommand : Message
    {
        private readonly TypedMessageHandler<TCommand> _decorated;
        private readonly IAuthorizationChecker _authorizationChecker;
        private readonly IRootProcessRegistrator _rootProcessRegistrator;
        //private readonly RightTranslator _rightTranslator;

        public AuthorizationCommandDecorator(
            TypedMessageHandler<TCommand> decorated,
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

        public override async Task Handle(TCommand command)
        {
            if (_rootProcessRegistrator.IsRootProcess(command))
            {
                var rights = command.GetType().GetCustomAttributes<Kiss4RightAttribute>();
                if (!await _authorizationChecker.UserHasRights(rights))
                {
                    throw new UnauthorizedAccessException(string.Format(AuthorizationResources.Unauthorized, command.GetType().Name));
                }
            }

            await _decorated.Handle(command);
        }
    }
}