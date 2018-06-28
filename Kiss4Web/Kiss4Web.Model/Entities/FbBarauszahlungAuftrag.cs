using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbBarauszahlungAuftrag
    {
        public FbBarauszahlungAuftrag()
        {
            FbBarauszahlungZyklus = new HashSet<FbBarauszahlungZyklus>();
        }

        public int FbBarauszahlungAuftragId { get; set; }
        public int FaLeistungId { get; set; }
        public int UserIdCreator { get; set; }
        public int UserIdModifier { get; set; }
        public int? XdocumentId { get; set; }
        public bool AuszahlungenVorhanden { get; set; }
        public decimal Betrag { get; set; }
        public string Buchungstext { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime? DatumBis { get; set; }
        public int FbBarauszahlungPeriodizitaetCode { get; set; }
        public int SollKtoNr { get; set; }
        public int HabenKtoNr { get; set; }
        public int Vorbezug { get; set; }
        public int Nachbezug { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FbBarauszahlungAuftragTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser UserIdCreatorNavigation { get; set; }
        public XUser UserIdModifierNavigation { get; set; }
        public ICollection<FbBarauszahlungZyklus> FbBarauszahlungZyklus { get; set; }
    }
}
