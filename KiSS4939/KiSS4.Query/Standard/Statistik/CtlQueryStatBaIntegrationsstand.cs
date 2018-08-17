using System;
using KiSS4.DB;

namespace KiSS4.Query
{
    public class CtlQueryStatBaIntegrationsstand : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn col1617;
        private DevExpress.XtraGrid.Columns.GridColumn col1825;
        private DevExpress.XtraGrid.Columns.GridColumn col2640;
        private DevExpress.XtraGrid.Columns.GridColumn col4150;
        private DevExpress.XtraGrid.Columns.GridColumn col5165;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahl;
        private DevExpress.XtraGrid.Columns.GridColumn colIntegrationsstand;
        private DevExpress.XtraGrid.Columns.GridColumn colIntegrationszustand;
        private DevExpress.XtraGrid.Columns.GridColumn colLOV;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFall1;
        private KiSS4.Common.CtlGotoFall ctlGotoFallStelleBI;
        private KiSS4.Gui.KissLookUpEdit edtOrgUnitID;
        private KiSS4.Gui.KissDateEdit edtStichtag;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissGrid grdRohdaten1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRohdaten1;
        private KiSS4.Gui.KissGrid kissGrid1;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblSektion;
        private KiSS4.Gui.KissLabel lblStichtag;
        private KiSS4.DB.SqlQuery qryListe2;
        private KiSS4.DB.SqlQuery qryListe3;
        private SharpLibrary.WinControls.TabPageEx tpgList2;
        private SharpLibrary.WinControls.TabPageEx tpgList3;

        #endregion

        #region Constructors

        public CtlQueryStatBaIntegrationsstand()
        {
            this.InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL( @"SELECT Code = OrgUnitID, Text = ItemName
                         FROM XOrgUnit ORG
                         WHERE ORG.OrgUnitID = 30 OR ORG.ParentID = 30
                         ORDER BY ItemName" );
            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow,0);
            NewRow.AcceptChanges();
            edtOrgUnitID.Properties.Columns.Clear();
            edtOrgUnitID.Properties.Columns.AddRange( new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       } );
            edtOrgUnitID.Properties.ShowFooter = false;
            edtOrgUnitID.Properties.ShowHeader = false;
            edtOrgUnitID.Properties.DisplayMember = "Text";
            edtOrgUnitID.Properties.ValueMember = "Code";
            edtOrgUnitID.Properties.DropDownRows = Math.Min( qry.Count, 7 );
            edtOrgUnitID.Properties.DataSource = qry;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryStatBaIntegrationsstand));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            this.lblStichtag = new KiSS4.Gui.KissLabel();
            this.edtStichtag = new KiSS4.Gui.KissDateEdit();
            this.edtOrgUnitID = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.tpgList2 = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallStelleBI = new KiSS4.Common.CtlGotoFall();
            this.grdRohdaten1 = new KiSS4.Gui.KissGrid();
            this.qryListe2 = new KiSS4.DB.SqlQuery(this.components);
            this.grvRohdaten1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgList3 = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFall1 = new KiSS4.Common.CtlGotoFall();
            this.kissGrid1 = new KiSS4.Gui.KissGrid();
            this.qryListe3 = new KiSS4.DB.SqlQuery(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col1617 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col1825 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2640 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col4150 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col5165 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntegrationsstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIntegrationszustand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichtag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            this.tpgList2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten1)).BeginInit();
            this.tpgList3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe3)).BeginInit();
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
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(167, 398);
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
            this.tabControlSearch.Controls.Add(this.tpgList3);
            this.tabControlSearch.Controls.Add(this.tpgList2);
            this.tabControlSearch.SelectedTabIndex = 0;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgList2,
            this.tpgList3});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgList2, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgList3, 0);
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtOrgUnitID);
            this.tpgSuchen.Controls.Add(this.edtStichtag);
            this.tpgSuchen.Controls.Add(this.lblStichtag);
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStichtag, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStichtag, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrgUnitID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            //
            // lblSAR
            //
            this.lblSAR.Location = new System.Drawing.Point(10, 100);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 1;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            //
            // lblSektion
            //
            this.lblSektion.Location = new System.Drawing.Point(10, 70);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(130, 24);
            this.lblSektion.TabIndex = 1;
            this.lblSektion.Text = "Sektion";
            this.lblSektion.UseCompatibleTextRendering = true;
            //
            // lblStichtag
            //
            this.lblStichtag.Location = new System.Drawing.Point(10, 40);
            this.lblStichtag.Name = "lblStichtag";
            this.lblStichtag.Size = new System.Drawing.Size(130, 24);
            this.lblStichtag.TabIndex = 1;
            this.lblStichtag.Text = "Stichtag";
            this.lblStichtag.UseCompatibleTextRendering = true;
            //
            // edtStichtag
            //
            this.edtStichtag.EditValue = "";
            this.edtStichtag.Location = new System.Drawing.Point(150, 40);
            this.edtStichtag.Name = "edtStichtag";
            this.edtStichtag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStichtag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichtag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichtag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichtag.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichtag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichtag.Properties.Appearance.Options.UseFont = true;
            this.edtStichtag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtStichtag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtStichtag.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtStichtag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStichtag.Properties.ShowToday = false;
            this.edtStichtag.Size = new System.Drawing.Size(100, 24);
            this.edtStichtag.TabIndex = 20;
            //
            // edtOrgUnitID
            //
            this.edtOrgUnitID.Location = new System.Drawing.Point(150, 70);
            this.edtOrgUnitID.Name = "edtOrgUnitID";
            this.edtOrgUnitID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrgUnitID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrgUnitID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrgUnitID.Properties.Appearance.Options.UseFont = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtOrgUnitID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtOrgUnitID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtOrgUnitID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtOrgUnitID.Properties.NullText = "";
            this.edtOrgUnitID.Properties.ShowFooter = false;
            this.edtOrgUnitID.Properties.ShowHeader = false;
            this.edtOrgUnitID.Size = new System.Drawing.Size(250, 24);
            this.edtOrgUnitID.TabIndex = 21;
            //
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(150, 100);
            this.edtUserID.LookupSQL = resources.GetString("edtUserID.LookupSQL");
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
            this.edtUserID.TabIndex = 22;
            //
            // tpgList2
            //
            this.tpgList2.Controls.Add(this.ctlGotoFallStelleBI);
            this.tpgList2.Controls.Add(this.grdRohdaten1);
            this.tpgList2.Location = new System.Drawing.Point(6, 6);
            this.tpgList2.Name = "tpgList2";
            this.tpgList2.Size = new System.Drawing.Size(772, 424);
            this.tpgList2.TabIndex = 1;
            this.tpgList2.Title = "Liste 2";
            //
            // ctlGotoFallStelleBI
            //
            this.ctlGotoFallStelleBI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallStelleBI.BaPersonID = ((object)(resources.GetObject("ctlGotoFallStelleBI.BaPersonID")));
            this.ctlGotoFallStelleBI.Location = new System.Drawing.Point(3, 399);
            this.ctlGotoFallStelleBI.Name = "ctlGotoFallStelleBI";
            this.ctlGotoFallStelleBI.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallStelleBI.TabIndex = 7;
            this.ctlGotoFallStelleBI.Visible = false;
            //
            // grdRohdaten1
            //
            this.grdRohdaten1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRohdaten1.ColumnFilterActivated = true;
            this.grdRohdaten1.DataSource = this.qryListe2;
            this.grdRohdaten1.EmbeddedNavigator.Name = "";
            this.grdRohdaten1.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdRohdaten1.Location = new System.Drawing.Point(3, 1);
            this.grdRohdaten1.MainView = this.grvRohdaten1;
            this.grdRohdaten1.Name = "grdRohdaten1";
            this.grdRohdaten1.Size = new System.Drawing.Size(766, 392);
            this.grdRohdaten1.TabIndex = 6;
            this.grdRohdaten1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRohdaten1});
            //
            // qryListe2
            //
            this.qryListe2.FillTimeOut = 300;
            this.qryListe2.HostControl = this;
            this.qryListe2.SelectStatement = resources.GetString("qryListe2.SelectStatement");
            //
            // grvRohdaten1
            //
            this.grvRohdaten1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvRohdaten1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.Empty.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.Empty.Options.UseFont = true;
            this.grvRohdaten1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.EvenRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRohdaten1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvRohdaten1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvRohdaten1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvRohdaten1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRohdaten1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvRohdaten1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvRohdaten1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRohdaten1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRohdaten1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRohdaten1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRohdaten1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.GroupRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvRohdaten1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvRohdaten1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvRohdaten1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRohdaten1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvRohdaten1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRohdaten1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvRohdaten1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRohdaten1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvRohdaten1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvRohdaten1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.OddRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvRohdaten1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.Row.Options.UseBackColor = true;
            this.grvRohdaten1.Appearance.Row.Options.UseFont = true;
            this.grvRohdaten1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvRohdaten1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvRohdaten1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvRohdaten1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvRohdaten1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRohdaten1.GridControl = this.grdRohdaten1;
            this.grvRohdaten1.Name = "grvRohdaten1";
            this.grvRohdaten1.OptionsBehavior.Editable = false;
            this.grvRohdaten1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvRohdaten1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvRohdaten1.OptionsNavigation.UseTabKey = false;
            this.grvRohdaten1.OptionsView.ColumnAutoWidth = false;
            this.grvRohdaten1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRohdaten1.OptionsView.ShowGroupPanel = false;
            this.grvRohdaten1.OptionsView.ShowIndicator = false;
            //
            // tpgList3
            //
            this.tpgList3.Controls.Add(this.ctlGotoFall1);
            this.tpgList3.Controls.Add(this.kissGrid1);
            this.tpgList3.Location = new System.Drawing.Point(6, 6);
            this.tpgList3.Name = "tpgList3";
            this.tpgList3.Size = new System.Drawing.Size(772, 424);
            this.tpgList3.TabIndex = 2;
            this.tpgList3.Title = "Liste 3";
            //
            // ctlGotoFall1
            //
            this.ctlGotoFall1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall1.BaPersonID = ((object)(resources.GetObject("ctlGotoFall1.BaPersonID")));
            this.ctlGotoFall1.Location = new System.Drawing.Point(3, 399);
            this.ctlGotoFall1.Name = "ctlGotoFall1";
            this.ctlGotoFall1.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFall1.TabIndex = 7;
            this.ctlGotoFall1.Visible = false;
            //
            // kissGrid1
            //
            this.kissGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissGrid1.ColumnFilterActivated = true;
            this.kissGrid1.DataSource = this.qryListe3;
            this.kissGrid1.EmbeddedNavigator.Name = "";
            this.kissGrid1.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.kissGrid1.Location = new System.Drawing.Point(3, 1);
            this.kissGrid1.MainView = this.gridView1;
            this.kissGrid1.Name = "kissGrid1";
            this.kissGrid1.Size = new System.Drawing.Size(766, 392);
            this.kissGrid1.TabIndex = 6;
            this.kissGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            //
            // qryListe3
            //
            this.qryListe3.FillTimeOut = 300;
            this.qryListe3.HostControl = this;
            this.qryListe3.SelectStatement = resources.GetString("qryListe3.SelectStatement");
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
            this.gridView1.GridControl = this.kissGrid1;
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
            // col1617
            //
            this.col1617.Name = "col1617";
            //
            // col1825
            //
            this.col1825.Name = "col1825";
            //
            // col2640
            //
            this.col2640.Name = "col2640";
            //
            // col4150
            //
            this.col4150.Name = "col4150";
            //
            // col5165
            //
            this.col5165.Name = "col5165";
            //
            // colAnzahl
            //
            this.colAnzahl.Name = "colAnzahl";
            //
            // colIntegrationsstand
            //
            this.colIntegrationsstand.Name = "colIntegrationsstand";
            //
            // colIntegrationszustand
            //
            this.colIntegrationszustand.Name = "colIntegrationszustand";
            //
            // colLOV
            //
            this.colLOV.Name = "colLOV";
            //
            // colOrgUnit
            //
            this.colOrgUnit.Name = "colOrgUnit";
            //
            // colPerson
            //
            this.colPerson.Name = "colPerson";
            //
            // colSAR
            //
            this.colSAR.Name = "colSAR";
            //
            // CtlQueryStatBaIntegrationsstand
            //
            this.Name = "CtlQueryStatBaIntegrationsstand";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichtag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrgUnitID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            this.tpgList2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten1)).EndInit();
            this.tpgList3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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