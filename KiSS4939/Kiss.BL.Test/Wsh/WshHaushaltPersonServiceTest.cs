using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Test;
using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class WshHaushaltPersonServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshHaushaltPersonHelper _haushaltPersonHelper = new WshHaushaltPersonHelper();

        //private List<TEntity> _entities;
        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();
        private readonly BaPersonHelper _personHelper = new BaPersonHelper();

        private const string CREATOR = "UnitTester";

        #endregion

        #region Private Fields

        private BaPerson _baPerson;
        private List<BaPerson> _baPersons;
        private BaWohnsituation _baWohnsituation;
        private BaWohnsituationPerson _baWohnsituationPerson;
        private FaLeistung _faLeistung;
        private FaLeistung _faLeistungHaushalt;
        private IList<WshHaushaltPerson> _haushaltPersonen;

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

                /*
                    * P0  +-------------------------
                    *     +-------------------------
                    * P1        +-----+
                    *           +-----+
                    * ----+-----+-----+-----+-----+--->
                    *    1.1.  1.2.  1.3.  1.4.  1.5.
                    */

                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;

                _faLeistung = _leistungHelper.Create(unitOfWork);
                _baPerson = _personHelper.Create(unitOfWork);
                _haushaltPersonen = _haushaltPersonHelper.Create(unitOfWork, out _baPersons, out _baWohnsituation,
                    out _baWohnsituationPerson, out _faLeistungHaushalt);

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
                var unitOfWork = UnitOfWork.GetNew;
                _haushaltPersonHelper.Delete(unitOfWork);
            }
        }

        [TestMethod]
        public void AddPersonToHaushalt_DatumBis_OK()
        {
            //Arrange
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();
            var unitOfWork = UnitOfWork.GetNew;

            //Act
            //- Füge Person vom 01.01. bis 28.02. hinzu
            var haushaltPerson = new WshHaushaltPerson
            {
                FaLeistung = _faLeistung,
                BaPerson = _baPerson,
                DatumVon = new DateTime(2010, 01, 01),
                DatumBis = new DateTime(2010, 02, 28),
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
                Unterstuetzt = true
            };

            var result = haushaltService.SaveData(unitOfWork, haushaltPerson);

            //add it to delete it again in TestCleanup()
            _haushaltPersonen.Add(haushaltPerson);

            Assert.IsTrue(result.IsOk, result.ToString());

            //- Füge person per 01.04. erneut zum Haushalt hinzu
            haushaltPerson = new WshHaushaltPerson
            {
                FaLeistung = _faLeistung,
                BaPerson = _baPerson,
                DatumVon = new DateTime(2010, 04, 01),
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
                Unterstuetzt = true
            };

            result = haushaltService.SaveData(unitOfWork, haushaltPerson);

            //add it to delete it again in TestCleanup()
            _haushaltPersonen.Add(haushaltPerson);

            //Assert
            Assert.IsTrue(result.IsOk, result.ToString());
        }

        [TestMethod]
        public void AddPersonToHaushalt_OK()
        {
            //Arrange
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();
            var unitOfWork = UnitOfWork.GetNew;

            //Act
            var haushaltPerson = new WshHaushaltPerson
            {
                FaLeistung = _faLeistung,
                BaPerson = _baPerson,
                DatumVon = new DateTime(2010, 01, 01),
                DatumBis = new DateTime(2010, 02, 28),
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
                Unterstuetzt = true
            };

            var result = haushaltService.SaveData(unitOfWork, haushaltPerson);

            //add it to delete it again in TestCleanup()
            _haushaltPersonen.Add(haushaltPerson);

            //Assert
            Assert.IsTrue(result.IsOk, result.ToString());
        }

        [TestMethod]
        public void AddPersonToHaushalt_Ueberschneidung_Error()
        {
            //Arrange
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();
            var unitOfWork = UnitOfWork.GetNew;

            //Act
            //- Füge Person vom 01.01. bis 28.02. hinzu
            var haushaltPerson = new WshHaushaltPerson
            {
                FaLeistung = _faLeistung,
                BaPerson = _baPerson,
                DatumVon = new DateTime(2010, 01, 01),
                DatumBis = new DateTime(2010, 02, 28),
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
                Unterstuetzt = true
            };

            var result = haushaltService.SaveData(unitOfWork, haushaltPerson);

            //add it to delete it again in TestCleanup()
            _haushaltPersonen.Add(haushaltPerson);

            Assert.IsTrue(result.IsOk, result.ToString());

            //TODO: aktivieren, wenn das Problem mit dem Objekt nach dem fehlerhaften Speichern gelöst ist
            //- Füge person per 01.02 erneut zum Haushalt hinzu
            //haushaltPerson = new WshHaushaltPerson
            //{
            //    FaLeistung = _faLeistung,
            //    BaPerson = _baPerson,
            //    DatumVon = new DateTime(2010, 02, 01),
            //    Creator = CREATOR,
            //    Created = DateTime.Now,
            //    Modifier = CREATOR,
            //    Modified = DateTime.Now,
            //    Unterstuetzt = true
            //};

            //result = haushaltService.SaveData(unitOfWork, haushaltPerson); //schlägt fehl -> TestCleanup kann nicht aufräumen

            ////Assert
            //Assert.IsTrue(result.IsError, result.ToString());
        }

        [TestMethod]
        public void CreateHaushaltFromAdresse_Ok()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            //Arrage
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();

            //Act
            haushaltService.CreateHaushaltFromAdresse(null, _faLeistungHaushalt);

            //Assert
            unitOfWork = UnitOfWork.GetNew;
            IRepository<WshHaushaltPerson> repository = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);
            var result = from x in repository
                         where x.FaLeistungID == _faLeistungHaushalt.FaLeistungID
                         select x;
            Assert.AreEqual(3, result.Count()); //2 Waren schon da, 1 wurde im Service kreiert.
        }

        [TestMethod]
        public void CreateHaushaltFromWohnsituation_Ok()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            //Arange
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();

            //Act
            haushaltService.CreateHaushaltFromWohnsituation(null, _faLeistungHaushalt);

            //Assert
            unitOfWork = UnitOfWork.GetNew;
            IRepository<WshHaushaltPerson> repository = UnitOfWork.GetRepository<WshHaushaltPerson>(unitOfWork);
            var result = from x in repository
                         where x.FaLeistungID == _faLeistungHaushalt.FaLeistungID
                         select x;
            Assert.AreEqual(3, result.Count()); //2 Waren schon da, 1 wurde im Service kreiert.
        }

        [TestMethod]
        public void GetHaushaltPersonen_OK()
        {
            //Arrange
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();
            var unitOfWork = UnitOfWork.GetNew;

            //Act
            var result = haushaltService.GetHaushaltPersonen(unitOfWork, _faLeistungHaushalt.FaLeistungID);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);

            Assert.AreEqual(_faLeistungHaushalt.FaLeistungID, result[0].FaLeistungID);
            Assert.AreEqual(_baPersons[0].BaPersonID, result[0].BaPersonID);
            Assert.AreEqual(new DateTime(2008, 01, 01), result[0].DatumVon);

            Assert.AreEqual(_faLeistungHaushalt.FaLeistungID, result[1].FaLeistungID);
            Assert.AreEqual(_baPersons[1].BaPersonID, result[1].BaPersonID);
            Assert.AreEqual(new DateTime(2010, 02, 01), result[1].DatumVon);
            Assert.AreEqual(new DateTime(2010, 02, 28), result[1].DatumBis);
        }

        [TestMethod]
        public void GetHaushaltPersonen_Stichtag1_DatumVon_OK()
        {
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();
            var unitOfWork = UnitOfWork.GetNew;

            //Act
            var result = haushaltService.GetHaushaltPersonen(unitOfWork, _faLeistungHaushalt.FaLeistungID, new DateTime(2010, 01, 15));

            //Assert
            //On 15.02.2010, only P0 is in the Haushalt
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            Assert.AreEqual(_faLeistungHaushalt.FaLeistungID, result[0].FaLeistungID);
            Assert.AreEqual(_baPersons[0].BaPersonID, result[0].BaPersonID);
        }

        [TestMethod]
        public void GetHaushaltPersonen_Stichtag2_DatumVon_OK()
        {
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();
            var unitOfWork = UnitOfWork.GetNew;

            //Act
            var result = haushaltService.GetHaushaltPersonen(unitOfWork, _faLeistungHaushalt.FaLeistungID, new DateTime(2010, 02, 15));

            //Assert
            //On 15.02.2010, P0 and P1 are in the Haushalt
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);

            Assert.AreEqual(_faLeistungHaushalt.FaLeistungID, result[0].FaLeistungID);
            Assert.AreEqual(_baPersons[0].BaPersonID, result[0].BaPersonID);

            Assert.AreEqual(_faLeistungHaushalt.FaLeistungID, result[1].FaLeistungID);
            Assert.AreEqual(_baPersons[1].BaPersonID, result[1].BaPersonID);
        }

        [TestMethod]
        public void GetHaushaltPersonen_Stichtag_DatumBis_OK()
        {
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();
            var unitOfWork = UnitOfWork.GetNew;

            //Act
            var result = haushaltService.GetHaushaltPersonen(unitOfWork, _faLeistungHaushalt.FaLeistungID, new DateTime(2010, 03, 15));

            //Assert
            //On 15.03.2010, only P0 is in the Haushalt
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            Assert.AreEqual(_faLeistungHaushalt.FaLeistungID, result[0].FaLeistungID);
            Assert.AreEqual(_baPersons[0].BaPersonID, result[0].BaPersonID);
        }

        [TestMethod]
        public void GetHaushaltsGroesse_OK()
        {
            //Arrange
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();

            //Act
            int result = haushaltService.GetHaushaltsGroesse(null, _faLeistungHaushalt.FaLeistungID);

            //Assert
        }

        [TestMethod]
        public void GetUnterstuetzungsEinheitsGroesse_OK()
        {
            //Arrange
            var haushaltService = Container.Resolve<WshHaushaltPersonService>();

            //Act
            int result = haushaltService.GetUnterstuetzungsEinheitsGroesse(null, _faLeistungHaushalt.FaLeistungID);

            //Assert
        }

        #endregion
    }
}