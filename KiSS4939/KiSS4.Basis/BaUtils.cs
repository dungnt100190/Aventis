using System;
using System.Collections.Specialized;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Schnittstellen.Newod.Service;
using SharpLibrary.WinControls;

namespace KiSS4.Basis
{
    #region Enumerations

    public enum ErwerbssituationsCode
    {
        Selbständig = 1,
        AngestelltInDerEigenenFirma = 2,
        RegelmaessigAngestellt = 3,
        ZeitlichBefristeterVertrag = 4,
        ArbeitAufAbruf = 5,
        Gelegenheitsarbeit = 6,
        MitarbeitendesFamilienmitglied = 7,
        InDerLehre = 8,
        Arbeitsintegrationsprogramm = 9,
        BeschaeftigungsprogrammFuerAusgesteuerte = 10,
        AufStellensucheBeimArbeitsamtGemeldet = 11,
        AufStellensucheNichtBeimArbeitsamtGemeldet = 12,
        InAusbildungOhneLehrlinge = 13,
        HaushaltFamiliäreGruende = 14,
        Rentner = 15,
        VoruebergehendArbeitsunfaehig = 16,
        Dauerinvaliditaet = 17,
        KeineChanceAufDemArbeitsmarkt = 18,
        AnderesErwerbstaetig = 20,
        AnderesAufArbeitssuche = 21,
        AnderesNichtErwerbstaetig = 22,
        NichtFestgestellt = 99999
    }

    #endregion

    public class BaUtils
    {
        #region Fields

        #region Private Static Fields

        private static readonly string CLASSNAME = "BaUtils";

        #endregion

        #endregion

        #region Constructors

        private BaUtils()
        {
            // prevent having public constructor
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Handle flag 'Gleicher Haushalt' and copy Wohnsitz address if possible
        /// </summary>
        /// <param name="columnModified"><c>True</c> if column containing the flag was modified, otherwise <c>False</c></param>
        /// <param name="isGleicherHaushalt"><c>True</c> if flag 'Gleicher Haushalt' is set, otherwise <c>False</c></param>
        /// <param name="baPersonIDTargetPerson">The id of the person who has to get the address from another person</param>
        /// <param name="nameTargetPerson">The name of the person who has to get the address from another person</param>
        /// <param name="baAdresseIDSourcePerson">The id of the address which has to be copied to the target person</param>
        /// <param name="addressSourcePerson">The written address which has to be copied to the target person</param>
        /// <exception cref="Exception">Any exception can be thrown when executing sql-code</exception>
        /// <returns><c>True</c> if action could be completed successfully, <c>False</c> if flag has to be (re)set to <c>False</c> for 'Gleicher Haushalt'</returns>
        public static bool HandleGleicherHaushaltFlagSet(
            bool columnModified,
            bool isGleicherHaushalt,
            int baPersonIDTargetPerson,
            string nameTargetPerson,
            int baAdresseIDSourcePerson,
            string addressSourcePerson)
        {
            // validate modification first
            if (!columnModified)
            {
                // no modification, no reset of flag required
                return true;
            }

            // validate and confirm changes
            if (!isGleicherHaushalt ||
                baPersonIDTargetPerson < 1 ||
                baAdresseIDSourcePerson < 1 ||
                /* confirm */
                !KissMsg.ShowQuestion(CLASSNAME,
                                      "SetGleicherHaushalt",
                                      "Soll für '{0}' die Adresse '{1}' gesetzt werden?", 0, 0, true, nameTargetPerson, addressSourcePerson))
            {
                // not same houshold or user did not confirm question, remove flag
                return false;
            }

            // validate addresses first
            int countInvalid = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                DECLARE @DatumVon DATETIME;
                DECLARE @DatumBis DATETIME;

                DECLARE @BaPersonID INT;
                DECLARE @BaAdresseID INT;

                SET @BaPersonID = {0};
                SET @BaAdresseID = {1};

                SELECT @DatumVon = ADR.DatumVon,
                       @DatumBis = ADR.DatumBis
                FROM BaAdresse ADR
                WHERE BaAdresseID = @BaAdresseID ;

                SELECT COUNT(1)
                FROM dbo.BaAdresse
                WHERE BaPersonID = @BaPersonID
                  AND AdresseCode = 1   -- wohnsitz
                  AND (CASE
                        -- Wenn beide Daten des aktuellen Datensatzes leer sind, dann darf kein anderer Datensatz existieren
                        WHEN @DatumVon IS NULL AND @DatumBis IS NULL
                          THEN 1

                        -- Wenn Datum von nicht leer ist, DatumBis aber leer ist, dann darf es kein anderer Datensatz geben, bei welchem ein Datum grösser als das DatumVon des aktuellen Datensatzes ist
                        WHEN @DatumVon IS NOT NULL AND @DatumBis IS NULL
                          THEN CASE
                                 WHEN DatumVon >= @DatumVon OR DatumBis >= @DatumVon THEN 1
                                 ELSE 0
                               END

                        -- Wenn Datum bis nicht leer ist, DatumVon aber leer ist, dann darf es kein anderer Datensatz geben, bei welchem ein Datum kleiner als das DatumBis des aktuellen Datensatzes ist
                        WHEN @DatumVon IS NULL AND @DatumBis IS NOT NULL
                          THEN CASE
                                 WHEN DatumVon <= @DatumVon OR DatumBis <= @DatumVon THEN 1
                                 ELSE 0
                               END

                        -- sonst darf es keine Überschneidungen geben
                        ELSE CASE
                               WHEN (DatumVon <= @DatumBis AND DatumBis IS NULL) OR
                                    (DatumBis >= @DatumVon AND DatumVon IS NULL) OR
                                    (DatumBis >= @DatumVon AND DatumBis <= @DatumBis) OR
                                    (DatumVon >= @DatumVon AND DatumVon <= @DatumBis)
                                 THEN 1
                               ELSE 0
                             END
                      END) = 1;", baPersonIDTargetPerson, baAdresseIDSourcePerson));

            if (countInvalid > 0)
            {
                throw new KissInfoException(KissMsg.GetMLMessage(CLASSNAME,
                                                                 "AdressenBereinigen",
                                                                 "Die Adresse kann nicht übernommen werden.\r\n\r\nBereinigen Sie bitte zuerst die Adressen von '{0}'.",
                                                                 nameTargetPerson));
            }

            // DatumBis von der alte Adresse setzen wenn es noch NULL ist
            SqlQuery qryAdresse = DBUtil.OpenSQL(@"
                SELECT TOP 1
                       ADR.BaAdresseID,
                       ADR.DatumBis
                FROM dbo.BaAdresse ADR
                WHERE ADR.BaPersonID = {0}
                ORDER BY ADR.DatumVon DESC;", baPersonIDTargetPerson);

            // do this within a transaction
            Session.BeginTransaction();

            try
            {
                // new history version
                DBUtil.NewHistoryVersion();

                if (DBUtil.IsEmpty(qryAdresse[DBO.BaAdresse.DatumBis]))
                {
                    // close address
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE ADR
                        SET ADR.DatumBis = (SELECT DATEADD(d, -1, SADR.DatumVon)
                                            FROM dbo.BaAdresse SADR
                                            WHERE SADR.BaAdresseID = {0}),
                            ADR.Modifier = {2},
                            ADR.Modified = GETDATE()
                        FROM dbo.BaAdresse ADR
                        WHERE ADR.BaAdresseID = {1};",
                        baAdresseIDSourcePerson,
                        qryAdresse[DBO.BaAdresse.BaAdresseID],
                        DBUtil.GetDBRowCreatorModifier());
                }

                // add new address (copy)
                DBUtil.ExecSQLThrowingException(@"
                    INSERT INTO dbo.BaAdresse (BaPersonID, BaLandID, DatumVon, DatumBis, AdresseCode, CareOf, Zusatz,
                                               ZuhandenVon, Strasse, HausNr, Postfach, PostfachOhneNr, PLZ, Ort,
                                               OrtschaftCode, Kanton, Bezirk, Bemerkung, PlatzierungsartCode,
                                               WohnStatusCode, WohnungsgroesseCode,
                                               Creator, Created, Modifier, Modified)
                      SELECT BaPersonID          = {0},
                             BaLandID            = ADR.BaLandID,
                             DatumVon            = ADR.DatumVon,
                             DatumBis            = ADR.DatumBis,
                             AdresseCode         = ADR.AdresseCode, --> should always be '1'=wohnsitz
                             CareOf              = ADR.CareOf,
                             Zusatz              = ADR.Zusatz,
                             ZuhandenVon         = ADR.ZuhandenVon,
                             Strasse             = ADR.Strasse,
                             HausNr              = ADR.HausNr,
                             Postfach            = ADR.Postfach,
                             PostfachOhneNr      = ADR.PostfachOhneNr,
                             PLZ                 = ADR.PLZ,
                             Ort                 = ADR.Ort,
                             OrtschaftCode       = ADR.OrtschaftCode,
                             Kanton              = ADR.Kanton,
                             Bezirk              = ADR.Bezirk,
                             Bemerkung           = ADR.Bemerkung,
                             PlatzierungsartCode = ADR.PlatzierungsartCode,
                             WohnStatusCode      = ADR.WohnStatusCode,
                             WohnungsgroesseCode = ADR.WohnungsgroesseCode,
                             Creator             = {2},
                             Created             = GETDATE(),
                             Modifier            = {2},
                             Modified            = GETDATE()
                      FROM dbo.BaAdresse ADR
                      WHERE ADR.BaAdresseID = {1};",
                    baPersonIDTargetPerson,
                    baAdresseIDSourcePerson,
                    DBUtil.GetDBRowCreatorModifier());

                // successfully applied changes for same household
                Session.Commit();

                // success
                return true;
            }
            catch (Exception)
            {
                // do rollback transaction
                Session.Rollback();

                // throw exception further on
                throw;
            }
        }

        /// <summary>
        /// Handles the ReceiveMessage for the CtlBaPerson mask
        /// </summary>
        /// <param name="parameters">The parameters of the message</param>
        /// <param name="tabControl">The tab control to change the tabPage from</param>
        /// <param name="tpgAdresse">The address tabPage</param>
        /// <param name="ctlAdresse">the <see cref="CtlBaPersonAdresse"/> control to select the address from</param>
        /// <returns><c>true</c> if the message could be handled</returns>
        public static bool ReceiveMessageBaPerson(HybridDictionary parameters, KissTabControlEx tabControl, TabPageEx tpgAdresse, CtlBaPersonAdresse ctlAdresse)
        {
            if (parameters == null)
            {
                return false;
            }

            var result = false;

            if (parameters.Contains("Tab"))
            {
                if (parameters["Tab"].ToString() == "Adressen" && parameters.Contains("BaAdresseID"))
                {
                    tabControl.SelectTab(tpgAdresse);
                    var baAdresseId = Convert.ToInt32(parameters["BaAdresseID"]);
                    result = ctlAdresse.SelectBaAdresse(baAdresseId);
                }
            }

            return result;
        }

        #endregion

        #endregion
    }
}