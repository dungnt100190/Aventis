using System;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Administration
{
    /// <summary>
    /// Control, used for managing KiSS bookmarks (without DynaMask bookmarks)
    /// </summary>
    public partial class CtlBookmarkStandard : KissSearchUserControl
    {
        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private bool _canUserDeleteData; // flag to store if user is allowed to delete data - defined by userrights
        private bool _canUserInsertData; // flag to store if user is allowed to insert data - defined by userrights
        private bool _canUserUpdateData; // flag to store if user is allowed to update data - defined by userrights

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlBookmarkStandard"/> class.
        /// </summary>
        public CtlBookmarkStandard()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // setup rights
            SetupRights();

            // fill names of tables
            FillTableNames();

            // init gui
            ResetCounterLabel();
        }

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set focus
            edtSucheCategory.Focus();

            // reset row-count label
            ResetCounterLabel();
        }

        protected override void RunSearch()
        {
            kissSearch.SelectParameters = new object[] { Session.User.LanguageCode };
            base.RunSearch();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // validate first
            if (qryBookmark.Count == 0 || !qryBookmark.Post())
            {
                return;
            }

            // create row
            DataRow row = qryBookmark.Row;
            qryBookmark.Insert();

            // set values
            qryBookmark.Row.ItemArray = row.ItemArray;
            qryBookmark["BookmarkName"] = string.Format("{0}_", qryBookmark["BookmarkName"]);
            qryBookmark["DisplayName"] = string.Format("{0}_", qryBookmark["DisplayName"]);
            SetDefaultSystemFlag();                 // system-flag default depends on current user's rights

            // save and refresh
            qryBookmark.Post();
            qryBookmark.Refresh();
        }

        /// <summary>
        /// Check if user is allowed to CRUD system bookmarks
        /// </summary>
        /// <returns><c>True</c> if user has rights to CRUD system bookmarks, otherwise <c>False</c></returns>
        private bool CanUserChangeSystemBookmarks()
        {
            // only biag-admin can change system-bookmarks
            return Session.User.IsUserBIAGAdmin;
        }

        private void chkReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            // show/hide copy-button
            btnCopy.Visible = !chkReadOnly.Checked;

            // handle rights
            SetupRights();

            // refresh data
            qryBookmark.Refresh();

            // setup rights depending on current row
            SetupRowRights();
        }

        private void CtlBookmarkStandard_Load(object sender, EventArgs e)
        {
            // set column edit
            colBookmarkCode.ColumnEdit = grdBookmark.GetLOVLookUpEdit("Bookmark");

            // start new search
            NewSearch();

            // run search
            tabControlSearch.SelectTab(tpgListe);
        }

        private void FillTableNames()
        {
            SqlQuery qryTableNames = new SqlQuery();

            qryTableNames.Fill(@"
                -- empty entry
                SELECT TableName = ''

                UNION

                -- tables
                SELECT TableName = TBL.name
                FROM sys.tables TBL WITH (READUNCOMMITTED)

                UNION

                -- views
                SELECT TableName = VWS.name
                FROM sys.views VWS WITH (READUNCOMMITTED)
                ORDER BY TableName");

            foreach (DataRow row in qryTableNames.DataTable.Rows)
            {
                // apply items to combobox
                edtTableName.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(row["TableName"]));
                edtSucheTableName.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(row["TableName"]));
            }
        }

        /// <summary>
        /// Check if current bookmark is a system-bookmark
        /// </summary>
        /// <returns><c>True</c> if system-flag is set and true, otherwise false</returns>
        private bool IsSytemEntry()
        {
            return (!DBUtil.IsEmpty(qryBookmark["System"]) && Convert.ToBoolean(qryBookmark["System"]));
        }

        private void qryBookmark_AfterFill(object sender, EventArgs e)
        {
            // set amount of entries found
            lblRowCount.Text = KissMsg.GetMLMessage("CtlBookmarkStandard", "LabelRowCount", "Anzahl Datensätze: {0}", qryBookmark.Count);
        }

        private void qryBookmark_AfterInsert(object sender, EventArgs e)
        {
            qryBookmark["SQL"] = "SELECT NULL";
            qryBookmark["BookmarkCode"] = 1;        // Text
            SetDefaultSystemFlag();                 // system-flag default depends on current user's rights

            edtCategory.Focus();
        }

        private void qryBookmark_AfterPost(object sender, EventArgs e)
        {
            // apply lookup fields to display-only column
            qryBookmark["Modul"] = edtModulID.Text;
        }

        private void qryBookmark_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // validate if change is allowed (SECURITY PURPOSE)
            if (SystemBookmarkWithNoRights())
            {
                // user wants to delete a system-bookmark: show message and cancel
                KissMsg.ShowError("CtlBookmarkStandard", "NoPermissionToDeleteSystemBM", "System-Textmarken dürfen nur von berechtigten Personen gelöscht werden.");

                // cancel
                throw new KissCancelException();
            }
        }

        private void qryBookmark_BeforePost(object sender, EventArgs e)
        {
            // validate if change is allowed (SECURITY PURPOSE)
            if (SystemBookmarkWithNoRights())
            {
                // user has changed a system-bookmark: show message and cancel
                KissMsg.ShowError("CtlBookmarkStandard", "NoPermissionToChangeSystemBM", "Die gemachten Änderungen können nicht gespeichert werden. System-Textmarken dürfen nur von berechtigten Personen verändert werden.");

                // cancel
                throw new KissCancelException();
            }

            // validate must-fields
            DBUtil.CheckNotNullField(edtCategory, lblCategory.Text);
            DBUtil.CheckNotNullField(edtBookmarkName, lblBookmarkName.Text);
            DBUtil.CheckNotNullField(edtBookmarkCode, lblBookmarkCode.Text);
            DBUtil.CheckNotNullField(edtSQL, lblSQL.Text);
        }

        private void qryBookmark_PositionChanged(object sender, EventArgs e)
        {
            // setup rights depending on current row
            SetupRowRights();
        }

        private void ResetCounterLabel()
        {
            // remove current text
            lblRowCount.Text = "";

            // do it
            ApplicationFacade.DoEvents();
        }

        /// <summary>
        /// Set the default value for "System" flag of new entries
        /// </summary>
        private void SetDefaultSystemFlag()
        {
            qryBookmark["System"] = CanUserChangeSystemBookmarks();     // system-flag default depends on current user's rights
        }

        private void SetLblRowCountPosition()
        {
            // set position of label due to splitter moving
            lblRowCount.Top = tabControlSearch.Height - 23;
            lblRowCount.Left = tabControlSearch.Width - lblRowCount.Width - 9;
        }

        private void SetRightsOfQuery()
        {
            // init query (depending on user's-rights and locked-state)
            qryBookmark.CanInsert = _canUserInsertData && !chkReadOnly.Checked;
            qryBookmark.CanUpdate = _canUserUpdateData && !chkReadOnly.Checked;
            qryBookmark.CanDelete = _canUserDeleteData && !chkReadOnly.Checked;
        }

        private void SetupRights()
        {
            // logging
            _logger.Debug("enter");

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

            // apply members
            _canUserInsertData = canUserInsert;
            _canUserUpdateData = canUserUpdate;
            _canUserDeleteData = canUserDelete;

            // logging
            _logger.DebugFormat("canReadData='{0}', canUserInsert='{1}', canUserUpdate='{2}', canUserDelete='{3}'", canReadData, canUserInsert, canUserUpdate, canUserDelete);

            // setup CanInsert/Update/Delete on query
            SetRightsOfQuery();

            // setup checkbox "readonly"
            chkReadOnly.EditMode = (canUserInsert || canUserUpdate || canUserDelete) ? Kiss.Interfaces.UI.EditModeType.Normal : Kiss.Interfaces.UI.EditModeType.ReadOnly; // checkbox is locked if user cannot insert or update or delete bookmarks

            // setup checkbox "system"
            chkSystem.EditMode = CanUserChangeSystemBookmarks() ? Kiss.Interfaces.UI.EditModeType.Normal : Kiss.Interfaces.UI.EditModeType.ReadOnly; // checkbox is locked if user cannot change system-bookmarks

            // enable bound fields
            qryBookmark.EnableBoundFields();

            // logging
            _logger.DebugFormat("qryBookmark.CanInsert='{0}', qryBookmark.CanUpdate='{1}', qryBookmark.CanDelete='{2}'", qryBookmark.CanInsert, qryBookmark.CanUpdate, qryBookmark.CanDelete);
            _logger.Debug("done");
        }

        private void SetupRowRights()
        {
            // logging
            _logger.Debug("enter");

            // check if current row is system-bookmark where user has no rights and current mode is non-readonly
            if (SystemBookmarkWithNoRights() && !chkReadOnly.Checked)
            {
                // logging
                _logger.Debug("SystemBookmarkWithNoRights()=true and not readonly-mode >> lock update/delete");

                // user has no rights to edit system-bookmark > lock update/delete (insert is not important here)
                qryBookmark.CanUpdate = false;
                qryBookmark.CanDelete = false;
            }
            else
            {
                // update state depends on current rights
                SetRightsOfQuery();
            }

            // refresh controls depending on update-mode (otherwise controls would be enabled anyway)
            qryBookmark.EnableBoundFields(qryBookmark.CanUpdate);

            // logging
            _logger.DebugFormat("qryBookmark.CanInsert='{0}', qryBookmark.CanUpdate='{1}', qryBookmark.CanDelete='{2}'", qryBookmark.CanInsert, qryBookmark.CanUpdate, qryBookmark.CanDelete);
            _logger.Debug("done");
        }

        /// <summary>
        /// Check if current bookmark is a system-bookmark and user has no rights to edit those
        /// </summary>
        /// <returns><c>True</c> if user has no rights to edit current system-bookmark</returns>
        private bool SystemBookmarkWithNoRights()
        {
            return (IsSytemEntry() && !CanUserChangeSystemBookmarks());
        }

        private void tabControlSearch_Resize(object sender, EventArgs e)
        {
            // set position of label
            SetLblRowCountPosition();
        }
    }
}