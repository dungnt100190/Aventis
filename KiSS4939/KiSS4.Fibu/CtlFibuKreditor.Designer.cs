using System;
using System.Data;
using System.Windows.Forms;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuKreditor.
    /// </summary>
    partial class CtlFibuKreditor
    {
        # region Class Members

        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit editName;
        private KiSS4.Gui.KissTabControlEx tabControlSearch;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;
        private KiSS4.Gui.KissGrid grdFbKreditor;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private System.Windows.Forms.Panel panel1;
        private KiSS4.Gui.KissGrid grdFbZahlungsweg;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbZahlungsweg;
        private DevExpress.XtraGrid.Columns.GridColumn colBankKtoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPCKtoNr;
        private KiSS4.Gui.KissButtonEdit edtBank;
        private KiSS4.DB.SqlQuery qryFbKreditor;
        private KiSS4.DB.SqlQuery qryFbZahlungsweg;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblZusatz;
        private KiSS4.Gui.KissLabel lblStrasse;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissCheckEdit chkBxActiv;
        private KiSS4.Gui.KissLabel lblAktiv;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissTextEdit edtBankKontoNr;
        private KiSS4.Gui.KissTextEdit edtPostKontoNr;
        private KiSS4.Gui.KissLookUpEdit edtZahlungsArt;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colAufwandKonto;
        private KiSS4.Gui.KissIntEdit edtZahlungsFrist;
        private KiSS4.Gui.KissLabel lblZahlungsfrist;
        private KiSS4.Gui.KissLabel lblBank;
        private KiSS4.Gui.KissLabel lblPostKontoNr;
        private KiSS4.Gui.KissLabel lblBankKontoNr;
        private KiSS4.Gui.KissTextEdit editZusatz;
        private KiSS4.Gui.KissTextEdit editStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colFinanziellinstitution;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungsArt;
        private KiSS4.Common.KissPLZOrt kissPLZOrt1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private KiSS4.Gui.KissCheckEdit editSearchAktiv;
        private KiSS4.Gui.KissTextEdit editSearchStrasse;
        private KiSS4.Gui.KissTextEdit editSearchName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private KiSS4.Gui.KissButtonEdit editAufwandKonto;
        private KiSS4.Gui.KissTextEdit editAufwandKontoName;
        private KiSS4.Gui.KissCalcEdit editSearchAufwandKonto;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KiSS4.Gui.KissCheckEdit IsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv2;
        private KiSS4.Gui.KissLabel kissLabel15;
        private System.Windows.Forms.Label label6;

        # endregion

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuKreditor));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFbKreditor = new KiSS4.DB.SqlQuery(this.components);
            this.editName = new KiSS4.Gui.KissButtonEdit();
            this.tabControlSearch = new KiSS4.Gui.KissTabControlEx();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdFbKreditor = new KiSS4.Gui.KissGrid();
            this.grvFbKreditor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufwandKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLetzteBuchung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.editSearchOrt = new KiSS4.Gui.KissTextEdit();
            this.lblStichtag = new System.Windows.Forms.Label();
            this.edtStichtag = new KiSS4.Gui.KissDateEdit();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.editSearchAufwandKonto = new KiSS4.Gui.KissCalcEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.editSearchAktiv = new KiSS4.Gui.KissCheckEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.editSearchPlz = new KiSS4.Gui.KissTextEdit();
            this.editSearchStrasse = new KiSS4.Gui.KissTextEdit();
            this.editSearchName = new KiSS4.Gui.KissTextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtIBANErrorMsg = new KiSS4.Gui.KissMemoEdit();
            this.edtIBAN = new KiSS4.Gui.KissTextEdit();
            this.qryFbZahlungsweg = new KiSS4.DB.SqlQuery(this.components);
            this.lblIBAN = new KiSS4.Gui.KissLabel();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.IsActive = new KiSS4.Gui.KissCheckEdit();
            this.edtZahlungsFrist = new KiSS4.Gui.KissIntEdit();
            this.lblZahlungsfrist = new KiSS4.Gui.KissLabel();
            this.edtZahlungsArt = new KiSS4.Gui.KissLookUpEdit();
            this.edtBankKontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtPostKontoNr = new KiSS4.Gui.KissTextEdit();
            this.lblBankKontoNr = new KiSS4.Gui.KissLabel();
            this.lblBank = new KiSS4.Gui.KissLabel();
            this.lblPostKontoNr = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.edtBank = new KiSS4.Gui.KissButtonEdit();
            this.grdFbZahlungsweg = new KiSS4.Gui.KissGrid();
            this.grvFbZahlungsweg = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colZahlungsArt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinanziellinstitution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankKtoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCKtoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblZusatz = new KiSS4.Gui.KissLabel();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.chkBxActiv = new KiSS4.Gui.KissCheckEdit();
            this.lblAktiv = new KiSS4.Gui.KissLabel();
            this.editZusatz = new KiSS4.Gui.KissTextEdit();
            this.editStrasse = new KiSS4.Gui.KissTextEdit();
            this.kissPLZOrt1 = new KiSS4.Common.KissPLZOrt();
            this.editAufwandKonto = new KiSS4.Gui.KissButtonEdit();
            this.editAufwandKontoName = new KiSS4.Gui.KissTextEdit();
            this.btnAlleKreditorenDeaktivieren = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.tpgSuchen.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editSearchOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSearchAufwandKonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSearchAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSearchPlz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSearchStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSearchName.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBANErrorMsg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBAN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIBAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsFrist.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsfrist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsArt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBxActiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufwandKonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufwandKontoName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryFbKreditor
            // 
            this.qryFbKreditor.CanDelete = true;
            this.qryFbKreditor.CanInsert = true;
            this.qryFbKreditor.CanUpdate = true;
            this.qryFbKreditor.HostControl = this;
            this.qryFbKreditor.TableName = "FbKreditor";
            this.qryFbKreditor.AfterFill += new System.EventHandler(this.qryKreditor_AfterFill);
            this.qryFbKreditor.AfterInsert += new System.EventHandler(this.qryKreditor_AfterInsert);
            this.qryFbKreditor.AfterPost += new System.EventHandler(this.qryFbKreditor_AfterPost);
            this.qryFbKreditor.BeforePost += new System.EventHandler(this.qryKreditor_BeforePost);
            this.qryFbKreditor.PositionChanged += new System.EventHandler(this.qryFbKreditor_PositionChanged);
            // 
            // editName
            // 
            this.editName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editName.DataMember = "Name";
            this.editName.DataSource = this.qryFbKreditor;
            this.editName.Location = new System.Drawing.Point(102, 454);
            this.editName.Name = "editName";
            this.editName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editName.Properties.Appearance.Options.UseBackColor = true;
            this.editName.Properties.Appearance.Options.UseBorderColor = true;
            this.editName.Properties.Appearance.Options.UseFont = true;
            this.editName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editName.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editName.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editName.Size = new System.Drawing.Size(300, 24);
            this.editName.TabIndex = 2;
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Controls.Add(this.tpgListe);
            this.tabControlSearch.Controls.Add(this.tpgSuchen);
            this.tabControlSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlSearch.Location = new System.Drawing.Point(5, 5);
            this.tabControlSearch.Name = "tabControlSearch";
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.ShowFixedWidthTooltip = true;
            this.tabControlSearch.Size = new System.Drawing.Size(445, 443);
            this.tabControlSearch.TabIndex = 0;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
            this.tabControlSearch.TabsLineColor = System.Drawing.Color.Black;
            this.tabControlSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControlSearch.TabStop = false;
            this.tabControlSearch.Enter += new System.EventHandler(this.xTabControl1_Enter);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdFbKreditor);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(433, 405);
            this.tpgListe.TabIndex = 0;
            this.tpgListe.Title = "Liste";
            // 
            // grdFbKreditor
            // 
            this.grdFbKreditor.DataSource = this.qryFbKreditor;
            this.grdFbKreditor.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdFbKreditor.EmbeddedNavigator.Name = "";
            this.grdFbKreditor.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFbKreditor.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbKreditor.Location = new System.Drawing.Point(0, 0);
            this.grdFbKreditor.MainView = this.grvFbKreditor;
            this.grdFbKreditor.Name = "grdFbKreditor";
            this.grdFbKreditor.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdFbKreditor.Size = new System.Drawing.Size(433, 405);
            this.grdFbKreditor.TabIndex = 0;
            this.grdFbKreditor.TabStop = false;
            this.grdFbKreditor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbKreditor});
            // 
            // grvFbKreditor
            // 
            this.grvFbKreditor.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbKreditor.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.Empty.Options.UseFont = true;
            this.grvFbKreditor.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFbKreditor.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbKreditor.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFbKreditor.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbKreditor.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbKreditor.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbKreditor.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFbKreditor.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbKreditor.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbKreditor.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbKreditor.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFbKreditor.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbKreditor.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbKreditor.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbKreditor.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbKreditor.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbKreditor.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbKreditor.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbKreditor.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbKreditor.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbKreditor.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbKreditor.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFbKreditor.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbKreditor.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbKreditor.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbKreditor.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbKreditor.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.OddRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbKreditor.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.Row.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.Row.Options.UseFont = true;
            this.grvFbKreditor.Appearance.RowSeparator.BackColor = System.Drawing.Color.Firebrick;
            this.grvFbKreditor.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvFbKreditor.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbKreditor.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbKreditor.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbKreditor.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbKreditor.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbKreditor.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbKreditor.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbKreditor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbKreditor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colPLZ,
            this.colOrt,
            this.colAktiv,
            this.colAufwandKonto,
            this.colLetzteBuchung});
            this.grvFbKreditor.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFbKreditor.GridControl = this.grdFbKreditor;
            this.grvFbKreditor.Name = "grvFbKreditor";
            this.grvFbKreditor.OptionsBehavior.Editable = false;
            this.grvFbKreditor.OptionsCustomization.AllowFilter = false;
            this.grvFbKreditor.OptionsFilter.AllowFilterEditor = false;
            this.grvFbKreditor.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbKreditor.OptionsMenu.EnableColumnMenu = false;
            this.grvFbKreditor.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbKreditor.OptionsNavigation.UseTabKey = false;
            this.grvFbKreditor.OptionsView.ColumnAutoWidth = false;
            this.grvFbKreditor.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbKreditor.OptionsView.ShowGroupPanel = false;
            this.grvFbKreditor.OptionsView.ShowIndicator = false;
            this.grvFbKreditor.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvFbKreditor_CellValueChanged);
            this.grvFbKreditor.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvFbKreditor_CellValueChanging);
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 211;
            // 
            // colPLZ
            // 
            this.colPLZ.Caption = "PLZ";
            this.colPLZ.FieldName = "PLZ";
            this.colPLZ.Name = "colPLZ";
            this.colPLZ.OptionsColumn.AllowEdit = false;
            this.colPLZ.Visible = true;
            this.colPLZ.VisibleIndex = 1;
            this.colPLZ.Width = 47;
            // 
            // colOrt
            // 
            this.colOrt.Caption = "Ort";
            this.colOrt.FieldName = "Ort";
            this.colOrt.Name = "colOrt";
            this.colOrt.OptionsColumn.AllowEdit = false;
            this.colOrt.Visible = true;
            this.colOrt.VisibleIndex = 2;
            this.colOrt.Width = 120;
            // 
            // colAktiv
            // 
            this.colAktiv.Caption = "Aktiv";
            this.colAktiv.FieldName = "Aktiv";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 3;
            this.colAktiv.Width = 40;
            // 
            // colAufwandKonto
            // 
            this.colAufwandKonto.Caption = "Aufwandkonto";
            this.colAufwandKonto.FieldName = "AufwandKonto";
            this.colAufwandKonto.Name = "colAufwandKonto";
            this.colAufwandKonto.OptionsColumn.AllowEdit = false;
            // 
            // colLetzteBuchung
            // 
            this.colLetzteBuchung.Caption = "Letzte Buchung";
            this.colLetzteBuchung.FieldName = "Buchungsdatum";
            this.colLetzteBuchung.Name = "colLetzteBuchung";
            this.colLetzteBuchung.OptionsColumn.AllowEdit = false;
            this.colLetzteBuchung.Width = 120;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.panel3);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(433, 405);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suchen";
            this.tpgSuchen.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panel3.Controls.Add(this.editSearchOrt);
            this.panel3.Controls.Add(this.lblStichtag);
            this.panel3.Controls.Add(this.edtStichtag);
            this.panel3.Controls.Add(this.kissSearchTitel1);
            this.panel3.Controls.Add(this.editSearchAufwandKonto);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.editSearchAktiv);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.editSearchPlz);
            this.panel3.Controls.Add(this.editSearchStrasse);
            this.panel3.Controls.Add(this.editSearchName);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(433, 405);
            this.panel3.TabIndex = 20;
            // 
            // editSearchOrt
            // 
            this.editSearchOrt.EditValue = "";
            this.editSearchOrt.Location = new System.Drawing.Point(243, 89);
            this.editSearchOrt.Name = "editSearchOrt";
            this.editSearchOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editSearchOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSearchOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSearchOrt.Properties.Appearance.Options.UseBackColor = true;
            this.editSearchOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.editSearchOrt.Properties.Appearance.Options.UseFont = true;
            this.editSearchOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editSearchOrt.Size = new System.Drawing.Size(180, 24);
            this.editSearchOrt.TabIndex = 7;
            // 
            // lblStichtag
            // 
            this.lblStichtag.Location = new System.Drawing.Point(6, 149);
            this.lblStichtag.Name = "lblStichtag";
            this.lblStichtag.Size = new System.Drawing.Size(146, 24);
            this.lblStichtag.TabIndex = 10;
            this.lblStichtag.Text = "Stichtag letzte Buchung";
            // 
            // edtStichtag
            // 
            this.edtStichtag.EditValue = null;
            this.edtStichtag.Location = new System.Drawing.Point(158, 149);
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
            this.edtStichtag.TabIndex = 11;
            // 
            // kissSearchTitel1
            // 
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(10, 1);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 0;
            // 
            // editSearchAufwandKonto
            // 
            this.editSearchAufwandKonto.Location = new System.Drawing.Point(158, 119);
            this.editSearchAufwandKonto.Name = "editSearchAufwandKonto";
            this.editSearchAufwandKonto.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editSearchAufwandKonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editSearchAufwandKonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSearchAufwandKonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSearchAufwandKonto.Properties.Appearance.Options.UseBackColor = true;
            this.editSearchAufwandKonto.Properties.Appearance.Options.UseBorderColor = true;
            this.editSearchAufwandKonto.Properties.Appearance.Options.UseFont = true;
            this.editSearchAufwandKonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editSearchAufwandKonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editSearchAufwandKonto.Size = new System.Drawing.Size(265, 24);
            this.editSearchAufwandKonto.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "AufwandKonto";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "Strasse";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "PLZ/Ort/Land";
            // 
            // editSearchAktiv
            // 
            this.editSearchAktiv.EditValue = true;
            this.editSearchAktiv.Location = new System.Drawing.Point(158, 179);
            this.editSearchAktiv.Name = "editSearchAktiv";
            this.editSearchAktiv.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editSearchAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.editSearchAktiv.Properties.Caption = "";
            this.editSearchAktiv.Size = new System.Drawing.Size(18, 19);
            this.editSearchAktiv.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Aktiv";
            // 
            // editSearchPlz
            // 
            this.editSearchPlz.EditValue = "";
            this.editSearchPlz.Location = new System.Drawing.Point(158, 89);
            this.editSearchPlz.Name = "editSearchPlz";
            this.editSearchPlz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editSearchPlz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSearchPlz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSearchPlz.Properties.Appearance.Options.UseBackColor = true;
            this.editSearchPlz.Properties.Appearance.Options.UseBorderColor = true;
            this.editSearchPlz.Properties.Appearance.Options.UseFont = true;
            this.editSearchPlz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editSearchPlz.Size = new System.Drawing.Size(79, 24);
            this.editSearchPlz.TabIndex = 6;
            // 
            // editSearchStrasse
            // 
            this.editSearchStrasse.EditValue = "";
            this.editSearchStrasse.Location = new System.Drawing.Point(158, 59);
            this.editSearchStrasse.Name = "editSearchStrasse";
            this.editSearchStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editSearchStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSearchStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSearchStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.editSearchStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.editSearchStrasse.Properties.Appearance.Options.UseFont = true;
            this.editSearchStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editSearchStrasse.Size = new System.Drawing.Size(265, 24);
            this.editSearchStrasse.TabIndex = 4;
            // 
            // editSearchName
            // 
            this.editSearchName.EditValue = "";
            this.editSearchName.Location = new System.Drawing.Point(158, 30);
            this.editSearchName.Name = "editSearchName";
            this.editSearchName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editSearchName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editSearchName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editSearchName.Properties.Appearance.Options.UseBackColor = true;
            this.editSearchName.Properties.Appearance.Options.UseBorderColor = true;
            this.editSearchName.Properties.Appearance.Options.UseFont = true;
            this.editSearchName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editSearchName.Size = new System.Drawing.Size(265, 24);
            this.editSearchName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.edtIBANErrorMsg);
            this.panel1.Controls.Add(this.edtIBAN);
            this.panel1.Controls.Add(this.lblIBAN);
            this.panel1.Controls.Add(this.kissLabel15);
            this.panel1.Controls.Add(this.IsActive);
            this.panel1.Controls.Add(this.edtZahlungsFrist);
            this.panel1.Controls.Add(this.lblZahlungsfrist);
            this.panel1.Controls.Add(this.edtZahlungsArt);
            this.panel1.Controls.Add(this.edtBankKontoNr);
            this.panel1.Controls.Add(this.edtPostKontoNr);
            this.panel1.Controls.Add(this.lblBankKontoNr);
            this.panel1.Controls.Add(this.lblBank);
            this.panel1.Controls.Add(this.lblPostKontoNr);
            this.panel1.Controls.Add(this.kissLabel7);
            this.panel1.Controls.Add(this.edtBank);
            this.panel1.Controls.Add(this.grdFbZahlungsweg);
            this.panel1.Location = new System.Drawing.Point(460, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 443);
            this.panel1.TabIndex = 14;
            this.panel1.Enter += new System.EventHandler(this.panel1_Enter);
            // 
            // edtIBANErrorMsg
            // 
            this.edtIBANErrorMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIBANErrorMsg.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIBANErrorMsg.Location = new System.Drawing.Point(-1, 204);
            this.edtIBANErrorMsg.Name = "edtIBANErrorMsg";
            this.edtIBANErrorMsg.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIBANErrorMsg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIBANErrorMsg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIBANErrorMsg.Properties.Appearance.Options.UseBackColor = true;
            this.edtIBANErrorMsg.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIBANErrorMsg.Properties.Appearance.Options.UseFont = true;
            this.edtIBANErrorMsg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIBANErrorMsg.Properties.ReadOnly = true;
            this.edtIBANErrorMsg.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.edtIBANErrorMsg.Size = new System.Drawing.Size(459, 25);
            this.edtIBANErrorMsg.TabIndex = 1;
            this.edtIBANErrorMsg.TabStop = false;
            this.edtIBANErrorMsg.Visible = false;
            // 
            // edtIBAN
            // 
            this.edtIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIBAN.DataMember = "IBAN";
            this.edtIBAN.DataSource = this.qryFbZahlungsweg;
            this.edtIBAN.Location = new System.Drawing.Point(105, 291);
            this.edtIBAN.Name = "edtIBAN";
            this.edtIBAN.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIBAN.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIBAN.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIBAN.Properties.Appearance.Options.UseBackColor = true;
            this.edtIBAN.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIBAN.Properties.Appearance.Options.UseFont = true;
            this.edtIBAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIBAN.Properties.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.editPostKontoNr_Properties_ParseEditValue);
            this.edtIBAN.Properties.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.editPostKontoNr_Properties_FormatEditValue);
            this.edtIBAN.Size = new System.Drawing.Size(260, 24);
            this.edtIBAN.TabIndex = 7;
            // 
            // qryFbZahlungsweg
            // 
            this.qryFbZahlungsweg.CanDelete = true;
            this.qryFbZahlungsweg.CanInsert = true;
            this.qryFbZahlungsweg.CanUpdate = true;
            this.qryFbZahlungsweg.HostControl = this;
            this.qryFbZahlungsweg.TableName = "FbZahlungsWeg";
            this.qryFbZahlungsweg.AfterInsert += new System.EventHandler(this.qryZahlungsweg_AfterInsert);
            this.qryFbZahlungsweg.BeforePost += new System.EventHandler(this.qryZahlungsweg_BeforePost);
            this.qryFbZahlungsweg.PositionChanged += new System.EventHandler(this.qryFbZahlungsweg_PositionChanged);
            // 
            // lblIBAN
            // 
            this.lblIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIBAN.Location = new System.Drawing.Point(17, 289);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(70, 24);
            this.lblIBAN.TabIndex = 6;
            this.lblIBAN.Text = "IBAN";
            // 
            // kissLabel15
            // 
            this.kissLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kissLabel15.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel15.Location = new System.Drawing.Point(17, 408);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(355, 25);
            this.kissLabel15.TabIndex = 15;
            this.kissLabel15.Text = "(um einen neuen Zahlungsweg zu erfassen/löschen: zuerst in diesen Bereich wechsel" +
    "n, zB. mit einem Mausklick, dann F5/F8)";
            // 
            // IsActive
            // 
            this.IsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IsActive.DataMember = "IsActive";
            this.IsActive.DataSource = this.qryFbZahlungsweg;
            this.IsActive.Location = new System.Drawing.Point(302, 385);
            this.IsActive.Name = "IsActive";
            this.IsActive.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.IsActive.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsActive.Properties.Appearance.Options.UseBackColor = true;
            this.IsActive.Properties.Appearance.Options.UseFont = true;
            this.IsActive.Properties.Caption = "Aktiv";
            this.IsActive.Size = new System.Drawing.Size(63, 19);
            this.IsActive.TabIndex = 14;
            // 
            // edtZahlungsFrist
            // 
            this.edtZahlungsFrist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZahlungsFrist.DataMember = "ZahlungsFrist";
            this.edtZahlungsFrist.DataSource = this.qryFbZahlungsweg;
            this.edtZahlungsFrist.Location = new System.Drawing.Point(105, 382);
            this.edtZahlungsFrist.Name = "edtZahlungsFrist";
            this.edtZahlungsFrist.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZahlungsFrist.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZahlungsFrist.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungsFrist.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsFrist.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungsFrist.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungsFrist.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungsFrist.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZahlungsFrist.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZahlungsFrist.Properties.DisplayFormat.FormatString = "################################";
            this.edtZahlungsFrist.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtZahlungsFrist.Properties.EditFormat.FormatString = "################################";
            this.edtZahlungsFrist.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtZahlungsFrist.Properties.Mask.EditMask = "################################";
            this.edtZahlungsFrist.Size = new System.Drawing.Size(191, 24);
            this.edtZahlungsFrist.TabIndex = 13;
            // 
            // lblZahlungsfrist
            // 
            this.lblZahlungsfrist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZahlungsfrist.Location = new System.Drawing.Point(17, 382);
            this.lblZahlungsfrist.Name = "lblZahlungsfrist";
            this.lblZahlungsfrist.Size = new System.Drawing.Size(70, 24);
            this.lblZahlungsfrist.TabIndex = 12;
            this.lblZahlungsfrist.Text = "Zahlungsfrist";
            // 
            // edtZahlungsArt
            // 
            this.edtZahlungsArt.AllowNull = false;
            this.edtZahlungsArt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZahlungsArt.DataMember = "ZahlungsArtCode";
            this.edtZahlungsArt.DataSource = this.qryFbZahlungsweg;
            this.edtZahlungsArt.Location = new System.Drawing.Point(105, 232);
            this.edtZahlungsArt.LOVName = "FbZahlungsArtCode";
            this.edtZahlungsArt.Name = "edtZahlungsArt";
            this.edtZahlungsArt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZahlungsArt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungsArt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsArt.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungsArt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungsArt.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungsArt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZahlungsArt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsArt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZahlungsArt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZahlungsArt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZahlungsArt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZahlungsArt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZahlungsArt.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Typ")});
            this.edtZahlungsArt.Properties.NullText = "";
            this.edtZahlungsArt.Properties.ShowFooter = false;
            this.edtZahlungsArt.Properties.ShowHeader = false;
            this.edtZahlungsArt.Size = new System.Drawing.Size(260, 24);
            this.edtZahlungsArt.TabIndex = 3;
            this.edtZahlungsArt.EditValueChanged += new System.EventHandler(this.edtZahlungsArt_EditValueChanged);
            // 
            // edtBankKontoNr
            // 
            this.edtBankKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBankKontoNr.DataMember = "BankKontoNr";
            this.edtBankKontoNr.DataSource = this.qryFbZahlungsweg;
            this.edtBankKontoNr.Location = new System.Drawing.Point(105, 351);
            this.edtBankKontoNr.Name = "edtBankKontoNr";
            this.edtBankKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBankKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtBankKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBankKontoNr.Size = new System.Drawing.Size(260, 24);
            this.edtBankKontoNr.TabIndex = 11;
            // 
            // edtPostKontoNr
            // 
            this.edtPostKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPostKontoNr.DataMember = "PCKontoNr";
            this.edtPostKontoNr.DataSource = this.qryFbZahlungsweg;
            this.edtPostKontoNr.Location = new System.Drawing.Point(105, 321);
            this.edtPostKontoNr.Name = "edtPostKontoNr";
            this.edtPostKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPostKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtPostKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostKontoNr.Properties.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.editPostKontoNr_Properties_ParseEditValue);
            this.edtPostKontoNr.Properties.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.editPostKontoNr_Properties_FormatEditValue);
            this.edtPostKontoNr.Size = new System.Drawing.Size(260, 24);
            this.edtPostKontoNr.TabIndex = 9;
            // 
            // lblBankKontoNr
            // 
            this.lblBankKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBankKontoNr.Location = new System.Drawing.Point(17, 348);
            this.lblBankKontoNr.Name = "lblBankKontoNr";
            this.lblBankKontoNr.Size = new System.Drawing.Size(70, 24);
            this.lblBankKontoNr.TabIndex = 10;
            this.lblBankKontoNr.Text = "BankKontoNr";
            // 
            // lblBank
            // 
            this.lblBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBank.Location = new System.Drawing.Point(17, 261);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(60, 24);
            this.lblBank.TabIndex = 4;
            this.lblBank.Text = "Bank";
            // 
            // lblPostKontoNr
            // 
            this.lblPostKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPostKontoNr.Location = new System.Drawing.Point(17, 319);
            this.lblPostKontoNr.Name = "lblPostKontoNr";
            this.lblPostKontoNr.Size = new System.Drawing.Size(70, 24);
            this.lblPostKontoNr.TabIndex = 8;
            this.lblPostKontoNr.Text = "PostkontoNr";
            // 
            // kissLabel7
            // 
            this.kissLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel7.Location = new System.Drawing.Point(17, 232);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(70, 24);
            this.kissLabel7.TabIndex = 2;
            this.kissLabel7.Text = "Zahlungsart";
            // 
            // edtBank
            // 
            this.edtBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBank.DataMember = "Finanzinstitut";
            this.edtBank.DataSource = this.qryFbZahlungsweg;
            this.edtBank.Location = new System.Drawing.Point(105, 262);
            this.edtBank.Name = "edtBank";
            this.edtBank.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBank.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBank.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBank.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.edtBank.Properties.Appearance.Options.UseBackColor = true;
            this.edtBank.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBank.Properties.Appearance.Options.UseFont = true;
            this.edtBank.Properties.Appearance.Options.UseForeColor = true;
            this.edtBank.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBank.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBank.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBank.Size = new System.Drawing.Size(260, 24);
            this.edtBank.TabIndex = 5;
            this.edtBank.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBank_UserModifiedFld);
            // 
            // grdFbZahlungsweg
            // 
            this.grdFbZahlungsweg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdFbZahlungsweg.DataSource = this.qryFbZahlungsweg;
            // 
            // 
            // 
            this.grdFbZahlungsweg.EmbeddedNavigator.Name = "";
            this.grdFbZahlungsweg.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFbZahlungsweg.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbZahlungsweg.Location = new System.Drawing.Point(0, 0);
            this.grdFbZahlungsweg.MainView = this.grvFbZahlungsweg;
            this.grdFbZahlungsweg.Name = "grdFbZahlungsweg";
            this.grdFbZahlungsweg.Size = new System.Drawing.Size(458, 207);
            this.grdFbZahlungsweg.TabIndex = 0;
            this.grdFbZahlungsweg.TabStop = false;
            this.grdFbZahlungsweg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbZahlungsweg});
            // 
            // grvFbZahlungsweg
            // 
            this.grvFbZahlungsweg.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbZahlungsweg.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.Empty.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFbZahlungsweg.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbZahlungsweg.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFbZahlungsweg.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbZahlungsweg.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbZahlungsweg.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFbZahlungsweg.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbZahlungsweg.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbZahlungsweg.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbZahlungsweg.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFbZahlungsweg.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbZahlungsweg.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbZahlungsweg.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbZahlungsweg.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbZahlungsweg.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbZahlungsweg.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbZahlungsweg.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbZahlungsweg.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbZahlungsweg.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbZahlungsweg.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbZahlungsweg.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbZahlungsweg.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbZahlungsweg.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.OddRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbZahlungsweg.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.Row.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.Row.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.RowSeparator.BackColor = System.Drawing.Color.Firebrick;
            this.grvFbZahlungsweg.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvFbZahlungsweg.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbZahlungsweg.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbZahlungsweg.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbZahlungsweg.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbZahlungsweg.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbZahlungsweg.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbZahlungsweg.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbZahlungsweg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbZahlungsweg.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colZahlungsArt,
            this.colFinanziellinstitution,
            this.colBankKtoNr,
            this.colPCKtoNr,
            this.colAktiv2});
            this.grvFbZahlungsweg.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFbZahlungsweg.GridControl = this.grdFbZahlungsweg;
            this.grvFbZahlungsweg.Name = "grvFbZahlungsweg";
            this.grvFbZahlungsweg.OptionsBehavior.Editable = false;
            this.grvFbZahlungsweg.OptionsCustomization.AllowFilter = false;
            this.grvFbZahlungsweg.OptionsFilter.AllowFilterEditor = false;
            this.grvFbZahlungsweg.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbZahlungsweg.OptionsMenu.EnableColumnMenu = false;
            this.grvFbZahlungsweg.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbZahlungsweg.OptionsNavigation.UseTabKey = false;
            this.grvFbZahlungsweg.OptionsView.ColumnAutoWidth = false;
            this.grvFbZahlungsweg.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbZahlungsweg.OptionsView.ShowGroupPanel = false;
            this.grvFbZahlungsweg.OptionsView.ShowIndicator = false;
            // 
            // colZahlungsArt
            // 
            this.colZahlungsArt.Caption = "Zahlungsart";
            this.colZahlungsArt.FieldName = "ZahlungsArtCode";
            this.colZahlungsArt.Name = "colZahlungsArt";
            this.colZahlungsArt.Visible = true;
            this.colZahlungsArt.VisibleIndex = 0;
            this.colZahlungsArt.Width = 101;
            // 
            // colFinanziellinstitution
            // 
            this.colFinanziellinstitution.Caption = "Finanzinstitut";
            this.colFinanziellinstitution.FieldName = "Finanzinstitut";
            this.colFinanziellinstitution.Name = "colFinanziellinstitution";
            this.colFinanziellinstitution.Visible = true;
            this.colFinanziellinstitution.VisibleIndex = 1;
            this.colFinanziellinstitution.Width = 136;
            // 
            // colBankKtoNr
            // 
            this.colBankKtoNr.Caption = "Bank-KtoNr.";
            this.colBankKtoNr.FieldName = "BankKontoNr";
            this.colBankKtoNr.Name = "colBankKtoNr";
            this.colBankKtoNr.Visible = true;
            this.colBankKtoNr.VisibleIndex = 2;
            this.colBankKtoNr.Width = 78;
            // 
            // colPCKtoNr
            // 
            this.colPCKtoNr.Caption = "PC-KtoNr";
            this.colPCKtoNr.FieldName = "PCKontoNr";
            this.colPCKtoNr.Name = "colPCKtoNr";
            this.colPCKtoNr.Visible = true;
            this.colPCKtoNr.VisibleIndex = 3;
            this.colPCKtoNr.Width = 81;
            // 
            // colAktiv2
            // 
            this.colAktiv2.Caption = "Aktiv";
            this.colAktiv2.FieldName = "IsActive";
            this.colAktiv2.Name = "colAktiv2";
            this.colAktiv2.Visible = true;
            this.colAktiv2.VisibleIndex = 4;
            this.colAktiv2.Width = 40;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.Location = new System.Drawing.Point(9, 454);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(90, 24);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblZusatz
            // 
            this.lblZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZusatz.Location = new System.Drawing.Point(9, 484);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(90, 24);
            this.lblZusatz.TabIndex = 3;
            this.lblZusatz.Text = "Zusatz";
            // 
            // lblStrasse
            // 
            this.lblStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrasse.Location = new System.Drawing.Point(9, 514);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(90, 24);
            this.lblStrasse.TabIndex = 5;
            this.lblStrasse.Text = "Strasse";
            // 
            // kissLabel5
            // 
            this.kissLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel5.Location = new System.Drawing.Point(9, 544);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(90, 24);
            this.kissLabel5.TabIndex = 7;
            this.kissLabel5.Text = "PLZ/Ort/Land";
            // 
            // kissLabel6
            // 
            this.kissLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel6.Location = new System.Drawing.Point(457, 454);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(85, 24);
            this.kissLabel6.TabIndex = 9;
            this.kissLabel6.Text = "Aufwand Konto";
            // 
            // chkBxActiv
            // 
            this.chkBxActiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBxActiv.DataMember = "Aktiv";
            this.chkBxActiv.DataSource = this.qryFbKreditor;
            this.chkBxActiv.Location = new System.Drawing.Point(566, 488);
            this.chkBxActiv.Name = "chkBxActiv";
            this.chkBxActiv.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkBxActiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkBxActiv.Properties.Caption = "";
            this.chkBxActiv.Size = new System.Drawing.Size(250, 19);
            this.chkBxActiv.TabIndex = 13;
            // 
            // lblAktiv
            // 
            this.lblAktiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAktiv.Location = new System.Drawing.Point(457, 484);
            this.lblAktiv.Name = "lblAktiv";
            this.lblAktiv.Size = new System.Drawing.Size(85, 24);
            this.lblAktiv.TabIndex = 12;
            this.lblAktiv.Text = "Aktiv";
            // 
            // editZusatz
            // 
            this.editZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editZusatz.DataMember = "Zusatz";
            this.editZusatz.DataSource = this.qryFbKreditor;
            this.editZusatz.Location = new System.Drawing.Point(102, 484);
            this.editZusatz.Name = "editZusatz";
            this.editZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.editZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.editZusatz.Properties.Appearance.Options.UseFont = true;
            this.editZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editZusatz.Size = new System.Drawing.Size(300, 24);
            this.editZusatz.TabIndex = 4;
            // 
            // editStrasse
            // 
            this.editStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editStrasse.DataMember = "Strasse";
            this.editStrasse.DataSource = this.qryFbKreditor;
            this.editStrasse.Location = new System.Drawing.Point(102, 514);
            this.editStrasse.Name = "editStrasse";
            this.editStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.editStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.editStrasse.Properties.Appearance.Options.UseFont = true;
            this.editStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editStrasse.Size = new System.Drawing.Size(300, 24);
            this.editStrasse.TabIndex = 6;
            // 
            // kissPLZOrt1
            // 
            this.kissPLZOrt1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissPLZOrt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissPLZOrt1.DataMemberBaGemeindeID = null;
            this.kissPLZOrt1.DataSource = this.qryFbKreditor;
            this.kissPLZOrt1.Location = new System.Drawing.Point(102, 544);
            this.kissPLZOrt1.Name = "kissPLZOrt1";
            this.kissPLZOrt1.ShowKanton = false;
            this.kissPLZOrt1.Size = new System.Drawing.Size(300, 48);
            this.kissPLZOrt1.TabIndex = 8;
            // 
            // editAufwandKonto
            // 
            this.editAufwandKonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editAufwandKonto.DataMember = "AufwandKonto";
            this.editAufwandKonto.DataSource = this.qryFbKreditor;
            this.editAufwandKonto.Location = new System.Drawing.Point(566, 454);
            this.editAufwandKonto.Name = "editAufwandKonto";
            this.editAufwandKonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editAufwandKonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAufwandKonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAufwandKonto.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editAufwandKonto.Properties.Appearance.Options.UseBackColor = true;
            this.editAufwandKonto.Properties.Appearance.Options.UseBorderColor = true;
            this.editAufwandKonto.Properties.Appearance.Options.UseFont = true;
            this.editAufwandKonto.Properties.Appearance.Options.UseForeColor = true;
            this.editAufwandKonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editAufwandKonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editAufwandKonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editAufwandKonto.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editAufwandKonto.Size = new System.Drawing.Size(92, 24);
            this.editAufwandKonto.TabIndex = 10;
            this.editAufwandKonto.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editAufwandKonto_UserModifiedFld);
            // 
            // editAufwandKontoName
            // 
            this.editAufwandKontoName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editAufwandKontoName.DataMember = "AufwandKontoName";
            this.editAufwandKontoName.DataSource = this.qryFbKreditor;
            this.editAufwandKontoName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.editAufwandKontoName.Location = new System.Drawing.Point(663, 454);
            this.editAufwandKontoName.Name = "editAufwandKontoName";
            this.editAufwandKontoName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.editAufwandKontoName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editAufwandKontoName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editAufwandKontoName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.editAufwandKontoName.Properties.Appearance.Options.UseBackColor = true;
            this.editAufwandKontoName.Properties.Appearance.Options.UseBorderColor = true;
            this.editAufwandKontoName.Properties.Appearance.Options.UseFont = true;
            this.editAufwandKontoName.Properties.Appearance.Options.UseForeColor = true;
            this.editAufwandKontoName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editAufwandKontoName.Properties.ReadOnly = true;
            this.editAufwandKontoName.Size = new System.Drawing.Size(215, 24);
            this.editAufwandKontoName.TabIndex = 11;
            this.editAufwandKontoName.TabStop = false;
            // 
            // btnAlleKreditorenDeaktivieren
            // 
            this.btnAlleKreditorenDeaktivieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAlleKreditorenDeaktivieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlleKreditorenDeaktivieren.Location = new System.Drawing.Point(236, 424);
            this.btnAlleKreditorenDeaktivieren.Name = "btnAlleKreditorenDeaktivieren";
            this.btnAlleKreditorenDeaktivieren.Size = new System.Drawing.Size(166, 24);
            this.btnAlleKreditorenDeaktivieren.TabIndex = 15;
            this.btnAlleKreditorenDeaktivieren.Text = "Alle Kreditoren deaktivieren";
            this.btnAlleKreditorenDeaktivieren.UseVisualStyleBackColor = false;
            this.btnAlleKreditorenDeaktivieren.Visible = false;
            this.btnAlleKreditorenDeaktivieren.Click += new System.EventHandler(this.btnAlleKreditorenDeaktivieren_Click);
            // 
            // CtlFibuKreditor
            // 
            this.AutoRefresh = false;
            this.Controls.Add(this.btnAlleKreditorenDeaktivieren);
            this.Controls.Add(this.editAufwandKontoName);
            this.Controls.Add(this.editAufwandKonto);
            this.Controls.Add(this.kissPLZOrt1);
            this.Controls.Add(this.editStrasse);
            this.Controls.Add(this.editZusatz);
            this.Controls.Add(this.lblAktiv);
            this.Controls.Add(this.chkBxActiv);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.lblZusatz);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlSearch);
            this.Controls.Add(this.editName);
            this.Controls.Add(this.lblStrasse);
            this.Controls.Add(this.kissLabel6);
            this.Name = "CtlFibuKreditor";
            this.Size = new System.Drawing.Size(925, 607);
            this.Search += new System.EventHandler(this.CtlFibuKreditor_Search);
            this.Load += new System.EventHandler(this.ctlFibuBuchung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryFbKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFbKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.tpgSuchen.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editSearchOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSearchAufwandKonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSearchAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSearchPlz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSearchStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editSearchName.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtIBANErrorMsg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBAN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIBAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsFrist.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsfrist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsArt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBxActiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAktiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufwandKonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAufwandKontoName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissTextEdit edtIBAN;
        private Gui.KissLabel lblIBAN;
        private Gui.KissMemoEdit edtIBANErrorMsg;
        private DevExpress.XtraGrid.Columns.GridColumn colLetzteBuchung;
        private Label lblStichtag;
        private Gui.KissDateEdit edtStichtag;
        private Gui.KissButton btnAlleKreditorenDeaktivieren;
        private Gui.KissTextEdit editSearchOrt;
        private Gui.KissTextEdit editSearchPlz;

    }
}

