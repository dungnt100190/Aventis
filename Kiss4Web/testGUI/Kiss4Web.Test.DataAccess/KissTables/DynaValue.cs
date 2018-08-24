namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DynaValue")]
    public partial class DynaValue
    {
        public int DynaValueID { get; set; }

        public int? FaPhaseID { get; set; }

        public int? FaLeistungID { get; set; }

        public int DynaFieldID { get; set; }

        public string ValueText { get; set; }

        public int GridRowID { get; set; }

        public DateTime CreationDate { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] DynaValueTS { get; set; }

        public virtual DynaField DynaField { get; set; }

        public virtual FaLeistung FaLeistung { get; set; }

        public virtual FaPhase FaPhase { get; set; }
    }
}
