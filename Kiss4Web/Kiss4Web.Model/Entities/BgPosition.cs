using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgPosition
    {
        public BgPosition()
        {
            BgAuszahlungPerson = new HashSet<BgAuszahlungPerson>();
            BgBewilligung = new HashSet<BgBewilligung>();
            BgDokument = new HashSet<BgDokument>();
            InverseBgPositionIdAutoForderungNavigation = new HashSet<BgPosition>();
            InverseBgPositionIdCopyOfNavigation = new HashSet<BgPosition>();
            InverseBgPositionIdParentNavigation = new HashSet<BgPosition>();
            KbBuchungKostenart = new HashSet<KbBuchungKostenart>();
        }

        public int BgPositionId { get; set; }
        public int? BgPositionIdParent { get; set; }
        public int? BgPositionIdCopyOf { get; set; }
        public int BgBudgetId { get; set; }
        public int? BaPersonId { get; set; }
        public int? BgPositionsartId { get; set; }
        public int? BgSpezkontoId { get; set; }
        public int? BaInstitutionId { get; set; }
        public int? DebitorBaPersonId { get; set; }
        public int? ErstelltUserId { get; set; }
        public int? MutiertUserId { get; set; }
        public int? BgPositionIdAutoForderung { get; set; }
        public int BgKategorieCode { get; set; }
        public int? ShBelegId { get; set; }
        public decimal Betrag { get; set; }
        public decimal Reduktion { get; set; }
        public decimal Abzug { get; set; }
        public decimal? BetragEff { get; set; }
        public decimal MaxBeitragSd { get; set; }
        public string Buchungstext { get; set; }
        public bool VerwaltungSd { get; set; }
        public string Bemerkung { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int? OldId { get; set; }
        public DateTime? VerwPeriodeVon { get; set; }
        public DateTime? VerwPeriodeBis { get; set; }
        public DateTime? FaelligAm { get; set; }
        public DateTime? RechnungDatum { get; set; }
        public int BgBewilligungStatusCode { get; set; }
        public decimal? BetragAnfrage { get; set; }
        public int? BgAuszahlungId { get; set; }
        public DateTime? DatumEff { get; set; }
        public string BemerkungSaldierung { get; set; }
        public bool Saldiert { get; set; }
        public DateTime? ErstelltDatum { get; set; }
        public DateTime? MutiertDatum { get; set; }
        public byte[] BgPositionTs { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public BaPerson BaPerson { get; set; }
        public BgBudget BgBudget { get; set; }
        public BgPosition BgPositionIdAutoForderungNavigation { get; set; }
        public BgPosition BgPositionIdCopyOfNavigation { get; set; }
        public BgPosition BgPositionIdParentNavigation { get; set; }
        public BgPositionsart BgPositionsart { get; set; }
        public BgSpezkonto BgSpezkonto { get; set; }
        public BaPerson DebitorBaPerson { get; set; }
        public XUser ErstelltUser { get; set; }
        public XUser MutiertUser { get; set; }
        public ICollection<BgAuszahlungPerson> BgAuszahlungPerson { get; set; }
        public ICollection<BgBewilligung> BgBewilligung { get; set; }
        public ICollection<BgDokument> BgDokument { get; set; }
        public ICollection<BgPosition> InverseBgPositionIdAutoForderungNavigation { get; set; }
        public ICollection<BgPosition> InverseBgPositionIdCopyOfNavigation { get; set; }
        public ICollection<BgPosition> InverseBgPositionIdParentNavigation { get; set; }
        public ICollection<KbBuchungKostenart> KbBuchungKostenart { get; set; }
    }
}
