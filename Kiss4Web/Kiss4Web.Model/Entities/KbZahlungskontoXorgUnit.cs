using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbZahlungskontoXorgUnit
    {
        public int KbZahlungskontoXorgUnitId { get; set; }
        public int KbZahlungskontoId { get; set; }
        public int OrgUnitId { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KbZahlungskontoXorgUnitTs { get; set; }

        public KbZahlungskonto KbZahlungskonto { get; set; }
        public XOrgUnit OrgUnit { get; set; }
    }
}
