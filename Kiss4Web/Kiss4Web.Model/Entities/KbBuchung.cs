using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbBuchung
    {
        public KbBuchung()
        {
            IkBetreibungAusgleich = new HashSet<IkBetreibungAusgleich>();
            InverseNeubuchungVonKbBuchung = new HashSet<KbBuchung>();
            InverseStorniertKbBuchung = new HashSet<KbBuchung>();
            KbBuchungKostenart = new HashSet<KbBuchungKostenart>();
            KbForderungAuszahlungKbBuchungIdAuszahlungNavigation = new HashSet<KbForderungAuszahlung>();
            KbForderungAuszahlungKbBuchungIdForderungNavigation = new HashSet<KbForderungAuszahlung>();
            KbOpAusgleichAusgleichBuchung = new HashSet<KbOpAusgleich>();
            KbOpAusgleichOpBuchung = new HashSet<KbOpAusgleich>();
            KbTransfer = new HashSet<KbTransfer>();
        }

        public int KbBuchungId { get; set; }
        public int? BaZahlungswegId { get; set; }
        public int? KbAuszahlungsArtCode { get; set; }
        public int? FlTypSourceCode { get; set; }
        public int? FlBelegStatusCode { get; set; }
        public int? IdSource { get; set; }
        public int? BelegNr { get; set; }
        public int? BarbelegUserId { get; set; }
        public DateTime ErstelltDatum { get; set; }
        public DateTime? TransferDatum { get; set; }
        public DateTime? BelegDatum { get; set; }
        public DateTime? ValutaDatum { get; set; }
        public DateTime? BarbelegDatum { get; set; }
        public string Text { get; set; }
        public string Extern { get; set; }
        public string ReferenzNummer { get; set; }
        public string AggregateInfo { get; set; }
        public string FibuFehlermeldung { get; set; }
        public string Remark { get; set; }
        public int? OldSourceId { get; set; }
        public byte[] KbBuchungTs { get; set; }
        public int KbPeriodeId { get; set; }
        public int KbBuchungTypCode { get; set; }
        public int? KbBuchungStatusCode { get; set; }
        public decimal Betrag { get; set; }
        public string SollKtoNr { get; set; }
        public string HabenKtoNr { get; set; }
        public int? EinzahlungsscheinCode { get; set; }
        public string PckontoNr { get; set; }
        public string BankKontoNr { get; set; }
        public string Iban { get; set; }
        public int? BaBankId { get; set; }
        public string BankBcn { get; set; }
        public string BankName { get; set; }
        public string BankStrasse { get; set; }
        public string BankPlz { get; set; }
        public string BankOrt { get; set; }
        public string Zahlungsgrund { get; set; }
        public string MitteilungZeile1 { get; set; }
        public string MitteilungZeile2 { get; set; }
        public string MitteilungZeile3 { get; set; }
        public string MitteilungZeile4 { get; set; }
        public string BeguenstigtName { get; set; }
        public string BeguenstigtName2 { get; set; }
        public string BeguenstigtStrasse { get; set; }
        public string BeguenstigtHausNr { get; set; }
        public string BeguenstigtPostfach { get; set; }
        public string BeguenstigtPlz { get; set; }
        public string BeguenstigtOrt { get; set; }
        public int? BeguenstigtLandCode { get; set; }
        public int? KbZahlungseingangId { get; set; }
        public int ErstelltUserId { get; set; }
        public int? MutiertUserId { get; set; }
        public DateTime? MutiertDatum { get; set; }
        public int? SchuldnerBaInstitutionId { get; set; }
        public int? SchuldnerBaPersonId { get; set; }
        public int? StorniertKbBuchungId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? BgBudgetId { get; set; }
        public int? IkPositionId { get; set; }
        public int? NeubuchungVonKbBuchungId { get; set; }
        public int? KbBelegKreisId { get; set; }
        public int? KbZahlungskontoId { get; set; }
        public int? IkForderungBgKostenartHistId { get; set; }

        public BaBank BaBank { get; set; }
        public BaZahlungsweg BaZahlungsweg { get; set; }
        public XUser BarbelegUser { get; set; }
        public BaLand BeguenstigtLandCodeNavigation { get; set; }
        public BgBudget BgBudget { get; set; }
        public XUser ErstelltUser { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public IkForderungBgKostenartHist IkForderungBgKostenartHist { get; set; }
        public IkPosition IkPosition { get; set; }
        public KbBelegKreis KbBelegKreis { get; set; }
        public KbPeriode KbPeriode { get; set; }
        public KbZahlungseingang KbZahlungseingang { get; set; }
        public KbZahlungskonto KbZahlungskonto { get; set; }
        public XUser MutiertUser { get; set; }
        public KbBuchung NeubuchungVonKbBuchung { get; set; }
        public BaInstitution SchuldnerBaInstitution { get; set; }
        public BaPerson SchuldnerBaPerson { get; set; }
        public KbBuchung StorniertKbBuchung { get; set; }
        public ICollection<IkBetreibungAusgleich> IkBetreibungAusgleich { get; set; }
        public ICollection<KbBuchung> InverseNeubuchungVonKbBuchung { get; set; }
        public ICollection<KbBuchung> InverseStorniertKbBuchung { get; set; }
        public ICollection<KbBuchungKostenart> KbBuchungKostenart { get; set; }
        public ICollection<KbForderungAuszahlung> KbForderungAuszahlungKbBuchungIdAuszahlungNavigation { get; set; }
        public ICollection<KbForderungAuszahlung> KbForderungAuszahlungKbBuchungIdForderungNavigation { get; set; }
        public ICollection<KbOpAusgleich> KbOpAusgleichAusgleichBuchung { get; set; }
        public ICollection<KbOpAusgleich> KbOpAusgleichOpBuchung { get; set; }
        public ICollection<KbTransfer> KbTransfer { get; set; }
    }
}
