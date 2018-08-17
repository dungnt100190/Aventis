using System.Linq;

using Moq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BusinessLogic.Vm;
using Kiss.DataAccess.Vm;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;
using Kiss.Infrastructure.IoC;

namespace Kiss.BusinessLogic.Test.Vm
{
    /// <summary>
    /// Tests the VmKlientenbudgetService service.
    /// </summary>
    [TestClass]
    public class VmKlientenbudgetServiceTest
    {
        #region Test Methods

        [TestMethod]
        public void DeleteData_BudgetWithPosition_IsOk()
        {
            // Arrange
            var budget = CreateBudget();
            var positions = budget.VmPosition.ToArray();

            var budgetRepository = new Mock<VmKlientenbudgetRepository>();
            budgetRepository.Setup(moq => moq.GetById(It.IsAny<int>()))
                            .Returns(budget);
            budgetRepository.Setup(moq => moq.Remove(It.IsAny<VmKlientenbudget>()))
                            .Returns(budget);

            var positionRepository = new Mock<VmPositionRepository>();
            positionRepository.Setup(moq => moq.GetByVmKlientenbudgetId(It.IsAny<int>()))
                               .Returns(positions.ToArray());
            positionRepository.Setup(moq => moq.Remove(It.IsAny<VmPosition>()))
                               .Returns((VmPosition id) => positions.FirstOrDefault(pos => pos.VmPositionID == id.VmPositionID));

            var ouwMock = new UnitOfWorkMock();
            ouwMock.RegisterRepository(uow => uow.VmKlientenbudget, budgetRepository.Object);
            ouwMock.RegisterRepository(uow => uow.VmPosition, positionRepository.Object);

            // Act
            var service = Container.Resolve<VmKlientenbudgetService>();
            var result = service.DeleteEntity(budget);

            // Assert
            Assert.IsTrue(result.IsOk);

            // budget and dependend positions should be removed
            budgetRepository.Verify(moq => moq.Remove(budget), Times.Once());
            positionRepository.Verify(moq => moq.Remove(positions[0]), Times.Once());
            positionRepository.Verify(moq => moq.Remove(positions[1]), Times.Once());
            positionRepository.Verify(moq => moq.Remove(positions[2]), Times.Once());
        }

        // ToDo: Was ist der Unterschied zu DeleteData_BudgetWithPosition_IsOk?
        //[TestMethod]
        //public void DeleteData_NewBudgetWithPosition_IsOk()
        //{
        //    if (!TestUtils.IsDbTest(null))
        //    {
        //        return;
        //    }
        //    // Arrange
        //    var service = Container.Resolve<VmKlientenbudgetService>();
        //    VmKlientenbudget entity;
        //    var result = service.NewData(out entity);
        //    Assert.IsTrue(result, result);
        //    entity.FaLeistung = _faLeistung;
        //    entity.XUser = _faLeistung.XUser;
        //    entity.VmKlientenbudgetMutationsgrundCode = 1;
        //    result = service.SaveData(null, entity);
        //    Assert.IsTrue(result, result);
        //    // Act
        //    result = service.DeleteData(null, entity);
        //    // Assert
        //    Assert.IsTrue(result, result);
        //}

        [TestMethod]
        public void NewData_KlientenbudgetUndStandardPositionenErstellt()
        {
            // Arrange
            var service = Container.Resolve<VmKlientenbudgetService>();
            var positionsarten = new[]{new VmPositionsart
                                           {
                                               Name = "PoA 1",
                                               VmKategorie = VmKategorie.Einnahmen,
                                               VmPositionsartID = 1,
                                               VmPositionsartTyp = VmPositionsartTyp.EinnAhvRente
                                           },
                                           new VmPositionsart
                                           {
                                               Name = "PoA 2",
                                               VmKategorie = VmKategorie.Einnahmen,
                                               VmPositionsartID = 2,
                                               VmPositionsartTyp = VmPositionsartTyp.EinnAnteilAusVermoegen
                                           },
                                           new VmPositionsart
                                           {
                                               Name = "PoA 3",
                                               VmKategorie = VmKategorie.VariableKosten,
                                               VmPositionsartID = 3,
                                               VmPositionsartTyp = VmPositionsartTyp.AusgHeizUndNebenkosten
                                           }
                                       };
            var positionartRepository = new Mock<VmPositionsartRepository>();
            positionartRepository.Setup(moq => moq.GetTemplatePositionsarten())
                                 .Returns(positionsarten);

            var ouwMock = new UnitOfWorkMock();
            ouwMock.RegisterRepository(uow => uow.VmPositionsart, positionartRepository.Object);

            // Act
            var budget = service.GetDefaultBudget();

            // Assert
            Assert.IsNotNull(budget);
            Assert.IsTrue(budget.VmPosition.Count == 3);
            Assert.IsTrue(budget.VmPosition.Single(pos => IsPositionOfPositionsart(pos, positionsarten[0])) != null);
            Assert.IsTrue(budget.VmPosition.Single(pos => IsPositionOfPositionsart(pos, positionsarten[1])) != null);
            Assert.IsTrue(budget.VmPosition.Single(pos => IsPositionOfPositionsart(pos, positionsarten[2])) != null);
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static VmKlientenbudget CreateBudget()
        {
            var budget = new VmKlientenbudget
            {
                VmKlientenbudgetID = 123
            };

            budget.VmPosition = new[]
            {
                new VmPosition
                {
                    VmPositionID = 1,
                    VmKlientenbudgetID = budget.VmKlientenbudgetID
                },
                new VmPosition
                {
                    VmPositionID = 2,
                    VmKlientenbudgetID = budget.VmKlientenbudgetID
                },
                new VmPosition
                {
                    VmPositionID = 3,
                    VmKlientenbudgetID = budget.VmKlientenbudgetID
                }
            };
            return budget;
        }

        private static bool IsPositionOfPositionsart(VmPosition position, VmPositionsart positionsart)
        {
            return position.VmPositionsartID == positionsart.VmPositionsartID;
        }

        #endregion

        #endregion
    }
}