namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwBaAdressate")]
    public partial class vwBaAdressate
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TypCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(11)]
        public string Typ { get; set; }

        [StringLength(601)]
        public string Name { get; set; }

        [StringLength(111)]
        public string Strasse { get; set; }

        [StringLength(61)]
        public string Ort { get; set; }
    }
}
