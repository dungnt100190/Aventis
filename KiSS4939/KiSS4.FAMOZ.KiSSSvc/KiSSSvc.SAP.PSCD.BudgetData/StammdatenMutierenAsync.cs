using System;

//using KiSSSvc.SAP.PSCD.BudgetData.BudgetDatenWebReference;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Web.Services.Protocols;
using KiSSSvc.DAL;
using KiSSSvc.Logging;
using KiSSSvc.SAP.Helpers;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.SAP.PSCD.BudgetData;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.WebServiceHelper.TransactionControl;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.BpMutieren;
using DTO = KiSSSvc.SAP.Helpers.DataObjects;

namespace KiSSSvc.SAP.PSCD.BudgetData
{
    public class StammdatenMutierenAsync
    {
        private const string CALL_ID_CHANGE_INSTITUTION_DATA = "CHBPID_";
        private const string CALL_ID_CHANGE_PERSON_DATA = "CHBPPD_";
        private MI_BUDGET_CHG_SOAP_OUTService svcBpMutieren;

        /// <summary>
        /// Constructor
        /// </summary>
        public StammdatenMutierenAsync()
        {
            svcBpMutieren = WebServiceSource.GetBpMutierenAsyncWS();
        }

        public ReturnMsgAsync ModifyBusinessPartnerInstitution(KiSSDB.BaInstitutionRow institution, KiSSDB.BaAdresseRow address, UserInfo userInfo)
        {
            int baInstitutionID = institution.BaInstitutionID;

            string callId = String.Concat(CALL_ID_CHANGE_INSTITUTION_DATA, baInstitutionID);
            ReturnMsgAsync retMsg = null;

            try
            {
                retMsg = TransactionControlService.Instance.GetReturnMsgForCallId(callId);
                retMsg.ObjectID = baInstitutionID;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
            }

            if (retMsg != null)
                return retMsg;

            string country = SapHelper.GetSapCountryCode(address["BaLandID"]);
            string businessPartnerNumber = SapHelper.GetBusinessPartnerNumber(baInstitutionID);
            string contractAccountNumber = SapHelper.GetContractAccountNumber(baInstitutionID);

            // Personendaten
            BAPIBUS1006_CENTRAL_PERSON step1_centralDataPerson = new BAPIBUS1006_CENTRAL_PERSON();

            BAPIBUS1006_ADDRESS step1_AddressData = GetAdressData(address, country);
            BAPIBUS1006_CENTRAL step1_centralData = GetCentralInstitution();
            BAPIBUS1006_CENTRAL_ORGAN step1_centralOrganization = GetCentralOrganisation(institution);
            BAPIADTEL[] step1_t_telefonDataArray = GetTelephoneInstitution(institution, country);
            BAPIADSMTP[] step1_t_e_maildataArray = GetMailInstitution(institution);

            // step 2 and 3: bank/iban
            List<BAPIBUS1006_BANKDETAILS> step2_t_bankDetailData = new List<BAPIBUS1006_BANKDETAILS>();
            List<ZSTEP3_IBAN_CHANGE> step3_t_iban_create = new List<ZSTEP3_IBAN_CHANGE>();
            KiSSDB.BaZahlungswegDataTable zahlwegTable = BaZahlungswegBLL.GetZahlungsVerbindungByBaInstitutionID(baInstitutionID);
            foreach (KiSSDB.BaZahlungswegRow bankRow in zahlwegTable)
            {
                // not an IBAN Account
                BAPIBUS1006_BANKDETAILS bankDetailItem = new BAPIBUS1006_BANKDETAILS();
                string sapCountryCode;
                bankDetailItem.BANK_KEY = SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], out sapCountryCode, !bankRow.IsPCNrNull(), bankRow.IBANNummer);//["ClearingNummer"] as string;
                bankDetailItem.BANK_CTRY = sapCountryCode;
                bankDetailItem.BANK_ACCT = BaZahlungswegBLL.GetAccountNumber(bankRow);
                bankDetailItem.ACCOUNTHOLDER = institution.InstitutionName;
                bankDetailItem.BANKDETAILVALIDFROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                bankDetailItem.BANKDETAILVALIDTO = SapHelper.ConvertDateToEndObject(bankRow["DatumBis"]);
                bankDetailItem.EXTERNALBANKID = bankRow.BaZahlungswegID.ToString();
                step2_t_bankDetailData.Add(bankDetailItem);
                // if we have an IBAN-Number, send this also
                if (!string.IsNullOrEmpty(bankRow.IBANNummer))
                {
                    ZSTEP3_IBAN_CHANGE ibanCreateItem = new ZSTEP3_IBAN_CHANGE();
                    ibanCreateItem.BANKCOUNTRY = sapCountryCode;
                    ibanCreateItem.BANKKEY = bankDetailItem.BANK_KEY;
                    ibanCreateItem.BANKACCOUNTNUMBER = bankDetailItem.BANK_ACCT;
                    ibanCreateItem.IBAN = SapHelper.RemoveBlanks(bankRow.IBANNummer);
                    ibanCreateItem.VALID_FROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                    step3_t_iban_create.Add(ibanCreateItem);
                }
            }

            // step 4
            BAPIFKKVKI step4_ctracDetail = GetCreateAccountDetailInstitution();
            BAPIFKKVKPI1 step4_t_ctracPartnerDetailItem = GetPartnerDetailItemInstitution(businessPartnerNumber);

            //BAPIFKKVKLOCKSI1 step4_t_ctracLockDetailItem = new BAPIFKKVKLOCKSI1(); // für Demo noch nicht nötig

            string step4_validFrom = DateTime.Now.Date.ToString("dd.MM.yyyy"); // ToDo

            BAPIADSMTP[] step1_t_e_mailDataOnAddress = new BAPIADSMTP[] { };
            BAPIADFAX[] step1_t_faxdata = new BAPIADFAX[] { };
            BAPIADFAX[] step1_faxdataOnAddress = new BAPIADFAX[] { };
            BAPIADTEL[] step1_t_telefonDataOnAddress = new BAPIADTEL[] { };
            BAPIBUS1006_BANKDETAILS[] step2_t_bankDetailDataArray = step2_t_bankDetailData.ToArray();
            ZSTEP3_IBAN_CHANGE[] step3_t_iban_changeArray = step3_t_iban_create.ToArray();
            BAPIFKKVKLOCKSI1[] step4_t_ctracLockDetail = new BAPIFKKVKLOCKSI1[] { };
            BAPIFKKVKPI1[] step4_t_ctracPartnerDetail = new BAPIFKKVKPI1[] { step4_t_ctracPartnerDetailItem };

            BAPIADSMTX[] step1_t_e_mailDataOnAddress_x = new BAPIADSMTX[] { };
            BAPIADFAXX[] step1_t_faxdata_x = new BAPIADFAXX[] { };
            BAPIADFAXX[] step1_faxdataOnAddress_x = new BAPIADFAXX[] { };
            BAPIADTELX[] step1_t_telefonDataOnAddress_x = new BAPIADTELX[] { };
            ZSTEP5_CTRACPSOBJECT_CHANGE[] step5_t_ctracPsObject_changeArray = new ZSTEP5_CTRACPSOBJECT_CHANGE[] { };

            // step 6
            BUS000_EEW eew = new BUS000_EEW();
            BUS000_EEW_X eew_x = new BUS000_EEW_X();

            BAPIBUS1006_CENTRAL_PERSON_X step1_centralDataPersonX = GetCentralPersonX();
            BAPIBUS1006_ADDRESS_X step1_AddressDataX = GetAdressDataX();
            BAPIBUS1006_CENTRAL_X step1_centralDataX = GetCentralX();
            BAPIADTELX[] step1_t_telefonDataArray_x = GetTelephoneX(step1_t_telefonDataArray);
            BAPIADSMTX[] step1_t_e_maildataArray_x = GetMailX(step1_t_e_maildataArray);

            long transactionID = KeysBLL.GetBelegNr("TRANS");
            string transactionIDStr = SapHelper.GetTransactionID(transactionID);

            PscdCallLogEntry log = new PscdCallLogEntry("MI_BUDGET_CHG_SOAP_OUT", svcBpMutieren.Url, baInstitutionID, userInfo);
            try
            {
                Log.Info(svcBpMutieren.GetType(), "Calling WebService MI_BUDGET_CHG_SOAP_OUT...");

                svcBpMutieren.MI_BUDGET_CHG_SOAP_OUT(
                    businessPartnerNumber,
                    step1_centralData,
                    null,
                    step1_centralDataPerson,
                    null,
                    step1_centralDataPersonX,
                    step1_centralDataX,
                    "", // STEP1_VALIDFROM
                    "", // STEP1_VALID_DATE
                    step1_AddressData,
                    step1_AddressDataX,
                    contractAccountNumber,
                    step4_ctracDetail,
                    step5_t_ctracPsObject_changeArray,
                    eew,
                    eew_x,
                    transactionIDStr,
                    step1_t_e_mailDataOnAddress,
                    step1_t_e_mailDataOnAddress_x,
                    step1_faxdataOnAddress,
                    step1_faxdataOnAddress_x,
                    step1_t_telefonDataOnAddress,
                    step1_t_telefonDataOnAddress_x,
                    step1_t_faxdata,
                    step1_t_faxdata_x,
                    step1_t_e_maildataArray,
                    step1_t_e_maildataArray_x,
                    step1_t_telefonDataArray,
                    step1_t_telefonDataArray_x,
                    step2_t_bankDetailDataArray,
                    step3_t_iban_changeArray,
                    step4_t_ctracLockDetail,
                    step4_t_ctracPartnerDetail);
                log.StopWatch();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                log.ExceptionMsg = ex.Message;
                Exception ex2 = new Exception(string.Format("Fehler beim Verbinden vom KiSS-Server zu XI (beim Mutieren der Institution mit ID {0}):{1}{2}", baInstitutionID, ex.Message, WebServiceHelperMethods.GetNewLineString()), ex);
                throw ex2;
            }
            finally
            {
                log.WriteToDB();
            }
            retMsg = new ReturnMsgAsync(transactionIDStr);
            retMsg.CallId = callId;
            retMsg.ObjectID = baInstitutionID;
            TransactionControlService.Instance.CreateNewTransaction(retMsg);

            return retMsg;
        }

        public ReturnMsgAsync ModifyBusinessPartnerPerson(KiSSDB.BaPersonRow person, KiSSDB.BaAdresseRow address, UserInfo userInfo)
        {
            int baPersonID = person.BaPersonID;

            string callId = String.Concat(CALL_ID_CHANGE_PERSON_DATA, baPersonID);
            ReturnMsgAsync retMsg = null;

            try
            {
                retMsg = TransactionControlService.Instance.GetReturnMsgForCallId(callId);
                retMsg.ObjectID = baPersonID;
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
            }

            if (retMsg != null)
                return retMsg;

            string wohnsitzCountry = SapHelper.GetSapCountryCode(address["BaLandID"]);
            object sex = person["GeschlechtCode"];
            string bpNumber = SapHelper.GetBusinessPartnerNumber(baPersonID);
            string accountNumber = SapHelper.GetContractAccountNumber(baPersonID);

            // Personendaten
            BAPIBUS1006_CENTRAL_PERSON step1_centralDataPerson = GetCentralPerson(person, sex);
            BAPIBUS1006_CENTRAL_PERSON_X step1_centralDataPersonX = GetCentralPersonX();
            BAPIBUS1006_ADDRESS step1_AddressData = GetAdressData(address, wohnsitzCountry);
            BAPIBUS1006_ADDRESS_X step1_AddressDataX = GetAdressDataX();
            BAPIBUS1006_CENTRAL step1_centralData = GetCentral(person, sex);
            BAPIBUS1006_CENTRAL_X step1_centralDataX = GetCentralX();
            BAPIADTEL[] step1_t_telefonDataArray = GetTelephone(person, wohnsitzCountry);
            BAPIADTELX[] step1_t_telefonDataArray_x = GetTelephoneX(step1_t_telefonDataArray);
            BAPIADSMTP[] step1_t_e_maildataArray = GetMail(person);
            BAPIADSMTX[] step1_t_e_maildataArray_x = GetMailX(step1_t_e_maildataArray);

            // step 2 and 3: bank/iban
            List<BAPIBUS1006_BANKDETAILS> step2_t_bankDetailData = new List<BAPIBUS1006_BANKDETAILS>();
            List<ZSTEP3_IBAN_CHANGE> step2_iban = new List<ZSTEP3_IBAN_CHANGE>();

            KiSSDB.BaZahlungswegDataTable zahlwegTable = BaZahlungswegBLL.GetZahlungswegeOfPerson(baPersonID);
            foreach (KiSSDB.BaZahlungswegRow bankRow in zahlwegTable)
            {
                // Account
                BAPIBUS1006_BANKDETAILS bankDetailItem = new BAPIBUS1006_BANKDETAILS();
                string sapCountryCode;
                bankDetailItem.BANK_KEY = SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], out sapCountryCode, !bankRow.IsPCNrNull(), bankRow.IBANNummer);//["ClearingNummer"] as string;
                bankDetailItem.BANK_CTRY = sapCountryCode;
                bankDetailItem.BANK_ACCT = BaZahlungswegBLL.GetAccountNumber(bankRow);
                bankDetailItem.ACCOUNTHOLDER = string.Format("{0} {1}", person.Vorname, person.Name);
                bankDetailItem.BANKDETAILVALIDFROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                bankDetailItem.BANKDETAILVALIDTO = SapHelper.ConvertDateToEndObject(bankRow["DatumBis"]);
                bankDetailItem.EXTERNALBANKID = bankRow.BaZahlungswegID.ToString();
                step2_t_bankDetailData.Add(bankDetailItem);
                // if we have an IBAN-Number, send this also
                if (!string.IsNullOrEmpty(bankRow.IBANNummer))
                {
                    // this structure is being filled by SAP
                    ZSTEP3_IBAN_CHANGE ibanCreateItem = new ZSTEP3_IBAN_CHANGE();
                    ibanCreateItem.BANKCOUNTRY = sapCountryCode;
                    ibanCreateItem.BANKKEY = bankDetailItem.BANK_KEY;
                    ibanCreateItem.BANKACCOUNTNUMBER = bankDetailItem.BANK_ACCT;
                    ibanCreateItem.IBAN = SapHelper.RemoveBlanks(bankRow.IBANNummer);
                    ibanCreateItem.VALID_FROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                    step2_iban.Add(ibanCreateItem);
                }
            }

            // step 4
            BAPIFKKVKI step4_ctracDetail = GetContractDetail();
            BAPIFKKVKPI1[] step4_t_ctracPartnerDetail = GetAccountPartnerDetail(bpNumber);

            //BAPIFKKVKLOCKSI1 step4_t_ctracLockDetailItem = new BAPIFKKVKLOCKSI1(); // für Demo noch nicht nötig

            string step4_validFrom = DateTime.Now.Date.ToString("dd.MM.yyyy"); // ToDo

            // step 6
            BUS000_EEW eew = new BUS000_EEW();
            BUS000_EEW_X eew_x = new BUS000_EEW_X();

            BAPIADSMTP[] step1_t_e_mailDataOnAddress = new BAPIADSMTP[] { };
            BAPIADSMTX[] step1_t_e_mailDataOnAddress_x = new BAPIADSMTX[] { };
            BAPIADFAX[] step1_t_faxdata = new BAPIADFAX[] { };
            BAPIADFAXX[] step1_t_faxdata_x = new BAPIADFAXX[] { };
            BAPIADFAX[] step1_faxdataOnAddress = new BAPIADFAX[] { };
            BAPIADFAXX[] step1_faxdataOnAddress_x = new BAPIADFAXX[] { };
            BAPIADTEL[] step1_t_telefonDataOnAddress = new BAPIADTEL[] { };
            BAPIADTELX[] step1_t_telefonDataOnAddress_x = new BAPIADTELX[] { };
            BAPIBUS1006_BANKDETAILS[] step2_t_bankDetailDataArray = step2_t_bankDetailData.ToArray();
            ZSTEP3_IBAN_CHANGE[] step3_t_iban_changeArray = new ZSTEP3_IBAN_CHANGE[] { };
            BAPIFKKVKLOCKSI1[] step4_t_ctracLockDetail = new BAPIFKKVKLOCKSI1[] { };
            ZSTEP5_CTRACPSOBJECT_CHANGE[] step5_t_ctracPsObject_changeArray = new ZSTEP5_CTRACPSOBJECT_CHANGE[] { };

            long transactionID = KeysBLL.GetBelegNr("TRANS");
            string transactionIDStr = SapHelper.GetTransactionID(transactionID);
            PscdCallLogEntry log = new PscdCallLogEntry("MI_BUDGET_CHG_SOAP_OUT", svcBpMutieren.Url, baPersonID, userInfo);
            try
            {
                Log.Info(svcBpMutieren.GetType(), "Calling WebService MI_BUDGET_CHG_SOAP_OUT...");
                svcBpMutieren.MI_BUDGET_CHG_SOAP_OUT(
                    bpNumber,
                    step1_centralData,
                    null,
                    step1_centralDataPerson,
                    null,
                    step1_centralDataPersonX,
                    step1_centralDataX,
                    "", // STEP1_VALIDFROM
                    "", // STEP1_VALID_DATE
                    step1_AddressData,
                    step1_AddressDataX,
                    accountNumber,
                    step4_ctracDetail,
                    step5_t_ctracPsObject_changeArray,
                    eew,
                    eew_x,
                    transactionIDStr,
                    step1_t_e_mailDataOnAddress,
                    step1_t_e_mailDataOnAddress_x,
                    step1_faxdataOnAddress,
                    step1_faxdataOnAddress_x,
                    step1_t_telefonDataOnAddress,
                    step1_t_telefonDataOnAddress_x,
                    step1_t_faxdata,
                    step1_t_faxdata_x,
                    step1_t_e_maildataArray,
                    step1_t_e_maildataArray_x,
                    step1_t_telefonDataArray,
                    step1_t_telefonDataArray_x,
                    step2_t_bankDetailDataArray,
                    step3_t_iban_changeArray,
                    step4_t_ctracLockDetail,
                    step4_t_ctracPartnerDetail);

                Log.Info(svcBpMutieren.GetType(), "MI_BUDGET_CHG_SOAP_OUT gesendet");
                log.StopWatch();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                log.ExceptionMsg = ex.Message;
                Exception ex2 = new Exception(string.Format("Fehler beim Verbinden vom KiSS-Server zu XI (beim Mutieren der Person mit ID {0}):{1}{2}", baPersonID, ex.Message, WebServiceHelperMethods.GetNewLineString()), ex);
                throw ex2;
            }
            finally
            {
                log.WriteToDB();
            }
            retMsg = new ReturnMsgAsync(transactionIDStr);
            retMsg.CallId = callId;
            retMsg.ObjectID = baPersonID;
            TransactionControlService.Instance.CreateNewTransaction(retMsg);

            return retMsg;
        }

        #region Process Response from PSCD

        public void Process_STZH_KISS_BUDGET_CHG_OUT(string TRANSACTIONID, DTO.BAPIRET2[] RETURN_MESSAGES, DTO.BAPIBUS1006_BANKDETAILS[] STEP3_T_BANKDETAILDATA, DTO.ZSTEP3_IBAN_CHANGE[] STEP3_T_IBAN, DTO.BAPIFKKVKLOCKSI1[] STEP4_T_CTRACLOCKDETAIL, DTO.BAPIFKKVKPI1[] STEP4_T_CTRACPARTNERDETAIL)
        {
            TransactionControlService.Instance.SetTransactionReturnedFromSap(TRANSACTIONID, true, null);
            int? businessPartner = TransactionControlService.Instance.GetObjectIDFromCallID(TRANSACTIONID);
            if (!businessPartner.HasValue)
                throw new Exception(string.Format("Für die Transaktion mit ID {0} ist keine ID hinterlegt", TRANSACTIONID));

            if (RETURN_MESSAGES.Length > 0)
            {
                PscdCallLogEntry log = new PscdCallLogEntry("STZH_KISS_BUDGET_CHG_OUT", svcBpMutieren.Url, -1, null);
                log.ErrorMsgs = ParseReturnMessages(RETURN_MESSAGES);
                string exceptionMsg = "";
                foreach (DTO.BAPIRET2 message in RETURN_MESSAGES)
                {
                    exceptionMsg += message.MESSAGE + WebServiceHelperMethods.GetNewLineString();
                    Log.Info(svcBpMutieren.GetType(), string.Format("ZReturnMessage: '{0}'", message.MESSAGE));
                }
                throw new Exception(exceptionMsg);
            }
            else
            {
                try
                {
                    int receivedBpId = businessPartner.Value;
                    if (receivedBpId < SapHelper.FirstInstitutionID)
                    {
                        // Register Person as 'sent to PSCD'
                        KiSSDB.BaPersonRow person = BaPersonBLL.GetPerson(receivedBpId);
                        PscdSentBLL.SavePscdSentPerson(receivedBpId, person.BaPersonTS);
                    }
                    else
                    {
                        // Register Institution as 'sent to PSCD'
                        KiSSDB.BaInstitutionRow institution = BaInstitutionBLL.GetInstitution(receivedBpId);
                        PscdSentBLL.SavePscdSentInstitution(receivedBpId, institution.BaInstitutionTS);
                    }
                    // Register Address as 'sent to PSCD'
                    KiSSDB.BaAdresseRow address = BaAdresseBLL.GetCurrentWMAOfPerson(receivedBpId);
                    PscdSentBLL.SavePscdSentAdresse(address.BaAdresseID, address.BaAdresseTS);
                    // Register Zahlweg as 'sent to PSCD'
                    KiSSDB.BaZahlungswegDataTable zahlwegTable = BaZahlungswegBLL.GetZahlungswegeOfPerson(receivedBpId);

                    foreach (DTO.BAPIBUS1006_BANKDETAILS receivedZahlweg in STEP3_T_BANKDETAILDATA)
                    {
                        try
                        {
                            int externalID = int.Parse(receivedZahlweg.EXTERNALBANKID);
                            int sapID = int.Parse(receivedZahlweg.BANKDETAILID);
                            KiSSDB.BaZahlungswegRow kissZahlweg = zahlwegTable.FindByBaZahlungswegID(externalID);
                            if (kissZahlweg != null)
                                PscdSentBLL.SavePscdSentZahlungsweg(kissZahlweg.BaZahlungswegID, kissZahlweg.BaZahlungswegTS, sapID);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                }
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

        #region Create BP Person helper methods

        private static BAPIFKKVKPI1[] GetAccountPartnerDetail(string bpNumber)
        {
            BAPIFKKVKPI1 step4_t_ctracPartnerDetailItem = new BAPIFKKVKPI1();
            step4_t_ctracPartnerDetailItem.LINE_NUMBER = "0001"; // fix value because we have a 1-to-1 relationship between business partner and contract account
            step4_t_ctracPartnerDetailItem.BUSPARTNER = bpNumber;
            step4_t_ctracPartnerDetailItem.COMP_CODE = "5550"; // fix value
            step4_t_ctracPartnerDetailItem.STANDARD_COMP_CODE = "5550"; // fix value
            step4_t_ctracPartnerDetailItem.DUNN_PROC = "01"; // ToDo: noch offen
            step4_t_ctracPartnerDetailItem.ACCT_RELAT = "01"; // fix value, means 'account holder'
            step4_t_ctracPartnerDetailItem.TOLER_GROUP = "0001"; // fix value
            return new BAPIFKKVKPI1[] { step4_t_ctracPartnerDetailItem };
        }

        private static BAPIBUS1006_ADDRESS GetAdressData(KiSSDB.BaAdresseRow address, string wohnsitzCountry)
        {
            BAPIBUS1006_ADDRESS step1_AddressData = new BAPIBUS1006_ADDRESS();
            step1_AddressData.STANDARDADDRESS = "X";
            step1_AddressData.STREET = address.Strasse;
            step1_AddressData.HOUSE_NO = address.HausNr;
            step1_AddressData.CITY = address.Ort;
            step1_AddressData.POSTL_COD1 = address.PLZ;
            step1_AddressData.PO_BOX = address.Postfach;
            step1_AddressData.COUNTRY = wohnsitzCountry;
            step1_AddressData.VALIDFROMDATE = SapHelper.ConvertDateObject(address["DatumVon"]);
            step1_AddressData.VALIDTODATE = SapHelper.ConvertDateToEndObject(address["DatumBis"]);
            //step1_AddressData.VALIDFROMDATE = SapHelper.ConvertDateObject(new DateTime(1900, 1, 1));
            //step1_AddressData.VALIDTODATE = SapHelper.ConvertDateToEndObject(new DateTime(9999, 12, 31));
            return step1_AddressData;
        }

        private static BAPIBUS1006_ADDRESS_X GetAdressDataX()
        {
            BAPIBUS1006_ADDRESS_X item = new BAPIBUS1006_ADDRESS_X();
            item.STANDARDADDRESS = "X";
            item.STREET = "X";
            item.HOUSE_NO = "X";
            item.CITY = "X";
            item.POSTL_COD1 = "X";
            item.PO_BOX = "X";
            item.COUNTRY = "X";
            item.VALIDFROMDATE = "X";
            item.VALIDTODATE = "X";
            //item.VALIDFROMDATE = SapHelper.ConvertDateObject(new DateTime(1900, 1, 1));
            //item.VALIDTODATE = SapHelper.ConvertDateToEndObject(new DateTime(9999, 12, 31));
            return item;
        }

        private static BAPIBUS1006_CENTRAL GetCentral(KiSSDB.BaPersonRow person, object sex)
        {
            BAPIBUS1006_CENTRAL step1_centralData = new BAPIBUS1006_CENTRAL();
            step1_centralData.PARTNERTYPE = SapHelper.EnumToCode(BU_BPTYPE.Personen);
            step1_centralData.PARTNERLANGUAGE = SapHelper.GetSapLanguageCode(person["SprachCode"]);
            if (sex is int)
            {
                if ((int)sex == 1)
                {
                    // männlich
                    step1_centralData.TITLE_KEY = SapHelper.EnumToCode(AD_TITLE.Herr);
                }
                else if ((int)sex == 2)
                {
                    // weiblich
                    step1_centralData.TITLE_KEY = SapHelper.EnumToCode(AD_TITLE.Frau);
                }
            }

            return step1_centralData;
        }

        private static BAPIBUS1006_CENTRAL_PERSON GetCentralPerson(KiSSDB.BaPersonRow person, object sex)
        {
            BAPIBUS1006_CENTRAL_PERSON step1_centralDataPerson = new BAPIBUS1006_CENTRAL_PERSON();
            step1_centralDataPerson.FIRSTNAME = person.Vorname;
            step1_centralDataPerson.LASTNAME = person.Name;
            step1_centralDataPerson.BIRTHNAME = person.FruehererName;
            step1_centralDataPerson.MIDDLENAME = person.Vorname2;
            //step1_centralDataPerson.SEX = SapHelper.ConvertSex(sex);
            step1_centralDataPerson.BIRTHDATE = SapHelper.ConvertDateObject(person["GeburtsDatum"]);
            step1_centralDataPerson.NATIONALITY = SapHelper.GetSapCountryCode(person["NationalitaetCode"]);
            return step1_centralDataPerson;
        }

        private static BAPIBUS1006_CENTRAL_PERSON_X GetCentralPersonX()
        {
            BAPIBUS1006_CENTRAL_PERSON_X item = new BAPIBUS1006_CENTRAL_PERSON_X();
            item.FIRSTNAME = "X";
            item.LASTNAME = "X";
            item.BIRTHNAME = "X";
            item.MIDDLENAME = "X";
            //item.SEX = "X";
            item.BIRTHDATE = "X";
            item.NATIONALITY = "X";
            return item;
        }

        private static BAPIBUS1006_CENTRAL_X GetCentralX()
        {
            BAPIBUS1006_CENTRAL_X item = new BAPIBUS1006_CENTRAL_X();
            item.PARTNERLANGUAGE = "X";
            item.TITLE_KEY = "X";
            return item;
        }

        private static BAPIFKKVKI GetContractDetail()
        {
            BAPIFKKVKI step4_ctracDetail = new BAPIFKKVKI();
            step4_ctracDetail.ACCT_NAME = "VG zu KiSS-Klient";
            return step4_ctracDetail;
        }

        //private static BAPIFKKVKCI GetAccountCreate(string bpNumber, string accountNumber)
        //{
        //   BAPIFKKVKCI step4_ctracCreateInfo = new BAPIFKKVKCI();
        //   step4_ctracCreateInfo.CONT_ACCT = accountNumber;
        //   step4_ctracCreateInfo.ACCT_CAT = SapHelper.EnumToCode(BU_CTRACCTYPE.Personen);
        //   step4_ctracCreateInfo.APPL_AREA = "P"; // fix value
        //   step4_ctracCreateInfo.BUSPARTNER = bpNumber;
        //   return step4_ctracCreateInfo;
        //}

        private static BAPIADSMTP[] GetMail(KiSSDB.BaPersonRow person)
        {
            List<BAPIADSMTP> step1_t_e_maildataList = new List<BAPIADSMTP>();
            if (!person.IsEMailNull())
            {
                BAPIADSMTP step1_mailItem = new BAPIADSMTP();
                step1_mailItem.E_MAIL = person.EMail;
                step1_mailItem.VALID_FROM = SapHelper.ConvertDateStartFrom(DateTime.Now);
                step1_mailItem.VALID_TO = SapHelper.ConvertDateEndAt(new DateTime(9999, 12, 31));
                step1_t_e_maildataList.Add(step1_mailItem);
            }
            return step1_t_e_maildataList.ToArray();
        }

        private static BAPIADTEL[] GetTelephone(KiSSDB.BaPersonRow person, string wohnsitzCountry)
        {
            List<BAPIADTEL> step1_t_telefonDataList = new List<BAPIADTEL>();
            // 4 phone items: private, business, mobile1, mobile2
            foreach (string phoneDbFieldName in new string[] { "Telefon_P", "Telefon_G", "MobilTel1", "MobilTel2" })
            {
                string phone = person[phoneDbFieldName] as string;
                if (!string.IsNullOrEmpty(phone))
                {
                    BAPIADTEL step1_telefonItem = new BAPIADTEL();
                    if (phoneDbFieldName == "Telefon_P")
                    {
                        step1_telefonItem.STD_NO = "X"; // this is the standard phone for this person
                    }
                    step1_telefonItem.COUNTRY = wohnsitzCountry;
                    step1_telefonItem.TELEPHONE = phone;
                    step1_telefonItem.VALID_FROM = SapHelper.ConvertDateStartFrom(DateTime.Now);
                    step1_telefonItem.VALID_TO = SapHelper.ConvertDateEndAt(new DateTime(9999, 12, 31));
                    step1_t_telefonDataList.Add(step1_telefonItem);
                }
            }
            return step1_t_telefonDataList.ToArray();
        }

        private BAPIADSMTX[] GetMailX(BAPIADSMTP[] step1_t_e_maildataArray)
        {
            List<BAPIADSMTX> step1_t_e_maildataList_x = new List<BAPIADSMTX>();
            foreach (BAPIADSMTP smtp in step1_t_e_maildataArray)
            {
                BAPIADSMTX x = new BAPIADSMTX();
                x.E_MAIL = "X";
                x.VALID_FROM = "X";
                x.VALID_TO = "X";
                step1_t_e_maildataList_x.Add(x);
            }
            return step1_t_e_maildataList_x.ToArray();
        }

        private BAPIADTELX[] GetTelephoneX(BAPIADTEL[] step1_t_telefonDataArray)
        {
            List<BAPIADTELX> step1_t_telefonDataList_x = new List<BAPIADTELX>();
            foreach (BAPIADTEL phoneDbFieldName in step1_t_telefonDataArray)
            {
                BAPIADTELX step1_telefonItem = new BAPIADTELX();
                step1_telefonItem.COUNTRY = "X";
                step1_telefonItem.TELEPHONE = "X";
                step1_telefonItem.VALID_FROM = "X";
                step1_telefonItem.VALID_TO = "X";
                step1_t_telefonDataList_x.Add(step1_telefonItem);
            }
            return step1_t_telefonDataList_x.ToArray();
        }

        #endregion

        #region Create BP Institution helper methods

        private static BAPIBUS1006_CENTRAL GetCentralInstitution()
        {
            BAPIBUS1006_CENTRAL step1_centralData = new BAPIBUS1006_CENTRAL();
            step1_centralData.PARTNERTYPE = SapHelper.EnumToCode(BU_BPTYPE.Organisationen);
            //step1_centralData.PARTNERLANGUAGE = LookupTables.ConvertKissLanguageToSapLanguage(institution["SprachCode"]);
            step1_centralData.TITLE_KEY = SapHelper.EnumToCode(AD_TITLE.Firma);
            return step1_centralData;
        }

        private static BAPIBUS1006_CENTRAL_ORGAN GetCentralOrganisation(KiSSDB.BaInstitutionRow institution)
        {
            BAPIBUS1006_CENTRAL_ORGAN step1_centralOrganization = new BAPIBUS1006_CENTRAL_ORGAN();
            step1_centralOrganization.NAME1 = institution.InstitutionName;
            return step1_centralOrganization;
        }

        private static BAPIFKKVKI GetCreateAccountDetailInstitution()
        {
            BAPIFKKVKI step4_ctracDetail = new BAPIFKKVKI();
            step4_ctracDetail.ACCT_NAME = "VG zu KiSS-Institution";
            return step4_ctracDetail;
        }

        private static BAPIADSMTP[] GetMailInstitution(KiSSDB.BaInstitutionRow institution)
        {
            List<BAPIADSMTP> step1_t_e_maildataList = new List<BAPIADSMTP>();
            if (!string.IsNullOrEmpty(institution.EMail))
            {
                BAPIADSMTP step1_mailItem = new BAPIADSMTP();
                step1_mailItem.E_MAIL = institution.EMail;
                step1_mailItem.VALID_FROM = SapHelper.ConvertDateStartFrom(DateTime.Now);
                step1_mailItem.VALID_TO = SapHelper.ConvertDateEndAt(new DateTime(9999, 12, 31));
                step1_t_e_maildataList.Add(step1_mailItem);
            }
            return step1_t_e_maildataList.ToArray();
        }

        private static BAPIFKKVKPI1 GetPartnerDetailItemInstitution(string businessPartnerNumber)
        {
            BAPIFKKVKPI1 step4_t_ctracPartnerDetailItem = new BAPIFKKVKPI1();
            step4_t_ctracPartnerDetailItem.LINE_NUMBER = "0001"; // fix value because we have a 1-to-1 relationship between business partner and contract account
            step4_t_ctracPartnerDetailItem.BUSPARTNER = businessPartnerNumber;
            step4_t_ctracPartnerDetailItem.COMP_CODE = "5550"; // fix value
            step4_t_ctracPartnerDetailItem.STANDARD_COMP_CODE = "5550"; // fix value
            step4_t_ctracPartnerDetailItem.DUNN_PROC = "01"; // ToDo: noch offen
            step4_t_ctracPartnerDetailItem.ACCT_RELAT = "01"; // fix value, means 'account holder'
            step4_t_ctracPartnerDetailItem.TOLER_GROUP = "0001"; // fix value
            return step4_t_ctracPartnerDetailItem;
        }

        //private static BAPIFKKVKCI GetCreateAccountInstitution(string businessPartnerNumber)
        //{
        //   BAPIFKKVKCI step4_ctracCreateInfo = new BAPIFKKVKCI();
        //   step4_ctracCreateInfo.CONT_ACCT = string.Format("00{0}", businessPartnerNumber); // Same number as business partner number with two additional leading zeros
        //   step4_ctracCreateInfo.ACCT_CAT = SapHelper.EnumToCode(BU_CTRACCTYPE.Organisationen);
        //   step4_ctracCreateInfo.APPL_AREA = "P"; // fix value
        //   step4_ctracCreateInfo.BUSPARTNER = businessPartnerNumber;
        //   return step4_ctracCreateInfo;
        //}
        private static BAPIADTEL[] GetTelephoneInstitution(KiSSDB.BaInstitutionRow institution, string country)
        {
            List<BAPIADTEL> step1_t_telefonDataList = new List<BAPIADTEL>();
            if (!string.IsNullOrEmpty(institution.Telefon))
            {
                BAPIADTEL step1_telefonItem = new BAPIADTEL();
                step1_telefonItem.STD_NO = "X"; // this is the standard phone for this person
                step1_telefonItem.COUNTRY = country;
                step1_telefonItem.TELEPHONE = institution.Telefon;
                step1_telefonItem.VALID_FROM = SapHelper.ConvertDateStartFrom(DateTime.Now);
                step1_telefonItem.VALID_TO = SapHelper.ConvertDateEndAt(new DateTime(9999, 12, 31));
                step1_t_telefonDataList.Add(step1_telefonItem);
            }
            return step1_t_telefonDataList.ToArray();
        }

        /*
        private KiSSDB.PscdCallReturnMsgDataTable ParseInstitutionReturnMessages(DTO.BAPIRET2[] returnMessages)
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
        */

        #endregion
    }
}