namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaTransferZielvereinb")]
    public partial class KaTransferZielvereinb
    {
        public int KaTransferZielvereinbID { get; set; }

        public int FaLeistungID { get; set; }

        public bool SichtbarSDFlag { get; set; }

        public DateTime? FeinzielDat { get; set; }

        public string Feinziel { get; set; }

        [StringLength(100)]
        public string ErreichenBis { get; set; }

        public string ProzessAuftrag { get; set; }

        public string Ergebnis { get; set; }

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
        public byte[] KaTransferZielvereinbTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
