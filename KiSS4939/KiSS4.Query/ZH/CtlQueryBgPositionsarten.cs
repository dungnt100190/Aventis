#region Header

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#endregion

using System;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public class CtlQueryBgPositionsarten : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnBeginTran;
        private KiSS4.Gui.KissButton btnCommit;
        private KiSS4.Gui.KissButton btnRollback;
        private DevExpress.XtraGrid.Columns.GridColumn colAbfolge;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahl;
        private DevExpress.XtraGrid.Columns.GridColumn colBereich;
        private DevExpress.XtraGrid.Columns.GridColumn colGruppe;
        private DevExpress.XtraGrid.Columns.GridColumn colGruppeFilter;
        private DevExpress.XtraGrid.Columns.GridColumn colKategorie;
        private DevExpress.XtraGrid.Columns.GridColumn colLA;
        private DevExpress.XtraGrid.Columns.GridColumn colLAQuoting;
        private DevExpress.XtraGrid.Columns.GridColumn colLASplitting;
        private DevExpress.XtraGrid.Columns.GridColumn colLAWV;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterbudgetgrau;
        private DevExpress.XtraGrid.Columns.GridColumn colMasterbudgetgrn;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatsbudgetgrn;
        private DevExpress.XtraGrid.Columns.GridColumn colMonstabudgetgrau;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colProPer;
        private DevExpress.XtraGrid.Columns.GridColumn colProUE;
        private DevExpress.XtraGrid.Columns.GridColumn colSD;
        private DevExpress.XtraGrid.Columns.GridColumn colSpezKto;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCHF;
        private KiSS4.Gui.KissLabel lblStatus;
        private KissButton btnBeginTran2;
        private KissButton btnRollback2;
        private KissButton btnCommit2;
        private KissLabel kissLabel1;
        private KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel lblSucheName;

        #endregion

        #region Constructors

        public CtlQueryBgPositionsarten()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBgPositionsarten));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.btnBeginTran = new KiSS4.Gui.KissButton();
            this.btnRollback = new KiSS4.Gui.KissButton();
            this.btnCommit = new KiSS4.Gui.KissButton();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.colAbfolge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBereich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGruppe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGruppeFilter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKategorie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAQuoting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLASplitting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAWV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterbudgetgrau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasterbudgetgrn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatsbudgetgrn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonstabudgetgrau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProPer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpezKto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCHF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBeginTran2 = new KiSS4.Gui.KissButton();
            this.btnRollback2 = new KiSS4.Gui.KissButton();
            this.btnCommit2 = new KiSS4.Gui.KissButton();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
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
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument �ffnen")});
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = null;
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(8, 45);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(221, 24);
            this.lblSucheName.TabIndex = 2;
            this.lblSucheName.Text = "(Diese Abfrage hat keine Suchfelder)";
            this.lblSucheName.UseCompatibleTextRendering = true;
            // 
            // btnBeginTran
            // 
            this.btnBeginTran.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBeginTran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeginTran.Location = new System.Drawing.Point(387, 476);
            this.btnBeginTran.Name = "btnBeginTran";
            this.btnBeginTran.Size = new System.Drawing.Size(90, 24);
            this.btnBeginTran.TabIndex = 3;
            this.btnBeginTran.Text = "BeginTran";
            this.btnBeginTran.UseCompatibleTextRendering = true;
            this.btnBeginTran.UseVisualStyleBackColor = true;
            this.btnBeginTran.Click += new System.EventHandler(this.btnBeginTran_Click);
            // 
            // btnRollback
            // 
            this.btnRollback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRollback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRollback.Location = new System.Drawing.Point(483, 476);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(90, 24);
            this.btnRollback.TabIndex = 4;
            this.btnRollback.Text = "Rollback";
            this.btnRollback.UseCompatibleTextRendering = true;
            this.btnRollback.UseVisualStyleBackColor = true;
            this.btnRollback.Click += new System.EventHandler(this.btnRollback_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommit.Location = new System.Drawing.Point(579, 476);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(90, 24);
            this.btnCommit.TabIndex = 5;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseCompatibleTextRendering = true;
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.Location = new System.Drawing.Point(675, 476);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 24);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Transaktion: ?";
            this.lblStatus.UseCompatibleTextRendering = true;
            // 
            // colAbfolge
            // 
            this.colAbfolge.Name = "colAbfolge";
            // 
            // colAnzahl
            // 
            this.colAnzahl.Name = "colAnzahl";
            // 
            // colBereich
            // 
            this.colBereich.Name = "colBereich";
            // 
            // colGruppe
            // 
            this.colGruppe.Name = "colGruppe";
            // 
            // colGruppeFilter
            // 
            this.colGruppeFilter.Name = "colGruppeFilter";
            // 
            // colKategorie
            // 
            this.colKategorie.Name = "colKategorie";
            // 
            // colLA
            // 
            this.colLA.Name = "colLA";
            // 
            // colLAQuoting
            // 
            this.colLAQuoting.Name = "colLAQuoting";
            // 
            // colLASplitting
            // 
            this.colLASplitting.Name = "colLASplitting";
            // 
            // colLAWV
            // 
            this.colLAWV.Name = "colLAWV";
            // 
            // colMasterbudgetgrau
            // 
            this.colMasterbudgetgrau.Name = "colMasterbudgetgrau";
            // 
            // colMasterbudgetgrn
            // 
            this.colMasterbudgetgrn.Name = "colMasterbudgetgrn";
            // 
            // colMonatsbudgetgrn
            // 
            this.colMonatsbudgetgrn.Name = "colMonatsbudgetgrn";
            // 
            // colMonstabudgetgrau
            // 
            this.colMonstabudgetgrau.Name = "colMonstabudgetgrau";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colProPer
            // 
            this.colProPer.Name = "colProPer";
            // 
            // colProUE
            // 
            this.colProUE.Name = "colProUE";
            // 
            // colSD
            // 
            this.colSD.Name = "colSD";
            // 
            // colSpezKto
            // 
            this.colSpezKto.Name = "colSpezKto";
            // 
            // colTotalCHF
            // 
            this.colTotalCHF.Name = "colTotalCHF";
            // 
            // btnBeginTran2
            // 
            this.btnBeginTran2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeginTran2.Location = new System.Drawing.Point(330, 9);
            this.btnBeginTran2.Name = "btnBeginTran2";
            this.btnBeginTran2.Size = new System.Drawing.Size(90, 24);
            this.btnBeginTran2.TabIndex = 7;
            this.btnBeginTran2.Text = "BeginTran";
            this.btnBeginTran2.UseCompatibleTextRendering = true;
            this.btnBeginTran2.UseVisualStyleBackColor = true;
            this.btnBeginTran2.Click += new System.EventHandler(this.btnBeginTran2_Click);
            // 
            // btnRollback2
            // 
            this.btnRollback2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRollback2.Location = new System.Drawing.Point(426, 9);
            this.btnRollback2.Name = "btnRollback2";
            this.btnRollback2.Size = new System.Drawing.Size(90, 24);
            this.btnRollback2.TabIndex = 8;
            this.btnRollback2.Text = "Rollback";
            this.btnRollback2.UseCompatibleTextRendering = true;
            this.btnRollback2.UseVisualStyleBackColor = true;
            this.btnRollback2.Click += new System.EventHandler(this.btnRollback2_Click);
            // 
            // btnCommit2
            // 
            this.btnCommit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommit2.Location = new System.Drawing.Point(522, 9);
            this.btnCommit2.Name = "btnCommit2";
            this.btnCommit2.Size = new System.Drawing.Size(90, 24);
            this.btnCommit2.TabIndex = 9;
            this.btnCommit2.Text = "Commit";
            this.btnCommit2.UseCompatibleTextRendering = true;
            this.btnCommit2.UseVisualStyleBackColor = true;
            this.btnCommit2.Click += new System.EventHandler(this.btnCommit2_Click);
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(282, 9);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(42, 24);
            this.kissLabel1.TabIndex = 10;
            this.kissLabel1.Text = "direkt:";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel2.Location = new System.Drawing.Point(270, 482);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(111, 24);
            this.kissLabel2.TabIndex = 11;
            this.kissLabel2.Text = "indirekt �ber Session:";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // CtlQueryBgPositionsarten
            // 
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.btnCommit2);
            this.Controls.Add(this.btnRollback2);
            this.Controls.Add(this.btnBeginTran2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.btnRollback);
            this.Controls.Add(this.btnBeginTran);
            this.Name = "CtlQueryBgPositionsarten";
            this.Load += new System.EventHandler(this.CtlQueryBgPositionsarten_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.btnBeginTran, 0);
            this.Controls.SetChildIndex(this.btnRollback, 0);
            this.Controls.SetChildIndex(this.btnCommit, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.btnBeginTran2, 0);
            this.Controls.SetChildIndex(this.btnRollback2, 0);
            this.Controls.SetChildIndex(this.btnCommit2, 0);
            this.Controls.SetChildIndex(this.kissLabel1, 0);
            this.Controls.SetChildIndex(this.kissLabel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Private Methods

        private void CtlQueryBgPositionsarten_Load(object sender, System.EventArgs e)
        {
            DisplayTransactionStatus();
        }

        private void DisplayTransactionStatus()
        {
            if (Session.Transaction == null)
                lblStatus.Text = "Transaktion: inaktiv";
            else
                lblStatus.Text = "Transaktion: aktiv";
        }

        private void btnBeginTran_Click(object sender, System.EventArgs e)
        {
            try
            {
                Session.BeginTransaction();
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
            DisplayTransactionStatus();
        }

        private void btnCommit_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Session.Transaction != null)
                    Session.Commit();
                else
                    DBUtil.ExecSQLThrowingException("Commit");
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
            DisplayTransactionStatus();
        }

        private void btnRollback_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Session.Transaction != null)
                    Session.Rollback();
                else
                    //zur Sicherheit
                    DBUtil.ExecSQLThrowingException("Rollback");
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
            DisplayTransactionStatus();
        }

        #endregion

        private void btnBeginTran2_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtil.ExecSQL("BEGIN TRAN Test");
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void btnRollback2_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtil.ExecSQL("Rollback");
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void btnCommit2_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtil.ExecSQL("Commit");
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }
    }
}