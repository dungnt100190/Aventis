using Dapper;
using Kiss4Web.Model.Pendenzen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Modules.Pendenzen
{
	[Authorize]
	public class PendenzenController : Controller
	{
		public PendenzenController()
		{ }

		[HttpGet]
		[Route("api/Pendenzen/RefreshNavBarItems")]
		public NavBarItemsModel RefreshNavBarItems()
		{
			var navbarItems = new NavBarItemsModel
			{
				ItmMeineFaellig = 1,
				ItmMeineOffen = 2,
				ItmMeineInBearbeitung = 3,
				ItmMeineErstellt = 4,
				ItmMeineErhalten = 5,
				ItmMeineZuVisieren = 6,
				ItmVersandteFaellig = 7,
				ItmVersandteZuVisieren = 8,
				ItmVersandteAllgemein = 9,
				ItmVersandteOffen = 10
			};
			return navbarItems;
		}

		[HttpGet]
		[Route("api/Pendenzen/GetListPendenzen")]
		public IEnumerable<TaskModel> GetListPendenzen()
		{
			List<TaskModel> listContact = new List<TaskModel>();
			listContact.Add(new TaskModel
			{
				OrderNumber = 1111,
				OrderDate = DateTime.Now,
				DeliveryDate = DateTime.Now.AddDays(1),
				SaleAmount = 111.11,
				Employee = "DungNT",
				CustomerStoreCity = "Ha Noi"
			});
			listContact.Add(new TaskModel
			{
				OrderNumber = 2222,
				OrderDate = DateTime.Now.AddHours(1),
				DeliveryDate = DateTime.Now.AddDays(1).AddHours(1),
				SaleAmount = 222.22,
				Employee = "TrongNN",
				CustomerStoreCity = "Da Nang"
			});
			listContact.Add(new TaskModel
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
}
