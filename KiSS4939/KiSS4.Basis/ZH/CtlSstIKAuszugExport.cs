using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;

using Kiss.BusinessLogic.Ba;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Basis.ZH
{
    public class CtlSstIKAuszugExport : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        private int _anzahlFehlendeVersNr = 0;
        private string _exportPassword;
        private string _exportPath;
        private KiSS4.Gui.KissButton btnDeactivate;
        private KissButton btnExport;
        private KissButton btnOmegaCheck;
        private KissButton btnSaveVersichertennummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAnforderungDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colFallIDs;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtstag;
        private DevExpress.XtraGrid.Columns.GridColumn colImportFehler;
        private DevExpress.XtraGrid.Columns.GridColumn colJahrBis;
        private DevExpress.XtraGrid.Columns.GridColumn colJahrVon;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthSinceLastIKAuszug;
        private DevExpress.XtraGrid.Columns.GridColumn colNameVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colPID;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colVersichertennummer;
        private DevExpress.XtraGrid.Columns.GridColumn colWhEkEntscheidID;
        private KissVersichertenNrEdit edtVersichertennummer;
        private KissLabel kissLabel5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;

        #endregion

        #endregion

        #region Constructors

        public CtlSstIKAuszugExport()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlSstIKAuszugExport));
            this.btnDeactivate = new KiSS4.Gui.KissButton();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahrVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahrBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaLeistungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersichertennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnforderungDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWhEkEntscheidID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtstag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.edtVersichertennummer = new KiSS4.Gui.KissVersichertenNrEdit();
            this.btnSaveVersichertennummer = new KiSS4.Gui.KissButton();
            this.btnOmegaCheck = new KiSS4.Gui.KissButton();
            this.colImportFehler = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.btnExport = new KiSS4.Gui.KissButton();
            this.colMonthSinceLastIKAuszug = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallIDs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.BatchUpdate = true;
            this.qryQuery.CanUpdate = true;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            this.colNameVorname,
            this.colFallIDs,
            this.colBaPersonID,
            this.colPID,
            this.colGeburtstag,
            this.colAHVNummer,
            this.colVersichertennummer,
            this.colAnforderungDatum,
            this.colUser,
            this.colJahrVon,
            this.colJahrBis,
            this.colBemerkung,
            this.colMonthSinceLastIKAuszug,
            this.colImportFehler});
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
            this.grdQuery1.Size = new System.Drawing.Size(766, 330);
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(740, -49);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
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
            this.tpgListe.Controls.Add(this.btnExport);
            this.tpgListe.Controls.Add(this.btnOmegaCheck);
            this.tpgListe.Controls.Add(this.btnSaveVersichertennummer);
            this.tpgListe.Controls.Add(this.edtVersichertennummer);
            this.tpgListe.Controls.Add(this.btnDeactivate);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(772, 394);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnDeactivate, 0);
            this.tpgListe.Controls.SetChildIndex(this.edtVersichertennummer, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnSaveVersichertennummer, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnOmegaCheck, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnExport, 0);
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
            this.btnDeactivate.Location = new System.Drawing.Point(3, 337);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(156, 24);
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
            this.colUser.VisibleIndex = 8;
            this.colUser.Width = 120;
            //
            // colNameVorname
            //
            this.colNameVorname.Caption = "Name, Vorname";
            this.colNameVorname.FieldName = "NameVorname";
            this.colNameVorname.Name = "colNameVorname";
            this.colNameVorname.OptionsColumn.ReadOnly = true;
            this.colNameVorname.Visible = true;
            this.colNameVorname.VisibleIndex = 0;
            //
            // colJahrVon
            //
            this.colJahrVon.Caption = "Auszug von";
            this.colJahrVon.FieldName = "JahrVon";
            this.colJahrVon.Name = "colJahrVon";
            this.colJahrVon.OptionsColumn.ReadOnly = true;
            this.colJahrVon.Visible = true;
            this.colJahrVon.VisibleIndex = 9;
            //
            // colJahrBis
            //
            this.colJahrBis.Caption = "Auszug bis";
            this.colJahrBis.FieldName = "JahrBis";
            this.colJahrBis.Name = "colJahrBis";
            this.colJahrBis.OptionsColumn.ReadOnly = true;
            this.colJahrBis.Visible = true;
            this.colJahrBis.VisibleIndex = 10;
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
            this.colVersichertennummer.VisibleIndex = 6;
            this.colVersichertennummer.Width = 135;
            //
            // colAnforderungDatum
            //
            this.colAnforderungDatum.Caption = "Angefordert am";
            this.colAnforderungDatum.FieldName = "AnforderungDatum";
            this.colAnforderungDatum.Name = "colAnforderungDatum";
            this.colAnforderungDatum.OptionsColumn.ReadOnly = true;
            this.colAnforderungDatum.Visible = true;
            this.colAnforderungDatum.VisibleIndex = 7;
            this.colAnforderungDatum.Width = 98;
            //
            // colAHVNummer
            //
            this.colAHVNummer.Caption = "AHV-Nr";
            this.colAHVNummer.FieldName = "AHVNummer";
            this.colAHVNummer.Name = "colAHVNummer";
            this.colAHVNummer.Visible = true;
            this.colAHVNummer.VisibleIndex = 5;
            this.colAHVNummer.Width = 130;
            //
            // colPID
            //
            this.colPID.Caption = "PID";
            this.colPID.FieldName = "EinwohnerregisterIDOhne0er";
            this.colPID.Name = "colPID";
            this.colPID.OptionsColumn.ReadOnly = true;
            this.colPID.Visible = true;
            this.colPID.VisibleIndex = 3;
            this.colPID.Width = 69;
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
            this.colGeburtstag.VisibleIndex = 4;
            this.colGeburtstag.Width = 86;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // edtVersichertennummer
            //
            this.edtVersichertennummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtVersichertennummer.Location = new System.Drawing.Point(232, 367);
            this.edtVersichertennummer.Name = "edtVersichertennummer";
            this.edtVersichertennummer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVersichertennummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersichertennummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertennummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertennummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertennummer.Properties.Appearance.Options.UseTextOptions = true;
            this.edtVersichertennummer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtVersichertennummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertennummer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersichertennummer.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtVersichertennummer.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummer.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummer.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummer.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtVersichertennummer.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtVersichertennummer.Properties.MaxLength = 18;
            this.edtVersichertennummer.Properties.Name = "dtpVersichertennummer.Properties";
            this.edtVersichertennummer.Properties.Precision = 0;
            this.edtVersichertennummer.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtVersichertennummer.Size = new System.Drawing.Size(152, 24);
            this.edtVersichertennummer.TabIndex = 14;
            //
            // btnSaveVersichertennummer
            //
            this.btnSaveVersichertennummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveVersichertennummer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveVersichertennummer.Location = new System.Drawing.Point(390, 367);
            this.btnSaveVersichertennummer.Name = "btnSaveVersichertennummer";
            this.btnSaveVersichertennummer.Size = new System.Drawing.Size(165, 24);
            this.btnSaveVersichertennummer.TabIndex = 15;
            this.btnSaveVersichertennummer.Text = "Versicherten-Nr speichern";
            this.btnSaveVersichertennummer.UseCompatibleTextRendering = true;
            this.btnSaveVersichertennummer.UseVisualStyleBackColor = false;
            this.btnSaveVersichertennummer.Click += new System.EventHandler(this.btnSaveVersichertennummer_Click);
            //
            // btnOmegaCheck
            //
            this.btnOmegaCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOmegaCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOmegaCheck.Location = new System.Drawing.Point(232, 337);
            this.btnOmegaCheck.Name = "btnOmegaCheck";
            this.btnOmegaCheck.Size = new System.Drawing.Size(323, 24);
            this.btnOmegaCheck.TabIndex = 16;
            this.btnOmegaCheck.Text = "Hole alle fehlenden Versicherten-Nr von Omega";
            this.btnOmegaCheck.UseCompatibleTextRendering = true;
            this.btnOmegaCheck.UseVisualStyleBackColor = false;
            this.btnOmegaCheck.Click += new System.EventHandler(this.btnOmegaCheck_Click);
            //
            // colImportFehler
            //
            this.colImportFehler.Caption = "Import-Fehlermeldung";
            this.colImportFehler.FieldName = "ImportFehlermeldung";
            this.colImportFehler.Name = "colImportFehler";
            this.colImportFehler.Visible = true;
            this.colImportFehler.VisibleIndex = 13;
            this.colImportFehler.Width = 150;
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
            this.kissLabel5.Text = "Liste aller automatisch oder manuell angeforderten IK-Auszüge";
            this.kissLabel5.UseCompatibleTextRendering = true;
            //
            // btnExport
            //
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Location = new System.Drawing.Point(644, 367);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(128, 24);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Export zur SVA";
            this.btnExport.UseCompatibleTextRendering = true;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            //
            // colMonthSinceLastIKAuszug
            //
            this.colMonthSinceLastIKAuszug.Caption = "Datum letzter Auszug";
            this.colMonthSinceLastIKAuszug.FieldName = "DatumLetzterIKAuszug";
            this.colMonthSinceLastIKAuszug.Name = "colMonthSinceLastIKAuszug";
            this.colMonthSinceLastIKAuszug.ToolTip = "Datum vom letzten IK-Auszug";
            this.colMonthSinceLastIKAuszug.Visible = true;
            this.colMonthSinceLastIKAuszug.VisibleIndex = 12;
            //
            // colBaPersonID
            //
            this.colBaPersonID.Caption = "Personen-Nr";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 2;
            //
            // colFallIDs
            //
            this.colFallIDs.Caption = "Fall-Nrn";
            this.colFallIDs.FieldName = "FaFallIDs";
            this.colFallIDs.Name = "colFallIDs";
            this.colFallIDs.Visible = true;
            this.colFallIDs.VisibleIndex = 1;
            //
            // colBemerkung
            //
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.FieldName = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 11;
            //
            // CtlSstIKAuszugExport
            //
            this.Controls.Add(this.kissLabel5);
            this.Name = "CtlSstIKAuszugExport";
            this.Load += new System.EventHandler(this.CtlSstIKAuszugExport_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummer.Properties)).EndInit();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Sicherstellen, dass die aktuellen Daten gesichert sind
            qryQuery.EndCurrentEdit();

            // Let the user choose an export path
            _exportPath = DBUtil.GetConfigString("System\\IKAuszuege\\ExportPfad", "P:\\FAMOZ_IK_Auszug_XML_Ablage\\Export");

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = _exportPath;
            dlg.Description = "Selektieren Sie das Export-Verzeichis für die XML-Dateien für die IKAuszüge";

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _exportPath = dlg.SelectedPath;

            bool exportZIPPasswortErforderlich = DBUtil.GetConfigBool("System\\IKAuszuege\\ExportZIPPasswortErforderlich", true);
            _exportPassword = "";
            if (exportZIPPasswortErforderlich)
            {
                // Passwort verlangen
                DlgPasswort dlgPasswort = new DlgPasswort("IK-Auszug Export: Passwort für ZIP-File", "Bitte geben Sie das Passwort für das ZIP-File ein:");
                if (dlgPasswort.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                _exportPassword = dlgPasswort.Password;
            }

            DlgProgressLog.Show("IK-Auszüge exportieren", 700, 500, new ProgressEventHandler(ProgressExportStart), new ProgressEventHandler(ProgressExportEnd), Session.MainForm);
        }

        private void btnOmegaCheck_Click(object sender, EventArgs e)
        {
            _anzahlFehlendeVersNr = 0;
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                if (DBUtil.IsEmpty(row["Versichertennummer"]))
                {
                    _anzahlFehlendeVersNr++;
                }
            }

            if (_anzahlFehlendeVersNr == 0)
            {
                KissMsg.ShowInfo("Alle Personen der angeforderten IK-Auszüge haben eine Versichertennummer.");
                return;
            }

            if (!KissMsg.ShowQuestion(string.Format("Sollen die fehlenden {0} Versichertennummern aus Omega importiert werden (falls vorhanden)?", _anzahlFehlendeVersNr)))
            {
                return;
            }

            DlgProgressLog.Show("Fehlende Versichertennummern aus Omega importieren", 700, 500, ProgressImportOmegaStart, ProgressImportOmegaEnd, Session.MainForm);
        }

        private void btnSaveVersichertennummer_Click(object sender, EventArgs e)
        {
            if (edtVersichertennummer.ValidateVersNr(true, true))
            {
                // First check if this Versichertennummer is not already used by another person
                string personWithSameNr = DBUtil.ExecuteScalarSQLThrowingException("SELECT TOP 1 DisplayText FROM vwPerson WHERE Versichertennummer = {0}", edtVersichertennummer.EditValue) as string;

                if (personWithSameNr != null)
                {
                    KissMsg.ShowError(string.Format("Die Versichertennummer {0} verweist bereits auf die Person {1}.\r\nBitte kontrollieren Sie die Versichertennummer auf Eindeutigkeit.", edtVersichertennummer.EditValue, personWithSameNr));
                    return;
                }

                // OK, now save the number in the DB
                DBUtil.ExecSQLThrowingException("UPDATE BaPerson SET Versichertennummer = {0}, Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {2}",
                                                        edtVersichertennummer.EditValue,
                                                        DBUtil.GetDBRowCreatorModifier(),
                                                        qryQuery["BaPersonID"]);

                // And also set it in the Query
                qryQuery["Versichertennummer"] = edtVersichertennummer.EditValue;
            }
        }

        private void CtlSstIKAuszugExport_Load(object sender, EventArgs e)
        {
            try
            {
                // Deaktiviere diejenigen IK-Auszug-Anfragen (nur Genemigung Finanzplan),
                // bei denen der Finanzplan nicht mehr genemigt ist
                // resp. die W-Leistung nicht mehr aktiv ist
                DBUtil.ExecSQLThrowingException(@"
                    UPDATE IKA SET
                        Deaktiviert = 1,
                        ImportFehlermeldung = 'Auszug wurde am ' + CONVERT(varchar, GetDate(), 102) + ' automatisch deaktiviert, da der erste Finanzplan nicht mehr genemigt resp. die W-Leistung nicht mehr aktiv ist\r\n' + ISNULL('\r\n' + IKA.ImportFehlermeldung, '')
                    FROM SstIKAuszug IKA
                    WHERE IKA.SstIKAuszugID IN
                    (
                        SELECT DISTINCT IKA.SstIKAuszugID
                        FROM vwSstIKAuszug IKA
                        WHERE IKA.SstIKAuszugStatusCode = 1							-- IK-Auszug ist erst angefordert
                            AND SstIkAuszugAnforderungCode = 1						-- IK-Auszug bei Genemigung Finanzplan
                    EXCEPT
                        SELECT DISTINCT IKA.SstIKAuszugID
                        FROM vwSstIKAuszug IKA
                            INNER JOIN BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BaPersonID = IKA.BaPersonID
                            INNER JOIN BgFinanzplan FIP WITH (READUNCOMMITTED) ON FIP.BgFinanzplanID = FPP.BgFinanzplanID
                            INNER JOIN FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FIP.FaLeistungID
                            INNER JOIN BgBewilligung BEW WITH (READUNCOMMITTED) ON BEW.BgFinanzplanID = FPP.BgFinanzplanID
                        WHERE IKA.SstIKAuszugStatusCode = 1							-- IK-Auszug ist erst angefordert
                            AND IKA.SstIkAuszugAnforderungCode = 1					-- IK-Auszug bei Genemigung Finanzplan
                            AND LEI.FaProzessCode = 300 AND LEI.DatumBis IS NULL	-- Aktive W-Leistung ist immer noch vorhanden
                            AND FIP.BgBewilligungStatusCode = 5						-- Bewilligter Finanzplan ist immer noch vorhanden
                    )");
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("Fehler beim Überprüfen der IK-Auszugs-Anforderungen auf aktive W-Leistung und genemigte Finanzpläne.", ex);
            }
        }

        private void qryQuery_PositionChanged(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryQuery["Versichertennummer"]))
            {
                edtVersichertennummer.EditMode = EditModeType.Normal;
                btnSaveVersichertennummer.Enabled = true;
            }
            else
            {
                edtVersichertennummer.EditMode = EditModeType.ReadOnly;
                btnSaveVersichertennummer.Enabled = false;
            }

            edtVersichertennummer.EditValue = qryQuery["Versichertennummer"];
        }

        #endregion

        #region Methods

        #region Private Methods

        private void ProgressExportEnd()
        {
            qryQuery.Refresh();
        }

        private void ProgressExportStart()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int rowsToExport = 0;

                foreach (DataRow row in qryQuery.DataTable.Rows)
                {
                    if (DBUtil.IsEmpty(row["Versichertennummer"]))
                    {
                        continue;
                    }

                    rowsToExport++;
                }

                if (qryQuery.DataTable.Rows.Count > rowsToExport)
                {
                    DlgProgressLog.AddLine(string.Format("{0} Auszüge können nicht exportiert werden, da keine Versichertennummer bekannt ist.", qryQuery.DataTable.Rows.Count - rowsToExport));
                }

                DlgProgressLog.AddLine(string.Format("Es werden {0} Auszüge exportiert", rowsToExport));

                // Generiere die XML-Daten
                try
                {
                    DBUtil.ExecSQLThrowingException("EXEC spSstIKAuszugExportXML");
                }
                catch (Exception ex)
                {
                    DlgProgressLog.AddError(string.Format("Export abgebrochen: Fehler beim Generieren der XML-Daten: {0}", ex.Message));
                    return;
                }

                // Hole alle IK-Auszugsanforderungen, für die das XML nun generiert (aber noch nicht exporiert) wurden
                SqlQuery qry = DBUtil.OpenSQL(@"
                        SELECT DISTINCT
                            IKA.SstIkAuszugID,
                            PER.DisplayText,
                            IKA.Versichertennummer,
                            IKA.ExportXML
                        FROM vwSstIkAuszug IKA
                        INNER JOIN vwPerson PER WITH (READUNCOMMITTED) ON PER.BaPersonID = IKA.BaPersonID
                        WHERE IKA.SstIkAuszugStatusCode IN (1, 4) AND IKA.ExportXML IS NOT NULL");  // StatusCode 1 und 4 (Angefordert und Importiert mit Fehler)

                DlgProgressLog.AddLine(string.Format("nach {0} ...", _exportPath));
                List<string> tempFiles = new List<string>();

                // Erstelle temporärer Export-Pfad
                string tempExportPath = "";
                try
                {
                    tempExportPath = _exportPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                    Directory.CreateDirectory(tempExportPath);
                }
                catch (Exception ex)
                {
                    DlgProgressLog.AddError(string.Format("Export abgebrochen: Fehler beim Erstellen des temporären Export-Verzeichnisses {0}: {1}", tempExportPath, ex.Message));
                    return;
                }

                Session.BeginTransaction();
                try
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        if (!string.IsNullOrEmpty(_exportPassword))
                        {
                            zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                            zip.Password = _exportPassword;
                        }

                        string zipFileName = Path.Combine(_exportPath, "Anfrage_IK_Auszuege_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".zip");

                        int count = 0;
                        foreach (DataRow row in qry.DataTable.Rows)
                        {
                            string personName = "";
                            try
                            {
                                personName = (string)row["DisplayText"];
                                count++;

                                // Erstelle temporärer Filename
                                string fileName = "FZH1_" + count.ToString("00000") + ".xml";
                                DlgProgressLog.AddLine(string.Format("{0}/{1}: {2}: Export läuft ...", count, rowsToExport, personName, fileName));

                                string filePath = Path.Combine(tempExportPath, fileName);

                                // Erstelle das File und exportiere das XML
                                StreamWriter writer = File.CreateText(filePath);
                                writer.Write(row["ExportXML"]);
                                writer.Close();

                                // XML-File ins ZIP-File zufügen
                                zip.AddFile(filePath, "\\");

                                // Temporäres File wieder zum löschen markieren
                                tempFiles.Add(filePath);

                                // Setze das Export-Datum => Damit wechselt der Status dieses IK-Auszugs auf "Exporiert"
                                DBUtil.ExecSQLThrowingException("UPDATE SstIkAuszug SET ExportDatum = GetDate() WHERE SstIkAuszugID = {0}", row["SstIkAuszugID"]);
                            }
                            catch (Exception ex)
                            {
                                DlgProgressLog.AddError(string.Format("{0}: Fehler beim Export: {1}", personName, ex.Message));
                            }
                        }

                        DlgProgressLog.AddLine("ZIP-File wird nun erstellt, das kann einige Sekunden gehen...");
                        zip.Save(zipFileName);

                        // Löschen der temporären Dateien

                        foreach (string fn in tempFiles)
                        {
                            try
                            {
                                File.Delete(fn);
                            }
                            catch (Exception)
                            {
                                // Ignorieren
                            }
                        }

                        // Löschen des temporären Export-Verzeichnisses
                        try
                        {
                            Directory.Delete(tempExportPath);
                        }
                        catch (Exception)
                        {
                            // Ignorieren
                        }

                        DlgProgressLog.AddLine("Export wurde erledigt, das Passwort-geschützte ZIP-File liegt hier:");
                        DlgProgressLog.AddLine(zipFileName);
                    }

                    Session.Commit();

                    // Starte den Explorer im Export-Verzeichnis
                    try
                    {
                        Process.Start("explorer", _exportPath);
                    }
                    catch (Exception)
                    {
                        // Ignoriere Fehler, es ist nicht so wichtig, dass dies auf jeden Fall funktioniert, und eine Fehlermeldung würde mehr verwirren als helfen
                    }
                }
                catch (Exception ex2)
                {
                    DlgProgressLog.AddError(string.Format("Fehler beim Export, der Export wurde rückgängig gemacht, die bereits erstellten Dateien bitte nicht verwenden: {0}", ex2.Message));

                    if (Session.Transaction != null)
                    {
                        Session.Rollback();
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        private void ProgressImportOmegaEnd()
        {
        }

        private void ProgressImportOmegaStart()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var count = 0;
                foreach (DataRow row in qryQuery.DataTable.Rows)
                {
                    if (!DBUtil.IsEmpty(row["Versichertennummer"]))
                    {
                        continue;
                    }

                    if (DBUtil.IsEmpty(row["EinwohnerregisterID"]))
                    {
                        // Ohne PID können wir Omega nicht ansprechen
                        DlgProgressLog.AddError(string.Format("{0} hat keine PID, daher ist eine Abfrage via Omega leider nicht möglich.", row["NameVorname"]));
                        continue;
                    }

                    count++;
                    DlgProgressLog.AddLine(string.Format("{0}/{1}: {2}:", count, _anzahlFehlendeVersNr, row["NameVorname"]));

                    var pid = row["EinwohnerregisterID"].ToString();

                    try
                    {
                        var einwohnerregisterService = Kiss.Infrastructure.IoC.Container.Resolve<BaEinwohnerregisterService>();

                        var result = einwohnerregisterService.GetPersonDetails(pid);

                        if (!result.IsOk)
                        {
                            DlgProgressLog.AddError(result.GetTechnicalDetails());
                            continue;
                        }

                        var person = result.Result;

                        if (person != null)
                        {
                            try
                            {
                                if (person.Versichertennummer == null)
                                {
                                    DlgProgressLog.UpdateLastLine(string.Format("{0}: Die Versichertennummer ist im Omega nicht definiert für diese Person", row["NameVorname"]));
                                }
                                else if (!row["Versichertennummer"].Equals(person.Versichertennummer))
                                {
                                    DlgProgressLog.UpdateLastLine(string.Format("{0}: Die Versichertennummer hat geändert: {1}", row["NameVorname"], person.Versichertennummer));

                                    row["Versichertennummer"] = person.Versichertennummer;

                                    DBUtil.ExecSQLThrowingException("UPDATE dbo.BaPerson SET Versichertennummer = {0}, Modifier = {1}, Modified = GetDate() WHERE BaPersonID = {2}",
                                                                    person.Versichertennummer,
                                                                    DBUtil.GetDBRowCreatorModifier(),
                                                                    row["BaPersonID"]);
                                }
                                else
                                {
                                    DlgProgressLog.UpdateLastLine(string.Format("{0}: Es wurden keine neueren Daten im Omega gefunden.", row["NameVorname"]));
                                }
                            }
                            catch (KissCancelException ex)
                            {
                                DlgProgressLog.AddError(string.Format("Genereller Fehler beim Import: {0}", ex.Message));
                            }
                        }
                    }
                    catch (KissCancelException)
                    {
                        DlgProgressLog.AddError(string.Format("Es konnte keine Person mit der PID {0} im Omega gefunden werden", pid));
                    }
                    catch (Exception ex)
                    {
                        DlgProgressLog.AddError(string.Format("Genereller Fehler beim Import: {0}", ex.Message));
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        #endregion

        #endregion
    }
}