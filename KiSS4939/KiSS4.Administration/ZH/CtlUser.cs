using System;
using System.ComponentModel;
using System.Data;

using Kiss.BL.KissSystem;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Administration.ZH
{
    /// <summary>
    /// Control, used to CRUD users
    /// </summary>
    public partial class CtlUser : KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private bool _userModifiedPasswordField;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlUser"/> class.
        /// </summary>
        public CtlUser()
        {
            InitializeComponent();

            SetQryUserSQL();

            // prepare control depending on rights
            SetupRights();

            // setup qryUserRight
            qryUserRight.SelectStatement = @"
                SELECT
                  UserText  = MAX(COALESCE(" + CtlUserGroup.sqlUserText_XRight + ", " + CtlUserGroup.sqlUserText_XClass + (Session.SupportDynaMask ? @",
                    'EM ' + " + CtlUserGroup.sqlUserText_DynaMask : string.Empty) + @")),
                  MayInsert = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayInsert))),
                  MayUpdate = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayUpdate))),
                  MayDelete = CONVERT(BIT, MAX(CONVERT(INT, UGR.mayDelete)))
                FROM dbo.XUserGroup_Right        UGR WITH(READUNCOMMITTED)
                  INNER JOIN dbo.XUser_UserGroup UUG WITH(READUNCOMMITTED) ON UUG.UserGroupID = UGR.UserGroupID
                  LEFT  JOIN dbo.XRight          RGT WITH(READUNCOMMITTED) ON RGT.RightID = UGR.RightID
                  LEFT  JOIN dbo.XClass          CLS WITH(READUNCOMMITTED) ON CLS.ClassName = UGR.ClassName
                  LEFT  JOIN dbo.XModul          MOD WITH(READUNCOMMITTED) ON MOD.ModulID = CLS.ModulID" + (Session.SupportDynaMask ? @"
                  LEFT  JOIN dbo.DynaMask        MSK WITH(READUNCOMMITTED) ON MSK.MaskName = UGR.MaskName" : string.Empty) + @"
                WHERE UUG.UserID = {0}
                GROUP BY CLS.ClassName, RGT.RightID" + (Session.SupportDynaMask ? @", MSK.MaskName" : string.Empty) + @"
                ORDER BY 1;";
        }

        #endregion

        #region EventHandlers

        private void CtlUser_Load(object sender, EventArgs e)
        {
            SqlQuery qryXPermissionGroup = DBUtil.OpenSQL(@"
                SELECT PermissionGroupID, PermissionGroupName
                FROM dbo.XPermissionGroup WITH(READUNCOMMITTED)
                UNION ALL
                SELECT NULL, ''
                ORDER BY 2;");

            edtPermissionGroupID.LoadQuery(qryXPermissionGroup, "PermissionGroupID", "PermissionGroupName");
            edtGrantPermGroupID.LoadQuery(qryXPermissionGroup, "PermissionGroupID", "PermissionGroupName");

            qryZugeteilt.DeleteQuestion = null;

            tabControlSearch.SelectedTabIndex = 0;
            tabDetail.SelectedTabIndex = 0;

            qryUser.Fill();

            tpgSubUser.HideTab = true;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (qryUser.Count == 0 || qryVerfuegbar.Count == 0 ||
                (qryUser.Row.RowState == DataRowState.Added && !qryUser.Post()))
            {
                return;
            }

            DBUtil.ExecSQL(@"
                INSERT INTO dbo.XUser_UserGroup (UserID, UserGroupID)
                  SELECT {0}, UserGroupID
                  FROM XUserGroup UGR
                  WHERE NOT EXISTS (SELECT TOP 1 1
                                    FROM dbo.XUser_UserGroup
                                    WHERE UserID = {0}
                                      AND UserGroupID = UGR.UserGroupID);", qryUser[DBO.XUser.UserID]);

            DisplayGroups(true, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (qryUser.Count == 0 || qryVerfuegbar.Count == 0 || !qryUser.Post())
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
                qryZugeteilt[DBO.XUser_UserGroup.UserID] = qryUser[DBO.XUser.UserID];
                qryZugeteilt[DBO.XUser_UserGroup.UserGroupID] = grvVerfuegbar.GetRowCellValue(rowHandle, grvVerfuegbar.Columns[DBO.XUser_UserGroup.UserGroupID]);

                // save pending changes
                qryZugeteilt.Post();
            }

            DisplayGroups(true, true);
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (qryUser.Count == 0 || qryZugeteilt.Count == 0 || qryUser.Row.RowState == DataRowState.Added)
            {
                return;
            }

            DBUtil.ExecSQL("DELETE FROM dbo.XUser_UserGroup WHERE UserID = {0};", qryUser[DBO.XUser.UserID]);

            DisplayGroups(true, true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (qryUser.Count == 0 || qryZugeteilt.Count == 0 || qryUser.Row.RowState == DataRowState.Added)
            {
                return;
            }

            qryZugeteilt.Delete();
            DisplayGroups(true, false);
        }

        private void edtFilterBenutzergruppen_EditValueChanged(object sender, EventArgs e)
        {
            // do filtering
            qryVerfuegbar.DataTable.DefaultView.RowFilter = string.Format("UserGroupName LIKE '%{0}%'", edtFilterBenutzergruppen.EditValue);
        }

        private void edtGrantPermGroupID_QueryPopUp(object sender, CancelEventArgs e)
        {
            SqlQuery qry = (SqlQuery)edtGrantPermGroupID.Properties.DataSource;
            qry.Refresh();
            edtGrantPermGroupID.Properties.DropDownRows = Math.Min(qry.Count, 7);
        }

        private void edtPasswort_KeyDown(object sender, EventArgs e)
        {
            _userModifiedPasswordField = true;
        }

        private void edtPermissionGroupID_QueryPopUp(object sender, CancelEventArgs e)
        {
            SqlQuery qry = (SqlQuery)edtPermissionGroupID.Properties.DataSource;
            qry.Refresh();
            edtPermissionGroupID.Properties.DropDownRows = Math.Min(qry.Count, 7);
        }

        private void edtPrimaryUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtPrimaryUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryUser["PrimaryUserID"] = DBNull.Value;
                    qryUser["PrimaryUser"] = DBNull.Value;
                    return;
                }
            }

            using (var dlg = new KissLookupDialog())
            {
                e.Cancel = !dlg.SearchData(@"
                    SELECT ID$              = USR.UserID,
                           [Kürzel]         = LogonName,
                           [Mitarbeiter/in] = LastName + ISNULL(', ' + FirstName,''),
                           [Org.Einheit]    = XOU.ItemName
                    FROM dbo.XUser                USR WITH(READUNCOMMITTED)
                      LEFT JOIN dbo.XOrgUnit_User OUU WITH(READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                           AND OUU.OrgUnitMemberCode = 2
                      LEFT JOIN dbo.XOrgUnit      XOU WITH(READUNCOMMITTED) ON XOU.OrgUnitID = OUU.OrgUnitID
                    WHERE LastName + ISNULL(', ' + FirstName,'') LIKE '%' + {0} + '%'
                    ORDER BY [Kürzel];",
                    searchString,
                    e.ButtonClicked,
                    null,
                    null,
                    null);

                if (!e.Cancel)
                {
                    qryUser["PrimaryUserID"] = dlg["ID$"];
                    qryUser["PrimaryUser"] = dlg["Mitarbeiter/in"];
                }
            }
        }

        private void edtSB_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSB.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryUser["SachbearbeiterID"] = DBNull.Value;
                    qryUser["SB"] = DBNull.Value;
                    return;
                }
            }

            using (var dlg = new KissLookupDialog())
            {
                e.Cancel = !dlg.SearchData(@"
                    SELECT ID$              = USR.UserID,
                           [Kürzel]         = LogonName,
                           [Mitarbeiter/in] = LastName + ISNULL(', ' + FirstName,''),
                           [Org.Einheit]    = XOU.ItemName
                    FROM dbo.XUser                USR WITH(READUNCOMMITTED)
                      LEFT JOIN dbo.XOrgUnit_User OUU WITH(READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                           AND OUU.OrgUnitMemberCode = 2
                      LEFT JOIN dbo.XOrgUnit      XOU WITH(READUNCOMMITTED) ON XOU.OrgUnitID = OUU.OrgUnitID
                    WHERE LastName + ISNULL(', ' + FirstName,'') LIKE '%' + {0} + '%'
                    ORDER BY [Kürzel];",
                    searchString,
                    e.ButtonClicked,
                    null,
                    null,
                    null);

                if (!e.Cancel)
                {
                    qryUser["SachbearbeiterID"] = dlg["ID$"];
                    qryUser["SB"] = dlg["Mitarbeiter/in"];
                }
            }
        }

        private void grdVerfuegbar_DoubleClick(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                btnAdd.PerformClick();
            }
        }

        private void grdZugeteilt_DoubleClick(object sender, EventArgs e)
        {
            if (btnRemove.Enabled)
            {
                btnRemove.PerformClick();
            }
        }

        private void qryUser_AfterInsert(object sender, EventArgs e)
        {
            qryUser.SetCreator();
            edtLastName.Focus();
        }

        private void qryUser_AfterPost(object sender, EventArgs e)
        {
            qryUser["Password"] = "***";
            qryUser["RetypePassword"] = "***";
            _userModifiedPasswordField = false;
        }

        private void qryUser_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtLastName, lblLastName.Text);
            DBUtil.CheckNotNullField(edtLogonName, lblLogonName.Text);

            /* PASSWORD */
            var usrPassword = qryUser["Password"].ToString();
            var validationResult = KissServiceResult.Ok();
            try
            {
                if (_userModifiedPasswordField || qryUser.CurrentRowState == DataRowState.Added)
                {
                    var xUserService = Kiss.Infrastructure.IoC.Container.Resolve<XUserService>();
                    validationResult = xUserService.IsPasswordComplexCheck(usrPassword, false);

                    // create hash and hide password again
                    if (qryUser["Password"].ToString() != "***")
                    {
                        qryUser[DBO.XUser.PasswordHash] = Session.ScramblePassword(qryUser["Password"].ToString());
                    }
                }

            }
            finally
            {
                if (!validationResult.IsOk)
                {
                    KissMsg.ShowInfo(validationResult.GetWarningsAndErrors());
                    throw new KissCancelException();
                }
            }

            // Beim Sperren auf offene Fälle prüfen
            if (qryUser.ColumnModified(DBO.XUser.IsLocked) && Utils.ConvertToBool(qryUser[DBO.XUser.IsLocked]))
            {
                var countFaFall = Utils.ConvertToInt(
                    DBUtil.ExecuteScalarSQL(@"
                        SELECT COUNT(DISTINCT TMP.FaFallID)
                        FROM (
                          SELECT FaFallID
                          FROM dbo.FaLeistung
                          WHERE UserID = {0}
                            AND DatumBis IS NULL
                          
                          UNION ALL
                          
                          SELECT FaFallID
                          FROM dbo.FaFall
                          WHERE UserID = {0}
                            AND DatumBis IS NULL
                        ) TMP;",
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

                // Beim Sperren auf offene Abklärungen prüfen
                var countFaAbklaerung = Utils.ConvertToInt(DBUtil.ExecuteScalarSQL(@"
                    SELECT COUNT(1)
                    FROM dbo.FaAbklaerung
                    WHERE UserID = {0}
                      AND AusloeserCode <> -1
                      AND AbklaerungsberichtbeendetDatum IS NULL;",
                    qryUser[DBO.XUser.UserID]));

                if (countFaAbklaerung > 0)
                {
                    var msg = "Diesem Benutzer sind noch {0} aktive Abklärungen zugewiesen.\r\n" +
                              "Weisen Sie die aktiven Abklärungen einem anderen Benutzer zu.\r\n" +
                              "Wollen Sie den Benutzer trotzdem sperren?";

                    if (!KissMsg.ShowQuestion(typeof(CtlUser).Name, "SperrenOffeneAbklaerungen", msg, false, countFaAbklaerung))
                    {
                        qryUser[DBO.XUser.IsLocked] = false;
                        throw new KissCancelException();
                    }
                }
            }

            DBUtil.NewHistoryVersion();
            qryUser.SetModifierModified();
        }

        private void qryUser_PositionChanged(object sender, EventArgs e)
        {
            DisplayGroups(true, true);
            DisplaySubUsers();
            qryAbteilung.Fill(qryUser[DBO.XUser.UserID]);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnUndoDataChanges()
        {
            base.OnUndoDataChanges();
            _userModifiedPasswordField = false;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            chkSucheNurAktive.Checked = true;
            chkSucheNurAdmin.Checked = false;
            chkSucheNurBIAGAdmin.Checked = false;

            edtSucheLastName.Focus();
        }

        #endregion

        #region Private Methods

        private void DisplayGroups(bool refreshVerfuegbar, bool refreshZugeteilt)
        {
            if (refreshZugeteilt)
            {
                qryZugeteilt.Fill(qryUser[DBO.XUser.UserID]);
            }

            if (refreshVerfuegbar)
            {
                qryVerfuegbar.Fill(qryUser[DBO.XUser.UserID]);
            }

            qryUserRight.Fill(qryUser[DBO.XUser.UserID]);
        }

        private void DisplaySubUsers()
        {
            qrySubUser.Fill(qryUser[DBO.XUser.UserID]);
            tpgSubUser.HideTab = qrySubUser.Count == 0;
        }

        /// <summary>
        /// Set prepared sql-statement to qryUser
        /// </summary>
        private void SetQryUserSQL()
        {
            // set prepared sql-statement to qry
            qryUser.SelectStatement = string.Format(@"
                SELECT
                  USR.*,
                  Password = '***',
                  RetypePassword = '***',
                  Abteilung = ORG.ItemName,
                  SB = SB.NameVorname,
                  PrimaryUser = PRI.NameVorname
                FROM XUser                  USR WITH(READUNCOMMITTED)
                  LEFT  JOIN XOrgUnit_User  OUU WITH(READUNCOMMITTED) ON OUU.UserID = USR.UserID AND OUU.OrgUnitMemberCode = 2
                                                                     AND OUU.OrgUnitID = (SELECT MAX(OrgUnitID)
                                                                                          FROM XOrgUnit_User
                                                                                          WHERE UserID = USR.UserID
                                                                                            AND OrgUnitMemberCode = 2)
                  LEFT  JOIN XOrgUnit       ORG WITH(READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                  LEFT  JOIN vwUser         SB                        ON SB.UserID = USR.SachbearbeiterID
                  LEFT  JOIN vwUser         PRI                       ON PRI.UserID = USR.PrimaryUserID
                WHERE ({0} = 1 OR ISNULL(USR.IsUserBIAGAdmin, 0) = 0)  -- BIAGAdmins are only visible to BIAGAdmins due to security!
                ---  AND USR.LastName  LIKE {{edtSucheLastName}} + '%'
                ---  AND USR.FirstName LIKE {{edtSucheFirstName}} + '%'
                ---  AND USR.LogonName LIKE {{edtSucheLogonName}} + '%'
                ---  AND USR.UserID = {{edtSucheUserID}}
                ---  AND ORG.ItemName  LIKE {{edtSucheAbteilung}} + '%'
                ---  AND (USR.IsLocked = 0 OR {{chkSucheNurAktive}} = 0)
                ---  AND (USR.IsUserAdmin = 1 OR {{chkSucheNurAdmin.Checked}} = 0)
                ---  AND (USR.IsUserBIAGAdmin = 1 OR {{chkSucheNurBIAGAdmin.Checked}} = 0)
                ORDER BY LastName, FirstName;", DBUtil.SqlLiteral(Session.User.IsUserBIAGAdmin));
        }

        private void SetupRights()
        {
            // set rights to admin-checkboxes
            chkIsUserAdmin.EditMode = Session.User.IsUserAdmin ? EditModeType.Normal : EditModeType.ReadOnly;
            chkIsUserBIAGAdmin.EditMode = Session.User.IsUserBIAGAdmin ? EditModeType.Normal : EditModeType.ReadOnly;

            // show biag-admin stuff only if biag admin
            colIsUserBIAGAdmin.Visible = Session.User.IsUserBIAGAdmin;
            colSubIsUserBIAGAdmin.Visible = Session.User.IsUserBIAGAdmin;
            chkSucheNurBIAGAdmin.Visible = Session.User.IsUserBIAGAdmin;
            chkIsUserBIAGAdmin.Visible = Session.User.IsUserBIAGAdmin;
        }

        #endregion

        #endregion
    }
}