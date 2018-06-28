using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmBudget
    {
        public int VmBudgetId { get; set; }
        public int FaLeistungId { get; set; }
        public int? UserId { get; set; }
        public int? DocumentId { get; set; }
        public DateTime? DatumErstellung { get; set; }
        public string Stichworte { get; set; }
        public DateTime? DatumMutation { get; set; }
        public string Grund { get; set; }
        public bool IsDeleted { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmBudgetTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
    }
}
