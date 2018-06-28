using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmMandant
    {
        public VmMandant()
        {
            BaAdresse = new HashSet<BaAdresse>();
        }

        public int VmMandantId { get; set; }
        public int BaPersonId { get; set; }
        public int Version { get; set; }
        public DateTime Datum { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public int? ZivilstandCode { get; set; }
        public int? HeimatgemeindeBaGemeindeId { get; set; }
        public string Beruf { get; set; }
        public string WertschriftenDepot { get; set; }
        public string Ahvnummer { get; set; }
        public string Versichertennummer { get; set; }
        public string Bemerkung { get; set; }
        public byte[] VmMandantTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public BaGemeinde HeimatgemeindeBaGemeinde { get; set; }
        public XUser User { get; set; }
        public ICollection<BaAdresse> BaAdresse { get; set; }
    }
}
