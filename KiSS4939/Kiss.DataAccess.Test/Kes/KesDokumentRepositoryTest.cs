using Kiss.DataAccess.Test.Seeder;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Kes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Kes
{
    [TestClass]
    public class KesDokumentRepositoryTest
    {
        [TestMethod]
        public void GetByKesAuftragId_Ok()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                // Arrange
                seed.GetOrCreateEntity<KesDokument>();
                seed.CreateSeed();

                var auftrag = seed.GetOrCreateEntity<KesAuftrag>();

                using (var unitOfWork = new KissUnitOfWork())
                {
                    //Act
                    var result = unitOfWork.KesDokument.GetByKesAuftragId(auftrag.KesAuftragID, (int)KesDokumentTyp.AuftragDokument, false);

                    // Assert
                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.Count > 0);
                }
            }
        }
    }
}