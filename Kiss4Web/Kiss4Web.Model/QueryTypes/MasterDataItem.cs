using System;
using System.Collections.Generic;
using System.Text;

namespace Kiss4Web.Model.QueryTypes
{
    public class MasterDataItem
    {
		public IEnumerable<SelectItem> Status { get; set; }
		public IEnumerable<SelectItem> PendenzType { get; set; }
		public IEnumerable<SelectItem> Organisationseinheit { get; set; }
        public string Ersteller { get; set; }
    }

	public class SelectItem

	{
		public int Value { get; set; }
		public string Name { get; set; }
	}
}
