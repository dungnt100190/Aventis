using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung
{
    public class CtlQueryKbKostenarten : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBeleg;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBenutzer;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungtext;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGegenkonto;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colKA;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenart;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenstelle;
        private DevExpress.XtraGrid.Columns.GridColumn colMitarbeiter;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colVon;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissDateEdit edtDatumBisX;
        private KiSS4.Gui.KissDateEdit edtDatumVonX;
        private KiSS4.Gui.KissButtonEdit edtKostenartBisX;
        private KiSS4.Gui.KissCalcEdit edtKostenartNrBis;
        private KiSS4.Gui.KissCalcEdit edtKostenartNrVon;
        private KiSS4.Gui.KissButtonEdit edtKostenartVonX;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;

        /*
        Im Query gibts den Filter
          AND (BUC.SollKtoNr IS NULL OR BUC.HabenKtoNr IS NULL OR KOS.BgKostenartID IS NULL)

        dies war/ist aufgrund der (Ausgleichs-)Buchungen die eine SollKtoNr, eine HabenKtoNr UND eine BgKostenartID
        auf KbBuchungKostenart gesetzt haben!

        Das ganze ist etwas konzeptlos (Zitat Dani). Ich habs jetzt halt mal so geflickt!

        */
        private int _kbPeriodeID;
        private KiSS4.Gui.KissLabel lblBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblKostenartBisX;
        private KiSS4.Gui.KissLabel lblKostenartVonX;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryKbKostenarten()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKbKostenarten));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.edtKostenartVonX = new KiSS4.Gui.KissButtonEdit();
            this.edtKostenartBisX = new KiSS4.Gui.KissButtonEdit();
            this.lblKostenartVonX = new KiSS4.Gui.KissLabel();
            this.lblKostenartBisX = new KiSS4.Gui.KissLabel();
            this.edtDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblBis = new KiSS4.Gui.KissLabel();
            this.edtKostenartNrVon = new KiSS4.Gui.KissCalcEdit();
            this.edtKostenartNrBis = new KiSS4.Gui.KissCalcEdit();
            this.colBeleg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBenutzer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungtext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGegenkonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenstelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitarbeiter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartNrVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartNrBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.TableName = "KbBuchung";
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
            this.grdQuery1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.grdQuery1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.Location = new System.Drawing.Point(0, 0);
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.Size = new System.Drawing.Size(772, 424);
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grdQuery1.XtraPrint += new KiSS4.Gui.XtraPrintEventHandler(this.grdQuery1_XtraPrint);
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
            this.ctlGotoFall.Visible = false;
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtKostenartNrBis);
            this.tpgSuchen.Controls.Add(this.edtKostenartNrVon);
            this.tpgSuchen.Controls.Add(this.lblBis);
            this.tpgSuchen.Controls.Add(this.lblDatumVon);
            this.tpgSuchen.Controls.Add(this.edtDatumBisX);
            this.tpgSuchen.Controls.Add(this.edtDatumVonX);
            this.tpgSuchen.Controls.Add(this.lblKostenartBisX);
            this.tpgSuchen.Controls.Add(this.lblKostenartVonX);
            this.tpgSuchen.Controls.Add(this.edtKostenartBisX);
            this.tpgSuchen.Controls.Add(this.edtKostenartVonX);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 1;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKostenartVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKostenartBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKostenartVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKostenartBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKostenartNrVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKostenartNrBis, 0);
            // 
            // edtKostenartVonX
            // 
            this.edtKostenartVonX.Location = new System.Drawing.Point(130, 40);
            this.edtKostenartVonX.Name = "edtKostenartVonX";
            this.edtKostenartVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenartVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenartVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenartVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenartVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenartVonX.Properties.Appearance.Options.UseFont = true;
            this.edtKostenartVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtKostenartVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtKostenartVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenartVonX.Size = new System.Drawing.Size(324, 24);
            this.edtKostenartVonX.TabIndex = 2;
            this.edtKostenartVonX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenartVonX_UserModifiedFld);
            // 
            // edtKostenartBisX
            // 
            this.edtKostenartBisX.Location = new System.Drawing.Point(130, 70);
            this.edtKostenartBisX.Name = "edtKostenartBisX";
            this.edtKostenartBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenartBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenartBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenartBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenartBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenartBisX.Properties.Appearance.Options.UseFont = true;
            this.edtKostenartBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKostenartBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKostenartBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenartBisX.Size = new System.Drawing.Size(324, 24);
            this.edtKostenartBisX.TabIndex = 4;
            this.edtKostenartBisX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenartBisX_UserModifiedFld);
            // 
            // lblKostenartVonX
            // 
            this.lblKostenartVonX.Location = new System.Drawing.Point(30, 40);
            this.lblKostenartVonX.Name = "lblKostenartVonX";
            this.lblKostenartVonX.Size = new System.Drawing.Size(94, 24);
            this.lblKostenartVonX.TabIndex = 1;
            this.lblKostenartVonX.Text = "Kostenart von";
            this.lblKostenartVonX.UseCompatibleTextRendering = true;
            // 
            // lblKostenartBisX
            // 
            this.lblKostenartBisX.Location = new System.Drawing.Point(30, 70);
            this.lblKostenartBisX.Name = "lblKostenartBisX";
            this.lblKostenartBisX.Size = new System.Drawing.Size(94, 24);
            this.lblKostenartBisX.TabIndex = 3;
            this.lblKostenartBisX.Text = "Kostenart bis";
            this.lblKostenartBisX.UseCompatibleTextRendering = true;
            // 
            // edtDatumVonX
            // 
            this.edtDatumVonX.EditValue = null;
            this.edtDatumVonX.Location = new System.Drawing.Point(130, 100);
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
            this.edtDatumVonX.TabIndex = 6;
            // 
            // edtDatumBisX
            // 
            this.edtDatumBisX.EditValue = null;
            this.edtDatumBisX.Location = new System.Drawing.Point(270, 101);
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
            this.edtDatumBisX.TabIndex = 8;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(30, 101);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(94, 24);
            this.lblDatumVon.TabIndex = 5;
            this.lblDatumVon.Text = "Beleg Datum";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblBis
            // 
            this.lblBis.Location = new System.Drawing.Point(236, 100);
            this.lblBis.Name = "lblBis";
            this.lblBis.Size = new System.Drawing.Size(28, 24);
            this.lblBis.TabIndex = 7;
            this.lblBis.Text = "bis";
            this.lblBis.UseCompatibleTextRendering = true;
            // 
            // edtKostenartNrVon
            // 
            this.edtKostenartNrVon.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKostenartNrVon.Location = new System.Drawing.Point(460, 40);
            this.edtKostenartNrVon.Name = "edtKostenartNrVon";
            this.edtKostenartNrVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKostenartNrVon.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKostenartNrVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenartNrVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenartNrVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenartNrVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenartNrVon.Properties.Appearance.Options.UseFont = true;
            this.edtKostenartNrVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenartNrVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenartNrVon.Properties.ReadOnly = true;
            this.edtKostenartNrVon.Size = new System.Drawing.Size(75, 24);
            this.edtKostenartNrVon.TabIndex = 10;
            // 
            // edtKostenartNrBis
            // 
            this.edtKostenartNrBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKostenartNrBis.Location = new System.Drawing.Point(460, 70);
            this.edtKostenartNrBis.Name = "edtKostenartNrBis";
            this.edtKostenartNrBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKostenartNrBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKostenartNrBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenartNrBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenartNrBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenartNrBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenartNrBis.Properties.Appearance.Options.UseFont = true;
            this.edtKostenartNrBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenartNrBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenartNrBis.Properties.ReadOnly = true;
            this.edtKostenartNrBis.Size = new System.Drawing.Size(75, 24);
            this.edtKostenartNrBis.TabIndex = 11;
            // 
            // colBeleg
            // 
            this.colBeleg.Caption = "Beleg Nr.";
            this.colBeleg.FieldName = "BelegNr";
            this.colBeleg.Name = "colBeleg";
            this.colBeleg.Visible = true;
            this.colBeleg.VisibleIndex = 0;
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
            this.colBenutzer.VisibleIndex = 3;
            this.colBenutzer.Width = 82;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 7;
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
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 2;
            this.colBuchungstext.Width = 164;
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
            this.colDatum.VisibleIndex = 1;
            // 
            // colGegenkonto
            // 
            this.colGegenkonto.Caption = "Gegenkonto";
            this.colGegenkonto.FieldName = "Gegenkonto";
            this.colGegenkonto.Name = "colGegenkonto";
            this.colGegenkonto.Visible = true;
            this.colGegenkonto.VisibleIndex = 4;
            this.colGegenkonto.Width = 88;
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
            this.colKA.Visible = true;
            this.colKA.VisibleIndex = 5;
            this.colKA.Width = 113;
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
            this.colKostenstelle.VisibleIndex = 6;
            this.colKostenstelle.Width = 114;
            // 
            // colMitarbeiter
            // 
            this.colMitarbeiter.Name = "colMitarbeiter";
            // 
            // colStatus
            // 
            this.colStatus.Name = "colStatus";
            // 
            // colVon
            // 
            this.colVon.Name = "colVon";
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
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBeleg,
            this.colDatum,
            this.colBuchungstext,
            this.colBenutzer,
            this.colGegenkonto,
            this.colKA,
            this.colKostenstelle,
            this.colBetrag});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryKbKostenarten
            // 
            this.Name = "CtlQueryKbKostenarten";
            this.Load += new System.EventHandler(this.CtlQueryKbKostenarten_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenartBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartNrVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenartNrBis.Properties)).EndInit();
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

        #region EventHandlers

        private void CtlQueryKbKostenarten_Load(object sender, System.EventArgs e)
        {
            qryQuery.SelectStatement = KliBuUtil.SELECT_KOSTENARTEN;

            _kbPeriodeID = (int)FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID");
            this.kissSearch.SelectParameters = new object[] { _kbPeriodeID };
        }

        private void edtKostenartBisX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtKostenartBisX.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtKostenartBisX.LookupID = DBNull.Value;
                    edtKostenartBisX.EditValue = DBNull.Value;
                }
                return;
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT BgKostenartID$ = BgKostenartID,
                       Name,
                       KontoNr
                FROM dbo.BgKostenart WITH (READUNCOMMITTED)
                WHERE KontoNr LIKE '%' + isNull({0},'') + '%'
                ORDER BY RIGHT(REPLICATE('0', 10) + KontoNr, 10) ASC",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtKostenartBisX.EditValue = Utils.ConvertToString(dlg["Name"]);
                edtKostenartBisX.LookupID = Utils.ConvertToInt(dlg["BgKostenartID$"]);
                edtKostenartNrBis.EditValue = dlg["KontoNr"];
            }
        }

        private void edtKostenartVonX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtKostenartVonX.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtKostenartVonX.LookupID = DBNull.Value;
                    edtKostenartVonX.EditValue = DBNull.Value;
                }
                return;
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT BgKostenartID$ = BgKostenartID,
                       Name,
                       KontoNr
                FROM dbo.BgKostenart WITH (READUNCOMMITTED)
                WHERE KontoNr LIKE '%' + isNull({0},'') + '%'
                ORDER BY RIGHT(REPLICATE('0', 10) + KontoNr, 10) ASC",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtKostenartVonX.EditValue = Utils.ConvertToString(dlg["Name"]);
                edtKostenartVonX.LookupID = Utils.ConvertToInt(dlg["BgKostenartID$"]);
                edtKostenartNrVon.EditValue = dlg["KontoNr"];
            }
        }

        private void grdQuery1_XtraPrint(object sender, XtraPrintEventArgs e)
        {
            string footerTextLeft = Utils.GetDateRangeText(edtDatumVonX.Text, edtDatumBisX.Text);
            grdQuery1.SetHeaderAndFooterText(
                e,
                KissMsg.GetMLMessage("CtlQueryKbKostenarten", "KbKostenarten", "Kostenarten"),
                footerTextLeft
            );
        }

        #endregion
    }
}