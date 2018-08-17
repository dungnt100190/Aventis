using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Utils;
using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for DlgAuswahlBank.
    /// </summary>
    public class DlgAuswahlBank : KiSS4.Gui.KissDialog
    {
        public DataRow ResultRow = null;
        private KiSS4.Gui.KissButton btnBankSuchen;
        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnOK;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCalcEdit edtClearingNrX;
        private KiSS4.Gui.KissTextEdit edtNameX;
        private KiSS4.Gui.KissTextEdit edtOrtX;
        private KiSS4.Gui.KissTextEdit edtPCKontoX;
        private KiSS4.Gui.KissCalcEdit edtPLZX;
        private KiSS4.Gui.KissGrid grdBank;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBank;
        private KiSS4.Gui.KissLabel lblClearingNr;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblPLZOrt;
        private KiSS4.Gui.KissLabel lblPostkontoNr;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private KiSS4.DB.SqlQuery qryBaBank;
        private KiSS4.Gui.KissTabControlEx tabControlSearch;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;

        public DlgAuswahlBank()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.SelectedTabIndex = 0;
        }

        /// <summary>
        /// Searches the bank.
        /// </summary>
        /// <param name="searchClearingNrOrNameParam">The search clearing nr or name param.</param>
        /// <param name="searchPCKontoNrParam">The search PC konto nr param.</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <returns></returns>
        public bool SearchBank(
            string searchClearingNrOrNameParam,
            string searchPCKontoNrParam,
            bool open)
        {
            try
            {
                bool usePCKontoNr = false;

                qryBaBank.SelectStatement = @"SELECT BaBankID,
                                                     Name,
                                                     PCKontoNr,
                                                     ClearingNr,
                                                     Strasse,
                                                     Ort = ISNULL(PLZ + ' ', '') + ISNULL(Ort, '')
                                              FROM BaBank
                                              WHERE ClearingNr IS NULL ";

                if (Utils.IsNatural(searchClearingNrOrNameParam) && searchClearingNrOrNameParam != "")
                {
                    qryBaBank.SelectStatement += " AND ClearingNr = " + DBUtil.SqlLiteral(searchClearingNrOrNameParam);
                }
                else if (searchClearingNrOrNameParam != "")
                {
                    qryBaBank.SelectStatement += " AND Name LIKE " + DBUtil.SqlLiteralLike('%' + searchClearingNrOrNameParam + '%');
                }

                if (searchPCKontoNrParam != "")
                {
                    try
                    {
                        usePCKontoNr = true;
                        searchPCKontoNrParam = Utils.FormatPCKontoNummerToDBFormat(searchPCKontoNrParam);
                        qryBaBank.SelectStatement += " AND PCKontoNr = " + DBUtil.SqlLiteral(searchPCKontoNrParam);
                    }
                    catch (Exception e)
                    {
                        KissMsg.ShowError("DlgAuswahlBank", "FalschePCKontoNr", "Falsches PCKontoNr", e.Message, e);
                    }
                }
                qryBaBank.SelectStatement += " Order by Name, Ort";

                qryBaBank.Fill();

                AddGridColumn("Name", "Name", 250);
                AddGridColumn("Clearing Nr", "ClearingNr", 100);
                AddGridColumn("PostKonto Nr", "PCKontoNr", 250);
                AddGridColumn("Strasse", "Strasse", 250);
                AddGridColumn("Ort", "Ort", 250);

                if (qryBaBank.Count == 0)
                {
                    string problem = "";
                    if (usePCKontoNr)
                    {
                        problem = " mit PostKonto Nr : " + Utils.FormatPCKontoNummerToUserFormat(searchPCKontoNrParam);
                    }
                    else if (Utils.IsNatural(searchClearingNrOrNameParam))
                    {
                        problem = " mit Clearing Nr : " + searchClearingNrOrNameParam.ToString();
                    }
                    else
                    {
                        problem = " mit Name : " + searchClearingNrOrNameParam.ToString();
                    }

                    KissMsg.ShowInfo("DlgAuswahlBank", "BankNichtGefunden1", "Keine zutreffenden Bank {0} gefunden", 0, 0, problem);
                    this.tabControlSearch.SelectedTabIndex = 1;
                }
                else if (qryBaBank.Count == 1 && !open)
                {
                    ResultRow = qryBaBank.DataTable.Rows[0];
                    return true;
                }
                else
                {
                    this.tabControlSearch.SelectedTabIndex = 0;
                }

                return DisplayDialog();
            }
            catch (Exception e)
            {
                KissMsg.ShowError("DlgAuswahlBank", "FehlerBeimSuchen", "Ein Fehler ist beim Suchen aufgetreten", e.Message + Environment.NewLine + e.StackTrace, e);
                return false;
            }
        }

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
            this.qryBaBank = new KiSS4.DB.SqlQuery(this.components);
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnOK = new KiSS4.Gui.KissButton();
            this.tabControlSearch = new KiSS4.Gui.KissTabControlEx();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.grdBank = new KiSS4.Gui.KissGrid();
            this.grvBank = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.edtOrtX = new KiSS4.Gui.KissTextEdit();
            this.edtPLZX = new KiSS4.Gui.KissCalcEdit();
            this.edtClearingNrX = new KiSS4.Gui.KissCalcEdit();
            this.edtPCKontoX = new KiSS4.Gui.KissTextEdit();
            this.lblPostkontoNr = new KiSS4.Gui.KissLabel();
            this.edtNameX = new KiSS4.Gui.KissTextEdit();
            this.lblPLZOrt = new KiSS4.Gui.KissLabel();
            this.lblClearingNr = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.btnBankSuchen = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaBank)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBank)).BeginInit();
            this.panel1.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKontoX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostkontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClearingNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            this.SuspendLayout();
            //
            // qryBaBank
            //
            this.qryBaBank.HostControl = this;
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(968, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbruch";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(858, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            //
            // tabControlSearch
            //
            this.tabControlSearch.CausesValidation = false;
            this.tabControlSearch.Controls.Add(this.tpgListe);
            this.tabControlSearch.Controls.Add(this.tpgSuchen);
            this.tabControlSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Name = "tabControlSearch";
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.ShowFixedWidthTooltip = true;
            this.tabControlSearch.Size = new System.Drawing.Size(1084, 401);
            this.tabControlSearch.TabIndex = 10;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
            this.tabControlSearch.TabsLineColor = System.Drawing.Color.Black;
            this.tabControlSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControlSearch.TabStop = false;
            this.tabControlSearch.TabIndexChanged += new System.EventHandler(this.xTabControl1_TabIndexChanged);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdBank);
            this.tpgListe.Controls.Add(this.panel1);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(1072, 363);
            this.tpgListe.TabIndex = 0;
            this.tpgListe.Title = "Liste";
            this.tpgListe.Visible = false;
            //
            // grdBank
            //
            this.grdBank.DataSource = this.qryBaBank;
            this.grdBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBank.EmbeddedNavigator.Name = "";
            this.grdBank.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdBank.Location = new System.Drawing.Point(0, 0);
            this.grdBank.MainView = this.grvBank;
            this.grdBank.Name = "grdBank";
            this.grdBank.Size = new System.Drawing.Size(1072, 330);
            this.grdBank.Styles.AddReplace("StyleFar", new DevExpress.Utils.ViewStyleEx("StyleFar", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdBank.Styles.AddReplace("StyleNear", new DevExpress.Utils.ViewStyleEx("StyleNear", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdBank.Styles.AddReplace("StyleCenter", new DevExpress.Utils.ViewStyleEx("StyleCenter", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grdBank.TabIndex = 14;
            this.grdBank.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBank});
            //
            // grvBank
            //
            this.grvBank.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.grvBank.Appearance.Empty.Options.UseBackColor = true;
            this.grvBank.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvBank.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvBank.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBank.Appearance.FocusedCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.grvBank.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBank.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBank.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBank.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBank.Appearance.FocusedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvBank.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBank.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBank.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBank.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBank.Appearance.GroupRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvBank.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBank.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBank.Appearance.GroupRow.Options.UseFont = true;
            this.grvBank.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBank.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBank.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBank.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvBank.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBank.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBank.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBank.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBank.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvBank.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBank.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBank.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBank.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBank.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvBank.Appearance.OddRow.Options.UseBackColor = true;
            this.grvBank.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBank.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvBank.Appearance.Row.Options.UseBackColor = true;
            this.grvBank.Appearance.Row.Options.UseFont = true;
            this.grvBank.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvBank.Appearance.SelectedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvBank.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvBank.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvBank.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBank.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvBank.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBank.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBank.GridControl = this.grdBank;
            this.grvBank.Name = "grvBank";
            this.grvBank.OptionsBehavior.Editable = false;
            this.grvBank.OptionsCustomization.AllowFilter = false;
            this.grvBank.OptionsCustomization.AllowGroup = false;
            this.grvBank.OptionsFilter.AllowFilterEditor = false;
            this.grvBank.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBank.OptionsMenu.EnableColumnMenu = false;
            this.grvBank.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBank.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvBank.OptionsNavigation.UseTabKey = false;
            this.grvBank.OptionsPrint.AutoWidth = false;
            this.grvBank.OptionsPrint.UsePrintStyles = true;
            this.grvBank.OptionsView.ColumnAutoWidth = false;
            this.grvBank.OptionsView.ShowDetailButtons = false;
            this.grvBank.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBank.OptionsView.ShowGroupPanel = false;
            this.grvBank.OptionsView.ShowIndicator = false;
            //
            // panel1
            //
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 330);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 33);
            this.panel1.TabIndex = 13;
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.panel2);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(1072, 363);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Bank Suchen";
            //
            // panel2
            //
            this.panel2.CausesValidation = false;
            this.panel2.Controls.Add(this.edtOrtX);
            this.panel2.Controls.Add(this.edtPLZX);
            this.panel2.Controls.Add(this.edtClearingNrX);
            this.panel2.Controls.Add(this.edtPCKontoX);
            this.panel2.Controls.Add(this.lblPostkontoNr);
            this.panel2.Controls.Add(this.edtNameX);
            this.panel2.Controls.Add(this.lblPLZOrt);
            this.panel2.Controls.Add(this.lblClearingNr);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.btnBankSuchen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1072, 363);
            this.panel2.TabIndex = 14;
            //
            // edtOrtX
            //
            this.edtOrtX.EditValue = "";
            this.edtOrtX.Location = new System.Drawing.Point(171, 90);
            this.edtOrtX.Name = "edtOrtX";
            this.edtOrtX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrtX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrtX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrtX.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrtX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrtX.Properties.Appearance.Options.UseFont = true;
            this.edtOrtX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrtX.Size = new System.Drawing.Size(198, 24);
            this.edtOrtX.TabIndex = 5;
            //
            // edtPLZX
            //
            this.edtPLZX.Location = new System.Drawing.Point(120, 90);
            this.edtPLZX.Name = "edtPLZX";
            this.edtPLZX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtPLZX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPLZX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZX.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZX.Properties.Appearance.Options.UseFont = true;
            this.edtPLZX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPLZX.Size = new System.Drawing.Size(52, 24);
            this.edtPLZX.TabIndex = 4;
            //
            // edtClearingNrX
            //
            this.edtClearingNrX.Location = new System.Drawing.Point(120, 38);
            this.edtClearingNrX.Name = "edtClearingNrX";
            this.edtClearingNrX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtClearingNrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtClearingNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtClearingNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtClearingNrX.Properties.Appearance.Options.UseBackColor = true;
            this.edtClearingNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtClearingNrX.Properties.Appearance.Options.UseFont = true;
            this.edtClearingNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtClearingNrX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtClearingNrX.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtClearingNrX.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtClearingNrX.Size = new System.Drawing.Size(249, 24);
            this.edtClearingNrX.TabIndex = 2;
            //
            // edtPCKontoX
            //
            this.edtPCKontoX.EditValue = "";
            this.edtPCKontoX.Location = new System.Drawing.Point(120, 64);
            this.edtPCKontoX.Name = "edtPCKontoX";
            this.edtPCKontoX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPCKontoX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPCKontoX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPCKontoX.Properties.Appearance.Options.UseBackColor = true;
            this.edtPCKontoX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPCKontoX.Properties.Appearance.Options.UseFont = true;
            this.edtPCKontoX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPCKontoX.Size = new System.Drawing.Size(249, 24);
            this.edtPCKontoX.TabIndex = 3;
            this.edtPCKontoX.Leave += new System.EventHandler(this.editPCKonto_Leave);
            //
            // lblPostkontoNr
            //
            this.lblPostkontoNr.Location = new System.Drawing.Point(20, 64);
            this.lblPostkontoNr.Name = "lblPostkontoNr";
            this.lblPostkontoNr.Size = new System.Drawing.Size(100, 23);
            this.lblPostkontoNr.TabIndex = 11;
            this.lblPostkontoNr.Text = "Postkonto Nr";
            //
            // edtNameX
            //
            this.edtNameX.EditValue = "";
            this.edtNameX.Location = new System.Drawing.Point(120, 12);
            this.edtNameX.Name = "edtNameX";
            this.edtNameX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameX.Properties.Appearance.Options.UseFont = true;
            this.edtNameX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameX.Size = new System.Drawing.Size(249, 24);
            this.edtNameX.TabIndex = 1;
            //
            // lblPLZOrt
            //
            this.lblPLZOrt.Location = new System.Drawing.Point(19, 89);
            this.lblPLZOrt.Name = "lblPLZOrt";
            this.lblPLZOrt.Size = new System.Drawing.Size(100, 23);
            this.lblPLZOrt.TabIndex = 2;
            this.lblPLZOrt.Text = "PLZ/Ort";
            //
            // lblClearingNr
            //
            this.lblClearingNr.Location = new System.Drawing.Point(19, 37);
            this.lblClearingNr.Name = "lblClearingNr";
            this.lblClearingNr.Size = new System.Drawing.Size(100, 23);
            this.lblClearingNr.TabIndex = 1;
            this.lblClearingNr.Text = "Clearing Nr";
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(20, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            //
            // btnBankSuchen
            //
            this.btnBankSuchen.CausesValidation = false;
            this.btnBankSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBankSuchen.Location = new System.Drawing.Point(224, 124);
            this.btnBankSuchen.Name = "btnBankSuchen";
            this.btnBankSuchen.Size = new System.Drawing.Size(144, 24);
            this.btnBankSuchen.TabIndex = 6;
            this.btnBankSuchen.Text = "Suchen";
            this.btnBankSuchen.UseVisualStyleBackColor = false;
            this.btnBankSuchen.Click += new System.EventHandler(this.btnBankSuchen_Click);
            //
            // DlgAuswahlBank
            //

            this.ClientSize = new System.Drawing.Size(1084, 401);
            this.Controls.Add(this.tabControlSearch);
            this.Name = "DlgAuswahlBank";
            this.Text = "Auswahl";
            ((System.ComponentModel.ISupportInitialize)(this.qryBaBank)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBank)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPCKontoX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostkontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblClearingNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private void AddGridColumn(string Caption, string FieldName, int Width)
        {
            AddGridColumn(Caption, FieldName, Width, HorzAlignment.Default);
        }

        private void AddGridColumn(string Caption, string FieldName, int Width, DevExpress.Utils.HorzAlignment Alignment)
        {
            DevExpress.XtraGrid.Columns.GridColumn col = grvBank.Columns.Add();
            col.Caption = Caption;
            col.FieldName = FieldName;
            col.Name = FieldName;
            col.VisibleIndex = grvBank.Columns.Count - 1;
            col.Width = Width;
            col.AppearanceCell.Options.UseTextOptions = true;
            col.AppearanceCell.TextOptions.HAlignment = Alignment;
        }

        private void btnBankSuchen_Click(object sender, EventArgs e)
        {
            qryBaBank.SelectStatement = @"
                SELECT BaBankId,
                       Name,
                       PCKontoNr,
                       ClearingNr,
                       Strasse,
                       Ort = PLZ + ' ' + Ort
                FROM dbo.BaBank ";

            if (edtNameX.Text != "")
            {
                qryBaBank.SelectStatement += FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " Name like " + DBUtil.SqlLiteralLike("%" + edtNameX.Text + "%");
            }
            if (!String.IsNullOrEmpty(edtClearingNrX.Text))
            {
                // --- bug fix
                String literal = DBUtil.SqlLiteral(edtClearingNrX.EditValue);
                qryBaBank.SelectStatement += FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " ClearingNr = " + literal;
            }
            if (edtPCKontoX.Text != "")
            {
                qryBaBank.SelectStatement += FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " PCKontoNr like " + DBUtil.SqlLiteralLike("%" + Utils.FormatPCKontoNummerToDBFormat(edtPCKontoX.Text) + "%");
            }
            if (edtOrtX.Text != "")
            {
                qryBaBank.SelectStatement += FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " Ort like " + DBUtil.SqlLiteralLike("%" + edtOrtX.Text + "%");
            }
            if (edtPLZX.Text != "")
            {
                qryBaBank.SelectStatement += FibuUtilities.AndOrWhere(qryBaBank.SelectStatement) + " Plz like " + DBUtil.SqlLiteralLike("%" + edtPLZX.Text + "%");
            }

            qryBaBank.SelectStatement += " Order by Name, Ort";

            qryBaBank.Fill();

            tabControlSearch.SelectedTabIndex = 0;

            if (qryBaBank.Count == 0)
            {
                KissMsg.ShowInfo("DlgAuswahlBank", "BankNichtGefunden2", "Keine zutreffenden Bank gefunden");
            }
        }

        private bool DisplayDialog()
        {
            // Enlarge modal Dialog to display all columns
            int GridWidth = 10 + 15; //Border + Scrollspace
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grvBank.Columns)
            {
                GridWidth += col.Width + 1; // vertical line;
            }
            this.Width += GridWidth - grdBank.Width;

            this.grdBank.View.Columns["PCKontoNr"].DisplayFormat.Format = new GridColumnPCKontoFormatter();

            if (ShowDialog(Session.MainForm) == DialogResult.OK)
            {
                ResultRow = qryBaBank.Row;
                return true;
            }
            else
            {
                ResultRow = null;
                return false;
            }
        }

        private void editPCKonto_Leave(object sender, System.EventArgs e)
        {
            this.edtPCKontoX.Text = Utils.FormatPCKontoNummerToUserFormat(this.edtPCKontoX.Text);
        }

        private void grid_DoubleClick(object sender, System.EventArgs e)
        {
            btnOK.PerformClick();
        }

        private void xTabControl1_TabIndexChanged(object sender, System.EventArgs e)
        {
            if (tabControlSearch.SelectedTabIndex == 0)
                this.AcceptButton = btnOK;
            else
                this.AcceptButton = btnBankSuchen;
        }
    }
}