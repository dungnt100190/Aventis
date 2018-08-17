using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryKaKurseBIBIPSI : KissQueryControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASS_NAME = "CtlQueryKaKurseBIBIPSI";

        #endregion

        #region Private Fields

        private bool _isInEditValueChanged;
        private bool _showTimespanMessage;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryKaKurseBIBIPSI()
        {
            InitializeComponent();

            // HACK: Tabulator springt nicht aus einem KissLookUpEdit, wenn es nicht das letzte seiner Art ist..
            tpgSuchen.Controls.Add(new KissLookUpEdit { TabIndex = 999, TabStop = false, Visible = false });
        }

        #endregion

        #region EventHandlers

        private void CtlQueryKaKurseBIBIPSI_Load(object sender, EventArgs e)
        {
            tpgListe.Title = "Kurse";
        }

        private void edtDatumBis_EditValueChanged(object sender, EventArgs e)
        {
            if (_isInEditValueChanged)
            {
                return;
            }

            try
            {
                _isInEditValueChanged = true;

                var datumVon = edtDatumVon.DateTime;
                var datumBis = edtDatumBis.DateTime;

                if (datumVon.Year != datumBis.Year)
                {
                    datumVon = new DateTime(datumBis.Year, datumVon.Month, datumVon.Day);

                    ShowTimespanMessage();
                }

                if (datumBis != DateTime.MinValue && datumVon >= datumBis)
                {
                    datumVon = datumBis.AddDays(-1);
                }

                edtDatumVon.DateTime = datumVon;
            }
            finally
            {
                _isInEditValueChanged = false;
            }
        }

        private void edtDatumVon_EditValueChanged(object sender, EventArgs e)
        {
            if (_isInEditValueChanged)
            {
                return;
            }

            try
            {
                _isInEditValueChanged = true;

                var datumVon = edtDatumVon.DateTime;
                var datumBis = edtDatumBis.DateTime;

                if (datumVon.Year != datumBis.Year)
                {
                    datumBis = new DateTime(datumVon.Year, datumBis.Month, datumBis.Day);
                    ShowTimespanMessage();
                }

                if (datumVon != DateTime.MaxValue && datumBis <= datumVon)
                {
                    datumBis = datumVon.AddDays(1);
                }

                edtDatumBis.DateTime = datumBis;
            }
            finally
            {
                _isInEditValueChanged = false;
            }
        }

        private void edtZustaendigKA_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtZustaendigKA.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtZustaendigKA.EditValue = null;
                    edtZustaendigKA.LookupID = null;
                    return;
                }
            }

            using (var dlg = new KissLookupDialog())
            {
                e.Cancel = !dlg.SearchData(@"
                    SELECT
                      [ID$]            = UserID,
                      [Kürzel]         = LogonName,
                      [Mitarbeiter/in] = NameVorname,
                      [Org.Einheit]    = OrgUnit
                    FROM dbo.vwUser
                    WHERE NameVorname LIKE {0} + '%'
                      AND LogonName LIKE 'KA%'
                    ORDER BY NameVorname;",
                    searchString,
                    e.ButtonClicked,
                    null,
                    null,
                    null);

                if (!e.Cancel)
                {
                    edtZustaendigKA.EditValue = dlg[2];
                    edtZustaendigKA.LookupID = dlg[0];
                }
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtDatumBis.EditValue = new DateTime(DateTime.Today.Year, 12, 31);
            _showTimespanMessage = true;

            edtZustaendigKA.EditValue = null;
            edtZustaendigKA.LookupID = null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            NewSearch();
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatumVon, "Datum von");
            DBUtil.CheckNotNullField(edtDatumBis, "Datum bis");

            base.RunSearch();

            _showTimespanMessage = false;
        }

        #endregion

        #region Private Methods

        private void ShowTimespanMessage()
        {
            if (_showTimespanMessage)
            {
                KissMsg.ShowInfo(CLASS_NAME, "AbfrageZeitraumImGleichenJahr", "Der Abfragezeitraum muss innerhalb des gleichen Jahres sein.");
            }
        }

        #endregion

        #endregion
    }
}