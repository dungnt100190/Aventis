namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaAKZuweiser")]
    public partial class KaAKZuweiser
    {
        public int KaAKZuweiserID { get; set; }

        public int FaLeistungID { get; set; }

        public DateTime? Erfassung { get; set; }

        public int? AnmeldungCode { get; set; }

        public int? InstitutionID { get; set; }

        public int? BeraterID { get; set; }

        public bool SichtbarSDFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaAKZuweiserTS { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }
    }
}
