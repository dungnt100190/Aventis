using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryGvInterneFondsErweitert : KissQueryControl
    {
        private const string CLASSNAME = "CtlQueryGvFondsBase";
        private readonly bool _kompetenzBsl;
        private readonly bool _kompetenzKgl;

        public CtlQueryGvInterneFondsErweitert()
        {
            InitializeComponent();

            _kompetenzBsl = DBUtil.UserHasRight("CtlGvAntrag_Kompetenz_BSL");
            _kompetenzKgl = DBUtil.UserHasRight("CtlQueryGvFondsBase_Kompetenz_KGL_HS");

            kissSearch.SelectParameters = new object[]
            {
                Session.User.LanguageCode
            };
        }

        /// <summary>
        /// Default-Einstellungen bei einer neuen Suche setzen.
        /// </summary>
        protected override void NewSearch()
        {
            // Suchzeitraum
            edtSucheZeitraumValutaBis.EditValue = DateTime.Today;
            SetupSucheZeitraumVonDate(edtSucheZeitraumValutaVon, edtSucheZeitraumValutaBis);

            var setKst = !_kompetenzKgl;
            var setUser = !_kompetenzBsl && !_kompetenzKgl;

            ctlKGSKostenstelleSAR.InitControlForNewSearch(true, setKst, setUser);

            base.NewSearch();
        }

        protected override void RunSearch()
        {
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

            base.RunSearch();
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

        private void edtSucheZeitraumValutaBis_EditValueChanged(object sender, EventArgs e)
        {
            SetupSucheZeitraumVonDate(edtSucheZeitraumValutaVon, edtSucheZeitraumValutaBis);
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