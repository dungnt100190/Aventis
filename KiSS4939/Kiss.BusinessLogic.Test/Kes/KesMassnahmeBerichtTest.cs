using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.BusinessLogic.Kes;
using Kiss.DataAccess.Kes;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Kiss.BusinessLogic.Test.Kes
{
    [TestClass]
    public class KesMassnahmeBerichtTest
    {
        [TestMethod]
        public void GetByKesMassnahmeId_Ok()
        {
            // Arrange
            var kesMassnahme = new KesMassnahme
            {
                KesMassnahmeID = 1,
            };

            var mandatsfuehrendePersonRepository = new Mock<KesMassnahmeBerichtRepository>();
            mandatsfuehrendePersonRepository.Setup(moq => moq.GetByKesMassnahmeId(It.IsAny<int>(), false)).Returns(
                new List<KesMassnahmeBericht>
                {
                    new KesMassnahmeBericht
                    {
                        KesMassnahme = kesMassnahme,
                        DatumVon = new DateTime(2014, 1, 1),
                        DatumBis = new DateTime(2014, 2, 1),
                    },
                    new KesMassnahmeBericht
                    {
                        KesMassnahme = kesMassnahme,
                    }
                });

            var uowMock = new UnitOfWorkMock();
            uowMock.RegisterRepository(uow => uow.KesMassnahmeBericht, mandatsfuehrendePersonRepository.Object);

            // Act
            var service = Container.Resolve<KesMassnahmeBerichtService>();
            var result = service.GetByKesMassnahmeId(1, false);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(new DateTime(2014, 1, 1), result[0].DatumVon);
            Assert.AreEqual(new DateTime(2014, 2, 1), result[0].DatumBis);
        }
    }
}