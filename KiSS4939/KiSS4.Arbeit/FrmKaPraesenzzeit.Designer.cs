using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Arbeit
{
    partial class FrmKaPraesenzzeit
    {
        #region Dispose

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

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKaPraesenzzeit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryPraesenz = new KiSS4.DB.SqlQuery(this.components);
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.qryInfo = new KiSS4.DB.SqlQuery(this.components);
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.memBemerkungRTF = new KiSS4.Gui.KissMemoEdit();
            this.lblAustritt = new KiSS4.Gui.KissLabel();
            this.datAustritt = new KiSS4.Gui.KissDateEdit();
            this.grdInfo = new KiSS4.Gui.KissGrid();
            this.gvInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInfo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAustritt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuweiser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.qryFachbereich = new KiSS4.DB.SqlQuery(this.components);
            this.grdFachbereich = new KiSS4.Gui.KissGrid();
            this.grvFachbereich = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFachbereich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grdPraesenz = new KiSS4.Gui.KissGrid();
            this.gvPraesenz = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col05 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col06 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col07 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col08 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col09 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be05 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be06 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be07 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be08 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be09 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.be31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.btnPrint = new KiSS4.Gui.KissButton();
            this.ddlMonatX = new KiSS4.Gui.KissLookUpEdit();
            this.lblMonatJahr = new KiSS4.Gui.KissLabel();
            this.btnRefresh = new KiSS4.Gui.KissButton();
            this.edtJahr = new KiSS4.Gui.KissCalcEdit();
            this.lblAnzDatensaetze = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.panDetail = new System.Windows.Forms.Panel();
            this.dlgFachbereichX = new KiSS4.Gui.KissButtonEdit();
            this.dlgKursX = new KiSS4.Gui.KissButtonEdit();
            this.lblKurs = new KiSS4.Gui.KissLabel();
            this.dlgFachleitungX = new KiSS4.Common.KissMitarbeiterButtonEdit(this.components);
            this.lblFachleitung = new KiSS4.Gui.KissLabel();
            this.dlgCoachX = new KiSS4.Common.KissMitarbeiterButtonEdit(this.components);
            this.lblZusatzX = new KiSS4.Gui.KissLabel();
            this.ddlZusatzX = new KiSS4.Gui.KissLookUpEdit();
            this.ddlAPVNrX = new KiSS4.Gui.KissLookUpEdit();
            this.dlgKlientX = new KiSS4.Gui.KissButtonEdit();
            this.lblFachbereich = new KiSS4.Gui.KissLabel();
            this.lblCoach = new KiSS4.Gui.KissLabel();
            this.lblAPVNr = new KiSS4.Gui.KissLabel();
            this.lblKlientIn = new KiSS4.Gui.KissLabel();
            this.edtTabWorkaroundInvisible = new KiSS4.Gui.KissLookUpEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraesenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungRTF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAustritt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datAustritt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFachbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFachbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFachbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPraesenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPraesenz)).BeginInit();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMonatX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMonatX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).BeginInit();
            this.panDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlgFachbereichX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgKursX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgFachleitungX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachleitung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgCoachX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZusatzX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZusatzX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAPVNrX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAPVNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgKlientX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCoach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAPVNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTabWorkaroundInvisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTabWorkaroundInvisible.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(952, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(6, 6);
            this.tabControlSearch.Size = new System.Drawing.Size(976, 387);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.ctlGotoFall);
            this.tpgListe.Controls.Add(this.grdPraesenz);
            this.tpgListe.Controls.Add(this.pnlHead);
            this.tpgListe.Size = new System.Drawing.Size(964, 349);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtTabWorkaroundInvisible);
            this.tpgSuchen.Controls.Add(this.dlgFachbereichX);
            this.tpgSuchen.Controls.Add(this.dlgKursX);
            this.tpgSuchen.Controls.Add(this.lblKurs);
            this.tpgSuchen.Controls.Add(this.dlgFachleitungX);
            this.tpgSuchen.Controls.Add(this.lblFachleitung);
            this.tpgSuchen.Controls.Add(this.dlgCoachX);
            this.tpgSuchen.Controls.Add(this.lblZusatzX);
            this.tpgSuchen.Controls.Add(this.ddlZusatzX);
            this.tpgSuchen.Controls.Add(this.ddlAPVNrX);
            this.tpgSuchen.Controls.Add(this.dlgKlientX);
            this.tpgSuchen.Controls.Add(this.lblFachbereich);
            this.tpgSuchen.Controls.Add(this.lblCoach);
            this.tpgSuchen.Controls.Add(this.lblAPVNr);
            this.tpgSuchen.Controls.Add(this.lblKlientIn);
            this.tpgSuchen.Size = new System.Drawing.Size(964, 349);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlientIn, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAPVNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblCoach, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFachbereich, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.dlgKlientX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.ddlAPVNrX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.ddlZusatzX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZusatzX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.dlgCoachX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFachleitung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.dlgFachleitungX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKurs, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.dlgKursX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.dlgFachbereichX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtTabWorkaroundInvisible, 0);
            // 
            // qryPraesenz
            // 
            this.qryPraesenz.CanUpdate = true;
            this.qryPraesenz.HostControl = this;
            this.qryPraesenz.IsIdentityInsert = false;
            this.qryPraesenz.TableName = "KaArbeitsrapport";
            this.qryPraesenz.BeforePost += new System.EventHandler(this.qryPraesenz_BeforePost);
            this.qryPraesenz.PositionChanged += new System.EventHandler(this.qryPraesenz_PositionChanged);
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.ForeColor = System.Drawing.Color.Black;
            this.lblBemerkung.Location = new System.Drawing.Point(-3, 3);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(70, 24);
            this.lblBemerkung.TabIndex = 0;
            this.lblBemerkung.Text = "Bemerkung";
            // 
            // qryInfo
            // 
            this.qryInfo.HostControl = this;
            this.qryInfo.IsIdentityInsert = false;
            this.qryInfo.TableName = "KaEinsatz";
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 325);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(202, 24);
            this.ctlGotoFall.TabIndex = 2;
            // 
            // memBemerkungRTF
            // 
            this.memBemerkungRTF.DataSource = this.qryPraesenz;
            this.memBemerkungRTF.EditValue = "";
            this.memBemerkungRTF.Location = new System.Drawing.Point(0, 30);
            this.memBemerkungRTF.Name = "memBemerkungRTF";
            this.memBemerkungRTF.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkungRTF.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungRTF.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungRTF.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungRTF.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungRTF.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungRTF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungRTF.Size = new System.Drawing.Size(463, 84);
            this.memBemerkungRTF.TabIndex = 3;
            this.memBemerkungRTF.Leave += new System.EventHandler(this.memBemerkungRTF_Leave);
            // 
            // lblAustritt
            // 
            this.lblAustritt.Location = new System.Drawing.Point(543, 3);
            this.lblAustritt.Name = "lblAustritt";
            this.lblAustritt.Size = new System.Drawing.Size(57, 24);
            this.lblAustritt.TabIndex = 1;
            this.lblAustritt.Text = "Austritt";
            this.lblAustritt.Visible = false;
            // 
            // datAustritt
            // 
            this.datAustritt.DataMember = "Austritt";
            this.datAustritt.DataSource = this.qryInfo;
            this.datAustritt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.datAustritt.EditValue = null;
            this.datAustritt.Location = new System.Drawing.Point(606, 3);
            this.datAustritt.Name = "datAustritt";
            this.datAustritt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datAustritt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.datAustritt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datAustritt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datAustritt.Properties.Appearance.Options.UseBackColor = true;
            this.datAustritt.Properties.Appearance.Options.UseBorderColor = true;
            this.datAustritt.Properties.Appearance.Options.UseFont = true;
            this.datAustritt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.datAustritt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, false, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datAustritt.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.datAustritt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datAustritt.Properties.ReadOnly = true;
            this.datAustritt.Properties.ShowToday = false;
            this.datAustritt.Size = new System.Drawing.Size(89, 24);
            this.datAustritt.TabIndex = 2;
            this.datAustritt.TabStop = false;
            this.datAustritt.Visible = false;
            // 
            // grdInfo
            // 
            this.grdInfo.DataSource = this.qryInfo;
            // 
            // 
            // 
            this.grdInfo.EmbeddedNavigator.Name = "";
            this.grdInfo.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdInfo.Location = new System.Drawing.Point(0, 120);
            this.grdInfo.MainView = this.gvInfo;
            this.grdInfo.Name = "grdInfo";
            this.grdInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.grdInfo.Size = new System.Drawing.Size(860, 96);
            this.grdInfo.TabIndex = 5;
            this.grdInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInfo});
            // 
            // gvInfo
            // 
            this.gvInfo.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvInfo.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvInfo.Appearance.Empty.Options.UseBackColor = true;
            this.gvInfo.Appearance.Empty.Options.UseFont = true;
            this.gvInfo.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvInfo.Appearance.EvenRow.Options.UseFont = true;
            this.gvInfo.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvInfo.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvInfo.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvInfo.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvInfo.Appearance.FocusedCell.Options.UseFont = true;
            this.gvInfo.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvInfo.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvInfo.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvInfo.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvInfo.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvInfo.Appearance.FocusedRow.Options.UseFont = true;
            this.gvInfo.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvInfo.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gvInfo.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gvInfo.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvInfo.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvInfo.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvInfo.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvInfo.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvInfo.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvInfo.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvInfo.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvInfo.Appearance.GroupRow.Options.UseFont = true;
            this.gvInfo.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvInfo.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvInfo.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvInfo.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvInfo.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvInfo.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvInfo.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvInfo.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvInfo.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvInfo.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvInfo.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvInfo.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvInfo.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvInfo.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvInfo.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvInfo.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvInfo.Appearance.OddRow.Options.UseFont = true;
            this.gvInfo.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvInfo.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvInfo.Appearance.Row.Options.UseBackColor = true;
            this.gvInfo.Appearance.Row.Options.UseFont = true;
            this.gvInfo.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvInfo.Appearance.SelectedRow.Options.UseFont = true;
            this.gvInfo.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvInfo.Appearance.VertLine.Options.UseBackColor = true;
            this.gvInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInfo,
            this.colAustritt,
            this.colZuweiser});
            this.gvInfo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvInfo.GridControl = this.grdInfo;
            this.gvInfo.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvInfo.Name = "gvInfo";
            this.gvInfo.OptionsBehavior.Editable = false;
            this.gvInfo.OptionsCustomization.AllowFilter = false;
            this.gvInfo.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvInfo.OptionsNavigation.AutoFocusNewRow = true;
            this.gvInfo.OptionsNavigation.UseTabKey = false;
            this.gvInfo.OptionsView.ColumnAutoWidth = false;
            this.gvInfo.OptionsView.RowAutoHeight = true;
            this.gvInfo.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvInfo.OptionsView.ShowGroupPanel = false;
            this.gvInfo.OptionsView.ShowIndicator = false;
            // 
            // colInfo
            // 
            this.colInfo.Caption = "An- / Zuweisung";
            this.colInfo.FieldName = "Info";
            this.colInfo.Name = "colInfo";
            this.colInfo.Visible = true;
            this.colInfo.VisibleIndex = 0;
            this.colInfo.Width = 450;
            // 
            // colAustritt
            // 
            this.colAustritt.Caption = "Austritt";
            this.colAustritt.FieldName = "Austritt";
            this.colAustritt.Name = "colAustritt";
            this.colAustritt.Visible = true;
            this.colAustritt.VisibleIndex = 1;
            this.colAustritt.Width = 96;
            // 
            // colZuweiser
            // 
            this.colZuweiser.Caption = "Zuweiser";
            this.colZuweiser.FieldName = "Zuweiser";
            this.colZuweiser.Name = "colZuweiser";
            this.colZuweiser.Visible = true;
            this.colZuweiser.VisibleIndex = 2;
            this.colZuweiser.Width = 301;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            this.repositoryItemMemoEdit2.ReadOnly = true;
            // 
            // qryFachbereich
            // 
            this.qryFachbereich.HostControl = this;
            this.qryFachbereich.IsIdentityInsert = false;
            this.qryFachbereich.TableName = "KaZuteilFachbereich";
            // 
            // grdFachbereich
            // 
            this.grdFachbereich.DataSource = this.qryFachbereich;
            // 
            // 
            // 
            this.grdFachbereich.EmbeddedNavigator.Name = "";
            this.grdFachbereich.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFachbereich.Location = new System.Drawing.Point(469, 30);
            this.grdFachbereich.MainView = this.grvFachbereich;
            this.grdFachbereich.Name = "grdFachbereich";
            this.grdFachbereich.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdFachbereich.Size = new System.Drawing.Size(391, 84);
            this.grdFachbereich.TabIndex = 4;
            this.grdFachbereich.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFachbereich});
            // 
            // grvFachbereich
            // 
            this.grvFachbereich.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFachbereich.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFachbereich.Appearance.Empty.Options.UseBackColor = true;
            this.grvFachbereich.Appearance.Empty.Options.UseFont = true;
            this.grvFachbereich.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFachbereich.Appearance.EvenRow.Options.UseFont = true;
            this.grvFachbereich.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFachbereich.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFachbereich.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFachbereich.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFachbereich.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFachbereich.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFachbereich.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFachbereich.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFachbereich.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFachbereich.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFachbereich.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFachbereich.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFachbereich.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFachbereich.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFachbereich.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFachbereich.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFachbereich.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFachbereich.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFachbereich.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFachbereich.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFachbereich.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFachbereich.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFachbereich.Appearance.GroupRow.Options.UseFont = true;
            this.grvFachbereich.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFachbereich.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFachbereich.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFachbereich.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFachbereich.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFachbereich.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFachbereich.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFachbereich.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFachbereich.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFachbereich.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFachbereich.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFachbereich.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFachbereich.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFachbereich.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFachbereich.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFachbereich.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFachbereich.Appearance.OddRow.Options.UseFont = true;
            this.grvFachbereich.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFachbereich.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFachbereich.Appearance.Row.Options.UseBackColor = true;
            this.grvFachbereich.Appearance.Row.Options.UseFont = true;
            this.grvFachbereich.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFachbereich.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFachbereich.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFachbereich.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFachbereich.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFachbereich.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFachbereich});
            this.grvFachbereich.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFachbereich.GridControl = this.grdFachbereich;
            this.grvFachbereich.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvFachbereich.Name = "grvFachbereich";
            this.grvFachbereich.OptionsBehavior.Editable = false;
            this.grvFachbereich.OptionsCustomization.AllowFilter = false;
            this.grvFachbereich.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFachbereich.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFachbereich.OptionsNavigation.UseTabKey = false;
            this.grvFachbereich.OptionsView.ColumnAutoWidth = false;
            this.grvFachbereich.OptionsView.RowAutoHeight = true;
            this.grvFachbereich.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFachbereich.OptionsView.ShowGroupPanel = false;
            this.grvFachbereich.OptionsView.ShowIndicator = false;
            // 
            // colFachbereich
            // 
            this.colFachbereich.Caption = "Zuteilung Fachbereich";
            this.colFachbereich.FieldName = "Info";
            this.colFachbereich.Name = "colFachbereich";
            this.colFachbereich.Visible = true;
            this.colFachbereich.VisibleIndex = 0;
            this.colFachbereich.Width = 377;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ReadOnly = true;
            // 
            // grdPraesenz
            // 
            this.grdPraesenz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPraesenz.DataSource = this.qryPraesenz;
            // 
            // 
            // 
            this.grdPraesenz.EmbeddedNavigator.Name = "";
            this.grdPraesenz.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdPraesenz.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdPraesenz.Location = new System.Drawing.Point(0, 48);
            this.grdPraesenz.MainView = this.gvPraesenz;
            this.grdPraesenz.Name = "grdPraesenz";
            this.grdPraesenz.Size = new System.Drawing.Size(964, 275);
            this.grdPraesenz.TabIndex = 1;
            this.grdPraesenz.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPraesenz});
            // 
            // gvPraesenz
            // 
            this.gvPraesenz.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvPraesenz.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenz.Appearance.Empty.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.Empty.Options.UseFont = true;
            this.gvPraesenz.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvPraesenz.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenz.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.EvenRow.Options.UseFont = true;
            this.gvPraesenz.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gvPraesenz.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenz.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvPraesenz.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.FocusedCell.Options.UseFont = true;
            this.gvPraesenz.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvPraesenz.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvPraesenz.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenz.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gvPraesenz.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.FocusedRow.Options.UseFont = true;
            this.gvPraesenz.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvPraesenz.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gvPraesenz.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gvPraesenz.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvPraesenz.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvPraesenz.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvPraesenz.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvPraesenz.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvPraesenz.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.GroupRow.Options.UseFont = true;
            this.gvPraesenz.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvPraesenz.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvPraesenz.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvPraesenz.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvPraesenz.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvPraesenz.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPraesenz.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvPraesenz.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenz.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvPraesenz.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvPraesenz.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvPraesenz.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gvPraesenz.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gvPraesenz.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenz.Appearance.OddRow.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.OddRow.Options.UseFont = true;
            this.gvPraesenz.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gvPraesenz.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenz.Appearance.Row.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.Row.Options.UseFont = true;
            this.gvPraesenz.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvPraesenz.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenz.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvPraesenz.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvPraesenz.Appearance.SelectedRow.Options.UseFont = true;
            this.gvPraesenz.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvPraesenz.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gvPraesenz.Appearance.VertLine.Options.UseBackColor = true;
            this.gvPraesenz.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvPraesenz.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKlient,
            this.colBG,
            this.colVN,
            this.col01,
            this.col02,
            this.col03,
            this.col04,
            this.col05,
            this.col06,
            this.col07,
            this.col08,
            this.col09,
            this.col10,
            this.col11,
            this.col12,
            this.col13,
            this.col14,
            this.col15,
            this.col16,
            this.col17,
            this.col18,
            this.col19,
            this.col20,
            this.col21,
            this.col22,
            this.col23,
            this.col24,
            this.col25,
            this.col26,
            this.col27,
            this.col28,
            this.col29,
            this.col30,
            this.col31,
            this.statA,
            this.statB,
            this.statC,
            this.statE,
            this.statF,
            this.statG,
            this.statH,
            this.statI,
            this.statY,
            this.statZ,
            this.statX,
            this.be01,
            this.be02,
            this.be03,
            this.be04,
            this.be05,
            this.be06,
            this.be07,
            this.be08,
            this.be09,
            this.be10,
            this.be11,
            this.be12,
            this.be13,
            this.be14,
            this.be15,
            this.be16,
            this.be17,
            this.be18,
            this.be19,
            this.be20,
            this.be21,
            this.be22,
            this.be23,
            this.be24,
            this.be25,
            this.be26,
            this.be27,
            this.be28,
            this.be29,
            this.be30,
            this.be31});
            this.gvPraesenz.GridControl = this.grdPraesenz;
            this.gvPraesenz.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvPraesenz.Name = "gvPraesenz";
            this.gvPraesenz.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvPraesenz.OptionsCustomization.AllowFilter = false;
            this.gvPraesenz.OptionsCustomization.AllowGroup = false;
            this.gvPraesenz.OptionsCustomization.AllowSort = false;
            this.gvPraesenz.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvPraesenz.OptionsNavigation.AutoFocusNewRow = true;
            this.gvPraesenz.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvPraesenz.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvPraesenz.OptionsPrint.AutoWidth = false;
            this.gvPraesenz.OptionsPrint.UsePrintStyles = true;
            this.gvPraesenz.OptionsView.ColumnAutoWidth = false;
            this.gvPraesenz.OptionsView.ShowDetailButtons = false;
            this.gvPraesenz.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvPraesenz.OptionsView.ShowGroupPanel = false;
            this.gvPraesenz.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvPraesenz_CustomDrawCell);
            this.gvPraesenz.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvPraesenz_RowCellStyle);
            this.gvPraesenz.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gvPraesenz_CustomRowCellEdit);
            this.gvPraesenz.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvPraesenz_ShowingEditor);
            this.gvPraesenz.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPraesenz_FocusedRowChanged);
            this.gvPraesenz.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gvPraesenz_FocusedColumnChanged);
            this.gvPraesenz.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvPraesenz_CellValueChanging);
            // 
            // colKlient
            // 
            this.colKlient.AppearanceCell.Options.UseTextOptions = true;
            this.colKlient.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKlient.Caption = "STES";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.OptionsColumn.ReadOnly = true;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 0;
            this.colKlient.Width = 200;
            // 
            // colBG
            // 
            this.colBG.Caption = "BG";
            this.colBG.FieldName = "BG";
            this.colBG.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colBG.Name = "colBG";
            this.colBG.Visible = true;
            this.colBG.VisibleIndex = 1;
            this.colBG.Width = 40;
            // 
            // colVN
            // 
            this.colVN.AppearanceCell.Options.UseTextOptions = true;
            this.colVN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVN.Caption = "V/N";
            this.colVN.FieldName = "VN";
            this.colVN.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colVN.Name = "colVN";
            this.colVN.OptionsColumn.AllowEdit = false;
            this.colVN.OptionsColumn.ReadOnly = true;
            this.colVN.Visible = true;
            this.colVN.VisibleIndex = 2;
            this.colVN.Width = 30;
            // 
            // col01
            // 
            this.col01.AppearanceCell.Options.UseTextOptions = true;
            this.col01.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col01.AppearanceHeader.Options.UseTextOptions = true;
            this.col01.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col01.Caption = "1";
            this.col01.FieldName = "Code01";
            this.col01.Name = "col01";
            this.col01.Visible = true;
            this.col01.VisibleIndex = 3;
            this.col01.Width = 25;
            // 
            // col02
            // 
            this.col02.AppearanceCell.Options.UseTextOptions = true;
            this.col02.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col02.AppearanceHeader.Options.UseTextOptions = true;
            this.col02.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col02.Caption = "2";
            this.col02.FieldName = "Code02";
            this.col02.Name = "col02";
            this.col02.Visible = true;
            this.col02.VisibleIndex = 4;
            this.col02.Width = 25;
            // 
            // col03
            // 
            this.col03.AppearanceCell.Options.UseTextOptions = true;
            this.col03.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col03.AppearanceHeader.Options.UseTextOptions = true;
            this.col03.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col03.Caption = "3";
            this.col03.FieldName = "Code03";
            this.col03.Name = "col03";
            this.col03.Visible = true;
            this.col03.VisibleIndex = 5;
            this.col03.Width = 25;
            // 
            // col04
            // 
            this.col04.AppearanceCell.Options.UseTextOptions = true;
            this.col04.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col04.AppearanceHeader.Options.UseTextOptions = true;
            this.col04.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col04.Caption = "4";
            this.col04.FieldName = "Code04";
            this.col04.Name = "col04";
            this.col04.Visible = true;
            this.col04.VisibleIndex = 6;
            this.col04.Width = 25;
            // 
            // col05
            // 
            this.col05.AppearanceCell.Options.UseTextOptions = true;
            this.col05.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col05.AppearanceHeader.Options.UseTextOptions = true;
            this.col05.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col05.Caption = "5";
            this.col05.FieldName = "Code05";
            this.col05.Name = "col05";
            this.col05.Visible = true;
            this.col05.VisibleIndex = 7;
            this.col05.Width = 25;
            // 
            // col06
            // 
            this.col06.AppearanceCell.Options.UseTextOptions = true;
            this.col06.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col06.AppearanceHeader.Options.UseTextOptions = true;
            this.col06.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col06.Caption = "6";
            this.col06.FieldName = "Code06";
            this.col06.Name = "col06";
            this.col06.Visible = true;
            this.col06.VisibleIndex = 8;
            this.col06.Width = 25;
            // 
            // col07
            // 
            this.col07.AppearanceCell.Options.UseTextOptions = true;
            this.col07.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col07.AppearanceHeader.Options.UseTextOptions = true;
            this.col07.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col07.Caption = "7";
            this.col07.FieldName = "Code07";
            this.col07.Name = "col07";
            this.col07.Visible = true;
            this.col07.VisibleIndex = 9;
            this.col07.Width = 25;
            // 
            // col08
            // 
            this.col08.AppearanceCell.Options.UseTextOptions = true;
            this.col08.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col08.AppearanceHeader.Options.UseTextOptions = true;
            this.col08.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col08.Caption = "8";
            this.col08.FieldName = "Code08";
            this.col08.Name = "col08";
            this.col08.Visible = true;
            this.col08.VisibleIndex = 10;
            this.col08.Width = 25;
            // 
            // col09
            // 
            this.col09.AppearanceCell.Options.UseTextOptions = true;
            this.col09.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col09.AppearanceHeader.Options.UseTextOptions = true;
            this.col09.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col09.Caption = "9";
            this.col09.FieldName = "Code09";
            this.col09.Name = "col09";
            this.col09.Visible = true;
            this.col09.VisibleIndex = 11;
            this.col09.Width = 25;
            // 
            // col10
            // 
            this.col10.AppearanceCell.Options.UseTextOptions = true;
            this.col10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col10.AppearanceHeader.Options.UseTextOptions = true;
            this.col10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col10.Caption = "10";
            this.col10.FieldName = "Code10";
            this.col10.Name = "col10";
            this.col10.Visible = true;
            this.col10.VisibleIndex = 12;
            this.col10.Width = 25;
            // 
            // col11
            // 
            this.col11.AppearanceCell.Options.UseTextOptions = true;
            this.col11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col11.AppearanceHeader.Options.UseTextOptions = true;
            this.col11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col11.Caption = "11";
            this.col11.FieldName = "Code11";
            this.col11.Name = "col11";
            this.col11.Visible = true;
            this.col11.VisibleIndex = 13;
            this.col11.Width = 25;
            // 
            // col12
            // 
            this.col12.AppearanceCell.Options.UseTextOptions = true;
            this.col12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col12.AppearanceHeader.Options.UseTextOptions = true;
            this.col12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col12.Caption = "12";
            this.col12.FieldName = "Code12";
            this.col12.Name = "col12";
            this.col12.Visible = true;
            this.col12.VisibleIndex = 14;
            this.col12.Width = 25;
            // 
            // col13
            // 
            this.col13.AppearanceCell.Options.UseTextOptions = true;
            this.col13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col13.AppearanceHeader.Options.UseTextOptions = true;
            this.col13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col13.Caption = "13";
            this.col13.FieldName = "Code13";
            this.col13.Name = "col13";
            this.col13.Visible = true;
            this.col13.VisibleIndex = 15;
            this.col13.Width = 25;
            // 
            // col14
            // 
            this.col14.AppearanceCell.Options.UseTextOptions = true;
            this.col14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col14.AppearanceHeader.Options.UseTextOptions = true;
            this.col14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col14.Caption = "14";
            this.col14.FieldName = "Code14";
            this.col14.Name = "col14";
            this.col14.Visible = true;
            this.col14.VisibleIndex = 16;
            this.col14.Width = 25;
            // 
            // col15
            // 
            this.col15.AppearanceCell.Options.UseTextOptions = true;
            this.col15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col15.AppearanceHeader.Options.UseTextOptions = true;
            this.col15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col15.Caption = "15";
            this.col15.FieldName = "Code15";
            this.col15.Name = "col15";
            this.col15.Visible = true;
            this.col15.VisibleIndex = 17;
            this.col15.Width = 25;
            // 
            // col16
            // 
            this.col16.AppearanceCell.Options.UseTextOptions = true;
            this.col16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col16.AppearanceHeader.Options.UseTextOptions = true;
            this.col16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col16.Caption = "16";
            this.col16.FieldName = "Code16";
            this.col16.Name = "col16";
            this.col16.Visible = true;
            this.col16.VisibleIndex = 18;
            this.col16.Width = 25;
            // 
            // col17
            // 
            this.col17.AppearanceCell.Options.UseTextOptions = true;
            this.col17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col17.AppearanceHeader.Options.UseTextOptions = true;
            this.col17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col17.Caption = "17";
            this.col17.FieldName = "Code17";
            this.col17.Name = "col17";
            this.col17.Visible = true;
            this.col17.VisibleIndex = 19;
            this.col17.Width = 25;
            // 
            // col18
            // 
            this.col18.AppearanceCell.Options.UseTextOptions = true;
            this.col18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col18.AppearanceHeader.Options.UseTextOptions = true;
            this.col18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col18.Caption = "18";
            this.col18.FieldName = "Code18";
            this.col18.Name = "col18";
            this.col18.Visible = true;
            this.col18.VisibleIndex = 20;
            this.col18.Width = 25;
            // 
            // col19
            // 
            this.col19.AppearanceCell.Options.UseTextOptions = true;
            this.col19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col19.AppearanceHeader.Options.UseTextOptions = true;
            this.col19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col19.Caption = "19";
            this.col19.FieldName = "Code19";
            this.col19.Name = "col19";
            this.col19.Visible = true;
            this.col19.VisibleIndex = 21;
            this.col19.Width = 25;
            // 
            // col20
            // 
            this.col20.AppearanceCell.Options.UseTextOptions = true;
            this.col20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col20.AppearanceHeader.Options.UseTextOptions = true;
            this.col20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col20.Caption = "20";
            this.col20.FieldName = "Code20";
            this.col20.Name = "col20";
            this.col20.Visible = true;
            this.col20.VisibleIndex = 22;
            this.col20.Width = 25;
            // 
            // col21
            // 
            this.col21.AppearanceCell.Options.UseTextOptions = true;
            this.col21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col21.AppearanceHeader.Options.UseTextOptions = true;
            this.col21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col21.Caption = "21";
            this.col21.FieldName = "Code21";
            this.col21.Name = "col21";
            this.col21.Visible = true;
            this.col21.VisibleIndex = 23;
            this.col21.Width = 25;
            // 
            // col22
            // 
            this.col22.AppearanceCell.Options.UseTextOptions = true;
            this.col22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col22.AppearanceHeader.Options.UseTextOptions = true;
            this.col22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col22.Caption = "22";
            this.col22.FieldName = "Code22";
            this.col22.Name = "col22";
            this.col22.Visible = true;
            this.col22.VisibleIndex = 24;
            this.col22.Width = 25;
            // 
            // col23
            // 
            this.col23.AppearanceCell.Options.UseTextOptions = true;
            this.col23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col23.AppearanceHeader.Options.UseTextOptions = true;
            this.col23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col23.Caption = "23";
            this.col23.FieldName = "Code23";
            this.col23.Name = "col23";
            this.col23.Visible = true;
            this.col23.VisibleIndex = 25;
            this.col23.Width = 25;
            // 
            // col24
            // 
            this.col24.AppearanceCell.Options.UseTextOptions = true;
            this.col24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col24.AppearanceHeader.Options.UseTextOptions = true;
            this.col24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col24.Caption = "24";
            this.col24.FieldName = "Code24";
            this.col24.Name = "col24";
            this.col24.Visible = true;
            this.col24.VisibleIndex = 26;
            this.col24.Width = 25;
            // 
            // col25
            // 
            this.col25.AppearanceCell.Options.UseTextOptions = true;
            this.col25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col25.AppearanceHeader.Options.UseTextOptions = true;
            this.col25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col25.Caption = "25";
            this.col25.FieldName = "Code25";
            this.col25.Name = "col25";
            this.col25.Visible = true;
            this.col25.VisibleIndex = 27;
            this.col25.Width = 25;
            // 
            // col26
            // 
            this.col26.AppearanceCell.Options.UseTextOptions = true;
            this.col26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col26.AppearanceHeader.Options.UseTextOptions = true;
            this.col26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col26.Caption = "26";
            this.col26.FieldName = "Code26";
            this.col26.Name = "col26";
            this.col26.Visible = true;
            this.col26.VisibleIndex = 28;
            this.col26.Width = 25;
            // 
            // col27
            // 
            this.col27.AppearanceCell.Options.UseTextOptions = true;
            this.col27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col27.AppearanceHeader.Options.UseTextOptions = true;
            this.col27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col27.Caption = "27";
            this.col27.FieldName = "Code27";
            this.col27.Name = "col27";
            this.col27.Visible = true;
            this.col27.VisibleIndex = 29;
            this.col27.Width = 25;
            // 
            // col28
            // 
            this.col28.AppearanceCell.Options.UseTextOptions = true;
            this.col28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col28.AppearanceHeader.Options.UseTextOptions = true;
            this.col28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col28.Caption = "28";
            this.col28.FieldName = "Code28";
            this.col28.Name = "col28";
            this.col28.Visible = true;
            this.col28.VisibleIndex = 30;
            this.col28.Width = 25;
            // 
            // col29
            // 
            this.col29.AppearanceCell.Options.UseTextOptions = true;
            this.col29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col29.AppearanceHeader.Options.UseTextOptions = true;
            this.col29.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col29.Caption = "29";
            this.col29.FieldName = "Code29";
            this.col29.Name = "col29";
            this.col29.Visible = true;
            this.col29.VisibleIndex = 31;
            this.col29.Width = 25;
            // 
            // col30
            // 
            this.col30.AppearanceCell.Options.UseTextOptions = true;
            this.col30.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col30.AppearanceHeader.Options.UseTextOptions = true;
            this.col30.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col30.Caption = "30";
            this.col30.FieldName = "Code30";
            this.col30.Name = "col30";
            this.col30.Visible = true;
            this.col30.VisibleIndex = 32;
            this.col30.Width = 25;
            // 
            // col31
            // 
            this.col31.AppearanceCell.Options.UseTextOptions = true;
            this.col31.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col31.AppearanceHeader.Options.UseTextOptions = true;
            this.col31.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col31.Caption = "31";
            this.col31.FieldName = "Code31";
            this.col31.Name = "col31";
            this.col31.Visible = true;
            this.col31.VisibleIndex = 33;
            this.col31.Width = 25;
            // 
            // statA
            // 
            this.statA.AppearanceCell.Options.UseTextOptions = true;
            this.statA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statA.AppearanceHeader.Options.UseTextOptions = true;
            this.statA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statA.Caption = "A";
            this.statA.FieldName = "StatA";
            this.statA.Name = "statA";
            this.statA.OptionsColumn.AllowEdit = false;
            this.statA.OptionsColumn.ReadOnly = true;
            this.statA.Visible = true;
            this.statA.VisibleIndex = 34;
            this.statA.Width = 30;
            // 
            // statB
            // 
            this.statB.AppearanceCell.Options.UseTextOptions = true;
            this.statB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statB.AppearanceHeader.Options.UseTextOptions = true;
            this.statB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statB.Caption = "B";
            this.statB.FieldName = "StatB";
            this.statB.Name = "statB";
            this.statB.OptionsColumn.AllowEdit = false;
            this.statB.OptionsColumn.ReadOnly = true;
            this.statB.Visible = true;
            this.statB.VisibleIndex = 35;
            this.statB.Width = 30;
            // 
            // statC
            // 
            this.statC.AppearanceCell.Options.UseTextOptions = true;
            this.statC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statC.AppearanceHeader.Options.UseTextOptions = true;
            this.statC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statC.Caption = "C";
            this.statC.FieldName = "StatC";
            this.statC.Name = "statC";
            this.statC.OptionsColumn.AllowEdit = false;
            this.statC.OptionsColumn.ReadOnly = true;
            this.statC.Visible = true;
            this.statC.VisibleIndex = 36;
            this.statC.Width = 30;
            // 
            // statE
            // 
            this.statE.AppearanceCell.Options.UseTextOptions = true;
            this.statE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statE.AppearanceHeader.Options.UseTextOptions = true;
            this.statE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statE.Caption = "E";
            this.statE.FieldName = "StatE";
            this.statE.Name = "statE";
            this.statE.OptionsColumn.AllowEdit = false;
            this.statE.OptionsColumn.ReadOnly = true;
            this.statE.Visible = true;
            this.statE.VisibleIndex = 37;
            this.statE.Width = 30;
            // 
            // statF
            // 
            this.statF.AppearanceCell.Options.UseTextOptions = true;
            this.statF.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statF.AppearanceHeader.Options.UseTextOptions = true;
            this.statF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statF.Caption = "F";
            this.statF.FieldName = "StatF";
            this.statF.Name = "statF";
            this.statF.OptionsColumn.AllowEdit = false;
            this.statF.OptionsColumn.ReadOnly = true;
            this.statF.Visible = true;
            this.statF.VisibleIndex = 38;
            this.statF.Width = 30;
            // 
            // statG
            // 
            this.statG.AppearanceCell.Options.UseTextOptions = true;
            this.statG.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statG.AppearanceHeader.Options.UseTextOptions = true;
            this.statG.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statG.Caption = "G";
            this.statG.FieldName = "StatG";
            this.statG.Name = "statG";
            this.statG.OptionsColumn.AllowEdit = false;
            this.statG.OptionsColumn.ReadOnly = true;
            this.statG.Visible = true;
            this.statG.VisibleIndex = 39;
            this.statG.Width = 30;
            // 
            // statH
            // 
            this.statH.AppearanceCell.Options.UseTextOptions = true;
            this.statH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statH.AppearanceHeader.Options.UseTextOptions = true;
            this.statH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statH.Caption = "H";
            this.statH.FieldName = "StatH";
            this.statH.Name = "statH";
            this.statH.OptionsColumn.AllowEdit = false;
            this.statH.OptionsColumn.ReadOnly = true;
            this.statH.Visible = true;
            this.statH.VisibleIndex = 40;
            this.statH.Width = 30;
            // 
            // statI
            // 
            this.statI.AppearanceCell.Options.UseTextOptions = true;
            this.statI.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statI.AppearanceHeader.Options.UseTextOptions = true;
            this.statI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statI.Caption = "I";
            this.statI.FieldName = "StatI";
            this.statI.Name = "statI";
            this.statI.OptionsColumn.AllowEdit = false;
            this.statI.OptionsColumn.ReadOnly = true;
            this.statI.Visible = true;
            this.statI.VisibleIndex = 41;
            this.statI.Width = 30;
            // 
            // statY
            // 
            this.statY.AppearanceCell.Options.UseTextOptions = true;
            this.statY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statY.AppearanceHeader.Options.UseTextOptions = true;
            this.statY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statY.Caption = "Y";
            this.statY.FieldName = "StatY";
            this.statY.Name = "statY";
            this.statY.OptionsColumn.AllowEdit = false;
            this.statY.OptionsColumn.ReadOnly = true;
            this.statY.Visible = true;
            this.statY.VisibleIndex = 42;
            this.statY.Width = 30;
            // 
            // statZ
            // 
            this.statZ.AppearanceCell.Options.UseTextOptions = true;
            this.statZ.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statZ.AppearanceHeader.Options.UseTextOptions = true;
            this.statZ.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statZ.Caption = "Z";
            this.statZ.FieldName = "StatZ";
            this.statZ.Name = "statZ";
            this.statZ.OptionsColumn.AllowEdit = false;
            this.statZ.OptionsColumn.ReadOnly = true;
            this.statZ.Visible = true;
            this.statZ.VisibleIndex = 43;
            this.statZ.Width = 30;
            // 
            // statX
            // 
            this.statX.AppearanceCell.Options.UseTextOptions = true;
            this.statX.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statX.AppearanceHeader.Options.UseTextOptions = true;
            this.statX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.statX.Caption = "X";
            this.statX.FieldName = "StatX";
            this.statX.Name = "statX";
            this.statX.OptionsColumn.AllowEdit = false;
            this.statX.OptionsColumn.ReadOnly = true;
            this.statX.Visible = true;
            this.statX.VisibleIndex = 44;
            this.statX.Width = 30;
            // 
            // be01
            // 
            this.be01.Caption = "gridColumn1";
            this.be01.FieldName = "Bem01";
            this.be01.Name = "be01";
            // 
            // be02
            // 
            this.be02.Caption = "gridColumn1";
            this.be02.FieldName = "Bem02";
            this.be02.Name = "be02";
            // 
            // be03
            // 
            this.be03.Caption = "gridColumn2";
            this.be03.FieldName = "Bem03";
            this.be03.Name = "be03";
            // 
            // be04
            // 
            this.be04.Caption = "gridColumn3";
            this.be04.FieldName = "Bem04";
            this.be04.Name = "be04";
            // 
            // be05
            // 
            this.be05.Caption = "gridColumn4";
            this.be05.FieldName = "Bem05";
            this.be05.Name = "be05";
            // 
            // be06
            // 
            this.be06.Caption = "gridColumn5";
            this.be06.FieldName = "Bem06";
            this.be06.Name = "be06";
            // 
            // be07
            // 
            this.be07.Caption = "gridColumn1";
            this.be07.FieldName = "Bem07";
            this.be07.Name = "be07";
            // 
            // be08
            // 
            this.be08.Caption = "gridColumn2";
            this.be08.FieldName = "Bem08";
            this.be08.Name = "be08";
            // 
            // be09
            // 
            this.be09.Caption = "gridColumn3";
            this.be09.FieldName = "Bem09";
            this.be09.Name = "be09";
            // 
            // be10
            // 
            this.be10.Caption = "gridColumn4";
            this.be10.FieldName = "Bem10";
            this.be10.Name = "be10";
            // 
            // be11
            // 
            this.be11.Caption = "gridColumn5";
            this.be11.FieldName = "Bem11";
            this.be11.Name = "be11";
            // 
            // be12
            // 
            this.be12.Caption = "gridColumn6";
            this.be12.FieldName = "Bem12";
            this.be12.Name = "be12";
            // 
            // be13
            // 
            this.be13.Caption = "gridColumn7";
            this.be13.FieldName = "Bem13";
            this.be13.Name = "be13";
            // 
            // be14
            // 
            this.be14.Caption = "gridColumn8";
            this.be14.FieldName = "Bem14";
            this.be14.Name = "be14";
            // 
            // be15
            // 
            this.be15.Caption = "gridColumn9";
            this.be15.FieldName = "Bem15";
            this.be15.Name = "be15";
            // 
            // be16
            // 
            this.be16.Caption = "gridColumn10";
            this.be16.FieldName = "Bem16";
            this.be16.Name = "be16";
            // 
            // be17
            // 
            this.be17.Caption = "gridColumn11";
            this.be17.FieldName = "Bem17";
            this.be17.Name = "be17";
            // 
            // be18
            // 
            this.be18.Caption = "gridColumn12";
            this.be18.FieldName = "Bem18";
            this.be18.Name = "be18";
            // 
            // be19
            // 
            this.be19.Caption = "gridColumn13";
            this.be19.FieldName = "Bem19";
            this.be19.Name = "be19";
            // 
            // be20
            // 
            this.be20.Caption = "gridColumn14";
            this.be20.FieldName = "Bem20";
            this.be20.Name = "be20";
            // 
            // be21
            // 
            this.be21.Caption = "gridColumn15";
            this.be21.FieldName = "Bem21";
            this.be21.Name = "be21";
            // 
            // be22
            // 
            this.be22.Caption = "gridColumn16";
            this.be22.FieldName = "Bem22";
            this.be22.Name = "be22";
            // 
            // be23
            // 
            this.be23.Caption = "gridColumn17";
            this.be23.FieldName = "Bem23";
            this.be23.Name = "be23";
            // 
            // be24
            // 
            this.be24.Caption = "gridColumn18";
            this.be24.FieldName = "Bem24";
            this.be24.Name = "be24";
            // 
            // be25
            // 
            this.be25.Caption = "gridColumn19";
            this.be25.FieldName = "Bem25";
            this.be25.Name = "be25";
            // 
            // be26
            // 
            this.be26.Caption = "gridColumn20";
            this.be26.FieldName = "Bem26";
            this.be26.Name = "be26";
            // 
            // be27
            // 
            this.be27.Caption = "gridColumn21";
            this.be27.FieldName = "Bem27";
            this.be27.Name = "be27";
            // 
            // be28
            // 
            this.be28.Caption = "gridColumn22";
            this.be28.FieldName = "Bem28";
            this.be28.Name = "be28";
            // 
            // be29
            // 
            this.be29.Caption = "gridColumn23";
            this.be29.FieldName = "Bem29";
            this.be29.Name = "be29";
            // 
            // be30
            // 
            this.be30.Caption = "gridColumn24";
            this.be30.FieldName = "Bem30";
            this.be30.Name = "be30";
            // 
            // be31
            // 
            this.be31.Caption = "gridColumn25";
            this.be31.FieldName = "Bem31";
            this.be31.Name = "be31";
            // 
            // pnlHead
            // 
            this.pnlHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHead.Controls.Add(this.btnPrint);
            this.pnlHead.Controls.Add(this.ddlMonatX);
            this.pnlHead.Controls.Add(this.lblMonatJahr);
            this.pnlHead.Controls.Add(this.btnRefresh);
            this.pnlHead.Controls.Add(this.edtJahr);
            this.pnlHead.Controls.Add(this.lblAnzDatensaetze);
            this.pnlHead.Controls.Add(this.lblRowCount);
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(964, 48);
            this.pnlHead.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(365, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 24);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Drucken";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ddlMonatX
            // 
            this.ddlMonatX.Location = new System.Drawing.Point(89, 11);
            this.ddlMonatX.LOVName = "Branche";
            this.ddlMonatX.Name = "ddlMonatX";
            this.ddlMonatX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlMonatX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlMonatX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlMonatX.Properties.Appearance.Options.UseBackColor = true;
            this.ddlMonatX.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlMonatX.Properties.Appearance.Options.UseFont = true;
            this.ddlMonatX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlMonatX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlMonatX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlMonatX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlMonatX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.ddlMonatX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.ddlMonatX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlMonatX.Properties.NullText = "";
            this.ddlMonatX.Properties.ShowFooter = false;
            this.ddlMonatX.Properties.ShowHeader = false;
            this.ddlMonatX.Size = new System.Drawing.Size(89, 24);
            this.ddlMonatX.TabIndex = 1;
            this.ddlMonatX.EditValueChanged += new System.EventHandler(this.ddlMonatX_EditValueChanged);
            // 
            // lblMonatJahr
            // 
            this.lblMonatJahr.ForeColor = System.Drawing.Color.Black;
            this.lblMonatJahr.Location = new System.Drawing.Point(12, 11);
            this.lblMonatJahr.Name = "lblMonatJahr";
            this.lblMonatJahr.Size = new System.Drawing.Size(71, 24);
            this.lblMonatJahr.TabIndex = 0;
            this.lblMonatJahr.Text = "Monat/Jahr";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(269, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 24);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Aktualisieren";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // edtJahr
            // 
            this.edtJahr.Location = new System.Drawing.Point(184, 11);
            this.edtJahr.Name = "edtJahr";
            this.edtJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtJahr.Properties.Appearance.Options.UseFont = true;
            this.edtJahr.Properties.Appearance.Options.UseTextOptions = true;
            this.edtJahr.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtJahr.Properties.Mask.BeepOnError = true;
            this.edtJahr.Properties.Mask.EditMask = "####";
            this.edtJahr.Size = new System.Drawing.Size(48, 24);
            this.edtJahr.TabIndex = 2;
            // 
            // lblAnzDatensaetze
            // 
            this.lblAnzDatensaetze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnzDatensaetze.AutoSize = true;
            this.lblAnzDatensaetze.Location = new System.Drawing.Point(807, 15);
            this.lblAnzDatensaetze.Name = "lblAnzDatensaetze";
            this.lblAnzDatensaetze.Size = new System.Drawing.Size(111, 15);
            this.lblAnzDatensaetze.TabIndex = 5;
            this.lblAnzDatensaetze.Text = "Anzahl Datensätze:";
            // 
            // lblRowCount
            // 
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.Location = new System.Drawing.Point(931, 17);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(14, 13);
            this.lblRowCount.TabIndex = 6;
            this.lblRowCount.Text = "0";
            // 
            // panDetail
            // 
            this.panDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panDetail.Controls.Add(this.memBemerkungRTF);
            this.panDetail.Controls.Add(this.lblBemerkung);
            this.panDetail.Controls.Add(this.grdInfo);
            this.panDetail.Controls.Add(this.datAustritt);
            this.panDetail.Controls.Add(this.grdFachbereich);
            this.panDetail.Controls.Add(this.lblAustritt);
            this.panDetail.Location = new System.Drawing.Point(6, 393);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(865, 221);
            this.panDetail.TabIndex = 1;
            // 
            // dlgFachbereichX
            // 
            this.dlgFachbereichX.Location = new System.Drawing.Point(154, 165);
            this.dlgFachbereichX.Name = "dlgFachbereichX";
            this.dlgFachbereichX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgFachbereichX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgFachbereichX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgFachbereichX.Properties.Appearance.Options.UseBackColor = true;
            this.dlgFachbereichX.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgFachbereichX.Properties.Appearance.Options.UseFont = true;
            this.dlgFachbereichX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.dlgFachbereichX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.dlgFachbereichX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgFachbereichX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.dlgFachbereichX.Size = new System.Drawing.Size(260, 24);
            this.dlgFachbereichX.TabIndex = 12;
            this.dlgFachbereichX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgFachbereichX_UserModifiedFld);
            // 
            // dlgKursX
            // 
            this.dlgKursX.Location = new System.Drawing.Point(154, 195);
            this.dlgKursX.Name = "dlgKursX";
            this.dlgKursX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgKursX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgKursX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgKursX.Properties.Appearance.Options.UseBackColor = true;
            this.dlgKursX.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgKursX.Properties.Appearance.Options.UseFont = true;
            this.dlgKursX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.dlgKursX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.dlgKursX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgKursX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.dlgKursX.Size = new System.Drawing.Size(405, 24);
            this.dlgKursX.TabIndex = 14;
            this.dlgKursX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgKursX_UserModifiedFld);
            // 
            // lblKurs
            // 
            this.lblKurs.Location = new System.Drawing.Point(39, 195);
            this.lblKurs.Name = "lblKurs";
            this.lblKurs.Size = new System.Drawing.Size(111, 24);
            this.lblKurs.TabIndex = 13;
            this.lblKurs.Text = "Kursname / -Nr.";
            // 
            // dlgFachleitungX
            // 
            this.dlgFachleitungX.IsSearchField = true;
            this.dlgFachleitungX.Location = new System.Drawing.Point(154, 135);
            this.dlgFachleitungX.Name = "dlgFachleitungX";
            this.dlgFachleitungX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgFachleitungX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgFachleitungX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgFachleitungX.Properties.Appearance.Options.UseBackColor = true;
            this.dlgFachleitungX.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgFachleitungX.Properties.Appearance.Options.UseFont = true;
            this.dlgFachleitungX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.dlgFachleitungX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.dlgFachleitungX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgFachleitungX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.dlgFachleitungX.Size = new System.Drawing.Size(260, 24);
            this.dlgFachleitungX.TabIndex = 10;
            // 
            // lblFachleitung
            // 
            this.lblFachleitung.ForeColor = System.Drawing.Color.Black;
            this.lblFachleitung.Location = new System.Drawing.Point(39, 135);
            this.lblFachleitung.Name = "lblFachleitung";
            this.lblFachleitung.Size = new System.Drawing.Size(80, 24);
            this.lblFachleitung.TabIndex = 9;
            this.lblFachleitung.Text = "Fachleitung";
            // 
            // dlgCoachX
            // 
            this.dlgCoachX.IsSearchField = true;
            this.dlgCoachX.Location = new System.Drawing.Point(154, 106);
            this.dlgCoachX.Name = "dlgCoachX";
            this.dlgCoachX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgCoachX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgCoachX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgCoachX.Properties.Appearance.Options.UseBackColor = true;
            this.dlgCoachX.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgCoachX.Properties.Appearance.Options.UseFont = true;
            this.dlgCoachX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.dlgCoachX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.dlgCoachX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgCoachX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.dlgCoachX.Size = new System.Drawing.Size(260, 24);
            this.dlgCoachX.TabIndex = 8;
            // 
            // lblZusatzX
            // 
            this.lblZusatzX.Location = new System.Drawing.Point(434, 76);
            this.lblZusatzX.Name = "lblZusatzX";
            this.lblZusatzX.Size = new System.Drawing.Size(48, 24);
            this.lblZusatzX.TabIndex = 5;
            this.lblZusatzX.Text = "Zusatz";
            // 
            // ddlZusatzX
            // 
            this.ddlZusatzX.Location = new System.Drawing.Point(484, 76);
            this.ddlZusatzX.LOVName = "KaApvZusatz";
            this.ddlZusatzX.Name = "ddlZusatzX";
            this.ddlZusatzX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlZusatzX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlZusatzX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlZusatzX.Properties.Appearance.Options.UseBackColor = true;
            this.ddlZusatzX.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlZusatzX.Properties.Appearance.Options.UseFont = true;
            this.ddlZusatzX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlZusatzX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlZusatzX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlZusatzX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlZusatzX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.ddlZusatzX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.ddlZusatzX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlZusatzX.Properties.NullText = "";
            this.ddlZusatzX.Properties.ShowFooter = false;
            this.ddlZusatzX.Properties.ShowHeader = false;
            this.ddlZusatzX.Size = new System.Drawing.Size(78, 24);
            this.ddlZusatzX.TabIndex = 6;
            // 
            // ddlAPVNrX
            // 
            this.ddlAPVNrX.Location = new System.Drawing.Point(154, 76);
            this.ddlAPVNrX.LOVName = "KaAPV";
            this.ddlAPVNrX.Name = "ddlAPVNrX";
            this.ddlAPVNrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.ddlAPVNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.ddlAPVNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAPVNrX.Properties.Appearance.Options.UseBackColor = true;
            this.ddlAPVNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.ddlAPVNrX.Properties.Appearance.Options.UseFont = true;
            this.ddlAPVNrX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ddlAPVNrX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ddlAPVNrX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.ddlAPVNrX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.ddlAPVNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.ddlAPVNrX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.ddlAPVNrX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ddlAPVNrX.Properties.NullText = "";
            this.ddlAPVNrX.Properties.ShowFooter = false;
            this.ddlAPVNrX.Properties.ShowHeader = false;
            this.ddlAPVNrX.Size = new System.Drawing.Size(260, 24);
            this.ddlAPVNrX.TabIndex = 4;
            // 
            // dlgKlientX
            // 
            this.dlgKlientX.Location = new System.Drawing.Point(154, 46);
            this.dlgKlientX.Name = "dlgKlientX";
            this.dlgKlientX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.dlgKlientX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.dlgKlientX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.dlgKlientX.Properties.Appearance.Options.UseBackColor = true;
            this.dlgKlientX.Properties.Appearance.Options.UseBorderColor = true;
            this.dlgKlientX.Properties.Appearance.Options.UseFont = true;
            this.dlgKlientX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.dlgKlientX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.dlgKlientX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dlgKlientX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.dlgKlientX.Size = new System.Drawing.Size(260, 24);
            this.dlgKlientX.TabIndex = 2;
            this.dlgKlientX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.dlgKlientX_UserModifiedFld);
            // 
            // lblFachbereich
            // 
            this.lblFachbereich.ForeColor = System.Drawing.Color.Black;
            this.lblFachbereich.Location = new System.Drawing.Point(39, 165);
            this.lblFachbereich.Name = "lblFachbereich";
            this.lblFachbereich.Size = new System.Drawing.Size(67, 24);
            this.lblFachbereich.TabIndex = 11;
            this.lblFachbereich.Text = "Fachbereich";
            // 
            // lblCoach
            // 
            this.lblCoach.ForeColor = System.Drawing.Color.Black;
            this.lblCoach.Location = new System.Drawing.Point(39, 106);
            this.lblCoach.Name = "lblCoach";
            this.lblCoach.Size = new System.Drawing.Size(80, 24);
            this.lblCoach.TabIndex = 7;
            this.lblCoach.Text = "zuständig KA";
            // 
            // lblAPVNr
            // 
            this.lblAPVNr.Location = new System.Drawing.Point(39, 77);
            this.lblAPVNr.Name = "lblAPVNr";
            this.lblAPVNr.Size = new System.Drawing.Size(48, 24);
            this.lblAPVNr.TabIndex = 3;
            this.lblAPVNr.Text = "APV-Nr";
            // 
            // lblKlientIn
            // 
            this.lblKlientIn.Location = new System.Drawing.Point(39, 46);
            this.lblKlientIn.Name = "lblKlientIn";
            this.lblKlientIn.Size = new System.Drawing.Size(97, 24);
            this.lblKlientIn.TabIndex = 1;
            this.lblKlientIn.Text = "STES";
            // 
            // edtTabWorkaroundInvisible
            // 
            this.edtTabWorkaroundInvisible.Location = new System.Drawing.Point(42, 285);
            this.edtTabWorkaroundInvisible.LOVName = "KaApvZusatz";
            this.edtTabWorkaroundInvisible.Name = "edtTabWorkaroundInvisible";
            this.edtTabWorkaroundInvisible.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTabWorkaroundInvisible.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTabWorkaroundInvisible.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTabWorkaroundInvisible.Properties.Appearance.Options.UseBackColor = true;
            this.edtTabWorkaroundInvisible.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTabWorkaroundInvisible.Properties.Appearance.Options.UseFont = true;
            this.edtTabWorkaroundInvisible.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTabWorkaroundInvisible.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTabWorkaroundInvisible.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTabWorkaroundInvisible.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTabWorkaroundInvisible.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtTabWorkaroundInvisible.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtTabWorkaroundInvisible.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTabWorkaroundInvisible.Properties.NullText = "";
            this.edtTabWorkaroundInvisible.Properties.ShowFooter = false;
            this.edtTabWorkaroundInvisible.Properties.ShowHeader = false;
            this.edtTabWorkaroundInvisible.Size = new System.Drawing.Size(78, 24);
            this.edtTabWorkaroundInvisible.TabIndex = 15;
            this.edtTabWorkaroundInvisible.Visible = false;
            // 
            // FrmKaPraesenzzeit
            // 
            this.ActiveSQLQuery = this.qryPraesenz;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(865, 500);
            this.ClientSize = new System.Drawing.Size(988, 614);
            this.Controls.Add(this.panDetail);
            this.Name = "FrmKaPraesenzzeit";
            this.Text = "KA Präsenzzeiterfassung";
            this.Load += new System.EventHandler(this.FrmKaPraesenzzeit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmKaPraesenzzeit_KeyDown);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.panDetail, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryPraesenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungRTF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAustritt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datAustritt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFachbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFachbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFachbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPraesenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPraesenz)).EndInit();
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMonatX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlMonatX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtJahr.Properties)).EndInit();
            this.panDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlgFachbereichX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgKursX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgFachleitungX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachleitung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgCoachX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatzX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZusatzX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlZusatzX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAPVNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlAPVNrX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dlgKlientX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCoach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAPVNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTabWorkaroundInvisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTabWorkaroundInvisible)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn be01;
        private DevExpress.XtraGrid.Columns.GridColumn be02;
        private DevExpress.XtraGrid.Columns.GridColumn be03;
        private DevExpress.XtraGrid.Columns.GridColumn be04;
        private DevExpress.XtraGrid.Columns.GridColumn be05;
        private DevExpress.XtraGrid.Columns.GridColumn be06;
        private DevExpress.XtraGrid.Columns.GridColumn be07;
        private DevExpress.XtraGrid.Columns.GridColumn be08;
        private DevExpress.XtraGrid.Columns.GridColumn be09;
        private DevExpress.XtraGrid.Columns.GridColumn be10;
        private DevExpress.XtraGrid.Columns.GridColumn be11;
        private DevExpress.XtraGrid.Columns.GridColumn be12;
        private DevExpress.XtraGrid.Columns.GridColumn be13;
        private DevExpress.XtraGrid.Columns.GridColumn be14;
        private DevExpress.XtraGrid.Columns.GridColumn be15;
        private DevExpress.XtraGrid.Columns.GridColumn be16;
        private DevExpress.XtraGrid.Columns.GridColumn be17;
        private DevExpress.XtraGrid.Columns.GridColumn be18;
        private DevExpress.XtraGrid.Columns.GridColumn be19;
        private DevExpress.XtraGrid.Columns.GridColumn be20;
        private DevExpress.XtraGrid.Columns.GridColumn be21;
        private DevExpress.XtraGrid.Columns.GridColumn be22;
        private DevExpress.XtraGrid.Columns.GridColumn be23;
        private DevExpress.XtraGrid.Columns.GridColumn be24;
        private DevExpress.XtraGrid.Columns.GridColumn be25;
        private DevExpress.XtraGrid.Columns.GridColumn be26;
        private DevExpress.XtraGrid.Columns.GridColumn be27;
        private DevExpress.XtraGrid.Columns.GridColumn be28;
        private DevExpress.XtraGrid.Columns.GridColumn be29;
        private DevExpress.XtraGrid.Columns.GridColumn be30;
        private DevExpress.XtraGrid.Columns.GridColumn be31;
        private KiSS4.Gui.KissButton btnPrint;
        private KiSS4.Gui.KissButton btnRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn col01;
        private DevExpress.XtraGrid.Columns.GridColumn col02;
        private DevExpress.XtraGrid.Columns.GridColumn col03;
        private DevExpress.XtraGrid.Columns.GridColumn col04;
        private DevExpress.XtraGrid.Columns.GridColumn col05;
        private DevExpress.XtraGrid.Columns.GridColumn col06;
        private DevExpress.XtraGrid.Columns.GridColumn col07;
        private DevExpress.XtraGrid.Columns.GridColumn col08;
        private DevExpress.XtraGrid.Columns.GridColumn col09;
        private DevExpress.XtraGrid.Columns.GridColumn col10;
        private DevExpress.XtraGrid.Columns.GridColumn col11;
        private DevExpress.XtraGrid.Columns.GridColumn col12;
        private DevExpress.XtraGrid.Columns.GridColumn col13;
        private DevExpress.XtraGrid.Columns.GridColumn col14;
        private DevExpress.XtraGrid.Columns.GridColumn col15;
        private DevExpress.XtraGrid.Columns.GridColumn col16;
        private DevExpress.XtraGrid.Columns.GridColumn col17;
        private DevExpress.XtraGrid.Columns.GridColumn col18;
        private DevExpress.XtraGrid.Columns.GridColumn col19;
        private DevExpress.XtraGrid.Columns.GridColumn col20;
        private DevExpress.XtraGrid.Columns.GridColumn col21;
        private DevExpress.XtraGrid.Columns.GridColumn col22;
        private DevExpress.XtraGrid.Columns.GridColumn col23;
        private DevExpress.XtraGrid.Columns.GridColumn col24;
        private DevExpress.XtraGrid.Columns.GridColumn col25;
        private DevExpress.XtraGrid.Columns.GridColumn col26;
        private DevExpress.XtraGrid.Columns.GridColumn col27;
        private DevExpress.XtraGrid.Columns.GridColumn col28;
        private DevExpress.XtraGrid.Columns.GridColumn col29;
        private DevExpress.XtraGrid.Columns.GridColumn col30;
        private DevExpress.XtraGrid.Columns.GridColumn col31;
        private DevExpress.XtraGrid.Columns.GridColumn colAustritt;
        private DevExpress.XtraGrid.Columns.GridColumn colFachbereich;
        private DevExpress.XtraGrid.Columns.GridColumn colInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colVN;
        private DevExpress.XtraGrid.Columns.GridColumn colZuweiser;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Gui.KissDateEdit datAustritt;
        private KiSS4.Gui.KissLookUpEdit ddlAPVNrX;
        private KiSS4.Gui.KissLookUpEdit ddlMonatX;
        private KiSS4.Gui.KissLookUpEdit ddlZusatzX;
        private KiSS4.Common.KissMitarbeiterButtonEdit dlgCoachX;
        private KiSS4.Gui.KissButtonEdit dlgFachbereichX;
        private KiSS4.Common.KissMitarbeiterButtonEdit dlgFachleitungX;
        private KiSS4.Gui.KissButtonEdit dlgKlientX;
        private KiSS4.Gui.KissButtonEdit dlgKursX;
        private KiSS4.Gui.KissCalcEdit edtJahr;
        private KiSS4.Gui.KissGrid grdFachbereich;
        private KiSS4.Gui.KissGrid grdInfo;
        private KiSS4.Gui.KissGrid grdPraesenz;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFachbereich;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPraesenz;
        private KiSS4.Gui.KissLabel lblAPVNr;
        private System.Windows.Forms.Label lblAnzDatensaetze;
        private KiSS4.Gui.KissLabel lblAustritt;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblCoach;
        private KiSS4.Gui.KissLabel lblFachbereich;
        private KiSS4.Gui.KissLabel lblFachleitung;
        private KiSS4.Gui.KissLabel lblKlientIn;
        private KiSS4.Gui.KissLabel lblKurs;
        private KiSS4.Gui.KissLabel lblMonatJahr;
        private System.Windows.Forms.Label lblRowCount;
        private KiSS4.Gui.KissLabel lblZusatzX;
        private KiSS4.Gui.KissMemoEdit memBemerkungRTF;
        private System.Windows.Forms.Panel panDetail;
        private System.Windows.Forms.Panel pnlHead;
        private KiSS4.DB.SqlQuery qryFachbereich;
        private KiSS4.DB.SqlQuery qryInfo;
        private KiSS4.DB.SqlQuery qryPraesenz;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemKaPraesenzCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn statA;
        private DevExpress.XtraGrid.Columns.GridColumn statB;
        private DevExpress.XtraGrid.Columns.GridColumn statC;
        private DevExpress.XtraGrid.Columns.GridColumn statE;
        private DevExpress.XtraGrid.Columns.GridColumn statF;
        private DevExpress.XtraGrid.Columns.GridColumn statG;
        private DevExpress.XtraGrid.Columns.GridColumn statH;
        private DevExpress.XtraGrid.Columns.GridColumn statI;
        private DevExpress.XtraGrid.Columns.GridColumn statZ;
        private DevExpress.XtraGrid.Columns.GridColumn statX;
        private DevExpress.XtraGrid.Columns.GridColumn statY;
        private DevExpress.XtraGrid.Columns.GridColumn colBG;
        private Gui.KissLookUpEdit edtTabWorkaroundInvisible;
    }
}
