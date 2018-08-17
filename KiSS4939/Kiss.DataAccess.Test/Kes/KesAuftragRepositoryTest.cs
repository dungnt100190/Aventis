using Kiss.DataAccess.Test.Seeder;
using Kiss.DbContext;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Kes
{
    [TestClass]
    public class KesAuftragRepositoryTest
    {
        [TestMethod]
        public void GetByFaLeistungId_Ok()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                // Arrange
                var auftrag = seed.GetOrCreateEntity<KesAuftrag>();
                seed.CreateSeed();

                using (var unitOfWork = new KissUnitOfWork())
                {
                    //Act
                    var result = unitOfWork.KesAuftrag.GetByFaLeistungId(auftrag.FaLeistungID);

                    // Assert
                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.Count > 0);
                }
            }
        }
    }
}