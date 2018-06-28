using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmErblasser
    {
        public int VmErblasserId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? TodesDatum { get; set; }
        public string TodesDatumText { get; set; }
        public string TodesOrt { get; set; }
        public string Ahvnummer { get; set; }
        public string Anrede { get; set; }
        public string FamilienNamen { get; set; }
        public string LedigName { get; set; }
        public string Vornamen { get; set; }
        public string Elternnamen { get; set; }
        public string Zivilstand { get; set; }
        public int? ZivilstandCode { get; set; }
        public string Geburtsdatum { get; set; }
        public string Heimatorte { get; set; }
        public string Strasse { get; set; }
        public string Ort { get; set; }
        public string Aufenthalt { get; set; }
        public string Bemerkung { get; set; }
        public byte[] VmErblasserTs { get; set; }
        public string Versichertennummer { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
