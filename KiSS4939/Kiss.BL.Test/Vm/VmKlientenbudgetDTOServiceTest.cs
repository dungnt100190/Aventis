using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test.Helpers;
using Kiss.BL.Vm;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Vm
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class VmKlientenbudgetDTOServiceTest : TransactionTestBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly BaGesundheitHelper _baGesundheitHelper = new BaGesundheitHelper();
        private readonly VmKlientenbudgetHelper _vmKlientenbudgetHelper = new VmKlientenbudgetHelper();
        private readonly VmPositionsartHelper _vmPositionsartHelper = new VmPositionsartHelper();

        #endregion

        #region Private Fields

        private List<VmKlientenbudget> _entities;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize();
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            // Create some temporary test objects and store the entities
            var unitOfWork = UnitOfWork.GetNew;

            _entities = new List<VmKlientenbudget>();
            // Budget 0
            _entities.Add(_vmKlientenbudgetHelper.Create(unitOfWork));

            // Budget 1 - mit Gesundheit KVG
            var budget = _vmKlientenbudgetHelper.Create(unitOfWork);
            var positionsart = _vmPositionsartHelper.Create(
                unitOfWork,
                LOVsGenerated.VmKategorie.FixeKosten,
                LOVsGenerated.VmPositionsartTyp.AusgKkPraemienKvg,
                "KK KVG");
            _vmKlientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "KVG");
            _baGesundheitHelper.Create(unitOfWork, budget.FaLeistung.BaPerson, 10, "KVG-Institution Test");

            _entities.Add(budget);

            // Budget 2 - mit Gesundheit VVG
            budget = _vmKlientenbudgetHelper.Create(unitOfWork);
            positionsart = _vmPositionsartHelper.Create(
                unitOfWork,
                LOVsGenerated.VmKategorie.FixeKosten,
                LOVsGenerated.VmPositionsartTyp.AusgKkPraemienVvg,
                "KK VVG");
            _vmKlientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "VVG");
            _baGesundheitHelper.Create(unitOfWork, budget.FaLeistung.BaPerson, null, null, (decimal?)20.5, "VVG-Institution Test");

            _entities.Add(budget);

            // Budget 3 - mit Vermögen
            budget = _vmKlientenbudgetHelper.Create(unitOfWork);
            positionsart = _vmPositionsartHelper.Create(
                unitOfWork,
                LOVsGenerated.VmKategorie.Vermoegen,
                LOVsGenerated.VmPositionsartTyp.Empty,
                "vermögen");
            _vmKlientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "Vermögen");
            positionsart = _vmPositionsartHelper.Create(
                unitOfWork,
                LOVsGenerated.VmKategorie.Vermoegen,
                LOVsGenerated.VmPositionsartTyp.Empty,
                "Wertschriften");
            _vmKlientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "Wertschriften", null, 200);
            positionsart = _vmPositionsartHelper.Create(
                unitOfWork,
                LOVsGenerated.VmKategorie.Vermoegen,
                LOVsGenerated.VmPositionsartTyp.VermElFreibetrag,
                "EL-Freibetrag");
            _vmKlientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "EL-Freibetrag", null, 300);
            positionsart = _vmPositionsartHelper.Create(
                unitOfWork,
                LOVsGenerated.VmKategorie.Vermoegen,
                LOVsGenerated.VmPositionsartTyp.VermElBerechnung,
                "EL-Berechnung");
            _vmKlientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "EL-Berechnung", null, 20);

            _entities.Add(budget);

            // Save UnitOfWork
            unitOfWork.SaveChanges();
        }

        [ClassCleanup]
        public new static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void GetByFaLeistungId_BudgetExists_ReturnBudget()
        {
            // Arrange
            var service = Container.Resolve<VmKlientenbudgetDTOService>();
            var entity = _entities[0];

            // Act
            var result = service.GetByFaLeistungId(null, entity.FaLeistungID);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsNotNull(result[0].VmKlientenbudget);
            Assert.AreEqual(entity.VmKlientenbudgetID, result[0].VmKlientenbudget.VmKlientenbudgetID);
        }

        #endregion
    }
}