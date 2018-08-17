using System.Threading;

using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

namespace Kiss.Infrastructure.Utils
{
    public static class Multilanguage
    {
        public static void SetCurrentCulture()
        {
            var sessionService = Container.Resolve<ISessionService>();
            Thread.CurrentThread.CurrentCulture = sessionService.AuthenticatedUser.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = sessionService.AuthenticatedUser.CurrentCulture;
        }
    }
}