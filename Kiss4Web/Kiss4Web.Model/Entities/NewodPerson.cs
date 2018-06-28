using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class NewodPerson
    {
        public int NewodPersonId { get; set; }
        public string Vorname { get; set; }
        public string Name { get; set; }
        public string Ahvnummer { get; set; }
        public string Versichertennummer { get; set; }
        public string GeburtsdatumString { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public string Strasse { get; set; }
        public string HausNr { get; set; }
        public string HausNrZusatz { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
    }
}
