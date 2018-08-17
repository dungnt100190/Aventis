using System;

using KiSS4.DB;
using KiSS4.Messages;

namespace KiSS4.FAMOZ.VIS
{
    /// <summary>
    /// Class contains common used helper methods for VM-Mandate
    /// </summary>
    public class UtilsVIS
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Erstellt neue VM-Leistung inkl. VMMassnahme und synchronisiert die VIS-Daten gleich rüber ins KiSS
        /// </summary>
        /// <param name="faFallID"></param>
        /// <param name="baPersonID"></param>
        /// <param name="arrangementId"></param>
        /// <param name="ueberfuehren"> </param>
        /// <returns>FaLeistungID, falls die Leistung erstellt werden konnte, sonst -1</returns>
        public static int CreateNewVMLeistung(int faFallID, int baPersonID, int vormschID, string arrangementId, bool ueberfuehren)
        {
            int faLeistungID = -1;
            bool transactionStarted = false;

            try
            {
                // Prüfe, ob es nicht schon eine aktive V-Leistung für diese ArrangementId gibt
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT LEI.FaFallID, LEI.FaLeistungID
                    FROM FaLeistung LEI
                      INNER JOIN VmMassnahme MAS ON MAS.FaLeistungID = LEI.FaLeistungID
                    WHERE MAS.VIS_ArrangementId = {0} AND LEI.DatumBis IS NULL", arrangementId);

                if (qry.Count > 0)
                {
                    // es gibt bereits eine aktive Leistung für diese VormschID => exception
                    KissMsg.ShowInfo(string.Format("Für die VIS-Massnahme mit VormschID {0} kann keine neuen M-Leistung erstellt werden,\r\nda sie bereits aktiv in der Leistung {1} im Fall {2} geführt wird.", vormschID, qry["FaLeistungID"], qry["FaFallID"]));
                    return -1;
                }

                // Prüfe, ob die Namen des VIS-Mandants und KiSS-Person übereinstimmen.
                qry = DBUtil.OpenSQL(@"
                    DECLARE @Name VARCHAR(100);
                    DECLARE @Vorname VARCHAR(100);
                    DECLARE @KissMandant VARCHAR(300);

                    SELECT
                      @Name = Name,
                      @Vorname = Vorname,
                      @KissMandant = DisplayText
                    FROM dbo.vwPerson PRS WITH (READUNCOMMITTED)
                    WHERE BaPersonID = {0}

                    SELECT DISTINCT
                      GleichePerson = CONVERT(BIT, CASE WHEN DOS.Name <> @Name AND DOS.Vorname <> @Vorname THEN 0 ELSE 1 END),
                      VISMandant    = DOS.Name + ' ' + DOS.Vorname + ' (' + CONVERT(VARCHAR, DATEDIFF(yy, DOS.G_DAT, GetDate())) + ',' + DOS.SEX + ')',
                      KiSSMandant   = @KissMandant
                    FROM dbo.vwVIS_MASSNAHMEN VMAS
                      INNER JOIN dbo.vwVIS_DOSSIER DOS ON DOS.Id = VMAS.DossierId
                    WHERE VMAS.ArrangementId = {1}",
                    baPersonID, arrangementId);

                if (!(bool)qry["GleichePerson"])
                {
                    // Dies ist vermutlich nicht die gleiche Person => Frage nochmals nach
                    if (!KissMsg.ShowQuestion(string.Format("Der Name des VIS-Mandanten ist nicht gleich wie der Name der selektierten KiSS-Person.\r\nSind Sie sicher, dass Sie diesen VIS-Fall mit dem KiSS-Fall verbinden wollen?\r\nVIS-Mandant:{0}\r\nKiSS-Person:{1}", qry["VISMandant"], qry["KiSSMandant"])))
                    {
                        // Der Benutzer hat abgebrochen
                        return -1;
                    }
                }

                if (Session.Transaction == null)
                {
                    Session.BeginTransaction();
                    transactionStarted = true;
                }

                int? eroeffnungsgrund;
                int userId;
                int? sachbearbeiterId;

                if (ueberfuehren)
                {
                    eroeffnungsgrund = 21004; // LOV EroeffnungsGrund 21004=Überführung altrechtliche Massnahme in Neurechtliche
                    var qryLeistung = DBUtil.OpenSQL(@"
                        SELECT LEI.UserID, LEI.SachbearbeiterID
                        FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                          INNER JOIN dbo.VmMassnahme MAS WITH (READUNCOMMITTED) ON MAS.FaLeistungID = LEI.FaLeistungID
                        WHERE MAS.VIS_ArrangementId_Neurechtlich = {0}
                          AND LEI.DatumBis IS NULL;",
                        arrangementId);

                    userId = Convert.ToInt32(qryLeistung["UserID"]);
                    sachbearbeiterId = qryLeistung["SachbearbeiterID"] as int?;

                    // altrechtliche Massnahme abschliessen falls sie noch nicht abgeschlossen ist.
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE LEI
                          SET AbschlussGrundCode = 21007,
                              DatumBis = {1}
                        FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                          INNER JOIN dbo.VmMassnahme MAS WITH (READUNCOMMITTED) ON MAS.FaLeistungID = LEI.FaLeistungID
                        WHERE MAS.VIS_ArrangementId_Neurechtlich = {0}
                          AND LEI.DatumBis IS NULL;",
                        arrangementId,
                        DateTime.Today);
                }
                else
                {
                    eroeffnungsgrund = null;
                    userId = Session.User.UserID;
                    sachbearbeiterId = null;
                }

                // neue VM-FaLeistung
                qry = DBUtil.OpenSQL(@"
                    INSERT INTO dbo.FaLeistung (FaFallID, BaPersonID, UserID, SachbearbeiterID, DatumVon, ModulID, FaProzessCode, EroeffnungsGrundCode, Creator, Created, Modifier, Modified)
                      VALUES ({0}, {1}, {2}, {6}, {5}, 2, 210, {4}, {3}, GetDate(), {3}, GetDate());
                    SELECT FaLeistungID = CONVERT(INT, SCOPE_IDENTITY());",
                    faFallID,
                    baPersonID,
                    userId,
                    DBUtil.GetDBRowCreatorModifier(),
                    eroeffnungsgrund,
                    DateTime.Today,
                    sachbearbeiterId);

                faLeistungID = (int)qry["FaLeistungID"];

                // Füge einer allenfalls noch existierenden, inaktiven V-Leistung einen Kommentar zur Leistungs-Bemerkung
                DBUtil.ExecSQL(@"
                    UPDATE LEI
                      SET Bemerkung = ISNULL(convert(varchar(max), LEI.Bemerkung) + CHAR(10), '') + {1}, Modifier = {2}, Modified = GetDate()
                    FROM dbo.FaLeistung LEI
                      INNER JOIN VmMassnahme MAS ON MAS.FaLeistungID = LEI.FaLeistungID
                    WHERE MAS.VIS_ArrangementId = {0}",
                    arrangementId,
                    string.Format("Diese M-Leistung mit VIS VormschID {3} wird seit dem {0:d} im Fall {1} unter der M-Leistung {2} geführt.", DateTime.Now, faFallID, faLeistungID, vormschID),
                    DBUtil.GetDBRowCreatorModifier());

                // Neue VM-Massnahme
                qry = DBUtil.OpenSQL(@"
                    INSERT INTO dbo.VmMassnahme (FaLeistungID, DatumVon, VIS_VormschID, VIS_ArrangementId)
                    VALUES ({0}, GetDate(), {1}, {2})",
                    faLeistungID,
                    vormschID,
                    arrangementId);

                //Eintrag Fallverlaufsprotokoll
                DBUtil.ExecSQL(@"
                    INSERT INTO dbo.FaJournal (FaFallID, FaLeistungID, UserID, Text, OrgUnitID)
                      VALUES ({0},{1},{2},{3},{4})",
                    faFallID,
                    faLeistungID,
                    Session.User.UserID,
                    "Kindes- und Erwachsenenschutzmassnahme angelegt für VormschID " + vormschID,
                    Session.User["OrgUnitID"]);

                if (transactionStarted)
                {
                    Session.Commit();
                }

                // Importiere die Massnahme aus VIS. Dies überschreibt redundant gehaltene Daten im KiSS
                // (Wir machen dies ausserhalb der Transaktion, da der LinkedServer zu VIS keine Distributed Transactions zulässt)
                UtilsVIS.SyncVISToKiSS(faLeistungID);
            }
            catch (Exception ex)
            {
                if (transactionStarted)
                {
                    Session.Rollback();
                }

                KissMsg.ShowError("Die neue M-Leistung konnte nicht eröffnet werden. Folgender Fehler ist während dem Erstellen aufgetreten:\r\n" + ex.Message);

                return -1;
            }

            return faLeistungID;
        }

        /// <summary>
        /// Exportiere Berichtsdaten aus KiSS nach VIS
        /// Dies überschreibt redundant gehaltene Daten im VIS
        /// </summary>
        /// <param name="VmBerichtID">VmBerichtID des Berichts, der synchronisiert werden soll</param>
        public static void SyncKiSSToVIS(int vmBerichtID)
        {
            // Synchronisiere den Bericht
            new VMSyncHelper().SyncKiSSToVIS(vmBerichtID);
        }

        /// <summary>
        /// Importiere die Massnahme aus VIS für einen Benutzer
        /// Dies überschreibt redundant gehaltene Daten im KiSS
        /// </summary>
        /// <param name="userID">UserID des Users, dessen V-Leistungen synchronisiert werden soll</param>
        /// <param name="userName">Username des Users, dessen V-Leistungen synchronisiert werden soll. Dies wird nur für die Anzeige verwendet.</param>
        public static void SyncVISToKiSS(int userID, string userName)
        {
            // Synchronisiere die Leistung
            new VMSyncHelper().SyncVISToKiSS(userID, userName);
        }

        /// <summary>
        /// Importiere die Massnahme aus VIS
        /// Dies überschreibt redundant gehaltene Daten im KiSS
        /// </summary>
        /// <param name="faLeistungID">LeistungID der leistung, die synchronisiert werden soll</param>
        public static void SyncVISToKiSS(int faLeistungID)
        {
            // Synchronisiere die Leistung
            new VMSyncHelper().SyncVISToKiSS(faLeistungID);
        }

        /// <summary>
        /// Importiere alle im KiSS gehaltenen Massnahme aus VIS
        /// Dies überschreibt redundant gehaltene Daten im KiSS
        /// </summary>
        public static void SyncVISToKiSS()
        {
            // Synchronisiere alle Leistungen
            new VMSyncHelper().SyncVISToKiSS();
        }

        #endregion

        #endregion

        #region Nested Types

        private class VMSyncHelper
        {
            #region Fields

            #region Private Fields

            private string _sql;
            private int _userID = 0;

            #endregion

            #endregion

            #region Methods

            #region Public Methods

            public void SyncKiSSToVIS(int vmBerichtID)
            {
                _sql = string.Format(@"
                    UPDATE VBER
                      SET EINGANG_SDS = BER.DatumEingangSDS,
                          AUSGANG_SDS = BER.DatumAusgangSDS
                    FROM dbo.vwVIS_BERICHT     VBER
                      INNER JOIN dbo.VmBericht BER  ON BER.VIS_BK_ID = VBER.BK_ID
                    WHERE BER.VMBerichtID = {0}", vmBerichtID);

                DlgProgressLog.Show("Synchronisiere 'Eingang/Ausgang SDS' nach VIS", new ProgressEventHandler(SyncVMWithVISThread), null, Session.MainForm);
            }

            public void SyncVISToKiSS(int faLeistungID)
            {
                _sql = string.Format("EXEC dbo.spVISSyncWithKiSS {0}", faLeistungID);

                DlgProgressLog.Show(string.Format("Synchronisiere M-Leistung {0} von VIS nach KiSS", faLeistungID), new ProgressEventHandler(SyncVMWithVISThread), null, Session.MainForm);
            }

            public void SyncVISToKiSS()
            {
                _sql = "EXEC dbo.spVISSyncWithKiSS";

                DlgProgressLog.Show("Synchronisiere alle M-Leistungen von VIS nach KiSS", new ProgressEventHandler(SyncVMWithVISThread), null, Session.MainForm);
            }

            public void SyncVISToKiSS(int userID, string userName)
            {
                _userID = userID;
                DlgProgressLog.Show(string.Format("Synchronisiere alle M-Leistungen von {0} von VIS nach KiSS", userName), new ProgressEventHandler(SyncVMWithVISThreadForMA), null, Session.MainForm);
            }

            #endregion

            #region Private Methods

            private void SyncVMWithVISThread()
            {
                try
                {
                    DlgProgressLog.AddLine("Synchronisiere Daten...");
                    DlgProgressLog.AddLine("Dies kann einige Sekunden dauern ...");

                    DBUtil.ExecSQLThrowingException(1500, _sql, null);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError("Die Synchronisation zwischen VIS und KiSS wurde wegen einem Fehler abgebrochen.\r\nFalls dies ein Timeout- oder Netzwerk-Problem war, versuchen Sie später nochmals.", ex);
                }
                finally
                {
                    DlgProgressLog.CloseDialog();
                    Session.MainForm.Activate();
                }
            }

            private void SyncVMWithVISThreadForMA()
            {
                try
                {
                    DlgProgressLog.AddLine("Synchronisiere Daten...");
                    DlgProgressLog.AddLine("Dies kann einige Sekunden dauern ...");

                    // Selektiere alle V-Leistungen des Users
                    SqlQuery leistungen = DBUtil.OpenSQL("SELECT FaLeistungID FROM FaLeistung WHERE UserID = {0} AND FaProzessCode = 210", _userID);

                    int leistung = 0;
                    int total = leistungen.DataTable.Rows.Count;
                    int count = 0;
                    foreach (System.Data.DataRow row in leistungen.DataTable.Rows)
                    {
                        count++;
                        leistung = (int)row["FaLeistungID"];
                        DlgProgressLog.AddLine(string.Format("{0} von {1}: Update der Leistung {2}", count, total, leistung));

                        DBUtil.ExecSQLThrowingException(300, string.Format("EXEC dbo.spVISSyncWithKiSS {0}", leistung), null);
                    }
                }
                catch (KissCancelException cex)
                {
                    // Cancel-Exception ignorieren wir hier.
                    // Machen wir was mit dem Exception-Objekt, damit es keine Warnung gibt
                    GC.KeepAlive(cex);
                }
                catch (Exception ex)
                {
                    KissMsg.ShowError("Die Synchronisation zwischen VIS und KiSS wurde wegen einem Fehler abgebrochen.\r\nFalls dies ein Timeout- oder Netzwerk-Problem war, versuchen Sie später nochmals.", ex);
                }
                finally
                {
                    DlgProgressLog.CloseDialog();
                }
            }

            #endregion

            #endregion
        }

        #endregion
    }
}