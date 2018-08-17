using Kiss.DataAccess.Test.Seeder;
using Kiss.DbContext;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Kes
{
    [TestClass]
    public class KesMassnahmeRepositoryTest
    {
        [TestMethod]
        public void GetByFaLeistungId_Ok()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                // Arrange
                var massnahme = seed.GetOrCreateEntity<KesMassnahme>();
                seed.CreateSeed();

                using (var unitOfWork = new KissUnitOfWork())
                {
                    //Act
                    var result = unitOfWork.KesMassnahme.GetByFaLeistungId(massnahme.FaLeistungID, false);

                    // Assert
                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.Count > 0);
                }
            }
        }
    }
}