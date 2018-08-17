using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using KiSSSvc.Logging;

namespace KiSSSvc.SAP.PSCD.KiSSClientInterfaceAsync
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			Log.Init();
		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}