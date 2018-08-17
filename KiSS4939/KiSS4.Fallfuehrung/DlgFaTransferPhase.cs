using System;
using System.Data;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Fallfuehrung {
	public class DlgFaTransferPhase : KiSS4.Gui.KissDialog {
		private DevExpress.XtraGrid.Views.Grid.GridView grvEinzelfelder;
		private KiSS4.Gui.KissLabel kissLabel2;
		private KiSS4.Gui.KissLabel kissLabel3;
		private DevExpress.XtraGrid.Views.Grid.GridView grvZiele;
		private KiSS4.Gui.KissButton btnNoTransfer;
		private DevExpress.XtraGrid.Columns.GridColumn colSelect1;
		private DevExpress.XtraGrid.Columns.GridColumn colField;
		private DevExpress.XtraGrid.Columns.GridColumn colValue;
		private KiSS4.Gui.KissButton btnTransfer;
		private DevExpress.XtraGrid.Columns.GridColumn colSelect2;
		private DevExpress.XtraGrid.Columns.GridColumn colZiel;
		private System.ComponentModel.IContainer components = null;
		private KiSS4.DB.SqlQuery qryEinzelfeld;
		private KiSS4.DB.SqlQuery qryZiel;

		private int FaPhaseID;
		private int VorphaseID;
		private int VorPhaseCode;
		private KiSS4.Gui.KissGrid grdEinzelfelder;
		private KiSS4.Gui.KissGrid grdZiele;

		public bool NoData = true;

		public DlgFaTransferPhase() 
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}

		public DlgFaTransferPhase(int FaPhaseID) : this() 
		{
			this.FaPhaseID = FaPhaseID;

			//gibt es eine Vorphase?
			SqlQuery qry = DBUtil.OpenSQL(@"
				select	top 1 B.*
				from	dbo.FaPhase A
						inner join dbo.FaPhase B on B.FaLeistungID = A.FaLeistungID and
												B.FaPhaseID <> {0} and
												B.DatumVon < A.DatumVon
				where   A.FaPhaseID = {0} and
                        B.DatumBis is not null
				order by B.DatumVon desc",
				FaPhaseID);

			if (qry.Count == 0)
				return;

			this.Text += " (" +  ((DateTime) qry["DatumVon"]).ToString("dd.MM.yyyy") + " - " + 
				((DateTime) qry["DatumBis"]).ToString("dd.MM.yyyy") + ")";

			VorphaseID = (int) qry["FaPhaseID"];
			VorPhaseCode = (int) qry["FaPhaseCode"];

			qryEinzelfeld.Fill(@"
				declare @ZielMaskname varchar(100)

				select	top 1
						@ZielMaskname = MSK.Maskname
				from	dbo.DynaField FLD
						inner join dbo.DynaMask MSK on MSK.Maskname = FLD.Maskname
				where	FLD.AppCode like '%[[]ZielText]%' and
						MSK.FaPhaseCode = {1}

				select	sel = convert(bit,1), 
						Field = FLD.DisplayText, 
						Value = case FLD.FieldCode
							    when 5 then convert(varchar,VAL.Value,104) 
                                else VAL.Value
                                end,
						Fld.DynaFieldID,
						NewDynaFieldID = (select top 1 DynaFieldID
										  from   dbo.DynaField
										  where  FieldName = dbo.fnGetAppCodeNamedValue('Transfer',FLD.AppCode))
				from	dbo.DynaField FLD
						inner join dbo.DynaMask  MSK on MSK.Maskname = FLD.Maskname
						left  join dbo.DynaValue VAL on VAL.DynaFieldID = FLD.DynaFieldID and
													VAL.FaPhaseID = {0} and
													VAL.GridRowID = 1
				where	FLD.AppCode like '%[[]Transfer=%]%' and
						MSK.FaPhaseCode = {1} and
						VAL.Value is not null and
						MSK.MaskName <> isNull(@ZielMaskName,'')
				order by FLD.DisplayText",
				VorphaseID,
				VorPhaseCode);

			qryZiel.Fill(@"
				declare @ZielTextFldID int
				declare @Maskname      varchar(100)

				select	top 1
						@ZielTextFldID = FLD.DynaFieldID,
						@Maskname = MSK.Maskname
				from	dbo.DynaField FLD
						inner join DynaMask MSK on MSK.Maskname = FLD.Maskname
				where	FLD.AppCode like '%[[]ZielText]%' and
						MSK.FaPhaseCode = {1}

				select	sel = convert(bit,1), 
						ZielText = Value, 
						Maskname = @Maskname,
						GridRowID
				from	dbo.DynaValue
				where	FaPhaseID = {0} and
						DynaFieldID = @ZielTextFldID
				order by GridRowID", 
					VorphaseID,
					VorPhaseCode);

			if (qryEinzelfeld.Count > 0 || qryZiel.Count > 0)
				NoData = false;

			if (DBUtil.UserHasRight("DlgFaTransferPhase","U"))
			{
				grdEinzelfelder.GridStyle = GridStyleType.Editable;
				grdZiele.GridStyle = GridStyleType.Editable;
			}
			else
			{
				grdEinzelfelder.GridStyle = GridStyleType.ReadOnly;
				grdZiele.GridStyle = GridStyleType.ReadOnly;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.btnNoTransfer = new KiSS4.Gui.KissButton();
			this.grdEinzelfelder = new KiSS4.Gui.KissGrid();
			this.qryEinzelfeld = new KiSS4.DB.SqlQuery(this.components);
			this.grvEinzelfelder = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colSelect1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colField = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnTransfer = new KiSS4.Gui.KissButton();
			this.kissLabel2 = new KiSS4.Gui.KissLabel();
			this.kissLabel3 = new KiSS4.Gui.KissLabel();
			this.grdZiele = new KiSS4.Gui.KissGrid();
			this.qryZiel = new KiSS4.DB.SqlQuery(this.components);
			this.grvZiele = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colSelect2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colZiel = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.grdEinzelfelder)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.qryEinzelfeld)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvEinzelfelder)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdZiele)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.qryZiel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvZiele)).BeginInit();
			this.SuspendLayout();
			// 
			// btnNoTransfer
			// 
			this.btnNoTransfer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnNoTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNoTransfer.Location = new System.Drawing.Point(584, 440);
			this.btnNoTransfer.Name = "btnNoTransfer";
			this.btnNoTransfer.Size = new System.Drawing.Size(176, 24);
			this.btnNoTransfer.TabIndex = 20;
			this.btnNoTransfer.Text = "Keine Daten kopieren";
			this.btnNoTransfer.UseVisualStyleBackColor = false;
			this.btnNoTransfer.Click += new System.EventHandler(this.btnNoTransfer_Click);
			// 
			// grdEinzelfelder
			// 
			this.grdEinzelfelder.DataSource = this.qryEinzelfeld;
			// 
			// 
			// 
			this.grdEinzelfelder.EmbeddedNavigator.Name = "";
			this.grdEinzelfelder.GridStyle = KiSS4.Gui.GridStyleType.Editable;
			this.grdEinzelfelder.Location = new System.Drawing.Point(8, 32);
			this.grdEinzelfelder.MainView = this.grvEinzelfelder;
			this.grdEinzelfelder.Name = "grdEinzelfelder";
			this.grdEinzelfelder.Size = new System.Drawing.Size(752, 216);
			this.grdEinzelfelder.TabIndex = 21;
			this.grdEinzelfelder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEinzelfelder});
			// 
			// qryEinzelfeld
			// 
			this.qryEinzelfeld.CanUpdate = true;
			this.qryEinzelfeld.HostControl = this;
			this.qryEinzelfeld.TableName = "DynaField";
			this.qryEinzelfeld.BeforePost += new System.EventHandler(this.qryEinzelfeld_BeforePost);
			// 
			// grvEinzelfelder
			// 
			this.grvEinzelfelder.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.grvEinzelfelder.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvEinzelfelder.Appearance.Empty.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.Empty.Options.UseFont = true;
			this.grvEinzelfelder.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
			this.grvEinzelfelder.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvEinzelfelder.Appearance.EvenRow.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.EvenRow.Options.UseFont = true;
			this.grvEinzelfelder.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
			this.grvEinzelfelder.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvEinzelfelder.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
			this.grvEinzelfelder.Appearance.FocusedCell.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.FocusedCell.Options.UseFont = true;
			this.grvEinzelfelder.Appearance.FocusedCell.Options.UseForeColor = true;
			this.grvEinzelfelder.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
			this.grvEinzelfelder.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvEinzelfelder.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
			this.grvEinzelfelder.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.FocusedRow.Options.UseFont = true;
			this.grvEinzelfelder.Appearance.FocusedRow.Options.UseForeColor = true;
			this.grvEinzelfelder.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			this.grvEinzelfelder.Appearance.GroupPanel.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			this.grvEinzelfelder.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grvEinzelfelder.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvEinzelfelder.Appearance.GroupRow.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.GroupRow.Options.UseFont = true;
			this.grvEinzelfelder.Appearance.GroupRow.Options.UseForeColor = true;
			this.grvEinzelfelder.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.grvEinzelfelder.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			this.grvEinzelfelder.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grvEinzelfelder.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.grvEinzelfelder.Appearance.HeaderPanel.Options.UseFont = true;
			this.grvEinzelfelder.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
			this.grvEinzelfelder.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvEinzelfelder.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvEinzelfelder.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.HideSelectionRow.Options.UseFont = true;
			this.grvEinzelfelder.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.grvEinzelfelder.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
			this.grvEinzelfelder.Appearance.HorzLine.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
			this.grvEinzelfelder.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvEinzelfelder.Appearance.OddRow.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.OddRow.Options.UseFont = true;
			this.grvEinzelfelder.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
			this.grvEinzelfelder.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvEinzelfelder.Appearance.Row.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.Row.Options.UseFont = true;
			this.grvEinzelfelder.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
			this.grvEinzelfelder.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvEinzelfelder.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
			this.grvEinzelfelder.Appearance.SelectedRow.Options.UseBackColor = true;
			this.grvEinzelfelder.Appearance.SelectedRow.Options.UseFont = true;
			this.grvEinzelfelder.Appearance.SelectedRow.Options.UseForeColor = true;
			this.grvEinzelfelder.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
			this.grvEinzelfelder.Appearance.VertLine.Options.UseBackColor = true;
			this.grvEinzelfelder.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.grvEinzelfelder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelect1,
            this.colField,
            this.colValue});
			this.grvEinzelfelder.GridControl = this.grdEinzelfelder;
			this.grvEinzelfelder.Name = "grvEinzelfelder";
			this.grvEinzelfelder.OptionsCustomization.AllowFilter = false;
			this.grvEinzelfelder.OptionsFilter.UseNewCustomFilterDialog = true;
			this.grvEinzelfelder.OptionsNavigation.AutoFocusNewRow = true;
			this.grvEinzelfelder.OptionsView.ColumnAutoWidth = false;
			this.grvEinzelfelder.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.grvEinzelfelder.OptionsView.ShowGroupPanel = false;
			// 
			// colSelect1
			// 
			this.colSelect1.Caption = "Kopieren";
			this.colSelect1.FieldName = "sel";
			this.colSelect1.Name = "colSelect1";
			this.colSelect1.Visible = true;
			this.colSelect1.VisibleIndex = 0;
			this.colSelect1.Width = 65;
			// 
			// colField
			// 
			this.colField.Caption = "Feld";
			this.colField.FieldName = "Field";
			this.colField.Name = "colField";
			this.colField.OptionsColumn.AllowEdit = false;
			this.colField.OptionsColumn.ReadOnly = true;
			this.colField.Visible = true;
			this.colField.VisibleIndex = 1;
			this.colField.Width = 208;
			// 
			// colValue
			// 
			this.colValue.Caption = "Inhalt";
			this.colValue.FieldName = "Value";
			this.colValue.Name = "colValue";
			this.colValue.OptionsColumn.AllowEdit = false;
			this.colValue.OptionsColumn.ReadOnly = true;
			this.colValue.Visible = true;
			this.colValue.VisibleIndex = 2;
			this.colValue.Width = 447;
			// 
			// btnTransfer
			// 
			this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTransfer.Location = new System.Drawing.Point(392, 440);
			this.btnTransfer.Name = "btnTransfer";
			this.btnTransfer.Size = new System.Drawing.Size(184, 24);
			this.btnTransfer.TabIndex = 26;
			this.btnTransfer.Text = "Markierte Daten kopieren";
			this.btnTransfer.UseVisualStyleBackColor = false;
			this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
			// 
			// kissLabel2
			// 
			this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
			this.kissLabel2.Location = new System.Drawing.Point(8, 8);
			this.kissLabel2.Name = "kissLabel2";
			this.kissLabel2.Size = new System.Drawing.Size(192, 16);
			this.kissLabel2.TabIndex = 27;
			this.kissLabel2.Text = "Einzelfelder";
			// 
			// kissLabel3
			// 
			this.kissLabel3.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
			this.kissLabel3.Location = new System.Drawing.Point(8, 256);
			this.kissLabel3.Name = "kissLabel3";
			this.kissLabel3.Size = new System.Drawing.Size(51, 16);
			this.kissLabel3.TabIndex = 28;
			this.kissLabel3.Text = "Ziele";
			// 
			// grdZiele
			// 
			this.grdZiele.DataSource = this.qryZiel;
			// 
			// 
			// 
			this.grdZiele.EmbeddedNavigator.Name = "";
			this.grdZiele.GridStyle = KiSS4.Gui.GridStyleType.Editable;
			this.grdZiele.Location = new System.Drawing.Point(8, 280);
			this.grdZiele.MainView = this.grvZiele;
			this.grdZiele.Name = "grdZiele";
			this.grdZiele.Size = new System.Drawing.Size(752, 152);
			this.grdZiele.TabIndex = 29;
			this.grdZiele.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZiele});
			// 
			// qryZiel
			// 
			this.qryZiel.CanUpdate = true;
			this.qryZiel.HostControl = this;
			this.qryZiel.TableName = "DynaValue";
			this.qryZiel.BeforePost += new System.EventHandler(this.qryZiel_BeforePost);
			// 
			// grvZiele
			// 
			this.grvZiele.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			this.grvZiele.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvZiele.Appearance.Empty.Options.UseBackColor = true;
			this.grvZiele.Appearance.Empty.Options.UseFont = true;
			this.grvZiele.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
			this.grvZiele.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvZiele.Appearance.EvenRow.Options.UseBackColor = true;
			this.grvZiele.Appearance.EvenRow.Options.UseFont = true;
			this.grvZiele.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
			this.grvZiele.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvZiele.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
			this.grvZiele.Appearance.FocusedCell.Options.UseBackColor = true;
			this.grvZiele.Appearance.FocusedCell.Options.UseFont = true;
			this.grvZiele.Appearance.FocusedCell.Options.UseForeColor = true;
			this.grvZiele.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
			this.grvZiele.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvZiele.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
			this.grvZiele.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grvZiele.Appearance.FocusedRow.Options.UseFont = true;
			this.grvZiele.Appearance.FocusedRow.Options.UseForeColor = true;
			this.grvZiele.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
			this.grvZiele.Appearance.GroupPanel.Options.UseBackColor = true;
			this.grvZiele.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
			this.grvZiele.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grvZiele.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvZiele.Appearance.GroupRow.Options.UseBackColor = true;
			this.grvZiele.Appearance.GroupRow.Options.UseFont = true;
			this.grvZiele.Appearance.GroupRow.Options.UseForeColor = true;
			this.grvZiele.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
			this.grvZiele.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
			this.grvZiele.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.grvZiele.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.grvZiele.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.grvZiele.Appearance.HeaderPanel.Options.UseFont = true;
			this.grvZiele.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
			this.grvZiele.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvZiele.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.grvZiele.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grvZiele.Appearance.HideSelectionRow.Options.UseFont = true;
			this.grvZiele.Appearance.HideSelectionRow.Options.UseForeColor = true;
			this.grvZiele.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
			this.grvZiele.Appearance.HorzLine.Options.UseBackColor = true;
			this.grvZiele.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
			this.grvZiele.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvZiele.Appearance.OddRow.Options.UseBackColor = true;
			this.grvZiele.Appearance.OddRow.Options.UseFont = true;
			this.grvZiele.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
			this.grvZiele.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvZiele.Appearance.Row.Options.UseBackColor = true;
			this.grvZiele.Appearance.Row.Options.UseFont = true;
			this.grvZiele.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
			this.grvZiele.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.grvZiele.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
			this.grvZiele.Appearance.SelectedRow.Options.UseBackColor = true;
			this.grvZiele.Appearance.SelectedRow.Options.UseFont = true;
			this.grvZiele.Appearance.SelectedRow.Options.UseForeColor = true;
			this.grvZiele.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
			this.grvZiele.Appearance.VertLine.Options.UseBackColor = true;
			this.grvZiele.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.grvZiele.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelect2,
            this.colZiel});
			this.grvZiele.GridControl = this.grdZiele;
			this.grvZiele.Name = "grvZiele";
			this.grvZiele.OptionsCustomization.AllowFilter = false;
			this.grvZiele.OptionsFilter.UseNewCustomFilterDialog = true;
			this.grvZiele.OptionsNavigation.AutoFocusNewRow = true;
			this.grvZiele.OptionsView.ColumnAutoWidth = false;
			this.grvZiele.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.grvZiele.OptionsView.ShowGroupPanel = false;
			// 
			// colSelect2
			// 
			this.colSelect2.Caption = "Kopieren";
			this.colSelect2.FieldName = "sel";
			this.colSelect2.Name = "colSelect2";
			this.colSelect2.Visible = true;
			this.colSelect2.VisibleIndex = 0;
			this.colSelect2.Width = 64;
			// 
			// colZiel
			// 
			this.colZiel.Caption = "Ziel";
			this.colZiel.FieldName = "ZielText";
			this.colZiel.Name = "colZiel";
			this.colZiel.OptionsColumn.AllowEdit = false;
			this.colZiel.OptionsColumn.ReadOnly = true;
			this.colZiel.Visible = true;
			this.colZiel.VisibleIndex = 1;
			this.colZiel.Width = 654;
			// 
			// DlgFaTransferPhase
			// 
			this.AcceptButton = this.btnTransfer;
			this.ActiveSQLQuery = this.qryEinzelfeld;
			this.CancelButton = this.btnNoTransfer;
			this.ClientSize = new System.Drawing.Size(770, 472);
			this.Controls.Add(this.grdZiele);
			this.Controls.Add(this.kissLabel3);
			this.Controls.Add(this.kissLabel2);
			this.Controls.Add(this.btnTransfer);
			this.Controls.Add(this.grdEinzelfelder);
			this.Controls.Add(this.btnNoTransfer);
			this.Name = "DlgFaTransferPhase";
			this.Text = "Daten kopieren aus der Vorphase";
			((System.ComponentModel.ISupportInitialize)(this.grdEinzelfelder)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.qryEinzelfeld)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvEinzelfelder)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdZiele)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.qryZiel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvZiele)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnNoTransfer_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void qryEinzelfeld_BeforePost(object sender, System.EventArgs e)
		{
			qryEinzelfeld.Row.AcceptChanges();
			qryEinzelfeld.RowModified = false;
		}

		private void qryZiel_BeforePost(object sender, System.EventArgs e)
		{
			qryZiel.Row.AcceptChanges();
			qryZiel.RowModified = false;
		}

		private void btnTransfer_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			Session.BeginTransaction();
            try
            {
                // Einzelfelder
                foreach (DataRow row in qryEinzelfeld.DataTable.Rows)
                {
                    if ((bool)row["sel"])
                    {
                        DBUtil.ExecSQL(@"
							insert dbo.dynavalue (FaPhaseID, DynaFieldID, Value, GridRowID, CreationDate) 
							values ({0},{1},{2},1,getdate())",
                            this.FaPhaseID,
                            row["NewDynaFieldID"],
                            row["Value"]);
                    }
                }

                foreach (DataRow row in qryZiel.DataTable.Rows)
                {
                    if ((bool)row["sel"])
                    {
                        DBUtil.ExecSQLThrowingException(@"
							insert	dbo.dynavalue (FaPhaseID, DynaFieldID, Value, GridRowID, CreationDate) 
							select	{0}, 
									NewDynaFieldID = 
										(select top 1 DynaFieldID
										from   DynaField
										where  FieldName = dbo.fnGetAppCodeNamedValue('Transfer',FLD.AppCode)),
									VAL.Value, 
									VAL.GridRowID, 
									getdate()
							from	dbo.DynaField FLD
									inner join dbo.DynaValue VAL on VAL.DynaFieldID = FLD.DynaFieldID and
																VAL.FaPhaseID = {1} and
																VAL.GridRowID = {2}
							where	FLD.MaskName = CONVERT(varchar(100), {3}) and
									FLD.AppCode like '%[[]Transfer=%]%'",
                            this.FaPhaseID,
                            VorphaseID,
                            row["GridRowID"],
                            row["Maskname"]);
                    }
                }
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError("DlgFaTransferPhase", "FehlerKopieren", "Fehler beim Kopieren der Vorphasedaten", ex);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.WaitCursor;
            }

            this.Close();
		}
	}
}

