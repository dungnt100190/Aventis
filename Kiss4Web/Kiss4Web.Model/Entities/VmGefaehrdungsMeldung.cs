using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmGefaehrdungsMeldung
    {
        public int VmGefaehrdungsMeldungId { get; set; }
        public int FaLeistungId { get; set; }
        public int? DocumentId { get; set; }
        public DateTime? DatumEingang { get; set; }
        public int? FaKontaktveranlasserCode { get; set; }
        public string VmGefaehrdungNsbcodes { get; set; }
        public string FaThemaCodes { get; set; }
        public string Ausgangslage { get; set; }
        public string Auflagen { get; set; }
        public string Ueberpruefung { get; set; }
        public string Konsequenzen { get; set; }
        public DateTime? AuflageDatum { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmGefaehrdungsMeldungTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
