namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VmVaterschaft")]
    public partial class VmVaterschaft
    {
        public int VmVaterschaftID { get; set; }

        public int FaLeistungID { get; set; }

        [StringLength(50)]
        public string ZGBCodes { get; set; }

        public DateTime? AnerkennungDatum { get; set; }

        [StringLength(100)]
        public string AnerkennungOrt { get; set; }

        public DateTime? UHVDatum { get; set; }

        [Column(TypeName = "money")]
        public decimal? UHVBetrag { get; set; }

        public int? UHVAbschlussGrundCode { get; set; }

        public DateTime? SorgerechtVereinbDatum { get; set; }

        public DateTime? VAnfechtungsurteil { get; set; }

        public DateTime? VUrteilDatum { get; set; }

        [Column(TypeName = "money")]
        public decimal? VUrteilBetrag { get; set; }

        public DateTime? UnterhaltsurteilDatum { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnterhaltsurteilBetrag { get; set; }

        public DateTime? SchlussberichtAnKommission { get; set; }

        public DateTime? SchlussberichtGenehmigung { get; set; }

        public DateTime? GeburtsmitteilungDatum { get; set; }

        [StringLength(100)]
        public string GeburtsmitteilungOrt { get; set; }

        public DateTime? GebuehrDatum { get; set; }

        public bool? GebuehrErlass { get; set; }

        [StringLength(250)]
        public string PendenzText { get; set; }

        public DateTime? PendenzFrist { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] VmVaterschaftTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
