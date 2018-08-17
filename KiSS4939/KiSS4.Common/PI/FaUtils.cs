using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common.PI
{
    /// <summary>
    /// Helper class used for client and case management
    /// </summary>
    public class FaUtils
    {
        #region Enumerations

        /// <summary>
        /// State if BW can be closed or which data is missing
        /// </summary>
        public enum ClosingBWState
        {
            /// <summary>
            /// Close is possible and can be performed
            /// </summary>
            Ok = 1,

            MissingErsterEinsatzAm = 2,
            MissingAbwesenheitKlient = 3,
            MissingEintrittVon = 4,
            MissingAustrittNach = 5
        }

        /// <summary>
        /// State if ED can be closed or which data is missing
        /// </summary>
        public enum ClosingEDState
        {
            /// <summary>
            /// Close is possible and can be performed
            /// </summary>
            Ok = 1,

            MissingErsterEinsatzAm = 2,
            MissingLetzteStandortbestimmung = 3
        }

        #endregion

        #region Fields

        #region Public Constant/Read-Only Fields

        public const string QRY_SITUATIONSBESCHREIBUNG = @"
            SELECT *
            FROM dbo.FaSituationsbeschreibung WITH (READUNCOMMITTED)
            WHERE BaPersonID = {0}
            ORDER BY FaSituationsbeschreibungID ASC;";

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "FaUtils";

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Check if BW process can be closed
        /// </summary>
        /// <param name="faLeistungID">The id of the process to check</param>
        /// <param name="showMessage"><c>True</c> if info message has to be shown or not</param>
        /// <param name="processName">The name of the process to show in message (if flag <paramref name="showMessage"/> is <c>True</c>)</param>
        /// <returns><c>True</c> if item can be closed, otherwise false</returns>
        public static ClosingBWState CheckCanBWBeClosed(int faLeistungID, bool showMessage, string processName)
        {
            // validate FaLeistungID
            if (faLeistungID < 1)
            {
                // invalid
                throw new ArgumentOutOfRangeException("faLeistungID", "Invalid id, cannot perform check.");
            }

            // get value from database
            var qryClosingCheck = DBUtil.OpenSQL(@"
                DECLARE @FaLeistungID INT;
                SET @FaLeistungID = {0};

                SELECT MissingErsterEinsatzAm   = CASE
                                                    WHEN NOT EXISTS (SELECT TOP 1 1
                                                                     FROM dbo.BwEinsatzvereinbarung WITH (READUNCOMMITTED)
                                                                     WHERE FaLeistungID = @FaLeistungID
                                                                       AND ErsterEinsatzAm IS NOT NULL) THEN 1
                                                    ELSE 0
                                                  END,
                       --
                       MissingAbwesenheitKlient = CASE
                                                    WHEN NOT EXISTS (SELECT TOP 1 1
                                                                     FROM dbo.BwAuswertungOrganisation WITH (READUNCOMMITTED)
                                                                     WHERE FaLeistungID = @FaLeistungID
                                                                       AND AbwesenheitKlient IS NOT NULL) THEN 1
                                                    ELSE 0
                                                  END,
                       --
                       MissingEintrittVon       = CASE
                                                    WHEN NOT EXISTS (SELECT TOP 1 1
                                                                     FROM dbo.BwAuswertungOrganisation WITH (READUNCOMMITTED)
                                                                     WHERE FaLeistungID = @FaLeistungID
                                                                       AND BwEintrittVonCode IS NOT NULL) THEN 1
                                                    ELSE 0
                                                  END,
                       --
                       MissingAustrittNach      = CASE
                                                    WHEN NOT EXISTS (SELECT TOP 1 1
                                                                     FROM dbo.BwAuswertungOrganisation WITH (READUNCOMMITTED)
                                                                     WHERE FaLeistungID = @FaLeistungID
                                                                       AND BwAustrittNachCode IS NOT NULL) THEN 1
                                                    ELSE 0
                                                  END;", faLeistungID);

            // validate
            if (qryClosingCheck.IsEmpty)
            {
                throw new InvalidOperationException("Invalid operation, the expected query result is empty.");
            }

            // check data
            if (Convert.ToBoolean(qryClosingCheck["MissingErsterEinsatzAm"]))
            {
                if (showMessage)
                {
                    KissMsg.ShowInfo(CLASSNAME, "BWCannotBeClosedErsterEinsatzAm", "Der '{0}' Prozess kann nicht abgeschlossen werden.{1}{1}Das Feld 'Erster Einsatz am' der Einsatzvereinbarung muss ausgefüllt sein.", 0, 0, processName, Environment.NewLine);
                }

                return ClosingBWState.MissingErsterEinsatzAm;
            }

            if (Convert.ToBoolean(qryClosingCheck["MissingAbwesenheitKlient"]))
            {
                if (showMessage)
                {
                    KissMsg.ShowInfo(CLASSNAME, "BWCannotBeClosedAbwesenheitKlient", "Der '{0}' Prozess kann nicht abgeschlossen werden.{1}{1}Das Feld 'Anzahl Wochen' der Auswertung muss ausgefüllt sein.", 0, 0, processName, Environment.NewLine);
                }

                return ClosingBWState.MissingAbwesenheitKlient;
            }

            if (Convert.ToBoolean(qryClosingCheck["MissingEintrittVon"]))
            {
                if (showMessage)
                {
                    KissMsg.ShowInfo(CLASSNAME, "BWCannotBeClosedEintrittVon", "Der '{0}' Prozess kann nicht abgeschlossen werden.{1}{1}Das Feld 'Eintritt von' der Auswertung muss ausgefüllt sein.", 0, 0, processName, Environment.NewLine);
                }

                return ClosingBWState.MissingEintrittVon;
            }

            if (Convert.ToBoolean(qryClosingCheck["MissingAustrittNach"]))
            {
                if (showMessage)
                {
                    KissMsg.ShowInfo(CLASSNAME, "BWCannotBeClosedAustrittNach", "Der '{0}' Prozess kann nicht abgeschlossen werden.{1}{1}Das Feld 'Austritt nach' der Auswertung muss ausgefüllt sein.", 0, 0, processName, Environment.NewLine);
                }

                return ClosingBWState.MissingAustrittNach;
            }

            // if we are here, the BW process can be closed
            return ClosingBWState.Ok;
        }

        /// <summary>
        /// Check if ED process can be closed
        /// </summary>
        /// <param name="faLeistungID">The id of the process to check</param>
        /// <param name="showMessage"><c>True</c> if info message has to be shown or not</param>
        /// <param name="processName">The name of the process to show in message (if flag <paramref name="showMessage"/> is <c>True</c>)</param>
        /// <returns><c>True</c> if item can be closed, otherwise false</returns>
        public static ClosingEDState CheckCanEDBeClosed(int faLeistungID, bool showMessage, string processName)
        {
            // validate FaLeistungID
            if (faLeistungID < 1)
            {
                // invalid
                throw new ArgumentOutOfRangeException("faLeistungID", "Invalid id, cannot perform check.");
            }

            // get value from database
            var qryClosingCheck = DBUtil.OpenSQL(@"
                DECLARE @FaLeistungID INT;
                SET @FaLeistungID = {0};

                SELECT MissingErsterEinsatzAm          = CASE
                                                           WHEN NOT EXISTS (SELECT TOP 1 1
                                                                            FROM dbo.EdEinsatzvereinbarung WITH (READUNCOMMITTED)
                                                                            WHERE FaLeistungID = @FaLeistungID
                                                                              AND ErsterEinsatzAm IS NOT NULL) THEN 1
                                                           ELSE 0
                                                         END,
                       --
                       MissingLetzteStandortbestimmung = CASE
                                                           WHEN NOT EXISTS (SELECT TOP 1 1
                                                                            FROM dbo.EdAuswertungsdaten WITH (READUNCOMMITTED)
                                                                            WHERE FaLeistungID = @FaLeistungID
                                                                              AND LetzteStandortbestimmung IS NOT NULL) THEN 1
                                                           ELSE 0
                                                         END;", faLeistungID);

            // validate
            if (qryClosingCheck.IsEmpty)
            {
                throw new InvalidOperationException("Invalid operation, the expected query result is empty.");
            }

            // check data
            if (Convert.ToBoolean(qryClosingCheck["MissingErsterEinsatzAm"]))
            {
                if (showMessage)
                {
                    KissMsg.ShowInfo(CLASSNAME, "EDCannotBeClosedErsterEinsatzAm", "Der '{0}' Prozess kann nicht abgeschlossen werden.{1}{1}Das Feld 'Erster Einsatz am' der Einsatzvereinbarung muss ausgefüllt sein.", 0, 0, processName, Environment.NewLine);
                }

                return ClosingEDState.MissingErsterEinsatzAm;
            }

            if (Convert.ToBoolean(qryClosingCheck["MissingLetzteStandortbestimmung"]))
            {
                if (showMessage)
                {
                    KissMsg.ShowInfo(CLASSNAME, "EDCannotBeClosedLetzteStandortbestimmung", "Der '{0}' Prozess kann nicht abgeschlossen werden.{1}{1}Das Feld 'Letzte Standortbestimmung' der Auswertungsdaten muss ausgefüllt sein.", 0, 0, processName, Environment.NewLine);
                }

                return ClosingEDState.MissingLetzteStandortbestimmung;
            }

            // if we are here, the ED process can be closed
            return ClosingEDState.Ok;
        }

        /// <summary>
        /// Check if SB or CM process can be closed
        /// </summary>
        /// <param name="faLeistungID">The id of the process to check</param>
        /// <returns><c>True</c> if item can be closed, otherwise false</returns>
        public static bool CheckCanSBCMBeClosed(int faLeistungID)
        {
            // validate FaLeistungID
            if (faLeistungID < 1)
            {
                // invalid
                throw new ArgumentOutOfRangeException("faLeistungID", "Invalid id, cannot perform check.");
            }

            // get value from database
            int canCloseSBorCM = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnFaCanCloseSBorCMFaLeistungID({0});", faLeistungID));

            // validate output
            if (canCloseSBorCM < 0 || canCloseSBorCM > 1)
            {
                // invalid return type, expect only 1/0
                throw new DataException("Invalid return value, exception occured in statement call.");
            }

            // return value (only if canCLoseSBorCM==1 item can be closed!)
            return Convert.ToBoolean(canCloseSBorCM);
        }

        /// <summary>
        /// Check if there is already a WD with no FaModulDienstleistungenCode
        /// </summary>
        /// <param name="baPersonID">The id of the person to check</param>
        /// <returns><c>True</c> if an active WD with the given FaModulDienstleistungen-code exists, otherwise false</returns>
        public static bool CheckDuplicateEmptyWdExists(int baPersonID)
        {
            var qryOpenWDs = DBUtil.OpenSQL(@"
                SELECT TOP 1
                       FaLeistungID
                FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND ModulID = 31 --WD
                  AND FaModulDienstleistungenCode IS NULL
                  AND (DatumBis IS NULL OR GETDATE() BETWEEN DatumVon AND DatumBis)", baPersonID);

            if (qryOpenWDs.Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if a active WD with same faModulDienstleistungCode exists
        /// </summary>
        /// <param name="baPersonID">The id of the person to check</param>
        /// <param name="faModulDienstleistungCode">The FaModulDienstleistungen-code to check, or NULL</param>
        /// <param name="faLeistungID">The id of the faleistung to check</param>
        /// <returns><c>True</c> if an active WD with the given FaModulDienstleistungen-code exists, otherwise false</returns>
        public static bool CheckDuplicateWdExists(int baPersonID, int faModulDienstleistungCode, int faLeistungID)
        {
            var qryOpenWDs = DBUtil.OpenSQL(@"
                SELECT TOP 1
                       FaLeistungID
                FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND ModulID = 31 --WD
                  AND FaModulDienstleistungenCode = {1}
                  AND FaLeistungID <> {2}
                  AND (DatumBis IS NULL OR GETDATE() BETWEEN DatumVon AND DatumBis)", baPersonID, faModulDienstleistungCode, faLeistungID);

            if (qryOpenWDs.Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Close FaLeistung by now without any further checks (if FaLeistung is not yet closed!)
        /// </summary>
        /// <param name="faLeistungID">The id of the FaLeistung to close</param>
        public static void CloseFaLeistungByNow(int faLeistungID)
        {
            // #7827: DateTime without time
            DBUtil.ExecSQLThrowingException(@"
                UPDATE LEI
                SET LEI.DatumBis = dbo.fnDateOf(GETDATE())
                FROM dbo.FaLeistung LEI
                WHERE LEI.FaLeistungID = {0}
                  AND LEI.DatumBis IS NULL;", faLeistungID);
        }

        /// <summary>
        /// Combines the Date part of a DateTime object with the Time part of a second one.
        /// </summary>
        /// <param name="date">Object with Date part</param>
        /// <param name="time">Object with Time part</param>
        /// <returns>Combined DateTime object</returns>
        public static DateTime CombineDateTime(DateTime date, DateTime time)
        {
            // combine dd.MM.yyyy from date with hh:mm to one new datetime construct
            return Convert.ToDateTime(string.Format("{0:d} {1:T}", date, time));
        }

        /// <summary>
        /// Correct a DateTime to use with Sql-server
        /// </summary>
        /// <param name="date">DateTime to be corrected.</param>
        /// <returns>Corrected DateTime.</returns>
        public static DateTime CorrectDateTimeToSqlDateTime(DateTime date)
        {
            try
            {
                // validate datetime to use for sql-server
                if (date < SqlDateTime.MinValue.Value)
                {
                    // sql-server cannot handle DateTime.MinValue (!!)
                    date = SqlDateTime.MinValue.Value;
                }
                else if (date > SqlDateTime.MaxValue.Value)
                {
                    // sql-server maybe cannot handle DateTime.MaxValue (??)
                    date = SqlDateTime.MaxValue.Value;
                }

                // return possible corrected value
                return date;
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(CLASSNAME, "ErrorCorrectDateTimeSQL", "Es ist ein Fehler in der Verarbeitung aufgetreten.", ex);

                // return date
                return date;
            }
        }

        /// <summary>
        /// Creates a new process for given person and module for current user (will also check if creating is possible)
        /// </summary>
        /// <param name="baPersonID">The person who will get a new process</param>
        /// <param name="modulID">The id of the process to create</param>
        /// <returns>The id of the new created process (FaLeistungID), or -1 if invalid</returns>
        public static int CreateNewProcess(int baPersonID, int modulID)
        {
            // call with current user
            return CreateNewProcess(baPersonID, modulID, Session.User.UserID);
        }

        /// <summary>
        /// Creates a new process for given person and module (will also check if creating is possible)
        /// </summary>
        /// <param name="baPersonID">The person who will get a new process</param>
        /// <param name="modulID">The id of the process to create</param>
        /// <param name="userID">The user who is responsible for new process</param>
        /// <returns>The id of the new created process (FaLeistungID), or -1 if invalid</returns>
        public static int CreateNewProcess(int baPersonID, int modulID, int userID)
        {
            // validate parameters
            if (baPersonID < 1)
            {
                throw new ArgumentOutOfRangeException("baPersonID",
                                                      "Invalid BaPersonID, cannot create new process for given BaPersonID.");
            }

            List<int> validModulIDs = new List<int>
            {
                Convert.ToInt32(BaUtils.ModulID.Fallverlauf),
                Convert.ToInt32(BaUtils.ModulID.SozialBeratung),
                Convert.ToInt32(BaUtils.ModulID.CaseManagement),
                Convert.ToInt32(BaUtils.ModulID.BegleitetesWohnen),
                Convert.ToInt32(BaUtils.ModulID.EntlastungsDienst),
                Convert.ToInt32(BaUtils.ModulID.Intake),
                Convert.ToInt32(BaUtils.ModulID.Assistenzberatung),
                Convert.ToInt32(BaUtils.ModulID.WeitereDL),
            };

            if (!validModulIDs.Contains(modulID))
            {
                throw new ArgumentOutOfRangeException("modulID", "Invalid ModulID, cannot create new process for given ModulID.");
            }
            if (userID < 1)
            {
                throw new ArgumentOutOfRangeException("userID", "Invalid UserID, cannot create new process for given UserID.");
            }

            // FALLVERLAUF:
            // check if FallVerlauf (handled specially)
            if (modulID == 2)
            {
                // create new FV
                return CreateNewFV(baPersonID, userID);
            }

            // DIENSTLEISTUNGEN:
            // find latest Fallverlauf
            var qryFV = DBUtil.OpenSQL(@"
                SELECT TOP 1
                       FaLeistungID,
                       DatumBis
                FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0} AND
                      ModulID = 2
                ORDER BY DatumVon DESC, FaLeistungID DESC", baPersonID);

            // check if we have at least any Fallverlauf
            if (qryFV.Count == 0)
            {
                // cannot append any module, do not continue
                KissMsg.ShowError(CLASSNAME, "NoFallverlaufFound", "Es existiert kein Fallverlauf. Die Dienstleistung kann nicht eröffnet werden.");
                return -1;
            }

            // check if already closed
            if (!DBUtil.IsEmpty(qryFV["DatumBis"]))
            {
                KissMsg.ShowInfo(CLASSNAME, "CurrentItemAlreadyClosed_v02", @"Es besteht kein offener Fallverlauf!{0}{0}(Um einen neuen Prozess zu eröffnen, muss zuerst ein neuer Fall eröffnet werden)", 0, 0, Environment.NewLine);
                return -1;
            }

            // get open Intake / Dienstleistungen
            var qryOpenItems = DBUtil.OpenSQL(@"
                SELECT CountIN = (SELECT COUNT(1)
                                  FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                  WHERE BaPersonID = {0} AND
                                        ModulID = 7 AND
                                        DatumBis IS NULL),
                       CountSB = (SELECT COUNT(1)
                                  FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                  WHERE BaPersonID = {0} AND
                                        ModulID = 3 AND
                                        DatumBis IS NULL),
                       CountCM = (SELECT COUNT(1)
                                  FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                  WHERE BaPersonID = {0} AND
                                        ModulID = 4 AND
                                        DatumBis IS NULL),
                       CountBW = (SELECT COUNT(1)
                                  FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                  WHERE BaPersonID = {0} AND
                                        ModulID = 5 AND
                                        DatumBis IS NULL),
                       CountED = (SELECT COUNT(1)
                                  FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                  WHERE BaPersonID = {0} AND
                                        ModulID = 6 AND
                                        DatumBis IS NULL),
                       CountAB = (SELECT COUNT(1)
                                  FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                                  WHERE BaPersonID = {0} AND
                                        ModulID = 8 AND
                                        DatumBis IS NULL),
                       CountWD = 0 -- Es ist erlaubt mehreren WD-Leistungen gleichzeitig offen zu haben
                        ", baPersonID);

            // get values
            int countIN = Convert.ToInt32(qryOpenItems["CountIN"]);
            int countSB = Convert.ToInt32(qryOpenItems["CountSB"]);
            int countCM = Convert.ToInt32(qryOpenItems["CountCM"]);
            int countBW = Convert.ToInt32(qryOpenItems["CountBW"]);
            int countED = Convert.ToInt32(qryOpenItems["CountED"]);
            int countAB = Convert.ToInt32(qryOpenItems["CountAB"]);

            // validate if a new item is possible, depending on modulID
            switch (modulID)
            {
                case 3:	// SB
                    if (countSB > 0)
                    {
                        // cannot have a new SozialBeratung if one is open
                        KissMsg.ShowInfo(CLASSNAME, "OpenSBExists", "Es gibt noch eine offene Sozialberatung, welche zuerst abgeschlossen werden muss!");
                        return -1;
                    }

                    if (countIN > 0)
                    {
                        // cannot have a new SozialBeratung if Intake is open
                        KissMsg.ShowInfo(CLASSNAME, "OpenIntakeExistsForDL", "Es gibt noch ein offenes Intake, welches vor dem Eröffnen einer neuen Dienstleistung abgeschlossen werden muss!");
                        return -1;
                    }
                    break;

                case 4:	// CM
                    if (countCM > 0)
                    {
                        // cannot have a new CaseManagement if one is open
                        KissMsg.ShowInfo(CLASSNAME, "OpenCMExists", "Es gibt noch ein offenes Case Management, welches zuerst abgeschlossen werden muss!");
                        return -1;
                    }

                    if (countIN > 0)
                    {
                        // cannot have a new CaseManagement if Intake is open
                        KissMsg.ShowInfo(CLASSNAME, "OpenIntakeExistsForDL", "Es gibt noch ein offenes Intake, welches vor dem Eröffnen einer neuen Dienstleistung abgeschlossen werden muss!");
                        return -1;
                    }
                    break;

                case 5:	// BW
                    if (countBW > 0)
                    {
                        // cannot have a new BegleitetesWohnen if one is open
                        KissMsg.ShowInfo(CLASSNAME, "OpenBWExists", "Es gibt noch ein offenes Begleitetes Wohnen, welches zuerst abgeschlossen werden muss!");
                        return -1;
                    }

                    if (countIN > 0)
                    {
                        // cannot have a new BegleitetesWohnen if Intake is open
                        KissMsg.ShowInfo(CLASSNAME, "OpenIntakeExistsForDL", "Es gibt noch ein offenes Intake, welches vor dem Eröffnen einer neuen Dienstleistung abgeschlossen werden muss!");
                        return -1;
                    }
                    break;

                case 6:	// ED
                    if (countED > 0)
                    {
                        // cannot have a new EntlastungsDienst if one is open
                        KissMsg.ShowInfo(CLASSNAME, "OpenEDExists", "Es gibt noch ein offener Entlastungsdienst, welcher zuerst abgeschlossen werden muss!");
                        return -1;
                    }

                    if (countIN > 0)
                    {
                        // cannot have a new EntlastungsDienst if Intake is open
                        KissMsg.ShowInfo(CLASSNAME, "OpenIntakeExistsForDL", "Es gibt noch ein offenes Intake, welches vor dem Eröffnen einer neuen Dienstleistung abgeschlossen werden muss!");
                        return -1;
                    }
                    break;

                case 7:	// IN
                    if (countIN > 0)
                    {
                        // cannot have a new Intake if one is open
                        KissMsg.ShowInfo(CLASSNAME, "OpenIntakeExists", "Es gibt noch ein offenes Intake, welches zuerst abgeschlossen werden muss!");
                        return -1;
                    }
                    break;

                case 8:	// AB
                    if (countAB > 0)
                    {
                        // cannot have a new Assistenzberatung if one is open
                        KissMsg.ShowInfo(CLASSNAME, "OpenABExists", "Es gibt noch eine offene Assistenzberatung, welche zuerst abgeschlossen werden muss!");
                        return -1;
                    }

                    if (countIN > 0)
                    {
                        // cannot have a new EntlastungsDienst if Intake is open
                        KissMsg.ShowInfo(CLASSNAME, "OpenIntakeExistsForDL", "Es gibt noch ein offenes Intake, welches vor dem Eröffnen einer neuen Dienstleistung abgeschlossen werden muss!");
                        return -1;
                    }
                    break;

                case 31://WD
                    //9577 : Es ist erlaubt mehreren WD-Leistungen gleichzeitig offen zu haben
                    break;

                default: // unknown
                    // cannot append any module, do not continue
                    KissMsg.ShowError(CLASSNAME, "InvalidModule", "Ungültiger Wert, es kann keine neue Dienstleistung eröffnet werden zu diesem Wert.");
                    return -1;
            }

            // init new vars
            // #7827: DateTime without time
            var newDLDateFrom = DateTimeWithoutTime(DateTime.Today);

            // check if DatumVon can be used
            // #9577-002 : Modul 31 (Weiter Dienstleistungen) darf mehreren aktiven Einträge haben
            bool doCheckIsDateInOtherProcess = modulID != Convert.ToInt32(BaUtils.ModulID.WeitereDL);
            if (!IsProcessDateValid(modulID, Convert.ToInt32(qryFV["FaLeistungID"]), true, newDLDateFrom.Value, DateTime.MinValue, doCheckIsDateInOtherProcess))
            {
                // cannot create new module with today's date
                KissMsg.ShowError(CLASSNAME, "InvalidTodaysDateForNewModule", "Für das heutige Datum kann keine neue Dienstleistung vom gewählten Typ erstellt werden.");
                return -1;
            }

            // -> if we are here, we can create a new item

            // insert a new module / Dienstleistung
            SqlQuery qryNewModule = DBUtil.OpenSQL(@"
                    INSERT dbo.FaLeistung (BaPersonID, FaFallID, ModulID, DatumVon, UserID, Creator, Created, Modifier, Modified)
                    VALUES ({0}, {0}, {1}, {2}, {3}, {4}, GETDATE(), {4}, GETDATE());

                    SELECT ID = SCOPE_IDENTITY();", baPersonID, modulID, newDLDateFrom, userID, DBUtil.GetDBRowCreatorModifier());

            // validate
            if (qryNewModule.Count > 0)
            {
                // success, return new id of process
                return Convert.ToInt32(qryNewModule["ID"]);
            }

            // failed, show info
            KissMsg.ShowError(CLASSNAME, "CouldNotCreateNewDLProcess", "Die Dienstleistung konnte aufgrund eines Datenbank-Fehlers nicht erstellt werden, bitte versuchen Sie es erneut (ID < 1).");

            // return failed
            return -1;
        }

        /// <summary>
        /// Get date without time of query column
        /// </summary>
        /// <param name="qry">The SqlQuery containing the given column to use</param>
        /// <param name="columnName">The column name within the given SqlQuery containing the date or DBNull</param>
        /// <returns>The date without time or null</returns>
        public static DateTime? DateTimeWithoutTime(SqlQuery qry, string columnName)
        {
            return DBUtil.IsEmpty(qry[columnName]) ? null : DateTimeWithoutTime(Convert.ToDateTime(qry[columnName]));
        }

        /// <summary>
        /// Get date without time
        /// </summary>
        /// <param name="dateTime">The date time to parse</param>
        /// <returns>The date without time or null</returns>
        public static DateTime? DateTimeWithoutTime(DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.Date : dateTime;
        }

        /// <summary>
        /// Get the id of the person corresponding to given id in FaLeistung
        /// </summary>
        /// <param name="faLeistungID">The id within FaLeistung to use</param>
        /// <returns>The id of the person or -1 if no id was found</returns>
        public static int GetBaPersonIDFromFaLeistungID(int faLeistungID)
        {
            // validate FaLeistungID
            if (faLeistungID < 1)
            {
                // no matching data will be found
                return -1;
            }

            // get value from database
            return Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                DECLARE @BaPersonID INT;

                SELECT @BaPersonID = LEI.BaPersonID
                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                WHERE LEI.FaLeistungID = {0};

                SELECT ISNULL(@BaPersonID, -1);", faLeistungID));
        }

        /// <summary>
        /// Get the BwAuswertungOrganisationID for a FaLeistung
        /// </summary>
        /// <param name="faLeistungId">Id of the FaLeistung</param>
        /// <returns>The corresponding id to FaLeistung of BwAuswertungOrganisation or -1 if invalid/not found</returns>
        public static int GetBwAuswertungOrganisationID(int faLeistungId)
        {
            // validate
            if (faLeistungId < 1)
            {
                // no valid id
                return -1;
            }

            // get id
            int bwAuswertungOrganisationID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                DECLARE @BwAuswertungOrganisationID INT;

                SELECT TOP 1
                       @BwAuswertungOrganisationID = BWA.BwAuswertungOrganisationID
                FROM dbo.BwAuswertungOrganisation BWA WITH (READUNCOMMITTED)
                WHERE BWA.FaLeistungID = {0}
                ORDER BY BWA.BwAuswertungOrganisationID ASC;

                SELECT ISNULL(@BwAuswertungOrganisationID, -1);", faLeistungId));

            // return found id
            return bwAuswertungOrganisationID;
        }

        /// <summary>
        /// Get the BwEinsatzvereinbarungID for a FaLeistung
        /// </summary>
        /// <param name="faLeistungId">Id of the FaLeistung</param>
        /// <returns>The corresponding id to FaLeistung of BwEinsatzvereinbarung or -1 if invalid/not found</returns>
        public static int GetBwEinsatzvereinbarungID(int faLeistungId)
        {
            // validate
            if (faLeistungId < 1)
            {
                // no valid id
                return -1;
            }

            // get id
            int bwEinsatzvereinbarungID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                DECLARE @BwEinsatzvereinbarungID INT;

                SELECT TOP 1
                       @BwEinsatzvereinbarungID = BWV.BwEinsatzvereinbarungID
                FROM dbo.BwEinsatzvereinbarung BWV WITH (READUNCOMMITTED)
                WHERE BWV.FaLeistungID = {0}
                ORDER BY BWV.BwEinsatzvereinbarungID ASC;

                SELECT ISNULL(@BwEinsatzvereinbarungID, -1);", faLeistungId));

            // return found id
            return bwEinsatzvereinbarungID;
        }

        /// <summary>
        /// Get the EdEinsatzvereinbarungID for a FaLeistung
        /// </summary>
        /// <param name="faLeistungId">Id of the FaLeistung</param>
        /// <returns>The corresponding id to FaLeistung of EdEinsatzvereinbarung or -1 if invalid/not found</returns>
        public static int GetEdEinsatzvereinbarungID(int faLeistungId)
        {
            // validate
            if (faLeistungId < 1)
            {
                // no valid id
                return -1;
            }

            // get id
            int edEinsatzvereinbarungID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                DECLARE @EdEinsatzvereinbarungID INT;

                SELECT TOP 1
                       @EdEinsatzvereinbarungID = EDV.EdEinsatzvereinbarungID
                FROM dbo.EdEinsatzvereinbarung EDV WITH (READUNCOMMITTED)
                WHERE EDV.FaLeistungID = {0}
                ORDER BY EDV.EdEinsatzvereinbarungID ASC;

                SELECT ISNULL(@EdEinsatzvereinbarungID, -1);", faLeistungId));

            // return found id
            return edEinsatzvereinbarungID;
        }

        /// <summary>
        /// Get the FaBetreuungsinfoID for a BaPersonID
        /// </summary>
        /// <param name="baPersonId">ID of the BaPerson</param>
        /// <returns>The corresponding id to BaPerson of FaBetreuungsinfo or -1 if invalid/not found</returns>
        public static int GetFaBetreuungsinfoID(int baPersonId)
        {
            // validate
            if (baPersonId < 1)
            {
                // no valid id
                return -1;
            }

            // get id
            int faBetreuungsinfoID = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                DECLARE @FaBetreuungsinfoID INT;

                SELECT TOP 1
                       @FaBetreuungsinfoID = FAB.FaBetreuungsinfoID
                FROM dbo.FaBetreuungsinfo FAB WITH (READUNCOMMITTED)
                WHERE FAB.BaPersonID = {0}
                ORDER BY FAB.FaBetreuungsinfoID ASC;

                SELECT ISNULL(@FaBetreuungsinfoID, -1);", baPersonId));

            // return id found
            return faBetreuungsinfoID;
        }

        public static void HistorizeSituationsbeschreibung(int baPersonID)
        {
            var qryFaSituationsbeschreibung = new SqlQuery();
            var qryHistory = new SqlQuery { TableName = "Hist_FaSituationsbeschreibung", CanInsert = true };

            // load data to historize
            qryFaSituationsbeschreibung.Fill(QRY_SITUATIONSBESCHREIBUNG, baPersonID);

            //check if we have something to historize
            if (qryFaSituationsbeschreibung.IsEmpty)
            {
                //there is nothing to historize, simply return
                return;
            }

            // create an empty construct within query
            qryHistory.Fill(@"
                SELECT TOP 1
                        HIS.*
                FROM dbo.Hist_FaSituationsbeschreibung HIS WITH (READUNCOMMITTED)
                WHERE 1=2");

            // insert a new empty row
            qryHistory.Insert(null);

            // copy each value into a new row
            foreach (DataColumn col in
                qryFaSituationsbeschreibung.DataTable.Columns.Cast<DataColumn>()
                .Where(col => !col.ColumnName.Equals("FaSituationsbeschreibungTS")))
            {
                qryHistory[col.ColumnName] = qryFaSituationsbeschreibung.Row[col.ColumnName];
            }

            // modify copied values!
            qryHistory["Hist_UserID"] = Session.User.UserID;
            qryHistory["Hist_Datum"] = DateTime.Now;

            // save pending changes
            if (!qryHistory.Post())
            {
                throw new Exception("Post has failed, data could not be inserted.");
            }
        }

        /// <summary>
        /// Check if date of Fallverlauf start before or ends after any corresponding process (will also show message if invalid)
        /// </summary>
        /// <param name="currentFVFaLeistungID">The id of the Fallverlauf FaLeistungID</param>
        /// <param name="currentBaPersonID">The id of the person who owns the Fallverlauf</param>
        /// <param name="doCheckDatumVon"><c>True</c> if DatumVon has to be checked, <c>False</c> if DatumBis has to be checked</param>
        /// <param name="dateToCheck">The date to check</param>
        /// <returns><c>True</c> if valid, otherwise false</returns>
        public static bool IsFVDateBeforeAfterProcesses(int currentFVFaLeistungID, int currentBaPersonID, bool doCheckDatumVon, DateTime dateToCheck)
        {
            // check if any process starts before or ends after current FV
            int count = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                -- init vars
                DECLARE @FVFaLeistungID INT
                DECLARE @CurrentBaPersonID INT
                DECLARE @DoCheckDatumVon BIT
                DECLARE @DateToCheck DATETIME

                -- set vars
                SET @FVFaLeistungID = {0}
                SET @CurrentBaPersonID = {1}
                SET @DoCheckDatumVon = ISNULL({2}, 1)
                SET @DateToCheck = {3}

                -- check if date is valid
                SELECT COUNT(1)
                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                WHERE LEI.BaPersonID = @CurrentBaPersonID AND
                      LEI.ModulID <> 2 AND                                                -- non-FV
                      dbo.fnFaGetFallIDOfDL(LEI.FaLeistungID, NULL) = @FVFaLeistungID AND -- only DLs within same FV
                      ((@DoCheckDatumVon = 1 AND dbo.fnDateOf(LEI.DatumVon) < @DateToCheck) OR
                       (@DoCheckDatumVon = 0 AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') > @DateToCheck))", currentFVFaLeistungID, currentBaPersonID, doCheckDatumVon, dateToCheck));

            // return result
            if (count > 0)
            {
                // failed, show info
                if (doCheckDatumVon)
                {
                    // invalid DatumVon
                    KissMsg.ShowInfo(CLASSNAME, "FVDatumVonIsAfterProcessDatumVon", "Das Eröffnungsdatum des Fallverlaufs darf nicht nach dem Eröffnungsdatum der ersten zugehörigen Dienstleistung liegen!");
                }
                else
                {
                    // invalid DatumBis
                    KissMsg.ShowInfo(CLASSNAME, "FVDatumBisIsBeforeProcessDatumBis", "Das Abschlussdatum des Fallverlaufs darf nicht vor dem Abschlussdatum der letzten zugehörigen Dienstleistung liegen!");
                }

                // failed
                return false;
            }

            // success
            return true;
        }

        /// <summary>
        /// Check if process dates are valid (will also show message if invalid)
        /// </summary>
        /// <param name="currentModulID">The id of the process module</param>
        /// <param name="currentFaLeistungID">The id of the process</param>
        /// <param name="doCheckDatumVon"><c>True</c> if DatumVon has to be checked, otherwise DatumBis will be chekced</param>
        /// <param name="currentDatumVon">The DatumVon to check</param>
        /// <param name="currentDatumBis">The DatumBis to check</param>
        /// <param name="doCheckIsDateInOtherProcess">Überschneidung erlaubt?</param>
        /// <returns><c>True</c> if date is valid, otherwise <c>False</c></returns>
        public static bool IsProcessDateValid(int currentModulID, int currentFaLeistungID, bool doCheckDatumVon, DateTime currentDatumVon, DateTime currentDatumBis, bool doCheckIsDateInOtherProcess)
        {
            try
            {
                // check if DatumBis needs to be validated
                if (!doCheckDatumVon)
                {
                    // validate DatumBis
                    if (currentDatumBis == DateTime.MinValue || currentDatumBis == DateTime.MaxValue)
                    {
                        throw new ArgumentNullException("currentDatumBis", "The given dateto to check is invalid.");
                    }

                    // check if DatumBis is later than today
                    if (DateTime.Compare(DateTime.Now.Date, currentDatumBis) < 0)
                    {
                        // show message
                        KissMsg.ShowInfo(CLASSNAME, "InFutureInvalidDateTo", "Das Abschlussdatum darf nicht in der Zukunft liegen.");

                        // failed, invalid DatumBis
                        return false;
                    }
                }

                // init vars
                bool resultProcessCheck = false;

                // check if date is within FV (for non-FV-entries)
                var resultFVRangeCheck = IsDateInFVRange(currentModulID, currentFaLeistungID, doCheckDatumVon, currentDatumVon, currentDatumBis);

                // check if success and doCheckIsDateInOtherProcess==true
                if (resultFVRangeCheck && doCheckIsDateInOtherProcess)
                {
                    // check if date does cross with other processes of same modulid
                    resultProcessCheck = IsDateNotInOtherProcess(currentModulID, currentFaLeistungID, doCheckDatumVon, currentDatumVon, currentDatumBis);
                    // return result
                    return resultFVRangeCheck && resultProcessCheck;
                }

                // return result
                return resultFVRangeCheck;
            }
            catch (Exception ex)
            {
                // show message
                KissMsg.ShowError(CLASSNAME, "ErrorCheckIsProcessDateValid", "Es ist ein Fehler beim Prüfen der Prozessdaten aufgetreten.", ex);

                // invalid
                return false;
            }
        }

        public static void SetBeteiligtePersonenInstitutionenCheckedLookupEdit(ref KissCheckedLookupEdit edt)
        {
            edt.ShortedTextMaxLength = 32;
            edt.ToolTipTextFieldName = DBO.fnFaGetBeteiligtePersonenInstitutionen.Text;
        }

        /// <summary>
        /// Update FV responsibility (UserID) depending on current processes
        /// </summary>
        /// <param name="baPersonID">The id of the person to handle</param>
        public static void UpdateFVResponsibility(int baPersonID)
        {
            // update userid on open Fallverlauf depending on open modules
            DBUtil.ExecSQL(@"EXEC dbo.spFaUpdateFVUserID {0};", baPersonID);
        }

        /// <summary>
        /// Check if user is allowed to see persons dossier
        /// </summary>
        /// <param name="baPersonId">The id of the person the user wants to access</param>
        /// <returns><c>True</c> if access is granted, otherwise <c>False</c></returns>
        public static bool UserMayShowPersonDossier(int baPersonId)
        {
            // check if user is admin
            if (Session.User.IsUserAdmin)
            {
                // admin is always allowed to see dossier
                return true;
            }

            // check if user can show this BaPerson
            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT dbo.fnUserMayShowPersonDossier({0}, {1});", Session.User.UserID, baPersonId));
        }

        #endregion

        #region Private Static Methods

        private static int CreateNewFV(int baPersonID, int userID)
        {
            // validate parameters
            if (baPersonID < 1)
            {
                throw new ArgumentOutOfRangeException("baPersonID", "Invalid BaPersonID, cannot create new process for given BaPersonID.");
            }

            if (userID < 1)
            {
                throw new ArgumentOutOfRangeException("userID", "Invalid UserID, cannot create new process for given UserID.");
            }

            // check if any open FV exists
            int countOpenFV = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(1)
                FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0} AND
                        ModulID = 2 AND
                        DatumBis IS NULL", baPersonID));

            // check if any open FV was found
            if (countOpenFV > 0)
            {
                // there is already an open FV
                KissMsg.ShowError(CLASSNAME, "AlreadyOpenFV", "Für diese Person gibt es bereits einen aktiven Fallverlauf!");

                // do not continue
                return -1;
            }

            // init new vars
            // #7827: DateTime without time
            var newFVDateFrom = DateTimeWithoutTime(DateTime.Today);

            // check if any FV exists for today
            // 	1. Invalid: DatumVon < LEI.DatumBis
            int countCrossingFV = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(1)
                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                WHERE LEI.BaPersonID = {0} AND
                        LEI.ModulID = 2 AND
                        ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') > {1};", baPersonID, newFVDateFrom));

            // check if any item was found
            if (countCrossingFV > 0)
            {
                // there is already an open FV
                KissMsg.ShowError(CLASSNAME, "NewFVCrossingDates", "Für das heutige Datum existiert bereits ein Fallverlauf. Ein neuer Fallverlauf darf sich nicht mit einem bereits vorhandenen Fallverlauf überschneiden!");

                // do not continue
                return -1;
            }

            // -> if we are here, we can create a new item

            // insert a new module / Dienstleistung
            SqlQuery qryNewFV = DBUtil.OpenSQL(@"
                INSERT dbo.FaLeistung (BaPersonID, FaFallID, ModulID, DatumVon, UserID, Creator, Created, Modifier, Modified)
                VALUES ({0}, {0}, {1}, {2}, {3}, {4}, GETDATE(), {4}, GETDATE());

                SELECT ID = SCOPE_IDENTITY();", baPersonID, 2, newFVDateFrom, userID, DBUtil.GetDBRowCreatorModifier());

            // validate
            if (qryNewFV.Count > 0)
            {
                // success, return new id of FV
                return Convert.ToInt32(qryNewFV["ID"]);
            }

            // failed, show info
            KissMsg.ShowError(CLASSNAME, "CouldNotCreateNewFV", "Der Fallverlauf konnte aufgrund eines Datenbank-Fehlers nicht erstellt werden, bitte versuchen Sie es erneut (ID < 1).");

            // return failed
            return -1;
        }

        private static bool IsDateInFVRange(Int32 currentModulID, Int32 currentFaLeistungID, Boolean doCheckDatumVon, DateTime currentDatumVon, DateTime currentDatumBis)
        {
            // FallVerlauf cannot be checked and is always valid
            if (currentModulID == 2)
            {
                // good
                return true;
            }

            // check if date-range is withing fallverlauf
            int count = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                -- init vars
                DECLARE @CurrentFaLeistungID INT
                DECLARE @DoCheckDatumVon BIT
                DECLARE @DateToCheck DATETIME
                DECLARE @FVFaLeistungID INT

                -- set vars
                SET @CurrentFaLeistungID = {0}
                SET @DoCheckDatumVon = ISNULL({1}, 1)
                SET @DateToCheck = {2}

                -- get FaLeistungID of FV
                SET @FVFaLeistungID = ISNULL(dbo.fnFaGetFallIDOfDL(@CurrentFaLeistungID, NULL), -1)

                -- check given id
                IF (@FVFaLeistungID < 1)
                BEGIN
                    -- invalid id, set at least one data to have invalid check-result
                    SELECT 1

                    -- do not continue
                    RETURN
                END

                -- check if date is valid
                SELECT COUNT(1)
                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                WHERE LEI.FaLeistungID = @FVFaLeistungID AND
                        ((@DoCheckDatumVon = 1 AND dbo.fnDateOf(LEI.DatumVon) > @DateToCheck) OR
                        (@DoCheckDatumVon = 0 AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') < @DateToCheck));", currentFaLeistungID, doCheckDatumVon, doCheckDatumVon ? currentDatumVon : currentDatumBis));

            // return result
            if (count > 0)
            {
                // failed, show info
                if (doCheckDatumVon)
                {
                    // invalid DatumVon
                    KissMsg.ShowInfo(CLASSNAME, "DatumVonIsBeforeFVDatumVon", "Das Eröffnungsdatum der Dienstleistung darf nicht vor dem Eröffnungsdatum des Fallverlaufs liegen!");
                }
                else
                {
                    // invalid DatumBis
                    KissMsg.ShowInfo(CLASSNAME, "DatumBisIsAfterFVDatumBis", "Das Abschlussdatum der Dienstleistung darf nicht nach dem Abschlussdatum des Fallverlaufs liegen!");
                }

                // failed
                return false;
            }

            // success
            return true;
        }

        private static bool IsDateNotInOtherProcess(Int32 currentModulID, Int32 currentFaLeistungID, Boolean doCheckDatumVon, DateTime currentDatumVon, DateTime currentDatumBis)
        {
            // validate parameters
            List<int> validModulIDs = new List<int>
            {
                Convert.ToInt32(BaUtils.ModulID.Fallverlauf),
                Convert.ToInt32(BaUtils.ModulID.SozialBeratung),
                Convert.ToInt32(BaUtils.ModulID.CaseManagement),
                Convert.ToInt32(BaUtils.ModulID.BegleitetesWohnen),
                Convert.ToInt32(BaUtils.ModulID.EntlastungsDienst),
                Convert.ToInt32(BaUtils.ModulID.Intake),
                Convert.ToInt32(BaUtils.ModulID.Assistenzberatung),
                Convert.ToInt32(BaUtils.ModulID.WeitereDL),
            };
            if (!validModulIDs.Contains(currentModulID))
            {
                throw new ArgumentOutOfRangeException("currentModulID", "The given ModulID is invalid.");
            }

            if (currentFaLeistungID < 1)
            {
                throw new ArgumentOutOfRangeException("currentFaLeistungID", "The given FaLeistungID is invalid.");
            }

            if (currentDatumVon == DateTime.MinValue || currentDatumVon == DateTime.MaxValue)
            {
                throw new ArgumentNullException("currentDatumVon", "The given datefrom to check is invalid.");
            }

            if (!doCheckDatumVon && (currentDatumBis == DateTime.MinValue || currentDatumBis == DateTime.MaxValue))
            {
                throw new ArgumentNullException("currentDatumBis", "The given dateto to check is invalid.");
            }

            // get BaPersonID of given entry
            int currentBaPersonID = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                DECLARE @BaPersonID INT;

                SELECT @BaPersonID = LEI.BaPersonID
                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                WHERE LEI.FaLeistungID = {0};

                SELECT ISNULL(@BaPersonID, -1);", currentFaLeistungID));

            // validate BaPersonID
            if (currentBaPersonID < 1)
            {
                // entry could not be found
                KissMsg.ShowError(CLASSNAME, "CheckDateSearchBaPersonIDNotFound", "Für die gegebene Dienstleistung konnte die zugehörige Person nicht ermittelt werden.");

                // failed
                return false;
            }

            // mode-depending checks
            if (doCheckDatumVon)
            {
                // DATUMVON:
                // check if any other same leistung of this person has this DatumVon already used
                // 	1. Invalid: DatumVon < LEI.DatumBis
                int count = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT COUNT(1)
                    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                    WHERE LEI.BaPersonID = {0} AND
                          LEI.ModulID = {1} AND
                          LEI.FaLeistungID <> {2} AND
                          ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') > {3}; -- those with same start date as enddate of last entry are allowed, earlier entries are permitted (same as below)",
                    currentBaPersonID, currentModulID, currentFaLeistungID, currentDatumVon));

                // check if we have any invalid entry
                if (count > 0)
                {
                    // show message depending on given module
                    switch (currentModulID)
                    {
                        case 2:     // Fallverlauf
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningDateFV", "Das Eröffnungsdatum darf sich nicht mit Werten anderer Fallverläufe überschneiden!");
                            break;

                        case 3:     // SB
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningDateSB", "Das Eröffnungsdatum darf sich nicht mit Werten anderer Dienstleistungen 'Sozialberatung' überschneiden!");
                            break;

                        case 4:     // CM
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningDateCM", "Das Eröffnungsdatum darf sich nicht mit Werten anderer Dienstleistungen 'Case Management' überschneiden!");
                            break;

                        case 5:     // BW
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningDateBW", "Das Eröffnungsdatum darf sich nicht mit Werten anderer Dienstleistungen 'Begleitetes Wohnen' überschneiden!");
                            break;

                        case 6:     // ED
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningDateED", "Das Eröffnungsdatum darf sich nicht mit Werten anderer Dienstleistungen 'Entlastungsdienst' überschneiden!");
                            break;

                        case 7:     // Intake
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningDateIN", "Das Eröffnungsdatum darf sich nicht mit Werten anderer Intakes überschneiden!");
                            break;

                        case 8:     // AB
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningDateAB", "Das Eröffnungsdatum darf sich nicht mit Werten anderer Dienstleistungen 'Assistenzberatung' überschneiden!");
                            break;

                        case 31:   //9557-002 WD do nothing because many WDs can covers the same period
                            break;

                        default:
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningDate", "Das Eröffnungsdatum darf sich nicht mit anderen vorhandenen Werten überschneiden!");
                            break;
                    }

                    // failed
                    return false;
                } // [if (count > 0)]

                // success
                return true;
            }
            else
            {
                // DATUMBIS: VALIDATE FALLVERLAUF
                if (currentModulID == 2)
                {
                    // check if we have any open Dienstleistungen
                    int countDLs = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT COUNT(1)
                        FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                        WHERE LEI.BaPersonID = {0} AND
                              LEI.ModulID <> 2 AND
                              LEI.DatumBis IS NULL;", currentBaPersonID));

                    // check result from database
                    if (countDLs > 0)
                    {
                        // show info
                        KissMsg.ShowInfo(CLASSNAME, "OtherServicesStillOpen", "Der Fallverlauf kann nicht abgeschlossen werden, solange andere Dienstleistungen noch offen sind!");

                        // failed
                        return false;
                    }
                }

                // DATUMBIS:
                // check if range can be used
                // 	1. Invalid: DatumVon < LEI.DatumBis
                // 	2. Invalid: DatumBis < LEI.DatumBis
                int count = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT COUNT(1)
                    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                    WHERE LEI.BaPersonID = {0} AND
                          LEI.ModulID = {1} AND
                          LEI.FaLeistungID <> {2} AND
                          ((ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') > {3}) OR -- those with same start date as enddate of last entry are allowed, earlier entries are permitted (same as above)
                           (ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') > {4}));",
                    currentBaPersonID, currentModulID, currentFaLeistungID, currentDatumVon, currentDatumBis));

                // check if we have any invalid entry
                if (count > 0)
                {
                    // show message depending on given module
                    switch (currentModulID)
                    {
                        case 2:     // Fallverlauf
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningEndingDateFV", "Das Eröffnungsdatum und/oder das Abschlussdatum darf sich nicht mit Werten anderer Fallverläufe überschneiden!");
                            break;

                        case 3:     // SB
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningEndingDateSB", "Das Eröffnungsdatum und/oder das Abschlussdatum darf sich nicht mit Werten anderer Dienstleistungen 'Sozialberatung' überschneiden!");
                            break;

                        case 4:     // CM
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningEndingDateCM", "Das Eröffnungsdatum und/oder das Abschlussdatum darf sich nicht mit Werten anderer Dienstleistungen 'Case Management' überschneiden!");
                            break;

                        case 5:     // BW
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningEndingDateBW", "Das Eröffnungsdatum und/oder das Abschlussdatum darf sich nicht mit Werten anderer Dienstleistungen 'Begleitetes Wohnen' überschneiden!");
                            break;

                        case 6:     // ED
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningEndingDateED", "Das Eröffnungsdatum und/oder das Abschlussdatum darf sich nicht mit Werten anderer Dienstleistungen 'Entlastungsdienst' überschneiden!");
                            break;

                        case 7:     // Intake
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningEndingDateIN", "Das Eröffnungsdatum und/oder das Abschlussdatum darf sich nicht mit Werten anderer Intakes überschneiden!");
                            break;

                        case 8:     // AB
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningEndingDateAB", "Das Eröffnungsdatum und/oder das Abschlussdatum darf sich nicht mit Werten anderer Dienstleistungen 'Assistenzberatung' überschneiden!");
                            break;

                        case 31: //9557-002 WD do nothing because many WDs can covers the same period
                            break;

                        default:
                            KissMsg.ShowInfo(CLASSNAME, "CrossingOpeningEndingDate", "Das Eröffnungsdatum und/oder das Abschlussdatum darf sich nicht mit anderen vorhandenen Werten überschneiden!");
                            break;
                    }

                    // failed
                    return false;
                } // [if (count > 0)]

                // success
                return true;
            } // [if (doCheckDatumVon)]
        }

        #endregion

        #endregion
    }
}