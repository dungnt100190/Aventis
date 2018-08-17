using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.DB;
using KiSS4.Messages;

namespace KiSS4.Basis.ZH.Strassenverzeichnis
{
    public partial class FrmBaStrassenverzeichnis : KiSS4.Gui.KissChildForm
    {
        private BaStrasseDTO[] strassenEingelesen;
        private BaHausDTO[] haeuserEingelesen;
        private IDictionary<BaStrasseDTO, BaStrasseDTO> strassenVeraendert;
        private IList<BaStrasseDTO> strassenNeu;
        private IDictionary<BaHausDTO, BaHausDTO> haeuserVeraendert;
        private IList<BaHausDTO> haeuserNeu;

        public FrmBaStrassenverzeichnis()
        {
            InitializeComponent();
            tabMain.SelectedTabIndex = 0;

            SqlQuery qryLookupQT = DBUtil.OpenSQL("SELECT Code = OrgUnitID, Text = ItemName FROM XOrgUnit WHERE ItemName LIKE 'QT %'");
            colQTKiSS.ColumnEdit = grdImport.GetLOVLookUpEdit(qryLookupQT);
            colHaus_QT_Kiss.ColumnEdit = grdBaHausEingelesen.GetLOVLookUpEdit(qryLookupQT);
            colDiffHaus_QT_bisher.ColumnEdit = grdDifferenzenHaus.GetLOVLookUpEdit(qryLookupQT);
            colDiffHaus_QT_neu.ColumnEdit = grdDifferenzenHaus.GetLOVLookUpEdit(qryLookupQT);
            colHausNeu_QT.ColumnEdit = grdHausNeu.GetLOVLookUpEdit(qryLookupQT);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DlgProgressLog.Show("Strassenverzeichnis einlesen", false, 700, 500, new ProgressEventHandler(ProgressStart_Import), new ProgressEventHandler(ProgressEnd), Session.MainForm);
        }

        private void ProgressStart_Import()
        {
            strassenEingelesen = null;
            haeuserEingelesen = null;
            Stream fileStream = null;
            try
            {
                ApplicationFacade.DoEvents();

                Cursor = Cursors.WaitCursor;
                DlgProgressLog.AddLine("Datei auswählen...");

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "CSV (Comma delimited)|*.csv";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ApplicationFacade.DoEvents();

                    try
                    {
                        fileStream = dlg.OpenFile();
                    }
                    catch (IOException ex)
                    {
                        string error = "Zugriff auf Datei nicht möglich. Ist sie noch in einem anderen Programm geöffnet?";
                        KissMsg.ShowError(error, ex);
                        DlgProgressLog.AddError(error);
                        return;
                    }
                    DlgProgressLog.AddLine(string.Format("Datei geöffnet ({0})", dlg.FileName));
                    DlgProgressLog.AddLine("Datei einlesen...");
                    if (ImportCsv(fileStream))
                    {
                        DlgProgressLog.AddLine("Datei erfolgreich eingelesen");
                        DlgProgressLog.AddLine("Eingelesene Strassen vergleichen mit bestehenden...");
                        DetermineDifferences_Strasse(strassenEingelesen);
                        DlgProgressLog.AddLine("Eingelesene Adressen vergleichen mit bestehenden...");
                        DetermineDifferences_Haus(haeuserEingelesen);
                        if (strassenEingelesen.Length > 0)
                        {
                            FocusStrasse(strassenEingelesen[0].BaStrasseID, strassenEingelesen[0].StrassenName);
                        }
                        DlgProgressLog.AddLine("Einlesen und Vergleichen beendet, bitte Differenzen im Reiter 'Update' überprüfen und schliesslich anwenden.");
                    }
                }
                else
                {
                    DlgProgressLog.AddLine("Abgebrochen");
                }
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
                Cursor = Cursors.Default;
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        private bool ImportCsv(Stream fileStream)
        {
            BaStrasseHausDTO[] lines = BaStrassenverzeichnisParser.ReadStrassenverzeichnis(fileStream);
            BaStrasseHausDTO[] correctLines = lines.Where(line => line.ParseError == null).ToArray();
            BaStrasseHausDTO[] parseErrors = lines.Where(line => line.ParseError != null).ToArray();

            if (parseErrors != null && parseErrors.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Fehler beim Einlesen der Datei, folgende Fehler sind aufgetreten (zeilenweise)");
                sb.AppendLine();
                foreach (BaStrasseHausDTO adresse in parseErrors)
                {
                    sb.AppendLine(adresse.ParseError);
                }
                KissMsg.ShowError(sb.ToString());
                return false;
            }

            DetermineOrgUnitID(ref correctLines);
            grdImport.DataSource = correctLines;

            // Strassen extrahieren
            var strassen = from BaStrasseHausDTO line in correctLines
                           group line by new { line.BaStrasseID, line.StrassenName } into strasse
                           select new BaStrasseDTO
                           {
                               BaStrasseID = strasse.Key.BaStrasseID,
                               StrassenName = strasse.Key.StrassenName
                           };

            strassenEingelesen = strassen.ToArray();
            grdBaStrasseEingelesen.DataSource = strassenEingelesen;

            // Häuser extrahieren
            var haeuser = from BaStrasseHausDTO line in correctLines
                          select new BaHausDTO
                          {
                              //BaStrasseHausID = line.BaStrasseHausID,
                              BaStrasseID = line.BaStrasseID,
                              StrassenName = line.StrassenName,
                              Hausnummer = line.Hausnummer,
                              Suffix = string.IsNullOrEmpty(line.Suffix) ? line.Suffix : line.Suffix.ToLower(),
                              PLZ = line.PLZ,
                              Kreis = line.Kreis,
                              Quartier = line.Quartier,
                              QuartierTeam = line.QuartierTeam,
                              StatistischeZone = line.StatistischeZone,
                              Zone = line.Zone,
                              OrgUnitID_QT = line.OrgUnitID_QT
                          };

            //// Test ob doppelte Einträge vorhanden sind
            //var a = from h in haeuser
            //        group h by new {h.BaStrasseID, h.StrassenName, h.Hausnummer, h.Suffix} into grp
            //        where grp.Count() > 1
            //        select new {grp,grp. Min(g=> g.BaStrasseHausID)};

            //var b = a.ToList();

            haeuserEingelesen = haeuser.Distinct(new BaHausDTOComparer()).ToArray();

            var a = from h in haeuserEingelesen
                    group h by new { h.BaStrasseID, h.StrassenName, h.Hausnummer, h.Suffix } into grp
                    where grp.Count() > 1
                    select grp;

            var b = a.ToList();

            return true;
        }

        private void DetermineOrgUnitID(ref BaStrasseHausDTO[] haeuser)
        {
            IDictionary<string, int> qtName2orgUnitID = LoadQTHashtable();

            // Manuelle mappings
            qtName2orgUnitID.Add("Industriequartier", 90);
            qtName2orgUnitID.Add("Ober-/Unterstrass", 109);
            qtName2orgUnitID.Add("Langstrasse/Werd", 91);
            qtName2orgUnitID.Add("Höngg/Wipkingen", 108);

            IDictionary<string, int> nichtzuordenbar = new Dictionary<string, int>();
            int temp;
            foreach (BaStrasseHausDTO haus in haeuser)
            {
                if (qtName2orgUnitID.TryGetValue(haus.QuartierTeam, out temp))
                {
                    haus.OrgUnitID_QT = temp;
                }
                else
                {
                    if (nichtzuordenbar.ContainsKey(haus.QuartierTeam))
                    {
                        nichtzuordenbar[haus.QuartierTeam]++;
                    }
                    else
                    {
                        nichtzuordenbar.Add(haus.QuartierTeam, 1);
                    }
                }
            }

            if (nichtzuordenbar.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Fehler beim Einlesen, folgende Quartierteams konnten nicht KiSS-Quartierteams zugeordnet werden:");
                sb.AppendLine();
                foreach (var qtUngueltig in nichtzuordenbar)
                {
                    sb.AppendLine(string.Format("{0} ({1} Adressen)", qtUngueltig.Key, qtUngueltig.Value));
                }
                KissMsg.ShowError(sb.ToString());
            }
        }

        private void DetermineDifferences_Strasse(BaStrasseDTO[] strassen_Soll)
        {
            IDictionary<int, string> strassen_Ist = GetBaStrasse();
            var modified = from strasse_Soll in strassen_Soll
                           join strasse_Ist in strassen_Ist on strasse_Soll.BaStrasseID equals (int)strasse_Ist.Key
                           where strasse_Soll.StrassenName != (string)strasse_Ist.Value
                           select new { Neu = strasse_Soll, Alt = new BaStrasseDTO { BaStrasseID = strasse_Ist.Key, StrassenName = strasse_Ist.Value } };
            strassenVeraendert = modified.ToDictionary(p => p.Alt, p => p.Neu);

            var added = from strasse_Soll in strassen_Soll
                        where !strassen_Ist.ContainsKey(strasse_Soll.BaStrasseID)
                        select strasse_Soll;
            strassenNeu = added.ToList();
            grdStrassenNeu.DataSource = strassenNeu;

            SqlQuery qryStrassenVeraendert = DBUtil.OpenSQL("SELECT TOP 0 BaStrasseID = CAST(0 as INT), NameBisher = CAST('' as varchar), NameNeu = CAST('' as varchar)");
            foreach (KeyValuePair<BaStrasseDTO, BaStrasseDTO> diff in strassenVeraendert)
            {
                qryStrassenVeraendert.DataTable.Rows.Add(diff.Key.BaStrasseID, diff.Key.StrassenName, diff.Value.StrassenName);
            }
            grdDifferenzenStrasse.DataSource = qryStrassenVeraendert.DataTable;
        }

        private void DetermineDifferences_Haus(BaHausDTO[] haeuser_Soll)
        {
            IList<BaHausDTO> haueser_Ist = GetBaHaus();

            var added = from haus_Soll in haeuser_Soll
                        where haueser_Ist.FirstOrDefault(haus_Ist => haus_Ist.BaStrasseID == haus_Soll.BaStrasseID &&
                                                         haus_Ist.Hausnummer == haus_Soll.Hausnummer &&
                                                         (string.IsNullOrEmpty(haus_Soll.Suffix) &&
                                                          string.IsNullOrEmpty(haus_Ist.Suffix) ||
                                                          haus_Soll.Suffix == haus_Ist.Suffix)) == null
                        select haus_Soll;
            haeuserNeu = added.ToList();
            grdHausNeu.DataSource = haeuserNeu;

            var modified = from haus_Soll in haeuser_Soll
                           join haus_Ist in haueser_Ist on haus_Soll.BaStrasseID equals haus_Ist.BaStrasseID
                           where haus_Soll.Hausnummer == haus_Ist.Hausnummer &&
                                 (string.IsNullOrEmpty(haus_Soll.Suffix) && string.IsNullOrEmpty(haus_Ist.Suffix) || haus_Soll.Suffix == haus_Ist.Suffix) &&
                                 (haus_Soll.OrgUnitID_QT != haus_Ist.OrgUnitID_QT ||
                                  haus_Soll.PLZ != haus_Ist.PLZ ||
                                  haus_Soll.Kreis != haus_Ist.Kreis ||
                                  haus_Soll.Quartier != haus_Ist.Quartier ||
                                  haus_Soll.Zone != haus_Ist.Zone ||
                                  haus_Soll.StatistischeZone != haus_Ist.StatistischeZone
                                  )
                           select new { Alt = haus_Ist, Neu = haus_Soll };
            haeuserVeraendert = modified.ToDictionary(p => p.Alt, p => p.Neu);

            SqlQuery qryHaeuserVeraendert = DBUtil.OpenSQL(@"SELECT TOP 0 StrassenName = CAST('' as varchar),
                                                                          BaStrasseID = CAST(0 as INT),
                                                                          Hausnummer = CAST(0 as INT),
                                                                          Suffix = CAST('' as varchar),
                                                                          OrgUnitID_bisher = CAST(0 as INT),
                                                                          OrgUnitID_neu = CAST(0 as INT),
                                                                          PLZ_alt = CAST(0 as INT),
                                                                          PLZ_neu = CAST(0 as INT),
                                                                          Kreis_alt = CAST(0 as INT),
                                                                          Kreis_neu = CAST(0 as INT),
                                                                          Quartier_alt = CAST(0 as INT),
                                                                          Quartier_neu = CAST(0 as INT),
                                                                          Zone_alt = CAST(0 as INT),
                                                                          Zone_neu = CAST(0 as INT),
                                                                          StatistischeZone_alt = CAST(0 as INT),
                                                                          StatistischeZone_neu = CAST(0 as INT)");
            foreach (KeyValuePair<BaHausDTO, BaHausDTO> diff in haeuserVeraendert)
            {
                qryHaeuserVeraendert.DataTable.Rows.Add(diff.Value.StrassenName, diff.Key.BaStrasseID, diff.Key.Hausnummer, diff.Key.Suffix,
                                                        diff.Key.OrgUnitID_QT, diff.Value.OrgUnitID_QT,
                                                        diff.Key.PLZ, diff.Value.PLZ,
                                                        diff.Key.Kreis, diff.Value.Kreis,
                                                        diff.Key.Quartier, diff.Value.Quartier,
                                                        diff.Key.Zone, diff.Value.Zone,
                                                        diff.Key.StatistischeZone, diff.Value.StatistischeZone);
            }
            grdDifferenzenHaus.DataSource = qryHaeuserVeraendert.DataTable;
        }

        private IDictionary<int, string> GetBaStrasse()
        {
            SqlQuery qryBaStrasse = DBUtil.OpenSQL("SELECT BaStrasseID, StrasseLang FROM BaStrasse");
            IDictionary<int, string> strassen = new Dictionary<int, string>();
            foreach (DataRow strasse in qryBaStrasse.DataTable.Rows)
            {
                strassen.Add((int)strasse["BaStrasseID"], (string)strasse["StrasseLang"]);
            }
            return strassen;
        }

        private IList<BaHausDTO> GetBaHaus()
        {
            SqlQuery qryBaHaus = DBUtil.OpenSQL("SELECT BaHausID, BaStrasseID, Hausnummer, Suffix, PLZ, OrgUnitID, Kreis, Quartier, Zone, StatistischeZone FROM BaHaus");
            IList<BaHausDTO> haeuser = new List<BaHausDTO>();
            foreach (DataRow haus in qryBaHaus.DataTable.Rows)
            {
                int baStrasseID = (int)haus["BaStrasseID"];
                haeuser.Add(new BaHausDTO
                                             {
                                                 BaHausID = (int)haus["BaHausID"],
                                                 BaStrasseID = baStrasseID,
                                                 Hausnummer = (short)haus["Hausnummer"],
                                                 Suffix = haus["Suffix"] as string,
                                                 PLZ = haus["PLZ"] as short?,
                                                 OrgUnitID_QT = (int)haus["OrgUnitID"],
                                                 Kreis = haus["Kreis"] as int?,
                                                 Quartier = haus["Quartier"] as int?,
                                                 Zone = haus["Zone"] as int?,
                                                 StatistischeZone = haus["StatistischeZone"] as int?
                                             });
            }
            return haeuser;
        }

        private IDictionary<string, int> LoadQTHashtable()
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
               SELECT OrgUnitID, ItemName
               FROM XOrgUnit
               WHERE ItemName LIKE 'QT %'");

            IDictionary<string, int> qtName2orgUnitID = new Dictionary<string, int>();
            foreach (DataRow orgUnit in qry.DataTable.Rows)
            {
                string qtName = (string)orgUnit[1];
                qtName2orgUnitID.Add(qtName.Remove(0, 3), (int)orgUnit[0]);
            }
            return qtName2orgUnitID;
        }

        private void grvBaStrasseEingelesen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int? baStrasseID = grvBaStrasseEingelesen.GetFocusedRowCellValue("BaStrasseID") as int?;
            if (baStrasseID.HasValue && haeuserEingelesen != null)
            {
                FocusStrasse(baStrasseID.Value, grvBaStrasseEingelesen.GetFocusedRowCellValue("StrassenName") as string);
            }
        }

        private void FocusStrasse(int baStrasseID, string strassenName)
        {
            grdBaHausEingelesen.DataSource = haeuserEingelesen.Where(haus => haus.BaStrasseID == baStrasseID).ToArray();
            lblImportedBaHaus.Text = string.Format("Importierte Adressen für Strasse '{0}'", strassenName);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DlgProgressLog.Show("Adressen updaten", false, 700, 500, new ProgressEventHandler(ProgressStart), new ProgressEventHandler(ProgressEnd), Session.MainForm);
        }

        private void ProgressStart()
        {
            const string updateStrasseSQL = @"UPDATE BaStrasse
                                              SET StrasseLang = {1}, Aktiv = 1
                                              WHERE BaStrasseID = {0}";
            const string insertStrasseSQL = @"INSERT BaStrasse (BaStrasseID, OrtCode, Aktiv, StrasseKurz, StrasseLang)
                                              VALUES           (        {0}, 261    , 1    , ''         , {1})";
            const string updateHausSQL = @"UPDATE BaHaus
                                           SET PLZ = {1}, OrgUnitID = {2}, Kreis = {3}, Quartier = {4}, Zone = {5}, StatistischeZone = {6}
                                           WHERE BaHausID = {0}";
            const string insertHausSQL = @"INSERT BaHaus (BaStrasseID, Hausnummer, Suffix, PLZ, OrgUnitID, Kreis, Quartier, Zone, StatistischeZone)
                                           VALUES        ({0},         {1}       , {2}   , {3}, {4}      , {5}  , {6}     , {7} , {8})";
            const string updateStrasseFeedback = "{0} Strassen aktualisiert";
            const string insertStrasseFeedback = "{0} Strassen hinzugefügt";
            const string updateHausFeedback = "{0} Adressen aktualisiert";
            const string insertHausFeedback = "{0} Adressen hinzugefügt";

            int strassenAktualisiert = 0;
            int strassenEingefuegt = 0;
            int adressenAktualisiert = 0;
            int adressenEingefuegt = 0;

            int rowsAffected;
            int errorCount = 0;

            ApplicationFacade.DoEvents();
            DlgProgressLog.AddLine("Import gestartet");

            try
            {
                Cursor = Cursors.WaitCursor;

                // UPDATE BaStrasse
                DlgProgressLog.AddLine("Strassen aktualisieren...");
                DlgProgressLog.AddLine(string.Format(updateStrasseFeedback, strassenAktualisiert));

                Session.BeginTransaction();
                foreach (KeyValuePair<BaStrasseDTO, BaStrasseDTO> diffStrasse in strassenVeraendert)
                {
                    rowsAffected = DBUtil.ExecSQL(updateStrasseSQL, diffStrasse.Key.BaStrasseID, diffStrasse.Value.StrassenName);
                    if (rowsAffected == 0)
                    {
                        DlgProgressLog.UpdateLastLine(string.Format("Fehler: Strasse konnte nicht aktualisiert werden (BaStrasseID {0}, Name (bisher) '{1}', Name (neu) '{2}'", diffStrasse.Key.BaStrasseID, diffStrasse.Key.StrassenName, diffStrasse.Value.StrassenName));
                        DlgProgressLog.AddLine(string.Format(updateStrasseFeedback, strassenAktualisiert));
                        errorCount++;
                    }
                    else if (rowsAffected == 1)
                    {
                        DlgProgressLog.UpdateLastLine(string.Format(updateStrasseFeedback, ++strassenAktualisiert));
                    }
                    else
                    {
                        DlgProgressLog.UpdateLastLine(string.Format("Fehler: Mehr als ein Datensatz wurde aktualisiert! (BaStrasseID {0}, Name (bisher) '{1}', Name (neu) '{2}'", diffStrasse.Key.BaStrasseID, diffStrasse.Key.StrassenName, diffStrasse.Value.StrassenName));
                        DlgProgressLog.AddLine(string.Format(updateStrasseFeedback, strassenAktualisiert));
                        errorCount++;
                    }
                }

                // INSERT BaStrasse
                DlgProgressLog.AddLine("Neue Strassen hinzufügen...");
                DlgProgressLog.AddLine(string.Format(insertStrasseFeedback, strassenEingefuegt));

                foreach (BaStrasseDTO strasseNeu in strassenNeu)
                {
                    rowsAffected = DBUtil.ExecSQL(insertStrasseSQL, strasseNeu.BaStrasseID, strasseNeu.StrassenName);
                    if (rowsAffected == 0)
                    {
                        DlgProgressLog.UpdateLastLine(string.Format("Fehler: Strasse konnte nicht eingefügt werden (Name '{0}')", strasseNeu.StrassenName));
                        DlgProgressLog.AddLine(string.Format(insertStrasseFeedback, strassenEingefuegt));
                        errorCount++;
                    }
                    else if (rowsAffected == 1)
                    {
                        DlgProgressLog.UpdateLastLine(string.Format(insertStrasseFeedback, ++strassenEingefuegt));
                    }
                }

                // UPDATE BaHaus
                DlgProgressLog.AddLine("Adressen aktualisieren...");
                DlgProgressLog.AddLine(string.Format(updateHausFeedback, adressenAktualisiert));

                foreach (KeyValuePair<BaHausDTO, BaHausDTO> diffHaus in haeuserVeraendert)
                {
                    rowsAffected = DBUtil.ExecSQL(updateHausSQL, diffHaus.Key.BaHausID, diffHaus.Value.PLZ, diffHaus.Value.OrgUnitID_QT, diffHaus.Value.Kreis, diffHaus.Value.Quartier, diffHaus.Value.Zone, diffHaus.Value.StatistischeZone);
                    if (rowsAffected == 0)
                    {
                        DlgProgressLog.UpdateLastLine(string.Format("Fehler: Adresse konnte nicht aktualisiert werden (BaHausID {0}, BaStrasseID {1}, Hausnummer {2}, Suffix {3}, OrgUnitID (alt) {4}, OrgUnitID (neu) {5}", diffHaus.Key.BaHausID, diffHaus.Key.BaStrasseID, diffHaus.Key.Hausnummer, diffHaus.Key.Suffix, diffHaus.Key.OrgUnitID_QT, diffHaus.Value.OrgUnitID_QT));
                        DlgProgressLog.AddLine(string.Format(updateHausFeedback, adressenAktualisiert));
                        errorCount++;
                    }
                    else if (rowsAffected == 1)
                    {
                        DlgProgressLog.UpdateLastLine(string.Format(updateHausFeedback, ++adressenAktualisiert));
                    }
                    else
                    {
                        DlgProgressLog.UpdateLastLine(string.Format("Fehler: Adresse konnte nicht aktualisiert werden (BaHausID {0}, BaStrasseID {1}, Hausnummer {2}, Suffix {3}, OrgUnitID (alt) {4}, OrgUnitID (neu) {5}", diffHaus.Key.BaHausID, diffHaus.Key.BaStrasseID, diffHaus.Key.Hausnummer, diffHaus.Key.Suffix, diffHaus.Key.OrgUnitID_QT, diffHaus.Value.OrgUnitID_QT));
                        DlgProgressLog.AddLine(string.Format(updateHausFeedback, adressenAktualisiert));
                        errorCount++;
                    }
                }

                // INSERT BaHaus
                DlgProgressLog.AddLine("Neue Adressen hinzufügen...");
                DlgProgressLog.AddLine(string.Format(insertHausFeedback, adressenEingefuegt));

                foreach (BaHausDTO hausNeu in haeuserNeu)
                {
                    rowsAffected = DBUtil.ExecSQL(insertHausSQL, hausNeu.BaStrasseID, hausNeu.Hausnummer, hausNeu.Suffix, hausNeu.PLZ, hausNeu.OrgUnitID_QT, hausNeu.Kreis, hausNeu.Quartier, hausNeu.Zone, hausNeu.StatistischeZone);
                    if (rowsAffected == 0)
                    {
                        DlgProgressLog.UpdateLastLine(string.Format("Fehler: Adresse konnte nicht eingefügt werden (BaStrasseID {0}, Hausnummer {1}, Suffix {2}, OrgUnitID {3})", hausNeu.BaStrasseID, hausNeu.Hausnummer, hausNeu.Suffix, hausNeu.OrgUnitID_QT));
                        DlgProgressLog.AddLine(string.Format(insertHausFeedback, adressenEingefuegt));
                        errorCount++;
                    }
                    else if (rowsAffected == 1)
                    {
                        DlgProgressLog.UpdateLastLine(string.Format(insertHausFeedback, ++adressenEingefuegt));
                    }
                }
                DlgProgressLog.AddLine(string.Format("{0} Fehler aufgetreten", errorCount));
                DlgProgressLog.AddLine("Import abgeschlossen");

                XLog.Create("FrmBaStrassenverzeichnis", LogLevel.INFO, string.Format("Import des Strassenverzeichnis abgeschlossen. {0} geänderte Strassen, {1} neue Strassen, {2} geänderte Adressen, {3} neue Adressen. {4} Fehler", strassenAktualisiert, strassenEingefuegt, adressenAktualisiert, adressenEingefuegt, errorCount), Session.User.UserID);

                Session.Commit();

                strassenEingelesen = null;
                haeuserEingelesen = null;
                strassenVeraendert = null;
                strassenNeu = null;
                haeuserVeraendert = null;
                haeuserNeu = null;

                grdStrassenNeu.DataSource = null;
                grdDifferenzenStrasse.DataSource = null;
                grdHausNeu.DataSource = null;
                grdDifferenzenHaus.DataSource = null;
                grdImport.DataSource = null;
                grdBaStrasseEingelesen.DataSource = null;
                grdBaHausEingelesen.DataSource = null;
            }
            catch (Exception ex)
            {
                Session.Rollback();
                XLog.Create("FrmBaStrassenverzeichnis", LogLevel.ERROR, string.Format("Import des Strassenverzeichnis fehlgeschlagen, Fehlermeldung: '{0}'", ex.Message), Session.User.UserID);
                DlgProgressLog.AddError(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
            }
        }

        private void ProgressEnd()
        {
        }
    }
}