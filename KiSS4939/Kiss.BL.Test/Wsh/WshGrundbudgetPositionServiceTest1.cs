using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Kbu;
using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Enumeration;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the Grundbudget/Monatsbudget functionality of the WshGrundbudgetPositionService.
    /// </summary>
    [TestClass]
    public class WshGrundbudgetPositionServiceTest1
    {
        #region Fields

        #region Private Static Fields

        private static readonly Dictionary<string, QuestionAnswerOption> _questionsAndAnswers = new Dictionary<string, QuestionAnswerOption>();

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly WshAbzugHelper _abzugHelper = new WshAbzugHelper();
        private readonly WshGrundbudgetHelper _grundbudgetHelper = new WshGrundbudgetHelper();

        #endregion

        #region Private Fields

        private WshAbzugDTO _abzugDto;
        private TransactionScope _transaction;

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
            _transaction = new TransactionScope();

            try
            {
                // Create some temporary test objects and store the entities
                var unitOfWork = UnitOfWork.GetNew;

                //HACK: Habe todo zetelli aufgenommen.
                if (!TestUtils.IsDbTest(unitOfWork))
                {
                    var repKreditor = UnitOfWork.GetRepository<WshPositionKreditor>(unitOfWork);
                    var theList = repKreditor.ToList();
                    theList.ForEach(x => x.MarkAsDeleted());
                    theList.ForEach(repKreditor.ApplyChanges);
                    unitOfWork.SaveChanges();
                }

                // Create some temporary test objects and store the entities
                _grundbudgetHelper.CreateGrundbudget(unitOfWork);

                // Create some WshPosition entities based on the grundbudget
                var grundbudgetUebertragenService = Container.Resolve<WshGrundbudgetUebertragenService>();

                DateTime datumAb = new DateTime(2011, 01, 01);

                grundbudgetUebertragenService.PositionInMonatsbudgetUebertragen(
                    unitOfWork,
                    _grundbudgetHelper.Position.WshGrundbudgetPositionID,
                    datumAb,
                    _grundbudgetHelper.Position.ModifiedProperties,
                    _questionsAndAnswers);

                _abzugDto = _abzugHelper.CreateAbzugVerrechnung(unitOfWork);
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

        [TestCleanup]
        public void TestCleanup()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
        }

        [TestMethod]
        public void AreAllDependingPositionsGray_False()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            List<WshAuszahlvorschlagPositionDTO> offenePositionen;
            List<WshAuszahlvorschlagBelegDTO> belegDtos;
            KbuBeleg beleg;

            //Für einen Monat einen Beleg erstellen
            var auszahlVorschlagService = Container.Resolve<WshAuszahlvorschlagService>();

            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            var result = auszahlVorschlagService.GetAuszahlvorschlagPositionUndBeleg(
                null, _grundbudgetHelper.Position.FaLeistungID, lastOfMonth, false, out offenePositionen, out belegDtos);

            Assert.IsTrue(result, result);
            Assert.IsNotNull(offenePositionen);
            Assert.IsTrue(offenePositionen.Count > 0);
            Assert.IsNotNull(belegDtos);
            Assert.IsTrue(belegDtos.Count > 0);

            var belegDTO = belegDtos[0];
            belegDTO.BelegPositionen.ForEach(bp => bp.Ausgabe = 0);

            //nur bei der aktuellen monats-position einen ausgabe-betrag erfassen
            belegDTO.BelegPositionen.Where(bp => bp.WshPosition.MonatVon == firstOfMonth).First().Ausgabe = _grundbudgetHelper.Position.BetragMonatlich;

            var belegService = Container.Resolve<KbuBelegService>();
            result = belegService.CreateBeleg(null, belegDTO, false, out beleg);
            Assert.IsTrue(result, result);

            DateTime? firstNonGrayPosition;
            DateTime? lastNonGrayPosition;
            bool allDependingPositionsAreGray = service.AreAllDependingPositionsGray(
                null, _grundbudgetHelper.Position.WshGrundbudgetPositionID, out firstNonGrayPosition, out lastNonGrayPosition);

            // Assert
            Assert.IsFalse(allDependingPositionsAreGray);
            Assert.AreEqual(firstOfMonth, firstNonGrayPosition);
            Assert.AreEqual(lastOfMonth, lastNonGrayPosition);
        }

        [TestMethod]
        public void AreAllDependingPositionsGray_IstAbzug_False()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // MB-Position mit Betrag 0 erstellen
            var wshPosition = _abzugDto.WshAbzug.WshGrundbudgetPosition.WshPosition.First();
            wshPosition.Betrag = 0;

            var wshPositionService = Container.Resolve<WshPositionService>();
            var result = wshPositionService.SaveData(null, wshPosition);
            result.Assert();

            DateTime monatVon = wshPosition.MonatVon;
            DateTime monatBis = wshPosition.MonatBis;

            // Act
            DateTime? firstNonGrayPosition;
            DateTime? lastNonGrayPosition;
            var allDependingPositionsAreGray = service.AreAllDependingPositionsGray(
                null, _abzugDto.WshAbzug.WshGrundbudgetPosition.WshGrundbudgetPositionID, out firstNonGrayPosition, out lastNonGrayPosition, true);

            // Assert
            Assert.IsFalse(allDependingPositionsAreGray);
            Assert.AreEqual(monatVon, firstNonGrayPosition);
            Assert.AreEqual(monatBis, lastNonGrayPosition);
        }

        [TestMethod]
        public void AreAllDependingPositionsGray_True()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            DateTime? firstNonGrayPosition;
            DateTime? lastNonGrayPosition;
            var allDependingPositionsAreGray = service.AreAllDependingPositionsGray(
                null, _grundbudgetHelper.Position.WshGrundbudgetPositionID, out firstNonGrayPosition, out lastNonGrayPosition);

            // Assert
            Assert.IsTrue(allDependingPositionsAreGray);
        }

        [TestMethod]
        public void DoDependingPositionsExist_False()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            var doExist = service.DoDependingPositionsExist(null, _grundbudgetHelper.Position.WshGrundbudgetPositionID, WshPositionsstatus.Freigegeben);

            // Assert
            Assert.IsFalse(doExist);
        }

        [TestMethod]
        public void DoDependingPositionsExist_True()
        {
            // Arrange
            var service = Container.Resolve<WshGrundbudgetPositionService>();

            // Act
            List<WshAuszahlvorschlagPositionDTO> offenePositionen;
            List<WshAuszahlvorschlagBelegDTO> belegDtos;
            KbuBeleg beleg;

            //Für einen Monat einen Beleg erstellen
            var auszahlVorschlagService = Container.Resolve<WshAuszahlvorschlagService>();

            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            var result = auszahlVorschlagService.GetAuszahlvorschlagPositionUndBeleg(
                null, _grundbudgetHelper.Position.FaLeistungID, lastOfMonth, false, out offenePositionen, out belegDtos);

            Assert.IsTrue(result, result);
            Assert.IsNotNull(offenePositionen);
            Assert.IsTrue(offenePositionen.Count > 0);
            Assert.IsNotNull(belegDtos);
            Assert.IsTrue(belegDtos.Count > 0);

            var belegDTO = belegDtos[0];
            belegDTO.BelegPositionen.ForEach(bp => bp.Ausgabe = 0);

            //nur bei der aktuellen monats-position einen ausgabe-betrag erfassen
            belegDTO.BelegPositionen.Where(bp => bp.WshPosition.MonatVon == firstOfMonth).First().Ausgabe = _grundbudgetHelper.Position.BetragMonatlich;

            var belegService = Container.Resolve<KbuBelegService>();
            result = belegService.CreateBeleg(null, belegDTO, false, out beleg);
            Assert.IsTrue(result, result);

            var doExist = service.DoDependingPositionsExist(null, _grundbudgetHelper.Position.WshGrundbudgetPositionID, WshPositionsstatus.Freigegeben);

            // Assert
            Assert.IsTrue(doExist);
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

        #endregion
    }
}