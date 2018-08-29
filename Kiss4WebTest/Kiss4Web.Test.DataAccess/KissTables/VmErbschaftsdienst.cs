namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmErbschaftsdienst")]
    public partial class VmErbschaftsdienst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VmErbschaftsdienst()
        {
            VmErbes = new HashSet<VmErbe>();
        }

        public int VmErbschaftsdienstID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public int? LaufNr { get; set; }

        public int? Jahr { get; set; }

        [StringLength(200)]
        public string MassnahmenCodes { get; set; }

        public int? AnschriftErbenDokID { get; set; }

        public DateTime? AnschriftErbenDatum { get; set; }

        public int? InventarCode { get; set; }

        public int? InventarNotarID { get; set; }

        public bool? Aktiv { get; set; }

        public bool? VertretungsBeistandschaft { get; set; }

        public bool? Ausschlagung { get; set; }

        public bool? El { get; set; }

        [StringLength(20)]
        public string KopieAnCodes { get; set; }

        public int? UeberweisungRSTADokID { get; set; }

        public DateTime? UeberweisungRSTA { get; set; }

        public string Massnahme { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmErbschaftsdienstTS { get; set; }

        public virtual BaInstitution BaInstitution { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmErbe> VmErbes { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
