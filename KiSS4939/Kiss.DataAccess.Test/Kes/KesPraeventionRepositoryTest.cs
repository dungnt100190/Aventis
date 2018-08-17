using Kiss.DataAccess.Test.Seeder;
using Kiss.DbContext;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Kes
{
    [TestClass]
    public class KesPraeventionRepositoryTest
    {
        [TestMethod]
        public void GetByFaLeistungId_Ok()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                // Arrange
                var praevention = seed.GetOrCreateEntity<KesPraevention>();
                seed.CreateSeed();

                using (var unitOfWork = new KissUnitOfWork())
                {
                    //Act
                    var result = unitOfWork.KesPraevention.GetByFaLeistungId(praevention.FaLeistungID);

                    // Assert
                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.Count > 0);
                }
            }
        }
    }
}