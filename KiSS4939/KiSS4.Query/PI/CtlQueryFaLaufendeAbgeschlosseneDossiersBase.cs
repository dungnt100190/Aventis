using System;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.PI
{
    public class CtlQueryFaLaufendeAbgeschlosseneDossiersBase : KiSS4.Common.KissQueryControl
    {
        #region Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        // rights
        private Boolean _isChiefOrRepresentative = false; // store if sesssion user is chief or representative of current users' oe

        private Boolean _openCases = true; // store if only open or only closed cases have to be displayed

        // rights
        private String _rightNameKostenstelleHS = String.Empty; // store the name of the special right for KostenstelleHS

        private String _rightNameKostenstelleKGS = String.Empty; // store the name of the special right for KostenstelleKGS
        private Boolean _specialRightKostenstelleHS = false; // store if user has special rights to show all orgunits (Hauptsitz)
        private Boolean _specialRightKostenstelleKGS = false; // store if user has special rights to show all orgunits within its KGS

        // default search settings
        private Int32 _userOrgUnitID = -1; // store the user's orgunitid

        // others
        private Int32 _validateYear = -1; // store config value for validation year

        private KissCheckEdit chkSucheNurEndgueltigGeschlosseneDossiers;

        // controls/components
        private System.ComponentModel.IContainer components;

        private KissLookUpEdit edtSucheBSVBehinderungsart;
        private KissDateEdit edtSucheGeburtBis;
        private KissDateEdit edtSucheGeburtVon;
        private KissLookUpEdit edtSucheHauptbehinderungsart;
        private KissLookUpEdit edtSucheIVBerechtigung;
        private KiSS4.Gui.KissLookUpEdit edtSucheKostenstelle;
        private KiSS4.Gui.KissLookUpEdit edtSucheMitarbeiter;
        private KiSS4.Gui.KissDateEdit edtSucheZeitraumBis;
        private KiSS4.Gui.KissDateEdit edtSucheZeitraumVon;
        private KiSS4.Gui.KissGrid grdListe2Hauptbehinderung;
        private KiSS4.Gui.KissGrid grdListe3Mitarbeiter;
        private KiSS4.Gui.KissGrid grdListe4Kostenstelle;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe2Hauptbehinderung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe3Mitarbeiter;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListe4Kostenstelle;
        private KissLabel lblSucheBSVBehinderungsart;
        private KissLabel lblSucheGeburtBis;
        private KissLabel lblSucheGeburtVon;
        private KissLabel lblSucheHauptbehinderungsart;
        private KissLabel lblSucheIVBerechtigung;
        private KiSS4.Gui.KissLabel lblSucheKostenstelle;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheZeitraumBis;
        private KiSS4.Gui.KissLabel lblSucheZeitraumVon;
        private KiSS4.DB.SqlQuery qryListe2Hauptbehinderung;
        private KiSS4.DB.SqlQuery qryListe3Mitarbeiter;
        private KiSS4.DB.SqlQuery qryListe4Kostenstelle;
        private SharpLibrary.WinControls.TabPageEx tpgListe2;
        private SharpLibrary.WinControls.TabPageEx tpgListe3;
        private SharpLibrary.WinControls.TabPageEx tpgListe4;

        #endregion

        #region Constructors

        public CtlQueryFaLaufendeAbgeschlosseneDossiersBase()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryFaLaufendeAbgeschlosseneDossiersBase));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheKostenstelle = new KiSS4.Gui.KissLabel();
            this.edtSucheKostenstelle = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheZeitraumVon = new KiSS4.Gui.KissLabel();
            this.edtSucheZeitraumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheZeitraumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheZeitraumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.tpgListe4 = new SharpLibrary.WinControls.TabPageEx();
            this.grdListe4Kostenstelle = new KiSS4.Gui.KissGrid();
            this.qryListe4Kostenstelle = new KiSS4.DB.SqlQuery();
            this.grvListe4Kostenstelle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryListe3Mitarbeiter = new KiSS4.DB.SqlQuery();
            this.tpgListe2 = new SharpLibrary.WinControls.TabPageEx();
            this.grdListe2Hauptbehinderung = new KiSS4.Gui.KissGrid();
            this.qryListe2Hauptbehinderung = new KiSS4.DB.SqlQuery();
            this.grvListe2Hauptbehinderung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgListe3 = new SharpLibrary.WinControls.TabPageEx();
            this.grdListe3Mitarbeiter = new KiSS4.Gui.KissGrid();
            this.grvListe3Mitarbeiter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkSucheNurEndgueltigGeschlosseneDossiers = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheGeburtBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGeburtBis = new KiSS4.Gui.KissLabel();
            this.edtSucheGeburtVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGeburtVon = new KiSS4.Gui.KissLabel();
            this.edtSucheIVBerechtigung = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheIVBerechtigung = new KiSS4.Gui.KissLabel();
            this.edtSucheBSVBehinderungsart = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheBSVBehinderungsart = new KiSS4.Gui.KissLabel();
            this.edtSucheHauptbehinderungsart = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheHauptbehinderungsart = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
            this.tpgListe4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe4Kostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe4Kostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe4Kostenstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe3Mitarbeiter)).BeginInit();
            this.tpgListe2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2Hauptbehinderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2Hauptbehinderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2Hauptbehinderung)).BeginInit();
            this.tpgListe3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListe3Mitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe3Mitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurEndgueltigGeschlosseneDossiers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheIVBerechtigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheIVBerechtigung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheIVBerechtigung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBSVBehinderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBSVBehinderungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBSVBehinderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHauptbehinderungsart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHauptbehinderungsart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHauptbehinderungsart)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.FillTimeOut = 500;
            this.qryQuery.SelectStatement = "SELECT [Error] = \'no statement yet, done in code\', \r\n       [BaPersonID$] = NULL";
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
            this.grdQuery1.Location = new System.Drawing.Point(3, 3);
            this.grdQuery1.Size = new System.Drawing.Size(766, 389);
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(182, 398);
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
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 394);
            this.ctlGotoFall.ShowToolTipsOnIcons = true;
            this.ctlGotoFall.Size = new System.Drawing.Size(173, 27);
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(757, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Controls.Add(this.tpgListe2);
            this.tabControlSearch.Controls.Add(this.tpgListe3);
            this.tabControlSearch.Controls.Add(this.tpgListe4);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe2,
            this.tpgListe3,
            this.tpgListe4});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe4, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe3, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe2, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Title = "Klient/innen";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheGeburtBis);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtBis);
            this.tpgSuchen.Controls.Add(this.edtSucheGeburtVon);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtVon);
            this.tpgSuchen.Controls.Add(this.edtSucheIVBerechtigung);
            this.tpgSuchen.Controls.Add(this.lblSucheIVBerechtigung);
            this.tpgSuchen.Controls.Add(this.edtSucheBSVBehinderungsart);
            this.tpgSuchen.Controls.Add(this.lblSucheBSVBehinderungsart);
            this.tpgSuchen.Controls.Add(this.edtSucheHauptbehinderungsart);
            this.tpgSuchen.Controls.Add(this.lblSucheHauptbehinderungsart);
            this.tpgSuchen.Controls.Add(this.chkSucheNurEndgueltigGeschlosseneDossiers);
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheZeitraumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheZeitraumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheZeitraumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheZeitraumVon);
            this.tpgSuchen.Controls.Add(this.edtSucheKostenstelle);
            this.tpgSuchen.Controls.Add(this.lblSucheKostenstelle);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKostenstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurEndgueltigGeschlosseneDossiers, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheHauptbehinderungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheHauptbehinderungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBSVBehinderungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBSVBehinderungsart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheIVBerechtigung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheIVBerechtigung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGeburtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheGeburtBis, 0);
            //
            // lblSucheKostenstelle
            //
            this.lblSucheKostenstelle.Location = new System.Drawing.Point(31, 40);
            this.lblSucheKostenstelle.Name = "lblSucheKostenstelle";
            this.lblSucheKostenstelle.Size = new System.Drawing.Size(133, 24);
            this.lblSucheKostenstelle.TabIndex = 1;
            this.lblSucheKostenstelle.Text = "Kostenstelle";
            this.lblSucheKostenstelle.UseCompatibleTextRendering = true;
            //
            // edtSucheKostenstelle
            //
            this.edtSucheKostenstelle.Location = new System.Drawing.Point(170, 40);
            this.edtSucheKostenstelle.Name = "edtSucheKostenstelle";
            this.edtSucheKostenstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKostenstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKostenstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKostenstelle.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheKostenstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheKostenstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheKostenstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKostenstelle.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheKostenstelle.Properties.DisplayMember = "Text";
            this.edtSucheKostenstelle.Properties.NullText = "";
            this.edtSucheKostenstelle.Properties.ShowFooter = false;
            this.edtSucheKostenstelle.Properties.ShowHeader = false;
            this.edtSucheKostenstelle.Properties.ValueMember = "Code";
            this.edtSucheKostenstelle.Size = new System.Drawing.Size(244, 24);
            this.edtSucheKostenstelle.TabIndex = 2;
            //
            // lblSucheZeitraumVon
            //
            this.lblSucheZeitraumVon.Location = new System.Drawing.Point(31, 70);
            this.lblSucheZeitraumVon.Name = "lblSucheZeitraumVon";
            this.lblSucheZeitraumVon.Size = new System.Drawing.Size(133, 24);
            this.lblSucheZeitraumVon.TabIndex = 3;
            this.lblSucheZeitraumVon.Text = "Zeitraum von";
            this.lblSucheZeitraumVon.UseCompatibleTextRendering = true;
            //
            // edtSucheZeitraumVon
            //
            this.edtSucheZeitraumVon.EditValue = null;
            this.edtSucheZeitraumVon.Location = new System.Drawing.Point(170, 70);
            this.edtSucheZeitraumVon.Name = "edtSucheZeitraumVon";
            this.edtSucheZeitraumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheZeitraumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheZeitraumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheZeitraumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheZeitraumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheZeitraumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheZeitraumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheZeitraumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheZeitraumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheZeitraumVon.Properties.ShowToday = false;
            this.edtSucheZeitraumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheZeitraumVon.TabIndex = 4;
            //
            // lblSucheZeitraumBis
            //
            this.lblSucheZeitraumBis.Location = new System.Drawing.Point(276, 70);
            this.lblSucheZeitraumBis.Name = "lblSucheZeitraumBis";
            this.lblSucheZeitraumBis.Size = new System.Drawing.Size(32, 24);
            this.lblSucheZeitraumBis.TabIndex = 5;
            this.lblSucheZeitraumBis.Text = "bis";
            this.lblSucheZeitraumBis.UseCompatibleTextRendering = true;
            //
            // edtSucheZeitraumBis
            //
            this.edtSucheZeitraumBis.EditValue = null;
            this.edtSucheZeitraumBis.Location = new System.Drawing.Point(314, 70);
            this.edtSucheZeitraumBis.Name = "edtSucheZeitraumBis";
            this.edtSucheZeitraumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheZeitraumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheZeitraumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheZeitraumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheZeitraumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheZeitraumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheZeitraumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheZeitraumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheZeitraumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheZeitraumBis.Properties.ShowToday = false;
            this.edtSucheZeitraumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheZeitraumBis.TabIndex = 6;
            //
            // lblSucheMitarbeiter
            //
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(31, 100);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(133, 24);
            this.lblSucheMitarbeiter.TabIndex = 7;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            //
            // edtSucheMitarbeiter
            //
            this.edtSucheMitarbeiter.Location = new System.Drawing.Point(170, 100);
            this.edtSucheMitarbeiter.Name = "edtSucheMitarbeiter";
            this.edtSucheMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheMitarbeiter.Properties.DisplayMember = "Text";
            this.edtSucheMitarbeiter.Properties.NullText = "";
            this.edtSucheMitarbeiter.Properties.ShowFooter = false;
            this.edtSucheMitarbeiter.Properties.ShowHeader = false;
            this.edtSucheMitarbeiter.Properties.ValueMember = "Code";
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(244, 24);
            this.edtSucheMitarbeiter.TabIndex = 8;
            //
            // tpgListe4
            //
            this.tpgListe4.Controls.Add(this.grdListe4Kostenstelle);
            this.tpgListe4.Location = new System.Drawing.Point(6, 6);
            this.tpgListe4.Name = "tpgListe4";
            this.tpgListe4.Size = new System.Drawing.Size(772, 424);
            this.tpgListe4.TabIndex = 1;
            this.tpgListe4.Title = "Kostenstelle";
            //
            // grdListe4Kostenstelle
            //
            this.grdListe4Kostenstelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe4Kostenstelle.DataSource = this.qryListe4Kostenstelle;
            //
            //
            //
            this.grdListe4Kostenstelle.EmbeddedNavigator.Name = "";
            this.grdListe4Kostenstelle.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe4Kostenstelle.Location = new System.Drawing.Point(3, 3);
            this.grdListe4Kostenstelle.MainView = this.grvListe4Kostenstelle;
            this.grdListe4Kostenstelle.Name = "grdListe4Kostenstelle";
            this.grdListe4Kostenstelle.Size = new System.Drawing.Size(766, 418);
            this.grdListe4Kostenstelle.TabIndex = 0;
            this.grdListe4Kostenstelle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListe4Kostenstelle});
            //
            // qryListe4Kostenstelle
            //
            this.qryListe4Kostenstelle.FillTimeOut = 500;
            this.qryListe4Kostenstelle.HostControl = this;
            this.qryListe4Kostenstelle.IsIdentityInsert = false;
            this.qryListe4Kostenstelle.SelectStatement = "SELECT [Error] = \'no statement yet, done in code\', \r\n       [BaPersonID$] = NULL";
            //
            // grvListe4Kostenstelle
            //
            this.grvListe4Kostenstelle.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe4Kostenstelle.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe4Kostenstelle.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe4Kostenstelle.Appearance.Empty.Options.UseFont = true;
            this.grvListe4Kostenstelle.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe4Kostenstelle.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe4Kostenstelle.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe4Kostenstelle.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe4Kostenstelle.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe4Kostenstelle.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe4Kostenstelle.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe4Kostenstelle.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe4Kostenstelle.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe4Kostenstelle.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe4Kostenstelle.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe4Kostenstelle.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe4Kostenstelle.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe4Kostenstelle.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe4Kostenstelle.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe4Kostenstelle.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe4Kostenstelle.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvListe4Kostenstelle.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvListe4Kostenstelle.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe4Kostenstelle.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe4Kostenstelle.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe4Kostenstelle.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe4Kostenstelle.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe4Kostenstelle.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe4Kostenstelle.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe4Kostenstelle.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe4Kostenstelle.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe4Kostenstelle.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe4Kostenstelle.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe4Kostenstelle.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe4Kostenstelle.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe4Kostenstelle.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe4Kostenstelle.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe4Kostenstelle.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe4Kostenstelle.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe4Kostenstelle.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe4Kostenstelle.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe4Kostenstelle.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe4Kostenstelle.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe4Kostenstelle.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe4Kostenstelle.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe4Kostenstelle.Appearance.OddRow.Options.UseFont = true;
            this.grvListe4Kostenstelle.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe4Kostenstelle.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe4Kostenstelle.Appearance.Row.Options.UseBackColor = true;
            this.grvListe4Kostenstelle.Appearance.Row.Options.UseFont = true;
            this.grvListe4Kostenstelle.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe4Kostenstelle.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe4Kostenstelle.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe4Kostenstelle.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe4Kostenstelle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe4Kostenstelle.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe4Kostenstelle.GridControl = this.grdListe4Kostenstelle;
            this.grvListe4Kostenstelle.Name = "grvListe4Kostenstelle";
            this.grvListe4Kostenstelle.OptionsBehavior.Editable = false;
            this.grvListe4Kostenstelle.OptionsCustomization.AllowFilter = false;
            this.grvListe4Kostenstelle.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe4Kostenstelle.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe4Kostenstelle.OptionsNavigation.UseTabKey = false;
            this.grvListe4Kostenstelle.OptionsView.ColumnAutoWidth = false;
            this.grvListe4Kostenstelle.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe4Kostenstelle.OptionsView.ShowGroupPanel = false;
            this.grvListe4Kostenstelle.OptionsView.ShowIndicator = false;
            //
            // qryListe3Mitarbeiter
            //
            this.qryListe3Mitarbeiter.FillTimeOut = 500;
            this.qryListe3Mitarbeiter.HostControl = this;
            this.qryListe3Mitarbeiter.IsIdentityInsert = false;
            this.qryListe3Mitarbeiter.SelectStatement = "SELECT [Error] = \'no statement yet, done in code\', \r\n       [BaPersonID$] = NULL";
            //
            // tpgListe2
            //
            this.tpgListe2.Controls.Add(this.grdListe2Hauptbehinderung);
            this.tpgListe2.Location = new System.Drawing.Point(6, 6);
            this.tpgListe2.Name = "tpgListe2";
            this.tpgListe2.Size = new System.Drawing.Size(772, 424);
            this.tpgListe2.TabIndex = 2;
            this.tpgListe2.Title = "Hauptbehinderung";
            //
            // grdListe2Hauptbehinderung
            //
            this.grdListe2Hauptbehinderung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe2Hauptbehinderung.DataSource = this.qryListe2Hauptbehinderung;
            //
            //
            //
            this.grdListe2Hauptbehinderung.EmbeddedNavigator.Name = "";
            this.grdListe2Hauptbehinderung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe2Hauptbehinderung.Location = new System.Drawing.Point(3, 3);
            this.grdListe2Hauptbehinderung.MainView = this.grvListe2Hauptbehinderung;
            this.grdListe2Hauptbehinderung.Name = "grdListe2Hauptbehinderung";
            this.grdListe2Hauptbehinderung.Size = new System.Drawing.Size(766, 418);
            this.grdListe2Hauptbehinderung.TabIndex = 0;
            this.grdListe2Hauptbehinderung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListe2Hauptbehinderung});
            //
            // qryListe2Hauptbehinderung
            //
            this.qryListe2Hauptbehinderung.FillTimeOut = 500;
            this.qryListe2Hauptbehinderung.HostControl = this;
            this.qryListe2Hauptbehinderung.IsIdentityInsert = false;
            this.qryListe2Hauptbehinderung.SelectStatement = "SELECT [Error] = \'no statement yet, done in code\', \r\n       [BaPersonID$] = NULL";
            //
            // grvListe2Hauptbehinderung
            //
            this.grvListe2Hauptbehinderung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe2Hauptbehinderung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Hauptbehinderung.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe2Hauptbehinderung.Appearance.Empty.Options.UseFont = true;
            this.grvListe2Hauptbehinderung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Hauptbehinderung.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe2Hauptbehinderung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2Hauptbehinderung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Hauptbehinderung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe2Hauptbehinderung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe2Hauptbehinderung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe2Hauptbehinderung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe2Hauptbehinderung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe2Hauptbehinderung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Hauptbehinderung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe2Hauptbehinderung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe2Hauptbehinderung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe2Hauptbehinderung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe2Hauptbehinderung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2Hauptbehinderung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe2Hauptbehinderung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvListe2Hauptbehinderung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvListe2Hauptbehinderung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2Hauptbehinderung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe2Hauptbehinderung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe2Hauptbehinderung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2Hauptbehinderung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2Hauptbehinderung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe2Hauptbehinderung.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe2Hauptbehinderung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe2Hauptbehinderung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe2Hauptbehinderung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe2Hauptbehinderung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe2Hauptbehinderung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe2Hauptbehinderung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe2Hauptbehinderung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe2Hauptbehinderung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe2Hauptbehinderung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Hauptbehinderung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe2Hauptbehinderung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe2Hauptbehinderung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe2Hauptbehinderung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe2Hauptbehinderung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2Hauptbehinderung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe2Hauptbehinderung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Hauptbehinderung.Appearance.OddRow.Options.UseFont = true;
            this.grvListe2Hauptbehinderung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe2Hauptbehinderung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Hauptbehinderung.Appearance.Row.Options.UseBackColor = true;
            this.grvListe2Hauptbehinderung.Appearance.Row.Options.UseFont = true;
            this.grvListe2Hauptbehinderung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe2Hauptbehinderung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe2Hauptbehinderung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe2Hauptbehinderung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe2Hauptbehinderung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe2Hauptbehinderung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe2Hauptbehinderung.GridControl = this.grdListe2Hauptbehinderung;
            this.grvListe2Hauptbehinderung.Name = "grvListe2Hauptbehinderung";
            this.grvListe2Hauptbehinderung.OptionsBehavior.Editable = false;
            this.grvListe2Hauptbehinderung.OptionsCustomization.AllowFilter = false;
            this.grvListe2Hauptbehinderung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe2Hauptbehinderung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe2Hauptbehinderung.OptionsNavigation.UseTabKey = false;
            this.grvListe2Hauptbehinderung.OptionsView.ColumnAutoWidth = false;
            this.grvListe2Hauptbehinderung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe2Hauptbehinderung.OptionsView.ShowGroupPanel = false;
            this.grvListe2Hauptbehinderung.OptionsView.ShowIndicator = false;
            //
            // tpgListe3
            //
            this.tpgListe3.Controls.Add(this.grdListe3Mitarbeiter);
            this.tpgListe3.Location = new System.Drawing.Point(6, 6);
            this.tpgListe3.Name = "tpgListe3";
            this.tpgListe3.Size = new System.Drawing.Size(772, 424);
            this.tpgListe3.TabIndex = 5;
            this.tpgListe3.Title = "Mitarbeiter/innen";
            //
            // grdListe3Mitarbeiter
            //
            this.grdListe3Mitarbeiter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListe3Mitarbeiter.DataSource = this.qryListe3Mitarbeiter;
            //
            //
            //
            this.grdListe3Mitarbeiter.EmbeddedNavigator.Name = "";
            this.grdListe3Mitarbeiter.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdListe3Mitarbeiter.Location = new System.Drawing.Point(3, 3);
            this.grdListe3Mitarbeiter.MainView = this.grvListe3Mitarbeiter;
            this.grdListe3Mitarbeiter.Name = "grdListe3Mitarbeiter";
            this.grdListe3Mitarbeiter.Size = new System.Drawing.Size(766, 418);
            this.grdListe3Mitarbeiter.TabIndex = 0;
            this.grdListe3Mitarbeiter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListe3Mitarbeiter});
            //
            // grvListe3Mitarbeiter
            //
            this.grvListe3Mitarbeiter.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvListe3Mitarbeiter.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3Mitarbeiter.Appearance.Empty.Options.UseBackColor = true;
            this.grvListe3Mitarbeiter.Appearance.Empty.Options.UseFont = true;
            this.grvListe3Mitarbeiter.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3Mitarbeiter.Appearance.EvenRow.Options.UseFont = true;
            this.grvListe3Mitarbeiter.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe3Mitarbeiter.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3Mitarbeiter.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvListe3Mitarbeiter.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvListe3Mitarbeiter.Appearance.FocusedCell.Options.UseFont = true;
            this.grvListe3Mitarbeiter.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvListe3Mitarbeiter.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvListe3Mitarbeiter.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3Mitarbeiter.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvListe3Mitarbeiter.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvListe3Mitarbeiter.Appearance.FocusedRow.Options.UseFont = true;
            this.grvListe3Mitarbeiter.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvListe3Mitarbeiter.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe3Mitarbeiter.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe3Mitarbeiter.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvListe3Mitarbeiter.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvListe3Mitarbeiter.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe3Mitarbeiter.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvListe3Mitarbeiter.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvListe3Mitarbeiter.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe3Mitarbeiter.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe3Mitarbeiter.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvListe3Mitarbeiter.Appearance.GroupRow.Options.UseFont = true;
            this.grvListe3Mitarbeiter.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvListe3Mitarbeiter.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvListe3Mitarbeiter.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvListe3Mitarbeiter.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvListe3Mitarbeiter.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvListe3Mitarbeiter.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvListe3Mitarbeiter.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvListe3Mitarbeiter.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvListe3Mitarbeiter.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3Mitarbeiter.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvListe3Mitarbeiter.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvListe3Mitarbeiter.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvListe3Mitarbeiter.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvListe3Mitarbeiter.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe3Mitarbeiter.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvListe3Mitarbeiter.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3Mitarbeiter.Appearance.OddRow.Options.UseFont = true;
            this.grvListe3Mitarbeiter.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvListe3Mitarbeiter.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3Mitarbeiter.Appearance.Row.Options.UseBackColor = true;
            this.grvListe3Mitarbeiter.Appearance.Row.Options.UseFont = true;
            this.grvListe3Mitarbeiter.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvListe3Mitarbeiter.Appearance.SelectedRow.Options.UseFont = true;
            this.grvListe3Mitarbeiter.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvListe3Mitarbeiter.Appearance.VertLine.Options.UseBackColor = true;
            this.grvListe3Mitarbeiter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvListe3Mitarbeiter.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvListe3Mitarbeiter.GridControl = this.grdListe3Mitarbeiter;
            this.grvListe3Mitarbeiter.Name = "grvListe3Mitarbeiter";
            this.grvListe3Mitarbeiter.OptionsBehavior.Editable = false;
            this.grvListe3Mitarbeiter.OptionsCustomization.AllowFilter = false;
            this.grvListe3Mitarbeiter.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvListe3Mitarbeiter.OptionsNavigation.AutoFocusNewRow = true;
            this.grvListe3Mitarbeiter.OptionsNavigation.UseTabKey = false;
            this.grvListe3Mitarbeiter.OptionsView.ColumnAutoWidth = false;
            this.grvListe3Mitarbeiter.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvListe3Mitarbeiter.OptionsView.ShowGroupPanel = false;
            this.grvListe3Mitarbeiter.OptionsView.ShowIndicator = false;
            //
            // chkSucheNurEndgueltigGeschlosseneDossiers
            //
            this.chkSucheNurEndgueltigGeschlosseneDossiers.EditValue = false;
            this.chkSucheNurEndgueltigGeschlosseneDossiers.Location = new System.Drawing.Point(170, 250);
            this.chkSucheNurEndgueltigGeschlosseneDossiers.Name = "chkSucheNurEndgueltigGeschlosseneDossiers";
            this.chkSucheNurEndgueltigGeschlosseneDossiers.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkSucheNurEndgueltigGeschlosseneDossiers.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurEndgueltigGeschlosseneDossiers.Properties.Appearance.Options.UseTextOptions = true;
            this.chkSucheNurEndgueltigGeschlosseneDossiers.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.chkSucheNurEndgueltigGeschlosseneDossiers.Properties.AutoHeight = false;
            this.chkSucheNurEndgueltigGeschlosseneDossiers.Properties.Caption = "Nur endgültig abgeschlossene Dossiers   (ohne spätere Wiederaufnahme)";
            this.chkSucheNurEndgueltigGeschlosseneDossiers.Size = new System.Drawing.Size(244, 38);
            this.chkSucheNurEndgueltigGeschlosseneDossiers.TabIndex = 9;
            //
            // edtSucheGeburtBis
            //
            this.edtSucheGeburtBis.EditValue = null;
            this.edtSucheGeburtBis.Location = new System.Drawing.Point(314, 220);
            this.edtSucheGeburtBis.Name = "edtSucheGeburtBis";
            this.edtSucheGeburtBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGeburtBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGeburtBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGeburtBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGeburtBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGeburtBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGeburtBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGeburtBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheGeburtBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGeburtBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheGeburtBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGeburtBis.Properties.ShowToday = false;
            this.edtSucheGeburtBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheGeburtBis.TabIndex = 28;
            //
            // lblSucheGeburtBis
            //
            this.lblSucheGeburtBis.Location = new System.Drawing.Point(276, 220);
            this.lblSucheGeburtBis.Name = "lblSucheGeburtBis";
            this.lblSucheGeburtBis.Size = new System.Drawing.Size(32, 24);
            this.lblSucheGeburtBis.TabIndex = 27;
            this.lblSucheGeburtBis.Text = "bis";
            this.lblSucheGeburtBis.UseCompatibleTextRendering = true;
            //
            // edtSucheGeburtVon
            //
            this.edtSucheGeburtVon.EditValue = null;
            this.edtSucheGeburtVon.Location = new System.Drawing.Point(170, 220);
            this.edtSucheGeburtVon.Name = "edtSucheGeburtVon";
            this.edtSucheGeburtVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheGeburtVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheGeburtVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheGeburtVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheGeburtVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheGeburtVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheGeburtVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheGeburtVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheGeburtVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheGeburtVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheGeburtVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheGeburtVon.Properties.ShowToday = false;
            this.edtSucheGeburtVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheGeburtVon.TabIndex = 26;
            //
            // lblSucheGeburtVon
            //
            this.lblSucheGeburtVon.Location = new System.Drawing.Point(31, 220);
            this.lblSucheGeburtVon.Name = "lblSucheGeburtVon";
            this.lblSucheGeburtVon.Size = new System.Drawing.Size(133, 24);
            this.lblSucheGeburtVon.TabIndex = 25;
            this.lblSucheGeburtVon.Text = "Geburt von";
            this.lblSucheGeburtVon.UseCompatibleTextRendering = true;
            //
            // edtSucheIVBerechtigung
            //
            this.edtSucheIVBerechtigung.Location = new System.Drawing.Point(170, 190);
            this.edtSucheIVBerechtigung.LOVFilter = "CODE IN (1,3)";
            this.edtSucheIVBerechtigung.LOVFilterWhereAppend = true;
            this.edtSucheIVBerechtigung.LOVName = "BaIVBerechtigung";
            this.edtSucheIVBerechtigung.Name = "edtSucheIVBerechtigung";
            this.edtSucheIVBerechtigung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheIVBerechtigung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheIVBerechtigung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheIVBerechtigung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheIVBerechtigung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheIVBerechtigung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheIVBerechtigung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheIVBerechtigung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheIVBerechtigung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheIVBerechtigung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheIVBerechtigung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheIVBerechtigung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheIVBerechtigung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheIVBerechtigung.Properties.NullText = "";
            this.edtSucheIVBerechtigung.Properties.ShowFooter = false;
            this.edtSucheIVBerechtigung.Properties.ShowHeader = false;
            this.edtSucheIVBerechtigung.Size = new System.Drawing.Size(244, 24);
            this.edtSucheIVBerechtigung.TabIndex = 24;
            //
            // lblSucheIVBerechtigung
            //
            this.lblSucheIVBerechtigung.Location = new System.Drawing.Point(31, 190);
            this.lblSucheIVBerechtigung.Name = "lblSucheIVBerechtigung";
            this.lblSucheIVBerechtigung.Size = new System.Drawing.Size(133, 24);
            this.lblSucheIVBerechtigung.TabIndex = 23;
            this.lblSucheIVBerechtigung.Text = "IV-Berechtigung";
            this.lblSucheIVBerechtigung.UseCompatibleTextRendering = true;
            //
            // edtSucheBSVBehinderungsart
            //
            this.edtSucheBSVBehinderungsart.Location = new System.Drawing.Point(170, 160);
            this.edtSucheBSVBehinderungsart.LOVName = "BaBSVBehinderungsart";
            this.edtSucheBSVBehinderungsart.Name = "edtSucheBSVBehinderungsart";
            this.edtSucheBSVBehinderungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBSVBehinderungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBSVBehinderungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBSVBehinderungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBSVBehinderungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBSVBehinderungsart.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBSVBehinderungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheBSVBehinderungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBSVBehinderungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheBSVBehinderungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheBSVBehinderungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheBSVBehinderungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheBSVBehinderungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBSVBehinderungsart.Properties.NullText = "";
            this.edtSucheBSVBehinderungsart.Properties.ShowFooter = false;
            this.edtSucheBSVBehinderungsart.Properties.ShowHeader = false;
            this.edtSucheBSVBehinderungsart.Size = new System.Drawing.Size(244, 24);
            this.edtSucheBSVBehinderungsart.TabIndex = 22;
            //
            // lblSucheBSVBehinderungsart
            //
            this.lblSucheBSVBehinderungsart.Location = new System.Drawing.Point(31, 160);
            this.lblSucheBSVBehinderungsart.Name = "lblSucheBSVBehinderungsart";
            this.lblSucheBSVBehinderungsart.Size = new System.Drawing.Size(133, 24);
            this.lblSucheBSVBehinderungsart.TabIndex = 21;
            this.lblSucheBSVBehinderungsart.Text = "BSV-Behinderungsart";
            this.lblSucheBSVBehinderungsart.UseCompatibleTextRendering = true;
            //
            // edtSucheHauptbehinderungsart
            //
            this.edtSucheHauptbehinderungsart.Location = new System.Drawing.Point(170, 130);
            this.edtSucheHauptbehinderungsart.LOVName = "BaBehinderungsart";
            this.edtSucheHauptbehinderungsart.Name = "edtSucheHauptbehinderungsart";
            this.edtSucheHauptbehinderungsart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheHauptbehinderungsart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheHauptbehinderungsart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheHauptbehinderungsart.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheHauptbehinderungsart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheHauptbehinderungsart.Properties.Appearance.Options.UseFont = true;
            this.edtSucheHauptbehinderungsart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheHauptbehinderungsart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheHauptbehinderungsart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheHauptbehinderungsart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheHauptbehinderungsart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtSucheHauptbehinderungsart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtSucheHauptbehinderungsart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheHauptbehinderungsart.Properties.NullText = "";
            this.edtSucheHauptbehinderungsart.Properties.ShowFooter = false;
            this.edtSucheHauptbehinderungsart.Properties.ShowHeader = false;
            this.edtSucheHauptbehinderungsart.Size = new System.Drawing.Size(244, 24);
            this.edtSucheHauptbehinderungsart.TabIndex = 20;
            //
            // lblSucheHauptbehinderungsart
            //
            this.lblSucheHauptbehinderungsart.Location = new System.Drawing.Point(31, 130);
            this.lblSucheHauptbehinderungsart.Name = "lblSucheHauptbehinderungsart";
            this.lblSucheHauptbehinderungsart.Size = new System.Drawing.Size(133, 24);
            this.lblSucheHauptbehinderungsart.TabIndex = 19;
            this.lblSucheHauptbehinderungsart.Text = "Hauptbehinderungsart";
            this.lblSucheHauptbehinderungsart.UseCompatibleTextRendering = true;
            //
            // CtlQueryFaLaufendeAbgeschlosseneDossiersBase
            //
            this.Name = "CtlQueryFaLaufendeAbgeschlosseneDossiersBase";
            this.Load += new System.EventHandler(this.CtlQueryBaLaufendeAbgeschlosseneDossiersBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheZeitraumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheZeitraumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).EndInit();
            this.tpgListe4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe4Kostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe4Kostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe4Kostenstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe3Mitarbeiter)).EndInit();
            this.tpgListe2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe2Hauptbehinderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2Hauptbehinderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe2Hauptbehinderung)).EndInit();
            this.tpgListe3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdListe3Mitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListe3Mitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurEndgueltigGeschlosseneDossiers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheGeburtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheIVBerechtigung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheIVBerechtigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheIVBerechtigung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBSVBehinderungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBSVBehinderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBSVBehinderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHauptbehinderungsart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheHauptbehinderungsart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheHauptbehinderungsart)).EndInit();
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

        #region Internal Properties

        /// <summary>
        /// Get and set the visible state of checkbox [chkSucheNurEndgueltigGeschlosseneDossiers]
        /// </summary>
        internal Boolean ChkSucheNurEndgueltigGeschlosseneDossiersVisible
        {
            get { return this.chkSucheNurEndgueltigGeschlosseneDossiers.Visible; }
            set { this.chkSucheNurEndgueltigGeschlosseneDossiers.Visible = value; }
        }

        /// <summary>
        /// Set and get if only open or only closed cases have to be displayed in result grids
        /// </summary>
        internal Boolean OpenCases
        {
            get { return this._openCases; }
            set { this._openCases = value; }
        }

        /// <summary>
        /// Get and set the name of the special right for KostenstelleHS
        /// </summary>
        internal String RightNameKostenstelleHS
        {
            get
            {
                // validate
                if (String.IsNullOrEmpty(this._rightNameKostenstelleHS))
                {
                    throw new ArgumentNullException("The value was not set and cannot be returned therefore.");
                }

                // return value
                return this._rightNameKostenstelleHS;
            }
            set
            {
                // set the given value as property
                this._rightNameKostenstelleHS = value;
            }
        }

        /// <summary>
        /// Get and set the name of the special right for KostenstelleKGS
        /// </summary>
        internal String RightNameKostenstelleKGS
        {
            get
            {
                // validate
                if (String.IsNullOrEmpty(this._rightNameKostenstelleKGS))
                {
                    throw new ArgumentNullException("The value was not set and cannot be returned therefore.");
                }

                // return value
                return this._rightNameKostenstelleKGS;
            }
            set
            {
                // set the given value as property
                this._rightNameKostenstelleKGS = value;
            }
        }

        #endregion

        #region Public Methods

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // do sorting of LOVs
            edtSucheHauptbehinderungsart.SortByFirstColumn();
            edtSucheBSVBehinderungsart.SortByFirstColumn();

            // setup titles
            tpgListe.Title = KissMsg.GetMLMessage("CtlQueryBaLaufendeAbgeschlosseneDossiersBase", "Liste1TitelKlient", "Klient/innen");
            tpgListe2.Title = KissMsg.GetMLMessage("CtlQueryBaLaufendeAbgeschlosseneDossiersBase", "Liste2TitelHauptbehinderung", "Hauptbehinderung");
            tpgListe3.Title = KissMsg.GetMLMessage("CtlQueryBaLaufendeAbgeschlosseneDossiersBase", "Liste3TitelMitarbeiter", "Mitarbeiter/innen");
            tpgListe4.Title = KissMsg.GetMLMessage("CtlQueryBaLaufendeAbgeschlosseneDossiersBase", "Liste4TitelKostenstelle", "Kostenstelle");
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // apply rights and default search parameters
            QryUtils.NewSearchMitarbeiter(this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, this._isChiefOrRepresentative, edtSucheMitarbeiter);

            // default Kostenstelle (for all users the same way)
            edtSucheKostenstelle.EditValue = this._userOrgUnitID;

            // date range
            edtSucheZeitraumBis.EditValue = DateTime.Today;
            this.SetupSucheZeitraumVonDate();

            // set focus
            edtSucheKostenstelle.Focus();
        }

        protected override void RunSearch()
        {
            // validate Kostenstelle and Mitarbeiter
            QryUtils.RunSearchValidateKstMa(this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, edtSucheKostenstelle, edtSucheMitarbeiter);

            // validate dates
            if (DBUtil.IsEmpty(edtSucheZeitraumVon.EditValue))
            {
                // DatumVon is required
                KissMsg.ShowInfo("CtlQueryBaLaufendeAbgeschlosseneDossiersBase", "RequiredSearchZeitraumVon_v01", "Das Feld 'Zeitraum von' wird für die Suche benötigt!");
                edtSucheZeitraumVon.Focus();

                throw new KissCancelException();
            }

            if (DBUtil.IsEmpty(edtSucheZeitraumBis.EditValue))
            {
                // DatumBis is required
                KissMsg.ShowInfo("CtlQueryBaLaufendeAbgeschlosseneDossiersBase", "RequiredSearchZeitraumBis", "Das Feld 'Zeitraum bis' wird für die Suche benötigt!");
                edtSucheZeitraumBis.Focus();

                throw new KissCancelException();
            }

            // validate dates
            if (Convert.ToDateTime(edtSucheZeitraumVon.EditValue).Year < this._validateYear || Convert.ToDateTime(edtSucheZeitraumBis.EditValue).Year < this._validateYear)
            {
                // year cannot be smaller than config value
                KissMsg.ShowInfo("CtlQueryBaLaufendeAbgeschlosseneDossiersBase", "RequiredSearchDatesInvalid_v01", "Das Jahr von 'Zeitraum von' oder 'Zeitraum bis' darf nicht kleiner als '{0}' sein!", 0, 0, this._validateYear);
                edtSucheZeitraumVon.Focus();

                throw new KissCancelException();
            }

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CtlQueryBaLaufendeAbgeschlosseneDossiersBase_Load(object sender, System.EventArgs e)
        {
            // check if designer
            if (DesignerMode)
            {
                // currently in designer, do nothing
                return;
            }

            // logging
            logger.Debug("enter");
            logger.DebugFormat("RightNameKostenstelleHS='{0}', RightNameKostenstelleKGS='{1}', OpenCases='{2}'", this.RightNameKostenstelleHS, this.RightNameKostenstelleKGS, this.OpenCases);

            // SETTINGS
            this._validateYear = 2000;  // manually, none before year 2k

            // validate
            if (this._validateYear < 2000)
            {
                // invalid value, do not continue
                throw new ArgumentOutOfRangeException("Invalid configuration value for year-validation, cannot continue.");
            }

            // DEFAULT VALUES:
            // get users member orgunit
            this._userOrgUnitID = QryUtils.GetOrgUnitOfUser(Session.User.UserID);

            // RIGHTS:
            // get if user has special right to select specified Kostenstelle/MA
            this._specialRightKostenstelleHS = DBUtil.UserHasRight(this.RightNameKostenstelleHS);
            this._specialRightKostenstelleKGS = DBUtil.UserHasRight(this.RightNameKostenstelleKGS);

            // get if user is zle chief or representative of ANY orgunit
            this._isChiefOrRepresentative = QryUtils.IsChiefOrRepresentative(Session.User.UserID, -1);

            // logging
            logger.Debug(String.Format("SpecialRightKostenstelleHS={0}, SpecialRightKostenstelleKGS={1}, IsChiefOrRepresentative={2}", this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, this._isChiefOrRepresentative));

            // SEARCH:
            // fill dropdowns data, depending on rights
            BDEUtils.InitKostenstelleDropDown(Session.User.UserID, this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, edtSucheKostenstelle);
            BDEUtils.InitMitarbeiterDropDown(Session.User.UserID, this._specialRightKostenstelleHS, this._specialRightKostenstelleKGS, this._isChiefOrRepresentative, edtSucheMitarbeiter);

            // QUERIES:
            this.SetupSqlQuery(qryQuery, "klient");
            this.SetupSqlQuery(qryListe2Hauptbehinderung, "hauptbehinderung");
            this.SetupSqlQuery(qryListe3Mitarbeiter, "mitarbeiter");
            this.SetupSqlQuery(qryListe4Kostenstelle, "kostenstelle");

            // INIT
            // start with new search
            this.NewSearch();

            // logging
            logger.Debug("done");
        }

        private void SetupSqlQuery(SqlQuery qry, String resultTable)
        {
            qry.SelectStatement = @"
                    -- declare vars
                    DECLARE @OrgUnitID INT
                    DECLARE @ZeitraumBis DATETIME
                    DECLARE @ZeitraumVon DATETIME
                    DECLARE @UserID INT
                    DECLARE @HauptbehinderungsartCode INT
                    DECLARE @BSVBehinderungsartCode INT
                    DECLARE @IVBerechtigungsCode INT
                    DECLARE @GeburtVon DATETIME
                    DECLARE @GeburtBis DATETIME
                    DECLARE @OnlyWithNoFollowingFV BIT

                    -- fill vars with search parameters (if value is given)
                    --- SET @OrgUnitID                = {edtSucheKostenstelle}
                    --- SET @ZeitraumVon              = {edtSucheZeitraumVon}
                    --- SET @ZeitraumBis              = {edtSucheZeitraumBis}
                    --- SET @UserID                   = {edtSucheMitarbeiter}
                    --- SET @HauptbehinderungsartCode = {edtSucheHauptbehinderungsart}
                    --- SET @BSVBehinderungsartCode   = {edtSucheBSVBehinderungsart}
                    --- SET @IVBerechtigungsCode      = {edtSucheIVBerechtigung}
                    --- SET @GeburtVon                = {edtSucheGeburtVon}
                    --- SET @GeburtBis                = {edtSucheGeburtBis}
                    --- SET @OnlyWithNoFollowingFV    = {chkSucheNurEndgueltigGeschlosseneDossiers.Checked}

                    -- default if not set
                    SET @OnlyWithNoFollowingFV = ISNULL(@OnlyWithNoFollowingFV, 0)

                    -- run statement
                    EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers " + Convert.ToString(Session.User.LanguageCode) + @",
                                                                 @OrgUnitID,
                                                                 @ZeitraumVon,
                                                                 @ZeitraumBis,
                                                                 @UserID,
                                                                 @HauptbehinderungsartCode,
                                                                 @BSVBehinderungsartCode,
                                                                 @IVBerechtigungsCode,
                                                                 @GeburtVon,
                                                                 @GeburtBis,
                                                                 '" + resultTable + @"',
                                                                 " + Convert.ToString(Session.User.UserID) + @",
                                                                 " + (this._specialRightKostenstelleHS ? "1" : "0") + @",
                                                                 " + (this._specialRightKostenstelleKGS ? "1" : "0") + @",
                                                                 " + (this.OpenCases ? "1" : "0") + @",
                                                                 @OnlyWithNoFollowingFV";
        }

        /// <summary>
        /// Set ZeitraumVon-search date depending on given ZeitraumBis-search date
        /// </summary>
        private void SetupSucheZeitraumVonDate()
        {
            // check if there is a date-value to parse
            if (DBUtil.IsEmpty(edtSucheZeitraumBis.EditValue))
            {
                // no value, so reset first date
                edtSucheZeitraumVon.EditValue = null;
            }
            else
            {
                // we have a date
                edtSucheZeitraumVon.EditValue = new DateTime(Convert.ToDateTime(edtSucheZeitraumBis.EditValue).Year, 1, 1);
            }
        }

        #endregion
    }
}