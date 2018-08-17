using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Web.Services.Protocols;

using KiSS4.DB;
using KiSS4.Schnittstellen.AbacFibuClassification201100;
using ApplicationParameterType = KiSS4.Schnittstellen.AbacFibuClassification201100.ApplicationParameterType;
using CostCentreElementComType = KiSS4.Schnittstellen.AbacFibuClassification201100.CostCentreElementComType;
using ElementComType = KiSS4.Schnittstellen.AbacFibuClassification201100.ElementComType;
using FindType = KiSS4.Schnittstellen.AbacFibuClassification201100.FindType;
using IntDataType = KiSS4.Schnittstellen.AbacFibuClassification201100.IntDataType;
using LevelType = KiSS4.Schnittstellen.AbacFibuClassification201100.LevelType;
using LoginLogoutResponseType = KiSS4.Schnittstellen.AbacFibuClassification201100.LoginLogoutResponseType;
using LoginType = KiSS4.Schnittstellen.AbacFibuClassification201100.LoginType;
using MessageType = KiSS4.Schnittstellen.AbacFibuClassification201100.MessageType;
using ObjectDataType = KiSS4.Schnittstellen.AbacFibuClassification201100.ObjectDataType;
using OperationType = KiSS4.Schnittstellen.AbacFibuClassification201100.OperationType;
using PingType = KiSS4.Schnittstellen.AbacFibuClassification201100.PingType;
using RequestFinishedType = KiSS4.Schnittstellen.AbacFibuClassification201100.RequestFinishedType;
using RequestParameterType = KiSS4.Schnittstellen.AbacFibuClassification201100.RequestParameterType;
using RequestType = KiSS4.Schnittstellen.AbacFibuClassification201100.RequestType;
using ResponseType = KiSS4.Schnittstellen.AbacFibuClassification201100.ResponseType;
using UserLoginType = KiSS4.Schnittstellen.AbacFibuClassification201100.UserLoginType;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten.KlientenKonto
{
    public class FibuClassificationWrapper
    {
        #region Fields

        #region Private Fields

        private AbacusConnection abaConnection;
        private RequestParameterType abaRequestParams;
        private FibuClassificationPortClient fibuClassifcationWebService;
        private Boolean loggedIn;
        private Int32 threadSleepTime = -1;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, create a new instance of the FibuClassification wrapper used for webservice call
        /// </summary>
        /// <param name="abaConnection">The connection object to Abacus</param>
        /// <param name="webServiceUri">The webservice uri to use for service</param>
        /// <param name="sleepTime">The sleep time used for the asynchron call of the webservice</param>
        public FibuClassificationWrapper(AbacusConnection abaConnection, String webServiceUri, Int32 webServiceSleepTime)
        {
            // validate parameters
            if (abaConnection == null)
            {
                throw new ArgumentNullException("abaConnection", "Invalid AbacusConnection received, cannot proceed.");
            }
            if (DBUtil.IsEmpty(webServiceUri))
            {
                throw new ArgumentNullException("webServiceUri", "Invalid WebServiceUri received, cannot proceed.");
            }
            if (webServiceSleepTime < 0 || webServiceSleepTime > 5000)
            {
                throw new ArgumentOutOfRangeException("webServiceSleepTime", "Invalid WebServiceSleepTime, cannot be negative or > 5000ms");
            }

            // apply fields
            this.abaConnection = new AbacusConnection(abaConnection);
            this.threadSleepTime = webServiceSleepTime;

            // set parameters
            SetRequestParams();

            // init webservice
            this.abaConnection.SetWebServiceUri(webServiceUri);
            EndpointAddress address = new EndpointAddress(this.abaConnection.Url); //abaconnection contains the prefix (servername:port/services/) and concatenates the webServiceUri when the Url-property is retrieved

            fibuClassifcationWebService = new FibuClassificationPortClient(new BasicHttpBinding { MessageEncoding = WSMessageEncoding.Mtom }, address);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the AbacusConnection used for webservice
        /// </summary>
        public AbacusConnection AbaConnection
        {
            get { return this.abaConnection; }
        }

        /// <summary>
        /// Get the FibuClassification to access the webservice
        /// </summary>
        public FibuClassificationPortClient FibuClassifcationWebService
        {
            get { return this.fibuClassifcationWebService; }
        }

        /// <summary>
        /// Get current state for logged in (=true) or logged out (=false)
        /// </summary>
        public Boolean LoggedIn
        {
            get { return this.loggedIn; }
        }

        /// <summary>
        /// Get the thread sleep time used for webservice
        /// </summary>
        public Int32 ThreadSleepTime
        {
            get { return this.threadSleepTime; }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Does wait loop until request is finished.
        /// </summary>
        /// <param name="requestResponse">The request response to wait until response is finished</param>
        /// <returns>The response to the given request</returns>
        private ResponseType do_IsFinishedWaitLoop(ResponseType requestResponse)
        {
            // check if call is valid
            if (requestResponse == null)
            {
                throw new NullReferenceException("The given requestResponse is invalid.");
            }

            // wait until request if finished
            return WaitAndGetRequest(requestResponse);
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Finds the konto by id
        /// </summary>
        /// <param name="klient">The klient to find within Abacus</param>
        /// <returns>Konto we found within Abacus</returns>
        public Konto FindKontoById(Klient klient)
        {
            // validate parameters
            if (klient == null)
            {
                throw new ArgumentNullException("klient", "No valid instance of Klient received, cannot continue.");
            }

            // TODO: this is not yet implemented
            throw new NotImplementedException("This call is not yet implemented and therefore cannot be used.");
        }

        /// <summary>
        /// Gets all Konto of current mandant within Abacus
        /// </summary>
        /// <param name="kontoToFind">The Konto to find within Abacus</param>
        /// <returns>A list of all Konto we found for current Mandant within Abacus</returns>
        public Dictionary<Int32, Konto> GetAllKontosOfCurrentMandant(Dictionary<Int32, Konto> kontosToFind)
        {
            // init dictionary
            Dictionary<Int32, Konto> dictOfExistingAbaKontos = new Dictionary<Int32, Konto>();

            // Erstes Element aus allen Konti aus Abacus holen
            // Da diese nicht über einen Bookmark gesucht werden kann
            // muss man mit der Suchoption "FIRST" den ersten Datensatz abfragen
            ResponseType response = BrowseKonto(String.Empty, OperationType.FIRST);

            // check if error occured in response (only if check is possible)
            if (!this.ValidateResponseType(response))
            {
                var errorMessage = ConcatMessages(response.ResponseMessage.Messages, true, "     ");
                throw new KlientenStammdatenException(String.Format("Error with Response: {0}", errorMessage));
            }

            // create new account from response
            Konto newKontoFirst = new Konto(response);

            // check if found Konto has a valid KlientenkontoNr
            if (newKontoFirst.KlientenkontoNr != null && newKontoFirst.KlientenkontoNr.HasValue)
            {
                // add to dictionary
                dictOfExistingAbaKontos.Add(newKontoFirst.KlientenkontoNr.Value, newKontoFirst);

                // check if we can find the new item in our KiSS Kontos
                if (kontosToFind.ContainsKey(newKontoFirst.KlientenkontoNr.Value))
                {
                    // found it, set flag
                    kontosToFind[newKontoFirst.KlientenkontoNr.Value].SetFoundInAbacus();
                }
            }

            // Alle weiteren Elemente werden über NEXT geholt bis der gefunde Datensatz leer ist
            while (!this.FoundAllKontos(kontosToFind) && !String.IsNullOrEmpty(response.ResponseMessage.Bookmark))
            {
                // read next response and get Konto from response
                response = BrowseKonto(response.ResponseMessage.Bookmark, OperationType.NEXT);

                // check if error occured in response (only if check is possible)
                if (!this.ValidateResponseType(response))
                {
                    var errorMessage = ConcatMessages(response.ResponseMessage.Messages, true, "     ");
                    throw new KlientenStammdatenException(String.Format("Error with Response: {0}", errorMessage));
                }

                // create new account from response
                Konto newKontoNext = new Konto(response);

                // check if found Konto has a valid KlientenkontoNr
                if (newKontoNext.KlientenkontoNr != null && newKontoNext.KlientenkontoNr.HasValue)
                {
                    // add to dictionary
                    dictOfExistingAbaKontos.Add(newKontoNext.KlientenkontoNr.Value, newKontoNext);

                    // check if we can find the new item in our KiSS Kontos
                    if (kontosToFind.ContainsKey(newKontoNext.KlientenkontoNr.Value))
                    {
                        // found it, set flag
                        kontosToFind[newKontoNext.KlientenkontoNr.Value].SetFoundInAbacus();
                    }
                }
            }

            // return all found Konto within Abacus
            return dictOfExistingAbaKontos;
        }

        /// <summary>
        /// Determines whether server is reachable
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if server is reachable otherwise, <c>false</c>.
        /// </returns>
        public bool IsServerAlive()
        {
            // setup our message to send
            String message = "Is there a man on the moon?";

            // create ping and apply message
            PingType requestPingType = new PingType();
            requestPingType.Echo = message;

            // try to call service
            PingType receivingPingType = fibuClassifcationWebService.ping(requestPingType);

            // HACK: return if server sent back our message within defined type
            return receivingPingType.Echo.Substring(receivingPingType.Echo.IndexOf(": ") + 2, receivingPingType.Echo.IndexOf("(") - ((receivingPingType.Echo.IndexOf(": ") + 2))).Equals(message);
        }

        /// <summary>
        /// Logs in to Abacus
        /// </summary>
        public void LogIn()
        {
            // logging
            DataHandler.InsertAbaLog(null, null, null, "LogIn called of FibuClassificationWrapper");

            // check if we are already logged in
            if (abaConnection.IsTokenValid())
            {
                throw new KlientenStammdatenException("Already logged in. Please logout before attempting to log in.");
            }

            try
            {
                // validate webservice
                if (fibuClassifcationWebService == null)
                {
                    throw new NullReferenceException("The reference to the FibuClassification webservice is invalid, cannot log in to Abacus.");
                }

                // get type and perform login
                LoginType loginType = GetLoginType();
                LoginLogoutResponseType loginResponse = fibuClassifcationWebService.login(loginType);

                // check result of login
                if (loginResponse == null)
                {
                    throw new NullReferenceException("The returned loginResponse is invalid, login token is null but was sent successfully, login failed.");
                }

                // valid token, apply to field
                abaConnection.LoginToken = loginResponse.LoginToken;

                // set status, we are LoggedIn
                this.loggedIn = true;
            }
            catch (SoapException soapEx)
            {
                // set status, we are not LoggedIn
                this.loggedIn = false;

                if (soapEx.Detail != null)
                {
                    var detail = soapEx.Detail;
                    string soapMessage = detail.InnerText;

                    throw new KlientenStammdatenException(
                        string.Format("Login Failed. Error: {0}", soapMessage));
                }
            }
            catch (Exception ex)
            {
                // set status, we are not LoggedIn
                this.loggedIn = false;

                // do not continue
                throw new KlientenStammdatenException("Unexpected exception occured while trying to log in to Abacus.", ex);
            }
        }

        /// <summary>
        /// Logs out from Abacus
        /// </summary>
        public void LogOut()
        {
            // logging
            DataHandler.InsertAbaLog(null, null, null, "LogOut called of FibuClassificationWrapper");

            // validate if already logged in
            if (!abaConnection.IsTokenValid())
            {
                throw new KlientenStammdatenException("No active connection to Abacus-server found, you cannot log out before you are logged in.");
            }

            // validate webservice
            if (fibuClassifcationWebService == null)
            {
                throw new NullReferenceException("The reference to the FibuClassification webservice is invalid, cannot log out from Abacus.");
            }

            // check if server is alive to perform log out
            if (!this.IsServerAlive())
            {
                throw new KlientenStammdatenException("The connection to Abacus was terminated, cannot log out from Abacus. Now, your account might be already in use for next login.");
            }

            // get type and perform logout
            LoginType loginType = GetLoginType();
            LoginLogoutResponseType logoutResponse = fibuClassifcationWebService.logout(loginType);

            // check result of logout
            if (logoutResponse == null)
            {
                throw new NullReferenceException("The logoutResponse is invalid, logout failed.");
            }

            // set status, we are LoggedOut
            this.loggedIn = false;

            // remove LoginToken
            abaConnection.LoginToken = "";
        }

        /// <summary>
        /// Saves the existing Konto in abacus.
        /// </summary>
        /// <param name="klient">The klient to save into Abacus</param>
        /// <param name="isNewKonto">True if Konto does not yet exists in Abacus, false if Konto does already exist in Abacus</param>
        public void SaveKontoInAbacus(Klient klient, Boolean isNewKonto)
        {
            // validate webservice
            if (fibuClassifcationWebService == null)
            {
                throw new NullReferenceException("The reference to the FibuClassification webservice is invalid, cannot perform operations on Abacus.");
            }

            // build up Abacus-stuff
            RequestParameterType abaConnectParam = new RequestParameterType();
            abaConnectParam.Login = GetLoginType();
            abaConnectParam.Level = LevelType.Warning;
            abaConnectParam.LevelSpecified = true;
            abaConnectParam.Revision = 0;

            ObjectDataType allParams = new ObjectDataType();
            IntDataType[] intParam = GetSearchSettings();
            allParams.IntData = intParam;
            ApplicationParameterType appParams = new ApplicationParameterType();
            appParams.Parameters = allParams;

            FibuClassificationAbaDefaultWSType dataType = new FibuClassificationAbaDefaultWSType();
            ElementComType dataStructure = CreateAccountElement(klient);
            dataType.Element = dataStructure;

            RequestType saveRequest = new RequestType();
            saveRequest.AbaConnectParam = abaConnectParam;
            saveRequest.ApplicationParam = appParams;
            saveRequest.Data = dataType;

            // save Konto in Abacus (does not matter if existing or not)
            ResponseType saveResponse = fibuClassifcationWebService.save(saveRequest);

            // check if error occured in saveResponse (only if check is possible)
            if (!this.ValidateResponseType(saveResponse))
            {
                var errorMessage = ConcatMessages(saveResponse.ResponseMessage.Messages, true, "     ");
                throw new KlientenStammdatenException(String.Format("Error with SaveResponse: {0}", errorMessage));
            }

            // wait and get the request until finished
            ResponseType finishedResponse = WaitAndGetRequest(saveResponse);

            // check if error occured in finishedResponse (only if check is possible)
            if (!this.ValidateResponseType(finishedResponse))
            {
                var errorMessage = ConcatMessages(finishedResponse.ResponseMessage.Messages, true, "     ");
                throw new KlientenStammdatenException(String.Format("Error with FinishedResponse: {0}", errorMessage));
            }
        }

        #endregion

        #region Private Static Methods

        private static StringBuilder ConcatMessages(MessageType[] messages, bool leadingNewLine, string indentString)
        {
            StringBuilder errorMessageBuilder = new StringBuilder();
            if (leadingNewLine)
            {
                errorMessageBuilder.AppendLine();
            }

            foreach (var messageType in messages)
            {
                errorMessageBuilder.AppendFormat("{0}- {1}", indentString, messageType.Text);
                errorMessageBuilder.AppendLine();
            }
            return errorMessageBuilder;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Browses to the Konto where the bookmark matches using the passed find operation.
        /// </summary>
        /// <param name="bookmark">The bookmark</param>
        /// <param name="findOperation">The find operation</param>
        /// <returns></returns>
        private ResponseType BrowseKonto(String bookmark, OperationType findOperation)
        {
            // validate webservice
            if (fibuClassifcationWebService == null)
            {
                throw new NullReferenceException("The reference to the FibuClassification webservice is invalid, cannot browse for account.");
            }

            // further on some Abacus-stuff
            FindType findParam = new FindType();
            findParam.Index = 1;
            findParam.IndexSpecified = true;
            findParam.Operation = findOperation;

            if (!String.IsNullOrEmpty(bookmark))
            {
                findParam.Bookmark = bookmark;
            }

            ObjectDataType allParams = new ObjectDataType();

            if (String.IsNullOrEmpty(bookmark))
            {
                allParams.IntData = GetSearchSettings();
            }

            findParam.KeyFields = allParams;

            RequestType findRequest = new RequestType();
            findRequest.AbaConnectParam = this.abaRequestParams;
            findRequest.FindParam = findParam;

            ResponseType findReponse = fibuClassifcationWebService.find(findRequest);

            if (!findReponse.ResponseMessage.IsFinished)
            {
                findReponse = do_IsFinishedWaitLoop(findReponse);
            }

            return findReponse;
        }

        /// <summary>
        /// Creates the account element out of the passed client that is used for the update or insert request
        /// </summary>
        /// <param name="klient">The client to apply information and create new ElementComType</param>
        /// <returns>A new instance of ElementComType with all desirec information from given client</returns>
        private ElementComType CreateAccountElement(Klient klient)
        {
            // validate parameter
            if (klient == null)
            {
                throw new ArgumentNullException("klient", "The client is invalid, cannot continue.");
            }
            else if (klient.KlientenKonto == null)
            {
                throw new ArgumentNullException(String.Format("The client '{0}, {1}' (BaPersonID={2}) has no valid account, cannot continue.", klient.Name, klient.Vorname, klient.BaPersonID));
            }
            else if (klient.KlientenKonto.KlientenkontoNr == null || !klient.KlientenKonto.KlientenkontoNr.HasValue)
            {
                throw new ArgumentNullException(String.Format("The client '{0}, {1}' (BaPersonID={2}) has no valid 'KlientenkontoNr' on given account.", klient.Name, klient.Vorname, klient.BaPersonID));
            }

            // create and apply information from client
            ElementComType dataStructure = new ElementComType();
            CostCentreElementComType[] costCenterElement = new CostCentreElementComType[1];

            costCenterElement[0] = new CostCentreElementComType();

            costCenterElement[0].Plan = 2;
            costCenterElement[0].PlanSpecified = true;

            costCenterElement[0].Variant = 1; // Variant has to be 1 save and insert actions
            costCenterElement[0].VariantSpecified = true;

            costCenterElement[0].Level = 90;
            costCenterElement[0].LevelSpecified = true;

            costCenterElement[0].Type = 1;
            costCenterElement[0].TypeSpecified = true;

            costCenterElement[0].CostCentreType = 1;
            costCenterElement[0].CostCentreTypeSpecified = true;

            // define Name as "Name Vorname, PLZ Ort"
            costCenterElement[0].Name = klient.KlientenKonto.Bezeichnung; // per definition, this field can have maximum 40 chars!

            costCenterElement[0].Identification = klient.KlientenKonto.KlientenkontoNr.Value;
            costCenterElement[0].IdentificationSpecified = true;

            costCenterElement[0].Abbreviation = klient.KlientenKonto.KlientenkontoNr.Value.ToString();

            costCenterElement[0].Reference = Convert.ToDecimal(klient.KlientenKonto.Klassierung);
            costCenterElement[0].ReferenceSpecified = true;

            costCenterElement[0].ReferenceLevel = 3;
            costCenterElement[0].ReferenceLevelSpecified = true;

            dataStructure.CostCentreElement = costCenterElement;

            // return ElementComType
            return dataStructure;
        }

        /// <summary>
        /// Determines whether all Konto are already found
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if all Konto are already found otherwise, <c>false</c>.
        /// </returns>
        private Boolean FoundAllKontos(Dictionary<Int32, Konto> kontosToFind)
        {
            // loop all Kontos and check if any is not marked as found
            foreach (Konto konto in kontosToFind.Values)
            {
                if (!konto.FoundInAbacus)
                {
                    // at least one was not found yet
                    return false;
                }
            }

            // found all
            return true;
        }

        /// <summary>
        /// Gets the LoginType and Username and Password or LoginToken depending if there is a current user logged in
        /// </summary>
        /// <returns>The LoginType which contains requested data</returns>
        private LoginType GetLoginType()
        {
            LoginType loginType = new LoginType();

            if (abaConnection.LoginToken != null)
            {
                if (abaConnection.LoginToken.Length > 0)
                {
                    loginType.Item = abaConnection.LoginToken;
                    return loginType;
                }
            }

            UserLoginType userLogin = new UserLoginType();
            userLogin.UserName = this.abaConnection.UserLogInName;
            userLogin.Password = this.abaConnection.UserPassword;
            userLogin.Mandant = this.abaConnection.MandantenNummer;

            loginType.Item = userLogin;

            return loginType;
        }

        /// <summary>
        /// Gets the search settings
        /// </summary>
        /// <returns></returns>
        private IntDataType[] GetSearchSettings()
        {
            IntDataType[] intParam = new IntDataType[4];

            /* state: (default=4)
             * 0=Kopfzeile
             * 1=Gliederung
             * 2=Druckattribute
             * 3=Klassierung
             * 4=DetailElement*/
            intParam[0] = new IntDataType();
            intParam[0].Name = "state";
            intParam[0].Value = 4;

            /* plan: (default=1)
            * 1=KTO;  // Accounts
            * 2=KST;  // CostCentre
            * 3=PRO   // */
            intParam[1] = new IntDataType();
            intParam[1].Name = "plan";
            intParam[1].Value = 2;

            //level: (default=90) 1-9,90   (only necessary when state=3 for Klassierung)
            intParam[2] = new IntDataType();
            intParam[2].Name = "level";
            intParam[2].Value = 90;

            // variant: (default=1)
            intParam[3] = new IntDataType();
            intParam[3].Name = "variant";
            intParam[3].Value = 1;

            //intParam[4] = new IntDataType();
            //intParam[4].Name = "type";
            //intParam[4].Value = 1;

            return intParam;
        }

        /// <summary>
        /// Set-up AbaConnectParam parameter of FindRequest
        /// </summary>
        private void SetRequestParams()
        {
            // Set-up AbaConnectParam parameter of FindRequest
            abaRequestParams = new RequestParameterType();
            abaRequestParams.Login = GetLoginType();
            abaRequestParams.Level = LevelType.Warning;
            abaRequestParams.LevelSpecified = true;
            abaRequestParams.Revision = 0;
        }

        /// <summary>
        /// Validate if valid response contains error message from webservice call
        /// </summary>
        /// <param name="response">The response to validate</param>
        /// <returns>True if response is empty or does not contain any error, false if response contains error message</returns>
        private Boolean ValidateResponseType(ResponseType response)
        {
            // check if error occured in response (only if check is possible)
            if (response != null &&
                response.ResponseMessage != null &&
                response.ResponseMessage.Messages != null &&
                response.ResponseMessage.Messages[0].Level == LevelType.Error)
            {
                // response contains error
                return false;
            }

            // response is empty or valid
            return true;
        }

        /// <summary>
        /// Waits the and gets request from Abacus
        /// </summary>
        /// <param name="request">The request to wait until response is finished</param>
        /// <returns>The ResponseType that was returned from Abacus for the desired request</returns>
        private ResponseType WaitAndGetRequest(ResponseType request)
        {
            // check if request is already finished
            if (request != null && request.ResponseMessage != null && request.ResponseMessage.IsFinished)
            {
                // we are already done because request.IsFinished == true
                return request;
            }

            // init vars
            Boolean isFinished = false;
            long startTime = WebServiceHelper.GetCurrentMilliseconds();
            long timeOutSeconds = 3 * 60L;
            long timeoutMilliseconds = timeOutSeconds * 1000L;
            Boolean timedOut = false;
            RequestFinishedType requestFinished = null;
            ResponseType finishedResponse = null;

            // loop until finished or timed out
            while (!isFinished && !timedOut)
            {
                // init requestFinished object if not yet done
                if (requestFinished == null)
                {
                    requestFinished = new RequestFinishedType();
                    requestFinished.RequestID = request.ResponseMessage.RequestID;

                    // validate instance and RequestID which is required for call
                    if (requestFinished == null)
                    {
                        throw new NullReferenceException("The Request object is empty, cannot check if call is finished.");
                    }
                    if (DBUtil.IsEmpty(requestFinished.RequestID))
                    {
                        throw new NullReferenceException("The Request.RequestID is empty, cannot check if call is finished.");
                    }
                }

                // wait for next check
                System.Threading.Thread.Sleep(this.ThreadSleepTime);

                // try to get response from webservice
                finishedResponse = fibuClassifcationWebService.isFinished(requestFinished);

                // check if we received a response from call
                if (finishedResponse != null)
                {
                    // get flag if call is finished
                    isFinished = finishedResponse.ResponseMessage.IsFinished;

                    // check if call is finshed
                    if (isFinished)
                    {
                        // INFO: Wait till after loop to read the returned data.
                    }
                    else if ((WebServiceHelper.GetCurrentMilliseconds() - startTime) > timeoutMilliseconds)
                    {
                        // ended in timeout (due to security reason)
                        timedOut = true;

                        // debug:writeOutputLine("FIND TIME OUT AFTER " + timeOutSeconds + " seconds !!", mLogMessageToStdOut, mLogMessageToInfoPane);
                    }
                }
                else
                {
                    // done because of no answer
                    isFinished = true;
                }
            }

            // check if we reached a timeout
            if (timedOut)
            {
                throw new TimeoutException(String.Format("Timeout-Error: This is a server error. RequestID [{0}] is still running on server.", request.ResponseMessage.RequestID));
            }

            // return response
            return finishedResponse;
        }

        #endregion

        #endregion
    }
}