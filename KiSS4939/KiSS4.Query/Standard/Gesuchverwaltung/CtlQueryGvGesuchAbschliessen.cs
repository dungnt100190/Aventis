using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Query
{
    public partial class CtlQueryGvGesuchAbschliessen : KissQueryControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlQueryGvGesuchAbschliessen";
        private const string IS_SELECTED = "IsSelected";
        private const string MITARBEITER = "Mitarbeiter";

        #endregion

        #endregion

        #region Constructors

        public CtlQueryGvGesuchAbschliessen()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void btnGesucheAbschliessen_Click(object sender, EventArgs e)
        {
            //Ask for confirmation
            if (!KissMsg.ShowQuestion(
                CLASSNAME,
                "FrageGesucheAbschliessen",
                "Wollen Sie die selektierten Gesuche wirklich abschliessen?")
                )
            {
                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "AbschliessenAbgebrochen", "Gesuchsabschlussvorgang abgebrochen"));
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
            else
            {
                GesucheAbschliessenFortschrittDialog();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetFlagOnAllRows(true);
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            SetFlagOnAllRows(false);
        }

        private void CtlQueryGvGesuchAbschliessen_Load(object sender, EventArgs eventArgs)
        {
            SetupFieldName();

            // INIT
            SetupEdtSucheFonds();

            // start with new search
            NewSearch();

            //make sure, the gridview is editable (is set to false in super-class)
            grvGesuchAbschliessen.OptionsBehavior.Editable = true;
        }

        private void edtSucheGesuchsteller_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = !DialogKlient(e, edtSucheGesuchsteller);
        }

        private void qryQuery_BeforePost(object sender, EventArgs e)
        {
            //Der Benutzer kann keine Änderungen an den Daten vornehmen (ausser Dossiers/Fallträger löschen)
            //Selektion einer Zeile im Grid wird im Query aber bereits als Daten-Mutation angesehen und wird beim
            //Fokus-Wechsel "abgespeichert".
            //-> Query als nicht-modifiziert markieren
            qryQuery.Row.RejectChanges();
            qryQuery.RowModified = false;
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            ctlKGSKostenstelleSAR.InitControlForNewSearch();
            base.NewSearch();
        }

        #endregion

        #region Private Methods

        private bool DialogKlient(UserModifiedFldEventArgs e, KissButtonEdit edt)
        {
            try
            {
                // check if data can be altered
                if (edt.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // validate edt
                if (edt != edtSucheGesuchsteller)
                {
                    // do nothing
                    return false;
                }

                // prepare search string
                string searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edt.EditValue))
                {
                    // prepare for database search
                    searchString = edt.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        // user
                        edt.EditValue = null;
                        edt.LookupID = null;

                        // done
                        return true;
                    }
                }

                // search user (only within KGS and those who are not yet in use within this Einsatzvereinbarung)
                var dlg = new KissLookupDialog();

                e.Cancel =
                    !dlg.SearchData(
                        String.Format(
                            @"
                            SELECT PRS.*
                            FROM dbo.fnDlgPersonSuchenKGS({0}, 1, N'{1}') PRS
                            WHERE PRS.Name LIKE N'{1}%';",
                            Session.User.UserID,
                            searchString),
                        searchString,
                        e.ButtonClicked,
                        null,
                        null,
                        null);

                if (!e.Cancel)
                {
                    // user
                    edt.EditValue = dlg["Name"];
                    edt.LookupID = dlg["BaPersonID$"];

                    // success
                    return true;
                }

                // canceled or error
                return false;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(MethodBase.GetCurrentMethod().ReflectedType.Name, "ErrorIKissUserModified", "Fehler bei der Verarbeitung.", ex);
                return false;
            }
        }

        private void GesuchAbschliessen(int gesuchID, int baPersonID)
        {
            //Transaktion öffnen
            Session.BeginTransaction();
            // hier darf kein Code stehen!
            try
            {
                DBUtil.ExecSQLThrowingException(@"
                    UPDATE dbo.GvGesuch
                      SET GvStatusCode = {2},
                          AbschlussDatum = {3}
                    WHERE GvGesuchID = {0}
                      AND BaPersonID = {1};",
                    gesuchID,
                    baPersonID,
                    LOVsGenerated.GvStatus.Abgeschlossen,
                    DateTime.Today);

                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "GesuchsabschlussvorgangGemacht", "Gesuch Nummer: {0} wurde abgeschlossen", gesuchID));

                Session.Commit();
                // hier darf kein Code stehen!
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                DlgProgressLog.AddLine(
                    KissMsg.GetMLMessage(
                        CLASSNAME,
                        "GesuchsabschlussvorgangFehlgeschlagen",
                        "Abschliessen des Gesuches Nummer: {0} ist fehlgeschlagen. Fehler: {1}",
                        gesuchID,
                        ex.Message));
            }
        }

        private void GesucheAbschliessenFortschrittDialog()
        {
            // Alle selektierten Gesuche abschliessen
            DlgProgressLog.Show
                (
                    KissMsg.GetMLMessage(CLASSNAME, "FortschrittGesucheAbschliessen", "Fortschritt: Gesuche abschliessen"),
                    700,
                    300,
                    SchliesseGesucheAbStart,
                    SchliesseGesucheAbEnd,
                    Session.MainForm
                );
        }

        private void SchliesseGesucheAbEnd()
        {
            qryQuery.Refresh();
        }

        private void SchliesseGesucheAbStart()
        {
            try
            {
                /*Change Cursor*/
                Cursor = Cursors.WaitCursor;

                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "AbschliessenGestartet", "Gesuchsabschlussvorgang gestartet..."));
                DlgProgressLog.ShowTopMost();

                //perform task
                foreach (DataRow row in qryQuery.DataTable.Rows)
                {
                    if (DlgProgressLog.CancellledByUser)
                    {
                        return;
                    }

                    bool isSelected = Utils.ConvertToBool(row[IS_SELECTED]);

                    if (isSelected)
                    {
                        int baPersonID = Utils.ConvertToInt(row[DBO.vwPerson.BaPersonID]);
                        int gesuchID = Utils.ConvertToInt(row[DBO.GvGesuch.GvGesuchID]);

                        //Gesuch abschliessen
                        GesuchAbschliessen(gesuchID, baPersonID);
                    }
                }
            }
            finally
            {
                /*Change Cursor*/
                Cursor = Cursors.Default;

                DlgProgressLog.AddLine(KissMsg.GetMLMessage(CLASSNAME, "AbschliessenAbgeschlossen", "Gesuchsabschlussvorgang erledigt"));
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        private void SetFlagOnAllRows(bool flagStatus)
        {
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                row[IS_SELECTED] = flagStatus;
            }
        }

        private void SetupEdtSucheFonds()
        {
            // Query für Suche: Fonds (nur bestimmte Fonds anzeigen)
            var qrySearchGvFonds =
                DBUtil.OpenSQL(
                    @"
                    DECLARE @UserId INT;
                    SET @UserId = {0};

                    SELECT [GvFondsID] = NULL,
                           [NameKurz] = '',
                           [GvFondsTypCode] = NULL

                    UNION

                    SELECT DISTINCT
                      FND.GvFondsID,
                      FND.NameKurz,
                      FND.GvFondsTypCode
                    FROM dbo.GvFonds                   FND    WITH (READUNCOMMITTED)
                      INNER JOIN dbo.GvFonds_XOrgUnit  FOU    WITH (READUNCOMMITTED) ON FOU.GvFondsID = FND.GvFondsID
                      -- Kantonale Geschäftsstellen
                      LEFT  JOIN dbo.XOrgUnit          ORG_KG WITH (READUNCOMMITTED) ON ORG_KG.OrgUnitID = FOU.OrgUnitID
                      -- Fonds Schweiz (Hauptsitz)
                      LEFT  JOIN dbo.XOrgUnit          ORG_CH WITH (READUNCOMMITTED) ON ORG_CH.OrgUnitID = FOU.OrgUnitId
                                                                                    AND ORG_CH.OEItemTypCode = 1
                    WHERE FND.GvFondsTypCode = 1
                      AND (ORG_KG.Mandantennummer = dbo.fnOrgUnitOfUserMandantenNr(@UserId)
                           OR ORG_CH.OrgUnitID IS NOT NULL)
                    ORDER BY NameKurz;",
                    Session.User.UserID);
            edtSucheFonds.LoadQuery(qrySearchGvFonds, DBO.GvFonds.GvFondsID, DBO.GvFonds.NameKurz);
        }

        private void SetupFieldName()
        {
            colAbschliessenCheckBox.FieldName = IS_SELECTED;
            colAutor.FieldName = MITARBEITER;
            colBewilligt.FieldName = DBO.GvGesuch.BetragBewilligt;
            colEntscheid.FieldName = DBO.GvGesuch.BewilligtAm;
            colErstellDatum.FieldName = DBO.GvGesuch.GesuchsDatum;
            colGesuchsgrund.FieldName = DBO.GvGesuch.Gesuchsgrund;
            colGesuchID.FieldName = DBO.GvGesuch.GvGesuchID;
            colKlient.FieldName = DBO.vwPerson.NameVorname;
            colNameFonds.FieldName = DBO.GvFonds.NameKurz;
        }

        #endregion

        #endregion
    }
}