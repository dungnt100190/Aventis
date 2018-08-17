using System;
using System.Data;
using System.Text;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    /// <summary>
    /// Query, used to display Bilanz Konti within KliBu
    /// </summary>
    public class CtlQueryKbBilanzkonti : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        /*
        Im Query gibts den Filter
          AND (BUC.SollKtoNr IS NULL OR BUC.HabenKtoNr IS NULL OR KOS.BgKostenartID IS NULL)

        dies war/ist aufgrund der (Ausgleichs-)Buchungen die eine SollKtoNr, eine HabenKtoNr UND eine BgKostenartID
        auf KbBuchungKostenart gesetzt haben!

        Das ganze ist etwas konzeptlos (Zitat Dani). Ich habs jetzt halt mal so geflickt!

        */
        private int _kbPeriodeID;
        private string _kontoNrSuche;
        private DevExpress.XtraGrid.Columns.GridColumn colBeleg;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBenutzer;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragSoll;
        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungtext;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGegenkonto;
        private DevExpress.XtraGrid.Columns.GridColumn colHabenKto;
        private DevExpress.XtraGrid.Columns.GridColumn colHabenKtoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colKA;
        private DevExpress.XtraGrid.Columns.GridColumn colKoABelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoName;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenart;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenstelle;
        private DevExpress.XtraGrid.Columns.GridColumn colMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colSollKto;
        private DevExpress.XtraGrid.Columns.GridColumn colSollKtoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colValutaDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissDateEdit edtDatumBisX;
        private KiSS4.Gui.KissDateEdit edtDatumVonX;
        private KiSS4.Gui.KissButtonEdit edtKontoX;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBuchung;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KissLabel lblBezahltAm;
        private KissDateEdit edtBezahltAmX;
        private DevExpress.XtraGrid.Columns.GridColumn colKbZahlungslaufID;
        private KissTextEdit edtKbZahlungslaufIDX;
        private KissLabel lblZahlungslaufID;
        private KissCheckEdit edtAuchUnverbuchte;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private KiSS4.Gui.KissLabel lblKontoVonX;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlQueryKbBilanzkonti"/> class.
        /// </summary>
        public CtlQueryKbBilanzkonti()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKbBilanzkonti));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.edtKontoX = new KiSS4.Gui.KissButtonEdit();
            this.lblKontoVonX = new KiSS4.Gui.KissLabel();
            this.edtDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.colBeleg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBenutzer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungtext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGegenkonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHabenKto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHabenKtoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKoABelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenstelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollKto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollKtoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValutaDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvBuchung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKontoName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKbZahlungslaufID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblBezahltAm = new KiSS4.Gui.KissLabel();
            this.edtBezahltAmX = new KiSS4.Gui.KissDateEdit();
            this.lblZahlungslaufID = new KiSS4.Gui.KissLabel();
            this.edtKbZahlungslaufIDX = new KiSS4.Gui.KissTextEdit();
            this.edtAuchUnverbuchte = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezahltAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezahltAmX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungslaufID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungslaufIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuchUnverbuchte.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.TableName = "KbBuchung";
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
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
            this.grdQuery1.MainView = this.grvBuchung;
            this.grdQuery1.Size = new System.Drawing.Size(779, 437);
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBuchung});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(164, -2522);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 414);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 26);
            this.ctlGotoFall.Visible = false;
            // 
            // searchTitle
            // 
            this.searchTitle.Location = new System.Drawing.Point(-3, 3);
            this.searchTitle.Size = new System.Drawing.Size(773, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Location = new System.Drawing.Point(3, 39);
            this.tabControlSearch.Size = new System.Drawing.Size(797, 478);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(785, 440);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtAuchUnverbuchte);
            this.tpgSuchen.Controls.Add(this.edtKbZahlungslaufIDX);
            this.tpgSuchen.Controls.Add(this.lblZahlungslaufID);
            this.tpgSuchen.Controls.Add(this.lblBezahltAm);
            this.tpgSuchen.Controls.Add(this.edtBezahltAmX);
            this.tpgSuchen.Controls.Add(this.lblBis);
            this.tpgSuchen.Controls.Add(this.lblDatumVon);
            this.tpgSuchen.Controls.Add(this.edtDatumBisX);
            this.tpgSuchen.Controls.Add(this.edtDatumVonX);
            this.tpgSuchen.Controls.Add(this.lblKontoVonX);
            this.tpgSuchen.Controls.Add(this.edtKontoX);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(785, 440);
            this.tpgSuchen.TabIndex = 1;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKontoX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKontoVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBezahltAmX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBezahltAm, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZahlungslaufID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKbZahlungslaufIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuchUnverbuchte, 0);
            // 
            // edtKontoX
            // 
            this.edtKontoX.Location = new System.Drawing.Point(130, 40);
            this.edtKontoX.Name = "edtKontoX";
            this.edtKontoX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoX.Properties.Appearance.Options.UseFont = true;
            this.edtKontoX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKontoX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKontoX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontoX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKontoX.Size = new System.Drawing.Size(324, 24);
            this.edtKontoX.TabIndex = 2;
            this.edtKontoX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKontoX_UserModifiedFld);
            // 
            // lblKontoVonX
            // 
            this.lblKontoVonX.Location = new System.Drawing.Point(19, 40);
            this.lblKontoVonX.Name = "lblKontoVonX";
            this.lblKontoVonX.Size = new System.Drawing.Size(81, 24);
            this.lblKontoVonX.TabIndex = 1;
            this.lblKontoVonX.Text = "Konto";
            this.lblKontoVonX.UseCompatibleTextRendering = true;
            // 
            // edtDatumVonX
            // 
            this.edtDatumVonX.EditValue = null;
            this.edtDatumVonX.Location = new System.Drawing.Point(130, 72);
            this.edtDatumVonX.Name = "edtDatumVonX";
            this.edtDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonX.Properties.ShowToday = false;
            this.edtDatumVonX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVonX.TabIndex = 4;
            // 
            // edtDatumBisX
            // 
            this.edtDatumBisX.EditValue = null;
            this.edtDatumBisX.Location = new System.Drawing.Point(264, 73);
            this.edtDatumBisX.Name = "edtDatumBisX";
            this.edtDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisX.Properties.ShowToday = false;
            this.edtDatumBisX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBisX.TabIndex = 6;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(19, 72);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(81, 24);
            this.lblDatumVon.TabIndex = 3;
            this.lblDatumVon.Text = "Beleg Datum";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(238, 72);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(17, 24);
            this.lblBis.TabIndex = 5;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            // 
            // colBeleg
            // 
            this.colBeleg.Caption = "Beleg Nr.";
            this.colBeleg.FieldName = "BelegNr";
            this.colBeleg.Name = "colBeleg";
            this.colBeleg.Visible = true;
            this.colBeleg.VisibleIndex = 0;
            this.colBeleg.Width = 49;
            // 
            // colBelegNr
            // 
            this.colBelegNr.Name = "colBelegNr";
            // 
            // colBenutzer
            // 
            this.colBenutzer.Caption = "Mitarbeiter";
            this.colBenutzer.FieldName = "Mitarbeiter";
            this.colBenutzer.Name = "colBenutzer";
            this.colBenutzer.Visible = true;
            this.colBenutzer.VisibleIndex = 14;
            this.colBenutzer.Width = 55;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Width = 50;
            // 
            // colBis
            // 
            this.colBis.Name = "colBis";
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungtext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.OptionsColumn.FixedWidth = true;
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 9;
            this.colBuchungstext.Width = 150;
            // 
            // colBuchungtext
            // 
            this.colBuchungtext.Name = "colBuchungtext";
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 6;
            this.colDatum.Width = 50;
            // 
            // colGegenkonto
            // 
            this.colGegenkonto.Caption = "Gegenkonto";
            this.colGegenkonto.FieldName = "Gegenkonto";
            this.colGegenkonto.Name = "colGegenkonto";
            this.colGegenkonto.Visible = true;
            this.colGegenkonto.VisibleIndex = 15;
            this.colGegenkonto.Width = 59;
            // 
            // colHabenKto
            // 
            this.colHabenKto.Caption = "Haben Konto";
            this.colHabenKto.FieldName = "HabenKonto";
            this.colHabenKto.Name = "colHabenKto";
            this.colHabenKto.OptionsColumn.FixedWidth = true;
            this.colHabenKto.Visible = true;
            this.colHabenKto.VisibleIndex = 13;
            this.colHabenKto.Width = 90;
            // 
            // colHabenKtoNr
            // 
            this.colHabenKtoNr.Caption = "Haben Kto-Nr.";
            this.colHabenKtoNr.FieldName = "HabenKontoNr";
            this.colHabenKtoNr.Name = "colHabenKtoNr";
            this.colHabenKtoNr.OptionsColumn.FixedWidth = true;
            this.colHabenKtoNr.Visible = true;
            this.colHabenKtoNr.VisibleIndex = 12;
            this.colHabenKtoNr.Width = 90;
            // 
            // colID
            // 
            this.colID.Name = "colID";
            // 
            // colKA
            // 
            this.colKA.Caption = "Kostenart";
            this.colKA.FieldName = "Kostenart";
            this.colKA.Name = "colKA";
            this.colKA.OptionsColumn.FixedWidth = true;
            this.colKA.Visible = true;
            this.colKA.VisibleIndex = 16;
            this.colKA.Width = 76;
            // 
            // colKoABelegNr
            // 
            this.colKoABelegNr.Caption = "KoA Beleg Nr.";
            this.colKoABelegNr.FieldName = "KoaBelegNr";
            this.colKoABelegNr.Name = "colKoABelegNr";
            this.colKoABelegNr.Visible = true;
            this.colKoABelegNr.VisibleIndex = 2;
            this.colKoABelegNr.Width = 70;
            // 
            // colKostenart
            // 
            this.colKostenart.Name = "colKostenart";
            // 
            // colKostenstelle
            // 
            this.colKostenstelle.Caption = "Kostenstelle";
            this.colKostenstelle.FieldName = "Kostenstelle";
            this.colKostenstelle.Name = "colKostenstelle";
            this.colKostenstelle.Visible = true;
            this.colKostenstelle.VisibleIndex = 17;
            this.colKostenstelle.Width = 89;
            // 
            // colMitarbeiter
            // 
            this.colMitarbeiter.Name = "colMitarbeiter";
            // 
            // colSollKto
            // 
            this.colSollKto.Caption = "Soll Konto";
            this.colSollKto.FieldName = "SollKonto";
            this.colSollKto.Name = "colSollKto";
            this.colSollKto.OptionsColumn.FixedWidth = true;
            this.colSollKto.Visible = true;
            this.colSollKto.VisibleIndex = 11;
            this.colSollKto.Width = 90;
            // 
            // colSollKtoNr
            // 
            this.colSollKtoNr.Caption = "Soll Kto-Nr.";
            this.colSollKtoNr.FieldName = "SollKontoNr";
            this.colSollKtoNr.Name = "colSollKtoNr";
            this.colSollKtoNr.OptionsColumn.FixedWidth = true;
            this.colSollKtoNr.Visible = true;
            this.colSollKtoNr.VisibleIndex = 10;
            this.colSollKtoNr.Width = 90;
            // 
            // colValutaDatum
            // 
            this.colValutaDatum.Caption = "Valuta";
            this.colValutaDatum.FieldName = "ValutaDatum";
            this.colValutaDatum.Name = "colValutaDatum";
            this.colValutaDatum.Visible = true;
            this.colValutaDatum.VisibleIndex = 7;
            // 
            // colVon
            // 
            this.colVon.Name = "colVon";
            // 
            // grvBuchung
            // 
            this.grvBuchung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBuchung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.Empty.Options.UseBackColor = true;
            this.grvBuchung.Appearance.Empty.Options.UseFont = true;
            this.grvBuchung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.EvenRow.Options.UseFont = true;
            this.grvBuchung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBuchung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBuchung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBuchung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBuchung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBuchung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBuchung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBuchung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBuchung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBuchung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBuchung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBuchung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBuchung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBuchung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBuchung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBuchung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBuchung.Appearance.GroupRow.Options.UseFont = true;
            this.grvBuchung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBuchung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBuchung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBuchung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBuchung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBuchung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBuchung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBuchung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBuchung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBuchung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBuchung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBuchung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBuchung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBuchung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBuchung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.OddRow.Options.UseFont = true;
            this.grvBuchung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBuchung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.Row.Options.UseBackColor = true;
            this.grvBuchung.Appearance.Row.Options.UseFont = true;
            this.grvBuchung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBuchung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBuchung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBuchung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBuchung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBuchung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKontoName,
            this.colBeleg,
            this.colStatus,
            this.colKoABelegNr,
            this.colBetrag,
            this.colBetragSoll,
            this.colBetragHaben,
            this.colSaldo,
            this.colDatum,
            this.colValutaDatum,
            this.colKbZahlungslaufID,
            this.colBuchungstext,
            this.colSollKtoNr,
            this.colSollKto,
            this.colHabenKtoNr,
            this.colHabenKto,
            this.colBenutzer,
            this.colGegenkonto,
            this.colKA,
            this.colKostenstelle});
            this.grvBuchung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBuchung.GridControl = this.grdQuery1;
            this.grvBuchung.GroupCount = 1;
            this.grvBuchung.Name = "grvBuchung";
            this.grvBuchung.OptionsBehavior.Editable = false;
            this.grvBuchung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBuchung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBuchung.OptionsNavigation.UseTabKey = false;
            this.grvBuchung.OptionsView.ColumnAutoWidth = false;
            this.grvBuchung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBuchung.OptionsView.ShowFooter = true;
            this.grvBuchung.OptionsView.ShowGroupPanel = false;
            this.grvBuchung.OptionsView.ShowIndicator = false;
            this.grvBuchung.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKontoName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colKontoName
            // 
            this.colKontoName.Caption = "Konto";
            this.colKontoName.FieldName = "KontoName";
            this.colKontoName.Name = "colKontoName";
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 1;
            // 
            // colBetragSoll
            // 
            this.colBetragSoll.Caption = "Soll";
            this.colBetragSoll.FieldName = "BetragSoll";
            this.colBetragSoll.Name = "colBetragSoll";
            this.colBetragSoll.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetragSoll.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragSoll.Visible = true;
            this.colBetragSoll.VisibleIndex = 3;
            this.colBetragSoll.Width = 50;
            // 
            // colBetragHaben
            // 
            this.colBetragHaben.Caption = "Haben";
            this.colBetragHaben.FieldName = "BetragHaben";
            this.colBetragHaben.Name = "colBetragHaben";
            this.colBetragHaben.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetragHaben.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragHaben.Visible = true;
            this.colBetragHaben.VisibleIndex = 4;
            this.colBetragHaben.Width = 50;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "N2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 5;
            this.colSaldo.Width = 50;
            // 
            // colKbZahlungslaufID
            // 
            this.colKbZahlungslaufID.Caption = "ZahlungslaufID";
            this.colKbZahlungslaufID.FieldName = "KbZahlungslaufID";
            this.colKbZahlungslaufID.Name = "colKbZahlungslaufID";
            this.colKbZahlungslaufID.Visible = true;
            this.colKbZahlungslaufID.VisibleIndex = 8;
            // 
            // lblBezahltAm
            // 
            this.lblBezahltAm.Location = new System.Drawing.Point(19, 102);
            this.lblBezahltAm.Name = "lblBezahltAm";
            this.lblBezahltAm.Size = new System.Drawing.Size(81, 24);
            this.lblBezahltAm.TabIndex = 7;
            this.lblBezahltAm.Text = "Bezahlt am";
            this.lblBezahltAm.UseCompatibleTextRendering = true;
            // 
            // edtBezahltAmX
            // 
            this.edtBezahltAmX.EditValue = null;
            this.edtBezahltAmX.Location = new System.Drawing.Point(130, 102);
            this.edtBezahltAmX.Name = "edtBezahltAmX";
            this.edtBezahltAmX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBezahltAmX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezahltAmX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezahltAmX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezahltAmX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezahltAmX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezahltAmX.Properties.Appearance.Options.UseFont = true;
            this.edtBezahltAmX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBezahltAmX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBezahltAmX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBezahltAmX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBezahltAmX.Properties.ShowToday = false;
            this.edtBezahltAmX.Size = new System.Drawing.Size(100, 24);
            this.edtBezahltAmX.TabIndex = 8;
            // 
            // lblZahlungslaufID
            // 
            this.lblZahlungslaufID.Location = new System.Drawing.Point(19, 132);
            this.lblZahlungslaufID.Name = "lblZahlungslaufID";
            this.lblZahlungslaufID.Size = new System.Drawing.Size(81, 24);
            this.lblZahlungslaufID.TabIndex = 9;
            this.lblZahlungslaufID.Text = "ZahlungslaufID";
            this.lblZahlungslaufID.UseCompatibleTextRendering = true;
            // 
            // edtKbZahlungslaufIDX
            // 
            this.edtKbZahlungslaufIDX.Location = new System.Drawing.Point(130, 132);
            this.edtKbZahlungslaufIDX.Name = "edtKbZahlungslaufIDX";
            this.edtKbZahlungslaufIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKbZahlungslaufIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKbZahlungslaufIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKbZahlungslaufIDX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKbZahlungslaufIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKbZahlungslaufIDX.Properties.Appearance.Options.UseFont = true;
            this.edtKbZahlungslaufIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKbZahlungslaufIDX.Size = new System.Drawing.Size(100, 24);
            this.edtKbZahlungslaufIDX.TabIndex = 10;
            // 
            // edtAuchUnverbuchte
            // 
            this.edtAuchUnverbuchte.EditValue = false;
            this.edtAuchUnverbuchte.Location = new System.Drawing.Point(130, 162);
            this.edtAuchUnverbuchte.Name = "edtAuchUnverbuchte";
            this.edtAuchUnverbuchte.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtAuchUnverbuchte.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuchUnverbuchte.Properties.Caption = "auch unverbuchte Zahlungseingänge anzeigen";
            this.edtAuchUnverbuchte.Size = new System.Drawing.Size(324, 19);
            this.edtAuchUnverbuchte.TabIndex = 13;
            // 
            // CtlQueryKbBilanzkonti
            // 
            this.Name = "CtlQueryKbBilanzkonti";
            this.Size = new System.Drawing.Size(807, 517);
            this.Load += new System.EventHandler(this.CtlQueryKbBilanzkonti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezahltAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezahltAmX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungslaufID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKbZahlungslaufIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuchUnverbuchte.Properties)).EndInit();
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

        #region EventHandlers

        private void CtlQueryKbBilanzkonti_Load(object sender, System.EventArgs e)
        {
            _kontoNrSuche = "";
            _kbPeriodeID = (int)FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID");
            base.grdQuery1.XtraPrint += new KiSS4.Gui.XtraPrintEventHandler(this.grdQuery1_XtraPrint);
            this.kissSearch.SelectParameters = new object[] { _kbPeriodeID };
        }

        private void edtKontoX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtKontoX.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtKontoX.LookupID = DBNull.Value;
                    edtKontoX.EditValue = DBNull.Value;
                    _kontoNrSuche = "";
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(string.Format(@"
                SELECT KbKontoID$ = KbKontoID,
                       KontoNr,
                       KontoName
                FROM KbKonto
                WHERE KontoNr LIKE '%' + isNull({0},'') + '%'
                  AND KbPeriodeID = {1}
                  AND KbKontoklasseCode IN (5,6)
                ORDER BY SortKey, KontoNr", "{0}", _kbPeriodeID),
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtKontoX.EditValue = dlg["KontoName"].ToString();
                edtKontoX.LookupID = Convert.ToInt32(dlg["KbKontoID$"]);
                _kontoNrSuche = dlg["KontoNr"].ToString();

            }
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            grdQuery1.DataSource = null;
            grvBuchung.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragSoll", colBetragSoll, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragHaben", colBetragHaben, "{0:N2}")});

            // Saldo berechnen
            decimal saldo = (decimal)0.0;
            string kontoNr = "";
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                if (kontoNr != row["KontoNr"].ToString())
                {
                    kontoNr = row["KontoNr"].ToString();
                    saldo = Utils.ConvertToDecimal(row["Vorsaldo"]);
                }

                saldo += Utils.ConvertToDecimal(row["BetragSoll"]) - Utils.ConvertToDecimal(row["BetragHaben"]);
                row["Saldo"] = saldo;
            }

            qryQuery.DataTable.AcceptChanges();
            qryQuery.RowModified = false;
            grdQuery1.DataSource = qryQuery;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnSearch()
        {
            base.OnSearch();

            GroupKonto();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            _kontoNrSuche = "";
        }

        #endregion

        #region Private Methods

        private void GroupKonto()
        {
            if (edtKontoX.EditValue == null || string.IsNullOrEmpty(edtKontoX.EditValue.ToString()))
            {
                colKontoName.GroupIndex = 0;
                colKontoName.Visible = false;
                grvBuchung.GroupCount = 1;
                grvBuchung.ExpandAllGroups();
            }
            else
            {
                grvBuchung.GroupCount = 0;
            }
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn der User mit der
        /// rechten Maustaste das Grid ausdrucken will.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdQuery1_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            //Footer
            StringBuilder footer = new StringBuilder();
            footer.Append(Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text));
            footer.Append(", ");
            footer.Append(KissMsg.GetMLMessage("CtlQueryKbBilanzKonti", "Seite", "Seite"));
            footer.Append(" [Page # of Pages #]"); //http://www.devexpress.com/Support/Center/kb/p/A607.aspx

            //Header
            StringBuilder header = new StringBuilder();
            header.Append(KissMsg.GetMLMessage("CtlQueryKbBilanzKonti", "KbBilanzKonti", "Bilanzkonti"));

            //Header -> Ausgewähltes Konto
            if (!string.IsNullOrEmpty(_kontoNrSuche))
            {
                header.Append(": ");
                header.Append(_kontoNrSuche);
            }

            //Footer und Header setzen.
            grdQuery1.SetHeaderAndFooterText(e, header.ToString(), footer.ToString());
        }

        #endregion

        #endregion
    }
}
