using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuBuchungCode.
    /// </summary>
    public class CtlFibuBuchungCode : KiSS4.Gui.KissUserControl
    {
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colKtoHabenNr;
        private DevExpress.XtraGrid.Columns.GridColumn colKtoSollNr;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private System.ComponentModel.IContainer components;

        private KiSS4.Gui.KissCalcEdit editBetrag;
        private KiSS4.Gui.KissButtonEdit editCode;
        private KiSS4.Gui.KissButtonEdit editHaben;
        private KiSS4.Gui.KissTextEdit editHabenName;
        private KiSS4.Gui.KissButtonEdit editMandant;
        private KiSS4.Gui.KissTextEdit editMandantNr;
        private KiSS4.Gui.KissButtonEdit editMitarbeiter;
        private KiSS4.Gui.KissTextEdit editPlzOrt;
        private KiSS4.Gui.KissButtonEdit editSoll;
        private KiSS4.Gui.KissTextEdit editSollName;
        private KiSS4.Gui.KissTextEdit editText;
        private KiSS4.Gui.KissGrid grdFbBuchungCode;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbBuchungCode;
        private KiSS4.Gui.KissLabel label1;
        private KiSS4.Gui.KissLabel label4;
        private KiSS4.Gui.KissLabel label40;
        private KiSS4.Gui.KissLabel label5;
        private KiSS4.Gui.KissLabel label7;
        private KiSS4.Gui.KissLabel label8;
        private KiSS4.Gui.KissLabel lblCode;
        private KiSS4.DB.SqlQuery qryFbBuchungCode;

        public CtlFibuBuchungCode()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>

        public override string GetContextName()
        {
            return "VmFibu";
        }

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFbBuchungCode = new KiSS4.DB.SqlQuery(this.components);
            this.grdFbBuchungCode = new KiSS4.Gui.KissGrid();
            this.grvFbBuchungCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKtoSollNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKtoHabenNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.editMandant = new KiSS4.Gui.KissButtonEdit();
            this.editSoll = new KiSS4.Gui.KissButtonEdit();
            this.editMandantNr = new KiSS4.Gui.KissTextEdit();
            this.editBetrag = new KiSS4.Gui.KissCalcEdit();
            this.editPlzOrt = new KiSS4.Gui.KissTextEdit();
            this.lblCode = new KiSS4.Gui.KissLabel();
            this.editHabenName = new KiSS4.Gui.KissTextEdit();
            this.editSollName = new KiSS4.Gui.KissTextEdit();
            this.editText = new KiSS4.Gui.KissTextEdit();
            this.label8 = new KiSS4.Gui.KissLabel();
            this.label7 = new KiSS4.Gui.KissLabel();
            this.label5 = new KiSS4.Gui.KissLabel();
            this.label4 = new KiSS4.Gui.KissLabel();
            this.label40 = new KiSS4.Gui.KissLabel();
            this.editCode = new KiSS4.Gui.KissButtonEdit();
            this.editHaben = new KiSS4.Gui.KissButtonEdit();
            this.label1 = new KiSS4.Gui.KissLabel();
            this.editMitarbeiter = new KiSS4.Gui.KissButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbBuchungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbBuchungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbBuchungCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSoll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPlzOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editHabenName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSollName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editHaben.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMitarbeiter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryFbBuchungCode
            // 
            this.qryFbBuchungCode.CanDelete = true;
            this.qryFbBuchungCode.CanInsert = true;
            this.qryFbBuchungCode.CanUpdate = true;
            this.qryFbBuchungCode.HostControl = this;
            this.qryFbBuchungCode.TableName = "FbBuchungCode";
            this.qryFbBuchungCode.AfterInsert += new System.EventHandler(this.qryBuchungCode_AfterInsert);
            this.qryFbBuchungCode.BeforePost += new System.EventHandler(this.qryBuchungCode_BeforePost);
            // 
            // grdFbBuchungCode
            // 
            this.grdFbBuchungCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFbBuchungCode.DataSource = this.qryFbBuchungCode;
            // 
            // 
            // 
            this.grdFbBuchungCode.EmbeddedNavigator.Name = "";
            this.grdFbBuchungCode.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFbBuchungCode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbBuchungCode.Location = new System.Drawing.Point(8, 6);
            this.grdFbBuchungCode.MainView = this.grvFbBuchungCode;
            this.grdFbBuchungCode.Name = "grdFbBuchungCode";
            this.grdFbBuchungCode.Size = new System.Drawing.Size(809, 355);
            this.grdFbBuchungCode.TabIndex = 0;
            this.grdFbBuchungCode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbBuchungCode});
            this.grdFbBuchungCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridBuchungen_KeyPress);
            // 
            // grvFbBuchungCode
            // 
            this.grvFbBuchungCode.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbBuchungCode.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungCode.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.Empty.Options.UseFont = true;
            this.grvFbBuchungCode.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFbBuchungCode.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungCode.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbBuchungCode.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbBuchungCode.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungCode.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFbBuchungCode.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbBuchungCode.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbBuchungCode.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbBuchungCode.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungCode.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFbBuchungCode.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbBuchungCode.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbBuchungCode.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbBuchungCode.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbBuchungCode.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFbBuchungCode.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbBuchungCode.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbBuchungCode.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbBuchungCode.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbBuchungCode.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbBuchungCode.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbBuchungCode.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbBuchungCode.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbBuchungCode.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbBuchungCode.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbBuchungCode.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbBuchungCode.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFbBuchungCode.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungCode.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbBuchungCode.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbBuchungCode.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbBuchungCode.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbBuchungCode.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbBuchungCode.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungCode.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.OddRow.Options.UseFont = true;
            this.grvFbBuchungCode.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbBuchungCode.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungCode.Appearance.Row.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.Row.Options.UseFont = true;
            this.grvFbBuchungCode.Appearance.RowSeparator.BackColor = System.Drawing.Color.Firebrick;
            this.grvFbBuchungCode.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvFbBuchungCode.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbBuchungCode.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbBuchungCode.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbBuchungCode.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbBuchungCode.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbBuchungCode.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbBuchungCode.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbBuchungCode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbBuchungCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colMandant,
            this.colKtoSollNr,
            this.colKtoHabenNr,
            this.colText,
            this.colBetrag,
            this.colMitarbeiter});
            this.grvFbBuchungCode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFbBuchungCode.GridControl = this.grdFbBuchungCode;
            this.grvFbBuchungCode.Name = "grvFbBuchungCode";
            this.grvFbBuchungCode.OptionsBehavior.Editable = false;
            this.grvFbBuchungCode.OptionsCustomization.AllowFilter = false;
            this.grvFbBuchungCode.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbBuchungCode.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbBuchungCode.OptionsNavigation.UseTabKey = false;
            this.grvFbBuchungCode.OptionsView.ColumnAutoWidth = false;
            this.grvFbBuchungCode.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbBuchungCode.OptionsView.ShowGroupPanel = false;
            this.grvFbBuchungCode.OptionsView.ShowIndicator = false;
            // 
            // colCode
            // 
            this.colCode.Caption = "Code";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // colMandant
            // 
            this.colMandant.Caption = "Mandant";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 1;
            this.colMandant.Width = 147;
            // 
            // colKtoSollNr
            // 
            this.colKtoSollNr.Caption = "Soll";
            this.colKtoSollNr.FieldName = "SollKtoNr";
            this.colKtoSollNr.Name = "colKtoSollNr";
            this.colKtoSollNr.Visible = true;
            this.colKtoSollNr.VisibleIndex = 2;
            this.colKtoSollNr.Width = 59;
            // 
            // colKtoHabenNr
            // 
            this.colKtoHabenNr.Caption = "Haben";
            this.colKtoHabenNr.FieldName = "HabenKtoNr";
            this.colKtoHabenNr.Name = "colKtoHabenNr";
            this.colKtoHabenNr.Visible = true;
            this.colKtoHabenNr.VisibleIndex = 3;
            this.colKtoHabenNr.Width = 57;
            // 
            // colText
            // 
            this.colText.Caption = "Text";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 4;
            this.colText.Width = 230;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N3";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            this.colBetrag.Width = 109;
            // 
            // colMitarbeiter
            // 
            this.colMitarbeiter.Caption = "MitarbeiterIn";
            this.colMitarbeiter.FieldName = "MTName";
            this.colMitarbeiter.Name = "colMitarbeiter";
            this.colMitarbeiter.Visible = true;
            this.colMitarbeiter.VisibleIndex = 6;
            this.colMitarbeiter.Width = 99;
            // 
            // editMandant
            // 
            this.editMandant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editMandant.DataMember = "Mandant";
            this.editMandant.DataSource = this.qryFbBuchungCode;
            this.editMandant.Location = new System.Drawing.Point(75, 410);
            this.editMandant.Name = "editMandant";
            this.editMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMandant.Properties.Appearance.Options.UseBackColor = true;
            this.editMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.editMandant.Properties.Appearance.Options.UseFont = true;
            this.editMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editMandant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editMandant.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editMandant.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editMandant.Size = new System.Drawing.Size(205, 24);
            this.editMandant.TabIndex = 2;
            this.editMandant.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editMandant_UserModifiedFld);
            // 
            // editSoll
            // 
            this.editSoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editSoll.DataMember = "SollKtoNr";
            this.editSoll.DataSource = this.qryFbBuchungCode;
            this.editSoll.Location = new System.Drawing.Point(75, 445);
            this.editSoll.Name = "editSoll";
            this.editSoll.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editSoll.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSoll.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSoll.Properties.Appearance.Options.UseBackColor = true;
            this.editSoll.Properties.Appearance.Options.UseBorderColor = true;
            this.editSoll.Properties.Appearance.Options.UseFont = true;
            this.editSoll.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editSoll.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editSoll.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editSoll.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editSoll.Size = new System.Drawing.Size(80, 24);
            this.editSoll.TabIndex = 3;
            this.editSoll.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editSoll_UserModifiedFld);
            // 
            // editMandantNr
            // 
            this.editMandantNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editMandantNr.DataMember = "BaPersonID";
            this.editMandantNr.DataSource = this.qryFbBuchungCode;
            this.editMandantNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editMandantNr.Location = new System.Drawing.Point(288, 410);
            this.editMandantNr.Name = "editMandantNr";
            this.editMandantNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editMandantNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMandantNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMandantNr.Properties.Appearance.Options.UseBackColor = true;
            this.editMandantNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editMandantNr.Properties.Appearance.Options.UseFont = true;
            this.editMandantNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editMandantNr.Properties.ReadOnly = true;
            this.editMandantNr.Size = new System.Drawing.Size(56, 24);
            this.editMandantNr.TabIndex = 283;
            this.editMandantNr.TabStop = false;
            // 
            // editBetrag
            // 
            this.editBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editBetrag.DataMember = "Betrag";
            this.editBetrag.DataSource = this.qryFbBuchungCode;
            this.editBetrag.Location = new System.Drawing.Point(620, 410);
            this.editBetrag.Name = "editBetrag";
            this.editBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.editBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.editBetrag.Properties.Appearance.Options.UseFont = true;
            this.editBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.editBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.editBetrag.Size = new System.Drawing.Size(180, 24);
            this.editBetrag.TabIndex = 6;
            // 
            // editPlzOrt
            // 
            this.editPlzOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editPlzOrt.DataMember = "PlzOrt";
            this.editPlzOrt.DataSource = this.qryFbBuchungCode;
            this.editPlzOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editPlzOrt.Location = new System.Drawing.Point(343, 410);
            this.editPlzOrt.Name = "editPlzOrt";
            this.editPlzOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editPlzOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPlzOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPlzOrt.Properties.Appearance.Options.UseBackColor = true;
            this.editPlzOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.editPlzOrt.Properties.Appearance.Options.UseFont = true;
            this.editPlzOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editPlzOrt.Properties.ReadOnly = true;
            this.editPlzOrt.Size = new System.Drawing.Size(172, 24);
            this.editPlzOrt.TabIndex = 274;
            this.editPlzOrt.TabStop = false;
            // 
            // lblCode
            // 
            this.lblCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCode.ForeColor = System.Drawing.Color.Black;
            this.lblCode.Location = new System.Drawing.Point(10, 375);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(37, 24);
            this.lblCode.TabIndex = 273;
            this.lblCode.Text = "Code";
            // 
            // editHabenName
            // 
            this.editHabenName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editHabenName.DataMember = "HabenKtoName";
            this.editHabenName.DataSource = this.qryFbBuchungCode;
            this.editHabenName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editHabenName.Location = new System.Drawing.Point(162, 468);
            this.editHabenName.Name = "editHabenName";
            this.editHabenName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editHabenName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editHabenName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editHabenName.Properties.Appearance.Options.UseBackColor = true;
            this.editHabenName.Properties.Appearance.Options.UseBorderColor = true;
            this.editHabenName.Properties.Appearance.Options.UseFont = true;
            this.editHabenName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editHabenName.Properties.ReadOnly = true;
            this.editHabenName.Size = new System.Drawing.Size(353, 24);
            this.editHabenName.TabIndex = 270;
            this.editHabenName.TabStop = false;
            // 
            // editSollName
            // 
            this.editSollName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editSollName.DataMember = "SollKtoName";
            this.editSollName.DataSource = this.qryFbBuchungCode;
            this.editSollName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editSollName.Location = new System.Drawing.Point(162, 445);
            this.editSollName.Name = "editSollName";
            this.editSollName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editSollName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSollName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSollName.Properties.Appearance.Options.UseBackColor = true;
            this.editSollName.Properties.Appearance.Options.UseBorderColor = true;
            this.editSollName.Properties.Appearance.Options.UseFont = true;
            this.editSollName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editSollName.Properties.ReadOnly = true;
            this.editSollName.Size = new System.Drawing.Size(353, 24);
            this.editSollName.TabIndex = 269;
            this.editSollName.TabStop = false;
            // 
            // editText
            // 
            this.editText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editText.DataMember = "Text";
            this.editText.DataSource = this.qryFbBuchungCode;
            this.editText.Location = new System.Drawing.Point(75, 503);
            this.editText.Name = "editText";
            this.editText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editText.Properties.Appearance.Options.UseBackColor = true;
            this.editText.Properties.Appearance.Options.UseBorderColor = true;
            this.editText.Properties.Appearance.Options.UseFont = true;
            this.editText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editText.Size = new System.Drawing.Size(440, 24);
            this.editText.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(535, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 24);
            this.label8.TabIndex = 268;
            this.label8.Text = "Betrag CHF";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(10, 503);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 24);
            this.label7.TabIndex = 267;
            this.label7.Text = "Text";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 468);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 24);
            this.label5.TabIndex = 265;
            this.label5.Text = "Haben";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 24);
            this.label4.TabIndex = 264;
            this.label4.Text = "Soll";
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(10, 410);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(63, 24);
            this.label40.TabIndex = 262;
            this.label40.Text = "Mandant";
            // 
            // editCode
            // 
            this.editCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editCode.DataMember = "Code";
            this.editCode.DataSource = this.qryFbBuchungCode;
            this.editCode.Location = new System.Drawing.Point(75, 375);
            this.editCode.Name = "editCode";
            this.editCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editCode.Properties.Appearance.Options.UseBackColor = true;
            this.editCode.Properties.Appearance.Options.UseBorderColor = true;
            this.editCode.Properties.Appearance.Options.UseFont = true;
            this.editCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editCode.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editCode.Size = new System.Drawing.Size(111, 24);
            this.editCode.TabIndex = 1;
            // 
            // editHaben
            // 
            this.editHaben.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editHaben.DataMember = "HabenKtoNr";
            this.editHaben.DataSource = this.qryFbBuchungCode;
            this.editHaben.Location = new System.Drawing.Point(75, 468);
            this.editHaben.Name = "editHaben";
            this.editHaben.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editHaben.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editHaben.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editHaben.Properties.Appearance.Options.UseBackColor = true;
            this.editHaben.Properties.Appearance.Options.UseBorderColor = true;
            this.editHaben.Properties.Appearance.Options.UseFont = true;
            this.editHaben.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.editHaben.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.editHaben.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editHaben.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editHaben.Size = new System.Drawing.Size(80, 24);
            this.editHaben.TabIndex = 4;
            this.editHaben.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editHaben_UserModifiedFld);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(535, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 284;
            this.label1.Text = "MitarbeiterIn";
            // 
            // editMitarbeiter
            // 
            this.editMitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editMitarbeiter.DataMember = "MTName";
            this.editMitarbeiter.DataSource = this.qryFbBuchungCode;
            this.editMitarbeiter.Location = new System.Drawing.Point(620, 445);
            this.editMitarbeiter.Name = "editMitarbeiter";
            this.editMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.editMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.editMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.editMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editMitarbeiter.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editMitarbeiter.Size = new System.Drawing.Size(180, 24);
            this.editMitarbeiter.TabIndex = 7;
            this.editMitarbeiter.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editMitarbeiter_UserModifiedFld);
            // 
            // CtlFibuBuchungCode
            // 
            this.ActiveSQLQuery = this.qryFbBuchungCode;
            this.AutoRefresh = false;
            this.Controls.Add(this.editMitarbeiter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editMandant);
            this.Controls.Add(this.editSoll);
            this.Controls.Add(this.editMandantNr);
            this.Controls.Add(this.editBetrag);
            this.Controls.Add(this.editPlzOrt);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.editHabenName);
            this.Controls.Add(this.editSollName);
            this.Controls.Add(this.editText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.editCode);
            this.Controls.Add(this.editHaben);
            this.Controls.Add(this.grdFbBuchungCode);
            this.Name = "CtlFibuBuchungCode";
            this.Size = new System.Drawing.Size(825, 535);
            this.Load += new System.EventHandler(this.ctlFibuBuchung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryFbBuchungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbBuchungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbBuchungCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSoll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMandantNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPlzOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editHabenName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSollName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editHaben.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editMitarbeiter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private void ctlFibuBuchung_Load(object sender, System.EventArgs e)
        {
            qryFbBuchungCode.Fill("select * from viewFbBuchungCode order by Code");
        }

        private void editHaben_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.KontoSuchen(editHaben.Text, 0, e.ButtonClicked);
            if (!e.Cancel)
            {
                qryFbBuchungCode["HabenKtoNr"] = dlg["KontoNr"];
                qryFbBuchungCode["HabenKtoName"] = dlg["KontoName"];
            }
        }

        private void editMandant_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MandantSuchenB(editMandant.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                qryFbBuchungCode["BaPersonID"] = dlg["BaPersonID"];
                qryFbBuchungCode["BaPersonID"] = dlg["BaPersonID"];
                qryFbBuchungCode["Mandant"] = dlg["Mandant"];
                qryFbBuchungCode["PLZOrt"] = dlg["PLZOrt"];
            }
        }

        private void editMitarbeiter_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(editMitarbeiter.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                qryFbBuchungCode["UserID"] = dlg["UserID"];
                qryFbBuchungCode["MTLogon"] = dlg["LogonName"];
                qryFbBuchungCode["MTName"] = dlg["Name"];
            }
        }

        private void editSoll_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.KontoSuchen(editSoll.Text, 0, e.ButtonClicked);
            if (!e.Cancel)
            {
                qryFbBuchungCode["SollKtoNr"] = dlg["KontoNr"];
                qryFbBuchungCode["SollKtoName"] = dlg["KontoName"];
            }
        }

        private void gridBuchungen_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                editCode.Focus();
                e.Handled = true;
            }
        }

        private void qryBuchungCode_AfterInsert(object sender, System.EventArgs e)
        {
            editCode.Focus();
        }

        private void qryBuchungCode_BeforePost(object sender, System.EventArgs e)
        {
            DBUtil.CheckNotNullField(editCode, lblCode.Text);
        }
    }
}