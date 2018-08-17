using System;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query
{
    public class CtlQueryVmVormundschaftsregister : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAufhebungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBerichtseingang;
        private DevExpress.XtraGrid.Columns.GridColumn colErrichtungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colFallstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatort;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colMTName;
        private DevExpress.XtraGrid.Columns.GridColumn colMTOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colMTStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colMTTelefon;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodeBis;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriodeVon;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colZGB;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstand;
        private DevExpress.XtraGrid.Columns.GridColumn colprivat;
        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KiSS4.Gui.KissLookUpEdit edtFallstatus;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatum;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissLookUpEdit edtUserType;
        private KiSS4.Gui.KissTextEdit edtZGB;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblFallstatus;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblMandatstraeger;
        private KiSS4.Gui.KissLabel lblMandatstraegertyp;
        private KiSS4.Gui.KissLabel lblZGB;

        #endregion

        #region Constructors

        public CtlQueryVmVormundschaftsregister()
        {
            this.InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL( @"SELECT Code=1, Text = 'amtlich' UNION SELECT Code = 2, Text = 'PriMa'" );
            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow,0);
            NewRow.AcceptChanges();
            edtUserType.Properties.Columns.Clear();
            edtUserType.Properties.Columns.AddRange( new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       } );
            edtUserType.Properties.ShowFooter = false;
            edtUserType.Properties.ShowHeader = false;
            edtUserType.Properties.DisplayMember = "Text";
            edtUserType.Properties.ValueMember = "Code";
            edtUserType.Properties.DropDownRows = Math.Min( qry.Count, 7 );
            edtUserType.Properties.DataSource = qry;

            qry = DBUtil.OpenSQL( @"select Code = 1, Text = 'aktiv'
            union all
            select Code = 2, Text = 'geschlossen'
            union all
            select Code = 3, Text = 'archiviert'
            union all
            select Code = 4, Text = 'geschlossen + archiviert'" );
            NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow,0);
            NewRow.AcceptChanges();
            edtFallstatus.Properties.Columns.Clear();
            edtFallstatus.Properties.Columns.AddRange( new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       } );
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryVmVormundschaftsregister));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblFallstatus = new KiSS4.Gui.KissLabel();
            this.lblMandatstraeger = new KiSS4.Gui.KissLabel();
            this.lblMandatstraegertyp = new KiSS4.Gui.KissLabel();
            this.lblZGB = new KiSS4.Gui.KissLabel();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.edtGeburtsdatum = new KiSS4.Gui.KissDateEdit();
            this.edtFallstatus = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtUserType = new KiSS4.Gui.KissLookUpEdit();
            this.edtZGB = new KiSS4.Gui.KissTextEdit();
            this.colAufhebungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerichtseingang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErrichtungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMTName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMTOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMTStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMTTelefon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodeBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprivat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZGB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegertyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallstatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZGB.Properties)).BeginInit();
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
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.grdQuery1.MainView = this.gridView1;
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
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtZGB);
            this.tpgSuchen.Controls.Add(this.edtUserType);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtFallstatus);
            this.tpgSuchen.Controls.Add(this.edtGeburtsdatum);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.lblZGB);
            this.tpgSuchen.Controls.Add(this.lblMandatstraegertyp);
            this.tpgSuchen.Controls.Add(this.lblMandatstraeger);
            this.tpgSuchen.Controls.Add(this.lblFallstatus);
            this.tpgSuchen.Controls.Add(this.lblGeburtsdatum);
            this.tpgSuchen.Controls.Add(this.lblKlient);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGeburtsdatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFallstatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandatstraeger, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandatstraegertyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZGB, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtsdatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFallstatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserType, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZGB, 0);
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(10, 40);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(130, 24);
            this.lblKlient.TabIndex = 1;
            this.lblKlient.Text = "Klient";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // lblGeburtsdatum
            // 
            this.lblGeburtsdatum.Location = new System.Drawing.Point(10, 70);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(130, 24);
            this.lblGeburtsdatum.TabIndex = 2;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            this.lblGeburtsdatum.UseCompatibleTextRendering = true;
            // 
            // lblFallstatus
            // 
            this.lblFallstatus.Location = new System.Drawing.Point(10, 100);
            this.lblFallstatus.Name = "lblFallstatus";
            this.lblFallstatus.Size = new System.Drawing.Size(130, 24);
            this.lblFallstatus.TabIndex = 3;
            this.lblFallstatus.Text = "Fallstatus";
            this.lblFallstatus.UseCompatibleTextRendering = true;
            // 
            // lblMandatstraeger
            // 
            this.lblMandatstraeger.Location = new System.Drawing.Point(10, 130);
            this.lblMandatstraeger.Name = "lblMandatstraeger";
            this.lblMandatstraeger.Size = new System.Drawing.Size(130, 24);
            this.lblMandatstraeger.TabIndex = 4;
            this.lblMandatstraeger.Text = "Mandatstraeger";
            this.lblMandatstraeger.UseCompatibleTextRendering = true;
            // 
            // lblMandatstraegertyp
            // 
            this.lblMandatstraegertyp.Location = new System.Drawing.Point(10, 160);
            this.lblMandatstraegertyp.Name = "lblMandatstraegertyp";
            this.lblMandatstraegertyp.Size = new System.Drawing.Size(130, 24);
            this.lblMandatstraegertyp.TabIndex = 5;
            this.lblMandatstraegertyp.Text = "Mandatstraegertyp";
            this.lblMandatstraegertyp.UseCompatibleTextRendering = true;
            // 
            // lblZGB
            // 
            this.lblZGB.Location = new System.Drawing.Point(10, 190);
            this.lblZGB.Name = "lblZGB";
            this.lblZGB.Size = new System.Drawing.Size(130, 24);
            this.lblZGB.TabIndex = 6;
            this.lblZGB.Text = "ZGB";
            this.lblZGB.UseCompatibleTextRendering = true;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.EditValue = ((object)(resources.GetObject("edtBaPersonID.EditValue")));
            this.edtBaPersonID.Location = new System.Drawing.Point(150, 40);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Size = new System.Drawing.Size(200, 24);
            this.edtBaPersonID.TabIndex = 21;
            this.edtBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonID_UserModifiedFld);
            // 
            // edtGeburtsdatum
            // 
            this.edtGeburtsdatum.EditValue = "";
            this.edtGeburtsdatum.Location = new System.Drawing.Point(150, 70);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtGeburtsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatum.Properties.ShowToday = false;
            this.edtGeburtsdatum.Size = new System.Drawing.Size(100, 24);
            this.edtGeburtsdatum.TabIndex = 22;
            // 
            // edtFallstatus
            // 
            this.edtFallstatus.Location = new System.Drawing.Point(150, 100);
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
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtFallstatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtFallstatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFallstatus.Properties.NullText = "";
            this.edtFallstatus.Properties.ShowFooter = false;
            this.edtFallstatus.Properties.ShowHeader = false;
            this.edtFallstatus.Size = new System.Drawing.Size(200, 24);
            this.edtFallstatus.TabIndex = 23;
            // 
            // edtUserID
            // 
            this.edtUserID.EditValue = "";
            this.edtUserID.Location = new System.Drawing.Point(150, 130);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(200, 24);
            this.edtUserID.TabIndex = 24;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            // 
            // edtUserType
            // 
            this.edtUserType.Location = new System.Drawing.Point(150, 160);
            this.edtUserType.Name = "edtUserType";
            this.edtUserType.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserType.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserType.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserType.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserType.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserType.Properties.Appearance.Options.UseFont = true;
            this.edtUserType.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtUserType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserType.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtUserType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtUserType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUserType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUserType.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserType.Properties.NullText = "";
            this.edtUserType.Properties.ShowFooter = false;
            this.edtUserType.Properties.ShowHeader = false;
            this.edtUserType.Size = new System.Drawing.Size(200, 24);
            this.edtUserType.TabIndex = 25;
            // 
            // edtZGB
            // 
            this.edtZGB.EditValue = "";
            this.edtZGB.Location = new System.Drawing.Point(150, 190);
            this.edtZGB.Name = "edtZGB";
            this.edtZGB.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZGB.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZGB.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZGB.Properties.Appearance.Options.UseBackColor = true;
            this.edtZGB.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZGB.Properties.Appearance.Options.UseFont = true;
            this.edtZGB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZGB.Size = new System.Drawing.Size(200, 24);
            this.edtZGB.TabIndex = 26;
            // 
            // colAufhebungsdatum
            // 
            this.colAufhebungsdatum.Name = "colAufhebungsdatum";
            // 
            // colBerichtseingang
            // 
            this.colBerichtseingang.Name = "colBerichtseingang";
            // 
            // colErrichtungsdatum
            // 
            this.colErrichtungsdatum.Name = "colErrichtungsdatum";
            // 
            // colFallstatus
            // 
            this.colFallstatus.Name = "colFallstatus";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colHeimatort
            // 
            this.colHeimatort.Name = "colHeimatort";
            // 
            // colKlient
            // 
            this.colKlient.Name = "colKlient";
            // 
            // colMTName
            // 
            this.colMTName.Name = "colMTName";
            // 
            // colMTOrt
            // 
            this.colMTOrt.Name = "colMTOrt";
            // 
            // colMTStrasse
            // 
            this.colMTStrasse.Name = "colMTStrasse";
            // 
            // colMTTelefon
            // 
            this.colMTTelefon.Name = "colMTTelefon";
            // 
            // colOrt
            // 
            this.colOrt.Name = "colOrt";
            // 
            // colPeriodeBis
            // 
            this.colPeriodeBis.Name = "colPeriodeBis";
            // 
            // colPeriodeVon
            // 
            this.colPeriodeVon.Name = "colPeriodeVon";
            // 
            // colprivat
            // 
            this.colprivat.Name = "colprivat";
            // 
            // colStrasse
            // 
            this.colStrasse.Name = "colStrasse";
            // 
            // colZGB
            // 
            this.colZGB.Name = "colZGB";
            // 
            // colZivilstand
            // 
            this.colZivilstand.Name = "colZivilstand";
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
            // CtlQueryVmVormundschaftsregister
            // 
            this.Name = "CtlQueryVmVormundschaftsregister";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFallstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegertyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallstatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFallstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZGB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Private Methods

        private void edtBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                        edtBaPersonID.EditValue = null;
                        edtBaPersonID.LookupID = null;
              		return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                select distinct
                    ID = PRS.BaPersonID,
                    Klient = PRS.NameVorname,
                    Strasse = PRS.WohnsitzStrasseHausNr,
                    Ort     = PRS.WohnsitzPLZOrt,
                    Mandatstraeger = isNull(BEN.FirstName + ' ','') + isNull(BEN.LastName,'')
                from FbPeriode PER
                    inner join vwPerson        PRS on PRS.BaPersonID = PER.BaPersonID
                    left  join FaLeistung      FAL on FAL.BaPersonID = PER.BaPersonID and
                                                 FAL.ModulID = 5 and
                                                 FAL.DatumVon  = (select max(DatumVon)
                                                                  from   FaLeistung
                                                                  where  BaPersonID = PER.BaPersonID and
                                                                         FAL.ModulID = 5 and
                                                                         FaProzessCode = 501)
                    left  join XUser            BEN on BEN.UserID = FAL.UserID
                where PRS.NameVorname like {0} + '%'
                order by Klient",
              SearchString,
              e.ButtonClicked,null,null,null);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg[1];
                edtBaPersonID.LookupID = dlg[0];
            }
        }

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

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