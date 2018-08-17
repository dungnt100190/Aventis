using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;
using log4net;

namespace KiSS4.Entlastungsdienst
{
    /// <summary>
    /// Control, used for Einsatzvereinbarung on Entlastungsdienst
    /// </summary>
    public partial class CtlEdEinsatzvereinbarung : KissUserControl
    {
        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly CtlFaBegleiterEntlaster _ctlEntlaster;

        private int _edEinsatzvereinbarungID = -1;
        private int _faLeistungID = -1;
        private bool _hadNoEDEinsatzvereinbarungID = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlEdEinsatzvereinbarung"/> class.
        /// </summary>
        public CtlEdEinsatzvereinbarung()
        {
            // init control
            InitializeComponent();

            // create and arrange control
            _ctlEntlaster = new CtlFaBegleiterEntlaster();
            _ctlEntlaster.Dock = DockStyle.Fill;
            tpgEntlaster.Controls.Add(_ctlEntlaster);

            // init with default values
            Init(null, null, -1, false);
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "EDEINSATZVEREINBARUNGID":
                    // check if we have an entry
                    if (qryEdEinsatzvereinbarung.Count < 1)
                    {
                        return -1;
                    }

                    // get current value
                    return qryEdEinsatzvereinbarung["EdEinsatzvereinbarungID"];

                case "FALEISTUNGID":
                    // get current value
                    return _faLeistungID;

                case "BAPERSONID":
                    // check if we have an entry
                    if (qryEdEinsatzvereinbarung.Count < 1)
                    {
                        return -1;
                    }

                    // get current value
                    return qryEdEinsatzvereinbarung["BaPersonID"];
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
            _logger.Debug("enter");
            _logger.DebugFormat("faLeistungID={0}, isLeistungClosed={1}", faLeistungID, isLeistungClosed);

            // reset ref-id
            _edEinsatzvereinbarungID = -1;

            // validate
            if (faLeistungID < 1)
            {
                // do not continue
                qryEdEinsatzvereinbarung.CanUpdate = false;
                qryEdEinsatzvereinbarung.EnableBoundFields(qryEdEinsatzvereinbarung.CanUpdate);

                _ctlEntlaster.ActiveSQLQuery.CanUpdate = false;
                _ctlEntlaster.ActiveSQLQuery.EnableBoundFields(_ctlEntlaster.ActiveSQLQuery.CanUpdate);
                return;
            }

            // allow changes
            qryEdEinsatzvereinbarung.CanUpdate = !isLeistungClosed;

            // apply values
            _faLeistungID = faLeistungID;
            picTitel.Image = titleImage;
            //this.lblTitel.Text	= titleName;

            // get reductions
            edtReduktionCodes.LookupSQL = string.Format(@"
                SELECT Code = EDR.EdReduktionID,
                       Text = ISNULL(TXT.Text, EDR.Text)
                FROM dbo.EdReduktion      EDR WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = EDR.TextTID
                                                                    AND TXT.LanguageCode = {0}
                ORDER BY Code", Session.User.LanguageCode);

            // fill data for Einsatzvereinbarung
            qryEdEinsatzvereinbarung.Fill(@"
                SELECT ESV.*,
                       BaPersonID       = LEI.BaPersonID,
                       ZustaendigED     = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
                       ReduktionenCodes = (SELECT REPLACE(REPLACE(REPLACE(
                                            (SELECT SEVR.EdReduktionID AS reduktion
                                             FROM dbo.EdEinsatzvereinbarung_EdReduktion SEVR WITH (READUNCOMMITTED)
                                             WHERE SEVR.EdEinsatzvereinbarungID = ESV.EdEinsatzvereinbarungID
                                             ORDER BY SEVR.EdReduktionID FOR XML PATH('')), '</reduktion><reduktion>',','),'</reduktion>',''),'<reduktion>',''))
                FROM dbo.EdEinsatzvereinbarung ESV WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.FaLeistung     LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = ESV.FaLeistungID
                WHERE ESV.FaLeistungID = {0}", faLeistungID, Session.User.LanguageCode);

            // insert new entry if not yet any entry found
            if (qryEdEinsatzvereinbarung.CanUpdate && qryEdEinsatzvereinbarung.Count < 1)
            {
                // create new entry
                qryEdEinsatzvereinbarung.Insert(null);

                // logging
                _logger.Debug("created new entry");
            }

            // set flag, used to init MA-control afterwards
            SetHadNoEDFlag();

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
            if (IsEntlasterTpgActive())
            {
                // check if we have a valid main-id
                if (_edEinsatzvereinbarungID < 1)
                {
                    // show message
                    KissMsg.ShowError(Name, "NoEinsatzvereinbarungForPerson", "Die Einsatzvereinbarung wurde noch nicht gespeichert, es kann zurzeit kein/e Mitarbeiter/in hinzugefügt werden.");
                    return false;
                }

                // try to add a new row
                return (_ctlEntlaster.ActiveSQLQuery.Insert() != null);
            }

            // let base do stuff
            return base.OnAddData();
        }

        public override bool OnDeleteData()
        {
            // check tpg
            if (IsEntlasterTpgActive())
            {
                // try to delete current row
                return _ctlEntlaster.ActiveSQLQuery.Delete();
            }

            // let base do stuff
            return base.OnDeleteData();
        }

        public override void OnMoveFirst()
        {
            // check tpg
            if (IsEntlasterTpgActive())
            {
                // move to first row
                _ctlEntlaster.ActiveSQLQuery.First();
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
            if (IsEntlasterTpgActive())
            {
                // move to last row
                _ctlEntlaster.ActiveSQLQuery.Last();
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
            if (IsEntlasterTpgActive())
            {
                // move to next row
                _ctlEntlaster.ActiveSQLQuery.Next();
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
            if (IsEntlasterTpgActive())
            {
                // move to previous row
                _ctlEntlaster.ActiveSQLQuery.Previous();
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
            _ctlEntlaster.ActiveSQLQuery.Refresh();
        }

        public override bool OnSaveData()
        {
            // first try to save main-data and then try to save sub-data
            bool success = ActiveSQLQuery.Post() && _ctlEntlaster.ActiveSQLQuery.Post();

            // check if properly saved and no id yet applied
            if (success && _hadNoEDEinsatzvereinbarungID)
            {
                //sicherstellen, dass Spalten via JOIN geladen sind
                qryEdEinsatzvereinbarung.Refresh();

                // load data for users
                ApplyAccompanyingData();
            }

            // return value
            return success;
        }

        public override void OnUndoDataChanges()
        {
            // check tpg
            if (IsEntlasterTpgActive())
            {
                // undo current changes
                _ctlEntlaster.ActiveSQLQuery.Cancel();
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
            _ctlEntlaster.ResetMitarbeiterChangedFlags();
        }

        private void ApplyAccompanyingData()
        {
            // check if we have exactly one valid Einsatzvereinbarung
            if (qryEdEinsatzvereinbarung.Count == 1 && !DBUtil.IsEmpty(qryEdEinsatzvereinbarung["EdEinsatzvereinbarungID"]))
            {
                // get new id
                int newEdEinsatzvereinbarungID = Convert.ToInt32(qryEdEinsatzvereinbarung["EdEinsatzvereinbarungID"]);

                // validate
                if (_edEinsatzvereinbarungID > 0 && _edEinsatzvereinbarungID != newEdEinsatzvereinbarungID)
                {
                    // show error
                    KissMsg.ShowError(Name, "ChangedEdEinsatzvereinbarungID", "Schwerer Ausnahmefehler, die Referenz-ID für die Einsatzvereinbarung darf nicht verändert werden!");

                    // reset id
                    _edEinsatzvereinbarungID = -1;

                    // do not continue
                    return;
                }

                // apply new id
                _edEinsatzvereinbarungID = newEdEinsatzvereinbarungID;
            }

            // init the control
            _ctlEntlaster.Init(BaUtils.ModulID.EntlastungsDienst, _edEinsatzvereinbarungID, ActiveSQLQuery.CanUpdate);
        }

        private bool CompareQueryValueAndEditValue(string columnName, string editValue)
        {
            // get value of query
            string queryValue = DBUtil.IsEmpty(qryEdEinsatzvereinbarung[columnName]) ? string.Empty : Convert.ToString(qryEdEinsatzvereinbarung[columnName]);

            // validate empty
            if (string.IsNullOrEmpty(queryValue) && string.IsNullOrEmpty(editValue))
            {
                // values are equal
                return true;
            }

            // compare strings
            return queryValue == editValue;
        }

        private void CtlEdEinsatzvereinbarung_Load(object sender, EventArgs e)
        {
            // select first tabPage
            tabEinsatzvereinbarung.SelectedTabIndex = 0;
        }

        private bool IsEntlasterTpgActive()
        {
            return tabEinsatzvereinbarung.IsTabSelected(tpgEntlaster);
        }

        private void qryEdEinsatzvereinbarung_AfterInsert(object sender, EventArgs e)
        {
            // apply person id
            qryEdEinsatzvereinbarung["FaLeistungID"] = _faLeistungID;

            // apply default values
            qryEdEinsatzvereinbarung["TypCode"] = 1;    // Entlastungsdienst
            qryEdEinsatzvereinbarung["ErstellungEV"] = DateTime.Today;

            // creator of row
            qryEdEinsatzvereinbarung.SetCreator();
        }

        private void qryEdEinsatzvereinbarung_AfterPost(object sender, EventArgs e)
        {
            // set flag, used to init MA-control afterwards
            SetHadNoEDFlag();

            try
            {
                // logging
                _logger.Debug("enter");

                // get current id
                _edEinsatzvereinbarungID = Convert.ToInt32(qryEdEinsatzvereinbarung["EdEinsatzvereinbarungID"]);

                // logging
                _logger.DebugFormat("_edEinsatzvereinbarungID='{0}'", _edEinsatzvereinbarungID);

                // validate
                if (_edEinsatzvereinbarungID < 1)
                {
                    throw new KissCancelException("Could not get valid value for EdEinsatzvereinbarungID.");
                }

                // validate
                if (!CompareQueryValueAndEditValue(edtReduktionCodes.DataMember, edtReduktionCodes.EditValue))
                {
                    // invalid data in query
                    throw new KissCancelException(string.Format("Invalid value in SqlQuery detected for '{0}'", edtReduktionCodes.DataMember));
                }

                // save changes in subtable for EdReduktion
                SaveCsvListInTable(_edEinsatzvereinbarungID, edtReduktionCodes.EditValue, "EdReduktion");

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

        private void qryEdEinsatzvereinbarung_BeforePost(object sender, EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtTyp, lblTyp.Text);
            DBUtil.CheckNotNullField(edtErstellungEV, lblErstellungEV.Text);

            // validate amounts
            if (!DBUtil.IsEmpty(qryEdEinsatzvereinbarung["TarifTag"]) &&
                Convert.ToDecimal(qryEdEinsatzvereinbarung["TarifTag"]) < 0.0m)
            {
                // invalid value
                edtTarifTag.Focus();

                // show info
                KissMsg.ShowInfo(Name, "InvalidTarifTag", "Der Geldbetrag für den Tagestarif darf nicht negativ sein.");

                // cancel
                throw new KissCancelException();
            }

            if (!DBUtil.IsEmpty(qryEdEinsatzvereinbarung["TarifNacht"]) &&
                Convert.ToDecimal(qryEdEinsatzvereinbarung["TarifNacht"]) < 0.0m)
            {
                // invalid value
                edtTarifNacht.Focus();

                // show info
                KissMsg.ShowInfo(Name, "InvalidTarifNacht", "Der Geldbetrag für den Nachttarif darf nicht negativ sein.");

                // cancel
                throw new KissCancelException();
            }

            if (!DBUtil.IsEmpty(qryEdEinsatzvereinbarung["TarifZuschlag"]) &&
                Convert.ToDecimal(qryEdEinsatzvereinbarung["TarifZuschlag"]) < 0.0m)
            {
                // invalid value
                edtTarifZuschlag.Focus();

                // show info
                KissMsg.ShowInfo(Name, "InvalidTarifZuschlag", "Der Geldbetrag für den Zugschlagstarif darf nicht negativ sein.");

                // cancel
                throw new KissCancelException();
            }

            Session.BeginTransaction();

            try
            {
                // apply modifier
                // TODO: not yet available on table: qryEdEinsatzvereinbarung.SetModifierModified();
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

        /// <summary>
        /// Save changes in subtable for csv values
        /// </summary>
        /// <param name="edEinsatzvereinbarungId">The id of EdEinsatzvereinbarung to which the entries belong</param>
        /// <param name="csvCodes">The currend unsaved csv list of values to save</param>
        /// <param name="tableType">The name of the table where the items come from</param>
        private void SaveCsvListInTable(int edEinsatzvereinbarungId, string csvCodes, string tableType)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("edEinsatzvereinbarungId='{0}', csvCodes='{1}', tableType='{2}'", edEinsatzvereinbarungId, csvCodes, tableType);

            // setup table vars for dynamic access
            string tableName = string.Format("EdEinsatzvereinbarung_{0}", tableType);
            string tableTypeIdColName = string.Format("{0}ID", tableType);

            // validate csvCodes
            if (string.IsNullOrEmpty(csvCodes) || string.IsNullOrEmpty(csvCodes.Trim()))
            {
                csvCodes = "-1";
            }

            // create statement
            string sqlDeleteInsert = string.Format(@" --SQLCHECK_IGNORE--
                DELETE FROM dbo.{0}
                WHERE EdEinsatzvereinbarungID = {2} AND
                      {1} NOT IN ({3});                                         -- remove those which are no more selected

                INSERT INTO dbo.{0} (EdEinsatzvereinbarungID, {1}, Creator, Modifier)
                  SELECT EdEinsatzvereinbarungID = {2},
                         {1}                     = CONVERT(INT, FCN.SplitValue),
                         Creator                 = N'{4}',
                         Modifier                = N'{4}'
                  FROM dbo.fnSplitStringToValues(N'{3}', N',', 1) FCN
                  WHERE CONVERT(INT, FCN.SplitValue) > 0                        -- filter '-1' value
                    AND NOT EXISTS(SELECT TOP 1 1                               -- ensure entry does not yet exist
                                   FROM dbo.{0} SUB WITH (READUNCOMMITTED)
                                   WHERE SUB.EdEinsatzvereinbarungID = {2}
                                     AND SUB.{1} = CONVERT(INT, FCN.SplitValue));", tableName,
                tableTypeIdColName,
                edEinsatzvereinbarungId,
                csvCodes,
                DBUtil.GetDBRowCreatorModifier());

            // logging
            _logger.DebugFormat("SQL='{0}'", sqlDeleteInsert);

            // DELETE and INSERT entries to match new selection
            DBUtil.ExecSQLThrowingException(sqlDeleteInsert);

            // logging
            _logger.Debug("done");
        }

        private void SetHadNoEDFlag()
        {
            // set flag, used to init MA-control afterwards
            _hadNoEDEinsatzvereinbarungID = _edEinsatzvereinbarungID < 1;
        }
    }
}