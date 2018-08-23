namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IkGlaeubiger")]
    public partial class IkGlaeubiger
    {
        public int IkGlaeubigerID { get; set; }

        public int? FaLeistungID { get; set; }

        public int? IkRechtstitelID { get; set; }

        public int BaPersonID { get; set; }

        public int? BaPersonID_AntragStellendePerson { get; set; }

        public int? BaZahlungswegID { get; set; }

        [StringLength(1024)]
        public string Ausbildung { get; set; }

        public string Bemerkung { get; set; }

        public bool Aktiv { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] IkGlaeubigerTS { get; set; }

        public bool AuszahlungVermittlungStoppen { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BaPerson BaPerson1 { get; set; }

        public virtual BaZahlungsweg BaZahlungsweg { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual IkRechtstitel IkRechtstitel { get; set; }
    }
}
