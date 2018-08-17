using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using KiSSSvc.Logging;
using KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl;
using KiSSSvc.SAP.PSCD.BudgetData;
using KiSSSvc.SAP.PSCD.Notification.Utils;
using KiSSSvc.SAP.Helpers.DataObjects;

namespace KiSSSvc.SAP.PSCD.Notification
{
	/// <summary>
	/// Summary description for SAPSvc
	/// </summary>
	[WebService(Namespace = "http://www.born.ch/KiSS/FAMOZ/PSCD/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	public class NotifyTransactionResult : System.Web.Services.WebService
	{


        //#region Mahnlauf

        //[WebMethod]
        //public void MI_KISS_ANSTOSS_MAHN_SOAP_OUT(string TRANSACTIONID, BAPIRET2[] RETURN_MESSAGES)
        //{
        //    try
        //    {
        //        Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Processing response from Pscd for TransactionId: '{0}'", TRANSACTIONID));
        //        MahnlaufStartenAsync svc = new MahnlaufStartenAsync();
        //        svc.Process_MI_KISS_ANSTOSS_MAHN_SOAP_OUT(TRANSACTIONID, RETURN_MESSAGES);
                
        //        Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Response from Pscd for TransactionId: '{0}' Processed succesfully!", TRANSACTIONID));
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), e);
        //    }
        //}
        //#endregion

        #region Geschäftspartner

        /// <summary>
		/// Answer from XI for Service 'Create BP'
		/// </summary>
		/// <param name="STEP1_BUSINESSPARTNER">The STE P1_ BUSINESSPARTNER.</param>
		/// <param name="STEP4_CONTRACTACCOUNT">The STE P4_ CONTRACTACCOUNT.</param>
		/// <param name="TRANSACTIONID">The TRANSACTIONID.</param>
		/// <param name="RETURN_MESSAGES">The RETUR n_ MESSAGES.</param>
		/// <param name="STEP2_T_BANKDETAILDATA">The STE P2_ t_ BANKDETAILDATA.</param>
		/// <param name="STEP3_T_IBAN">The STE P3_ t_ IBAN.</param>
		/// <returns></returns>
		[WebMethod]
		public void STZH_KISS_BUDGET_CREA_OUT(string STEP1_BUSINESSPARTNER, string STEP4_CONTRACTACCOUNT, string TRANSACTIONID, BAPIRET2[] RETURN_MESSAGES, BAPIBUS1006_BANKDETAILS[] STEP2_T_BANKDETAILDATA, ZSTEP3_IBAN[] STEP3_T_IBAN)
		{
			try
			{
				Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Processing response from Pscd for TransactionId: '{0}' and Businesspartner: {1}", TRANSACTIONID, STEP1_BUSINESSPARTNER));
				StammdatenAsync svc = new StammdatenAsync();

				svc.Process_STZH_KISS_BUDGET_CREA_OUT(STEP1_BUSINESSPARTNER, STEP4_CONTRACTACCOUNT, TRANSACTIONID, RETURN_MESSAGES, STEP2_T_BANKDETAILDATA, STEP3_T_IBAN);

				Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Response from Pscd for TransactionId: '{0}' and Businesspartner: {1} Processed succesfully!", TRANSACTIONID, STEP1_BUSINESSPARTNER));
			}
			catch (Exception e)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), e);
			}
		}

		/// <summary>
		/// Answer from XI for Service 'Change BP'
		/// </summary>
		/// <param name="STEP1_BUSINESSPARTNER">The STE P1_ BUSINESSPARTNER.</param>
		/// <param name="STEP4_CONTRACTACCOUNT">The STE P4_ CONTRACTACCOUNT.</param>
		/// <param name="TRANSACTIONID">The TRANSACTIONID.</param>
		/// <param name="RETURN_MESSAGES">The RETUR n_ MESSAGES.</param>
		/// <param name="STEP2_T_BANKDETAILDATA">The STE P2_ t_ BANKDETAILDATA.</param>
		/// <param name="STEP3_T_IBAN">The STE P3_ t_ IBAN.</param>
		/// <returns></returns>
		[WebMethod]
		public void STZH_KISS_BUDGET_CHG_OUT(string TRANSACTIONID, BAPIRET2[] RETURN_MESSAGES, BAPIBUS1006_BANKDETAILS[] STEP3_T_BANKDETAILDATA, ZSTEP3_IBAN_CHANGE[] STEP3_T_IBAN, BAPIFKKVKLOCKSI1[] STEP4_T_CTRACLOCKDETAIL, BAPIFKKVKPI1[] STEP4_T_CTRACPARTNERDETAIL)
		{
			try
			{
				Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Processing response from Pscd for TransactionId: '{0}' ", TRANSACTIONID));
				StammdatenMutierenAsync svc = new StammdatenMutierenAsync();

				svc.Process_STZH_KISS_BUDGET_CHG_OUT(TRANSACTIONID, RETURN_MESSAGES, STEP3_T_BANKDETAILDATA, STEP3_T_IBAN, STEP4_T_CTRACLOCKDETAIL, STEP4_T_CTRACPARTNERDETAIL);

				Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Response from Pscd for TransactionId: '{0}' Processed succesfully!", TRANSACTIONID));
			}
			catch (Exception e)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), e);
			}
		}

		#endregion

		#region Vetragsgegenstand

		[WebMethod]
		public void STZH_KISS_BUDGET_CREA_VG_OUT(string TRANSACTIONID, BAPIRET2[] RETURN_MESSAGES, BAPI_TE_DPSOB_BP_ACC T_EXT_DPSOB_BP_ACC_OUT, BAPI_TE_DPSOB T_EXT_DPSOB_OUT)
		{
			//try
			//{
			//   Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Processing response from Pscd for TransactionId: '{0}'", TRANSACTIONID));
			//   VertragsgegenständeAsync svc = new VertragsgegenständeAsync();

			//   svc.ProcessResponse(TRANSACTIONID, RETURN_MESSAGES, T_EXT_DPSOB_BP_ACC_OUT, T_EXT_DPSOB_OUT);

			//   Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Response from Pscd for TransactionId: '{0}' and Businesspartner: {1} Processed succesfully!", TRANSACTIONID, STEP1_BUSINESSPARTNER));
			//}
			//catch (Exception e)
			//{
			//   Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), e);
			//}
		}

		[WebMethod]
		public void STZH_KISS_BUDGET_CHG_VG_OUT(string TRANSACTIONID, BAPIRET2[] RETURN_MESSAGES, BAPI_TE_DPSOB_BP_ACC T_EXT_DPSOB_BP_ACC_OUT, BAPI_TE_DPSOB T_EXT_DPSOB_OUT)
		{
		}

		#endregion

		#region Buchungsstoff

		/// <summary>
		/// Answer from XI for Service 'Create Documents'
		/// </summary>
		/// <param name="TRANSACTIONID">The TRANSACTIONID.</param>
		/// <param name="item">The item.</param>
		[WebMethod]
		public void STZH_KISS_BUCHSTOFF_CREA_OUT(string transactionID, NotificationBelegeObjects.T_DOCUMENTS[] items)
		{
			BuchungResponseObjectPreprocessor preprocessor = new BuchungResponseObjectPreprocessor();
			try
			{
				Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Processing response from Pscd for TransactionId: '{0}'. Count: {1}", transactionID, items == null ? 0 : items.Length));

				preprocessor.ProcessResponse(transactionID, items);

				Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Response from Pscd for TransactionId: '{0}' processed succesfully!", transactionID));
				TransactionControlService.Instance.SetTransactionReturnedFromSap(transactionID, true, null);
			}
			catch (Exception e)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), e);
				TransactionControlService.Instance.SetTransactionReturnedFromSap(transactionID, false, e.Message);
			}
		}

		[WebMethod]
		public void STZH_KISS_BUCHSTOFF_CHG_OUT(string transactionID, BAPIRET2 RETURN_MESSAGES)
		{
		}

		[WebMethod]
		public void STZH_KISS_BUCHSTOFF_STO_OUT(string transactionID, BAPIRET2 RETURN_MESSAGES, string[] REV_DOCUMENTNUMBER)
		{
		}

		#endregion
	}
}
