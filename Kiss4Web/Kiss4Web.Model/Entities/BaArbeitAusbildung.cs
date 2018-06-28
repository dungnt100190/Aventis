using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaArbeitAusbildung
    {
        public int BaPersonId { get; set; }
        public int? ErwerbssituationStatus1Code { get; set; }
        public int? ErwerbssituationStatus2Code { get; set; }
        public int? ErwerbssituationStatus3Code { get; set; }
        public int? ErwerbssituationStatus4Code { get; set; }
        public int? BeschaeftigungsGradCode { get; set; }
        public int? GrundTeilzeitarbeit1Code { get; set; }
        public int? GrundTeilzeitarbeit2Code { get; set; }
        public int? BrancheCode { get; set; }
        public int? ErlernterBerufCode { get; set; }
        public int? BerufCode { get; set; }
        public int? BaInstitutionId { get; set; }
        public int? HoechsteAusbildungCode { get; set; }
        public int? AbgebrochenAusbildungCode { get; set; }
        public int? AnstellungCode { get; set; }
        public decimal? Arbeitszeit { get; set; }
        public bool IsVariableArbeitszeit { get; set; }
        public DateTime? StempelDatum { get; set; }
        public int? WieOftArbeitslos { get; set; }
        public int? AusgesteuertUnbekanntCode { get; set; }
        public DateTime? AusgesteuertDatum { get; set; }
        public string Bemerkung { get; set; }
        public byte[] BaArbeitAusbildungTs { get; set; }
        public int? IntegrationsstandCode { get; set; }
        public bool FinanziellUnabhaengig { get; set; }

        public BaInstitution BaInstitution { get; set; }
        public BaPerson BaPerson { get; set; }
    }
}
