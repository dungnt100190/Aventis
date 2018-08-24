namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KaAmmBesch")]
    public partial class KaAmmBesch
    {
        public int KaAmmBeschID { get; set; }

        public int BaPersonID { get; set; }

        public int KaEinsatzID { get; set; }

        public int? KaEinsatzplatzID { get; set; }

        public int? ZustaendigKaID { get; set; }

        public int? Monat { get; set; }

        public int? Jahr { get; set; }

        public int? ProfilCode { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public bool gedrucktFlag { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] KaAKZuweiserTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual KaEinsatz KaEinsatz { get; set; }

        public virtual KaEinsatzplatz2 KaEinsatzplatz2 { get; set; }
    }
}
