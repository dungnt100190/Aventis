using System.Linq;

using Kiss.DataAccess.Test.Seeder;
using Kiss.DbContext;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Sys
{
    [TestClass]
    public class XLovCodeRepositoryTest
    {
        [TestMethod]
        public void GetLovCodeByLovName_OK()
        {
            using (var seedLangText = new DbSeed(() => new KissUnitOfWork()))
            {
                // Arrange
                var lan = seedLangText.GetOrCreateEntity<XLangText>();
                seedLangText.CreateSeed();

                using (var seed = new DbSeed(() => new KissUnitOfWork()))
                {
                    var loc = seed.GetOrCreateEntity<XLOVCode>();
                    loc.TextTID = lan.TID;
                    seed.CreateSeed();

                    using (var unitOfWork = new KissUnitOfWork())
                    {
                        //Act
                        var result = unitOfWork.XLovCode.GetLovCodeByLovName(loc.LOVName, 1);

                        // Assert
                        Assert.IsNotNull(result);
                        Assert.IsTrue(result.Count > 0);
                    }
                }
            }
        }

        [TestMethod]
        public void GetLovCodeByLovName_TextFr_OK()
        {
            using (var seedLangText = new DbSeed(() => new KissUnitOfWork()))
            {
                // Arrange
                var lan = seedLangText.GetOrCreateEntity<XLangText>();
                lan.LanguageCode = 2;
                lan.Text = lan.Text + " fr";
                seedLangText.CreateSeed();

                using (var seed = new DbSeed(() => new KissUnitOfWork()))
                {
                    var loc = seed.GetOrCreateEntity<XLOVCode>();
                    loc.TextTID = lan.TID;
                    seed.CreateSeed();

                    using (var unitOfWork = new KissUnitOfWork())
                    {
                        //Act
                        var result = unitOfWork.XLovCode.GetLovCodeByLovName(loc.LOVName, 2);

                        // Assert
                        Assert.IsNotNull(result);
                        Assert.IsTrue(result.Count == 1);
                        Assert.AreEqual(lan.Text, result.First(x => x.Code == loc.Code).Text);
                    }
                }
            }
        }
    }
}