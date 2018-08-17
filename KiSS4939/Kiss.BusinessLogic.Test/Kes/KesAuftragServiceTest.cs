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
    public class KesAuftragServiceTest
    {
        [TestMethod]
        public void GetByFaLeistungId_Ok()
        {
            // Arrange
            var auftragRepository = new Mock<KesAuftragRepository>();
            auftragRepository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>())).Returns(
                new[]
                {
                    new KesAuftrag
                    {
                        KesAuftragID = 1,
                        FaLeistungID = 1,
                        DatumAuftrag = new DateTime(2012, 1, 1),
                        UserID = 1,
                        Anlass = "Testanlass1",
                        Auftrag = "Testauftrag1",
                    },
                    new KesAuftrag
                    {
                        KesAuftragID = 1,
                        FaLeistungID = 1,
                        DatumAuftrag = new DateTime(2012, 1, 1),
                        UserID = 1,
                        Anlass = "Testanlass2",
                        Auftrag = "Testauftrag2",
                    }
                });

            var uowMock = new UnitOfWorkMock();
            uowMock.RegisterRepository(uow => uow.KesAuftrag, auftragRepository.Object);

            // Act
            var service = Container.Resolve<KesAuftragService>();
            var result = service.GetByFaLeistungId(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result[0].DatumAuftrag);
            Assert.IsNotNull(result[0].KesAuftrag_BaPerson);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Testauftrag1", result[0].Auftrag);
            Assert.AreEqual("Testauftrag2", result[1].Auftrag);
        }
    }
}