namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKaEafSpezifischeErmittlung")]
    public partial class vwTmKaEafSpezifischeErmittlung
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaLeistungIDRelation { get; set; }

        [StringLength(200)]
        public string AnwTeilzeit { get; set; }

        public string Zielsetzungen { get; set; }

        public string BemAbschluss { get; set; }
    }
}
