

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public class CtlQueryWhEkEntscheid : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colEntscheidJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colEntscheidKW;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colGrund;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colTeam;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colWhEkEntscheidID;
        private DevExpress.XtraGrid.Columns.GridColumn colZentrum;
        private KiSS4.Dokument.XDokument edtDoc;
        private KiSS4.Gui.KissDateEdit edtEntscheidJahr;
        private KiSS4.Gui.KissCalcEdit edtEntscheidKW;
        private KiSS4.Gui.KissButtonEdit edtSucheKlient;
        private KiSS4.Gui.KissButtonEdit edtSucheMA;
        private KiSS4.Gui.KissLookUpEdit edtSucheOrgUnit;
        private KiSS4.Gui.KissLookUpEdit edtSucheSozialzentrum;

        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel lblJahr;
        private KiSS4.Gui.KissLabel lblKW;
        private KiSS4.Gui.KissLabel lblWhSucheKlientX;
        private KiSS4.Gui.KissLabel lblWhSucheSAR;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;

        SqlQuery qryDat = DBUtil.OpenSQL(@"SELECT SozialzentrumCode, OrgUnitID 
                           FROM vwUser USR
                             INNER JOIN XLOVCode LOV ON LOV.LOVName = 'FaSozialzentrum' AND Code = USR.SozialzentrumCode
                           WHERE UserID = {0}", Session.User.UserID);

        #endregion

        #region Constructors

        public CtlQueryWhEkEntscheid()
        {
            this.InitializeComponent();

            // AllowMultiselecting sollte nicht durch den Designer gesetzt werden, da sonst Nebenwirkungen entstehen können
            // (RunSearch wird aufgerufen bevor IntializeComponent fertig ist). Siehe #6074.
            this.AllowMultiselecting = true;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryWhEkEntscheid));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtEntscheidKW = new KiSS4.Gui.KissCalcEdit();
            this.lblJahr = new KiSS4.Gui.KissLabel();
            this.lblKW = new KiSS4.Gui.KissLabel();
            this.edtEntscheidJahr = new KiSS4.Gui.KissDateEdit();
            this.btnSave = new KiSS4.Gui.KissButton();
            this.edtDoc = new KiSS4.Dokument.XDokument();
            this.edtSucheMA = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheKlient = new KiSS4.Gui.KissButtonEdit();
            this.lblWhSucheSAR = new KiSS4.Gui.KissLabel();
            this.lblWhSucheKlientX = new KiSS4.Gui.KissLabel();
            this.edtSucheSozialzentrum = new KiSS4.Gui.KissLookUpEdit();
            this.edtSucheOrgUnit = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntscheidJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntscheidKW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaLeistungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWhEkEntscheidID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZentrum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtEntscheidKW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEntscheidJahr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheKlientX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSozialzentrum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSozialzentrum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.CanUpdate = true;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.TableName = "WhEkEntscheid";
            this.qryQuery.PositionChanged += new System.EventHandler(this.qryQuery_PositionChanged);
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
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colUser,
            this.colZentrum,
            this.colTeam,
            this.colGrund,
            this.colKlient,
            this.colBemerkung,
            this.colEntscheidJahr,
            this.colEntscheidKW,
            this.colID});
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
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdQuery1.Size = new System.Drawing.Size(766, 391);
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(740, 397);
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
            this.xDocument.Size = new System.Drawing.Size(29, 24);
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "KlientensystemID$";
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.edtDoc);
            this.tpgListe.Controls.Add(this.btnSave);
            this.tpgListe.Controls.Add(this.edtEntscheidJahr);
            this.tpgListe.Controls.Add(this.lblKW);
            this.tpgListe.Controls.Add(this.lblJahr);
            this.tpgListe.Controls.Add(this.edtEntscheidKW);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.edtEntscheidKW, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblJahr, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblKW, 0);
            this.tpgListe.Controls.SetChildIndex(this.edtEntscheidJahr, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnSave, 0);
            this.tpgListe.Controls.SetChildIndex(this.edtDoc, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.kissLabel12);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.edtSucheOrgUnit);
            this.tpgSuchen.Controls.Add(this.edtSucheSozialzentrum);
            this.tpgSuchen.Controls.Add(this.lblWhSucheKlientX);
            this.tpgSuchen.Controls.Add(this.lblWhSucheSAR);
            this.tpgSuchen.Controls.Add(this.edtSucheKlient);
            this.tpgSuchen.Controls.Add(this.edtSucheMA);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMA, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWhSucheSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblWhSucheKlientX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSozialzentrum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheOrgUnit, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel12, 0);
            // 
            // edtEntscheidKW
            // 
            this.edtEntscheidKW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEntscheidKW.Location = new System.Drawing.Point(167, 398);
            this.edtEntscheidKW.Name = "edtEntscheidKW";
            this.edtEntscheidKW.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEntscheidKW.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEntscheidKW.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEntscheidKW.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEntscheidKW.Properties.Appearance.Options.UseBackColor = true;
            this.edtEntscheidKW.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEntscheidKW.Properties.Appearance.Options.UseFont = true;
            this.edtEntscheidKW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtEntscheidKW.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEntscheidKW.Size = new System.Drawing.Size(60, 24);
            this.edtEntscheidKW.TabIndex = 3;
            // 
            // lblJahr
            // 
            this.lblJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblJahr.Location = new System.Drawing.Point(234, 397);
            this.lblJahr.Name = "lblJahr";
            this.lblJahr.Size = new System.Drawing.Size(32, 24);
            this.lblJahr.TabIndex = 5;
            this.lblJahr.Text = "Jahr";
            this.lblJahr.UseCompatibleTextRendering = true;
            // 
            // lblKW
            // 
            this.lblKW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKW.Location = new System.Drawing.Point(129, 397);
            this.lblKW.Name = "lblKW";
            this.lblKW.Size = new System.Drawing.Size(32, 24);
            this.lblKW.TabIndex = 5;
            this.lblKW.Text = "KW";
            this.lblKW.UseCompatibleTextRendering = true;
            // 
            // edtEntscheidJahr
            // 
            this.edtEntscheidJahr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEntscheidJahr.EditValue = "";
            this.edtEntscheidJahr.Location = new System.Drawing.Point(272, 398);
            this.edtEntscheidJahr.Name = "edtEntscheidJahr";
            this.edtEntscheidJahr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEntscheidJahr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEntscheidJahr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEntscheidJahr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEntscheidJahr.Properties.Appearance.Options.UseBackColor = true;
            this.edtEntscheidJahr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEntscheidJahr.Properties.Appearance.Options.UseFont = true;
            this.edtEntscheidJahr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtEntscheidJahr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEntscheidJahr.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtEntscheidJahr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEntscheidJahr.Properties.DisplayFormat.FormatString = "yyyy";
            this.edtEntscheidJahr.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtEntscheidJahr.Properties.EditFormat.FormatString = "yyyy";
            this.edtEntscheidJahr.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtEntscheidJahr.Properties.Mask.EditMask = "yyyy";
            this.edtEntscheidJahr.Properties.ShowToday = false;
            this.edtEntscheidJahr.Size = new System.Drawing.Size(53, 24);
            this.edtEntscheidJahr.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(349, 397);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 24);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "KW festlegen";
            this.btnSave.UseCompatibleTextRendering = true;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // edtDoc
            // 
            this.edtDoc.AllowDrop = true;
            this.edtDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDoc.CanCreateDocument = false;
            this.edtDoc.CanDeleteDocument = false;
            this.edtDoc.CanImportDocument = false;
            this.edtDoc.Context = null;
            this.edtDoc.DataMember = "DocumentID";
            this.edtDoc.DataSource = this.qryQuery;
            this.edtDoc.Location = new System.Drawing.Point(445, 398);
            this.edtDoc.Name = "edtDoc";
            this.edtDoc.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDoc.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDoc.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDoc.Properties.Appearance.Options.UseBackColor = true;
            this.edtDoc.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDoc.Properties.Appearance.Options.UseFont = true;
            this.edtDoc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDoc.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDoc.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDoc.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDoc.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument importieren")});
            this.edtDoc.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDoc.Properties.ReadOnly = true;
            this.edtDoc.Size = new System.Drawing.Size(110, 24);
            this.edtDoc.TabIndex = 8;
            // 
            // edtSucheMA
            // 
            this.edtSucheMA.Location = new System.Drawing.Point(127, 110);
            this.edtSucheMA.LookupSQL = resources.GetString("edtSucheMA.LookupSQL");
            this.edtSucheMA.Name = "edtSucheMA";
            this.edtSucheMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSucheMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSucheMA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMA.Size = new System.Drawing.Size(260, 24);
            this.edtSucheMA.TabIndex = 1;
            // 
            // edtSucheKlient
            // 
            this.edtSucheKlient.Location = new System.Drawing.Point(127, 140);
            this.edtSucheKlient.LookupSQL = "select \r\n  ID$ = BaPersonID, \r\n  MA  = Name + isNull(\', \' + Vorname,\'\'),\r\n  [Pers" +
                "on ID] = BaPersonID\r\nfrom   BaPerson\r\nwhere Name + IsNull(\', \' + Vorname,\'\') LIK" +
                "E \'%\' + {0} + \'%\'\r\norder by MA\r\n----";
            this.edtSucheKlient.Name = "edtSucheKlient";
            this.edtSucheKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKlient.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKlient.Size = new System.Drawing.Size(260, 24);
            this.edtSucheKlient.TabIndex = 2;
            // 
            // lblWhSucheSAR
            // 
            this.lblWhSucheSAR.Location = new System.Drawing.Point(8, 110);
            this.lblWhSucheSAR.Name = "lblWhSucheSAR";
            this.lblWhSucheSAR.Size = new System.Drawing.Size(70, 24);
            this.lblWhSucheSAR.TabIndex = 22;
            this.lblWhSucheSAR.Text = "SA";
            this.lblWhSucheSAR.UseCompatibleTextRendering = true;
            // 
            // lblWhSucheKlientX
            // 
            this.lblWhSucheKlientX.Location = new System.Drawing.Point(8, 140);
            this.lblWhSucheKlientX.Name = "lblWhSucheKlientX";
            this.lblWhSucheKlientX.Size = new System.Drawing.Size(70, 24);
            this.lblWhSucheKlientX.TabIndex = 23;
            this.lblWhSucheKlientX.Text = "Klient";
            this.lblWhSucheKlientX.UseCompatibleTextRendering = true;
            // 
            // edtSucheSozialzentrum
            // 
            this.edtSucheSozialzentrum.Location = new System.Drawing.Point(127, 50);
            this.edtSucheSozialzentrum.LOVName = "FaSozialzentrum";
            this.edtSucheSozialzentrum.Name = "edtSucheSozialzentrum";
            this.edtSucheSozialzentrum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheSozialzentrum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheSozialzentrum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSozialzentrum.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheSozialzentrum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheSozialzentrum.Properties.Appearance.Options.UseFont = true;
            this.edtSucheSozialzentrum.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheSozialzentrum.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSozialzentrum.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheSozialzentrum.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheSozialzentrum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheSozialzentrum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheSozialzentrum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheSozialzentrum.Properties.NullText = "";
            this.edtSucheSozialzentrum.Properties.ShowFooter = false;
            this.edtSucheSozialzentrum.Properties.ShowHeader = false;
            this.edtSucheSozialzentrum.Size = new System.Drawing.Size(260, 24);
            this.edtSucheSozialzentrum.TabIndex = 311;
            this.edtSucheSozialzentrum.EditValueChanged += new System.EventHandler(this.edtSucheSozialzentrum_EditValueChanged);
            // 
            // edtSucheOrgUnit
            // 
            this.edtSucheOrgUnit.Location = new System.Drawing.Point(127, 80);
            this.edtSucheOrgUnit.Name = "edtSucheOrgUnit";
            this.edtSucheOrgUnit.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrgUnit.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrgUnit.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrgUnit.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrgUnit.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrgUnit.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrgUnit.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheOrgUnit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrgUnit.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheOrgUnit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheOrgUnit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheOrgUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheOrgUnit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheOrgUnit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtSucheOrgUnit.Properties.DisplayMember = "Text";
            this.edtSucheOrgUnit.Properties.NullText = "";
            this.edtSucheOrgUnit.Properties.ShowFooter = false;
            this.edtSucheOrgUnit.Properties.ShowHeader = false;
            this.edtSucheOrgUnit.Properties.ValueMember = "Code";
            this.edtSucheOrgUnit.Size = new System.Drawing.Size(260, 24);
            this.edtSucheOrgUnit.TabIndex = 312;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(8, 50);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(100, 23);
            this.kissLabel4.TabIndex = 313;
            this.kissLabel4.Text = "Sozialzentrum";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // kissLabel12
            // 
            this.kissLabel12.Location = new System.Drawing.Point(8, 80);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(100, 23);
            this.kissLabel12.TabIndex = 314;
            this.kissLabel12.Text = "Organisationseinheit$$";
            this.kissLabel12.UseCompatibleTextRendering = true;
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Name = "colBaPersonID";
            // 
            // colBemerkung
            // 
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.FieldName = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.OptionsColumn.ReadOnly = true;
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 6;
            this.colBemerkung.Width = 256;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.OptionsColumn.ReadOnly = true;
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            // 
            // colEntscheidJahr
            // 
            this.colEntscheidJahr.Caption = "Jahr";
            this.colEntscheidJahr.FieldName = "EntscheidJahr";
            this.colEntscheidJahr.Name = "colEntscheidJahr";
            this.colEntscheidJahr.OptionsColumn.ReadOnly = true;
            this.colEntscheidJahr.Visible = true;
            this.colEntscheidJahr.VisibleIndex = 7;
            this.colEntscheidJahr.Width = 46;
            // 
            // colEntscheidKW
            // 
            this.colEntscheidKW.Caption = "KW";
            this.colEntscheidKW.FieldName = "EntscheidKW";
            this.colEntscheidKW.Name = "colEntscheidKW";
            this.colEntscheidKW.OptionsColumn.ReadOnly = true;
            this.colEntscheidKW.Visible = true;
            this.colEntscheidKW.VisibleIndex = 8;
            this.colEntscheidKW.Width = 37;
            // 
            // colFaLeistungID
            // 
            this.colFaLeistungID.Name = "colFaLeistungID";
            // 
            // colGrund
            // 
            this.colGrund.Caption = "Grund";
            this.colGrund.FieldName = "Grund";
            this.colGrund.Name = "colGrund";
            this.colGrund.OptionsColumn.ReadOnly = true;
            this.colGrund.Visible = true;
            this.colGrund.VisibleIndex = 4;
            this.colGrund.Width = 135;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "WhEkEntscheidID";
            this.colID.Name = "colID";
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.ReadOnly = true;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 5;
            this.colKlient.Width = 98;
            // 
            // colTeam
            // 
            this.colTeam.Caption = "Team";
            this.colTeam.FieldName = "OrgUnit";
            this.colTeam.Name = "colTeam";
            this.colTeam.Visible = true;
            this.colTeam.VisibleIndex = 3;
            this.colTeam.Width = 130;
            // 
            // colUser
            // 
            this.colUser.Caption = "SA";
            this.colUser.FieldName = "UserName";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.ReadOnly = true;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 1;
            this.colUser.Width = 69;
            // 
            // colUserName
            // 
            this.colUserName.Name = "colUserName";
            // 
            // colWhEkEntscheidID
            // 
            this.colWhEkEntscheidID.Name = "colWhEkEntscheidID";
            // 
            // colZentrum
            // 
            this.colZentrum.Caption = "Zentrum";
            this.colZentrum.FieldName = "SozialzentrumKurz";
            this.colZentrum.Name = "colZentrum";
            this.colZentrum.Visible = true;
            this.colZentrum.VisibleIndex = 2;
            this.colZentrum.Width = 70;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // CtlQueryWhEkEntscheid
            // 
            this.Name = "CtlQueryWhEkEntscheid";
            this.Load += new System.EventHandler(this.CtlQueryWhEkEntscheid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtEntscheidKW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblJahr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEntscheidJahr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWhSucheKlientX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSozialzentrum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSozialzentrum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrgUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Public Methods

        public void SetDefaultValues()
        {
            DateTime date = DateTime.Now;
            // Aktuelle Kultur ermitteln
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            // Aktuellen Kalender ermitteln
            Calendar calendar = currentCulture.Calendar;
            // Kalenderwoche über das Calendar-Objekt ermitteln
            int calendarWeek = calendar.GetWeekOfYear(date,
                currentCulture.DateTimeFormat.CalendarWeekRule,
                currentCulture.DateTimeFormat.FirstDayOfWeek);
            // Überprüfen, ob eine Kalenderwoche größer als 52 ermittelt wurde und ob
            // die Kalenderwoche des Datums in einer Woche 2 ergibt: In diesem Fall hat
            // GetWeekOfYear die Kalenderwoche nicht nach ISO 8601 berechnet (Montag,
            // der 30.12.2003 wird z. B. fälschlicherweise als KW 53 berechnet).
            // Die Kalenderwoche wird dann auf 1 gesetzt
            if (calendarWeek > 52)
            {
                date = date.AddDays(7);
                int testCalendarWeek = calendar.GetWeekOfYear(date,
                    currentCulture.DateTimeFormat.CalendarWeekRule,
                    currentCulture.DateTimeFormat.FirstDayOfWeek);
                if (testCalendarWeek == 2)
                    calendarWeek = 1;
            }
            // Das Jahr der Kalenderwoche ermitteln
            int year = date.Year;
            if (calendarWeek == 1 && date.Month == 12)
                year++;
            if (calendarWeek >= 52 && date.Month == 1)
                year--;
            // Die ermittelte Kalenderwoche zurückgeben
            edtEntscheidJahr.EditValue = DateTime.Now;
            edtEntscheidKW.EditValue = calendarWeek + 1;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            this.edtSucheSozialzentrum.EditValue = qryDat["SozialzentrumCode"];
            this.edtSucheOrgUnit.EditValue = qryDat["OrgUnitID"];
        }

        protected override void RunSearch()
        {
            base.RunSearch();
        }
        #endregion

        #region Private Methods

        private void CtlQueryWhEkEntscheid_Load(object sender, System.EventArgs e)
        {
            SetDefaultValues();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            // Selektierte rows bestimmen
            List<string> ids = new List<string>();
            foreach (int rowHandle in grdQuery1.View.GetSelectedRows())
            {
                DataRow row = grdQuery1.View.GetDataRow(rowHandle);
                ids.Add(row["WhEkEntscheidID"].ToString());
            }

            // zurücksetzen
            if( DBUtil.IsEmpty(edtEntscheidKW.EditValue) && DBUtil.IsEmpty(edtEntscheidJahr.EditValue))
            {
                try
                {
                    DBUtil.ExecSQLThrowingException(string.Format("UPDATE WhEkEntscheid SET EntscheidJahr = NULL, EntscheidKW = NULL WHERE WhEkEntscheidID IN ({0})", string.Join(",", ids.ToArray())));
                }
                catch( KissCancelException ex )
                {
                    KissMsg.ShowError("CtlQueryWhEkEntscheid", "PersonGrundSitzungNichtEindeutig", "Person, Grund und Sitzung müssen eindeutig sein", ex);
                }
            }
            else
            {
                if( DBUtil.IsEmpty(edtEntscheidKW.EditValue) || DBUtil.IsEmpty(edtEntscheidJahr.EditValue))
                {
                    KissMsg.ShowError("CtlQueryWhEkEntscheid", "WerteLeer", "Die Felder 'Entscheid Jahr' und 'Entscheid KW' müssen ausgefüllt sein.");
                    return;
                }

                int kw   = (int)edtEntscheidKW.Value;
                int year = ((DateTime)edtEntscheidJahr.EditValue).Year;

                if( kw < 1 || kw > 54 )
                {
                    KissMsg.ShowError("CtlQueryWhEkEntscheid", "KWFalsch", "Bitte geben Sie einen gültigen Wert für 'Entscheid KW' ein.");
                    return;
                }

                if( DateTime.Now > new DateTime( year, 12, 31 ) || year > 2100 )
                {
                    KissMsg.ShowError("CtlQueryWhEkEntscheid", "JahrFalsch", "Bitte geben Sie einen gültigen Wert für 'Entscheid Jahr' ein.");
                    return;
                }

                try
                {
                    DBUtil.ExecSQLThrowingException(string.Format("UPDATE WhEkEntscheid SET EntscheidJahr = {1}, EntscheidKW = {2} WHERE WhEkEntscheidID IN ({0})", string.Join(",", ids.ToArray()), "{0}", "{1}"), year, kw);
                }
                catch( KissCancelException ex )
                {
                    KissMsg.ShowError("CtlQueryWhEkEntscheid", "PersonGrundSitzungNichtEindeutig", "Person, Grund und Sitzung müssen eindeutig sein", ex);
                }
            }
            qryQuery.Refresh();
        }

        private void edtSucheSozialzentrum_EditValueChanged(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(edtSucheSozialzentrum.EditValue))
            {
                edtSucheOrgUnit.EditValue = null;
            }

            edtSucheOrgUnit.LoadQuery(DBUtil.OpenSQL(@"
                SELECT Code = ORG.OrgUnitID, Text = ORG.ItemName
                    FROM XLOVCode         LOV
                     INNER JOIN XOrgUnit  ORG ON ORG.parentid = convert(int, LOV.Value1)
                    WHERE
                 LOV.Code = {0} and LOVName like 'FaSozialzentrum'
                union all
                 select null,null
                order by Text", edtSucheSozialzentrum.EditValue));
            if (((SqlQuery)edtSucheOrgUnit.Properties.DataSource).Count >= 1)
            {
                edtSucheOrgUnit.EditValue = ((SqlQuery)edtSucheOrgUnit.Properties.DataSource)["Code"];
            }
            else
            {
                edtSucheOrgUnit.EditValue = null;
            }
        }

        private void qryQuery_PositionChanged(object sender, System.EventArgs e)
        {
            //bool traktandiert = !DBUtil.IsEmpty(qryQuery["EntscheidKW"]) ||
            //                    !DBUtil.IsEmpty(qryQuery["EntscheidJahr"]);

            bool traktandiert = false;

            edtDoc.EditMode =  traktandiert ? EditModeType.ReadOnly : EditModeType.Normal;
            qryQuery.CanUpdate = !traktandiert;
        }

        #endregion
    }
}