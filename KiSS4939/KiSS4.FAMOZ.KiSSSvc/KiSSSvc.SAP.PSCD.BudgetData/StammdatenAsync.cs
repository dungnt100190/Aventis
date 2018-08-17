using System;
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
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.BpAnlegen;
using DTO = KiSSSvc.SAP.Helpers.DataObjects;

namespace KiSSSvc.SAP.PSCD.BudgetData
{
    public class StammdatenAsync
    {
        private const string CALL_ID_CREATE_INSTITUTION_DATA = "CSBPID_";
        private const string CALL_ID_CREATE_PERSON_DATA = "CSBPPD_";
        private MI_BUDGET_CREA_SOAP_OUTService svcBpAnlegen;

        /// <summary>
        /// Constructor
        /// </summary>
        public StammdatenAsync()
        {
            svcBpAnlegen = WebServiceSource.GetBpAnlegenAsyncWS();
        }

        #region Create BP Person

        /// <summary>
        /// Creates the and submit business partner person.
        /// </summary>
        /// <param name="baPersonID">The ba person ID.</param>
        /// <param name="userID">The user ID.</param>
        /// <returns></returns>
        public ReturnMsgAsync CreateAndSubmitBusinessPartnerPerson(int baPersonID, UserInfo userInfo)
        {
            Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().GetType(), String.Format("Incoming Create BPP Request for User:  '{0}', BPPersonId: '{1}'", userInfo.UserID, baPersonID));

            string callId = String.Concat(CALL_ID_CREATE_PERSON_DATA, baPersonID);
            ReturnMsgAsync retMsg = null;

            try
            {
                retMsg = TransactionControlService.Instance.GetReturnMsgForCallId(callId);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
            }

            if (retMsg != null)
            {
                retMsg.ObjectID = baPersonID;
                return retMsg;
            }
            Log.Debug(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType, String.Format("Submitting new BPP Data: '{0}' for user: '{1}'", baPersonID, userInfo));

            // For Testing:
            //long test_transactionID = KeysBLL.GetBelegNr("TRANS");
            //Log.Info(typeof(Stammdaten), string.Format("Generated Transaction ID: '{0}'", test_transactionID));
            //string test_transactionIDStr = SapHelper.GetTransactionID(test_transactionID);
            //ReturnMsgAsync test_retMsg = new ReturnMsgAsync(test_transactionIDStr); return test_retMsg;

            KiSSDB.BaPersonRow person = BaPersonBLL.GetPerson(baPersonID);
            PscdSentBLL.SendState personSendstate = PscdSentBLL.HasPersonBeenChanged(baPersonID, person.BaPersonTSCast);

            KiSSDB.BaAdresseRow address = BaAdresseBLL.GetCurrentWMAOfPerson(baPersonID);
            PscdSentBLL.SendState addressSendState = PscdSentBLL.HasAdresseBeenChanged(address.BaAdresseID, address.BaAdresseTSCast);
            bool zahlwegChanged = BaZahlungswegBLL.HaveZahlungswegOfPersonChanged(baPersonID);
            if (personSendstate == PscdSentBLL.SendState.Unchanged && addressSendState == PscdSentBLL.SendState.Unchanged)
            {
                String infoMsg = string.Format("Person mit ID {0} und ihre WMA wurden nicht geändert seit der letzten Übertragung an PSCD", baPersonID);
                Log.Info(typeof(Stammdaten), infoMsg);
                ReturnMsgAsync msgRet = ReturnMsgAsync.Success;
                msgRet.Message = infoMsg;
                msgRet.TransactionStatus = TransactionStatus.successful;
                return msgRet; // ToDo: don't return yet
            }
            else if (personSendstate == PscdSentBLL.SendState.Changed ||
                      (personSendstate == PscdSentBLL.SendState.Unchanged && (addressSendState == PscdSentBLL.SendState.NotYetSent || addressSendState == PscdSentBLL.SendState.Changed) ||
                      (addressSendState == PscdSentBLL.SendState.Unchanged && zahlwegChanged)))
            {
                String infoMsg = string.Format("Person mit ID {0}, ihre WMA oder ihr Zahlwege wurden geändert seit der letzten Übertragung an PSCD", baPersonID);
                Log.Info(typeof(Stammdaten), infoMsg);
                try
                {
                    return (new StammdatenMutierenAsync()).ModifyBusinessPartnerPerson(person, address, userInfo);
                }
                catch (Exception ex)
                {
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    ReturnMsgAsync msgRet = ReturnMsgAsync.Exception(ex.Message);
                    msgRet.TransactionStatus = TransactionStatus.error;
                    return msgRet;
                }
            }

            string wohnsitzCountry = SapHelper.GetSapCountryCode(address["BaLandID"]);
            object sex = person["GeschlechtCode"];
            string bpNumber = SapHelper.GetBusinessPartnerNumber(baPersonID);// baPersonID.ToString("0000000000"); //GetExternalNumber(person);
            string accountNumber = SapHelper.GetContractAccountNumber(baPersonID);

            // Personendaten
            BAPIBUS1006_CENTRAL_PERSON step1_centralDataPerson = GetCentralPerson(person, sex);
            BAPIBUS1006_ADDRESS step1_AddressData = GetAdressData(address, wohnsitzCountry);
            BAPIBUS1006_CENTRAL step1_centralData = GetCentral(person, sex);
            BAPIADTEL[] step1_t_telefonDataArray = GetTelephone(person, wohnsitzCountry);
            BAPIADSMTP[] step1_t_e_maildataArray = GetMail(person);

            // step 2 and 3: bank/iban
            List<BAPIBUS1006_BANKDETAILS> step2_t_bankDetailData = new List<BAPIBUS1006_BANKDETAILS>();
            List<ZSTEP3_IBAN_CREATE> step3_t_iban_create = new List<ZSTEP3_IBAN_CREATE>();
            KiSSDB.BaZahlungswegDataTable zahlwegTable = BaZahlungswegBLL.GetZahlungswegeOfPerson(baPersonID);
            foreach (KiSSDB.BaZahlungswegRow bankRow in zahlwegTable)
            {
                string ezCode = SapHelper.LookupEinzahlungsscheinCode(bankRow["EinzahlungsscheinCode"]);
                // ESR werden nicht als Stammdaten angelegt
                if (ezCode == "1")
                    continue;

                // IBAN is mandatory (for B(ank))
                if (ezCode == "3" && string.IsNullOrEmpty(bankRow.IBANNummer))
                    throw new Exception(string.Format("Der Zahlweg von {0} {1}, ClearingNr {2}, Kontonummer {3} ist ungültig: Es wurde keine IBAN generiert", person.Vorname, person.Name, SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], !bankRow.IsPCNrNull()), BaZahlungswegBLL.GetAccountNumber(bankRow, true)));

                // Account
                BAPIBUS1006_BANKDETAILS bankDetailItem = new BAPIBUS1006_BANKDETAILS();
                string sapCountryCode;
                bankDetailItem.BANK_KEY = SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], out sapCountryCode, !bankRow.IsPCNrNull(), bankRow.IBANNummer);//["ClearingNummer"] as string;
                bankDetailItem.BANK_CTRY = sapCountryCode;
                if (ezCode == "3")
                    bankDetailItem.BANK_ACCT = BaZahlungswegBLL.GetAccountNumber(bankRow);
                bankDetailItem.ACCOUNTHOLDER = string.Format("{0} {1}", person.Vorname, person.Name);
                bankDetailItem.BANKDETAILVALIDFROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                bankDetailItem.BANKDETAILVALIDTO = SapHelper.ConvertDateToEndObject(bankRow["DatumBis"]);
                bankDetailItem.EXTERNALBANKID = bankRow.BaZahlungswegID.ToString();
                step2_t_bankDetailData.Add(bankDetailItem);
                if (ezCode == "3")
                {
                    ZSTEP3_IBAN_CREATE ibanCreateItem = new ZSTEP3_IBAN_CREATE();
                    ibanCreateItem.STEP3_BANKCOUNTRY_CREATE = "CH"; // ToDo !!
                    ibanCreateItem.STEP3_BANKKEY_CREATE = bankDetailItem.BANK_KEY;
                    ibanCreateItem.STEP3_BANKACCOUNTNUMBER_CREATE = bankDetailItem.BANK_ACCT;
                    ibanCreateItem.STEP3_IBAN = SapHelper.RemoveBlanks(bankRow.IBANNummer);
                    ibanCreateItem.STEP3_VALID_FROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                    step3_t_iban_create.Add(ibanCreateItem);
                }
            }

            // step 4
            BAPIFKKVKCI step4_ctracCreateInfo = GetAccountCreate(bpNumber, accountNumber);
            BAPIFKKVKI step4_ctracDetail = GetContractDetail();
            BAPIFKKVKPI1[] step4_t_ctracPartnerDetail = GetAccountPartnerDetail(bpNumber);

            //BAPIFKKVKLOCKSI1 step4_t_ctracLockDetailItem = new BAPIFKKVKLOCKSI1(); // für Demo noch nicht nötig

            string step4_validFrom = DateTime.Now.Date.ToString("dd.MM.yyyy"); // ToDo

            // step 6
            BUS000_EEW step6_eew = new BUS000_EEW();
            step6_eew._STZH_SOZ_AHVNR = string.IsNullOrEmpty(person.AHVNummer) ? null : person.AHVNummer.Replace(".", "");
            if (!person.IsZIPNrNull())
                step6_eew._STZH_SOZ_ZIPNR = person.ZIPNr.ToString();

            KiSSDB.PersonInfoRow info = PersonInfoBLL.GetPersonInfo(baPersonID);
            if (info != null)
            {
                step6_eew._STZH_SOZ_HEIMAT = info.Heimatort;
                step6_eew._STZH_SOZ_GPWVC = info.WVCode;
                step6_eew._STZH_SOZ_WVGVON = SapHelper.ConvertDateObject(info["DatumVon"]);
                step6_eew._STZH_SOZ_WVGBIS = SapHelper.ConvertDateToEndObject(info["DatumBis"]);
            }

            long transactionID = KeysBLL.GetBelegNr("TRANS");
            string transactionIDStr = SapHelper.GetTransactionID(transactionID);

            BAPIADSMTP[] step1_t_e_mailDataOnAddress = new BAPIADSMTP[] { };
            BAPIADFAX[] step1_t_faxdata = new BAPIADFAX[] { };
            BAPIADFAX[] step1_faxdataOnAddress = new BAPIADFAX[] { };
            BAPIADTEL[] step1_t_telefonDataOnAddress = new BAPIADTEL[] { };
            BAPIBUS1006_BANKDETAILS[] step2_t_bankDetailDataArray = step2_t_bankDetailData.ToArray();
            ZSTEP3_IBAN_CREATE[] step3_t_iban_createArray = step3_t_iban_create.ToArray();
            BAPIFKKVKLOCKSI1[] step4_t_ctracLockDetail = new BAPIFKKVKLOCKSI1[] { };
            ZSTEP5_CTRACPSOBJECT_CREATE[] step5_t_ctracPsObject_createArray = new ZSTEP5_CTRACPSOBJECT_CREATE[] { };
            PscdCallLogEntry log = new PscdCallLogEntry("MI_BUDGET_CREA_SOAP_OUT", svcBpAnlegen.Url, baPersonID, userInfo);
            try
            {
                Log.Info(svcBpAnlegen.GetType(), "Calling WebService MI_BUDGET_CREA_SOAP_OUT...");
                svcBpAnlegen.MI_BUDGET_CREA_SOAP_OUT(
                    step1_AddressData,
                    bpNumber,
                    step1_centralData,
                    null,
                    step1_centralDataPerson,
                    SapHelper.EnumToCode(BU_BPCATEGORY.NatuerlichePerson),
                    SapHelper.EnumToCode(BU_BPGROUP.Personen),
                    step4_ctracCreateInfo,
                    step4_ctracDetail,
                    step4_validFrom,
                    step5_t_ctracPsObject_createArray,
                    step6_eew,
                    transactionIDStr,
                    step1_t_e_maildataArray,
                    step1_t_e_mailDataOnAddress,
                    step1_t_faxdata,
                    step1_faxdataOnAddress,
                    step1_t_telefonDataArray,
                    step1_t_telefonDataOnAddress,
                    step2_t_bankDetailDataArray,
                    step3_t_iban_createArray,
                    step4_t_ctracLockDetail,
                    step4_t_ctracPartnerDetail);

                Log.Info(svcBpAnlegen.GetType(), "Response from MI_BUDGET_CREA_SOAP_OUT");
                log.StopWatch();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                log.ExceptionMsg = ex.Message;
                Exception ex2 = new Exception(string.Format("Fehler beim Verbinden vom KiSS-Server zu XI (beim Anlegen der Person mit ID {0}):{1}{2}", baPersonID, ex.Message, WebServiceHelperMethods.GetNewLineString()), ex);
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

        #region Create BP Person helper methods

        private static BAPIFKKVKCI GetAccountCreate(string bpNumber, string accountNumber)
        {
            BAPIFKKVKCI step4_ctracCreateInfo = new BAPIFKKVKCI();
            step4_ctracCreateInfo.CONT_ACCT = accountNumber;
            step4_ctracCreateInfo.ACCT_CAT = SapHelper.EnumToCode(BU_CTRACCTYPE.Personen);
            step4_ctracCreateInfo.APPL_AREA = "P"; // fix value
            step4_ctracCreateInfo.BUSPARTNER = bpNumber;
            return step4_ctracCreateInfo;
        }

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
            step1_AddressData.EXTADDRESSNUMBER = address.BaAdresseID.ToString();
            //step1_AddressData.VALIDFROMDATE = SapHelper.ConvertDateObject(new DateTime(1900, 1, 1));
            //step1_AddressData.VALIDTODATE = SapHelper.ConvertDateToEndObject(new DateTime(9999, 12, 31));
            return step1_AddressData;
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

        private static BAPIFKKVKI GetContractDetail()
        {
            BAPIFKKVKI step4_ctracDetail = new BAPIFKKVKI();
            step4_ctracDetail.ACCT_NAME = "VG zu KiSS-Klient";
            return step4_ctracDetail;
        }

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

        private void SubmitInvolvierteInstitutionen(int baPersonID, UserInfo userInfo)
        {
            int[] involvierteInstitutionIDs = FaInvolvierteInstitutionBLL.GetInvolvierteInstitutionenOfPerson(baPersonID);

            if (involvierteInstitutionIDs.Length > 0)
                Log.Info(this.GetType(), string.Format("Submitting {0} Institutions...", involvierteInstitutionIDs.Length));

            string errorMessages = "";

            foreach (int institutionID in involvierteInstitutionIDs)
            {
                try
                {
                    Log.Info(this.GetType(), string.Format("Creating Institution with ID {0}", institutionID));
                    CreateAndSubmitBusinessPartnerInstitution(institutionID, userInfo);
                }
                catch (Exception ex)
                {
                    errorMessages += ex.Message + WebServiceHelperMethods.GetNewLineString();
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Failed to create Institution", ex);
                }
            }
            if (!string.IsNullOrEmpty(errorMessages))
                throw new Exception(errorMessages);
        }

        #endregion

        #endregion

        #region Create BP Institution

        public ReturnMsgAsync CreateAndSubmitBusinessPartnerInstitution(int baInstitutionID, UserInfo userInfo)
        {
            string callId = String.Concat(CALL_ID_CREATE_INSTITUTION_DATA, baInstitutionID);
            ReturnMsgAsync retMsg = null;

            try
            {
                retMsg = TransactionControlService.Instance.GetReturnMsgForCallId(callId);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
            }

            if (retMsg != null)
            {
                retMsg.ObjectID = baInstitutionID;
                return retMsg;
            }

            KiSSDB.BaInstitutionRow institution = BaInstitutionBLL.GetInstitution(baInstitutionID);
            PscdSentBLL.SendState institutionSendState = PscdSentBLL.HasInstitutionBeenChanged(baInstitutionID, institution.BaInstitutionTSCast);

            KiSSDB.BaAdresseRow address = BaAdresseBLL.GetAdressOfInstitution(baInstitutionID);
            PscdSentBLL.SendState addressSendState = PscdSentBLL.HasAdresseBeenChanged(address.BaAdresseID, address.BaAdresseTSCast);
            bool zahlwegChanged = BaZahlungswegBLL.HaveZahlungswegOfInstitutionChanged(baInstitutionID);
            // ToDo: WV-Code changed

            if (institutionSendState == PscdSentBLL.SendState.Unchanged && addressSendState == PscdSentBLL.SendState.Unchanged && !zahlwegChanged)
            {
                Log.Info(typeof(Stammdaten), string.Format("Institution {0}, ihre Adresse und ihre Bankverbindungen wurden nicht verändert seit der letzten Übertragung an PSCD", baInstitutionID));
                return ReturnMsgAsync.Success;
            }
            else if (institutionSendState == PscdSentBLL.SendState.Changed ||
                      (institutionSendState == PscdSentBLL.SendState.Unchanged && (addressSendState == PscdSentBLL.SendState.NotYetSent || addressSendState == PscdSentBLL.SendState.Changed) ||
                      (addressSendState == PscdSentBLL.SendState.Unchanged && zahlwegChanged)))
            {
                String infoMsg = string.Format("Institution {0}, ihre Adresse oder ihre Bankverbindungen wurden verändert seit der letzten Übertragung an PSCD", baInstitutionID);
                Log.Info(typeof(Stammdaten), infoMsg);
                try
                {
                    return (new StammdatenMutierenAsync()).ModifyBusinessPartnerInstitution(institution, address, userInfo);
                }
                catch (Exception ex)
                {
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    ReturnMsgAsync msgRet = ReturnMsgAsync.Exception(ex.Message);
                    msgRet.Message = infoMsg;
                    msgRet.TransactionStatus = TransactionStatus.warning;
                    return msgRet;
                }
            }

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
            List<ZSTEP3_IBAN_CREATE> step3_t_iban_create = new List<ZSTEP3_IBAN_CREATE>();
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
                    ZSTEP3_IBAN_CREATE ibanCreateItem = new ZSTEP3_IBAN_CREATE();
                    ibanCreateItem.STEP3_BANKCOUNTRY_CREATE = sapCountryCode;
                    ibanCreateItem.STEP3_BANKKEY_CREATE = bankDetailItem.BANK_KEY;
                    ibanCreateItem.STEP3_BANKACCOUNTNUMBER_CREATE = bankDetailItem.BANK_ACCT;
                    ibanCreateItem.STEP3_IBAN = SapHelper.RemoveBlanks(bankRow.IBANNummer);
                    ibanCreateItem.STEP3_VALID_FROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                    step3_t_iban_create.Add(ibanCreateItem);
                }
            }

            // step 4
            BAPIFKKVKCI step4_ctracCreateInfo = GetCreateAccountInstitution(businessPartnerNumber);
            BAPIFKKVKI step4_ctracDetail = GetCreateAccountDetailInstitution();
            BAPIFKKVKPI1 step4_t_ctracPartnerDetailItem = GetPartnerDetailItemInstitution(businessPartnerNumber);

            //BAPIFKKVKLOCKSI1 step4_t_ctracLockDetailItem = new BAPIFKKVKLOCKSI1(); // für Demo noch nicht nötig

            string step4_validFrom = DateTime.Now.Date.ToString("dd.MM.yyyy"); // ToDo

            long transactionID = KeysBLL.GetBelegNr("TRANS");
            string transactionIDStr = SapHelper.GetTransactionID(transactionID);
            BAPIADSMTP[] step1_t_e_mailDataOnAddress = new BAPIADSMTP[] { };
            BAPIADFAX[] step1_t_faxdata = new BAPIADFAX[] { };
            BAPIADFAX[] step1_faxdataOnAddress = new BAPIADFAX[] { };
            BAPIADTEL[] step1_t_telefonDataOnAddress = new BAPIADTEL[] { };
            BAPIBUS1006_BANKDETAILS[] step2_t_bankDetailDataArray = step2_t_bankDetailData.ToArray();
            ZSTEP3_IBAN_CREATE[] step3_t_iban_createArray = step3_t_iban_create.ToArray();
            BAPIFKKVKLOCKSI1[] step4_t_ctracLockDetail = new BAPIFKKVKLOCKSI1[] { };
            BAPIFKKVKPI1[] step4_t_ctracPartnerDetail = new BAPIFKKVKPI1[] { step4_t_ctracPartnerDetailItem };
            ZSTEP5_CTRACPSOBJECT_CREATE[] step5_t_ctracPsObject_createArray = new ZSTEP5_CTRACPSOBJECT_CREATE[] { };
            BUS000_EEW eew = new BUS000_EEW();
            PscdCallLogEntry log = new PscdCallLogEntry("MI_BUDGET_CREA_SOAP_OUT", svcBpAnlegen.Url, baInstitutionID, userInfo);
            try
            {
                Log.Info(svcBpAnlegen.GetType(), "Calling WebService MI_BUDGET_CREA_SOAP_OUT...");
                svcBpAnlegen.MI_BUDGET_CREA_SOAP_OUT(
                    step1_AddressData,
                    businessPartnerNumber,
                    step1_centralData,
                    step1_centralOrganization,
                    step1_centralDataPerson,
                    SapHelper.EnumToCode(BU_BPCATEGORY.Organisation),
                    SapHelper.EnumToCode(BU_BPGROUP.Organisationen),
                    step4_ctracCreateInfo,
                    step4_ctracDetail,
                    step4_validFrom,
                    step5_t_ctracPsObject_createArray,
                    eew,
                    transactionIDStr,
                    step1_t_e_maildataArray,
                    step1_t_e_mailDataOnAddress,
                    step1_t_faxdata,
                    step1_faxdataOnAddress,
                    step1_t_telefonDataArray,
                    step1_t_telefonDataOnAddress,
                    step2_t_bankDetailDataArray,
                    step3_t_iban_createArray,
                    step4_t_ctracLockDetail,
                    step4_t_ctracPartnerDetail);
                log.StopWatch();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Exception occured in call of MI_BUDGET_DATA001.", ex);
                log.ExceptionMsg = ex.Message;
                throw;
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

        private static BAPIFKKVKCI GetCreateAccountInstitution(string businessPartnerNumber)
        {
            BAPIFKKVKCI step4_ctracCreateInfo = new BAPIFKKVKCI();
            step4_ctracCreateInfo.CONT_ACCT = string.Format("00{0}", businessPartnerNumber); // Same number as business partner number with two additional leading zeros
            step4_ctracCreateInfo.ACCT_CAT = SapHelper.EnumToCode(BU_CTRACCTYPE.Organisationen);
            step4_ctracCreateInfo.APPL_AREA = "P"; // fix value
            step4_ctracCreateInfo.BUSPARTNER = businessPartnerNumber;
            return step4_ctracCreateInfo;
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

        //private KiSSDB.PscdCallReturnMsgDataTable ParseReturnMessages(BAPIRET2[] returnMessages)
        //{
        //   KiSSDB.PscdCallReturnMsgDataTable errorTbl = new KiSSDB.PscdCallReturnMsgDataTable();
        //   int tempInt;
        //   foreach (BAPIRET2 retMsg in returnMessages)
        //   {
        //      KiSSDB.PscdCallReturnMsgRow err = errorTbl.NewPscdCallReturnMsgRow();
        //      err.CausingSystem = retMsg.SYSTEM;
        //      err.Field = retMsg.FIELD;
        //      if (int.TryParse(retMsg.LOG_MSG_NO, out tempInt))
        //         err.LogNrInternal = tempInt;
        //      else
        //         err.SetLogNrInternalNull();
        //      err.LogNr = retMsg.LOG_NO;
        //      err.Message1 = retMsg.MESSAGE_V1;
        //      err.Message2 = retMsg.MESSAGE_V2;
        //      err.Message3 = retMsg.MESSAGE_V3;
        //      err.Message4 = retMsg.MESSAGE_V4;
        //      err.MessageClass = retMsg.ID;
        //      if (int.TryParse(retMsg.NUMBER, out tempInt))
        //         err.MessageNumber = tempInt;
        //      else
        //         err.SetMessageNumberNull();
        //      err.Message = retMsg.MESSAGE;
        //      err.Parameter = retMsg.PARAMETER;
        //      if (int.TryParse(retMsg.ROW, out tempInt))
        //         err.Row = tempInt;
        //      else
        //         err.SetRowNull();

        //      if (!string.IsNullOrEmpty(retMsg.TYPE))
        //         err.Severity = retMsg.TYPE;

        //      errorTbl.AddPscdCallReturnMsgRow(err);
        //   }
        //   return errorTbl;
        //}

        #endregion

        #endregion

        #region Process Response from PSCD

        public void Process_STZH_KISS_BUDGET_CREA_OUT(string STEP1_BUSINESSPARTNER, string STEP4_CONTRACTACCOUNT, string TRANSACTIONID, DTO.BAPIRET2[] RETURN_MESSAGES, DTO.BAPIBUS1006_BANKDETAILS[] STEP2_T_BANKDETAILDATA, DTO.ZSTEP3_IBAN[] STEP3_T_IBAN)
        {
            TransactionControlService.Instance.SetTransactionReturnedFromSap(TRANSACTIONID, true, null);

            if (RETURN_MESSAGES.Length > 0)
            {
                PscdCallLogEntry log = new PscdCallLogEntry("STZH_KISS_BUDGET_CREA_OUT", svcBpAnlegen.Url, -1, new UserInfo(-1, ""));
                log.ErrorMsgs = ParseReturnMessages(RETURN_MESSAGES);
                string exceptionMsg = "";
                foreach (DTO.BAPIRET2 message in RETURN_MESSAGES)
                {
                    exceptionMsg += message.MESSAGE + WebServiceHelperMethods.GetNewLineString();
                    Log.Info(svcBpAnlegen.GetType(), string.Format("ZReturnMessage: '{0}'", message.MESSAGE));
                }
                throw new Exception(exceptionMsg);
            }
            else
            {
                try
                {
                    int receivedBpId;
                    if (int.TryParse(STEP1_BUSINESSPARTNER, out receivedBpId))
                    {
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
                        foreach (DTO.BAPIBUS1006_BANKDETAILS receivedZahlweg in STEP2_T_BANKDETAILDATA)
                        {
                            KiSSDB.BaZahlungswegRow kissZahlweg = zahlwegTable.FindByBaZahlungswegID(int.Parse(receivedZahlweg.EXTERNALBANKID));
                            if (kissZahlweg != null)
                                PscdSentBLL.SavePscdSentZahlungsweg(kissZahlweg.BaZahlungswegID, kissZahlweg.BaZahlungswegTS, int.Parse(receivedZahlweg.BANKDETAILID));
                        }
                    }
                    else
                        throw new Exception(String.Format("Error updating Person/Institution: '{0}'", receivedBpId));
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

                if (retMsg.ROW.HasValue)
                    err.Row = retMsg.ROW.Value;

                if (!string.IsNullOrEmpty(retMsg.TYPE))
                    err.Severity = retMsg.TYPE;

                errorTbl.AddPscdCallReturnMsgRow(err);
            }
            return errorTbl;
        }

        #endregion
    }
}