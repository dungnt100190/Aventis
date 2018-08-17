using System;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query.BSS
{
    public class CtlQueryVmInventarfristen : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn col30TageFrist;
        private DevExpress.XtraGrid.Columns.GridColumn col30TageFristeingehalten;
        private DevExpress.XtraGrid.Columns.GridColumn col7TageFrist;
        private DevExpress.XtraGrid.Columns.GridColumn col7TageFristeingehalten;
        private DevExpress.XtraGrid.Columns.GridColumn colAufgenommen;
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnung;
        private DevExpress.XtraGrid.Columns.GridColumn colErstkontakt;
        private DevExpress.XtraGrid.Columns.GridColumn colGenehmigung;
        private DevExpress.XtraGrid.Columns.GridColumn colInventarVorlage;
        private DevExpress.XtraGrid.Columns.GridColumn colMahnung;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colVersand;
        private KiSS4.Gui.KissCheckEdit edtBemerkungen;
        private KiSS4.Gui.KissDateEdit edtEroeffnungBis;
        private KiSS4.Gui.KissDateEdit edtEroeffnungVon;
        private KiSS4.Gui.KissLookUpEdit edtFallstatus;
        private KiSS4.Gui.KissCheckEdit edtFrist30Tage;
        private KiSS4.Gui.KissCheckEdit edtFrist7Tage;
        private KiSS4.Gui.KissDateEdit edtGenehmigungBis;
        private KiSS4.Gui.KissDateEdit edtGenehmigungVon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblEroeffnungvon;
        private KiSS4.Gui.KissLabel lblFallstatus;
        private KiSS4.Gui.KissLabel lblGenehmigungvon;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblbis;
        private KissMitarbeiterButtonEdit edtUserID;
        private KiSS4.Gui.KissLabel lblbis1;

        #endregion

        #region Constructors

        public CtlQueryVmInventarfristen()
        {
            this.InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT Code = 1, Text = 'aktiv'
                    UNION ALL
                    SELECT Code = 2, Text = 'geschlossen'
                    UNION ALL
                    SELECT Code = 3, Text = 'archiviert'
                    UNION ALL
                    SELECT Code = 4, Text = 'geschlossen + archiviert'");

            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";

            qry.DataTable.Rows.InsertAt(NewRow,0);

            NewRow.AcceptChanges();

            edtFallstatus.Properties.Columns.Clear();
            edtFallstatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                    {new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)});
            edtFallstatus.Properties.ShowFooter = false;
            edtFallstatus.Properties.ShowHeader = false;
            edtFallstatus.Properties.DisplayMember = "Text";
            edtFallstatus.Properties.ValueMember = "Code";
            edtFallstatus.Properties.DropDownRows = Math.Min( qry.Count, 7 );
            edtFallstatus.Properties.DataSource = qry;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryVmInventarfristen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblEroeffnungvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.lblGenehmigungvon = new KiSS4.Gui.KissLabel();
            this.lblbis1 = new KiSS4.Gui.KissLabel();
            this.lblFallstatus = new KiSS4.Gui.KissLabel();
            this.edtEroeffnungVon = new KiSS4.Gui.KissDateEdit();
            this.edtEroeffnungBis = new KiSS4.Gui.KissDateEdit();
            this.edtGenehmigungVon = new KiSS4.Gui.KissDateEdit();
            this.edtGenehmigungBis = new KiSS4.Gui.KissDateEdit();
            this.edtFallstatus = new KiSS4.Gui.KissLookUpEdit();
            this.edtFrist7Tage = new KiSS4.Gui.KissCheckEdit();
            this.edtFrist30Tage = new KiSS4.Gui.KissCheckEdit();
            this.edtBemerkungen = new KiSS4.Gui.KissCheckEdit();
            this.col30TageFrist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col30TageFristeingehalten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7TageFrist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col7TageFristeingehalten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufgenommen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstkontakt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGenehmigung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventarVorlage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMahnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtUserID = new KiSS4.Common.KissMitarbeiterButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGenehmigungvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenehmigungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenehmigungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFrist7Tage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFrist30Tage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
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
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
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
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtBemerkungen);
            this.tpgSuchen.Controls.Add(this.edtFrist30Tage);
            this.tpgSuchen.Controls.Add(this.edtFrist7Tage);
            this.tpgSuchen.Controls.Add(this.edtFallstatus);
            this.tpgSuchen.Controls.Add(this.edtGenehmigungBis);
            this.tpgSuchen.Controls.Add(this.edtGenehmigungVon);
            this.tpgSuchen.Controls.Add(this.edtEroeffnungBis);
            this.tpgSuchen.Controls.Add(this.edtEroeffnungVon);
            this.tpgSuchen.Controls.Add(this.lblFallstatus);
            this.tpgSuchen.Controls.Add(this.lblbis1);
            this.tpgSuchen.Controls.Add(this.lblGenehmigungvon);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblEroeffnungvon);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEroeffnungvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGenehmigungvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFallstatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEroeffnungVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEroeffnungBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGenehmigungVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGenehmigungBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFallstatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFrist7Tage, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFrist30Tage, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBemerkungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(10, 40);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 1;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // lblEroeffnungvon
            // 
            this.lblEroeffnungvon.Location = new System.Drawing.Point(10, 70);
            this.lblEroeffnungvon.Name = "lblEroeffnungvon";
            this.lblEroeffnungvon.Size = new System.Drawing.Size(130, 24);
            this.lblEroeffnungvon.TabIndex = 2;
            this.lblEroeffnungvon.Text = "Eroeffnung von";
            this.lblEroeffnungvon.UseCompatibleTextRendering = true;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(270, 70);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 3;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // lblGenehmigungvon
            // 
            this.lblGenehmigungvon.Location = new System.Drawing.Point(10, 100);
            this.lblGenehmigungvon.Name = "lblGenehmigungvon";
            this.lblGenehmigungvon.Size = new System.Drawing.Size(130, 24);
            this.lblGenehmigungvon.TabIndex = 4;
            this.lblGenehmigungvon.Text = "Genehmigung von";
            this.lblGenehmigungvon.UseCompatibleTextRendering = true;
            // 
            // lblbis1
            // 
            this.lblbis1.Location = new System.Drawing.Point(270, 100);
            this.lblbis1.Name = "lblbis1";
            this.lblbis1.Size = new System.Drawing.Size(130, 24);
            this.lblbis1.TabIndex = 5;
            this.lblbis1.Text = "bis";
            this.lblbis1.UseCompatibleTextRendering = true;
            // 
            // lblFallstatus
            // 
            this.lblFallstatus.Location = new System.Drawing.Point(10, 130);
            this.lblFallstatus.Name = "lblFallstatus";
            this.lblFallstatus.Size = new System.Drawing.Size(130, 24);
            this.lblFallstatus.TabIndex = 6;
            this.lblFallstatus.Text = "Fallstatus";
            this.lblFallstatus.UseCompatibleTextRendering = true;
            // 
            // edtEroeffnungVon
            // 
            this.edtEroeffnungVon.EditValue = "";
            this.edtEroeffnungVon.Location = new System.Drawing.Point(150, 70);
            this.edtEroeffnungVon.Name = "edtEroeffnungVon";
            this.edtEroeffnungVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEroeffnungVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungVon.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtEroeffnungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtEroeffnungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungVon.Properties.ShowToday = false;
            this.edtEroeffnungVon.Size = new System.Drawing.Size(100, 24);
            this.edtEroeffnungVon.TabIndex = 21;
            // 
            // edtEroeffnungBis
            // 
            this.edtEroeffnungBis.EditValue = "";
            this.edtEroeffnungBis.Location = new System.Drawing.Point(300, 70);
            this.edtEroeffnungBis.Name = "edtEroeffnungBis";
            this.edtEroeffnungBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEroeffnungBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEroeffnungBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEroeffnungBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEroeffnungBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEroeffnungBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEroeffnungBis.Properties.Appearance.Options.UseFont = true;
            this.edtEroeffnungBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtEroeffnungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEroeffnungBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtEroeffnungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEroeffnungBis.Properties.ShowToday = false;
            this.edtEroeffnungBis.Size = new System.Drawing.Size(100, 24);
            this.edtEroeffnungBis.TabIndex = 22;
            // 
            // edtGenehmigungVon
            // 
            this.edtGenehmigungVon.EditValue = "";
            this.edtGenehmigungVon.Location = new System.Drawing.Point(150, 100);
            this.edtGenehmigungVon.Name = "edtGenehmigungVon";
            this.edtGenehmigungVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGenehmigungVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGenehmigungVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGenehmigungVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGenehmigungVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtGenehmigungVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGenehmigungVon.Properties.Appearance.Options.UseFont = true;
            this.edtGenehmigungVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtGenehmigungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGenehmigungVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtGenehmigungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGenehmigungVon.Properties.ShowToday = false;
            this.edtGenehmigungVon.Size = new System.Drawing.Size(100, 24);
            this.edtGenehmigungVon.TabIndex = 23;
            // 
            // edtGenehmigungBis
            // 
            this.edtGenehmigungBis.EditValue = "";
            this.edtGenehmigungBis.Location = new System.Drawing.Point(300, 100);
            this.edtGenehmigungBis.Name = "edtGenehmigungBis";
            this.edtGenehmigungBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGenehmigungBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGenehmigungBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGenehmigungBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGenehmigungBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGenehmigungBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGenehmigungBis.Properties.Appearance.Options.UseFont = true;
            this.edtGenehmigungBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtGenehmigungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGenehmigungBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtGenehmigungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGenehmigungBis.Properties.ShowToday = false;
            this.edtGenehmigungBis.Size = new System.Drawing.Size(100, 24);
            this.edtGenehmigungBis.TabIndex = 24;
            // 
            // edtFallstatus
            // 
            this.edtFallstatus.Location = new System.Drawing.Point(150, 130);
            this.edtFallstatus.Name = "edtFallstatus";
            this.edtFallstatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFallstatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFallstatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallstatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtFallstatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFallstatus.Properties.Appearance.Options.UseFont = true;
            this.edtFallstatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtFallstatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtFallstatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtFallstatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtFallstatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtFallstatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtFallstatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallstatus.Properties.NullText = "";
            this.edtFallstatus.Properties.ShowFooter = false;
            this.edtFallstatus.Properties.ShowHeader = false;
            this.edtFallstatus.Size = new System.Drawing.Size(250, 24);
            this.edtFallstatus.TabIndex = 25;
            // 
            // edtFrist7Tage
            // 
            this.edtFrist7Tage.EditValue = false;
            this.edtFrist7Tage.Location = new System.Drawing.Point(150, 160);
            this.edtFrist7Tage.Name = "edtFrist7Tage";
            this.edtFrist7Tage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtFrist7Tage.Properties.Appearance.Options.UseBackColor = true;
            this.edtFrist7Tage.Properties.Caption = "Frist ueber 7 Tage";
            this.edtFrist7Tage.Size = new System.Drawing.Size(250, 19);
            this.edtFrist7Tage.TabIndex = 26;
            // 
            // edtFrist30Tage
            // 
            this.edtFrist30Tage.EditValue = false;
            this.edtFrist30Tage.Location = new System.Drawing.Point(150, 190);
            this.edtFrist30Tage.Name = "edtFrist30Tage";
            this.edtFrist30Tage.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtFrist30Tage.Properties.Appearance.Options.UseBackColor = true;
            this.edtFrist30Tage.Properties.Caption = "Frist ueber 30 Tage";
            this.edtFrist30Tage.Size = new System.Drawing.Size(250, 19);
            this.edtFrist30Tage.TabIndex = 27;
            // 
            // edtBemerkungen
            // 
            this.edtBemerkungen.EditValue = false;
            this.edtBemerkungen.Location = new System.Drawing.Point(150, 220);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Caption = "inkl. Bemerkungen";
            this.edtBemerkungen.Size = new System.Drawing.Size(250, 19);
            this.edtBemerkungen.TabIndex = 28;
            // 
            // col30TageFrist
            // 
            this.col30TageFrist.Name = "col30TageFrist";
            // 
            // col30TageFristeingehalten
            // 
            this.col30TageFristeingehalten.Name = "col30TageFristeingehalten";
            // 
            // col7TageFrist
            // 
            this.col7TageFrist.Name = "col7TageFrist";
            // 
            // col7TageFristeingehalten
            // 
            this.col7TageFristeingehalten.Name = "col7TageFristeingehalten";
            // 
            // colAufgenommen
            // 
            this.colAufgenommen.Name = "colAufgenommen";
            // 
            // colAutor
            // 
            this.colAutor.Name = "colAutor";
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Name = "colBemerkungen";
            // 
            // colErffnung
            // 
            this.colErffnung.Name = "colErffnung";
            // 
            // colErstkontakt
            // 
            this.colErstkontakt.Name = "colErstkontakt";
            // 
            // colGenehmigung
            // 
            this.colGenehmigung.Name = "colGenehmigung";
            // 
            // colInventarVorlage
            // 
            this.colInventarVorlage.Name = "colInventarVorlage";
            // 
            // colMahnung
            // 
            this.colMahnung.Name = "colMahnung";
            // 
            // colPerson
            // 
            this.colPerson.Name = "colPerson";
            // 
            // colSAR
            // 
            this.colSAR.Name = "colSAR";
            // 
            // colVersand
            // 
            this.colVersand.Name = "colVersand";
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
            // edtUserID
            // 
            this.edtUserID.IsSearchField = true;
            this.edtUserID.Location = new System.Drawing.Point(150, 39);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(250, 24);
            this.edtUserID.TabIndex = 29;
            // 
            // CtlQueryVmInventarfristen
            // 
            this.Name = "CtlQueryVmInventarfristen";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEroeffnungvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGenehmigungvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEroeffnungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenehmigungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGenehmigungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFrist7Tage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFrist30Tage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Private Methods

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            String SearchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        #endregion
    }
}