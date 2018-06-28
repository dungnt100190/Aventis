using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmBeschwerdeAnfrage
    {
        public int VmBeschwerdeAnfrageId { get; set; }
        public int FaLeistungId { get; set; }
        public DateTime? Eingang { get; set; }
        public string Absender { get; set; }
        public string Stichworte { get; set; }
        public int? VmBsBeschwerdeBehandlungCode { get; set; }
        public DateTime? Abschluss { get; set; }
        public int? DocumentId { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmBeschwerdeAnfrageTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
    }
}
