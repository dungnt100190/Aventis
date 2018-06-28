using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class IkBetreibung
    {
        public IkBetreibung()
        {
            IkBetreibungAusgleich = new HashSet<IkBetreibungAusgleich>();
        }

        public int IkBetreibungId { get; set; }
        public int? FaLeistungId { get; set; }
        public int? IkRechtstitelId { get; set; }
        public int IkBetreibungStatusCode { get; set; }
        public int IkVerlustscheinStatusCode { get; set; }
        public int IkVerlustscheinTypCode { get; set; }
        public DateTime BetreibungAm { get; set; }
        public string BetreibungNummer { get; set; }
        public string BetreibungAmt { get; set; }
        public decimal? BetreibungBetrag { get; set; }
        public DateTime? BetreibungVon { get; set; }
        public DateTime? BetreibungBis { get; set; }
        public DateTime? BetreibungFortsetzungAm { get; set; }
        public DateTime? BetreibungVerwertungAm { get; set; }
        public DateTime? BetreibungRechtsoeffnungAm { get; set; }
        public string Glaeubiger { get; set; }
        public DateTime VerlustscheinAm { get; set; }
        public string VerlustscheinNummer { get; set; }
        public string VerlustscheinAmt { get; set; }
        public decimal? VerlustscheinBetrag { get; set; }
        public decimal? VerlustscheinZins { get; set; }
        public decimal? VerlustscheinKosten { get; set; }
        public DateTime? VerlustscheinVerjaehrungAm { get; set; }
        public string Bemerkung { get; set; }
        public byte[] IkBetreibungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public IkRechtstitel IkRechtstitel { get; set; }
        public ICollection<IkBetreibungAusgleich> IkBetreibungAusgleich { get; set; }
    }
}
