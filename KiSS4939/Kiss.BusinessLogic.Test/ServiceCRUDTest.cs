using Kiss.DbContext;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BusinessLogic.Test
{
    [TestClass]
    public class ServiceCRUDTest : DatabaseTestBase
    {
        [TestMethod]
        public void TestGet()
        {
            var service = new ServiceCRUD<BaPerson>();
            var person = service.GetEntityById(1);
        }
    }
}