namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmSchulden")]
    public partial class VmSchulden
    {
        public int VmSchuldenID { get; set; }

        public int FaLeistungID { get; set; }

        public int? VmSchuldtitelCode { get; set; }

        public DateTime? Datum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Betrag { get; set; }

        public DateTime? TilgungDatum { get; set; }

        public int? DocumentID { get; set; }

        [StringLength(200)]
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
        public byte[] VmSchuldenTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
