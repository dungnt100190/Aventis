using Kiss.Infrastructure;
using Kiss.Interfaces.BL;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BusinessLogic.Test
{
    [TestClass]
    public class ServiceResultTest
    {
        [TestMethod]
        public void TypeError_GetTechnicalDetails_FormatsString()
        {
            var serviceResult = new ServiceResult(ServiceResultType.Error, "format {0}", null, null, "string");
            var details = serviceResult.GetTechnicalDetails();
            Assert.IsTrue(details.Contains("format string"), "Actual: {0}", details);
        }
    }
}