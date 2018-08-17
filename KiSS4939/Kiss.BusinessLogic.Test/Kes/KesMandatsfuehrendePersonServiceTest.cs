using System;
using System.Collections.Generic;
using Kiss.BusinessLogic.Kes;
using Kiss.DataAccess.Kes;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;
using Kiss.Infrastructure.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kiss.BusinessLogic.Test.Kes
{
    [TestClass]
    public class KesMandatsfuehrendePersonServiceTest
    {
        [TestMethod]
        public void GetByKesMassnahmeID_Int_Ok()
        {
            // Arrange
            var kesMassnahme = new KesMassnahme
            {
                KesMassnahmeID = 1,
                KesMassnahme_KesArtikel = null,
            };

            var mandatsfuehrendePersonRepository = new Mock<KesMandatsfuehrendePersonRepository>();
            mandatsfuehrendePersonRepository.Setup(moq => moq.GetByKesMassnahmeID(It.IsAny<int>(), false)).Returns(
                new List<KesMandatsfuehrendePersonDTO>
                {
                    new KesMandatsfuehrendePersonDTO(
                        new KesMandatsfuehrendePerson
                        {
                            KesMassnahmeID = kesMassnahme.KesMassnahmeID,
                            KesMassnahme = kesMassnahme,
                            DatumMandatBis = new DateTime(2014, 2, 7),
                            DatumMandatVon = new DateTime(2014, 2, 10)
                        })
                });

            var uowMock = new UnitOfWorkMock();
            uowMock.RegisterRepository(uow => uow.KesMandatsfuehrendePerson, mandatsfuehrendePersonRepository.Object);

            // Act
            var service = Container.Resolve<KesMandatsfuehrendePersonService>();
            var result = service.GetByKesMassnahmeID(1, false);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(new DateTime(2014, 2, 7), result[0].WrappedEntity.DatumMandatBis);
            Assert.AreEqual(new DateTime(2014, 2, 10), result[0].WrappedEntity.DatumMandatVon);
        }
    }
}