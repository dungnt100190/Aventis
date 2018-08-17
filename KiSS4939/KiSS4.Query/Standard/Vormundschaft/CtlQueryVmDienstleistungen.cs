using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryVmDienstleistungen : KissQueryControl
    {
        #region Constructors

        public CtlQueryVmDienstleistungen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void edtBaPersonID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtBaPersonID.EditValue = null;
                    edtBaPersonID.LookupID = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(string.Format(@"
                SELECT ID = BaPersonID, Person = IsNull(NameVorname, '')
                FROM vwPerson
                WHERE IsNull(NameVorname,'') like {{0}} + '%'
                    AND (PersonSichtbarSDFlag = dbo.fnGetPersonSichtbarFlag('{0}') or PersonSichtbarSDFlag = 1)
                ORDER BY Person", Session.User.LogonName),
                searchString,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg[1];
                edtBaPersonID.LookupID = dlg[0];
            }
        }

        #endregion
    }
}