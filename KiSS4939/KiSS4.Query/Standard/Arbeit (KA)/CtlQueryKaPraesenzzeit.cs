using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    partial class CtlQueryKaPraesenzzeit : KissQueryControl
    {
        #region Constructors

        public CtlQueryKaPraesenzzeit()
        {
            InitializeComponent();
            UpdateDatumVonBis();
        }

        #endregion

        #region EventHandlers

        private void edtFachbereich_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = edtFachbereich.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtFachbereich.EditValue = null;
                    edtFachbereich.LookupID = null;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID = Code, Fachbereich = Text, Abteilung = Value1
                FROM   XLOVCode XLC
                WHERE  XLC.Text like '%' + {0} + '%'
                AND    XLC.LOVName = 'KAFachbereich'
                ORDER BY XLC.Text",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtFachbereich.EditValue = dlg[1];
                edtFachbereich.LookupID = dlg[0];
            }
        }

        private void edtFachleitung_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = PrepareSearchString(edtFachleitung, e);
            SearchMitarbeiter(edtFachleitung, e, searchString);
        }

        private void edtStes_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = PrepareSearchString(edtStes, e);
            SearchPerson(edtStes, e, searchString);
        }

        private void edtZustaendigKa_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var searchString = PrepareSearchString(edtZustaendigKa, e);
            SearchMitarbeiter(edtZustaendigKa, e, searchString);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            UpdateDatumVonBis();
        }

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtDatumVon, lblDatumVon.Text);
            DBUtil.CheckNotNullField(edtDatumBis, lblDatumBis.Text);

            base.RunSearch();
        }

        #endregion

        #region Private Static Methods

        private static string PrepareSearchString(KissButtonEdit buttonEdit, UserModifiedFldEventArgs e)
        {
            var searchString = buttonEdit.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    buttonEdit.EditValue = null;
                    buttonEdit.LookupID = null;
                    return null;
                }
            }
            return searchString;
        }

        #endregion

        #region Private Methods

        private void SearchMitarbeiter(KissButtonEdit buttonEdit, UserModifiedFldEventArgs e, string searchString)
        {
            if (searchString == null)
            {
                return;
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                buttonEdit.EditValue = dlg["Name"];
                buttonEdit.LookupID = dlg["UserID"];
            }
        }

        private void SearchPerson(KissButtonEdit buttonEdit, UserModifiedFldEventArgs e, string searchString)
        {
            if (searchString == null)
            {
                return;
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(searchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                buttonEdit.EditValue = dlg["Name"];
                buttonEdit.LookupID = dlg["BaPersonID"];
            }
        }

        private void UpdateDatumVonBis()
        {
            edtDatumVon.EditValue = new DateTime(Convert.ToInt32(DateTime.Today.Year), 1, 1);
            edtDatumBis.EditValue = DateTime.Today;
        }

        #endregion

        #endregion
    }
}