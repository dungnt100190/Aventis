using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query
{
    partial class CtlQueryBaKrankenkassenIBE
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaKrankenkassenIBE));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtNNr = new KiSS4.Gui.KissTextEdit();
            this.edtZemisNr = new KiSS4.Gui.KissTextEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.edtKrankenkasse = new KiSS4.Gui.KissTextEdit();
            this.edtNurAbtretung = new KiSS4.Gui.KissCheckEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.lblNNr = new KiSS4.Gui.KissLabel();
            this.lblZemisNr = new KiSS4.Gui.KissLabel();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.lblKrankenkasse = new KiSS4.Gui.KissLabel();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtNurAktiveFaelle = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtNNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZemisNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKrankenkasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAbtretung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZemisNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKrankenkasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktiveFaelle.Properties)).BeginInit();
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
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
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
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
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
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 395);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 27);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtNurAktiveFaelle);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Controls.Add(this.lblKrankenkasse);
            this.tpgSuchen.Controls.Add(this.lblKlient);
            this.tpgSuchen.Controls.Add(this.lblZemisNr);
            this.tpgSuchen.Controls.Add(this.lblNNr);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtNurAbtretung);
            this.tpgSuchen.Controls.Add(this.edtKrankenkasse);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtZemisNr);
            this.tpgSuchen.Controls.Add(this.edtNNr);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZemisNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKrankenkasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAbtretung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZemisNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKrankenkasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAktiveFaelle, 0);
            // 
            // edtNNr
            // 
            this.edtNNr.Location = new System.Drawing.Point(161, 48);
            this.edtNNr.Name = "edtNNr";
            this.edtNNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtNNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNNr.Properties.Appearance.Options.UseFont = true;
            this.edtNNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNNr.Size = new System.Drawing.Size(111, 24);
            this.edtNNr.TabIndex = 1;
            // 
            // edtZemisNr
            // 
            this.edtZemisNr.Location = new System.Drawing.Point(161, 79);
            this.edtZemisNr.Name = "edtZemisNr";
            this.edtZemisNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZemisNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZemisNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZemisNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtZemisNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZemisNr.Properties.Appearance.Options.UseFont = true;
            this.edtZemisNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZemisNr.Size = new System.Drawing.Size(111, 24);
            this.edtZemisNr.TabIndex = 2;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Location = new System.Drawing.Point(161, 109);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBaPersonID.Size = new System.Drawing.Size(220, 24);
            this.edtBaPersonID.TabIndex = 3;
            this.edtBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonID_UserModifiedFld);
            // 
            // edtKrankenkasse
            // 
            this.edtKrankenkasse.Location = new System.Drawing.Point(161, 139);
            this.edtKrankenkasse.Name = "edtKrankenkasse";
            this.edtKrankenkasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKrankenkasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKrankenkasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKrankenkasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtKrankenkasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKrankenkasse.Properties.Appearance.Options.UseFont = true;
            this.edtKrankenkasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKrankenkasse.Size = new System.Drawing.Size(220, 24);
            this.edtKrankenkasse.TabIndex = 4;
            // 
            // edtNurAbtretung
            // 
            this.edtNurAbtretung.EditValue = false;
            this.edtNurAbtretung.Location = new System.Drawing.Point(161, 169);
            this.edtNurAbtretung.Name = "edtNurAbtretung";
            this.edtNurAbtretung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurAbtretung.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAbtretung.Properties.Caption = " nur Abtretung";
            this.edtNurAbtretung.Size = new System.Drawing.Size(200, 19);
            this.edtNurAbtretung.TabIndex = 5;
            // 
            // edtUserID
            // 
            this.edtUserID.Location = new System.Drawing.Point(161, 194);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(220, 24);
            this.edtUserID.TabIndex = 6;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            // 
            // lblNNr
            // 
            this.lblNNr.Location = new System.Drawing.Point(21, 48);
            this.lblNNr.Name = "lblNNr";
            this.lblNNr.Size = new System.Drawing.Size(130, 24);
            this.lblNNr.TabIndex = 7;
            this.lblNNr.Text = "N-Nr";
            this.lblNNr.UseCompatibleTextRendering = true;
            // 
            // lblZemisNr
            // 
            this.lblZemisNr.Location = new System.Drawing.Point(21, 79);
            this.lblZemisNr.Name = "lblZemisNr";
            this.lblZemisNr.Size = new System.Drawing.Size(130, 24);
            this.lblZemisNr.TabIndex = 8;
            this.lblZemisNr.Text = "Zemis-Nr";
            this.lblZemisNr.UseCompatibleTextRendering = true;
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(21, 109);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(130, 24);
            this.lblKlient.TabIndex = 9;
            this.lblKlient.Text = "Klient";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // lblKrankenkasse
            // 
            this.lblKrankenkasse.Location = new System.Drawing.Point(21, 139);
            this.lblKrankenkasse.Name = "lblKrankenkasse";
            this.lblKrankenkasse.Size = new System.Drawing.Size(130, 24);
            this.lblKrankenkasse.TabIndex = 10;
            this.lblKrankenkasse.Text = "KVG-Name";
            this.lblKrankenkasse.UseCompatibleTextRendering = true;
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(21, 194);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 11;
            this.lblSAR.Text = "zuständiger SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
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
            // edtNurAktiveFaelle
            // 
            this.edtNurAktiveFaelle.EditValue = false;
            this.edtNurAktiveFaelle.Location = new System.Drawing.Point(161, 224);
            this.edtNurAktiveFaelle.Name = "edtNurAktiveFaelle";
            this.edtNurAktiveFaelle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurAktiveFaelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktiveFaelle.Properties.Caption = " nur aktive Fälle";
            this.edtNurAktiveFaelle.Size = new System.Drawing.Size(200, 19);
            this.edtNurAktiveFaelle.TabIndex = 12;
            // 
            // CtlQueryBaKrankenkassenIBE
            // 
            this.Name = "CtlQueryBaKrankenkassenIBE";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtNNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZemisNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKrankenkasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAbtretung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZemisNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKrankenkasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktiveFaelle.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KiSS4.Gui.KissTextEdit edtKrankenkasse;
        private KiSS4.Gui.KissTextEdit edtNNr;
        private KiSS4.Gui.KissCheckEdit edtNurAbtretung;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissTextEdit edtZemisNr;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblKrankenkasse;
        private KiSS4.Gui.KissLabel lblNNr;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblZemisNr;
        private KissCheckEdit edtNurAktiveFaelle;
    }
}