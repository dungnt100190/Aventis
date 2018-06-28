using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BaGesundheit
    {
        public int BaGesundheitId { get; set; }
        public int BaPersonId { get; set; }
        public int Jahr { get; set; }
        public int? KvgorganisationId { get; set; }
        public string KvgkontaktPerson { get; set; }
        public string KvgkontaktTelefon { get; set; }
        public string KvgmitgliedNr { get; set; }
        public DateTime? KvgversichertSeit { get; set; }
        public decimal? KvggrundPraemie { get; set; }
        public decimal? KvgunfallPraemie { get; set; }
        public decimal? KvggesundFoerdPraemie { get; set; }
        public decimal? KvgzuschussBetrag { get; set; }
        public decimal? KvgumweltabgabeBetrag { get; set; }
        public decimal? Kvgpraemie { get; set; }
        public decimal? Kvgfranchise { get; set; }
        public int? KvgzahlungsPeriodeCode { get; set; }
        public int? VvgorganisationId { get; set; }
        public string VvgkontaktPerson { get; set; }
        public string VvgkontaktTelefon { get; set; }
        public string VvgmitgliedNr { get; set; }
        public DateTime? VvgversichertSeit { get; set; }
        public decimal? Vvgpraemie { get; set; }
        public decimal? Vvgfranchise { get; set; }
        public int? VvgzahlungsPeriodeCode { get; set; }
        public string VvgzusaetzeRtf { get; set; }
        public bool? ZuschussInAbklaerungFlag { get; set; }
        public int? IveingliederungsmassnahmeCode { get; set; }
        public int? PflegeDurchCode { get; set; }
        public bool? PflegebeduerftigFlag { get; set; }
        public DateTime? DatumVon { get; set; }
        public DateTime? Asvsabmeldung { get; set; }
        public DateTime? Asvsanmeldung { get; set; }
        public string Bemerkung { get; set; }
        public bool AbtretungKk { get; set; }
        public DateTime? Evazdatum { get; set; }
        public int? ZahnarztBaInstitutionId { get; set; }
        public byte[] BaGesundheitTs { get; set; }

        public BaPerson BaPerson { get; set; }
        public BaInstitution Kvgorganisation { get; set; }
        public BaInstitution Vvgorganisation { get; set; }
        public BaInstitution ZahnarztBaInstitution { get; set; }
    }
}
