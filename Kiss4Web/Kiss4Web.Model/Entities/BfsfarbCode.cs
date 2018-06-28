using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class BfsfarbCode
    {
        public int BfsfarbCodeId { get; set; }
        public int Leistungsfilter { get; set; }
        public int ExcelFarbCode { get; set; }
        public int BfsfrageId { get; set; }

        public Bfsfrage Bfsfrage { get; set; }
    }
}
