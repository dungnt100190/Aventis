using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class KaVermittlungSizwischenbericht
    {
        public int KaVermittlungSizwischenberichtId { get; set; }
        public int? KaVermittlungVorschlagId { get; set; }
        public DateTime? Anfrage { get; set; }
        public DateTime? Mahnung { get; set; }
        public DateTime? Eingang { get; set; }
        public string Bemerkung { get; set; }
        public int? InterventionCode { get; set; }
        public int? VorgeseheneMassnahmenCode { get; set; }
        public DateTime? ZwischenberichtSd { get; set; }
        public byte[] KaVermittlungSizwischenberichtTs { get; set; }

        public KaVermittlungVorschlag KaVermittlungVorschlag { get; set; }
    }
}
