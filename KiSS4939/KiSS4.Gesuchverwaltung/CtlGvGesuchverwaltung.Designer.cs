namespace KiSS4.Gesuchverwaltung
{
    partial class CtlGvGesuchverwaltung
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlGvGesuchverwaltung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTitel = new System.Windows.Forms.Panel();
            this.lblTitelInfo = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdGesuch = new KiSS4.Gui.KissGrid();
            this.qryGvGesuch = new KiSS4.DB.SqlQuery(this.components);
            this.grvGesuch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFonds = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repStatusImg = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBetragBeantragt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragBewilligt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungAbgeschlossen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBewilligt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGesuchgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntscheider = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKompetenzKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKompetenzBsl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIstFondsExtern = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGvGesuchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repStatusImgText = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.lblGesuche = new KiSS4.Gui.KissLabel();
            this.panGesuch = new System.Windows.Forms.Panel();
            this.tpgAntrag = new SharpLibrary.WinControls.TabPageEx();
            this.tpgBegruendung = new SharpLibrary.WinControls.TabPageEx();
            this.tpgBeilagenDokumente = new SharpLibrary.WinControls.TabPageEx();
            this.tabPageEx1 = new SharpLibrary.WinControls.TabPageEx();
            this.tabPageEx2 = new SharpLibrary.WinControls.TabPageEx();
            this.tabPageEx3 = new SharpLibrary.WinControls.TabPageEx();
            this.tpgBewilligung = new SharpLibrary.WinControls.TabPageEx();
            this.tpgAuflagen = new SharpLibrary.WinControls.TabPageEx();
            this.tpgAuszahlung = new SharpLibrary.WinControls.TabPageEx();
            this.tpgAbklaerendeStelle = new SharpLibrary.WinControls.TabPageEx();
            this.edtSucheGesuchsDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGesuchsDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheGesuchsDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGesuchsDatum = new KiSS4.Gui.KissLabel();
            this.edtSucheKostenart = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheFonds = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheGesuchID = new KiSS4.Gui.KissTextEdit();
            this.lblSucheGesuchID = new KiSS4.Gui.KissLabel();
            this.lblSucheFonds = new KiSS4.Gui.KissLabel();
            this.lblSucheKostenart = new KiSS4.Gui.KissLabel();
            this.edtSucheKlient = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheKlient = new KiSS4.Gui.KissLabel();
            this.lblSucheStatus = new KiSS4.Gui.KissLabel();
            this.chkSucheAbgeschlosseneAusschliessen = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheNurExterneGesuche = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheStatus = new KiSS4.Gui.KissImageComboBoxEdit();
            this.btnPersonalien = new KiSS4.Gui.KissButton();
            this.btnDokumenteGV = new KiSS4.Gui.KissButton();
            this.chkSucheKompetenzKanton = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheKompetenzBsl = new KiSS4.Gui.KissCheckEdit();
            this.chkSucheGesuchAnExterneFonds = new KiSS4.Gui.KissCheckEdit();
            this.ctlSucheKGSKostenstelleSAR = new KiSS4.Common.CtlKGSKostenstelleSAR();
            this.btnGesuchVerlauf = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGesuch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvGesuch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGesuch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImgText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchsDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchsDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchsDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchsDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFonds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFonds.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFonds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAbgeschlosseneAusschliessen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurExterneGesuche.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheKompetenzKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheKompetenzBsl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheGesuchAnExterneFonds.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(1019, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Controls.Add(this.tpgAntrag);
            this.tabControlSearch.Controls.Add(this.tpgAbklaerendeStelle);
            this.tabControlSearch.Controls.Add(this.tpgBegruendung);
            this.tabControlSearch.Controls.Add(this.tpgBeilagenDokumente);
            this.tabControlSearch.Controls.Add(this.tpgBewilligung);
            this.tabControlSearch.Controls.Add(this.tpgAuflagen);
            this.tabControlSearch.Controls.Add(this.tpgAuszahlung);
            this.tabControlSearch.Location = new System.Drawing.Point(3, 36);
            this.tabControlSearch.Size = new System.Drawing.Size(1082, 634);
            this.tabControlSearch.TabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgAntrag,
            this.tpgAbklaerendeStelle,
            this.tpgBegruendung,
            this.tpgBeilagenDokumente,
            this.tpgBewilligung,
            this.tpgAuflagen,
            this.tpgAuszahlung});
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgAuszahlung, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgAuflagen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgBewilligung, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgBeilagenDokumente, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgBegruendung, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgAbklaerendeStelle, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgAntrag, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tpgListe.Controls.Add(this.panGesuch);
            this.tpgListe.Controls.Add(this.lblGesuche);
            this.tpgListe.Controls.Add(this.grdGesuch);
            this.tpgListe.Size = new System.Drawing.Size(1070, 596);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.ctlSucheKGSKostenstelleSAR);
            this.tpgSuchen.Controls.Add(this.chkSucheGesuchAnExterneFonds);
            this.tpgSuchen.Controls.Add(this.chkSucheKompetenzBsl);
            this.tpgSuchen.Controls.Add(this.chkSucheKompetenzKanton);
            this.tpgSuchen.Controls.Add(this.edtSucheStatus);
            this.tpgSuchen.Controls.Add(this.chkSucheNurExterneGesuche);
            this.tpgSuchen.Controls.Add(this.chkSucheAbgeschlosseneAusschliessen);
            this.tpgSuchen.Controls.Add(this.lblSucheStatus);
            this.tpgSuchen.Controls.Add(this.edtSucheKlient);
            this.tpgSuchen.Controls.Add(this.lblSucheKlient);
            this.tpgSuchen.Controls.Add(this.lblSucheKostenart);
            this.tpgSuchen.Controls.Add(this.lblSucheFonds);
            this.tpgSuchen.Controls.Add(this.lblSucheGesuchID);
            this.tpgSuchen.Controls.Add(this.edtSucheGesuchID);
            this.tpgSuchen.Controls.Add(this.edtSucheFonds);
            this.tpgSuchen.Controls.Add(this.edtSucheKostenart);
            this.tpgSuchen.Controls.Add(this.edtSucheGesuchsDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheGesuchsDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheGesuchsDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheGesuchsDatum);
            this.tpgSuchen.Size = new System.Drawing.Size(1070, 596);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGesuchsDatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGesuchsDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGesuchsDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGesuchsDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKostenart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFonds, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGesuchID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGesuchID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFonds, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKostenart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheAbgeschlosseneAusschliessen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurExterneGesuche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheKompetenzKanton, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheKompetenzBsl, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheGesuchAnExterneFonds, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.ctlSucheKGSKostenstelleSAR, 0);
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.lblTitelInfo);
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(1085, 30);
            this.panTitel.TabIndex = 0;
            // 
            // lblTitelInfo
            // 
            this.lblTitelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitelInfo.Location = new System.Drawing.Point(451, 3);
            this.lblTitelInfo.Name = "lblTitelInfo";
            this.lblTitelInfo.Size = new System.Drawing.Size(628, 24);
            this.lblTitelInfo.TabIndex = 1;
            this.lblTitelInfo.Text = "Name Gesuchsteller, Gesuch ID";
            this.lblTitelInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(410, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Gesuch";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // grdGesuch
            // 
            this.grdGesuch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGesuch.DataSource = this.qryGvGesuch;
            // 
            // 
            // 
            this.grdGesuch.EmbeddedNavigator.Name = "";
            this.grdGesuch.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdGesuch.Location = new System.Drawing.Point(3, 19);
            this.grdGesuch.MainView = this.grvGesuch;
            this.grdGesuch.Name = "grdGesuch";
            this.grdGesuch.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repStatusImg});
            this.grdGesuch.Size = new System.Drawing.Size(1067, 331);
            this.grdGesuch.TabIndex = 1;
            this.grdGesuch.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGesuch});
            // 
            // qryGvGesuch
            // 
            this.qryGvGesuch.CanDelete = true;
            this.qryGvGesuch.CanInsert = true;
            this.qryGvGesuch.CanUpdate = true;
            this.qryGvGesuch.HostControl = this;
            this.qryGvGesuch.IsIdentityInsert = false;
            this.qryGvGesuch.SelectStatement = resources.GetString("qryGvGesuch.SelectStatement");
            this.qryGvGesuch.TableName = "GvGesuch";
            this.qryGvGesuch.AfterDelete += new System.EventHandler(this.qryGvGesuch_AfterDelete);
            this.qryGvGesuch.AfterFill += new System.EventHandler(this.qryGvGesuch_AfterFill);
            this.qryGvGesuch.AfterPost += new System.EventHandler(this.qryGvGesuch_AfterPost);
            this.qryGvGesuch.BeforePost += new System.EventHandler(this.qryGvGesuch_BeforePost);
            this.qryGvGesuch.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryGvGesuch_ColumnChanged);
            this.qryGvGesuch.PositionChanged += new System.EventHandler(this.qryGvGesuch_PositionChanged);
            // 
            // grvGesuch
            // 
            this.grvGesuch.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvGesuch.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuch.Appearance.Empty.Options.UseBackColor = true;
            this.grvGesuch.Appearance.Empty.Options.UseFont = true;
            this.grvGesuch.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuch.Appearance.EvenRow.Options.UseFont = true;
            this.grvGesuch.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGesuch.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuch.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvGesuch.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvGesuch.Appearance.FocusedCell.Options.UseFont = true;
            this.grvGesuch.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvGesuch.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvGesuch.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuch.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvGesuch.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvGesuch.Appearance.FocusedRow.Options.UseFont = true;
            this.grvGesuch.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvGesuch.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGesuch.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGesuch.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvGesuch.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvGesuch.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGesuch.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvGesuch.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvGesuch.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGesuch.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGesuch.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvGesuch.Appearance.GroupRow.Options.UseFont = true;
            this.grvGesuch.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvGesuch.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvGesuch.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvGesuch.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvGesuch.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvGesuch.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvGesuch.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvGesuch.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvGesuch.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuch.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvGesuch.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvGesuch.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvGesuch.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvGesuch.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvGesuch.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvGesuch.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuch.Appearance.OddRow.Options.UseFont = true;
            this.grvGesuch.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvGesuch.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuch.Appearance.Row.Options.UseBackColor = true;
            this.grvGesuch.Appearance.Row.Options.UseFont = true;
            this.grvGesuch.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvGesuch.Appearance.SelectedRow.Options.UseFont = true;
            this.grvGesuch.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvGesuch.Appearance.VertLine.Options.UseBackColor = true;
            this.grvGesuch.BestFitMaxRowCount = 1000;
            this.grvGesuch.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvGesuch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKlient,
            this.colFonds,
            this.colStatus,
            this.colBetragBeantragt,
            this.colBetragBewilligt,
            this.colErfassungAbgeschlossen,
            this.colTage,
            this.colDatumBewilligt,
            this.colAutor,
            this.colGesuchsdatum,
            this.colGesuchgrund,
            this.colEntscheider,
            this.colKompetenzKanton,
            this.colKompetenzBsl,
            this.colIstFondsExtern,
            this.colGvGesuchID});
            this.grvGesuch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvGesuch.GridControl = this.grdGesuch;
            this.grvGesuch.Name = "grvGesuch";
            this.grvGesuch.OptionsBehavior.Editable = false;
            this.grvGesuch.OptionsCustomization.AllowFilter = false;
            this.grvGesuch.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvGesuch.OptionsNavigation.AutoFocusNewRow = true;
            this.grvGesuch.OptionsNavigation.UseTabKey = false;
            this.grvGesuch.OptionsView.ColumnAutoWidth = false;
            this.grvGesuch.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvGesuch.OptionsView.ShowFooter = true;
            this.grvGesuch.OptionsView.ShowGroupPanel = false;
            this.grvGesuch.OptionsView.ShowIndicator = false;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 0;
            this.colKlient.Width = 150;
            // 
            // colFonds
            // 
            this.colFonds.Caption = "Fonds";
            this.colFonds.Name = "colFonds";
            this.colFonds.Visible = true;
            this.colFonds.VisibleIndex = 1;
            this.colFonds.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.Caption = "Status";
            this.colStatus.ColumnEdit = this.repStatusImg;
            this.colStatus.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colStatus.MinWidth = 10;
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 60;
            // 
            // repStatusImg
            // 
            this.repStatusImg.AutoHeight = false;
            this.repStatusImg.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repStatusImg.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repStatusImg.Name = "repStatusImg";
            // 
            // colBetragBeantragt
            // 
            this.colBetragBeantragt.Caption = "beantragt";
            this.colBetragBeantragt.DisplayFormat.FormatString = "n2";
            this.colBetragBeantragt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragBeantragt.Name = "colBetragBeantragt";
            this.colBetragBeantragt.Visible = true;
            this.colBetragBeantragt.VisibleIndex = 3;
            // 
            // colBetragBewilligt
            // 
            this.colBetragBewilligt.Caption = "bewilligt";
            this.colBetragBewilligt.DisplayFormat.FormatString = "n2";
            this.colBetragBewilligt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragBewilligt.FieldName = "BetragBewilligt";
            this.colBetragBewilligt.Name = "colBetragBewilligt";
            this.colBetragBewilligt.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetragBewilligt.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragBewilligt.Visible = true;
            this.colBetragBewilligt.VisibleIndex = 4;
            // 
            // colErfassungAbgeschlossen
            // 
            this.colErfassungAbgeschlossen.Caption = "Bearbeitungs-Datum";
            this.colErfassungAbgeschlossen.FieldName = "ErfassungAbgeschlossen";
            this.colErfassungAbgeschlossen.Name = "colErfassungAbgeschlossen";
            this.colErfassungAbgeschlossen.Visible = true;
            this.colErfassungAbgeschlossen.VisibleIndex = 5;
            // 
            // colTage
            // 
            this.colTage.Caption = "Bearbeitungstage";
            this.colTage.Name = "colTage";
            this.colTage.Visible = true;
            this.colTage.VisibleIndex = 6;
            // 
            // colDatumBewilligt
            // 
            this.colDatumBewilligt.Caption = "Entscheid-Datum";
            this.colDatumBewilligt.Name = "colDatumBewilligt";
            this.colDatumBewilligt.Visible = true;
            this.colDatumBewilligt.VisibleIndex = 7;
            this.colDatumBewilligt.Width = 85;
            // 
            // colAutor
            // 
            this.colAutor.Caption = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.Visible = true;
            this.colAutor.VisibleIndex = 8;
            this.colAutor.Width = 150;
            // 
            // colGesuchsdatum
            // 
            this.colGesuchsdatum.Caption = "Erfassungs-Datum";
            this.colGesuchsdatum.Name = "colGesuchsdatum";
            this.colGesuchsdatum.Visible = true;
            this.colGesuchsdatum.VisibleIndex = 9;
            // 
            // colGesuchgrund
            // 
            this.colGesuchgrund.Caption = "Gesuchgrund";
            this.colGesuchgrund.FieldName = "Gesuchsgrund";
            this.colGesuchgrund.Name = "colGesuchgrund";
            this.colGesuchgrund.Visible = true;
            this.colGesuchgrund.VisibleIndex = 10;
            // 
            // colEntscheider
            // 
            this.colEntscheider.Caption = "Entscheider";
            this.colEntscheider.FieldName = "Entscheider";
            this.colEntscheider.Name = "colEntscheider";
            this.colEntscheider.Visible = true;
            this.colEntscheider.VisibleIndex = 11;
            // 
            // colKompetenzKanton
            // 
            this.colKompetenzKanton.Caption = "Kompetenz kant. FLB-Ko/KK";
            this.colKompetenzKanton.Name = "colKompetenzKanton";
            this.colKompetenzKanton.Visible = true;
            this.colKompetenzKanton.VisibleIndex = 12;
            // 
            // colKompetenzBsl
            // 
            this.colKompetenzBsl.Caption = "Kompetenz BSL";
            this.colKompetenzBsl.Name = "colKompetenzBsl";
            this.colKompetenzBsl.Visible = true;
            this.colKompetenzBsl.VisibleIndex = 13;
            // 
            // colIstFondsExtern
            // 
            this.colIstFondsExtern.Caption = "Gesuche an externe Fonds";
            this.colIstFondsExtern.Name = "colIstFondsExtern";
            this.colIstFondsExtern.Visible = true;
            this.colIstFondsExtern.VisibleIndex = 14;
            // 
            // colGvGesuchID
            // 
            this.colGvGesuchID.Caption = "Gesuchs-ID";
            this.colGvGesuchID.Name = "colGvGesuchID";
            this.colGvGesuchID.Visible = true;
            this.colGvGesuchID.VisibleIndex = 15;
            // 
            // repStatusImgText
            // 
            this.repStatusImgText.AutoHeight = false;
            this.repStatusImgText.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repStatusImgText.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repStatusImgText.Name = "repStatusImgText";
            // 
            // lblGesuche
            // 
            this.lblGesuche.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblGesuche.Location = new System.Drawing.Point(0, 0);
            this.lblGesuche.Name = "lblGesuche";
            this.lblGesuche.Size = new System.Drawing.Size(100, 16);
            this.lblGesuche.TabIndex = 0;
            this.lblGesuche.Text = "Gesuche";
            // 
            // panGesuch
            // 
            this.panGesuch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panGesuch.Location = new System.Drawing.Point(3, 357);
            this.panGesuch.Name = "panGesuch";
            this.panGesuch.Size = new System.Drawing.Size(1067, 237);
            this.panGesuch.TabIndex = 2;
            // 
            // tpgAntrag
            // 
            this.tpgAntrag.Location = new System.Drawing.Point(6, 6);
            this.tpgAntrag.Name = "tpgAntrag";
            this.tpgAntrag.Size = new System.Drawing.Size(1070, 596);
            this.tpgAntrag.TabIndex = 0;
            this.tpgAntrag.Title = "Antrag";
            // 
            // tpgBegruendung
            // 
            this.tpgBegruendung.Location = new System.Drawing.Point(6, 6);
            this.tpgBegruendung.Name = "tpgBegruendung";
            this.tpgBegruendung.Size = new System.Drawing.Size(1070, 596);
            this.tpgBegruendung.TabIndex = 0;
            this.tpgBegruendung.Title = "Begründung";
            // 
            // tpgBeilagenDokumente
            // 
            this.tpgBeilagenDokumente.Location = new System.Drawing.Point(6, 6);
            this.tpgBeilagenDokumente.Name = "tpgBeilagenDokumente";
            this.tpgBeilagenDokumente.Size = new System.Drawing.Size(1070, 596);
            this.tpgBeilagenDokumente.TabIndex = 0;
            this.tpgBeilagenDokumente.Title = "Beilagen/Dokumente";
            // 
            // tabPageEx1
            // 
            this.tabPageEx1.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx1.Name = "tabPageEx1";
            this.tabPageEx1.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx1.TabIndex = 0;
            this.tabPageEx1.Title = "tabPageEx1";
            // 
            // tabPageEx2
            // 
            this.tabPageEx2.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx2.Name = "tabPageEx2";
            this.tabPageEx2.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx2.TabIndex = 0;
            this.tabPageEx2.Title = "tabPageEx2";
            // 
            // tabPageEx3
            // 
            this.tabPageEx3.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx3.Name = "tabPageEx3";
            this.tabPageEx3.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx3.TabIndex = 0;
            this.tabPageEx3.Title = "tabPageEx3";
            // 
            // tpgBewilligung
            // 
            this.tpgBewilligung.Location = new System.Drawing.Point(6, 6);
            this.tpgBewilligung.Name = "tpgBewilligung";
            this.tpgBewilligung.Size = new System.Drawing.Size(1070, 596);
            this.tpgBewilligung.TabIndex = 0;
            this.tpgBewilligung.Title = "Bewilligung";
            // 
            // tpgAuflagen
            // 
            this.tpgAuflagen.Location = new System.Drawing.Point(6, 6);
            this.tpgAuflagen.Name = "tpgAuflagen";
            this.tpgAuflagen.Size = new System.Drawing.Size(1070, 596);
            this.tpgAuflagen.TabIndex = 0;
            this.tpgAuflagen.Title = "Auflagen";
            // 
            // tpgAuszahlung
            // 
            this.tpgAuszahlung.Location = new System.Drawing.Point(6, 6);
            this.tpgAuszahlung.Name = "tpgAuszahlung";
            this.tpgAuszahlung.Size = new System.Drawing.Size(1070, 596);
            this.tpgAuszahlung.TabIndex = 2;
            this.tpgAuszahlung.Title = "Auszahlung";
            // 
            // tpgAbklaerendeStelle
            // 
            this.tpgAbklaerendeStelle.Location = new System.Drawing.Point(6, 6);
            this.tpgAbklaerendeStelle.Name = "tpgAbklaerendeStelle";
            this.tpgAbklaerendeStelle.Size = new System.Drawing.Size(1070, 596);
            this.tpgAbklaerendeStelle.TabIndex = 3;
            this.tpgAbklaerendeStelle.Title = "Abklärende Stelle";
            // 
            // edtSucheGesuchsDatumBis
            // 
            this.edtSucheGesuchsDatumBis.EditValue = null;
            this.edtSucheGesuchsDatumBis.Location = new System.Drawing.Point(294, 276);
            this.edtSucheGesuchsDatumBis.Name = "edtSucheGesuchsDatumBis";
            this.edtSucheGesuchsDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGesuchsDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGesuchsDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGesuchsDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGesuchsDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGesuchsDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGesuchsDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGesuchsDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheGesuchsDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGesuchsDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheGesuchsDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGesuchsDatumBis.Properties.ShowToday = false;
            this.edtSucheGesuchsDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheGesuchsDatumBis.TabIndex = 16;
            // 
            // lblSucheGesuchsDatumBis
            // 
            this.lblSucheGesuchsDatumBis.Location = new System.Drawing.Point(256, 276);
            this.lblSucheGesuchsDatumBis.Name = "lblSucheGesuchsDatumBis";
            this.lblSucheGesuchsDatumBis.Size = new System.Drawing.Size(32, 24);
            this.lblSucheGesuchsDatumBis.TabIndex = 15;
            this.lblSucheGesuchsDatumBis.Text = "bis";
            this.lblSucheGesuchsDatumBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheGesuchsDatumVon
            // 
            this.edtSucheGesuchsDatumVon.EditValue = null;
            this.edtSucheGesuchsDatumVon.Location = new System.Drawing.Point(150, 276);
            this.edtSucheGesuchsDatumVon.Name = "edtSucheGesuchsDatumVon";
            this.edtSucheGesuchsDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGesuchsDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGesuchsDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGesuchsDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGesuchsDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGesuchsDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGesuchsDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGesuchsDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheGesuchsDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGesuchsDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheGesuchsDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGesuchsDatumVon.Properties.EditFormat.FormatString = "yyyy";
            this.edtSucheGesuchsDatumVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSucheGesuchsDatumVon.Properties.ShowToday = false;
            this.edtSucheGesuchsDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheGesuchsDatumVon.TabIndex = 14;
            // 
            // lblSucheGesuchsDatum
            // 
            this.lblSucheGesuchsDatum.Location = new System.Drawing.Point(11, 276);
            this.lblSucheGesuchsDatum.Name = "lblSucheGesuchsDatum";
            this.lblSucheGesuchsDatum.Size = new System.Drawing.Size(133, 24);
            this.lblSucheGesuchsDatum.TabIndex = 13;
            this.lblSucheGesuchsDatum.Text = "Datum von";
            this.lblSucheGesuchsDatum.UseCompatibleTextRendering = true;
            // 
            // edtSucheKostenart
            // 
            this.edtSucheKostenart.Location = new System.Drawing.Point(150, 306);
            this.edtSucheKostenart.Name = "edtSucheKostenart";
            this.edtSucheKostenart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKostenart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKostenart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenart.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKostenart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKostenart.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKostenart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheKostenart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheKostenart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheKostenart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheKostenart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheKostenart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKostenart.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheKostenart.Properties.DisplayMember = "Text";
            this.edtSucheKostenart.Properties.NullText = "";
            this.edtSucheKostenart.Properties.ShowFooter = false;
            this.edtSucheKostenart.Properties.ShowHeader = false;
            this.edtSucheKostenart.Properties.ValueMember = "Code";
            this.edtSucheKostenart.Size = new System.Drawing.Size(244, 24);
            this.edtSucheKostenart.TabIndex = 18;
            // 
            // edtSucheFonds
            // 
            this.edtSucheFonds.Location = new System.Drawing.Point(150, 246);
            this.edtSucheFonds.Name = "edtSucheFonds";
            this.edtSucheFonds.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFonds.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFonds.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFonds.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFonds.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFonds.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFonds.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheFonds.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFonds.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheFonds.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheFonds.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheFonds.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheFonds.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheFonds.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheFonds.Properties.DisplayMember = "Text";
            this.edtSucheFonds.Properties.NullText = "";
            this.edtSucheFonds.Properties.ShowFooter = false;
            this.edtSucheFonds.Properties.ShowHeader = false;
            this.edtSucheFonds.Properties.ValueMember = "Code";
            this.edtSucheFonds.Size = new System.Drawing.Size(244, 24);
            this.edtSucheFonds.TabIndex = 12;
            // 
            // edtSucheGesuchID
            // 
            this.edtSucheGesuchID.Location = new System.Drawing.Point(150, 186);
            this.edtSucheGesuchID.Name = "edtSucheGesuchID";
            this.edtSucheGesuchID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGesuchID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGesuchID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGesuchID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGesuchID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGesuchID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGesuchID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheGesuchID.Size = new System.Drawing.Size(244, 24);
            this.edtSucheGesuchID.TabIndex = 10;
            // 
            // lblSucheGesuchID
            // 
            this.lblSucheGesuchID.Location = new System.Drawing.Point(11, 186);
            this.lblSucheGesuchID.Name = "lblSucheGesuchID";
            this.lblSucheGesuchID.Size = new System.Drawing.Size(133, 24);
            this.lblSucheGesuchID.TabIndex = 9;
            this.lblSucheGesuchID.Text = "GesuchID";
            this.lblSucheGesuchID.UseCompatibleTextRendering = true;
            // 
            // lblSucheFonds
            // 
            this.lblSucheFonds.Location = new System.Drawing.Point(11, 246);
            this.lblSucheFonds.Name = "lblSucheFonds";
            this.lblSucheFonds.Size = new System.Drawing.Size(133, 24);
            this.lblSucheFonds.TabIndex = 11;
            this.lblSucheFonds.Text = "Fonds";
            this.lblSucheFonds.UseCompatibleTextRendering = true;
            // 
            // lblSucheKostenart
            // 
            this.lblSucheKostenart.Location = new System.Drawing.Point(11, 306);
            this.lblSucheKostenart.Name = "lblSucheKostenart";
            this.lblSucheKostenart.Size = new System.Drawing.Size(133, 24);
            this.lblSucheKostenart.TabIndex = 17;
            this.lblSucheKostenart.Text = "Kostenart";
            this.lblSucheKostenart.UseCompatibleTextRendering = true;
            // 
            // edtSucheKlient
            // 
            this.edtSucheKlient.Location = new System.Drawing.Point(150, 66);
            this.edtSucheKlient.Name = "edtSucheKlient";
            this.edtSucheKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKlient.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheKlient.Size = new System.Drawing.Size(244, 24);
            this.edtSucheKlient.TabIndex = 2;
            this.edtSucheKlient.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheKlient_UserModifiedFld);
            // 
            // lblSucheKlient
            // 
            this.lblSucheKlient.Location = new System.Drawing.Point(11, 66);
            this.lblSucheKlient.Name = "lblSucheKlient";
            this.lblSucheKlient.Size = new System.Drawing.Size(133, 24);
            this.lblSucheKlient.TabIndex = 1;
            this.lblSucheKlient.Text = "Klient";
            this.lblSucheKlient.UseCompatibleTextRendering = true;
            // 
            // lblSucheStatus
            // 
            this.lblSucheStatus.Location = new System.Drawing.Point(11, 216);
            this.lblSucheStatus.Name = "lblSucheStatus";
            this.lblSucheStatus.Size = new System.Drawing.Size(133, 24);
            this.lblSucheStatus.TabIndex = 21;
            this.lblSucheStatus.Text = "Status";
            this.lblSucheStatus.UseCompatibleTextRendering = true;
            // 
            // chkSucheAbgeschlosseneAusschliessen
            // 
            this.chkSucheAbgeschlosseneAusschliessen.EditValue = false;
            this.chkSucheAbgeschlosseneAusschliessen.Location = new System.Drawing.Point(150, 336);
            this.chkSucheAbgeschlosseneAusschliessen.Name = "chkSucheAbgeschlosseneAusschliessen";
            this.chkSucheAbgeschlosseneAusschliessen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheAbgeschlosseneAusschliessen.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheAbgeschlosseneAusschliessen.Properties.Caption = "abgeschlossene ausschliessen";
            this.chkSucheAbgeschlosseneAusschliessen.Size = new System.Drawing.Size(244, 19);
            this.chkSucheAbgeschlosseneAusschliessen.TabIndex = 22;
            // 
            // chkSucheNurExterneGesuche
            // 
            this.chkSucheNurExterneGesuche.EditValue = false;
            this.chkSucheNurExterneGesuche.Location = new System.Drawing.Point(150, 361);
            this.chkSucheNurExterneGesuche.Name = "chkSucheNurExterneGesuche";
            this.chkSucheNurExterneGesuche.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheNurExterneGesuche.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurExterneGesuche.Properties.Caption = "nur externe Gesuche, die älter als 30 Tage sind";
            this.chkSucheNurExterneGesuche.Size = new System.Drawing.Size(254, 19);
            this.chkSucheNurExterneGesuche.TabIndex = 23;
            // 
            // edtSucheStatus
            // 
            this.edtSucheStatus.Location = new System.Drawing.Point(150, 216);
            this.edtSucheStatus.Name = "edtSucheStatus";
            this.edtSucheStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtSucheStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheStatus.Size = new System.Drawing.Size(244, 24);
            this.edtSucheStatus.TabIndex = 25;
            // 
            // btnPersonalien
            // 
            this.btnPersonalien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPersonalien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonalien.Location = new System.Drawing.Point(858, 647);
            this.btnPersonalien.Name = "btnPersonalien";
            this.btnPersonalien.Size = new System.Drawing.Size(100, 24);
            this.btnPersonalien.TabIndex = 0;
            this.btnPersonalien.Text = "Personalien";
            this.btnPersonalien.UseVisualStyleBackColor = false;
            this.btnPersonalien.Click += new System.EventHandler(this.btnPersonalien_Click);
            // 
            // btnDokumenteGV
            // 
            this.btnDokumenteGV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDokumenteGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDokumenteGV.Location = new System.Drawing.Point(964, 647);
            this.btnDokumenteGV.Name = "btnDokumenteGV";
            this.btnDokumenteGV.Size = new System.Drawing.Size(115, 24);
            this.btnDokumenteGV.TabIndex = 0;
            this.btnDokumenteGV.Text = "Dokumente GV";
            this.btnDokumenteGV.UseVisualStyleBackColor = false;
            this.btnDokumenteGV.Click += new System.EventHandler(this.btnDokumenteGV_Click);
            // 
            // chkSucheKompetenzKanton
            // 
            this.chkSucheKompetenzKanton.EditValue = false;
            this.chkSucheKompetenzKanton.Location = new System.Drawing.Point(150, 386);
            this.chkSucheKompetenzKanton.Name = "chkSucheKompetenzKanton";
            this.chkSucheKompetenzKanton.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheKompetenzKanton.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheKompetenzKanton.Properties.Caption = "Kompetenz kant. FLB-Ko/KK";
            this.chkSucheKompetenzKanton.Size = new System.Drawing.Size(254, 19);
            this.chkSucheKompetenzKanton.TabIndex = 27;
            // 
            // chkSucheKompetenzBsl
            // 
            this.chkSucheKompetenzBsl.EditValue = false;
            this.chkSucheKompetenzBsl.Location = new System.Drawing.Point(150, 411);
            this.chkSucheKompetenzBsl.Name = "chkSucheKompetenzBsl";
            this.chkSucheKompetenzBsl.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheKompetenzBsl.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheKompetenzBsl.Properties.Caption = "Kompetenz BSL";
            this.chkSucheKompetenzBsl.Size = new System.Drawing.Size(254, 19);
            this.chkSucheKompetenzBsl.TabIndex = 28;
            // 
            // chkSucheGesuchAnExterneFonds
            // 
            this.chkSucheGesuchAnExterneFonds.EditValue = false;
            this.chkSucheGesuchAnExterneFonds.Location = new System.Drawing.Point(150, 436);
            this.chkSucheGesuchAnExterneFonds.Name = "chkSucheGesuchAnExterneFonds";
            this.chkSucheGesuchAnExterneFonds.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheGesuchAnExterneFonds.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheGesuchAnExterneFonds.Properties.Caption = "Gesuche an externe Fonds";
            this.chkSucheGesuchAnExterneFonds.Size = new System.Drawing.Size(254, 19);
            this.chkSucheGesuchAnExterneFonds.TabIndex = 29;
            // 
            // ctlSucheKGSKostenstelleSAR
            // 
            this.ctlSucheKGSKostenstelleSAR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlSucheKGSKostenstelleSAR.DataMemberKGS = "";
            this.ctlSucheKGSKostenstelleSAR.DataMemberKostenstelle = "";
            this.ctlSucheKGSKostenstelleSAR.DataMemberMitarbeiter = "";
            this.ctlSucheKGSKostenstelleSAR.Location = new System.Drawing.Point(11, 96);
            this.ctlSucheKGSKostenstelleSAR.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.ctlSucheKGSKostenstelleSAR.Name = "ctlSucheKGSKostenstelleSAR";
            this.ctlSucheKGSKostenstelleSAR.Size = new System.Drawing.Size(383, 87);
            this.ctlSucheKGSKostenstelleSAR.TabIndex = 30;
            // 
            // btnGesuchVerlauf
            // 
            this.btnGesuchVerlauf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGesuchVerlauf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGesuchVerlauf.Location = new System.Drawing.Point(737, 647);
            this.btnGesuchVerlauf.Name = "btnGesuchVerlauf";
            this.btnGesuchVerlauf.Size = new System.Drawing.Size(115, 24);
            this.btnGesuchVerlauf.TabIndex = 2;
            this.btnGesuchVerlauf.Text = "Gesuch-Verlauf";
            this.btnGesuchVerlauf.UseVisualStyleBackColor = false;
            this.btnGesuchVerlauf.Click += new System.EventHandler(this.btnGesuchVerlauf_Click);
            // 
            // CtlGvGesuchverwaltung
            // 
            this.ActiveSQLQuery = this.qryGvGesuch;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1065, 400);
            this.Controls.Add(this.btnGesuchVerlauf);
            this.Controls.Add(this.btnDokumenteGV);
            this.Controls.Add(this.btnPersonalien);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlGvGesuchverwaltung";
            this.Size = new System.Drawing.Size(1085, 676);
            this.Load += new System.EventHandler(this.CtlGvGesuchverwaltung_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.panTitel, 0);
            this.Controls.SetChildIndex(this.btnPersonalien, 0);
            this.Controls.SetChildIndex(this.btnDokumenteGV, 0);
            this.Controls.SetChildIndex(this.btnGesuchVerlauf, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitelInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGesuch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvGesuch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGesuch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImgText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGesuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchsDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchsDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchsDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchsDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFonds.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFonds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGesuchID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGesuchID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFonds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAbgeschlosseneAusschliessen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurExterneGesuche.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheKompetenzKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheKompetenzBsl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheGesuchAnExterneFonds.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTitel;
        private Gui.KissLabel lblTitelInfo;
        private System.Windows.Forms.PictureBox picTitel;
        private Gui.KissLabel lblTitel;
        private Gui.KissGrid grdGesuch;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGesuch;
        private Gui.KissLabel lblGesuche;
        private DB.SqlQuery qryGvGesuch;
        private System.Windows.Forms.Panel panGesuch;
        private SharpLibrary.WinControls.TabPageEx tpgAntrag;
        private DevExpress.XtraGrid.Columns.GridColumn colGvGesuchID;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colFonds;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragBeantragt;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragBewilligt;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBewilligt;
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private SharpLibrary.WinControls.TabPageEx tpgBegruendung;
        private SharpLibrary.WinControls.TabPageEx tpgBeilagenDokumente;
        private SharpLibrary.WinControls.TabPageEx tpgBewilligung;
        private SharpLibrary.WinControls.TabPageEx tabPageEx1;
        private SharpLibrary.WinControls.TabPageEx tabPageEx2;
        private SharpLibrary.WinControls.TabPageEx tabPageEx3;
        private SharpLibrary.WinControls.TabPageEx tpgAuflagen;
        private SharpLibrary.WinControls.TabPageEx tpgAuszahlung;
        private SharpLibrary.WinControls.TabPageEx tpgAbklaerendeStelle;
        private Gui.KissDateEdit edtSucheGesuchsDatumBis;
        private Gui.KissLabel lblSucheGesuchsDatumBis;
        private Gui.KissDateEdit edtSucheGesuchsDatumVon;
        private Gui.KissLabel lblSucheGesuchsDatum;
        private Gui.KissLookUpEdit edtSucheFonds;
        private Gui.KissLookUpEdit edtSucheKostenart;
        private Gui.KissLabel lblSucheKostenart;
        private Gui.KissLabel lblSucheFonds;
        private Gui.KissLabel lblSucheGesuchID;
        private Gui.KissTextEdit edtSucheGesuchID;
        private Gui.KissButtonEdit edtSucheKlient;
        private Gui.KissLabel lblSucheKlient;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repStatusImg;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repStatusImgText;
        private Gui.KissCheckEdit chkSucheNurExterneGesuche;
        private Gui.KissCheckEdit chkSucheAbgeschlosseneAusschliessen;
        private Gui.KissLabel lblSucheStatus;
        private Gui.KissImageComboBoxEdit edtSucheStatus;
        private Gui.KissButton btnDokumenteGV;
        private Gui.KissButton btnPersonalien;
        private DevExpress.XtraGrid.Columns.GridColumn colTage;
        private Gui.KissCheckEdit chkSucheGesuchAnExterneFonds;
        private Gui.KissCheckEdit chkSucheKompetenzBsl;
        private Gui.KissCheckEdit chkSucheKompetenzKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colKompetenzKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colKompetenzBsl;
        private DevExpress.XtraGrid.Columns.GridColumn colIstFondsExtern;
        private Common.CtlKGSKostenstelleSAR ctlSucheKGSKostenstelleSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungAbgeschlossen;
        private DevExpress.XtraGrid.Columns.GridColumn colGesuchgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colEntscheider;
        private Gui.KissButton btnGesuchVerlauf;
    }
}
