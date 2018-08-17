namespace KiSS4.Fallfuehrung.ZH
{
    partial class CtlFaTeilleistungserbringer
    {
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaTeilleistungserbringer));
            this.grdFaLeistungserbringer = new KiSS4.Gui.KissGrid();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblOrgUnit = new KiSS4.Gui.KissLabel();
            this.edtUser = new KiSS4.Gui.KissButtonEdit();
            this.lblUser = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.edtOrgName = new KiSS4.Gui.KissTextEdit();
            this.kissLabel17 = new KiSS4.Gui.KissLabel();
            this.edtUserName = new KiSS4.Gui.KissTextEdit();
            this.kissLabel18 = new KiSS4.Gui.KissLabel();
            this.edtTelefon = new KiSS4.Gui.KissTextEdit();
            this.edtEMail = new KiSS4.Gui.KissTextEdit();
            this.kissLabel19 = new KiSS4.Gui.KissLabel();
            this.lblUserName = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvFaLeistungserbringer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryFaTeilLeistungserbringer = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistungserbringer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistungserbringer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaTeilLeistungserbringer)).BeginInit();
            this.SuspendLayout();
            //
            // grdFaLeistungserbringer
            //
            this.grdFaLeistungserbringer.DataSource = this.qryFaTeilLeistungserbringer;
            this.grdFaLeistungserbringer.EmbeddedNavigator.Name = "kissGrid2.EmbeddedNavigator";
            this.grdFaLeistungserbringer.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFaLeistungserbringer.Location = new System.Drawing.Point(5, 31);
            this.grdFaLeistungserbringer.MainView = this.grvFaLeistungserbringer;
            this.grdFaLeistungserbringer.Name = "grdFaLeistungserbringer";
            this.grdFaLeistungserbringer.Size = new System.Drawing.Size(694, 152);
            this.grdFaLeistungserbringer.TabIndex = 0;
            this.grdFaLeistungserbringer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvFaLeistungserbringer});
            //
            // edtDatumVon
            //
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryFaTeilLeistungserbringer;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(86, 200);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.Name = "kissDateEdit1.Properties";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 1;
            //
            // kissLabel3
            //
            this.kissLabel3.Location = new System.Drawing.Point(5, 200);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(72, 24);
            this.kissLabel3.TabIndex = 1;
            this.kissLabel3.Text = "Dauer von";
            this.kissLabel3.UseCompatibleTextRendering = true;
            //
            // edtDatumBis
            //
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryFaTeilLeistungserbringer;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(226, 200);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.Name = "kissDateEdit5.Properties";
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 2;
            //
            // lblOrgUnit
            //
            this.lblOrgUnit.Location = new System.Drawing.Point(5, 260);
            this.lblOrgUnit.Name = "lblOrgUnit";
            this.lblOrgUnit.Size = new System.Drawing.Size(72, 24);
            this.lblOrgUnit.TabIndex = 2;
            this.lblOrgUnit.Text = "Org. Einheit";
            this.lblOrgUnit.UseCompatibleTextRendering = true;
            //
            // edtUser
            //
            this.edtUser.DataMember = "UserLogon";
            this.edtUser.DataSource = this.qryFaTeilLeistungserbringer;
            this.edtUser.Location = new System.Drawing.Point(86, 230);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUser.Properties.Appearance.Options.UseFont = true;
            this.edtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUser.Properties.Name = "kissButtonEdit1.Properties";
            this.edtUser.Size = new System.Drawing.Size(100, 24);
            this.edtUser.TabIndex = 3;
            this.edtUser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUser_UserModifiedFld);
            //
            // lblUser
            //
            this.lblUser.Location = new System.Drawing.Point(5, 230);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(72, 24);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Mitarbeiter/in";
            this.lblUser.UseCompatibleTextRendering = true;
            //
            // edtBemerkung
            //
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryFaTeilLeistungserbringer;
            this.edtBemerkung.Location = new System.Drawing.Point(86, 380);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Properties.MaxLength = 300;
            this.edtBemerkung.Properties.Name = "kissMemoEdit1.Properties";
            this.edtBemerkung.Size = new System.Drawing.Size(514, 44);
            this.edtBemerkung.TabIndex = 4;
            //
            // kissLabel16
            //
            this.kissLabel16.Location = new System.Drawing.Point(5, 320);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(72, 24);
            this.kissLabel16.TabIndex = 4;
            this.kissLabel16.Text = "Telefon";
            this.kissLabel16.UseCompatibleTextRendering = true;
            //
            // edtOrgName
            //
            this.edtOrgName.DataMember = "UserOrgUnit";
            this.edtOrgName.DataSource = this.qryFaTeilLeistungserbringer;
            this.edtOrgName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOrgName.Location = new System.Drawing.Point(86, 260);
            this.edtOrgName.Name = "edtOrgName";
            this.edtOrgName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOrgName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrgName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgName.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrgName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrgName.Properties.Appearance.Options.UseFont = true;
            this.edtOrgName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrgName.Properties.Name = "kissTextEdit1.Properties";
            this.edtOrgName.Properties.ReadOnly = true;
            this.edtOrgName.Size = new System.Drawing.Size(300, 24);
            this.edtOrgName.TabIndex = 5;
            //
            // kissLabel17
            //
            this.kissLabel17.Location = new System.Drawing.Point(5, 350);
            this.kissLabel17.Name = "kissLabel17";
            this.kissLabel17.Size = new System.Drawing.Size(72, 24);
            this.kissLabel17.TabIndex = 5;
            this.kissLabel17.Text = "E-Mail";
            this.kissLabel17.UseCompatibleTextRendering = true;
            //
            // edtUserName
            //
            this.edtUserName.DataMember = "UserName";
            this.edtUserName.DataSource = this.qryFaTeilLeistungserbringer;
            this.edtUserName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUserName.Location = new System.Drawing.Point(86, 290);
            this.edtUserName.Name = "edtUserName";
            this.edtUserName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUserName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserName.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserName.Properties.Appearance.Options.UseFont = true;
            this.edtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserName.Properties.Name = "kissTextEdit1.Properties";
            this.edtUserName.Properties.ReadOnly = true;
            this.edtUserName.Size = new System.Drawing.Size(300, 24);
            this.edtUserName.TabIndex = 6;
            //
            // kissLabel18
            //
            this.kissLabel18.Location = new System.Drawing.Point(5, 380);
            this.kissLabel18.Name = "kissLabel18";
            this.kissLabel18.Size = new System.Drawing.Size(72, 24);
            this.kissLabel18.TabIndex = 6;
            this.kissLabel18.Text = "Bemerkung";
            this.kissLabel18.UseCompatibleTextRendering = true;
            //
            // edtTelefon
            //
            this.edtTelefon.DataMember = "UserPhone";
            this.edtTelefon.DataSource = this.qryFaTeilLeistungserbringer;
            this.edtTelefon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTelefon.Location = new System.Drawing.Point(86, 320);
            this.edtTelefon.Name = "edtTelefon";
            this.edtTelefon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTelefon.Properties.Name = "kissTextEdit1.Properties";
            this.edtTelefon.Properties.ReadOnly = true;
            this.edtTelefon.Size = new System.Drawing.Size(300, 24);
            this.edtTelefon.TabIndex = 7;
            //
            // edtEMail
            //
            this.edtEMail.DataMember = "UserEMail";
            this.edtEMail.DataSource = this.qryFaTeilLeistungserbringer;
            this.edtEMail.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEMail.Location = new System.Drawing.Point(86, 350);
            this.edtEMail.Name = "edtEMail";
            this.edtEMail.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEMail.Properties.Appearance.Options.UseFont = true;
            this.edtEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEMail.Properties.Name = "kissTextEdit2.Properties";
            this.edtEMail.Properties.ReadOnly = true;
            this.edtEMail.Size = new System.Drawing.Size(300, 24);
            this.edtEMail.TabIndex = 8;
            //
            // kissLabel19
            //
            this.kissLabel19.Location = new System.Drawing.Point(198, 200);
            this.kissLabel19.Name = "kissLabel19";
            this.kissLabel19.Size = new System.Drawing.Size(24, 24);
            this.kissLabel19.TabIndex = 8;
            this.kissLabel19.Text = "bis";
            this.kissLabel19.UseCompatibleTextRendering = true;
            //
            // lblUserName
            //
            this.lblUserName.Location = new System.Drawing.Point(5, 290);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(72, 24);
            this.lblUserName.TabIndex = 18;
            this.lblUserName.Text = "Name";
            this.lblUserName.UseCompatibleTextRendering = true;
            //
            // panel1
            //
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 24);
            this.panel1.TabIndex = 19;
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 17);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Teilleistungserbringer/innen";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            //
            // colDatumBis
            //
            this.colDatumBis.Caption = "bis";
            this.colDatumBis.FieldName = "DatumBis";
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 1;
            //
            // colDatumVon
            //
            this.colDatumVon.Caption = "Dauer von";
            this.colDatumVon.FieldName = "DatumVon";
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 0;
            //
            // colName
            //
            this.colName.Caption = "Mitarbeiter/in";
            this.colName.FieldName = "UserName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 211;
            //
            // colOrgUnit
            //
            this.colOrgUnit.Caption = "Organisationseinheit";
            this.colOrgUnit.FieldName = "UserOrgUnit";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 3;
            this.colOrgUnit.Width = 242;
            //
            // grvFaLeistungserbringer
            //
            this.grvFaLeistungserbringer.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFaLeistungserbringer.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungserbringer.Appearance.Empty.Options.UseBackColor = true;
            this.grvFaLeistungserbringer.Appearance.Empty.Options.UseFont = true;
            this.grvFaLeistungserbringer.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungserbringer.Appearance.EvenRow.Options.UseFont = true;
            this.grvFaLeistungserbringer.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaLeistungserbringer.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungserbringer.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFaLeistungserbringer.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFaLeistungserbringer.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFaLeistungserbringer.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFaLeistungserbringer.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFaLeistungserbringer.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungserbringer.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFaLeistungserbringer.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFaLeistungserbringer.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFaLeistungserbringer.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFaLeistungserbringer.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistungserbringer.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFaLeistungserbringer.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFaLeistungserbringer.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungserbringer.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistungserbringer.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFaLeistungserbringer.Appearance.GroupRow.Options.UseFont = true;
            this.grvFaLeistungserbringer.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFaLeistungserbringer.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFaLeistungserbringer.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFaLeistungserbringer.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungserbringer.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFaLeistungserbringer.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFaLeistungserbringer.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFaLeistungserbringer.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFaLeistungserbringer.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungserbringer.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFaLeistungserbringer.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFaLeistungserbringer.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFaLeistungserbringer.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFaLeistungserbringer.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaLeistungserbringer.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFaLeistungserbringer.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungserbringer.Appearance.OddRow.Options.UseFont = true;
            this.grvFaLeistungserbringer.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFaLeistungserbringer.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungserbringer.Appearance.Row.Options.UseBackColor = true;
            this.grvFaLeistungserbringer.Appearance.Row.Options.UseFont = true;
            this.grvFaLeistungserbringer.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFaLeistungserbringer.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFaLeistungserbringer.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFaLeistungserbringer.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFaLeistungserbringer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFaLeistungserbringer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colDatumVon,
                        this.colDatumBis,
                        this.colName,
                        this.colOrgUnit});
            this.grvFaLeistungserbringer.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFaLeistungserbringer.GridControl = this.grdFaLeistungserbringer;
            this.grvFaLeistungserbringer.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvFaLeistungserbringer.Name = "grvFaLeistungserbringer";
            this.grvFaLeistungserbringer.OptionsBehavior.Editable = false;
            this.grvFaLeistungserbringer.OptionsCustomization.AllowFilter = false;
            this.grvFaLeistungserbringer.OptionsFilter.AllowFilterEditor = false;
            this.grvFaLeistungserbringer.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFaLeistungserbringer.OptionsMenu.EnableColumnMenu = false;
            this.grvFaLeistungserbringer.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFaLeistungserbringer.OptionsNavigation.UseTabKey = false;
            this.grvFaLeistungserbringer.OptionsView.ColumnAutoWidth = false;
            this.grvFaLeistungserbringer.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFaLeistungserbringer.OptionsView.ShowGroupPanel = false;
            this.grvFaLeistungserbringer.OptionsView.ShowIndicator = false;
            //
            // qryFaTeilLeistungserbringer
            //
            this.qryFaTeilLeistungserbringer.CanDelete = true;
            this.qryFaTeilLeistungserbringer.CanInsert = true;
            this.qryFaTeilLeistungserbringer.CanUpdate = true;
            this.qryFaTeilLeistungserbringer.HostControl = this;
            this.qryFaTeilLeistungserbringer.SelectStatement = resources.GetString("qryFaTeilLeistungserbringer.SelectStatement");
            this.qryFaTeilLeistungserbringer.TableName = "FaTeilLeistungserbringer";
            this.qryFaTeilLeistungserbringer.PositionChanged += new System.EventHandler(this.qryFaTeilLeistungserbringer_PositionChanged);
            this.qryFaTeilLeistungserbringer.BeforePost += new System.EventHandler(this.qryFaTeilLeistungserbringer_BeforePost);
            this.qryFaTeilLeistungserbringer.AfterInsert += new System.EventHandler(this.qryFaTeilLeistungserbringer_AfterInsert);
            //
            // CtlFaTeilleistungserbringer
            //
            this.ActiveSQLQuery = this.qryFaTeilLeistungserbringer;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.kissLabel19);
            this.Controls.Add(this.edtEMail);
            this.Controls.Add(this.edtTelefon);
            this.Controls.Add(this.kissLabel18);
            this.Controls.Add(this.edtUserName);
            this.Controls.Add(this.kissLabel17);
            this.Controls.Add(this.edtOrgName);
            this.Controls.Add(this.kissLabel16);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.edtUser);
            this.Controls.Add(this.lblOrgUnit);
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.kissLabel3);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.grdFaLeistungserbringer);
            this.Name = "CtlFaTeilleistungserbringer";
            this.Size = new System.Drawing.Size(711, 440);
            ((System.ComponentModel.ISupportInitialize)(this.grdFaLeistungserbringer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserName)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFaLeistungserbringer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaTeilLeistungserbringer)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissTextEdit edtEMail;
        private KiSS4.Gui.KissTextEdit edtOrgName;
        private KiSS4.Gui.KissTextEdit edtTelefon;
        private KiSS4.Gui.KissButtonEdit edtUser;
        private KiSS4.Gui.KissTextEdit edtUserName;
        private KiSS4.Gui.KissGrid grdFaLeistungserbringer;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFaLeistungserbringer;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel kissLabel17;
        private KiSS4.Gui.KissLabel kissLabel18;
        private KiSS4.Gui.KissLabel kissLabel19;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel lblOrgUnit;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblUser;
        private KiSS4.Gui.KissLabel lblUserName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaTeilLeistungserbringer;
    }
}