using System;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryGvHaengigeAuflagenInterneFonds : KissQueryControl
    {
        #region Constructors

        public CtlQueryGvHaengigeAuflagenInterneFonds()
        {
            InitializeComponent();

            kissSearch.SelectParameters = new object[] { Session.User.LanguageCode };
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            var queryFonds =
                DBUtil.OpenSQL(@"
                    SELECT [Code] = NULL,
                           [Text] = ''
                    UNION ALL
                    SELECT [Code] = GvFondsID,
                           [Text] = NameKurz
                    FROM dbo.GvFonds WITH (READUNCOMMITTED)
                    WHERE GvFondsTypCode = 1
                    ORDER BY [Text];");
            edtSucheFonds.LoadQuery(queryFonds);

            base.OnLoad(e);
        }

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            chkSucheNurFlb.Checked = true;
            chkSucheEntschiedeneGesuche.Checked = true;

            edtSucheZeitraumDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtSucheZeitraumDatumBis.EditValue = DateTime.Today;

            ctlKGSKostenstelleSAR.InitControlForNewSearch(true, false, false);

            base.NewSearch();
        }

        #endregion

        #endregion
    }
}