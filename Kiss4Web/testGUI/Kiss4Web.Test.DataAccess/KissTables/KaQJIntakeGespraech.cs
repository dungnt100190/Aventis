namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQJIntakeGespraech")]
    public partial class KaQJIntakeGespraech
    {
        public int KaQJIntakeGespraechID { get; set; }

        public int KaQJIntakeID { get; set; }

        public DateTime? Datum { get; set; }

        public int? KaQjIntakePraesenzCode { get; set; }

        public int? KaQjIntakeEntscheidCode { get; set; }

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
        public byte[] KaQJIntakeGespraechTS { get; set; }

        public virtual KaQJIntake KaQJIntake { get; set; }
    }
}
