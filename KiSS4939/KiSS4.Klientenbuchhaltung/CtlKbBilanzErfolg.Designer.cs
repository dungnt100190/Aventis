using System;

namespace KiSS4.Klientenbuchhaltung
{
    partial class CtlKbBilanzErfolg
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colEroeffnungsSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colKlasse;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoName;
        private DevExpress.XtraGrid.Columns.GridColumn colKtoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalZeile;
        private DevExpress.XtraGrid.Columns.GridColumn colUmsatz;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.CheckBox edtNurMitBuchungen;
        private KiSS4.Gui.KissDateEdit edtPerDatum;
        private KiSS4.Gui.KissGrid grdBilanz;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBilanz;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel lblMandant;
        private KiSS4.DB.SqlQuery qryBilanz;
        private KiSS4.DB.SqlQuery qryPeriodeX;
        private KiSS4.DB.SqlQuery sqlQuery1;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grdBilanz = new KiSS4.Gui.KissGrid();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.edtPerDatum = new KiSS4.Gui.KissDateEdit();
            this.edtNurMitBuchungen = new System.Windows.Forms.CheckBox();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.colEroeffnungsSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontoName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKtoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalZeile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUmsatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvBilanz = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryBilanz = new KiSS4.DB.SqlQuery(this.components);
            this.qryPeriodeX = new KiSS4.DB.SqlQuery(this.components);
            this.sqlQuery1 = new KiSS4.DB.SqlQuery(this.components);
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBilanz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBilanz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBilanz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriodeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(785, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(809, 514);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.lblMandant);
            this.tpgListe.Controls.Add(this.grdBilanz);
            this.tpgListe.Size = new System.Drawing.Size(797, 476);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.edtNurMitBuchungen);
            this.tpgSuchen.Controls.Add(this.edtPerDatum);
            this.tpgSuchen.Size = new System.Drawing.Size(797, 476);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtPerDatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurMitBuchungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            //
            // grdBilanz
            //
            this.grdBilanz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBilanz.DataSource = this.qryBilanz;
            this.grdBilanz.EmbeddedNavigator.Name = "grid.EmbeddedNavigator";
            this.grdBilanz.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBilanz.Location = new System.Drawing.Point(6, 22);
            this.grdBilanz.MainView = this.grvBilanz;
            this.grdBilanz.Name = "grdBilanz";
            this.grdBilanz.Size = new System.Drawing.Size(785, 451);
            this.grdBilanz.TabIndex = 3;
            this.grdBilanz.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvBilanz});
            //
            // lblMandant
            //
            this.lblMandant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMandant.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblMandant.Location = new System.Drawing.Point(6, 3);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(785, 16);
            this.lblMandant.TabIndex = 4;
            this.lblMandant.Text = "Mandant";
            this.lblMandant.UseCompatibleTextRendering = true;
            //
            // edtPerDatum
            //
            this.edtPerDatum.EditValue = null;
            this.edtPerDatum.Location = new System.Drawing.Point(83, 51);
            this.edtPerDatum.Name = "edtPerDatum";
            this.edtPerDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtPerDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPerDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPerDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPerDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtPerDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPerDatum.Properties.Appearance.Options.UseFont = true;
            this.edtPerDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPerDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.edtPerDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPerDatum.Properties.Name = "editPerDatum.Properties";
            this.edtPerDatum.Properties.ShowToday = false;
            this.edtPerDatum.Size = new System.Drawing.Size(100, 24);
            this.edtPerDatum.TabIndex = 1;
            //
            // edtNurMitBuchungen
            //
            this.edtNurMitBuchungen.Location = new System.Drawing.Point(83, 85);
            this.edtNurMitBuchungen.Name = "edtNurMitBuchungen";
            this.edtNurMitBuchungen.Size = new System.Drawing.Size(210, 24);
            this.edtNurMitBuchungen.TabIndex = 2;
            this.edtNurMitBuchungen.Text = "nur Konti mit Buchungen";
            this.edtNurMitBuchungen.UseCompatibleTextRendering = true;
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(4, 51);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(61, 24);
            this.kissLabel1.TabIndex = 371;
            this.kissLabel1.Text = "per Datum";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // colEroeffnungsSaldo
            //
            this.colEroeffnungsSaldo.Caption = "Eröffnung";
            this.colEroeffnungsSaldo.DisplayFormat.FormatString = "N2";
            this.colEroeffnungsSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEroeffnungsSaldo.FieldName = "EroeffnungsSaldo";
            this.colEroeffnungsSaldo.Name = "colEroeffnungsSaldo";
            this.colEroeffnungsSaldo.Visible = true;
            this.colEroeffnungsSaldo.VisibleIndex = 2;
            this.colEroeffnungsSaldo.Width = 120;
            //
            // colKlasse
            //
            this.colKlasse.Caption = "Klasse";
            this.colKlasse.FieldName = "Klasse";
            this.colKlasse.Name = "colKlasse";
            this.colKlasse.Width = 59;
            //
            // colKontoName
            //
            this.colKontoName.Caption = "Kontoname";
            this.colKontoName.FieldName = "KontoName";
            this.colKontoName.Name = "colKontoName";
            this.colKontoName.Visible = true;
            this.colKontoName.VisibleIndex = 1;
            this.colKontoName.Width = 320;
            //
            // colKtoNr
            //
            this.colKtoNr.Caption = "Kto-Nr.";
            this.colKtoNr.FieldName = "KontoNr";
            this.colKtoNr.Name = "colKtoNr";
            this.colKtoNr.Visible = true;
            this.colKtoNr.VisibleIndex = 0;
            this.colKtoNr.Width = 80;
            //
            // colSaldo
            //
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "N2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 4;
            this.colSaldo.Width = 120;
            //
            // colTotalZeile
            //
            this.colTotalZeile.Caption = "TotalZeile";
            this.colTotalZeile.DisplayFormat.FormatString = "N2";
            this.colTotalZeile.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalZeile.FieldName = "TotalZeile";
            this.colTotalZeile.Name = "colTotalZeile";
            //
            // colUmsatz
            //
            this.colUmsatz.Caption = "Umsatz";
            this.colUmsatz.DisplayFormat.FormatString = "N2";
            this.colUmsatz.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUmsatz.FieldName = "Umsatz";
            this.colUmsatz.Name = "colUmsatz";
            this.colUmsatz.Visible = true;
            this.colUmsatz.VisibleIndex = 3;
            this.colUmsatz.Width = 120;
            //
            // grvBilanz
            //
            this.grvBilanz.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBilanz.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBilanz.Appearance.Empty.Options.UseBackColor = true;
            this.grvBilanz.Appearance.Empty.Options.UseFont = true;
            this.grvBilanz.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBilanz.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBilanz.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBilanz.Appearance.EvenRow.Options.UseFont = true;
            this.grvBilanz.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBilanz.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBilanz.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBilanz.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBilanz.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBilanz.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBilanz.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBilanz.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBilanz.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBilanz.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBilanz.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBilanz.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBilanz.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBilanz.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBilanz.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBilanz.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBilanz.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBilanz.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBilanz.Appearance.GroupRow.Options.UseFont = true;
            this.grvBilanz.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBilanz.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBilanz.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBilanz.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBilanz.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBilanz.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBilanz.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBilanz.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBilanz.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBilanz.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBilanz.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBilanz.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBilanz.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBilanz.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBilanz.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBilanz.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBilanz.Appearance.OddRow.Options.UseFont = true;
            this.grvBilanz.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBilanz.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBilanz.Appearance.Row.Options.UseBackColor = true;
            this.grvBilanz.Appearance.Row.Options.UseFont = true;
            this.grvBilanz.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvBilanz.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBilanz.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBilanz.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBilanz.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBilanz.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBilanz.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBilanz.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBilanz.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBilanz.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colKlasse,
                        this.colKtoNr,
                        this.colKontoName,
                        this.colEroeffnungsSaldo,
                        this.colUmsatz,
                        this.colSaldo,
                        this.colTotalZeile});
            this.grvBilanz.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBilanz.GridControl = this.grdBilanz;
            this.grvBilanz.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBilanz.Name = "grvBilanz";
            this.grvBilanz.OptionsBehavior.Editable = false;
            this.grvBilanz.OptionsCustomization.AllowFilter = false;
            this.grvBilanz.OptionsFilter.AllowFilterEditor = false;
            this.grvBilanz.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBilanz.OptionsMenu.EnableColumnMenu = false;
            this.grvBilanz.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBilanz.OptionsNavigation.UseTabKey = false;
            this.grvBilanz.OptionsView.ColumnAutoWidth = false;
            this.grvBilanz.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBilanz.OptionsView.ShowGroupPanel = false;
            this.grvBilanz.OptionsView.ShowIndicator = false;
            this.grvBilanz.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvBilanz_CustomDrawCell);
            //
            // qryBilanz
            //
            this.qryBilanz.HostControl = this;
            this.qryBilanz.SelectStatement = "SELECT 1 WHERE 1 = 0";
            //
            // qryPeriodeX
            //
            this.qryPeriodeX.HostControl = this;
            //
            // sqlQuery1
            //
            this.sqlQuery1.HostControl = this;
            //
            // CtlKbBilanzErfolg
            //
            this.ActiveSQLQuery = this.qryBilanz;
            this.Name = "CtlKbBilanzErfolg";
            this.Size = new System.Drawing.Size(809, 514);
            this.Load += new System.EventHandler(this.CtlKbBilanzErfolg_Load);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBilanz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBilanz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBilanz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPeriodeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            this.ResumeLayout(false);
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
