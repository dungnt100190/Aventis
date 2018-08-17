using System;
using System.Data;
using System.Drawing;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using SharpLibrary.WinControls;

namespace KiSS4.Query
{
    public partial class CtlQueryGvFondsBase : KissQueryControl
    {
        private const string CLASSNAME = "CtlQueryGvFondsBase";

        private readonly bool _kompetenzBsl;
        private readonly bool _kompetenzKgl;

        /// <summary>
        /// Konstruktor ist nur wegen Designer-Mode Problem
        /// </summary>
        public CtlQueryGvFondsBase()
        {
            InitializeComponent();

            _kompetenzBsl = DBUtil.UserHasRight("CtlGvAntrag_Kompetenz_BSL");
            _kompetenzKgl = DBUtil.UserHasRight("CtlQueryGvFondsBase_Kompetenz_KGL_HS");
        }

        /// <summary>
        /// Tab-Titel Übersetzungen setzen.
        /// </summary>
        public override void Translate()
        {
            base.Translate();
            tpgFonds.Title = KissMsg.GetMLMessage(CLASSNAME, "ListeTitelFonds", "Fonds");
            tpgKgs.Title = KissMsg.GetMLMessage(CLASSNAME, "ListeTitelKgs", "KGS");
            tpgKlient.Title = KissMsg.GetMLMessage(CLASSNAME, "ListeTitelKlient", "KlientInnen");
            tpgKostenstelle.Title = KissMsg.GetMLMessage(CLASSNAME, "ListeTitelKostenstelle", "Kostenstelle");
            tpgListe.Title = KissMsg.GetMLMessage(CLASSNAME, "ListeTitelGesuche", "Gesuche");
            tpgMitarbeiter.Title = KissMsg.GetMLMessage(CLASSNAME, "ListeTitelMitarbeiter", "MitarbeiterInnen");
        }

        /// <summary>
        /// Hides a tab page.
        /// This is done by Remove; Hide and Visible did not work.
        /// </summary>
        protected void HideTab(TabPageEx tabPageToHide)
        {
            tabControlSearch.BeginUpdate();

            try
            {
                tabControlSearch.TabPages.Remove(tabPageToHide);
            }
            finally
            {
                tabControlSearch.EndUpdate();
            }
        }

        /// <summary>
        /// Default-Einstellungen bei einer neuen Suche setzen.
        /// </summary>
        protected override void NewSearch()
        {
            // Suchzeitraum
            edtSucheZeitraumEntscheidBis.EditValue = DateTime.Today;
            SetupSucheZeitraumVonDate(edtSucheZeitraumEntscheidVon, edtSucheZeitraumEntscheidBis);

            var setKst = !_kompetenzKgl;
            var setUser = !_kompetenzBsl && !_kompetenzKgl;

            ctlKGSKostenstelleSAR.InitControlForNewSearch(true, setKst, setUser);

            base.NewSearch();
        }

        protected override void RunSearch()
        {
            ClearDataSourceAndColumns();
            grdQuery1.DataSource = qryQuery;

            if (Convert.ToDateTime(edtSucheZeitraumEntscheidVon.EditValue) > Convert.ToDateTime(edtSucheZeitraumEntscheidBis.EditValue))
            {
                KissMsg.ShowInfo(CLASSNAME, "SearchDatesInvalid", "'Zeitraum von' muss kleiner als 'Zeitraum bis' sein!");
                edtSucheZeitraumEntscheidVon.Focus();
                throw new KissCancelException();
            }

            if (Convert.ToDateTime(edtSucheZeitraumErfassungVon.EditValue) > Convert.ToDateTime(edtSucheZeitraumErfassungBis.EditValue))
            {
                KissMsg.ShowInfo(CLASSNAME, "SearchDatesInvalid", "'Zeitraum von' muss kleiner als 'Zeitraum bis' sein!");
                edtSucheZeitraumErfassungVon.Focus();
                throw new KissCancelException();
            }

            if (Convert.ToDateTime(edtSucheZeitraumAbschlussVon.EditValue) > Convert.ToDateTime(edtSucheZeitraumAbschlussBis.EditValue))
            {
                KissMsg.ShowInfo(CLASSNAME, "SearchDatesInvalid", "'Zeitraum von' muss kleiner als 'Zeitraum bis' sein!");
                edtSucheZeitraumAbschlussVon.Focus();
                throw new KissCancelException();
            }

            // let base do stuff
            base.RunSearch();
        }

        /// <summary>
        /// Datasource bei Grids entfernen.
        /// </summary>
        private void ClearDataSourceAndColumns()
        {
            grdQuery1.DataSource = null;
            grdFonds.DataSource = null;
            grdKgs.DataSource = null;
            grdKostenstelle.DataSource = null;
            grdListeKlient.DataSource = null;
            grdMitarbeiter.DataSource = null;
            foreach (DataTable table in qryQuery.DataSet.Tables)
            {
                table.Columns.Clear();
            }
        }

        private void CtlQueryGvFonds_Load(object sender, EventArgs e)
        {
            // Designer-Mode Problem
            if (DesignerMode)
            {
                return;
            }

            colGesuchBemerkungen.DisplayFormat.Format = new GridColumnRTF();
            colAbgeschlossenesGesuchBemerkung.DisplayFormat.Format = new GridColumnRTF();
            colErfasstesGesuchBemerkung.DisplayFormat.Format = new GridColumnRTF();

            // KgsDropdown initialisieren
            colGesuchStatus.FieldName = DBO.GvGesuch.GvStatusCode;
            Utils.SetStatusImageRepository(repStatusImg, "GvStatus", Session.User.LanguageCode);
        }

        private void edtSucheZeitraumAbschlussBis_EditValueChanged(object sender, EventArgs e)
        {
            SetupSucheZeitraumVonDate(edtSucheZeitraumAbschlussVon, edtSucheZeitraumAbschlussBis);
        }

        private void edtSucheZeitraumEntscheidBis_EditValueChanged(object sender, EventArgs e)
        {
            SetupSucheZeitraumVonDate(edtSucheZeitraumEntscheidVon, edtSucheZeitraumEntscheidBis);
        }

        private void edtSucheZeitraumErfassungBis_EditValueChanged(object sender, EventArgs e)
        {
            SetupSucheZeitraumVonDate(edtSucheZeitraumErfassungVon, edtSucheZeitraumErfassungBis);
        }

        /// <summary>
        /// Binding der übrigen 5 Dataset-Tabellen an die Grids
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            SetupDataSourceAndGridColumns(grdListeKlient, qryQuery.DataSet.Tables[1]);
            SetupDataSourceAndGridColumns(grdMitarbeiter, qryQuery.DataSet.Tables[2]);
            SetupDataSourceAndGridColumns(grdKostenstelle, qryQuery.DataSet.Tables[3]);
            SetupDataSourceAndGridColumns(grdKgs, qryQuery.DataSet.Tables[4]);
            SetupDataSourceAndGridColumns(grdFonds, qryQuery.DataSet.Tables[5]);
        }

        /// <summary>
        /// Set ZeitraumVon-search date depending on given ZeitraumBis-search date
        /// </summary>
        private void SetupSucheZeitraumVonDate(KissDateEdit edtDatumVon, KissDateEdit edtDatumBis)
        {
            // check if there is a date-value to parse
            if (DBUtil.IsEmpty(edtDatumBis.EditValue))
            {
                // no value, so reset first date
                edtDatumVon.EditValue = null;
            }
            else
            {
                // we have a date
                edtDatumVon.EditValue = new DateTime(Convert.ToDateTime(edtDatumBis.EditValue).Year, 1, 1);
            }
        }
    }
}