using System;
using System.Transactions;

using KiSS.Common.BL;
using KiSS.Context;
using KiSS.KliBu.BL.DTO;

using Autofac;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS.KliBu.BL.Test.IntegrationTest
{
    [TestClass]
    public class BankenServiceTest
    {
        #region Fields

        #region Private Fields

        private static IContainer _container;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            AppContext.Init("server=sql2014.diartislocal.local\\sql2014;initial catalog=KiSS_BSS_Test;user id=kiss3;password=kiss2012;");
            _container = AppContext.Container;
        }

        [TestMethod,
        TestCategory("LongRunning")]
        public void Add_existing_bank_should_have_an_error_in_the_serviceResult()
        {
            using (BankenService service = _container.Resolve<BankenService>())
            {
                Bank bank = new Bank("Test", "100", 0, new DateTime(2009, 07, 29));

                Assert.IsNotNull(service.GetByClearingNrAndFilialNr(bank.ClearingNr, bank.FilialeNr), "Bank not exists");

                ServiceResult result = service.Add(bank);

                if (!result.Success && result.Errors.Count > 1)
                {
                    Assert.Fail("Validation errors");
                }
                else
                {
                    Assert.AreEqual(1, result.Errors.Count, "Bank exists");
                }
            }
        }

        [TestMethod,
                TestCategory("LongRunning")]
        public void Add_New_Bank()
        {
            string clearingNr = "1234";
            int filialeNr = 0;
            Bank bank = new Bank("Test", clearingNr, filialeNr, new DateTime(2009, 07, 29));

            using (BankenService service = _container.Resolve<BankenService>())
            {
                // check that the bank we'll add is really new
                if (service.GetByClearingNrAndFilialNr(clearingNr, filialeNr) != null)
                {
                    Assert.Fail("The bank already exists");
                }
                // add the bank
                service.Add(bank);
            }

            // delete the added bank for the next test
            using (BankenService service = _container.Resolve<BankenService>())
            {
                service.Delete(bank);
                // check that the bank we've added has been deleted
                if (service.GetByClearingNrAndFilialNr(clearingNr, filialeNr) != null)
                {
                    Assert.Fail("The bank still exists");
                }
            }
        }

        [TestMethod,
        TestCategory("LongRunning")]
        public void Get_not_existing_bank_should_return_null()
        {
            using (BankenService service = _container.Resolve<BankenService>())
            {
                Bank bank = service.GetByClearingNrAndFilialNr("1234", 1);
                Assert.IsNull(bank, "no bank found");
            }
        }

        [TestMethod,
        TestCategory("LongRunning")]
        public void Should_not_update_bank_after_rollback()
        {
            Bank bank;
            string origBankName;

            string tempBankeName = "temp";

            using (BankenService service = _container.Resolve<BankenService>())
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    bank = service.GetByClearingNrAndFilialNr("100", 0);  // nationalbank
                    origBankName = bank.Name;

                    bank.Name = tempBankeName;
                    service.Update(bank);
                    trans.Complete();
                }
            }
            using (BankenService service = _container.Resolve<BankenService>())
            {
                bank = service.GetByClearingNrAndFilialNr("100", 0);
                Assert.AreEqual(bank.Name, origBankName);
            }
        }

        [TestMethod,
        TestCategory("LongRunning")]
        public void Should_update_bank()
        {
            Bank bank;
            ServiceResult result;
            string origBankName;

            string tempBankeName = "temp";

            using (BankenService service = _container.Resolve<BankenService>())
            {
                bank = service.GetByClearingNrAndFilialNr("100", 0);  // nationalbank
                origBankName = bank.Name;

                bank.Name = tempBankeName;
                result = service.Update(bank);
            }

            if (result.Success) // read the updated value and update with the old value
            {
                // create a new service instance, to reset cacheing
                using (BankenService service = _container.Resolve<BankenService>())
                {
                    bank = service.GetByClearingNrAndFilialNr("100", 0);
                    Assert.AreEqual(bank.Name, tempBankeName);

                    bank.Name = origBankName;
                    result = service.Update(bank);

                    Assert.AreEqual(result.Success, true);
                }
            }
        }

        #endregion

        #region Other

        //}
        //[TestMethod,
        //TestCategory("LongRunning")]
        //public void When_two_service_instances_are_updateing_the_same_record_update_should_throw_an_OptimisticConcurrencyException()
        //{
        //    BankenService service1 = new BankenService();
        //    service = new BankenService();
        //    bank = service.GetByClearingNrAndFilialNr("100", 0);  // nationalbank
        //    Bank bank1 = service1.GetByClearingNrAndFilialNr("100", 0);  // nationalbank
        //    string origBankName = bank.Name;
        //    bank1.Name = "t1";
        //    bool success = service1.Update(bank1).Success;
        //    bank.Name = "t2";
        //    Assert.Throws<OptimisticConcurrencyException>(Update);
        //    if (success)    // reset the content
        //    {
        //        service = new BankenService();  // create a new service instance, to reset cacheing
        //        bank = bank = service.GetByClearingNrAndFilialNr("100", 0);
        //        bank.Name = origBankName;
        //        result = service.Update(bank);
        //        Assert.AreEqual(result.Success, true);
        //    }
        //}

        #endregion
    }
}