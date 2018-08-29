namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmSteuern")]
    public partial class VmSteuern
    {
        public int VmSteuernID { get; set; }

        public int FaLeistungID { get; set; }

        public int? DocumentID { get; set; }

        public int? SteuerJahr { get; set; }

        public bool SteuererklaerungExternErledigt { get; set; }

        public bool SteuererklaerungInternErledigt { get; set; }

        [StringLength(255)]
        public string ErledigungDurch { get; set; }

        public DateTime? SteuererklaerungEingereicht { get; set; }

        public bool Artikel41 { get; set; }

        public DateTime? FristverlaengerungBeantragt { get; set; }

        public DateTime? EingangDefVeranlagung { get; set; }

        public DateTime? DatumEntscheidErlass { get; set; }

        public bool Erlass { get; set; }

        public bool Teilerlass { get; set; }

        public bool Abelehnt { get; set; }

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
        public byte[] VmSteuernTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
