namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmPosition")]
    public partial class VmPosition
    {
        public int VmPositionID { get; set; }

        public int VmKlientenbudgetID { get; set; }

        public int VmPositionsartID { get; set; }

        public bool IstImportiert { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Bemerkung { get; set; }

        public DateTime? DatumSaldoPer { get; set; }

        [Column(TypeName = "money")]
        public decimal? Saldo { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragMonatlich { get; set; }

        [Column(TypeName = "money")]
        public decimal? BetragJaehrlich { get; set; }

        public int SortKey { get; set; }

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
        public byte[] VmPositionTS { get; set; }

        public virtual VmKlientenbudget VmKlientenbudget { get; set; }

        public virtual VmPositionsart VmPositionsart { get; set; }
    }
}
