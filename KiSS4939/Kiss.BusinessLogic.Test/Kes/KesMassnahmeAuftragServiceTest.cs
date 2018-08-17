using System;
using System.Collections.Generic;

using Kiss.BusinessLogic.Kes;
using Kiss.DataAccess.Kes;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Kiss.BusinessLogic.Test.Kes
{
    [TestClass]
    public class KesMassnahmeAuftragServiceTest
    {
        [TestMethod]
        public void GetByKesMassnahmeID_Ok()
        {
            // Arrange
            var kesMassnahme = new KesMassnahme
            {
                KesMassnahmeID = 1,
            };

            var mandatsfuehrendePersonRepository = new Mock<KesMassnahmeAuftragRepository>();
            mandatsfuehrendePersonRepository.Setup(moq => moq.GetByKesMassnahmeID(It.IsAny<int>(), false)).Returns(
                new List<KesMassnahmeAuftrag>
                {
                    new KesMassnahmeAuftrag
                    {
                        KesMassnahme = kesMassnahme,
                        BeschlussVom = new DateTime(2014, 1, 1),
                        ErledigungBis = new DateTime(2014, 2, 1),
                    },
                    new KesMassnahmeAuftrag
                    {
                        KesMassnahme = kesMassnahme,
                    }
                });

            var uowMock = new UnitOfWorkMock();
            uowMock.RegisterRepository(uow => uow.KesMassnahmeAuftrag, mandatsfuehrendePersonRepository.Object);

            // Act
            var service = Container.Resolve<KesMassnahmeAuftragService>();
            var result = service.GetByKesMassnahmeID(1, false);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(new DateTime(2014, 1, 1), result[0].BeschlussVom);
            Assert.AreEqual(new DateTime(2014, 2, 1), result[0].ErledigungBis);
        }
    }
}