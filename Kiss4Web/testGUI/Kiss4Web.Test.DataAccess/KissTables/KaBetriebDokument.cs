namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaBetriebDokument")]
    public partial class KaBetriebDokument
    {
        public int KaBetriebDokumentID { get; set; }

        public int? KaBetriebID { get; set; }

        public DateTime? Datum { get; set; }

        public int? AbsenderID { get; set; }

        public int? AdressatID { get; set; }

        [StringLength(100)]
        public string Stichwort { get; set; }

        public int? DokumentDocID { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaBetriebDokumentTS { get; set; }

        public virtual KaBetrieb KaBetrieb { get; set; }
    }
}
