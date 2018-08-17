using System;
using System.Data;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;
using System.Text;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;

namespace KiSS4.Fibu
{
	/// <summary>
	/// Summary description for CtlFibuPeriode.
	/// </summary>
	partial class CtlFibuPeriode
	{
		#region GUI components

		private System.ComponentModel.IContainer components;

		private DevExpress.XtraGrid.Views.Grid.GridView gridViewMasks;
		private DevExpress.XtraGrid.Columns.GridColumn colItemMandant;
		private DevExpress.XtraGrid.Columns.GridColumn colBeleg;
		private DevExpress.XtraGrid.Columns.GridColumn colDatum;
		private DevExpress.XtraGrid.Columns.GridColumn colSoll;
		private DevExpress.XtraGrid.Columns.GridColumn colHaben;
		private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;

		private KiSS4.DB.SqlQuery qryPeriode;
        private KiSS4.Gui.KissTabControlEx tabControlSearch;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn colMandantNr;
		private DevExpress.XtraGrid.Columns.GridColumn colMandant;
		private DevExpress.XtraGrid.Columns.GridColumn colMT;
        private KiSS4.Gui.KissLabel lblTitelAuswahlMandant;
		private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
		private DevExpress.XtraGrid.Columns.GridColumn colOrt;
		private KiSS4.DB.SqlQuery qryMandant;
		private KiSS4.Gui.KissTextEdit edtSucheMandant;
		private KiSS4.Gui.KissLabel lblSucheMaTraeger;
		private KiSS4.Gui.KissLabel lblSucheMandant;
        private KiSS4.Gui.KissTextEdit edtSucheMaTraeger;
        private KiSS4.Gui.KissGrid gridMandant;
		private System.Windows.Forms.CheckBox chkSuchePersStamm;
		private KiSS4.Gui.KissSearchTitel searchTitle;
		private KiSS4.Gui.KissLabel lblSuchePeriodeVon;
		private KiSS4.Gui.KissLabel lblSuchePeriodeBis;
		private KiSS4.Gui.KissDateEdit edtSuchePeriodeVon;
        private KiSS4.Gui.KissDateEdit edtSuchePeriodeBis;
        private KissLabel lblSucheJournAblOrt;
        private KissLookUpEdit edtSucheJournAblOrt;
        private KissLabel lblSucheTeam;
        private KissLookUpEdit edtSucheTeam;

		#endregion

		#region IDisposable Members

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuPeriode));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridViewMasks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qryPeriode = new KiSS4.DB.SqlQuery(this.components);
            this.gridMandant = new KiSS4.Gui.KissGrid();
            this.qryMandant = new KiSS4.DB.SqlQuery(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMandantNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtSuchePeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.edtSuchePeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.lblSuchePeriodeBis = new KiSS4.Gui.KissLabel();
            this.lblSuchePeriodeVon = new KiSS4.Gui.KissLabel();
            this.searchTitle = new KiSS4.Gui.KissSearchTitel();
            this.chkSuchePersStamm = new System.Windows.Forms.CheckBox();
            this.lblSucheMandant = new KiSS4.Gui.KissLabel();
            this.lblSucheMaTraeger = new KiSS4.Gui.KissLabel();
            this.edtSucheMaTraeger = new KiSS4.Gui.KissTextEdit();
            this.edtSucheMandant = new KiSS4.Gui.KissTextEdit();
            this.lblTitelAuswahlMandant = new KiSS4.Gui.KissLabel();
            this.lblSucheTeam = new KiSS4.Gui.KissLabel();
            this.edtSucheTeam = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheJournAblOrt = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheJournAblOrt = new KiSS4.Gui.KissLabel();
            this.tabControlSearch = new KiSS4.Gui.KissTabControlEx();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.chkSuchePersonMitBuchhaltung = new System.Windows.Forms.CheckBox();
            this.panDetail = new System.Windows.Forms.Panel();
            this.edtPersonID = new KiSS4.Gui.KissIntEdit();
            this.btnUebertragen = new KiSS4.Gui.KissButton();
            this.lblPersonNr = new KiSS4.Gui.KissLabel();
            this.lblJournAblOrt = new KiSS4.Gui.KissLabel();
            this.edtJournAblOrt = new KiSS4.Gui.KissLookUpEdit();
            this.lblPeriodeId = new KiSS4.Gui.KissLabel();
            this.editTeam = new KiSS4.Gui.KissLookUpEdit();
            this.lblTeam = new KiSS4.Gui.KissLabel();
            this.editPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.editPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.lblPeriodeBis = new KiSS4.Gui.KissLabel();
            this.lblPeriodeVon = new KiSS4.Gui.KissLabel();
            this.btnAbschluss = new KiSS4.Gui.KissButton();
            this.btnAktiv = new KiSS4.Gui.KissButton();
            this.lblTitelPerioden = new KiSS4.Gui.KissLabel();
            this.btnSaldiVortragen = new KiSS4.Gui.KissButton();
            this.gridPeriode = new KiSS4.Gui.KissGrid();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grideditTeam = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePeriodeBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePeriodeVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMaTraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMaTraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMandant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelAuswahlMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJournAblOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJournAblOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheJournAblOrt)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJournAblOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJournAblOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJournAblOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelPerioden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewMasks
            // 
            this.gridViewMasks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemMandant,
            this.colBeleg,
            this.colDatum,
            this.colSoll,
            this.colHaben,
            this.colText,
            this.colBetrag});
            this.gridViewMasks.Name = "gridViewMasks";
            this.gridViewMasks.ViewStyles.AddReplace("FocusedCell", "FocusedRow");
            this.gridViewMasks.ViewStyles.AddReplace("SelectedRow", "Row");
            this.gridViewMasks.ViewStyles.AddReplace("HideSelectionRow", "SelectedRow");
            // 
            // colItemMandant
            // 
            this.colItemMandant.Caption = "Mandant";
            this.colItemMandant.FieldName = "Mandant";
            this.colItemMandant.Name = "colItemMandant";
            this.colItemMandant.Visible = true;
            this.colItemMandant.VisibleIndex = 0;
            this.colItemMandant.Width = 147;
            // 
            // colBeleg
            // 
            this.colBeleg.Caption = "Beleg";
            this.colBeleg.FieldName = "BelegNr";
            this.colBeleg.Name = "colBeleg";
            this.colBeleg.Visible = true;
            this.colBeleg.VisibleIndex = 1;
            this.colBeleg.Width = 70;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "DatumBuchung";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 2;
            this.colDatum.Width = 92;
            // 
            // colSoll
            // 
            this.colSoll.Caption = "Soll";
            this.colSoll.FieldName = "KontoNrS";
            this.colSoll.Name = "colSoll";
            this.colSoll.Visible = true;
            this.colSoll.VisibleIndex = 3;
            this.colSoll.Width = 56;
            // 
            // colHaben
            // 
            this.colHaben.Caption = "Haben";
            this.colHaben.FieldName = "KontoNrH";
            this.colHaben.Name = "colHaben";
            this.colHaben.Visible = true;
            this.colHaben.VisibleIndex = 4;
            this.colHaben.Width = 57;
            // 
            // colText
            // 
            this.colText.Caption = "Text";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 5;
            this.colText.Width = 230;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 6;
            this.colBetrag.Width = 109;
            // 
            // qryPeriode
            // 
            this.qryPeriode.CanDelete = true;
            this.qryPeriode.CanInsert = true;
            this.qryPeriode.CanUpdate = true;
            this.qryPeriode.DeleteQuestion = "Soll diese Periode gelöscht werden ?";
            this.qryPeriode.HostControl = this;
            this.qryPeriode.IsIdentityInsert = false;
            this.qryPeriode.TableName = "FbPeriode";
            this.qryPeriode.AfterFill += new System.EventHandler(this.qryPeriode_AfterFill);
            this.qryPeriode.AfterInsert += new System.EventHandler(this.qryPeriode_AfterInsert);
            this.qryPeriode.AfterPost += new System.EventHandler(this.qryPeriode_AfterPost);
            this.qryPeriode.BeforeDelete += new System.EventHandler(this.qryPeriode_BeforeDelete);
            this.qryPeriode.BeforePost += new System.EventHandler(this.qryPeriode_BeforePost);
            this.qryPeriode.PositionChanged += new System.EventHandler(this.qryPeriode_PositionChanged);
            // 
            // gridMandant
            // 
            this.gridMandant.DataSource = this.qryMandant;
            this.gridMandant.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.gridMandant.EmbeddedNavigator.Name = "";
            this.gridMandant.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridMandant.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gridMandant.Location = new System.Drawing.Point(0, 0);
            this.gridMandant.MainView = this.gridView1;
            this.gridMandant.Name = "gridMandant";
            this.gridMandant.Size = new System.Drawing.Size(807, 259);
            this.gridMandant.TabIndex = 0;
            this.gridMandant.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qryMandant
            // 
            this.qryMandant.HostControl = this;
            this.qryMandant.IsIdentityInsert = false;
            this.qryMandant.PositionChanged += new System.EventHandler(this.qryMandant_PositionChanged);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMandantNr,
            this.colMandant,
            this.colStrasse,
            this.colOrt,
            this.colMT});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.gridMandant;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsPrint.UsePrintStyles = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            // 
            // colMandantNr
            // 
            this.colMandantNr.Caption = "Nr";
            this.colMandantNr.FieldName = "BaPersonID";
            this.colMandantNr.Name = "colMandantNr";
            this.colMandantNr.Visible = true;
            this.colMandantNr.VisibleIndex = 0;
            this.colMandantNr.Width = 63;
            // 
            // colMandant
            // 
            this.colMandant.Caption = "Mandant";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 1;
            this.colMandant.Width = 219;
            // 
            // colStrasse
            // 
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "Strasse";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 2;
            this.colStrasse.Width = 150;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "PLZOrt";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 3;
            this.colOrt.Width = 168;
            // 
            // colMT
            // 
            this.colMT.Caption = "Mandatsträger";
            this.colMT.FieldName = "MTName";
            this.colMT.Name = "colMT";
            this.colMT.Visible = true;
            this.colMT.VisibleIndex = 4;
            this.colMT.Width = 168;
            // 
            // edtSuchePeriodeBis
            // 
            this.edtSuchePeriodeBis.EditValue = null;
            this.edtSuchePeriodeBis.Location = new System.Drawing.Point(428, 70);
            this.edtSuchePeriodeBis.Name = "edtSuchePeriodeBis";
            this.edtSuchePeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSuchePeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchePeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchePeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchePeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchePeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtSuchePeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSuchePeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSuchePeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSuchePeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchePeriodeBis.Properties.ShowToday = false;
            this.edtSuchePeriodeBis.Size = new System.Drawing.Size(100, 24);
            this.edtSuchePeriodeBis.TabIndex = 7;
            // 
            // edtSuchePeriodeVon
            // 
            this.edtSuchePeriodeVon.EditValue = null;
            this.edtSuchePeriodeVon.Location = new System.Drawing.Point(428, 40);
            this.edtSuchePeriodeVon.Name = "edtSuchePeriodeVon";
            this.edtSuchePeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSuchePeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchePeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchePeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchePeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchePeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtSuchePeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSuchePeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSuchePeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSuchePeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSuchePeriodeVon.Properties.ShowToday = false;
            this.edtSuchePeriodeVon.Size = new System.Drawing.Size(100, 24);
            this.edtSuchePeriodeVon.TabIndex = 3;
            // 
            // lblSuchePeriodeBis
            // 
            this.lblSuchePeriodeBis.Location = new System.Drawing.Point(337, 70);
            this.lblSuchePeriodeBis.Name = "lblSuchePeriodeBis";
            this.lblSuchePeriodeBis.Size = new System.Drawing.Size(85, 24);
            this.lblSuchePeriodeBis.TabIndex = 6;
            this.lblSuchePeriodeBis.Text = "Periode bis";
            // 
            // lblSuchePeriodeVon
            // 
            this.lblSuchePeriodeVon.Location = new System.Drawing.Point(337, 40);
            this.lblSuchePeriodeVon.Name = "lblSuchePeriodeVon";
            this.lblSuchePeriodeVon.Size = new System.Drawing.Size(85, 24);
            this.lblSuchePeriodeVon.TabIndex = 2;
            this.lblSuchePeriodeVon.Text = "Periode von";
            // 
            // searchTitle
            // 
            this.searchTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.searchTitle.Location = new System.Drawing.Point(10, 2);
            this.searchTitle.Name = "searchTitle";
            this.searchTitle.Size = new System.Drawing.Size(200, 24);
            this.searchTitle.TabIndex = 343;
            // 
            // chkSuchePersStamm
            // 
            this.chkSuchePersStamm.Location = new System.Drawing.Point(129, 100);
            this.chkSuchePersStamm.Name = "chkSuchePersStamm";
            this.chkSuchePersStamm.Size = new System.Drawing.Size(265, 24);
            this.chkSuchePersStamm.TabIndex = 8;
            this.chkSuchePersStamm.Text = "Suche nur im Personenstamm";
            this.chkSuchePersStamm.CheckedChanged += new System.EventHandler(this.chkSuchePersStamm_CheckedChanged);
            // 
            // lblSucheMandant
            // 
            this.lblSucheMandant.Location = new System.Drawing.Point(30, 40);
            this.lblSucheMandant.Name = "lblSucheMandant";
            this.lblSucheMandant.Size = new System.Drawing.Size(93, 24);
            this.lblSucheMandant.TabIndex = 0;
            this.lblSucheMandant.Text = "Mandant";
            // 
            // lblSucheMaTraeger
            // 
            this.lblSucheMaTraeger.Location = new System.Drawing.Point(30, 70);
            this.lblSucheMaTraeger.Name = "lblSucheMaTraeger";
            this.lblSucheMaTraeger.Size = new System.Drawing.Size(85, 24);
            this.lblSucheMaTraeger.TabIndex = 4;
            this.lblSucheMaTraeger.Text = "Mandatsträger";
            // 
            // edtSucheMaTraeger
            // 
            this.edtSucheMaTraeger.EditValue = "";
            this.edtSucheMaTraeger.Location = new System.Drawing.Point(129, 70);
            this.edtSucheMaTraeger.Name = "edtSucheMaTraeger";
            this.edtSucheMaTraeger.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMaTraeger.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMaTraeger.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMaTraeger.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMaTraeger.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMaTraeger.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMaTraeger.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheMaTraeger.Size = new System.Drawing.Size(172, 24);
            this.edtSucheMaTraeger.TabIndex = 5;
            // 
            // edtSucheMandant
            // 
            this.edtSucheMandant.EditValue = "";
            this.edtSucheMandant.Location = new System.Drawing.Point(129, 40);
            this.edtSucheMandant.Name = "edtSucheMandant";
            this.edtSucheMandant.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMandant.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMandant.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMandant.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMandant.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMandant.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMandant.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheMandant.Size = new System.Drawing.Size(172, 24);
            this.edtSucheMandant.TabIndex = 1;
            // 
            // lblTitelAuswahlMandant
            // 
            this.lblTitelAuswahlMandant.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitelAuswahlMandant.Location = new System.Drawing.Point(5, 10);
            this.lblTitelAuswahlMandant.Name = "lblTitelAuswahlMandant";
            this.lblTitelAuswahlMandant.Size = new System.Drawing.Size(145, 16);
            this.lblTitelAuswahlMandant.TabIndex = 0;
            this.lblTitelAuswahlMandant.Text = "Auswahl Mandant";
            // 
            // lblSucheTeam
            // 
            this.lblSucheTeam.Location = new System.Drawing.Point(30, 160);
            this.lblSucheTeam.Name = "lblSucheTeam";
            this.lblSucheTeam.Size = new System.Drawing.Size(93, 24);
            this.lblSucheTeam.TabIndex = 10;
            this.lblSucheTeam.Text = "Team";
            // 
            // edtSucheTeam
            // 
            this.edtSucheTeam.Location = new System.Drawing.Point(129, 160);
            this.edtSucheTeam.Name = "edtSucheTeam";
            this.edtSucheTeam.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTeam.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTeam.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTeam.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTeam.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTeam.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTeam.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTeam.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTeam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheTeam.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTeam.Properties.NullText = "";
            this.edtSucheTeam.Properties.ShowFooter = false;
            this.edtSucheTeam.Properties.ShowHeader = false;
            this.edtSucheTeam.Size = new System.Drawing.Size(265, 24);
            this.edtSucheTeam.TabIndex = 11;
            // 
            // edtSucheJournAblOrt
            // 
            this.edtSucheJournAblOrt.Location = new System.Drawing.Point(129, 190);
            this.edtSucheJournAblOrt.LOVName = "FbJournalablageort";
            this.edtSucheJournAblOrt.Name = "edtSucheJournAblOrt";
            this.edtSucheJournAblOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheJournAblOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheJournAblOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheJournAblOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheJournAblOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheJournAblOrt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheJournAblOrt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheJournAblOrt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheJournAblOrt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheJournAblOrt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheJournAblOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheJournAblOrt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheJournAblOrt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheJournAblOrt.Properties.NullText = "";
            this.edtSucheJournAblOrt.Properties.ShowFooter = false;
            this.edtSucheJournAblOrt.Properties.ShowHeader = false;
            this.edtSucheJournAblOrt.Size = new System.Drawing.Size(265, 24);
            this.edtSucheJournAblOrt.TabIndex = 13;
            // 
            // lblSucheJournAblOrt
            // 
            this.lblSucheJournAblOrt.Location = new System.Drawing.Point(30, 190);
            this.lblSucheJournAblOrt.Name = "lblSucheJournAblOrt";
            this.lblSucheJournAblOrt.Size = new System.Drawing.Size(93, 24);
            this.lblSucheJournAblOrt.TabIndex = 12;
            this.lblSucheJournAblOrt.Text = "Journalablageort";
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Controls.Add(this.tpgListe);
            this.tabControlSearch.Controls.Add(this.tpgSuchen);
            this.tabControlSearch.Location = new System.Drawing.Point(3, 29);
            this.tabControlSearch.Name = "tabControlSearch";
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.ShowFixedWidthTooltip = true;
            this.tabControlSearch.Size = new System.Drawing.Size(819, 297);
            this.tabControlSearch.TabIndex = 0;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
            this.tabControlSearch.TabsLineColor = System.Drawing.Color.Black;
            this.tabControlSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.gridMandant);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(807, 259);
            this.tpgListe.TabIndex = 0;
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.chkSuchePersonMitBuchhaltung);
            this.tpgSuchen.Controls.Add(this.lblSucheMandant);
            this.tpgSuchen.Controls.Add(this.edtSucheMandant);
            this.tpgSuchen.Controls.Add(this.lblSucheMaTraeger);
            this.tpgSuchen.Controls.Add(this.edtSuchePeriodeVon);
            this.tpgSuchen.Controls.Add(this.lblSuchePeriodeVon);
            this.tpgSuchen.Controls.Add(this.edtSucheMaTraeger);
            this.tpgSuchen.Controls.Add(this.edtSucheJournAblOrt);
            this.tpgSuchen.Controls.Add(this.edtSuchePeriodeBis);
            this.tpgSuchen.Controls.Add(this.lblSucheTeam);
            this.tpgSuchen.Controls.Add(this.edtSucheTeam);
            this.tpgSuchen.Controls.Add(this.lblSuchePeriodeBis);
            this.tpgSuchen.Controls.Add(this.lblSucheJournAblOrt);
            this.tpgSuchen.Controls.Add(this.chkSuchePersStamm);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(807, 259);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            // 
            // chkSuchePersonMitBuchhaltung
            // 
            this.chkSuchePersonMitBuchhaltung.Location = new System.Drawing.Point(129, 130);
            this.chkSuchePersonMitBuchhaltung.Name = "chkSuchePersonMitBuchhaltung";
            this.chkSuchePersonMitBuchhaltung.Size = new System.Drawing.Size(329, 24);
            this.chkSuchePersonMitBuchhaltung.TabIndex = 9;
            this.chkSuchePersonMitBuchhaltung.Text = "Suche nur Personen mit Buchhaltung";
            // 
            // panDetail
            // 
            this.panDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDetail.Controls.Add(this.edtPersonID);
            this.panDetail.Controls.Add(this.btnUebertragen);
            this.panDetail.Controls.Add(this.lblPersonNr);
            this.panDetail.Controls.Add(this.lblJournAblOrt);
            this.panDetail.Controls.Add(this.edtJournAblOrt);
            this.panDetail.Controls.Add(this.lblPeriodeId);
            this.panDetail.Controls.Add(this.editTeam);
            this.panDetail.Controls.Add(this.lblTeam);
            this.panDetail.Controls.Add(this.editPeriodeBis);
            this.panDetail.Controls.Add(this.editPeriodeVon);
            this.panDetail.Controls.Add(this.lblPeriodeBis);
            this.panDetail.Controls.Add(this.lblPeriodeVon);
            this.panDetail.Controls.Add(this.btnAbschluss);
            this.panDetail.Controls.Add(this.btnAktiv);
            this.panDetail.Controls.Add(this.lblTitelPerioden);
            this.panDetail.Controls.Add(this.btnSaldiVortragen);
            this.panDetail.Controls.Add(this.gridPeriode);
            this.panDetail.Location = new System.Drawing.Point(4, 323);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(818, 234);
            this.panDetail.TabIndex = 1;
            // 
            // edtPersonID
            // 
            this.edtPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPersonID.Location = new System.Drawing.Point(600, 31);
            this.edtPersonID.Name = "edtPersonID";
            this.edtPersonID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonID.Properties.DisplayFormat.FormatString = "################################";
            this.edtPersonID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtPersonID.Properties.EditFormat.FormatString = "################################";
            this.edtPersonID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtPersonID.Properties.Mask.EditMask = "################################";
            this.edtPersonID.Size = new System.Drawing.Size(96, 24);
            this.edtPersonID.TabIndex = 36;
            // 
            // btnUebertragen
            // 
            this.btnUebertragen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUebertragen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebertragen.Location = new System.Drawing.Point(702, 31);
            this.btnUebertragen.Name = "btnUebertragen";
            this.btnUebertragen.Size = new System.Drawing.Size(110, 24);
            this.btnUebertragen.TabIndex = 37;
            this.btnUebertragen.Text = "übertragen";
            this.btnUebertragen.UseVisualStyleBackColor = false;
            this.btnUebertragen.Click += new System.EventHandler(this.btnUebertragen_Click);
            this.btnUebertragen.Enter += new System.EventHandler(this.btnUebertragen_Enter);
            this.btnUebertragen.Leave += new System.EventHandler(this.btnUebertragen_Leave);
            this.btnUebertragen.MouseEnter += new System.EventHandler(this.btnUebertragen_MouseEnter);
            this.btnUebertragen.MouseLeave += new System.EventHandler(this.btnUebertragen_MouseLeave);
            // 
            // lblPersonNr
            // 
            this.lblPersonNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonNr.Location = new System.Drawing.Point(451, 31);
            this.lblPersonNr.Name = "lblPersonNr";
            this.lblPersonNr.Size = new System.Drawing.Size(143, 24);
            this.lblPersonNr.TabIndex = 35;
            this.lblPersonNr.Text = "alle Perioden an Pers. Nr.";
            // 
            // lblJournAblOrt
            // 
            this.lblJournAblOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJournAblOrt.Location = new System.Drawing.Point(448, 162);
            this.lblJournAblOrt.Name = "lblJournAblOrt";
            this.lblJournAblOrt.Size = new System.Drawing.Size(93, 24);
            this.lblJournAblOrt.TabIndex = 47;
            this.lblJournAblOrt.Text = "Journalablageort";
            // 
            // edtJournAblOrt
            // 
            this.edtJournAblOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtJournAblOrt.DataMember = "JournalablageortCode";
            this.edtJournAblOrt.DataSource = this.qryPeriode;
            this.edtJournAblOrt.Location = new System.Drawing.Point(547, 162);
            this.edtJournAblOrt.LOVName = "FbJournalablageort";
            this.edtJournAblOrt.Name = "edtJournAblOrt";
            this.edtJournAblOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJournAblOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJournAblOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJournAblOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtJournAblOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJournAblOrt.Properties.Appearance.Options.UseFont = true;
            this.edtJournAblOrt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtJournAblOrt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtJournAblOrt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtJournAblOrt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtJournAblOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtJournAblOrt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtJournAblOrt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtJournAblOrt.Properties.NullText = "";
            this.edtJournAblOrt.Properties.ShowFooter = false;
            this.edtJournAblOrt.Properties.ShowHeader = false;
            this.edtJournAblOrt.Size = new System.Drawing.Size(265, 24);
            this.edtJournAblOrt.TabIndex = 48;
            // 
            // lblPeriodeId
            // 
            this.lblPeriodeId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriodeId.DataMember = "FbPeriodeID";
            this.lblPeriodeId.DataSource = this.qryPeriode;
            this.lblPeriodeId.Location = new System.Drawing.Point(712, 72);
            this.lblPeriodeId.Name = "lblPeriodeId";
            this.lblPeriodeId.Size = new System.Drawing.Size(100, 24);
            this.lblPeriodeId.TabIndex = 42;
            this.lblPeriodeId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // editTeam
            // 
            this.editTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editTeam.DataMember = "FbTeamID";
            this.editTeam.DataSource = this.qryPeriode;
            this.editTeam.Location = new System.Drawing.Point(547, 132);
            this.editTeam.Name = "editTeam";
            this.editTeam.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editTeam.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editTeam.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editTeam.Properties.Appearance.Options.UseBackColor = true;
            this.editTeam.Properties.Appearance.Options.UseBorderColor = true;
            this.editTeam.Properties.Appearance.Options.UseFont = true;
            this.editTeam.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editTeam.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editTeam.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editTeam.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editTeam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editTeam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editTeam.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editTeam.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name")});
            this.editTeam.Properties.DisplayMember = "Name";
            this.editTeam.Properties.NullText = "";
            this.editTeam.Properties.ShowFooter = false;
            this.editTeam.Properties.ShowHeader = false;
            this.editTeam.Properties.ValueMember = "FbTeamID";
            this.editTeam.Size = new System.Drawing.Size(265, 24);
            this.editTeam.TabIndex = 46;
            // 
            // lblTeam
            // 
            this.lblTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTeam.Location = new System.Drawing.Point(451, 132);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(56, 24);
            this.lblTeam.TabIndex = 45;
            this.lblTeam.Text = "Team";
            // 
            // editPeriodeBis
            // 
            this.editPeriodeBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editPeriodeBis.DataMember = "PeriodeBis";
            this.editPeriodeBis.DataSource = this.qryPeriode;
            this.editPeriodeBis.EditValue = new System.DateTime(2004, 7, 17, 0, 0, 0, 0);
            this.editPeriodeBis.Location = new System.Drawing.Point(547, 102);
            this.editPeriodeBis.Name = "editPeriodeBis";
            this.editPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.editPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.editPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.editPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editPeriodeBis.Properties.ShowToday = false;
            this.editPeriodeBis.Size = new System.Drawing.Size(95, 24);
            this.editPeriodeBis.TabIndex = 44;
            // 
            // editPeriodeVon
            // 
            this.editPeriodeVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editPeriodeVon.Cursor = System.Windows.Forms.Cursors.Default;
            this.editPeriodeVon.DataMember = "PeriodeVon";
            this.editPeriodeVon.DataSource = this.qryPeriode;
            this.editPeriodeVon.EditValue = new System.DateTime(2004, 7, 17, 0, 0, 0, 0);
            this.editPeriodeVon.Location = new System.Drawing.Point(547, 72);
            this.editPeriodeVon.Name = "editPeriodeVon";
            this.editPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.editPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.editPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.editPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.editPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.editPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editPeriodeVon.Properties.ShowToday = false;
            this.editPeriodeVon.Size = new System.Drawing.Size(95, 24);
            this.editPeriodeVon.TabIndex = 41;
            // 
            // lblPeriodeBis
            // 
            this.lblPeriodeBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriodeBis.Location = new System.Drawing.Point(451, 102);
            this.lblPeriodeBis.Name = "lblPeriodeBis";
            this.lblPeriodeBis.Size = new System.Drawing.Size(76, 24);
            this.lblPeriodeBis.TabIndex = 43;
            this.lblPeriodeBis.Text = "Periode bis";
            // 
            // lblPeriodeVon
            // 
            this.lblPeriodeVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriodeVon.Location = new System.Drawing.Point(451, 72);
            this.lblPeriodeVon.Name = "lblPeriodeVon";
            this.lblPeriodeVon.Size = new System.Drawing.Size(86, 24);
            this.lblPeriodeVon.TabIndex = 40;
            this.lblPeriodeVon.Text = "Periode von";
            // 
            // btnAbschluss
            // 
            this.btnAbschluss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbschluss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbschluss.Location = new System.Drawing.Point(586, 193);
            this.btnAbschluss.Name = "btnAbschluss";
            this.btnAbschluss.Size = new System.Drawing.Size(110, 24);
            this.btnAbschluss.TabIndex = 50;
            this.btnAbschluss.Text = "Abschluss";
            this.btnAbschluss.UseVisualStyleBackColor = false;
            this.btnAbschluss.Click += new System.EventHandler(this.btnAbschluss_Click);
            // 
            // btnAktiv
            // 
            this.btnAktiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAktiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAktiv.Location = new System.Drawing.Point(470, 193);
            this.btnAktiv.Name = "btnAktiv";
            this.btnAktiv.Size = new System.Drawing.Size(110, 24);
            this.btnAktiv.TabIndex = 49;
            this.btnAktiv.Text = "Aktiv / Inaktiv";
            this.btnAktiv.UseVisualStyleBackColor = false;
            this.btnAktiv.Click += new System.EventHandler(this.btnAktiv_Click);
            // 
            // lblTitelPerioden
            // 
            this.lblTitelPerioden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitelPerioden.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitelPerioden.Location = new System.Drawing.Point(7, 6);
            this.lblTitelPerioden.Name = "lblTitelPerioden";
            this.lblTitelPerioden.Size = new System.Drawing.Size(80, 16);
            this.lblTitelPerioden.TabIndex = 38;
            this.lblTitelPerioden.Text = "Perioden";
            // 
            // btnSaldiVortragen
            // 
            this.btnSaldiVortragen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaldiVortragen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaldiVortragen.Location = new System.Drawing.Point(702, 193);
            this.btnSaldiVortragen.Name = "btnSaldiVortragen";
            this.btnSaldiVortragen.Size = new System.Drawing.Size(110, 24);
            this.btnSaldiVortragen.TabIndex = 51;
            this.btnSaldiVortragen.Text = "Saldi vortragen";
            this.btnSaldiVortragen.UseVisualStyleBackColor = false;
            this.btnSaldiVortragen.Click += new System.EventHandler(this.btnSaldiVortragen_Click);
            // 
            // gridPeriode
            // 
            this.gridPeriode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPeriode.DataSource = this.qryPeriode;
            // 
            // 
            // 
            this.gridPeriode.EmbeddedNavigator.Name = "";
            this.gridPeriode.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridPeriode.ImeMode = System.Windows.Forms.ImeMode.On;
            this.gridPeriode.Location = new System.Drawing.Point(7, 31);
            this.gridPeriode.MainView = this.gridView2;
            this.gridPeriode.Name = "gridPeriode";
            this.gridPeriode.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.grideditTeam});
            this.gridPeriode.Size = new System.Drawing.Size(435, 200);
            this.gridPeriode.TabIndex = 39;
            this.gridPeriode.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVon,
            this.colBis,
            this.colStatus,
            this.colTeam});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.gridPeriode;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsMenu.EnableColumnMenu = false;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsPrint.AutoWidth = false;
            this.gridView2.OptionsPrint.UsePrintStyles = true;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowDetailButtons = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // colVon
            // 
            this.colVon.Caption = "Periode Von";
            this.colVon.DisplayFormat.FormatString = "d";
            this.colVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colVon.FieldName = "PeriodeVon";
            this.colVon.Name = "colVon";
            this.colVon.Visible = true;
            this.colVon.VisibleIndex = 0;
            this.colVon.Width = 94;
            // 
            // colBis
            // 
            this.colBis.Caption = "Periode Bis";
            this.colBis.DisplayFormat.FormatString = "d";
            this.colBis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBis.FieldName = "PeriodeBis";
            this.colBis.Name = "colBis";
            this.colBis.Visible = true;
            this.colBis.VisibleIndex = 1;
            this.colBis.Width = 88;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "PeriodeStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 101;
            // 
            // colTeam
            // 
            this.colTeam.Caption = "Team";
            this.colTeam.ColumnEdit = this.grideditTeam;
            this.colTeam.FieldName = "FbTeamID";
            this.colTeam.Name = "colTeam";
            this.colTeam.Visible = true;
            this.colTeam.VisibleIndex = 3;
            this.colTeam.Width = 128;
            // 
            // grideditTeam
            // 
            this.grideditTeam.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grideditTeam.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grideditTeam.AppearanceDropDown.Options.UseBackColor = true;
            this.grideditTeam.AppearanceDropDown.Options.UseFont = true;
            this.grideditTeam.AutoHeight = false;
            this.grideditTeam.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grideditTeam.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name")});
            this.grideditTeam.DisplayMember = "Name";
            this.grideditTeam.Name = "grideditTeam";
            this.grideditTeam.NullText = "";
            this.grideditTeam.ShowFooter = false;
            this.grideditTeam.ShowHeader = false;
            this.grideditTeam.ValueMember = "FbTeamID";
            // 
            // CtlFibuPeriode
            // 
            this.ActiveSQLQuery = this.qryPeriode;
            this.AutoRefresh = false;
            this.Controls.Add(this.panDetail);
            this.Controls.Add(this.lblTitelAuswahlMandant);
            this.Controls.Add(this.tabControlSearch);
            this.Name = "CtlFibuPeriode";
            this.Size = new System.Drawing.Size(825, 560);
            this.Search += new System.EventHandler(this.CtlFibuPeriode_Search);
            this.Load += new System.EventHandler(this.CtlFibuPeriode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePeriodeBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePeriodeVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMaTraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMaTraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMandant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelAuswahlMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJournAblOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheJournAblOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheJournAblOrt)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJournAblOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJournAblOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJournAblOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelPerioden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grideditTeam)).EndInit();
            this.ResumeLayout(false);

		}

        private void chkSuchePersStamm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSuchePersStamm.Checked)
            {
                edtSucheMaTraeger.EditMode = EditModeType.ReadOnly;
                edtSucheMaTraeger.EditValue = string.Empty;
            }
            else
            {
                edtSucheMaTraeger.EditMode = EditModeType.Normal;
            }

        }
		#endregion

        private Panel panDetail;
        private KissIntEdit edtPersonID;
        private KissButton btnUebertragen;
        private KissLabel lblPersonNr;
        private KissLabel lblJournAblOrt;
        private KissLookUpEdit edtJournAblOrt;
        private KissLabel lblPeriodeId;
        private KissLookUpEdit editTeam;
        private KissLabel lblTeam;
        private KissDateEdit editPeriodeBis;
        private KissDateEdit editPeriodeVon;
        private KissLabel lblPeriodeBis;
        private KissLabel lblPeriodeVon;
        private KissButton btnAbschluss;
        private KissButton btnAktiv;
        private KissLabel lblTitelPerioden;
        private KissButton btnSaldiVortragen;
        private KissGrid gridPeriode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTeam;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit grideditTeam;
        private CheckBox chkSuchePersonMitBuchhaltung;


    }
}

