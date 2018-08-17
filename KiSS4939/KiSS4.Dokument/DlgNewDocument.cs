using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

using DevExpress.XtraTreeList.Nodes;

namespace KiSS4.Dokument
{
    /// <summary>
    /// Summary description for DlgNewDocument.
    /// </summary>
    public class DlgNewDocument : KissDialog
    {
        #region Enumerations

        /// <summary>
        /// Enumeration to sepcify the document access modes of control
        /// </summary>
        public enum DocumentAccessModes
        {
            /// <summary>
            /// All documents will be displayed
            /// </summary>
            All = 0,

            /// <summary>
            /// Only Word documents will be displayed
            /// </summary>
            Word = 1,

            /// <summary>
            /// Only Excel documents will be displayed
            /// </summary>
            Excel = 2
        }

        #endregion

        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The column that contains the icon id in a treeNode.
        /// </summary>
        private const string COL_IMAGE_ICON = "IconID";

        /// <summary>
        /// In ZH ist der Change 4227 nicht umgesetzt.
        /// Daher anderes SQL. Könnte man auch in den embedded Resources
        /// ablegen, aber wir werden das hoffentlich bald rückbauen dürfen.
        /// </summary>
        private const string SQL_NOXPROFILE = @"
            --SQLCHECK_IGNORE--
            -- declare vars
            DECLARE @DocContextName VARCHAR(255);
            DECLARE @UserProfileCode INT;
            DECLARE @DocTypeFilter INT;

            -- set vars
            SET @DocContextName  = {0};
            SET @UserProfileCode = {1};
            SET @DocTypeFilter   = {2};

            -- get data
            SELECT CDO.*,
                   DOC.DocTemplateName,
                   DOC.DateCreation,
                   DOC.DateLastSave,
                   DOC.DocFormatCode,
                   DOC.FileExtension,
                   ItemName = ISNULL(CDO.FolderName, DOC.DocTemplateName),
                   IconID   = CASE
                                WHEN CDO.FolderName IS NULL THEN DOC.DocFormatCode
                                ELSE 0
                              END
            FROM dbo.XDocContext                  CON WITH (READUNCOMMITTED)
              INNER JOIN dbo.XDocContext_Template CDO WITH (READUNCOMMITTED) ON CDO.DocContextID = CON.DocContextID
              LEFT  JOIN dbo.XDocTemplate         DOC WITH (READUNCOMMITTED) ON DOC.DocTemplateID = CDO.DocTemplateID
            WHERE CON.DocContextName = @DocContextName
              AND (CDO.UserProfileCode IS NULL OR
                   CDO.UserProfileCode = ISNULL(@UserProfileCode, CDO.UserProfileCode))
              AND (CDO.FolderName IS NOT NULL OR        -- allow folders everytime
                   @DocTypeFilter = 0 OR                -- if showing all, show all
                   @DocTypeFilter = DOC.DocFormatCode)  -- otherwise just show the matching docformatcode
            ORDER BY ParentID, ParentPosition;";

        #endregion

        #region Private Fields

        private string _context;
        private DocumentAccessModes _documentAccessMode = DocumentAccessModes.All;
        private KissButton btnCancel;
        private KissButton btnCreate;
        private KissCheckEdit chkFoldersExpanded;
        private KissCheckEdit chkShowBookmarkErrors;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colItemName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUserProfileCode;
        private System.ComponentModel.IContainer components;
        private KissTextEdit edtTemplateName;
        private KissLookUpEdit edtUserProfile;
        private ImageList imgList;
        private KissLabel lblTemplateName;
        private KissLabel lblUserProfile;
        private SqlQuery qryXDocTemplate;
        private DataRow resultRow;
        private KissTree treXDocTemplate;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgNewDocument"/> class.
        /// </summary>
        public DlgNewDocument()
        {
            // init components
            InitializeComponent();

            //this.colUserProfileCode.ColumnEdit = this.treXDocTemplate.GetLOVLookUpEdit((SqlQuery)this.edtUserProfile.Properties.DataSource);

            // set column autowith of tree
            treXDocTemplate.OptionsView.AutoWidth = true;

            // set default document filter
            _documentAccessMode = DocumentAccessModes.All;

            //Load the dropdown box with all available profiles.
            if (IsXProfileActivated)
            {
                SqlQuery qry = Utilities.GuiUtilities.GetSqlQueryXProfilesUserOrOrgUnit();

                edtUserProfile.LoadQuery(qry);
                edtUserProfile.Properties.DropDownRows = Math.Min(qry.Count, 14);
            }
            else
            {
                edtUserProfile.LOVName = "UserProfile";
                colUserProfileCode.Caption = "Benutzerprofil";
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgNewDocument"/> class.
        /// </summary>
        /// <param name="documentAccessMode">Set the filter for displaying template documents</param>
        public DlgNewDocument(DocumentAccessModes documentAccessMode)
            : this()
        {
            // apply default document filter
            _documentAccessMode = documentAccessMode;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgNewDocument));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryXDocTemplate = new KiSS4.DB.SqlQuery(this.components);
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnCreate = new KiSS4.Gui.KissButton();
            this.treXDocTemplate = new KiSS4.Gui.KissTree();
            this.colItemName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUserProfileCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.edtUserProfile = new KiSS4.Gui.KissLookUpEdit();
            this.lblUserProfile = new KiSS4.Gui.KissLabel();
            this.chkShowBookmarkErrors = new KiSS4.Gui.KissCheckEdit();
            this.chkFoldersExpanded = new KiSS4.Gui.KissCheckEdit();
            this.lblTemplateName = new KiSS4.Gui.KissLabel();
            this.edtTemplateName = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXDocTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treXDocTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowBookmarkErrors.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFoldersExpanded.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTemplateName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTemplateName.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // qryXDocTemplate
            //
            this.qryXDocTemplate.HostControl = this;
            this.qryXDocTemplate.SelectStatement = resources.GetString("qryXDocTemplate.SelectStatement");
            this.qryXDocTemplate.TableName = "XDocTemplate";
            this.qryXDocTemplate.PositionChanged += new System.EventHandler(this.qryXDocTemplate_PositionChanged);
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(308, 393);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbruch";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // btnCreate
            //
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCreate.Enabled = false;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(160, 393);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(140, 24);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Dokument erstellen";
            this.btnCreate.UseVisualStyleBackColor = false;
            //
            // treXDocTemplate
            //
            this.treXDocTemplate.AllowSortTree = true;
            this.treXDocTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treXDocTemplate.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treXDocTemplate.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treXDocTemplate.Appearance.Empty.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.Empty.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treXDocTemplate.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXDocTemplate.Appearance.EvenRow.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.EvenRow.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treXDocTemplate.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treXDocTemplate.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treXDocTemplate.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treXDocTemplate.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treXDocTemplate.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXDocTemplate.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.FooterPanel.Options.UseFont = true;
            this.treXDocTemplate.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treXDocTemplate.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treXDocTemplate.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXDocTemplate.Appearance.GroupButton.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.GroupButton.Options.UseFont = true;
            this.treXDocTemplate.Appearance.GroupButton.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treXDocTemplate.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXDocTemplate.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treXDocTemplate.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treXDocTemplate.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXDocTemplate.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.HeaderPanel.Options.UseFont = true;
            this.treXDocTemplate.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treXDocTemplate.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treXDocTemplate.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treXDocTemplate.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treXDocTemplate.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treXDocTemplate.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treXDocTemplate.Appearance.HorzLine.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.HorzLine.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treXDocTemplate.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treXDocTemplate.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXDocTemplate.Appearance.OddRow.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.OddRow.Options.UseFont = true;
            this.treXDocTemplate.Appearance.OddRow.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treXDocTemplate.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treXDocTemplate.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXDocTemplate.Appearance.Preview.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.Preview.Options.UseFont = true;
            this.treXDocTemplate.Appearance.Preview.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treXDocTemplate.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treXDocTemplate.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXDocTemplate.Appearance.Row.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.Row.Options.UseFont = true;
            this.treXDocTemplate.Appearance.Row.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treXDocTemplate.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treXDocTemplate.Appearance.TreeLine.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treXDocTemplate.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treXDocTemplate.Appearance.VertLine.Options.UseBackColor = true;
            this.treXDocTemplate.Appearance.VertLine.Options.UseForeColor = true;
            this.treXDocTemplate.Appearance.VertLine.Options.UseTextOptions = true;
            this.treXDocTemplate.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treXDocTemplate.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colItemName,
            this.colUserProfileCode});
            this.treXDocTemplate.DataSource = this.qryXDocTemplate;
            this.treXDocTemplate.ImageIndexFieldName = "IconID";
            this.treXDocTemplate.KeyFieldName = "XDocContext_TemplateID";
            this.treXDocTemplate.Location = new System.Drawing.Point(8, 65);
            this.treXDocTemplate.Name = "treXDocTemplate";
            this.treXDocTemplate.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treXDocTemplate.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treXDocTemplate.OptionsBehavior.Editable = false;
            this.treXDocTemplate.OptionsBehavior.KeepSelectedOnClick = false;
            this.treXDocTemplate.OptionsBehavior.MoveOnEdit = false;
            this.treXDocTemplate.OptionsBehavior.ShowToolTips = false;
            this.treXDocTemplate.OptionsBehavior.SmartMouseHover = false;
            this.treXDocTemplate.OptionsMenu.EnableColumnMenu = false;
            this.treXDocTemplate.OptionsMenu.EnableFooterMenu = false;
            this.treXDocTemplate.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treXDocTemplate.OptionsView.AutoWidth = false;
            this.treXDocTemplate.OptionsView.EnableAppearanceEvenRow = true;
            this.treXDocTemplate.OptionsView.EnableAppearanceOddRow = true;
            this.treXDocTemplate.OptionsView.ShowIndicator = false;
            this.treXDocTemplate.OptionsView.ShowVertLines = false;
            this.treXDocTemplate.SelectImageList = this.imgList;
            this.treXDocTemplate.Size = new System.Drawing.Size(396, 275);
            this.treXDocTemplate.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.treXDocTemplate.TabIndex = 0;
            this.treXDocTemplate.DoubleClick += new System.EventHandler(this.treXDocTemplate_DoubleClick);
            //
            // colItemName
            //
            this.colItemName.Caption = "Vorlage";
            this.colItemName.FieldName = "ItemName";
            this.colItemName.MinWidth = 27;
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowSort = false;
            this.colItemName.OptionsColumn.ReadOnly = true;
            this.colItemName.VisibleIndex = 0;
            this.colItemName.Width = 280;
            //
            // colUserProfileCode
            //
            this.colUserProfileCode.Caption = "Merkmale";
            this.colUserProfileCode.FieldName = "ProfileTags";
            this.colUserProfileCode.Name = "colUserProfileCode";
            this.colUserProfileCode.OptionsColumn.AllowMove = false;
            this.colUserProfileCode.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colUserProfileCode.OptionsColumn.AllowSort = false;
            this.colUserProfileCode.VisibleIndex = 1;
            this.colUserProfileCode.Width = 95;
            //
            // imgList
            //
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Magenta;
            this.imgList.Images.SetKeyName(0, "FolderImgList");
            this.imgList.Images.SetKeyName(1, "WordImgList");
            this.imgList.Images.SetKeyName(2, "ExcelImgList");
            this.imgList.Images.SetKeyName(3, "DocumentImgList");
            //
            // edtUserProfile
            //
            this.edtUserProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUserProfile.Location = new System.Drawing.Point(114, 8);
            this.edtUserProfile.Name = "edtUserProfile";
            this.edtUserProfile.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserProfile.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserProfile.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserProfile.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserProfile.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserProfile.Properties.Appearance.Options.UseFont = true;
            this.edtUserProfile.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtUserProfile.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserProfile.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtUserProfile.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtUserProfile.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUserProfile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUserProfile.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserProfile.Properties.NullText = "";
            this.edtUserProfile.Properties.ShowFooter = false;
            this.edtUserProfile.Properties.ShowHeader = false;
            this.edtUserProfile.Size = new System.Drawing.Size(290, 24);
            this.edtUserProfile.TabIndex = 3;
            this.edtUserProfile.EditValueChanged += new System.EventHandler(this.edtUserProfileCode_EditValueChanged);
            //
            // lblUserProfile
            //
            this.lblUserProfile.Location = new System.Drawing.Point(8, 8);
            this.lblUserProfile.Name = "lblUserProfile";
            this.lblUserProfile.Size = new System.Drawing.Size(100, 24);
            this.lblUserProfile.TabIndex = 14;
            this.lblUserProfile.Text = "Benutzerprofil";
            //
            // chkShowBookmarkErrors
            //
            this.chkShowBookmarkErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowBookmarkErrors.EditValue = true;
            this.chkShowBookmarkErrors.Location = new System.Drawing.Point(8, 364);
            this.chkShowBookmarkErrors.Name = "chkShowBookmarkErrors";
            this.chkShowBookmarkErrors.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkShowBookmarkErrors.Properties.Appearance.Options.UseBackColor = true;
            this.chkShowBookmarkErrors.Properties.Caption = "Textmarken-Fehler anzeigen nach dem Erstellen";
            this.chkShowBookmarkErrors.Size = new System.Drawing.Size(396, 19);
            this.chkShowBookmarkErrors.TabIndex = 15;
            //
            // chkFoldersExpanded
            //
            this.chkFoldersExpanded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFoldersExpanded.EditValue = true;
            this.chkFoldersExpanded.Location = new System.Drawing.Point(8, 344);
            this.chkFoldersExpanded.Name = "chkFoldersExpanded";
            this.chkFoldersExpanded.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkFoldersExpanded.Properties.Appearance.Options.UseBackColor = true;
            this.chkFoldersExpanded.Properties.Caption = "Alle Ordner geöffnet";
            this.chkFoldersExpanded.Size = new System.Drawing.Size(396, 19);
            this.chkFoldersExpanded.TabIndex = 16;
            this.chkFoldersExpanded.CheckedChanged += new System.EventHandler(this.chkFoldersExpanded_CheckedChanged);
            //
            // lblTemplateName
            //
            this.lblTemplateName.Location = new System.Drawing.Point(8, 32);
            this.lblTemplateName.Name = "lblTemplateName";
            this.lblTemplateName.Size = new System.Drawing.Size(85, 24);
            this.lblTemplateName.TabIndex = 17;
            this.lblTemplateName.Text = "Vorlagenname";
            //
            // edtTemplateName
            //
            this.edtTemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTemplateName.Location = new System.Drawing.Point(114, 35);
            this.edtTemplateName.Name = "edtTemplateName";
            this.edtTemplateName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTemplateName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTemplateName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTemplateName.Properties.Appearance.Options.UseBackColor = true;
            this.edtTemplateName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTemplateName.Properties.Appearance.Options.UseFont = true;
            this.edtTemplateName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTemplateName.Size = new System.Drawing.Size(290, 24);
            this.edtTemplateName.TabIndex = 18;
            this.edtTemplateName.EnterKey += new System.Windows.Forms.KeyEventHandler(this.edtTemplateName_EnterKey);
            this.edtTemplateName.EditValueChanged += new System.EventHandler(this.edtTemplateName_EditValueChanged);
            this.edtTemplateName.Enter += new System.EventHandler(this.edtTemplateName_Enter);
            this.edtTemplateName.Leave += new System.EventHandler(this.edtTemplateName_Leave);
            //
            // DlgNewDocument
            //
            this.AcceptButton = this.btnCreate;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(412, 426);
            this.Controls.Add(this.edtTemplateName);
            this.Controls.Add(this.lblTemplateName);
            this.Controls.Add(this.chkFoldersExpanded);
            this.Controls.Add(this.chkShowBookmarkErrors);
            this.Controls.Add(this.lblUserProfile);
            this.Controls.Add(this.edtUserProfile);
            this.Controls.Add(this.treXDocTemplate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgNewDocument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neues Dokument erstellen";
            this.Shown += new System.EventHandler(this.DlgNewDocument_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.qryXDocTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treXDocTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowBookmarkErrors.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFoldersExpanded.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTemplateName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTemplateName.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Der Change 4227 ist bei PI und beim Standard 
        /// eingeschaltet, bei ZH aber nocht  nicht.
        /// Diese Maske hat daher zwei Modi,
        /// einer für Zürich und einer für PI und Standard.
        /// </summary>
        public bool IsXProfileActivated
        {
            get
            {
                return DBUtil.GetConfigBool(@"System\Dokumentemanagement\XProfile", true);
            }
        }

        /// <summary>
        /// Gets a value indicating whether [show bookmark errors].
        /// </summary>
        /// <value><c>true</c> if [show bookmark errors]; otherwise, <c>false</c>.</value>
        public bool ShowBookmarkErrors
        {
            get { return chkShowBookmarkErrors.Checked; }
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Gets the <see cref="System.Object"/> with the specified column name.
        /// </summary>
        /// <value></value>
        public object this[string columnName]
        {
            get
            {
                if (resultRow == null)
                {
                    return DBNull.Value;
                }

                try
                {
                    return resultRow[columnName];
                }
                catch (Exception ex)
                {
                    _logger.Error("Specified Column does not exist.", ex);
                    return DBNull.Value;
                }
            }
        }

        #endregion

        #region EventHandlers

        private void DlgNewDocument_Shown(object sender, EventArgs e)
        {
            DisplayTree();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkFoldersExpanded control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkFoldersExpanded_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFoldersExpanded.Checked)
            {
                treXDocTemplate.ExpandAll();
            }
            else
            {
                treXDocTemplate.CollapseAll();
            }
        }

        private void edtTemplateName_EditValueChanged(object sender, EventArgs e)
        {
            //DisplayTree();
            var text = edtTemplateName.EditValue.ToString();

            if (string.IsNullOrEmpty(text))
            {
                qryXDocTemplate.DataTable.DefaultView.RowFilter = null;

                if (chkFoldersExpanded.Checked)
                {
                    treXDocTemplate.ExpandAll();
                }
                else
                {
                    treXDocTemplate.CollapseAll();
                }
            }
            else
            {
                qryXDocTemplate.DataTable.DefaultView.RowFilter = "DocTemplateName LIKE '%" + text + "%'";
            }

            SetCreateButtonState();
        }

        private void edtTemplateName_Enter(object sender, EventArgs e)
        {
            AcceptButton = null;
        }

        private void edtTemplateName_EnterKey(object sender, KeyEventArgs e)
        {
            DisplayTree();
        }

        private void edtTemplateName_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnCreate;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the edtUserProfileCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void edtUserProfileCode_EditValueChanged(object sender, EventArgs e)
        {
            DisplayTree();
        }

        /// <summary>
        /// Handles the PositionChanged event of the qryXDocTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryXDocTemplate_PositionChanged(object sender, EventArgs e)
        {
            SetCreateButtonState();
        }

        /// <summary>
        /// Sets the Enabled property of btnCreate based on qryXDocTemplate.
        /// </summary>
        private void SetCreateButtonState()
        {
            btnCreate.Enabled = qryXDocTemplate.Count > 0 && DBUtil.IsEmpty(qryXDocTemplate["FolderName"]);
        }

        /// <summary>
        /// Handles the DoubleClick event of the treXDocTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void treXDocTemplate_DoubleClick(object sender, EventArgs e)
        {
            if (btnCreate.Enabled)
            {
                btnCreate.PerformClick();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="dialogOwner">The dialog owner.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public bool NewDocument(IWin32Window dialogOwner, string context)
        {
            if (DBUtil.IsEmpty(context))
            {
                KissMsg.ShowInfo("DlgNewDocument", "KeinKontext", "Kein Dokument-Kontext definiert!\r\n\r\n(Muss durch KiSS-Administrator eingerichtet werden)");
                return false;
            }

            _context = context;

            // check ob keine oder genau eine Vorlage definiert ist für den aktuellen Kontext
            SqlQuery qry;

            if (IsXProfileActivated)
            {
                qry = DBUtil.OpenSQL(qryXDocTemplate.SelectStatement,
                                     _context,
                                     null, //Profil
                                     Convert.ToInt32(_documentAccessMode),
                                     Session.User.UserID,
                                     Session.User.LanguageCode);
            }
            else
            {
                qry = DBUtil.OpenSQL(SQL_NOXPROFILE,
                                     _context,
                                     null,
                                     Convert.ToInt32(_documentAccessMode));
            }

            switch (qry.Count)
            {
                case 0:
                    KissMsg.ShowInfo(
                        "DlgNewDocument",
                        "KeineVorlage",
                        "Keine Vorlage für den Kontext '{0}' definiert!\r\n\r\n(Muss durch KiSS-Administrator eingerichtet werden)",
                        0,
                        0,
                        context);
                    return false;

                case 1:
                    resultRow = qry.Row;
                    return true;

                default:
                    edtUserProfile.EditValueChanged -= edtUserProfileCode_EditValueChanged;

                    // get default profile for current user
                    if (IsXProfileActivated)
                    {
                        edtUserProfile.EditValue =
                            DBUtil.ExecuteScalarSQL(@"
                                --SQLCHECK_IGNORE--
                                SELECT XProfileID = ISNULL(USR.XProfileID, ORG.XProfileID)
                                FROM dbo.XUser                USR WITH (READUNCOMMITTED)
                                  LEFT JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                                        AND OUU.OrgUnitMemberCode = 2
                                  LEFT JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                                WHERE USR.UserID = {0};", Session.User.UserID);
                    }
                    else
                    {
                        // get default modulcode for current user and set modul filter
                        edtUserProfile.EditValue = DBUtil.ExecuteScalarSQL(@"
                            --SQLCHECK_IGNORE--
                            SELECT UserProfileCode = ISNULL(USR.UserProfileCode, ORG.UserProfileCode)
                            FROM dbo.XUser                USR WITH (READUNCOMMITTED)
                              LEFT JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                                    AND OUU.OrgUnitMemberCode = 2
                              LEFT JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
                            WHERE USR.UserID = {0};", Session.User.UserID);
                    }

                    edtUserProfile.EditValueChanged += edtUserProfileCode_EditValueChanged;

                    if (ShowDialog(dialogOwner) == DialogResult.OK)
                    {
                        resultRow = qryXDocTemplate.Row;
                        return true;
                    }

                    return false;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Stores the window's Left, Top, Width, Hight properties, then raises the GettingLayout event.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>Note to inheritors: base implementation must be called.</remarks>
        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout(e);

            KissControlLayout.SaveSimpleProperty(e, colItemName.Name, colItemName, "Width");
            KissControlLayout.SaveSimpleProperty(e, colUserProfileCode.Name, colUserProfileCode, "Width");

            KissControlLayout.SaveSimpleProperty(e, chkFoldersExpanded, "Checked");
            KissControlLayout.SaveSimpleProperty(e, chkShowBookmarkErrors, "Checked");
        }

        /// <summary>
        /// Stores the window's Left, Top, Width, Hight properties, then raises the SettingLayout event.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>Note to inheritors: base implementation must be called.</remarks>
        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout(e);

            KissControlLayout.ReadSimpleProperty(e, colItemName.Name, colItemName, "Width");
            KissControlLayout.ReadSimpleProperty(e, colUserProfileCode.Name, colUserProfileCode, "Width");

            KissControlLayout.ReadSimpleProperty(e, chkFoldersExpanded, "Checked");
            KissControlLayout.ReadSimpleProperty(e, chkShowBookmarkErrors, "Checked");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Displays the tree.
        /// </summary>
        private void DisplayTree()
        {
            if (IsXProfileActivated)
            {
                // Für Standard und PI
                qryXDocTemplate.Fill(qryXDocTemplate.SelectStatement,
                                     _context,
                                     edtUserProfile.EditValue,
                                     Convert.ToInt32(_documentAccessMode),
                                     Session.User.UserID,
                                     Session.User.LanguageCode);
            }
            else
            {
                // Für Zürich
                qryXDocTemplate.Fill(SQL_NOXPROFILE,
                                     _context,
                                     edtUserProfile.EditValue,
                                     Convert.ToInt32(_documentAccessMode));
            }

            // leere Ordner entfernen.
            RemoveEmptyFolders();

            // to display the tree correctly
            treXDocTemplate.MoveLast();
            treXDocTemplate.MoveFirst();

            if (chkFoldersExpanded.Checked)
            {
                treXDocTemplate.ExpandAll();
            }
            else
            {
                treXDocTemplate.CollapseAll();
            }
        }

        /// <summary>
        ///  Removes empty folders recursively.
        /// </summary>
        /// <param name="node">
        ///   True if this node can be removed. 
        ///   It is an empty folder or contains only empty subfolders (contains no documents).
        /// </param>
        /// <returns></returns>
        private bool RemoveEmptyFolderRecursively(TreeListNode node)
        {
            if(node.HasChildren == false)
            {
                int icon = (int)node.GetValue(COL_IMAGE_ICON); //0 ist ein Ordner. 1 ist eine Datei.
                if (icon == 0)
                {
                    return true; //This is an empty folder (Blattknoten).
                }
                return false;
            }

            bool removedAll = true;

            IList<TreeListNode> nodesToRemove = new List<TreeListNode>();

            foreach (TreeListNode childNode in node.Nodes)
            {
                if (RemoveEmptyFolderRecursively(childNode))
                {
                    nodesToRemove.Add(childNode);
                }
                else
                {
                    removedAll = false;
                }
            }

            foreach (var nodetoRemove in nodesToRemove)
            {
                node.Nodes.Remove(nodetoRemove);
            }

            return removedAll;
        }

        /// <summary>
        /// Removes emtpy folders from the tree.
        /// </summary>
        private void RemoveEmptyFolders()
        {
            var rootNodes = treXDocTemplate.Nodes;

            IList<TreeListNode> nodesToRemove = new List<TreeListNode>();

            foreach (TreeListNode node in rootNodes)
            {
                if(RemoveEmptyFolderRecursively(node))
                {
                    nodesToRemove.Add(node);
                }
            }

            foreach(TreeListNode node in nodesToRemove)
            {
                rootNodes.Remove(node);
            }
        }

        #endregion

        #endregion
    }
}