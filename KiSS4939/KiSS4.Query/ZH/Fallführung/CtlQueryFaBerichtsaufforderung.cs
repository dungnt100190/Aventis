using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.Common.ZH;
using KiSS4.DB;
using KiSS4.FAMOZ.VIS;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public class CtlQueryFaBerichtsaufforderung : KissQueryControl
    {
        #region Fields

        #region Private Fields

        private KissButton btnSync;
        private DevExpress.XtraGrid.Columns.GridColumn col1Mahnung;
        private DevExpress.XtraGrid.Columns.GridColumn col2Mahnung;
        private DevExpress.XtraGrid.Columns.GridColumn col3Mahnung;
        private DevExpress.XtraGrid.Columns.GridColumn colAbgeschlosseneLeistung;
        private DevExpress.XtraGrid.Columns.GridColumn colAusgangSDS;
        private DevExpress.XtraGrid.Columns.GridColumn colBerichtBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBerichtsart;
        private DevExpress.XtraGrid.Columns.GridColumn colBerichtVon;
        private DevExpress.XtraGrid.Columns.GridColumn colEingangSDS;
        private DevExpress.XtraGrid.Columns.GridColumn colErstellung;
        private DevExpress.XtraGrid.Columns.GridColumn colFallBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colFristerstreckung;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtstag;
        private DevExpress.XtraGrid.Columns.GridColumn colGenehmBRZ;
        private DevExpress.XtraGrid.Columns.GridColumn colGenehmVB;
        private DevExpress.XtraGrid.Columns.GridColumn colHistorisiert;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKlibu;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colMandatstraeger;
        private DevExpress.XtraGrid.Columns.GridColumn colMandatstyp;
        private DevExpress.XtraGrid.Columns.GridColumn colPersNr;
        private DevExpress.XtraGrid.Columns.GridColumn colSpesen;
        private DevExpress.XtraGrid.Columns.GridColumn colTage;
        private DevExpress.XtraGrid.Columns.GridColumn colTodestag;
        private DevExpress.XtraGrid.Columns.GridColumn colVersandVB;
        private DevExpress.XtraGrid.Columns.GridColumn colZGB;
        private DevExpress.XtraGrid.Columns.GridColumn colzustMA;
        private KiSS4.Common.ZH.CtlOrgUnitTeamUser ctlOrgUnitTeamUser;
        private KissDateEdit edtAusgangSDSBis;
        private KissDateEdit edtAusgangSDSVon;
        private KissDateEdit edtEingangSDSBis;
        private KissDateEdit edtEingangSDSVon;
        private KiSS4.Gui.KissDateEdit edtFaelligBis;
        private KissCheckEdit edtInklAbgeschlosseneLeistungen;
        private KiSS4.Gui.KissCheckEdit edtInklErstellte;
        private KissCheckEdit edtInklHist;
        private KissButtonEdit edtMAKlibu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KissLabel lblAusgangSDS;
        private KissLabel lblAusgangSDSBis;
        private KissLabel lblEingangSDS;
        private KissLabel lblEingangSDSBis;
        private KissLabel lblMAKlibu;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryFaBerichtsaufforderung()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryFaBerichtsaufforderung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtFaelligBis = new KiSS4.Gui.KissDateEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.ctlOrgUnitTeamUser = new KiSS4.Common.ZH.CtlOrgUnitTeamUser();
            this.edtInklErstellte = new KiSS4.Gui.KissCheckEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtstag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTodestag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZGB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandatstyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerichtsart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerichtVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBerichtBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFristerstreckung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col1Mahnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col2Mahnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col3Mahnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpesen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEingangSDS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusgangSDS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErstellung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVersandVB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGenehmVB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGenehmBRZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colzustMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandatstraeger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKlibu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHistorisiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colAbgeschlosseneLeistung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSync = new KiSS4.Gui.KissButton();
            this.lblEingangSDS = new KiSS4.Gui.KissLabel();
            this.edtEingangSDSVon = new KiSS4.Gui.KissDateEdit();
            this.edtEingangSDSBis = new KiSS4.Gui.KissDateEdit();
            this.lblEingangSDSBis = new KiSS4.Gui.KissLabel();
            this.lblAusgangSDSBis = new KiSS4.Gui.KissLabel();
            this.edtAusgangSDSBis = new KiSS4.Gui.KissDateEdit();
            this.lblAusgangSDS = new KiSS4.Gui.KissLabel();
            this.edtAusgangSDSVon = new KiSS4.Gui.KissDateEdit();
            this.edtMAKlibu = new KiSS4.Gui.KissButtonEdit();
            this.lblMAKlibu = new KiSS4.Gui.KissLabel();
            this.edtInklHist = new KiSS4.Gui.KissCheckEdit();
            this.edtInklAbgeschlosseneLeistungen = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtFaelligBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklErstellte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingangSDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEingangSDSVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEingangSDSBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingangSDSBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgangSDSBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgangSDSBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgangSDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgangSDSVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMAKlibu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMAKlibu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklHist.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklAbgeschlosseneLeistungen.Properties)).BeginInit();
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
            this.grvQuery1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "FallBaPersonID$";
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtInklAbgeschlosseneLeistungen);
            this.tpgSuchen.Controls.Add(this.edtInklHist);
            this.tpgSuchen.Controls.Add(this.lblMAKlibu);
            this.tpgSuchen.Controls.Add(this.edtMAKlibu);
            this.tpgSuchen.Controls.Add(this.lblAusgangSDSBis);
            this.tpgSuchen.Controls.Add(this.edtAusgangSDSBis);
            this.tpgSuchen.Controls.Add(this.lblAusgangSDS);
            this.tpgSuchen.Controls.Add(this.edtAusgangSDSVon);
            this.tpgSuchen.Controls.Add(this.lblEingangSDSBis);
            this.tpgSuchen.Controls.Add(this.edtEingangSDSBis);
            this.tpgSuchen.Controls.Add(this.lblEingangSDS);
            this.tpgSuchen.Controls.Add(this.edtEingangSDSVon);
            this.tpgSuchen.Controls.Add(this.btnSync);
            this.tpgSuchen.Controls.Add(this.edtInklErstellte);
            this.tpgSuchen.Controls.Add(this.ctlOrgUnitTeamUser);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.edtFaelligBis);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFaelligBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.ctlOrgUnitTeamUser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklErstellte, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.btnSync, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEingangSDSVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEingangSDS, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEingangSDSBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEingangSDSBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAusgangSDSVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAusgangSDS, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAusgangSDSBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAusgangSDSBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtMAKlibu, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMAKlibu, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklHist, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInklAbgeschlosseneLeistungen, 0);
            //
            // edtFaelligBis
            //
            this.edtFaelligBis.EditValue = null;
            this.edtFaelligBis.Location = new System.Drawing.Point(123, 133);
            this.edtFaelligBis.Name = "edtFaelligBis";
            this.edtFaelligBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtFaelligBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFaelligBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFaelligBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFaelligBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtFaelligBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFaelligBis.Properties.Appearance.Options.UseFont = true;
            this.edtFaelligBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtFaelligBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtFaelligBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtFaelligBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFaelligBis.Properties.ShowToday = false;
            this.edtFaelligBis.Size = new System.Drawing.Size(100, 24);
            this.edtFaelligBis.TabIndex = 1;
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(10, 133);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(83, 24);
            this.kissLabel1.TabIndex = 5;
            this.kissLabel1.Text = "Fällig bis";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // ctlOrgUnitTeamUser
            //
            this.ctlOrgUnitTeamUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlOrgUnitTeamUser.LableWidth = 113;
            this.ctlOrgUnitTeamUser.Location = new System.Drawing.Point(10, 43);
            this.ctlOrgUnitTeamUser.Name = "ctlOrgUnitTeamUser";
            this.ctlOrgUnitTeamUser.SetUserOnNewSearch = false;
            this.ctlOrgUnitTeamUser.ShowUser = true;
            this.ctlOrgUnitTeamUser.Size = new System.Drawing.Size(373, 84);
            this.ctlOrgUnitTeamUser.TabIndex = 9;
            this.ctlOrgUnitTeamUser.UserModifiedFldMA += new System.EventHandler(this.ctlOrgUnitTeamUser_UserModifiedFldMA);
            this.ctlOrgUnitTeamUser.UserModifiedFldOE += new System.EventHandler(this.ctlOrgUnitTeamUser_UserModifiedFldOE);
            this.ctlOrgUnitTeamUser.UserModifiedFldTeam += new System.EventHandler(this.ctlOrgUnitTeamUser_UserModifiedFldTeam);
            //
            // edtInklErstellte
            //
            this.edtInklErstellte.EditValue = true;
            this.edtInklErstellte.Location = new System.Drawing.Point(123, 165);
            this.edtInklErstellte.Name = "edtInklErstellte";
            this.edtInklErstellte.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklErstellte.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklErstellte.Properties.Caption = "inkl. bereits erstellte Berichte";
            this.edtInklErstellte.Size = new System.Drawing.Size(176, 19);
            this.edtInklErstellte.TabIndex = 10;
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
            this.colMandant,
            this.colPersNr,
            this.colGeburtstag,
            this.colTodestag,
            this.colZGB,
            this.colMandatstyp,
            this.colBerichtsart,
            this.colBerichtVon,
            this.colBerichtBis,
            this.colFristerstreckung,
            this.col1Mahnung,
            this.col2Mahnung,
            this.col3Mahnung,
            this.colSpesen,
            this.colEingangSDS,
            this.colAusgangSDS,
            this.colErstellung,
            this.colTage,
            this.colVersandVB,
            this.colGenehmVB,
            this.colGenehmBRZ,
            this.colzustMA,
            this.colMandatstraeger,
            this.colMAKlibu,
            this.colFallBaPersonID,
            this.colHistorisiert,
            this.colAbgeschlosseneLeistung});
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
            // colMandant
            //
            this.colMandant.Caption = "Person mit zivilr. Massnahme";
            this.colMandant.FieldName = "Person mit zivilr. Massnahme";
            this.colMandant.Name = "colMandant";
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 0;
            this.colMandant.Width = 231;
            //
            // colPersNr
            //
            this.colPersNr.Caption = "Pers.-Nr";
            this.colPersNr.FieldName = "Pers.-Nr";
            this.colPersNr.Name = "colPersNr";
            //
            // colGeburtstag
            //
            this.colGeburtstag.Caption = "Geburtstag";
            this.colGeburtstag.FieldName = "Geburtstag";
            this.colGeburtstag.Name = "colGeburtstag";
            //
            // colTodestag
            //
            this.colTodestag.Caption = "Todestag";
            this.colTodestag.FieldName = "Todestag";
            this.colTodestag.Name = "colTodestag";
            //
            // colZGB
            //
            this.colZGB.Caption = "ZGB";
            this.colZGB.FieldName = "ZGB";
            this.colZGB.Name = "colZGB";
            //
            // colMandatstyp
            //
            this.colMandatstyp.Caption = "Behördliche Massnahme";
            this.colMandatstyp.FieldName = "Behördliche Massnahme";
            this.colMandatstyp.Name = "colMandatstyp";
            //
            // colBerichtsart
            //
            this.colBerichtsart.Caption = "Berichtsart";
            this.colBerichtsart.FieldName = "Berichtsart";
            this.colBerichtsart.Name = "colBerichtsart";
            this.colBerichtsart.Visible = true;
            this.colBerichtsart.VisibleIndex = 1;
            this.colBerichtsart.Width = 145;
            //
            // colBerichtVon
            //
            this.colBerichtVon.Caption = "Bericht von";
            this.colBerichtVon.FieldName = "Bericht von";
            this.colBerichtVon.Name = "colBerichtVon";
            this.colBerichtVon.Visible = true;
            this.colBerichtVon.VisibleIndex = 2;
            //
            // colBerichtBis
            //
            this.colBerichtBis.Caption = "Bericht bis";
            this.colBerichtBis.FieldName = "Bericht bis";
            this.colBerichtBis.Name = "colBerichtBis";
            this.colBerichtBis.Visible = true;
            this.colBerichtBis.VisibleIndex = 3;
            //
            // colFristerstreckung
            //
            this.colFristerstreckung.Caption = "Fristerstreckung";
            this.colFristerstreckung.FieldName = "Fristerstreckung";
            this.colFristerstreckung.Name = "colFristerstreckung";
            this.colFristerstreckung.Visible = true;
            this.colFristerstreckung.VisibleIndex = 5;
            this.colFristerstreckung.Width = 106;
            //
            // col1Mahnung
            //
            this.col1Mahnung.Caption = "1. Mahnung";
            this.col1Mahnung.FieldName = "1. Mahnung";
            this.col1Mahnung.Name = "col1Mahnung";
            this.col1Mahnung.Visible = true;
            this.col1Mahnung.VisibleIndex = 6;
            //
            // col2Mahnung
            //
            this.col2Mahnung.Caption = "2. Mahnung";
            this.col2Mahnung.FieldName = "2. Mahnung";
            this.col2Mahnung.Name = "col2Mahnung";
            this.col2Mahnung.Visible = true;
            this.col2Mahnung.VisibleIndex = 7;
            //
            // col3Mahnung
            //
            this.col3Mahnung.Caption = "3. Mahnung";
            this.col3Mahnung.FieldName = "3. Mahnung";
            this.col3Mahnung.Name = "col3Mahnung";
            this.col3Mahnung.Visible = true;
            this.col3Mahnung.VisibleIndex = 8;
            //
            // colSpesen
            //
            this.colSpesen.Caption = "Spesen";
            this.colSpesen.FieldName = "Spesen";
            this.colSpesen.Name = "colSpesen";
            //
            // colEingangSDS
            //
            this.colEingangSDS.Caption = "Eingang SDS";
            this.colEingangSDS.FieldName = "Eingang SDS";
            this.colEingangSDS.Name = "colEingangSDS";
            //
            // colAusgangSDS
            //
            this.colAusgangSDS.Caption = "Ausgang SDS";
            this.colAusgangSDS.FieldName = "Ausgang SDS";
            this.colAusgangSDS.Name = "colAusgangSDS";
            //
            // colErstellung
            //
            this.colErstellung.Caption = "Erstellung";
            this.colErstellung.FieldName = "Erstellung";
            this.colErstellung.Name = "colErstellung";
            //
            // colTage
            //
            this.colTage.Caption = "Tage";
            this.colTage.FieldName = "Tage";
            this.colTage.Name = "colTage";
            this.colTage.Visible = true;
            this.colTage.VisibleIndex = 4;
            //
            // colVersandVB
            //
            this.colVersandVB.Caption = "Versand KESB";
            this.colVersandVB.FieldName = "Versand KESB";
            this.colVersandVB.Name = "colVersandVB";
            //
            // colGenehmVB
            //
            this.colGenehmVB.Caption = "Genehm. KESB";
            this.colGenehmVB.FieldName = "Genehm. KESB";
            this.colGenehmVB.Name = "colGenehmVB";
            //
            // colGenehmBRZ
            //
            this.colGenehmBRZ.Caption = "Genehm. BRZ (gültig bis 31.12.2012)";
            this.colGenehmBRZ.FieldName = "Genehm. BRZ (gültig bis 31.12.2012)";
            this.colGenehmBRZ.Name = "colGenehmBRZ";
            //
            // colzustMA
            //
            this.colzustMA.Caption = "zust. MA";
            this.colzustMA.FieldName = "zust. MA";
            this.colzustMA.Name = "colzustMA";
            //
            // colMandatstraeger
            //
            this.colMandatstraeger.Caption = "Beist. oder Vorm.";
            this.colMandatstraeger.FieldName = "Beist. oder Vorm.";
            this.colMandatstraeger.Name = "colMandatstraeger";
            //
            // colMAKlibu
            //
            this.colMAKlibu.Caption = "MA Klibu";
            this.colMAKlibu.FieldName = "MA Klibu";
            this.colMAKlibu.Name = "colMAKlibu";
            //
            // colFallBaPersonID
            //
            this.colFallBaPersonID.Caption = "FallBaPersonID";
            this.colFallBaPersonID.FieldName = "FallBaPersonID$";
            this.colFallBaPersonID.Name = "colFallBaPersonID";
            //
            // colHistorisiert
            //
            this.colHistorisiert.Caption = "Hist.";
            this.colHistorisiert.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colHistorisiert.FieldName = "Historisiert";
            this.colHistorisiert.Name = "colHistorisiert";
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // colAbgeschlosseneLeistung
            //
            this.colAbgeschlosseneLeistung.Caption = "Abgeschlossene Leistung";
            this.colAbgeschlosseneLeistung.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colAbgeschlosseneLeistung.FieldName = "Abgeschlossen";
            this.colAbgeschlosseneLeistung.Name = "colAbgeschlosseneLeistung";
            //
            // btnSync
            //
            this.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSync.Location = new System.Drawing.Point(3, 354);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(253, 24);
            this.btnSync.TabIndex = 11;
            this.btnSync.Text = "Alle Fälle SOD mit VIS synchronisieren ...";
            this.btnSync.UseCompatibleTextRendering = true;
            this.btnSync.UseVisualStyleBackColor = false;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            //
            // lblEingangSDS
            //
            this.lblEingangSDS.Location = new System.Drawing.Point(3, 246);
            this.lblEingangSDS.Name = "lblEingangSDS";
            this.lblEingangSDS.Size = new System.Drawing.Size(105, 24);
            this.lblEingangSDS.TabIndex = 13;
            this.lblEingangSDS.Text = "Eingang SDS von";
            this.lblEingangSDS.UseCompatibleTextRendering = true;
            this.lblEingangSDS.Visible = false;
            //
            // edtEingangSDSVon
            //
            this.edtEingangSDSVon.EditValue = null;
            this.edtEingangSDSVon.Location = new System.Drawing.Point(122, 246);
            this.edtEingangSDSVon.Name = "edtEingangSDSVon";
            this.edtEingangSDSVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEingangSDSVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEingangSDSVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEingangSDSVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEingangSDSVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtEingangSDSVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEingangSDSVon.Properties.Appearance.Options.UseFont = true;
            this.edtEingangSDSVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtEingangSDSVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEingangSDSVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtEingangSDSVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEingangSDSVon.Properties.ShowToday = false;
            this.edtEingangSDSVon.Size = new System.Drawing.Size(100, 24);
            this.edtEingangSDSVon.TabIndex = 12;
            this.edtEingangSDSVon.Visible = false;
            //
            // edtEingangSDSBis
            //
            this.edtEingangSDSBis.EditValue = null;
            this.edtEingangSDSBis.Location = new System.Drawing.Point(282, 246);
            this.edtEingangSDSBis.Name = "edtEingangSDSBis";
            this.edtEingangSDSBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtEingangSDSBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEingangSDSBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEingangSDSBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEingangSDSBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtEingangSDSBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEingangSDSBis.Properties.Appearance.Options.UseFont = true;
            this.edtEingangSDSBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtEingangSDSBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtEingangSDSBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtEingangSDSBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEingangSDSBis.Properties.ShowToday = false;
            this.edtEingangSDSBis.Size = new System.Drawing.Size(100, 24);
            this.edtEingangSDSBis.TabIndex = 14;
            this.edtEingangSDSBis.Visible = false;
            //
            // lblEingangSDSBis
            //
            this.lblEingangSDSBis.Location = new System.Drawing.Point(244, 246);
            this.lblEingangSDSBis.Name = "lblEingangSDSBis";
            this.lblEingangSDSBis.Size = new System.Drawing.Size(28, 24);
            this.lblEingangSDSBis.TabIndex = 15;
            this.lblEingangSDSBis.Text = "bis";
            this.lblEingangSDSBis.UseCompatibleTextRendering = true;
            this.lblEingangSDSBis.Visible = false;
            //
            // lblAusgangSDSBis
            //
            this.lblAusgangSDSBis.Location = new System.Drawing.Point(244, 278);
            this.lblAusgangSDSBis.Name = "lblAusgangSDSBis";
            this.lblAusgangSDSBis.Size = new System.Drawing.Size(28, 24);
            this.lblAusgangSDSBis.TabIndex = 19;
            this.lblAusgangSDSBis.Text = "bis";
            this.lblAusgangSDSBis.UseCompatibleTextRendering = true;
            this.lblAusgangSDSBis.Visible = false;
            //
            // edtAusgangSDSBis
            //
            this.edtAusgangSDSBis.EditValue = null;
            this.edtAusgangSDSBis.Location = new System.Drawing.Point(282, 278);
            this.edtAusgangSDSBis.Name = "edtAusgangSDSBis";
            this.edtAusgangSDSBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAusgangSDSBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusgangSDSBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusgangSDSBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusgangSDSBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusgangSDSBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusgangSDSBis.Properties.Appearance.Options.UseFont = true;
            this.edtAusgangSDSBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAusgangSDSBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAusgangSDSBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAusgangSDSBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusgangSDSBis.Properties.ShowToday = false;
            this.edtAusgangSDSBis.Size = new System.Drawing.Size(100, 24);
            this.edtAusgangSDSBis.TabIndex = 18;
            this.edtAusgangSDSBis.Visible = false;
            //
            // lblAusgangSDS
            //
            this.lblAusgangSDS.Location = new System.Drawing.Point(3, 278);
            this.lblAusgangSDS.Name = "lblAusgangSDS";
            this.lblAusgangSDS.Size = new System.Drawing.Size(105, 24);
            this.lblAusgangSDS.TabIndex = 17;
            this.lblAusgangSDS.Text = "Ausgang SDS von";
            this.lblAusgangSDS.UseCompatibleTextRendering = true;
            this.lblAusgangSDS.Visible = false;
            //
            // edtAusgangSDSVon
            //
            this.edtAusgangSDSVon.EditValue = null;
            this.edtAusgangSDSVon.Location = new System.Drawing.Point(122, 278);
            this.edtAusgangSDSVon.Name = "edtAusgangSDSVon";
            this.edtAusgangSDSVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAusgangSDSVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAusgangSDSVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusgangSDSVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusgangSDSVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusgangSDSVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusgangSDSVon.Properties.Appearance.Options.UseFont = true;
            this.edtAusgangSDSVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtAusgangSDSVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAusgangSDSVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtAusgangSDSVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAusgangSDSVon.Properties.ShowToday = false;
            this.edtAusgangSDSVon.Size = new System.Drawing.Size(100, 24);
            this.edtAusgangSDSVon.TabIndex = 16;
            this.edtAusgangSDSVon.Visible = false;
            //
            // edtMAKlibu
            //
            this.edtMAKlibu.DataMember = "Klient";
            this.edtMAKlibu.Location = new System.Drawing.Point(122, 310);
            this.edtMAKlibu.LookupSQL = "select null";
            this.edtMAKlibu.Name = "edtMAKlibu";
            this.edtMAKlibu.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMAKlibu.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMAKlibu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMAKlibu.Properties.Appearance.Options.UseBackColor = true;
            this.edtMAKlibu.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMAKlibu.Properties.Appearance.Options.UseFont = true;
            this.edtMAKlibu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtMAKlibu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtMAKlibu.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMAKlibu.Properties.Name = "editMandant.Properties";
            this.edtMAKlibu.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtMAKlibu.Size = new System.Drawing.Size(260, 24);
            this.edtMAKlibu.TabIndex = 20;
            this.edtMAKlibu.Visible = false;
            this.edtMAKlibu.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtMAKlibu_UserModifiedFld);
            //
            // lblMAKlibu
            //
            this.lblMAKlibu.Location = new System.Drawing.Point(3, 310);
            this.lblMAKlibu.Name = "lblMAKlibu";
            this.lblMAKlibu.Size = new System.Drawing.Size(105, 24);
            this.lblMAKlibu.TabIndex = 21;
            this.lblMAKlibu.Text = "MA Klibu";
            this.lblMAKlibu.UseCompatibleTextRendering = true;
            this.lblMAKlibu.Visible = false;
            //
            // edtInklHist
            //
            this.edtInklHist.EditValue = true;
            this.edtInklHist.Location = new System.Drawing.Point(123, 192);
            this.edtInklHist.Name = "edtInklHist";
            this.edtInklHist.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklHist.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklHist.Properties.Caption = "inkl. historisierte Berichte";
            this.edtInklHist.Size = new System.Drawing.Size(176, 19);
            this.edtInklHist.TabIndex = 22;
            //
            // edtInklAbgeschlosseneLeistungen
            //
            this.edtInklAbgeschlosseneLeistungen.EditValue = true;
            this.edtInklAbgeschlosseneLeistungen.Location = new System.Drawing.Point(123, 221);
            this.edtInklAbgeschlosseneLeistungen.Name = "edtInklAbgeschlosseneLeistungen";
            this.edtInklAbgeschlosseneLeistungen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInklAbgeschlosseneLeistungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtInklAbgeschlosseneLeistungen.Properties.Caption = "inkl. abgeschlossene Leistungen";
            this.edtInklAbgeschlosseneLeistungen.Size = new System.Drawing.Size(188, 19);
            this.edtInklAbgeschlosseneLeistungen.TabIndex = 23;
            //
            // CtlQueryFaBerichtsaufforderung
            //
            this.Name = "CtlQueryFaBerichtsaufforderung";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtFaelligBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklErstellte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingangSDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEingangSDSVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEingangSDSBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingangSDSBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgangSDSBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgangSDSBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgangSDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgangSDSVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMAKlibu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMAKlibu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklHist.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInklAbgeschlosseneLeistungen.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region EventHandlers

        private void btnSync_Click(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(ctlOrgUnitTeamUser.SucheUserID.EditValue))
            {
                if (KissMsg.ShowQuestion("Wollen Sie alle M-Leistungen im KiSS mit Daten aus VIS aktualisieren?\r\nZur Information: Dies kann u.U. mehrere Minuten gehen."))
                {
                    // Synchroniziere mit VIS, und zwar alle Leistungen
                    UtilsVIS.SyncVISToKiSS();
                }
            }
            else
            {
                if (KissMsg.ShowQuestion("Wollen Sie alle M-Leistungen des Mitarbeiters " + ctlOrgUnitTeamUser.SucheUserID.EditValue + " im KiSS mit Daten aus VIS aktualisieren?"))
                {
                    // Synchroniziere mit VIS, und zwar alle Leistungen des MA
                    UtilsVIS.SyncVISToKiSS(int.Parse(ctlOrgUnitTeamUser.SucheUserID.LookupID.ToString()), ctlOrgUnitTeamUser.SucheUserID.EditValue.ToString());
                }
            }
        }

        private void ctlOrgUnitTeamUser_UserModifiedFldMA(object sender, System.EventArgs e)
        {
            CheckUserModified();
        }

        private void ctlOrgUnitTeamUser_UserModifiedFldOE(object sender, System.EventArgs e)
        {
            CheckUserModified();
        }

        private void ctlOrgUnitTeamUser_UserModifiedFldTeam(object sender, System.EventArgs e)
        {
            CheckUserModified();
        }

        private void edtMAKlibu_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string SearchString = edtMAKlibu.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtMAKlibu.LookupID = null;
                    return;
                }
            }

            int SearchNr;
            bool suceeded = int.TryParse(SearchString, out SearchNr);

            string sql = @"
              SELECT distinct
                     ID$    = USRKlibu.UserID,
                     [Kürzel]   = USRKlibu.LogonName,
                     Name       = USRKlibu.NameVorname
              FROM   dbo.VmBericht BER WITH (READUNCOMMITTED)
                INNER JOIN  dbo.vwUser           USRKlibu  WITH (READUNCOMMITTED) ON USRKlibu.UserID = BER.MAKlibuUserID";

            if (SearchNr != 0)
                sql += " WHERE USRKlibu.UserID = {0} ORDER BY NameVorname";
            else
                sql += " WHERE USRKlibu.NameVorname LIKE '%' + {0} + '%' OR USRKlibu.LogonName LIKE '%' + {0} + '%' ORDER BY Name";

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(sql, SearchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtMAKlibu.EditValue = dlg["Kürzel"] + " - " + dlg["Name"];
                edtMAKlibu.LookupID = dlg[0];
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnSearch()
        {
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                foreach (Control ctl in UtilsGui.AllControls(tpgSuchen))
                {
                    if (ctl is KissButtonEdit)
                    {
                        KissButtonEdit edt = (KissButtonEdit)ctl;
                        edt.CheckPendingSearchValue();
                    }

                    if (ctl is CtlOrgUnitTeamUser)
                    {
                        ((CtlOrgUnitTeamUser)ctl).CheckPendingSearchValue();
                    }
                }
            }

            // Workaround um F3 weiter zu reichen, da das FrameWork das OrgUnitTeamUser UserControl nicht kennt
            if (ActiveControl is ContainerControl && ((ContainerControl)ActiveControl).ActiveControl.Equals(ctlOrgUnitTeamUser))
            {
                edtFaelligBis.Focus();
            }

            base.OnSearch();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            // Setze Checkbox für K-Finanzsupport
            bool finanzSupport = DBUtil.UserHasRight("CtlQueryFaBerichtsaufforderung_EnableFinanzsupportKFeatures");
            edtInklErstellte.Checked = finanzSupport;
            edtInklHist.Checked = finanzSupport;
            edtInklAbgeschlosseneLeistungen.Checked = finanzSupport;
            setDefaultMaKlibuUser();

            ctlOrgUnitTeamUser.NewSearch();

            CheckUserModified();

            edtFaelligBis.Focus();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            bool showKlibuFields = DBUtil.UserHasRight("CtlQueryFaBerichtsaufforderung_EnableFinanzsupportKFeatures");
            this.lblAusgangSDS.Visible = showKlibuFields;
            this.lblEingangSDS.Visible = showKlibuFields;
            this.lblEingangSDSBis.Visible = showKlibuFields;
            this.lblAusgangSDSBis.Visible = showKlibuFields;
            this.edtAusgangSDSBis.Visible = showKlibuFields;
            this.edtEingangSDSBis.Visible = showKlibuFields;
            this.edtAusgangSDSVon.Visible = showKlibuFields;
            this.edtEingangSDSVon.Visible = showKlibuFields;
            this.edtInklHist.Visible = showKlibuFields;
            this.edtInklAbgeschlosseneLeistungen.Visible = showKlibuFields;
            this.lblMAKlibu.Visible = showKlibuFields;
            this.edtMAKlibu.Visible = showKlibuFields;
            this.colEingangSDS.Visible = showKlibuFields;
            this.colAusgangSDS.Visible = showKlibuFields;
            this.colMAKlibu.Visible = showKlibuFields;
            this.colHistorisiert.Visible = showKlibuFields;
            this.ctlOrgUnitTeamUser.SetUserOnNewSearch = !showKlibuFields;
            if (!showKlibuFields)
            {
                this.ctlOrgUnitTeamUser.NewSearch();
            }
        }

        #endregion

        #region Private Methods

        private void CheckUserModified()
        {
            if (!DBUtil.IsEmpty(ctlOrgUnitTeamUser.SucheUserID.EditValue))
            {
                btnSync.Text = "Nur Fälle MA mit VIS synchronisieren ...";
            }
            else
            {
                btnSync.Text = "Alle Fälle SOD mit VIS synchronisieren ...";
            }
        }

        private void setDefaultMaKlibuUser()
        {
            if (DBUtil.UserHasRight("CtlQueryFaBerichtsaufforderung_EnableFinanzsupportKFeatures") &&
                (DBUtil.ExecuteScalarSQLThrowingException("SELECT TOP 1 MAKlibuUserID FROM dbo.VmBericht BER WITH (READUNCOMMITTED) WHERE MAKlibuUserID = {0}", Session.User.UserID) as int?).GetValueOrDefault(0) == Session.User.UserID)
            {
                this.edtMAKlibu.EditValue = Session.User.LastName + " - " + Session.User.LastFirstName;
                this.edtMAKlibu.LookupID = Session.User.UserID;
            }
        }

        #endregion

        #endregion
    }
}