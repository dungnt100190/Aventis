namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkBetreibungAusgleich")]
    public partial class IkBetreibungAusgleich
    {
        public int IkBetreibungAusgleichID { get; set; }

        public int IkBetreibungID { get; set; }

        public int AusgleichBuchungID { get; set; }

        [Column(TypeName = "money")]
        public decimal Betrag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] IkBetreibungAusgleichTS { get; set; }

        public virtual IkBetreibung IkBetreibung { get; set; }

        public virtual KbBuchung KbBuchung { get; set; }
    }
}
