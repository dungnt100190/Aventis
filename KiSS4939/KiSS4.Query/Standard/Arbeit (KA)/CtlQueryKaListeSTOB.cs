using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    partial class CtlQueryKaListeSTOB : Common.KissQueryControl
    {
        #region Constructors

        public CtlQueryKaListeSTOB()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void edtKursID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtKursID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtKursID.EditValue = null;
                    edtKursID.LookupID = null;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                            SELECT ID          = KaKurserfassungID,
                                   Kurs        = KUE.KursNr + ISNULL(', ' + KUR.Name, ''),
                                   [Datum von] = ISNULL(CONVERT(VARCHAR(15), KUE.DatumVon, 104), ''),
                                   [Datum bis] = ISNULL(CONVERT(VARCHAR(15), KUE.DatumBis, 104), '')
                            FROM KaKurserfassung KUE WITH (READUNCOMMITTED)
                              INNER JOIN KaKurs  KUR WITH (READUNCOMMITTED) ON KUR.KaKursID = KUE.KursID
                            WHERE KUE.KursNr + ISNULL(', ' + KUR.Name,'') LIKE '%' + {0} + '%'
                              AND KUE.KursNr LIKE 'S%'
                              AND KUE.SistiertFlag = 0
                              AND CONVERT(DATETIME, KUE.DatumBis, 104) > CONVERT(DATETIME, GETDATE(), 104)",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtKursID.EditValue = dlg[1];
                edtKursID.LookupID = dlg[0];
            }
        }

        #endregion
    }
}