namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hist_BDELeistung
    {
        public int UserID { get; set; }

        public int BDELeistungsartID { get; set; }

        public int KostenstelleOrgUnitID { get; set; }

        public int? BaPersonID { get; set; }

        public DateTime Datum { get; set; }

        [Column(TypeName = "money")]
        public decimal? Dauer { get; set; }

        public int? Anzahl { get; set; }

        public int? LohnartCode { get; set; }

        [StringLength(500)]
        public string Bemerkung { get; set; }

        public bool KeinExport { get; set; }

        public int HistKostentraeger { get; set; }

        public int HistKostenstelle { get; set; }

        public int HistKostenart { get; set; }

        public int HistMandantNr { get; set; }

        public bool Freigegeben { get; set; }

        public bool Visiert { get; set; }

        public DateTime? Verbucht { get; set; }

        public DateTime? VerbuchtLD { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VerID { get; set; }

        public int? VerID_DELETED { get; set; }

        public bool Fakturiert { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BDELeistungID { get; set; }
    }
}
