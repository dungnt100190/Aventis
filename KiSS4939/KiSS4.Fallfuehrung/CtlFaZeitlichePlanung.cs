using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;
using ZPL = KiSS.DBScheme.DBO.FaZeitlichePlanung;

namespace KiSS4.Fallfuehrung
{
    public partial class CtlFaZeitlichePlanung : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string COL_PHASE1_BEGINN = "Phase1Beginn";
        private const string COL_PHASE3_ENDE = "Phase3Ende";

        #endregion

        #region Private Fields

        private int _faLeistungId;

        #endregion

        #endregion

        #region Constructors

        public CtlFaZeitlichePlanung()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void qryFaZeitlichePlanung_AfterFill(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryFaZeitlichePlanung[DBO.FaZeitlichePlanung.FaZeitlichePlanungID]))
            {
                var phase1Beginn = qryFaZeitlichePlanung[COL_PHASE1_BEGINN];
                var phase3Ende = qryFaZeitlichePlanung[COL_PHASE3_ENDE];

                var table = DBO.FaZeitlichePlanung.DBOName;
                qryFaZeitlichePlanung.Insert(table);
                qryFaZeitlichePlanung[DBO.FaZeitlichePlanung.FaLeistungID] = _faLeistungId;
                qryFaZeitlichePlanung[COL_PHASE1_BEGINN] = phase1Beginn;
                qryFaZeitlichePlanung[COL_PHASE3_ENDE] = phase3Ende;

                SetupDates();
                qryFaZeitlichePlanung.RowModified = true;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string titleName, Image titleImage, int faLeistungId)
        {
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;
            _faLeistungId = faLeistungId;

            qryFaZeitlichePlanung.Fill(faLeistungId);
        }

        #endregion

        #region Private Methods

        private void SetDateIfEmpty(string column, DateTime date)
        {
            if (DBUtil.IsEmpty(qryFaZeitlichePlanung[column]))
            {
                qryFaZeitlichePlanung[column] = date;
            }
        }

        private void SetupDates()
        {
            var phase1Beginn = qryFaZeitlichePlanung[COL_PHASE1_BEGINN];
            var phase3Ende = qryFaZeitlichePlanung[COL_PHASE3_ENDE];

            var confPhase1Dauer = DBUtil.GetConfigInt(@"System\Fallfuehrung\ZeitlichePlanung\Phase1Dauer", 18);
            var confPhase1SitAnalyse = DBUtil.GetConfigInt(@"System\Fallfuehrung\ZeitlichePlanung\Phase1SitAnalyse", 12);
            var confPhase2SitAnalyse = DBUtil.GetConfigInt(@"System\Fallfuehrung\ZeitlichePlanung\Phase2SitAnalyse", 6);
            var confPhase2Ende = DBUtil.GetConfigInt(@"System\Fallfuehrung\ZeitlichePlanung\Phase2Ende", 12);
            var confPhase3SitAnalyse = DBUtil.GetConfigInt(@"System\Fallfuehrung\ZeitlichePlanung\Phase3SitAnalyse", 3);

            if (!DBUtil.IsEmpty(phase1Beginn))
            {
                var x = (DateTime)phase1Beginn;
                var y = x.AddMonths(confPhase1Dauer);

                // Phase 1
                SetDateIfEmpty(ZPL.Phase1Ende, y);
                SetDateIfEmpty(ZPL.Phase1SitAnalyse, x.AddMonths(confPhase1SitAnalyse));

                // Phase 2
                var y1 = y.AddDays(1);
                SetDateIfEmpty(ZPL.Phase2Beginn, y1);
                SetDateIfEmpty(ZPL.Phase2SitAnalyse, y1.AddMonths(confPhase2SitAnalyse));
            }

            if (!DBUtil.IsEmpty(phase3Ende))
            {
                var z = (DateTime)phase3Ende;

                // Phase 2
                var v = z.AddMonths(-confPhase2Ende);
                SetDateIfEmpty(ZPL.Phase2Ende, v);

                // Phase 3
                var v1 = v.AddDays(1);
                SetDateIfEmpty(ZPL.Phase3Beginn, v1);
                SetDateIfEmpty(ZPL.Phase3SitAnalyse, v1.AddMonths(confPhase3SitAnalyse));
            }
        }

        #endregion

        #endregion
    }
}