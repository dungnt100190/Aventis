using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaBetriebBesprechung
    {
        public int KaBetriebBesprechungId { get; set; }
        public int? KaBetriebId { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? KontaktGeplant { get; set; }
        public int? KontaktPersonId { get; set; }
        public int? AutorId { get; set; }
        public int? KontaktArtCode { get; set; }
        public string Stichwort { get; set; }
        public string Inhalt { get; set; }
        public byte[] KaBetriebBesprechungTs { get; set; }

        public XUser Autor { get; set; }
        public KaBetrieb KaBetrieb { get; set; }
    }
}
