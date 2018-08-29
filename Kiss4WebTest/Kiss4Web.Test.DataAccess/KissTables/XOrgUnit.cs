namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XOrgUnit")]
    public partial class XOrgUnit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XOrgUnit()
        {
            BaInstitutions = new HashSet<BaInstitution>();
            BaInstitutionTyps = new HashSet<BaInstitutionTyp>();
            BgBewilligungs = new HashSet<BgBewilligung>();
            FaKategorisierungEksProdukts = new HashSet<FaKategorisierungEksProdukt>();
            GvFonds_XOrgUnit = new HashSet<GvFonds_XOrgUnit>();
            KbZahlungskonto_XOrgUnit = new HashSet<KbZahlungskonto_XOrgUnit>();
            XOrgUnit_User = new HashSet<XOrgUnit_User>();
            XOrgUnit_XDocTemplate = new HashSet<XOrgUnit_XDocTemplate>();
            XOrgUnit1 = new HashSet<XOrgUnit>();
        }

        [Key]
        public int OrgUnitID { get; set; }

        public int? ParentID { get; set; }

        public int? ModulID { get; set; }

        public int? ChiefID { get; set; }

        public int? RechtsdienstUserID { get; set; }

        public int? RepresentativeID { get; set; }

        public int? StellvertreterID { get; set; }

        public int? XProfileID { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        public int? OEItemTypCode { get; set; }

        public int? ParentPosition { get; set; }

        public int? Kostenstelle { get; set; }

        public int? Mandantennummer { get; set; }

        public int? StundenLohnlaufNr { get; set; }

        public int? LeistungLohnlaufNr { get; set; }

        public int? Sammelkonto { get; set; }

        [StringLength(100)]
        public string PCKonto { get; set; }

        [StringLength(2000)]
        public string AD_Abteilung { get; set; }

        public string Logo { get; set; }

        [StringLength(2000)]
        public string Adressat { get; set; }

        [StringLength(2000)]
        public string Adresse { get; set; }

        [StringLength(100)]
        public string AdresseKGS { get; set; }

        [StringLength(100)]
        public string AdresseAbteilung { get; set; }

        [StringLength(100)]
        public string AdresseStrasse { get; set; }

        [StringLength(100)]
        public string Postfach { get; set; }

        public bool PostfachOhneNr { get; set; }

        [StringLength(10)]
        public string AdresseHausNr { get; set; }

        [StringLength(10)]
        public string AdressePLZ { get; set; }

        [StringLength(50)]
        public string AdresseOrt { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(100)]
        public string WWW { get; set; }

        [StringLength(100)]
        public string Internet { get; set; }

        public int? UserProfileCode { get; set; }

        [StringLength(2000)]
        public string Text1 { get; set; }

        [StringLength(2000)]
        public string Text2 { get; set; }

        [StringLength(2000)]
        public string Text3 { get; set; }

        [StringLength(2000)]
        public string Text4 { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        public int? VerID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] XOrgUnitTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaInstitution> BaInstitutions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaInstitutionTyp> BaInstitutionTyps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BgBewilligung> BgBewilligungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaKategorisierungEksProdukt> FaKategorisierungEksProdukts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GvFonds_XOrgUnit> GvFonds_XOrgUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbZahlungskonto_XOrgUnit> KbZahlungskonto_XOrgUnit { get; set; }

        public virtual XModul XModul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XOrgUnit_User> XOrgUnit_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XOrgUnit_XDocTemplate> XOrgUnit_XDocTemplate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XOrgUnit> XOrgUnit1 { get; set; }

        public virtual XOrgUnit XOrgUnit2 { get; set; }

        public virtual XProfile XProfile { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XUser XUser1 { get; set; }

        public virtual XUser XUser2 { get; set; }
    }
}
