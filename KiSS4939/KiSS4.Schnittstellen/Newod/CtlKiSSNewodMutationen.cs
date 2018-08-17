using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Schnittstellen.Newod.DTO;
using KiSS4.Schnittstellen.Newod.Service;

namespace KiSS4.Schnittstellen.Newod
{
    internal class CtlKiSSNewodMutationen : Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private bool _pendenzAktiv;
        private NewodService _svcNewod;
        private Gui.KissLabel edtCurrentTask;
        private Gui.KissLabel edtCurrentTaskText;
        private Gui.KissButton edtStart;

        #endregion

        #endregion

        #region Constructors

        public CtlKiSSNewodMutationen()
        {
            InitializeComponent();
            edtCurrentTaskText.Text = "";

            _pendenzAktiv = DBUtil.GetConfigBool(@"System\Pendenzen\Newod\NewodDatenMeldung\Aktiv", false);
        }

        #endregion

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.edtStart = new KiSS4.Gui.KissButton();
            this.edtCurrentTask = new KiSS4.Gui.KissLabel();
            this.edtCurrentTaskText = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentTaskText)).BeginInit();
            this.SuspendLayout();
            //
            // edtStart
            //
            this.edtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edtStart.Location = new System.Drawing.Point(3, 3);
            this.edtStart.Name = "edtStart";
            this.edtStart.Size = new System.Drawing.Size(701, 24);
            this.edtStart.TabIndex = 0;
            this.edtStart.Text = "Mutationslauf starten";
            this.edtStart.UseVisualStyleBackColor = false;
            this.edtStart.Click += new System.EventHandler(this.edtStart_Click);
            //
            // edtCurrentTask
            //
            this.edtCurrentTask.Location = new System.Drawing.Point(3, 30);
            this.edtCurrentTask.Name = "edtCurrentTask";
            this.edtCurrentTask.Size = new System.Drawing.Size(103, 24);
            this.edtCurrentTask.TabIndex = 5;
            this.edtCurrentTask.Text = "Task:";
            //
            // edtCurrentTaskText
            //
            this.edtCurrentTaskText.Location = new System.Drawing.Point(123, 30);
            this.edtCurrentTaskText.Name = "edtCurrentTaskText";
            this.edtCurrentTaskText.Size = new System.Drawing.Size(327, 24);
            this.edtCurrentTaskText.TabIndex = 5;
            this.edtCurrentTaskText.Text = "Start";
            //
            // CtlKiSSNewodMutationen
            //
            this.Controls.Add(this.edtCurrentTaskText);
            this.Controls.Add(this.edtCurrentTask);
            this.Controls.Add(this.edtStart);
            this.Name = "CtlKiSSNewodMutationen";
            this.Size = new System.Drawing.Size(707, 436);
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtCurrentTaskText)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region EventHandlers

        private void edtStart_Click(object sender, EventArgs e)
        {
            edtCurrentTaskText.Text = "";
            AddStatusMessage("Starte Mutationslauf");

            Cursor.Current = Cursors.WaitCursor;

            //initialize service
            _svcNewod = new NewodService(DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\URL", null), DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\Username", null), DBUtil.GetConfigString(@"System\Schnittstelle\NEWOD\Server\Passwort", null), GetProxySetting(), 0);
            // get mutationen
            try
            {
                string datumLetzterMutationslauf = DBUtil.GetConfigValue(@"System\Schnittstelle\NEWOD\Services\GetMutation\ValidFrom", "", DateTime.Now, false).ToString();
                string datumNeuerMutationslauf;

                var mutMeldungen = _svcNewod.GetMutationenAsRequest(datumLetzterMutationslauf, out datumNeuerMutationslauf);

                Session.BeginTransaction();
                SaveMutationToDB(mutMeldungen);

                DBUtil.OpenSQL(@"
                    UPDATE dbo.XConfig
                      SET ValueVarchar = {0}
                    WHERE KeyPath = 'System\Schnittstelle\NEWOD\Services\GetMutation\ValidFrom'",
                    datumNeuerMutationslauf);

                Session.Commit();
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                XLog.Create(GetType().FullName, 1, LogLevel.ERROR, "Fehler", String.Format("Fehler Beim Empfangen neuer Mutationsmeldungen: {0}", ex.Message), "BaPerson", 0);
                AddStatusMessage("Fehler Beim Empfangen neuer Mutationsmeldungen ");
            }

            ProcessMutationen();

            AddStatusMessage("Ende Mutationslauf");
            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Methods

        #region Private Methods

        private void AddStatusMessage(string message)
        {
            edtCurrentTaskText.Text = message;
            ApplicationFacade.DoEvents();
        }

        private string GetProxySetting()
        {
            var asr = new AppSettingsReader();
            string proxy;
            try
            {
                proxy = (string)asr.GetValue("NewodProxy", typeof(string));
            }
            catch
            {
                proxy = "";
            }

            return proxy;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private List<GetPersonRequest> GetSavedMutationen()
        {
            var qry = DBUtil.OpenSQL(@"SELECT
                                         NewodNummer,
                                         Mutationsart,
                                         DatumVon
                                       FROM dbo.SstNewodMutation
                                       WHERE Processed = 0
                                         AND (DatumVon < GETDATE() OR Mutationsart = 'CABM')
                                       ORDER BY DatumVon ASC;");

            var requests = new List<GetPersonRequest>();
            if (qry.Count == 0)
            {
                AddStatusMessage("- Keine Mutationsmeldungen zum Verarbeiten.");
                return requests;
            }

            AddStatusMessage(String.Format("- Verarbeite {0} Mutationsmeldungen.", qry.Count));
            requests.AddRange(from DataRow row in qry.DataTable.Rows
                              select new GetPersonRequest
                              {
                                  ID = row["NewodNummer"].ToString(),
                                  Mutationsart = row["Mutationsart"].ToString(),
                                  ValidFrom = Utils.ConvertToDateTime(row["DatumVon"]),
                                  ValidFromSpecified = true
                              });
            return requests;
        }

        private void ProcessMutationen()
        {
            var filter = new HashSet<string>
            {
                "Strasse",
                "Zusatz",
                "Postfach",
                "HausNr",
                "Plz",
                "Ort",
                "Kanton",
                "LandCode"
            };

            var svcBaPerson = new BaPersonService();
            var criteria = new PersonSearchCriteria();
            var baperson = new List<BaPerson>();
            var mutMeldungen = GetSavedMutationen();
            var svcNewodPendenz = new NewodPendenzService();
            var differences = new List<PropertyInfo>();

            int i = 1;

            foreach (GetPersonRequest mutMeldung in mutMeldungen)
            {
                baperson.Clear();
                differences.Clear();

                string logComment;
                LogLevel loglevel;
                string logMessage;

                string newodNummer = mutMeldung.ID;
                int baPersonID = -1;

                try
                {
                    _svcNewod.ClearCache();

                    var newodperson = _svcNewod.GetPerson(mutMeldung, false);
                    criteria.NewodNummer = newodperson.ID;

                    int totalMatches;
                    baperson = svcBaPerson.SearchPerson(criteria, out totalMatches);
                    if (baperson.Count == 0)
                    {
                        mutMeldung.ID = "-1";
                        baPersonID = -1;
                    }
                    else
                    {
                        loglevel = LogLevel.INFO;
                        logMessage = String.Format("Basisdaten ({0})", mutMeldung.Mutationsart);
                        logComment = "Keine Änderung vorgenommen";

                        mutMeldung.ID = baperson[0].ID;
                        baPersonID = Convert.ToInt32(baperson[0].ID);
                        differences = svcBaPerson.Diff(baperson[0], newodperson, filter, true);

                        if (differences.Count > 0)
                        {
                            svcBaPerson.UpdateBasisDaten(mutMeldung, newodperson);

                            logComment = "geänderte Daten: ";
                            foreach (var info in differences)
                            {
                                logComment += info.Name + " Newod: " + svcBaPerson.GetStringRepresentation(info, info.GetValue(newodperson, null))
                                                        + " KiSS: " + svcBaPerson.GetStringRepresentation(info, info.GetValue(baperson[0], null)) + " /";
                            }

                            logComment = logComment.Remove(logComment.Length - 1, 1);

                            if (_pendenzAktiv)
                            {
                                // Pendenz schreiben
                                svcNewodPendenz.InsertPendenz(Convert.ToInt32(mutMeldung.ID), differences);
                            }
                        }

                        // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                        XLog.Create(GetType().FullName, 1, loglevel, logMessage, logComment, "BaPerson", Convert.ToInt32(mutMeldung.ID));

                        if (mutMeldung.Mutationsart == "CABM" || mutMeldung.Mutationsart == "CA6M") // CABM = Adressmutation, CA6M = Zuzug
                        {
                            differences.Clear();

                            loglevel = LogLevel.INFO;
                            logMessage = String.Format("Adresse ({0})", mutMeldung.Mutationsart);
                            logComment = "Keine Änderung vorgenommen";
                            mutMeldung.ID = baperson[0].ID;

                            try
                            {
                                differences = svcBaPerson.Diff(baperson[0], newodperson, filter, false);

                                if (differences.Count > 0)
                                {
                                    svcBaPerson.UpdateAdressDaten(mutMeldung, baperson[0], newodperson);

                                    logComment = "geänderte Daten: ";
                                    foreach (PropertyInfo info in differences)
                                    {
                                        logComment += info.Name + " Newod: " + svcBaPerson.GetStringRepresentation(info, info.GetValue(newodperson, null))
                                                                + " KiSS: " + svcBaPerson.GetStringRepresentation(info, info.GetValue(baperson[0], null)) + " /";
                                    }

                                    logComment = logComment.Remove(logComment.Length - 1, 1);

                                    if (_pendenzAktiv)
                                    {
                                        // Pendenz schreiben
                                        svcNewodPendenz.InsertPendenz(Convert.ToInt32(mutMeldung.ID), differences);
                                    }
                                }
                            }
                            catch (ApplicationException ex)
                            {
                                loglevel = LogLevel.ERROR;
                                logMessage = "Fehler Adresse";
                                logComment = ex.Message;
                            }

                            // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                            XLog.Create(GetType().FullName, 1, loglevel, logMessage, logComment, "BaPerson", Convert.ToInt32(mutMeldung.ID));
                        }
                    }

                    mutMeldung.ID = criteria.NewodNummer;
                    // nur Mutationsmeldung auf Processed = 1 setzen wenn es erfolgreich abarbeitet wurde
                    Update(mutMeldung);
                }
                catch (InvalidOperationException ex)
                {
                    loglevel = LogLevel.ERROR;
                    logMessage = "Fehler";
                    logComment = String.Format("NEWOD ID: {0}, Die von NEWOD empfangenen Daten sind nicht valid: {1}", newodNummer, ex.Message);

                    // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                    XLog.Create(GetType().FullName, 1, loglevel, logMessage, logComment + Environment.NewLine + "Stacktrace: " + ex.StackTrace, "BaPerson", baPersonID);
                }
                catch (Exception ex)
                {
                    loglevel = LogLevel.ERROR;
                    logMessage = "Fehler";
                    logComment = String.Format("NEWOD ID: {0}, {1}. " + ex, newodNummer, ex.Message);

                    // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                    XLog.Create(GetType().FullName, 1, loglevel, logMessage, logComment + Environment.NewLine + "Stacktrace: " + ex.StackTrace, "BaPerson", baPersonID);
                }

                AddStatusMessage(String.Format(@"{0} von {1} Mutationsmeldungen verarbeitet", i, mutMeldungen.Count));
                i++;
            }
        }

        private void SaveMutationToDB(GetPersonRequest[] mutMeldungen)
        {
            string sql = "";

            if (mutMeldungen == null || mutMeldungen.Length == 0)
            {
                AddStatusMessage("Keine neuen Mutationsmeldungen empfangen");
                return;
            }

            AddStatusMessage(String.Format("Speichere {0} neue Mutationsmeldungen", mutMeldungen.Length));
            foreach (GetPersonRequest mutationmeldung in mutMeldungen)
            {
                sql = @"INSERT INTO dbo.sstNewodMutation (
                            NewodNummer,
                            Mutationsart,
                            DatumVon
                        )
                        VALUES ({0},{1},{2})";

                DBUtil.ExecSQLThrowingException(sql, Convert.ToInt32(mutationmeldung.ID), mutationmeldung.Mutationsart, mutationmeldung.ValidFrom);
            }
        }

        private void Update(GetPersonRequest req)
        {
            if (req == null)
            {
                return;
            }

            string sql = @"UPDATE dbo.sstNewodMutation
                            SET Processed = 1
                            WHERE Newodnummer = {0}  AND
                                  (({1} IS NULL AND Mutationsart IS NULL) OR Mutationsart = {1} ) AND
                                  DatumVon = {2}";

            DBUtil.ExecSQLThrowingException(sql, Convert.ToInt32(req.ID), req.Mutationsart, req.ValidFrom);
        }

        #endregion

        #endregion
    }
}