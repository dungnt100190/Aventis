using System;
using System.Transactions;

using Kiss.BL.Ba;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BL.Test.Ba
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class BaZahlungswegSearchServiceTest
    {
        #region Fields

        private BaPersonHelper _helpPerson = new BaPersonHelper();
        private BaZahlungsweg _zahlweg = null;

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using (var transaction = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;
                var person = _helpPerson.Create(unitOfWork);

                var repository = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);

                _zahlweg = new BaZahlungsweg
                {
                    BaPersonID = person.BaPersonID,
                    DatumVon = DateTime.Now,
                    DatumBis = DateTime.Now.AddMonths(12),
                    IBANNummer = "CH5180971000003119189",
                    PostKontoNummer = "300221234"
                };

                repository.ApplyChanges(_zahlweg);
                unitOfWork.SaveChanges();

                transaction.Complete();
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (var transaction = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;
                var repository = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);

                _zahlweg.MarkAsDeleted();
                repository.ApplyChanges(_zahlweg);
                unitOfWork.SaveChanges();

                _helpPerson.Delete(unitOfWork);

                transaction.Complete();
            }
        }

        ////[TestMethod]
        ////public void SearchKreditor_BaPerson()
        ////{

        ////    var unitOfWork = UnitOfWork.GetNew;
        ////    if (!TestUtils.IsDbTest(unitOfWork))
        ////    {
        ////        return;
        ////    }

        ////    // Arrange
        ////    var service = Container.Resolve<BaZahlungswegSearchService>();

        ////    // Tests
        ////    // TODO : Test NOK: Adresse muss vorhanden sein
        ////    var result = service.SearchZahlungsweg(null, "Unit Test Nachname", 0);

        ////    //TODO: Dieser Test muss überarbeitet werden. Neu werden nur noch Institutionen berücksichtigt. 
        ////    //Assert.IsTrue(result.Count >= 1);
        ////}

        ////[TestMethod]
        ////public void SearchKreditor_Asterix()
        ////{

        ////    var unitOfWork = UnitOfWork.GetNew;
        ////    if (!TestUtils.IsDbTest(unitOfWork))
        ////    {
        ////        return;
        ////    }

        ////    // Arrange
        ////    var service = Container.Resolve<BaZahlungswegSearchService>();

        ////    // Tests mit *
        ////    var result = service.SearchZahlungsweg(null, "*", 0);
        ////    Assert.IsTrue(result.Count >= 1);
        ////}

        ////[TestMethod]
        ////public void SearchKreditor_Point()
        ////{
        ////    var unitOfWork = UnitOfWork.GetNew;
        ////    if (!TestUtils.IsDbTest(unitOfWork))
        ////    {
        ////        return;
        ////    }

        ////    // Arrange
        ////    var service = Container.Resolve<BaZahlungswegSearchService>();

        ////    // Tests mit .
        ////    var result = service.SearchZahlungsweg(null, ".", 0);
        ////    Assert.IsTrue(result.Count == 0);
        ////}


        #endregion
    }
}