using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query.BSS
{
    public partial class CtlQueryVmSachversicherungen : KissQueryControl
    {
        #region Constructors

        public CtlQueryVmSachversicherungen()
        {
            this.InitializeComponent();

            edtNurAktive.Checked = true;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtNurAktive.Checked = true;
        }

        #endregion

        #region Private Methods

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
                SELECT	ID = BaPersonID,
                        Person = IsNull(NameVorname, ''),
                        [Vers. Nr.] = Versichertennummer,
                        AHVNummer
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