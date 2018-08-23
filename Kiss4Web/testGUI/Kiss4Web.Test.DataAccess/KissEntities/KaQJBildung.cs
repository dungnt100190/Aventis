namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQJBildung")]
    public partial class KaQJBildung
    {
        public int KaQJBildungID { get; set; }

        public int FaLeistungID { get; set; }

        public bool KursBewerbungFlag { get; set; }

        public bool KursInformatikFlag { get; set; }

        public bool KursVideoFlag { get; set; }

        public bool KursWissenFlag { get; set; }

        public bool KursCustom1Flag { get; set; }

        [StringLength(255)]
        public string KursCustom1Text { get; set; }

        public bool KursCustom2Flag { get; set; }

        [StringLength(255)]
        public string KursCustom2Text { get; set; }

        public bool KursCustom3Flag { get; set; }

        [StringLength(255)]
        public string KursCustom3Text { get; set; }

        public bool KursCustom4Flag { get; set; }

        [StringLength(255)]
        public string KursCustom4Text { get; set; }

        public bool KursCustom5Flag { get; set; }

        [StringLength(255)]
        public string KursCustom5Text { get; set; }

        public bool KursCustom6Flag { get; set; }

        [StringLength(255)]
        public string KursCustom6Text { get; set; }

        [Required]
        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [StringLength(50)]
        public string Modifier { get; set; }

        public DateTime Modified { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaQJBildungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
