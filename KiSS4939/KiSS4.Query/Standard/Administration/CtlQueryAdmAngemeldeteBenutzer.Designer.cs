namespace KiSS4.Query
{
    partial class CtlQueryAdmAngemeldeteBenutzer
    {
        #region Dispose

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

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryAdmAngemeldeteBenutzer));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.edtLetztesSql = new KiSS4.Gui.KissMemoEdit();
            this.lblLetztesSql = new KiSS4.Gui.KissLabel();
            this.lblGesperrtDurch = new KiSS4.Gui.KissLabel();
            this.edtLockPid = new KiSS4.Gui.KissTextEdit();
            this.qrySperrUser = new KiSS4.DB.SqlQuery();
            this.edtLockUser = new KiSS4.Gui.KissTextEdit();
            this.edtLockUserAbteilung = new KiSS4.Gui.KissTextEdit();
            this.edtLockUserTel = new KiSS4.Gui.KissTextEdit();
            this.edtLockUserPc = new KiSS4.Gui.KissTextEdit();
            this.lblLockPid = new KiSS4.Gui.KissLabel();
            this.lblLockUser = new KiSS4.Gui.KissLabel();
            this.lblLockUserAbteilung = new KiSS4.Gui.KissLabel();
            this.lblLockUserTel = new KiSS4.Gui.KissLabel();
            this.lblLockUserPc = new KiSS4.Gui.KissLabel();
            this.edtSucheNurGesperrte = new KiSS4.Gui.KissCheckEdit();
            this.panListeDetails = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtLetztesSql.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetztesSql)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesperrtDurch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLockPid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySperrUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLockUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLockUserAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLockUserTel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLockUserPc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLockPid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLockUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLockUserAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLockUserTel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLockUserPc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurGesperrte.Properties)).BeginInit();
            this.panListeDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.PositionChanged += new System.EventHandler(this.qryQuery_PositionChanged);
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(0, 460);
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
            this.xDocument.Size = new System.Drawing.Size(10, 24);
            this.xDocument.TabIndex = 9;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(13, 401);
            this.ctlGotoFall.Size = new System.Drawing.Size(16, 26);
            this.ctlGotoFall.TabIndex = 8;
            this.ctlGotoFall.Visible = false;
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(761, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(785, 465);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.panListeDetails);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(773, 427);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.panListeDetails, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheNurGesperrte);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(773, 427);
            this.tpgSuchen.TabIndex = 3;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNurGesperrte, 0);
            // 
            // edtLetztesSql
            // 
            this.edtLetztesSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLetztesSql.DataMember = "LetzerBefehl$";
            this.edtLetztesSql.DataSource = this.qryQuery;
            this.edtLetztesSql.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLetztesSql.Location = new System.Drawing.Point(106, 9);
            this.edtLetztesSql.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtLetztesSql.Name = "edtLetztesSql";
            this.edtLetztesSql.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLetztesSql.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLetztesSql.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLetztesSql.Properties.Appearance.Options.UseBackColor = true;
            this.edtLetztesSql.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLetztesSql.Properties.Appearance.Options.UseFont = true;
            this.edtLetztesSql.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLetztesSql.Properties.ReadOnly = true;
            this.edtLetztesSql.Size = new System.Drawing.Size(658, 67);
            this.edtLetztesSql.TabIndex = 1;
            // 
            // lblLetztesSql
            // 
            this.lblLetztesSql.Location = new System.Drawing.Point(9, 9);
            this.lblLetztesSql.Name = "lblLetztesSql";
            this.lblLetztesSql.Size = new System.Drawing.Size(91, 24);
            this.lblLetztesSql.TabIndex = 0;
            this.lblLetztesSql.Text = "Letzer Befehl";
            this.lblLetztesSql.UseCompatibleTextRendering = true;
            // 
            // lblGesperrtDurch
            // 
            this.lblGesperrtDurch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGesperrtDurch.Location = new System.Drawing.Point(9, 106);
            this.lblGesperrtDurch.Name = "lblGesperrtDurch";
            this.lblGesperrtDurch.Size = new System.Drawing.Size(91, 24);
            this.lblGesperrtDurch.TabIndex = 2;
            this.lblGesperrtDurch.Text = "Gesperrt durch";
            this.lblGesperrtDurch.UseCompatibleTextRendering = true;
            // 
            // edtLockPid
            // 
            this.edtLockPid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtLockPid.DataMember = "Prozess";
            this.edtLockPid.DataSource = this.qrySperrUser;
            this.edtLockPid.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLockPid.Location = new System.Drawing.Point(106, 106);
            this.edtLockPid.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtLockPid.Name = "edtLockPid";
            this.edtLockPid.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLockPid.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLockPid.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLockPid.Properties.Appearance.Options.UseBackColor = true;
            this.edtLockPid.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLockPid.Properties.Appearance.Options.UseFont = true;
            this.edtLockPid.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLockPid.Properties.ReadOnly = true;
            this.edtLockPid.Size = new System.Drawing.Size(57, 24);
            this.edtLockPid.TabIndex = 4;
            // 
            // qrySperrUser
            // 
            this.qrySperrUser.HostControl = this;
            this.qrySperrUser.SelectStatement = resources.GetString("qrySperrUser.SelectStatement");
            // 
            // edtLockUser
            // 
            this.edtLockUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLockUser.DataMember = "Benutzer";
            this.edtLockUser.DataSource = this.qrySperrUser;
            this.edtLockUser.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLockUser.Location = new System.Drawing.Point(169, 106);
            this.edtLockUser.Name = "edtLockUser";
            this.edtLockUser.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLockUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLockUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLockUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtLockUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLockUser.Properties.Appearance.Options.UseFont = true;
            this.edtLockUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLockUser.Properties.ReadOnly = true;
            this.edtLockUser.Size = new System.Drawing.Size(196, 24);
            this.edtLockUser.TabIndex = 6;
            // 
            // edtLockUserAbteilung
            // 
            this.edtLockUserAbteilung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLockUserAbteilung.DataMember = "Abteilung";
            this.edtLockUserAbteilung.DataSource = this.qrySperrUser;
            this.edtLockUserAbteilung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLockUserAbteilung.Location = new System.Drawing.Point(371, 106);
            this.edtLockUserAbteilung.Name = "edtLockUserAbteilung";
            this.edtLockUserAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLockUserAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLockUserAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLockUserAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtLockUserAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLockUserAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtLockUserAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLockUserAbteilung.Properties.ReadOnly = true;
            this.edtLockUserAbteilung.Size = new System.Drawing.Size(138, 24);
            this.edtLockUserAbteilung.TabIndex = 8;
            // 
            // edtLockUserTel
            // 
            this.edtLockUserTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLockUserTel.DataMember = "Telefon";
            this.edtLockUserTel.DataSource = this.qrySperrUser;
            this.edtLockUserTel.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLockUserTel.Location = new System.Drawing.Point(515, 106);
            this.edtLockUserTel.Name = "edtLockUserTel";
            this.edtLockUserTel.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLockUserTel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLockUserTel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLockUserTel.Properties.Appearance.Options.UseBackColor = true;
            this.edtLockUserTel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLockUserTel.Properties.Appearance.Options.UseFont = true;
            this.edtLockUserTel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLockUserTel.Properties.ReadOnly = true;
            this.edtLockUserTel.Size = new System.Drawing.Size(100, 24);
            this.edtLockUserTel.TabIndex = 10;
            // 
            // edtLockUserPc
            // 
            this.edtLockUserPc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLockUserPc.DataMember = "PC";
            this.edtLockUserPc.DataSource = this.qrySperrUser;
            this.edtLockUserPc.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLockUserPc.Location = new System.Drawing.Point(621, 106);
            this.edtLockUserPc.Name = "edtLockUserPc";
            this.edtLockUserPc.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLockUserPc.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLockUserPc.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLockUserPc.Properties.Appearance.Options.UseBackColor = true;
            this.edtLockUserPc.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLockUserPc.Properties.Appearance.Options.UseFont = true;
            this.edtLockUserPc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLockUserPc.Properties.ReadOnly = true;
            this.edtLockUserPc.Size = new System.Drawing.Size(143, 24);
            this.edtLockUserPc.TabIndex = 12;
            // 
            // lblLockPid
            // 
            this.lblLockPid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLockPid.Location = new System.Drawing.Point(106, 79);
            this.lblLockPid.Name = "lblLockPid";
            this.lblLockPid.Size = new System.Drawing.Size(57, 24);
            this.lblLockPid.TabIndex = 3;
            this.lblLockPid.Text = "Prozess";
            this.lblLockPid.UseCompatibleTextRendering = true;
            // 
            // lblLockUser
            // 
            this.lblLockUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLockUser.Location = new System.Drawing.Point(169, 79);
            this.lblLockUser.Name = "lblLockUser";
            this.lblLockUser.Size = new System.Drawing.Size(191, 24);
            this.lblLockUser.TabIndex = 5;
            this.lblLockUser.Text = "Benutzer";
            this.lblLockUser.UseCompatibleTextRendering = true;
            // 
            // lblLockUserAbteilung
            // 
            this.lblLockUserAbteilung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLockUserAbteilung.Location = new System.Drawing.Point(371, 79);
            this.lblLockUserAbteilung.Name = "lblLockUserAbteilung";
            this.lblLockUserAbteilung.Size = new System.Drawing.Size(138, 24);
            this.lblLockUserAbteilung.TabIndex = 7;
            this.lblLockUserAbteilung.Text = "Abteilung";
            this.lblLockUserAbteilung.UseCompatibleTextRendering = true;
            // 
            // lblLockUserTel
            // 
            this.lblLockUserTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLockUserTel.Location = new System.Drawing.Point(515, 80);
            this.lblLockUserTel.Name = "lblLockUserTel";
            this.lblLockUserTel.Size = new System.Drawing.Size(100, 23);
            this.lblLockUserTel.TabIndex = 9;
            this.lblLockUserTel.Text = "Telefon";
            this.lblLockUserTel.UseCompatibleTextRendering = true;
            // 
            // lblLockUserPc
            // 
            this.lblLockUserPc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLockUserPc.Location = new System.Drawing.Point(621, 79);
            this.lblLockUserPc.Name = "lblLockUserPc";
            this.lblLockUserPc.Size = new System.Drawing.Size(143, 24);
            this.lblLockUserPc.TabIndex = 11;
            this.lblLockUserPc.Text = "PC";
            this.lblLockUserPc.UseCompatibleTextRendering = true;
            // 
            // edtSucheNurGesperrte
            // 
            this.edtSucheNurGesperrte.EditValue = false;
            this.edtSucheNurGesperrte.Location = new System.Drawing.Point(31, 40);
            this.edtSucheNurGesperrte.Name = "edtSucheNurGesperrte";
            this.edtSucheNurGesperrte.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtSucheNurGesperrte.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNurGesperrte.Properties.Caption = "nur gesperrte Benutzer";
            this.edtSucheNurGesperrte.Size = new System.Drawing.Size(221, 19);
            this.edtSucheNurGesperrte.TabIndex = 1;
            // 
            // panListeDetails
            // 
            this.panListeDetails.Controls.Add(this.lblLetztesSql);
            this.panListeDetails.Controls.Add(this.lblLockUserPc);
            this.panListeDetails.Controls.Add(this.edtLetztesSql);
            this.panListeDetails.Controls.Add(this.lblLockUserTel);
            this.panListeDetails.Controls.Add(this.lblGesperrtDurch);
            this.panListeDetails.Controls.Add(this.lblLockUserAbteilung);
            this.panListeDetails.Controls.Add(this.edtLockPid);
            this.panListeDetails.Controls.Add(this.lblLockUser);
            this.panListeDetails.Controls.Add(this.edtLockUser);
            this.panListeDetails.Controls.Add(this.lblLockPid);
            this.panListeDetails.Controls.Add(this.edtLockUserAbteilung);
            this.panListeDetails.Controls.Add(this.edtLockUserPc);
            this.panListeDetails.Controls.Add(this.edtLockUserTel);
            this.panListeDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panListeDetails.Location = new System.Drawing.Point(0, 283);
            this.panListeDetails.Name = "panListeDetails";
            this.panListeDetails.Size = new System.Drawing.Size(773, 144);
            this.panListeDetails.TabIndex = 1;
            // 
            // CtlQueryAdmAngemeldeteBenutzer
            // 
            this.Name = "CtlQueryAdmAngemeldeteBenutzer";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtLetztesSql.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetztesSql)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesperrtDurch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLockPid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySperrUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLockUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLockUserAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLockUserTel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLockUserPc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLockPid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLockUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLockUserAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLockUserTel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLockUserPc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNurGesperrte.Properties)).EndInit();
            this.panListeDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissMemoEdit edtLetztesSql;
        private KiSS4.Gui.KissTextEdit edtLockPid;
        private KiSS4.Gui.KissTextEdit edtLockUser;
        private KiSS4.Gui.KissTextEdit edtLockUserAbteilung;
        private KiSS4.Gui.KissTextEdit edtLockUserPc;
        private KiSS4.Gui.KissTextEdit edtLockUserTel;
        private KiSS4.Gui.KissCheckEdit edtSucheNurGesperrte;
        private KiSS4.Gui.KissLabel lblGesperrtDurch;
        private KiSS4.Gui.KissLabel lblLetztesSql;
        private KiSS4.Gui.KissLabel lblLockPid;
        private KiSS4.Gui.KissLabel lblLockUser;
        private KiSS4.Gui.KissLabel lblLockUserAbteilung;
        private KiSS4.Gui.KissLabel lblLockUserPc;
        private KiSS4.Gui.KissLabel lblLockUserTel;
        private System.Windows.Forms.Panel panListeDetails;
        private KiSS4.DB.SqlQuery qrySperrUser;
    }
}
