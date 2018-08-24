namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwTmKaBetriebVerlauf")]
    public partial class vwTmKaBetriebVerlauf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KaBetriebBesprechungID { get; set; }

        public DateTime? Datum { get; set; }

        [StringLength(202)]
        public string Kontaktperson { get; set; }

        [StringLength(402)]
        public string Autor { get; set; }

        [StringLength(100)]
        public string Stichwort { get; set; }
    }
}
