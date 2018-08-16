using System;
using System.Collections.Generic;
using System.Text;

namespace Kiss4Web.Model.QueryTypes
{
    public class CreateOrUpdateTaskItem
    {
		public int? TaskId { get; set; }
		public int TaskTypeCode { get; set; }
		public string Betreff { get; set; }
		public string Beschreibung { get; set; }
		public string Empfanger { get; set; }
		public string Falltrager { get; set; }
		public string Leistung { get; set; }
		public string Leistungsverantw { get; set; }
		public string BetrifftPerson { get; set; }
		public string Antwort { get; set; }
		public DateTime Erfasst { get; set; }
		public DateTime Fallig { get; set; }

	}
}
