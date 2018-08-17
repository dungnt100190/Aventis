using System;

using Kiss.BusinessLogic.Kes;
using Kiss.DataAccess.Kes;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Kiss.BusinessLogic.Test.Kes
{
    [TestClass]
    public class KesPraeventionServiceTest
    {
        [TestMethod]
        public void GetByFaLeistungId_Ok()
        {
            // Arrange
            var praeventionRepository = new Mock<KesPraeventionRepository>();
            praeventionRepository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>())).Returns(
                new[]
                {
                    new KesPraevention
                    {
                        KesPraeventionID = 1,
                        FaLeistungID = 1,
                        Bemerkung = "1",
                        DatumVon = new DateTime(2012, 1, 1),
                        DatumBis = new DateTime(2012, 1, 31),
                        UserID = 1
                    },
                    new KesPraevention
                    {
                        KesPraeventionID = 1,
                        FaLeistungID = 1,
                        Bemerkung = "2",
                        DatumVon = new DateTime(2013, 1, 1),
                        DatumBis = new DateTime(2013, 1, 31),
                        UserID = 1
                    }
                });

            var uowMock = new UnitOfWorkMock();
            uowMock.RegisterRepository(uow => uow.KesPraevention, praeventionRepository.Object);

            // Act
            var service = Container.Resolve<KesPraeventionService>();
            var result = service.GetByFaLeistungId(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("1", result[0].Bemerkung);
            Assert.AreEqual("2", result[1].Bemerkung);
        }
    }
}