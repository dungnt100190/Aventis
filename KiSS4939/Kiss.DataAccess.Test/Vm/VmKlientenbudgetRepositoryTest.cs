
using Kiss.DataAccess.Test.Seeder;
using Kiss.DbContext;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Vm
{
    [TestClass]
    public class VmKlientenbudgetRepositoryTest
    {
        [TestMethod]
        public void GetByFaLeistungId_BudgetExistsForLeistungId_ReturnListOfBudget()
        {
            // Arrange
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                var budgetArrange = seed.GetOrCreateEntity<VmKlientenbudget>();
                seed.CreateSeed();

                //Act
                using (var unitOfWork = new KissUnitOfWork())
                {
                    var budgetAct = unitOfWork.VmKlientenbudget.GetByFaLeistungId(budgetArrange.FaLeistungID);

                    // Assert
                    Assert.IsNotNull(budgetAct);
                    Assert.IsTrue(budgetAct.Length > 0);
                }
            }
        }
    }
}
