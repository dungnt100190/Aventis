SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_CreateKbBuchung
GO
/*===============================================================================================
  $Revision: 44 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Grünstellroutine.
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhBudget_CreateKbBuchung]
(
  @BgBudgetID          int,
  @UserID              int,
  @PreviewMode         int = 0,    -- 0: kein Preview (sondern echte Einträge in KbBuchung... Tabellen, 
                                   -- 1: Netto Preview, (temporäre Buchungen generieren)
                                   -- 2: Brutto Preview (temporäre Buchungen generieren)
  @CreateAllLocked     bit = 0,    -- 1: Die Buchungen mit Status 'gesperrt' generieren
  @BgPositionID_IN     int = NULL, -- 1: BgPositionID der Budgetposition, die separat auf grün gestellt werden soll
  @IncludeZahlwegGroup bit = 0,    -- 1: für Einzelpositionen auch weitere Positionen mit gleichem Zahlweg mitberücksichtigen
  @CheckSpezialkonti   bit = 1     -- 1: Prüfen, ob Spezialkonti (falls benützt) genügend Deckung aufweisen
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

          @BuchungenID               int,

          @StartSaldo                money,
          @Summe                     money,
          @BetragKonto               money,

          @BuchungstextZL            varchar(120),  -- Zahlungslauf
          @BuchungstextBL            varchar(120),  -- Beleg

          @msg                       varchar(max),
          @KbPeriodeID               int,
          @TotalBetrag               money,
          @KbBuchungStatusCode       int,
          @Diff                      money,
          @SummeGBLAbzug             money,
          @SummeGBL                  money,
          @BgKostenartIDGBL          int,
          @BgPositionsartIDGBL       int,
          @BgPositionIDGBL           int,

          @KontoNrDebitor            varchar(10),
          @KontoNrKreditor           varchar(10),
          @KontoNrInterneVerrechnung varchar(10),
          @KissStandard              bit,

          @EFBErwerbsaufnahme        bit,

          @KreditorMehrZeilig        VARCHAR(MAX),
          @ClearingNr                VARCHAR(15),
          @ClearingNrNeu             VARCHAR(15),
          
          @ErrorMessage              varchar(max);

  SET @KissStandard = 1


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

  IF @UserID NOT IN (SELECT UserID FROM dbo.XUser WITH (READUNCOMMITTED)) BEGIN
    RAISERROR ('Es existiert kein User mit ID %d!', 18, 1, @UserID)
    RETURN -1
  END

  IF NOT EXISTS (SELECT 1 FROM dbo.BgBudget WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID) BEGIN
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
         @BgKostenartIDGBL        = BPA.BgKostenartID,
         @BgPositionsartIDGBL     = SFP.WhGrundbedarfTypCode,
         @FaLeistungID            = FAL.FaLeistungID
  FROM   dbo.BgBudget                    BBG WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgFinanzplan          SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID     = BBG.BgFinanzplanID
    INNER JOIN dbo.FaLeistung            FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID       = SFP.FaLeistungID
    INNER JOIN dbo.BaPerson              PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID         = FAL.BaPersonID
    INNER JOIN dbo.BgPositionsart        BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartCode = SFP.WhGrundbedarfTypCode AND
                                                                       ISNULL(BPA.DatumVon, '1900-01-01') <= dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) AND 
                                                                       ISNULL(BPA.DatumBis, '9999-12-31') >= dbo.fnLastDayOf(dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1))
  WHERE BBG.BgBudgetID = @BgBudgetID

  IF (@@ROWCOUNT = 0) BEGIN
    RAISERROR ('Inkonsistente Konfiguration im Finanzplan: Es existiert keine Positionsart für den Grundbedarf in diesem Monat.', 18, 1)
    RETURN -1
  END

  IF (@@ROWCOUNT > 1) BEGIN
    RAISERROR ('Inkonsistente Konfiguration im Finanzplan: Es existieren mehrere Positionsarten für den Grundbedarf in diesem Monat.', 18, 1)
    RETURN -1
  END

  IF (@MasterBudget = 1) BEGIN
    RAISERROR ('Dieses Budget ist ein Masterbudget !', 18, 1)
    RETURN -1
  END

  IF (@BgBewilligungStatusCode = 5 AND @BgPositionID_IN IS NULL) BEGIN
    -- Für ein bewilligtes Budget werden keine Vorschaubelege erzeugt    
    IF @PreviewMode > 0
      RETURN 0
    RAISERROR ('Dieses Monatsbudget ist bereits zur Zahlung freigegeben!', 18, 1)
    RETURN -1
  END

  IF (@BgBewilligungStatusCode = 9) BEGIN
    RAISERROR ('Dieses Monatsbudget ist gesperrt!', 18, 1)
    RETURN -1
  END

  /************************************************************************************************/
  /* Check Konsistenz                                                                             */
  /************************************************************************************************/
  DECLARE @COUNT int
  DECLARE @BgPositionID_Parent int;   
      
  SELECT @BgPositionID_Parent = BgPositionID_Parent
  FROM dbo.vwBgPosition 
  WHERE BgBudgetID = @BgBudgetID AND BgPositionID = @BgPositionID_IN              

  -- #vwBgPosition ist eine temporäre Tabelle, die die BgPositionen enthält.
  -- Die Haupt- und Nebenpositionen können nur zusammen auf grün oder grau
  -- gestellt werden: Auch wenn eine BgPositionsID mitgegeben wird, können mehrere
  -- BgPositionen betroffen sein. 

  SELECT *, BelegVorhanden = dbo.fnWhExistsBelegForPosition(BgPositionID)
  INTO #vwBgPosition
  FROM dbo.vwBgPosition
  WHERE BgBudgetID = @BgBudgetID
    AND ((@BgPositionID_IN IS NULL 
      OR BgPositionID = @BgPositionID_IN
      OR (BgKategorieCode IN (100, 101) AND BgPositionID_Parent = @BgPositionID_IN))  --Hauptposition ist angewählt --> alle Nebenpositionen auch grünstellen
      OR (BgKategorieCode IN (100, 101) AND @BgPositionID_Parent IS NOT NULL AND (BgPositionID = @BgPositionID_Parent OR BgPositionID_Parent = @BgPositionID_Parent)) -- Nebenposition ist angewählt --> Hauptposition und alle Nebenpositionen auch grünstellen
    )

  CREATE NONCLUSTERED INDEX [IX_vwBgPosition_BgKategorieCode] ON [dbo].[#vwBgPosition] ([BgKategorieCode])
  CREATE NONCLUSTERED INDEX [IX_vwBgPosition_BgPositionID] ON [dbo].[#vwBgPosition] ([BgPositionID])


  -- Bereits verbuchte Buchungen. Wenn bereits verbuchte Buchungen vorhanden sind, dann kann man nicht auf grün stellen.
  SELECT @COUNT = COUNT(*)
  FROM   dbo.KbBuchung                KBU WITH (READUNCOMMITTED)
    INNER JOIN dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID = KBU.KbBuchungID
  WHERE BgBudgetID = @BgBudgetID AND BgPositionID IN (SELECT BgPositionID FROM #vwBgPosition)
    AND KbBuchungTypCode IN (1/*Budget*/) AND KbBuchungStatusCode NOT IN (5,8,9) --falls Belege in diesen Sati existieren, können neue erzeugt werden 

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Für ' + CASE WHEN @BgPositionID_IN IS NULL THEN  'dieses Budget' ELSE 'diese Budgetposition' END + ' gibt es bereits verbuchte Belege!'
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END

  -- Positionen ohne Positionsarten
  SELECT @COUNT = COUNT(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + BPO.Buchungstext + ' (Betrag: ' + CONVERT(varchar, BPO.Betrag) + ')')
  FROM   #vwBgPosition       BPO
    LEFT JOIN dbo.BgSpezkonto    SPZ WITH (READUNCOMMITTED) ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
    LEFT JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
    LEFT JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = IsNull(BPA.BgKostenartID,    SPZ.BgKostenartID)
  WHERE BPO.BgKategorieCode IN (1, 2, 100) -- Einnahmen, Ausgaben, Einzelzahlungen
    AND (BPO.BetragBudget) > 0
    AND (BKA.BgKostenartID IS NULL )

  IF (@COUNT > 0) BEGIN
    SET @ErrorMessage = 'Den folgenden Positionen dieses Budgets ist keine Leistungsart zugeordnet:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg)
    RETURN -1
  END

  -- Positionen ohne BaAuszahlung-FK
  SELECT @COUNT = COUNT(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + BPO.Buchungstext + ' (Betrag: ' + CONVERT(varchar, BPO.Betrag) + ')')
  FROM   #vwBgPosition BPO
  WHERE (BPO.BgKategorieCode = 101 OR (BPO.BgKategorieCode IN (2, 100) AND BgSpezkontoID IS NULL)) -- Einzelzahlungen, Ausgaben, Zusätzliche Leistung
    AND (BPO.Betrag - BPO.Reduktion) > 0
    AND NOT EXISTS (SELECT 1 FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED)
                    WHERE BgPositionID = BPO.BgPositionID
                      AND (KbAuszahlungsArtCode <> 106 OR BPO.BgKategorieCode <> 2) -- keine Vorerfassung bei Ausgaben
                   )

  IF (@COUNT > 0) BEGIN
    SET @ErrorMessage = 'Die folgenden Positionen dieses Budgets haben keine Auszahlungsangaben:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg)
    RETURN -1
  END

  -- Positionen mit BaAuszahlung-FK aber ohne Zahlweg 
  SELECT @COUNT = COUNT(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + BPO.Buchungstext + ' (Betrag: ' + CONVERT(varchar, BPO.Betrag) + ')')
  FROM   #vwBgPosition           BPO
    LEFT OUTER JOIN dbo.BgAuszahlungPerson BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID
  WHERE  (BPO.BgKategorieCode = 101 OR (BPO.BgKategorieCode IN (2, 100) AND BgSpezkontoID IS NULL)) -- Einnahmen, Ausgaben, Einzelzahlungen
    AND (BPO.Betrag - BPO.Reduktion) > 0
    AND ((BAP.KbAuszahlungsArtCode IN (101, 102) /*Elektronische Auszahlung, PapierVerfügung (nexiste pas)*/ AND BaZahlungswegID IS NULL)
         OR (BAP.BgAuszahlungsTerminCode IS NULL )
         OR (NOT EXISTS (SELECT BgAuszahlungPersonID FROM dbo.BgAuszahlungPersonTermin WITH (READUNCOMMITTED) WHERE BgAuszahlungPersonID = BAP.BgAuszahlungPersonID))
        )

  IF (@COUNT > 0) BEGIN
    SET @ErrorMessage = 'Die folgenden Positionen dieses Budgets haben keinen Auszahlungstermin oder Kreditor:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg)
    RETURN -1
  END

  -- Referenznummer
  SELECT @COUNT = COUNT(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + BPO.Buchungstext + ' (Betrag: ' + CONVERT(varchar, BPO.Betrag) + ')')
  FROM   #vwBgPosition                BPO
    INNER JOIN dbo.BgAuszahlungPerson BAP WITH (READUNCOMMITTED) ON BPO.BgPositionID    = BAP.BgPositionID
    INNER JOIN dbo.BaZahlungsweg      ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID = BAP.BaZahlungswegID
  WHERE (BPO.Betrag - BPO.Reduktion) > 0 AND
          (BAP.ReferenzNummer IS NOT NULL AND dbo.[fnCheckReferenznummer](BAP.ReferenzNummer) = 0 OR
           (ZAL.EinzahlungsscheinCode = 1 AND BAP.ReferenzNummer IS NULL))

  IF (@COUNT > 0) BEGIN
    SET @ErrorMessage = 'Bei folgenden Positionen ist die Referenznummer ungültig:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg)
    RETURN -1
  END

  IF( @BgPositionID_IN IS NULL ) BEGIN -- nur für gesamtes Budget testen
    -- Zuviel Abzug vom GBL
    -- ToDo: Ev. werden hier noch nicht alle Abzüge berücksichtigt
    -- TODO SUM(Betrag) ist eigentlich falsch! Es müsste BetragBudget kontrollieren, hat aber weitere Konsequenzen --> Berechnung Abzug!
    -- siehe Ticket 4111 
    SELECT @SummeGBLAbzug = SUM(BetragBudget)
    FROM   vwBgPosition         BPO
      LEFT JOIN dbo.BgSpezkonto SPK ON SPK.BgSpezkontoID = BPO.BgSpezkontoID      
    WHERE  BgBudgetID = @BgBudgetID
      AND (BgKategorieCode = 101 AND BPO.BgSpezkontoID IS NULL -- Einzelzahlung vom GBL
                 OR BgKategorieCode = 6 /*Vorabzüge*/
                 OR BgKategorieCode = 3 /*Abzahlung*/ AND (SPK.BgKostenartID IS NULL OR SPK.BgKostenartID = @BgKostenartIDGBL)) --Abzahlungen auf anderen Kostenarten ignorieren

    SELECT @SummeGBL = SUM(BetragBudget)
    FROM   #vwBgPosition       BPO
      LEFT JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPO.BgPositionsartID = BPA.BgPositionsartID
    WHERE  BgBudgetID = @BgBudgetID AND BPA.BgKostenartID = @BgKostenartIDGBL

    IF (@SummeGBLAbzug > @SummeGBL) BEGIN
      SET @msg = 'Es werden mehr Abzüge vom GBL gemacht als GBL bewilligt ist!' + char(13) + char(10) + ' Die Differenz beträgt CHF ' + CAST((@SummeGBLAbzug - @SummeGBL) AS varchar )
      RAISERROR ( @msg, 18, 1)
      RETURN -1
    END

    -- Zuviel Kürzungen?
    DECLARE @MaxKuerzungProzent decimal(19,1), @MaxKuerzungProPerson money
    SET @MaxKuerzungProzent = ISNULL(CONVERT(decimal(19,1), dbo.fnXConfig('System\Sozialhilfe\KuerzungMaxProzentsatz', @RefDate)), 15);
    SET @MaxKuerzungProPerson = dbo.fnShGetBetragGBL(@BgFinanzplanID, 1, 0) * @MaxKuerzungProzent / 100.0

    SELECT @Count = COUNT(*), @msg = dbo.ConcDistinct('- ' + PRS.NameVorname + ': Total Kürzungen ' + CONVERT(varchar, SummeKuerzungen) + ' Fr., erlaubt wären maximal ' + CONVERT(varchar, Erlaubt) + ' Fr.' + char(13) + char(10))
    FROM
    (
      SELECT BaPersonID, SummeKuerzungen = SUM(Betrag), Erlaubt = @MaxKuerzungProPerson
      FROM   #vwBgPosition
      WHERE  BgBudgetID = @BgBudgetID
             AND (BgKategorieCode = 4)
      GROUP BY BaPersonID
      HAVING SUM(Betrag) > @MaxKuerzungProPerson
    ) KRZ
      INNER JOIN vwPerson PRS ON PRS.BaPersonID = KRZ.BaPersonID

    IF (@Count > 0) BEGIN
      SET @msg = 'Bei folgenden Klienten überschreitet die Summe der Kürzungen die maximal erlaubten ' + convert(varchar, @MaxKuerzungProzent) + '%% vom personenbezogenen GBL:' + char(13) + char(10) + char(13) + char(10) + @msg
      RAISERROR (@msg, 18, 1)
      RETURN -1
    END

  END

  /************************************************************************************************/
  /* Check Spezialkonti                                                                           */
  /************************************************************************************************/
  IF (IsNull(@CheckSpezialkonti, 1) = 1)
  BEGIN
  -- Prüfen, ob Spezialkonti (falls benützt) genügend Deckung aufweisen
  DECLARE cSpezKonto CURSOR LOCAL FAST_FORWARD FOR
    SELECT 'Das ' + XLC.Text + ' "' + SSK.NameSpezkonto + '" weist zuwenig Deckung auf'
    FROM #vwBgPosition               BPO
--      INNER JOIN BgAuszahlungPerson  STZ ON STZ.BgPositionID   = BPO.BgPositionID
      INNER JOIN dbo.BgSpezkonto         SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID  = BPO.BgSpezkontoID
      INNER JOIN dbo.XLOVCode            XLC WITH (READUNCOMMITTED) ON XLC.LOVName        = 'BgSpezkontoTyp' AND XLC.Code = SSK.BgSpezkontoTypCode
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (101) -- Einzelzahlung
      --ToDo: AND NOT EXISTS (SELECT * FROM KbBuchung WHERE FlTypSourceCode = 105 AND IdSource = SEZ.BgAuszahlungID AND FlBelegStatusCode IN (102, 103, 106)) --verbucht(warnung)/gesperrt
      AND dbo.fnBgSpezkonto(BPO.BgSpezkontoID, 4, @BgBudgetID, default) < $0.00

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
  END

  /************************************************************************************************/
  /* Buchungsperiode bestimmen                                                                    */
  /************************************************************************************************/
  -- get PeriodeID for range and if none within range, get newest open periode (BSS Klibu: KbMandantID = 1)
  SET @KbPeriodeID = dbo.fnKbGetPeriodeID(1, NULL, @BgJahr, @BgMonat, 1)

  IF (@KbPeriodeID IS NULL) BEGIN
    SET @msg = 'Es existiert keine offene Buchungsperiode, die den ' + CONVERT(varchar, @BgMonat) + '. Monat im Jahr ' + CONVERT(varchar, @BgJahr) + ' beinhaltet!'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END

  -- Debitor-/Kreditor- und InterneVerrechnung-Konto bestimmen
  SELECT TOP 1 @KontoNrDebitor = KontoNr
  FROM   dbo.KbKonto WITH (READUNCOMMITTED)
  WHERE  KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes + ',' LIKE '%,20,%'

  SELECT TOP 1 @KontoNrKreditor = KontoNr
  FROM   dbo.KbKonto WITH (READUNCOMMITTED)
  WHERE  KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes  + ',' LIKE '%,30,%'

  SELECT TOP 1 @KontoNrInterneVerrechnung = KontoNr
  FROM   dbo.KbKonto WITH (READUNCOMMITTED)
  WHERE  KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes  + ',' LIKE '%,70,%'

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
    PersonFactor          double precision
  )

  CREATE TABLE #Buchungen (
    BuchungenID           int NOT NULL IDENTITY(1, 1),
    BgPositionID          int NULL,
    BaPersonID            int NULL,
    BetragBrutto          money NULL, --!BSS
    BetragNetto           money NOT NULL,
    KbKostenstelleID      int NULL, --! BSS
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
    TerminFaktor          double precision NULL,
    NettoBetragProTermin  double precision NULL,
    BruttoBetragProTermin double precision NULL,
    BgSplittingArtCode    int NULL
  )
  CREATE NONCLUSTERED INDEX [IX_BaPersonID_Teil] ON [dbo].[#Buchungen] ([BaPersonID_Teil])
  CREATE NONCLUSTERED INDEX [IX_BgPositionID] ON [dbo].[#Buchungen] ([BgPositionID])


  -- Unterstützte Personen im Finanzplan
  INSERT INTO @PersonVerrechnung
    SELECT BFP.BaPersonID, PRS.NameVorname, KST.KbKostenstelleID,
           (SELECT CONVERT(double precision, 1) / COUNT(*)
            FROM  dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED)
            WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1
           )                  AS PersonFactor
    FROM dbo.BgFinanzplan_BaPerson   BFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.vwPerson        PRS ON PRS.BaPersonID = BFP.BaPersonID
      LEFT  JOIN dbo.KbKostenstelle_BaPerson KST WITH (READUNCOMMITTED) ON KST.BaPersonID = PRS.BaPersonID
                                                                       AND @FirstDayInMonth BETWEEN KST.DatumVon AND ISNULL(KST.DatumBis, '99990101')
                                                                       AND @LastDayInMonth BETWEEN KST.DatumVon AND ISNULL(KST.DatumBis, '99990101')
    WHERE BgFinanzplanID = @BgFinanzplanID AND BFP.IstUnterstuetzt = 1

  -- Sind denn überhaupt Personen im Finanzplan?
  SELECT @COUNT = COUNT(*)
  FROM   @PersonVerrechnung

  IF (@COUNT = 0) BEGIN
    SET @msg = 'Diesem Finanzplan sind keine Personen zugeordnet!'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END

  -- Gibt es Positionen von Personen, welche nicht in diesem Finanzplan unterstützt sind?
  SELECT @Count = Count(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + PER.NameVorname + ': ' + BPO.Buchungstext + ' (Betrag: ' + CONVERT(varchar, BPO.Betrag) + ')')
  FROM #vwBgPosition              BPO
    INNER JOIN dbo.vwPerson		    PER ON PER.BaPersonID = BPO.BaPersonID
    LEFT  JOIN @PersonVerrechnung SPP ON SPP.BaPersonID = BPO.BaPersonID
  WHERE  SPP.BaPersonID IS NULL 
  AND  BPO.BetragBudget <> $0.00;

  IF (@Count > 0) BEGIN
    SET @ErrorMessage = 'Folgende Positionen betreffen Personen, welche nicht in diesem Finanzplan unterstützt sind:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg);
    RETURN -1;
  END

--select '@PersonVerrechnung', * FROM @PersonVerrechnung

  -- Buchungen (Ausgaben) aus Monatsbudget
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, KbKostenstelleID, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, KbBuchungStatusCode, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, BPO.BetragBudget   * CASE WHEN BPO.BaPersonID IS NULL OR (BKA.Quoting = 1 AND BPA.BgPositionsartCode NOT IN (32021, 32023)) THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, BPO.BetragRechnung * CASE WHEN BPO.BaPersonID IS NULL OR (BKA.Quoting = 1 AND BPA.BgPositionsartCode NOT IN (32021, 32023)) THEN SPP.PersonFactor ELSE 1.0 END),
      SPP.KbKostenstelleID, --! BSS
      BgPositionsartID     = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID),
      IsNull(BPO.Buchungstext, BPA.Name), BPA.BgKostenartID,
      Einnahme             = 0,
      BgKategorieCode      = BPO.BgKategorieCode,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      LEFT OUTER JOIN dbo.BgSpezkonto         SPZ WITH (READUNCOMMITTED) ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      LEFT OUTER JOIN dbo.BgPositionsart      BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
      LEFT OUTER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = BPA.BgKostenartID
      INNER JOIN @PersonVerrechnung  SPP ON ((BKA.Quoting = 1 AND BPA.BgPositionsartCode NOT IN (32021, 32023)) OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                              SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                              BPO.BaPersonID IS NULL)            /* normales Quoting */
    WHERE (BPO.BgKategorieCode = 2 /*Ausgaben*/ OR (BPO.BgKategorieCode = 100 /*Zusätzliche Leistung*/ AND BPO.BgBewilligungStatusCode = 5 /*bewilligt*/))
      AND (BPO.Betrag - BPO.Reduktion) > 0 AND BPO.BgSpezkontoID IS NULL
      AND BPO.BelegVorhanden = 0 /*keine verbuchten Belege*/

  -- Buchungen (Einnahmen) aus Monatsbudget
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, KbKostenstelleID, BgPositionsartID, Name, BgKostenartID, Einnahme, BgKategorieCode, VerwaltungSD, KbBuchungStatusCode, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, -BPO.BetragBudget   * CASE WHEN BPO.BaPersonID IS NULL OR BKA.Quoting = 1 THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, -BPO.BetragRechnung * CASE WHEN BPO.BaPersonID IS NULL OR BKA.Quoting = 1 THEN SPP.PersonFactor ELSE 1.0 END),
      SPP.KbKostenstelleID, --! BSS
      BgPositionsartID     = IsNull(BPA.BgPositionsartID,@BgPositionsartIDGBL),--CASE BPO.BgKategorieCode WHEN 1 THEN BPA.BgPositionsartID ELSE @BgPositionsartIDGBL END,
      IsNull(BPO.Buchungstext, BPA.Name),
      BgKostenartID        = IsNull(BPA.BgKostenartID, @BgKostenartIDGBL),--CASE BPO.BgKategorieCode WHEN 1 THEN BPA.BgKostenartID ELSE @BgKostenartIDGBL END,
      Einnahme             = 1,
      BgKategorieCode      = BPO.BgKategorieCode,
      VerwaltungSD         = BPO.VerwaltungSD,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      LEFT OUTER JOIN dbo.BgPositionsart      BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = BPO.BgPositionsartID
      LEFT OUTER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = BPA.BgKostenartID
      INNER JOIN @PersonVerrechnung  SPP ON (BKA.Quoting = 1                 OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                             SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                             BPO.BaPersonID IS NULL)            /* normales Quoting */
    WHERE BPO.BgKategorieCode IN (1) --,4) /* Einnahmen, Sanktionen */
      AND ABS(BPO.Betrag - BPO.Reduktion) > 0                           -- positive und negative Einnahmen
      AND BPO.BelegVorhanden = 0          -- noch kein verbuchter Beleg

  -- Buchungen aus Einzelzahlung
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, KbKostenstelleID, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, BgSpezkontoID, KbBuchungStatusCode, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, BPO.BetragBudget * CASE WHEN BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, BPO.BetragBudget * CASE WHEN BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      SPP.KbKostenstelleID,
      BPA.BgPositionsartID,
      IsNull(BPO.Buchungstext, IsNull('Zahlung aus Spezialkonto "' + SPZ.NameSpezkonto + '"', BPA.Name)),
      BgKostenartID        = CASE WHEN BPO.BgSpezkontoID IS NULL THEN @BgKostenartIDGBL /*Einzelzahlung vom GBL*/ ELSE COALESCE(BPA.BgKostenartID, SPZ.BgKostenartID, /*ToDo*/@BgKostenartIDGBL) END,
      Einnahme             = 0,
      BPO.BgKategorieCode, BPO.BgSpezkontoID,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      INNER JOIN @PersonVerrechnung  SPP ON (SPP.BaPersonID       = BPO.BaPersonID OR BPO.BaPersonID IS NULL)
      LEFT OUTER JOIN dbo.BgSpezkonto         SPZ WITH (READUNCOMMITTED) ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      LEFT OUTER JOIN dbo.BgPositionsart      BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
      LEFT OUTER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = BPA.BgKostenartID
    WHERE BPO.BgKategorieCode = 101 /*Einzelzahlung*/
      AND BPO.BelegVorhanden = 0 -- noch kein verbuchter Beleg

  -- Einnahmen aus Abzügen von Verrechnungs-/Abzahlungskonti
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, KbKostenstelleID, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, BgSpezkontoID, VerwaltungSD, KbBuchungStatusCode, BgSplittingArtCode)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, -BPO.BetragBudget * CASE WHEN SPZ.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, -BPO.BetragBudget * CASE WHEN SPZ.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      SPP.KbKostenstelleID,
      SPZ.BgPositionsartID,
      IsNull(BPO.Buchungstext, IsNull('Abzug aus Spezialkonto "' + SPZ.NameSpezkonto + '"', BPA.Name)),
      BgKostenartID        = CASE WHEN BPO.BgSpezkontoID IS NULL THEN @BgKostenartIDGBL /*Einzelzahlung vom GBL*/ ELSE COALESCE(SPZ.BgKostenartID, BPA.BgKostenartID, /*ToDo*/@BgKostenartIDGBL) END,
      Einnahme             = 1,
      BPO.BgKategorieCode, BPO.BgSpezkontoID,
      VerwaltungSD         = 0, -- Abzüge werden gleich behandelt wie nicht abgetretene Einkommen
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode
    FROM #vwBgPosition               BPO
      INNER JOIN dbo.BgSpezkonto         SPZ WITH (READUNCOMMITTED) ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      INNER JOIN @PersonVerrechnung  SPP ON (SPP.BaPersonID       = SPZ.BaPersonID OR SPZ.BaPersonID IS NULL)
      INNER JOIN dbo.BgPositionsart      BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = SPZ.BgPositionsartID AND BPA.BgKategorieCode = BPO.BgKategorieCode
      LEFT OUTER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = BPA.BgKostenartID
    WHERE BPO.BgKategorieCode IN (3 /*Abzahlung*/) --AND SPZ.OhneEinzelzahlung = 1
      AND BPO.BelegVorhanden = 0 -- noch kein verbuchter Beleg

-- select '#Buchungen', * from #Buchungen

  -- Bestimmen, ob EFB ausbezahlt wird
  IF (EXISTS(SELECT *
             FROM #Buchungen BUC
               INNER JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BUC.BgPositionsartID
             WHERE BPA.BgGruppeCode IN (39100, 39110) /*EFB Erwerbsaufnahme*/)) BEGIN
    SET @EFBErwerbsaufnahme = 1
  END

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
  FROM #Buchungen                  TMP
    INNER JOIN dbo.BgAuszahlungPerson  BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID     = TMP.BgPositionID AND (BAP.BaPersonID = TMP.BaPersonID_Teil OR BAP.BaPersonID IS NULL)
    LEFT OUTER JOIN dbo.BaZahlungsweg       BZW WITH (READUNCOMMITTED) ON BZW.BaZahlungswegID  = BAP.BaZahlungswegID
    LEFT OUTER JOIN dbo.BgPositionsart      BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = TMP.BgPositionsartID
    LEFT OUTER JOIN dbo.XLOVCode            XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgGruppe' AND XLC.Code = BPA.BgGruppeCode
  WHERE (BZW.BaPersonID IS NULL AND BAP.KbAuszahlungsArtCode IN (103 /* Cash / Barauszahlung */, 104 /* Check */))
          OR BZW.BaPersonID IN (SELECT FPP.BaPersonID
                                FROM   dbo.BgFinanzplan_BaPerson  FPP WITH (READUNCOMMITTED)
                                WHERE  FPP.BgFinanzplanID = @BgFinanzplanID AND FPP.IstUnterstuetzt = 1)
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
  SELECT POS.BgBudgetID, POS.BaPersonID, BetragBudget = SUM(POS.BetragBudget)
  INTO #VVG
  FROM #vwBgPosition          POS
    INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
  WHERE POA.BgPositionsartCode IN (32021, 32022 /* VVG */, 32023 /* KVG - GBL */)
    AND POS.MaxBeitragSD = $0.00 --AND BgSpezkontoID IS NULL
  GROUP BY POS.BgBudgetID, POS.BaPersonID
--SELECT * FROM #VVG

  DECLARE @VVGDurchschnittBetrag money
  SELECT @VVGDurchschnittBetrag = SUM(BetragBudget) / COUNT(*)
  FROM @PersonVerrechnung  SPP
    LEFT JOIN #VVG         VVG ON VVG.BaPersonID = SPP.BaPersonID

  -- Korrektur Grundbedarf VVG-Abzug
  UPDATE TMP
    SET BetragBrutto = TMP.BetragBrutto - IsNull(VVG.BetragBudget, $0.00) + @VVGDurchschnittBetrag,
        BetragNetto  = TMP.BetragNetto  - IsNull(VVG.BetragBudget, $0.00) + @VVGDurchschnittBetrag
  FROM #Buchungen                  TMP
    LEFT  JOIN #VVG                VVG ON VVG.BgBudgetID = @BgBudgetID AND VVG.BaPersonID = TMP.BaPersonID_Teil
    INNER JOIN @PersonVerrechnung  SPP ON SPP.BaPersonID = TMP.BaPersonID_Teil
  WHERE @VVGDurchschnittBetrag > $0.00 AND TMP.BgPositionsartID = @BgPositionsartIDGBL

  DROP TABLE #VVG

--SELECT 'VVG - Korrektur', * FROM #Buchungen

  /************************************************************************************************/
  /* Direktabzug Kürzungen                                                                        */
  /************************************************************************************************/
  UPDATE TMP
    SET BetragBrutto = TMP.BetragBrutto - SummeKuerzungen,
        BetragNetto  = TMP.BetragNetto  - SummeKuerzungen
  FROM #Buchungen                  TMP
    INNER JOIN (SELECT BaPersonID, SummeKuerzungen = SUM(Betrag)
                FROM   #vwBgPosition
                WHERE  BgBudgetID = @BgBudgetID
                  AND (BgKategorieCode = 4)
                GROUP BY BaPersonID) KRZ ON KRZ.BaPersonID = TMP.BaPersonID_Teil
  WHERE TMP.BgPositionsartID = @BgPositionsartIDGBL


  /************************************************************************************************/
  /* Abzüge und Ausgaben an Dritte                                                                */
  /************************************************************************************************/
  DECLARE @Abzuege TABLE (
    AbzugID            int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    BgPositionID       int NULL,     -- Herkunft,    "Abzugsverursacher"
    BgPositionID_Abzug int NULL,     -- Erstes Ziel  "erstes Abzugsopfer"
    BaPersonID         int NULL,     -- gequotete Person
    BetragNetto        money NOT NULL DEFAULT($0.00),  -- gequoteter Betrag, der (noch) abgezogen wird. Bei erfolgtem Abzug wird dieser reduziert
    BetragNettoAbzug   money NOT NULL DEFAULT($0.00),  -- Hilfsfeld für direkte Abzüge (Bsp. Einkommen <-> EFB)
    BetragBrutto       money NULL DEFAULT($0.00), --BSS!
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
    WHERE TMP.Einnahme = 0 AND (GRP.SumBetragNetto > $0.00 OR GRP.SumBetragBrutto > $0.00)

    -- Abzugsursache abziehen (Bsp EFB) -> netto
    UPDATE TMP
      SET BetragNetto  = TMP.BetragNetto - CASE WHEN TMP.Dritte = 0 AND TMP.Einnahme = 0 THEN ABZ.SumBetragNettoAbzug ELSE $0.00 END,
          BetragBrutto = TMP.BetragBrutto - ABZ.SumBetragBruttoAbzug
    FROM #Buchungen  TMP
      INNER JOIN (SELECT BgPositionID_Abzug, BaPersonID,
                    SumBetragNettoAbzug = SUM(BetragNettoAbzug),
                    SumBetragBruttoAbzug = SUM(BetragBruttoAbzug)
                  FROM @Abzuege
                  WHERE BgPositionID_Abzug = BgPositionID
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
        BetragNetto  = BetragNetto - BetragNettoAbzug, BetragNettoAbzug = $0.00,
        BetragBrutto = BetragBrutto - BetragBruttoAbzug, BetragBruttoAbzug = $0.00


    IF @LoopCount = 1 BEGIN
      IF --1=1 OR
         IsNull(dbo.fnXConfig('System\Sozialhilfe\Belege\LineareEinkommensverteilung', @RefDate), 0) = 1 BEGIN
        -- Einkommen auf alle Ausgaben verteilen
        UPDATE @Abzuege SET BgPositionID_Abzug = NULL

        -- Ausnahmen beim Verteilen: KVG (32020), EFB(32020/32025; da bereits verrechnet), Einzelzahlungen
        SELECT BgPositionID, BaPersonID_Teil, BetragNetto
        INTO #Ausgaben
        FROM #Buchungen            TMP
          LEFT JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = TMP.BgPositionsartID
        WHERE BetragNetto > $0.00 AND Einnahme = 0
          AND BPA.BgPositionsartCode NOT IN (32020, 32121, 32122, 32123, 32124, 32125, 32126, 32127, 32128, 32129, 32130/*, 32021*/) 
          AND BPA.BgKategorieCode NOT IN (100,101) /* Keine Einzelzahlungen */
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
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BetragBrutto, BgKostenartID, Buchungstext)
        SELECT BPO.BgPositionID, BPO.BaPersonID, BPO.Betrag, BPO.Betrag, @BgKostenartIDGBL, BPO.Buchungstext + ' (finanziert vom GBL)'
        FROM #vwBgPosition BPO
        WHERE BPO.BgSpezkontoID IS NULL AND BPO.BgKategorieCode = 101 /* Einzelzahlung aus Grundbedarf */

      -- Kürzungen / Spezialkonto
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BetragBrutto, BgKostenartID, Buchungstext)
        SELECT BPO.BgPositionID, BPO.BaPersonID, BPO.BetragBudget, BPO.BetragBudget,
          BKA.BgKostenartID, IsNull(BSK.NameSpezkonto, BPO.Buchungstext) + IsNull( ' (' + LOV.Text + ')', '')
        FROM #vwBgPosition          BPO
          LEFT OUTER JOIN dbo.BgSpezkonto    BSK WITH (READUNCOMMITTED) ON BSK.BgSpezkontoID = BPO.BgSpezkontoID
          LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BSK.BgPositionsartID
          LEFT OUTER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = IsNull(BSK.BgKostenartID, @BgKostenartIDGBL)
          LEFT OUTER JOIN dbo.XLOVCode       LOV WITH (READUNCOMMITTED) ON LOV.LOVName = 'BgKategorie' AND LOV.Code = BPO.BgKategorieCode
        WHERE BPO.BgKategorieCode IN (3, /*4, */6) /* 3:Abzahlung, 4:Kürzung, 6:Vorabzug */
          AND NOT (BPO.BgKategorieCode = 3 AND IsNull(BPA.BgKategorieCode, 0) = 3 /*AND BSK.OhneEinzelzahlung = 1*/) -- Verrechnung mit Sollstellung

      -- Nicht übernommene Ausgaben 
      -- Bsp Miete 1300.- (wird dem Vermieter ausbezahlt), SD übernimmt aber nur 1000.- -> 300.- müssen sonstwo abgezogen werden werden
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext)
        SELECT BPO.BgPositionID, BPO.BaPersonID, BPO.BetragRechnung - BPO.BetragBudget, BPA.BgKostenartID, BPA.Name + ' (nicht vom SD übernommen)'
        FROM #vwBgPosition           BPO
          INNER JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPO.BgPositionsartID = BPA.BgPositionsartID
        WHERE BPO.BgKategorieCode = 2 /* Ausgaben */
          AND BPO.BetragRechnung > BPO.BetragBudget

      IF IsNull(dbo.fnXConfig('System\Sozialhilfe\Belege\KostendachMiete', @RefDate), 0) = 1 BEGIN
        -- Falls mehr Geld für Miete vorhanden ist als bezahlt werden soll, wird dieses Geld auf andere Miet-Abzüge (bsp Nebenkosten) verteilt (Abzüge werden reduziert)
        UPDATE TMP
          SET BetragNetto = CONVERT(money, dbo.fnMAX(TMP.BetragNetto -
            IsNull((SELECT SUM(BPO.BetragBudget - BPO.BetragRechnung)
                    FROM #vwBgPosition          BPO
                      INNER JOIN dbo.WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID AND SPT.BgGruppeCode = 3206 /* Miete */
                    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2 /* Ausgaben */
                      AND BPO.BetragRechnung < BPO.BetragBudget), $0.00), $0.00))
        FROM @Abzuege               TMP
          INNER JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = TMP.BgPositionID
          INNER JOIN dbo.WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID AND SPT.BgGruppeCode = 3206  /* Miete */
      END


      -- SKOS2005 - EFB / Zulagen Limite
      -- Falls mehr Zulagen bezahlt werden sollen als die Limite erlaubt, wird die Differenz ebenfalls abgezogen
      DECLARE @SumZulage money, @Limit money

      SELECT @SumZulage = SUM(BPO.BetragBudget)
      FROM #vwBgPosition           BPO
        INNER JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
      WHERE BPO.BgKategorieCode = 2
        AND BPA.BgGruppeCode BETWEEN 39000 AND 39999 /* EFB, IZU, MIZ */

      IF @SumZulage > $0.00 BEGIN
        SELECT TOP 1 @Limit = CONVERT(money, CFG.ValueVar)
        FROM dbo.fnXConfigChild('System\Sozialhilfe\SKOS2005\Abzug_Limit\', @RefDate)  CFG
        WHERE CONVERT(int, CFG.Child) <= (SELECT UeGrundbedarf FROM dbo.fnWhKennzahlen(@BgFinanzplanID) KNZ)
        ORDER BY CFG.Child DESC

        IF @SumZulage > @Limit BEGIN
          INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BetragBrutto)
            SELECT BPO.BgPositionID, BPO.BaPersonID,
              BPO.BetragBudget - (BPO.BetragBudget * @Limit / @SumZulage),
              BPO.BetragBudget - (BPO.BetragBudget * @Limit / @SumZulage)
            FROM #vwBgPosition  BPO
              INNER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
            WHERE BPO.BgKategorieCode = 2 -- Ausgaben
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
          @AbzugFactorNetto         double precision,
          @AbzugFactorBrutto        double precision

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
  WHERE BetragNetto < $0.00

  SELECT @SummeGejoined = SUM(ABZ.BetragNetto)
  FROM @Abzuege           ABZ
    INNER JOIN #Buchungen BUC ON BUC.BgPositionID = @BgPositionIDGBL AND BUC.BaPersonID_Teil = ABZ.BaPersonID
  WHERE ABZ.BetragNetto < $0.00

  IF ( @SummeGejoined <> @SummeNegEinkommen ) BEGIN
    SET @msg = 'Die negativen gequoteten Einkommen können nicht entsprechenden GBL-Position zugeordnet werden'
    RAISERROR(@msg, 18, 1)
    RETURN -1
  END

  -- GBL erhöhen
  UPDATE BUC
  SET BUC.BetragNetto = BUC.BetragNetto - ABZ.BetragNetto
  FROM #Buchungen       BUC
    INNER JOIN (SELECT BaPersonID, BetragNetto = SUM(BetragNetto) FROM @Abzuege WHERE BetragNetto < $0.00 GROUP BY BaPersonID ) ABZ ON BUC.BgPositionID = @BgPositionIDGBL AND BUC.BaPersonID_Teil = ABZ.BaPersonID
  WHERE ABZ.BetragNetto < $0.00

  -- Buchung kurzen, die den Abzug verursacht hat (negatives Einkommen)
  UPDATE BUC
  SET BUC.BetragNetto = BUC.BetragNetto + ABZ.BetragNetto
  FROM #Buchungen       BUC
    INNER JOIN @Abzuege ABZ ON ABZ.BgPositionID = BUC.BgPositionID AND ABZ.BaPersonID = BUC.BaPersonID_Teil
  WHERE ABZ.BetragNetto < $0.00

  -- Abzüge leeren
  UPDATE @Abzuege
  SET BetragNetto = $0.00
  WHERE BetragNetto < $0.00

/*
SELECT '#Buchungen', * FROM #Buchungen
SELECT '@Abzuege', * FROM @Abzuege

    SELECT 'cAbzugNetto', BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE ABS(BetragNetto) > $0.01
    ORDER BY BgKostenartID, BaPersonID

    SELECT 'cAbzugBrutto', BaPersonID, BetragBrutto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE ABS(BetragBrutto) > $0.01
    ORDER BY BgKostenartID, BaPersonID
*/

  DECLARE cAbzugNetto CURSOR LOCAL FOR
    SELECT BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE ABS(BetragNetto) > $0.01
    ORDER BY BgKostenartID, BaPersonID
    FOR UPDATE OF BetragNetto

  DECLARE cAbzugBrutto CURSOR LOCAL FOR
    SELECT BgPositionID, BaPersonID, BetragBrutto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE ABS(BetragBrutto) > $0.01
    ORDER BY BgKostenartID, BaPersonID
    FOR UPDATE OF BetragBrutto

  SET @LoopCount = 0
  WHILE @LoopCount < 6 BEGIN
    SET @LoopCount = @LoopCount + 1

-- Reihenfolgen: 1,2(Person/Kostenart), 3,4(Person), 5,6(Finanzplan)
/* -- DEBUG
      SELECT * FROM #Buchungen

      SELECT * FROM @Abzuege
      ORDER BY BgKostenartID, BaPersonID

      SELECT LoopCount = @LoopCount,
        BaPersonID = CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END,
        TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgPositionID, COUNT(*),
        SUM(TMP.BetragNetto),  CASE WHEN MIN(TMP.BetragNetto)  = MAX(TMP.BetragNetto)  THEN 1 ELSE 0 END,
        SUM(TMP.BetragBrutto), CASE WHEN MIN(TMP.BetragBrutto) = MAX(TMP.BetragBrutto) THEN 1 ELSE 0 END
      FROM #Buchungen  TMP
        LEFT  JOIN WhPositionsart   SPT ON SPT.BgPositionsartID = TMP.BgPositionsartID
        LEFT  JOIN XLOVCode         XLC ON XLC.LOVName = 'BgGruppe' AND XLC.Code = SPT.BgGruppeCode
      WHERE Einnahme = 0
        AND (@LoopCount % 2 = 0 OR TMP.Dritte = 0) AND (@LoopCount IN (3, 4, 5, 6) OR TMP.BgKategorieCode NOT IN (100, 101))
      GROUP BY CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgKategorieCode, TMP.BgPositionID
      ORDER BY CASE WHEN TMP.BgKategorieCode IN (100, 101) THEN TMP.BgKategorieCode ELSE 1 END   -- Einzelzahlungen zuletzt kürzen
         , MIN(CASE WHEN SPT.BgGruppeCode = 3202 THEN 9999 ELSE 0 END)                           -- KVG / VVG als letzte BgPosition kürzen
         , MIN(CASE WHEN @LoopCount <= 2 THEN TMP.BgKostenartID ELSE 0 END)
         , MIN(CASE WHEN SPT.BgGruppeCode BETWEEN 3900 AND 3999 THEN SPT.SortKey ELSE 9999 END)  -- SKOS2005 Zulagen
         , MIN(IsNull(XLC.SortKey, 9999)), MIN(SPT.SortKey) DESC
         , CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END
-- */

    DECLARE cBuchung CURSOR LOCAL FAST_FORWARD FOR
      SELECT
        BaPersonID = CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END,
        TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgPositionID, COUNT(*),
        SUM(TMP.BetragNetto),  CASE WHEN MIN(TMP.BetragNetto)  = MAX(TMP.BetragNetto)  THEN 1 ELSE 0 END,
        SUM(TMP.BetragBrutto), CASE WHEN MIN(TMP.BetragBrutto) = MAX(TMP.BetragBrutto) THEN 1 ELSE 0 END
      FROM #Buchungen               TMP
        LEFT OUTER JOIN dbo.WhPositionsart   SPT ON SPT.BgPositionsartID = TMP.BgPositionsartID
        LEFT OUTER JOIN dbo.XLOVCode         XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgGruppe' AND XLC.Code = SPT.BgGruppeCode
      WHERE Einnahme = 0
        AND (@LoopCount % 2 = 0 OR TMP.Dritte = 0) AND (@LoopCount IN (3, 4, 5, 6) OR TMP.BgKategorieCode NOT IN (100, 101))
      GROUP BY CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgKategorieCode, TMP.BgPositionID
      ORDER BY CASE WHEN TMP.BgKategorieCode IN (100, 101) THEN TMP.BgKategorieCode ELSE 1 END   -- Einzelzahlungen zuletzt kürzen
         , MIN(CASE WHEN SPT.BgGruppeCode = 3202 THEN 9999 ELSE 0 END)                           -- KVG / VVG als letzte BgPosition kürzen
         , MIN(CASE WHEN @LoopCount <= 2 THEN TMP.BgKostenartID ELSE 0 END)
         --, MIN(CASE WHEN SPT.BgGruppeCode BETWEEN 39000 AND 39999 THEN SPT.SortKey ELSE 9999 END)  -- SKOS2005 Zulagen, #8492: SKOS-Zulagen werden erst nach GBL gekürzt
         , MIN(IsNull(XLC.SortKey, 9999)), MIN(IsNull(SPT.SortKey, 0)) DESC
         , CASE WHEN @LoopCount <= 4 THEN TMP.BaPersonID_Teil ELSE NULL END

    OPEN cBuchung
    OPEN cAbzugNetto
    OPEN cAbzugBrutto
    SELECT @AbzBetragNetto  = $0.00, @AbzugGruppeBetragNetto  = $0.00, @AbzugFactorNetto  = 1,
           @AbzBetragBrutto = $0.00, @AbzugGruppeBetragBrutto = $0.00, @AbzugFactorBrutto = 1

    WHILE 1 = 1 BEGIN
      IF NOT EXISTS (SELECT * FROM @Abzuege
                     WHERE (@LoopCount % 2 = 1 AND ABS(BetragNetto) > $0.01) OR (@LoopCount % 2 = 0 AND ABS(BetragBrutto) > $0.01)) BEGIN
        BREAK
      END

      IF ((@LoopCount % 2 = 1 AND ABS(@AbzugGruppeBetragNetto) <= $0.01) OR (@LoopCount % 2 = 0 AND ABS(@AbzugGruppeBetragBrutto) <= $0.01)) BEGIN
        SELECT @AbzBetragNetto = $0.00, @AbzBetragBrutto = $0.00
        FETCH NEXT FROM cBuchung INTO @BaPersonID, @BgKostenartID, @BgPositionsartID, @BgPositionID, @AbzugGruppeCount,
          @AbzugGruppeBetragNetto, @AbzugGruppeNettoGleich, @AbzugGruppeBetragBrutto, @AbzugGruppeBruttoGleich
        IF @@FETCH_STATUS < 0 BREAK
-- SELECT 'cBuchung', @BaPersonID, @BgKostenartID, @BgPositionsartID, @BgPositionID, @AbzugGruppeCount, @AbzugGruppeBetragNetto, @AbzugGruppeNettoGleich, @AbzugGruppeBetragBrutto, @AbzugGruppeBruttoGleich
      END

      IF (@LoopCount % 2 = 1) BEGIN  -- Netto
        IF (@AbzBetragNetto <= $0.01) BEGIN
          CLOSE cAbzugNetto
          OPEN cAbzugNetto

          WHILE 1 = 1 BEGIN
            FETCH NEXT FROM cAbzugNetto INTO @AbzBgPositionID, @AbzBaPersonID, @AbzBetragNetto, @AbzBgKostenartID, @AbzBuchungstext
            IF @@FETCH_STATUS < 0 BREAK
            IF (ABS(@AbzBetragNetto) > $0.01
                 AND (@AbzBgKostenartID = @BgKostenartID OR @LoopCount > 2)
                 AND (@AbzBaPersonID    = @BaPersonID    OR @LoopCount > 4)) BEGIN
-- SELECT 'cAbzugNetto', @AbzBetragNetto, @BgPositionID, @AbzBaPersonID, @BaPersonID, @AbzugGruppeBetragNetto, @AbzugGruppeNettoGleich
              BREAK
            END
          END
          IF @@FETCH_STATUS < 0 BEGIN
            SET @AbzugGruppeBetragNetto = $0.00
            CONTINUE
          END
        END

        IF @AbzBetragNetto <= @AbzugGruppeBetragNetto BEGIN
          SELECT @AbzugBetragNetto = @AbzBetragNetto,
                 @AbzugBetragBrutto = $0.00,
                 @AbzugFactorNetto = CONVERT(double precision, (@AbzugGruppeBetragNetto - @AbzBetragNetto)) / @AbzugGruppeBetragNetto,
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
        IF (@AbzBetragBrutto <= $0.01) BEGIN
          CLOSE cAbzugBrutto
          OPEN cAbzugBrutto

          WHILE 1 = 1 BEGIN
            FETCH NEXT FROM cAbzugBrutto INTO @AbzBgPositionID, @AbzBaPersonID, @AbzBetragBrutto, @AbzBgKostenartID, @AbzBuchungstext
            IF @@FETCH_STATUS < 0 BREAK
            IF (ABS(@AbzBetragBrutto) > $0.01
                 AND (@AbzBgKostenartID = @BgKostenartID OR @LoopCount > 2)
                 AND (@AbzBaPersonID    = @BaPersonID    OR @LoopCount > 4)) BEGIN
-- SELECT 'cAbzugBrutto', @AbzBgPositionID, @AbzBaPersonID, @AbzBetragBrutto, @AbzBgKostenartID, @AbzBuchungstext
              BREAK
            END
          END
          IF @@FETCH_STATUS < 0 BEGIN
            SET @AbzugGruppeBetragBrutto = $0.00
            CONTINUE
          END
        END

        IF @AbzBetragBrutto <= @AbzugGruppeBetragBrutto BEGIN
          SELECT @AbzugBetragNetto = $0.00,
                 @AbzugBetragBrutto = @AbzBetragBrutto,
                 @AbzugFactorNetto = 1,
                 @AbzugFactorBrutto = CONVERT(double precision, (@AbzugGruppeBetragBrutto - @AbzBetragBrutto)) / @AbzugGruppeBetragBrutto,
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

/*
IF EXISTS (SELECT * FROM @Buchung)
  SELECT '@Buchung', LoopCount = @LoopCount, AbzugBetragNetto = @AbzugBetragNetto, AbzugBetragBrutto = @AbzugBetragBrutto,
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
        SET BetragNetto  = BUC.BetragNetto  - (TMP.BetragNetto  * SIGN(BUC.BetragNetto)),
            BetragBrutto = BUC.BetragBrutto - (TMP.BetragBrutto * SIGN(BUC.BetragBrutto))
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

  DECLARE cBuchungRunden CURSOR LOCAL FOR
    SELECT BuchungenID, BetragBrutto, BetragNetto
    FROM #Buchungen
    ORDER BY Einnahme, BgKostenartID, BgPositionID

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

/* --
SELECT sumbet = (SELECT SUM(BetragNetto) FROM #Buchungen), *
FROM #Buchungen
ORDER BY BaPersonID_Teil, BuchungenID
-- */

  /************************************************************************************************/
  /* Beträge plausibilisieren                                                                     */
  /************************************************************************************************/
  IF EXISTS (SELECT * FROM @Abzuege WHERE BetragNetto > $0.01) BEGIN
    SET @msg = 'Der Auszahlungsbetrag an den Klienten beträgt:' + CHAR(13)  + CHAR(10) + ' -' + LTrim(STR((SELECT SUM(BetragNetto) FROM @Abzuege), 10, 2)) + ' sFr.'
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
  SET TerminFaktor = TMP.Faktor, NettoBetragProTermin = TMP.Faktor * BetragNetto, BruttoBetragProTermin = TMP.Faktor * BetragBrutto
  FROM #Buchungen BUC
    INNER JOIN (SELECT BgPositionID, Faktor = CONVERT(DOUBLE PRECISION, 1.0) / COUNT(*), BAP.BaPersonID
                FROM dbo.BgAuszahlungPerson               BAP WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BgAuszahlungPersonTermin BPT WITH (READUNCOMMITTED) ON BAP.BgAuszahlungPersonID = BPT.BgAuszahlungPersonID
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
  --!BSS [KbKostenstelleID] [int] NULL,
  [BankName] [varchar](70) NULL,
  [BankStrasse] [varchar](50) NULL,
  [BankPLZ] [varchar](10) NULL,
  [BankOrt] [varchar](60) NULL,
  [BankBCN] [varchar](10) NULL,
  [ErstelltUserID] [int] NULL,
  [ErstelltDatum] [datetime] NOT NULL DEFAULT(GetDate()), --! BSS
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
  [KbForderungArtCode] [int] NULL,
  [VerwPeriodeVon] [datetime] NULL,
  [VerwPeriodeBis] [datetime] NULL,
    [KbKostenstelleID] [int] NULL, --! BSS
    [BgSplittingArtCode] [int] NULL, -- ! BSS
  [Weiterverrechenbar] [bit] NOT NULL DEFAULT (0), -- ! BSS
  [Quoting] [bit] NOT NULL DEFAULT (0) -- ! BSS
)

  /************************************************************************************************/
  /* Nettobelege verbuchen                                                                        */
  /************************************************************************************************/
/*
SELECT * FROM #Buchungen

  SELECT AuszahlBetrag = SUM(IsNull(BUC.NettoBetragProTermin,BUC.BetragNetto)), BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, Datum = IsNull(BAT.Datum,POS.FaelligAm), BUC.TerminFaktor, BAP.KbAuszahlungsArtCode, BAP.BaZahlungswegID, BAP.ReferenzNummer, Zahlungsgrund = NULL,/*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode
    FROM #Buchungen                      BUC
      LEFT JOIN BgPosition               POS ON POS.BgPositionID = BUC.BgPositionID
      LEFT JOIN BgAuszahlungPerson       BAP ON BUC.BgPositionID = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
      LEFT JOIN BgAuszahlungPersonTermin BAT ON BAP.BgAuszahlungPersonID = BAT.BgAuszahlungPersonID
    WHERE ABS(BUC.BetragNetto) > $0.00
    GROUP BY BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.KbKostenstelleID, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, BAP.BaZahlungswegID, IsNull(BAT.Datum,POS.FaelligAm), BAP.KbAuszahlungsArtCode, BUC.TerminFaktor, BAP.ReferenzNummer, /*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode, BUC.AuszahlGruppeID
    ORDER BY BUC.BaPersonID_Teil, BUC.AuszahlGruppeID
*/
  SELECT
    AuszahlungID = IDENTITY(int, 1, 1),
    AuszahlBetrag = SUM(IsNull(CONVERT(MONEY,BUC.NettoBetragProTermin), BUC.BetragNetto)),
    BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.KbKostenstelleID, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme,
    Datum = IsNull(BAT.Datum, POS.FaelligAm), BUC.TerminFaktor, BAP.KbAuszahlungsArtCode, BAP.BaZahlungswegID, BAP.ReferenzNummer,
    Zahlungsgrund = NULL,/*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode,
    BAP.MitteilungZeile1, BAP.MitteilungZeile2, BAP.MitteilungZeile3, BAP.MitteilungZeile4
  INTO #NettoAuszahlungen
  FROM #Buchungen                      BUC
    LEFT JOIN #vwBgPosition            POS ON POS.BgPositionID = BUC.BgPositionID
    LEFT JOIN dbo.BgAuszahlungPerson       BAP WITH (READUNCOMMITTED) ON BUC.BgPositionID = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
    LEFT JOIN dbo.BgAuszahlungPersonTermin BAT WITH (READUNCOMMITTED) ON BAP.BgAuszahlungPersonID = BAT.BgAuszahlungPersonID
  --WHERE ABS(BUC.BetragNetto) > $0.01
  GROUP BY BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.KbKostenstelleID, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme,
    IsNull(BAT.Datum, POS.FaelligAm), BUC.TerminFaktor, BAP.KbAuszahlungsArtCode,  BAP.BaZahlungswegID, BAP.ReferenzNummer,
    /*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode,
    BUC.AuszahlGruppeID, BAP.MitteilungZeile1, BAP.MitteilungZeile2, BAP.MitteilungZeile3, BAP.MitteilungZeile4
  ORDER BY BUC.BaPersonID_Teil, BUC.AuszahlGruppeID


  -- Check Zahlungsweg:
  --  IBAN
/*
--!BSS nocheck
  SELECT @COUNT = COUNT(*)
  FROM #NettoAuszahlungen    AUZ
    INNER JOIN BaZahlungsweg ZAL ON ZAL.BaZahlungswegID = AUZ.BaZahlungswegID
  WHERE  IBANNummer IS NULL AND EinzahlungsscheinCode IN (2,3,5)

  IF @COUNT > 0 BEGIN
    SET @msg = 'Nicht alle verwendeten Zahlungswege haben eine IBAN. Die IBAN ist zwingend, um Auszahlungen zu machen. Tragen sie bitte die IBAN in den Basisdaten bzw im Institutionenstamm ein.'
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END
*/
  --  Gültigkeit
  SELECT @COUNT = COUNT(*), @Msg = dbo.ConcDistinct(char(13) + char(10) + POS.Buchungstext + ' (Betrag: ' + CONVERT(varchar, POS.Betrag) + '), Valuta: ' + CONVERT(varchar, AUZ.Datum, 104) + ', Gültigkeit: ' + IsNull(CONVERT(varchar, ZAL.DatumVon, 104), '-') + ' bis ' + IsNull(CONVERT(varchar, ZAL.DatumBis, 104), '-'))
  FROM #NettoAuszahlungen    AUZ
    INNER JOIN dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID = AUZ.BaZahlungswegID
    INNER JOIN dbo.BgPosition POS WITH (READUNCOMMITTED) ON POS.BgPositionID = AUZ.BgPositionID
  WHERE  AUZ.Datum NOT BETWEEN ZAL.DatumVon AND ZAL.DatumBis

  IF @COUNT > 0 BEGIN
    SET @ErrorMessage = 'Folgende Positionen haben ein Valutadatum, welches ausserhalb des Gültigkeitszeitraums des Zahlungswegs liegt. Überprüfen Sie bitte die Gültigkeit der verwendeten Zahlungswege:' + char(13) + char(10) + '%s';
    RAISERROR ( @ErrorMessage, 18, 1, @Msg);
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
  DECLARE @BaPersonID_Teil  int,
          @AuszahlungID     int,
          @BelegBetrag      money,
          @AuszahlBetrag    money


  SET @BetragNettoRound = $0.00
  SET @RundungsdifferenzNetto = $0.00

  DECLARE cBelegRunden CURSOR LOCAL FOR
    SELECT BgPositionID, BaPersonID_Teil, SUM(AuszahlBetrag)
    FROM #NettoAuszahlungen
    GROUP BY BgPositionID, BaPersonID_Teil
    HAVING COUNT(*) > 1

  OPEN cBelegRunden
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cBelegRunden INTO @BgPositionID, @BaPersonID_Teil, @BelegBetrag
    IF @@FETCH_STATUS < 0 BREAK

    DECLARE cBelegPositionRunden CURSOR LOCAL FOR
      SELECT AuszahlungID, AuszahlBetrag
      FROM #NettoAuszahlungen
      WHERE BgPositionID = @BgPositionID AND BaPersonID_Teil = @BaPersonID_Teil

    OPEN cBelegPositionRunden
    WHILE 1=1 BEGIN
      FETCH NEXT FROM cBelegPositionRunden INTO @AuszahlungID, @AuszahlBetrag
      IF @@FETCH_STATUS < 0 BREAK
      SET @BetragNettoRound        = FLOOR((@AuszahlBetrag + @RundungsdifferenzNetto) * 20.0 + 0.5) / 20.0
      SET @RundungsdifferenzNetto  = @AuszahlBetrag + @RundungsdifferenzNetto - @BetragNettoRound

      UPDATE #NettoAuszahlungen SET AuszahlBetrag = @BetragNettoRound
      WHERE AuszahlungID = @AuszahlungID

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


--SELECT '#NettoAuszahlungen', *, Betrag = CONVERT(varchar, CONVERT(float,AuszahlBetrag)) FROM #NettoAuszahlungen AUZ

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
    SELECT 'cNettoBeleg', Einnahme, Datum, FLOOR((SUM(AuszahlBetrag)) * 20.0 + 0.5) / 20.0,
           BaZahlungswegID, KbAuszahlungsArtCode, Zahlungsgrund, ReferenzNummer, KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4
    FROM #NettoAuszahlungen     AUZ
      LEFT OUTER JOIN #vwBgPosition   BPO ON BPO.BgPositionID     = AUZ.BgPositionID
      LEFT OUTER JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
    WHERE IsNull(KbAuszahlungsArtCode, 0) <> 106 --! BSS Vorerfassung 
    --WHERE  AUZ.Einnahme = 0
    GROUP BY Datum, AUZ.BaZahlungswegID, AUZ.KbAuszahlungsArtCode, Zahlungsgrund, Einnahme, ReferenzNummer, AUZ.KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4
*/

  DECLARE cNettoBeleg CURSOR LOCAL FOR
    SELECT Einnahme, Datum, FLOOR((SUM(AuszahlBetrag)) * 20.0 + 0.5) / 20.0,
           BaZahlungswegID, KbAuszahlungsArtCode, Zahlungsgrund, ReferenzNummer, KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4
    FROM #NettoAuszahlungen     AUZ
      LEFT OUTER JOIN #vwBgPosition   BPO ON BPO.BgPositionID     = AUZ.BgPositionID
      LEFT OUTER JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
    WHERE IsNull(KbAuszahlungsArtCode, 0) <> 106 --! BSS Vorerfassung 
    --WHERE  AUZ.Einnahme = 0
    GROUP BY Datum, AUZ.BaZahlungswegID, AUZ.KbAuszahlungsArtCode, Zahlungsgrund, Einnahme, ReferenzNummer, AUZ.KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4

  DECLARE @BaBankID_Post int, @Einnahme int

  SELECT @BaBankID_Post = BaBankID
  FROM   dbo.BaBank WITH (READUNCOMMITTED)
  WHERE  ClearingNr = '9000'


  OPEN cNettoBeleg
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cNettoBeleg INTO @Einnahme, @ValutaDatum, @SumBetrag, @BaZahlungswegID, @KbAuszahlungsArtCode, @Zahlungsgrund, @ReferenzNummer, @KbBuchungStatusCode, @Schuldner_BaInstitutionID, @Schuldner_BaPersonID, @BgPositionID_Einzahlung, @MitteilungZeile1, @MitteilungZeile2, @MitteilungZeile3, @MitteilungZeile4
    IF @@FETCH_STATUS < 0 BREAK

    -- Buchungskopf
    IF( @Einnahme = 0 ) BEGIN --Ausgabe

      IF (@KbAuszahlungsArtCode IN (103,104)) BEGIN -- Barauszahlung/Check
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


        INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, ErstelltUserID, SollKtoNr, HabenKtoNr,
                                KbAuszahlungsArtCode, BgBudgetID, PscdZahlwegArt/*, KbKostenstelleID*/, BeguenstigtName, BeguenstigtStrasse, BeguenstigtOrt, FaLeistungID)
        VALUES( @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, @SumBetrag, CASE @KbAuszahlungsArtCode WHEN 103 THEN 'Barauszahlung' ELSE 'Check' END + IsNull(' an ' + @MitteilungZeile1tmp,''), @KbBuchungStatusCode, @UserID, NULL, @KontoNrKreditor,
               @KbAuszahlungsArtCode, @BgBudgetID, CASE @KbAuszahlungsArtCode WHEN 103 THEN 'C' END/*, KbKostenstelleID*/, @MitteilungZeile1tmp, @MitteilungZeile2tmp, @MitteilungZeile3tmp, @FaLeistungID )
      END
/*
      ELSE IF (@KbAuszahlungsArtCode = 104) BEGIN -- Check
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


        INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, ErstelltUserID, SollKtoNr, HabenKtoNr,
                                KbAuszahlungsArtCode, BgBudgetID, PscdZahlwegArt/*, KbKostenstelleID*/, BeguenstigtName, BeguenstigtStrasse, BeguenstigtOrt, FaLeistungID)
        VALUES( @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, @SumBetrag, 'Check' + IsNull(' an ' + @MitteilungZeile1tmp,''), @KbBuchungStatusCode, @UserID, NULL, @KontoNrKreditor,
               @KbAuszahlungsArtCode, @BgBudgetID, NULL/*, KbKostenstelleID*/, @MitteilungZeile1tmp, @MitteilungZeile2tmp, @MitteilungZeile3tmp, @FaLeistungID )
      END
*/
      ELSE BEGIN
      
      -- #4644: Hat der Zalungsweg eine Bank mit einer neuen ClearingNr?
      SELECT TOP 1 
        @KreditorMehrZeilig = KreditorMehrZeilig,  
        @ClearingNr = ClearingNr, 
        @ClearingNrNeu = ClearingNrNeu
      FROM dbo.vwKreditor  BZW 
        LEFT  JOIN dbo.BaBank BNK ON BNK.BaBankID = BZW.BaBankID
      WHERE BZW.BaZahlungswegID = @BaZahlungswegID
   
      IF @ClearingNrNeu IS NOT NULL
      BEGIN
        CLOSE cNettoBeleg
        DEALLOCATE cNettoBeleg
        DECLARE @Message VARCHAR(MAX)
        SET @Message = 'Der Zahlungsweg mit der ID %d hat eine Bank (ClearingNr %s) mit einer neuen ClearingNr.' + CHAR(13) + CHAR(10) +
                       'Kreditor:'+ CHAR(13) + CHAR(10) +
                       '%s'
        RAISERROR (@Message, 18, 1, @BaZahlungswegID, @ClearingNr, @KreditorMehrZeilig)
        RETURN -1
      END
      
        -- Elektronische Auszahlung
        INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID, SollKtoNr, HabenKtoNr,
                                KbAuszahlungsArtCode, PCKontoNr, BaBankID, BankKontoNr, IBAN, ReferenzNummer, Zahlungsgrund, BeguenstigtName, BeguenstigtName2, BeguenstigtStrasse, BeguenstigtHausNr, BeguenstigtPLZ, BeguenstigtOrt,
                                BgBudgetID, PscdZahlwegArt, ModulID, /*KbKostenstelleID,*/ BankName, BankStrasse, BankPLZ, BankOrt, BankBCN, ErstelltUserID, FaLeistungID,
                                MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4)
          SELECT @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, @SumBetrag,
               'an ' + CASE WHEN ZAL.BaZahlungswegID IS NOT NULL THEN CAST(CASE WHEN ZAL.BaPersonID IS NOT NULL THEN ZAL.PersonNameVorname WHEN ZAL.BaInstitutionID IS NOT NULL THEN ZAL.InstitutionName END AS varchar) + '; am ' + CONVERT(varchar,@ValutaDatum,104) WHEN @KbAuszahlungsArtCode = 103 THEN 'Barauszahlung' ELSE '' END,
               @KbBuchungStatusCode, @BaZahlungswegID, NULL, @KontoNrKreditor,
               @KbAuszahlungsArtCode, CASE WHEN (BNK.PCKontoNr IS NOT NULL AND BNK.PCKontoNr <> '') THEN BNK.PCKontoNr ELSE ZAL.PostKontoNummer END, ZAL.BaBankID, ZAL.BankKontoNummer, ZAL.IBANNummer, @ReferenzNummer, @Zahlungsgrund,
               ZAL.BeguenstigtName,
               ZAL.BeguenstigtName2,
               ZAL.BeguenstigtStrasse,
               ZAL.BeguenstigtHausNr,
               ZAL.BeguenstigtPLZ,
               ZAL.BeguenstigtOrt,
               @BgBudgetID,
               IsNull( XLA.Value1, XLE.Value1 ), ModulID = 3 /*W*/, /*@Kostenstelle,*/
               BNK.Name, BNK.Strasse, BNK.PLZ, BNK.Ort, BNK.ClearingNr, @UserID, @FaLeistungID, @MitteilungZeile1, @MitteilungZeile2, @MitteilungZeile3, @MitteilungZeile4
          FROM dbo.vwKreditor         ZAL
            LEFT  JOIN dbo.XLOVCode      XLE WITH (READUNCOMMITTED) ON XLE.LOVName = 'BgEinzahlungsschein' AND XLE.Code = ZAL.EinzahlungsscheinCode
            LEFT  JOIN dbo.XLOVCode      XLA WITH (READUNCOMMITTED) ON XLA.LOVName = 'KbAuszahlungsArt'    AND XLA.Code = @KbAuszahlungsArtCode
            LEFT  JOIN dbo.BaBank        BNK WITH (READUNCOMMITTED) ON BNK.BaBankID = CASE WHEN ZAL.BaBankID IS NULL AND (BNK.PCKontoNr IS NOT NULL AND BNK.PCKontoNr <> '' OR ZAL.PostKontoNummer IS NOT NULL AND ZAL.PostKontoNummer <> '') THEN @BaBankID_Post ELSE ZAL.BaBankID END
          WHERE ZAL.BaZahlungswegID = @BaZahlungswegID
          GROUP BY ZAL.BaZahlungswegID, CASE WHEN (BNK.PCKontoNr IS NOT NULL AND BNK.PCKontoNr <> '') THEN BNK.PCKontoNr ELSE ZAL.PostKontoNummer END, ZAL.BaBankID, ZAL.BankKontoNummer, ZAL.IBANNummer, ZAL.BaPersonID, ZAL.BaInstitutionID, ZAL.EinzahlungsscheinCode, ZAL.PersonNameVorname, ZAL.BeguenstigtName, ZAL.BeguenstigtName2, ZAL.BeguenstigtStrasse, ZAL.BeguenstigtHausNr, ZAL.BeguenstigtPLZ, ZAL.BeguenstigtOrt, ZAL.BaInstitutionID, ZAL.PersonStrasseHausNr, ZAL.PersonPLZ, ZAL.PersonOrt, ZAL.InstitutionName, ZAL.InstitutionStrasseHausNr, ZAL.InstitutionPLZ, ZAL.InstitutionOrt, XLA.Value1, XLE.Value1, BNK.Name, BNK.Strasse, BNK.PLZ, BNK.Ort, BNK.ClearingNr

          IF @@ROWCOUNT = 0
          BEGIN
              RAISERROR ('Der angegebene Kreditor ist keiner Person/Institution zugewiesen!', 18, 1)
              RETURN -1
          END 
      END
      
      SET @KbBuchungID = SCOPE_IDENTITY()
   
      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, KontoNr, VerwPeriodeVon, VerwPeriodeBis, KbKostenstelleID, BgSplittingArtCode, Weiterverrechenbar, Quoting)
        SELECT @KbBuchungID, AUZ.BgPositionID, AUZ.BgKostenartID, AUZ.BaPersonID_Teil, AUZ.Name, AuszahlBetrag, NULL,
             BKA.KontoNr,
             VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 THEN @ValutaDatum ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
             VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 THEN NULL         ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth) END,
             AUZ.KbKostenstelleID,
             BgSplittingArtCode = BKA.BgSplittingArtCode,
             Weiterverrechenbar = CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
             Quoting            = BKA.Quoting
        FROM   #NettoAuszahlungen   AUZ
          INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = AUZ.BgKostenartID
          LEFT OUTER JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = AUZ.BgPositionID
          LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
        WHERE AUZ.Datum = @ValutaDatum AND IsNull(AUZ.BaZahlungswegID,-1) = IsNull(@BaZahlungswegID,-1) AND AUZ.KbAuszahlungsArtCode = @KbAuszahlungsArtCode AND IsNull(AUZ.ReferenzNummer,'') = IsNull(@ReferenzNummer,'')
          AND Einnahme = 0
          AND IsNull(AUZ.MitteilungZeile1,'') = IsNull(@MitteilungZeile1,'') AND IsNull(AUZ.MitteilungZeile2,'') = IsNull(@MitteilungZeile2,'') AND IsNull(AUZ.MitteilungZeile3,'') = IsNull(@MitteilungZeile3,'') AND IsNull(AUZ.MitteilungZeile4,'') = IsNull(@MitteilungZeile4,'')

    END
    ELSE BEGIN -- Einnahme
      IF ABS(@SumBetrag) < $0.01 CONTINUE

      DECLARE @ForderungText varchar(200)
      SET @ForderungText = NULL

      IF( @Schuldner_BaInstitutionID IS NOT NULL ) BEGIN
        SELECT @ForderungText = [Name]
        FROM   dbo.BaInstitution WITH (READUNCOMMITTED)
        WHERE  BaInstitutionID = @Schuldner_BaInstitutionID
      END
      ELSE IF( @Schuldner_BaPersonID IS NOT NULL ) BEGIN
        SELECT @ForderungText = NameVorname
        FROM   dbo.vwPerson
        WHERE  BaPersonID = @Schuldner_BaPersonID
      END

      SET @ForderungText = IsNull('von ' + @ForderungText + IsNull('; am ' + CONVERT(varchar,@ValutaDatum,104),''),'Forderung')

      INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID,
                              KbAuszahlungsArtCode, ReferenzNummer, BgBudgetID, PscdZahlwegArt, /*KbKostenstelleID,*/ SollKtoNr, ErstelltUserID, ErstelltDatum, Schuldner_BaPersonID, Schuldner_BaInstitutionID, FaLeistungID)
      VALUES( @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, -@SumBetrag, @ForderungText, @KbBuchungStatusCode, NULL,
              NULL, NULL, @BgBudgetID, NULL, /*@KbKostenstelleID,*/ @KontoNrDebitor, @UserID, GetDate(), @Schuldner_BaPersonID, @Schuldner_BaInstitutionID, @FaLeistungID )

      SET @KbBuchungID = SCOPE_IDENTITY()

      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, KontoNr, VerwPeriodeVon, VerwPeriodeBis, KbKostenstelleID, BgSplittingArtCode, Weiterverrechenbar, Quoting)
        SELECT @KbBuchungID, AUZ.BgPositionID, AUZ.BgKostenartID, AUZ.BaPersonID_Teil, AUZ.Name, -AuszahlBetrag, NULL,
               BKA.KontoNr,
               VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 THEN @ValutaDatum ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
               VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 THEN NULL         ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth) END,
               AUZ.KbKostenstelleID,
               BgSplittingArtCode = BKA.BgSplittingArtCode,
               Weiterverrechenbar = CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
               Quoting            = BKA.Quoting
        FROM   #NettoAuszahlungen   AUZ
          INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = AUZ.BgKostenartID
          LEFT OUTER JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = AUZ.BgPositionID
          LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
        WHERE IsNull(BPO.BaInstitutionID,-1) = IsNull(@Schuldner_BaInstitutionID,-1) AND IsNull(BPO.DebitorBaPersonID,-1) = IsNull(@Schuldner_BaPersonID,-1)
          AND Einnahme = 1 AND @BgPositionID_Einzahlung = AUZ.BgPositionID
          AND IsNull(AUZ.MitteilungZeile1,'') = IsNull(@MitteilungZeile1,'') AND IsNull(AUZ.MitteilungZeile2,'') = IsNull(@MitteilungZeile2,'') AND IsNull(AUZ.MitteilungZeile3,'') = IsNull(@MitteilungZeile3,'') AND IsNull(AUZ.MitteilungZeile4,'') = IsNull(@MitteilungZeile4,'')
    END
  END
  CLOSE cNettoBeleg
  DEALLOCATE cNettoBeleg

-- zusätzliche buchungen für abzüge auf abzahlungskonto
  DECLARE cAbzuege CURSOR LOCAL FOR
    SELECT BgPositionID
    FROM #Buchungen
  WHERE BgKategorieCode = 3
  GROUP BY BgPositionID
  
  OPEN cAbzuege
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cAbzuege INTO @BgPositionID
    IF @@FETCH_STATUS < 0 OR @KontoNrInterneVerrechnung IS NULL BREAK  --'Interne Verrechnung'-Buchungen nur erstellen, wenn ein solches Konto existiert
    
  -- Buchungskopf "BelastungKonto (GBL) -> Interne Verrechnung"
      INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID,
                              KbAuszahlungsArtCode, ReferenzNummer, BgBudgetID, PscdZahlwegArt, /*KbKostenstelleID,*/ SollKtoNr, HabenKtoNr, ErstelltUserID, ErstelltDatum, Schuldner_BaPersonID, Schuldner_BaInstitutionID, FaLeistungID)
      SELECT @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, sum(-BUC.BetragBrutto), 'Abzug aus Spezialkonto "' + SPZ.NameSpezkonto + '"', @KbBuchungStatusCode, NULL,
              105 /*Interne Verrechnung*/, NULL, @BgBudgetID, NULL, /*@KbKostenstelleID,*/ NULL, @KontoNrInterneVerrechnung, @UserID, GetDate(), @Schuldner_BaPersonID, @Schuldner_BaInstitutionID, @FaLeistungID 
      FROM #Buchungen          BUC
        INNER JOIN dbo.BgSpezkonto SPZ  on SPZ.BgSpezKontoID  = BUC.BgSpezkontoID
        LEFT JOIN  dbo.BgPosition  BPO  on BPO.BgPositionID   = BUC.BgPositionID
        LEFT JOIN  dbo.BgKostenart BKA  on BKA.BgKostenartID  = SPZ.BgKostenartID
      WHERE BUC.BgPositionID = @BgPositionID
      GROUP BY SPZ.NameSpezkonto

      SET @KbBuchungID = SCOPE_IDENTITY()

      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, 
    Buchungstext, Betrag, PositionImBeleg, 
    KontoNr, 
    VerwPeriodeVon, 
    VerwPeriodeBis, 
    KbKostenstelleID, 
    BgSplittingArtCode, 
    Weiterverrechenbar, 
    Quoting)
        SELECT @KbBuchungID, BUC.BgPositionID, BUC.BgKostenartID, BUC.BaPersonID_Teil, 
               'Abzug aus Spezialkonto "' + SPZ.NameSpezkonto + '"', -BUC.BetragBrutto, NULL,
               BKA.KontoNr,
               VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 THEN @ValutaDatum ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
               VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 THEN NULL         ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth) END,
               BUC.KbKostenstelleID,
               BgSplittingArtCode = BKA.BgSplittingArtCode,
               Weiterverrechenbar = CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
               Quoting            = BKA.Quoting
        FROM   #Buchungen                    BUC
      INNER JOIN dbo.BgSpezkonto         SPZ ON                        SPZ.BgSpezKontoID    = BUC.BgSpezkontoID
          INNER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = BUC.BgKostenartID
          LEFT OUTER JOIN #vwBgPosition      BPO ON                        BPO.BgPositionID     = BUC.BgPositionID
        WHERE BUC.BgPositionID = @BgPositionID

  -- Buchungskopf "Interne Verrechnung -> GutschriftKonto"
      INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID,
                              KbAuszahlungsArtCode, ReferenzNummer, BgBudgetID, PscdZahlwegArt, /*KbKostenstelleID,*/ SollKtoNr, HabenKtoNr, ErstelltUserID, ErstelltDatum, Schuldner_BaPersonID, Schuldner_BaInstitutionID, FaLeistungID)
      SELECT @KbPeriodeID, 1/*Budget*/, NULL/*BSS! GetDate()*/, @ValutaDatum, SUM(-BUC.BetragBrutto), 'Gutschrift auf Konto "' + BPKA.KontoNr + ' ' + BPKA.Name + '"', @KbBuchungStatusCode, NULL,
              105 /*Interne Verrechnung*/, NULL, @BgBudgetID, NULL, /*@KbKostenstelleID,*/ @KontoNrInterneVerrechnung, NULL, @UserID, GetDate(), @Schuldner_BaPersonID, @Schuldner_BaInstitutionID, @FaLeistungID 
      FROM #Buchungen          BUC
        INNER JOIN dbo.BgSpezkonto SPZ  on SPZ.BgSpezKontoID  = BUC.BgSpezkontoID
        LEFT JOIN  dbo.BgPosition  BPO  on BPO.BgPositionID   = BUC.BgPositionID
        LEFT JOIN  dbo.BgKostenart BKA  on BKA.BgKostenartID  = SPZ.BgKostenartID
        LEFT JOIN  dbo.BgPositionsart BPA  on BPA.BgPositionsartID = BUC.BgPositionsartID
        LEFT JOIN  dbo.BgKostenart BPKA on BPKA.BgKostenartID = BPA.BgKostenartID
      WHERE BUC.BgPositionID = @BgPositionID
      GROUP BY BPKA.KontoNr, BPKA.Name, BKA.KontoNr

      SET @KbBuchungID = SCOPE_IDENTITY()

      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, 
                  Buchungstext, Betrag, PositionImBeleg, 
                  KontoNr, 
                  VerwPeriodeVon, 
                  VerwPeriodeBis, 
                  KbKostenstelleID, 
                  BgSplittingArtCode, 
                  Weiterverrechenbar, 
                  Quoting)
        SELECT @KbBuchungID, BUC.BgPositionID, BPA.BgKostenartID, BUC.BaPersonID_Teil, 
               'Abzug aus Spezialkonto "' + SPZ.NameSpezkonto + '"', -BUC.BetragBrutto, NULL,
               BPKA.KontoNr,
               VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 THEN @ValutaDatum ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
               VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 THEN NULL         ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth) END,
               BUC.KbKostenstelleID,
               BgSplittingArtCode = BKA.BgSplittingArtCode,
               Weiterverrechenbar = CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
               Quoting            = BKA.Quoting
        FROM   #Buchungen                    BUC
      INNER JOIN dbo.BgSpezkonto         SPZ ON                        SPZ.BgSpezKontoID    = BUC.BgSpezkontoID
          INNER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = BUC.BgKostenartID
          LEFT OUTER JOIN #vwBgPosition      BPO ON                        BPO.BgPositionID     = BUC.BgPositionID
      LEFT JOIN  dbo.BgPositionsart BPA  on BPA.BgPositionsartID = BUC.BgPositionsartID
          LEFT JOIN  dbo.BgKostenart BPKA on BPKA.BgKostenartID = BPA.BgKostenartID
        WHERE BUC.BgPositionID = @BgPositionID
  END
  CLOSE cAbzuege
  DEALLOCATE cAbzuege

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

  DECLARE cNetto CURSOR LOCAL FOR
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

    -- Detailpositionen
    INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, KontoNr, VerwPeriodeVon, VerwPeriodeBis, KbKostenstelleID, BgSplittingArtCode, Weiterverrechenbar, Quoting)
      SELECT @KbBuchungIDGBL, BUC.BgPositionID, BUC.BgKostenartID, BUC.BaPersonID_Teil, BUC.Name, $0.00, NULL,
             BKA.KontoNr,
             VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 THEN @ValutaDatum ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
             VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 THEN NULL         ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth) END,
             BUC.KbKostenstelleID,
             BgSplittingArtCode = BKA.BgSplittingArtCode,
             Weiterverrechenbar = CASE WHEN BKA.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
             Quoting            = BKA.Quoting
      FROM   #Buchungen   BUC
        INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = BUC.BgKostenartID
        LEFT  JOIN #vwBgPosition  BPO ON BPO.BgPositionID     = BUC.BgPositionID
      WHERE ABS(BetragNetto) < $0.01 AND Einnahme = 1

/*
    SELECT *
    FROM #Buchungen
    WHERE ABS(BetragNetto) < $0.01 AND Einnahme = 1
*/
  END

  DROP TABLE #Buchungen



  /************************************************************************************************/
  /* Belege von temporären Tabellen in 'scharfe' Tabellen kopieren                                */
  /************************************************************************************************/
  IF @PreviewMode = 0 BEGIN
    -- Pendenz für EFB erstellen
    IF (@EFBErwerbsaufnahme = 1) BEGIN
      DECLARE @CreatorModifier VARCHAR(50)
      SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(@UserID)
      EXEC dbo.spPendenz_AblaufEFBErwerbsaufnahme @BgBudgetID, @CreatorModifier, @RefDate
    END

    DECLARE @KbBuchungID_tmp int
    DECLARE @KbBuchungID_new int
    DECLARE @KbBuchungBruttoID_tmp int
    DECLARE @KbBuchungBruttoID_new int

    BEGIN TRY 
      BEGIN TRAN

    IF EXISTS (SELECT POS2.BgPositionID
                 FROM #vwBgPosition POS2
                    INNER JOIN dbo.BgPosition POS ON POS.BgPositionID = POS2.BgPositionID
                 WHERE POS.BgPositionTS <> POS2.BgPositionTS)
      BEGIN
        RAISERROR('Mindestens eine Position wurde durch einen anderen Benutzer verändert!', 18, 1);
      END

/*
      -- Alte (nicht verbuchte, siehe Check zu Beginn) Belege dieses Budgets löschen
      DECLARE @IDs TABLE( ID int )

      --Brutto
      INSERT INTO @IDs
        SELECT KBB.KbBuchungBruttoID
        FROM KbBuchungBrutto              KBB
          LEFT JOIN KbBuchungBruttoPerson KBP ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
        WHERE BgBudgetID = @BgBudgetID AND KbBuchungTypCode IN (1,2) AND KbBuchungStatusCode IN (1,2) AND (@BgPositionID_IN IS NULL OR BgPositionID = @BgPositionID_IN)
    
      DELETE FROM KbBuchungBruttoPerson    
      WHERE KbBuchungBruttoID IN (SELECT ID FROM @IDs)

      DELETE FROM KbBuchungBrutto
      WHERE KbBuchungBruttoID IN (SELECT ID FROM @IDs)

      DELETE FROM @IDs

      --Netto
      INSERT INTO @IDs
        SELECT DISTINCT KBU.KbBuchungID
        FROM KbBuchung                 KBU
          LEFT JOIN KbBuchungKostenart KBK ON KBU.KbBuchungID = KBK.KbBuchungID
        WHERE BgBudgetID = @BgBudgetID AND KbBuchungTypCode IN (1,2) AND KbBuchungStatusCode IN (1,2) AND (@BgPositionID_IN IS NULL OR BgPositionID = @BgPositionID_IN)

      DELETE FROM KbBuchung    
      WHERE KbBuchungID IN (SELECT ID FROM @IDs)

      DELETE FROM KbBuchungKostenart
      WHERE KbBuchungID IN (SELECT ID FROM @IDs)
*/
      -- Netto
      DECLARE cKopf CURSOR LOCAL FAST_FORWARD FOR
        SELECT KbBuchungID
        FROM   @KbBuchung

      OPEN cKopf
      WHILE 1=1 BEGIN
        FETCH NEXT FROM cKopf INTO @KbBuchungID_tmp
        IF @@FETCH_STATUS <> 0 BREAK

        --Kopf einfügen
        INSERT INTO KbBuchung ([KbPeriodeID],[IkPositionID],[KbBuchungTypCode],/*[Code],*/[BelegNr],[BelegDatum],[ValutaDatum],[TransferDatum],[Betrag],[Text],[KbBuchungStatusCode],
                 [SollKtoNr],[HabenKtoNr],[KbZahlungseingangID],[BaZahlungswegID],[KbAuszahlungsArtCode],[PCKontoNr],[BaBankID],[BankKontoNr],[IBAN],[ReferenzNummer],
                 [Zahlungsgrund],[MitteilungZeile1],[MitteilungZeile2],[MitteilungZeile3],[MitteilungZeile4],[BeguenstigtName],[BeguenstigtName2],[BeguenstigtStrasse],
                 [BeguenstigtHausNr],[BeguenstigtPostfach],[BeguenstigtOrt],[BeguenstigtPLZ],[BeguenstigtLandCode],[BgBudgetID],[BarbelegUserID],[BarbelegDatum],/*[CashOrCheckAm],*/
                 /*[PscdZahlwegArt],[PscdFehlermeldung],*/[StorniertKbBuchungID],[Schuldner_BaInstitutionID],[Schuldner_BaPersonID],/*[ModulID],[KbForderungIstSH],[Kostenstelle],*/
                 [BankName],[BankStrasse],[BankPLZ],[BankOrt],[BankBCN],[ErstelltUserID],[ErstelltDatum],[MutiertUserID],[MutiertDatum])
          SELECT [KbPeriodeID],[IkPositionID],[KbBuchungTypCode],/*[Code],*/[BelegNr],[BelegDatum],[ValutaDatum],[TransferDatum],[Betrag],[Text],[KbBuchungStatusCode],
                 [SollKtoNr],[HabenKtoNr],[KbZahlungseingangID],[BaZahlungswegID],[KbAuszahlungsArtCode],[PCKontoNr],[BaBankID],[BankKontoNr],[IBAN],[ReferenzNummer],
                 [Zahlungsgrund],[MitteilungZeile1],[MitteilungZeile2],[MitteilungZeile3],[MitteilungZeile4],
                 [BeguenstigtName],
                 [BeguenstigtName2],[BeguenstigtStrasse],
                 [BeguenstigtHausNr],[BeguenstigtPostfach],[BeguenstigtOrt],[BeguenstigtPLZ],[BeguenstigtLandCode],[BgBudgetID],[BarbelegUserID],[BarbelegDatum],/*[CashOrCheckAm],*/
                 /*[PscdZahlwegArt],[PscdFehlermeldung],*/[StorniertKbBuchungID],[Schuldner_BaInstitutionID],[Schuldner_BaPersonID],/*[ModulID],[KbForderungIstSH],[Kostenstelle],*/
                 [BankName],[BankStrasse],[BankPLZ],[BankOrt],[BankBCN],[ErstelltUserID],[ErstelltDatum],[MutiertUserID],[MutiertDatum]
          FROM @KbBuchung
          WHERE KbBuchungID = @KbBuchungID_tmp

        -- 'echte' ID bestimmen
        SELECT @KbBuchungID_new = SCOPE_IDENTITY()

        -- Detailpositionen einfügen
        INSERT INTO KbBuchungKostenart([KbBuchungID],[BgPositionID],[BgKostenartID],[BaPersonID],[Buchungstext],[Betrag],[KontoNr],[PositionImBeleg],/*[Hauptvorgang],[Teilvorgang],*/
                    /*[Belegart],*/[KbForderungArtCode],[VerwPeriodeVon],[VerwPeriodeBis], [KbKostenstelleID], [BgSplittingArtCode], [Weiterverrechenbar], [Quoting])
          SELECT 	@KbBuchungID_new,[BgPositionID],[BgKostenartID],KOA.[BaPersonID],[Buchungstext],[Betrag],[KontoNr],[PositionImBeleg],/*[Hauptvorgang],[Teilvorgang],*/
                    /*[Belegart],*/[KbForderungArtCode],[VerwPeriodeVon],[VerwPeriodeBis], KOS.KbKostenstelleID, [BgSplittingArtCode], [Weiterverrechenbar], [Quoting]
          FROM @KbBuchungKostenart    KOA --! BSS
            LEFT  JOIN KbKostenstelle_BaPerson KOS ON KOS.BaPersonID = KOA.BaPersonID --! BSS
                                                  AND @FirstDayInMonth BETWEEN KOS.DatumVon AND ISNULL(KOS.DatumBis, '99990101')
                                                  AND @LastDayInMonth BETWEEN KOS.DatumVon AND ISNULL(KOS.DatumBis, '99990101')
          WHERE KbBuchungID = @KbBuchungID_tmp
        IF @@ROWCOUNT = 0 BEGIN
          RAISERROR('Interner Fehler: Beleg ohne Detailposition erstellt!', 18, 1)
        END
      END
      CLOSE cKopf
      DEALLOCATE cKopf

      -- BgPosition schein-updaten, damit TS verändert wird und nachträgliche Bearbeitungen fehlschlagen (z.B. Sozi verändert Kreditor nachdem Stellenleiter Position bewilligt & grün gestellt hat)
      UPDATE BgPosition
      SET MutiertDatum = MutiertDatum
      WHERE BgPositionID IN (SELECT BgPositionID
                             FROM @KbBuchungKostenart
                             WHERE BgPositionID IS NOT NULL)

      IF @BgPositionID_IN IS NULL BEGIN
        -- ganzes Budget grünstellen
        UPDATE BgBudget SET BgBewilligungStatusCode = 5 /* ersteilt */ WHERE BgBudgetID = @BgBudgetID
      END

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
    SELECT Betrag      = CASE WHEN KRE.KontoNr = KBU.HabenKtoNr THEN Betrag ELSE Betrag END, --! BSS
           BetragTotal = CASE WHEN KRE.KontoNr = KBU.HabenKtoNr THEN Betrag ELSE Betrag END, --! BSS
           *,
      Zahlungsempfaenger = IsNull(ZPR.NameVorname, ZIN.[Name])
    FROM   @KbBuchung KBU
           LEFT JOIN dbo.BaZahlungsweg      ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID   = KBU.BaZahlungswegID
           LEFT JOIN dbo.vwPerson           ZPR ON ZPR.BaPersonID        = ZAL.BaPersonID
           LEFT JOIN dbo.vwInstitution      ZIN ON ZIN.BaInstitutionID   = ZAL.BaInstitutionID
           LEFT JOIN dbo.KbKonto            KRE WITH (READUNCOMMITTED) ON KRE.KbPeriodeID       = KBU.KbPeriodeID AND KRE.KontoNr = @KontoNrKreditor

    SELECT BKA.*, PersonName = PRS.NameVorname
    FROM   @KbBuchungKostenart BKA
           LEFT  JOIN vwPerson    PRS ON PRS.BaPersonID  = BKA.BaPersonID
    WHERE  ABS(Betrag) > $0.01

  END
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
