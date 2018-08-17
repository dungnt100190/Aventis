using KiSS4.DB;
using KiSS4.Schnittstellen.AbacAddress200710;
using System;
using System.ServiceModel;
using System.Text;
using System.Web.Services.Protocols;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten.Adresse
{
    public class AddressWrapper
    {
        #region Fields

        #region Private Fields

        private AbacusConnection abaConnection;
        private AddressPortClient addressWebService;
        private Boolean loggedIn = false;
        private Int32 threadSleepTime = -1;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor, create a new instance of the Address wrapper used for webservice call
        /// </summary>
        /// <param name="abaConnection">The connection object to Abacus</param>
        /// <param name="webServiceUri">The webservice uri to use for service</param>
        /// <param name="sleepTime">The sleep time used for the asynchron call of the webservice</param>
        public AddressWrapper(AbacusConnection abaConnection, String webServiceUri, Int32 webServiceSleepTime)
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

            // init webservice
            this.abaConnection.SetWebServiceUri(webServiceUri);
            EndpointAddress address = new EndpointAddress(this.abaConnection.Url); //abaconnection contains the prefix (servername:port/services/) and concatenates the webServiceUri when the Url-property is retrieved
            addressWebService = new AddressPortClient(new BasicHttpBinding { MessageEncoding = WSMessageEncoding.Mtom }, address);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Get the AbacusConnection used for webservice
        /// </summary>
        public AbacusConnection AbaConnection
        {
            get { return this.abaConnection; }
        }

        /// <summary>
        /// Get the Address to access the webservice
        /// </summary>
        public AddressPortClient AddressWebService
        {
            get { return this.addressWebService; }
        }

        /// <summary>
        /// Get current state for logged in (=true) or logged out (=false)
        /// </summary>
        public Boolean LoggedIn
        {
            get { return loggedIn; }
        }

        /// <summary>
        /// Get the thread sleep time used for webservice
        /// </summary>
        public Int32 ThreadSleepTime
        {
            get { return this.threadSleepTime; }
        }

        #endregion Properties

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

        #endregion EventHandlers

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gets the address out of Abacus of a klient.
        /// </summary>
        /// <param name="klient">The klient.</param>
        /// <returns></returns>
        public KlientenAddress GetAddressOfKlient(Klient klient)
        {
            // Get the address of the client from Abacus
            ResponseType abaAddress = this.GetAddressInAbacus(klient);

            // check if the response contains the requested data
            if (abaAddress.DataContainer == null)
            {
                // create an empty address
                return new KlientenAddress();
            }

            // create the address from DataContainer
            return new KlientenAddress(abaAddress.DataContainer[0].AddressData);
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
            PingType receivingPingType = addressWebService.ping(requestPingType);

            // HACK: return if server sent back our message within defined type
            return receivingPingType.Echo.Substring(receivingPingType.Echo.IndexOf(": ") + 2, receivingPingType.Echo.IndexOf("(") - ((receivingPingType.Echo.IndexOf(": ") + 2))).Equals(message);
        }

        /// <summary>
        /// Logs on to Abacus.
        /// </summary>
        public void LogIn()
        {
            // logging
            DataHandler.InsertAbaLog(null, null, null, "LogIn called of AddressWrapper");

            // check if we are already logged in
            if (abaConnection.IsTokenValid())
            {
                throw new KlientenStammdatenException("Already logged in. Please logout before attempting to log in.");
            }

            try
            {
                // validate webservice
                if (addressWebService == null)
                {
                    throw new NullReferenceException("The reference to the Address webservice is invalid, cannot log in to Abacus.");
                }

                // get type and perform login
                LoginType loginType = GetLoginType();
                LoginLogoutResponseType loginResponse = addressWebService.login(loginType);

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
            DataHandler.InsertAbaLog(null, null, null, "LogOut called of AddressWrapper");

            // validate if already logged in
            if (!abaConnection.IsTokenValid())
            {
                throw new KlientenStammdatenException("No active connection to Abacus-server found, you cannot log out before you are logged in.");
            }

            // validate webservice
            if (addressWebService == null)
            {
                throw new NullReferenceException("The reference to the Address webservice is invalid, cannot log out from Abacus.");
            }

            // check if server is alive to perform log out
            if (!this.IsServerAlive())
            {
                throw new KlientenStammdatenException("The connection to Abacus was terminated, cannot log out from Abacus. Now, your account might be already in use for next login.");
            }

            // get type and perform logout
            LoginType loginType = GetLoginType();
            LoginLogoutResponseType logoutResponse = addressWebService.logout(loginType);

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
        /// Saves the client's address in Abacus
        /// </summary>
        /// <param name="klient">The client to save address in Abacus</param>
        public void SaveAddressInAbacus(Klient klient)
        {
            // Pflichtfelder: lastname, country, postcode, city, language
            if (!klient.Adresse.IsCorrectAbacusAddress())
            {
                throw new ArgumentException(String.Format("Not all required fields are valid on given client '{0}, {1}', cannot save address in Abacus. Required fields are: lastname, country, postcode, city, language.", klient.Name, klient.Vorname));
            }
            if (addressWebService == null)
            {
                throw new NullReferenceException("The reference of the address webservice is invalid, cannot continue.");
            }

            // check if need to log in
            if (!this.loggedIn)
            {
                this.LogIn();
            }

            // prepare address for Abacus
            AddressAbaDefaultType adrType = new AddressAbaDefaultType();
            adrType.AddressData = klient.Adresse.CreateAbacusType();

            // check if account is valid and contains a KlientenkontoNr
            if (klient.KlientenKonto != null &&
                klient.KlientenKonto.KlientenkontoNr.HasValue &&
                klient.KlientenKonto.KlientenkontoNr.Value > 0)
            {
                // valid KlientenkontoNr, apply to addressdata
                adrType.AddressData.AddressNumber = klient.KlientenKonto.KlientenkontoNr.Value;
                adrType.AddressData.AddressNumberSpecified = true;
            }
            else
            {
                // invalid KlientenkontoNr, cannot continue
                throw new ArgumentException(String.Format("Invalid 'KlientenkontoNr' for given client '{0}, {1}', cannot export address to Abacus.", klient.Name, klient.Vorname));
            }

            // prepare LoginParameter for the webservice request
            RequestParameterType requestParamType = new RequestParameterType();
            requestParamType.Login = GetLoginType();
            requestParamType.Level = LevelType.Warning;
            requestParamType.LevelSpecified = true;
            requestParamType.Revision = 0;

            // prepare the request
            RequestType reqType = new RequestType();
            reqType.AbaConnectParam = requestParamType;
            reqType.Data = adrType;

            // do request
            ResponseType saveResponse = addressWebService.save(reqType);

            // check if error occured in saveResponse (only if check is possible)
            if (!this.ValidateResponseType(saveResponse))
            {
                var errorMessage = ConcatMessages(saveResponse.ResponseMessage.Messages, true, "     ");
                throw new KlientenStammdatenException(String.Format("Error with SaveResponse: {0}", errorMessage));
            }

            // wait and get the request until finished
            ResponseType finishedResponse = do_IsFinishedWaitLoop(saveResponse);

            // check if error occured in finishedResponse (only if check is possible)
            if (!this.ValidateResponseType(finishedResponse))
            {
                var errorMessage = ConcatMessages(finishedResponse.ResponseMessage.Messages, true, "     ");
                throw new KlientenStammdatenException(string.Format("Error with FinishedResponse: {0}", errorMessage));
            }
        }

        #endregion Public Methods

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

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Get the address in Abacus of given client
        /// </summary>
        /// <param name="klient">The client to get address from</param>
        /// <returns>The ResponseType which should contain the address</returns>
        private ResponseType GetAddressInAbacus(Klient klient)
        {
            // check if already logged in
            if (!this.loggedIn)
            {
                this.LogIn();
            }

            // validate webservice
            if (addressWebService == null)
            {
                throw new NullReferenceException("The reference of the address webservice is invalid, cannot continue.");
            }

            // Set-up AbaConnectParam parameter of FindRequest
            RequestParameterType abaConnectParam = new RequestParameterType();
            abaConnectParam.Login = GetLoginType();
            abaConnectParam.Level = LevelType.Warning;
            abaConnectParam.LevelSpecified = true;
            abaConnectParam.Revision = 0;

            // Request extended fields data
            StringDataType[] extendedFields = new StringDataType[1];
            extendedFields[0] = new StringDataType();
            extendedFields[0].Name = "ACIncludeExtendedFields";
            extendedFields[0].Value = "all";

            ObjectDataType additionalData = new ObjectDataType();
            additionalData.StringData = extendedFields;
            abaConnectParam.Additional = additionalData;

            // Set-up AbaConnectParam parameter of FindRequest
            FindType findParam = new FindType();
            findParam.Index = 1;
            findParam.IndexSpecified = true;
            findParam.Operation = OperationType.EQUAL;

            LongDataType[] longParam = new LongDataType[1];
            longParam[0] = new LongDataType();
            longParam[0].Name = "INR";
            longParam[0].Value = (long)klient.KlientenKonto.KlientenkontoNr.Value;
            //writeOutputLine("FIND Adre.INR == " + adreINR, mLogMessageToStdOut, mLogMessageToInfoPane);

            ObjectDataType allParams = new ObjectDataType();
            allParams.LongData = longParam;
            findParam.KeyFields = allParams;

            //Request absetzen
            RequestType findRequest = new RequestType();
            findRequest.AbaConnectParam = abaConnectParam;
            findRequest.FindParam = findParam;

            // find address in Abacus
            ResponseType findReponse = addressWebService.find(findRequest);

            // check if error occured in findReponse (only if check is possible)
            if (!this.ValidateResponseType(findReponse))
            {
                var errorMessage = ConcatMessages(findReponse.ResponseMessage.Messages, true, "     ");
                throw new KlientenStammdatenException(String.Format("Error with FindReponse: {0}", errorMessage));
            }

            // wait and get the request until finished
            ResponseType finishedFindReponse = do_IsFinishedWaitLoop(findReponse);

            // check if error occured in finishedFindReponse (only if check is possible)
            if (!this.ValidateResponseType(finishedFindReponse))
            {
                var errorMessage = ConcatMessages(finishedFindReponse.ResponseMessage.Messages, true, "     ");
                throw new KlientenStammdatenException(String.Format("Error with FinishedFindReponse: {0}", errorMessage));
            }

            // return response
            return finishedFindReponse;
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
                finishedResponse = addressWebService.isFinished(requestFinished);

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

        #endregion Private Methods

        #endregion Methods
    }
}