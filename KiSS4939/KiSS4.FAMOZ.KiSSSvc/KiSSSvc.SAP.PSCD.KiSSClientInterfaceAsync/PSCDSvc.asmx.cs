using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.MahnlaufStarten;
using KiSSSvc.SAP.PSCD.BudgetData;
using KiSSSvc.Logging;
using KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl;
using DTO = KiSSSvc.SAP.Helpers.DataObjects;


namespace KiSSSvc.SAP.PSCD.KiSSClientInterfaceAsync
{
	/// <summary>
	/// Summary description for PSCDSvc
	/// </summary>
	[WebService(Namespace = "http://www.born.ch/KiSS/FAMOZ/PSCD/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	public class PSCDSvc : System.Web.Services.WebService
	{
        #region Mahnlauf

        [WebMethod]
        public ReturnMsgAsync MahnlaufStarten(string dbName, int userIDSender, string userWinLogonName, DTO.MahnungBeleg[] mahnungBelege, DateTime austellungsDatum, DateTime zahlungBeruecksichtigt)
        {
            try
            {
                WebServiceHelperMethods.CheckDBName(dbName);
                MahnlaufStartenAsync svc = new MahnlaufStartenAsync();
                return svc.MahnlaufStarten(mahnungBelege, austellungsDatum, zahlungBeruecksichtigt, new UserInfo(userIDSender, userWinLogonName));
            }
            catch (Exception ex)
            {
                ReturnMsgAsync msg = ReturnMsgAsync.Exception(ex.Message);
                msg.TransactionStatus = TransactionStatus.error;
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                return msg;
            }
        }
        #endregion

        #region Stammdaten

        #region Create

        [WebMethod]
		public ReturnMsgAsync CreateAndSubmitBusinessPartnerPersonData(string dbName, int userIDSender, string userWinLogonName, int baPersonID)
		{
			try
			{
				WebServiceHelperMethods.CheckDBName(dbName);
				StammdatenAsync svc = new StammdatenAsync();
				return svc.CreateAndSubmitBusinessPartnerPerson(baPersonID, new UserInfo(userIDSender, userWinLogonName));
			}
			catch (Exception ex)
			{
				ReturnMsgAsync msg = ReturnMsgAsync.Exception(ex.Message);
				msg.TransactionStatus = TransactionStatus.error;
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
				return msg;
			}
		}

		[WebMethod]
		public ReturnMsg CreateAndSubmitBusinessPartnerInstitutionData(string dbName, int userIDSender, string userWinLogonName, int baInstitutionID)
		{
			Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().GetType(), String.Format("Incoming Create BPP Request for User:  '{0}', Database: '{1}' BPInstitutionId: '{2}'", userIDSender, dbName, baInstitutionID));

			try
			{
				WebServiceHelperMethods.CheckDBName(dbName);
				StammdatenAsync svc = new StammdatenAsync();
				return svc.CreateAndSubmitBusinessPartnerInstitution(baInstitutionID, new UserInfo(userIDSender, userWinLogonName));
			}
			catch (Exception ex)
			{
				ReturnMsgAsync msg = ReturnMsgAsync.Exception(ex.Message);
				msg.TransactionStatus = TransactionStatus.error;
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
				return msg;
			}
		}

		#endregion

		#endregion

		#region Wh Buchungsstoff

		[WebMethod]
		public ReturnMsg SubmitWhBelegeByIDs(string dbName, int userIDSender, string userWinLogonName, int[] kbBuchungIDs, int[] kbBuchungBruttoIDs)
		{
			ReturnMsg msg = new ReturnMsg();
			try
			{
				WebServiceHelperMethods.CheckDBName(dbName);
				BuchungsstoffAsync svc = new BuchungsstoffAsync();
				string warningMsg = "";
				//msg.Result = svc.SubmitWhBelegeByKbBuchungIDs(kbBuchungIDs, kbBuchungBruttoIDs, new UserInfo(userIDSender, userWinLogonName), ref warningMsg);
				if (!string.IsNullOrEmpty(warningMsg))
					msg.WarningMessage = warningMsg;
			}
			catch (Exception ex)
			{
				msg.Result = CreateObjectResult.ExceptionOccured;
				msg.ExceptionMessage = ex.Message;
				Logging.Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
			}
			return msg;
		}

		#endregion

		#region Alim Buchungsstoff

		#endregion

		#region Kg Buchungsstoff

        private const string CALL_ID_SUBMIT_KG_BUDGET_DATA = "SUKGBD_";

		[WebMethod]
		public ReturnMsgAsync SubmitKgBelege(string dbName, int userIDSender, string userWinLogonName, int[] kgBuchungIDs)
		{
			Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().GetType(), String.Format("Incoming Submit KgBelege Request for User:  '{0}', Database: '{1}'", userIDSender, dbName));

			String callId = String.Concat(CALL_ID_SUBMIT_KG_BUDGET_DATA, userWinLogonName);
			ReturnMsgAsync msg = null;

			try
			{
				msg = TransactionControlService.Instance.GetReturnMsgForCallId(callId);
			}
			catch (Exception ex)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
			}

			if (msg == null)
			{
				try
				{
					WebServiceHelperMethods.CheckDBName(dbName);
					BuchungsstoffAsync svc = new BuchungsstoffAsync();
					string warningMsg = "";
					//msg = svc.SubmitKgBelege(kgBuchungIDs, new UserInfo(userIDSender, userWinLogonName), ref warningMsg);
					msg.CallId = callId;
					if (!string.IsNullOrEmpty(warningMsg))
						msg.WarningMessage = warningMsg;
					TransactionControlService.Instance.CreateNewTransaction(msg);
				}
				catch (Exception ex)
				{
					msg = ReturnMsgAsync.Exception(ex.Message);
					msg.TransactionStatus = TransactionStatus.error;
				}
			}
			return msg;
		}


		#endregion

		#region Check Transaction Processed by PSCD

		/// <summary>
		/// Checks the transaction processed by ps CD.
		/// </summary>
		/// <param name="dbName">Name of the db.</param>
		/// <param name="userIDSender">The user ID sender.</param>
		/// <param name="transactionId">The transaction id.</param>
		/// <returns></returns>
		[WebMethod]
		public ReturnMsgAsync CheckTransactionProcessedByPsCD(string dbName, int userIDSender, string userWinLogonName, string transactionId)
		{
			Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Processing Reques for Check Transactionid Executed. Transactionid: '{0}' UserId: '{1}' Database: '{2}' ", transactionId, userIDSender, dbName));

			ReturnMsgAsync retMsg = TransactionControlService.Instance.GetTransactionStatus(transactionId);

			if (retMsg == null)
			{
				retMsg = ReturnMsgAsync.Exception(string.Format("Transaction Id auf Datenbank nicht gefunden: '{0}'", transactionId));
				retMsg.TransactionStatus = TransactionStatus.error;
			}

			return retMsg;
		}


		#endregion
	}
}
