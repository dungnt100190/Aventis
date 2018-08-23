namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaBetriebBesprechung")]
    public partial class KaBetriebBesprechung
    {
        public int KaBetriebBesprechungID { get; set; }

        public int? KaBetriebID { get; set; }

        public DateTime? Datum { get; set; }

        public DateTime? KontaktGeplant { get; set; }

        public int? KontaktPersonID { get; set; }

        public int? AutorID { get; set; }

        public int? KontaktArtCode { get; set; }

        [StringLength(100)]
        public string Stichwort { get; set; }

        public string Inhalt { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaBetriebBesprechungTS { get; set; }

        public virtual KaBetrieb KaBetrieb { get; set; }

        public virtual XUser XUser { get; set; }
    }
}
