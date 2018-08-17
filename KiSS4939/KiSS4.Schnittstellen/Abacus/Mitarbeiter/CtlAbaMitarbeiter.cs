using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;
using KiSS4.Schnittstellen.Abacus.KlientenStammdaten;
using log4net;

namespace KiSS4.Schnittstellen.Abacus.Mitarbeiter
{
    public partial class CtlAbaMitarbeiter : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        private static readonly ILog _logger = LogManager.GetLogger(typeof(CtlAbaMitarbeiter));

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Set MaskName used for multilanguage handling
        /// </summary>
        private const String MASK_NAME = "CtlAbaMitarbeiter";

        private const string SQL_GESCHAEFTSBEREICH = @"
            SELECT [Code] = ORG.Mandantennummer,
                   [Text] = CONVERT(VARCHAR(10), ISNULL(ORG.Mandantennummer, -1)) + '   ' + ORG.ItemName
            FROM dbo.XOrgUnit ORG WITH(READUNCOMMITTED)
            WHERE ORG.Mandantennummer IS NOT NULL
              AND (1 = {0} OR ORG.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr({1})) -- only special can select all
            ORDER BY [Code], [Text];";

        private const String STATUSUPDATEDIFF = "UPDATE different";
        private readonly KAConRead _kcr = new KAConRead();
        private readonly KAConWrite _kcw = new KAConWrite();

        #endregion

        #region Private Fields

        private bool _cancel;
        private bool _checkAll;
        private IDictionary<int, MitarbeiterDTO> _mitarbeiterAbakus;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public CtlAbaMitarbeiter()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void SetupColumn(GridColumn gridColumn, bool editable)
        {
            var backColor = editable ? GuiConfig.GridEditable : GuiConfig.GridReadOnly;

            gridColumn.AppearanceCell.BackColor = backColor;
            gridColumn.AppearanceCell.Options.UseBackColor = true;

            gridColumn.OptionsColumn.AllowEdit = editable;
            gridColumn.OptionsColumn.AllowFocus = editable;
            gridColumn.OptionsColumn.ReadOnly = !editable;
        }

        private void SetupGrid()
        {
            SetupColumn(colDoImport, true);
            SetupColumn(colMitarbeiterNr, false);
            SetupColumn(colName, false);
            SetupColumn(colVorname, false);
            SetupColumn(colGeburtstag, false);
            SetupColumn(colAbteilung, false);
            SetupColumn(colLohnTyp, false);
            SetupColumn(colAustritt, false);
            SetupColumn(colStatus, false);
        }

        #endregion

        #region EventHandlers

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            InsertAbaLog(Session.User.UserID, 0, null, null, null, "Button Uncheck clicked");
            var mandantenNr = Utils.ConvertToInt(edtGeschaeftsbereich.EditValue);
            _checkAll = false;
            LoadData(mandantenNr, false, false);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            InsertAbaLog(Session.User.UserID, 0, null, null, null, "Button Check clicked");
            var mandantenNr = Utils.ConvertToInt(edtGeschaeftsbereich.EditValue);
            _checkAll = true;
            LoadData(mandantenNr, true, false);
        }

        private void btnSynchro_Click(Object sender, EventArgs e)
        {
            DlgProgressLog.Show(
                KissMsg.GetMLMessage(
                    MASK_NAME,
                    "SynchronisierenTitel",
                    "Fortschritt: Daten synchronisieren"),
                true,
                false,
                500,
                300,
                DatenSynchronisierenStart,
                DatenSynchronisierenClose,
                Session.MainForm);
        }

        private void CtlAbaMitarbeiter_Load(Object sender, EventArgs e)
        {
            try
            {
                // fill default month/year
                edtMonth.EditValue = DateTime.Now.Month;
                edtYear.EditValue = DateTime.Now.Year;

                // depending on rights, the user can see just his mandant or all
                bool userCanSeeAllMandanten = Session.User.IsUserAdmin || DBUtil.UserHasRight("ABAMASchnittstelleGB");

                // all mandanten the user can see
                var sql = SQL_GESCHAEFTSBEREICH;

                // add null entry
                if (userCanSeeAllMandanten)
                {
                    sql = @"SELECT [Code] = NULL,
                                   [Text] = NULL

                            UNION ALL " + sql;
                }

                var qryMandanten = DBUtil.OpenSQL(sql, userCanSeeAllMandanten, Session.User.UserID);

                // setup edtGeschaeftsbereich
                edtGeschaeftsbereich.EditMode = userCanSeeAllMandanten ? EditModeType.Normal : EditModeType.ReadOnly;
                edtGeschaeftsbereich.Properties.DropDownRows = Math.Min(qryMandanten.Count, 14);
                edtGeschaeftsbereich.Properties.DataSource = qryMandanten;

                // setup default values
                edtGeschaeftsbereich.EditValue = DBUtil.ExecuteScalarSQL(@"SELECT dbo.fnOrgUnitOfUserMandantenNr({0})", Session.User.UserID);

                // check if any selected
                if (DBUtil.IsEmpty(edtGeschaeftsbereich.EditValue) || Convert.ToInt32(edtGeschaeftsbereich.EditValue) < 1)
                {
                    // select first possible item
                    edtGeschaeftsbereich.EditValue = qryMandanten.DataTable.Rows[0]["Code"];
                }
            }
            catch (Exception ex)
            {
                // log message
                InsertAbaLog(Session.User.UserID, 0, null, null, ex.Message, "Error occured while loading control.");
                _logger.Error("Error occured while loading control.", ex);

                // show error
                KissMsg.ShowError(MASK_NAME, "LoadingEventError", "Es ist ein Fehler beim Laden der Maske aufgetreten.",
                                  "Error executing Load(...) event.", ex, 500, 300, Session.User.UserID);
            }
        }

        private void edtGeschaeftsbereich_EditValueChanged(object sender, EventArgs e)
        {
            var mandantenNr = Utils.ConvertToInt(edtGeschaeftsbereich.EditValue);
            LoadData(mandantenNr, _checkAll, false);
        }

        private void qryXUser_BeforePost(Object sender, EventArgs e)
        {
            qryXUser.RowModified = false;
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Vergleicht die KissDaten mit den Abakusdaten und eruiert, ob ein Datensatz im Kiss aktualisiert
        /// werden muss (setzt Status CHANGED, UNCHANGED, NEW u.s.w.)
        /// Die neuen Mitarbeiter, welche im Kiss noch nicht vorhanden sind, werden ebenfalls eruiert.
        /// </summary>
        /// <returns></returns>
        private void DatenAbakusUndKissVergleichen(int mandantenNr)
        {
            InsertAbaLog(Session.User.UserID, 0, null, null, null, "DatenAbakusUndKissVergleichen");

            // vars
            Int32 paramYear = DateTime.Now.Year;
            Int32 paramMonth = DateTime.Now.Month;

            // validate
            if (edtYear.Value > 0)
            {
                paramYear = Convert.ToInt32(edtYear.Value);
            }
            else
            {
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(MASK_NAME,
                        "MASchnittstelleJahrUngultig_v01",
                        "Das gewählte Jahr ist ungültig, es wird das aktuelle Jahr verwendet."));
            }

            if (edtMonth.Value > 0 && edtMonth.Value < 13)
            {
                paramMonth = Convert.ToInt32(edtMonth.Value);
            }
            else
            {
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(MASK_NAME,
                        "MASchnittstelleMonatUngultig_v01",
                        "Der gewählte Monat ist ungültig, es wird der aktuelle Monat verwendet."));
            }

            // init and prepare Abacus-call-variables
            String paramIn = "";
            paramIn += " User: " + edtUser.Text;
            paramIn += " Mandant: " + mandantenNr;
            paramIn += " User: " + edtUser.Text;
            paramIn += " year: " + paramYear;
            paramIn += " month: " + paramMonth;
            paramIn += " gb: " + mandantenNr;

            InsertAbaLog(Session.User.UserID, 0, paramIn, null, null, "Abacus Mitarbeiter call");

            try
            {
                DlgProgressLog.AddLine(
                    KissMsg.GetMLMessage(MASK_NAME,
                        "MASchnittstelleLadeDatenVonAbacus",
                        "Daten werden von Abacus angefordert."));

                _mitarbeiterAbakus = GetMitarbeiterDTOs(edtUser.Text, edtPassword.Text, paramYear, paramMonth, mandantenNr);

                DlgProgressLog.AddLine(
                    KissMsg.GetMLMessage(MASK_NAME,
                        "MASchnittstelleDatenVonAbacusGeladen",
                        "Daten von Abacus empfangen."));

                // check if we found any data
                if (_mitarbeiterAbakus == null || _mitarbeiterAbakus.Count == 0)
                {
                    throw new NullReferenceException(String.Format("No employee found for given division number '{0}'.", mandantenNr));
                }

                String paramOut = _kcr.LogResultList(_mitarbeiterAbakus.Values);

                InsertAbaLog(Session.User.UserID, 0, null, paramOut, null, "return from Abacus Mitarbeiter call");
            }
            catch (SoapException soapEx)
            {
                if (soapEx.Detail != null)
                {
                    var detail = soapEx.Detail;
                    string soapMessage = detail.InnerText;

                    throw new KlientenStammdatenException(
                        string.Format("Login Failed. Error: {0}", soapMessage));
                }

                String errTxt = soapEx.Message;

                _logger.Error(String.Format("Error getting employees of division number '{0}'.", mandantenNr), soapEx);

                InsertAbaLog(Session.User.UserID, 0, null, null, errTxt,
                             String.Format("Error reading employees from division number '{0}'.", mandantenNr));

                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(MASK_NAME,
                        "MASyncrhoError_v02",
                        "Die Mitarbeiter des Geschäftsbereiches '{0}' konnten nicht aus Abacus ausgelesen werden. ({1})",
                        mandantenNr,
                        soapEx.Message));
            }
            catch (Exception ex)
            {
                String errTxt = ex.Message;

                _logger.Error(String.Format("Error getting employees of division number '{0}'.", mandantenNr), ex);

                InsertAbaLog(Session.User.UserID, 0, null, null, errTxt,
                             String.Format("Error reading employees from division number '{0}'.", mandantenNr));

                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(MASK_NAME,
                        "MASyncrhoError_v02",
                        "Die Mitarbeiter des Geschäftsbereiches '{0}' konnten nicht aus Abacus ausgelesen werden. ({1})",
                        mandantenNr,
                        ex.Message));
            }

            DlgProgressLog.AddLine(
                KissMsg.GetMLMessage(MASK_NAME,
                    "MASchnittstelleDatenVergleichStart",
                    "Starte Datenvergleich."));

            // check if we have a valid data.
            if (_mitarbeiterAbakus != null && _mitarbeiterAbakus.Count != 0)
            {
                _kcr.SetAbaDataSet(_mitarbeiterAbakus);
                _kcw.SetAbaDataSet(_mitarbeiterAbakus);

                qryXUser.First();
                _kcr.ResetUpdatedMitarbeiterList();

                while (qryXUser.Count > 0)
                {
                    // let messages flow
                    ApplicationFacade.DoEvents();

                    // check if canceled
                    if (_cancel)
                    {
                        break;
                    }

                    if (!DBUtil.IsEmpty(qryXUser["DoImport"]) && Convert.ToBoolean(qryXUser["DoImport"]))
                    {
                        // check if mitarbeiter is changed
                        if (!DBUtil.IsEmpty(qryXUser["MitarbeiterNr"]))
                        {
                            String manr = Convert.ToString(qryXUser["MitarbeiterNr"]);
                            Int32 dmanr = Convert.ToInt32(manr);

                            try
                            {
                                KAConRead.CoWorkerStatus cws = _kcr.CompareWorker(dmanr);

                                if (cws == KAConRead.CoWorkerStatus.CHANGED)
                                {
                                    // APPLY STATUS "UPDATE different:..." TO USER TO DO UPDATE IN btnRun_Click()...
                                    qryXUser["Status"] = String.Format("{0}: {1}", STATUSUPDATEDIFF, _kcr.GetStatus());

                                    // log
                                    _logger.Debug(String.Format("Compared user with MANr='{0}' as different in: <{1}>", manr, _kcr.GetStatus()));

                                    DlgProgressLog.AddLine(KissMsg.GetMLMessage(MASK_NAME,
                                            "MASchnittstelleUserDifferent",
                                            "MANr '{0}': unterschiedlich in {1}.", manr, _kcr.GetStatus()));

                                    InsertAbaLog(Session.User.UserID, 0, String.Format("MANr='{0}'", manr),
                                                 String.Format(
                                                     "Compared user with MANr='{0}' as different in: <{1}>", manr,
                                                     _kcr.GetStatus()), null, null);
                                }
                                else if (cws == KAConRead.CoWorkerStatus.UNCHANGED)
                                {
                                    // user did not change
                                    qryXUser["Status"] = "UNCHANGED";

                                    DlgProgressLog.AddLine(string.Format("MANr '{0}' UNCHANGED", manr));

                                    // log
                                    InsertAbaLog(Session.User.UserID, 0, String.Format("MANr='{0}'", manr),
                                                 "User has not changed, no differences detected.", null, null);
                                }
                                else if (cws == KAConRead.CoWorkerStatus.DOES_NOT_EXIST_ANYMORE)
                                {
                                    // does not exist anymore
                                    qryXUser["Status"] = "ERROR! Mitarbeiter '" + manr + "' not gotten from abacus!";

                                    // log
                                    _logger.Error("Worker  '" + manr +
                                                 "' not gotten from abacus with THE sql statement.");
                                    InsertAbaLog(Session.User.UserID, 0, String.Format("MANr='{0}'", manr),
                                                 "User does not exist anymore within Abacus!", null, null);

                                    DlgProgressLog.AddError(
                                        KissMsg.GetMLMessage(MASK_NAME,
                                            "MASchnittstelleUserDoesNotExistAnymoreInAbacus_V2",
                                            "MANr '{0}': existiert nicht mehr in Abacus.", manr));
                                }
                            }
                            catch (SoapException soapEx)
                            {
                                // error
                                qryXUser["Status"] = "ERROR! Mitarbeiter '" + manr + "' -> '" + soapEx.Message + "'";

                                // log
                                _logger.Error("error comparing worker mitarbeiter " + manr, soapEx);
                                InsertAbaLog(Session.User.UserID, 0, null, null, soapEx.Message, "error comparing worker mitarbeiter " + manr);

                                DlgProgressLog.AddError(
                                    KissMsg.GetMLMessage(MASK_NAME,
                                        "MASchnittstelleAllgemeinerFehlerVergleich_V2",
                                        "MANr '{0}': Unbekannter Fehler beim Vergleich mit Abacus: {1}", manr, soapEx.Message));

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
                                // error
                                qryXUser["Status"] = "ERROR! Mitarbeiter '" + manr + "' -> '" + ex.Message + "'";

                                // log
                                _logger.Error("error comparing worker mitarbeiter " + manr, ex);
                                InsertAbaLog(Session.User.UserID, 0, null, null, ex.Message, "error comparing worker mitarbeiter " + manr);

                                DlgProgressLog.AddError(
                                    KissMsg.GetMLMessage(MASK_NAME,
                                        "MASchnittstelleAllgemeinerFehlerVergleich_V2",
                                        "MANr '{0}': Unbekannter Fehler beim Vergleich mit Abacus: {1}", manr, ex.Message));
                            }
                        }
                        else
                        {
                            // new user
                            qryXUser["Status"] = "NEW";

                            // log
                            InsertAbaLog(Session.User.UserID, 0, Convert.ToString(qryXUser["MitarbeiterNr"]), "User is new in KiSS.", null, null);
                        }
                    }
                    else if (!DBUtil.IsEmpty(qryXUser["MitarbeiterNr"]))
                    {
                        //treatment of those who where not marked by the synchronisation process, ore thowe who has the 'import' flag not set,
                        //because we don't want to import the MitarbeiterNumbers which are already in the XUser Table
                        _kcr.InsertUpdatedMaIfExistingInAbacus(_mitarbeiterAbakus, Convert.ToInt32(qryXUser["MitarbeiterNr"]));
                    }

                    // stop while
                    if (!qryXUser.Next())
                    {
                        break;
                    }
                }

                //CHECK IF THERE ARE INSERTS OF NEW COWORKERS
                int amountNewCoworkers = _kcr.GetAmountNewMa();
                IList<int> allNew = _kcr.GetListOfNonUpdatedMa();

                if (amountNewCoworkers < allNew.Count)
                {
                    // log
                    InsertAbaLog(Session.User.UserID,
                        0,
                        "Es gibt einen Mitarbeiter, der mit der gleichen Mitarbeiternummer zweimal erscheint",
                        null,
                        null,
                        null);
                    _logger.Error("Es gibt einen Mitarbeiter, der mit der gleichen Mitarbeiternummer zweimal erscheint");

                    DlgProgressLog.AddError(
                        KissMsg.GetMLMessage(MASK_NAME,
                            "ErrorSynchroMa_v02",
                            "Bitte KiSS Daten für diesen Geschäftsbereich kontrollieren. Es gibt mindestens einen Mitarbeiternummer, der zweimal erscheint."));
                }

                if (allNew.Count < 1)
                {
                    InsertAbaLog(Session.User.UserID, 0, null, null, null, "Es gibt keine neuen Mitarbeiter zum Importieren");

                    DlgProgressLog.AddLine(
                        KissMsg.GetMLMessage(MASK_NAME, "InfoKeineMaZumImportieren_v02", "Es gibt keine neuen Mitarbeiter in Abacus zum Importieren."));
                }
                else
                {
                    String newMaList = "";

                    if (allNew.Count > 0)
                    {
                        //error list:
                        Int32 i = 0;

                        while (i < allNew.Count)
                        {
                            newMaList += String.Format(" {0} ", Convert.ToInt32(allNew[i]));
                            i++;
                        }
                    }

                    InsertAbaLog(Session.User.UserID, 0, null, null, null,
                                 String.Format("Es gibt '{0}' neue Mitarbeiter zum Importieren: {1}",
                                               amountNewCoworkers, newMaList));

                    DlgProgressLog.AddLine(KissMsg.GetMLMessage(MASK_NAME,
                        "InfoNeueMitarbeiterZumImportieren",
                        "Es gibt '{0}' neue Mitarbeiter zum Importieren: {1}", amountNewCoworkers, newMaList));
                }
            }

            DlgProgressLog.AddLine(
                KissMsg.GetMLMessage(MASK_NAME,
                    "MASchnittstelleDatenVergleichEnde",
                    "Datenvergleich abgeschlossen."));
        }

        private void DatenSynchronisierenClose()
        {
        }

        private void DatenSynchronisierenStart()
        {
            _cancel = false;

            if (!DBUtil.IsEmpty(edtGeschaeftsbereich.EditValue))
            {
                var mandantenNr = Utils.ConvertToInt(edtGeschaeftsbereich.EditValue);
                MandantSynchronisieren(mandantenNr, true);
            }
            else
            {
                var qryMandanten = DBUtil.OpenSQL(SQL_GESCHAEFTSBEREICH, true, Session.User.UserID);

                while (qryMandanten.Next())
                {
                    if (_cancel)
                    {
                        break;
                    }

                    var mandantenNr = Utils.ConvertToInt(qryMandanten["Code"]);

                    LoadData(mandantenNr, true, true);

                    MandantSynchronisieren(mandantenNr, false);
                }
            }

            DlgProgressLog.EndProgress();
        }

        /// <summary>
        /// Importiert die Daten vom Abakus in die Kiss Datenbank.
        /// Bestehende User werden aktualisiert, neue User werden erstellt.
        /// </summary>
        private void DatenVomAbakusInsKissImportieren(bool askQuestions)
        {
            InsertAbaLog(Session.User.UserID, 0, null, null, null, "Event: btnRun_Click");

            DlgProgressLog.AddLine(
                KissMsg.GetMLMessage(MASK_NAME,
                    "MASchnittstelleDatenUpdateStart",
                    "Starte Datenaktualisierung."));

            //DO THE UPDATES
            qryXUser.First();
            _kcw.ResetUpdatedMitarbeiterList();

            while (qryXUser.Count > 0)
            {
                // let messages flow
                ApplicationFacade.DoEvents();

                // check if canceled
                if (_cancel)
                {
                    break;
                }

                // HERE WE CHECK IF WE NEED TO UPDATE THIS USER (DoImport and qryXUser["Status"] LIKE 'STATUSUPDATEDIFF%')
                if (!DBUtil.IsEmpty(qryXUser["DoImport"]) &&
                    Convert.ToBoolean(qryXUser["DoImport"]) &&
                    !DBUtil.IsEmpty(qryXUser["Status"]) &&
                    Convert.ToString(qryXUser["Status"]).StartsWith(STATUSUPDATEDIFF))
                {
                    if (!DBUtil.IsEmpty(qryXUser["MitarbeiterNr"]))
                    {
                        String maNr = Convert.ToString(qryXUser["MitarbeiterNr"]);
                        Int32 dmaNr = Convert.ToInt32(maNr);
                        Int32 dUserID = Convert.ToInt32(qryXUser["UserID"]);

                        try
                        {
                            _kcw.Update(_mitarbeiterAbakus, dUserID, dmaNr);
                            qryXUser["Status"] = "UPDATE OK";
                            InsertAbaLog(Session.User.UserID, 0, "MitarbeiterNr: " + maNr, null, null,
                                         "XUser + " + maNr + "UPDATE OK");
                            DlgProgressLog.AddLine(string.Format("MANr '{0}': UPDATE OK", maNr));
                        }
                        catch (Exception exc)
                        {
                            String ertxt = "Error während update von mitarbeiter '" + dmaNr + "'. Exception msg: " + exc.Message;
                            _logger.Error(exc);
                            qryXUser["Status"] = ertxt;
                            InsertAbaLog(Session.User.UserID, 0, "MitarbeiterNr: " + maNr, null, exc.Message, "XUser + " + maNr + "UPDATE NOT OK");
                            DlgProgressLog.AddError(
                                KissMsg.GetMLMessage(MASK_NAME,
                                    "MASchnittstelleFehlerBeimSynchronisieren_V2",
                                    "MANr '{0}': Fehler beim Synchronisieren: {1}", maNr, exc.Message));
                        }
                    }
                    else
                    {
                        String erTxt = "Error: Mitarbeiter mit UserID '" + Convert.ToInt32(qryXUser["UserID"]) +
                                       "' kann nicht synchronisiert werden mit ABACUS Mitarbeiter weil er keine MitarbeiterNr hat";
                        _logger.Error(erTxt);
                        qryXUser["Status"] = erTxt;
                        InsertAbaLog(Session.User.UserID, 0, null, null, null, erTxt);
                        DlgProgressLog.AddError(
                            KissMsg.GetMLMessage(MASK_NAME,
                                "MASchnittstelleMitarbeiterHatKeineMitarbeiterNrZugewiesen",
                                "Der Mitarbeiter mit UserID '{0}' kann nicht synchronisiert werden, da er keine Mitarbeiter Nr. zugewiesen hat.",
                                Convert.ToInt32(qryXUser["UserID"])));
                    }
                }
                else if (!DBUtil.IsEmpty(qryXUser["MitarbeiterNr"]))
                {
                    //treatment of those who where not marked by the synchronisation process, ore thowe who has the 'import' flag not set,
                    //because we don't want to import the MitarbeiterNumbers which are already in the XUser Table
                    _kcw.InsertUpdatedMaIfExistingInAbacus(_mitarbeiterAbakus, Convert.ToInt32(qryXUser["MitarbeiterNr"]));
                }

                // stop while
                if (!qryXUser.Next())
                {
                    break;
                }
            }

            // DO THE INSERTS OF THE NEW COWORKERS
            Int32 amountNewCoworkers = _kcw.GetAmountNewMa();
            IList<int> alNew = _kcw.GetListOfNonUpdatedMa();

            if (amountNewCoworkers < alNew.Count)
            {
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(MASK_NAME,
                        "ErrorImportMa_v01",
                        "Bitte KiSS-Daten für diesen Geschäftsbereich kontrollieren. Es gibt mindestens eine Mitarbeiternummer, welche zweimal erscheint."));

                _logger.Error(
                    "Es gibt mindestens einen Mitarbeiter, der zweimal mit der gleichen Mitarbeiternummer erscheint.");
            }

            //gibt es neue MAs?
            if (alNew.Count > 0)
            {
                string question = alNew.Count == 1
                                      ? KissMsg.GetMLMessage(MASK_NAME,
                                          "FragenObMarbeiterImportiertWerdenSollEinzahl",
                                          "Soll der neue Mitarbeiter importiert werden?")
                                      : KissMsg.GetMLMessage(MASK_NAME,
                                          "FragenObMarbeiterImportiertWerdenSollMehrzahl",
                                          "Sollen die {0} neuen Mitarbeiter importiert werden?",
                                          alNew.Count);

                if (!askQuestions || KissMsg.ShowQuestion(question, true))
                {
                    var error = false;

                    foreach (var newMaNr in alNew)
                    {
                        try
                        {
                            _kcw.Insert(_mitarbeiterAbakus, newMaNr, Convert.ToInt32(edtYear.Value), Convert.ToInt32(edtMonth.Value));
                        }
                        catch (Exception ezz)
                        {
                            error = true;

                            InsertAbaLog(Session.User.UserID,
                                0,
                                null,
                                null,
                                ezz.Message,
                                "Import von Mitarbeiter mit Nr. '" + newMaNr + "' fehlgeschlagen.");

                            DlgProgressLog.AddError(KissMsg.GetMLMessage(MASK_NAME,
                                "MASchnittstelleImportFailed",
                                "MANr '{0}': Import fehlgeschlagen ({1})",
                                newMaNr,
                                ezz.Message));
                        }
                    }

                    if (!error)
                    {
                        DlgProgressLog.AddLine(
                            KissMsg.GetMLMessage(MASK_NAME,
                                "AllCoWorkersInserted_V2",
                                "Alle neuen Mitarbeiter konnten eingefügt werden."));
                    }
                }
            }

            DlgProgressLog.AddLine(
                KissMsg.GetMLMessage(MASK_NAME,
                    "MASchnittstelleDatenUpdateEnde",
                    "Datenaktualisierung abgeschlossen."));
        }

        /// <summary>
        /// Holt die Informationen über die Mitarbeiter beim ABAKUS
        /// über die Mitarbeiter-Schnittstelle. Es werden alle Informationen über alle User
        /// eines Geschäftsbereichs geholt, ohne die nicht selektierten, d.h.:
        /// - Die User, welche noch nicht im Kiss sind.
        /// - Die selektierten User.
        /// - Explizit ausgeblendet werden die User, welche nicht selektiert sind.
        /// </summary>
        private IDictionary<int, MitarbeiterDTO> GetMitarbeiterDTOs(string username, string password, int year,
            int month, int geschaeftsbereich)
        {
            IList<int> selektierteMitarbeiter = new List<int>();
            IList<int> nichtSelektiereteMitarbeiter = new List<int>();

            foreach (DataRow xUserRow in qryXUser.DataTable.Rows)
            {
                int userId = Convert.ToInt32(xUserRow["UserID"]);
                if (!DBUtil.IsEmpty(xUserRow["DoImport"]) && Convert.ToBoolean(xUserRow["DoImport"]))
                {
                    selektierteMitarbeiter.Add(userId);
                }
                else
                {
                    nichtSelektiereteMitarbeiter.Add(userId);
                }
            }

            var adapter = new MitarbeiterServiceAdapter();
            //var adapter = new MitarbeiterServiceAdapterMock(); // "Last-Test" mittels Mock-Implementation:
            IList<MitarbeiterDTO> mitarbeiter = adapter.GetMitarbeiterDaten(username,
                                                                            password,
                                                                            year, month, selektierteMitarbeiter,
                                                                            nichtSelektiereteMitarbeiter,
                                                                            geschaeftsbereich);

            IDictionary<int, MitarbeiterDTO> result = new Dictionary<int, MitarbeiterDTO>();
            foreach (MitarbeiterDTO ma in mitarbeiter)
            {
                //Wir sind kulant, Mitarbeiter dürfen doppelt vorkommen (Doppelte Mitarbeiternummer).
                //wir nehmen einfach den ersten Treffer.
                if (!result.ContainsKey((int)ma.MitarbeiterNummer))
                {
                    result.Add((int)ma.MitarbeiterNummer, ma);
                }
            }

            return result;
        }

        /// <summary>
        /// Macht einen Eintrag in die Tabelle XAbaLog.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="schnittstellenCode"></param>
        /// <param name="paramIn"></param>
        /// <param name="paramOut"></param>
        /// <param name="exceptionTxt"></param>
        /// <param name="remark"></param>
        private void InsertAbaLog(int userID, int schnittstellenCode, string paramIn, string paramOut, string exceptionTxt, string remark)
        {
            try
            {
                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO dbo.XAbaLog (UserID, LogDate, SchnittstellenCode, ParameterIn, ParameterOut, ExceptionMsg, Remark)
                    VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6});",
                    userID, DateTime.Now, schnittstellenCode, paramIn, paramOut, exceptionTxt, remark);
            }
            catch (Exception ex)
            {
                _logger.Error("Error writing log in XAbaLog", ex);
                DlgProgressLog.AddError(
                    KissMsg.GetMLMessage(MASK_NAME,
                        "FailedLoggingToDB_v01",
                        "Es ist ein Fehler beim Logging in die Datenbank aufgetreten. ({0})",
                        ex));
            }
        }

        private void LoadData(int mandantenNr, bool setChecked, bool suppressDialogs)
        {
            InsertAbaLog(Session.User.UserID, 0, null, null, null, "loadData(" + setChecked + ") called.");

            if (_kcr != null)
            {
                _kcr.ResetUpdatedMitarbeiterList();
                if (_kcr.GetAbaDataSet() != null)
                {
                    _kcr.GetAbaDataSet().Clear();
                }
            }

            if (_kcw != null)
            {
                _kcw.ResetUpdatedMitarbeiterList();
                if (_kcw.GetAbaDataSet() != null)
                {
                    _kcw.GetAbaDataSet().Clear();
                }
            }

            // if the value is not set, clear the data
            if (mandantenNr < 1)
            {
                qryXUser.Fill("SELECT TOP 0 NULL;");
                return;
            }

            try
            {
                Int32 dMandantanNummer = mandantenNr;

                // get data from db
                qryXUser.Fill(@"
                    SELECT DoImport = CONVERT(BIT, {3}),
                           Status = CONVERT(TEXT, NULL),
                           USR.UserID,
                           USR.MitarbeiterNr,
                           USR.Lastname,
                           USR.Firstname,
                           USR.Geburtstag,
                           USR.Austrittsdatum,
                           Lohntyp = dbo.fnGetLOVMLText('BenutzerLohnTyp', USR.LohnTypCode, {1}),
                           Abteilung = ORG.ItemName
                    FROM dbo.XUser USR WITH (READUNCOMMITTED)
                        INNER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                               AND OUU.OrgUnitMemberCode = 2
                        INNER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                    WHERE (dbo.fnOrgUnitHierarchyValue(ORG.OrgUnitID, 'mndnr') = {0})
                      AND ((USR.Austrittsdatum is null) OR (USR.Austrittsdatum >= {2}));",
                    dMandantanNummer,
                    Session.User.LanguageCode,
                    new DateTime(Convert.ToInt32(edtYear.Value), Convert.ToInt32(edtMonth.Value), 1),
                    setChecked);
            }
            catch (SoapException soapEx)
            {
                String errTxt = "Fehler beim Laden der Mitarbeiter in die Maske";

                _logger.Error(errTxt, soapEx);
                InsertAbaLog(Session.User.UserID, 0, null, null, soapEx.Message, errTxt);

                if (!suppressDialogs)
                {
                    KissMsg.ShowError(MASK_NAME, "Ma_Error", errTxt, soapEx);
                }

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
                String errTxt = "Fehler beim Laden der Mitarbeiter in die Maske";

                _logger.Error(errTxt, ex);
                InsertAbaLog(Session.User.UserID, 0, null, null, ex.Message, errTxt);

                if (!suppressDialogs)
                {
                    KissMsg.ShowError(MASK_NAME, "Ma_Error", errTxt, ex);
                }
            }
        }

        private void MandantSynchronisieren(int mandantenNr, bool askQuestions)
        {
            try
            {
                DlgProgressLog.AddLine(
                    KissMsg.GetMLMessage(MASK_NAME,
                        "MASchnittstelleStarteDatensynchronisationGeschaeftsbereich",
                        "Starte Datensynchronisation für Geschäftsbereich '{0}'.", mandantenNr));

                DatenAbakusUndKissVergleichen(mandantenNr);

                if (_mitarbeiterAbakus != null)
                {
                    DatenVomAbakusInsKissImportieren(askQuestions);
                }

                DlgProgressLog.AddLine(
                    KissMsg.GetMLMessage(MASK_NAME,
                        "MASchnittstelleDatensynchronisationGeschaeftsbereichAbgeschlossen",
                        "Datensynchronisation für Geschäftsbereich '{0}' abgeschlossen.", mandantenNr));

                DlgProgressLog.AddEmptyLine();
            }
            catch (CancelledByUserException)
            {
                _cancel = true;
            }
        }

        #endregion

        #endregion
    }
}