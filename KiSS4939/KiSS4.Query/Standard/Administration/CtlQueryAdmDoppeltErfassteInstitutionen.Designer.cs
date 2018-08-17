using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Query
{
    partial class CtlQueryAdmDoppeltErfassteInstitutionen
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryAdmDoppeltErfassteInstitutionen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblVergleichName = new KiSS4.Gui.KissLabel();
            this.lblVergleichStrasse = new KiSS4.Gui.KissLabel();
            this.lblVergleichOrt = new KiSS4.Gui.KissLabel();
            this.lblVergleichTelefon = new KiSS4.Gui.KissLabel();
            this.edtNameCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtStrasseCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtOrtCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtTelefonCode = new KiSS4.Gui.KissLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnDatenbereinigung = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonCode.Properties)).BeginInit();
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
            this.xDocument.Location = new System.Drawing.Point(307, 397);
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
            this.xDocument.Size = new System.Drawing.Size(31, 24);
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Location = new System.Drawing.Point(269, 398);
            this.ctlGotoFall.Size = new System.Drawing.Size(32, 24);
            this.ctlGotoFall.Visible = false;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnDatenbereinigung);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnDatenbereinigung, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtTelefonCode);
            this.tpgSuchen.Controls.Add(this.edtOrtCode);
            this.tpgSuchen.Controls.Add(this.edtStrasseCode);
            this.tpgSuchen.Controls.Add(this.edtNameCode);
            this.tpgSuchen.Controls.Add(this.lblVergleichTelefon);
            this.tpgSuchen.Controls.Add(this.lblVergleichOrt);
            this.tpgSuchen.Controls.Add(this.lblVergleichStrasse);
            this.tpgSuchen.Controls.Add(this.lblVergleichName);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVergleichName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVergleichStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVergleichOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVergleichTelefon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStrasseCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrtCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtTelefonCode, 0);
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
            // lblVergleichStrasse
            // 
            this.lblVergleichStrasse.Location = new System.Drawing.Point(10, 70);
            this.lblVergleichStrasse.Name = "lblVergleichStrasse";
            this.lblVergleichStrasse.Size = new System.Drawing.Size(130, 24);
            this.lblVergleichStrasse.TabIndex = 2;
            this.lblVergleichStrasse.Text = "Vergleich Strasse";
            this.lblVergleichStrasse.UseCompatibleTextRendering = true;
            // 
            // lblVergleichOrt
            // 
            this.lblVergleichOrt.Location = new System.Drawing.Point(10, 100);
            this.lblVergleichOrt.Name = "lblVergleichOrt";
            this.lblVergleichOrt.Size = new System.Drawing.Size(130, 24);
            this.lblVergleichOrt.TabIndex = 3;
            this.lblVergleichOrt.Text = "Vergleich Ort";
            this.lblVergleichOrt.UseCompatibleTextRendering = true;
            // 
            // lblVergleichTelefon
            // 
            this.lblVergleichTelefon.Location = new System.Drawing.Point(10, 130);
            this.lblVergleichTelefon.Name = "lblVergleichTelefon";
            this.lblVergleichTelefon.Size = new System.Drawing.Size(130, 24);
            this.lblVergleichTelefon.TabIndex = 4;
            this.lblVergleichTelefon.Text = "Vergleich Telefon";
            this.lblVergleichTelefon.UseCompatibleTextRendering = true;
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
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtNameCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtNameCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameCode.Properties.NullText = "";
            this.edtNameCode.Properties.ShowFooter = false;
            this.edtNameCode.Properties.ShowHeader = false;
            this.edtNameCode.Size = new System.Drawing.Size(200, 24);
            this.edtNameCode.TabIndex = 21;
            // 
            // edtStrasseCode
            // 
            this.edtStrasseCode.Location = new System.Drawing.Point(150, 70);
            this.edtStrasseCode.Name = "edtStrasseCode";
            this.edtStrasseCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasseCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseCode.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStrasseCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStrasseCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStrasseCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtStrasseCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtStrasseCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStrasseCode.Properties.NullText = "";
            this.edtStrasseCode.Properties.ShowFooter = false;
            this.edtStrasseCode.Properties.ShowHeader = false;
            this.edtStrasseCode.Size = new System.Drawing.Size(200, 24);
            this.edtStrasseCode.TabIndex = 22;
            // 
            // edtOrtCode
            // 
            this.edtOrtCode.Location = new System.Drawing.Point(150, 100);
            this.edtOrtCode.Name = "edtOrtCode";
            this.edtOrtCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrtCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrtCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrtCode.Properties.Appearance.Options.UseFont = true;
            this.edtOrtCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtOrtCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrtCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtOrtCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtOrtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtOrtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtOrtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrtCode.Properties.NullText = "";
            this.edtOrtCode.Properties.ShowFooter = false;
            this.edtOrtCode.Properties.ShowHeader = false;
            this.edtOrtCode.Size = new System.Drawing.Size(200, 24);
            this.edtOrtCode.TabIndex = 23;
            // 
            // edtTelefonCode
            // 
            this.edtTelefonCode.Location = new System.Drawing.Point(150, 130);
            this.edtTelefonCode.Name = "edtTelefonCode";
            this.edtTelefonCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTelefonCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefonCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefonCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefonCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefonCode.Properties.Appearance.Options.UseFont = true;
            this.edtTelefonCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTelefonCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefonCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTelefonCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTelefonCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtTelefonCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtTelefonCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTelefonCode.Properties.NullText = "";
            this.edtTelefonCode.Properties.ShowFooter = false;
            this.edtTelefonCode.Properties.ShowHeader = false;
            this.edtTelefonCode.Size = new System.Drawing.Size(200, 24);
            this.edtTelefonCode.TabIndex = 24;
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
            // btnDatenbereinigung
            // 
            this.btnDatenbereinigung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDatenbereinigung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatenbereinigung.Location = new System.Drawing.Point(3, 397);
            this.btnDatenbereinigung.Name = "btnDatenbereinigung";
            this.btnDatenbereinigung.Size = new System.Drawing.Size(119, 24);
            this.btnDatenbereinigung.TabIndex = 5;
            this.btnDatenbereinigung.Text = "Datenbereinigung";
            this.btnDatenbereinigung.UseCompatibleTextRendering = true;
            this.btnDatenbereinigung.UseVisualStyleBackColor = false;
            this.btnDatenbereinigung.Click += new System.EventHandler(this.btnDatenbereinigung_Click);
            // 
            // CtlQueryAdmDoppeltErfassteInstitutionen
            // 
            this.Name = "CtlQueryAdmDoppeltErfassteInstitutionen";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVergleichTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefonCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissButton btnDatenbereinigung;
        private KiSS4.Gui.KissLookUpEdit edtNameCode;
        private KiSS4.Gui.KissLookUpEdit edtOrtCode;
        private KiSS4.Gui.KissLookUpEdit edtStrasseCode;
        private KiSS4.Gui.KissLookUpEdit edtTelefonCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblVergleichName;
        private KiSS4.Gui.KissLabel lblVergleichOrt;
        private KiSS4.Gui.KissLabel lblVergleichStrasse;
        private KiSS4.Gui.KissLabel lblVergleichTelefon;
    }
}
