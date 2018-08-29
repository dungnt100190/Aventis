namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmMandant")]
    public partial class VmMandant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VmMandant()
        {
            BaAdresses = new HashSet<BaAdresse>();
        }

        public int VmMandantID { get; set; }

        public int BaPersonID { get; set; }

        public int Version { get; set; }

        public DateTime Datum { get; set; }

        public int? UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Vorname { get; set; }

        public DateTime? Geburtsdatum { get; set; }

        public int? ZivilstandCode { get; set; }

        public int? HeimatgemeindeBaGemeindeID { get; set; }

        [StringLength(100)]
        public string Beruf { get; set; }

        [StringLength(200)]
        public string WertschriftenDepot { get; set; }

        [StringLength(16)]
        public string AHVNummer { get; set; }

        [StringLength(18)]
        public string Versichertennummer { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmMandantTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaAdresse> BaAdresses { get; set; }

        public virtual BaGemeinde BaGemeinde { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
