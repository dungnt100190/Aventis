namespace KiSS4.Query
{
    partial class CtlQueryKaWartelisteSemo
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaWartelisteSemo));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblStatusWL = new KiSS4.Gui.KissLabel();
            this.lblZuweiser = new KiSS4.Gui.KissLabel();
            this.lblNiveau = new KiSS4.Gui.KissLabel();
            this.edtWartelisteCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtZuweiserID = new KiSS4.Gui.KissButtonEdit();
            this.edtNiveauCode = new KiSS4.Gui.KissLookUpEdit();
            this.colAdresse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusweisart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum1Intake = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum2Intake = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumAnmeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEintrittmglichab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExtern = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHandy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHandySTES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameSTES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNiveaueinteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusRahmenfrist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefonSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefonSARPB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefonSTES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVornameSTES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWerkstattabwahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustndigerSARPB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustndigerSozialdienst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuweiser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusWL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNiveau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWartelisteCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWartelisteCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuweiserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            // 
            // 
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
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
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
            this.tpgSuchen.Controls.Add(this.edtNiveauCode);
            this.tpgSuchen.Controls.Add(this.edtZuweiserID);
            this.tpgSuchen.Controls.Add(this.edtWartelisteCode);
            this.tpgSuchen.Controls.Add(this.lblNiveau);
            this.tpgSuchen.Controls.Add(this.lblZuweiser);
            this.tpgSuchen.Controls.Add(this.lblStatusWL);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatusWL, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZuweiser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNiveau, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtWartelisteCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZuweiserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNiveauCode, 0);
            // 
            // lblStatusWL
            // 
            this.lblStatusWL.Location = new System.Drawing.Point(10, 40);
            this.lblStatusWL.Name = "lblStatusWL";
            this.lblStatusWL.Size = new System.Drawing.Size(130, 24);
            this.lblStatusWL.TabIndex = 1;
            this.lblStatusWL.Text = "Status WL";
            this.lblStatusWL.UseCompatibleTextRendering = true;
            // 
            // lblZuweiser
            // 
            this.lblZuweiser.Location = new System.Drawing.Point(10, 70);
            this.lblZuweiser.Name = "lblZuweiser";
            this.lblZuweiser.Size = new System.Drawing.Size(130, 24);
            this.lblZuweiser.TabIndex = 2;
            this.lblZuweiser.Text = "Zuweiser";
            this.lblZuweiser.UseCompatibleTextRendering = true;
            // 
            // lblNiveau
            // 
            this.lblNiveau.Location = new System.Drawing.Point(10, 100);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(130, 24);
            this.lblNiveau.TabIndex = 3;
            this.lblNiveau.Text = "Niveau";
            this.lblNiveau.UseCompatibleTextRendering = true;
            // 
            // edtWartelisteCode
            // 
            this.edtWartelisteCode.Location = new System.Drawing.Point(150, 40);
            this.edtWartelisteCode.LOVName = "KaQjIntakeStatusWarteliste";
            this.edtWartelisteCode.Name = "edtWartelisteCode";
            this.edtWartelisteCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWartelisteCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWartelisteCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWartelisteCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtWartelisteCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWartelisteCode.Properties.Appearance.Options.UseFont = true;
            this.edtWartelisteCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtWartelisteCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtWartelisteCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtWartelisteCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtWartelisteCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtWartelisteCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtWartelisteCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWartelisteCode.Properties.NullText = "";
            this.edtWartelisteCode.Properties.ShowFooter = false;
            this.edtWartelisteCode.Properties.ShowHeader = false;
            this.edtWartelisteCode.Size = new System.Drawing.Size(250, 24);
            this.edtWartelisteCode.TabIndex = 21;
            // 
            // edtZuweiserID
            // 
            this.edtZuweiserID.Location = new System.Drawing.Point(150, 70);
            this.edtZuweiserID.Name = "edtZuweiserID";
            this.edtZuweiserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZuweiserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZuweiserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZuweiserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtZuweiserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZuweiserID.Properties.Appearance.Options.UseFont = true;
            this.edtZuweiserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZuweiserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZuweiserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZuweiserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtZuweiserID.Size = new System.Drawing.Size(250, 24);
            this.edtZuweiserID.TabIndex = 22;
            this.edtZuweiserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZuweiserID_UserModifiedFld);
            // 
            // edtNiveauCode
            // 
            this.edtNiveauCode.Location = new System.Drawing.Point(150, 100);
            this.edtNiveauCode.LOVName = "KaQjNiveau";
            this.edtNiveauCode.Name = "edtNiveauCode";
            this.edtNiveauCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNiveauCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNiveauCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNiveauCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtNiveauCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNiveauCode.Properties.Appearance.Options.UseFont = true;
            this.edtNiveauCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNiveauCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNiveauCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNiveauCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNiveauCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtNiveauCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtNiveauCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNiveauCode.Properties.NullText = "";
            this.edtNiveauCode.Properties.ShowFooter = false;
            this.edtNiveauCode.Properties.ShowHeader = false;
            this.edtNiveauCode.Size = new System.Drawing.Size(250, 24);
            this.edtNiveauCode.TabIndex = 23;
            // 
            // colAdresse
            // 
            this.colAdresse.Name = "colAdresse";
            // 
            // colAusweisart
            // 
            this.colAusweisart.Name = "colAusweisart";
            // 
            // colBemerkung
            // 
            this.colBemerkung.Name = "colBemerkung";
            // 
            // colDatum1Intake
            // 
            this.colDatum1Intake.Name = "colDatum1Intake";
            // 
            // colDatum2Intake
            // 
            this.colDatum2Intake.Name = "colDatum2Intake";
            // 
            // colDatumAnmeldung
            // 
            this.colDatumAnmeldung.Name = "colDatumAnmeldung";
            // 
            // colEintrittmglichab
            // 
            this.colEintrittmglichab.Name = "colEintrittmglichab";
            // 
            // colEmailSAR
            // 
            this.colEmailSAR.Name = "colEmailSAR";
            // 
            // colExtern
            // 
            this.colExtern.Name = "colExtern";
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Name = "colGeschlecht";
            // 
            // colHandy
            // 
            this.colHandy.Name = "colHandy";
            // 
            // colHandySTES
            // 
            this.colHandySTES.Name = "colHandySTES";
            // 
            // colNameSTES
            // 
            this.colNameSTES.Name = "colNameSTES";
            // 
            // colNiveaueinteilung
            // 
            this.colNiveaueinteilung.Name = "colNiveaueinteilung";
            // 
            // colOrt
            // 
            this.colOrt.Name = "colOrt";
            // 
            // colPLZ
            // 
            this.colPLZ.Name = "colPLZ";
            // 
            // colSAR
            // 
            this.colSAR.Name = "colSAR";
            // 
            // colStatusRahmenfrist
            // 
            this.colStatusRahmenfrist.Name = "colStatusRahmenfrist";
            // 
            // colTelefon
            // 
            this.colTelefon.Name = "colTelefon";
            // 
            // colTelefonSAR
            // 
            this.colTelefonSAR.Name = "colTelefonSAR";
            // 
            // colTelefonSARPB
            // 
            this.colTelefonSARPB.Name = "colTelefonSARPB";
            // 
            // colTelefonSTES
            // 
            this.colTelefonSTES.Name = "colTelefonSTES";
            // 
            // colVornameSTES
            // 
            this.colVornameSTES.Name = "colVornameSTES";
            // 
            // colWerkstattabwahl
            // 
            this.colWerkstattabwahl.Name = "colWerkstattabwahl";
            // 
            // colZustndigerSARPB
            // 
            this.colZustndigerSARPB.Name = "colZustndigerSARPB";
            // 
            // colZustndigerSozialdienst
            // 
            this.colZustndigerSozialdienst.Name = "colZustndigerSozialdienst";
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
            // CtlQueryKaWartelisteSemo
            // 
            this.Name = "CtlQueryKaWartelisteSemo";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusWL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuweiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNiveau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWartelisteCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWartelisteCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZuweiserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAdresse;
        private DevExpress.XtraGrid.Columns.GridColumn colAusweisart;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum1Intake;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum2Intake;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumAnmeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colEintrittmglichab;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colExtern;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colHandy;
        private DevExpress.XtraGrid.Columns.GridColumn colHandySTES;
        private DevExpress.XtraGrid.Columns.GridColumn colNameSTES;
        private DevExpress.XtraGrid.Columns.GridColumn colNiveaueinteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusRahmenfrist;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefonSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefonSARPB;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefonSTES;
        private DevExpress.XtraGrid.Columns.GridColumn colVornameSTES;
        private DevExpress.XtraGrid.Columns.GridColumn colWerkstattabwahl;
        private DevExpress.XtraGrid.Columns.GridColumn colZustndigerSARPB;
        private DevExpress.XtraGrid.Columns.GridColumn colZustndigerSozialdienst;
        private DevExpress.XtraGrid.Columns.GridColumn colZuweiser;
        private KiSS4.Gui.KissLookUpEdit edtNiveauCode;
        private KiSS4.Gui.KissLookUpEdit edtWartelisteCode;
        private KiSS4.Gui.KissButtonEdit edtZuweiserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblNiveau;
        private KiSS4.Gui.KissLabel lblStatusWL;
        private KiSS4.Gui.KissLabel lblZuweiser;
    }
}