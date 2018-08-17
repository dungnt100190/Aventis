using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Query
{
    partial class CtlQueryAdmDoppeltErfasstePersonen
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryAdmDoppeltErfasstePersonen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnStammdatenAB = new KiSS4.Gui.KissButton();
            this.btnDatenbereinigung = new KiSS4.Gui.KissButton();
            this.lblVergleichName = new KiSS4.Gui.KissLabel();
            this.lblVergleichVorname = new KiSS4.Gui.KissLabel();
            this.lblVergleichGeburt = new KiSS4.Gui.KissLabel();
            this.lblVergleichAHVNr = new KiSS4.Gui.KissLabel();
            this.edtNameCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtVornameCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtGeburtCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtAHVCode = new KiSS4.Gui.KissLookUpEdit();
            this.colAAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGeburt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colANr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBGeburt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtVersNr = new KiSS4.Gui.KissLookUpEdit();
            this.lblVergleichVersNr = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichGeburt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichAHVNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichVersNr)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            //
            // grvQuery1
            //
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Visible = false;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.btnDatenbereinigung);
            this.tpgListe.Controls.Add(this.btnStammdatenAB);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnStammdatenAB, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnDatenbereinigung, 0);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtVersNr);
            this.tpgSuchen.Controls.Add(this.lblVergleichVersNr);
            this.tpgSuchen.Controls.Add(this.edtAHVCode);
            this.tpgSuchen.Controls.Add(this.edtGeburtCode);
            this.tpgSuchen.Controls.Add(this.edtVornameCode);
            this.tpgSuchen.Controls.Add(this.edtNameCode);
            this.tpgSuchen.Controls.Add(this.lblVergleichAHVNr);
            this.tpgSuchen.Controls.Add(this.lblVergleichGeburt);
            this.tpgSuchen.Controls.Add(this.lblVergleichVorname);
            this.tpgSuchen.Controls.Add(this.lblVergleichName);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVergleichName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVergleichVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVergleichGeburt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVergleichAHVNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVornameCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAHVCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVergleichVersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVersNr, 0);
            //
            // btnStammdatenAB
            //
            this.btnStammdatenAB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStammdatenAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStammdatenAB.Location = new System.Drawing.Point(431, 397);
            this.btnStammdatenAB.Name = "btnStammdatenAB";
            this.btnStammdatenAB.Size = new System.Drawing.Size(90, 24);
            this.btnStammdatenAB.TabIndex = 3;
            this.btnStammdatenAB.Text = "Stammdaten";
            this.btnStammdatenAB.UseCompatibleTextRendering = true;
            this.btnStammdatenAB.UseVisualStyleBackColor = true;
            this.btnStammdatenAB.Click += new System.EventHandler(this.btnStammdatenAB_Click);
            //
            // btnDatenbereinigung
            //
            this.btnDatenbereinigung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDatenbereinigung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatenbereinigung.Location = new System.Drawing.Point(306, 398);
            this.btnDatenbereinigung.Name = "btnDatenbereinigung";
            this.btnDatenbereinigung.Size = new System.Drawing.Size(119, 24);
            this.btnDatenbereinigung.TabIndex = 4;
            this.btnDatenbereinigung.Text = "Datenbereinigung";
            this.btnDatenbereinigung.UseCompatibleTextRendering = true;
            this.btnDatenbereinigung.UseVisualStyleBackColor = false;
            this.btnDatenbereinigung.Click += new System.EventHandler(this.btnDatenbereinigung_Click);
            //
            // lblVergleichName
            //
            this.lblVergleichName.Location = new System.Drawing.Point(10, 40);
            this.lblVergleichName.Name = "lblVergleichName";
            this.lblVergleichName.Size = new System.Drawing.Size(130, 24);
            this.lblVergleichName.TabIndex = 1;
            this.lblVergleichName.Text = "Vergleich Name";
            this.lblVergleichName.UseCompatibleTextRendering = true;
            //
            // lblVergleichVorname
            //
            this.lblVergleichVorname.Location = new System.Drawing.Point(10, 70);
            this.lblVergleichVorname.Name = "lblVergleichVorname";
            this.lblVergleichVorname.Size = new System.Drawing.Size(130, 24);
            this.lblVergleichVorname.TabIndex = 2;
            this.lblVergleichVorname.Text = "Vergleich Vorname";
            this.lblVergleichVorname.UseCompatibleTextRendering = true;
            //
            // lblVergleichGeburt
            //
            this.lblVergleichGeburt.Location = new System.Drawing.Point(10, 100);
            this.lblVergleichGeburt.Name = "lblVergleichGeburt";
            this.lblVergleichGeburt.Size = new System.Drawing.Size(130, 24);
            this.lblVergleichGeburt.TabIndex = 3;
            this.lblVergleichGeburt.Text = "Vergleich Geburt";
            this.lblVergleichGeburt.UseCompatibleTextRendering = true;
            //
            // lblVergleichAHVNr
            //
            this.lblVergleichAHVNr.Location = new System.Drawing.Point(10, 130);
            this.lblVergleichAHVNr.Name = "lblVergleichAHVNr";
            this.lblVergleichAHVNr.Size = new System.Drawing.Size(130, 24);
            this.lblVergleichAHVNr.TabIndex = 4;
            this.lblVergleichAHVNr.Text = "Vergleich AHV Nr.";
            this.lblVergleichAHVNr.UseCompatibleTextRendering = true;
            //
            // edtNameCode
            //
            this.edtNameCode.Location = new System.Drawing.Point(150, 40);
            this.edtNameCode.Name = "edtNameCode";
            this.edtNameCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameCode.Properties.Appearance.Options.UseFont = true;
            this.edtNameCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNameCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNameCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNameCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtNameCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtNameCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameCode.Properties.NullText = "";
            this.edtNameCode.Properties.ShowFooter = false;
            this.edtNameCode.Properties.ShowHeader = false;
            this.edtNameCode.Size = new System.Drawing.Size(200, 24);
            this.edtNameCode.TabIndex = 21;
            //
            // edtVornameCode
            //
            this.edtVornameCode.Location = new System.Drawing.Point(150, 70);
            this.edtVornameCode.Name = "edtVornameCode";
            this.edtVornameCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVornameCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVornameCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVornameCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtVornameCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVornameCode.Properties.Appearance.Options.UseFont = true;
            this.edtVornameCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVornameCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVornameCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVornameCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVornameCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtVornameCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtVornameCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVornameCode.Properties.NullText = "";
            this.edtVornameCode.Properties.ShowFooter = false;
            this.edtVornameCode.Properties.ShowHeader = false;
            this.edtVornameCode.Size = new System.Drawing.Size(200, 24);
            this.edtVornameCode.TabIndex = 22;
            //
            // edtGeburtCode
            //
            this.edtGeburtCode.Location = new System.Drawing.Point(150, 100);
            this.edtGeburtCode.Name = "edtGeburtCode";
            this.edtGeburtCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtCode.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGeburtCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGeburtCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGeburtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtGeburtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtGeburtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtCode.Properties.NullText = "";
            this.edtGeburtCode.Properties.ShowFooter = false;
            this.edtGeburtCode.Properties.ShowHeader = false;
            this.edtGeburtCode.Size = new System.Drawing.Size(200, 24);
            this.edtGeburtCode.TabIndex = 23;
            //
            // edtAHVCode
            //
            this.edtAHVCode.Location = new System.Drawing.Point(150, 130);
            this.edtAHVCode.Name = "edtAHVCode";
            this.edtAHVCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAHVCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVCode.Properties.Appearance.Options.UseFont = true;
            this.edtAHVCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAHVCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAHVCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAHVCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAHVCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAHVCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAHVCode.Properties.NullText = "";
            this.edtAHVCode.Properties.ShowFooter = false;
            this.edtAHVCode.Properties.ShowHeader = false;
            this.edtAHVCode.Size = new System.Drawing.Size(200, 24);
            this.edtAHVCode.TabIndex = 24;
            //
            // colAAHVNummer
            //
            this.colAAHVNummer.Name = "colAAHVNummer";
            //
            // colAGeburt
            //
            this.colAGeburt.Name = "colAGeburt";
            //
            // colAName
            //
            this.colAName.Name = "colAName";
            //
            // colANr
            //
            this.colANr.Name = "colANr";
            //
            // colAVorname
            //
            this.colAVorname.Name = "colAVorname";
            //
            // colBAHVNummer
            //
            this.colBAHVNummer.Name = "colBAHVNummer";
            //
            // colBGeburt
            //
            this.colBGeburt.Name = "colBGeburt";
            //
            // colBName
            //
            this.colBName.Name = "colBName";
            //
            // colBNr
            //
            this.colBNr.Name = "colBNr";
            //
            // colBVorname
            //
            this.colBVorname.Name = "colBVorname";
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
            // edtVersNr
            //
            this.edtVersNr.Location = new System.Drawing.Point(150, 160);
            this.edtVersNr.Name = "edtVersNr";
            this.edtVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtVersNr.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVersNr.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNr.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVersNr.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtVersNr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtVersNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersNr.Properties.NullText = "";
            this.edtVersNr.Properties.ShowFooter = false;
            this.edtVersNr.Properties.ShowHeader = false;
            this.edtVersNr.Size = new System.Drawing.Size(200, 24);
            this.edtVersNr.TabIndex = 26;
            //
            // lblVergleichVersNr
            //
            this.lblVergleichVersNr.Location = new System.Drawing.Point(10, 160);
            this.lblVergleichVersNr.Name = "lblVergleichVersNr";
            this.lblVergleichVersNr.Size = new System.Drawing.Size(130, 24);
            this.lblVergleichVersNr.TabIndex = 25;
            this.lblVergleichVersNr.Text = "Vergleich Vers. Nr.";
            this.lblVergleichVersNr.UseCompatibleTextRendering = true;
            //
            // CtlQueryAdmDoppeltErfasstePersonen
            //
            this.Name = "CtlQueryAdmDoppeltErfasstePersonen";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichGeburt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichAHVNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichVersNr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private KiSS4.Gui.KissButton btnDatenbereinigung;
        private KiSS4.Gui.KissButton btnStammdatenAB;
        private DevExpress.XtraGrid.Columns.GridColumn colAAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAGeburt;
        private DevExpress.XtraGrid.Columns.GridColumn colAName;
        private DevExpress.XtraGrid.Columns.GridColumn colANr;
        private DevExpress.XtraGrid.Columns.GridColumn colAVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colBAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colBGeburt;
        private DevExpress.XtraGrid.Columns.GridColumn colBName;
        private DevExpress.XtraGrid.Columns.GridColumn colBNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBVorname;
        private KiSS4.Gui.KissLookUpEdit edtAHVCode;
        private KiSS4.Gui.KissLookUpEdit edtGeburtCode;
        private KiSS4.Gui.KissLookUpEdit edtNameCode;
        private KiSS4.Gui.KissLookUpEdit edtVersNr;
        private KiSS4.Gui.KissLookUpEdit edtVornameCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblVergleichAHVNr;
        private KiSS4.Gui.KissLabel lblVergleichGeburt;
        private KiSS4.Gui.KissLabel lblVergleichName;
        private KiSS4.Gui.KissLabel lblVergleichVersNr;
        private KiSS4.Gui.KissLabel lblVergleichVorname;
    }
}
