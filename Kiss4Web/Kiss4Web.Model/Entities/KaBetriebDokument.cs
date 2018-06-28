using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaBetriebDokument
    {
        public int KaBetriebDokumentId { get; set; }
        public int? KaBetriebId { get; set; }
        public DateTime? Datum { get; set; }
        public int? AbsenderId { get; set; }
        public int? AdressatId { get; set; }
        public string Stichwort { get; set; }
        public int? DokumentDocId { get; set; }
        public byte[] KaBetriebDokumentTs { get; set; }

        public KaBetrieb KaBetrieb { get; set; }
    }
}
