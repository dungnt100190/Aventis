namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hist_XOrgUnit
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerID { get; set; }

        public int? VerID_DELETED { get; set; }
    }
}
