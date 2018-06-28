using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmErnennung
    {
        public int VmErnennungId { get; set; }
        public int VmMassnahmeId { get; set; }
        public int? UserId { get; set; }
        public int? VmPriMaId { get; set; }
        public DateTime? Ernennung { get; set; }
        public int? ErnennungsurkundeDokId { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmErnennungTs { get; set; }

        public XUser User { get; set; }
        public VmMassnahme VmMassnahme { get; set; }
        public VmPriMa VmPriMa { get; set; }
    }
}
