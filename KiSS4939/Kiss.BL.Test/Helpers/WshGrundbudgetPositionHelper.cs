using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.BL.Wsh;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class WshGrundbudgetPositionHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshKategorieHelper _kategorieHelper = new WshKategorieHelper();
        private readonly KbuKontoHelper _kontoHelper = new KbuKontoHelper();
        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();
        private readonly List<WshGrundbudgetPosition> _list = new List<WshGrundbudgetPosition>();
        private readonly List<WshAbzug> _listAbzug = new List<WshAbzug>();
        private readonly List<WshGrundbudgetPositionDebitor> _listDebitor = new List<WshGrundbudgetPositionDebitor>();
        private readonly List<WshGrundbudgetPositionKreditor> _listKreditor = new List<WshGrundbudgetPositionKreditor>();
        private readonly BaPersonHelper _personHelper = new BaPersonHelper();
        private readonly BaZahlungswegHelper _zahlungswegHelper = new BaZahlungswegHelper();

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Löscht die DeleteWshGrundbudgetPosition inklusive:
        /// - Positionen (Monatsbudget)
        /// - Kreditoren der Positionen (Monatsbudget)
        /// - Debitoren der Positionen (Monatsbudget)
        /// - Kreditoren der Grundbudgetposition
        /// - Debitoren der Grundbudgetposition
        /// - Grundbudgetposition selber
        /// 
        /// Gibt es die GrundPosition nicht, dann wird keine Exception geworfen,
        /// Methode läuft normal durch.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="wshGrundbudgetPositionId"></param>
        public static void DeleteWshGrundbudgetPosition(IUnitOfWork unitOfWork, int wshGrundbudgetPositionId)
        {
            DeleteWshPositionInclBelongingData(unitOfWork, wshGrundbudgetPositionId);

            //search kreditor grundbudgetposition
            var repositoryWshGrundbugetPositionKreditor = UnitOfWork.GetRepository<WshGrundbudgetPositionKreditor>(unitOfWork);
            var wshGrudbudgetPositionKreditors = repositoryWshGrundbugetPositionKreditor
                .Where(x => x.WshGrundbudgetPositionID == wshGrundbudgetPositionId)
                .Select(x => x).ToList();

            wshGrudbudgetPositionKreditors.ForEach(
                x =>
                {
                    x.MarkAsDeleted();
                    repositoryWshGrundbugetPositionKreditor.ApplyChanges(x);
                });
            unitOfWork.SaveChanges();

            //search debitor grundbudgetposition
            var repositoryDebitor = UnitOfWork.GetRepository<WshGrundbudgetPositionDebitor>(unitOfWork);
            var debitoren = repositoryDebitor
                .Where(x => x.WshGrundbudgetPositionID == wshGrundbudgetPositionId)
                .Select(x => x).ToList();

            debitoren.ForEach(
                x =>
                {
                    x.MarkAsDeleted();
                    repositoryDebitor.ApplyChanges(x);
                });
            unitOfWork.SaveChanges();

            //Search grundbudgetposition
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);
            var position = repository
                .Where(x => x.WshGrundbudgetPositionID == wshGrundbudgetPositionId)
                .Select(x => x).FirstOrDefault();
            if (position != null)
            {
                position.MarkAsDeleted();
                repository.ApplyChanges(position);
                unitOfWork.SaveChanges();
            }
        }

        /// <summary>
        /// Löscht alle WshGrundbudgetPosition* der GrundbudgetPosition.
        /// </summary>
        /// <param name="unitOfWork">Das UnitOfWork, welches verwendet werden soll</param>
        /// <param name="wshGrundbudgetPositionId">ID der GrundbudgetPosition</param>
        public static void DeleteWshPositionInclBelongingData(IUnitOfWork unitOfWork, int wshGrundbudgetPositionId)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);

            // get WshGrundbudgetPositionKreditors
            var repositoryWshPositionKreditor = UnitOfWork.GetRepository<WshGrundbudgetPositionKreditor>(unitOfWork);

            var wshPositionKreditors = repositoryWshPositionKreditor
                .Include(kred => kred.WshGrundbudgetPosition)
                .Where(kred => kred.WshGrundbudgetPositionID == wshGrundbudgetPositionId)
                .Select(kred => kred).ToList();

            // delete WshGrundbudgetPositionKreditors
            wshPositionKreditors.ForEach(
                kred =>
                {
                    kred.MarkAsDeleted();
                    repositoryWshPositionKreditor.ApplyChanges(kred);
                });

            unitOfWork.SaveChanges();

            // get WshGrundbudgetPositionDebitors
            var repositoryDebitor = UnitOfWork.GetRepository<WshGrundbudgetPositionDebitor>(unitOfWork);

            var debitoren = repositoryDebitor
                .Include(x => x.WshGrundbudgetPosition)
                .Where(x => x.WshGrundbudgetPositionID == wshGrundbudgetPositionId)
                .Select(x => x).ToList();

            // delete WshGrundbudgetPositionDebitors
            debitoren.ForEach(
                x =>
                {
                    x.MarkAsDeleted();
                    repositoryDebitor.ApplyChanges(x);
                });

            unitOfWork.SaveChanges();

            // get WshPositions
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            var wshPositions = repository
                .Include(pos => pos.WshPositionKreditor)
                .Include(pos => pos.WshPositionDebitor)
                .Where(pos => pos.WshGrundbudgetPositionID == wshGrundbudgetPositionId)
                .Select(pos => pos).ToList();

            var repositoryPosKreditor = UnitOfWork.GetRepository<WshPositionKreditor>(unitOfWork);
            var repositoryPosDebitor = UnitOfWork.GetRepository<WshPositionDebitor>(unitOfWork);
            foreach (WshPosition wshPosition in wshPositions.ToList())
            {
                foreach (WshPositionKreditor kreditor in wshPosition.WshPositionKreditor.ToList())
                {
                    kreditor.MarkAsDeleted();
                    repositoryPosKreditor.ApplyChanges(kreditor);
                }
                unitOfWork.SaveChanges();

                foreach (WshPositionDebitor debitor in wshPosition.WshPositionDebitor.ToList())
                {
                    debitor.MarkAsDeleted();
                    repositoryPosDebitor.ApplyChanges(debitor);
                }
                unitOfWork.SaveChanges();

                wshPosition.MarkAsDeleted();
                repository.ApplyChanges(wshPosition);
                unitOfWork.SaveChanges();
            }

            unitOfWork.SaveChanges();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Erstellt eine Ausgabe-GB-Position mit Kreditor.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="faLeistung"></param>
        /// <param name="kbuKonto"></param>
        /// <param name="baPerson"></param>
        /// <returns></returns>
        public WshGrundbudgetPosition Create(IUnitOfWork unitOfWork, FaLeistung faLeistung = null, KbuKonto kbuKonto = null, BaPerson baPerson = null)
        {
            unitOfWork = UnitOfWork.GetNewOrParent(unitOfWork);
            var leistung = faLeistung ?? _leistungHelper.Create(unitOfWork);
            var konto = kbuKonto ?? _kontoHelper.Create(unitOfWork);
            var person = baPerson ?? _personHelper.Create(unitOfWork);

            var service = Container.Resolve<WshGrundbudgetPositionService>();
            WshGrundbudgetPosition grundbudgetPosition;
            service.NewData(out grundbudgetPosition);

            var today = DateTime.Today;

            // GB-Position
            grundbudgetPosition.FaLeistung = leistung;
            grundbudgetPosition.KbuKonto = konto;
            grundbudgetPosition.BaPerson = person;
            grundbudgetPosition.BetragMonatlich = 1469;
            grundbudgetPosition.DatumVon = new DateTime(today.Year, today.Month, 1);
            grundbudgetPosition.DatumBis = grundbudgetPosition.DatumVon.AddYears(1).AddDays(-1);
            grundbudgetPosition.Bemerkung = "Das ist eine Bemerkung";
            grundbudgetPosition.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;
            grundbudgetPosition.Text = "GBL UnitTestPosition";
            grundbudgetPosition.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat;
            grundbudgetPosition.WshBewilligungStatusCode = (int)LOVsGenerated.WshBewilligungStatus.BewilligungErteilt;
            grundbudgetPosition.WshKategorie = _kategorieHelper.GetWshKategorie(unitOfWork, LOVsGenerated.WshKategorie.Ausgabe);

            // Kreditor/Zahlungsweg
            var zahlungsweg = _zahlungswegHelper.Create(unitOfWork);
            var kreditorSvc = Container.Resolve<WshGrundbudgetPositionKreditorService>();
            WshGrundbudgetPositionKreditor kreditor;
            kreditorSvc.NewData(out kreditor);
            kreditor.BaZahlungsweg = zahlungsweg;
            kreditor.WshGrundbudgetPosition = grundbudgetPosition;

            var result = service.SaveData(unitOfWork, grundbudgetPosition);

            if (!result)
            {
                throw new InvalidOperationException(result);
            }

            _list.Add(grundbudgetPosition);

            return grundbudgetPosition;
        }

        public WshGrundbudgetPosition Create(
            IUnitOfWork unitOfWork,
            FaLeistung leistung,
            DateTime datumVon,
            DateTime? datumBis,
            string text,
            decimal betrag,
            KbuKonto konto,
            BaPerson person,
            LOVsGenerated.WshKategorie kategorie,
            bool verwaltungSd)
        {
            var repositoryPosition = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);

            var position = new WshGrundbudgetPosition
            {
                FaLeistung = leistung,
                KbuKonto = konto,
                DatumVon = datumVon,
                DatumBis = datumBis,
                Text = text,
                BetragMonatlich = betrag,
                BaPerson = person,
                WshKategorie = _kategorieHelper.GetWshKategorie(unitOfWork, kategorie),
                WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat,
                VerwaltungSD = verwaltungSd,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };

            _list.Add(position);

            repositoryPosition.ApplyChanges(position);
            unitOfWork.SaveChanges();
            position.AcceptChanges();

            return position;
        }

        /// <summary>
        /// Elektroniche Auszahlung mit Kreditor erstellen
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork</param>
        /// <returns>Die neu erstellte Grundbudgetposition (<see cref="WshGrundbudgetPosition"/>)</returns>
        public WshGrundbudgetPosition CreateAusgabe(IUnitOfWork unitOfWork)
        {
            var leistung = _leistungHelper.Create(unitOfWork);
            var konto = _kontoHelper.Create(unitOfWork);
            var person = _personHelper.Create(unitOfWork);

            var zahlungswegHelper = new BaZahlungswegHelper();
            var zahlungsweg = zahlungswegHelper.Create(unitOfWork, person);

            var position = Create(unitOfWork, leistung, new DateTime(2011, 08, 01), null, "GBL Test", 1200, konto, person, LOVsGenerated.WshKategorie.Ausgabe, false);
            position.KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung;

            CreateKreditor(unitOfWork, position, zahlungsweg);

            return position;
        }

        public WshGrundbudgetPosition CreateEinnahme(IUnitOfWork unitOfWork)
        {
            var leistung = _leistungHelper.Create(unitOfWork);
            var konto = _kontoHelper.Create(unitOfWork);
            var person = _personHelper.Create(unitOfWork);

            var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);
            var grundbudgetPosition = new WshGrundbudgetPosition
            {
                FaLeistung = leistung,
                KbuKonto = konto,
                BaPerson = person,
                BetragMonatlich = 900,
                DatumVon = new DateTime(DateTime.Today.Year, 1, 1),
                DatumBis = new DateTime(DateTime.Today.Year, 12, 31),
                Bemerkung = "Das ist eine Bemerkung",
                Text = "GBL UnitTestPosition",
                WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat,
                WshBewilligungStatusCode = (int)LOVsGenerated.WshBewilligungStatus.BewilligungErteilt,
                WshKategorie = _kategorieHelper.GetWshKategorie(unitOfWork, LOVsGenerated.WshKategorie.Einnahme),
                VerwaltungSD = true,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };

            repository.ApplyChanges(grundbudgetPosition);
            unitOfWork.SaveChanges();
            grundbudgetPosition.AcceptChanges();

            _list.Add(grundbudgetPosition);

            return grundbudgetPosition;
        }

        /// <summary>
        /// Kreditor für die Position <paramref name="position"/> mit dem Zahlungsweg <paramref name="zahlungsweg"/> erstellen
        /// </summary>
        /// <param name="unitOfWork">Die UnitOfWork</param>
        /// <param name="position">Die Position für welche den Kerditor erstellt werden muss</param>
        /// <param name="zahlungsweg">Der Zahlungsweg des Kreditors</param>
        /// <returns>Der neu erstellten Kreditor (<see cref="WshGrundbudgetPositionKreditor"/>)</returns>
        public WshGrundbudgetPositionKreditor CreateKreditor(IUnitOfWork unitOfWork, WshGrundbudgetPosition position, BaZahlungsweg zahlungsweg)
        {
            var repositoryPositionKreditor = UnitOfWork.GetRepository<WshGrundbudgetPositionKreditor>(unitOfWork);

            var kreditor = new WshGrundbudgetPositionKreditor
            {
                WshGrundbudgetPosition = position,
                BaZahlungsweg = zahlungsweg,
                MitteilungZeile1 = zahlungsweg == null ? "Mitteilung Zeile 1" : null,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };
            _listKreditor.Add(kreditor);

            repositoryPositionKreditor.ApplyChanges(kreditor);
            unitOfWork.SaveChanges();
            kreditor.AcceptChanges();

            return kreditor;
        }

        public WshGrundbudgetPosition CreateNichtGBLPosition(IUnitOfWork unitOfWork)
        {
            var leistung = _leistungHelper.Create(unitOfWork);
            var konto = _kontoHelper.Create(unitOfWork, "110", "Miete", LOVsGenerated.KbuKontoklasse.Aufwand);
            var person = _personHelper.Create(unitOfWork);

            var today = DateTime.Today;

            var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);
            var grundbudgetPosition = new WshGrundbudgetPosition
            {
                FaLeistung = leistung,
                KbuKonto = konto,
                BaPerson = person,
                BetragMonatlich = 1469,
                DatumVon = new DateTime(today.Year, today.Month, 1),
                DatumBis = new DateTime(today.Year, today.Month, 1).AddYears(1).AddDays(-1),
                Bemerkung = "Das ist eine Bemerkung",
                KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung,
                Text = "GBL UnitTestPosition",
                WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat,
                WshBewilligungStatusCode = (int)LOVsGenerated.WshBewilligungStatus.BewilligungErteilt,
                WshKategorie = _kategorieHelper.GetWshKategorie(unitOfWork, LOVsGenerated.WshKategorie.Ausgabe),
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };

            repository.ApplyChanges(grundbudgetPosition);
            unitOfWork.SaveChanges();
            grundbudgetPosition.AcceptChanges();

            _list.Add(grundbudgetPosition);

            return grundbudgetPosition;
        }

        public WshGrundbudgetPosition CreateNoDatumBis(IUnitOfWork unitOfWork)
        {
            var leistung = _leistungHelper.Create(unitOfWork);
            var konto = _kontoHelper.Create(unitOfWork);
            var person = _personHelper.Create(unitOfWork);

            var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);
            var grundbudgetPosition = new WshGrundbudgetPosition
            {
                FaLeistung = leistung,
                KbuKonto = konto,
                BaPerson = person,
                BetragMonatlich = 1469,
                DatumVon = new DateTime(2011, 1, 1),
                WshKategorie = _kategorieHelper.GetWshKategorie(unitOfWork, LOVsGenerated.WshKategorie.Ausgabe),
                Bemerkung = "Das ist eine Bemerkung",
                KbuAuszahlungArtCode = (int)LOVsGenerated.KbuAuszahlungArt.ElektronischeAuszahlung,
                Text = "GBL UnitTestPosition",
                WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat,
                WshBewilligungStatusCode = (int)LOVsGenerated.WshBewilligungStatus.BewilligungErteilt,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };

            repository.ApplyChanges(grundbudgetPosition);
            unitOfWork.SaveChanges();
            grundbudgetPosition.AcceptChanges();

            _list.Add(grundbudgetPosition);

            return grundbudgetPosition;
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            // delete debitor
            _listDebitor.ForEach(x => DeleteDebitor(unitOfWork, x));
            unitOfWork.SaveChanges();
            _listDebitor.ForEach(x => x.AcceptChanges());

            // delete kreditor
            _listKreditor.ForEach(x => DeleteKreditor(unitOfWork, x));
            unitOfWork.SaveChanges();
            _listKreditor.ForEach(x => x.AcceptChanges());

            // delete position
            _list.ForEach(x => DeleteWshGrundbudgetPosition(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());

            // delete abzug
            _listAbzug.ForEach(x => DeleteAbzug(unitOfWork, x));
            unitOfWork.SaveChanges();
            _listAbzug.ForEach(x => x.AcceptChanges());

            _leistungHelper.Delete(unitOfWork);
            _kontoHelper.Delete(unitOfWork);
        }

        #endregion

        #region Private Static Methods

        private static void DeleteAbzug(IUnitOfWork unitOfWork, WshAbzug wshAbzug)
        {
            // WshAbzugDetail
            var repoDetail = UnitOfWork.GetRepository<WshAbzugDetail>(unitOfWork);
            var details = repoDetail.Where(x => x.WshAbzugID == wshAbzug.WshAbzugID);

            foreach (var detail in details)
            {
                detail.MarkAsDeleted();
                repoDetail.ApplyChanges(detail);
            }

            // WshAbzug
            var repository = UnitOfWork.GetRepository<WshAbzug>(unitOfWork);
            var entity = (from x in repository
                          where x.WshAbzugID == wshAbzug.WshAbzugID
                          select x).SingleOrDefault();

            if (entity != null)
            {
                entity.MarkAsDeleted();
                repository.ApplyChanges(entity);
            }
        }

        private static void DeleteDebitor(IUnitOfWork unitOfWork, WshGrundbudgetPositionDebitor debitor)
        {
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPositionDebitor>(unitOfWork);
            var entity = (from x in repository
                          where x.WshGrundbudgetPositionDebitorID == debitor.WshGrundbudgetPositionDebitorID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        private static void DeleteKreditor(IUnitOfWork unitOfWork, WshGrundbudgetPositionKreditor kreditor)
        {
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPositionKreditor>(unitOfWork);
            var entity = (from x in repository
                          where x.WshGrundbudgetPositionKreditorID == kreditor.WshGrundbudgetPositionKreditorID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        private static void DeleteWshGrundbudgetPosition(IUnitOfWork unitOfWork, WshGrundbudgetPosition position)
        {
            var repository = UnitOfWork.GetRepository<WshGrundbudgetPosition>(unitOfWork);

            var entity = (from x in repository
                          where x.WshGrundbudgetPositionID == position.WshGrundbudgetPositionID
                          select x).FirstOrDefault();

            if (entity == null)
            {
                return;
            }

            DeleteWshPositionInclBelongingData(unitOfWork, entity.WshGrundbudgetPositionID);

            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}