using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaInizio
    {
        public int KaInizioId { get; set; }
        public int? FaLeistungId { get; set; }
        public DateTime? MappeVerschickt { get; set; }
        public DateTime? AnmeldungEingegangen { get; set; }
        public int? AnmeldungDurchCode { get; set; }
        public int? SchulabschlussCode { get; set; }
        public int? EmpfehlungInizioCode { get; set; }
        public int? AbschlussPhaseCode { get; set; }
        public byte[] KaInizioTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
