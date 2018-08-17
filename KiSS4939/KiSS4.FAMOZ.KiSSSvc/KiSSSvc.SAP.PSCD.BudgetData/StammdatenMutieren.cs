using System;

//using KiSSSvc.SAP.PSCD.BudgetData.BudgetDatenWebReference;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Web.Services.Protocols;
using System.Xml;
using KiSSSvc.DAL;
using KiSSSvc.Logging;
using KiSSSvc.SAP.Helpers;
using KiSSSvc.SAP.PSCD.BLL;
using KiSSSvc.SAP.PSCD.BudgetData;
using KiSSSvc.SAP.PSCD.WebServiceHelper;
using KiSSSvc.SAP.PSCD.WebServiceHelper.Settings;
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.BpMutieren;

namespace KiSSSvc.SAP.PSCD.BudgetData
{
    public class StammdatenMutieren
    {
        private MI_BUDGET_DATA002Service svcBpMutieren;

        /// <summary>
        /// Constructor
        /// </summary>
        public StammdatenMutieren()
        {
            svcBpMutieren = WebServiceSource.GetBpMutierenWS();
        }

        public CreateObjectResult ModifyBusinessPartnerInstitution(KiSSDB.BaInstitutionRow institution, KiSSDB.BaAdresseRow address, UserInfo user)
        {
            string country = SapHelper.GetSapCountryCode(address["BaLandID"]);
            string businessPartnerNumber = SapHelper.GetBusinessPartnerNumber(institution.BaInstitutionID);
            string contractAccountNumber = SapHelper.GetContractAccountNumber(institution.BaInstitutionID);
            int baInstitutionID = institution.BaInstitutionID;

            // Personendaten
            BAPIBUS1006_CENTRAL_PERSON step1_centralDataPerson = new BAPIBUS1006_CENTRAL_PERSON();

            BAPIBUS1006_ADDRESS step1_AddressData = GetAdressData(address, country);
            BAPIBUS1006_ADDRESS_X step1_AddressDataX = GetAdressDataX();
            BAPIBUS1006_CENTRAL step1_centralData = GetCentralInstitution();
            BAPIBUS1006_CENTRAL_X step1_centralDataX = GetCentralInstitutionX();
            BAPIBUS1006_CENTRAL_ORGAN step1_centralOrganization = GetCentralOrganisation(institution);
            BAPIADTEL[] step1_t_telefonDataArray = GetTelephoneInstitution(institution, country);
            BAPIADSMTP[] step1_t_e_maildataArray = GetMailInstitution(institution);

            // step 2 and 3: bank/iban
            List<BAPIBUS1006_BANKDETAILS> step2_t_bankDetailData = new List<BAPIBUS1006_BANKDETAILS>();
            List<ZSTEP3_IBAN_CHANGE> step3_t_iban_create = new List<ZSTEP3_IBAN_CHANGE>();

            KiSSDB.BaZahlungswegDataTable zahlwegTable = BaZahlungswegBLL.GetZahlungsVerbindungByBaInstitutionID(baInstitutionID);
            foreach (KiSSDB.BaZahlungswegRow bankRow in zahlwegTable)
            {
                // we create only Bankverbindungen (Code: 3), not ESR nor Postmandat
                string ezCode = SapHelper.LookupEinzahlungsscheinCode(bankRow["EinzahlungsscheinCode"]);
                if (ezCode != "3")
                    continue;

                if (string.IsNullOrEmpty(bankRow.IBANNummer))
                    throw new Exception(string.Format("Der Zahlweg der Institution {0} (ID {3}), ClearingNr {1}, Kontonummer {2} ist ungültig: Es wurde keine IBAN generiert", institution.InstitutionName, SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], !bankRow.IsPCNrNull()), BaZahlungswegBLL.GetAccountNumber(bankRow, true), baInstitutionID));

                BAPIBUS1006_BANKDETAILS bankDetailItem = new BAPIBUS1006_BANKDETAILS();
                string sapLandCode;
                bankDetailItem.BANK_KEY = SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], out sapLandCode, !bankRow.IsPCNrNull(), bankRow.IBANNummer);
                bankDetailItem.BANK_CTRY = sapLandCode;
                bankDetailItem.BANK_ACCT = BaZahlungswegBLL.GetAccountNumber(bankRow);
                bankDetailItem.ACCOUNTHOLDER = SapHelper.Truncate(institution.InstitutionName, 55);
                bankDetailItem.BANKDETAILVALIDFROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                bankDetailItem.BANKDETAILVALIDTO = SapHelper.ConvertDateToEndObject(bankRow["DatumBis"]);
                bankDetailItem.EXTERNALBANKID = bankRow.BaZahlungswegID.ToString();
                // bestehende sapID eintragen
                int? sapID = PscdSentBLL.GetSapID(bankRow.BaZahlungswegID);
                if (sapID.HasValue)
                    bankDetailItem.BANKDETAILID = sapID.Value.ToString("0000");

                // if we have an IBAN-Number, send this also
                bankDetailItem.IBAN = SapHelper.RemoveBlanks(bankRow.IBANNummer);

                step2_t_bankDetailData.Add(bankDetailItem);
            }

            // step 4
            BAPIFKKVKI step4_ctracDetail = GetCreateAccountDetailInstitution();
            BAPIFKKVKPI1 step4_t_ctracPartnerDetailItem = GetPartnerDetailItemInstitution(businessPartnerNumber);

            //BAPIFKKVKLOCKSI1 step4_t_ctracLockDetailItem = new BAPIFKKVKLOCKSI1(); // für Demo noch nicht nötig

            string step4_validFrom = DateTime.Now.Date.ToString("dd.MM.yyyy"); // ToDo

            //string step2_bankDetailOut;
            BAPIADSMTP[] step1_t_e_mailDataOnAddress = new BAPIADSMTP[] { };
            BAPIADFAX[] step1_t_faxdata = new BAPIADFAX[] { };
            BAPIADFAX[] step1_faxdataOnAddress = new BAPIADFAX[] { };
            BAPIADTEL[] step1_t_telefonDataOnAddress = new BAPIADTEL[] { };
            BAPIBUS1006_BANKDETAILS[] step2_t_bankDetailDataArray = step2_t_bankDetailData.ToArray();
            ZSTEP3_IBAN_CHANGE[] step3_t_iban_changeArray = new ZSTEP3_IBAN_CHANGE[] { };// step3_t_iban_create.ToArray();
            BAPIFKKVKLOCKSI1[] step4_t_ctracLockDetail = new BAPIFKKVKLOCKSI1[] { };
            BAPIFKKVKPI1[] step4_t_ctracPartnerDetail = new BAPIFKKVKPI1[] { };// step4_t_ctracPartnerDetailItem };
            BAPIRET2[] returnMessages = new BAPIRET2[] { };

            BAPIADSMTX[] step1_t_e_mailDataOnAddress_x = new BAPIADSMTX[] { };
            BAPIADFAXX[] step1_t_faxdata_x = new BAPIADFAXX[] { };
            BAPIADFAXX[] step1_faxdataOnAddress_x = new BAPIADFAXX[] { };
            BAPIADTELX[] step1_t_telefonDataOnAddress_x = new BAPIADTELX[] { };
            ZSTEP5_CTRACPSOBJECT_CHANGE[] step5_t_ctracPsObject_changeArray = new ZSTEP5_CTRACPSOBJECT_CHANGE[] { };

            // step 6
            BUS000_EEW eew = new BUS000_EEW();
            BUS000_EEW_X eew_x = new BUS000_EEW_X();

            BAPIBUS1006_CENTRAL_PERSON_X step1_centralDataPersonX = GetCentralPersonX();
            BAPIADTELX[] step1_t_telefonDataArray_x = GetTelephoneX(step1_t_telefonDataArray);
            BAPIADSMTX[] step1_t_e_maildataArray_x = GetMailX(step1_t_e_maildataArray);
            _STZH_S_KISS_ZUS_ADRESSEN[] zahlwegAdressen = new _STZH_S_KISS_ZUS_ADRESSEN[] { };
            _STZH_S_KISS_ZUS_ADRESSEN_X[] zahlwegAdressen_x = new _STZH_S_KISS_ZUS_ADRESSEN_X[] { };

            PscdCallLogEntry log = new PscdCallLogEntry("MI_BUDGET_DATA002", svcBpMutieren.Url, baInstitutionID, user);
            try
            {
                //Log.Info(svcBpMutieren.GetType(), "Calling WebService MI_BUDGETDATA002...");
                svcBpMutieren.MI_BUDGET_DATA002(
                    businessPartnerNumber,
                    step1_centralData,
                    null,
                    null,//step1_centralDataPerson,
                    null,
                    null,//step1_centralDataPersonX,
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
                    ref returnMessages,
                    ref zahlwegAdressen,
                    ref zahlwegAdressen_x,
                    ref step1_t_e_mailDataOnAddress,
                    ref step1_t_e_mailDataOnAddress_x,
                    ref step1_faxdataOnAddress,
                    ref step1_faxdataOnAddress_x,
                    ref step1_t_telefonDataOnAddress,
                    ref step1_t_telefonDataOnAddress_x,
                    ref step1_t_faxdata,
                    ref step1_t_faxdata_x,
                    ref step1_t_e_maildataArray,
                    ref step1_t_e_maildataArray_x,
                    ref step1_t_telefonDataArray,
                    ref step1_t_telefonDataArray_x,
                    ref step2_t_bankDetailDataArray,
                    ref step3_t_iban_changeArray,
                    ref step4_t_ctracLockDetail,
                    ref step4_t_ctracPartnerDetail);
                log.StopWatch();
                bool exception;
                log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
                if (exception)
                {
                    string exceptionMsg = "";
                    foreach (BAPIRET2 message in returnMessages)
                    {
                        exceptionMsg += string.Format("Fehlermeldung von PSCD beim Mutieren der Institution mit ID {0}: {1}{2}", baInstitutionID, message.MESSAGE, WebServiceHelperMethods.GetNewLineString());
                    }
                    throw new Exception(exceptionMsg);
                }
                else
                {
                    try
                    {
                        // Register Institution as 'sent to PSCD'
                        PscdSentBLL.SavePscdSentInstitution(institution.BaInstitutionID, institution.BaInstitutionTS);
                        // Register Address as 'sent to PSCD'
                        PscdSentBLL.SavePscdSentAdresse(address.BaAdresseID, address.BaAdresseTS);
                        // Register Zahlweg as 'sent to PSCD'
                        foreach (BAPIBUS1006_BANKDETAILS receivedZahlweg in step2_t_bankDetailDataArray)
                        {
                            KiSSDB.BaZahlungswegRow kissZahlweg = zahlwegTable.FindByBaZahlungswegID(int.Parse(receivedZahlweg.EXTERNALBANKID));
                            if (kissZahlweg != null)
                                PscdSentBLL.SavePscdSentZahlungsweg(kissZahlweg.BaZahlungswegID, kissZahlweg.BaZahlungswegTS, int.Parse(receivedZahlweg.BANKDETAILID));
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    }
                }
            }
            catch (SoapException ex)
            {
                log.ExceptionMsg = SapHelper.ProcessSoapException(ex);
                throw new Exception(log.ExceptionMsg, ex);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Exception occured in call of MI_BUDGET_DATA002.", ex);
                log.ExceptionMsg = ex.Message;
                Exception ex2 = new Exception(string.Format("Fehler beim Mutieren der Institution mit ID {0}:{1}{2}", baInstitutionID, ex.Message, WebServiceHelperMethods.GetNewLineString()), ex);
                throw ex2;
            }
            finally
            {
                log.WriteToDB();
            }
            return CreateObjectResult.Success;
        }

        public CreateObjectResult ModifyBusinessPartnerPerson(KiSSDB.BaPersonRow person, KiSSDB.BaAdresseRow address, UserInfo userInfo)
        {
            int baPersonID = person.BaPersonID;
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
            List<_STZH_S_KISS_ZUS_ADRESSEN> step1_zahlwegAdressen = new List<_STZH_S_KISS_ZUS_ADRESSEN>();
            List<_STZH_S_KISS_ZUS_ADRESSEN_X> step1_zahlwegAdressen_x = new List<_STZH_S_KISS_ZUS_ADRESSEN_X>();

            KiSSDB.BaZahlungswegDataTable zahlwegTable = BaZahlungswegBLL.GetZahlungswegeOfPerson(baPersonID);
            foreach (KiSSDB.BaZahlungswegRow bankRow in zahlwegTable)
            {
                // we create only Bankverbindungen (Code: 3), not ESR nor Postmandat
                string ezCode = SapHelper.LookupEinzahlungsscheinCode(bankRow["EinzahlungsscheinCode"]);
                if (ezCode != "3")
                    continue;

                if (string.IsNullOrEmpty(bankRow.IBANNummer))
                    throw new Exception(string.Format("Der Zahlweg der Person {0} {1} (ID {4}), ClearingNr {2}, Kontonummer {3} ist ungültig: Es wurde keine IBAN generiert", person.Vorname, person.Name, SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], !bankRow.IsPCNrNull()), BaZahlungswegBLL.GetAccountNumber(bankRow, true), baPersonID));

                BAPIBUS1006_BANKDETAILS bankDetailItem = new BAPIBUS1006_BANKDETAILS();
                string sapLandCode;
                bankDetailItem.BANK_KEY = SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], out sapLandCode, !bankRow.IsPCNrNull(), bankRow.IBANNummer);
                bankDetailItem.BANK_CTRY = sapLandCode;
                bankDetailItem.BANK_ACCT = BaZahlungswegBLL.GetAccountNumber(bankRow);
                bankDetailItem.ACCOUNTHOLDER = SapHelper.Truncate(string.Format("{0} {1}", person.Vorname, person.Name), 55);
                bankDetailItem.BANKDETAILVALIDFROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                bankDetailItem.BANKDETAILVALIDTO = SapHelper.ConvertDateToEndObject(bankRow["DatumBis"]);
                bankDetailItem.EXTERNALBANKID = bankRow.BaZahlungswegID.ToString();
                // bestehende sapID eintragen
                int? sapID = PscdSentBLL.GetSapID(bankRow.BaZahlungswegID);
                if (sapID.HasValue)
                    bankDetailItem.BANKDETAILID = sapID.Value.ToString("0000");

                bankDetailItem.IBAN = SapHelper.RemoveBlanks(bankRow.IBANNummer);
                if (!bankRow.WMAVerwenden)
                {
                    bankDetailItem.ACCOUNTHOLDER = SapHelper.Truncate(bankRow.AdresseName, 55);
                    _STZH_S_KISS_ZUS_ADRESSEN zusAdresse = GetZahlwegAdressData(bankRow, baPersonID, wohnsitzCountry);
                    _STZH_S_KISS_ZUS_ADRESSEN_X zusAdresseX = GetZahlwegAdressDataX();
                    zusAdresseX.BUSINESSPARTNER = zusAdresse.BUSINESSPARTNER;
                    zusAdresseX.ADDRNUMBER = zusAdresse.ADDRNUMBER;
                    step1_zahlwegAdressen.Add(zusAdresse);
                    step1_zahlwegAdressen_x.Add(zusAdresseX);
                }
                step2_t_bankDetailData.Add(bankDetailItem);

                ZSTEP3_IBAN_CHANGE ibanChangeItem = new ZSTEP3_IBAN_CHANGE();
                ibanChangeItem.BANKCOUNTRY = bankDetailItem.BANK_CTRY;
                ibanChangeItem.BANKKEY = bankDetailItem.BANK_KEY;
                ibanChangeItem.BANKACCOUNTNUMBER = bankDetailItem.BANK_ACCT;
                ibanChangeItem.IBAN = SapHelper.RemoveBlanks(bankDetailItem.IBAN);
                ibanChangeItem.IBAN_CHANGED = "X";
                //ibanChangeItem.VALID_FROM = SapHelper.ConvertDate(new DateTime(2000, 1, 1));
                //ibanChangeItem.VALID_FROM_CHANGED = "X";
                step2_iban.Add(ibanChangeItem);
            }

            // step 4
            BAPIFKKVKI step4_ctracDetail = GetContractDetail();
            //BAPIFKKVKPI1[] step4_t_ctracPartnerDetail = GetAccountPartnerDetail(bpNumber);
            BAPIFKKVKPI1[] step4_t_ctracPartnerDetail = new BAPIFKKVKPI1[] { };// step4_t_ctracPartnerDetailItem };

            //BAPIFKKVKLOCKSI1 step4_t_ctracLockDetailItem = new BAPIFKKVKLOCKSI1(); // für Demo noch nicht nötig

            string step4_validFrom = DateTime.Now.Date.ToString("dd.MM.yyyy"); // ToDo

            // step 6
            BUS000_EEW eew = new BUS000_EEW();
            BUS000_EEW_X eew_x = new BUS000_EEW_X();

            eew._STZH_SOZ_AHVNR = string.IsNullOrEmpty(person.AHVNummer) ? null : person.AHVNummer.Replace(".", "");

            //Sozialversicherungsnummer
            eew._STZH_SOZ_SOVNR = string.IsNullOrEmpty(person.Versichertennummer) ? null : person.Versichertennummer;

            if (!person.IsZIPNrNull())
                eew._STZH_SOZ_ZIPNR = person.ZIPNr.ToString();

            try
            {
                KiSSDB.PersonInfoRow info = PersonInfoBLL.GetPersonInfo(baPersonID);
                if (info != null)
                {
                    eew._STZH_SOZ_HEIMAT = info.Heimatort;
                    eew._STZH_SOZ_GPWVC = info.WVCode;
                    eew._STZH_SOZ_WVGVON = SapHelper.ConvertDateObject(info["DatumVon"]);
                    eew._STZH_SOZ_WVGBIS = SapHelper.ConvertDateToEndObject(info["DatumBis"]);
                    eew._STZH_SOZ_UEINH = info.IsWVEinheitNull() ? null : info.WVEinheit.ToString();
                    eew._STZH_SOZ_UTRAE = info.IsWVTraegerNull() || !info.WVTraeger ? "" : "X";
                    eew._STZH_SOZ_WVUPE = info.IsWVPersonenNull() ? null : info.WVPersonen.ToString();
                }

                eew_x._STZH_SOZ_AHVNR = "X";
                eew_x._STZH_SOZ_GPWVC = "X";
                eew_x._STZH_SOZ_HEIMAT = "X";
                eew_x._STZH_SOZ_UEINH = "X";
                eew_x._STZH_SOZ_UTRAE = "X";
                eew_x._STZH_SOZ_WVGBIS = "X";
                eew_x._STZH_SOZ_WVGVON = "X";
                eew_x._STZH_SOZ_WVUPE = "X";
                eew_x._STZH_SOZ_ZIPNR = "X";
                eew_x._STZH_SOZ_SOVNR = "X";
            }
            catch (Exception exception)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }

            BAPIADSMTP[] step1_t_e_mailDataOnAddress = new BAPIADSMTP[] { };
            BAPIADSMTX[] step1_t_e_mailDataOnAddress_x = new BAPIADSMTX[] { };
            BAPIADFAX[] step1_t_faxdata = new BAPIADFAX[] { };
            BAPIADFAXX[] step1_t_faxdata_x = new BAPIADFAXX[] { };
            BAPIADFAX[] step1_faxdataOnAddress = new BAPIADFAX[] { };
            BAPIADFAXX[] step1_faxdataOnAddress_x = new BAPIADFAXX[] { };
            BAPIADTEL[] step1_t_telefonDataOnAddress = new BAPIADTEL[] { };
            BAPIADTELX[] step1_t_telefonDataOnAddress_x = new BAPIADTELX[] { };
            BAPIBUS1006_BANKDETAILS[] step2_t_bankDetailDataArray = step2_t_bankDetailData.ToArray();
            ZSTEP3_IBAN_CHANGE[] step3_t_iban_changeArray = new ZSTEP3_IBAN_CHANGE[] { };//step2_iban.ToArray(); ;
            BAPIFKKVKLOCKSI1[] step4_t_ctracLockDetail = new BAPIFKKVKLOCKSI1[] { };
            ZSTEP5_CTRACPSOBJECT_CHANGE[] step5_t_ctracPsObject_changeArray = new ZSTEP5_CTRACPSOBJECT_CHANGE[] { };
            _STZH_S_KISS_ZUS_ADRESSEN[] step1_zahlwegAdressenArray = step1_zahlwegAdressen.ToArray();
            _STZH_S_KISS_ZUS_ADRESSEN_X[] step1_zahlwegAdressen_xArray = step1_zahlwegAdressen_x.ToArray();

            BAPIRET2[] returnMessages = new BAPIRET2[] { };

            PscdCallLogEntry log = new PscdCallLogEntry("MI_BUDGET_DATA002", svcBpMutieren.Url, baPersonID, userInfo);
            try
            {
                //Log.Info(svcBpMutieren.GetType(), "Calling WebService MI_BUDGETDATA002...");
                svcBpMutieren.MI_BUDGET_DATA002(
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
                    ref returnMessages,
                    ref step1_zahlwegAdressenArray,
                    ref step1_zahlwegAdressen_xArray,
                    ref step1_t_e_mailDataOnAddress,
                    ref step1_t_e_mailDataOnAddress_x,
                    ref step1_faxdataOnAddress,
                    ref step1_faxdataOnAddress_x,
                    ref step1_t_telefonDataOnAddress,
                    ref step1_t_telefonDataOnAddress_x,
                    ref step1_t_faxdata,
                    ref step1_t_faxdata_x,
                    ref step1_t_e_maildataArray,
                    ref step1_t_e_maildataArray_x,
                    ref step1_t_telefonDataArray,
                    ref step1_t_telefonDataArray_x,
                    ref step2_t_bankDetailDataArray,
                    ref step3_t_iban_changeArray,
                    ref step4_t_ctracLockDetail,
                    ref step4_t_ctracPartnerDetail);
                bool exception;
                log.StopWatch();
                log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
                if (exception)
                {
                    string exceptionMsg = "";
                    foreach (BAPIRET2 message in returnMessages)
                    {
                        exceptionMsg += string.Format("Fehlermeldung von PSCD beim Mutieren der Person mit ID {0}: {1}{2}", bpNumber, message.MESSAGE, WebServiceHelperMethods.GetNewLineString());
                    }
                    throw new Exception(exceptionMsg);
                }
                else
                {
                    try
                    {
                        // Register Person as 'sent to PSCD'
                        PscdSentBLL.SavePscdSentPerson(baPersonID, person.BaPersonTS);
                        // Register Address as 'sent to PSCD'
                        PscdSentBLL.SavePscdSentAdresse(address.BaAdresseID, address.BaAdresseTS);
                        // Register Zahlweg as 'sent to PSCD'
                        foreach (BAPIBUS1006_BANKDETAILS receivedZahlweg in step2_t_bankDetailDataArray)
                        {
                            KiSSDB.BaZahlungswegRow kissZahlweg = zahlwegTable.FindByBaZahlungswegID(int.Parse(receivedZahlweg.EXTERNALBANKID));
                            if (kissZahlweg != null)
                                PscdSentBLL.SavePscdSentZahlungsweg(kissZahlweg.BaZahlungswegID, kissZahlweg.BaZahlungswegTS, int.Parse(receivedZahlweg.BANKDETAILID));
                        }
                        if (step1_zahlwegAdressenArray != null)
                        {
                            foreach (_STZH_S_KISS_ZUS_ADRESSEN receivedAddress in step1_zahlwegAdressenArray)
                            {
                                KiSSDB.BaZahlungswegRow kissZahlweg = zahlwegTable.FindByBaZahlungswegID(int.Parse(receivedAddress.EXTADDRESSNUMBER));
                                if (kissZahlweg != null)
                                    PscdSentBLL.SavePscdSentZahlungswegAddress(kissZahlweg.BaZahlungswegID, kissZahlweg.BaZahlungswegTS, int.Parse(receivedAddress.ADDRNUMBER));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    }
                }
            }
            catch (SoapException ex)
            {
                log.ExceptionMsg = SapHelper.ProcessSoapException(ex);
                throw new Exception(log.ExceptionMsg, ex);
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                log.ExceptionMsg = ex.Message;
                Exception ex2 = new Exception(string.Format("Fehler beim Mutieren der Person mit ID {0}:{1}{2}", baPersonID, ex.Message, WebServiceHelperMethods.GetNewLineString()), ex);
                throw ex2;
            }
            finally
            {
                log.WriteToDB();
            }
            return CreateObjectResult.Success;
        }

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
            step1_AddressData.C_O_NAME = address.Zusatz;
            step1_AddressData.COUNTRY = wohnsitzCountry;
            step1_AddressData.VALIDFROMDATE = SapHelper.ConvertDateObject(address["DatumVon"]);
            step1_AddressData.VALIDTODATE = SapHelper.ConvertDateToEndObject(address["DatumBis"]);
            step1_AddressData.EXTADDRESSNUMBER = address.BaAdresseID.ToString();

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
            item.C_O_NAME = "X";
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
            step1_centralData.AUTHORIZATIONGROUP = SapHelper.GetAuthorizationGroup();
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
            step1_centralDataPerson.FIRSTNAME = SapHelper.Truncate(person.Vorname, 35);
            step1_centralDataPerson.LASTNAME = SapHelper.Truncate(person.Name, 35);
            step1_centralDataPerson.BIRTHNAME = SapHelper.Truncate(person.FruehererName, 35);
            step1_centralDataPerson.MIDDLENAME = SapHelper.Truncate(person.Vorname2, 35);
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
            return new BAPIADSMTP[] { };
            //List<BAPIADSMTP> step1_t_e_maildataList = new List<BAPIADSMTP>();
            //if (!person.IsEMailNull())
            //{
            //   BAPIADSMTP step1_mailItem = new BAPIADSMTP();
            //   step1_mailItem.E_MAIL = person.EMail;
            //   step1_mailItem.VALID_FROM = SapHelper.ConvertDateStartFrom(DateTime.Now);
            //   step1_mailItem.VALID_TO = SapHelper.ConvertDateEndAt(new DateTime(9999, 12, 31));
            //   step1_t_e_maildataList.Add(step1_mailItem);
            //}
            //return step1_t_e_maildataList.ToArray();
        }

        private static BAPIADTEL[] GetTelephone(KiSSDB.BaPersonRow person, string wohnsitzCountry)
        {
            return new BAPIADTEL[] { };
            //List<BAPIADTEL> step1_t_telefonDataList = new List<BAPIADTEL>();
            //// 4 phone items: private, business, mobile1, mobile2
            //foreach (string phoneDbFieldName in new string[] { "Telefon_P", "Telefon_G", "MobilTel1", "MobilTel2" })
            //{
            //   string phone = person[phoneDbFieldName] as string;
            //   if (!string.IsNullOrEmpty(phone))
            //   {
            //      BAPIADTEL step1_telefonItem = new BAPIADTEL();
            //      if (phoneDbFieldName == "Telefon_P")
            //      {
            //         step1_telefonItem.STD_NO = "X"; // this is the standard phone for this person
            //      }
            //      step1_telefonItem.COUNTRY = wohnsitzCountry;
            //      step1_telefonItem.TELEPHONE = phone;
            //      step1_telefonItem.VALID_FROM = SapHelper.ConvertDateStartFrom(DateTime.Now);
            //      step1_telefonItem.VALID_TO = SapHelper.ConvertDateEndAt(new DateTime(9999, 12, 31));
            //      step1_t_telefonDataList.Add(step1_telefonItem);
            //   }
            //}
            //return step1_t_telefonDataList.ToArray();
        }

        private static _STZH_S_KISS_ZUS_ADRESSEN GetZahlwegAdressData(KiSSDB.BaZahlungswegRow bankRow, int bpNumber, string wohnsitzCountry)
        {
            _STZH_S_KISS_ZUS_ADRESSEN step1_zahlwegAddressData = new _STZH_S_KISS_ZUS_ADRESSEN();
            step1_zahlwegAddressData.STREET = bankRow.AdresseStrasse;
            step1_zahlwegAddressData.HOUSE_NO = bankRow.AdresseHausNr;
            step1_zahlwegAddressData.CITY = bankRow.AdresseOrt;
            step1_zahlwegAddressData.POSTL_COD1 = bankRow.AdressePLZ;
            step1_zahlwegAddressData.PO_BOX = bankRow.AdressePostfach;
            step1_zahlwegAddressData.COUNTRY = wohnsitzCountry;
            step1_zahlwegAddressData.VALIDFROMDATE = SapHelper.ConvertDateObject(new DateTime(1900, 1, 1));
            step1_zahlwegAddressData.VALIDTODATE = SapHelper.ConvertDateToEndObject(new DateTime(9999, 12, 31));
            step1_zahlwegAddressData.EXTADDRESSNUMBER = bankRow.BaZahlungswegID.ToString();
            step1_zahlwegAddressData.BUSINESSPARTNER = SapHelper.GetBusinessPartnerNumber(bpNumber);
            int? sapIDAddress = PscdSentBLL.GetSapIDAddress(bankRow.BaZahlungswegID);
            if (sapIDAddress.HasValue)
                step1_zahlwegAddressData.ADDRNUMBER = sapIDAddress.Value.ToString("0000000000");

            return step1_zahlwegAddressData;
        }

        private BAPIADSMTX[] GetMailX(BAPIADSMTP[] step1_t_e_maildataArray)
        {
            return new BAPIADSMTX[] { };
            //List<BAPIADSMTX> step1_t_e_maildataList_x = new List<BAPIADSMTX>();
            //foreach (BAPIADSMTP smtp in step1_t_e_maildataArray)
            //{
            //   BAPIADSMTX x = new BAPIADSMTX();
            //   x.E_MAIL = "X";
            //   x.VALID_FROM = "X";
            //   x.VALID_TO = "X";
            //   step1_t_e_maildataList_x.Add(x);
            //}
            //return step1_t_e_maildataList_x.ToArray();
        }

        private BAPIADTELX[] GetTelephoneX(BAPIADTEL[] step1_t_telefonDataArray)
        {
            return new BAPIADTELX[] { };
            //List<BAPIADTELX> step1_t_telefonDataList_x = new List<BAPIADTELX>();
            //foreach (BAPIADTEL phoneDbFieldName in step1_t_telefonDataArray)
            //{
            //   BAPIADTELX step1_telefonItem = new BAPIADTELX();
            //   step1_telefonItem.COUNTRY = "X";
            //   step1_telefonItem.TELEPHONE = "X";
            //   step1_telefonItem.VALID_FROM = "X";
            //   step1_telefonItem.VALID_TO = "X";
            //   step1_t_telefonDataList_x.Add(step1_telefonItem);

            //}
            //return step1_t_telefonDataList_x.ToArray();
        }

        private _STZH_S_KISS_ZUS_ADRESSEN_X GetZahlwegAdressDataX()
        {
            _STZH_S_KISS_ZUS_ADRESSEN_X zahlwegAddressData_x = new _STZH_S_KISS_ZUS_ADRESSEN_X();
            zahlwegAddressData_x.STREET = "X";
            zahlwegAddressData_x.HOUSE_NO = "X";
            zahlwegAddressData_x.CITY = "X";
            zahlwegAddressData_x.POSTL_COD1 = "X";
            zahlwegAddressData_x.PO_BOX = "X";
            zahlwegAddressData_x.COUNTRY = "X";
            //zahlwegAddressData_x.BUSINESSPARTNER = bpNumber;
            //zahlwegAddressData_x.EXTADDRESSNUMBER = "X";
            //zahlwegAddressData_x.ADDRNUMBER = "X";
            //zahlwegAddressData_x.VALIDFROMDATE = "X";
            //zahlwegAddressData_x.VALIDTODATE = "X";
            //zahlwegAddressData_x.EXTADDRESSNUMBER = "X";
            //zahlwegAddressData_x.BUSINESSPARTNER = "X";
            return zahlwegAddressData_x;
        }

        #endregion

        #region Create BP Institution helper methods

        private static BAPIBUS1006_CENTRAL GetCentralInstitution()
        {
            BAPIBUS1006_CENTRAL step1_centralData = new BAPIBUS1006_CENTRAL();
            step1_centralData.PARTNERTYPE = SapHelper.EnumToCode(BU_BPTYPE.Organisationen);
            //step1_centralData.PARTNERLANGUAGE = LookupTables.ConvertKissLanguageToSapLanguage(institution["SprachCode"]);
            step1_centralData.TITLE_KEY = SapHelper.EnumToCode(AD_TITLE.Firma);
            step1_centralData.AUTHORIZATIONGROUP = SapHelper.GetAuthorizationGroup();
            return step1_centralData;
        }

        private static BAPIBUS1006_CENTRAL_X GetCentralInstitutionX()
        {
            BAPIBUS1006_CENTRAL_X item = new BAPIBUS1006_CENTRAL_X();
            item.PARTNERTYPE = "X";
            item.TITLE_KEY = "X";
            item.AUTHORIZATIONGROUP = "X";
            return item;
        }

        private static BAPIBUS1006_CENTRAL_ORGAN GetCentralOrganisation(KiSSDB.BaInstitutionRow institution)
        {
            BAPIBUS1006_CENTRAL_ORGAN step1_centralOrganization = new BAPIBUS1006_CENTRAL_ORGAN();
            step1_centralOrganization.NAME1 = SapHelper.Truncate(institution.InstitutionName, 35);
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
            return new BAPIADSMTP[] { };
            //List<BAPIADSMTP> step1_t_e_maildataList = new List<BAPIADSMTP>();
            //if (!string.IsNullOrEmpty(institution.EMail))
            //{
            //   BAPIADSMTP step1_mailItem = new BAPIADSMTP();
            //   step1_mailItem.E_MAIL = institution.EMail;
            //   step1_mailItem.VALID_FROM = SapHelper.ConvertDateStartFrom(DateTime.Now);
            //   step1_mailItem.VALID_TO = SapHelper.ConvertDateEndAt(new DateTime(9999, 12, 31));
            //   step1_t_e_maildataList.Add(step1_mailItem);
            //}
            //return step1_t_e_maildataList.ToArray();
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
            return new BAPIADTEL[] { };
            //List<BAPIADTEL> step1_t_telefonDataList = new List<BAPIADTEL>();
            //if (!string.IsNullOrEmpty(institution.Telefon))
            //{
            //   BAPIADTEL step1_telefonItem = new BAPIADTEL();
            //   step1_telefonItem.STD_NO = "X"; // this is the standard phone for this person
            //   step1_telefonItem.COUNTRY = country;
            //   step1_telefonItem.TELEPHONE = institution.Telefon;
            //   step1_telefonItem.VALID_FROM = SapHelper.ConvertDateStartFrom(DateTime.Now);
            //   step1_telefonItem.VALID_TO = SapHelper.ConvertDateEndAt(new DateTime(9999, 12, 31));
            //   step1_t_telefonDataList.Add(step1_telefonItem);
            //}
            //return step1_t_telefonDataList.ToArray();
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

        #endregion
    }
}