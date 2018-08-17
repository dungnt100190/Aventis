using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Schnittstellen.Newod.BO;
using KiSS4.Schnittstellen.Newod.DTO;

namespace KiSS4.Schnittstellen.Newod
{
    public partial class CtlKiSSNewodMappingWeb : KissUserControl
    {
        #region Fields

        #region Private Fields

        // Uses strings for baPersonID, NewodNummer because we
        // make webservice calls (everything is string)
        private string _baPersonID;

        #endregion

        #endregion

        #region Constructors

        // Is called from frmNewodAdmin (shows all Persons from KiSS)
        public CtlKiSSNewodMappingWeb()
            : this(null)
        {
            _baPersonID = null;
        }

        // Is called from Basis Personalien (shows only current Person)
        public CtlKiSSNewodMappingWeb(string baPersonID)
        {
            this.InitializeComponent();

            _baPersonID = baPersonID;

            edtMappingKriterien.EditValue = "3,7";
        }

        #endregion

        #region EventHandlers

        private void btnDoMapping_Click(object sender, EventArgs e)
        {
            if (KissMsg.ShowQuestion("Wollen Sie das Mapping herstellen?"))
            {
                ServiceResult resultMapping = _svcPerson.SetNewodBinding((BaPerson)_selKissPerson, (NewodPerson)_selNewodPerson);

                if (resultMapping.Success)
                {
                    // succeeded, close dialog
                    //TODO: Hack ... Refactor
                    Form parent = Parent as Form;
                    if (parent != null)
                        parent.DialogResult = DialogResult.OK;
                }
                else
                {   foreach (string message in resultMapping.Errors)
                    {
                        KissMsg.ShowInfo(message);
                     }
                }
            }
        }

        private void btnDoSearch_Click(object sender, EventArgs e)
        {
            ServiceResult resultLookupNewodPerson = new ServiceResult();

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //System.Threading.Thread.Sleep(3000);

                resultLookupNewodPerson = this.LookupNewodPersons();

                if (!resultLookupNewodPerson.Success)
                    this.ShowServiceResultMessages(resultLookupNewodPerson);

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                KissMsg.ShowError("CtlKiSSNewodMappingWeb", "ErrorSearch", "Fehler beim Suchen der Daten.", ex);

                // Refresh Grid
                this.RefreshDataNewodPerson(null);
            }
        }

        private void grdVwNewodPerson_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (_svcPerson.NewodPersons.Count == 0)
            {
                _selNewodPerson = new Person();
            }
            else
            {
                // get selected row as person object
                _selNewodPerson = _svcPerson.GetByID(grdNewodPerson.View.GetFocusedRowCellValue("ID").ToString());
            }
            // set fields
            this.SetInputFieldValuesNewodPerson(_selNewodPerson);
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="baPersonID"></param>
        /// 
        public void LookupKiSSPersons()
        {
            _criteria = new PersonSearchCriteria();
            _criteria.ID = _baPersonID;

            ServiceResult result = _svcPerson.SearchPerson(true, false, _criteria);
            List<BaPerson> bapersons = _svcPerson.KissPersons;

            this.RefreshDataBaPerson(bapersons);

            // get selected row as person object
            _selKissPerson = _svcPerson.GetByID(grdBaPerson.View.GetFocusedRowCellValue("ID").ToString());

            // set fields
            this.SetInputFieldValuesBaPerson(_selKissPerson);
        }

        #endregion

        #region Private Methods

        private void ClearValuesNewodPerson()
        {
            // Felder löschen
            edtIDNewodPerson.EditValue = null;
            edtNameNewodPerson.EditValue = null;
            edtVornameNewodPerson.EditValue = null;
            edtGeburtsdatumNewodPerson.EditValue = null;
            edtAHVNummerNewodPerson.EditValue = null;
            edtVersichertennummerNewodPerson.EditValue = null;
            edtStrasseNewodPerson.EditValue = null;
            edtHausNrNewodPerson.EditValue = null;
            edtPLZNewodPerson.EditValue = null;
            edtOrtNewodPerson.EditValue = null;
        }

        private ServiceResult LookupNewodPersons()
        {
            ClearValuesNewodPerson();

            _criteria = new PersonSearchCriteria();
            String _selItems = edtMappingKriterien.EditValue;

            if (_selItems != null && !_selItems.Equals(""))
            {
                // file pattern is defined, try to split if multiple patterns are given
                String[] checkedValues = _selItems.Split(',');

                _criteria.Trim();

                // loop foreach single search pattern
                foreach (String val in checkedValues)
                {
                    switch (val)
                    {
                        case "1":
                            _criteria.Ahv11 = _selKissPerson.AHVNummer;
                            break;
                        case "2":
                            if (!string.IsNullOrEmpty(_selKissPerson.AHVNummer))
                            {
                                _criteria.Ahv11 = _selKissPerson.AHVNummer.Substring(0, 7) + '*';
                            }
                            break;
                        case "3":
                            _criteria.LastName = _selKissPerson.Name;
                            break;
                        case "4":
                            _criteria.FirstName = _selKissPerson.Vorname;
                            break;
                        case "5":
                            if (_selKissPerson.Versichertennummer != null)
                            {
                                _criteria.Ahv13 = _selKissPerson.Versichertennummer.Value.ToString();
                            }
                            break;
                        case "6":
                            _criteria.Strasse = _selKissPerson.Strasse;
                            _criteria.Hausnr = _selKissPerson.HausNr;
                            break;
                        case "7":
                            _criteria.BirthDayFrom = _selKissPerson.Geburtsdatum;
                            _criteria.BirthDayTo = _selKissPerson.Geburtsdatum;
                            break;
                        case "8":
                            _criteria.Plz = _selKissPerson.Plz;
                            break;
                        case "9":
                            _criteria.Ort = _selKissPerson.Ort;
                            break;
                    }
                }
            }

            // do service call
            ServiceResult resultSearchNewodPerson = _svcPerson.SearchPerson(false, true, _criteria);

            // Refresh Grid
            this.RefreshDataNewodPerson(_svcPerson.NewodPersons);

            if (_svcPerson.NewodPersons.Count != 0)
            {

                // get selected row as person object
                _selNewodPerson = _svcPerson.GetByID(grdNewodPerson.View.GetFocusedRowCellValue("ID").ToString());

                // set fields
                this.SetInputFieldValuesNewodPerson(_selNewodPerson);
            }

            return resultSearchNewodPerson;
        }

        private void RefreshDataBaPerson(List<BaPerson> list)
        {
            grdBaPerson.DataSource = null;
            grdBaPerson.DataSource = list;
        }

        private void RefreshDataNewodPerson(List<NewodPerson> list)
        {
            grdNewodPerson.DataSource = null;
            grdNewodPerson.DataSource = list;
        }

        private void SetInputFieldValuesBaPerson(Person selectedKiSSPerson)
        {
            // Felder Werte setzen
            edtIDBaPerson.EditValue = selectedKiSSPerson.ID;
            edtNameBaPerson.EditValue = selectedKiSSPerson.Name;
            edtVornameBaPerson.EditValue = selectedKiSSPerson.Vorname;
            edtGeburtsdatumBaPerson.EditValue = selectedKiSSPerson.Geburtsdatum;
            edtAHVNummerBaPerson.EditValue = selectedKiSSPerson.AHVNummer;
            edtVersichertennummerBaPerson.EditValue = selectedKiSSPerson.Versichertennummer;

            edtStrasseBaPerson.EditValue = selectedKiSSPerson.Strasse;
            edtHausNrBaPerson.EditValue = selectedKiSSPerson.HausNr;
            edtPLZBaPerson.EditValue = selectedKiSSPerson.Plz;
            edtOrtBaPerson.EditValue = selectedKiSSPerson.Ort;
        }

        private void SetInputFieldValuesNewodPerson(Person selectedNewodPerson)
        {
            // Felder Werte setzen
            edtIDNewodPerson.EditValue = selectedNewodPerson.ID;
            edtNameNewodPerson.EditValue = selectedNewodPerson.Name;
            edtVornameNewodPerson.EditValue = selectedNewodPerson.Vorname;
            edtGeburtsdatumNewodPerson.EditValue = selectedNewodPerson.Geburtsdatum;
            edtAHVNummerNewodPerson.EditValue = selectedNewodPerson.AHVNummer;
            edtVersichertennummerNewodPerson.EditValue = selectedNewodPerson.Versichertennummer;
            edtStrasseNewodPerson.EditValue = selectedNewodPerson.Strasse;
            edtHausNrNewodPerson.EditValue = selectedNewodPerson.HausNr;
            edtPLZNewodPerson.EditValue = selectedNewodPerson.Plz;
            edtOrtNewodPerson.EditValue = selectedNewodPerson.Ort;
        }

        private void ShowServiceResultMessages(ServiceResult result)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string error in result.Errors)
            {
                sb.Append(error);
                sb.Append("\n");
            }

            KissMsg.ShowError("CtlKiSSNewodMappingWeb", "ErrorGeneral", "Es ist ein Fehler aufgetreten.", sb.ToString());
        }

        #endregion

        #endregion
    }
}