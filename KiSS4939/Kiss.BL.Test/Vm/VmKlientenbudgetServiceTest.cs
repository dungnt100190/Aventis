using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test.Helpers;
using Kiss.BL.Vm;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Vm
{
    /// <summary>
    /// Tests the VmKlientenbudgetService service.
    /// </summary>
    [TestClass]
    public class VmKlientenbudgetServiceTest : TransactionTestBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FaLeistungHelper _faLeistungHelper = new FaLeistungHelper();
        private readonly VmKlientenbudgetHelper _klientenbudgetHelper = new VmKlientenbudgetHelper();
        private readonly VmPositionsartHelper _positionsartHelper = new VmPositionsartHelper();

        #endregion

        #region Private Fields

        private List<VmKlientenbudget> _entities;
        private FaLeistung _faLeistung;

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

            var unitOfWork = UnitOfWork.GetNew;

            var positionsart = _positionsartHelper.Create(
                unitOfWork,
                Infrastructure.Constant.LOVsGenerated.VmKategorie.Einnahmen,
                Infrastructure.Constant.LOVsGenerated.VmPositionsartTyp.EinnIvRente,
                "TemplateTest",
                true);

            _faLeistung = _faLeistungHelper.Create(unitOfWork, 5, 501);

            var budget = _klientenbudgetHelper.Create(unitOfWork, _faLeistung);
            _klientenbudgetHelper.AddPosition(unitOfWork, budget, positionsart, "pos test", 11);
            _entities = new List<VmKlientenbudget>();
            _entities.Add(budget);
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
        public void DeleteData_BudgetWithPosition_IsOk()
        {
            // Arrange
            var service = Container.Resolve<VmKlientenbudgetService>();
            var entity = _entities[0];

            // Act
            var result = service.DeleteData(null, entity);

            // Assert
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void DeleteData_NewBudgetWithPosition_IsOk()
        {
            if (!TestUtils.IsDbTest(null))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<VmKlientenbudgetService>();
            VmKlientenbudget entity;
            var result = service.NewData(out entity);
            Assert.IsTrue(result, result);
            entity.FaLeistung = _faLeistung;
            entity.XUser = _faLeistung.XUser;
            entity.VmKlientenbudgetMutationsgrundCode = 1;
            result = service.SaveData(null, entity);
            Assert.IsTrue(result, result);

            // Act
            result = service.DeleteData(null, entity);

            // Assert
            Assert.IsTrue(result, result);
        }

        [TestMethod]
        public void GetByFaLeistungId_BudgetExistsForLeistungId_ReturnListOfBudget()
        {
            // Arrange
            var service = Container.Resolve<VmKlientenbudgetService>();

            // Act
            var result = service.GetByFaLeistungId(null, _faLeistung.FaLeistungID);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetById_BudgetWithIdExists_NotNull()
        {
            // Arrange
            var service = Container.Resolve<VmKlientenbudgetService>();
            var entity = _entities[0];

            // Act
            var result = service.GetById(null, entity.VmKlientenbudgetID);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void NewData_KlientenbudgetUndStandardPositionenErstellt()
        {
            // Arrange
            var service = Container.Resolve<VmKlientenbudgetService>();
            VmKlientenbudget budget;

            // Act
            var result = service.NewData(out budget);

            // Assert
            Assert.IsTrue(result.IsOk);
            Assert.IsNotNull(budget);
            Assert.IsTrue(budget.VmPosition.Count > 0);
        }

        #endregion
    }
}