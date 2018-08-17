using System;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Use this control to manage "Begleiter" / "Entlaster" on "Begleitetes Wohnen" and "Entlastungsdienst"
    /// This control is intendet to be hosted by EdEinsatzvereinbarung or BwEinsatzvereinbarung.
    /// </summary>
    public partial class CtlFaBegleiterEntlaster : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private BaUtils.ModulID _accessModul;
        private int _einsatzvereinbarungId;
        private string _einsatzvereinbarungIdColName;
        private bool _hasMitarbeiterChanged;
        private string _queryTableIdColName;
        private string _queryTableName;
        private int _sortKeyBeforeDeleted;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor initializes all components
        /// </summary>
        public CtlFaBegleiterEntlaster()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnDown_Click(object sender, EventArgs e)
        {
            ButtonUpDownMitarbeiter(btnDown);
        }

        private void btnInfoMitarbeiter_Click(object sender, EventArgs e)
        {
            // validate accessing mode here again because of depending implementations in this method
            IsAccessingModuleValid();

            // validate if any data can be displayed
            if (DBUtil.IsEmpty(qryMitarbeiter["UserID"]))
            {
                // no data selected
                KissMsg.ShowInfo(Name, "NoUserSelected", "Es ist kein/e Mitarbeiter/in ausgewählt. Das Anzeigen der Details ist nicht möglich.");
                return;
            }

            // find EdMitarbeiterID of given user
            SqlQuery qryEdMitarbeiter = DBUtil.OpenSQL(@"
                SELECT TOP 1
                       EDM.EdMitarbeiterID
                FROM dbo.EdMitarbeiter                EDM WITH (READUNCOMMITTED)
                  INNER JOIN dbo.EdMitarbeiter_XModul EMX WITH (READUNCOMMITTED) ON EMX.EdMitarbeiterID = EDM.EdMitarbeiterID
                                                                                AND EMX.XModulID = {1}
                WHERE EDM.UserID = {0}", Convert.ToInt32(qryMitarbeiter["UserID"]), Convert.ToInt32(_accessModul));

            // check if call is valid
            if (qryEdMitarbeiter.Count < 1 || DBUtil.IsEmpty(qryEdMitarbeiter["EdMitarbeiterID"]))
            {
                // no data selected, show message depending on given access-mode
                switch (_accessModul)
                {
                    case BaUtils.ModulID.BegleitetesWohnen:
                        // BW message
                        KissMsg.ShowInfo(Name, "NoUserFoundToJumpToBW_v01", "Der/die gewünschte Mitarbeiter/in ist beim Begleiteten Wohnen nicht eingetragen. Das Anzeigen der Details ist nicht möglich.");
                        break;

                    case BaUtils.ModulID.EntlastungsDienst:
                        // ED message
                        KissMsg.ShowInfo(Name, "NoUserFoundToJumpToED_v01", "Der/die gewünschte Mitarbeiter/in ist beim Entlastungsdienst nicht eingetragen. Das Anzeigen der Details ist nicht möglich.");
                        break;
                }

                return;
            }

            // jump to selected user
            FormController.OpenForm(FrmMitarbeiterverwaltung.FormControllerTarget_Mitarbeiterverwaltung,
                                    "Action", CtlMitarbeiterverwaltung.FormControllerAction_JumpToMitarbeiter,
                                    "EdMitarbeiterID", qryEdMitarbeiter["EdMitarbeiterID"]);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ButtonUpDownMitarbeiter(btnUp);
        }

        private void edtMitarbeiter_EditValueChanged(object sender, EventArgs e)
        {
            _hasMitarbeiterChanged = true;
        }

        private void edtMitarbeiter_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogMitarbeiter(sender, e, edtMitarbeiter);
        }

        private void grvXUserEdEinsatzvereinbarung_CustomDrawCell(Object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                // get value
                string showingSortKey = Convert.ToString(grvXUser_Einsatzvereinbarung.GetRowCellValue(e.RowHandle, grvXUser_Einsatzvereinbarung.Columns["ShowingSortKey"]));

                // check value
                if (!DBUtil.IsEmpty(showingSortKey))
                {
                    if (Convert.ToInt32(showingSortKey) > 5)
                    {
                        // only 5 items can be within bookmarks, the others will be displayed slightly different
                        e.Appearance.ForeColor = System.Drawing.Color.FromArgb(0, 30, 80, 120);
                    }
                }
            }
            catch (Exception ex)
            {
                // logging
                _logger.DebugFormat("exception occured while drawing cell.", ex);
            }
        }

        private void qryMitarbeiter_AfterDelete(object sender, EventArgs e)
        {
            // check if we have a last sortkey of before delete
            if (_sortKeyBeforeDeleted > -1)
            {
                // update those with bigger sortkey to sortkey-1 in order to have continuous sortkeys even after delete
                DBUtil.ExecuteScalarSQL(@" --SQLCHECK_IGNORE--
                    UPDATE dbo." + _queryTableName + @"
                    SET SortKey = SortKey - 1
                    WHERE " + _einsatzvereinbarungIdColName + @" = {0} AND
                          SortKey > {1}", _einsatzvereinbarungId, _sortKeyBeforeDeleted);

                // reset sortkey
                _sortKeyBeforeDeleted = -1;

                // refresh data
                qryMitarbeiter.Refresh();
            }
        }

        private void qryMitarbeiter_AfterInsert(object sender, EventArgs e)
        {
            // set default values
            qryMitarbeiter[_einsatzvereinbarungIdColName] = _einsatzvereinbarungId;

            // set creator
            qryMitarbeiter.SetCreator();
        }

        private void qryMitarbeiter_BeforeDelete(object sender, EventArgs e)
        {
            // store this sort key to update others after delete
            _sortKeyBeforeDeleted = Convert.ToInt32(qryMitarbeiter["SortKey"]);
        }

        private void qryMitarbeiter_BeforePost(object sender, EventArgs e)
        {
            // validate EdEinsatzvereinbarungID
            if (_einsatzvereinbarungId < 1 ||
                DBUtil.IsEmpty(qryMitarbeiter[_einsatzvereinbarungIdColName]) ||
                Convert.ToInt32(qryMitarbeiter[_einsatzvereinbarungIdColName]) != _einsatzvereinbarungId)
            {
                // invalid reference, cannot save data
                KissMsg.ShowError(this.Name, "InvalidEinsatzvereinbarungIDOnPost", "Schwerer Ausnahmefehler bei der Referenz-ID, die Daten für Mitarbeiter/in können nicht gespeichert werden.");

                // cancel
                throw new KissCancelException();
            }

            // UserID is must field
            DBUtil.CheckNotNullField(edtMitarbeiter, lblMitarbeiter.Text);

            // validate buttonedits - user
            if (_hasMitarbeiterChanged && !DialogMitarbeiter(this, new UserModifiedFldEventArgs(false, false), edtMitarbeiter))
            {
                // invalid value
                edtMitarbeiter.Focus();

                // cancel
                throw new KissCancelException();
            }

            // reset flags
            ResetMitarbeiterChangedFlags();

            // get last used SortKey for this entry if none applied yet (for new entries)
            if (DBUtil.IsEmpty(qryMitarbeiter["SortKey"]))
            {
                // get next possible one
                qryMitarbeiter["SortKey"] = DBUtil.ExecuteScalarSQLThrowingException(@"
                    DECLARE @NewSortKey INT

                    SELECT @NewSortKey = MAX(UEV.SortKey)
                    FROM dbo." + _queryTableName + @" UEV WITH (READUNCOMMITTED)
                    WHERE UEV." + _einsatzvereinbarungIdColName + @" = {0}

                    SELECT ISNULL(@NewSortKey + 1, 0) -- 0 if none defined yet, otherwise max+1!", _einsatzvereinbarungId);

                // set showing sortkey
                qryMitarbeiter["ShowingSortKey"] = Convert.ToInt32(qryMitarbeiter["SortKey"]) + 1;
            }

            // update modifier/modified
            qryMitarbeiter.SetModifierModified();
        }

        private void qryMitarbeiter_PositionChanged(object sender, EventArgs e)
        {
            ResetMitarbeiterChangedFlags();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initializes the control. Has to be called during initialization of the host control.
        /// </summary>
        /// <param name="accessModul">The module used for accessing the control (only BW and ED are supported by now)</param>
        /// <param name="einsatzvereinbarungID">Id of the current Einsatzvereinbarung</param>
        /// <param name="canInsertUpdateDelete">Controls the CRUD rights of the query</param>
        public void Init(BaUtils.ModulID accessModul, int einsatzvereinbarungID, bool canInsertUpdateDelete)
        {
            // init vars
            string modulTablePrefix;

            // check accessing mode
            switch (accessModul)
            {
                case BaUtils.ModulID.BegleitetesWohnen:
                    modulTablePrefix = "BW";
                    break;

                case BaUtils.ModulID.EntlastungsDienst:
                    modulTablePrefix = "ED";
                    break;

                default:
                    // logging
                    XLog.Create(this.GetType().FullName, LogLevel.INFO, "Requested accessing module is not supported.");

                    // cancel
                    throw new ArgumentOutOfRangeException("accessModul", "The given accessing module is not supported by now.");
            }

            // apply members
            _accessModul = accessModul;
            _queryTableName = string.Format("XUser_{0}Einsatzvereinbarung", modulTablePrefix);
            _queryTableIdColName = string.Format("{0}ID", _queryTableName);
            _einsatzvereinbarungIdColName = string.Format("{0}EinsatzvereinbarungID", modulTablePrefix);
            _einsatzvereinbarungId = einsatzvereinbarungID;

            // apply query
            qryMitarbeiter.TableName = _queryTableName;

            // setup rights depending on main query (main-query can only update!)
            qryMitarbeiter.CanInsert = canInsertUpdateDelete;
            qryMitarbeiter.CanUpdate = canInsertUpdateDelete;
            qryMitarbeiter.CanDelete = canInsertUpdateDelete;

            // setup buttons
            btnUp.Enabled = qryMitarbeiter.CanUpdate;
            btnDown.Enabled = qryMitarbeiter.CanUpdate;

            // fill data depending on current id!
            qryMitarbeiter.Fill(@"   --SQLCHECK_IGNORE--
                SELECT UEV.*,
                       ShowingSortKey     = UEV.SortKey + 1,
                       Mitarbeiter        = dbo.fnGetLastFirstName(UEV.UserID, NULL, NULL),
                       MitarbeiterKontakt = dbo.fnEdGetEntlasterKontakt(UEV.UserID, 1, 1, {1})
                FROM dbo." + _queryTableName + @" UEV WITH (READUNCOMMITTED)
                WHERE UEV." + _einsatzvereinbarungIdColName + @" = {0}
                ORDER BY UEV.SortKey, Mitarbeiter", _einsatzvereinbarungId, Session.User.LanguageCode);

            // insert new entry if not yet any entry found and valid conditions
            if (qryMitarbeiter.CanUpdate && qryMitarbeiter.Count < 1 && _einsatzvereinbarungId > 0)
            {
                // create new entry
                qryMitarbeiter.Insert(null);
            }

            // refresh fields
            qryMitarbeiter.EnableBoundFields();
        }

        /// <summary>
        /// Reset flags for changed user
        /// </summary>
        public void ResetMitarbeiterChangedFlags()
        {
            _hasMitarbeiterChanged = false;
        }

        #endregion

        #region Private Methods

        private void ButtonUpDownMitarbeiter(object sender)
        {
            // check if we have a valid sender
            if (sender != btnUp && sender != btnDown)
            {
                // not excpected sender, do nothing
                return;
            }

            // do it only if update is allowed and we have more than one entry
            if (!qryMitarbeiter.CanUpdate || qryMitarbeiter.Count < 2)
            {
                // locked or not enough data, do nothing
                return;
            }

            // check if button is enabled
            if ((sender == btnUp && btnUp.Enabled == false) ||
                (sender == btnDown && btnDown.Enabled == false))
            {
                // button is disabled, do nothing
                return;
            }

            // save current changes
            if (!qryMitarbeiter.Post())
            {
                // could not save, do nothing
                return;
            }

            try
            {
                // set focus
                grdXUser_Einsatzvereinbarung.Focus();

                // disable buttons
                btnUp.Enabled = false;
                btnDown.Enabled = false;

                SqlQuery qry;

                if (sender == btnUp)
                {
                    // Vorgänger bestimmen
                    qry = DBUtil.OpenSQL(@"  --SQLCHECK_IGNORE--
                        SELECT TOP 1 UEV.*
                        FROM dbo." + _queryTableName + @" UEV
                        WHERE UEV." + _einsatzvereinbarungIdColName + @" = {0} AND
                              UEV.SortKey < {1}
                        ORDER BY UEV.SortKey DESC", _einsatzvereinbarungId, qryMitarbeiter["SortKey"]);
                }
                else
                {
                    // Nachfolger bestimmen
                    qry = DBUtil.OpenSQL(@"    --SQLCHECK_IGNORE--
                        SELECT TOP 1 UEV.*
                        FROM dbo." + _queryTableName + @" UEV
                        WHERE UEV." + _einsatzvereinbarungIdColName + @" = {0} AND
                              UEV.SortKey > {1}
                        ORDER BY UEV.SortKey ASC", _einsatzvereinbarungId, qryMitarbeiter["SortKey"]);
                }

                // nothing found, do nothing
                if (qry.Count == 0)
                {
                    return;
                }

                // switch positions
                DBUtil.ExecSQL(@"   --SQLCHECK_IGNORE--
                    UPDATE dbo." + _queryTableName + @"
                    SET SortKey = {0}
                    WHERE " + _queryTableIdColName + " = {1}", qry["SortKey"], qryMitarbeiter[_queryTableIdColName]);

                DBUtil.ExecSQL(@"   --SQLCHECK_IGNORE--
                    UPDATE dbo." + _queryTableName + @"
                    SET SortKey = {0}
                    WHERE " + _queryTableIdColName + " = {1}", qryMitarbeiter["SortKey"], qry[_queryTableIdColName]);

                // reload data
                qryMitarbeiter.Refresh();
            }
            catch (Exception ex)
            {
                // logging
                XLog.Create(this.GetType().FullName, LogLevel.ERROR, "Exception occured while moving users up/down.", ex.Message);

                // show message
                KissMsg.ShowError(this.Name, "ErrorButtonUpDown", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
            finally
            {
                // enable buttons
                btnUp.Enabled = true;
                btnDown.Enabled = true;
            }
        }

        private bool DialogMitarbeiter(Object sender, UserModifiedFldEventArgs e, KissButtonEdit edt)
        {
            try
            {
                // check if data can be altered
                if (edt.EditMode == EditModeType.ReadOnly || !qryMitarbeiter.CanUpdate)
                {
                    // do nothing
                    return true;
                }

                // validate edt
                if (edt != edtMitarbeiter)
                {
                    // do nothing
                    return false;
                }

                // set query-fields
                string userID = "UserID";                   // written on db
                string userName = "Mitarbeiter";            // only display
                string userContact = "MitarbeiterKontakt";  // only display

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edt.EditValue))
                {
                    // prepare for database search
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
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
                        qryMitarbeiter[userID] = DBNull.Value;
                        qryMitarbeiter[userName] = DBNull.Value;
                        qryMitarbeiter[userContact] = DBNull.Value;

                        return true;
                    }
                }

                // get current id (if any)
                int currentXUserEinsatzvereinbarungID = DBUtil.IsEmpty(qryMitarbeiter[_queryTableName + "ID"]) ? -1 : Convert.ToInt32(qryMitarbeiter[_queryTableName + "ID"]);

                // search user (only within KGS and those who are not yet in use within this Einsatzvereinbarung)
                KissLookupDialog dlg = new KissLookupDialog();

                // showing only users that are within allowed users of KGS and registered as active BW/ED users
                e.Cancel = !dlg.SearchData(string.Format(@"
                    DECLARE @UserID INT
                    DECLARE @SearchString VARCHAR(1000)
                    DECLARE @LanguageCode INT
                    DECLARE @EinsatzvereinbarungID INT
                    DECLARE @CurrentXUserEinsatzvereinbarungID INT
                    DECLARE @ModulID INT

                    SET @UserID = {0}
                    SET @SearchString = {1}
                    SET @LanguageCode = {2}
                    SET @EinsatzvereinbarungID = {3}
                    SET @CurrentXUserEinsatzvereinbarungID = {4}
                    SET @ModulID = {5}

                    SELECT USR.*,
                           Kontakt$ = dbo.fnEdGetEntlasterKontakt(USR.UserID$, 1, 1, @LanguageCode)
                    FROM dbo.fnDlgMitarbeiterSuchenKGS(@UserID) USR
                      INNER JOIN dbo.EdMitarbeiter          EDM WITH (READUNCOMMITTED) ON EDM.UserID = USR.UserID$
                      INNER JOIN dbo.EdMitarbeiter_XModul   EXM WITH (READUNCOMMITTED) ON EXM.EdMitarbeiterID = EDM.EdMitarbeiterID
                                                                                      AND EXM.XModulID = @ModulID
                                                                                      AND EXM.IstAktiv = 1
                    WHERE USR.Name LIKE (@SearchString + '%')
                      AND NOT EXISTS(SELECT TOP 1 1
                                     FROM dbo." + _queryTableName + @" UEV WITH (READUNCOMMITTED)
                                     WHERE UEV." + _einsatzvereinbarungIdColName + @" = @EinsatzvereinbarungID
                                       AND UEV.UserID = USR.UserID$
                                       AND UEV." + _queryTableIdColName + @" <> @CurrentXUserEinsatzvereinbarungID)",
                        Session.User.UserID,
                        DBUtil.SqlLiteral(searchString),
                        Session.User.LanguageCode,
                        _einsatzvereinbarungId,
                        currentXUserEinsatzvereinbarungID,
                        Convert.ToInt32(_accessModul)),
                    searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // user
                    qryMitarbeiter[userID] = dlg["UserID$"];
                    qryMitarbeiter[userName] = dlg["Name"];
                    qryMitarbeiter[userContact] = dlg["Kontakt$"];

                    // reset flags
                    ResetMitarbeiterChangedFlags();

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                // logging
                XLog.Create(this.GetType().FullName, LogLevel.ERROR, "Exception occured with showing DialogMitarbeiter.", ex.Message);

                // show message
                KissMsg.ShowError(this.Name, "ErrorIKissUserModified_v01", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);

                // call failed
                return false;
            }
        }

        /// <summary>
        /// Validate current access module
        /// </summary>
        /// <exception cref="InvalidOperationException">If current access module is invalid, this exception will be thrown</exception>
        private void IsAccessingModuleValid()
        {
            // validate accessing module
            if (_accessModul != BaUtils.ModulID.BegleitetesWohnen && _accessModul != BaUtils.ModulID.EntlastungsDienst)
            {
                // logging
                XLog.Create(this.GetType().FullName, LogLevel.ERROR, "The given accessing module is not valid and therefore cannot be handled. No implementation for this module.");

                // cancel
                throw new InvalidOperationException("The given accessing module is not valid and therefore cannot be handled.");
            }
        }

        #endregion

        #endregion
    }
}