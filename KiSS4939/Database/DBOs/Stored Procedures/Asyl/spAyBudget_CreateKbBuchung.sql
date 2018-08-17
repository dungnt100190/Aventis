SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spAyBudget_CreateKbBuchung;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Asyl/spAyBudget_CreateKbBuchung.sql $
  $Author: Cjaeggi $
  $Modtime: 15.07.10 15:47 $
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Asyl/spAyBudget_CreateKbBuchung.sql $
 * 
 * 10    15.07.10 18:34 Cjaeggi
 * #4167: Fixed BaInstitution.InstitutionName after changes of table
 * 
 * 9     14.07.10 11:31 Nweber
 * #6064: Spalte KbPeriodeID von der Tabelle KbBuchungKostenart löschen
 * 
 * 8     17.12.09 10:53 Nweber
 * #4644: Meldung für ungültige Banken angepasst
 * 
 * 7     28.11.09 11:15 Nweber
 * #4644: Fehlermeldung wenn die Bank eine neue ClearingNr hat.
 * 
 * 6     24.09.09 8:44 Lgreulich
 * Umbau KbKostenstelle -> KbKostenstelle_BaPerson
 * 
 * 5     25.06.09 11:42 Ckaeser
 * Alter2Create
 * 
 * 4     7.01.09 10:54 Lgreulich
 * 
 * 3     12.12.08 10:15 Ckaeser
 * 
 * 2     21.10.08 8:42 Lgreulich
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE PROCEDURE dbo.spAyBudget_CreateKbBuchung
 (
   @BgBudgetID          INT,
   @KbBuchungStatusCode INT = 1,
   @UserID              INT
 )
AS 

BEGIN
  /*
    Gibt ein Monatsbudget zur Zahlung frei:
    - Sämtliche Belege des Budgets (ausser Einzelzahlungen) werden generiert, falls:
    - Der Status des Monatsbudget wird von 1 auf 5 gewechselt
  */
  SET NOCOUNT ON;

  DECLARE @BgFinanzplanID            INT,
          @MasterBudget              BIT,
          @BgBewilligungStatusCode   INT,
          @BgJahr                    INT,
          @BgMonat                   INT,
          @FAL_BaPersonID            INT,
          @Person                    VARCHAR(100),  -- Name/Vorname

          @BgSpezkontoID             INT,
          @NameSpezkonto             VARCHAR(100),
          @BgSpezkontoTypCode        INT,

          @StartSaldo                MONEY,
          @Summe                     MONEY,
          @BetragKonto               MONEY,

          @KbPeriodeID               INT,
          @KontoNrDebitor            VARCHAR(10),
          @KontoNrKreditor           VARCHAR(10),

          @BuchungstextBL            VARCHAR(120),  -- Beleg

          @msg                       VARCHAR(200),
          
          @KreditorMehrZeilig        VARCHAR(MAX),
          @ClearingNr                VARCHAR(15),
          @ClearingNrNeu             VARCHAR(15);

  /************************************************************************************************/
  /* Check parameters                                                                             */
  /************************************************************************************************/
  IF @BgBudgetID IS NULL 
  BEGIN
    RAISERROR ('Der Aufruf-Parameter @BgBudgetID ist null!', 18, 1);
    RETURN -1;
  END;

  IF NOT EXISTS (SELECT TOP 1 1 FROM BgBudget WHERE BgBudgetID = @BgBudgetID) 
  BEGIN
    RAISERROR ('Das Monatsbudget mit der ID %d existiert nicht!', 18, 1, @BgBudgetID);
    RETURN -1;
  END;

  /************************************************************************************************/
  /* Get Monatsbudget properties, Check Stati, validate                                           */
  /************************************************************************************************/
  SELECT @BgFinanzplanID          = BBG.BgFinanzplanID,
         @MasterBudget            = BBG.MasterBudget,
         @BgBewilligungStatusCode = BBG.BgBewilligungStatusCode,
         @BgJahr                  = BBG.Jahr,
         @BgMonat                 = BBG.Monat,
         @FAL_BaPersonID          = FAL.BaPersonID,
         @Person                  = PRS.Name + IsNull(', ' + Vorname,'')
  FROM dbo.BgBudget              BBG WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
    INNER JOIN dbo.FaLeistung    FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = SFP.FaLeistungID
    INNER JOIN dbo.BaPerson      PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
  WHERE BBG.BgBudgetID = @BgBudgetID;

  IF (@MasterBudget = 1) 
  BEGIN
    RAISERROR ('Dieses Budget ist ein Masterbudget !', 18, 1);
    RETURN -1;
  END;

  IF (@MasterBudget = 0 AND @BgBewilligungStatusCode = 5) 
  BEGIN
    RAISERROR ('Dieses Monatsbudget ist bereits zur Zahlung freigegeben!', 18, 1);
    RETURN -1;
  END;

  IF (@MasterBudget = 0 AND @BgBewilligungStatusCode > 5) 
  BEGIN
    RAISERROR ('Dieses Monatsbudget ist gesperrt!', 18, 1);
    RETURN -1;
  END;

  /************************************************************************************************/
  /* Buchungsperiode bestimmen                                                                    */
  /************************************************************************************************/
  -- get PeriodeID for range and if none within range, get newest open periode (BSS Klibu: KbMandantID = 6)
  SET @KbPeriodeID = dbo.fnKbGetPeriodeID(6, NULL, @BgJahr, @BgMonat, 1);

  IF (@KbPeriodeID IS NULL) 
  BEGIN
    SET @msg = 'Es existiert keine offene Buchungsperiode, die den ' + CONVERT(varchar, @BgMonat) + '. Monat im Jahr ' + CONVERT(varchar, @BgJahr) + ' beinhaltet!';
    RAISERROR (@msg, 18, 1);
    RETURN -1;
  END;

  -- Debitor-/Kreditorkonto bestimmen
  SELECT TOP 1 @KontoNrDebitor = KontoNr
  FROM dbo.KbKonto WITH (READUNCOMMITTED) 
  WHERE KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes + ',' LIKE '%,20,%';

  SELECT TOP 1 @KontoNrKreditor = KontoNr
  FROM dbo.KbKonto WITH (READUNCOMMITTED) 
  WHERE KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes  + ',' LIKE '%,30,%';


  /************************************************************************************************/
  /* Check Spezialkonti                                                                           */
  /************************************************************************************************/

  -- Prüfen, ob Spezialkonti (falls benützt) genügend Deckung aufweisen

  DECLARE cSpezKonto CURSOR FAST_FORWARD FOR
    SELECT 'Das ' + XLC.Text + ' "' + SSK.NameSpezkonto + '" weist zuwenig Deckung auf'
    FROM dbo.BgPosition                  BPO WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BgAuszahlungPerson  STZ WITH (READUNCOMMITTED) ON STZ.BgPositionID = BPO.BgPositionID
      INNER JOIN dbo.BgSpezkonto         SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID = BPO.BgSpezkontoID
      INNER JOIN dbo.XLOVCode            XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgSpezkontoTyp' AND XLC.Code = SSK.BgSpezkontoTypCode
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND BPO.BgKategorieCode = 101
      AND NOT EXISTS (SELECT 1
                      FROM dbo.KbBuchung                   KBU WITH (READUNCOMMITTED) 
                        INNER JOIN dbo.KbBuchungKostenart  KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID = KBU.KbBuchungID
                      WHERE KBU.BgBudgetID = @BgBudgetID AND KBK.BgPositionID = BPO.BgPositionID
                        AND KbBuchungStatusCode NOT IN (1, 2))
      AND STZ.BgZahlungsmodusID IS NOT NULL
      AND dbo.fnAySpezkonto(SSK.BgSpezkontoID, 4, @BgBudgetID, default) < $0.00;

  OPEN cSpezKonto;
  WHILE (1 = 1) 
  BEGIN
    FETCH NEXT FROM cSpezKonto INTO @msg;
    IF @@FETCH_STATUS < 0 BREAK;

    DEALLOCATE cSpezKonto;
    RAISERROR (@msg, 18, 1);
    RETURN -1;
  END;
  CLOSE cSpezKonto;
  DEALLOCATE cSpezKonto;


  /************************************************************************************************/
  /* Monatsbudget verbuchen                                                                       */
  /************************************************************************************************/
  -- Personen, Kostenstellen, NrmKonto
  DECLARE @PersonVerrechnung TABLE (
    BaPersonID            INT PRIMARY KEY,
    NamePerson            VARCHAR(200) COLLATE DATABASE_DEFAULT NOT NULL,
    KbKostenstelleID      INT,
    PersonFactor          REAL
  );

  CREATE TABLE #Buchungen (
    BgPositionID          INT NOT NULL,
    BgKategorieCode       INT NOT NULL,
    BaPersonID            INT NULL,
    Betrag                MONEY NOT NULL,
    RechnungsDatum        DATETIME NULL,
    KbKostenstelleID      INT NOT NULL,
    BgPositionsartID      INT NULL,
    Name                  VARCHAR(200) COLLATE DATABASE_DEFAULT NULL,
    BgKostenartID         INT NOT NULL,
    BgZahlungsmodusID     INT NOT NULL,
    KbAuszahlungsArtCode  INT NOT NULL,
    BaZahlungswegID       INT NULL,
    ReferenzNummer        VARCHAR(50) COLLATE DATABASE_DEFAULT NULL,
    Dritte                BIT NOT NULL DEFAULT (1),
    BaPersonID_Teil       INT NOT NULL
  );

  INSERT INTO @PersonVerrechnung
    SELECT
      SPP.BaPersonID,
      PRS.NameVorname,
      KST.KbKostenstelleID,
      PersonFactor = (SELECT CONVERT(real, 1) / COUNT(*)
                      FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
                      WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1)
    FROM dbo.BgFinanzplan_BaPerson           SPP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.vwPerson                PRS ON PRS.BaPersonID = SPP.BaPersonID
      LEFT  JOIN dbo.KbKostenstelle_BaPerson KST WITH (READUNCOMMITTED) ON KST.BaPersonID = PRS.BaPersonID
    WHERE BgFinanzplanID = @BgFinanzplanID 
      AND SPP.IstUnterstuetzt = 1;

  -- Buchungen aus Monatsbudget (Ausgaben, Zusätzliche Leistungen, Einzelzahlungen)
  INSERT INTO #Buchungen (BgPositionID, BgKategorieCode, BaPersonID, BaPersonID_Teil, Betrag, RechnungsDatum, KbKostenstelleID, BgPositionsartID, Name, BgKostenartID, BgZahlungsmodusID, KbAuszahlungsArtCode, BaZahlungswegID, ReferenzNummer)
    SELECT BPO.BgPositionID, BPO.BgKategorieCode, BPO.BaPersonID, SPP.BaPersonID,
      Betrag               = CONVERT(MONEY, BPO.BetragRechnung * CASE WHEN BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      BPO.RechnungDatum,
      KbKostenstelleID     = SPP.KbKostenstelleID,
      BPT.BgPositionsartID, ISNULL(BPO.Buchungstext, BPT.Name), BPT.BgKostenartID,
      ISNULL(SZM.BgZahlungsmodusID, 0),
      KbAuszahlungsArtCode = CASE WHEN SZM.BgZahlungsmodusID IS NULL THEN STZ.KbAuszahlungsArtCode ELSE SZM.KbAuszahlungsArtCode END,
      BaZahlungswegID      = CASE WHEN SZM.BgZahlungsmodusID IS NULL THEN STZ.BaZahlungswegID      ELSE IsNull(SZM.BaZahlungswegID, STZ.BaZahlungswegID) END,
      ReferenzNummer       = CASE WHEN SZM.BgZahlungsmodusID IS NULL THEN STZ.ReferenzNummer       ELSE IsNull(SZM.ReferenzNummer, STZ.ReferenzNummer) END
    FROM dbo.vwBgPosition                BPO
      INNER JOIN @PersonVerrechnung  SPP ON (SPP.BaPersonID = BPO.BaPersonID OR BPO.BaPersonID IS NULL)
      INNER JOIN dbo.BgAuszahlungPerson  STZ WITH (READUNCOMMITTED) ON STZ.BgPositionID = BPO.BgPositionID AND (STZ.BaPersonID = SPP.BaPersonID OR STZ.BaPersonID IS NULL)
      LEFT  JOIN dbo.BgZahlungsmodus     SZM WITH (READUNCOMMITTED) ON SZM.BgZahlungsmodusID = STZ.BgZahlungsmodusID
      LEFT  JOIN dbo.BgPositionsart      BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND (BPO.BgKategorieCode NOT IN (100) OR BPO.BgBewilligungStatusCode = 5)
      AND (BPO.BgKategorieCode = 2 OR
             (BPO.BgKategorieCode IN (100, 101) AND NOT EXISTS (SELECT TOP 1 1
                                                                FROM dbo.KbBuchung                   KBU WITH (READUNCOMMITTED) 
                                                                  INNER JOIN dbo.KbBuchungKostenart  KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID = KBU.KbBuchungID
                                                                WHERE KBU.BgBudgetID = @BgBudgetID 
                                                                  AND KBK.BgPositionID = BPO.BgPositionID
                                                                  AND KbBuchungStatusCode NOT IN (1, 2))))
      AND (BPO.Betrag - BPO.Reduktion) > 0;

  -- Zahlungen an Klient
  UPDATE TMP
    SET Dritte = CASE
        WHEN FLW.BaZahlungswegID IS NULL AND TMP.KbAuszahlungsArtCode BETWEEN 103 AND 104        THEN 0
        WHEN FLW.BaPersonID IS NULL                                                              THEN 1
        WHEN FLW.BaPersonID IN (SELECT BaPersonID
                                FROM BgFinanzplan_BaPerson
                                WHERE IstUnterstuetzt = 1 AND BgFinanzplanID = @BgFinanzplanID)  THEN 0
        WHEN FLW.BaPersonID IN (SELECT FLZ2.BaPersonID
                                FROM BgFinanzplan_BaPerson   SPP
                                  INNER JOIN BaZahlungsweg   FLZ2 ON FLZ2.BaZahlungswegID = SPP.BaZahlungswegID
                                WHERE IstUnterstuetzt = 1 AND BgFinanzplanID = @BgFinanzplanID)  THEN 0
        ELSE 1
      END
  FROM #Buchungen                   TMP
    LEFT  JOIN dbo.BaZahlungsweg    FLW WITH (READUNCOMMITTED) ON FLW.BaZahlungswegID = TMP.BaZahlungswegID;


  /************************************************************************************************/
  /* Abzüge und Ausgaben an Dritte                                                                */
  /************************************************************************************************/
  DECLARE @BetragTotalAbzug  MONEY;

  -- Einkommen nicht vom Sozialdiesnst verwaltet
  SELECT @BetragTotalAbzug = ISNULL(SUM(BPO.BetragBudget), $0)
  FROM dbo.vwBgPosition   BPO
  WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 1 AND VerwaltungSD = 0;

  -- Nicht übernommene Ausgaben
  SELECT @BetragTotalAbzug = @BetragTotalAbzug + ISNULL(SUM(BPO.BetragRechnung - BPO.BetragFinanzplan), $0)
  FROM dbo.vwBgPosition   BPO
  WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2
    AND (BPO.Betrag - BPO.Reduktion) > BPO.MaxBeitragSD;

  -- Kürzungen / Spezialkonto
  SELECT @BetragTotalAbzug = @BetragTotalAbzug + ISNULL(SUM(BPO.BetragBudget), $0)
  FROM dbo.vwBgPosition   BPO
  WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (4, 3, 6);


  DECLARE @BgPositionsartID         INT,
          @BgPositionID_EZ          INT,
          @AbzugGruppeBetrag        MONEY,
          @AbzugGruppeCount         INT,
          @AbzugGruppeBetragGleich  BIT,
          @AbzugFactor              REAL,
          @AbzugBetrag              MONEY;

  DECLARE cAbzug CURSOR FAST_FORWARD FOR
    SELECT TMP.BgPositionsartID,
      BgPositionID_EZ = CASE WHEN TMP.BgKategorieCode IN (100, 101) THEN BgPositionID ELSE NULL END,
      Betrag          = SUM(TMP.Betrag),
      Anzahl          = COUNT(*),
      BetragGleich    = CASE WHEN MIN(TMP.Betrag) = MAX(TMP.Betrag) THEN 1 ELSE 0 END
    FROM #Buchungen               TMP
      LEFT  JOIN dbo.BaZahlungsweg    FLW WITH (READUNCOMMITTED) ON FLW.BaZahlungswegID = TMP.BaZahlungswegID
      LEFT  JOIN dbo.BgPositionsart   BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = TMP.BgPositionsartID
      LEFT  JOIN dbo.XLOVCode         XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgGruppe' AND XLC.Code = BPT.BgGruppeCode
    WHERE TMP.Dritte = 0
    GROUP BY TMP.BgPositionsartID, CASE WHEN TMP.BgKategorieCode IN (100, 101) THEN BgPositionID ELSE NULL END, XLC.SortKey, BPT.SortKey
    ORDER BY 2, IsNull(XLC.SortKey, 9999), BPT.SortKey DESC;

  OPEN cAbzug;
  WHILE 1 = 1 
  BEGIN
    FETCH NEXT FROM cAbzug INTO @BgPositionsartID, @BgPositionID_EZ, @AbzugGruppeBetrag, @AbzugGruppeCount, @AbzugGruppeBetragGleich;
    IF @@FETCH_STATUS != 0 BREAK;

    IF @BetragTotalAbzug = 0 BREAK;

    IF @BetragTotalAbzug <= @AbzugGruppeBetrag 
    BEGIN
      SELECT @AbzugBetrag = @BetragTotalAbzug,
             @AbzugFactor = CONVERT(REAL, (@AbzugGruppeBetrag - @BetragTotalAbzug)) / @AbzugGruppeBetrag,
             @BetragTotalAbzug = $0;
    END 
    ELSE 
    BEGIN
      SELECT @AbzugBetrag = @AbzugGruppeBetrag,
             @AbzugFactor = 0,
             @BetragTotalAbzug = @BetragTotalAbzug - @AbzugGruppeBetrag;
    END;

    UPDATE TMP
      SET TMP.Betrag = CASE WHEN @AbzugGruppeBetragGleich = 1 THEN TMP.Betrag - (@AbzugBetrag / @AbzugGruppeCount) ELSE @AbzugFactor * TMP.Betrag END
    FROM #Buchungen              TMP
    WHERE ISNULL(TMP.BgPositionsartID, 0) = ISNULL(@BgPositionsartID, 0)
      AND (@BgPositionID_EZ IS NULL AND TMP.BgKategorieCode = 2 OR (TMP.BgPositionID = @BgPositionID_EZ))
      AND TMP.Dritte = 0;
  END;
  CLOSE cAbzug;
  DEALLOCATE cAbzug;


  /************************************************************************************************/
  /* Beträge plausibilisieren                                                                     */
  /************************************************************************************************/
  IF @BetragTotalAbzug > $0.01 
  BEGIN
    SET @msg = 'Der Auszahlungsbetrag an den Klienten beträgt:' + CHAR(13) + CHAR(10) + ' -' + LTRIM(STR(@BetragTotalAbzug, 10, 2)) + ' sFr.';
    RAISERROR(@msg, 18, 1);
  END;

  DELETE TMP
  FROM #Buchungen  TMP
    INNER JOIN (SELECT BgPositionID, SUM(Betrag) AS BetragSumme
                FROM #Buchungen
                GROUP BY BgPositionID)   EZ  ON EZ.BgPositionID = TMP.BgPositionID
  WHERE TMP.BgKategorieCode IN (100, 101)
    AND EZ.BetragSumme = (SELECT Betrag FROM BgPosition WHERE BgPositionID = TMP.BgPositionID);


  /************************************************************************************************/
  /* Belege verbuchen                                                                             */
  /************************************************************************************************/
  DECLARE @TAB_KbBuchungID TABLE (KbBuchungID INT, BgPositionID INT);

  INSERT INTO @TAB_KbBuchungID (KbBuchungID, BgPositionID)
    SELECT DISTINCT KBU.KbBuchungID, KBK.BgPositionID
    FROM dbo.KbBuchung                   KBU WITH (READUNCOMMITTED) 
      LEFT  JOIN dbo.BgPosition          BPO WITH (READUNCOMMITTED) ON BPO.BgBudgetID = KBU.BgBudgetID AND BPO.BgKategorieCode IN (100, 101)
      LEFT  JOIN dbo.KbBuchungKostenart  KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID = KBU.KbBuchungID AND KBK.BgPositionID = BPO.BgPositionID
    WHERE KBU.BgBudgetID = @BgBudgetID;

  DELETE #Buchungen WHERE Betrag BETWEEN -$0.0009 AND $0.0009 AND BgKategorieCode = 2;

  UPDATE #Buchungen
    SET BgZahlungsmodusID = 0
  WHERE BgZahlungsmodusID IS NULL;

  UPDATE #Buchungen
    SET BaZahlungswegID = 0
  WHERE BaZahlungswegID IS NULL;

  DECLARE @KbBuchungID           INT,
          @KbBuchungKostenartID  INT;

  /*** Loop Zahlungsmodus  ***/
  DECLARE @RechnungsDatum        DATETIME,
          @BgZahlungsmodusID     INT,
          @KbAuszahlungsArtCode  INT,
          @BaZahlungswegID       INT,
          @ReferenzNummer        VARCHAR(50),
          @BetragZahlungsmodus   MONEY,
          @Rundungsdifferenz     MONEY,
          @SummeZahlungsmodus    MONEY;

  DECLARE cZahlungsmodus CURSOR FAST_FORWARD FOR
    SELECT
      BgPositionID_EZ = CASE WHEN BgKategorieCode IN (100, 101) THEN BgPositionID ELSE NULL END,
      RechnungsDatum, BgZahlungsmodusID, KbAuszahlungsArtCode, BaZahlungswegID, ReferenzNummer, SUM(Betrag)
    FROM #Buchungen
    GROUP BY CASE WHEN BgKategorieCode IN (100, 101) THEN BgPositionID ELSE NULL END,
      RechnungsDatum, BgZahlungsmodusID, KbAuszahlungsArtCode, BaZahlungswegID, ReferenzNummer;

  OPEN cZahlungsmodus;
  WHILE 1=1 
  BEGIN
    FETCH NEXT FROM cZahlungsmodus INTO @BgPositionID_EZ, @RechnungsDatum, @BgZahlungsmodusID, @KbAuszahlungsArtCode, @BaZahlungswegID, @ReferenzNummer, @BetragZahlungsmodus;
    IF @@FETCH_STATUS != 0 BREAK;

    SELECT @Rundungsdifferenz  = $0.00,
           @SummeZahlungsmodus = $0.00;

    /*** Loop Auszahlungstermine  ***/
    DECLARE @AnzahlMonatstage  INT,
            @AnzahlBelege      INT,
            @BelegLaufNr       INT,
            @SummeBeleg        MONEY,
            @FactorBeleg       FLOAT;

    SELECT
      @AnzahlMonatstage = dbo.fnDaysInMonthOf(dbo.fnDateSerial(@BgJahr, @BgMonat, 1)),
      @AnzahlBelege     = CASE
                            WHEN @BgZahlungsmodusID = 0 THEN 1
                            ELSE (SELECT COUNT(*) FROM dbo.BgZahlungsmodusTermin WITH (READUNCOMMITTED) 
                                  WHERE BgZahlungsmodusID = @BgZahlungsmodusID AND
                                    (Datum IS NULL OR (Year(Datum) = @BgJahr AND MONTH(Datum) = @BgMonat)))
                          END,
      @BelegLaufNr      = 0;

    IF ISNULL(@AnzahlBelege, 0) = 0 
    BEGIN
      SET @msg = 'Im Zahlungsmodus "' + 
                 (SELECT MIN(NameZahlungsmodus) 
                  FROM dbo.BgZahlungsmodus WITH (READUNCOMMITTED) 
                  WHERE BgZahlungsmodusID = @BgZahlungsmodusID) + 
                 '" sind noch keine Zahlungstermine für den ' + 
                 dbo.fnXMonat(@BgMonat) + ' ' + CONVERT(VARCHAR, @BgJahr) + ' festgelegt worden.';
      SET @msg = @msg + CHAR(13) + CHAR(10) + 'Bevor die Belege erzeugt werden können, müssen Sie die Zahlungstermine festlegen.';
      RAISERROR(@msg, 18, 1);
    END;

    DECLARE @AuszahlTag    DATETIME,
            @BetragGleich  BIT,
            @DatumLast     DATETIME,
            @DatumNext     DATETIME;

    SELECT @DatumLast = NULL;

    IF @BgZahlungsmodusID = 0 
    BEGIN
      DECLARE cZahlungsmodusTermin CURSOR FAST_FORWARD FOR
        SELECT NULL, 1, NULL;
    END 
    ELSE 
    BEGIN
      DECLARE cZahlungsmodusTermin CURSOR FAST_FORWARD FOR
        SELECT
          CASE
            WHEN SZT.Datum IS NOT NULL THEN SZT.Datum
            WHEN SZT.ImVormonat = 1    THEN DATEADD(m, -1, dbo.fnDateSerial(@BgJahr, @BgMonat, SZT.TagImMonat))
            ELSE dbo.fnDateSerial(@BgJahr, @BgMonat, SZT.TagImMonat)
          END AS Zahlungstermin,
          BetragGleich = CASE WHEN SZT.Datum IS NULL THEN 1 ELSE SZT.BetragGleich END,
          DatumNext    = (SELECT MIN(Datum) FROM dbo.BgZahlungsmodusTermin WITH (READUNCOMMITTED) 
                          WHERE BgZahlungsmodusID = SZT.BgZahlungsmodusID
                            AND Datum > SZT.Datum AND YEAR(Datum) = @BgJahr AND MONTH(Datum) = @BgMonat )
        FROM   dbo.BgZahlungsmodusTermin SZT WITH (READUNCOMMITTED) 
        WHERE  SZT.BgZahlungsmodusID = @BgZahlungsmodusID AND
               (SZT.Datum IS NULL OR (YEAR(SZT.Datum) = @BgJahr AND MONTH(SZT.Datum) = @BgMonat))
        ORDER BY 1;
    END;

    OPEN cZahlungsmodusTermin;
    WHILE 1=1 
    BEGIN
      FETCH NEXT FROM cZahlungsmodusTermin INTO @AuszahlTag, @BetragGleich, @DatumNext;
      IF @@FETCH_STATUS != 0 BREAK;

      IF @AnzahlBelege = 1 OR @BetragGleich = 1
        SET @FactorBeleg = CONVERT(float, 1) / @AnzahlBelege;
      ELSE IF @DatumLast IS NULL
        SET @FactorBeleg = CONVERT(float, DAY(@DatumNext) - 1) / @AnzahlMonatstage;
      ELSE
        SET @FactorBeleg = CONVERT(float, ISNULL(DAY(@DatumNext) - DAY(@AuszahlTag), @AnzahlMonatstage - DAY(@AuszahlTag) + 1)) / @AnzahlMonatstage;

      SET @DatumLast = @AuszahlTag;

      SET @BelegLaufNr = @BelegLaufNr + 1;

      SET @BuchungstextBL = CASE
                              WHEN @BgPositionID_EZ IS NOT NULL THEN
                                (SELECT TOP 1 Name FROM #Buchungen
                                 WHERE BgPositionID = @BgPositionID_EZ
                                 ORDER BY Betrag DESC)
                              WHEN @KbAuszahlungsArtCode = 103 THEN 'Barauszahlung'
                              ELSE ISNULL(
                                (SELECT CASE WHEN BZW.BaPersonID IS NOT NULL THEN PRS.NameVorname ELSE INS.[Name] END
                                 FROM BaZahlungsweg         BZW
                                   LEFT JOIN dbo.vwPerson       PRS ON PRS.BaPersonID = BZW.BaPersonID
                                   LEFT JOIN dbo.vwInstitution  INS ON INS.BaInstitutionID = BZW.BaInstitutionID
                                 WHERE BZW.BaZahlungswegID = @BaZahlungswegID), '')
                            END +
                            CASE
                              WHEN @AnzahlBelege = 1  THEN ''
                              ELSE ' (' + CONVERT(varchar, @BelegLaufNr) + ' von ' + CONVERT(VARCHAR, @AnzahlBelege) + ' Teilzahlungen' +
                                CASE WHEN @BetragGleich = 1
                                  THEN ')'
                                  ELSE ', für ' + CONVERT(VARCHAR, CONVERT(INT, @AnzahlMonatstage * @FactorBeleg)) + ' Tage)'
                                END
                            END;


      -- recycle KbBuchungID
      SET @KbBuchungID = NULL;
      IF @BgPositionID_EZ IS NULL 
      BEGIN
        SELECT TOP 1 @KbBuchungID = KbBuchungID FROM @TAB_KbBuchungID WHERE BgPositionID IS NULL;
        DELETE FROM @TAB_KbBuchungID WHERE KbBuchungID = @KbBuchungID;
      END 
      ELSE 
      BEGIN
        SELECT TOP 1 @KbBuchungID = KbBuchungID FROM @TAB_KbBuchungID WHERE BgPositionID = @BgPositionID_EZ;
        DELETE FROM @TAB_KbBuchungID WHERE KbBuchungID = @KbBuchungID;

        IF @AnzahlBelege = 1 AND (@AuszahlTag IS NULL OR (SELECT COUNT(*) FROM BgZahlungsmodusTermin WHERE BgZahlungsmodusID = @BgZahlungsmodusID AND Datum IS NULL) = 1) 
        BEGIN
          SELECT @AuszahlTag = MIN(Datum)
          FROM dbo.BgAuszahlungPerson                AZP WITH (READUNCOMMITTED) 
            INNER JOIN dbo.BgAuszahlungPersonTermin  AZT WITH (READUNCOMMITTED) ON AZT.BgAuszahlungPersonID = AZP.BgAuszahlungPersonID
          WHERE AZP.BgPositionID = @BgPositionID_EZ;
        END;
      END;

      -- #4644: Hat der Zalungsweg eine Bank mit einer neuen ClearingNr?
      SELECT TOP 1 @KreditorMehrZeilig = KreditorMehrZeilig,  @ClearingNr = ClearingNr, @ClearingNrNeu = ClearingNrNeu
      FROM dbo.vwKreditor     BZW 
        LEFT  JOIN dbo.BaBank BNK ON BNK.BaBankID = BZW.BaBankID
      WHERE BZW.BaZahlungswegID = @BaZahlungswegID;
   
      IF @ClearingNrNeu IS NOT NULL
      BEGIN
        DECLARE @Message VARCHAR(MAX);
        SET @Message = 'Der Zahlungsweg mit der ID %d hat eine Bank (ClearingNr %s) mit einer neuen ClearingNr.' + CHAR(13) + CHAR(10) +
                       'Kreditor:'+ CHAR(13) + CHAR(10) +
                       '%s';
        RAISERROR (@Message, 18, 1, @BaZahlungswegID, @ClearingNr, @KreditorMehrZeilig);
        RETURN -1;
      END;

      IF @KbBuchungID IS NULL 
      BEGIN
        INSERT INTO KbBuchung (
          KbPeriodeID, KbBuchungTypCode, BgBudgetID, Betrag,
          KbAuszahlungsArtCode, KbBuchungStatusCode,
          ErstelltDatum, BelegDatum, ValutaDatum,
          [Text], Extern, ErstelltUserID)
        VALUES (
          @KbPeriodeID, 1, @BgBudgetID, $0.00,
          @KbAuszahlungsArtCode, @KbBuchungStatusCode,
          GetDate(), IsNull(@RechnungsDatum, @AuszahlTag), @AuszahlTag,
          @BuchungstextBL, @Person, @UserID);

        SET @KbBuchungID = SCOPE_IDENTITY();
      END 
      ELSE 
      BEGIN
        DELETE KbBuchungKostenart WHERE KbBuchungID = @KbBuchungID;
      END;

      UPDATE KBU
        SET
          KbPeriodeID             = @KbPeriodeID,
          Betrag                  = $0.00,
          KbBuchungStatusCode     = @KbBuchungStatusCode,
          HabenKtoNr              = @KontoNrKreditor,
          KbAuszahlungsArtCode    = @KbAuszahlungsArtCode,
          ValutaDatum             = @AuszahlTag,

          [BaZahlungswegID]       = NullIf(@BaZahlungswegID, 0),
          [EinzahlungsscheinCode] = BZW.EinzahlungsscheinCode,
          [PCKontoNr]             = BZW.PostKontoNummer,
          [ReferenzNummer]        = SubString(@ReferenzNummer, 1, 30),
          [BankKontoNr]           = BZW.BankKontoNummer,
          [IBAN]                  = BZW.IBANNummer,
          [BaBankID]              = BZW.BaBankID,
          [BankBCN]               = BNK.ClearingNr,
          [BankName]              = BNK.Name,
          [BankStrasse]           = BNK.Strasse,
          [BankPLZ]               = BNK.PLZ,
          [BankOrt]               = BNK.Ort,

          [BeguenstigtName]       = BZW.BeguenstigtName,
          [BeguenstigtStrasse]    = BZW.BeguenstigtStrasse,
          [BeguenstigtPLZ]        = BZW.BeguenstigtPLZ,
          [BeguenstigtOrt]        = BZW.BeguenstigtOrt,
          
          [MitteilungZeile1]      = CASE WHEN BZW.EinzahlungsscheinCode IN (2, 3, 5) THEN SUBSTRING(@Person, 1, 35) END -- Tickets 3724, 4120 
      FROM dbo.KbBuchung              KBU WITH (READUNCOMMITTED) 
        LEFT  JOIN dbo.vwKreditor     BZW ON BZW.BaZahlungswegID = @BaZahlungswegID
        LEFT  JOIN dbo.vwPerson       PRS ON PRS.BaPersonID      = BZW.BaPersonID
        LEFT  JOIN dbo.vwInstitution  INS ON INS.BaInstitutionID = BZW.BaInstitutionID
        LEFT  JOIN dbo.BaBank         BNK WITH (READUNCOMMITTED) ON BNK.BaBankID        = BZW.BaBankID
      WHERE KBU.KbBuchungID = @KbBuchungID;

      /*** Loop Kostenart  ***/
      DECLARE @BgKostenartID            INT,
              @KontoNr                  VARCHAR(10),
              @BgPositionID             INT,
              @BaPersonID               INT,
              @KOABuchungstext          VARCHAR(200),
              @KbKostenstelleID         INT,
              @BetragKostenstelle       MONEY,
              @BetragKostenstelleRound  MONEY,
              @BgSplittingArtCode       INT,
              @Weiterverrechenbar       BIT,
              @Quoting                  BIT;

      DECLARE cKostenart CURSOR FAST_FORWARD FOR
        SELECT TMP.BgKostenartID, BKA.KontoNr, TMP.BgPositionID, TMP.BaPersonID_Teil,
          MIN(TMP.Name + ', ' + IsNull(PRS.Name + IsNull(', ' + PRS.Vorname, ''), '')),
          TMP.KbKostenstelleID, SUM(TMP.Betrag) * @FactorBeleg,
          BKA.BgSplittingArtCode, 
          [Weiterverrechenbar]=CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END, 
          BKA.Quoting
        FROM #Buchungen           TMP
          LEFT  JOIN dbo.BaPerson     PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID_Teil
          LEFT  JOIN dbo.BgKostenart  BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = TMP.BgKostenartID
        WHERE TMP.BgZahlungsmodusID = @BgZahlungsmodusID AND (TMP.BgPositionID = @BgPositionID_EZ OR (@BgPositionID_EZ IS NULL AND TMP.BgKategorieCode IN (2)))
          AND TMP.KbAuszahlungsArtCode = @KbAuszahlungsArtCode AND TMP.BaZahlungswegID = @BaZahlungswegID
          AND IsNull(TMP.ReferenzNummer, '') = IsNull(@ReferenzNummer, '')
        GROUP BY TMP.BgKostenartID, BKA.KontoNr, TMP.BgPositionID, TMP.BaPersonID_Teil, TMP.KbKostenstelleID, BKA.BgSplittingArtCode, CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END, BKA.Quoting;

      OPEN cKostenart;
      WHILE 1 = 1 
      BEGIN
        FETCH NEXT FROM cKostenart INTO @BgKostenartID, @KontoNr, @BgPositionID, @BaPersonID, @KOABuchungstext,
                                        @KbKostenstelleID, @BetragKostenstelle, 
                                        @BgSplittingArtCode, @Weiterverrechenbar, @Quoting;
        IF @@FETCH_STATUS != 0 BREAK;

        SET @BetragKostenstelleRound = FLOOR((@BetragKostenstelle + @Rundungsdifferenz) * 20.0 + 0.5) / 20.0;
        SET @Rundungsdifferenz       = @BetragKostenstelle + @Rundungsdifferenz - @BetragKostenstelleRound;
        SET @SummeZahlungsmodus      = @SummeZahlungsmodus + @BetragKostenstelleRound;

        INSERT INTO KbBuchungKostenart (KbBuchungID, BgPositionID, BaPersonID, Buchungstext, KbKostenstelleID, BgKostenartID, KontoNr, Betrag, BgSplittingArtCode, Weiterverrechenbar, Quoting)
          VALUES (@KbBuchungID, @BgPositionID, @BaPersonID, @KOABuchungstext, @KbKostenstelleID, @BgKostenartID, @KontoNr, @BetragKostenstelleRound, @BgSplittingArtCode, @Weiterverrechenbar, @Quoting);

        SET @KbBuchungKostenartID = SCOPE_IDENTITY();

        UPDATE KbBuchung
          SET Betrag = Betrag + @BetragKostenstelleRound
        WHERE KbBuchungID = @KbBuchungID;
      END;
      CLOSE cKostenart;
      DEALLOCATE cKostenart;

    END;
    CLOSE cZahlungsmodusTermin;
    DEALLOCATE cZahlungsmodusTermin;

    -- Korrektur Rundungsdifferenz Zahlungsmodus
    IF @BetragZahlungsmodus <> @SummeZahlungsmodus 
    BEGIN
      UPDATE KbBuchungKostenart
        SET Betrag = FLOOR((Betrag + @BetragZahlungsmodus - @SummeZahlungsmodus) * 20.0 + 0.5) / 20.0
      WHERE KbBuchungKostenartID = @KbBuchungKostenartID;

      UPDATE KbBuchung
        SET Betrag = FLOOR((Betrag + @BetragZahlungsmodus - @SummeZahlungsmodus) * 20.0 + 0.5) / 20.0
      WHERE KbBuchungID = @KbBuchungID;
    END;
  END;

  CLOSE cZahlungsmodus;
  DEALLOCATE cZahlungsmodus;

  DELETE FROM KbBuchungKostenart WHERE KbBuchungID IN (SELECT KbBuchungID FROM @TAB_KbBuchungID);
  DELETE FROM KbBuchung          WHERE KbBuchungID IN (SELECT KbBuchungID FROM @TAB_KbBuchungID);

  -- Delete Fr. 0.-- Belege
  DELETE FKS
  FROM KbBuchung                   FBL
    INNER JOIN KbBuchungKostenart  FKS ON FKS.KbBuchungID = FBL.KbBuchungID
  WHERE FBL.BgBudgetID = @BgBudgetID
    AND NOT EXISTS (SELECT TOP 1 1 FROM BgPosition WHERE BgPositionID = FKS.BgPositionID AND BgKategorieCode IN (100, 101))
    AND FBL.Betrag = $0.00;

/*
  DELETE FBL
  FROM KbBuchung                   FBL
  WHERE FBL.BgBudgetID = @BgBudgetID
    AND NOT EXISTS (SELECT * FROM KbBuchungKostenart WHERE KbBuchungID = FBL.KbBuchungID)
*/

  -- Einzelzahlungen
  DECLARE cEinzelzahlungen CURSOR FAST_FORWARD FOR
    SELECT DISTINCT BgPositionID
    FROM dbo.BgPosition              BPO WITH (READUNCOMMITTED) 
      LEFT  JOIN dbo.BgPositionsart  BPT WITH (READUNCOMMITTED) ON BPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (100, 101)
      AND NOT EXISTS (SELECT 1
                      FROM dbo.KbBuchung                   KBU WITH (READUNCOMMITTED) 
                        INNER JOIN dbo.KbBuchungKostenart  KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID = KBU.KbBuchungID
                      WHERE KBU.BgBudgetID = @BgBudgetID AND KBK.BgPositionID = BPO.BgPositionID
                        AND KbBuchungStatusCode NOT IN (1, 2))
      AND NOT EXISTS (SELECT 1 FROM #Buchungen WHERE BgPositionID = BPO.BgPositionID);

  OPEN cEinzelzahlungen;
  WHILE 1 = 1 
  BEGIN
    FETCH NEXT FROM cEinzelzahlungen INTO @BgPositionID;
    IF @@FETCH_STATUS != 0 BREAK;

    EXECUTE spAyEinzelzahlung_CreateKbBuchung @BgBudgetID, @BgPositionID, @KbBuchungStatusCode, @UserID;
  END;
  CLOSE cEinzelzahlungen;
  DEALLOCATE cEinzelzahlungen;

  DROP TABLE #Buchungen;
END;
GO