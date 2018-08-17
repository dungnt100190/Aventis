using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    public class WshPositionHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly KbuKontoHelper _kontoHelper = new KbuKontoHelper();
        private readonly FaLeistungHelper _leistungHelper = new FaLeistungHelper();
        private readonly List<WshPosition> _list = new List<WshPosition>();
        private readonly List<WshPositionDebitor> _listDebitor = new List<WshPositionDebitor>();
        private readonly List<WshPositionKreditor> _listKreditor = new List<WshPositionKreditor>();

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public WshPosition Create(IUnitOfWork unitOfWork)
        {
            var leistung = _leistungHelper.Create(unitOfWork);
            var konto = _kontoHelper.Create(unitOfWork);

            return Create(unitOfWork, leistung, 2011, 4, "GBL Lebensunterhalt", 150, konto, null, LOVsGenerated.WshKategorie.Ausgabe, DateTime.Today);
        }

        public WshPosition Create(
            IUnitOfWork unitOfWork,
            FaLeistung leistung,
            int jahr,
            int monat,
            string text,
            decimal betrag,
            KbuKonto konto,
            BaPerson person,
            LOVsGenerated.WshKategorie kategorie,
            DateTime faelligAm,
            bool verwaltungSD = false)
        {
            var repositoryPosition = UnitOfWork.GetRepository<WshPosition>(unitOfWork);

            var position = new WshPosition
            {
                FaLeistung = leistung,
                KbuKonto = konto,
                MonatVon = new DateTime(jahr, monat, 1),
                MonatBis =  new DateTime(jahr, monat, 1).AddMonths(1).AddDays(-1),
                Text = text,
                Betrag = betrag,
                BaPerson = person,
                WshKategorieID = (int)kategorie,
                VerwPeriodeVon = new DateTime(jahr, monat, 1),
                VerwPeriodeBis = new DateTime(jahr, monat, DateTime.DaysInMonth(jahr, monat)),
                WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet._1xProMonat,
                FaelligAm = faelligAm,
                VerwaltungSD = verwaltungSD,
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

        public WshPosition CreateAusgabe(
            IUnitOfWork unitOfWork,
            FaLeistung leistung,
            int jahr,
            int monat,
            string text,
            decimal betrag,
            KbuKonto konto,
            BaPerson personBetrifft)
        {
            var zahlungswegHelper = new BaZahlungswegHelper();
            var zahlungsweg = zahlungswegHelper.Create(unitOfWork);

            return CreateAusgabe(unitOfWork, leistung, jahr, monat, text, betrag, konto, personBetrifft, zahlungsweg, DateTime.Now);
        }

        public WshPosition CreateAusgabe(
            IUnitOfWork unitOfWork,
            FaLeistung leistung,
            int jahr,
            int monat,
            string text,
            decimal betrag,
            KbuKonto konto,
            BaPerson personBetrifft,
            BaZahlungsweg zahlungsweg,
            DateTime valutaDatum)
        {
            var position = Create(unitOfWork, leistung, jahr, monat, text, betrag, konto, personBetrifft, LOVsGenerated.WshKategorie.Ausgabe, valutaDatum);
            CreateKreditor(unitOfWork, position, zahlungsweg);

            return position;
        }

        public WshPositionDebitor CreateDebitor(IUnitOfWork unitOfWork, WshPosition position, BaPerson person)
        {
            var repositoryPositionDebitor = UnitOfWork.GetRepository<WshPositionDebitor>(unitOfWork);

            var debitor = new WshPositionDebitor
            {
                WshPosition = position,
                BaPerson = person,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };
            _listDebitor.Add(debitor);

            repositoryPositionDebitor.ApplyChanges(debitor);
            unitOfWork.SaveChanges();
            debitor.AcceptChanges();

            return debitor;
        }

        public WshPosition CreateEinnahme(
            IUnitOfWork unitOfWork,
            FaLeistung leistung,
            int jahr,
            int monat,
            string text,
            decimal betrag,
            KbuKonto konto,
            BaPerson personBetrifft,
            BaPerson debitor = null,
            bool verwaltungSD = false)
        {
            if (debitor == null)
            {
                var personHelper = new BaPersonHelper();
                debitor = personHelper.Create(unitOfWork);
            }
            var position = Create(unitOfWork, leistung, jahr, monat, text, betrag, konto, personBetrifft, LOVsGenerated.WshKategorie.Einnahme, DateTime.Today.AddDays(20), verwaltungSD);
            CreateDebitor(unitOfWork, position, debitor);

            return position;
        }

        public WshPositionKreditor CreateKreditor(IUnitOfWork unitOfWork, WshPosition position, BaZahlungsweg zahlungsweg)
        {
            var repositoryPositionKreditor = UnitOfWork.GetRepository<WshPositionKreditor>(unitOfWork);

            var kreditor = new WshPositionKreditor
            {
                WshPosition = position,
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
            _list.ForEach(x => DeletePosition(unitOfWork, x));
            unitOfWork.SaveChanges();
            _list.ForEach(x => x.AcceptChanges());
        }

        #endregion

        #region Private Static Methods

        private static void DeleteDebitor(IUnitOfWork unitOfWork, WshPositionDebitor debitor)
        {
            var repository = UnitOfWork.GetRepository<WshPositionDebitor>(unitOfWork);
            var entity = (from x in repository
                          where x.WshPositionDebitorID == debitor.WshPositionDebitorID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        private static void DeleteKreditor(IUnitOfWork unitOfWork, WshPositionKreditor kreditor)
        {
            var repository = UnitOfWork.GetRepository<WshPositionKreditor>(unitOfWork);
            var entity = (from x in repository
                          where x.WshPositionKreditorID == kreditor.WshPositionKreditorID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        private static void DeletePosition(IUnitOfWork unitOfWork, WshPosition position)
        {
            var repository = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            var entity = (from x in repository
                          where x.WshPositionID == position.WshPositionID
                          select x).Single();
            entity.MarkAsDeleted();
            repository.ApplyChanges(entity);
        }

        #endregion

        #endregion
    }
}