using System.Linq;

using Kiss.DataAccess.Test.Seeder;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Kes;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Kes
{
    [TestClass]
    public class KesVerlaufRepositoryTest
    {
        [TestMethod]
        public void GetByFaLeistungId_Pflegekinderaufsicht_Ok()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                // Arrange
                var kesVerlaufPriMaBegleitung = seed.CreateEntity<KesVerlauf>();
                kesVerlaufPriMaBegleitung.KesVerlaufTypCode = (int)KesVerlaufTyp.PriMaBegleitung;
                var kesVerlaufPflegekinderaufsicht = seed.CreateEntity<KesVerlauf>();
                kesVerlaufPflegekinderaufsicht.KesVerlaufTypCode = (int)KesVerlaufTyp.Pflegekinderaufsicht;
                seed.CreateSeed();

                using (var unitOfWork = new KissUnitOfWork())
                {
                    // Act
                    var result = unitOfWork.KesVerlauf.GetByFaLeistungId(kesVerlaufPflegekinderaufsicht.FaLeistungID, (int)KesVerlaufTyp.Pflegekinderaufsicht);

                    // Assert
                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.All(x => x.WrappedEntity != null));
                    Assert.IsTrue(result.Any(x => x.AutoIdentityID == kesVerlaufPflegekinderaufsicht.KesVerlaufID));
                    Assert.IsTrue(result.All(x => x.WrappedEntity.KesVerlaufTypCode == (int)KesVerlaufTyp.Pflegekinderaufsicht));

                    Assert.IsFalse(result.Any(x => x.AutoIdentityID == kesVerlaufPriMaBegleitung.AutoIdentityID));
                }
            }
        }

        [TestMethod]
        public void GetByFaLeistungId_PriMaBegleitung_Ok()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                // Arrange
                var kesVerlaufPriMaBegleitung = seed.CreateEntity<KesVerlauf>();
                kesVerlaufPriMaBegleitung.KesVerlaufTypCode = (int)KesVerlaufTyp.PriMaBegleitung;
                var kesVerlaufPflegekinderaufsicht = seed.CreateEntity<KesVerlauf>();
                kesVerlaufPflegekinderaufsicht.KesVerlaufTypCode = (int)KesVerlaufTyp.Pflegekinderaufsicht;
                seed.CreateSeed();

                using (var unitOfWork = new KissUnitOfWork())
                {
                    // Act
                    var result = unitOfWork.KesVerlauf.GetByFaLeistungId(kesVerlaufPriMaBegleitung.FaLeistungID, (int)KesVerlaufTyp.PriMaBegleitung);

                    // Assert
                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.All(x => x.WrappedEntity != null));
                    Assert.IsTrue(result.Any(x => x.AutoIdentityID == kesVerlaufPriMaBegleitung.KesVerlaufID));
                    Assert.IsTrue(result.All(x => x.WrappedEntity.KesVerlaufTypCode == (int)KesVerlaufTyp.PriMaBegleitung));

                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.All(x => x.WrappedEntity != null));
                    Assert.IsTrue(result.Any(x => x.AutoIdentityID == kesVerlaufPriMaBegleitung.KesVerlaufID));
                    Assert.IsTrue(result.All(x => x.WrappedEntity.KesVerlaufTypCode == (int)KesVerlaufTyp.PriMaBegleitung));

                    Assert.IsFalse(result.Any(x => x.AutoIdentityID == kesVerlaufPflegekinderaufsicht.AutoIdentityID));
                }
            }
        }
    }
}