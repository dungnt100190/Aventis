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
    public class VmPositionDTOServiceTest : TransactionTestBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly VmKlientenbudgetHelper _vmKlientenbudgetHelper = new VmKlientenbudgetHelper();
        private readonly VmPositionsartHelper _vmPositionsartHelper = new VmPositionsartHelper();

        #endregion

        #region Private Fields

        private List<VmKlientenbudget> _budgetEntities;

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

            _budgetEntities = new List<VmKlientenbudget>();
            // Budget 0 - mit Vermögen
            var budget = _vmKlientenbudgetHelper.Create(unitOfWork);
            var positionsart = _vmPositionsartHelper.Create(
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

            _budgetEntities.Add(budget);

            // Save UnitOfWork
            unitOfWork.SaveChanges();
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
        public void UpdateBetragSaldoOtherPositions_VermoegenElFreibetragZuGross_UpdateSaldoElBerechnung()
        {
            // Arrange
            var budgetService = Container.Resolve<VmKlientenbudgetDTOService>();
            var entity = _budgetEntities[0];
            var budgetDto = budgetService.GetById(null, entity.VmKlientenbudgetID);
            Assert.IsNotNull(budgetDto, "Klientenbudget is null");
            var result = budgetService.SetPositionen(null, budgetDto);
            Assert.IsTrue(result.IsOk, "SetPositionen failed");
            var position = budgetDto.Vermoegen[0];
            position.VmPosition.Saldo = 10;
            var positionService = Container.Resolve<VmPositionDTOService>();

            // Act
            result = positionService.UpdateBetragSaldoOtherPositions(null, budgetDto, position);
            var positionElBerechnung = budgetDto.Vermoegen[3];

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(0, positionElBerechnung.VmPosition.Saldo);
        }

        [TestMethod]
        public void UpdateBetragSaldoOtherPositions_Vermoegen_UpdateSaldoElBerechnung()
        {
            // Arrange
            var budgetService = Container.Resolve<VmKlientenbudgetDTOService>();
            var entity = _budgetEntities[0];
            var budgetDto = budgetService.GetById(null, entity.VmKlientenbudgetID);
            Assert.IsNotNull(budgetDto, "Klientenbudget is null");
            var result = budgetService.SetPositionen(null, budgetDto);
            Assert.IsTrue(result.IsOk, "SetPositionen failed");
            var position = budgetDto.Vermoegen[0];
            position.VmPosition.Saldo = 110;
            var positionService = Container.Resolve<VmPositionDTOService>();

            // Act
            result = positionService.UpdateBetragSaldoOtherPositions(null, budgetDto, position);
            var positionElBerechnung = budgetDto.Vermoegen[3];

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.AreEqual(110 + 200 - 300, positionElBerechnung.VmPosition.Saldo);
        }

        #endregion
    }
}