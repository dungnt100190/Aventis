namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmBeschwerdeAnfrage")]
    public partial class VmBeschwerdeAnfrage
    {
        public int VmBeschwerdeAnfrageID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? Eingang { get; set; }

        [StringLength(100)]
        public string Absender { get; set; }

        public string Stichworte { get; set; }

        public int? VmBsBeschwerdeBehandlungCode { get; set; }

        public DateTime? Abschluss { get; set; }

        public int? DocumentID { get; set; }

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
        public byte[] VmBeschwerdeAnfrageTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
