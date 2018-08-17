using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Basis
{
    partial class CtlPersonenStamm
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlPersonenStamm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdBaPerson = new KiSS4.Gui.KissGrid();
            this.qryBaPerson = new KiSS4.DB.SqlQuery();
            this.grvBaPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitaet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissCalcEdit();
            this.edtGeburtVon = new KiSS4.Gui.KissDateEdit();
            this.edtGeburtBis = new KiSS4.Gui.KissDateEdit();
            this.edtNationalitaet = new KiSS4.Gui.KissLookUpEdit();
            this.edtAHVNummer = new KiSS4.Gui.KissTextEdit();
            this.edtFT = new KiSS4.Gui.KissCheckEdit();
            this.kissLabel80 = new KiSS4.Gui.KissLabel();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.lblSucheNationalitaet = new KiSS4.Gui.KissLabel();
            this.lblSucheAHVNummer = new KiSS4.Gui.KissLabel();
            this.lblSucheGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblSuchePlzOrt = new KiSS4.Gui.KissLabel();
            this.lblSucheStrasse = new KiSS4.Gui.KissLabel();
            this.lblSucheBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.btnFallInfo = new KiSS4.Gui.KissButton();
            this.lblAnzahlDatensaetze = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.pnlDemographie = new System.Windows.Forms.Panel();
            this.ctlBaPerson = new KiSS4.Basis.CtlBaPerson();
            this.lblVersNr = new KiSS4.Gui.KissLabel();
            this.edtVersNr = new KiSS4.Gui.KissTextEdit();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.splPersonenstamm = new KiSS4.Gui.KissSplitterCollapsible();
            this.edtSucheKeinSerienbrief = new KiSS4.Gui.KissCheckEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel80)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAHVNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePlzOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            this.pnlDemographie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKeinSerienbrief.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(980, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Margin = new System.Windows.Forms.Padding(6);
            this.tabControlSearch.Padding = new System.Windows.Forms.Padding(6);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(1004, 224);
            this.tabControlSearch.SizeChanged += new System.EventHandler(this.tabControlSearch_SizeChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdBaPerson);
            this.tpgListe.Size = new System.Drawing.Size(992, 186);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtSucheKeinSerienbrief);
            this.tpgSuchen.Controls.Add(this.lblVersNr);
            this.tpgSuchen.Controls.Add(this.edtVersNr);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheBaPersonID);
            this.tpgSuchen.Controls.Add(this.lblSucheStrasse);
            this.tpgSuchen.Controls.Add(this.lblSuchePlzOrt);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtsdatum);
            this.tpgSuchen.Controls.Add(this.lblSucheAHVNummer);
            this.tpgSuchen.Controls.Add(this.lblSucheNationalitaet);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.kissLabel80);
            this.tpgSuchen.Controls.Add(this.edtFT);
            this.tpgSuchen.Controls.Add(this.edtAHVNummer);
            this.tpgSuchen.Controls.Add(this.edtNationalitaet);
            this.tpgSuchen.Controls.Add(this.edtGeburtBis);
            this.tpgSuchen.Controls.Add(this.edtGeburtVon);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtOrt);
            this.tpgSuchen.Controls.Add(this.edtPLZ);
            this.tpgSuchen.Controls.Add(this.edtStrasse);
            this.tpgSuchen.Controls.Add(this.edtVorname);
            this.tpgSuchen.Controls.Add(this.edtName);
            this.tpgSuchen.Size = new System.Drawing.Size(992, 186);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPLZ, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNationalitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAHVNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFT, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel80, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheNationalitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAHVNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburtsdatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchePlzOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKeinSerienbrief, 0);
            // 
            // grdBaPerson
            // 
            this.grdBaPerson.DataSource = this.qryBaPerson;
            this.grdBaPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBaPerson.EmbeddedNavigator.Name = "";
            this.grdBaPerson.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaPerson.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdBaPerson.Location = new System.Drawing.Point(0, 0);
            this.grdBaPerson.MainView = this.grvBaPerson;
            this.grdBaPerson.Name = "grdBaPerson";
            this.grdBaPerson.Size = new System.Drawing.Size(992, 186);
            this.grdBaPerson.TabIndex = 4;
            this.grdBaPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBaPerson});
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.CanDelete = true;
            this.qryBaPerson.CanUpdate = true;
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.SelectStatement = resources.GetString("qryBaPerson.SelectStatement");
            this.qryBaPerson.TableName = "BaPerson";
            this.qryBaPerson.AfterDelete += new System.EventHandler(this.qryBaPerson_AfterDelete);
            this.qryBaPerson.AfterFill += new System.EventHandler(this.qryBaPerson_AfterFill);
            this.qryBaPerson.BeforeDelete += new System.EventHandler(this.qryBaPerson_BeforeDelete);
            this.qryBaPerson.BeforeDeleteQuestion += new System.EventHandler(this.qryBaPerson_BeforeDeleteQuestion);
            this.qryBaPerson.PositionChanged += new System.EventHandler(this.qryBaPerson_PositionChanged);
            this.qryBaPerson.PositionChanging += new System.EventHandler(this.qryBaPerson_PositionChanging);
            // 
            // grvBaPerson
            // 
            this.grvBaPerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaPerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.Empty.Options.UseFont = true;
            this.grvBaPerson.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBaPerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaPerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaPerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaPerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaPerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaPerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaPerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaPerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaPerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaPerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaPerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaPerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBaPerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaPerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaPerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaPerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaPerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaPerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvBaPerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.OddRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.OddRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaPerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.Row.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.Row.Options.UseFont = true;
            this.grvBaPerson.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvBaPerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaPerson.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBaPerson.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBaPerson.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaPerson.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBaPerson.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaPerson.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaPerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaPerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFT,
            this.colNr,
            this.colName,
            this.colVorname,
            this.colStrasse,
            this.colOrt,
            this.colGeschlecht,
            this.colAlter,
            this.colGeburtsdatum,
            this.colNationalitaet,
            this.colAHVNr,
            this.colVersNr});
            this.grvBaPerson.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaPerson.GridControl = this.grdBaPerson;
            this.grvBaPerson.Name = "grvBaPerson";
            this.grvBaPerson.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvBaPerson.OptionsBehavior.Editable = false;
            this.grvBaPerson.OptionsCustomization.AllowFilter = false;
            this.grvBaPerson.OptionsCustomization.AllowGroup = false;
            this.grvBaPerson.OptionsFilter.AllowFilterEditor = false;
            this.grvBaPerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaPerson.OptionsMenu.EnableColumnMenu = false;
            this.grvBaPerson.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaPerson.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvBaPerson.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvBaPerson.OptionsNavigation.UseTabKey = false;
            this.grvBaPerson.OptionsPrint.AutoWidth = false;
            this.grvBaPerson.OptionsPrint.UsePrintStyles = true;
            this.grvBaPerson.OptionsView.ColumnAutoWidth = false;
            this.grvBaPerson.OptionsView.ShowDetailButtons = false;
            this.grvBaPerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaPerson.OptionsView.ShowGroupPanel = false;
            this.grvBaPerson.OptionsView.ShowIndicator = false;
            // 
            // colFT
            // 
            this.colFT.Caption = "FT";
            this.colFT.FieldName = "FT";
            this.colFT.Name = "colFT";
            this.colFT.Visible = true;
            this.colFT.VisibleIndex = 0;
            this.colFT.Width = 26;
            // 
            // colNr
            // 
            this.colNr.AppearanceCell.Options.UseTextOptions = true;
            this.colNr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colNr.Caption = "Nr";
            this.colNr.FieldName = "BaPersonID";
            this.colNr.Name = "colNr";
            this.colNr.Visible = true;
            this.colNr.VisibleIndex = 1;
            this.colNr.Width = 63;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 131;
            // 
            // colVorname
            // 
            this.colVorname.Caption = "Vorname";
            this.colVorname.FieldName = "Vorname";
            this.colVorname.Name = "colVorname";
            this.colVorname.Visible = true;
            this.colVorname.VisibleIndex = 3;
            this.colVorname.Width = 90;
            // 
            // colStrasse
            // 
            this.colStrasse.Caption = "Strasse";
            this.colStrasse.FieldName = "WohnsitzStrasseHausNr";
            this.colStrasse.Name = "colStrasse";
            this.colStrasse.Visible = true;
            this.colStrasse.VisibleIndex = 4;
            this.colStrasse.Width = 146;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "WohnsitzPLZOrt";
            this.colOrt.Name = "colOrt";
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 5;
            this.colOrt.Width = 132;
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.AppearanceCell.Options.UseTextOptions = true;
            this.colGeschlecht.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGeschlecht.Caption = "m/w";
            this.colGeschlecht.FieldName = "Geschlecht";
            this.colGeschlecht.Name = "colGeschlecht";
            this.colGeschlecht.Visible = true;
            this.colGeschlecht.VisibleIndex = 6;
            this.colGeschlecht.Width = 34;
            // 
            // colAlter
            // 
            this.colAlter.AppearanceCell.Options.UseTextOptions = true;
            this.colAlter.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Alter";
            this.colAlter.Name = "colAlter";
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 7;
            this.colAlter.Width = 38;
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Caption = "Geburt";
            this.colGeburtsdatum.FieldName = "Geburtsdatum";
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            this.colGeburtsdatum.Visible = true;
            this.colGeburtsdatum.VisibleIndex = 8;
            // 
            // colNationalitaet
            // 
            this.colNationalitaet.Caption = "Nationalität";
            this.colNationalitaet.FieldName = "NationalitaetCode";
            this.colNationalitaet.Name = "colNationalitaet";
            this.colNationalitaet.Visible = true;
            this.colNationalitaet.VisibleIndex = 9;
            this.colNationalitaet.Width = 97;
            // 
            // colAHVNr
            // 
            this.colAHVNr.Caption = "AHV-Nr.";
            this.colAHVNr.FieldName = "AHVNummer";
            this.colAHVNr.Name = "colAHVNr";
            this.colAHVNr.Visible = true;
            this.colAHVNr.VisibleIndex = 10;
            this.colAHVNr.Width = 101;
            // 
            // colVersNr
            // 
            this.colVersNr.Caption = "Vers.-Nr.";
            this.colVersNr.FieldName = "Versichertennummer";
            this.colVersNr.Name = "colVersNr";
            this.colVersNr.Visible = true;
            this.colVersNr.VisibleIndex = 11;
            this.colVersNr.Width = 101;
            // 
            // edtName
            // 
            this.edtName.EditValue = "";
            this.edtName.Location = new System.Drawing.Point(85, 40);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(206, 24);
            this.edtName.TabIndex = 1;
            // 
            // edtVorname
            // 
            this.edtVorname.EditValue = "";
            this.edtVorname.Location = new System.Drawing.Point(85, 70);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Size = new System.Drawing.Size(206, 24);
            this.edtVorname.TabIndex = 3;
            // 
            // edtStrasse
            // 
            this.edtStrasse.EditValue = "";
            this.edtStrasse.Location = new System.Drawing.Point(85, 100);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Size = new System.Drawing.Size(206, 24);
            this.edtStrasse.TabIndex = 5;
            // 
            // edtPLZ
            // 
            this.edtPLZ.EditValue = "";
            this.edtPLZ.Location = new System.Drawing.Point(85, 130);
            this.edtPLZ.Name = "edtPLZ";
            this.edtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZ.Size = new System.Drawing.Size(56, 24);
            this.edtPLZ.TabIndex = 7;
            // 
            // edtOrt
            // 
            this.edtOrt.EditValue = "";
            this.edtOrt.Location = new System.Drawing.Point(140, 130);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Size = new System.Drawing.Size(151, 24);
            this.edtOrt.TabIndex = 8;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Location = new System.Drawing.Point(395, 40);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Size = new System.Drawing.Size(95, 24);
            this.edtBaPersonID.TabIndex = 12;
            // 
            // edtGeburtVon
            // 
            this.edtGeburtVon.EditValue = null;
            this.edtGeburtVon.Location = new System.Drawing.Point(395, 71);
            this.edtGeburtVon.Name = "edtGeburtVon";
            this.edtGeburtVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtVon.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGeburtVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGeburtVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtVon.Properties.ShowToday = false;
            this.edtGeburtVon.Size = new System.Drawing.Size(95, 24);
            this.edtGeburtVon.TabIndex = 14;
            // 
            // edtGeburtBis
            // 
            this.edtGeburtBis.EditValue = null;
            this.edtGeburtBis.Location = new System.Drawing.Point(510, 71);
            this.edtGeburtBis.Name = "edtGeburtBis";
            this.edtGeburtBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtBis.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGeburtBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGeburtBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtBis.Properties.ShowToday = false;
            this.edtGeburtBis.Size = new System.Drawing.Size(95, 24);
            this.edtGeburtBis.TabIndex = 15;
            // 
            // edtNationalitaet
            // 
            this.edtNationalitaet.Location = new System.Drawing.Point(395, 101);
            this.edtNationalitaet.LOVFilter = "1=1";
            this.edtNationalitaet.LOVFilterWhereAppend = true;
            this.edtNationalitaet.LOVName = "BaLand";
            this.edtNationalitaet.Name = "edtNationalitaet";
            this.edtNationalitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNationalitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNationalitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNationalitaet.Properties.Appearance.Options.UseFont = true;
            this.edtNationalitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNationalitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNationalitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNationalitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtNationalitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtNationalitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNationalitaet.Properties.NullText = "";
            this.edtNationalitaet.Properties.ShowFooter = false;
            this.edtNationalitaet.Properties.ShowHeader = false;
            this.edtNationalitaet.Size = new System.Drawing.Size(210, 24);
            this.edtNationalitaet.TabIndex = 17;
            // 
            // edtAHVNummer
            // 
            this.edtAHVNummer.Location = new System.Drawing.Point(395, 131);
            this.edtAHVNummer.Name = "edtAHVNummer";
            this.edtAHVNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAHVNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummer.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummer.Size = new System.Drawing.Size(210, 24);
            this.edtAHVNummer.TabIndex = 19;
            // 
            // edtFT
            // 
            this.edtFT.EditValue = false;
            this.edtFT.Location = new System.Drawing.Point(85, 160);
            this.edtFT.Name = "edtFT";
            this.edtFT.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFT.Properties.Appearance.Options.UseBackColor = true;
            this.edtFT.Properties.Caption = "nur Fallträger";
            this.edtFT.Size = new System.Drawing.Size(206, 19);
            this.edtFT.TabIndex = 9;
            // 
            // kissLabel80
            // 
            this.kissLabel80.Location = new System.Drawing.Point(495, 71);
            this.kissLabel80.Name = "kissLabel80";
            this.kissLabel80.Size = new System.Drawing.Size(9, 24);
            this.kissLabel80.TabIndex = 605;
            this.kissLabel80.Text = "-";
            this.kissLabel80.UseCompatibleTextRendering = true;
            // 
            // lblSucheVorname
            // 
            this.lblSucheVorname.Location = new System.Drawing.Point(30, 70);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(49, 24);
            this.lblSucheVorname.TabIndex = 2;
            this.lblSucheVorname.Text = "Vorname";
            this.lblSucheVorname.UseCompatibleTextRendering = true;
            // 
            // lblSucheNationalitaet
            // 
            this.lblSucheNationalitaet.Location = new System.Drawing.Point(308, 101);
            this.lblSucheNationalitaet.Name = "lblSucheNationalitaet";
            this.lblSucheNationalitaet.Size = new System.Drawing.Size(85, 24);
            this.lblSucheNationalitaet.TabIndex = 16;
            this.lblSucheNationalitaet.Text = "Nationalität";
            this.lblSucheNationalitaet.UseCompatibleTextRendering = true;
            // 
            // lblSucheAHVNummer
            // 
            this.lblSucheAHVNummer.Location = new System.Drawing.Point(308, 131);
            this.lblSucheAHVNummer.Name = "lblSucheAHVNummer";
            this.lblSucheAHVNummer.Size = new System.Drawing.Size(85, 24);
            this.lblSucheAHVNummer.TabIndex = 18;
            this.lblSucheAHVNummer.Text = "AHV- Nr.";
            this.lblSucheAHVNummer.UseCompatibleTextRendering = true;
            // 
            // lblSucheGeburtsdatum
            // 
            this.lblSucheGeburtsdatum.Location = new System.Drawing.Point(308, 71);
            this.lblSucheGeburtsdatum.Name = "lblSucheGeburtsdatum";
            this.lblSucheGeburtsdatum.Size = new System.Drawing.Size(85, 24);
            this.lblSucheGeburtsdatum.TabIndex = 13;
            this.lblSucheGeburtsdatum.Text = "Geburt";
            this.lblSucheGeburtsdatum.UseCompatibleTextRendering = true;
            // 
            // lblSuchePlzOrt
            // 
            this.lblSuchePlzOrt.Location = new System.Drawing.Point(30, 130);
            this.lblSuchePlzOrt.Name = "lblSuchePlzOrt";
            this.lblSuchePlzOrt.Size = new System.Drawing.Size(48, 24);
            this.lblSuchePlzOrt.TabIndex = 6;
            this.lblSuchePlzOrt.Text = "PLZ / Ort";
            this.lblSuchePlzOrt.UseCompatibleTextRendering = true;
            // 
            // lblSucheStrasse
            // 
            this.lblSucheStrasse.Location = new System.Drawing.Point(30, 100);
            this.lblSucheStrasse.Name = "lblSucheStrasse";
            this.lblSucheStrasse.Size = new System.Drawing.Size(48, 24);
            this.lblSucheStrasse.TabIndex = 4;
            this.lblSucheStrasse.Text = "Strasse";
            this.lblSucheStrasse.UseCompatibleTextRendering = true;
            // 
            // lblSucheBaPersonID
            // 
            this.lblSucheBaPersonID.Location = new System.Drawing.Point(308, 40);
            this.lblSucheBaPersonID.Name = "lblSucheBaPersonID";
            this.lblSucheBaPersonID.Size = new System.Drawing.Size(85, 24);
            this.lblSucheBaPersonID.TabIndex = 11;
            this.lblSucheBaPersonID.Text = "Personen-Nr";
            this.lblSucheBaPersonID.UseCompatibleTextRendering = true;
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(30, 40);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(49, 24);
            this.lblSucheName.TabIndex = 0;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.Location = new System.Drawing.Point(139, 199);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(162, 24);
            this.ctlGotoFall.TabIndex = 1;
            // 
            // btnFallInfo
            // 
            this.btnFallInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFallInfo.Location = new System.Drawing.Point(335, 199);
            this.btnFallInfo.Name = "btnFallInfo";
            this.btnFallInfo.Size = new System.Drawing.Size(98, 24);
            this.btnFallInfo.TabIndex = 2;
            this.btnFallInfo.Text = "Fallinfo";
            this.btnFallInfo.UseCompatibleTextRendering = true;
            this.btnFallInfo.UseVisualStyleBackColor = false;
            this.btnFallInfo.Click += new System.EventHandler(this.btnFallInfo_Click);
            // 
            // lblAnzahlDatensaetze
            // 
            this.lblAnzahlDatensaetze.AutoSize = true;
            this.lblAnzahlDatensaetze.Location = new System.Drawing.Point(572, 205);
            this.lblAnzahlDatensaetze.Name = "lblAnzahlDatensaetze";
            this.lblAnzahlDatensaetze.Size = new System.Drawing.Size(102, 17);
            this.lblAnzahlDatensaetze.TabIndex = 3;
            this.lblAnzahlDatensaetze.Text = "Anzahl Datensätze:";
            this.lblAnzahlDatensaetze.UseCompatibleTextRendering = true;
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblRowCount.Location = new System.Drawing.Point(694, 205);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(10, 17);
            this.lblRowCount.TabIndex = 4;
            this.lblRowCount.Text = "0";
            this.lblRowCount.UseCompatibleTextRendering = true;
            // 
            // pnlDemographie
            // 
            this.pnlDemographie.Controls.Add(this.ctlBaPerson);
            this.pnlDemographie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDemographie.Location = new System.Drawing.Point(0, 232);
            this.pnlDemographie.Name = "pnlDemographie";
            this.pnlDemographie.Size = new System.Drawing.Size(1004, 418);
            this.pnlDemographie.TabIndex = 6;
            // 
            // ctlBaPerson
            // 
            this.ctlBaPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlBaPerson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlBaPerson.BaPersonID = 0;
            this.ctlBaPerson.IsTopHidden = true;
            this.ctlBaPerson.Location = new System.Drawing.Point(3, -28);
            this.ctlBaPerson.Name = "ctlBaPerson";
            this.ctlBaPerson.Size = new System.Drawing.Size(998, 443);
            this.ctlBaPerson.TabIndex = 0;
            // 
            // lblVersNr
            // 
            this.lblVersNr.Location = new System.Drawing.Point(308, 161);
            this.lblVersNr.Name = "lblVersNr";
            this.lblVersNr.Size = new System.Drawing.Size(85, 24);
            this.lblVersNr.TabIndex = 20;
            this.lblVersNr.Text = "Vers.-Nr.";
            this.lblVersNr.UseCompatibleTextRendering = true;
            // 
            // edtVersNr
            // 
            this.edtVersNr.Location = new System.Drawing.Point(395, 161);
            this.edtVersNr.Name = "edtVersNr";
            this.edtVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersNr.Size = new System.Drawing.Size(210, 24);
            this.edtVersNr.TabIndex = 21;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Location = new System.Drawing.Point(128, 205);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(787, 26);
            this.pnlInfo.TabIndex = 15;
            // 
            // splPersonenstamm
            // 
            this.splPersonenstamm.AnimationDelay = 20;
            this.splPersonenstamm.AnimationStep = 20;
            this.splPersonenstamm.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splPersonenstamm.ControlToHide = this.pnlDemographie;
            this.splPersonenstamm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splPersonenstamm.ExpandParentForm = false;
            this.splPersonenstamm.Location = new System.Drawing.Point(0, 224);
            this.splPersonenstamm.Name = "splPersonenstamm";
            this.splPersonenstamm.TabIndex = 5;
            this.splPersonenstamm.TabStop = false;
            this.splPersonenstamm.UseAnimations = false;
            this.splPersonenstamm.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // edtSucheKeinSerienbrief
            // 
            this.edtSucheKeinSerienbrief.EditValue = false;
            this.edtSucheKeinSerienbrief.Location = new System.Drawing.Point(85, 185);
            this.edtSucheKeinSerienbrief.Name = "edtSucheKeinSerienbrief";
            this.edtSucheKeinSerienbrief.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSucheKeinSerienbrief.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKeinSerienbrief.Properties.Caption = "nur mit Serienbrief";
            this.edtSucheKeinSerienbrief.Size = new System.Drawing.Size(206, 19);
            this.edtSucheKeinSerienbrief.TabIndex = 10;
            // 
            // CtlPersonenStamm
            // 
            this.ActiveSQLQuery = this.qryBaPerson;
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.lblAnzahlDatensaetze);
            this.Controls.Add(this.btnFallInfo);
            this.Controls.Add(this.ctlGotoFall);
            this.Controls.Add(this.splPersonenstamm);
            this.Controls.Add(this.pnlDemographie);
            this.Name = "CtlPersonenStamm";
            this.Size = new System.Drawing.Size(1004, 650);
            this.Controls.SetChildIndex(this.pnlDemographie, 0);
            this.Controls.SetChildIndex(this.splPersonenstamm, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.Controls.SetChildIndex(this.btnFallInfo, 0);
            this.Controls.SetChildIndex(this.lblAnzahlDatensaetze, 0);
            this.Controls.SetChildIndex(this.lblRowCount, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel80)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAHVNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePlzOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            this.pnlDemographie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKeinSerienbrief.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissButton btnFallInfo;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colFT;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitaet;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colVersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Basis.CtlBaPerson ctlBaPerson;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Gui.KissTextEdit edtAHVNummer;
        private KiSS4.Gui.KissCalcEdit edtBaPersonID;
        private KiSS4.Gui.KissCheckEdit edtFT;
        private KiSS4.Gui.KissDateEdit edtGeburtBis;
        private KiSS4.Gui.KissDateEdit edtGeburtVon;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissLookUpEdit edtNationalitaet;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissTextEdit edtPLZ;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissCheckEdit edtSucheKeinSerienbrief;
        private KiSS4.Gui.KissTextEdit edtVersNr;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private KiSS4.Gui.KissGrid grdBaPerson;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaPerson;
        private KiSS4.Gui.KissLabel kissLabel80;
        private System.Windows.Forms.Label lblAnzahlDatensaetze;
        private System.Windows.Forms.Label lblRowCount;
        private KiSS4.Gui.KissLabel lblSucheAHVNummer;
        private KiSS4.Gui.KissLabel lblSucheBaPersonID;
        private KiSS4.Gui.KissLabel lblSucheGeburtsdatum;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KiSS4.Gui.KissLabel lblSucheNationalitaet;
        private KiSS4.Gui.KissLabel lblSuchePlzOrt;
        private KiSS4.Gui.KissLabel lblSucheStrasse;
        private KiSS4.Gui.KissLabel lblSucheVorname;
        private KiSS4.Gui.KissLabel lblVersNr;
        private System.Windows.Forms.Panel pnlDemographie;
        private System.Windows.Forms.Panel pnlInfo;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private KiSS4.Gui.KissSplitterCollapsible splPersonenstamm;
    }
}
