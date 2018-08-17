//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.832
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using KiSS4.DB;

namespace KiSS4.Administration
{
	
	
	public class CtlKbZahlungslaufValuta : KiSS4.Gui.KissUserControl
	{
		private KiSS4.Gui.KissGrid grdDatenValuta;
		private KiSS4.DB.SqlQuery qryZahlungslauf;
		private System.ComponentModel.IContainer components;
		private KiSS4.Gui.KissLookUpEdit ddlYear;
		private KiSS4.Gui.KissLabel lblJahr;
		private DevExpress.XtraGrid.Views.Grid.GridView grvDatenValuta;
		private DevExpress.XtraGrid.Columns.GridColumn colMonat;
		private DevExpress.XtraGrid.Columns.GridColumn colmonatlich;
		private DevExpress.XtraGrid.Columns.GridColumn colHalbMonat1;
		private DevExpress.XtraGrid.Columns.GridColumn colHalbMonat2;
		private DevExpress.XtraGrid.Columns.GridColumn colWoche1;
		private DevExpress.XtraGrid.Columns.GridColumn colWoche2;
		private DevExpress.XtraGrid.Columns.GridColumn colWoche3;
		private DevExpress.XtraGrid.Columns.GridColumn colWoche4;
        private KiSS4.Gui.KissButton btnVonVorjahrFuellen;
		private DevExpress.XtraGrid.Columns.GridColumn colWoche5;

		private void FillData()
		{
			qryZahlungslauf.Fill(ddlYear.EditValue);
		
			if (qryZahlungslauf.Count < 1)
			{
				DBUtil.ExecSQL(@"
                    INSERT INTO KbZahlungslaufValuta (Monat, Jahr)
					SELECT Monat = 1, Jahr = {0} union all
					SELECT 2, {0} union all
					SELECT 3, {0} union all
					SELECT 4, {0} union all
					SELECT 5, {0} union all
					SELECT 6, {0} union all
					SELECT 7, {0} union all
					SELECT 8, {0} union all
					SELECT 9, {0} union all
					SELECT 10, {0} union all
					SELECT 11, {0} union all
					SELECT 12, {0} ", 
                    ddlYear.EditValue
                );
				qryZahlungslauf.Fill(ddlYear.EditValue);
			}
		}
		
		public CtlKbZahlungslaufValuta()
		{
			this.InitializeComponent();
		}
		
		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdDatenValuta = new KiSS4.Gui.KissGrid();
            this.qryZahlungslauf = new KiSS4.DB.SqlQuery(this.components);
            this.grvDatenValuta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMonat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmonatlich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHalbMonat1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHalbMonat2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWoche1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWoche2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWoche3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWoche4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWoche5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblJahr = new KiSS4.Gui.KissLabel();
            this.ddlYear = new KiSS4.Gui.KissLookUpEdit();
            this.btnVonVorjahrFuellen = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatenValuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungslauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDatenValuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatenValuta
            // 
            this.grdDatenValuta.DataSource = this.qryZahlungslauf;
            // 
            // 
            // 
            this.grdDatenValuta.EmbeddedNavigator.Name = "";
            this.grdDatenValuta.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdDatenValuta.Location = new System.Drawing.Point(0, 73);
            this.grdDatenValuta.MainView = this.grvDatenValuta;
            this.grdDatenValuta.Name = "grdDatenValuta";
            this.grdDatenValuta.Size = new System.Drawing.Size(791, 430);
            this.grdDatenValuta.TabIndex = 1;
            this.grdDatenValuta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDatenValuta});
            // 
            // qryZahlungslauf
            // 
            this.qryZahlungslauf.CanUpdate = true;
            this.qryZahlungslauf.HostControl = this;
            this.qryZahlungslauf.SelectStatement = "SELECT MonatText = dbo.fnXMonat(Monat),\r\n*\r\nFROM KbZahlungslaufValuta ZLV\r\nWHERE " +
                "Jahr = {0}\r\nORDER BY Monat ASC";
            this.qryZahlungslauf.TableName = "KbZahlungslaufValuta";
            // 
            // grvDatenValuta
            // 
            this.grvDatenValuta.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDatenValuta.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDatenValuta.Appearance.Empty.Options.UseBackColor = true;
            this.grvDatenValuta.Appearance.Empty.Options.UseFont = true;
            this.grvDatenValuta.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvDatenValuta.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDatenValuta.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvDatenValuta.Appearance.EvenRow.Options.UseFont = true;
            this.grvDatenValuta.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvDatenValuta.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDatenValuta.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvDatenValuta.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDatenValuta.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDatenValuta.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDatenValuta.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvDatenValuta.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDatenValuta.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvDatenValuta.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDatenValuta.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDatenValuta.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDatenValuta.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDatenValuta.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDatenValuta.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDatenValuta.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDatenValuta.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDatenValuta.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDatenValuta.Appearance.GroupRow.Options.UseFont = true;
            this.grvDatenValuta.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDatenValuta.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDatenValuta.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDatenValuta.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDatenValuta.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDatenValuta.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDatenValuta.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDatenValuta.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvDatenValuta.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDatenValuta.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDatenValuta.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDatenValuta.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDatenValuta.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDatenValuta.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvDatenValuta.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDatenValuta.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDatenValuta.Appearance.OddRow.Options.UseFont = true;
            this.grvDatenValuta.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvDatenValuta.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDatenValuta.Appearance.Row.Options.UseBackColor = true;
            this.grvDatenValuta.Appearance.Row.Options.UseFont = true;
            this.grvDatenValuta.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvDatenValuta.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDatenValuta.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvDatenValuta.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvDatenValuta.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDatenValuta.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvDatenValuta.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvDatenValuta.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDatenValuta.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDatenValuta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMonat,
            this.colmonatlich,
            this.colHalbMonat1,
            this.colHalbMonat2,
            this.colWoche1,
            this.colWoche2,
            this.colWoche3,
            this.colWoche4,
            this.colWoche5});
            this.grvDatenValuta.GridControl = this.grdDatenValuta;
            this.grvDatenValuta.Name = "grvDatenValuta";
            this.grvDatenValuta.OptionsCustomization.AllowFilter = false;
            this.grvDatenValuta.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDatenValuta.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDatenValuta.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvDatenValuta.OptionsView.ColumnAutoWidth = false;
            this.grvDatenValuta.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDatenValuta.OptionsView.ShowGroupPanel = false;
            // 
            // colMonat
            // 
            this.colMonat.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colMonat.AppearanceCell.Options.UseBackColor = true;
            this.colMonat.Caption = "Monat";
            this.colMonat.FieldName = "MonatText";
            this.colMonat.Name = "colMonat";
            this.colMonat.OptionsColumn.AllowEdit = false;
            this.colMonat.OptionsColumn.AllowFocus = false;
            this.colMonat.Visible = true;
            this.colMonat.VisibleIndex = 0;
            this.colMonat.Width = 88;
            // 
            // colmonatlich
            // 
            this.colmonatlich.Caption = "monatlich";
            this.colmonatlich.FieldName = "DatMonatlich";
            this.colmonatlich.Name = "colmonatlich";
            this.colmonatlich.Visible = true;
            this.colmonatlich.VisibleIndex = 1;
            this.colmonatlich.Width = 90;
            // 
            // colHalbMonat1
            // 
            this.colHalbMonat1.Caption = "1. Teil halbmtl";
            this.colHalbMonat1.FieldName = "DatTeil1";
            this.colHalbMonat1.Name = "colHalbMonat1";
            this.colHalbMonat1.Visible = true;
            this.colHalbMonat1.VisibleIndex = 2;
            this.colHalbMonat1.Width = 90;
            // 
            // colHalbMonat2
            // 
            this.colHalbMonat2.Caption = "2. Teil halbmtl";
            this.colHalbMonat2.FieldName = "DatTeil2";
            this.colHalbMonat2.Name = "colHalbMonat2";
            this.colHalbMonat2.Visible = true;
            this.colHalbMonat2.VisibleIndex = 3;
            this.colHalbMonat2.Width = 90;
            // 
            // colWoche1
            // 
            this.colWoche1.Caption = "1. Woche";
            this.colWoche1.FieldName = "DatWoche1";
            this.colWoche1.Name = "colWoche1";
            this.colWoche1.Visible = true;
            this.colWoche1.VisibleIndex = 4;
            // 
            // colWoche2
            // 
            this.colWoche2.Caption = "2. Woche";
            this.colWoche2.FieldName = "DatWoche2";
            this.colWoche2.Name = "colWoche2";
            this.colWoche2.Visible = true;
            this.colWoche2.VisibleIndex = 5;
            // 
            // colWoche3
            // 
            this.colWoche3.Caption = "3. Woche";
            this.colWoche3.FieldName = "DatWoche3";
            this.colWoche3.Name = "colWoche3";
            this.colWoche3.Visible = true;
            this.colWoche3.VisibleIndex = 6;
            // 
            // colWoche4
            // 
            this.colWoche4.Caption = "4. Woche";
            this.colWoche4.FieldName = "DatWoche4";
            this.colWoche4.Name = "colWoche4";
            this.colWoche4.Visible = true;
            this.colWoche4.VisibleIndex = 7;
            // 
            // colWoche5
            // 
            this.colWoche5.Caption = "5. Woche";
            this.colWoche5.FieldName = "DatWoche5";
            this.colWoche5.Name = "colWoche5";
            this.colWoche5.Visible = true;
            this.colWoche5.VisibleIndex = 8;
            // 
            // lblJahr
            // 
            this.lblJahr.Location = new System.Drawing.Point(3, 19);
            this.lblJahr.Name = "lblJahr";
            this.lblJahr.Size = new System.Drawing.Size(70, 24);
            this.lblJahr.TabIndex = 2;
            this.lblJahr.Text = "Jahr";
            this.lblJahr.UseCompatibleTextRendering = true;
            // 
            // ddlYear
            // 
            this.ddlYear.Location = new System.Drawing.Point(44, 18);
            this.ddlYear.Name = "ddlYear";
            this.ddlYear.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlYear.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlYear.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlYear.Properties.Appearance.Options.UseBackColor = true;
            this.ddlYear.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlYear.Properties.Appearance.Options.UseFont = true;
            this.ddlYear.Properties.Appearance.Options.UseTextOptions = true;
            this.ddlYear.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ddlYear.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlYear.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlYear.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlYear.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlYear.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.ddlYear.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ddlYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.ddlYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.ddlYear.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlYear.Properties.DisplayMember = "Code";
            this.ddlYear.Properties.NullText = "";
            this.ddlYear.Properties.PopupWidth = 100;
            this.ddlYear.Properties.ShowFooter = false;
            this.ddlYear.Properties.ShowHeader = false;
            this.ddlYear.Properties.ValueMember = "Code";
            this.ddlYear.Size = new System.Drawing.Size(100, 24);
            this.ddlYear.TabIndex = 3;
            this.ddlYear.EditValueChanged += new System.EventHandler(this.ddlYear_EditValueChanged);
            // 
            // btnVonVorjahrFuellen
            // 
            this.btnVonVorjahrFuellen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVonVorjahrFuellen.Location = new System.Drawing.Point(165, 18);
            this.btnVonVorjahrFuellen.Name = "btnVonVorjahrFuellen";
            this.btnVonVorjahrFuellen.Size = new System.Drawing.Size(258, 24);
            this.btnVonVorjahrFuellen.TabIndex = 4;
            this.btnVonVorjahrFuellen.Text = "Gew�hltes Jahr vom Vorjahr f�llen";
            this.btnVonVorjahrFuellen.UseVisualStyleBackColor = false;
            this.btnVonVorjahrFuellen.Click += new System.EventHandler(this.btnVonVorjahrFuellen_Click);
            // 
            // CtlKbZahlungslaufValuta
            // 
            this.ActiveSQLQuery = this.qryZahlungslauf;
            this.Controls.Add(this.btnVonVorjahrFuellen);
            this.Controls.Add(this.ddlYear);
            this.Controls.Add(this.lblJahr);
            this.Controls.Add(this.grdDatenValuta);
            this.Name = "CtlKbZahlungslaufValuta";
            this.Size = new System.Drawing.Size(808, 523);
            this.Load += new System.EventHandler(this.CtlKbZahlungslaufValuta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatenValuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungslauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDatenValuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlYear)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if ((components != null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		private void CtlKbZahlungslaufValuta_Load(object sender, System.EventArgs e)
		{
			SqlQuery qry = DBUtil.OpenSQL(@"
                select  Code = Year(GetDate()) union all
				select  Year(GetDate()) + 1 union all
				select  Year(GetDate()) + 2"
            );
			ddlYear.Properties.DataSource = qry;
			ddlYear.EditValue = DateTime.Today.Year;
			
			FillData();
		}
		
		private void ddlYear_EditValueChanged(object sender, System.EventArgs e)
		{
			FillData();
        }

        private void btnVonVorjahrFuellen_Click(object sender, EventArgs e)
        {
            // F�llt das ausgew�hlte Jahr anhand der Daten im vorhergehenden Jahr 
            DBUtil.ExecSQL(
                "EXEC dbo.spKbZahlungslaufValuta_InsertNewYear {0}, 2", 
                ddlYear.EditValue
            );
            FillData();
        }
	}
}