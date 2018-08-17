using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Fs;
using Kiss.BL.Test.Helpers;
using Kiss.Infrastructure.IoC;
using Kiss.Model.DTO;
using Kiss.Model.DTO.Fs;

namespace Kiss.BL.Test.Fs
{
    /// <summary>
    /// Tests the Abfrageservice.
    /// </summary>
    [TestClass]
    public class FsDienstleistungAuswertungServiceTest : TransactionTestBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FsDienstleistungspaketHelper _dlpHelper = new FsDienstleistungspaketHelper();
        private readonly FaPhaseHelper _phaseHelper = new FaPhaseHelper();
        private readonly FsReduktionMitarbeiterHelper _reduktionMitarbeiterHelper = new FsReduktionMitarbeiterHelper();

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            ClassInitialize();
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            // TODO Einzelne Tests funktionieren nicht mit existierenden Daten, daher hier für jeden Test den Kontext leeren
            ClearObjectContext();

            base.TestInitialize();

            var unitOfWork = UnitOfWork.GetNew;

            var dlp = _dlpHelper.Create(unitOfWork);
            var phase = _phaseHelper.Create(unitOfWork);
            phase.FsDienstleistungspaket_Zugewiesen = dlp;
            _phaseHelper.ApplyChanges();
            _reduktionMitarbeiterHelper.CreateList(unitOfWork);
        }

        [ClassCleanup]
        public static new void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        public void Test_DlpLaufzeit_Fertig()
        {
            var service = Container.Resolve<FsDienstleistungAuswertungService>();

            // PhaseVon: 01.01.XXXX
            // PhaseBis: null
            // Laufzeit: 1 Monat -> 01.01.XXXX - 31.01.XXXX
            // Suche von 01.02.XXXX
            var pars = new FsDienstleistungAuswSearchParamDTO
            {
                DatumVon = new DateTime(DateTime.Today.Year, 2, 1),
                DatumBis = new DateTime(DateTime.Today.Year, 1, 1)
            };

            _phaseHelper.List[0].DatumBis = null;
            _phaseHelper.ApplyChanges();

            _dlpHelper.List[0].MaximaleLaufzeit = 1;
            _dlpHelper.ApplyChanges();

            var result = service.RunQuery(pars);
            var dto = result.Where(x => x.FaPhaseID == _phaseHelper.List[0].FaPhaseID).Single();

            // Suche beginnt nach Ende der DLP-Laufzeit, Stunden sind also 0
            Assert.AreEqual(0, dto.StundenZugewiesen);
        }

        [TestMethod]
        public void Test_DlpLaufzeit_Kuerzer()
        {
            var service = Container.Resolve<FsDienstleistungAuswertungService>();
            var pars = new FsDienstleistungAuswSearchParamDTO
            {
                DatumVon = new DateTime(DateTime.Today.Year - 1, 1, 1),
                DatumBis = new DateTime(DateTime.Today.Year + 1, 12, 31)
            };

            // Laufzeit des DLPs setzen (3.5 Monate)
            _phaseHelper.List[0].DatumBis = null;
            _phaseHelper.ApplyChanges();
            _dlpHelper.List[0].MaximaleLaufzeit = 3.5m;
            _dlpHelper.ApplyChanges();

            var result = service.RunQuery(pars);
            var dto = result.Where(x => x.FaPhaseID == _phaseHelper.List[0].FaPhaseID).Single();

            // Assert
            // Tage pro Monat: 30.4375
            // Phase von: 01.01.XXXX
            // DLP-Laufzeit bis: 15.03.XXXX
            // Anzahl Tage: 31 + 28 + 31 + 15 = 105
            // Total-Aufwand DLP: 7.25
            // Aufwand pro Tag: 7.25 / 30.4375.. = 0.2382..
            // Total Stunden: 0.2382.. * 105 = 25.01
            Assert.AreEqual(25, decimal.Floor(dto.StundenZugewiesen));
            Assert.IsTrue(dto.AbgelaufenDlpZugewiesen);
        }

        [TestMethod]
        public void Test_Gesamt_Dlp_Zugewiesen()
        {
            // TODO Test does not run on DB (existing data)
            TestUtils.AbortIfDbTest();

            // Neue DLPs und Phase erstellen
            var unitOfWork = UnitOfWork.GetNew;
            var dlp1 = _dlpHelper.Create(unitOfWork);
            var dlp2 = _dlpHelper.Create(unitOfWork);
            var phase = _phaseHelper.Create(unitOfWork);
            unitOfWork.SaveChanges();

            // DLPs zuordnen
            var oldUserId = phase.UserID;
            phase.UserID = _reduktionMitarbeiterHelper.Users[0].UserID;
            phase.FsDienstleistungspaket_Zugewiesen = dlp1;
            phase.FsDienstleistungspaket_Bedarf = dlp2;
            _phaseHelper.ApplyChanges();

            // Service und Suchparameter erstellen
            var service = Container.Resolve<FsDienstleistungAuswertungService>();
            var pars = new DateRangeSearchParamDTO
            {
                DatumVon = new DateTime(DateTime.Today.Year - 1, 1, 1),
                DatumBis = new DateTime(DateTime.Today.Year + 1, 12, 31)
            };

            // Abfrage
            IList<FsDienstleistungAuswertungGesamtDTO> list;
            var result = service.RunQuery(pars, out list);

            // Assert
            Assert.IsTrue(result.IsOkOrWarning, result);
            Assert.AreEqual(1, list.Count);

            var dto = list[0];
            Assert.AreEqual(1, dto.AnzahlDlpBedarf);
            Assert.AreEqual(1, dto.AnzahlDlpZugewiesen);
            Assert.AreEqual(1, dto.AnzahlPhasenIntake);
            Assert.AreEqual(0, dto.AnzahlPhasenBeratung);

            Assert.AreEqual(86, decimal.Floor(dto.StdZugewiesen));
            Assert.AreEqual(86, decimal.Floor(dto.StdBedarf));

            // Cleanup
            phase.UserID = oldUserId;
            _phaseHelper.ApplyChanges();
        }

        [TestMethod]
        public void Test_Gesamt_Nichts_Zugewiesen()
        {
            // TODO Test does not run on DB (existing data)
            TestUtils.AbortIfDbTest();

            // Service und Suchparameter erstellen
            var service = Container.Resolve<FsDienstleistungAuswertungService>();
            var pars = new DateRangeSearchParamDTO
                       {
                           DatumVon = new DateTime(DateTime.Today.Year - 1, 1, 1),
                           DatumBis = new DateTime(DateTime.Today.Year + 1, 12, 31)
                       };

            // Abfrage
            IList<FsDienstleistungAuswertungGesamtDTO> list;
            var result = service.RunQuery(pars, out list);

            // Assert
            Assert.IsTrue(result, result);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Test_KeineLaufzeit()
        {
            // Arrange
            var service = Container.Resolve<FsDienstleistungAuswertungService>();
            var pars = new FsDienstleistungAuswSearchParamDTO
            {
                DatumVon = new DateTime(DateTime.Today.Year - 1, 1, 1),
                DatumBis = new DateTime(DateTime.Today.Year + 1, 12, 31)
            };

            // Act
            var result = service.RunQuery(pars);
            var dto = result.Where(x => x.FaPhaseID == _phaseHelper.List[0].FaPhaseID).Single(); //There must be only one.

            // Assert
            // Es sind drei DL dem DLP zugewiesen.
            // 1. StandardAufwand 1.5
            // 2. StandardAufwand 2.75
            // 3. StandardAufwand 3
            // Der Phase ist für den Bedarf kein DLP zugewiesen, nur für Zugewiesen.
            // PhaseVon: 01.01.XXXX
            // PhaseBis: 31.12.XXXX
            Assert.AreEqual(0, dto.StundenBedarf);
            Assert.AreEqual(86, decimal.Floor(dto.StundenZugewiesen));
            Assert.IsFalse(dto.AbgelaufenDlpZugewiesen);
        }

        [TestMethod]
        public void Test_Phase_abgeschlossen_mit_Laufzeit()
        {
            var service = Container.Resolve<FsDienstleistungAuswertungService>();
            var pars = new FsDienstleistungAuswSearchParamDTO
            {
                DatumVon = new DateTime(DateTime.Today.Year - 1, 1, 1),
                DatumBis = new DateTime(DateTime.Today.Year + 1, 12, 31)
            };

            // DLP-Laufzeit: 3 Monate
            // Phase-Laufzeit: 12 Monate
            var dlp = _dlpHelper.List[0];
            dlp.MaximaleLaufzeit = 3;
            _dlpHelper.ApplyChanges();

            // Run
            var result = service.RunQuery(pars);
            var dto = result.Where(x => x.FaPhaseID == _phaseHelper.List[0].FaPhaseID).Single();

            // Assert
            Assert.AreEqual(86, decimal.Floor(dto.StundenZugewiesen));
            Assert.AreEqual(0, dto.StundenBedarf);
            Assert.IsFalse(dto.AbgelaufenDlpZugewiesen);
            Assert.IsFalse(dto.AbgelaufenDlpBedarf);
        }

        [TestMethod]
        public void Test_Zugewiesen_und_Bedarf()
        {
            // Neue DLPs und Phase erstellen
            var unitOfWork = UnitOfWork.GetNew;
            var dlp1 = _dlpHelper.Create(unitOfWork);
            var dlp2 = _dlpHelper.Create(unitOfWork);
            var phase = _phaseHelper.Create(unitOfWork);
            unitOfWork.SaveChanges();

            // DLPs zuordnen
            phase.FsDienstleistungspaket_Zugewiesen = dlp1;
            phase.FsDienstleistungspaket_Bedarf = dlp2;
            _phaseHelper.ApplyChanges();

            // Service und Suchparameter erstellen
            var service = Container.Resolve<FsDienstleistungAuswertungService>();
            var pars = new FsDienstleistungAuswSearchParamDTO
            {
                DatumVon = new DateTime(DateTime.Today.Year - 1, 1, 1),
                DatumBis = new DateTime(DateTime.Today.Year + 1, 12, 31)
            };

            // Abfrage
            var result = service.RunQuery(pars);
            var dto = result.Where(x => x.FaPhaseID == phase.FaPhaseID).Single();

            // Assert
            Assert.AreEqual(86, decimal.Floor(dto.StundenZugewiesen));
            Assert.AreEqual(86, decimal.Floor(dto.StundenBedarf));
        }

        #endregion
    }
}