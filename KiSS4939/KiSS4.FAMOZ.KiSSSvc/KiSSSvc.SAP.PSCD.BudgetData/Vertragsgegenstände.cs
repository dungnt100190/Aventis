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
using VgAnlegen = KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.VgAnlegen;
using VgMutieren = KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.VgMutieren;
//using KiSSSvc.Common;


namespace KiSSSvc.SAP.PSCD.BudgetData
{
	public class Vertragsgegenstände
	{
		private const string wshPscdKuerzel = "WSH1";
		private const string albvPscdKuerzel = "ALBV";
		private const string inkwPscdKuerzel = "INKW";
		private const string wshVetragsgegenstandName = "Wirtschaftliche Hilfe";
		private const string alimVetragsgegenstandName = "Alimente";
		private const string inkwVetragsgegenstandName = "W-Inkasso";
		private VgAnlegen.MI_BUDGET_DATA001_VGService svcVgAnlegen;

		/// <summary>
		/// Constructor
		/// </summary>
		public Vertragsgegenstände()
		{
			svcVgAnlegen = WebServiceSource.GetVgAnlegenWS();
		}

		private void SubmitVetragsgegenstaende(KiSSDB.FaLeistungRow leistungRow, int faLeistungID, List<int> personsInvolved, List<VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE> vgAnlegenItems, int logKey, UserInfo user)
		{
			if (vgAnlegenItems.Count > 0)
			{
				VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE[] vgAnlegenItemsArray = vgAnlegenItems.ToArray();
				VgAnlegen.BAPIRET2[] returnMessages = new VgAnlegen.BAPIRET2[] { };
				VgAnlegen.BAPI_TE_DPSOB_BP_ACC[] extAcc = new VgAnlegen.BAPI_TE_DPSOB_BP_ACC[] { };
				VgAnlegen.BAPI_TE_DPSOB[] ext = new VgAnlegen.BAPI_TE_DPSOB[] { };
				PscdCallLogEntry log = new PscdCallLogEntry("MI_BUDGET_DATA001_VG", svcVgAnlegen.Url, logKey, user);
				bool exception;
				try
				{
					svcVgAnlegen.MI_BUDGET_DATA001_VG(
						vgAnlegenItemsArray,
						ref returnMessages,
						ref extAcc,
						ref ext);
					log.StopWatch();
					log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
				}
				catch (Exception ex)
				{
					Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
					log.ExceptionMsg = ex.Message;
					Exception ex2 = new Exception(string.Format("Fehler beim Anlegen der Leistung mit ID {0}:{1}{2}", faLeistungID, ex.Message, WebServiceHelperMethods.GetNewLineString()), ex);
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
            bool leistungUebertragen = false;

			for (int i = 0; i < leistungenTable.Count; i++)
			{
                leistungUebertragen = false;

					KiSSDB.FaLeistungRow leistungRow = leistungenTable[i];
				try
				{
					List<VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE> vgAnlegenItems = new List<VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE>();
					List<VgAnlegen.BAPI_TE_DPSOB> vgAnlegenInfoItems = new List<VgAnlegen.BAPI_TE_DPSOB>();
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

                    string personIDs = "";
                    int personenUebertragen = 0;
					foreach (int baPersonID in personsInvolved)
					{
						try
						{
							stammdaten.CreateAndSubmitBusinessPartnerPerson(baPersonID, user, ref warningMsg);
                            personIDs = (personIDs == "") ? baPersonID.ToString() : personIDs + "," + baPersonID.ToString();
                            personenUebertragen++;
						}
						catch (Exception ex)
						{
							innerExceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
                            Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Person " + baPersonID + " konnte nicht übertragen werden.", ex);
						}
					}

                    Log.Info(this.GetType(), string.Format("{0} von {1} Personen übertragen: {2}", personenUebertragen, personsInvolved.Count, personIDs));

					if (!string.IsNullOrEmpty(innerExceptionMessage))
						throw new Exception(innerExceptionMessage);

					foreach (int baPersonID in personsInvolved)
					{
						if (!PscdSentBLL.HasLeistungPersonBeenSent(faLeistungID, baPersonID))
						{
							VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE vgAnlegenItem = new VgAnlegen.ZSTEP5_CTRACPSOBJECT_CREATE();
							string kuerzel = GetPsObjectTypeFromProzessCode(leistungRow.FaProzessCode);
							vgAnlegenItem.PSOBJECTTYPE = kuerzel;
							if (leistungRow.IsPscdVertragsgegenstandIDNull())
								FaLeistungBLL.UpdatePscdVgID(ref leistungRow, KeysBLL.GetBelegNr(kuerzel));
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
							vgAnlegenItem.EXT_DPSOB._STZH_SOZ_FVERA = SapHelper.ToUpperCase(leistungRow.Fallverantwortlicher);
                            vgAnlegenItem.EXT_DPSOB._STZH_SOZ_FALL = leistungRow.FaFallID.ToString();
							vgAnlegenItems.Add(vgAnlegenItem);
						}
					}
					SubmitVetragsgegenstaende(leistungRow, faLeistungID, personsInvolved, vgAnlegenItems, leistungRow.FaLeistungID, user);
                    leistungUebertragen = true;
				}
				catch (Exception ex)
				{
					Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
					exceptionMsg += string.Format("Leistung mit FaLeistungID {0} konnte nicht in PSCD angelegt werden: {1}{2}", faLeistungID, ex.Message, WebServiceHelperMethods.GetNewLineString());
				}

                try
                {
                    if (leistungUebertragen && !leistungRow.IsPscdVertragsgegenstandIDNull() && PscdSentBLL.HasLeistungBeenChanged(leistungRow.FaLeistungID, leistungRow.FaLeistungTSCast))
                    {
                        (new VertragsgegenstaendeMutieren()).ModifyVetragsgegenstand(leistungRow, user);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Fehler beim Mutieren des Vertragsgegenstandes (FaLeistungID={0}):{1}{2}",
                                                      leistungRow.FaLeistungID, WebServiceHelperMethods.GetNewLineString(), ex));
                }
			}

			if (!string.IsNullOrEmpty(exceptionMsg))
                throw new Exception(string.Format("Fehler beim Anlegen von Vertragsgegenständen (FaLeistungID={0}):{1}{2}", faLeistungID, WebServiceHelperMethods.GetNewLineString(), exceptionMsg));
			return CreateObjectResult.Success;
		}

		#region Helper Method

		private static string GetPsObjectTypeFromProzessCode(int faProzessCode)
		{
			if (faProzessCode >= 400 && faProzessCode < 500)
				return albvPscdKuerzel;
			else if (faProzessCode == 301 || faProzessCode == 302 || faProzessCode == 304)
				return inkwPscdKuerzel;
			else if (faProzessCode >= 300 && faProzessCode < 400)
				return wshPscdKuerzel;
			return null;
		}
		private static string GetPsObjectTextFromProzessCode(int faProzessCode)
		{
			if (faProzessCode >= 400 && faProzessCode < 500)
				return alimVetragsgegenstandName;
			else if (faProzessCode == 301 || faProzessCode == 302 || faProzessCode == 304)
				return inkwVetragsgegenstandName;
			else if (faProzessCode >= 300 && faProzessCode < 400)
				return wshVetragsgegenstandName;
			return null;
		}

		#endregion

		#region Answer

		private KiSSDB.PscdCallReturnMsgDataTable ParseReturnMessages(VgAnlegen.BAPIRET2[] returnMessages, out bool exception)
		{
			KiSSDB.PscdCallReturnMsgDataTable errorTbl = new KiSSDB.PscdCallReturnMsgDataTable();
			int tempInt;
			exception = false;
			foreach (VgAnlegen.BAPIRET2 retMsg in returnMessages)
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
