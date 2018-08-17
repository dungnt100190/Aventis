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
using KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.BpAnlegen;

namespace KiSSSvc.SAP.PSCD.BudgetData
{
    public class Stammdaten
    {
        private MI_BUDGET_DATA001Service svcBpAnlegen;

        /// <summary>
        /// Constructor
        /// </summary>
        public Stammdaten()
        {
            svcBpAnlegen = WebServiceSource.GetBpAnlegenWS();
        }

        public CreateObjectResult CreateAndSubmitBusinessPartnerInstitution(int baInstitutionID, UserInfo user, ref string warningMsg)
        {
            KiSSDB.BaInstitutionRow institution = BaInstitutionBLL.GetInstitution(baInstitutionID);
            PscdSentBLL.SendState institutionSendState = PscdSentBLL.HasInstitutionBeenChanged(baInstitutionID, institution.BaInstitutionTSCast);

            KiSSDB.BaAdresseRow address = BaAdresseBLL.GetAdressOfInstitution(baInstitutionID);
            PscdSentBLL.SendState addressSendState = PscdSentBLL.HasAdresseBeenChanged(address.BaAdresseID, address.BaAdresseTSCast);
            bool zahlwegChanged = BaZahlungswegBLL.HaveZahlungswegOfInstitutionChanged(baInstitutionID);

            if (institutionSendState == PscdSentBLL.SendState.Unchanged && addressSendState == PscdSentBLL.SendState.Unchanged && !zahlwegChanged)
            {
                //Log.Info(typeof(Stammdaten), string.Format("Institution mit ID {0} und ihre Adresse wurden nicht geändert seit der letzten Übertragung an PSCD", baInstitutionID));
                return CreateObjectResult.Success; // ToDo: don't return yet
            }
            else if (institutionSendState != PscdSentBLL.SendState.NotYetSent &&
                        (institutionSendState == PscdSentBLL.SendState.Changed ||
                         (institutionSendState == PscdSentBLL.SendState.Unchanged && (addressSendState == PscdSentBLL.SendState.NotYetSent || addressSendState == PscdSentBLL.SendState.Changed) ||
                          (addressSendState == PscdSentBLL.SendState.Unchanged && zahlwegChanged))))
            {
                //Log.Info(typeof(Stammdaten), string.Format("Institution mit ID {0} und ihre Adresse wurden geändert seit der letzten Übertragung an PSCD", baInstitutionID));
                try
                {
                    return (new StammdatenMutieren()).ModifyBusinessPartnerInstitution(institution, address, user);
                }
                catch (Exception ex)
                {
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    throw;
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
            List<ZSTEP3_IBAN> step3_t_iban = new List<ZSTEP3_IBAN>();
            List<ZSTEP3_IBAN_CREATE> step3_t_iban_create = new List<ZSTEP3_IBAN_CREATE>();
            KiSSDB.BaZahlungswegDataTable zahlwegTable = BaZahlungswegBLL.GetZahlungsVerbindungByBaInstitutionID(baInstitutionID);

            foreach (KiSSDB.BaZahlungswegRow bankRow in zahlwegTable)
            {
                // we create only Bankverbindungen (Code: 3), not ESR nor Postmandat
                string ezCode = SapHelper.LookupEinzahlungsscheinCode(bankRow["EinzahlungsscheinCode"]);
                if (ezCode != "3")
                    continue;

                // IBAN is mandatory (for B(ank))
                if (string.IsNullOrEmpty(bankRow.IBANNummer))
                    throw new Exception(string.Format("Der Zahlweg der Institution {0} (ID {3}), ClearingNr {1}, Kontonummer {2} ist ungültig: Es wurde keine IBAN generiert", institution.InstitutionName, SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], !bankRow.IsPCNrNull()), BaZahlungswegBLL.GetAccountNumber(bankRow, true), baInstitutionID));

                // not an IBAN Account
                BAPIBUS1006_BANKDETAILS bankDetailItem = new BAPIBUS1006_BANKDETAILS();
                string sapCountryCode;
                bankDetailItem.BANK_KEY = SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], out sapCountryCode, !bankRow.IsPCNrNull(), bankRow.IBANNummer); ;
                bankDetailItem.BANK_CTRY = sapCountryCode;
                bankDetailItem.BANK_ACCT = BaZahlungswegBLL.GetAccountNumber(bankRow);
                bankDetailItem.ACCOUNTHOLDER = SapHelper.Truncate(institution.InstitutionName, 55);
                bankDetailItem.BANKDETAILVALIDFROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                bankDetailItem.BANKDETAILVALIDTO = SapHelper.ConvertDateToEndObject(bankRow["DatumBis"]);
                bankDetailItem.EXTERNALBANKID = bankRow.BaZahlungswegID.ToString();
                step2_t_bankDetailData.Add(bankDetailItem);

                // this structure is being filled by SAP
                ZSTEP3_IBAN ibanItem = new ZSTEP3_IBAN();
                step3_t_iban.Add(ibanItem);

                ZSTEP3_IBAN_CREATE ibanCreateItem = new ZSTEP3_IBAN_CREATE();
                ibanCreateItem.STEP3_BANKCOUNTRY_CREATE = sapCountryCode;
                ibanCreateItem.STEP3_BANKKEY_CREATE = bankDetailItem.BANK_KEY;
                ibanCreateItem.STEP3_BANKACCOUNTNUMBER_CREATE = bankDetailItem.BANK_ACCT;
                ibanCreateItem.STEP3_IBAN = SapHelper.RemoveBlanks(bankRow.IBANNummer);
                ibanCreateItem.STEP3_VALID_FROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                step3_t_iban_create.Add(ibanCreateItem);
            }

            // step 4
            BAPIFKKVKCI step4_ctracCreateInfo = GetCreateAccountInstitution(businessPartnerNumber);
            BAPIFKKVKI step4_ctracDetail = GetCreateAccountDetailInstitution();
            BAPIFKKVKPI1 step4_t_ctracPartnerDetailItem = GetPartnerDetailItemInstitution(businessPartnerNumber);

            //BAPIFKKVKLOCKSI1 step4_t_ctracLockDetailItem = new BAPIFKKVKLOCKSI1(); // für Demo noch nicht nötig

            string step4_validFrom = DateTime.Now.Date.ToString("dd.MM.yyyy"); // ToDo

            // step 6
            BUS000_EEW step6_eew = new BUS000_EEW();

            string returnMsg = "";

            string step2_bankDetailOut;
            string step4_contractAccount;
            BAPIADSMTP[] step1_t_e_mailDataOnAddress = new BAPIADSMTP[] { };
            BAPIADFAX[] step1_t_faxdata = new BAPIADFAX[] { };
            BAPIADFAX[] step1_faxdataOnAddress = new BAPIADFAX[] { };
            BAPIADTEL[] step1_t_telefonDataOnAddress = new BAPIADTEL[] { };
            BAPIBUS1006_BANKDETAILS[] step2_t_bankDetailDataArray = step2_t_bankDetailData.ToArray();
            ZSTEP3_IBAN[] step3_t_ibanArray = step3_t_iban.ToArray();
            ZSTEP3_IBAN_CREATE[] step3_t_iban_createArray = step3_t_iban_create.ToArray();
            BAPIFKKVKLOCKSI1[] step4_t_ctracLockDetail = new BAPIFKKVKLOCKSI1[] { };
            BAPIFKKVKPI1[] step4_t_ctracPartnerDetail = new BAPIFKKVKPI1[] { step4_t_ctracPartnerDetailItem };
            ZSTEP5_CTRACPSOBJECT_CREATE[] step5_t_ctracPsObject_createArray = new ZSTEP5_CTRACPSOBJECT_CREATE[] { };
            BAPIRET2[] returnMessages = new BAPIRET2[] { };
            _STZH_S_KISS_ZUS_ADRESSEN[] step1_zahlwegAdressenArray = new _STZH_S_KISS_ZUS_ADRESSEN[] { };

            PscdCallLogEntry log = new PscdCallLogEntry("MI_BUDGET_DATA001", svcBpAnlegen.Url, baInstitutionID, user);
            try
            {
                //Log.Info(svcBpAnlegen.GetType(), "Calling WebService MI_BUDGETDATA001...");
                returnMsg = svcBpAnlegen.MI_BUDGET_DATA001(
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
                    step6_eew,
                    ref returnMessages,
                    ref step1_zahlwegAdressenArray,
                    ref step1_t_e_maildataArray,
                    ref step1_t_e_mailDataOnAddress,
                    ref step1_t_faxdata,
                    ref step1_faxdataOnAddress,
                    ref step1_t_telefonDataArray,
                    ref step1_t_telefonDataOnAddress,
                    ref step2_t_bankDetailDataArray,
                    ref step3_t_ibanArray,
                    ref step3_t_iban_createArray,
                    ref step4_t_ctracLockDetail,
                    ref step4_t_ctracPartnerDetail,
                    out step2_bankDetailOut,
                    out step4_contractAccount);
                log.StopWatch();
                log.ReturnMsg = returnMsg;
                bool exception;
                log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
                if (exception)
                {
                    string exceptionMsg = "";
                    foreach (BAPIRET2 message in returnMessages)
                    {
                        exceptionMsg += string.Format("Fehlermeldung von PSCD beim Anlegen der Institution mit ID {0}: {1}{2}", baInstitutionID, message.MESSAGE, WebServiceHelperMethods.GetNewLineString());
                    }
                    throw new Exception(exceptionMsg);
                }
                else
                {
                    try
                    {
                        // Register Institution as 'sent to PSCD'
                        int receivedBpId;
                        if (int.TryParse(returnMsg, out receivedBpId) && receivedBpId == baInstitutionID)
                        {
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
                        else
                            throw new Exception(returnMsg);
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
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Exception occured in call of MI_BUDGET_DATA001.", ex);
                log.ExceptionMsg = ex.Message;
                Exception ex2 = new Exception(string.Format("Fehler beim Anlegen der Institution mit ID {0}:{1}{2}", baInstitutionID, ex.Message, WebServiceHelperMethods.GetNewLineString()), ex);
                throw ex2;
            }
            finally
            {
                log.WriteToDB();
            }
            return CreateObjectResult.Success;
        }

        public CreateObjectResult CreateAndSubmitBusinessPartnerPerson(int baPersonID, UserInfo user, ref string warningMsg)
        {
            KiSSDB.BaPersonRow person = BaPersonBLL.GetPerson(baPersonID);
            PscdSentBLL.SendState personSendstate = PscdSentBLL.HasPersonBeenChanged(baPersonID, person.BaPersonTSCast);

            KiSSDB.BaAdresseRow address = BaAdresseBLL.GetCurrentWMAOfPerson(baPersonID);
            PscdSentBLL.SendState addressSendState = PscdSentBLL.HasAdresseBeenChanged(address.BaAdresseID, address.BaAdresseTSCast);
            bool zahlwegChanged = BaZahlungswegBLL.HaveZahlungswegOfPersonChanged(baPersonID);
            if (personSendstate == PscdSentBLL.SendState.Unchanged && addressSendState == PscdSentBLL.SendState.Unchanged && !zahlwegChanged)
            {
                //Log.Info(typeof(Stammdaten), string.Format("Person mit ID {0} und ihre WMA wurden nicht geändert seit der letzten Übertragung an PSCD", baPersonID));
                return CreateObjectResult.Success; // ToDo: don't return yet
            }
            else if (personSendstate != PscdSentBLL.SendState.NotYetSent   // Person (inkl. allen dazumal zugehörigen Stammdaten) wurde bereits mal gesendet
                     && (personSendstate == PscdSentBLL.SendState.Changed   // und (     Person hat geändert
                         || addressSendState == PscdSentBLL.SendState.NotYetSent // oder Adresse ist noch nicht gesendet
                         || addressSendState == PscdSentBLL.SendState.Changed    // oder Adresse hat geändert
                         || zahlwegChanged))                                      // oder ein Zahlweg hat geändert)
            {
                //Log.Info(typeof(Stammdaten), string.Format("Person mit ID {0} und ihre WMA wurden geändert seit der letzten Übertragung an PSCD", baPersonID));
                try
                {
                    return (new StammdatenMutieren()).ModifyBusinessPartnerPerson(person, address, user);
                }
                catch (Exception ex)
                {
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                    throw;
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

            // step 2 and 3: Bankverbindungen (bank/iban)
            List<BAPIBUS1006_BANKDETAILS> step2_t_bankDetailData = new List<BAPIBUS1006_BANKDETAILS>();
            List<ZSTEP3_IBAN> step3_t_iban = new List<ZSTEP3_IBAN>();
            List<ZSTEP3_IBAN_CREATE> step3_t_iban_create = new List<ZSTEP3_IBAN_CREATE>();
            List<_STZH_S_KISS_ZUS_ADRESSEN> step1_zahlwegAdressen = new List<_STZH_S_KISS_ZUS_ADRESSEN>();

            KiSSDB.BaZahlungswegDataTable zahlwegTable = BaZahlungswegBLL.GetZahlungswegeOfPerson(baPersonID);
            foreach (KiSSDB.BaZahlungswegRow bankRow in zahlwegTable)
            {
                // we create only Bankverbindungen (Code: 3), not ESR nor Postmandat
                string ezCode = SapHelper.LookupEinzahlungsscheinCode(bankRow["EinzahlungsscheinCode"]);
                if (ezCode != "3")
                    continue;

                // IBAN is mandatory (for B(ank))
                if (string.IsNullOrEmpty(bankRow.IBANNummer))
                    throw new Exception(string.Format("Der Zahlweg von {0} {1} (ID {4}), ClearingNr {2}, Kontonummer {3} ist ungültig: Es wurde keine IBAN generiert", person.Vorname, person.Name, SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], !bankRow.IsPCNrNull()), BaZahlungswegBLL.GetAccountNumber(bankRow, true), baPersonID));

                // Account
                BAPIBUS1006_BANKDETAILS bankDetailItem = new BAPIBUS1006_BANKDETAILS();
                string sapLandCode;
                bankDetailItem.BANK_KEY = SapHelper.GetClearingNrFromBaBankID(bankRow["BaBankID"], out sapLandCode, !bankRow.IsPCNrNull(), bankRow.IBANNummer);
                bankDetailItem.BANK_CTRY = sapLandCode;
                bankDetailItem.EXTERNALBANKID = bankRow.BaZahlungswegID.ToString();
                bankDetailItem.BANK_ACCT = BaZahlungswegBLL.GetAccountNumber(bankRow);
                bankDetailItem.ACCOUNTHOLDER = SapHelper.Truncate(string.Format("{0} {1}", person.Vorname, person.Name), 55);
                bankDetailItem.BANKDETAILVALIDFROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                bankDetailItem.BANKDETAILVALIDTO = SapHelper.ConvertDateToEndObject(bankRow["DatumBis"]);

                step2_t_bankDetailData.Add(bankDetailItem);

                // this structure is being filled by SAP
                ZSTEP3_IBAN ibanItem = new ZSTEP3_IBAN();
                step3_t_iban.Add(ibanItem);

                ZSTEP3_IBAN_CREATE ibanCreateItem = new ZSTEP3_IBAN_CREATE();
                ibanCreateItem.STEP3_BANKCOUNTRY_CREATE = sapLandCode;
                ibanCreateItem.STEP3_BANKKEY_CREATE = bankDetailItem.BANK_KEY;
                ibanCreateItem.STEP3_BANKACCOUNTNUMBER_CREATE = bankDetailItem.BANK_ACCT;
                ibanCreateItem.STEP3_IBAN = SapHelper.RemoveBlanks(bankRow.IBANNummer);
                //				ibanCreateItem.STEP3_VALID_FROM = SapHelper.ConvertDateObject(bankRow["DatumVon"]);
                ibanCreateItem.STEP3_VALID_FROM = SapHelper.ConvertDate(new DateTime(1900, 1, 1));

                if (!bankRow.WMAVerwenden)
                {
                    bankDetailItem.ACCOUNTHOLDER = SapHelper.Truncate(bankRow.AdresseName, 55);
                    step1_zahlwegAdressen.Add(GetZahlwegAdressData(bankRow, baPersonID, wohnsitzCountry));
                }

                step3_t_iban_create.Add(ibanCreateItem);
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

            // Sozialversicherungsnummer, 8182
            step6_eew._STZH_SOZ_SOVNR = string.IsNullOrEmpty(person.Versichertennummer) ? null : person.Versichertennummer;

            if (!person.IsZIPNrNull())
                step6_eew._STZH_SOZ_ZIPNR = person.ZIPNr.ToString();

            try
            {
                KiSSDB.PersonInfoRow info = PersonInfoBLL.GetPersonInfo(baPersonID);
                if (info != null)
                {
                    step6_eew._STZH_SOZ_HEIMAT = info.Heimatort;
                    step6_eew._STZH_SOZ_GPWVC = info.WVCode;
                    step6_eew._STZH_SOZ_WVGVON = SapHelper.ConvertDateObject(info["DatumVon"]);
                    step6_eew._STZH_SOZ_WVGBIS = SapHelper.ConvertDateToEndObject(info["DatumBis"]);
                    step6_eew._STZH_SOZ_UEINH = info.IsWVEinheitNull() ? null : info.WVEinheit.ToString();
                    step6_eew._STZH_SOZ_UTRAE = info.IsWVTraegerNull() || !info.WVTraeger ? "" : "X";
                    step6_eew._STZH_SOZ_WVUPE = info.IsWVPersonenNull() ? null : info.WVPersonen.ToString();
                }
            }
            catch (Exception exception)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }

            string returnMsg = "";
            string step2_bankDetailOut;
            string step4_contractAccount;
            BAPIADSMTP[] step1_t_e_mailDataOnAddress = new BAPIADSMTP[] { };
            BAPIADFAX[] step1_t_faxdata = new BAPIADFAX[] { };
            BAPIADFAX[] step1_faxdataOnAddress = new BAPIADFAX[] { };
            BAPIADTEL[] step1_t_telefonDataOnAddress = new BAPIADTEL[] { };
            BAPIBUS1006_BANKDETAILS[] step2_t_bankDetailDataArray = step2_t_bankDetailData.ToArray();
            ZSTEP3_IBAN[] step3_t_ibanArray = step3_t_iban.ToArray();
            ZSTEP3_IBAN_CREATE[] step3_t_iban_createArray = step3_t_iban_create.ToArray();
            BAPIFKKVKLOCKSI1[] step4_t_ctracLockDetail = new BAPIFKKVKLOCKSI1[] { };
            ZSTEP5_CTRACPSOBJECT_CREATE[] step5_t_ctracPsObject_createArray = new ZSTEP5_CTRACPSOBJECT_CREATE[] { };
            BAPIRET2[] returnMessages = new BAPIRET2[] { };
            _STZH_S_KISS_ZUS_ADRESSEN[] step1_zahlwegAdressenArray = step1_zahlwegAdressen.ToArray();
            //_STZH_S_KISS_ZUS_ADRESSEN[] step1_zahlwegAdressenArray = new _STZH_S_KISS_ZUS_ADRESSEN[] { };

            PscdCallLogEntry log = new PscdCallLogEntry("MI_BUDGET_DATA001", svcBpAnlegen.Url, baPersonID, user);
            try
            {
                //Log.Info(svcBpAnlegen.GetType(), "Calling WebService MI_BUDGETDATA001...");
                returnMsg = svcBpAnlegen.MI_BUDGET_DATA001(
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
                    ref returnMessages,
                    ref step1_zahlwegAdressenArray,
                    ref step1_t_e_maildataArray,
                    ref step1_t_e_mailDataOnAddress,
                    ref step1_t_faxdata,
                    ref step1_faxdataOnAddress,
                    ref step1_t_telefonDataArray,
                    ref step1_t_telefonDataOnAddress,
                    ref step2_t_bankDetailDataArray,
                    ref step3_t_ibanArray,
                    ref step3_t_iban_createArray,
                    ref step4_t_ctracLockDetail,
                    ref step4_t_ctracPartnerDetail,
                    out step2_bankDetailOut,
                    out step4_contractAccount);
                log.StopWatch();
                log.ReturnMsg = returnMsg;
                bool exception;
                log.ErrorMsgs = ParseReturnMessages(returnMessages, out exception);
                if (exception)
                {
                    string exceptionMsg = "";
                    foreach (BAPIRET2 message in returnMessages)
                    {
                        exceptionMsg += string.Format("Fehlermeldung von PSCD beim Anlegen der Person mit ID {0}: {1}{2}", bpNumber, message.MESSAGE, WebServiceHelperMethods.GetNewLineString());
                    }

                    if (exceptionMsg.Contains("Geschäftspartner") && exceptionMsg.Contains("ist bereits vorhanden"))
                    {
                        // Die Person war schon früher mal korrekt ans PSCD übermittelt worden, aber aus irgendeinem Grund weiss Kiss nichts mehr davon
                        // Wir akzeptieren dies hier normal, schicken aber sicherheitshalber die Daten trotzdem nochmals rüber
                        //Log.Info(typeof(Stammdaten), string.Format("Person mit ID {0} und ihre WMA wurden geändert seit der letzten Übertragung an PSCD", baPersonID));
                        try
                        {
                            return (new StammdatenMutieren()).ModifyBusinessPartnerPerson(person, address, user);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), ex);
                            throw;
                        }
                    }
                    else
                    {
                        throw new Exception(exceptionMsg);
                    }
                }
                else
                {
                    try
                    {
                        int receivedBpId;
                        if (int.TryParse(returnMsg, out receivedBpId) && receivedBpId == baPersonID)
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
                        else
                            throw new Exception(returnMsg);
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
                Exception ex2 = new Exception(string.Format("Fehler beim Anlegen der Person mit ID {0}:{1}{2}", baPersonID, ex.Message, WebServiceHelperMethods.GetNewLineString()), ex);
                throw ex2;
            }
            finally
            {
                log.WriteToDB();
            }
            return CreateObjectResult.Success;
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
            step1_AddressData.C_O_NAME = address.Zusatz;
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

        private static BAPIFKKVKI GetContractDetail()
        {
            BAPIFKKVKI step4_ctracDetail = new BAPIFKKVKI();
            step4_ctracDetail.ACCT_NAME = "VG zu KiSS-Klient";
            return step4_ctracDetail;
        }

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
            return step1_zahlwegAddressData;
        }

        private void SubmitInvolvierteInstitutionen(int baPersonID, UserInfo user, ref string warningMsg)
        {
            int[] involvierteInstitutionIDs = FaInvolvierteInstitutionBLL.GetInvolvierteInstitutionenOfPerson(baPersonID);

            //if (involvierteInstitutionIDs.Length > 0)
            //   Log.Info(this.GetType(), string.Format("Übertrage {0} Institutionen...", involvierteInstitutionIDs.Length));

            string errorMessages = "";

            foreach (int institutionID in involvierteInstitutionIDs)
            {
                try
                {
                    //Log.Info(this.GetType(), string.Format("Erstelle Institution mit ID {0}", institutionID));
                    CreateAndSubmitBusinessPartnerInstitution(institutionID, user, ref warningMsg);
                }
                catch (Exception ex)
                {
                    errorMessages += ex.Message + WebServiceHelperMethods.GetNewLineString();
                    Log.Error(System.Reflection.MethodBase.GetCurrentMethod(), "Institution konnte nicht erstellt werden", ex);
                }
            }
            if (!string.IsNullOrEmpty(errorMessages))
                throw new Exception(errorMessages);
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

        private static BAPIBUS1006_CENTRAL_ORGAN GetCentralOrganisation(KiSSDB.BaInstitutionRow institution)
        {
            BAPIBUS1006_CENTRAL_ORGAN step1_centralOrganization = new BAPIBUS1006_CENTRAL_ORGAN();
            step1_centralOrganization.NAME1 = SapHelper.Truncate(institution.InstitutionName, 35);
            //institution.InstitutionName == null ? null : institution.InstitutionName.Substring(0, Math.Min(35, institution.InstitutionName.Length));
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