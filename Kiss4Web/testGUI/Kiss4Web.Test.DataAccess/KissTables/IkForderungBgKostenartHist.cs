namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkForderungBgKostenartHist")]
    public partial class IkForderungBgKostenartHist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IkForderungBgKostenartHist()
        {
            KbBuchungs = new HashSet<KbBuchung>();
        }

        public int IkForderungBgKostenartHistID { get; set; }

        public int BgKostenartID { get; set; }

        public int? IkForderungPeriodischCode { get; set; }

        public bool IstAlbvBerechtigt { get; set; }

        public bool IstAlbvUeberMax { get; set; }

        public bool IstUnterstuetzungsfall { get; set; }

        public int? IkForderungEinmaligCode { get; set; }

        public int IkForderungsartFilterCode { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

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
        public byte[] IkForderungBgKostenartHistTS { get; set; }

        public virtual BgKostenart BgKostenart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KbBuchung> KbBuchungs { get; set; }
    }
}
