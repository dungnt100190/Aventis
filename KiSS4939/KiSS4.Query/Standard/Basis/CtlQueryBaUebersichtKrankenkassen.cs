using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public class CtlQueryBaUebersichtKrankenkassen : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colASVSAbm;
        private DevExpress.XtraGrid.Columns.GridColumn colASVSAnm;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colJahresfranchiseKVG;
        private DevExpress.XtraGrid.Columns.GridColumn colJahresfranchiseVVG;
        private DevExpress.XtraGrid.Columns.GridColumn colKVGAngaben;
        private DevExpress.XtraGrid.Columns.GridColumn colKVGPrmie;
        private DevExpress.XtraGrid.Columns.GridColumn colMitgliedNr;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colPrmienverbilligung;
        private DevExpress.XtraGrid.Columns.GridColumn colSARAsyl;
        private DevExpress.XtraGrid.Columns.GridColumn colSARFallfhrung;
        private DevExpress.XtraGrid.Columns.GridColumn colSARInkasso;
        private DevExpress.XtraGrid.Columns.GridColumn colSARSozialhilfe;
        private DevExpress.XtraGrid.Columns.GridColumn colSARVormundschaft;
        private DevExpress.XtraGrid.Columns.GridColumn colUnfallversicherung;
        private DevExpress.XtraGrid.Columns.GridColumn colVVGAngaben;
        private DevExpress.XtraGrid.Columns.GridColumn colVVGPrmie;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungKVG;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungVVG;
        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KiSS4.Gui.KissTextEdit edtKrankenkasse;
        private KiSS4.Gui.KissCheckEdit edtNurAktive;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblKrankenkasse;
        private KiSS4.Gui.KissLabel lblSAR;

        #endregion

        #region Constructors

        public CtlQueryBaUebersichtKrankenkassen()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaUebersichtKrankenkassen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.lblKrankenkasse = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.edtKrankenkasse = new KiSS4.Gui.KissTextEdit();
            this.edtNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.colASVSAbm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colASVSAnm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahresfranchiseKVG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJahresfranchiseVVG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKVGAngaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKVGPrmie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitgliedNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrmienverbilligung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARAsyl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARFallfhrung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARInkasso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARSozialhilfe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARVormundschaft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnfallversicherung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVVGAngaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVVGPrmie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungKVG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungVVG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKrankenkasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKrankenkasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            this.xDocument.Visible = false;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 398);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 26);
            //
            // tabControlSearch
            //
            this.tabControlSearch.SelectedTabIndex = 1;
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtNurAktive);
            this.tpgSuchen.Controls.Add(this.edtKrankenkasse);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblKrankenkasse);
            this.tpgSuchen.Controls.Add(this.lblKlient);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKrankenkasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKrankenkasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAktive, 0);
            //
            // lblSAR
            //
            this.lblSAR.Location = new System.Drawing.Point(10, 40);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 1;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            //
            // lblKlient
            //
            this.lblKlient.Location = new System.Drawing.Point(10, 70);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(130, 24);
            this.lblKlient.TabIndex = 2;
            this.lblKlient.Text = "Klient";
            this.lblKlient.UseCompatibleTextRendering = true;
            //
            // lblKrankenkasse
            //
            this.lblKrankenkasse.Location = new System.Drawing.Point(10, 100);
            this.lblKrankenkasse.Name = "lblKrankenkasse";
            this.lblKrankenkasse.Size = new System.Drawing.Size(130, 24);
            this.lblKrankenkasse.TabIndex = 3;
            this.lblKrankenkasse.Text = "Krankenkasse";
            this.lblKrankenkasse.UseCompatibleTextRendering = true;
            //
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(150, 40);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(220, 24);
            this.edtUserID.TabIndex = 20;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.Location = new System.Drawing.Point(150, 70);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBaPersonID.Size = new System.Drawing.Size(220, 24);
            this.edtBaPersonID.TabIndex = 21;
            this.edtBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonID_UserModifiedFld);
            //
            // edtKrankenkasse
            //
            this.edtKrankenkasse.Location = new System.Drawing.Point(150, 100);
            this.edtKrankenkasse.Name = "edtKrankenkasse";
            this.edtKrankenkasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKrankenkasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKrankenkasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKrankenkasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtKrankenkasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKrankenkasse.Properties.Appearance.Options.UseFont = true;
            this.edtKrankenkasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKrankenkasse.Size = new System.Drawing.Size(220, 24);
            this.edtKrankenkasse.TabIndex = 22;
            //
            // edtNurAktive
            //
            this.edtNurAktive.EditValue = false;
            this.edtNurAktive.Location = new System.Drawing.Point(150, 130);
            this.edtNurAktive.Name = "edtNurAktive";
            this.edtNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktive.Properties.Caption = "nur aktive";
            this.edtNurAktive.Size = new System.Drawing.Size(200, 19);
            this.edtNurAktive.TabIndex = 23;
            //
            // colASVSAbm
            //
            this.colASVSAbm.Name = "colASVSAbm";
            //
            // colASVSAnm
            //
            this.colASVSAnm.Name = "colASVSAnm";
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            //
            // colJahresfranchiseKVG
            //
            this.colJahresfranchiseKVG.Name = "colJahresfranchiseKVG";
            //
            // colJahresfranchiseVVG
            //
            this.colJahresfranchiseVVG.Name = "colJahresfranchiseVVG";
            //
            // colKVGAngaben
            //
            this.colKVGAngaben.Name = "colKVGAngaben";
            //
            // colKVGPrmie
            //
            this.colKVGPrmie.Name = "colKVGPrmie";
            //
            // colMitgliedNr
            //
            this.colMitgliedNr.Name = "colMitgliedNr";
            //
            // colPerson
            //
            this.colPerson.Name = "colPerson";
            //
            // colPrmienverbilligung
            //
            this.colPrmienverbilligung.Name = "colPrmienverbilligung";
            //
            // colSARAsyl
            //
            this.colSARAsyl.Name = "colSARAsyl";
            //
            // colSARFallfhrung
            //
            this.colSARFallfhrung.Name = "colSARFallfhrung";
            //
            // colSARInkasso
            //
            this.colSARInkasso.Name = "colSARInkasso";
            //
            // colSARSozialhilfe
            //
            this.colSARSozialhilfe.Name = "colSARSozialhilfe";
            //
            // colSARVormundschaft
            //
            this.colSARVormundschaft.Name = "colSARVormundschaft";
            //
            // colUnfallversicherung
            //
            this.colUnfallversicherung.Name = "colUnfallversicherung";
            //
            // colVVGAngaben
            //
            this.colVVGAngaben.Name = "colVVGAngaben";
            //
            // colVVGPrmie
            //
            this.colVVGPrmie.Name = "colVVGPrmie";
            //
            // colZahlungKVG
            //
            this.colZahlungKVG.Name = "colZahlungKVG";
            //
            // colZahlungVVG
            //
            this.colZahlungVVG.Name = "colZahlungVVG";
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
            // CtlQueryBaUebersichtKrankenkassen
            //
            this.Name = "CtlQueryBaUebersichtKrankenkassen";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKrankenkasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKrankenkasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Protected Methods

        protected override void RunSearch()
        {
            // replace search parameters
            object[] parameters = new object[] { Session.User.LogonName, Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;
            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void edtBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtBaPersonID.EditValue = null;
                    edtBaPersonID.LookupID = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(string.Format(@"
                SELECT  ID = BaPersonID,
                        Person = IsNull(NameVorname, ''),
                        [Vers. Nr.] = Versichertennummer,
                        AHVNummer
                FROM vwPerson
                WHERE IsNull(NameVorname,'') like {{0}} + '%'
                    AND (PersonSichtbarSDFlag = dbo.fnGetPersonSichtbarFlag('{0}') or PersonSichtbarSDFlag = 1)
                ORDER BY Person", Session.User.LogonName),
                SearchString,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg[1];
                edtBaPersonID.LookupID = dlg[0];
            }
        }

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        #endregion
    }
}