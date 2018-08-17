using Kiss.DataAccess.Test.Seeder;
using Kiss.DbContext;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Kes
{
    [TestClass]
    public class KesMassnahmeBerichtRepositoryTest
    {
        [TestMethod]
        public void GetByKesMassnahmeId_Ok()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                // Arrange
                var massnahmeBericht = seed.GetOrCreateEntity<KesMassnahmeBericht>();
                seed.CreateSeed();

                using (var unitOfWork = new KissUnitOfWork())
                {
                    //Act
                    var result = unitOfWork.KesMassnahmeBericht.GetByKesMassnahmeId(massnahmeBericht.KesMassnahmeID, false);

                    // Assert
                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.Count > 0);
                }
            }
        }
    }
}