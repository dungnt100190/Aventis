using System;
using System.Data;
using DevExpress.XtraGrid.Columns;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
    /// <summary>
    /// Class used in BusinessDesigner to display rights associated with class or mask
    /// </summary>
    public partial class CtlXRight : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private string _className;
        private string _maskName;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlXRight"/> class.
        /// </summary>
        public CtlXRight()
        {
            // init control
            InitializeComponent();

            SetupGrid();

            // set and check rights
            SetupRights();

            if (!Session.SupportDynaMask)
            {
                // remove MaskName-part of queries
                qryVerfuegbar.SelectStatement = qryVerfuegbar.SelectStatement.Replace(@"ISNULL(MEM.MaskName, '') = ISNULL({2}, '')", "1 = 1");
                qryZugeteilt.SelectStatement = qryZugeteilt.SelectStatement.Replace(@"ISNULL(MEM.MaskName, '') = ISNULL({2}, '')", "1 = 1");
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get and set the current used classname
        /// </summary>
        internal string ClassName
        {
            get { return _className; }
            set
            {
                LoadData(value, _maskName);
            }
        }

        /// <summary>
        /// Get and set the current used maskname (dynamask)
        /// </summary>
        internal string MaskName
        {
            get { return _maskName; }
            set
            {
                LoadData(_className, value);
            }
        }

        #endregion

        #region EventHandlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // check if valid
            if (!btnAdd.Enabled || qryXRight.Count == 0 || qryVerfuegbar.Count == 0 || !qryXRight.Post())
            {
                return;
            }

            // get all rows the user selected
            int[] rowHandles = grdXUserGroup.View.GetSelectedRows();

            if (rowHandles == null || rowHandles.Length < 1)
            {
                return;
            }

            // insert all rows the user selected
            foreach (int rowHandle in rowHandles)
            {
                // create new row
                qryZugeteilt.Insert();

                // apply data
                qryZugeteilt["ClassName"] = qryXRight["ClassName"];
                qryZugeteilt["RightID"] = qryXRight["RightID"];

                if (Session.SupportDynaMask)
                {
                    qryZugeteilt["MaskName"] = qryXRight["MaskName"];
                }

                qryZugeteilt["UserGroupID"] = grdXUserGroup.View.GetRowCellValue(rowHandle, grdXUserGroup.View.Columns["UserGroupID"]);
                qryZugeteilt["UserGroupName"] = grdXUserGroup.View.GetRowCellValue(rowHandle, grdXUserGroup.View.Columns["UserGroupName"]);

                // save
                qryZugeteilt.Post();
            }

            // update list
            FillGroupData();

            // clear filter and set focus
            edtFilter.EditValue = null;
            edtFilter.Focus();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            // validate first
            if (!btnAddAll.Enabled || qryXRight.Count == 0 || qryVerfuegbar.Count == 0)
            {
                return;
            }

            if (qryXRight.Row.RowState == DataRowState.Added && !qryXRight.Post())
            {
                return;
            }

            // start transaction
            Session.BeginTransaction();

            try
            {
                if (Session.SupportDynaMask)
                {
                    // remove all entries and reinsert values (with dynamask)
                    DBUtil.ExecSQLThrowingException(@"
                        DELETE FROM dbo.XUserGroup_Right
                        WHERE ISNULL(ClassName, '') = ISNULL({0}, '') AND
                              ISNULL(RightID, 0)    = ISNULL({1}, 0) AND
                              ISNULL(MaskName, '')  = ISNULL({2}, '')", qryXRight["ClassName"], qryXRight["RightID"], qryXRight["MaskName"]);

                    DBUtil.ExecSQL(@"--SQLCHECK_IGNORE--
                        INSERT INTO dbo.XUserGroup_Right (ClassName, RightID, MaskName, UserGroupID)
                          SELECT {0}, {1}, {2}, TMP.UserGroupID
                          FROM (" + this.qryVerfuegbar.SelectStatement.Replace("ORDER BY GRP.UserGroupName", "") + ") TMP", qryXRight["ClassName"], qryXRight["RightID"], qryXRight["MaskName"]);
                }
                else
                {
                    // remove all entries and reinsert values (no dynamask)
                    DBUtil.ExecSQLThrowingException(@"
                        DELETE FROM dbo.XUserGroup_Right
                        WHERE ISNULL(ClassName, '') = ISNULL({0}, '') AND
                              ISNULL(RightID, 0)    = ISNULL({1}, 0)", qryXRight["ClassName"], qryXRight["RightID"]);

                    DBUtil.ExecSQL(@"--SQLCHECK_IGNORE--
                        INSERT INTO dbo.XUserGroup_Right (ClassName, RightID, UserGroupID)
                          SELECT {0}, {1}, TMP.UserGroupID
                          FROM (" + this.qryVerfuegbar.SelectStatement.Replace("ORDER BY GRP.UserGroupName", "") + ") TMP", qryXRight["ClassName"], qryXRight["RightID"]);
                }

                // success, commit now
                Session.Commit();
            }
            catch (Exception ex)
            {
                // do rollback
                Session.Rollback();

                // show message
                KissMsg.ShowError("CtlXRight", "ErrorAddingAllItems", "Es ist ein Fehler beim Hinzufügen aller Gruppen aufgetreten. Die Aktion wurde rückgängig gemacht.", ex);
            }

            // refresh list
            FillGroupData();

            // clear filter and set focus
            edtFilter.EditValue = null;
            edtFilter.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // validate first
            if (!btnRemove.Enabled || qryXRight.Count == 0 || qryZugeteilt.Count == 0 || qryXRight.Row.RowState == DataRowState.Added)
            {
                return;
            }

            // remove current entry
            qryZugeteilt.DeleteQuestion = null;
            qryZugeteilt.Delete();

            // refresh list
            FillGroupData();

            // clear filter and set focus
            edtFilter.EditValue = null;
            edtFilter.Focus();
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            // validate first
            if (!btnRemoveAll.Enabled || qryXRight.Count == 0 || qryZugeteilt.Count == 0 || qryXRight.Row.RowState == DataRowState.Added)
            {
                return;
            }

            // remove all entries
            if (Session.SupportDynaMask)
            {
                // remove all entries (with dynamask)
                DBUtil.ExecSQLThrowingException(@"
                    DELETE FROM dbo.XUserGroup_Right
                    WHERE ISNULL(ClassName, '') = ISNULL({0}, '') AND
                          ISNULL(RightID, 0)    = ISNULL({1}, 0) AND
                          ISNULL(MaskName, '')  = ISNULL({2}, '')", qryXRight["ClassName"], qryXRight["RightID"], qryXRight["MaskName"]);
            }
            else
            {
                // remove all entries (no dynamask)
                DBUtil.ExecSQLThrowingException(@"
                    DELETE FROM dbo.XUserGroup_Right
                    WHERE ISNULL(ClassName, '') = ISNULL({0}, '') AND
                          ISNULL(RightID, 0)    = ISNULL({1}, 0)", qryXRight["ClassName"], qryXRight["RightID"]);
            }

            // refresh list
            FillGroupData();

            // clear filter and set focus
            edtFilter.EditValue = null;
            edtFilter.Focus();
        }

        private void edtFilter_EditValueChanged(object sender, EventArgs e)
        {
            // do filtering
            qryVerfuegbar.DataTable.DefaultView.RowFilter = String.Format("UserGroupName LIKE '%{0}%'", edtFilter.EditValue);
        }

        private void grdXUserGroup_DoubleClick(object sender, System.EventArgs e)
        {
            this.btnAdd_Click(btnAdd, e);
        }

        private void qryXRight_AfterInsert(object sender, EventArgs e)
        {
            // setup default values
            this.qryXRight["ClassName"] = _className;
            this.qryXRight["Type"] = 1;                 // specialright
            this.qryXRight["RightName"] = string.Format("{0}_", _className);
            this.qryXRight["Creator"] = DBUtil.GetDBRowCreatorModifier();
            this.qryXRight["Created"] = DateTime.Today;

            // set focus
            this.edtRightName.Focus();

            // select text to change by default
            this.edtRightName.SelectionStart = _className.Length + 1;
        }

        private void qryXRight_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            // handle controls (only biagadmin can change anything)
            if (!Session.User.IsUserBIAGAdmin || !(this.qryXRight["Type"] is int) || Convert.ToInt32(this.qryXRight["Type"]) != 1)
            {
                // cannot delete entry, no permission or invalid type
                KissMsg.ShowInfo("CtlXRight", "CannotDeleteEntry", "Dieser Eintrag kann nicht gelöscht werden.");

                // cancel
                throw new KissCancelException();
            }
        }

        private void qryXRight_BeforeInsert(object sender, EventArgs e)
        {
            // validate, can only insert new rights if classname is given
            if (DBUtil.IsEmpty(_className))
            {
                throw new KissCancelException();
            }
        }

        private void qryXRight_BeforePost(object sender, EventArgs e)
        {
            // check rights
            if (!IsUserAllowedToChangeRights())
            {
                // show message
                KissMsg.ShowError("CtlXRight", "NoRightsToChangeRights", "Sie besitzen keine Rechte, diese Daten zu verändern.");

                // cancel
                throw new KissCancelException();
            }

            // check type
            if (!(this.qryXRight["Type"] is int) || Convert.ToInt32(this.qryXRight["Type"]) < 0 || Convert.ToInt32(this.qryXRight["Type"]) > 2)
            {
                // show message
                KissMsg.ShowError("CtlXRight", "InvalidTypeToSaveRights", "Die vorhandenen Daten sind ungültig und können nicht gespeichert werden.");

                // cancel
                throw new KissCancelException();
            }

            // do action depending on type
            switch (Convert.ToInt32(this.qryXRight["Type"]))
            {
                case 0:     // XClass
                    // do only update on mask-name (no new entries and no other changes)
                    if (qryXRight.Row.RowState == DataRowState.Modified)
                    {
                        // validate mustfields
                        DBUtil.CheckNotNullField(this.edtDescription, this.lblDescription.Text);

                        // update description of current entry
                        DBUtil.ExecSQLThrowingException(@"
                            UPDATE dbo.XClass
                            SET MaskName = {0}
                            WHERE ClassName = {1}", qryXRight["DescriptionInView"], qryXRight["ClassName"]);
                    }
                    else
                    {
                        // show message
                        KissMsg.ShowError("CtlXRight", "CanOnlyModifyXClassEntries", "Bei dieser Art von Recht können nur Änderungen der Beschreibung gespeichert werden.");

                        // cancel
                        throw new KissCancelException();
                    }
                    break;

                case 1:     // XRight (specialright)
                    // validate must-fields
                    DBUtil.CheckNotNullField(this.edtRightName, this.lblRightName.Text);

                    if (edtDescription.EditMode == EditModeType.Normal)
                    {
                        DBUtil.CheckNotNullField(this.edtDescription, this.lblDescription.Text);
                    }

                    // depending on current mode, we do insert or update
                    if (qryXRight.Row.RowState == DataRowState.Added)
                    {
                        // create new entry
                        DBUtil.ExecSQLThrowingException(@"
                            INSERT INTO dbo.XRight (ClassName, RightName, UserText, Description, Creator, Created, Modifier, Modified)
                            VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {4}, {5})",
                            qryXRight["ClassName"],
                            qryXRight["RightName"],
                            qryXRight["DescriptionInView"],
                            "",
                            DBUtil.GetDBRowCreatorModifier(),
                            DateTime.Today,
                            DBUtil.GetDBRowCreatorModifier(),
                            DateTime.Today
                        );
                    }
                    else if (qryXRight.Row.RowState == DataRowState.Modified)
                    {
                        // update current entry
                        DBUtil.ExecSQLThrowingException(@"
                            UPDATE dbo.XRight
                            SET RightName = {0},
                                UserText  = {1}
                            WHERE RightID = {2}", qryXRight["RightName"], qryXRight["DescriptionInView"], qryXRight["RightID"]);
                    }
                    else
                    {
                        // show message
                        KissMsg.ShowError("CtlXRight", "InvalidRowStateXRight", "Ungültiger Zustand des aktuellen Datensatzes (RowState='{0}'), die Änderungen können nicht gespeichert werden.", null, null, qryXRight.Row.RowState);

                        // cancel
                        throw new KissCancelException();
                    }

                    break;

                default:    // DynaMask or anything else
                    // do not allow any changes
                    KissMsg.ShowError("CtlXRight", "ChangesToDynaMaskProhibited", "Änderungen an DynaMask-Rechten werden nicht unterstützt.");

                    // cancel
                    return;
            }

            // discard any changes (we saved above)
            qryXRight.RowModified = false;
            qryXRight.Row.AcceptChanges();

            // post other data
            this.qryZugeteilt.Post();

            // refresh data
            qryXRight.Refresh();
        }

        private void qryXRight_PositionChanged(object sender, EventArgs e)
        {
            // handle controls (only biagadmin can change anything)
            if (Session.User.IsUserBIAGAdmin && this.qryXRight["Type"] is int)
            {
                switch (Convert.ToInt32(this.qryXRight["Type"]))
                {
                    case 0:     // XClass
                        this.edtRightName.EditMode = EditModeType.ReadOnly;
                        this.edtDescription.EditMode = EditModeType.Normal;
                        break;

                    case 1:     // XRight (specialright)
                        this.edtRightName.EditMode = EditModeType.Normal;
                        this.edtDescription.EditMode = EditModeType.Normal;
                        break;

                    default:    // DynaMask or anything else
                        this.edtRightName.EditMode = EditModeType.ReadOnly;
                        this.edtDescription.EditMode = EditModeType.ReadOnly;
                        break;
                }

                // update controls
                this.qryXRight.EnableBoundFields();
            }
            else
            {
                // no rights
                this.edtRightName.EditMode = EditModeType.ReadOnly;
                this.edtDescription.EditMode = EditModeType.ReadOnly;
            }

            // save pending changes
            qryZugeteilt.Post();

            // fill data of group-grids
            FillGroupData();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnSaveData()
        {
            // save both: rights and assigned groups
            return qryXRight.Post() && qryZugeteilt.Post();
        }

        #endregion

        #region Private Methods

        private void FillGroupData()
        {
            // override defaults
            grvXUserGroup.OptionsView.ColumnAutoWidth = true;

            // fill group-data
            this.qryVerfuegbar.Fill(this.qryXRight["ClassName"], this.qryXRight["RightID"], this.qryXRight["MaskName"]);
            this.qryZugeteilt.Fill(this.qryXRight["ClassName"], this.qryXRight["RightID"], this.qryXRight["MaskName"]);
        }

        private bool IsUserAllowedToChangeRights()
        {
            return Session.Active && Session.User.IsUserBIAGAdmin;
        }

        private void LoadData(string className, string maskName)
        {
            // save pending changes first
            if (!this.qryXRight.Post())
            {
                // cancel, do not load any other data
                return;
            }

            // validate values
            if (!DBUtil.IsEmpty(maskName) && (DBUtil.IsEmpty(className) || className == "CtlDynaMask"))
            {
                // we use dynamask
                this._className = null;
                this._maskName = maskName;
            }
            else
            {
                // we use class
                this._className = className;
                this._maskName = null;
            }

            // load new data
            this.qryXRight.Fill(@"
                -- init vars
                DECLARE @ClassName VARCHAR(255)
                DECLARE @MaskName VARCHAR(255)

                SET @ClassName = {0}
                SET @MaskName = {1}

                -- validate
                IF (ISNULL(@ClassName, '') = '' AND ISNULL(@MaskName, '') = '')
                BEGIN
                  -- show empty output
                  SELECT UserText    = CONVERT(VARCHAR, NULL),
                         ClassName   = CONVERT(VARCHAR, NULL),
                         RightID     = CONVERT(INT, NULL),
                         MaskName    = CONVERT(VARCHAR, NULL),
                         RightName   = CONVERT(VARCHAR, NULL),
                         DescriptionInView = CONVERT(VARCHAR, NULL),
                         Type        = CONVERT(INT, NULL)
                  WHERE 1 = 0   -- only table without any row

                  -- done
                  RETURN
                END

                -- init temporary table
                DECLARE @Rights TABLE
                (
                  ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
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
                )

                -- get data from stored procedure
                INSERT INTO @Rights
                  EXEC dbo.spXGetRightsAssignedUnassigned NULL, NULL, NULL, NULL

                -- collect needed data
                SELECT DISTINCT
                       RGT.UserText,
                       RGT.ClassName,
                       RGT.RightID,
                       RGT.MaskName,
                       RightName   = CASE WHEN RGT.RightID IS NULL THEN COALESCE(RGT.ClassName, RGT.MaskName)
                                          ELSE XRT.RightName
                                     END,
                       DescriptionInView = CASE WHEN RGT.RightID IS NULL THEN CONVERT(VARCHAR(MAX), CLS.MaskName)
                                          ELSE XRT.UserText
                                     END,
                       Type        = CASE WHEN RGT.RightID IS NOT NULL THEN 1   -- from XRight table (specialright)
                                          WHEN RGT.MaskName IS NOT NULL THEN 2  -- from DynaMask table
                                          ELSE 0                                -- normal class
                                     END
                FROM @Rights RGT
                  LEFT JOIN dbo.XClass CLS WITH (READUNCOMMITTED) ON CLS.ClassName = RGT.ClassName
                  LEFT  JOIN dbo.XRight XRT WITH (READUNCOMMITTED) ON XRT.RightID = RGT.RightID
                WHERE RGT.ClassName = @ClassName OR RGT.MaskName = @MaskName
                ORDER BY ClassName, Type, UserText", _className, _maskName);
        }

        private void SetupColumn(GridColumn gridColumn, bool editable)
        {
            var backColor = editable ? GuiConfig.GridEditable : GuiConfig.GridReadOnly;

            gridColumn.AppearanceCell.BackColor = backColor;
            gridColumn.AppearanceCell.Options.UseBackColor = true;

            gridColumn.OptionsColumn.AllowEdit = editable;
            gridColumn.OptionsColumn.AllowFocus = editable;
            gridColumn.OptionsColumn.ReadOnly = !editable;
        }

        private void SetupGrid()
        {
            SetupColumn(colUser, false);
            SetupColumn(colMayInsert, true);
            SetupColumn(colMayUpdate, true);
            SetupColumn(colMayDelete, true);
        }

        private void SetupRights()
        {
            // init vars
            bool isUserAllowedToChangeRights = IsUserAllowedToChangeRights();

            bool canReadData = false;
            bool canUserInsert = false;
            bool canUserUpdate = false;
            bool canUserDelete = false;

            // set values
            Session.GetUserRight(this.Name, out canReadData, out canUserInsert, out canUserUpdate, out canUserDelete);

            if (Session.Active && !canReadData)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            // setup queries
            qryXRight.CanInsert = isUserAllowedToChangeRights;      // only special users can change rights
            qryXRight.CanUpdate = isUserAllowedToChangeRights;
            qryXRight.CanDelete = isUserAllowedToChangeRights;

            qryVerfuegbar.CanInsert = false;                        // always locked
            qryVerfuegbar.CanUpdate = false;
            qryVerfuegbar.CanDelete = false;

            qryZugeteilt.CanInsert = canUserUpdate;                 // update is important
            qryZugeteilt.CanUpdate = canUserUpdate;
            qryZugeteilt.CanDelete = canUserUpdate;

            // setup buttons
            btnAdd.Enabled = canUserUpdate;                         // update is important
            btnRemove.Enabled = canUserUpdate;
            btnAddAll.Enabled = canUserUpdate;
            btnRemoveAll.Enabled = canUserUpdate;

            // update controls
            qryXRight.EnableBoundFields();
            qryVerfuegbar.EnableBoundFields();
            qryZugeteilt.EnableBoundFields();
        }

        #endregion

        #endregion
    }
}