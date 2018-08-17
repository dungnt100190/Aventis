using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using KiSSSvc.DAL;
using KiSSSvc.Logging;
using KiSSSvc.SAP.Helpers;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.BelegSenden;

namespace KiSSSvc.SAP.PSCD.BudgetData
{
    public class BuchungsstoffAsync
    {
        private MI_BUCHSTOFF_CREA_SOAP_OUTService svcBuchungsstoff;

        public BuchungsstoffAsync()
        {
            svcBuchungsstoff = WebServiceSource.GetBelegAnlegenAsyncWS();
        }

        /*
        public CreateObjectResult SubmitWhBelegeByKbBuchungIDs(int[] kbBuchungIDs, int[] kbBuchungBruttoIDs, UserInfo userInfo, ref string warningMsg)
        {
            KiSSDB.KbBuchungDataTable nettoBelege = KbBuchungBLL.GetWhBelegeFromKbBuchungIDs(kbBuchungIDs);
            KiSSDB.KbBuchungBruttoDataTable bruttoBelege = KbBuchungBruttoBLL.GetBruttoBelegeByKbBuchungIDs(kbBuchungIDs, kbBuchungBruttoIDs);
            int[] faLeistungIDs = KbBuchungBLL.GetDistinctFaLeistungIDs(nettoBelege, bruttoBelege);
            Log.Info(this.GetType(), string.Format("Daten zusammengesucht von DB: Netto {0}, Brutto {1}, Leistungen {2}", nettoBelege.Count, bruttoBelege.Count, faLeistungIDs.Length));
            string exceptionMessage = "";
            // Submit the BPs that are referenced from the documents
            try
            {
                Vertragsgegenstände vg = new Vertragsgegenstände();
                vg.SubmitLeistungen(faLeistungIDs, userInfo, ref warningMsg);
            }
            catch (Exception ex)
            {
                string msg = string.Format("Fehler beim Anlegen von Vertragsgegenständen: {0}{1}", ex.Message, WebServiceHelperMethods.GetNewLineString());
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), msg, ex);
                exceptionMessage += msg;
                // if the creation of the vg failed, the documents won't be successfully created. so abort now
                throw;
            }

            int[] institutionAndSchuldnerIDs = BaInstitutionBLL.GetInstitutionsAndSchuldnerOfKbBuchungIDs(kbBuchungIDs, kbBuchungBruttoIDs);
            exceptionMessage = SubmitInstitutionsAndSchuldner(exceptionMessage, institutionAndSchuldnerIDs, userInfo, ref warningMsg);

            //fetch again, some fields could possibly have been changed (e.g. AnDritte, PscdVertragsgegenstandNr)
            nettoBelege = KbBuchungBLL.GetWhBelegeFromKbBuchungIDs(kbBuchungIDs);
            bruttoBelege = KbBuchungBruttoBLL.GetBruttoBelegeByKbBuchungIDs(kbBuchungIDs, kbBuchungBruttoIDs);

            bool success = SubmitWhBelege(nettoBelege, bruttoBelege, userInfo, ref exceptionMessage, ref warningMsg);

            if (!string.IsNullOrEmpty(exceptionMessage))
                throw new Exception(exceptionMessage);
            return success ? CreateObjectResult.Success : CreateObjectResult.Warning;
        }

        private bool SubmitWhBelege(KiSSDB.KbBuchungDataTable nettoBelege, KiSSDB.KbBuchungBruttoDataTable bruttoBelege, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        {
            bool success = true;
            Log.Info(this.GetType(), string.Format("Sende {0} Wh-Belege ({1} Netto, {2} Brutto)", nettoBelege.Count + bruttoBelege.Count, nettoBelege.Count, bruttoBelege.Count));
            foreach (KiSSDB.KbBuchungRow belegRow in nettoBelege)
            {
                try
                {
                    success &= SubmitNettoBeleg(belegRow, user, ref exceptionMessage, ref warningMessage);
                }
                catch (Exception ex)
                {
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    success = false;
                    exceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
                }
            }
            // Bruttobelege
            foreach (KiSSDB.KbBuchungBruttoRow belegRow in bruttoBelege)
            {
                try
                {
                    success &= SubmitBruttoBeleg(belegRow, user, ref exceptionMessage, ref warningMessage);
                }
                catch (Exception ex)
                {
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    success = false;
                    exceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
                }
            }
            return success;
        }

        private static string SubmitInstitutionsAndSchuldner(string exceptionMessage, int[] institutionAndSchuldnerIDs, UserInfo user, ref string warningMsg)
        {
            if (institutionAndSchuldnerIDs.Length > 0)
            {
                Stammdaten st = new Stammdaten();
                foreach (int id in institutionAndSchuldnerIDs)
                {
                    if (id < SapHelper.FirstInstitutionID)
                    {
                        try
                        {
                            st.CreateAndSubmitBusinessPartnerPerson(id, user, ref warningMsg);
                        }
                        catch (Exception ex)
                        {
                            string msg = string.Format("Fehler beim Anlegen von Institution mit ID {0}: {1}{2}", id, ex.Message, WebServiceHelperMethods.GetNewLineString());
                            Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), msg, ex);
                            exceptionMessage += msg;
                        }
                    }
                    else
                    {
                        try
                        {
                            st.CreateAndSubmitBusinessPartnerInstitution(id, user, ref warningMsg);
                        }
                        catch (Exception ex)
                        {
                            string msg = string.Format("Fehler beim Anlegen von Institution mit ID {0}: {1}{2}", id, ex.Message, WebServiceHelperMethods.GetNewLineString());
                            Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), msg, ex);
                            exceptionMessage += msg;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);
            }
            return exceptionMessage;
        }

        #region Brutto

        private bool SubmitBruttoBeleg(KiSSDB.KbBuchungBruttoRow belegRow, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        {
            bool success = true;
            if (belegRow.IsKbBuchungStatusCodeNull() || belegRow.KbBuchungStatusCode != 2)
                // Buchung is not ready to be transferred
                return true;

            KiSSDB.KbBuchungBruttoPersonDataTable positionsTable = KbBuchungBruttoBLL.GetPositionsOfBeleg(belegRow.KbBuchungBruttoID);
            if (positionsTable.Count == 0)
                return true;

            string belegart = belegRow.Belegart;
            string payment_grp = SapHelper.GetGrouping(belegRow.BgBudgetID);
            string soz_mbudg = SapHelper.GetBudgetID(belegRow.BgBudgetID, BgBudgetBLL.GetDateOfBudget(belegRow.BgBudgetID)); // ToDo: DB-Zugriffe reduzieren
            long pscdVgID = belegRow.PscdVertragsgegenstandID;

            // Check if Belegart is null
            if (string.IsNullOrEmpty(belegart))
            {
                string msg = string.Format("Keine Belegart für KbBuchungBruttoPerson mit ID {0} definiert", positionsTable[0].KbBuchungBruttoPersonID);
                exceptionMessage += msg + WebServiceHelperMethods.GetNewLineString();
                Log.Warn(this.GetType(), msg);
                return true;
            }

            using (BelegNr belegNumber = new BelegNr(KeysBLL.GetBelegNr(belegart)))
            {
                string completeDocument = "X";
                BAPIDFKKKO documentHeader = new BAPIDFKKKO();
                documentHeader.DOC_NO = SapHelper.GetDocumentNumber(belegNumber.Number);//.ToString("000000000000");// (((Int64)kbBuchungID) * 1000000).ToString("000000000000");
                documentHeader.FIKEY = SapHelper.GetAbstimmschluessel();
                documentHeader.APPL_AREA = "P"; // fix value, 'Öffentliche Verwaltung'
                documentHeader.DOC_TYPE = belegart;
                documentHeader.DOC_SOURCE_KEY = "33"; // Belegübernahme
                documentHeader.CURRENCY = "CHF";
                object belegDatum = belegRow["BelegDatum"];
                if (belegDatum == System.DBNull.Value)
                    belegDatum = DateTime.Now;
                documentHeader.DOC_DATE = SapHelper.ConvertDateObject(belegDatum); // Belegdatum im Beleg
                //object valutaDatum = SapHelper.ConvertDateObject(belegRow["Valutadatum"]);
                documentHeader.POST_DATE = SapHelper.ConvertDateObject(belegRow["Valutadatum"]);
                documentHeader.SINGLE_DOC = " ";
                documentHeader.OBJ_SYS = belegRow.Kostenstelle;

                BAPIRECKEYINFO recKeyInfo = new BAPIRECKEYINFO();
                recKeyInfo.CALLER_ID = SapHelper.GetKissCallerID();

                List<BAPIDFKKOP> partnerPositionList = new List<BAPIDFKKOP>();
                List<BAPIDFKKOPLOCK> lockList = new List<BAPIDFKKOPLOCK>();
                List<BAPI_TE_DFKKOP> dfkkopList = new List<BAPI_TE_DFKKOP>();
                foreach (KiSSDB.KbBuchungBruttoPersonRow positionRow in positionsTable)
                {
                    BAPIDFKKOP partnerPositionItem = new BAPIDFKKOP();
                    BAPI_TE_DFKKOP dfkkopItem = new BAPI_TE_DFKKOP();

                    partnerPositionItem.DOC_NO = documentHeader.DOC_NO;
                    partnerPositionItem.REP_ITEM = "000"; // ToDo: offen
                    partnerPositionItem.ITEM = positionRow.PositionImBeleg.ToString("0000");
                    partnerPositionItem.SUB_ITEM = "000"; // fix value
                    partnerPositionItem.COMP_CODE = "5550"; // fix value, Standardbuchungskreis
                    partnerPositionItem.BUSPARTNER = SapHelper.GetBusinessPartnerNumber(positionRow.BaPersonID);
                    partnerPositionItem.CONT_ACCT = SapHelper.GetContractAccountNumber(positionRow.BaPersonID);
                    partnerPositionItem.CONTRACT = SapHelper.GetPsObjectNumber(pscdVgID);
                    partnerPositionItem.APPL_AREA = "P"; // fix value
                    partnerPositionItem.MAIN_TRANS = belegRow.Hauptvorgang.ToString("0000");
                    partnerPositionItem.SUB_TRANS = belegRow.Teilvorgang.ToString("0000");
                    partnerPositionItem.ACTDETERID = "01"; // ToDo: offen
                    partnerPositionItem.CALC_PERLO = SapHelper.ConvertDateObject(positionRow["VerwPeriodeVon"]);
                    partnerPositionItem.CALC_PERHI = SapHelper.ConvertDateObject(positionRow["VerwPeriodeBis"]);

                    if (positionRow.Betrag > 0m)
                    {
                        // Bei Forderungen den Debitor als abweichenden Zahler eintragen
                        if (!positionRow.IsSchuldner_BaInstitutionIDNull())
                            partnerPositionItem.PARTNER = SapHelper.GetBusinessPartnerNumber(positionRow.Schuldner_BaInstitutionID);
                        else if (!positionRow.IsSchuldner_BaPersonIDNull())
                            partnerPositionItem.PARTNER = SapHelper.GetBusinessPartnerNumber(positionRow.Schuldner_BaPersonID);
                    }

                    if (SapHelper.IsAbgetreten(belegRow.Hauptvorgang))
                    {
                        // abgetretene Forderungen
                        partnerPositionItem.STAT_KEY = "G";
                    }
                    else
                    {
                        // nicht abgetretene Forderungen
                        dfkkopItem._STZH_SOZ_PYGRP = payment_grp;
                        partnerPositionItem.ONLY_OFF = "X";

                        BAPIDFKKOPLOCK lockItem = new BAPIDFKKOPLOCK();
                        lockItem.PROCESSING_MODE = "01";
                        lockItem.REP_ITEM = "000";
                        lockItem.ITEM = partnerPositionItem.ITEM;
                        lockItem.SUB_ITEM = "000";
                        lockItem.PROCESS_ID = "09";
                        lockItem.LOCK_REASON = "M";
                        lockItem.FROM_DATE = "0001-01-01";
                        lockItem.TO_DATE = "9999-12-31";
                        lockList.Add(lockItem);
                    }

                    partnerPositionItem.DOC_DATE = documentHeader.DOC_DATE;
                    partnerPositionItem.POST_DATE = documentHeader.POST_DATE;
                    partnerPositionItem.NET_DATE = documentHeader.POST_DATE; // Nettofälligkeitsdatum SapHelper.ConvertDateObject(positionRow["ValutaDatum"]);
                    partnerPositionItem.DISC_DUE = partnerPositionItem.NET_DATE; // Skontofälligkeit, identisch mit Nettofälligkeit
                    partnerPositionItem.TEXT = positionRow.Buchungstext;
                    partnerPositionItem.CURRENCY = "CHF";
                    //partnerPositionItem.CURRENCY_ISO = "CHF";
                    decimal amount = positionRow.Betrag;
                    partnerPositionItem.AMOUNT_LOC_CURR = amount;
                    partnerPositionItem.AMOUNT_LOC_CURRSpecified = true;
                    partnerPositionItem.AMOUNT = amount;
                    partnerPositionItem.AMOUNTSpecified = true;
                    partnerPositionItem.DOC_TYPE = belegRow.Belegart;

                    //if (!belegRow.IsValutaDatumNull())
                    //   partnerPositionItem.FISC_YEAR = belegRow.ValutaDatum.Year.ToString();	// #5292: FISC_YEAR darf nicht befüllt werden
                    //partnerPositionItem.AMOUNT_GL = partnerPositionItem.AMOUNT_LOC_CURR;
                    //partnerPositionItem.AMOUNT_GLSpecified = true;
                    partnerPositionItem.CURRENCY_GL = "CHF";

                    //dfkkopItem._STZH_SOZ_GPART2 = partnerPositionItem.BUSPARTNER; // Nur wenn Beleg auf Dritte gebucht wird, sprich nur bei Nettozahlungen
                    dfkkopItem._STZH_SOZ_MBUDG = soz_mbudg;
                    dfkkopItem.DOC_NO = partnerPositionItem.DOC_NO;
                    dfkkopItem.REP_ITEM = partnerPositionItem.REP_ITEM;
                    dfkkopItem.SUB_ITEM = partnerPositionItem.SUB_ITEM;
                    dfkkopItem.ITEM = partnerPositionItem.ITEM;
                    dfkkopList.Add(dfkkopItem);

                    partnerPositionList.Add(partnerPositionItem);
                }

                // the document header might have no valuta, take the first of the detailpos then
                if (string.IsNullOrEmpty(documentHeader.POST_DATE) && partnerPositionList.Count > 0)
                    documentHeader.POST_DATE = partnerPositionList[0].POST_DATE;

                BAPIDFKKOPK[] genledgerPositions = new BAPIDFKKOPK[] { };
                BAPIDFKKOP[] partnerPositions = partnerPositionList.ToArray();
                BAPIRET2[] returnMessages = new BAPIRET2[] { };
                string returnMsg;
                BAPI_TE_DFKKOP[] dfkkop = dfkkopList.ToArray();
                _STZH_SOZ_CD_BELEG_BAPI_ESR esr = new _STZH_SOZ_CD_BELEG_BAPI_ESR();
                _STZH_SOZ_CD_VK_AUSZAHLDATEN auszahlDaten = new _STZH_SOZ_CD_VK_AUSZAHLDATEN();
                BAPIDFKKOPC[] dfkkopc = new BAPIDFKKOPC[] { };
                BAPIFKKDEFREV_DATES[] dates = new BAPIFKKDEFREV_DATES[] { };
                BAPIDFKKOPKX[] genledgerPositionsExt = new BAPIDFKKOPKX[] { };
                BAPIFKKOPREL[] relations = new BAPIFKKOPREL[] { };
                BAPIDFKKOPLOCK[] locks = lockList.ToArray();
                BAPIDFKKOPW[] repetition = new BAPIDFKKOPW[] { };
                _STZH_KISS_BUCHSTOFF buchstoff = new _STZH_KISS_BUCHSTOFF();
                buchstoff.

                PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF001", svcBuchungsstoff.Url, belegNumber.Number, user);
                try
                {
                    returnMsg = svcBuchungsstoff.MI_BUCHSTOFF_CREA_SOAP_OUT(
                        completeDocument,
                        documentHeader,
                        esr,
                        recKeyInfo,
                        auszahlDaten,
                        ref dfkkopc,
                        ref dates,
                        ref dfkkop,
                        ref genledgerPositions,
                        ref genledgerPositionsExt,
                        ref relations,
                        ref partnerPositions,
                        ref locks,
                        ref repetition,
                        ref returnMessages);
                    log.StopWatch();
                    log.ReturnMsg = returnMsg;
                    log.ErrorMsgs = ParseReturnMessages(returnMessages);
                }
                catch (Exception ex)
                {
                    log.StopWatch();
                    log.ExceptionMsg = ex.Message;
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von Bruttobelegen", ex);
                    exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Bruttobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungBruttoID, ex.Message, WebServiceHelperMethods.GetNewLineString());
                }
                finally
                {
                    log.WriteToDB();
                }

                if (!log.HasErrorOccured())
                {
                    // belegNr has beeen successfully used
                    // Mark the Buchung as 'sent to SAP'
                    belegRow.BelegNr = belegNumber.Number;
                    if (belegRow.Betrag > 0)
                    {
                        // Einnahme -> Nettobeleg als verbucht setzen
                        KbBuchungBLL.SetEinnahmeNettoBelegVerbucht(belegRow.KbBuchungBruttoID);
                    }
                    belegRow.KbBuchungStatusCode = 3; // verbucht
                    belegRow.TransferDatum = DateTime.Now;
                    KbBuchungBruttoBLL.Update(belegRow);
                    belegNumber.SetNumberSuccessfullyUsed();
                }
                else
                {
                    belegRow.KbBuchungStatusCode = 5; // Zahlauftrag fehlerhaft
                    belegRow.PscdFehlermeldung = log.GetErrorMsgs(false);
                    warningMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Bruttobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungBruttoID, belegRow.PscdFehlermeldung, WebServiceHelperMethods.GetNewLineString());
                    success = false;
                    KbBuchungBruttoBLL.Update(belegRow);
                    ProcessErrorMessages(log.ErrorMsgs, belegNumber);
                }
            }
            return success;
        }

        private void ProcessErrorMessages(KiSSDB.PscdCallReturnMsgDataTable pscdCallReturnMsgDataTable, BelegNr belegNumber)
        {
            foreach (KiSSDB.PscdCallReturnMsgRow row in pscdCallReturnMsgDataTable)
            {
                if (!row.IsMessageNumberNull() && row.MessageNumber == 51) // Belegnummer bereits vergeben
                {
                    long nr = 0;
                    if (long.TryParse(row.Message1, out nr))
                    {
                        if (belegNumber.Number == nr)
                            belegNumber.SetNumberSuccessfullyUsed();
                        else
                            KeysBLL.RemoveBelegNr(nr);
                    }
                }
            }
        }

        #endregion

        */

        #region Netto

        //private bool SubmitNettoBeleg(KiSSDB.KbBuchungRow belegRow, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        //{
        //   bool success = true;
        //   if (belegRow.IsKbBuchungStatusCodeNull() || belegRow.KbBuchungStatusCode != 2)
        //      // Buchung is not ready to be transferred
        //      return true;

        //   KiSSDB.KbBuchungKostenartDataTable positionsTable = KbBuchungBLL.GetPositionsOfBeleg(belegRow.KbBuchungID);
        //   if (positionsTable.Count == 0)
        //      return true;

        //   string belegart = "AA"; // Nettobelege, "Auszahlanweisung"
        //   string payment_grp = SapHelper.GetGrouping(belegRow.BgBudgetID);
        //   string soz_mbudg = SapHelper.GetBudgetID(belegRow.BgBudgetID, BgBudgetBLL.GetDateOfBudget(belegRow.BgBudgetID)); // ToDo: DB-Zugriffe reduzieren
        //   long pscdVgID = belegRow.PscdVertragsgegenstandID;

        //   using (BelegNr belegNumber = new BelegNr(KeysBLL.GetBelegNr(belegart)))
        //   {
        //      string completeDocument = "X";
        //      BAPIDFKKKO documentHeader = new BAPIDFKKKO();
        //      documentHeader.DOC_NO = SapHelper.GetDocumentNumber(belegNumber.Number);
        //      documentHeader.FIKEY = SapHelper.GetAbstimmschluessel();
        //      documentHeader.APPL_AREA = "P"; // fix value, 'Öffentliche Verwaltung'
        //      documentHeader.DOC_TYPE = belegart;
        //      documentHeader.DOC_SOURCE_KEY = "33"; // Belegübernahme
        //      documentHeader.CURRENCY = "CHF";
        //      object belegDatum = belegRow["BelegDatum"];
        //      if (belegDatum == System.DBNull.Value)
        //         belegDatum = DateTime.Now;
        //      documentHeader.DOC_DATE = SapHelper.ConvertDateObject(belegDatum); // Belegdatum im Beleg
        //      documentHeader.POST_DATE = SapHelper.ConvertDateObject(belegRow["Valutadatum"]);
        //      documentHeader.SINGLE_DOC = " ";
        //      documentHeader.OBJ_SYS = belegRow.Kostenstelle;

        //      BAPIRECKEYINFO recKeyInfo = new BAPIRECKEYINFO();
        //      recKeyInfo.CALLER_ID = SapHelper.GetKissCallerID();

        //      string zahlungswegSapID;
        //      string pscdAuszahlungsart;
        //      int? zahlungswegBesitzerBpId = GetBusinessPartnerOfZahlungsweg(belegRow, out zahlungswegSapID, out pscdAuszahlungsart);
        //      if (!belegRow.IsPscdZahlwegArtNull())
        //         pscdAuszahlungsart = belegRow.PscdZahlwegArt;

        //      List<BAPIDFKKOP> partnerPositionList = new List<BAPIDFKKOP>();

        //      #region Detaillierte Nettobelege
        //      /*
        //            foreach (KiSSDB.KbBuchungKostenartRow positionRow in positionsTable)
        //            {
        //               BAPIDFKKOP partnerPositionItem = new BAPIDFKKOP();
        //               partnerPositionItem.DOC_NO = documentHeader.DOC_NO;
        //               partnerPositionItem.REP_ITEM = "000"; // ToDo: offen
        //               partnerPositionItem.ITEM = positionRow.PositionImBeleg.ToString("0000");
        //               partnerPositionItem.SUB_ITEM = "000"; // fix value
        //               partnerPositionItem.COMP_CODE = "5550"; // fix value, Standardbuchungskreis
        //               partnerPositionItem.BUSPARTNER = SapHelper.GetBusinessPartnerNumber(positionRow.BaPersonID);
        //               partnerPositionItem.CONT_ACCT = SapHelper.GetContractAccountNumber(positionRow.BaPersonID);
        //               partnerPositionItem.CONTRACT = SapHelper.GetPsObjectNumber(pscdVgID);
        //               partnerPositionItem.APPL_AREA = "P"; // fix value
        //               partnerPositionItem.MAIN_TRANS = "2000";
        //               partnerPositionItem.SUB_TRANS = "2100";
        //               partnerPositionItem.ACTDETERID = "01"; // ToDo: offen

        //               partnerPositionItem.DOC_DATE = documentHeader.DOC_DATE;
        //               partnerPositionItem.POST_DATE = documentHeader.POST_DATE;
        //               partnerPositionItem.NET_DATE = documentHeader.POST_DATE;
        //               partnerPositionItem.DISC_DUE = partnerPositionItem.NET_DATE; // Skontofälligkeit, identisch mit Nettofälligkeit
        //               partnerPositionItem.TEXT = positionRow.Buchungstext;
        //               partnerPositionItem.CURRENCY = "CHF";
        //               //partnerPositionItem.CURRENCY_ISO = "CHF";
        //               decimal amount = positionRow.Betrag;
        //               if (belegRow.BuchungTypCode == 1) // Verbindlichkeit
        //               {
        //                  // Submit the Zahlungwseg (where the money gets to or comes from)
        //                  // BK_DETAILS: ID of the Zahlungsweg; received from a previously transmitted Zahlungsweg
        //                  // PMNT_METH: Zahlungsweg: Banküberweisung (nur für Auszahlungen)
        //                  // PARTNER: Number of the business partner who receives the money
        //                  if (string.IsNullOrEmpty(zahlungswegBesitzerBpId))
        //                  {
        //                     partnerPositionItem.PARTNER = partnerPositionItem.BUSPARTNER; // Zahlungsweg: Banküberweisung (nur für Auszahlungen)
        //                     partnerPositionItem.PMNT_METH = "3";
        //                  }
        //                  else
        //                  {
        //                     partnerPositionItem.PARTNER = zahlungswegBesitzerBpId;

        //                     partnerPositionItem.BK_DETAILS = zahlungswegSapID;
        //                     partnerPositionItem.PMNT_METH = pscdAuszahlungsart;
        //                  }
        //                  // Auszahlungen müssen für SAP ein negatives Vorzeichen haben
        //                  //amount = -amount;
        //                  //DataTable zahlungswegTable = DBUtil.OpenSQL(session, "SELECT BaPersonID, BaInstitutionID, SapID FROM BaZahlungsweg WHERE BaZahlungswegID = {0}", positionRow["BaZahlungswegID"]).DataTable;
        //               }
        //               partnerPositionItem.AMOUNT_LOC_CURR = amount;
        //               partnerPositionItem.AMOUNT_LOC_CURRSpecified = true;
        //               //partnerPositionItem.AMOUNT = amount;
        //               //partnerPositionItem.AMOUNTSpecified = true;
        //               partnerPositionItem.DOC_TYPE = positionRow.Belegart;
        //               if (!belegRow.IsValutaDatumNull())
        //                  partnerPositionItem.FISC_YEAR = belegRow.ValutaDatum.Year.ToString();	// #5292: FISC_YEAR darf nicht befüllt werden
        //               //partnerPositionItem.AMOUNT_GL = partnerPositionItem.AMOUNT_LOC_CURR;
        //               //partnerPositionItem.AMOUNT_GLSpecified = true;
        //               partnerPositionItem.CURRENCY_GL = "CHF";
        //               //			partnerPositionItem.G_L_ACCT = "36605110";
        //               partnerPositionList.Add(partnerPositionItem);
        //            }
        //            */
        //      #endregion

        //      BAPIDFKKOP partnerPositionItem = new BAPIDFKKOP();
        //      BAPI_TE_DFKKOP dfkkopItem = new BAPI_TE_DFKKOP();

        //      partnerPositionItem.DOC_NO = documentHeader.DOC_NO;
        //      partnerPositionItem.REP_ITEM = "000"; // ToDo: offen
        //      partnerPositionItem.ITEM = "0001"; // fix, da nur eine Position
        //      partnerPositionItem.SUB_ITEM = "000"; // fix value
        //      partnerPositionItem.COMP_CODE = "5550"; // fix value, Standardbuchungskreis

        //      // Nettobelege werden auf Dritte gebucht (wenn sie an Dritte ausbezahlt werden)
        //      // zur Not (Barbelege) werden sie auf den Leistungsträger gebucht
        //      int bpNumber = zahlungswegBesitzerBpId.HasValue ? zahlungswegBesitzerBpId.Value : belegRow.BaPersonID_LT;
        //      // Für Barauszahlungen werden sie auf die Person der Detailposition gebucht. Der Leistungsträger muss nicht zwingend im Finanzplan dabei sein und ist daher ev. nicht in PSDC angelegt. Dann könnte der Beleg nicht verbucht werden
        //      if (pscdAuszahlungsart == "C" && positionsTable.Count > 0 && !positionsTable[0].IsBaPersonIDNull())
        //         bpNumber = positionsTable[0].BaPersonID;
        //      partnerPositionItem.BUSPARTNER = SapHelper.GetBusinessPartnerNumber(bpNumber);
        //      partnerPositionItem.CONT_ACCT = SapHelper.GetContractAccountNumber(bpNumber);
        //      if (belegRow.AnDritte)
        //         dfkkopItem._STZH_SOZ_VTREF2 = SapHelper.GetPsObjectNumber(pscdVgID);
        //      else
        //         partnerPositionItem.CONTRACT = SapHelper.GetPsObjectNumber(pscdVgID);

        //      partnerPositionItem.PARTNER = partnerPositionItem.BUSPARTNER;
        //      partnerPositionItem.PMNT_METH = pscdAuszahlungsart;
        //      if (pscdAuszahlungsart != "C")
        //         partnerPositionItem.BK_DETAILS = zahlungswegSapID;

        //      partnerPositionItem.APPL_AREA = "P"; // fix value
        //      partnerPositionItem.MAIN_TRANS = "2000";
        //      partnerPositionItem.SUB_TRANS = "2100";
        //      partnerPositionItem.ACTDETERID = "01"; // ToDo: offen

        //      partnerPositionItem.DOC_DATE = documentHeader.DOC_DATE;
        //      partnerPositionItem.POST_DATE = documentHeader.POST_DATE;
        //      partnerPositionItem.NET_DATE = documentHeader.POST_DATE;
        //      partnerPositionItem.DISC_DUE = documentHeader.POST_DATE; // Skontofälligkeit, identisch mit Nettofälligkeit
        //      partnerPositionItem.TEXT = belegRow.Text;
        //      partnerPositionItem.CURRENCY = "CHF";
        //      partnerPositionItem.STAT_KEY = "Z"; // Zahlungsanweisung
        //      decimal amount = belegRow.Betrag;
        //      if (belegRow.IstKreditorBuchung)
        //         amount = -amount;

        //      partnerPositionItem.AMOUNT_LOC_CURR = amount;
        //      partnerPositionItem.AMOUNT_LOC_CURRSpecified = true;
        //      partnerPositionItem.AMOUNT = amount;
        //      partnerPositionItem.AMOUNTSpecified = true;
        //      partnerPositionItem.DOC_TYPE = belegart;
        //      dfkkopItem._STZH_SOZ_PYGRP = payment_grp;
        //      if (!belegRow.IsValutaDatumNull())
        //         partnerPositionItem.FISC_YEAR = belegRow.ValutaDatum.Year.ToString();	// #5292: FISC_YEAR darf nicht befüllt werden
        //      //partnerPositionItem.AMOUNT_GL = partnerPositionItem.AMOUNT_LOC_CURR;
        //      //partnerPositionItem.AMOUNT_GLSpecified = true;
        //      //partnerPositionItem.CURRENCY_GL = "CHF";
        //      //			partnerPositionItem.G_L_ACCT = "36605110";
        //      partnerPositionList.Add(partnerPositionItem);

        //      //						if (belegRow.Dritte)
        //      //							dfkkopItem._STZH_SOZ_GPART2 = partnerPositionItem.BUSPARTNER;
        //      dfkkopItem._STZH_SOZ_MBUDG = soz_mbudg;
        //      dfkkopItem.DOC_NO = partnerPositionItem.DOC_NO;
        //      dfkkopItem.REP_ITEM = partnerPositionItem.REP_ITEM;
        //      dfkkopItem.SUB_ITEM = partnerPositionItem.SUB_ITEM;
        //      dfkkopItem.ITEM = partnerPositionItem.ITEM;

        //      // the document header might have no valuta, take the first of the detailpos then
        //      if (string.IsNullOrEmpty(documentHeader.POST_DATE) && partnerPositionList.Count > 0)
        //         documentHeader.POST_DATE = partnerPositionList[0].POST_DATE;

        //      BAPIDFKKOPK[] genledgerPositions = new BAPIDFKKOPK[] { };
        //      BAPIDFKKOP[] partnerPositions = partnerPositionList.ToArray();
        //      BAPIRET2[] returnMessages = new BAPIRET2[] { };
        //      string returnMsg;
        //      BAPI_TE_DFKKOP[] dfkkop = new BAPI_TE_DFKKOP[] { dfkkopItem };
        //      _STZH_SOZ_CD_BELEG_BAPI_ESR esr = new _STZH_SOZ_CD_BELEG_BAPI_ESR();
        //      if (pscdAuszahlungsart == "1")
        //      {
        //         if (belegRow.IsReferenzNummerNull())
        //         {
        //            exceptionMessage = string.Format("Keine ESR-Referenznummer angegeben für Nettobeleg mit ID {0}", belegRow.KbBuchungID);
        //            return false;
        //         }
        //         string refNr = belegRow.ReferenzNummer;
        //         esr.ESRRE = refNr; // Referenznummer
        //         if (!string.IsNullOrEmpty(refNr) && refNr.Length >= 27)
        //            esr.ESRPZ = refNr[refNr.Length - 1].ToString(); // Prüfziffer
        //         esr.ESRNR = BaZahlungswegBLL.MakePcNr(belegRow.PCKontoNr); // Teilnehmernummer -> PC-Nummer
        //         esr.NAME1 = belegRow.BeguenstigtName;
        //         esr.NAME2 = belegRow.BeguenstigtName2;
        //         esr.STREET = belegRow.BeguenstigtStrasse;
        //         esr.HOUSE_NUM1 = belegRow.BeguenstigtHausNr;
        //         esr.POST_CODE1 = belegRow.BeguenstigtPLZ;
        //         esr.CITY1 = belegRow.BeguenstigtOrt;
        //      }
        //      _STZH_SOZ_CD_VK_AUSZAHLDATEN auszahlDaten = new _STZH_SOZ_CD_VK_AUSZAHLDATEN();
        //      BAPIDFKKOPC[] dfkkopc = new BAPIDFKKOPC[] { };
        //      BAPIFKKDEFREV_DATES[] dates = new BAPIFKKDEFREV_DATES[] { };
        //      BAPIDFKKOPKX[] genledgerPositionsExt = new BAPIDFKKOPKX[] { };
        //      BAPIFKKOPREL[] relations = new BAPIFKKOPREL[] { };
        //      BAPIDFKKOPLOCK[] locks = new BAPIDFKKOPLOCK[] { };
        //      BAPIDFKKOPW[] repetition = new BAPIDFKKOPW[] { };

        //      PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF001", svcBuchugsstoff.Url, belegNumber.Number, user);
        //      try
        //      {
        //         returnMsg = svcBuchugsstoff.MI_KISS_BUCHSTOFF001(
        //            completeDocument,
        //            documentHeader,
        //            esr,
        //            recKeyInfo,
        //            auszahlDaten,
        //            ref dfkkopc,
        //            ref dates,
        //            ref dfkkop,
        //            ref genledgerPositions,
        //            ref genledgerPositionsExt,
        //            ref relations,
        //            ref partnerPositions,
        //            ref locks,
        //            ref repetition,
        //            ref returnMessages);
        //         log.StopWatch();
        //         log.ReturnMsg = returnMsg;
        //         log.ErrorMsgs = ParseReturnMessages(returnMessages);
        //      }
        //      catch (Exception ex)
        //      {
        //         log.StopWatch();
        //         log.ExceptionMsg = ex.Message;
        //         Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von Nettobelegen", ex);
        //         exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Nettobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, ex.Message, WebServiceHelperMethods.GetNewLineString());
        //      }
        //      finally
        //      {
        //         log.WriteToDB();
        //      }
        //      if (!log.HasErrorOccured())
        //      {
        //         // belegNr has beeen successfully used
        //         belegRow.BelegNr = belegNumber.Number;
        //         belegRow.KbBuchungStatusCode = 3; // verbucht
        //         belegRow.TransferDatum = DateTime.Now;
        //         KbBuchungBLL.Update(belegRow);
        //         belegNumber.SetNumberSuccessfullyUsed();
        //      }
        //      else
        //      {
        //         belegRow.KbBuchungStatusCode = 5; // Zahlauftrag fehlerhaft
        //         belegRow.PscdFehlermeldung = log.GetErrorMsgs(false);
        //         warningMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Nettobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, belegRow.PscdFehlermeldung, WebServiceHelperMethods.GetNewLineString());
        //         success = false;
        //         KbBuchungBLL.Update(belegRow);
        //         ProcessErrorMessages(log.ErrorMsgs, belegNumber);
        //      }
        //   }
        //   return success;
        //}

        #endregion

        /*

		#region Alim: KiSS Netto, PSCD Brutto

		public CreateObjectResult SubmitAlimBelegeByKbBuchungIDs(int[] kbBuchungIDs, UserInfo userInfo, ref string warningMsg)
		{
			KiSSDB.KbBuchungDataTable buchungen = KbBuchungBLL.GetAlimBelegeFromKbBuchungIDs(kbBuchungIDs);
			int[] faLeistungIDs = KbBuchungBLL.GetDistinctFaLeistungIDs(buchungen);

			string exceptionMessage = "";
			// Submit the BPs that are referenced from the documents
			try
			{
				Vertragsgegenstände vg = new Vertragsgegenstände();
				vg.SubmitLeistungen(faLeistungIDs, userInfo, ref warningMsg);
			}
			catch (Exception ex)
			{
				string msg = string.Format("Fehler beim Anlegen von Vertragsgegenständen: {0}{1}", ex.Message, WebServiceHelperMethods.GetNewLineString());
				Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), msg, ex);
				exceptionMessage += msg;
				// if the creation of the vg failed, the documents won't be successfully created. so abort now
				throw;
			}

			//fetch again, some fields could possibly have been changed (e.g. AnDritte, PscdVertragsgegenstandNr)
			buchungen = KbBuchungBLL.GetAlimBelegeFromKbBuchungIDs(kbBuchungIDs);

			bool success = SubmitAlimBelege(buchungen, userInfo, ref exceptionMessage, ref warningMsg);

			if (!string.IsNullOrEmpty(exceptionMessage))
				throw new Exception(exceptionMessage);
			return success ? CreateObjectResult.Success : CreateObjectResult.Warning;
		}

		private bool SubmitAlimBelege(KiSSDB.KbBuchungDataTable belege, UserInfo user, ref string exceptionMessage, ref string warningMessage)
		{
			bool success = true;
			Log.Info(this.GetType(), string.Format("Sende {0} Alim-Belege", belege.Count));
			foreach (KiSSDB.KbBuchungRow belegRow in belege)
			{
				try
				{
					success &= SubmitAlimBeleg(belegRow, user, ref exceptionMessage, ref warningMessage);
				}
				catch (Exception ex)
				{
					Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
					success = false;
					exceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
				}
			}
			return success;
		}

		private bool SubmitAlimBeleg(KiSSDB.KbBuchungRow belegRow, UserInfo user, ref string exceptionMessage, ref string warningMessage)
		{
			bool success = true;
			if (belegRow.IsKbBuchungStatusCodeNull() || belegRow.KbBuchungStatusCode != 2)
				// Buchung is not ready to be transferred
				return false;

			if (belegRow.IsPscdVertragsgegenstandIDNull())
			{
				string msg = string.Format("Die Leistung zur Buchung mit ID {0} wurde noch nicht PSCD übertragen", belegRow.KbBuchungID);
				exceptionMessage += msg + WebServiceHelperMethods.GetNewLineString();
				Log.Warn(this.GetType(), msg);
				return false;
			}

			KiSSDB.KbBuchungKostenartDataTable positionsTable = KbBuchungBLL.GetPositionsOfBeleg(belegRow.KbBuchungID);
			if (positionsTable.Count == 0)
				return false;

			string belegart = positionsTable[0].Belegart;
			// Check if Belegart is null
			if (string.IsNullOrEmpty(belegart))
			{
				string msg = string.Format("Keine Belegart für KbBuchungKostenart mit ID {0} definiert", positionsTable[0].KbBuchungKostenartID);
				exceptionMessage += msg + WebServiceHelperMethods.GetNewLineString();
				Log.Warn(this.GetType(), msg);
				return false;
			}

			_STZH_SOZ_CD_BELEG_BAPI_ESR esr = new _STZH_SOZ_CD_BELEG_BAPI_ESR();
			using (BelegNr belegNumber = new BelegNr(KeysBLL.GetBelegNr(belegart)))
			{
				string completeDocument = "X";
				BAPIDFKKKO documentHeader = new BAPIDFKKKO();
				documentHeader.DOC_NO = SapHelper.GetDocumentNumber(belegNumber.Number);
				documentHeader.FIKEY = SapHelper.GetAbstimmschluessel();
				documentHeader.APPL_AREA = "P"; // fix value, 'Öffentliche Verwaltung'
				documentHeader.DOC_TYPE = belegart;
				documentHeader.DOC_SOURCE_KEY = "33"; // Belegübernahme
				documentHeader.CURRENCY = "CHF";
				object belegDatum = belegRow["BelegDatum"];
				if (belegDatum == System.DBNull.Value)
					belegDatum = DateTime.Now;
				documentHeader.DOC_DATE = SapHelper.ConvertDateObject(belegDatum); // Belegdatum im Beleg
				documentHeader.POST_DATE = SapHelper.ConvertDateObject(belegRow["Valutadatum"]);
				documentHeader.SINGLE_DOC = " ";
				documentHeader.OBJ_SYS = belegRow.Kostenstelle;

				BAPIRECKEYINFO recKeyInfo = new BAPIRECKEYINFO();
				recKeyInfo.CALLER_ID = SapHelper.GetKissCallerID();

				List<BAPIDFKKOP> partnerPositionList = new List<BAPIDFKKOP>();
				List<BAPIDFKKOPLOCK> lockList = new List<BAPIDFKKOPLOCK>();
				List<BAPI_TE_DFKKOP> dfkkopList = new List<BAPI_TE_DFKKOP>();
				foreach (KiSSDB.KbBuchungKostenartRow positionRow in positionsTable)
				{
					string verwPeriodeVon = SapHelper.ConvertDateObject(positionRow["VerwPeriodeVon"]);
					string verwPeriodeBis = SapHelper.ConvertDateObject(positionRow["VerwPeriodeBis"]);

					BAPIDFKKOP partnerPositionItem = new BAPIDFKKOP();
					BAPI_TE_DFKKOP dfkkopItem = new BAPI_TE_DFKKOP();

					partnerPositionItem.DOC_NO = documentHeader.DOC_NO;
					partnerPositionItem.REP_ITEM = "000"; // ToDo: offen
					partnerPositionItem.ITEM = positionRow.PositionImBeleg.ToString("0000");
					partnerPositionItem.SUB_ITEM = "000"; // fix value
					partnerPositionItem.COMP_CODE = "5550"; // fix value, Standardbuchungskreis
					partnerPositionItem.BUSPARTNER = SapHelper.GetBusinessPartnerNumber(positionRow.BaPersonID);
					partnerPositionItem.CONT_ACCT = SapHelper.GetContractAccountNumber(positionRow.BaPersonID);
					partnerPositionItem.CONTRACT = SapHelper.GetPsObjectNumber(belegRow.PscdVertragsgegenstandID);
					partnerPositionItem.APPL_AREA = "P"; // fix value
					partnerPositionItem.MAIN_TRANS = positionRow.Hauptvorgang.ToString("0000");
					partnerPositionItem.SUB_TRANS = positionRow.Teilvorgang.ToString("0000");
					partnerPositionItem.ACTDETERID = "01"; // ToDo: offen
					partnerPositionItem.CALC_PERLO = verwPeriodeVon;
					partnerPositionItem.CALC_PERHI = verwPeriodeBis;
					if (SapHelper.IsAbgetreten(positionRow.Hauptvorgang))
					{
						// abgetretene Forderungen
						partnerPositionItem.STAT_KEY = "G";
					}
					else
					{
						// nicht abgetretene Forderungen
						dfkkopItem._STZH_SOZ_PYGRP = "";
					}

					if (string.IsNullOrEmpty(documentHeader.POST_DATE))
					{
						documentHeader.POST_DATE = SapHelper.ConvertDateObject(belegRow["Valutadatum"]);
					}
					partnerPositionItem.DOC_DATE = documentHeader.DOC_DATE;
					partnerPositionItem.POST_DATE = documentHeader.POST_DATE;
					partnerPositionItem.NET_DATE = SapHelper.ConvertDateObject(belegRow["Valutadatum"]); // Nettofälligkeitsdatum SapHelper.ConvertDateObject(positionRow["ValutaDatum"]);
					partnerPositionItem.DISC_DUE = partnerPositionItem.NET_DATE; // Skontofälligkeit, identisch mit Nettofälligkeit
					partnerPositionItem.TEXT = positionRow.Buchungstext;
					partnerPositionItem.CURRENCY = "CHF";
					decimal amount = positionRow.Betrag;

					// Auszahldaten
					if (belegRow.IstDebitorBuchung) // Forderung
					{
						if (!belegRow.IsSchuldner_BaPersonIDNull())
							partnerPositionItem.PARTNER = SapHelper.GetBusinessPartnerNumber(belegRow.Schuldner_BaPersonID);
					}
					if (belegRow.IstKreditorBuchung) // Verbindlichkeit
					{
						// Auszahlungen haben ein negatives Vorzeichen (minus -> Geld fliesst vom Konto ab)
						amount = -amount;

						// Submit the Zahlungwseg (where the money gets to or comes from)
						// BK_DETAILS: ID of the Zahlungsweg; received from a previously transmitted Zahlungsweg
						// PMNT_METH: Zahlungsweg: Banküberweisung (nur für Auszahlungen)
						// PARTNER: Number of the business partner who receives the money
						string zahlungswegSapID;
						string pscdAuszahlungsart;
						int? zahlungswegBesitzerBpId = GetBusinessPartnerOfZahlungsweg(belegRow, out zahlungswegSapID, out pscdAuszahlungsart);
						if (!belegRow.IsPscdZahlwegArtNull())
							pscdAuszahlungsart = belegRow.PscdZahlwegArt;

						// Nettobelege werden auf Dritte gebucht
						// zur Not (Barbelege) werden sie auf den Leistungsträger gebucht
						int bpNumber = zahlungswegBesitzerBpId.HasValue ? zahlungswegBesitzerBpId.Value : positionRow.BaPersonID;
						if (pscdAuszahlungsart == "C" && positionsTable.Count > 0 && !positionsTable[0].IsBaPersonIDNull())
							bpNumber = positionsTable[0].BaPersonID;

						partnerPositionItem.BUSPARTNER = SapHelper.GetBusinessPartnerNumber(bpNumber);
						partnerPositionItem.CONT_ACCT = SapHelper.GetContractAccountNumber(bpNumber);
						if (belegRow.AnDritte)
							dfkkopItem._STZH_SOZ_VTREF2 = SapHelper.GetPsObjectNumber(belegRow.PscdVertragsgegenstandID);
						else
							partnerPositionItem.CONTRACT = SapHelper.GetPsObjectNumber(belegRow.PscdVertragsgegenstandID);

						partnerPositionItem.PARTNER = partnerPositionItem.BUSPARTNER;
						partnerPositionItem.PMNT_METH = pscdAuszahlungsart;
						if (pscdAuszahlungsart != "C")
							partnerPositionItem.BK_DETAILS = zahlungswegSapID;

						if (pscdAuszahlungsart == "1")
						{
							if (belegRow.IsReferenzNummerNull())
							{
								exceptionMessage = string.Format("Keine ESR-Referenznummer angegeben für Alim-Nettobeleg mit ID {0}", belegRow.KbBuchungID);
								return false;
							}
							string refNr = belegRow.ReferenzNummer;
							esr.ESRRE = refNr; // Referenznummer
							if (!string.IsNullOrEmpty(refNr) && refNr.Length >= 27)
								esr.ESRPZ = string.IsNullOrEmpty(refNr) ? "" : refNr[refNr.Length - 1].ToString(); // Prüfziffer
							esr.ESRNR = BaZahlungswegBLL.MakePcNr(belegRow.PCKontoNr); // Teilnehmernummer
							esr.NAME1 = belegRow.BeguenstigtName;
							esr.NAME2 = belegRow.BeguenstigtName2;
							esr.STREET = belegRow.BeguenstigtStrasse;
							esr.HOUSE_NUM1 = belegRow.BeguenstigtHausNr;
							esr.POST_CODE1 = belegRow.BeguenstigtPLZ;
							esr.CITY1 = belegRow.BeguenstigtOrt;
						}
						else if (pscdAuszahlungsart == " ") // interne Verrechnung
						{
							partnerPositionItem.ONLY_OFF = "X";
						}
					}

					partnerPositionItem.AMOUNT_LOC_CURR = amount;
					partnerPositionItem.AMOUNT_LOC_CURRSpecified = true;
					partnerPositionItem.AMOUNT = amount;
					partnerPositionItem.AMOUNTSpecified = true;
					partnerPositionItem.DOC_TYPE = positionRow.Belegart;
					//if (!belegRow.IsValutaDatumNull())
					//   partnerPositionItem.FISC_YEAR = belegRow.ValutaDatum.Year.ToString();	// #5292: FISC_YEAR darf nicht befüllt werden
					//partnerPositionItem.AMOUNT_GL = partnerPositionItem.AMOUNT_LOC_CURR;
					//partnerPositionItem.AMOUNT_GLSpecified = true;
					//partnerPositionItem.CURRENCY_GL = "CHF";

					dfkkopItem._STZH_SOZ_MBUDG = "";
					dfkkopItem.DOC_NO = partnerPositionItem.DOC_NO;
					dfkkopItem.REP_ITEM = partnerPositionItem.REP_ITEM;
					dfkkopItem.SUB_ITEM = partnerPositionItem.SUB_ITEM;
					dfkkopItem.ITEM = partnerPositionItem.ITEM;
					dfkkopList.Add(dfkkopItem);

					partnerPositionList.Add(partnerPositionItem);
				}

				// the document header might have no valuta, take the first of the detailpos then
				if (string.IsNullOrEmpty(documentHeader.POST_DATE) && partnerPositionList.Count > 0)
					documentHeader.POST_DATE = partnerPositionList[0].POST_DATE;

				BAPIDFKKOPK[] genledgerPositions = new BAPIDFKKOPK[] { };
				BAPIDFKKOP[] partnerPositions = partnerPositionList.ToArray();
				BAPIRET2[] returnMessages = new BAPIRET2[] { };
				string returnMsg;
				BAPI_TE_DFKKOP[] dfkkop = dfkkopList.ToArray();
				_STZH_SOZ_CD_VK_AUSZAHLDATEN auszahlDaten = new _STZH_SOZ_CD_VK_AUSZAHLDATEN();
				BAPIDFKKOPC[] dfkkopc = new BAPIDFKKOPC[] { };
				BAPIFKKDEFREV_DATES[] dates = new BAPIFKKDEFREV_DATES[] { };
				BAPIDFKKOPKX[] genledgerPositionsExt = new BAPIDFKKOPKX[] { };
				BAPIFKKOPREL[] relations = new BAPIFKKOPREL[] { };
				BAPIDFKKOPLOCK[] locks = lockList.ToArray();
				BAPIDFKKOPW[] repetition = new BAPIDFKKOPW[] { };

				PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF001", svcBuchugsstoff.Url, belegNumber.Number, user);
				try
				{
					returnMsg = svcBuchugsstoff.MI_KISS_BUCHSTOFF001(
						completeDocument,
						documentHeader,
						esr,
						recKeyInfo,
						auszahlDaten,
						ref dfkkopc,
						ref dates,
						ref dfkkop,
						ref genledgerPositions,
						ref genledgerPositionsExt,
						ref relations,
						ref partnerPositions,
						ref locks,
						ref repetition,
						ref returnMessages);
					log.StopWatch();
					log.ReturnMsg = returnMsg;
					log.ErrorMsgs = ParseReturnMessages(returnMessages);
				}
				catch (Exception ex)
				{
					log.StopWatch();
					log.ExceptionMsg = ex.Message;
					Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von Alim-Belegen", ex);
					exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Alim-Belegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, ex.Message, WebServiceHelperMethods.GetNewLineString());
				}
				finally
				{
					log.WriteToDB();
				}

				if (!log.HasErrorOccured())
				{
					// belegNr has beeen successfully used
					// Mark the Buchung as 'sent to SAP'
					belegRow.BelegNr = belegNumber.Number;
					belegRow.KbBuchungStatusCode = 3; // verbucht
					belegRow.TransferDatum = DateTime.Now;
					KbBuchungBLL.Update(belegRow);
					belegNumber.SetNumberSuccessfullyUsed();
				}
				else
				{
					belegRow.KbBuchungStatusCode = 5; // Zahlauftrag fehlerhaft
					belegRow.PscdFehlermeldung = log.GetErrorMsgs(false);
					warningMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Alimbelegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, belegRow.PscdFehlermeldung, WebServiceHelperMethods.GetNewLineString());
					success = false;
					KbBuchungBLL.Update(belegRow);
					ProcessErrorMessages(log.ErrorMsgs, belegNumber);
				}
			}
			return success;
		}

		#endregion

		#region Kg

		public CreateObjectResult SubmitKgBelege(int[] kgBudgetIDs, UserInfo user, ref string warningMsg)
		{
			bool success = true;
			string exceptionMessage = "";
			try
			{
				KiSSDB.KgBuchungDataTable buchungenTable = KgBuchungBLL.GetKgBuchungByIDs(kgBudgetIDs);
				foreach (KiSSDB.KgBuchungRow belegRow in buchungenTable)
				{
					success &= SubmitKgBeleg(belegRow, user, ref exceptionMessage, ref warningMsg);
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

		public CreateObjectResult SubmitKgBeleg(int kgBuchungID, UserInfo user, ref string warningMsg)
		{
			bool success = true;
			string exceptionMessage = "";
			KiSSDB.KgBuchungRow belegRow = KgBuchungBLL.GetKgBuchungByID(kgBuchungID);
			try
			{
				success &= SubmitKgBeleg(belegRow, user, ref exceptionMessage, ref warningMsg);
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

		private bool SubmitKgBeleg(KiSSDB.KgBuchungRow belegRow, UserInfo user, ref string exceptionMessage, ref string warningMessage)
		{
			bool success = true;
			if (belegRow.IsKgBuchungStatusCodeNull() || (belegRow.KgBuchungStatusCode != 2 && belegRow.KgBuchungStatusCode != 4))
				// Buchung is not ready to be transferred
				return true;

			string belegart = "AK"; // VK-Belege

			//using (BelegNr belegNumber = new BelegNr(KeysBLL.GetBelegNr(belegart)))
			{
				BAPIDFKKOPK[] genledgerPositions = new BAPIDFKKOPK[] { };
				_STZH_SOZ_CD_BELEG_BAPI_ESR esr = new _STZH_SOZ_CD_BELEG_BAPI_ESR();
				_STZH_SOZ_CD_VK_AUSZAHLDATEN auszahlDaten = new _STZH_SOZ_CD_VK_AUSZAHLDATEN();
				BAPI_TE_DFKKOP[] dfkkop = null;
				BAPIRET2[] returnMessages = new BAPIRET2[] { };
				BAPIDFKKOP[] partnerPositions = null;
				BAPIDFKKKO documentHeader = new BAPIDFKKKO();
				BAPIRECKEYINFO recKeyInfo = new BAPIRECKEYINFO();
				BAPI_TE_DFKKOP dfkkopItem = new BAPI_TE_DFKKOP();
				BAPIDFKKOPC[] dfkkopc = new BAPIDFKKOPC[] { };
				BAPIFKKDEFREV_DATES[] dates = new BAPIFKKDEFREV_DATES[] { };
				BAPIDFKKOPKX[] genledgerPositionsExt = new BAPIDFKKOPKX[] { };
				BAPIFKKOPREL[] relations = new BAPIFKKOPREL[] { };
				BAPIDFKKOPLOCK[] locks = new BAPIDFKKOPLOCK[] { };
				BAPIDFKKOPW[] repetition = new BAPIDFKKOPW[] { };

				long pscdBelegNr = belegRow.KgBuchungID + KeysBLL.GetFirstID(belegart);
				try
				{
					documentHeader.DOC_NO = SapHelper.GetDocumentNumber(pscdBelegNr);// SapHelper.GetDocumentNumber(belegNumber.Number);//.ToString("000000000000");// (((Int64)kbBuchungID) * 1000000).ToString("000000000000");
					documentHeader.FIKEY = "";// SapHelper.GetAbstimmschluessel();
					documentHeader.APPL_AREA = "P"; // fix value, 'Öffentliche Verwaltung'
					documentHeader.DOC_TYPE = belegart;
					documentHeader.DOC_SOURCE_KEY = "33"; // Belegübernahme
					documentHeader.CURRENCY = "CHF";
					object belegDatum = belegRow["ErstelltDatum"];
					if (belegDatum == System.DBNull.Value)
						belegDatum = DateTime.Now;
					documentHeader.DOC_DATE = SapHelper.ConvertDateObject(belegDatum); // Belegdatum im Beleg
					documentHeader.POST_DATE = SapHelper.ConvertDateObject(belegRow["BuchungsDatum"]);
					documentHeader.SINGLE_DOC = " ";

					recKeyInfo.CALLER_ID = SapHelper.GetKissModulKCallerID();

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

					List<BAPIDFKKOP> partnerPositionList = new List<BAPIDFKKOP>();

					BAPIDFKKOP partnerPositionItem = new BAPIDFKKOP();
					partnerPositionItem.DOC_NO = documentHeader.DOC_NO;
					partnerPositionItem.REP_ITEM = "000"; // ToDo: offen
					partnerPositionItem.ITEM = "0001"; // fix, da nur eine Position
					partnerPositionItem.SUB_ITEM = "000"; // fix value
					partnerPositionItem.COMP_CODE = "5550"; // fix value, Standardbuchungskreis

					// Kg-Belege werden auf Dummy-Geschäftspartner/-Vertragskonto gebucht
					// Es wird kein Vertragsgegenstand angegeben
					int bpNumber = 499999;
					partnerPositionItem.BUSPARTNER = SapHelper.GetBusinessPartnerNumber(bpNumber);
					partnerPositionItem.CONT_ACCT = SapHelper.GetContractAccountNumber(bpNumber);
					partnerPositionItem.PMNT_METH = pscdAuszahlungsart;

					partnerPositionItem.APPL_AREA = "P"; // fix value
					partnerPositionItem.MAIN_TRANS = "9000"; // fix für Kg
					partnerPositionItem.SUB_TRANS = "9000"; // fix für Kg
					partnerPositionItem.ACTDETERID = "01"; // ToDo: offen

					partnerPositionItem.DOC_DATE = documentHeader.DOC_DATE;
					partnerPositionItem.POST_DATE = documentHeader.POST_DATE;
					partnerPositionItem.NET_DATE = SapHelper.ConvertDateObject(belegRow["Valutadatum"]);
					partnerPositionItem.DISC_DUE = partnerPositionItem.NET_DATE; // Skontofälligkeit, identisch mit Nettofälligkeit
					partnerPositionItem.TEXT = belegRow.Text;
					partnerPositionItem.CURRENCY = "CHF";
					decimal amount = -belegRow.Betrag; // Betrag in Kg-Buchhaltung ist positiv, es werden nur Auszahlungen als Beleg an PSCD gesendet
					//if( !belegRow.IsKgBuchungStatusCodeNull() && belegRow.KgBuchungTypCode == 2 )//Auszahlung
					partnerPositionItem.AMOUNT_LOC_CURR = amount;
					partnerPositionItem.AMOUNT_LOC_CURRSpecified = true;
					partnerPositionItem.AMOUNT = amount;
					partnerPositionItem.AMOUNTSpecified = true;
					partnerPositionItem.DOC_TYPE = belegart;
					//if (!belegRow.IsValutaDatumNull())
					//   partnerPositionItem.FISC_YEAR = belegRow.ValutaDatum.Year.ToString();// #5292: FISC_YEAR darf nicht befüllt werden
					partnerPositionList.Add(partnerPositionItem);

					dfkkopItem.DOC_NO = partnerPositionItem.DOC_NO;
					dfkkopItem.REP_ITEM = partnerPositionItem.REP_ITEM;
					dfkkopItem.SUB_ITEM = partnerPositionItem.SUB_ITEM;
					dfkkopItem.ITEM = partnerPositionItem.ITEM;

					// the document header might have no valuta, take the first of the detailpos then
					if (string.IsNullOrEmpty(documentHeader.POST_DATE) && partnerPositionList.Count > 0)
						documentHeader.POST_DATE = partnerPositionList[0].POST_DATE;

					partnerPositions = partnerPositionList.ToArray();
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

					KiSSDB.BaZahlungswegRow quellKonto = BaZahlungswegBLL.GetZahlungswegOfKgPeriode(belegRow.KgPeriodeID);
					if (quellKonto == null)
					{
						RegisterBelegError(belegRow, string.Format("Kein Quellkonto angegeben für KgPeriode mit ID {0}", belegRow.KgPeriodeID), ref warningMessage);
						return false;
					}

					KiSSDB.BaPersonRow klient = BaPersonBLL.GetPersonOfKgPeriode(belegRow.KgPeriodeID);
					KiSSDB.BaAdresseRow klientWma = BaAdresseBLL.GetCurrentWMAOfPerson(klient.BaPersonID);

					auszahlDaten._STZH_SOZ_UBKNT = BaZahlungswegBLL.GetMuCFromZKBAccountNr(BaZahlungswegBLL.GetAccountNumber(quellKonto));
					auszahlDaten._STZH_SOZ_UIBAN = quellKonto.IBANNummer;
					auszahlDaten._STZH_SOZ_AUST1 = string.Format("{0} {1}", klient.Vorname, klient.Name);
					auszahlDaten._STZH_SOZ_AUST2 = string.Format("{0} {1}", klientWma.Strasse, klientWma.HausNr);
					auszahlDaten._STZH_SOZ_AUST3 = string.Format("{0} {1}", klientWma.PLZ, klientWma.Ort);
					auszahlDaten._STZH_SOZ_ZNME1 = belegRow.BeguenstigtName;
					auszahlDaten._STZH_SOZ_ZNME2 = belegRow.BeguenstigtName2;
					if (string.IsNullOrEmpty(belegRow.BeguenstigtStrasse))
					{
						auszahlDaten._STZH_SOZ_ZPFAC = belegRow.BeguenstigtPostfach;
					}
					else
					{
						auszahlDaten._STZH_SOZ_ZSTRA = belegRow.BeguenstigtStrasse;
						auszahlDaten._STZH_SOZ_ZSTR1 = belegRow.BeguenstigtHausNr;
					}
					auszahlDaten._STZH_SOZ_ZPST1 = belegRow.BeguenstigtPLZ;
					auszahlDaten._STZH_SOZ_ZORT1 = belegRow.BeguenstigtOrt;
					if (pscdAuszahlungsart == "I" || pscdAuszahlungsart == "R")
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
						auszahlDaten._STZH_SOZ_ZBNKL = SapHelper.GetClearingNrFromBaBankID(belegRow["BaBankID"], out sapLandCode, !belegRow.IsPostKontoNummerNull());
						auszahlDaten._STZH_SOZ_ZBNKS = sapLandCode;
						auszahlDaten._STZH_SOZ_ZBNKN = BaZahlungswegBLL.GetAccountNumber(zielKonto);
						if (pscdAuszahlungsart == "I" && string.IsNullOrEmpty(belegRow.IBANNummer))
						{
							RegisterBelegError(belegRow, "Keine IBAN für Zielkonto angegeben", ref warningMessage);
							return false;
						}
						auszahlDaten._STZH_SOZ_ZIBAN = SapHelper.RemoveBlanks(belegRow.IBANNummer);
					}
					auszahlDaten._STZH_SOZ_VWZW1 = belegRow.MitteilungZeile1;
					auszahlDaten._STZH_SOZ_VWZW2 = belegRow.MitteilungZeile2;
					auszahlDaten._STZH_SOZ_VWZW3 = belegRow.MitteilungZeile3;
				}
				catch (Exception ex)
				{
					// Unexcpected Error
					RegisterBelegError(belegRow, ex.Message, ref warningMessage);
					return false;
				}
				PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF001", svcBuchugsstoff.Url, pscdBelegNr, user);
				try
				{
					string returnMsg = svcBuchugsstoff.MI_KISS_BUCHSTOFF001(
						"X",
						documentHeader,
						esr,
						recKeyInfo,
						auszahlDaten,
						ref dfkkopc,
						ref dates,
						ref dfkkop,
						ref genledgerPositions,
						ref genledgerPositionsExt,
						ref relations,
						ref partnerPositions,
						ref locks,
						ref repetition,
						ref returnMessages);
					log.StopWatch();
					log.ReturnMsg = returnMsg;
					log.ErrorMsgs = ParseReturnMessages(returnMessages);
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

		private void RegisterBelegError(KiSSDB.KgBuchungRow belegRow, string errorMsg, ref string warningMessage)
		{
			belegRow.KgBuchungStatusCode = 5; // Zahlauftrag fehlerhaft
			belegRow.PscdFehlermeldung = errorMsg;
			warningMessage += string.Format("Beleg {0}: {1}{2}", belegRow.KgBuchungID, errorMsg, WebServiceHelperMethods.GetNewLineString());
			KgBuchungBLL.Update(belegRow);
		}

		private string GetKgZahlungswegInfo(KiSSDB.KgBuchungRow belegRow)
		{
			if (!belegRow.IsKgAuszahlungsArtCodeNull())
			{
				if (belegRow.KgAuszahlungsArtCode == 103) // cash
					return "C";
				else if (belegRow.KgAuszahlungsArtCode == 101) // e-banking
					return ConvertToKgAuszahlungsart(SapHelper.LookupEinzahlungsscheinCode(belegRow["EinzahlungsscheinCode"]));
			}
			return null;
		}

		private static string ConvertToKgAuszahlungsart(string pscdAuszahlungsart)
		{
			// Bank
			if (pscdAuszahlungsart == "3")
				return "I";
			// ESR
			if (pscdAuszahlungsart == "1")
				return "R";
			// Postmandant
			if (pscdAuszahlungsart == "D")
				return "M";

			return pscdAuszahlungsart;
		}

		#endregion

		*/

        #region Zahlungsweg holen

        private int? GetBusinessPartnerByZahlungswegID(int zahlungswegID, out string sapID, out string zahlungsart)
        {
            sapID = null;
            zahlungsart = null;
            KiSSDB.BaZahlungswegRow zahlungswegRow = BaZahlungswegBLL.GetZahlungswegByID(zahlungswegID);
            if (zahlungswegRow == null)
            {
                // Inkonsistente DB, sollte durch FK nicht vorkommen
                throw new Exception(string.Format("Kein Zahlungsweg mit ID '{0}' gefunden", zahlungswegID));
            }
            else
            {
                zahlungsart = SapHelper.LookupEinzahlungsscheinCode(zahlungswegRow["EinzahlungsscheinCode"]);
                int? sapIDtmp = PscdSentBLL.GetSapID(zahlungswegID);
                if (zahlungsart == "3" && !sapIDtmp.HasValue)
                {
                    Log.Warn(this.GetType(), string.Format("Zahlungsweg mit ID '{0}' wurde noch nicht an SAP übermittelt", zahlungswegID));
                    // ToDo: Zahlungsweg übermitteln
                }
                else
                {
                    if (sapIDtmp.HasValue)
                        sapID = sapIDtmp.Value.ToString("0000");
                }
                if (!zahlungswegRow.IsBaPersonIDNull())
                    return zahlungswegRow.BaPersonID;
                else if (!zahlungswegRow.IsBaInstitutionIDNull())
                    return zahlungswegRow.BaInstitutionID;
                else
                    throw new Exception(string.Format("BaZahlungsweg mit ID '{0}' gehört weder einer Person noch einer Institution", zahlungswegID));
            }
        }

        private int? GetBusinessPartnerOfZahlungsweg(KiSSDB.KbBuchungRow belegRow, out string sapID, out string zahlungsart)
        {
            sapID = null;
            zahlungsart = null;
            if (!belegRow.IsKbAuszahlungsArtCodeNull())
                zahlungsart = SapHelper.LookupAuszahlungsArtCode(belegRow.KbAuszahlungsArtCode);
            if (belegRow.IsBaZahlungswegIDNull())
            {
                Log.Warn(this.GetType(), string.Format("Kein Zahlungsweg für KbBuchung mit ID '{0}' abgelegt", belegRow.KbBuchungID));
            }
            else
            {
                int? bpNummer = GetBusinessPartnerByZahlungswegID(belegRow.BaZahlungswegID, out sapID, out zahlungsart);
                string buchungAuszArt = null;
                if (!belegRow.IsKbAuszahlungsArtCodeNull())
                    buchungAuszArt = SapHelper.LookupAuszahlungsArtCode(belegRow.KbAuszahlungsArtCode);
                if (!string.IsNullOrEmpty(buchungAuszArt))
                    zahlungsart = buchungAuszArt;
                return bpNummer;
            }
            return null;
        }

        //private int? GetBusinessPartnerOfZahlungsweg(object kbAuszahlungsArtCode, object baZahlungswegID, int id, out string sapID, out string zahlungsart)
        //{
        //   sapID = null;
        //   zahlungsart = null;
        //   int? kbAuszahlungsArtCodeNb = kbAuszahlungsArtCode as int?;
        //   int? baZahlungswegIDNb = baZahlungswegID as int?;
        //   if (kbAuszahlungsArtCodeNb.HasValue)
        //      zahlungsart = SapHelper.LookupAuszahlungsArtCode(kbAuszahlungsArtCodeNb.Value);
        //   if (!baZahlungswegIDNb.HasValue)
        //   {
        //      Log.Warn(this.GetType(), string.Format("Kein Zahlungsweg für KgBuchung mit ID '{0}' abgelegt", id));
        //   }
        //   else
        //   {
        //      int? bpNummer = GetBusinessPartnerByZahlungswegID(baZahlungswegIDNb.Value, out sapID, out zahlungsart);
        //      string buchungAuszArt = null;
        //      if (kbAuszahlungsArtCodeNb.HasValue)
        //         buchungAuszArt = SapHelper.LookupAuszahlungsArtCode(kbAuszahlungsArtCodeNb.Value);
        //      if (!string.IsNullOrEmpty(buchungAuszArt))
        //         zahlungsart = buchungAuszArt;
        //      return bpNummer;
        //   }
        //   return null;
        //}

        //private int? GetBusinessPartnerOfZahlungsweg(KiSSDB.KbBuchungKostenartBruttoRow positionRow, out string sapID, out string zahlungsart)
        //{
        //   sapID = null;
        //   zahlungsart = SapHelper.LookupAuszahlungsArtCode(positionRow.KbAuszahlungsArtCode);
        //   if (positionRow.IsBaZahlungswegIDNull())
        //   {
        //      Log.Warn(this.GetType(), string.Format("Kein Zahlungsweg für KbBuchungKostenartBrutto mit ID '{0}' abgelegt", positionRow.KbBuchungKostenartBruttoID));
        //   }
        //   else
        //   {
        //      string buchungAuszArt = zahlungsart;
        //      int? bpNummer = GetBusinessPartnerByZahlungswegID(positionRow.BaZahlungswegID, out sapID, out zahlungsart);
        //      if (!string.IsNullOrEmpty(buchungAuszArt))
        //         zahlungsart = buchungAuszArt;
        //      return bpNummer;
        //   }
        //   return null;
        //}

        #endregion

        private KiSSDB.PscdCallReturnMsgDataTable ParseReturnMessages(BAPIRET2[] returnMessages)
        {
            KiSSDB.PscdCallReturnMsgDataTable errorTbl = new KiSSDB.PscdCallReturnMsgDataTable();
            int tempInt;
            foreach (BAPIRET2 retMsg in returnMessages)
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

                if (!string.IsNullOrEmpty(retMsg.TYPE))
                    err.Severity = retMsg.TYPE;

                errorTbl.AddPscdCallReturnMsgRow(err);
            }
            return errorTbl;
        }
    }
}