using System;
using System.Data;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Administration
{
    /// <summary>
    /// Control, used for handling the right-group and assigned rights
    /// </summary>
    public partial class CtlUserGroup : KissUserControl
    {
        #region Fields

        #region Internal Constant/Read-Only Fields

        internal const string sqlUserText_DynaMask = @"CASE MSK.ModulID 
                                WHEN 2 THEN
                                  CASE MSK.FaPhaseCode
                                    WHEN 1 THEN 'FF-INT-'
                                    WHEN 2 THEN 'FF-BER-'
                                    ELSE 'FF-DOK-'
                                  END
                                WHEN 5 THEN
                                  CASE MSK.VmProzessCode
                                    WHEN 1  THEN 'VM-MAS-'
                                    WHEN 2  THEN 'VM-VAT-'
                                    WHEN 3  THEN 'VM-EA-'
                                    WHEN 31 THEN 'VM-EA-SIE-'
                                    WHEN 32 THEN 'VM-EA-TES-'
                                    WHEN 33 THEN 'VM-EA-ERB-'
                                    WHEN 4  THEN 'VM-PFL-'
                                    ELSE 'VM-'
                                  END
                                ELSE ''
                              END + MSK.DisplayText";
        internal const string sqlUserText_XClass = "CLS.MaskName";
        internal const string sqlUserText_XRight = "RGT.UserText";

        #endregion

        #region Private Constant/Read-Only Fields

        private const string COL_USERGROUPDESCRIPTION_ML = "DescriptionML";
        private const string COL_USERGROUPNAME_ML = "UserGroupNameML";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlUserGroup"/> class.
        /// </summary>
        public CtlUserGroup()
        {
            // init control
            InitializeComponent();

            // setup user rights
            SetupRights();

            // setup select statements for queries
            qryZugeteilt.SelectStatement = @"
                EXEC dbo.spXGetRightsAssignedUnassigned {0}, 1, 0, {1};";

            qryVerfuegbar.SelectStatement = @"
                EXEC dbo.spXGetRightsAssignedUnassigned {0}, 0, 1, {1};";

            // select first tab
            tabControl.SelectTab(tpgRechte);
        }

        #endregion

        #region EventHandlers

        private void CtlUserGroup_Load(object sender, EventArgs e)
        {
            SetupFieldName();

            // remove delete question to prevent message
            qryZugeteilt.DeleteQuestion = null;

            // fill data
            qryUserGroup.Fill(@"
                SELECT UGR.*,
                       --
                       UserGroupNameML = dbo.fnGetMLTextByDefault(UGR.UserGroupNameTID, {0}, UGR.UserGroupName),
                       DescriptionML   = dbo.fnGetMLTextByDefault(UGR.DescriptionTID, {0}, UGR.Description)
                FROM dbo.XUserGroup UGR WITH (READUNCOMMITTED)
                ORDER BY UserGroupNameML;", Session.User.LanguageCode);
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            // validate first
            if (!btnAddAll.Enabled || qryUserGroup.Count == 0 || !qryUserGroup.Post())
            {
                return;
            }

            // confirm first
            if (!KissMsg.ShowQuestion(Name, "ConfirmAddAll", "Wollen Sie wirklich alle verfügbaren Rechte zur ausgewählten Gruppe hinzufügen?", true))
            {
                return;
            }

            // add all rows
            foreach (DataRow row in qryVerfuegbar.DataTable.Rows)
            {
                qryZugeteilt.Insert();

                qryZugeteilt[DBO.XUserGroup_Right.UserGroupID] = qryUserGroup[DBO.XUserGroup.UserGroupID];
                qryZugeteilt[DBO.XUserGroup_Right.XClassID] = row["XClassID"];
                qryZugeteilt[DBO.XUserGroup_Right.ClassName] = row["ClassName"];
                qryZugeteilt[DBO.XUserGroup_Right.RightID] = row["RightID"];

                // copy MaskName only if current connection supports DynaMasks to prevent error
                if (Session.SupportDynaMask)
                {
                    qryZugeteilt[DBO.XUserGroup_Right.MaskName] = row["MaskName"];
                }

                qryZugeteilt.Post();
            }

            // update lists
            DisplayRights(true, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // validate first
                if (!btnAdd.Enabled || qryUserGroup.Count == 0 || qryVerfuegbar.Count == 0 || !OnSaveData())
                {
                    return;
                }

                // get all rows the user selected
                var rowHandles = grdVerfuegbar.View.GetSelectedRows();

                if (rowHandles == null || rowHandles.Length < 1)
                {
                    return;
                }

                // insert all rows the user selected
                foreach (var rowHandle in rowHandles)
                {
                    // add data
                    qryZugeteilt.Insert();

                    // apply values
                    qryZugeteilt[DBO.XUserGroup_Right.UserGroupID] = qryUserGroup[DBO.XUserGroup.UserGroupID];
                    qryZugeteilt[DBO.XUserGroup_Right.XClassID] = grvVerfuegbar.GetRowCellValue(rowHandle, grvVerfuegbar.Columns["XClassID"]);
                    qryZugeteilt[DBO.XUserGroup_Right.ClassName] = grvVerfuegbar.GetRowCellValue(rowHandle, grvVerfuegbar.Columns["ClassName"]);
                    qryZugeteilt[DBO.XUserGroup_Right.RightID] = grvVerfuegbar.GetRowCellValue(rowHandle, grvVerfuegbar.Columns["RightID"]);

                    // copy MaskName only if current connection supports DynaMasks to prevent error
                    if (Session.SupportDynaMask)
                    {
                        qryZugeteilt[DBO.XUserGroup_Right.MaskName] = grvVerfuegbar.GetRowCellValue(rowHandle, grvVerfuegbar.Columns["MaskName"]);
                    }

                    // save pending changes
                    qryZugeteilt.Post();
                }

                // refresh lists
                DisplayRights(true, true);

                // clear filter and set focus
                edtFilter.EditValue = null;
                edtFilter.Focus();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(Name, "ErrorAddItemBtnAdd_v02", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);
            }
        }

        private void btnRemoveAllUsers_Click(object sender, EventArgs e)
        {
            // ensure only admin can do this
            if (!Session.User.IsUserAdmin)
            {
                // disable button and cancel
                btnRemoveAllUsers.Enabled = false;
                return;
            }

            // validate first
            if (qryUserGroup.Count < 1 || DBUtil.IsEmpty(qryUserGroup[DBO.XUserGroup.UserGroupID]) || !OnSaveData())
            {
                // invalid selection, do nothing
                return;
            }

            // confirm action
            if (!KissMsg.ShowQuestion(Name, "ConfirmRemoveAllUsersFromRight", "Sollen wirklich alle {0} Benutzer aus der Gruppe '{1}' enfernt werden?", 0, 0, false, qryUser.Count, qryUserGroup[COL_USERGROUPNAME_ML]))
            {
                // user canceled
                return;
            }

            // log this event
            XLog.Create(GetType().FullName, LogLevel.INFO, "Removing all uses from assigned usergroup.", string.Format("XUserGroupID='{0}'", qryUserGroup[DBO.XUserGroup.UserGroupID]));

            // do remove all users from given user-group
            DBUtil.ExecSQL(@"
                DELETE UUG
                FROM dbo.XUser_UserGroup UUG
                WHERE UUG.UserGroupID = {0};", qryUserGroup[DBO.XUserGroup.UserGroupID]);

            // refresh display
            DisplayUsers();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            // validate first
            if (!btnRemoveAll.Enabled || qryUserGroup.Count == 0 || !OnSaveData())
            {
                return;
            }

            // confirm first
            if (!KissMsg.ShowQuestion(Name, "ConfirmRemoveAll", "Wollen Sie wirklich alle zugewiesenen Rechte von der ausgewählten Gruppe entfernen?", true))
            {
                return;
            }

            // remove all entries
            DBUtil.ExecSQL(@"
                DELETE UGR
                FROM dbo.XUserGroup_Right UGR
                WHERE UGR.UserGroupID = {0};", qryUserGroup[DBO.XUserGroup_Right.UserGroupID]);

            // refresh lists
            DisplayRights(true, true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // validate first
            if (!btnRemove.Enabled || qryZugeteilt.Count == 0 || !OnSaveData())
            {
                return;
            }

            // delete entry
            if (qryZugeteilt.Delete())
            {
                // refresh lists if delete was successfull
                DisplayRights(true, false);
            }
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            qryVerfuegbar.DataTable.DefaultView.RowFilter = string.Format("UserText LIKE '%{0}%'", edtFilter.EditValue);
        }

        private void grdVerfuegbar_DoubleClick(object sender, EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void grdZugeteilt_DoubleClick(object sender, EventArgs e)
        {
            btnRemove.PerformClick();
        }

        private void qryUserGroup_AfterInsert(object sender, EventArgs e)
        {
            // set default values
            qryUserGroup[DBO.XUserGroup.OnlyAdminVisible] = false;
            qryUserGroup.SetCreator();

            // focus control
            edtUserGroupName.Focus();
        }

        private void qryUserGroup_BeforePost(object sender, EventArgs e)
        {
            // validate must fields
            DBUtil.CheckNotNullField(edtUserGroupName, lblUserGroupName.Text);

            // set modifier and modified
            qryUserGroup.SetModifierModified();
        }

        private void qryUserGroup_PositionChanged(object sender, EventArgs e)
        {
            // refresh lists
            DisplayRights(true, true);

            // fill users
            DisplayUsers();

            // setup gridviews
            SetupGridViews();
        }

        private void qryUserGroup_PositionChanging(object sender, EventArgs e)
        {
            // save pending changes first
            if (!OnSaveData())
            {
                // cancel changing
                throw new KissCancelException();
            }
        }

        private void qryUserGroup_PostCompleted(object sender, EventArgs e)
        {
            // apply changed texts to showonly columns
            qryUserGroup[COL_USERGROUPNAME_ML] = edtUserGroupName.Text;
            qryUserGroup[COL_USERGROUPDESCRIPTION_ML] = edtDescription.EditValue;

            // prevent data changed (we did save data already)
            if (qryUserGroup.Row != null)
            {
                qryUserGroup.Row.AcceptChanges();
                qryUserGroup.RowModified = false;
                qryUserGroup.RefreshDisplay();
            }
        }

        private void qryZugeteilt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            qryUserGroup.RowModified = true;
        }

        private void tabControl_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // HACK: due to an unknown bug, the gridview will only change if visible...
            SetupGridViews();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Save pending changes
        /// </summary>
        /// <returns><c>True</c> if saving was successfull, otherwise <c>False</c></returns>
        public override bool OnSaveData()
        {
            // save both: assigned rights and group (first rights as saving the group will load the rights)
            return qryZugeteilt.Post() && qryUserGroup.Post();
        }

        #endregion

        #region Private Methods

        private void DisplayRights(bool refreshVerfuegbar, bool refreshZugeteilt)
        {
            // available
            if (refreshVerfuegbar)
            {
                qryVerfuegbar.Fill(qryUserGroup[DBO.XUserGroup.UserGroupID], Session.User.LanguageCode);
            }

            // assigned
            if (refreshZugeteilt)
            {
                qryZugeteilt.Fill(qryUserGroup[DBO.XUserGroup.UserGroupID], Session.User.LanguageCode);
            }
        }

        /// <summary>
        /// Display and refresh assigned users to current selected right
        /// </summary>
        private void DisplayUsers()
        {
            // show all assigned users for given right
            qryUser.Fill(@"
                SELECT UserName = dbo.fnGetLastFirstName(NULL, USR.Lastname, USR.Firstname) + ISNULL(' (' + USR.LogonName + ')', ''),
                       OrgUnit  = (SELECT TOP 1 ORG.ItemName
                                   FROM dbo.XOrgUnit_User    OUU WITH (READUNCOMMITTED)
                                     INNER JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                                   WHERE OUU.UserID = USR.UserID
                                     AND OrgUnitMemberCode = 2),
                       IsLocked = USR.IsLocked,
                       EMail    = USR.EMail
                FROM dbo.XUser_UserGroup UUG WITH (READUNCOMMITTED)
                  INNER JOIN dbo.XUser   USR WITH (READUNCOMMITTED) ON USR.UserID = UUG.UserID
                WHERE UUG.UserGroupID = {0}
                ORDER BY UserName;", qryUserGroup[DBO.XUserGroup.UserGroupID]);
        }

        private void SetupFieldName()
        {
            // usergroups
            colUserGroupName.FieldName = COL_USERGROUPNAME_ML;
            colOnlyAdminVisible.FieldName = DBO.XUserGroup.OnlyAdminVisible;
            colDescription.FieldName = COL_USERGROUPDESCRIPTION_ML;

            // user details
            colUserIsLocked.FieldName = DBO.XUser.IsLocked;
            colUserEmail.FieldName = DBO.XUser.EMail;
        }

        private void SetupGridViews()
        {
            grvXUser.OptionsView.ColumnAutoWidth = true;
            grvVerfuegbar.OptionsView.ColumnAutoWidth = true;
            grvZugeteilt.OptionsView.ColumnAutoWidth = true;
        }

        private void SetupRights()
        {
            // handle checkbox enabled (only admin can modify value)
            chkNurFuerAdminSichtbar.EditMode = Session.User.IsUserAdmin ? EditModeType.Normal : EditModeType.ReadOnly;

            // enable button only for admin!
            btnRemoveAllUsers.Enabled = Session.User.IsUserAdmin;
        }

        #endregion

        #endregion
    }
}