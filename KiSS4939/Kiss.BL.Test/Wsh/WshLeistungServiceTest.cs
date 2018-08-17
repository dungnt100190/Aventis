using System;
using System.Linq;
using System.Transactions;

using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Kiss.BL.Kbu;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class WshLeistungServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly BaPersonHelper _personHelper = new BaPersonHelper();
        private readonly XUserHelper _userHelper = new XUserHelper();
        private readonly WshHaushaltPersonHelper _haushaltHelper = new WshHaushaltPersonHelper();
        private readonly WshGrundbudgetHelper _grundbudgetHelper = new WshGrundbudgetHelper();
        private readonly KbuBelegHelper _belegHelper = new KbuBelegHelper();
        private readonly List<KbuBeleg> _belegeCreated = new List<KbuBeleg>();
        #endregion

        #region Private Fields

        private BaPerson _baPerson;
        private XUser _user;
        private FaLeistung _faLeistung;

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
            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                IUnitOfWork unitOfWork = UnitOfWork.GetNew;
                _baPerson = _personHelper.Create(unitOfWork);
                _user = _userHelper.GetOrCreate(unitOfWork);

                transaction.Complete();
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (var transaction = new TransactionScope())
            {
                IUnitOfWork unitOfWork = UnitOfWork.GetNew;
                var repositoryHaushalt = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);
                var repositoryBelege = UnitOfWork.GetRepository<KbuBeleg>(unitOfWork);
                var repository = UnitOfWork.GetRepository<FaLeistung>(unitOfWork);

                //Durch den Serviceaufruf wurde eine Leistung und ein Haushalt erstellt.
                if (_faLeistung != null)
                {
                    var query = from x in repositoryHaushalt
                                where x.FaLeistungID == _faLeistung.FaLeistungID
                                select x;
                    var list = query.ToList();
                    list.ForEach(x => x.MarkAsDeleted());
                    list.ForEach(repositoryHaushalt.ApplyChanges);
                    _faLeistung.MarkAsDeleted();
                    repository.ApplyChanges(_faLeistung);
                }
                unitOfWork.SaveChanges();

                _haushaltHelper.Delete(unitOfWork);
                _belegeCreated.ForEach(x => KbuBelegHelper.DeleteBeleg(unitOfWork, x));
                unitOfWork.SaveChanges();

                //_belegHelper.Delete(unitOfWork);
                _grundbudgetHelper.Delete(unitOfWork);
                _personHelper.Delete(unitOfWork);
                _userHelper.Delete(unitOfWork);

                transaction.Complete();
            }
        }

        [TestMethod]
        public void InsertLeistung_OK()
        {
            //Arrange
            //In case we are in Mock, we will not execute this test.
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<WshLeistungService>();
            var creationData = new WshCreateLeistungDTO();
            creationData.BaPersonId = _baPerson.BaPersonID;
            creationData.DatumVon = DateTime.Today;
            creationData.UserId = _user.UserID;


            // Act
            KissServiceResult serviceResult = service.InsertExistenzsicherungLeistung(null, creationData, out _faLeistung);

            // Assert
            Assert.IsTrue(serviceResult.IsOk);
        }

        [TestMethod]
        public void UpdateDatumVonWithoutGrundbudgetPositionen_OK()
        {
            // Arrange
            IUnitOfWork unitOfWorkArrange = UnitOfWork.GetNew;
            var haushaltPersonen = _haushaltHelper.Create(unitOfWorkArrange);
            var wshLeistung = haushaltPersonen.First().FaLeistung;
            var faLeistungID = haushaltPersonen.First().FaLeistungID;
            unitOfWorkArrange.SaveChanges();

            var service = Container.Resolve<WshLeistungService>();

            // Act
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            wshLeistung = service.GetById(unitOfWork, faLeistungID);
            wshLeistung.DatumVon = wshLeistung.DatumVon.AddMonths(1);
            var result = service.SaveData(unitOfWork, wshLeistung);

            // Assert
            Assert.IsTrue(result.IsOk);
        }


        [TestMethod]
        public void UpdateDatumVonWithGrundbudgetPositionen_OK()
        {

            // Arrange
            IUnitOfWork unitOfWorkArrange = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWorkArrange))
            {
                return;
            }
            _grundbudgetHelper.CreateGrundbudget(unitOfWorkArrange);
            int faLeistungID = _grundbudgetHelper.Leistung.FaLeistungID;
            unitOfWorkArrange.SaveChanges();

            var service = Container.Resolve<WshLeistungService>();

            // Act
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var wshLeistung = service.GetById(unitOfWork, faLeistungID);
            DateTime newDatumVon = wshLeistung.DatumVon.Day > 15 ? wshLeistung.DatumVon.AddDays(-10) : wshLeistung.DatumVon.AddDays(10);
            wshLeistung.DatumVon = newDatumVon;
            var result = service.SaveData(unitOfWork, wshLeistung);

            // Assert
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void UpdateDatumVonWithGrundbudgetPositionen_Error()
        {

            // Arrange
            IUnitOfWork unitOfWorkArrange = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWorkArrange))
            {
                return;
            }
            _grundbudgetHelper.CreateGrundbudget(unitOfWorkArrange);
            int faLeistungID = _grundbudgetHelper.Leistung.FaLeistungID;
            unitOfWorkArrange.SaveChanges();

            var service = Container.Resolve<WshLeistungService>();

            // Act
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var wshLeistung = service.GetById(unitOfWork, faLeistungID);
            wshLeistung.DatumVon = wshLeistung.DatumVon.AddMonths(1);
            var result = service.SaveData(unitOfWork, wshLeistung);

            // Assert
            Assert.IsTrue(result.IsError);
        }

        [TestMethod]
        public void UpdateDatumVonWithKbuBeleg_Error()
        {

            // Arrange
            IUnitOfWork unitOfWorkArrange = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWorkArrange))
            {
                return;
            }
            _grundbudgetHelper.CreateGrundbudget(unitOfWorkArrange);
            int faLeistungID = _grundbudgetHelper.Leistung.FaLeistungID;
            unitOfWorkArrange.SaveChanges();

            var auszahlService = Container.Resolve<WshAuszahlvorschlagService>();
            List<WshAuszahlvorschlagPositionDTO> offenePositionen;
            List<WshAuszahlvorschlagBelegDTO> belege;
            var result = auszahlService.GetAuszahlvorschlagPositionUndBeleg(unitOfWorkArrange, faLeistungID, null, false, out offenePositionen, out belege);

            var belegService = Container.Resolve<KbuBelegService>();
            List<KbuBeleg> belegeCreated;
            result += belegService.CreateBelege(unitOfWorkArrange, belege.Take(2).ToList(), out belegeCreated);
            _belegeCreated.AddRange(belegeCreated);

            //var beleg = _belegHelper.CreateBelegFreigegeben(unitOfWorkArrange);
            //int faLeistungID = beleg.KbuBelegPosition[1].FaLeistungID.Value;
            unitOfWorkArrange.SaveChanges();

            var service = Container.Resolve<WshLeistungService>();

            // Act
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var wshLeistung = service.GetById(unitOfWork, faLeistungID);
            DateTime newDatumVon = wshLeistung.DatumVon.Day > 15 ? wshLeistung.DatumVon.AddDays(-10) : wshLeistung.DatumVon.AddDays(10);
            wshLeistung.DatumVon = newDatumVon;
            result += service.SaveData(unitOfWork, wshLeistung);

            // Assert
            Assert.IsTrue(result.IsError);
        }

        #endregion
    }
}