using System;

using KiSS4.Common;
using KiSS4.DB;

namespace KiSS4.Query
{
    public partial class CtlQueryKaIntegrationszulagen : KissQueryControl
    {
        private readonly string Classname = "CtlQueryKaIntegrationszulagen";

        #region Constructors

        public CtlQueryKaIntegrationszulagen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryKaIntegrationszulagen_Load(object sender, EventArgs e)
        {
            SetupMonatJahrEdit();
            SetupZuweiserEdit();
        }

        private void edtNameSTESID_UserModifiedFld(object sender, Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtNameSTESID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtNameSTESID.EditValue = null;
                    edtNameSTESID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtNameSTESID.EditValue = dlg["Name"];
                edtNameSTESID.LookupID = dlg["BaPersonID"];
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            SetupMonatJahrEdit();
            base.NewSearch();
        }

        protected override void RunSearch()
        {
            if(DBUtil.IsEmpty(edtJahr.EditValue))
            {
                KissMsg.ShowInfo(Classname, "SearchYearInvalid", "Das Suchfeld Jahr muss ausgefüllt werden!");
                edtJahr.Focus();

                throw new KissCancelException();
            }
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void SetupMonatJahrEdit()
        {
            edtMonat.LoadQuery(DBUtil.GetLOVQuery("Monat", false), "Code", "ShortText");
            edtMonat.EditValue = DateTime.Today.Month;

            edtJahr.EditValue = DateTime.Today.Year;
        }

        private void SetupZuweiserEdit()
        {
            edtSucheFallfuehrung.LoadQuery(DBUtil.OpenSQL(@"
                SELECT Code = NULL, Text = '' UNION ALL
                SELECT Code = 1, Text = 'SD Bern' UNION ALL
                SELECT Code = 2, Text = 'EKS' UNION ALL
                SELECT Code = 3, Text = 'JA' UNION ALL
                SELECT Code = 4, Text = 'SD Aussengemeinden'"));
        }

        #endregion

        #endregion
    }
}