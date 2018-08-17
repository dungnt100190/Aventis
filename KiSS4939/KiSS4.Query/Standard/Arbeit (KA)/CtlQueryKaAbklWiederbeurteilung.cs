using System;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    partial class CtlQueryKaAbklWiederbeurteilung : Common.KissQueryControl
    {
        #region Constructors

        public CtlQueryKaAbklWiederbeurteilung()
        {
            InitializeComponent();
            edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtDatumBis.EditValue = DateTime.Today;
        }

        #endregion

        #region EventHandlers

        private void edtZuweiserID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtZuweiserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtZuweiserID.EditValue = null;
                    edtZuweiserID.LookupID = null;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                            SELECT ID$          = OKO.BaInstitutionKontaktID,
                                   Name         = OKO.Name + ISNULL(', ' + OKO.Vorname,''),
                                   Organisation = ORG.Name,
                                   Tel          = OKO.Telefon,
                                   Fax          = OKO.Fax,
                                   Email        = OKO.Email
                            FROM BaInstitutionKontakt  OKO WITH (READUNCOMMITTED)
                              INNER JOIN BaInstitution ORG WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = OKO.BaInstitutionID
                            WHERE OKO.Name + ISNULL(', ' + OKO.Vorname,'') LIKE '%' + {0} + '%'

                            UNION ALL

                            SELECT ID$          = -UserID,
                                   Name         = LastName + ISNULL(', ' + FirstName,''),
                                   Organisation = 'User',
                                   Tel          = Phone,
                                   Fax          = '',
                                   Email        = Email
                            FROM XUser WITH (READUNCOMMITTED)
                            WHERE LastName + ISNULL(', ' + FirstName,'') LIKE '%' + {0} + '%'
                            ORDER BY Name",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtZuweiserID.EditValue = dlg[1];
                edtZuweiserID.LookupID = dlg[0];
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtDatumVon.EditValue = new DateTime(DateTime.Today.Year, 1, 1);
            edtDatumBis.EditValue = DateTime.Today;
        }

        #endregion

        #endregion
    }
}