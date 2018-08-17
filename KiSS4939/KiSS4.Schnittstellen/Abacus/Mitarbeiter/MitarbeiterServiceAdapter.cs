using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using KiSS4.DB;
using KiSS4.Schnittstellen.AbakusMitarbeiterWebService;

namespace KiSS4.Schnittstellen.Abacus.Mitarbeiter
{
    /// <summary>
    /// Zwischenschicht zwischen Abakus-Webservice (Pro-Infirmis) und
    /// der KiSS Business-Logik.
    /// </summary>
    public class MitarbeiterServiceAdapter
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string MANDANT_CONFIG = @"System\Schnittstellen\MA-Schnittstelle\Mandant";
        private const string TIMEOUT_RECEIVE_CONFIG = @"System\Schnittstellen\MA-Schnittstelle\TimeoutReceive";
        private const string TIMEOUT_SEND_CONFIG = @"System\Schnittstellen\MA-Schnittstelle\TimeoutSend";
        private const string URL_CONFIG = @"System\Schnittstellen\MA-Schnittstelle\WebserviceURI";

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Liefert die Mitarbeiterdaten aller Mitarbeiter eines Geschäftsbereichs. Stichtag ist der Erste des übergebenen Monats.
        /// </summary>
        /// <param name="username">Username für den Zugriff ins ABAKUS.</param>
        /// <param name="pwd">Passwort.</param>
        /// <param name="jahr">Das Jahr des Stichtags.</param>
        /// <param name="monat">Der Monat des Stichtags</param>
        /// <param name="geschaeftsbereich">Der Geschäftsbereich der zu liefernden Mitarbeiter. (Division)</param>
        /// <returns></returns>
        public IList<MitarbeiterDTO> GetAlleMitarbeiterDaten(string username, string pwd, int jahr, int monat, int geschaeftsbereich)
        {
            var service = GetService();

            var mandant = DBUtil.GetConfigInt(MANDANT_CONFIG, 800);

            var request = new QueryAllEmployeesRequest();
            request.passwordAbacus = username;
            request.usernameAbacus = pwd;
            request.yearRecordDate = jahr;
            request.monthRecordDate = monat;
            request.mandator = mandant;
            request.division = geschaeftsbereich;

            var mainRequest = new getAllEmployeeDataRequest();
            mainRequest.queryAllEmployeesRequest = request;

            getAllEmployeeDataResponse response;
            try
            {
                response = service.getAllEmployeeData(mainRequest);
            }

            //SOAP Fault (eventuell fachliche Fehlermeldung vom anbieter enthalten).
            catch (FaultException fe)
            {
                throw new MitarbeiterServiceAdapterException(fe);
            }

            //Allgemeine Excepiton technischer Natur
            catch (Exception e)
            {
                throw new MitarbeiterServiceAdapterException(e);
            }

            return ConvertToMitarbeiterDTOList(response, monat, jahr);
        }

        /// <summary>
        /// Liefert die Mitarbeiterdaten aller Mitarbeiter eines Geschäftsbereichs. Stichtag ist der Erste des übergebenen Monats.
        /// Geliefert werden die Mitarbeiterdaten der mittels Parameter mitarbeiterNrs angeforderten Mitarbeiter
        /// sowie die Mitarb = eiterdaten aller Mitarbeiter des Geschäftsbereichs, welche nicht in der Liste des Parameters mitarbeiterNrsExisting vorkommen.
        ///
        /// Ein Mitarbeiter wird also zurückgegeben wenn seine MitarbeiterNr
        ///   - in der Liste mitarbeiterNrs vorkommt
        ///   oder
        ///   - in der Liste mitarbeiterNrsExisting NICHT vorkommt.
        ///
        /// Ist die Liste in Parameter mitarbeiterNrs leer, werden nur die neuen Mitarbeiter (welche nicht in Liste in Parameter mitarbeiterNrsExisting enthalten sind) geliefert.
        /// Ist die Liste in Parameter mitarbeiterNrsExisting leer, werden alle Mitarbeiter des übergebenen Geschäftsbereichs geliefert (unabhängig des Zustands von mitarbeiterNrs).
        /// </summary>
        /// <param name="username">Username für den Zugriff ins ABAKUS.</param>
        /// <param name="pwd">Passwort.</param>
        /// <param name="jahr">Das Jahr des Stichtags.</param>
        /// <param name="monat">Der Monat des Stichtags.</param>
        /// <param name="mitarbeiterNrs">Eine Liste von Mitarbeiter-Nr der zu liefernden Mitarbeiter.</param>
        /// <param name="mitarbeiterNrsExisting">Eine Liste von Mitarbeiter-Nr der bereits exportierten Mitarbeiter (dient zur Erkennung von "neuen" Mitarbeitern, welche in jedem Fall geliefert werden müssen, unabhängig davon, ob sie in Parameter mitarbeiterNrs vorkommen oder nicht).</param>
        /// <param name="geschaeftsbereich">Der Geschäftsbereich der zu liefernden Mitarbeiter. (Division)</param>
        /// <returns></returns>
        public IList<MitarbeiterDTO> GetMitarbeiterDaten(string username, string pwd, int jahr, int monat, IList<int> mitarbeiterNrs, IList<int> mitarbeiterNrsExisting, int geschaeftsbereich)
        {
            var service = GetService();

            var mandant = DBUtil.GetConfigInt(MANDANT_CONFIG, 800);

            //Mitarbeiternummer
            var mitarbeiterNrsArray = new long[mitarbeiterNrs.Count()];
            for (var i = 0; i < mitarbeiterNrsArray.Length; i++)
            {
                mitarbeiterNrsArray[i] = mitarbeiterNrs[i];
            }

            //Mitarbeiternummer existierend
            var mitarbeiterNrsExistingArray = new long[mitarbeiterNrsExisting.Count];
            for (var i = 0; i < mitarbeiterNrsExistingArray.Length; i++)
            {
                mitarbeiterNrsExistingArray[i] = mitarbeiterNrsExisting[i];
            }

            var request = new QueryEmployeeRequest();
            request.passwordAbacus = pwd;
            request.usernameAbacus = username;
            request.yearRecordDate = jahr;
            request.monthRecordDate = monat;
            request.mandator = mandant;
            request.division = geschaeftsbereich;
            request.allKnownEmployees = mitarbeiterNrsExistingArray;
            request.queryEmployees = mitarbeiterNrsArray;

            var mainRequest = new getEmployeeDataRequest();
            mainRequest.queryEmployeeRequest = request;

            getEmployeeDataResponse response;
            try
            {
                response = service.getEmployeeData(mainRequest);
            }

            //SOAP Fault (eventuell fachliche Fehlermeldung vom anbieter enthalten).
            catch (FaultException fe)
            {
                throw new MitarbeiterServiceAdapterException(fe);
            }

            //Allgemeine Excepiton technischer Natur
            catch (Exception e)
            {
                throw new MitarbeiterServiceAdapterException(e);
            }
            return ConvertToMitarbeiterDTOList(response, monat, jahr);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Konvertiert ein SalaryRecord in ein MitarbeiterDTO Objekt.
        /// </summary>
        /// <param name="salaryRecord"></param>
        /// <param name="stichMonat"> </param>
        /// <param name="stichJahr"> </param>
        /// <returns></returns>
        private MitarbeiterDTO ConvertToMitarbeiterDTO(SalaryRecord salaryRecord, int stichMonat, int stichJahr)
        {
            var dto = new MitarbeiterDTO();

            //Validierungen
            if (salaryRecord.employeeData == null)
            {
                throw new MitarbeiterServiceAdapterException("EmployeeData ist null. Bitte Administrator kontaktieren.");
            }
            if (salaryRecord.salaryAmounts == null)
            {
                throw new MitarbeiterServiceAdapterException("SalaryAmounts ist null. Bitte Administrator kontaktieren.");
            }
            if (salaryRecord.targetTime == null)
            {
                throw new MitarbeiterServiceAdapterException("TargetTime ist null. Bitte Administrator kontaktieren.");
            }

            //EmployeeData
            dto.Kostenstelle = salaryRecord.employeeData.CCenter1;
            dto.EMail = salaryRecord.employeeData.EMail;
            dto.FibuKonto = salaryRecord.employeeData.accountA1;
            dto.StrasseUndNummer = salaryRecord.employeeData.strasseHausNr;
            dto.StrasseZusatz = salaryRecord.employeeData.zusatz;
            dto.PostfachUndNr = salaryRecord.employeeData.postfachUndNr;
            dto.GeburtsDatum = salaryRecord.employeeData.birthday;
            dto.Ort = salaryRecord.employeeData.city;
            dto.Land = salaryRecord.employeeData.country;
            dto.EintrittsDatum = salaryRecord.employeeData.dateIn;
            dto.AustrittsDatum = salaryRecord.employeeData.dateOut;
            dto.Geschaeftsbereich = salaryRecord.employeeData.division;
            dto.MitarbeiterNummer = salaryRecord.employeeData.employeeNumber;
            dto.VorName = salaryRecord.employeeData.firstName;

            //functionCode ist in Abacus ein alphanumerischer Wert
            if (!string.IsNullOrEmpty(salaryRecord.employeeData.functionId))
            {
                int functionCode;
                if (int.TryParse(salaryRecord.employeeData.functionId, out functionCode))
                {
                    dto.Funktion = functionCode;
                }
                else
                {
                    throw new MitarbeiterServiceAdapterException("EmployeeData.functionId enthält einen nicht-numerischen Wert. Dieser Wert kann nicht importiert werden. Bitte Abacus-Administrator kontaktieren.");
                }
            }

            dto.LanguageCodeString = salaryRecord.employeeData.languageCode;
            dto.Name = salaryRecord.employeeData.name;
            dto.PlzArbeitsort = salaryRecord.employeeData.national1;
            dto.TelefonNrPrivat = salaryRecord.employeeData.phone1;
            dto.TelefonNrGesch = salaryRecord.employeeData.phone2;
            dto.Plz = salaryRecord.employeeData.postalCode;
            dto.Kostentraeger = salaryRecord.employeeData.project1;

            dto.Qualifikation = salaryRecord.employeeData.qualificationNumber;

            dto.Geschlecht = salaryRecord.employeeData.sex;
            dto.FaxNr = salaryRecord.employeeData.telefax;
            dto.TelefonNrMobil = salaryRecord.employeeData.telex;
            dto.StichMonat = stichMonat;
            dto.StichJahr = stichJahr;
            dto.LohnTyp = salaryRecord.employeeData.type;

            //Salary
            dto.StundenAnsatz1 = salaryRecord.salaryAmounts.amount_11;
            dto.StundenAnsatz2 = salaryRecord.salaryAmounts.amount_12;
            dto.StundenAnsatz3 = salaryRecord.salaryAmounts.amount_13;
            dto.StundenAnsatz4 = salaryRecord.salaryAmounts.amount_17;
            dto.BeschaeftigungsGrad = salaryRecord.salaryAmounts.amount_3;

            dto.StundenAnsatz11 = salaryRecord.salaryAmounts.amount_51;
            dto.StundenAnsatz12 = salaryRecord.salaryAmounts.amount_52;
            dto.StundenAnsatz13 = salaryRecord.salaryAmounts.amount_53;
            dto.StundenAnsatz14 = salaryRecord.salaryAmounts.amount_54;
            dto.StundenAnsatz15 = salaryRecord.salaryAmounts.amount_55;
            dto.StundenAnsatz16 = salaryRecord.salaryAmounts.amount_56;

            dto.GueltigkeitsDatumBeschaeftigungsgradAenderung = salaryRecord.salaryAmounts.amount_70;

            dto.SollStundenProTag = salaryRecord.salaryAmounts.amount_71;

            dto.GueltigkeitsDatumSollStundenProTag = salaryRecord.salaryAmounts.amount_72;

            dto.FerienAnspruchAnzahlStunden = salaryRecord.salaryAmounts.amount_73;

            dto.GueltigkeitsDatumFerienanspruchProJahr = salaryRecord.salaryAmounts.amount_74;

            dto.FerienKuerzungAnzahlStunden = salaryRecord.salaryAmounts.amount_75;

            dto.AusbezahlteUeberstunden = salaryRecord.salaryAmounts.amount_76;

            dto.GueltigkeitsDatumAusbezahlteUeberstunden = salaryRecord.salaryAmounts.amount_77;

            //TargetTime
            dto.Januar = salaryRecord.targetTime.january;
            dto.Februar = salaryRecord.targetTime.february;
            dto.Maerz = salaryRecord.targetTime.march;
            dto.April = salaryRecord.targetTime.april;
            dto.Mai = salaryRecord.targetTime.may;
            dto.Juni = salaryRecord.targetTime.june;
            dto.Juli = salaryRecord.targetTime.july;
            dto.August = salaryRecord.targetTime.august;
            dto.September = salaryRecord.targetTime.september;
            dto.Oktober = salaryRecord.targetTime.october;
            dto.November = salaryRecord.targetTime.november;
            dto.Dezember = salaryRecord.targetTime.december;
            dto.PlzArbeitsortSollarbeitszeit = salaryRecord.targetTime.workArea;
            dto.TotalJahr = salaryRecord.targetTime.yearTotal;

            return dto;
        }

        /// <summary>
        /// Konvertiert getAllEmployeeeDataResponse in eine Liste mit
        /// MitarbeiterDTO Objekten.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="stichMonat"> </param>
        /// <param name="stichJahr"> </param>
        /// <returns></returns>
        private IList<MitarbeiterDTO> ConvertToMitarbeiterDTOList(getEmployeeDataResponse response, int stichMonat, int stichJahr)
        {
            var result = new List<MitarbeiterDTO>();
            foreach (var salaryRecord in response.@return)
            {
                var dto = ConvertToMitarbeiterDTO(salaryRecord, stichMonat, stichJahr);
                result.Add(dto);
            }
            return result;
        }

        /// <summary>
        /// Konvertiert getAllEmployeeeDataResponse in eine Liste mit
        /// MitarbeiterDTO Objekten.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="stichMonat"> </param>
        /// <param name="stichJahr"> </param>
        /// <returns></returns>
        private IList<MitarbeiterDTO> ConvertToMitarbeiterDTOList(getAllEmployeeDataResponse response, int stichMonat, int stichJahr)
        {
            var result = new List<MitarbeiterDTO>();
            foreach (var salaryRecord in response.@return)
            {
                var dto = ConvertToMitarbeiterDTO(salaryRecord, stichMonat, stichJahr);
                result.Add(dto);
            }
            return result;
        }

        /// <summary>
        /// Erstellt den Service und konfiguriert die Web-Service URL und die
        /// Verbindungsparameter.
        /// </summary>
        /// <returns></returns>
        private EmployeeQueryPortType GetService()
        {
            //Binding zusammenstellen (Werte wurden durch Service-Anbieter emphohlen).
            //Bei Bedarf in XConfig auslagern!
            var binding = new BasicHttpBinding();

            binding.MaxReceivedMessageSize = 999999999;

            var nbrMinutesTimeoutSend = DBUtil.GetConfigInt(TIMEOUT_SEND_CONFIG, 5);
            var nbrMinutesTimeoutReceive = DBUtil.GetConfigInt(TIMEOUT_RECEIVE_CONFIG, 5);

            //Timespan(int hours, int minutes, int seconds)
            var timeoutSend = new TimeSpan(0, nbrMinutesTimeoutSend, 0);
            var timeoutReceive = new TimeSpan(0, nbrMinutesTimeoutReceive, 0);
            binding.CloseTimeout = timeoutSend;
            binding.OpenTimeout = timeoutSend;
            binding.SendTimeout = timeoutSend;
            binding.ReceiveTimeout = timeoutReceive;

            var url = DBUtil.GetConfigString(URL_CONFIG, "http://ZHAB001:8181/ProInfirmisSalary/services/EmployeeQuery.EmployeeQueryHttpSoap11Endpoint/");

            //EnpointAdresse zusammenstellen
            var address = new EndpointAddress(url);

            //Service erstellen
            var service = new EmployeeQueryPortTypeClient(binding, address);

            return service;
        }

        #endregion

        #endregion
    }
}