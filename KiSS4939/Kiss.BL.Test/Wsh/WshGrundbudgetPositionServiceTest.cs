using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Kiss.Interfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Kbu;
using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Enumeration;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.BA;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the WshGrundbudgetPosition service.
    /// </summary>
    [TestClass]
    public class WshGrundbudgetPositionServiceTest
    {
        #region Fields

        #region Private Static Fields

        private static readonly Dictionary<string, QuestionAnswerOption> _questionsAndAnswers = new Dictionary<string, QuestionAnswerOption>();

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly WshGrundbudgetHelper _grundbudgetHelper = new WshGrundbudgetHelper();
        private readonly WshKategorieHelper _kategorieHelper = new WshKategorieHelper();

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize(DatabaseTestUtil.CONNECTION_STRING_NAME_KISS5);
            _questionsAndAnswers["GrauePositionenLoeschen"] = new QuestionAnswerOption(true, "Ja");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;
                _grundbudgetHelper.CreateGrundbudget(unitOfWork);

                // persist
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
                _grundbudgetHelper.Delete(unitOfWork);
                transaction.Complete();
            }
        }

        [TestMethod]
        public void DeleteData_MitDebitor()
        {
            if (!TestUtils.IsDbTest(UnitOfWork.GetNew))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            service.DeleteData(null, _grundbudgetHelper.PositionDebitor);
            _grundbudgetHelper.Entities.Remove(_grundbudgetHelper.PositionDebitor);
            _grundbudgetHelper.DebitorList.Remove(_grundbudgetHelper.PositionDebitor.WshGrundbudgetPositionDebitor.FirstOrDefault());

            // Assert
            var unitOfWork = UnitOfWork.GetNew;
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);
            var pos = repository.Where(x => x.WshGrundbudgetPositionID == _grundbudgetHelper.PositionDebitor.WshGrundbudgetPositionID).FirstOrDefault();
            Assert.IsTrue(pos == null);
        }

        [TestMethod]
        public void DeleteData_MitKreditor()
        {
            if (!TestUtils.IsDbTest(UnitOfWork.GetNew))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            service.DeleteData(null, _grundbudgetHelper.Position);
            _grundbudgetHelper.Entities.Remove(_grundbudgetHelper.Position);
            _grundbudgetHelper.KreditorList.Remove(_grundbudgetHelper.Position.WshGrundbudgetPositionKreditor.FirstOrDefault());

            // Assert
            var unitOfWork = UnitOfWork.GetNew;
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);
            var pos = repository.Where(x => x.WshGrundbudgetPositionID == _grundbudgetHelper.Position.WshGrundbudgetPositionID).FirstOrDefault();
            Assert.IsTrue(pos == null);
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonEqualPosDatumBis_DatumBisIsNull_Exklusive_IsFalse()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                _grundbudgetHelper.Position.DatumBis,
                null,
                false);

            // Assert
            Assert.IsFalse(result, "Es wurde eine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonEqualPosDatumBis_DatumBisIsNull_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                _grundbudgetHelper.Position.DatumBis,
                null,
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonEqualPosDatumVon_DatumBisInRange_Exclusive_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                _grundbudgetHelper.Position.DatumVon,
                _grundbudgetHelper.Position.DatumVon.AddMonths(2).AddDays(-1),
                false);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonEqualPosDatumVon_DatumBisInRange_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                _grundbudgetHelper.Position.DatumVon,
                _grundbudgetHelper.Position.DatumVon.AddMonths(2).AddDays(-1),
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonGreater_DatumBisGreater_IsFalse()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            // ReSharper disable PossibleInvalidOperationException
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                _grundbudgetHelper.Position.DatumBis.Value.AddDays(14),
                _grundbudgetHelper.Position.DatumBis.Value.AddMonths(2).AddDays(-1),
                true);
            // ReSharper restore PossibleInvalidOperationException

            // Assert
            Assert.IsFalse(result, "Es wurde eine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonGreater_DatumBisIsNull_IsFalse()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            // ReSharper disable PossibleInvalidOperationException
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                _grundbudgetHelper.Position.DatumBis.Value.AddMonths(1),
                null,
                true);
            // ReSharper restore PossibleInvalidOperationException

            // Assert
            Assert.IsFalse(result, "Es wurde eine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonInRange_DatumBisInRange_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            // ReSharper disable PossibleInvalidOperationException
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                _grundbudgetHelper.Position.DatumVon.AddDays(14),
                _grundbudgetHelper.Position.DatumBis.Value.AddMonths(1),
                true);
            // ReSharper restore PossibleInvalidOperationException

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonIsNull_DatumBisEqualPosDatumVon_Exklusive_IsFalse()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                null,
                _grundbudgetHelper.Position.DatumVon,
                false);

            // Assert
            Assert.IsFalse(result, "Es wurde eine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonIsNull_DatumBisEqualPosDatumVon_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                null,
                _grundbudgetHelper.Position.DatumVon,
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonIsNull_DatumBisGreater_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            // ReSharper disable PossibleInvalidOperationException
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                null,
                _grundbudgetHelper.Position.DatumBis.Value.AddMonths(5),
                true);
            // ReSharper restore PossibleInvalidOperationException

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonIsNull_DatumBisLess_IsFalse()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                null,
                _grundbudgetHelper.Position.DatumVon.AddMonths(-3),
                true);

            // Assert
            Assert.IsFalse(result, "Es wurde eine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonLess_DatumBisEqualPosDatumVon_Exklusive_IsFalse()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                _grundbudgetHelper.Position.DatumVon.AddYears(-1),
                _grundbudgetHelper.Position.DatumVon,
                false);

            // Assert
            Assert.IsFalse(result, "Es wurde eine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonLess_DatumBisEqualPosDatumVon_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                _grundbudgetHelper.Position.DatumVon.AddYears(-1),
                _grundbudgetHelper.Position.DatumVon,
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonLess_DatumBisIsNull_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                _grundbudgetHelper.Position.DatumVon.AddYears(-1),
                null,
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_DatumVonLess_DatumBisLess_IsFalse()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                _grundbudgetHelper.Position.DatumVon.AddYears(-1),
                _grundbudgetHelper.Position.DatumVon.AddDays(-1),
                true);

            // Assert
            Assert.IsFalse(result, "Es wurde eine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosMitDatumBis_KeinDatumBereich_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.Leistung.FaLeistungID,
                _grundbudgetHelper.Position.BaPersonID ?? -1,
                null,
                null,
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosOhneDatumBis_DatumVonEqualPosDatumVon_DatumBisIsNull_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.LeistungOhneBisDatum.FaLeistungID,
                _grundbudgetHelper.PositionOhneBisDatum.BaPersonID ?? -1,
                _grundbudgetHelper.PositionOhneBisDatum.DatumVon,
                null,
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosOhneDatumBis_DatumVonEqualPosDatumVon_DatumBisIsRange_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.LeistungOhneBisDatum.FaLeistungID,
                _grundbudgetHelper.PositionOhneBisDatum.BaPersonID ?? -1,
                _grundbudgetHelper.PositionOhneBisDatum.DatumVon,
                _grundbudgetHelper.PositionOhneBisDatum.DatumVon.AddMonths(3).AddDays(-1),
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosOhneDatumBis_DatumVonIsNull_DatumBisEqualPosDatumVon_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.LeistungOhneBisDatum.FaLeistungID,
                _grundbudgetHelper.PositionOhneBisDatum.BaPersonID ?? -1,
                null,
                _grundbudgetHelper.PositionOhneBisDatum.DatumVon,
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosOhneDatumBis_DatumVonIsNull_DatumBisInRange_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.LeistungOhneBisDatum.FaLeistungID,
                _grundbudgetHelper.PositionOhneBisDatum.BaPersonID ?? -1,
                null,
                _grundbudgetHelper.PositionOhneBisDatum.DatumVon.AddMonths(5),
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosOhneDatumBis_DatumVonIsNull_DatumBisLess_IsFalse()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.LeistungOhneBisDatum.FaLeistungID,
                _grundbudgetHelper.PositionOhneBisDatum.BaPersonID ?? -1,
                null,
                _grundbudgetHelper.PositionOhneBisDatum.DatumVon.AddMonths(-10),
                true);

            // Assert
            Assert.IsFalse(result, "Es wurde eine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosOhneDatumBis_DatumVonLess_DatumBisEqualPosDatumVon_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.LeistungOhneBisDatum.FaLeistungID,
                _grundbudgetHelper.PositionOhneBisDatum.BaPersonID ?? -1,
                _grundbudgetHelper.PositionOhneBisDatum.DatumVon.AddYears(-1),
                _grundbudgetHelper.PositionOhneBisDatum.DatumVon,
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosOhneDatumBis_DatumVonLess_DatumBisIsNull_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.LeistungOhneBisDatum.FaLeistungID,
                _grundbudgetHelper.PositionOhneBisDatum.BaPersonID ?? -1,
                _grundbudgetHelper.PositionOhneBisDatum.DatumVon.AddYears(-1),
                null,
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosOhneDatumBis_DatumVonLess_DatumBisLess_IsFalse()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.LeistungOhneBisDatum.FaLeistungID,
                _grundbudgetHelper.PositionOhneBisDatum.BaPersonID ?? -1,
                _grundbudgetHelper.PositionOhneBisDatum.DatumVon.AddYears(-1),
                _grundbudgetHelper.PositionOhneBisDatum.DatumVon.AddDays(-1),
                true);

            // Assert
            Assert.IsFalse(result, "Es wurde eine Position gefunden.");
        }

        [TestMethod]
        public void DoPositionenExist_PosOhneDatumBis_KeinDatumBereich_IsTrue()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            bool result = service.DoPositionenExist(
                null,
                _grundbudgetHelper.LeistungOhneBisDatum.FaLeistungID,
                _grundbudgetHelper.PositionOhneBisDatum.BaPersonID ?? -1,
                null,
                null,
                true);

            // Assert
            Assert.IsTrue(result, "Es wurde keine Position gefunden.");
        }

        [TestMethod]
        public void GetByFaLeistungID_AktiveUndZukuenftigeVorhandenNachDatumBis_KeinTreffer()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            // ReSharper disable PossibleInvalidOperationException
            var result = service.GetByFaLeistungID(null, _grundbudgetHelper.Position.FaLeistungID, _grundbudgetHelper.Position.DatumBis.Value.AddMonths(7), false);
            // ReSharper restore PossibleInvalidOperationException

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetByFaLeistungID_AktiveUndZukuenftigeVorhandenVorDatumVon_Treffer()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            var result = service.GetByFaLeistungID(null, _grundbudgetHelper.Position.FaLeistungID, _grundbudgetHelper.Position.DatumVon.AddMonths(-7), false);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(_grundbudgetHelper.Position.Bemerkung, result[0].Bemerkung);
        }

        [TestMethod]
        public void GetByFaLeistungID_Alle()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            var result = service.GetByFaLeistungID(null, _grundbudgetHelper.Position.FaLeistungID);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(_grundbudgetHelper.Position.Bemerkung, result[0].Bemerkung);
        }

        [TestMethod]
        public void GetByFaLeistungID_NurAktiveVorhanden2010_Treffer()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            var result = service.GetByFaLeistungID(null, _grundbudgetHelper.Position.FaLeistungID, _grundbudgetHelper.Position.DatumVon.AddMonths(4), true);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(_grundbudgetHelper.Position.Bemerkung, result[0].Bemerkung);
        }

        [TestMethod]
        public void GetByFaLeistungID_NurAktiveVorhanden2011_KeinTreffer()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            // ReSharper disable PossibleInvalidOperationException
            var result = service.GetByFaLeistungID(null, _grundbudgetHelper.Position.FaLeistungID, _grundbudgetHelper.Position.DatumBis.Value.AddMonths(7), true);
            // ReSharper restore PossibleInvalidOperationException

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetByFaLeistungID_NurAktiveVorhandenVorDatumVon_KeinTreffer()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            var result = service.GetByFaLeistungID(null, _grundbudgetHelper.Position.FaLeistungID, _grundbudgetHelper.Position.DatumVon.AddMonths(-7), true);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SaveData_Ok()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            WshGrundbudgetPosition newPos;
            KissServiceResult result = service.NewData(out newPos);
            newPos.FaLeistung = _grundbudgetHelper.Position.FaLeistung;
            newPos.BaPerson = _grundbudgetHelper.Position.FaLeistung.BaPerson;
            newPos.KbuKontoID = _grundbudgetHelper.KbuKonto.KbuKontoID;
            newPos.KbuKonto = _grundbudgetHelper.KbuKonto;
            newPos.Bemerkung = "Auszahlung";
            newPos.BetragMonatlich = 12345.55m;
            newPos.DatumVon = new DateTime(2009, 4, 1);
            newPos.DatumVon = new DateTime(2010, 1, 31);
            newPos.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.CashBarauszahlung;
            newPos.Text = "GBL UnitTest";
            newPos.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat;
            newPos.WshBewilligungStatusCode = (int)LOVsGenerated.WshBewilligungStatus.InVorbereitung;
            newPos.WshKategorie = _kategorieHelper.GetWshKategorie(null, LOVsGenerated.WshKategorie.Ausgabe);

            //Act
            result += service.SaveData(null, newPos);
            _grundbudgetHelper.Entities.Add(newPos);

            //Assert
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            IList<WshGrundbudgetPosition> positionen = service.GetByFaLeistungID(unitOfWork, _grundbudgetHelper.Leistung.FaLeistungID);
            WshGrundbudgetPosition myPos = positionen.FirstOrDefault(pos => pos.WshGrundbudgetPositionID == newPos.WshGrundbudgetPositionID);

            Assert.IsTrue(result, result);
            Assert.IsNotNull(myPos);
            Assert.AreEqual(newPos.BetragMonatlich, myPos.BetragMonatlich);
        }

        [TestMethod]
        public void SavePosition_DatumBis_Error()
        {
            // Funktioniert mit Mock-Implementation nicht, da es jeweils nur eine Instanz eines Eintrags gibt
            // und so nicht der Originalwert mit dem neuen Wert verglichen werden kann.
            if (!TestUtils.IsDbTest(null))
            {
                return;
            }

            // Arrange
            using (new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;
                var service = Container.Resolve<WshGrundbudgetPositionService>();
                WshGrundbudgetPosition position;
                var result = service.NewData(out position);

                Assert.IsTrue(result, result);

                position.FaLeistung = _grundbudgetHelper.Leistung;
                position.BaPerson = _grundbudgetHelper.Person;
                position.KbuKonto = _grundbudgetHelper.KbuKonto;

                position.Text = "DatumBis_Error UnitTest";
                position.BetragMonatlich = 100;
                position.FaelligAm = DateTime.Today;
                position.WshKategorie = _kategorieHelper.GetWshKategorie(null, LOVsGenerated.WshKategorie.Einnahme);
                position.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Valuta;

                // Aktueller Monat, 4 Monate
                position.DatumVon = FirstDayOf(DateTime.Now);
                position.DatumBis = position.DatumVon.AddMonths(4);

                // GB-Position speichern
                result = service.SaveData(unitOfWork, position, _questionsAndAnswers);

                Assert.IsTrue(result, result);

                // Letzte erstellte Position holen
                var posSvc = Container.Resolve<WshPositionService>();
                var wshPosition = (from pos in posSvc.GetByWshGrundbudgetPositionID(unitOfWork, position.WshGrundbudgetPositionID)
                                   orderby pos.WshPositionID
                                   select pos).Last();

                // Belege erstellen
                var belegSvc = Container.Resolve<KbuBelegService>();
                var belegDto = new WshAuszahlvorschlagBelegDTO();
                belegDto.BelegPositionen = new List<WshAuszahlvorschlagBelegPositionDTO>
                {
                    new WshAuszahlvorschlagBelegPositionDTO(belegDto)
                    {
                        Einnahme = 100,
                        WshPosition = wshPosition
                    }
                };
                belegDto.Kreditor = new WshAuszahlvorschlagKreditorDTO
                {
                    BaZahlungsweg = new BaZahlungsweg
                    {
                        DatumVon = new DateTime(2010, 1, 1),
                    },
                    Name = "Kreditor",
                    Type = KreditorType.Person
                };
                belegDto.Status = WshAuszahlvorschlagStatus.Freigegeben;
                belegDto.Valuta = DateTime.Now;

                KbuBeleg beleg;
                result = belegSvc.CreateBeleg(unitOfWork, belegDto, true, out beleg);
                Assert.IsTrue(result, result);

                // DatumBis vorverschieben (DatumVon + 1 Monat)
                position.DatumBis = position.DatumVon.AddMonths(1);
                result = service.SaveData(unitOfWork, position, _questionsAndAnswers);

                Assert.IsFalse(result, result);
            }
        }

        [TestMethod]
        public void SavePosition_ExistierendMitKreditor()
        {
            //Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();
            _grundbudgetHelper.Position.FaelligAm = DateTime.Today;
            _grundbudgetHelper.Position.Text = "HelloAgain";
            _grundbudgetHelper.Position.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Valuta;
            _grundbudgetHelper.Position.WshKategorie = _kategorieHelper.GetWshKategorie(null, LOVsGenerated.WshKategorie.Einnahme);
            _grundbudgetHelper.Position.WshGrundbudgetPositionKreditor.Single().MitteilungZeile1 = "HelloAgain";

            //Act
            KissServiceResult result = service.SaveData(null, _grundbudgetHelper.Position, _questionsAndAnswers);

            //Assert
            Assert.IsTrue(result, result);
            var unitOfWork = UnitOfWork.GetNew;
            var repositoryKreditor = UnitOfWork.GetRepository<WshGrundbudgetPositionKreditor>(unitOfWork);
            int kreditorId = _grundbudgetHelper.Position.WshGrundbudgetPositionKreditor.Single().WshGrundbudgetPositionKreditorID;
            var kreditorFound = (from x in repositoryKreditor
                                 where x.WshGrundbudgetPositionKreditorID == kreditorId
                                 select x).Single();
            Assert.AreEqual("HelloAgain", kreditorFound.MitteilungZeile1);
        }

        [TestMethod]
        public void SavePosition_NeuMitDebitor()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();
            WshGrundbudgetPosition newPos;
            var result = service.NewData(out newPos);

            Assert.IsTrue(result, result);

            newPos.FaLeistung = _grundbudgetHelper.Leistung;
            newPos.BaPerson = _grundbudgetHelper.Person;
            newPos.KbuKonto = _grundbudgetHelper.KbuKonto;
            newPos.Bemerkung = "Abgetretene Einnahme";
            newPos.BetragMonatlich = 1000;
            newPos.DatumVon = new DateTime(2010, 1, 1);
            newPos.DatumBis = new DateTime(2010, 12, 31);
            newPos.FaelligAm = new DateTime(2010, 1, 1);
            newPos.Text = "Debitor UnitTest";
            newPos.WshKategorie = _kategorieHelper.GetWshKategorie(null, LOVsGenerated.WshKategorie.Einnahme);
            newPos.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Valuta;
            newPos.VerwaltungSD = true;

            var debitorService = Container.Resolve<WshGrundbudgetPositionDebitorService>();
            WshGrundbudgetPositionDebitor debitor;
            result = debitorService.NewData(out debitor);

            Assert.IsTrue(result, result);

            debitor.BaPerson = _grundbudgetHelper.Person;
            debitor.WshGrundbudgetPosition = newPos;
            newPos.WshGrundbudgetPositionDebitor.Add(debitor);

            // Act
            result = service.SaveData(null, newPos, _questionsAndAnswers);
            _grundbudgetHelper.Entities.Add(newPos);

            Assert.IsTrue(result, result);
            Assert.IsTrue(debitor.WshGrundbudgetPositionDebitorID > 0);

            var repositoryDebitor = UnitOfWork.GetRepository<WshGrundbudgetPositionDebitor>(UnitOfWork.GetNew);
            var debitorFound = (from x in repositoryDebitor
                                where x.WshGrundbudgetPositionDebitorID == debitor.WshGrundbudgetPositionDebitorID
                                select x).Single();

            Assert.AreEqual(debitor.BaPersonID, debitorFound.BaPersonID);
        }

        [TestMethod]
        public void SavePosition_NeuMitKreditor()
        {
            if (!TestUtils.IsDbTest(UnitOfWork.GetNew))
            {
                return;
            }

            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();
            WshGrundbudgetPosition newPos;
            var result = service.NewData(out newPos);
            Assert.IsTrue(result, result);
            newPos.FaLeistung = _grundbudgetHelper.Leistung;
            newPos.BaPerson = _grundbudgetHelper.Person;
            newPos.KbuKonto = _grundbudgetHelper.KbuKonto;
            newPos.Bemerkung = "Auszahlung";
            newPos.BetragMonatlich = 12345.55m;
            newPos.DatumVon = new DateTime(2009, 4, 1);
            newPos.DatumVon = new DateTime(2010, 1, 31);
            newPos.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            newPos.Text = "GBL UnitTest";
            newPos.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat;
            newPos.WshBewilligungStatusCode = (int)LOVsGenerated.WshBewilligungStatus.InVorbereitung;
            newPos.WshKategorie = _kategorieHelper.GetWshKategorie(null, LOVsGenerated.WshKategorie.Ausgabe);

            var grundbudgetPositionKreditorService = Container.Resolve<WshGrundbudgetPositionKreditorService>();
            WshGrundbudgetPositionKreditor kreditor;
            grundbudgetPositionKreditorService.NewData(out kreditor);

            kreditor.BaZahlungsweg = _grundbudgetHelper.Zahlungsweg;
            kreditor.WshGrundbudgetPosition = newPos;
            kreditor.MitteilungZeile1 = "hello UnitTest";
            _grundbudgetHelper.KreditorList.Add(kreditor);

            // Act
            result = service.SaveData(null, newPos, _questionsAndAnswers);
            _grundbudgetHelper.Entities.Add(newPos);

            // Assert
            Assert.IsTrue(result, result);
            Assert.IsTrue(kreditor.WshGrundbudgetPositionKreditorID > 0);
            var unitOfWork = UnitOfWork.GetNew;
            var repositoryKreditor = UnitOfWork.GetRepository<WshGrundbudgetPositionKreditor>(unitOfWork);
            var kreditorFound = (from x in repositoryKreditor
                                 where x.WshGrundbudgetPositionKreditorID == kreditor.WshGrundbudgetPositionKreditorID
                                 select x).Single();
            Assert.AreEqual(kreditor.MitteilungZeile1, kreditorFound.MitteilungZeile1);
        }

        [TestMethod]
        public void SavePosition_NeuOhneKreditor()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();
            WshGrundbudgetPosition newPos;
            KissServiceResult result = service.NewData(out newPos);
            Assert.IsTrue(result, result);
            newPos.FaLeistung = _grundbudgetHelper.Leistung;
            newPos.BaPerson = _grundbudgetHelper.Person;
            newPos.KbuKonto = _grundbudgetHelper.KbuKonto;
            newPos.Bemerkung = "Auszahlung";
            newPos.BetragMonatlich = 12345.55m;
            newPos.DatumVon = new DateTime(2009, 4, 1);
            newPos.DatumVon = new DateTime(2010, 1, 31);
            newPos.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.CashBarauszahlung;
            newPos.Text = "GBL UnitTest";
            newPos.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat;
            newPos.WshBewilligungStatusCode = (int)LOVsGenerated.WshBewilligungStatus.InVorbereitung;
            newPos.WshKategorie = _kategorieHelper.GetWshKategorie(null, LOVsGenerated.WshKategorie.Ausgabe);

            // Act
            result = service.SaveData(null, newPos, _questionsAndAnswers);
            _grundbudgetHelper.Entities.Add(newPos);

            // Assert
            Assert.IsTrue(result, result);
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static QuestionAnswerOption TakeFirstAvailableQuestionAnswerOption(string question, List<QuestionAnswerOption> availableOptions)
        {
            if (availableOptions.Count == 0)
            {
                return null;
            }

            return availableOptions[0];
        }

        #endregion

        #region Private Methods

        private DateTime FirstDayOf(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        #endregion

        #endregion
    }
}