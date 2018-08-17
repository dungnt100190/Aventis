using System;
using System.Data;
using System.Drawing;
using KiSS4.DB;
using KiSS4.Common;
using KiSS.DBScheme;


namespace KiSS4.Sozialhilfe
{
	public class CtlBgErwerbseinkommen : KiSS4.Gui.KissUserControl
	{
		private KiSS4.Gui.KissGrid grdBgPosition;
		private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
		private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
		private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
		private DevExpress.XtraGrid.Columns.GridColumn colBgPositionsartID;
		private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
		private DevExpress.XtraGrid.Columns.GridColumn colUKBetrag;
		private DevExpress.XtraGrid.Columns.GridColumn colUKReduktion;
		private KiSS4.Gui.KissLookUpEdit edtBgPositionsartID;
		private KiSS4.Gui.KissLabel lblBgPositionsartID;
		private KiSS4.Gui.KissLabel lblBemerkung;
		private KiSS4.Gui.KissLabel lblEffektiv;
		private KiSS4.Gui.KissLabel lblReduktion;
		private KiSS4.Gui.KissLabel lblAngerechnet;
		private KiSS4.Gui.KissLabel lblTitel;
		private System.Windows.Forms.PictureBox picTitel;
		private KiSS4.DB.SqlQuery qryBgPosition;
		private KiSS4.Gui.KissMemoEdit edtBemerkung;
		private KiSS4.Gui.KissCheckEdit edtVerwaltungSD;
		private KiSS4.Gui.KissCalcEdit edtBetrag;
		private System.ComponentModel.IContainer components = null;
		private KiSS4.Gui.KissLabel lblTotal;
		private KiSS4.Gui.KissCalcEdit edtUKBetrag;
		private KiSS4.Gui.KissCalcEdit txtUKAng;
		private KiSS4.Gui.KissCalcEdit txtTotal;
		private KiSS4.Gui.KissLabel lblUKBetragMinusAbzug;
		private KiSS4.Gui.KissLabel lblUKBetragMinusAbzugEq;
		private KiSS4.Gui.KissLabel lblAngPlus;
		private KiSS4.Gui.KissLabel lblUKAngMinus;
		private KiSS4.Gui.KissLabel lblEinkommen;
        private KiSS4.Gui.KissLabel lblUKEinkommen;
		private KiSS4.Gui.KissCalcEdit edtUKReduktion;
		private KiSS4.Gui.KissLabel lblBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private KiSS4.Gui.KissCheckEdit edtNurAktuelle;
		private KiSS4.Gui.KissLookUpEdit edtBaPersonID;

        private DateTime finanzplanVon;

        LOV.BgGruppeCode BgGruppeCode = LOV.BgGruppeCode.Erwerbseinkommen;

        private int BgBudgetID;
        private int BgFinanzplanID;
        private SqlQuery qryBgPositionsart;

		public CtlBgErwerbseinkommen()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		public CtlBgErwerbseinkommen(Image titelImage, string titelText, int bgBudgetID) : this()
		{
			this.picTitel.Image = titelImage;
			this.BgBudgetID = bgBudgetID;

			SqlQuery qry = DBUtil.OpenSQL(@"
				SELECT SFP.BgFinanzplanID,
				  FinanzplanVon = IsNull(SFP.DatumVon, SFP.GeplantVon),
				  FinanzplanBis = IsNull(SFP.DatumBis, SFP.GeplantBis)
				FROM BgBudget             BBG
				  INNER JOIN BgFinanzplan SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
				WHERE BBG.BgBudgetID = {0}"
				, bgBudgetID);
			this.lblTitel.Text = string.Format(this.lblTitel.Text, qry["FinanzplanVon"], qry["FinanzplanBis"], titelText);
            this.BgFinanzplanID = Utils.ConvertToInt(qry["BgFinanzplanID"]);
            //zur Bestimmung der gültigen BgPositionsartIDs wird der Gültigkeitsbereich des Finanzplans verwendet.
            finanzplanVon = Utils.ConvertToDateTime(qry["FinanzplanVon"]);
            DateTime finanzplanBis = Utils.ConvertToDateTime(qry["FinanzplanBis"]);

			qry = ShUtil.GetPersonen_Unterstuetzt(BgBudgetID);
			this.colBaPersonID.ColumnEdit = this.grdBgPosition.GetLOVLookUpEdit(qry, "BaPersonID", "NameVorname");
			this.edtBaPersonID.LoadQuery(qry, "BaPersonID", "NameVorname");

			qryBgPositionsart = ShUtil.GetSqlQueryShPositionTyp(BgGruppeCode, finanzplanVon, finanzplanBis, false);
			this.colBgPositionsartID.ColumnEdit = this.grdBgPosition.GetLOVLookUpEdit(qryBgPositionsart);
			this.edtBgPositionsartID.LoadQuery(qryBgPositionsart);

			ShUtil.ApplyShStatusCodeToSqlQuery(this.ActiveSQLQuery, BgBudgetID);
            this.qryBgPosition.Fill(qryBgPosition.SelectStatement, BgBudgetID, BgGruppeCode, edtNurAktuelle.Checked);
		}


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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBgErwerbseinkommen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBgPositionsartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUKBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUKReduktion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.edtVerwaltungSD = new KiSS4.Gui.KissCheckEdit();
            this.lblBgPositionsartID = new KiSS4.Gui.KissLabel();
            this.edtBgPositionsartID = new KiSS4.Gui.KissLookUpEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtUKBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtUKReduktion = new KiSS4.Gui.KissCalcEdit();
            this.txtUKAng = new KiSS4.Gui.KissCalcEdit();
            this.txtTotal = new KiSS4.Gui.KissCalcEdit();
            this.lblUKBetragMinusAbzug = new KiSS4.Gui.KissLabel();
            this.lblUKBetragMinusAbzugEq = new KiSS4.Gui.KissLabel();
            this.lblAngPlus = new KiSS4.Gui.KissLabel();
            this.lblUKAngMinus = new KiSS4.Gui.KissLabel();
            this.lblEffektiv = new KiSS4.Gui.KissLabel();
            this.lblReduktion = new KiSS4.Gui.KissLabel();
            this.lblAngerechnet = new KiSS4.Gui.KissLabel();
            this.lblEinkommen = new KiSS4.Gui.KissLabel();
            this.lblUKEinkommen = new KiSS4.Gui.KissLabel();
            this.lblTotal = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtNurAktuelle = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUKBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUKReduktion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUKAng.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUKBetragMinusAbzug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUKBetragMinusAbzugEq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngPlus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUKAngMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEffektiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReduktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngerechnet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinkommen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUKEinkommen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktuelle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryBgPosition;
            this.edtBemerkung.Location = new System.Drawing.Point(8, 376);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(664, 100);
            this.edtBemerkung.TabIndex = 22;
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.CanDelete = true;
            this.qryBgPosition.CanInsert = true;
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.AfterInsert += new System.EventHandler(this.qryBgPosition_AfterInsert);
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.AfterPost += new System.EventHandler(this.qryBgPosition_AfterPost);
            this.qryBgPosition.BeforeDelete += new System.EventHandler(this.qryBgPosition_BeforeDelete);
            this.qryBgPosition.AfterDelete += new System.EventHandler(this.qryBgPosition_AfterDelete);
            // 
            // grdBgPosition
            // 
            this.grdBgPosition.DataSource = this.qryBgPosition;
            // 
            // 
            // 
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPosition.Location = new System.Drawing.Point(8, 37);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.Size = new System.Drawing.Size(664, 183);
            this.grdBgPosition.TabIndex = 1;
            this.grdBgPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPosition});
            // 
            // grvBgPosition
            // 
            this.grvBgPosition.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgPosition.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Empty.Options.UseFont = true;
            this.grvBgPosition.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgPosition.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.OddRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Row.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Row.Options.UseFont = true;
            this.grvBgPosition.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgPosition.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgPosition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatumVon,
            this.colBaPersonID,
            this.colGeburtsdatum,
            this.colBgPositionsartID,
            this.colBetrag,
            this.colUKBetrag,
            this.colUKReduktion});
            this.grvBgPosition.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgPosition.GridControl = this.grdBgPosition;
            this.grvBgPosition.Name = "grvBgPosition";
            this.grvBgPosition.OptionsBehavior.Editable = false;
            this.grvBgPosition.OptionsCustomization.AllowFilter = false;
            this.grvBgPosition.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgPosition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgPosition.OptionsNavigation.UseTabKey = false;
            this.grvBgPosition.OptionsView.ColumnAutoWidth = false;
            this.grvBgPosition.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgPosition.OptionsView.ShowFooter = true;
            this.grvBgPosition.OptionsView.ShowGroupPanel = false;
            this.grvBgPosition.OptionsView.ShowIndicator = false;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Gültig ab";
            this.colDatumVon.DisplayFormat.FormatString = "Y";
            this.colDatumVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            this.colDatumVon.Width = 69;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Caption = "Name";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 1;
            this.colBaPersonID.Width = 130;
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Caption = "Geburtsdatum";
            this.colGeburtsdatum.DisplayFormat.FormatString = "d";
            this.colGeburtsdatum.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colGeburtsdatum.FieldName = "Geburtsdatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 2;
            this.colGeburtsdatum.Width = 90;
            // 
            // colBgPositionsartID
            // 
            this.colBgPositionsartID.Caption = "Art des Einkommens";
            this.colBgPositionsartID.FieldName = "BgPositionsartID";
            this.colBgPositionsartID.Name = "colBgPositionsartID";
            this.colBgPositionsartID.Visible = true;
            this.colBgPositionsartID.VisibleIndex = 3;
            this.colBgPositionsartID.Width = 128;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBetrag.Caption = "Einkommen";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 4;
            this.colBetrag.Width = 80;
            // 
            // colUKBetrag
            // 
            this.colUKBetrag.AppearanceCell.Options.UseTextOptions = true;
            this.colUKBetrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colUKBetrag.Caption = "Unkosten";
            this.colUKBetrag.DisplayFormat.FormatString = "n2";
            this.colUKBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUKBetrag.FieldName = "UKBetrag";
            this.colUKBetrag.Name = "colUKBetrag";
            this.colUKBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colUKBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colUKBetrag.Visible = true;
            this.colUKBetrag.VisibleIndex = 5;
            // 
            // colUKReduktion
            // 
            this.colUKReduktion.AppearanceCell.Options.UseTextOptions = true;
            this.colUKReduktion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colUKReduktion.Caption = "Reduktion";
            this.colUKReduktion.DisplayFormat.FormatString = "n2";
            this.colUKReduktion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUKReduktion.FieldName = "UKReduktion";
            this.colUKReduktion.Name = "colUKReduktion";
            this.colUKReduktion.SummaryItem.DisplayFormat = "{0:n2}";
            this.colUKReduktion.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colUKReduktion.Visible = true;
            this.colUKReduktion.VisibleIndex = 6;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(32, 8);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(640, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Monatliches Erwerbseinkommen vom {0:d} bis {1:d}";
            // 
            // edtVerwaltungSD
            // 
            this.edtVerwaltungSD.DataMember = "VerwaltungSD";
            this.edtVerwaltungSD.DataSource = this.qryBgPosition;
            this.edtVerwaltungSD.Location = new System.Drawing.Point(8, 280);
            this.edtVerwaltungSD.Name = "edtVerwaltungSD";
            this.edtVerwaltungSD.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtVerwaltungSD.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwaltungSD.Properties.Caption = "von SD verwaltet";
            this.edtVerwaltungSD.Size = new System.Drawing.Size(120, 19);
            this.edtVerwaltungSD.TabIndex = 5;
            // 
            // lblBgPositionsartID
            // 
            this.lblBgPositionsartID.Location = new System.Drawing.Point(8, 256);
            this.lblBgPositionsartID.Name = "lblBgPositionsartID";
            this.lblBgPositionsartID.Size = new System.Drawing.Size(144, 24);
            this.lblBgPositionsartID.TabIndex = 3;
            this.lblBgPositionsartID.Text = "Art des Einkommens";
            // 
            // edtBgPositionsartID
            // 
            this.edtBgPositionsartID.DataMember = "BgPositionsartID";
            this.edtBgPositionsartID.DataSource = this.qryBgPosition;
            this.edtBgPositionsartID.Location = new System.Drawing.Point(148, 256);
            this.edtBgPositionsartID.Name = "edtBgPositionsartID";
            this.edtBgPositionsartID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgPositionsartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgPositionsartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgPositionsartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgPositionsartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBgPositionsartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBgPositionsartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgPositionsartID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBgPositionsartID.Properties.DisplayMember = "Text";
            this.edtBgPositionsartID.Properties.NullText = "";
            this.edtBgPositionsartID.Properties.ShowFooter = false;
            this.edtBgPositionsartID.Properties.ShowHeader = false;
            this.edtBgPositionsartID.Properties.ValueMember = "Code";
            this.edtBgPositionsartID.Size = new System.Drawing.Size(524, 24);
            this.edtBgPositionsartID.TabIndex = 4;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 360);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(112, 16);
            this.lblBemerkung.TabIndex = 21;
            this.lblBemerkung.Text = "Beschreibung";
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.Location = new System.Drawing.Point(152, 304);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(112, 24);
            this.edtBetrag.TabIndex = 8;
            this.edtBetrag.EditValueChanged += new System.EventHandler(this.Detail_EditValueChanged);
            // 
            // edtUKBetrag
            // 
            this.edtUKBetrag.DataMember = "UKBetrag";
            this.edtUKBetrag.DataSource = this.qryBgPosition;
            this.edtUKBetrag.Location = new System.Drawing.Point(152, 327);
            this.edtUKBetrag.Name = "edtUKBetrag";
            this.edtUKBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUKBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUKBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUKBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUKBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtUKBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUKBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtUKBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUKBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUKBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtUKBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtUKBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtUKBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtUKBetrag.Size = new System.Drawing.Size(112, 24);
            this.edtUKBetrag.TabIndex = 14;
            this.edtUKBetrag.EditValueChanged += new System.EventHandler(this.Detail_EditValueChanged);
            // 
            // edtUKReduktion
            // 
            this.edtUKReduktion.DataMember = "UKReduktion";
            this.edtUKReduktion.DataSource = this.qryBgPosition;
            this.edtUKReduktion.Location = new System.Drawing.Point(288, 327);
            this.edtUKReduktion.Name = "edtUKReduktion";
            this.edtUKReduktion.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUKReduktion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUKReduktion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUKReduktion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUKReduktion.Properties.Appearance.Options.UseBackColor = true;
            this.edtUKReduktion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUKReduktion.Properties.Appearance.Options.UseFont = true;
            this.edtUKReduktion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUKReduktion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUKReduktion.Properties.DisplayFormat.FormatString = "n2";
            this.edtUKReduktion.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtUKReduktion.Properties.EditFormat.FormatString = "n2";
            this.edtUKReduktion.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtUKReduktion.Size = new System.Drawing.Size(112, 24);
            this.edtUKReduktion.TabIndex = 16;
            this.edtUKReduktion.EditValueChanged += new System.EventHandler(this.Detail_EditValueChanged);
            // 
            // txtUKAng
            // 
            this.txtUKAng.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtUKAng.Location = new System.Drawing.Point(424, 327);
            this.txtUKAng.Name = "txtUKAng";
            this.txtUKAng.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtUKAng.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtUKAng.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtUKAng.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtUKAng.Properties.Appearance.Options.UseBackColor = true;
            this.txtUKAng.Properties.Appearance.Options.UseBorderColor = true;
            this.txtUKAng.Properties.Appearance.Options.UseFont = true;
            this.txtUKAng.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtUKAng.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.txtUKAng.Properties.DisplayFormat.FormatString = "n2";
            this.txtUKAng.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUKAng.Properties.EditFormat.FormatString = "n2";
            this.txtUKAng.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUKAng.Properties.ReadOnly = true;
            this.txtUKAng.Size = new System.Drawing.Size(112, 24);
            this.txtUKAng.TabIndex = 18;
            // 
            // txtTotal
            // 
            this.txtTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.txtTotal.Location = new System.Drawing.Point(560, 327);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtTotal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtTotal.Properties.Appearance.Options.UseBackColor = true;
            this.txtTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.txtTotal.Properties.DisplayFormat.FormatString = "n2";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.EditFormat.FormatString = "n2";
            this.txtTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(112, 24);
            this.txtTotal.TabIndex = 20;
            // 
            // lblUKBetragMinusAbzug
            // 
            this.lblUKBetragMinusAbzug.Location = new System.Drawing.Point(272, 328);
            this.lblUKBetragMinusAbzug.Name = "lblUKBetragMinusAbzug";
            this.lblUKBetragMinusAbzug.Size = new System.Drawing.Size(8, 24);
            this.lblUKBetragMinusAbzug.TabIndex = 15;
            this.lblUKBetragMinusAbzug.Text = "-";
            // 
            // lblUKBetragMinusAbzugEq
            // 
            this.lblUKBetragMinusAbzugEq.Location = new System.Drawing.Point(408, 328);
            this.lblUKBetragMinusAbzugEq.Name = "lblUKBetragMinusAbzugEq";
            this.lblUKBetragMinusAbzugEq.Size = new System.Drawing.Size(8, 24);
            this.lblUKBetragMinusAbzugEq.TabIndex = 17;
            this.lblUKBetragMinusAbzugEq.Text = "=";
            // 
            // lblAngPlus
            // 
            this.lblAngPlus.Location = new System.Drawing.Point(544, 304);
            this.lblAngPlus.Name = "lblAngPlus";
            this.lblAngPlus.Size = new System.Drawing.Size(8, 24);
            this.lblAngPlus.TabIndex = 12;
            this.lblAngPlus.Text = "+";
            // 
            // lblUKAngMinus
            // 
            this.lblUKAngMinus.Location = new System.Drawing.Point(544, 328);
            this.lblUKAngMinus.Name = "lblUKAngMinus";
            this.lblUKAngMinus.Size = new System.Drawing.Size(8, 24);
            this.lblUKAngMinus.TabIndex = 19;
            this.lblUKAngMinus.Text = "-";
            // 
            // lblEffektiv
            // 
            this.lblEffektiv.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblEffektiv.Location = new System.Drawing.Point(152, 288);
            this.lblEffektiv.Name = "lblEffektiv";
            this.lblEffektiv.Size = new System.Drawing.Size(112, 16);
            this.lblEffektiv.TabIndex = 7;
            this.lblEffektiv.Text = "Effektiv";
            // 
            // lblReduktion
            // 
            this.lblReduktion.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblReduktion.Location = new System.Drawing.Point(284, 288);
            this.lblReduktion.Name = "lblReduktion";
            this.lblReduktion.Size = new System.Drawing.Size(112, 16);
            this.lblReduktion.TabIndex = 9;
            this.lblReduktion.Text = "Reduktion";
            // 
            // lblAngerechnet
            // 
            this.lblAngerechnet.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblAngerechnet.Location = new System.Drawing.Point(424, 288);
            this.lblAngerechnet.Name = "lblAngerechnet";
            this.lblAngerechnet.Size = new System.Drawing.Size(112, 16);
            this.lblAngerechnet.TabIndex = 10;
            this.lblAngerechnet.Text = "Angerechnet";
            // 
            // lblEinkommen
            // 
            this.lblEinkommen.Location = new System.Drawing.Point(8, 304);
            this.lblEinkommen.Name = "lblEinkommen";
            this.lblEinkommen.Size = new System.Drawing.Size(140, 24);
            this.lblEinkommen.TabIndex = 6;
            this.lblEinkommen.Text = "Monatliches Einkommen";
            // 
            // lblUKEinkommen
            // 
            this.lblUKEinkommen.Location = new System.Drawing.Point(8, 327);
            this.lblUKEinkommen.Name = "lblUKEinkommen";
            this.lblUKEinkommen.Size = new System.Drawing.Size(140, 24);
            this.lblUKEinkommen.TabIndex = 13;
            this.lblUKEinkommen.Text = "Effektive Erwerbsunkosten";
            // 
            // lblTotal
            // 
            this.lblTotal.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblTotal.Location = new System.Drawing.Point(560, 288);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(112, 16);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total";
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(8, 8);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 55;
            this.picTitel.TabStop = false;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(8, 226);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(134, 24);
            this.lblBaPersonID.TabIndex = 72;
            this.lblBaPersonID.Text = "Person";
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(148, 226);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBaPersonID.Properties.DisplayMember = "Text";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "Code";
            this.edtBaPersonID.Size = new System.Drawing.Size(524, 24);
            this.edtBaPersonID.TabIndex = 71;
            // 
            // edtNurAktuelle
            // 
            this.edtNurAktuelle.EditValue = false;
            this.edtNurAktuelle.Location = new System.Drawing.Point(543, 8);
            this.edtNurAktuelle.Name = "edtNurAktuelle";
            this.edtNurAktuelle.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurAktuelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktuelle.Properties.Caption = "Nur aktuelle anzeigen";
            this.edtNurAktuelle.Size = new System.Drawing.Size(129, 19);
            this.edtNurAktuelle.TabIndex = 73;
            this.edtNurAktuelle.CheckedChanged += new System.EventHandler(this.edtNurAktive_CheckedChanged);
            // 
            // CtlBgErwerbseinkommen
            // 
            this.ActiveSQLQuery = this.qryBgPosition;
            this.Controls.Add(this.edtNurAktuelle);
            this.Controls.Add(this.lblBaPersonID);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblUKEinkommen);
            this.Controls.Add(this.lblEinkommen);
            this.Controls.Add(this.lblAngerechnet);
            this.Controls.Add(this.lblReduktion);
            this.Controls.Add(this.lblEffektiv);
            this.Controls.Add(this.lblUKAngMinus);
            this.Controls.Add(this.lblAngPlus);
            this.Controls.Add(this.lblUKBetragMinusAbzugEq);
            this.Controls.Add(this.lblUKBetragMinusAbzug);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtUKAng);
            this.Controls.Add(this.edtUKReduktion);
            this.Controls.Add(this.edtUKBetrag);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtBgPositionsartID);
            this.Controls.Add(this.lblBgPositionsartID);
            this.Controls.Add(this.edtVerwaltungSD);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.grdBgPosition);
            this.Controls.Add(this.edtBemerkung);
            this.Name = "CtlBgErwerbseinkommen";
            this.Size = new System.Drawing.Size(680, 488);
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwaltungSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgPositionsartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUKBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUKReduktion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUKAng.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUKBetragMinusAbzug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUKBetragMinusAbzugEq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngPlus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUKAngMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEffektiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblReduktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAngerechnet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinkommen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUKEinkommen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktuelle.Properties)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region qryBgPosition_Insert
		private void qryBgPosition_AfterInsert(object sender, System.EventArgs e)
		{
			this.qryBgPosition["BgBudgetID"] = this.BgBudgetID;
			this.qryBgPosition["BgKategorieCode"] = 1;

			this.qryBgPosition["UKBetrag"] = "0.00";
			this.qryBgPosition["UKReduktion"] = "0.00";

			this.edtBaPersonID.Focus();
		}
		#endregion

		#region qryBgPosition_Post
		private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
		{
			DBUtil.CheckNotNullField(edtBaPersonID, lblBaPersonID.Text);

			DBUtil.CheckNotNullField(edtBgPositionsartID, lblBgPositionsartID.Text);

			DBUtil.CheckNotNullField(this.edtBetrag, KissMsg.GetMLMessage("CtlBgErwerbseinkommen", "BetragEinkommen", "Betrag Einkommen"));
			DBUtil.CheckNotNullField(this.edtUKBetrag, KissMsg.GetMLMessage("CtlBgErwerbseinkommen", "BetragUnkosten", "Betrag Unkosten"));
			DBUtil.CheckNotNullField(this.edtUKReduktion, KissMsg.GetMLMessage("CtlBgErwerbseinkommen", "ReduktionUnkosten", "Reduktion Unkosten"));

			if ((DBUtil.IsEmpty(qryBgPosition["Buchungstext"]) || qryBgPosition.ColumnModified("BgPositionsartID"))
				&& qryBgPositionsart.Find(string.Format("BgPositionsartID = {0}", qryBgPosition["BgPositionsartID"])))
			{
				qryBgPosition["Buchungstext"] = qryBgPositionsart["Name"];
			}

            SqlQuery qry = DBUtil.OpenSQL("SELECT Geburtsdatum FROM BaPerson WHERE BaPersonID = {0}", qryBgPosition["BaPersonID"]);
            qryBgPosition["Geburtsdatum"] = qry["Geburtsdatum"];

			Session.BeginTransaction();
            //da kein Code nach Transaktionsöffung folgt gibts hier nichts zu tun, Rest folgt im After Post
		}

        private void qryBgPosition_AfterPost(object sender, System.EventArgs e)
        {
            try
            {
                if (qryBgPosition.Row.RowState != DataRowState.Deleted)
                {
                    SqlQuery qry = DBUtil.OpenSQL(@"
    				SELECT 
                      POS.BgPositionID,
                      POS.BgPositionID_Parent,
                      POS.BgPositionID_CopyOf,
                      POS.BgBudgetID,
                      POS.BaPersonID,
                      POS.BgKategorieCode,
                      POS.BgPositionsartID,
                      POS.ShBelegID,
                      POS.Betrag,
                      POS.Reduktion,
                      POS.Abzug,
                      POS.BetragEff,
                      POS.MaxBeitragSD,
                      POS.Buchungstext,
                      POS.BgSpezkontoID,
                      POS.VerwaltungSD,
                      POS.Bemerkung,
                      POS.DatumVon,
                      POS.DatumBis,
                      POS.OldID,
                      POS.BaInstitutionID,
                      POS.DebitorBaPersonID,
                      POS.VerwPeriodeVon,
                      POS.VerwPeriodeBis,
                      POS.FaelligAm,
                      POS.RechnungDatum,
                      POS.BgBewilligungStatusCode,
                      POS.Value1,
                      POS.Value2,
                      POS.Value3,
                      POS.ErstelltUserID,
                      POS.ErstelltDatum,
                      POS.MutiertUserID,
                      POS.MutiertDatum
                    FROM dbo.BgPosition POS
					WHERE POS.BgPositionID_Parent = {0}"
                        , this.qryBgPosition["BgPositionID"]);

                    if (qry.Count == 0)
                    {
                        qry.Insert("BgPosition");

                        qry["BgBudgetID"] = this.qryBgPosition["BgBudgetID"];
                        qry["BgPositionID_Parent"] = this.qryBgPosition["BgPositionID"];
                        qry["BgKategorieCode"] = 2;
                        qry["BgPositionsartID"] = ShUtil.GetBgPositionsartID(LOV.BgPositionsArt.Eff_Erwerbsunkosten, finanzplanVon);
                    }

                    qry["BaPersonID"] = this.qryBgPosition["BaPersonID"];
                    qry["Betrag"] = this.edtUKBetrag.EditValue;
                    qry["Reduktion"] = this.edtUKReduktion.EditValue;

                    if (!qry.Post("BgPosition"))
                        throw new KissErrorException(KissMsg.GetMLMessage("CtlBgErwerbseinkommen", "ErwerbsunkostenNichtGespeichert", "Effektive Erwerbsunkosten können nicht gespeichert werden", KissMsgCode.MsgError));
                }
                Session.Commit();
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }

            //Budget runden
            DBUtil.ExecSQLThrowingException("EXEC spWhBudget_Runden {0}", this.BgBudgetID);

            //Die StoredProcedure überprüft die editierte Masterbudget-Position und erstellt gegebenenfalls eine Nachfolge-Position,
            //falls eine Positionsart verwendet wurde, die während der Finanzplan-Laufzeit terminiert wurde.
            DBUtil.ExecSQLThrowingException("EXEC spWhPositionsart_Masterbudget_Terminieren {0}, {1}", this.BgFinanzplanID, qryBgPosition["BgPositionsartID"]);

            //Query Refresh, damit die durch die StoredProcedure veränderten Positionen auch korrekt dargestellt werden
            //Damit kein Endlos-Loop entsteht, müssen wir die aktuelle Zeile unmodified markieren
            qryBgPosition.RowModified = false;
            qryBgPosition.Refresh();
        }
		#endregion

		#region qryBgPosition_Delete
		private void qryBgPosition_BeforeDelete(object sender, System.EventArgs e)
		{
			Session.BeginTransaction();
            try
            {
                //vorgängig Positionen mit Parent_ID = <zu löschender ID> löschen
                DBUtil.ExecSQLThrowingException("DELETE FROM BgPosition WHERE BgPositionID_Parent = {0}", this.qryBgPosition["BgPositionID"]);
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                throw new KissCancelException();
            }
		}

		private void qryBgPosition_AfterDelete(object sender, System.EventArgs e)
		{
            try
            {
                Session.Commit();
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
		}
		#endregion

		private void Detail_EditValueChanged(object sender, System.EventArgs e)
		{
			decimal ukAng = this.edtUKBetrag.Value - this.edtUKReduktion.Value;
			this.txtUKAng.Value = ukAng;
			this.txtTotal.Value = this.edtBetrag.Value - ukAng;
		}

        private void edtNurAktive_CheckedChanged(object sender, EventArgs e)
        {
            this.qryBgPosition.Fill(BgBudgetID, BgGruppeCode, edtNurAktuelle.Checked);
        }
	}
}

