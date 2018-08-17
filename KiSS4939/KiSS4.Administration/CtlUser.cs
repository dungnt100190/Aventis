using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using DevExpress.XtraEditors;
using Kiss.BL.KissSystem;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;
using Kiss.UI.View.LocalResources.Ad;
using KiSS.DBScheme;
using KiSS4.BDE;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument.Utilities;
using KiSS4.Gui;
using log4net;
using SharpLibrary.WinControls;

namespace KiSS4.Administration
{
    /// <summary>
    /// Control, used to CRUD users
    /// </summary>
    public partial class CtlUser : KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private const string USR_ABTEILUNG = "Abteilung";
        private const string USR_ABTEILUNGKST = "AbteilungKST";
        private const string USR_PASSWORD = "Password";
        private const string USR_RETYPEPASSWORD = "RetypePassword";
        private readonly string _labelStd = "Std."; // used to store the appendix "Std." for Übersicht

        #endregion

        #region Private Fields

        private bool _defaultKeinSchnittstellenExport;
        private bool _isManualMode; // store the manual mode (either manual or data from external application)
        private bool _userModifiedPasswordField;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlUser"/> class.
        /// </summary>
        public CtlUser()
        {
            // logging
            _logger.Debug("enter");

            // init components
            InitializeComponent();

            // setup sql-statement on qryUser
            SetQryUserSQL();

            // setup rights
            SetupRights();

            // get textlabels
            _labelStd = KissMsg.GetMLMessage("CtlUser", "HourShortText", "Std.");

            // remove delete question to prevent asking
            qryZugeteilt.DeleteQuestion = null;

            // init default look and search
            tabUser.SelectedTabIndex = 0;

            // Laden der DropDown Box mit den Profilen.
            SqlQuery qry = GuiUtilities.GetSqlQueryXProfilesUserOrOrgUnit();

            edtUserProfil.LoadQuery(qry);
            edtUserProfil.Properties.DropDownRows = Math.Min(qry.Count, 14);

            // logging
            _logger.Debug("done");

            //sicherstellen, dass Focus nach KissPLZOrt noch weiter geht
            tpgBaAdresse.Controls.Add(new KissLookUpEdit { TabIndex = 999, TabStop = false, Visible = false });
        }

        #endregion

        #region EventHandlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // check if valid
            if (!btnAdd.Enabled || qryUser.Count == 0 || qryVerfuegbar.Count == 0 || !qryUser.Post())
            {
                return;
            }

            // get all rows the user selected
            int[] rowHandles = grdVerfuegbar.View.GetSelectedRows();

            if (rowHandles == null)
            {
                return;
            }

            // insert all rows the user selected
            foreach (int rowHandle in rowHandles)
            {
                qryZugeteilt.Insert();
                qryZugeteilt[DBO.XUser_UserGroup.UserID] = qryUser[DBO.XUser.UserID];
                qryZugeteilt[DBO.XUser_UserGroup.UserGroupID] = grdVerfuegbar.View.GetRowCellValue(
                    rowHandle, grdVerfuegbar.View.Columns["UserGroupID"]);
                qryZugeteilt.Post();
            }

            // update list
            DisplayGroups(true, true);

            // clear filter and set focus
            edtFilter.EditValue = null;
            edtFilter.Focus();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            // validate first
            if (!btnAddAll.Enabled || qryUser.Count == 0 || qryVerfuegbar.Count == 0)
            {
                return;
            }
            if (qryUser.Row.RowState == DataRowState.Added && !qryUser.Post())
            {
                return;
            }

            // start transaction
            Session.BeginTransaction();

            try
            {
                // remove all entries and reinsert values
                DBUtil.ExecSQLThrowingException(@"
                    DELETE
                    FROM dbo.XUser_UserGroup
                    WHERE UserID = {0}",
                    qryUser[DBO.XUser.UserID]);

                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO dbo.XUser_UserGroup (UserID, UserGroupID)
                      SELECT {0}, UGR.UserGroupID
                      FROM dbo.XUserGroup UGR WITH(READUNCOMMITTED)
                      WHERE UGR.OnlyAdminVisible IN (0, {1})",
                    qryUser[DBO.XUser.UserID],
                    Session.User.IsUserAdmin);

                // success, commit now
                Session.Commit();
            }
            catch (Exception ex)
            {
                // do rollback
                Session.Rollback();

                // show message
                KissMsg.ShowError(
                    Name,
                    "ErrorAddingAllItems",
                    "Es ist ein Fehler beim Hinzufügen aller Rollen aufgetreten. Die Aktion wurde rückgängig gemacht.",
                    ex);
            }

            // refresh list
            DisplayGroups(true, true);

            // clear filter and set focus
            edtFilter.EditValue = null;
            edtFilter.Focus();
        }

        private void btnGotoBDEErfassung_Click(object sender, EventArgs e)
        {
            // validate
            if (qryUser.Count < 1 || DBUtil.IsEmpty(qryUser[DBO.XUser.UserID]))
            {
                // invalid data, do nothing
                return;
            }

            // jump to form with given user
            FormController.OpenForm(
                "FrmBDEZeiterfassung",
                "Action",
                "SelectUser",
                "UserID",
                Convert.ToInt32(qryUser[DBO.XUser.UserID]));
        }

        private void btnPersonaldatenWerteAendern_Click(object sender, EventArgs e)
        {
            // check again if user has rights to do so
            if (!qryUser.CanUpdate || !btnPersonaldatenWerteAendern.Enabled)
            {
                // user has no rights to alter any data, do not continue
                KissMsg.ShowInfo(Name, "NoRightsToAlterUserPersonalData", "Sie besitzen keine Rechte für diese Funktionalität.");

                // do not continue
                return;
            }

            // create and show dialog where user can alter data (parameters: current selected "UserID" and "manual edit" --> show warning or not...)
            try
            {
                // create dialog
                var dlg = new DlgUserBDEDetails();

                // init data
                dlg.Init(
                    Convert.ToInt32(qryUser[DBO.XUser.UserID]),
                    DBUtil.GetConfigBool(@"System\Benutzerverwaltung\Benutzer\ManuelleBearbeitung", false),
                    Convert.ToString(qryUser[DBO.XUser.LastName]),
                    Convert.ToString(qryUser[DBO.XUser.FirstName]));

                // show dialog
                dlg.ShowDialog(this);
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorShowingDialogUserBDEDetails", "Es ist ein Fehler aufgetreten beim Erzeugen des Detail-Dialogs.", ex);
            }

            // refresh shown data
            DisplayBDEData();
            DisplayBDESollProJahr();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // validate first
            if (!btnRemove.Enabled || qryUser.Count == 0 || qryZugeteilt.Count == 0 || qryUser.Row.RowState == DataRowState.Added)
            {
                return;
            }

            // remove current entry
            qryZugeteilt.Delete();

            // refresh list
            DisplayGroups(true, false);
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            // validate first
            if (!btnRemoveAll.Enabled || qryUser.Count == 0 || qryZugeteilt.Count == 0 || qryUser.Row.RowState == DataRowState.Added)
            {
                return;
            }

            // remove all entries
            DBUtil.ExecSQL(@"
                DELETE
                FROM dbo.XUser_UserGroup
                WHERE UserID = {0} AND
                      UserGroupID IN (SELECT UGR.UserGroupID
                                      FROM dbo.XUserGroup UGR WITH(READUNCOMMITTED)
                                      WHERE UGR.OnlyAdminVisible IN (0, {1}))",
                qryUser[DBO.XUser.UserID],
                Session.User.IsUserAdmin);

            // refresh list
            DisplayGroups(true, true);
        }

        private void CtlUser_Load(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // Setup DataMember and FieldName
            SetupDataMember();
            SetupFieldName();

            // Load permissions
            SqlQuery qryXPermissionGroup = DBUtil.OpenSQL(@"
                SELECT PermissionGroupID,
                       PermissionGroupName
                FROM dbo.XPermissionGroup WITH (READUNCOMMITTED)

                UNION ALL

                SELECT NULL,
                       ''
                ORDER BY 2");

            edtPermissionGroupID.LoadQuery(qryXPermissionGroup, "PermissionGroupID", "PermissionGroupName");
            edtGrantPermGroupID.LoadQuery(qryXPermissionGroup, "PermissionGroupID", "PermissionGroupName");

            // setup default values
            edtSollProJahrJahr.EditValue = DateTime.Now.Year;
            _defaultKeinSchnittstellenExport = DBUtil.GetConfigBool(@"System\Schnittstellen\Alpi\Standard_KeinSchnittstellenExport", false);

            // run search
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);

            // logging
            _logger.Debug("done");
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            // do filtering
            qryVerfuegbar.DataTable.DefaultView.RowFilter = string.Format("UserGroupName LIKE '%{0}%'", edtFilter.EditValue);
        }

        private void edtPassword_Modified(object sender, EventArgs e)
        {
            _userModifiedPasswordField = true;
        }

        private void edtSollProJahrJahr_EditValueChanged(object sender, EventArgs e)
        {
            // reload data for new year
            DisplayBDESollProJahr();
        }

        private void grdVerfuegbar_DoubleClick(object sender, EventArgs e)
        {
            // add item
            btnAdd.PerformClick();
        }

        private void grdZugeteilt_DoubleClick(object sender, EventArgs e)
        {
            // remove item
            btnRemove.PerformClick();
        }

        private void qryBaAdresse_BeforePost(object sender, EventArgs e)
        {
            // validate
            edtPLZWohnsitz.DoValidate();

            // new history entry
            DBUtil.NewHistoryVersion();
        }

        private void qryUser_AfterFill(object sender, EventArgs e)
        {
            // refresh data
            qryUser_PositionChanged(this, EventArgs.Empty);
        }

        private void qryUser_AfterInsert(object sender, EventArgs e)
        {
            qryUser.SetCreator();

            qryUser[DBO.XUser.KeinBDEExport] = _defaultKeinSchnittstellenExport;

            // set focus
            edtLastName.Focus();
        }

        private void qryUser_AfterPost(object sender, EventArgs e)
        {
            // hide password again
            qryUser[USR_PASSWORD] = "***";
            qryUser[USR_RETYPEPASSWORD] = "***";
            _userModifiedPasswordField = false;

            try
            {
                qryBaAdresse[DBO.BaAdresse.UserID] = qryUser[DBO.XUser.UserID];
                qryBaAdresse.Post();
                qryXUserStundenansatz.Post();
                Session.Commit();
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void qryUser_BeforeDelete(object sender, EventArgs e)
        {
            // new history entry
            DBUtil.NewHistoryVersion();
        }

        private void qryUser_BeforePost(object sender, EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtLogonName, lblLogon.Text);
            DBUtil.CheckNotNullField(edtLastName, lblName.Text);

            /* PASSWORD */
            var usrPassword = qryUser[USR_PASSWORD].ToString();
            var usrPasswordRetype = qryUser[USR_RETYPEPASSWORD].ToString();
            var validationResult = KissServiceResult.Ok();
            try
            {
                if (_userModifiedPasswordField || qryUser.CurrentRowState == DataRowState.Added)
                {
                    var xUserService = Kiss.Infrastructure.IoC.Container.Resolve<XUserService>();
                    validationResult = xUserService.IsPasswordComplexCheck(usrPassword, true, usrPasswordRetype);
                }
            }
            finally
            {
                if (!validationResult.IsOk)
                {
                    KissMsg.ShowInfo(AdPasswortAendernViewRes.FehlerBeimPasswortAendern + Environment.NewLine + validationResult.GetWarningsAndErrors());
                    throw new KissCancelException();
                }
            }

            // create hash and hide password again
            if (qryUser[USR_PASSWORD].ToString() != "***")
            {
                qryUser[DBO.XUser.PasswordHash] = Session.ScramblePassword(qryUser[USR_PASSWORD].ToString());
            }

            // VALIDATE StdKA, StdKTR
            // kostenart
            if (!DBUtil.IsEmpty(qryUser[DBO.XUser.Kostenart]) && !DBUtil.IsEmpty(edtPersonaldatenStdKA.EditValue))
            {
                // validate
                if (Convert.ToDouble(edtPersonaldatenStdKA.EditValue) < 0.0)
                {
                    edtPersonaldatenStdKA.Focus();
                    KissMsg.ShowError(Name, "InvalidKostenartValue", "Die Standard-Kostenart kann nicht negativ sein.");
                    throw new KissCancelException();
                }
            }

            // kostentraeger
            if (!DBUtil.IsEmpty(qryUser[DBO.XUser.Kostentraeger]) && !DBUtil.IsEmpty(edtPersonaldatenStdKTR.EditValue))
            {
                // validate
                if (Convert.ToDouble(edtPersonaldatenStdKTR.EditValue) < 0.0)
                {
                    edtPersonaldatenStdKTR.Focus();
                    KissMsg.ShowError(Name, "InvalidKostentraegerValue", "Der Standard-Kostenträger kann nicht negativ sein.");
                    throw new KissCancelException();
                }
            }

            // Weitere Kostenträger validieren
            if (!DBUtil.IsEmpty(qryUser[DBO.XUser.WeitereKostentraeger]) && !DBUtil.IsEmpty(edtPersonaldatenWeitereKTR.EditValue))
            {
                // validate
                var values = edtPersonaldatenWeitereKTR.EditValue.ToString().Split(',');

                foreach (var ktr in values.Select(value => value.Trim()))
                {
                    int parsedInt;
                    var parsed = Int32.TryParse(ktr, out parsedInt);
                    if (!parsed || parsedInt < 0)
                    {
                        edtPersonaldatenWeitereKTR.Focus();
                        KissMsg.ShowError(
                            Name,
                            "InvalidWeitereKostentraegerValue",
                            "Ungültige Eingabe im Feld 'Weitere Kostenträger'." + Environment.NewLine + "Die Werte müssen numerisch und durch Komma getrennt sein.");
                        throw new KissCancelException();
                    }
                }
            }

            //Wenn in der DropDown keine Auswahl getroffen worden ist, dann ist der Code -1.
            //In diesem Falle speichern wir null.
            if (Utils.ConvertToInt(qryUser[DBO.XUser.XProfileID]) == -1)
            {
                qryUser[DBO.XUser.XProfileID] = null;
            }

            //Validiere BDE-Leistungsdaten wenn das Flag "Kein Schnittstellen-Export" verändert wurde
            if (qryUser.ColumnModified(DBO.XUser.KeinBDEExport))
            {
                //Gibt es einen nicht verbuchten Datensatz, dessen BDEExport-Flag dem neuen Stand der Checkbox NICHT entspricht?

                string sqlValidation = @"
                    SELECT COUNT(1)
                    FROM BDELeistung
                    WHERE UserID = {0}
                      AND Verbucht IS NULL
                      AND KeinExport <> {1};";

                var today = DateTime.Today;

                var nbrInvalidRecordsObject = DBUtil.ExecuteScalarSQL(sqlValidation, qryUser[DBO.XUser.UserID], qryUser[DBO.XUser.KeinBDEExport]);
                var nbrInvalidRecords = Utils.ConvertToInt(nbrInvalidRecordsObject);

                //Wenn ja -> Hinweis
                if (nbrInvalidRecords != 0)
                {
                    KissMsg.ShowInfo(Name, "KeinBDEExportFlagEsGibtBereitsErfassteDaten", "Das Flag 'Kein Schnittstellen-Export' kann nicht angepasst werden. Es gibt unverbuchte Zeiterfassungen, welche dem neuen Zustand des Flags widersprechen. Bitte löschen oder bereinigen Sie die widersprechenden Daten, bevor Sie das Flag erneut anpassen.");
                    throw new KissCancelException();
                }
            }

            // Beim Sperren auf offene Fälle prüfen
            if (qryUser.ColumnModified(DBO.XUser.IsLocked) && Utils.ConvertToBool(qryUser[DBO.XUser.IsLocked]))
            {
                var countFaFall = Utils.ConvertToInt(
                    DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(DISTINCT BaPersonID)
                        FROM dbo.FaLeistung
                        WHERE UserID = {0}
                          AND DatumBis IS NULL;",
                        qryUser[DBO.XUser.UserID]));

                if (countFaFall > 0)
                {
                    var msg = "Diesem Benutzer sind noch {0} offene Fälle zugewiesen.\r\n" +
                              "Weisen Sie die offenen Fälle einem anderen Benutzer zu.\r\n" +
                              "Wollen Sie den Benutzer trotzdem sperren?";

                    if (!KissMsg.ShowQuestion(typeof(CtlUser).Name, "SperrenOffeneFaelle", msg, false, countFaFall))
                    {
                        qryUser[DBO.XUser.IsLocked] = false;
                        throw new KissCancelException();
                    }
                }
            }

            // Row has been modified
            if (qryUser.RowModified)
            {
                // Phone = PhoneOffice
                qryUser[DBO.XUser.Phone] = qryUser[DBO.XUser.PhoneOffice];

                Session.BeginTransaction();

                // HISTORY
                // new history entry
                DBUtil.NewHistoryVersion();
                qryUser.SetModifierModified();
            }
        }

        private void qryUser_PositionChanged(object sender, EventArgs e)
        {
            // load depending values of selected user
            DisplayGroups(true, true);
            DisplayAbteilungen();
            DisplayUserRights();
            DisplayBDEData();
            DisplayBDESollProJahr();
            DisplayAdresse();
            DisplayStundenansatz();

            // setup colors and gridviews
            SetupGridViews();
            SetupExternalControlledControls();
        }

        private void qryUser_PositionChanging(object sender, EventArgs e)
        {
            // Speichere BaAdresse vor Zeilenwechsel
            qryBaAdresse.Post();
        }

        private void qryXUserStundenansatz_AfterInsert(object sender, EventArgs e)
        {
            qryXUserStundenansatz[DBO.XUserStundenansatz.UserID] = qryUser[DBO.XUser.UserID];
        }

        private void qryXUserStundenansatz_BeforePost(object sender, EventArgs e)
        {
            ValidateStundenansatz(edtStundenansatz1);
            ValidateStundenansatz(edtStundenansatz2);
            ValidateStundenansatz(edtStundenansatz3);
            ValidateStundenansatz(edtStundenansatz4);
            ValidateStundenansatz(edtStundenansatz5);
            ValidateStundenansatz(edtStundenansatz6);
            ValidateStundenansatz(edtStundenansatz7);
            ValidateStundenansatz(edtStundenansatz8);
            ValidateStundenansatz(edtStundenansatz9);
            ValidateStundenansatz(edtStundenansatz10);
            ValidateStundenansatz(edtStundenansatz11);
            ValidateStundenansatz(edtStundenansatz12);
            ValidateStundenansatz(edtStundenansatz13);
            ValidateStundenansatz(edtStundenansatz14);
            ValidateStundenansatz(edtStundenansatz15);
            ValidateStundenansatz(edtStundenansatz16);
            ValidateStundenansatz(edtStundenansatz17);
            ValidateStundenansatz(edtStundenansatz18);
            ValidateStundenansatz(edtStundenansatz19);
            ValidateStundenansatz(edtStundenansatz20);

            DBUtil.NewHistoryVersion();
        }

        private void tabUser_SelectedTabChanged(TabPageEx page)
        {
            // HACK: due to an unknown bug, the gridview will only change if visible...
            SetupGridViews();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnSaveData()
        {
            qryUser.EndCurrentEdit();

            //sicherstellen, dass BaAdresse gespeichert wird, wenn nur Adresse angepasst wird und qryUser unmodified bleibt
            if (!qryUser.RowModified)
            {
                if (!DBUtil.IsEmpty(qryBaAdresse[DBO.BaAdresse.UserID]))
                {
                    qryBaAdresse.Post();
                }

                qryXUserStundenansatz.EndCurrentEdit();

                if (qryXUserStundenansatz.RowModified)
                {
                    DBUtil.NewHistoryVersion();
                    qryXUserStundenansatz.Post();
                }
            }

            // save pending changes
            return base.OnSaveData(); // ActiveSqlQuery
        }

        public override void OnUndoDataChanges()
        {
            qryBaAdresse.Cancel();
            qryXUserStundenansatz.Cancel();
            base.OnUndoDataChanges();
            _userModifiedPasswordField = false;
        }

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // update other data
            qryUser_PositionChanged(this, EventArgs.Empty);
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set default values
            chkSucheNurAdmin.Checked = false;
            chkSucheNurNichtGesperrt.Checked = true;
            chkSucheNurBIAGAdmin.Checked = false;

            // set focus
            edtSucheName.Focus();
        }

        #endregion

        #region Private Methods

        private void DisplayAbteilungen()
        {
            // fill data
            qryAbteilung.Fill(@"
                SELECT OUU.*,
                       Abteilung = ORG.ItemName,
                       Funktion = dbo.fnGetLOVMLText('OrgUnitMember', OUU.OrgUnitMemberCode, {1})
                FROM dbo.XOrgUnit_User    OUU WITH(READUNCOMMITTED)
                  INNER JOIN dbo.XOrgUnit ORG WITH(READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                WHERE OUU.UserID = {0}
                ORDER BY OUU.OrgUnitMemberCode, Abteilung",
                qryUser[DBO.XUser.UserID],
                Session.User.LanguageCode);
        }

        private void DisplayAdresse()
        {
            // fill data
            qryBaAdresse.Fill(@"
                SELECT
                       ADR.BaAdresseID,
                       ADR.AdresseCode,
                       ADR.Zusatz,
                       ADR.Strasse,
                       ADR.HausNr,
                       ADR.Postfach,
                       ADR.PostfachOhneNr,
                       ADR.PLZ,
                       ADR.Ort,
                       ADR.OrtschaftCode,
                       ADR.Kanton,
                       ADR.Bezirk,
                       ADR.BaLandID,
                       ADR.UserID,
                       ADR.Creator,
                       ADR.Created,
                       ADR.Modifier,
                       ADR.Modified
                FROM
                     dbo.BaAdresse ADR
                WHERE ADR.UserID={0}",
                qryUser[DBO.XUser.UserID]
                );
            if (qryBaAdresse.Count == 0 && qryBaAdresse.CanInsert)
            {
                qryBaAdresse.SetCreator();
                qryBaAdresse.SetModifierModified();
                qryBaAdresse.Insert();
                qryBaAdresse[DBO.BaAdresse.UserID] = qryUser[DBO.XUser.UserID];
                qryBaAdresse[DBO.BaAdresse.AdresseCode] = 1;
            }

            qryBaAdresse.Position = 0;
        }

        private void DisplayBDEData()
        {
            // load new data for current month
            // >> query will always return a row (if valid parameters given)
            qryBDEData.Fill(@"
                SELECT *
                FROM dbo.fnBDEGetUebersicht({0}, dbo.fnLastDayOf(GETDATE()), {1}, 1)",
                qryUser[DBO.XUser.UserID],
                Session.User.LanguageCode); // for last day of current month!

            // setup year and month
            lblPersonaldatenAktuellerMonat.Text = qryBDEData["MonatJahrText"] as string;

            // setup labels
            UpdateUebersichtLabel(lblPersonaldatenPensum, qryBDEData["PensumProzent"], "%", false, false);
            UpdateUebersichtLabel(lblPersonaldatenSollProTag, qryBDEData["SollArbeitszeitProTag"], _labelStd, true, false);
            UpdateUebersichtLabel(lblPersonaldatenSollProMonat, qryBDEData["GZSollArbeitszeitProMonat"], _labelStd, true, false);
            UpdateUebersichtLabel(lblPersonaldatenFerienanspruch, qryBDEData["FerienAnspruchProJahr"], _labelStd, true, true);
            UpdateUebersichtLabel(lblPersonaldatenFerienZugabenKuerzungen, qryBDEData["FerienZugabenKuerzungen"], _labelStd, true, true);
            UpdateUebersichtLabel(lblPersonaldatenAusbezUeberstunden, qryBDEData["GZAusbezahlteUeberstunden"], _labelStd, true, true);

            // handle editmode of controls
            qryBDEData.EnableBoundFields(qryBDEData.CanUpdate);
        }

        private void DisplayBDESollProJahr()
        {
            // set vars
            int currentUser = DBUtil.IsEmpty(qryUser[DBO.XUser.UserID]) ? -1 : Convert.ToInt32(qryUser[DBO.XUser.UserID]);
            int currentYear = DBUtil.IsEmpty(edtSollProJahrJahr.EditValue) ? DateTime.Now.Year : Convert.ToInt32(edtSollProJahrJahr.EditValue);

            // load new data for current month
            qryBDESollProJahr.Fill(String.Format(@"
                SELECT Jahr = {1},
                       SollProJahrJanuar    = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-01-01')),  -- always for last day of current year and month
                       SollProJahrFebruar   = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-02-01')),
                       SollProJahrMaerz     = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-03-01')),
                       SollProJahrApril     = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-04-01')),
                       SollProJahrMai       = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-05-01')),
                       SollProJahrJuni      = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-06-01')),
                       SollProJahrJuli      = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-07-01')),
                       SollProJahrAugust    = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-08-01')),
                       SollProJahrSeptember = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-09-01')),
                       SollProJahrOktober   = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-10-01')),
                       SollProJahrNovember  = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-11-01')),
                       SollProJahrDezember  = dbo.fnBDEGetSollProMonat({0}, dbo.fnLastDayOf('{1}-12-01'))",
                    currentUser,
                    currentYear));

            // setup labels
            UpdateUebersichtLabel(lblSollProJahrJanuar, qryBDESollProJahr["SollProJahrJanuar"], _labelStd, true, false);
            UpdateUebersichtLabel(lblSollProJahrFebruar, qryBDESollProJahr["SollProJahrFebruar"], _labelStd, true, false);
            UpdateUebersichtLabel(lblSollProJahrMaerz, qryBDESollProJahr["SollProJahrMaerz"], _labelStd, true, false);
            UpdateUebersichtLabel(lblSollProJahrApril, qryBDESollProJahr["SollProJahrApril"], _labelStd, true, false);
            UpdateUebersichtLabel(lblSollProJahrMai, qryBDESollProJahr["SollProJahrMai"], _labelStd, true, false);
            UpdateUebersichtLabel(lblSollProJahrJuni, qryBDESollProJahr["SollProJahrJuni"], _labelStd, true, false);
            UpdateUebersichtLabel(lblSollProJahrJuli, qryBDESollProJahr["SollProJahrJuli"], _labelStd, true, false);
            UpdateUebersichtLabel(lblSollProJahrAugust, qryBDESollProJahr["SollProJahrAugust"], _labelStd, true, false);
            UpdateUebersichtLabel(lblSollProJahrSeptember, qryBDESollProJahr["SollProJahrSeptember"], _labelStd, true, false);
            UpdateUebersichtLabel(lblSollProJahrOktober, qryBDESollProJahr["SollProJahrOktober"], _labelStd, true, false);
            UpdateUebersichtLabel(lblSollProJahrNovember, qryBDESollProJahr["SollProJahrNovember"], _labelStd, true, false);
            UpdateUebersichtLabel(lblSollProJahrDezember, qryBDESollProJahr["SollProJahrDezember"], _labelStd, true, false);

            // handle editmode of controls
            qryBDESollProJahr.EnableBoundFields(qryBDESollProJahr.CanUpdate);
        }

        private void DisplayGroups(bool refreshVerfuegbar, bool refreshZugeteilt)
        {
            if (refreshZugeteilt)
            {
                // fill data
                qryZugeteilt.Fill(@"
                    SELECT UUG.*,
                           UserGroupName = dbo.fnGetMLTextByDefault(UGR.UserGroupNameTID, {2}, UGR.UserGroupName)
                    FROM dbo.XUser_UserGroup    UUG WITH(READUNCOMMITTED)
                      INNER JOIN dbo.XUserGroup UGR WITH(READUNCOMMITTED) ON UGR.UserGroupID = UUG.UserGroupID
                    WHERE UUG.UserID = {0}
                      AND UGR.OnlyAdminVisible IN (0, {1})
                    ORDER BY UGR.UserGroupName",
                    qryUser[DBO.XUser.UserID],
                    Session.User.IsUserAdmin,
                    Session.User.LanguageCode);
            }

            if (refreshVerfuegbar)
            {
                qryVerfuegbar.Fill(@"
                    SELECT UGR.UserGroupID,
                           UserGroupName = dbo.fnGetMLTextByDefault(UGR.UserGroupNameTID, {2}, UGR.UserGroupName)
                    FROM dbo.XUserGroup             UGR WITH(READUNCOMMITTED)
                      LEFT JOIN dbo.XUser_UserGroup UUG WITH(READUNCOMMITTED) ON UUG.UserGroupID = UGR.UserGroupID
                                                                             AND UUG.UserID = {0}
                    WHERE UUG.UserGroupID IS NULL
                      AND UGR.OnlyAdminVisible IN (0, {1})
                    ORDER BY UserGroupName",
                    qryUser[DBO.XUser.UserID],
                    Session.User.IsUserAdmin,
                    Session.User.LanguageCode);
            }
        }

        private void DisplayStundenansatz()
        {
            qryXUserStundenansatz.Fill(@"
                SELECT
                  USA.XUserStundenansatzID,
                  USA.UserID,
                  USA.Lohnart1,
                  USA.Lohnart2,
                  USA.Lohnart3,
                  USA.Lohnart4,
                  USA.Lohnart5,
                  USA.Lohnart6,
                  USA.Lohnart7,
                  USA.Lohnart8,
                  USA.Lohnart9,
                  USA.Lohnart10,
                  USA.Lohnart11,
                  USA.Lohnart12,
                  USA.Lohnart13,
                  USA.Lohnart14,
                  USA.Lohnart15,
                  USA.Lohnart16,
                  USA.Lohnart17,
                  USA.Lohnart18,
                  USA.Lohnart19,
                  USA.Lohnart20,
                  USA.Creator,
                  USA.Created,
                  USA.Modifier,
                  USA.Modified
                FROM dbo.XUserStundenansatz USA WITH(READUNCOMMITTED)
                WHERE USA.UserID = {0};",
                qryUser[DBO.XUser.UserID]);

            if (qryXUserStundenansatz.IsEmpty && qryXUserStundenansatz.CanInsert)
            {
                qryXUserStundenansatz.Insert();
            }
        }

        private void DisplayUserRights()
        {
            // fill data
            qryUserRight.Fill(@"
                DECLARE @UserID INT;
                DECLARE @LanguageCode INT;

                SET @UserID = {0};
                SET @LanguageCode = {1};

                DECLARE @Rights TABLE
                (
                  UserGroup_RightID INT,
                  UserGroupID INT,
                  MayInsert BIT,
                  MayUpdate BIT,
                  MayDelete BIT,
                  XUserGroup_RightTS BINARY(8),     -- cannot use TIMESTAMP here
                  UserText VARCHAR(765) NOT NULL,   -- calculated amount of chars!
                  XClassID INT NULL,
                  ClassName VARCHAR(255) NULL,
                  RightID INT,
                  MaskName VARCHAR(100)
                );

                INSERT INTO @Rights
                  EXEC dbo.spXGetRightsAssignedUnassigned NULL, 0, 0, @LanguageCode;

                SELECT DISTINCT
                  UserText  = COALESCE(TMP.UserText, RGT.UserText, 'REP - ' + QRY.UserText),
                  MayInsert = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayInsert))),
                  MayUpdate = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayUpdate))),
                  MayDelete = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayDelete)))
                FROM dbo.XUserGroup_Right UGR WITH(READUNCOMMITTED)
                  LEFT JOIN dbo.XRight    RGT WITH(READUNCOMMITTED) ON RGT.RightID = UGR.RightID
                  LEFT JOIN dbo.XClass    CLS WITH(READUNCOMMITTED) ON CLS.ClassName = UGR.ClassName
                  LEFT JOIN dbo.XQuery    QRY WITH(READUNCOMMITTED) ON QRY.QueryName = UGR.QueryName
                  LEFT JOIN @Rights       TMP ON TMP.RightID = RGT.RightID
                                              OR (TMP.RightID IS NULL AND TMP.ClassName = CLS.ClassName)
                                              OR (TMP.RightID IS NULL AND TMP.ClassName IS NULL AND TMP.MaskName = UGR.MaskName)
                WHERE UGR.UserGroupID IN (SELECT UserGroupID
                                          FROM dbo.XUser_UserGroup WITH(READUNCOMMITTED)
                                          WHERE UserID = @UserID)
                GROUP BY TMP.UserText, RGT.UserText, QRY.UserText
                ORDER BY UserText;",
                qryUser[DBO.XUser.UserID],
                Session.User.LanguageCode);
        }

        /// <summary>
        /// Set prepared sql-statement to qryUser
        /// </summary>
        private void SetQryUserSQL()
        {
            // set prepared sql-statement to qry
            qryUser.SelectStatement = string.Format(@"
                -------------------------------------------------------------------------------
                -- due to performance, we do not use a join on XOrgUnit!
                -------------------------------------------------------------------------------
                SELECT USR.*,
                       Password       = '***',
                       RetypePassword = '***',
                       Abteilung      = dbo.fnOrgUnitOfUser(USR.UserID, 0),
                       AbteilungKST   = (SELECT dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName)
                                         FROM dbo.XOrgUnit ORG WITH(READUNCOMMITTED)
                                         WHERE ORG.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(USR.UserID, 1)))
                FROM dbo.XUser USR WITH(READUNCOMMITTED)
                WHERE ({0} = 1 OR ISNULL(USR.IsUserBIAGAdmin, 0) = 0)  -- BIAGAdmins are only visible to BIAGAdmins due to security!
                --- AND USR.LastName LIKE {{edtSucheName}} + '%'
                --- AND USR.FirstName LIKE {{edtSucheVorname}} + '%'
                --- AND USR.LogonName LIKE {{edtSucheLogon}} + '%'
                --- AND USR.UserID = {{edtSucheUserID}}
                --- AND USR.MitarbeiterNr = {{edtSuchePersNr}}
                --- AND dbo.fnOrgUnitOfUser(USR.UserID, 0) LIKE {{edtSucheAbteilung}} + '%'
                --- AND USR.IsLocked = CASE WHEN ISNULL({{chkSucheNurNichtGesperrt}}, 0) = 1 THEN 0 ELSE USR.IsLocked END
                --- AND USR.IsUserAdmin = CASE WHEN ISNULL({{chkSucheNurAdmin}}, 0) = 1 THEN 1 ELSE USR.IsUserAdmin END
                --- AND USR.IsUserBIAGAdmin = CASE WHEN ISNULL({{chkSucheNurBIAGAdmin}}, 0) = 1 THEN 1 ELSE USR.IsUserBIAGAdmin END
                ORDER BY USR.LastName, USR.FirstName, USR.UserID",
                DBUtil.SqlLiteral(Session.User.IsUserBIAGAdmin));
        }

        private void SetupDataMember()
        {
            // Benutzer
            edtUserID.DataMember = DBO.XUser.UserID;
            chkIsLocked.DataMember = DBO.XUser.IsLocked;
            edtPersonalNr.DataMember = DBO.XUser.MitarbeiterNr;
            edtLastName.DataMember = DBO.XUser.LastName;
            edtFirstName.DataMember = DBO.XUser.FirstName;
            edtLogonName.DataMember = DBO.XUser.LogonName;
            edtShortName.DataMember = DBO.XUser.ShortName;
            edtPassword.DataMember = USR_PASSWORD;
            edtPasswordRetype.DataMember = USR_RETYPEPASSWORD;
            chkUserSystemadministration.DataMember = DBO.XUser.IsUserAdmin;
            chkUserIsUserBIAGAdmin.DataMember = DBO.XUser.IsUserBIAGAdmin;
            edtGenderCode.DataMember = DBO.XUser.GenderCode;
            edtLanguageCode.DataMember = DBO.XUser.LanguageCode;
            edtPhone.DataMember = DBO.XUser.PhoneOffice;
            edtEmail.DataMember = DBO.XUser.EMail;
            memBemerkungen.DataMember = DBO.XUser.Bemerkungen;
            edtPermissionGroupID.DataMember = DBO.XUser.PermissionGroupID;
            edtGrantPermGroupID.DataMember = DBO.XUser.GrantPermGroupID;
            edtModulCode.DataMember = DBO.XUser.ModulID;
            edtUserProfil.DataMember = DBO.XUser.XProfileID;
            edtQualifikation.DataMember = DBO.XUser.QualificationTitleCode;
            edtFunktionsbezeichnung.DataMember = DBO.XUser.RoleTitleCode;

            // Personaldaten
            edtPersonaldatenEintritt.DataMember = DBO.XUser.Eintrittsdatum;
            edtPersonaldatenAustritt.DataMember = DBO.XUser.Austrittsdatum;
            edtPersonaldatenStdKST.DataMember = USR_ABTEILUNGKST;
            edtPersonaldatenStdKA.DataMember = DBO.XUser.Kostenart;
            edtPersonaldatenStdKTR.DataMember = DBO.XUser.Kostentraeger;
            edtPersonaldatenWeitereKTR.DataMember = DBO.XUser.WeitereKostentraeger;
            edtPersonaldatenLohntyp.DataMember = DBO.XUser.LohntypCode;
            edtKeinExport.DataMember = DBO.XUser.KeinBDEExport;

            // BaAdresse-Daten
            edtAdresseZusatz.DataMember = DBO.BaAdresse.Zusatz;
            edtAdresseStrasse.DataMember = DBO.BaAdresse.Strasse;
            edtAdresseHausNr.DataMember = DBO.BaAdresse.HausNr;
            edtAdressePostfach.DataMember = DBO.BaAdresse.Postfach;
            chkPostfachOhneNummer.DataMember = DBO.BaAdresse.PostfachOhneNr;
            edtPLZWohnsitz.DataMember = DBO.BaAdresse.OrtschaftCode;
            edtPLZWohnsitz.DataMemberPLZ = DBO.BaAdresse.PLZ;
            edtPLZWohnsitz.DataMemberOrt = DBO.BaAdresse.Ort;
            edtPLZWohnsitz.DataMemberKanton = DBO.BaAdresse.Kanton;
            edtPLZWohnsitz.DataMemberBezirk = DBO.BaAdresse.Bezirk;
            edtPLZWohnsitz.DataMemberLand = DBO.BaAdresse.BaLandID;
            edtXUserPhonePrivat.DataMember = DBO.XUser.PhonePrivat;
            edtXUserPhoneGesch.DataMember = DBO.XUser.PhoneOffice;
            edtXUSerPhoneMobile.DataMember = DBO.XUser.PhoneMobile;
            edtXUserFax.DataMember = DBO.XUser.Fax;
            edtXUserEmail.DataMember = DBO.XUser.EMail;

            // Stundenansatz
            edtStundenansatz1.DataMember = DBO.XUserStundenansatz.Lohnart1;
            edtStundenansatz2.DataMember = DBO.XUserStundenansatz.Lohnart2;
            edtStundenansatz3.DataMember = DBO.XUserStundenansatz.Lohnart3;
            edtStundenansatz4.DataMember = DBO.XUserStundenansatz.Lohnart4;
            edtStundenansatz5.DataMember = DBO.XUserStundenansatz.Lohnart5;
            edtStundenansatz6.DataMember = DBO.XUserStundenansatz.Lohnart6;
            edtStundenansatz7.DataMember = DBO.XUserStundenansatz.Lohnart7;
            edtStundenansatz8.DataMember = DBO.XUserStundenansatz.Lohnart8;
            edtStundenansatz9.DataMember = DBO.XUserStundenansatz.Lohnart9;
            edtStundenansatz10.DataMember = DBO.XUserStundenansatz.Lohnart10;
            edtStundenansatz11.DataMember = DBO.XUserStundenansatz.Lohnart11;
            edtStundenansatz12.DataMember = DBO.XUserStundenansatz.Lohnart12;
            edtStundenansatz13.DataMember = DBO.XUserStundenansatz.Lohnart13;
            edtStundenansatz14.DataMember = DBO.XUserStundenansatz.Lohnart14;
            edtStundenansatz15.DataMember = DBO.XUserStundenansatz.Lohnart15;
            edtStundenansatz16.DataMember = DBO.XUserStundenansatz.Lohnart16;
            edtStundenansatz17.DataMember = DBO.XUserStundenansatz.Lohnart17;
            edtStundenansatz18.DataMember = DBO.XUserStundenansatz.Lohnart18;
            edtStundenansatz19.DataMember = DBO.XUserStundenansatz.Lohnart19;
            edtStundenansatz20.DataMember = DBO.XUserStundenansatz.Lohnart20;
        }

        /// <summary>
        /// Setup color of control depending on current editmode. This is only neccessary for those controls who are updated from external application.
        /// </summary>
        /// <param name="edt">The control to setup</param>
        /// <param name="currentEditMode">The current <see cref="EditModeType"/> of the control</param>
        private void SetupEditColor(BaseEdit edt, EditModeType currentEditMode)
        {
            // validate
            if (edt == null)
            {
                throw new ArgumentNullException("edt", "Invalid edit, cannot setup color.");
            }

            // set background-color depending on current editmode
            if (currentEditMode == EditModeType.Normal)
            {
                // depending on personal-number given, we set color
                if (DBUtil.IsEmpty(qryUser[DBO.XUser.MitarbeiterNr]))
                {
                    // set default background color
                    edt.BackColor = GuiConfig.EditColorNormal;
                }
                else
                {
                    // set different warning-background color
                    edt.BackColor = Color.FromArgb(255, 215, 215);
                }
            }
        }

        /// <summary>
        /// Setup controls depending on usage with external application or only within KiSS
        /// </summary>
        private void SetupExternalControlledControls()
        {
            // only if not manual-mode
            if (_isManualMode)
            {
                // logging
                _logger.Debug("this.IsManualMode=true, cancel with setup");

                // cancel
                return;
            }

            // Benutzer/in tpg
            SetupEditColor(edtPersonalNr, edtPersonalNr.EditMode);
            SetupEditColor(edtLastName, edtLastName.EditMode);
            SetupEditColor(edtFirstName, edtFirstName.EditMode);
            SetupEditColor(edtGenderCode, edtGenderCode.EditMode);
            SetupEditColor(edtPhone, edtPhone.EditMode);
            SetupEditColor(edtEmail, edtEmail.EditMode);
            SetupEditColor(edtLanguageCode, edtLanguageCode.EditMode);
            SetupEditColor(edtFunktionsbezeichnung, edtFunktionsbezeichnung.EditMode);
            SetupEditColor(edtQualifikation, edtQualifikation.EditMode);

            // Personaldaten tpg
            SetupEditColor(edtPersonaldatenEintritt, edtPersonaldatenEintritt.EditMode);
            SetupEditColor(edtPersonaldatenAustritt, edtPersonaldatenAustritt.EditMode);
            SetupEditColor(edtPersonaldatenStdKA, edtPersonaldatenStdKA.EditMode);
            SetupEditColor(edtPersonaldatenStdKTR, edtPersonaldatenStdKTR.EditMode);
            SetupEditColor(edtPersonaldatenLohntyp, edtPersonaldatenLohntyp.EditMode);

            // Stundenansatz
            SetupEditColor(edtStundenansatz1, edtStundenansatz1.EditMode);
            SetupEditColor(edtStundenansatz2, edtStundenansatz2.EditMode);
            SetupEditColor(edtStundenansatz3, edtStundenansatz3.EditMode);
            SetupEditColor(edtStundenansatz4, edtStundenansatz4.EditMode);
            SetupEditColor(edtStundenansatz11, edtStundenansatz11.EditMode);
            SetupEditColor(edtStundenansatz12, edtStundenansatz12.EditMode);
            SetupEditColor(edtStundenansatz13, edtStundenansatz13.EditMode);
            SetupEditColor(edtStundenansatz14, edtStundenansatz14.EditMode);
            SetupEditColor(edtStundenansatz15, edtStundenansatz15.EditMode);
            SetupEditColor(edtStundenansatz16, edtStundenansatz16.EditMode);

            //Die folgenden Felder werden aktuell noch nicht über den MA-Schnittstellen-Webservice übertragen:
            //SetupEditColor(edtStundenansatz5, edtStundenansatz5.EditMode);
            //SetupEditColor(edtStundenansatz6, edtStundenansatz6.EditMode);
            //SetupEditColor(edtStundenansatz7, edtStundenansatz7.EditMode);
            //SetupEditColor(edtStundenansatz8, edtStundenansatz8.EditMode);
            //SetupEditColor(edtStundenansatz9, edtStundenansatz9.EditMode);
            //SetupEditColor(edtStundenansatz16, edtStundenansatz16.EditMode);
            //SetupEditColor(edtStundenansatz17, edtStundenansatz17.EditMode);
            //SetupEditColor(edtStundenansatz18, edtStundenansatz18.EditMode);
            //SetupEditColor(edtStundenansatz19, edtStundenansatz19.EditMode);
            //SetupEditColor(edtStundenansatz20, edtStundenansatz20.EditMode);

            // Adressdaten
            SetupEditColor(edtAdresseZusatz, edtAdresseZusatz.EditMode);
            SetupEditColor(edtAdresseStrasse, edtAdresseStrasse.EditMode);
            SetupEditColor(edtAdresseHausNr, edtAdresseHausNr.EditMode);
            SetupEditColor(edtAdressePostfach, edtAdressePostfach.EditMode);
            //CHKBOX testen
            SetupEditColor(edtPLZWohnsitz.EdtPLZ, edtPLZWohnsitz.EdtPLZ.EditMode);
            SetupEditColor(edtPLZWohnsitz.EdtOrt, edtPLZWohnsitz.EdtOrt.EditMode);
            SetupEditColor(edtPLZWohnsitz.EdtKanton, edtPLZWohnsitz.EdtKanton.EditMode);
            SetupEditColor(edtPLZWohnsitz.EdtBezirk, edtPLZWohnsitz.EdtBezirk.EditMode);
            SetupEditColor(edtPLZWohnsitz.EdtLand, edtPLZWohnsitz.EdtLand.EditMode);
            SetupEditColor(edtXUserPhonePrivat, edtXUserPhonePrivat.EditMode);
            SetupEditColor(edtXUserPhoneGesch, edtXUserPhoneGesch.EditMode);
            SetupEditColor(edtXUSerPhoneMobile, edtXUSerPhoneMobile.EditMode);
            SetupEditColor(edtXUserFax, edtXUserFax.EditMode);
            SetupEditColor(edtXUserEmail, edtXUserEmail.EditMode);
        }

        private void SetupFieldName()
        {
            colUserID.FieldName = DBO.XUser.UserID;
            colPersonalNr.FieldName = DBO.XUser.MitarbeiterNr;
            colLogonName.FieldName = DBO.XUser.LogonName;
            colLastName.FieldName = DBO.XUser.LastName;
            colFirstName.FieldName = DBO.XUser.FirstName;
            colIsUserAdmin.FieldName = DBO.XUser.IsUserAdmin;
            colIsUserBIAGAdmin.FieldName = DBO.XUser.IsUserBIAGAdmin;
            colIsLocked.FieldName = DBO.XUser.IsLocked;
            colOrgUnit.FieldName = USR_ABTEILUNG;
            colUserStandardKST.FieldName = USR_ABTEILUNGKST;
            colUserStandardKostenart.FieldName = DBO.XUser.Kostenart;
            colUserStandardKTR.FieldName = DBO.XUser.Kostentraeger;
            colUserWeitereKTR.FieldName = DBO.XUser.WeitereKostentraeger;
        }

        private void SetupGridViews()
        {
            grvVerfuegbar.OptionsView.ColumnAutoWidth = true;
            grvZugeteilt.OptionsView.ColumnAutoWidth = true;
            grvRechte.OptionsView.ColumnAutoWidth = true;
            grvAbteilungen.OptionsView.ColumnAutoWidth = true;
        }

        private void SetupRights()
        {
            // logging
            _logger.Debug("enter");

            #region Setup RightVars

            // init vars
            bool isAdmin = Session.User.IsUserAdmin;
            _isManualMode = DBUtil.GetConfigBool(@"System\Benutzerverwaltung\Benutzer\ManuelleBearbeitung", false);
            bool hasSpecialRightHS = isAdmin || DBUtil.UserHasRight("ADUserAdminHS");

            bool canReadData;
            bool canUserInsert;
            bool canUserUpdate;
            bool canUserDelete;

            // set values
            Session.GetUserRight(Name, out canReadData, out canUserInsert, out canUserUpdate, out canUserDelete);

            if (!canReadData)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            // logging
            _logger.DebugFormat(
                "isAdmin='{0}', this.IsManualMode='{1}', hasSpecialRightHS='{2}', canReadData='{3}', canUserInsert='{4}', canUserUpdate='{5}', canUserDelete='{6}'",
                isAdmin,
                _isManualMode,
                hasSpecialRightHS,
                canReadData,
                canUserInsert,
                canUserUpdate,
                canUserDelete);

            #endregion

            #region Setup SqlQueries

            // USER
            // init first
            qryUser.CanInsert = isAdmin || (canUserInsert && (_isManualMode || hasSpecialRightHS)); // only admins and (manualmode or specialright with right) can insert/delete data
            qryUser.CanUpdate = isAdmin || canUserUpdate;
            qryUser.CanDelete = isAdmin || (canUserDelete && (_isManualMode || hasSpecialRightHS));

            // ORGUNITS
            // always disabled
            qryAbteilung.CanInsert = false;
            qryAbteilung.CanUpdate = false;
            qryAbteilung.CanDelete = false;

            // BDEDATA:
            // always disabled, showing just informations
            qryBDEData.CanInsert = false;
            qryBDEData.CanUpdate = false;
            qryBDEData.CanDelete = false;

            qryBDESollProJahr.CanInsert = false;
            qryBDESollProJahr.CanUpdate = false;
            qryBDESollProJahr.CanDelete = false;

            // USERRIGHTS
            // always disabled
            qryUserRight.CanInsert = false;
            qryUserRight.CanUpdate = false;
            qryUserRight.CanDelete = false;

            // ROLLEN
            // always disabled
            qryVerfuegbar.CanInsert = false;
            qryVerfuegbar.CanUpdate = false;
            qryVerfuegbar.CanDelete = false;

            // depending on qryUser.CanUpdate
            qryZugeteilt.CanInsert = qryUser.CanUpdate;
            qryZugeteilt.CanUpdate = qryUser.CanUpdate;
            qryZugeteilt.CanDelete = qryUser.CanUpdate;

            qryBaAdresse.CanInsert = qryUser.CanInsert;
            qryBaAdresse.CanUpdate = qryUser.CanUpdate;
            qryBaAdresse.CanDelete = qryUser.CanDelete;

            #endregion

            #region Setup Controls

            // EDIT MODES
            // eml: needs to have update-rights (set above)
            EditModeType editModeEML = qryUser.CanUpdate ? EditModeType.Normal : EditModeType.ReadOnly;

            // hs: needs to have updates rights and special-right (set above)
            EditModeType editModeHS = qryUser.CanUpdate && hasSpecialRightHS ? EditModeType.Normal : EditModeType.ReadOnly;

            // controls on Benutzer/in-tpg
            edtUserID.EditMode = EditModeType.ReadOnly; // always locked
            edtPersonalNr.EditMode = editModeHS;
            edtLastName.EditMode = editModeHS;
            edtFirstName.EditMode = editModeHS;
            edtLogonName.EditMode = editModeEML;
            edtShortName.EditMode = editModeEML;
            edtPassword.EditMode = editModeHS;
            edtPasswordRetype.EditMode = editModeHS;
            chkUserSystemadministration.EditMode = isAdmin ? EditModeType.Normal : EditModeType.ReadOnly; // can only be set by a Sysadmin
            chkUserIsUserBIAGAdmin.EditMode = Session.User.IsUserBIAGAdmin ? EditModeType.Normal : EditModeType.ReadOnly; // can only be set by BIAG-Admin
            chkIsLocked.EditMode = editModeEML;
            edtGenderCode.EditMode = editModeHS;
            edtLanguageCode.EditMode = editModeHS;
            edtPhone.EditMode = editModeEML;
            edtEmail.EditMode = editModeEML;
            memBemerkungen.EditMode = editModeEML;
            edtUserProfil.EditMode = editModeEML;

            // >> show biag-admin stuff only if biag admin (except checkbox set above)
            colIsUserBIAGAdmin.Visible = Session.User.IsUserBIAGAdmin;
            chkSucheNurBIAGAdmin.Visible = Session.User.IsUserBIAGAdmin;
            chkUserIsUserBIAGAdmin.Visible = Session.User.IsUserBIAGAdmin;

            // controls on Rollen-tgp
            btnAdd.Enabled = qryZugeteilt.CanUpdate;
            btnAddAll.Enabled = qryZugeteilt.CanUpdate;
            btnRemove.Enabled = qryZugeteilt.CanUpdate;
            btnRemoveAll.Enabled = qryZugeteilt.CanUpdate;
            grdZugeteilt.GridStyle = qryZugeteilt.CanUpdate ? GridStyleType.Editable : GridStyleType.ReadOnly;

            // controls on Personaldaten-tpg
            bool personaldatenWerteAendern = qryUser.CanUpdate && (isAdmin || (_isManualMode && hasSpecialRightHS)); // can only modify personal-data of user if update is allowed and user is admin or manual edit is active
            edtPersonaldatenEintritt.EditMode = editModeEML;
            edtPersonaldatenAustritt.EditMode = editModeEML;
            edtPersonaldatenStdKST.EditMode = EditModeType.ReadOnly; // always locked
            edtPersonaldatenStdKA.EditMode = editModeHS;
            edtPersonaldatenStdKTR.EditMode = editModeHS;
            edtPersonaldatenWeitereKTR.EditMode = personaldatenWerteAendern ? EditModeType.Normal : EditModeType.ReadOnly;
            edtPersonaldatenLohntyp.EditMode = editModeHS;
            btnPersonaldatenWerteAendern.Enabled = personaldatenWerteAendern;
            edtKeinExport.EditMode = editModeHS;

            // Stundenansatz
            edtStundenansatz1.EditMode = editModeHS;
            edtStundenansatz2.EditMode = editModeHS;
            edtStundenansatz3.EditMode = editModeHS;
            edtStundenansatz4.EditMode = editModeHS;
            edtStundenansatz5.EditMode = editModeHS;
            edtStundenansatz6.EditMode = editModeHS;
            edtStundenansatz7.EditMode = editModeHS;
            edtStundenansatz8.EditMode = editModeHS;
            edtStundenansatz9.EditMode = editModeHS;
            edtStundenansatz10.EditMode = editModeHS;
            edtStundenansatz11.EditMode = editModeHS;
            edtStundenansatz12.EditMode = editModeHS;
            edtStundenansatz13.EditMode = editModeHS;
            edtStundenansatz14.EditMode = editModeHS;
            edtStundenansatz15.EditMode = editModeHS;
            edtStundenansatz16.EditMode = editModeHS;
            edtStundenansatz17.EditMode = editModeHS;
            edtStundenansatz18.EditMode = editModeHS;
            edtStundenansatz19.EditMode = editModeHS;
            edtStundenansatz20.EditMode = editModeHS;

            //controls on tpgBaAdresse
            bool hasSpecialRightADUserAdressdaten = DBUtil.UserHasRight("ADUserAdressdaten");

            edtAdresseZusatz.EditMode = editModeEML;
            edtAdresseStrasse.EditMode = editModeEML;
            edtAdresseStrasse.EditMode = editModeEML;
            edtAdresseHausNr.EditMode = editModeEML;
            edtAdressePostfach.EditMode = editModeEML;
            edtPLZWohnsitz.EditMode = editModeEML;
            edtXUserPhonePrivat.EditMode = editModeEML;
            edtXUserPhoneGesch.EditMode = editModeEML;
            edtXUSerPhoneMobile.EditMode = editModeEML;
            edtXUserFax.EditMode = editModeEML;
            edtXUserEmail.EditMode = editModeEML;

            // show tab 'Arbeitszeit' only if Modul 'Vormundschaft' is licensed
            tpgArbeitszeit.Visible = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT Licensed
                FROM dbo.XModul WITH (READUNCOMMITTED)
                WHERE ModulID = {0}
                  AND ShortName = 'V'",
                (int)ModulID.V) as bool? ?? false;

            #endregion

            #region EnableBoundFields

            qryUser.EnableBoundFields();
            qryAbteilung.EnableBoundFields();
            qryBDEData.EnableBoundFields();
            qryBDESollProJahr.EnableBoundFields();
            qryUserRight.EnableBoundFields();
            qryVerfuegbar.EnableBoundFields();
            qryZugeteilt.EnableBoundFields();
            qryBaAdresse.EnableBoundFields();

            #endregion

            // show tpgBaAdresse only if user has specialrights
            if (!hasSpecialRightADUserAdressdaten)
            {
                // tpgBaAdresse.Visible = false;
                //tpgBaAdress.Hide();
                this.tabUser.TabPages.Remove(this.tpgBaAdresse);
            }

            // logging
            _logger.DebugFormat(
                "qryUser.CanInsert='{0}', qryUser.CanUpdate='{1}', qryUser.CanDelete='{2}', edtLastName.EditMode='{3}'",
                qryUser.CanInsert,
                qryUser.CanUpdate,
                qryUser.CanDelete,
                edtLastName.EditMode);
            _logger.Debug("done");
        }

        private void UpdateUebersichtLabel(KissLabel lbl, object dbValue, string appendix, bool showTwoCommaNulls, bool canBeNegative)
        {
            // vars
            string caption = "-"; // init caption with default value (unnkown state)
            double fieldValue = 0.0; // inti with zero value

            // validate first
            if (!DBUtil.IsEmpty(dbValue) && (canBeNegative || Convert.ToDouble(dbValue) >= 0))
            {
                // set field value
                fieldValue = Convert.ToDouble(dbValue);

                // value is ok, return proper formated string
                if (showTwoCommaNulls)
                {
                    caption = string.Format("{0:0.00} {1}", fieldValue, appendix);
                }
                else
                {
                    caption = string.Format("{0} {1}", Math.Round(fieldValue, 2), appendix);
                }
            }

            // apply caption
            lbl.Text = caption;

            // apply color if negative is possible
            if (canBeNegative && fieldValue < 0.0)
            {
                // negative values are red
                lbl.ForeColor = Color.Red;
            }
            else
            {
                // field is black (default)
                lbl.ForeColor = SystemColors.ControlText;
            }
        }

        private void ValidateStundenansatz(KissCalcEdit edit)
        {
            if (Utils.ConvertToDecimal(edit.EditValue) < 0)
            {
                edit.Focus();
                KissMsg.ShowError(Name, "InvalidStundensatzValue", "Der Stundenansatz kann nicht negativ sein.");
                throw new KissCancelException();
            }
        }

        #endregion

        #endregion
    }
}