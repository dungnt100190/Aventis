namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmAHVMindestbeitrag")]
    public partial class VmAHVMindestbeitrag
    {
        public int VmAHVMindestbeitragID { get; set; }

        public int FaLeistungID { get; set; }

        public int? DocumentID_IKAuszug { get; set; }

        public int? DocumentID_Neutral { get; set; }

        public int? DocumentID_NEAnmeldung { get; set; }

        public DateTime? IKAuszugDatum { get; set; }

        [StringLength(200)]
        public string BeitragsRechnungsJahr { get; set; }

        [Column(TypeName = "money")]
        public decimal? Bruttolohn { get; set; }

        public DateTime? NEAnmeldungDatum { get; set; }

        public int? VmQuartalCode { get; set; }

        public string Bemerkungen { get; set; }

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
        public byte[] VmAHVMindestbeitragTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
