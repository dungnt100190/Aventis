namespace Kiss4Web.Test.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BgBewilligung")]
    public partial class BgBewilligung
    {
        public int BgBewilligungID { get; set; }

        public int? BgFinanzplanID { get; set; }

        public int? BgBudgetID { get; set; }

        public int UserID { get; set; }

        public int? UserID_An { get; set; }

        public DateTime Datum { get; set; }

        public int BgBewilligungCode { get; set; }

        public string Bemerkung { get; set; }

        public DateTime? PerDatum { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] BgBewilligungTS { get; set; }

        public int? BgPositionID { get; set; }

        public int? UserID_Zustaendig { get; set; }

        public int? OrgUnitID_ChefZustaendig { get; set; }

        public bool Zurueckgewiesen { get; set; }

        public virtual BgBudget BgBudget { get; set; }

        public virtual BgFinanzplan BgFinanzplan { get; set; }

        public virtual BgPosition BgPosition { get; set; }

        public virtual XUser XUser { get; set; }

        public virtual XUser XUser1 { get; set; }

        public virtual XOrgUnit XOrgUnit { get; set; }

        public virtual XUser XUser2 { get; set; }
    }
}
