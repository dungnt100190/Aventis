namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BaPerson_Relation
    {
        public int BaPerson_RelationID { get; set; }

        public int BaPersonID_1 { get; set; }

        public int BaPersonID_2 { get; set; }

        public int? BaRelationID { get; set; }

        public DateTime? DatumVon { get; set; }

        public DateTime? DatumBis { get; set; }

        public string Bemerkung { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BaPerson_RelationTS { get; set; }

        public virtual BaPerson BaPerson { get; set; }

        public virtual BaPerson BaPerson1 { get; set; }

        public virtual BaRelation BaRelation { get; set; }
    }
}
