using System;
using Kiss.DbContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Fs
{
    [TestClass]
    public class FsPhaseRepositoryTest
    {
        //TODO [TestMethod]
        public void TestMethod1()
        {
            var von = DateTime.Today.AddDays(-20);
            var bis = DateTime.Today.AddDays(20);
            using (var uow = new KissUnitOfWork())
            {
                var auswertung = uow.FaPhase.GetPhasenDienstleistungAuswertung(von, bis);
            }

            // Assert
        }
    }
}