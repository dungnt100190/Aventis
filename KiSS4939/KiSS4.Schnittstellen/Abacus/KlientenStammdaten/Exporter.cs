using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services.Protocols;

using KiSS4.DB;
using KiSS4.Schnittstellen.Abacus.KlientenStammdaten.Adresse;
using KiSS4.Schnittstellen.Abacus.KlientenStammdaten.KlientenKonto;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    public class Exporter
    {
        #region Enumerations

        public enum WorkingPart
        {
            Step1_ExportAddress = 1,
            Step2_ExportAccount = 2
        }

        #endregion

        #region Fields

        #region Private Constant/Read-Only Fields

        // const vars
        private const Int32 TOTALAMOUNTOFWORKPARTS = 2;

        #endregion

        #region Private Fields

        private String AbacusUserName = "";
        private String AbacusUserPassword = "";
        private AddressWrapper addressWebServiceWrapper;
        private Dictionary<Int32, Konto> dictOfExistingAbaKontos;
        private BackgroundWorker exportWorker;
        private FibuClassificationWrapper fibuWebServiceWrapper;
        private Boolean isExportCanceled = false;
        private Boolean isInitialized = false;
        private Boolean KissConfig_CompareAccount = false;
        private Boolean KissConfig_CompareAddress = false;

        // define fields to store values
        private Boolean KissConfig_DebugFlag = false;

        private Int32 KissConfig_WebServiceSleepTime = -1;
        private String KissConfig_WebServiceUri = "";
        private String KissConfig_WebServiceUriAddress = "";
        private String KissConfig_WebServiceUriFibuClassification = "";
        private List<KlientExceptionPair> klientenMitAddressExportException;
        private List<KlientExceptionPair> klientenMitKontoExportException;
        private List<Klient> klientenToExport;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of Exporter using BackgroundWorker
        /// </summary>
        /// <param name="abacusUserName">The user name to use for login to Abacus</param>
        /// <param name="abacusUserPassword">The user password to use for login to Abacus</param>
        public Exporter(String abacusUserName, String abacusUserPassword)
        {
            // set status
            this.SetNewStatus("ConstructorOfExporter", "Lesen der Einstellungen für den Export...", StatusChangedEventArgs.StatusMessageEvents.GeneralExport, false);

            // validate parameters
            if (DBUtil.IsEmpty(abacusUserName))
            {
                throw new ArgumentOutOfRangeException("abacusUserName", "Invalid user name received, cannot continue without valid user name.");
            }
            if (DBUtil.IsEmpty(abacusUserPassword))
            {
                throw new ArgumentOutOfRangeException("abacusUserPassword", "Invalid user password received, cannot continue without valid user password.");
            }

            // apply fields
            this.AbacusUserName = abacusUserName;
            this.AbacusUserPassword = abacusUserPassword;

            // get config values
            this.KissConfig_DebugFlag = DBUtil.GetConfigBool(Constants.KissConfig_DebugFlag, false);
            this.KissConfig_WebServiceUri = DBUtil.GetConfigString(Constants.KissConfig_WebServiceUri, "");
            this.KissConfig_WebServiceUriAddress = DBUtil.GetConfigString(Constants.KissConfig_WebServiceUriAddress, "");
            this.KissConfig_WebServiceUriFibuClassification = DBUtil.GetConfigString(Constants.KissConfig_WebServiceUriFibuClassification, "");
            this.KissConfig_WebServiceSleepTime = DBUtil.GetConfigInt(Constants.KissConfig_WebServiceSleepTime, 200);
            this.KissConfig_CompareAddress = DBUtil.GetConfigBool(Constants.KissConfig_CompareAddress, false);
            this.KissConfig_CompareAccount = DBUtil.GetConfigBool(Constants.KissConfig_CompareAccount, false);

            // validate
            if (DBUtil.IsEmpty(this.KissConfig_WebServiceUri) ||
                DBUtil.IsEmpty(this.KissConfig_WebServiceUriAddress) ||
                DBUtil.IsEmpty(this.KissConfig_WebServiceUriFibuClassification))
            {
                throw new ArgumentNullException("Invalid configuration values detected, cannot continue without proper settings.");
            }

            // setup new BackgroundWorker
            this.exportWorker = new System.ComponentModel.BackgroundWorker();
        }

        #endregion

        #region Delegates

        /// <summary>
        /// Notification when status text changed
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        public delegate void StatusChangedEventHandler(Object sender, StatusChangedEventArgs e);

        #endregion

        #region Events

        /// <summary>
        /// The event that others can connect to
        /// </summary>
        public event StatusChangedEventHandler StatusChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Get the current used background worker that does the export
        /// </summary>
        public BackgroundWorker ExportWorker
        {
            get { return this.exportWorker; }
        }

        /// <summary>
        /// Get the flag if current export was canceled by user
        /// </summary>
        public Boolean IsExportCanceled
        {
            get { return this.isExportCanceled; }
        }

        /// <summary>
        /// Get a flag if <see cref="Exporter"/> is properly initialized for doing the export
        /// </summary>
        public Boolean IsInitialized
        {
            get { return this.isInitialized; }
        }

        /// <summary>
        /// Get all <see cref="KlientExceptionPair"/> where exceptions occured while exporting address
        /// </summary>
        public List<KlientExceptionPair> KlientenMitAddressExportException
        {
            get { return klientenMitAddressExportException; }
        }

        /// <summary>
        /// Get all <see cref="KlientExceptionPair"/> where exceptions occured while exporting Konto
        /// </summary>
        public List<KlientExceptionPair> KlientenMitKontoExportException
        {
            get { return klientenMitKontoExportException; }
        }

        /// <summary>
        /// Get the clients to export
        /// </summary>
        public List<Klient> KlientenToExport
        {
            get { return this.klientenToExport; }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// This event handler is where the actual, potentially time-consuming work is done.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> parameter</param>
        private void copyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // do catch exceptions here because of separate thread
            try
            {
                // logging
                DataHandler.InsertAbaLog(null, null, null, "Exporter.copyWorker_DoWork(...)");

                // Get the BackgroundWorker that raised this event.
                // BackgroundWorker worker = sender as BackgroundWorker;

                // Assign the result of the computation to the Result property of the DoWorkEventArgs object.
                // This will be available to the RunWorkerCompleted eventhandler.

                // >> Start the export here and set result as given from export
                e.Result = new ExporterResult(this.Export(e));
            }
            catch (Exception ex)
            {
                // logging
                DataHandler.InsertAbaLog(null, null, ex, "Exporter.copyWorker_DoWork(...) caught exception");

                // show error message
                KissMsg.ShowError("Exporter", "ErrorCopyWorkerThread", "Es ist ein Fehler im Arbeiter-Thread aufgetreten, der Export wurde nicht korrekt durchgeführt.", ex);

                // set result because of error
                e.Result = new ExporterResult(KissMsg.GetMLMessage("Exporter", "ErrorCopyWorkerThreadResult", "Die gewählten Klienten wurden nicht vollständig ins Abacus übertragen."), ex);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Inits the exporter and starts the export with given parameters
        /// </summary>
        /// <param name="klientenToExport">The clients to export</param>
        /// <param name="mandantenNummer">The mandantennr to use</param>
        public void Init(List<Klient> klientenToExport, Int32 mandantenNummer)
        {
            // logging
            DataHandler.InsertAbaLog(String.Format("MandantNr='{0}'", mandantenNummer), null, null, "Exporter.Init(...)");

            // set status
            this.SetNewStatus("InitCalled", "Initialisieren des Exports...", StatusChangedEventArgs.StatusMessageEvents.GeneralExport, false);

            // check if given list ist valid
            if (klientenToExport == null)
            {
                throw new ArgumentNullException("Invalid list with clients to export, cannot continue.");
            }

            // export is not canceled by default
            this.isExportCanceled = false;

            // attach DoWork event
            exportWorker.DoWork += new DoWorkEventHandler(copyWorker_DoWork);

            // apply fields
            this.klientenToExport = klientenToExport;

            // set flag to store if Init(...) was called
            this.isInitialized = true;

            // create new connection to use for wrapper
            AbacusConnection abaConnection = new AbacusConnection(new Uri(this.KissConfig_WebServiceUri), this.AbacusUserName, this.AbacusUserPassword, mandantenNummer);

            // setup wrappers for Abacus.Address and Abacus.FibuClassification
            addressWebServiceWrapper = new AddressWrapper(abaConnection, this.KissConfig_WebServiceUriAddress, this.KissConfig_WebServiceSleepTime);
            fibuWebServiceWrapper = new FibuClassificationWrapper(abaConnection, this.KissConfig_WebServiceUriFibuClassification, this.KissConfig_WebServiceSleepTime);
        }

        /// <summary>
        /// Set that the current export has to be canceled
        /// </summary>
        public void SetExportCanceled()
        {
            this.isExportCanceled = true;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// The event calling method
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnStatusChanged(StatusChangedEventArgs e)
        {
            // only if someone is listening
            if (StatusChanged != null)
            {
                // send status changed event to listener
                this.StatusChanged(this, e);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Starts the Export of Address and Konto
        /// </summary>
        /// <param name="e">In this implementation we dont passe any information through e<see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        /// <returns>Message if export was finished with or without success</returns>
        private String Export(DoWorkEventArgs e)
        {
            // set status
            this.SetNewStatus("StartingTheExport", "Beginne mit dem Export...", StatusChangedEventArgs.StatusMessageEvents.GeneralExport, true);

            // logging
            DataHandler.InsertAbaLog(String.Format("KissConfig_DebugFlag='{1}',{0}KissConfig_WebServiceUri='{2}',{0}KissConfig_WebServiceUriAddress='{3}',{0}KissConfig_WebServiceUriFibuClassification='{4}',{0}KissConfig_WebServiceSleepTime='{5}',{0}KissConfig_CompareAddress='{6}',{0}KissConfig_CompareAccount='{7}',{0}AbacusUserName='{8}'",
                                                    Environment.NewLine,								// 0
                                                    this.KissConfig_DebugFlag,							// 1
                                                    this.KissConfig_WebServiceUri,						// 2
                                                    this.KissConfig_WebServiceUriAddress,				// 3
                                                    this.KissConfig_WebServiceUriFibuClassification,	// 4
                                                    this.KissConfig_WebServiceSleepTime,				// 5
                                                    this.KissConfig_CompareAddress,						// 6
                                                    this.KissConfig_CompareAccount,						// 7
                                                    this.AbacusUserName),								// 8
                                                    null, null, "Exporter.Export(...)");

            // set do report progress
            this.exportWorker.WorkerReportsProgress = true;

            // log all before export
            this.LogClientsToExport(false);

            // logging
            DataHandler.InsertAbaLog(null, null, null, "Exporter.Export(...) - start exporting addresses");

            // do export of adresses and get possible exceptions
            klientenMitAddressExportException = ExportAddresses();

            // logging
            DataHandler.InsertAbaLog(null, null, null, "Exporter.Export(...) - start exporting accounts");

            // do export of Konto and get possible exceptions
            klientenMitKontoExportException = ExportKonto();

            // log all after export
            this.LogClientsToExport(true);

            // check if we had any errors
            if (klientenMitAddressExportException.Count < 1 && klientenMitKontoExportException.Count < 1)
            {
                // no errors detected, successfully done
                return KissMsg.GetMLMessage("Exporter", "ExportSuccessfullyFinished", "Die gewählten Klienten wurden erfolgreich ins Abacus übertragen.");
            }
            else
            {
                // not successfully finished
                return KissMsg.GetMLMessage("Exporter", "ExportFinishedWithErrors_v02", "Error - der Export konnte leider nicht fehlerfrei durchgeführt werden.");
            }
        }

        /// <summary>
        /// Exports the adresses.
        /// </summary>
        /// <returns>A list of Klient-Exception pairs for clients that have not exported successfully</returns>
        private List<KlientExceptionPair> ExportAddresses()
        {
            // check if Init(...) was called first
            if (!this.isInitialized)
            {
                throw new KlientenStammdatenException("First call the method Init(...) before starting the export");
            }

            // check if server is responding
            if (!addressWebServiceWrapper.IsServerAlive())
            {
                throw new KlientenStammdatenException("The desired Address-WebService of Abacus does not respond, please check your connection.");
            }

            // create a new list of Klient-Exception pairs to stroe those who did not export without excpetion
            List<KlientExceptionPair> klientenMitExportFehler = new List<KlientExceptionPair>();

            try
            {
                // set status
                this.SetNewStatus("AddressLogInAbacus", "Einloggen in Abacus...", StatusChangedEventArgs.StatusMessageEvents.AddressExport, true);

                // log in to Abacus
                addressWebServiceWrapper.LogIn();

                // init vars used for progress state
                Int32 counter = 0;
                Int32 numberOfKlienten = this.klientenToExport.Count;

                // start time messuring (used for debugging)
                DateTime debug_StartTime = DateTime.Now;

                // set status
                this.SetNewStatus("StartExportingAddresses", "Starte Adressen exportieren...", StatusChangedEventArgs.StatusMessageEvents.AddressExport, true);

                // DO EXPORT OF ADDRESSES
                //Iteration über alle selektierten Klientendatensätze
                foreach (Klient klient in this.klientenToExport)
                {
                    // check if export has to be canceled
                    if (this.IsExportCanceled)
                    {
                        // do not continue
                        throw new KlientenStammdatenException("The user has canceled the current export (at exporting addresses).");
                    }

                    try
                    {
                        // validate if Klient has really the flag KontoFuehrung = true
                        if (klient.KontoFuehrung)
                        {
                            // check if Klient is a new Klient
                            if (klient.IsNewKlient)
                            {
                                // new client, generate first a new KlientenkontoNr, otherwise Klient would not be exportable to Abacus
                                this.ExportNewKlient(klient);
                            }
                            else
                            {
                                // update client with existing KlientenkontoNr
                                this.ExportExistingKlient(klient);
                            }

                            // update information on Klient (BaPerson.KlientenkontoNr, BaPerson.DebitorUpdate)
                            klient.Save();
                        }
                    }
                    catch (SoapException soapEx)
                    {
                        // current client reported an exception, store it
                        klientenMitExportFehler.Add(new KlientExceptionPair(klient, soapEx));

                        // logging
                        DataHandler.InsertAbaLog(klient.ToString(), null, soapEx, "Exporter.ExportAddress(...) caught exception with client");

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
                        // current client reported an exception, store it
                        klientenMitExportFehler.Add(new KlientExceptionPair(klient, ex));

                        // logging
                        DataHandler.InsertAbaLog(klient.ToString(), null, ex, "Exporter.ExportAddress(...) caught exception with client");
                    }

                    // first count up and then update progress-bar
                    this.ReportProgress(++counter, numberOfKlienten, TOTALAMOUNTOFWORKPARTS, WorkingPart.Step1_ExportAddress);
                } // [foreach client]

                // finished with export of Address, do show consumed time only if debug=true
                if (this.KissConfig_DebugFlag)
                {
                    // set end time and calculate time consumption
                    DateTime debug_EndTime = DateTime.Now;
                    TimeSpan debug_TimeSpan = debug_EndTime.Subtract(debug_StartTime);

                    // show message with consumed time informations (no multilanguage!)
                    DataHandler.InsertAbaLog(null, null, null, String.Format("Address: Updated '{0}' clients in '{1}' seconds", this.klientenToExport.Count, debug_TimeSpan.TotalSeconds));
                }
            }
            finally
            {
                // do logout if logged in
                if (addressWebServiceWrapper.LoggedIn)
                {
                    // set status
                    this.SetNewStatus("AddressLogOutAbacus", "Ausloggen aus Abacus...", StatusChangedEventArgs.StatusMessageEvents.AddressExport, true);

                    addressWebServiceWrapper.LogOut();
                }
            }

            // set status
            this.SetNewStatus("AddressExportFinished", "Adress-Export abgeschlossen...", StatusChangedEventArgs.StatusMessageEvents.AddressExport, true);

            // return errors
            return klientenMitExportFehler;
        }

        /// <summary>
        /// Exports an existing Klient
        /// </summary>
        /// <param name="klient">The existing Klient to export</param>
        private void ExportExistingKlient(Klient klient)
        {
            // get the address of this Klient from Abacus
            KlientenAddress abacusAdresse = addressWebServiceWrapper.GetAddressOfKlient(klient);

            // check if there is already an Address for existing KlientenkontoNr which should be the case
            if (abacusAdresse.IsEmpty)
            {
                // although we already have a defined KlientenkontoNr on the Klient, this number does not yet exists in Abacus.
                //   therefore we let the user decide what he wants to do
                if (KissMsg.ShowQuestion("Exporter", "ExportExistingKlientNumberNotFoundInAbacus_v01", "Die Debitorennummer '{1}' von '{2}, {3}' wurde nicht in Abacus gefunden.{0}{0}Wollen Sie die Adresse neu in Abacus erstellen lassen?", 0, 0, true, Environment.NewLine, klient.KlientenKonto.KlientenkontoNr, klient.Name, klient.Vorname))
                {
                    // yes case, user wants to export Klient
                    addressWebServiceWrapper.SaveAddressInAbacus(klient);
                }
                else
                {
                    // no case, user decided to cancel export, therefore throw an exception
                    throw new KlientenStammdatenException(String.Format("The existing KlientenkontoNr '{0}' for BaPersonID = '{1}' does not exist in Abacus, user canceled writing to Abacus.", klient.KlientenKonto.KlientenkontoNr, klient.BaPersonID));
                }
            }
            else
            {
                // in order to have a better performance, we have a flag if address has to be compared with Abacus-Address or not
                if (!this.KissConfig_CompareAddress || !klient.Adresse.Equals(abacusAdresse))
                {
                    // do write Address to Abacus
                    addressWebServiceWrapper.SaveAddressInAbacus(klient);
                }
            }
        }

        /// <summary>
        /// Exports the Konto that were passed in Init Method
        /// </summary>
        /// <returns>A list with all clients and exceptions that occured on export</returns>
        private List<KlientExceptionPair> ExportKonto()
        {
            // check if Init(...) was called first
            if (!this.isInitialized)
            {
                throw new KlientenStammdatenException("First call the method Init(...) before starting the export");
            }

            // check if server is responding
            if (!fibuWebServiceWrapper.IsServerAlive())
            {
                throw new KlientenStammdatenException("The desired Fibu-WebService of Abacus does not respond, please check your connection.");
            }

            // create a new list of Klient-Exception pairs to store those who did not export without excpetion
            List<KlientExceptionPair> klientenMitExportFehler = new List<KlientExceptionPair>();

            // start the export
            try
            {
                // set status
                this.SetNewStatus("AccountLogInAbacus", "Einloggen in Abacus...", StatusChangedEventArgs.StatusMessageEvents.AccountExport, true);

                //Im Webservice einloggen
                fibuWebServiceWrapper.LogIn();

                // start time messuring (used for debugging)
                DateTime debug_StartTime = DateTime.Now;

                #region Compare Accounts

                // only when flag is set
                if (this.KissConfig_CompareAccount)
                {
                    // set status
                    this.SetNewStatus("AccountReadGivenAccounts", "Vorhandene Konten für den Ablgleich von Abacus einlesen...", StatusChangedEventArgs.StatusMessageEvents.AccountExport, true);

                    // Liste erstellen mit allen Klienten die schon eine KlientenkontoNr(Kostenstelle) hatten.
                    // Nur diese müssen und können auch in Abacus gefunden werden
                    Dictionary<Int32, Konto> kontosToFind = new Dictionary<Int32, Konto>();

                    foreach (Klient klient in klientenToExport)
                    {
                        // check if export has to be canceled
                        if (this.IsExportCanceled)
                        {
                            // do not continue
                            throw new KlientenStammdatenException("The user has cancelled the current export (at setting up accounts for existing clients).");
                        }

                        // check if Klient was a new Klient (had no KlientenkontoNr before updating Address), save only Klienten with an existing KlientenkontoNr
                        if (!klient.IsNewKlient)
                        {
                            // store in dictionary where ID=KlientenkontoNr and Value=Klient.KlientenKonto
                            kontosToFind.Add(klient.KlientenKonto.KlientenkontoNr.Value, klient.KlientenKonto);
                        }
                    }

                    // read all Kontos from Abacus for selected MandantenNummer
                    this.dictOfExistingAbaKontos = fibuWebServiceWrapper.GetAllKontosOfCurrentMandant(kontosToFind);

                    // finished preparing and reading existing Abacus-Konto, do show consumed time only if debug=true
                    if (this.KissConfig_DebugFlag)
                    {
                        // set end time and calculate time consumption
                        DateTime debug_EndTime = DateTime.Now;
                        TimeSpan debug_TimeSpan = debug_EndTime.Subtract(debug_StartTime);

                        // show message with consumed time informations (no multilanguage!)
                        KissMsg.ShowInfo(String.Format("FibuClassification: Reading existing classification for '{0}' clients in '{1}' seconds, found '{2}' items", this.klientenToExport.Count, debug_TimeSpan.TotalSeconds, dictOfExistingAbaKontos.Count));
                    }
                }
                else
                {
                    // reset dictionary, no items will be added and therefore each account handled as new
                    // info: Abacus does not make a difference between insert/update account, the webservice will automatically handle this.
                    //       >> see later on the flag isNewKonto
                    this.dictOfExistingAbaKontos = new Dictionary<Int32, Konto>();
                }

                #endregion

                #region Do Export Of Accounts

                // set status
                this.SetNewStatus("AccountStartExporting", "Starte Konten exportieren...", StatusChangedEventArgs.StatusMessageEvents.AccountExport, true);

                // init vars used for progress state
                Int32 counter = 0;
                Int32 numberOfKlienten = this.klientenToExport.Count;

                // loop all clients that have to be exported
                foreach (Klient exportKlient in this.klientenToExport)
                {
                    // check if export has to be canceled
                    if (this.IsExportCanceled)
                    {
                        // do not continue
                        throw new KlientenStammdatenException("The user has canceled the current export (at exporting accounts).");
                    }

                    try
                    {
                        // check if KlientenkontoNr is in dictionary and therefore would be an existing Konto
                        Boolean isNewKonto = !dictOfExistingAbaKontos.ContainsKey(exportKlient.KlientenKonto.KlientenkontoNr.Value);

                        // save changes to abacus-account
                        this.SaveKontoToAbacus(exportKlient, isNewKonto);

                        // update information on Klient (BaPerson.KlientenkontoNr, BaPerson.DebitorUpdate)
                        exportKlient.Save();
                    }
                    catch (SoapException soapEx)
                    {
                        // exception occured on export Konto into Abacus, store information
                        klientenMitExportFehler.Add(new KlientExceptionPair(exportKlient, soapEx));

                        // logging
                        DataHandler.InsertAbaLog(exportKlient.ToString(), null, soapEx, "Exporter.ExportKonto(...) caught exception with client");

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
                        // exception occured on export Konto into Abacus, store information
                        klientenMitExportFehler.Add(new KlientExceptionPair(exportKlient, ex));

                        // logging
                        DataHandler.InsertAbaLog(exportKlient.ToString(), null, ex, "Exporter.ExportKonto(...) caught exception with client");
                    }

                    // first count up and then update progress-bar
                    this.ReportProgress(++counter, numberOfKlienten, TOTALAMOUNTOFWORKPARTS, WorkingPart.Step2_ExportAccount);
                } // [foreach client]

                #endregion

                // finished exporting clients to Abacus, do show consumed time only if debug=true
                if (this.KissConfig_DebugFlag)
                {
                    // set end time and calculate time consumption
                    DateTime debug_EndTime = DateTime.Now;
                    TimeSpan debug_TimeSpan = debug_EndTime.Subtract(debug_StartTime);
                }
            }
            finally
            {
                // do logout if logged in
                if (fibuWebServiceWrapper.LoggedIn)
                {
                    // set status
                    this.SetNewStatus("AccountLogOutAbacus", "Ausloggen aus Abacus...", StatusChangedEventArgs.StatusMessageEvents.AccountExport, true);

                    fibuWebServiceWrapper.LogOut();
                }
            }

            // set status
            this.SetNewStatus("AccountExportFinished", "Konto-Export abgeschlossen...", StatusChangedEventArgs.StatusMessageEvents.AccountExport, true);

            // return errors
            return klientenMitExportFehler;
        }

        /// <summary>
        /// Exports a new klient
        /// </summary>
        /// <param name="klient">The klient to export</param>
        private void ExportNewKlient(Klient klient)
        {
            // create and set a new KlientenkontoNr on given client
            klient.KlientenKonto.SetKlientenkontoNummer(this.GenerateNewKlientenkontoNr());

            // get address for given Klient (using KlientenkontoNr as ID)
            KlientenAddress abacusAdresse = addressWebServiceWrapper.GetAddressOfKlient(klient);

            // check if there is already an Address for new created KlientenkontoNr which would be a an evil exception
            if (abacusAdresse.IsEmpty)
            {
                // address does not yet exist, save address with new KlientenkontoNr
                addressWebServiceWrapper.SaveAddressInAbacus(klient);
            }
            else
            {
                // show error message
                KissMsg.ShowError("Exporter", "ExportNewKlientKlientenkontoNrAlreadyInAbacus_v01", "Es ist ein schwerer Ausnahmefehler aufgetreten.{0}{0}In Abacus ist die KlientenkontoNr '{1}' bereits vorhanden, welche neu in KiSS generiert wurde.{0}{0}Bitte melden Sie diesen Fehler beim Administrator!", "Die von KiSS generierte KlientenkontoNr ist in Abacus schon vorhanden", null, 0, 0, Environment.NewLine, klient.KlientenKonto.KlientenkontoNr);

                // throw exception because this Klient is not valid to export
                throw new KlientenStammdatenException(String.Format("New created KlientenkontoNr '{0}' does already exist in Abacus.", klient.KlientenKonto.KlientenkontoNr));
            }
        }

        /// <summary>
        /// Generates a new unique KlientenkontoNr used as AbacusID
        /// </summary>
        /// <returns>The new generated unique KlientenkontoNr</returns>
        private Int32 GenerateNewKlientenkontoNr()
        {
            // generate and return a new unique KlientenkontoNr
            return Convert.ToInt32(DB.DBUtil.ExecuteScalarSQL("EXEC dbo.spGetUniqueKey 'DebiID'"));
        }

        /// <summary>
        /// Log given clients to database as input parameters because of security reasons
        /// </summary>
        private void LogClientsToExport(Boolean exportFinished)
        {
            // validate
            if (this.klientenToExport == null)
            {
                throw new NullReferenceException("Cannot log clients to export without having any clients.");
            }

            // init vars
            String loggingParamIn = "";

            // loop clients and append string-value to var
            foreach (Klient klient in this.klientenToExport)
            {
                loggingParamIn = String.Format("{0}[{1}];{2}{2}", loggingParamIn, klient.ToString(), Environment.NewLine);
            }

            // write output to database
            DataHandler.InsertAbaLog(loggingParamIn, null, null, String.Format("Exporter.LogClientsToExport - data of all '{0}' clients {1} export.", this.klientenToExport.Count, exportFinished ? "after" : "before"));
        }

        /// <summary>
        /// Report the progress to connected objects
        /// </summary>
        /// <param name="counter">The current counter</param>
        /// <param name="totalAmount">The total amount</param>
        /// <param name="amountOfWorkParts">The amount of total work-parts who have to be reported</param>
        /// <param name="currentWorkingPart">The current working part who is currently reporting an update of the progress</param>
        private void ReportProgress(Int32 counter, Int32 totalAmount, Int32 amountOfWorkParts, WorkingPart currentWorkingPart)
        {
            // validate parameters
            if (counter < 0)
            {
                throw new ArgumentOutOfRangeException("counter", "Counter cannot be negative, progress cannot be updated.");
            }
            if (totalAmount < 0)
            {
                throw new ArgumentOutOfRangeException("totalAmount", "TotalAmount cannot be negative, progress cannot be updated.");
            }
            if (counter > totalAmount)
            {
                throw new ArgumentOutOfRangeException("counter", "Counter cannot be bigger than the totalAmount, progress cannot be updated.");
            }
            if (amountOfWorkParts < 0)
            {
                throw new ArgumentOutOfRangeException("amountOfWorkParts", "AmountOfWorkParts cannot be negative, progress cannot be updated.");
            }
            if (this.exportWorker == null)
            {
                throw new NullReferenceException("The ExportWorker is empty, progress cannot be updated.");
            }

            // calculate total parts to percentage (e.g. two parts >> each part is 50%)
            Int32 partialPercentageOfSingePart = Convert.ToInt32((100.0 / Convert.ToDouble(amountOfWorkParts)));

            // add the current step-1 to progress (to have all steps make 100%)
            Int32 addPercentage = (Convert.ToInt32(currentWorkingPart) - 1) * partialPercentageOfSingePart;

            // update progress-bar
            this.exportWorker.ReportProgress(addPercentage + Convert.ToInt32((Convert.ToDouble(counter) / Convert.ToDouble(totalAmount)) * partialPercentageOfSingePart), currentWorkingPart);
        }

        /// <summary>
        /// Saves a new Konto in Abacus
        /// </summary>
        /// <param name="klient">The Klient to save Konto</param>
        private void SaveKontoToAbacus(Klient klient, Boolean isNewKonto)
        {
            // if existing account, we do compare if config is set
            if (!isNewKonto && this.KissConfig_CompareAccount)
            {
                // compare data of Konto with found data in Abacus (stored in dictionary) and save only if different
                if (!klient.KlientenKonto.Equals(this.dictOfExistingAbaKontos[klient.KlientenKonto.KlientenkontoNr.Value]))
                {
                    // save (existing) Konto-data in Abacus
                    fibuWebServiceWrapper.SaveKontoInAbacus(klient, isNewKonto);
                }
            }
            else
            {
                // save new/existing Konto-data in Abacus
                fibuWebServiceWrapper.SaveKontoInAbacus(klient, isNewKonto);
            }
        }

        /// <summary>
        /// Set new status to connected event watchers of StatusChanged event
        /// </summary>
        /// <param name="messageName">The message name to use for multilanguage message (MessageName)</param>
        /// <param name="defaultMessageText">The default message if none defined yet by translation (DefaultMessage)</param>
        /// <param name="statusMessageEvent">The event where the new status occured</param>
        /// <param name="isFromAsyncCall">Flag if the event is called from other thread than UI thread</param>
        private void SetNewStatus(String messageName, String defaultMessageText, StatusChangedEventArgs.StatusMessageEvents statusMessageEvent, Boolean isFromAsyncCall)
        {
            // validate parameters
            if (messageName == null)
            {
                throw new ArgumentNullException("messageName", "The name of the message for the new status cannot be empty.");
            }
            if (defaultMessageText == null)
            {
                throw new ArgumentNullException("defaultMessageText", "The message used for the new status cannot be empty.");
            }

            // create multilanguage message as StatusChangedEventArgs and send to event-handler
            this.OnStatusChanged(new StatusChangedEventArgs(KissMsg.GetMLMessage("Exporter", messageName, defaultMessageText), statusMessageEvent, isFromAsyncCall));
        }

        #endregion

        #endregion
    }
}