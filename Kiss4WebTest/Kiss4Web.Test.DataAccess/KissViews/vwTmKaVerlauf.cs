namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKaVerlauf")]
    public partial class vwTmKaVerlauf
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KaVerlaufID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(402)]
        public string Autor { get; set; }

        public DateTime? Datum { get; set; }

        [StringLength(200)]
        public string Kontaktart { get; set; }

        [StringLength(255)]
        public string Kontaktperson { get; set; }

        [StringLength(255)]
        public string Stichwort { get; set; }

        [StringLength(1000)]
        public string Thema { get; set; }

        public string InhaltRTF { get; set; }

        public string InhaltNORTF { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool SichtbarSD { get; set; }
    }
}
