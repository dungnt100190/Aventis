using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Kbu;
using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.BA;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the WshAbzugDTOService service.
    /// </summary>
    [TestClass]
    public class WshAbzugDTOServiceTest
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshAbzugHelper _abzugHelper = new WshAbzugHelper();
        private readonly WshGrundbudgetPositionHelper _grundbudgetHelper = new WshGrundbudgetPositionHelper();
        private readonly WshKategorieHelper _kategorieHelper = new WshKategorieHelper();
        private readonly KbuKontoHelper _kontoHelper = new KbuKontoHelper();
        private readonly Dictionary<string, QuestionAnswerOption> _questionsAndAnswers = new Dictionary<string, QuestionAnswerOption>();

        #endregion

        #region Private Fields

        private WshGrundbudgetPosition _gblPosition;
        private WshAbzugDTO _rueckerstattungGblDetails;
        private WshAbzugDTO _verrechnung;

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _transaction = new TransactionScope();

            try
            {
                var unitOfWork = UnitOfWork.GetNew;

                _kategorieHelper.FillWshKategorieMock(unitOfWork);
                _verrechnung = _abzugHelper.CreateAbzugVerrechnung(unitOfWork);
                _rueckerstattungGblDetails = _abzugHelper.CreateAbzugRueckerstattungGblDetails(unitOfWork);
                _gblPosition = _grundbudgetHelper.Create(unitOfWork, _verrechnung.WshAbzug.WshGrundbudgetPosition.FaLeistung);
            }
            catch (Exception)
            {
                _transaction.Dispose();
                throw;
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassCleanup();
        }

        private TransactionScope _transaction;

        [TestCleanup]
        public void TestCleanup()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
        }

        [TestMethod]
        public void Test_GetByFaLeistungId_OhneAbgeschlossene()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            var service = Container.Resolve<WshAbzugDTOService>();

            _verrechnung.WshAbzug.AbschlussDatum = DateTime.Now;
            _verrechnung.WshAbzug.AbschlussGrund = "Abjeschlossen halt";
            _verrechnung.WshAbzug.WshAbzugAbschlussAktionCode = (int)LOVsGenerated.WshAbzugAbschlussAktion.Keine;
            _verrechnung.WshAbzug.WshGrundbudgetPosition.FaelligAm = DateTime.Now;

            var result = service.SaveData(unitOfWork, _verrechnung, _questionsAndAnswers);

            Assert.IsTrue(result, result);

            // Act
            var list = service.GetByFaLeistungId(unitOfWork, _verrechnung.WshAbzug.WshGrundbudgetPosition.FaLeistungID, false);

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Test_GetByFaLeistungId_Position_Included()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            var service = Container.Resolve<WshAbzugDTOService>();

            // Act
            var result = service.GetByFaLeistungId(unitOfWork, _verrechnung.WshAbzug.WshGrundbudgetPosition.FaLeistungID);

            // Assert
            Assert.IsTrue(result.Count > 0);
            Assert.IsNotNull(result[0].WshAbzug);
            Assert.IsNotNull(result[0].WshAbzug.WshGrundbudgetPosition);
        }

        [TestMethod]
        public void Test_NewData_Position_Copy_RE_mit_Details()
        {
            // Arrange
            var service = Container.Resolve<WshAbzugDTOService>();

            // Act
            WshAbzugDTO dto;
            var result = service.NewData(_rueckerstattungGblDetails, out dto);

            // Assert
            Assert.IsTrue(result, result);
            Assert.IsNotNull(dto.WshAbzug);
            Assert.IsNotNull(dto.WshAbzug.WshGrundbudgetPosition);
            Assert.AreEqual(dto.WshAbzug.WshAbzugDetail.Count, dto.WshAbzug.WshAbzugDetail.Count);

            Assert.AreEqual(_rueckerstattungGblDetails.GblAbzugProzent, dto.GblAbzugProzent);
            Assert.AreEqual(_rueckerstattungGblDetails.GblAktuell, dto.GblAktuell);
            Assert.AreEqual(_rueckerstattungGblDetails.VoraussichtlicheDauer, dto.VoraussichtlicheDauer);

            Assert.AreEqual(_rueckerstattungGblDetails.WshAbzug.MonatlichWiederholend, dto.WshAbzug.MonatlichWiederholend);

            Assert.AreEqual(_rueckerstattungGblDetails.WshAbzug.WshGrundbudgetPosition.BetragMonatlich, dto.WshAbzug.WshGrundbudgetPosition.BetragMonatlich);
            Assert.AreEqual(_rueckerstattungGblDetails.WshAbzug.WshGrundbudgetPosition.BetragTotal, dto.WshAbzug.WshGrundbudgetPosition.BetragTotal);
            Assert.AreEqual(_rueckerstattungGblDetails.WshAbzug.WshGrundbudgetPosition.DatumVon, dto.WshAbzug.WshGrundbudgetPosition.DatumVon);
            Assert.AreEqual(_rueckerstattungGblDetails.WshAbzug.WshGrundbudgetPosition.DatumBis, dto.WshAbzug.WshGrundbudgetPosition.DatumBis);
            Assert.AreEqual(_rueckerstattungGblDetails.WshAbzug.WshGrundbudgetPosition.WshKategorie, dto.WshAbzug.WshGrundbudgetPosition.WshKategorie);
        }

        [TestMethod]
        public void Test_NewData_Position_Copy_Verrechnung()
        {
            // Arrange
            var service = Container.Resolve<WshAbzugDTOService>();

            // Act
            WshAbzugDTO dto;
            var result = service.NewData(_verrechnung, out dto);

            // Assert
            Assert.IsTrue(result, result);
            Assert.IsNotNull(dto.WshAbzug);
            Assert.IsNotNull(dto.WshAbzug.WshGrundbudgetPosition);
            Assert.AreEqual(dto.WshAbzug.WshAbzugDetail.Count, dto.WshAbzug.WshAbzugDetail.Count);

            Assert.AreEqual(_verrechnung.GblAbzugProzent, dto.GblAbzugProzent);
            Assert.AreEqual(_verrechnung.GblAktuell, dto.GblAktuell);
            Assert.AreEqual(_verrechnung.VoraussichtlicheDauer, dto.VoraussichtlicheDauer);

            Assert.AreEqual(_verrechnung.WshAbzug.AbschlussDatum, dto.WshAbzug.AbschlussDatum);
            Assert.AreEqual(_verrechnung.WshAbzug.AbschlussGrund, dto.WshAbzug.AbschlussGrund);
            Assert.AreEqual(_verrechnung.WshAbzug.WshAbzugAbschlussAktionCode, dto.WshAbzug.WshAbzugAbschlussAktionCode);
            Assert.AreEqual(_verrechnung.WshAbzug.MonatlichWiederholend, dto.WshAbzug.MonatlichWiederholend);

            Assert.AreEqual(_verrechnung.WshAbzug.WshGrundbudgetPosition.BetragMonatlich, dto.WshAbzug.WshGrundbudgetPosition.BetragMonatlich);
            Assert.AreEqual(_verrechnung.WshAbzug.WshGrundbudgetPosition.BetragTotal, dto.WshAbzug.WshGrundbudgetPosition.BetragTotal);
            Assert.AreEqual(_verrechnung.WshAbzug.WshGrundbudgetPosition.DatumVon, dto.WshAbzug.WshGrundbudgetPosition.DatumVon);
            Assert.AreEqual(_verrechnung.WshAbzug.WshGrundbudgetPosition.DatumBis, dto.WshAbzug.WshGrundbudgetPosition.DatumBis);
            Assert.AreEqual(_verrechnung.WshAbzug.WshGrundbudgetPosition.WshKategorie, dto.WshAbzug.WshGrundbudgetPosition.WshKategorie);
        }

        [TestMethod]
        public void Test_NewData_Position_Is_Set()
        {
            // Arrange
            var service = Container.Resolve<WshAbzugDTOService>();

            // Act
            WshAbzugDTO dto;
            var result = service.NewData(out dto);

            // Assert
            Assert.IsTrue(result, result);
            Assert.IsNotNull(dto.WshAbzug);
            Assert.IsNotNull(dto.WshAbzug.WshGrundbudgetPosition);
        }

        [TestMethod]
        public void Test_ProzentGbl_OhneDetail()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            var service = Container.Resolve<WshAbzugDTOService>();
            var gblKonto = _kontoHelper.Create(unitOfWork);

            _verrechnung.WshAbzug.WshGrundbudgetPosition.KbuKonto = gblKonto;
            var result = service.SaveData(unitOfWork, _verrechnung, _questionsAndAnswers);
            result.Assert();

            // Act
            service.SetDtoProperties(unitOfWork, _verrechnung);

            //Assert
            Assert.AreEqual(10, _verrechnung.GblAbzugProzent);
        }

        [TestMethod]
        public void SetVoraussichtlicheDauer_VerrechnungMitPositionBetrag0_Dauer1MonatVerlaengern()
        {
            //Dieser Testfall scheint in der Mock-Implementation nicht korrekt zu funktionieren...
            //--> nur gegen die DB ausführen
            var unitOfWork = UnitOfWork.GetNew;
            if(!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<WshAbzugDTOService>();
            var servicePositionAbzug = Container.Resolve<WshPositionAbzugDTOService>();

            var position = _verrechnung.WshAbzug.WshGrundbudgetPosition;

            position.BetragTotal = 25;
            position.BetragMonatlich = 10;

            // Aktueller Monat
            position.DatumVon = FirstDayOf(DateTime.Today);

            // GB-Position speichern (achtung: das generiert MonatsBudgetPositionen!)
            var result = service.SaveData(unitOfWork, _verrechnung, _questionsAndAnswers);

            result.Assert();

            // Erste Position holen und Betrag = 0 setzen
            var posSvc = Container.Resolve<WshPositionService>();
            var wshPosition = posSvc.GetByWshGrundbudgetPositionID(unitOfWork, position.WshGrundbudgetPositionID).First();

            wshPosition.Betrag = 0;

            result = posSvc.SaveData(unitOfWork, wshPosition);
            result.Assert();

            // Positionen im Abzug laden
            _verrechnung.WshPosition = servicePositionAbzug.GetByWshGrundbudgetPositionId(
                null,
                _verrechnung.WshAbzug.WshGrundbudgetPosition.WshGrundbudgetPositionID,
                _verrechnung.WshAbzug.WshGrundbudgetPosition.BetragTotal);

            // Act
            service.SetVoraussichtlicheDauer(_verrechnung);

            // Assert
            // Dauer: 4 Monate
            Assert.AreEqual(_verrechnung.WshAbzug.WshGrundbudgetPosition.DatumVon.AddMonths(3), _verrechnung.VoraussichtlicheDauer);
        }

        [TestMethod]
        public void Test_VoraussichtlicheDauer_Saldo_Verrechnung_OhneBelege()
        {
            // Arrange
            var unitOfWork = UnitOfWork.GetNew;
            var service = Container.Resolve<WshAbzugDTOService>();

            // Act
            var position = _verrechnung.WshAbzug.WshGrundbudgetPosition;
            position.BetragTotal = 500;
            position.BetragMonatlich = 50;
            position.DatumVon = new DateTime(2010, 1, 1);
            position.DatumBis = null;

            service.SetDtoProperties(unitOfWork, _verrechnung);

            // Assert
            // Dauer: +10 Monate
            Assert.AreEqual(new DateTime(2010, 10, 1), _verrechnung.VoraussichtlicheDauer);

            // Saldo: Keine Belege --> Total
            Assert.AreEqual(500, _verrechnung.Saldo);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void SaveData_WithQuestion_ThrowException()
        {
            // Arrange
            var service = Container.Resolve<WshAbzugDTOService>();

            // Act
            WshAbzugDTO dto = null;
            service.SaveData(null, dto);

            // Assert
            Assert.IsFalse(true);
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static DateTime FirstDayOf(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        #endregion

        #endregion
    }
}