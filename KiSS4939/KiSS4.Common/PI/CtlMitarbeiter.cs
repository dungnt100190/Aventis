using System;
using System.ComponentModel;
using System.Data;
using System.Text;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Control, used for managing users in BW/ED
    /// </summary>
    public partial class CtlMitarbeiter : KissSearchUserControl
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private int? _defaultSearchModule; // store the default search module (only if restricted rights)
        private bool _hasBwRights;
        private bool _hasEdRights;
        private bool _hasInterviewerChanged;
        private bool _hasMitarbeiterChanged;
        private bool _isCurrentBwMember;
        private bool _isCurrentEdMember;
        private bool _isRefreshingAfterPostOfCourse; // flag if currently refreshing main data after post of courses-query
        private DataRowState _rowState = DataRowState.Unchanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlMitarbeiter"/> class.
        /// </summary>
        public CtlMitarbeiter()
        {
            // logging
            _logger.Debug("enter");

            // init control
            InitializeComponent();

            // apply lov-filters
            BaUtils.ApplyLOVBaLand(edtZusatzdatenNationalitaet);
            BaUtils.ApplyLOVBaLand(edtGrunddatenAdresseLand);

            // setup rights (do before init!)
            SetupRights();

            // init GUI
            Init();

            // logging
            _logger.Debug("done");
        }

        public void FillEdKurs()
        {
            // logging
            _logger.Debug("enter");

            // init controls
            edtWeiterbildungKurs.Properties.DataSource = null;

            // get data from EdKurs table
            SqlQuery qryEdKurs = DBUtil.OpenSQL(@"
                DECLARE @UserID INT
                DECLARE @LanguageCode INT

                SET @UserID = {0}
                SET @LanguageCode = {1}

                -- get empty row
                SELECT [Code] = NULL,
                       [Text] = ''

                UNION

                -- get courses of current user-kgs
                SELECT [Code] = EDK.EdKursID,
                       [Text] = dbo.fnGetMLTextByDefault(EDK.BezeichnungTID, @LanguageCode, EDK.Bezeichnung) + ISNULL(' (' + ORG.ItemName + ')', '')
                FROM dbo.EdKurs EDK WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMItTED) ON ORG.OrgUnitID = EDK.OrgUnitID
                WHERE (EDK.OrgUnitID IS NULL OR EDK.OrgUnitID IN (SELECT SUB.Code
                                                                  FROM dbo.fnGetAllKGSOfUser(@UserID, 0, 0) SUB))
                ORDER BY [Text], [Code]", Session.User.UserID, Session.User.LanguageCode);

            // setup edtKGS
            edtWeiterbildungKurs.LoadQuery(qryEdKurs);
            edtWeiterbildungKurs.Properties.DropDownRows = Math.Min(qryEdKurs.Count, 7);

            // logging
            _logger.Debug("done");
        }

        public override Object GetContextValue(string fieldName)
        {
            // logging
            _logger.Debug("call");

            switch (fieldName.ToUpper())
            {
                case "EDMITARBEITERID":
                    // check if we have any data
                    if (qryEdMitarbeiter.Count < 1)
                    {
                        // no data, return invalid id
                        return "-1";
                    }

                    // return id of current row
                    return qryEdMitarbeiter["EDMitarbeiterID"];

                case "EDMITARBEITERKURSIDLIST":
                    // check if we have any data
                    if (qryEdMitarbeiterKurs.Count < 1)
                    {
                        return "-1";
                    }

                    StringBuilder sb = new StringBuilder();

                    foreach (DataRow row in qryEdMitarbeiterKurs.DataTable.Rows)
                    {
                        sb.Append(row["EdMitarbeiter_KursID"]);
                        sb.Append(",");
                    }

                    sb.Remove(sb.Length - 1, 1);
                    return sb.ToString();
            }

            return base.GetContextValue(fieldName);
        }

        public void Init()
        {
            // logging
            _logger.Debug("enter");

            // reset flags
            _hasMitarbeiterChanged = false;
            _hasInterviewerChanged = false;

            // fill dropdown for courses
            FillEdKurs();

            // logging
            _logger.Debug("done");
        }

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // logging
            _logger.Debug("call");

            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "LoadEdMitarbeiter":
                    if (!param.Contains("EdMitarbeiterID"))
                    {
                        param["EdMitarbeiterID"] = -1;
                    }

                    // try to save pending changes
                    if (!OnSaveData())
                    {
                        // show error, save failed
                        KissMsg.ShowError(Name, "CouldNotJumpToEntry", "Es ist ein Fehler beim Speichern der angezeigten Daten aufgetreten. Auf den gewünschten Datensatz kann nicht gesprungen werden.");

                        // cancel
                        return false;
                    }

                    // try to localize desired data
                    if (!qryEdMitarbeiter.Find(string.Format("EdMitarbeiterID = {0}", param["EdMitarbeiterID"])))
                    {
                        // show info due to failure
                        KissMsg.ShowInfo(Name, "ReceiveMessageEdMitarbeiterNotFound_v02", "Der gewünschte Eintrag konnte nicht gefunden werden, da dieser möglicherweise inaktiv ist. Bitte suchen Sie den/die Mitarbeiter/in manuell.");

                        // failed
                        return false;
                    }

                    // done
                    return true;
            }

            // did not understand message
            return false;
        }

        public override void Translate()
        {
            // logging
            _logger.Debug("enter");

            // apply translation
            base.Translate();

            // do sorting of LOVs
            edtGrunddatenAdresseLand.SortByFirstColumn();
            edtZusatzdatenNationalitaet.SortByFirstColumn();

            // logging
            _logger.Debug("done");
        }

        protected override void NewSearch()
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("ActiveSQLQuery.TableName='{0}'", ActiveSQLQuery.TableName);

            // select tpgGrunddaten (due to ActiveSQLQuery)
            SelectTpgGrunddaten();

            // let base do stuff
            base.NewSearch();

            // set default search values
            edtSucheNurAktive.Checked = true;

            // set default search (if defined)
            if (_defaultSearchModule.HasValue)
            {
                // apply default search value and lock control
                edtSucheModul.EditValue = _defaultSearchModule.Value;
                edtSucheModul.EditMode = EditModeType.ReadOnly;
            }

            // set focus
            edtSucheName.Focus();

            // logging
            _logger.Debug("done");
        }

        protected override void RunSearch()
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("ActiveSQLQuery.TableName='{0}'", ActiveSQLQuery.TableName);

            // replace search parameters
            object[] parameters = { Session.User.LanguageCode, Session.User.UserID };
            kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();

            // logging
            _logger.Debug("base.RunSearch was called");
            _logger.Debug("done");
        }

        private static void UpdateModuleDependency(int modulID, int edMitarbeiterID, KissCheckEdit edtModuleMembership, bool currentMembership, bool isActive, string typCodes)
        {
            string creatorModifier = DBUtil.GetDBRowCreatorModifier();

            // Do insert / delete if status has changed
            if (edtModuleMembership.Checked != currentMembership)
            {
                if (edtModuleMembership.Checked)
                {
                    // Do INSERT on EdMitarbeiter_XModul for module
                    DBUtil.ExecSQLThrowingException(@"
                        INSERT INTO dbo.EdMitarbeiter_XModul (EdMitarbeiterID, XModulID, IstAktiv, ModulTypCodes, Creator, Modifier)
                        VALUES ({0}, {1}, {2}, {3}, {4}, {5})", edMitarbeiterID,
                                                                modulID,
                                                                isActive,
                                                                typCodes,
                                                                creatorModifier,
                                                                creatorModifier);
                }
                else
                {
                    // Do DELETE on EdMitarbeiter_XModul for module
                    DBUtil.ExecSQLThrowingException(@"
                        DELETE FROM dbo.EdMitarbeiter_XModul
                        WHERE EdMitarbeiterID = {0}
                          AND XModulID = {1}", edMitarbeiterID, modulID);
                }
            }
            else if (edtModuleMembership.Checked)
            {
                // update current existing entry
                DBUtil.ExecSQLThrowingException(@"
                    UPDATE EMX
                    SET EMX.IstAktiv      = {0},
                        EMX.ModulTypCodes = {1},
                        EMX.Modifier      = {2},
                        EMX.Modified      = {3}
                    FROM dbo.EdMitarbeiter_XModul EMX
                    WHERE EMX.EdMitarbeiterID = {4}
                      AND EMX.XModulID = {5}", isActive,
                                               typCodes,
                                               creatorModifier,
                                               DateTime.Now,
                                               edMitarbeiterID,
                                               modulID);
            }
        }

        private void btnVerfuegbarkeit_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("call");

            // check if call is valid
            if (qryEdMitarbeiter.Count < 1 || DBUtil.IsEmpty(qryEdMitarbeiter["EdMitarbeiterID"]))
            {
                // do nothing
                return;
            }

            // jump to selected EdMitarbeiterID
            FormController.SendMessage(FrmMitarbeiterverwaltung.FormControllerTarget_Mitarbeiterverwaltung,
                                       "Action", CtlMitarbeiterverwaltung.FormControllerAction_JumpToVerfuegbarkeit,
                                       "EdMitarbeiterID", qryEdMitarbeiter["EdMitarbeiterID"]);
        }

        private void CtlMitarbeiter_Load(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // start a new search
            NewSearch();
            tabControlSearch.SelectTab(tpgListe);

            // show first tab for details
            tabMitarbeiter.SelectTab(tpgGrunddaten);

            // logging
            _logger.Debug("done");
        }

        private bool DialogInterviewer(object sender, UserModifiedFldEventArgs e, KissButtonEdit edt)
        {
            // logging
            _logger.Debug("call");

            try
            {
                // check if data can be altered
                if (edt.EditMode == EditModeType.ReadOnly || !qryEdMitarbeiter.CanUpdate)
                {
                    // do nothing
                    return true;
                }

                // validate edt
                if (edt != edtInterviewInterviewer)
                {
                    // do nothing
                    return false;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edt.EditValue))
                {
                    // prepare for database search
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        // clear appropriate fields in qryMitarbeiter
                        qryEdMitarbeiter["UserIDInterview"] = DBNull.Value;
                        qryEdMitarbeiter["NameVornameInterviewer"] = DBNull.Value;

                        return true;
                    }
                }

                // search user (only within KGS and those who are not yet in use within EdMitarbeiter)
                KissLookupDialog dlg = new KissLookupDialog();

                _logger.Debug("enter");

                e.Cancel = !dlg.SearchData(String.Format(@"
                    SELECT USR.*
                    FROM dbo.fnDlgMitarbeiterSuchenKGS({0}) USR
                    WHERE USR.Name LIKE ({1} + '%')", Session.User.UserID, DBUtil.SqlLiteral(searchString)), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // sets appropriate fields in qryEdMitarbeiter
                    qryEdMitarbeiter["UserIDInterview"] = dlg["UserID$"];
                    qryEdMitarbeiter["NameVornameInterviewer"] = dlg["Name"];

                    // reset flags
                    _hasInterviewerChanged = false;

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorIKissUserModified_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        private bool DialogMitarbeiter(object sender, UserModifiedFldEventArgs e, KissButtonEdit edt)
        {
            // logging
            _logger.Debug("call");

            try
            {
                // check if data can be altered
                if (edt.EditMode == EditModeType.ReadOnly || !qryEdMitarbeiter.CanUpdate)
                {
                    // do nothing
                    return true;
                }

                // validate edt
                if (edt != edtGrunddatenName)
                {
                    // do nothing
                    return false;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edt.EditValue))
                {
                    // prepare for database search
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        // user
                        qryEdMitarbeiter["UserID"] = DBNull.Value;

                        // for display only
                        qryEdMitarbeiter["NameVorname"] = DBNull.Value;
                        qryEdMitarbeiter["MitarbeiterNr"] = DBNull.Value;
                        qryEdMitarbeiter["Eintrittsdatum"] = DBNull.Value;
                        qryEdMitarbeiter["Austrittsdatum"] = DBNull.Value;
                        qryEdMitarbeiter["Geburtstag"] = DBNull.Value;
                        qryEdMitarbeiter["GenderCode"] = DBNull.Value;
                        qryEdMitarbeiter["Email"] = DBNull.Value;
                        qryEdMitarbeiter["Telefon"] = DBNull.Value;
                        qryEdMitarbeiter["Fax"] = DBNull.Value;
                        qryEdMitarbeiter["PhoneMobile"] = DBNull.Value;
                        qryEdMitarbeiter["LanguageCode"] = DBNull.Value;

                        qryEdMitarbeiter["Zusatz"] = DBNull.Value;
                        qryEdMitarbeiter["Strasse"] = DBNull.Value;
                        qryEdMitarbeiter["HausNr"] = DBNull.Value;
                        qryEdMitarbeiter["Postfach"] = DBNull.Value;
                        qryEdMitarbeiter["PostfachOhneNr"] = DBNull.Value;
                        qryEdMitarbeiter["PLZ"] = DBNull.Value;
                        qryEdMitarbeiter["Ort"] = DBNull.Value;
                        qryEdMitarbeiter["OrtschaftCode"] = DBNull.Value;
                        qryEdMitarbeiter["Kanton"] = DBNull.Value;
                        qryEdMitarbeiter["Bezirk"] = DBNull.Value;
                        qryEdMitarbeiter["BaLandID"] = DBNull.Value;
                        return true;
                    }
                }

                // get current id (if any)
                int currentEdMitarbeiterID = DBUtil.IsEmpty(qryEdMitarbeiter["EdMitarbeiterID"]) ? -1 : Convert.ToInt32(qryEdMitarbeiter["EdMitarbeiterID"]);

                // search user (only within KGS and those who are not yet in use within EdMitarbeiter)
                KissLookupDialog dlg = new KissLookupDialog();

                // logging
                _logger.Debug("enter mitarbeiterdialog");

                // display dialog
                e.Cancel = !dlg.SearchData(String.Format(@"
                    SELECT USR.*,
                           -- hidden additional
                           MitarbeiterNr$  = XUS.MitarbeiterNr,
                           Eintrittsdatum$ = XUS.Eintrittsdatum,
                           Austrittsdatum$ = XUS.Austrittsdatum,
                           GenderCode$     = XUS.GenderCode,
                           Email$          = XUS.Email,
                           Telefon$        = dbo.fnEdGetEntlasterKontakt(XUS.UserID, 1, 0, {3}), -- phone number depending on priority
                           PhoneMobile$    = XUS.PhoneMobile,
                           Fax$            = XUS.Fax,
                           Geburtstag$     = XUS.Geburtstag,
                           LanguageCode$   = XUS.LanguageCode,
                            -- data from BaAdresse
                           Zusatz$         = ADR.Zusatz,
                           Strasse$        = ADR.Strasse,
                           HausNr$         = ADR.HausNr,
                           Postfach$       = ADR.Postfach,
                           PostfachOhneNr$ = ADR.PostfachOhneNr,
                           PLZ$            = ADR.PLZ,
                           Ort$            = ADR.Ort,
                           OrtschaftCode$  = ADR.OrtschaftCode,
                           Kanton$         = ADR.Kanton,
                           Bezirk$         = ADR.Bezirk,
                           BaLandID$       = ADR.BaLandID

                    FROM dbo.fnDlgMitarbeiterSuchenKGS({0}) USR
                      INNER JOIN dbo.XUser XUS WITH (READUNCOMMITTED) ON USR.UserID$ = XUS.UserID
                      LEFT  JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.UserID = USR.UserID$
                    WHERE (USR.Name LIKE {1} OR USR.Kürzel LIKE {1} OR USR.UserID$ LIKE {1}) AND
                          NOT EXISTS(SELECT TOP 1 1
                                     FROM dbo.EdMitarbeiter EDM WITH (READUNCOMMITTED)
                                     WHERE EDM.EdMitarbeiterID <> {2} AND
                                           EDM.UserID = USR.UserID$)", Session.User.UserID,
                                                                       DBUtil.SqlLiteral(searchString + "%"),
                                                                       currentEdMitarbeiterID,
                                                                       Session.User.LanguageCode), searchString,
                                                                                                   e.ButtonClicked,
                                                                                                   null,
                                                                                                   null,
                                                                                                   null);

                if (!e.Cancel)
                {
                    // sets apropriate fields in qryEdMitarbeiter
                    qryEdMitarbeiter["UserID"] = dlg["UserID$"];

                    // for display only
                    qryEdMitarbeiter["NameVorname"] = dlg["Name"];
                    qryEdMitarbeiter["MitarbeiterNr"] = dlg["MitarbeiterNr$"];
                    qryEdMitarbeiter["Eintrittsdatum"] = dlg["Eintrittsdatum$"];
                    qryEdMitarbeiter["Austrittsdatum"] = dlg["Austrittsdatum$"];
                    qryEdMitarbeiter["Geburtstag"] = dlg["Geburtstag$"];
                    qryEdMitarbeiter["GenderCode"] = dlg["GenderCode$"];
                    qryEdMitarbeiter["Email"] = dlg["Email$"];
                    qryEdMitarbeiter["Telefon"] = dlg["Telefon$"];
                    qryEdMitarbeiter["Fax"] = dlg["Fax$"];
                    qryEdMitarbeiter["PhoneMobile"] = dlg["PhoneMobile$"];
                    qryEdMitarbeiter["LanguageCode"] = dlg["LanguageCode$"];

                    qryEdMitarbeiter["Zusatz"] = dlg["Zusatz$"];
                    qryEdMitarbeiter["Strasse"] = dlg["Strasse$"];
                    qryEdMitarbeiter["HausNr"] = dlg["HausNr$"];
                    qryEdMitarbeiter["Postfach"] = dlg["Postfach$"];
                    qryEdMitarbeiter["PostfachOhneNr"] = dlg["PostfachOhneNr$"];
                    qryEdMitarbeiter["PLZ"] = dlg["PLZ$"];
                    qryEdMitarbeiter["Ort"] = dlg["Ort$"];
                    qryEdMitarbeiter["OrtschaftCode"] = dlg["OrtschaftCode$"];
                    qryEdMitarbeiter["Kanton"] = dlg["Kanton$"];
                    qryEdMitarbeiter["Bezirk"] = dlg["Bezirk$"];
                    qryEdMitarbeiter["BaLandID"] = dlg["BaLandID$"];

                    // reset flags
                    _hasMitarbeiterChanged = false;

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlMitarbeiter", "ErrorIKissUserModified_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
                return false;
            }
        }

        private void edtGrunddatenIsBwMitarbeiter_CheckedChanged(object sender, EventArgs e)
        {
            SetupGUIDependingOnModules();
        }

        private void edtGrunddatenIsEdMitarbeiter_CheckedChanged(object sender, EventArgs e)
        {
            SetupGUIDependingOnModules();
        }

        private void edtGrunddatenName_EditValueChanged(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // data has changed
            _hasMitarbeiterChanged = true;

            // logging
            _logger.Debug("done");
        }

        private void edtGrunddatenName_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // select user
            e.Cancel = !DialogMitarbeiter(sender, e, edtGrunddatenName);

            // logging
            _logger.Debug("done");
        }

        private void edtInterviewInterviewer_EditValueChanged(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // data has changed
            _hasInterviewerChanged = true;

            // logging
            _logger.Debug("done");
        }

        private void edtInterviewInterviewer_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // select interviewer-user
            e.Cancel = !DialogInterviewer(sender, e, edtInterviewInterviewer);

            // logging
            _logger.Debug("done");
        }

        private void EnableDisableTpgWeiterbildung()
        {
            // do not disable by default
            EnableDisableTpgWeiterbildung(false);
        }

        private void EnableDisableTpgWeiterbildung(bool disableAnyway)
        {
            // check if disable without any check
            if (disableAnyway)
            {
                // disable
                tpgWeiterbildung.Enabled = false;

                // done
                return;
            }

            // enable or disable tpg Weiterbildung
            tpgWeiterbildung.Enabled = qryEdMitarbeiter.Count > 0 && !DBUtil.IsEmpty(qryEdMitarbeiter["EdMitarbeiterID"]);
        }

        private void FillEdMitarbeiterKurs()
        {
            // logging
            _logger.Debug("enter");

            // get current id
            int edMitarbeiterID = DBUtil.IsEmpty(qryEdMitarbeiter["EdMitarbeiterID"]) ? -1 : Convert.ToInt32(qryEdMitarbeiter["EdMitarbeiterID"]);

            // logging
            _logger.DebugFormat("edMitarbeiterID='{0}', LanguageCode='{1}'", edMitarbeiterID, Session.User.LanguageCode);

            // get courses-data for EdMitarbeiterID
            qryEdMitarbeiterKurs.Fill(edMitarbeiterID, Session.User.LanguageCode);

            // logging
            _logger.Debug("done");
        }

        private void qryEdMitarbeiter_AfterDelete(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // do nothing if no transaction
            if (Session.Transaction != null)
            {
                try
                {
                    // commit
                    Session.Commit();
                }
                catch (Exception ex)
                {
                    // rollback
                    Session.Rollback();

                    // show error
                    KissMsg.ShowError(Name, "FailedAfterDeletePendingData", "Es ist ein schwerer Ausnahmefehler aufgetreten. Die Daten konnten nicht gelöscht werden.", ex);
                }
            }

            // if no more data disable tab
            if (qryEdMitarbeiter.Count == 0)
            {
                qryEdMitarbeiter_PositionChanged(sender, e);
            }

            // logging
            _logger.Debug("done");
        }

        private void qryEdMitarbeiter_AfterFill(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // select last row
            qryEdMitarbeiter.Last();

            // falls keine Daten mehr vorhanden sind, Tab Weiterbildung sperren
            if (qryEdMitarbeiter.Count == 0)
            {
                qryEdMitarbeiter_PositionChanged(sender, e);
            }

            // logging
            _logger.Debug("done");
        }

        private void qryEdMitarbeiter_AfterInsert(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // set default vlaues
            qryEdMitarbeiter.SetCreator();

            // select first tab and set focus
            tabMitarbeiter.SelectedTabIndex = 0;
            edtGrunddatenName.Focus();

            // logging
            _logger.Debug("done");
        }

        private void qryEdMitarbeiter_AfterPost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // check if we have a transaction
            if (Session.Transaction != null)
            {
                try
                {
                    // fill edverfuegbarkeit, edVerfuegbarkeit_tag
                    if (_rowState == DataRowState.Added)
                    {
                        // insert pending data into database
                        DBUtil.ExecSQLThrowingException(@"EXEC dbo.spEdVerfuegbarkeit_Create {0}, {1} ", qryEdMitarbeiter["EdMitarbeiterID"], Session.User.UserID);

                        // reset state because of security
                        _rowState = DataRowState.Unchanged;
                    }

                    // update bw/ed
                    UpdateModuleDependency(BaUtils.ModulIDCode(BaUtils.ModulID.BegleitetesWohnen),
                                           Convert.ToInt32(qryEdMitarbeiter["EdMitarbeiterID"]),
                                           edtGrunddatenIsBwMitarbeiter,
                                           _isCurrentBwMember,
                                           edtGrunddatenBwAktiv.Checked,
                                           edtGrunddatenTypBW.EditValue);

                    // update bw/ed
                    UpdateModuleDependency(BaUtils.ModulIDCode(BaUtils.ModulID.EntlastungsDienst),
                                           Convert.ToInt32(qryEdMitarbeiter["EdMitarbeiterID"]),
                                           edtGrunddatenIsEdMitarbeiter,
                                           _isCurrentEdMember,
                                           edtGrunddatenEdAktiv.Checked,
                                           edtGrunddatenTypED.EditValue);

                    // commit
                    Session.Commit();
                }
                catch (Exception ex)
                {
                    //rollback
                    Session.Rollback();

                    // logging
                    _logger.Debug("rollback");

                    // show error
                    KissMsg.ShowError(Name, "FailedAfterPostInsertingPendingData", "Es ist ein schwerer Ausnahmefehler aufgetreten. Die Daten konnten nicht gespeichert werden.", ex);

                    // logging into XLog
                    XLog.Create(GetType().FullName, LogLevel.ERROR, "Could not save data in Mitarbeiterverwaltung.", ex.Message);
                }
            }

            // enable or disable tpg Weiterbildung
            EnableDisableTpgWeiterbildung();

            // logging
            _logger.Debug("done");
        }

        private void qryEdMitarbeiter_BeforeDelete(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // start transaction
            Session.BeginTransaction();

            try
            {
                // delete pending data
                DBUtil.ExecSQLThrowingException(@"EXEC dbo.spEdVerfuegbarkeit_Delete {0} ", qryEdMitarbeiter["EdMitarbeiterID"]);
            }
            catch (Exception ex)
            {
                // rollback
                Session.Rollback();

                // logging
                _logger.Debug("rollback");

                // entry cannot be deleted because of usage
                KissMsg.ShowError(Name, "CannotDeleteEntry", "Es ist ein Fehler beim Löschen der zugehörigen Daten aufgetreten. Der Datensatz kann nicht entfernt werden.", ex);

                // cancel
                throw new KissCancelException();
            }

            // logging
            _logger.Debug("done");
        }

        private void qryEdMitarbeiter_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // set member variable rowstate (used in AfterPost)
            _rowState = qryEdMitarbeiter.Row.RowState;

            // check empty fields
            DBUtil.CheckNotNullField(edtGrunddatenName, lblGrunddatenName.Text);

            // validate membership
            if (!edtGrunddatenIsBwMitarbeiter.Checked && !edtGrunddatenIsEdMitarbeiter.Checked)
            {
                // show message
                KissMsg.ShowInfo(Name, "FehlerKeinModulAusgewaehlt", "Der/die Mitarbeiter/in hat keine Modulzugehörigkeit. Wählen Sie ein Modul für den/die Mitarbeiter/in.");

                // focus
                edtGrunddatenIsBwMitarbeiter.Focus();

                // cancel
                throw new KissCancelException();
            }

            // validate types
            if (edtGrunddatenIsBwMitarbeiter.Checked)
            {
                // type BW is required if MA of BW
                DBUtil.CheckNotNullField(edtGrunddatenTypBW, grpGrunddatenTypBW.Text);
            }

            if (edtGrunddatenIsEdMitarbeiter.Checked)
            {
                // type ED is required if MA of ED
                DBUtil.CheckNotNullField(edtGrunddatenTypED, grpGrunddatenTypED.Text);
            }

            if (!edtVersichertennummer.ValidateVersNr(true, false))
            {
                throw new KissCancelException();
            }

            try
            {
                // MITARBEITER:
                // validate buttonedits - user
                if (_hasMitarbeiterChanged && !DialogMitarbeiter(this, new UserModifiedFldEventArgs(false, false), edtGrunddatenName))
                {
                    // invalid value
                    edtGrunddatenName.Focus();
                    throw new KissCancelException();
                }

                // reset flags
                _hasMitarbeiterChanged = false;

                // INTERVIEWER:
                // validate buttonedits - user
                if (_hasInterviewerChanged && !DialogInterviewer(this, new UserModifiedFldEventArgs(false, false), edtInterviewInterviewer))
                {
                    // invalid value
                    edtInterviewInterviewer.Focus();
                    throw new KissCancelException();
                }

                // reset flags
                _hasInterviewerChanged = false;
            }
            catch (KissCancelException)
            {
                // throw exception further on
                throw;
            }
            catch (Exception ex)
            {
                // logging
                _logger.Debug("error in BeforePost()");

                // show error
                KissMsg.ShowError(Name, "FailedBeforePostInsertingPendingData", "Es ist ein Fehler aufgetreten. Die Daten konnten nicht gespeichert werden.", ex);

                // cancel
                throw new KissCancelException();
            }

            // logging
            _logger.Debug("done, starting transaction");

            // start transaction
            Session.BeginTransaction();
        }

        private void qryEdMitarbeiter_PositionChanged(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("_isRefreshingAfterPostOfCourse='{0}'", _isRefreshingAfterPostOfCourse);

            // check if need to do stuff
            if (!_isRefreshingAfterPostOfCourse)
            {
                // enable or disable tpg Weiterbildung
                EnableDisableTpgWeiterbildung();

                // get courses-data for EdMitarbeiterID
                FillEdMitarbeiterKurs();
            }

            SetMembershipFlags();
            SetupGUIDependingOnModules();

            /*
            edtGrunddatenEdAktiv.EditMode = _isCurrentEdMember ? EditModeType.Normal : EditModeType.ReadOnly;
            edtGrunddatenBwAktiv.EditMode = _isCurrentBwMember ? EditModeType.Normal : EditModeType.ReadOnly;

            edtGrunddatenTypED.EditMode = edtGrunddatenIsEdMitarbeiter.Checked ? EditModeType.Normal : EditModeType.ReadOnly;
            edtGrunddatenTypBW.EditMode = edtGrunddatenIsBwMitarbeiter.Checked ? EditModeType.Normal : EditModeType.ReadOnly;
            */

            // logging
            _logger.Debug("done");
        }

        private void qryEdMitarbeiter_PostCompleted(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // refresh data after post has completed
            qryEdMitarbeiter.Refresh();

            // update flags
            SetMembershipFlags();

            // logging
            _logger.Debug("done");
        }

        private void qryEdMitarbeiterKurs_AfterInsert(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // set default values
            qryEdMitarbeiterKurs.SetCreator();
            qryEdMitarbeiterKurs["EdMitarbeiterID"] = qryEdMitarbeiter["EdMitarbeiterID"];

            // set focus
            edtWeiterbildungKurs.Focus();

            // logging
            _logger.Debug("done");
        }

        private void qryEdMitarbeiterKurs_AfterPost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // refresh column in grid
            qryEdMitarbeiterKurs["MLBezeichnung"] = edtWeiterbildungKurs.Text;

            // logging
            _logger.Debug("done");
        }

        private void qryEdMitarbeiterKurs_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // check if we have a valid EdMitarbeiterID
            if (DBUtil.IsEmpty(qryEdMitarbeiterKurs["EdMitarbeiterID"]))
            {
                // show error
                KissMsg.ShowError(Name, "ErrorNoEdMitarbeiterID", "Es ist kein Wert für EdMitarbeiterID definiert, der Datensatz kann nicht gespeichert werden.");

                // cancel
                throw new KissCancelException();
            }

            // check must fields
            DBUtil.CheckNotNullField(edtWeiterbildungKurs, lblWeiterbildungKurs.Text);

            // set modifier/modified
            qryEdMitarbeiterKurs.SetModifierModified();

            // logging
            _logger.Debug("done");
        }

        private void qryEdMitarbeiterKurs_PostCompleted(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            try
            {
                // set flag
                _isRefreshingAfterPostOfCourse = true;

                // refresh main query (maybe a performance problem?)
                qryEdMitarbeiter.Refresh();
            }
            finally
            {
                // reset flag
                _isRefreshingAfterPostOfCourse = false;
            }

            // logging
            _logger.Debug("done");
        }

        private void SelectTpgGrunddaten()
        {
            // select tpgGrunddaten only if tpgWeiterbildung is selected
            if (tabMitarbeiter.IsTabSelected(tpgWeiterbildung))
            {
                // select first tpg
                tabMitarbeiter.SelectTab(tpgGrunddaten);

                // let it do
                ApplicationFacade.DoEvents();
            }
        }

        private void SetMembershipFlags()
        {
            _isCurrentBwMember = DBUtil.IsEmpty(qryEdMitarbeiter["IsBwMitarbeiter"]) ? false : Convert.ToBoolean(qryEdMitarbeiter["IsBwMitarbeiter"]);
            _isCurrentEdMember = DBUtil.IsEmpty(qryEdMitarbeiter["IsEdMitarbeiter"]) ? false : Convert.ToBoolean(qryEdMitarbeiter["IsEdMitarbeiter"]);
        }

        private void SetupGUIDependingOnModules()
        {
            // get flags
            bool isBWMember = edtGrunddatenIsBwMitarbeiter.Checked;
            bool isEDMember = edtGrunddatenIsEdMitarbeiter.Checked;

            // BW
            edtGrunddatenBwAktiv.Checked = isBWMember ? edtGrunddatenBwAktiv.Checked : false;   // uncheck active if not member
            edtGrunddatenBwAktiv.EditMode = isBWMember ? EditModeType.Normal : EditModeType.ReadOnly;
            edtGrunddatenTypBW.EditMode = isBWMember ? EditModeType.Normal : EditModeType.ReadOnly;

            // ED
            edtGrunddatenEdAktiv.Checked = isEDMember ? edtGrunddatenEdAktiv.Checked : false;   // uncheck active if not member
            edtGrunddatenEdAktiv.EditMode = isEDMember ? EditModeType.Normal : EditModeType.ReadOnly;
            edtGrunddatenTypED.EditMode = isEDMember ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        private void SetupRights()
        {
            // logging
            _logger.Debug("enter");

            // reset vars
            _defaultSearchModule = null;

            // VARS
            bool isAdmin = Session.User.IsUserAdmin;
            bool canReadData;
            bool canUserInsert;
            bool canUserUpdate;
            bool canUserDelete;

            // set values
            Session.GetUserRight(Name, out canReadData, out canUserInsert, out canUserUpdate, out canUserDelete);

            if (!canReadData)
            {
                // no rights to view this control
                throw new UnauthorizedAccessException("No rights to view details of this control (no read permission).");
            }

            // get special rights
            _hasBwRights = DBUtil.UserHasRight("VerwaltungBW");
            _hasEdRights = DBUtil.UserHasRight("VerwaltungED");

            // logger
            _logger.DebugFormat("isAdmin={0}, canReadData={1}, canUserInsert={2}, canUserUpdate={3}, canUserDelete={4}, _hasBwRights='{5}', _hasEdRights='{6}'",
                                isAdmin, canReadData, canUserInsert, canUserUpdate, canUserDelete, _hasBwRights, _hasEdRights);

            // no rights
            if (!isAdmin && !_hasEdRights && !_hasBwRights)
            {
                // no rights to view this control
                throw new UnauthorizedAccessException("No rights to view details of this control (no BW/ED specialrights).");
            }

            // only BwRights
            if (!isAdmin && !_hasEdRights && _hasBwRights)
            {
                // setup default search module
                _defaultSearchModule = Convert.ToInt32(BaUtils.ModulID.BegleitetesWohnen);

                // setup search-controls
                edtSucheModul.EditValue = _defaultSearchModule.Value;
                edtSucheModul.EditMode = EditModeType.ReadOnly;
                edtSucheTypED.EditMode = EditModeType.ReadOnly;

                // setup columns
                colAktivEd.Visible = false;
                colIsEd.Visible = false;
                colTypED.Visible = false;

                // setup controls
                edtGrunddatenIsEdMitarbeiter.EditMode = EditModeType.ReadOnly;
                edtGrunddatenIsEdMitarbeiter.DataMember = string.Empty;

                edtGrunddatenEdAktiv.EditMode = EditModeType.ReadOnly;
                edtGrunddatenIsEdMitarbeiter.DataMember = string.Empty;

                edtGrunddatenTypED.EditMode = EditModeType.ReadOnly;
                edtGrunddatenTypED.DataMember = string.Empty;
            }
            // only EdRights
            else if (!isAdmin && _hasEdRights && !_hasBwRights)
            {
                // setup default search module
                _defaultSearchModule = Convert.ToInt32(BaUtils.ModulID.EntlastungsDienst);

                // setup search-controls
                edtSucheModul.EditValue = _defaultSearchModule.Value;
                edtSucheModul.EditMode = EditModeType.ReadOnly;
                edtSucheTypBW.EditMode = EditModeType.ReadOnly;

                // setup columns
                colAktivBw.Visible = false;
                colIsBw.Visible = false;
                colTypBW.Visible = false;

                // setup controls
                edtGrunddatenIsBwMitarbeiter.EditMode = EditModeType.ReadOnly;
                edtGrunddatenIsBwMitarbeiter.DataMember = string.Empty;
                edtGrunddatenBwAktiv.EditMode = EditModeType.ReadOnly;
                edtGrunddatenBwAktiv.DataMember = string.Empty;
                edtGrunddatenTypBW.EditMode = EditModeType.ReadOnly;
                edtGrunddatenTypBW.DataMember = string.Empty;
            }

            // EdMitarbeiter
            qryEdMitarbeiter.CanInsert = isAdmin || canUserInsert;
            qryEdMitarbeiter.CanUpdate = isAdmin || canUserUpdate;
            qryEdMitarbeiter.CanDelete = isAdmin || canUserDelete;

            // EdMitarbeiter_Kurs
            qryEdMitarbeiterKurs.CanInsert = isAdmin || canUserInsert;
            qryEdMitarbeiterKurs.CanUpdate = isAdmin || canUserUpdate;
            qryEdMitarbeiterKurs.CanDelete = isAdmin || canUserDelete;

            // FIELDS
            qryEdMitarbeiter.EnableBoundFields();
            qryEdMitarbeiterKurs.EnableBoundFields();

            // logging
            _logger.Debug("done");
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // logging
            _logger.Debug("enter");

            // the current tab is Weiterbildung
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                // logging
                _logger.Debug("the current tab is Suchen");

                // select tpgGrunddaten (due to ActiveSQLQuery)
                SelectTpgGrunddaten();

                // disable weiterbildung
                EnableDisableTpgWeiterbildung(true);
            }
            else
            {
                // enable or disable tpg Weiterbildung
                EnableDisableTpgWeiterbildung();
            }

            // logging
            _logger.Debug("done");
        }

        private void tabControlSearch_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // try to save data, if failure do not change tpg
            e.Cancel = !OnSaveData();

            // logging
            _logger.DebugFormat("e.Cancel={0}", e.Cancel);
            _logger.Debug("done");
        }

        private void tabMitarbeiter_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // logging
            _logger.Debug("enter");

            // save pending changes on current query
            if (!OnSaveData())
            {
                // failed, cancel
                return;
            }

            // the current tab is Weiterbildung
            if (tabMitarbeiter.IsTabSelected(tpgWeiterbildung))
            {
                // logging
                _logger.Debug("the current tab is Weiterbildung");

                // change ActiveQuery
                ActiveSQLQuery = qryEdMitarbeiterKurs;

                // get courses-data for EdMitarbeiterID
                FillEdMitarbeiterKurs();
            }
            else
            {
                // default tpgs
                ActiveSQLQuery = qryEdMitarbeiter;
            }

            // logging
            _logger.Debug("done");
        }

        private void tabMitarbeiter_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // try to save data, if failure do not change tpg
            e.Cancel = !OnSaveData();

            // logging
            _logger.DebugFormat("e.Cancel={0}", e.Cancel);
            _logger.Debug("done");
        }
    }
}