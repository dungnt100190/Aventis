using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KbZahlungslauf
    {
        public KbZahlungslauf()
        {
            KbTransfer = new HashSet<KbTransfer>();
        }

        public int KbZahlungslaufId { get; set; }
        public int KbZahlungskontoId { get; set; }
        public string PaymentMessageId { get; set; }
        public int UserId { get; set; }
        public string FilePath { get; set; }
        public decimal TotalBetrag { get; set; }
        public DateTime? TransferDatum { get; set; }
        public bool Transferiert { get; set; }
        public string Zahlungsdaten { get; set; }
        public DateTime? FaelligkeitDatum { get; set; }
        public byte[] KbZahlungslaufTs { get; set; }

        public KbZahlungskonto KbZahlungskonto { get; set; }
        public XUser User { get; set; }
        public ICollection<KbTransfer> KbTransfer { get; set; }
    }
}
