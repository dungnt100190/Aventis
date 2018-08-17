using System.Collections.Generic;

using Kiss.BusinessLogic.Ba;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kiss.BusinessLogic.Test.Ba
{
    [TestClass]
    public class BaAdressatServiceTest
    {
        #region Test Methods

        [TestMethod]
        public void GetAdressatList_BaPersonId_ReturnList()
        {
            // Arrange
            const int baPersonId = 900000;

            var baPersonService = new Mock<BaPersonService>();
            baPersonService.Setup(moq => moq.GetAffectedPersons(baPersonId))
                            .Returns(new[] { new BaPerson
                                                 {
                                                     BaPersonID = 123456,
                                                     Name = "Minestrone",
                                                     Vorname = "Vitali"
                                                 },
                                              new BaPerson
                                                 {
                                                     BaPersonID = 456789,
                                                     Name = "Calzone",
                                                     Vorname = "Wladimir"
                                                 },
                                              new BaPerson
                                                 {
                                                     BaPersonID = 789123,
                                                     Name = "Börner",
                                                     Vorname = "Paul"
                                                 }});
            Container.RegisterInstance(baPersonService.Object);

            var baInstitutionService = new Mock<BaInstitutionService>();
            baInstitutionService.Setup(moq => moq.GetAffectedInstitutions(baPersonId))
                            .Returns(new[] { new BaInstitution
                                                 {
                                                     BaInstitutionID = 147258,
                                                     Name = "VitaBella",
                                                     Vorname = "Mafia"
                                                 },
                                            new BaInstitution
                                                 {
                                                     BaInstitutionID = 258369,
                                                     Name = "DaCarlo",
                                                     Vorname = "Ristorante"
                                                 },
                                            new BaInstitution
                                                 {
                                                     BaInstitutionID = 369147,
                                                     Name = "DaPolo",
                                                     Vorname = "Club"
                                                 }});

            Container.RegisterInstance(baInstitutionService.Object);

            var baAdresseService = new Mock<BaAdresseService>();
            baAdresseService.Setup(moq => moq.GetByListOfBapersonId(It.IsAny<List<int?>>()))
                .Returns(new List<BaAdresse>());
            baAdresseService.Setup(moq => moq.GetByListOfBaInstitutionIds(It.IsAny<List<int?>>()))
                .Returns(new List<BaAdresse>());

            Container.RegisterInstance(baAdresseService.Object);

            // Act
            var baAdressatService = new BaAdressatService();
            var value = baAdressatService.GetAdressatList(".", baPersonId);

            // Assert
            Assert.IsNotNull(value);
            Assert.AreEqual(value.Result.Count, 6);
        }

        #endregion
    }
}