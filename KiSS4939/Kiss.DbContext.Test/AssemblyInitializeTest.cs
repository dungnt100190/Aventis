using Kiss.DbContext.Test.Mock;
using Kiss.Edmx;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DbContext.Test
{
    [TestClass]
    public class AssemblyInitializeTest
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            new EdmxReference();
            var sessionService = new SessionServiceMock();
            sessionService.Open(null, new AuthenticatedUser());
            Container.RegisterInstance<ISessionService>(sessionService);
        }
    }
}