using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.SAP.Helpers;
using System.Threading;
using System.Data;
using System.Net;
using KiSSSvc.Logging;
using KiSSSvc.DAL;
using KiSSSvc.SAP.PSCD.BLL;
using System.Web.Services.Protocols;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.PSCD.BudgetData;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.MahnlaufStarten;
using KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl;
using DTO = KiSSSvc.SAP.Helpers.DataObjects;

namespace KiSSSvc.SAP.PSCD.BudgetData
{
	public class MahnlaufStartenAsync
	{
		private MI_KISS_ANSTOSS_MAHN_SOAP_OUTService svcMahnlaufStarten;

		/// <summary>
		/// Constructor
		/// </summary>
        public MahnlaufStartenAsync()
		{
			svcMahnlaufStarten = WebServiceSource.GetMahnlaufStartenAsyncWS();
		}

		public ReturnMsgAsync MahnlaufStarten(DTO.MahnungBeleg[] mahnungBelege, DateTime austellungsDatum, DateTime zahlungBeruecksichtigt, UserInfo userInfo)
		{
		    string callId = String.Concat("MAHN_", DateTime.Now.ToString("yyyyMMddHHMMss"));
			ReturnMsgAsync retMsg = null;

			try
			{
				retMsg = TransactionControlService.Instance.GetReturnMsgForCallId(callId);
				//retMsg.ObjectID = baPersonID;
			}
			catch (Exception ex)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
			}

			if (retMsg != null)
				return retMsg;
			
			long transactionID = KeysBLL.GetBelegNr("TRANS");
			string transactionIDStr = SapHelper.GetTransactionID(transactionID);
            PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_ANSTOSS_MAHN_SOAP_OUT", svcMahnlaufStarten.Url, null, userInfo);
            
			try
			{
                Log.Info(svcMahnlaufStarten.GetType(), "Calling WebService MI_KISS_ANSTOSS_MAHN_SOAP_OUT...");
                
                _STZH_S_KISS_ANSTOSS_MAHNLAUF mahnlauf = new _STZH_S_KISS_ANSTOSS_MAHNLAUF();
                
                //Log.Info(this.GetType(), string.Format("mahnungBelege.GetLength(0): {0}", mahnungBelege.GetLength(0).ToString()));
                //Log.Info(this.GetType(), string.Format("mahnungBelege.GetLength(1): {0}", mahnungBelege.GetLength(1).ToString()));

                List<_STZH_S_BELEGE> listBelege = new List<_STZH_S_BELEGE>();                
                foreach (DTO.MahnungBeleg beleg in mahnungBelege)
                {
                    _STZH_S_BELEGE belegPSCD = new _STZH_S_BELEGE();
                    belegPSCD.OPBEL = beleg.BelegNummer;
                    belegPSCD.MAHNS_OLD = beleg.MahnstufeAlt.ToString();
                    belegPSCD.MAHNS = beleg.MahnstufeNeu.ToString();
                    listBelege.Add(belegPSCD);                    
                }
                mahnlauf.BELEGE = listBelege.ToArray();
                mahnlauf.AUSDAT = SapHelper.ConvertDate(austellungsDatum);
                mahnlauf.ZAHLBERBIS = SapHelper.ConvertDate(zahlungBeruecksichtigt);
                mahnlauf.LAUFD = SapHelper.ConvertDate(DateTime.Today);
                mahnlauf.LAUFI = DateTime.Now.ToString("HHMMss");
                svcMahnlaufStarten.MI_KISS_ANSTOSS_MAHN_SOAP_OUT(mahnlauf);            
                
                Log.Info(svcMahnlaufStarten.GetType(), "MI_KISS_ANSTOSS_MAHN_SOAP_OUT gesendet");
				log.StopWatch();
			}
			catch (Exception ex)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
				log.ExceptionMsg = ex.Message;
				Exception ex2 = new Exception(string.Format("Fehler beim Verbinden vom KiSS-Server zu XI (beim Starten eines Mahnlaufs: {0}{1}", ex.Message, WebServiceHelperMethods.GetNewLineString()), ex);
				throw ex2;
			}
			finally
			{
				log.WriteToDB();
			}
			retMsg = new ReturnMsgAsync(transactionIDStr);
			retMsg.CallId = callId;
			//retMsg.ObjectID = baPersonID;
			TransactionControlService.Instance.CreateNewTransaction(retMsg);

			return retMsg;
		}

        
        //Bei dieser asynchronen Schnittstelle, wird nur das Daten senden hier behandelt. Das Daten empfangen wird im InfoFetcher.MahnungenFetcher behandelt

        //#region Process Response from PSCD

        //public void Process_MI_KISS_ANSTOSS_MAHN_SOAP_OUT(string TRANSACTIONID, DTO.BAPIRET2[] RETURN_MESSAGES)
        //{
        //    TransactionControlService.Instance.SetTransactionReturnedFromSap(TRANSACTIONID, true, null);
        //    int? businessPartner = TransactionControlService.Instance.GetObjectIDFromCallID(TRANSACTIONID);
        //    if (!businessPartner.HasValue)
        //        throw new Exception(string.Format("Für die Transaktion mit ID {0} ist keine ID hinterlegt", TRANSACTIONID));

        //    if (RETURN_MESSAGES.Length > 0)
        //    {
        //        PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_ANSTOSS_MAHN_SOAP_OUT", svcMahnlaufStarten.Url, -1, null);
        //        log.ErrorMsgs = ParseReturnMessages(RETURN_MESSAGES);
        //        string exceptionMsg = "";
        //        foreach (DTO.BAPIRET2 message in RETURN_MESSAGES)
        //        {
        //            exceptionMsg += message.MESSAGE + WebServiceHelperMethods.GetNewLineString();
        //            Log.Info(svcMahnlaufStarten.GetType(), string.Format("ZReturnMessage: '{0}'", message.MESSAGE));
        //        }
        //        throw new Exception(exceptionMsg);
        //    }
        //}


        ///// <summary>
        ///// Parses the return messages.
        ///// </summary>
        ///// <param name="returnMessages">The return messages.</param>
        ///// <returns></returns>
        //private KiSSDB.PscdCallReturnMsgDataTable ParseReturnMessages(DTO.BAPIRET2[] returnMessages)
        //{
        //    KiSSDB.PscdCallReturnMsgDataTable errorTbl = new KiSSDB.PscdCallReturnMsgDataTable();
        //    int tempInt;
        //    foreach (DTO.BAPIRET2 retMsg in returnMessages)
        //    {
        //        KiSSDB.PscdCallReturnMsgRow err = errorTbl.NewPscdCallReturnMsgRow();
        //        err.CausingSystem = retMsg.SYSTEM;
        //        err.Field = Convert.ToString(retMsg.FIELD);
        //        if (int.TryParse(retMsg.LOG_MSG_NO, out tempInt))
        //            err.LogNrInternal = tempInt;
        //        else
        //            err.SetLogNrInternalNull();
        //        err.LogNr = retMsg.LOG_NO;
        //        err.Message1 = retMsg.MESSAGE_V1;
        //        err.Message2 = retMsg.MESSAGE_V2;
        //        err.Message3 = retMsg.MESSAGE_V3;
        //        err.Message4 = retMsg.MESSAGE_V4;
        //        err.MessageClass = retMsg.ID;

        //        if (int.TryParse(retMsg.NUMBER, out tempInt))
        //            err.MessageNumber = tempInt;
        //        else
        //            err.SetMessageNumberNull();
        //        err.Message = retMsg.MESSAGE;
        //        err.Parameter = retMsg.PARAMETER;
        //        //if (int.TryParse(retMsg.ROW, out tempInt))
        //        //   err.Row = tempInt;
        //        //else
        //        //    err.SetRowNull();
        //        if (retMsg.ROW.HasValue)
        //            err.Row = retMsg.ROW.Value;

        //        if (!string.IsNullOrEmpty(retMsg.TYPE))
        //            err.Severity = retMsg.TYPE;

        //        errorTbl.AddPscdCallReturnMsgRow(err);
        //    }
        //    return errorTbl;
        //}

        //#endregion



	}
}
