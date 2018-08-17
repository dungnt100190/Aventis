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
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.BuchungsstoffAnlegen;

namespace KiSSSvc.SAP.PSCD.BudgetData
{
    public class Buchungsstoff
    {
        private const int dummyInvMDASPartner = 499998;
        private MI_KISS_BUCHSTOFF001Service svcBuchungsstoff;

        public Buchungsstoff()
        {
            svcBuchungsstoff = WebServiceSource.GetBuchungsstoffAnlegenWS();
        }

        public CreateObjectResult SubmitWhBelegeByKbBuchungIDs(int[] kbBuchungIDs, int[] kbBuchungBruttoIDs, DateTime valutaDatum, UserInfo userInfo, ref string warningMsg)
        {
            KiSSDB.KbBuchungDataTable nettoBelege = KbBuchungBLL.GetWhBelegeFromKbBuchungIDs(null, kbBuchungIDs, false, false);
            KiSSDB.KbBuchungBruttoDataTable bruttoBelege = KbBuchungBruttoBLL.GetBruttoBelegeByKbBuchungIDs(null, kbBuchungIDs, kbBuchungBruttoIDs);
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
                if (nettoBelege.Count == 1)
                {
                    try
                    {
                        // Fehlermeldung auf Beleg schreiben
                        KiSSDB.KbBuchungRow beleg = nettoBelege[0];
                        beleg.PscdFehlermeldung = SapHelper.GetFehlermeldung(ex);
                        beleg.KbBuchungStatusCode = 5; //Zahlauftrag fehlerhaft
                        KbBuchungBLL.Update(beleg);
                    }
                    catch { }
                }
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), msg, ex);
                exceptionMessage += msg;
                // if the creation of the vg failed, the documents won't be successfully created. so abort now
                throw;
            }

            try
            {
                int[] institutionAndSchuldnerIDs = BaInstitutionBLL.GetInstitutionsAndSchuldnerOfKbBuchungIDs(kbBuchungIDs, kbBuchungBruttoIDs);
                exceptionMessage = SubmitInstitutionsAndSchuldner(exceptionMessage, institutionAndSchuldnerIDs, userInfo, ref warningMsg);
            }
            catch (Exception ex)
            {
                if (nettoBelege.Count == 1)
                {
                    try
                    {
                        // Fehlermeldung auf Beleg schreiben
                        KiSSDB.KbBuchungRow beleg = nettoBelege[0];
                        beleg.PscdFehlermeldung = SapHelper.GetFehlermeldung(ex);
                        beleg.KbBuchungStatusCode = 5; //Zahlauftrag fehlerhaft
                        KbBuchungBLL.Update(beleg);
                    }
                    catch { }
                }
                throw;
            }
            //fetch again, some fields could possibly have been changed (e.g. AnDritte, PscdVertragsgegenstandNr)
            nettoBelege = KbBuchungBLL.GetWhBelegeFromKbBuchungIDs(null, kbBuchungIDs, false, false);
            bruttoBelege = KbBuchungBruttoBLL.GetBruttoBelegeByKbBuchungIDs(null, kbBuchungIDs, kbBuchungBruttoIDs);

            bool success = SubmitWhBelege(nettoBelege, bruttoBelege, valutaDatum, userInfo, ref exceptionMessage, ref warningMsg);

            if (!string.IsNullOrEmpty(exceptionMessage))
                throw new Exception(exceptionMessage);
            return success ? CreateObjectResult.Success : CreateObjectResult.Warning;
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

        private KiSSDB.PscdCallReturnMsgDataTable ParseReturnMessages(BAPIRET2[] returnMessages, out bool exception)
        {
            KiSSDB.PscdCallReturnMsgDataTable errorTbl = new KiSSDB.PscdCallReturnMsgDataTable();
            int tempInt;
            exception = false;
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

                exception |= retMsg.TYPE == "E";
                if (!string.IsNullOrEmpty(retMsg.TYPE))
                    err.Severity = retMsg.TYPE;

                errorTbl.AddPscdCallReturnMsgRow(err);
            }
            return errorTbl;
        }

        private bool SubmitWhBelege(KiSSDB.KbBuchungDataTable nettoBelege, KiSSDB.KbBuchungBruttoDataTable bruttoBelege, DateTime valutaDatum, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        {
            bool success = true;
            //Log.Info(this.GetType(), string.Format("Sende {0} Wh-Belege ({1} Netto, {2} Brutto)", nettoBelege.Count + bruttoBelege.Count, nettoBelege.Count, bruttoBelege.Count));
            foreach (KiSSDB.KbBuchungRow belegRow in nettoBelege)
            {
                try
                {
                    success &= SubmitNettoBeleg(belegRow, valutaDatum, user, ref exceptionMessage, ref warningMessage);
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
                    success &= SubmitBruttoBeleg(null, belegRow, valutaDatum, user, ref exceptionMessage, ref warningMessage);
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

        #region Brutto

        public bool SubmitBruttoBeleg(TransactionHelper transHelper, KiSSDB.KbBuchungBruttoRow belegRow, DateTime valutaDatum, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        {
            bool success = true;
            //if (belegRow.IsKbBuchungStatusCodeNull() || belegRow.KbBuchungStatusCode != 2)
            //   // Buchung is not ready to be transferred
            //   return true;
            if (!belegRow.IsTransferDatumNull())
                return true;
            bool invmdasForderung = belegRow.IsBgBudgetIDNull() && belegRow.KbBuchungTypCode != 5 && belegRow.IsMigDetailBuchungIDNull();
            bool umbuchungsBeleg = !belegRow.IsStorniertKbBuchungBruttoIDNull() || !belegRow.IsNeubuchungVonKbBuchungBruttoIDNull() || !belegRow.IsMigDetailBuchungIDNull();
            bool invmdasUmbuchung = umbuchungsBeleg && belegRow.KbBuchungTypCode == 5 && belegRow.IsBgBudgetIDNull() && belegRow.IsFaLeistungIDNull() && belegRow.IsMigDetailBuchungIDNull();

            if (!invmdasForderung && !invmdasUmbuchung && belegRow.IsPscdVertragsgegenstandIDNull())
            {
                string msg = string.Format("Die Leistung zur Brutto-Buchung mit ID {0} wurde noch nicht PSCD übertragen", belegRow.KbBuchungBruttoID);
                exceptionMessage += msg + WebServiceHelperMethods.GetNewLineString();
                //Log.Warn(this.GetType(), msg);
                return false;
            }

            KiSSDB.KbBuchungBruttoPersonDataTable positionsTable = KbBuchungBruttoBLL.GetPositionsOfBeleg(transHelper, belegRow.KbBuchungBruttoID);
            if (positionsTable.Count == 0)
                return true;

            string belegart = belegRow.Belegart;
            string payment_grp = belegRow.IsGruppierungUmbuchungNull() ? "" : belegRow.GruppierungUmbuchung;
            string soz_mbudg = "";
            string invmdasBpReferenz = "";
            if (!invmdasForderung)
            {
                if (!belegRow.IsBgBudgetIDNull())
                {
                    soz_mbudg = SapHelper.GetBudgetID(belegRow.BgBudgetID, BgBudgetBLL.GetDateOfBudget(belegRow.BgBudgetID)); // ToDo: DB-Zugriffe reduzieren
                    if (belegRow.IsGruppierungUmbuchungNull())
                    {
                        payment_grp = SapHelper.GetGrouping(belegRow.BgBudgetID, umbuchungsBeleg);
                        // Umbuchung, Quellbudget bestimmen
                        if (!belegRow.IsNeubuchungVonKbBuchungBruttoIDNull())
                        {
                            int? bgbudgetID = KbBuchungBruttoBLL.GetBudgetIDOfBruttoBeleg(belegRow.NeubuchungVonKbBuchungBruttoID);
                            if (bgbudgetID.HasValue)
                                payment_grp = SapHelper.GetGrouping(bgbudgetID.Value, true);
                        }
                    }
                }

                if (belegRow.IsHauptvorgangNull() || belegRow.IsTeilvorgangNull())
                {
                    string msg = string.Format("Haupt- und Teilvorgang sind nicht definiert für Bruttobeleg mit ID {0}. Bitte in den Stammdaten eintragen", belegRow.KbBuchungBruttoID);
                    exceptionMessage += msg + WebServiceHelperMethods.GetNewLineString();
                    //Log.Warn(this.GetType(), msg);
                    return false;
                }
            }
            else
            {
                // Die Person soll als Referenz bekannt sein - also holen wir sie uns von der Sicherheitsleistung
                int baPersonID = KbBuchungBruttoBLL.GetPersonOfSicherheitsleistungBuchung(transHelper, belegRow.KbBuchungBruttoID);
                invmdasBpReferenz = SapHelper.GetBusinessPartnerNumber(baPersonID);
            }

            // Check if Belegart is null
            if (string.IsNullOrEmpty(belegart))
            {
                string msg = string.Format("Keine Belegart definiert für KbBuchungBrutto mit ID {0}", belegRow.KbBuchungBruttoID);
                exceptionMessage += msg + WebServiceHelperMethods.GetNewLineString();
                //Log.Warn(this.GetType(), msg);
                return false;
            }
            if (belegRow.IsBelegNrNull())
                belegRow.BelegNr = KeysBLL.GetBelegNr(belegart);

            string completeDocument = "X";
            BAPIDFKKKO documentHeader = new BAPIDFKKKO();
            documentHeader.DOC_NO = SapHelper.GetDocumentNumber(belegRow.BelegNr);
            documentHeader.FIKEY = SapHelper.GetAbstimmschluessel();
            documentHeader.APPL_AREA = "P"; // fix value, 'Öffentliche Verwaltung'
            documentHeader.DOC_TYPE = belegart;
            documentHeader.DOC_SOURCE_KEY = "33"; // Belegübernahme
            documentHeader.CURRENCY = "CHF";

            // Beleg Datum
            object belegDatum = (DateTime)belegRow["BelegDatum"];
            if (belegDatum == System.DBNull.Value)
            {
                belegDatum = DateTime.Today;
            }
            documentHeader.DOC_DATE = SapHelper.ConvertDateObject(belegDatum);

            DateTime ValutaDatumFuerVerwPeriode = DateTime.MinValue;

            // Valuta-Datum
            if (valutaDatum == DateTime.MinValue)
            {
                // Valuta-Datum wurde nicht mitgegeben, d.h. wir verwenden das Valuta-Datum aus dem KissBeleg resp. das heutige Datum (sollte nicht vorkommen)
                object valuta = (DateTime)belegRow["Valutadatum"];
                if (valuta == System.DBNull.Value)
                {
                    valutaDatum = DateTime.Today;
                }
                else
                {
                    valutaDatum = (DateTime)valuta;
                }
            }
            else
            {
                // Das Valuta-Datum wurde mitgegeben.
                // Falls der SplittingCode auf Valuta gesetzt ist, muss auch die Verwendungsperiode mit dem ValutaDatum übersteuert werden
                if (!belegRow.IsBgSplittingArtCodeNull() && belegRow.BgSplittingArtCode == 3) // 3 = Valuta
                {
                    ValutaDatumFuerVerwPeriode = valutaDatum;
                }
            }

            documentHeader.POST_DATE = SapHelper.ConvertDateObject(valutaDatum);

            documentHeader.SINGLE_DOC = " ";
            documentHeader.OBJ_SYS = invmdasForderung && belegRow.IsKostenstelleNull() ? "9010" : belegRow.Kostenstelle;
            if (umbuchungsBeleg)
            {
                int kbbuchungBruttoID = -1;
                if (!belegRow.IsStorniertKbBuchungBruttoIDNull())
                    kbbuchungBruttoID = belegRow.StorniertKbBuchungBruttoID;
                else if (!belegRow.IsNeubuchungVonKbBuchungBruttoIDNull())
                    kbbuchungBruttoID = belegRow.NeubuchungVonKbBuchungBruttoID;

                KiSSDB.KbBuchungBruttoDataTable refbelege = KbBuchungBruttoBLL.GetBruttoBelegeByKbBuchungIDs(transHelper, null, new int[] { kbbuchungBruttoID });
                if (refbelege.Count == 1)
                    documentHeader.REF_DOC_NO = SapHelper.GetDocumentNumber(refbelege[0].BelegNr);
            }
            BAPIRECKEYINFO recKeyInfo = new BAPIRECKEYINFO();
            recKeyInfo.CALLER_ID = SapHelper.GetKissCallerID();

            List<BAPIDFKKOP> partnerPositionList = new List<BAPIDFKKOP>();
            List<BAPIDFKKOPLOCK> lockList = new List<BAPIDFKKOPLOCK>();
            List<BAPI_TE_DFKKOP> dfkkopList = new List<BAPI_TE_DFKKOP>();
            foreach (KiSSDB.KbBuchungBruttoPersonRow positionRow in positionsTable)
            {
                if (positionRow.IsPositionImBelegNull())
                {
                    throw new Exception("PositionImBeleg ist NULL");
                }

                if (positionRow.PositionImBeleg == 0)
                {
                    // Ignoriere diese Position
                    if (positionRow.Betrag != 0)
                    {
                        // Problem: Diese Position hat einen Betrag ungleich 0
                        throw new Exception("PositionImBeleg ist 0 (d.h. wir sollen diese Position nicht ans PSCD schicken), aber der Betrag ist " + positionRow.Betrag);
                    }
                    else
                    {
                        // Weiterfahren mit der nächsten Position
                        continue;
                    }
                }

                BAPIDFKKOP partnerPositionItem = new BAPIDFKKOP();
                BAPI_TE_DFKKOP dfkkopItem = new BAPI_TE_DFKKOP();

                partnerPositionItem.DOC_NO = documentHeader.DOC_NO;
                partnerPositionItem.REP_ITEM = "000"; // ToDo: offen
                partnerPositionItem.ITEM = positionRow.PositionImBeleg.ToString("0000");
                partnerPositionItem.SUB_ITEM = "000"; // fix value
                partnerPositionItem.COMP_CODE = "5550"; // fix value, Standardbuchungskreis
                partnerPositionItem.BUSPARTNER = SapHelper.GetBusinessPartnerNumber(positionRow.BaPersonID);
                partnerPositionItem.CONT_ACCT = SapHelper.GetContractAccountNumber(positionRow.BaPersonID);
                partnerPositionItem.CONTRACT = !belegRow.IsPscdVertragsgegenstandIDNull() ? SapHelper.GetPsObjectNumber(belegRow.PscdVertragsgegenstandID) : "";
                partnerPositionItem.APPL_AREA = "P"; // fix value
                partnerPositionItem.MAIN_TRANS = !belegRow.IsHauptvorgangNull() ? belegRow.Hauptvorgang.ToString("0000") : positionRow.SpezHauptvorgang.ToString("0000");
                partnerPositionItem.SUB_TRANS = !belegRow.IsTeilvorgangNull() ? belegRow.Teilvorgang.ToString("0000") : positionRow.SpezTeilvorgang.ToString("0000");
                partnerPositionItem.ACTDETERID = "01"; // ToDo: offen

                if (ValutaDatumFuerVerwPeriode != DateTime.MinValue && !umbuchungsBeleg)
                {
                    // Dies ist kein Umbuchungsbeleg, d.h. die Verwendungsperiode kann angepasst werden

                    // Verwende das ValutaDatum für die Verwendungsperiode
                    positionRow.VerwPeriodeVon = ValutaDatumFuerVerwPeriode;
                    positionRow.VerwPeriodeBis = ValutaDatumFuerVerwPeriode;

                    partnerPositionItem.CALC_PERLO = SapHelper.ConvertDateObject(ValutaDatumFuerVerwPeriode);
                    partnerPositionItem.CALC_PERHI = SapHelper.ConvertDateObject(ValutaDatumFuerVerwPeriode);

                    // Führe diese Änderung auch auf der Kiss-DB nach
                    KbBuchungBruttoPersonBLL.UpdateVerwPeriode(transHelper, ValutaDatumFuerVerwPeriode, ValutaDatumFuerVerwPeriode, positionRow.KbBuchungBruttoPersonID);
                }
                else
                {
                    partnerPositionItem.CALC_PERLO = SapHelper.ConvertDateObject(positionRow["VerwPeriodeVon"]);
                    partnerPositionItem.CALC_PERHI = SapHelper.ConvertDateObject(positionRow["VerwPeriodeBis"]);
                }

                //alt: if (!umbuchungsBeleg && (invmdasForderung || (SapHelper.IsAbgetreten(belegRow.Hauptvorgang) && belegRow.PscdKennzeichen != "A" && belegRow.PscdKennzeichen != "Z" && belegRow.PscdKennzeichen != "I")))
                if ((belegRow.PscdKennzeichen == "A" ||
                      belegRow.PscdKennzeichen == "Z" ||
                      belegRow.PscdKennzeichen == "I" ||
                      belegRow.PscdKennzeichen == "V" ||
                      belegRow.PscdKennzeichen == "R" ||
                      belegRow.PscdKennzeichen == "N" ||
                      umbuchungsBeleg) &&
                     !invmdasForderung)
                {
                    // nicht abgetretene Forderungen
                    partnerPositionItem.ONLY_OFF = "X";

                    // Setze die Gruppierung in jedem Fall
                    dfkkopItem._STZH_SOZ_PYGRP = payment_grp;

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
                else
                {
                    // Setze hier die Gruppierung nur, wenn sie explizit im KiSS-Beleg vorgegeben ist, oder wenn der KategorieCode = 3 (Verrechnung) ist
                    if (!belegRow.IsGruppierungUmbuchungNull() || KbBuchungBruttoPersonBLL.GetBgKategorieCode(positionRow.KbBuchungBruttoPersonID) == 3)
                    {
                        dfkkopItem._STZH_SOZ_PYGRP = payment_grp;
                    }

                    if (invmdasForderung)
                    {
                        partnerPositionItem.GROUPING = "INV";
                        // Die Person soll als Referenz bekannt sein - also holen wir sie uns von der Sicherheitsleistung
                        if (positionRow.BaPersonID == dummyInvMDASPartner)
                            dfkkopItem._STZH_SOZ_GPART2 = invmdasBpReferenz;
                    }
                    else
                    {
                        // abgetretene Forderungen
                        partnerPositionItem.STAT_KEY = "G";
                    }

                    // Bei Forderungen den Debitor als abweichenden Zahler eintragen
                    if (positionRow.Betrag > 0m)
                    {
                        if (!positionRow.IsSchuldner_BaInstitutionIDNull())
                            partnerPositionItem.PARTNER = SapHelper.GetBusinessPartnerNumber(positionRow.Schuldner_BaInstitutionID);
                        else if (!positionRow.IsSchuldner_BaPersonIDNull())
                            partnerPositionItem.PARTNER = SapHelper.GetBusinessPartnerNumber(positionRow.Schuldner_BaPersonID);
                    }
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
                //   partnerPositionItem.FISC_YEAR = belegRow.ValutaDatum.Year.ToString();		// #5292: FISC_YEAR darf nicht befüllt werden

                //partnerPositionItem.AMOUNT_GL = partnerPositionItem.AMOUNT_LOC_CURR;
                //partnerPositionItem.AMOUNT_GLSpecified = true;
                partnerPositionItem.CURRENCY_GL = "CHF";

                dfkkopItem._STZH_SOZ_MBUDG = soz_mbudg;
                dfkkopItem.DOC_NO = partnerPositionItem.DOC_NO;
                dfkkopItem.REP_ITEM = partnerPositionItem.REP_ITEM;
                dfkkopItem.SUB_ITEM = partnerPositionItem.SUB_ITEM;
                dfkkopItem.ITEM = partnerPositionItem.ITEM;
                dfkkopItem._STZH_SOZ_KBKZ = belegRow.PscdKennzeichen;
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

            BAPI_TE_DFKKKO dossierNumber = new BAPI_TE_DFKKKO();
            //dossierNumber._STZH_SOZ_DOSSNR = belegRow.do

            PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF001", svcBuchungsstoff.Url, belegRow.BelegNr, user);
            bool exception;
            try
            {
                returnMsg = svcBuchungsstoff.MI_KISS_BUCHSTOFF001(
                    completeDocument,
                    documentHeader,
                    esr,
                    recKeyInfo,
                          dossierNumber,
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
                log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
            }
            catch (SoapException ex)
            {
                log.StopWatch();
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von Bruttobelegen", ex);
                log.ExceptionMsg = SapHelper.ProcessSoapException(ex);
                exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Bruttobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungBruttoID, log.ExceptionMsg, WebServiceHelperMethods.GetNewLineString());
            }
            catch (Exception ex)
            {
                log.StopWatch();
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von Bruttobelegen", ex);
                string msg = ex.Message;
                // HTML-Seite 'parsen' um eine anständige Timeout-Fehlermeldung zu erhalten
                if (!string.IsNullOrEmpty(ex.Message) && ex.Message.IndexOf(@"<H2>500 Connection timed out</H2>") > -1)
                    msg = string.Format("Fehler beim Anlegen des Bruttobelegs mit ID {0}: Zwischen XI und PSCD gab es ein Timeout{1}", belegRow.KbBuchungBruttoID, WebServiceHelperMethods.GetNewLineString());
                exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Bruttobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungBruttoID, msg, WebServiceHelperMethods.GetNewLineString());
                log.ExceptionMsg = msg;
            }
            finally
            {
                log.WriteToDB();
            }

            string errorlog = log.GetErrorMsgs(false);

            if (!log.HasErrorOccured())
            {
                // belegNr has beeen successfully used
                // Mark the Buchung as 'sent to SAP'

                if (belegRow.KbBuchungStatusCode != 8)
                {
                    if (belegRow.Betrag > 0)
                    {
                        // Einnahme -> Nettobeleg als verbucht setzen
                        //Log.Info(typeof(KbBuchungBLL), string.Format("SetEinnahmeNettoBelegStatus {0} rows affected",
                        KbBuchungBLL.SetEinnahmeNettoBelegStatus(transHelper, belegRow.KbBuchungBruttoID, 3, null);
                    }
                    belegRow.KbBuchungStatusCode = 3; // verbucht
                }

                belegRow.TransferDatum = DateTime.Now;
                belegRow.ValutaDatum = valutaDatum;
                belegRow.PscdFehlermeldung = "";    // Lösche die Fehlermeldung, falls sie von einer vorherigen Übertragung noch gesetzt war
                KbBuchungBruttoBLL.Update(transHelper, belegRow);
            }
            else if (errorlog.Contains("Beleg buchen: Belegnummer") && errorlog.Contains("ist bereits vergeben"))
            {
                // Der Beleg war schon früher mal korrekt ans PSCD übermittelt worden, war dann aber im Kiss hängengeblieben.
                // Wir akzeptieren dies hier normal verarbeiteter Beleg, schreiben aber einen Kommentar ins PSCD-Fehlermeldungs-Feld
                belegRow.PscdFehlermeldung = KiSSSvc.SAP.Helpers.SapHelper.TruncateFehlermeldung("Der Brutto-Beleg " + belegRow.KbBuchungBruttoID + " / " + belegRow.BelegNr + " wurde von PSCD zurückgewiesen (Belegnummer existiert bereits), was darauf schliessen lässt, dass dieser Beleg bereits früher korrekt verarbeitet wurde. Daher wird dieser Beleg als übermittelt deklariert.");

                // belegNr has beeen successfully used
                // Mark the Buchung as 'sent to SAP'
                if (belegRow.KbBuchungStatusCode != 8)
                {
                    if (belegRow.Betrag > 0)
                    {
                        // Einnahme -> Nettobeleg als verbucht setzen
                        //Log.Info(typeof(KbBuchungBLL), string.Format("SetEinnahmeNettoBelegStatus {0} rows affected",
                        KbBuchungBLL.SetEinnahmeNettoBelegStatus(transHelper, belegRow.KbBuchungBruttoID, 3, null);
                    }
                    belegRow.KbBuchungStatusCode = 3; // verbucht
                }

                belegRow.TransferDatum = DateTime.Now;
                belegRow.ValutaDatum = valutaDatum;
                KbBuchungBruttoBLL.Update(transHelper, belegRow);
            }
            else
            {
                if (belegRow.KbBuchungStatusCode != 8)
                    belegRow.KbBuchungStatusCode = 5; // Zahlauftrag fehlerhaft

                belegRow.PscdFehlermeldung = log.GetErrorMsgs(false);

                warningMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Bruttobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungBruttoID, belegRow.PscdFehlermeldung, WebServiceHelperMethods.GetNewLineString());

                success = false;
                KbBuchungBruttoBLL.Update(transHelper, belegRow);
                if (belegRow.KbBuchungStatusCode != 8)
                {
                    if (belegRow.Betrag > 0)
                    {
                        // Einnahme -> Nettobeleg als fehlerhaft setzen
                        KbBuchungBLL.SetEinnahmeNettoBelegStatus(transHelper, belegRow.KbBuchungBruttoID, 5, belegRow.PscdFehlermeldung);
                    }
                }
                //ProcessErrorMessages(log.ErrorMsgs, belegRow.BelegNr);
            }

            return success;
        }

        /*
        private void ProcessErrorMessages(KiSSDB.PscdCallReturnMsgDataTable pscdCallReturnMsgDataTable, BelegNr belegNumber)
        {
            if (pscdCallReturnMsgDataTable == null)
                return;
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
         */

        #endregion

        #region Netto

        private bool SubmitNettoBeleg(KiSSDB.KbBuchungRow belegRow, DateTime valutaDatum, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        {
            bool success = true;
            //if (belegRow.IsKbBuchungStatusCodeNull() || belegRow.KbBuchungStatusCode != 2)
            //   // Buchung is not ready to be transferred
            //   return true;
            if (!belegRow.IsTransferDatumNull())
            {
                if (belegRow.KbBuchungStatusCode == 16)
                {
                    // Rückläufer korrigiert -> Beleg im PSCD ändern
                    return (new BuchungsstoffMutieren()).SubmitNettoBeleg(belegRow, user, ref exceptionMessage, ref warningMessage);
                }
                else
                {
                    return true;
                }
            }

            if (belegRow.IsPscdVertragsgegenstandIDNull())
            {
                string msg = string.Format("Die Leistung zur Buchung mit ID {0} wurde noch nicht PSCD übertragen", belegRow.KbBuchungID);
                exceptionMessage += msg + WebServiceHelperMethods.GetNewLineString();
                //Log.Warn(this.GetType(), msg);
                return false;
            }

            if (belegRow.IsModulIDNull())
            {
                string msg = string.Format("Die Nettobuchung mit ID {0} ist keinem Modul zugeordnet (ModulID = NULL)", belegRow.KbBuchungID);
                exceptionMessage += msg + WebServiceHelperMethods.GetNewLineString();
                return false;
            }

            if (belegRow.ModulID == 3 && belegRow.IsIkPositionIDNull() && belegRow.IstDebitorBuchung)
            {
                // Forderungs-Nettobelege dürfen nicht übertragen werden
                return true;
            }

            if (belegRow.Betrag == 0m)
            {
                // 0er-Nettobelege werden nicht übertragen, die Bruttobelege dazu schon. Deshalb ist das hier kein Fehler
                belegRow.KbBuchungStatusCode = 6;//verbucht
                KbBuchungBLL.Update(belegRow);
                Log.Info(typeof(KbBuchungBLL), "Netto 0er -> verbucht");
                return true;
            }

            KiSSDB.KbBuchungKostenartDataTable positionsTable = KbBuchungBLL.GetPositionsOfBeleg(belegRow.KbBuchungID);
            if (positionsTable.Count == 0)
                return true;

            string belegart = "AA"; // Nettobelege, "Auszahlanweisung"
            string payment_grp = "";
            string soz_mbudg = "";
            if (!belegRow.IsBgBudgetIDNull())
            {
                payment_grp = SapHelper.GetGrouping(belegRow.BgBudgetID, false);
                soz_mbudg = SapHelper.GetBudgetID(belegRow.BgBudgetID, BgBudgetBLL.GetDateOfBudget(belegRow.BgBudgetID)); // ToDo: DB-Zugriffe reduzieren
            }
            long pscdVgID = belegRow.PscdVertragsgegenstandID;

            if (belegRow.IsBelegNrNull())
                belegRow.BelegNr = KeysBLL.GetBelegNr(belegart);

            string completeDocument = "X";
            BAPIDFKKKO documentHeader = new BAPIDFKKKO();
            documentHeader.DOC_NO = SapHelper.GetDocumentNumber(belegRow.BelegNr);
            documentHeader.FIKEY = SapHelper.GetAbstimmschluessel();
            documentHeader.APPL_AREA = "P"; // fix value, 'Öffentliche Verwaltung'
            documentHeader.DOC_TYPE = belegart;
            documentHeader.DOC_SOURCE_KEY = "33"; // Belegübernahme
            documentHeader.CURRENCY = "CHF";

            // Beleg Datum
            object belegDatum = (DateTime)belegRow["BelegDatum"];
            if (belegDatum == System.DBNull.Value)
            {
                belegDatum = DateTime.Today;
            }
            documentHeader.DOC_DATE = SapHelper.ConvertDateObject(belegDatum);

            DateTime ValutaDatumFuerVerwPeriode = DateTime.MinValue;

            // Valuta-Datum
            if (valutaDatum == DateTime.MinValue)
            {
                // Valuta-Datum wurde nicht mitgegeben, d.h. wir verwenden das Valuta-Datum aus dem KissBeleg resp. das heutige Datum (sollte nicht vorkommen)
                object valuta = (DateTime)belegRow["Valutadatum"];
                if (valuta == System.DBNull.Value)
                {
                    valutaDatum = DateTime.Today;
                }
                else
                {
                    valutaDatum = (DateTime)valuta;
                }
            }
            else
            {
                foreach (KiSSDB.KbBuchungKostenartRow kostenartRow in belegRow.GetKbBuchungKostenartRows())
                {
                    if (KbBuchungKostenartBLL.GetSplittingArtCode(kostenartRow.KbBuchungKostenartID) == 3) // 3 = Valuta
                    {
                        // Das Valuta-Datum wurde mitgegeben.
                        // Und der SplittingCode ist auf Valuta gesetzt ist, muss auch die Verwendungsperiode mit dem ValutaDatum übersteuert werden

                        // Führe diese Änderung auf der Kiss-DB nach
                        KbBuchungKostenartBLL.UpdateVerwPeriode(valutaDatum, valutaDatum, kostenartRow.KbBuchungKostenartID);
                    }
                }
            }

            documentHeader.POST_DATE = SapHelper.ConvertDateObject(valutaDatum);

            documentHeader.SINGLE_DOC = " ";
            documentHeader.OBJ_SYS = belegRow.Kostenstelle;

            BAPIRECKEYINFO recKeyInfo = new BAPIRECKEYINFO();
            recKeyInfo.CALLER_ID = SapHelper.GetKissCallerID();

            string zahlungswegSapID;
            string zahlungswegSapIDAddress;
            string pscdAuszahlungsart;
            int? zahlungswegBesitzerBpId = GetBusinessPartnerOfZahlungsweg(belegRow, out zahlungswegSapID, out pscdAuszahlungsart, out zahlungswegSapIDAddress);
            if (!belegRow.IsPscdZahlwegArtNull())
                pscdAuszahlungsart = belegRow.PscdZahlwegArt;

            List<BAPIDFKKOP> partnerPositionList = new List<BAPIDFKKOP>();

            BAPIDFKKOP partnerPositionItem = new BAPIDFKKOP();
            BAPI_TE_DFKKOP dfkkopItem = new BAPI_TE_DFKKOP();

            partnerPositionItem.DOC_NO = documentHeader.DOC_NO;
            partnerPositionItem.REP_ITEM = "000"; // ToDo: offen
            partnerPositionItem.ITEM = "0001"; // fix, da nur eine Position
            partnerPositionItem.SUB_ITEM = "000"; // fix value
            partnerPositionItem.COMP_CODE = "5550"; // fix value, Standardbuchungskreis

            // Nettobelege werden auf Dritte gebucht (wenn sie an Dritte ausbezahlt werden)
            // zur Not (Barbelege) werden sie auf den Leistungsträger gebucht
            int bpNumber = zahlungswegBesitzerBpId.HasValue ? zahlungswegBesitzerBpId.Value : belegRow.BaPersonID_LT;
            // Für Barauszahlungen werden sie auf die Person der Detailposition gebucht. Der Leistungsträger muss nicht zwingend im Finanzplan dabei sein und ist daher ev. nicht in PSDC angelegt. Dann könnte der Beleg nicht verbucht werden
            if (pscdAuszahlungsart == "C" && positionsTable.Count > 0 && !positionsTable[0].IsBaPersonIDNull())
                bpNumber = positionsTable[0].BaPersonID;
            partnerPositionItem.BUSPARTNER = SapHelper.GetBusinessPartnerNumber(bpNumber);
            partnerPositionItem.CONT_ACCT = SapHelper.GetContractAccountNumber(bpNumber);
            if (belegRow.AnDritte && pscdAuszahlungsart != "C")
                dfkkopItem._STZH_SOZ_VTREF2 = SapHelper.GetPsObjectNumber(pscdVgID);
            else
                partnerPositionItem.CONTRACT = SapHelper.GetPsObjectNumber(pscdVgID);

            partnerPositionItem.PARTNER = partnerPositionItem.BUSPARTNER;
            partnerPositionItem.PMNT_METH = pscdAuszahlungsart;
            if (pscdAuszahlungsart != "C")
            {
                partnerPositionItem.BK_DETAILS = zahlungswegSapID;
                partnerPositionItem.ADDR_NO = zahlungswegSapIDAddress;
            }
            partnerPositionItem.APPL_AREA = "P"; // fix value
            partnerPositionItem.MAIN_TRANS = "2000";
            partnerPositionItem.SUB_TRANS = "2100";
            partnerPositionItem.ACTDETERID = "01"; // ToDo: offen

            partnerPositionItem.DOC_DATE = documentHeader.DOC_DATE;
            partnerPositionItem.POST_DATE = documentHeader.POST_DATE;
            partnerPositionItem.NET_DATE = documentHeader.POST_DATE;
            partnerPositionItem.DISC_DUE = documentHeader.POST_DATE; // Skontofälligkeit, identisch mit Nettofälligkeit
            partnerPositionItem.TEXT = belegRow.Text;
            partnerPositionItem.CURRENCY = "CHF";
            partnerPositionItem.STAT_KEY = "Z"; // Zahlungsanweisung
            decimal amount = belegRow.Betrag;
            if (belegRow.IstKreditorBuchung)
                amount = -amount;

            partnerPositionItem.AMOUNT_LOC_CURR = amount;
            partnerPositionItem.AMOUNT_LOC_CURRSpecified = true;
            partnerPositionItem.AMOUNT = amount;
            partnerPositionItem.AMOUNTSpecified = true;
            partnerPositionItem.DOC_TYPE = belegart;
            dfkkopItem._STZH_SOZ_PYGRP = payment_grp;
            dfkkopItem._STZH_SOZ_VWZW1 = belegRow.MitteilungZeile1;
            dfkkopItem._STZH_SOZ_VWZW2 = belegRow.MitteilungZeile2;
            //if (!belegRow.IsValutaDatumNull())
            //   partnerPositionItem.FISC_YEAR = belegRow.ValutaDatum.Year.ToString();		// #5292: FISC_YEAR darf nicht befüllt werden
            //partnerPositionItem.AMOUNT_GL = partnerPositionItem.AMOUNT_LOC_CURR;
            //partnerPositionItem.AMOUNT_GLSpecified = true;
            //partnerPositionItem.CURRENCY_GL = "CHF";
            //			partnerPositionItem.G_L_ACCT = "36605110";
            partnerPositionList.Add(partnerPositionItem);

            //						if (belegRow.Dritte)
            //							dfkkopItem._STZH_SOZ_GPART2 = partnerPositionItem.BUSPARTNER;
            dfkkopItem._STZH_SOZ_MBUDG = soz_mbudg;

            dfkkopItem.DOC_NO = partnerPositionItem.DOC_NO;
            dfkkopItem.REP_ITEM = partnerPositionItem.REP_ITEM;
            dfkkopItem.SUB_ITEM = partnerPositionItem.SUB_ITEM;
            dfkkopItem.ITEM = partnerPositionItem.ITEM;
            if (positionsTable.Count > 0)
                dfkkopItem._STZH_SOZ_KBKZ = "A"; // Nettoauszahlungen sind immer 'A'

            // the document header might have no valuta, take the first of the detailpos then
            if (string.IsNullOrEmpty(documentHeader.POST_DATE) && partnerPositionList.Count > 0)
                documentHeader.POST_DATE = partnerPositionList[0].POST_DATE;

            BAPIDFKKOPK[] genledgerPositions = new BAPIDFKKOPK[] { };
            BAPIDFKKOP[] partnerPositions = partnerPositionList.ToArray();
            BAPIRET2[] returnMessages = new BAPIRET2[] { };
            string returnMsg;
            BAPI_TE_DFKKOP[] dfkkop = new BAPI_TE_DFKKOP[] { dfkkopItem };
            _STZH_SOZ_CD_BELEG_BAPI_ESR esr = new _STZH_SOZ_CD_BELEG_BAPI_ESR();
            if (pscdAuszahlungsart == "1")
            {
                if (belegRow.IsReferenzNummerNull())
                {
                    RegisterBelegError(belegRow, string.Format("Keine ESR-Referenznummer angegeben für Nettobeleg mit ID {0}", belegRow.KbBuchungID), ref  warningMessage);
                    exceptionMessage += string.Format("Keine ESR-Referenznummer angegeben für Nettobeleg mit ID {0}", belegRow.KbBuchungID);
                    return false;
                }
                string refNr = belegRow.ReferenzNummer;
                esr.ESRRE = refNr; // Referenznummer
                if (!string.IsNullOrEmpty(refNr) && refNr.Length >= 27)
                    esr.ESRPZ = refNr[refNr.Length - 1].ToString(); // Prüfziffer
                esr.ESRNR = BaZahlungswegBLL.MakePcNr(belegRow.PCKontoNr); // Teilnehmernummer -> PC-Nummer
                esr.NAME1 = belegRow.BeguenstigtName;
                esr.NAME2 = belegRow.BeguenstigtName2;
                esr.STREET = belegRow.BeguenstigtStrasse;
                esr.HOUSE_NUM1 = belegRow.BeguenstigtHausNr;
                esr.POST_CODE1 = belegRow.BeguenstigtPLZ;
                esr.CITY1 = belegRow.BeguenstigtOrt;
            }
            _STZH_SOZ_CD_VK_AUSZAHLDATEN auszahlDaten = new _STZH_SOZ_CD_VK_AUSZAHLDATEN();
            BAPIDFKKOPC[] dfkkopc = new BAPIDFKKOPC[] { };
            BAPIFKKDEFREV_DATES[] dates = new BAPIFKKDEFREV_DATES[] { };
            BAPIDFKKOPKX[] genledgerPositionsExt = new BAPIDFKKOPKX[] { };
            BAPIFKKOPREL[] relations = new BAPIFKKOPREL[] { };
            BAPIDFKKOPLOCK[] locks = new BAPIDFKKOPLOCK[] { };
            BAPIDFKKOPW[] repetition = new BAPIDFKKOPW[] { };

            BAPI_TE_DFKKKO dossierNumber = new BAPI_TE_DFKKKO();
            dossierNumber._STZH_SOZ_DOSSNR = belegRow.Dossiernummer;

            PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF001", svcBuchungsstoff.Url, belegRow.BelegNr, user);
            bool exception;
            try
            {
                returnMsg = svcBuchungsstoff.MI_KISS_BUCHSTOFF001(
                    completeDocument,
                    documentHeader,
                    esr,
                    recKeyInfo,
             dossierNumber,
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
                log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
            }
            catch (SoapException ex)
            {
                log.StopWatch();
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von Nettobelegen", ex);
                log.ExceptionMsg = SapHelper.ProcessSoapException(ex);
                exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Nettobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, log.ExceptionMsg, WebServiceHelperMethods.GetNewLineString());
            }
            catch (Exception ex)
            {
                log.StopWatch();
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von Nettobelegen", ex);
                string msg = ex.Message;
                // HTML-Seite 'parsen' um eine anständige Timeout-Fehlermeldung zu erhalten
                if (!string.IsNullOrEmpty(ex.Message) && ex.Message.IndexOf(@"<H2>500 Connection timed out</H2>") > -1)
                    msg = string.Format("Fehler beim Anlegen des Nettobelegs mit ID {0}: Zwischen XI und PSCD gab es ein Timeout{1}", belegRow.KbBuchungID, WebServiceHelperMethods.GetNewLineString());
                exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Nettobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, msg, WebServiceHelperMethods.GetNewLineString());
                log.ExceptionMsg = msg;
            }
            finally
            {
                log.WriteToDB();
            }

            string errorlog = log.GetErrorMsgs(false);

            if (!log.HasErrorOccured())
            {
                belegRow.KbBuchungStatusCode = 3; //Zahlauftrag erstellt
                belegRow.TransferDatum = DateTime.Now;
                belegRow.ValutaDatum = valutaDatum;
                belegRow.PscdFehlermeldung = "";    // Lösche die Fehlermeldung, falls sie von einer vorherigen Übertragung noch gesetzt war
                KbBuchungBLL.Update(belegRow);
            }
            else if (errorlog.Contains("Beleg buchen: Belegnummer") && errorlog.Contains("ist bereits vergeben"))
            {
                // Der Beleg war schon früher mal korrekt ans PSCD übermittelt worden, war dann aber im Kiss hängengeblieben.
                // Wir akzeptieren dies hier normal verarbeiteter Beleg, schreiben aber einen Kommentar ins PSCD-Fehlermeldungs-Feld
                belegRow.PscdFehlermeldung = KiSSSvc.SAP.Helpers.SapHelper.TruncateFehlermeldung("Der Netto-Beleg " + belegRow.KbBuchungID + " / " + belegRow.BelegNr + " wurde von PSCD zurückgewiesen (Belegnummer existiert bereits), was darauf schliessen lässt, dass dieser Beleg bereits früher korrekt verarbeitet wurde. Daher wird dieser Beleg als übermittelt deklariert.");

                belegRow.KbBuchungStatusCode = 3; //Zahlauftrag erstellt
                belegRow.TransferDatum = DateTime.Now;
                belegRow.ValutaDatum = valutaDatum;
                KbBuchungBLL.Update(belegRow);
            }
            else
            {
                belegRow.KbBuchungStatusCode = 5; // Zahlauftrag fehlerhaft
                belegRow.PscdFehlermeldung = log.GetErrorMsgs(false);
                warningMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Nettobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, belegRow.PscdFehlermeldung, WebServiceHelperMethods.GetNewLineString());
                success = false;
                KbBuchungBLL.Update(belegRow);
            }
            return success;
        }

        #endregion

        #region Alim: KiSS Netto, PSCD Brutto

        public CreateObjectResult SubmitAlimBelegeByKbBuchungIDs(int[] kbBuchungIDs, DateTime valutaDatum, UserInfo userInfo, ref string warningMsg)
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
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                if (buchungen.Count == 1)
                {
                    try
                    {
                        // Fehlermeldung auf Beleg schreiben
                        KiSSDB.KbBuchungRow beleg = buchungen[0];
                        beleg.PscdFehlermeldung = SapHelper.GetFehlermeldung(ex);
                        beleg.KbBuchungStatusCode = 5; //Zahlauftrag fehlerhaft
                        KbBuchungBLL.Update(beleg);
                    }
                    catch (Exception exx)
                    {
                        Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), exx);
                    }
                }
                exceptionMessage += msg;
                // if the creation of the vg failed, the documents won't be successfully created. so abort now
                throw;
            }
            try
            {
                int[] institutionAndSchuldnerIDs = BaInstitutionBLL.GetInstitutionsAndSchuldnerOfKbBuchungIDs(kbBuchungIDs, null);
                exceptionMessage = SubmitInstitutionsAndSchuldner(exceptionMessage, institutionAndSchuldnerIDs, userInfo, ref warningMsg);
            }
            catch (Exception ex)
            {
                if (buchungen.Count == 1)
                {
                    try
                    {
                        // Fehlermeldung auf Beleg schreiben
                        KiSSDB.KbBuchungRow beleg = buchungen[0];
                        beleg.PscdFehlermeldung = SapHelper.GetFehlermeldung(ex);
                        beleg.KbBuchungStatusCode = 5; //Zahlauftrag fehlerhaft
                        KbBuchungBLL.Update(beleg);
                    }
                    catch { }
                }
                throw;
            }

            //fetch again, some fields could possibly have been changed (e.g. AnDritte, PscdVertragsgegenstandNr)
            buchungen = KbBuchungBLL.GetAlimBelegeFromKbBuchungIDs(kbBuchungIDs);

            bool success = SubmitAlimBelege(buchungen, valutaDatum, userInfo, ref exceptionMessage, ref warningMsg);

            if (!string.IsNullOrEmpty(exceptionMessage))
                throw new Exception(exceptionMessage);
            return success ? CreateObjectResult.Success : CreateObjectResult.Warning;
        }

        private bool SubmitAlimBeleg(KiSSDB.KbBuchungRow belegRow, DateTime valutaDatum, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        {
            bool success = true;
            //if (belegRow.IsKbBuchungStatusCodeNull() || belegRow.KbBuchungStatusCode != 2)
            //   // Buchung is not ready to be transferred
            //   return false;
            if (!belegRow.IsTransferDatumNull())
            {
                if (belegRow.KbBuchungStatusCode == 16)
                {
                    // Rückläufer korrigiert -> Beleg im PSCD ändern
                    return (new BuchungsstoffMutieren()).SubmitNettoBeleg(belegRow, user, ref exceptionMessage, ref warningMessage);
                }
                else
                {
                    warningMessage += string.Format("Alim-Buchung mit ID {0} wurde bereits an PSCD übertragen (Transferdatum ist ausgefüllt)", belegRow.KbBuchungID);
                    return true;
                }
            }
            // Buchung ist weder Kreditor- noch Debitorbuchung
            if (!belegRow.IstDebitorBuchung && !belegRow.IstKreditorBuchung)
            {
                warningMessage += string.Format("Alim-Buchung mit ID {0} ist weder Kreditor- noch Debitorbuchung", belegRow.KbBuchungID);
                return true;
            }

            if (belegRow.IsPscdVertragsgegenstandIDNull())
            {
                string msg = string.Format("Die Leistung zur Alim-Buchung mit ID {0} wurde noch nicht PSCD übertragen", belegRow.KbBuchungID);
                RegisterBelegError(belegRow, msg, ref  warningMessage);
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
                //Log.Warn(this.GetType(), msg);
                return false;
            }

            if (belegRow.IsBelegNrNull())
                belegRow.BelegNr = KeysBLL.GetBelegNr(belegart);

            _STZH_SOZ_CD_BELEG_BAPI_ESR esr = new _STZH_SOZ_CD_BELEG_BAPI_ESR();
            string completeDocument = "X";
            BAPIDFKKKO documentHeader = new BAPIDFKKKO();
            documentHeader.DOC_NO = SapHelper.GetDocumentNumber(belegRow.BelegNr);
            documentHeader.FIKEY = SapHelper.GetAbstimmschluessel();
            documentHeader.APPL_AREA = "P"; // fix value, 'Öffentliche Verwaltung'
            documentHeader.DOC_TYPE = belegart;
            documentHeader.DOC_SOURCE_KEY = "33"; // Belegübernahme
            documentHeader.CURRENCY = "CHF";

            // Beleg Datum
            object belegDatum = (DateTime)belegRow["BelegDatum"];
            if (belegDatum == System.DBNull.Value)
            {
                belegDatum = DateTime.Today;
            }
            documentHeader.DOC_DATE = SapHelper.ConvertDateObject(belegDatum);

            bool VerwPeriodeMitValutaDatumUebersteuern = false;

            // Valuta-Datum
            if (valutaDatum == DateTime.MinValue)
            {
                // Valuta-Datum wurde nicht mitgegeben, d.h. wir verwenden das Valuta-Datum aus dem KissBeleg resp. das heutige Datum (sollte nicht vorkommen)
                object valuta = (DateTime)belegRow["Valutadatum"];
                if (valuta == System.DBNull.Value)
                {
                    valutaDatum = DateTime.Today;
                }
                else
                {
                    valutaDatum = (DateTime)valuta;
                }
            }
            else
            {
                // Das Valuta-Datum wurde mitgegeben.
                // Falls der SplittingCode auf Valuta gesetzt ist,
                // muss auch die Verwendungsperiode mit dem ValutaDatum übersteuert werden (siehe weiter unten)
                VerwPeriodeMitValutaDatumUebersteuern = true;
            }

            documentHeader.POST_DATE = SapHelper.ConvertDateObject(valutaDatum);
            documentHeader.SINGLE_DOC = " ";
            documentHeader.OBJ_SYS = belegRow.Kostenstelle;

            BAPIRECKEYINFO recKeyInfo = new BAPIRECKEYINFO();
            recKeyInfo.CALLER_ID = SapHelper.GetKissCallerID();

            List<BAPIDFKKOP> partnerPositionList = new List<BAPIDFKKOP>();
            List<BAPIDFKKOPLOCK> lockList = new List<BAPIDFKKOPLOCK>();
            List<BAPI_TE_DFKKOP> dfkkopList = new List<BAPI_TE_DFKKOP>();
            foreach (KiSSDB.KbBuchungKostenartRow positionRow in positionsTable)
            {
                if (positionRow.IsPositionImBelegNull())
                {
                    throw new Exception("PositionImBeleg ist NULL");
                }

                if (positionRow.PositionImBeleg == 0)
                {
                    // Ignoriere diese Position
                    if (positionRow.Betrag > 0)
                    {
                        // Problem: Diese Position hat einen Betrag > 0
                        throw new Exception("PositionImBeleg ist 0 (d.h. wir sollen diese Position nicht ans PSCD schicken), aber der Betrag ist " + positionRow.Betrag);
                    }
                    else
                    {
                        // Weiterfahren mit der nächsten Position
                        continue;
                    }
                }

                string verwPeriodeVon = SapHelper.ConvertDateObject(positionRow["VerwPeriodeVon"]);
                string verwPeriodeBis = SapHelper.ConvertDateObject(positionRow["VerwPeriodeBis"]);
                int baPersonID = !positionRow.IsBaPersonIDNull() ? positionRow.BaPersonID : belegRow.IstDebitorBuchung && !belegRow.IsSchuldner_BaPersonIDNull() ? belegRow.Schuldner_BaPersonID : -1;
                if (baPersonID == -1)
                    throw new Exception("Fehlerhafte Buchung: Sowohl KbBuchungKostenart.BaPersonID als auch KbBuchung.Schuldner_BaPersonID sind NULL!");

                BAPIDFKKOP partnerPositionItem = new BAPIDFKKOP();
                BAPI_TE_DFKKOP dfkkopItem = new BAPI_TE_DFKKOP();

                partnerPositionItem.DOC_NO = documentHeader.DOC_NO;
                partnerPositionItem.REP_ITEM = "000"; // ToDo: offen
                partnerPositionItem.ITEM = positionRow.PositionImBeleg.ToString("0000");
                partnerPositionItem.SUB_ITEM = "000"; // fix value
                partnerPositionItem.COMP_CODE = "5550"; // fix value, Standardbuchungskreis
                partnerPositionItem.BUSPARTNER = SapHelper.GetBusinessPartnerNumber(baPersonID);
                partnerPositionItem.CONT_ACCT = SapHelper.GetContractAccountNumber(baPersonID);
                partnerPositionItem.CONTRACT = SapHelper.GetPsObjectNumber(belegRow.PscdVertragsgegenstandID);
                partnerPositionItem.APPL_AREA = "P"; // fix value
                partnerPositionItem.MAIN_TRANS = positionRow.Hauptvorgang.ToString("0000");
                partnerPositionItem.SUB_TRANS = positionRow.Teilvorgang.ToString("0000");
                partnerPositionItem.ACTDETERID = "01"; // ToDo: offen

                if (VerwPeriodeMitValutaDatumUebersteuern && KbBuchungKostenartBLL.GetSplittingArtCode(positionRow.KbBuchungKostenartID) == 3) // 3 = Valuta
                {
                    // Das Valuta-Datum wurde mitgegeben.
                    // Und der SplittingCode ist auf Valuta gesetzt ist, muss auch die Verwendungsperiode mit dem ValutaDatum übersteuert werden
                    verwPeriodeVon = SapHelper.ConvertDateObject(valutaDatum);
                    verwPeriodeBis = SapHelper.ConvertDateObject(valutaDatum);

                    partnerPositionItem.CALC_PERLO = verwPeriodeVon;
                    partnerPositionItem.CALC_PERHI = verwPeriodeBis;

                    // Führe diese Änderung auch auf der Kiss-DB nach
                    KbBuchungKostenartBLL.UpdateVerwPeriode(valutaDatum, valutaDatum, positionRow.KbBuchungKostenartID);
                }
                else
                {
                    partnerPositionItem.CALC_PERLO = verwPeriodeVon;
                    partnerPositionItem.CALC_PERHI = verwPeriodeBis;
                }

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
                    if (belegRow.KbBuchungTypCode == 5 && amount < 0) // Umbuchung
                        partnerPositionItem.ONLY_OFF = "X";
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
                    string zahlungswegSapIDAddress;
                    string pscdAuszahlungsart;
                    int? zahlungswegBesitzerBpId = GetBusinessPartnerOfZahlungsweg(belegRow, out zahlungswegSapID, out pscdAuszahlungsart, out zahlungswegSapIDAddress);
                    if (!belegRow.IsPscdZahlwegArtNull())
                        pscdAuszahlungsart = belegRow.PscdZahlwegArt;

                    // Nettobelege werden auf Dritte gebucht
                    // zur Not (Barbelege) werden sie auf den Leistungsträger gebucht
                    int bpNumber = zahlungswegBesitzerBpId.HasValue ? zahlungswegBesitzerBpId.Value : baPersonID;
                    if (pscdAuszahlungsart == "C" && positionsTable.Count > 0 && !positionsTable[0].IsBaPersonIDNull())
                        bpNumber = positionsTable[0].BaPersonID;

                    partnerPositionItem.BUSPARTNER = SapHelper.GetBusinessPartnerNumber(bpNumber);
                    partnerPositionItem.CONT_ACCT = SapHelper.GetContractAccountNumber(bpNumber);
                    //dfkkopItem._STZH_SOZ_GPART2 = SapHelper.GetBusinessPartnerNumber(baPersonID);
                    if (belegRow.AnDritte && pscdAuszahlungsart != "C")
                    {
                        dfkkopItem._STZH_SOZ_VTREF2 = SapHelper.GetPsObjectNumber(belegRow.PscdVertragsgegenstandID);
                        partnerPositionItem.CONTRACT = null;
                    }
                    else
                        partnerPositionItem.CONTRACT = SapHelper.GetPsObjectNumber(belegRow.PscdVertragsgegenstandID);

                    partnerPositionItem.PARTNER = partnerPositionItem.BUSPARTNER;
                    partnerPositionItem.PMNT_METH = pscdAuszahlungsart;
                    if (pscdAuszahlungsart != "C")
                    {
                        partnerPositionItem.BK_DETAILS = zahlungswegSapID;
                        partnerPositionItem.ADDR_NO = zahlungswegSapIDAddress;
                    }

                    if (pscdAuszahlungsart == "1")
                    {
                        if (belegRow.IsReferenzNummerNull())
                        {
                            RegisterBelegError(belegRow, string.Format("Keine ESR-Referenznummer angegeben für Alim-Nettobeleg mit ID {0}", belegRow.KbBuchungID), ref  warningMessage);
                            //								exceptionMessage = string.Format("Keine ESR-Referenznummer angegeben für Alim-Nettobeleg mit ID {0}", belegRow.KbBuchungID);
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
                //   partnerPositionItem.FISC_YEAR = belegRow.ValutaDatum.Year.ToString();		// #5292: FISC_YEAR darf nicht befüllt werden
                //partnerPositionItem.AMOUNT_GL = partnerPositionItem.AMOUNT_LOC_CURR;
                //partnerPositionItem.AMOUNT_GLSpecified = true;
                //partnerPositionItem.CURRENCY_GL = "CHF";

                dfkkopItem._STZH_SOZ_MBUDG = "";
                dfkkopItem.DOC_NO = partnerPositionItem.DOC_NO;
                dfkkopItem.REP_ITEM = partnerPositionItem.REP_ITEM;
                dfkkopItem.SUB_ITEM = partnerPositionItem.SUB_ITEM;
                dfkkopItem.ITEM = partnerPositionItem.ITEM;
                dfkkopItem._STZH_SOZ_VWZW1 = belegRow.MitteilungZeile1;
                dfkkopItem._STZH_SOZ_VWZW2 = belegRow.MitteilungZeile2;
                dfkkopItem._STZH_SOZ_KBKZ = positionRow.PscdKennzeichen;
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

            BAPI_TE_DFKKKO dossierNumber = new BAPI_TE_DFKKKO();
            dossierNumber._STZH_SOZ_DOSSNR = belegRow.Dossiernummer;

            PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF001", svcBuchungsstoff.Url, belegRow.BelegNr, user);
            bool exception;
            try
            {
                returnMsg = svcBuchungsstoff.MI_KISS_BUCHSTOFF001(
                    completeDocument,
                    documentHeader,
                    esr,
                    recKeyInfo,
             dossierNumber,
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
                log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
            }
            catch (SoapException ex)
            {
                log.StopWatch();
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von Alim-Belegen", ex);
                log.ExceptionMsg = SapHelper.ProcessSoapException(ex);
                exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Alim-Belegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, log.ExceptionMsg, WebServiceHelperMethods.GetNewLineString());
            }
            catch (Exception ex)
            {
                log.StopWatch();
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von Alim-Belegen", ex);
                string msg = ex.Message;
                // HTML-Seite 'parsen' um eine anständige Timeout-Fehlermeldung zu erhalten
                if (!string.IsNullOrEmpty(ex.Message) && ex.Message.IndexOf(@"<H2>500 Connection timed out</H2>") > -1)
                    msg = string.Format("Fehler beim Anlegen des Alim-Belegs mit ID {0}: Zwischen XI und PSCD gab es ein Timeout{1}", belegRow.KbBuchungID, WebServiceHelperMethods.GetNewLineString());
                exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Alim-Belegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, msg, WebServiceHelperMethods.GetNewLineString());
                log.ExceptionMsg = msg;
            }
            finally
            {
                log.WriteToDB();
            }

            string errorlog = log.GetErrorMsgs(false);

            if (!log.HasErrorOccured())
            {
                // Mark the Buchung as 'sent to SAP'
                belegRow.KbBuchungStatusCode = 3; // verbucht
                belegRow.TransferDatum = DateTime.Now;
                belegRow.ValutaDatum = valutaDatum;
                belegRow.PscdFehlermeldung = "";    // Lösche die Fehlermeldung, falls sie von einer vorherigen Übertragung noch gesetzt war
                KbBuchungBLL.Update(belegRow);
            }
            else if (errorlog.Contains("Beleg buchen: Belegnummer") && errorlog.Contains("ist bereits vergeben"))
            {
                // Der Beleg war schon früher mal korrekt ans PSCD übermittelt worden, war dann aber im Kiss hängengeblieben.
                // Wir akzeptieren dies hier normal verarbeiteter Beleg, schreiben aber einen Kommentar ins PSCD-Fehlermeldungs-Feld
                belegRow.PscdFehlermeldung = KiSSSvc.SAP.Helpers.SapHelper.TruncateFehlermeldung("Der Alim-Beleg " + belegRow.KbBuchungID + " / " + belegRow.BelegNr + " wurde von PSCD zurückgewiesen (Belegnummer existiert bereits), was darauf schliessen lässt, dass dieser Beleg bereits früher korrekt verarbeitet wurde. Daher wird dieser Beleg als übermittelt deklariert.");

                belegRow.KbBuchungStatusCode = 3; // verbucht
                belegRow.TransferDatum = DateTime.Now;
                belegRow.ValutaDatum = valutaDatum;
                KbBuchungBLL.Update(belegRow);
            }
            else
            {
                belegRow.KbBuchungStatusCode = 5; // Zahlauftrag fehlerhaft
                belegRow.PscdFehlermeldung = log.GetErrorMsgs(false);
                warningMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des Alimbelegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, belegRow.PscdFehlermeldung, WebServiceHelperMethods.GetNewLineString());
                success = false;
                KbBuchungBLL.Update(belegRow);
            }
            return success;
        }

        private bool SubmitAlimBelege(KiSSDB.KbBuchungDataTable belege, DateTime valutaDatum, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        {
            bool success = true;
            //Log.Info(this.GetType(), string.Format("Sende {0} Alim-Belege", belege.Count));
            foreach (KiSSDB.KbBuchungRow belegRow in belege)
            {
                try
                {
                    success &= SubmitAlimBeleg(belegRow, valutaDatum, user, ref exceptionMessage, ref warningMessage);
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

        #endregion

        #region Kg

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

        private static string ConvertToKgAuszahlungsart(string pscdAuszahlungsart)
        {
            // Bank (neu)
            if (pscdAuszahlungsart == "3")
                return "I";
            // ESR (neu)
            if (pscdAuszahlungsart == "1")
                return "R";
            // Postmandant
            if (pscdAuszahlungsart == "D")
                return "M";

            return pscdAuszahlungsart;
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

        private bool SubmitKgBeleg(KiSSDB.KgBuchungRow belegRow, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        {
            bool success = true;
            if (belegRow.IsKgBuchungStatusCodeNull() || (belegRow.KgBuchungStatusCode != 2 && belegRow.KgBuchungStatusCode != 4 && belegRow.KgBuchungStatusCode != 5))
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

                BAPI_TE_DFKKKO dossierNumber = new BAPI_TE_DFKKKO();
                //dossierNumber._STZH_SOZ_DOSSNR = belegRow.Dossiernummer;

                try
                {
                    documentHeader.DOC_NO = SapHelper.GetDocumentNumber(belegRow.PscdBelegNr);
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
                    //   partnerPositionItem.FISC_YEAR = belegRow.ValutaDatum.Year.ToString();		// #5292: FISC_YEAR darf nicht befüllt werden
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
                    auszahlDaten._STZH_SOZ_UIBAN = SapHelper.RemoveBlanks(quellKonto.IBANNummer);
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
                    if (pscdAuszahlungsart == "R" || pscdAuszahlungsart == "I")
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
                        auszahlDaten._STZH_SOZ_ZBNKL = SapHelper.GetClearingNrFromBaBankID(belegRow["BaBankID"], out sapLandCode, !belegRow.IsPostKontoNummerNull(), SapHelper.RemoveBlanks(belegRow.IBANNummer));
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
                PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF001", svcBuchungsstoff.Url, belegRow.PscdBelegNr, user);
                bool exception;
                try
                {
                    string returnMsg = svcBuchungsstoff.MI_KISS_BUCHSTOFF001(
                        "X",
                        documentHeader,
                        esr,
                        recKeyInfo,
                dossierNumber,
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
                    log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
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
                }
            }
            return success;
        }

        /*
        public static bool CheckMod10Nummer(string Nummer)
        {
            if (Utils.IsNumeric(Nummer))
            {
                int[] array = new int[11] { 0, 9, 4, 6, 8, 2, 7, 1, 3, 5, 0 };

                if (Nummer.Length > 0)
                {
                    int length = Nummer.Length;
                    //int [] values = new int[length-1] ;
                    int temp = array[Convert.ToInt32(Convert.ToString(Nummer[0]))];

                    for (int i = 1; i < length - 1; i++)
                    {
                        temp = array[(Convert.ToInt32(Convert.ToString(Nummer[i])) + temp) % 10];
                    }

                    if (Convert.ToInt32(Convert.ToString(Nummer[length - 1])) == (10 - temp) % 10)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
         */

        #endregion

        #region Zahlungsweg holen

        private int? GetBusinessPartnerByZahlungswegID(int zahlungswegID, out string sapID, out string zahlungsart, out string sapIDAddress)
        {
            sapID = null;
            zahlungsart = null;
            sapIDAddress = null;
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
                int? sapIDAddresstmp = null;
                if (!zahlungswegRow.IsBaPersonIDNull() && !zahlungswegRow.WMAVerwenden)
                    sapIDAddresstmp = PscdSentBLL.GetSapIDAddress(zahlungswegID);

                if (zahlungsart == "3" && !sapIDtmp.HasValue)
                {
                    Log.Warn(this.GetType(), string.Format("Zahlungsweg mit ID '{0}' wurde noch nicht an SAP übermittelt", zahlungswegID));
                    // ToDo: Zahlungsweg übermitteln
                }
                else
                {
                    if (sapIDtmp.HasValue)
                        sapID = sapIDtmp.Value.ToString("0000");
                    if (sapIDAddresstmp.HasValue)
                        sapIDAddress = sapIDAddresstmp.Value.ToString("0000000000");
                }
                if (!zahlungswegRow.IsBaPersonIDNull())
                    return zahlungswegRow.BaPersonID;
                else if (!zahlungswegRow.IsBaInstitutionIDNull())
                    return zahlungswegRow.BaInstitutionID;
                else
                    throw new Exception(string.Format("BaZahlungsweg mit ID '{0}' gehört weder einer Person noch einer Institution", zahlungswegID));
            }
        }

        private int? GetBusinessPartnerOfZahlungsweg(KiSSDB.KbBuchungRow belegRow, out string sapID, out string zahlungsart, out string sapIDAddress)
        {
            sapID = null;
            sapIDAddress = null;
            zahlungsart = null;
            // PSCD-Zahlwegart bestimmen ('1', '3', 'C' etc; ist im LOV definiert)
            if (!belegRow.IsKbAuszahlungsArtCodeNull())
                zahlungsart = SapHelper.LookupAuszahlungsArtCode(belegRow.KbAuszahlungsArtCode);
            if (belegRow.IsBaZahlungswegIDNull())
            {
                Log.Warn(this.GetType(), string.Format("Kein Zahlungsweg für KbBuchung mit ID '{0}' abgelegt", belegRow.KbBuchungID));
            }
            else
            {
                int? bpNummer = GetBusinessPartnerByZahlungswegID(belegRow.BaZahlungswegID, out sapID, out zahlungsart, out sapIDAddress);
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

        #region Weiterverrechnung

        public CreateObjectResult SubmitWVEinzelpostenByIDs(int[] kbWVEinzelpostenIDs, UserInfo userInfo, ref string warningMsg)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            KiSSDB.KbWVEinzelpostenDataTable wvPosten = KbWVEinzelpostenBLL.GetWVEinzelpostenByIDs(kbWVEinzelpostenIDs);
            string exceptionMessage = "";
            watch.Stop();
            Log.Info(this.GetType(), string.Format("SubmitWVEinzelpostenByIDs: {0} WV-Einzelposten vom Client an Server übermittelt: {1} WV-Einzelposten-Details von DB gelesen in {2} ms.", kbWVEinzelpostenIDs.GetLength(0), wvPosten.Count, watch.ElapsedMilliseconds));

            watch.Reset();
            watch.Start();
            int success = SubmitWVEinzelposten(wvPosten, userInfo, ref exceptionMessage, ref warningMsg);
            watch.Stop();
            Log.Info(this.GetType(), string.Format("SubmitWVEinzelpostenByIDs: {0} von {1} WV-Einzelposten-Details erfolgreich abgearbeitet in {2} ms.", success, wvPosten.Count, watch.ElapsedMilliseconds));

            if (!string.IsNullOrEmpty(exceptionMessage))
                throw new Exception(exceptionMessage);
            return success == wvPosten.Count ? CreateObjectResult.Success : CreateObjectResult.Warning;
        }

        private int SubmitWVEinzelposten(KiSSDB.KbWVEinzelpostenDataTable wvPosten, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        {
            int success = 0;

            // gestaffelte Timeouts: Timeout von Webservice sollte kleiner sein als Timeout von KiSS-Client
            //
            int timeout = 120000; // 2 minutes = 120000 millisecondsx
            if (wvPosten.Count > 20)
            {
                timeout = wvPosten.Count * 6000;
            }

            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Bruttobelege
            foreach (KiSSDB.KbWVEinzelpostenRow wvPostenRow in wvPosten)
            {
                try
                {
                    if (SubmitWVEinzelpostenRow(wvPostenRow, user, ref exceptionMessage, ref warningMessage))
                    {
                        success++;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(this.GetType(), string.Format("SubmitWVEinzelposten: Bei der Übermittlung von KbWVEinzelpostenID {0} wurde folgende Exception ausgelöst:", wvPostenRow.KbWVEinzelpostenID, ex));
                    exceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
                }
                if (watch.ElapsedMilliseconds > timeout)
                {
                    break;
                }
            }
            watch.Stop();
            return success;
        }

        private bool SubmitWVEinzelpostenRow(KiSSDB.KbWVEinzelpostenRow wvPostenRow, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        {
            bool success = true;
            //if (belegRow.IsKbBuchungStatusCodeNull() || belegRow.KbBuchungStatusCode != 2)
            //   // Buchung is not ready to be transferred
            //   return true;
            if (!wvPostenRow.IsTransferDatumNull())
                return true;

            string soz_mbudg = "";//SapHelper.GetBudgetID(wvPostenRow.BgBudgetID, BgBudgetBLL.GetDateOfBudget(wvPostenRow.BgBudgetID)); // ToDo: DB-Zugriffe reduzieren
            if (wvPostenRow.IsHauptvorgangNull() || wvPostenRow.IsTeilvorgangNull())
            {
                string msg = string.Format("Haupt- und Teilvorgang sind nicht definiert für WV-Einzelposten mit ID {0}. Bitte in den Stammdaten eintragen", wvPostenRow.KbWVEinzelpostenID);
                exceptionMessage += msg + WebServiceHelperMethods.GetNewLineString();
                return false;
            }

            string completeDocument = "X";
            BAPIDFKKKO documentHeader = new BAPIDFKKKO();
            documentHeader.DOC_NO = SapHelper.GetDocumentNumber(wvPostenRow.PscdBelegNr);
            documentHeader.FIKEY = SapHelper.GetAbstimmschluessel();
            documentHeader.APPL_AREA = "P"; // fix value, 'Öffentliche Verwaltung'
            documentHeader.DOC_TYPE = "WV";
            documentHeader.DOC_SOURCE_KEY = "33"; // Belegübernahme
            documentHeader.CURRENCY = "CHF";
            documentHeader.DOC_DATE = SapHelper.ConvertDate(DateTime.Today); // Belegdatum im Beleg
            documentHeader.POST_DATE = SapHelper.ConvertDate(DateTime.Today);
            documentHeader.SINGLE_DOC = " ";
            documentHeader.REF_DOC_NO = wvPostenRow.IsBelegNrBuchungNull() || wvPostenRow.IsPositionImBelegNull() ? "" : SapHelper.GetDocumentNumberInclPosition(wvPostenRow.BelegNrBuchung, wvPostenRow.PositionImBeleg); ;

            documentHeader.OBJ_SYS = wvPostenRow.IsKostenstelleNull() ? "" : wvPostenRow.Kostenstelle;    // Migrierte WV-Posten haben keine Kostenstelle

            BAPIRECKEYINFO recKeyInfo = new BAPIRECKEYINFO();
            recKeyInfo.CALLER_ID = SapHelper.GetKissCallerID();

            List<BAPIDFKKOP> partnerPositionList = new List<BAPIDFKKOP>();
            List<BAPIDFKKOPLOCK> lockList = new List<BAPIDFKKOPLOCK>();
            List<BAPI_TE_DFKKOP> dfkkopList = new List<BAPI_TE_DFKKOP>();
            BAPIDFKKOP partnerPositionItem = new BAPIDFKKOP();
            BAPI_TE_DFKKOP dfkkopItem = new BAPI_TE_DFKKOP();

            partnerPositionItem.DOC_NO = documentHeader.DOC_NO;
            partnerPositionItem.REP_ITEM = "000"; // ToDo: offen
            partnerPositionItem.ITEM = "0001";
            partnerPositionItem.SUB_ITEM = "000"; // fix value
            partnerPositionItem.COMP_CODE = "5550"; // fix value, Standardbuchungskreis
            partnerPositionItem.BUSPARTNER = SapHelper.GetBusinessPartnerNumber(wvPostenRow.BEDCode);
            partnerPositionItem.CONT_ACCT = SapHelper.GetContractAccountNumber(wvPostenRow.BEDCode);
            //partnerPositionItem.CONTRACT = !belegRow.IsPscdVertragsgegenstandIDNull() ? SapHelper.GetPsObjectNumber(belegRow.PscdVertragsgegenstandID) : "";
            partnerPositionItem.APPL_AREA = "P"; // fix value
            partnerPositionItem.MAIN_TRANS = wvPostenRow.Hauptvorgang.ToString("0000");
            partnerPositionItem.SUB_TRANS = wvPostenRow.Teilvorgang.ToString("0000");
            partnerPositionItem.ACTDETERID = "01"; // ToDo: offen
            partnerPositionItem.CALC_PERLO = SapHelper.ConvertDate(wvPostenRow.DatumVon);
            partnerPositionItem.CALC_PERHI = SapHelper.ConvertDate(wvPostenRow.DatumBis);

            partnerPositionItem.STAT_KEY = "G";
            //partnerPositionItem.PARTNER = SapHelper.GetBusinessPartnerNumber(wvPostenRow.BeguenstigterBaPersonID);
            //dfkkopItem._STZH_SOZ_PYGRP = payment_grp;
            //partnerPositionItem.ONLY_OFF = "X";

            partnerPositionItem.DOC_DATE = documentHeader.DOC_DATE;
            partnerPositionItem.POST_DATE = documentHeader.POST_DATE;
            partnerPositionItem.NET_DATE = documentHeader.POST_DATE; // Nettofälligkeitsdatum SapHelper.ConvertDateObject(positionRow["ValutaDatum"]);
            partnerPositionItem.DISC_DUE = partnerPositionItem.NET_DATE; // Skontofälligkeit, identisch mit Nettofälligkeit
            partnerPositionItem.TEXT = "";// wvPostenRow.Buchungstext;
            partnerPositionItem.CURRENCY = "CHF";
            //partnerPositionItem.CURRENCY_ISO = "CHF";
            decimal amount = wvPostenRow.Betrag;
            partnerPositionItem.AMOUNT_LOC_CURR = amount;
            partnerPositionItem.AMOUNT_LOC_CURRSpecified = true;
            partnerPositionItem.AMOUNT = amount;
            partnerPositionItem.AMOUNTSpecified = true;
            partnerPositionItem.DOC_TYPE = "WV";

            //partnerPositionItem.AMOUNT_GL = partnerPositionItem.AMOUNT_LOC_CURR;
            //partnerPositionItem.AMOUNT_GLSpecified = true;
            //partnerPositionItem.CURRENCY_GL = "CHF";

            //dfkkopItem._STZH_SOZ_GPART2 = partnerPositionItem.BUSPARTNER; // Nur wenn Beleg auf Dritte gebucht wird, sprich nur bei Nettozahlungen
            dfkkopItem._STZH_SOZ_MBUDG = soz_mbudg;
            dfkkopItem.DOC_NO = partnerPositionItem.DOC_NO;
            dfkkopItem.REP_ITEM = partnerPositionItem.REP_ITEM;
            dfkkopItem.SUB_ITEM = partnerPositionItem.SUB_ITEM;
            dfkkopItem.ITEM = partnerPositionItem.ITEM;
            dfkkopItem._STZH_SOZ_MBUDG = wvPostenRow.IsBgBudgetIDNull() ? "" : SapHelper.GetGrouping(wvPostenRow.BgBudgetID, false);
            dfkkopItem._STZH_SOZ_FAKID = wvPostenRow.KbWVLaufID.ToString();
            dfkkopItem._STZH_SOZ_EPID = wvPostenRow.KbWVEinzelpostenID.ToString();
            dfkkopItem._STZH_SOZ_FNRHK = wvPostenRow.HeimatkantonNr;
            dfkkopItem._STZH_SOZ_SKZNR = wvPostenRow.SKZNummer;
            dfkkopItem._STZH_SOZ_FPV = SapHelper.ConvertDate(wvPostenRow.DatumVon);
            dfkkopItem._STZH_SOZ_FPB = SapHelper.ConvertDate(wvPostenRow.DatumBis);
            dfkkopItem._STZH_SOZ_WVCODE = SapHelper.GetWVShortText(wvPostenRow.WVCode);
            dfkkopItem._STZH_SOZ_WVCVON = wvPostenRow.IsWVCodeVonNull() ? "" : SapHelper.ConvertDate(wvPostenRow.WVCodeVon);
            dfkkopItem._STZH_SOZ_WVCBIS = wvPostenRow.IsWVCodeVonNull() ? "" : SapHelper.ConvertDateToEndObject(wvPostenRow["WVCodeBis"]);
            dfkkopItem._STZH_SOZ_FLAGHW = wvPostenRow.WohnHeimatKanton;
            dfkkopItem._STZH_SOZ_WVEIID = wvPostenRow.IsWVEinheitIDNull() ? "" : wvPostenRow.WVEinheitID.ToString();
            dfkkopItem._STZH_SOZ_BLKISS = wvPostenRow.IsBelegNrBuchungNull() ? "" : SapHelper.GetDocumentNumber(wvPostenRow.BelegNrBuchung);
            dfkkopItem._STZH_SOZ_VTREF2 = wvPostenRow.IsVertragsgegenstandNull() ? "" : SapHelper.GetPsObjectNumber(wvPostenRow.Vertragsgegenstand);
            dfkkopItem._STZH_SOZ_WVSTAT = "V";
            dfkkopItem._STZH_SOZ_USTR = SapHelper.GetBusinessPartnerNumber(wvPostenRow.UnterstuetzungstraegerBaPersonID);
            dfkkopItem._STZH_SOZ_GPART2 = SapHelper.GetBusinessPartnerNumber(wvPostenRow.BeguenstigterBaPersonID);
            dfkkopItem._STZH_SOZ_APHA = wvPostenRow.IsPersonenImHaushaltNull() ? "" : wvPostenRow.PersonenImHaushalt.ToString();
            dfkkopItem._STZH_SOZ_APUN = wvPostenRow.IsPersonenUnterstuetztNull() ? "" : wvPostenRow.PersonenUnterstuetzt.ToString();
            dfkkopItem._STZH_SOZ_KBKZ = "W"; // WV-Posten sind immer 'W'

            dfkkopItem._STZH_SOZ_APUNHA = wvPostenRow.IsUntPersonenImHaushaltNull() ? "" : wvPostenRow.UntPersonenImHaushalt.ToString();  // Bei Migrierten WV-Posten ist dieses Feld NULL

            //nur Schweizer, dürfen einen Heimatkanton haben
            if (wvPostenRow.IsNationalitaetCodeNull() || wvPostenRow.NationalitaetCode == 8100)
                dfkkopItem._STZH_SOZ_HEKA = wvPostenRow.Heimatkanton;

            dfkkopItem._STZH_SOZ_LANR = wvPostenRow.Leistungsart;
            dfkkopItem._STZH_SOZ_LATEXT = wvPostenRow.LeistungsartText;

            dfkkopList.Add(dfkkopItem);
            partnerPositionList.Add(partnerPositionItem);

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

            BAPI_TE_DFKKKO dossierNumber = new BAPI_TE_DFKKKO();
            //dossierNumber._STZH_SOZ_DOSSNR = belegRow.Dossiernummer;

            PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF001", svcBuchungsstoff.Url, wvPostenRow.PscdBelegNr, user);
            bool exception;
            try
            {
                returnMsg = svcBuchungsstoff.MI_KISS_BUCHSTOFF001(
                    completeDocument,
                    documentHeader,
                    esr,
                    recKeyInfo,
             dossierNumber,
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
                log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
            }
            catch (SoapException ex)
            {
                log.StopWatch();
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von WV-Einzelposten", ex);
                log.ExceptionMsg = SapHelper.ProcessSoapException(ex);
                exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des WV-Einzelposten mit ID {0}: {1}{2}", wvPostenRow.KbWVEinzelpostenID, log.ExceptionMsg, WebServiceHelperMethods.GetNewLineString());
            }
            catch (Exception ex)
            {
                log.StopWatch();
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Anlegen von WV-Einzelposten", ex);
                string msg = ex.Message;
                // HTML-Seite 'parsen' um eine anständige Timeout-Fehlermeldung zu erhalten
                if (!string.IsNullOrEmpty(ex.Message) && ex.Message.IndexOf(@"<H2>500 Connection timed out</H2>") > -1)
                    msg = string.Format("Fehler beim Anlegen des WV-Einzelposten mit ID {0}: Zwischen XI und PSCD gab es ein Timeout{1}", wvPostenRow.KbWVEinzelpostenID, WebServiceHelperMethods.GetNewLineString());
                exceptionMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des WV-Einzelposten mit ID {0}: {1}{2}", wvPostenRow.KbWVEinzelpostenID, msg, WebServiceHelperMethods.GetNewLineString());
                log.ExceptionMsg = msg;
            }
            finally
            {
                log.WriteToDB();
            }

            string errorlog = log.GetErrorMsgs(false);
            if (!log.HasErrorOccured())
            {
                // belegNr has beeen successfully used
                // Mark the Buchung as 'sent to SAP'
                wvPostenRow.KbWVEinzelpostenStatusCode = 2; // [V]orbereitet
                wvPostenRow.TransferDatum = DateTime.Now;
                wvPostenRow.PscdFehlermeldung = "";
                KbWVEinzelpostenBLL.Update(wvPostenRow);
            }
            else if (errorlog.Contains("Beleg buchen: Belegnummer") && errorlog.Contains("ist bereits vergeben"))
            {
                // Der Beleg war schon früher mal korrekt ans PSCD übermittelt worden, war dann aber im Kiss hängengeblieben.
                // Wir akzeptieren dies hier normal verarbeiteter Beleg, schreiben aber einen Kommentar ins PSCD-Fehlermeldungs-Feld
                wvPostenRow.PscdFehlermeldung = KiSSSvc.SAP.Helpers.SapHelper.TruncateFehlermeldung("Der WV-Einzelposten " + wvPostenRow.KbWVEinzelpostenID + " / " + wvPostenRow.PscdBelegNr + " wurde von PSCD zurückgewiesen (Belegnummer existiert bereits), was darauf schliessen lässt, dass dieser Beleg bereits früher korrekt verarbeitet wurde. Daher wird dieser Beleg als übermittelt deklariert.");

                // belegNr has beeen successfully used
                // Mark the Buchung as 'sent to SAP'
                if (wvPostenRow.KbWVEinzelpostenStatusCode == 1) // L, lieferbar
                {
                    wvPostenRow.KbWVEinzelpostenStatusCode = 2; // V, vorbereitet (=im PSCD angekommen)
                }

                wvPostenRow.TransferDatum = DateTime.Now;
                success = false;
                KbWVEinzelpostenBLL.Update(wvPostenRow);
            }
            else
            {
                wvPostenRow.PscdFehlermeldung = log.GetErrorMsgs(false);
                warningMessage += string.Format("Fehlermeldung von PSCD beim Anlegen des WV-Einzelpostens mit ID {0}: {1}{2}", wvPostenRow.KbWVEinzelpostenID, wvPostenRow.PscdFehlermeldung, WebServiceHelperMethods.GetNewLineString());
                success = false;
                KbWVEinzelpostenBLL.Update(wvPostenRow);
            }
            return success;
        }

        #endregion
    }
}