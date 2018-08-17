using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using KiSS.DBScheme;
using KiSS4.DB;

namespace KiSS4.Common
{
    /// <summary>
    /// Util-Klasse für die Klientenbuchhaltung
    /// </summary>
    public class KliBuUtil
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// Select statement für die Konstenarten-Abfrage (KliBu). Wird auch in der Controlling-Maske verwendet.
        /// Folgende Control-Name und Parameter werden in der Controlling-Maske auch ersetzt:
        ///     - {edtDatumVonX}
        ///     - {edtDatumBisX}
        ///     - {edtKostenartNrVon}
        ///     - {edtKostenartNrBis}
        ///     - {0}
        /// Achtung beim Umbenennen eines Control auf der Maske!
        /// </summary>
        public const string SELECT_KOSTENARTEN = @"
            SELECT BaPersonID$  = KOS.BaPersonID,
                   BelegNr      = BUC.Belegnr,
                   Datum        = BUC.BelegDatum,
                   Buchungtext  = KOS.Buchungstext,
                   Mitarbeiter  = USR.LogonName,
                   Gegenkonto   = BGK.KontoNr,
                   Kostenart    = BGK.Name,
                   Kostenstelle = dbo.fnKbGetKostenstelle(KST.BaPersonID),
                   Betrag       = CASE WHEN BUC.SollKtoNr IS NULL THEN KOS.Betrag ELSE -KOS.Betrag END
            FROM dbo.fnKbGetRelevanteBuchungen({0}, NULL, NULL, 0, 0) REB -- KbPeriodeID aus FormKlibu (FormController)
              INNER JOIN dbo.KbBuchungKostenart      KOS WITH(READUNCOMMITTED) ON KOS.KbBuchungKostenartID = REB.KbBuchungKostenartID
              INNER JOIN dbo.KbBuchung               BUC WITH(READUNCOMMITTED) ON BUC.KbBuchungID = KOS.KbBuchungID
              LEFT  JOIN dbo.XUser                   USR WITH(READUNCOMMITTED) ON USR.UserID = BUC.ErstelltUserID -- es hat leider (noch)nicht jede Buchungen einen Ersteller
              INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH(READUNCOMMITTED) ON KST.KbKostenstelleID = KOS.KbKostenstelleID
                                                                              AND (BUC.BelegDatum BETWEEN KST.DatumVon AND ISNULL(KST.DatumBis, '99991231'))
              INNER JOIN dbo.BgKostenart             BGK WITH(READUNCOMMITTED) ON BGK.BgKostenartID = KOS.BgKostenartID
            WHERE BUC.BelegNr IS NOT NULL
              AND REB.Ausgabe = 1
              AND BUC.BelegDatum IS NOT NULL
              AND KOS.Betrag <> 0       -- Ticket 2703
            --- AND dbo.fnDateOf(BUC.BelegDatum) >= {edtDatumVonX}
            --- AND dbo.fnDateOf(BUC.BelegDatum) <= {edtDatumBisX}
            --- AND RIGHT(REPLICATE('0', 10) + BGK.KontoNr, 10) >= RIGHT(REPLICATE('0', 10) + {edtKostenartNrVon}, 10) -- '0' am Anfang setzen sonst ist '11' groesser als '100'
            --- AND RIGHT(REPLICATE('0', 10) + BGK.KontoNr, 10) <= RIGHT(REPLICATE('0', 10) + {edtKostenartNrBis}, 10)
            ORDER BY BUC.BelegDatum ASC;";

        /// <summary>
        /// Select statement für die Sozialhilfe-Abfrage (KliBu). Wird auch in der Controlling-Maske verwendet.
        /// Folgende Control-Name und Parameter werden in der Controlling-Maske auch ersetzt:
        ///     - {edtDatumVonX}
        ///     - {edtDatumBisX}
        ///     - {0}
        ///     - {1}
        /// Achtung beim Umbenennen eines Control auf der Maske!
        /// </summary>
        public const string SELECT_SOZIALHILFERECHNUNG = @"
            /*
            TOREMEMBER:
             - Filter auf Konto --> z.T. KontoNr drin (Parent, aber auch direkte)
            */

            DECLARE @DatumVon DATETIME
            DECLARE @DatumBis DATETIME
            DECLARE @KbPeriodeID INT
            DECLARE @nurOhneGemeinde BIT
            DECLARE @LanguageCode INT

            SET @KbPeriodeID  = {0}  --32--
            SET @LanguageCode = {1} --1--
            ---SET @DatumVon  = {edtDatumVonX}
            ---SET @DatumBis  = {edtDatumBisX}
            ---SET @nurOhneGemeinde = {edtNurOhneGemeindeX}

            IF (@DatumVon IS NULL)
            BEGIN
              SELECT @DatumVon = PER.PeriodeVon
              FROM dbo.KbPeriode PER WITH(READUNCOMMITTED)
              WHERE PER.KbPeriodeID = @KbPeriodeID
            END

            IF (@DatumBis IS NULL)
            BEGIN
              SELECT @DatumBis = PER.PeriodeBis
              FROM dbo.KbPeriode PER WITH(READUNCOMMITTED)
              WHERE PER.KbPeriodeID = @KbPeriodeID
            END

            SET @nurOhneGemeinde = ISNULL(@nurOhneGemeinde, 0)

            DECLARE @ZeitraumString VARCHAR(100)
            SET @ZeitraumString = dbo.fnGetZeitraumString(@DatumVon, @DatumBis)

            DECLARE @tmpSummen  TABLE
            (
              KbKostenstelleID     INT,
              BaWVCode             INT,
              KbBuchungKostenartID INT         NULL,
              KbBuchungID          INT         NULL,
              SollKtoNr            VARCHAR(10) NOT NULL,
              HabenKtoNr           VARCHAR(10) NOT NULL,
              Betrag               MONEY,
              Ausgabe              BIT,
              GemeindeCode         INT,
              HasBgKostenart       BIT
            )

            DECLARE @tmp TABLE
            (
              KbKostenstelleID   int,
              BaWVCode           int,
              KbKontoID          int,
              GruppeKontoID      int,
              Kontogruppe        bit,
              KbKontoklasseCode  int,
              KontoNr            varchar(50),
              KontoName          varchar(150),
              Aufwand            money,
              Ertrag             money,
              GemeindeCode       INT,
              HasBgKostenart     BIT
            )

            INSERT INTO @tmpSummen (KbKostenstelleID, BaWVCode, SollKtoNr, HabenKtoNr, Betrag, GemeindeCode, HasBgKostenart)
              SELECT BKO.KbKostenstelleID,
                     BaWVCode   = WVC.BaWVCode,
                     TMP.SollKtoNr,
                     TMP.HabenKtoNr,
                     SUM(CASE
                           WHEN dbo.fnDateOf(BUC.BelegDatum) BETWEEN dbo.fnDateOf(WVC.DatumVon) AND dbo.fnDateOf(ISNULL(WVC.DatumBis, '99990101')) THEN TMP.Betrag
                           WHEN WVC.BaWVCodeID IS NULL THEN TMP.Betrag
                           ELSE $0
                         END),
                     TMP.GemeindeCode,
                     HasBgKostenart = CASE WHEN KOA.BgKostenartID IS NOT NULL THEN 1 ELSE 0 END
              FROM dbo.fnKbGetRelevanteBuchungen(@KbPeriodeID, @DatumVon, @DatumBis, 0, 1) TMP
                INNER JOIN dbo.KbBuchungKostenart      BKO WITH (READUNCOMMITTED) ON BKO.KbBuchungKostenartID = TMP.KbBuchungKostenartID
                INNER JOIN dbo.KbBuchung               BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BKO.KbBuchungID
                INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH (READUNCOMMITTED) ON KST.KbKostenstelleID = BKO.KbKostenstelleID
                                                                                 AND (KST.DatumBis IS NULL OR GetDate() BETWEEN KST.DatumVon AND KST.DatumBis)
                LEFT  JOIN dbo.BaWVCode                WVC WITH (READUNCOMMITTED) ON WVC.BaPersonID = KST.BaPersonID
                                                                                 AND dbo.fnDateOf(BUC.BelegDatum) BETWEEN WVC.DatumVon AND IsNull(WVC.DatumBis, '99991231')
                LEFT  JOIN dbo.BgKostenart             KOA WITH (READUNCOMMITTED) ON KOA.KontoNr = TMP.SollKtoNr OR KOA.KontoNr = TMP.HabenKtoNr
              WHERE 1 = 1
                AND dbo.fnDateOf(BUC.BelegDatum) BETWEEN @DatumVon AND @DatumBis
                --- AND (@nurOhneGemeinde = 1 OR TMP.GemeindeCode = {edtZustaendigeGemeindeX})
                AND (@nurOhneGemeinde = 0 OR TMP.GemeindeCode IS NULL)
              GROUP BY BKO.KbKostenstelleID, WVC.BaWVCode, TMP.SollKtoNr, TMP.HabenKtoNr, TMP.GemeindeCode, CASE WHEN KOA.BgKostenartID IS NOT NULL THEN 1 ELSE 0 END

            INSERT @tmp
              SELECT TMP.KbKostenstelleID,
                     BaWVCode = CASE
                                  WHEN KTO.KontoNr IN ('680', '682', '780', '782') THEN 9999
                                  ELSE TMP.BaWVCode
                                END,
                     KTO.KbKontoID,
                     KTO.GruppeKontoID,
                     KTO.Kontogruppe,
                     KTO.KbKontoklasseCode,
                     KTO.KontoNr,
                     KTO.KontoName,
                     Aufwand = CASE
                                 WHEN KTO.KbKontoKlasseCode <> 3   THEN $0
                                 WHEN TMP.SollKtoNr  = KTO.KontoNr THEN Betrag
                                 WHEN TMP.HabenKtoNr = KTO.KontoNr THEN -Betrag
                                 ELSE $0
                               END,
                     Ertrag  = CASE
                                 WHEN KTO.KbKontoKlasseCode <> 4   THEN $0
                                 WHEN TMP.HabenKtoNr = KTO.KontoNr THEN Betrag
                                 WHEN TMP.SollKtoNr  = KTO.KontoNr THEN -Betrag
                                 ELSE $0
                               END,
                     TMP.GemeindeCode,
                     TMP.HasBgKostenart
              FROM dbo.KbKonto        KTO WITH(READUNCOMMITTED)
                INNER JOIN @tmpSummen TMP ON TMP.SollKtoNr = KTO.KontoNr OR TMP.HabenKtoNr = KTO.KontoNr
              WHERE KTO.KbPeriodeID = @KbPeriodeID

            -- output
            SELECT
                Personalien             = PRS.NameVorname
                                          + IsNull(' ,' + CONVERT(varchar, DATEPART(YEAR, Geburtsdatum)), '')
                                          + CASE WHEN PRS.NationalitaetCode = 147 THEN IsNull(' ,' + PRS.Heimatort, '')  -- bei CH Heimatort
                                                 ELSE IsNull(' ,' + PRS.Nationalitaet, '') -- bei Ausländern Nationalität
                                            END
                                          + IsNull(' ,' + CONVERT(varchar, ZuzugKtDatum, 104), ''),
                Bezugsgroesse           = dbo.fnLOVText('BaWVCode', TMP.BaWVCode),
                AnzahlDossiers          = IsNull((SELECT TOP 1 FT = CASE WHEN BPP.BaPersonID = LST.BaPersonID THEN 1 ELSE 0 END
                                             FROM dbo.BgFinanzplan_BaPerson BPP WITH (READUNCOMMITTED)
                                               INNER JOIN dbo.BgFinanzplan  BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BPP.BgFinanzplanID
                                               INNER JOIN dbo.FaLeistung    LST WITH (READUNCOMMITTED) ON LST.FaLeistungID = BFP.FaLeistungID
                                               INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH (READUNCOMMITTED) ON KST.BaPersonID = BPP.BaPersonID
                                                                                                  AND (KST.DatumBis IS NULL OR GetDate() BETWEEN KST.DatumVon AND KST.DatumBis)
                                             WHERE BPP.IstUnterstuetzt = 1
                                               AND KST.KbKostenstelleID = TMP.KbKostenstelleID
                                               AND (BFP.DatumVon BETWEEN @DatumVon AND @DatumBis
                                                OR  BFP.DatumBis BETWEEN @DatumVon AND @DatumBis
                                                OR  (BFP.DatumVon <= @DatumVon AND BFP.DatumBis >= @DatumBis))
                                             ORDER BY BFP.DatumVon DESC), 0),
                AnzahlPersonen          = 1,

                Aufwand                    = SUM(IsNull(Aufwand, 0)),
                AufwandSHR                 = SUM(CASE WHEN TMP.HasBgKostenart = 1 THEN IsNull(Aufwand, 0) ELSE 0 END),
                Ertrag                     = SUM(IsNull(Ertrag, 0)),
                ErtragSHR                  = SUM(CASE WHEN TMP.HasBgKostenart = 1 THEN IsNull(Ertrag, 0) ELSE 0 END),
                ErtraegeInkassoprivileg    = SUM(CASE WHEN PAR.KontoNr = '4360.301' THEN IsNull(Ertrag,0) ELSE 0 END), -- laut Maskendefinition
                ErtraegeSHRInkassoprivileg = SUM(CASE WHEN TMP.HasBgKostenart = 1 AND PAR.KontoNr = '4360.301' THEN IsNull(Ertrag,0) ELSE 0 END), -- laut Maskendefinition
                UebrigeErtraege            = SUM(CASE WHEN PAR.KontoNr NOT IN ('4360.301', '4360.303') THEN IsNull(Ertrag,0) ELSE 0 END), -- alle andere Erträge
                UebrigeErtraegeSHR         = SUM(CASE WHEN TMP.HasBgKostenart = 1 AND PAR.KontoNr NOT IN ('4360.301', '4360.303') THEN IsNull(Ertrag,0) ELSE 0 END), -- alle andere Erträge
                ErtraegeHeimatliche        = SUM(CASE WHEN PAR.KontoNr = '4360.303' THEN IsNull(Ertrag,0) ELSE 0 END), -- laut Maskendefinition
                ErtraegeSHRHeimatliche     = SUM(CASE WHEN TMP.HasBgKostenart = 1 AND PAR.KontoNr = '4360.303' THEN IsNull(Ertrag,0) ELSE 0 END), -- laut Maskendefinition
                ErtragSHRInkassoUebrig     = SUM(CASE WHEN TMP.HasBgKostenart = 1 AND PAR.KontoNr NOT IN ('4360.303') THEN IsNull(Ertrag,0) ELSE 0 END), -- ErtraegeInkassoprivileg + UebrigeErtraege

                MonatlichAlimente       = IsNull((SELECT TOP 1 POS.TotalAliment
                                               FROM dbo.IkPosition POS WITH (READUNCOMMITTED)
                                               WHERE POS.ALBVBerechtigt = 1
                                                 AND POS.Datum BETWEEN @DatumVon AND @DatumBis
                                                 AND POS.BaPersonID = PRS.BaPersonID
                                               ORDER BY POS.Datum DESC), $0),
                Bevorschussung          = SUM(CASE WHEN BaWVCode = 9999 AND TMP.KontoNr = '680' THEN IsNull(Aufwand,0)  ELSE 0 END),--SUM(CASE WHEN KTO.KontoNr IN ('680') THEN IsNull(Ertrag,0) ELSE 0 END), -- laut Maskendefinition--
                Inkassikosten           = SUM(CASE WHEN BaWVCode = 9999 AND TMP.KontoNr IN ('682') THEN IsNull(Aufwand,0)
                                                   WHEN BaWVCode = 9999 AND TMP.KontoNr IN ('782') THEN IsNull(-Ertrag,0)
                                                   ELSE 0
                                                END), -- laut Maskendefinition
                Rueckerstattung          = SUM(CASE WHEN BaWVCode = 9999 AND TMP.KontoNr IN ('780') THEN IsNull(Ertrag,0) ELSE 0 END), -- laut Maskendefinition
                Netto                    = $0, -- wird im code berechnet (Bevorschussung + Inkassikosten - Rueckerstattung)
                BaWVCode$                = TMP.BaWVCode,
                BaPersonID$              = PRS.BaPersonID,
                DatumVonBis              = @ZeitraumString,
                Gemeinde                 = dbo.fnLOVMLText('GemeindeSozialdienst', TMP.GemeindeCode, @LanguageCode)
              FROM   @tmp                     TMP
                INNER JOIN dbo.KbKonto        KTO WITH(READUNCOMMITTED)
                                               ON KTO.KbKontoID = TMP.KbKontoID
                INNER JOIN dbo.KbKostenstelle_BaPerson KST WITH(READUNCOMMITTED)
                                               ON KST.KbKostenstelleID = TMP.KbKostenstelleID
                                               AND (KST.DatumBis IS NULL OR GetDate() BETWEEN KST.DatumVon AND KST.DatumBis)
                INNER JOIN dbo.vwPerson       PRS WITH(READUNCOMMITTED)
                                               ON PRS.BaPersonID = KST.BaPersonID
                LEFT  JOIN dbo.KbKonto        PAR WITH(READUNCOMMITTED)
                                               ON PAR.KbKontoID = KTO.GruppeKontoID -- Parent-Konto
            WHERE  1 = 1
              AND KTO.KbKontoklasseCode IN (3, 4) -- Aufwand, Ertrag
            GROUP BY
              PRS.BaPersonID, TMP.KbKostenstelleID, TMP.BaWVCode, TMP.GemeindeCode,
              -- Personalien
              PRS.NameVorname
              + IsNull(' ,' + CONVERT(varchar, DATEPART(YEAR, Geburtsdatum)), '')
              + CASE WHEN PRS.NationalitaetCode = 147 THEN IsNull(' ,' + PRS.Heimatort, '')  -- bei CH Heimatort
                     ELSE IsNull(' ,' + PRS.Nationalitaet, '') -- bei Ausländern Nationalität
                END
              + IsNull(' ,' + CONVERT(varchar, ZuzugKtDatum, 104), '')
            ORDER BY Personalien
            ";

        #endregion

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "KliBuUtil";

        #endregion

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Prüfen ob Belege von der Folgeperiode importiert werden sollen.
        /// </summary>
        /// <param name="rows">Belege zu importieren</param>
        /// <param name="kbPeriodeId">ID der aktuelle Periode</param>
        /// <param name="kbFolgeperiodeId">ID der Folgeperiode</param>
        /// <returns><c>true</c> wenn die Belege (von aktuelle und folge Periode) importiert werden können. Sonst <c>false</c></returns>
        public static bool CheckImportBelegeOfFollowingPeriod(IEnumerable<DataRow> rows, int kbPeriodeId, int? kbFolgeperiodeId)
        {
            if (!kbFolgeperiodeId.HasValue)
            {
                return true;
            }

            // hat Belege von Folgperiode
            if (rows.Any(row => Utils.ConvertToInt(row[DBO.KbBuchung.KbPeriodeID]) == kbFolgeperiodeId.Value))
            {
                var qryPerioden = DBUtil.OpenSQL(
                    @"SELECT KbPeriodeID,
                             Periodenjahr = CASE WHEN YEAR(PeriodeVon) = YEAR(PeriodeBis)
                                              THEN CONVERT(VARCHAR, YEAR(PeriodeVon))
                                              ELSE CONVERT(VARCHAR, YEAR(PeriodeVon)) + '-' + CONVERT(VARCHAR, YEAR(PeriodeBis))
                                            END
                      FROM dbo.KbPeriode WITH(READUNCOMMITTED)
                      WHERE KbPeriodeID IN ({0}, {1});",
                    kbPeriodeId,
                    kbFolgeperiodeId.Value);

                qryPerioden.Find(string.Format("{0} = {1}", DBO.KbPeriode.KbPeriodeID, kbPeriodeId));
                var jahr = qryPerioden["Periodenjahr"];
                qryPerioden.Find(string.Format("{0} = {1}", DBO.KbPeriode.KbPeriodeID, kbFolgeperiodeId.Value));
                var folgejahr = qryPerioden["Periodenjahr"];

                // sollen Belege von der Folgeperiode auch importiert werden?
                return KissMsg.ShowQuestion(
                    CLASSNAME,
                    "BelegeFolgeperiodeImportieren",
                    "Es werden Belege vom Folgejahr {0} importiert. Sind Sie sicher, dass diese Belege ins aktuelle Jahr {1} importiert werden sollen?",
                    0,
                    0,
                    false,
                    folgejahr,
                    jahr);
            }

            return true;
        }

        /// <summary>
        /// Prüfen ob Belege mit BelegNr von anderen Perioden importiert werden sollen.
        /// </summary>
        /// <param name="rows">Belege zu importieren</param>
        /// <param name="kbPeriodeId">ID der aktuelle Periode</param>
        /// <returns><c>true</c> wenn alle Belege importiert werden können. Sonst <c>false</c></returns>
        public static bool CheckImportBelegeWithBelegNrOfOtherPeriod(IEnumerable<DataRow> rows, int kbPeriodeId)
        {
            // hat Belege von Folgperiode
            if (rows.Any(row => Utils.ConvertToInt(row[DBO.KbBuchung.KbPeriodeID]) != kbPeriodeId && !DBUtil.IsEmpty(row[DBO.KbBuchung.BelegNr])))
            {
                var jahr = Utils.ConvertToString(DBUtil.ExecuteScalarSQLThrowingException(
                    @"SELECT Periodenjahr = CASE WHEN YEAR(PeriodeVon) = YEAR(PeriodeBis)
                                              THEN CONVERT(VARCHAR, YEAR(PeriodeVon))
                                              ELSE CONVERT(VARCHAR, YEAR(PeriodeVon)) + '-' + CONVERT(VARCHAR, YEAR(PeriodeBis))
                                            END
                      FROM dbo.KbPeriode WITH(READUNCOMMITTED)
                      WHERE KbPeriodeID = {0};",
                    kbPeriodeId));

                // sollen Belege von der Folgeperiode auch importiert werden?
                return KissMsg.ShowQuestion(
                    CLASSNAME,
                    "BelegeMitBelegNrAusAnderenPeriodenImportieren",
                    "Es werden Belege mit BelegNr von anderen Perioden importiert. Sind Sie sicher, dass diese Belege ins aktuelle Jahr {0} importiert werden sollen?",
                    0,
                    0,
                    false,
                    jahr);
            }

            return true;
        }

        /// <summary>
        /// Gibt die ID der Folgeperiode
        /// </summary>
        /// <param name="kbPeriodeId">ID der aktuelle Periode</param>
        /// <returns>ID der Folgeperiode oder <c>null</c> wenn keine Folgeperiode vorhanden ist</returns>
        public static int? GetFolgeperiodeId(int kbPeriodeId)
        {
            return DBUtil.ExecuteScalarSQL(@"
                DECLARE @PeriodeBisDatum DATETIME;
                DECLARE @KbMandantID INT;

                SELECT
                  @PeriodeBisDatum = PeriodeBis,
                  @KbMandantID = KbMandantID
                FROM dbo.KbPeriode
                WHERE KbPeriodeID = {0};

                SELECT TOP 1 KbPeriodeID
                FROM dbo.KbPeriode
                WHERE KbMandantID = @KbMandantID
                  AND PeriodeVon > @PeriodeBisDatum
                ORDER BY PeriodeVon DESC;",
                kbPeriodeId) as int?;
        }

        /// <summary>
        /// Gets the id of a given belegkreisCode of a periode
        /// </summary>
        /// <param name="kbPeriodeId">the id of the periode</param>
        /// <param name="kbBelegKreisCode">the belegkreis code to get the id from</param>
        /// <param name="kontoNr">the kontoNr is needed for kbBelegKreisCode = 1 (Aktivkonto)</param>
        /// <returns>the id of KbBelegKreis</returns>
        public static int? GetKbBelegKreisId(int kbPeriodeId, int kbBelegKreisCode, string kontoNr = null)
        {
            return DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT KbBelegKreisID
                FROM dbo.KbBelegKreis BLK WITH (READUNCOMMITTED)
                WHERE BLK.KbPeriodeID = {0}
                  AND BLK.KbBelegKreisCode = {1}
                  AND ISNULL(BLK.KontoNr, '') = ISNULL({2}, '');",
                kbPeriodeId,
                kbBelegKreisCode,
                kontoNr) as int?;
        }

        /// <summary>
        /// Gibt die ID der Vorperiode
        /// </summary>
        /// <param name="kbPeriodeId">ID der aktuelle Periode</param>
        /// <returns>ID der Vorperiode oder <c>null</c> wenn keine Vorperiode vorhanden ist</returns>
        public static int? GetVorperiodeId(int kbPeriodeId)
        {
            return DBUtil.ExecuteScalarSQL(@"
                DECLARE @PeriodeVonDatum DATETIME;
                DECLARE @KbMandantID INT;

                SELECT
                  @PeriodeVonDatum = PeriodeVon,
                  @KbMandantID = KbMandantID
                FROM dbo.KbPeriode
                WHERE KbPeriodeID = {0};

                SELECT TOP 1 KbPeriodeID
                FROM dbo.KbPeriode
                WHERE KbMandantID = @KbMandantID
                  AND PeriodeBis < @PeriodeVonDatum
                ORDER BY PeriodeVon DESC;",
                kbPeriodeId) as int?;
        }

        /// <summary>
        /// Zum überprüfen ob das Belegdatum in der Periode gültig ist.
        /// </summary>
        /// <param name="kbPeriodeID">ID der Periode</param>
        /// <param name="belegDatum">Belegdatum zu überprüfen</param>
        /// <returns><c>True</c> wenn das BelegDatum in der Periode gültig ist, sonst <c>False</c></returns>
        public static bool HasValidBelegDatum(int kbPeriodeID, DateTime? belegDatum)
        {
            return Convert.ToBoolean(DBUtil.ExecuteScalarSQLThrowingException(
                    @"SELECT dbo.fnKbCheckBelegDatum ({0}, {1});",
                    kbPeriodeID,
                    belegDatum));
        }

        #endregion

        #endregion
    }
}