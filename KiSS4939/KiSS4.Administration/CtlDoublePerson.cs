using DevExpress.XtraEditors.Controls;
using Kiss.Infrastructure;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using System;
using System.Windows.Forms;

namespace KiSS4.Administration
{
    /// <summary>
    /// Control, used to merge duplicated persons
    /// </summary>
    public partial class CtlDoublePerson : KissUserControl
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string PERSON_A = "Person A";
        private const string PERSON_B = "Person B";

        private const string SQL = @"
            DECLARE @LanguageCode INT;
            SET @LanguageCode = {1};

            SELECT
              PRS.BaPersonID,
              PRS.NameVorname,
              PRS.WohnsitzStrasseHausNr,
              PRS.WohnsitzPostfach,
              PRS.WohnsitzPLZOrt,
              PRS.WohnsitzLand,
              PRS.AHVNummer,
              PRS.Versichertennummer,
              PRS.Geburtsdatum,
              Nationalitaet = dbo.fnLandMLText(PRS.NationalitaetCode, @LanguageCode),
              PRS.Heimatort,
              PRS.Bemerkung,
              NrNameVorname  = convert(varchar, PRS.BaPersonID) + ' ' + PRS.NameVorname,
              Geschlecht     = dbo.fnLOVMLText('Geschlecht', PRS.GeschlechtCode, @LanguageCode),
              Zivilstand     = dbo.fnLOVMLText('Zivilstand', PRS.ZivilstandCode, @LanguageCode)
            FROM dbo.vwPerson        PRS
            WHERE  PRS.BaPersonID = {0};";

        #endregion

        #region Private Fields

        private int _baPersonIdA;
        private int _baPersonIdB;
        private int? _baPersonIdToDelete;
        private bool _filledMigrationProblems;
        private string _nameVornamePersonA;
        private string _nameVornamePersonB;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlDoublePerson"/> class.
        /// </summary>
        public CtlDoublePerson()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlDoublePerson"/> class.
        /// </summary>
        /// <param name="baPersonIda">The id of the first person</param>
        /// <param name="baPersonIdb">The id of the second person</param>
        public CtlDoublePerson(int baPersonIda, int baPersonIdb)
            : this()
        {
            _baPersonIdA = baPersonIda;
            _baPersonIdB = baPersonIdb;
        }

        #endregion

        #region EventHandlers

        private void btnJumpToPathA_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var path = qryProblems["JumpToPathA"];

            if (!DBUtil.IsEmpty(path))
            {
                JumpToPath((string)path);
            }
        }

        private void btnJumpToPathB_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var path = qryProblems["JumpToPathB"];

            if (!DBUtil.IsEmpty(path))
            {
                JumpToPath((string)path);
            }
        }

        private void btnMigrateA_Click(object sender, EventArgs e)
        {
            Migrate(_baPersonIdB, _baPersonIdA, PERSON_B, PERSON_A, _nameVornamePersonB, _nameVornamePersonA);
            OnRefreshData();
        }

        private void btnMigrateB_Click(object sender, EventArgs e)
        {
            Migrate(_baPersonIdA, _baPersonIdB, PERSON_A, PERSON_B, _nameVornamePersonA, _nameVornamePersonB);
            OnRefreshData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OnRefreshData();
        }

        private void CtlDoublePerson_Load(object sender, EventArgs e)
        {
            // used for the buttons to work and is sometimes reset by the designer
            grvProblems.OptionsBehavior.Editable = true;
            grvProblems.OptionsView.ColumnAutoWidth = true;

            tabDoublePerson.SelectTab(tpgPersons);

            lblStatus.Text = string.Empty;
            OnRefreshData();
        }

        private void editPersonID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();

            try
            {
                e.Cancel = !dlg.PersonSuchen(((KissButtonEdit)sender).Text, e.ButtonClicked);

                if (e.Cancel)
                {
                    return;
                }

                if (sender == edtPersonA)
                {
                    _baPersonIdA = Utils.ConvertToInt(dlg["BaPersonID"]);
                }
                else if (sender == edtPersonB)
                {
                    _baPersonIdB = Utils.ConvertToInt(dlg["BaPersonID"]);
                }
            }
            finally
            {
                OnRefreshData();
            }
        }

        private void qryPersonA_AfterFill(object sender, EventArgs e)
        {
            ClearMigrationProblems();
        }

        private void qryPersonB_AfterFill(object sender, EventArgs e)
        {
            ClearMigrationProblems();
        }

        private void tabDoublePerson_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // fill migration problems for the first time if not done yet
            if (!_filledMigrationProblems)
            {
                CheckAndRefreshMigrationProblems();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnRefreshData()
        {
            base.OnRefreshData();

            qryPersonA.Fill(SQL, _baPersonIdA, Session.User.LanguageCode);
            qryPersonB.Fill(SQL, _baPersonIdB, Session.User.LanguageCode);

            if (qryPersonA.Count == 0)
            {
                qryPersonA.Insert(null);
                _nameVornamePersonA = null;
            }
            else
            {
                _nameVornamePersonA = Utils.ConvertToString(qryPersonA["NameVorname"]);
            }

            if (qryPersonB.Count == 0)
            {
                qryPersonB.Insert(null);
                _nameVornamePersonB = null;
            }
            else
            {
                _nameVornamePersonB = Utils.ConvertToString(qryPersonB["NameVorname"]);
            }

            var enableButtons = !DBUtil.IsEmpty(qryPersonA["BaPersonID"]) && !DBUtil.IsEmpty(qryPersonB["BaPersonID"]);
            btnMigrateA.Enabled = enableButtons;
            btnMigrateB.Enabled = enableButtons;

            // Wenn auf Problem-Tab und keine Probleme existieren soll auf Personen-Tab gewechselt werden
            if (tabDoublePerson.SelectedTab == tpgProblems && !CheckAndRefreshMigrationProblems())
            {
                KissMsg.ShowInfo(Name, "NoMoreFusionProblems", "Es wurden keine Probleme für die Zusammenführung der beiden Personen gefunden.");
                tabDoublePerson.SelectTab(tpgPersons);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks if there are any problems.
        /// </summary>
        /// <returns>True if there is a problem that should prevent the migration.</returns>
        private bool CheckAndRefreshMigrationProblems()
        {
            // fill query and count results
            var result = qryProblems.Fill(_baPersonIdA, _baPersonIdB, Session.User.LanguageCode, _baPersonIdToDelete);
            var count = qryProblems.Count;

            _filledMigrationProblems = true;

            if (!result || count > 0)
            {
                SetStatus(KissMsg.GetMLMessage(typeof(CtlDoublePerson).Name, "ProblemGefunden", "{0} Probleme gefunden...", KissMsgCode.Text, count));
                return true;
            }

            return false;
        }

        private void ClearMigrationProblems()
        {
            qryProblems.Fill(-1, -1, Session.User.LanguageCode, null);
            SetStatus();

            _filledMigrationProblems = false;
        }

        private void CreateXLogEntry(
            int baPersonId,
            int baPersonIdDelete,
            string person,
            string personDelete,
            string nameVornamePerson,
            string nameVornamePersonDelete,
            LogLevel level,
            string message,
            string extraComment,
            bool nonPurgeable)
        {
            var comment = string.Format("BaPerson_Keep=[{0} (NameVorname={1}; ID={2})], BaPerson_Delete=[{3} (NameVorname={4}; ID={5})]",
                person,
                nameVornamePerson,
                baPersonId,
                personDelete,
                nameVornamePersonDelete,
                baPersonIdDelete);

            if (!string.IsNullOrEmpty(extraComment))
            {
                comment = string.Format("{0}; ExtraComment=[{1}]", comment, extraComment);
            }

            XLog.Create(GetType().FullName, 0, level, message, comment, "BaPerson", baPersonId, nonPurgeable, Session.User.UserID);
        }

        private void JumpToPath(string path)
        {
            var dict = FormController.ConvertToDictionary(path);

            if (dict.Contains("Action"))
            {
                FormController.OpenForm((string)dict["ClassName"], dict);
            }
            else
            {
                FormController.OpenForm((string)dict["ClassName"], "Action", "JumpToPath", dict);
            }
        }

        private void Migrate(int baPersonId, int baPersonIdDelete, string person, string personDelete, string nameVornamePerson, string nameVornamePersonDelete)
        {
            _baPersonIdToDelete = baPersonIdDelete;
            if (baPersonId == 0 || baPersonIdDelete == 0)
            {
                KissMsg.ShowInfo(typeof(CtlDoublePerson).Name, "PersonABLeer", "Person A und Person B müssen ausgefüllt sein!");
                return;
            }

            if (baPersonId == baPersonIdDelete)
            {
                KissMsg.ShowInfo(typeof(CtlDoublePerson).Name, "PersonABIdentisch", "Person A und Person B sind identisch (gleiche Nr)!");
                return;
            }

            // check for possible problems
            SetStatus(KissMsg.GetMLMessage(typeof(CtlDoublePerson).Name, "Problemeidentifizieren", "Probleme identifizieren...", KissMsgCode.Text));

            if (CheckAndRefreshMigrationProblems())
            {
                KissMsg.ShowInfo(
                    typeof(CtlDoublePerson).Name,
                    "ProblemExistiert",
                    "Achtung: Die aufgelisteten Punkte müssen zuerst bereinigt werden,\r\nbevor die Migration durchgeführt werden kann.");

                tabDoublePerson.SelectTab(tpgProblems);
                return;
            }

            if (!KissMsg.ShowQuestion(
                    typeof(CtlDoublePerson).Name,
                    "StammdatenWerdenGeloescht",
                    "Achtung: Die Stammdaten der {0} werden gelöscht und alle Falldaten der {1} zugeordnet.\r\n\r\nSoll diese Aktion durchgeführt werden?",
                    true,
                    personDelete,
                    person))
            {
                return;
            }

            Session.BeginTransaction();

            try
            {
                // log merging process
                SetStatus("Logging");

                CreateXLogEntry(baPersonId,
                                baPersonIdDelete,
                                person,
                                personDelete,
                                nameVornamePerson,
                                nameVornamePersonDelete,
                                LogLevel.INFO,
                                "Merging BaPerson entries",
                                null,
                                true);

                DBUtil.NewHistoryVersion();

                SetStatus(KissMsg.GetMLMessage(typeof(CtlDoublePerson).Name, "Beziehungenbereinigen", "Beziehungen bereinigen (max. 60s)...", KissMsgCode.Text));

                //Wenn neue Person (also nicht die, die mann löschen will) bereits Gläubiger ist, dann kann man den Eintrag der zu löschenden Person in IkGlaeubiger löschen.
                DBUtil.ExecSQLThrowingException(@"IF EXISTS
                                                    (
                                                    SELECT 1
                                                    FROM dbo.IkGlaeubiger
                                                    WHERE BaPersonID ={0})
                                                  BEGIN
                                                      DELETE FROM dbo.IkGlaeubiger
                                                      WHERE BaPersonID = {1}
                                                  END;", baPersonId, baPersonIdDelete);

                DBUtil.ExecSQLThrowingException(60, @"
                    DELETE DRE
                    FROM dbo.BaPerson_Relation DRE
                    WHERE (DRE.BaPersonID_1 = {1}
                           AND EXISTS (SELECT TOP 1 1
                                       FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                                       WHERE BaPersonID_1 = {0} AND BaPersonID_2 = DRE.BaPersonID_2))
                       OR (DRE.BaPersonID_2 = {1}
                           AND EXISTS (SELECT TOP 1 1
                                       FROM dbo.BaPerson_Relation WITH (READUNCOMMITTED)
                                       WHERE BaPersonID_2 = {0} AND BaPersonID_1 = DRE.BaPersonID_1));", baPersonId, baPersonIdDelete);

                SetStatus(KissMsg.GetMLMessage(typeof(CtlDoublePerson).Name, "BFSWerteloeschen", "BFS Werte löschen (max. 60s)...", KissMsgCode.Text));

                DBUtil.ExecSQLThrowingException(60, "DELETE dbo.BFSWert WHERE BFSDossierPersonID = {0};", baPersonIdDelete);

                //nicht mehr gültige Mietverträge für baPersonIdDelete löschen
                DBUtil.ExecSQLThrowingException(60, @"
                    DELETE BMV
                    FROM dbo.BaMietvertrag BMV
                    WHERE BMV.BaPersonID in ({0}, {1})
                      AND BMV.DatumBis IS NOT NULL", baPersonId, baPersonIdDelete);

                // alle abhängigen Daten auf neue Person umhängen
                SetStatus(KissMsg.GetMLMessage(typeof(CtlDoublePerson).Name, "AbhaengigeDaten", "Abhängige Daten (Falldaten) umhängen (max. 180s)...", KissMsgCode.Text));
                DBUtil.ExecSQLThrowingException(180, "EXECUTE dbo.spXRowMerge {0}, {1}, {2};", DBO.BaPerson.DBOName, baPersonId, baPersonIdDelete);

                Session.Commit();
            }
            catch (Exception ex)
            {
                SetStatus("Rollback");
                Session.Rollback();

                // log error
                SetStatus("Logging");
                CreateXLogEntry(baPersonId,
                                baPersonIdDelete,
                                person,
                                personDelete,
                                nameVornamePerson,
                                nameVornamePersonDelete,
                                LogLevel.WARN,
                                "Merging BaPerson entries failed",
                                ex.Message,
                                false);

                SetStatus("Error-Info");
                KissMsg.ShowError(Name, "FehlerDatenbereinigung", "Beim Versuch, die Datenbereinigung durchzuführen, ist ein Fehler aufgetreten.", ex);
            }
            finally
            {
                SetStatus();
            }
        }

        private void SetStatus(string message = "", params object[] parameters)
        {
            lblStatus.Text = string.Format(message, parameters);
            ApplicationFacade.DoEvents();
        }

        #endregion

        #endregion
    }
}