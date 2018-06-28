using System;
using System.Collections.Generic;
using Kiss4Web.Model.Entities;

namespace Kiss4Web.Model
{
    public partial class VmKlientenbudget : IEntity, IAuditableEntity
    {
        public VmKlientenbudget()
        {
            VmPosition = new HashSet<VmPosition>();
        }

        public int VmKlientenbudgetId { get; set; }
        public int FaLeistungId { get; set; }
        public int UserId { get; set; }
        public int VmKlientenbudgetStatusCode { get; set; }
        public DateTime GueltigAb { get; set; }
        public int VmKlientenbudgetMutationsgrundCode { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmKlientenbudgetTs { get; set; }

        public FaLeistung FaLeistung { get; set; }
        public XUser User { get; set; }
        public ICollection<VmPosition> VmPosition { get; set; }
        public int Id => VmKlientenbudgetId;
        public byte[] RowVersion => VmKlientenbudgetTs;
    }
}