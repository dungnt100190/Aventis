using Kiss.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using KiSS4.DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiSS4.Sozialhilfe.Test
{
    [TestClass]
    public class GruenstellenTest
    {
        #region Fields

        #region Private Fields

        private int _userid;

        #endregion

        #endregion

        #region Test Methods

        [TestInitialize]
        [TestCategory("LongRunning")]
        public void SetupDb()
        {
            // Use the reference because the assemblies were not copied when running on TeamCity
            Container.RegisterType<ISessionService, SessionService>();

            //Env env = new Env(".: KiSS_ZH_DEV_R4519 (szhm9301) :.", EnvType.Dev, "server=szhm9301;initial catalog=KiSS_ZH_DEV_R4519;user id=kiss_tfs;password=kiss2012;");
            Env env = new Env(".: KiSS_ZH_Test (bisrv1029/schinti) :.", EnvType.Dev, @"server=bisrv1029\a99tdbse02;initial catalog=KiSS_ZH_Test;user id=kiss_tfs;password=kiss2012;");

            // do login with given values
            Session.Open(env, "diag_admin", "Ki$$2013");

            // check if success
            if (!Session.Active)
            {
                // failed, set focus to username
                Assert.IsTrue(false, "Unable to connect to the DB.");
            }

            _userid = Session.User.UserID;

            // Clean up
            DBUtil.ExecSQLThrowingException(@"
                BEGIN TRY
                  DROP PROCEDURE dbo.spTmpCreateFallAndFinanzplan
                END TRY
                BEGIN CATCH
                END CATCH

                BEGIN TRY
                  DROP PROCEDURE dbo.spTmpCheckGSRResult
                END TRY
                BEGIN CATCH
                END CATCH

                BEGIN TRY
                  DROP TABLE #Netto_Erwartet
                END TRY
                BEGIN CATCH
                END CATCH

                BEGIN TRY
                  DROP TABLE #Brutto_Erwartet
                END TRY
                BEGIN CATCH
                END CATCH");

            // Create helper-SPs
            DBUtil.ExecSQLThrowingException(@"
            CREATE PROCEDURE dbo.spTmpCreateFallAndFinanzplan
            (
              @UE             INT,
              @Bezeichnung    VARCHAR(100),
              @UserID         INT,
              @BetragMiete    MONEY,
              @BetragKVG      MONEY,
              @BgFinanzplanID INT OUT
            )
            AS BEGIN
              IF @UE < 1 OR @UE > 20 RETURN

              DECLARE @BaPersonID_FT_LT INT,
              @BaPersonID       INT,
              @FaFallID         INT,
              @FaLeistungID     INT,
              @PersonNr         INT,
              @DatumVon         DATETIME,
              @DatumBis         DATETIME,
              @DatumFrueh       DATETIME,
              @CreatorModifier  VARCHAR(50);

              SET @DatumVon   = dbo.fnFirstDayOf(GETDATE());
              SET @DatumBis   = dbo.fnLastDayOf(DATEADD(m,6,@DatumVon));
              SET @DatumFrueh = dbo.fnDateSerial(1950,1,1);
              SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());

              -- LT erstellen
              INSERT INTO dbo.BaPerson ([Name], [Vorname], Geburtsdatum, Creator, Created, Modifier, Modified)
              VALUES ('UnitTest', @Bezeichnung, @DatumFrueh, @CreatorModifier, GETDATE(), @CreatorModifier, GETDATE())
              SET @BaPersonID_FT_LT = SCOPE_IDENTITY()

              INSERT INTO BaWVCode (BaPersonID, DatumVon, WVCode, BaBedID)
              VALUES (@BaPersonID_FT_LT, @DatumFrueh, 3, 16026)

              INSERT INTO BaAdresse (BaPersonID, AdresseCode, DatumVon, Strasse, HausNr, PLZ, Ort, Kanton, BaLandID)
              VALUES (@BaPersonID_FT_LT, 1, @DatumFrueh, 'Teststrasse', '99z', 9000, 'Testenhausen', 'ZZ', 147)

              INSERT INTO BaZahlungsweg (BaPersonID, DatumVon, EinzahlungsscheinCode, ZahlinformationAktiv, IBANNummer, PostKontoNummer)
              VALUES (@BaPersonID_FT_LT, @DatumFrueh, 2, 1, 'CH3309000000462980261', 462980261)

              -- Fall/Leistung erstellen
              INSERT INTO FaFall(BaPersonID, UserID, DatumVon)
              VALUES (@BaPersonID_FT_LT, @UserID, @DatumVon)
              SET @FaFallID = SCOPE_IDENTITY()

              INSERT INTO FaLeistung(FaFallID, ModulID, FaProzessCode, BaPersonID, UserID, DatumVon, Creator, Created, Modifier, Modified)
              VALUES (@FaFallID, 2, 200, @BaPersonID_FT_LT, @UserID, @DatumVon, @CreatorModifier, GetDate(), @CreatorModifier, GetDate())

              INSERT INTO FaFallPerson (FaFallID, BaPersonID, DatumVon)
              VALUES (@FaFallID, @BaPersonID_FT_LT, @DatumVon)

              INSERT INTO FaLeistung(FaFallID, ModulID, FaProzessCode, BaPersonID, UserID, DatumVon, Creator, Created, Modifier, Modified)
              VALUES (@FaFallID, 3, 300, @BaPersonID_FT_LT, @UserID, @DatumVon, @CreatorModifier, GetDate(), @CreatorModifier, GetDate())
              SET @FaLeistungID = SCOPE_IDENTITY()

              -- FP erstellen
              EXECUTE spWhFinanzplan_Create @FaLeistungID, @DatumVon, @DatumBis, 2
              SELECT TOP 1 @BgFinanzplanID = BgFinanzplanID
              FROM BgFinanzplan
              WHERE FaLeistungID = @FaLeistungID

              -- Ev weitere Mitglieder erstellen
              SET @PersonNr = 1
              WHILE (@PersonNr < @UE) BEGIN
            SET @PersonNr = @PersonNr + 1

            INSERT INTO dbo.BaPerson ([Name], [Vorname], Geburtsdatum, Creator, Created, Modifier, Modified)
            VALUES ('UnitTest', 'Mitglied ' + CAST(@PersonNr AS VARCHAR), dbo.fnDateSerial(1970,1,1), @CreatorModifier, GetDate(), @CreatorModifier, GetDate())
            SET @BaPersonID = SCOPE_IDENTITY()

            INSERT INTO BaWVCode (BaPersonID, DatumVon, WVCode, BaBedID)
            VALUES (@BaPersonID, @DatumFrueh, 3, 16026)

            INSERT INTO BaAdresse (BaPersonID, AdresseCode, DatumVon, Strasse, HausNr, PLZ, Ort, Kanton, BaLandID)
            VALUES (@BaPersonID, 1, @DatumFrueh, 'Teststrasse', '99z', 9000, 'Testenhausen', 'ZZ', 147)

            INSERT INTO FaFallPerson (FaFallID, BaPersonID, DatumVon)
            VALUES (@FaFallID, @BaPersonID, @DatumVon)

            INSERT INTO BgFinanzplan_BaPerson (BgFinanzplanID, BaPersonID, IstUnterstuetzt)
            VALUES (@BgFinanzplanID, @BaPersonID, 1)
              END

            --  EXECUTE spWhFinanzplan_Bewilligen @BgFinanzplanID, @DatumVon

              DECLARE @BgBudgetID_MasterBudget INT
              SELECT @BgBudgetID_MasterBudget = BgBudgetID
              FROM BgBudget
              WHERE BgFinanzplanID = @BgFinanzplanID
            AND MasterBudget = 1

              IF @BetragMiete IS NOT NULL AND @BetragMiete > 0 BEGIN
            UPDATE BPO
            SET Betrag       = @BetragMiete,
            MaxBeitragSD = @BetragMiete
            FROM BgPosition             BPO
              INNER JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
              INNER JOIN BgKostenart    BKA ON BKA.BgKostenartID    = BPA.BgKostenartID
            WHERE BPO.BgBudgetID = @BgBudgetID_MasterBudget
              AND BKA.KontoNr = '130'
              END

              IF @BetragKVG IS NOT NULL AND @BetragKVG > 0 BEGIN
            UPDATE BPO
            SET Betrag = @BetragKVG
            FROM BgPosition             BPO
              INNER JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
              INNER JOIN BgKostenart    BKA ON BKA.BgKostenartID    = BPA.BgKostenartID
            WHERE BPO.BgBudgetID = @BgBudgetID_MasterBudget
              AND BKA.KontoNr = '140'
              END

              UPDATE BgFinanzplan
              SET UnterschriftAntrag             = dbo.fnDateOf(GETDATE()),
              XDocumentID_Leistungsentscheid = 1
              WHERE BgFinanzplanID = @BgFinanzplanID

              EXECUTE spWhFinanzplan_Bewilligen @BgFinanzplanID, @DatumVon

              UPDATE BgFinanzplan
              SET BgBewilligungStatusCode = 5,
              DatumVon = GeplantVon,
              DatumBis = GeplantBis
              WHERE BgFinanzplanID = @BgFinanzplanID

              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgFinanzplanID = @BgFinanzplanID AND MasterBudget = 1

              EXECUTE dbo.spWhWVModifyUnits @FaFallID

            END");

            DBUtil.ExecSQLThrowingException(@"
            CREATE PROCEDURE dbo.spTmpCheckGSRResult
            (
              @BgBudgetID INT
            )
            AS BEGIN
              DECLARE @ErrorMsg VARCHAR(MAX);
              SET @ErrorMsg = '';

              SELECT @ErrorMsg = IsNull(dbo.ConcDistinct(char(13) + char(10) + 'Die erwartete Nettobuchung wurde nicht erzeugt: KontoNr ' + IsNull(SOLL.KontoNr,'(NULL)') +
                     ', Kat ' + IsNull(SOLL.PscdKennzeichen,'(NULL)') +
                     ', Pers ' + IsNull(CAST(IST.PersCount AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.PersCount AS VARCHAR),'(NULL)') +
                     ', BetragMin ' + IsNull(CAST(IST.BetragMin AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.BetragMin AS VARCHAR),'(NULL)') +
                     ', BetragMax ' + IsNull(CAST(IST.BetragMax AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.BetragMax AS VARCHAR),'(NULL)')),'')
              FROM (SELECT KBK.KontoNr, KBK.PscdKennzeichen, PersCount = Count(KBK.BaPersonID), BetragMin = MIN(KBK.Betrag), BetragMax = MAX(KBK.Betrag)
            FROM dbo.KbBuchungKostenart KBK
              INNER JOIN dbo.KbBuchung  KBU ON KBU.KbBuchungID = KBK.KbBuchungID AND KBU.BgBudgetID = @BgBudgetID
            GROUP BY KBK.KontoNr, KBK.PscdKennzeichen) IST
            RIGHT JOIN #Netto_Erwartet                     SOLL ON SOLL.KontoNr = IST.KontoNr AND SOLL.PscdKennzeichen = IST.PscdKennzeichen
              WHERE IST.KontoNr IS NULL OR IST.PersCount <> SOLL.PersCount OR IST.BetragMin <> SOLL.BetragMin OR IST.BetragMax <> SOLL.BetragMax

              SELECT @ErrorMsg = @ErrorMsg + IsNull(dbo.ConcDistinct(char(13) + char(10) + 'Die erzeugte Nettobuchung wurde nicht erwartet: KontoNr ' + IsNull(IST.KontoNr,'(NULL)') +
                                 ', Kat ' + IsNull(IST.PscdKennzeichen,'(NULL)') +
                                 ', Pers ' + IsNull(CAST(IST.PersCount AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.PersCount AS VARCHAR),'(NULL)') +
                                 ', BetragMin ' + IsNull(CAST(IST.BetragMin AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.BetragMin AS VARCHAR),'(NULL)') +
                                 ', BetragMax ' + IsNull(CAST(IST.BetragMax AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.BetragMax AS VARCHAR),'(NULL)')),'')
              FROM (SELECT KBK.KontoNr, KBK.PscdKennzeichen, PersCount = Count(KBK.BaPersonID), BetragMin = MIN(KBK.Betrag), BetragMax = MAX(KBK.Betrag)
            FROM dbo.KbBuchungKostenart KBK
              INNER JOIN dbo.KbBuchung  KBU ON KBU.KbBuchungID = KBK.KbBuchungID AND KBU.BgBudgetID = @BgBudgetID
            GROUP BY KBK.KontoNr, KBK.PscdKennzeichen) IST
            LEFT JOIN #Netto_Erwartet                      SOLL ON SOLL.KontoNr = IST.KontoNr AND SOLL.PscdKennzeichen = IST.PscdKennzeichen
              WHERE SOLL.KontoNr IS NULL OR IST.PersCount <> SOLL.PersCount OR IST.BetragMin <> SOLL.BetragMin OR IST.BetragMax <> SOLL.BetragMax

              SELECT @ErrorMsg = @ErrorMsg + IsNull(dbo.ConcDistinct(char(13) + char(10) + 'Die erwartete Bruttobuchung wurde nicht erzeugt: KontoNr ' + IsNull(SOLL.KontoNr,'(NULL)') +
                                 ', Kat ' + IsNull(SOLL.PscdKennzeichen,'(NULL)') +
                                 ', Pers ' + IsNull(CAST(IST.PersCount AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.PersCount AS VARCHAR),'(NULL)') +
                                 ', BetragMin ' + IsNull(CAST(IST.BetragMin AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.BetragMin AS VARCHAR),'(NULL)') +
                                 ', BetragMax ' + IsNull(CAST(IST.BetragMax AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.BetragMax AS VARCHAR),'(NULL)') +
                                 char(13) + char(10)),'')
              FROM (SELECT BKA.KontoNr, KBB.PscdKennzeichen, PersCount = Count(KBP.BaPersonID), BetragMin = MIN(KBP.Betrag), BetragMax = MAX(KBP.Betrag)
            FROM dbo.KbBuchungBruttoPerson   KBP
              INNER JOIN dbo.KbBuchungBrutto KBB ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID AND KBB.BgBudgetID = @BgBudgetID
              INNER JOIN dbo.BgKostenart     BKA ON BKA.BgKostenartID     = KBB.BgKostenartID
            GROUP BY BKA.KontoNr, KBB.PscdKennzeichen) IST
            RIGHT JOIN #Brutto_Erwartet                    SOLL ON SOLL.KontoNr = IST.KontoNr AND SOLL.PscdKennzeichen = IST.PscdKennzeichen
              WHERE IST.KontoNr IS NULL OR IST.PersCount <> SOLL.PersCount OR IST.BetragMin <> SOLL.BetragMin OR IST.BetragMax <> SOLL.BetragMax

              SELECT @ErrorMsg = @ErrorMsg + IsNull(dbo.ConcDistinct(char(13) + char(10) + 'Die erzeugte Bruttobuchung wurde nicht erwartet: KontoNr ' + IsNull(IST.KontoNr,'(NULL)') +
                                 ', Kat ' + IsNull(IST.PscdKennzeichen,'(NULL)') +
                                 ', Pers ' + IsNull(CAST(IST.PersCount AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.PersCount AS VARCHAR),'(NULL)') +
                                 ', BetragMin ' + IsNull(CAST(IST.BetragMin AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.BetragMin AS VARCHAR),'(NULL)') +
                                 ', BetragMax ' + IsNull(CAST(IST.BetragMax AS VARCHAR),'(NULL)') + '/' + IsNull(CAST(SOLL.BetragMax AS VARCHAR),'(NULL)')),'')
              FROM (SELECT BKA.KontoNr, KBB.PscdKennzeichen, PersCount = Count(KBP.BaPersonID), BetragMin = MIN(KBP.Betrag), BetragMax = MAX(KBP.Betrag)
            FROM dbo.KbBuchungBruttoPerson   KBP
              INNER JOIN dbo.KbBuchungBrutto KBB ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID AND KBB.BgBudgetID = @BgBudgetID
              INNER JOIN dbo.BgKostenart     BKA ON BKA.BgKostenartID     = KBB.BgKostenartID
            GROUP BY BKA.KontoNr, KBB.PscdKennzeichen) IST
            LEFT JOIN #Brutto_Erwartet                     SOLL ON SOLL.KontoNr = IST.KontoNr AND SOLL.PscdKennzeichen = IST.PscdKennzeichen
              WHERE SOLL.KontoNr IS NULL OR IST.PersCount <> SOLL.PersCount OR IST.BetragMin <> SOLL.BetragMin OR IST.BetragMax <> SOLL.BetragMax

              IF @ErrorMsg <> '' BEGIN
            RAISERROR(@ErrorMsg, 18, 1)
              END
            END");

            // Create helper tables
            DBUtil.ExecSQLThrowingException(@"
            CREATE TABLE #Netto_Erwartet
            (
              KontoNr         VARCHAR(10),
              PscdKennzeichen VARCHAR(1),
              PersCount       INT,
              BetragMin       MONEY,
              BetragMax       MONEY
            )

            CREATE TABLE #Brutto_Erwartet
            (
              KontoNr         VARCHAR(10),
              PscdKennzeichen VARCHAR(1),
              PersCount       INT,
              BetragMin       MONEY,
              BetragMax       MONEY
            )");
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T01_NurGBL()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget DATETIME,
              @DatumBis_Budget DATETIME

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @UserID             = {0};
              EXECUTE dbo.spTmpCreateFallAndFinanzplan 3, 'NurAusgaben', @UserID, NULL, NULL, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BgBudgetID
              FROM BgBudget
              WHERE BgFinanzplanID = @BgFinanzplanID
            AND Masterbudget = 0

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 3, 325.65, 325.70) -- Muss bei GBL-Anpassungen aktualisiert werden (GBL_PerPerson / Anz. Pers.)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 3, -325.70, -325.65)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T02_GblMieteKvg()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget DATETIME,
              @DatumBis_Budget DATETIME

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 3, 'GblMieteKvg', @UserID, 1276, 350, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BgBudgetID
              FROM BgBudget
              WHERE BgFinanzplanID = @BgFinanzplanID
            AND Masterbudget = 0

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 3, 325.65, 325.70)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 3, 425.30, 425.35)
              INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1, 350, 350)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 3, -325.70, -325.65)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 3, -425.35, -425.30)
              INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1, -350, -350)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T03_NichtAbgetreteneEinnahmen()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget DATETIME,
              @DatumBis_Budget DATETIME

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 3, 'NichtAbgetreteneEinnahmen', @UserID, 1276, 350, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BgBudgetID, @DatumVon_Budget = dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1), @DatumBis_Budget = dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1))
              FROM BgBudget BUD
              WHERE BgFinanzplanID = @BgFinanzplanID
            AND Masterbudget = 0

              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 1, 3101, 'Erwerbslohn', 500, 1, @DatumVon_Budget, @DatumBis_Budget)

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 3, 159, 159)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 3, 425.30, 425.35)
              INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1, 350, 350)
              INSERT INTO #Netto_Erwartet VALUES('850', 'N', 3, 0, 0)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 3, -325.70, -325.65)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 3, -425.35, -425.30)
              INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1, -350, -350)
              INSERT INTO #Brutto_Erwartet VALUES('850', 'N', 3, 166.65, 166.70)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T04_ZweiNichtAbgetreteneEinnahmen()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget DATETIME,
              @DatumBis_Budget DATETIME

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 3, 'ZweiNichtAbgetreteneEinnahmen', @UserID, 1276, 350, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BgBudgetID, @DatumVon_Budget = dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1), @DatumBis_Budget = dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1))
              FROM BgBudget BUD
              WHERE BgFinanzplanID = @BgFinanzplanID
            AND Masterbudget = 0

              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 1, 3101, 'Erwerbslohn', 500, 1, @DatumVon_Budget, @DatumBis_Budget)

              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 1, 3101, 'Erwerbslohn', 100, 1, @DatumVon_Budget, @DatumBis_Budget)

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 3, 125.65, 125.70)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 3, 425.30, 425.35)
              INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1, 350, 350)
              INSERT INTO #Netto_Erwartet VALUES('850', 'N', 6, 0, 0)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 3, -325.70, -325.65)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 3, -425.35, -425.30)
              INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1, -350, -350)
              INSERT INTO #Brutto_Erwartet VALUES('850', 'N', 6, 33.3, 166.70)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T05_Verrechnung()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget    DATETIME,
              @DatumBis_Budget    DATETIME,
              @BgSpezkontoID      INT,
              @FaLeistungID       INT,
              @BaPersonID_FT_LT   INT,
              @BaZahlungswegID    INT;

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @DatumVon_Budget    = NULL;
              SET @DatumBis_Budget    = NULL;
              SET @BgSpezkontoID      = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 4, 'Verrechnung', @UserID, 1276, 350, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BUD.BgBudgetID, @DatumVon_Budget = dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1), @DatumBis_Budget = dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)), @FaLeistungID = BFP.FaLeistungID, @BaPersonID_FT_LT = LEI.BaPersonID
              FROM BgBudget             BUD
            INNER JOIN BgFinanzplan BFP ON BFP.BgFinanzplanID = BUD.BgFinanzplanID
            INNER JOIN FaLeistung   LEI ON LEI.FaLeistungID   = BFP.FaLeistungID
              WHERE BUD.BgFinanzplanID = @BgFinanzplanID
            AND BUD.Masterbudget = 0

              UPDATE BgPosition
              SET Betrag = 2054.00,
              BewilligtBetrag = 2054.00
              WHERE BgBudgetID = @BgBudgetID
            AND BgPositionsartID = 32015

              -- Verrechnung erstellen
              INSERT INTO dbo.BgSpezkonto(FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, StartSaldo, OhneEinzelzahlung, BetragProMonat, BgPositionsartID, BgKostenartID, DatumVon, BaPersonID)
              VALUES (@FaLeistungID, 3, 'Verrechnung UnitTest', 385.00, 1, 100.00, 40140, 206, @DatumVon_Budget, @BaPersonID_FT_LT)
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgSpezkontoID, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 3, SCOPE_IDENTITY(), NULL, NULL, 100, 1, @DatumVon_Budget, @DatumBis_Budget)

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 4, 413.5, 513.5)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 4, 319, 319)
              INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1, 350, 350)
              INSERT INTO #Netto_Erwartet VALUES('872', 'V', 1,   0,   0)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 4, -513.5, -513.5)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 4, -319, -319)
              INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1, -350, -350)
              INSERT INTO #Brutto_Erwartet VALUES('872', 'V', 1,  100,  100)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T06_VerrechnungOhnePositionsart()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget    DATETIME,
              @DatumBis_Budget    DATETIME,
              @BgSpezkontoID      INT,
              @FaLeistungID       INT,
              @BaPersonID_FT_LT   INT,
              @BaZahlungswegID    INT;

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @DatumVon_Budget    = NULL;
              SET @DatumBis_Budget    = NULL;
              SET @BgSpezkontoID      = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 4, 'Verrechnung', @UserID, 1276, 350, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BUD.BgBudgetID, @DatumVon_Budget = dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1), @DatumBis_Budget = dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)), @FaLeistungID = BFP.FaLeistungID, @BaPersonID_FT_LT = LEI.BaPersonID
              FROM BgBudget             BUD
            INNER JOIN BgFinanzplan BFP ON BFP.BgFinanzplanID = BUD.BgFinanzplanID
            INNER JOIN FaLeistung   LEI ON LEI.FaLeistungID   = BFP.FaLeistungID
              WHERE BUD.BgFinanzplanID = @BgFinanzplanID
            AND BUD.Masterbudget = 0

              UPDATE BgPosition
              SET Betrag = 2054.00,
              BewilligtBetrag = 2054.00
              WHERE BgBudgetID = @BgBudgetID
            AND BgPositionsartID = 32015

              -- Verrechnung erstellen
              INSERT INTO dbo.BgSpezkonto(FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, StartSaldo, OhneEinzelzahlung, BetragProMonat, BgPositionsartID, BgKostenartID, DatumVon, BaPersonID)
              VALUES (@FaLeistungID, 3, 'Verrechnung UnitTest', 385.00, 1, 100.00, NULL, 206, @DatumVon_Budget, @BaPersonID_FT_LT)
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgSpezkontoID, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 3, SCOPE_IDENTITY(), NULL, NULL, 100, 1, @DatumVon_Budget, @DatumBis_Budget)

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 4, 488.5, 488.5)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 4, 319, 319)
              INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1, 350, 350)
              INSERT INTO #Netto_Erwartet VALUES('110', 'V', 4,   0,   0)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 4, -513.5, -513.5)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 4, -319, -319)
              INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1, -350, -350)
              INSERT INTO #Brutto_Erwartet VALUES('110', 'V', 4,   25,   25)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T07_EinzelzahlungVomGbl()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget    DATETIME,
              @DatumBis_Budget    DATETIME,
              @BgSpezkontoID      INT,
              @FaLeistungID       INT,
              @BaPersonID_FT_LT   INT,
              @BaZahlungswegID    INT;

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @DatumVon_Budget    = NULL;
              SET @DatumBis_Budget    = NULL;
              SET @BgSpezkontoID      = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 4, 'EZ vom GBL', @UserID, 1276, 350, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BUD.BgBudgetID, @DatumVon_Budget = dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1), @DatumBis_Budget = dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)), @FaLeistungID = BFP.FaLeistungID, @BaPersonID_FT_LT = LEI.BaPersonID
              FROM BgBudget             BUD
            INNER JOIN BgFinanzplan BFP ON BFP.BgFinanzplanID = BUD.BgFinanzplanID
            INNER JOIN FaLeistung   LEI ON LEI.FaLeistungID   = BFP.FaLeistungID
              WHERE BUD.BgFinanzplanID = @BgFinanzplanID
            AND BUD.Masterbudget = 0

              UPDATE BgPosition
              SET Betrag = 2054.00,
              BewilligtBetrag = 2054.00
              WHERE BgBudgetID = @BgBudgetID
            AND BgPositionsartID = 32015

              SELECT TOP 1 @BaZahlungswegID = BaZahlungswegID
              FROM BaZahlungsweg
              WHERE BaPersonID = @BaPersonID_FT_LT

              -- Einzelzahlung
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Buchungstext, BaPersonID, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 101, NULL, 'akkonto', @BaPersonID_FT_LT, 500, 1, @DatumVon_Budget, @DatumBis_Budget)
              INSERT INTO dbo.BgAuszahlungPerson (BgPositionID, KbAuszahlungsArtCode, BgAuszahlungsTerminCode, BaZahlungswegID)
              VALUES (SCOPE_IDENTITY(), 101, 4, @BaZahlungswegID)
              INSERT INTO dbo.BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum)
              VALUES (SCOPE_IDENTITY(), @DatumVon_Budget)

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 4, 388.5, 388.5)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 4, 319, 319)
              INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1, 350, 350)
              INSERT INTO #Netto_Erwartet VALUES('110', 'I', 4, 125, 125)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 4, -388.5, -388.5)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 4, -319, -319)
              INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1, -350, -350)
              INSERT INTO #Brutto_Erwartet VALUES('110', 'I', 4, -125, -125)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T08_EinzelzahlungVomGblUndVerrechnung()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget    DATETIME,
              @DatumBis_Budget    DATETIME,
              @BgSpezkontoID      INT,
              @FaLeistungID       INT,
              @BaPersonID_FT_LT   INT,
              @BaZahlungswegID    INT;

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @DatumVon_Budget    = NULL;
              SET @DatumBis_Budget    = NULL;
              SET @BgSpezkontoID      = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 4, 'EZ vom GBL und Verrechnung', @UserID, 1276, 350, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BUD.BgBudgetID, @DatumVon_Budget = dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1), @DatumBis_Budget = dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)), @FaLeistungID = BFP.FaLeistungID, @BaPersonID_FT_LT = LEI.BaPersonID
              FROM BgBudget             BUD
            INNER JOIN BgFinanzplan BFP ON BFP.BgFinanzplanID = BUD.BgFinanzplanID
            INNER JOIN FaLeistung   LEI ON LEI.FaLeistungID   = BFP.FaLeistungID
              WHERE BUD.BgFinanzplanID = @BgFinanzplanID
            AND BUD.Masterbudget = 0

              UPDATE BgPosition
              SET Betrag = 2054.00,
              BewilligtBetrag = 2054.00
              WHERE BgBudgetID = @BgBudgetID
            AND BgPositionsartID = 32015

              SELECT TOP 1 @BaZahlungswegID = BaZahlungswegID
              FROM BaZahlungsweg
              WHERE BaPersonID = @BaPersonID_FT_LT

              --Verrechnung
              INSERT INTO dbo.BgSpezkonto(FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, StartSaldo, OhneEinzelzahlung, BetragProMonat, BgPositionsartID, BgKostenartID, DatumVon, BaPersonID)
              VALUES (@FaLeistungID, 3, 'Verrechnung UnitTest', 385.00, 1, 100.00, 40140, 206, @DatumVon_Budget, @BaPersonID_FT_LT)
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgSpezkontoID, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 3, SCOPE_IDENTITY(), NULL, NULL, 100, 1, @DatumVon_Budget, @DatumBis_Budget)

              -- EZ
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Buchungstext, BaPersonID, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 101, NULL, 'akkonto', @BaPersonID_FT_LT, 500, 1, @DatumVon_Budget, @DatumBis_Budget)
              INSERT INTO dbo.BgAuszahlungPerson (BgPositionID, KbAuszahlungsArtCode, BgAuszahlungsTerminCode, BaZahlungswegID)
              VALUES (SCOPE_IDENTITY(), 101, 4, @BaZahlungswegID)
              INSERT INTO dbo.BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum)
              VALUES (SCOPE_IDENTITY(), @DatumVon_Budget)

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 4, 288.5, 388.5)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 4, 319, 319)
              INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1, 350, 350)
              INSERT INTO #Netto_Erwartet VALUES('872', 'V', 1,   0,   0)
              INSERT INTO #Netto_Erwartet VALUES('110', 'I', 4, 125, 125)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 4, -388.5, -388.5)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 4, -319, -319)
              INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1, -350, -350)
              INSERT INTO #Brutto_Erwartet VALUES('872', 'V', 1,  100,  100)
              INSERT INTO #Brutto_Erwartet VALUES('110', 'I', 4, -125, -125)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T09_GblAufAusgabekontoUndVerrechnung()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget    DATETIME,
              @DatumBis_Budget    DATETIME,
              @BgSpezkontoID      INT,
              @FaLeistungID       INT,
              @BaPersonID_FT_LT   INT,
              @BaZahlungswegID    INT;

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @DatumVon_Budget    = NULL;
              SET @DatumBis_Budget    = NULL;
              SET @BgSpezkontoID      = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 4, 'GBL auf Ausgabekonto & Verrechnung', @UserID, 1400, 200, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BUD.BgBudgetID, @DatumVon_Budget = dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1), @DatumBis_Budget = dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)), @FaLeistungID = BFP.FaLeistungID, @BaPersonID_FT_LT = LEI.BaPersonID
              FROM BgBudget             BUD
            INNER JOIN BgFinanzplan BFP ON BFP.BgFinanzplanID = BUD.BgFinanzplanID
            INNER JOIN FaLeistung   LEI ON LEI.FaLeistungID   = BFP.FaLeistungID
              WHERE BUD.BgFinanzplanID = @BgFinanzplanID
            AND BUD.Masterbudget = 0

              -- Ausgabekonto erstellen
              INSERT INTO dbo.BgSpezkonto(FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, StartSaldo, OhneEinzelzahlung, BetragProMonat, BgPositionsartID, BgKostenartID, DatumVon, BaPersonID)
              VALUES (@FaLeistungID, 1, 'Ausgabekonto UnitTest', 0, 0, 0, 32015, 206, @DatumVon_Budget, @BaPersonID_FT_LT)

              SELECT @BgPositionID_GBL = BgPositionID
              FROM BgPosition
              WHERE BgBudgetID = @BgBudgetID
            AND BgPositionsartID = 32015

              UPDATE BgPosition
              SET Betrag                  = 2000.00,
              BewilligtBetrag         = 2000.00,
              BgSpezkontoID           = SCOPE_IDENTITY()
              WHERE BgPositionID = @BgPositionID_GBL

              DELETE FROM BgAuszahlungPerson
              WHERE BgPositionID = @BgPositionID_GBL

              SELECT TOP 1 @BaZahlungswegID = BaZahlungswegID
              FROM BaZahlungsweg
              WHERE BaPersonID = @BaPersonID_FT_LT

              -- Verrechnung erstellen
              INSERT INTO dbo.BgSpezkonto(FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, StartSaldo, OhneEinzelzahlung, BetragProMonat, BgPositionsartID, BgKostenartID, DatumVon, BaPersonID)
              VALUES (@FaLeistungID, 3, 'Verrechnung UnitTest', 385.00, 1, 100.00, 40140, 206, @DatumVon_Budget, @BaPersonID_FT_LT)

              -- Verrechnungs-Position
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgSpezkontoID, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 3, SCOPE_IDENTITY(), NULL, NULL, 100, 1, @DatumVon_Budget, @DatumBis_Budget)

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 4,   0,   0)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 4, 350, 350)
              INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1, 200, 200)
              INSERT INTO #Netto_Erwartet VALUES('872', 'V', 1,   0,   0)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 4,  -25,  -25)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 4, -350, -350)
              INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1, -200, -200)
              INSERT INTO #Brutto_Erwartet VALUES('872', 'V', 1,  100,  100)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T10_GblAufAusgabekontoUndEzVomGblUndVerrechnung()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget    DATETIME,
              @DatumBis_Budget    DATETIME,
              @BgSpezkontoID      INT,
              @FaLeistungID       INT,
              @BaPersonID_FT_LT   INT,
              @BaZahlungswegID    INT;

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @DatumVon_Budget    = NULL;
              SET @DatumBis_Budget    = NULL;
              SET @BgSpezkontoID      = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 4, 'GBL auf Ausgabekonto & EZ vom GBL & Verrechnung', @UserID, 1400, 200, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BUD.BgBudgetID, @DatumVon_Budget = dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1), @DatumBis_Budget = dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)), @FaLeistungID = BFP.FaLeistungID, @BaPersonID_FT_LT = LEI.BaPersonID
              FROM BgBudget             BUD
            INNER JOIN BgFinanzplan BFP ON BFP.BgFinanzplanID = BUD.BgFinanzplanID
            INNER JOIN FaLeistung   LEI ON LEI.FaLeistungID   = BFP.FaLeistungID
              WHERE BUD.BgFinanzplanID = @BgFinanzplanID
            AND BUD.Masterbudget = 0

              -- Ausgabekonto erstellen
              INSERT INTO dbo.BgSpezkonto(FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, StartSaldo, OhneEinzelzahlung, BetragProMonat, BgPositionsartID, BgKostenartID, DatumVon, BaPersonID)
              VALUES (@FaLeistungID, 1, 'Ausgabekonto UnitTest', 0, 0, 0, 32015, 206, @DatumVon_Budget, @BaPersonID_FT_LT)

              SELECT @BgPositionID_GBL = BgPositionID
              FROM BgPosition
              WHERE BgBudgetID = @BgBudgetID
            AND BgPositionsartID = 32015

              UPDATE BgPosition
              SET Betrag                  = 2000.00,
              BewilligtBetrag         = 2000.00,
              BgSpezkontoID           = SCOPE_IDENTITY()
              WHERE BgPositionID = @BgPositionID_GBL

              DELETE FROM BgAuszahlungPerson
              WHERE BgPositionID = @BgPositionID_GBL

              SELECT TOP 1 @BaZahlungswegID = BaZahlungswegID
              FROM BaZahlungsweg
              WHERE BaPersonID = @BaPersonID_FT_LT

              -- Verrechnung erstellen
              INSERT INTO dbo.BgSpezkonto(FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, StartSaldo, OhneEinzelzahlung, BetragProMonat, BgPositionsartID, BgKostenartID, DatumVon, BaPersonID)
              VALUES (@FaLeistungID, 3, 'Verrechnung UnitTest', 385.00, 1, 100.00, 40140, 206, @DatumVon_Budget, @BaPersonID_FT_LT)

              -- Verrechnungs-Position
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgSpezkontoID, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 3, SCOPE_IDENTITY(), NULL, NULL, 100, 1, @DatumVon_Budget, @DatumBis_Budget)

              -- EZ vom GBL
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Buchungstext, BaPersonID, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 101, NULL, 'akkonto', @BaPersonID_FT_LT, 500, 1, @DatumVon_Budget, @DatumBis_Budget)

              INSERT INTO dbo.BgAuszahlungPerson (BgPositionID, KbAuszahlungsArtCode, BgAuszahlungsTerminCode, BaZahlungswegID)
              VALUES (SCOPE_IDENTITY(), 101, 4, @BaZahlungswegID)

              INSERT INTO dbo.BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum)
              VALUES (SCOPE_IDENTITY(), @DatumVon_Budget)

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 4,   0,   0)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 4, 350, 350)
              INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1, 200, 200)
              INSERT INTO #Netto_Erwartet VALUES('110', 'I', 4, 125, 125)
              INSERT INTO #Netto_Erwartet VALUES('872', 'V', 1,   0,   0)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 4,  -25,  -25)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 4, -350, -350)
              INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1, -200, -200)
              INSERT INTO #Brutto_Erwartet VALUES('110', 'I', 4, -125, -125)
              INSERT INTO #Brutto_Erwartet VALUES('872', 'V', 1,  100,  100)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T11_ZweiNichtAbgetreteneEinnahmen_GblReichtNicht()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget DATETIME,
              @DatumBis_Budget DATETIME

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 5, 'ZweiNichtAbgetreteneEinnahmen', @UserID, 1300, NULL, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BgBudgetID, @DatumVon_Budget = dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1), @DatumBis_Budget = dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1))
              FROM BgBudget BUD
              WHERE BgFinanzplanID = @BgFinanzplanID
            AND Masterbudget = 0

              UPDATE BgPosition
              SET Betrag = 2000.00,
              BewilligtBetrag = 2000.00
              WHERE BgBudgetID = @BgBudgetID
            AND BgPositionsartID = 32015

              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 1, 3101, 'Erwerbslohn', 500, 1, @DatumVon_Budget, @DatumBis_Budget)

              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 1, 40459, 'Erwerbslohn', 2100, 1, @DatumVon_Budget, @DatumBis_Budget)

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 5,   0, 0)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 5, 140, 140)
              --INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1, 350, 350)
              INSERT INTO #Netto_Erwartet VALUES('850', 'N', 5, 0, 0)
              INSERT INTO #Netto_Erwartet VALUES('851', 'N', 5, 0, 0)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 5, -400, -400)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 5, -260, -260)
              --INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1, -350, -350)
              INSERT INTO #Brutto_Erwartet VALUES('850', 'N', 5, 100, 100)
              INSERT INTO #Brutto_Erwartet VALUES('851', 'N', 5, 420, 420)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T12_Sanktion_Verrechnung_Einnahme()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget    DATETIME,
              @DatumBis_Budget    DATETIME,
              @BgSpezkontoID      INT,
              @FaLeistungID       INT,
              @BaPersonID_FT_LT   INT,
              @BaZahlungswegID    INT;

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @DatumVon_Budget    = NULL;
              SET @DatumBis_Budget    = NULL;
              SET @BgSpezkontoID      = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 1, 'Sanktion, Verrechnung und n.a. Einnahme', @UserID, 2000, 350, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BUD.BgBudgetID, @DatumVon_Budget = dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1), @DatumBis_Budget = dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)), @FaLeistungID = BFP.FaLeistungID, @BaPersonID_FT_LT = LEI.BaPersonID
              FROM BgBudget             BUD
            INNER JOIN BgFinanzplan BFP ON BFP.BgFinanzplanID = BUD.BgFinanzplanID
            INNER JOIN FaLeistung   LEI ON LEI.FaLeistungID   = BFP.FaLeistungID
              WHERE BUD.BgFinanzplanID = @BgFinanzplanID
            AND BUD.Masterbudget = 0

              SELECT TOP 1 @BaZahlungswegID = BaZahlungswegID
              FROM BaZahlungsweg
              WHERE BaPersonID = @BaPersonID_FT_LT

              UPDATE BgPosition
              SET Betrag = 595.35,
              BewilligtBetrag = 595.35
              WHERE BgBudgetID = @BgBudgetID
            AND BgPositionsartID = 32015

              -- Verrechnung erstellen
              INSERT INTO dbo.BgSpezkonto(FaLeistungID, BgSpezkontoTypCode, NameSpezkonto, StartSaldo, OhneEinzelzahlung, BetragProMonat, BgPositionsartID, BgKostenartID, DatumVon, BaPersonID)
              VALUES (@FaLeistungID, 3, 'Verrechnung UnitTest', 385.00, 1, 100.00, 40140, 206, @DatumVon_Budget, @BaPersonID_FT_LT)
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgSpezkontoID, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 3, SCOPE_IDENTITY(), NULL, NULL, 100, 1, @DatumVon_Budget, @DatumBis_Budget)

              -- EFB
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BaPersonID, BgPositionsartID, Buchungstext, Betrag, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 2, @BaPersonID_FT_LT, 40282, 'EFB Unmündige', 200, @DatumVon_Budget, @DatumBis_Budget)
              INSERT INTO dbo.BgAuszahlungPerson (BgPositionID, KbAuszahlungsArtCode, BgAuszahlungsTerminCode, BaZahlungswegID)
              VALUES (SCOPE_IDENTITY(), 101, 4, @BaZahlungswegID)
              INSERT INTO dbo.BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum)
              VALUES (SCOPE_IDENTITY(), @DatumVon_Budget)

              -- Sanktion EFB
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BaPersonID, BgPositionsartID, Buchungstext, Betrag, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 4, @BaPersonID_FT_LT, 40283, 'Sanktion EFB Unmündige', 50, @DatumVon_Budget, @DatumBis_Budget)

              -- n.a. Einnahme
              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BaPersonID, BgPositionsartID, Buchungstext, Betrag, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 1, @BaPersonID_FT_LT, 40280, 'Erwerbslohn Unmündige', 500, @DatumVon_Budget, @DatumBis_Budget)

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 1,    0,       0)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 1, 1995.35, 1995.35)
              INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1,  350,     350)
              INSERT INTO #Netto_Erwartet VALUES('392', 'A', 1,  150,     150)
              INSERT INTO #Netto_Erwartet VALUES('392', 'R', 1,    0,       0)
              INSERT INTO #Netto_Erwartet VALUES('855', 'N', 1,    0,       0)
              INSERT INTO #Netto_Erwartet VALUES('872', 'V', 1,    0,       0)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 1,  -595.35, -595.35)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 1, -2000,   -2000)
              INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1,  -350,    -350)
              INSERT INTO #Brutto_Erwartet VALUES('392', 'A', 1,  -200,    -200)
              INSERT INTO #Brutto_Erwartet VALUES('392', 'R', 1,    50,      50)
              INSERT INTO #Brutto_Erwartet VALUES('855', 'N', 1,   500,     500)
              INSERT INTO #Brutto_Erwartet VALUES('872', 'V', 1,   100,     100)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void T13_NegativeEinnahme()
        {
            TryAndRollbackSQL(@"
              DECLARE @BgFinanzplanID     INT,
              @BgBudgetID         INT,
              @BgPositionID_GBL   INT,
              @BgPositionID_Miete INT,
              @UserID             INT,
              @DatumVon_Budget DATETIME,
              @DatumBis_Budget DATETIME

              SET @BgFinanzplanID     = NULL;
              SET @BgBudgetID         = NULL;
              SET @BgPositionID_GBL   = NULL;
              SET @BgPositionID_Miete = NULL;
              SET @UserID             = {0};

              EXECUTE dbo.spTmpCreateFallAndFinanzplan 3, 'Negative Einnahme', @UserID, 1276, 350, @BgFinanzplanID OUT

              -- Monatsbudget erstellen
              EXECUTE dbo.spWhBudget_Create @BgFinanzplanID
              SELECT TOP 1 @BgBudgetID = BgBudgetID, @DatumVon_Budget = dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1), @DatumBis_Budget = dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1))
              FROM BgBudget BUD
              WHERE BgFinanzplanID = @BgFinanzplanID
            AND Masterbudget = 0

              INSERT INTO dbo.BgPosition (BgBudgetID, BgKategorieCode, BgPositionsartID, Buchungstext, Betrag, BgBewilligungstatusCode, VerwPeriodeVon, VerwPeriodeBis)
              VALUES (@BgBudgetID, 1, 3101, 'Erwerbslohn', -500, 1, @DatumVon_Budget, @DatumBis_Budget)

              EXECUTE dbo.spWhBudget_CreateKbBuchung @BgBudgetID, @UserID, 0
              UPDATE BgBudget
              SET BgBewilligungStatusCode = 5
              WHERE BgBudgetID = @BgBudgetID

              -- Vergleich
              TRUNCATE TABLE #Netto_Erwartet
              INSERT INTO #Netto_Erwartet VALUES('110', 'A', 3, 492.30, 492.35)
              INSERT INTO #Netto_Erwartet VALUES('130', 'A', 3, 425.30, 425.35)
              INSERT INTO #Netto_Erwartet VALUES('140', 'A', 1, 350, 350)
              INSERT INTO #Netto_Erwartet VALUES('850', 'N', 3, 0, 0)

              TRUNCATE TABLE #Brutto_Erwartet
              INSERT INTO #Brutto_Erwartet VALUES('110', 'A', 3, -325.70,    -325.65)
              INSERT INTO #Brutto_Erwartet VALUES('130', 'A', 3, -425.35, -425.30)
              INSERT INTO #Brutto_Erwartet VALUES('140', 'A', 1, -350,    -350)
              INSERT INTO #Brutto_Erwartet VALUES('850', 'N', 3, -166.70, -166.65)

              EXECUTE spTmpCheckGSRResult @BgBudgetID", _userid);
        }

        [TestCleanup]
        [TestCategory("LongRunning")]
        public void TearDown()
        {
            DBUtil.ExecSQLThrowingException(@"
            DROP PROCEDURE dbo.spTmpCreateFallAndFinanzplan
            DROP PROCEDURE dbo.spTmpCheckGSRResult
            DROP TABLE #Netto_Erwartet
            DROP TABLE #Brutto_Erwartet");
        }

        #endregion

        #region Methods

        #region Private Methods

        private void TryAndRollbackSQL(string sqlStatement, params object[] sqlParameters)
        {
            try
            {
                Session.BeginTransaction();
                DBUtil.ExecSQLThrowingException(sqlStatement, sqlParameters);
            }
            finally
            {
                Session.Rollback();
            }
        }

        #endregion

        #endregion
    }
}