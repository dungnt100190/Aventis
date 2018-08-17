using System;
using System.Collections.Generic;
using System.Text;
using KiSSSvc.SAP.Helpers;
using System.Threading;
using System.Data;
using KiSSSvc.Logging;
using KiSSSvc.DAL;
using KiSSSvc.SAP.PSCD.BLL;
using System.Web.Services.Protocols;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.WebServiceHelper;

using VgAnlegen = KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.VertragsgegenstandAnlegen;
using VgMutieren = KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.VertragsgegenstandMutieren;
using DTO = KiSSSvc.SAP.Helpers.DataObjects;
using KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl;


namespace KiSSSvc.SAP.PSCD.BudgetData
{
	public class VertragsgegenständeAsync
	{
		private const string wshPscdKuerzel = "WSH1";
		private const string albvPscdKuerzel = "ALBV";
		private const string kkbbPscdKuerzel = "KKBB";
		private const string uebhPscdKuerzel = "UEBH";
		private const string alimPscdKuerzel = "ALIM";
		private const string wshVetragsgegenstandName = "Wirtschaftliche Hilfe";
		private const string alimVetragsgegenstandName = "Alimente";
		private VgAnlegen.MI_BUDGET_CREA_VG_SOAP_OUTService svcVgAnlegen;
		//private VgMutieren.MI_BUDGET_CHG_VG_SOAP_OUTService svcVgMutieren;

		/// <summary>
		/// Constructor
		/// </summary>
		public VertragsgegenständeAsync()
		{
			svcVgAnlegen = WebServiceSource.GetVgAnlegenAsyncWS();
		}

		private void SubmitVetragsgegenstaende(KiSSDB.FaLeistungRow leistungRow, int faLeistungID, List<int> personsInvolved, List<VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE> vgAnlegenItems, int logKey, UserInfo user)
		{
			if (vgAnlegenItems.Count > 0)
			{
				VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE[] vgAnlegenItemsArray = vgAnlegenItems.ToArray();
				VgAnlegen.BAPI_TE_DPSOB_BP_ACC[] extAcc = new VgAnlegen.BAPI_TE_DPSOB_BP_ACC[] { };
				VgAnlegen.BAPI_TE_DPSOB[] ext = new VgAnlegen.BAPI_TE_DPSOB[] { };
				
				long transactionID = KeysBLL.GetBelegNr("TRANS");
				string transactionIDStr = SapHelper.GetTransactionID(transactionID);

				PscdCallLogEntry log = new PscdCallLogEntry("MI_BUDGET_CREA_VG_SOAP_OUT", svcVgAnlegen.Url, logKey, user);
				try
				{
					svcVgAnlegen.MI_BUDGET_CREA_VG_SOAP_OUT(
						vgAnlegenItemsArray,
						transactionIDStr,
						extAcc,
						ext);
					log.StopWatch();
				}
				catch (Exception ex)
				{
					Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
					log.ExceptionMsg = ex.Message;
					Exception ex2 = new Exception(string.Format("Fehler beim Verbinden vom KiSS-Server zu XI (beim Anlegen der Leistung mit ID {0}):{1}{2}", faLeistungID, ex.Message, WebServiceHelperMethods.GetNewLineString()), ex);
					throw ex2;
				}
				finally
				{
					log.WriteToDB();
				}
				// If we get one or more return message(s), something went wrong
				log.ThrowExceptionIfErrorOccured();
				// No errors
				try
				{
					// Register as 'sent to PSCD'
					PscdSentBLL.SavePscdSentLeistung(faLeistungID, leistungRow.FaLeistungTS);
					foreach (int baPersonID in personsInvolved)
						PscdSentBLL.SavePscdSentLeistungPerson(faLeistungID, baPersonID);
				}
				catch (Exception ex)
				{
					Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
					throw;
				}
			}
		}


		internal CreateObjectResult SubmitLeistungen(int[] faLeistungIDs, UserInfo user, ref string warningMsg)
		{
			KiSSDB.FaLeistungDataTable leistungenTable = FaLeistungBLL.GetLeistungenByIDs(faLeistungIDs);
			Log.Info(this.GetType(), string.Format("Sende {0} Leistungen", leistungenTable.Count));
			string exceptionMsg = "";
			Stammdaten stammdaten = new Stammdaten();
			int faLeistungID = -1;
			for (int i = 0; i < leistungenTable.Count; i++)
			{
				try
				{
					List<VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE> vgAnlegenItems = new List<VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE>();
					List<VgAnlegen.BAPI_TE_DPSOB> vgAnlegenInfoItems = new List<VgAnlegen.BAPI_TE_DPSOB>();
					KiSSDB.FaLeistungRow leistungRow = leistungenTable[i];
					string innerExceptionMessage = "";
					faLeistungID = leistungRow.FaLeistungID;

					// first submit the persons involved in this finanzplan
					List<int> personsInvolved = null;
					if (leistungRow.ModulID == 4)//Alim
						personsInvolved = FaLeistungBLL.GetPersonsOfAlimLeistung(faLeistungID);
					else if (leistungRow.ModulID == 3)//Wh
						personsInvolved = FaLeistungBLL.GetSupportedPersonsOfWhLeistung(faLeistungID);
					else
						throw new Exception(string.Format("Leistung {0} ist dem Modul {1} zugeordnet, für das keine Leistungen an PSCD übertragen werden", faLeistungID, leistungRow.ModulID));

					Log.Info(this.GetType(), string.Format("{0} Personen zu übertragen: {1}", personsInvolved.Count, personsInvolved.ToArray()));
					foreach (int baPersonID in personsInvolved)
					{
						try
						{
							stammdaten.CreateAndSubmitBusinessPartnerPerson(baPersonID, user, ref warningMsg);
						}
						catch (Exception ex)
						{
							innerExceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
							Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Failed to create Person", ex);
						}
					}
					if (!string.IsNullOrEmpty(innerExceptionMessage))
						throw new Exception(innerExceptionMessage);

					foreach (int baPersonID in personsInvolved)
					{
						if (!PscdSentBLL.HasLeistungPersonBeenSent(faLeistungID, baPersonID))
						{
							VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE vgAnlegenItem = new VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE();
							vgAnlegenItem.PSOBJECTTYPE = GetPsObjectTypeFromProzessCode(leistungRow.FaProzessCode);
							if (leistungRow.IsPscdVertragsgegenstandIDNull())
								FaLeistungBLL.UpdatePscdVgID(ref leistungRow, KeysBLL.GetBelegNr(alimPscdKuerzel));
							vgAnlegenItem.PSOBJECTKEYEXT = SapHelper.GetPsObjectNumber(leistungRow.PscdVertragsgegenstandID);

							vgAnlegenItem.PARTNER = SapHelper.GetBusinessPartnerNumber(baPersonID);
							vgAnlegenItem.CTRACCOUNTTYPE = SapHelper.EnumToCode(BU_CTRACCTYPE.Personen);
							vgAnlegenItem.CTRACCOUNT = SapHelper.GetContractAccountNumber(baPersonID);
							vgAnlegenItem.PSOBJECTDETAIL = new VgAnlegen.BAPI_CTRACPSOBJECT_DETAILI();
							vgAnlegenItem.PSOBJECTDETAIL.PSOBJECTTEXT = GetPsObjectTextFromProzessCode(leistungRow.FaProzessCode);
							vgAnlegenItem.PSOBJECTACCOUNT = new VgAnlegen.BAPI_CTRACPSOBJECT_ACCOUNTI();
							vgAnlegenItem.PSOBJECTACCOUNT.PSOBJECT_PAY_ACT = "X"; // fix value
							vgAnlegenItem.PSOBJECTACCOUNT.PSOBJECT_CORR_ACT = "X"; // fix value
							vgAnlegenItem.EXT_DPSOB = new VgAnlegen.BAPI_TE_DPSOB();
							vgAnlegenItem.EXT_DPSOB.PSOBJECTKEY = vgAnlegenItem.PSOBJECTKEYEXT;
							vgAnlegenItem.EXT_DPSOB._STZH_SOZ_FTRAE = SapHelper.GetBusinessPartnerNumber(leistungRow.BaPersonID);
							vgAnlegenItem.EXT_DPSOB._STZH_SOZ_FVERA = leistungRow.Fallverantwortlicher;
							vgAnlegenItems.Add(vgAnlegenItem);
						}
					}
					SubmitVetragsgegenstaende(leistungRow, faLeistungID, personsInvolved, vgAnlegenItems, leistungRow.FaLeistungID, user);
				}
				catch (Exception ex)
				{
					Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
					exceptionMsg += string.Format("Leistung mit FaLeistungID {0} konnte nicht in PSCD angelegt werden: {1}{2}", faLeistungID, ex.Message, WebServiceHelperMethods.GetNewLineString());
				}
			}
			if (!string.IsNullOrEmpty(exceptionMsg))
				throw new Exception(string.Format("Fehler beim Anlegen von Vertragsgegenständen:{0}{1}", WebServiceHelperMethods.GetNewLineString(), exceptionMsg));
			return CreateObjectResult.Success;
		}

		//internal CreateObjectResult SubmitWhLeistungen(int[] faLeistungIDs, UserInfo user, ref string warningMsg)
		//{
		//   KiSSDB.FaLeistungDataTable leistungenTable = FaLeistungBLL.GetLeistungenByIDs(faLeistungIDs);
		//   Log.Info(this.GetType(), string.Format("Sende {0} Wh-Leistungen", leistungenTable.Count));
		//   string exceptionMsg = "";
		//   Stammdaten stammdaten = new Stammdaten();
		//   int faLeistungID = -1;
		//   for (int i = 0; i < leistungenTable.Count; i++)
		//   {
		//      try
		//      {
		//         List<VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE> vgAnlegenItems = new List<VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE>();
		//         List<VgAnlegen.BAPI_TE_DPSOB> vgAnlegenInfoItems = new List<VgAnlegen.BAPI_TE_DPSOB>();
		//         KiSSDB.FaLeistungRow leistungRow = leistungenTable[i];
		//         string innerExceptionMessage = "";
		//         faLeistungID = leistungRow.FaLeistungID;
		//         // first submit the persons involved in this finanzplan
		//         List<int> personsInvolved = FaLeistungBLL.GetSupportedPersonsOfWhLeistung(faLeistungID);
		//         Log.Info(this.GetType(), string.Format("{0} Personen zu übertragen: {1}", personsInvolved.Count, personsInvolved.ToArray()));
		//         foreach (int baPersonID in personsInvolved)
		//         {
		//            try
		//            {
		//               stammdaten.CreateAndSubmitBusinessPartnerPerson(baPersonID, user, ref warningMsg);
		//            }
		//            catch (Exception ex)
		//            {
		//               innerExceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
		//               Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Failed to create Person", ex);
		//            }
		//         }
		//         if (!string.IsNullOrEmpty(innerExceptionMessage))
		//            throw new Exception(innerExceptionMessage);

		//         foreach (int baPersonID in personsInvolved)
		//         {
		//            if (!PscdSentBLL.HasLeistungPersonBeenSent(faLeistungID, baPersonID))
		//            {
		//               VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE vgAnlegenItem = new VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE();
		//               vgAnlegenItem.PSOBJECTTYPE = albvPscdKuerzel;
		//               if (leistungRow.IsPscdVertragsgegenstandIDNull())
		//                  FaLeistungBLL.UpdatePscdVgID(ref leistungRow, KeysBLL.GetBelegNr(alimPscdKuerzel));
		//               vgAnlegenItem.PSOBJECTKEYEXT = SapHelper.GetPsObjectNumber(leistungRow.PscdVertragsgegenstandID);

		//               vgAnlegenItem.PARTNER = SapHelper.GetBusinessPartnerNumber(baPersonID);
		//               vgAnlegenItem.CTRACCOUNTTYPE = SapHelper.EnumToCode(BU_CTRACCTYPE.Personen);
		//               vgAnlegenItem.CTRACCOUNT = SapHelper.GetContractAccountNumber(baPersonID);
		//               vgAnlegenItem.PSOBJECTDETAIL = new VgAnlegen.BAPI_CTRACPSOBJECT_DETAILI();
		//               vgAnlegenItem.PSOBJECTDETAIL.PSOBJECTTEXT = alimVetragsgegenstandName;
		//               vgAnlegenItem.PSOBJECTACCOUNT = new VgAnlegen.BAPI_CTRACPSOBJECT_ACCOUNTI();
		//               vgAnlegenItem.PSOBJECTACCOUNT.PSOBJECT_PAY_ACT = "X"; // fix value
		//               vgAnlegenItem.PSOBJECTACCOUNT.PSOBJECT_CORR_ACT = "X"; // fix value
		//               vgAnlegenItem.EXT_DPSOB = new VgAnlegen.BAPI_TE_DPSOB();
		//               vgAnlegenItem.EXT_DPSOB.PSOBJECTKEY = vgAnlegenItem.PSOBJECTKEYEXT;
		//               vgAnlegenItem.EXT_DPSOB._STZH_SOZ_FTRAE = SapHelper.GetBusinessPartnerNumber(leistungRow.BaPersonID);
		//               vgAnlegenItem.EXT_DPSOB._STZH_SOZ_FVERA = leistungRow.Fallverantwortlicher;
		//               vgAnlegenItems.Add(vgAnlegenItem);
		//            }
		//         }
		//         SubmitVetragsgegenstaende(leistungRow, faLeistungID, personsInvolved, vgAnlegenItems, leistungRow.FaLeistungID, user);
		//      }
		//      catch (Exception ex)
		//      {
		//         Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
		//         exceptionMsg += string.Format("ALIM-Leistung mit FaLeistungID {0} konnte nicht in PSCD angelegt werden: {1}{2}", faLeistungID, ex.Message, WebServiceHelperMethods.GetNewLineString());
		//      }
		//   }
		//   if (!string.IsNullOrEmpty(exceptionMsg))
		//      throw new Exception(string.Format("Fehler beim Anlegen von ALIM-Vertragsgegenständen:{0}{1}", WebServiceHelperMethods.GetNewLineString(), exceptionMsg));
		//   return CreateObjectResult.Success;
		//}

		#region Helper Method

		private string GetPsObjectTypeFromProzessCode(int faProzessCode)
		{
			if (faProzessCode >= 400 && faProzessCode < 500)
				return albvPscdKuerzel;
			else if (faProzessCode >= 300 && faProzessCode < 400)
				return wshPscdKuerzel;
			return null;
		}
		private string GetPsObjectTextFromProzessCode(int faProzessCode)
		{
			if (faProzessCode >= 400 && faProzessCode < 500)
				return alimVetragsgegenstandName;
			else if (faProzessCode >= 300 && faProzessCode < 400)
				return wshVetragsgegenstandName;
			return null;
		}

		#endregion

		#region Answer

		#region Process Response from PSCD

		//public void ProcessResponse(string TRANSACTIONID, DTO.BAPIRET2[] RETURN_MESSAGES, DTO.BAPI_TE_DPSOB_BP_ACC T_EXT_DPSOB_BP_ACC_OUT, DTO.BAPI_TE_DPSOB T_EXT_DPSOB_OUT)
		//{
		//   TransactionControlService.Instance.SetTransactionReturnedFromSap(TRANSACTIONID, true, null);
		//   int? businessPartner = TransactionControlService.Instance.GetObjectIDFromCallID(TRANSACTIONID);
		//   if (!businessPartner.HasValue)
		//      throw new Exception(string.Format("Für die Transaktion mit ID {0} ist keine ID hinterlegt", TRANSACTIONID));

		//   if (RETURN_MESSAGES.Length > 0)
		//   {
		//      PscdCallLogEntry log = new PscdCallLogEntry("STZH_KISS_BUDGET_CHG_OUT", svcBpMutieren.Url, -1, null);
		//      log.ErrorMsgs = ParseReturnMessages(RETURN_MESSAGES);
		//      string exceptionMsg = "";
		//      foreach (DTO.BAPIRET2 message in RETURN_MESSAGES)
		//      {
		//         exceptionMsg += message.MESSAGE + WebServiceHelperMethods.GetNewLineString();
		//         Log.Info(svcBpMutieren.GetType(), string.Format("ZReturnMessage: '{0}'", message.MESSAGE));
		//      }
		//      throw new Exception(exceptionMsg);
		//   }
		//   else
		//   {
		//      try
		//      {
		//         int receivedBpId = businessPartner.Value;
		//         if (receivedBpId < SapHelper.FirstInstitutionID)
		//         {
		//            // Register Person as 'sent to PSCD'
		//            KiSSDB.BaPersonRow person = BaPersonBLL.GetPerson(receivedBpId);
		//            PscdSentBLL.SavePscdSentPerson(receivedBpId, person.BaPersonTS);
		//         }
		//         else
		//         {
		//            // Register Institution as 'sent to PSCD'
		//            KiSSDB.BaInstitutionRow institution = BaInstitutionBLL.GetInstitution(receivedBpId);
		//            PscdSentBLL.SavePscdSentInstitution(receivedBpId, institution.BaInstitutionTS);
		//         }
		//         // Register Address as 'sent to PSCD'
		//         KiSSDB.BaAdresseRow address = BaAdresseBLL.GetCurrentWMAOfPerson(receivedBpId);
		//         PscdSentBLL.SavePscdSentAdresse(address.BaAdresseID, address.BaAdresseTS);
		//         // Register Zahlweg as 'sent to PSCD'
		//         KiSSDB.BaZahlungswegDataTable zahlwegTable = BaZahlungswegBLL.GetZahlungswegeOfPerson(receivedBpId);

		//         foreach (DTO.BAPIBUS1006_BANKDETAILS receivedZahlweg in STEP3_T_BANKDETAILDATA)
		//         {
		//            try
		//            {
		//               int externalID = int.Parse(receivedZahlweg.EXTERNALBANKID);
		//               int sapID = int.Parse(receivedZahlweg.BANKDETAILID);
		//               KiSSDB.BaZahlungswegRow kissZahlweg = zahlwegTable.FindByBaZahlungswegID(externalID);
		//               if (kissZahlweg != null)
		//                  PscdSentBLL.SavePscdSentZahlungsweg(kissZahlweg.BaZahlungswegID, kissZahlweg.BaZahlungswegTS, sapID);
		//            }
		//            catch (Exception ex)
		//            {
		//               Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
		//            }
		//         }
		//      }
		//      catch (Exception ex)
		//      {
		//         Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
		//      }
		//   }
		//}

		private KiSSDB.PscdCallReturnMsgDataTable ParseReturnMessages(DTO.BAPIRET2[] returnMessages)
		{
			KiSSDB.PscdCallReturnMsgDataTable errorTbl = new KiSSDB.PscdCallReturnMsgDataTable();
			int tempInt;
			foreach (DTO.BAPIRET2 retMsg in returnMessages)
			{
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
				if (retMsg.ROW.HasValue)
					err.Row = retMsg.ROW.Value;
				else
					err.SetRowNull();

				if (!string.IsNullOrEmpty(retMsg.TYPE))
					err.Severity = retMsg.TYPE;

				errorTbl.AddPscdCallReturnMsgRow(err);
			}
			return errorTbl;
		}

		#endregion

		#endregion
	}
}
