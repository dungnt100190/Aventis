using System;
using Kiss.Infrastructure.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BusinessLogic.Test.Ba
{
    ///// <summary>
    ///// Tests the BaGemeindeService service.
    ///// </summary>
    //[TestClass]
    //[DeploymentItem(@"TestFiles\BaGemeindeServiceTestFiles.zip", "TestFiles")]
    //public class BaGemeindeServiceTest : TransactionTestBase
    //{
    //    #region Test Methods

    //    [ClassInitialize]
    //    public static void ClassInitialize(TestContext context)
    //    {
    //        ClassInitialize();
    //    }

    //    [TestInitialize]
    //    public override void TestInitialize()
    //    {
    //        base.TestInitialize();
    //    }

    //    [ClassCleanup]
    //    public static new void ClassCleanup()
    //    {
    //        TestServiceBase.ClassCleanup();
    //    }

    //    [TestCleanup]
    //    public override void TestCleanup()
    //    {
    //        base.TestCleanup();
    //    }

    //    [TestMethod]
    //    public void Test_UpdateBaGemeinde()
    //    {
    //        var service = Container.Resolve<BaGemeindeService>();
    //        var stream = service.GetXmlStream(@"TestFiles\BaGemeindeServiceTestFiles.zip");
    //        var result = service.UpdateBaGemeindeInternal(null, stream);

    //        Assert.IsTrue(result, result);

    //        var unitOfWork = UnitOfWork.GetNew;
    //        var repoBaGemeinde = UnitOfWork.GetRepository<BaGemeinde>(unitOfWork);
    //        var testGemeinde = repoBaGemeinde.FirstOrDefault(x => x.GemeindeHistorisierungID == 10001);

    //        Assert.IsNotNull(testGemeinde);
    //        Assert.AreEqual(3501, testGemeinde.BFSCode);
    //        Assert.AreEqual(1000, testGemeinde.GemeindeAufnahmeNummer);
    //        Assert.AreEqual(new DateTime(1960, 1, 1), testGemeinde.GemeindeAufnahmeDatum);
    //        Assert.AreEqual(1944, testGemeinde.GemeindeAufhebungNummer);
    //        Assert.AreEqual(new DateTime(2000, 12, 31), testGemeinde.GemeindeAufhebungDatum);
    //        Assert.AreEqual(new DateTime(2000, 12, 31), testGemeinde.GemeindeAenderungDatum);
    //    }

    //    #endregion
    //}
}