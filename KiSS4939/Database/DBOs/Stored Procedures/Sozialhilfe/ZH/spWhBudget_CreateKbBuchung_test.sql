SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_CreateKbBuchung_test
GO

CREATE PROCEDURE [dbo].[spWhBudget_CreateKbBuchung_test]
(
  @BgBudgetID          int,
  @UserID              int,
  @PreviewMode         int = 0,    -- 0: kein Preview (sondern echte Einträge in KbBuchung... Tabellen, 
                                   -- 1: Netto Preview, (temporäre Buchungen generieren)
                                   -- 2: Brutto Preview (temporäre Buchungen generieren)
  @CreateAllLocked     bit = 0,    -- 1: Die Buchungen mit Status 'gesperrt' generieren
  @BgPositionID_IN     int = NULL, -- 1: BgPositionID der Budgetposition, die separat auf grün gestellt werden soll
  @IncludeZahlwegGroup bit = 0     -- 1: für Einzelpositionen auch weitere Positionen mit gleichem Zahlweg mitberücksichtigen
)
AS BEGIN
  /*
    Gibt ein Monatsbudget zur Zahlung frei:
    - Sämtliche Belege des Budgets (ausser Einzelzahlungen) werden generiert, falls:
    - Der Status des Monatsbudget wird von 101 auf 102 gewechselt
  */
  SET NOCOUNT ON

  DECLARE @BgFinanzplanID            int,
          @MasterBudget              bit,
          @BgBewilligungStatusCode   int,
          @RefDate                   datetime,
          @FirstDayInMonth           datetime,
          @LastDayInMonth            datetime,
          @BgJahr                    int,
          @BgMonat                   int,
          @FAL_BaPersonID            int,
          @Person                    varchar(100),  -- Name/Vorname
          @FaLeistungID              int,
          @FaFallID                  int,

          @BuchungenID               int,

          @BgSpezkontoID             int,
          @NameSpezkonto             varchar(100),
          @BgSpezkontoTypCode        int,

          @StartSaldo                money,
          @Summe                     money,
          @BetragKonto               money,

          @FlZahlungslaufID          int,
          @BuchungstextZL            varchar(120),  -- Zahlungslauf
          @BuchungstextBL            varchar(120),  -- Beleg

          @msg                       varchar(500),
          @KbPeriodeID               int,
          @TotalBetrag               money,
          @KbBuchungStatusCode       int,
          @Diff                      money,
          @Kostenstelle              varchar(20),
          @SummeGBLAbzug             money,
          @SummeGBL                  money,
          @BgKostenartIDGBL          int,
          @BgPositionsartIDGBL       int,
          @BgPositionIDGBL           int,
          @WhHilfeTypCode            int,

          @KontoNrDebitor            varchar(10),
          @KontoNrKreditor           varchar(10),
          @KissStandard              bit,
          @PscdBelegNr               bigint,
          @Belegart                  varchar(4)


  SET @KissStandard = 0


  /************************************************************************************************/
  /* Check parameters                                                                             */
  /************************************************************************************************/
  IF @BgBudgetID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @BgBudgetID ist null!', 18, 1)
    RETURN -1
  END

  IF @UserID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @UserID ist null!', 18, 1)
    RETURN -1
  END

  IF @UserID NOT IN (SELECT UserID FROM XUser) BEGIN
    RAISERROR ('Es existiert kein User mit ID %d!', 18, 1, @UserID)
    RETURN -1
  END

  IF NOT EXISTS (SELECT 1 FROM BgBudget WHERE BgBudgetID = @BgBudgetID) BEGIN
    RAISERROR ('Das Monatsbudget mit der ID %d existiert nicht!', 18, 1, @BgBudgetID)
    RETURN -1
  END

  SET @KbBuchungStatusCode = CASE @PreviewMode WHEN 0 THEN 2 /*freigegeben*/ ELSE 1 /*vorbereitet*/ END

  /************************************************************************************************/
  /* Get Monatsbudget properties, Check Stati, validate                                           */
  /************************************************************************************************/
  SELECT @BgFinanzplanID          = BBG.BgFinanzplanID,
         @MasterBudget            = BBG.MasterBudget,
         @BgBewilligungStatusCode = BBG.BgBewilligungStatusCode,
         @RefDate                 = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
         @BgJahr                  = BBG.Jahr,
         @BgMonat                 = BBG.Monat,
         @FAL_BaPersonID          = FAL.BaPersonID,
         @Person                  = PRS.Name + IsNull(', ' + Vorname,''),
         @FirstDayInMonth         = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
         @LastDayInMonth          = dbo.fnLastDayOf(@FirstDayInMonth),
         @Kostenstelle            = ORG.Kostenstelle,
         @BgKostenartIDGBL        = BPA.BgKostenartID,
         @BgPositionsartIDGBL     = SFP.WhGrundbedarfTypCode,
         @FaLeistungID            = FAL.FaLeistungID,
         @FaFallID                = FAL.FaFallID,
         @WhHilfeTypCode          = SFP.WhHilfeTypCode
  FROM   BgBudget               BBG
    INNER JOIN BgFinanzplan     SFP ON SFP.BgFinanzplanID   = BBG.BgFinanzplanID
    INNER JOIN FaLeistung       FAL ON FAL.FaLeistungID     = SFP.FaLeistungID
    INNER JOIN BaPerson         PRS ON PRS.BaPersonID       = FAL.BaPersonID
    INNER JOIN XOrgUnit_User    O2U ON FAL.UserID           = O2U.UserID AND O2U.OrgUnitMemberCode = 2 /*Mitglied*/
    INNER JOIN XOrgUnit         ORG ON ORG.OrgUnitID        = O2U.OrgUnitID
    LEFT  JOIN BgPositionsart   BPA ON BPA.BgPositionsartID = SFP.WhGrundbedarfTypCode
  WHERE BBG.BgBudgetID = @BgBudgetID

  IF (@BgFinanzplanID IS NULL) BEGIN
    RAISERROR ('Der Leistungserbringer ist in keiner Organisationseinheit!', 18, 1)
    RETURN -1
  END

  IF (@MasterBudget = 1) BEGIN
    RAISERROR ('Dieses Budget ist ein Masterbudget !', 18, 1)
    RETURN -1
  END

  IF ( @BgPositionID_IN IS NULL AND @BgBewilligungStatusCode <> 1 AND @WhHilfeTypCode <> 1) BEGIN
    RAISERROR ('Das Budget kann nur aus dem Status ''Grau'' auf grün gestellt werden!', 18, 1)
    RETURN -1
  END

  IF (@BgPositionID_IN IS NOT NULL AND @BgBewilligungStatusCode < 5) BEGIN
    RAISERROR ('Einzelne Positionen können nur in einem grünen oder roten Budget auf grün gestellt werden!', 18, 1)
    RETURN -1
  END

  IF (@BgBewilligungStatusCode = 5 AND @BgPositionID_IN IS NULL) BEGIN
    -- Für ein bewilligtes Budget werden keine Vorschaubelege erzeugt    
    IF @PreviewMode > 0
      RETURN 0
    RAISERROR ('Dieses Monatsbudget ist bereits zur Zahlung freigegeben!', 18, 1)
    RETURN -1
  END

  IF (@BgPositionID_IN IS NULL AND @BgBewilligungStatusCode = 9) BEGIN
    RAISERROR ('Dieses Monatsbudget ist gesperrt!', 18, 1)
    RETURN -1
  END

  /************************************************************************************************/
  /* Check Konsistenz                                                                             */
  /************************************************************************************************/
  DECLARE @COUNT int

  -- Wenn Detailposition in @BgPositionID_IN, dann @BgPositionID_IN auf Parent-Position setzen (damit der ganze Beleg in einem Rutsch auf grün gestellt wird)
  IF @BgPositionID_IN IS NOT NULL BEGIN
    SELECT @BgPositionID_IN = IsNull(BgPositionID_Parent,BgPositionID)
    FROM   BgPosition
    WHERE  BgPositionID = @BgPositionID_IN
  END
/*
  -- Bereits verbuchte Buchungen
  SELECT @COUNT = COUNT(*)
  FROM   KbBuchung                KBU
    INNER JOIN KbBuchungKostenart KBK ON KBK.KbBuchungID = KBU.KbBuchungID
  WHERE  BgBudgetID = @BgBudgetID OR
         (@BgPositionID_IN IS NOT NULL AND BgPositionID IN (SELECT BgPositionID FROM BgPosition WHERE BgPositionID = @BgPositionID_IN OR BgPositionID_Parent = @BgPositionID_IN))

  SELECT @COUNT = @COUNT + COUNT(*)
  FROM   KbBuchungBrutto             KBB
    INNER JOIN KbBuchungBruttoPerson KBP ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
  WHERE  BgBudgetID = @BgBudgetID OR
         (@BgPositionID_IN IS NOT NULL AND BgPositionID IN (SELECT BgPositionID FROM BgPosition WHERE BgPositionID = @BgPositionID_IN OR BgPositionID_Parent = @BgPositionID_IN))

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Für ' + CASE WHEN @BgPositionID_IN IS NULL THEN  'dieses Budget' ELSE 'diese Budgetposition' END + ' gibt es bereits verbuchte Belege!'
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END
*/
  -- maximale Anzahl grüner Budgets in der Zukunft: 2
  IF @BgPositionID_IN IS NULL BEGIN
    SELECT @COUNT = COUNT(*)
    FROM   BgBudget
    WHERE  BgFinanzplanID = @BgFinanzplanID AND
           MasterBudget = 0 AND
           BgBewilligungStatusCode IN (5,9) AND
           dbo.fnDateSerial(Jahr,Monat,1) >= GetDate()

    IF (@COUNT >= 2) BEGIN
      RAISERROR ( 'Es dürfen nur 2 Monatsbudget im Voraus auf grün gestellt werden!', 18, 1)
      RETURN -1
    END
  END

  -- Verwendungsperiode Monat korrigieren
  UPDATE BPO
  SET VerwPeriodeVon = dbo.fnFirstDayOf(VerwPeriodeVon),
      VerwPeriodeBis = dbo.fnLastDayOf(VerwPeriodeBis)
  FROM   BgPosition           BPO
    INNER JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN BgKostenart    BKA ON BKA.BgKostenartID    = BPA.BgKostenartID
  WHERE BgBudgetID = @BgBudgetID
    AND (@BgPositionID_IN IS NULL OR BgPositionID = @BgPositionID_IN
           OR (BPO.BgKategorieCode IN (100, 101) AND BPO.BgPositionID_Parent = @BgPositionID_IN)) -- für Einzelposition
    AND  BKA.BgSplittingArtCode = 2 /*Monat*/ AND (dbo.fnFirstDayOf(VerwPeriodeVon) <> VerwPeriodeVon OR dbo.fnLastDayOf(VerwPeriodeBis) <> VerwPeriodeBis)

  -- Temporärtabelle erstellen
  SELECT *, BelegVorhanden = dbo.fnWhExistsBelegForPosition(BgPositionID)
    INTO #vwBgPosition
  FROM vwBgPosition
  WHERE BgBudgetID = @BgBudgetID
    AND (@BgPositionID_IN IS NULL OR BgPositionID = @BgPositionID_IN
           OR (BgKategorieCode IN (100, 101) AND BgPositionID_Parent = @BgPositionID_IN)) -- für Einzelposition

  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition
  WHERE  BelegVorhanden = 1

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Für ' + CASE WHEN @BgPositionID_IN IS NULL THEN  'dieses Budget' ELSE 'diese Budgetposition' END + ' gibt es bereits verbuchte Belege!'
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END

  -- Positionen ohne Positionsarten
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition       BPO
    LEFT JOIN BgSpezkonto    SPZ ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
    LEFT JOIN BgPositionsart BPA ON BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
    LEFT JOIN BgKostenart    BKA ON BKA.BgKostenartID    = IsNull(BPA.BgKostenartID,    SPZ.BgKostenartID)
  WHERE BPO.BgKategorieCode IN (1, 2, 100) -- Einnahmen, Ausgaben, Einzelzahlungen
--    AND (BPO.Betrag - BPO.Reduktion) > 0
    AND (BPO.BetragBudget) > 0
    AND (BKA.BgKostenartID IS NULL )

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Nicht allen Positionen dieses Budgets ist eine Leistungsart zugeordnet!', 18, 1)
    RETURN -1
  END

  -- Haupt-/Teilvorgang nicht definiert
  IF @KissStandard = 0 BEGIN
    SELECT @COUNT = COUNT(*), @msg = dbo.ConcDistinct(BKA.KontoNr + ' (' + BKA.Name + ', '+CASE WHEN BPO.VerwaltungSD = 1 THEN 'abgetreten' ELSE 'nicht abgetreten' END +')')
    FROM #vwBgPosition         BPO
      LEFT JOIN BgSpezkonto    SPZ ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      LEFT JOIN BgPositionsart BPA ON BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
      LEFT JOIN BgKostenart    BKA ON BKA.BgKostenartID    = COALESCE(BPA.BgKostenartID,  SPZ.BgKostenartID, @BgKostenartIDGBL)
    WHERE (BPO.Betrag - BPO.Reduktion) > 0
      AND BPO.BgPositionID = IsNull(@BgPositionID_IN,BPO.BgPositionID) -- für Einzelposition
      AND (BPO.VerwaltungSD = 1 AND (BKA.HauptvorgangAbtretung IS NULL OR BKA.TeilvorgangAbtretung IS NULL) OR
           BPO.VerwaltungSD = 0 AND (BKA.Hauptvorgang          IS NULL OR BKA.Teilvorgang          IS NULL))

    IF (@COUNT > 0) BEGIN
      SET @msg = 'Folgende Leistungsarten haben keinen Haupt-/Teilvorgang definiert: ' + char(13) + char(10) + char(13) + char(10) + @msg + char(13) + char(10) + char(13) + char(10) + 'Bitte in den Stammdaten nachtragen (lassen)'
      RAISERROR ( @msg, 18, 1)
      RETURN -1
    END
  END

  -- Positionen ohne BaAuszahlung-FK
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition BPO
  WHERE (BPO.BgKategorieCode = 101 OR (BPO.BgKategorieCode IN (2, 100) AND BgSpezkontoID IS NULL)) -- Einnahmen, Ausgaben, Einzelzahlungen
    AND (BPO.Betrag - BPO.Reduktion) > 0
    AND (BPO.BgPositionID NOT IN (SELECT BgPositionID FROM BgAuszahlungPerson WHERE BgPositionID IS NOT NULL))

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Nicht alle Positionen dieses Budgets haben Auszahlungsangaben!', 18, 1)
    RETURN -1
  END

  -- Positionen mit BaAuszahlung-FK aber ohne Zahlweg 
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition           BPO
    LEFT JOIN BgAuszahlungPerson BAP ON BAP.BgPositionID = BPO.BgPositionID
  WHERE (BPO.BgKategorieCode = 101 OR (BPO.BgKategorieCode IN (2, 100) AND BgSpezkontoID IS NULL)) -- Einnahmen, Ausgaben, Einzelzahlungen
    AND (BPO.Betrag - BPO.Reduktion) > 0
    AND ((BAP.KbAuszahlungsArtCode = 101           /*Elektronische Auszahlung*/ AND BaZahlungswegID IS NULL)
         OR (BAP.BgAuszahlungsTerminCode IS NULL )
         OR (BAP.BgAuszahlungPersonID NOT IN (SELECT BgAuszahlungPersonID FROM BgAuszahlungPersonTermin))
        )

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Nicht alle Positionen dieses Budgets haben einen Auszahlungstermin!', 18, 1)
    RETURN -1
  END

  -- Referenznummer
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition            BPO
    INNER JOIN BgAuszahlungPerson BAP ON BPO.BgPositionID    = BAP.BgPositionID
    INNER JOIN BaZahlungsweg      ZAL ON ZAL.BaZahlungswegID = BAP.BaZahlungswegID
  WHERE (BPO.Betrag - BPO.Reduktion) > 0 AND
          (BAP.ReferenzNummer IS NOT NULL AND dbo.[fnCheckReferenznummer](BAP.ReferenzNummer) = 0 OR
           (ZAL.EinzahlungsscheinCode = 1 AND BAP.ReferenzNummer IS NULL))

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Nicht alle Referenznummern sind gültig!', 18, 1)
    RETURN -1
  END

  -- Forderungen ohne Debitor
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition
  WHERE  BgKategorieCode = 1 /*Einnahme*/ AND VerwaltungSD = 1 AND Betrag > 0 AND BaInstitutionID IS NULL AND DebitorBaPersonID IS NULL

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Nicht alle Forderungen dieses Budgets haben einen Debitor!', 18, 1)
    RETURN -1
  END

  -- gequotete Positionen ohne Person
  SELECT @COUNT = COUNT(*), @msg = dbo.ConcDistinct(BPA.Name)
  FROM   #vwBgPosition        BPO
    INNER JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN BgKostenart    BKA ON BKA.BgKostenartID    = BPA.BgKostenartID
  WHERE BKA.Quoting = 0 AND BPO.BaPersonID IS NULL
    AND (BPO.Betrag - BPO.Reduktion) > 0

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Es gibt nicht gequotete Positionen, bei denen ''betrifft Person'' nicht ausgefüllt ist!' + char(13) + char(10) + char(13) + char(10) + @msg
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END

  -- Keine Verwendungsperiode
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition        BPO
    INNER JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN BgKostenart    BKA ON BKA.BgKostenartID    = BPA.BgKostenartID
  WHERE  BKA.BgSplittingArtCode <> 3 /*Valuta*/ AND (VerwPeriodeVon IS NULL OR (VerwPeriodeBis IS NULL AND BKA.BgSplittingArtCode <> 4 /*Entscheid*/))

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Verwendungsperiode von/bis ist nicht für jede Position ausgefüllt!', 18, 1)
    RETURN -1
  END

  -- Verwendungsperiode Monat prüfen
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition        BPO
    INNER JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN BgKostenart    BKA ON BKA.BgKostenartID    = BPA.BgKostenartID
  WHERE  BKA.BgSplittingArtCode = 2 /*Monat*/ AND (dbo.fnFirstDayOf(VerwPeriodeVon) <> VerwPeriodeVon OR dbo.fnLastDayOf(VerwPeriodeBis) <> VerwPeriodeBis)

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Bei Splittingart Monat muss die Verwendungsperiode vom Anfang eines Monats bis Ende eines Monats dauern!', 18, 1)
    RETURN -1
  END

  IF( @BgPositionID_IN IS NULL ) BEGIN -- nur für gesamtes Budget testen
    -- Zuviel Abzug vom GBL
    -- ToDo: Ev. werden hier noch nicht alle Abzüge berücksichtigt
    SELECT @SummeGBLAbzug = SUM(Betrag)
    FROM   #vwBgPosition
    WHERE  BgBudgetID = @BgBudgetID
           AND ((BgKategorieCode = 101 AND BgSpezkontoID IS NULL) -- Einzelzahlung vom GBL
           OR  (BgKategorieCode IN (3 /*Abzahlung*/, 6 /*Vorabzüge*/)))


    SELECT @SummeGBL = SUM(BetragBudget)
    FROM   #vwBgPosition         BPO
      INNER JOIN BgPositionsart  BPA ON BPO.BgPositionsartID = BPA.BgPositionsartID
    WHERE  BgBudgetID = @BgBudgetID AND BPA.BgKostenartID = @BgKostenartIDGBL

    IF (@SummeGBLAbzug > @SummeGBL) BEGIN
      SET @msg = 'Es werden mehr Abzüge vom GBL gemacht als GBL bewilligt ist!' + char(13) + char(10) + ' Die Differenz beträgt CHF ' + CAST((@SummeGBLAbzug - @SummeGBL) AS varchar )
      RAISERROR ( @msg, 18, 1)
      RETURN -1
    END
  END

  /************************************************************************************************/
  /* Check Spezialkonti                                                                           */
  /************************************************************************************************/

  -- Prüfen, ob Spezialkonti (falls benützt) genügend Deckung aufweisen
  DECLARE cSpezKonto CURSOR FAST_FORWARD FOR
    SELECT 'Das ' + XLC.Text + ' "' + SSK.NameSpezkonto + '" weist zuwenig Deckung auf'
    FROM #vwBgPosition               BPO
--      INNER JOIN BgAuszahlungPerson  STZ ON STZ.BgPositionID   = BPO.BgPositionID
      INNER JOIN BgSpezkonto         SSK ON SSK.BgSpezkontoID  = BPO.BgSpezkontoID
      INNER JOIN XLOVCode            XLC ON XLC.LOVName        = 'BgSpezkontoTyp' AND XLC.Code = SSK.BgSpezkontoTypCode
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (101) -- Einzelzahlung
      --ToDo: AND NOT EXISTS (SELECT * FROM KbBuchung WHERE FlTypSourceCode = 105 AND IdSource = SEZ.BgAuszahlungID AND FlBelegStatusCode IN (102, 103, 106)) --verbucht(warnung)/gesperrt
      AND dbo.fnBgSpezkonto(BPO.BgSpezkontoID, 4, @BgBudgetID, @BgPositionID_IN) < $0.00

  OPEN cSpezKonto
  FETCH NEXT FROM cSpezKonto INTO @msg
  IF @@FETCH_STATUS = 0 BEGIN
    RAISERROR (@msg, 18, 1)

    -- close cursor here and stop execution
    CLOSE cSpezKonto
    DEALLOCATE cSpezKonto
    RETURN -1
  END
  CLOSE cSpezKonto
  DEALLOCATE cSpezKonto

  /************************************************************************************************/
  /* Buchungsperiode bestimmen                                                                    */
  /************************************************************************************************/
  SELECT @KbPeriodeID = KbPeriodeID
  FROM   KbPeriode
  WHERE  KbMandantCode = 1 /*für ZH nur Mandant 1*/
     AND PeriodeStatusCode = 1 /*offen*/
     AND PeriodeVon <= dbo.fnDateSerial(@BgJahr, @BgMonat, 1)
     AND PeriodeBis >= dbo.fnLastDayOf(dbo.fnDateSerial(@BgJahr, @BgMonat, 1))

  IF (@KbPeriodeID IS NULL) BEGIN
    SET @msg = 'Es existiert keine offene Buchungsperiode, die den ' + CONVERT(varchar, @BgMonat) + '. Monat im Jahr ' + CONVERT(varchar, @BgJahr) + ' beinhaltet!'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END

  -- Debitor-/Kreditorkonto bestimmen
  SELECT TOP 1 @KontoNrDebitor = KontoNr
  FROM   KbKonto
  WHERE  KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes + ',' LIKE '%,20,%'

  SELECT TOP 1 @KontoNrKreditor = KontoNr
  FROM   KbKonto
  WHERE  KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes  + ',' LIKE '%,30,%'

  /************************************************************************************************/
  /* Monatsbudget verbuchen                                                                       */
  /************************************************************************************************/

  SELECT @BgPositionIDGBL = BgPositionID
  FROM #vwBgPosition
  WHERE BgBudgetID = @BgBudgetID AND BgPositionsartID = @BgPositionsartIDGBL

  -- Personen, Kostenstellen, NrmKonto
  DECLARE @PersonVerrechnung TABLE (
    BaPersonID            int PRIMARY KEY Clustered,
    NamePerson            varchar(200) COLLATE DATABASE_DEFAULT NOT NULL,
    KbKostenstelleID      int,
    PersonFactor          real
  )

  CREATE TABLE #Buchungen (
    BuchungenID           int NOT NULL IDENTITY(1, 1),
    BgPositionID          int NULL,
    BaPersonID            int NULL,
    BetragBrutto          money NOT NULL,
    BetragNetto           money NOT NULL,
    Kostenstelle          varchar(20) NULL,
    BgPositionsartID      int NULL,
    [Name]                varchar(200) COLLATE DATABASE_DEFAULT NULL,
    BgKostenartID         int NOT NULL,
    Dritte                bit NOT NULL DEFAULT (1),
    BaPersonID_Teil       int NOT NULL,
    Einnahme              bit NOT NULL DEFAULT (0),
    BgKategorieCode       int NULL,
    VerwaltungSD          bit NOT NULL DEFAULT (0),
    BgSpezkontoID         int NULL,
    KbBuchungStatusCode   int NULL,
    AuszahlGruppeID       int NULL,
    TerminFaktor          real NULL,
    NettoBetragProTermin  real NULL,
    BruttoBetragProTermin real NULL,
    GBLAufAusgabeKonto    bit NOT NULL DEFAULT (0),
    BgSplittingArtCode    int NULL
  )
  CREATE NONCLUSTERED INDEX [IX_BaPersonID_Teil] ON [dbo].[#Buchungen]
  (
	[BaPersonID_Teil] ASC
  )WITH (PAD_INDEX  = OFF, FILLFACTOR = 90) ON [PRIMARY]
  CREATE NONCLUSTERED INDEX [IX_BgPositionID] ON [dbo].[#Buchungen]
  (
	[BgPositionID] ASC
  )WITH (PAD_INDEX  = OFF, FILLFACTOR = 90) ON [PRIMARY]

  -- Unterstützte Personen im Finanzplan
  INSERT INTO @PersonVerrechnung
    SELECT BFP.BaPersonID, PRS.NameVorname, NULL, --KST.KbKostenstelleID
           (SELECT CONVERT(real, 1) / COUNT(*)
            FROM  BgFinanzplan_BaPerson
            WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1
           )                  AS PersonFactor
    FROM BgFinanzplan_BaPerson   BFP
      INNER JOIN vwPerson        PRS ON PRS.BaPersonID = BFP.BaPersonID
    WHERE BgFinanzplanID = @BgFinanzplanID AND BFP.IstUnterstuetzt = 1

  -- Sind denn überhaupt Personen im Finanzplan?
  SELECT @COUNT = COUNT(*)
  FROM   @PersonVerrechnung

  IF (@COUNT = 0) BEGIN
    SET @msg = 'Diesem Finanzplan sind keine Personen zugeordnet!'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END

  SELECT @COUNT = COUNT(*)
  FROM @PersonVerrechnung SPP
    LEFT  JOIN vwPerson   PRS ON PRS.BaPersonID = SPP.BaPersonID
  WHERE WohnsitzBaAdresseID IS NULL
    OR VornameName IS NULL
    OR WohnsitzPLZ IS NULL
    OR WohnsitzOrt IS NULL

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Nicht alle Personen des Finanzplans ' +CONVERT(varchar,@BgFinanzplanID)+ ' im Fall '+CONVERT(varchar,@FaFallID)+' haben eine Wohn-/Meldeadresse. Die WMA ist Voraussetzung, um Auszahlungen zu machen'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END
--bgfinanzplanid, fafallid
  --select '@PersonVerrechnung', * FROM @PersonVerrechnung
  SELECT @COUNT = COUNT(*)
  FROM #vwBgPosition             BPO
    LEFT JOIN @PersonVerrechnung SPP ON SPP.BaPersonID = BPO.BaPersonID
  WHERE BPO.BaPersonID IS NOT NULL AND SPP.BaPersonID IS NULL

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Eine unter "Betrifft Person" gewählte Person ist nicht Mitglied dieses Finanzplans'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END

  -- Buchungen (Ausgaben) aus Monatsbudget
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, Kostenstelle, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, KbBuchungStatusCode, GBLAufAusgabeKonto, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto     = CONVERT(money, BPO.BetragBudget   * CASE WHEN BPO.BaPersonID IS NULL OR (BKA.Quoting = 1 AND BPA.BgPositionsartID <> 32021) THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto      = CONVERT(money, BPO.BetragRechnung * CASE WHEN BPO.BaPersonID IS NULL OR (BKA.Quoting = 1 AND BPA.BgPositionsartID <> 32021) THEN SPP.PersonFactor ELSE 1.0 END),
      Kostenstelle     = @Kostenstelle,
      BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID),
      IsNull(BPO.Buchungstext, BPA.Name), BPA.BgKostenartID,
      Einnahme             = 0,
      BgKategorieCode      = BPO.BgKategorieCode,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      GBLAufAusgabeKonto   = CASE WHEN BPO.BgSpezkontoID IS NOT NULL AND BPO.BgPositionsartID = @BgPositionsartIDGBL THEN 1 ELSE 0 END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      LEFT  JOIN BgSpezkonto         SPZ ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      LEFT  JOIN BgPositionsart      BPA ON  BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
      LEFT  JOIN BgKostenart         BKA ON  BKA.BgKostenartID    = BPA.BgKostenartID
      INNER JOIN @PersonVerrechnung  SPP ON ((BKA.Quoting = 1 AND BPA.BgPositionsartID <> 32021) OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                              SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                              BPO.BaPersonID IS NULL)            /* normales Quoting */
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND (BPO.BgKategorieCode = 2 /*Ausgaben*/ OR (BPO.BgKategorieCode = 100 /*Zusätzliche Leistung*/ AND BPO.BgBewilligungStatusCode = 5 /*bewilligt*/))
      AND (BPO.Betrag - BPO.Reduktion) > 0 AND (BPO.BgSpezkontoID IS NULL OR BPO.BgPositionsartID = @BgPositionsartIDGBL /*Spezialtrick, um Betrag für Ausgabekonto zu bstimmen*/)
      AND BPO.BelegVorhanden = 0 /*keine verbuchten Belege*/

  -- Buchungen (Einnahmen) aus Monatsbudget
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, Kostenstelle, BgPositionsartID, Name, BgKostenartID, Einnahme, BgKategorieCode, VerwaltungSD, KbBuchungStatusCode, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, -BPO.BetragBudget   * CASE WHEN BPO.BaPersonID IS NULL OR BKA.Quoting = 1 THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, -BPO.BetragRechnung * CASE WHEN BPO.BaPersonID IS NULL OR BKA.Quoting = 1 THEN SPP.PersonFactor ELSE 1.0 END),
      Kostenstelle         = @Kostenstelle,
      BgPositionsartID     = IsNull(BPA.BgPositionsartID,@BgPositionsartIDGBL),--CASE BPO.BgKategorieCode WHEN 1 THEN BPA.BgPositionsartID ELSE @BgPositionsartIDGBL END,
      IsNull(BPO.Buchungstext, BPA.Name),
      BgKostenartID        = IsNull(BPA.BgKostenartID, @BgKostenartIDGBL),--CASE BPO.BgKategorieCode WHEN 1 THEN BPA.BgKostenartID ELSE @BgKostenartIDGBL END,
      Einnahme             = 1,
      BgKategorieCode      = BPO.BgKategorieCode,
      VerwaltungSD         = BPO.VerwaltungSD,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      LEFT  JOIN BgPositionsart      BPA ON  BPA.BgPositionsartID = BPO.BgPositionsartID
      LEFT  JOIN BgKostenart         BKA ON  BKA.BgKostenartID    = BPA.BgKostenartID
      INNER JOIN @PersonVerrechnung  SPP ON (BKA.Quoting = 1                 OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                             SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                             BPO.BaPersonID IS NULL)            /* normales Quoting */
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (1,4) /* Einnahmen, Sanktionen */
      AND ABS(BPO.Betrag - BPO.Reduktion) > 0                           -- positive und negative Einnahmen
      AND BPO.BelegVorhanden = 0          -- noch kein verbuchter Beleg

  -- Buchungen aus Einzelzahlung
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, Kostenstelle, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, BgSpezkontoID, KbBuchungStatusCode, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, BPO.Betrag * CASE WHEN BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, BPO.Betrag * CASE WHEN BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      Kostenstelle         = @Kostenstelle,
      BPA.BgPositionsartID,
      IsNull(BPO.Buchungstext, IsNull('Zahlung aus Spezialkonto "' + SPZ.NameSpezkonto + '"', BPA.Name)),
      BgKostenartID        = CASE WHEN BPO.BgSpezkontoID IS NULL THEN @BgKostenartIDGBL /*Einzelzahlung vom GBL*/ ELSE COALESCE(SPZ.BgKostenartID, BPA.BgKostenartID,/*ToDo*/@BgKostenartIDGBL) END,
      Einnahme             = 0,
      BPO.BgKategorieCode, BPO.BgSpezkontoID,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      INNER JOIN @PersonVerrechnung  SPP ON (SPP.BaPersonID       = BPO.BaPersonID OR BPO.BaPersonID IS NULL)
      LEFT  JOIN BgSpezkonto         SPZ ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      LEFT  JOIN BgPositionsart      BPA ON  BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
      LEFT  JOIN BgKostenart         BKA ON  BKA.BgKostenartID    = BPA.BgKostenartID
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND BPO.BgKategorieCode = 101 /*Einzelzahlung*/
      AND BPO.BelegVorhanden = 0 -- noch kein verbuchter Beleg

  -- Einnahmen aus Abzügen von Verrechnungs-/Abzahlungskonti
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, Kostenstelle, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, BgSpezkontoID, VerwaltungSD, KbBuchungStatusCode, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, -BPO.Betrag * CASE WHEN SPZ.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, -BPO.Betrag * CASE WHEN SPZ.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      Kostenstelle         = @Kostenstelle,
      SPZ.BgPositionsartID,
      IsNull(BPO.Buchungstext, IsNull('Abzug aus Spezialkonto "' + SPZ.NameSpezkonto + '"', BPA.Name)),
      BgKostenartID        = CASE WHEN BPO.BgSpezkontoID IS NULL THEN @BgKostenartIDGBL /*Einzelzahlung vom GBL*/ ELSE COALESCE(BPA.BgKostenartID, SPZ.BgKostenartID, /*ToDo*/@BgKostenartIDGBL) END,
      Einnahme             = 1,
      BPO.BgKategorieCode, BPO.BgSpezkontoID,
      VerwaltungSD         = 0, -- Abzüge werden gleich behandelt wie nicht abgetretene Einkommen
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      INNER JOIN BgSpezkonto         SPZ ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      INNER JOIN @PersonVerrechnung  SPP ON (SPP.BaPersonID       = SPZ.BaPersonID OR SPZ.BaPersonID IS NULL)
      LEFT  JOIN BgPositionsart      BPA ON  BPA.BgPositionsartID = SPZ.BgPositionsartID AND BPA.BgKategorieCode = BPO.BgKategorieCode
      LEFT  JOIN BgKostenart         BKA ON  BKA.BgKostenartID    = IsNull(BPA.BgKostenartID,SPZ.BgKostenartID)
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND BPO.BgKategorieCode IN (3 /*Abzahlung*/) --AND SPZ.OhneEinzelzahlung = 1
      AND BPO.BelegVorhanden = 0 -- noch kein verbuchter Beleg


--SELECT * FROM #Buchungen

/*
  DECLARE @ZuErzeugendeVerbuchteEinnahmen TABLE (
    ID int NOT NULL IDENTITY(1, 1),
    BgPositionID int NULL,
    BgKostenartID int NULL,
    BaPersonID int NULL,
    ValutaDatum datetime NULL,
    Betrag money NULL,
    [Text] varchar(100) NULL
  )
  INSERT INTO @ZuErzeugendeVerbuchteEinnahmen(BgPositionID, BgKostenartID, BaPersonID, ValutaDatum, Betrag, [Text])
    SELECT DISTINCT BPO.BgPositionID, SPZ.BgKostenartID, SPP.BaPersonID, @FirstDayInMonth, CONVERT(money, BPO.Betrag * CASE WHEN SPZ.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END), SPZ.NameSpezkonto
    FROM BgPosition                  BPO
      INNER JOIN BgSpezkonto         SPZ ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      INNER JOIN @PersonVerrechnung  SPP ON (SPP.BaPersonID       = SPZ.BaPersonID OR SPZ.BaPersonID IS NULL)
      INNER JOIN BgPositionsart      BPA ON  BPA.BgPositionsartID = SPZ.BgPositionsartID AND BPA.BgKategorieCode = BPO.BgKategorieCode
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND BPO.BgKategorieCode IN (3 /*Abzahlung*/) --AND SPZ.OhneEinzelzahlung = 1
      AND BPO.BelegVorhanden = 0 -- noch kein verbuchter Beleg
      AND BPO.BgPositionID = IsNull(@BgPositionID_IN,BPO.BgPositionID) -- für Einzelposition
*/
--select '@ZuErzeugendeVerbuchteEinnahmen', * from @ZuErzeugendeVerbuchteEinnahmen

  /************************************************************************************************/
  /* Auszahlbetrag bestimmen                                                                      */
  /************************************************************************************************/
  DECLARE @GetDate datetime
  SET @GetDate = GetDate()

  IF (@BgPositionID_IN IS NULL) BEGIN
    SELECT @TotalBetrag = SUM(IsNull(Total, -Betrag))
    FROM dbo.fnWhGetBudgetUebersicht(@BgBudgetID, @GetDate)
    WHERE Rec_ID IN (-20, -21)
  END
  ELSE BEGIN
    SELECT @TotalBetrag = SUM(Betrag)
    FROM #vwBgPosition
  END


  -- Alle Buchungen über @BuchungenID sind Netto-Buchungen (Umbuchungen)
  SELECT @BuchungenID = MAX(BuchungenID) + 1 FROM #Buchungen

  -- Zahlungen an Klient
  -- Default ist für jede Buchung eingetragen, dass sie an Dritte geht
  -- Hier wird Dritte = 0, wenn die Zahlung an einen Zahlungsweg geht, der einer unterstützten Person im Finanzplan geht
  UPDATE TMP
    SET Dritte = 0
  FROM #Buchungen  TMP
    INNER JOIN BgAuszahlungPerson  BAP ON BAP.BgPositionID     = TMP.BgPositionID AND (BAP.BaPersonID = TMP.BaPersonID_Teil OR BAP.BaPersonID IS NULL)
    LEFT  JOIN BaZahlungsweg       BZW ON BZW.BaZahlungswegID  = BAP.BaZahlungswegID
    LEFT  JOIN BgPositionsart      BPA ON BPA.BgPositionsartID = TMP.BgPositionsartID
    LEFT  JOIN XLOVCode            XLC ON XLC.LOVName = 'BgGruppe' AND XLC.Code = BPA.BgGruppeCode
  WHERE (BZW.BaPersonID IS NULL AND BAP.KbAuszahlungsArtCode = 103 /* Cash an Klient */)
          OR BZW.BaPersonID IN (SELECT FPP.BaPersonID
                                FROM   BgFinanzplan_BaPerson  FPP
                                WHERE  FPP.BgFinanzplanID = @BgFinanzplanID AND FPP.IstUnterstuetzt = 1)

  UPDATE #Buchungen
  SET Dritte = 0
  WHERE GBLAufAusgabeKonto = 1

--SELECT 'Buchungen', * FROM #Buchungen


IF(@BgPositionID_IN IS NULL) BEGIN -- für Einzelposition

  -- Achtung Schönwetterprogrammierer: jetzt Augen schliessen und 20 Zeilen weiter unten wieder öffnen
  -- Dieser HACK sorgt dafür, dass das VVG gerecht vom GBL abgezogen wird
  -- Problem: In BetragBudget der GBL-BgPosition sind bereits alle VVGs abgezogen. BetragBudget wird aber wiederum von anderen Positionen benötigt, da so z.B. nicht übernommene Mieten korrekt abgehandelt werden
  ------ [Total GBL] - [Total VVG] = [BetragBudget]
  -- Deshalb werden hier zuerst die gequoteten GBL-Positionen um den Durchschnitt erhöht
  ------ [GBL P1] + [VVG Durchschnitt] = [GBL P1 temp]
  ------ [GBL P2] + [VVG Durchschnitt] = [GBL P2 temp]
  -- Danach werden die Personenbezogenen VVGs abgezogen
  ------ [GBL P1 temp] - [VVG P1] = [GBL P1 VVG-bereinigt]
  ------ [GBL P2 temp] - [VVG P2] = [GBL P2 VVG-bereinigt]
  -- voila...
  SELECT BgBudgetID, BaPersonID, BetragBudget = SUM(BetragBudget)
  INTO #VVG
  FROM #vwBgPosition
  WHERE BgPositionsartID IN (32021, 32022 /* VVG */)
    AND MaxBeitragSD = $0.00 --AND BgSpezkontoID IS NULL
    AND BgBudgetID = @BgBudgetID
  GROUP BY BgBudgetID, BaPersonID

--SELECT * FROM #VVG

  DECLARE @VVGDurchschnittBetrag money
  SELECT @VVGDurchschnittBetrag = SUM(BetragBudget) / COUNT(*) FROM #VVG
/*
SELECT *
  FROM #Buchungen                  TMP
    LEFT  JOIN #VVG  VVG ON VVG.BgBudgetID = @BgBudgetID AND VVG.BaPersonID = TMP.BaPersonID_Teil
    INNER JOIN @PersonVerrechnung  SPP ON SPP.BaPersonID = TMP.BaPersonID_Teil
    INNER JOIN (SELECT SUM(BetragBudget) AS SumBetrag
                FROM #vwBgPosition
                WHERE BgBudgetID = @BgBudgetID AND BgPositionsartID IN (32021, 32022 /* VVG */)
                  AND MaxBeitragSD = $0.00 /*AND BgSpezkontoID IS NULL*/) TOT ON 1 = 1
  WHERE TMP.BgPositionsartID = @BgPositionsartIDGBL
*/
  -- Korrektur Grundbedarf VVG-Abzug
  UPDATE TMP
    SET BetragBrutto = TMP.BetragBrutto - IsNull(VVG.BetragBudget, $0.00) + @VVGDurchschnittBetrag,
        BetragNetto  = TMP.BetragNetto  - IsNull(VVG.BetragBudget, $0.00) + @VVGDurchschnittBetrag
  FROM #Buchungen                  TMP
    LEFT  JOIN #VVG                VVG ON VVG.BgBudgetID = @BgBudgetID AND VVG.BaPersonID = TMP.BaPersonID_Teil
    INNER JOIN @PersonVerrechnung  SPP ON SPP.BaPersonID = TMP.BaPersonID_Teil
  WHERE @VVGDurchschnittBetrag > $0.00 AND TMP.BgPositionsartID = @BgPositionsartIDGBL

  DROP TABLE #VVG

/*
  -- VVG Brutto-Betrag korrigieren
  UPDATE TMP
    SET BetragBrutto = $0.00
  FROM #Buchungen            TMP
    INNER JOIN #vwBgPosition VVG ON VVG.BgBudgetID = @BgBudgetID AND VVG.BgPositionID = TMP.BgPositionID
                                AND VVG.BgPositionsartID IN (32021, 32022 /* VVG */)
                                AND VVG.MaxBeitragSD = $0.00 AND VVG.BgSpezkontoID IS NULL
*/
--SELECT 'VVG - Korrektur', * FROM #Buchungen

  /************************************************************************************************/
  /* Abzüge und Ausgaben an Dritte                                                                */
  /************************************************************************************************/
  DECLARE @Abzuege TABLE (
    BgPositionID       int NULL,     -- Herkunft,    "Abzugsverursacher"
    BgPositionID_Abzug int NULL,     -- Erstes Ziel  "erstes Abzugsopfer"
    BaPersonID         int NULL,     -- gequotete Person
    BetragNetto        money NOT NULL DEFAULT($0.00),  -- gequoteter Betrag, der (noch) abgezogen wird. Bei erfolgtem Abzug wird dieser reduziert
    BetragNettoAbzug   money NOT NULL DEFAULT($0.00),  -- Hilfsfeld für direkte Abzüge (Bsp. Einkommen <-> EFB)
    BetragBrutto       money NOT NULL DEFAULT($0.00),
    BetragBruttoAbzug  money NOT NULL DEFAULT($0.00),
    BgKostenartID      int NULL,        -- des "Verursachers"
    Buchungstext       varchar(200) COLLATE DATABASE_DEFAULT NULL,
    BgKategorieCode    int
  )

  DECLARE @LoopCount int
  SET @LoopCount = 0
  -- Einkommen nicht vom Sozialdienst verwaltet (bewirken, dass weniger ausbezahlt wird, da der Klient das Geld direkt erhält)
  INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext, BgKategorieCode)
    SELECT BUC.BgPositionID, BUC.BaPersonID_Teil, -BUC.BetragBrutto, BUC.BgKostenartID, BUC.Name, BUC.BgKategorieCode
    FROM #Buchungen            BUC
      LEFT JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BUC.BgPositionsartID
    WHERE BUC.Einnahme = 1 /*Einnahmen*/ AND BUC.VerwaltungSD = 0 AND BUC.BgKategorieCode IN (1, 3) /* Einnahmen, Verrechnung */

/*
SELECT 'Vor Abzug', * FROM #Buchungen
SELECT 'Vor Abzug', * FROM @Abzuege
*/
  WHILE 1 = 1 BEGIN
    SET @LoopCount = @LoopCount + 1

    -- Für nicht gequotete Einnahmen wird hier noch gequotet
    INSERT INTO @Abzuege
      SELECT ABZ.BgPositionID, ABZ.BgPositionID_Abzug, PVR.BaPersonID,
        ABZ.BetragNetto  * PVR.PersonFactor, $0.00,
        ABZ.BetragBrutto * PVR.PersonFactor, $0.00,
        ABZ.BgKostenartID, ABZ.Buchungstext, ABZ.BgKategorieCode
      FROM @Abzuege  ABZ, @PersonVerrechnung  PVR
      WHERE ABZ.BaPersonID IS NULL

    -- nicht gequotete Einträge löschen
    DELETE FROM @Abzuege WHERE BaPersonID IS NULL

    -- Spezialfall: Sanktion abziehen
    UPDATE ABZ
      SET BgPositionID_Abzug = BUC.BgPositionID
    FROM @Abzuege           ABZ
      INNER JOIN #Buchungen BUC ON BUC.BgKostenartID = ABZ.BgKostenartID AND BUC.BaPersonID_Teil = ABZ.BaPersonID AND BUC.BgKategorieCode IN (2,100) /*Ausgaben, Zusätzliche Leistungen*/
    WHERE ABZ.BgKategorieCode = 4 AND BgPositionID_Abzug IS NULL


    -- Bei direkt verrechenbaren Abzügen bleibt die PositionsID gleich
    UPDATE @Abzuege
      SET BgPositionID_Abzug = BgPositionID
    WHERE BgPositionID_Abzug IS NULL


    -- Abzüge direkte
    UPDATE ABZ
      SET BetragNettoAbzug  = CASE
                                WHEN TMP.Dritte = 1               THEN $0.00  -- Auszahlungen an Dritte
                                WHEN TMP.BgKategorieCode <> 2     THEN $0.00  -- Nur bei Auszahlung Direkter Abzug
                                WHEN GRP.SumBetragNetto = $0.00   THEN $0.00
                                ELSE CONVERT(money, dbo.fnMIN(ABS(GRP.SumBetragNetto), ABS(TMP.BetragNetto))) * ABZ.BetragNetto / GRP.SumBetragNetto
                              END,
          BetragBruttoAbzug = CASE
                                WHEN GRP.SumBetragBrutto = $0.00  THEN $0.00
                                ELSE CONVERT(money, dbo.fnMIN(ABS(GRP.SumBetragBrutto), ABS(TMP.BetragBrutto))) * ABZ.BetragBrutto / GRP.SumBetragBrutto
                              END
    FROM @Abzuege            ABZ
      INNER JOIN #Buchungen  TMP ON TMP.BgPositionID = ABZ.BgPositionID_Abzug AND TMP.BaPersonID_Teil = ABZ.BaPersonID
      INNER JOIN (SELECT BgPositionID_Abzug, BaPersonID,
                    SumBetragNetto = SUM(BetragNetto),
                    SumBetragBrutto = SUM(BetragBrutto)
                  FROM @Abzuege
                  GROUP BY BgPositionID_Abzug, BaPersonID
                 )           GRP ON GRP.BgPositionID_Abzug = ABZ.BgPositionID_Abzug AND GRP.BaPersonID = ABZ.BaPersonID
    WHERE TMP.Einnahme = 0 AND (GRP.SumBetragNetto > $0.00 OR GRP.SumBetragBrutto > $0.00 OR ABZ.BgKategorieCode = 4)

    -- Abzugsursache abziehen (Bsp EFB) -> netto
    UPDATE TMP
      SET BetragNetto  = TMP.BetragNetto - CASE WHEN TMP.Dritte = 0 AND TMP.Einnahme = 0 THEN ABZ.SumBetragNettoAbzug ELSE $0.00 END,
          BetragBrutto = TMP.BetragBrutto - ABZ.SumBetragBruttoAbzug
    FROM #Buchungen  TMP
      INNER JOIN (SELECT BgPositionID_Abzug, BaPersonID,
                    SumBetragNettoAbzug = SUM(BetragNettoAbzug),
                    SumBetragBruttoAbzug = SUM(BetragBruttoAbzug)
                  FROM @Abzuege
                  --WHERE BgPositionID_Abzug = BgPositionID
                  GROUP BY BgPositionID_Abzug, BaPersonID
                 )   ABZ ON ABZ.BgPositionID_Abzug = TMP.BgPositionID AND ABZ.BaPersonID = TMP.BaPersonID_Teil
    WHERE TMP.BuchungenID < @BuchungenID

    -- Erstellen der Sollbuchungen für Direktabzüge
    INSERT INTO #Buchungen (BgPositionID, BgKostenartID, Name, BaPersonID_Teil, BetragBrutto, BetragNetto, KbBuchungStatusCode)
      SELECT ABZ.BgPositionID, ABZ.BgKostenartID, ABZ.Buchungstext + ' (direkt)', ABZ.BaPersonID,
        $0.00, ABZ.BetragNettoAbzug, TMP.KbBuchungStatusCode
      FROM #Buchungen          TMP
        INNER JOIN @Abzuege    ABZ ON ABZ.BgPositionID_Abzug = TMP.BgPositionID AND ABZ.BaPersonID = TMP.BaPersonID_Teil
        INNER JOIN #Buchungen  HAB ON HAB.BgPositionID = ABZ.BgPositionID AND HAB.BaPersonID_Teil = ABZ.BaPersonID AND HAB.Einnahme = 0
      WHERE TMP.BuchungenID < @BuchungenID AND TMP.Dritte = 0 AND TMP.Einnahme = 0 AND ABZ.BetragNettoAbzug > $0.00
        AND ABZ.BgPositionID_Abzug <> ABZ.BgPositionID

    -- Abzugsopfer abziehen (Bsp Einkommen) -> netto
    UPDATE TMP
      SET BetragNetto  = TMP.BetragNetto  + ABZ.SumBetragNettoAbzug,
          BetragBrutto = TMP.BetragBrutto + ABZ.SumBetragBruttoAbzug
    FROM #Buchungen  TMP
      INNER JOIN (SELECT BgPositionID, BaPersonID,
                    SumBetragNettoAbzug = SUM(BetragNettoAbzug),
                    SumBetragBruttoAbzug = SUM(BetragBruttoAbzug)
                  FROM @Abzuege
                  GROUP BY BgPositionID, BaPersonID
                 )   ABZ ON ABZ.BgPositionID = TMP.BgPositionID AND ABZ.BaPersonID = TMP.BaPersonID_Teil
    WHERE TMP.BuchungenID < @BuchungenID AND TMP.Einnahme = 1
/*
IF EXISTS (SELECT * FROM @Abzuege WHERE BetragNettoAbzug > $0.00 OR BetragBruttoAbzug > $0.00) BEGIN
  SELECT 'Nach Abzug Direkt, Loop: ' + CONVERT(varchar, @LoopCount), * FROM @Abzuege
  SELECT 'Nach Abzug Direkt, Loop: ' + CONVERT(varchar, @LoopCount), * FROM #Buchungen
END
*/

    UPDATE @Abzuege
      SET BgPositionID_Abzug = BgPositionID,
        BetragNetto  = CASE WHEN BgKategorieCode = 4 THEN BetragNetto  + BetragNettoAbzug  ELSE BetragNetto  - BetragNettoAbzug  END, BetragNettoAbzug  = $0.00,
        BetragBrutto = CASE WHEN BgKategorieCode = 4 THEN BetragBrutto + BetragBruttoAbzug ELSE BetragBrutto - BetragBruttoAbzug END, BetragBruttoAbzug = $0.00


    IF @LoopCount = 1 BEGIN
      IF --1=1 OR
         IsNull(dbo.fnXConfig('System\Sozialhilfe\Belege\LineareEinkommensverteilung', @RefDate), 0) = 1 BEGIN
        -- Einkommen auf alle Ausgaben verteilen
        UPDATE @Abzuege SET BgPositionID_Abzug = NULL

        -- Ausnahmen beim Verteilen: KVG (32020), EFB(32020/32025; da bereits verrechnet), Einzelzahlungen
        SELECT BgPositionID, BaPersonID_Teil, BetragNetto
        INTO #Ausgaben
        FROM #Buchungen            TMP
          LEFT JOIN BgPositionsart BPA ON BPA.BgPositionsartID = TMP.BgPositionsartID
        WHERE BetragNetto > $0.00 AND Einnahme = 0
          AND TMP.BgPositionsartID NOT IN (32020/*, 32021*/) AND BPA.BgKategorieCode NOT IN (100,101) /* Keine Einzelzahlungen */
          AND BPA.BgGruppeCode NOT IN (39030, 39035) /* EFB */

        INSERT INTO @Abzuege
          SELECT ABZ.BgPositionID, TMP.BgPositionID, TMP.BaPersonID_Teil, ABZ.BetragNetto * TMP.BetragNetto / SBG.SumBetrag, $0.00, $0.00, $0.00, ABZ.BgKostenartID, ABZ.Buchungstext
          FROM #Ausgaben        TMP
            INNER JOIN @Abzuege ABZ ON ABZ.BaPersonID = TMP.BaPersonID_Teil AND ABZ.Betrag > $0.00
            INNER JOIN (SELECT BaPersonID_Teil, SUM(BetragNetto) AS SumBetrag
                        FROM #Ausgaben
                        GROUP BY BaPersonID_Teil) SBG ON SBG.BaPersonID_Teil = TMP.BaPersonID_Teil

        DROP TABLE #Ausgaben

        UPDATE @Abzuege SET BetragNetto = $0.00 WHERE BgPositionID_Abzug IS NULL
      END

      -- Einzelzahlungen von Grundbedarf
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BetragBrutto, BgKostenartID, Buchungstext, BgKategorieCode)
        SELECT BPO.BgPositionID, BPO.BaPersonID, BPO.Betrag, BPO.Betrag, @BgKostenartIDGBL, BPO.Buchungstext + ' (finanziert vom GBL)', 101
        FROM #vwBgPosition BPO
        WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgSpezkontoID IS NULL AND BPO.BgKategorieCode = 101 /* Einzelzahlung aus Grundbedarf */

      -- Kürzungen / Spezialkonto
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BetragBrutto, BgKostenartID, Buchungstext, BgKategorieCode)
/*
        SELECT BPO.BgPositionID, BPO.BaPersonID, BPO.BetragBudget, BPO.BetragBudget,
          BKA.BgKostenartID, IsNull(BSK.NameSpezkonto, BPO.Buchungstext) + IsNull( ' (' + LOV.Text + ')', '')
        FROM #vwBgPosition          BPO
          LEFT  JOIN BgSpezkonto    BSK ON BSK.BgSpezkontoID = BPO.BgSpezkontoID
          LEFT  JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BSK.BgPositionsartID
          LEFT  JOIN BgKostenart    BKA ON BKA.BgKostenartID = IsNull(BSK.BgKostenartID, @BgKostenartIDGBL)
          LEFT  JOIN XLOVCode       LOV ON LOV.LOVName = 'BgKategorie' AND LOV.Code = BPO.BgKategorieCode
        WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (3, 4, 6) /* 3:Abzahlung, 4:Kürzung, 6:Vorabzug */
          AND NOT (BPO.BgKategorieCode = 3 AND IsNull(BPA.BgKategorieCode, 0) = 3 /*AND BSK.OhneEinzelzahlung = 1*/) -- Verrechnung mit Sollstellung
*/
        SELECT BPO.BgPositionID, SPP.BaPersonID,
          BetragNetto  = CONVERT(money, -BPO.BetragBudget * CASE WHEN BPO.BaPersonID IS NULL OR BKA.Quoting = 1 THEN SPP.PersonFactor ELSE 1.0 END),
          BetragBrutto = CONVERT(money, -BPO.BetragBudget * CASE WHEN BPO.BaPersonID IS NULL OR BKA.Quoting = 1 THEN SPP.PersonFactor ELSE 1.0 END),
          BKA.BgKostenartID, IsNull(BSK.NameSpezkonto, BPO.Buchungstext) + IsNull( ' (' + LOV.Text + ')', ''), BPO.BgKategorieCode
        FROM #vwBgPosition              BPO
          LEFT  JOIN BgSpezkonto        BSK ON BSK.BgSpezkontoID = BPO.BgSpezkontoID
          LEFT  JOIN BgPositionsart     BPA ON BPA.BgPositionsartID = IsNull(BSK.BgPositionsartID, BPO.BgPositionsartID)
          LEFT  JOIN BgKostenart        BKA ON BKA.BgKostenartID = COALESCE(BSK.BgKostenartID, BPA.BgKostenartID, @BgKostenartIDGBL)
          LEFT  JOIN XLOVCode           LOV ON LOV.LOVName = 'BgKategorie' AND LOV.Code = BPO.BgKategorieCode
         INNER JOIN @PersonVerrechnung  SPP ON ((BKA.Quoting = 1 AND BPA.BgPositionsartID <> 32021) OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                                 SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                                 BPO.BaPersonID IS NULL)            /* normales Quoting */
        WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (3, 4, 6) /* 3:Abzahlung, 4:Kürzung, 6:Vorabzug */
          AND NOT (BPO.BgKategorieCode = 3 AND IsNull(BPA.BgKategorieCode, 0) = 3 /*AND BSK.OhneEinzelzahlung = 1*/) -- Verrechnung mit Sollstellung

      -- Nicht übernommene Ausgaben 
      -- Bsp Miete 1300.- (wird dem Vermieter ausbezahlt), SD übernimmt aber nur 1000.- -> 300.- müssen sonstwo abgezogen werden werden
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext, BgKategorieCode)
        SELECT BPO.BgPositionID, BPO.BaPersonID, BPO.BetragRechnung - BPO.BetragBudget, BPA.BgKostenartID, BPA.Name + ' (nicht vom SD übernommen)', BPO.BgKategorieCode
        FROM #vwBgPosition  BPO
          INNER JOIN BgPositionsart BPA ON BPO.BgPositionsartID = BPA.BgPositionsartID
        WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2 /* Ausgaben */
          AND BPO.BetragRechnung > BPO.BetragBudget

      IF IsNull(dbo.fnXConfig('System\Sozialhilfe\Belege\KostendachMiete', @RefDate), 0) = 1 BEGIN
        -- Falls mehr Geld für Miete vorhanden ist als bezahlt werden soll, wird dieses Geld auf andere Miet-Abzüge (bsp Nebenkosten) verteilt (Abzüge werden reduziert)
        UPDATE TMP
          SET BetragNetto = CONVERT(money, dbo.fnMAX(TMP.BetragNetto -
            IsNull((SELECT SUM(BPO.BetragBudget - BPO.BetragRechnung)
                    FROM #vwBgPosition          BPO
                      INNER JOIN WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID AND SPT.BgGruppeCode = 3206 /* Miete */
                    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2 /* Ausgaben */
                      AND BPO.BetragRechnung < BPO.BetragBudget), $0.00), $0.00))
        FROM @Abzuege               TMP
          INNER JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = TMP.BgPositionID
          INNER JOIN WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID AND SPT.BgGruppeCode = 3206  /* Miete */
      END


      -- SKOS2005 - EFB / Zulagen Limite
      -- Falls mehr Zulagen bezahlt werden sollen als die Limite erlaubt, wird die Differenz ebenfalls abgezogen
      DECLARE @SumZulage money, @Limit money

      SELECT @SumZulage = SUM(BPO.BetragBudget)
      FROM #vwBgPosition  BPO
        INNER JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
      WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2
        AND BPA.BgGruppeCode BETWEEN 39000 AND 39999 /* EFB, IZU, MIZ */

      IF @SumZulage > $0.00 BEGIN
        SELECT TOP 1 @Limit = CONVERT(money, CFG.ValueVar)
        FROM dbo.fnXConfigChild('System\Sozialhilfe\SKOS2005\Abzug_Limit\', @RefDate)  CFG
        WHERE CONVERT(int, CFG.Child) <= (SELECT UeGrundbedarf FROM dbo.fnWhKennzahlen(@BgFinanzplanID) KNZ)
        ORDER BY CFG.Child DESC

        IF @SumZulage > @Limit BEGIN
          INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BetragBrutto, BgKategorieCode)
            SELECT BPO.BgPositionID, BPO.BaPersonID,
              BPO.Betrag - (BPO.Betrag * @Limit / @SumZulage),
              BPO.Betrag - (BPO.Betrag * @Limit / @SumZulage), BUC.BgKategorieCode
            FROM #vwBgPosition  BPO
              INNER JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
            WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2 -- Ausgaben
              AND BPA.BgGruppeCode BETWEEN 39000 AND 39999 /* EFB, IZU, MIZ */
        END
      END
    END ELSE
      BREAK
  END

/*
SELECT 'Ende Abzug Direkt', * FROM @Abzuege
SELECT 'Ende Abzug Direkt', * FROM #Buchungen
*/

  -- Abzüge von GB
  DECLARE @AbzugBetragNetto         money,
          @AbzugBetragBrutto        money,
          @AbzugFactorNetto         real,
          @AbzugFactorBrutto        real

  DECLARE @BaPersonID               int,
          @BgKostenartID            int,
          @BgPositionsartID         int,

          @BgPositionID             int,
          @AbzugGruppeBetragNetto   money,
          @AbzugGruppeNettoGleich   bit,
          @AbzugGruppeBetragBrutto  money,
          @AbzugGruppeBruttoGleich  bit,
          @AbzugGruppeCount         int,

          @AbzBgPositionID          int,
          @AbzBaPersonID            int,
          @AbzBetragNetto           money,
          @AbzBetragBrutto          money,
          @AbzBgKostenartID         int,
          @AbzBuchungstext          varchar(200)


-- Negative Einkommen dem GBL dazuzählen
-- HACK, eigentlich sollte das auch über die Schlaufen gleich unten funktionieren...
  DECLARE @SummeNegEinkommen money, @SummeGejoined money

  SELECT @SummeNegEinkommen = SUM(BetragNetto)
  FROM @Abzuege
  WHERE BgKategorieCode = 1 AND BetragNetto < $0.00

  SELECT @SummeGejoined = SUM(ABZ.BetragNetto)
  FROM @Abzuege           ABZ
    INNER JOIN #Buchungen BUC ON BUC.BgPositionID = @BgPositionIDGBL AND BUC.BaPersonID_Teil = ABZ.BaPersonID
  WHERE ABZ.BgKategorieCode = 1 AND ABZ.BetragNetto < $0.00

  IF ( @SummeGejoined <> @SummeNegEinkommen ) BEGIN
    SET @msg = 'Die negativen gequoteten Einkommen können nicht entsprechenden GBL-Position zugeordnet werden'
    RAISERROR(@msg, 18, 1)
    RETURN -1
  END

  -- GBL erhöhen
  UPDATE BUC
  SET BUC.BetragNetto = BUC.BetragNetto - ABZ.BetragNetto
  FROM #Buchungen       BUC
    INNER JOIN (SELECT BaPersonID, BetragNetto = SUM(BetragNetto) FROM @Abzuege WHERE BgKategorieCode = 1 AND BetragNetto < $0.00 GROUP BY BaPersonID ) ABZ ON BUC.BgPositionID = @BgPositionIDGBL AND BUC.BaPersonID_Teil = ABZ.BaPersonID
  WHERE ABZ.BetragNetto < $0.00

  -- Buchung kurzen, die den Abzug verursacht hat (negatives Einkommen)
  UPDATE BUC
  SET BUC.BetragNetto = BUC.BetragNetto + ABZ.BetragNetto
  FROM #Buchungen       BUC
    INNER JOIN @Abzuege ABZ ON ABZ.BgPositionID = BUC.BgPositionID AND ABZ.BaPersonID = BUC.BaPersonID_Teil
  WHERE ABZ.BgKategorieCode = 1 AND ABZ.BetragNetto < $0.00

  -- Abzüge leeren
  UPDATE @Abzuege
  SET BetragNetto = $0.00
  WHERE BgKategorieCode = 1 AND BetragNetto < $0.00

/*
SELECT '#Buchungen', *FROM #Buchungen
SELECT '@Abzuege', *FROM @Abzuege

    SELECT 'cAbzugNetto', BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE ABS(BetragNetto) > $0.00
    ORDER BY BetragNetto

    SELECT 'cAbzugBrutto', BgPositionID, BaPersonID, BetragBrutto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE ABS(BetragBrutto) > $0.00
*/

  SET @LoopCount = 0

  DECLARE @RepeatLoop bit
  SET @RepeatLoop = 0

  DECLARE cAbzugNetto CURSOR FOR
    SELECT BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE BetragNetto > $0.00
--  FOR UPDATE OF BetragNetto

  DECLARE cAbzugBrutto CURSOR FOR
    SELECT BgPositionID, BaPersonID, BetragBrutto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE BetragBrutto > $0.00
--  FOR UPDATE OF BetragBrutto

  WHILE @LoopCount < 6 BEGIN
    IF @RepeatLoop = 0
      SET @LoopCount = @LoopCount + 1

    SET @RepeatLoop = 0
-- Reihenfolgen: 1,2(Person/Kostenart), 3,4(Person), 5,6(Finanzplan)
/*
      SELECT @LoopCount, CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgPositionID, COUNT(*),
        SUM(TMP.BetragNetto),  CASE WHEN MIN(TMP.BetragNetto)  = MAX(TMP.BetragNetto)  THEN 1 ELSE 0 END,
        SUM(TMP.BetragBrutto), CASE WHEN MIN(TMP.BetragBrutto) = MAX(TMP.BetragBrutto) THEN 1 ELSE 0 END
      FROM #Buchungen  TMP
        LEFT  JOIN WhPositionsart   SPT ON SPT.BgPositionsartID = TMP.BgPositionsartID
        LEFT  JOIN XLOVCode         XLC ON XLC.LOVName = 'BgGruppe' AND XLC.Code = SPT.BgGruppeCode
      WHERE (@LoopCount % 2 = 0 OR TMP.Dritte = 0) AND (@LoopCount IN (3, 4, 5, 6) OR TMP.BgKategorieCode NOT IN (100, 101))
      GROUP BY CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgKategorieCode, TMP.BgPositionID
      ORDER BY CASE WHEN TMP.BgKategorieCode IN (100,101) THEN TMP.BgKategorieCode ELSE 1 END    -- Einzelzahlungen zuletzt kürzen
         , MIN(CASE WHEN SPT.BgGruppeCode = 3202 THEN 9999 ELSE 0 END)                           -- KVG / VVG als letzte BgPosition kürzen
         , MIN(CASE WHEN SPT.BgGruppeCode BETWEEN 3900 AND 3999 THEN SPT.SortKey ELSE 9999 END)  -- SKOS2005 Zulagen
         , MIN(IsNull(XLC.SortKey, 9999)), MIN(SPT.SortKey) DESC
         , CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END
*/
    DECLARE cBuchung CURSOR FAST_FORWARD FOR
      SELECT CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgPositionID, COUNT(*),
        SUM(TMP.BetragNetto),  CASE WHEN MIN(TMP.BetragNetto)  = MAX(TMP.BetragNetto)  THEN 1 ELSE 0 END,
        SUM(TMP.BetragBrutto), CASE WHEN MIN(TMP.BetragBrutto) = MAX(TMP.BetragBrutto) THEN 1 ELSE 0 END
      FROM #Buchungen  TMP
        LEFT  JOIN WhPositionsart   SPT ON SPT.BgPositionsartID = TMP.BgPositionsartID
        LEFT  JOIN XLOVCode         XLC ON XLC.LOVName = 'BgGruppe' AND XLC.Code = SPT.BgGruppeCode
      WHERE (@LoopCount % 2 = 0 OR TMP.Dritte = 0) AND (@LoopCount IN (3, 4, 5, 6) OR TMP.BgKategorieCode NOT IN (100, 101))
      GROUP BY CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgKategorieCode, TMP.BgPositionID
      ORDER BY CASE WHEN TMP.BgKategorieCode IN (100, 101) THEN TMP.BgKategorieCode ELSE 1 END   -- Einzelzahlungen zuletzt kürzen
         , MIN(CASE WHEN SPT.BgGruppeCode = 3202 THEN 9999 ELSE 0 END)                           -- KVG / VVG als letzte BgPosition kürzen
         , MIN(CASE WHEN SPT.BgGruppeCode BETWEEN 3900 AND 3999 THEN SPT.SortKey ELSE 9999 END)  -- SKOS2005 Zulagen
         , MIN(IsNull(XLC.SortKey, 9999)), MIN(SPT.SortKey) DESC
         , CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END

    OPEN cBuchung
    OPEN cAbzugNetto
    OPEN cAbzugBrutto
    SELECT @AbzBetragNetto  = $0.00, @AbzugGruppeBetragNetto  = $0.00, @AbzugFactorNetto  = 1,
           @AbzBetragBrutto = $0.00, @AbzugGruppeBetragBrutto = $0.00, @AbzugFactorBrutto = 1
--SELECT 'LoopCount' = @LoopCount
    WHILE 1 = 1 BEGIN
--      IF ((@LoopCount % 2 = 1 AND @AbzugGruppeBetragNetto <= $0.00) OR (@LoopCount % 2 = 0 AND @AbzugGruppeBetragBrutto <= $0.00)) BEGIN
      IF ((@LoopCount % 2 = 1 AND ABS(@AbzugGruppeBetragNetto) <= $0.01) OR (@LoopCount % 2 = 0 AND ABS(@AbzugGruppeBetragBrutto) <= $0.01)) BEGIN
        FETCH NEXT FROM cBuchung INTO @BaPersonID, @BgKostenartID, @BgPositionsartID, @BgPositionID, @AbzugGruppeCount,
          @AbzugGruppeBetragNetto, @AbzugGruppeNettoGleich, @AbzugGruppeBetragBrutto, @AbzugGruppeBruttoGleich
        IF @@FETCH_STATUS < 0 BREAK
      END

      IF (@LoopCount % 2 = 1) BEGIN  -- Netto
        IF (@AbzBetragNetto <= $0.00) BEGIN
          CLOSE cAbzugNetto
          OPEN cAbzugNetto

          WHILE 1 = 1 BEGIN
            FETCH NEXT FROM cAbzugNetto INTO @AbzBgPositionID, @AbzBaPersonID, @AbzBetragNetto, @AbzBgKostenartID, @AbzBuchungstext
            IF @@FETCH_STATUS < 0 BREAK
--SELECT @AbzBetragNetto, @BgPositionID, @AbzBaPersonID, @BaPersonID, @AbzugGruppeBetragNetto, @AbzugGruppeNettoGleich
            IF (ABS(@AbzBetragNetto) > $0.00
                 AND (@AbzBgKostenartID = @BgKostenartID OR @LoopCount > 2)
                 AND (@AbzBaPersonID    = @BaPersonID    OR @LoopCount > 4)) BREAK
          END
          IF @@FETCH_STATUS < 0 BEGIN
            BREAK
          END
        END


        IF @AbzBetragNetto <= @AbzugGruppeBetragNetto BEGIN
          SELECT @AbzugBetragNetto = @AbzBetragNetto,
                 @AbzugBetragBrutto = $0.00,
                 @AbzugFactorNetto = CONVERT(real, (@AbzugGruppeBetragNetto - @AbzBetragNetto)) / @AbzugGruppeBetragNetto,
                 @AbzugFactorBrutto = 1,
                 @AbzBetragNetto = $0.00
        END ELSE BEGIN
          SELECT @AbzugBetragNetto = @AbzugGruppeBetragNetto,
                 @AbzugBetragBrutto = $0.00,
                 @AbzugFactorNetto = 0,
                 @AbzugFactorBrutto = 1,
                 @AbzBetragNetto = @AbzBetragNetto - @AbzugGruppeBetragNetto
        END

        UPDATE @Abzuege
          SET BetragNetto = @AbzBetragNetto
        WHERE CURRENT OF cAbzugNetto
      END ELSE BEGIN -- Brutto
        IF (@AbzBetragBrutto <= $0.00) BEGIN
          CLOSE cAbzugBrutto
          OPEN cAbzugBrutto

          WHILE 1 = 1 BEGIN
            FETCH NEXT FROM cAbzugBrutto INTO @AbzBgPositionID, @AbzBaPersonID, @AbzBetragBrutto, @AbzBgKostenartID, @AbzBuchungstext
            IF @@FETCH_STATUS < 0 BREAK
            IF (ABS(@AbzBetragBrutto) > $0.00
                 AND (@AbzBgKostenartID = @BgKostenartID OR @LoopCount > 2)
                 AND (@AbzBaPersonID    = @BaPersonID    OR @LoopCount > 4)) BREAK
          END
          IF @@FETCH_STATUS < 0 BEGIN
            BREAK
          END
        END

        IF @AbzBetragBrutto <= @AbzugGruppeBetragBrutto BEGIN
          SELECT @AbzugBetragNetto = $0.00,
                 @AbzugBetragBrutto = @AbzBetragBrutto,
                 @AbzugFactorNetto = 1,
                 @AbzugFactorBrutto = CONVERT(real, (@AbzugGruppeBetragBrutto - @AbzBetragBrutto)) / @AbzugGruppeBetragBrutto,
                 @AbzBetragBrutto = $0.00
        END ELSE BEGIN
          SELECT @AbzugBetragNetto = $0.00,
                 @AbzugBetragBrutto = @AbzugGruppeBetragBrutto,
                 @AbzugFactorNetto = 1,
                 @AbzugFactorBrutto = 0,
                 @AbzBetragBrutto = @AbzBetragBrutto - @AbzugGruppeBetragBrutto
        END

        UPDATE @Abzuege
          SET BetragBrutto = @AbzBetragBrutto
        WHERE CURRENT OF cAbzugBrutto
      END

      DECLARE @Buchung TABLE (
        BuchungenID_SOLL   int,
        BuchungenID_HABEN  int,
        BetragNetto        money,
        BetragBrutto       money)

      DELETE FROM @Buchung

      INSERT INTO @Buchung
        SELECT SOL.BuchungenID, HAB.BuchungenID,
          CASE WHEN @AbzugGruppeNettoGleich  = 1 THEN (@AbzugBetragNetto  / @AbzugGruppeCount) ELSE (-@AbzugFactorNetto  + 1) * SOL.BetragNetto END,
          CASE WHEN @AbzugGruppeBruttoGleich = 1 THEN (@AbzugBetragBrutto / @AbzugGruppeCount) ELSE (-@AbzugFactorBrutto + 1) * SOL.BetragBrutto END
        FROM #Buchungen         SOL
          LEFT  JOIN #Buchungen HAB ON HAB.BgPositionID = @AbzBgPositionID AND HAB.BaPersonID_Teil = @AbzBaPersonID
                                   AND HAB.BuchungenID < @BuchungenID AND (SIGN(SOL.BetragNetto) = SIGN(HAB.BetragNetto) OR HAB.VerwaltungSD = 0)
        WHERE (IsNull(SOL.BgPositionsartID, 0) = IsNull(@BgPositionsartID, 0) AND IsNull(SOL.BgPositionID, 0) = IsNull(@BgPositionID, 0))
          AND SOL.BaPersonID_Teil = IsNull(@BaPersonID, SOL.BaPersonID_Teil) AND (@LoopCount % 2 = 0 OR SOL.Dritte = 0)

      DELETE FROM @Buchung WHERE BetragNetto = $0.00 AND BetragBrutto = $0.00

      SELECT @RepeatLoop = CASE WHEN @RepeatLoop = 0 AND COUNT(*) = 0 THEN 0 ELSE 1 END
      FROM @Buchung

/*
IF( SELECT Count(*) FROM @Buchung )> 0 
SELECT '@RepeatLoop' = @RepeatLoop, '@Buchung', LoopCount = @LoopCount, AbzugBetragNetto = @AbzugBetragNetto, AbzugBetragBrutto = @AbzugBetragBrutto,
  TMP.*, @AbzBuchungstext, SOL.*, HAB.*
FROM @Buchung           TMP
  LEFT JOIN #Buchungen  SOL ON SOL.BuchungenID = BuchungenID_SOLL
  LEFT JOIN #Buchungen  HAB ON HAB.BuchungenID = BuchungenID_Haben
*/
      UPDATE BUC
        SET BetragNetto  = BUC.BetragNetto  - TMP.BetragNetto,
            BetragBrutto = BUC.BetragBrutto - TMP.BetragBrutto
      FROM #Buchungen        BUC
        INNER JOIN (SELECT BuchungenID_SOLL, BetragNetto = SUM(BetragNetto), BetragBrutto = SUM(BetragBrutto)
                    FROM @Buchung B
                    GROUP BY BuchungenID_SOLL) TMP ON TMP.BuchungenID_SOLL = BUC.BuchungenID

      UPDATE BUC
        SET BetragNetto  = BUC.BetragNetto -  (TMP.BetragNetto  * SIGN(BUC.BetragNetto)),
            BetragBrutto = BUC.BetragBrutto - (TMP.BetragBrutto * SIGN(BUC.BetragBrutto))
--        SET BetragNetto  = BUC.BetragNetto -  (TMP.BetragNetto),
--            BetragBrutto = BUC.BetragBrutto - (TMP.BetragBrutto)
      FROM #Buchungen        BUC
        INNER JOIN (SELECT BuchungenID_HABEN, BetragNetto = SUM(BetragNetto), BetragBrutto = SUM(BetragBrutto)
                    FROM @Buchung B
                    GROUP BY BuchungenID_HABEN) TMP ON TMP.BuchungenID_HABEN = BUC.BuchungenID


      INSERT INTO #Buchungen (BgKategorieCode, BgPositionID, BgKostenartID, Name, BaPersonID_Teil, BetragBrutto, BetragNetto, KbBuchungStatusCode)
        SELECT SOL.BgKategorieCode, HAB.BgPositionID, SOL.BgKostenartID, @AbzBuchungstext, SOL.BaPersonID_Teil, TMP.BetragBrutto, TMP.BetragNetto, SOL.KbBuchungStatusCode
        FROM #Buchungen         SOL
          INNER JOIN @Buchung   TMP ON TMP.BuchungenID_SOLL = SOL.BuchungenID
          INNER JOIN #Buchungen HAB ON HAB.BuchungenID = BuchungenID_HABEN
        WHERE HAB.Einnahme = 0

--

/*
      INSERT INTO #Buchungen (BgPositionID, BgKostenartID, Name, BaPersonID_Teil,BgAuszahlungID, BetragBrutto, BetragNetto)
        SELECT @AbzBgPositionID, @AbzBgKostenartID, @AbzBuchungstext, BaPersonID_Teil, TMP.BgAuszahlungID,
          $0.00, CASE WHEN @AbzugGruppeBetragGleich = 1 THEN (@AbzugBetrag / @AbzugGruppeCount) ELSE (-@AbzugFactor + 1) * TMP.BetragNetto END
        FROM #Buchungen      TMP
        WHERE (IsNull(TMP.BgPositionsartID, 0) = IsNull(@BgPositionsartID, 0) AND IsNull(TMP.BgPositionID, 0) = IsNull(@BgPositionID, 0))
          AND TMP.BaPersonID_Teil = IsNull(@BaPersonID, TMP.BaPersonID_Teil) AND TMP.Dritte = 0
*/


      SELECT @AbzugGruppeBetragNetto  = @AbzugGruppeBetragNetto  - @AbzugBetragNetto,
             @AbzugGruppeBetragBrutto = @AbzugGruppeBetragBrutto - @AbzugBetragBrutto
--ToDo: ob das wohl so klappt?
      SELECT @AbzugGruppeBetragNetto  = $0.00,
             @AbzugGruppeBetragBrutto = $0.00

      IF (@LoopCount % 2 = 1) BEGIN  -- Netto
        UPDATE @Abzuege
          SET BetragNetto = @AbzBetragNetto
        WHERE CURRENT OF cAbzugNetto
        SET @AbzBetragNetto  = $0.00
      END ELSE BEGIN
        UPDATE @Abzuege
          SET BetragBrutto = @AbzBetragBrutto
        WHERE CURRENT OF cAbzugBrutto
        SET @AbzBetragBrutto = $0.00
      END

--IF @RepeatLoop = 1 BREAK
--      SELECT '@AbzugGruppeBetragNetto'  = @AbzugGruppeBetragNetto,
--             '@AbzugGruppeBetragBrutto' = @AbzugGruppeBetragBrutto
--print 'buchung, @AbzugGruppeBetrag neu: ' + cast(@AbzugGruppeBetrag as varchar)
    END

    DEALLOCATE cBuchung
    CLOSE cAbzugNetto
    CLOSE cAbzugBrutto
  END
  DEALLOCATE cAbzugNetto
  DEALLOCATE cAbzugBrutto


/*
SELECT *
FROM #Buchungen
ORDER BY BaPersonID_Teil, BuchungenID
SELECT '@Abzuege', * FROM @Abzuege

SELECT Brutto=SUM(BetragBrutto),Netto=SUM(BetragNetto) FROM #Buchungen /*where einnahme = 0 OR VerwaltungSD = 1*/ GROUP BY BgPositionID

SELECT Brutto=SUM(BetragBrutto),Netto=SUM(BetragNetto), diff=SUM(BetragBrutto)-SUM(BetragNetto)  FROM #Buchungen /*where einnahme = 0 OR VerwaltungSD = 1*/
*/

END -- IF(@BgPositionID_IN) -- für Einzelposition


  -- Runden
  DECLARE @BuchungenIDRunden        int,
          @BetragBrutto             money,
          @BetragNetto              money,
          @BetragBruttoRound        money,
          @BetragNettoRound         money,
          @RundungsdifferenzBrutto  money,
          @RundungsdifferenzNetto   money
--@SummeZahlungsmodus int


  SET @RundungsdifferenzBrutto = $0.00
  SET @RundungsdifferenzNetto = $0.00

  DECLARE cBuchungRunden CURSOR FOR
    SELECT BuchungenID, BetragBrutto, BetragNetto
    FROM #Buchungen
    ORDER BY Einnahme, BgKostenartID, BgPositionID
  FOR UPDATE OF BetragBrutto, BetragNetto

  OPEN cBuchungRunden
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cBuchungRunden INTO @BuchungenIDRunden, @BetragBrutto, @BetragNetto
    IF @@FETCH_STATUS < 0 BREAK

    SET @BetragBruttoRound       = FLOOR((@BetragBrutto + @RundungsdifferenzBrutto) * 20.0 + 0.5) / 20.0
    SET @BetragNettoRound        = FLOOR((@BetragNetto + @RundungsdifferenzNetto) * 20.0 + 0.5) / 20.0
    SET @RundungsdifferenzBrutto = @BetragBrutto + @RundungsdifferenzBrutto - @BetragBruttoRound
    SET @RundungsdifferenzNetto  = @BetragNetto + @RundungsdifferenzNetto - @BetragNettoRound
    --SET @SummeZahlungsmodus      = @SummeZahlungsmodus + @BetragNettoRound

    UPDATE #Buchungen SET BetragBrutto = @BetragBruttoRound, BetragNetto = @BetragNettoRound
    WHERE BuchungenID = @BuchungenIDRunden

  END
  CLOSE cBuchungRunden
  DEALLOCATE cBuchungRunden

/*
SELECT *
FROM #Buchungen
ORDER BY BaPersonID_Teil, BuchungenID

SELECT BgKategorieCode, SUM(BetragBrutto), SUM(BetragNetto)
FROM #Buchungen
GROUP BY BgKategorieCode
*/

  /************************************************************************************************/
  /* Beträge plausibilisieren                                                                     */
  /************************************************************************************************/
  IF EXISTS (SELECT * FROM @Abzuege WHERE BetragNetto > $0.01) BEGIN
    SET @msg = 'Der Auszahlungsbetrag an den Klienten beträgt:' + char(13) + char(10) + ' -' + LTrim(STR((SELECT SUM(BetragNetto) FROM @Abzuege), 10, 2)) + ' sFr.'
    RAISERROR(@msg, 18, 1)
    RETURN -1
  END

--SELECT Diff = ABS(SUM(BetragBrutto) - SUM(BetragNetto)), Brutto = SUM(BetragBrutto), Netto = SUM(BetragNetto) FROM #Buchungen

  SELECT @Diff = ABS(SUM(BetragBrutto) - SUM(BetragNetto)) FROM #Buchungen
  IF @Diff > $0.05 BEGIN
    SET @msg = 'Die Summe der Bruttobeträge entspricht nicht der Summe der Nettobeträge! Die Differenz beträgt ' + CONVERT(varchar,@Diff) + 'CHF'
    RAISERROR(@msg, 18, 1)
    RETURN -1
  END

--return
/*
select *
from #Buchungen

select *
from @Abzuege 
select sum(betrag) from @Abzuege
*/
--return

/*
  DELETE TMP
  FROM #Buchungen  TMP
    INNER JOIN (SELECT BgAuszahlungID_EZ, SUM(BetragNetto) AS BetragSumme
                FROM #Buchungen GROUP BY BgAuszahlungID_EZ
               )   EZ  ON EZ.BgAuszahlungID_EZ = TMP.BgAuszahlungID_EZ
  WHERE EZ.BetragSumme = (SELECT SUM(Betrag) FROM ShEinzelzahlung WHERE BgAuszahlungID = TMP.BgAuszahlungID_EZ)
*/

  /************************************************************************************************/
  /* Belege verbuchen                                                                             */
  /************************************************************************************************/

  -- Faktor bestimmen für Aufteilung eines Betrages auf mehrere Auszahlungen (Bsp. 4 Termine -> Faktor 0.25)
  UPDATE BUC
  SET TerminFaktor = TMP.Faktor, NettoBetragProTermin = BetragNetto * TMP.Faktor, BruttoBetragProTermin = BetragBrutto * TMP.Faktor
  FROM #Buchungen BUC
    INNER JOIN (SELECT BgPositionID, Faktor = 1.0 / COUNT(*), BAP.BaPersonID
                FROM BgAuszahlungPerson               BAP
                  INNER JOIN BgAuszahlungPersonTermin BPT ON BAP.BgAuszahlungPersonID = BPT.BgAuszahlungPersonID
                GROUP BY BgPositionID, BAP.BaPersonID) TMP ON TMP.BgPositionID = BUC.BgPositionID AND IsNull(TMP.BaPersonID, BUC.BaPersonID_Teil) = BUC.BaPersonID_Teil


/*

select * FROM #Buchungen 

  SELECT BUC.BgPositionID, BUC.BetragNetto, TerminFaktor = TMP.Faktor, NettoBetragProTermin = BetragNetto * TMP.Faktor, BruttoBetragProTermin = BetragBrutto * TMP.Faktor
  FROM #Buchungen BUC
    INNER JOIN (SELECT BgPositionID, Faktor = 1.0 / Count(*), BAP.BaPersonID
                FROM BgAuszahlungPerson               BAP
                  INNER JOIN BgAuszahlungPersonTermin BPT ON BAP.BgAuszahlungPersonID = BPT.BgAuszahlungPersonID
                GROUP BY BgPositionID, BAP.BaPersonID) TMP ON TMP.BgPositionID = BUC.BgPositionID AND IsNull(TMP.BaPersonID, BUC.BaPersonID_Teil) = BUC.BaPersonID_Teil
  SELECT BUC.BgPositionID, BUC.BetragNetto, TerminFaktor = TMP.Faktor, NettoBetragProTermin = BetragNetto * TMP.Faktor, BruttoBetragProTermin = BetragBrutto * TMP.Faktor
  FROM #Buchungen BUC
    INNER JOIN (SELECT BgPositionID, Faktor = 1.0 / Count(*)
                FROM BgAuszahlungPerson               BAP
                  INNER JOIN BgAuszahlungPersonTermin BPT ON BAP.BgAuszahlungPersonID = BPT.BgAuszahlungPersonID
                GROUP BY BgPositionID) TMP ON TMP.BgPositionID = BUC.BgPositionID --AND IsNull(TMP.BaPersonID, BUC.BaPersonID_Teil) = BUC.BaPersonID_Teil
*/

  /************************************************************************************************/
  /* Temporäre (Netto-)Tabellen erstellen                                                         */
  /************************************************************************************************/
  DECLARE @KbBuchung TABLE(
	[KbBuchungID] [int] IDENTITY(1,1) NOT NULL,
	[KbPeriodeID] [int] NOT NULL,
	[IkPositionID] [int] NULL,
	[KbBuchungTypCode] [int] NOT NULL,
	[Code] [varchar](10) NULL,
	[BelegNr] [bigint] NULL,
	[BelegDatum] [datetime] NULL,
	[ValutaDatum] [datetime] NULL,
	[TransferDatum] [datetime] NULL,
	[Betrag] [money] NOT NULL,
	[Text] [varchar](200) NOT NULL,
	[KbBuchungStatusCode] [int] NULL,
	[SollKtoNr] [varchar](10) NULL,
	[HabenKtoNr] [varchar](10) NULL,
	[KbZahlungseingangID] [int] NULL,
	[BaZahlungswegID] [int] NULL,
	[KbAuszahlungsArtCode] [int] NULL,
	[PCKontoNr] [varchar](50) NULL,
	[BaBankID] [int] NULL,
	[BankKontoNr] [varchar](50) NULL,
	[IBAN] [varchar](50) NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[Zahlungsgrund] [varchar](200) NULL,
	[MitteilungZeile1] [varchar](35) NULL,
	[MitteilungZeile2] [varchar](35) NULL,
	[MitteilungZeile3] [varchar](35) NULL,
	[MitteilungZeile4] [varchar](35) NULL,
	[BeguenstigtName] [varchar](100) NULL,
	[BeguenstigtName2] [varchar](200) NULL,
	[BeguenstigtStrasse] [varchar](100) NULL,
	[BeguenstigtHausNr] [varchar](10) NULL,
	[BeguenstigtPostfach] [varchar](40) NULL,
	[BeguenstigtOrt] [varchar](100) NULL,
	[BeguenstigtPLZ] [varchar](10) NULL,
	[BeguenstigtLandCode] [int] NULL,
	[BgBudgetID] [int] NULL,
	[BarbelegUserID] [int] NULL,
	[BarbelegDatum] [datetime] NULL,
	[CashOrCheckAm] [datetime] NULL,
	[PscdZahlwegArt] [char](1) NULL,
	[PscdFehlermeldung] [varchar](200) NULL,
	[StorniertKbBuchungID] [int] NULL,
	[Schuldner_BaInstitutionID] [int] NULL,
	[Schuldner_BaPersonID] [int] NULL,
	[ModulID] [int] NULL,
	[KbForderungIstSH] [bit] NULL,
	[Kostenstelle] [varchar](20) NULL,
	[BankName] [varchar](70) NULL,
	[BankStrasse] [varchar](50) NULL,
	[BankPLZ] [varchar](10) NULL,
	[BankOrt] [varchar](60) NULL,
	[BankBCN] [varchar](10) NULL,
	[ErstelltUserID] [int] NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
    [FaLeistungID] [int] NULL
)

DECLARE @KbBuchungKostenart TABLE
(
	[KbBuchungKostenartID] [int] IDENTITY(1,1) NOT NULL,
	[KbBuchungID] [int] NOT NULL,
	[BgPositionID] [int] NULL,
	[BgKostenartID] [int] NULL,
	[BaPersonID] [int] NULL,
	[Buchungstext] [varchar](200) NULL,
	[Betrag] [money] NOT NULL,
	[KontoNr] [varchar](50) NULL,
	[PositionImBeleg] [int] NULL,
	[Hauptvorgang] [int] NULL,
	[Teilvorgang] [int] NULL,
	[Belegart] [varchar](4) NULL,
	[VerwPeriodeVon] [datetime] NULL,
	[VerwPeriodeBis] [datetime] NULL
)

  /************************************************************************************************/
  /* Nettobelege verbuchen                                                                        */
  /************************************************************************************************/
  -- GBL auf Ausgabekonto: Betrag bestimmen, in BgPosition schreiben, aus #Buchungen löschen damit es keine Auszahlung gibt
  DECLARE @BetragAusgabekonto money

/*
  select * from #Buchungen

  SELECT [Count] = COUNT(DISTINCT(BgPositionID)), BgPositionID = SUM(DISTINCT(BgPositionID)), BetragAusgabekonto = SUM(BetragNetto)
  FROM #Buchungen
  WHERE BgPositionsartID = @BgPositionsartIDGBL AND GBLAufAusgabeKonto = 1
*/

  SELECT @COUNT = COUNT(DISTINCT(BgPositionID)), @BgPositionID = SUM(DISTINCT(BgPositionID)), @BetragAusgabekonto = SUM(BetragNetto)
  FROM #Buchungen
  WHERE BgPositionsartID = @BgPositionsartIDGBL AND GBLAufAusgabeKonto = 1

  IF @COUNT = 1 BEGIN
    UPDATE BgPosition
    SET BetragGBLAufAusgabekonto = @BetragAusgabekonto
    WHERE BgPositionID = @BgPositionID
/*
    SELECT 'BetragGBLAufAusgabekonto', BetragGBLAufAusgabekonto, *
    FROM BgPosition
    WHERE BgPositionID =@BgPositionID
*/
  END

  DELETE FROM BUC
  FROM #Buchungen         BUC
    LEFT JOIN BgAuszahlungPerson       BAP ON BUC.BgPositionID = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
  WHERE GBLAufAusgabeKonto = 1 AND KbAuszahlungsArtCode IS NULL AND BaZahlungswegID IS NULL

/*
SELECT * FROM #Buchungen

  SELECT AuszahlBetrag = SUM(IsNull(BUC.NettoBetragProTermin,BUC.BetragNetto)), BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, Datum = IsNull(BAT.Datum,POS.FaelligAm), BUC.TerminFaktor, BAP.KbAuszahlungsArtCode, BAP.BaZahlungswegID, BAP.ReferenzNummer, Zahlungsgrund = NULL,/*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode
    FROM #Buchungen                      BUC
      LEFT JOIN BgPosition               POS ON POS.BgPositionID = BUC.BgPositionID
      LEFT JOIN BgAuszahlungPerson       BAP ON BUC.BgPositionID = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
      LEFT JOIN BgAuszahlungPersonTermin BAT ON BAP.BgAuszahlungPersonID = BAT.BgAuszahlungPersonID
    WHERE ABS(BUC.BetragNetto) > $0.00
    GROUP BY BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, BAP.BaZahlungswegID, IsNull(BAT.Datum,POS.FaelligAm), BAP.KbAuszahlungsArtCode, BUC.TerminFaktor, BAP.ReferenzNummer, /*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode, BUC.AuszahlGruppeID
    ORDER BY BUC.BaPersonID_Teil, BUC.AuszahlGruppeID
*/
  SELECT AuszahlBetrag = SUM(IsNull(CAST(BUC.NettoBetragProTermin AS money),BUC.BetragNetto)), BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, Datum = IsNull(BAT.Datum,POS.FaelligAm), BUC.TerminFaktor, BAP.KbAuszahlungsArtCode, BAP.BaZahlungswegID, BAP.ReferenzNummer, Zahlungsgrund = NULL,/*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode, MitteilungZeile1 = IsNull(BAP.MitteilungZeile1,'F' + CAST(@FaFallID AS varchar) + IsNull(' ' + @Person,'')), BAP.MitteilungZeile2, BAP.MitteilungZeile3, BAP.MitteilungZeile4
    INTO #NettoAuszahlungen
    FROM #Buchungen                      BUC
      LEFT JOIN #vwBgPosition            POS ON POS.BgPositionID = BUC.BgPositionID
      LEFT JOIN BgAuszahlungPerson       BAP ON BUC.BgPositionID = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
      LEFT JOIN BgAuszahlungPersonTermin BAT ON BAP.BgAuszahlungPersonID = BAT.BgAuszahlungPersonID
    --WHERE ABS(BUC.BetragNetto) > $0.01
    GROUP BY BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, BAP.BaZahlungswegID, IsNull(BAT.Datum,POS.FaelligAm), BAP.KbAuszahlungsArtCode, BUC.TerminFaktor, BAP.ReferenzNummer, /*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode, BUC.AuszahlGruppeID, IsNull(BAP.MitteilungZeile1,'F' + CAST(@FaFallID AS varchar) + IsNull(' ' + @Person,'')), BAP.MitteilungZeile2, BAP.MitteilungZeile3, BAP.MitteilungZeile4
    ORDER BY BUC.BaPersonID_Teil, BUC.AuszahlGruppeID

/*
  -- Check Zahlungsweg:
  --  IBAN
  SELECT @COUNT = COUNT(*), @msg = dbo.ConcDistinct(IsNull(Kreditor + ', ' + Zusatzinfo + ', ' + Zahlungsweg + char(13) + char(10) + char(13) + char(10),''))
  FROM #NettoAuszahlungen    AUZ
    INNER JOIN BaZahlungsweg ZAL ON ZAL.BaZahlungswegID = AUZ.BaZahlungswegID
    LEFT  JOIN vwKreditor    KRE ON KRE.BaZahlungswegID = ZAL.BaZahlungswegID
  WHERE  ZAL.IBANNummer IS NULL AND ZAL.EinzahlungsscheinCode IN (2,3,5)

  IF @COUNT > 0 BEGIN
    SET @msg = 'Nicht alle verwendeten Zahlungswege haben eine IBAN. Die IBAN ist zwingend, um Auszahlungen zu machen. Tragen sie bitte die IBAN in den Basisdaten bzw im Institutionenstamm ein. Betroffene Stammdaten:' + char(13) + char(10) + char(13) + char(10) + @msg
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END
*/
  DECLARE @ZahlungswegeCheck TABLE (BaZahlungswegID int)

  -- Zahlungwege der anzulegenden Personen
  INSERT INTO @ZahlungswegeCheck
    SELECT ZAL.BaZahlungswegID
    FROM #NettoAuszahlungen    AUZ
      INNER JOIN BaZahlungsweg ZA1 ON ZA1.BaZahlungswegID = AUZ.BaZahlungswegID
      INNER JOIN BaZahlungsweg ZAL ON ZAL.BaPersonID      = ZA1.BaPersonID OR ZAL.BaInstitutionID = ZA1.BaInstitutionID
    WHERE ZAL.BaZahlungswegID IS NOT NULL

  -- Zahlungswege der Debitoren
  INSERT INTO @ZahlungswegeCheck
    SELECT ZAL.BaZahlungswegID
    FROM #Buchungen            BUC
      INNER JOIN BgPosition    POS ON POS.BgPositionID = BUC.BgPositionID
      INNER JOIN BaZahlungsweg ZAL ON ZAL.BaPersonID   = POS.DebitorBaPersonID OR ZAL.BaInstitutionID = POS.BaInstitutionID
    WHERE ZAL.BaZahlungswegID IS NOT NULL

  -- Alle Zahlungswege der Finanzplan-Personen
  INSERT INTO @ZahlungswegeCheck
    SELECT ZAL.BaZahlungswegID
    FROM BgFinanzplan_BaPerson FPP
      INNER JOIN BaZahlungsweg ZAL ON ZAL.BaPersonID = FPP.BaPersonID
    WHERE FPP.BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1 AND BaZahlungswegID IS NOT NULL

  SELECT @COUNT = COUNT(*), @msg = dbo.ConcDistinct(IsNull(Kreditor + ', ' + ZusatzInfo + ', ' + Zahlungsweg + char(13) + char(10) + char(13) + char(10),''))
  FROM @ZahlungswegeCheck    TMP
    INNER JOIN BaZahlungsweg ZAL ON ZAL.BaZahlungswegID = TMP.BaZahlungswegID
    LEFT  JOIN vwKreditor    KRE ON KRE.BaZahlungswegID = TMP.BaZahlungswegID
  WHERE  ZAL.IBANNummer IS NULL AND ZAL.EinzahlungsscheinCode IN (2,3,5)

  IF @COUNT > 0 BEGIN
    SET @msg = REPLACE('Nicht alle Zahlungswege haben eine IBAN. Die IBAN ist zwingend, um Auszahlungen zu machen. Tragen sie bitte die IBAN in den Basisdaten bzw im Institutionenstamm ein. Betroffene Stammdaten:' + char(13) + char(10) + char(13) + char(10) + @msg, char(13) + char(10) + ',', char(13) + char(10))
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END

  -- WMAs
  DECLARE @WMACheck TABLE (BaAdresseID int, BaPersonID int, BaInstitutionID int, DatumVon datetime, DatumBis datetime)

  -- Adressen der anzulegenden Personen/Institutionen
  INSERT INTO @WMACheck
    SELECT DISTINCT ADR.BaAdresseID, ADR.BaPersonID, ADR.BaInstitutionID, ADR.DatumVon, ADR.DatumBis
    FROM #NettoAuszahlungen    AUZ
      INNER JOIN BaZahlungsweg ZAL ON ZAL.BaZahlungswegID = AUZ.BaZahlungswegID
      LEFT  JOIN BaAdresse     ADR ON ADR.BaPersonID = ZAL.BaPersonID OR ADR.BaInstitutionID = ZAL.BaInstitutionID
    WHERE ZAL.BaZahlungswegID IS NOT NULL AND AdresseCode = 1 /*WMA*/

  -- Adressen der Debitoren
  INSERT INTO @WMACheck
    SELECT DISTINCT ADR.BaAdresseID, ADR.BaPersonID, ADR.BaInstitutionID, ADR.DatumVon, ADR.DatumBis
    FROM #Buchungen            BUC
      INNER JOIN BgPosition    POS ON POS.BgPositionID = BUC.BgPositionID
      LEFT  JOIN BaAdresse     ADR ON ADR.BaPersonID   = POS.DebitorBaPersonID OR ADR.BaInstitutionID = POS.BaInstitutionID
    WHERE (POS.DebitorBaPersonID IS NOT NULL OR POS.BaInstitutionID IS NOT NULL) AND AdresseCode = 1 /*WMA*/
      AND (BaAdresseID IS NULL OR BaAdresseID NOT IN (SELECT BaAdresseID FROM @WMACheck WHERE BaAdresseID IS NOT NULL))

  -- Alle Adressen der Finanzplan-Personen
  INSERT INTO @WMACheck
    SELECT DISTINCT ADR.BaAdresseID, FPP.BaPersonID, NULL, ADR.DatumVon, ADR.DatumBis
    FROM BgFinanzplan_BaPerson FPP
      LEFT  JOIN BaAdresse     ADR ON ADR.BaPersonID = FPP.BaPersonID
    WHERE FPP.BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1 AND AdresseCode = 1 /*WMA*/
      AND (BaAdresseID IS NULL OR BaAdresseID NOT IN (SELECT BaAdresseID FROM @WMACheck WHERE BaAdresseID IS NOT NULL))


  DELETE FROM @WMACheck
  WHERE GetDate() NOT BETWEEN DatumVon AND IsNull(DatumBis,dbo.fnDateSerial(9999,12,31))

  -- Check: > 1 WMA
  SELECT @msg = dbo.ConcDistinct([Name]), @Count = Count(*)
  FROM( SELECT [Name] = dbo.ConcDistinct(IsNull(PRS.NameVorname,INS.Name)), [Count] = Count(*)
        FROM @WMACheck            ADR
          LEFT JOIN vwPerson      PRS ON PRS.BaPersonID      = ADR.BaPersonID
          LEFT JOIN vwInstitution INS ON INS.BaInstitutionID = ADR.BaInstitutionID
        WHERE BaAdresseID IS NOT NULL
        GROUP BY ADR.BaPersonID, ADR.BaInstitutionID
        HAVING Count(*) > 1) TMP

  IF @COUNT > 0 BEGIN
    SET @msg = 'Folgende Personen/Institutionen haben mehr als eine Wohn-/Meldeadresse:' + char(13) + char(10) + char(13) + char(10) + @msg
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END

  -- Check: 0 WMA
  SELECT @msg = dbo.ConcDistinct(KRE.Kreditor), @Count = Count(*)
  FROM @WMACheck         ADR
    LEFT JOIN vwKreditor KRE ON KRE.BaPersonID = ADR.BaPersonID OR KRE.BaInstitutionID = ADR.BaInstitutionID
  WHERE BaAdresseID IS NULL

  IF @COUNT > 0 BEGIN
    SET @msg = 'Folgende Personen/Institutionen keine Wohn-/Meldeadresse:' + char(13) + char(10) + char(13) + char(10) + @msg
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END


  -- Gültigkeit
  SELECT @COUNT = COUNT(*)
  FROM #NettoAuszahlungen    AUZ
    INNER JOIN BaZahlungsweg ZAL ON ZAL.BaZahlungswegID = AUZ.BaZahlungswegID
  WHERE  Datum NOT BETWEEN DatumVon AND DatumBis

  IF @COUNT > 0 BEGIN
    SET @msg = 'Ein Valutadatum liegt ausserhalb des Gültigkeitszeitraums das Zahlungswegs. Überprüfen Sie bitte die Gültigkeit der verwendeten Zahlungswege im Modul B oder im Institutionenstamm (jeweils Register Zahlinfo).'
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END



--select Referenzsumme = @TotalBetrag, Auszahlsumme = (SUM(AuszahlBetrag)) FROM #NettoAuszahlungen
/*
  SELECT @Diff = ABS(ABS(SUM(AuszahlBetrag)) - ABS(@TotalBetrag)) FROM #NettoAuszahlungen
  IF @Diff > $0.05 BEGIN
    SET @msg = 'Die Summe der auszuzahlenden Beträge wurde falsch berechnet! Der Fehler der Summe der Nettobeträge beträgt ' + CONVERT(varchar,@Diff) + 'CHF'
    RAISERROR(@msg, 18, 1)
    RETURN -1
  END
*/
  -- Runden
  DECLARE @BaPersonID_Teil int,
          @BelegBetrag money,
          @AuszahlBetrag money


  SET @BetragNettoRound = $0.00
  SET @RundungsdifferenzNetto = $0.00

  DECLARE cBelegRunden CURSOR FOR
    SELECT BgPositionID, BaPersonID_Teil, SUM(AuszahlBetrag)
    FROM #NettoAuszahlungen
    GROUP BY BgPositionID, BaPersonID_Teil
    HAVING COUNT(*) > 1

  OPEN cBelegRunden
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cBelegRunden INTO @BgPositionID, @BaPersonID_Teil, @BelegBetrag
    IF @@FETCH_STATUS < 0 BREAK

    DECLARE cBelegPositionRunden CURSOR FOR
      SELECT AuszahlBetrag
      FROM #NettoAuszahlungen
      WHERE BgPositionID = @BgPositionID AND BaPersonID_Teil = @BaPersonID_Teil
    FOR UPDATE OF AuszahlBetrag

    OPEN cBelegPositionRunden
    WHILE 1=1 BEGIN
      FETCH NEXT FROM cBelegPositionRunden INTO @AuszahlBetrag
      IF @@FETCH_STATUS < 0 BREAK
      SET @BetragNettoRound        = FLOOR((@AuszahlBetrag + @RundungsdifferenzNetto) * 20.0 + 0.5) / 20.0
      SET @RundungsdifferenzNetto  = @AuszahlBetrag + @RundungsdifferenzNetto - @BetragNettoRound

      UPDATE #NettoAuszahlungen SET AuszahlBetrag = @BetragNettoRound
      WHERE CURRENT OF cBelegPositionRunden

    END
    CLOSE cBelegPositionRunden
    DEALLOCATE cBelegPositionRunden

  END
  CLOSE cBelegRunden
  DEALLOCATE cBelegRunden

  --Wegrunden von minimalen Beträgen (<0.001)

  UPDATE #NettoAuszahlungen
    SET AuszahlBetrag = FLOOR(AuszahlBetrag * 20.0 + 0.5) / 20.0
  WHERE ABS(FLOOR(AuszahlBetrag * 20.0 + 0.5) / 20.0 - AuszahlBetrag) < 0.001

--SELECT '#NettoAuszahlungen', *, Betrag = CONVERT(varchar, CONVERT(float,AuszahlBetrag)) FROM #NettoAuszahlungen

  DECLARE @KbBuchungTypCode int,
          @SumBetrag money,
          @Text varchar(200),
          @VerwPeriodeVon datetime,
          @VerwPeriodeBis datetime,
          @KbBuchungBruttoID int,
          @KbBuchungID int,
          @BaZahlungswegID int,
          @ValutaDatum datetime,
          @KbAuszahlungsArtCode int,
          @ReferenzNummer varchar(200),
          @Zahlungsgrund varchar(200),
          @KontoNr varchar(10),
          @Schuldner_BaInstitutionID int,
          @Schuldner_BaPersonID int,
          @BgPositionID_Einzahlung int,
          @MitteilungZeile1 varchar(35),
          @MitteilungZeile2 varchar(35),
          @MitteilungZeile3 varchar(35),
          @MitteilungZeile4 varchar(35)

/*
    SELECT 'cNettoBeleg', CASE Einnahme WHEN 1 THEN 2 /*Forderung*/ ELSE 1 /*Verbindlichkeit*/ END, Datum, FLOOR((-SUM(AuszahlBetrag)) * 20.0 + 0.5) / 20.0,
           BaZahlungswegID, KbAuszahlungsArtCode, Zahlungsgrund, ReferenzNummer, KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID,
           CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END
    FROM #NettoAuszahlungen     AUZ
      LEFT JOIN BgPosition      BPO ON BPO.BgPositionID     = AUZ.BgPositionID
      LEFT JOIN BgPositionsart  BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
      LEFT JOIN BgKostenart     BKA ON BKA.BgKostenartID    = BPA.BgKostenartID
    --WHERE  AUZ.Einnahme = 0
    GROUP BY Datum, AUZ.BaZahlungswegID, AUZ.KbAuszahlungsArtCode, Zahlungsgrund, Einnahme, ReferenzNummer, AUZ.KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END
*/

  DECLARE cNettoBeleg CURSOR FOR
    SELECT Einnahme, Datum, FLOOR((SUM(AuszahlBetrag)) * 20.0 + 0.5) / 20.0,
           BaZahlungswegID, KbAuszahlungsArtCode, Zahlungsgrund, ReferenzNummer, KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, LEFT(MitteilungZeile1,35), LEFT(MitteilungZeile2,35), LEFT(MitteilungZeile3,35), LEFT(MitteilungZeile4,35)
    FROM #NettoAuszahlungen     AUZ
      LEFT JOIN #vwBgPosition   BPO ON BPO.BgPositionID     = AUZ.BgPositionID
      LEFT JOIN BgPositionsart  BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
    --WHERE  AUZ.Einnahme = 0
    GROUP BY Datum, AUZ.BaZahlungswegID, AUZ.KbAuszahlungsArtCode, Zahlungsgrund, Einnahme, ReferenzNummer, AUZ.KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, LEFT(MitteilungZeile1,35), LEFT(MitteilungZeile2,35), LEFT(MitteilungZeile3,35), LEFT(MitteilungZeile4,35)

  DECLARE @BaBankID_Post int, @Einnahme int

  SELECT @BaBankID_Post = BaBankID
  FROM   BaBank
  WHERE  ClearingNr = '9000' /*Post*/ AND LandCode = 8100 /*CH*/

  OPEN cNettoBeleg
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cNettoBeleg INTO @Einnahme, @ValutaDatum, @SumBetrag, @BaZahlungswegID, @KbAuszahlungsArtCode, @Zahlungsgrund, @ReferenzNummer, @KbBuchungStatusCode, @Schuldner_BaInstitutionID, @Schuldner_BaPersonID, @BgPositionID_Einzahlung, @MitteilungZeile1, @MitteilungZeile2, @MitteilungZeile3, @MitteilungZeile4
    IF @@FETCH_STATUS < 0 BREAK

    -- Buchungskopf
    IF( @Einnahme = 0 ) BEGIN --Ausgabe
    IF( @KbAuszahlungsArtCode <> 103 ) BEGIN
      -- Elektronische Auszahlung
      INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID, SollKtoNr, HabenKtoNr,
                              KbAuszahlungsArtCode, PCKontoNr, BaBankID, BankKontoNr, IBAN, ReferenzNummer, Zahlungsgrund, BeguenstigtName, BeguenstigtName2, BeguenstigtPostfach, BeguenstigtStrasse, BeguenstigtHausNr, BeguenstigtPLZ, BeguenstigtOrt, BeguenstigtLandCode,
                              BgBudgetID, PscdZahlwegArt, ModulID, Kostenstelle, BankName, BankStrasse, BankPLZ, BankOrt, BankBCN, ErstelltUserID, ErstelltDatum, FaLeistungID,
                              MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4)
        SELECT @KbPeriodeID, 1/*Budget*/, GetDate(), @ValutaDatum, @SumBetrag,
             'an ' + CASE WHEN ZAL.BaZahlungswegID IS NOT NULL THEN ZAL.Name + '; am ' + CONVERT(varchar,@ValutaDatum,104) WHEN @KbAuszahlungsArtCode = 103 THEN 'Barauszahlung' ELSE '' END,
             @KbBuchungStatusCode, @BaZahlungswegID, NULL, @KontoNrKreditor,
             @KbAuszahlungsArtCode, ZAL.PCKontoNr, ZAL.BaBankID, ZAL.BankKontoNr, ZAL.IBAN, @ReferenzNummer, @Zahlungsgrund,
               ZAL.Name,--CASE WHEN ZAL.BaPersonID IS NOT NULL THEN CASE WHEN ZAL. PRS.NameVorname ELSE INS.Name END,
               NULL,
               ZAL.Postfach,
               ZAL.Strasse,--CASE WHEN ZAL.BaPersonID IS NOT NULL THEN PRS.WohnsitzStrasseHausNr ELSE INS.StrasseHausNr   END,
               ZAL.HausNr,
               ZAL.PLZ,--CASE WHEN ZAL.BaPersonID IS NOT NULL THEN PRS.WohnsitzPLZ           ELSE INS.PLZ             END,
               ZAL.Ort,--CASE WHEN ZAL.BaPersonID IS NOT NULL THEN PRS.WohnsitzOrt           ELSE INS.Ort             END,
               ZAL.LandCode,
             @BgBudgetID,
               IsNull( XLA.Value1, ZAL.Auszahlungsart ), ModulID = 3 /*W*/, @Kostenstelle,
             ZAL.BankName, ZAL.BankStrasse, ZAL.BankPLZ, ZAL.BankOrt, ZAL.Bank_BCN, @UserID, GetDate(), @FaLeistungID, @MitteilungZeile1, @MitteilungZeile2, @MitteilungZeile3, @MitteilungZeile4
        FROM vwKreditorInfo        ZAL
          LEFT  JOIN XLOVCode      XLA ON XLA.LOVName = 'KbAuszahlungsArt'    AND XLA.Code = @KbAuszahlungsArtCode
        WHERE ZAL.BaZahlungswegID = @BaZahlungswegID
        GROUP BY ZAL.BaZahlungswegID, ZAL.PCKontoNr, ZAL.BaBankID, ZAL.BankKontoNr, ZAL.IBAN, ZAL.BaPersonID, ZAL.BaInstitutionID, ZAL.EinzahlungsscheinCode, ZAL.Name, ZAL.Postfach, ZAL.Strasse, ZAL.HausNr, ZAL.PLZ, ZAL.Ort, ZAL.LandCode, XLA.Value1, ZAL.Auszahlungsart, ZAL.BankName, ZAL.BankStrasse, ZAL.BankPLZ, ZAL.BankOrt, ZAL.Bank_BCN
    END
    ELSE BEGIN
      -- Barauszahlung
      --Mitteilung bestimmen
      DECLARE @MitteilungZeile1tmp varchar(35),
              @MitteilungZeile2tmp varchar(35),
              @MitteilungZeile3tmp varchar(35),
              @MitteilungZeile4tmp varchar(35)

      SELECT TOP 1 @MitteilungZeile1tmp = MitteilungZeile1,
                   @MitteilungZeile2tmp = MitteilungZeile2,
                   @MitteilungZeile3tmp = MitteilungZeile3,
                   @MitteilungZeile4tmp = MitteilungZeile4
      FROM   #NettoAuszahlungen   AUZ
      WHERE AUZ.Datum = @ValutaDatum AND IsNull(AUZ.BaZahlungswegID,-1) = IsNull(@BaZahlungswegID,-1) AND AUZ.KbAuszahlungsArtCode = @KbAuszahlungsArtCode AND IsNull(AUZ.ReferenzNummer,'') = IsNull(@ReferenzNummer,'')
        AND Einnahme = 0 AND MitteilungZeile1 IS NOT NULL


      INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, ErstelltUserID, BaZahlungswegID, SollKtoNr, HabenKtoNr,
                              KbAuszahlungsArtCode, ReferenzNummer, BgBudgetID, PscdZahlwegArt, ModulID, Kostenstelle, BeguenstigtName, BeguenstigtStrasse, BeguenstigtOrt, FaLeistungID)
      VALUES( @KbPeriodeID, 1/*Budget*/, GetDate(), @ValutaDatum, @SumBetrag, 'Barauszahlung' + IsNull(' an ' + @MitteilungZeile1tmp,''), @KbBuchungStatusCode, @UserID, NULL, NULL, @KontoNrKreditor,
             @KbAuszahlungsArtCode, NULL, @BgBudgetID, 'C', 3, @Kostenstelle, @MitteilungZeile1tmp, @MitteilungZeile2tmp, @MitteilungZeile3tmp, @FaLeistungID )
    END
    SET @KbBuchungID = SCOPE_IDENTITY()

    -- Detailpositionen
    INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart, KontoNr, VerwPeriodeVon, VerwPeriodeBis)
      SELECT @KbBuchungID, AUZ.BgPositionID, AUZ.BgKostenartID, AUZ.BaPersonID_Teil, AUZ.Name, AuszahlBetrag, NULL,
             CASE AUZ.VerwaltungSD WHEN 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END,
             CASE AUZ.VerwaltungSD WHEN 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END,
             BKA.Belegart,
             BKA.KontoNr,
             VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
             VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth)  END
      FROM   #NettoAuszahlungen   AUZ
        INNER JOIN BgKostenart    BKA ON BKA.BgKostenartID    = AUZ.BgKostenartID
        LEFT  JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = AUZ.BgPositionID
        LEFT  JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
      WHERE AUZ.Datum = @ValutaDatum AND IsNull(AUZ.BaZahlungswegID,-1) = IsNull(@BaZahlungswegID,-1) AND AUZ.KbAuszahlungsArtCode = @KbAuszahlungsArtCode AND IsNull(AUZ.ReferenzNummer,'') = IsNull(@ReferenzNummer,'')
        AND Einnahme = 0
        AND IsNull(AUZ.MitteilungZeile1,'') = IsNull(@MitteilungZeile1,'') AND IsNull(AUZ.MitteilungZeile2,'') = IsNull(@MitteilungZeile2,'') AND IsNull(AUZ.MitteilungZeile3,'') = IsNull(@MitteilungZeile3,'') AND IsNull(AUZ.MitteilungZeile4,'') = IsNull(@MitteilungZeile4,'')

    END
    ELSE BEGIN -- Einnahme
      IF ABS(@SumBetrag) < $0.01 CONTINUE

      DECLARE @ForderungText varchar(200)
      IF( @Schuldner_BaInstitutionID IS NOT NULL ) BEGIN
        SELECT @ForderungText = Name
        FROM   BaInstitution
        WHERE  BaInstitutionID = @Schuldner_BaInstitutionID
      END
      ELSE IF( @Schuldner_BaPersonID IS NOT NULL ) BEGIN
        SELECT @ForderungText = NameVorname
        FROM   vwPerson
        WHERE  BaPersonID = @Schuldner_BaPersonID
      END

      SET @ForderungText = IsNull('von ' + @ForderungText + IsNull('; am ' + CONVERT(varchar,@ValutaDatum,104),''),'Forderung')

      INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID,
                              KbAuszahlungsArtCode, ReferenzNummer, BgBudgetID, PscdZahlwegArt, ModulID, Kostenstelle, SollKtoNr, ErstelltUserID, ErstelltDatum, Schuldner_BaPersonID, Schuldner_BaInstitutionID, FaLeistungID)
      VALUES( @KbPeriodeID, 1/*Budget*/, GetDate(), @ValutaDatum, -@SumBetrag, @ForderungText, @KbBuchungStatusCode, NULL,
              NULL, NULL, @BgBudgetID, NULL, 3, @Kostenstelle, @KontoNrDebitor, @UserID, GetDate(), @Schuldner_BaPersonID, @Schuldner_BaInstitutionID, @FaLeistungID )

      SET @KbBuchungID = SCOPE_IDENTITY()

      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart, KontoNr, VerwPeriodeVon, VerwPeriodeBis)
        SELECT @KbBuchungID, AUZ.BgPositionID, AUZ.BgKostenartID, AUZ.BaPersonID_Teil, AUZ.Name, -AuszahlBetrag, NULL,
               CASE AUZ.VerwaltungSD WHEN 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END,
               CASE AUZ.VerwaltungSD WHEN 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END,
               BKA.Belegart,
               BKA.KontoNr,
               VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
               VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth)  END
        FROM   #NettoAuszahlungen   AUZ
          INNER JOIN BgKostenart    BKA ON BKA.BgKostenartID    = AUZ.BgKostenartID
          LEFT  JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = AUZ.BgPositionID
          LEFT  JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BPO.BgPositionsartID
        WHERE IsNull(BPO.BaInstitutionID,-1) = IsNull(@Schuldner_BaInstitutionID,-1) AND IsNull(BPO.DebitorBaPersonID,-1) = IsNull(@Schuldner_BaPersonID,-1)
          AND Einnahme = 1 AND @BgPositionID_Einzahlung = AUZ.BgPositionID
          AND IsNull(AUZ.MitteilungZeile1,'') = IsNull(@MitteilungZeile1,'') AND IsNull(AUZ.MitteilungZeile2,'') = IsNull(@MitteilungZeile2,'') AND IsNull(AUZ.MitteilungZeile3,'') = IsNull(@MitteilungZeile3,'') AND IsNull(AUZ.MitteilungZeile4,'') = IsNull(@MitteilungZeile4,'')
    END
  END
  CLOSE cNettoBeleg
  DEALLOCATE cNettoBeleg

  DROP TABLE #NettoAuszahlungen


  -- Leere Belege löschen
  DECLARE @tmp TABLE
  (
    KbBuchungID int
  )

  INSERT INTO @tmp
  SELECT KbBuchungID
  FROM @KbBuchung
  WHERE Betrag = $0.00 AND KbBuchungID NOT IN (SELECT KbBuchungID
                                               FROM @KbBuchungKostenart
                                               WHERE Betrag <> $0.00)

  DELETE FROM @KbBuchungKostenart WHERE KbBuchungID IN (SELECT KbBuchungID FROM @tmp)
  DELETE FROM @KbBuchung          WHERE KbBuchungID IN (SELECT KbBuchungID FROM @tmp)

  -- Position im NettoBeleg
  DECLARE @Pos int,
          @CurrentKbBuchungID int,
          @LastKbBuchungID int,
          @KbBuchungKostenartID int,
          @Betrag money


  SET @LastKbBuchungID = NULL

  DECLARE cNetto CURSOR FOR
    SELECT KbBuchungKostenartID, KbBuchungID, Betrag
    FROM @KbBuchungKostenart
    ORDER BY KbBuchungID

  OPEN cNetto
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cNetto INTO @KbBuchungKostenartID, @CurrentKbBuchungID, @Betrag
    IF @@FETCH_STATUS < 0 BREAK

    IF ABS(@Betrag) < $0.01 CONTINUE

    IF IsNull(@LastKbBuchungID, -1) <> @CurrentKbBuchungID BEGIN
      SET @Pos = 1
      SET @LastKbBuchungID = @CurrentKbBuchungID
    END
    ELSE
      SET @Pos = @Pos + 1

    UPDATE @KbBuchungKostenart
    SET PositionImBeleg = @Pos
    WHERE KbBuchungKostenartID = @KbBuchungKostenartID

  END
  CLOSE cNetto
  DEALLOCATE cNetto


  -- Die auf 0.00 gekürzten Nettopositionenen müssen in einem Nettobeleg untergebracht werden, damit die entsprechenden Bruttobelege zu einem Nettobeleg zugeordnet werden können
  IF @KissStandard = 0 BEGIN
    DECLARE @KbBuchungIDGBL int

    SELECT TOP 1 @KbBuchungIDGBL = KBU.KbBuchungID
    FROM   @KbBuchung                KBU
      INNER JOIN @KbBuchungKostenart KBK ON KBK.KbBuchungID = KBU.KbBuchungID
    WHERE BgPositionID = @BgPositionIDGBL
    ORDER BY ValutaDatum

    IF @KbBuchungIDGBL IS NULL BEGIN
      SELECT TOP 1 @KbBuchungIDGBL = KbBuchungID
      FROM   @KbBuchung
      ORDER BY ValutaDatum
    END

    IF @KbBuchungIDGBL IS NOT NULL BEGIN
      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart, KontoNr, VerwPeriodeVon, VerwPeriodeBis)
        SELECT @KbBuchungIDGBL, BUC.BgPositionID, BUC.BgKostenartID, BUC.BaPersonID_Teil, BUC.Name, $0.00, NULL,
               CASE BUC.VerwaltungSD WHEN 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END,
               CASE BUC.VerwaltungSD WHEN 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END,
               BKA.Belegart,
               BKA.KontoNr,
               VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
               VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth)  END
        FROM   #Buchungen           BUC
          INNER JOIN BgKostenart    BKA ON BKA.BgKostenartID    = BUC.BgKostenartID
          LEFT  JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = BUC.BgPositionID
        WHERE ABS(BetragNetto) < $0.01 AND Einnahme = 1
    END

/*
    SELECT *
    FROM #Buchungen
    WHERE ABS(BetragNetto) < $0.01 AND Einnahme = 1
*/
  END

  /************************************************************************************************/
  /* Temporäre (Brutto-)Tabellen erstellen                                                         */
  /************************************************************************************************/
  DECLARE @KbBuchungBrutto TABLE(
	[KbBuchungBruttoID] [int] IDENTITY(1,1) NOT NULL,
	[KbPeriodeID] [int] NOT NULL,
	[BgKostenartID] [int] NULL,
	[KbBuchungTypCode] [int] NOT NULL,
	[Code] [varchar](10) NULL,
	[BelegNr] [bigint] NULL,
	[BelegDatum] [datetime] NULL,
	[ValutaDatum] [datetime] NULL,
	[ErfassungsDatum] [datetime] NULL,
	[TransferDatum] [datetime] NULL,
	[Zahlungsfrist] [int] NULL,
	[Betrag] [money] NOT NULL,
	[BetragEffektiv] [money] NOT NULL,
	[DatumEffektiv] [datetime] NULL,
	[Text] [varchar](200) NOT NULL,
	[KbBuchungStatusCode] [int] NULL,
	[UserID] [int] NULL,
	[KbBuchungBruttoTS] [timestamp] NOT NULL,
	[StorniertKbBuchungBruttoID] [int] NULL,
	[BgBudgetID] [int] NULL,
	[PscdFehlermeldung] [varchar](200) NULL,
	[ModulID] [int] NULL,
	[Kostenstelle] [varchar](20) NULL,
	[Hauptvorgang] [int] NULL,
	[Teilvorgang] [int] NULL,
	[Belegart] [varchar](4) NULL,
	[BgPositionID] [int] NULL,
	[FaLeistungID] [int] NULL,
	[BgSplittingArtCode] [int] NULL,
	[Weiterverrechenbar] [int] NULL,
	[Quoting] [int] NULL,
    [Einnahme] [bit] NULL
  )

  DECLARE @KbBuchungBruttoPerson TABLE(
	[KbBuchungBruttoPersonID] [int] IDENTITY(1,1) NOT NULL,
	[KbBuchungBruttoID] [int] NOT NULL,
	[BgPositionID] [int] NULL,
	[BaPersonID] [int] NULL,
	[Schuldner_BaInstitutionID] [int] NULL,
	[Schuldner_BaPersonID] [int] NULL,
	[Buchungstext] [varchar](200) NULL,
	[Betrag] [money] NOT NULL,
	[VerwPeriodeVon] [datetime] NULL,
	[VerwPeriodeBis] [datetime] NULL,
	[PositionImBeleg] [int] NULL
  )

  /************************************************************************************************/
  /* Bruttobelege verbuchen                                                                       */
  /************************************************************************************************/

--SELECT * FROM #Buchungen BUC
/*
select sum(BruttoBetragProTermin), sum(BetragBrutto), sum(cast(BetragBrutto as real)), sum(IsNull(cast(BruttoBetragProTermin as money),BetragBrutto))
from #Buchungen buc
      LEFT JOIN #vwBgPosition            POS ON POS.BgPositionID         = BUC.BgPositionID
      LEFT JOIN BgAuszahlungPerson       BAP ON BUC.BgPositionID         = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
      LEFT JOIN BgAuszahlungPersonTermin BAT ON BAP.BgAuszahlungPersonID = BAT.BgAuszahlungPersonID
    WHERE ABS(BUC.BetragBrutto) > $0.00
    GROUP BY BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.AuszahlGruppeID, BUC.Einnahme, COALESCE(BAT.Datum, POS.FaelligAm, @FirstDayInMonth), /*BAP.Zahlungsgrund, */BUC.VerwaltungSD, BUC.KbBuchungStatusCode, POS.BaInstitutionID, POS.DebitorBaPersonID, IsNull(VerwPeriodeVon, @FirstDayInMonth), IsNull(VerwPeriodeBis,@LastDayInMonth)
    ORDER BY BUC.BaPersonID_Teil, BUC.AuszahlGruppeID
*/

  SELECT BetragBrutto = SUM(IsNull(CAST(BruttoBetragProTermin AS money),BetragBrutto)), BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, Termin = COALESCE(BAT.Datum, POS.FaelligAm, @FirstDayInMonth), Zahlungsgrund = NULL, /*BAP.Zahlungsgrund, */BUC.VerwaltungSD, BUC.KbBuchungStatusCode, Schuldner_BaInstitutionID = POS.BaInstitutionID, Schuldner_BaPersonID = POS.DebitorBaPersonID, VerwPeriodeVon, VerwPeriodeBis
    INTO #BruttoAuszahlungen
    FROM #Buchungen BUC
      LEFT JOIN #vwBgPosition            POS ON POS.BgPositionID         = BUC.BgPositionID
      LEFT JOIN BgAuszahlungPerson       BAP ON BUC.BgPositionID         = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
      LEFT JOIN BgAuszahlungPersonTermin BAT ON BAP.BgAuszahlungPersonID = BAT.BgAuszahlungPersonID
    WHERE ABS(BUC.BetragBrutto) > $0.00
    GROUP BY BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.AuszahlGruppeID, BUC.Einnahme, COALESCE(BAT.Datum, POS.FaelligAm, @FirstDayInMonth), /*BAP.Zahlungsgrund, */BUC.VerwaltungSD, BUC.KbBuchungStatusCode, POS.BaInstitutionID, POS.DebitorBaPersonID, VerwPeriodeVon, VerwPeriodeBis
    ORDER BY BUC.BaPersonID_Teil, BUC.AuszahlGruppeID



/*
SELECT Referenz = @TotalBetrag, Bruttosumme = SUM(BetragBrutto)
FROM #BruttoAuszahlungen
*/
--DECLARE @BgKostenartID int
/*
  IF (SELECT ABS(SUM(BetragBrutto) - @TotalBetrag) FROM #BruttoAuszahlungen) > $0.05 BEGIN
    SET @msg = 'Die Summe der Bruttobeträge wurde falsch berechnet!'
    RAISERROR(@msg, 18, 1)
    RETURN -1
  END
*/
  -- Runden
  SET @BetragBruttoRound = $0.00
  SET @RundungsdifferenzBrutto = $0.00

  DECLARE cBelegRunden CURSOR FOR
    SELECT BgKostenartID, SUM(BetragBrutto)
    FROM #BruttoAuszahlungen
    GROUP BY BgKostenartID
    HAVING COUNT(*) > 1

  OPEN cBelegRunden
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cBelegRunden INTO @BgKostenartID, @BelegBetrag
    IF @@FETCH_STATUS < 0 BREAK

    DECLARE cBelegPositionRunden CURSOR FOR
      SELECT BetragBrutto
      FROM #BruttoAuszahlungen
      WHERE BgKostenartID = @BgKostenartID
    FOR UPDATE OF BetragBrutto

    OPEN cBelegPositionRunden
    WHILE 1=1 BEGIN
      FETCH NEXT FROM cBelegPositionRunden INTO @AuszahlBetrag
      IF @@FETCH_STATUS < 0 BREAK
      SET @BetragBruttoRound        = FLOOR((@AuszahlBetrag + @RundungsdifferenzBrutto) * 20.0 + 0.5) / 20.0
      SET @RundungsdifferenzBrutto  = @AuszahlBetrag + @RundungsdifferenzBrutto - @BetragBruttoRound

      UPDATE #BruttoAuszahlungen SET BetragBrutto = @BetragBruttoRound
      WHERE CURRENT OF cBelegPositionRunden

    END
    CLOSE cBelegPositionRunden
    DEALLOCATE cBelegPositionRunden

  END
  CLOSE cBelegRunden
  DEALLOCATE cBelegRunden

  --Wegrunden von minimalen Beträgen (<0.001)
  UPDATE #BruttoAuszahlungen
    SET BetragBrutto = FLOOR(BetragBrutto * 20.0 + 0.5) / 20.0
  WHERE ABS(FLOOR(BetragBrutto * 20.0 + 0.5) / 20.0 - BetragBrutto) < 0.003

/*
  SELECT CAST(BetragBrutto as money), *
  FROM #BruttoAuszahlungen
  WHERE ABS(CAST(BetragBrutto as money)) % 0.05 BETWEEN 0.00001 AND 0.001
*/
--SELECT *, Betrag = CONVERT(varchar, CONVERT(float,BetragBrutto)) FROM #BruttoAuszahlungen
/*
    SELECT @KbPeriodeID, BKA.BgKostenartID, 1/*Budget*/, GetDate(), TMP.Termin, GetDate(), FLOOR((-SUM(BetragBrutto)) * 20.0 + 0.5) / 20.0, BKA.Name, TMP.KbBuchungStatusCode, @UserID, @BgBudgetID, @Kostenstelle, $0.0,
      CASE TMP.VerwaltungSD WHEN 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END,
      CASE TMP.VerwaltungSD WHEN 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END,
      BKA.Belegart
    FROM #BruttoAuszahlungen TMP
      INNER JOIN BgKostenart BKA ON BKA.BgKostenartID = TMP.BgKostenartID
    GROUP BY BKA.BgKostenartID, Termin, BKA.Name, KbBuchungStatusCode, VerwaltungSD, BKA.Hauptvorgang, BKA.Teilvorgang, BKA.HauptvorgangAbtretung, BKA.TeilvorgangAbtretung, BKA.Belegart
  */

  -- Buchungskopf, gruppiert nach Kostenart/Auszahltermin
  INSERT INTO @KbBuchungBrutto (KbPeriodeID, BgKostenartID, KbBuchungTypCode, BelegDatum, ValutaDatum, ErfassungsDatum, Betrag, [Text], KbBuchungStatusCode, UserID, BgBudgetID, Kostenstelle, BetragEffektiv, Hauptvorgang, Teilvorgang, Belegart, BgPositionID, FaLeistungID, BgSplittingArtCode, Weiterverrechenbar, Quoting, Einnahme)
    SELECT @KbPeriodeID, BKA.BgKostenartID, 1/*Budget*/, GetDate(), TMP.Termin, GetDate(), FLOOR((-SUM(BetragBrutto)) * 20.0 + 0.5) / 20.0, BKA.Name, TMP.KbBuchungStatusCode, @UserID, @BgBudgetID, @Kostenstelle, $0.0,
      CASE TMP.VerwaltungSD WHEN 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END,
      CASE TMP.VerwaltungSD WHEN 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END,
      BKA.Belegart,
      CASE Einnahme WHEN 1 THEN TMP.BgPositionID END, @FaLeistungID, BKA.BgSplittingArtCode, BKA.Weiterverrechenbar, BKA.Quoting, TMP.Einnahme
    FROM #BruttoAuszahlungen TMP
      INNER JOIN BgKostenart BKA ON BKA.BgKostenartID = TMP.BgKostenartID
    GROUP BY BKA.BgKostenartID, Termin, BKA.Name, KbBuchungStatusCode, VerwaltungSD, BKA.Hauptvorgang, BKA.Teilvorgang, BKA.HauptvorgangAbtretung, BKA.TeilvorgangAbtretung, BKA.Belegart, CASE Einnahme WHEN 1 THEN TMP.BgPositionID END, BKA.BgSplittingArtCode, BKA.Weiterverrechenbar, BKA.Quoting, Einnahme

  -- Detailpositionen (mit Quoting)
  INSERT INTO @KbBuchungBruttoPerson (KbBuchungBruttoID, BgPositionID, BaPersonID, Schuldner_BaInstitutionID, Schuldner_BaPersonID, Buchungstext, Betrag, VerwPeriodeVon, VerwPeriodeBis)
    SELECT KBN.KbBuchungBruttoID, AUZ.BgPositionID, AUZ.BaPersonID_Teil, Schuldner_BaInstitutionID, Schuldner_BaPersonID, AUZ.Name, -BetragBrutto,
      VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN AUZ.VerwPeriodeVon ELSE IsNull(AUZ.VerwPeriodeVon, @FirstDayInMonth) END,
      VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN AUZ.VerwPeriodeVon ELSE IsNull(AUZ.VerwPeriodeBis, @LastDayInMonth)  END
    FROM   #BruttoAuszahlungen    AUZ
      INNER JOIN BgKostenart      BKA ON BKA.BgKostenartID = AUZ.BgKostenartID
      INNER JOIN @KbBuchungBrutto KBN ON KBN.BgKostenartID = AUZ.BgKostenartID AND AUZ.Termin = KBN.ValutaDatum
                                           AND KBN.Hauptvorgang = CASE AUZ.VerwaltungSD WHEN 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END
                                           AND KBN.Teilvorgang  = CASE AUZ.VerwaltungSD WHEN 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END
                                           AND AUZ.BgPositionID = CASE AUZ.Einnahme WHEN 1 THEN KBN.BgPositionID ELSE AUZ.BgPositionID END
                                           AND AUZ.Einnahme     = KBN.Einnahme

  DROP TABLE #BruttoAuszahlungen

  -- Position im BruttoBeleg
  DECLARE @KbBuchungBruttoPersonID int,
          @CurrentKbBuchungBruttoID int,
          @LastKbBuchungBruttoID int
  SET @LastKbBuchungBruttoID = NULL

  DECLARE cBrutto CURSOR FOR
    SELECT KbBuchungBruttoPersonID, KbBuchungBruttoID
    FROM @KbBuchungBruttoPerson
    ORDER BY KbBuchungBruttoID

  OPEN cBrutto
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cBrutto INTO @KbBuchungBruttoPersonID, @CurrentKbBuchungBruttoID
    IF @@FETCH_STATUS < 0 BREAK

    IF IsNull(@LastKbBuchungBruttoID, -1) <> @CurrentKbBuchungBruttoID BEGIN
      SET @Pos = 1
      SET @LastKbBuchungBruttoID = @CurrentKbBuchungBruttoID
    END
    ELSE
      SET @Pos = @Pos + 1

    UPDATE @KbBuchungBruttoPerson
    SET PositionImBeleg = @Pos
    WHERE KbBuchungBruttoPersonID = @KbBuchungBruttoPersonID

  END
  CLOSE cBrutto
  DEALLOCATE cBrutto


/*
SELECT *
from KbBuchung
where BgBudgetID = @BgBudgetID

SELECT kbk.*
from KbBuchungKostenart kbk inner join KbBuchung kbn on kbk.KbBuchungID = kbn.KbBuchungID
where BgBudgetID = @BgBudgetID
order by kbk.KbBuchungID

select sum(Betrag) from KbBuchung where BgBudgetID = @BgBudgetID
select sum(KBK.Betrag) from KbBuchungKostenart kbk inner join KbBuchung kbn on kbk.KbBuchungID = kbn.KbBuchungID where BgBudgetID = @BgBudgetID

*/

  DROP TABLE #Buchungen



  /************************************************************************************************/
  /* Belege von temporären Tabellen in 'scharfe' Tabellen kopieren                                */
  /************************************************************************************************/
  IF @PreviewMode = 0 BEGIN
    DECLARE @KbBuchungID_tmp int
    DECLARE @KbBuchungID_new int
    DECLARE @KbBuchungBruttoID_tmp int
    DECLARE @KbBuchungBruttoID_new int
    BEGIN TRY
      BEGIN TRAN

      -- Netto
      DECLARE cKopf CURSOR FAST_FORWARD FOR
        SELECT KbBuchungID
        FROM   @KbBuchung

      OPEN cKopf
      WHILE 1=1 BEGIN
        FETCH NEXT FROM cKopf INTO @KbBuchungID_tmp
        IF @@FETCH_STATUS <> 0 BREAK

        -- PSCD-Belegnummer lösen
        SET @PscdBelegNr = NULL
        EXEC dbo.spKbGetBelegNr_out 'AA', @PscdBelegNr OUT

        --Kopf einfügen
        INSERT INTO KbBuchung ([KbPeriodeID],[IkPositionID],[KbBuchungTypCode],[Code],[BelegNr],[BelegDatum],[ValutaDatum],[TransferDatum],[Betrag],[Text],[KbBuchungStatusCode],
                 [SollKtoNr],[HabenKtoNr],[KbZahlungseingangID],[BaZahlungswegID],[KbAuszahlungsArtCode],[PCKontoNr],[BaBankID],[BankKontoNr],[IBAN],[ReferenzNummer],
                 [Zahlungsgrund],[MitteilungZeile1],[MitteilungZeile2],[MitteilungZeile3],[MitteilungZeile4],[BeguenstigtName],[BeguenstigtName2],[BeguenstigtStrasse],
                 [BeguenstigtHausNr],[BeguenstigtPostfach],[BeguenstigtOrt],[BeguenstigtPLZ],[BeguenstigtLandCode],[BgBudgetID],[BarbelegUserID],[BarbelegDatum],[CashOrCheckAm],
                 [PscdZahlwegArt],[PscdFehlermeldung],[StorniertKbBuchungID],[Schuldner_BaInstitutionID],[Schuldner_BaPersonID],[ModulID],[KbForderungIstSH],[Kostenstelle],
                 [BankName],[BankStrasse],[BankPLZ],[BankOrt],[BankBCN],[ErstelltUserID],[ErstelltDatum],[MutiertUserID],[MutiertDatum], FaLeistungID)
          SELECT [KbPeriodeID],[IkPositionID],[KbBuchungTypCode],[Code],@PscdBelegNr,[BelegDatum],[ValutaDatum],[TransferDatum],[Betrag],[Text],[KbBuchungStatusCode],
                 [SollKtoNr],[HabenKtoNr],[KbZahlungseingangID],[BaZahlungswegID],[KbAuszahlungsArtCode],[PCKontoNr],[BaBankID],[BankKontoNr],[IBAN],[ReferenzNummer],
                 [Zahlungsgrund],[MitteilungZeile1],[MitteilungZeile2],[MitteilungZeile3],[MitteilungZeile4],[BeguenstigtName],[BeguenstigtName2],[BeguenstigtStrasse],
                 [BeguenstigtHausNr],[BeguenstigtPostfach],[BeguenstigtOrt],[BeguenstigtPLZ],[BeguenstigtLandCode],[BgBudgetID],[BarbelegUserID],[BarbelegDatum],[CashOrCheckAm],
                 [PscdZahlwegArt],[PscdFehlermeldung],[StorniertKbBuchungID],[Schuldner_BaInstitutionID],[Schuldner_BaPersonID],[ModulID],[KbForderungIstSH],[Kostenstelle],
                 [BankName],[BankStrasse],[BankPLZ],[BankOrt],[BankBCN],[ErstelltUserID],[ErstelltDatum],[MutiertUserID],[MutiertDatum], FaLeistungID
          FROM @KbBuchung
          WHERE KbBuchungID = @KbBuchungID_tmp

        -- 'echte' ID bestimmen
        SELECT @KbBuchungID_new = SCOPE_IDENTITY()

        -- Detailpositionen einfügen
        INSERT INTO KbBuchungKostenart([KbBuchungID],[BgPositionID],[BgKostenartID],[BaPersonID],[Buchungstext],[Betrag],[KontoNr],[PositionImBeleg],[Hauptvorgang],[Teilvorgang],
                    [Belegart],[VerwPeriodeVon],[VerwPeriodeBis])
          SELECT 	@KbBuchungID_new,[BgPositionID],[BgKostenartID],[BaPersonID],[Buchungstext],[Betrag],[KontoNr],[PositionImBeleg],[Hauptvorgang],[Teilvorgang],
                    [Belegart],[VerwPeriodeVon],[VerwPeriodeBis]
          FROM @KbBuchungKostenart
          WHERE KbBuchungID = @KbBuchungID_tmp
      END
      CLOSE cKopf
      DEALLOCATE cKopf

      -- Brutto
      DECLARE cKopf CURSOR FAST_FORWARD FOR
        SELECT KbBuchungBruttoID, Belegart
        FROM   @KbBuchungBrutto

      OPEN cKopf
      WHILE 1=1 BEGIN
        FETCH NEXT FROM cKopf INTO @KbBuchungBruttoID_tmp, @Belegart
        IF @@FETCH_STATUS <> 0 BREAK

        -- PSCD-Belegnummer lösen
        SET @PscdBelegNr = NULL
        EXEC dbo.spKbGetBelegNr_out @Belegart, @PscdBelegNr OUT

        --Kopf einfügen
        INSERT INTO KbBuchungBrutto ([KbPeriodeID], [BgKostenartID], [KbBuchungTypCode], [Code], [BelegNr], [BelegDatum], [ValutaDatum], [ErfassungsDatum], [TransferDatum], [Zahlungsfrist], [Betrag],
                                     [BetragEffektiv], [DatumEffektiv], [Text], [KbBuchungStatusCode], [UserID], [StorniertKbBuchungBruttoID], [BgBudgetID], [PscdFehlermeldung], [ModulID],
                                     [Kostenstelle], [Hauptvorgang], [Teilvorgang], [Belegart], [FaLeistungID], BgSplittingArtCode, Weiterverrechenbar, Quoting)
          SELECT [KbPeriodeID], [BgKostenartID], [KbBuchungTypCode], [Code], @PscdBelegNr, [BelegDatum], [ValutaDatum], [ErfassungsDatum], [TransferDatum], [Zahlungsfrist], [Betrag],
                 [BetragEffektiv], [DatumEffektiv], [Text], [KbBuchungStatusCode], [UserID], [StorniertKbBuchungBruttoID], [BgBudgetID], [PscdFehlermeldung], [ModulID],
                 [Kostenstelle], [Hauptvorgang], [Teilvorgang], [Belegart], [FaLeistungID], BgSplittingArtCode, Weiterverrechenbar, Quoting
          FROM @KbBuchungBrutto
          WHERE KbBuchungBruttoID = @KbBuchungBruttoID_tmp

        -- 'echte' ID bestimmen
        SELECT @KbBuchungBruttoID_new = SCOPE_IDENTITY()

        -- Falls kein Nettobeleg erzeugt wird, müssen die Bruttobelege separat an PSCD übertragen werden
        IF @KbBuchungIDGBL IS NULL BEGIN
          INSERT INTO KbBuchungBruttoZuUebertragen
          VALUES (@KbBuchungBruttoID_new, @BgBudgetID)
        END

        -- Detailpositionen einfügen
        INSERT INTO KbBuchungBruttoPerson ([KbBuchungBruttoID], [BgPositionID], [BaPersonID], [Schuldner_BaInstitutionID], [Schuldner_BaPersonID],	[Buchungstext], [Betrag], [VerwPeriodeVon], [VerwPeriodeBis], [PositionImBeleg])
          SELECT 	@KbBuchungBruttoID_new, [BgPositionID], [BaPersonID], [Schuldner_BaInstitutionID], [Schuldner_BaPersonID],	[Buchungstext], [Betrag], [VerwPeriodeVon], [VerwPeriodeBis], [PositionImBeleg]
          FROM @KbBuchungBruttoPerson
          WHERE KbBuchungBruttoID = @KbBuchungBruttoID_tmp

      END
      CLOSE cKopf
      DEALLOCATE cKopf

      COMMIT
    END TRY
    BEGIN CATCH
      DECLARE @errormsg varchar(500)
      SET @errormsg = ERROR_MESSAGE()
      ROLLBACK
      RAISERROR(@errormsg,18,1)
    END CATCH
  END

  IF @PreviewMode = 1 BEGIN
    -- Netto Preview
    SELECT Betrag      = CASE WHEN KRE.KontoNr = KBU.HabenKtoNr THEN -Betrag ELSE Betrag END,
           BetragTotal = CASE WHEN KRE.KontoNr = KBU.HabenKtoNr THEN -Betrag ELSE Betrag END,
           *, Zahlungsempfaenger = IsNull(ZPR.NameVorname, ZIN.Name)
    FROM   @KbBuchung KBU
           LEFT JOIN BaZahlungsweg      ZAL ON ZAL.BaZahlungswegID   = KBU.BaZahlungswegID
           LEFT JOIN vwPerson           ZPR ON ZPR.BaPersonID        = ZAL.BaPersonID
           LEFT JOIN vwInstitution      ZIN ON ZIN.BaInstitutionID   = ZAL.BaInstitutionID
           LEFT JOIN KbKonto            KRE ON KRE.KbPeriodeID       = KBU.KbPeriodeID AND ',' + KRE.KbKontoartCodes + ',' LIKE '%30%'
    SELECT BKA.*, PersonName = PRS.NameVorname
    FROM   @KbBuchungKostenart BKA
           LEFT  JOIN vwPerson    PRS ON PRS.BaPersonID  = BKA.BaPersonID
    WHERE  ABS(Betrag) > $0.01

  END
  ELSE IF @PreviewMode = 2 BEGIN
    -- Brutto Preview
    SELECT *
    FROM   @KbBuchungBrutto

    SELECT BKA.*, PersonName = PRS.NameVorname
    FROM   @KbBuchungBruttoPerson  BKA
           LEFT  JOIN vwPerson PRS ON PRS.BaPersonID = BKA.BaPersonID

  END

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
