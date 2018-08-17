using System;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis.PI
{
    public partial class DlgBaIVBerechtigung : KissDialog
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private int _baPersonID = -1; // store the BaPersonID to use (>0 is valid)
        private bool _canDeleteData; // store flag if user can delete data
        private bool _canUpdateData; // store flag if user can update data
        private bool _hasSpecialRightToEdit; // store if user has special right to edit even if finished
        private bool _isActivated; // flag to store if Activated was executed (only once)
        private bool _origEntryHadDatumBis; // flag to store if original entry was closed (DatumBis IS NOT NULL)

        #endregion

        #endregion

        #region Constructors

        public DlgBaIVBerechtigung()
        {
            InitializeComponent();

            // setup rights (do before init!)
            SetupRights();

            // load default data
            Init(-1, "<lastName>", "<firstName>");

            // DebugOnly
            //this.Init(77923, "Einstein", "Albert");
        }

        #endregion

        #region EventHandlers

        private void DlgBaIVBerechtigung_Activated(Object sender, EventArgs e)
        {
            // check if already processed
            if (_isActivated)
            {
                // do nothing more
                return;
            }

            // logging
            _logger.Debug("enter");

            // select last row, due to unknown behaviour in DevExpress with CurrencyManager when ShowDialog(), we try here to move to last entry
            qryBaIVBerechtigung.Last();

            // set flag
            _isActivated = true;

            // logging
            _logger.Debug("done");
        }

        private void DlgBaIVBerechtigung_Load(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // attach event
            Activated += DlgBaIVBerechtigung_Activated;

            // logging
            _logger.Debug("done");
        }

        private void btnCloseDialog_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("clicked");

            // save pending changes
            if (!SavePendingChanges())
            {
                // cannot close dialog
                return;
            }

            // logging
            _logger.Debug("close dialog");

            // close dialog
            DialogResult = DialogResult.OK;
            Close();
        }

        private void qryBaIVBerechtigung_AfterInsert(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // apply current personid to new entry
            qryBaIVBerechtigung["BaPersonID"] = _baPersonID;

            // apply creator of row
            qryBaIVBerechtigung["Creator"] = DBUtil.GetDBRowCreatorModifier();

            // set focus to first edit field
            edtIVBerechtigungDatumVon.Focus();

            // reset flag for before-post-confirm-close-message
            SetDatumBisFlag(true);

            // logging
            _logger.Debug("done");
        }

        private void qryBaIVBerechtigung_AfterPost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // apply new data
            qryBaIVBerechtigung["BaIVBerechtigung"] = edtIVBerechtigungCode.Text;

            // set flag for before-post-confirm-close-message
            SetDatumBisFlag(false);

            // logging
            _logger.Debug("done");
        }

        private void qryBaIVBerechtigung_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current baPersonID={0}", _baPersonID));

            // VALIDATE
            // validate BaPersonID
            ValidateBaPersonID();

            // validate must fields
            DBUtil.CheckNotNullField(edtIVBerechtigungDatumVon, lblIVBerechtigungDatumVon.Text);
            DBUtil.CheckNotNullField(edtIVBerechtigungCode, lblIVBerechtigungCode.Text);

            // validate dates
            if (!IsDateRangeValid(edtIVBerechtigungDatumVon, edtIVBerechtigungDatumBis, lblIVBerechtigungDatumVon, lblIVBerechtigungDatumBis))
            {
                // date order is invalid, cannot continue (message already shown)
                throw new KissCancelException();
            }

            // validate with other existing data in db depending on mode
            //   no entry is allowed where DatumVon is between DatumVon..DatumBis of existing (other) entry
            //   no entry is allowed where DatumBis is between DatumVon..DatumBis of existing (other) entry
            if (Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    DECLARE @BaPersonID INT;
                    DECLARE @BaIVBerechtigungID INT;
                    DECLARE @DatumVon DATETIME;
                    DECLARE @DatumBis DATETIME;

                    SET @BaPersonID = ISNULL({0}, -1);
                    SET @BaIVBerechtigungID = ISNULL({1}, -1);
                    SET @DatumVon = {2};
                    SET @DatumBis = ISNULL({3}, '9999-12-31'); -- far far away...

                    SELECT COUNT(1)
                    FROM dbo.BaIVBerechtigung BIV WITH(READUNCOMMITTED)
                    WHERE BIV.BaPersonID = @BaPersonID AND
                          BIV.BaIVBerechtigungID <> @BaIVBerechtigungID AND
                          ((BIV.DatumVon <= @DatumVon AND ISNULL(BIV.DatumBis, '9999-12-31') >= @DatumVon) OR
                           (BIV.DatumVon <= @DatumBis AND ISNULL(BIV.DatumBis, '9999-12-31') >= @DatumBis) OR
                           (BIV.DatumVon >= @DatumVon AND ISNULL(BIV.DatumBis, '9999-12-31') <= @DatumBis));
                    ", _baPersonID, qryBaIVBerechtigung["BaIVBerechtigungID"], qryBaIVBerechtigung["DatumVon"], qryBaIVBerechtigung["DatumBis"])) > 0)
            {
                // invalid range of datarows for DatumVon/DatumBis
                edtIVBerechtigungDatumVon.Focus();
                KissMsg.ShowError(Name, "InvalidIVBerechtigungVonBis", "Ungültige Datumsangabe, die Werte dürfen sich nicht mit bestehenden Einträgen überschneiden.");
                throw new KissCancelException();
            }

            // FINISH
            // confirm if DatumBis was changed from empty to value
            if (!_origEntryHadDatumBis && !DBUtil.IsEmpty(qryBaIVBerechtigung["DatumBis"]))
            {
                // confirm close
                if (!KissMsg.ShowQuestion(Name, "ConfirmCloseEntryDatumBis", "Wollen Sie die aktuelle Periode wirklich abschliessen?", true))
                {
                    // cancel
                    throw new KissCancelException();
                }
            }

            // new history entry
            if (qryBaIVBerechtigung.RowModified)
            {
                DBUtil.NewHistoryVersion();
            }

            // logging
            _logger.Debug("done");
        }

        private void qryBaIVBerechtigung_PositionChanged(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // set updatemode depending on current datarow
            ApplyUpdateModeForRow();

            // set flag for before-post-confirm-close-message
            SetDatumBisFlag(false);

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static Boolean CanReadData()
        {
            // VARS
            bool isAdmin = Session.User.IsUserAdmin;
            bool canReadData;
            bool canUserInsert;
            bool canUserUpdate;
            bool canUserDelete;

            // set values
            Session.GetUserRight("DlgBaIVBerechtigung", out canReadData, out canUserInsert, out canUserUpdate, out canUserDelete);

            // return value
            return isAdmin || canReadData;
        }

        #endregion

        #region Public Methods

        public int GetCurrentIVBerechtigungCode()
        {
            return Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                SELECT ISNULL(dbo.fnBaGetIVBerechtigungStatus({0}, NULL, 0), -1);", _baPersonID));
        }

        public bool Init(int baPersonID, string firstName, string lastName)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("baPersonID={0}, firstName={1}, lastName={2}", baPersonID, firstName, lastName);

            // INIT
            // apply fields
            _baPersonID = baPersonID;

            // apply username
            lblBaPerson.Text = string.Format("{0}, {1} (Nr. {2})", lastName, firstName, baPersonID);

            // reset flag for before-post-confirm-close-message
            SetDatumBisFlag(true);

            // LOAD DATA
            qryBaIVBerechtigung.Fill(@"
                SELECT BIV.*,
                       BaIVBerechtigung = dbo.fnGetLOVMLText('BaIVBerechtigung', BIV.BaIVBerechtigungCode, {1})
                FROM dbo.BaIVBerechtigung BIV WITH(READUNCOMMITTED)
                WHERE BIV.BaPersonID = {0}
                ORDER BY BIV.DatumVon, BIV.DatumBis, BIV.BaIVBerechtigungID;", baPersonID, Session.User.LanguageCode);

            // set updatemode depending on current datarow
            ApplyUpdateModeForRow();

            // logging
            _logger.Debug("sel. last entry");

            // select last row
            qryBaIVBerechtigung.Last();

            // insert new entry if not yet any entry found
            if (qryBaIVBerechtigung.CanInsert && qryBaIVBerechtigung.Count < 1 && _baPersonID > 0)
            {
                qryBaIVBerechtigung.Insert(null);
            }

            // logging
            _logger.Debug("done");

            // good
            return true;
        }

        public override void Translate()
        {
            // read current client-text from label
            var labelText = lblBaPerson.Text;

            // apply translation
            base.Translate();

            // reapply client-text to label
            lblBaPerson.Text = labelText;
        }

        #endregion

        #region Private Methods

        private void ApplyUpdateModeForRow()
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("Count={0}, CanUpdateData={1}, CanDeleteData={2}", qryBaIVBerechtigung.Count, _canUpdateData, _canDeleteData);

            // init var ((only open items) or (closed items with specialrights) can be edited)
            var canUpdateDeleteCurrent = (DBUtil.IsEmpty(qryBaIVBerechtigung["DatumBis"]) || _hasSpecialRightToEdit);

            // setup query
            qryBaIVBerechtigung.CanUpdate = canUpdateDeleteCurrent && _canUpdateData;
            qryBaIVBerechtigung.CanDelete = canUpdateDeleteCurrent && _canDeleteData;

            // FIELDS
            qryBaIVBerechtigung.EnableBoundFields(qryBaIVBerechtigung.CanUpdate);

            // logging
            _logger.DebugFormat("qry.CanUpdate={0}, qry.CanDelete={1}, canUpdateDeleteCurrent={2}", qryBaIVBerechtigung.CanUpdate, qryBaIVBerechtigung.CanDelete, canUpdateDeleteCurrent);
            _logger.Debug("done");
        }

        private bool IsDateRangeValid(KissDateEdit edtDateFrom, KissDateEdit edtDateTo, KissLabel lblDateFrom, KissLabel lblDateTo)
        {
            // validate controls
            if (edtDateFrom == null || edtDateTo == null || lblDateFrom == null || lblDateTo == null)
            {
                // invalid controls
                KissMsg.ShowError(Name, "InvalidControlsToCheck", "Ungültige Controls, es müssen alle Controls instanziert sein.");
                return false;
            }

            // validate values
            //   1.) if only datefrom is given (infinit dateto)
            if (!DBUtil.IsEmpty(edtDateFrom.EditValue) && DBUtil.IsEmpty(edtDateTo.EditValue))
            {
                // only datefrom is given and set, we do not need to check any other values
                return true;
            }

            //   2.) if both dates are given
            if (DBUtil.IsEmpty(edtDateFrom.EditValue) || DBUtil.IsEmpty(edtDateTo.EditValue) || DBUtil.IsEmpty(lblDateFrom.Text) || DBUtil.IsEmpty(lblDateTo.Text))
            {
                // invalid controls
                KissMsg.ShowError(Name, "EmptyControlsToCheck", "Keinen Wert vorhanden, es muss für alle Controls einen Wert vorhanden sein.");
                return false;
            }

            // check if date-range is valid
            if (Convert.ToDateTime(edtDateFrom.EditValue) > Convert.ToDateTime(edtDateTo.EditValue))
            {
                // invalid range
                KissMsg.ShowError(Name, "InvalidDateRange", "Das Datum '{0}' ist ungültig - es darf nicht kleiner als das Datum '{1}' sein.", null, null, 0, 0, lblDateFrom.Text, lblDateTo.Text);
                return false;
            }

            // if we are here, everything is ok
            return true;
        }

        private bool SavePendingChanges()
        {
            // logging
            _logger.Debug("called");

            // check if we have an active sqlquery set
            return ActiveSQLQuery == null || ActiveSQLQuery.Post();
        }

        private void SetDatumBisFlag(bool resetFlag)
        {
            // check if required to reset
            if (resetFlag)
            {
                // reset flag
                _origEntryHadDatumBis = false;

                // do not continue
                return;
            }

            // set flag for before-post-confirm-close-message
            _origEntryHadDatumBis = !DBUtil.IsEmpty(qryBaIVBerechtigung["DatumBis"]);
        }

        private void SetupRights()
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("current baPersonID={0}", _baPersonID));

            // SPECIAL RIGHTS:
            // get if user has special right to edit even closed items
            _hasSpecialRightToEdit = DBUtil.UserHasRight("DlgBaIVBerechtigung_CanEditClosed");

            // VARS
            var isAdmin = Session.User.IsUserAdmin;
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

            // logger
            _logger.DebugFormat("isAdmin={0}, canReadData={1}, canUserInsert={2}, canUserUpdate={3}, canUserDelete={4}", isAdmin, canReadData, canUserInsert, canUserUpdate, canUserDelete);

            // IV-BERECHTIGUNG
            qryBaIVBerechtigung.CanInsert = isAdmin || canUserInsert;
            qryBaIVBerechtigung.CanUpdate = isAdmin || canUserUpdate;
            qryBaIVBerechtigung.CanDelete = isAdmin || canUserDelete;

            // FLAGS
            _canUpdateData = qryBaIVBerechtigung.CanUpdate;
            _canDeleteData = qryBaIVBerechtigung.CanDelete;

            // FIELDS
            qryBaIVBerechtigung.EnableBoundFields();

            // logging
            _logger.DebugFormat("CanUpdateData={0}, CanDeleteData={1}, HasSpecialRightToEdit={2}", _canUpdateData, _canDeleteData, _hasSpecialRightToEdit);
            _logger.Debug("done");
        }

        private void ValidateBaPersonID()
        {
            // check if we have a valid BaPersonID set
            if (_baPersonID < 1)
            {
                // cannot save data to this id
                KissMsg.ShowError(Name, "ValidationOnPostInvalidBaPersonID", "Die angegebene BaPersonID ist ungültig, es können keine Daten gespeichert werden.");

                // do not continue
                throw new KissCancelException();
            }
        }

        #endregion

        #endregion
    }
}