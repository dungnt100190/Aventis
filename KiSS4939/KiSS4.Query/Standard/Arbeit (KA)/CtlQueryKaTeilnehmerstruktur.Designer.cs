using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Query
{
    partial class CtlQueryKaTeilnehmerstruktur
    {
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaTeilnehmerstruktur));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tpgSTES = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallSTES = new KiSS4.Common.CtlGotoFall();
            this.qrySTES = new KiSS4.DB.SqlQuery();
            this.grdSTES = new KiSS4.Gui.KissGrid();
            this.grvSTES = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblDatumvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.lblAPVNummer = new KiSS4.Gui.KissLabel();
            this.lblZusatz = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtEinsatzPlatzID = new KiSS4.Gui.KissLookUpEdit();
            this.edtZusatzCode = new KiSS4.Gui.KissLookUpEdit();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltersgruppe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAPVNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusbildung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAustritt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAustrittscode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAustrittsgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuweiser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tpgSTES.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrySTES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSTES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSTES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAPVNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzPlatzID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzPlatzID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 395);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 27);
            this.ctlGotoFall.Visible = false;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgSTES);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgSTES});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSTES, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Title = "Zusammenfassung";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtZusatzCode);
            this.tpgSuchen.Controls.Add(this.edtEinsatzPlatzID);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblZusatz);
            this.tpgSuchen.Controls.Add(this.lblAPVNummer);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblDatumvon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAPVNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZusatz, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinsatzPlatzID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZusatzCode, 0);
            // 
            // tpgSTES
            // 
            this.tpgSTES.Controls.Add(this.ctlGotoFallSTES);
            this.tpgSTES.Controls.Add(this.grdSTES);
            this.tpgSTES.Location = new System.Drawing.Point(6, 6);
            this.tpgSTES.Name = "tpgSTES";
            this.tpgSTES.Size = new System.Drawing.Size(772, 424);
            this.tpgSTES.TabIndex = 1;
            this.tpgSTES.Title = "STES";
            // 
            // ctlGotoFallSTES
            // 
            this.ctlGotoFallSTES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallSTES.DataMember = "BaPersonID$";
            this.ctlGotoFallSTES.DataSource = this.qrySTES;
            this.ctlGotoFallSTES.Location = new System.Drawing.Point(3, 399);
            this.ctlGotoFallSTES.Name = "ctlGotoFallSTES";
            this.ctlGotoFallSTES.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallSTES.TabIndex = 5;
            // 
            // qrySTES
            // 
            this.qrySTES.FillTimeOut = 300;
            this.qrySTES.HostControl = this;
            this.qrySTES.SelectStatement = resources.GetString("qrySTES.SelectStatement");
            // 
            // grdSTES
            // 
            this.grdSTES.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSTES.DataSource = this.qrySTES;
            // 
            // 
            // 
            this.grdSTES.EmbeddedNavigator.Name = "";
            this.grdSTES.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdSTES.Location = new System.Drawing.Point(3, 1);
            this.grdSTES.MainView = this.grvSTES;
            this.grdSTES.Name = "grdSTES";
            this.grdSTES.Size = new System.Drawing.Size(766, 392);
            this.grdSTES.TabIndex = 4;
            this.grdSTES.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSTES});
            // 
            // grvSTES
            // 
            this.grvSTES.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvSTES.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSTES.Appearance.Empty.Options.UseBackColor = true;
            this.grvSTES.Appearance.Empty.Options.UseFont = true;
            this.grvSTES.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSTES.Appearance.EvenRow.Options.UseFont = true;
            this.grvSTES.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSTES.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSTES.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvSTES.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvSTES.Appearance.FocusedCell.Options.UseFont = true;
            this.grvSTES.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvSTES.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSTES.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSTES.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvSTES.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvSTES.Appearance.FocusedRow.Options.UseFont = true;
            this.grvSTES.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvSTES.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSTES.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvSTES.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSTES.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSTES.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSTES.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvSTES.Appearance.GroupRow.Options.UseFont = true;
            this.grvSTES.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvSTES.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvSTES.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvSTES.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSTES.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvSTES.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvSTES.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSTES.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvSTES.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSTES.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSTES.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvSTES.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvSTES.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvSTES.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvSTES.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvSTES.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSTES.Appearance.OddRow.Options.UseFont = true;
            this.grvSTES.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvSTES.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSTES.Appearance.Row.Options.UseBackColor = true;
            this.grvSTES.Appearance.Row.Options.UseFont = true;
            this.grvSTES.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSTES.Appearance.SelectedRow.Options.UseFont = true;
            this.grvSTES.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvSTES.Appearance.VertLine.Options.UseBackColor = true;
            this.grvSTES.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvSTES.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvSTES.GridControl = this.grdSTES;
            this.grvSTES.Name = "grvSTES";
            this.grvSTES.OptionsBehavior.Editable = false;
            this.grvSTES.OptionsCustomization.AllowFilter = false;
            this.grvSTES.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvSTES.OptionsNavigation.AutoFocusNewRow = true;
            this.grvSTES.OptionsNavigation.UseTabKey = false;
            this.grvSTES.OptionsView.ColumnAutoWidth = false;
            this.grvSTES.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvSTES.OptionsView.ShowGroupPanel = false;
            this.grvSTES.OptionsView.ShowIndicator = false;
            // 
            // lblDatumvon
            // 
            this.lblDatumvon.Location = new System.Drawing.Point(10, 40);
            this.lblDatumvon.Name = "lblDatumvon";
            this.lblDatumvon.Size = new System.Drawing.Size(130, 24);
            this.lblDatumvon.TabIndex = 1;
            this.lblDatumvon.Text = "Datum von";
            this.lblDatumvon.UseCompatibleTextRendering = true;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(270, 40);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 2;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // lblAPVNummer
            // 
            this.lblAPVNummer.Location = new System.Drawing.Point(10, 70);
            this.lblAPVNummer.Name = "lblAPVNummer";
            this.lblAPVNummer.Size = new System.Drawing.Size(130, 24);
            this.lblAPVNummer.TabIndex = 3;
            this.lblAPVNummer.Text = "APV-Nummer";
            this.lblAPVNummer.UseCompatibleTextRendering = true;
            // 
            // lblZusatz
            // 
            this.lblZusatz.Location = new System.Drawing.Point(10, 100);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(130, 24);
            this.lblZusatz.TabIndex = 4;
            this.lblZusatz.Text = "Zusatz";
            this.lblZusatz.UseCompatibleTextRendering = true;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(150, 40);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 21;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(300, 40);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 22;
            // 
            // edtEinsatzPlatzID
            // 
            this.edtEinsatzPlatzID.Location = new System.Drawing.Point(150, 70);
            this.edtEinsatzPlatzID.Name = "edtEinsatzPlatzID";
            this.edtEinsatzPlatzID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinsatzPlatzID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinsatzPlatzID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzPlatzID.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinsatzPlatzID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinsatzPlatzID.Properties.Appearance.Options.UseFont = true;
            this.edtEinsatzPlatzID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinsatzPlatzID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinsatzPlatzID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinsatzPlatzID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinsatzPlatzID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtEinsatzPlatzID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtEinsatzPlatzID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinsatzPlatzID.Properties.NullText = "";
            this.edtEinsatzPlatzID.Properties.ShowFooter = false;
            this.edtEinsatzPlatzID.Properties.ShowHeader = false;
            this.edtEinsatzPlatzID.Size = new System.Drawing.Size(250, 24);
            this.edtEinsatzPlatzID.TabIndex = 23;
            // 
            // edtZusatzCode
            // 
            this.edtZusatzCode.Location = new System.Drawing.Point(150, 100);
            this.edtZusatzCode.LOVName = "KaAPVZusatz";
            this.edtZusatzCode.Name = "edtZusatzCode";
            this.edtZusatzCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatzCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzCode.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZusatzCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZusatzCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZusatzCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZusatzCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZusatzCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZusatzCode.Properties.NullText = "";
            this.edtZusatzCode.Properties.ShowFooter = false;
            this.edtZusatzCode.Properties.ShowHeader = false;
            this.edtZusatzCode.Size = new System.Drawing.Size(250, 24);
            this.edtZusatzCode.TabIndex = 24;
            // 
            // colAlter
            // 
            this.colAlter.Name = "colAlter";
            // 
            // colAltersgruppe
            // 
            this.colAltersgruppe.Name = "colAltersgruppe";
            // 
            // colAPVNr
            // 
            this.colAPVNr.Name = "colAPVNr";
            // 
            // colAusbildung
            // 
            this.colAusbildung.Name = "colAusbildung";
            // 
            // colAustritt
            // 
            this.colAustritt.Name = "colAustritt";
            // 
            // colAustrittscode
            // 
            this.colAustrittscode.Name = "colAustrittscode";
            // 
            // colAustrittsgrund
            // 
            this.colAustrittsgrund.Name = "colAustrittsgrund";
            // 
            // colBezeichnung
            // 
            this.colBezeichnung.Name = "colBezeichnung";
            // 
            // colbis
            // 
            this.colbis.Name = "colbis";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colmw
            // 
            this.colmw.Name = "colmw";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colNationalitt
            // 
            this.colNationalitt.Name = "colNationalitt";
            // 
            // colPeriode
            // 
            this.colPeriode.Name = "colPeriode";
            // 
            // colTyp
            // 
            this.colTyp.Name = "colTyp";
            // 
            // colvon
            // 
            this.colvon.Name = "colvon";
            // 
            // colVorname
            // 
            this.colVorname.Name = "colVorname";
            // 
            // colWert
            // 
            this.colWert.Name = "colWert";
            // 
            // colZusatz
            // 
            this.colZusatz.Name = "colZusatz";
            // 
            // colZuweiser
            // 
            this.colZuweiser.Name = "colZuweiser";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryKaTeilnehmerstruktur
            // 
            this.Name = "CtlQueryKaTeilnehmerstruktur";
            this.Load += new System.EventHandler(this.CtlQueryKaTeilnehmerstruktur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            this.tpgSTES.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qrySTES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSTES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSTES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAPVNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzPlatzID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinsatzPlatzID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colAltersgruppe;
        private DevExpress.XtraGrid.Columns.GridColumn colAPVNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbildung;
        private DevExpress.XtraGrid.Columns.GridColumn colAustritt;
        private DevExpress.XtraGrid.Columns.GridColumn colAustrittscode;
        private DevExpress.XtraGrid.Columns.GridColumn colAustrittsgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colbis;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colmw;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriode;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colvon;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colWert;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatz;
        private DevExpress.XtraGrid.Columns.GridColumn colZuweiser;
        private KiSS4.Common.CtlGotoFall ctlGotoFallSTES;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtEinsatzPlatzID;
        private KiSS4.Gui.KissLookUpEdit edtZusatzCode;
        private KiSS4.Gui.KissGrid grdSTES;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSTES;
        private KiSS4.Gui.KissLabel lblAPVNummer;
        private KiSS4.Gui.KissLabel lblbis;
        private KiSS4.Gui.KissLabel lblDatumvon;
        private KiSS4.Gui.KissLabel lblZusatz;
        private KiSS4.DB.SqlQuery qrySTES;
        private SharpLibrary.WinControls.TabPageEx tpgSTES;
    }
}
