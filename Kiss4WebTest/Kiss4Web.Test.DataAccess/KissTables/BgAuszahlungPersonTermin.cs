namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgAuszahlungPersonTermin")]
    public partial class BgAuszahlungPersonTermin
    {
        public int BgAuszahlungPersonTerminID { get; set; }

        public int BgAuszahlungPersonID { get; set; }

        public DateTime Datum { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgAuszahlungPersonTerminTS { get; set; }

        public virtual BgAuszahlungPerson BgAuszahlungPerson { get; set; }
    }
}
