namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwPersonSimple")]
    public partial class vwPersonSimple
    {
        [Key]
        [Column(Order = 0)]
        public int BaPersonID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(202)]
        public string NameVorname { get; set; }

        [StringLength(18)]
        public string Versichertennummer { get; set; }

        public int? GeschlechtCode { get; set; }

        public DateTime? Geburtsdatum { get; set; }
    }
}
