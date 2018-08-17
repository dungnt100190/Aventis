using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.Logging;
using System.Data;
using KiSSSvc.SAP.Helpers;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.DAL;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.MahnungLesen;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.MahnlaufStarten;
using KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl;
using DTO = KiSSSvc.SAP.Helpers.DataObjects;

namespace KiSSSvc.SAP.PSCD.InfoFetcher
{
	public class MahnungenFetcher
	{
		private MI_READ_MAHNSService svc;
		//private MI_KISS_ANSTOSS_MAHN_SOAP_OUTService svcMahnlaufStarten;

		public MahnungenFetcher()
		{
			svc = WebServiceSource.GetMahnungLesenWS();
			//svcMahnlaufStarten = WebServiceSource.GetMahnlaufStartenAsyncWS();
		}

		public void FetchMahnungen()
		{
			try
			{
				_STZH_SOZ_MA_STA[] mahnungen = new _STZH_SOZ_MA_STA[] { };

				Log.Info(this.GetType(), "Rufe MI_READ_MAHNSService auf...");
				svc.MI_READ_MAHNS(ref mahnungen);
				Log.Info(this.GetType(), string.Format("Habe Mahnlauf mit {0} Belegen erhalten", mahnungen.Length));

				KiSSDB.PscdMahnungLogDataTable mahnungLog = new KiSSDB.PscdMahnungLogDataTable();

				int i = 0;
				foreach (_STZH_SOZ_MA_STA beleg in mahnungen)
				{
					KiSSDB.PscdMahnungLogRow log = mahnungLog.NewPscdMahnungLogRow();
					try
					{
						#region FillFields for DB-Log
						log.LAUFD = SapHelper.Truncate(beleg.LAUFD, 10);
						log.LAUFI = SapHelper.Truncate(beleg.LAUFI, 10);
						log.AUSDAT = SapHelper.Truncate(beleg.AUSDAT, 10);
						log.ZAHLBERBIS = SapHelper.Truncate(beleg.ZAHLBERBIS, 10);
						log.OPBEL = SapHelper.Truncate(beleg.OPBEL, 20);
						log.MAHNS_OLD = SapHelper.Truncate(beleg.MAHNS_OLD, 2);
						log.MAHNS = SapHelper.Truncate(beleg.MAHNS, 2);
						log.MAHN_FLAG = SapHelper.Truncate(beleg.MAHN_FLAG, 1);
						log.FUBANAME = SapHelper.Truncate(beleg.FUBANAME, 50);
						log.OPUPK = SapHelper.Truncate(beleg.OPUPK, 50);
						log.OPUPW = SapHelper.Truncate(beleg.OPUPW, 50);
						log.OPUPZ = SapHelper.Truncate(beleg.OPUPZ, 50);
						log.STATUS = SapHelper.Truncate(beleg.STATUS, 50);
						log.TIMESTAMP = SapHelper.Truncate(beleg.TIMESTAMP, 50);
						log.ErstelltDatum = DateTime.Now;
						log.Verarbeitet = false;

						///STZH/TYPE    CHAR 1
						///STZH/CODE    CHAR 5
						///STZH/MESSAGE CHAR 220

						#endregion

						#region Logging
						i++;
						if (i < 5)
						{
							Log.Info(beleg.GetType(), string.Format("AUSDAT: {0}", beleg.AUSDAT));
							Log.Info(beleg.GetType(), string.Format("FUBANAME: {0}", beleg.FUBANAME));
							Log.Info(beleg.GetType(), string.Format("LAUFD: {0}", beleg.LAUFD));
							Log.Info(beleg.GetType(), string.Format("LAUFI: {0}", beleg.LAUFI));
							Log.Info(beleg.GetType(), string.Format("MAHN_FLAG: {0}", beleg.MAHN_FLAG));
							Log.Info(beleg.GetType(), string.Format("MAHNS: {0}", beleg.MAHNS));
							Log.Info(beleg.GetType(), string.Format("MAHNS_OLD: {0}", beleg.MAHNS_OLD));
							Log.Info(beleg.GetType(), string.Format("MANDT: {0}", beleg.MANDT));
							Log.Info(beleg.GetType(), string.Format("OPBEL: {0}", beleg.OPBEL));
							Log.Info(beleg.GetType(), string.Format("OPUPK: {0}", beleg.OPUPK));
							Log.Info(beleg.GetType(), string.Format("OPUPW: {0}", beleg.OPUPW));
							Log.Info(beleg.GetType(), string.Format("OPUPZ: {0}", beleg.OPUPZ));
							Log.Info(beleg.GetType(), string.Format("STATUS: {0}", beleg.STATUS));
							Log.Info(beleg.GetType(), string.Format("TIMESTAMP: {0}", beleg.TIMESTAMP));
							Log.Info(beleg.GetType(), string.Format("ZAHLBERBIS: {0}", beleg.ZAHLBERBIS));
							Log.Info(beleg.GetType(), string.Format("TYPE: {0}", beleg._STZH_TYPE));
							Log.Info(beleg.GetType(), string.Format("CODE: {0}", beleg._STZH_CODE));
							Log.Info(beleg.GetType(), string.Format("MESSAGE: {0}", beleg._STZH_MESSAGE));
						}
						#endregion

						//TODO: Plausis
						int mahnstufe_neu = Convert.ToInt32(beleg.MAHNS);
						// Mahnstufe 99 ist 'in Betreibung' und entspricht Status 4 im KiSS
						if (mahnstufe_neu == 99)
							mahnstufe_neu = 4;

						//int mahnstufe_alt = Convert.ToInt32(beleg.MAHNS_OLD);

						//if (mahnstufe_neu < 90)
						//{
						//   if (mahnstufe_neu < mahnstufe_alt)
						//      throw new Exception(string.Format("Es darf keine niedrigere Mahnstufe angegeben werden! Beleg={0}, StufeAlt={1}, StufeNeu={2}",
						//                                        beleg.OPBEL, beleg.MAHNS_OLD, beleg.MAHNS));

						//   if ((mahnstufe_neu - mahnstufe_alt) > 1)
						//      throw new Exception(string.Format("Es darf nur um 1 Mahnstufe erhöht werden! Beleg={0}, StufeAlt={1}, StufeNeu={2}",
						//                                        beleg.OPBEL, beleg.MAHNS_OLD, beleg.MAHNS));
						//}
						//TODO: mit Belegnummer, Buchung holen, (plausi Betrag > 0) + KbBuchungStatusCode in (3,10)
						//ev. auslassen, da im Update-Query das sicher gestellt wird.

						int count = 0;
						long bnr;
						if (long.TryParse(beleg.OPBEL, out bnr))
							count = KbBuchungBruttoBLL.UpdateMahnstufe(bnr, mahnstufe_neu);

						log.Verarbeitet = (count > 0);

						//TODO: ASYNC-Transaction-Handling (Transaction abschliessen)
						//Problem ist, hier kommen 2 verschiedene Arten, einmal die von Async, aber auch direkt vom PSCD						
						//long transactionID = KeysBLL.GetBelegNr("TRANS");
						//string transactionIDStr = SapHelper.GetTransactionID(transactionID);
						//TransactionControlService.Instance.SetTransactionReturnedFromSap(transactionIDStr, true, null);

						if (!log.Verarbeitet)
						{
							string msg = string.Format("Mahnstufe konnte nicht aktualisiert werden! Beleg={0}, StufeAlt={1}, StufeNeu={2}",
																			 beleg.OPBEL, beleg.MAHNS_OLD, beleg.MAHNS);
							Log.Info(this.GetType(), msg);
							log.Fehlermeldung = SapHelper.Truncate(msg, 300);
						}
					}
					catch (Exception ex)
					{
						Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
						log.Fehlermeldung = SapHelper.Truncate(ex.Message, 300);
					}
					mahnungLog.AddPscdMahnungLogRow(log);
				}
				PscdMahnungLogBLL.Update(mahnungLog);
			}
			catch (Exception ex)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
			}
			finally
			{
				Log.Info(this.GetType(), "Aufruf von MI_READ_MAHNSService beendet");
			}
		}

		#region Process Response from PSCD

		public void Process_MI_KISS_ANSTOSS_MAHN_SOAP_OUT(string TRANSACTIONID, DTO.BAPIRET2[] RETURN_MESSAGES)
		{
			TransactionControlService.Instance.SetTransactionReturnedFromSap(TRANSACTIONID, true, null);
			int? businessPartner = TransactionControlService.Instance.GetObjectIDFromCallID(TRANSACTIONID);
			if (!businessPartner.HasValue)
				throw new Exception(string.Format("Für die Transaktion mit ID {0} ist keine ID hinterlegt", TRANSACTIONID));

			if (RETURN_MESSAGES.Length > 0)
			{
				PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_ANSTOSS_MAHN_SOAP_OUT", "??", -1, null);
				log.ErrorMsgs = ParseReturnMessages(RETURN_MESSAGES);
				string exceptionMsg = "";
				foreach (DTO.BAPIRET2 message in RETURN_MESSAGES)
				{
					exceptionMsg += message.MESSAGE + WebServiceHelperMethods.GetNewLineString();
					Log.Info(this.GetType(), string.Format("ZReturnMessage: '{0}'", message.MESSAGE));
				}
				throw new Exception(exceptionMsg);
			}
		}


		/// <summary>
		/// Parses the return messages.
		/// </summary>
		/// <param name="returnMessages">The return messages.</param>
		/// <returns></returns>
		private KiSSDB.PscdCallReturnMsgDataTable ParseReturnMessages(DTO.BAPIRET2[] returnMessages)
		{
			KiSSDB.PscdCallReturnMsgDataTable errorTbl = new KiSSDB.PscdCallReturnMsgDataTable();
			int tempInt;
			foreach (DTO.BAPIRET2 retMsg in returnMessages)
			{
				KiSSDB.PscdCallReturnMsgRow err = errorTbl.NewPscdCallReturnMsgRow();
				err.CausingSystem = retMsg.SYSTEM;
				err.Field = Convert.ToString(retMsg.FIELD);
				if (int.TryParse(retMsg.LOG_MSG_NO, out tempInt))
					err.LogNrInternal = tempInt;
				else
					err.SetLogNrInternalNull();
				err.LogNr = retMsg.LOG_NO;
				err.Message1 = retMsg.MESSAGE_V1;
				err.Message2 = retMsg.MESSAGE_V2;
				err.Message3 = retMsg.MESSAGE_V3;
				err.Message4 = retMsg.MESSAGE_V4;
				err.MessageClass = retMsg.ID;

				if (int.TryParse(retMsg.NUMBER, out tempInt))
					err.MessageNumber = tempInt;
				else
					err.SetMessageNumberNull();
				err.Message = retMsg.MESSAGE;
				err.Parameter = retMsg.PARAMETER;
				//if (int.TryParse(retMsg.ROW, out tempInt))
				//   err.Row = tempInt;
				//else
				//    err.SetRowNull();
				if (retMsg.ROW.HasValue)
					err.Row = retMsg.ROW.Value;

				if (!string.IsNullOrEmpty(retMsg.TYPE))
					err.Severity = retMsg.TYPE;

				errorTbl.AddPscdCallReturnMsgRow(err);
			}
			return errorTbl;
		}

		#endregion

	}
}
