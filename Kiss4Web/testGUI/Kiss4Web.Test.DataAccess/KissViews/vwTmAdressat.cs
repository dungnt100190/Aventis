namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmAdressat")]
    public partial class vwTmAdressat
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FaDokumenteID { get; set; }

        [StringLength(126)]
        public string GeehrteFrauHerr { get; set; }

        [StringLength(500)]
        public string ErsteZeile { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1237)]
        public string AdresseMehrzeilig { get; set; }

        [StringLength(50)]
        public string Ort { get; set; }

        [StringLength(10)]
        public string PLZ { get; set; }

        [StringLength(61)]
        public string PLZOrt { get; set; }

        [StringLength(111)]
        public string Strasse { get; set; }

        [StringLength(200)]
        public string Zusatzzeile { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }
    }
}
