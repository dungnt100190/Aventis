using System;
using System.Collections.Generic;
using System.Text;

namespace Kiss4Web.Model.QueryTypes
{
    public class SearchPendenzenItem
    {
        public List<object> Status { get; set; }
        public List<object> PendenzTyp { get; set; }
        public string Betreff { get; set; }
        public List<object> Ersteller { get; set; }
        public DateTime Fallig { get; set; }
        public List<object> Empfanger { get; set; }
        public string NameKlientIn { get; set; }
        public long Fallnummer { get; set; }
        public char Leistungsverantw { get; set; }
        public object Organisationseinheit { get; set; }
        public DateTime Erfasst { get; set; }
        public DateTime Bearbeitung { get; set; }
        public DateTime Erledigt { get; set; }
        public string VornameKlientIn { get; set; }
        public string IdMenu { get; set; }
    }
}
