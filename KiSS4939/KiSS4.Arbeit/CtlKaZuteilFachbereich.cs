using System;
using System.Data;
using System.Drawing;

using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaZuteilFachbereich.
    /// </summary>
    public class CtlKaZuteilFachbereich : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int actPosition = -1;
        private int BaPersonID = 0;
        private bool CheckRange = false;
        private DevExpress.XtraGrid.Columns.GridColumn colFachbereich;
        private DevExpress.XtraGrid.Columns.GridColumn colFachleitung;
        private DevExpress.XtraGrid.Columns.GridColumn colNiveau;
        private DevExpress.XtraGrid.Columns.GridColumn colZustKA;
        private DevExpress.XtraGrid.Columns.GridColumn colZuteilBis;
        private DevExpress.XtraGrid.Columns.GridColumn colZuteilVon;
        private System.ComponentModel.IContainer components = null;
        private DateTime datumBis;
        private DateTime datumVon;
        private KiSS4.Gui.KissDateEdit datZuteilBis;
        private KiSS4.Gui.KissDateEdit datZuteilVon;
        private KiSS4.Gui.KissLookUpEdit ddlNiveau;
        private KiSS4.Gui.KissButtonEdit dlgFachbereich;
        private KiSS4.Gui.KissButtonEdit dlgFachleitung;
        private KiSS4.Gui.KissButtonEdit dlgZustKA;
        private KiSS4.Dokument.XDokument docKompetenznachweis;
        private int FaLeistungID = 0;
        private KiSS4.Gui.KissGrid grdZuteilung;
        private DevExpress.XtraGrid.Views.Grid.GridView gvZuteilung;
        private KiSS4.Gui.KissLabel lblFachbereich;
        private KiSS4.Gui.KissLabel lblFachleitung;
        private System.Windows.Forms.Label lblNiveau;
        private KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblZustKA;
        private System.Windows.Forms.Label lblZuteilBis;
        private System.Windows.Forms.Label lblZuteilVon;
        private bool MayClose = false;
        private bool MayDel = false;
        private bool MayIns = false;
        private bool MayRead = false;
        private bool MayReopen = false;
        private bool MayUpd = false;
        private System.Windows.Forms.Panel panDetails;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryZuteilung;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;

        #endregion

        #endregion

        #region Constructors

        public CtlKaZuteilFachbereich()
        {
            // This call is required by the Windows.Forms Form Designer.
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaZuteilFachbereich));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.datZuteilBis = new KiSS4.Gui.KissDateEdit();
            this.qryZuteilung = new KiSS4.DB.SqlQuery(this.components);
            this.lblZuteilBis = new System.Windows.Forms.Label();
            this.ddlNiveau = new KiSS4.Gui.KissLookUpEdit();
            this.datZuteilVon = new KiSS4.Gui.KissDateEdit();
            this.lblNiveau = new System.Windows.Forms.Label();
            this.lblZuteilVon = new System.Windows.Forms.Label();
            this.grdZuteilung = new KiSS4.Gui.KissGrid();
            this.gvZuteilung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colZuteilVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuteilBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFachbereich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNiveau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFachleitung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.dlgZustKA = new KiSS4.Gui.KissButtonEdit();
            this.lblZustKA = new KiSS4.Gui.KissLabel();
            this.dlgFachleitung = new KiSS4.Gui.KissButtonEdit();
            this.lblFachleitung = new KiSS4.Gui.KissLabel();
            this.dlgFachbereich = new KiSS4.Gui.KissButtonEdit();
            this.lblFachbereich = new KiSS4.Gui.KissLabel();
            this.docKompetenznachweis = new KiSS4.Dokument.XDokument();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.panDetails = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.datZuteilBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZuteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlNiveau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlNiveau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datZuteilVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZuteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZuteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgZustKA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgFachleitung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachleitung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgFachbereich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docKompetenznachweis.Properties)).BeginInit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.panDetails.SuspendLayout();
            this.SuspendLayout();
            //
            // datZuteilBis
            //
            this.datZuteilBis.DataMember = "ZuteilungBis";
            this.datZuteilBis.DataSource = this.qryZuteilung;
            this.datZuteilBis.EditValue = null;
            this.datZuteilBis.Location = new System.Drawing.Point(274, 9);
            this.datZuteilBis.Name = "datZuteilBis";
            this.datZuteilBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datZuteilBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datZuteilBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datZuteilBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datZuteilBis.Properties.Appearance.Options.UseBackColor = true;
            this.datZuteilBis.Properties.Appearance.Options.UseBorderColor = true;
            this.datZuteilBis.Properties.Appearance.Options.UseFont = true;
            this.datZuteilBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.datZuteilBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datZuteilBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.datZuteilBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datZuteilBis.Properties.ShowToday = false;
            this.datZuteilBis.Size = new System.Drawing.Size(89, 24);
            this.datZuteilBis.TabIndex = 3;
            this.datZuteilBis.Leave += new System.EventHandler(this.dat_leave);
            //
            // qryZuteilung
            //
            this.qryZuteilung.CanDelete = true;
            this.qryZuteilung.CanInsert = true;
            this.qryZuteilung.CanUpdate = true;
            this.qryZuteilung.HostControl = this;
            this.qryZuteilung.IsIdentityInsert = false;
            this.qryZuteilung.TableName = "KaZuteilFachbereich";
            this.qryZuteilung.AfterInsert += new System.EventHandler(this.qryZuteilung_AfterInsert);
            this.qryZuteilung.AfterPost += new System.EventHandler(this.qryZuteilung_AfterPost);
            this.qryZuteilung.BeforePost += new System.EventHandler(this.qryZuteilung_BeforePost);
            this.qryZuteilung.PositionChanged += new System.EventHandler(this.qryZuteilung_PositionChanged);
            //
            // lblZuteilBis
            //
            this.lblZuteilBis.Location = new System.Drawing.Point(234, 9);
            this.lblZuteilBis.Name = "lblZuteilBis";
            this.lblZuteilBis.Size = new System.Drawing.Size(34, 24);
            this.lblZuteilBis.TabIndex = 2;
            this.lblZuteilBis.Text = "bis";
            this.lblZuteilBis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // ddlNiveau
            //
            this.ddlNiveau.DataMember = "NiveauCode";
            this.ddlNiveau.DataSource = this.qryZuteilung;
            this.ddlNiveau.Location = new System.Drawing.Point(579, 39);
            this.ddlNiveau.LOVName = "KaQjNiveau";
            this.ddlNiveau.Name = "ddlNiveau";
            this.ddlNiveau.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlNiveau.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlNiveau.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlNiveau.Properties.Appearance.Options.UseBackColor = true;
            this.ddlNiveau.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlNiveau.Properties.Appearance.Options.UseFont = true;
            this.ddlNiveau.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlNiveau.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlNiveau.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlNiveau.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlNiveau.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.ddlNiveau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.ddlNiveau.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlNiveau.Properties.NullText = "";
            this.ddlNiveau.Properties.ShowFooter = false;
            this.ddlNiveau.Properties.ShowHeader = false;
            this.ddlNiveau.Size = new System.Drawing.Size(150, 24);
            this.ddlNiveau.TabIndex = 7;
            //
            // datZuteilVon
            //
            this.datZuteilVon.DataMember = "ZuteilungVon";
            this.datZuteilVon.DataSource = this.qryZuteilung;
            this.datZuteilVon.EditValue = null;
            this.datZuteilVon.Location = new System.Drawing.Point(129, 9);
            this.datZuteilVon.Name = "datZuteilVon";
            this.datZuteilVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datZuteilVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datZuteilVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datZuteilVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datZuteilVon.Properties.Appearance.Options.UseBackColor = true;
            this.datZuteilVon.Properties.Appearance.Options.UseBorderColor = true;
            this.datZuteilVon.Properties.Appearance.Options.UseFont = true;
            this.datZuteilVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.datZuteilVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datZuteilVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.datZuteilVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datZuteilVon.Properties.ShowToday = false;
            this.datZuteilVon.Size = new System.Drawing.Size(89, 24);
            this.datZuteilVon.TabIndex = 1;
            this.datZuteilVon.Leave += new System.EventHandler(this.dat_leave);
            //
            // lblNiveau
            //
            this.lblNiveau.Location = new System.Drawing.Point(514, 39);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(59, 24);
            this.lblNiveau.TabIndex = 6;
            this.lblNiveau.Text = "Niveau";
            this.lblNiveau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblZuteilVon
            //
            this.lblZuteilVon.Location = new System.Drawing.Point(9, 9);
            this.lblZuteilVon.Name = "lblZuteilVon";
            this.lblZuteilVon.Size = new System.Drawing.Size(114, 24);
            this.lblZuteilVon.TabIndex = 0;
            this.lblZuteilVon.Text = "Datum von";
            this.lblZuteilVon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // grdZuteilung
            //
            this.grdZuteilung.DataSource = this.qryZuteilung;
            this.grdZuteilung.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdZuteilung.EmbeddedNavigator.Name = "";
            this.grdZuteilung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZuteilung.Location = new System.Drawing.Point(0, 30);
            this.grdZuteilung.MainView = this.gvZuteilung;
            this.grdZuteilung.Name = "grdZuteilung";
            this.grdZuteilung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.grdZuteilung.Size = new System.Drawing.Size(855, 221);
            this.grdZuteilung.TabIndex = 1;
            this.grdZuteilung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvZuteilung});
            //
            // gvZuteilung
            //
            this.gvZuteilung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvZuteilung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZuteilung.Appearance.Empty.Options.UseBackColor = true;
            this.gvZuteilung.Appearance.Empty.Options.UseFont = true;
            this.gvZuteilung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZuteilung.Appearance.EvenRow.Options.UseFont = true;
            this.gvZuteilung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvZuteilung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZuteilung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvZuteilung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvZuteilung.Appearance.FocusedCell.Options.UseFont = true;
            this.gvZuteilung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvZuteilung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvZuteilung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZuteilung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvZuteilung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvZuteilung.Appearance.FocusedRow.Options.UseFont = true;
            this.gvZuteilung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvZuteilung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gvZuteilung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gvZuteilung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvZuteilung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvZuteilung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvZuteilung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvZuteilung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvZuteilung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZuteilung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvZuteilung.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvZuteilung.Appearance.GroupRow.Options.UseFont = true;
            this.gvZuteilung.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvZuteilung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvZuteilung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvZuteilung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvZuteilung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvZuteilung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvZuteilung.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvZuteilung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvZuteilung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZuteilung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvZuteilung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvZuteilung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvZuteilung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvZuteilung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvZuteilung.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvZuteilung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZuteilung.Appearance.OddRow.Options.UseFont = true;
            this.gvZuteilung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvZuteilung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZuteilung.Appearance.Row.Options.UseBackColor = true;
            this.gvZuteilung.Appearance.Row.Options.UseFont = true;
            this.gvZuteilung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvZuteilung.Appearance.SelectedRow.Options.UseFont = true;
            this.gvZuteilung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvZuteilung.Appearance.VertLine.Options.UseBackColor = true;
            this.gvZuteilung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvZuteilung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colZuteilVon,
            this.colZuteilBis,
            this.colFachbereich,
            this.colNiveau,
            this.colZustKA,
            this.colFachleitung});
            this.gvZuteilung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvZuteilung.GridControl = this.grdZuteilung;
            this.gvZuteilung.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvZuteilung.Name = "gvZuteilung";
            this.gvZuteilung.OptionsBehavior.Editable = false;
            this.gvZuteilung.OptionsCustomization.AllowFilter = false;
            this.gvZuteilung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvZuteilung.OptionsNavigation.AutoFocusNewRow = true;
            this.gvZuteilung.OptionsNavigation.UseTabKey = false;
            this.gvZuteilung.OptionsView.ColumnAutoWidth = false;
            this.gvZuteilung.OptionsView.RowAutoHeight = true;
            this.gvZuteilung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvZuteilung.OptionsView.ShowGroupPanel = false;
            this.gvZuteilung.OptionsView.ShowIndicator = false;
            //
            // colZuteilVon
            //
            this.colZuteilVon.Caption = "von";
            this.colZuteilVon.FieldName = "ZuteilungVon";
            this.colZuteilVon.Name = "colZuteilVon";
            this.colZuteilVon.Visible = true;
            this.colZuteilVon.VisibleIndex = 0;
            this.colZuteilVon.Width = 80;
            //
            // colZuteilBis
            //
            this.colZuteilBis.Caption = "bis";
            this.colZuteilBis.FieldName = "ZuteilungBis";
            this.colZuteilBis.Name = "colZuteilBis";
            this.colZuteilBis.Visible = true;
            this.colZuteilBis.VisibleIndex = 1;
            this.colZuteilBis.Width = 80;
            //
            // colFachbereich
            //
            this.colFachbereich.Caption = "Fachbereich";
            this.colFachbereich.FieldName = "Fachbereich";
            this.colFachbereich.Name = "colFachbereich";
            this.colFachbereich.Visible = true;
            this.colFachbereich.VisibleIndex = 2;
            this.colFachbereich.Width = 200;
            //
            // colNiveau
            //
            this.colNiveau.Caption = "Niveau";
            this.colNiveau.FieldName = "NiveauCode";
            this.colNiveau.Name = "colNiveau";
            this.colNiveau.OptionsColumn.AllowEdit = false;
            this.colNiveau.OptionsColumn.ReadOnly = true;
            this.colNiveau.Visible = true;
            this.colNiveau.VisibleIndex = 3;
            this.colNiveau.Width = 150;
            //
            // colZustKA
            //
            this.colZustKA.Caption = "Zuständig KA";
            this.colZustKA.FieldName = "ZustKA";
            this.colZustKA.Name = "colZustKA";
            this.colZustKA.Visible = true;
            this.colZustKA.VisibleIndex = 4;
            this.colZustKA.Width = 150;
            //
            // colFachleitung
            //
            this.colFachleitung.Caption = "Fachleitung";
            this.colFachleitung.FieldName = "Fachleitung";
            this.colFachleitung.Name = "colFachleitung";
            this.colFachleitung.Visible = true;
            this.colFachleitung.VisibleIndex = 5;
            this.colFachleitung.Width = 150;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // repositoryItemMemoEdit1
            //
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ReadOnly = true;
            //
            // dlgZustKA
            //
            this.dlgZustKA.DataMember = "ZustKA";
            this.dlgZustKA.DataSource = this.qryZuteilung;
            this.dlgZustKA.Location = new System.Drawing.Point(129, 69);
            this.dlgZustKA.Name = "dlgZustKA";
            this.dlgZustKA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgZustKA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgZustKA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgZustKA.Properties.Appearance.Options.UseBackColor = true;
            this.dlgZustKA.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgZustKA.Properties.Appearance.Options.UseFont = true;
            this.dlgZustKA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.dlgZustKA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.dlgZustKA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgZustKA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.dlgZustKA.Size = new System.Drawing.Size(350, 24);
            this.dlgZustKA.TabIndex = 9;
            this.dlgZustKA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgZustKA_UserModifiedFld);
            //
            // lblZustKA
            //
            this.lblZustKA.Location = new System.Drawing.Point(9, 69);
            this.lblZustKA.Name = "lblZustKA";
            this.lblZustKA.Size = new System.Drawing.Size(114, 24);
            this.lblZustKA.TabIndex = 8;
            this.lblZustKA.Text = "Zuständig KA";
            //
            // dlgFachleitung
            //
            this.dlgFachleitung.DataMember = "Fachleitung";
            this.dlgFachleitung.DataSource = this.qryZuteilung;
            this.dlgFachleitung.Location = new System.Drawing.Point(129, 99);
            this.dlgFachleitung.Name = "dlgFachleitung";
            this.dlgFachleitung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgFachleitung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgFachleitung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgFachleitung.Properties.Appearance.Options.UseBackColor = true;
            this.dlgFachleitung.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgFachleitung.Properties.Appearance.Options.UseFont = true;
            this.dlgFachleitung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.dlgFachleitung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.dlgFachleitung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgFachleitung.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.dlgFachleitung.Size = new System.Drawing.Size(350, 24);
            this.dlgFachleitung.TabIndex = 11;
            this.dlgFachleitung.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgFachleitung_UserModifiedFld);
            //
            // lblFachleitung
            //
            this.lblFachleitung.Location = new System.Drawing.Point(9, 99);
            this.lblFachleitung.Name = "lblFachleitung";
            this.lblFachleitung.Size = new System.Drawing.Size(114, 24);
            this.lblFachleitung.TabIndex = 10;
            this.lblFachleitung.Text = "Fachleitung";
            //
            // dlgFachbereich
            //
            this.dlgFachbereich.DataMember = "Fachbereich";
            this.dlgFachbereich.DataSource = this.qryZuteilung;
            this.dlgFachbereich.Location = new System.Drawing.Point(129, 39);
            this.dlgFachbereich.Name = "dlgFachbereich";
            this.dlgFachbereich.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgFachbereich.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgFachbereich.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgFachbereich.Properties.Appearance.Options.UseBackColor = true;
            this.dlgFachbereich.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgFachbereich.Properties.Appearance.Options.UseFont = true;
            this.dlgFachbereich.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.dlgFachbereich.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.dlgFachbereich.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgFachbereich.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.dlgFachbereich.Size = new System.Drawing.Size(350, 24);
            this.dlgFachbereich.TabIndex = 5;
            this.dlgFachbereich.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgFachbereich_UserModifiedFld);
            //
            // lblFachbereich
            //
            this.lblFachbereich.Location = new System.Drawing.Point(9, 39);
            this.lblFachbereich.Name = "lblFachbereich";
            this.lblFachbereich.Size = new System.Drawing.Size(114, 24);
            this.lblFachbereich.TabIndex = 4;
            this.lblFachbereich.Text = "Fachbereich";
            //
            // docKompetenznachweis
            //
            this.docKompetenznachweis.Context = "KaZuteilFachbereich";
            this.docKompetenznachweis.DataMember = "ZuteilDokID";
            this.docKompetenznachweis.DataSource = this.qryZuteilung;
            this.docKompetenznachweis.Location = new System.Drawing.Point(129, 153);
            this.docKompetenznachweis.Name = "docKompetenznachweis";
            this.docKompetenznachweis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docKompetenznachweis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docKompetenznachweis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docKompetenznachweis.Properties.Appearance.Options.UseBackColor = true;
            this.docKompetenznachweis.Properties.Appearance.Options.UseBorderColor = true;
            this.docKompetenznachweis.Properties.Appearance.Options.UseFont = true;
            this.docKompetenznachweis.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docKompetenznachweis.Properties.AppearanceDisabled.Options.UseFont = true;
            this.docKompetenznachweis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.docKompetenznachweis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docKompetenznachweis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docKompetenznachweis.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docKompetenznachweis.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docKompetenznachweis.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.docKompetenznachweis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docKompetenznachweis.Properties.ReadOnly = true;
            this.docKompetenznachweis.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.docKompetenznachweis.Size = new System.Drawing.Size(136, 24);
            this.docKompetenznachweis.TabIndex = 12;
            //
            // panTitel
            //
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(855, 30);
            this.panTitel.TabIndex = 0;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(813, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Leistung";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // panDetails
            //
            this.panDetails.Controls.Add(this.lblZuteilVon);
            this.panDetails.Controls.Add(this.lblNiveau);
            this.panDetails.Controls.Add(this.docKompetenznachweis);
            this.panDetails.Controls.Add(this.datZuteilVon);
            this.panDetails.Controls.Add(this.dlgFachbereich);
            this.panDetails.Controls.Add(this.ddlNiveau);
            this.panDetails.Controls.Add(this.lblFachbereich);
            this.panDetails.Controls.Add(this.lblZuteilBis);
            this.panDetails.Controls.Add(this.dlgFachleitung);
            this.panDetails.Controls.Add(this.datZuteilBis);
            this.panDetails.Controls.Add(this.lblFachleitung);
            this.panDetails.Controls.Add(this.lblZustKA);
            this.panDetails.Controls.Add(this.dlgZustKA);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 251);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(855, 194);
            this.panDetails.TabIndex = 2;
            //
            // CtlKaZuteilFachbereich
            //
            this.ActiveSQLQuery = this.qryZuteilung;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(855, 245);
            this.Controls.Add(this.grdZuteilung);
            this.Controls.Add(this.panDetails);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlKaZuteilFachbereich";
            this.Size = new System.Drawing.Size(855, 445);
            this.Load += new System.EventHandler(this.CtlKaZuteilFachbereich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datZuteilBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZuteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlNiveau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlNiveau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datZuteilVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZuteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvZuteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgZustKA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgFachleitung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachleitung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgFachbereich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docKompetenznachweis.Properties)).EndInit();
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.panDetails.ResumeLayout(false);
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

        private void CtlKaZuteilFachbereich_Load(object sender, EventArgs e)
        {
            FillZuteilung();
        }

        private void dat_leave(object sender, EventArgs e)
        {
            if (!CheckDate(false))
            {
                KissMsg.ShowInfo(Name, "DatumBisVorDatumVon", "Datum 'bis' darf nicht vor 'von' liegen!");
                ((KissDateEdit)sender).Focus();
            }
        }

        private void dlgFachbereich_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();

            if (dlg.FachbereichSuchen(dlgFachbereich.Text, e.ButtonClicked))
            {
                qryZuteilung["Fachbereich"] = dlg["Text"];
                qryZuteilung["FachbereichID"] = dlg["Code"];

                dlgFachbereich.EditValue = dlg["Text"];
                dlgFachbereich.LookupID = dlg["Code"];

                qryZuteilung.Post();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dlgFachleitung_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();

            if (dlg.MitarbeiterKASuchen(dlgFachleitung.Text, e.ButtonClicked))
            {
                qryZuteilung["Fachleitung"] = dlg["Name"];
                qryZuteilung["FachleitungID"] = dlg["UserID"];

                dlgFachleitung.EditValue = dlg["Name"];
                dlgFachleitung.LookupID = dlg["UserID"];

                qryZuteilung.Post();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dlgZustKA_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();

            if (dlg.MitarbeiterKASuchen(dlgZustKA.Text, e.ButtonClicked))
            {
                qryZuteilung["ZustKA"] = dlg["Name"];
                qryZuteilung["ZustaendigKaID"] = dlg["UserID"];

                dlgZustKA.EditValue = dlg["Name"];
                dlgZustKA.LookupID = dlg["UserID"];

                qryZuteilung.Post();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void qryZuteilung_AfterInsert(object sender, EventArgs e)
        {
            qryZuteilung["BaPersonID"] = BaPersonID;
            qryZuteilung["SichtbarSDFlag"] = KaUtil.IsVisibleSD(BaPersonID);

            datZuteilVon.Focus();
        }

        private void qryZuteilung_AfterPost(object sender, EventArgs e)
        {
            FillZuteilung();
            qryZuteilung.Position = actPosition;
        }

        private void qryZuteilung_BeforePost(object sender, EventArgs e)
        {
            if (!CheckDate(true))
            {
                throw new KissInfoException("Datum 'bis' darf nicht vor 'von' liegen!");
            }

            //  if (!CheckDateRange())
            //      throw new KissInfoException("Datum ist nicht innerhalb einer\r\nbestehenden An-/Zuweisung!\r\n\r\nAn-/Zuweisung: " + datumVon.ToShortDateString() + " - " + datumBis.ToShortDateString());

            if (qryZuteilung.Row.RowState == DataRowState.Added)
            {
                actPosition = 0;
            }
            else
            {
                actPosition = qryZuteilung.Position;
            }
        }

        private void qryZuteilung_PositionChanged(object sender, EventArgs e)
        {
            SetEditModeNiveau();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "FALEISTUNGID":
                    return FaLeistungID;

                case "BAPERSONID":
                    return BaPersonID;

                case "KAZUTEILFACHBEREICHID":
                    return Convert.ToInt32(qryZuteilung["KaZuteilFachbereichID"]);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int baPersonID, int faLeistungID)
        {
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;
            BaPersonID = baPersonID;
            FaLeistungID = faLeistungID;

            colNiveau.ColumnEdit = grdZuteilung.GetLOVLookUpEdit("KaQjNiveau");
        }

        #endregion

        #region Private Methods

        private bool CheckDate(bool isBeforePost)
        {
            bool rslt = true;

            if (DBUtil.IsEmpty(datZuteilVon.EditValue) || DBUtil.IsEmpty(datZuteilBis.EditValue))
            {
                rslt = true;
            }
            else
            {
                if (isBeforePost)
                {
                    DBUtil.CheckNotNullField(datZuteilVon, "von");
                    DBUtil.CheckNotNullField(datZuteilBis, "bis");
                }

                if (Convert.ToDateTime(datZuteilVon.EditValue) > Convert.ToDateTime(datZuteilBis.EditValue))
                {
                    rslt = false;
                }
            }

            return rslt;
        }

        private bool CheckDateRange()
        {
            bool rslt = true;

            if (!DBUtil.IsEmpty(datZuteilVon.EditValue) && !DBUtil.IsEmpty(datZuteilBis.EditValue))
            {
                if (CheckRange)
                {
                    if (Convert.ToDateTime(datZuteilVon.EditValue) < datumVon ||
                        Convert.ToDateTime(datZuteilVon.EditValue) > datumBis ||
                        Convert.ToDateTime(datZuteilBis.EditValue) < datumVon ||
                        Convert.ToDateTime(datZuteilBis.EditValue) > datumBis)
                    {
                        rslt = false;
                    }
                }
            }

            return rslt;
        }

        private void FillZuteilung()
        {
            qryZuteilung.Fill(@"
                SELECT ZFB.*,
                       LOV.Value1,
                       Fachbereich = dbo.fnLOVText('KAFachbereich', ZFB.FachbereichID),
                       ZustKA      = XUR.LastName + ISNULL(', ' + XUR.FirstName, ''),
                       Fachleitung = XUR1.LastName + ISNULL(', ' + XUR1.FirstName, '')
                FROM dbo.KaZuteilFachbereich ZFB  WITH (READUNCOMMITTED)
                    LEFT JOIN dbo.XUser      XUR  WITH (READUNCOMMITTED) ON XUR.UserID = ZFB.ZustaendigKaID
                    LEFT JOIN dbo.XUser      XUR1 WITH (READUNCOMMITTED) ON XUR1.UserID = ZFB.FachleitungID
                    LEFT JOIN dbo.XLOVCode   LOV  WITH (READUNCOMMITTED) ON ZFB.FachbereichID = LOV.Code AND LOVName = 'KaFachbereich'
                where ZFB.BaPersonID = {0}
                  AND (ZFB.SichtbarSDFlag = {1} OR ZFB.SichtbarSDFlag = 1)
                ORDER BY ZFB.ZuteilungVon DESC", BaPersonID, Session.User.IsUserKA ? 0 : 1);

            var qry = new SqlQuery();
            qry.Fill(@"
                SELECT KAE.DatumVon,
                       KAE.DatumBis
                FROM dbo.KaEinsatz KAE WITH (READUNCOMMITTED)
                WHERE KAE.BaPersonID = {0}
                  AND KAE.DatumVon = (SELECT MAX(KAE1.DatumVon)
                                      FROM dbo.KaEinsatz KAE1 WITH (READUNCOMMITTED)
                                      WHERE KAE1.BaPersonID = {0});", BaPersonID);

            CheckRange = false;

            if (qry.DataTable.Rows.Count > 0)
            {
                if (!DBUtil.IsEmpty(qry["DatumVon"]) && !DBUtil.IsEmpty(qry["DatumBis"]))
                {
                    datumVon = Convert.ToDateTime(qry["DatumVon"]);
                    datumBis = Convert.ToDateTime(qry["DatumBis"]);
                    CheckRange = true;
                }
            }

            SetEditMode();
        }

        private void SetEditMode()
        {
            DBUtil.GetFallRights(FaLeistungID, out MayRead, out MayIns, out MayUpd, out MayDel, out MayClose, out MayReopen);

            qryZuteilung.CanUpdate = MayUpd && DBUtil.UserHasRight("CtlKaZuteilFachbereich", "U");
            qryZuteilung.CanInsert = MayIns && DBUtil.UserHasRight("CtlKaZuteilFachbereich", "I");
            qryZuteilung.CanDelete = MayDel && DBUtil.UserHasRight("CtlKaZuteilFachbereich", "D");
            qryZuteilung.EnableBoundFields();

            SetEditModeNiveau();
        }

        private void SetEditModeNiveau()
        {
            if (qryZuteilung.IsEmpty || !qryZuteilung.CanUpdate)
            {
                // let framework handle editmode
                return;
            }

            if (!DBUtil.IsEmpty(qryZuteilung["Value1"]))
            {
                string value1 = qryZuteilung["Value1"].ToString();

                //editierbar, falls Value1 gleich Semo
                if (value1.Equals("Semo"))
                {
                    ddlNiveau.EditMode = EditModeType.Normal;
                }
                else
                {
                    ddlNiveau.EditMode = EditModeType.ReadOnly;
                }
            }
            else
            {
                ddlNiveau.EditMode = EditModeType.ReadOnly;
            }
        }

        #endregion

        #endregion
    }
}