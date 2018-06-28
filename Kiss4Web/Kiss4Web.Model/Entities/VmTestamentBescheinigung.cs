using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmTestamentBescheinigung
    {
        public int VmTestamentBescheinigungId { get; set; }
        public int VmTestamentId { get; set; }
        public DateTime Datum { get; set; }
        public int? BescheinigungCode { get; set; }
        public string BescheinigungText { get; set; }
        public int? BescheinigungDokId { get; set; }
        public decimal? Gebuehr { get; set; }
        public string Sapnr { get; set; }
        public string Bemerkung { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmTestamentBescheinigungTs { get; set; }

        public VmTestament VmTestament { get; set; }
    }
}
