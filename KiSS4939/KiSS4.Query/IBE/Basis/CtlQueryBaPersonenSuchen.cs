using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.IBE
{
    public partial class CtlQueryBaPersonenSuchen : KissQueryControl
    {
        public CtlQueryBaPersonenSuchen()
        {
            InitializeComponent();

            _suchKriteriumCtrItems = new List<KeyValuePair<string, BaseEdit>>
            {
                new KeyValuePair<string, BaseEdit>(lblName.Text, edtName),
                new KeyValuePair<string, BaseEdit>(lblVorname.Text, edtVorname),
                new KeyValuePair<string, BaseEdit>(lblGeburtsdatumvon.Text, edtGeburtVon),
                new KeyValuePair<string, BaseEdit>(lblbis.Text, edtGeburtBis),
                new KeyValuePair<string, BaseEdit>(lblAHV.Text, edtAHV),
                new KeyValuePair<string, BaseEdit>(lblVersNr.Text, edtVersNr),
                new KeyValuePair<string, BaseEdit>(lblHaushaltVersNr.Text, edtHaushaltVersNr),
                new KeyValuePair<string, BaseEdit>(lblNNr.Text, edtNNr),
                new KeyValuePair<string, BaseEdit>(lblStrasse.Text, edtStrasse),
                new KeyValuePair<string, BaseEdit>(lblPLZOrt.Text.Split('/')[0], edtPLZ),
                new KeyValuePair<string, BaseEdit>(lblPLZOrt.Text.Split('/')[1], edtOrt),
                new KeyValuePair<string, BaseEdit>(lblAktivVon.Text, edtAktivVon),
                new KeyValuePair<string, BaseEdit>(lblAktivBis.Text, edtAktivBis),
                new KeyValuePair<string, BaseEdit>(edtFT.Text, edtFT),
                new KeyValuePair<string, BaseEdit>(edtNurAktivePerson.Text, edtNurAktivePerson),
                new KeyValuePair<string, BaseEdit>(soundex.Text, soundex)
            };
        }

        protected override void RunSearch()
        {
            kissSearch.SelectParameters = new object[] { Session.User.LanguageCode };

            base.RunSearch();
        }

        private void btnFallInfo_Click(object sender, EventArgs e)
        {
            FormController.ShowDialogOnMain("FrmFallInfo", qryQuery["BaPersonID$"], true);
        }
    }
}