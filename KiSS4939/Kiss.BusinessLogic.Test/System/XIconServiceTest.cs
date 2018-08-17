using System;
using System.Collections.Generic;
using Kiss.BusinessLogic.Sys;
using Kiss.DataAccess;
using Kiss.DataAccess.Fa;
using Kiss.DataAccess.Sys;
using Kiss.DbContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kiss.BusinessLogic.Test.System
{
    /// <summary>
    /// Unittestclass for XIconServiceTest
    /// </summary>
    [TestClass]
    public class XIconServiceTest
    {
        #region Test Methods

        [TestMethod]
        public void GetModulIcons_AbgeschlossenerFall_Ok()
        {
            // Arrange
            var personRepository = new Mock<BaPersonRepository>();
            personRepository.Setup(moq => moq.Exists(It.IsAny<int>()))
                            .Returns(true);

            var fallRepository = new Mock<FaFallRepository>();
            fallRepository.Setup(moq => moq.GetByPersonId(It.IsAny<int>()))
                            .Returns(new List<FaFall>
                                        {
                                            new FaFall
                                            {
                                                FaFallID = 1,
                                                BaPersonID = 12,
                                            }
                                        });

            var leistungRepository = new Mock<FaLeistungRepository>();
            leistungRepository.Setup(moq => moq.GetByFaFallIds(It.IsAny<List<int>>()))
                            .Returns(new List<FaLeistung>
                                        {
                                            new FaLeistung
                                            {
                                                FaLeistungID = 1,
                                                FaFallID = 1,
                                                ModulID = 3,
                                                FaLeistungArchiv = new List<FaLeistungArchiv>(),
                                                DatumBis = new DateTime(2012, 1, 1)
                                            }
                                        });

            var modulRepository = new Mock<XModulRepository>();
            modulRepository.Setup(moq => moq.GetForGotoFall(It.IsAny<bool>()))
                            .Returns(new List<XModul>
                                        {
                                            new XModul
                                            {
                                                ModulID = 3,
                                                ShortName = "S",
                                                SortKey = 3,
                                            }
                                        });

            var ouwMock = new UnitOfWorkMock();
            ouwMock.RegisterRepository(uow => uow.FaFall, fallRepository.Object);
            ouwMock.RegisterRepository(uow => uow.BaPerson, personRepository.Object);
            ouwMock.RegisterRepository(uow => uow.FaLeistung, leistungRepository.Object);
            ouwMock.RegisterRepository(uow => uow.XModul, modulRepository.Object);
            var xIconRepository = new Mock<XIconRepository>();
            ouwMock.RegisterRepository(uow => uow.XIcon, xIconRepository.Object);

            // Act
            var service = new XIconService();
            var result = service.GetModulIcons(12);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result[0].ModulID);
            Assert.AreEqual("S", result[0].ShortName);
            Assert.AreEqual(1302, result[0].IconId);
            Assert.IsFalse(result[0].IsEmptyIcon);
        }

        [TestMethod]
        public void GetModulIcons_AktiverFall_Ok()
        {
            // Arrange
            var personRepository = new Mock<BaPersonRepository>();
            personRepository.Setup(moq => moq.Exists(It.IsAny<int>()))
                            .Returns(true);

            var fallRepository = new Mock<FaFallRepository>();
            fallRepository.Setup(moq => moq.GetByPersonId(It.IsAny<int>()))
                            .Returns(new List<FaFall>
                                        {
                                            new FaFall
                                            {
                                                FaFallID = 1,
                                                BaPersonID = 12,
                                            }
                                        });

            var leistungRepository = new Mock<FaLeistungRepository>();
            leistungRepository.Setup(moq => moq.GetByFaFallIds(It.IsAny<List<int>>()))
                            .Returns(new List<FaLeistung>
                                        {
                                            new FaLeistung
                                            {
                                                FaLeistungID = 1,
                                                FaFallID = 1,
                                                ModulID = 2,
                                                FaLeistungArchiv = new List<FaLeistungArchiv>()
                                            }
                                        });

            var modulRepository = new Mock<XModulRepository>();
            modulRepository.Setup(moq => moq.GetForGotoFall(It.IsAny<bool>()))
                            .Returns(new List<XModul>
                                        {
                                            new XModul
                                            {
                                                ModulID = 2,
                                                ShortName = "F",
                                                SortKey = 2,
                                            }
                                        });

            var ouwMock = new UnitOfWorkMock();
            ouwMock.RegisterRepository(uow => uow.FaFall, fallRepository.Object);
            ouwMock.RegisterRepository(uow => uow.BaPerson, personRepository.Object);
            ouwMock.RegisterRepository(uow => uow.FaLeistung, leistungRepository.Object);
            ouwMock.RegisterRepository(uow => uow.XModul, modulRepository.Object);
            var xIconRepository = new Mock<XIconRepository>();
            ouwMock.RegisterRepository(uow => uow.XIcon, xIconRepository.Object);

            // Act
            var service = new XIconService();
            var result = service.GetModulIcons(12);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result[0].ModulID);
            Assert.AreEqual("F", result[0].ShortName);
            Assert.AreEqual(1201, result[0].IconId);
            Assert.IsFalse(result[0].IsEmptyIcon);
        }

        [TestMethod]
        public void GetModulIcons_ArchivierterFall_Ok()
        {
            // Arrange
            var personRepository = new Mock<BaPersonRepository>();
            personRepository.Setup(moq => moq.Exists(It.IsAny<int>()))
                            .Returns(true);

            var fallRepository = new Mock<FaFallRepository>();
            fallRepository.Setup(moq => moq.GetByPersonId(It.IsAny<int>()))
                            .Returns(new List<FaFall>
                                        {
                                            new FaFall
                                            {
                                                FaFallID = 1,
                                                BaPersonID = 12,
                                            }
                                        });

            var leistungRepository = new Mock<FaLeistungRepository>();
            leistungRepository.Setup(moq => moq.GetByFaFallIds(It.IsAny<List<int>>()))
                            .Returns(new List<FaLeistung>
                                        {
                                            new FaLeistung
                                            {
                                                FaLeistungID = 1,
                                                FaFallID = 1,
                                                ModulID = 3,
                                                FaLeistungArchiv = new List<FaLeistungArchiv>
                                                                    {
                                                                        new FaLeistungArchiv
                                                                        {
                                                                            FaLeistungID = 1,
                                                                            FaLeistungArchivID = 45
                                                                        }
                                                                    }
                                            }
                                        });

            var modulRepository = new Mock<XModulRepository>();
            modulRepository.Setup(moq => moq.GetForGotoFall(It.IsAny<bool>()))
                            .Returns(new List<XModul>
                                        {
                                            new XModul
                                            {
                                                ModulID = 3,
                                                ShortName = "S",
                                                SortKey = 3,
                                            }
                                        });

            var ouwMock = new UnitOfWorkMock();
            ouwMock.RegisterRepository(uow => uow.FaFall, fallRepository.Object);
            ouwMock.RegisterRepository(uow => uow.BaPerson, personRepository.Object);
            ouwMock.RegisterRepository(uow => uow.FaLeistung, leistungRepository.Object);
            ouwMock.RegisterRepository(uow => uow.XModul, modulRepository.Object);
            var xIconRepository = new Mock<XIconRepository>();
            ouwMock.RegisterRepository(uow => uow.XIcon, xIconRepository.Object);

            // Act
            var service = new XIconService();
            var result = service.GetModulIcons(12);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result[0].ModulID);
            Assert.AreEqual("S", result[0].ShortName);
            Assert.AreEqual(1303, result[0].IconId);
            Assert.IsFalse(result[0].IsEmptyIcon);
        }

        [TestMethod]
        public void GetModulIcons_Basismodul_Ok()
        {
            // Arrange
            var personRepository = new Mock<BaPersonRepository>();
            personRepository.Setup(moq => moq.Exists(It.IsAny<int>()))
                            .Returns(true);

            var fallRepository = new Mock<FaFallRepository>();
            fallRepository.Setup(moq => moq.GetByPersonId(It.IsAny<int>()))
                            .Returns(new List<FaFall>
                                        {
                                            new FaFall
                                            {
                                                FaFallID = 1,
                                                BaPersonID = 12,
                                            }
                                        });

            var leistungRepository = new Mock<FaLeistungRepository>();
            leistungRepository.Setup(moq => moq.GetByFaFallIds(It.IsAny<List<int>>()))
                            .Returns(new List<FaLeistung>
                                        {
                                            new FaLeistung
                                            {
                                                FaLeistungID = 1,
                                                FaFallID = 1,
                                                ModulID = 1,
                                                FaLeistungArchiv = new List<FaLeistungArchiv>()
                                            }
                                        });

            var modulRepository = new Mock<XModulRepository>();
            modulRepository.Setup(moq => moq.GetForGotoFall(It.IsAny<bool>()))
                            .Returns(new List<XModul>
                                        {
                                            new XModul
                                            {
                                                ModulID = 1,
                                                ShortName = "B",
                                                SortKey = 1,
                                            }
                                        });

            var ouwMock = new UnitOfWorkMock();
            ouwMock.RegisterRepository(uow => uow.FaFall, fallRepository.Object);
            ouwMock.RegisterRepository(uow => uow.BaPerson, personRepository.Object);
            ouwMock.RegisterRepository(uow => uow.FaLeistung, leistungRepository.Object);
            ouwMock.RegisterRepository(uow => uow.XModul, modulRepository.Object);
            var xIconRepository = new Mock<XIconRepository>();
            ouwMock.RegisterRepository(uow => uow.XIcon, xIconRepository.Object);

            // Act
            var service = new XIconService();
            var result = service.GetModulIcons(12);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result[0].ModulID);
            Assert.AreEqual("B", result[0].ShortName);
            Assert.AreEqual(1101, result[0].IconId);
            Assert.IsFalse(result[0].IsEmptyIcon);
        }

        [TestMethod]
        public void GetModulIcons_IsPiAktiverFall_Ok()
        {
            // Arrange
            var personRepository = new Mock<BaPersonRepository>();
            personRepository.Setup(moq => moq.Exists(It.IsAny<int>()))
                            .Returns(true);

            var fallRepository = new Mock<FaFallRepository>();
            fallRepository.Setup(moq => moq.GetByPersonId(It.IsAny<int>()))
                            .Returns(new List<FaFall>
                                        {
                                            new FaFall
                                            {
                                                FaFallID = 1,
                                                BaPersonID = 12,
                                            }
                                        });

            var leistungRepository = new Mock<FaLeistungRepository>();
            leistungRepository.Setup(moq => moq.GetByFaFallIds(It.IsAny<List<int>>()))
                            .Returns(new List<FaLeistung>
                                        {
                                            new FaLeistung
                                            {
                                                FaLeistungID = 1,
                                                FaFallID = 1,
                                                ModulID = 2,
                                                FaLeistungArchiv = new List<FaLeistungArchiv>()
                                            }
                                        });

            var modulRepository = new Mock<XModulRepository>();
            modulRepository.Setup(moq => moq.GetForGotoFall(It.IsAny<bool>()))
                            .Returns(new List<XModul>
                                        {
                                            new XModul
                                            {
                                                ModulID = 2,
                                                ShortName = "F",
                                                SortKey = 2,
                                            },
                                            new XModul
                                            {
                                                ModulID = 3,
                                                ShortName = "SB",
                                                SortKey = 3,
                                            }
                                        });

            var ouwMock = new UnitOfWorkMock();
            ouwMock.RegisterRepository(uow => uow.FaFall, fallRepository.Object);
            ouwMock.RegisterRepository(uow => uow.BaPerson, personRepository.Object);
            ouwMock.RegisterRepository(uow => uow.FaLeistung, leistungRepository.Object);
            ouwMock.RegisterRepository(uow => uow.XModul, modulRepository.Object);
            var xIconRepository = new Mock<XIconRepository>();
            ouwMock.RegisterRepository(uow => uow.XIcon, xIconRepository.Object);

            // Act
            var service = new XIconService();
            var result = service.GetModulIcons(12, null, false, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);

            Assert.AreEqual(2, result[0].ModulID);
            Assert.AreEqual("F", result[0].ShortName);
            Assert.AreEqual(1201, result[0].IconId);
            Assert.IsFalse(result[0].IsEmptyIcon);

            Assert.AreEqual(3, result[1].ModulID);
            Assert.AreEqual(4, result[1].OrderId);
            Assert.AreEqual("SB", result[1].ShortName);
            Assert.AreEqual(1300, result[1].IconId);
            Assert.IsTrue(result[1].IsEmptyIcon);
        }

        [TestMethod]
        public void GetModulIcons_IsPiTreeExistsAktiverFall_Ok()
        {
            // Arrange
            var personRepository = new Mock<BaPersonRepository>();
            personRepository.Setup(moq => moq.Exists(It.IsAny<int>()))
                            .Returns(true);

            var fallRepository = new Mock<FaFallRepository>();
            fallRepository.Setup(moq => moq.GetByPersonId(It.IsAny<int>()))
                            .Returns(new List<FaFall>
                                        {
                                            new FaFall
                                            {
                                                FaFallID = 1,
                                                BaPersonID = 12,
                                            }
                                        });

            var leistungRepository = new Mock<FaLeistungRepository>();
            leistungRepository.Setup(moq => moq.GetByFaFallIds(It.IsAny<List<int>>()))
                            .Returns(new List<FaLeistung>
                                        {
                                            new FaLeistung
                                            {
                                                FaLeistungID = 1,
                                                FaFallID = 1,
                                                ModulID = 2,
                                                FaLeistungArchiv = new List<FaLeistungArchiv>()
                                            }
                                        });

            var modulRepository = new Mock<XModulRepository>();
            modulRepository.Setup(moq => moq.GetForGotoFall(It.IsAny<bool>()))
                            .Returns(new List<XModul>
                                        {
                                            new XModul
                                            {
                                                ModulID = 2,
                                                ShortName = "F",
                                                SortKey = 2,
                                            },
                                            new XModul
                                            {
                                                ModulID = 3,
                                                ShortName = "SB",
                                                SortKey = 3,
                                            }
                                        });

            var ouwMock = new UnitOfWorkMock();
            ouwMock.RegisterRepository(uow => uow.FaFall, fallRepository.Object);
            ouwMock.RegisterRepository(uow => uow.BaPerson, personRepository.Object);
            ouwMock.RegisterRepository(uow => uow.FaLeistung, leistungRepository.Object);
            ouwMock.RegisterRepository(uow => uow.XModul, modulRepository.Object);
            var xIconRepository = new Mock<XIconRepository>();
            ouwMock.RegisterRepository(uow => uow.XIcon, xIconRepository.Object);

            // Act
            var service = new XIconService();
            var result = service.GetModulIcons(12, null, true, true);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);

            Assert.AreEqual(2, result[0].ModulID);
            Assert.AreEqual("F", result[0].ShortName);
            Assert.AreEqual(1201, result[0].IconId);
            Assert.IsFalse(result[0].IsEmptyIcon);

            Assert.AreEqual(0, result[1].ModulID);
            Assert.AreEqual(3, result[1].OrderId);
            Assert.AreEqual("", result[1].ShortName);
            Assert.AreEqual(0, result[1].IconId);
            Assert.IsTrue(result[1].IsEmptyIcon);

            Assert.AreEqual(3, result[2].ModulID);
            Assert.AreEqual(4, result[2].OrderId);
            Assert.AreEqual("SB", result[2].ShortName);
            Assert.AreEqual(1300, result[2].IconId);
            Assert.IsTrue(result[2].IsEmptyIcon);
        }

        [TestMethod]
        public void GetModulIcons_KeineLeistung_Ok()
        {
            // Arrange
            var personRepository = new Mock<BaPersonRepository>();
            personRepository.Setup(moq => moq.Exists(It.IsAny<int>()))
                            .Returns(true);

            var fallRepository = new Mock<FaFallRepository>();
            fallRepository.Setup(moq => moq.GetByPersonId(It.IsAny<int>()))
                            .Returns(new List<FaFall>
                                        {
                                            new FaFall
                                            {
                                                FaFallID = 1,
                                                BaPersonID = 12,
                                            }
                                        });

            var leistungRepository = new Mock<FaLeistungRepository>();
            leistungRepository.Setup(moq => moq.GetByFaFallIds(It.IsAny<List<int>>()))
                            .Returns(new List<FaLeistung>());

            var modulRepository = new Mock<XModulRepository>();
            modulRepository.Setup(moq => moq.GetForGotoFall(It.IsAny<bool>()))
                            .Returns(new List<XModul>
                                        {
                                            new XModul
                                            {
                                                ModulID = 4,
                                                ShortName = "S",
                                                SortKey = 4,
                                            }
                                        });

            var ouwMock = new UnitOfWorkMock();
            ouwMock.RegisterRepository(uow => uow.FaFall, fallRepository.Object);
            ouwMock.RegisterRepository(uow => uow.BaPerson, personRepository.Object);
            ouwMock.RegisterRepository(uow => uow.FaLeistung, leistungRepository.Object);
            ouwMock.RegisterRepository(uow => uow.XModul, modulRepository.Object);
            var xIconRepository = new Mock<XIconRepository>();
            ouwMock.RegisterRepository(uow => uow.XIcon, xIconRepository.Object);

            // Act
            var service = new XIconService();
            var result = service.GetModulIcons(12);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result[0].ModulID);
            Assert.AreEqual("S", result[0].ShortName);
            Assert.AreEqual(1400, result[0].IconId);
            Assert.IsTrue(result[0].IsEmptyIcon);
        }

        [TestMethod]
        public void GetModulIcons_VormundschaftKes()
        {
            // Arrange
            var personRepository = new Mock<BaPersonRepository>();
            personRepository.Setup(moq => moq.Exists(It.IsAny<int>()))
                .Returns(true);

            var fallRepository = new Mock<FaFallRepository>();
            fallRepository.Setup(moq => moq.GetByPersonId(It.IsAny<int>()))
                .Returns(
                    new List<FaFall>
                    {
                        new FaFall
                        {
                            FaFallID = 13,
                            BaPersonID = 13,
                        }
                    });

            var leistungRepository = new Mock<FaLeistungRepository>();
            leistungRepository.Setup(moq => moq.GetByFaFallIds(It.IsAny<List<int>>()))
                .Returns(
                    new List<FaLeistung>
                    {
                        new FaLeistung
                        {
                            FaLeistungID = 2,
                            FaFallID = 13,
                            ModulID = 5,
                            FaLeistungArchiv = new List<FaLeistungArchiv>(),
                            DatumVon = new DateTime(2014, 1, 1),
                            DatumBis = new DateTime(2014, 12, 31)
                        }
                    });

            var modulRepository = new Mock<XModulRepository>();
            modulRepository.Setup(moq => moq.GetForGotoFall(It.IsAny<bool>()))
                .Returns(
                    new List<XModul>
                    {
                        new XModul
                        {
                            ModulID = 29,
                            ShortName = "M",
                            SortKey = 29,
                        }
                    });

            var ouwMock = new UnitOfWorkMock();
            ouwMock.RegisterRepository(uow => uow.FaFall, fallRepository.Object);
            ouwMock.RegisterRepository(uow => uow.BaPerson, personRepository.Object);
            ouwMock.RegisterRepository(uow => uow.FaLeistung, leistungRepository.Object);
            ouwMock.RegisterRepository(uow => uow.XModul, modulRepository.Object);
            var xIconRepository = new Mock<XIconRepository>();
            ouwMock.RegisterRepository(uow => uow.XIcon, xIconRepository.Object);

            // Act
            var service = new XIconService();
            var result = service.GetModulIcons(13);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(29, result[0].ModulID);
            Assert.AreEqual("M", result[0].ShortName);
            Assert.AreEqual(3902, result[0].IconId);
            Assert.IsFalse(result[0].IsEmptyIcon);
        }

        #endregion
    }
}