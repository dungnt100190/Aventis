using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kiss.BL.Ba;
using Kiss.BL.Kbu;
using Kiss.BL.Test.Helpers;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Wsh
{
    /// <summary>
    /// Tests the TService service.
    /// </summary>
    [TestClass]
    public class WshGrundbudgetUebertragenServiceTest
    {
        #region Fields

        #region Private Static Fields

        private static readonly Dictionary<string, QuestionAnswerOption> _questionsAndAnswers = new Dictionary<string, QuestionAnswerOption>();

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly BaPersonHelper _baPersonHelper = new BaPersonHelper();
        private readonly WshGrundbudgetHelper _grundbudgetHelper = new WshGrundbudgetHelper();

        #endregion

        #endregion

        #region Test Methods

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestServiceBase.ClassInitialize();
            _questionsAndAnswers["GrauePositionenLoeschen"] = new QuestionAnswerOption(true, "Ja");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using (var transaction = new TransactionScope())
            {
                // Create some temporary test objects and store the entities
                IUnitOfWork unitOfWork = UnitOfWork.GetNew;
                _grundbudgetHelper.CreateGrundbudget(unitOfWork);

                transaction.Complete();
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TestServiceBase.ClassInitialize(DatabaseTestUtil.CONNECTION_STRING_NAME_KISS5);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (var transaction = new TransactionScope())
            {
                var unitOfWork = UnitOfWork.GetNew;
                _grundbudgetHelper.Delete(unitOfWork);
                _baPersonHelper.Delete(unitOfWork);

                transaction.Complete();
            }
        }

        [TestMethod]
        public void AlleFelderImMBMutierenUndUebertragen_Ok()
        {
            //Arrange
            var svcGbPosition = Container.Resolve<WshGrundbudgetPositionService>();
            var svcMbPosition = Container.Resolve<WshPositionService>();

            var unitOfWork = UnitOfWork.GetNew;
            var gbPositionen = svcGbPosition.GetByFaLeistungID(unitOfWork, _grundbudgetHelper.Leistung.FaLeistungID);
            var gbPosition = gbPositionen.First(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe);
            svcGbPosition.SaveData(unitOfWork, gbPosition, _questionsAndAnswers);
            unitOfWork.SaveChanges();

            //"manuelle" Änderungen im Monatsbudget
            var monatsbudgetPositionen = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWork, gbPosition.WshGrundbudgetPositionID).ToList();
            var kbuKontoId = Container.Resolve<KbuKontoService>().GetData(unitOfWork).Where(x => x.KbuKontoID != gbPosition.KbuKontoID).First().KbuKontoID;
            foreach (var monatsbudgetPosition in monatsbudgetPositionen)
            {
                monatsbudgetPosition.KbuKontoID = kbuKontoId;
                monatsbudgetPosition.Text = "Monatstext";
                monatsbudgetPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.InterneVerrechnung;
                monatsbudgetPosition.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Semester;
                monatsbudgetPosition.FaelligAm = monatsbudgetPosition.FaelligAm.HasValue
                                                     ? monatsbudgetPosition.FaelligAm.Value.AddDays(2)
                                                     : DateTime.Today;
                monatsbudgetPosition.Betrag = monatsbudgetPosition.Betrag * 2;
                if (monatsbudgetPosition.BetragTotal.HasValue)
                {
                    monatsbudgetPosition.BetragTotal = monatsbudgetPosition.BetragTotal * 2;
                }
            }
            svcMbPosition.SaveData(unitOfWork, monatsbudgetPositionen);
            unitOfWork.SaveChanges();

            //Act
            var unitOfWorkAct = UnitOfWork.GetNew;
            var gbPositionAct = svcGbPosition.GetById(unitOfWorkAct, gbPosition.WshGrundbudgetPositionID);
            const int newPeriodizitaet = (int)LOVsGenerated.WshPeriodizitaet.Woechentlich;
            gbPositionAct.WshPeriodizitaetCode = newPeriodizitaet;
            svcGbPosition.SaveData(unitOfWorkAct, gbPositionAct, _questionsAndAnswers);
            unitOfWorkAct.SaveChanges();

            //Assert
            var unitOfWorkCheck = UnitOfWork.GetNew;
            var monatsbudgetPositionenCheck = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWorkCheck, gbPosition.WshGrundbudgetPositionID);
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.Text == gbPositionAct.Text));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.KbuKontoID == gbPositionAct.KbuKontoID));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.KbuAuszahlungArtCode == gbPositionAct.KbuAuszahlungArtCode));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x =>
                    x.FaelligAm ==
                    WshGrundbudgetUebertragenService.CalculateMonthFaelligAm(gbPositionAct.FaelligAm, gbPositionAct.DatumVon, x.MonatVon)));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPeriodizitaetCode != newPeriodizitaet));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.Betrag == gbPositionAct.BetragMonatlich));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.BetragTotal.HasValue && x.BetragTotal.Value == gbPositionAct.BetragTotal));
        }

        [TestMethod]
        public void AlleFelderMutierenUndUebertragenKreditor_Ok()
        {
            //Arrange
            var svcGbPosition = Container.Resolve<WshGrundbudgetPositionService>();
            var svcMbPosition = Container.Resolve<WshPositionService>();

            var unitOfWork = UnitOfWork.GetNew;

            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            var gbPositionen = svcGbPosition.GetByFaLeistungID(unitOfWork, _grundbudgetHelper.Leistung.FaLeistungID);
            var gbPosition = gbPositionen.First(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe);
            svcGbPosition.SaveData(unitOfWork, gbPosition, _questionsAndAnswers);
            unitOfWork.SaveChanges();

            //"manuelle" Änderungen im Monatsbudget
            var monatsbudgetPositionen = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWork, gbPosition.WshGrundbudgetPositionID).ToList();
            // ToDo: Zahlungsweg testen
            foreach (var kreditor in monatsbudgetPositionen.Select(monatsbudgetPosition => monatsbudgetPosition.WshPositionKreditor.Single()))
            {
                kreditor.MitteilungZeile1 = "MonatsMitteilung 1";
                kreditor.MitteilungZeile2 = "MonatsMitteilung 2";
                kreditor.MitteilungZeile3 = "MonatsMitteilung 3";
                kreditor.MitteilungZeile4 = "MonatsMitteilung 4";
                kreditor.ReferenzNummer = "123456789012345";
            }
            svcMbPosition.SaveData(unitOfWork, monatsbudgetPositionen);
            unitOfWork.SaveChanges();

            //Act
            var unitOfWorkAct = UnitOfWork.GetNew;
            var gbPositionAct = svcGbPosition.GetById(unitOfWorkAct, gbPosition.WshGrundbudgetPositionID);
            gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile1 = "GrundbudgetMitteilung 1";
            gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile2 = "GrundbudgetMitteilung 2";
            gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile3 = "GrundbudgetMitteilung 3";
            gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile4 = "GrundbudgetMitteilung 4";
            gbPositionAct.WshGrundbudgetPositionKreditor.Single().ReferenzNummer = "543210987654321";
            svcGbPosition.SaveData(unitOfWorkAct, gbPositionAct, _questionsAndAnswers);
            unitOfWorkAct.SaveChanges();

            //Assert
            var unitOfWorkCheck = UnitOfWork.GetNew;
            var monatsbudgetPositionenCheck = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWorkCheck, gbPosition.WshGrundbudgetPositionID);
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionKreditor.Single().MitteilungZeile1 != gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile1));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionKreditor.Single().MitteilungZeile2 != gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile2));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionKreditor.Single().MitteilungZeile3 != gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile3));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionKreditor.Single().MitteilungZeile4 != gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile4));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionKreditor.Single().ReferenzNummer != gbPositionAct.WshGrundbudgetPositionKreditor.Single().ReferenzNummer));
        }

        [TestMethod]
        public void BetragMonatlichImGBMutierenUndUebertragen_Ok()
        {
            //Arrange
            var svcGbPosition = Container.Resolve<WshGrundbudgetPositionService>();
            var svcMbPosition = Container.Resolve<WshPositionService>();

            var unitOfWork = UnitOfWork.GetNew;
            var gbPositionen = svcGbPosition.GetByFaLeistungID(unitOfWork, _grundbudgetHelper.Leistung.FaLeistungID);
            var gbPosition = gbPositionen.First(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe);
            svcGbPosition.SaveData(unitOfWork, gbPosition, _questionsAndAnswers);
            unitOfWork.SaveChanges();

            //Act
            gbPosition.BetragMonatlich = gbPosition.BetragMonatlich * 2;
            svcGbPosition.SaveData(unitOfWork, gbPosition, _questionsAndAnswers);

            var monatsbudgetPositionen = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWork, gbPosition.WshGrundbudgetPositionID);

            //Assert
            Assert.AreEqual(0, monatsbudgetPositionen.Count(x => x.Betrag != WshGrundbudgetUebertragenService.PositionsBetragBerechnen(gbPosition, x.MonatVon)));
        }

        [TestMethod]
        public void FaelligAmImGBMutierenUndUebertragen_Ok()
        {
            //Arrange
            var svcGbPosition = Container.Resolve<WshGrundbudgetPositionService>();
            var svcMbPosition = Container.Resolve<WshPositionService>();

            var unitOfWork = UnitOfWork.GetNew;
            var gbPositionen = svcGbPosition.GetByFaLeistungID(unitOfWork, _grundbudgetHelper.Leistung.FaLeistungID);
            var gbPosition = gbPositionen.First(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe);
            svcGbPosition.SaveData(unitOfWork, gbPosition, _questionsAndAnswers);
            unitOfWork.SaveChanges();

            //Act
            gbPosition.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Valuta;
            gbPosition.FaelligAm = gbPosition.FaelligAm.HasValue ? gbPosition.FaelligAm.Value.AddDays(4) : gbPosition.DatumVon.AddDays(5);
            svcGbPosition.SaveData(unitOfWork, gbPosition, _questionsAndAnswers);

            var monatsbudgetPositionen = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWork, gbPosition.WshGrundbudgetPositionID);

            //Assert
            Assert.AreEqual(0, monatsbudgetPositionen.Count(x => x.FaelligAm != WshGrundbudgetUebertragenService.CalculateMonthFaelligAm(gbPosition.FaelligAm, gbPosition.DatumVon, x.MonatVon)));
        }

        [TestMethod]
        public void GblAnLeistungAnpassen_Ok()
        {
            //Arrange
            var service = Container.Resolve<WshGrundbudgetUebertragenService>();
            int idGbPosition = _grundbudgetHelper.Position.WshGrundbudgetPositionID;

            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            UnitOfWork.GetRepository<FaLeistung>(unitOfWork);
            var repoPositionen = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            WshPosition pos = repoPositionen.Include(x => x.WshGrundbudgetPosition)
                .Include(x => x.FaLeistung)
                .Where(x => x.WshGrundbudgetPositionID == idGbPosition).OrderBy(x => x.MonatVon).FirstOrDefault();

            var kbuKontoService = Container.Resolve<KbuKontoService>();
            pos.KbuKonto = kbuKontoService.GetGblKonto(unitOfWork);
            pos.WshGrundbudgetPosition.Berechnet = true;
            pos.WshGrundbudgetPosition.KbuKonto = pos.KbuKonto;
            pos.MonatVon = pos.FaLeistung.DatumVon.AddDays(-10);
            pos.MonatBis = pos.FaLeistung.DatumVon.AddDays(10);
            repoPositionen.ApplyChanges(pos);

            unitOfWork.SaveChanges();

            //Act
            KissServiceResult result = service.GblAnLeistungAnpassen(null, pos.FaLeistungID, pos.FaLeistung.DatumVon);

            //Assert
            Assert.IsTrue(result.IsOk);
            unitOfWork = UnitOfWork.GetNew;
            repoPositionen = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            pos = repoPositionen.Where(x => x.WshGrundbudgetPositionID == idGbPosition).OrderBy(x => x.MonatVon).FirstOrDefault();
            Assert.AreEqual(1469.00M, pos.Betrag);
        }

        [TestMethod]
        public void NurMutierteFelderUebertragenDebitor_Ok()
        {
            //Arrange
            var svcGbPosition = Container.Resolve<WshGrundbudgetPositionService>();
            var svcMbPosition = Container.Resolve<WshPositionService>();

            var unitOfWork = UnitOfWork.GetNew;
            var gbPositionen = svcGbPosition.GetByFaLeistungID(unitOfWork, _grundbudgetHelper.PositionDebitor.FaLeistungID);
            var gbPosition = gbPositionen.First(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Einnahme);
            svcGbPosition.SaveData(unitOfWork, gbPosition, _questionsAndAnswers);
            unitOfWork.SaveChanges();

            //"manuelle" Änderungen im Monatsbudget
            var monatsbudgetPositionen = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWork, gbPosition.WshGrundbudgetPositionID).ToList();
            var monatsDebitorPerson = _baPersonHelper.Create(unitOfWork);
            foreach (var debitor in monatsbudgetPositionen.Select(monatsbudgetPosition => monatsbudgetPosition.WshPositionDebitor.Single()))
            {
                debitor.BaPerson = monatsDebitorPerson;
                debitor.BaInstitution = null;
            }
            svcMbPosition.SaveData(unitOfWork, monatsbudgetPositionen);
            unitOfWork.SaveChanges();

            //Act
            var unitOfWorkAct = UnitOfWork.GetNew;
            var gbPositionAct = svcGbPosition.GetById(unitOfWorkAct, gbPosition.WshGrundbudgetPositionID);
            var grundbudgetDebitorPerson = _baPersonHelper.Create(unitOfWork);
            gbPositionAct.WshGrundbudgetPositionDebitor.Single().BaPersonID = grundbudgetDebitorPerson.BaPersonID;
            gbPositionAct.WshGrundbudgetPositionDebitor.Single().BaInstitutionID = null;
            svcGbPosition.SaveData(unitOfWorkAct, gbPositionAct, _questionsAndAnswers);
            unitOfWorkAct.SaveChanges();

            //Assert
            var unitOfWorkCheck = UnitOfWork.GetNew;
            var monatsbudgetPositionenCheck = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWorkCheck, gbPosition.WshGrundbudgetPositionID);
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionDebitor.Single().BaPersonID != gbPositionAct.WshGrundbudgetPositionDebitor.Single().BaPersonID));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionDebitor.Single().BaInstitutionID != gbPositionAct.WshGrundbudgetPositionDebitor.Single().BaInstitutionID));
        }

        [TestMethod]
        public void NurMutierteFelderUebertragenKreditor_Ok()
        {
            //Arrange
            var svcGbPosition = Container.Resolve<WshGrundbudgetPositionService>();
            var svcMbPosition = Container.Resolve<WshPositionService>();

            var unitOfWork = UnitOfWork.GetNew;
            if (!TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }
            var gbPositionen = svcGbPosition.GetByFaLeistungID(unitOfWork, _grundbudgetHelper.Leistung.FaLeistungID);
            var gbPosition = gbPositionen.First(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe);
            svcGbPosition.SaveData(unitOfWork, gbPosition, _questionsAndAnswers);
            unitOfWork.SaveChanges();

            //"manuelle" Änderungen im Monatsbudget
            var monatsbudgetPositionen = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWork, gbPosition.WshGrundbudgetPositionID).ToList();
            var baZahlungswegDTO = Container.Resolve<BaZahlungswegSearchService>().SearchZahlungsweg(unitOfWork, "H", gbPosition.FaLeistungID).FirstOrDefault();
            // ToDo: Zahlungsweg testen
            foreach (var kreditor in monatsbudgetPositionen.Select(monatsbudgetPosition => monatsbudgetPosition.WshPositionKreditor.Single()))
            {
                kreditor.MitteilungZeile1 = "MonatsMitteilung 1";
                kreditor.MitteilungZeile2 = "MonatsMitteilung 2";
                kreditor.MitteilungZeile3 = "MonatsMitteilung 3";
                kreditor.MitteilungZeile4 = "MonatsMitteilung 4";
                kreditor.ReferenzNummer = "123456789012345";
            }
            svcMbPosition.SaveData(unitOfWork, monatsbudgetPositionen);
            unitOfWork.SaveChanges();

            //Act
            var unitOfWorkAct = UnitOfWork.GetNew;
            var gbPositionAct = svcGbPosition.GetById(unitOfWorkAct, gbPosition.WshGrundbudgetPositionID);
            const string newMitteilungszeile2 = "GrundbudgetMitteilung 2";
            gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile2 = newMitteilungszeile2;
            svcGbPosition.SaveData(unitOfWorkAct, gbPositionAct, _questionsAndAnswers);
            unitOfWorkAct.SaveChanges();

            //Assert
            var unitOfWorkCheck = UnitOfWork.GetNew;
            var monatsbudgetPositionenCheck = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWorkCheck, gbPosition.WshGrundbudgetPositionID);
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionKreditor.Single().MitteilungZeile1 == gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile1));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionKreditor.Single().MitteilungZeile2 != gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile2));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionKreditor.Single().MitteilungZeile3 == gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile3));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionKreditor.Single().MitteilungZeile4 == gbPositionAct.WshGrundbudgetPositionKreditor.Single().MitteilungZeile4));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPositionKreditor.Single().ReferenzNummer == gbPositionAct.WshGrundbudgetPositionKreditor.Single().ReferenzNummer));
        }

        [TestMethod]
        public void NurMutierteFelderUebertragen_Ok()
        {
            //Arrange
            var svcGbPosition = Container.Resolve<WshGrundbudgetPositionService>();
            var svcMbPosition = Container.Resolve<WshPositionService>();

            var unitOfWork = UnitOfWork.GetNew;
            var gbPositionen = svcGbPosition.GetByFaLeistungID(unitOfWork, _grundbudgetHelper.Leistung.FaLeistungID);
            var gbPosition = gbPositionen.First(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe);
            svcGbPosition.SaveData(unitOfWork, gbPosition, _questionsAndAnswers);
            unitOfWork.SaveChanges();

            //"manuelle" Änderungen im Monatsbudget
            var monatsbudgetPositionen = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWork, gbPosition.WshGrundbudgetPositionID).ToList();
            var kbuKontoId = Container.Resolve<KbuKontoService>().GetData(unitOfWork).Where(x => x.KbuKontoID != gbPosition.KbuKontoID).First().KbuKontoID;
            foreach (var monatsbudgetPosition in monatsbudgetPositionen)
            {
                monatsbudgetPosition.KbuKontoID = kbuKontoId;
                monatsbudgetPosition.Text = "Monatstext";
                monatsbudgetPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.InterneVerrechnung;
                monatsbudgetPosition.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Semester;
                monatsbudgetPosition.FaelligAm = monatsbudgetPosition.FaelligAm.HasValue
                                                     ? monatsbudgetPosition.FaelligAm.Value.AddDays(2)
                                                     : DateTime.Today;
                monatsbudgetPosition.Betrag = monatsbudgetPosition.Betrag * 2;
                if (monatsbudgetPosition.BetragTotal.HasValue)
                {
                    monatsbudgetPosition.BetragTotal = monatsbudgetPosition.BetragTotal * 2;
                }
            }
            svcMbPosition.SaveData(unitOfWork, monatsbudgetPositionen);
            unitOfWork.SaveChanges();

            //Act
            var unitOfWorkAct = UnitOfWork.GetNew;
            var gbPositionAct = svcGbPosition.GetById(unitOfWorkAct, gbPosition.WshGrundbudgetPositionID);
            const int newPeriodizitaet = (int)LOVsGenerated.WshPeriodizitaet.Woechentlich;
            gbPositionAct.WshPeriodizitaetCode = newPeriodizitaet;
            svcGbPosition.SaveData(unitOfWorkAct, gbPositionAct, _questionsAndAnswers);
            unitOfWorkAct.SaveChanges();

            //Assert
            var unitOfWorkCheck = UnitOfWork.GetNew;
            var monatsbudgetPositionenCheck = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWorkCheck, gbPosition.WshGrundbudgetPositionID);
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.Text == gbPositionAct.Text));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.KbuKontoID == gbPositionAct.KbuKontoID));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.KbuAuszahlungArtCode == gbPositionAct.KbuAuszahlungArtCode));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(
                    x =>
                    x.FaelligAm == WshGrundbudgetUebertragenService.CalculateMonthFaelligAm(gbPosition.FaelligAm, gbPosition.DatumVon, x.MonatVon)));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.WshPeriodizitaetCode != newPeriodizitaet));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.Betrag == gbPositionAct.BetragMonatlich));
            Assert.AreEqual(0, monatsbudgetPositionenCheck.Count(x => x.BetragTotal.HasValue && x.BetragTotal.Value == gbPositionAct.BetragTotal));
        }

        [TestMethod]
        public void PositionInMonatsbudgetUebertragen_GBLPeriodizitaetMonat()
        {
            //Arrange
            var service = Container.Resolve<WshGrundbudgetUebertragenService>();
            int idGbPosition = _grundbudgetHelper.Position.WshGrundbudgetPositionID;

            //Act
            KissServiceResult result = service.PositionInMonatsbudgetUebertragen(null, idGbPosition, DateTime.Today, null, _questionsAndAnswers);

            //Assert
            Assert.IsTrue(result.IsOk);
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var repoPositionen = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            int count = repoPositionen.Where(x => x.WshGrundbudgetPositionID == idGbPosition).Count();

            //Wir erwarten vier Positionen. Diesen Monat plus 3 Monate.
            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void PositionInMonatsbudgetUebertragen_PeriodizitaetQuartal()
        {
            //Arrange
            var service = Container.Resolve<WshGrundbudgetUebertragenService>();
            int idGbPosition = _grundbudgetHelper.PositionNoGBL.WshGrundbudgetPositionID;

            //Act
            KissServiceResult result = service.PositionInMonatsbudgetUebertragen(null, idGbPosition, DateTime.Today, null, _questionsAndAnswers);

            //Assert
            Assert.IsTrue(result.IsOk);
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;
            var repoPositionen = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            //Wir erwarten zwei Positionen. Diesen Monat plus 3 Monate (4 Monate) (Leistung fängt genau am 1 an). Da pro Quartal eine Monatsposition angelegt
            //wird, ergibt das zwei.
            int count = repoPositionen.Where(x => x.WshGrundbudgetPositionID == idGbPosition).Count();
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TextImGBMutierenUndUebertragen_Ok()
        {
            //Arrange
            var svcGbPosition = Container.Resolve<WshGrundbudgetPositionService>();
            var svcMbPosition = Container.Resolve<WshPositionService>();

            var unitOfWork = UnitOfWork.GetNew;
            var gbPositionen = svcGbPosition.GetByFaLeistungID(unitOfWork, _grundbudgetHelper.Leistung.FaLeistungID);
            var gbPosition = gbPositionen.First(x => x.WshKategorieID == (int)LOVsGenerated.WshKategorie.Ausgabe);
            svcGbPosition.SaveData(unitOfWork, gbPosition, _questionsAndAnswers);
            unitOfWork.SaveChanges();

            const string newText = "Neuer Text im Grundbudget";

            //Act
            gbPosition.Text = newText;
            svcGbPosition.SaveData(unitOfWork, gbPosition, _questionsAndAnswers);

            var monatsbudgetPositionen = svcMbPosition.GetByWshGrundbudgetPositionID(unitOfWork, gbPosition.WshGrundbudgetPositionID);

            //Assert
            Assert.AreEqual(0, monatsbudgetPositionen.Count(x => x.Text != newText));
        }

        #endregion
    }
}