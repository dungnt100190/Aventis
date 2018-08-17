using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.BL.Wsh;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Kbu;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Kbu;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class WshKbuKontoServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CREATOR = "UnitTester";

        #endregion

        #region Private Fields

        private List<KbuKonto> _entities;
        private List<WshKontoAttribut> _addedAttributes;
        private WshKategorie_KbuKonto _kontoKategorie;

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
                var unitOfWork = UnitOfWork.GetNew;
                var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);

                _entities = new List<KbuKonto>
                {
                    new KbuKonto()
                    {
                        KontoNr = "12",
                        Name = "Geldfresserli",
                        KbuKontoklasseCode = (int) LOVsGenerated.KbuKontoklasse.Aufwand,
                        Creator = CREATOR,
                        Created = new DateTime(2010, 01, 01),
                        Modifier = CREATOR,
                        Modified = new DateTime(2010, 01, 01),
                    },
                    new KbuKonto()
                    {
                        KontoNr = "88",
                        Name = "Bürobedarf",
                        KbuKontoklasseCode = (int) LOVsGenerated.KbuKontoklasse.Aufwand,
                        Creator = CREATOR,
                        Created = new DateTime(2010, 01, 01),
                        Modifier = CREATOR,
                        Modified = new DateTime(2010, 01, 01),
                    },
                    new KbuKonto()
                    {
                        KontoNr = "99",
                        Name = "Verpflegung",
                        KbuKontoklasseCode = (int) LOVsGenerated.KbuKontoklasse.Aufwand,
                        Creator = CREATOR,
                        Created = new DateTime(2010, 01, 01),
                        Modifier = CREATOR,
                        Modified = new DateTime(2010, 01, 01),
                    }
                };

                _entities.ForEach(x => repository.ApplyChanges(x));
                unitOfWork.SaveChanges();
                _entities.ForEach(x => x.AcceptChanges());

                _kontoKategorie = new WshKategorie_KbuKonto
                {
                    KbuKonto = _entities[0],
                    KbuKontoID = _entities[0].KbuKontoID,
                    WshKategorieID = (int)LOVsGenerated.WshKategorie.Ausgabe,
                    NurMitSpezialrecht = false,
                    Creator = CREATOR,
                    Created = new DateTime(2010, 01, 01),
                    Modifier = CREATOR,
                    Modified = new DateTime(2010, 01, 01),
                };
                var repositoryKontoKat = UnitOfWork.GetRepository<WshKategorie_KbuKonto>(unitOfWork);
                repositoryKontoKat.ApplyChanges(_kontoKategorie);
                unitOfWork.SaveChanges();

                _addedAttributes = new List<WshKontoAttribut>{
                    new WshKontoAttribut
                    {
                        KbuKonto = _entities[0],
                        KbuKontoID = _entities[0].KbuKontoID,
                        IstGrundbudgetAktiv = true,
                        IstLeistungWsh = true,
                        IstLeistungWshStationaer = true,
                        IstMonatsbudgetAktiv = false,
                        SysEditModeCode_BetrifftPerson = (int)LOVsGenerated.SysEditMode.ReadOnly,
                        Creator = CREATOR,
                        Created = new DateTime(2010, 01, 01),
                        Modifier = CREATOR,
                        Modified = new DateTime(2010, 01, 01),
                    }};
                var repositoryKontoAttr = UnitOfWork.GetRepository<WshKontoAttribut>(unitOfWork);

                _addedAttributes.ForEach(repositoryKontoAttr.ApplyChanges);
                unitOfWork.SaveChanges();
                _addedAttributes.ForEach(x => x.AcceptChanges());

                unitOfWork.SaveChanges();

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

                var repositoryKontoAttr = UnitOfWork.GetRepository<WshKontoAttribut>(unitOfWork);
                _addedAttributes.ForEach(x => x.MarkAsDeleted());
                _addedAttributes.ForEach(repositoryKontoAttr.ApplyChanges);
                unitOfWork.SaveChanges();

                var repositoryKontoKat = UnitOfWork.GetRepository<WshKategorie_KbuKonto>(unitOfWork);
                _kontoKategorie.MarkAsDeleted();
                repositoryKontoKat.ApplyChanges(_kontoKategorie);
                unitOfWork.SaveChanges();

                // Delete the temporary test objects
                unitOfWork = UnitOfWork.GetNew; // Hack: CreateAttributeIfNecessaryAndSave_Ok schlägt sonst unerklärlicherweise fehl
                var repository = UnitOfWork.GetRepository<KbuKonto>(unitOfWork);
                _entities.ForEach(x => x.MarkAsDeleted());
                _entities.ForEach(repository.ApplyChanges);
                unitOfWork.SaveChanges();

                transaction.Complete();
            }
        }

        [TestMethod]
        public void SearchKonto_Asterix()
        {
            // Arrange
            var service = Container.Resolve<WshKbuKontoService>();
            KbuKontoSearchDTO serachDTO = new KbuKontoSearchDTO
            {
                LeistungWsh = true,
                Datum = DateTime.Today,
                LeistungWshStationaer = false,
                Grundbudget = true,
                WshKategorie = LOVsGenerated.WshKategorie.Ausgabe,
                SearchString = "*",
            };

            //Act
            IList<KbuKonto> result = service.SearchKonto(null, serachDTO);

            //Assert
            int count = result.ToList().Where(x => x.KbuKontoID == _entities[0].KbuKontoID).Count();
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void SearchKonto_Basic_Found()
        {
            // Arrange
            var service = Container.Resolve<WshKbuKontoService>();
            KbuKontoSearchDTO serachDTO = new KbuKontoSearchDTO
            {
                LeistungWsh = true,
                Datum = DateTime.Today,
                LeistungWshStationaer = false,
                Grundbudget = true,
                WshKategorie = LOVsGenerated.WshKategorie.Ausgabe,
            };

            //Act
            IList<KbuKonto> result = service.SearchKonto(null, serachDTO);

            //Assert
            int count = result.ToList().Where(x => x.KbuKontoID == _entities[0].KbuKontoID).Count();
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void SearchKonto_Basic_NotFound()
        {
            // Arrange
            var service = Container.Resolve<WshKbuKontoService>();
            KbuKontoSearchDTO serachDTO = new KbuKontoSearchDTO
            {
                LeistungWsh = true,
                Datum = DateTime.Today,
                LeistungWshStationaer = false,
                Grundbudget = true,
                WshKategorie = LOVsGenerated.WshKategorie.Einnahme,
            };

            //Act
            IList<KbuKonto> result = service.SearchKonto(null, serachDTO);

            //Assert
            int count = result.ToList().Where(x => x.KbuKontoID == _entities[0].KbuKontoID).Count();
            Assert.IsTrue(count == 0);
        }

        [TestMethod]
        public void SearchKonto_KontoName()
        {
            // Arrange
            var service = Container.Resolve<WshKbuKontoService>();
            KbuKontoSearchDTO serachDTO = new KbuKontoSearchDTO
            {
                LeistungWsh = true,
                Datum = DateTime.Today,
                LeistungWshStationaer = false,
                Grundbudget = true,
                WshKategorie = LOVsGenerated.WshKategorie.Ausgabe,
                SearchString = "Geldfresserli",
            };

            //Act
            IList<KbuKonto> result = service.SearchKonto(null, serachDTO);

            //Assert
            int count = result.ToList().Where(x => x.KbuKontoID == _entities[0].KbuKontoID).Count();
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void SearchKonto_KontoNummerUndName()
        {
            // Arrange
            var service = Container.Resolve<WshKbuKontoService>();
            KbuKontoSearchDTO serachDTO = new KbuKontoSearchDTO
            {
                LeistungWsh = true,
                Datum = DateTime.Today,
                LeistungWshStationaer = false,
                Grundbudget = true,
                WshKategorie = LOVsGenerated.WshKategorie.Ausgabe,
                SearchString = "12 Geldfresserli",
            };

            //Act
            IList<KbuKonto> result = service.SearchKonto(null, serachDTO);

            //Assert
            int count = result.ToList().Where(x => x.KbuKontoID == _entities[0].KbuKontoID).Count();
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void SearchKonto_Number()
        {
            // Arrange
            var service = Container.Resolve<WshKbuKontoService>();
            KbuKontoSearchDTO serachDTO = new KbuKontoSearchDTO
            {
                LeistungWsh = true,
                Datum = DateTime.Today,
                LeistungWshStationaer = false,
                Grundbudget = true,
                WshKategorie = LOVsGenerated.WshKategorie.Ausgabe,
                SearchString = "12",
            };

            //Act
            IList<KbuKonto> result = service.SearchKonto(null, serachDTO);

            //Assert
            int count = result.ToList().Where(x => x.KbuKontoID == _entities[0].KbuKontoID).Count();
            Assert.IsTrue(count > 0);
        }

        [TestMethod]
        public void IsValidKbuKontoWshKategorieKombination_OK()
        {
            // Arrange
            var service = Container.Resolve<WshKbuKontoService>();

            KbuKontoValidationDTO validationDTO = new KbuKontoValidationDTO
            {
                DatumVon = new DateTime(2011, 1, 1),
                DatumBis = new DateTime(2011, 1, 31),
                LeistungWsh = true,
                Grundbudget = true,
                KbuKontoID = _entities[0].KbuKontoID,
                WshKategorieID = (int)LOVsGenerated.WshKategorie.Ausgabe,
                PersonAusgewaehlt = true,
            };

            //Act
            var result = service.IsValidKbuKontoWshKategorieKombination(null, validationDTO);

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void IsValidKbuKontoWshKategorieKombination_NOK()
        {
            // Arrange
            var service = Container.Resolve<WshKbuKontoService>();
            KbuKontoValidationDTO validationDTO = new KbuKontoValidationDTO
            {
                DatumVon = new DateTime(2011, 1, 1),
                DatumBis = new DateTime(2011, 1, 31),
                LeistungWsh = true,
                Grundbudget = true,
                KbuKontoID = _entities[0].KbuKontoID,
                WshKategorieID = (int)LOVsGenerated.WshKategorie.Einnahme,
            };


            //Act
            var result = service.IsValidKbuKontoWshKategorieKombination(null, validationDTO);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetSysEditModePersonBetrifft_Ok()
        {
            // Arrange
            var service = Container.Resolve<WshKbuKontoService>();

            //Act
            LOVsGenerated.SysEditMode editMode = service.GetSysEditModeBetrifftPerson(null, _entities[0].KbuKontoID, null, null);

            //Asssert
            //KOA ist nicht gequoted -> Zwingend.
            Assert.AreEqual(LOVsGenerated.SysEditMode.Required, editMode);
        }

        [TestMethod]
        public void GetAllKontoCreateAttributeIfNecessary_Ok()
        {
            // Arrange
            var service = Container.Resolve<WshKontoAttributService>();

            //Act
            var konti = service.GetAllWshKontoAttributeAddIfNotExist(null);

            //Asssert
            var addedAttribute = konti.SingleOrDefault(k => k.KbuKontoID == _entities[1].KbuKontoID);
            Assert.IsNotNull(addedAttribute);
            var addedAttribute2 = konti.SingleOrDefault(k => k.KbuKontoID == _entities[2].KbuKontoID);
            Assert.IsNotNull(addedAttribute2);
        }

        [TestMethod]
        public void CreateAttributeIfNecessaryAndSave_Ok()
        {
            if (!TestUtils.IsDbTest(null))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<WshKontoAttributService>();

            //Act
            var unitOfWork = UnitOfWork.GetNew;

            var konti = service.GetAllWshKontoAttributeAddIfNotExist(unitOfWork);
            _addedAttributes.AddRange(konti.Where(x => x.ChangeTracker.State == ObjectState.Added));

            unitOfWork.SaveChanges();

            //Assert
            var addedAttribute = service.GetKontoAttributByKontoId(null, _entities[1].KbuKontoID);
            Assert.IsNotNull(addedAttribute);
            var addedAttribute2 = service.GetKontoAttributByKontoId(null, _entities[2].KbuKontoID);
            Assert.IsNotNull(addedAttribute2);
        }

        #endregion
    }
}