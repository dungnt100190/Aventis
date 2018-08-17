using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.BL.Sst;
using Kiss.Interfaces.IoC;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Kbu;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Kbu
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class KbuBelegServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly KbuBelegHelper _belegHelper = new KbuBelegHelper();
        private readonly List<KbuBeleg> _entities = new List<KbuBeleg>();
        private readonly KbuKontoHelper _kontoHelper = new KbuKontoHelper();
        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();
        private readonly WshPositionHelper _positionHelper = new WshPositionHelper();

        private const string CREATOR = "UnitTester";

        #endregion

        #region Private Fields

        private KbuBeleg _beleg;
        private KbuKonto _konto;
        private FaLeistung _leistung;
        private WshPosition _positionAusgabe;
        private WshPosition _positionEinnahme;
        private readonly List<int> _kbuBelegPositionMitSachkonto = new List<int>();

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize(DatabaseTestUtil.CONNECTION_STRING_NAME_KISS5);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //using (var transaction = new TransactionScope())
            //{

            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            _beleg = _belegHelper.Create(unitOfWork);
            _konto = _kontoHelper.Create(unitOfWork);

            _leistung = _leistungHelper.Create(unitOfWork);
            _positionEinnahme = _positionHelper.CreateEinnahme(unitOfWork, _leistung, 2011, 6, "UnitTest", 10, _konto, _leistung.BaPerson);
            _positionAusgabe = _positionHelper.CreateAusgabe(unitOfWork, _leistung, 2011, 6, "UnitTest", 60, _konto, _leistung.BaPerson);

            //  transaction.Complete();
            //}
        }

        [TestCleanup]
        public void TestCleanup()
        {
            //using (var transaction = new TransactionScope())
            //{
            var unitOfWork = UnitOfWork.GetNew;
            var repositoryBeleg = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);
            var repositorySachkonto = UnitOfWork.GetRepository<SstPscdBelegPosition>(unitOfWork);

            /*
            var repository = UnitOfWork.GetRepository<TEntity>(unitOfWork);

            // Delete the temporary test objects
            _entities.ForEach(x => x.MarkAsDeleted());
            _entities.ForEach(x => repository.ApplyChanges(x));

            unitOfWork.SaveChanges();*/
            var svcSachkontoInnenauftrag = Container.Resolve<SstPscdBelegPositionService>();
            var sachkonti = svcSachkontoInnenauftrag.GetData(unitOfWork).Where(x=>_kbuBelegPositionMitSachkonto.Contains(x.KbuBelegPositionID));
            foreach (var sachkonto in sachkonti)
            {
                sachkonto.MarkAsDeleted();
                repositorySachkonto.ApplyChanges(sachkonto);
            }

            foreach (var beleg in _entities)
            {
                DeleteBeleg(unitOfWork, beleg);
            }

            _positionHelper.Delete(unitOfWork);
            _leistungHelper.Delete(unitOfWork);
            _kontoHelper.Delete(unitOfWork);
            _belegHelper.Delete(unitOfWork);

            //  transaction.Complete();
            //}
        }

        [TestMethod]
        public void CreateBeleg_Ok()
        {
            //Prepare
            var service = Container.Resolve<KbuBelegService>();
            WshAuszahlvorschlagBelegDTO auszahlvorschlagBelegDTO = new WshAuszahlvorschlagBelegDTO();
            WshAuszahlvorschlagBelegPositionDTO belegPositionAusgabe = new WshAuszahlvorschlagBelegPositionDTO(auszahlvorschlagBelegDTO);
            WshAuszahlvorschlagBelegPositionDTO belegPositionEinnahme = new WshAuszahlvorschlagBelegPositionDTO(auszahlvorschlagBelegDTO);

            belegPositionAusgabe.Ausgabe = 300;
            belegPositionAusgabe.WshPosition = _positionAusgabe;

            belegPositionEinnahme.Einnahme = 50;
            belegPositionEinnahme.WshPosition = _positionEinnahme;


            auszahlvorschlagBelegDTO.BelegPositionen = new List<WshAuszahlvorschlagBelegPositionDTO>();
            auszahlvorschlagBelegDTO.BelegPositionen.Add(belegPositionAusgabe);
            auszahlvorschlagBelegDTO.BelegPositionen.Add(belegPositionEinnahme);
            auszahlvorschlagBelegDTO.Valuta = DateTime.Now;
            auszahlvorschlagBelegDTO.Kreditor = new WshAuszahlvorschlagKreditorDTO();
            auszahlvorschlagBelegDTO.Kreditor.Name = "Unit Test";

            // Act
            KbuBeleg beleg;
            var result = service.CreateBeleg(null, auszahlvorschlagBelegDTO, false, out beleg);
            _entities.Add(beleg);

            // Assert
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void Test_GetBelegWithSachkontoInnenauftrag()
        {
            // doppeltes SubInclude funktioniert nur gegenüber DB
            if (!TestUtils.IsDbTest(null))
            {
                return;
            }
            
            //Prepare
            var unitOfWork = UnitOfWork.GetNew;
            var beleg = _belegHelper.CreateBelegVerbucht(unitOfWork);
            var svcSachkontoInnenauftrag = Container.Resolve<SstPscdBelegPositionService>();
            var svcBeleg = Container.Resolve<KbuBelegService>();
            var sachkonto = "1234";
            var innenauftrag = "123456789";
            foreach (var belegPosition in beleg.KbuBelegPosition.Where(pos => pos.HauptPosition == false))
            {
                svcSachkontoInnenauftrag.Insert(unitOfWork, belegPosition.KbuBelegPositionID, sachkonto, innenauftrag);
                _kbuBelegPositionMitSachkonto.Add(belegPosition.KbuBelegPositionID);
            }

            // Act
            var belege = svcBeleg.GetByIdsForPscdTransfer(unitOfWork, new int[] { beleg.KbuBelegID });

            // Assert
            var belegGet = belege.Single();
            var erPositionen = belegGet.KbuBelegPosition.Where(pos => pos.HauptPosition == false);
            var pos1 = erPositionen.First();
            Assert.AreEqual(1, pos1.SstPscdBelegPosition.Count);
            Assert.AreEqual(sachkonto, pos1.SstPscdBelegPosition[0].Sachkonto);
            Assert.AreEqual(innenauftrag, pos1.SstPscdBelegPosition[0].Innenauftrag);
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Löscht einen Beleg
        /// </summary>
        /// <param name="unitOfwork"></param>
        /// <param name="beleg"></param>
        private void DeleteBeleg(IUnitOfWork unitOfwork, KbuBeleg beleg)
        {
            //belegNew.KbuBelegPosition.ToList().ForEach(x => DeleteBelegPosition(unitOfwork, x));
            foreach (var belegPosition in beleg.KbuBelegPosition.ToList())
            {
                DeleteBelegPosition(unitOfwork, belegPosition);
            }

            //Kreditoren löschen
            foreach (var belegKreditor in beleg.KbuBelegKreditor.ToList())
            {
                DeleteBelegKreditor(unitOfwork, belegKreditor);
            }

            var repository = UnitOfWork.GetRepository<KbuBeleg>(unitOfwork);
            var belegNew = repository
                           .Where(entity => entity.KbuBelegID == beleg.KbuBelegID)
                           .Include(x => x.KbuBelegPosition)
                           .Select(entity => entity).Single();

            belegNew.MarkAsDeleted();
            repository.ApplyChanges(belegNew);
            unitOfwork.SaveChanges();
        }

        /// <summary>
        /// Löscht einen BelegKreditor
        /// </summary>
        /// <param name="unitOfwork"></param>
        /// <param name="kreditor"></param>
        private void DeleteBelegKreditor(IUnitOfWork unitOfwork, Kiss.Model.KbuBelegKreditor kreditor)
        {
            var repository = UnitOfWork.GetRepository<Kiss.Model.KbuBelegKreditor>(unitOfwork);
            var tmpBelegKreditor = repository
                .Where(x => x.KbuBelegKreditorID == kreditor.KbuBelegKreditorID)
                .Select(x => x).Single();
            tmpBelegKreditor.MarkAsDeleted();
            repository.ApplyChanges(tmpBelegKreditor);
            unitOfwork.SaveChanges();
        }

        /// <summary>
        /// Löscht BelegPositionen
        /// </summary>
        /// <param name="unitOfwork"></param>
        /// <param name="belegPosition"></param>
        private void DeleteBelegPosition(IUnitOfWork unitOfwork, KbuBelegPosition belegPosition)
        {
            var repository = UnitOfWork.GetRepository<KbuBelegPosition>(unitOfwork);
            var tmpBelegPosition = repository
                .Where(x => x.KbuBelegPositionID == belegPosition.KbuBelegPositionID)
                .Select(x => x).Single();
            tmpBelegPosition.MarkAsDeleted();
            repository.ApplyChanges(tmpBelegPosition);
            unitOfwork.SaveChanges();
        }

        #endregion

        #endregion
    }
}