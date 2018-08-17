using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Klientenbuchhaltung
{
    partial class CtlKbBelegImportSH
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbBelegImportSH));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grvKbBuchungKostenart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPositionImBelegDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_Teilbetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_Text = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_Person = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_KbBuchungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKbBuchung = new KiSS4.Gui.KissGrid();
            this.qryKbBuchung = new KiSS4.DB.SqlQuery(this.components);
            this.grvKbBuchung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKbBuchungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_Betrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_ValutaDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_Buchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_BelegStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_PSCDBelegNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_BelegDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_Auszahlungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPscdZahlwegArt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeleg_Zahlungsempfaenger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPscdFehlermeldung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdBeleg = new KiSS4.Gui.KissGrid();
            this.qryBeleg = new KiSS4.DB.SqlQuery(this.components);
            this.grvBeleg = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repStatusImg = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErfassungsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBudgetMonatJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValutaDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colESR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuszahlungsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErsteller = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panImport = new System.Windows.Forms.Panel();
            this.lblSummeSelektion = new KiSS4.Gui.KissLabel();
            this.edtSummeSelektion = new KiSS4.Gui.KissCalcEdit();
            this.lblBelegImport = new KiSS4.Gui.KissLabel();
            this.edtErgaenzungText = new KiSS4.Gui.KissTextEdit();
            this.edtBuchungsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblEraenzungBuchungstext = new KiSS4.Gui.KissLabel();
            this.lblBelegdatum = new KiSS4.Gui.KissLabel();
            this.btnImport = new KiSS4.Gui.KissButton();
            this.lblSucheDatumVon = new KiSS4.Gui.KissLabel();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.lblSucheStatus = new KiSS4.Gui.KissLabel();
            this.edtSucheValutaVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheValutaBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheKbBuchungsStatus = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtSucheBudgetVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheBudgetVon = new KiSS4.Gui.KissLabel();
            this.lblSucheBudgetBis = new KiSS4.Gui.KissLabel();
            this.edtSucheBudgetBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGruppe = new KiSS4.Gui.KissLabel();
            this.lblSucheBarbelegVon = new KiSS4.Gui.KissLabel();
            this.lblSucheBarbelegBis = new KiSS4.Gui.KissLabel();
            this.edtSucheBarbelegVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheBarbelegBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheGruppe = new KiSS4.Gui.KissLookUpEdit();
            this.lblPeriodeMandant = new KiSS4.Gui.KissLabel();
            this.panBelegDetail = new System.Windows.Forms.Panel();
            this.qryGruppe = new KiSS4.DB.SqlQuery(this.components);
            this.chkSucheInterneVerrechnungEinbeziehen = new KiSS4.Gui.KissCheckEdit();
            this.panTop = new System.Windows.Forms.Panel();
            this.lblRowCount = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.edtSucheBelegNrBis = new KiSS4.Gui.KissCalcEdit();
            this.edtSucheBelegNrVon = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheBelegNrBis = new KiSS4.Gui.KissLabel();
            this.lblSucheBelegNrVon = new KiSS4.Gui.KissLabel();
            this.chkSucheOhneBelegNr = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheErfasser = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheErfasser = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBeleg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBeleg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBeleg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImg)).BeginInit();
            this.panImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSummeSelektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSummeSelektion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErgaenzungText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEraenzungBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKbBuchungsStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBudgetVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBudgetVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBudgetBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBudgetBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBarbelegVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBarbelegBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBarbelegVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBarbelegBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeMandant)).BeginInit();
            this.panBelegDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryGruppe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheInterneVerrechnungEinbeziehen.Properties)).BeginInit();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegNrBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegNrVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegNrBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegNrVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheOhneBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfasser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErfasser)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(754, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 30);
            this.tabControlSearch.Size = new System.Drawing.Size(778, 362);
            this.tabControlSearch.TabIndex = 1;
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdBeleg);
            this.tpgListe.Controls.Add(this.panImport);
            this.tpgListe.Size = new System.Drawing.Size(766, 324);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblSucheErfasser);
            this.tpgSuchen.Controls.Add(this.edtSucheErfasser);
            this.tpgSuchen.Controls.Add(this.edtSucheBelegNrBis);
            this.tpgSuchen.Controls.Add(this.edtSucheBelegNrVon);
            this.tpgSuchen.Controls.Add(this.lblSucheBelegNrBis);
            this.tpgSuchen.Controls.Add(this.lblSucheBelegNrVon);
            this.tpgSuchen.Controls.Add(this.chkSucheOhneBelegNr);
            this.tpgSuchen.Controls.Add(this.chkSucheInterneVerrechnungEinbeziehen);
            this.tpgSuchen.Controls.Add(this.edtSucheGruppe);
            this.tpgSuchen.Controls.Add(this.edtSucheBarbelegBis);
            this.tpgSuchen.Controls.Add(this.edtSucheBarbelegVon);
            this.tpgSuchen.Controls.Add(this.lblSucheBarbelegBis);
            this.tpgSuchen.Controls.Add(this.lblSucheBarbelegVon);
            this.tpgSuchen.Controls.Add(this.lblSucheGruppe);
            this.tpgSuchen.Controls.Add(this.edtSucheBudgetBis);
            this.tpgSuchen.Controls.Add(this.lblSucheBudgetBis);
            this.tpgSuchen.Controls.Add(this.lblSucheBudgetVon);
            this.tpgSuchen.Controls.Add(this.edtSucheBudgetVon);
            this.tpgSuchen.Controls.Add(this.edtSucheKbBuchungsStatus);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaBis);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaVon);
            this.tpgSuchen.Controls.Add(this.lblSucheStatus);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumVon);
            this.tpgSuchen.Size = new System.Drawing.Size(766, 324);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKbBuchungsStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBudgetVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBudgetVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBudgetBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBudgetBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGruppe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBarbelegVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBarbelegBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBarbelegVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBarbelegBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGruppe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheInterneVerrechnungEinbeziehen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheOhneBelegNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBelegNrVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBelegNrBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBelegNrVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBelegNrBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheErfasser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheErfasser, 0);
            // 
            // grvKbBuchungKostenart
            // 
            this.grvKbBuchungKostenart.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.grvKbBuchungKostenart.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKbBuchungKostenart.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungKostenart.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvKbBuchungKostenart.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.OddRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchungKostenart.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchungKostenart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPositionImBelegDetail,
            this.colBeleg_Teilbetrag,
            this.colBeleg_Text,
            this.colBeleg_Person,
            this.colBeleg_KbBuchungID});
            this.grvKbBuchungKostenart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbBuchungKostenart.GridControl = this.grdKbBuchung;
            this.grvKbBuchungKostenart.Name = "grvKbBuchungKostenart";
            this.grvKbBuchungKostenart.OptionsBehavior.Editable = false;
            this.grvKbBuchungKostenart.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchungKostenart.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchungKostenart.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchungKostenart.OptionsNavigation.UseTabKey = false;
            this.grvKbBuchungKostenart.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchungKostenart.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchungKostenart.OptionsView.ShowIndicator = false;
            // 
            // colPositionImBelegDetail
            // 
            this.colPositionImBelegDetail.Caption = "Pos";
            this.colPositionImBelegDetail.FieldName = "PositionImBeleg";
            this.colPositionImBelegDetail.Name = "colPositionImBelegDetail";
            this.colPositionImBelegDetail.Visible = true;
            this.colPositionImBelegDetail.VisibleIndex = 0;
            this.colPositionImBelegDetail.Width = 35;
            // 
            // colBeleg_Teilbetrag
            // 
            this.colBeleg_Teilbetrag.Caption = "Betrag";
            this.colBeleg_Teilbetrag.DisplayFormat.FormatString = "n2";
            this.colBeleg_Teilbetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBeleg_Teilbetrag.FieldName = "Betrag";
            this.colBeleg_Teilbetrag.Name = "colBeleg_Teilbetrag";
            this.colBeleg_Teilbetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBeleg_Teilbetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBeleg_Teilbetrag.Visible = true;
            this.colBeleg_Teilbetrag.VisibleIndex = 1;
            this.colBeleg_Teilbetrag.Width = 96;
            // 
            // colBeleg_Text
            // 
            this.colBeleg_Text.Caption = "Text";
            this.colBeleg_Text.FieldName = "Buchungstext";
            this.colBeleg_Text.Name = "colBeleg_Text";
            this.colBeleg_Text.Visible = true;
            this.colBeleg_Text.VisibleIndex = 2;
            this.colBeleg_Text.Width = 154;
            // 
            // colBeleg_Person
            // 
            this.colBeleg_Person.Caption = "betrifft Person";
            this.colBeleg_Person.FieldName = "PersonName";
            this.colBeleg_Person.Name = "colBeleg_Person";
            this.colBeleg_Person.Visible = true;
            this.colBeleg_Person.VisibleIndex = 3;
            this.colBeleg_Person.Width = 140;
            // 
            // colBeleg_KbBuchungID
            // 
            this.colBeleg_KbBuchungID.Caption = "Buchung-ID";
            this.colBeleg_KbBuchungID.FieldName = "KbBuchungID";
            this.colBeleg_KbBuchungID.Name = "colBeleg_KbBuchungID";
            // 
            // grdKbBuchung
            // 
            this.grdKbBuchung.DataSource = this.qryKbBuchung;
            this.grdKbBuchung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdKbBuchung.EmbeddedNavigator.Name = "";
            gridLevelNode1.LevelTemplate = this.grvKbBuchungKostenart;
            gridLevelNode1.RelationName = "BelegDetail";
            this.grdKbBuchung.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdKbBuchung.Location = new System.Drawing.Point(0, 0);
            this.grdKbBuchung.MainView = this.grvKbBuchung;
            this.grdKbBuchung.Name = "grdKbBuchung";
            this.grdKbBuchung.Size = new System.Drawing.Size(778, 200);
            this.grdKbBuchung.TabIndex = 0;
            this.grdKbBuchung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbBuchung,
            this.grvKbBuchungKostenart});
            // 
            // qryKbBuchung
            // 
            this.qryKbBuchung.SelectStatement = resources.GetString("qryKbBuchung.SelectStatement");
            this.qryKbBuchung.AfterFill += new System.EventHandler(this.qryKbBuchung_AfterFill);
            // 
            // grvKbBuchung
            // 
            this.grvKbBuchung.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.grvKbBuchung.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvKbBuchung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbBuchung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchung.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvKbBuchung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.OddRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbBuchung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKbBuchung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKbBuchungID,
            this.colBeleg_Betrag,
            this.colBeleg_ValutaDatum,
            this.colBeleg_Buchungstext,
            this.colBeleg_BelegStatus,
            this.colBeleg_PSCDBelegNummer,
            this.colBeleg_BelegDatum,
            this.colBeleg_Auszahlungsart,
            this.colPscdZahlwegArt,
            this.colBeleg_Zahlungsempfaenger,
            this.colPscdFehlermeldung});
            this.grvKbBuchung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.PaleGreen;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colBeleg_BelegStatus;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = 102;
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Gold;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colBeleg_BelegStatus;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = 103;
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.LightCoral;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.colBeleg_BelegStatus;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = "104";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.DarkGray;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Column = this.colBeleg_BelegStatus;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition4.Value1 = "106";
            this.grvKbBuchung.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4});
            this.grvKbBuchung.GridControl = this.grdKbBuchung;
            this.grvKbBuchung.Name = "grvKbBuchung";
            this.grvKbBuchung.OptionsBehavior.Editable = false;
            this.grvKbBuchung.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchung.OptionsDetail.ShowDetailTabs = false;
            this.grvKbBuchung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchung.OptionsNavigation.UseTabKey = false;
            this.grvKbBuchung.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchung.OptionsView.ShowChildrenInGroupPanel = true;
            this.grvKbBuchung.OptionsView.ShowFooter = true;
            this.grvKbBuchung.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchung.OptionsView.ShowIndicator = false;
            // 
            // colKbBuchungID
            // 
            this.colKbBuchungID.AppearanceCell.Options.UseTextOptions = true;
            this.colKbBuchungID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colKbBuchungID.Caption = "Beleg-ID";
            this.colKbBuchungID.FieldName = "KbBuchungID";
            this.colKbBuchungID.MinWidth = 10;
            this.colKbBuchungID.Name = "colKbBuchungID";
            this.colKbBuchungID.Visible = true;
            this.colKbBuchungID.VisibleIndex = 0;
            this.colKbBuchungID.Width = 64;
            // 
            // colBeleg_Betrag
            // 
            this.colBeleg_Betrag.AppearanceCell.Options.UseTextOptions = true;
            this.colBeleg_Betrag.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBeleg_Betrag.Caption = "Betrag";
            this.colBeleg_Betrag.DisplayFormat.FormatString = "n2";
            this.colBeleg_Betrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBeleg_Betrag.FieldName = "Betrag";
            this.colBeleg_Betrag.Name = "colBeleg_Betrag";
            this.colBeleg_Betrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBeleg_Betrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBeleg_Betrag.Visible = true;
            this.colBeleg_Betrag.VisibleIndex = 1;
            // 
            // colBeleg_ValutaDatum
            // 
            this.colBeleg_ValutaDatum.Caption = "Valuta";
            this.colBeleg_ValutaDatum.FieldName = "ValutaDatum";
            this.colBeleg_ValutaDatum.Name = "colBeleg_ValutaDatum";
            this.colBeleg_ValutaDatum.Visible = true;
            this.colBeleg_ValutaDatum.VisibleIndex = 2;
            this.colBeleg_ValutaDatum.Width = 77;
            // 
            // colBeleg_Buchungstext
            // 
            this.colBeleg_Buchungstext.Caption = "Buchungstext";
            this.colBeleg_Buchungstext.FieldName = "Text";
            this.colBeleg_Buchungstext.Name = "colBeleg_Buchungstext";
            this.colBeleg_Buchungstext.Visible = true;
            this.colBeleg_Buchungstext.VisibleIndex = 3;
            this.colBeleg_Buchungstext.Width = 135;
            // 
            // colBeleg_BelegStatus
            // 
            this.colBeleg_BelegStatus.Caption = "Stat.";
            this.colBeleg_BelegStatus.FieldName = "KbBuchungStatusCode";
            this.colBeleg_BelegStatus.Name = "colBeleg_BelegStatus";
            this.colBeleg_BelegStatus.Visible = true;
            this.colBeleg_BelegStatus.VisibleIndex = 4;
            this.colBeleg_BelegStatus.Width = 40;
            // 
            // colBeleg_PSCDBelegNummer
            // 
            this.colBeleg_PSCDBelegNummer.Caption = "Fibu Beleg Nr";
            this.colBeleg_PSCDBelegNummer.FieldName = "BelegNr";
            this.colBeleg_PSCDBelegNummer.Name = "colBeleg_PSCDBelegNummer";
            this.colBeleg_PSCDBelegNummer.Visible = true;
            this.colBeleg_PSCDBelegNummer.VisibleIndex = 5;
            this.colBeleg_PSCDBelegNummer.Width = 92;
            // 
            // colBeleg_BelegDatum
            // 
            this.colBeleg_BelegDatum.Caption = "Belegdatum";
            this.colBeleg_BelegDatum.FieldName = "BelegDatum";
            this.colBeleg_BelegDatum.Name = "colBeleg_BelegDatum";
            this.colBeleg_BelegDatum.Visible = true;
            this.colBeleg_BelegDatum.VisibleIndex = 6;
            this.colBeleg_BelegDatum.Width = 80;
            // 
            // colBeleg_Auszahlungsart
            // 
            this.colBeleg_Auszahlungsart.Caption = "Auszahlungsart";
            this.colBeleg_Auszahlungsart.FieldName = "KbAuszahlungsArtCode";
            this.colBeleg_Auszahlungsart.Name = "colBeleg_Auszahlungsart";
            this.colBeleg_Auszahlungsart.Visible = true;
            this.colBeleg_Auszahlungsart.VisibleIndex = 7;
            this.colBeleg_Auszahlungsart.Width = 122;
            // 
            // colPscdZahlwegArt
            // 
            this.colPscdZahlwegArt.FieldName = "PscdZahlwegArt";
            this.colPscdZahlwegArt.Name = "colPscdZahlwegArt";
            this.colPscdZahlwegArt.Visible = true;
            this.colPscdZahlwegArt.VisibleIndex = 8;
            this.colPscdZahlwegArt.Width = 20;
            // 
            // colBeleg_Zahlungsempfaenger
            // 
            this.colBeleg_Zahlungsempfaenger.Caption = "Zahlungsempfaenger";
            this.colBeleg_Zahlungsempfaenger.FieldName = "Zahlungsempfaenger";
            this.colBeleg_Zahlungsempfaenger.Name = "colBeleg_Zahlungsempfaenger";
            this.colBeleg_Zahlungsempfaenger.Visible = true;
            this.colBeleg_Zahlungsempfaenger.VisibleIndex = 9;
            this.colBeleg_Zahlungsempfaenger.Width = 159;
            // 
            // colPscdFehlermeldung
            // 
            this.colPscdFehlermeldung.Caption = "PSCD-Fehlermeldung";
            this.colPscdFehlermeldung.FieldName = "PscdFehlermeldung";
            this.colPscdFehlermeldung.Name = "colPscdFehlermeldung";
            this.colPscdFehlermeldung.Width = 143;
            // 
            // grdBeleg
            // 
            this.grdBeleg.DataSource = this.qryBeleg;
            this.grdBeleg.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdBeleg.EmbeddedNavigator.Name = "";
            this.grdBeleg.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBeleg.Location = new System.Drawing.Point(0, 77);
            this.grdBeleg.MainView = this.grvBeleg;
            this.grdBeleg.Name = "grdBeleg";
            this.grdBeleg.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repStatusImg});
            this.grdBeleg.Size = new System.Drawing.Size(766, 247);
            this.grdBeleg.TabIndex = 1;
            this.grdBeleg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBeleg});
            // 
            // qryBeleg
            // 
            this.qryBeleg.CanUpdate = true;
            this.qryBeleg.HostControl = this;
            this.qryBeleg.SelectStatement = resources.GetString("qryBeleg.SelectStatement");
            this.qryBeleg.TableName = "KbBuchung";
            this.qryBeleg.AfterFill += new System.EventHandler(this.qryBeleg_AfterFill);
            this.qryBeleg.PositionChanged += new System.EventHandler(this.qryBeleg_PositionChanged);
            // 
            // grvBeleg
            // 
            this.grvBeleg.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBeleg.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBeleg.Appearance.Empty.Options.UseBackColor = true;
            this.grvBeleg.Appearance.Empty.Options.UseFont = true;
            this.grvBeleg.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBeleg.Appearance.EvenRow.Options.UseFont = true;
            this.grvBeleg.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBeleg.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBeleg.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBeleg.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBeleg.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBeleg.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBeleg.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBeleg.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBeleg.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBeleg.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBeleg.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBeleg.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBeleg.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBeleg.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBeleg.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBeleg.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBeleg.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBeleg.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBeleg.Appearance.GroupRow.Options.UseFont = true;
            this.grvBeleg.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBeleg.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBeleg.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBeleg.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBeleg.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBeleg.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBeleg.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBeleg.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBeleg.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBeleg.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBeleg.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBeleg.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBeleg.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBeleg.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBeleg.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBeleg.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBeleg.Appearance.OddRow.Options.UseFont = true;
            this.grvBeleg.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBeleg.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBeleg.Appearance.Row.Options.UseBackColor = true;
            this.grvBeleg.Appearance.Row.Options.UseFont = true;
            this.grvBeleg.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBeleg.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBeleg.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBeleg.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBeleg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBeleg.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatus,
            this.colBelegNr,
            this.colErfassungsdatum,
            this.colBudgetMonatJahr,
            this.colValutaDatum,
            this.colBetrag,
            this.colKlient,
            this.colBuchungstext,
            this.colKreditor,
            this.colESR,
            this.colAuszahlungsart,
            this.colErsteller});
            this.grvBeleg.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBeleg.GridControl = this.grdBeleg;
            this.grvBeleg.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBeleg.Name = "grvBeleg";
            this.grvBeleg.OptionsBehavior.Editable = false;
            this.grvBeleg.OptionsCustomization.AllowFilter = false;
            this.grvBeleg.OptionsFilter.AllowFilterEditor = false;
            this.grvBeleg.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBeleg.OptionsMenu.EnableColumnMenu = false;
            this.grvBeleg.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBeleg.OptionsNavigation.UseTabKey = false;
            this.grvBeleg.OptionsSelection.MultiSelect = true;
            this.grvBeleg.OptionsView.ColumnAutoWidth = false;
            this.grvBeleg.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBeleg.OptionsView.ShowFooter = true;
            this.grvBeleg.OptionsView.ShowGroupPanel = false;
            this.grvBeleg.OptionsView.ShowIndicator = false;
            this.grvBeleg.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvBeleg_SelectionChanged);
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Stat.";
            this.colStatus.ColumnEdit = this.repStatusImg;
            this.colStatus.FieldName = "KbBuchungStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 0;
            this.colStatus.Width = 40;
            // 
            // repStatusImg
            // 
            this.repStatusImg.AutoHeight = false;
            this.repStatusImg.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repStatusImg.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repStatusImg.Name = "repStatusImg";
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "Beleg-Nr.";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 1;
            this.colBelegNr.Width = 70;
            // 
            // colErfassungsdatum
            // 
            this.colErfassungsdatum.Caption = "B-Datum";
            this.colErfassungsdatum.FieldName = "BelegDatum";
            this.colErfassungsdatum.Name = "colErfassungsdatum";
            this.colErfassungsdatum.Visible = true;
            this.colErfassungsdatum.VisibleIndex = 2;
            // 
            // colBudgetMonatJahr
            // 
            this.colBudgetMonatJahr.Caption = "Budget";
            this.colBudgetMonatJahr.FieldName = "BudgetMonatJahr";
            this.colBudgetMonatJahr.Name = "colBudgetMonatJahr";
            this.colBudgetMonatJahr.Visible = true;
            this.colBudgetMonatJahr.VisibleIndex = 3;
            // 
            // colValutaDatum
            // 
            this.colValutaDatum.Caption = "Valuta";
            this.colValutaDatum.FieldName = "ValutaDatum";
            this.colValutaDatum.Name = "colValutaDatum";
            this.colValutaDatum.Visible = true;
            this.colValutaDatum.VisibleIndex = 4;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 5;
            this.colBetrag.Width = 80;
            // 
            // colKlient
            // 
            this.colKlient.Caption = "Klient/-in";
            this.colKlient.FieldName = "KlientIn";
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 6;
            this.colKlient.Width = 150;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Text";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 7;
            this.colBuchungstext.Width = 200;
            // 
            // colKreditor
            // 
            this.colKreditor.Caption = "Kreditor";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 8;
            this.colKreditor.Width = 100;
            // 
            // colESR
            // 
            this.colESR.Caption = "ESR";
            this.colESR.FieldName = "Referenznummer";
            this.colESR.Name = "colESR";
            this.colESR.Visible = true;
            this.colESR.VisibleIndex = 9;
            this.colESR.Width = 90;
            // 
            // colAuszahlungsart
            // 
            this.colAuszahlungsart.Caption = "Auszahlungsart";
            this.colAuszahlungsart.FieldName = "KbAuszahlungsArtCode";
            this.colAuszahlungsart.Name = "colAuszahlungsart";
            this.colAuszahlungsart.Visible = true;
            this.colAuszahlungsart.VisibleIndex = 10;
            this.colAuszahlungsart.Width = 120;
            // 
            // colErsteller
            // 
            this.colErsteller.Caption = "Beleg Ersteller";
            this.colErsteller.FieldName = "Ersteller";
            this.colErsteller.Name = "colErsteller";
            this.colErsteller.Visible = true;
            this.colErsteller.VisibleIndex = 11;
            this.colErsteller.Width = 120;
            // 
            // panImport
            // 
            this.panImport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panImport.Controls.Add(this.lblSummeSelektion);
            this.panImport.Controls.Add(this.edtSummeSelektion);
            this.panImport.Controls.Add(this.lblBelegImport);
            this.panImport.Controls.Add(this.edtErgaenzungText);
            this.panImport.Controls.Add(this.edtBuchungsdatum);
            this.panImport.Controls.Add(this.lblEraenzungBuchungstext);
            this.panImport.Controls.Add(this.lblBelegdatum);
            this.panImport.Controls.Add(this.btnImport);
            this.panImport.Dock = System.Windows.Forms.DockStyle.Top;
            this.panImport.Location = new System.Drawing.Point(0, 0);
            this.panImport.Name = "panImport";
            this.panImport.Size = new System.Drawing.Size(766, 77);
            this.panImport.TabIndex = 0;
            // 
            // lblSummeSelektion
            // 
            this.lblSummeSelektion.Location = new System.Drawing.Point(9, 42);
            this.lblSummeSelektion.Name = "lblSummeSelektion";
            this.lblSummeSelektion.Size = new System.Drawing.Size(57, 24);
            this.lblSummeSelektion.TabIndex = 1;
            this.lblSummeSelektion.Text = "Summe";
            this.lblSummeSelektion.UseCompatibleTextRendering = true;
            // 
            // edtSummeSelektion
            // 
            this.edtSummeSelektion.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSummeSelektion.Location = new System.Drawing.Point(72, 42);
            this.edtSummeSelektion.Name = "edtSummeSelektion";
            this.edtSummeSelektion.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSummeSelektion.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSummeSelektion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSummeSelektion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSummeSelektion.Properties.Appearance.Options.UseBackColor = true;
            this.edtSummeSelektion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSummeSelektion.Properties.Appearance.Options.UseFont = true;
            this.edtSummeSelektion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSummeSelektion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSummeSelektion.Properties.DisplayFormat.FormatString = "c";
            this.edtSummeSelektion.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSummeSelektion.Properties.EditFormat.FormatString = "c";
            this.edtSummeSelektion.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSummeSelektion.Properties.Mask.EditMask = "c";
            this.edtSummeSelektion.Properties.ReadOnly = true;
            this.edtSummeSelektion.Size = new System.Drawing.Size(114, 24);
            this.edtSummeSelektion.TabIndex = 2;
            this.edtSummeSelektion.TabStop = false;
            // 
            // lblBelegImport
            // 
            this.lblBelegImport.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblBelegImport.Location = new System.Drawing.Point(9, 9);
            this.lblBelegImport.Name = "lblBelegImport";
            this.lblBelegImport.Size = new System.Drawing.Size(199, 20);
            this.lblBelegImport.TabIndex = 0;
            this.lblBelegImport.Text = "Belegimport aus Budgets";
            this.lblBelegImport.UseCompatibleTextRendering = true;
            // 
            // edtErgaenzungText
            // 
            this.edtErgaenzungText.Location = new System.Drawing.Point(371, 42);
            this.edtErgaenzungText.Name = "edtErgaenzungText";
            this.edtErgaenzungText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErgaenzungText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErgaenzungText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErgaenzungText.Properties.Appearance.Options.UseBackColor = true;
            this.edtErgaenzungText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErgaenzungText.Properties.Appearance.Options.UseFont = true;
            this.edtErgaenzungText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErgaenzungText.Size = new System.Drawing.Size(214, 24);
            this.edtErgaenzungText.TabIndex = 6;
            // 
            // edtBuchungsdatum
            // 
            this.edtBuchungsdatum.EditValue = null;
            this.edtBuchungsdatum.Location = new System.Drawing.Point(371, 12);
            this.edtBuchungsdatum.Name = "edtBuchungsdatum";
            this.edtBuchungsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchungsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBuchungsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBuchungsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBuchungsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchungsdatum.Properties.ShowToday = false;
            this.edtBuchungsdatum.Size = new System.Drawing.Size(95, 24);
            this.edtBuchungsdatum.TabIndex = 4;
            // 
            // lblEraenzungBuchungstext
            // 
            this.lblEraenzungBuchungstext.Location = new System.Drawing.Point(221, 42);
            this.lblEraenzungBuchungstext.Name = "lblEraenzungBuchungstext";
            this.lblEraenzungBuchungstext.Size = new System.Drawing.Size(144, 24);
            this.lblEraenzungBuchungstext.TabIndex = 5;
            this.lblEraenzungBuchungstext.Text = "Ergänzung Buchungstext";
            this.lblEraenzungBuchungstext.UseCompatibleTextRendering = true;
            // 
            // lblBelegdatum
            // 
            this.lblBelegdatum.Location = new System.Drawing.Point(221, 12);
            this.lblBelegdatum.Name = "lblBelegdatum";
            this.lblBelegdatum.Size = new System.Drawing.Size(144, 24);
            this.lblBelegdatum.TabIndex = 3;
            this.lblBelegdatum.Text = "Belegdatum";
            this.lblBelegdatum.UseCompatibleTextRendering = true;
            // 
            // btnImport
            // 
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Location = new System.Drawing.Point(609, 42);
            this.btnImport.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(146, 24);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Belege &importieren";
            this.btnImport.UseCompatibleTextRendering = true;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblSucheDatumVon
            // 
            this.lblSucheDatumVon.Location = new System.Drawing.Point(30, 40);
            this.lblSucheDatumVon.Name = "lblSucheDatumVon";
            this.lblSucheDatumVon.Size = new System.Drawing.Size(123, 24);
            this.lblSucheDatumVon.TabIndex = 1;
            this.lblSucheDatumVon.Text = "Valuta von";
            this.lblSucheDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblSucheDatumBis
            // 
            this.lblSucheDatumBis.Location = new System.Drawing.Point(260, 40);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(28, 24);
            this.lblSucheDatumBis.TabIndex = 3;
            this.lblSucheDatumBis.Text = "bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            // 
            // lblSucheStatus
            // 
            this.lblSucheStatus.Location = new System.Drawing.Point(433, 40);
            this.lblSucheStatus.Name = "lblSucheStatus";
            this.lblSucheStatus.Size = new System.Drawing.Size(123, 24);
            this.lblSucheStatus.TabIndex = 21;
            this.lblSucheStatus.Text = "Status";
            this.lblSucheStatus.UseCompatibleTextRendering = true;
            // 
            // edtSucheValutaVon
            // 
            this.edtSucheValutaVon.EditValue = null;
            this.edtSucheValutaVon.Location = new System.Drawing.Point(159, 40);
            this.edtSucheValutaVon.Name = "edtSucheValutaVon";
            this.edtSucheValutaVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheValutaVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheValutaVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaVon.Properties.ShowToday = false;
            this.edtSucheValutaVon.Size = new System.Drawing.Size(95, 24);
            this.edtSucheValutaVon.TabIndex = 2;
            // 
            // edtSucheValutaBis
            // 
            this.edtSucheValutaBis.EditValue = null;
            this.edtSucheValutaBis.Location = new System.Drawing.Point(294, 40);
            this.edtSucheValutaBis.Name = "edtSucheValutaBis";
            this.edtSucheValutaBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheValutaBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaBis.Properties.ShowToday = false;
            this.edtSucheValutaBis.Size = new System.Drawing.Size(95, 24);
            this.edtSucheValutaBis.TabIndex = 4;
            // 
            // edtSucheKbBuchungsStatus
            // 
            this.edtSucheKbBuchungsStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSucheKbBuchungsStatus.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtSucheKbBuchungsStatus.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKbBuchungsStatus.Appearance.Options.UseBackColor = true;
            this.edtSucheKbBuchungsStatus.Appearance.Options.UseBorderColor = true;
            this.edtSucheKbBuchungsStatus.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtSucheKbBuchungsStatus.CheckOnClick = true;
            this.edtSucheKbBuchungsStatus.Location = new System.Drawing.Point(433, 70);
            this.edtSucheKbBuchungsStatus.LOVFilter = "BelegImportS";
            this.edtSucheKbBuchungsStatus.LOVName = "KbBuchungsStatus";
            this.edtSucheKbBuchungsStatus.Name = "edtSucheKbBuchungsStatus";
            this.edtSucheKbBuchungsStatus.Size = new System.Drawing.Size(268, 251);
            this.edtSucheKbBuchungsStatus.TabIndex = 22;
            // 
            // edtSucheBudgetVon
            // 
            this.edtSucheBudgetVon.EditValue = null;
            this.edtSucheBudgetVon.Location = new System.Drawing.Point(159, 70);
            this.edtSucheBudgetVon.Name = "edtSucheBudgetVon";
            this.edtSucheBudgetVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBudgetVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBudgetVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBudgetVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBudgetVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBudgetVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBudgetVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBudgetVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheBudgetVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheBudgetVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheBudgetVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBudgetVon.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtSucheBudgetVon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSucheBudgetVon.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtSucheBudgetVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSucheBudgetVon.Properties.Mask.EditMask = "MM.yyyy";
            this.edtSucheBudgetVon.Properties.ShowToday = false;
            this.edtSucheBudgetVon.Size = new System.Drawing.Size(95, 24);
            this.edtSucheBudgetVon.TabIndex = 6;
            // 
            // lblSucheBudgetVon
            // 
            this.lblSucheBudgetVon.Location = new System.Drawing.Point(30, 70);
            this.lblSucheBudgetVon.Name = "lblSucheBudgetVon";
            this.lblSucheBudgetVon.Size = new System.Drawing.Size(123, 24);
            this.lblSucheBudgetVon.TabIndex = 5;
            this.lblSucheBudgetVon.Text = "Budget von";
            this.lblSucheBudgetVon.UseCompatibleTextRendering = true;
            // 
            // lblSucheBudgetBis
            // 
            this.lblSucheBudgetBis.Location = new System.Drawing.Point(260, 70);
            this.lblSucheBudgetBis.Name = "lblSucheBudgetBis";
            this.lblSucheBudgetBis.Size = new System.Drawing.Size(28, 24);
            this.lblSucheBudgetBis.TabIndex = 7;
            this.lblSucheBudgetBis.Text = "bis";
            this.lblSucheBudgetBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheBudgetBis
            // 
            this.edtSucheBudgetBis.EditValue = null;
            this.edtSucheBudgetBis.Location = new System.Drawing.Point(294, 70);
            this.edtSucheBudgetBis.Name = "edtSucheBudgetBis";
            this.edtSucheBudgetBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBudgetBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBudgetBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBudgetBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBudgetBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBudgetBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBudgetBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBudgetBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheBudgetBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheBudgetBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheBudgetBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBudgetBis.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtSucheBudgetBis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSucheBudgetBis.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtSucheBudgetBis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSucheBudgetBis.Properties.Mask.EditMask = "MM.yyyy";
            this.edtSucheBudgetBis.Properties.ShowToday = false;
            this.edtSucheBudgetBis.Size = new System.Drawing.Size(95, 24);
            this.edtSucheBudgetBis.TabIndex = 8;
            // 
            // lblSucheGruppe
            // 
            this.lblSucheGruppe.Location = new System.Drawing.Point(30, 185);
            this.lblSucheGruppe.Name = "lblSucheGruppe";
            this.lblSucheGruppe.Size = new System.Drawing.Size(123, 24);
            this.lblSucheGruppe.TabIndex = 18;
            this.lblSucheGruppe.Text = "Gruppe";
            this.lblSucheGruppe.UseCompatibleTextRendering = true;
            // 
            // lblSucheBarbelegVon
            // 
            this.lblSucheBarbelegVon.Location = new System.Drawing.Point(30, 100);
            this.lblSucheBarbelegVon.Name = "lblSucheBarbelegVon";
            this.lblSucheBarbelegVon.Size = new System.Drawing.Size(123, 24);
            this.lblSucheBarbelegVon.TabIndex = 9;
            this.lblSucheBarbelegVon.Text = "Barbeleg von";
            this.lblSucheBarbelegVon.UseCompatibleTextRendering = true;
            // 
            // lblSucheBarbelegBis
            // 
            this.lblSucheBarbelegBis.Location = new System.Drawing.Point(260, 100);
            this.lblSucheBarbelegBis.Name = "lblSucheBarbelegBis";
            this.lblSucheBarbelegBis.Size = new System.Drawing.Size(28, 24);
            this.lblSucheBarbelegBis.TabIndex = 11;
            this.lblSucheBarbelegBis.Text = "bis";
            this.lblSucheBarbelegBis.UseCompatibleTextRendering = true;
            // 
            // edtSucheBarbelegVon
            // 
            this.edtSucheBarbelegVon.EditValue = null;
            this.edtSucheBarbelegVon.Location = new System.Drawing.Point(159, 100);
            this.edtSucheBarbelegVon.Name = "edtSucheBarbelegVon";
            this.edtSucheBarbelegVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBarbelegVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBarbelegVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBarbelegVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBarbelegVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBarbelegVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBarbelegVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBarbelegVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheBarbelegVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheBarbelegVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheBarbelegVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBarbelegVon.Properties.ShowToday = false;
            this.edtSucheBarbelegVon.Size = new System.Drawing.Size(95, 24);
            this.edtSucheBarbelegVon.TabIndex = 10;
            // 
            // edtSucheBarbelegBis
            // 
            this.edtSucheBarbelegBis.EditValue = null;
            this.edtSucheBarbelegBis.Location = new System.Drawing.Point(294, 100);
            this.edtSucheBarbelegBis.Name = "edtSucheBarbelegBis";
            this.edtSucheBarbelegBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBarbelegBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBarbelegBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBarbelegBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBarbelegBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBarbelegBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBarbelegBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBarbelegBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheBarbelegBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheBarbelegBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheBarbelegBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBarbelegBis.Properties.ShowToday = false;
            this.edtSucheBarbelegBis.Size = new System.Drawing.Size(95, 24);
            this.edtSucheBarbelegBis.TabIndex = 12;
            // 
            // edtSucheGruppe
            // 
            this.edtSucheGruppe.Location = new System.Drawing.Point(159, 185);
            this.edtSucheGruppe.Name = "edtSucheGruppe";
            this.edtSucheGruppe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGruppe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGruppe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGruppe.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGruppe.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGruppe.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheGruppe.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGruppe.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheGruppe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheGruppe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheGruppe.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGruppe.Properties.NullText = "";
            this.edtSucheGruppe.Properties.ShowFooter = false;
            this.edtSucheGruppe.Properties.ShowHeader = false;
            this.edtSucheGruppe.Size = new System.Drawing.Size(230, 24);
            this.edtSucheGruppe.TabIndex = 19;
            // 
            // lblPeriodeMandant
            // 
            this.lblPeriodeMandant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriodeMandant.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblPeriodeMandant.Location = new System.Drawing.Point(35, 7);
            this.lblPeriodeMandant.Name = "lblPeriodeMandant";
            this.lblPeriodeMandant.Size = new System.Drawing.Size(516, 16);
            this.lblPeriodeMandant.TabIndex = 0;
            this.lblPeriodeMandant.Text = "Mandant, PeriodeVon PeriodeBis";
            this.lblPeriodeMandant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPeriodeMandant.UseCompatibleTextRendering = true;
            // 
            // panBelegDetail
            // 
            this.panBelegDetail.Controls.Add(this.grdKbBuchung);
            this.panBelegDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBelegDetail.Location = new System.Drawing.Point(0, 400);
            this.panBelegDetail.Name = "panBelegDetail";
            this.panBelegDetail.Size = new System.Drawing.Size(778, 200);
            this.panBelegDetail.TabIndex = 3;
            // 
            // qryGruppe
            // 
            this.qryGruppe.HostControl = this;
            this.qryGruppe.SelectStatement = "SELECT [Text] = ItemName,   \r\n       [Code] = OrgUnitID\r\nFROM dbo.XOrgUnit WITH (" +
                "READUNCOMMITTED)\r\nUNION\r\nSELECT [Text] = \'\',\r\n       [Code] = NULL\r\nORDER BY [Te" +
                "xt] ASC;";
            // 
            // chkSucheInterneVerrechnungEinbeziehen
            // 
            this.chkSucheInterneVerrechnungEinbeziehen.EditValue = false;
            this.chkSucheInterneVerrechnungEinbeziehen.Location = new System.Drawing.Point(159, 254);
            this.chkSucheInterneVerrechnungEinbeziehen.Name = "chkSucheInterneVerrechnungEinbeziehen";
            this.chkSucheInterneVerrechnungEinbeziehen.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheInterneVerrechnungEinbeziehen.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheInterneVerrechnungEinbeziehen.Properties.Caption = "Interne Verrechnung einbeziehen";
            this.chkSucheInterneVerrechnungEinbeziehen.Size = new System.Drawing.Size(230, 19);
            this.chkSucheInterneVerrechnungEinbeziehen.TabIndex = 20;
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.lblRowCount);
            this.panTop.Controls.Add(this.picTitel);
            this.panTop.Controls.Add(this.lblPeriodeMandant);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(778, 30);
            this.panTop.TabIndex = 0;
            // 
            // lblRowCount
            // 
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Location = new System.Drawing.Point(557, 3);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(218, 24);
            this.lblRowCount.TabIndex = 0;
            this.lblRowCount.Text = "Anzahl Einträge: <Count>";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picTitel
            // 
            this.picTitel.Image = global::KiSS4.Klientenbuchhaltung.Properties.Resources.info_small;
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 7;
            this.picTitel.TabStop = false;
            // 
            // splitter
            // 
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.panBelegDetail;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(0, 392);
            this.splitter.MinSize = 50;
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 2;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // edtSucheBelegNrBis
            // 
            this.edtSucheBelegNrBis.Location = new System.Drawing.Point(294, 130);
            this.edtSucheBelegNrBis.Name = "edtSucheBelegNrBis";
            this.edtSucheBelegNrBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBelegNrBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBelegNrBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBelegNrBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBelegNrBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBelegNrBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBelegNrBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBelegNrBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBelegNrBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBelegNrBis.Properties.DisplayFormat.FormatString = "n0";
            this.edtSucheBelegNrBis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBelegNrBis.Properties.EditFormat.FormatString = "n0";
            this.edtSucheBelegNrBis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBelegNrBis.Properties.Mask.EditMask = "n0";
            this.edtSucheBelegNrBis.Properties.Precision = 0;
            this.edtSucheBelegNrBis.Size = new System.Drawing.Size(95, 24);
            this.edtSucheBelegNrBis.TabIndex = 16;
            this.edtSucheBelegNrBis.EditValueChanged += new System.EventHandler(this.edtSucheBelegNr_EditValueChanged);
            // 
            // edtSucheBelegNrVon
            // 
            this.edtSucheBelegNrVon.Location = new System.Drawing.Point(159, 130);
            this.edtSucheBelegNrVon.Name = "edtSucheBelegNrVon";
            this.edtSucheBelegNrVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBelegNrVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBelegNrVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBelegNrVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBelegNrVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBelegNrVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBelegNrVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBelegNrVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBelegNrVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBelegNrVon.Properties.Precision = 0;
            this.edtSucheBelegNrVon.Size = new System.Drawing.Size(95, 24);
            this.edtSucheBelegNrVon.TabIndex = 14;
            this.edtSucheBelegNrVon.EditValueChanged += new System.EventHandler(this.edtSucheBelegNr_EditValueChanged);
            // 
            // lblSucheBelegNrBis
            // 
            this.lblSucheBelegNrBis.Location = new System.Drawing.Point(260, 130);
            this.lblSucheBelegNrBis.Name = "lblSucheBelegNrBis";
            this.lblSucheBelegNrBis.Size = new System.Drawing.Size(28, 24);
            this.lblSucheBelegNrBis.TabIndex = 15;
            this.lblSucheBelegNrBis.Text = "bis";
            this.lblSucheBelegNrBis.UseCompatibleTextRendering = true;
            // 
            // lblSucheBelegNrVon
            // 
            this.lblSucheBelegNrVon.Location = new System.Drawing.Point(30, 130);
            this.lblSucheBelegNrVon.Name = "lblSucheBelegNrVon";
            this.lblSucheBelegNrVon.Size = new System.Drawing.Size(123, 24);
            this.lblSucheBelegNrVon.TabIndex = 13;
            this.lblSucheBelegNrVon.Text = "Beleg-Nr. von";
            this.lblSucheBelegNrVon.UseCompatibleTextRendering = true;
            // 
            // chkSucheOhneBelegNr
            // 
            this.chkSucheOhneBelegNr.EditValue = false;
            this.chkSucheOhneBelegNr.Location = new System.Drawing.Point(159, 160);
            this.chkSucheOhneBelegNr.Name = "chkSucheOhneBelegNr";
            this.chkSucheOhneBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheOhneBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheOhneBelegNr.Properties.Caption = "Ohne Beleg-Nr.";
            this.chkSucheOhneBelegNr.Size = new System.Drawing.Size(156, 19);
            this.chkSucheOhneBelegNr.TabIndex = 17;
            this.chkSucheOhneBelegNr.CheckedChanged += new System.EventHandler(this.chkSucheOhneBelegNr_CheckedChanged);
            // 
            // edtSucheErfasser
            // 
            this.edtSucheErfasser.Location = new System.Drawing.Point(159, 216);
            this.edtSucheErfasser.Name = "edtSucheErfasser";
            this.edtSucheErfasser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfasser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfasser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfasser.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfasser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfasser.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfasser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheErfasser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheErfasser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfasser.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtSucheErfasser.Size = new System.Drawing.Size(230, 24);
            this.edtSucheErfasser.TabIndex = 23;
            this.edtSucheErfasser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheErfasser_UserModifiedFld);
            // 
            // lblSucheErfasser
            // 
            this.lblSucheErfasser.Location = new System.Drawing.Point(30, 216);
            this.lblSucheErfasser.Name = "lblSucheErfasser";
            this.lblSucheErfasser.Size = new System.Drawing.Size(123, 24);
            this.lblSucheErfasser.TabIndex = 24;
            this.lblSucheErfasser.Text = "Beleg Ersteller";
            this.lblSucheErfasser.UseCompatibleTextRendering = true;
            // 
            // CtlKbBelegImportSH
            // 
            this.ActiveSQLQuery = this.qryBeleg;
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.panTop);
            this.Controls.Add(this.panBelegDetail);
            this.MinimumSize = new System.Drawing.Size(778, 0);
            this.Name = "CtlKbBelegImportSH";
            this.Size = new System.Drawing.Size(778, 600);
            this.Load += new System.EventHandler(this.CtlKbBelegImportSH_Load);
            this.Controls.SetChildIndex(this.panBelegDetail, 0);
            this.Controls.SetChildIndex(this.panTop, 0);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBeleg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBeleg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBeleg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImg)).EndInit();
            this.panImport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSummeSelektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSummeSelektion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErgaenzungText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEraenzungBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKbBuchungsStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBudgetVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBudgetVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBudgetBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBudgetBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBarbelegVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBarbelegBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBarbelegVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBarbelegBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPeriodeMandant)).EndInit();
            this.panBelegDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryGruppe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheInterneVerrechnungEinbeziehen.Properties)).EndInit();
            this.panTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegNrBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegNrVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegNrBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBelegNrVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheOhneBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfasser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheErfasser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnImport;
        private KiSS4.Gui.KissCheckEdit chkSucheInterneVerrechnungEinbeziehen;
        private KiSS4.Gui.KissCheckEdit chkSucheOhneBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAuszahlungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_Auszahlungsart;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_BelegDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_BelegStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_Betrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_Buchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_KbBuchungID;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_PSCDBelegNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_Person;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_Teilbetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_Text;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_ValutaDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg_Zahlungsempfaenger;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colBudgetMonatJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colESR;
        private DevExpress.XtraGrid.Columns.GridColumn colErfassungsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchungID;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colPositionImBelegDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colPscdFehlermeldung;
        private DevExpress.XtraGrid.Columns.GridColumn colPscdZahlwegArt;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colValutaDatum;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissDateEdit edtBuchungsdatum;
        private KiSS4.Gui.KissTextEdit edtErgaenzungText;
        private KiSS4.Gui.KissDateEdit edtSucheBarbelegBis;
        private KiSS4.Gui.KissDateEdit edtSucheBarbelegVon;
        private KiSS4.Gui.KissCalcEdit edtSucheBelegNrBis;
        private KiSS4.Gui.KissCalcEdit edtSucheBelegNrVon;
        private KiSS4.Gui.KissDateEdit edtSucheBudgetBis;
        private KiSS4.Gui.KissDateEdit edtSucheBudgetVon;
        private KiSS4.Gui.KissLookUpEdit edtSucheGruppe;
        private KiSS4.Gui.KissCheckedLookupEdit edtSucheKbBuchungsStatus;
        private KiSS4.Gui.KissDateEdit edtSucheValutaBis;
        private KiSS4.Gui.KissDateEdit edtSucheValutaVon;
        private KiSS4.Gui.KissCalcEdit edtSummeSelektion;
        private KiSS4.Gui.KissGrid grdBeleg;
        private KiSS4.Gui.KissGrid grdKbBuchung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBeleg;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchungKostenart;
        private KiSS4.Gui.KissLabel lblBelegImport;
        private KiSS4.Gui.KissLabel lblBelegdatum;
        private KiSS4.Gui.KissLabel lblEraenzungBuchungstext;
        private KiSS4.Gui.KissLabel lblPeriodeMandant;
        private KiSS4.Gui.KissLabel lblRowCount;
        private KiSS4.Gui.KissLabel lblSucheBarbelegBis;
        private KiSS4.Gui.KissLabel lblSucheBarbelegVon;
        private KiSS4.Gui.KissLabel lblSucheBelegNrBis;
        private KiSS4.Gui.KissLabel lblSucheBelegNrVon;
        private KiSS4.Gui.KissLabel lblSucheBudgetBis;
        private KiSS4.Gui.KissLabel lblSucheBudgetVon;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheDatumVon;
        private KiSS4.Gui.KissLabel lblSucheGruppe;
        private KiSS4.Gui.KissLabel lblSucheStatus;
        private KiSS4.Gui.KissLabel lblSummeSelektion;
        private System.Windows.Forms.Panel panBelegDetail;
        private System.Windows.Forms.Panel panImport;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBeleg;
        private KiSS4.DB.SqlQuery qryGruppe;
        private KiSS4.DB.SqlQuery qryKbBuchung;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repStatusImg;
        private KiSS4.Gui.KissSplitterCollapsible splitter;
        private Gui.KissLabel lblSucheErfasser;
        private Gui.KissButtonEdit edtSucheErfasser;
        private DevExpress.XtraGrid.Columns.GridColumn colErsteller;
    }
}
