
namespace KiSS4.Query
{
    public class CtlQueryVmKlientenliste : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAHVNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBesonderes;
        private DevExpress.XtraGrid.Columns.GridColumn colEL;
        private DevExpress.XtraGrid.Columns.GridColumn colEinkommen;
        private DevExpress.XtraGrid.Columns.GridColumn colFA;
        private DevExpress.XtraGrid.Columns.GridColumn colGestorben;
        private DevExpress.XtraGrid.Columns.GridColumn colHE;
        private DevExpress.XtraGrid.Columns.GridColumn colMT;
        private DevExpress.XtraGrid.Columns.GridColumn colMandantin;
        private DevExpress.XtraGrid.Columns.GridColumn colPV;
        private DevExpress.XtraGrid.Columns.GridColumn colZuDe;
        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KiSS4.Gui.KissButtonEdit edtUserID1;
        private KiSS4.Gui.KissButtonEdit edtUserID2;
        private KiSS4.Gui.KissButtonEdit edtUserID3;
        private KiSS4.Gui.KissCheckEdit edtaktuell;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblMandantin;
        private KiSS4.Gui.KissLabel lblMandatstraegerin1;
        private KiSS4.Gui.KissLabel lblMandatstraegerin2;
        private KiSS4.Gui.KissLabel lblMandatstraegerin3;

        #endregion

        #region Constructors

        public CtlQueryVmKlientenliste()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryVmKlientenliste));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblMandatstraegerin1 = new KiSS4.Gui.KissLabel();
            this.lblMandatstraegerin2 = new KiSS4.Gui.KissLabel();
            this.lblMandatstraegerin3 = new KiSS4.Gui.KissLabel();
            this.lblMandantin = new KiSS4.Gui.KissLabel();
            this.edtUserID1 = new KiSS4.Gui.KissButtonEdit();
            this.edtUserID2 = new KiSS4.Gui.KissButtonEdit();
            this.edtUserID3 = new KiSS4.Gui.KissButtonEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.edtaktuell = new KiSS4.Gui.KissCheckEdit();
            this.colAHVNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBesonderes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinkommen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGestorben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandantin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZuDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtaktuell.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.gridView1});
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
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtaktuell);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtUserID3);
            this.tpgSuchen.Controls.Add(this.edtUserID2);
            this.tpgSuchen.Controls.Add(this.edtUserID1);
            this.tpgSuchen.Controls.Add(this.lblMandantin);
            this.tpgSuchen.Controls.Add(this.lblMandatstraegerin3);
            this.tpgSuchen.Controls.Add(this.lblMandatstraegerin2);
            this.tpgSuchen.Controls.Add(this.lblMandatstraegerin1);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandatstraegerin1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandatstraegerin2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandatstraegerin3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMandantin, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtaktuell, 0);
            //
            // lblMandatstraegerin1
            //
            this.lblMandatstraegerin1.Location = new System.Drawing.Point(10, 40);
            this.lblMandatstraegerin1.Name = "lblMandatstraegerin1";
            this.lblMandatstraegerin1.Size = new System.Drawing.Size(130, 24);
            this.lblMandatstraegerin1.TabIndex = 1;
            this.lblMandatstraegerin1.Text = "Mandatstraeger/-in 1";
            this.lblMandatstraegerin1.UseCompatibleTextRendering = true;
            //
            // lblMandatstraegerin2
            //
            this.lblMandatstraegerin2.Location = new System.Drawing.Point(10, 70);
            this.lblMandatstraegerin2.Name = "lblMandatstraegerin2";
            this.lblMandatstraegerin2.Size = new System.Drawing.Size(130, 24);
            this.lblMandatstraegerin2.TabIndex = 1;
            this.lblMandatstraegerin2.Text = "Mandatstraeger/-in 2";
            this.lblMandatstraegerin2.UseCompatibleTextRendering = true;
            //
            // lblMandatstraegerin3
            //
            this.lblMandatstraegerin3.Location = new System.Drawing.Point(10, 100);
            this.lblMandatstraegerin3.Name = "lblMandatstraegerin3";
            this.lblMandatstraegerin3.Size = new System.Drawing.Size(130, 24);
            this.lblMandatstraegerin3.TabIndex = 1;
            this.lblMandatstraegerin3.Text = "Mandatstraeger/-in 3";
            this.lblMandatstraegerin3.UseCompatibleTextRendering = true;
            //
            // lblMandantin
            //
            this.lblMandantin.Location = new System.Drawing.Point(10, 130);
            this.lblMandantin.Name = "lblMandantin";
            this.lblMandantin.Size = new System.Drawing.Size(130, 24);
            this.lblMandantin.TabIndex = 2;
            this.lblMandantin.Text = "Mandant/-in";
            this.lblMandantin.UseCompatibleTextRendering = true;
            //
            // edtUserID1
            //
            this.edtUserID1.EditValue = "";
            this.edtUserID1.Location = new System.Drawing.Point(150, 40);
            this.edtUserID1.LookupSQL = resources.GetString("edtUserID1.LookupSQL");
            this.edtUserID1.Name = "edtUserID1";
            this.edtUserID1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID1.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID1.Properties.Appearance.Options.UseFont = true;
            this.edtUserID1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserID1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtUserID1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID1.Size = new System.Drawing.Size(200, 24);
            this.edtUserID1.TabIndex = 20;
            //
            // edtUserID2
            //
            this.edtUserID2.EditValue = "";
            this.edtUserID2.Location = new System.Drawing.Point(150, 70);
            this.edtUserID2.LookupSQL = resources.GetString("edtUserID2.LookupSQL");
            this.edtUserID2.Name = "edtUserID2";
            this.edtUserID2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID2.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID2.Properties.Appearance.Options.UseFont = true;
            this.edtUserID2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserID2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtUserID2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID2.Size = new System.Drawing.Size(200, 24);
            this.edtUserID2.TabIndex = 21;
            //
            // edtUserID3
            //
            this.edtUserID3.EditValue = "";
            this.edtUserID3.Location = new System.Drawing.Point(150, 100);
            this.edtUserID3.LookupSQL = resources.GetString("edtUserID3.LookupSQL");
            this.edtUserID3.Name = "edtUserID3";
            this.edtUserID3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID3.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID3.Properties.Appearance.Options.UseFont = true;
            this.edtUserID3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtUserID3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtUserID3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID3.Size = new System.Drawing.Size(200, 24);
            this.edtUserID3.TabIndex = 22;
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.EditValue = "";
            this.edtBaPersonID.Location = new System.Drawing.Point(150, 130);
            this.edtBaPersonID.LookupSQL = resources.GetString("edtBaPersonID.LookupSQL");
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Size = new System.Drawing.Size(200, 24);
            this.edtBaPersonID.TabIndex = 23;
            //
            // edtaktuell
            //
            this.edtaktuell.EditValue = false;
            this.edtaktuell.Location = new System.Drawing.Point(150, 160);
            this.edtaktuell.Name = "edtaktuell";
            this.edtaktuell.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtaktuell.Properties.Appearance.Options.UseBackColor = true;
            this.edtaktuell.Properties.Caption = "nur aktive";
            this.edtaktuell.Size = new System.Drawing.Size(250, 19);
            this.edtaktuell.TabIndex = 24;
            //
            // colAHVNr
            //
            this.colAHVNr.Name = "colAHVNr";
            //
            // colBesonderes
            //
            this.colBesonderes.Name = "colBesonderes";
            //
            // colEinkommen
            //
            this.colEinkommen.Name = "colEinkommen";
            //
            // colEL
            //
            this.colEL.Name = "colEL";
            //
            // colFA
            //
            this.colFA.Name = "colFA";
            //
            // colGestorben
            //
            this.colGestorben.Name = "colGestorben";
            //
            // colHE
            //
            this.colHE.Name = "colHE";
            //
            // colMandantin
            //
            this.colMandantin.Name = "colMandantin";
            //
            // colMT
            //
            this.colMT.Name = "colMT";
            //
            // colPV
            //
            this.colPV.Name = "colPV";
            //
            // colZuDe
            //
            this.colZuDe.Name = "colZuDe";
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
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
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
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.grvQuery1.GridControl = this.grdQuery1;
            this.grvQuery1.Name = "grvQuery1";
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
            // CtlQueryVmKlientenliste
            //
            this.Name = "CtlQueryVmKlientenliste";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandatstraegerin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandantin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtaktuell.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}