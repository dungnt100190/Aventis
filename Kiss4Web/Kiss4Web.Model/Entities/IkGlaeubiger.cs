using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkGlaeubiger
    {
        public int IkGlaeubigerId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? IkRechtstitelId { get; set; }
        public int BaPersonId { get; set; }
        public int? BaPersonIdAntragStellendePerson { get; set; }
        public int? BaZahlungswegId { get; set; }
        public string Ausbildung { get; set; }
        public string Bemerkung { get; set; }
        public bool Aktiv { get; set; }
        public byte[] IkGlaeubigerTs { get; set; }
        public bool AuszahlungVermittlungStoppen { get; set; }

        public BaPerson BaPerson { get; set; }
        public BaPerson BaPersonIdAntragStellendePersonNavigation { get; set; }
        public BaZahlungsweg BaZahlungsweg { get; set; }
        public FaLeistung FaLeistung { get; set; }
        public IkRechtstitel IkRechtstitel { get; set; }
    }
}
