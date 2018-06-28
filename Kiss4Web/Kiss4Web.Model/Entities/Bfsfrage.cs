using System;
using System.Collections.Generic;

namespace Kiss4Web.Model
{
    public partial class Bfsfrage
    {
        public Bfsfrage()
        {
            BfsfarbCode = new HashSet<BfsfarbCode>();
            Bfswert = new HashSet<Bfswert>();
        }

        public int BfsfrageId { get; set; }
        public int BfskatalogVersionId { get; set; }
        public string Variable { get; set; }
        public string Frage { get; set; }
        public string BfsleistungsfilterCodes { get; set; }
        public int BfspersonCode { get; set; }
        public int PersonIndex { get; set; }
        public int BfsfeldCode { get; set; }
        public string Bfsformat { get; set; }
        public string Fflovname { get; set; }
        public string Bfslovname { get; set; }
        public int? BfsvalidierungCode { get; set; }
        public int? BfskategorieCode { get; set; }
        public int HerkunftCode { get; set; }
        public string HerkunftBeschreibung { get; set; }
        public string HerkunftSql { get; set; }
        public string Fftabelle { get; set; }
        public string Fffeld { get; set; }
        public string Ffpkfeld { get; set; }
        public bool? Editierbar { get; set; }
        public string ExportNode { get; set; }
        public string ExportAttribute { get; set; }
        public string ExportPredicate { get; set; }
        public string HilfeTitel { get; set; }
        public string HilfeText { get; set; }
        public int? Reihenfolge { get; set; }
        public byte[] BfsfrageTs { get; set; }
        public string FilterRegel { get; set; }
        public bool? UpdateOk { get; set; }
        public string VariableAntragsteller { get; set; }
        public string VariableExpandiert { get; set; }

        public BfskatalogVersion BfskatalogVersion { get; set; }
        public ICollection<BfsfarbCode> BfsfarbCode { get; set; }
        public ICollection<Bfswert> Bfswert { get; set; }
    }
}
