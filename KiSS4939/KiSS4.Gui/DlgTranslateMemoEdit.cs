using KiSS4.DB;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace KiSS4.Gui
{
    /// <summary>
    /// Multilanguage translation control
    /// TODO: Known bug: edit field and move mouse out of current editing field --> change is undone (DevExpress?!?)
    /// </summary>
    public class DlgTranslateMemoEdit : KiSS4.Gui.KissDialog
    {
        #region Fields

        private int _currentTid;
        private bool _dataHasChanged;
        private bool _isMultiline = true;
        private KiSS4.Gui.KissButton btnSave;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraGrid.Columns.GridColumn gcLanguage;
        private DevExpress.XtraGrid.Columns.GridColumn gcText;
        private KiSS4.Gui.KissGrid grdTranslation;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTranslation;
        private KiSS4.Gui.KissContainerControl kccSubContainer;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Language;
        private KiSS4.DB.SqlQuery qryText;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repItemEditMemo;

        #endregion

        #region Constructor / Dispose

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgTranslateMemoEdit"/> class.
        /// </summary>
        /// <param name="currentTid">The current tid.</param>
        /// <param name="isMultiline">if set to <c>true</c> [is multiline].</param>
        public DlgTranslateMemoEdit(int currentTid, bool isMultiline)
        {
            InitializeComponent();

            this._currentTid = currentTid;
            this._isMultiline = isMultiline;

            if (this._isMultiline)
            {
                // multiline
                repItemEditMemo.AcceptsReturn = true;
                repItemEditMemo.WordWrap = false;
                repItemEditMemo.LinesCount = 5;
                repItemEditMemo.ScrollBars = ScrollBars.Vertical;

                grvTranslation.RowHeight = 60;
            }
            else
            {
                // singleline
                repItemEditMemo.AcceptsReturn = false;
                repItemEditMemo.WordWrap = false;
                repItemEditMemo.LinesCount = 1;
                repItemEditMemo.ScrollBars = ScrollBars.None;

                grvTranslation.RowHeight = 20;
    
            }
        }

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
        /// Get if some data has been added or changed by the user
        /// </summary>
        [Browsable(false)]
        [Description("Get if some data has been added or changed by the user")]
        [DefaultValue(false)]
        public bool DataHasChanged
        {
            get { return _dataHasChanged; }
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
            this.qryText = new KiSS4.DB.SqlQuery(this.components);
            this.Language = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.grdTranslation = new KiSS4.Gui.KissGrid();
            this.grvTranslation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcLanguage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemEditMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.kccSubContainer = new KiSS4.Gui.KissContainerControl();
            this.btnSave = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTranslation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTranslation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemEditMemo)).BeginInit();
            this.kccSubContainer.SuspendLayout();
            this.SuspendLayout();
            //
            // qryText
            //
            this.qryText.CanUpdate = true;
            this.qryText.HostControl = this;
            this.qryText.TableName = "XLangText";
            this.qryText.BeforePost += new System.EventHandler(this.qryText_BeforePost);
            //
            // Language
            //
            this.Language.Caption = "treeListColumn1";
            this.Language.FieldName = "Text";
            this.Language.Name = "Language";
            this.Language.VisibleIndex = 0;
            this.Language.Width = 101;
            //
            // grdTranslation
            //
            this.grdTranslation.DataSource = this.qryText;
            this.grdTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTranslation.EmbeddedNavigator.Name = "";
            this.grdTranslation.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdTranslation.Location = new System.Drawing.Point(0, 0);
            this.grdTranslation.MainView = this.grvTranslation;
            this.grdTranslation.Name = "grdTranslation";
            this.grdTranslation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemEditMemo});
            this.grdTranslation.Size = new System.Drawing.Size(640, 374);
            this.grdTranslation.TabIndex = 8;
            this.grdTranslation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTranslation});
            //
            // grvTranslation
            //
            this.grvTranslation.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvTranslation.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.Empty.Options.UseBackColor = true;
            this.grvTranslation.Appearance.Empty.Options.UseFont = true;
            this.grvTranslation.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvTranslation.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvTranslation.Appearance.EvenRow.Options.UseFont = true;
            this.grvTranslation.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvTranslation.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvTranslation.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvTranslation.Appearance.FocusedCell.Options.UseFont = true;
            this.grvTranslation.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvTranslation.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvTranslation.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvTranslation.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvTranslation.Appearance.FocusedRow.Options.UseFont = true;
            this.grvTranslation.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvTranslation.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvTranslation.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvTranslation.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvTranslation.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvTranslation.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvTranslation.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvTranslation.Appearance.GroupRow.Options.UseFont = true;
            this.grvTranslation.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvTranslation.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvTranslation.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvTranslation.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvTranslation.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvTranslation.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvTranslation.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTranslation.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvTranslation.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvTranslation.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvTranslation.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvTranslation.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvTranslation.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvTranslation.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvTranslation.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.OddRow.Options.UseFont = true;
            this.grvTranslation.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvTranslation.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.Row.Options.UseBackColor = true;
            this.grvTranslation.Appearance.Row.Options.UseFont = true;
            this.grvTranslation.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvTranslation.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTranslation.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvTranslation.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvTranslation.Appearance.SelectedRow.Options.UseFont = true;
            this.grvTranslation.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvTranslation.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvTranslation.Appearance.VertLine.Options.UseBackColor = true;
            this.grvTranslation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvTranslation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcLanguage,
            this.gcText});
            this.grvTranslation.GridControl = this.grdTranslation;
            this.grvTranslation.Name = "grvTranslation";
            this.grvTranslation.OptionsCustomization.AllowFilter = false;
            this.grvTranslation.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvTranslation.OptionsNavigation.AutoFocusNewRow = true;
            this.grvTranslation.OptionsView.ColumnAutoWidth = false;
            this.grvTranslation.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvTranslation.OptionsView.ShowGroupPanel = false;
            this.grvTranslation.RowHeight = 60;
            this.grvTranslation.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvTranslation_CellValueChanged);
            //
            // gcLanguage
            //
            this.gcLanguage.AppearanceCell.Options.UseTextOptions = true;
            this.gcLanguage.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gcLanguage.Caption = "Sprache";
            this.gcLanguage.FieldName = "Language";
            this.gcLanguage.Name = "gcLanguage";
            this.gcLanguage.OptionsColumn.AllowEdit = false;
            this.gcLanguage.Visible = true;
            this.gcLanguage.VisibleIndex = 0;
            this.gcLanguage.Width = 93;
            //
            // gcText
            //
            this.gcText.Caption = "Text";
            this.gcText.ColumnEdit = this.repItemEditMemo;
            this.gcText.FieldName = "Text";
            this.gcText.Name = "gcText";
            this.gcText.Visible = true;
            this.gcText.VisibleIndex = 1;
            this.gcText.Width = 513;
            //
            // repItemEditMemo
            //
            this.repItemEditMemo.LinesCount = 5;
            this.repItemEditMemo.Name = "repItemEditMemo";
            this.repItemEditMemo.WordWrap = false;
            //
            // kccSubContainer
            //
            this.kccSubContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kccSubContainer.Controls.Add(this.btnSave);
            this.kccSubContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kccSubContainer.Location = new System.Drawing.Point(0, 374);
            this.kccSubContainer.Name = "kccSubContainer";
            this.kccSubContainer.Size = new System.Drawing.Size(640, 51);
            this.kccSubContainer.TabIndex = 13;
            //
            // btnSave
            //
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(544, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 24);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "OK";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // DlgTranslateMemoEdit
            //
            this.ActiveSQLQuery = this.qryText;
            this.ClientSize = new System.Drawing.Size(640, 425);
            this.ControlBox = false;
            this.Controls.Add(this.grdTranslation);
            this.Controls.Add(this.kccSubContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(264, 192);
            this.Name = "DlgTranslateMemoEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Memo editieren";
            this.Load += new System.EventHandler(this.DlgMemoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTranslation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTranslation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemEditMemo)).EndInit();
            this.kccSubContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        #region Events

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            qryText.Post();
        }

        private void DlgMemoEdit_Load(object sender, System.EventArgs e)
        {
            qryText.Fill(@"
                SELECT
                  LanguageCode          = LOV.Code,
                  Language              = ISNULL(LAN.Text, LOV.Text),
                  Text                  = TXT.Text,
                  TID                   = TXT.TID,
                  LanguageCodeXLangText = TXT.LanguageCode
                FROM dbo.XLOVCode          LOV WITH (READUNCOMMITTED)
                  LEFT  JOIN dbo.XLangText LAN WITH (READUNCOMMITTED) ON LAN.TID = LOV.TextTID
                                                                     AND LAN.LanguageCode = {1}
                  LEFT  JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.LanguageCode = LOV.Code
                                                                     AND TXT.TID = {0}
                WHERE LOVName = 'Sprache'",
                _currentTid,
                Session.User.LanguageCode);
        }

        /// <summary>
        /// Event: CellValueChanged, set flag to determine if some data has changed
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void grvTranslation_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this._dataHasChanged = true;
        }

        private void qryText_BeforePost(object sender, System.EventArgs e)
        {
            if (qryText["LanguageCodeXLangText"] == DBNull.Value)
            {
                DB.DBUtil.ExecSQL(@"--SQLCHECK_IGNORE--
                                    IF NOT EXISTS(SELECT * FROM XLangText WHERE TID = {0} AND LanguageCode = {1}) BEGIN
                                       SET IDENTITY_INSERT XLangText ON
                                       INSERT INTO XLangText (TID, LanguageCode, Text) VALUES ({0}, {1}, {2})
                                       SET IDENTITY_INSERT XLangText OFF
                                    END
                                   ", this._currentTid, qryText["LanguageCode"], qryText["Text"]);
                // TODO: timestamp zurücklesen
                qryText.Row.AcceptChanges();
            }
            else if (!qryText.CanInsert && !qryText.CanUpdate)
            {
                qryText.Row.AcceptChanges();
            }
        }

        #endregion
    }
}