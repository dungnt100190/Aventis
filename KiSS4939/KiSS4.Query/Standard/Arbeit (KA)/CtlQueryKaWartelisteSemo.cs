using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    partial class CtlQueryKaWartelisteSemo : KissQueryControl
    {
        public CtlQueryKaWartelisteSemo()
        {
            InitializeComponent();
        }

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
                  	   Name         = OKO.Name + isNull(', ' + OKO.Vorname,''),
              		   Organisation = ORG.Name,
              		   Tel          = OKO.Telefon,
                       Fax          = OKO.Fax,
                       Email        = OKO.Email
                FROM BaInstitutionKontakt OKO
                    INNER JOIN BaInstitution ORG ON ORG.BaInstitutionID = OKO.BaInstitutionID
                WHERE OKO.Name + ISNULL(', ' + OKO.Vorname,'') like '%' + {0} + '%'

                UNION ALL

                SELECT ID$          = -UserID,
              		   Name         = LastName + isNull(', ' + FirstName,''),
              		   Organisation = 'User',
              		   Tel          = Phone,
              		   Fax          = '',
              		   Email        = Email
                FROM XUser
                WHERE LastName + ISNULL(', ' + FirstName,'') like '%' + {0} + '%'
                ORDER BY Name",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtZuweiserID.EditValue = dlg[1];
                edtZuweiserID.LookupID = dlg[0];
            }
        }
    }
}