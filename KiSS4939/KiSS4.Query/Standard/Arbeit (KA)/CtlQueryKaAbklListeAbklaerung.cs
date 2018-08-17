using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    partial class CtlQueryKaAbklListeAbklaerung : Common.KissQueryControl
    {
        #region Constructors

        public CtlQueryKaAbklListeAbklaerung()
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
                SELECT ID = KUE.KaKurserfassungID,
                       [Kurs-Nr.] = ISNULL(KUE.KursNr, '') + ISNULL(', ' + KUR.Name, ''),
                       [Datum]    = ISNULL(CONVERT(VARCHAR(15), KUE.DatumVon, 104), '') + ISNULL(' - ' + CONVERT(VARCHAR(15), KUE.DatumBis, 104), '')
                FROM dbo.KaKurserfassung KUE WITH (READUNCOMMITTED)
                  INNER JOIN dbo.KaKurs  KUR WITH (READUNCOMMITTED) ON KUR.KaKursID = KUE.KursID
                WHERE KUE.SistiertFlag = 0
                  AND ISNULL(KUE.KursNr, '') + ISNULL(', ' + KUR.Name, '') LIKE '%' + {0} + '%'
                ORDER BY KUR.Name, KUE.KursNr, KUE.DatumVon ASC;",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtKursID.EditValue = dlg[1];
                edtKursID.LookupID = dlg[0];
            }
        }

        private void edtUserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID$         = OKO.BaInstitutionKontaktID,
                       Zuweiser    = OKO.Name + isNull(', ' + OKO.Vorname,''),
                       Institution = ORG.Name,
                       Tel         = OKO.Telefon,
                       Fax         = OKO.Fax,
                       Email       = OKO.Email
                FROM dbo.BaInstitutionKontakt OKO WITH (READUNCOMMITTED)
                  INNER JOIN BaInstitution    ORG WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = OKO.BaInstitutionID
                WHERE OKO.Name + ISNULL(', ' + OKO.Vorname,'') LIKE '%' + {0} + '%'

                UNION ALL

                SELECT ID$         = -UserID,
                       Zuweiser    = LastName + isNull(', ' + FirstName,''),
                       Institution = 'User',
                       Tel         = Phone,
                       Fax         = '',
                       Email       = Email
                FROM dbo.XUser
                WHERE LastName + ISNULL(', ' + FirstName, '') LIKE '%' + {0} + '%'
                ORDER BY Zuweiser;",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg[1];
                edtUserID.LookupID = dlg[0];
            }
        }

        #endregion
    }
}