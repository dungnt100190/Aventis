using System;

using Kiss.DataAccess.Test.Seeder;
using Kiss.DbContext;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Fa
{
    [TestClass]
    public class FaLeistungRepositoryTest
    {
        [TestMethod]
        [TestCategory("ZH")]
        public void GetActiveByBaPersonId_Falltraeger()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                var faLeistungSeeder = (FaLeistungSeeder)seed.GetOrCreateSeeder<FaLeistung>();
                faLeistungSeeder.IsZh = true;
                var faLeistung = seed.GetOrCreateEntity<FaLeistung>();
                seed.CreateSeed();

                var baPersonId = faLeistung.BaPersonID;

                using (var unitOfWork = new KissUnitOfWork())
                {
                    var activeLeistung = unitOfWork.FaLeistung.GetFaLeistungByBaPersonId(baPersonId, true);

                    Assert.IsNotNull(activeLeistung);
                    Assert.AreEqual(faLeistung.FaLeistungID, activeLeistung.FaLeistungID);
                }
            }
        }

        [TestMethod]
        [TestCategory("ZH")]
        public void GetActiveByBaPersonId_InFall()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                var faLeistungSeeder = (FaLeistungSeeder)seed.GetOrCreateSeeder<FaLeistung>();
                faLeistungSeeder.IsZh = true;
                var faLeistung = seed.GetOrCreateEntity<FaLeistung>();
                var faFallPerson = seed.GetOrCreateEntity<FaFallPerson>();
                var baPerson2 = seed.CreateEntity<BaPerson>();
                faFallPerson.FaFall = faLeistung.FaFall;
                faFallPerson.BaPerson = baPerson2;
                seed.CreateSeed();

                var baPersonId = baPerson2.BaPersonID;

                using (var unitOfWork = new KissUnitOfWork())
                {
                    var activeLeistung = unitOfWork.FaLeistung.GetFaLeistungByBaPersonId(baPersonId, true);

                    Assert.IsNotNull(activeLeistung);
                    Assert.AreEqual(faLeistung.FaLeistungID, activeLeistung.FaLeistungID);
                }
            }
        }

        [TestMethod]
        [TestCategory("ZH")]
        public void GetActiveByBaPersonId_Leistungstraeger()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                var faLeistungSeeder = (FaLeistungSeeder)seed.GetOrCreateSeeder<FaLeistung>();
                faLeistungSeeder.IsZh = true;
                var faLeistung = seed.GetOrCreateEntity<FaLeistung>();
                faLeistung.FaProzessCode = 700;
                seed.CreateSeed();

                var baPersonId = faLeistung.BaPersonID;

                using (var unitOfWork = new KissUnitOfWork())
                {
                    var activeLeistung = unitOfWork.FaLeistung.GetFaLeistungByBaPersonId(baPersonId, true);

                    Assert.IsNotNull(activeLeistung);
                    Assert.AreEqual(faLeistung.FaLeistungID, activeLeistung.FaLeistungID);
                }
            }
        }

        [TestMethod]
        [TestCategory("ZH")]
        public void GetFaLeistungProUserByBaPersonId_aktiverFalltraeger_ReturnLeistung()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                var faLeistungSeeder = (FaLeistungSeeder)seed.GetOrCreateSeeder<FaLeistung>();
                faLeistungSeeder.IsZh = true;
                var faLeistung = seed.GetOrCreateEntity<FaLeistung>();
                seed.CreateSeed();

                var baPersonId = faLeistung.BaPersonID;

                using (var unitOfWork = new KissUnitOfWork())
                {
                    var activeLeistung = unitOfWork.FaLeistung.GetFaLeistungProUserByBaPersonId(baPersonId);

                    Assert.IsNotNull(activeLeistung);
                    Assert.AreEqual(1, activeLeistung.Count);
                    Assert.AreEqual(faLeistung.FaLeistungID, activeLeistung[0].FaLeistungID);
                }
            }
        }

        [TestMethod]
        [TestCategory("ZH")]
        public void GetFaLeistungProUserByBaPersonId_aktiverFalltraegerUndLeistungstraegerGleicherBenutzer_ReturnLeistung()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                var faLeistungSeeder = (FaLeistungSeeder)seed.GetOrCreateSeeder<FaLeistung>();
                faLeistungSeeder.IsZh = true;
                var faLeistung = seed.GetOrCreateEntity<FaLeistung>();
                var faLeistung2 = seed.CreateEntity<FaLeistung>();
                faLeistung2.FaProzessCode = 700;
                seed.CreateSeed();

                var baPersonId = faLeistung.BaPersonID;

                using (var unitOfWork = new KissUnitOfWork())
                {
                    var activeLeistung = unitOfWork.FaLeistung.GetFaLeistungProUserByBaPersonId(baPersonId);

                    Assert.IsNotNull(activeLeistung);
                    Assert.AreEqual(1, activeLeistung.Count);
                    Assert.AreEqual(faLeistung.FaLeistungID, activeLeistung[0].FaLeistungID);
                }
            }
        }

        // TODO Problem mit seed.CreateSeed() beheben
        //[TestMethod]
        //[TestCategory("ZH")]
        //public void GetFaLeistungProUserByBaPersonId_aktiverFalltraegerUndLeistungstraegerUnterschiedlicheBenutzer_ReturnBeideLeistungen()
        //{
        //    using (var seed = new DbSeed(() => new KissUnitOfWork()))
        //    {
        //        var faLeistung = seed.GetOrCreateEntity<FaLeistung>();
        //        var faLeistung2 = seed.CreateEntity<FaLeistung>();
        //        faLeistung2.FaProzessCode = 700;
        //        faLeistung2.XUser = seed.CreateEntity<XUser>();
        //        seed.CreateSeed();

        //        var baPersonId = faLeistung.BaPersonID;

        //        using (var unitOfWork = new KissUnitOfWork())
        //        {
        //            var activeLeistung = unitOfWork.FaLeistung.GetFaLeistungProUserByBaPersonId(baPersonId);

        //            Assert.IsNotNull(activeLeistung);
        //            Assert.AreEqual(2, activeLeistung.Count);
        //            Assert.AreEqual(faLeistung.FaLeistungID, activeLeistung[0].FaLeistungID);
        //            Assert.AreEqual(faLeistung2.FaLeistungID, activeLeistung[1].FaLeistungID);
        //        }
        //    }
        //}

        [TestMethod]
        [TestCategory("ZH")]
        public void GetFaLeistungProUserByBaPersonId_aktiverLeistungstraeger_ReturnLeistung()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                var faLeistungSeeder = (FaLeistungSeeder)seed.GetOrCreateSeeder<FaLeistung>();
                faLeistungSeeder.IsZh = true;
                var faLeistung = seed.GetOrCreateEntity<FaLeistung>();
                faLeistung.FaProzessCode = 700;
                seed.CreateSeed();

                var baPersonId = faLeistung.BaPersonID;

                using (var unitOfWork = new KissUnitOfWork())
                {
                    var activeLeistung = unitOfWork.FaLeistung.GetFaLeistungProUserByBaPersonId(baPersonId);

                    Assert.IsNotNull(activeLeistung);
                    Assert.AreEqual(1, activeLeistung.Count);
                    Assert.AreEqual(faLeistung.FaLeistungID, activeLeistung[0].FaLeistungID);
                }
            }
        }

        [TestMethod]
        [TestCategory("ZH")]
        public void GetFaLeistungProUserByBaPersonId_inAktiverFall_ReturnLeistung()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                var faLeistungSeeder = (FaLeistungSeeder)seed.GetOrCreateSeeder<FaLeistung>();
                faLeistungSeeder.IsZh = true;
                var faLeistung = seed.GetOrCreateEntity<FaLeistung>();
                var faFallPerson = seed.GetOrCreateEntity<FaFallPerson>();
                var baPerson2 = seed.CreateEntity<BaPerson>();
                faFallPerson.FaFall = faLeistung.FaFall;
                faFallPerson.BaPerson = baPerson2;
                seed.CreateSeed();

                var baPersonId = baPerson2.BaPersonID;

                using (var unitOfWork = new KissUnitOfWork())
                {
                    var activeLeistung = unitOfWork.FaLeistung.GetFaLeistungProUserByBaPersonId(baPersonId);

                    Assert.IsNotNull(activeLeistung);
                    Assert.AreEqual(1, activeLeistung.Count);
                    Assert.AreEqual(faLeistung.FaLeistungID, activeLeistung[0].FaLeistungID);
                }
            }
        }

        [TestMethod]
        [TestCategory("ZH")]
        public void GetFaLeistungProUserByBaPersonId_inaktiverFalltraeger_ReturnEmptyList()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                var faLeistungSeeder = (FaLeistungSeeder)seed.GetOrCreateSeeder<FaLeistung>();
                faLeistungSeeder.IsZh = true;
                var faLeistung = seed.GetOrCreateEntity<FaLeistung>();
                faLeistung.DatumBis = DateTime.Today.AddDays(-1);
                seed.CreateSeed();

                var baPersonId = faLeistung.BaPersonID;

                using (var unitOfWork = new KissUnitOfWork())
                {
                    var activeLeistung = unitOfWork.FaLeistung.GetFaLeistungProUserByBaPersonId(baPersonId);

                    Assert.IsNotNull(activeLeistung);
                    Assert.AreEqual(0, activeLeistung.Count);
                }
            }
        }

        [TestMethod]
        [TestCategory("ZH")]
        public void GetFaLeistungProUserByBaPersonId_inInaktiverFall_ReturnLeistung()
        {
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                var faLeistungSeeder = (FaLeistungSeeder)seed.GetOrCreateSeeder<FaLeistung>();
                faLeistungSeeder.IsZh = true;
                var faLeistung = seed.GetOrCreateEntity<FaLeistung>();
                faLeistung.DatumBis = DateTime.Today.AddDays(-1);
                var faFallPerson = seed.GetOrCreateEntity<FaFallPerson>();
                var baPerson2 = seed.CreateEntity<BaPerson>();
                faFallPerson.FaFall = faLeistung.FaFall;
                faFallPerson.BaPerson = baPerson2;
                seed.CreateSeed();

                var baPersonId = baPerson2.BaPersonID;

                using (var unitOfWork = new KissUnitOfWork())
                {
                    var activeLeistung = unitOfWork.FaLeistung.GetFaLeistungProUserByBaPersonId(baPersonId);

                    Assert.IsNotNull(activeLeistung);
                    Assert.AreEqual(0, activeLeistung.Count);
                }
            }
        }
    }
}