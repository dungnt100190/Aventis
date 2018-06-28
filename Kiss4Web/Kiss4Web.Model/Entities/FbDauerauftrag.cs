using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbDauerauftrag
    {
        public FbDauerauftrag()
        {
            FbBuchung = new HashSet<FbBuchung>();
        }

        public int FbDauerauftragId { get; set; }
        public string Text { get; set; }
        public int BaPersonId { get; set; }
        public int SollKtoNr { get; set; }
        public int HabenKtoNr { get; set; }
        public decimal Betrag { get; set; }
        public int FbZahlungswegId { get; set; }
        public DateTime DatumVon { get; set; }
        public int PeriodizitaetCode { get; set; }
        public int? WochentagCode { get; set; }
        public int? Monatstag1 { get; set; }
        public int? Monatstag2 { get; set; }
        public bool VorWochenende { get; set; }
        public DateTime? DatumBis { get; set; }
        public string ReferenzNummer { get; set; }
        public string Zahlungsgrund { get; set; }
        public int Status { get; set; }
        public byte[] FbDauerauftragTs { get; set; }
        public int? DauerauftragDokId { get; set; }

        public BaPerson BaPerson { get; set; }
        public FbZahlungsweg FbZahlungsweg { get; set; }
        public ICollection<FbBuchung> FbBuchung { get; set; }
    }
}
