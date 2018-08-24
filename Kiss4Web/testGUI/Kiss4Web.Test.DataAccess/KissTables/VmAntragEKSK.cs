namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmAntragEKSK")]
    public partial class VmAntragEKSK
    {
        public int VmAntragEKSKID { get; set; }

        public int FaLeistungID { get; set; }

        public int? UserID { get; set; }

        public int? DocumentID { get; set; }

        public string Antrag { get; set; }

        public string Begruendung { get; set; }

        public DateTime? DatumAntrag { get; set; }

        public DateTime? DatumGenehmigtEKSK { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(255)]
        public string Titel { get; set; }

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
        public byte[] VmAntragEKSKTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
