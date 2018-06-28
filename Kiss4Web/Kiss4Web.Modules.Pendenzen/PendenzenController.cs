using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kiss4Web.Modules.Pendenzen
{
	[Authorize]
	public class PendenzenController : Controller
	{
		public PendenzenController()
		{ }

		[HttpGet]
		[Route("api/Pendenzen/GetListPendenzen")]
		public IEnumerable<Task> GetListPendenzen()
		{
			List<Task> listContact = new List<Task>();
			listContact.Add(new Task
			{
				OrderNumber = 1111,
				OrderDate = DateTime.Now,
				DeliveryDate = DateTime.Now.AddDays(1),
				SaleAmount = 111.11,
				Employee = "DungNT",
				CustomerStoreCity = "Ha Noi"
			});
			listContact.Add(new Task
			{
				OrderNumber = 2222,
				OrderDate = DateTime.Now.AddHours(1),
				DeliveryDate = DateTime.Now.AddDays(1).AddHours(1),
				SaleAmount = 222.22,
				Employee = "TrongNN",
				CustomerStoreCity = "Da Nang"
			});
			listContact.Add(new Task
			{
				OrderNumber = 3333,
				OrderDate = DateTime.Now.AddHours(2),
				DeliveryDate = DateTime.Now.AddDays(1).AddHours(2),
				SaleAmount = 333.33,
				Employee = "TungTX",
				CustomerStoreCity = "Sai Gon"
			});
			return listContact;
		}
	}

	public class Task
	{
		public int OrderNumber { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime DeliveryDate { get; set; }
		public double SaleAmount { get; set; }
		public string Employee { get; set; }
		public string CustomerStoreCity { get; set; }
	}
}
