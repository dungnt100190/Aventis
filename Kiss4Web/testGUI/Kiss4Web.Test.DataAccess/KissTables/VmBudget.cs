namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmBudget")]
    public partial class VmBudget
    {
        public int VmBudgetID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public int? DocumentID { get; set; }

        public DateTime? DatumErstellung { get; set; }

        [StringLength(200)]
        public string Stichworte { get; set; }

        public DateTime? DatumMutation { get; set; }

        [StringLength(200)]
        public string Grund { get; set; }

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
        public byte[] VmBudgetTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
