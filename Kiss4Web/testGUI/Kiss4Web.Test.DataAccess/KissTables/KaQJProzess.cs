namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaQJProzess")]
    public partial class KaQJProzess
    {
        public int KaQJProzessID { get; set; }

        public int FaLeistungID { get; set; }

        public int? KompetenzDokID { get; set; }

        public int? ZwischenzeugnisDokID { get; set; }

        public int? LebenslaufDokID { get; set; }

        public int? StandortbestDokID { get; set; }

        public int? ProgrammBildungDokID { get; set; }

        public int? BeilageSEMODokID { get; set; }

        public DateTime? ProgEnde { get; set; }

        public int? BeraterID { get; set; }

        public int? FallfuehrungID { get; set; }

        public string AndereStellen { get; set; }

        public int? ProgEndeGrund { get; set; }

        public int? ProgEndeCode { get; set; }

        public int? AbbruchCode { get; set; }

        public int? TermineStaoDokID { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaQJProzessTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
