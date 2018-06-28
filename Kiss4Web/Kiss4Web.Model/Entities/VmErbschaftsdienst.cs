using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmErbschaftsdienst
    {
        public VmErbschaftsdienst()
        {
            VmErbe = new HashSet<VmErbe>();
        }

        public int VmErbschaftsdienstId { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public int? LaufNr { get; set; }
        public int? Jahr { get; set; }
        public string MassnahmenCodes { get; set; }
        public int? AnschriftErbenDokId { get; set; }
        public DateTime? AnschriftErbenDatum { get; set; }
        public int? InventarCode { get; set; }
        public int? InventarNotarId { get; set; }
        public bool? Aktiv { get; set; }
        public bool? VertretungsBeistandschaft { get; set; }
        public bool? Ausschlagung { get; set; }
        public bool? El { get; set; }
        public string KopieAnCodes { get; set; }
        public int? UeberweisungRstadokId { get; set; }
        public DateTime? UeberweisungRsta { get; set; }
        public string Massnahme { get; set; }
        public string Bemerkung { get; set; }
        public byte[] VmErbschaftsdienstTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public BaInstitution InventarNotar { get; set; }
        public XUser User { get; set; }
        public ICollection<VmErbe> VmErbe { get; set; }
    }
}
