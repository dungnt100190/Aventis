using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Cache;
using Kiss.BL.KissSystem;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.System
{
    /// <summary>
    /// Unittestclass for XConfigService
    /// </summary>
    [TestClass]
    public class XConfigServiceTest : TransactionTestBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<XConfig> _testXConfigEntries = new List<XConfig>();
        private readonly List<XLOVCode> _testXLovCodeEntries = new List<XLOVCode>();
        private readonly List<XLOV> _testXLovEntries = new List<XLOV>();
        private readonly XConfigService _xConfigService = Container.Resolve<XConfigService>();

        private const string ABSCHLUSSGRUND_LOV_NAME = "AbschlussGrund";
        private const string CLASSNAME = "XConfigServiceTest";

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            ClassInitialize();
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            SetupTestConfigValues(unitOfWork);
            SetupTestLovValues(unitOfWork);
            CacheManager.Instance.ClearCache();
        }

        [ClassCleanup]
        public static new void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void GetConfigValueBitTest()
        {
            string keyPath = CLASSNAME + @"\TestBit";
            var xConfig = GetXConfigByKeyPath(keyPath);
            var configValue = _xConfigService.GetConfigValue<bool>(keyPath);
            Assert.AreEqual(xConfig.ValueBit, configValue);
        }

        [TestMethod]
        public void GetConfigValueCsvIntTest()
        {
            string keyPath = CLASSNAME + @"\TestCsv\Int";
            var xConfig = GetXConfigByKeyPath(keyPath);
            var configValue = _xConfigService.GetConfigValueSplitted<int>(keyPath);
            string csvValue = xConfig.ValueVarchar;
            string[] splittedValues = csvValue.Split(',');
            Assert.AreEqual(splittedValues.Count(), configValue.Count);
            for (int i = 0; i <= 2; i++)
            {
                Assert.AreEqual(Convert.ToInt32(splittedValues[i]), configValue[i]);
            }
        }

        [TestMethod]
        public void GetConfigValueCsvStringTest()
        {
            string keyPath = CLASSNAME + @"\TestCsv\String";
            var xConfig = GetXConfigByKeyPath(keyPath);
            var configValue = _xConfigService.GetConfigValueSplitted<string>(keyPath);
            string csvValue = xConfig.ValueVarchar;
            string[] splittedValues = csvValue.Split(',');
            Assert.AreEqual(splittedValues.Count(), configValue.Count);
            for (int i = 0; i <= 2; i++)
            {
                Assert.AreEqual(splittedValues[i], configValue[i]);
            }
        }

        [TestMethod]
        public void GetConfigValueDateTimeTest()
        {
            string keyPath = CLASSNAME + @"\TestDateTime";
            var xConfig = GetXConfigByKeyPath(keyPath);
            var configValue = _xConfigService.GetConfigValue<DateTime>(keyPath);
            Assert.AreEqual(xConfig.ValueDateTime.Value.ToString(CultureInfo.InvariantCulture), configValue.ToString(CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void GetConfigValueDecimalTest()
        {
            string keyPath = CLASSNAME + @"\TestDecimal";
            var xConfig = GetXConfigByKeyPath(keyPath);
            var configValue = _xConfigService.GetConfigValue<decimal>(keyPath);
            Assert.AreEqual(xConfig.ValueDecimal, configValue);
        }

        [TestMethod]
        public void GetConfigValueIntTest()
        {
            string keyPath = CLASSNAME + @"\TestInt";
            var xConfig = GetXConfigByKeyPath(keyPath);
            var configValue = _xConfigService.GetConfigValue<int>(keyPath);
            Assert.AreEqual(xConfig.ValueInt, configValue);
        }

        [TestMethod]
        public void GetConfigValueLovCodeTest()
        {
            string keyPath = CLASSNAME + @"\TestLovname";
            var xConfig = GetXConfigByKeyPath(keyPath);
            var configValue = _xConfigService.GetConfigValueSplitted<XLOVCode>(keyPath);
            string csvValue = xConfig.ValueVarchar;
            string[] splittedValues = csvValue.Split(',');
            Assert.AreEqual(splittedValues.Count(), configValue.Count);
            for (int i = 0; i <= 2; i++)
            {
                Assert.AreEqual(Convert.ToInt32(splittedValues[i]), configValue[i].Code);
            }
        }

        [TestMethod]
        public void GetConfigValueMoneyTest()
        {
            string keyPath = CLASSNAME + @"\TestMoney";
            var xConfig = GetXConfigByKeyPath(keyPath);
            var configValue = _xConfigService.GetConfigValue<decimal>(keyPath);
            Assert.AreEqual(xConfig.ValueMoney, configValue);
        }

        [TestMethod]
        public void GetConfigValueStringTest()
        {
            string keyPath = CLASSNAME + @"\TestString";
            var xConfig = GetXConfigByKeyPath(keyPath);
            var configValue = _xConfigService.GetConfigValue<string>(keyPath);
            Assert.AreEqual(xConfig.ValueVarchar, configValue);

            keyPath = CLASSNAME + @"\TestTree\Leaf1";
            configValue = _xConfigService.GetConfigValue<string>(keyPath);
            Assert.AreEqual("Leaf1 New", configValue);
            configValue = _xConfigService.GetConfigValue(keyPath, new DateTime(2010, 1, 1), "Default String Value");
            Assert.AreEqual("Leaf1 Old", configValue);
            configValue = _xConfigService.GetConfigValue(keyPath, new DateTime(2008, 1, 1), "Default String Value");
            Assert.AreEqual("Leaf1 Old Old", configValue);
            configValue = _xConfigService.GetConfigValue(keyPath, new DateTime(2007, 1, 1), "Default String Value");
            Assert.AreEqual("Default String Value", configValue);
        }

        [TestMethod]
        public void GetConfigValue_WithoutDefaultString_TestOk()
        {
            string keyPath = CLASSNAME + @"\TestString";
            var xConfig = GetXConfigByKeyPath(keyPath);
            var configValue = _xConfigService.GetConfigValue<string>(keyPath);
            Assert.AreEqual(xConfig.ValueVarchar, configValue);

            keyPath = CLASSNAME + @"\TestTree\Leaf1";
            configValue = _xConfigService.GetConfigValue<string>(keyPath);
            Assert.AreEqual("Leaf1 New", configValue);
            configValue = _xConfigService.GetConfigValue<string>(keyPath, new DateTime(2010, 1, 1));
            Assert.AreEqual("Leaf1 Old", configValue);
            configValue = _xConfigService.GetConfigValue<string>(keyPath, new DateTime(2008, 1, 1));
            Assert.AreEqual("Leaf1 Old Old", configValue);
            configValue = _xConfigService.GetConfigValue<string>(keyPath, new DateTime(2007, 1, 1));
            Assert.IsNull(configValue);
        }

        [TestMethod]
        public void GetConfigValuesTest()
        {
            string keyPath = CLASSNAME + @"\TestTree";
            var configValue = _xConfigService.GetConfigValues<string>(keyPath);
            Assert.AreEqual(2, configValue.Count);
            Assert.AreEqual("Leaf1 New", configValue["Leaf1"]);
            Assert.AreEqual("Leaf2", configValue["Leaf2"]);
        }

        #endregion

        #region Methods

        #region Private Methods

        private XConfig GetXConfigByKeyPath(string keyPath)
        {
            var query = from c in _testXConfigEntries
                        where c.KeyPath.Equals(keyPath)
                        select c;
            return query.First();
        }

        private void SetupTestConfigValues(IUnitOfWork unitOfWork)
        {
            IRepository<XConfig> repositoryXConfig = UnitOfWork.GetRepository<XConfig>(unitOfWork);
            // VarcharTest
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2010, 1, 1),
                Description = "XConfigServiceTest - String",
                KeyPath = CLASSNAME + @"\TestString",
                OriginalValueVarchar = "Hello UnitTest",
                ValueVarchar = "Hello UnitTest",
                ValueCode = 1 // Varchar
            });
            // Int Test
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2010, 1, 1),
                Description = "XConfigServiceTest - Int",
                KeyPath = CLASSNAME + @"\TestInt",
                OriginalValueInt = 999,
                ValueInt = 999,
                ValueCode = 2 // Int
            });
            // Decimal Test
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2010, 1, 1),
                Description = "XConfigServiceTest - Decimal",
                KeyPath = CLASSNAME + @"\TestDecimal",
                OriginalValueDecimal = 300.25m,
                ValueDecimal = 300.25m,
                ValueCode = 3 // decimal
            });
            // Money Test
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2010, 1, 1),
                Description = "XConfigServiceTest - Money",
                KeyPath = CLASSNAME + @"\TestMoney",
                OriginalValueMoney = 400.25m,
                ValueMoney = 400.25m,
                ValueCode = 4 // Money
            });
            // Bit Test
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2010, 1, 1),
                Description = "XConfigServiceTest - Bit",
                KeyPath = CLASSNAME + @"\TestBit",
                OriginalValueBit = true,
                ValueBit = true,
                ValueCode = 5 // bit
            });
            // DateTime Test
            DateTime dateNow = new DateTime(2012, 5, 5);
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2010, 1, 1),
                Description = "XConfigServiceTest - DateTime",
                KeyPath = CLASSNAME + @"\TestDateTime",
                OriginalValueDateTime = dateNow,
                ValueDateTime = dateNow,
                ValueCode = 6 // DateTime
            });
            // Comma seperated values
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2010, 1, 1),
                Description = "XConfigServiceTest - CommaSep1",
                KeyPath = CLASSNAME + @"\TestCsv\String",
                OriginalValueVarchar = "Joe,Steve,Yngwie",
                ValueVarchar = "Joe,Steve,Yngwie",
                ValueCode = 11 // Csv
            });
            // Comma seperated values
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2010, 1, 1),
                Description = "XConfigServiceTest - CommaSep2",
                KeyPath = CLASSNAME + @"\TestCsv\Int",
                OriginalValueVarchar = "1,2,3",
                ValueVarchar = "1,2,3",
                ValueCode = 11 // Varchar
            });
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2010, 1, 1),
                Description = "XConfigServiceTest - LovName",
                KeyPath = CLASSNAME + @"\TestLovname",
                OriginalValueVarchar = "1,2,3",
                ValueVarchar = "1,2,3",
                LOVName = "AbschlussGrund",
                ValueCode = 11 // Varchar
            });
            // Value Tree Varchar
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2013, 1, 1),
                Description = "XConfigServiceTest - LovName",
                KeyPath = CLASSNAME + @"\TestTree\Leaf1",
                OriginalValueVarchar = "Leaf1",
                ValueVarchar = "Leaf1 New",
                ValueCode = 1 // Varchar
            });
            // Value Tree Varchar
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2010, 1, 1),
                Description = "XConfigServiceTest - LovName",
                KeyPath = CLASSNAME + @"\TestTree\Leaf1",
                OriginalValueVarchar = "Leaf1",
                ValueVarchar = "Leaf1 Old",
                ValueCode = 1 // Varchar
            });
            // Value Tree Varchar
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2008, 1, 1),
                Description = "XConfigServiceTest - LovName",
                KeyPath = CLASSNAME + @"\TestTree\Leaf1",
                OriginalValueVarchar = "Leaf1",
                ValueVarchar = "Leaf1 Old Old",
                ValueCode = 1 // Varchar
            });
            // Value Tree Varchar
            _testXConfigEntries.Add(new XConfig
            {
                Created = DateTime.Now,
                Creator = "XConfigServiceTest",
                Modified = DateTime.Now,
                Modifier = "XConfigServiceTest",
                DatumVon = new DateTime(2013, 1, 1),
                Description = "XConfigServiceTest - LovName",
                KeyPath = CLASSNAME + @"\TestTree\Leaf2",
                OriginalValueVarchar = "Leaf2",
                ValueVarchar = "Leaf2",
                ValueCode = 1 // Varchar
            });
            _testXConfigEntries.ForEach(repositoryXConfig.ApplyChanges);
            unitOfWork.SaveChanges();
            _testXConfigEntries.ForEach(x => x.AcceptChanges());
        }

        private void SetupTestLovValues(IUnitOfWork unitOfWork)
        {
            IRepository<XLOV> repositoryLov = UnitOfWork.GetRepository<XLOV>(unitOfWork);

            if (repositoryLov.Any(x => x.LOVName == ABSCHLUSSGRUND_LOV_NAME))
            {
                return;
            }

            _testXLovEntries.Add(new XLOV
            {
                LOVName = ABSCHLUSSGRUND_LOV_NAME
            });
            _testXLovEntries.ForEach(repositoryLov.ApplyChanges);
            unitOfWork.SaveChanges();

            IRepository<XLOVCode> repositoryLovCode = UnitOfWork.GetRepository<XLOVCode>(unitOfWork);
            _testXLovCodeEntries.Add(new XLOVCode
            {
                LOVName = ABSCHLUSSGRUND_LOV_NAME,
                Code = 1,
                Value3 = "S",
                Text = "Integration Erwerbseinkommen"
            });
            _testXLovCodeEntries.Add(new XLOVCode
            {
                LOVName = ABSCHLUSSGRUND_LOV_NAME,
                Code = 2,
                Value3 = "S",
                Text = "Integration Erwerbseinkommen Rente"
            });
            _testXLovCodeEntries.Add(new XLOVCode
            {
                LOVName = ABSCHLUSSGRUND_LOV_NAME,
                Code = 3,
                Value3 = "S",
                Text = "Integration Ersatzeinkommen Taggelder"
            });
            _testXLovCodeEntries.ForEach(repositoryLovCode.ApplyChanges);
            unitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}