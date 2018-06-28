using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmInventar
    {
        public int VmInventarId { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public int? DocumentId { get; set; }
        public DateTime? Eroeffnung { get; set; }
        public DateTime? ErstKontakt { get; set; }
        public DateTime? Mahnung { get; set; }
        public DateTime? Genehmigung { get; set; }
        public DateTime? Versand { get; set; }
        public DateTime? InventarAufgenommen { get; set; }
        public string Bemerkung { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmInventarTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
