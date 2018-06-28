using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class FbDtajournal
    {
        public FbDtajournal()
        {
            FbDtabuchung = new HashSet<FbDtabuchung>();
        }

        public int FbDtajournalId { get; set; }
        public string FilePath { get; set; }
        public decimal TotalBetrag { get; set; }
        public DateTime? TransferDatum { get; set; }
        public int? FbDtazugangId { get; set; }
        public string PaymentMessageId { get; set; }
        public int UserId { get; set; }
        public bool Transferiert { get; set; }
        public string Zahlungsdaten { get; set; }
        public byte[] FbDtajournalTs { get; set; }

        public FbDtazugang FbDtazugang { get; set; }
        public XUser User { get; set; }
        public ICollection<FbDtabuchung> FbDtabuchung { get; set; }
    }
}
