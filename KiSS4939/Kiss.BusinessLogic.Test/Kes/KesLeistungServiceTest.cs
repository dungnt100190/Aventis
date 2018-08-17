using System;
using System.Linq;

using Kiss.BusinessLogic.Kes;
using Kiss.DataAccess.Kes;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace Kiss.BusinessLogic.Test.Kes
{
    [TestClass]
    public class KesLeistungServiceTest
    {
        private const int FA_LEISTUNG_ID = 9945;

        private static readonly FaLeistung FaLeistung = new FaLeistung
        {
            FaLeistungID = FA_LEISTUNG_ID,
            AbschlussGrundCode = 2,
            DatumVon = new DateTime(2014, 1, 4),
            DatumBis = new DateTime(2014, 5, 4)
        };

        private readonly DateTime _badDate = new DateTime(2014, 6, 4);
        private readonly DateTime _goodDate = new DateTime(2014, 4, 4);

        private enum Testtypen
        {
            Auftrag,
            Praevention,
            Massnahme,
            Pflegekinderaufsicht,
            Keiner
        }

        [TestMethod]
        public void AbschlussPruefung_DatumAuftrag_NOk()
        {
            // Arrange
            PrepareMocksWithBadDateOn(Testtypen.Auftrag);

            // Act
            var service = Container.Resolve<KesLeistungService>();
            var result = service.AbschlussPruefung(FaLeistung);

            // Assert
            Assert.IsTrue(result.IsError);
            Assert.AreEqual(1, result.ServiceResultEntries.Where(sre => sre.Message.Contains("Auftrag")).Count());
        }

        [TestMethod]
        public void AbschlussPruefung_DatumKeiner_Ok()
        {
            // Arrange
            PrepareMocksWithBadDateOn(Testtypen.Keiner);

            // Act
            var service = Container.Resolve<KesLeistungService>();
            var result = service.AbschlussPruefung(FaLeistung);

            // Assert
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void AbschlussPruefung_DatumMassnahme_NOk()
        {
            // Arrange
            PrepareMocksWithBadDateOn(Testtypen.Massnahme);

            // Act
            var service = Container.Resolve<KesLeistungService>();
            var result = service.AbschlussPruefung(FaLeistung);

            // Assert
            Assert.IsTrue(result.IsError);
            Assert.AreEqual(1, result.ServiceResultEntries.Where(sre => sre.Message.Contains("Massnahme")).Count());
        }

        [TestMethod]
        public void AbschlussPruefung_DatumPflegekinderaufsicht_NOk()
        {
            // Arrange
            PrepareMocksWithBadDateOn(Testtypen.Pflegekinderaufsicht);

            // Act
            var service = Container.Resolve<KesLeistungService>();
            var result = service.AbschlussPruefung(FaLeistung);

            // Assert
            Assert.IsTrue(result.IsError);
            Assert.AreEqual(1, result.ServiceResultEntries.Where(sre => sre.Message.Contains("Pflegekinderaufsicht")).Count());
        }

        [TestMethod]
        public void AbschlussPruefung_DatumPraevention_NOk()
        {
            // Arrange
            PrepareMocksWithBadDateOn(Testtypen.Praevention);

            // Act
            var service = Container.Resolve<KesLeistungService>();
            var result = service.AbschlussPruefung(FaLeistung);

            // Assert
            Assert.IsTrue(result.IsError);
            Assert.AreEqual(1, result.ServiceResultEntries.Where(sre => sre.Message.Contains("Prävention")).Count());
        }

        [TestMethod]
        public void AbschlussPruefung_Grund_NOk()
        {
            // Arrange
            PrepareMocksWithBadDateOn(Testtypen.Keiner);

            // Act
            var service = Container.Resolve<KesLeistungService>();
            var result = service.AbschlussPruefung(new FaLeistung
            {
                FaLeistungID = FA_LEISTUNG_ID,
                DatumVon = new DateTime(2014, 1, 4),
                DatumBis = new DateTime(2014, 5, 4)
            });

            // Assert
            Assert.IsTrue(result.IsError);
            Assert.AreEqual(1, result.ServiceResultEntries.Where(sre => sre.Message.Contains("Grund")).Count());
        }

        private void PrepareMocksWithBadDateOn(Testtypen bad)
        {
            var uowMock = new UnitOfWorkMock();

            var kesPraeventionRepository = new Mock<KesPraeventionRepository>();
            kesPraeventionRepository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>())).Returns(
                new[]
                {
                    new KesPraevention
                    {
                        FaLeistungID = FA_LEISTUNG_ID,
                        DatumBis = (Testtypen.Praevention == bad ? _badDate : _goodDate)
                    }
                });
            uowMock.RegisterRepository(uow => uow.KesPraevention, kesPraeventionRepository.Object);

            var kesAuftragRepository = new Mock<KesAuftragRepository>();
            kesAuftragRepository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>())).Returns(
                new[]
                {
                    new KesAuftrag
                    {
                        FaLeistungID = FA_LEISTUNG_ID,
                        AbschlussDatum = (Testtypen.Auftrag == bad ? _badDate : _goodDate)
                    }
                });
            uowMock.RegisterRepository(uow => uow.KesAuftrag, kesAuftragRepository.Object);

            var kesMassnahmeRepository = new Mock<KesMassnahmeRepository>();
            kesMassnahmeRepository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>(), false)).Returns(
                new[]
                {
                    new KesMassnahme
                    {
                        FaLeistungID = FA_LEISTUNG_ID,
                        DatumBis = (Testtypen.Massnahme == bad ? _badDate : _goodDate)
                    }
                });
            uowMock.RegisterRepository(uow => uow.KesMassnahme, kesMassnahmeRepository.Object);

            var kesPflegekinderaufsichtRepository = new Mock<KesPflegekinderaufsichtRepository>();
            kesPflegekinderaufsichtRepository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>())).Returns(
                new[]
                {
                    new KesPflegekinderaufsicht
                    {
                        FaLeistungID = FA_LEISTUNG_ID,
                        DatumBis = (Testtypen.Pflegekinderaufsicht == bad ? _badDate : _goodDate)
                    }
                });
            uowMock.RegisterRepository(uow => uow.KesPflegekinderaufsicht, kesPflegekinderaufsichtRepository.Object);
        }
    }
}