using System;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuBelegNr.
    /// </summary>
    public class CtlFibuBelegNr : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBelegNrCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBereichBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBereichVon;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colNaechsteBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPraefix;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCalcEdit edtBelegNrBis;
        private KiSS4.Gui.KissLookUpEdit edtBelegNrCode;
        private KiSS4.Gui.KissCalcEdit edtBelegNrVon;
        private KiSS4.Gui.KissButtonEdit edtMandant;
        private KiSS4.Gui.KissCalcEdit edtNaechsteBelegNr;
        private KiSS4.Gui.KissButtonEdit edtPraefix;
        private KiSS4.Gui.KissButtonEdit edtUser;
        private KiSS4.Gui.KissGrid grdFbBelegNr;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit grideditBelegNrCode;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbBelegNr;
        private KiSS4.Gui.KissLabel lblBelegNrBis;
        private KiSS4.Gui.KissLabel lblBelegNrTyp;
        private KiSS4.Gui.KissLabel lblBelegNrVon;
        private KiSS4.Gui.KissLabel lblMandant;
        private KiSS4.Gui.KissLabel lblMitarbeiter;
        private KiSS4.Gui.KissLabel lblNaechsterBelegNr;
        private KiSS4.Gui.KissLabel lblPraefix;
        private KiSS4.DB.SqlQuery qryFbBelegNr;

        #endregion

        #endregion

        #region Constructors

        public CtlFibuBelegNr()
        {
            InitializeComponent();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFbBelegNr = new KiSS4.DB.SqlQuery(this.components);
            this.grdFbBelegNr = new KiSS4.Gui.KissGrid();
            this.grvFbBelegNr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBelegNrCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPraefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNaechsteBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBereichVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBereichBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grideditBelegNrCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lblPraefix = new KiSS4.Gui.KissLabel();
            this.lblNaechsterBelegNr = new KiSS4.Gui.KissLabel();
            this.edtPraefix = new KiSS4.Gui.KissButtonEdit();
            this.lblMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtUser = new KiSS4.Gui.KissButtonEdit();
            this.lblBelegNrVon = new KiSS4.Gui.KissLabel();
            this.lblBelegNrBis = new KiSS4.Gui.KissLabel();
            this.edtNaechsteBelegNr = new KiSS4.Gui.KissCalcEdit();
            this.edtBelegNrBis = new KiSS4.Gui.KissCalcEdit();
            this.edtBelegNrVon = new KiSS4.Gui.KissCalcEdit();
            this.edtBelegNrCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBelegNrTyp = new KiSS4.Gui.KissLabel();
            this.edtMandant = new KiSS4.Gui.KissButtonEdit();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditBelegNrCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPraefix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNaechsterBelegNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraefix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNrVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNrBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNaechsteBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNrBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNrVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNrCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNrCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNrTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            this.SuspendLayout();
            //
            // qryFbBelegNr
            //
            this.qryFbBelegNr.CanDelete = true;
            this.qryFbBelegNr.CanInsert = true;
            this.qryFbBelegNr.CanUpdate = true;
            this.qryFbBelegNr.HostControl = this;
            this.qryFbBelegNr.TableName = "FbBelegNr";
            this.qryFbBelegNr.AutoApplyUserRights = false;
            this.qryFbBelegNr.BeforePost += new System.EventHandler(this.qryFbBelegNr_BeforePost);
            this.qryFbBelegNr.AfterInsert += new System.EventHandler(this.qryFbBelegNr_AfterInsert);
            //
            // grdFbBelegNr
            //
            this.grdFbBelegNr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFbBelegNr.DataSource = this.qryFbBelegNr;
            this.grdFbBelegNr.EmbeddedNavigator.Name = "";
            this.grdFbBelegNr.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFbBelegNr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbBelegNr.Location = new System.Drawing.Point(8, 6);
            this.grdFbBelegNr.MainView = this.grvFbBelegNr;
            this.grdFbBelegNr.Name = "grdFbBelegNr";
            this.grdFbBelegNr.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.grideditBelegNrCode});
            this.grdFbBelegNr.Size = new System.Drawing.Size(809, 324);
            this.grdFbBelegNr.TabIndex = 0;
            this.grdFbBelegNr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbBelegNr});
            //
            // grvFbBelegNr
            //
            this.grvFbBelegNr.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbBelegNr.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBelegNr.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.Empty.Options.UseFont = true;
            this.grvFbBelegNr.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFbBelegNr.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBelegNr.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbBelegNr.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbBelegNr.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBelegNr.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFbBelegNr.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbBelegNr.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbBelegNr.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbBelegNr.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBelegNr.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFbBelegNr.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbBelegNr.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbBelegNr.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbBelegNr.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbBelegNr.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbBelegNr.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbBelegNr.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbBelegNr.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbBelegNr.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbBelegNr.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbBelegNr.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbBelegNr.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbBelegNr.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbBelegNr.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFbBelegNr.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBelegNr.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbBelegNr.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbBelegNr.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbBelegNr.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbBelegNr.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbBelegNr.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBelegNr.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.OddRow.Options.UseFont = true;
            this.grvFbBelegNr.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbBelegNr.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBelegNr.Appearance.Row.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.Row.Options.UseFont = true;
            this.grvFbBelegNr.Appearance.RowSeparator.BackColor = System.Drawing.Color.Firebrick;
            this.grvFbBelegNr.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvFbBelegNr.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBelegNr.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbBelegNr.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbBelegNr.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbBelegNr.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbBelegNr.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbBelegNr.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbBelegNr.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbBelegNr.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBelegNrCode,
            this.colMandant,
            this.colUser,
            this.colPraefix,
            this.colNaechsteBelegNr,
            this.colBereichVon,
            this.colBereichBis});
            this.grvFbBelegNr.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFbBelegNr.GridControl = this.grdFbBelegNr;
            this.grvFbBelegNr.Name = "grvFbBelegNr";
            this.grvFbBelegNr.OptionsBehavior.Editable = false;
            this.grvFbBelegNr.OptionsCustomization.AllowFilter = false;
            this.grvFbBelegNr.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbBelegNr.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbBelegNr.OptionsNavigation.UseTabKey = false;
            this.grvFbBelegNr.OptionsView.ColumnAutoWidth = false;
            this.grvFbBelegNr.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbBelegNr.OptionsView.ShowGroupPanel = false;
            this.grvFbBelegNr.OptionsView.ShowIndicator = false;
            //
            // colBelegNrCode
            //
            this.colBelegNrCode.Caption = "BelegNr-Typ";
            this.colBelegNrCode.ColumnEdit = this.grideditBelegNrCode;
            this.colBelegNrCode.FieldName = "BelegNrCode";
            this.colBelegNrCode.Name = "colBelegNrCode";
            this.colBelegNrCode.Visible = true;
            this.colBelegNrCode.VisibleIndex = 0;
            this.colBelegNrCode.Width = 120;
            //
            // colMandant
            //
            this.colMandant.Caption = "MandantIn";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 1;
            this.colMandant.Width = 200;
            //
            // colUser
            //
            this.colUser.Caption = "MitarbeiterIn";
            this.colUser.FieldName = "User";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 2;
            this.colUser.Width = 200;
            //
            // colPraefix
            //
            this.colPraefix.Caption = "Präfix";
            this.colPraefix.FieldName = "Praefix";
            this.colPraefix.Name = "colPraefix";
            this.colPraefix.Visible = true;
            this.colPraefix.VisibleIndex = 3;
            this.colPraefix.Width = 62;
            //
            // colNaechsteBelegNr
            //
            this.colNaechsteBelegNr.Caption = "Nächste Nr";
            this.colNaechsteBelegNr.FieldName = "NaechsteBelegNr";
            this.colNaechsteBelegNr.Name = "colNaechsteBelegNr";
            this.colNaechsteBelegNr.Visible = true;
            this.colNaechsteBelegNr.VisibleIndex = 4;
            this.colNaechsteBelegNr.Width = 110;
            //
            // colBereichVon
            //
            this.colBereichVon.Caption = "Bereich von";
            this.colBereichVon.FieldName = "BelegNrVon";
            this.colBereichVon.Name = "colBereichVon";
            this.colBereichVon.Visible = true;
            this.colBereichVon.VisibleIndex = 5;
            this.colBereichVon.Width = 110;
            //
            // colBereichBis
            //
            this.colBereichBis.Caption = "Bereich bis";
            this.colBereichBis.FieldName = "BelegNrBis";
            this.colBereichBis.Name = "colBereichBis";
            this.colBereichBis.Visible = true;
            this.colBereichBis.VisibleIndex = 6;
            this.colBereichBis.Width = 110;
            //
            // grideditBelegNrCode
            //
            this.grideditBelegNrCode.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grideditBelegNrCode.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grideditBelegNrCode.AppearanceDropDown.Options.UseBackColor = true;
            this.grideditBelegNrCode.AppearanceDropDown.Options.UseFont = true;
            this.grideditBelegNrCode.AutoHeight = false;
            this.grideditBelegNrCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grideditBelegNrCode.DisplayMember = "Text";
            this.grideditBelegNrCode.Name = "grideditBelegNrCode";
            this.grideditBelegNrCode.NullText = "";
            this.grideditBelegNrCode.ShowFooter = false;
            this.grideditBelegNrCode.ShowHeader = false;
            this.grideditBelegNrCode.ValueMember = "Code";
            //
            // lblPraefix
            //
            this.lblPraefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPraefix.ForeColor = System.Drawing.Color.Black;
            this.lblPraefix.Location = new System.Drawing.Point(15, 440);
            this.lblPraefix.Name = "lblPraefix";
            this.lblPraefix.Size = new System.Drawing.Size(31, 24);
            this.lblPraefix.TabIndex = 273;
            this.lblPraefix.Text = "Präfix";
            //
            // lblNaechsterBelegNr
            //
            this.lblNaechsterBelegNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNaechsterBelegNr.ForeColor = System.Drawing.Color.Black;
            this.lblNaechsterBelegNr.Location = new System.Drawing.Point(15, 470);
            this.lblNaechsterBelegNr.Name = "lblNaechsterBelegNr";
            this.lblNaechsterBelegNr.Size = new System.Drawing.Size(114, 24);
            this.lblNaechsterBelegNr.TabIndex = 268;
            this.lblNaechsterBelegNr.Text = "nächste BelegNr";
            //
            // edtPraefix
            //
            this.edtPraefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPraefix.DataMember = "Praefix";
            this.edtPraefix.DataSource = this.qryFbBelegNr;
            this.edtPraefix.Location = new System.Drawing.Point(135, 440);
            this.edtPraefix.Name = "edtPraefix";
            this.edtPraefix.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPraefix.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPraefix.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPraefix.Properties.Appearance.Options.UseBackColor = true;
            this.edtPraefix.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPraefix.Properties.Appearance.Options.UseFont = true;
            this.edtPraefix.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPraefix.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPraefix.Size = new System.Drawing.Size(85, 24);
            this.edtPraefix.TabIndex = 3;
            //
            // lblMitarbeiter
            //
            this.lblMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMitarbeiter.ForeColor = System.Drawing.Color.Black;
            this.lblMitarbeiter.Location = new System.Drawing.Point(15, 380);
            this.lblMitarbeiter.Name = "lblMitarbeiter";
            this.lblMitarbeiter.Size = new System.Drawing.Size(85, 24);
            this.lblMitarbeiter.TabIndex = 284;
            this.lblMitarbeiter.Text = "MitarbeiterIn";
            //
            // edtUser
            //
            this.edtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtUser.DataMember = "User";
            this.edtUser.DataSource = this.qryFbBelegNr;
            this.edtUser.Location = new System.Drawing.Point(135, 380);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUser.Properties.Appearance.Options.UseFont = true;
            this.edtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUser.Size = new System.Drawing.Size(250, 24);
            this.edtUser.TabIndex = 2;
            this.edtUser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUser_UserModifiedFld);
            //
            // lblBelegNrVon
            //
            this.lblBelegNrVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegNrVon.ForeColor = System.Drawing.Color.Black;
            this.lblBelegNrVon.Location = new System.Drawing.Point(15, 500);
            this.lblBelegNrVon.Name = "lblBelegNrVon";
            this.lblBelegNrVon.Size = new System.Drawing.Size(114, 24);
            this.lblBelegNrVon.TabIndex = 286;
            this.lblBelegNrVon.Text = "BelegNr-Bereich";
            //
            // lblBelegNrBis
            //
            this.lblBelegNrBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegNrBis.ForeColor = System.Drawing.Color.Black;
            this.lblBelegNrBis.Location = new System.Drawing.Point(230, 500);
            this.lblBelegNrBis.Name = "lblBelegNrBis";
            this.lblBelegNrBis.Size = new System.Drawing.Size(8, 24);
            this.lblBelegNrBis.TabIndex = 6;
            this.lblBelegNrBis.Text = "-";
            //
            // edtNaechsteBelegNr
            //
            this.edtNaechsteBelegNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNaechsteBelegNr.DataMember = "NaechsteBelegNr";
            this.edtNaechsteBelegNr.DataSource = this.qryFbBelegNr;
            this.edtNaechsteBelegNr.Location = new System.Drawing.Point(135, 470);
            this.edtNaechsteBelegNr.Name = "edtNaechsteBelegNr";
            this.edtNaechsteBelegNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNaechsteBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNaechsteBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNaechsteBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNaechsteBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtNaechsteBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNaechsteBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtNaechsteBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNaechsteBelegNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNaechsteBelegNr.Size = new System.Drawing.Size(85, 24);
            this.edtNaechsteBelegNr.TabIndex = 4;
            //
            // edtBelegNrBis
            //
            this.edtBelegNrBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBelegNrBis.DataMember = "BelegNrBis";
            this.edtBelegNrBis.DataSource = this.qryFbBelegNr;
            this.edtBelegNrBis.Location = new System.Drawing.Point(245, 500);
            this.edtBelegNrBis.Name = "edtBelegNrBis";
            this.edtBelegNrBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegNrBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegNrBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegNrBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegNrBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegNrBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegNrBis.Properties.Appearance.Options.UseFont = true;
            this.edtBelegNrBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBelegNrBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegNrBis.Size = new System.Drawing.Size(85, 24);
            this.edtBelegNrBis.TabIndex = 6;
            //
            // edtBelegNrVon
            //
            this.edtBelegNrVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBelegNrVon.DataMember = "BelegNrVon";
            this.edtBelegNrVon.DataSource = this.qryFbBelegNr;
            this.edtBelegNrVon.Location = new System.Drawing.Point(135, 500);
            this.edtBelegNrVon.Name = "edtBelegNrVon";
            this.edtBelegNrVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegNrVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegNrVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegNrVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegNrVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegNrVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegNrVon.Properties.Appearance.Options.UseFont = true;
            this.edtBelegNrVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBelegNrVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegNrVon.Size = new System.Drawing.Size(85, 24);
            this.edtBelegNrVon.TabIndex = 5;
            //
            // edtBelegNrCode
            //
            this.edtBelegNrCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBelegNrCode.DataMember = "BelegNrCode";
            this.edtBelegNrCode.DataSource = this.qryFbBelegNr;
            this.edtBelegNrCode.Location = new System.Drawing.Point(135, 350);
            this.edtBelegNrCode.LOVName = "FbBelegNr";
            this.edtBelegNrCode.Name = "edtBelegNrCode";
            this.edtBelegNrCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegNrCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegNrCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegNrCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegNrCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegNrCode.Properties.Appearance.Options.UseFont = true;
            this.edtBelegNrCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBelegNrCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegNrCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBelegNrCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBelegNrCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBelegNrCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBelegNrCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegNrCode.Properties.NullText = "";
            this.edtBelegNrCode.Properties.ShowFooter = false;
            this.edtBelegNrCode.Properties.ShowHeader = false;
            this.edtBelegNrCode.Size = new System.Drawing.Size(250, 24);
            this.edtBelegNrCode.TabIndex = 1;
            this.edtBelegNrCode.EditValueChanged += new System.EventHandler(this.edtBelegNrCode_EditValueChanged);
            //
            // lblBelegNrTyp
            //
            this.lblBelegNrTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegNrTyp.ForeColor = System.Drawing.Color.Black;
            this.lblBelegNrTyp.Location = new System.Drawing.Point(15, 350);
            this.lblBelegNrTyp.Name = "lblBelegNrTyp";
            this.lblBelegNrTyp.Size = new System.Drawing.Size(85, 24);
            this.lblBelegNrTyp.TabIndex = 288;
            this.lblBelegNrTyp.Text = "BelegNr-Typ";
            //
            // edtMandant
            //
            this.edtMandant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMandant.DataMember = "Mandant";
            this.edtMandant.DataSource = this.qryFbBelegNr;
            this.edtMandant.Location = new System.Drawing.Point(135, 410);
            this.edtMandant.Name = "edtMandant";
            this.edtMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandant.Properties.Appearance.Options.UseFont = true;
            this.edtMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMandant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMandant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMandant.Size = new System.Drawing.Size(250, 24);
            this.edtMandant.TabIndex = 289;
            this.edtMandant.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMandant_UserModifiedFld);
            //
            // lblMandant
            //
            this.lblMandant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMandant.ForeColor = System.Drawing.Color.Black;
            this.lblMandant.Location = new System.Drawing.Point(15, 410);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(85, 24);
            this.lblMandant.TabIndex = 290;
            this.lblMandant.Text = "MandantIn";
            //
            // CtlFibuBelegNr
            //
            this.ActiveSQLQuery = this.qryFbBelegNr;
            this.AutoRefresh = false;
            this.Controls.Add(this.edtMandant);
            this.Controls.Add(this.lblMandant);
            this.Controls.Add(this.lblBelegNrTyp);
            this.Controls.Add(this.edtBelegNrCode);
            this.Controls.Add(this.edtBelegNrVon);
            this.Controls.Add(this.edtBelegNrBis);
            this.Controls.Add(this.edtNaechsteBelegNr);
            this.Controls.Add(this.lblBelegNrBis);
            this.Controls.Add(this.lblBelegNrVon);
            this.Controls.Add(this.edtUser);
            this.Controls.Add(this.lblMitarbeiter);
            this.Controls.Add(this.lblPraefix);
            this.Controls.Add(this.lblNaechsterBelegNr);
            this.Controls.Add(this.edtPraefix);
            this.Controls.Add(this.grdFbBelegNr);
            this.Name = "CtlFibuBelegNr";
            this.Size = new System.Drawing.Size(825, 535);
            this.Load += new System.EventHandler(this.CtlFibuBelegNr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryFbBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditBelegNrCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPraefix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNaechsterBelegNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPraefix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNrVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNrBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNaechsteBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNrBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNrVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNrCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegNrCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNrTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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

        #region EventHandlers

        private void CtlFibuBelegNr_Load(object sender, System.EventArgs e)
        {
            grideditBelegNrCode.DataSource = DBUtil.OpenSQL(
                "SELECT Code, Text FROM XLOVCode WHERE LOVName = 'FbBelegNr' ORDER BY SortKey");

            qryFbBelegNr.Fill(@"
                SELECT BNR.*,
                       [User]    = USR.NameVorname,
                       [Mandant] = PRS.NameVorname
                FROM   FbBelegNr          BNR
                       LEFT JOIN vwUser   USR ON USR.UserID = BNR.UserID
                       LEFT JOIN vwPerson PRS ON PRS.BaPersonID = BNR.BaPersonID
                ORDER BY [User], [Mandant]");

            DBUtil.ApplyUserRightsToSqlQuery(this.Name, this.qryFbBelegNr);
        }

        private void edtBelegNrCode_EditValueChanged(object sender, EventArgs e)
        {
            // Mitarbeiter
            if (edtBelegNrCode.EditValue as int? == 1)
            {
                edtUser.EditMode = Kiss.Interfaces.UI.EditModeType.Normal;
            }
            else
            {
                edtUser.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            }
            // Mandant
            if (edtBelegNrCode.EditValue as int? == 4)
            {
                edtMandant.EditMode = Kiss.Interfaces.UI.EditModeType.Normal;
            }
            else
            {
                edtMandant.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            }
        }

        private void edtMandant_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MandantSuchenB(edtMandant.Text, e.ButtonClicked);
            if (!e.Cancel && !DBUtil.IsEmpty(dlg["BaPersonID"]))
            {
                if (this.qryFbBelegNr.DataTable.Select("BaPersonID=" + dlg["BaPersonID"].ToString()).Length > 0)
                {
                    throw new KissInfoException(string.Format("Für den Mandant '{0}' existiert bereits ein Eintrag.", dlg["Mandant"]), edtMandant);
                }
                qryFbBelegNr["BaPersonID"] = dlg["BaPersonID"];
                qryFbBelegNr["Mandant"] = dlg["Mandant"];
            }
        }

        private void edtUser_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(edtUser.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                qryFbBelegNr["UserID"] = dlg["UserID"];
                qryFbBelegNr["User"] = dlg["Name"];
            }
        }

        private void qryFbBelegNr_AfterInsert(object sender, System.EventArgs e)
        {
            qryFbBelegNr["BelegNrCode"] = 1;
            edtUser.Focus();
        }

        private void qryFbBelegNr_BeforePost(object sender, System.EventArgs e)
        {
            // Mitarbeiter
            if (((int)qryFbBelegNr["BelegNrCode"]) == 1)
            {
                DBUtil.CheckNotNullField(edtUser, lblMitarbeiter.Text);
            }
            else
            {
                qryFbBelegNr["UserID"] = DBNull.Value;
                qryFbBelegNr["User"] = DBNull.Value;
            }
            // Mandant
            if ((int)qryFbBelegNr["BelegNrCode"] == 4)
            {
                DBUtil.CheckNotNullField(edtMandant, lblMandant.Text);
            }
            else
            {
                qryFbBelegNr["BaPersonID"] = DBNull.Value;
                qryFbBelegNr["Mandant"] = DBNull.Value;
            }

            DBUtil.CheckNotNullField(edtNaechsteBelegNr, lblNaechsterBelegNr.Text);
            DBUtil.CheckNotNullField(edtBelegNrVon, lblBelegNrVon.Text);
            DBUtil.CheckNotNullField(edtBelegNrBis, lblBelegNrBis.Text);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string GetContextName()
        {
            return "VmFibu";
        }

        #endregion

        #endregion
    }
}