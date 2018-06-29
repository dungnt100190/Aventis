using System;
using System.Collections.Generic;
using System.Text;

namespace Kiss4Web.Model.Pendenzen
{
	public class TaskModel
	{
		public int OrderNumber { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public double SaleAmount { get; set; }
		public string Employee { get; set; }
		public string CustomerStoreCity { get; set; }
	}
}
