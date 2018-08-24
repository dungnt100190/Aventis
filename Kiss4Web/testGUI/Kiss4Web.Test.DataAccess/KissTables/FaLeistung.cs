namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FaLeistung")]
    public partial class FaLeistung : IEntity, IAuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FaLeistung()
        {
            BFSDossiers = new HashSet<BFSDossier>();
            BgFinanzplans = new HashSet<BgFinanzplan>();
            BgSpezkontoes = new HashSet<BgSpezkonto>();
            BgZahlungsmodus = new HashSet<BgZahlungsmodu>();
            DynaValues = new HashSet<DynaValue>();
            FaAktennotizens = new HashSet<FaAktennotizen>();
            FaDokumentAblages = new HashSet<FaDokumentAblage>();
            FaDokumentes = new HashSet<FaDokumente>();
            FaLeistungArchivs = new HashSet<FaLeistungArchiv>();
            FaLeistungBewertungs = new HashSet<FaLeistungBewertung>();
            FaLeistungUserHists = new HashSet<FaLeistungUserHist>();
            FaLeistungZugriffs = new HashSet<FaLeistungZugriff>();
            FaPhases = new HashSet<FaPhase>();
            FaRelations = new HashSet<FaRelation>();
            FaRelations1 = new HashSet<FaRelation>();
            FaWeisungs = new HashSet<FaWeisung>();
            FaZeitlichePlanungs = new HashSet<FaZeitlichePlanung>();
            FbBarauszahlungAuftrags = new HashSet<FbBarauszahlungAuftrag>();
            IkAbklaerungs = new HashSet<IkAbklaerung>();
            IkAnzeiges = new HashSet<IkAnzeige>();
            IkBetreibungs = new HashSet<IkBetreibung>();
            IkForderungs = new HashSet<IkForderung>();
            IkGlaeubigers = new HashSet<IkGlaeubiger>();
            IkPositions = new HashSet<IkPosition>();
            IkRatenplans = new HashSet<IkRatenplan>();
            IkRechtstitels = new HashSet<IkRechtstitel>();
            KaAbklaerungIntakes = new HashSet<KaAbklaerungIntake>();
            KaAbklaerungVertiefts = new HashSet<KaAbklaerungVertieft>();
            KaAKZuweisers = new HashSet<KaAKZuweiser>();
            KaAllgemeins = new HashSet<KaAllgemein>();
            KaAssistenzs = new HashSet<KaAssistenz>();
            KaAusbildungs = new HashSet<KaAusbildung>();
            KaEafSozioberuflicheBilanzs = new HashSet<KaEafSozioberuflicheBilanz>();
            KaEafSpezifischeErmittlungs = new HashSet<KaEafSpezifischeErmittlung>();
            KaEinsatzs = new HashSet<KaEinsatz>();
            KaExterneBildungs = new HashSet<KaExterneBildung>();
            KaInizios = new HashSet<KaInizio>();
            KaIntegBildungs = new HashSet<KaIntegBildung>();
            KaJobtimals = new HashSet<KaJobtimal>();
            KaKontaktartProzesses = new HashSet<KaKontaktartProzess>();
            KaQEEPQs = new HashSet<KaQEEPQ>();
            KaQEEPQZielvereinbs = new HashSet<KaQEEPQZielvereinb>();
            KaQEEPQZielvereinbVerls = new HashSet<KaQEEPQZielvereinbVerl>();
            KaQEJobtimums = new HashSet<KaQEJobtimum>();
            KaQJBildungs = new HashSet<KaQJBildung>();
            KaQJIntakes = new HashSet<KaQJIntake>();
            KaQJProzesses = new HashSet<KaQJProzess>();
            KaQJPZAssessments = new HashSet<KaQJPZAssessment>();
            KaQJPZBerichts = new HashSet<KaQJPZBericht>();
            KaQJPZSchlussberichts = new HashSet<KaQJPZSchlussbericht>();
            KaQJPZZielvereinbarungs = new HashSet<KaQJPZZielvereinbarung>();
            KaQJVereinbarungs = new HashSet<KaQJVereinbarung>();
            KaTransfers = new HashSet<KaTransfer>();
            KaTransferZielvereinbs = new HashSet<KaTransferZielvereinb>();
            KaVerlaufs = new HashSet<KaVerlauf>();
            KaVermittlungBIBIPs = new HashSet<KaVermittlungBIBIP>();
            KaVermittlungProfils = new HashSet<KaVermittlungProfil>();
            KaVermittlungSIs = new HashSet<KaVermittlungSI>();
            KaVermittlungVorschlags = new HashSet<KaVermittlungVorschlag>();
            KbBuchungs = new HashSet<KbBuchung>();
            KesAuftrags = new HashSet<KesAuftrag>();
            KesDokuments = new HashSet<KesDokument>();
            KesMassnahmes = new HashSet<KesMassnahme>();
            KesMassnahmeBSSes = new HashSet<KesMassnahmeBSS>();
            KesPflegekinderaufsichts = new HashSet<KesPflegekinderaufsicht>();
            KesPraeventions = new HashSet<KesPraevention>();
            KesVerlaufs = new HashSet<KesVerlauf>();
            VmAHVMindestbeitrags = new HashSet<VmAHVMindestbeitrag>();
            VmAntragEKSKs = new HashSet<VmAntragEKSK>();
            VmBerichts = new HashSet<VmBericht>();
            VmBeschwerdeAnfrages = new HashSet<VmBeschwerdeAnfrage>();
            VmBewertungs = new HashSet<VmBewertung>();
            VmBudgets = new HashSet<VmBudget>();
            VmELKrankheitskostens = new HashSet<VmELKrankheitskosten>();
            VmErblassers = new HashSet<VmErblasser>();
            VmErbschaftsdiensts = new HashSet<VmErbschaftsdienst>();
            VmGefaehrdungsMeldungs = new HashSet<VmGefaehrdungsMeldung>();
            VmInventars = new HashSet<VmInventar>();
            VmKlientenbudgets = new HashSet<VmKlientenbudget>();
            VmMandBerichts = new HashSet<VmMandBericht>();
            VmMassnahmes = new HashSet<VmMassnahme>();
            VmSachversicherungs = new HashSet<VmSachversicherung>();
            VmSchuldens = new HashSet<VmSchulden>();
            VmSiegelungs = new HashSet<VmSiegelung>();
            VmSituationsBerichts = new HashSet<VmSituationsBericht>();
            VmSozialversicherungs = new HashSet<VmSozialversicherung>();
            VmSteuerns = new HashSet<VmSteuern>();
            VmTestaments = new HashSet<VmTestament>();
            VmVaterschafts = new HashSet<VmVaterschaft>();
            WhASVSEintrags = new HashSet<WhASVSEintrag>();
            XTasks = new HashSet<XTask>();
        }

        public int FaLeistungID { get; set; }

        public int BaPersonID { get; set; }

        public int FaFallID { get; set; }

        public int ModulID { get; set; }

        public int UserID { get; set; }

        public int? SachbearbeiterID { get; set; }

        public int? SchuldnerBaPersonID { get; set; }

        public int? FaProzessCode { get; set; }

        public int? GemeindeCode { get; set; }

        public int? LeistungsartCode { get; set; }

        public int? EroeffnungsGrundCode { get; set; }

        public int? AbschlussGrundCode { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public string Bemerkung { get; set; }

        [StringLength(20)]
        public string Dossiernummer { get; set; }

        public int? FaAufnahmeartCode { get; set; }

        public int? FaKontaktveranlasserCode { get; set; }

        [StringLength(255)]
        public string FaTeilleistungserbringerCodes { get; set; }

        public int? FaModulDienstleistungenCode { get; set; }

        public int? IkSchuldnerStatusCode { get; set; }

        public int? IkAufenthaltsartCode { get; set; }

        public bool IkHatUnterstuetzung { get; set; }

        public bool IkIstRentenbezueger { get; set; }

        public bool IkSchuldnerMahnen { get; set; }

        public int? IkEinnahmenQuoteCode { get; set; }

        public DateTime? IkDatumRechtskraft { get; set; }

        public int? IkInkassoBemuehungCode { get; set; }

        public DateTime? IkVerjaehrungAm { get; set; }

        public int? IkLeistungStatusCode { get; set; }

        public DateTime? IkDatumForderungstitel { get; set; }

        public int? IkRueckerstattungTypCode { get; set; }

        public int? IkForderungTitelCode { get; set; }

        public int? IkErreichungsGradCode { get; set; }

        public int? OldUnitID { get; set; }

        public int? VmAuftragCode { get; set; }

        public int? KaProzessCode { get; set; }

        public bool? KaEpqJob { get; set; }

        [StringLength(50)]
        public string Bezeichnung { get; set; }

        public int? MigrationKA { get; set; }

        public long? PscdVertragsgegenstandID { get; set; }

        [StringLength(200)]
        public string MigBemerkung { get; set; }

        public int? MigHerkunftCode { get; set; }

        public int? MigAlteFallNr { get; set; }

        public int? VUFaFallID { get; set; }

        [StringLength(255)]
        public string visdat36Area { get; set; }

        [StringLength(6)]
        public string visdat36FALLID { get; set; }

        [StringLength(6)]
        public string visdat36LEISTUNGID { get; set; }

        public bool WiederholteSpezifischeErmittlungEAF { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] FaLeistungTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BaPerson BaPerson1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BFSDossier> BFSDossiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgFinanzplan> BgFinanzplans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgSpezkonto> BgSpezkontoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgZahlungsmodu> BgZahlungsmodus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DynaValue> DynaValues { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaAktennotizen> FaAktennotizens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumentAblage> FaDokumentAblages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumente> FaDokumentes { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XModul XModul { get; set; }

        public virtual XUser XUser1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistungArchiv> FaLeistungArchivs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistungBewertung> FaLeistungBewertungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistungUserHist> FaLeistungUserHists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistungZugriff> FaLeistungZugriffs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaPhase> FaPhases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaRelation> FaRelations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaRelation> FaRelations1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaWeisung> FaWeisungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaZeitlichePlanung> FaZeitlichePlanungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBarauszahlungAuftrag> FbBarauszahlungAuftrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkAbklaerung> IkAbklaerungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkAnzeige> IkAnzeiges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkBetreibung> IkBetreibungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkForderung> IkForderungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkGlaeubiger> IkGlaeubigers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkPosition> IkPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkRatenplan> IkRatenplans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkRechtstitel> IkRechtstitels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaAbklaerungIntake> KaAbklaerungIntakes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaAbklaerungVertieft> KaAbklaerungVertiefts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaAKZuweiser> KaAKZuweisers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaAllgemein> KaAllgemeins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaAssistenz> KaAssistenzs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaAusbildung> KaAusbildungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaEafSozioberuflicheBilanz> KaEafSozioberuflicheBilanzs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaEafSpezifischeErmittlung> KaEafSpezifischeErmittlungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaEinsatz> KaEinsatzs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaExterneBildung> KaExterneBildungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaInizio> KaInizios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaIntegBildung> KaIntegBildungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaJobtimal> KaJobtimals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaKontaktartProzess> KaKontaktartProzesses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQEEPQ> KaQEEPQs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQEEPQZielvereinb> KaQEEPQZielvereinbs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQEEPQZielvereinbVerl> KaQEEPQZielvereinbVerls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQEJobtimum> KaQEJobtimums { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQJBildung> KaQJBildungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQJIntake> KaQJIntakes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQJProzess> KaQJProzesses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQJPZAssessment> KaQJPZAssessments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQJPZBericht> KaQJPZBerichts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQJPZSchlussbericht> KaQJPZSchlussberichts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQJPZZielvereinbarung> KaQJPZZielvereinbarungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaQJVereinbarung> KaQJVereinbarungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaTransfer> KaTransfers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaTransferZielvereinb> KaTransferZielvereinbs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaVerlauf> KaVerlaufs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaVermittlungBIBIP> KaVermittlungBIBIPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaVermittlungProfil> KaVermittlungProfils { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaVermittlungSI> KaVermittlungSIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaVermittlungVorschlag> KaVermittlungVorschlags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesAuftrag> KesAuftrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesDokument> KesDokuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahme> KesMassnahmes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahmeBSS> KesMassnahmeBSSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesPflegekinderaufsicht> KesPflegekinderaufsichts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesPraevention> KesPraeventions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesVerlauf> KesVerlaufs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmAHVMindestbeitrag> VmAHVMindestbeitrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmAntragEKSK> VmAntragEKSKs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmBericht> VmBerichts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmBeschwerdeAnfrage> VmBeschwerdeAnfrages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmBewertung> VmBewertungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmBudget> VmBudgets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmELKrankheitskosten> VmELKrankheitskostens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmErblasser> VmErblassers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmErbschaftsdienst> VmErbschaftsdiensts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmGefaehrdungsMeldung> VmGefaehrdungsMeldungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmInventar> VmInventars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmKlientenbudget> VmKlientenbudgets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmMandBericht> VmMandBerichts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmMassnahme> VmMassnahmes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSachversicherung> VmSachversicherungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSchulden> VmSchuldens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSiegelung> VmSiegelungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSituationsBericht> VmSituationsBerichts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSozialversicherung> VmSozialversicherungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSteuern> VmSteuerns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmTestament> VmTestaments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmVaterschaft> VmVaterschafts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WhASVSEintrag> WhASVSEintrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XTask> XTasks { get; set; }

        public int Id => FaLeistungID;

        public byte[] RowVersion => FaLeistungTS;
    }
}
