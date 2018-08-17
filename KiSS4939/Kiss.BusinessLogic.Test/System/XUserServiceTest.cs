using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BusinessLogic.Test.System
{
    [TestClass]
    public class XUserServiceTest
    {
        [TestMethod]
        public void GetContactInfoMultiline_Ok()
        {
            var user = new XUser
            {
                Phone = "01356+89",
                PhoneIntern = "6858",
                PhoneMobile = "88+9",
                PhonePrivat = "",
                EMail = "hansi.hinterseer@schlager.ch"
            };

            var userService = Container.Resolve<XUserService>();
            var result = userService.GetContactInfoMultiline(user);

            Assert.IsTrue(result.Contains("P: -"));
            Assert.IsTrue(result.Contains("M: 88+9"));
            Assert.IsTrue(result.Contains("G: 01356+89"));
            Assert.IsTrue(result.Contains("@schlager"));
        }
    }
}