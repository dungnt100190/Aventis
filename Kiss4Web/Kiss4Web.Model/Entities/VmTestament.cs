using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmTestament
    {
        public VmTestament()
        {
            VmErbe = new HashSet<VmErbe>();
            VmTestamentBescheinigung = new HashSet<VmTestamentBescheinigung>();
            VmTestamentVerfuegung = new HashSet<VmTestamentVerfuegung>();
        }

        public int VmTestamentId { get; set; }
        public int FaLeistungId { get; set; }
        public int? LaufNr { get; set; }
        public int? UserId { get; set; }
        public string KopieAnCodes { get; set; }
        public string ZeugnisseCodes { get; set; }
        public decimal? EroeffnungsRechnungBetrag { get; set; }
        public string EroeffnungsRechnungSapnr { get; set; }
        public decimal? ZusatzRechnungBetrag { get; set; }
        public string ZusatzRechnungSapnr { get; set; }
        public int? EroeffnungDokId { get; set; }
        public int? EroeffnungAuszugDokId { get; set; }
        public int? EroeffnungAdressenDokId { get; set; }
        public DateTime? EroeffnungAbgeschlossenDatum { get; set; }
        public DateTime? PublikationFrist { get; set; }
        public DateTime? PublikationDatum { get; set; }
        public string Bemerkung { get; set; }
        public byte[] VmTestamentTs { get; set; }
        public int? NotarId { get; set; }
        public int? Jahr { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public BaInstitution Notar { get; set; }
        public XUser User { get; set; }
        public ICollection<VmErbe> VmErbe { get; set; }
        public ICollection<VmTestamentBescheinigung> VmTestamentBescheinigung { get; set; }
        public ICollection<VmTestamentVerfuegung> VmTestamentVerfuegung { get; set; }
    }
}
