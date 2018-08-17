using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using KiSS.Common.BL;
using KiSS.Common.DA;
using KiSS.Context;
using KiSS.KliBu.BL.DTO;
using KiSS.KliBu.BL.Test.Mock;
using KiSS.KliBu.DA;
using KiSS.Lookup.DA;

using Autofac;
using Autofac.Builder;

namespace KiSS.KliBu.BL.Test.UnitTest
{
    [TestClass]
    public class BankabgleichMocked
    {
        #region Fields

        #region Private Fields

        private IContainer _container;
        private IRepository<BaBank> _mockBankRepository;
        private IRepository<XLog> _mockXLogRepository;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        public void Setup()
        {
            AppContext.InitNoDB(RegisterMock);
            _container = AppContext.Container;
        }

        [TestMethod,
        Description("Add a new bank during the update"),
        TestCategory("LongRunning")]
        public void Test_AddNewUpdateBank()
        {
            _mockBankRepository.Add(new BaBank { Name = "bank1", ClearingNr = "100", FilialeNr = 100, GueltigAb = DateTime.Today });

            using (BankenabgleichService svc = _container.Resolve<BankenabgleichService>())
            {
                List<Bank> inputBankList = new List<Bank>();
                inputBankList.Add(new Bank("bank to update", "123", 456, DateTime.Today) { Gruppe = 1, HauptsitzBCL = "123", BcArt = 1, Sprachcode = 1, Landcode = "CH" });

                List<Bank> updatedBankList;
                ServiceResult serviceResult = svc.Sync(inputBankList, out updatedBankList);

                Assert.IsTrue(serviceResult.Success);

                Assert.AreEqual(1, updatedBankList.Count, "Updated bank");
                Assert.AreEqual(2, _mockBankRepository.Count(), "Number of bank in the repository");

                BaBank bank = _mockBankRepository.Where(p => p.ClearingNr == "123" && p.FilialeNr == 456).Single();

                Assert.AreEqual("bank to update", bank.Name, "Updated bank name");
            }
        }

        [TestMethod,
        Description("Add two bank from the update list that have the same ClearingNr and FilialeNr"),
        TestCategory("LongRunning")]
        public void Test_AddTwoBankWithSameClId()
        {
            using (BankenabgleichService svc = _container.Resolve<BankenabgleichService>())
            {
                List<Bank> inputBankList = new List<Bank>();

                inputBankList.Add(new Bank("bank 1", "100", 100, DateTime.Today) { Gruppe = 1, HauptsitzBCL = "123", BcArt = 1, Sprachcode = 1, Landcode = "CH" });
                inputBankList.Add(new Bank("bank 2", "100", 100, DateTime.Today) { Gruppe = 1, HauptsitzBCL = "123", BcArt = 1, Sprachcode = 1, Landcode = "CH" });

                List<Bank> updatedBankList;
                ServiceResult serviceResult = svc.Sync(inputBankList, out updatedBankList);
                int numberOfBankUpdated = updatedBankList.Count;

                Assert.IsTrue(serviceResult.Success);

                Assert.AreEqual(2, numberOfBankUpdated, "Updated bank");
                Assert.AreEqual(1, _mockBankRepository.Count(), "Number of bank in the repository");

                BaBank bank = _mockBankRepository.Where(b => b.ClearingNr == "100" && b.FilialeNr == 100).Single();

                Assert.AreEqual("bank 2", bank.Name, "Second bank name");
            }
        }

        [TestMethod,
        Description("Repository and update list are empty"),
        TestCategory("LongRunning")]
        public void Test_AllIsEmpty()
        {
            using (BankenabgleichService svc = _container.Resolve<BankenabgleichService>())
            {
                List<Bank> inputBankList = new List<Bank>();

                List<Bank> updatedBankList;
                ServiceResult serviceResult = svc.Sync(inputBankList, out updatedBankList);
                int numberOfBankUpdated = updatedBankList.Count;

                Assert.IsTrue(serviceResult.Success);

                Assert.AreEqual(0, numberOfBankUpdated, "Updated bank");
                Assert.AreEqual(0, _mockBankRepository.Count(), "Number of bank in the repository");
            }
        }

        [TestMethod,
        Description("Two BaBank with the same ClearingNr and FilialeNr in the Repository"),
        TestCategory("LongRunning")]
        [ExpectedException(typeof(Common.AppException))]
        public void Test_TwoBankWithSameIDInRepository()
        {
            _mockBankRepository.Add(new BaBank { Name = "bank1", ClearingNr = "100", FilialeNr = 100, GueltigAb = DateTime.Today });
            _mockBankRepository.Add(new BaBank { Name = "bank2", ClearingNr = "100", FilialeNr = 100, GueltigAb = DateTime.Today });

            using (BankenabgleichService svc = _container.Resolve<BankenabgleichService>())
            {
                List<Bank> inputBankList = new List<Bank>();

                inputBankList.Add(new Bank("bank to update", "123", 46, DateTime.Today) { Gruppe = 1, HauptsitzBCL = "123", BcArt = 1, Sprachcode = 1, Landcode = "CH" });

                List<Bank> updatedBankList;
                ServiceResult serviceResult = svc.Sync(inputBankList, out updatedBankList);

                Assert.IsTrue(serviceResult.Success);
            }
        }

        [TestMethod,
        Description("Bank-update with ClearingNr and FilialeNr that is already in the Repository"),
        TestCategory("LongRunning")]
        public void Test_UpdateBank()
        {
            BaBank mockBank = new BaBank
            {
                Name = "bank1",
                ClearingNr = "100",
                FilialeNr = 100,
                GueltigAb = new DateTime(2000, 01, 01),
                HauptsitzBCL = "1",
                Ort = "Zurich",
                PCKontoNr = "001111112",
                PLZ = "1234",
                Strasse = "address"
            };
            _mockBankRepository.Add(mockBank);

            using (BankenabgleichService svc = _container.Resolve<BankenabgleichService>())
            {
                List<Bank> inputBankList = new List<Bank>();

                Bank updateBank = new Bank("bank to update", "100", 100, new DateTime(2009, 01, 01)) { Gruppe = 1, HauptsitzBCL = "123", BcArt = 1, Sprachcode = 1, Landcode = "CH" };
                updateBank.Strasse = "new address";
                updateBank.PLZ = "3018";
                updateBank.Ort = "Bern";
                updateBank.PCKontoNr = "80-1-1";

                inputBankList.Add(updateBank);

                List<Bank> updatedBankList;
                ServiceResult serviceResult = svc.Sync(inputBankList, out updatedBankList);
                int numberOfBankUpdated = updatedBankList.Count;

                Assert.IsTrue(serviceResult.Success);

                Assert.AreEqual(1, numberOfBankUpdated, "Updated bank");
                Assert.AreEqual(1, _mockBankRepository.Count(), "Number of bank in the repository");

                BaBank baBank = _mockBankRepository.Where(b => b.ClearingNr == "100" && b.FilialeNr == 100).Single();
                Assert.AreEqual("bank to update", baBank.Name, "Bank has a new name");
                Assert.AreEqual("new address", baBank.Strasse, "Bank has a new address");
                Assert.AreEqual("3018", baBank.PLZ, "Bank has a new zip code");
                Assert.AreEqual("Bern", baBank.Ort, "Bank has a new place");
                Assert.AreEqual("800000011", baBank.PCKontoNr, "Bank has a new Account");
                Assert.AreEqual(new DateTime(2009, 01, 01), baBank.GueltigAb, "Bank has a new valid from date");
            }
        }

        [TestMethod,
        Description("Bank-update with ClearingNr and FilialeNr that is already in the Repository"),
        TestCategory("LongRunning")]
        public void Test_UpdateBankName()
        {
            _mockBankRepository.Add(new BaBank { Name = "bank1", ClearingNr = "100", FilialeNr = 100, GueltigAb = DateTime.Today });
            _mockBankRepository.Add(new BaBank { Name = "bank2", ClearingNr = "200", FilialeNr = 200, GueltigAb = DateTime.Today });

            using (BankenabgleichService svc = _container.Resolve<BankenabgleichService>())
            {
                List<Bank> inputBankList = new List<Bank>();

                inputBankList.Add(new Bank("bank to update", "100", 100, DateTime.Today) { Gruppe = 1, HauptsitzBCL = "123", BcArt = 1, Sprachcode = 1, Landcode = "CH" });

                List<Bank> updatedBankList;
                ServiceResult serviceResult = svc.Sync(inputBankList, out updatedBankList);
                int numberOfBankUpdated = updatedBankList.Count;

                Assert.IsTrue(serviceResult.Success);

                Assert.AreEqual(1, numberOfBankUpdated, "Updated bank");
                Assert.AreEqual(2, _mockBankRepository.Count(), "Number of bank in the repository");

                BaBank baBank = _mockBankRepository.Where(b => b.ClearingNr == "100" && b.FilialeNr == 100).Single();
                Assert.AreEqual("bank to update", baBank.Name, "Bank has a new name");
            }
        }

        [TestMethod,
        Description("Bank-update with an invalid account number"),
        TestCategory("LongRunning")]
        public void Test_UpdateBankWithInvalidAccount()
        {
            BaBank mockBank = new BaBank
            {
                Name = "bank1",
                ClearingNr = "100",
                FilialeNr = 100,
                GueltigAb = new DateTime(2000, 01, 01),
                HauptsitzBCL = "1",
                Ort = "Zurich",
                PCKontoNr = "001111112",
                PLZ = "1234",
                Strasse = "address"
            };
            _mockBankRepository.Add(mockBank);
            BaBank mockBank2 = new BaBank
            {
                Name = "bank2",
                ClearingNr = "200",
                FilialeNr = 200,
                GueltigAb = new DateTime(2000, 01, 01),
                HauptsitzBCL = "1",
                Ort = "Zurich",
                PCKontoNr = "001111112",
                PLZ = "1234",
                Strasse = "address"
            };
            _mockBankRepository.Add(mockBank2);

            using (BankenabgleichService svc = _container.Resolve<BankenabgleichService>())
            {
                List<Bank> inputBankList = new List<Bank>();

                Bank updateBank = new Bank("bank to update", "100", 100, new DateTime(2009, 01, 01)) { Gruppe = 1, HauptsitzBCL = "123", BcArt = 1, Sprachcode = 1, Landcode = "CH" };
                updateBank.Strasse = "new address";
                updateBank.PLZ = "3018";
                updateBank.Ort = "Bern";
                updateBank.PCKontoNr = "80-1234567-1";

                inputBankList.Add(updateBank);

                Bank updateBank2 = new Bank("bank to update2", "200", 200, new DateTime(2009, 01, 01)) { Gruppe = 1, HauptsitzBCL = "123", BcArt = 1, Sprachcode = 1, Landcode = "CH" };
                updateBank2.Strasse = "new address";
                updateBank2.PLZ = "3018";
                updateBank2.Ort = "Bern";
                updateBank2.PCKontoNr = "80-1-1";

                inputBankList.Add(updateBank2);

                List<Bank> updatedBankList;
                ServiceResult serviceResult = svc.Sync(inputBankList, out updatedBankList);
                Assert.IsFalse(serviceResult.Success, "Has error");
            }
        }

        [TestMethod,
        Description("Empty bank list update"),
        TestCategory("LongRunning")]
        public void Test_UpdateEmptyBankList()
        {
            _mockBankRepository.Add(new BaBank { Name = "bank1", ClearingNr = "100", FilialeNr = 100, GueltigAb = DateTime.Today });
            _mockBankRepository.Add(new BaBank { Name = "bank2", ClearingNr = "200", FilialeNr = 200, GueltigAb = DateTime.Today });

            using (BankenabgleichService svc = _container.Resolve<BankenabgleichService>())
            {
                List<Bank> inputBankList = new List<Bank>();

                List<Bank> updatedBankList;
                ServiceResult serviceResult = svc.Sync(inputBankList, out updatedBankList);
                int numberOfBankUpdated = updatedBankList.Count;

                Assert.IsTrue(serviceResult.Success);

                Assert.AreEqual(0, numberOfBankUpdated, "Updated bank");
                Assert.AreEqual(2, _mockBankRepository.Count(), "Number of bank in the repository");
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Delegate function to register all mocked repositories
        /// </summary>
        /// <param name="builder">the builder on which to make the registration</param>
        private void RegisterMock(ContainerBuilder builder)
        {
            _mockBankRepository = new MockBankRepository();
            builder.Register(_mockBankRepository).As<IRepository<BaBank>>();

            builder.Register<MockUnitOfWork>().As<DA.IUnitOfWork>();

            _mockXLogRepository = new MockXLogRepository();
            builder.Register(_mockXLogRepository).As<IRepository<XLog>>();
        }

        #endregion

        #endregion
    }
}