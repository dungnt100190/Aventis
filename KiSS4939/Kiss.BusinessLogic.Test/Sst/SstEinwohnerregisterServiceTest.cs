using System;

using Kiss.BusinessLogic.Ba;
using Kiss.DbContext.DTO.Ba;
using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BusinessLogic.Test.Sst
{
    [TestClass]
    public class SstEinwohnerregisterServiceTest
    {
        /// <remarks>
        /// Web server has to be running!
        /// </remarks>
        [TestMethod]
        public void PersonSuchen()
        {
            // only manual execution
            return;

            var service = Container.Resolve<BaEinwohnerregisterService>();

            var result = service.PersonSuchen(new BaEinwohnerregisterPersonSucheDTO());

            Assert.IsTrue(result.IsOk, result.ToString());
            Console.WriteLine(result.Result);
        }
    }
}