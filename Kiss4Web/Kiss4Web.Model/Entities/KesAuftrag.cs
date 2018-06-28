using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KesAuftrag
    {
        public KesAuftrag()
        {
            KesAuftragBaPerson = new HashSet<KesAuftragBaPerson>();
            KesDokument = new HashSet<KesDokument>();
        }

        public int KesAuftragId { get; set; }
        public int FaLeistungId { get; set; }
        public bool IsKs { get; set; }
        public DateTime? DatumAuftrag { get; set; }
        public int? DocumentIdAuftrag { get; set; }
        public int? UserId { get; set; }
        public DateTime? DatumFrist { get; set; }
        public int? KesGefaehrdungsmeldungDurchCode { get; set; }
        public int? KesAuftragDurchCode { get; set; }
        public int? KesAuftragAbklaerungsartCode { get; set; }
        public string Anlass { get; set; }
        public string Auftrag { get; set; }
        public DateTime? AbschlussDatum { get; set; }
        public int? KesAuftragAbschlussgrundCode { get; set; }
        public int? DocumentIdBeschlussRueckmeldung { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] KesAuftragTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
        public ICollection<KesAuftragBaPerson> KesAuftragBaPerson { get; set; }
        public ICollection<KesDokument> KesDokument { get; set; }
    }
}
