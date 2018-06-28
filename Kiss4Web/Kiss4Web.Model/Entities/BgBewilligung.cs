using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgBewilligung
    {
        public int BgBewilligungId { get; set; }
        public int? BgFinanzplanId { get; set; }
        public int? BgBudgetId { get; set; }
        public int UserId { get; set; }
        public int? UserIdAn { get; set; }
        public DateTime Datum { get; set; }
        public int BgBewilligungCode { get; set; }
        public string Bemerkung { get; set; }
        public DateTime? PerDatum { get; set; }
        public byte[] BgBewilligungTs { get; set; }
        public int? BgPositionId { get; set; }
        public int? UserIdZustaendig { get; set; }
        public int? OrgUnitIdChefZustaendig { get; set; }
        public bool Zurueckgewiesen { get; set; }

        public BgBudget BgBudget { get; set; }
        public BgFinanzplan BgFinanzplan { get; set; }
        public BgPosition BgPosition { get; set; }
        public XOrgUnit OrgUnitIdChefZustaendigNavigation { get; set; }
        public XUser User { get; set; }
        public XUser UserIdAnNavigation { get; set; }
        public XUser UserIdZustaendigNavigation { get; set; }
    }
}
