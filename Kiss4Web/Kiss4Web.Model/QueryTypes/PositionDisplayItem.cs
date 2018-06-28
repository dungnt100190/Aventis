using System;

namespace Kiss4Web.Model.QueryTypes
{
    public class PositionDisplayItem
    {
        public int SortKey { get; set; }
        public DateTime? Datum { get; set; }
        public DateTime? DatumSort { get; set; }
        public decimal? Gutschrift { get; set; }
        public decimal? Belastung { get; set; }
        public bool? Freigegeben { get; set; }
        public bool? Verbucht { get; set; }
        public bool? Gesperrt { get; set; }
        public string Buchungstext { get; set; }
        public decimal? Saldo { get; set; }
    }
}
