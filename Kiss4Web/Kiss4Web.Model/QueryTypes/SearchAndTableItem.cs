using System;
using System.Collections.Generic;
using System.Text;

namespace Kiss4Web.Model.QueryTypes
{
    public class SearchAndTableItem
    {
        public DateTime Fallig { get; set; }
        public string Betreff { get; set; }
        public List<object> Leistungsverantw { get; set; }
        public long Fallnummer { get; set; }
        public List<object> Ersteller { get; set; }
        public List<object> Empfanger { get; set; }
        public List<object> Status { get; set; }
        public DateTime Erfasst { get; set; }
        public DateTime Bearbeitung { get; set; }
        public DateTime Erledigt { get; set; }

    }
}
