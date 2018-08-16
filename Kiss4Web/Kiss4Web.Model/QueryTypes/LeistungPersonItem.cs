using System;
using System.Collections.Generic;
using System.Text;

namespace Kiss4Web.Model.QueryTypes
{
    public class LeistungPersonItem
    {
		public IEnumerable<SelectItem> ListLeistung { get; set; }
		public IEnumerable<SelectItem> ListBetrifftPerson { get; set; }
	}
}
