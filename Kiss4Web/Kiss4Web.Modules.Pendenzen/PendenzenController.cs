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
		public IEnumerable<string> GetListPendenzen()
		{
			return new string[] { "value1", "value2" };
		}
	}
}
