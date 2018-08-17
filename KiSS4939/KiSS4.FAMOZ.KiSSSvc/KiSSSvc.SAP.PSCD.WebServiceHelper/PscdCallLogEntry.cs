using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Data;
using System.Web;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.SAP.PSCD.BLL;

namespace KiSSSvc.SAP.PSCD.WebServiceHelper
{
	public class PscdCallLogEntry
	{
		#region Properties

		private DateTime startTime;

		private string serviceURL;

		private string serviceName;

		private string returnMsg;
		public string ReturnMsg
		{
			get { return returnMsg; }
			set { returnMsg = value; }
		}

		private int elapsedMilliseconds;

		private string exceptionMsg;
		public string ExceptionMsg
		{
			get { return exceptionMsg; }
			set { exceptionMsg = value; }
		}

		private KiSSDB.PscdCallReturnMsgDataTable errorMsgs;
		public KiSSDB.PscdCallReturnMsgDataTable ErrorMsgs
		{
			get { return errorMsgs; }
			set { errorMsgs = value; }
		}

		long? primaryKey = null;

		private UserInfo user;
		public UserInfo User
		{
			get { return user; }
			set { user = value; }
		}


		#endregion

		Stopwatch watch;
		public PscdCallLogEntry(string serviceName, string serviceUrl, long? primaryKey, UserInfo user)
		{
			startTime = DateTime.Now;
			this.serviceName = serviceName;
			this.serviceURL = serviceUrl;
			this.primaryKey = primaryKey;
			this.user = user;
			watch = Stopwatch.StartNew();
		}

		public void StopWatch()
		{
			if (watch.IsRunning)
			{
				watch.Stop();
				elapsedMilliseconds = (int)watch.ElapsedMilliseconds;
			}
		}

		public void WriteToDB()
		{
			if (watch.IsRunning)
				StopWatch();
			PscdCallLogBLL.InsertCallLog(startTime, serviceName, serviceURL, returnMsg, elapsedMilliseconds, exceptionMsg, errorMsgs, primaryKey, user == null ? (int?)null : user.UserID, user == null ? null : user.UserWinLogonName);
		}


		public void ThrowExceptionIfErrorOccured()
		{
			if (errorMsgs.Rows.Count > 0)
			{
				string msg = "";
				foreach (KiSSDB.PscdCallReturnMsgRow row in errorMsgs.Rows)
				{
					if (!row.IsSeverityNull() && row.Severity == "E")
						msg += string.Format("{0}\r\n", row.Message);
				}
				if (!string.IsNullOrEmpty(msg))
					throw new Exception(msg);
			}
		}

		public bool HasErrorOccured()
		{
			return exceptionMsg != null || (errorMsgs != null && errorMsgs.Select("Severity = 'E'").Length > 0);
		}

		/// <summary>
		/// Gibt die Fehlermeldung zurück, bereits Truncated auf 500 Zeichen (inkl. Datum/Zeit-Stempel)
		/// </summary>
		/// <param name="addNewLine"></param>
		/// <returns></returns>
		public string GetErrorMsgs(bool addNewLine)
		{
			string msgs = "";

			if (errorMsgs == null)
				return KiSSSvc.SAP.Helpers.SapHelper.TruncateFehlermeldung(this.exceptionMsg ?? msgs);

			foreach (KiSSDB.PscdCallReturnMsgRow row in errorMsgs.Rows)
				msgs += row.Message;

			if (addNewLine && !string.IsNullOrEmpty(msgs))
				msgs += WebServiceHelperMethods.GetNewLineString();
			return KiSSSvc.SAP.Helpers.SapHelper.TruncateFehlermeldung(msgs);
		}
	}

	public class PscdError
	{
		private char severity;
		public char Severity
		{
			get { return severity; }
			set { severity = value; }
		}

		private string messageClass;
		public string MessageClass
		{
			get { return messageClass; }
			set { messageClass = value; }
		}

		private int? messageNr;
		public int? MessageNr
		{
			get { return messageNr; }
			set { messageNr = value; }
		}

		private string messageText;
		public string MessageText
		{
			get { return messageText; }
			set { messageText = value; }
		}

		private string logNr;
		public string LogNr
		{
			get { return logNr; }
			set { logNr = value; }
		}

		private int? internalLogNr;
		public int? InternalLogNr
		{
			get { return internalLogNr; }
			set { internalLogNr = value; }
		}

		private string message1;
		public string Message1
		{
			get { return message1; }
			set { message1 = value; }
		}

		private string message2;
		public string Message2
		{
			get { return message2; }
			set { message2 = value; }
		}

		private string message3;
		public string Message3
		{
			get { return message3; }
			set { message3 = value; }
		}

		private string message4;
		public string Message4
		{
			get { return message4; }
			set { message4 = value; }
		}

		private string parameterName;
		public string ParameterName
		{
			get { return parameterName; }
			set { parameterName = value; }
		}

		private int? row;
		public int? Row
		{
			get { return row; }
			set { row = value; }
		}

		private string fieldName;
		public string FieldName
		{
			get { return fieldName; }
			set { fieldName = value; }
		}

		private string causingSystem;
		public string CausingSystem
		{
			get { return causingSystem; }
			set { causingSystem = value; }
		}

	}



	//private const string cacheNameOfAdapter = "PscdLogAdapter";
	//public Stopwatch watch = new Stopwatch();
	//private readonly string url;
	//private readonly DateTime sendDate;

	//public PscdCallLogEntry(string url)
	//{
	//   this.url = url;
	//   this.sendDate = DateTime.Now;
	//   watch.Start();
	//}

	//public void Stop()
	//{
	//   watch.Stop();
	//}

	//private void InsertLogEntry()
	//{
	//   PscdCallTableAdapter adapter = HttpRuntime.Cache[cacheNameOfAdapter] as PscdCallTableAdapter;
	//   if (adapter == null)
	//   {
	//      adapter = new PscdCallTableAdapter();
	//      adapter.ReplacePwd();
	//      HttpRuntime.Cache[cacheNameOfAdapter] = adapter;
	//   }
	//   adapter.InsertPscdCallLog(url, sendDate, (int)watch.ElapsedMilliseconds);
	//}

	//#region IDisposable Members

	//public void Dispose()
	//{
	//   if (watch.IsRunning)
	//   {

	//   }
	//}

	//#endregion

}
