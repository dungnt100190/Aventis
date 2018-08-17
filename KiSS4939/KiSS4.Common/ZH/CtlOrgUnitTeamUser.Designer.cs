namespace KiSS4.Common.ZH
{
    partial class CtlOrgUnitTeamUser
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlOrgUnitTeamUser));
            this.edtSucheGruppe = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheOE = new KiSS4.Gui.KissLabel();
            this.edtSucheTeam = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheTeam = new KiSS4.Gui.KissLabel();
            this.edtSucheUserID = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheUserID = new KiSS4.Gui.KissLabel();
            this.qryOrgUnitTeam = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOrgUnitTeam)).BeginInit();
            this.SuspendLayout();
            // 
            // edtSucheGruppe
            // 
            this.edtSucheGruppe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSucheGruppe.Location = new System.Drawing.Point(113, 0);
            this.edtSucheGruppe.LOVName = "QuOrgUnitGroup";
            this.edtSucheGruppe.Name = "edtSucheGruppe";
            this.edtSucheGruppe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGruppe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGruppe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGruppe.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGruppe.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGruppe.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheGruppe.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGruppe.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheGruppe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheGruppe.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGruppe.Properties.NullText = "";
            this.edtSucheGruppe.Properties.ShowFooter = false;
            this.edtSucheGruppe.Properties.ShowHeader = false;
            this.edtSucheGruppe.Size = new System.Drawing.Size(260, 24);
            this.edtSucheGruppe.TabIndex = 0;
            this.edtSucheGruppe.EditValueChanged += new System.EventHandler(this.edtSucheGruppe_EditValueChanged);
            // 
            // lblSucheOE
            // 
            this.lblSucheOE.Location = new System.Drawing.Point(0, 0);
            this.lblSucheOE.Name = "lblSucheOE";
            this.lblSucheOE.Size = new System.Drawing.Size(111, 24);
            this.lblSucheOE.TabIndex = 0;
            this.lblSucheOE.Text = "Organisationsgruppe";
            this.lblSucheOE.UseCompatibleTextRendering = true;
            // 
            // edtSucheTeam
            // 
            this.edtSucheTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSucheTeam.Location = new System.Drawing.Point(113, 30);
            this.edtSucheTeam.LOVFilter = "FF";
            this.edtSucheTeam.LOVName = "QuOrgUnitTeam";
            this.edtSucheTeam.Name = "edtSucheTeam";
            this.edtSucheTeam.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTeam.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTeam.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTeam.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTeam.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTeam.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheTeam.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTeam.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheTeam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheTeam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheTeam.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheTeam.Properties.NullText = "";
            this.edtSucheTeam.Properties.ShowFooter = false;
            this.edtSucheTeam.Properties.ShowHeader = false;
            this.edtSucheTeam.Size = new System.Drawing.Size(260, 24);
            this.edtSucheTeam.TabIndex = 1;
            this.edtSucheTeam.Tag = "";
            this.edtSucheTeam.EditValueChanged += new System.EventHandler(this.edtSucheTeam_EditValueChanged);
            // 
            // lblSucheTeam
            // 
            this.lblSucheTeam.Location = new System.Drawing.Point(0, 30);
            this.lblSucheTeam.Name = "lblSucheTeam";
            this.lblSucheTeam.Size = new System.Drawing.Size(111, 24);
            this.lblSucheTeam.TabIndex = 1;
            this.lblSucheTeam.Text = "Team";
            this.lblSucheTeam.UseCompatibleTextRendering = true;
            // 
            // edtSucheUserID
            // 
            this.edtSucheUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSucheUserID.Location = new System.Drawing.Point(113, 60);
            this.edtSucheUserID.LookupSQL = "select ID = UserID, SAR = LastName + isNull(\', \' + FirstName,\'\'), \r\n[Kuerzel] = L" +
    "ogonName\nfrom   XUser \nwhere LastName + isNull(\', \' + FirstName,\'\') \r\nlike {0} +" +
    " \'%\' order by SAR\r\n----";
            this.edtSucheUserID.Name = "edtSucheUserID";
            this.edtSucheUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheUserID.Size = new System.Drawing.Size(260, 24);
            this.edtSucheUserID.TabIndex = 2;
            this.edtSucheUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheUserID_UserModifiedFld);
            this.edtSucheUserID.EditValueChanged += new System.EventHandler(this.edtSucheUserID_EditValueChanged);
            this.edtSucheUserID.Enter += new System.EventHandler(this.edtSucheUserID_Enter);
            this.edtSucheUserID.Leave += new System.EventHandler(this.edtSucheUserID_Leave);
            // 
            // lblSucheUserID
            // 
            this.lblSucheUserID.Location = new System.Drawing.Point(0, 60);
            this.lblSucheUserID.Name = "lblSucheUserID";
            this.lblSucheUserID.Size = new System.Drawing.Size(111, 24);
            this.lblSucheUserID.TabIndex = 2;
            this.lblSucheUserID.Text = "Mitarbeiter/in";
            this.lblSucheUserID.UseCompatibleTextRendering = true;
            // 
            // qryOrgUnitTeam
            // 
            this.qryOrgUnitTeam.HostControl = this;
            this.qryOrgUnitTeam.SelectStatement = resources.GetString("qryOrgUnitTeam.SelectStatement");
            // 
            // CtlOrgUnitTeamUser
            // 
            this.Controls.Add(this.lblSucheUserID);
            this.Controls.Add(this.edtSucheUserID);
            this.Controls.Add(this.lblSucheTeam);
            this.Controls.Add(this.edtSucheTeam);
            this.Controls.Add(this.lblSucheOE);
            this.Controls.Add(this.edtSucheGruppe);
            this.Name = "CtlOrgUnitTeamUser";
            this.Size = new System.Drawing.Size(373, 84);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOrgUnitTeam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissLookUpEdit edtSucheGruppe;
        private KiSS4.Gui.KissLookUpEdit edtSucheTeam;
        private KiSS4.Gui.KissButtonEdit edtSucheUserID;
        private KiSS4.Gui.KissLabel lblSucheOE;
        private KiSS4.Gui.KissLabel lblSucheTeam;
        private KiSS4.Gui.KissLabel lblSucheUserID;
        private DB.SqlQuery qryOrgUnitTeam;
    }
}
