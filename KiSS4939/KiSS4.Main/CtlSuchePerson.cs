using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Main
{
    public partial class CtlSuchePerson : KiSS4.Gui.KissUserControl, ISuchePerson
    {
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

        #region Public Properties
        public int SelectedTabIndex
        {
            get { return tabPerson.SelectedTabIndex; }
        }

        #endregion

        private bool _doRunSearch = false; // store if on tabChanged to Liste a new search has to be executed
        private bool _firstTime = true;

        public CtlSuchePerson()
        {
            InitializeComponent();
        }

        #region Public Methods

        public int? GetPersonIDCreateIfNecessary(bool checkIfFallExist)
        {
            try
            {
                if (tabPerson.SelectedTabIndex == 0)
                {
                    // Suche im KiSS
                    if (qryBaPerson.Count == 0)
                    {
                        throw new KissCancelException(KissMsg.GetMLMessage("CtlSuchePerson", "KeinePersonAusgewaehlt", "Es wurde keine Person ausgewählt!", KissMsgCode.MsgError));
                    }
                    else
                    {
                        int baPersonID = (int)qryBaPerson["BaPersonID"];
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
                        DBUtil.NewHistoryVersion();
                        DBUtil.ExecSQL(@"
                          UPDATE dbo.BaPerson
                          SET PersonSichtbarSDFlag = CONVERT(BIT, 1), Modifier = {1}, Modified = GetDate()
                          WHERE BaPersonID = {1}", DBUtil.GetDBRowCreatorModifier(), baPersonID);
                        return baPersonID;
                    }
                }
                else if (tabPerson.SelectedTabIndex == 1)
                {
                    // Person neu erfassen
                    if (!qryNeuePerson.CanInsert)
                    {
                        throw new KissInfoException(KissMsg.GetMLMessage("DlgPersonSucheNeu", "KeineBerechtigung", "Sie haben nicht die Berechtigung, eine neue Person zu erfassen!", KissMsgCode.MsgInfo));
                    }

                    DBUtil.CheckNotNullField(this.editNameNeu);
                    DBUtil.CheckNotNullField(this.editVornameNeu);
                    //DBUtil.CheckNotNullField(qryNeuePerson, "Name", KissMsg.GetMLMessage("DlgPersonSucheNeu", "Name", "Name"), this.editNameNeu);
                    //DBUtil.CheckNotNullField(qryNeuePerson, "Vorname", KissMsg.GetMLMessage("DlgPersonSucheNeu", "Vorname", "Vorname"), this.editNameNeu);

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
            //catch (KissCancelException ex)
            //{
            //    ex.ShowMessage();
            //    throw ex;
            //}
            //catch (Exception ex)
            //{
            //    KissMsg.ShowInfo(ex.Message);
            //    throw ex;
            //}
            catch (Exception ex)
            {
                // check type of exception
                if ((ex is KissCancelException || ex is KissInfoException) && ex.Message != null)
                {
                    // show message from info/cancel
                    if (!ex.Message.Equals(string.Empty))
                        KissMsg.ShowInfo(ex.Message);
                }
                else
                {
                    // show message
                    KissMsg.ShowError("DlgPersonSucheNeu", "ErrorCreateNewPerson", "Es ist ein Fehler beim Erstellen der neuen Person aufgetreten.", ex);
                }
            }
            return null;
        }

        #endregion

        #region EventHandlers

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

            //switch (tabPerson.SelectedTabIndex)
            //{
            //    case 0: if (tabSearch.SelectedTabIndex == 1)
            //        {
            //            RunSearch();
            //            tabSearch.SelectedTabIndex = 0;
            //            grdVwPerson.Focus();
            //        }
            //        else
            //        {
            //            tabPerson.SelectedTabIndex = 0;
            //            tabListeSuchen.SelectedTabIndex = 1;
            //            NeueSuche();

            //            //tabSearch.SelectedTabIndex = 1;
            //            //    foreach (Control C in Utils.AllControls(tpgSuchen))
            //            //    {
            //            //        if (C is DevExpress.XtraEditors.BaseEdit)
            //            //            ((DevExpress.XtraEditors.BaseEdit)C).EditValue = null;
            //            //    }
            //            //    edtSearchInKiSS.Checked = true;
            //            //    edtSearchInAlpha.Checked = true;
            //            //    edtSucheAuchAehnliche.Checked = true;
            //            //    edtSucheNurAktive.Checked = false;
            //            //    lblLimitierteAlphaRows.Visible = false;
            //            //    edtSucheNachname.Focus();
            //        }
            //        break;
            //}
        }

        /// TODO register
        private void CtlSuchePerson_Activated(object sender, System.EventArgs e)
        {
            this.editNameX.Focus();
        }

        private void CtlSuchePerson_Load(object sender, System.EventArgs e)
        {
            // select first tab
            this.tabPerson.SelectTab(tpgPersonSuchen);

            // setup tabs
            this.tpgPersonSuchen.Title = "Person suchen";
            this.tpgPersonErfassen.Title = "Person erfassen";

            // right management
            this.qryNeuePerson.ApplyUserRights(this.Name);
            this.qryBaPerson.ApplyUserRights(this.Name);

            // Neue Person vorbereiten
            qryNeuePerson.Fill(@"
                SELECT *
                FROM dbo.BaPerson WITH (READUNCOMMITTED)
                WHERE 1 = 2");

            if (DBUtil.UserHasRight(this.Name, "I"))
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
            this._doRunSearch = true;
        }
        private void tabListeSuchen_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // do search if from tabSuche
            if (this._doRunSearch && tabListeSuchen.IsTabSelected(tpgListe))
            {
                // load searched data
                this.FillPersonen(false);
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

        #region Private Methods

        private void FillPersonen(bool NoRows)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Demographie
                string Sql = @"
                    DECLARE @LanguageCode INT;
                    SET @LanguageCode = {0};

                    SELECT PRS.*,
                           PLZOrt     = PRS.WohnsitzPLZOrt,
                           [Alter]    = CONVERT(INT, ((DATEDIFF(dd, Geburtsdatum, GETDATE()) + .5) / 365.25)),
                           Geschlecht = dbo.fnGetGenderMLTitleMF(PRS.GeschlechtCode, @LanguageCode),
                           FT         = CONVERT(BIT, CASE WHEN EXISTS(SELECT TOP 1 1
                                                                      FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                                                      WHERE BaPersonID = PRS.BaPersonID) THEN 1
                                                          ELSE 0
                                                     END)
                    FROM dbo.vwPerson PRS
                    WHERE 1 = 1 ";

                if (NoRows)
                {
                    Sql += " AND 1=2 ";
                    qryBaPerson.Fill(Sql, Session.User.LanguageCode);
                    return;
                }

                // Name
                if (editNameX.Text != "")
                {
                    if (editSoundexX.Checked)
                    {
                        Sql += " AND SOUNDEX(PRS.Name) = SOUNDEX(" + DBUtil.SqlLiteral(editNameX.Text) + ") ";
                    }
                    else
                    {
                        Sql += " AND PRS.Name LIKE " + DBUtil.SqlLiteralLike(editNameX.Text + "%");
                    }
                }

                // Vorname
                if (editVornameX.Text != "")
                {
                    if (editSoundexX.Checked)
                    {
                        Sql += " AND SOUNDEX(PRS.Vorname) = SOUNDEX(" + DBUtil.SqlLiteral(editVornameX.Text) + ") ";
                    }
                    else
                    {
                        Sql += " AND PRS.Vorname LIKE " + DBUtil.SqlLiteralLike(editVornameX.Text + "%");
                    }
                }

                // Strasse
                if (editStrasseX.Text != "")
                {
                    Sql += " AND PRS.WohnsitzStrasse LIKE " + DBUtil.SqlLiteralLike(editStrasseX.Text + "%");
                }

                // PLZ
                if (editPLZX.Text != "")
                {
                    Sql += " AND PRS.WohnsitzPLZ LIKE " + DBUtil.SqlLiteralLike(editPLZX.Text + "%");
                }

                // Ort
                if (editOrtX.Text != "")
                {
                    Sql += " AND PRS.WohnsitzOrt LIKE " + DBUtil.SqlLiteralLike(editOrtX.Text + "%");
                }

                // Geburt von
                if (!DBUtil.IsEmpty(editGeburtVonX.EditValue))
                {
                    Sql += " AND PRS.Geburtsdatum >= " + DBUtil.SqlLiteral(editGeburtVonX.DateTime);
                }

                // Geburt bis
                if (!DBUtil.IsEmpty(editGeburtBisX.EditValue))
                {
                    Sql += " AND PRS.Geburtsdatum <= " + DBUtil.SqlLiteral(editGeburtBisX.DateTime);
                }

                // Nationalitaet
                if (!DBUtil.IsEmpty(editNationalitaetX.EditValue))
                {
                    Sql += " AND PRS.NationalitaetCode = " + DBUtil.SqlLiteral(editNationalitaetX.EditValue);
                }

                // AHVNummer
                if (editAHVNummerX.Text != "")
                {
                    Sql += " AND PRS.AHVNummer LIKE " + DBUtil.SqlLiteralLike(editAHVNummerX.Text + "%");
                }

                // Versichertennummer
                if (editVersichertennrX.Text != "")
                {
                    Sql += " AND PRS.Versichertennummer LIKE " + DBUtil.SqlLiteralLike(editVersichertennrX.Text + "%");
                }

                // nur Fallträger
                if (editFTX.Checked)
                {
                    Sql += @" AND EXISTS(SELECT TOP 1 1
                                     FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                     WHERE BaPersonID = PRS.BaPersonID)";
                }

                Sql += " ORDER BY Name, Vorname, Geburtsdatum";

                qryBaPerson.Fill(Sql, Session.User.LanguageCode);

                // setup fields
                this._doRunSearch = false;

                tabListeSuchen.SelectedTabIndex = 0;
                grdPerson.Focus();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("DlgPersonSucheNeu", "ErrorFillPersons", "Fehler beim Suchen der Daten.", ex);
            }
            finally
            {
                // setup fields
                this._doRunSearch = true;

                // setup cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void NeueSuche()
        {
            foreach (Control c in UtilsGui.AllControls(tabListeSuchen))
            {
                if (c is BaseEdit)
                {
                    ((BaseEdit)c).EditValue = null;
                }
            }

            editFTX.Checked = false;
            editSoundexX.Checked = false;

            editNameX.Focus();
        }

        #endregion

        #endregion
    }
}
