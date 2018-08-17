using System;
using System.Collections.Generic;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test.Helpers;
using Kiss.BL.Vm;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Vm
{
    /// <summary>
    /// Tests the VmPositionService service.
    /// </summary>
    [TestClass]
    public class VmPositionServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly BaGesundheitHelper _baGesundheitHelper = new BaGesundheitHelper();
        private readonly FbBuchungHelper _fbBuchungHelper = new FbBuchungHelper();
        private readonly FbKontoHelper _fbKontoHelper = new FbKontoHelper();
        private readonly FbPeriodeHelper _fbPeriodeHelper = new FbPeriodeHelper();
        private readonly VmKlientenbudgetHelper _klientenbudgetHelper = new VmKlientenbudgetHelper();
        private readonly VmPositionsartHelper _positionsartHelper = new VmPositionsartHelper();
        private readonly VmKlientenbudgetHelper _vmKlientenbudgetHelper = new VmKlientenbudgetHelper();
        private readonly VmPositionsartHelper _vmPositionsartHelper = new VmPositionsartHelper();

        #endregion

        #region Private Fields

        private List<VmKlientenbudget> _budgets;
        private List<VmPosition> _entities;

        #endregion

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
                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;
                var vmKlientenbudget = _klientenbudgetHelper.Create(unitOfWork);
                var vmPositionsart = _positionsartHelper.Create(unitOfWork);
                var repository = UnitOfWork.GetRepository<VmPosition>(unitOfWork);

                _entities = new List<VmPosition>
                {
                    new VmPosition
                    {
                        VmKlientenbudget = vmKlientenbudget,
                        VmPositionsart = vmPositionsart,
                        Name = "Position",
                        Creator = "UnitTest",
                        Created = DateTime.Now,
                        Modifier="UnitTest",
                        Modified = DateTime.Now
                    }
                };

                _entities.ForEach(repository.ApplyChanges);
                unitOfWork.SaveChanges();
                _entities.ForEach(x => x.AcceptChanges());

                _budgets = new List<VmKlientenbudget>();

                // Budget 0 - mit Gesundheit KVG
                var budget = _vmKlientenbudgetHelper.Create(unitOfWork);
                var positionsart = _vmPositionsartHelper.Create(
                    unitOfWork,
                    LOVsGenerated.VmKategorie.FixeKosten,
                    LOVsGenerated.VmPositionsartTyp.AusgKkPraemienKvg,
                    "KK KVG");
                _vmKlientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "KVG");
                _baGesundheitHelper.Create(unitOfWork, budget.FaLeistung.BaPerson, 10, "KVG-Institution Test");

                _budgets.Add(budget);

                // Budget 1 - mit Gesundheit VVG
                budget = _vmKlientenbudgetHelper.Create(unitOfWork);
                positionsart = _vmPositionsartHelper.Create(
                    unitOfWork,
                    LOVsGenerated.VmKategorie.FixeKosten,
                    LOVsGenerated.VmPositionsartTyp.AusgKkPraemienVvg,
                    "KK VVG");
                _vmKlientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "VVG");
                _baGesundheitHelper.Create(unitOfWork, budget.FaLeistung.BaPerson, null, null, (decimal?)20.5, "VVG-Institution Test");

                _budgets.Add(budget);

                // Budget 2 - mit Betriebskonto, ohne Fibu-Periode
                budget = _vmKlientenbudgetHelper.Create(unitOfWork);
                positionsart = _vmPositionsartHelper.Create(
                    unitOfWork,
                    LOVsGenerated.VmKategorie.Vermoegen,
                    LOVsGenerated.VmPositionsartTyp.VermBetriebskonto,
                    "betriebskonto");
                _vmKlientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "Betriebskonto");

                _budgets.Add(budget);

                // Budget 3 - mit Betriebskonto und Kasse + PC, mit Fibu-Periode ohne Buchung
                budget = _vmKlientenbudgetHelper.Create(unitOfWork);
                _vmKlientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "Betriebskonto");
                positionsart = _vmPositionsartHelper.Create(
                    unitOfWork,
                    LOVsGenerated.VmKategorie.Vermoegen,
                    LOVsGenerated.VmPositionsartTyp.VermKassePc,
                    "Kasse + PC");
                _vmKlientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "Kasse + PC");
                var fbPeriode = _fbPeriodeHelper.Create(unitOfWork, budget.FaLeistung.BaPerson);
                var fbKonto1 = _fbKontoHelper.Create(unitOfWork, fbPeriode, 2000);
                var fbKonto2 = _fbKontoHelper.Create(unitOfWork, fbPeriode, 0, 3510, "Steuern", "");
                _fbBuchungHelper.Create(unitOfWork, fbPeriode, 500, fbKonto1.KontoNr, fbKonto2.KontoNr);
                _fbBuchungHelper.Create(unitOfWork, fbPeriode, 25, fbKonto2.KontoNr, fbKonto1.KontoNr);

                _budgets.Add(budget);

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
                var repository = UnitOfWork.GetRepository<VmPosition>(unitOfWork);

                // Delete the temporary test objects
                _entities.ForEach(x => x.MarkAsDeleted());
                _entities.ForEach(repository.ApplyChanges);

                unitOfWork.SaveChanges();

                _klientenbudgetHelper.Delete(unitOfWork);
                _positionsartHelper.Delete(unitOfWork);

                transaction.Complete();
            }
        }

        [TestMethod]
        public void ImportData_BetriebskontoPositionMitFbPeriodeOhneBuchung_ImportIsOk()
        {
            // Arrange
            var service = Container.Resolve<VmPositionService>();
            var budget = _budgets[3];
            var position = budget.VmPosition[0];

            // Act
            var result = service.ImportData(null, budget, position);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(0, position.Saldo);
            Assert.AreEqual(DateTime.Today, position.DatumSaldoPer);
            Assert.IsTrue(position.IstImportiert);
        }

        [TestMethod]
        public void ImportData_BetriebskontoPositionOhneFbPeriode_ImportIsOk()
        {
            // Arrange
            var service = Container.Resolve<VmPositionService>();
            var budget = _budgets[2];
            var position = budget.VmPosition[0];

            // Act
            var result = service.ImportData(null, budget, position);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(null, position.Saldo);
            Assert.AreEqual(DateTime.Today, position.DatumSaldoPer);
            Assert.IsTrue(position.IstImportiert);
        }

        [TestMethod]
        public void ImportData_KassePcPositionMitFbPeriodeUndBuchung_ImportIsOk()
        {
            // Arrange
            var service = Container.Resolve<VmPositionService>();
            var budget = _budgets[3];
            var position = budget.VmPosition[1];

            // Act
            var result = service.ImportData(null, budget, position);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(2000 + 500 - 25, position.Saldo);
            Assert.AreEqual(DateTime.Today, position.DatumSaldoPer);
            Assert.IsTrue(position.IstImportiert);
        }

        [TestMethod]
        public void ImportData_KvgPosition_ImportIsOk()
        {
            // Arrange
            var service = Container.Resolve<VmPositionService>();
            var budget = _budgets[0];
            var position = budget.VmPosition[0];
            var gesundheit = budget.FaLeistung.BaPerson.BaGesundheit[0];

            // Act
            var result = service.ImportData(null, budget, position);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(gesundheit.KVGPraemie, position.BetragMonatlich);
            Assert.AreEqual(gesundheit.BaInstitution_Kvg.Name, position.Bemerkung);
            Assert.IsTrue(position.IstImportiert);
        }

        [TestMethod]
        public void ImportData_VvgPosition_ImportIsOk()
        {
            // Arrange
            var service = Container.Resolve<VmPositionService>();
            var budget = _budgets[1];
            var position = budget.VmPosition[0];
            var gesundheit = budget.FaLeistung.BaPerson.BaGesundheit[0];

            // Act
            var result = service.ImportData(null, budget, position);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(gesundheit.VVGPraemie, position.BetragMonatlich);
            Assert.AreEqual(gesundheit.BaInstitution_Vvg.Name, position.Bemerkung);
            Assert.IsTrue(position.IstImportiert);
        }

        [TestMethod]
        public void Test_GetByVmKlientenbudgetId()
        {
            // Arrange
            var service = Container.Resolve<VmPositionService>();
            var entity = _entities[0];

            // Act
            var result = service.GetByVmKlientenbudgetId(null, entity.VmKlientenbudgetID);

            // Assert
            Assert.IsTrue(result.Count > 0);
        }

        #endregion
    }
}