using System;

using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DataAccess.Sys;
using Kiss.DbContext;
using Kiss.Infrastructure.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kiss.BusinessLogic.Test.System
{
    /// <summary>
    /// Unittestclass for XConfigService
    /// </summary>
    [TestClass]
    public class XConfigServiceTest
    {
        #region Test Methods

        [TestMethod]
        public void GetConfigValueBitNotInitializedTest()
        {
            // Arrange
            const string keyPath = @"Test\DateTimeNode";
            var defaultValue = new DateTime(1991, 5, 10);

            var configRepository = new Mock<XConfigRepository>();
            configRepository.Setup(moq => moq.GetAllEntities())
                            .Returns(new XConfig[] { });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XConfig, configRepository.Object);

            var configNode = new ConfigNode<DateTime?>(keyPath, defaultValue);

            // Act
            // no value configured, service should return the default value of the node
            var configService = Container.Resolve<XConfigService>();
            configService.ReloadCache();
            var configValue = configService.GetConfigValue(configNode);

            // Assert
            Assert.AreEqual(defaultValue, configValue);
        }

        [TestMethod]
        public void GetConfigValueBitTest()
        {
            // Arrange
            const string keyPathBit = @"Test\BitNode";

            var configRepository = new Mock<XConfigRepository>();
            configRepository.Setup(moq => moq.GetAllEntities())
                            .Returns(new[] { new XConfig
                                                 {
                                                     KeyPath = keyPathBit,
                                                     DatumVon = null,
                                                     ValueBit = true,
                                                     ValueCode = (int)ValueCode.Bit
                                                 } });

            (new UnitOfWorkMock()).RegisterRepository(uow => uow.XConfig, configRepository.Object);

            var configNodeBit = new ConfigNode<bool>(keyPathBit);

            // Act
            var configService = Container.Resolve<XConfigService>();
            configService.ReloadCache();
            var configValue = configService.GetConfigValue(configNodeBit);

            // Assert
            Assert.IsTrue(configValue);
        }

        //[TestMethod]
        //public void GetConfigValueCsvIntTest()
        //{
        //    string keyPath = CLASSNAME + @"\TestCsv\Int";
        //    var xConfig = GetXConfigByKeyPath(keyPath);
        //    var configValue = _xConfigService.GetConfigValueSplitted<int>(keyPath);
        //    string csvValue = xConfig.ValueVarchar;
        //    string[] splittedValues = csvValue.Split(',');
        //    Assert.AreEqual(splittedValues.Count(), configValue.Count);
        //    for (int i = 0; i <= 2; i++)
        //    {
        //        Assert.AreEqual(Convert.ToInt32(splittedValues[i]), configValue[i]);
        //    }
        //}

        //[TestMethod]
        //public void GetConfigValueCsvStringTest()
        //{
        //    string keyPath = CLASSNAME + @"\TestCsv\String";
        //    var xConfig = GetXConfigByKeyPath(keyPath);
        //    var configValue = _xConfigService.GetConfigValueSplitted<string>(keyPath);
        //    string csvValue = xConfig.ValueVarchar;
        //    string[] splittedValues = csvValue.Split(',');
        //    Assert.AreEqual(splittedValues.Count(), configValue.Count);
        //    for (int i = 0; i <= 2; i++)
        //    {
        //        Assert.AreEqual(splittedValues[i], configValue[i]);
        //    }
        //}

        [TestMethod]
        public void GetConfigValueDateTimeNotInitializedNoConfiguredDefaultTest()
        {
            // Arrange
            const string keyPath = @"Test\DateTimeNode";

            var configRepository = new Mock<XConfigRepository>();
            configRepository.Setup(moq => moq.GetAllEntities())
                            .Returns(new XConfig[] { });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XConfig, configRepository.Object);

            var configNode = new ConfigNode<DateTime>(keyPath);

            // Act
            // no value configured, service should return the default value of the type of the node
            var configService = Container.Resolve<XConfigService>();
            configService.ReloadCache();
            var configValue = configService.GetConfigValue(configNode);

            // Assert
            Assert.AreEqual(DateTime.MinValue, configValue);
        }

        [TestMethod]
        public void GetConfigValueDateTimeTest()
        {
            // Arrange
            const string keyPath = @"Test\DateTimeNode";
            var configuredValue = new DateTime(2017, 5, 10);

            var configRepository = new Mock<XConfigRepository>();
            configRepository.Setup(moq => moq.GetAllEntities())
                            .Returns(new[] {
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today.AddDays(-10),
                                                     ValueDateTime = configuredValue.AddYears(-100),
                                                     ValueCode = (int)ValueCode.DateTime
                                                 },
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today,
                                                     ValueDateTime = configuredValue,
                                                     ValueCode = (int)ValueCode.DateTime
                                                 },
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today.AddDays(10),
                                                     ValueDateTime = configuredValue.AddYears(100),
                                                     ValueCode = (int)ValueCode.DateTime
                                                 }
                                           });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XConfig, configRepository.Object);

            var configNode = new ConfigNode<DateTime>(keyPath);

            // Act
            var configService = Container.Resolve<XConfigService>();
            configService.ReloadCache();
            var configValue = configService.GetConfigValue(configNode);

            // Assert
            Assert.AreEqual(configuredValue, configValue);
        }

        [TestMethod]
        public void GetConfigValueDecimalTest()
        {
            // Arrange
            const string keyPath = @"Test\DecimalNode";
            const decimal configuredValue = 37.5m;

            var configRepository = new Mock<XConfigRepository>();
            configRepository.Setup(moq => moq.GetAllEntities())
                            .Returns(new[] {
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today.AddDays(-10),
                                                     ValueDecimal = configuredValue - 5.78m,
                                                     ValueCode = (int)ValueCode.Decimal
                                                 },
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today,
                                                     ValueDecimal = configuredValue,
                                                     ValueCode = (int)ValueCode.Decimal
                                                 },
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today.AddDays(10),
                                                     ValueDecimal = configuredValue + 9.3m,
                                                     ValueCode = (int)ValueCode.Decimal
                                                 }
                                           });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XConfig, configRepository.Object);

            var configNode = new ConfigNode<decimal>(keyPath);

            // Act
            var configService = Container.Resolve<XConfigService>();
            configService.ReloadCache();
            var readConfigValue = configService.GetConfigValue(configNode);

            // Assert
            Assert.AreEqual(configuredValue, readConfigValue);
        }

        [TestMethod]
        public void GetConfigValueIntTest()
        {
            // Arrange
            const string keyPath = @"Test\IntNode";
            const int configuredValue = 42;

            var configRepository = new Mock<XConfigRepository>();
            configRepository.Setup(moq => moq.GetAllEntities())
                            .Returns(new[] {
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today.AddYears(-10),
                                                     ValueInt = configuredValue -35,
                                                     ValueCode = (int)ValueCode.Int
                                                 },
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today,
                                                     ValueInt = configuredValue,
                                                     ValueCode = (int)ValueCode.Int
                                                 },
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today.AddYears(10),
                                                     ValueInt = configuredValue - 37,
                                                     ValueCode = (int)ValueCode.Int
                                                 }
                                           });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XConfig, configRepository.Object);

            var configNode = new ConfigNode<int>(keyPath);

            // Act
            var configService = Container.Resolve<XConfigService>();
            configService.ReloadCache();
            var readConfigValue = configService.GetConfigValue(configNode);

            // Assert
            Assert.AreEqual(configuredValue, readConfigValue);
        }

        [TestMethod]
        public void GetConfigValueLovCodeTest()
        {
            // Arrange
            const string keyPath = @"Test\IntLovNode";
            const int code = 7;
            const string lovName = "TestLov";

            var lovCodeRepository = new Mock<XLovCodeRepository>();
            lovCodeRepository.Setup(moq => moq.GetLovCodeByLovName(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(new[]
                {
                    new XLOVCode
                    {
                        Code = code,
                        LOVName = lovName
                    }
                });

            var configRepository = new Mock<XConfigRepository>();
            configRepository.Setup(moq => moq.GetAllEntities())
                            .Returns(new[] { new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = null,
                                                     ValueInt = code,
                                                     ValueCode = (int)ValueCode.Int,
                                                     LOVName = lovName
                                                 } });

            var uow = new UnitOfWorkMock();
            uow.RegisterRepository(u => u.XConfig, configRepository.Object);
            uow.RegisterRepository(u => u.XLovCode, lovCodeRepository.Object);

            var configNode = new ConfigNode<XLOVCode>(keyPath);

            // Act
            var configService = Container.Resolve<XConfigService>();
            configService.ReloadCache();
            var configValue = configService.GetConfigValue(configNode);

            // Assert
            Assert.AreEqual(code, configValue.Code);
            Assert.AreEqual(lovName, configValue.LOVName);
        }

        //[TestMethod]
        //public void GetConfigValueLovCodeTest()
        //{
        //    string keyPath = CLASSNAME + @"\TestLovname";
        //    var xConfig = GetXConfigByKeyPath(keyPath);
        //    var configValue = _xConfigService.GetConfigValueSplitted<XLOVCode>(keyPath);
        //    string csvValue = xConfig.ValueVarchar;
        //    string[] splittedValues = csvValue.Split(',');
        //    Assert.AreEqual(splittedValues.Count(), configValue.Count);
        //    for (int i = 0; i <= 2; i++)
        //    {
        //        Assert.AreEqual(Convert.ToInt32(splittedValues[i]), configValue[i].Code);
        //    }
        //}

        [TestMethod]
        public void GetConfigValueMoneyTest()
        {
            // Arrange
            const string keyPath = @"Test\MoneyNode";
            const decimal configuredValue = -32.05m;

            var configRepository = new Mock<XConfigRepository>();
            configRepository.Setup(moq => moq.GetAllEntities())
                            .Returns(new[] {
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today.AddYears(-10),
                                                     ValueMoney = configuredValue -35.5m,
                                                     ValueCode = (int)ValueCode.Money
                                                 },
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today,
                                                     ValueMoney = configuredValue,
                                                     ValueCode = (int)ValueCode.Money
                                                 },
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today.AddYears(10),
                                                     ValueMoney = configuredValue - 42.95m,
                                                     ValueCode = (int)ValueCode.Money
                                                 }
                                           });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XConfig, configRepository.Object);

            var configNode = new ConfigNode<decimal>(keyPath);

            // Act
            var configService = Container.Resolve<XConfigService>();
            configService.ReloadCache();
            var readConfigValue = configService.GetConfigValue(configNode);

            // Assert
            Assert.AreEqual(configuredValue, readConfigValue);
        }

        [TestMethod]
        public void GetConfigValueVarcharTest()
        {
            // Arrange
            const string keyPath = @"Test\VarcharNode";
            const string configuredValue = "Hello mister testrunner";

            var configRepository = new Mock<XConfigRepository>();
            configRepository.Setup(moq => moq.GetAllEntities())
                            .Returns(new[] {
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today.AddYears(-10),
                                                     ValueVarchar = configuredValue + " before",
                                                     ValueCode = (int)ValueCode.Varchar
                                                 },
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today,
                                                     ValueVarchar = configuredValue,
                                                     ValueCode = (int)ValueCode.Varchar
                                                 },
                                             new XConfig
                                                 {
                                                     KeyPath = keyPath,
                                                     DatumVon = DateTime.Today.AddYears(10),
                                                     ValueVarchar = configuredValue + "after",
                                                     ValueCode = (int)ValueCode.Varchar
                                                 }
                                           });

            (new UnitOfWorkMock()).RegisterRepository(moq => moq.XConfig, configRepository.Object);

            var configNode = new ConfigNode<string>(keyPath);

            // Act
            var configService = Container.Resolve<XConfigService>();
            configService.ReloadCache();
            var readConfigValue = configService.GetConfigValue(configNode);

            // Assert
            Assert.AreEqual(configuredValue, readConfigValue);
        }

        //[TestMethod]
        //public void GetConfigValuesTest()
        //{
        //    string keyPath = CLASSNAME + @"\TestTree";
        //    var configValue = _xConfigService.GetConfigValues<string>(keyPath);
        //    Assert.AreEqual(2, configValue.Count);
        //    Assert.AreEqual("Leaf1 New", configValue["Leaf1"]);
        //    Assert.AreEqual("Leaf2", configValue["Leaf2"]);
        //}

        #endregion
    }
}