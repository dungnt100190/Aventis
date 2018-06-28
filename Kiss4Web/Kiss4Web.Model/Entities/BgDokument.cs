using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BgDokument
    {
        public int BgDokumentId { get; set; }
        public int? BgFinanzplanId { get; set; }
        public int? BgBudgetId { get; set; }
        public int? BgPositionId { get; set; }
        public int? BgDokumentTypCode { get; set; }
        public int? DocumentId { get; set; }
        public string Stichwort { get; set; }
        public byte[] BgDocumentTs { get; set; }

        public BgBudget BgBudget { get; set; }
        public BgFinanzplan BgFinanzplan { get; set; }
        public BgPosition BgPosition { get; set; }
    }
}
