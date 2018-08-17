namespace KiSS4.Administration
{
    partial class CtlDoublePerson
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlDoublePerson));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryPersonA = new KiSS4.DB.SqlQuery(this.components);
            this.qryPersonB = new KiSS4.DB.SqlQuery(this.components);
            this.tabDoublePerson = new KiSS4.Gui.KissTabControlEx();
            this.tpgPersons = new SharpLibrary.WinControls.TabPageEx();
            this.edtVersNrB = new KiSS4.Gui.KissTextEdit();
            this.edtVersNrA = new KiSS4.Gui.KissTextEdit();
            this.lblVersNr = new KiSS4.Gui.KissLabel();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.edtBemerkungB = new KiSS4.Gui.KissRTFEdit();
            this.edtBemerkungA = new KiSS4.Gui.KissRTFEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.ctlGotoFallB = new KiSS4.Common.CtlGotoFall();
            this.ctlGotoFallA = new KiSS4.Common.CtlGotoFall();
            this.btnMigrateA = new KiSS4.Gui.KissButton();
            this.edtBaPersonIdB = new KiSS4.Gui.KissTextEdit();
            this.edtLandB = new KiSS4.Gui.KissTextEdit();
            this.edtGeschlechtB = new KiSS4.Gui.KissTextEdit();
            this.edtNationB = new KiSS4.Gui.KissTextEdit();
            this.edtHeimatortB = new KiSS4.Gui.KissTextEdit();
            this.edtZivilstandB = new KiSS4.Gui.KissTextEdit();
            this.edtOrtWohnsitzB = new KiSS4.Gui.KissTextEdit();
            this.edtPostfachWohnsitzB = new KiSS4.Gui.KissTextEdit();
            this.edtStrasseWohnsitzB = new KiSS4.Gui.KissTextEdit();
            this.edtNameVornameB = new KiSS4.Gui.KissTextEdit();
            this.edtGeburtsdatumB = new KiSS4.Gui.KissDateEdit();
            this.edtAhvNrB = new KiSS4.Gui.KissTextEdit();
            this.edtPersonB = new KiSS4.Gui.KissButtonEdit();
            this.edtBaPersonIdA = new KiSS4.Gui.KissTextEdit();
            this.lblNr = new KiSS4.Gui.KissLabel();
            this.edtLandA = new KiSS4.Gui.KissTextEdit();
            this.edtGeschlechtA = new KiSS4.Gui.KissTextEdit();
            this.edtNationA = new KiSS4.Gui.KissTextEdit();
            this.edtHeimatortA = new KiSS4.Gui.KissTextEdit();
            this.edtZivilstandA = new KiSS4.Gui.KissTextEdit();
            this.edtOrtWohnsitzA = new KiSS4.Gui.KissTextEdit();
            this.edtPostfachWohnsitzA = new KiSS4.Gui.KissTextEdit();
            this.edtStrasseWohnsitzA = new KiSS4.Gui.KissTextEdit();
            this.lblPostfach = new KiSS4.Gui.KissLabel();
            this.lblPlz = new KiSS4.Gui.KissLabel();
            this.lblLand = new KiSS4.Gui.KissLabel();
            this.lblAdresse = new KiSS4.Gui.KissLabel();
            this.edtNameVornameA = new KiSS4.Gui.KissTextEdit();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatumA = new KiSS4.Gui.KissDateEdit();
            this.edtAhvNrA = new KiSS4.Gui.KissTextEdit();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblZivilstand = new KiSS4.Gui.KissLabel();
            this.lblGeschlecht = new KiSS4.Gui.KissLabel();
            this.lblAhvNr = new KiSS4.Gui.KissLabel();
            this.lblNation = new KiSS4.Gui.KissLabel();
            this.lblHeimatort = new KiSS4.Gui.KissLabel();
            this.edtPersonA = new KiSS4.Gui.KissButtonEdit();
            this.lblPersonB = new KiSS4.Gui.KissLabel();
            this.btnMigrateB = new KiSS4.Gui.KissButton();
            this.lblNameSuchen = new KiSS4.Gui.KissLabel();
            this.lblPersonA = new KiSS4.Gui.KissLabel();
            this.tpgProblems = new SharpLibrary.WinControls.TabPageEx();
            this.btnRefresh = new KiSS4.Gui.KissButton();
            this.grdProblems = new KiSS4.Gui.KissGrid();
            this.qryProblems = new KiSS4.DB.SqlQuery(this.components);
            this.grvProblems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProblem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSolution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJumpToPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJumpToPersonA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnJumpToPathA = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colJumpToPersonB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnJumpToPathB = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonB)).BeginInit();
            this.tabDoublePerson.SuspendLayout();
            this.tpgPersons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNrB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNrA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIdB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatortB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtWohnsitzB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfachWohnsitzB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseWohnsitzB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVornameB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatumB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAhvNrB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIdA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatortA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtWohnsitzA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfachWohnsitzA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseWohnsitzA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVornameA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatumA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAhvNrA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAhvNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSuchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonA)).BeginInit();
            this.tpgProblems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProblems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryProblems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProblems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnJumpToPathA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnJumpToPathB)).BeginInit();
            this.SuspendLayout();
            // 
            // qryPersonA
            // 
            this.qryPersonA.CanUpdate = true;
            this.qryPersonA.HostControl = this;
            this.qryPersonA.AfterFill += new System.EventHandler(this.qryPersonA_AfterFill);
            // 
            // qryPersonB
            // 
            this.qryPersonB.CanUpdate = true;
            this.qryPersonB.HostControl = this;
            this.qryPersonB.AfterFill += new System.EventHandler(this.qryPersonB_AfterFill);
            // 
            // tabDoublePerson
            // 
            this.tabDoublePerson.Controls.Add(this.tpgPersons);
            this.tabDoublePerson.Controls.Add(this.tpgProblems);
            this.tabDoublePerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDoublePerson.Location = new System.Drawing.Point(0, 0);
            this.tabDoublePerson.Name = "tabDoublePerson";
            this.tabDoublePerson.ShowFixedWidthTooltip = true;
            this.tabDoublePerson.Size = new System.Drawing.Size(720, 600);
            this.tabDoublePerson.TabIndex = 0;
            this.tabDoublePerson.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgPersons,
            this.tpgProblems});
            this.tabDoublePerson.TabsLineColor = System.Drawing.Color.Black;
            this.tabDoublePerson.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabDoublePerson.Text = "kissTabControlEx1";
            this.tabDoublePerson.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabDoublePerson_SelectedTabChanged);
            // 
            // tpgPersons
            // 
            this.tpgPersons.Controls.Add(this.edtVersNrB);
            this.tpgPersons.Controls.Add(this.edtVersNrA);
            this.tpgPersons.Controls.Add(this.lblVersNr);
            this.tpgPersons.Controls.Add(this.lblStatus);
            this.tpgPersons.Controls.Add(this.edtBemerkungB);
            this.tpgPersons.Controls.Add(this.edtBemerkungA);
            this.tpgPersons.Controls.Add(this.lblBemerkung);
            this.tpgPersons.Controls.Add(this.ctlGotoFallB);
            this.tpgPersons.Controls.Add(this.ctlGotoFallA);
            this.tpgPersons.Controls.Add(this.btnMigrateA);
            this.tpgPersons.Controls.Add(this.edtBaPersonIdB);
            this.tpgPersons.Controls.Add(this.edtLandB);
            this.tpgPersons.Controls.Add(this.edtGeschlechtB);
            this.tpgPersons.Controls.Add(this.edtNationB);
            this.tpgPersons.Controls.Add(this.edtHeimatortB);
            this.tpgPersons.Controls.Add(this.edtZivilstandB);
            this.tpgPersons.Controls.Add(this.edtOrtWohnsitzB);
            this.tpgPersons.Controls.Add(this.edtPostfachWohnsitzB);
            this.tpgPersons.Controls.Add(this.edtStrasseWohnsitzB);
            this.tpgPersons.Controls.Add(this.edtNameVornameB);
            this.tpgPersons.Controls.Add(this.edtGeburtsdatumB);
            this.tpgPersons.Controls.Add(this.edtAhvNrB);
            this.tpgPersons.Controls.Add(this.edtPersonB);
            this.tpgPersons.Controls.Add(this.edtBaPersonIdA);
            this.tpgPersons.Controls.Add(this.lblNr);
            this.tpgPersons.Controls.Add(this.edtLandA);
            this.tpgPersons.Controls.Add(this.edtGeschlechtA);
            this.tpgPersons.Controls.Add(this.edtNationA);
            this.tpgPersons.Controls.Add(this.edtHeimatortA);
            this.tpgPersons.Controls.Add(this.edtZivilstandA);
            this.tpgPersons.Controls.Add(this.edtOrtWohnsitzA);
            this.tpgPersons.Controls.Add(this.edtPostfachWohnsitzA);
            this.tpgPersons.Controls.Add(this.edtStrasseWohnsitzA);
            this.tpgPersons.Controls.Add(this.lblPostfach);
            this.tpgPersons.Controls.Add(this.lblPlz);
            this.tpgPersons.Controls.Add(this.lblLand);
            this.tpgPersons.Controls.Add(this.lblAdresse);
            this.tpgPersons.Controls.Add(this.edtNameVornameA);
            this.tpgPersons.Controls.Add(this.lblName);
            this.tpgPersons.Controls.Add(this.edtGeburtsdatumA);
            this.tpgPersons.Controls.Add(this.edtAhvNrA);
            this.tpgPersons.Controls.Add(this.lblGeburtsdatum);
            this.tpgPersons.Controls.Add(this.lblZivilstand);
            this.tpgPersons.Controls.Add(this.lblGeschlecht);
            this.tpgPersons.Controls.Add(this.lblAhvNr);
            this.tpgPersons.Controls.Add(this.lblNation);
            this.tpgPersons.Controls.Add(this.lblHeimatort);
            this.tpgPersons.Controls.Add(this.edtPersonA);
            this.tpgPersons.Controls.Add(this.lblPersonB);
            this.tpgPersons.Controls.Add(this.btnMigrateB);
            this.tpgPersons.Controls.Add(this.lblNameSuchen);
            this.tpgPersons.Controls.Add(this.lblPersonA);
            this.tpgPersons.Location = new System.Drawing.Point(6, 6);
            this.tpgPersons.Name = "tpgPersons";
            this.tpgPersons.Size = new System.Drawing.Size(708, 562);
            this.tpgPersons.TabIndex = 0;
            this.tpgPersons.Title = "Personen auswählen";
            // 
            // edtVersNrB
            // 
            this.edtVersNrB.DataMember = "Versichertennummer";
            this.edtVersNrB.DataSource = this.qryPersonB;
            this.edtVersNrB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersNrB.Location = new System.Drawing.Point(431, 265);
            this.edtVersNrB.Name = "edtVersNrB";
            this.edtVersNrB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersNrB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersNrB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNrB.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersNrB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersNrB.Properties.Appearance.Options.UseFont = true;
            this.edtVersNrB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersNrB.Properties.ReadOnly = true;
            this.edtVersNrB.Size = new System.Drawing.Size(270, 24);
            this.edtVersNrB.TabIndex = 634;
            // 
            // edtVersNrA
            // 
            this.edtVersNrA.DataMember = "Versichertennummer";
            this.edtVersNrA.DataSource = this.qryPersonA;
            this.edtVersNrA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersNrA.Location = new System.Drawing.Point(132, 265);
            this.edtVersNrA.Name = "edtVersNrA";
            this.edtVersNrA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersNrA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersNrA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNrA.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersNrA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersNrA.Properties.Appearance.Options.UseFont = true;
            this.edtVersNrA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersNrA.Properties.ReadOnly = true;
            this.edtVersNrA.Size = new System.Drawing.Size(270, 24);
            this.edtVersNrA.TabIndex = 633;
            // 
            // lblVersNr
            // 
            this.lblVersNr.ForeColor = System.Drawing.Color.Black;
            this.lblVersNr.Location = new System.Drawing.Point(8, 263);
            this.lblVersNr.Name = "lblVersNr";
            this.lblVersNr.Size = new System.Drawing.Size(118, 24);
            this.lblVersNr.TabIndex = 635;
            this.lblVersNr.Text = "Versichertennr.";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblStatus.Location = new System.Drawing.Point(132, 542);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(569, 20);
            this.lblStatus.TabIndex = 632;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edtBemerkungB
            // 
            this.edtBemerkungB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkungB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBemerkungB.DataMember = "Bemerkung";
            this.edtBemerkungB.DataSource = this.qryPersonB;
            this.edtBemerkungB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBemerkungB.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBemerkungB.Location = new System.Drawing.Point(431, 431);
            this.edtBemerkungB.Name = "edtBemerkungB";
            this.edtBemerkungB.ReadOnly = true;
            this.edtBemerkungB.Size = new System.Drawing.Size(270, 78);
            this.edtBemerkungB.TabIndex = 631;
            // 
            // edtBemerkungA
            // 
            this.edtBemerkungA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkungA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBemerkungA.DataMember = "Bemerkung";
            this.edtBemerkungA.DataSource = this.qryPersonA;
            this.edtBemerkungA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBemerkungA.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBemerkungA.Location = new System.Drawing.Point(132, 431);
            this.edtBemerkungA.Name = "edtBemerkungA";
            this.edtBemerkungA.ReadOnly = true;
            this.edtBemerkungA.Size = new System.Drawing.Size(270, 78);
            this.edtBemerkungA.TabIndex = 630;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.ForeColor = System.Drawing.Color.Black;
            this.lblBemerkung.Location = new System.Drawing.Point(8, 429);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(118, 24);
            this.lblBemerkung.TabIndex = 629;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // ctlGotoFallB
            // 
            this.ctlGotoFallB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlGotoFallB.DataMember = "BaPersonID";
            this.ctlGotoFallB.DataSource = this.qryPersonB;
            this.ctlGotoFallB.Location = new System.Drawing.Point(546, 83);
            this.ctlGotoFallB.Name = "ctlGotoFallB";
            this.ctlGotoFallB.Size = new System.Drawing.Size(155, 24);
            this.ctlGotoFallB.TabIndex = 628;
            // 
            // ctlGotoFallA
            // 
            this.ctlGotoFallA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlGotoFallA.DataMember = "BaPersonID";
            this.ctlGotoFallA.DataSource = this.qryPersonA;
            this.ctlGotoFallA.Location = new System.Drawing.Point(247, 83);
            this.ctlGotoFallA.Name = "ctlGotoFallA";
            this.ctlGotoFallA.Size = new System.Drawing.Size(155, 24);
            this.ctlGotoFallA.TabIndex = 627;
            // 
            // btnMigrateA
            // 
            this.btnMigrateA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMigrateA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMigrateA.IconID = 13;
            this.btnMigrateA.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMigrateA.Location = new System.Drawing.Point(132, 515);
            this.btnMigrateA.Name = "btnMigrateA";
            this.btnMigrateA.Size = new System.Drawing.Size(270, 24);
            this.btnMigrateA.TabIndex = 626;
            this.btnMigrateA.Text = "Person A löschen und Daten zu B migrieren";
            this.btnMigrateA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMigrateA.UseVisualStyleBackColor = false;
            this.btnMigrateA.Click += new System.EventHandler(this.btnMigrateA_Click);
            // 
            // edtBaPersonIdB
            // 
            this.edtBaPersonIdB.DataMember = "BaPersonID";
            this.edtBaPersonIdB.DataSource = this.qryPersonB;
            this.edtBaPersonIdB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonIdB.Location = new System.Drawing.Point(431, 83);
            this.edtBaPersonIdB.Name = "edtBaPersonIdB";
            this.edtBaPersonIdB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonIdB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonIdB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonIdB.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonIdB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonIdB.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonIdB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonIdB.Properties.ReadOnly = true;
            this.edtBaPersonIdB.Size = new System.Drawing.Size(93, 24);
            this.edtBaPersonIdB.TabIndex = 602;
            // 
            // edtLandB
            // 
            this.edtLandB.DataMember = "WohnsitzLand";
            this.edtLandB.DataSource = this.qryPersonB;
            this.edtLandB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLandB.Location = new System.Drawing.Point(431, 212);
            this.edtLandB.Name = "edtLandB";
            this.edtLandB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLandB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLandB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLandB.Properties.Appearance.Options.UseBackColor = true;
            this.edtLandB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLandB.Properties.Appearance.Options.UseFont = true;
            this.edtLandB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLandB.Properties.ReadOnly = true;
            this.edtLandB.Size = new System.Drawing.Size(270, 24);
            this.edtLandB.TabIndex = 607;
            // 
            // edtGeschlechtB
            // 
            this.edtGeschlechtB.DataMember = "Geschlecht";
            this.edtGeschlechtB.DataSource = this.qryPersonB;
            this.edtGeschlechtB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeschlechtB.Location = new System.Drawing.Point(431, 295);
            this.edtGeschlechtB.Name = "edtGeschlechtB";
            this.edtGeschlechtB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeschlechtB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlechtB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtB.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlechtB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlechtB.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlechtB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeschlechtB.Properties.ReadOnly = true;
            this.edtGeschlechtB.Size = new System.Drawing.Size(270, 24);
            this.edtGeschlechtB.TabIndex = 609;
            // 
            // edtNationB
            // 
            this.edtNationB.DataMember = "Nationalitaet";
            this.edtNationB.DataSource = this.qryPersonB;
            this.edtNationB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNationB.Location = new System.Drawing.Point(431, 355);
            this.edtNationB.Name = "edtNationB";
            this.edtNationB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNationB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationB.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationB.Properties.Appearance.Options.UseFont = true;
            this.edtNationB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNationB.Properties.ReadOnly = true;
            this.edtNationB.Size = new System.Drawing.Size(270, 24);
            this.edtNationB.TabIndex = 611;
            // 
            // edtHeimatortB
            // 
            this.edtHeimatortB.DataMember = "Heimatort";
            this.edtHeimatortB.DataSource = this.qryPersonB;
            this.edtHeimatortB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHeimatortB.Location = new System.Drawing.Point(431, 378);
            this.edtHeimatortB.Name = "edtHeimatortB";
            this.edtHeimatortB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHeimatortB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatortB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatortB.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatortB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatortB.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatortB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHeimatortB.Properties.ReadOnly = true;
            this.edtHeimatortB.Size = new System.Drawing.Size(270, 24);
            this.edtHeimatortB.TabIndex = 612;
            // 
            // edtZivilstandB
            // 
            this.edtZivilstandB.DataMember = "Zivilstand";
            this.edtZivilstandB.DataSource = this.qryPersonB;
            this.edtZivilstandB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZivilstandB.Location = new System.Drawing.Point(431, 401);
            this.edtZivilstandB.Name = "edtZivilstandB";
            this.edtZivilstandB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZivilstandB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZivilstandB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandB.Properties.Appearance.Options.UseBackColor = true;
            this.edtZivilstandB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZivilstandB.Properties.Appearance.Options.UseFont = true;
            this.edtZivilstandB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZivilstandB.Properties.ReadOnly = true;
            this.edtZivilstandB.Size = new System.Drawing.Size(270, 24);
            this.edtZivilstandB.TabIndex = 613;
            // 
            // edtOrtWohnsitzB
            // 
            this.edtOrtWohnsitzB.DataMember = "WohnsitzPLZOrt";
            this.edtOrtWohnsitzB.DataSource = this.qryPersonB;
            this.edtOrtWohnsitzB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOrtWohnsitzB.Location = new System.Drawing.Point(431, 189);
            this.edtOrtWohnsitzB.Name = "edtOrtWohnsitzB";
            this.edtOrtWohnsitzB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOrtWohnsitzB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrtWohnsitzB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrtWohnsitzB.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrtWohnsitzB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrtWohnsitzB.Properties.Appearance.Options.UseFont = true;
            this.edtOrtWohnsitzB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrtWohnsitzB.Properties.ReadOnly = true;
            this.edtOrtWohnsitzB.Size = new System.Drawing.Size(270, 24);
            this.edtOrtWohnsitzB.TabIndex = 606;
            // 
            // edtPostfachWohnsitzB
            // 
            this.edtPostfachWohnsitzB.DataMember = "WohnsitzPostfach";
            this.edtPostfachWohnsitzB.DataSource = this.qryPersonB;
            this.edtPostfachWohnsitzB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPostfachWohnsitzB.Location = new System.Drawing.Point(431, 166);
            this.edtPostfachWohnsitzB.Name = "edtPostfachWohnsitzB";
            this.edtPostfachWohnsitzB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPostfachWohnsitzB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostfachWohnsitzB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostfachWohnsitzB.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostfachWohnsitzB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostfachWohnsitzB.Properties.Appearance.Options.UseFont = true;
            this.edtPostfachWohnsitzB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostfachWohnsitzB.Properties.ReadOnly = true;
            this.edtPostfachWohnsitzB.Size = new System.Drawing.Size(270, 24);
            this.edtPostfachWohnsitzB.TabIndex = 605;
            // 
            // edtStrasseWohnsitzB
            // 
            this.edtStrasseWohnsitzB.DataMember = "WohnsitzStrasseHausNr";
            this.edtStrasseWohnsitzB.DataSource = this.qryPersonB;
            this.edtStrasseWohnsitzB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasseWohnsitzB.Location = new System.Drawing.Point(431, 143);
            this.edtStrasseWohnsitzB.Name = "edtStrasseWohnsitzB";
            this.edtStrasseWohnsitzB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStrasseWohnsitzB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseWohnsitzB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseWohnsitzB.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseWohnsitzB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseWohnsitzB.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseWohnsitzB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasseWohnsitzB.Properties.ReadOnly = true;
            this.edtStrasseWohnsitzB.Size = new System.Drawing.Size(270, 24);
            this.edtStrasseWohnsitzB.TabIndex = 604;
            // 
            // edtNameVornameB
            // 
            this.edtNameVornameB.DataMember = "NameVorname";
            this.edtNameVornameB.DataSource = this.qryPersonB;
            this.edtNameVornameB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameVornameB.Location = new System.Drawing.Point(431, 113);
            this.edtNameVornameB.Name = "edtNameVornameB";
            this.edtNameVornameB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNameVornameB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameVornameB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameVornameB.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameVornameB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameVornameB.Properties.Appearance.Options.UseFont = true;
            this.edtNameVornameB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameVornameB.Properties.ReadOnly = true;
            this.edtNameVornameB.Size = new System.Drawing.Size(270, 24);
            this.edtNameVornameB.TabIndex = 603;
            // 
            // edtGeburtsdatumB
            // 
            this.edtGeburtsdatumB.DataMember = "Geburtsdatum";
            this.edtGeburtsdatumB.DataSource = this.qryPersonB;
            this.edtGeburtsdatumB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeburtsdatumB.EditValue = null;
            this.edtGeburtsdatumB.Location = new System.Drawing.Point(431, 325);
            this.edtGeburtsdatumB.Name = "edtGeburtsdatumB";
            this.edtGeburtsdatumB.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatumB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeburtsdatumB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatumB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatumB.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatumB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatumB.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatumB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGeburtsdatumB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatumB.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGeburtsdatumB.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatumB.Properties.ReadOnly = true;
            this.edtGeburtsdatumB.Properties.ShowToday = false;
            this.edtGeburtsdatumB.Size = new System.Drawing.Size(95, 24);
            this.edtGeburtsdatumB.TabIndex = 610;
            // 
            // edtAhvNrB
            // 
            this.edtAhvNrB.DataMember = "AHVNummer";
            this.edtAhvNrB.DataSource = this.qryPersonB;
            this.edtAhvNrB.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAhvNrB.Location = new System.Drawing.Point(431, 242);
            this.edtAhvNrB.Name = "edtAhvNrB";
            this.edtAhvNrB.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAhvNrB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAhvNrB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAhvNrB.Properties.Appearance.Options.UseBackColor = true;
            this.edtAhvNrB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAhvNrB.Properties.Appearance.Options.UseFont = true;
            this.edtAhvNrB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAhvNrB.Properties.ReadOnly = true;
            this.edtAhvNrB.Size = new System.Drawing.Size(270, 24);
            this.edtAhvNrB.TabIndex = 608;
            // 
            // edtPersonB
            // 
            this.edtPersonB.DataMember = "NrNameVorname";
            this.edtPersonB.DataSource = this.qryPersonB;
            this.edtPersonB.Location = new System.Drawing.Point(431, 43);
            this.edtPersonB.Name = "edtPersonB";
            this.edtPersonB.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonB.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtPersonB.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonB.Properties.Appearance.Options.UseFont = true;
            this.edtPersonB.Properties.Appearance.Options.UseForeColor = true;
            this.edtPersonB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtPersonB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtPersonB.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonB.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtPersonB.Size = new System.Drawing.Size(270, 24);
            this.edtPersonB.TabIndex = 585;
            this.edtPersonB.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editPersonID_UserModifiedFld);
            // 
            // edtBaPersonIdA
            // 
            this.edtBaPersonIdA.DataMember = "BaPersonID";
            this.edtBaPersonIdA.DataSource = this.qryPersonA;
            this.edtBaPersonIdA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonIdA.Location = new System.Drawing.Point(132, 83);
            this.edtBaPersonIdA.Name = "edtBaPersonIdA";
            this.edtBaPersonIdA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonIdA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonIdA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonIdA.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonIdA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonIdA.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonIdA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonIdA.Properties.ReadOnly = true;
            this.edtBaPersonIdA.Size = new System.Drawing.Size(93, 24);
            this.edtBaPersonIdA.TabIndex = 587;
            // 
            // lblNr
            // 
            this.lblNr.ForeColor = System.Drawing.Color.Black;
            this.lblNr.Location = new System.Drawing.Point(8, 83);
            this.lblNr.Name = "lblNr";
            this.lblNr.Size = new System.Drawing.Size(118, 24);
            this.lblNr.TabIndex = 625;
            this.lblNr.Text = "Nr";
            // 
            // edtLandA
            // 
            this.edtLandA.DataMember = "WohnsitzLand";
            this.edtLandA.DataSource = this.qryPersonA;
            this.edtLandA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLandA.Location = new System.Drawing.Point(132, 212);
            this.edtLandA.Name = "edtLandA";
            this.edtLandA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLandA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLandA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLandA.Properties.Appearance.Options.UseBackColor = true;
            this.edtLandA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLandA.Properties.Appearance.Options.UseFont = true;
            this.edtLandA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLandA.Properties.ReadOnly = true;
            this.edtLandA.Size = new System.Drawing.Size(270, 24);
            this.edtLandA.TabIndex = 595;
            // 
            // edtGeschlechtA
            // 
            this.edtGeschlechtA.DataMember = "Geschlecht";
            this.edtGeschlechtA.DataSource = this.qryPersonA;
            this.edtGeschlechtA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeschlechtA.Location = new System.Drawing.Point(132, 295);
            this.edtGeschlechtA.Name = "edtGeschlechtA";
            this.edtGeschlechtA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeschlechtA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeschlechtA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeschlechtA.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeschlechtA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeschlechtA.Properties.Appearance.Options.UseFont = true;
            this.edtGeschlechtA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeschlechtA.Properties.ReadOnly = true;
            this.edtGeschlechtA.Size = new System.Drawing.Size(270, 24);
            this.edtGeschlechtA.TabIndex = 597;
            // 
            // edtNationA
            // 
            this.edtNationA.DataMember = "Nationalitaet";
            this.edtNationA.DataSource = this.qryPersonA;
            this.edtNationA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNationA.Location = new System.Drawing.Point(132, 355);
            this.edtNationA.Name = "edtNationA";
            this.edtNationA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNationA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationA.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationA.Properties.Appearance.Options.UseFont = true;
            this.edtNationA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNationA.Properties.ReadOnly = true;
            this.edtNationA.Size = new System.Drawing.Size(270, 24);
            this.edtNationA.TabIndex = 599;
            // 
            // edtHeimatortA
            // 
            this.edtHeimatortA.DataMember = "Heimatort";
            this.edtHeimatortA.DataSource = this.qryPersonA;
            this.edtHeimatortA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHeimatortA.Location = new System.Drawing.Point(132, 378);
            this.edtHeimatortA.Name = "edtHeimatortA";
            this.edtHeimatortA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHeimatortA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHeimatortA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHeimatortA.Properties.Appearance.Options.UseBackColor = true;
            this.edtHeimatortA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHeimatortA.Properties.Appearance.Options.UseFont = true;
            this.edtHeimatortA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHeimatortA.Properties.ReadOnly = true;
            this.edtHeimatortA.Size = new System.Drawing.Size(270, 24);
            this.edtHeimatortA.TabIndex = 600;
            // 
            // edtZivilstandA
            // 
            this.edtZivilstandA.DataMember = "Zivilstand";
            this.edtZivilstandA.DataSource = this.qryPersonA;
            this.edtZivilstandA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZivilstandA.Location = new System.Drawing.Point(132, 401);
            this.edtZivilstandA.Name = "edtZivilstandA";
            this.edtZivilstandA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZivilstandA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZivilstandA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZivilstandA.Properties.Appearance.Options.UseBackColor = true;
            this.edtZivilstandA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZivilstandA.Properties.Appearance.Options.UseFont = true;
            this.edtZivilstandA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZivilstandA.Properties.ReadOnly = true;
            this.edtZivilstandA.Size = new System.Drawing.Size(270, 24);
            this.edtZivilstandA.TabIndex = 601;
            // 
            // edtOrtWohnsitzA
            // 
            this.edtOrtWohnsitzA.DataMember = "WohnsitzPLZOrt";
            this.edtOrtWohnsitzA.DataSource = this.qryPersonA;
            this.edtOrtWohnsitzA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOrtWohnsitzA.Location = new System.Drawing.Point(132, 189);
            this.edtOrtWohnsitzA.Name = "edtOrtWohnsitzA";
            this.edtOrtWohnsitzA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOrtWohnsitzA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrtWohnsitzA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrtWohnsitzA.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrtWohnsitzA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrtWohnsitzA.Properties.Appearance.Options.UseFont = true;
            this.edtOrtWohnsitzA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrtWohnsitzA.Properties.ReadOnly = true;
            this.edtOrtWohnsitzA.Size = new System.Drawing.Size(270, 24);
            this.edtOrtWohnsitzA.TabIndex = 593;
            // 
            // edtPostfachWohnsitzA
            // 
            this.edtPostfachWohnsitzA.DataMember = "WohnsitzPostfach";
            this.edtPostfachWohnsitzA.DataSource = this.qryPersonA;
            this.edtPostfachWohnsitzA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPostfachWohnsitzA.Location = new System.Drawing.Point(132, 166);
            this.edtPostfachWohnsitzA.Name = "edtPostfachWohnsitzA";
            this.edtPostfachWohnsitzA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPostfachWohnsitzA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostfachWohnsitzA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostfachWohnsitzA.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostfachWohnsitzA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostfachWohnsitzA.Properties.Appearance.Options.UseFont = true;
            this.edtPostfachWohnsitzA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostfachWohnsitzA.Properties.ReadOnly = true;
            this.edtPostfachWohnsitzA.Size = new System.Drawing.Size(270, 24);
            this.edtPostfachWohnsitzA.TabIndex = 590;
            // 
            // edtStrasseWohnsitzA
            // 
            this.edtStrasseWohnsitzA.DataMember = "WohnsitzStrasseHausNr";
            this.edtStrasseWohnsitzA.DataSource = this.qryPersonA;
            this.edtStrasseWohnsitzA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasseWohnsitzA.Location = new System.Drawing.Point(132, 143);
            this.edtStrasseWohnsitzA.Name = "edtStrasseWohnsitzA";
            this.edtStrasseWohnsitzA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStrasseWohnsitzA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseWohnsitzA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseWohnsitzA.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseWohnsitzA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseWohnsitzA.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseWohnsitzA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasseWohnsitzA.Properties.ReadOnly = true;
            this.edtStrasseWohnsitzA.Size = new System.Drawing.Size(270, 24);
            this.edtStrasseWohnsitzA.TabIndex = 589;
            // 
            // lblPostfach
            // 
            this.lblPostfach.ForeColor = System.Drawing.Color.Black;
            this.lblPostfach.Location = new System.Drawing.Point(8, 166);
            this.lblPostfach.Name = "lblPostfach";
            this.lblPostfach.Size = new System.Drawing.Size(118, 24);
            this.lblPostfach.TabIndex = 624;
            this.lblPostfach.Text = "Postfach";
            // 
            // lblPlz
            // 
            this.lblPlz.ForeColor = System.Drawing.Color.Black;
            this.lblPlz.Location = new System.Drawing.Point(8, 189);
            this.lblPlz.Name = "lblPlz";
            this.lblPlz.Size = new System.Drawing.Size(118, 24);
            this.lblPlz.TabIndex = 623;
            this.lblPlz.Text = "PLZ / Ort";
            // 
            // lblLand
            // 
            this.lblLand.ForeColor = System.Drawing.Color.Black;
            this.lblLand.Location = new System.Drawing.Point(8, 212);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(118, 24);
            this.lblLand.TabIndex = 622;
            this.lblLand.Text = "Land";
            // 
            // lblAdresse
            // 
            this.lblAdresse.ForeColor = System.Drawing.Color.Black;
            this.lblAdresse.Location = new System.Drawing.Point(8, 143);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(118, 24);
            this.lblAdresse.TabIndex = 621;
            this.lblAdresse.Text = "Strasse / Nr";
            // 
            // edtNameVornameA
            // 
            this.edtNameVornameA.DataMember = "NameVorname";
            this.edtNameVornameA.DataSource = this.qryPersonA;
            this.edtNameVornameA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameVornameA.Location = new System.Drawing.Point(132, 113);
            this.edtNameVornameA.Name = "edtNameVornameA";
            this.edtNameVornameA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNameVornameA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameVornameA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameVornameA.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameVornameA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameVornameA.Properties.Appearance.Options.UseFont = true;
            this.edtNameVornameA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameVornameA.Properties.ReadOnly = true;
            this.edtNameVornameA.Size = new System.Drawing.Size(270, 24);
            this.edtNameVornameA.TabIndex = 588;
            // 
            // lblName
            // 
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(8, 113);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(118, 24);
            this.lblName.TabIndex = 620;
            this.lblName.Text = "Name";
            // 
            // edtGeburtsdatumA
            // 
            this.edtGeburtsdatumA.DataMember = "Geburtsdatum";
            this.edtGeburtsdatumA.DataSource = this.qryPersonA;
            this.edtGeburtsdatumA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeburtsdatumA.EditValue = null;
            this.edtGeburtsdatumA.Location = new System.Drawing.Point(132, 325);
            this.edtGeburtsdatumA.Name = "edtGeburtsdatumA";
            this.edtGeburtsdatumA.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatumA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeburtsdatumA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatumA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatumA.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatumA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatumA.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatumA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGeburtsdatumA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatumA.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGeburtsdatumA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatumA.Properties.ReadOnly = true;
            this.edtGeburtsdatumA.Properties.ShowToday = false;
            this.edtGeburtsdatumA.Size = new System.Drawing.Size(95, 24);
            this.edtGeburtsdatumA.TabIndex = 598;
            // 
            // edtAhvNrA
            // 
            this.edtAhvNrA.DataMember = "AHVNummer";
            this.edtAhvNrA.DataSource = this.qryPersonA;
            this.edtAhvNrA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAhvNrA.Location = new System.Drawing.Point(132, 242);
            this.edtAhvNrA.Name = "edtAhvNrA";
            this.edtAhvNrA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAhvNrA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAhvNrA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAhvNrA.Properties.Appearance.Options.UseBackColor = true;
            this.edtAhvNrA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAhvNrA.Properties.Appearance.Options.UseFont = true;
            this.edtAhvNrA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAhvNrA.Properties.ReadOnly = true;
            this.edtAhvNrA.Size = new System.Drawing.Size(270, 24);
            this.edtAhvNrA.TabIndex = 596;
            // 
            // lblGeburtsdatum
            // 
            this.lblGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.lblGeburtsdatum.Location = new System.Drawing.Point(8, 325);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(118, 24);
            this.lblGeburtsdatum.TabIndex = 619;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            // 
            // lblZivilstand
            // 
            this.lblZivilstand.ForeColor = System.Drawing.Color.Black;
            this.lblZivilstand.Location = new System.Drawing.Point(8, 401);
            this.lblZivilstand.Name = "lblZivilstand";
            this.lblZivilstand.Size = new System.Drawing.Size(118, 24);
            this.lblZivilstand.TabIndex = 618;
            this.lblZivilstand.Text = "Zivilstand";
            // 
            // lblGeschlecht
            // 
            this.lblGeschlecht.ForeColor = System.Drawing.Color.Black;
            this.lblGeschlecht.Location = new System.Drawing.Point(8, 295);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(118, 24);
            this.lblGeschlecht.TabIndex = 617;
            this.lblGeschlecht.Text = "Geschlecht";
            // 
            // lblAhvNr
            // 
            this.lblAhvNr.ForeColor = System.Drawing.Color.Black;
            this.lblAhvNr.Location = new System.Drawing.Point(8, 242);
            this.lblAhvNr.Name = "lblAhvNr";
            this.lblAhvNr.Size = new System.Drawing.Size(118, 24);
            this.lblAhvNr.TabIndex = 616;
            this.lblAhvNr.Text = "AVH-Nr";
            // 
            // lblNation
            // 
            this.lblNation.ForeColor = System.Drawing.Color.Black;
            this.lblNation.Location = new System.Drawing.Point(8, 355);
            this.lblNation.Name = "lblNation";
            this.lblNation.Size = new System.Drawing.Size(118, 24);
            this.lblNation.TabIndex = 615;
            this.lblNation.Text = "Nation";
            // 
            // lblHeimatort
            // 
            this.lblHeimatort.ForeColor = System.Drawing.Color.Black;
            this.lblHeimatort.Location = new System.Drawing.Point(8, 378);
            this.lblHeimatort.Name = "lblHeimatort";
            this.lblHeimatort.Size = new System.Drawing.Size(118, 24);
            this.lblHeimatort.TabIndex = 614;
            this.lblHeimatort.Text = "Heimatort";
            // 
            // edtPersonA
            // 
            this.edtPersonA.DataMember = "NrNameVorname";
            this.edtPersonA.DataSource = this.qryPersonA;
            this.edtPersonA.Location = new System.Drawing.Point(132, 43);
            this.edtPersonA.Name = "edtPersonA";
            this.edtPersonA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersonA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersonA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersonA.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtPersonA.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersonA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersonA.Properties.Appearance.Options.UseFont = true;
            this.edtPersonA.Properties.Appearance.Options.UseForeColor = true;
            this.edtPersonA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtPersonA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtPersonA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPersonA.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtPersonA.Size = new System.Drawing.Size(270, 24);
            this.edtPersonA.TabIndex = 584;
            this.edtPersonA.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editPersonID_UserModifiedFld);
            // 
            // lblPersonB
            // 
            this.lblPersonB.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblPersonB.Location = new System.Drawing.Point(428, 13);
            this.lblPersonB.Name = "lblPersonB";
            this.lblPersonB.Size = new System.Drawing.Size(273, 16);
            this.lblPersonB.TabIndex = 594;
            this.lblPersonB.Text = "Person B";
            // 
            // btnMigrateB
            // 
            this.btnMigrateB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMigrateB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMigrateB.IconID = 11;
            this.btnMigrateB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMigrateB.Location = new System.Drawing.Point(431, 515);
            this.btnMigrateB.Name = "btnMigrateB";
            this.btnMigrateB.Size = new System.Drawing.Size(270, 24);
            this.btnMigrateB.TabIndex = 586;
            this.btnMigrateB.Text = "Person B löschen und Daten zu A migrieren";
            this.btnMigrateB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMigrateB.UseVisualStyleBackColor = false;
            this.btnMigrateB.Click += new System.EventHandler(this.btnMigrateB_Click);
            // 
            // lblNameSuchen
            // 
            this.lblNameSuchen.Location = new System.Drawing.Point(8, 43);
            this.lblNameSuchen.Name = "lblNameSuchen";
            this.lblNameSuchen.Size = new System.Drawing.Size(118, 24);
            this.lblNameSuchen.TabIndex = 592;
            this.lblNameSuchen.Text = "nach Nr/Name suchen";
            // 
            // lblPersonA
            // 
            this.lblPersonA.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblPersonA.Location = new System.Drawing.Point(129, 13);
            this.lblPersonA.Name = "lblPersonA";
            this.lblPersonA.Size = new System.Drawing.Size(273, 16);
            this.lblPersonA.TabIndex = 591;
            this.lblPersonA.Text = "Person A";
            // 
            // tpgProblems
            // 
            this.tpgProblems.Controls.Add(this.btnRefresh);
            this.tpgProblems.Controls.Add(this.grdProblems);
            this.tpgProblems.Location = new System.Drawing.Point(6, 6);
            this.tpgProblems.Name = "tpgProblems";
            this.tpgProblems.Size = new System.Drawing.Size(708, 562);
            this.tpgProblems.TabIndex = 1;
            this.tpgProblems.Title = "Erkannte Probleme";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(3, 535);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 24);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Aktualisieren";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grdProblems
            // 
            this.grdProblems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProblems.DataSource = this.qryProblems;
            // 
            // 
            // 
            this.grdProblems.EmbeddedNavigator.Name = "";
            this.grdProblems.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdProblems.Location = new System.Drawing.Point(3, 3);
            this.grdProblems.MainView = this.grvProblems;
            this.grdProblems.Name = "grdProblems";
            this.grdProblems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnJumpToPathA,
            this.btnJumpToPathB});
            this.grdProblems.Size = new System.Drawing.Size(702, 526);
            this.grdProblems.TabIndex = 0;
            this.grdProblems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProblems});
            // 
            // qryProblems
            // 
            this.qryProblems.HostControl = this;
            this.qryProblems.SelectStatement = "SELECT *\r\nFROM dbo.fnXRowMerge_PersonCheck({0}, {1}, {2}, {3});\r\n";
            // 
            // grvProblems
            // 
            this.grvProblems.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvProblems.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProblems.Appearance.Empty.Options.UseBackColor = true;
            this.grvProblems.Appearance.Empty.Options.UseFont = true;
            this.grvProblems.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvProblems.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProblems.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvProblems.Appearance.EvenRow.Options.UseFont = true;
            this.grvProblems.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProblems.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProblems.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvProblems.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvProblems.Appearance.FocusedCell.Options.UseFont = true;
            this.grvProblems.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvProblems.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProblems.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProblems.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvProblems.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvProblems.Appearance.FocusedRow.Options.UseFont = true;
            this.grvProblems.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvProblems.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProblems.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvProblems.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProblems.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProblems.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProblems.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvProblems.Appearance.GroupRow.Options.UseFont = true;
            this.grvProblems.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvProblems.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvProblems.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvProblems.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProblems.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvProblems.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvProblems.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProblems.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvProblems.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProblems.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProblems.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvProblems.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvProblems.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvProblems.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvProblems.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvProblems.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProblems.Appearance.OddRow.Options.UseFont = true;
            this.grvProblems.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvProblems.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProblems.Appearance.Row.Options.UseBackColor = true;
            this.grvProblems.Appearance.Row.Options.UseFont = true;
            this.grvProblems.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvProblems.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProblems.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvProblems.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvProblems.Appearance.SelectedRow.Options.UseFont = true;
            this.grvProblems.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvProblems.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvProblems.Appearance.VertLine.Options.UseBackColor = true;
            this.grvProblems.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvProblems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProblem,
            this.colSolution,
            this.colJumpToPath,
            this.colJumpToPersonA,
            this.colJumpToPersonB});
            this.grvProblems.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvProblems.GridControl = this.grdProblems;
            this.grvProblems.Name = "grvProblems";
            this.grvProblems.OptionsBehavior.Editable = false;
            this.grvProblems.OptionsCustomization.AllowFilter = false;
            this.grvProblems.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvProblems.OptionsNavigation.AutoFocusNewRow = true;
            this.grvProblems.OptionsNavigation.UseTabKey = false;
            this.grvProblems.OptionsView.ColumnAutoWidth = false;
            this.grvProblems.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvProblems.OptionsView.ShowGroupPanel = false;
            this.grvProblems.OptionsView.ShowIndicator = false;
            // 
            // colProblem
            // 
            this.colProblem.Caption = "Problem";
            this.colProblem.FieldName = "Problem";
            this.colProblem.Name = "colProblem";
            this.colProblem.OptionsColumn.AllowEdit = false;
            this.colProblem.Visible = true;
            this.colProblem.VisibleIndex = 0;
            this.colProblem.Width = 150;
            // 
            // colSolution
            // 
            this.colSolution.Caption = "Lösung";
            this.colSolution.FieldName = "Solution";
            this.colSolution.Name = "colSolution";
            this.colSolution.OptionsColumn.AllowEdit = false;
            this.colSolution.Visible = true;
            this.colSolution.VisibleIndex = 1;
            this.colSolution.Width = 316;
            // 
            // colJumpToPath
            // 
            this.colJumpToPath.Caption = "JumpToPath";
            this.colJumpToPath.FieldName = "JumpToPath";
            this.colJumpToPath.Name = "colJumpToPath";
            // 
            // colJumpToPersonA
            // 
            this.colJumpToPersonA.Caption = "Person A";
            this.colJumpToPersonA.ColumnEdit = this.btnJumpToPathA;
            this.colJumpToPersonA.Name = "colJumpToPersonA";
            this.colJumpToPersonA.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colJumpToPersonA.OptionsColumn.AllowMove = false;
            this.colJumpToPersonA.OptionsColumn.FixedWidth = true;
            this.colJumpToPersonA.OptionsColumn.ReadOnly = true;
            this.colJumpToPersonA.ToolTip = "Absprung zur entsprechenden Maske der Person A";
            this.colJumpToPersonA.Visible = true;
            this.colJumpToPersonA.VisibleIndex = 2;
            // 
            // btnJumpToPathA
            // 
            this.btnJumpToPathA.AutoHeight = false;
            this.btnJumpToPathA.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Left, "Maske", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "Absprung zur entsprechenden Maske der Person A")});
            this.btnJumpToPathA.Name = "btnJumpToPathA";
            this.btnJumpToPathA.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnJumpToPathA.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnJumpToPathA_ButtonClick);
            // 
            // colJumpToPersonB
            // 
            this.colJumpToPersonB.Caption = "Person B";
            this.colJumpToPersonB.ColumnEdit = this.btnJumpToPathB;
            this.colJumpToPersonB.FieldName = "JumpToPersonBText";
            this.colJumpToPersonB.Name = "colJumpToPersonB";
            this.colJumpToPersonB.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colJumpToPersonB.OptionsColumn.AllowMove = false;
            this.colJumpToPersonB.OptionsColumn.FixedWidth = true;
            this.colJumpToPersonB.OptionsColumn.ReadOnly = true;
            this.colJumpToPersonB.ToolTip = "Absprung zur entsprechenden Maske der Person B";
            this.colJumpToPersonB.Visible = true;
            this.colJumpToPersonB.VisibleIndex = 3;
            // 
            // btnJumpToPathB
            // 
            this.btnJumpToPathB.AutoHeight = false;
            this.btnJumpToPathB.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right, "Maske", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "Absprung zur entsprechenden Maske der Person B")});
            this.btnJumpToPathB.Name = "btnJumpToPathB";
            this.btnJumpToPathB.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnJumpToPathB.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnJumpToPathB_ButtonClick);
            // 
            // CtlDoublePerson
            // 
            this.Controls.Add(this.tabDoublePerson);
            this.Name = "CtlDoublePerson";
            this.Size = new System.Drawing.Size(720, 600);
            this.Load += new System.EventHandler(this.CtlDoublePerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPersonB)).EndInit();
            this.tabDoublePerson.ResumeLayout(false);
            this.tpgPersons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNrB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNrA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIdB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatortB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtWohnsitzB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfachWohnsitzB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseWohnsitzB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVornameB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatumB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAhvNrB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIdA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLandA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlechtA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatortA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstandA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtWohnsitzA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfachWohnsitzA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseWohnsitzA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostfach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPlz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAdresse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameVornameA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatumA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAhvNrA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAhvNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersonA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSuchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPersonA)).EndInit();
            this.tpgProblems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProblems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryProblems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProblems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnJumpToPathA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnJumpToPathB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private KiSS4.DB.SqlQuery qryPersonA;
        private KiSS4.DB.SqlQuery qryPersonB;
        private Gui.KissTabControlEx tabDoublePerson;
        private SharpLibrary.WinControls.TabPageEx tpgPersons;
        private Gui.KissTextEdit edtVersNrB;
        private Gui.KissTextEdit edtVersNrA;
        private Gui.KissLabel lblVersNr;
        private Gui.KissLabel lblStatus;
        private Gui.KissRTFEdit edtBemerkungB;
        private Gui.KissRTFEdit edtBemerkungA;
        private Gui.KissLabel lblBemerkung;
        private Common.CtlGotoFall ctlGotoFallB;
        private Common.CtlGotoFall ctlGotoFallA;
        private Gui.KissButton btnMigrateA;
        private Gui.KissTextEdit edtBaPersonIdB;
        private Gui.KissTextEdit edtLandB;
        private Gui.KissTextEdit edtGeschlechtB;
        private Gui.KissTextEdit edtNationB;
        private Gui.KissTextEdit edtHeimatortB;
        private Gui.KissTextEdit edtZivilstandB;
        private Gui.KissTextEdit edtOrtWohnsitzB;
        private Gui.KissTextEdit edtPostfachWohnsitzB;
        private Gui.KissTextEdit edtStrasseWohnsitzB;
        private Gui.KissTextEdit edtNameVornameB;
        private Gui.KissDateEdit edtGeburtsdatumB;
        private Gui.KissTextEdit edtAhvNrB;
        private Gui.KissButtonEdit edtPersonB;
        private Gui.KissTextEdit edtBaPersonIdA;
        private Gui.KissLabel lblNr;
        private Gui.KissTextEdit edtLandA;
        private Gui.KissTextEdit edtGeschlechtA;
        private Gui.KissTextEdit edtNationA;
        private Gui.KissTextEdit edtHeimatortA;
        private Gui.KissTextEdit edtZivilstandA;
        private Gui.KissTextEdit edtOrtWohnsitzA;
        private Gui.KissTextEdit edtPostfachWohnsitzA;
        private Gui.KissTextEdit edtStrasseWohnsitzA;
        private Gui.KissLabel lblPostfach;
        private Gui.KissLabel lblPlz;
        private Gui.KissLabel lblLand;
        private Gui.KissLabel lblAdresse;
        private Gui.KissTextEdit edtNameVornameA;
        private Gui.KissLabel lblName;
        private Gui.KissDateEdit edtGeburtsdatumA;
        private Gui.KissTextEdit edtAhvNrA;
        private Gui.KissLabel lblGeburtsdatum;
        private Gui.KissLabel lblZivilstand;
        private Gui.KissLabel lblGeschlecht;
        private Gui.KissLabel lblAhvNr;
        private Gui.KissLabel lblNation;
        private Gui.KissLabel lblHeimatort;
        private Gui.KissButtonEdit edtPersonA;
        private Gui.KissLabel lblPersonB;
        private Gui.KissButton btnMigrateB;
        private Gui.KissLabel lblNameSuchen;
        private Gui.KissLabel lblPersonA;
        private SharpLibrary.WinControls.TabPageEx tpgProblems;
        private Gui.KissButton btnRefresh;
        private Gui.KissGrid grdProblems;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProblems;
        private DB.SqlQuery qryProblems;
        private DevExpress.XtraGrid.Columns.GridColumn colProblem;
        private DevExpress.XtraGrid.Columns.GridColumn colSolution;
        private DevExpress.XtraGrid.Columns.GridColumn colJumpToPath;
        private DevExpress.XtraGrid.Columns.GridColumn colJumpToPersonA;
        private DevExpress.XtraGrid.Columns.GridColumn colJumpToPersonB;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnJumpToPathA;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnJumpToPathB;
    }
}
