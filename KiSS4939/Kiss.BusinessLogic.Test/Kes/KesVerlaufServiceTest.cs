using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.BusinessLogic.Kes;
using Kiss.DataAccess.Kes;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Kes;
using Kiss.DbContext.Enums.Kes;
using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Kiss.BusinessLogic.Test.Kes
{
    [TestClass]
    public class KesVerlaufServiceTest
    {
        [TestMethod]
        public void GetByFaLeistungId_Ok()
        {
            var repository = new Mock<KesVerlaufRepository>();
            repository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>(), (int)KesVerlaufTyp.PriMaBegleitung)).Returns(
                new[]
                {
                    new KesVerlaufDTO(new KesVerlauf
                    {
                        KesVerlaufID = 1,
                        FaLeistungID = 2,
                        KesVerlaufTypCode = (int)KesVerlaufTyp.PriMaBegleitung
                    })
                });

            var uowMock = new UnitOfWorkMock();
            uowMock.RegisterRepository(uow => uow.KesVerlauf, repository.Object);

            var service = Container.Resolve<KesVerlaufService>();
            var result = service.GetByFaLeistungId(2, KesVerlaufTyp.PriMaBegleitung);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }
    }
}