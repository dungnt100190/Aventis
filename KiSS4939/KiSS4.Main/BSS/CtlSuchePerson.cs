using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Schnittstellen.Newod.BO;
using KiSS4.Schnittstellen.Newod.DTO;
using KiSS4.Schnittstellen.Newod.Service;

namespace KiSS4.Main.BSS
{
    public partial class CtlSuchePerson : KissUserControl, ISuchePerson
    {
        #region Fields

        #region Public Fields

        /// <summary>
        /// Store the flag if person is visible or not (used for KA)
        /// </summary>
        public int NewSichtbarFlag;

        /// <summary>
        /// Store the id of the responsible user for the created case
        /// </summary>
        public int UserID;

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly PersonService _personService;

        #endregion

        #region Private Fields

        private bool _doRunSearch; // store if on tabChanged to Liste a new search has to be executed
        private bool _firstTime = true;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor of the control
        /// </summary>
        public CtlSuchePerson()
        {
            InitializeComponent();
            _personService = new PersonService();
            searchCriteriaBindingSource.DataSource = new PersonSearchCriteria();
        }

        #endregion

        #region Properties

        public int SelectedTabIndex
        {
            get { return tabPerson.SelectedTabIndex; }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Converts BaLandID to isocode
        /// </summary>
        /// <param name="baLandId">BaLandID</param>
        /// <param name="fieldname">Fieldname (iso2code || iso3code)</param>
        /// <returns>string isocode</returns>
        private string ConvertBaLandIdToIsoCountryCode(int? baLandId, string fieldname)
        {
            if (!baLandId.HasValue)
            {
                return null;
            }

            string sqlCountry = String.Format(@"SELECT {0} FROM dbo.BaLand WITH (READUNCOMMITTED) WHERE BaLandID = {1}", fieldname, baLandId);
            SqlQuery qry = new SqlQuery();

            qry.Fill(sqlCountry);

            if (qry.Count == 0)
            {
                return null;
            }

            return qry.DataTable.Rows[0][fieldname].ToString();
        }

        private void CtlSuchePerson_Load(object sender, EventArgs e)
        {
            // select first tab
            tabPerson.SelectTab(tpgPersonSuchen);

            // setup tabs
            tpgPersonSuchen.Title = "Person suchen";
            tpgPersonErfassen.Title = "Person erfassen";

            // right management
            qryNeuePerson.ApplyUserRights(Name);
            qryBaPerson.ApplyUserRights(Name);

            // Neue Person vorbereiten
            qryNeuePerson.Fill(@"
                SELECT *
                FROM dbo.BaPerson WITH (READUNCOMMITTED)
                WHERE 1 = 2");

            if (DBUtil.UserHasRight(Name, "I"))
            {
                qryNeuePerson.Insert();
                qryNeuePerson.RowModified = true;
            }
            else
            {
                qryNeuePerson.CanInsert = false;
                panelBerechtigung.Visible = true;
            }

            // fill data without any row
            FillPersonen(true);
            qryBaPerson.EnableBoundFields(false);

            // init a new search if necessary
            tabListeSuchen.SelectTab(tpgSuchen);
            NeueSuche();

            // setup fields
            _doRunSearch = true;
        }

        private void editNationalitaetX_EditValueChanged(object sender, EventArgs e)
        {
            PersonSearchCriteria criteria = (PersonSearchCriteria)searchCriteriaBindingSource.DataSource;
            if (editNationalitaetX.EditValue.ToString() != "")
            {
                criteria.CountryIso2Code = ConvertBaLandIdToIsoCountryCode((int)editNationalitaetX.EditValue, "iso2code");
            }
            else
            {
                criteria.CountryIso2Code = null;
            }
        }

        private void grvPerson_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ClearDetailFields();
            Person pers = grdPerson.View.GetRow(e.FocusedRowHandle) as Person;

            if (pers != null)
            {
                editName.EditValue = pers.Name ?? "";
                editVorname.EditValue = pers.Vorname ?? "";
                editAHVNummer.EditValue = pers.AHVNummer ?? "";
                editBaPersonID.EditValue = pers.ID;
                editGeburtsdatum.EditValue = pers.Geburtsdatum;
                editNummer.EditValue = pers.HausNr ?? "";
                editOrt.EditValue = pers.Ort ?? "";
                editPLZ.EditValue = pers.Plz ?? "";
                editStrasse.EditValue = pers.Strasse ?? "";
                editVersNr.EditValue = pers.Versichertennummer;

                editGeschlecht.EditValue = pers.GeschlechtCode;
                editNationalitaet.EditValue = pers.NationalitaetCode;

                editKanton.EditValue = pers.Kanton ?? "";
                editLand.EditValue = pers.LandId;
                editAdressZusatz.EditValue = pers.Zusatz ?? "";
                editPstfach.EditValue = pers.Postfach ?? "";
            }
        }

        private void tabListeSuchen_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // do search if from tabSuche
            if (_doRunSearch && tabListeSuchen.IsTabSelected(tpgListe))
            {
                // load searched data
                FillPersonen(false);
            }
        }

        private void tabPerson_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (tabPerson.SelectedTabIndex == 1 && _firstTime)
            {
                qryNeuePerson["Name"] = editNameX.EditValue;
                qryNeuePerson["Vorname"] = editVornameX.EditValue;
                qryNeuePerson["AHVNummer"] = editAHVNummerX.EditValue;
                qryNeuePerson["Versichertennummer"] = editVersichertennrX.EditValue;
                qryNeuePerson["NationalitaetCode"] = editNationalitaetX.EditValue;
                qryNeuePerson["Geburtsdatum"] = editGeburtVonX.EditValue;
                qryNeuePerson["PersonSichtbarSDFlag"] = 1;
                _firstTime = false;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Gets the person id for the current person
        /// </summary>
        /// <param name="checkIfFallExist">Decide if it checkes for an existing case</param>
        /// <returns></returns>
        public int? GetPersonIDCreateIfNecessary(bool checkIfFallExist)
        {
            try
            {
                if (tabPerson.SelectedTabIndex == 0)
                {
                    // Suche im KiSS
                    if (editBaPersonID.EditValue == null || editBaPersonID.EditValue.Equals(string.Empty))
                    {
                        throw new KissCancelException(KissMsg.GetMLMessage("CtlSuchePerson", "KeinePersonAusgewaehlt", "Es wurde keine Person ausgewählt!", KissMsgCode.MsgError));
                    }

                    int personSichtbarSdFlag = 1;
                    int baPersonID = Convert.ToInt32(editBaPersonID.EditValue.ToString());

                    Person prs = _personService.GetByID(baPersonID.ToString());

                    bool isNewodPerson = prs.GetType() == typeof(NewodPerson);
                    // its a newod person, we need to create a baperson first
                    if (isNewodPerson)
                    {
                        personSichtbarSdFlag = 0;

                        if (!Session.User.IsUserKA)
                            personSichtbarSdFlag = 1;

                        BaPersonService baPersonService = new BaPersonService();

                        baPersonID = Convert.ToInt32(baPersonService.Insert(prs).ID);

                        // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                        XLog.Create("KiSS4.Schnittstellen.Newod", 4, LogLevel.INFO, "neuer Fall", PersonService.GetLogString(prs), "BaPerson", baPersonID);

                        PersonBasisDaten basisdaten = new PersonBasisDaten();
                        PersonAdressDaten adresse = new PersonAdressDaten();
                        basisdaten.ID = baPersonID.ToString();

                        BaPerson newBaPerson = new BaPerson(basisdaten, adresse);

                        ServiceResult resultMapping = _personService.MapPerson2NewodPerson(newBaPerson, prs);

                        if (resultMapping.Success)
                        {
                            BaPersonNewodFlags flags = _personService.CalculateNewodFlags(basisdaten.ID);
                            flags.kiSS = true;

                            try
                            {
                                _personService.UpdateNewodFlags(basisdaten.ID, flags, true, true);
                                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                                XLog.Create("KiSS4.Schnittstellen.Newod", 3, LogLevel.INFO, "Herstellen", String.Format("Verbindung mit NEWOD ID: {0} hergestellt", prs.ID), "BaPerson", baPersonID);
                            }
                            catch (Exception ex)
                            {
                                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                                XLog.Create(GetType().FullName, 3, LogLevel.ERROR, "Fehler", String.Format("NEWOD ID: {0}. " + ex.Message, prs.ID), "BaPerson", baPersonID);
                            }
                        }
                    }

                    if (checkIfFallExist)
                    {
                        //Prüfen, ob schon eine aktive Fallführung besteht
                        int count = (int)DBUtil.ExecuteScalarSQL(@"
                              SELECT COUNT(*) FROM FaFall
                              WHERE  BaPersonID = {0} AND
                                     DatumBis IS NULL",
                            baPersonID);

                        if (count > 0)
                        {
                            KissInfoException ex = new KissInfoException(KissMsg.GetMLMessage("CtlSuchePerson", "BereitsAktiverFall", "Für diese Person gibt es bereits einen aktiven Fall!", KissMsgCode.MsgInfo));

                            ex.ShowMessage();
                            throw ex;
                        }
                    }

                    //Wenn die Person aus dem Newod importiert wurde, haben wir bereits einen History-Eintrag
                    if (!isNewodPerson)
                    {
                        DBUtil.NewHistoryVersion();
                    }

                    DBUtil.ExecSQL(@"
                          UPDATE dbo.BaPerson
                          SET PersonSichtbarSDFlag = CONVERT(BIT, {0}), Modifier = {1}, Modified = GetDate()
                          WHERE BaPersonID = {2}", personSichtbarSdFlag, DBUtil.GetDBRowCreatorModifier(), baPersonID);

                    return baPersonID;
                }

                if (tabPerson.SelectedTabIndex == 1)
                {
                    // Person neu erfassen
                    if (!qryNeuePerson.CanInsert)
                    {
                        throw new KissInfoException(KissMsg.GetMLMessage("DlgPersonSucheNeu", "KeineBerechtigung", "Sie haben nicht die Berechtigung, eine neue Person zu erfassen!", KissMsgCode.MsgInfo));
                    }

                    DBUtil.CheckNotNullField(editNameNeu);
                    DBUtil.CheckNotNullField(editVornameNeu);

                    if (!editVersNrNeu.ValidateVersNr(true, false))
                    {
                        // set focus
                        editVersNrNeu.Focus();

                        // cancel, message already shown
                        throw new KissCancelException(string.Empty);
                    }

                    if (!KissMsg.ShowQuestion("DlgPersonSucheNeu", "IstInPersonenstamm", "Sind Sie sicher, dass '{0} {1}' nicht bereits im Personenstamm erfasst ist?", 0, 0, true, qryNeuePerson["Vorname"], qryNeuePerson["Name"]))
                    {
                        throw new KissCancelException(string.Empty);
                    }

                    qryNeuePerson["PersonSichtbarSDFlag"] = !Session.User.IsUserKA;

                    DBUtil.NewHistoryVersion();
                    if (!qryNeuePerson.Post())
                        throw new KissCancelException();

                    return (int)qryNeuePerson["BaPersonID"];
                }
            }
            catch (Exception ex)
            {
                // check type of exception
                if (ex is KissCancelException)
                {
                    // show message from info/cancel
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        KissMsg.ShowInfo(ex.Message);
                    }
                }
                else
                {
                    KissMsg.ShowError("DlgPersonSucheNeu", "ErrorCreateNewPerson", "Es ist ein Fehler beim Erstellen der neuen Person aufgetreten.", ex);
                }
            }
            return null;
        }

        public override void OnSearch()
        {
            if (tabPerson.SelectedTabIndex == 0 && tabListeSuchen.SelectedTabIndex == 1)
            {
                FillPersonen(false);
            }
            else
            {
                tabPerson.SelectedTabIndex = 0;
                tabListeSuchen.SelectedTabIndex = 1;
                NeueSuche();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Reset all detail fields
        /// </summary>
        private void ClearDetailFields()
        {
            editName.EditValue = "";
            editVorname.EditValue = "";
            editAdressZusatz.EditValue = "";
            editAHVNummer.EditValue = "";
            editBaPersonID.EditValue = "";
            editGeburtsdatum.Text = "";

            editGeschlecht.EditValue = null;
            editKanton.EditValue = "";
            editLand.EditValue = null;

            editNationalitaet.EditValue = null;

            editNummer.EditValue = "";
            editOrt.EditValue = "";
            editPLZ.EditValue = "";
            editPstfach.EditValue = "";
            editStrasse.EditValue = "";
            editVersNr.EditValue = "";
        }

        private void FillPersonen(bool noRows)
        {
            ClearDetailFields();

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (noRows)
                {
                    grdPerson.DataBindings.Clear();
                    grdPerson.DataSource = null;
                    grdPerson.DataSource = _personService.AllPersons;

                    Cursor.Current = Cursors.Default;
                    return;
                }

                // updates the search criterias with the current data in the fields
                searchCriteriaBindingSource.EndEdit();

                var result = _personService.SearchPerson(
                    Convert.ToBoolean(editSucheKissX.EditValue),
                    Convert.ToBoolean(editSucheNewodX.EditValue),
                    (PersonSearchCriteria)searchCriteriaBindingSource.DataSource);

                if (result.Success)
                {
                    List<GuiPerson> lst = PrepareGuiPersonList(_personService.KissPersons, _personService.NewodPersons);

                    // setup fields
                    _doRunSearch = false;
                    grdPerson.DataBindings.Clear();
                    grdPerson.DataSource = null;
                    grdPerson.DataSource = lst;

                    tabListeSuchen.SelectedTabIndex = 0;
                    grdPerson.Focus();

                    if (grvPerson.RowCount > 0)
                    {
                        // first person is shown in detail view
                        grvPerson_FocusedRowChanged(grvPerson, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
                    }
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string error in result.Errors)
                    {
                        sb.Append(error);
                        sb.Append("\n");
                    }

                    KissMsg.ShowError("CtlSuchePerson", "ErrorFillPersons", sb.ToString());
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlSuchePerson", "ErrorFillPersons", "Fehler beim Suchen der Daten.", ex);
            }
            finally
            {
                // setup fields
                _doRunSearch = true;

                Cursor.Current = Cursors.Default;
            }
        }

        private int GetIndexByIdFromNewodPersons(List<NewodPerson> newodPersonen, string id)
        {
            int index = 0;

            foreach (NewodPerson person in newodPersonen)
            {
                if (person.ID != null)
                {
                    if (person.ID.Equals(id))
                    {
                        return index;
                    }
                }

                index++;
            }

            return -1;
        }

        /// <summary>
        /// Reset all search input fields
        /// </summary>
        private void NeueSuche()
        {
            searchCriteriaBindingSource.DataSource = new PersonSearchCriteria();

            editFTX.Checked = false;
            editSoundexX.Checked = false;
            editSucheKissX.Checked = true;
            editSucheNewodX.Checked = false;

            editNameX.Focus();
        }

        private List<GuiPerson> PrepareGuiPersonList(List<BaPerson> kissPersonen, List<NewodPerson> newodPersonen)
        {
            List<GuiPerson> lst = new List<GuiPerson>();
            GuiPerson guiprs;

            //KiSSPersonen
            foreach (BaPerson person in kissPersonen)
            {
                guiprs = new GuiPerson(true, false, person.Basisdaten, person.AdressDaten);

                // Besteht ein Newod Mapping?
                if (!string.IsNullOrEmpty(person.NewodFlags.NewodID))
                {
                    guiprs.IsNewod = true;

                    // Suche die gemappte NewodPerson im Suchresultat der NewodSuche
                    int i = GetIndexByIdFromNewodPersons(newodPersonen, person.NewodFlags.NewodID);

                    if (i != -1)
                    {
                        // Aus der Liste entfernen
                        newodPersonen.RemoveAt(i);
                    }
                }

                lst.Add(guiprs);
            }

            //NewodPersonen
            foreach (NewodPerson person in newodPersonen)
            {
                if (!_personService.IsMapped(person))
                {
                    guiprs = new GuiPerson(false, true, person.Basisdaten, person.AdressDaten);
                    lst.Add(guiprs);
                }
            }

            return lst;
        }

        #endregion

        #endregion
    }
}