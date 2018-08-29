namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaLand")]
    public partial class BaLand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaLand()
        {
            BaAdresses = new HashSet<BaAdresse>();
            BaBanks = new HashSet<BaBank>();
            BaPersons = new HashSet<BaPerson>();
            BaPersons1 = new HashSet<BaPerson>();
            BaPersons2 = new HashSet<BaPerson>();
            BaPersons3 = new HashSet<BaPerson>();
            BaPersons4 = new HashSet<BaPerson>();
            BaZahlungswegs = new HashSet<BaZahlungsweg>();
            FbKreditors = new HashSet<FbKreditor>();
            KbBuchungs = new HashSet<KbBuchung>();
        }

        public int BaLandID { get; set; }

        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        [Required]
        [StringLength(200)]
        public string TextFR { get; set; }

        [Required]
        [StringLength(200)]
        public string TextIT { get; set; }

        [Required]
        [StringLength(200)]
        public string TextEN { get; set; }

        [StringLength(2)]
        public string Iso2Code { get; set; }

        [StringLength(3)]
        public string Iso3Code { get; set; }

        public int? BFSCode { get; set; }

        public int? SortKey { get; set; }

        [StringLength(20)]
        public string SAPCode { get; set; }

        public DateTime DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public bool BFSDelivered { get; set; }

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
        public byte[] BaLandTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaAdresse> BaAdresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaBank> BaBanks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson> BaPersons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson> BaPersons1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson> BaPersons2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson> BaPersons3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaPerson> BaPersons4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaZahlungsweg> BaZahlungswegs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FbKreditor> FbKreditors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }
    }
}
