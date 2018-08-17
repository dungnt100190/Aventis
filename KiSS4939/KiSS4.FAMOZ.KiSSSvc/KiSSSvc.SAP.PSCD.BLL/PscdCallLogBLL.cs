using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.DAL;
using KiSSSvc.DAL.KiSSDBTableAdapters;
using KiSSSvc.Logging;


namespace KiSSSvc.SAP.PSCD.BLL
{
	public static class PscdCallLogBLL
	{
		public static void InsertCallLog(DateTime startTime, string serviceName, string serviceURL, string returnMsg, int elapsedMilliseconds, string exceptionMsg, KiSSDB.PscdCallReturnMsgDataTable errorMsgs, long? primaryKey, int? userID, string userWinLogonName)
		{
			PscdCallTableAdapter adapter = new PscdCallTableAdapter();
			adapter.InitializeKiSSAdapter(null);
			long pscdCallID = -1;
			try
			{

                //Log.Info(adapter.GetType(), "startTime:" + startTime.ToString());
                //Log.Info(adapter.GetType(), "serviceName:" + serviceName);
                //Log.Info(adapter.GetType(), "serviceURL:" + serviceURL);
                //Log.Info(adapter.GetType(), "elapsedMilliseconds:" + elapsedMilliseconds.ToString());
                ////Log.Info(adapter.GetType(), "exceptionMsg:" + (exceptionMsg == null) ? "NULL" : exceptionMsg.Substring(0, Math.Min(1000, exceptionMsg.Length)));
                ////Log.Info(adapter.GetType(), "errorMsgs:" + errorMsgs.ToString());
                //Log.Info(adapter.GetType(), "primaryKey:" + primaryKey.ToString());
                //Log.Info(adapter.GetType(), "userID:" + userID.ToString());
                //Log.Info(adapter.GetType(), "userName:" + userWinLogonName);

                adapter.Insert(startTime, serviceName, serviceURL, returnMsg, elapsedMilliseconds, exceptionMsg == null ? null : exceptionMsg.Substring(0, Math.Min(1000, exceptionMsg.Length)), primaryKey, userID.HasValue ? userID.Value : (int?)null, userWinLogonName, out pscdCallID);
			}
			catch (Exception ex) { Logging.Log.Info(typeof(PscdCallLogBLL), ex.Message); }

			if (errorMsgs != null)
			{
				foreach (KiSSDB.PscdCallReturnMsgRow errorMsg in errorMsgs)
					if (pscdCallID >= 0)
						errorMsg.PscdCallID = pscdCallID;
					else
						errorMsg.SetPscdCallIDNull();

				PscdCallReturnMsgTableAdapter msgAdapter = new PscdCallReturnMsgTableAdapter();
                msgAdapter.InitializeKiSSAdapter(null);
				msgAdapter.Update(errorMsgs);
			}
		}

	}


}
