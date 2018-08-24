namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmBericht")]
    public partial class VmBericht
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VmBericht()
        {
            VmMandBerichts = new HashSet<VmMandBericht>();
        }

        public int VmBerichtID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? BerichtsperiodeVon { get; set; }

        public DateTime? BerichtsperiodeBis { get; set; }

        public DateTime? Erstellung { get; set; }

        public DateTime? Mahnung { get; set; }

        public DateTime? Mahnung2 { get; set; }

        public DateTime? Passation1 { get; set; }

        public DateTime? Passation2 { get; set; }

        public DateTime? Versand { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmBerichtTS { get; set; }

        [Column(TypeName = "money")]
        public decimal? Entschaedigung { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VmMandBericht> VmMandBerichts { get; set; }
    }
}
