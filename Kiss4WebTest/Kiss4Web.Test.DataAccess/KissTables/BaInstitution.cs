namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaInstitution")]
    public partial class BaInstitution
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaInstitution()
        {
            BaAdresses = new HashSet<BaAdresse>();
            BaAdresses1 = new HashSet<BaAdresse>();
            BaArbeits = new HashSet<BaArbeit>();
            BaArbeitAusbildungs = new HashSet<BaArbeitAusbildung>();
            BaGesundheits = new HashSet<BaGesundheit>();
            BaGesundheits1 = new HashSet<BaGesundheit>();
            BaGesundheits2 = new HashSet<BaGesundheit>();
            BaInstitution_BaInstitutionTyp = new HashSet<BaInstitution_BaInstitutionTyp>();
            BaInstitutionDokuments = new HashSet<BaInstitutionDokument>();
            BaInstitutionDokuments1 = new HashSet<BaInstitutionDokument>();
            BaInstitutionKontakts = new HashSet<BaInstitutionKontakt>();
            BaMietvertrags = new HashSet<BaMietvertrag>();
            BaPersons = new HashSet<BaPerson>();
            BaPerson_BaInstitution = new HashSet<BaPersonBaInstitution>();
            BaZahlungswegs = new HashSet<BaZahlungsweg>();
            BgPositions = new HashSet<BgPosition>();
            BgSpezkontoes = new HashSet<BgSpezkonto>();
            FaDokumentAblages = new HashSet<FaDokumentAblage>();
            FaDokumentes = new HashSet<FaDokumente>();
            GvDocuments = new HashSet<GvDocument>();
            KbBuchungs = new HashSet<KbBuchung>();
            KbZahlungseingangs = new HashSet<KbZahlungseingang>();
            KesDokuments = new HashSet<KesDokument>();
            KesMandatsfuehrendePersons = new HashSet<KesMandatsfuehrendePerson>();
            KesMassnahmeBSSes = new HashSet<KesMassnahmeBSS>();
            KesMassnahmeBSSes1 = new HashSet<KesMassnahmeBSS>();
            KesPflegekinderaufsichts = new HashSet<KesPflegekinderaufsicht>();
            KesVerlaufs = new HashSet<KesVerlauf>();
            VmErbschaftsdiensts = new HashSet<VmErbschaftsdienst>();
            VmSachversicherungs = new HashSet<VmSachversicherung>();
            VmSiegelungs = new HashSet<VmSiegelung>();
            VmSozialversicherungs = new HashSet<VmSozialversicherung>();
            VmTestaments = new HashSet<VmTestament>();
        }

        public int BaInstitutionID { get; set; }

        public int? OrgUnitID { get; set; }

        [StringLength(20)]
        public string InstitutionNr { get; set; }

        public int? BaInstitutionArtCode { get; set; }

        public bool Aktiv { get; set; }

        public bool Debitor { get; set; }

        public bool Kreditor { get; set; }

        public bool KeinSerienbrief { get; set; }

        public bool ManuelleAnrede { get; set; }

        [StringLength(100)]
        public string Anrede { get; set; }

        [StringLength(100)]
        public string Briefanrede { get; set; }

        [StringLength(100)]
        public string Titel { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Vorname { get; set; }

        public int? GeschlechtCode { get; set; }

        public DateTime? Geburtsdatum { get; set; }

        [StringLength(18)]
        public string Versichertennummer { get; set; }

        [StringLength(100)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Telefon2 { get; set; }

        [StringLength(100)]
        public string Telefon3 { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(100)]
        public string Homepage { get; set; }

        public int? SprachCode { get; set; }

        public string Bemerkung { get; set; }

        [StringLength(100)]
        public string InstitutionName { get; set; }

        public int? InstitutionTypCode { get; set; }

        public int? BaFreigabeStatusCode { get; set; }

        public int? DefinitivUserID { get; set; }

        public DateTime? DefinitivDatum { get; set; }

        public int? ErstelltUserID { get; set; }

        public DateTime? ErstelltDatum { get; set; }

        public int? MutiertUserID { get; set; }

        public DateTime? MutiertDatum { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaInstitutionTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaAdresse> BaAdresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaAdresse> BaAdresses1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaArbeit> BaArbeits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaArbeitAusbildung> BaArbeitAusbildungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaGesundheit> BaGesundheits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaGesundheit> BaGesundheits1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaGesundheit> BaGesundheits2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaInstitution_BaInstitutionTyp> BaInstitution_BaInstitutionTyp { get; set; }

        public virtual XOrgUnit XOrgUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaInstitutionDokument> BaInstitutionDokuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaInstitutionDokument> BaInstitutionDokuments1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaInstitutionKontakt> BaInstitutionKontakts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaMietvertrag> BaMietvertrags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson> BaPersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPersonBaInstitution> BaPerson_BaInstitution { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaZahlungsweg> BaZahlungswegs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgPosition> BgPositions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgSpezkonto> BgSpezkontoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumentAblage> FaDokumentAblages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumente> FaDokumentes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvDocument> GvDocuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbZahlungseingang> KbZahlungseingangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesDokument> KesDokuments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMandatsfuehrendePerson> KesMandatsfuehrendePersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahmeBSS> KesMassnahmeBSSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahmeBSS> KesMassnahmeBSSes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesPflegekinderaufsicht> KesPflegekinderaufsichts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesVerlauf> KesVerlaufs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmErbschaftsdienst> VmErbschaftsdiensts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSachversicherung> VmSachversicherungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSiegelung> VmSiegelungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSozialversicherung> VmSozialversicherungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmTestament> VmTestaments { get; set; }
    }
}
