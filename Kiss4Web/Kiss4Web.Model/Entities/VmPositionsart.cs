using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmPositionsart
    {
        public VmPositionsart()
        {
            VmPosition = new HashSet<VmPosition>();
        }

        public int VmPositionsartId { get; set; }
        public int VmKategorieCode { get; set; }
        public int? VmPositionsartTypCode { get; set; }
        public bool IstTemplate { get; set; }
        public string Name { get; set; }
        public int SortKey { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmPositionsartTs { get; set; }

        public ICollection<VmPosition> VmPosition { get; set; }
    }
}
