using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;

using KiSS4.DB;
using KiSS4.FAMOZ.WorkerProcess;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Basis.ZH
{
    public class CtlSstIKAuszugImport : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        private string _importPath;
        private KiSS4.Gui.KissButton btnDeactivate;
        private KissButton btnGeneratePDFs;
        private KissButton btnImport;
        private KissButton btnRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAnforderungDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colExportDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colFaFallIDs;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtstag;
        private DevExpress.XtraGrid.Columns.GridColumn colJahrBis;
        private DevExpress.XtraGrid.Columns.GridColumn colJahrVon;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colVersichertennummer;
        private DevExpress.XtraGrid.Columns.GridColumn colWhEkEntscheidID;
        private DevExpress.XtraGrid.Columns.GridColumn colZIPNr;
        private DevExpress.XtraGrid.Columns.GridColumn gridImportFehler;
        private StreamWriter importLogWriter = null;
        private KissLabel kissLabel5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;

        #endregion

        #endregion

        #region Constructors

        public CtlSstIKAuszugImport()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlSstIKAuszugImport));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnDeactivate = new KiSS4.Gui.KissButton();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahrVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahrBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaLeistungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersichertennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnforderungDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZIPNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWhEkEntscheidID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtstag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnRefresh = new KiSS4.Gui.KissButton();
            this.gridImportFehler = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.btnImport = new KiSS4.Gui.KissButton();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExportDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaFallIDs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGeneratePDFs = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.BatchUpdate = true;
            this.qryQuery.CanUpdate = true;
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
            this.grvQuery1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatus,
            this.colNameVorname,
            this.colFaFallIDs,
            this.colBaPersonID,
            this.colZIPNr,
            this.colGeburtstag,
            this.colAHVNummer,
            this.colVersichertennummer,
            this.colAnforderungDatum,
            this.colUser,
            this.colJahrVon,
            this.colJahrBis,
            this.colExportDatum,
            this.colBemerkung,
            this.gridImportFehler});
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
            this.grdQuery1.Size = new System.Drawing.Size(766, 241);
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(740, -143);
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
            this.ctlGotoFall.DataMember = "KlientensystemBaPersonID";
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 367);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Location = new System.Drawing.Point(8, 65);
            this.tabControlSearch.Size = new System.Drawing.Size(784, 432);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.btnGeneratePDFs);
            this.tpgListe.Controls.Add(this.btnImport);
            this.tpgListe.Controls.Add(this.btnRefresh);
            this.tpgListe.Controls.Add(this.btnDeactivate);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(772, 394);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnDeactivate, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnRefresh, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnImport, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnGeneratePDFs, 0);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(772, 394);
            //
            // btnDeactivate
            //
            this.btnDeactivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeactivate.Location = new System.Drawing.Point(167, 367);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(139, 24);
            this.btnDeactivate.TabIndex = 7;
            this.btnDeactivate.Text = "Anfrage Deaktivieren";
            this.btnDeactivate.UseCompatibleTextRendering = true;
            this.btnDeactivate.UseVisualStyleBackColor = false;
            this.btnDeactivate.Click += new System.EventHandler(this.btnDeactivate_Click);
            //
            // colUser
            //
            this.colUser.Caption = "Angefordert von";
            this.colUser.FieldName = "User";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.ReadOnly = true;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 9;
            this.colUser.Width = 120;
            //
            // colNameVorname
            //
            this.colNameVorname.Caption = "Name, Vorname";
            this.colNameVorname.FieldName = "NameVorname";
            this.colNameVorname.Name = "colNameVorname";
            this.colNameVorname.OptionsColumn.ReadOnly = true;
            this.colNameVorname.Visible = true;
            this.colNameVorname.VisibleIndex = 1;
            this.colNameVorname.Width = 148;
            //
            // colJahrVon
            //
            this.colJahrVon.Caption = "Auszug von";
            this.colJahrVon.FieldName = "JahrVon";
            this.colJahrVon.Name = "colJahrVon";
            this.colJahrVon.OptionsColumn.ReadOnly = true;
            this.colJahrVon.Visible = true;
            this.colJahrVon.VisibleIndex = 10;
            //
            // colJahrBis
            //
            this.colJahrBis.Caption = "Auszug bis";
            this.colJahrBis.FieldName = "JahrBis";
            this.colJahrBis.Name = "colJahrBis";
            this.colJahrBis.OptionsColumn.ReadOnly = true;
            this.colJahrBis.Visible = true;
            this.colJahrBis.VisibleIndex = 11;
            //
            // colFaLeistungID
            //
            this.colFaLeistungID.Name = "colFaLeistungID";
            //
            // colVersichertennummer
            //
            this.colVersichertennummer.Caption = "Versicherten-Nr";
            this.colVersichertennummer.FieldName = "Versichertennummer";
            this.colVersichertennummer.Name = "colVersichertennummer";
            this.colVersichertennummer.OptionsColumn.ReadOnly = true;
            this.colVersichertennummer.Visible = true;
            this.colVersichertennummer.VisibleIndex = 7;
            this.colVersichertennummer.Width = 135;
            //
            // colAnforderungDatum
            //
            this.colAnforderungDatum.Caption = "Angefordert am";
            this.colAnforderungDatum.FieldName = "AnforderungDatum";
            this.colAnforderungDatum.Name = "colAnforderungDatum";
            this.colAnforderungDatum.OptionsColumn.ReadOnly = true;
            this.colAnforderungDatum.Visible = true;
            this.colAnforderungDatum.VisibleIndex = 8;
            this.colAnforderungDatum.Width = 98;
            //
            // colAHVNummer
            //
            this.colAHVNummer.Caption = "AHV-Nr";
            this.colAHVNummer.FieldName = "AHVNummer";
            this.colAHVNummer.Name = "colAHVNummer";
            this.colAHVNummer.Visible = true;
            this.colAHVNummer.VisibleIndex = 6;
            this.colAHVNummer.Width = 83;
            //
            // colZIPNr
            //
            this.colZIPNr.Caption = "PID";
            this.colZIPNr.FieldName = "ZIPNr";
            this.colZIPNr.Name = "colZIPNr";
            this.colZIPNr.OptionsColumn.ReadOnly = true;
            this.colZIPNr.Visible = true;
            this.colZIPNr.VisibleIndex = 4;
            this.colZIPNr.Width = 69;
            //
            // colUserName
            //
            this.colUserName.Name = "colUserName";
            //
            // colWhEkEntscheidID
            //
            this.colWhEkEntscheidID.Name = "colWhEkEntscheidID";
            //
            // colGeburtstag
            //
            this.colGeburtstag.Caption = "Geb.-Datum";
            this.colGeburtstag.FieldName = "Geburtsdatum";
            this.colGeburtstag.Name = "colGeburtstag";
            this.colGeburtstag.Visible = true;
            this.colGeburtstag.VisibleIndex = 5;
            this.colGeburtstag.Width = 86;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // btnRefresh
            //
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(510, 367);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(128, 24);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Status-Refresh";
            this.btnRefresh.UseCompatibleTextRendering = true;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // gridImportFehler
            //
            this.gridImportFehler.Caption = "Import-Fehlermeldung";
            this.gridImportFehler.FieldName = "ImportFehlermeldung";
            this.gridImportFehler.Name = "gridImportFehler";
            this.gridImportFehler.Visible = true;
            this.gridImportFehler.VisibleIndex = 14;
            this.gridImportFehler.Width = 150;
            //
            // kissLabel5
            //
            this.kissLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel5.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel5.Location = new System.Drawing.Point(8, 43);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(782, 19);
            this.kissLabel5.TabIndex = 349;
            this.kissLabel5.Text = "Liste der pendenten IK-Auszüge";
            this.kissLabel5.UseCompatibleTextRendering = true;
            //
            // btnImport
            //
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(644, 367);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(128, 24);
            this.btnImport.TabIndex = 17;
            this.btnImport.Text = "Import von SVA";
            this.btnImport.UseCompatibleTextRendering = true;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            //
            // colStatus
            //
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 0;
            //
            // colExportDatum
            //
            this.colExportDatum.Caption = "Export Datum";
            this.colExportDatum.FieldName = "ExportDatum";
            this.colExportDatum.Name = "colExportDatum";
            this.colExportDatum.Visible = true;
            this.colExportDatum.VisibleIndex = 12;
            this.colExportDatum.Width = 87;
            //
            // colBaPersonID
            //
            this.colBaPersonID.Caption = "Personen-Nr";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 3;
            //
            // colFaFallIDs
            //
            this.colFaFallIDs.Caption = "Fall-Nrn";
            this.colFaFallIDs.FieldName = "FaFallIDs";
            this.colFaFallIDs.Name = "colFaFallIDs";
            this.colFaFallIDs.Visible = true;
            this.colFaFallIDs.VisibleIndex = 2;
            //
            // colBemerkung
            //
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.FieldName = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 13;
            //
            // btnGeneratePDFs
            //
            this.btnGeneratePDFs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneratePDFs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePDFs.Location = new System.Drawing.Point(376, 367);
            this.btnGeneratePDFs.Name = "btnGeneratePDFs";
            this.btnGeneratePDFs.Size = new System.Drawing.Size(128, 24);
            this.btnGeneratePDFs.TabIndex = 18;
            this.btnGeneratePDFs.Text = "Generiere PDFs";
            this.btnGeneratePDFs.UseCompatibleTextRendering = true;
            this.btnGeneratePDFs.UseVisualStyleBackColor = false;
            this.btnGeneratePDFs.Click += new System.EventHandler(this.btnGeneratePDFs_Click);
            //
            // CtlSstIKAuszugImport
            //
            this.Controls.Add(this.kissLabel5);
            this.Name = "CtlSstIKAuszugImport";
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.kissLabel5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region EventHandlers

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion(string.Format("Sind Sie sicher, dass sie die IK-Anfrage für Person {0} deaktivieren möchten?\r\nDiese Anfrage wird dann nicht mehr in dieser Liste erscheinen.", qryQuery["NameVorname"])))
            {
                DBUtil.ExecSQLThrowingException(@"UPDATE SstIKAuszug SET
                                                    Deaktiviert = 1,
                                                    ImportFehlermeldung = 'Auszug wurde am ' + CONVERT(varchar, GetDate(), 104) + ' von ' + {1} + ' manuell deaktiviert.\r\n' + ISNULL('\r\n' + ImportFehlermeldung, '')
                                                  WHERE SstIKAuszugID = {0}",
                                                qryQuery["SstIKAuszugID$"], Session.User.LogonName);

                qryQuery.Refresh();
            }
        }

        private void btnGeneratePDFs_Click(object sender, EventArgs e)
        {
            try
            {
                // Starte den Hintergrund-Prozess im Server
                WorkerProcessHelper.IKAuszuegeGenerieren();
                btnGeneratePDFs.Enabled = false;    // Disable den Button, damit er nicht versehentlich zeimal gestartet wird.
                KissMsg.ShowInfo("Der Hintergrund-Prozess für die PDF-Generierung wurde angestossen. Bitte prüfen Sie den Verlauf mit 'Status-Refresh'");
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(string.Format("Fehler beim Anstossen des Hintergrund-Prozesses für die PDF-Erzeugung: {0}", ex.ToString()));
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // Let the user choose an import path
            _importPath = DBUtil.GetConfigString("System\\IKAuszuege\\ImportPfad", "P:\\FAMOZ_IK_Auszug_XML_Ablage\\Import");

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = _importPath;
            dlg.Description = "Selektieren Sie das Import-Verzeichis mit den IK-Auszügen (XML-Dateien) der SVA";

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _importPath = dlg.SelectedPath;

            DlgProgressLog.Show("IK-Auszüge importieren", 700, 500, new ProgressEventHandler(ProgressImportStart), new ProgressEventHandler(ProgressImportEnd), Session.MainForm);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            qryQuery.Refresh();
        }

        #endregion

        #region Methods

        #region Private Methods

        private void LogAddError(string text)
        {
            DlgProgressLog.AddError(text);
            importLogWriter.WriteLine("!!! " + text);
        }

        private void LogAddLine(string text)
        {
            DlgProgressLog.AddLine(text);
            importLogWriter.WriteLine(text);
        }

        private void ProgressImportEnd()
        {
            qryQuery.Refresh();
        }

        private void ProgressImportStart()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string importFehlerPfad = Path.Combine(_importPath, "ImportFehler");
                DirectoryInfo dirInfo = new DirectoryInfo(_importPath);
                FileInfo[] xmlFiles = dirInfo.GetFiles("*.xml");
                int importFehlerCount = 0;
                int successCount = 0;
                string logFile = "";
                int ikAuszugID = 0;
                List<FileInfo> filesToDelete = new List<FileInfo>();
                List<FileInfo> filesToCopy = new List<FileInfo>();

                // Erstelle (falls noch nicht vorhanden) das ImportFehler-Verzeichnis
                try
                {
                    if (!Directory.Exists(importFehlerPfad))
                    {
                        Directory.CreateDirectory(importFehlerPfad);
                    }
                }
                catch (Exception ex)
                {
                    DlgProgressLog.AddError(string.Format("Import-Abbruch: Verzeichnis {0} konnte nicht erstellt werden: {1}", importFehlerPfad, ex.ToString()));
                    return;
                }

                // Öffne das Import-Logfile (oder erstelle es, falls es noch nicht existiert)
                try
                {
                    logFile = Path.Combine(importFehlerPfad, "Import-Protokoll.txt");
                    importLogWriter = File.AppendText(logFile);
                    importLogWriter.WriteLine("===============================================================================");
                    importLogWriter.WriteLine("Import von IK-Auszügen gestartet am {0} von {1} ({2} {3})", DateTime.Now, Session.User.LogonName, Session.User.FirstName, Session.User.LastName);
                    importLogWriter.WriteLine("===============================================================================");
                }
                catch (Exception ex)
                {
                    DlgProgressLog.AddError(string.Format("Import-Abbruch: Import-Protokolldatei {0} konnte nicht erstellt resp. geöffnet werden: {1}", logFile, ex.ToString()));
                    return;
                }

                LogAddLine(string.Format("Importiere {0} XML-Dateien von {1}...", xmlFiles.Length, _importPath));
                LogAddLine("");

                // Iterate through all XML-Files found in the Import-Folder
                foreach (FileInfo file in xmlFiles)
                {
                    string messageID = "";
                    string importXML = "";
                    string importFehler = "";
                    bool noAccountFound;

                    try
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(file.FullName);
                        importXML = xmlDoc.InnerXml;

                        XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
                        namespaceManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                        namespaceManager.AddNamespace("igs-0001", "http://igs-gmbh.ch/xmlns/igs-0001/1");
                        namespaceManager.AddNamespace("igs-0002", "http://igs-gmbh.ch/xmlns/igs-0002/1");
                        namespaceManager.AddNamespace("eCH-0058", "http://www.ech.ch/xmlns/eCH-0058/2");

                        noAccountFound = false;

                        // Check if there is an error-Code in the file (= if there is a reportHeader Element)
                        XmlNode header = xmlDoc.SelectSingleNode("/igs-0002:message/igs-0002:reportHeader", namespaceManager);
                        if (header != null)
                        {
                            // reportHeader-Element found => There is an error in the report-Element
                            XmlNodeList reports = xmlDoc.SelectNodes("/igs-0002:message/igs-0002:report/igs-0001:negativeReport/igs-0001:generalError", namespaceManager);
                            foreach (XmlNode report in reports)
                            {
                                decimal? fehlercode = ReadXMLElementDecimal(report["igs-0001:code"]);

                                if (fehlercode != null)
                                {
                                    if (fehlercode == 4) // 4 = no Account found for Client
                                    {
                                        // this error code is accepted, we need to add a dummy entry later in the process for this case
                                        noAccountFound = true;
                                    }
                                    else
                                    {
                                        string fehler = fehlercode + ": " + ReadXMLElementString(report["igs-0001:description"]);
                                        LogAddError(string.Format("Datei '{0}' wird importiert, meldet aber folgenden fachlichen Fehler: {1}", file.Name, fehler));

                                        // Concatenate all import-Errors for this file together, so that we can store the string in the DB
                                        importFehler = importFehler == "" ? fehler : importFehler + "\r\n" + fehler;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // No reportHeader-Element found, so check for the normal header-Element
                            header = xmlDoc.SelectSingleNode("/igs-0002:message/igs-0002:header", namespaceManager);
                        }

                        if (header == null)
                        {
                            // Import-Problem: No header info found
                            LogAddError(string.Format("Fehler: Datei '{0}' kann nicht importiert werden: Kein reportHeader resp. header-Element gefunden", file.Name));
                            filesToCopy.Add(file);
                            continue; // Go to the next Import-File
                        }

                        // Read MessageID from header
                        messageID = ReadXMLElementString(21, header["igs-0001:referenceMessageId"]);

                        // Use the MessageID to look for the correspondig IKAuszugID in the list of exported IK-Auszüge
                        ikAuszugID = 0;
                        foreach (DataRow row in qryQuery.DataTable.Rows)
                        {
                            if (row["MessageID"].Equals(messageID))
                            {
                                // Found the export-Entry
                                ikAuszugID = (int)row["SstIKAuszugID"];
                                break;
                            }
                        }

                        if (ikAuszugID == 0)
                        {
                            // No export entry for this import-file found
                            LogAddError(string.Format("Datei '{0}' kann nicht importiert werden, da keine IK-Auszugs-Anfrage für die MessageID {1} gefunden wurde. Entweder wurde diese IK-Anfrage nicht aus KiSS gestellt oder wurde in KiSS wieder deaktiviert",
                                          file.Name, messageID));
                            filesToCopy.Add(file);
                            continue; // Go to the next Import-File
                        }

                        // Start DB-Transaction
                        Session.BeginTransaction();
                        try
                        {
                            // Ensure that if there where no import errors, that the importFehler field is null (not just empty string)
                            if (string.IsNullOrEmpty(importFehler))
                            {
                                importFehler = null;
                            }

                            // Store the imported header-Info
                            DBUtil.ExecSQLThrowingException(@"
                                UPDATE SstIKAuszug SET
                                    ImportDatum = GETDATE(),
                                    ImportXML = {1},
                                    ImportFehlermeldung = {2}
                                WHERE SstIKAuszugID = {0}", ikAuszugID, importXML, importFehler);

                            // Delete existing Auszug-Details in the DB, in case there are any (in case there was an earlier, unsuccessfull import)
                            DBUtil.ExecSQLThrowingException(@"
                                DELETE FROM SstIKAuszugDetail
                                WHERE SstIKAuszugID = {0}", ikAuszugID);

                            // Read the Accounts
                            XmlNodeList accounts = xmlDoc.SelectNodes("/igs-0002:message/igs-0002:searchIndividualAccountReponse/igs-0002:account", namespaceManager);

                            if (accounts.Count == 0 || noAccountFound)
                            {
                                // Create a Dummy Entry
                                DBUtil.ExecSQLThrowingException(@"
                                        INSERT INTO SstIKAuszugDetail
                                            (SstIKAuszugID, Versichertennummer, Kassennummer, Abrechnungsnummer, Einkommenscode, BruchteilBG, BeitragsmonatVon, BeitragsmonatBis, BeitragsJahr, Einkommen, Arbeitgeber, Einkommensart, Bezeichnung)
                                        VALUES
                                            ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12})",
                                    ikAuszugID,
                                    "0",
                                    "0",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    "",
                                    0,
                                    "",
                                    "",
                                    "Rückmeldung Ausgleichskassen: Kein individuelles Konto vorhanden");
                            }

                            foreach (XmlNode account in accounts)
                            {
                                string versichertenNr = ReadXMLElementString(16, account["igs-0002:personId"]);

                                XmlNodeList accountEntries = account.SelectNodes("igs-0002:accountData", namespaceManager);
                                foreach (XmlNode accountEntry in accountEntries)
                                {
                                    string kassenNr = ReadXMLElementString(7, accountEntry["igs-0002:compensationOffice"]);
                                    string abrechnungsNr = ReadXMLElementString(16, accountEntry["igs-0002:accountNumber"]);
                                    string einkommensCode = ReadXMLElementString(2, accountEntry["igs-0002:incomeCode"]);
                                    string bruchteilBG = ReadXMLElementString(2, accountEntry["igs-0002:fractionFL"]);
                                    string beitragsMonatBeginn = ReadXMLElementString(2, accountEntry["igs-0002:contributionMonthStart"]);
                                    string beitragsMonatEnde = ReadXMLElementString(2, accountEntry["igs-0002:contributionMonthEnd"]);
                                    string beitragsJahr = ReadXMLElementString(4, accountEntry["igs-0002:contributionYear"]);
                                    decimal? einkommen = ReadXMLElementDecimal(accountEntry["igs-0002:income"]);
                                    string arbeitgeber = ReadXMLElementString(100, accountEntry["igs-0002:employer"]);
                                    string einkommensart = ReadXMLElementString(50, accountEntry["igs-0002:incomeType"]);
                                    string bezeichnung = ReadXMLElementString(100, accountEntry["igs-0002:description"]);

                                    // Create the new Auszug-Details
                                    DBUtil.ExecSQLThrowingException(@"
                                        INSERT INTO SstIKAuszugDetail
                                            (SstIKAuszugID, Versichertennummer, Kassennummer, Abrechnungsnummer, Einkommenscode, BruchteilBG, BeitragsmonatVon, BeitragsmonatBis, BeitragsJahr, Einkommen, Arbeitgeber, Einkommensart, Bezeichnung)
                                        VALUES
                                            ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12})",
                                        ikAuszugID,
                                        versichertenNr,
                                        kassenNr,
                                        abrechnungsNr,
                                        einkommensCode,
                                        bruchteilBG,
                                        beitragsMonatBeginn,
                                        beitragsMonatEnde,
                                        beitragsJahr,
                                        einkommen,
                                        arbeitgeber,
                                        einkommensart,
                                        bezeichnung);
                                }
                            }

                            // Import erfolgreich verlaufen
                            Session.Commit();
                            LogAddLine(string.Format("Datei '{0}' wurde erfolgreich importiert", file.Name));
                            successCount++;
                            filesToDelete.Add(file);
                        }
                        catch (Exception ex2)
                        {
                            if (Session.Transaction != null)
                            {
                                Session.Rollback();
                            }
                            throw ex2;  // rethrow exception for propper handling further down
                        }
                    }
                    catch (Exception ex)
                    {
                        LogAddError(string.Format("Fehler: Datei '{0}' konnte nicht importiert werden: {1}", file.Name, ex.ToString()));
                        importFehlerCount++;

                        filesToCopy.Add(file);
                    }
                }

                LogAddLine("");
                LogAddLine(string.Format("Import abgeschlossen: {0} von total {1} Dateien wurden erfolgreich importiert", successCount, successCount + filesToCopy.Count));
                LogAddLine("");
                LogAddLine("Es werden nun die fehlerhaften Import-Dateien ins Importfehler-Verzeichnis kopiert und anschliessend alle Import-Dateien im Import-Verzeichnis gelöscht");

                // Copy the Import-Files with errors
                foreach (FileInfo file in filesToCopy)
                {
                    try
                    {
                        File.Copy(file.FullName, Path.Combine(importFehlerPfad, file.Name));

                        // Dann markiere die Datei zum löschen
                        filesToDelete.Add(file);
                    }
                    catch (Exception ex)
                    {
                        LogAddError(string.Format("Fehler: Datei '{0}' konnte nicht ins Verzeichnis {1} kopiert werden: {2}", file.Name, importFehlerPfad, ex.ToString()));
                    }
                }

                foreach (FileInfo file in filesToDelete)
                {
                    try
                    {
                        // Falls der Import erfolgreich verlaufen ist, resp. die fehlerhafte Datei erfolgreich ins ImportFehler-Verzeichnis kopiert wurde, kann die Source-Datei gelöscht werden
                        File.Delete(file.FullName);
                    }
                    catch (Exception ex)
                    {
                        LogAddError(string.Format("Fehler: Datei '{0}' konnte nicht gelöscht werden: {1}", file.FullName, ex.ToString()));
                    }
                }

                LogAddLine("");
                DlgProgressLog.AddLine(string.Format("Das vollständige Import-Protokoll inkl. allfälligen Fehlermeldungen finden Sie hier: {0}", logFile));
                if (importFehlerCount > 0)
                {
                    LogAddLine(string.Format("Die fehlerhaften Dateien wurden in folgendes Verzeichnis kopiert: {0}", importFehlerPfad));
                }

                LogAddLine("");
                LogAddLine("Sie können nun die PDF-Generierung starten mit dem Knopf 'Generiere PDFs'");
                LogAddLine("");
                LogAddLine("");
            }
            finally
            {
                Cursor.Current = Cursors.Default;

                if (importLogWriter != null)
                {
                    importLogWriter.Close();
                    importLogWriter = null;
                }

                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        private decimal? ReadXMLElementDecimal(XmlElement element)
        {
            if (element == null)
            {
                return null;
            }

            return decimal.Parse(element.InnerText);
        }

        private string ReadXMLElementString(XmlElement element)
        {
            if (element == null)
            {
                return "";
            }

            return element.InnerText;
        }

        private string ReadXMLElementString(int size, XmlElement element)
        {
            if (element == null)
            {
                return "";
            }

            string text = element.InnerText;

            if (text.Length > size)
            {
                return text.Substring(0, size);
            }

            return text;
        }

        private string ReadXMLElementString(int pos, int size, XmlElement element)
        {
            if (element == null)
            {
                return "";
            }

            string text = element.InnerText;

            if (text.Length > pos + size)
            {
                return text.Substring(pos, size);
            }
            else if (text.Length > pos)
            {
                return text.Substring(pos, text.Length - pos);
            }

            return "";
        }

        #endregion

        #endregion
    }
}