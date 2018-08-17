using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using KiSSSvc.Logging;


namespace KiSSSvc.SAP.PSCD.Notification
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

		public void Application_Error(object sender, EventArgs e)
		{
			Exception ex = Server.GetLastError();
			Log.Error(ex.GetType(), "global.asax, Application_Error", ex);
		}
	}
}