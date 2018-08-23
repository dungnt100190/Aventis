namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmInventar")]
    public partial class VmInventar
    {
        public int VmInventarID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public int? DocumentID { get; set; }

        public DateTime? Eroeffnung { get; set; }

        public DateTime? ErstKontakt { get; set; }

        public DateTime? Mahnung { get; set; }

        public DateTime? Genehmigung { get; set; }

        public DateTime? Versand { get; set; }

        public DateTime? InventarAufgenommen { get; set; }

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
        public byte[] VmInventarTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
