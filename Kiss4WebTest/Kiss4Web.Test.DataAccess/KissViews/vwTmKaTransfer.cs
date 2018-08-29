namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKaTransfer")]
    public partial class vwTmKaTransfer
    {
        [Key]
        [Column(Order = 0)]
        public int KaTransferID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        public DateTime? TelErstkontaktDat { get; set; }

        public DateTime? DatumVG { get; set; }

        public string AllgZiele { get; set; }

        public string Bewerbungsstrategie { get; set; }

        public DateTime? MuendAufforderungDat1 { get; set; }

        public DateTime? MuendAufforderungDat2 { get; set; }

        public string MuendAufforderungBem1 { get; set; }

        public string MuendAufforderungBem2 { get; set; }

        public DateTime? AustrittDat { get; set; }

        public int? AustrittGrund { get; set; }

        public int? AustrittCode { get; set; }

        public string AustrittBem { get; set; }
    }
}
