using System;
using System.Collections.Generic;
using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class FaLeistung : IEntity, IAuditableEntity
    {
        public FaLeistung()
        {
            Bfsdossier = new HashSet<Bfsdossier>();
            BgFinanzplan = new HashSet<BgFinanzplan>();
            BgSpezkonto = new HashSet<BgSpezkonto>();
            BgZahlungsmodus = new HashSet<BgZahlungsmodus>();
            DynaValue = new HashSet<DynaValue>();
            FaAktennotizen = new HashSet<FaAktennotizen>();
            FaDokumentAblage = new HashSet<FaDokumentAblage>();
            FaDokumente = new HashSet<FaDokumente>();
            FaLeistungArchiv = new HashSet<FaLeistungArchiv>();
            FaLeistungBewertung = new HashSet<FaLeistungBewertung>();
            FaLeistungUserHist = new HashSet<FaLeistungUserHist>();
            FaLeistungZugriff = new HashSet<FaLeistungZugriff>();
            FaPhase = new HashSet<FaPhase>();
            FaRelationFaLeistungId1Navigation = new HashSet<FaRelation>();
            FaRelationFaLeistungId2Navigation = new HashSet<FaRelation>();
            FaWeisung = new HashSet<FaWeisung>();
            FbBarauszahlungAuftrag = new HashSet<FbBarauszahlungAuftrag>();
            IkAbklaerung = new HashSet<IkAbklaerung>();
            IkAnzeige = new HashSet<IkAnzeige>();
            IkBetreibung = new HashSet<IkBetreibung>();
            IkForderung = new HashSet<IkForderung>();
            IkGlaeubiger = new HashSet<IkGlaeubiger>();
            IkPosition = new HashSet<IkPosition>();
            IkRatenplan = new HashSet<IkRatenplan>();
            IkRechtstitel = new HashSet<IkRechtstitel>();
            KaAbklaerungIntake = new HashSet<KaAbklaerungIntake>();
            KaAbklaerungVertieft = new HashSet<KaAbklaerungVertieft>();
            KaAkzuweiser = new HashSet<KaAkzuweiser>();
            KaAllgemein = new HashSet<KaAllgemein>();
            KaAssistenz = new HashSet<KaAssistenz>();
            KaAusbildung = new HashSet<KaAusbildung>();
            KaEafSozioberuflicheBilanz = new HashSet<KaEafSozioberuflicheBilanz>();
            KaEafSpezifischeErmittlung = new HashSet<KaEafSpezifischeErmittlung>();
            KaEinsatz = new HashSet<KaEinsatz>();
            KaExterneBildung = new HashSet<KaExterneBildung>();
            KaInizio = new HashSet<KaInizio>();
            KaIntegBildung = new HashSet<KaIntegBildung>();
            KaJobtimal = new HashSet<KaJobtimal>();
            KaKontaktartProzess = new HashSet<KaKontaktartProzess>();
            KaQeepq = new HashSet<KaQeepq>();
            KaQeepqzielvereinb = new HashSet<KaQeepqzielvereinb>();
            KaQeepqzielvereinbVerl = new HashSet<KaQeepqzielvereinbVerl>();
            KaQejobtimum = new HashSet<KaQejobtimum>();
            KaQjbildung = new HashSet<KaQjbildung>();
            KaQjintake = new HashSet<KaQjintake>();
            KaQjprozess = new HashSet<KaQjprozess>();
            KaQjpzassessment = new HashSet<KaQjpzassessment>();
            KaQjpzbericht = new HashSet<KaQjpzbericht>();
            KaQjpzschlussbericht = new HashSet<KaQjpzschlussbericht>();
            KaQjpzzielvereinbarung = new HashSet<KaQjpzzielvereinbarung>();
            KaQjvereinbarung = new HashSet<KaQjvereinbarung>();
            KaTransfer = new HashSet<KaTransfer>();
            KaTransferZielvereinb = new HashSet<KaTransferZielvereinb>();
            KaVerlauf = new HashSet<KaVerlauf>();
            KaVermittlungBibip = new HashSet<KaVermittlungBibip>();
            KaVermittlungProfil = new HashSet<KaVermittlungProfil>();
            KaVermittlungSi = new HashSet<KaVermittlungSi>();
            KaVermittlungVorschlag = new HashSet<KaVermittlungVorschlag>();
            KbBuchung = new HashSet<KbBuchung>();
            KesAuftrag = new HashSet<KesAuftrag>();
            KesDokument = new HashSet<KesDokument>();
            KesMassnahme = new HashSet<KesMassnahme>();
            KesMassnahmeBss = new HashSet<KesMassnahmeBss>();
            KesPflegekinderaufsicht = new HashSet<KesPflegekinderaufsicht>();
            KesPraevention = new HashSet<KesPraevention>();
            KesVerlauf = new HashSet<KesVerlauf>();
            VmAhvmindestbeitrag = new HashSet<VmAhvmindestbeitrag>();
            VmAntragEksk = new HashSet<VmAntragEksk>();
            VmBericht = new HashSet<VmBericht>();
            VmBeschwerdeAnfrage = new HashSet<VmBeschwerdeAnfrage>();
            VmBewertung = new HashSet<VmBewertung>();
            VmBudget = new HashSet<VmBudget>();
            VmElkrankheitskosten = new HashSet<VmElkrankheitskosten>();
            VmErblasser = new HashSet<VmErblasser>();
            VmErbschaftsdienst = new HashSet<VmErbschaftsdienst>();
            VmGefaehrdungsMeldung = new HashSet<VmGefaehrdungsMeldung>();
            VmInventar = new HashSet<VmInventar>();
            VmKlientenbudget = new HashSet<VmKlientenbudget>();
            VmMandBericht = new HashSet<VmMandBericht>();
            VmMassnahme = new HashSet<VmMassnahme>();
            VmSachversicherung = new HashSet<VmSachversicherung>();
            VmSchulden = new HashSet<VmSchulden>();
            VmSiegelung = new HashSet<VmSiegelung>();
            VmSituationsBericht = new HashSet<VmSituationsBericht>();
            VmSozialversicherung = new HashSet<VmSozialversicherung>();
            VmSteuern = new HashSet<VmSteuern>();
            VmTestament = new HashSet<VmTestament>();
            VmVaterschaft = new HashSet<VmVaterschaft>();
            WhAsvseintrag = new HashSet<WhAsvseintrag>();
            Xtask = new HashSet<Xtask>();
        }

        public int FaLeistungId { get; set; }
        public int BaPersonId { get; set; }
        public int FaFallId { get; set; }
        public int ModulId { get; set; }
        public int UserId { get; set; }
        public int? SachbearbeiterId { get; set; }
        public int? SchuldnerBaPersonId { get; set; }
        public int? FaProzessCode { get; set; }
        public int? GemeindeCode { get; set; }
        public int? LeistungsartCode { get; set; }
        public int? EroeffnungsGrundCode { get; set; }
        public int? AbschlussGrundCode { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public string Bemerkung { get; set; }
        public string Dossiernummer { get; set; }
        public int? FaAufnahmeartCode { get; set; }
        public int? FaKontaktveranlasserCode { get; set; }
        public string FaTeilleistungserbringerCodes { get; set; }
        public int? FaModulDienstleistungenCode { get; set; }
        public int? IkSchuldnerStatusCode { get; set; }
        public int? IkAufenthaltsartCode { get; set; }
        public bool IkHatUnterstuetzung { get; set; }
        public bool IkIstRentenbezueger { get; set; }
        public bool? IkSchuldnerMahnen { get; set; }
        public int? IkEinnahmenQuoteCode { get; set; }
        public DateTime? IkDatumRechtskraft { get; set; }
        public int? IkInkassoBemuehungCode { get; set; }
        public DateTime? IkVerjaehrungAm { get; set; }
        public int? IkLeistungStatusCode { get; set; }
        public DateTime? IkDatumForderungstitel { get; set; }
        public int? IkRueckerstattungTypCode { get; set; }
        public int? IkForderungTitelCode { get; set; }
        public int? IkErreichungsGradCode { get; set; }
        public int? OldUnitId { get; set; }
        public int? VmAuftragCode { get; set; }
        public int? KaProzessCode { get; set; }
        public bool? KaEpqJob { get; set; }
        public string Bezeichnung { get; set; }
        public int? MigrationKa { get; set; }
        public long? PscdVertragsgegenstandId { get; set; }
        public string MigBemerkung { get; set; }
        public int? MigHerkunftCode { get; set; }
        public int? MigAlteFallNr { get; set; }
        public int? VufaFallId { get; set; }
        public string Visdat36Area { get; set; }
        public string Visdat36Fallid { get; set; }
        public string Visdat36Leistungid { get; set; }
        public bool WiederholteSpezifischeErmittlungEaf { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FaLeistungTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public XModul Modul { get; set; }
        public XUser Sachbearbeiter { get; set; }
        public BaPerson SchuldnerBaPerson { get; set; }
        public XUser User { get; set; }
        public FaZeitlichePlanung FaZeitlichePlanung { get; set; }
        public ICollection<Bfsdossier> Bfsdossier { get; set; }
        public ICollection<BgFinanzplan> BgFinanzplan { get; set; }
        public ICollection<BgSpezkonto> BgSpezkonto { get; set; }
        public ICollection<BgZahlungsmodus> BgZahlungsmodus { get; set; }
        public ICollection<DynaValue> DynaValue { get; set; }
        public ICollection<FaAktennotizen> FaAktennotizen { get; set; }
        public ICollection<FaDokumentAblage> FaDokumentAblage { get; set; }
        public ICollection<FaDokumente> FaDokumente { get; set; }
        public ICollection<FaLeistungArchiv> FaLeistungArchiv { get; set; }
        public ICollection<FaLeistungBewertung> FaLeistungBewertung { get; set; }
        public ICollection<FaLeistungUserHist> FaLeistungUserHist { get; set; }
        public ICollection<FaLeistungZugriff> FaLeistungZugriff { get; set; }
        public ICollection<FaPhase> FaPhase { get; set; }
        public ICollection<FaRelation> FaRelationFaLeistungId1Navigation { get; set; }
        public ICollection<FaRelation> FaRelationFaLeistungId2Navigation { get; set; }
        public ICollection<FaWeisung> FaWeisung { get; set; }
        public ICollection<FbBarauszahlungAuftrag> FbBarauszahlungAuftrag { get; set; }
        public ICollection<IkAbklaerung> IkAbklaerung { get; set; }
        public ICollection<IkAnzeige> IkAnzeige { get; set; }
        public ICollection<IkBetreibung> IkBetreibung { get; set; }
        public ICollection<IkForderung> IkForderung { get; set; }
        public ICollection<IkGlaeubiger> IkGlaeubiger { get; set; }
        public ICollection<IkPosition> IkPosition { get; set; }
        public ICollection<IkRatenplan> IkRatenplan { get; set; }
        public ICollection<IkRechtstitel> IkRechtstitel { get; set; }
        public ICollection<KaAbklaerungIntake> KaAbklaerungIntake { get; set; }
        public ICollection<KaAbklaerungVertieft> KaAbklaerungVertieft { get; set; }
        public ICollection<KaAkzuweiser> KaAkzuweiser { get; set; }
        public ICollection<KaAllgemein> KaAllgemein { get; set; }
        public ICollection<KaAssistenz> KaAssistenz { get; set; }
        public ICollection<KaAusbildung> KaAusbildung { get; set; }
        public ICollection<KaEafSozioberuflicheBilanz> KaEafSozioberuflicheBilanz { get; set; }
        public ICollection<KaEafSpezifischeErmittlung> KaEafSpezifischeErmittlung { get; set; }
        public ICollection<KaEinsatz> KaEinsatz { get; set; }
        public ICollection<KaExterneBildung> KaExterneBildung { get; set; }
        public ICollection<KaInizio> KaInizio { get; set; }
        public ICollection<KaIntegBildung> KaIntegBildung { get; set; }
        public ICollection<KaJobtimal> KaJobtimal { get; set; }
        public ICollection<KaKontaktartProzess> KaKontaktartProzess { get; set; }
        public ICollection<KaQeepq> KaQeepq { get; set; }
        public ICollection<KaQeepqzielvereinb> KaQeepqzielvereinb { get; set; }
        public ICollection<KaQeepqzielvereinbVerl> KaQeepqzielvereinbVerl { get; set; }
        public ICollection<KaQejobtimum> KaQejobtimum { get; set; }
        public ICollection<KaQjbildung> KaQjbildung { get; set; }
        public ICollection<KaQjintake> KaQjintake { get; set; }
        public ICollection<KaQjprozess> KaQjprozess { get; set; }
        public ICollection<KaQjpzassessment> KaQjpzassessment { get; set; }
        public ICollection<KaQjpzbericht> KaQjpzbericht { get; set; }
        public ICollection<KaQjpzschlussbericht> KaQjpzschlussbericht { get; set; }
        public ICollection<KaQjpzzielvereinbarung> KaQjpzzielvereinbarung { get; set; }
        public ICollection<KaQjvereinbarung> KaQjvereinbarung { get; set; }
        public ICollection<KaTransfer> KaTransfer { get; set; }
        public ICollection<KaTransferZielvereinb> KaTransferZielvereinb { get; set; }
        public ICollection<KaVerlauf> KaVerlauf { get; set; }
        public ICollection<KaVermittlungBibip> KaVermittlungBibip { get; set; }
        public ICollection<KaVermittlungProfil> KaVermittlungProfil { get; set; }
        public ICollection<KaVermittlungSi> KaVermittlungSi { get; set; }
        public ICollection<KaVermittlungVorschlag> KaVermittlungVorschlag { get; set; }
        public ICollection<KbBuchung> KbBuchung { get; set; }
        public ICollection<KesAuftrag> KesAuftrag { get; set; }
        public ICollection<KesDokument> KesDokument { get; set; }
        public ICollection<KesMassnahme> KesMassnahme { get; set; }
        public ICollection<KesMassnahmeBss> KesMassnahmeBss { get; set; }
        public ICollection<KesPflegekinderaufsicht> KesPflegekinderaufsicht { get; set; }
        public ICollection<KesPraevention> KesPraevention { get; set; }
        public ICollection<KesVerlauf> KesVerlauf { get; set; }
        public ICollection<VmAhvmindestbeitrag> VmAhvmindestbeitrag { get; set; }
        public ICollection<VmAntragEksk> VmAntragEksk { get; set; }
        public ICollection<VmBericht> VmBericht { get; set; }
        public ICollection<VmBeschwerdeAnfrage> VmBeschwerdeAnfrage { get; set; }
        public ICollection<VmBewertung> VmBewertung { get; set; }
        public ICollection<VmBudget> VmBudget { get; set; }
        public ICollection<VmElkrankheitskosten> VmElkrankheitskosten { get; set; }
        public ICollection<VmErblasser> VmErblasser { get; set; }
        public ICollection<VmErbschaftsdienst> VmErbschaftsdienst { get; set; }
        public ICollection<VmGefaehrdungsMeldung> VmGefaehrdungsMeldung { get; set; }
        public ICollection<VmInventar> VmInventar { get; set; }
        public ICollection<VmKlientenbudget> VmKlientenbudget { get; set; }
        public ICollection<VmMandBericht> VmMandBericht { get; set; }
        public ICollection<VmMassnahme> VmMassnahme { get; set; }
        public ICollection<VmSachversicherung> VmSachversicherung { get; set; }
        public ICollection<VmSchulden> VmSchulden { get; set; }
        public ICollection<VmSiegelung> VmSiegelung { get; set; }
        public ICollection<VmSituationsBericht> VmSituationsBericht { get; set; }
        public ICollection<VmSozialversicherung> VmSozialversicherung { get; set; }
        public ICollection<VmSteuern> VmSteuern { get; set; }
        public ICollection<VmTestament> VmTestament { get; set; }
        public ICollection<VmVaterschaft> VmVaterschaft { get; set; }
        public ICollection<WhAsvseintrag> WhAsvseintrag { get; set; }
        public ICollection<Xtask> Xtask { get; set; }
        public int Id => FaLeistungId;
        public byte[] RowVersion => FaLeistungTs;
    }
}