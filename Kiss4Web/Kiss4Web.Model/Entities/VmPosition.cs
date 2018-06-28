using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class VmPosition
    {
        public int VmPositionId { get; set; }
        public int VmKlientenbudgetId { get; set; }
        public int VmPositionsartId { get; set; }
        public bool IstImportiert { get; set; }
        public string Name { get; set; }
        public string Bemerkung { get; set; }
        public DateTime? DatumSaldoPer { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? BetragMonatlich { get; set; }
        public decimal? BetragJaehrlich { get; set; }
        public int SortKey { get; set; }
        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public string Modifier { get; set; }
        public DateTime Modified { get; set; }
        public byte[] VmPositionTs { get; set; }

        public VmKlientenbudget VmKlientenbudget { get; set; }
        public VmPositionsart VmPositionsart { get; set; }
    }
}
