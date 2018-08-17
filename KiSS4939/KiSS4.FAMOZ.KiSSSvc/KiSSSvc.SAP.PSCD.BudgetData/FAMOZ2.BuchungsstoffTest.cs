using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Services.Protocols;
using KiSSSvc.DAL;
using KiSSSvc.DAL.TransactionalTableAdapters;
using KiSSSvc.Logging;
using KiSSSvc.SAP.Helpers;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.FAMOZ2Test;

namespace KiSSSvc.SAP.PSCD.BudgetData.FAMOZ
{
    public class BuchungsstoffTest
    {
        private MI_SD01_CREATE_WSService svcBuchungsstoff;

        public BuchungsstoffTest()
        {
            svcBuchungsstoff = WebServiceSource.GetFAMOZ2TestWS();
        }

        #region Kg

        public CreateObjectResult SubmitKgBeleg(int kgBuchungID, UserInfo user, ref string warningMsg, bool withTimeout)
        {
            bool success = true;
            string exceptionMessage = "";
            KiSSDB.KgBuchungRow belegRow = KgBuchungBLL.GetKgBuchungByID(kgBuchungID);
            try
            {
                success &= SubmitKgBeleg(belegRow, user, ref exceptionMessage, ref warningMsg, withTimeout);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                exceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
            }
            if (!string.IsNullOrEmpty(exceptionMessage))
                throw new Exception(exceptionMessage);
            return CreateObjectResult.Success;
        }

        public CreateObjectResult SubmitKgBelege(int[] kgBudgetIDs, UserInfo user, ref string warningMsg, bool withTimeout)
        {
            KiSSDB.KgBuchungDataTable buchungenTable = KgBuchungBLL.GetKgBuchungByIDs(kgBudgetIDs);
            return this.SubmitKgBelege(buchungenTable, user, ref warningMsg, withTimeout);
        }

        public CreateObjectResult SubmitKgBelege(int anzahlBelege, UserInfo user, ref string warningMsg, bool withTimeout)
        {
            KiSSDB.KgBuchungDataTable buchungenTable = KgBuchungBLL.GetKgBuchungTopN(anzahlBelege);
            return this.SubmitKgBelege(buchungenTable, user, ref warningMsg, withTimeout);
        }

        private string GetKgZahlungswegInfo(KiSSDB.KgBuchungRow belegRow)
        {
            if (!belegRow.IsKgAuszahlungsArtCodeNull())
            {
                if (belegRow.KgAuszahlungsArtCode == 103) // cash
                    return "C";
                else if (belegRow.KgAuszahlungsArtCode == 101) // e-banking
                    return SapHelper.LookupEinzahlungsscheinCode(belegRow["EinzahlungsscheinCode"]);
            }
            return null;
        }

        private void RegisterBelegError(KiSSDB.KgBuchungRow belegRow, string errorMsg, ref string warningMessage)
        {
            belegRow.KgBuchungStatusCode = 5; // Zahlauftrag fehlerhaft
            belegRow.PscdFehlermeldung = SapHelper.TruncateFehlermeldung(errorMsg);
            warningMessage += string.Format("Beleg {0}: {1}{2}", belegRow.KgBuchungID, errorMsg, WebServiceHelperMethods.GetNewLineString());
            KgBuchungBLL.Update(belegRow);
        }

        private void RegisterBelegError(KiSSDB.KbBuchungRow beleg, string errorMsg, ref string warningMessage)
        {
            try
            {
                // Fehlermeldung auf Beleg schreiben
                beleg.PscdFehlermeldung = SapHelper.TruncateFehlermeldung(errorMsg);
                beleg.KbBuchungStatusCode = 5; //Zahlauftrag fehlerhaft
                KbBuchungBLL.Update(beleg);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
            }
        }

        private bool SubmitKgBeleg(KiSSDB.KgBuchungRow belegRow, UserInfo user, ref string exceptionMessage, ref string warningMessage, bool withTimeout)
        {
            bool success = true;
            if (belegRow.IsKgBuchungStatusCodeNull() || (belegRow.KgBuchungStatusCode != 2 && belegRow.KgBuchungStatusCode != 4 && belegRow.KgBuchungStatusCode != 5))
                // Buchung is not ready to be transferred
                return true;

            //string belegart = "AK"; // VK-Belege

            //using (BelegNr belegNumber = new BelegNr(KeysBLL.GetBelegNr(belegart)))
            {
                _STZH_SOZ_CD_F2_BAPI_PAYMENT auszahlDaten = new _STZH_SOZ_CD_F2_BAPI_PAYMENT();
                _STZH_SOZ_CD_F2_BAPIDFKKOP[] positions = null;
                BAPIRET2[] returnMessages = new BAPIRET2[] { };
                BAPIRET2 returnMessage = new BAPIRET2();
                _STZH_SOZ_CD_F2_BAPIDFKKKO documentHeader = new _STZH_SOZ_CD_F2_BAPIDFKKKO();

                long pscdBelegNr = belegRow.KgBuchungID + 90000000000;// KeysBLL.GetFirstID(belegart);
                try
                {
                    documentHeader.DOC_NO = SapHelper.GetDocumentNumber(pscdBelegNr);// SapHelper.GetDocumentNumber(belegNumber.Number);//.ToString("000000000000");// (((Int64)kbBuchungID) * 1000000).ToString("000000000000");
                    documentHeader.DOC_TYPE = "KA"; ;
                    object belegDatum = belegRow["ErstelltDatum"];
                    if (belegDatum == System.DBNull.Value)
                        belegDatum = DateTime.Now;
                    documentHeader.DOC_DATE = SapHelper.ConvertDateObject(belegDatum); // Belegdatum im Beleg
                    documentHeader.POST_DATE = SapHelper.ConvertDateObject(belegRow["BuchungsDatum"]);

                    string pscdAuszahlungsart = GetKgZahlungswegInfo(belegRow);
                    if (pscdAuszahlungsart == null && belegRow.IsBaZahlungswegIDNull())
                    {
                        RegisterBelegError(belegRow, "Kein Zahlungsweg angegeben", ref warningMessage);
                        return false;
                    }
                    //string pscdAuszahlungsart;
                    //int? pscdAuszahlungsart = GetKgZahlungswegInfo(null, belegRow["BaZahlungswegID"], belegRow.KgBuchungID, out zahlungswegSapID, out pscdAuszahlungsart);
                    //pscdAuszahlungsart = ConvertToKgAuszahlungsart(pscdAuszahlungsart);
                    //if (!belegRow.IsPscdZahlwegArtNull())
                    //   pscdAuszahlungsart = belegRow.PscdZahlwegArt;

                    List<_STZH_SOZ_CD_F2_BAPIDFKKOP> partnerPositionList = new List<_STZH_SOZ_CD_F2_BAPIDFKKOP>();

                    _STZH_SOZ_CD_F2_BAPIDFKKOP partnerPositionItem = new _STZH_SOZ_CD_F2_BAPIDFKKOP();
                    partnerPositionItem.TEXT = belegRow.Text;
                    decimal amount = -belegRow.Betrag; // Betrag in Kg-Buchhaltung ist positiv, es werden nur Auszahlungen als Beleg an PSCD gesendet
                    //if( !belegRow.IsKgBuchungStatusCodeNull() && belegRow.KgBuchungTypCode == 2 )//Auszahlung
                    partnerPositionItem.ITEM = "1";
                    partnerPositionItem.AMOUNT_LOC_CURR = amount;
                    partnerPositionItem.AMOUNT_LOC_CURRSpecified = true;
                    partnerPositionItem.TRANSACTION_TYPE = "A";
                    partnerPositionItem.TRANSACTION_CODE = "110";
                    partnerPositionItem.COST_CENTER = "9280";
                    partnerPositionList.Add(partnerPositionItem);

                    positions = partnerPositionList.ToArray();
                    /*
                    dfkkop = new BAPI_TE_DFKKOP[] { dfkkopItem };
					if (pscdAuszahlungsart == "R")
					{
						if (belegRow.IsESRReferenznummerNull() || string.IsNullOrEmpty(belegRow.ESRReferenznummer))
						{
							RegisterBelegError(belegRow, "ESR-Referenznummer fehlt", ref warningMessage);
							return false;
						}
						string refNr = belegRow.ESRReferenznummer;
						esr.ESRRE = SapHelper.GetESR(refNr); // Referenznummer
						if (!string.IsNullOrEmpty(refNr) && refNr.Length >= 27)
							esr.ESRPZ = refNr[refNr.Length - 1].ToString(); // Prüfziffer
						esr.ESRNR = BaZahlungswegBLL.MakePcNr(belegRow.PostKontoNummer);// ESRTeilnehmer; // Teilnehmernummer
						esr.NAME1 = belegRow.BeguenstigtName;
						esr.NAME2 = belegRow.BeguenstigtName2;
						esr.STREET = belegRow.BeguenstigtStrasse;
						esr.HOUSE_NUM1 = belegRow.BeguenstigtHausNr;
						esr.POST_CODE1 = belegRow.BeguenstigtPLZ;
						esr.CITY1 = belegRow.BeguenstigtOrt;
					}
                    */

                    //auszahlDaten.SENDER_BANK_ACCOUNT = "";
                    //auszahlDaten.SENDER_BANK_IBAN = "";
                    //auszahlDaten.SENDER_NAME1 = "Stadt Zürich";
                    //auszahlDaten.SENDER_NAME2 = "SoD";
                    //auszahlDaten.SENDER_STREET = "Werdstrasse";
                    //auszahlDaten.SENDER_HOUSE_NO = "75";
                    //auszahlDaten.SENDER_POST_CODE = "8000";
                    //auszahlDaten.SENDER_CITY = "Zürich";
                    //auszahlDaten.SENDER_COUNTRY = "Schweiz";

                    auszahlDaten.RECEIVER_NAME1 = belegRow.BeguenstigtName;
                    auszahlDaten.RECEIVER_NAME2 = belegRow.BeguenstigtName2;
                    if (string.IsNullOrEmpty(belegRow.BeguenstigtStrasse))
                    {
                        //auszahlDaten._STZH_SOZ_ZPFAC = belegRow.BeguenstigtPostfach;
                    }
                    else
                    {
                        auszahlDaten.RECEIVER_STREET = belegRow.BeguenstigtStrasse;
                        auszahlDaten.RECEIVER_HOUSE_NO = belegRow.BeguenstigtHausNr;
                    }
                    auszahlDaten.RECEIVER_POST_CODE = belegRow.BeguenstigtPLZ;
                    auszahlDaten.RECEIVER_CITY = belegRow.BeguenstigtOrt;
                    auszahlDaten.PAYMENT_TYPE = GetKgZahlungswegInfo(belegRow);

                    if (pscdAuszahlungsart == "3" || pscdAuszahlungsart == "1")
                    {
                        if (belegRow.IsBaZahlungswegIDNull())
                        {
                            RegisterBelegError(belegRow, "Kein Zahlungsweg angegeben", ref warningMessage);
                            return false;
                        }

                        KiSSDB.BaZahlungswegRow zielKonto = BaZahlungswegBLL.GetZahlungswegByID(belegRow.BaZahlungswegID);
                        if (zielKonto == null)
                        {
                            // sollte durch FK nicht vorkommen
                            RegisterBelegError(belegRow, "Kein Zielkonto gefunden", ref warningMessage);
                            return false;
                        }
                        string sapLandCode;
                        auszahlDaten.RECEIVER_BANK_KEY = SapHelper.GetClearingNrFromBaBankID(belegRow["BaBankID"], out sapLandCode, !belegRow.IsPostKontoNummerNull(), belegRow.IBANNummer);
                        auszahlDaten.RECEIVER_BANK_COUNTRY = sapLandCode;
                        auszahlDaten.RECEIVER_BANK_ACCOUNT = BaZahlungswegBLL.GetAccountNumber(zielKonto);
                        if (pscdAuszahlungsart == "3" && string.IsNullOrEmpty(belegRow.IBANNummer))
                        {
                            RegisterBelegError(belegRow, "Keine IBAN für Zielkonto angegeben", ref warningMessage);
                            return false;
                        }
                        auszahlDaten.RECEIVER_BANK_IBAN = SapHelper.RemoveBlanks(belegRow.IBANNummer);
                    }
                    auszahlDaten.RECEIVER_TXT1 = belegRow.MitteilungZeile1;
                    auszahlDaten.RECEIVER_TXT2 = belegRow.MitteilungZeile2;
                    auszahlDaten.RECEIVER_TXT3 = belegRow.MitteilungZeile3;
                }
                catch (Exception ex)
                {
                    // Unexcpected Error
                    RegisterBelegError(belegRow, ex.Message, ref warningMessage);
                    return false;
                }
                PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF001", svcBuchungsstoff.Url, pscdBelegNr/*belegNumber.Number*/, user);
                bool exception;
                string callerID = withTimeout ? "TIMEOUT" : SapHelper.GetKissCallerID();
                try
                {
                    string returnMsg = svcBuchungsstoff.MI_SD01_CREATE_WS(
                        callerID,
                        documentHeader,
                        auszahlDaten,
                        ref positions,
                        out returnMessage); // evt. falsch, vermutlich verwechslung returnmessage mit returnmessages
                    log.StopWatch();
                    log.ReturnMsg = returnMsg;
                    log.ErrorMsgs = ParseReturnMessages(returnMessage, out exception);
                    //exceptionMessage += log.GetErrorMsgs(true);
                }
                catch (WebException)
                {
                    // Timeout, unable to connect to the remote server: throw, dont send further documents
                    throw;
                }
                catch (Exception ex)
                {
                    log.StopWatch();
                    log.ExceptionMsg = ex.Message;
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von KgBelegen", ex);
                    exceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
                }
                finally
                {
                    log.WriteToDB();
                }
                if (!log.HasErrorOccured())
                {
                    //belegNr has beeen successfully used
                    belegRow.PscdBelegNr = pscdBelegNr;// belegNumber.Number;
                    belegRow.KgBuchungStatusCode = 3; // verbucht
                    belegRow.TransferDatum = DateTime.Now;
                    belegRow.PscdFehlermeldung = "";    // Lösche die Fehlermeldung, falls sie von einer vorherigen Übertragung noch gesetzt war
                    KgBuchungBLL.Update(belegRow);
                    //belegNumber.SetNumberSuccessfullyUsed();
                }
                else
                {
                    // an error occured, the status remains 'Zahlauftrag fehlerhaft'
                    belegRow.KgBuchungStatusCode = 5; // Zahlauftrag fehlerhaft
                    belegRow.PscdFehlermeldung = log.GetErrorMsgs(false);
                    warningMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Kg-Belegs mit ID {0}: {1}{2}", belegRow.KgBuchungID, belegRow.PscdFehlermeldung, WebServiceHelperMethods.GetNewLineString());
                    success = false;
                    KgBuchungBLL.Update(belegRow);
                    //ProcessErrorMessages(log.ErrorMsgs, pscdBelegNr);//belegNumber);
                }
            }
            return success;
        }

        private CreateObjectResult SubmitKgBelege(KiSSDB.KgBuchungDataTable buchungenTable, UserInfo user, ref string warningMsg, bool withTimeout)
        {
            bool success = true;
            string exceptionMessage = "";
            try
            {
                foreach (KiSSDB.KgBuchungRow belegRow in buchungenTable)
                {
                    success &= SubmitKgBeleg(belegRow, user, ref exceptionMessage, ref warningMsg, withTimeout);
                    //try
                    //{
                    //   success &= SubmitKgBeleg(belegRow, user, ref exceptionMessage, ref warningMsg);
                    //}
                    //catch (Exception ex)
                    //{
                    //   Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    //   exceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
                    //}
                }
            }
            catch (WebException ex)
            {
                // timeout, unable to connect to the remote server
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), string.Format("WebException beim Anlegen von KgBelegen. Status '{0}', Message: '{1}'", ex.Status, ex.Message), ex);
                if (ex.Status == WebExceptionStatus.Timeout)
                    exceptionMessage += string.Format("Timeout: Der XI-Server hat nicht innert nützlicher Frist geantwortet{0}", WebServiceHelperMethods.GetNewLineString());
                if (ex.Status == WebExceptionStatus.ConnectFailure)
                    exceptionMessage += string.Format("ConnectFailure: Der XI-Server gibt keine Antwort{0}", WebServiceHelperMethods.GetNewLineString());
                else
                    exceptionMessage += string.Format("Verbindungsproblem, HTTP-Status {0}, Fehlermeldung: '{1}'{2}", ex.Message, ex.Status, WebServiceHelperMethods.GetNewLineString());
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                exceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
            }
            if (!string.IsNullOrEmpty(exceptionMessage))
                throw new Exception(exceptionMessage);
            return success ? CreateObjectResult.Success : CreateObjectResult.Warning;
        }

        //private static string ConvertToKgAuszahlungsart(string pscdAuszahlungsart)
        //{
        //    // Bank
        //    if (pscdAuszahlungsart == "3")
        //        return "I";
        //    // ESR
        //    if (pscdAuszahlungsart == "1")
        //        return "R";
        //    // Postmandant
        //    if (pscdAuszahlungsart == "D")
        //        return "M";

        //    return pscdAuszahlungsart;
        //}

        #endregion

        private KiSSDB.PscdCallReturnMsgDataTable ParseReturnMessages(BAPIRET2 retMsg, out bool exception)
        {
            KiSSDB.PscdCallReturnMsgDataTable errorTbl = new KiSSDB.PscdCallReturnMsgDataTable();
            int tempInt;
            exception = false;
            //foreach (BAPIRET2 retMsg in returnMessages)
            //{
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
            //}
            return errorTbl;
        }
    }
}