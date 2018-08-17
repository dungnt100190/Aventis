namespace KiSS4.Administration.ZH
{
    partial class CtlUser
    {
        private System.ComponentModel.IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlUser));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabDetail = new KiSS4.Gui.KissTabControlEx();
            this.tpgSubUser = new SharpLibrary.WinControls.TabPageEx();
            this.grdSubUser = new KiSS4.Gui.KissGrid();
            this.qrySubUser = new KiSS4.DB.SqlQuery(this.components);
            this.grvSubUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubIsUserBIAGAdmin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgTexte = new SharpLibrary.WinControls.TabPageEx();
            this.memText2 = new KiSS4.Gui.KissRTFEdit();
            this.qryUser = new KiSS4.DB.SqlQuery(this.components);
            this.lblText2 = new KiSS4.Gui.KissLabel();
            this.memText1 = new KiSS4.Gui.KissRTFEdit();
            this.lblText1 = new KiSS4.Gui.KissLabel();
            this.tpgPerson = new SharpLibrary.WinControls.TabPageEx();
            this.edtPasswort = new KiSS4.Gui.KissTextEdit();
            this.lblPasswort = new KiSS4.Gui.KissLabel();
            this.lblUserProfile = new KiSS4.Gui.KissLabel();
            this.lblPersonFremdkompetenz = new KiSS4.Gui.KissLabel();
            this.lblPersonEigenkompetenz = new KiSS4.Gui.KissLabel();
            this.lblPersonSprache = new KiSS4.Gui.KissLabel();
            this.lblPersonGeschlecht = new KiSS4.Gui.KissLabel();
            this.lblPersonEmail = new KiSS4.Gui.KissLabel();
            this.lblPersonTelefon = new KiSS4.Gui.KissLabel();
            this.edtSB = new KiSS4.Gui.KissButtonEdit();
            this.edtGrantPermGroupID = new KiSS4.Gui.KissLookUpEdit();
            this.edtPermissionGroupID = new KiSS4.Gui.KissLookUpEdit();
            this.chkIsMandatsTraeger = new KiSS4.Gui.KissCheckEdit();
            this.edtLanguageCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblPrimaryUser = new KiSS4.Gui.KissLabel();
            this.lblPersonPWKontrolle = new KiSS4.Gui.KissLabel();
            this.edtGenderCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtEMail = new KiSS4.Gui.KissTextEdit();
            this.lblFuktion = new KiSS4.Gui.KissLabel();
            this.edtPhone = new KiSS4.Gui.KissTextEdit();
            this.chkIsLocked = new KiSS4.Gui.KissCheckEdit();
            this.lblPersonKurzzeichen = new KiSS4.Gui.KissLabel();
            this.chkIsUserBIAGAdmin = new KiSS4.Gui.KissCheckEdit();
            this.chkIsUserAdmin = new KiSS4.Gui.KissCheckEdit();
            this.edtPrimaryUserID = new KiSS4.Gui.KissButtonEdit();
            this.lblLogonName = new KiSS4.Gui.KissLabel();
            this.edtUserProfile = new KiSS4.Gui.KissLookUpEdit();
            this.edtFunktion = new KiSS4.Gui.KissTextEdit();
            this.lblPersonVorname = new KiSS4.Gui.KissLabel();
            this.edtShortName = new KiSS4.Gui.KissTextEdit();
            this.edtLogonName = new KiSS4.Gui.KissTextEdit();
            this.lblLastName = new KiSS4.Gui.KissLabel();
            this.edtFirstName = new KiSS4.Gui.KissTextEdit();
            this.edtLastName = new KiSS4.Gui.KissTextEdit();
            this.lblPersonNr = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissCalcEdit();
            this.tpgOrganisationseinheiten = new SharpLibrary.WinControls.TabPageEx();
            this.grdAbteilungen = new KiSS4.Gui.KissGrid();
            this.qryAbteilung = new KiSS4.DB.SqlQuery(this.components);
            this.grvAbteilungen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOrganisationseinheit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFunktion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgBenutzerrechte = new SharpLibrary.WinControls.TabPageEx();
            this.grdRechte = new KiSS4.Gui.KissGrid();
            this.qryUserRight = new KiSS4.DB.SqlQuery(this.components);
            this.grvRechte = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRechtE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRechtM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRechtL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tpgBenutzergruppen = new SharpLibrary.WinControls.TabPageEx();
            this.lblFilterBenutzergruppen = new KiSS4.Gui.KissLabel();
            this.edtFilterBenutzergruppen = new KiSS4.Gui.KissTextEdit();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.btnAddAll = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryVerfuegbar = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colVerfuegbar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdUser = new KiSS4.Gui.KissGrid();
            this.grvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsUserAdmin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsUserBIAGAdmin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtSucheLastName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.edtSucheFirstName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheLogon = new KiSS4.Gui.KissLabel();
            this.edtSucheLogonName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheNr = new KiSS4.Gui.KissLabel();
            this.edtSucheUserID = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheOrganisationseinheit = new KiSS4.Gui.KissLabel();
            this.edtSucheAbteilung = new KiSS4.Gui.KissTextEdit();
            this.chkSucheNurAdmin = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheNurBIAGAdmin = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tabDetail.SuspendLayout();
            this.tpgSubUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySubUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSubUser)).BeginInit();
            this.tpgTexte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText1)).BeginInit();
            this.tpgPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPasswort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPasswort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonFremdkompetenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonEigenkompetenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonSprache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrantPermGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrantPermGroupID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPermissionGroupID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPermissionGroupID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsMandatsTraeger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrimaryUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonPWKontrolle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenderCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenderCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFuktion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsLocked.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonKurzzeichen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsUserBIAGAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsUserAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPrimaryUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLogonName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFunktion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLogonName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            this.tpgOrganisationseinheiten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbteilungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbteilungen)).BeginInit();
            this.tpgBenutzerrechte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRechte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRechte)).BeginInit();
            this.tpgBenutzergruppen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterBenutzergruppen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterBenutzergruppen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLogon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLogonName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrganisationseinheit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurBIAGAdmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAktive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(776, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(800, 318);
            this.tabControlSearch.TabIndex = 63;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdUser);
            this.tpgListe.Size = new System.Drawing.Size(788, 280);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.chkSucheNurAktive);
            this.tpgSuchen.Controls.Add(this.chkSucheNurBIAGAdmin);
            this.tpgSuchen.Controls.Add(this.chkSucheNurAdmin);
            this.tpgSuchen.Controls.Add(this.edtSucheAbteilung);
            this.tpgSuchen.Controls.Add(this.lblSucheOrganisationseinheit);
            this.tpgSuchen.Controls.Add(this.edtSucheUserID);
            this.tpgSuchen.Controls.Add(this.lblSucheNr);
            this.tpgSuchen.Controls.Add(this.edtSucheLogonName);
            this.tpgSuchen.Controls.Add(this.lblSucheLogon);
            this.tpgSuchen.Controls.Add(this.edtSucheFirstName);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtSucheLastName);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 280);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suchen";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLastName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFirstName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheLogon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheLogonName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheOrganisationseinheit, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAbteilung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurAdmin, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurBIAGAdmin, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurAktive, 0);
            // 
            // tabDetail
            // 
            this.tabDetail.Controls.Add(this.tpgSubUser);
            this.tabDetail.Controls.Add(this.tpgTexte);
            this.tabDetail.Controls.Add(this.tpgPerson);
            this.tabDetail.Controls.Add(this.tpgOrganisationseinheiten);
            this.tabDetail.Controls.Add(this.tpgBenutzerrechte);
            this.tabDetail.Controls.Add(this.tpgBenutzergruppen);
            this.tabDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabDetail.Location = new System.Drawing.Point(0, 318);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.ShowFixedWidthTooltip = true;
            this.tabDetail.Size = new System.Drawing.Size(800, 291);
            this.tabDetail.TabIndex = 0;
            this.tabDetail.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgPerson,
            this.tpgBenutzergruppen,
            this.tpgBenutzerrechte,
            this.tpgOrganisationseinheiten,
            this.tpgTexte,
            this.tpgSubUser});
            this.tabDetail.TabsLineColor = System.Drawing.Color.Black;
            this.tabDetail.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tpgSubUser
            // 
            this.tpgSubUser.Controls.Add(this.grdSubUser);
            this.tpgSubUser.Location = new System.Drawing.Point(6, 6);
            this.tpgSubUser.Name = "tpgSubUser";
            this.tpgSubUser.Padding = new System.Windows.Forms.Padding(6);
            this.tpgSubUser.Size = new System.Drawing.Size(788, 253);
            this.tpgSubUser.TabIndex = 5;
            this.tpgSubUser.Title = "Sub-User";
            // 
            // grdSubUser
            // 
            this.grdSubUser.DataSource = this.qrySubUser;
            this.grdSubUser.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdSubUser.EmbeddedNavigator.Name = "";
            this.grdSubUser.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdSubUser.Location = new System.Drawing.Point(6, 6);
            this.grdSubUser.MainView = this.grvSubUser;
            this.grdSubUser.Name = "grdSubUser";
            this.grdSubUser.Size = new System.Drawing.Size(776, 241);
            this.grdSubUser.TabIndex = 0;
            this.grdSubUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSubUser});
            // 
            // qrySubUser
            // 
            this.qrySubUser.HostControl = this;
            this.qrySubUser.SelectStatement = resources.GetString("qrySubUser.SelectStatement");
            // 
            // grvSubUser
            // 
            this.grvSubUser.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvSubUser.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSubUser.Appearance.Empty.Options.UseBackColor = true;
            this.grvSubUser.Appearance.Empty.Options.UseFont = true;
            this.grvSubUser.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSubUser.Appearance.EvenRow.Options.UseFont = true;
            this.grvSubUser.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSubUser.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSubUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvSubUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvSubUser.Appearance.FocusedCell.Options.UseFont = true;
            this.grvSubUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvSubUser.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSubUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSubUser.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvSubUser.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvSubUser.Appearance.FocusedRow.Options.UseFont = true;
            this.grvSubUser.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvSubUser.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSubUser.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvSubUser.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSubUser.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSubUser.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSubUser.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvSubUser.Appearance.GroupRow.Options.UseFont = true;
            this.grvSubUser.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvSubUser.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvSubUser.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvSubUser.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSubUser.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvSubUser.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvSubUser.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSubUser.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvSubUser.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSubUser.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSubUser.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvSubUser.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvSubUser.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvSubUser.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvSubUser.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvSubUser.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSubUser.Appearance.OddRow.Options.UseFont = true;
            this.grvSubUser.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvSubUser.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSubUser.Appearance.Row.Options.UseBackColor = true;
            this.grvSubUser.Appearance.Row.Options.UseFont = true;
            this.grvSubUser.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSubUser.Appearance.SelectedRow.Options.UseFont = true;
            this.grvSubUser.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvSubUser.Appearance.VertLine.Options.UseBackColor = true;
            this.grvSubUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvSubUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.colSubIsUserBIAGAdmin,
            this.gridColumn6,
            this.gridColumn7});
            this.grvSubUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvSubUser.GridControl = this.grdSubUser;
            this.grvSubUser.Name = "grvSubUser";
            this.grvSubUser.OptionsBehavior.Editable = false;
            this.grvSubUser.OptionsCustomization.AllowFilter = false;
            this.grvSubUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvSubUser.OptionsNavigation.AutoFocusNewRow = true;
            this.grvSubUser.OptionsNavigation.UseTabKey = false;
            this.grvSubUser.OptionsView.ColumnAutoWidth = false;
            this.grvSubUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvSubUser.OptionsView.ShowGroupPanel = false;
            this.grvSubUser.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nr.";
            this.gridColumn1.FieldName = "UserID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 41;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Logon";
            this.gridColumn2.FieldName = "LogonName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Name";
            this.gridColumn3.FieldName = "LastName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 125;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Vorname";
            this.gridColumn4.FieldName = "FirstName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 117;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Admin";
            this.gridColumn5.FieldName = "IsUserAdmin";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 46;
            // 
            // colSubIsUserBIAGAdmin
            // 
            this.colSubIsUserBIAGAdmin.Caption = "BIAG Admin";
            this.colSubIsUserBIAGAdmin.FieldName = "IsUserBIAGAdmin";
            this.colSubIsUserBIAGAdmin.Name = "colSubIsUserBIAGAdmin";
            this.colSubIsUserBIAGAdmin.Visible = true;
            this.colSubIsUserBIAGAdmin.VisibleIndex = 6;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Gesp.";
            this.gridColumn6.FieldName = "IsLocked";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 43;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Organisationseinheit";
            this.gridColumn7.FieldName = "Abteilung";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 150;
            // 
            // tpgTexte
            // 
            this.tpgTexte.Controls.Add(this.memText2);
            this.tpgTexte.Controls.Add(this.lblText2);
            this.tpgTexte.Controls.Add(this.memText1);
            this.tpgTexte.Controls.Add(this.lblText1);
            this.tpgTexte.Location = new System.Drawing.Point(6, 6);
            this.tpgTexte.Name = "tpgTexte";
            this.tpgTexte.Size = new System.Drawing.Size(788, 253);
            this.tpgTexte.TabIndex = 4;
            this.tpgTexte.Title = "Texte";
            // 
            // memText2
            // 
            this.memText2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memText2.BackColor = System.Drawing.Color.White;
            this.memText2.DataMember = "Text2";
            this.memText2.DataSource = this.qryUser;
            this.memText2.Font = new System.Drawing.Font("Arial", 10F);
            this.memText2.Location = new System.Drawing.Point(59, 121);
            this.memText2.Name = "memText2";
            this.memText2.Size = new System.Drawing.Size(721, 129);
            this.memText2.TabIndex = 3;
            // 
            // qryUser
            // 
            this.qryUser.CanDelete = true;
            this.qryUser.CanInsert = true;
            this.qryUser.CanUpdate = true;
            this.qryUser.HostControl = this;
            this.qryUser.TableName = "XUser";
            this.qryUser.AfterInsert += new System.EventHandler(this.qryUser_AfterInsert);
            this.qryUser.BeforePost += new System.EventHandler(this.qryUser_BeforePost);
            this.qryUser.AfterPost += new System.EventHandler(this.qryUser_AfterPost);
            this.qryUser.PositionChanged += new System.EventHandler(this.qryUser_PositionChanged);
            // 
            // lblText2
            // 
            this.lblText2.Location = new System.Drawing.Point(5, 121);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(49, 24);
            this.lblText2.TabIndex = 2;
            this.lblText2.Text = "Text 2";
            this.lblText2.UseCompatibleTextRendering = true;
            // 
            // memText1
            // 
            this.memText1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memText1.BackColor = System.Drawing.Color.White;
            this.memText1.DataMember = "Text1";
            this.memText1.DataSource = this.qryUser;
            this.memText1.Font = new System.Drawing.Font("Arial", 10F);
            this.memText1.Location = new System.Drawing.Point(60, 10);
            this.memText1.Name = "memText1";
            this.memText1.Size = new System.Drawing.Size(720, 101);
            this.memText1.TabIndex = 1;
            // 
            // lblText1
            // 
            this.lblText1.Location = new System.Drawing.Point(5, 10);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(49, 24);
            this.lblText1.TabIndex = 0;
            this.lblText1.Text = "Text 1";
            this.lblText1.UseCompatibleTextRendering = true;
            // 
            // tpgPerson
            // 
            this.tpgPerson.Controls.Add(this.edtPasswort);
            this.tpgPerson.Controls.Add(this.lblPasswort);
            this.tpgPerson.Controls.Add(this.lblUserProfile);
            this.tpgPerson.Controls.Add(this.lblPersonFremdkompetenz);
            this.tpgPerson.Controls.Add(this.lblPersonEigenkompetenz);
            this.tpgPerson.Controls.Add(this.lblPersonSprache);
            this.tpgPerson.Controls.Add(this.lblPersonGeschlecht);
            this.tpgPerson.Controls.Add(this.lblPersonEmail);
            this.tpgPerson.Controls.Add(this.lblPersonTelefon);
            this.tpgPerson.Controls.Add(this.edtSB);
            this.tpgPerson.Controls.Add(this.edtGrantPermGroupID);
            this.tpgPerson.Controls.Add(this.edtPermissionGroupID);
            this.tpgPerson.Controls.Add(this.chkIsMandatsTraeger);
            this.tpgPerson.Controls.Add(this.edtLanguageCode);
            this.tpgPerson.Controls.Add(this.lblPrimaryUser);
            this.tpgPerson.Controls.Add(this.lblPersonPWKontrolle);
            this.tpgPerson.Controls.Add(this.edtGenderCode);
            this.tpgPerson.Controls.Add(this.edtEMail);
            this.tpgPerson.Controls.Add(this.lblFuktion);
            this.tpgPerson.Controls.Add(this.edtPhone);
            this.tpgPerson.Controls.Add(this.chkIsLocked);
            this.tpgPerson.Controls.Add(this.lblPersonKurzzeichen);
            this.tpgPerson.Controls.Add(this.chkIsUserBIAGAdmin);
            this.tpgPerson.Controls.Add(this.chkIsUserAdmin);
            this.tpgPerson.Controls.Add(this.edtPrimaryUserID);
            this.tpgPerson.Controls.Add(this.lblLogonName);
            this.tpgPerson.Controls.Add(this.edtUserProfile);
            this.tpgPerson.Controls.Add(this.edtFunktion);
            this.tpgPerson.Controls.Add(this.lblPersonVorname);
            this.tpgPerson.Controls.Add(this.edtShortName);
            this.tpgPerson.Controls.Add(this.edtLogonName);
            this.tpgPerson.Controls.Add(this.lblLastName);
            this.tpgPerson.Controls.Add(this.edtFirstName);
            this.tpgPerson.Controls.Add(this.edtLastName);
            this.tpgPerson.Controls.Add(this.lblPersonNr);
            this.tpgPerson.Controls.Add(this.edtUserID);
            this.tpgPerson.Location = new System.Drawing.Point(6, 6);
            this.tpgPerson.Name = "tpgPerson";
            this.tpgPerson.Size = new System.Drawing.Size(788, 253);
            this.tpgPerson.TabIndex = 0;
            this.tpgPerson.Title = "Person";
            // 
            // edtPasswort
            // 
            this.edtPasswort.DataMember = "Password";
            this.edtPasswort.DataSource = this.qryUser;
            this.edtPasswort.Location = new System.Drawing.Point(432, 199);
            this.edtPasswort.Name = "edtPasswort";
            this.edtPasswort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPasswort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPasswort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPasswort.Properties.Appearance.Options.UseBackColor = true;
            this.edtPasswort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPasswort.Properties.Appearance.Options.UseFont = true;
            this.edtPasswort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPasswort.Properties.PasswordChar = '*';
            this.edtPasswort.Size = new System.Drawing.Size(208, 24);
            this.edtPasswort.TabIndex = 31;
            this.edtPasswort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtPasswort_KeyDown);
            // 
            // lblPasswort
            // 
            this.lblPasswort.Location = new System.Drawing.Point(329, 199);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(100, 23);
            this.lblPasswort.TabIndex = 30;
            this.lblPasswort.Text = "Temp. Passwort";
            this.lblPasswort.UseCompatibleTextRendering = true;
            // 
            // lblUserProfile
            // 
            this.lblUserProfile.Location = new System.Drawing.Point(5, 170);
            this.lblUserProfile.Name = "lblUserProfile";
            this.lblUserProfile.Size = new System.Drawing.Size(75, 24);
            this.lblUserProfile.TabIndex = 13;
            this.lblUserProfile.Text = "Userprofil";
            this.lblUserProfile.UseCompatibleTextRendering = true;
            // 
            // lblPersonFremdkompetenz
            // 
            this.lblPersonFremdkompetenz.Location = new System.Drawing.Point(329, 168);
            this.lblPersonFremdkompetenz.Name = "lblPersonFremdkompetenz";
            this.lblPersonFremdkompetenz.Size = new System.Drawing.Size(97, 24);
            this.lblPersonFremdkompetenz.TabIndex = 28;
            this.lblPersonFremdkompetenz.Text = "Fremdkompetenz";
            this.lblPersonFremdkompetenz.UseCompatibleTextRendering = true;
            // 
            // lblPersonEigenkompetenz
            // 
            this.lblPersonEigenkompetenz.Location = new System.Drawing.Point(329, 145);
            this.lblPersonEigenkompetenz.Name = "lblPersonEigenkompetenz";
            this.lblPersonEigenkompetenz.Size = new System.Drawing.Size(97, 24);
            this.lblPersonEigenkompetenz.TabIndex = 26;
            this.lblPersonEigenkompetenz.Text = "Eigenkompetenz";
            this.lblPersonEigenkompetenz.UseCompatibleTextRendering = true;
            // 
            // lblPersonSprache
            // 
            this.lblPersonSprache.Location = new System.Drawing.Point(329, 114);
            this.lblPersonSprache.Name = "lblPersonSprache";
            this.lblPersonSprache.Size = new System.Drawing.Size(97, 24);
            this.lblPersonSprache.TabIndex = 24;
            this.lblPersonSprache.Text = "Sprache";
            this.lblPersonSprache.UseCompatibleTextRendering = true;
            // 
            // lblPersonGeschlecht
            // 
            this.lblPersonGeschlecht.Location = new System.Drawing.Point(329, 91);
            this.lblPersonGeschlecht.Name = "lblPersonGeschlecht";
            this.lblPersonGeschlecht.Size = new System.Drawing.Size(97, 24);
            this.lblPersonGeschlecht.TabIndex = 22;
            this.lblPersonGeschlecht.Text = "Geschlecht";
            this.lblPersonGeschlecht.UseCompatibleTextRendering = true;
            // 
            // lblPersonEmail
            // 
            this.lblPersonEmail.Location = new System.Drawing.Point(329, 60);
            this.lblPersonEmail.Name = "lblPersonEmail";
            this.lblPersonEmail.Size = new System.Drawing.Size(97, 24);
            this.lblPersonEmail.TabIndex = 20;
            this.lblPersonEmail.Text = "EMail";
            this.lblPersonEmail.UseCompatibleTextRendering = true;
            // 
            // lblPersonTelefon
            // 
            this.lblPersonTelefon.Location = new System.Drawing.Point(329, 37);
            this.lblPersonTelefon.Name = "lblPersonTelefon";
            this.lblPersonTelefon.Size = new System.Drawing.Size(97, 24);
            this.lblPersonTelefon.TabIndex = 18;
            this.lblPersonTelefon.Text = "Telefon";
            this.lblPersonTelefon.UseCompatibleTextRendering = true;
            // 
            // edtSB
            // 
            this.edtSB.DataMember = "SB";
            this.edtSB.DataSource = this.qryUser;
            this.edtSB.Location = new System.Drawing.Point(344, 7);
            this.edtSB.Name = "edtSB";
            this.edtSB.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSB.Properties.Appearance.Options.UseBackColor = true;
            this.edtSB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSB.Properties.Appearance.Options.UseFont = true;
            this.edtSB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSB.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSB.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSB.Size = new System.Drawing.Size(69, 24);
            this.edtSB.TabIndex = 35;
            this.edtSB.Visible = false;
            this.edtSB.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSB_UserModifiedFld);
            // 
            // edtGrantPermGroupID
            // 
            this.edtGrantPermGroupID.DataMember = "GrantPermGroupID";
            this.edtGrantPermGroupID.DataSource = this.qryUser;
            this.edtGrantPermGroupID.Location = new System.Drawing.Point(432, 168);
            this.edtGrantPermGroupID.Name = "edtGrantPermGroupID";
            this.edtGrantPermGroupID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrantPermGroupID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrantPermGroupID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrantPermGroupID.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrantPermGroupID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrantPermGroupID.Properties.Appearance.Options.UseFont = true;
            this.edtGrantPermGroupID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGrantPermGroupID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrantPermGroupID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGrantPermGroupID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGrantPermGroupID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGrantPermGroupID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGrantPermGroupID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrantPermGroupID.Properties.NullText = "";
            this.edtGrantPermGroupID.Properties.ShowFooter = false;
            this.edtGrantPermGroupID.Properties.ShowHeader = false;
            this.edtGrantPermGroupID.Size = new System.Drawing.Size(208, 24);
            this.edtGrantPermGroupID.TabIndex = 29;
            this.edtGrantPermGroupID.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.edtGrantPermGroupID_QueryPopUp);
            // 
            // edtPermissionGroupID
            // 
            this.edtPermissionGroupID.DataMember = "PermissionGroupID";
            this.edtPermissionGroupID.DataSource = this.qryUser;
            this.edtPermissionGroupID.Location = new System.Drawing.Point(432, 145);
            this.edtPermissionGroupID.Name = "edtPermissionGroupID";
            this.edtPermissionGroupID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPermissionGroupID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPermissionGroupID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPermissionGroupID.Properties.Appearance.Options.UseBackColor = true;
            this.edtPermissionGroupID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPermissionGroupID.Properties.Appearance.Options.UseFont = true;
            this.edtPermissionGroupID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPermissionGroupID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPermissionGroupID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPermissionGroupID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPermissionGroupID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtPermissionGroupID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtPermissionGroupID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPermissionGroupID.Properties.NullText = "";
            this.edtPermissionGroupID.Properties.ShowFooter = false;
            this.edtPermissionGroupID.Properties.ShowHeader = false;
            this.edtPermissionGroupID.Size = new System.Drawing.Size(208, 24);
            this.edtPermissionGroupID.TabIndex = 27;
            this.edtPermissionGroupID.QueryPopUp += new System.ComponentModel.CancelEventHandler(this.edtPermissionGroupID_QueryPopUp);
            // 
            // chkIsMandatsTraeger
            // 
            this.chkIsMandatsTraeger.DataMember = "IsMandatsTraeger";
            this.chkIsMandatsTraeger.DataSource = this.qryUser;
            this.chkIsMandatsTraeger.Location = new System.Drawing.Point(163, 10);
            this.chkIsMandatsTraeger.Name = "chkIsMandatsTraeger";
            this.chkIsMandatsTraeger.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkIsMandatsTraeger.Properties.Appearance.Options.UseBackColor = true;
            this.chkIsMandatsTraeger.Properties.Caption = "Mandatsträger";
            this.chkIsMandatsTraeger.Size = new System.Drawing.Size(94, 19);
            this.chkIsMandatsTraeger.TabIndex = 2;
            this.chkIsMandatsTraeger.Visible = false;
            // 
            // edtLanguageCode
            // 
            this.edtLanguageCode.DataMember = "LanguageCode";
            this.edtLanguageCode.DataSource = this.qryUser;
            this.edtLanguageCode.Location = new System.Drawing.Point(432, 114);
            this.edtLanguageCode.LOVName = "Sprache";
            this.edtLanguageCode.Name = "edtLanguageCode";
            this.edtLanguageCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLanguageCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLanguageCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLanguageCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtLanguageCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLanguageCode.Properties.Appearance.Options.UseFont = true;
            this.edtLanguageCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtLanguageCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtLanguageCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtLanguageCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtLanguageCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtLanguageCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtLanguageCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLanguageCode.Properties.NullText = "";
            this.edtLanguageCode.Properties.ShowFooter = false;
            this.edtLanguageCode.Properties.ShowHeader = false;
            this.edtLanguageCode.Size = new System.Drawing.Size(208, 24);
            this.edtLanguageCode.TabIndex = 25;
            // 
            // lblPrimaryUser
            // 
            this.lblPrimaryUser.Location = new System.Drawing.Point(5, 199);
            this.lblPrimaryUser.Name = "lblPrimaryUser";
            this.lblPrimaryUser.Size = new System.Drawing.Size(75, 24);
            this.lblPrimaryUser.TabIndex = 15;
            this.lblPrimaryUser.Text = "Primärer User";
            this.lblPrimaryUser.UseCompatibleTextRendering = true;
            // 
            // lblPersonPWKontrolle
            // 
            this.lblPersonPWKontrolle.Location = new System.Drawing.Point(263, 7);
            this.lblPersonPWKontrolle.Name = "lblPersonPWKontrolle";
            this.lblPersonPWKontrolle.Size = new System.Drawing.Size(75, 24);
            this.lblPersonPWKontrolle.TabIndex = 34;
            this.lblPersonPWKontrolle.Text = "Vorschlag SB";
            this.lblPersonPWKontrolle.UseCompatibleTextRendering = true;
            this.lblPersonPWKontrolle.Visible = false;
            // 
            // edtGenderCode
            // 
            this.edtGenderCode.DataMember = "GenderCode";
            this.edtGenderCode.DataSource = this.qryUser;
            this.edtGenderCode.Location = new System.Drawing.Point(432, 91);
            this.edtGenderCode.LOVName = "BaGeschlecht";
            this.edtGenderCode.Name = "edtGenderCode";
            this.edtGenderCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGenderCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGenderCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGenderCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtGenderCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGenderCode.Properties.Appearance.Options.UseFont = true;
            this.edtGenderCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtGenderCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtGenderCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtGenderCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtGenderCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtGenderCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtGenderCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGenderCode.Properties.NullText = "";
            this.edtGenderCode.Properties.ShowFooter = false;
            this.edtGenderCode.Properties.ShowHeader = false;
            this.edtGenderCode.Size = new System.Drawing.Size(208, 24);
            this.edtGenderCode.TabIndex = 23;
            // 
            // edtEMail
            // 
            this.edtEMail.DataMember = "EMail";
            this.edtEMail.DataSource = this.qryUser;
            this.edtEMail.Location = new System.Drawing.Point(432, 60);
            this.edtEMail.Name = "edtEMail";
            this.edtEMail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEMail.Properties.Appearance.Options.UseFont = true;
            this.edtEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEMail.Size = new System.Drawing.Size(208, 24);
            this.edtEMail.TabIndex = 21;
            // 
            // lblFuktion
            // 
            this.lblFuktion.Location = new System.Drawing.Point(5, 143);
            this.lblFuktion.Name = "lblFuktion";
            this.lblFuktion.Size = new System.Drawing.Size(75, 24);
            this.lblFuktion.TabIndex = 11;
            this.lblFuktion.Text = "Funktion";
            this.lblFuktion.UseCompatibleTextRendering = true;
            // 
            // edtPhone
            // 
            this.edtPhone.DataMember = "Phone";
            this.edtPhone.DataSource = this.qryUser;
            this.edtPhone.Location = new System.Drawing.Point(432, 37);
            this.edtPhone.Name = "edtPhone";
            this.edtPhone.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPhone.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPhone.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPhone.Properties.Appearance.Options.UseBackColor = true;
            this.edtPhone.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPhone.Properties.Appearance.Options.UseFont = true;
            this.edtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPhone.Size = new System.Drawing.Size(208, 24);
            this.edtPhone.TabIndex = 19;
            // 
            // chkIsLocked
            // 
            this.chkIsLocked.DataMember = "IsLocked";
            this.chkIsLocked.DataSource = this.qryUser;
            this.chkIsLocked.Location = new System.Drawing.Point(432, 10);
            this.chkIsLocked.Name = "chkIsLocked";
            this.chkIsLocked.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkIsLocked.Properties.Appearance.Options.UseBackColor = true;
            this.chkIsLocked.Properties.Caption = "Gesperrt";
            this.chkIsLocked.Size = new System.Drawing.Size(92, 19);
            this.chkIsLocked.TabIndex = 17;
            // 
            // lblPersonKurzzeichen
            // 
            this.lblPersonKurzzeichen.Location = new System.Drawing.Point(5, 113);
            this.lblPersonKurzzeichen.Name = "lblPersonKurzzeichen";
            this.lblPersonKurzzeichen.Size = new System.Drawing.Size(75, 24);
            this.lblPersonKurzzeichen.TabIndex = 9;
            this.lblPersonKurzzeichen.Text = "Kurzzeichen";
            this.lblPersonKurzzeichen.UseCompatibleTextRendering = true;
            // 
            // chkIsUserBIAGAdmin
            // 
            this.chkIsUserBIAGAdmin.DataMember = "IsUserBIAGAdmin";
            this.chkIsUserBIAGAdmin.DataSource = this.qryUser;
            this.chkIsUserBIAGAdmin.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkIsUserBIAGAdmin.Location = new System.Drawing.Point(530, 229);
            this.chkIsUserBIAGAdmin.Name = "chkIsUserBIAGAdmin";
            this.chkIsUserBIAGAdmin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkIsUserBIAGAdmin.Properties.Appearance.Options.UseBackColor = true;
            this.chkIsUserBIAGAdmin.Properties.Caption = "BIAG Admin";
            this.chkIsUserBIAGAdmin.Properties.ReadOnly = true;
            this.chkIsUserBIAGAdmin.Size = new System.Drawing.Size(110, 19);
            this.chkIsUserBIAGAdmin.TabIndex = 33;
            // 
            // chkIsUserAdmin
            // 
            this.chkIsUserAdmin.DataMember = "IsUserAdmin";
            this.chkIsUserAdmin.DataSource = this.qryUser;
            this.chkIsUserAdmin.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkIsUserAdmin.Location = new System.Drawing.Point(432, 229);
            this.chkIsUserAdmin.Name = "chkIsUserAdmin";
            this.chkIsUserAdmin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkIsUserAdmin.Properties.Appearance.Options.UseBackColor = true;
            this.chkIsUserAdmin.Properties.Caption = "Administrator";
            this.chkIsUserAdmin.Properties.ReadOnly = true;
            this.chkIsUserAdmin.Size = new System.Drawing.Size(92, 19);
            this.chkIsUserAdmin.TabIndex = 32;
            // 
            // edtPrimaryUserID
            // 
            this.edtPrimaryUserID.DataMember = "PrimaryUser";
            this.edtPrimaryUserID.DataSource = this.qryUser;
            this.edtPrimaryUserID.Location = new System.Drawing.Point(86, 199);
            this.edtPrimaryUserID.Name = "edtPrimaryUserID";
            this.edtPrimaryUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPrimaryUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPrimaryUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPrimaryUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtPrimaryUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPrimaryUserID.Properties.Appearance.Options.UseFont = true;
            this.edtPrimaryUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtPrimaryUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtPrimaryUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPrimaryUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtPrimaryUserID.Size = new System.Drawing.Size(213, 24);
            this.edtPrimaryUserID.TabIndex = 16;
            this.edtPrimaryUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtPrimaryUserID_UserModifiedFld);
            // 
            // lblLogonName
            // 
            this.lblLogonName.Location = new System.Drawing.Point(5, 90);
            this.lblLogonName.Name = "lblLogonName";
            this.lblLogonName.Size = new System.Drawing.Size(75, 24);
            this.lblLogonName.TabIndex = 7;
            this.lblLogonName.Text = "Logon";
            this.lblLogonName.UseCompatibleTextRendering = true;
            // 
            // edtUserProfile
            // 
            this.edtUserProfile.DataMember = "UserProfileCode";
            this.edtUserProfile.DataSource = this.qryUser;
            this.edtUserProfile.Location = new System.Drawing.Point(86, 170);
            this.edtUserProfile.LOVName = "UserProfile";
            this.edtUserProfile.Name = "edtUserProfile";
            this.edtUserProfile.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserProfile.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserProfile.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserProfile.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserProfile.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserProfile.Properties.Appearance.Options.UseFont = true;
            this.edtUserProfile.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtUserProfile.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserProfile.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtUserProfile.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtUserProfile.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtUserProfile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtUserProfile.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserProfile.Properties.NullText = "";
            this.edtUserProfile.Properties.ShowFooter = false;
            this.edtUserProfile.Properties.ShowHeader = false;
            this.edtUserProfile.Size = new System.Drawing.Size(213, 24);
            this.edtUserProfile.TabIndex = 14;
            // 
            // edtFunktion
            // 
            this.edtFunktion.DataMember = "Funktion";
            this.edtFunktion.DataSource = this.qryUser;
            this.edtFunktion.Location = new System.Drawing.Point(86, 143);
            this.edtFunktion.Name = "edtFunktion";
            this.edtFunktion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFunktion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFunktion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFunktion.Properties.Appearance.Options.UseBackColor = true;
            this.edtFunktion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFunktion.Properties.Appearance.Options.UseFont = true;
            this.edtFunktion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFunktion.Size = new System.Drawing.Size(213, 24);
            this.edtFunktion.TabIndex = 12;
            // 
            // lblPersonVorname
            // 
            this.lblPersonVorname.Location = new System.Drawing.Point(5, 60);
            this.lblPersonVorname.Name = "lblPersonVorname";
            this.lblPersonVorname.Size = new System.Drawing.Size(75, 24);
            this.lblPersonVorname.TabIndex = 5;
            this.lblPersonVorname.Text = "Vorname";
            this.lblPersonVorname.UseCompatibleTextRendering = true;
            // 
            // edtShortName
            // 
            this.edtShortName.DataMember = "ShortName";
            this.edtShortName.DataSource = this.qryUser;
            this.edtShortName.Location = new System.Drawing.Point(86, 113);
            this.edtShortName.Name = "edtShortName";
            this.edtShortName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtShortName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtShortName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtShortName.Properties.Appearance.Options.UseBackColor = true;
            this.edtShortName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtShortName.Properties.Appearance.Options.UseFont = true;
            this.edtShortName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtShortName.Size = new System.Drawing.Size(72, 24);
            this.edtShortName.TabIndex = 10;
            // 
            // edtLogonName
            // 
            this.edtLogonName.DataMember = "LogonName";
            this.edtLogonName.DataSource = this.qryUser;
            this.edtLogonName.Location = new System.Drawing.Point(86, 90);
            this.edtLogonName.Name = "edtLogonName";
            this.edtLogonName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLogonName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLogonName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLogonName.Properties.Appearance.Options.UseBackColor = true;
            this.edtLogonName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLogonName.Properties.Appearance.Options.UseFont = true;
            this.edtLogonName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLogonName.Size = new System.Drawing.Size(213, 24);
            this.edtLogonName.TabIndex = 8;
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(5, 37);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(75, 24);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Name";
            this.lblLastName.UseCompatibleTextRendering = true;
            // 
            // edtFirstName
            // 
            this.edtFirstName.DataMember = "FirstName";
            this.edtFirstName.DataSource = this.qryUser;
            this.edtFirstName.Location = new System.Drawing.Point(86, 60);
            this.edtFirstName.Name = "edtFirstName";
            this.edtFirstName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFirstName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFirstName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFirstName.Properties.Appearance.Options.UseBackColor = true;
            this.edtFirstName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFirstName.Properties.Appearance.Options.UseFont = true;
            this.edtFirstName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFirstName.Size = new System.Drawing.Size(213, 24);
            this.edtFirstName.TabIndex = 6;
            // 
            // edtLastName
            // 
            this.edtLastName.DataMember = "LastName";
            this.edtLastName.DataSource = this.qryUser;
            this.edtLastName.Location = new System.Drawing.Point(86, 37);
            this.edtLastName.Name = "edtLastName";
            this.edtLastName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLastName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLastName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLastName.Properties.Appearance.Options.UseBackColor = true;
            this.edtLastName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLastName.Properties.Appearance.Options.UseFont = true;
            this.edtLastName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLastName.Size = new System.Drawing.Size(213, 24);
            this.edtLastName.TabIndex = 4;
            // 
            // lblPersonNr
            // 
            this.lblPersonNr.Location = new System.Drawing.Point(5, 7);
            this.lblPersonNr.Name = "lblPersonNr";
            this.lblPersonNr.Size = new System.Drawing.Size(75, 24);
            this.lblPersonNr.TabIndex = 0;
            this.lblPersonNr.Text = "Nr.";
            this.lblPersonNr.UseCompatibleTextRendering = true;
            // 
            // edtUserID
            // 
            this.edtUserID.DataMember = "UserID";
            this.edtUserID.DataSource = this.qryUser;
            this.edtUserID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtUserID.Location = new System.Drawing.Point(86, 7);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Properties.ReadOnly = true;
            this.edtUserID.Size = new System.Drawing.Size(71, 24);
            this.edtUserID.TabIndex = 1;
            // 
            // tpgOrganisationseinheiten
            // 
            this.tpgOrganisationseinheiten.Controls.Add(this.grdAbteilungen);
            this.tpgOrganisationseinheiten.Location = new System.Drawing.Point(6, 6);
            this.tpgOrganisationseinheiten.Name = "tpgOrganisationseinheiten";
            this.tpgOrganisationseinheiten.Padding = new System.Windows.Forms.Padding(6);
            this.tpgOrganisationseinheiten.Size = new System.Drawing.Size(788, 253);
            this.tpgOrganisationseinheiten.TabIndex = 0;
            this.tpgOrganisationseinheiten.Title = "Organisationseinheiten";
            // 
            // grdAbteilungen
            // 
            this.grdAbteilungen.DataSource = this.qryAbteilung;
            this.grdAbteilungen.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdAbteilungen.EmbeddedNavigator.Name = "";
            this.grdAbteilungen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAbteilungen.Location = new System.Drawing.Point(6, 6);
            this.grdAbteilungen.MainView = this.grvAbteilungen;
            this.grdAbteilungen.Name = "grdAbteilungen";
            this.grdAbteilungen.Size = new System.Drawing.Size(776, 241);
            this.grdAbteilungen.TabIndex = 0;
            this.grdAbteilungen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAbteilungen});
            // 
            // qryAbteilung
            // 
            this.qryAbteilung.HostControl = this;
            this.qryAbteilung.SelectStatement = resources.GetString("qryAbteilung.SelectStatement");
            // 
            // grvAbteilungen
            // 
            this.grvAbteilungen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAbteilungen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.Empty.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.Empty.Options.UseFont = true;
            this.grvAbteilungen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.EvenRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAbteilungen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAbteilungen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAbteilungen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAbteilungen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAbteilungen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAbteilungen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAbteilungen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAbteilungen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAbteilungen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAbteilungen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.GroupRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAbteilungen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAbteilungen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAbteilungen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAbteilungen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAbteilungen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAbteilungen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAbteilungen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAbteilungen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAbteilungen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.OddRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAbteilungen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.Row.Options.UseBackColor = true;
            this.grvAbteilungen.Appearance.Row.Options.UseFont = true;
            this.grvAbteilungen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbteilungen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAbteilungen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAbteilungen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAbteilungen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAbteilungen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrganisationseinheit,
            this.colFunktion,
            this.colMayInsert,
            this.colMayUpdate,
            this.colMayDelete});
            this.grvAbteilungen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAbteilungen.GridControl = this.grdAbteilungen;
            this.grvAbteilungen.Name = "grvAbteilungen";
            this.grvAbteilungen.OptionsBehavior.Editable = false;
            this.grvAbteilungen.OptionsCustomization.AllowFilter = false;
            this.grvAbteilungen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAbteilungen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAbteilungen.OptionsNavigation.UseTabKey = false;
            this.grvAbteilungen.OptionsView.ColumnAutoWidth = false;
            this.grvAbteilungen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAbteilungen.OptionsView.ShowGroupPanel = false;
            this.grvAbteilungen.OptionsView.ShowIndicator = false;
            // 
            // colOrganisationseinheit
            // 
            this.colOrganisationseinheit.Caption = "Organisationseinheit";
            this.colOrganisationseinheit.FieldName = "Abteilung";
            this.colOrganisationseinheit.Name = "colOrganisationseinheit";
            this.colOrganisationseinheit.Visible = true;
            this.colOrganisationseinheit.VisibleIndex = 0;
            this.colOrganisationseinheit.Width = 243;
            // 
            // colFunktion
            // 
            this.colFunktion.Caption = "Funktion";
            this.colFunktion.FieldName = "Funktion";
            this.colFunktion.Name = "colFunktion";
            this.colFunktion.Visible = true;
            this.colFunktion.VisibleIndex = 1;
            // 
            // colMayInsert
            // 
            this.colMayInsert.Caption = "E";
            this.colMayInsert.FieldName = "MayInsert";
            this.colMayInsert.Name = "colMayInsert";
            this.colMayInsert.Visible = true;
            this.colMayInsert.VisibleIndex = 2;
            this.colMayInsert.Width = 20;
            // 
            // colMayUpdate
            // 
            this.colMayUpdate.Caption = "M";
            this.colMayUpdate.FieldName = "MayUpdate";
            this.colMayUpdate.Name = "colMayUpdate";
            this.colMayUpdate.Visible = true;
            this.colMayUpdate.VisibleIndex = 3;
            this.colMayUpdate.Width = 20;
            // 
            // colMayDelete
            // 
            this.colMayDelete.Caption = "L";
            this.colMayDelete.FieldName = "MayDelete";
            this.colMayDelete.Name = "colMayDelete";
            this.colMayDelete.Visible = true;
            this.colMayDelete.VisibleIndex = 4;
            this.colMayDelete.Width = 20;
            // 
            // tpgBenutzerrechte
            // 
            this.tpgBenutzerrechte.Controls.Add(this.grdRechte);
            this.tpgBenutzerrechte.Location = new System.Drawing.Point(6, 6);
            this.tpgBenutzerrechte.Name = "tpgBenutzerrechte";
            this.tpgBenutzerrechte.Padding = new System.Windows.Forms.Padding(6);
            this.tpgBenutzerrechte.Size = new System.Drawing.Size(788, 253);
            this.tpgBenutzerrechte.TabIndex = 0;
            this.tpgBenutzerrechte.Title = "Benutzerrechte";
            // 
            // grdRechte
            // 
            this.grdRechte.DataSource = this.qryUserRight;
            this.grdRechte.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdRechte.EmbeddedNavigator.Name = "";
            this.grdRechte.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdRechte.Location = new System.Drawing.Point(6, 6);
            this.grdRechte.MainView = this.grvRechte;
            this.grdRechte.Name = "grdRechte";
            this.grdRechte.Size = new System.Drawing.Size(776, 241);
            this.grdRechte.TabIndex = 0;
            this.grdRechte.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRechte});
            // 
            // qryUserRight
            // 
            this.qryUserRight.SelectStatement = resources.GetString("qryUserRight.SelectStatement");
            // 
            // grvRechte
            // 
            this.grvRechte.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvRechte.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.Empty.Options.UseBackColor = true;
            this.grvRechte.Appearance.Empty.Options.UseFont = true;
            this.grvRechte.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.EvenRow.Options.UseFont = true;
            this.grvRechte.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRechte.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvRechte.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvRechte.Appearance.FocusedCell.Options.UseFont = true;
            this.grvRechte.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvRechte.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRechte.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvRechte.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvRechte.Appearance.FocusedRow.Options.UseFont = true;
            this.grvRechte.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvRechte.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRechte.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvRechte.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRechte.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRechte.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvRechte.Appearance.GroupRow.Options.UseFont = true;
            this.grvRechte.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvRechte.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvRechte.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvRechte.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvRechte.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvRechte.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRechte.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvRechte.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRechte.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvRechte.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvRechte.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvRechte.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvRechte.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvRechte.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.OddRow.Options.UseFont = true;
            this.grvRechte.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvRechte.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.Row.Options.UseBackColor = true;
            this.grvRechte.Appearance.Row.Options.UseFont = true;
            this.grvRechte.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRechte.Appearance.SelectedRow.Options.UseFont = true;
            this.grvRechte.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvRechte.Appearance.VertLine.Options.UseBackColor = true;
            this.grvRechte.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvRechte.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRecht,
            this.colRechtE,
            this.colRechtM,
            this.colRechtL});
            this.grvRechte.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRechte.GridControl = this.grdRechte;
            this.grvRechte.Name = "grvRechte";
            this.grvRechte.OptionsBehavior.Editable = false;
            this.grvRechte.OptionsCustomization.AllowFilter = false;
            this.grvRechte.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvRechte.OptionsNavigation.AutoFocusNewRow = true;
            this.grvRechte.OptionsNavigation.UseTabKey = false;
            this.grvRechte.OptionsView.ColumnAutoWidth = false;
            this.grvRechte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRechte.OptionsView.ShowGroupPanel = false;
            this.grvRechte.OptionsView.ShowIndicator = false;
            // 
            // colRecht
            // 
            this.colRecht.Caption = "Recht";
            this.colRecht.FieldName = "UserText";
            this.colRecht.Name = "colRecht";
            this.colRecht.Visible = true;
            this.colRecht.VisibleIndex = 0;
            this.colRecht.Width = 400;
            // 
            // colRechtE
            // 
            this.colRechtE.Caption = "E";
            this.colRechtE.FieldName = "MayInsert";
            this.colRechtE.Name = "colRechtE";
            this.colRechtE.Visible = true;
            this.colRechtE.VisibleIndex = 1;
            this.colRechtE.Width = 20;
            // 
            // colRechtM
            // 
            this.colRechtM.Caption = "M";
            this.colRechtM.FieldName = "MayUpdate";
            this.colRechtM.Name = "colRechtM";
            this.colRechtM.Visible = true;
            this.colRechtM.VisibleIndex = 2;
            this.colRechtM.Width = 20;
            // 
            // colRechtL
            // 
            this.colRechtL.Caption = "L";
            this.colRechtL.FieldName = "MayDelete";
            this.colRechtL.Name = "colRechtL";
            this.colRechtL.Visible = true;
            this.colRechtL.VisibleIndex = 3;
            this.colRechtL.Width = 20;
            // 
            // tpgBenutzergruppen
            // 
            this.tpgBenutzergruppen.Controls.Add(this.lblFilterBenutzergruppen);
            this.tpgBenutzergruppen.Controls.Add(this.edtFilterBenutzergruppen);
            this.tpgBenutzergruppen.Controls.Add(this.grdZugeteilt);
            this.tpgBenutzergruppen.Controls.Add(this.btnRemoveAll);
            this.tpgBenutzergruppen.Controls.Add(this.btnAddAll);
            this.tpgBenutzergruppen.Controls.Add(this.btnRemove);
            this.tpgBenutzergruppen.Controls.Add(this.btnAdd);
            this.tpgBenutzergruppen.Controls.Add(this.grdVerfuegbar);
            this.tpgBenutzergruppen.Location = new System.Drawing.Point(6, 6);
            this.tpgBenutzergruppen.Name = "tpgBenutzergruppen";
            this.tpgBenutzergruppen.Size = new System.Drawing.Size(788, 253);
            this.tpgBenutzergruppen.TabIndex = 0;
            this.tpgBenutzergruppen.Title = "Benutzergruppen";
            // 
            // lblFilterBenutzergruppen
            // 
            this.lblFilterBenutzergruppen.Location = new System.Drawing.Point(9, 226);
            this.lblFilterBenutzergruppen.Name = "lblFilterBenutzergruppen";
            this.lblFilterBenutzergruppen.Size = new System.Drawing.Size(50, 24);
            this.lblFilterBenutzergruppen.TabIndex = 7;
            this.lblFilterBenutzergruppen.Text = "Filter";
            // 
            // edtFilterBenutzergruppen
            // 
            this.edtFilterBenutzergruppen.Location = new System.Drawing.Point(65, 226);
            this.edtFilterBenutzergruppen.Name = "edtFilterBenutzergruppen";
            this.edtFilterBenutzergruppen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterBenutzergruppen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterBenutzergruppen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterBenutzergruppen.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterBenutzergruppen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterBenutzergruppen.Properties.Appearance.Options.UseFont = true;
            this.edtFilterBenutzergruppen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterBenutzergruppen.Size = new System.Drawing.Size(247, 24);
            this.edtFilterBenutzergruppen.TabIndex = 6;
            this.edtFilterBenutzergruppen.EditValueChanged += new System.EventHandler(this.edtFilterBenutzergruppen_EditValueChanged);
            // 
            // grdZugeteilt
            // 
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            // 
            // 
            // 
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZugeteilt.Location = new System.Drawing.Point(372, 10);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(300, 240);
            this.grdZugeteilt.TabIndex = 5;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugeteilt});
            this.grdZugeteilt.DoubleClick += new System.EventHandler(this.grdZugeteilt_DoubleClick);
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.SelectStatement = "SELECT UUG.*, UGR.UserGroupName\r\nFROM dbo.XUser_UserGroup    UUG\r\n  INNER JOIN db" +
    "o.XUserGroup UGR ON UGR.UserGroupID = UUG.UserGroupID\r\nWHERE UUG.UserID = {0}\r\nO" +
    "RDER BY UserGroupName;";
            this.qryZugeteilt.TableName = "XUser_UserGroup";
            // 
            // grvZugeteilt
            // 
            this.grvZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZugeteilt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Empty.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Empty.Options.UseFont = true;
            this.grvZugeteilt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.EvenRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugeteilt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZugeteilt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZugeteilt.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZugeteilt.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZugeteilt.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.OddRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Row.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Row.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZugeteilt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUser});
            this.grvZugeteilt.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZugeteilt.GridControl = this.grdZugeteilt;
            this.grvZugeteilt.Name = "grvZugeteilt";
            this.grvZugeteilt.OptionsBehavior.Editable = false;
            this.grvZugeteilt.OptionsCustomization.AllowFilter = false;
            this.grvZugeteilt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZugeteilt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZugeteilt.OptionsNavigation.UseTabKey = false;
            this.grvZugeteilt.OptionsView.ColumnAutoWidth = false;
            this.grvZugeteilt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZugeteilt.OptionsView.ShowGroupPanel = false;
            this.grvZugeteilt.OptionsView.ShowIndicator = false;
            // 
            // colUser
            // 
            this.colUser.Caption = "Zugeteilte Gruppen";
            this.colUser.FieldName = "UserGroupName";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 0;
            this.colUser.Width = 243;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(328, 135);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 4;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAll.IconID = 14;
            this.btnAddAll.Location = new System.Drawing.Point(328, 105);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(28, 24);
            this.btnAddAll.TabIndex = 3;
            this.btnAddAll.UseCompatibleTextRendering = true;
            this.btnAddAll.UseVisualStyleBackColor = false;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(328, 75);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(328, 45);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grdVerfuegbar
            // 
            this.grdVerfuegbar.DataSource = this.qryVerfuegbar;
            // 
            // 
            // 
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerfuegbar.Location = new System.Drawing.Point(12, 10);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(300, 210);
            this.grdVerfuegbar.TabIndex = 0;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfuegbar});
            this.grdVerfuegbar.DoubleClick += new System.EventHandler(this.grdVerfuegbar_DoubleClick);
            // 
            // qryVerfuegbar
            // 
            this.qryVerfuegbar.HostControl = this;
            this.qryVerfuegbar.SelectStatement = resources.GetString("qryVerfuegbar.SelectStatement");
            // 
            // grvVerfuegbar
            // 
            this.grvVerfuegbar.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVerfuegbar.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Empty.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Empty.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.EvenRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerfuegbar.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerfuegbar.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVerfuegbar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVerfuegbar.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVerfuegbar.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.OddRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVerfuegbar.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.Row.Options.UseBackColor = true;
            this.grvVerfuegbar.Appearance.Row.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerfuegbar.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVerfuegbar.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerfuegbar.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVerfuegbar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVerfuegbar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colVerfuegbar,
            this.colUserGroupID});
            this.grvVerfuegbar.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerfuegbar.GridControl = this.grdVerfuegbar;
            this.grvVerfuegbar.Name = "grvVerfuegbar";
            this.grvVerfuegbar.OptionsBehavior.Editable = false;
            this.grvVerfuegbar.OptionsCustomization.AllowFilter = false;
            this.grvVerfuegbar.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerfuegbar.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerfuegbar.OptionsNavigation.UseTabKey = false;
            this.grvVerfuegbar.OptionsSelection.MultiSelect = true;
            this.grvVerfuegbar.OptionsView.ColumnAutoWidth = false;
            this.grvVerfuegbar.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVerfuegbar.OptionsView.ShowGroupPanel = false;
            this.grvVerfuegbar.OptionsView.ShowIndicator = false;
            // 
            // colVerfuegbar
            // 
            this.colVerfuegbar.Caption = "Verfügbare Gruppen";
            this.colVerfuegbar.FieldName = "UserGroupName";
            this.colVerfuegbar.Name = "colVerfuegbar";
            this.colVerfuegbar.Visible = true;
            this.colVerfuegbar.VisibleIndex = 0;
            this.colVerfuegbar.Width = 243;
            // 
            // colUserGroupID
            // 
            this.colUserGroupID.Caption = "-";
            this.colUserGroupID.FieldName = "UserGroupID";
            this.colUserGroupID.Name = "colUserGroupID";
            // 
            // grdUser
            // 
            this.grdUser.DataSource = this.qryUser;
            this.grdUser.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdUser.EmbeddedNavigator.Name = "";
            this.grdUser.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdUser.Location = new System.Drawing.Point(0, 0);
            this.grdUser.MainView = this.grvUser;
            this.grdUser.Name = "grdUser";
            this.grdUser.Size = new System.Drawing.Size(788, 280);
            this.grdUser.TabIndex = 1;
            this.grdUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUser});
            // 
            // grvUser
            // 
            this.grvUser.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvUser.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.Empty.Options.UseBackColor = true;
            this.grvUser.Appearance.Empty.Options.UseFont = true;
            this.grvUser.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.EvenRow.Options.UseFont = true;
            this.grvUser.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUser.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvUser.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvUser.Appearance.FocusedCell.Options.UseFont = true;
            this.grvUser.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvUser.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvUser.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvUser.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvUser.Appearance.FocusedRow.Options.UseFont = true;
            this.grvUser.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvUser.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUser.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvUser.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvUser.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvUser.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUser.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvUser.Appearance.GroupRow.Options.UseFont = true;
            this.grvUser.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvUser.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvUser.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvUser.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvUser.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvUser.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvUser.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvUser.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvUser.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvUser.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvUser.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvUser.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvUser.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvUser.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvUser.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.OddRow.Options.UseFont = true;
            this.grvUser.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvUser.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.Row.Options.UseBackColor = true;
            this.grvUser.Appearance.Row.Options.UseFont = true;
            this.grvUser.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvUser.Appearance.SelectedRow.Options.UseFont = true;
            this.grvUser.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvUser.Appearance.VertLine.Options.UseBackColor = true;
            this.grvUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colLogonName,
            this.colLastName,
            this.colFirstName,
            this.colIsUserAdmin,
            this.colIsUserBIAGAdmin,
            this.colIsLocked,
            this.colOrgUnit});
            this.grvUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvUser.GridControl = this.grdUser;
            this.grvUser.Name = "grvUser";
            this.grvUser.OptionsBehavior.Editable = false;
            this.grvUser.OptionsCustomization.AllowFilter = false;
            this.grvUser.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvUser.OptionsNavigation.AutoFocusNewRow = true;
            this.grvUser.OptionsNavigation.UseTabKey = false;
            this.grvUser.OptionsView.ColumnAutoWidth = false;
            this.grvUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvUser.OptionsView.ShowGroupPanel = false;
            this.grvUser.OptionsView.ShowIndicator = false;
            // 
            // colUserID
            // 
            this.colUserID.Caption = "Nr.";
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 0;
            this.colUserID.Width = 48;
            // 
            // colLogonName
            // 
            this.colLogonName.Caption = "Logon";
            this.colLogonName.FieldName = "LogonName";
            this.colLogonName.Name = "colLogonName";
            this.colLogonName.Visible = true;
            this.colLogonName.VisibleIndex = 1;
            this.colLogonName.Width = 68;
            // 
            // colLastName
            // 
            this.colLastName.Caption = "Name";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 2;
            this.colLastName.Width = 148;
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "Vorname";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 3;
            this.colFirstName.Width = 122;
            // 
            // colIsUserAdmin
            // 
            this.colIsUserAdmin.Caption = "Admin";
            this.colIsUserAdmin.FieldName = "IsUserAdmin";
            this.colIsUserAdmin.Name = "colIsUserAdmin";
            this.colIsUserAdmin.Visible = true;
            this.colIsUserAdmin.VisibleIndex = 5;
            this.colIsUserAdmin.Width = 50;
            // 
            // colIsUserBIAGAdmin
            // 
            this.colIsUserBIAGAdmin.Caption = "BIAG Admin";
            this.colIsUserBIAGAdmin.FieldName = "IsUserBIAGAdmin";
            this.colIsUserBIAGAdmin.Name = "colIsUserBIAGAdmin";
            this.colIsUserBIAGAdmin.Visible = true;
            this.colIsUserBIAGAdmin.VisibleIndex = 6;
            // 
            // colIsLocked
            // 
            this.colIsLocked.Caption = "Gesp.";
            this.colIsLocked.FieldName = "IsLocked";
            this.colIsLocked.Name = "colIsLocked";
            this.colIsLocked.Visible = true;
            this.colIsLocked.VisibleIndex = 4;
            this.colIsLocked.Width = 50;
            // 
            // colOrgUnit
            // 
            this.colOrgUnit.Caption = "Organisationseinheit";
            this.colOrgUnit.FieldName = "Abteilung";
            this.colOrgUnit.Name = "colOrgUnit";
            this.colOrgUnit.Visible = true;
            this.colOrgUnit.VisibleIndex = 7;
            this.colOrgUnit.Width = 127;
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(10, 34);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(114, 24);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            // 
            // edtSucheLastName
            // 
            this.edtSucheLastName.Location = new System.Drawing.Point(129, 34);
            this.edtSucheLastName.Name = "edtSucheLastName";
            this.edtSucheLastName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLastName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLastName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLastName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLastName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLastName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLastName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheLastName.Size = new System.Drawing.Size(172, 24);
            this.edtSucheLastName.TabIndex = 2;
            // 
            // lblSucheVorname
            // 
            this.lblSucheVorname.Location = new System.Drawing.Point(10, 64);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(114, 24);
            this.lblSucheVorname.TabIndex = 3;
            this.lblSucheVorname.Text = "Vorname";
            this.lblSucheVorname.UseCompatibleTextRendering = true;
            // 
            // edtSucheFirstName
            // 
            this.edtSucheFirstName.Location = new System.Drawing.Point(129, 64);
            this.edtSucheFirstName.Name = "edtSucheFirstName";
            this.edtSucheFirstName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFirstName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFirstName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFirstName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFirstName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFirstName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFirstName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheFirstName.Size = new System.Drawing.Size(172, 24);
            this.edtSucheFirstName.TabIndex = 4;
            // 
            // lblSucheLogon
            // 
            this.lblSucheLogon.Location = new System.Drawing.Point(9, 94);
            this.lblSucheLogon.Name = "lblSucheLogon";
            this.lblSucheLogon.Size = new System.Drawing.Size(114, 24);
            this.lblSucheLogon.TabIndex = 5;
            this.lblSucheLogon.Text = "Logon";
            this.lblSucheLogon.UseCompatibleTextRendering = true;
            // 
            // edtSucheLogonName
            // 
            this.edtSucheLogonName.Location = new System.Drawing.Point(129, 94);
            this.edtSucheLogonName.Name = "edtSucheLogonName";
            this.edtSucheLogonName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheLogonName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheLogonName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheLogonName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheLogonName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheLogonName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheLogonName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheLogonName.Size = new System.Drawing.Size(72, 24);
            this.edtSucheLogonName.TabIndex = 6;
            // 
            // lblSucheNr
            // 
            this.lblSucheNr.Location = new System.Drawing.Point(9, 124);
            this.lblSucheNr.Name = "lblSucheNr";
            this.lblSucheNr.Size = new System.Drawing.Size(114, 24);
            this.lblSucheNr.TabIndex = 7;
            this.lblSucheNr.Text = "Nr.";
            this.lblSucheNr.UseCompatibleTextRendering = true;
            // 
            // edtSucheUserID
            // 
            this.edtSucheUserID.Location = new System.Drawing.Point(129, 124);
            this.edtSucheUserID.Name = "edtSucheUserID";
            this.edtSucheUserID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheUserID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheUserID.Size = new System.Drawing.Size(71, 24);
            this.edtSucheUserID.TabIndex = 8;
            // 
            // lblSucheOrganisationseinheit
            // 
            this.lblSucheOrganisationseinheit.Location = new System.Drawing.Point(9, 154);
            this.lblSucheOrganisationseinheit.Name = "lblSucheOrganisationseinheit";
            this.lblSucheOrganisationseinheit.Size = new System.Drawing.Size(114, 24);
            this.lblSucheOrganisationseinheit.TabIndex = 9;
            this.lblSucheOrganisationseinheit.Text = "Organisationseinheit";
            this.lblSucheOrganisationseinheit.UseCompatibleTextRendering = true;
            // 
            // edtSucheAbteilung
            // 
            this.edtSucheAbteilung.Location = new System.Drawing.Point(129, 154);
            this.edtSucheAbteilung.Name = "edtSucheAbteilung";
            this.edtSucheAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAbteilung.Size = new System.Drawing.Size(172, 24);
            this.edtSucheAbteilung.TabIndex = 10;
            // 
            // chkSucheNurAdmin
            // 
            this.chkSucheNurAdmin.EditValue = false;
            this.chkSucheNurAdmin.Location = new System.Drawing.Point(129, 209);
            this.chkSucheNurAdmin.Name = "chkSucheNurAdmin";
            this.chkSucheNurAdmin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheNurAdmin.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurAdmin.Properties.Caption = "Nur Administratoren";
            this.chkSucheNurAdmin.Size = new System.Drawing.Size(172, 19);
            this.chkSucheNurAdmin.TabIndex = 13;
            // 
            // chkSucheNurBIAGAdmin
            // 
            this.chkSucheNurBIAGAdmin.EditValue = false;
            this.chkSucheNurBIAGAdmin.Location = new System.Drawing.Point(129, 234);
            this.chkSucheNurBIAGAdmin.Name = "chkSucheNurBIAGAdmin";
            this.chkSucheNurBIAGAdmin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheNurBIAGAdmin.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurBIAGAdmin.Properties.Caption = "Nur BIAG Administratoren";
            this.chkSucheNurBIAGAdmin.Size = new System.Drawing.Size(172, 19);
            this.chkSucheNurBIAGAdmin.TabIndex = 14;
            // 
            // chkSucheNurAktive
            // 
            this.chkSucheNurAktive.EditValue = true;
            this.chkSucheNurAktive.Location = new System.Drawing.Point(129, 184);
            this.chkSucheNurAktive.Name = "chkSucheNurAktive";
            this.chkSucheNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurAktive.Properties.Caption = "Nur aktive Benutzer";
            this.chkSucheNurAktive.Size = new System.Drawing.Size(172, 19);
            this.chkSucheNurAktive.TabIndex = 15;
            // 
            // CtlUser
            // 
            this.ActiveSQLQuery = this.qryUser;
            this.Controls.Add(this.tabDetail);
            this.Name = "CtlUser";
            this.Size = new System.Drawing.Size(800, 609);
            this.Load += new System.EventHandler(this.CtlUser_Load);
            this.Controls.SetChildIndex(this.tabDetail, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.tabDetail.ResumeLayout(false);
            this.tpgSubUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSubUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySubUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSubUser)).EndInit();
            this.tpgTexte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText1)).EndInit();
            this.tpgPerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPasswort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPasswort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonFremdkompetenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonEigenkompetenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonSprache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrantPermGroupID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrantPermGroupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPermissionGroupID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPermissionGroupID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsMandatsTraeger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanguageCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPrimaryUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonPWKontrolle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenderCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenderCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFuktion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsLocked.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonKurzzeichen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsUserBIAGAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsUserAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPrimaryUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLogonName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFunktion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLogonName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            this.tpgOrganisationseinheiten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAbteilungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbteilungen)).EndInit();
            this.tpgBenutzerrechte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRechte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUserRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRechte)).EndInit();
            this.tpgBenutzergruppen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterBenutzergruppen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterBenutzergruppen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheLogon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheLogonName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheOrganisationseinheit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurBIAGAdmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurAktive.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAdd;
        private KiSS4.Gui.KissButton btnAddAll;
        private KiSS4.Gui.KissButton btnRemove;
        private KiSS4.Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissCheckEdit chkIsLocked;
        private KiSS4.Gui.KissCheckEdit chkIsMandatsTraeger;
        private KiSS4.Gui.KissCheckEdit chkIsUserAdmin;
        private KiSS4.Gui.KissCheckEdit chkIsUserBIAGAdmin;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colFunktion;
        private DevExpress.XtraGrid.Columns.GridColumn colIsLocked;
        private DevExpress.XtraGrid.Columns.GridColumn colIsUserAdmin;
        private DevExpress.XtraGrid.Columns.GridColumn colIsUserBIAGAdmin;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colLogonName;
        private DevExpress.XtraGrid.Columns.GridColumn colMayDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colMayInsert;
        private DevExpress.XtraGrid.Columns.GridColumn colMayUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colOrganisationseinheit;
        private DevExpress.XtraGrid.Columns.GridColumn colRecht;
        private DevExpress.XtraGrid.Columns.GridColumn colRechtE;
        private DevExpress.XtraGrid.Columns.GridColumn colRechtL;
        private DevExpress.XtraGrid.Columns.GridColumn colRechtM;
        private DevExpress.XtraGrid.Columns.GridColumn colSubIsUserBIAGAdmin;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colVerfuegbar;
        private KiSS4.Gui.KissTextEdit edtEMail;
        private KiSS4.Gui.KissTextEdit edtFirstName;
        private KiSS4.Gui.KissTextEdit edtFunktion;
        private KiSS4.Gui.KissLookUpEdit edtGenderCode;
        private KiSS4.Gui.KissLookUpEdit edtGrantPermGroupID;
        private KiSS4.Gui.KissLookUpEdit edtLanguageCode;
        private KiSS4.Gui.KissTextEdit edtLastName;
        private KiSS4.Gui.KissTextEdit edtLogonName;
        private KiSS4.Gui.KissTextEdit edtPasswort;
        private KiSS4.Gui.KissLookUpEdit edtPermissionGroupID;
        private KiSS4.Gui.KissTextEdit edtPhone;
        private KiSS4.Gui.KissButtonEdit edtPrimaryUserID;
        private KiSS4.Gui.KissButtonEdit edtSB;
        private KiSS4.Gui.KissTextEdit edtShortName;
        private KiSS4.Gui.KissTextEdit edtSucheAbteilung;
        private KiSS4.Gui.KissTextEdit edtSucheFirstName;
        private KiSS4.Gui.KissTextEdit edtSucheLastName;
        private KiSS4.Gui.KissTextEdit edtSucheLogonName;
        private KiSS4.Gui.KissCalcEdit edtSucheUserID;
        private KiSS4.Gui.KissCalcEdit edtUserID;
        private KiSS4.Gui.KissLookUpEdit edtUserProfile;
        private KiSS4.Gui.KissGrid grdAbteilungen;
        private KiSS4.Gui.KissGrid grdRechte;
        private KiSS4.Gui.KissGrid grdSubUser;
        private KiSS4.Gui.KissGrid grdUser;
        private KiSS4.Gui.KissGrid grdVerfuegbar;
        private KiSS4.Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAbteilungen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRechte;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSubUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private KiSS4.Gui.KissLabel lblFuktion;
        private KiSS4.Gui.KissLabel lblLastName;
        private KiSS4.Gui.KissLabel lblLogonName;
        private KiSS4.Gui.KissLabel lblPasswort;
        private KiSS4.Gui.KissLabel lblPersonEigenkompetenz;
        private KiSS4.Gui.KissLabel lblPersonEmail;
        private KiSS4.Gui.KissLabel lblPersonFremdkompetenz;
        private KiSS4.Gui.KissLabel lblPersonGeschlecht;
        private KiSS4.Gui.KissLabel lblPersonKurzzeichen;
        private KiSS4.Gui.KissLabel lblPersonNr;
        private KiSS4.Gui.KissLabel lblPersonPWKontrolle;
        private KiSS4.Gui.KissLabel lblPersonSprache;
        private KiSS4.Gui.KissLabel lblPersonTelefon;
        private KiSS4.Gui.KissLabel lblPersonVorname;
        private KiSS4.Gui.KissLabel lblPrimaryUser;
        private KiSS4.Gui.KissLabel lblSucheLogon;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSucheNr;
        private KiSS4.Gui.KissLabel lblSucheOrganisationseinheit;
        private KiSS4.Gui.KissLabel lblSucheVorname;
        private KiSS4.Gui.KissLabel lblText1;
        private KiSS4.Gui.KissLabel lblText2;
        private KiSS4.Gui.KissLabel lblUserProfile;
        private KiSS4.Gui.KissRTFEdit memText1;
        private KiSS4.Gui.KissRTFEdit memText2;
        private KiSS4.DB.SqlQuery qryAbteilung;
        private KiSS4.DB.SqlQuery qrySubUser;
        private KiSS4.DB.SqlQuery qryUser;
        private KiSS4.DB.SqlQuery qryUserRight;
        private KiSS4.DB.SqlQuery qryVerfuegbar;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissTabControlEx tabDetail;
        private SharpLibrary.WinControls.TabPageEx tpgBenutzergruppen;
        private SharpLibrary.WinControls.TabPageEx tpgBenutzerrechte;
        private SharpLibrary.WinControls.TabPageEx tpgOrganisationseinheiten;
        private SharpLibrary.WinControls.TabPageEx tpgPerson;
        private SharpLibrary.WinControls.TabPageEx tpgSubUser;
        private SharpLibrary.WinControls.TabPageEx tpgTexte;
        private Gui.KissCheckEdit chkSucheNurAdmin;
        private Gui.KissCheckEdit chkSucheNurBIAGAdmin;
        private Gui.KissCheckEdit chkSucheNurAktive;
        private Gui.KissLabel lblFilterBenutzergruppen;
        private Gui.KissTextEdit edtFilterBenutzergruppen;
    }
}
