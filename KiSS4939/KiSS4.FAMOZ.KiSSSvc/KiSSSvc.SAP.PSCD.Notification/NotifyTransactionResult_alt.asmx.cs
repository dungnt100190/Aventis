using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KiSSSvc.Logging;

namespace KiSSSvc.SAP.PSCD.Notification
{
	/// <summary>
	/// Summary description for NotifyTransactionResult
	/// </summary>
	[WebService(Namespace = "http://www.born.ch/KiSS/FAMOZ/PSCD/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	public class NotifyTransactionResult_alt : System.Web.Services.WebService
	{

		[WebMethod]
		public bool Notify(long transactionID, PscdReturnMessage[] messages)
		{
			Log.Info(this.GetType(), string.Format("Result received, ID: {0}, Message Count: {1}", transactionID, messages == null ? "null" : messages.Length.ToString()));
			return true;
		}

		//[WebMethod]
		//public bool Test()
		//{
		//   return this.Notify(-1, null);
		//}

	}

	public class PscdReturnMessage
	{
		public string Type;
		public string ID;
		public string Number;
		public string Message;
		public string Log_No;
		public string Log_Msg_No;
		public string MessageV1;
		public string MessageV2;
		public string MessageV3;
		public string MessageV4;
		public string Parameter;
		public string Row;
		public string Field;
		public string System;
	}
}
