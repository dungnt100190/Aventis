using System;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.Database;
using Kiss.Model;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the WshGrundbudgetPositionKreditorService service.
    /// </summary>
    [TestClass]
    public class WshGrundbudgetPositionKreditorServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshGrundbudgetPositionHelper _grundbudgetPositionHelper = new WshGrundbudgetPositionHelper();

        #endregion

        #region Private Fields

        private WshGrundbudgetPosition _position;
        private BaZahlungsweg _zahlungsweg;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize(DatabaseTestUtil.CONNECTION_STRING_NAME_KISS5);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using (var transaction = new TransactionScope())
            {
                //Leistung erstellen
                var unitOfWork = UnitOfWork.GetNew;
                _position = _grundbudgetPositionHelper.Create(unitOfWork);

                //BaZahlungsweg ersellen.
                _zahlungsweg = new BaZahlungsweg
                {
                    BaPersonID = _position.FaLeistung.BaPerson.BaPersonID,
                    DatumVon = DateTime.Today
                };
                var repositoryZahlungsweg = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);

                repositoryZahlungsweg.ApplyChanges(_zahlungsweg);
                unitOfWork.SaveChanges();
                _zahlungsweg.AcceptChanges();

                transaction.Complete();
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (var transaction = new TransactionScope())
            {
                //Erstellte WshGrundBudgetPositionKreditoren Löschen
                var unitOfWork = UnitOfWork.GetNew;
                IRepository<WshGrundbudgetPositionKreditor> repository = UnitOfWork.GetRepository<WshGrundbudgetPositionKreditor>(unitOfWork);
                var query = from x in repository
                            where x.WshGrundbudgetPositionID == _position.WshGrundbudgetPositionID
                            select x;
                var list = query.ToList();
                list.ForEach(x => x.MarkAsDeleted());
                list.ForEach(repository.ApplyChanges);
                unitOfWork.SaveChanges();

                //Zahlungsweg löschen.
                var repositoryZahlungsweg = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);
                _zahlungsweg.MarkAsDeleted();
                repositoryZahlungsweg.ApplyChanges(_zahlungsweg);
                unitOfWork.SaveChanges();

                //Grundbudgetposition löschen.
                _grundbudgetPositionHelper.Delete(unitOfWork);

                transaction.Complete();
            }
        }

        #endregion
    }
}