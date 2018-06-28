using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmSiegelung
    {
        public VmSiegelung()
        {
            VmErbe = new HashSet<VmErbe>();
        }

        public int VmSiegelungId { get; set; }
        public int FaLeistungId { get; set; }
        public bool? Gesperrt { get; set; }
        public int? UserId { get; set; }
        public int? BezirkNr { get; set; }
        public int? LaufNr { get; set; }
        public int? Jahr { get; set; }
        public DateTime? TodesmeldungDatum { get; set; }
        public DateTime? SiegelungsDatum { get; set; }
        public bool? SiegelungsFristEingehalten { get; set; }
        public DateTime? VersandDatum { get; set; }
        public bool? KopieErbschaftsdienst { get; set; }
        public bool? KopieTestamentsdienst { get; set; }
        public string KopieAndere { get; set; }
        public int? VerfuegungsSperren { get; set; }
        public int? Durchsuchungen { get; set; }
        public string PliQuittung { get; set; }
        public bool? GesuchUeBestattung { get; set; }
        public bool? Ausschlagung { get; set; }
        public int? VmErbschaftInventarCode { get; set; }
        public int? NotarId { get; set; }
        public string MassaVerwalter { get; set; }
        public DateTime? EntsiegelungsDatum { get; set; }
        public bool? OhneGebuehr { get; set; }
        public string RechnungsNr { get; set; }
        public DateTime? RechnungsDatum { get; set; }
        public decimal? RechnungsBetrag { get; set; }
        public string RechnungAn { get; set; }
        public int? SiegelungsProtokollDokId { get; set; }
        public bool? Sdabgeschlossen { get; set; }
        public string Bemerkung { get; set; }
        public byte[] VmSiegelungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public BaInstitution Notar { get; set; }
        public XUser User { get; set; }
        public ICollection<VmErbe> VmErbe { get; set; }
    }
}
