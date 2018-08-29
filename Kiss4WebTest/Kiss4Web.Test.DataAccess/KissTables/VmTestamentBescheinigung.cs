namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmTestamentBescheinigung")]
    public partial class VmTestamentBescheinigung
    {
        public int VmTestamentBescheinigungID { get; set; }

        public int VmTestamentID { get; set; }

        public DateTime Datum { get; set; }

        public int? BescheinigungCode { get; set; }

        [StringLength(150)]
        public string BescheinigungText { get; set; }

        public int? BescheinigungDokID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Gebuehr { get; set; }

        [StringLength(10)]
        public string SAPNr { get; set; }

        public string Bemerkung { get; set; }

        public bool IsDeleted { get; set; }

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
        public byte[] VmTestamentBescheinigungTS { get; set; }

        public virtual VmTestament VmTestament { get; set; }
    }
}
