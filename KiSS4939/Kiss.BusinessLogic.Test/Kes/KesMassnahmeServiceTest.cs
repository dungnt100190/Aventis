using System.Collections.Generic;
using System.Collections.ObjectModel;

using Kiss.BusinessLogic.Kes;
using Kiss.DataAccess.Kes;
using Kiss.DataAccess.Sys;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kiss.BusinessLogic.Test.Kes
{
    [TestClass]
    public class KesMassnahmeServiceTest
    {
        [TestMethod]
        public void GetByFaLeistungId_MitArtikel_ZgbArtikelTextKurzIstGesetzt()
        {
            // Arrange
            var kesArtikel1 = new KesArtikel
            {
                KesArtikelID = 11,
                Artikel = "392",
                Ziffer = "2",
                Gesetz = "ZGB",
                Bezeichnung = "Auftrag an Drittperson",
            };
            var kesArtikel2 = new KesArtikel
            {
                KesArtikelID = 12,
                Artikel = "311",
                Absatz = "1",
                Ziffer = "1",
                Gesetz = "ZGB",
                Bezeichnung = "Entziehung der elterlichen Sorge von Amtes wegen - Eltern sind ausserstande",
            };
            var massnahmeRepository = new Mock<KesMassnahmeRepository>();
            massnahmeRepository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>(), false)).Returns(
                new[]
                {
                    new KesMassnahme
                    {
                        KesMassnahmeID = 1,
                        FaLeistungID = 1,
                        Auftragstext = "Testauftrag1",
                        KesMassnahme_KesArtikel = new List<KesMassnahme_KesArtikel>
                        {
                            new KesMassnahme_KesArtikel
                            {
                                KesArtikelID = kesArtikel1.KesArtikelID,
                                KesArtikel = kesArtikel1,
                            },
                            new KesMassnahme_KesArtikel
                            {
                                KesArtikelID = kesArtikel2.KesArtikelID,
                                KesArtikel = kesArtikel2,
                            },
                        },
                    },
                    new KesMassnahme
                    {
                        KesMassnahmeID = 1,
                        FaLeistungID = 1,
                        Auftragstext = "Testauftrag2",
                    }
                });

            var artikelRepository = new Mock<KesArtikelRepository>();
            artikelRepository.Setup(moq => moq.GetByArtikelIds(It.IsAny<int[]>())).Returns(
                new List<KesArtikel>
                {
                    kesArtikel1,
                    kesArtikel2,
                });

            var uowMock = new UnitOfWorkMock();
            uowMock.RegisterRepository(uow => uow.KesMassnahme, massnahmeRepository.Object);
            uowMock.RegisterRepository(uow => uow.KesArtikel, artikelRepository.Object);

            // Act
            var service = Container.Resolve<KesMassnahmeService>();
            var result = service.GetByFaLeistungId(1, false);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Testauftrag1", result[0].Auftragstext);
            Assert.AreEqual("392.2 ZGB, 311.1.1 ZGB", result[0].ZgbArtikelTextKurz);
            Assert.AreEqual("Testauftrag2", result[1].Auftragstext);
            Assert.AreEqual("", result[1].ZgbArtikelTextKurz);
        }

        [TestMethod]
        public void GetByFaLeistungId_Ok()
        {
            // Arrange
            var massnahmeRepository = new Mock<KesMassnahmeRepository>();
            massnahmeRepository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>(), false)).Returns(
                new[]
                {
                    new KesMassnahme
                    {
                        KesMassnahmeID = 1,
                        FaLeistungID = 1,
                        Auftragstext = "Testauftrag1",
                    },
                    new KesMassnahme
                    {
                        KesMassnahmeID = 1,
                        FaLeistungID = 1,
                        Auftragstext = "Testauftrag2",
                    }
                });

            var artikelRepository = new Mock<KesArtikelRepository>();
            artikelRepository.Setup(moq => moq.GetByArtikelIds(It.IsAny<int[]>()))
                            .Returns(new List<KesArtikel>());

            var uowMock = new UnitOfWorkMock();
            uowMock.RegisterRepository(uow => uow.KesMassnahme, massnahmeRepository.Object);
            uowMock.RegisterRepository(uow => uow.KesArtikel, artikelRepository.Object);

            // Act
            var service = Container.Resolve<KesMassnahmeService>();
            var result = service.GetByFaLeistungId(1, false);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Testauftrag1", result[0].Auftragstext);
            Assert.AreEqual("Testauftrag2", result[1].Auftragstext);
        }

        [TestMethod]
        public void GetCleanedCopyOfKesMassnahme_MassnahmeWithRelations_Ok()
        {
            // Arrange
            var kesMassnahme = new KesMassnahme
            {
                KesMassnahmeID = 1,
                FaLeistungID = 1,
                KesMandatsfuehrendePerson = new Collection<KesMandatsfuehrendePerson>
                {
                    new KesMandatsfuehrendePerson
                    {
                        KesMassnahmeID = 1,
                        KesMandatsfuehrendePersonID = 2
                    }
                },
                KesMassnahmeBericht = new Collection<KesMassnahmeBericht>
                {
                    new KesMassnahmeBericht
                    {
                        KesMassnahmeBerichtID = 3,
                        KesMassnahmeID = 1
                    }
                }
            };

            var configRepository = new Mock<XConfigRepository>();
            configRepository.Setup(moq => moq.GetAllEntities())
                            .Returns(new XConfig[] { });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XConfig, configRepository.Object);

            // Act
            var service = Container.Resolve<KesMassnahmeService>();
            var result = service.GetCleanedCopyOfKesMassnahme(kesMassnahme);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.KesMandatsfuehrendePerson);
            Assert.AreEqual(null, result.KesMassnahmeBericht);
            Assert.AreEqual(1, result.FaLeistungID);
        }

        [TestMethod]
        public void SetZgbArtikelTextKurzOfMassnahme_MassnahmeMitArtikel_KurztextIstGesetzt()
        {
            // Arrange
            var kesArtikel1 = new KesArtikel
            {
                KesArtikelID = 11,
                Artikel = "392",
                Ziffer = "2",
                Gesetz = "ZGB",
                Bezeichnung = "Auftrag an Drittperson",
            };
            var kesArtikel2 = new KesArtikel
            {
                KesArtikelID = 12,
                Artikel = "311",
                Absatz = "1",
                Ziffer = "1",
                Gesetz = "ZGB",
                Bezeichnung = "Entziehung der elterlichen Sorge von Amtes wegen - Eltern sind ausserstande",
            };
            var kesMassnahme = new KesMassnahme
            {
                KesMassnahmeID = 1,
                FaLeistungID = 1,
                Auftragstext = "Testauftrag1",
                KesMassnahme_KesArtikel = new List<KesMassnahme_KesArtikel>
                {
                    new KesMassnahme_KesArtikel
                    {
                        KesArtikelID = kesArtikel1.KesArtikelID,
                        KesArtikel = kesArtikel1,
                    },
                    new KesMassnahme_KesArtikel
                    {
                        KesArtikelID = kesArtikel2.KesArtikelID,
                        KesArtikel = kesArtikel2,
                    },
                },
            };

            var massnahmeRepository = new Mock<KesMassnahmeRepository>();
            massnahmeRepository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>(), false)).Returns(
                new[]
                {
                    kesMassnahme
                });

            var artikelRepository = new Mock<KesArtikelRepository>();
            artikelRepository.Setup(moq => moq.GetByArtikelIds(It.IsAny<int[]>())).Returns(
                new List<KesArtikel>
                {
                    kesArtikel1,
                    kesArtikel2,
                });

            var uowMock = new UnitOfWorkMock();
            uowMock.RegisterRepository(uow => uow.KesMassnahme, massnahmeRepository.Object);
            uowMock.RegisterRepository(uow => uow.KesArtikel, artikelRepository.Object);

            // Act
            var service = Container.Resolve<KesMassnahmeService>();
            service.SetZgbArtikelTextKurzOfMassnahme(uowMock.GetUnitOfWork(), kesMassnahme);

            // Assert
            Assert.AreEqual("392.2 ZGB, 311.1.1 ZGB", kesMassnahme.ZgbArtikelTextKurz);
        }

        [TestMethod]
        public void SetZgbArtikelTextKurzOfMassnahme_MassnahmeMitUndDannOhneArtikel_KurztextIstLeer()
        {
            // Arrange
            var kesArtikel1 = new KesArtikel
            {
                KesArtikelID = 11,
                Artikel = "392",
                Ziffer = "2",
                Gesetz = "ZGB",
                Bezeichnung = "Auftrag an Drittperson",
            };
            var kesArtikel2 = new KesArtikel
            {
                KesArtikelID = 12,
                Artikel = "311",
                Absatz = "1",
                Ziffer = "1",
                Gesetz = "ZGB",
                Bezeichnung = "Entziehung der elterlichen Sorge von Amtes wegen - Eltern sind ausserstande",
            };
            var kesMassnahme = new KesMassnahme
            {
                KesMassnahmeID = 1,
                FaLeistungID = 1,
                Auftragstext = "Testauftrag1",
                KesMassnahme_KesArtikel = new List<KesMassnahme_KesArtikel>
                {
                    new KesMassnahme_KesArtikel
                    {
                        KesArtikelID = kesArtikel1.KesArtikelID,
                        KesArtikel = kesArtikel1,
                    },
                    new KesMassnahme_KesArtikel
                    {
                        KesArtikelID = kesArtikel2.KesArtikelID,
                        KesArtikel = kesArtikel2,
                    },
                },
            };

            var massnahmeRepository = new Mock<KesMassnahmeRepository>();
            massnahmeRepository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>(), false)).Returns(
                new[]
                {
                    kesMassnahme
                });

            var artikelRepository = new Mock<KesArtikelRepository>();
            artikelRepository.Setup(moq => moq.GetByArtikelIds(It.IsAny<int[]>())).Returns(
                new List<KesArtikel>
                {
                    kesArtikel1,
                    kesArtikel2,
                });

            var uowMock = new UnitOfWorkMock();
            uowMock.RegisterRepository(uow => uow.KesMassnahme, massnahmeRepository.Object);
            uowMock.RegisterRepository(uow => uow.KesArtikel, artikelRepository.Object);

            // Act
            var service = Container.Resolve<KesMassnahmeService>();
            service.SetZgbArtikelTextKurzOfMassnahme(uowMock.GetUnitOfWork(), kesMassnahme);
            kesMassnahme.KesMassnahme_KesArtikel = null;
            service.SetZgbArtikelTextKurzOfMassnahme(uowMock.GetUnitOfWork(), kesMassnahme);

            // Assert
            Assert.AreEqual("", kesMassnahme.ZgbArtikelTextKurz);
        }

        [TestMethod]
        public void SetZgbArtikelTextKurzOfMassnahme_MassnahmeOhneArtikel_KurztextIstLeer()
        {
            // Arrange
            var kesMassnahme = new KesMassnahme
            {
                KesMassnahmeID = 1,
                FaLeistungID = 1,
                Auftragstext = "Testauftrag1",
                KesMassnahme_KesArtikel = null,
            };

            var massnahmeRepository = new Mock<KesMassnahmeRepository>();
            massnahmeRepository.Setup(moq => moq.GetByFaLeistungId(It.IsAny<int>(), false)).Returns(
                new[]
                {
                    kesMassnahme
                });

            var artikelRepository = new Mock<KesArtikelRepository>();
            artikelRepository.Setup(moq => moq.GetByArtikelIds(It.IsAny<int[]>())).Returns(
                new List<KesArtikel>()
                );

            var uowMock = new UnitOfWorkMock();
            uowMock.RegisterRepository(uow => uow.KesMassnahme, massnahmeRepository.Object);
            uowMock.RegisterRepository(uow => uow.KesArtikel, artikelRepository.Object);

            // Act
            var service = Container.Resolve<KesMassnahmeService>();
            service.SetZgbArtikelTextKurzOfMassnahme(uowMock.GetUnitOfWork(), kesMassnahme);

            // Assert
            Assert.AreEqual("", kesMassnahme.ZgbArtikelTextKurz);
        }
    }
}