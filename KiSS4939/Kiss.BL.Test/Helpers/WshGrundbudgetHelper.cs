using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.BL.Test.Helpers
{
    /// <summary>
    /// Erstellt ein kleines Grundbudget.
    /// </summary>
    public class WshGrundbudgetHelper : BaseHelper
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<WshGrundbudgetPositionDebitor> _debitorList = new List<WshGrundbudgetPositionDebitor>();
        private readonly List<WshGrundbudgetPosition> _entities = new List<WshGrundbudgetPosition>();
        private readonly WshGrundbudgetPositionHelper _grundbudgetPositionHelper = new WshGrundbudgetPositionHelper();
        private readonly List<WshGrundbudgetPositionKreditor> _kreditorList = new List<WshGrundbudgetPositionKreditor>();

        #endregion

        #region Private Fields

        private WshPosition _wshPosition;
        private WshPositionKreditor _wshPositionKreditor;

        #endregion

        #endregion

        #region Properties

        public List<WshGrundbudgetPositionDebitor> DebitorList
        {
            get { return _debitorList; }
        }

        public List<WshGrundbudgetPosition> Entities
        {
            get { return _entities; }
        }

        public KbuKonto KbuKonto
        {
            get;
            set;
        }

        public List<WshGrundbudgetPositionKreditor> KreditorList
        {
            get { return _kreditorList; }
        }

        public FaLeistung Leistung
        {
            get;
            set;
        }

        public FaLeistung LeistungOhneBisDatum
        {
            get;
            set;
        }

        public BaPerson Person
        {
            get;
            set;
        }

        public WshGrundbudgetPosition Position
        {
            get;
            set;
        }

        public WshGrundbudgetPosition PositionDebitor
        {
            get;
            set;
        }

        public WshGrundbudgetPosition PositionNoGBL
        {
            get;
            set;
        }

        public WshGrundbudgetPosition PositionOhneBisDatum
        {
            get;
            set;
        }

        public BaZahlungsweg Zahlungsweg
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Erstellt ein kleines Grundbudget.
        ///  
        /// </summary>
        /// <param name="unitOfWork"></param>
        public void CreateGrundbudget(IUnitOfWork unitOfWork)
        {
            Position = _grundbudgetPositionHelper.Create(unitOfWork);
            Leistung = Position.FaLeistung;
            KbuKonto = Position.KbuKonto;
            Person = Position.FaLeistung.BaPerson;
            KreditorList.AddRange(Position.WshGrundbudgetPositionKreditor);
            Zahlungsweg = Position.WshGrundbudgetPositionKreditor.First().BaZahlungsweg;

            PositionOhneBisDatum = _grundbudgetPositionHelper.CreateNoDatumBis(unitOfWork);
            LeistungOhneBisDatum = PositionOhneBisDatum.FaLeistung;

            // Position ohne GBL erstellen
            PositionNoGBL = _grundbudgetPositionHelper.CreateNichtGBLPosition(unitOfWork);
            PositionNoGBL.WshPeriodizitaetCode = (int)LOVsGenerated.WshPeriodizitaet.Quartal;
            Entities.Add(PositionNoGBL);

            // Position mit Debitor erstellen
            PositionDebitor = _grundbudgetPositionHelper.CreateEinnahme(unitOfWork);
            Entities.Add(PositionDebitor);

            // Debitor
            var repositoryDebitor = UnitOfWork.GetRepository<WshGrundbudgetPositionDebitor>(unitOfWork);
            var debitor = new WshGrundbudgetPositionDebitor
            {
                BaPerson = PositionDebitor.BaPerson,
                WshGrundbudgetPosition = PositionDebitor,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now
            };

            repositoryDebitor.ApplyChanges(debitor);
            unitOfWork.SaveChanges();
            debitor.AcceptChanges();
            DebitorList.Add(debitor);

            // WshPosition erstellen
            var dateToday = DateTime.Today;
            var repositoryWshPosition = UnitOfWork.GetRepository<WshPosition>(unitOfWork);
            _wshPosition = new WshPosition
            {
                WshGrundbudgetPosition = Position,
                FaLeistung = Position.FaLeistung,
                BaPerson = Position.BaPerson,
                KbuKonto = Position.KbuKonto,
                BaInstitution = Position.BaInstitution,
                MonatVon = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1),
                MonatBis = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1),
                WshKategorieID = Position.WshKategorieID,
                WshKategorie = Position.WshKategorie,
                WshBewilligungStatusCode = Position.WshBewilligungStatusCode,
                KbuAuszahlungArtCode = Position.KbuAuszahlungArtCode,
                VerwPeriodeVon = dateToday,
                VerwPeriodeBis = new DateTime(dateToday.Year, dateToday.Month, DateTime.DaysInMonth(dateToday.Year, dateToday.Month)),
                Betrag = Position.BetragMonatlich,
                VerwaltungSD = Position.VerwaltungSD,
                WshPeriodizitaetCode = Position.WshPeriodizitaetCode,
                FaelligAm = new DateTime(dateToday.Year, dateToday.Month, 15),
                Text = Position.Text,
                Bemerkung = Position.Bemerkung,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };

            repositoryWshPosition.ApplyChanges(_wshPosition);
            unitOfWork.SaveChanges();
            _wshPosition.AcceptChanges();

            // WshPositionKreditor erstellen
            var repositoryWshPositionKreditor = UnitOfWork.GetRepository<WshPositionKreditor>(unitOfWork);
            _wshPositionKreditor = new WshPositionKreditor
            {
                WshPosition = _wshPosition,
                BaZahlungsweg = Zahlungsweg,
                ReferenzNummer = null,
                MitteilungZeile1 = "Ich bin eine Zeile 1",
                MitteilungZeile2 = null,
                MitteilungZeile3 = null,
                MitteilungZeile4 = null,
                Creator = CREATOR,
                Created = DateTime.Now,
                Modifier = CREATOR,
                Modified = DateTime.Now,
            };

            repositoryWshPositionKreditor.ApplyChanges(_wshPositionKreditor);
            unitOfWork.SaveChanges();
            _wshPositionKreditor.AcceptChanges();
        }

        public void Delete(IUnitOfWork unitOfWork)
        {
            // WshGrundbudgetPositionen löschen
            if (Position != null && !Entities.Contains(Position))
            {
                Entities.Add(Position);
            }

            if (PositionDebitor != null && !Entities.Contains(PositionDebitor))
            {
                Entities.Add(PositionDebitor);
            }

            // löscht auch Kreditor-/Debitor-Infos
            Entities.ForEach(x => WshGrundbudgetPositionHelper.DeleteWshGrundbudgetPosition(unitOfWork, x.WshGrundbudgetPositionID));
            unitOfWork.SaveChanges();

            // Zahlungsweg löschen.
            if (Zahlungsweg != null)
            {
                var repositoryZahlungsweg = UnitOfWork.GetRepository<BaZahlungsweg>(unitOfWork);
                Zahlungsweg = repositoryZahlungsweg.Where(x => x.BaZahlungswegID == Zahlungsweg.BaZahlungswegID).Single();
                Zahlungsweg.MarkAsDeleted();
                repositoryZahlungsweg.ApplyChanges(Zahlungsweg);
                unitOfWork.SaveChanges();
            }
            // WshGrundbudgetPosition löschen
            _grundbudgetPositionHelper.Delete(unitOfWork);
        }

        #endregion

        #endregion
    }
}