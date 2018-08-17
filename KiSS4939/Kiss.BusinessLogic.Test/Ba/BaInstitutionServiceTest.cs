using Kiss.BusinessLogic.Ba;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BusinessLogic.Test.Ba
{
    [TestClass]
    public class BaInstitutionServiceTest
    {
        [TestMethod]
        public void GetContactInfoMultiline_Ok()
        {
            var baInstitution = new BaInstitution
            {
                Telefon = "031 1234 56 78",
                Telefon2 = "",
                Telefon3 = "Telefon3",
                Fax = "-",
                EMail = "unit@test.org",
            };

            var institutionService = Container.Resolve<BaInstitutionService>();

            var result = institutionService.GetContactInfoMultiline(baInstitution);

            Assert.IsTrue(result.Contains("Tel."));
            Assert.IsFalse(result.Contains("Tel. 2"));
            Assert.IsTrue(result.Contains("Fax: -"));
            Assert.IsTrue(result.EndsWith("unit@test.org"));
        }
    }
}