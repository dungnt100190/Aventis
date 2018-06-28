using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbBarauszahlungZyklus
    {
        public FbBarauszahlungZyklus()
        {
            FbBarauszahlungAusbezahlt = new HashSet<FbBarauszahlungAusbezahlt>();
        }

        public int FbBarauszahlungZyklusId { get; set; }
        public int FbBarauszahlungAuftragId { get; set; }
        public DateTime DatumStart { get; set; }
        public int DauerNaechsteZahlung { get; set; }
        public int DauerTypCode { get; set; }
        public int? WochentagCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FbBarauszahlungZyklusTs { get; set; }

        public FbBarauszahlungAuftrag FbBarauszahlungAuftrag { get; set; }
        public ICollection<FbBarauszahlungAusbezahlt> FbBarauszahlungAusbezahlt { get; set; }
    }
}
