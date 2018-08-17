using System;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Represents the Control to manage interventions for "BegleitetesWohnen" and "Entlastungsdienst"
    /// </summary>
    public partial class CtlEinsatz : KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private const int MODULIDBW = 5; // moduleID of BW
        private const int MODULIDED = 6; // moduleID of ED

        #endregion

        #region Private Fields

        private int _baPersonID = -1;
        private EinsatzHelper.AccessMode _currentAccessMode;
        private DateTime _datumBis = DateTime.MaxValue.Date;
        private DateTime _datumVon = DateTime.MinValue.Date;
        private EinsatzDTO _einsatzDaten;
        private int _einsatzTyp = -1;
        private int _faLeistungID = -1;
        private EinsatzHelper _helper;
        private bool _isInCopyProcess; // flag to save if currently within copying (btnKopie)
        private BaUtils.ModulID _modulID;
        private int _origPanBottomHeight = -1;
        private SqlQuery _qryMADetails;
        private int _userID = -1;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes componentes and fields.
        /// </summary>
        public CtlEinsatz()
        {
            // init controls/components
            InitializeComponent();

            // logging
            _logger.Debug("enter");

            // set original height of panBottom
            _origPanBottomHeight = panBottom.Height;

            // attach event
            edtBeginnDatum.LostFocus += edtBeginnDatum_LostFocus;

            // init with default values (BW)
            Init(null, null, -1, false, 5);

            // debug:
            //this.Init("something", null, AccessMode.Person, -1, false, -1, -1);

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region EventHandlers

        private void btnInfoMitarbeiter_Click(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // validate if any data can be displayed
            if (DBUtil.IsEmpty(qryEinsatz["UserID"]))
            {
                // logging
                _logger.Debug("no user selected, cancel");

                // no data selected
                KissMsg.ShowInfo(this.Name, "NoUserSelected", "Es ist kein/e Mitarbeiter/in ausgewählt. Das Anzeigen der Details ist nicht möglich.");
                return;
            }

            // find EdMitarbeiterID of given user depending on given module (also show inactive users)
            SqlQuery qryMitarbeiter = DBUtil.OpenSQL(@"
                SELECT TOP 1
                       EDM.EdMitarbeiterID
                FROM dbo.EdMitarbeiter EDM WITH (READUNCOMMITTED)
                  INNER JOIN dbo.EdMitarbeiter_XModul EMM ON EMM.EdMitarbeiterID = EDM.EdMitarbeiterID
                                                         AND EMM.XModulID = {1}
                WHERE EDM.UserID = {0}", Convert.ToInt32(qryEinsatz["UserID"]), BaUtils.ModulIDCode(_modulID));

            // check if call is valid
            if (qryMitarbeiter.Count < 1 || DBUtil.IsEmpty(qryMitarbeiter["EdMitarbeiterID"]))
            {
                // show message depending on given module
                switch (_modulID)
                {
                    case BaUtils.ModulID.BegleitetesWohnen:
                        // no data selected
                        KissMsg.ShowInfo(this.Name, "NoUserFoundToJumpToBW_v01", "Der/die gewünschte Mitarbeiter/in ist beim Begleiteten Wohnen nicht eingetragen. Das Anzeigen der Details ist nicht möglich.");
                        return;

                    case BaUtils.ModulID.EntlastungsDienst:
                        // no data selected
                        KissMsg.ShowInfo(this.Name, "NoUserFoundToJumpToED_v01", "Der/die gewünschte Mitarbeiter/in ist beim Entlastungsdienst nicht eingetragen. Das Anzeigen der Details ist nicht möglich.");
                        return;

                    default:
                        // modulID is not yet supported
                        throw new InvalidOperationException("The given modulID has no corresponding message yet!");
                }
            }

            // jump to selected EdMitarbeiterID
            FormController.OpenForm(FrmMitarbeiterverwaltung.FormControllerTarget_Mitarbeiterverwaltung,
                                    "Action", CtlMitarbeiterverwaltung.FormControllerAction_JumpToMitarbeiter,
                                    "EdMitarbeiterID", qryMitarbeiter["EdMitarbeiterID"]);

            // logging
            _logger.Debug("done");
        }

        private void btnKopie_Click(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // VALIDATE IF ALLOWED:
            // copy is only allowed if not locked
            if (!qryEinsatz.CanInsert || !qryEinsatz.CanUpdate)
            {
                // logging
                _logger.Debug("cannot insert/update, cancel");

                // do nothing
                btnKopie.Enabled = false;
                return;
            }

            // ensure valid data
            if (!qryEinsatz.Post() || qryEinsatz.Count < 1)
            {
                return;
            }

            // DO IT:
            Cursor currentCursor = Cursor.Current;
            Cursor = Cursors.WaitCursor;

            try
            {
                // set flag
                _isInCopyProcess = true;

                // show dialog to let the user select the dates he want to create copies to
                DlgMehrfacheintrag dlg = new DlgMehrfacheintrag();

                // allow sat/sun
                dlg.AllowSaturdaySunday = true;

                // show dialog and check if user clicked ok-button
                if (dlg.ShowDialog(this) != DialogResult.OK)
                {
                    // not ok-button clicked - do not continue
                    return;
                }

                // SPECIFIC HANDLING:
                // get current dates
                DateTime datumBeginn = Convert.ToDateTime(qryEinsatz["Beginn"]);
                DateTime datumEnde = Convert.ToDateTime(qryEinsatz["Ende"]);

                // calculate difference
                TimeSpan timeSpanBeginnEnde = datumEnde.Subtract(datumBeginn);  // end - beginn to have positive delta

                // logging
                _logger.DebugFormat("datumBeginn='{0}', datumEnde='{1}', timeSpanBeginnEnde='{2}'", datumBeginn, datumEnde, timeSpanBeginnEnde);

                // GO ON:
                // get selected dates from dialog
                DateTime[] selectedDates = dlg.GetSelectedDates();

                // validate
                if (selectedDates == null || selectedDates.Length < 1)
                {
                    // do not continue
                    return;
                }

                // loop through array
                for (int i = 0; i < selectedDates.Length; i++)
                {
                    // copy each value into a new row
                    DataRow newRow = qryEinsatz.DataTable.NewRow();

                    foreach (DataColumn col in qryEinsatz.DataTable.Columns)
                    {
                        if (!col.AutoIncrement)
                        {
                            newRow[col.ColumnName] = qryEinsatz.Row[col.ColumnName];
                        }
                    }

                    // CONTINUE
                    // setup new beginn-date with new-date-part and old-hours/minutes/seconds-part
                    DateTime newBeginn = new DateTime(selectedDates[i].Year, selectedDates[i].Month, selectedDates[i].Day, datumBeginn.Hour, datumBeginn.Minute, datumBeginn.Second);

                    // modify copied values, apply calculated values
                    newRow["Beginn"] = newBeginn;
                    newRow["Ende"] = newBeginn.Add(timeSpanBeginnEnde); // add amount of time to end, to have proper end-date calulated depending on start with same delta

                    // if empty, leave it empty, otherwise apply code 'geplant'
                    if (!DBUtil.IsEmpty(newRow["StatusCode"]))
                    {
                        // not empty, apply 'geplant'
                        newRow["StatusCode"] = 1;       // reset to 'geplant' (EdEinsatzStatus: 1=geplant)
                    }

                    // logging
                    _logger.DebugFormat("newRow['Beginn']='{0}', newRow['Ende']='{1}'", newRow["Beginn"], newRow["Ende"]);

                    // add new row to query and save data
                    qryEinsatz.RowModified = false;     // somehow KiSS thinks, it has changed the current row...
                    qryEinsatz.DataTable.Rows.Add(newRow);
                    qryEinsatz.RowModified = true;

                    if (!qryEinsatz.Post())
                    {
                        throw new Exception("Post has failed, data could not be inserted.");
                    }
                }
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(this.Name, "ErrorCopyEntryToNewDate", "Es ist ein Fehler beim Kopieren der Einträge aufgetreten.", ex);
            }
            finally
            {
                // refresh query
                qryEinsatz.Refresh();

                // reset flag
                _isInCopyProcess = false;

                // set focus
                edtBeginnDatum.Focus();

                // reset cursor
                Cursor = currentCursor;
            }

            // logging
            _logger.Debug("done");
        }

        private void edtBeginnDatum_LostFocus(object sender, System.EventArgs e)
        {
            // update default value if neccessary
            SetDefaultValueEndeDatum();
        }

        private void edtBeginnEnde_Modified(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // check if user can change value
            if (qryEinsatz.CanUpdate)
            {
                // set row modified to ensure values will be saved even without leaving control
                qryEinsatz.RowModified = true;
            }

            // logging
            _logger.Debug("done");
        }

        private void edtMitarbeiter_EditValueChanged(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // only if we have a valid datasource
            if (!qryEinsatz.CanUpdate ||
                edtMitarbeiter.Properties.DataSource == null ||
                _qryMADetails == null ||
                _qryMADetails.Count < 1)
            {
                // logging
                _logger.Debug("locked, cancel");

                // do nothing
                return;
            }

            // check if empty and found
            if (DBUtil.IsEmpty(edtMitarbeiter.EditValue) || !_qryMADetails.Find(string.Format("Code = {0}", edtMitarbeiter.EditValue)))
            {
                // logging
                _logger.Debug("nothing selected or not found");

                // manualy reset value because of some strange behaviour in databinding
                qryEinsatz[edtMitarbeiter.DataMember] = DBNull.Value;

                // reset display fields
                qryEinsatz["UserID"] = DBNull.Value;
                qryEinsatz["Mitarbeiter"] = DBNull.Value;
                qryEinsatz["MitarbeiterTelefon"] = DBNull.Value;
            }
            else
            {
                // logging
                _logger.DebugFormat("apply values to component: QryMADetails - UserID='{0}', Text='{1}', Code='{2}', Telefon='{3}'", _qryMADetails["UserID"], _qryMADetails["Text"], _qryMADetails["Code"], _qryMADetails["Telefon"]);

                // manualy set value because of some strange behaviour in databinding
                qryEinsatz[edtMitarbeiter.DataMember] = edtMitarbeiter.EditValue;

                // apply display-only fields depending on selected value
                qryEinsatz["UserID"] = _qryMADetails["UserID"];
                qryEinsatz["Mitarbeiter"] = _qryMADetails["Text"];
                qryEinsatz["MitarbeiterTelefon"] = _qryMADetails["Telefon"];
            }

            // check current mode
            if (qryEinsatz.Row != null && qryEinsatz.Row.RowState == DataRowState.Added)
            {
                // store current DatumBis to reapply after refresh if removed
                object endeDatum = edtEndeDatum.EditValue;

                // update binding, due to some strange behaviour not everytime binding does update control-text
                qryEinsatz.RefreshDisplay();

                // reapply if there was a date and now its gone
                if (!DBUtil.IsEmpty(endeDatum) && DBUtil.IsEmpty(edtEndeDatum.EditValue))
                {
                    edtEndeDatum.EditValue = endeDatum;

                    // logging
                    _logger.Debug("reapplied date to end-date control");
                }
            }
            else
            {
                // only update binding, due to some strange behaviour not everytime binding does update control-text
                qryEinsatz.RefreshDisplay();
            }

            // logging
            _logger.Debug("done");
        }

        private void qryEinsatz_AfterFill(object sender, System.EventArgs e)
        {
            // select last row
            qryEinsatz.Last();
        }

        private void qryEinsatz_AfterInsert(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // apply
            qryEinsatz["FaLeistungID"] = _faLeistungID;     // FaLeistungID
            qryEinsatz["TypCode"] = 1;                      // default value

            // creator of row
            qryEinsatz.SetCreator();

            // set focus
            edtBeginnDatum.Focus();

            // logging
            _logger.Debug("done");
        }

        private void qryEinsatz_AfterPost(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // apply lookup fields
            qryEinsatz["Typ"] = edtTyp.Text;
            qryEinsatz["Status"] = edtStatus.Text;

            // logging
            _logger.Debug("done");
        }

        private void qryEinsatz_BeforePost(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("BeginDate='{0}', BeginTime='{1}', EndDate='{2}', EndTime='{3}'", edtBeginnDatum.EditValue, edtBeginnZeit.EditValue, edtEndeDatum.EditValue, edtEndeZeit.EditValue);

            // check accessmode
            if (_currentAccessMode != EinsatzHelper.AccessMode.Leistung)
            {
                // show error
                KissMsg.ShowError(this.Name, "InvalidAccessMode", "Die Daten können nicht gespeichert werden, das Verändern der Daten in diesem Zugriffsmodus ist nicht zulässig.");

                // cancel
                throw new KissCancelException();
            }

            // CHECK IF NOT MULTICOPY
            if (!_isInCopyProcess)
            {
                // validate must-fields
                DBUtil.CheckNotNullField(edtBeginnDatum, lblBeginn.Text);
                DBUtil.CheckNotNullField(edtBeginnZeit, lblBeginn.Text);
                DBUtil.CheckNotNullField(edtEndeDatum, lblEnde.Text);
                DBUtil.CheckNotNullField(edtEndeZeit, lblEnde.Text);
                DBUtil.CheckNotNullField(edtTyp, lblTyp.Text);
                DBUtil.CheckNotNullField(edtMitarbeiter, lblMitarbeiter.Text);

                // check if we have a userid (required for later validation)
                if (DBUtil.IsEmpty(qryEinsatz["UserID"]) || Convert.ToInt32(qryEinsatz["UserID"]) < 1)
                {
                    // show error
                    KissMsg.ShowError(this.Name, "InvalidUserIDOnPost", "Ausnahmefehler: Es ist keine UserID definiert, der Datensatz kann nicht gespeichert werden.");

                    // do not continue
                    return;
                }

                // create Beginn and Ende DateTime
                qryEinsatz["Beginn"] = FaUtils.CombineDateTime(edtBeginnDatum.DateTime, edtBeginnZeit.Time);
                qryEinsatz["Ende"] = FaUtils.CombineDateTime(edtEndeDatum.DateTime, edtEndeZeit.Time);
            }

            // we have a ZeitVon and ZeitBis, validate if Bis > Von
            if (Convert.ToDateTime(qryEinsatz["Beginn"]) >= Convert.ToDateTime(qryEinsatz["Ende"]))
            {
                // invalid range
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name, "InvalidTimeOrder_v01", "Der Wert 'Ende' ist ungültig - er darf nicht kleiner oder gleich 'Beginn' sein."), edtEndeZeit);
            }

            // validate if range is not yet in use
            if (!Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnFaEinsatzIsTimeRangeValid({0}, {1}, {2}, {3}, {4})", BaUtils.ModulIDCode(_modulID),
                                                                                  Convert.ToInt32(qryEinsatz["UserID"]),
                                                                                  qryEinsatz["Beginn"],
                                                                                  qryEinsatz["Ende"],
                                                                                  qryEinsatz[_helper.EinsatzID])))
            {
                // range already in use, show warning
                KissMsg.ShowInfo(this.Name, "UserDateTimeRangeAlreadyInUse_v05", "Hinweis:{0}Die angegebene Zeitspanne wurde für den/die gewählten Mitarbeiter/in und Zeitspanne '{1:g} - {2:g}' bereits verwendet.{0}{0}Die Daten werden aber trotzdem gespeichert.", 0, 0, Environment.NewLine, Convert.ToDateTime(qryEinsatz["Beginn"]), Convert.ToDateTime(qryEinsatz["Ende"]));
            }

            // Modifier/Modified
            qryEinsatz.SetModifierModified();

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gets the value for a specified field. Used for Bookmarks.
        /// </summary>
        /// <param name="fieldName">Name of the field</param>
        /// <returns>The value of the field.</returns>
        public override object GetContextValue(string fieldName)
        {
            // logging
            _logger.Debug("call");
            _logger.DebugFormat("fieldName='{0}'", fieldName);

            switch (fieldName.ToUpper())
            {

                case "SELECTEDIDLIST":
                    // check if we have any data
                    if (qryEinsatz.Count > 0)
                    {
                        // init var
                        string idList = "";

                        // loop shown entries and get id from each line
                        for (int i = 0; i < grvEinsaetze.DataRowCount; i++)
                        {
                            if (idList.Length > 0)
                            {
                                idList += ",";
                            }

                            idList += grvEinsaetze.GetRowCellValue(i, colEinsatzID).ToString();
                        }

                        // logging
                        _logger.DebugFormat("SELECTEDIDLIST: idList='{0}'", idList);

                        // done, return ids as csv
                        return idList;
                    }
                    // else: no entry found ("-1" in order to have something to convert to int in stored procedure)
                    return "-1";

                case "SEARCHDATUMVON":
                    // init var
                    string returnDateFrom = string.Empty;

                    // depending on current access mode
                    if (_currentAccessMode == EinsatzHelper.AccessMode.Leistung)
                    {
                        // check if we have a search-date and return value
                        if (!DBUtil.IsEmpty(edtSucheDatumVon.EditValue))
                        {
                            returnDateFrom = String.Format("{0:d}", Convert.ToDateTime(edtSucheDatumVon.EditValue));
                        }
                    }
                    else
                    {
                        // return search-date from Init()-parameter
                        if (_datumVon > SqlDateTime.MinValue.Value)
                        {
                            returnDateFrom = String.Format("{0:d}", _datumVon);
                        }
                    }

                    // add "von" if we have a return date
                    if (!string.IsNullOrEmpty(returnDateFrom))
                    {
                        // we have a valid value
                        //return String.Format("{0} {1}", KissMsg.GetMLMessage("CtlEinsatz", "SearchDateFromPrefix", "von"), returnDateFrom);
                        return returnDateFrom;
                    }

                    // return no-value-string
                    return "-";

                case "SEARCHDATUMBIS":
                    // init var
                    string returnDateTo = string.Empty;

                    // depending on current access mode
                    if (_currentAccessMode == EinsatzHelper.AccessMode.Leistung)
                    {
                        // check if we have a search-date and return value
                        if (!DBUtil.IsEmpty(edtSucheDatumBis.EditValue))
                        {
                            returnDateTo = string.Format("{0:d}", Convert.ToDateTime(edtSucheDatumBis.EditValue));
                        }
                    }
                    else
                    {
                        // return search-date from Init()-parameter
                        if (_datumBis < SqlDateTime.MaxValue.Value)
                        {
                            returnDateTo = string.Format("{0:d}", _datumBis);
                        }
                    }

                    // add "bis" if we have a return date
                    if (!string.IsNullOrEmpty(returnDateTo))
                    {
                        // we have a valid value
                        //return String.Format("{0} {1}", KissMsg.GetMLMessage("CtlEinsatz", "SearchDateToPrefix", "bis"), returnDateTo);
                        return returnDateTo;
                    }

                    // return no-value-string
                    return "-";

                case "MODULID":
                    // get int of current moduleid
                    int modulID = BaUtils.ModulIDCode(_modulID);

                    // validate
                    if (modulID > 0)
                    {
                        return modulID;
                    }

                    // return invalid modul-id
                    return -1;

            }

            int searchTypeEditValue = DBUtil.IsEmpty(edtSucheTyp.EditValue) ? -1 : Convert.ToInt32(edtSucheTyp.EditValue);

            // search for the value specific for the module
            object result = _helper.ContextValueByModul(fieldName, qryEinsatz, searchTypeEditValue);

            // if a value is found by the helper, return it.
            if (!result.ToString().Equals(fieldName))
            {
                return result;
            }

            // let base do stuff
            return base.GetContextValue(fieldName);
        }

        /// <summary>
        /// Default access to initialize fields. Used in AKV.
        /// </summary>
        /// <param name="titleName">title of the control</param>
        /// <param name="titleImage">title image in the contol</param>
        /// <param name="faLeistungID">identification number of the Leistung which holds the intervention</param>
        /// <param name="isLeistungClosed">true if hosting Leistung is already closed</param>
        /// <param name="modulIDCode">id of the current module as defined in BaUtils.ModulID</param>
        /// <exception cref="ArgumentOutOfRangeException">This exception is thrown if <paramref name="modulIDCode"/> is not BW or ED</exception>
        public void Init(string titleName, Image titleImage, int faLeistungID, bool isLeistungClosed, int modulIDCode)
        {
            // logging
            _logger.Debug("enter (default access)");

            BaUtils.ModulID modulID;

            // check and set modulID
            switch (modulIDCode)
            {
                case MODULIDBW:
                    modulID = BaUtils.ModulID.BegleitetesWohnen;
                    break;

                case MODULIDED:
                    modulID = BaUtils.ModulID.EntlastungsDienst;
                    break;

                default:
                    // invalid code, cannot continue
                    throw new ArgumentOutOfRangeException("modulIDCode", "Given modulID is not supported at the moment, cannot continue.");
            }

            // call Leistung-mode
            Init(titleName,
                 titleImage,
                 EinsatzHelper.AccessMode.Leistung,
                 faLeistungID,
                 isLeistungClosed,
                 modulID,
                 -1,
                 -1,
                 DateTime.MinValue,
                 DateTime.MaxValue,
                 -1);

            // logging
            _logger.Debug("done (default access)");
        }

        /// <summary>
        /// Used to initialize fields in the control. Must be called after creation of the control if no other Init method is called
        /// </summary>
        /// <param name="titleName">title of the control</param>
        /// <param name="titleImage">title image in the contol</param>
        /// <param name="accessMode">the access mode decides which data will be displayed and the layout will be changed</param>
        /// <param name="faLeistungID">identification number of the Leistung which holds the intervention</param>
        /// <param name="isLeistungClosed">true if hosting Leistung is already closed</param>
        /// <param name="modulID">ID of the current module as defined in BaUtils.ModulID</param>
        /// <param name="baPersonID">identification number of the client</param>
        /// <param name="userID">identifiaciton number of the user</param>
        /// <param name="datumVon">starting date of the intervention</param>
        /// <param name="datumBis">end date of the intervention</param>
        /// <param name="einsatzTyp">type of the intervention according to the module (eg. BW)</param>
        /// <exception cref="ArgumentOutOfRangeException">This exception is thrown if <paramref name="modulID"/> is not BW or ED</exception>
        public void Init(string titleName,
            Image titleImage,
            EinsatzHelper.AccessMode accessMode,
            int faLeistungID,
            bool isLeistungClosed,
            BaUtils.ModulID modulID,
            int baPersonID,
            int userID,
            DateTime datumVon,
            DateTime datumBis,
            int einsatzTyp)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("accessMode='{0}', faLeistungID='{1}', isLeistungClosed='{2}', baPersonID='{3}', userID='{4}', datumVon='{5}', datumBis='{6}', einsatzTyp='{7}', modulID='{8}'",
                                accessMode, faLeistungID, isLeistungClosed, baPersonID, userID, datumVon, datumBis, einsatzTyp, modulID);

            // validate
            if (accessMode == EinsatzHelper.AccessMode.Leistung && faLeistungID < 1)
            {
                // logging
                _logger.Debug("invalid id, cancel");

                // do not continue
                qryEinsatz.CanUpdate = false;
                qryEinsatz.EnableBoundFields(qryEinsatz.CanUpdate);
                return;
            }

            // allow changes
            if (accessMode == EinsatzHelper.AccessMode.Leistung && !isLeistungClosed)
            {
                // update is allowed
                qryEinsatz.CanInsert = true;
                qryEinsatz.CanUpdate = true;
                qryEinsatz.CanDelete = true;
            }
            else
            {
                // everything is locked here
                qryEinsatz.CanInsert = false;
                qryEinsatz.CanUpdate = false;
                qryEinsatz.CanDelete = false;
            }

            // apply values
            _currentAccessMode = accessMode;
            _faLeistungID = faLeistungID;
            _baPersonID = baPersonID;
            _userID = userID;
            _datumVon = FaUtils.CorrectDateTimeToSqlDateTime(datumVon);
            _datumBis = FaUtils.CorrectDateTimeToSqlDateTime(datumBis);
            _einsatzTyp = einsatzTyp;
            _modulID = modulID;
            picTitel.Image = titleImage;
            lblTitel.Text = titleName;

            _einsatzDaten = new EinsatzDTO
            {
                CurrentAccessMode = _currentAccessMode,
                BaPersonID = _baPersonID,
                DatumBis = _datumBis,
                DatumVon = _datumVon,
                FaLeistungID = _faLeistungID,
                EinsatzTyp = _einsatzTyp,
                UserId = _userID
            };

            // choose helper depending on Modul
            switch (_modulID)
            {
                case BaUtils.ModulID.BegleitetesWohnen:
                    // apply helper for BegleitetesWohnen
                    _helper = new BwEinsatzHelper(_einsatzDaten);
                    break;

                case BaUtils.ModulID.EntlastungsDienst:
                    // apply helper for Entlastungsdienst
                    _helper = new EdEinsatzHelper(_einsatzDaten);
                    break;

                default:
                    // invalid code, cannot continue
                    throw new ArgumentOutOfRangeException("modulID", "Given modulID is not supported, cannot continue.");
            }

            // set the correct table name
            SetModulDependingValues(_helper);

            // set sql-statement
            qryEinsatz.SelectStatement = _helper.GetSqlStatement();

            // logging
            _logger.DebugFormat("SelectStatement='{0}'", qryEinsatz.SelectStatement);

            // depending on current access mode, we search or fill query
            if (accessMode == EinsatzHelper.AccessMode.Leistung)
            {
                // do new search and run search
                NewSearch();
                tabControlSearch.SelectTab(tpgListe);

                // insert new entry if not yet any entry found
                if (qryEinsatz.CanUpdate && qryEinsatz.Count < 1)
                {
                    qryEinsatz.Insert(null);
                }
            }
            else
            {
                // fill data
                qryEinsatz.Fill();
            }

            // setup button
            btnKopie.Enabled = qryEinsatz.CanInsert;	// copy is only allowed if user can insert new entries

            // setup gui
            SetupGUIDependingOnAccessMode();

            // setup MA-lookupedits
            ApplyMitarbeiterLookUps();

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Reacts on the KiSS defined input for saving.
        /// </summary>
        /// <returns></returns>
        public override bool OnSaveData()
        {
            // logging
            _logger.Debug("call");

            // check if user can change something
            if (qryEinsatz.CanUpdate && qryEinsatz.RowModified)
            {
                // logging
                _logger.DebugFormat("before: BeginDate='{0}', BeginTime='{1}', EndDate='{2}', EndTime='{3}'", edtBeginnDatum.EditValue, edtBeginnZeit.EditValue, edtEndeDatum.EditValue, edtEndeZeit.EditValue);

                // HACK: call DoValidate due to lost-changes-problem otherwise (see #4980)
                // do validate on controls to apply possibly changed values
                edtBeginnDatum.DoValidate();
                edtBeginnZeit.DoValidate();
                edtEndeDatum.DoValidate();
                edtEndeZeit.DoValidate();

                // logging
                _logger.DebugFormat("after: BeginDate='{0}', BeginTime='{1}', EndDate='{2}', EndTime='{3}'", edtBeginnDatum.EditValue, edtBeginnZeit.EditValue, edtEndeDatum.EditValue, edtEndeZeit.EditValue);
            }

            //Ist es ein neuer Datensatz?
            bool stateAdded = qryEinsatz.CurrentRowState == DataRowState.Added;

            // let base do stuff
            var result = base.OnSaveData();
            if (result && stateAdded)
            {
                //sicherstellen, dass Spalten via JOIN geladen sind
                qryEinsatz.Refresh();
            }

            return result;
        }

        /// <summary>
        /// Reacts on the KiSS defined input for search.
        /// Only allow search if AccessMode is Leistung
        /// </summary>
        public override void OnSearch()
        {
            // logging
            _logger.Debug("enter");

            // search is only allowed if in AccessMode.Leistung
            if (_currentAccessMode != EinsatzHelper.AccessMode.Leistung)
            {
                // do nothing
                return;
            }

            // otherwise, let base do stuff
            base.OnSearch();

            // logging
            _logger.Debug("done");
        }

        public override void Translate()
        {
            // let base do stuff
            base.Translate();

            // set module-depending translations
            SetModulDependingValues(_helper);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Prepare a new search
        /// </summary>
        protected override void NewSearch()
        {
            // logging
            _logger.Debug("enter");

            // let base do stuff
            base.NewSearch();

            // focus
            edtSucheDatumVon.Focus();

            // logging
            _logger.Debug("done");
        }

        /// <summary>
        /// Start a search
        /// </summary>
        protected override void RunSearch()
        {
            // logging
            _logger.Debug("enter");

            // let base do stuff
            base.RunSearch();

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Private Methods

        private void ApplyMitarbeiterLookUps()
        {
            // logging
            _logger.Debug("enter");

            // check current accessmode
            if (_currentAccessMode != EinsatzHelper.AccessMode.Leistung)
            {
                // logging
                _logger.Debug("not AccessMode.Leistung, cancel");

                // do nothing if not Leistung
                return;
            }

            // init controls
            edtMitarbeiter.Properties.DataSource = null;
            edtSucheMitarbeiter.Properties.DataSource = null;

            // get the query from the helper depending on the module
            SqlQuery qryMA = _helper.GetMitarbeiterLookupQuery();

            // setup edtMitarbeiter
            edtMitarbeiter.Properties.DropDownRows = Math.Min(qryMA.Count, 7);
            edtMitarbeiter.Properties.DataSource = qryMA;

            // setup edtSucheMitarbeiter
            edtSucheMitarbeiter.Properties.DropDownRows = Math.Min(qryMA.Count, 7);
            edtSucheMitarbeiter.Properties.DataSource = qryMA;

            // apply field
            _qryMADetails = qryMA;

            // logging
            _logger.Debug("done");
        }

        private void SetDefaultValueEndeDatum()
        {
            // logging
            _logger.Debug("enter");

            // only if we can and should apply value
            if (!qryEinsatz.CanUpdate || DBUtil.IsEmpty(edtBeginnDatum.EditValue) || !DBUtil.IsEmpty(edtEndeDatum.EditValue))
            {
                // logging
                _logger.Debug("nothing to do, cancel");

                // do nothing
                return;
            }

            // logger
            _logger.DebugFormat("apply value: BeginnDatum='{0}', BeginnDatum.EditValue='{1}', EndeDatum.EditValue='{2}'", qryEinsatz[edtBeginnDatum.DataMember], edtBeginnDatum.EditValue, edtEndeDatum.EditValue);

            // apply value from Beginn to empty Ende date
            edtEndeDatum.EditValue = edtBeginnDatum.EditValue;

            // logging
            _logger.Debug("done");
        }

        private void SetModulDependingValues(EinsatzHelper hlp)
        {
            // setup controls and components
            hlp.SetCaptionAndFieldNameForEinsatzIDColumn(colEinsatzID);
            hlp.SetDataMemberForMitarbeiterEdit(edtMitarbeiter);
            hlp.SetDocContextName(docBestaetigung);
            hlp.SetLovNameForEinsatzTypEdit(edtTyp);
            hlp.SetLovNameForEinsatzTypEdit(edtSucheTyp);
            hlp.SetQueryTableName(qryEinsatz);
            hlp.SetTextForEinsatzTypLabel(lblTyp);
            hlp.SetTextForEinsatzTypLabel(lblSucheTyp);

            // setup gotofall control
            ctlGotoFall.DisplayModules = Convert.ToString(BaUtils.ModulIDCode(_modulID));
        }

        private void SetupGUIDependingOnAccessMode()
        {
            // logging
            _logger.Debug("enter");

            // if access mode is Leistung, we do show/hide other controls than in other access modes
            if (_currentAccessMode == EinsatzHelper.AccessMode.Leistung)
            {
                // hide column
                colKlient.VisibleIndex = -1;

                // hide Klient
                lblKlient.Visible = false;
                edtKlient.Visible = false;
                ctlGotoFall.Visible = false;

                // show/hide Mitarbeiter-info-controls
                edtMitarbeiter.Visible = true;
                edtMitarbeiterInfo.Visible = false;

                // do not continue
                return;
            }

            // hide top panel
            panTitel.Visible = false;

            // other modes, disable copy-functionality
            btnKopie.Visible = false;

            // shrink bottom-panel (h=t1+h1+d, where d=h-(t2+h2) and h=height of panBottom; 1=comment, 2=copy-btn)
            panBottom.Height = (edtBemerkungen.Top + edtBemerkungen.Height) + (_origPanBottomHeight - (btnKopie.Top + btnKopie.Height));

            // setup tabcontrol and tabpages
            tabControlSearch.TabsLocation = SharpLibrary.WinControls.TabsLocation.Right;
            tabControlSearch.VerticalMargin = 0;
            tabControlSearch.FlatStyleSelectedTabBorderColor = BackColor;
            tabControlSearch.FlatStyleSelectedTabColor = BackColor;
            tabControlSearch.TextColor = BackColor;

            tpgSuchen.HideTab = true;

            // show/hide Mitarbeiter-info-controls
            edtMitarbeiter.Visible = false;
            edtMitarbeiterInfo.Visible = true;

            edtMitarbeiterInfo.Top = edtMitarbeiter.Top;
            edtMitarbeiterInfo.Left = edtMitarbeiter.Left;
            edtMitarbeiterInfo.Width = edtMitarbeiter.Width;
            edtMitarbeiterInfo.Anchor = edtMitarbeiter.Anchor;

            // logging
            _logger.Debug("done");
        }

        #endregion

        #endregion
    }
}