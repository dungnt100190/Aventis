using System.Collections.Generic;
using Kiss.BusinessLogic.Cache;
using Kiss.BusinessLogic.Sys;
using Kiss.DataAccess.Sys;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kiss.BusinessLogic.Test.System
{
    /// <summary>
    /// Unittestclass for XLovService
    /// </summary>
    [TestClass]
    public class XLovServiceTest
    {
        [TestMethod]
        public void ClearCacheTest()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                    Text = "first",
                                    Value3 = "A",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                    Text = "second",
                                    Value3 = "A,B",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                    Text = "third",
                                    Value3 = "B,C",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 4,
                                    Text = "fourth",
                                    Value3 = "B",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 5,
                                    Text = "fifth",
                                    Value3 = "B,A",
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var lovCodes = xLovService.GetLovCodesByLovName(lovName, false, false, "A", "B");
            LOVCache cache = Container.TryResolve<LOVCache>();
            cache.ClearCache();

            // Assert
            Assert.AreEqual(2, lovCodes.Count);
            Assert.AreEqual(2, lovCodes[0].Code);
            Assert.AreEqual(5, lovCodes[1].Code);
            Assert.IsTrue(!cache.IsCached(lovName));
        }

        [TestMethod]
        public void EnsureXLovCacheGetsFilled()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                    Text = "first",
                                    Value3 = "A",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                    Text = "second",
                                    Value3 = "A,B",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                    Text = "third",
                                    Value3 = "B,C",
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var result = xLovService.GetStringFromLovCodes(lovName, "1,3");
            LOVCache cache = Container.TryResolve<LOVCache>();

            // Assert
            Assert.AreEqual("first, third", result);
            Assert.IsTrue(cache.IsCached(lovName));
        }

        [TestMethod]
        public void Filter_NullValueRemains()
        {
            var lovName = "TestLov";
            var list = new List<XLOVCode>
            {
                new XLOVCode
                {
                    LOVName = lovName,
                    Code = -1,
                },
                new XLOVCode
                {
                    LOVName = lovName,
                    Code = 1,
                    Text = "1",
                    Value3 = "1"
                },
                new XLOVCode
                {
                    LOVName = lovName,
                    Code = 2,
                    Text = "2",
                    Value3 = "2"
                },
            };

            var xLovService = Container.Resolve<XLovService>();
            var result = xLovService.FilterLovCodes(list, 2);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(-1, result[0].Code);
            Assert.AreEqual(2, result[1].Code);
        }

        [TestMethod]
        public void GetLovCodes_InactiveCode()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                .Returns(
                    new List<XLOVCode>
                    {
                        new XLOVCode
                        {
                            LOVName = lovName,
                            Code = 1,
                            Text = "first",
                            Value3 = "A",
                            IsActive = true,
                        },
                        new XLOVCode
                        {
                            LOVName = lovName,
                            Code = 2,
                            Text = "second",
                            Value3 = "A,B",
                            IsActive = true,
                        },
                        new XLOVCode
                        {
                            LOVName = lovName,
                            Code = 3,
                            Text = "third",
                            Value3 = "B,C",
                            IsActive = false,
                        },
                    });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var result = xLovService.GetLovCodes(lovName, "1,2,3");

            // Assert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(1, result[0].Code);
            Assert.AreEqual(2, result[1].Code);
            Assert.AreEqual(3, result[2].Code);
        }

        [TestMethod]
        public void GetLovCodes_OneCode()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                    Text = "first",
                                    Value3 = "A",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                    Text = "second",
                                    Value3 = "A,B",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                    Text = "third",
                                    Value3 = "B,C",
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var result = xLovService.GetLovCodes(lovName, "1");

            // Assert
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(1, result[0].Code);
        }

        [TestMethod]
        public void GetLovCodes_TwoCodes()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                    Text = "first",
                                    Value3 = "A",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                    Text = "second",
                                    Value3 = "A,B",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                    Text = "third",
                                    Value3 = "B,C",
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var result = xLovService.GetLovCodes(lovName, "1,3");

            // Assert
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(1, result[0].Code);
            Assert.AreEqual(3, result[1].Code);
        }

        [TestMethod]
        public void GetLovCodesByLovName_IncludeNullValue_False()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var lovCodes = xLovService.GetLovCodesByLovName(lovName);

            // Assert
            Assert.AreEqual(3, lovCodes.Count);
            Assert.AreEqual(1, lovCodes[0].Code);
        }

        [TestMethod]
        public void GetLovCodesByLovName_IncludeNullValue_True()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var lovCodes = xLovService.GetLovCodesByLovName(lovName, true);

            // Assert
            Assert.AreEqual(4, lovCodes.Count);
            Assert.AreEqual(-1, lovCodes[0].Code);
            Assert.AreEqual(1, lovCodes[1].Code);
        }

        [TestMethod]
        public void GetLovCodesByLovName_OneFilter()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                    Text = "first",
                                    Value3 = "A",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                    Text = "second",
                                    Value3 = "A,B",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                    Text = "third",
                                    Value3 = "B,C",
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var lovCodes = xLovService.GetLovCodesByLovName(lovName, false, false, "A");

            // Assert
            Assert.AreEqual(2, lovCodes.Count);
            Assert.AreEqual(1, lovCodes[0].Code);
            Assert.AreEqual(2, lovCodes[1].Code);
        }

        [TestMethod]
        public void GetLovCodesByLovName_OnlyActive()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                    IsActive = true,
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                    IsActive = true,
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                    IsActive = false,
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var lovCodes = xLovService.GetLovCodesByLovName(lovName, false, true);

            // Assert
            Assert.AreEqual(2, lovCodes.Count);
            Assert.AreEqual(1, lovCodes[0].Code);
            Assert.AreEqual(2, lovCodes[1].Code);
        }

        [TestMethod]
        public void GetLovCodesByLovName_TwoFilters()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                    Text = "first",
                                    Value3 = "A",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                    Text = "second",
                                    Value3 = "A,B",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                    Text = "third",
                                    Value3 = "B,C",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 4,
                                    Text = "fourth",
                                    Value3 = "B",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 5,
                                    Text = "fifth",
                                    Value3 = "B,A",
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var lovCodes = xLovService.GetLovCodesByLovName(lovName, false, false, "A", "B");

            // Assert
            Assert.AreEqual(2, lovCodes.Count);
            Assert.AreEqual(2, lovCodes[0].Code);
            Assert.AreEqual(5, lovCodes[1].Code);
        }

        [TestMethod]
        public void GetSingleLovCode_CodeExists()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                    Text = "first",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                    Text = "second",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                    Text = "third",
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var lovCode = xLovService.GetSingleLovCode(lovName, 2);

            // Assert
            Assert.IsNotNull(lovCode);
            Assert.AreEqual(2, lovCode.Code);
            Assert.AreEqual("second", lovCode.Text);
        }

        [TestMethod]
        public void GetSingleLovCode_CodeNotExists()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                    Text = "first",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                    Text = "second",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                    Text = "third",
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var lovCode = xLovService.GetSingleLovCode(lovName, 4);

            // Assert
            Assert.IsNull(lovCode);
        }

        [TestMethod]
        public void GetStringFromLovCodes_InactiveCode()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                .Returns(
                    new List<XLOVCode>
                    {
                        new XLOVCode
                        {
                            LOVName = lovName,
                            Code = 1,
                            Text = "first",
                            Value3 = "A",
                            IsActive = true,
                        },
                        new XLOVCode
                        {
                            LOVName = lovName,
                            Code = 2,
                            Text = "second",
                            Value3 = "A,B",
                            IsActive = true,
                        },
                        new XLOVCode
                        {
                            LOVName = lovName,
                            Code = 3,
                            Text = "third",
                            Value3 = "B,C",
                            IsActive = false,
                        },
                    });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var result = xLovService.GetStringFromLovCodes(lovName, "1,2,3");

            // Assert
            Assert.AreEqual("first, second, third", result);
        }

        [TestMethod]
        public void GetStringFromLovCodes_OneCode()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                    Text = "first",
                                    Value3 = "A",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                    Text = "second",
                                    Value3 = "A,B",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                    Text = "third",
                                    Value3 = "B,C",
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var result = xLovService.GetStringFromLovCodes(lovName, "1");

            // Assert
            Assert.AreEqual("first", result);
        }

        [TestMethod]
        public void GetStringFromLovCodes_TwoCodes()
        {
            // Arrange
            var xlovRepository = new Mock<XLovCodeRepository>();
            var lovName = "TestLov";
            xlovRepository.Setup(moq => moq.GetLovCodeByLovName(lovName, 1))
                            .Returns(new List<XLOVCode>
                            {
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 1,
                                    Text = "first",
                                    Value3 = "A",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 2,
                                    Text = "second",
                                    Value3 = "A,B",
                                },
                                new XLOVCode
                                {
                                    LOVName = lovName,
                                    Code = 3,
                                    Text = "third",
                                    Value3 = "B,C",
                                },
                            });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XLovCode, xlovRepository.Object);

            // Act
            var xLovService = Container.Resolve<XLovService>();
            var result = xLovService.GetStringFromLovCodes(lovName, "1,3");

            // Assert
            Assert.AreEqual("first, third", result);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            var xLovService = Container.Resolve<XLovService>();
            xLovService.ClearCache();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var xLovService = Container.Resolve<XLovService>();
            xLovService.ClearCache();
        }
    }
}