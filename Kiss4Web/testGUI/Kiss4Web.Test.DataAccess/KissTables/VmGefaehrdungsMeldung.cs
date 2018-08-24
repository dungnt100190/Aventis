namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmGefaehrdungsMeldung")]
    public partial class VmGefaehrdungsMeldung
    {
        public int VmGefaehrdungsMeldungID { get; set; }

        public int FaLeistungID { get; set; }

        public int? DocumentID { get; set; }

        public DateTime? DatumEingang { get; set; }

        public int? FaKontaktveranlasserCode { get; set; }

        [StringLength(255)]
        public string VmGefaehrdungNSBCodes { get; set; }

        [StringLength(255)]
        public string FaThemaCodes { get; set; }

        public string Ausgangslage { get; set; }

        public string Auflagen { get; set; }

        public string Ueberpruefung { get; set; }

        public string Konsequenzen { get; set; }

        public DateTime? AuflageDatum { get; set; }

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
        public byte[] VmGefaehrdungsMeldungTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
