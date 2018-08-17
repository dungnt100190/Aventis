using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using System.Threading;
using KiSSSvc.DAL;
using KiSSSvc.Logging;
using KiSSSvc.SAP.Helpers;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.BuchungsstoffMutieren;

namespace KiSSSvc.SAP.PSCD.BudgetData
{
    public class BuchungsstoffMutieren
    {
        private MI_KISS_BUCHSTOFF002Service svcBuchugsstoff;

        public BuchungsstoffMutieren()
        {
            svcBuchugsstoff = WebServiceSource.GetBuchungsstoffMutierenWS();
        }

        /*
        public CreateObjectResult ModifyWhBelegeByKbBuchungIDs(int[] kbBuchungIDs, UserInfo userInfo, ref string warningMsg)
        {
            KiSSDB.KbBuchungDataTable nettoBelege = KbBuchungBLL.GetWhBelegeFromKbBuchungIDs(kbBuchungIDs);
            string exceptionMessage = "";
            // Submit the BPs that are referenced from the documents

            bool success = true;
            foreach (KiSSDB.KbBuchungRow belegRow in nettoBelege)
            {
                try
                {
                    success &= SubmitNettoBeleg(belegRow, userInfo, ref exceptionMessage, ref warningMsg);
                }
                catch (Exception ex)
                {
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    success = false;
                    exceptionMessage += ex.Message + WebServiceHelperMethods.GetNewLineString();
                }
            }
            if (!string.IsNullOrEmpty(exceptionMessage))
                throw new Exception(exceptionMessage);
            return success ? CreateObjectResult.Success : CreateObjectResult.Warning;
        }
        */

        #region Netto

        internal bool SubmitNettoBeleg(KiSSDB.KbBuchungRow belegRow, UserInfo user, ref string exceptionMessage, ref string warningMessage)
        {
            if (belegRow.KbBuchungStatusCode != 16)
                return false;

            bool success = true;
            BAPIDFKKKOCH header = new BAPIDFKKKOCH();

            BAPIDFKKKOCHX headerX = new BAPIDFKKKOCHX();
            BAPIPAREX[] extensionIn = new BAPIPAREX[] { };
            BAPIDFKKOPLOCK[] positionLocks = new BAPIDFKKOPLOCK[] { };

            BAPIDFKKOPWCH[] repetitionPosition = new BAPIDFKKOPWCH[] { };
            BAPIDFKKOPWCHX[] repetitionPositionX = new BAPIDFKKOPWCHX[] { };

            _STZH_BAPIDFKKOPCH partnerPositionItem = new _STZH_BAPIDFKKOPCH();
            _STZH_BAPIDFKKOPCHX partnerPositionItemX = new _STZH_BAPIDFKKOPCHX();

            List<BAPIDFKKOPLOCK> lsPositionLocks = new List<BAPIDFKKOPLOCK>();
            BAPIDFKKOPLOCK itemPostionLock = new BAPIDFKKOPLOCK();
            itemPostionLock.PROCESSING_MODE = "04"; //Löschen
            itemPostionLock.REP_ITEM = "000"; //leer lassen
            itemPostionLock.ITEM = "0001"; //immer 1, da im Ali nur 1 Position pro Beleg
            itemPostionLock.SUB_ITEM = "000"; //leer lassen
            itemPostionLock.PROCESS_ID = "10"; //Zahlsperre
            itemPostionLock.LOCK_REASON = "R"; //Rückläufer
            itemPostionLock.FROM_DATE = "00010101";
            itemPostionLock.TO_DATE = "99991231";
            lsPositionLocks.Add(itemPostionLock);
            positionLocks = lsPositionLocks.ToArray();

            string zahlungswegSapID;
            string zahlungswegSapIDAddress;
            string pscdAuszahlungsart;
            int? zahlungswegBesitzerBpId = GetBusinessPartnerOfZahlungsweg(belegRow, out zahlungswegSapID, out pscdAuszahlungsart, out zahlungswegSapIDAddress);
            if (!belegRow.IsPscdZahlwegArtNull())
                pscdAuszahlungsart = belegRow.PscdZahlwegArt;

            //partnerPositionItem._STZH_SOZ_APUNHA = belegRow.UntPersonenImHaushalt.ToString();
            //partnerPositionItemX._STZH_SOZ_APUNHA = "X";

            partnerPositionItem.REP_ITEM = "000"; // ToDo: offen
            partnerPositionItem.ITEM = "0001"; // fix, da nur eine Position
            partnerPositionItem.SUB_ITEM = "000"; // fix value
            partnerPositionItem.PMNT_METH = pscdAuszahlungsart;
            partnerPositionItemX.PMNT_METH = "X";
            //partnerPositionItem.OPTXT = belegRow.Text;
            //partnerPositionItemX.OPTXT = "X";

            string documentnumber = SapHelper.GetDocumentNumber(belegRow.BelegNr);
            if (pscdAuszahlungsart != "C")
            {
                partnerPositionItem.BK_DETAILS = zahlungswegSapID;
                partnerPositionItem.ADDR_NO = zahlungswegSapIDAddress;
                partnerPositionItemX.BK_DETAILS = "X";
                partnerPositionItemX.ADDR_NO = "X";
            }

            _STZH_SOZ_CD_BELEG_BAPI_ESR esr = new _STZH_SOZ_CD_BELEG_BAPI_ESR();
            if (pscdAuszahlungsart == "1")
            {
                if (belegRow.IsReferenzNummerNull())
                {
                    //RegisterBelegError(belegRow, string.Format("Keine ESR-Referenznummer angegeben für Nettobeleg mit ID {0}", belegRow.KbBuchungID), ref  warningMessage);
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

            _STZH_BAPIDFKKOPCH[] partnerPositions = new _STZH_BAPIDFKKOPCH[] { partnerPositionItem };
            _STZH_BAPIDFKKOPCHX[] partnerPositionsX = new _STZH_BAPIDFKKOPCHX[] { partnerPositionItemX };

            BAPIRET2[] returnMessages = new BAPIRET2[] { };

            PscdCallLogEntry log = new PscdCallLogEntry("MI_KISS_BUCHSTOFF002", svcBuchugsstoff.Url, belegRow.BelegNr, user);
            bool exception;
            try
            {
                svcBuchugsstoff.MI_KISS_BUCHSTOFF002(
                    header,
                    headerX,
                    documentnumber,
                    esr,
                    ref extensionIn,
                    ref partnerPositions,
                    ref partnerPositionsX,
                    ref positionLocks,
                    ref repetitionPosition,
                    ref repetitionPositionX,
                    ref returnMessages);
                log.StopWatch();
                log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
            }
            catch (Exception ex)
            {
                log.StopWatch();
                log.ExceptionMsg = ex.Message;
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Mutieren von Nettobelegen", ex);
                exceptionMessage += string.Format("Fehlermeldung von PSCD beim Mutieren des Nettobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, ex.Message, WebServiceHelperMethods.GetNewLineString());
            }
            finally
            {
                log.WriteToDB();
            }
            if (!log.HasErrorOccured())
            {
                belegRow.KbBuchungStatusCode = 3; // verbucht
                //belegRow.TransferDatum = DateTime.Now; // Darf nicht gesetzt werden, da sonst Abstimmung mit PSCD nicht mehr stimmt
                belegRow.PscdFehlermeldung = "";    // Lösche die Fehlermeldung, falls sie von einer vorherigen Übertragung noch gesetzt war
                KbBuchungBLL.Update(belegRow);
            }
            else
            {
                if (belegRow.KbBuchungStatusCode != 16)
                    belegRow.KbBuchungStatusCode = 5; // Zahlauftrag fehlerhaft
                belegRow.PscdFehlermeldung = log.GetErrorMsgs(false);
                warningMessage += string.Format("Fehlermeldung von PSCD beim Mutieren des Nettobelegs mit ID {0}: {1}{2}", belegRow.KbBuchungID, belegRow.PscdFehlermeldung, WebServiceHelperMethods.GetNewLineString());
                success = false;
                KbBuchungBLL.Update(belegRow);
            }
            return success;
        }

        #endregion

        #region Zahlungsweg holen

        private int? GetBusinessPartnerByZahlungswegID(int zahlungswegID, out string sapID, out string zahlungsart, out string sapIDAddress)
        {
            sapID = null;
            sapIDAddress = null;
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
            zahlungsart = null;
            sapIDAddress = null;
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
    }
}