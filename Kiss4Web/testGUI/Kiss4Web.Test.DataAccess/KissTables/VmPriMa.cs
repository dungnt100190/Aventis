namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmPriMa")]
    public partial class VmPriMa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VmPriMa()
        {
            BaAdresses = new HashSet<BaAdresse>();
            FaDokumentes = new HashSet<FaDokumente>();
            KesMassnahmeBSSes = new HashSet<KesMassnahmeBSS>();
            VmErnennungs = new HashSet<VmErnennung>();
            VmSachversicherungs = new HashSet<VmSachversicherung>();
            VmSozialversicherungs = new HashSet<VmSozialversicherung>();
        }

        public int VmPriMaID { get; set; }

        [StringLength(50)]
        public string Titel { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Vorname { get; set; }

        [StringLength(100)]
        public string Telefon_P { get; set; }

        [StringLength(100)]
        public string Telefon_G { get; set; }

        [StringLength(100)]
        public string MobilTel { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string EMail { get; set; }

        [StringLength(100)]
        public string Beruf { get; set; }

        public int? SprachCode { get; set; }

        [StringLength(70)]
        public string BankName { get; set; }

        [StringLength(50)]
        public string BankKontoNr { get; set; }

        public string Bemerkung { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmPriMaTS { get; set; }

        public int? VerID { get; set; }

        [StringLength(16)]
        public string AHVNummer { get; set; }

        [StringLength(18)]
        public string Versichertennummer { get; set; }

        public DateTime? Geburtsdatum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaAdresse> BaAdresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FaDokumente> FaDokumentes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KesMassnahmeBSS> KesMassnahmeBSSes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmErnennung> VmErnennungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSachversicherung> VmSachversicherungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmSozialversicherung> VmSozialversicherungs { get; set; }
    }
}
