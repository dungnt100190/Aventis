namespace KiSS4.Administration
{
    partial class CtlOrgUnit
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnDown;
        private KiSS4.Gui.KissButton btnUp;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colItemName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLeitung;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModulID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOEItemTyp;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtEMail;
        private KiSS4.Gui.KissTextEdit edtFax;
        private KiSS4.Gui.KissTextEdit edtItemName;
        private KiSS4.Gui.KissButtonEdit edtLeitung;
        private KiSS4.Gui.KissLookUpEdit edtModulID;
        private KiSS4.Gui.KissLookUpEdit edtOrgUnit;
        private KiSS4.Gui.KissTextEdit edtPhone;
        private KiSS4.Gui.KissButtonEdit edtRechtsdienst;
        private KiSS4.Gui.KissRTFEdit edtText1;
        private KiSS4.Gui.KissRTFEdit edtText2;
        private KiSS4.Gui.KissRTFEdit edtText3;
        private KiSS4.Gui.KissRTFEdit edtText4;
        private KiSS4.Gui.KissLookUpEdit edtUserProfile;
        private KiSS4.Gui.KissTextEdit edtWWW;
        private System.Windows.Forms.ImageList imageList1;
        private KiSS4.Gui.KissLabel lblAdressat;
        private KiSS4.Gui.KissLabel lblEMail;
        private KiSS4.Gui.KissLabel lblFax;
        private KiSS4.Gui.KissLabel lblItemName;
        private KiSS4.Gui.KissLabel lblLeitung;
        private KiSS4.Gui.KissLabel lblModulID;
        private KiSS4.Gui.KissLabel lblOEItemTyp;
        private KiSS4.Gui.KissLabel lblPhone;
        private KiSS4.Gui.KissLabel lblRechtsdienst;
        private KiSS4.Gui.KissLabel lblText1;
        private KiSS4.Gui.KissLabel lblText2;
        private KiSS4.Gui.KissLabel lblText3;
        private KiSS4.Gui.KissLabel lblText4;
        private KiSS4.Gui.KissLabel lblUserProfile;
        private KiSS4.Gui.KissLabel lblWWW;
        private KiSS4.Gui.KissRTFEdit memAdressat;
        private System.Windows.Forms.Panel panFill;
        private System.Windows.Forms.Panel panUpDown;
        private KiSS4.DB.SqlQuery qryKandidaten;
        private KiSS4.DB.SqlQuery qryOrgUnit;
        private KiSS4.DB.SqlQuery qryZugeteilt;
        private KiSS4.Gui.KissTabControlEx tabOrgUnit;
        private SharpLibrary.WinControls.TabPageEx tpgAbteilung;
        private SharpLibrary.WinControls.TabPageEx tpgAdressat;
        private SharpLibrary.WinControls.TabPageEx tpgMitglieder;
        private SharpLibrary.WinControls.TabPageEx tpgTexte;
        private SharpLibrary.WinControls.TabPageEx tpgZle;
        private Gui.KissCalcEdit edtLeistungLohnlaufNr;
        private Gui.KissLabel lblLeistungLohnlaufNr;
        private Gui.KissCalcEdit edtStundenLohnlaufNr;
        private Gui.KissLabel lblStundenLohnlaufNr;
        private Gui.KissCalcEdit edtMandantennummer;
        private Gui.KissLabel lblMandantennummer;
        private Gui.KissCalcEdit edtKostenstelle;
        private Gui.KissLabel lblKostenstelle;
        private SharpLibrary.WinControls.TabPageEx tabPageEx1;
        private Gui.KissButtonEdit edtStellvertreter;
        private Gui.KissLabel lblStellvertreter;
        private System.Windows.Forms.TableLayoutPanel panMitgliederTable;
        private System.Windows.Forms.Panel panMitgliederAvailable;
        private Gui.KissGrid grdVerfuegbar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerfuegbar;
        private DevExpress.XtraGrid.Columns.GridColumn colUsers;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private System.Windows.Forms.Panel panMitgliederAvailableFilter;
        private Gui.KissLabel lblFilter;
        private Gui.KissTextEdit edtFilter;
        private Gui.KissGrid grdZugeteilt;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZugeteilt;
        private DevExpress.XtraGrid.Columns.GridColumn colUsersOE;
        private DevExpress.XtraGrid.Columns.GridColumn colMemberCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMayInsert;
        private DevExpress.XtraGrid.Columns.GridColumn colMayUpdate;
        private DevExpress.XtraGrid.Columns.GridColumn colMayDelete;
        private System.Windows.Forms.Panel panMitgliederAvailableAddRemove;
        private Gui.KissButton btnAdd;
        private Gui.KissButton btnRemove;
        private Gui.KissButton btnRemoveAll;
        private KiSS4.Gui.KissTree treOrgUnit;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlOrgUnit));
            this.tabOrgUnit = new KiSS4.Gui.KissTabControlEx();
            this.tpgAbteilung = new SharpLibrary.WinControls.TabPageEx();
            this.edtStellvertreter = new KiSS4.Gui.KissButtonEdit();
            this.qryOrgUnit = new KiSS4.DB.SqlQuery(this.components);
            this.lblStellvertreter = new KiSS4.Gui.KissLabel();
            this.edtOrgUnit = new KiSS4.Gui.KissLookUpEdit();
            this.lblOEItemTyp = new KiSS4.Gui.KissLabel();
            this.edtUserProfile = new KiSS4.Gui.KissLookUpEdit();
            this.lblUserProfile = new KiSS4.Gui.KissLabel();
            this.lblRechtsdienst = new KiSS4.Gui.KissLabel();
            this.edtRechtsdienst = new KiSS4.Gui.KissButtonEdit();
            this.lblFax = new KiSS4.Gui.KissLabel();
            this.lblText1 = new KiSS4.Gui.KissLabel();
            this.lblLeitung = new KiSS4.Gui.KissLabel();
            this.lblWWW = new KiSS4.Gui.KissLabel();
            this.lblModulID = new KiSS4.Gui.KissLabel();
            this.lblPhone = new KiSS4.Gui.KissLabel();
            this.lblEMail = new KiSS4.Gui.KissLabel();
            this.lblItemName = new KiSS4.Gui.KissLabel();
            this.edtText1 = new KiSS4.Gui.KissRTFEdit();
            this.edtWWW = new KiSS4.Gui.KissTextEdit();
            this.edtEMail = new KiSS4.Gui.KissTextEdit();
            this.edtFax = new KiSS4.Gui.KissTextEdit();
            this.edtPhone = new KiSS4.Gui.KissTextEdit();
            this.edtModulID = new KiSS4.Gui.KissLookUpEdit();
            this.edtLeitung = new KiSS4.Gui.KissButtonEdit();
            this.edtItemName = new KiSS4.Gui.KissTextEdit();
            this.tpgMitglieder = new SharpLibrary.WinControls.TabPageEx();
            this.panMitgliederTable = new System.Windows.Forms.TableLayoutPanel();
            this.panMitgliederAvailable = new System.Windows.Forms.Panel();
            this.grdVerfuegbar = new KiSS4.Gui.KissGrid();
            this.qryKandidaten = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerfuegbar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUsers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panMitgliederAvailableFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new KiSS4.Gui.KissLabel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.grdZugeteilt = new KiSS4.Gui.KissGrid();
            this.qryZugeteilt = new KiSS4.DB.SqlQuery(this.components);
            this.grvZugeteilt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUsersOE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemberCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayInsert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayUpdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMayDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panMitgliederAvailableAddRemove = new System.Windows.Forms.Panel();
            this.btnAdd = new KiSS4.Gui.KissButton();
            this.btnRemove = new KiSS4.Gui.KissButton();
            this.btnRemoveAll = new KiSS4.Gui.KissButton();
            this.tpgTexte = new SharpLibrary.WinControls.TabPageEx();
            this.lblText4 = new KiSS4.Gui.KissLabel();
            this.lblText3 = new KiSS4.Gui.KissLabel();
            this.lblText2 = new KiSS4.Gui.KissLabel();
            this.edtText4 = new KiSS4.Gui.KissRTFEdit();
            this.edtText3 = new KiSS4.Gui.KissRTFEdit();
            this.edtText2 = new KiSS4.Gui.KissRTFEdit();
            this.tpgAdressat = new SharpLibrary.WinControls.TabPageEx();
            this.lblAdressat = new KiSS4.Gui.KissLabel();
            this.memAdressat = new KiSS4.Gui.KissRTFEdit();
            this.tpgZle = new SharpLibrary.WinControls.TabPageEx();
            this.edtLeistungLohnlaufNr = new KiSS4.Gui.KissCalcEdit();
            this.lblLeistungLohnlaufNr = new KiSS4.Gui.KissLabel();
            this.edtStundenLohnlaufNr = new KiSS4.Gui.KissCalcEdit();
            this.lblStundenLohnlaufNr = new KiSS4.Gui.KissLabel();
            this.edtMandantennummer = new KiSS4.Gui.KissCalcEdit();
            this.lblMandantennummer = new KiSS4.Gui.KissLabel();
            this.edtKostenstelle = new KiSS4.Gui.KissCalcEdit();
            this.lblKostenstelle = new KiSS4.Gui.KissLabel();
            this.treOrgUnit = new KiSS4.Gui.KissTree();
            this.colItemName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colOEItemTyp = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colLeitung = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colModulID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnUp = new KiSS4.Gui.KissButton();
            this.btnDown = new KiSS4.Gui.KissButton();
            this.panFill = new System.Windows.Forms.Panel();
            this.panUpDown = new System.Windows.Forms.Panel();
            this.tabPageEx1 = new SharpLibrary.WinControls.TabPageEx();
            this.tabOrgUnit.SuspendLayout();
            this.tpgAbteilung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtStellvertreter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStellvertreter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOEItemTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechtsdienst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechtsdienst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeitung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWWW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWWW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeitung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtItemName.Properties)).BeginInit();
            this.tpgMitglieder.SuspendLayout();
            this.panMitgliederTable.SuspendLayout();
            this.panMitgliederAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).BeginInit();
            this.panMitgliederAvailableFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).BeginInit();
            this.panMitgliederAvailableAddRemove.SuspendLayout();
            this.tpgTexte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblText4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText2)).BeginInit();
            this.tpgAdressat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressat)).BeginInit();
            this.tpgZle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungLohnlaufNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungLohnlaufNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenLohnlaufNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenLohnlaufNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantennummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantennummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treOrgUnit)).BeginInit();
            this.panFill.SuspendLayout();
            this.panUpDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOrgUnit
            // 
            this.tabOrgUnit.Controls.Add(this.tpgAbteilung);
            this.tabOrgUnit.Controls.Add(this.tpgMitglieder);
            this.tabOrgUnit.Controls.Add(this.tpgTexte);
            this.tabOrgUnit.Controls.Add(this.tpgAdressat);
            this.tabOrgUnit.Controls.Add(this.tpgZle);
            this.tabOrgUnit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabOrgUnit.Location = new System.Drawing.Point(0, 221);
            this.tabOrgUnit.Name = "tabOrgUnit";
            this.tabOrgUnit.ShowFixedWidthTooltip = true;
            this.tabOrgUnit.Size = new System.Drawing.Size(754, 321);
            this.tabOrgUnit.TabIndex = 1;
            this.tabOrgUnit.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgAbteilung,
            this.tpgMitglieder,
            this.tpgTexte,
            this.tpgAdressat,
            this.tpgZle});
            this.tabOrgUnit.TabsLineColor = System.Drawing.Color.Black;
            this.tabOrgUnit.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            // 
            // tpgAbteilung
            // 
            this.tpgAbteilung.Controls.Add(this.edtStellvertreter);
            this.tpgAbteilung.Controls.Add(this.lblStellvertreter);
            this.tpgAbteilung.Controls.Add(this.edtOrgUnit);
            this.tpgAbteilung.Controls.Add(this.lblOEItemTyp);
            this.tpgAbteilung.Controls.Add(this.edtUserProfile);
            this.tpgAbteilung.Controls.Add(this.lblUserProfile);
            this.tpgAbteilung.Controls.Add(this.lblRechtsdienst);
            this.tpgAbteilung.Controls.Add(this.edtRechtsdienst);
            this.tpgAbteilung.Controls.Add(this.lblFax);
            this.tpgAbteilung.Controls.Add(this.lblText1);
            this.tpgAbteilung.Controls.Add(this.lblLeitung);
            this.tpgAbteilung.Controls.Add(this.lblWWW);
            this.tpgAbteilung.Controls.Add(this.lblModulID);
            this.tpgAbteilung.Controls.Add(this.lblPhone);
            this.tpgAbteilung.Controls.Add(this.lblEMail);
            this.tpgAbteilung.Controls.Add(this.lblItemName);
            this.tpgAbteilung.Controls.Add(this.edtText1);
            this.tpgAbteilung.Controls.Add(this.edtWWW);
            this.tpgAbteilung.Controls.Add(this.edtEMail);
            this.tpgAbteilung.Controls.Add(this.edtFax);
            this.tpgAbteilung.Controls.Add(this.edtPhone);
            this.tpgAbteilung.Controls.Add(this.edtModulID);
            this.tpgAbteilung.Controls.Add(this.edtLeitung);
            this.tpgAbteilung.Controls.Add(this.edtItemName);
            this.tpgAbteilung.Location = new System.Drawing.Point(6, 6);
            this.tpgAbteilung.Name = "tpgAbteilung";
            this.tpgAbteilung.Size = new System.Drawing.Size(742, 283);
            this.tpgAbteilung.TabIndex = 0;
            this.tpgAbteilung.Title = "Abteilung";
            // 
            // edtStellvertreter
            // 
            this.edtStellvertreter.DataMember = "Stellvertreter";
            this.edtStellvertreter.DataSource = this.qryOrgUnit;
            this.edtStellvertreter.Location = new System.Drawing.Point(108, 85);
            this.edtStellvertreter.Name = "edtStellvertreter";
            this.edtStellvertreter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStellvertreter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStellvertreter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStellvertreter.Properties.Appearance.Options.UseBackColor = true;
            this.edtStellvertreter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStellvertreter.Properties.Appearance.Options.UseFont = true;
            this.edtStellvertreter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtStellvertreter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtStellvertreter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStellvertreter.Size = new System.Drawing.Size(243, 24);
            this.edtStellvertreter.TabIndex = 23;
            this.edtStellvertreter.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtStellvertreter_UserModifiedFld);
            // 
            // qryOrgUnit
            // 
            this.qryOrgUnit.CanDelete = true;
            this.qryOrgUnit.CanInsert = true;
            this.qryOrgUnit.CanUpdate = true;
            this.qryOrgUnit.HostControl = this;
            this.qryOrgUnit.TableName = "XOrgUnit";
            this.qryOrgUnit.BeforePost += new System.EventHandler(this.qryOrgUnit_BeforePost);
            this.qryOrgUnit.AfterPost += new System.EventHandler(this.qryOrgUnit_AfterPost);
            this.qryOrgUnit.BeforeDelete += new System.EventHandler(this.qryOrgUnit_BeforeDelete);
            this.qryOrgUnit.PositionChanged += new System.EventHandler(this.qryOrgUnit_PositionChanged);
            // 
            // lblStellvertreter
            // 
            this.lblStellvertreter.Location = new System.Drawing.Point(9, 85);
            this.lblStellvertreter.Name = "lblStellvertreter";
            this.lblStellvertreter.Size = new System.Drawing.Size(93, 24);
            this.lblStellvertreter.TabIndex = 22;
            this.lblStellvertreter.Text = "Stellvertreter";
            this.lblStellvertreter.UseCompatibleTextRendering = true;
            // 
            // edtOrgUnit
            // 
            this.edtOrgUnit.DataMember = "OEItemTypCode";
            this.edtOrgUnit.DataSource = this.qryOrgUnit;
            this.edtOrgUnit.Location = new System.Drawing.Point(108, 32);
            this.edtOrgUnit.LOVName = "OrganisationsEinheitTyp";
            this.edtOrgUnit.Name = "edtOrgUnit";
            this.edtOrgUnit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrgUnit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrgUnit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnit.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrgUnit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrgUnit.Properties.Appearance.Options.UseFont = true;
            this.edtOrgUnit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtOrgUnit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtOrgUnit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtOrgUnit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtOrgUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtOrgUnit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrgUnit.Properties.NullText = "";
            this.edtOrgUnit.Properties.ShowFooter = false;
            this.edtOrgUnit.Properties.ShowHeader = false;
            this.edtOrgUnit.Size = new System.Drawing.Size(243, 24);
            this.edtOrgUnit.TabIndex = 3;
            // 
            // lblOEItemTyp
            // 
            this.lblOEItemTyp.Location = new System.Drawing.Point(9, 31);
            this.lblOEItemTyp.Name = "lblOEItemTyp";
            this.lblOEItemTyp.Size = new System.Drawing.Size(93, 24);
            this.lblOEItemTyp.TabIndex = 2;
            this.lblOEItemTyp.Text = "Abteilungstyp";
            this.lblOEItemTyp.UseCompatibleTextRendering = true;
            // 
            // edtUserProfile
            // 
            this.edtUserProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUserProfile.DataMember = "XProfileID";
            this.edtUserProfile.DataSource = this.qryOrgUnit;
            this.edtUserProfile.Location = new System.Drawing.Point(462, 108);
            this.edtUserProfile.MaximumSize = new System.Drawing.Size(300, 0);
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUserProfile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUserProfile.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserProfile.Properties.NullText = "";
            this.edtUserProfile.Properties.ShowFooter = false;
            this.edtUserProfile.Properties.ShowHeader = false;
            this.edtUserProfile.Size = new System.Drawing.Size(271, 24);
            this.edtUserProfile.TabIndex = 19;
            // 
            // lblUserProfile
            // 
            this.lblUserProfile.Location = new System.Drawing.Point(373, 108);
            this.lblUserProfile.Name = "lblUserProfile";
            this.lblUserProfile.Size = new System.Drawing.Size(83, 24);
            this.lblUserProfile.TabIndex = 18;
            this.lblUserProfile.Text = "Benutzerprofil";
            this.lblUserProfile.UseCompatibleTextRendering = true;
            // 
            // lblRechtsdienst
            // 
            this.lblRechtsdienst.Location = new System.Drawing.Point(9, 145);
            this.lblRechtsdienst.Name = "lblRechtsdienst";
            this.lblRechtsdienst.Size = new System.Drawing.Size(93, 24);
            this.lblRechtsdienst.TabIndex = 8;
            this.lblRechtsdienst.Text = "Rechtsdienst";
            this.lblRechtsdienst.UseCompatibleTextRendering = true;
            // 
            // edtRechtsdienst
            // 
            this.edtRechtsdienst.DataMember = "Rechtsdienst";
            this.edtRechtsdienst.DataSource = this.qryOrgUnit;
            this.edtRechtsdienst.Location = new System.Drawing.Point(108, 145);
            this.edtRechtsdienst.Name = "edtRechtsdienst";
            this.edtRechtsdienst.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtRechtsdienst.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRechtsdienst.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRechtsdienst.Properties.Appearance.Options.UseBackColor = true;
            this.edtRechtsdienst.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRechtsdienst.Properties.Appearance.Options.UseFont = true;
            this.edtRechtsdienst.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtRechtsdienst.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtRechtsdienst.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRechtsdienst.Size = new System.Drawing.Size(243, 24);
            this.edtRechtsdienst.TabIndex = 9;
            this.edtRechtsdienst.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtRechtsdienst_UserModifiedFld);
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(373, 32);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(83, 24);
            this.lblFax.TabIndex = 12;
            this.lblFax.Text = "Fax";
            this.lblFax.UseCompatibleTextRendering = true;
            // 
            // lblText1
            // 
            this.lblText1.Location = new System.Drawing.Point(9, 175);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(93, 24);
            this.lblText1.TabIndex = 20;
            this.lblText1.Text = "Text 1";
            this.lblText1.UseCompatibleTextRendering = true;
            // 
            // lblLeitung
            // 
            this.lblLeitung.Location = new System.Drawing.Point(9, 62);
            this.lblLeitung.Name = "lblLeitung";
            this.lblLeitung.Size = new System.Drawing.Size(93, 24);
            this.lblLeitung.TabIndex = 4;
            this.lblLeitung.Text = "Leitung";
            this.lblLeitung.UseCompatibleTextRendering = true;
            // 
            // lblWWW
            // 
            this.lblWWW.Location = new System.Drawing.Point(373, 79);
            this.lblWWW.Name = "lblWWW";
            this.lblWWW.Size = new System.Drawing.Size(83, 24);
            this.lblWWW.TabIndex = 16;
            this.lblWWW.Text = "Web";
            this.lblWWW.UseCompatibleTextRendering = true;
            // 
            // lblModulID
            // 
            this.lblModulID.Location = new System.Drawing.Point(9, 115);
            this.lblModulID.Name = "lblModulID";
            this.lblModulID.Size = new System.Drawing.Size(93, 24);
            this.lblModulID.TabIndex = 6;
            this.lblModulID.Text = "Modul";
            this.lblModulID.UseCompatibleTextRendering = true;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(373, 9);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(83, 24);
            this.lblPhone.TabIndex = 10;
            this.lblPhone.Text = "Telefon";
            this.lblPhone.UseCompatibleTextRendering = true;
            // 
            // lblEMail
            // 
            this.lblEMail.Location = new System.Drawing.Point(373, 55);
            this.lblEMail.Name = "lblEMail";
            this.lblEMail.Size = new System.Drawing.Size(83, 24);
            this.lblEMail.TabIndex = 14;
            this.lblEMail.Text = "EMail";
            this.lblEMail.UseCompatibleTextRendering = true;
            // 
            // lblItemName
            // 
            this.lblItemName.Location = new System.Drawing.Point(9, 9);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(93, 24);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Abteilung";
            this.lblItemName.UseCompatibleTextRendering = true;
            // 
            // edtText1
            // 
            this.edtText1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtText1.BackColor = System.Drawing.Color.White;
            this.edtText1.DataMember = "Text1";
            this.edtText1.DataSource = this.qryOrgUnit;
            this.edtText1.Font = new System.Drawing.Font("Arial", 10F);
            this.edtText1.Location = new System.Drawing.Point(108, 175);
            this.edtText1.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.edtText1.Name = "edtText1";
            this.edtText1.Size = new System.Drawing.Size(639, 108);
            this.edtText1.TabIndex = 21;
            // 
            // edtWWW
            // 
            this.edtWWW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtWWW.DataMember = "WWW";
            this.edtWWW.DataSource = this.qryOrgUnit;
            this.edtWWW.Location = new System.Drawing.Point(462, 78);
            this.edtWWW.MaximumSize = new System.Drawing.Size(300, 0);
            this.edtWWW.Name = "edtWWW";
            this.edtWWW.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWWW.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWWW.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWWW.Properties.Appearance.Options.UseBackColor = true;
            this.edtWWW.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWWW.Properties.Appearance.Options.UseFont = true;
            this.edtWWW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtWWW.Size = new System.Drawing.Size(271, 24);
            this.edtWWW.TabIndex = 17;
            // 
            // edtEMail
            // 
            this.edtEMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtEMail.DataMember = "EMail";
            this.edtEMail.DataSource = this.qryOrgUnit;
            this.edtEMail.Location = new System.Drawing.Point(462, 55);
            this.edtEMail.MaximumSize = new System.Drawing.Size(300, 0);
            this.edtEMail.Name = "edtEMail";
            this.edtEMail.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEMail.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEMail.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEMail.Properties.Appearance.Options.UseBackColor = true;
            this.edtEMail.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEMail.Properties.Appearance.Options.UseFont = true;
            this.edtEMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEMail.Size = new System.Drawing.Size(271, 24);
            this.edtEMail.TabIndex = 15;
            // 
            // edtFax
            // 
            this.edtFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFax.DataMember = "Fax";
            this.edtFax.DataSource = this.qryOrgUnit;
            this.edtFax.Location = new System.Drawing.Point(462, 32);
            this.edtFax.MaximumSize = new System.Drawing.Size(300, 0);
            this.edtFax.Name = "edtFax";
            this.edtFax.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFax.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFax.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFax.Properties.Appearance.Options.UseBackColor = true;
            this.edtFax.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFax.Properties.Appearance.Options.UseFont = true;
            this.edtFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFax.Size = new System.Drawing.Size(271, 24);
            this.edtFax.TabIndex = 13;
            // 
            // edtPhone
            // 
            this.edtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtPhone.DataMember = "Phone";
            this.edtPhone.DataSource = this.qryOrgUnit;
            this.edtPhone.Location = new System.Drawing.Point(462, 9);
            this.edtPhone.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtPhone.MaximumSize = new System.Drawing.Size(300, 0);
            this.edtPhone.Name = "edtPhone";
            this.edtPhone.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPhone.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPhone.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPhone.Properties.Appearance.Options.UseBackColor = true;
            this.edtPhone.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPhone.Properties.Appearance.Options.UseFont = true;
            this.edtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPhone.Size = new System.Drawing.Size(271, 24);
            this.edtPhone.TabIndex = 11;
            // 
            // edtModulID
            // 
            this.edtModulID.DataMember = "ModulID";
            this.edtModulID.DataSource = this.qryOrgUnit;
            this.edtModulID.Location = new System.Drawing.Point(108, 115);
            this.edtModulID.LOVFilter = "System = 0 AND Licensed = 1";
            this.edtModulID.LOVFilterWhereAppend = true;
            this.edtModulID.LOVName = "Modul";
            this.edtModulID.Name = "edtModulID";
            this.edtModulID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtModulID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtModulID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.Appearance.Options.UseBackColor = true;
            this.edtModulID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtModulID.Properties.Appearance.Options.UseFont = true;
            this.edtModulID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtModulID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtModulID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtModulID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtModulID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtModulID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtModulID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtModulID.Properties.NullText = "";
            this.edtModulID.Properties.ShowFooter = false;
            this.edtModulID.Properties.ShowHeader = false;
            this.edtModulID.Size = new System.Drawing.Size(243, 24);
            this.edtModulID.TabIndex = 7;
            // 
            // edtLeitung
            // 
            this.edtLeitung.DataMember = "Leitung";
            this.edtLeitung.DataSource = this.qryOrgUnit;
            this.edtLeitung.Location = new System.Drawing.Point(108, 62);
            this.edtLeitung.Name = "edtLeitung";
            this.edtLeitung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLeitung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLeitung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeitung.Properties.Appearance.Options.UseBackColor = true;
            this.edtLeitung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLeitung.Properties.Appearance.Options.UseFont = true;
            this.edtLeitung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtLeitung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtLeitung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLeitung.Size = new System.Drawing.Size(243, 24);
            this.edtLeitung.TabIndex = 5;
            this.edtLeitung.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtLeitung_UserModifiedFld);
            // 
            // edtItemName
            // 
            this.edtItemName.DataMember = "ItemName";
            this.edtItemName.DataSource = this.qryOrgUnit;
            this.edtItemName.Location = new System.Drawing.Point(108, 9);
            this.edtItemName.Name = "edtItemName";
            this.edtItemName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtItemName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtItemName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtItemName.Properties.Appearance.Options.UseBackColor = true;
            this.edtItemName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtItemName.Properties.Appearance.Options.UseFont = true;
            this.edtItemName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtItemName.Size = new System.Drawing.Size(243, 24);
            this.edtItemName.TabIndex = 1;
            // 
            // tpgMitglieder
            // 
            this.tpgMitglieder.Controls.Add(this.panMitgliederTable);
            this.tpgMitglieder.Location = new System.Drawing.Point(6, 6);
            this.tpgMitglieder.Name = "tpgMitglieder";
            this.tpgMitglieder.Size = new System.Drawing.Size(742, 283);
            this.tpgMitglieder.TabIndex = 1;
            this.tpgMitglieder.Title = "Mitglieder";
            // 
            // panMitgliederTable
            // 
            this.panMitgliederTable.ColumnCount = 3;
            this.panMitgliederTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panMitgliederTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.panMitgliederTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panMitgliederTable.Controls.Add(this.panMitgliederAvailable, 0, 0);
            this.panMitgliederTable.Controls.Add(this.grdZugeteilt, 2, 0);
            this.panMitgliederTable.Controls.Add(this.panMitgliederAvailableAddRemove, 1, 0);
            this.panMitgliederTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMitgliederTable.Location = new System.Drawing.Point(0, 0);
            this.panMitgliederTable.Name = "panMitgliederTable";
            this.panMitgliederTable.RowCount = 1;
            this.panMitgliederTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panMitgliederTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panMitgliederTable.Size = new System.Drawing.Size(742, 283);
            this.panMitgliederTable.TabIndex = 1;
            this.panMitgliederTable.TabStop = true;
            // 
            // panMitgliederAvailable
            // 
            this.panMitgliederAvailable.Controls.Add(this.grdVerfuegbar);
            this.panMitgliederAvailable.Controls.Add(this.panMitgliederAvailableFilter);
            this.panMitgliederAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMitgliederAvailable.Location = new System.Drawing.Point(3, 3);
            this.panMitgliederAvailable.Name = "panMitgliederAvailable";
            this.panMitgliederAvailable.Size = new System.Drawing.Size(335, 277);
            this.panMitgliederAvailable.TabIndex = 1;
            this.panMitgliederAvailable.TabStop = true;
            // 
            // grdVerfuegbar
            // 
            this.grdVerfuegbar.DataSource = this.qryKandidaten;
            this.grdVerfuegbar.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdVerfuegbar.EmbeddedNavigator.Name = "";
            this.grdVerfuegbar.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerfuegbar.Location = new System.Drawing.Point(0, 0);
            this.grdVerfuegbar.MainView = this.grvVerfuegbar;
            this.grdVerfuegbar.Margin = new System.Windows.Forms.Padding(4);
            this.grdVerfuegbar.Name = "grdVerfuegbar";
            this.grdVerfuegbar.Size = new System.Drawing.Size(335, 243);
            this.grdVerfuegbar.TabIndex = 0;
            this.grdVerfuegbar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerfuegbar});
            this.grdVerfuegbar.DoubleClick += new System.EventHandler(this.grdVerfuegbar_DoubleClick);
            // 
            // qryKandidaten
            // 
            this.qryKandidaten.HostControl = this;
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
            this.colUsers,
            this.colUserID});
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
            // colUsers
            // 
            this.colUsers.Caption = "Benutzer/in";
            this.colUsers.FieldName = "UserName";
            this.colUsers.Name = "colUsers";
            this.colUsers.Visible = true;
            this.colUsers.VisibleIndex = 0;
            this.colUsers.Width = 315;
            // 
            // colUserID
            // 
            this.colUserID.Caption = "-";
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            // 
            // panMitgliederAvailableFilter
            // 
            this.panMitgliederAvailableFilter.Controls.Add(this.lblFilter);
            this.panMitgliederAvailableFilter.Controls.Add(this.edtFilter);
            this.panMitgliederAvailableFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panMitgliederAvailableFilter.Location = new System.Drawing.Point(0, 243);
            this.panMitgliederAvailableFilter.Name = "panMitgliederAvailableFilter";
            this.panMitgliederAvailableFilter.Size = new System.Drawing.Size(335, 34);
            this.panMitgliederAvailableFilter.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(3, 5);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(54, 24);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Filter";
            this.lblFilter.UseCompatibleTextRendering = true;
            // 
            // edtFilter
            // 
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilter.Location = new System.Drawing.Point(63, 5);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(272, 24);
            this.edtFilter.TabIndex = 1;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            // 
            // grdZugeteilt
            // 
            this.grdZugeteilt.DataSource = this.qryZugeteilt;
            this.grdZugeteilt.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdZugeteilt.EmbeddedNavigator.Name = "";
            this.grdZugeteilt.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdZugeteilt.Location = new System.Drawing.Point(405, 4);
            this.grdZugeteilt.MainView = this.grvZugeteilt;
            this.grdZugeteilt.Margin = new System.Windows.Forms.Padding(4);
            this.grdZugeteilt.Name = "grdZugeteilt";
            this.grdZugeteilt.Size = new System.Drawing.Size(333, 275);
            this.grdZugeteilt.TabIndex = 3;
            this.grdZugeteilt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZugeteilt});
            // 
            // qryZugeteilt
            // 
            this.qryZugeteilt.CanDelete = true;
            this.qryZugeteilt.CanInsert = true;
            this.qryZugeteilt.CanUpdate = true;
            this.qryZugeteilt.DeleteQuestion = null;
            this.qryZugeteilt.HostControl = this;
            this.qryZugeteilt.TableName = "XOrgUnit_User";
            this.qryZugeteilt.BeforePost += new System.EventHandler(this.qryZugeteilt_BeforePost);
            this.qryZugeteilt.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryZugeteilt_ColumnChanged);
            // 
            // grvZugeteilt
            // 
            this.grvZugeteilt.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZugeteilt.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Empty.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Empty.Options.UseFont = true;
            this.grvZugeteilt.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvZugeteilt.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.EvenRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZugeteilt.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
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
            this.grvZugeteilt.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvZugeteilt.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.OddRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.Row.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.Row.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZugeteilt.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZugeteilt.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZugeteilt.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvZugeteilt.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvZugeteilt.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZugeteilt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZugeteilt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUsersOE,
            this.colMemberCode,
            this.colMayInsert,
            this.colMayUpdate,
            this.colMayDelete});
            this.grvZugeteilt.GridControl = this.grdZugeteilt;
            this.grvZugeteilt.Name = "grvZugeteilt";
            this.grvZugeteilt.OptionsCustomization.AllowFilter = false;
            this.grvZugeteilt.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZugeteilt.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZugeteilt.OptionsView.ColumnAutoWidth = false;
            this.grvZugeteilt.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZugeteilt.OptionsView.ShowGroupPanel = false;
            // 
            // colUsersOE
            // 
            this.colUsersOE.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colUsersOE.AppearanceCell.Options.UseBackColor = true;
            this.colUsersOE.Caption = "Abteilungs-Mitglieder";
            this.colUsersOE.FieldName = "UserName";
            this.colUsersOE.Name = "colUsersOE";
            this.colUsersOE.OptionsColumn.AllowEdit = false;
            this.colUsersOE.Visible = true;
            this.colUsersOE.VisibleIndex = 0;
            this.colUsersOE.Width = 187;
            // 
            // colMemberCode
            // 
            this.colMemberCode.Caption = "Funktion";
            this.colMemberCode.FieldName = "OrgUnitMemberCode";
            this.colMemberCode.Name = "colMemberCode";
            this.colMemberCode.Visible = true;
            this.colMemberCode.VisibleIndex = 1;
            this.colMemberCode.Width = 76;
            // 
            // colMayInsert
            // 
            this.colMayInsert.Caption = "E";
            this.colMayInsert.FieldName = "MayInsert";
            this.colMayInsert.Name = "colMayInsert";
            this.colMayInsert.OptionsColumn.AllowSize = false;
            this.colMayInsert.OptionsColumn.FixedWidth = true;
            this.colMayInsert.Visible = true;
            this.colMayInsert.VisibleIndex = 2;
            this.colMayInsert.Width = 20;
            // 
            // colMayUpdate
            // 
            this.colMayUpdate.Caption = "M";
            this.colMayUpdate.FieldName = "MayUpdate";
            this.colMayUpdate.Name = "colMayUpdate";
            this.colMayUpdate.OptionsColumn.AllowSize = false;
            this.colMayUpdate.OptionsColumn.FixedWidth = true;
            this.colMayUpdate.Visible = true;
            this.colMayUpdate.VisibleIndex = 3;
            this.colMayUpdate.Width = 20;
            // 
            // colMayDelete
            // 
            this.colMayDelete.Caption = "L";
            this.colMayDelete.FieldName = "MayDelete";
            this.colMayDelete.Name = "colMayDelete";
            this.colMayDelete.OptionsColumn.AllowSize = false;
            this.colMayDelete.OptionsColumn.FixedWidth = true;
            this.colMayDelete.Visible = true;
            this.colMayDelete.VisibleIndex = 4;
            this.colMayDelete.Width = 20;
            // 
            // panMitgliederAvailableAddRemove
            // 
            this.panMitgliederAvailableAddRemove.Controls.Add(this.btnAdd);
            this.panMitgliederAvailableAddRemove.Controls.Add(this.btnRemove);
            this.panMitgliederAvailableAddRemove.Controls.Add(this.btnRemoveAll);
            this.panMitgliederAvailableAddRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMitgliederAvailableAddRemove.Location = new System.Drawing.Point(341, 0);
            this.panMitgliederAvailableAddRemove.Margin = new System.Windows.Forms.Padding(0);
            this.panMitgliederAvailableAddRemove.Name = "panMitgliederAvailableAddRemove";
            this.panMitgliederAvailableAddRemove.Size = new System.Drawing.Size(60, 283);
            this.panMitgliederAvailableAddRemove.TabIndex = 2;
            this.panMitgliederAvailableAddRemove.TabStop = true;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconID = 13;
            this.btnAdd.Location = new System.Drawing.Point(16, 30);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(10, 30, 10, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(28, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseCompatibleTextRendering = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.IconID = 11;
            this.btnRemove.Location = new System.Drawing.Point(16, 60);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 24);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.UseCompatibleTextRendering = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.IconID = 12;
            this.btnRemoveAll.Location = new System.Drawing.Point(16, 90);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(28, 24);
            this.btnRemoveAll.TabIndex = 2;
            this.btnRemoveAll.UseCompatibleTextRendering = true;
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // tpgTexte
            // 
            this.tpgTexte.Controls.Add(this.lblText4);
            this.tpgTexte.Controls.Add(this.lblText3);
            this.tpgTexte.Controls.Add(this.lblText2);
            this.tpgTexte.Controls.Add(this.edtText4);
            this.tpgTexte.Controls.Add(this.edtText3);
            this.tpgTexte.Controls.Add(this.edtText2);
            this.tpgTexte.Location = new System.Drawing.Point(6, 6);
            this.tpgTexte.Name = "tpgTexte";
            this.tpgTexte.Size = new System.Drawing.Size(742, 283);
            this.tpgTexte.TabIndex = 2;
            this.tpgTexte.Title = "Texte";
            // 
            // lblText4
            // 
            this.lblText4.Location = new System.Drawing.Point(9, 189);
            this.lblText4.Name = "lblText4";
            this.lblText4.Size = new System.Drawing.Size(42, 24);
            this.lblText4.TabIndex = 88;
            this.lblText4.Text = "Text 4";
            this.lblText4.UseCompatibleTextRendering = true;
            // 
            // lblText3
            // 
            this.lblText3.Location = new System.Drawing.Point(9, 118);
            this.lblText3.Name = "lblText3";
            this.lblText3.Size = new System.Drawing.Size(42, 24);
            this.lblText3.TabIndex = 86;
            this.lblText3.Text = "Text 3";
            this.lblText3.UseCompatibleTextRendering = true;
            // 
            // lblText2
            // 
            this.lblText2.Location = new System.Drawing.Point(9, 9);
            this.lblText2.Name = "lblText2";
            this.lblText2.Size = new System.Drawing.Size(42, 24);
            this.lblText2.TabIndex = 85;
            this.lblText2.Text = "Text 2";
            this.lblText2.UseCompatibleTextRendering = true;
            // 
            // edtText4
            // 
            this.edtText4.BackColor = System.Drawing.Color.White;
            this.edtText4.DataMember = "Text4";
            this.edtText4.DataSource = this.qryOrgUnit;
            this.edtText4.Font = new System.Drawing.Font("Arial", 10F);
            this.edtText4.Location = new System.Drawing.Point(61, 189);
            this.edtText4.Name = "edtText4";
            this.edtText4.Size = new System.Drawing.Size(612, 60);
            this.edtText4.TabIndex = 2;
            // 
            // edtText3
            // 
            this.edtText3.BackColor = System.Drawing.Color.White;
            this.edtText3.DataMember = "Text3";
            this.edtText3.DataSource = this.qryOrgUnit;
            this.edtText3.Font = new System.Drawing.Font("Arial", 10F);
            this.edtText3.Location = new System.Drawing.Point(61, 118);
            this.edtText3.Name = "edtText3";
            this.edtText3.Size = new System.Drawing.Size(612, 60);
            this.edtText3.TabIndex = 1;
            // 
            // edtText2
            // 
            this.edtText2.BackColor = System.Drawing.Color.White;
            this.edtText2.DataMember = "Text2";
            this.edtText2.DataSource = this.qryOrgUnit;
            this.edtText2.Font = new System.Drawing.Font("Arial", 10F);
            this.edtText2.Location = new System.Drawing.Point(61, 9);
            this.edtText2.Name = "edtText2";
            this.edtText2.Size = new System.Drawing.Size(612, 98);
            this.edtText2.TabIndex = 0;
            // 
            // tpgAdressat
            // 
            this.tpgAdressat.Controls.Add(this.lblAdressat);
            this.tpgAdressat.Controls.Add(this.memAdressat);
            this.tpgAdressat.Location = new System.Drawing.Point(6, 6);
            this.tpgAdressat.Name = "tpgAdressat";
            this.tpgAdressat.Size = new System.Drawing.Size(742, 283);
            this.tpgAdressat.TabIndex = 3;
            this.tpgAdressat.Title = "Adressat";
            // 
            // lblAdressat
            // 
            this.lblAdressat.Location = new System.Drawing.Point(9, 9);
            this.lblAdressat.Name = "lblAdressat";
            this.lblAdressat.Size = new System.Drawing.Size(50, 24);
            this.lblAdressat.TabIndex = 87;
            this.lblAdressat.Text = "Adressat";
            this.lblAdressat.UseCompatibleTextRendering = true;
            // 
            // memAdressat
            // 
            this.memAdressat.BackColor = System.Drawing.Color.White;
            this.memAdressat.DataMember = "Adressat";
            this.memAdressat.DataSource = this.qryOrgUnit;
            this.memAdressat.Font = new System.Drawing.Font("Arial", 10F);
            this.memAdressat.Location = new System.Drawing.Point(65, 9);
            this.memAdressat.Name = "memAdressat";
            this.memAdressat.Size = new System.Drawing.Size(612, 98);
            this.memAdressat.TabIndex = 86;
            // 
            // tpgZle
            // 
            this.tpgZle.Controls.Add(this.edtLeistungLohnlaufNr);
            this.tpgZle.Controls.Add(this.lblLeistungLohnlaufNr);
            this.tpgZle.Controls.Add(this.edtStundenLohnlaufNr);
            this.tpgZle.Controls.Add(this.lblStundenLohnlaufNr);
            this.tpgZle.Controls.Add(this.edtMandantennummer);
            this.tpgZle.Controls.Add(this.lblMandantennummer);
            this.tpgZle.Controls.Add(this.edtKostenstelle);
            this.tpgZle.Controls.Add(this.lblKostenstelle);
            this.tpgZle.Location = new System.Drawing.Point(6, 6);
            this.tpgZle.Name = "tpgZle";
            this.tpgZle.Size = new System.Drawing.Size(742, 283);
            this.tpgZle.TabIndex = 4;
            this.tpgZle.Title = "ZLE";
            // 
            // edtLeistungLohnlaufNr
            // 
            this.edtLeistungLohnlaufNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtLeistungLohnlaufNr.DataMember = "LeistungLohnlaufNr";
            this.edtLeistungLohnlaufNr.DataSource = this.qryOrgUnit;
            this.edtLeistungLohnlaufNr.Location = new System.Drawing.Point(129, 99);
            this.edtLeistungLohnlaufNr.Name = "edtLeistungLohnlaufNr";
            this.edtLeistungLohnlaufNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtLeistungLohnlaufNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLeistungLohnlaufNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLeistungLohnlaufNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLeistungLohnlaufNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtLeistungLohnlaufNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLeistungLohnlaufNr.Properties.Appearance.Options.UseFont = true;
            this.edtLeistungLohnlaufNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLeistungLohnlaufNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLeistungLohnlaufNr.Properties.Precision = 0;
            this.edtLeistungLohnlaufNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtLeistungLohnlaufNr.Size = new System.Drawing.Size(243, 24);
            this.edtLeistungLohnlaufNr.TabIndex = 19;
            // 
            // lblLeistungLohnlaufNr
            // 
            this.lblLeistungLohnlaufNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLeistungLohnlaufNr.Location = new System.Drawing.Point(9, 99);
            this.lblLeistungLohnlaufNr.Name = "lblLeistungLohnlaufNr";
            this.lblLeistungLohnlaufNr.Size = new System.Drawing.Size(114, 24);
            this.lblLeistungLohnlaufNr.TabIndex = 18;
            this.lblLeistungLohnlaufNr.Text = "Lohnlauf-Nr. (Leist.)";
            this.lblLeistungLohnlaufNr.UseCompatibleTextRendering = true;
            // 
            // edtStundenLohnlaufNr
            // 
            this.edtStundenLohnlaufNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStundenLohnlaufNr.DataMember = "StundenLohnlaufNr";
            this.edtStundenLohnlaufNr.DataSource = this.qryOrgUnit;
            this.edtStundenLohnlaufNr.Location = new System.Drawing.Point(129, 69);
            this.edtStundenLohnlaufNr.Name = "edtStundenLohnlaufNr";
            this.edtStundenLohnlaufNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStundenLohnlaufNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStundenLohnlaufNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStundenLohnlaufNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStundenLohnlaufNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtStundenLohnlaufNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStundenLohnlaufNr.Properties.Appearance.Options.UseFont = true;
            this.edtStundenLohnlaufNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStundenLohnlaufNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStundenLohnlaufNr.Properties.Precision = 0;
            this.edtStundenLohnlaufNr.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtStundenLohnlaufNr.Size = new System.Drawing.Size(243, 24);
            this.edtStundenLohnlaufNr.TabIndex = 17;
            // 
            // lblStundenLohnlaufNr
            // 
            this.lblStundenLohnlaufNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStundenLohnlaufNr.Location = new System.Drawing.Point(9, 69);
            this.lblStundenLohnlaufNr.Name = "lblStundenLohnlaufNr";
            this.lblStundenLohnlaufNr.Size = new System.Drawing.Size(114, 24);
            this.lblStundenLohnlaufNr.TabIndex = 16;
            this.lblStundenLohnlaufNr.Text = "Lohnlauf-Nr. (Std.)";
            this.lblStundenLohnlaufNr.UseCompatibleTextRendering = true;
            // 
            // edtMandantennummer
            // 
            this.edtMandantennummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMandantennummer.DataMember = "Mandantennummer";
            this.edtMandantennummer.DataSource = this.qryOrgUnit;
            this.edtMandantennummer.Location = new System.Drawing.Point(129, 39);
            this.edtMandantennummer.Name = "edtMandantennummer";
            this.edtMandantennummer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMandantennummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMandantennummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMandantennummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMandantennummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtMandantennummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMandantennummer.Properties.Appearance.Options.UseFont = true;
            this.edtMandantennummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMandantennummer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMandantennummer.Properties.Precision = 0;
            this.edtMandantennummer.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtMandantennummer.Size = new System.Drawing.Size(243, 24);
            this.edtMandantennummer.TabIndex = 15;
            // 
            // lblMandantennummer
            // 
            this.lblMandantennummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMandantennummer.Location = new System.Drawing.Point(9, 39);
            this.lblMandantennummer.Name = "lblMandantennummer";
            this.lblMandantennummer.Size = new System.Drawing.Size(114, 24);
            this.lblMandantennummer.TabIndex = 14;
            this.lblMandantennummer.Text = "Mandantennummer";
            this.lblMandantennummer.UseCompatibleTextRendering = true;
            // 
            // edtKostenstelle
            // 
            this.edtKostenstelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKostenstelle.DataMember = "Kostenstelle";
            this.edtKostenstelle.DataSource = this.qryOrgUnit;
            this.edtKostenstelle.Location = new System.Drawing.Point(129, 9);
            this.edtKostenstelle.Name = "edtKostenstelle";
            this.edtKostenstelle.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenstelle.Properties.Precision = 0;
            this.edtKostenstelle.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtKostenstelle.Size = new System.Drawing.Size(243, 24);
            this.edtKostenstelle.TabIndex = 13;
            // 
            // lblKostenstelle
            // 
            this.lblKostenstelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKostenstelle.Location = new System.Drawing.Point(9, 9);
            this.lblKostenstelle.Name = "lblKostenstelle";
            this.lblKostenstelle.Size = new System.Drawing.Size(114, 24);
            this.lblKostenstelle.TabIndex = 12;
            this.lblKostenstelle.Text = "Kostenstelle";
            this.lblKostenstelle.UseCompatibleTextRendering = true;
            // 
            // treOrgUnit
            // 
            this.treOrgUnit.AllowSortTree = true;
            this.treOrgUnit.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treOrgUnit.Appearance.Empty.ForeColor = System.Drawing.Color.White;
            this.treOrgUnit.Appearance.Empty.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.Empty.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treOrgUnit.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.EvenRow.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.EvenRow.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treOrgUnit.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treOrgUnit.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treOrgUnit.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treOrgUnit.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treOrgUnit.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.FooterPanel.Options.UseFont = true;
            this.treOrgUnit.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treOrgUnit.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treOrgUnit.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.GroupButton.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.GroupButton.Options.UseFont = true;
            this.treOrgUnit.Appearance.GroupButton.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treOrgUnit.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treOrgUnit.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treOrgUnit.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.HeaderPanel.Options.UseFont = true;
            this.treOrgUnit.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treOrgUnit.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treOrgUnit.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treOrgUnit.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treOrgUnit.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treOrgUnit.Appearance.HorzLine.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.HorzLine.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treOrgUnit.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treOrgUnit.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.OddRow.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.OddRow.Options.UseFont = true;
            this.treOrgUnit.Appearance.OddRow.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treOrgUnit.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treOrgUnit.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.treOrgUnit.Appearance.Preview.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.Preview.Options.UseFont = true;
            this.treOrgUnit.Appearance.Preview.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treOrgUnit.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treOrgUnit.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treOrgUnit.Appearance.Row.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.Row.Options.UseFont = true;
            this.treOrgUnit.Appearance.Row.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treOrgUnit.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treOrgUnit.Appearance.TreeLine.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treOrgUnit.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treOrgUnit.Appearance.VertLine.Options.UseBackColor = true;
            this.treOrgUnit.Appearance.VertLine.Options.UseForeColor = true;
            this.treOrgUnit.Appearance.VertLine.Options.UseTextOptions = true;
            this.treOrgUnit.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treOrgUnit.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colItemName,
            this.colOEItemTyp,
            this.colLeitung,
            this.colModulID});
            this.treOrgUnit.DataSource = this.qryOrgUnit;
            this.treOrgUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treOrgUnit.ImageIndexFieldName = "";
            this.treOrgUnit.KeyFieldName = "OrgUnitID";
            this.treOrgUnit.Location = new System.Drawing.Point(0, 0);
            this.treOrgUnit.Name = "treOrgUnit";
            this.treOrgUnit.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treOrgUnit.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treOrgUnit.OptionsBehavior.Editable = false;
            this.treOrgUnit.OptionsBehavior.KeepSelectedOnClick = false;
            this.treOrgUnit.OptionsBehavior.MoveOnEdit = false;
            this.treOrgUnit.OptionsMenu.EnableColumnMenu = false;
            this.treOrgUnit.OptionsMenu.EnableFooterMenu = false;
            this.treOrgUnit.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treOrgUnit.OptionsView.AutoWidth = false;
            this.treOrgUnit.OptionsView.EnableAppearanceEvenRow = true;
            this.treOrgUnit.OptionsView.EnableAppearanceOddRow = true;
            this.treOrgUnit.OptionsView.ShowIndicator = false;
            this.treOrgUnit.SelectImageList = this.imageList1;
            this.treOrgUnit.Size = new System.Drawing.Size(714, 221);
            this.treOrgUnit.TabIndex = 0;
            this.treOrgUnit.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.treOrgUnit_GetSelectImage);
            this.treOrgUnit.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treOrgUnit_BeforeFocusNode);
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Abteilung";
            this.colItemName.FieldName = "ItemName";
            this.colItemName.MinWidth = 27;
            this.colItemName.Name = "colItemName";
            this.colItemName.VisibleIndex = 0;
            this.colItemName.Width = 280;
            // 
            // colOEItemTyp
            // 
            this.colOEItemTyp.Caption = "Abteilungstyp";
            this.colOEItemTyp.FieldName = "OrgUnitTyp";
            this.colOEItemTyp.Name = "colOEItemTyp";
            this.colOEItemTyp.VisibleIndex = 1;
            this.colOEItemTyp.Width = 120;
            // 
            // colLeitung
            // 
            this.colLeitung.Caption = "Leitung";
            this.colLeitung.FieldName = "Leitung";
            this.colLeitung.Name = "colLeitung";
            this.colLeitung.VisibleIndex = 2;
            this.colLeitung.Width = 180;
            // 
            // colModulID
            // 
            this.colModulID.Caption = "Modul";
            this.colModulID.FieldName = "ModulID";
            this.colModulID.Name = "colModulID";
            this.colModulID.VisibleIndex = 3;
            this.colModulID.Width = 150;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            // 
            // btnUp
            // 
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.IconID = 16;
            this.btnUp.Location = new System.Drawing.Point(6, 9);
            this.btnUp.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 24);
            this.btnUp.TabIndex = 0;
            this.btnUp.UseCompatibleTextRendering = true;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.UpDown_Click);
            // 
            // btnDown
            // 
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.IconID = 17;
            this.btnDown.Location = new System.Drawing.Point(6, 39);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 24);
            this.btnDown.TabIndex = 1;
            this.btnDown.UseCompatibleTextRendering = true;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.UpDown_Click);
            // 
            // panFill
            // 
            this.panFill.Controls.Add(this.treOrgUnit);
            this.panFill.Controls.Add(this.panUpDown);
            this.panFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panFill.Location = new System.Drawing.Point(0, 0);
            this.panFill.Name = "panFill";
            this.panFill.Size = new System.Drawing.Size(754, 221);
            this.panFill.TabIndex = 0;
            // 
            // panUpDown
            // 
            this.panUpDown.Controls.Add(this.btnUp);
            this.panUpDown.Controls.Add(this.btnDown);
            this.panUpDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.panUpDown.Location = new System.Drawing.Point(714, 0);
            this.panUpDown.Name = "panUpDown";
            this.panUpDown.Size = new System.Drawing.Size(40, 221);
            this.panUpDown.TabIndex = 1;
            // 
            // tabPageEx1
            // 
            this.tabPageEx1.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx1.Name = "tabPageEx1";
            this.tabPageEx1.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx1.TabIndex = 0;
            this.tabPageEx1.Title = "tabPageEx1";
            // 
            // CtlOrgUnit
            // 
            this.ActiveSQLQuery = this.qryOrgUnit;
            this.Controls.Add(this.panFill);
            this.Controls.Add(this.tabOrgUnit);
            this.Name = "CtlOrgUnit";
            this.Size = new System.Drawing.Size(754, 542);
            this.Load += new System.EventHandler(this.CtlOrgUnit_Load);
            this.tabOrgUnit.ResumeLayout(false);
            this.tpgAbteilung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtStellvertreter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStellvertreter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOEItemTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRechtsdienst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRechtsdienst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeitung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWWW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWWW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtModulID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLeitung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtItemName.Properties)).EndInit();
            this.tpgMitglieder.ResumeLayout(false);
            this.panMitgliederTable.ResumeLayout(false);
            this.panMitgliederAvailable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVerfuegbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKandidaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerfuegbar)).EndInit();
            this.panMitgliederAvailableFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZugeteilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZugeteilt)).EndInit();
            this.panMitgliederAvailableAddRemove.ResumeLayout(false);
            this.tpgTexte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblText4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText2)).EndInit();
            this.tpgAdressat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAdressat)).EndInit();
            this.tpgZle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtLeistungLohnlaufNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeistungLohnlaufNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStundenLohnlaufNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStundenLohnlaufNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMandantennummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantennummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treOrgUnit)).EndInit();
            this.panFill.ResumeLayout(false);
            this.panUpDown.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
    }
}