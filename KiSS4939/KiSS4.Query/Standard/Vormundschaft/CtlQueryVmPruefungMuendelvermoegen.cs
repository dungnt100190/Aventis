using System;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    /// <summary>
    /// Query for Dataexplorer in tree Vormundschaft/Mandatbuchhaltung
    /// </summary>
    public partial class CtlQueryVmPruefungMuendelvermoegen : KissQueryControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly string Classname = "CtlQueryVmPruefungMuendelvermoegen";

        #endregion

        #endregion

        #region Constructors

        public CtlQueryVmPruefungMuendelvermoegen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Initialize dropdowns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtlQueryVmPruefungMuendelvermoegen_Load(object sender, EventArgs e)
        {
            InitializeLookups();
        }

        private void chkNurAmtlich_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNurAmtlich.Checked)
            {
                chkNurPriMa.Checked = false;
            }
        }

        private void chkNurPriMa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNurPriMa.Checked)
            {
                chkNurAmtlich.Checked = false;
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Set default values on Datum Von and Datum Bis
        /// Datum Von: 1. January actual year
        /// Datum Bis: 31. December actual year
        /// </summary>
        protected override void NewSearch()
        {
            edtSucheZeitraumDatumVon.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            edtSucheZeitraumDatumBis.EditValue = new DateTime(DateTime.Now.Year, 12, 31);
            base.NewSearch();
        }

        protected override void RunSearch()
        {
            if (Convert.ToDateTime(edtSucheZeitraumDatumVon.EditValue) > Convert.ToDateTime(edtSucheZeitraumDatumBis.EditValue))
            {
                KissMsg.ShowInfo(Classname, "SearchDatesInvalid", "'Zeitraum von' muss kleiner als 'Zeitraum bis' sein!");
                edtSucheZeitraumDatumVon.Focus();

                throw new KissCancelException();
            }
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Load dropdown Konto Gruppe
        /// </summary>
        private void InitializeLookupKontoGruppe()
        {
            SqlQuery qryKontoGruppe = DBUtil.OpenSQL(@"
                SELECT Code = NULL, Text = NULL
                UNION ALL
                SELECT Code = 1, Text = 'Aktiven'
                UNION ALL
                SELECT Code = 2, Text = 'Passiven'
                UNION ALL
                SELECT Code = 3, Text = 'Aktiven + Passiven'
                UNION ALL
                SELECT Code = 4, Text = 'Depot-Konti'
                UNION ALL
                SELECT Code = 5, Text = 'Transfer-Konti'
                UNION ALL
                SELECT Code = 6, Text = 'Aktiven ohne Depot-Konti'");
            edtKontoGruppeCode.LoadQuery(qryKontoGruppe);
        }

        /// <summary>
        /// Load dropdown Periode Status
        /// </summary>
        private void InitializeLookupPeriodeStatus()
        {
            SqlQuery qryPeriodenStatus = DBUtil.OpenSQL(@"
                SELECT Code = NULL, Text = NULL

                UNION ALL

                SELECT Code, Text
                FROM dbo.XLOVCode WITH(READUNCOMMITTED)
                WHERE LOVName = 'FbPeriodeStatus'

                UNION ALL

                SELECT Code = 9999, Text = 'aktiv oder inaktiv'; --- dummy code used in select");
            edtPeriodeStatusCode.LoadQuery(qryPeriodenStatus);
        }

        /// <summary>
        /// Load dropdown team
        /// </summary>
        private void InitializeLookupTeam()
        {
            SqlQuery qryTeam = DBUtil.OpenSQL(@"
                SELECT Code = FbTeamID, Text = Name
                FROM dbo.FbTeam WITH(READUNCOMMITTED)

                UNION ALL

                SELECT Code = 9999, Text = 'Alle ohne Erbschaftsbuchhaltung' --- dummy code used in select

                UNION ALL

                SELECT Code = null, Text = null
                ORDER BY Name");
            edtTeam.LoadQuery(qryTeam);
        }

        /// <summary>
        /// Initialize all dropdown (lookup fields)
        /// </summary>
        private void InitializeLookups()
        {
            InitializeLookupKontoGruppe();
            InitializeLookupPeriodeStatus();
            InitializeLookupTeam();
        }

        #endregion

        #endregion
    }
}