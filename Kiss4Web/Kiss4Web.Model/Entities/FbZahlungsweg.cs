using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbZahlungsweg
    {
        public FbZahlungsweg()
        {
            FbBuchung = new HashSet<FbBuchung>();
            FbDauerauftrag = new HashSet<FbDauerauftrag>();
        }

        public int FbZahlungswegId { get; set; }
        public int FbKreditorId { get; set; }
        public int? BaBankId { get; set; }
        public string PckontoNr { get; set; }
        public string BankKontoNr { get; set; }
        public string Iban { get; set; }
        public int? ZahlungsArtCode { get; set; }
        public int? Zahlungsfrist { get; set; }
        public string BelegBankKontoNr { get; set; }
        public bool? IsActive { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] FbZahlungswegTs { get; set; }

        public BaBank BaBank { get; set; }
        public FbKreditor FbKreditor { get; set; }
        public ICollection<FbBuchung> FbBuchung { get; set; }
        public ICollection<FbDauerauftrag> FbDauerauftrag { get; set; }
    }
}
