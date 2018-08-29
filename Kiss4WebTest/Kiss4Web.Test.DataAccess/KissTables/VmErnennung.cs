namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmErnennung")]
    public partial class VmErnennung
    {
        public int VmErnennungID { get; set; }

        public int VmMassnahmeID { get; set; }

        public int? UserID { get; set; }

        public int? VmPriMaID { get; set; }

        public DateTime? Ernennung { get; set; }

        public int? ErnennungsurkundeDokID { get; set; }

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
        public byte[] VmErnennungTS { get; set; }

        public virtual VmMassnahme VmMassnahme { get; set; }

        public virtual VmPriMa VmPriMa { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
