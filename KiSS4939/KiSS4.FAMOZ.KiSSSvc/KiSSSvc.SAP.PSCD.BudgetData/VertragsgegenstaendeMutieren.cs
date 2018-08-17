using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.SAP.Helpers;
using System.Threading;
using System.Data;
using KiSSSvc.Logging;
using KiSSSvc.DAL;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.VgMutieren;


namespace KiSSSvc.SAP.PSCD.BudgetData
{
	public class VertragsgegenstaendeMutieren
	{
		private const string wshPscdKuerzel = "WSH1";
		private const string albvPscdKuerzel = "ALBV";
		private const string inkwPscdKuerzel = "INKW";
		private const string wshVetragsgegenstandName = "Wirtschaftliche Hilfe";
		private const string alimVetragsgegenstandName = "Alimente";
		private const string inkwVetragsgegenstandName = "W-Inkasso";
		private MI_BUDGET_DATA002_VGService svcVgMutieren;

		/// <summary>
		/// Constructor
		/// </summary>
		public VertragsgegenstaendeMutieren()
		{
			svcVgMutieren = WebServiceSource.GetVgMutierenWS();
		}

		public void ModifyVetragsgegenstand(KiSSDB.FaLeistungRow leistungRow, UserInfo user)
		{
			ZSTEP5_CTRACPSOBJECT_CHANGE changeItem = new ZSTEP5_CTRACPSOBJECT_CHANGE();
			changeItem.PSOBJECTKEY = SapHelper.GetPsObjectNumber(leistungRow.PscdVertragsgegenstandID);
			changeItem.PSOBJECTKEYEXT = SapHelper.GetPsObjectNumber(leistungRow.PscdVertragsgegenstandID);

			ZSTEP5_CTRACPSOBJECT_CHANGE[] vgAnlegenItemsArray = new ZSTEP5_CTRACPSOBJECT_CHANGE[] { changeItem };
			BAPIRET2[] returnMessages = new BAPIRET2[] { };
			BAPI_TE_DPSOB_BP_ACC[] extAcc = new BAPI_TE_DPSOB_BP_ACC[] { };
			BAPI_TE_DPSOB extItem = new BAPI_TE_DPSOB();
			extItem.PSOBJECTKEY = SapHelper.GetPsObjectNumber(leistungRow.PscdVertragsgegenstandID);
			extItem._STZH_SOZ_FTRAE = SapHelper.GetBusinessPartnerNumber(leistungRow.BaPersonID);
			extItem._STZH_SOZ_FVERA = SapHelper.ToUpperCase(leistungRow.Fallverantwortlicher);
      extItem._STZH_SOZ_FALL = leistungRow.FaFallID.ToString();
			BAPI_TE_DPSOB[] ext = new BAPI_TE_DPSOB[] { extItem };
			PscdCallLogEntry log = new PscdCallLogEntry("MI_BUDGET_DATA002_VG", svcVgMutieren.Url, leistungRow.FaLeistungID, user);
			try
			{
				bool exception;
				svcVgMutieren.MI_BUDGET_DATA002_VG(
					vgAnlegenItemsArray,
					ref returnMessages,
					ref extAcc,
					ref ext);
				log.StopWatch();
				log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
				// If we get one or more return message(s), something went wrong
				log.ThrowExceptionIfErrorOccured();
			}
			catch (Exception ex)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
				log.ExceptionMsg = ex.Message;
				Exception ex2 = new Exception(string.Format("Fehler beim Mutieren der Leistung mit ID {0}:{1}{2}", leistungRow.FaLeistungID, ex.Message, WebServiceHelperMethods.GetNewLineString()), ex);
				throw ex2;
			}
			finally
			{
				log.WriteToDB();
			}
			// No errors
			try
			{
				// Register as 'sent to PSCD'
				PscdSentBLL.SavePscdSentLeistung(leistungRow.FaLeistungID, leistungRow.FaLeistungTS);
			}
			catch (Exception ex)
			{
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
				throw;
			}
		}

		#region Answer

		private static KiSSDB.PscdCallReturnMsgDataTable ParseReturnMessages(BAPIRET2[] returnMessages, out bool exception)
		{
			KiSSDB.PscdCallReturnMsgDataTable errorTbl = new KiSSDB.PscdCallReturnMsgDataTable();
			exception = false;
			foreach (BAPIRET2 retMsg in returnMessages)
			{
				int tempInt;
				KiSSDB.PscdCallReturnMsgRow err = errorTbl.NewPscdCallReturnMsgRow();
				err.CausingSystem = retMsg.SYSTEM;
				err.Field = retMsg.FIELD;
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
				if (int.TryParse(retMsg.ROW, out tempInt))
					err.Row = tempInt;
				else
					err.SetRowNull();

				exception |= retMsg.TYPE == "E";
				if (!string.IsNullOrEmpty(retMsg.TYPE))
					err.Severity = retMsg.TYPE;

				errorTbl.AddPscdCallReturnMsgRow(err);
			}
			return errorTbl;
		}

		#endregion
	}
}
