namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKaVermittlungSI")]
    public partial class vwTmKaVermittlungSI
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KaVermittlungSIID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime DatumEroeffnung { get; set; }

        public DateTime? DatumEroeffnungAbklaerung { get; set; }

        public DateTime? DatumAbschluss { get; set; }

        [StringLength(402)]
        public string ZustaendigKA { get; set; }
    }
}
