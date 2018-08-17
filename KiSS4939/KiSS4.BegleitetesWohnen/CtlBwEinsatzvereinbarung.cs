using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;
using log4net;

namespace KiSS4.BegleitetesWohnen
{
    /// <summary>
    /// Control, used for Einsatzvereinbarung of Begleitetes Wohnen
    /// </summary>
    public partial class CtlBwEinsatzvereinbarung : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly CtlFaBegleiterEntlaster _ctlBegleiter;

        #endregion

        #region Private Fields

        private int _bwEinsatzvereinbarungID = -1;
        private int _faLeistungID = -1;
        private bool _hadNoBWEinsatzvereinbarungID = true;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlBwEinsatzvereinbarung"/> class.
        /// </summary>
        public CtlBwEinsatzvereinbarung()
        {
            // init controls
            InitializeComponent();

            // HIDE REDUCTIONS and resize Tarife
            grpReduktionen.Visible = false;
            grpTarife.Width = grpZiele.Width;

            // create and arrange control
            _ctlBegleiter = new CtlFaBegleiterEntlaster();
            _ctlBegleiter.Dock = DockStyle.Fill;
            tpgBegleiter.Controls.Add(_ctlBegleiter);

            // init with default values
            Init(null, null, -1, false);
        }

        #endregion

        #region EventHandlers

        private void qryBwEinsatzvereinbarung_AfterInsert(object sender, EventArgs e)
        {
            // apply FaLeistungID
            qryBwEinsatzvereinbarung["FaLeistungID"] = _faLeistungID;

            // apply default values
            qryBwEinsatzvereinbarung["ErstellungEV"] = DateTime.Today;

            // set creator of row
            qryBwEinsatzvereinbarung.SetCreator();
        }

        private void qryBwEinsatzvereinbarung_AfterPost(object sender, EventArgs e)
        {
            // set flag, used to init MA-control afterwards
            SetHadNoBWFlag();

            try
            {
                // logging
                _logger.Debug("enter");

                // get current id
                _bwEinsatzvereinbarungID = Convert.ToInt32(qryBwEinsatzvereinbarung["BwEinsatzvereinbarungID"]);

                // logging
                _logger.DebugFormat("_bwEinsatzvereinbarungID='{0}'", _bwEinsatzvereinbarungID);

                // validate
                if (_bwEinsatzvereinbarungID < 1)
                {
                    throw new KissCancelException("Could not get valid value for BwEinsatzvereinbarungID.");
                }

                // validate
                if (!CompareQueryValueAndEditValue(edtThemenCodes.DataMember, edtThemenCodes.EditValue))
                {
                    // invalid data in query
                    throw new KissCancelException(string.Format("Invalid value in SqlQuery detected for '{0}'", edtThemenCodes.DataMember));
                }

                // save changes in subtable for BwThema
                SaveCsvListInTable(_bwEinsatzvereinbarungID, edtThemenCodes.EditValue, "BwThema");

                // done, commit changes now
                Session.Commit();

                // logging
                _logger.Debug("committed");
            }
            catch (Exception ex)
            {
                // undo changes
                Session.Rollback();

                // logging
                _logger.Debug("exception occured", ex);

                // show message
                KissMsg.ShowError(Name, "ErrorSavingData", "Es ist ein Fehler beim Speichern der Daten aufgetreten.", ex);

                // cancel here
                throw new KissCancelException();
            }

            // logging
            _logger.Debug("done");
        }

        private void qryBwEinsatzvereinbarung_BeforePost(object sender, EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtErstellungEV, lblErstellungEV.Text);

            // validate amounts
            if (!DBUtil.IsEmpty(qryBwEinsatzvereinbarung["TarifTag"]) && Convert.ToDecimal(qryBwEinsatzvereinbarung["TarifTag"]) < 0.0m)
            {
                // invalid value
                edtTarifTag.Focus();

                // show info
                KissMsg.ShowInfo(Name, "InvalidTarifTag", "Der Geldbetrag für den Tagestarif darf nicht negativ sein.");

                // cancel
                throw new KissCancelException();
            }

            if (!DBUtil.IsEmpty(qryBwEinsatzvereinbarung["TarifNacht"]) && Convert.ToDecimal(qryBwEinsatzvereinbarung["TarifNacht"]) < 0.0m)
            {
                // invalid value
                edtTarifNacht.Focus();

                // show info
                KissMsg.ShowInfo(Name, "InvalidTarifNacht", "Der Geldbetrag für den Nachttarif darf nicht negativ sein.");

                // cancel
                throw new KissCancelException();
            }

            // logging
            _logger.Debug("start transaction");

            Session.BeginTransaction();

            try
            {
                // apply modifier
                qryBwEinsatzvereinbarung.SetModifierModified();
            }
            catch (Exception ex)
            {
                // undo changes
                Session.Rollback();

                // show message
                KissMsg.ShowError(Name, "ErrorBeforeSavingData", "Es ist ein Fehler vor dem Speichern der Daten aufgetreten.", ex);

                // cancel post
                throw new KissCancelException();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BWEINSATZVEREINBARUNGID":
                    // check if we have an entry
                    if (qryBwEinsatzvereinbarung.Count < 1)
                    {
                        return -1;
                    }

                    // get current value
                    return qryBwEinsatzvereinbarung["BwEinsatzvereinbarungID"];

                case "BWAUSWERTUNGORGANISATIONID":
                    return FaUtils.GetBwAuswertungOrganisationID(_faLeistungID);

                case "FALEISTUNGID":
                    // get current value
                    return _faLeistungID;
            }

            return base.GetContextValue(fieldName);
        }

        /// <summary>
        /// Init control with given data
        /// </summary>
        /// <param name="titleName">The titlename (won't be displayed)</param>
        /// <param name="titleImage">The title image to display in title panel</param>
        /// <param name="faLeistungID">The id of the FaLeistung entry of the given person</param>
        /// <param name="isLeistungClosed"><c>True</c> if entry in FaLeistung is closed and therefore cannot be edited, otherwise <c>False</c></param>
        public void Init(string titleName, Image titleImage, int faLeistungID, bool isLeistungClosed)
        {
            // logging
            _logger.DebugFormat("init with faLeistungID='{0}', isLeistungClosed='{1}'", faLeistungID, isLeistungClosed);

            // apply/reset members
            _bwEinsatzvereinbarungID = -1;

            // validate FaLeistungID
            if (faLeistungID < 1)
            {
                // reset objects
                qryBwEinsatzvereinbarung.CanUpdate = false;
                qryBwEinsatzvereinbarung.EnableBoundFields(qryBwEinsatzvereinbarung.CanUpdate);

                _ctlBegleiter.ActiveSQLQuery.CanUpdate = false;
                _ctlBegleiter.ActiveSQLQuery.EnableBoundFields(_ctlBegleiter.ActiveSQLQuery.CanUpdate);

                // do not continue
                return;
            }

            edtThemenCodes.LookupSQL = string.Format(@"
                SELECT Code = BWT.BwThemaID,
                       Text = ISNULL(TXT.Text, BWT.Text)
                FROM dbo.BwThema          BWT WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON BWT.TextTID = TXT.TID
                                                                    AND TXT.LanguageCode = {0}
                ORDER BY Code", Session.User.LanguageCode);

            edtReduktionCodes.LookupSQL = string.Format(@"
                SELECT Code = BWR.BwReduktionID,
                       Text = ISNULL(TXT.Text, BWR.Text)
                FROM dbo.BwReduktion      BWR WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON BWR.TextTID = TXT.TID
                                                                    AND TXT.LanguageCode = {0}
                ORDER BY Code", Session.User.LanguageCode);

            // allow changes
            qryBwEinsatzvereinbarung.CanUpdate = !isLeistungClosed;

            // apply values
            _faLeistungID = faLeistungID;
            picTitel.Image = titleImage;

            // get data
            qryBwEinsatzvereinbarung.Fill(@"
                SELECT ESV.*,
                       BaPersonID       = LEI.BaPersonID,
                       ZustaendigBW     = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
                       ThemenCodes      = (SELECT REPLACE(REPLACE(REPLACE(
                                            (SELECT BwThemaID AS thema
                                             FROM dbo.BwEinsatzvereinbarung_BwThema WITH (READUNCOMMITTED)
                                             WHERE BwEinsatzvereinbarungID = ESV.BwEinsatzvereinbarungID
                                             ORDER BY BwThemaID FOR XML PATH('')), '</thema><thema>',','),'</thema>',''),'<thema>','')),
                       ReduktionenCodes = (SELECT REPLACE(REPLACE(REPLACE(
                                            (SELECT BwReduktionID AS reduktion
                                             FROM dbo.BwEinsatzvereinbarung_BwReduktion WITH (READUNCOMMITTED)
                                             WHERE BwEinsatzvereinbarungID = ESV.BwEinsatzvereinbarungID
                                             ORDER BY BwReduktionID FOR XML PATH('')), '</reduktion><reduktion>',','),'</reduktion>',''),'<reduktion>',''))
                FROM dbo.BwEinsatzvereinbarung ESV WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.FaLeistung     LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = ESV.FaLeistungID
                WHERE ESV.FaLeistungID = {0};", faLeistungID, Session.User.LanguageCode);

            // insert new entry if not yet any entry found
            if (qryBwEinsatzvereinbarung.CanUpdate && qryBwEinsatzvereinbarung.Count < 1)
            {
                // create new entry
                qryBwEinsatzvereinbarung.Insert(null);
            }

            // set flag, used to init MA-control afterwards
            SetHadNoBWFlag();

            // load subcontrol-data
            ApplyAccompanyingData();

            // logging
            _logger.Debug("done");
        }

        public override bool OnAddData()
        {
            // check if insert is allowed
            if (!ActiveSQLQuery.CanUpdate)
            {
                // do nothing, main-query is locked
                return false;
            }

            // check tpg
            if (IsBegleiterTpgActive())
            {
                // check if we have a valid main-id
                if (_bwEinsatzvereinbarungID < 1)
                {
                    // show message
                    KissMsg.ShowError(Name, "NoEinsatzvereinbarungForPerson", "Die Einsatzvereinbarung wurde noch nicht gespeichert, es kann zurzeit kein/e Mitarbeiter/in hinzugefügt werden.");
                    return false;
                }

                // try to add a new row
                return (_ctlBegleiter.ActiveSQLQuery.Insert() != null);
            }

            // let base do stuff
            return base.OnAddData();
        }

        public override bool OnDeleteData()
        {
            // check tpg
            if (IsBegleiterTpgActive())
            {
                // try to delete current row
                return _ctlBegleiter.ActiveSQLQuery.Delete();
            }

            // let base do stuff
            return base.OnDeleteData();
        }

        public override void OnMoveFirst()
        {
            // check tpg
            if (IsBegleiterTpgActive())
            {
                // move to first row
                _ctlBegleiter.ActiveSQLQuery.First();
            }
            else
            {
                // let base do stuff
                base.OnMoveFirst();
            }
        }

        public override void OnMoveLast()
        {
            // check tpg
            if (IsBegleiterTpgActive())
            {
                // move to last row
                _ctlBegleiter.ActiveSQLQuery.Last();
            }
            else
            {
                // let base do stuff
                base.OnMoveLast();
            }
        }

        public override void OnMoveNext()
        {
            // check tpg
            if (IsBegleiterTpgActive())
            {
                // move to next row
                _ctlBegleiter.ActiveSQLQuery.Next();
            }
            else
            {
                // let base do stuff
                base.OnMoveNext();
            }
        }

        public override void OnMovePrevious()
        {
            // check tpg
            if (IsBegleiterTpgActive())
            {
                // move to previous row
                _ctlBegleiter.ActiveSQLQuery.Previous();
            }
            else
            {
                // let base do stuff
                base.OnMovePrevious();
            }
        }

        public override void OnRefreshData()
        {
            // refresh main-data
            ActiveSQLQuery.Refresh();

            // refresh sub-data
            _ctlBegleiter.ActiveSQLQuery.Refresh();
        }

        public override bool OnSaveData()
        {
            // logging
            _logger.Debug("call");

            // first try to save main-data and then try to save sub-data
            bool success = ActiveSQLQuery.Post() && _ctlBegleiter.ActiveSQLQuery.Post();

            // check if success and no id yet applied
            if (success && _hadNoBWEinsatzvereinbarungID)
            {
                // load data for users
                ApplyAccompanyingData();

                //Spalten via JOIN waren noch nicht initialisiert, das jetzt nachholen
                qryBwEinsatzvereinbarung.Refresh();
            }


            // return value
            return success;
        }

        public override void OnUndoDataChanges()
        {
            // check tpg
            if (IsBegleiterTpgActive())
            {
                // undo current changes
                _ctlBegleiter.ActiveSQLQuery.Cancel();
            }
            else
            {
                // let base do stuff
                base.OnUndoDataChanges();
            }
        }

        /// <summary>
        /// Reset flags for changed values
        /// </summary>
        public void ResetChangedFlags()
        {
            _ctlBegleiter.ResetMitarbeiterChangedFlags();
        }

        #endregion

        #region Private Methods

        private void ApplyAccompanyingData()
        {
            // logging
            _logger.Debug("call");

            // check if we have exactly one valid Einsatzvereinbarung
            if (qryBwEinsatzvereinbarung.Count == 1 && !DBUtil.IsEmpty(qryBwEinsatzvereinbarung["BwEinsatzvereinbarungID"]))
            {
                // get new id
                int newBwEinsatzvereinbarungID = Convert.ToInt32(qryBwEinsatzvereinbarung["BwEinsatzvereinbarungID"]);

                // validate
                if (_bwEinsatzvereinbarungID > 0 && _bwEinsatzvereinbarungID != newBwEinsatzvereinbarungID)
                {
                    // show error
                    KissMsg.ShowError(Name, "ChangedBwEinsatzvereinbarungID", "Schwerer Ausnahmefehler, die Referenz-ID für die Einsatzvereinbarung darf nicht verändert werden!");

                    // reset id
                    _bwEinsatzvereinbarungID = -1;

                    // do not continue
                    return;
                }

                // apply new id
                _bwEinsatzvereinbarungID = newBwEinsatzvereinbarungID;
            }

            // init the control
            _ctlBegleiter.Init(BaUtils.ModulID.BegleitetesWohnen, _bwEinsatzvereinbarungID, ActiveSQLQuery.CanUpdate);
        }

        private bool CompareQueryValueAndEditValue(string columnName, string editValue)
        {
            // get value of query
            string queryValue = DBUtil.IsEmpty(qryBwEinsatzvereinbarung[columnName]) ? string.Empty : Convert.ToString(qryBwEinsatzvereinbarung[columnName]);

            // validate empty
            if (string.IsNullOrEmpty(queryValue) && string.IsNullOrEmpty(editValue))
            {
                // values are equal
                return true;
            }

            // compare strings
            return queryValue == editValue;
        }

        private bool IsBegleiterTpgActive()
        {
            return tabEinsatzvereinbarung.IsTabSelected(tpgBegleiter);
        }

        /// <summary>
        /// Save changes in subtable for csv values
        /// </summary>
        /// <param name="bwEinsatzvereinbarungId">The id of BwEinsatzvereinbarung to which the entries belong</param>
        /// <param name="csvCodes">The currend unsaved csv list of values to save</param>
        /// <param name="tableType">The name of the table where the items come from</param>
        private void SaveCsvListInTable(int bwEinsatzvereinbarungId, string csvCodes, string tableType)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("bwEinsatzvereinbarungId='{0}', csvCodes='{1}', tableType='{2}'", bwEinsatzvereinbarungId, csvCodes, tableType);

            // setup table vars for dynamic access
            string tableName = string.Format("BwEinsatzvereinbarung_{0}", tableType);
            string tableTypeIdColName = string.Format("{0}ID", tableType);

            // validate csvCodes
            if (string.IsNullOrEmpty(csvCodes) || string.IsNullOrEmpty(csvCodes.Trim()))
            {
                csvCodes = "-1";
            }

            // create statement
            string sqlDeleteInsert = string.Format(@"
                --SQLCHECK_IGNORE--
                DELETE FROM dbo.{0}
                WHERE BwEinsatzvereinbarungID = {2} AND
                      {1} NOT IN ({3});                                         -- remove those which are no more selected

                INSERT INTO dbo.{0} (BwEinsatzvereinbarungID, {1}, Creator, Modifier)
                  SELECT BwEinsatzvereinbarungID = {2},
                         {1}                     = CONVERT(INT, FCN.SplitValue),
                         Creator                 = N'{4}',
                         Modifier                = N'{4}'
                  FROM dbo.fnSplitStringToValues(N'{3}', N',', 1) FCN
                  WHERE CONVERT(INT, FCN.SplitValue) > 0                        -- filter '-1' value
                    AND NOT EXISTS(SELECT TOP 1 1                               -- ensure entry does not yet exist
                                   FROM dbo.{0} SUB WITH (READUNCOMMITTED)
                                   WHERE SUB.BwEinsatzvereinbarungID = {2}
                                     AND SUB.{1} = CONVERT(INT, FCN.SplitValue));", tableName,
                tableTypeIdColName,
                bwEinsatzvereinbarungId,
                csvCodes,
                DBUtil.GetDBRowCreatorModifier());

            // logging
            _logger.DebugFormat("SQL='{0}'", sqlDeleteInsert);

            // DELETE and INSERT entries to match new selection
            DBUtil.ExecSQLThrowingException(sqlDeleteInsert);

            // logging
            _logger.Debug("done");
        }

        private void SetHadNoBWFlag()
        {
            // set flag, used to init MA-control afterwards
            _hadNoBWEinsatzvereinbarungID = _bwEinsatzvereinbarungID < 1;
        }

        #endregion

        #endregion
    }
}