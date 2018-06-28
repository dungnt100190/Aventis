using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkVerrechnungskonto
    {
        public int IkVerrechnungskontoId { get; set; }
        public int IkRechtstitelId { get; set; }
        public int BaPersonId { get; set; }
        public decimal Grundforderung { get; set; }
        public DateTime? VereinbarungVom { get; set; }
        public decimal BetragProMonat { get; set; }
        public DateTime DatumVon { get; set; }
        public DateTime DatumBis { get; set; }
        public decimal LetzterMonat { get; set; }
        public string Bemerkung { get; set; }
        public bool IstErledigt { get; set; }
        public bool IstAnnulliert { get; set; }
        public DateTime? AnnulliertAm { get; set; }
        public int? IkVerrechnungsartCode { get; set; }
        public byte[] IkVerrechnungskontoTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public IkRechtstitel IkRechtstitel { get; set; }
    }
}
