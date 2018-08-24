namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XUser")]
    public partial class XUser : IEntity, IAuditableEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XUser()
        {
            BaAdresses = new HashSet<BaAdresse>();
            BaInstitutionDokuments = new HashSet<BaInstitutionDokument>();
            BDEAusbezahlteUeberstunden_XUser = new HashSet<BDEAusbezahlteUeberstunden_XUser>();
            BDEFerienanspruch_XUser = new HashSet<BDEFerienanspruch_XUser>();
            BDEFerienkuerzungen_XUser = new HashSet<BDEFerienkuerzungen_XUser>();
            BDELeistungs = new HashSet<BDELeistung>();
            BDEPensum_XUser = new HashSet<BDEPensum_XUser>();
            BDESollProTag_XUser = new HashSet<BDESollProTag_XUser>();
            BDESollStundenProJahr_XUser = new HashSet<BDESollStundenProJahr_XUser>();
            BDEZeitrechners = new HashSet<BDEZeitrechner>();
            BFSDossiers = new HashSet<BFSDossier>();
            BgBewilligungs = new HashSet<BgBewilligung>();
            BgBewilligungs1 = new HashSet<BgBewilligung>();
            BgBewilligungs2 = new HashSet<BgBewilligung>();
            BgPositions = new HashSet<BgPosition>();
            BgPositions1 = new HashSet<BgPosition>();
            FaAktennotizens = new HashSet<FaAktennotizen>();
            FaDokumentAblages = new HashSet<FaDokumentAblage>();
            FaDokumentes = new HashSet<FaDokumente>();
            FaDokumentes1 = new HashSet<FaDokumente>();
            FaDokumentes2 = new HashSet<FaDokumente>();
            FaDokumentes3 = new HashSet<FaDokumente>();
            FaDokumentes4 = new HashSet<FaDokumente>();
            FaKategorisierungs = new HashSet<FaKategorisierung>();
            FaLeistungs = new HashSet<FaLeistung>();
            FaLeistungs1 = new HashSet<FaLeistung>();
            FaLeistungArchivs = new HashSet<FaLeistungArchiv>();
            FaLeistungArchivs1 = new HashSet<FaLeistungArchiv>();
            FaLeistungBewertungs = new HashSet<FaLeistungBewertung>();
            FaLeistungUserHists = new HashSet<FaLeistungUserHist>();
            FaLeistungZugriffs = new HashSet<FaLeistungZugriff>();
            FaPendenzgruppe_User = new HashSet<FaPendenzgruppe_User>();
            FaPhases = new HashSet<FaPhase>();
            FaWeisungs = new HashSet<FaWeisung>();
            FaWeisungs1 = new HashSet<FaWeisung>();
            FaWeisungs2 = new HashSet<FaWeisung>();
            FbBarauszahlungAuftrags = new HashSet<FbBarauszahlungAuftrag>();
            FbBarauszahlungAuftrags1 = new HashSet<FbBarauszahlungAuftrag>();
            FbBarauszahlungAusbezahlts = new HashSet<FbBarauszahlungAusbezahlt>();
            FbBelegNrs = new HashSet<FbBelegNr>();
            FbBuchungs = new HashSet<FbBuchung>();
            FbBuchungCodes = new HashSet<FbBuchungCode>();
            FbDTAJournals = new HashSet<FbDTAJournal>();
            FbTeamMitglieds = new HashSet<FbTeamMitglied>();
            FsReduktionMitarbeiters = new HashSet<FsReduktionMitarbeiter>();
            GvBewilligungs = new HashSet<GvBewilligung>();
            GvDocuments = new HashSet<GvDocument>();
            GvGesuches = new HashSet<GvGesuch>();
            GvGesuches1 = new HashSet<GvGesuch>();
            GvGesuches2 = new HashSet<GvGesuch>();
            IkAbklaerungs = new HashSet<IkAbklaerung>();
            KaBetriebBesprechungs = new HashSet<KaBetriebBesprechung>();
            KaVerlaufs = new HashSet<KaVerlauf>();
            KbBuchungs = new HashSet<KbBuchung>();
            KbBuchungs1 = new HashSet<KbBuchung>();
            KbBuchungs2 = new HashSet<KbBuchung>();
            KbPeriode_User = new HashSet<KbPeriode_User>();
            KbWVLaufs = new HashSet<KbWVLauf>();
            KbZahlungseingangs = new HashSet<KbZahlungseingang>();
            KbZahlungseingangs1 = new HashSet<KbZahlungseingang>();
            KbZahlungseingangs2 = new HashSet<KbZahlungseingang>();
            KbZahlungslaufs = new HashSet<KbZahlungslauf>();
            KesAuftrags = new HashSet<KesAuftrag>();
            KesDokuments = new HashSet<KesDokument>();
            KesMandatsfuehrendePersons = new HashSet<KesMandatsfuehrendePerson>();
            KesMassnahmeBSSes = new HashSet<KesMassnahmeBSS>();
            KesPflegekinderaufsichts = new HashSet<KesPflegekinderaufsicht>();
            KesPraeventions = new HashSet<KesPraevention>();
            KesVerlaufs = new HashSet<KesVerlauf>();
            VmAntragEKSKs = new HashSet<VmAntragEKSK>();
            VmBewertungs = new HashSet<VmBewertung>();
            VmBudgets = new HashSet<VmBudget>();
            VmErbschaftsdiensts = new HashSet<VmErbschaftsdienst>();
            VmErnennungs = new HashSet<VmErnennung>();
            VmInventars = new HashSet<VmInventar>();
            VmKlientenbudgets = new HashSet<VmKlientenbudget>();
            VmMandants = new HashSet<VmMandant>();
            VmMandBerichts = new HashSet<VmMandBericht>();
            VmSiegelungs = new HashSet<VmSiegelung>();
            VmSituationsBerichts = new HashSet<VmSituationsBericht>();
            VmTestaments = new HashSet<VmTestament>();
            XDocTemplates = new HashSet<XDocTemplate>();
            XOrgUnits = new HashSet<XOrgUnit>();
            XOrgUnits1 = new HashSet<XOrgUnit>();
            XOrgUnits2 = new HashSet<XOrgUnit>();
            XOrgUnit_User = new HashSet<XOrgUnit_User>();
            XSearchControlTemplates = new HashSet<XSearchControlTemplate>();
            XTasks = new HashSet<XTask>();
            XTasks1 = new HashSet<XTask>();
            XUser_Archive = new HashSet<XUser_Archive>();
            XUser_BDEUserGroup = new HashSet<XUser_BDEUserGroup>();
            XUser_UserGroup = new HashSet<XUser_UserGroup>();
            XUser_XDocTemplate = new HashSet<XUser_XDocTemplate>();
            XUser1 = new HashSet<XUser>();
            XUser11 = new HashSet<XUser>();
            XUser12 = new HashSet<XUser>();
            XUserStundenansatzs = new HashSet<XUserStundenansatz>();
        }

        [Key]
        public int UserID { get; set; }

        public int? ChiefID { get; set; }

        public int? PrimaryUserID { get; set; }

        public int? PermissionGroupID { get; set; }

        public int? GrantPermGroupID { get; set; }

        public int? XProfileID { get; set; }

        public int? ModulID { get; set; }

        public int? SachbearbeiterID { get; set; }

        [StringLength(50)]
        public string MitarbeiterNr { get; set; }

        [Required]
        [StringLength(200)]
        public string LogonName { get; set; }

        [StringLength(200)]
        public string PasswordHash { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string ShortName { get; set; }

        public bool IsLocked { get; set; }

        public bool IsUserAdmin { get; set; }

        public bool IsUserBIAGAdmin { get; set; }

        public bool IsMandatsTraeger { get; set; }

        public int? GenderCode { get; set; }

        public DateTime? Geburtstag { get; set; }

        public int? LanguageCode { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string PhoneMobile { get; set; }

        [StringLength(100)]
        public string PhoneOffice { get; set; }

        [StringLength(100)]
        public string PhoneIntern { get; set; }

        [StringLength(100)]
        public string PhonePrivat { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        public int? UserProfileCode { get; set; }

        [StringLength(100)]
        public string Funktion { get; set; }

        public int? RoleTitleCode { get; set; }

        public int? QualificationTitleCode { get; set; }

        [StringLength(1000)]
        public string Bemerkungen { get; set; }

        [StringLength(2000)]
        public string Text1 { get; set; }

        [StringLength(2000)]
        public string Text2 { get; set; }

        public double? JobPercentage { get; set; }

        public int? HoursPerYearForCaseMgmt { get; set; }

        public DateTime? Eintrittsdatum { get; set; }

        public DateTime? Austrittsdatum { get; set; }

        public int? LohntypCode { get; set; }

        public int? Kostentraeger { get; set; }

        [StringLength(500)]
        public string WeitereKostentraeger { get; set; }

        public int? Kostenart { get; set; }

        public bool KeinBDEExport { get; set; }

        [StringLength(50)]
        public string MigHerkunft { get; set; }

        [StringLength(50)]
        public string MigMAKuerzel { get; set; }

        public bool MigUserFix { get; set; }

        [StringLength(255)]
        public string visdat36Area { get; set; }

        [StringLength(255)]
        public string visdat36SourceFile { get; set; }

        [StringLength(50)]
        public string visdat36ID { get; set; }

        [StringLength(255)]
        public string visdat36Name { get; set; }

        public int? VerID { get; set; }

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
        public byte[] XUserTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaAdresse> BaAdresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaInstitutionDokument> BaInstitutionDokuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDEAusbezahlteUeberstunden_XUser> BDEAusbezahlteUeberstunden_XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDEFerienanspruch_XUser> BDEFerienanspruch_XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDEFerienkuerzungen_XUser> BDEFerienkuerzungen_XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDELeistung> BDELeistungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDEPensum_XUser> BDEPensum_XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDESollProTag_XUser> BDESollProTag_XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDESollStundenProJahr_XUser> BDESollStundenProJahr_XUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BDEZeitrechner> BDEZeitrechners { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BFSDossier> BFSDossiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgBewilligung> BgBewilligungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgBewilligung> BgBewilligungs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgBewilligung> BgBewilligungs2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPosition> BgPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPosition> BgPositions1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaAktennotizen> FaAktennotizens { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumentAblage> FaDokumentAblages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumente> FaDokumentes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumente> FaDokumentes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumente> FaDokumentes2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumente> FaDokumentes3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumente> FaDokumentes4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaKategorisierung> FaKategorisierungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistung> FaLeistungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistung> FaLeistungs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistungArchiv> FaLeistungArchivs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistungArchiv> FaLeistungArchivs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistungBewertung> FaLeistungBewertungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistungUserHist> FaLeistungUserHists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaLeistungZugriff> FaLeistungZugriffs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaPendenzgruppe_User> FaPendenzgruppe_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaPhase> FaPhases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaWeisung> FaWeisungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaWeisung> FaWeisungs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaWeisung> FaWeisungs2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBarauszahlungAuftrag> FbBarauszahlungAuftrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBarauszahlungAuftrag> FbBarauszahlungAuftrags1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBarauszahlungAusbezahlt> FbBarauszahlungAusbezahlts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBelegNr> FbBelegNrs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBuchung> FbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbBuchungCode> FbBuchungCodes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbDTAJournal> FbDTAJournals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbTeamMitglied> FbTeamMitglieds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FsReduktionMitarbeiter> FsReduktionMitarbeiters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvBewilligung> GvBewilligungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvDocument> GvDocuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvGesuch> GvGesuches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvGesuch> GvGesuches1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvGesuch> GvGesuches2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IkAbklaerung> IkAbklaerungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaBetriebBesprechung> KaBetriebBesprechungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KaVerlauf> KaVerlaufs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbPeriode_User> KbPeriode_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbWVLauf> KbWVLaufs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbZahlungseingang> KbZahlungseingangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbZahlungseingang> KbZahlungseingangs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbZahlungseingang> KbZahlungseingangs2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbZahlungslauf> KbZahlungslaufs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesAuftrag> KesAuftrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesDokument> KesDokuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMandatsfuehrendePerson> KesMandatsfuehrendePersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahmeBSS> KesMassnahmeBSSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesPflegekinderaufsicht> KesPflegekinderaufsichts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesPraevention> KesPraeventions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesVerlauf> KesVerlaufs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmAntragEKSK> VmAntragEKSKs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmBewertung> VmBewertungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmBudget> VmBudgets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmErbschaftsdienst> VmErbschaftsdiensts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmErnennung> VmErnennungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmInventar> VmInventars { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmKlientenbudget> VmKlientenbudgets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmMandant> VmMandants { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmMandBericht> VmMandBerichts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSiegelung> VmSiegelungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSituationsBericht> VmSituationsBerichts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmTestament> VmTestaments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XDocTemplate> XDocTemplates { get; set; }

        public virtual XModul XModul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XOrgUnit> XOrgUnits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XOrgUnit> XOrgUnits1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XOrgUnit> XOrgUnits2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XOrgUnit_User> XOrgUnit_User { get; set; }

        public virtual XPermissionGroup XPermissionGroup { get; set; }

        public virtual XPermissionGroup XPermissionGroup1 { get; set; }

        public virtual XProfile XProfile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XSearchControlTemplate> XSearchControlTemplates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XTask> XTasks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XTask> XTasks1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUser_Archive> XUser_Archive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUser_BDEUserGroup> XUser_BDEUserGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUser_UserGroup> XUser_UserGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUser_XDocTemplate> XUser_XDocTemplate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUser> XUser1 { get; set; }

        public virtual XUser XUser2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUser> XUser11 { get; set; }

        public virtual XUser XUser3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUser> XUser12 { get; set; }

        public virtual XUser XUser4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XUserStundenansatz> XUserStundenansatzs { get; set; }

        public int Id => UserID;

        public byte[] RowVersion => XUserTS;
    }
}
