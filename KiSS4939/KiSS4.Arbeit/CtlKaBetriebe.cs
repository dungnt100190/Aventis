using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Arbeit
{
    public partial class CtlKaBetriebe : KissSearchUserControl
    {
        #region Constructors

        public CtlKaBetriebe()
        {
            InitializeComponent();

            tabControlSearch.SelectedTabIndex = 1;
            colCharakter.ColumnEdit = grdKaBetrieb.GetLOVLookUpEdit("KaBetriebCharakter");
            tabBetrieb.SelectedTabIndex = 1;

            qryKaBetrieb_PositionChanged(null, null);
            qryKaBetrieb.EnableBoundFields(false);

            tpgKontakt.Enabled = tabControlSearch.SelectedTabIndex == 0;
            tpgUebersicht.Enabled = tabControlSearch.SelectedTabIndex == 0;
            tpgVerlauf.Enabled = tabControlSearch.SelectedTabIndex == 0;
            tpgDokumente.Enabled = tabControlSearch.SelectedTabIndex == 0;
            tpgEinsatzplaetze.Enabled = tabControlSearch.SelectedTabIndex == 0;
        }

        #endregion

        #region EventHandlers

        private void btnJumpToEP_Click(object sender, EventArgs e)
        {
            FormController.SendMessage("FrmKaEinsatzorte", "Action", "JumpToEP", "KaEinsatzplatzID", qryKaEinsatzplatz["KaEinsatzplatzID"]);
        }

        private void edtBetriebDokumentAbsender_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtBetriebDokumentAbsender.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryKaBetriebDokument["AbsenderID"] = DBNull.Value;
                    qryKaBetriebDokument["Absender"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(
                string.Format(@"
                    SELECT ID$ = UserID,
                           [Name] = NameVorname,
                           [Bemerkung] = OrgUnit
                    FROM dbo.vwUser
                    WHERE NameVorname like '%' + {{0}} + '%'
                      AND LogonName like 'KA%'

                    UNION ALL

                    SELECT ID$ = -KaBetriebKontaktID,
                           [Name] = Name + IsNull(', ' + Vorname, ''),
                           [Bemerkung] = Funktion
                    FROM dbo.KaBetriebKontakt WITH (READUNCOMMITTED)
                    WHERE KaBetriebID = {0}
                    ORDER BY [Name];",
                    qryKaBetrieb["KaBetriebID"]),
              searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryKaBetriebDokument["AbsenderID"] = dlg[0];
                qryKaBetriebDokument["Absender"] = dlg[1];
            }
        }

        private void edtBetriebDokumentAdressat_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtBetriebDokumentAdressat.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryKaBetriebDokument["AdressatID"] = DBNull.Value;
                    qryKaBetriebDokument["Adressat"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(
                string.Format(@"
                    SELECT ID$ = UserID,
                           [Name] = NameVorname,
                           [Bemerkung] = OrgUnit
                    FROM dbo.vwUser
                    WHERE NameVorname like '%' + {{0}} + '%'
                      AND LogonName like 'KA%'

                    UNION ALL

                    SELECT ID$ = -KaBetriebKontaktID,
                           [Name] = Name + IsNull(', ' + Vorname, ''),
                           [Bemerkung] = Funktion
                    FROM dbo.KaBetriebKontakt WITH (READUNCOMMITTED)
                    WHERE KaBetriebID = {0}
                    ORDER BY [Name];",
                    qryKaBetrieb["KaBetriebID"]),
              searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryKaBetriebDokument["AdressatID"] = dlg[0];
                qryKaBetriebDokument["Adressat"] = dlg[1];
            }
        }

        private void edtUnterbetriebVon_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtUnterbetriebVon.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryKaBetrieb["TeilbetriebID"] = DBNull.Value;
                    qryKaBetrieb["TeilbetriebName"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
              SELECT ID$                 = BET.KaBetriebID,
                     Betrieb             = BET.BetriebName,
                     Adresse             = IsNull(ADR.PLZ, '') + IsNull(' ' + ADR.Ort, '') + IsNull(', ' + ADR.Strasse, '') + IsNull(' ' + ADR.HausNr, '')
              FROM   dbo.KaBetrieb BET WITH (READUNCOMMITTED)
                     inner join dbo.BaAdresse ADR WITH (READUNCOMMITTED) on ADR.KaBetriebID = BET.KaBetriebID
                                               and GetDate() between isNull(ADR.DatumVon, GetDate()) and isNull(ADR.DatumBis, GetDate())
              WHERE  BET.BetriebName LIKE '%' + {0} + '%'
              ORDER BY BET.BetriebName",
              searchString,
              e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryKaBetrieb["TeilbetriebID"] = dlg[0];
                qryKaBetrieb["TeilbetriebName"] = dlg[1];
            }
        }

        private void edtUseZusatzadresse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (qryKaBetriebKontakt.IsInserting || (qryKaBetriebKontakt.IsBinding && qryKaBetriebKontakt.Count == 0))
            {
                qryZusatzadresse.CanInsert = false;
                qryZusatzadresse.CanUpdate = false;
                qryZusatzadresse.CanDelete = false;
            }
            else
            {
                var useZusatzadresse = (bool)edtUseZusatzadresse.EditValue;

                qryZusatzadresse.CanInsert = useZusatzadresse && DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "I");
                qryZusatzadresse.CanUpdate = useZusatzadresse && DBUtil.UserHasRight("CtlKaBetriebe", "U") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "U");
                qryZusatzadresse.CanDelete = useZusatzadresse && DBUtil.UserHasRight("CtlKaBetriebe", "D") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "D");

                if (qryZusatzadresse.CanUpdate && qryZusatzadresse.Count == 0)
                {
                    qryZusatzadresse.Insert(qryZusatzadresse.TableName);
                    qryZusatzadresse["DatumVon"] = DateTime.Today;
                }
                else
                {
                    qryZusatzadresse.Refresh();
                }

                if (useZusatzadresse)
                {
                    edtKontaktStrasse.Focus();
                }
            }
        }

        private void qryBaAdresse_AfterInsert(object sender, EventArgs e)
        {
            qryBaAdresse.SetCreator();
            qryBaAdresse.SetModifierModified();
        }

        private void qryBaAdresse_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            switch (e.Column.ColumnName)
            {
                case "Strasse":
                case "HausNr":
                    qryKaBetrieb["StrasseNr"] = string.Format("{0} {1}", qryBaAdresse["Strasse"], qryBaAdresse["HausNr"]);
                    break;
            }
        }

        private void qryBaAdresse_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            qryKaBetrieb.RowModified = true;
        }

        private void qryKaBetriebDokument_AfterInsert(object sender, EventArgs e)
        {
            qryKaBetriebDokument["KaBetriebID"] = qryKaBetrieb["KaBetriebID"];
            qryKaBetriebDokument["Datum"] = DateTime.Today;
            edtBetriebDokumentDatum.Focus();
        }

        private void qryKaBetriebDokument_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBetriebDokumentDatum, lblBetriebDokumentDatum.Text);
            DBUtil.CheckNotNullField(edtBetriebDokumentStichwort, lblBetriebDokumentStichwort.Text);
        }

        private void qryKaBetriebKontakt_AfterDelete(object sender, EventArgs e)
        {
            qryZusatzadresse.Refresh();
        }

        private void qryKaBetriebKontakt_AfterFill(object sender, EventArgs e)
        {
            if (qryKaBetriebKontakt.Count == 0)
            {
                qryKaBetriebKontakt_PositionChanged(sender, null);
            }

            SetEditMode();
        }

        private void qryKaBetriebKontakt_AfterInsert(object sender, EventArgs e)
        {
            qryKaBetriebKontakt["KaBetriebID"] = qryKaBetrieb["KaBetriebID"];
        }

        private void qryKaBetriebKontakt_AfterPost(object sender, EventArgs e)
        {
            if (qryZusatzadresse.RowModified)
            {
                qryZusatzadresse["KaBetriebKontaktID"] = qryKaBetriebKontakt["KaBetriebKontaktID"];
                qryZusatzadresse.SetModifierModified();

                qryZusatzadresse.CanInsert = DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "I");
                qryZusatzadresse.CanUpdate = DBUtil.UserHasRight("CtlKaBetriebe", "U") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "U");
                qryZusatzadresse.CanDelete = DBUtil.UserHasRight("CtlKaBetriebe", "D") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "D");

                if (!qryZusatzadresse.Post())
                {
                    throw new KissCancelException();
                }
            }
        }

        private void qryKaBetriebKontakt_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtKontaktName, "Name");

            if ((bool)edtUseZusatzadresse.EditValue)
            {
                DBUtil.CheckNotNullField(edtKontaktVorname, "Vorname");
                DBUtil.CheckNotNullField(edtKontaktGeschlechtCode, "Geschlecht");

                if (DBUtil.IsEmpty(edtKontaktPLZOrtLand.Ort))
                {
                    KissMsg.ShowInfo("CtlKaBetriebe", "OrtLeer", "Das Feld Ort darf nicht leer sein!");
                    edtKontaktPLZOrtLand.Focus();
                    throw new KissCancelException();
                }
            }

            // HISTORY
            // new history entry
            if (qryKaBetriebKontakt.RowModified)
            {
                DBUtil.NewHistoryVersion();
            }

            qryKaBetriebKontakt["Kontaktperson"] = string.Format("{0}, {1}", qryKaBetriebKontakt["Name"], qryKaBetriebKontakt["Vorname"]);
        }

        private void qryKaBetriebKontakt_PositionChanged(object sender, EventArgs e)
        {
            if (qryKaBetriebKontakt.Count == 0)
            {
                qryProgKontakt.Fill(DBNull.Value);
                qryZusatzadresse.Fill(DBNull.Value);
            }
            else
            {
                if (ActiveSQLQuery.Count > 0 && ActiveSQLQuery.Row.RowState != DataRowState.Added)
                    ActiveSQLQuery.Post();

                qryProgKontakt.Fill(qryKaBetriebKontakt["KaBetriebKontaktID"]);
                qryZusatzadresse.Fill(qryKaBetriebKontakt["KaBetriebKontaktID"]);

                if (qryZusatzadresse.CanUpdate && qryZusatzadresse.Count == 0)
                {
                    qryZusatzadresse.Insert(qryZusatzadresse.TableName);
                    qryZusatzadresse["DatumVon"] = DateTime.Today;
                }

            }
        }

        private void qryKaBetriebVerlauf_AfterInsert(object sender, EventArgs e)
        {
            qryKaBetriebVerlauf["KaBetriebID"] = qryKaBetrieb["KaBetriebID"];
            qryKaBetriebVerlauf["Datum"] = DateTime.Today;
            qryKaBetriebVerlauf["AutorID"] = Session.User.UserID;
            qryKaBetriebVerlauf["Autor"] = Session.User.LastName + ", " + Session.User.FirstName;
        }

        private void qryKaBetriebVerlauf_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtBesprechungDatum, lblDatum.Text);
            DBUtil.CheckNotNullField(edtBesprechungStichwort, lblStichworte.Text);

            qryKaBetriebVerlauf["Kontaktperson"] = edtKontaktperson.Text;
        }

        private void qryKaBetrieb_AfterFill(object sender, EventArgs e)
        {
            if (qryKaBetrieb.Count == 0)
            {
                qryKaBetrieb_PositionChanged(sender, null);
            }

            SetEditMode();
        }

        private void qryKaBetrieb_AfterPost(object sender, EventArgs e)
        {
            if (qryBaAdresse.RowModified)
            {
                DBUtil.NewHistoryVersion();
            }

            qryBaAdresse[DBO.BaAdresse.KaBetriebID] = qryKaBetrieb[DBO.KaBetrieb.KaBetriebID];
            qryBaAdresse.SetModifierModified();

            if (!qryBaAdresse.Post())
            {
                throw new KissCancelException();
            }
        }

        private void qryKaBetrieb_BeforeDelete(object sender, EventArgs e)
        {
            int cnt = 0;

            try
            {
                cnt = (int)DBUtil.ExecuteScalarSQL(
                    @"SELECT COUNT(*)
                      FROM dbo.KaVermittlungVorschlag VER
                      WHERE VER.KaEinsatzplatzID IN (SELECT EIN.KaEinsatzplatzID
                                                     FROM dbo.KaEinsatzplatz EIN
                                                     WHERE EIN.KaBetriebID = {0})", qryKaBetrieb["KaBetriebID"]);
            }
            catch { }

            if (cnt > 0)
            {
                KissMsg.ShowInfo("CtlKaBetriebe", "LoeschenBetriebNichtMoeglich", "Betrieb kann nicht gelöscht werden, \r\nes bestehen noch abhängige Daten.");
                throw new KissCancelException();
            }

            DBUtil.NewHistoryVersion();
            DBUtil.ExecSQL(@"DELETE BaAdresse WHERE KaBetriebID = {0}", qryKaBetrieb["KaBetriebID"]);
            DBUtil.ExecSQL(@"DELETE BaAdresse WHERE KaBetriebKontaktID = {0}", qryKaBetriebKontakt["KaBetriebKontaktID"]);

            DBUtil.ExecSQL(@"DELETE KaEinsatzplatz WHERE KaBetriebID = {0}", qryKaBetrieb["KaBetriebID"]);
            DBUtil.ExecSQL(@"DELETE KaBetriebKontakt WHERE KaBetriebID = {0}", qryKaBetrieb["KaBetriebID"]);
            DBUtil.ExecSQL(@"DELETE KaBetriebBesprechung WHERE KaBetriebID = {0}", qryKaBetrieb["KaBetriebID"]);
            DBUtil.ExecSQL(@"DELETE KaBetriebDokument WHERE KaBetriebID = {0}", qryKaBetrieb["KaBetriebID"]);
        }

        private void qryKaBetrieb_BeforeInsert(object sender, EventArgs e)
        {
            if (tabControlSearch.SelectedTabIndex == 1)
            {
                throw new KissCancelException();
            }

            tabBetrieb.SelectedTabIndex = 1;
        }

        private void qryKaBetrieb_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(edtName, lblName.Text);

            if (DBUtil.IsEmpty(edtPLZOrtLand.Ort))
            {
                KissMsg.ShowInfo("CtlKaBetriebe", "OrtLeer", "Das Feld Ort darf nicht leer sein!");
                tabBetrieb.SelectedTabIndex = 1;
                edtPLZOrtLand.Focus();
                throw new KissCancelException();
            }

            // HISTORY
            // new history entry
            if (qryKaBetrieb.RowModified)
            {
                DBUtil.NewHistoryVersion();
            }
        }

        private void qryKaBetrieb_PositionChanged(object sender, EventArgs e)
        {
            if (qryKaBetrieb.Count == 0)
            {
                qryBaAdresse.Fill(DBNull.Value);
                qryKaBetriebKontakt.Fill(DBNull.Value);
                qryTeilbetriebe.Fill(DBNull.Value);
                qryKaBetriebVerlauf.Fill(DBNull.Value);
                qryKontaktperson.Fill(DBNull.Value);
                qryKaBetriebDokument.Fill(DBNull.Value);
                qryKaEinsatzplatz.Fill(DBNull.Value);
                qryKaProgramm.Fill(DBNull.Value);
                qryKaBranche.Fill(DBNull.Value);
                qryKaLehrberuf.Fill(DBNull.Value);
                qryProgKontakt.Fill(DBNull.Value);
            }
            else
            {
                if (ActiveSQLQuery.Count > 0 && ActiveSQLQuery.Row.RowState != DataRowState.Added)
                    ActiveSQLQuery.Post();

                qryBaAdresse.Fill(qryKaBetrieb["KaBetriebID"]);
                qryKaBetriebKontakt.Fill(qryKaBetrieb["KaBetriebID"]);
                qryTeilbetriebe.Fill(qryKaBetrieb["KaBetriebID"]);
                qryKaBetriebVerlauf.Fill(qryKaBetrieb["KaBetriebID"]);
                qryKontaktperson.Fill(qryKaBetrieb["KaBetriebID"]);
                qryKaBetriebDokument.Fill(qryKaBetrieb["KaBetriebID"]);
                qryKaEinsatzplatz.Fill(qryKaBetrieb["KaBetriebID"]);
                qryKaProgramm.Fill(qryKaBetrieb["KaBetriebID"]);
                qryKaBranche.Fill(qryKaBetrieb["KaBetriebID"]);
                qryKaLehrberuf.Fill(qryKaBetrieb["KaBetriebID"]);
                qryProgKontakt.Fill(qryKaBetriebKontakt["KaBetriebKontaktID"]);

                if (qryBaAdresse.CanUpdate && qryBaAdresse.Count == 0)
                {
                    qryBaAdresse.Insert(qryBaAdresse.TableName);
                    qryBaAdresse["DatumVon"] = DateTime.Today;
                }

                // Insert new row when tab "Verlauf" is selected and there are
                // no rows for "Verlauf" and user has right to insert.
                if (tabBetrieb.SelectedTabIndex == 3 && qryKaBetriebVerlauf.Count == 0 && DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Verlauf", "I"))
                {
                    qryKaBetriebVerlauf.Insert();
                }

                // Insert new row when tab "Dokument" is selected and there are
                // no rows for "Dokument" and user has right to insert.
                if (tabBetrieb.SelectedTabIndex == 4 && qryKaBetriebDokument.Count == 0 && DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Dokumente", "I"))
                {
                    qryKaBetriebDokument.Insert();
                }
            }

            edtKontaktperson.LoadQuery(qryKontaktperson, "KaBetriebKontaktID", "NameVorname");
        }

        private void qryKaEinsatzplatz_AfterFill(object sender, EventArgs e)
        {
            btnJumpToEP.Enabled = qryKaEinsatzplatz.Count > 0;
        }

        private void qryZusatzadresse_AfterInsert(object sender, EventArgs e)
        {
            qryZusatzadresse.SetCreator();
            qryZusatzadresse.SetModifierModified();
        }

        private void qryZusatzadresse_BeforePost(object sender, EventArgs e)
        {
            DBUtil.NewHistoryVersion();
        }

        private void qryZusatzadresse_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            qryKaBetriebKontakt.RowModified = true;
        }

        private void tabBetrieb_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            switch (tabBetrieb.SelectedTabIndex)
            {
                case 2:
                    // Tab Kontakt
                    ActiveSQLQuery = qryKaBetriebKontakt;
                    break;
                case 3:
                    // Tab Verlauf
                    ActiveSQLQuery = qryKaBetriebVerlauf;

                    // Insert new row when tab "Verlauf" is selected and there are
                    // no rows for "Verlauf" and user has right to insert.
                    if (qryKaBetrieb.Count > 0 && qryKaBetriebVerlauf.Count == 0 && DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Verlauf", "I"))
                    {
                        qryKaBetriebVerlauf.Insert();
                    }

                    if (qryKaBetrieb.Count == 0)
                    {
                        qryKontaktperson.Fill(DBNull.Value);
                    }
                    else
                    {
                        qryKontaktperson.Fill(qryKaBetrieb["KaBetriebID"]);
                    }

                    edtKontaktperson.LoadQuery(qryKontaktperson, "KaBetriebKontaktID", "NameVorname");

                    break;
                case 4:
                    // Tab Dokument
                    ActiveSQLQuery = qryKaBetriebDokument;

                    // Insert new row when tab "Dokument" is selected and there are
                    // no rows for "Dokument" and user has right to insert.
                    if (qryKaBetrieb.Count > 0 && qryKaBetriebDokument.Count == 0 && DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Dokumente", "I"))
                    {
                        qryKaBetriebDokument.Insert();
                    }

                    break;
                default:
                    ActiveSQLQuery = qryKaBetrieb;
                    break;
            }

            btnJumpToEP.Enabled = qryKaEinsatzplatz.Count > 0;
            SetEditMode();
        }

        private void tabBetrieb_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            if (ActiveSQLQuery.Row != null && ActiveSQLQuery.Row.RowState != DataRowState.Added)
            {
                e.Cancel = !ActiveSQLQuery.Post();
            }
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            tabBetrieb.SelectedTabIndex = 1;

            tpgKontakt.Enabled = tabControlSearch.SelectedTabIndex == 0;
            tpgUebersicht.Enabled = tabControlSearch.SelectedTabIndex == 0;
            tpgVerlauf.Enabled = tabControlSearch.SelectedTabIndex == 0;
            tpgDokumente.Enabled = tabControlSearch.SelectedTabIndex == 0;
            tpgEinsatzplaetze.Enabled = tabControlSearch.SelectedTabIndex == 0;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "KABETRIEBID":
                    return qryKaBetrieb["KaBetriebID"];

                case "KABETRIEBDOKUMENTID":
                    return qryKaBetriebDokument["KaBetriebDokumentID"];

                case "KABETRIEBBESPRECHUNGID":
                    return qryKaBetriebVerlauf["KaBetriebBesprechungID"];

                case "OWNERUSERID":
                    return Session.User.UserID;

            }

            return base.GetContextValue(fieldName);
        }

        public override bool ReceiveMessage(HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param == null || param.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "LoadBetrieb":
                    if (!param.Contains("KaBetriebID"))
                    {
                        param["KaBetriebID"] = -1;
                    }
                    chkInaktiveAnzeigen.Checked = true; // #6442
                    ActiveSQLQuery = qryKaBetrieb;
                    tabControlSearch.SelectedTabIndex = 0;
                    tabBetrieb.SelectedTabIndex = 0;
                    qryKaBetrieb.Find(string.Format("KaBetriebID = {0}", param["KaBetriebID"]));
                    return true;
                case "LoadBetriebKontakt":
                    if (!param.Contains("KaBetriebID"))
                    {
                        param["KaBetriebID"] = -1;
                    }
                    if (!param.Contains("KaKontaktpersonID"))
                    {
                        param["KaKontaktpersonID"] = -1;
                    }

                    ActiveSQLQuery = qryKaBetrieb;
                    tabControlSearch.SelectedTabIndex = 0;
                    tabBetrieb.SelectedTabIndex = 0;
                    qryKaBetrieb.Find(string.Format("KaBetriebID = {0}", param["KaBetriebID"]));

                    tabBetrieb.SelectedTabIndex = 2;
                    qryKaBetriebKontakt.Find(string.Format("KaBetriebKontaktID = {0}", param["KaKontaktpersonID"]));

                    return true;
            }

            // did not understand message
            return false;
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            chkInaktiveAnzeigen.EditValue = false;
        }

        #endregion

        #region Private Methods

        private void SetEditMode()
        {
            // Set rights for qryKaBetrieb
            qryKaBetrieb.CanInsert = DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Grunddaten", "I");
            qryKaBetrieb.CanUpdate = DBUtil.UserHasRight("CtlKaBetriebe", "U") && DBUtil.UserHasRight("CtlKaBetriebe_Grunddaten", "U");

            if (tabBetrieb.SelectedTabIndex == 1)
                qryKaBetrieb.CanDelete = DBUtil.UserHasRight("CtlKaBetriebe", "D") && DBUtil.UserHasRight("CtlKaBetriebe_Grunddaten", "D");
            else
                qryKaBetrieb.CanDelete = false;

            //DBUtil.ApplyUserRightsToSqlQuery("CtlKaBetriebe", qryKaBetrieb);
            qryKaBetrieb.EnableBoundFields();

            qryBaAdresse.CanInsert = DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Grunddaten", "I");
            qryBaAdresse.CanUpdate = DBUtil.UserHasRight("CtlKaBetriebe", "U") && DBUtil.UserHasRight("CtlKaBetriebe_Grunddaten", "U");
            qryBaAdresse.CanDelete = DBUtil.UserHasRight("CtlKaBetriebe", "D") && DBUtil.UserHasRight("CtlKaBetriebe_Grunddaten", "D");

            qryKaBetriebDokument.CanInsert = DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Dokumente", "I");
            qryKaBetriebDokument.CanUpdate = DBUtil.UserHasRight("CtlKaBetriebe", "U") && DBUtil.UserHasRight("CtlKaBetriebe_Dokumente", "U");
            qryKaBetriebDokument.CanDelete = DBUtil.UserHasRight("CtlKaBetriebe", "D") && DBUtil.UserHasRight("CtlKaBetriebe_Dokumente", "D");

            qryKaBetriebKontakt.CanInsert = DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "I");
            qryKaBetriebKontakt.CanUpdate = DBUtil.UserHasRight("CtlKaBetriebe", "U") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "U");
            qryKaBetriebKontakt.CanDelete = DBUtil.UserHasRight("CtlKaBetriebe", "D") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "D");

            qryKaBetriebVerlauf.CanInsert = DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Verlauf", "I");
            qryKaBetriebVerlauf.CanUpdate = DBUtil.UserHasRight("CtlKaBetriebe", "U") && DBUtil.UserHasRight("CtlKaBetriebe_Verlauf", "U");
            qryKaBetriebVerlauf.CanDelete = DBUtil.UserHasRight("CtlKaBetriebe", "D") && DBUtil.UserHasRight("CtlKaBetriebe_Verlauf", "D");

            qryZusatzadresse.CanInsert = DBUtil.UserHasRight("CtlKaBetriebe", "I") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "I");
            qryZusatzadresse.CanUpdate = DBUtil.UserHasRight("CtlKaBetriebe", "U") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "U");
            qryZusatzadresse.CanDelete = DBUtil.UserHasRight("CtlKaBetriebe", "D") && DBUtil.UserHasRight("CtlKaBetriebe_Kontakt", "D");

            /*
                if (qryKaBetrieb.Count > 0)
                {
                    qryBaAdresse.CanInsert = DBUtil.UserHasRight("CtlKaBetriebe", "I");
                    qryBaAdresse.CanUpdate = DBUtil.UserHasRight("CtlKaBetriebe", "U");
                    qryBaAdresse.CanDelete = DBUtil.UserHasRight("CtlKaBetriebe", "D");

                    qryKaBetriebDokument.CanInsert = DBUtil.UserHasRight("CtlKaBetriebe", "I");
                    qryKaBetriebDokument.CanUpdate = DBUtil.UserHasRight("CtlKaBetriebe", "U");
                    qryKaBetriebDokument.CanDelete = DBUtil.UserHasRight("CtlKaBetriebe", "D");

                    qryKaBetriebKontakt.CanInsert = DBUtil.UserHasRight("CtlKaBetriebe", "I");
                    qryKaBetriebKontakt.CanUpdate = DBUtil.UserHasRight("CtlKaBetriebe", "U");
                    qryKaBetriebKontakt.CanDelete = DBUtil.UserHasRight("CtlKaBetriebe", "D");

                    qryKaBetriebVerlauf.CanInsert = DBUtil.UserHasRight("CtlKaBetriebe", "I");
                    qryKaBetriebVerlauf.CanUpdate = DBUtil.UserHasRight("CtlKaBetriebe", "U");
                    qryKaBetriebVerlauf.CanDelete = DBUtil.UserHasRight("CtlKaBetriebe", "D");
                }
                else
                {
                    qryBaAdresse.CanInsert = false;
                    qryBaAdresse.CanUpdate = false;
                    qryBaAdresse.CanDelete = false;

                    qryKaBetriebDokument.CanInsert = false;
                    qryKaBetriebDokument.CanUpdate = false;
                    qryKaBetriebDokument.CanDelete = false;

                    qryKaBetriebKontakt.CanInsert = false;
                    qryKaBetriebKontakt.CanUpdate = false;
                    qryKaBetriebKontakt.CanDelete = false;

                    qryKaBetriebVerlauf.CanInsert = false;
                    qryKaBetriebVerlauf.CanUpdate = false;
                    qryKaBetriebVerlauf.CanDelete = false;
                }
            */

            qryBaAdresse.EnableBoundFields();
            qryKaBetriebDokument.EnableBoundFields();
            qryKaBetriebKontakt.EnableBoundFields();
            qryKaBetriebVerlauf.EnableBoundFields();
        }

        #endregion

        #endregion
    }
}