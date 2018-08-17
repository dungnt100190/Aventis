SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spWhBudget_CreateKbBuchung;
GO
/*===============================================================================================
  $Revision: 52 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spWhBudget_CreateKbBuchung
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
AS 
BEGIN
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
          @Belegart                  varchar(4),
          @BgKostenartID             INT,

          @KreditorMehrZeilig        VARCHAR(MAX),
          @ClearingNr                VARCHAR(15),
          @ClearingNrNeu             VARCHAR(15),
          @Message                   VARCHAR(MAX),
          @BaZahlungswegID           INT


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
         @RefDate                 = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15),
         @BgJahr                  = BBG.Jahr,
         @BgMonat                 = BBG.Monat,
         @Person                  = PRS.Name + IsNull(', ' + Vorname,''),
         @FirstDayInMonth         = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
         @LastDayInMonth          = dbo.fnLastDayOf(@FirstDayInMonth),
         @Kostenstelle            = ORG.Kostenstelle,
         @BgKostenartIDGBL        = BPA.BgKostenartID,
         @BgPositionsartIDGBL     = SFP.WhGrundbedarfTypCode,
         @FaLeistungID            = FAL.FaLeistungID,
         @FaFallID                = FAL.FaFallID,
         @WhHilfeTypCode          = SFP.WhHilfeTypCode
  FROM   dbo.BgBudget               BBG WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgFinanzplan     SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID   = BBG.BgFinanzplanID
    INNER JOIN dbo.FaLeistung       FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID     = SFP.FaLeistungID
    INNER JOIN dbo.BaPerson         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID       = FAL.BaPersonID
    INNER JOIN dbo.XOrgUnit_User    O2U WITH (READUNCOMMITTED) ON FAL.UserID           = O2U.UserID AND O2U.OrgUnitMemberCode = 2 /*Mitglied*/
    INNER JOIN dbo.XOrgUnit         ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID        = O2U.OrgUnitID
    LEFT OUTER JOIN dbo.BgPositionsart   BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = SFP.WhGrundbedarfTypCode
  WHERE BBG.BgBudgetID = @BgBudgetID --77938

  IF (@BgFinanzplanID IS NULL) BEGIN
    RAISERROR ('Der Leistungserbringer ist in keiner Organisationseinheit!', 18, 1)
    RETURN -1
  END

  IF (@MasterBudget = 1) BEGIN
    RAISERROR ('Dieses Budget ist ein Masterbudget !', 18, 1)
    RETURN -1
  END

  IF ( @BgPositionID_IN IS NULL AND @BgBewilligungStatusCode <> 1 AND @WhHilfeTypCode <> 1) BEGIN
    RAISERROR ( 'Der Status wurde durch andere/n BenutzerIn auf grün gestellt. Zur Aktualisierung Button "OK" anklicken.' , 18, 1)
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

  IF (@Kostenstelle IS NULL OR @Kostenstelle = '') BEGIN
    RAISERROR ('Der/die Verantwortliche dieser Leistung gehört einem Team an, das keine Buchungen erstellen darf. Weisen Sie die Leistung einem/einer Verantwortlichen aus einem berechtigten Team zu (QT, Intake, Kleinkinderberatung).', 18, 1)
    RETURN -1
  END

  /************************************************************************************************/
  /* Check Konsistenz                                                                             */
  /************************************************************************************************/
  DECLARE @COUNT int

  -- Wenn Detailposition in @BgPositionID_IN, dann @BgPositionID_IN auf Parent-Position setzen (damit der ganze Beleg in einem Rutsch auf grün gestellt wird)

  IF @BgPositionID_IN IS NOT NULL BEGIN
    SELECT @BgPositionID_IN = IsNull(BgPositionID_Parent,BgPositionID)
    FROM   dbo.BgPosition WITH (READUNCOMMITTED) 
    WHERE  BgPositionID = @BgPositionID_IN
  END

  -- maximale Anzahl grüner Budgets in der Zukunft: 2
  IF @BgPositionID_IN IS NULL BEGIN
    SELECT @COUNT = COUNT(*)
    FROM   dbo.BgBudget WITH (READUNCOMMITTED) 
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
  FROM   dbo.BgPosition           BPO WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = BPA.BgKostenartID
  WHERE BgBudgetID = @BgBudgetID
    AND (@BgPositionID_IN IS NULL OR BgPositionID = @BgPositionID_IN
           OR (BPO.BgKategorieCode IN (100, 101) AND BPO.BgPositionID_Parent = @BgPositionID_IN)) -- für Einzelposition
    AND  BKA.BgSplittingartCode = 2 /*Monat*/ AND (dbo.fnFirstDayOf(VerwPeriodeVon) <> VerwPeriodeVon OR dbo.fnLastDayOf(VerwPeriodeBis) <> VerwPeriodeBis)

  -- Temporärtabelle erstellen
  SELECT *, BelegVorhanden = dbo.fnWhExistsBelegForPosition(BgPositionID)
    INTO #vwBgPosition
  FROM dbo.vwBgPosition
  WHERE BgBudgetID = @BgBudgetID
    AND (@BgPositionID_IN IS NULL OR BgPositionID = @BgPositionID_IN
           OR (BgKategorieCode IN (100, 101) AND BgPositionID_Parent = @BgPositionID_IN)) -- für Einzelposition
    AND @RefDate BETWEEN IsNull(DatumVon, '19000101') AND IsNull(DatumBis, '99991231') 

  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition
  WHERE  BelegVorhanden = 1

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Für ' + CASE WHEN @BgPositionID_IN IS NULL THEN  'dieses Budget' ELSE 'diese Budgetposition' END + ' gibt es bereits verbuchte Belege!'
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END

  -- Positionen ohne Positionsarten

/* Verschlimmbesserung! 
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition       BPO
    LEFT OUTER JOIN dbo.BgSpezkonto    SPZ ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
    LEFT OUTER JOIN dbo.BgPositionsart BPA 
        ON BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
    LEFT OUTER JOIN dbo.BgKostenart    BKA 
        ON BKA.BgKostenartID    = IsNull(BPA.BgKostenartID,    SPZ.BgKostenartID)
        AND (BKA.BgKostenartID IS NULL )
  WHERE 
    BPO.BgKategorieCode IN (1, 2, 100) 
    AND (BPO.BetragBudget) > 0
                                              -- Einnahmen, Ausgaben, Einzelzahlungen
                                              --    AND (BPO.Betrag - BPO.Reduktion) > 0
*/


  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition           BPO
    LEFT JOIN dbo.BgSpezkonto    SPZ WITH(READUNCOMMITTED) ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
    LEFT JOIN dbo.BgPositionsart BPA WITH(READUNCOMMITTED) ON BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
    LEFT JOIN dbo.BgKostenart    BKA WITH(READUNCOMMITTED) ON BKA.BgKostenartID    = IsNull(BPA.BgKostenartID,    SPZ.BgKostenartID)
  WHERE BPO.BgKategorieCode IN (1, 2, 100) -- Einnahmen, Ausgaben, Einzelzahlungen
    AND (BPO.BetragBudget) > 0
    AND (BKA.BgKostenartID IS NULL )
  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Nicht allen Positionen dieses Budgets ist eine Leistungsart zugeordnet!', 18, 1)
    RETURN -1
  END

  -- Haupt-/Teilvorgang nicht definiert
  IF @KissStandard = 0 BEGIN
    SELECT @COUNT = COUNT(*), @msg = dbo.ConcDistinct(BKA.KontoNr + ' (' + BKA.Name + ', ' + CASE WHEN BPO.VerwaltungSD = 1 THEN 'abgetreten' ELSE 'nicht abgetreten' END +')')
    FROM #vwBgPosition         BPO
      LEFT OUTER JOIN dbo.BgSpezkonto    SPZ WITH (READUNCOMMITTED) ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
      LEFT OUTER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = COALESCE(BPA.BgKostenartID,  SPZ.BgKostenartID, @BgKostenartIDGBL)
    WHERE (BPO.Betrag - BPO.Reduktion) > 0
      AND BPO.BgPositionID = IsNull(@BgPositionID_IN,BPO.BgPositionID) -- für Einzelposition
      AND BPA.SpezHauptvorgang IS NULL AND BPA.SpezTeilvorgang IS NULL AND 
          (BPO.VerwaltungSD = 1 AND (BKA.HauptvorgangAbtretung IS NULL OR BKA.TeilvorgangAbtretung IS NULL) OR
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
  WHERE (BPO.BgKategorieCode = 101 OR (BPO.BgKategorieCode IN (2, 100) AND BgSpezkontoID IS NULL)) -- Ausgaben, ZL, Einzelzahlungen
    AND (BPO.Betrag - BPO.Reduktion) > 0
    AND (BPO.BgPositionID NOT IN (SELECT BgPositionID FROM BgAuszahlungPerson WHERE BgPositionID IS NOT NULL))

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Nicht alle Positionen dieses Budgets haben Auszahlungsangaben!', 18, 1)
    RETURN -1
  END

  -- Positionen mit BaAuszahlung-FK aber ohne Zahlweg 
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition           BPO
    LEFT OUTER JOIN dbo.BgAuszahlungPerson BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID
  WHERE (BPO.BgKategorieCode = 101 OR (BPO.BgKategorieCode IN (2, 100) AND BgSpezkontoID IS NULL)) -- Ausgaben, ZL, Einzelzahlungen
    AND (BPO.Betrag - BPO.Reduktion) > 0
    AND ((BAP.KbAuszahlungsArtCode = 101           /*Elektronische Auszahlung*/ AND BaZahlungswegID IS NULL)
         OR (BAP.BgAuszahlungsTerminCode IS NULL )
         OR (BAP.BgAuszahlungPersonID NOT IN (SELECT BgAuszahlungPersonID FROM dbo.BgAuszahlungPersonTermin WITH (READUNCOMMITTED) ))
        )

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Nicht alle Positionen dieses Budgets haben einen Auszahlungstermin!', 18, 1)
    RETURN -1
  END

  -- Referenznummer
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition            BPO
    INNER JOIN dbo.BgAuszahlungPerson BAP WITH (READUNCOMMITTED) ON BPO.BgPositionID    = BAP.BgPositionID
    INNER JOIN dbo.BaZahlungsweg      ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID = BAP.BaZahlungswegID
  WHERE (BPO.Betrag - BPO.Reduktion) > 0 AND
          (BAP.Referenznummer IS NOT NULL AND dbo.[fnCheckReferenznummer](BAP.ReferenzNummer) = 0 OR 
           (ZAL.EinzahlungsscheinCode = 1 AND BAP.Referenznummer IS NULL))

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
  FROM   #vwBgPosition            BPO
    LEFT  JOIN dbo.BgSpezkonto    SPZ WITH (READUNCOMMITTED) ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
    LEFT  JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
    INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = IsNull(BPA.BgKostenartID, SPZ.BgKostenartID)
  WHERE BKA.Quoting = 0 AND IsNull(BPO.BaPersonID,SPZ.BaPersonID) IS NULL --AND (BPO.BgKategorieCode IN () OR SPZ.BaPersonID IS NULL)
    AND (BPO.Betrag - BPO.Reduktion) > 0

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Es gibt nicht gequotete Positionen, bei denen ''betrifft Person'' nicht ausgefüllt ist!' + char(13) + char(10) + char(13) + char(10) + @msg
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END


  -- Keine Verwendungsperiode
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition        BPO
--    LEFT  JOIN BgSpezkonto    SPZ ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
--    INNER JOIN BgPositionsart BPA ON BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID,SPZ.BgPositionsartID)
    INNER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = BPA.BgKostenartID
  WHERE  BKA.BgSplittingartCode <> 3 /*Valuta*/ AND (VerwPeriodeVon IS NULL OR (VerwPeriodeBis IS NULL AND BKA.BgSplittingartCode <> 4 /*Entscheid*/))

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Verwendungsperiode von/bis ist nicht für jede Position ausgefüllt!', 18, 1)
    RETURN -1
  END

--temp: default-verwendungsperiode setzen
  UPDATE BPO
  SET  VerwPeriodeVon = @FirstDayInMonth,
       VerwPeriodeBis = CASE WHEN BKA.BgSplittingartCode <> 4 /*Entscheid*/ THEN @LastDayInMonth END
  FROM   #vwBgPosition        BPO
    INNER JOIN dbo.BgSpezkonto    SPZ WITH (READUNCOMMITTED) ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
    INNER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = SPZ.BgPositionsartID
    INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = BPA.BgKostenartID
  WHERE  BKA.BgSplittingartCode <> 3 /*Valuta*/ AND (VerwPeriodeVon IS NULL OR (VerwPeriodeBis IS NULL AND BKA.BgSplittingartCode <> 4 /*Entscheid*/))


  -- Verwendungsperiode Monat prüfen
  SELECT @COUNT = COUNT(*)
  FROM   #vwBgPosition        BPO
    INNER JOIN dbo.BgSpezkonto    SPZ WITH (READUNCOMMITTED) ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
    LEFT  JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID,SPZ.BgPositionsartID)
    INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = IsNull(BPA.BgKostenartID,SPZ.BgKostenartID)
  WHERE  BKA.BgSplittingartCode = 2 /*Monat*/ AND (dbo.fnFirstDayOf(VerwPeriodeVon) <> VerwPeriodeVon OR dbo.fnLastDayOf(VerwPeriodeBis) <> VerwPeriodeBis)

  IF (@COUNT > 0) BEGIN
    RAISERROR ( 'Bei Splittingart Monat muss die Verwendungsperiode vom Anfang eines Monats bis Ende eines Monats dauern!', 18, 1)
    RETURN -1
  END

  -- Fixe Zahladresse
  SELECT @COUNT = COUNT(*), @msg = dbo.ConcDistinct(BKA.KontoNr + IsNull(' ' + BKA.Name,'') + IsNull('. Vorgegebener Kreditor: '+ KRE.InstitutionName + ', ' + KRE.InstitutionAdressZusatz,''))
  FROM   #vwBgPosition        BPO
    INNER JOIN dbo.BgAuszahlungPerson BAP ON BAP.BgPositionID = BPO.BgPositionID 
    LEFT  JOIN dbo.BgSpezkonto    SPZ WITH (READUNCOMMITTED) ON SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
    LEFT  JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID,SPZ.BgPositionsartID)
    INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = IsNull(BPA.BgKostenartID,SPZ.BgKostenartID)
    INNER JOIN dbo.vwKreditor     KRE WITH (READUNCOMMITTED) ON KRE.BaZahlungswegID  = BKA.BaZahlungswegIDFix
  WHERE  BKA.BaZahlungswegIDFix IS NOT NULL AND BAP.BaZahlungswegID <> BKA.BaZahlungswegIDFix

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Eine fixe Zahladresse stimmt nicht mit der hinterlegten überein! Betroffene LAs:' + char(13) + char(10) + char(13) + char(10) + @msg
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END

  IF( @BgPositionID_IN IS NULL ) BEGIN -- nur für gesamtes Budget testen
    -- Zuviel Abzug vom GBL
    -- ToDo: Ev. werden hier noch nicht alle Abzüge berücksichtigt
    SELECT @SummeGBLAbzug = SUM(BetragBudget)
    FROM   #vwBgPosition
    WHERE  BgBudgetID = @BgBudgetID
           AND ((BgKategorieCode = 101 AND BgSpezkontoID IS NULL) -- Einzelzahlung vom GBL
           OR  (BgKategorieCode IN (3 /*Abzahlung*/, 6 /*Vorabzüge*/)))


    SELECT @SummeGBL = SUM(BetragBudget)
    FROM   #vwBgPosition         BPO
      INNER JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPO.BgPositionsartID = BPA.BgPositionsartID
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
      INNER JOIN dbo.BgSpezkonto         SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID  = BPO.BgSpezkontoID
      INNER JOIN dbo.XLOVCode            XLC WITH (READUNCOMMITTED) ON XLC.LOVName        = 'BgSpezkontoTyp' AND XLC.Code = SSK.BgSpezkontoTypCode
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (101) -- Einzelzahlung
      AND BPO.BgPositionID = IsNull(@BgPositionID_IN, BPO.BgPositionID)
      AND dbo.fnBgSpezkonto(BPO.BgSpezkontoID, CASE WHEN BgSpezkontoTypCode IN (1,2) THEN 3 ELSE 4 END, @BgBudgetID, @BgPositionID_IN) < CASE WHEN @BgPositionID_IN IS NOT NULL THEN BPO.BetragBudget ELSE $0.00 END

    
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


  DECLARE cSpezKonto CURSOR FAST_FORWARD FOR
    SELECT 'Das ' + XLC.Text + ' "' + SSK.NameSpezkonto + '" weist zwar per Budgetmonat genug Deckung auf, der aktuelle Saldo reicht jedoch nicht aus'
    FROM #vwBgPosition               BPO
      INNER JOIN dbo.BgSpezkonto         SSK WITH (READUNCOMMITTED) ON SSK.BgSpezkontoID  = BPO.BgSpezkontoID
      INNER JOIN dbo.XLOVCode            XLC WITH (READUNCOMMITTED) ON XLC.LOVName        = 'BgSpezkontoTyp' AND XLC.Code = SSK.BgSpezkontoTypCode
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (101) -- Einzelzahlung
      AND BPO.BgPositionID = IsNull(@BgPositionID_IN, BPO.BgPositionID)
      AND dbo.fnBgSpezkonto(BPO.BgSpezkontoID, CASE WHEN BgSpezkontoTypCode IN (1,2) THEN 3 ELSE 4 END, NULL, @BgPositionID_IN) < CASE WHEN @BgPositionID_IN IS NOT NULL THEN BPO.Betrag ELSE $0.00 END

    
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
  FROM   dbo.KbPeriode WITH (READUNCOMMITTED) 
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
  FROM   dbo.KbKonto WITH (READUNCOMMITTED) 
  WHERE  KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes + ',' LIKE '%,20,%'

  SELECT TOP 1 @KontoNrKreditor = KontoNr
  FROM   dbo.KbKonto WITH (READUNCOMMITTED)
  WHERE  KbPeriodeID = @KbPeriodeID AND ',' + KbKontoartCodes  + ',' LIKE '%,30,%'
  

  /************************************************************************************************/
  /* Monatsbudget verbuchen                                                                       */
  /************************************************************************************************/

  SELECT @BgPositionIDGBL = BgPositionID
  FROM #vwBgPosition
  WHERE BgBudgetID = @BgBudgetID AND BgPositionsartID = @BgPositionsartIDGBL

  -- Personen, Kostenstellen, NrmKonto
  DECLARE @PersonVerrechnung TABLE (
    BaPersonID            int PRIMARY KEY CLUSTERED,
    NamePerson            varchar(200) COLLATE DATABASE_DEFAULT NOT NULL,
    KbKostenstelleID      int,
    PersonFactor          double precision
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
    TerminFaktor          double precision NULL,
    NettoBetragProTermin  double precision NULL,
    BruttoBetragProTermin double precision NULL,
    GBLAufAusgabeKonto    bit NOT NULL DEFAULT (0),
    BgSplittingArtCode    int NULL,
    Hauptvorgang          int NULL,
    Teilvorgang           int NULL
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
           (SELECT CONVERT(double precision, 1) / COUNT(*)
            FROM  dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED) 
            WHERE BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1
           )                  AS PersonFactor
    FROM dbo.BgFinanzplan_BaPerson   BFP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.vwPerson        PRS ON PRS.BaPersonID = BFP.BaPersonID
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
    LEFT  JOIN dbo.vwPerson   PRS ON PRS.BaPersonID = SPP.BaPersonID
  WHERE WohnsitzBaAdresseID IS NULL
    OR VornameName IS NULL
    OR WohnsitzPLZ IS NULL
    OR WohnsitzOrt IS NULL

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Nicht alle Personen des Finanzplans ' +convert(varchar,@BgFinanzplanID)+ ' im Fall '+convert(varchar,@FaFallID)+' haben eine Wohn-/Meldeadresse. Die WMA ist Voraussetzung, um Budgetpositionen zu erstellen.'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END
--bgfinanzplanid, fafallid
  --select '@PersonVerrechnung', * FROM @PersonVerrechnung
  SELECT @COUNT = COUNT(*)
  FROM #vwBgPosition             BPO
    LEFT JOIN @PersonVerrechnung SPP ON SPP.BaPersonID = BPO.BaPersonID
  WHERE BPO.BaPersonID IS NOT NULL AND SPP.BaPersonID IS NULL
    AND BPO.BetragBudget > 0;   --8021: 0-Positionen als Platzhalter sollen keine Fehlermeldung generieren

  IF (@COUNT > 0) BEGIN
    SET @msg = 'Eine unter "Betrifft Person" gewählte Person ist nicht Mitglied dieses Finanzplans'
    RAISERROR (@msg, 18, 1)
    RETURN -1
  END

  -- Buchungen (Ausgaben) aus Monatsbudget
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, Kostenstelle, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, KbBuchungStatusCode, GBLAufAusgabeKonto, BgSplittingArtCode, Hauptvorgang, Teilvorgang)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto     = CONVERT(money, BPO.BetragBudget   * CASE WHEN BKA.Quoting = 1 OR BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto      = CONVERT(money, BPO.BetragRechnung * CASE WHEN BKA.Quoting = 1 OR BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      Kostenstelle     = @Kostenstelle,
      BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID),
      IsNull(BPO.Buchungstext, BPA.Name), BPA.BgKostenartID,
      Einnahme             = 0,
      BgKategorieCode      = BPO.BgKategorieCode,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      GBLAufAusgabeKonto   = CASE WHEN BPO.BgSpezkontoID IS NOT NULL AND BPO.BgPositionsartID = @BgPositionsartIDGBL THEN 1 ELSE 0 END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode,
      Hauptvorgang         = IsNull(BPA.SpezHauptvorgang, BKA.Hauptvorgang),
      Teilvorgang          = IsNull(BPA.SpezTeilvorgang,  BKA.Teilvorgang)
    FROM #vwBgPosition                   BPO
      LEFT OUTER JOIN dbo.BgSpezkonto    SPZ WITH (READUNCOMMITTED) ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
      LEFT OUTER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = BPA.BgKostenartID
      INNER JOIN @PersonVerrechnung      SPP ON (BKA.Quoting = 1 OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                                 SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                                 BPO.BaPersonID IS NULL)            /* normales Quoting */
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND (BPO.BgKategorieCode = 2 /*Ausgaben*/ OR (BPO.BgKategorieCode = 100 /*Zusätzliche Leistung*/ AND BPO.BgBewilligungStatusCode = 5 /*bewilligt*/))
      AND (BPO.Betrag - BPO.Reduktion) > 0 AND (BPO.BgSpezkontoID IS NULL OR BPO.BgPositionsartID = @BgPositionsartIDGBL /*Spezialtrick, um Betrag für Ausgabekonto zu bstimmen*/)
      AND BPO.BelegVorhanden = 0 /*keine verbuchten Belege*/

  -- Buchungen (Einnahmen) aus Monatsbudget
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, Kostenstelle, BgPositionsartID, Name, BgKostenartID, Einnahme, BgKategorieCode, VerwaltungSD, KbBuchungStatusCode, BgSplittingArtCode, Hauptvorgang, Teilvorgang)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, -BPO.BetragBudget   * CASE WHEN BKA.Quoting = 1 OR BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, -BPO.BetragRechnung * CASE WHEN BKA.Quoting = 1 OR BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      Kostenstelle         = @Kostenstelle,
      BgPositionsartID     = IsNull(BPA.BgPositionsartID,@BgPositionsartIDGBL),--CASE BPO.BgKategorieCode WHEN 1 THEN BPA.BgPositionsartID ELSE @BgPositionsartIDGBL END,
      IsNull(BPO.Buchungstext, BPA.Name),
      BgKostenartID        = IsNull(BPA.BgKostenartID, @BgKostenartIDGBL),--CASE BPO.BgKategorieCode WHEN 1 THEN BPA.BgKostenartID ELSE @BgKostenartIDGBL END,
      Einnahme             = 1,
      BgKategorieCode      = BPO.BgKategorieCode,
      VerwaltungSD         = BPO.VerwaltungSD,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode,
      Hauptvorgang         = IsNull(BPA.SpezHauptvorgang, CASE BPO.VerwaltungSD WHEN 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END),
      Teilvorgang          = IsNull(BPA.SpezTeilvorgang,  CASE BPO.VerwaltungSD WHEN 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END)
    FROM #vwBgPosition                   BPO
      LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = BPO.BgPositionsartID
      LEFT OUTER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = BPA.BgKostenartID
      INNER JOIN @PersonVerrechnung      SPP ON (BKA.Quoting = 1                 OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                                 SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                                 BPO.BaPersonID IS NULL)            /* normales Quoting */
    WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (1,4) /* Einnahmen, Sanktionen */
      AND ABS(BPO.Betrag - BPO.Reduktion) > 0                           -- positive und negative Einnahmen
      AND BPO.BelegVorhanden = 0          -- noch kein verbuchter Beleg

  -- Buchungen aus Einzelzahlung
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, Kostenstelle, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, BgSpezkontoID, KbBuchungStatusCode, BgSplittingArtCode, Hauptvorgang, Teilvorgang)
    SELECT DISTINCT BPO.BgPositionID, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE IsNull(BPO.BaPersonID,SPZ.BaPersonID) END, SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, BPO.BetragBudget * CASE WHEN BKA.Quoting = 1 OR IsNull(BPO.BaPersonID,SPZ.BaPersonID) IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, BPO.BetragBudget * CASE WHEN BKA.Quoting = 1 OR IsNull(BPO.BaPersonID,SPZ.BaPersonID) IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      Kostenstelle         = @Kostenstelle,
      BPA.BgPositionsartID,
      IsNull(BPO.Buchungstext, IsNull('Zahlung aus Spezialkonto "' + SPZ.NameSpezkonto + '"', BPA.Name)),
      BgKostenartID        = CASE WHEN BPO.BgSpezkontoID IS NULL THEN @BgKostenartIDGBL /*Einzelzahlung vom GBL*/ ELSE COALESCE(SPZ.BgKostenartID, BPA.BgKostenartID,/*ToDo*/@BgKostenartIDGBL) END,
      Einnahme             = 0,
      BPO.BgKategorieCode, BPO.BgSpezkontoID,
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode,
      Hauptvorgang         = IsNull(BPA.SpezHauptvorgang, BKA.Hauptvorgang),
      Teilvorgang          = IsNull(BPA.SpezTeilvorgang,  BKA.Teilvorgang)
    FROM #vwBgPosition                   BPO
      LEFT OUTER JOIN dbo.BgSpezkonto    SPZ WITH (READUNCOMMITTED) ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = IsNull(BPO.BgPositionsartID, SPZ.BgPositionsartID)
      LEFT OUTER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = COALESCE(BPA.BgKostenartID, SPZ.BgKostenartID, @BgKostenartIDGBL)
      INNER JOIN @PersonVerrechnung      SPP ON (BKA.Quoting = 1                                        OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                                 SPP.BaPersonID = IsNull(BPO.BaPersonID,SPZ.BaPersonID) OR /* kein Quoting */
                                                 IsNull(BPO.BaPersonID,SPZ.BaPersonID) IS NULL)            /* normales Quoting */
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND BPO.BgKategorieCode = 101 /*Einzelzahlung*/
      AND BPO.BelegVorhanden = 0 -- noch kein verbuchter Beleg

  -- Einnahmen aus Abzügen von Verrechnungs-/Abzahlungskonti
  INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, Kostenstelle, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, BgSpezkontoID, VerwaltungSD, KbBuchungStatusCode, BgSplittingArtCode, Hauptvorgang, Teilvorgang)
    SELECT DISTINCT 
      BgPositionID         = BPO.BgPositionID, 
      BaPersonID           = CASE WHEN BKA.Quoting = 1 THEN NULL ELSE IsNull(BPO.BaPersonID, SPZ.BaPersonID) END, 
      BaPersonID_Teil      = SPP.BaPersonID,
      BetragBrutto         = CONVERT(money, -BPO.BetragBudget * CASE WHEN BKA.Quoting = 1 OR IsNull(BPO.BaPersonID, SPZ.BaPersonID) IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      BetragNetto          = CONVERT(money, -BPO.BetragBudget * CASE WHEN BKA.Quoting = 1 OR IsNull(BPO.BaPersonID, SPZ.BaPersonID) IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
      Kostenstelle         = @Kostenstelle,
      BgPositionsartID     = BPA.BgPositionsartID,
      [Name]               = IsNull(BPO.Buchungstext, IsNull('Abzug aus Spezialkonto "' + SPZ.NameSpezkonto + '"', BPA.Name)),
      BgKostenartID        = BKA.BgKostenartID,
      Einnahme             = 1,
      BgKategorieCode      = BPO.BgKategorieCode, 
      BgSpezkontoID        = BPO.BgSpezkontoID,
      VerwaltungSD         = 0, -- Abzüge werden gleich behandelt wie nicht abgetretene Einkommen
      KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
      BgSplittingArtCode   = BKA.BgSplittingArtCode,
      Hauptvorgang         = IsNull(BPA.SpezHauptvorgang, BKA.Hauptvorgang),
      Teilvorgang          = IsNull(BPA.SpezTeilvorgang, BKA.Teilvorgang)
    FROM #vwBgPosition               BPO
      LEFT  JOIN dbo.BgSpezkonto     SPZ WITH (READUNCOMMITTED) ON  SPZ.BgSpezkontoID    = BPO.BgSpezkontoID
      LEFT  JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = SPZ.BgPositionsartID AND BPA.BgKategorieCode = BPO.BgKategorieCode
      INNER JOIN dbo.BgKostenart     BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = IsNull(BPA.BgKostenartID, CASE WHEN SPZ.BgKostenartID IN (206,207,208) OR SPZ.BgKostenartID IS NULL THEN @BgKostenartIDGBL ELSE SPZ.BgKostenartID END)
      INNER JOIN @PersonVerrechnung  SPP ON (BKA.Quoting = 1                                        OR /* quoten auch wenn BaPersonID NOT NULL ist */
                                             SPP.BaPersonID = IsNull(BPO.BaPersonID,SPZ.BaPersonID) OR /* kein Quoting */
                                             IsNull(BPO.BaPersonID,SPZ.BaPersonID) IS NULL)            /* Quoting, aber keine Person angegeben*/
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND BPO.BgKategorieCode IN (3 /*Abzahlung*/) --AND SPZ.OhneEinzelzahlung = 1
      AND BPO.BelegVorhanden = 0 -- noch kein verbuchter Beleg
      
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
  -- Hier wird Dritte = 0, wenn die Zahlung an einen Zahlungsweg geht, der einer unterstützten Person im Finanzplan gehört
  UPDATE TMP
    SET Dritte = 0
  FROM #Buchungen                      TMP
    INNER JOIN dbo.BgAuszahlungPerson  BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID     = TMP.BgPositionID AND (BAP.BaPersonID = TMP.BaPersonID_Teil OR BAP.BaPersonID IS NULL)
    LEFT OUTER JOIN dbo.BaZahlungsweg  BZW WITH (READUNCOMMITTED) ON BZW.BaZahlungswegID  = BAP.BaZahlungswegID
    LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = TMP.BgPositionsartID
  WHERE (BZW.BaPersonID IS NULL AND BAP.KbAuszahlungsArtCode = 103 /* Cash an Klient */)
          OR BZW.BaPersonID IN (SELECT FPP.BaPersonID
                                FROM   dbo.BgFinanzplan_BaPerson  FPP WITH (READUNCOMMITTED) 
                                WHERE  FPP.BgFinanzplanID = @BgFinanzplanID AND FPP.IstUnterstuetzt = 1)

  UPDATE #Buchungen
  SET Dritte = 0
  WHERE GBLAufAusgabeKonto = 1

--SELECT 'Buchungen', * FROM #Buchungen


IF(@BgPositionID_IN IS NULL) BEGIN -- für Einzelposition

  /************************************************************************************************/
  /* Abzüge und Ausgaben an Dritte                                                                */
  /************************************************************************************************/
  DECLARE @Abzuege TABLE
  (
    BgPositionID                 int NULL,     -- Herkunft,    "Abzugsverursacher"
    BgPositionID_Abzug           int NULL,     -- Erstes Ziel  "erstes Abzugsopfer"
    BgPositionID_Gesperrt        int NULL,     -- Von dieser Position darf nicht abgezogen werden (Bsp. EZ vom GBL darf nicht sich selbst kürzen)
    BaPersonID                   int NULL,     -- gequotete Person
    BetragNetto                  money NOT NULL DEFAULT($0.00),  -- gequoteter Betrag, der (noch) abgezogen wird. Bei erfolgtem Abzug wird dieser reduziert
    BetragNettoAbzug             money NOT NULL DEFAULT($0.00),  -- Hilfsfeld für direkte Abzüge (Bsp. Einkommen <-> EFB)
    BetragBrutto                 money NOT NULL DEFAULT($0.00),
    BetragBruttoAbzug            money NOT NULL DEFAULT($0.00),
    BgKostenartID                int NULL,        -- des "Verursachers"
    Buchungstext                 varchar(200) COLLATE DATABASE_DEFAULT NULL,
    BgKategorieCode              int,
    BgKostenartID_VerrechnungAus int
  )

  DECLARE @LoopCount int
  SET @LoopCount = 0
  -- Einkommen nicht vom Sozialdienst verwaltet (bewirken, dass weniger ausbezahlt wird, da der Klient das Geld direkt erhält)
  INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext, BgKategorieCode, BgKostenartID_VerrechnungAus)
    SELECT BUC.BgPositionID, BUC.BaPersonID_Teil, -BUC.BetragBrutto, BUC.BgKostenartID, BUC.Name, BUC.BgKategorieCode, SPZ.BgKostenartID
    FROM #Buchungen            BUC
      LEFT JOIN BgPositionsart BPA ON BPA.BgPositionsartID = BUC.BgPositionsartID
      LEFT JOIN BgSpezkonto    SPZ ON SPZ.BgSpezkontoID    = BUC.BgSpezkontoID
    WHERE BUC.Einnahme = 1 /*Einnahmen*/ AND BUC.VerwaltungSD = 0 AND BUC.BgKategorieCode IN (1, 3) /* Einnahmen, Verrechnung */

/*
SELECT 'Vor Abzug', * FROM #Buchungen
SELECT 'Vor Abzug', * FROM @Abzuege
*/
  WHILE 1 = 1 BEGIN
    SET @LoopCount = @LoopCount + 1

    -- Für nicht gequotete Einnahmen wird hier noch gequotet
    INSERT INTO @Abzuege
      SELECT ABZ.BgPositionID, ABZ.BgPositionID_Abzug, ABZ.BgPositionID_Gesperrt, PVR.BaPersonID,
        ABZ.BetragNetto  * PVR.PersonFactor, $0.00,
        ABZ.BetragBrutto * PVR.PersonFactor, $0.00,
        ABZ.BgKostenartID, ABZ.Buchungstext, ABZ.BgKategorieCode, ABZ.BgKostenartID_VerrechnungAus
      FROM @Abzuege  ABZ
        INNER JOIN @PersonVerrechnung  PVR ON 1=1 -- auf alle Personen quoten
      WHERE ABZ.BaPersonID IS NULL

    -- nicht gequotete Einträge löschen
    DELETE FROM @Abzuege WHERE BaPersonID IS NULL

    -- Spezialfall: Sanktion abziehen
    UPDATE ABZ
      SET BgPositionID_Abzug = BUC.BgPositionID
    FROM @Abzuege           ABZ
      INNER JOIN #Buchungen BUC ON BUC.BgKostenartID = ABZ.BgKostenartID AND BUC.BaPersonID_Teil = ABZ.BaPersonID AND BUC.BgKategorieCode IN (2,100) /*Ausgaben, Zusätzliche Leistungen*/
    WHERE ABZ.BgKategorieCode = 4 AND BgPositionID_Abzug IS NULL

    -- Verrechnungen wenn möglich von Positionen abziehen mit LA = Kostenart der Verrechnung
    UPDATE ABZ
      SET BgPositionID_Abzug = BUC.BgPositionID
    FROM @Abzuege            ABZ
      INNER JOIN #Buchungen  BUC ON BUC.BgKostenartID = ABZ.BgKostenartID_VerrechnungAus AND 
                                    BUC.BaPersonID_Teil = ABZ.BaPersonID AND 
                                    BUC.BgKategorieCode = 2 /*Ausgaben*/
    WHERE ABZ.BgKategorieCode = 3

    -- Bei direkt verrechenbaren Abzügen bleibt die PositionsID gleich
    UPDATE @Abzuege
      SET BgPositionID_Abzug = BgPositionID
    WHERE BgPositionID_Abzug IS NULL AND BgPositionID_Gesperrt <> BgPositionID

    -- Abzüge direkte
    UPDATE ABZ
      SET BetragNettoAbzug  = CASE
                                WHEN TMP.Dritte = 1               THEN $0.00  -- Auszahlungen an Dritte
                                WHEN TMP.BgKategorieCode <> 2     THEN $0.00  -- Nur bei Auszahlung Direkter Abzug
                                WHEN GRP.SumBetragNetto = $0.00   THEN $0.00
                                ELSE CONVERT(money, dbo.fnMIN(ABS(GRP.SumBetragNetto), ABS(TMP.BetragNetto))) * ABZ.BetragNetto / GRP.SumBetragNetto
                              END,
          BetragBruttoAbzug = CASE
                                WHEN GRP.SumBetragBrutto = $0.00 OR ABZ.BgKategorieCode <> 101 THEN $0.00 -- Nur bei EZ vom GBL muss die Bruttoseite verrechnet werden
                                ELSE CONVERT(money, dbo.fnMIN(ABS(GRP.SumBetragBrutto), ABS(TMP.BetragBrutto))) * ABZ.BetragBrutto / GRP.SumBetragBrutto
                              END
    FROM @Abzuege            ABZ
      INNER JOIN #Buchungen  TMP ON TMP.BgPositionID = ABZ.BgPositionID_Abzug AND TMP.BaPersonID_Teil = ABZ.BaPersonID
      INNER JOIN (SELECT BgPositionID_Abzug, BaPersonID,
                    SumBetragNetto = SUM(ISNULL(BetragNetto, $0.00)),
                    SumBetragBrutto = SUM(ISNULL(BetragBrutto, $0.00))
                  FROM @Abzuege
                  GROUP BY BgPositionID_Abzug, BaPersonID
                 )           GRP ON GRP.BgPositionID_Abzug = ABZ.BgPositionID_Abzug AND GRP.BaPersonID = ABZ.BaPersonID
    WHERE TMP.Einnahme = 0 AND (GRP.SumBetragNetto > $0.00 OR GRP.SumBetragBrutto > $0.00 OR ABZ.BgKategoriecode = 4)

    -- Abzugsursache abziehen (Bsp EFB) -> netto
    UPDATE TMP
      SET BetragNetto  = TMP.BetragNetto - CASE WHEN TMP.Dritte = 0 AND TMP.Einnahme = 0 THEN ABZ.SumBetragNettoAbzug ELSE $0.00 END,
          BetragBrutto = TMP.BetragBrutto - ABZ.SumBetragBruttoAbzug
    FROM #Buchungen  TMP
      INNER JOIN (SELECT BgPositionID_Abzug, BaPersonID,
                    SumBetragNettoAbzug = SUM(ISNULL(BetragNettoAbzug, $0.00)),
                    SumBetragBruttoAbzug = SUM(ISNULL(BetragBruttoAbzug, $0.00))
                  FROM @Abzuege
                  --WHERE BgPositionID_Abzug = BgPositionID
                  GROUP BY BgPositionID_Abzug, BaPersonID
                 )   ABZ ON ABZ.BgPositionID_Abzug = TMP.BgPositionID AND ABZ.BaPersonID = TMP.BaPersonID_Teil
    WHERE TMP.BuchungenID < @BuchungenID

/*
    -- Erstellen der Sollbuchungen für Direktabzüge
    INSERT INTO #Buchungen (BgPositionID, BgKostenartID, Name, BaPersonID_Teil, BetragBrutto, BetragNetto, KbBuchungStatusCode, Hauptvorgang, Teilvorgang)
      SELECT ABZ.BgPositionID, ABZ.BgKostenartID, ABZ.Buchungstext + ' (direkt)', ABZ.BaPersonID,
        $0.00, ABZ.BetragNettoAbzug, TMP.KbBuchungStatusCode, TMP.Hauptvorgang, TMP.Teilvorgang
      FROM #Buchungen          TMP
        INNER JOIN @Abzuege    ABZ ON ABZ.BgPositionID_Abzug = TMP.BgPositionID AND ABZ.BaPersonID = TMP.BaPersonID_Teil
        INNER JOIN #Buchungen  HAB ON HAB.BgPositionID = ABZ.BgPositionID AND HAB.BaPersonID_Teil = ABZ.BaPersonID AND HAB.Einnahme = 0
      WHERE TMP.BuchungenID < @BuchungenID AND TMP.Dritte = 0 AND TMP.Einnahme = 0 AND ABZ.BetragNettoAbzug > $0.00
        AND ABZ.BgPositionID_Abzug <> ABZ.BgPositionID
*/

    -- Abzugsopfer abziehen (Bsp Einkommen) -> netto
    UPDATE TMP
      SET BetragNetto  = TMP.BetragNetto  + ABZ.SumBetragNettoAbzug,
          BetragBrutto = TMP.BetragBrutto + ABZ.SumBetragBruttoAbzug
    FROM #Buchungen  TMP
      INNER JOIN (SELECT BgPositionID, BaPersonID,
                    SumBetragNettoAbzug = SUM(ISNULL(BetragNettoAbzug, $0.00)),
                    SumBetragBruttoAbzug = SUM(ISNULL(BetragBruttoAbzug, $0.00))
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
        BetragNetto  = BetragNetto  - BetragNettoAbzug,  BetragNettoAbzug  = $0.00,
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
          AND TMP.BgPositionsartID <> 32020 AND BPA.BgKategorieCode NOT IN (100,101) /* Keine Einzelzahlungen */
          AND BPA.BgGruppeCode NOT IN (39030, 39035) /* EFB */

        INSERT INTO @Abzuege
          SELECT ABZ.BgPositionID, TMP.BgPositionID, TMP.BaPersonID_Teil, ABZ.BetragNetto * TMP.BetragNetto / SBG.SumBetrag, $0.00, $0.00, $0.00, ABZ.BgKostenartID, ABZ.Buchungstext
          FROM #Ausgaben        TMP
            INNER JOIN @Abzuege ABZ ON ABZ.BaPersonID = TMP.BaPersonID_Teil AND ABZ.Betrag > $0.00
            INNER JOIN (SELECT BaPersonID_Teil, SUM(ISNULL(BetragNetto, $0.00)) AS SumBetrag
                        FROM #Ausgaben
                        GROUP BY BaPersonID_Teil) SBG ON SBG.BaPersonID_Teil = TMP.BaPersonID_Teil

        DROP TABLE #Ausgaben

        UPDATE @Abzuege SET BetragNetto = $0.00 WHERE BgPositionID_Abzug IS NULL
      END --LineareEinkommensverteilung

      -- Einzelzahlungen von Grundbedarf
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BetragBrutto, BgKostenartID, Buchungstext, BgKategorieCode, BgPositionID_Gesperrt, BgPositionID_Abzug)
        SELECT BPO.BgPositionID, SPP.BaPersonID,
               BetragNetto  = CONVERT(money, BPO.BetragBudget * CASE WHEN BKA.Quoting = 1 OR BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
               BetragBrutto = CONVERT(money, BPO.BetragBudget * CASE WHEN BKA.Quoting = 1 OR BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
               @BgKostenartIDGBL, BPO.Buchungstext + ' (finanziert vom GBL)', 101, BPO.BgPositionID, @BgPositionIDGBL
        FROM #vwBgPosition              BPO
          INNER JOIN BgKostenart        BKA ON BKA.BgKostenartID = @BgKostenartIDGBL
          INNER JOIN @PersonVerrechnung SPP ON (BKA.Quoting = 1 OR                 /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                                SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                                BPO.BaPersonID IS NULL)            /* kein Quoting, aber BaPersonID nicht definiert*/
        WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgSpezkontoID IS NULL AND BPO.BgKategorieCode = 101 /* Einzelzahlung aus Grundbedarf */

      -- Kürzungen / Spezialkonto
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BetragBrutto, BgKostenartID, Buchungstext, BgKategorieCode)
        SELECT BPO.BgPositionID, SPP.BaPersonID, 
          BetragNetto  = CONVERT(money, BPO.BetragBudget * CASE WHEN BPO.BaPersonID IS NULL OR BKA.Quoting = 1 THEN SPP.PersonFactor ELSE 1.0 END),
          BetragBrutto = CONVERT(money, BPO.BetragBudget * CASE WHEN BPO.BaPersonID IS NULL OR BKA.Quoting = 1 THEN SPP.PersonFactor ELSE 1.0 END),
          BKA.BgKostenartID, IsNull(BSK.NameSpezkonto, BPO.Buchungstext) + IsNull( ' (' + LOV.Text + ')', ''), BPO.BgKategorieCode
        FROM #vwBgPosition                   BPO
          LEFT OUTER JOIN dbo.BgSpezkonto    BSK WITH (READUNCOMMITTED) ON BSK.BgSpezkontoID = BPO.BgSpezkontoID
          LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = IsNull(BSK.BgPositionsartID, BPO.BgPositionsartID)
          LEFT OUTER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = COALESCE(BSK.BgKostenartID, BPA.BgKostenartID, @BgKostenartIDGBL)
          LEFT OUTER JOIN dbo.XLOVCode       LOV WITH (READUNCOMMITTED) ON LOV.LOVName = 'BgKategorie' AND LOV.Code = BPO.BgKategorieCode
         INNER JOIN @PersonVerrechnung  SPP ON (BKA.Quoting = 1 OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                                SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                                BPO.BaPersonID IS NULL)            /* normales Quoting */
        WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (4, 6) /* 3:Abzahlung, 4:Kürzung, 6:Vorabzug */

      -- Nicht übernommene Ausgaben 
      -- Bsp Miete 1300.- (wird dem Vermieter ausbezahlt), SD übernimmt aber nur 1000.- -> 300.- müssen sonstwo abgezogen werden werden
      INSERT INTO @Abzuege (BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext, BgKategorieCode)
        SELECT BPO.BgPositionID, BPO.BaPersonID, BPO.BetragRechnung - BPO.BetragBudget, BPA.BgKostenartID, BPA.Name + ' (nicht vom SD übernommen)', BPO.BgKategorieCode
        FROM #vwBgPosition  BPO
          INNER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPO.BgPositionsartID = BPA.BgPositionsartID
        WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2 /* Ausgaben */
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
          INNER JOIN WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID AND SPT.BgGruppeCode = 3206  /* Miete */
      END


      -- SKOS2005 - EFB / Zulagen Limite
      -- Falls mehr Zulagen bezahlt werden sollen als die Limite erlaubt, wird die Differenz ebenfalls abgezogen
      DECLARE @SumZulage money, @Limit money

      SELECT @SumZulage = SUM(BPO.BetragBudget)
      FROM #vwBgPosition  BPO
        INNER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
      WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 2
        AND BPA.BgGruppeCode BETWEEN 39000 AND 39999 /* EFB, IZU, MIZ */

      IF @SumZulage > $0.00 BEGIN
        SELECT TOP 1 @Limit = CONVERT(money, CFG.ValueVar)
        FROM dbo.fnXConfigChild('System\Sozialhilfe\SKOS2005\Abzug_Limit\', @RefDate)  CFG
        WHERE CONVERT(int, CFG.Child) <= (SELECT UeGrundbedarf FROM dbo.fnWhKennzahlen(@BgFinanzplanID) KNZ)
        ORDER BY CFG.Child DESC

        IF @SumZulage > @Limit BEGIN
          SET @msg = 'Es wird zu viel ab den LAs EFB, IZU und MIZ ausbezahlt, nämlich ' + cast(@SumZulage as varchar) + '. Erlaubt sind ' + cast(@Limit as varchar)
          RAISERROR ( @msg, 18, 1)
          RETURN -1
        END
      END
    END ELSE
      BREAK
  END

/*
SELECT 'Ende Abzug Direkt, @Abzuege', * FROM @Abzuege
SELECT 'Ende Abzug Direkt, #Buchungen', * FROM #Buchungen
*/

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
    SET @msg = 'Die negativen gequoteten Einkommen können nicht einer entsprechenden GBL-Position zugeordnet werden'
    RAISERROR(@msg, 18, 1)
    RETURN -1
  END

  -- GBL erhöhen
  UPDATE BUC
  SET BUC.BetragNetto = BUC.BetragNetto - ABZ.BetragNetto
  FROM #Buchungen       BUC
    INNER JOIN (SELECT BaPersonID, BetragNetto = SUM(ISNULL(BetragNetto, $0.00)) 
                FROM @Abzuege
                WHERE BgKategorieCode = 1 AND BetragNetto < $0.00 
                GROUP BY BaPersonID ) ABZ ON BUC.BgPositionID = @BgPositionIDGBL AND BUC.BaPersonID_Teil = ABZ.BaPersonID
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

  -- Abzüge von GB

/*
SELECT '#Buchungen', *FROM #Buchungen
SELECT '@Abzuege', *FROM @Abzuege

    SELECT 'cAbzugNetto', BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE ABS(BetragNetto) > $0.00
    ORDER BY BetragNetto
*/

  /************************************************************************************************
   * Abzüge vornehmen
   * - cAbzugNetto iteriert durch alle Netto-Abzüge, die noch ausstehend sind
   * - cBuchung iteriert über Kandidaten, von denen abgezogen werden kann
   ************************************************************************************************/
  SET @LoopCount = 0

  DECLARE @AktuellerAbzugBetrag             MONEY, 
          @AktuellerAbzugFaktor             double precision,  -- wenn ein Abzug auf eine Gruppe von Buchungen aufgeteilt wird, enstpricht dieser 1/[Anzahl Buchungen]

          @BuchungBaPersonID                INT,
          @BuchungBgKostenartID             INT,
          @BuchungBgPositionsartID          INT,

          @BuchungBgPositionID              INT,
          @BuchungBetrag                    MONEY,
          @BuchungenHabenIdentischeBetraege BIT,
          @AnzahlBuchungen                  INT,

          @AbzugBgPositionID                INT,
          @AbzugBaPersonID                  INT,
          @AbzugBetrag                      MONEY,
          @AbzugBgKostenartID               INT,
          @AbzugBuchungstext                VARCHAR(200)


  DECLARE cAbzugNetto CURSOR FOR
    SELECT BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext
    FROM @Abzuege
    WHERE BetragNetto > $0.00
--  FOR UPDATE OF BetragNetto
/*
SELECT 'cAbzugNetto', BgPositionID, BaPersonID, BetragNetto, BgKostenartID, Buchungstext
FROM @Abzuege
WHERE BetragNetto > $0.00
*/
  WHILE @LoopCount < 3 BEGIN

    -- Wenn es keine Abzüge mehr vorzunehmen gibt können wir aufhören
    SELECT @Count = COUNT(*)
    FROM @Abzuege
    WHERE BetragNetto > $0.00
    IF @Count = 0 BREAK

    SET @LoopCount = @LoopCount + 1
-- Reihenfolgen: 1(Person & Kostenart), 2(Person), 3(Finanzplan)
/*
      SELECT 'cBuchung', '@LoopCount' = @LoopCount,
        'BaPersonID' = CASE WHEN @LoopCount <= 2 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgPositionID, COUNT(*),
        SUM(TMP.BetragNetto),  CASE WHEN MIN(TMP.BetragNetto)  = MAX(TMP.BetragNetto)  THEN 1 ELSE 0 END
      FROM #Buchungen  TMP
        LEFT OUTER JOIN dbo.WhPositionsart   SPT ON SPT.BgPositionsartID = TMP.BgPositionsartID
        LEFT OUTER JOIN dbo.XLOVCode         XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgGruppe' AND XLC.Code = SPT.BgGruppeCode
      WHERE TMP.Dritte = 0                                 -- Zahlungen an Dritte werden ignoriert
        AND (@LoopCount IN (2, 3) OR TMP.BgKategorieCode NOT IN (100, 101))   -- EZ/ZL nur bei den ersten Loops ignorieren
      GROUP BY CASE WHEN @LoopCount <= 2 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgKategorieCode, TMP.BgPositionID
      ORDER BY CASE WHEN TMP.BgKategorieCode IN (100, 101) THEN TMP.BgKategorieCode ELSE 1 END   -- Einzelzahlungen zuletzt kürzen
         , MIN(CASE WHEN SPT.BgGruppeCode = 3202 THEN 9999 ELSE 0 END)                           -- KVG / VVG als letzte BgPosition kürzen
         , MIN(CASE WHEN SPT.BgGruppeCode BETWEEN 3900 AND 3999 THEN SPT.SortKey ELSE 9999 END)  -- SKOS2005 Zulagen
         , MIN(IsNull(XLC.SortKey, 9999)), MIN(SPT.SortKey) DESC
         , CASE WHEN @LoopCount <= 2 THEN TMP.BaPersonID_Teil ELSE NULL END
*/
    DECLARE cBuchung CURSOR FAST_FORWARD FOR
      SELECT CASE WHEN @LoopCount <= 2 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgPositionID, COUNT(*),
        SUM(TMP.BetragNetto),  CASE WHEN MIN(TMP.BetragNetto)  = MAX(TMP.BetragNetto)  THEN 1 ELSE 0 END
      FROM #Buchungen  TMP
        LEFT OUTER JOIN dbo.WhPositionsart   SPT ON SPT.BgPositionsartID = TMP.BgPositionsartID
        LEFT OUTER JOIN dbo.XLOVCode         XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgGruppe' AND XLC.Code = SPT.BgGruppeCode
      WHERE TMP.Dritte = 0                                 -- Zahlungen an Dritte werden ignoriert
        AND (@LoopCount IN (2, 3) OR TMP.BgKategorieCode NOT IN (100, 101))   -- EZ/ZL nur bei den ersten Loops ignorieren
      GROUP BY CASE WHEN @LoopCount <= 2 THEN TMP.BaPersonID_Teil ELSE NULL END, TMP.BgKostenartID, TMP.BgPositionsartID, TMP.BgKategorieCode, TMP.BgPositionID
      ORDER BY CASE WHEN TMP.BgKategorieCode IN (100, 101) THEN TMP.BgKategorieCode ELSE 1 END    -- Einzelzahlungen zuletzt kürzen
         , MIN(CASE WHEN SPT.BgGruppeCode = 3202 THEN 9999 ELSE 0 END)                            -- KVG / VVG als letzte BgPosition kürzen
         --, MIN(CASE WHEN SPT.BgGruppeCode BETWEEN 39000 AND 39999 THEN SPT.SortKey ELSE 9999 END)  -- SKOS2005 Zulagen, #8492: SKOS-Zulagen werden erst nach GBL gekürzt
         , MIN(IsNull(XLC.SortKey, 9999)), MIN(IsNull(SPT.SortKey, 0)) DESC
         , CASE WHEN @LoopCount <= 2 THEN TMP.BaPersonID_Teil ELSE NULL END

    OPEN cBuchung
    OPEN cAbzugNetto
    SELECT @AbzugBetrag = $0.00, @BuchungBetrag = $0.00, @AktuellerAbzugFaktor = 1

--SELECT 'LoopCount' = @LoopCount
    WHILE 1 = 1 BEGIN
--SELECT 'WHILE cBuchung'
      IF ABS(@BuchungBetrag)  <= $0.01
      BEGIN
        FETCH NEXT FROM cBuchung INTO @BuchungBaPersonID, @BuchungBgKostenartID, @BuchungBgPositionsartID, @BuchungBgPositionID, @AnzahlBuchungen,
          @BuchungBetrag, @BuchungenHabenIdentischeBetraege
        IF @@FETCH_STATUS < 0 BREAK
--SELECT 'FETCH cBuchung', BuchungBaPersonID=@BuchungBaPersonID, BuchungBgKostenartID=@BuchungBgKostenartID,
--       BuchungBgPositionsartID=@BuchungBgPositionsartID, BuchungBgPositionID=@BuchungBgPositionID, AnzahlBuchungen=@AnzahlBuchungen,
--       BuchungBetrag=@BuchungBetrag, BuchungenHabenIdentischeBetraege=@BuchungenHabenIdentischeBetraege
      END
 
--SELECT AbzugBetrag=@AbzugBetrag
      -- aktueller Abzug verarbeitet?
      -- ja:   nächsten holen
      -- nein: 
      IF (@AbzugBetrag <= $0.00) BEGIN
        CLOSE cAbzugNetto
        OPEN cAbzugNetto

        WHILE 1 = 1 BEGIN
          FETCH NEXT FROM cAbzugNetto INTO @AbzugBgPositionID, @AbzugBaPersonID, @AbzugBetrag, @AbzugBgKostenartID, @AbzugBuchungstext
          IF @@FETCH_STATUS < 0 BREAK
--SELECT 'FETCH cAbzugNetto', AbzugBgPositionID=@AbzugBgPositionID, AbzugBaPersonID=@AbzugBaPersonID, AbzugBetrag=@AbzugBetrag,
--       AbzugBgKostenartID=@AbzugBgKostenartID, AbzugBuchungstext=@AbzugBuchungstext, BuchungBaPersonID=@BuchungBaPersonID, BuchungBetrag=@BuchungBetrag,
--       BuchungenHabenIdentischeBetraege=@BuchungenHabenIdentischeBetraege
          IF (ABS(@AbzugBetrag) > $0.00
             AND (@AbzugBgKostenartID = @BuchungBgKostenartID OR @LoopCount > 1)
             AND (@AbzugBaPersonID    = @BuchungBaPersonID    OR @LoopCount > 2)) BREAK
        END
        IF @@FETCH_STATUS < 0 BEGIN
--select 'CONTINUE cAbzugNetto'
          -- Auf die aktuelle Buchung kann kein Abzug mehr vorgenommen werden, weiter zur nächsten
          SET @AbzugBetrag = 0
          SET @BuchungBetrag = 0
          CONTINUE
        END
      END


      IF @AbzugBetrag <= @BuchungBetrag BEGIN
        SELECT @AktuellerAbzugBetrag = @AbzugBetrag,
               @AktuellerAbzugFaktor = CONVERT(double precision, (@BuchungBetrag - @AbzugBetrag)) / @BuchungBetrag,
               @AbzugBetrag          = $0.00
      END ELSE BEGIN
        SELECT @AktuellerAbzugBetrag = @BuchungBetrag,
               @AktuellerAbzugFaktor = 0,
               @AbzugBetrag          = @AbzugBetrag - @BuchungBetrag
      END

      DECLARE @Buchung TABLE (
        BuchungenID_SOLL   int,
        BuchungenID_HABEN  int,
        BetragNetto        money)

      DELETE FROM @Buchung

/*
SELECT 'INSERT INTO @Buchung', BuchungenID_SOLL=SOL.BuchungenID, BuchungenID_HABEN=HAB.BuchungenID,
       BetragNetto = CASE
                       WHEN @BuchungenHabenIdentischeBetraege = 1 THEN (@AktuellerAbzugBetrag  / @AnzahlBuchungen)
                       ELSE                                            (1 - @AktuellerAbzugFaktor) * SOL.BetragNetto
                     END
FROM #Buchungen         SOL
  LEFT  JOIN #Buchungen HAB ON HAB.BgPositionID = @AbzugBgPositionID AND HAB.BaPersonID_Teil = @AbzugBaPersonID
                           AND HAB.BuchungenID < @BuchungenID AND (SIGN(SOL.BetragNetto) = SIGN(HAB.BetragNetto) OR HAB.VerwaltungSD = 0)
WHERE (IsNull(SOL.BgPositionsartID, 0) = IsNull(@BuchungBgPositionsartID, 0) AND IsNull(SOL.BgPositionID, 0) = IsNull(@BuchungBgPositionID, 0))
   AND SOL.BaPersonID_Teil = IsNull(@BuchungBaPersonID, SOL.BaPersonID_Teil) AND SOL.Dritte = 0
*/
      INSERT INTO @Buchung
        SELECT SOL.BuchungenID, HAB.BuchungenID,
               CASE
                 WHEN @BuchungenHabenIdentischeBetraege  = 1 THEN (@AktuellerAbzugBetrag  / @AnzahlBuchungen) 
                 ELSE                                             (1 - @AktuellerAbzugFaktor) * SOL.BetragNetto
               END
        FROM #Buchungen         SOL
          LEFT  JOIN #Buchungen HAB ON HAB.BgPositionID = @AbzugBgPositionID AND HAB.BaPersonID_Teil = @AbzugBaPersonID
                                   AND HAB.BuchungenID < @BuchungenID AND (SIGN(SOL.BetragNetto) = SIGN(HAB.BetragNetto) OR HAB.VerwaltungSD = 0)
        WHERE (IsNull(SOL.BgPositionsartID, 0) = IsNull(@BuchungBgPositionsartID, 0) AND IsNull(SOL.BgPositionID, 0) = IsNull(@BuchungBgPositionID, 0))
          AND SOL.BaPersonID_Teil = IsNull(@BuchungBaPersonID, SOL.BaPersonID_Teil) AND SOL.Dritte = 0

      DELETE FROM @Buchung WHERE BetragNetto = $0.00

      UPDATE BUC
        SET BetragNetto = BUC.BetragNetto - TMP.BetragNetto
      FROM #Buchungen        BUC
        INNER JOIN (SELECT BuchungenID_SOLL, BetragNetto = SUM(ISNULL(BetragNetto, $0.00))
                    FROM @Buchung B
                    GROUP BY BuchungenID_SOLL) TMP ON TMP.BuchungenID_SOLL = BUC.BuchungenID

      UPDATE BUC
        SET BetragNetto = BUC.BetragNetto - (TMP.BetragNetto  * SIGN(BUC.BetragNetto))
      FROM #Buchungen        BUC
        INNER JOIN (SELECT BuchungenID_HABEN, BetragNetto = SUM(ISNULL(BetragNetto, $0.00))
                    FROM @Buchung B
                    GROUP BY BuchungenID_HABEN) TMP ON TMP.BuchungenID_HABEN = BUC.BuchungenID

      SET @BuchungBetrag = @BuchungBetrag - @AktuellerAbzugBetrag
--SELECT BuchungBetrag=@BuchungBetrag, AktuellerAbzugBetrag=@AktuellerAbzugBetrag
--ToDo: ob das wohl so klappt?
--      SET @BuchungBetrag = $0.00

      UPDATE @Abzuege
      SET BetragNetto = @AbzugBetrag
      WHERE CURRENT OF cAbzugNetto
      SET @AbzugBetrag  = $0.00

--      SELECT '@BuchungBetrag'  = @BuchungBetrag
--print 'buchung, @AbzugGruppeBetrag neu: ' + cast(@AbzugGruppeBetrag as varchar)
    END

    DEALLOCATE cBuchung
    CLOSE cAbzugNetto
  END
  DEALLOCATE cAbzugNetto


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
-- Zwischenzeitlich auskommentieren ----
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


/*
select *
from #Buchungen

select *
from @Abzuege 
select sum(betrag) from @Abzuege
*/


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
    [FaLeistungID] [int] NULL,
    [Einnahme] [bit] NULL
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
  [VerwPeriodeBis] [datetime] NULL,
    [PscdKennzeichen] [varchar](1) NULL
)

  /************************************************************************************************/
  /* Nettobelege verbuchen                                                                        */
  /************************************************************************************************/
  -- GBL auf Ausgabekonto: Betrag bestimmen, in BgPosition schreiben, aus #Buchungen löschen damit es keine Auszahlung gibt
  DECLARE @BgSpezkontoID_GBLAufAusgabekonto MONEY,
          @BetragAusgabekonto               MONEY,
          @BetragGBLAufAusgabekontoGekuerzt MONEY,
          @BgPositionID                     INT

/*
  SELECT [Count] = COUNT(DISTINCT(BgPositionID)), BgPositionID = SUM(DISTINCT(BgPositionID)), BetragAusgabekonto = SUM(BetragNetto)
  FROM #Buchungen
  WHERE BgPositionsartID = @BgPositionsartID_GBL AND GBLAufAusgabeKonto = 1
*/

  DECLARE @BgPositionID_GBLAufAusgabekonto INT, @COUNT_POS_GBLAufAusgabekonto int

  SELECT @COUNT_POS_GBLAufAusgabekonto = COUNT(DISTINCT(BgPositionID)),
         @BgPositionID_GBLAufAusgabekonto = MAX(DISTINCT(BgPositionID)),
         @BetragAusgabekonto = SUM(BetragNetto),
         @BetragGBLAufAusgabekontoGekuerzt = SUM(BetragBrutto) - SUM(BetragNetto)
  FROM #Buchungen
  WHERE BgPositionsartID = @BgPositionsartIDGBL AND GBLAufAusgabeKonto = 1

  IF @COUNT_POS_GBLAufAusgabekonto = 1 BEGIN
/*
    SELECT 'BetragGBLAufAusgabekonto', BetragGBLAufAusgabekonto, *
    FROM BgPosition
    WHERE BgPositionID = @BgPositionID_GBLAufAusgabekonto
*/
    -- BgSpezkontoID ist auf #Buchungen für Ausgabepositionen nicht gesetzt
    SELECT @BgSpezkontoID_GBLAufAusgabekonto = BgSpezkontoID
    FROM #vwBgPosition
    WHERE BgPositionID = @BgPositionID_GBLAufAusgabekonto

    IF @BgSpezkontoID_GBLAufAusgabekonto IS NOT NULL BEGIN    
      -- Prüfen, ob Spezialkonti (falls benützt) genügend Deckung aufweisen
      -- Wird der GBL gekürzt (z.B. durch nicht abgetretene Einnahmen), muss der Saldo grösser sein als die Kürzung, denn fnBgSpezkonto kann diese nicht mit einbeziehen
      SELECT @Count = COUNT(*), @msg = dbo.ConcDistinct('Das ' + XLC.Text + ' "' + SSK.NameSpezkonto + '" weist zuwenig Deckung auf')
      FROM dbo.BgSpezkonto      SSK
        INNER JOIN dbo.XLOVCode XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgSpezkontoTyp' AND XLC.Code = SSK.BgSpezkontoTypCode
      WHERE SSK.BgSpezkontoID = @BgSpezkontoID_GBLAufAusgabekonto
        AND dbo.fnBgSpezkonto(@BgSpezkontoID_GBLAufAusgabekonto, 3, @BgBudgetID, @BgPositionID_IN) - @BetragGBLAufAusgabekontoGekuerzt < 0
        AND EXISTS (SELECT TOP 1 1
                    FROM #vwBgPosition
                    WHERE BgSpezkontoID = @BgSpezkontoID_GBLAufAusgabekonto
                      AND BgKategorieCode = 101) -- Einzelzahlung

      IF (@Count > 0) BEGIN
        RAISERROR (@msg, 18, 1)
        RETURN -1
      END    
    END
    
    -- GBL-Bruttobeleg für Kürzungen (=Differenz zwischen GBL Brutto und dem Anteil GBL, der tatsächlich auf Ausgabekonto landet) erstellen
    -- mit dieser 'Ausgabe' werden Verrechnungen, nA Einnahmen etc bezahlt
    IF ABS(@BetragGBLAufAusgabekontoGekuerzt) > 0.02 BEGIN

      INSERT INTO #Buchungen (BgPositionID, BaPersonID, BaPersonID_Teil, BetragBrutto, BetragNetto, Kostenstelle, BgPositionsartID, [Name], BgKostenartID, Einnahme, BgKategorieCode, KbBuchungStatusCode, GBLAufAusgabeKonto, BgSplittingArtCode, Hauptvorgang, Teilvorgang)
      SELECT DISTINCT @BgPositionID_GBLAufAusgabekonto, CASE WHEN BKA.Quoting = 1 THEN NULL ELSE BPO.BaPersonID END, SPP.BaPersonID,
        BetragBrutto     = CONVERT(money, @BetragGBLAufAusgabekontoGekuerzt * CASE WHEN BKA.Quoting = 1 OR BPO.BaPersonID IS NULL THEN SPP.PersonFactor ELSE 1.0 END),
        BetragNetto      = 0,
        Kostenstelle     = @Kostenstelle,
        BgPositionsartID = BPO.BgPositionsartID,
        IsNull(BPO.Buchungstext, BPA.Name), BPA.BgKostenartID,
        Einnahme             = 1, -- damit kein NEttobeleg erstellt wird
        BgKategorieCode      = BPO.BgKategorieCode,
        KbBuchungStatusCode  = CASE @CreateAllLocked WHEN 1 THEN 7 /*gesperrt*/ ELSE @KbBuchungStatusCode END,
        GBLAufAusgabeKonto   = 0,
        BgSplittingArtCode   = BKA.BgSplittingArtCode,
        Hauptvorgang         = IsNull(BPA.SpezHauptvorgang, BKA.Hauptvorgang),
        Teilvorgang          = IsNull(BPA.SpezTeilvorgang,  BKA.Teilvorgang)
      FROM #vwBgPosition                   BPO
        LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON  BPA.BgPositionsartID = BPO.BgPositionsartID
        LEFT OUTER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON  BKA.BgKostenartID    = BPA.BgKostenartID
        INNER JOIN @PersonVerrechnung      SPP ON (BKA.Quoting = 1 OR /* quoten auch wenn BPO.BaPersonID NOT NULL ist */
                                                   SPP.BaPersonID = BPO.BaPersonID OR /* kein Quoting */
                                                   BPO.BaPersonID IS NULL)            /* normales Quoting */
      WHERE BPO.BgPositionID = @BgPositionID_GBLAufAusgabekonto
        AND BPO.BelegVorhanden = 0 /*keine verbuchten Belege*/

    END
  END

  DELETE FROM BUC
  FROM #Buchungen         BUC
    LEFT JOIN dbo.BgAuszahlungPerson       BAP WITH (READUNCOMMITTED) ON BUC.BgPositionID = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
  WHERE GBLAufAusgabeKonto = 1 AND KbAuszahlungsArtCode IS NULL AND BaZahlungswegID IS NULL


  SELECT AuszahlBetrag = SUM(IsNull(CAST(BUC.NettoBetragProTermin AS MONEY),BUC.BetragNetto)), BUC.BgPositionID, BUC.BaPersonID_Teil, 
         BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, Datum = IsNull(BAT.Datum,POS.FaelligAm),
         BUC.TerminFaktor, BAP.KbAuszahlungsArtCode, BAP.BaZahlungswegID, BAP.ReferenzNummer, Zahlungsgrund = NULL,/*BAP.Zahlungsgrund,*/
         BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode,
         MitteilungZeile1 = CASE BAP.KbAuszahlungsArtCode WHEN 103 /*Bar*/ THEN BAP.MitteilungZeile1 END, BAP.MitteilungZeile2,
         BAP.MitteilungZeile3, BAP.MitteilungZeile4, Abgetreten = BUC.VerwaltungSD, Hauptvorgang, Teilvorgang,
         PscdKennzeichen = CASE WHEN BUC.VerwaltungSD = 0 AND BUC.BgKategorieCode = 1 THEN 'N' ELSE XLC.Value3 END
    INTO #NettoAuszahlungen
    FROM #Buchungen                                BUC
      LEFT OUTER JOIN #vwBgPosition                POS ON POS.BgPositionID = BUC.BgPositionID
      LEFT OUTER JOIN dbo.BgAuszahlungPerson       BAP WITH (READUNCOMMITTED) ON BUC.BgPositionID = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
      LEFT OUTER JOIN dbo.BgAuszahlungPersonTermin BAT WITH (READUNCOMMITTED) ON BAP.BgAuszahlungPersonID = BAT.BgAuszahlungPersonID
      LEFT OUTER JOIN dbo.XLOVCode                 XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgKategorie' AND XLC.Code = BUC.BgKategorieCode
    GROUP BY BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, BAP.BaZahlungswegID, IsNull(BAT.Datum,POS.FaelligAm), BAP.KbAuszahlungsArtCode, BUC.TerminFaktor, BAP.ReferenzNummer, /*BAP.Zahlungsgrund,*/ BUC.VerwaltungSD, BUC.Dritte, BUC.BgKategorieCode, BUC.KbBuchungStatusCode, BUC.AuszahlGruppeID, CASE BAP.KbAuszahlungsArtCode WHEN 103 /*Bar*/ THEN BAP.MitteilungZeile1 END,BAP.MitteilungZeile2, BAP.MitteilungZeile3, BAP.MitteilungZeile4, BUC.VerwaltungSD, Hauptvorgang, Teilvorgang, CASE WHEN BUC.VerwaltungSD = 0 AND BUC.BgKategorieCode = 1 THEN 'N' ELSE XLC.Value3 END
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
  --INSERT INTO @ZahlungswegeCheck
  --  SELECT DISTINCT ZAL.BaZahlungswegID
  --  FROM #NettoAuszahlungen    AUZ
  --    INNER JOIN dbo.BaZahlungsweg ZA1 WITH (READUNCOMMITTED) ON ZA1.BaZahlungswegID = AUZ.BaZahlungswegID
  --    INNER JOIN dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED) ON ZAL.BaPersonID      = ZA1.BaPersonID OR ZAL.BaInstitutionID = ZA1.BaInstitutionID
  --  WHERE ZAL.BaZahlungswegID IS NOT NULL


  INSERT INTO @ZahlungswegeCheck
    SELECT --DISTINCT 
    IsNull(ZAP.BaZahlungswegID, ZAI.BaZahlungswegID)
    FROM #NettoAuszahlungen    AUZ
      INNER JOIN dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID = AUZ.BaZahlungswegID
      left outer JOIN dbo.BaZahlungsweg ZAP WITH (READUNCOMMITTED) ON ZAP.BaPersonID      = ZAL.BaPersonID 
      left outer JOIN dbo.BaZahlungsweg ZAI WITH (READUNCOMMITTED) ON ZAI.BaInstitutionID = ZAL.BaInstitutionID
    --WHERE ZAL.BaZahlungswegID IS NOT NULL

  -- Zahlungswege der Debitoren
  INSERT INTO @ZahlungswegeCheck
    SELECT --DISTINCT 
    IsNull(ZAP.BaZahlungswegID, ZAI.BaZahlungswegID)
    FROM #Buchungen            BUC
      INNER JOIN dbo.BgPosition    POS WITH (READUNCOMMITTED) ON POS.BgPositionID = BUC.BgPositionID
      LEFT OUTER JOIN dbo.BaZahlungsweg ZAP WITH (READUNCOMMITTED) ON ZAP.BaPersonID   = POS.DebitorBaPersonID
      LEFT OUTER JOIN dbo.BaZahlungsweg ZAI WITH (READUNCOMMITTED) ON ZAI.BaInstitutionID = POS.BaInstitutionID
    --WHERE ZAL.BaZahlungswegID IS NOT NULL

  -- Alle Zahlungswege der Finanzplan-Personen
  INSERT INTO @ZahlungswegeCheck
    SELECT --DISTINCT 
    ZAL.BaZahlungswegID
    FROM dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) 
      INNER JOIN dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED) ON ZAL.BaPersonID = FPP.BaPersonID
    WHERE FPP.BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1 --AND BaZahlungswegID IS NOT NULL
  
  SELECT @COUNT = COUNT(*), @msg = dbo.ConcDistinct(IsNull(Kreditor + ', ' + Zusatzinfo + ', ' + Zahlungsweg + char(13) + char(10) + char(13) + char(10),''))
  FROM @ZahlungswegeCheck    TMP
    INNER JOIN dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID = TMP.BaZahlungswegID
    LEFT  JOIN dbo.vwKreditor    KRE ON KRE.BaZahlungswegID = TMP.BaZahlungswegID
  WHERE  ZAL.IBANNummer IS NULL AND ZAL.EinzahlungsscheinCode IN (2,3,5)

  IF @COUNT > 0 BEGIN
    SET @msg = REPLACE('Nicht alle Zahlungswege haben eine IBAN. Die IBAN ist zwingend, um Auszahlungen zu machen. Tragen sie bitte die IBAN in den Basisdaten bzw im Institutionenstamm ein. Betroffene Stammdaten:' + char(13) + char(10) + char(13) + char(10) + @msg, char(13) + char(10) + ',', char(13) + char(10))
    RAISERROR ( @msg, 18, 1)
    RETURN -1
  END


  -- WMAs
  DECLARE @WMACheck TABLE (BaAdresseID int primary key, BaPersonID int, BaInstitutionID int, DatumVon datetime, DatumBis datetime)

   --Adressen der anzulegenden Personen/Institutionen
  
  INSERT INTO @WMACheck
    SELECT DISTINCT ADR.BaAdresseID, ADR.BaPersonID, ADR.BaInstitutionID, ADR.DatumVon, ADR.DatumBis
    FROM #NettoAuszahlungen    AUZ
      INNER JOIN dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID = AUZ.BaZahlungswegID
      INNER JOIN dbo.BaAdresse     ADR WITH (READUNCOMMITTED) ON ADR.BaPersonID = ZAL.BaPersonID  AND ADR.AdresseCode = 1
   INSERT INTO @WMACheck
    SELECT DISTINCT ADR.BaAdresseID, ADR.BaPersonID, ADR.BaInstitutionID, ADR.DatumVon, ADR.DatumBis
    FROM #NettoAuszahlungen    AUZ
      INNER JOIN dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID = AUZ.BaZahlungswegID
      INNER JOIN dbo.BaAdresse     ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = ZAL.BaInstitutionID AND ADR.AdresseCode = 1

 
  -- Adressen der Debitoren
  INSERT INTO @WMACheck
    SELECT DISTINCT ADR.BaAdresseID, ADR.BaPersonID, ADR.BaInstitutionID, ADR.DatumVon, ADR.DatumBis
    FROM #Buchungen            BUC
      INNER JOIN dbo.BgPosition    POS WITH (READUNCOMMITTED) ON POS.BgPositionID = BUC.BgPositionID
      LEFT OUTER JOIN dbo.BaAdresse    ADR WITH (READUNCOMMITTED) ON ADR.BaPersonID   = POS.DebitorBaPersonID
    WHERE POS.DebitorBaPersonID IS NOT NULL AND AdresseCode = 1 /*WMA*/
      AND (BaAdresseID IS NULL OR BaAdresseID NOT IN (SELECT BaAdresseID FROM @WMACheck WHERE BaAdresseID IS NOT NULL))
  INSERT INTO @WMACheck
    SELECT DISTINCT ADR.BaAdresseID, ADR.BaPersonID, ADR.BaInstitutionID, ADR.DatumVon, ADR.DatumBis
    FROM #Buchungen            BUC
      INNER JOIN dbo.BgPosition    POS WITH (READUNCOMMITTED) ON POS.BgPositionID = BUC.BgPositionID
      LEFT OUTER JOIN dbo.BaAdresse    ADR WITH (READUNCOMMITTED) ON ADR.BaInstitutionID = POS.BaInstitutionID
    WHERE POS.BaInstitutionID IS NOT NULL AND AdresseCode = 1 /*WMA*/
      AND (BaAdresseID IS NULL OR BaAdresseID NOT IN (SELECT BaAdresseID FROM @WMACheck WHERE BaAdresseID IS NOT NULL))

  -- Alle Adressen der Finanzplan-Personen
  INSERT INTO @WMACheck
    SELECT DISTINCT ADR.BaAdresseID, FPP.BaPersonID, NULL, ADR.DatumVon, ADR.DatumBis
    FROM dbo.BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) 
      LEFT  JOIN dbo.BaAdresse     ADR WITH (READUNCOMMITTED) ON ADR.BaPersonID = FPP.BaPersonID
    WHERE FPP.BgFinanzplanID = @BgFinanzplanID AND IstUnterstuetzt = 1 AND AdresseCode = 1 /*WMA*/
      AND (BaAdresseID IS NULL OR BaAdresseID NOT IN (SELECT BaAdresseID FROM @WMACheck WHERE BaAdresseID IS NOT NULL))

  DELETE FROM @WMACheck
  WHERE GETDATE() NOT BETWEEN DatumVon AND IsNull(DatumBis,dbo.fnDateSerial(9999,12,31))

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
    INNER JOIN dbo.BaZahlungsweg ZAL WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID = AUZ.BaZahlungswegID
  WHERE  Datum NOT BETWEEN DatumVon AND DatumBis

  IF @COUNT > 0 BEGIN
    SET @msg = 'Ein Valutadatum liegt ausserhalb des Gültigkeitszeitraums des Zahlungswegs. Überprüfen Sie bitte die Gültigkeit der verwendeten Zahlungswege im Modul B oder im Institutionenstamm (jeweils Register Zahlinfo).'
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

  DECLARE cNettoBeleg CURSOR FOR
    SELECT Einnahme, Datum, FLOOR((SUM(AuszahlBetrag)) * 20.0 + 0.5) / 20.0,
           BaZahlungswegID, KbAuszahlungsArtCode, Zahlungsgrund, ReferenzNummer, KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, LEFT(MitteilungZeile1,35), LEFT(MitteilungZeile2,35), LEFT(MitteilungZeile3,35), LEFT(MitteilungZeile4,35)
    FROM #NettoAuszahlungen     AUZ
      LEFT OUTER JOIN #vwBgPosition   BPO ON BPO.BgPositionID     = AUZ.BgPositionID
     -- LEFT OUTER JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
    --WHERE  AUZ.Einnahme = 0
    GROUP BY Datum, AUZ.BaZahlungswegID, AUZ.KbAuszahlungsArtCode, Zahlungsgrund, Einnahme, ReferenzNummer, AUZ.KbBuchungStatusCode, CASE Einnahme WHEN 1 THEN BaInstitutionID ELSE NULL END, DebitorBaPersonID, CASE Einnahme WHEN 1 THEN AUZ.BgPositionID ELSE NULL END, LEFT(MitteilungZeile1,35), LEFT(MitteilungZeile2,35), LEFT(MitteilungZeile3,35), LEFT(MitteilungZeile4,35)

  DECLARE @BaBankID_Post int, @Einnahme int

  SELECT @BaBankID_Post = BaBankID
  FROM   dbo.BaBank WITH (READUNCOMMITTED) 
  WHERE  ClearingNr = '9000' /*Post*/ AND LandCode = 147 /*CH*/

  OPEN cNettoBeleg
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cNettoBeleg INTO @Einnahme, @ValutaDatum, @SumBetrag, @BaZahlungswegID, @KbAuszahlungsArtCode, @Zahlungsgrund, @ReferenzNummer, @KbBuchungStatusCode, @Schuldner_BaInstitutionID, @Schuldner_BaPersonID, @BgPositionID_Einzahlung, @MitteilungZeile1, @MitteilungZeile2, @MitteilungZeile3, @MitteilungZeile4
    IF @@FETCH_STATUS < 0 BREAK

    -- #4644: Hat der Zalungsweg eine Bank mit einer neuen ClearingNr?
    SELECT TOP 1 
      @KreditorMehrZeilig = KRE.KreditorMehrZeilig,  
      @ClearingNr         = BNK.ClearingNr, 
      @ClearingNrNeu      = BNK.ClearingNrNeu
    FROM dbo.vwKreditorInfo KRE
      LEFT  JOIN dbo.BaBank BNK ON BNK.BaBankID = KRE.BaBankID
    WHERE KRE.BaZahlungswegID = @BaZahlungswegID
 
    IF @ClearingNrNeu IS NOT NULL
    BEGIN
      CLOSE cNettoBeleg
      DEALLOCATE cNettoBeleg
      SET @Message = 'Der Zahlungsweg mit der ID %d hat eine Bank (ClearingNr %s) mit einer neuen ClearingNr.' + CHAR(13) + CHAR(10) +
                     'Kreditor:'+ CHAR(13) + CHAR(10) +
                     '%s'
      RAISERROR (@Message, 18, 1, @BaZahlungswegID, @ClearingNr, @KreditorMehrZeilig)
      RETURN -1
    END
    

    -- Buchungskopf
    IF( @Einnahme = 0 ) BEGIN --Ausgabe
      IF( @KbAuszahlungsArtCode <> 103 ) BEGIN
        -- Elektronische Auszahlung
        INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID, SollKtoNr, HabenKtoNr,
                                KbAuszahlungsArtCode, PCKontoNr, BaBankID, BankKontoNr, IBAN, ReferenzNummer, Zahlungsgrund, BeguenstigtName, BeguenstigtName2, BeguenstigtPostfach, BeguenstigtStrasse, BeguenstigtHausNr, BeguenstigtPLZ, BeguenstigtOrt, BeguenstigtLandCode,
                                BgBudgetID, PscdZahlwegArt, ModulID, Kostenstelle, BankName, BankStrasse, BankPLZ, BankOrt, BankBCN, ErstelltUserID, ErstelltDatum, FaLeistungID,
                                MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4, Einnahme)
          SELECT @KbPeriodeID, 1/*Budget*/, GetDate(), @ValutaDatum, @SumBetrag,
               LEFT('an ' + CASE WHEN ZAL.BaZahlungswegID IS NOT NULL THEN ZAL.Name + '; am ' + CONVERT(varchar,@ValutaDatum,104) WHEN @KbAuszahlungsArtCode = 103 THEN 'Barauszahlung' ELSE '' END, 200),
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
               ZAL.BankName, ZAL.BankStrasse, ZAL.BankPLZ, ZAL.BankOrt, ZAL.Bank_BCN, @UserID, GetDate(), @FaLeistungID, MitteilungZeile1 = LEFT('F' + CAST(@FaFallID as varchar) + IsNull(' ' + @Person,''),35), @MitteilungZeile2, @MitteilungZeile3, @MitteilungZeile4, 0
          FROM dbo.vwKreditorInfo        ZAL 
            LEFT OUTER JOIN dbo.XLOVCode      XLA WITH (READUNCOMMITTED) ON XLA.LOVName = 'KbAuszahlungsArt'    AND XLA.Code = @KbAuszahlungsArtCode
          WHERE ZAL.BaZahlungswegID = @BaZahlungswegID
          GROUP BY ZAL.BaZahlungswegID, ZAL.PCKontoNr, ZAL.BaBankID, ZAL.BankKontoNr, ZAL.IBAN, ZAL.BaPersonID, ZAL.BaInstitutionID, ZAL.EinzahlungsscheinCode, ZAL.Name, ZAL.Postfach, ZAL.Strasse, ZAL.HausNr, ZAL.PLZ, ZAL.Ort, ZAL.LandCode, XLA.Value1, ZAL.Auszahlungsart, ZAL.BankName, ZAL.BankStrasse, ZAL.BankPLZ, ZAL.BankOrt, ZAL.Bank_BCN
      END
      ELSE BEGIN
      -- Barauszahlung
      --Mitteilung bestimmen
/*
      DECLARE @MitteilungZeile1tmp varchar(35),
              @MitteilungZeile2tmp varchar(35),
              @MitteilungZeile3tmp varchar(35),
              @MitteilungZeile4tmp varchar(35)

      SELECT TOP 1 @MitteilungZeile1tmp = IsNull(@MitteilungZeile1, MitteilungZeile1),
                   @MitteilungZeile2tmp = MitteilungZeile2,
                   @MitteilungZeile3tmp = MitteilungZeile3,
                   @MitteilungZeile4tmp = MitteilungZeile4
      FROM   #NettoAuszahlungen   AUZ
      WHERE AUZ.Datum = @ValutaDatum AND IsNull(AUZ.BaZahlungswegID,-1) = IsNull(@BaZahlungswegID,-1) AND AUZ.KbAuszahlungsArtCode = @KbAuszahlungsArtCode AND IsNull(AUZ.ReferenzNummer,'') = IsNull(@ReferenzNummer,'')
        AND Einnahme = 0 AND MitteilungZeile1 IS NOT NULL
*/

        INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, ErstelltUserID, BaZahlungswegID, SollKtoNr, HabenKtoNr,
                                KbAuszahlungsArtCode, ReferenzNummer, BgBudgetID, PscdZahlwegArt, ModulID, Kostenstelle, BeguenstigtName, BeguenstigtStrasse, BeguenstigtOrt, FaLeistungID, Einnahme)
        VALUES( @KbPeriodeID, 1/*Budget*/, GetDate(), @ValutaDatum, @SumBetrag, LEFT('Barauszahlung' + IsNull(' an ' + @MitteilungZeile1,''),200), @KbBuchungStatusCode, @UserID, NULL, NULL, @KontoNrKreditor,
               @KbAuszahlungsArtCode, NULL, @BgBudgetID, 'C', 3, @Kostenstelle, @MitteilungZeile1, @MitteilungZeile2, @MitteilungZeile3, @FaLeistungID, 0 )
      END
      SET @KbBuchungID = SCOPE_IDENTITY()

      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart, KontoNr, VerwPeriodeVon, VerwPeriodeBis, PscdKennzeichen)
        SELECT @KbBuchungID, AUZ.BgPositionID, AUZ.BgKostenartID, AUZ.BaPersonID_Teil, AUZ.Name, AuszahlBetrag, NULL,
               IsNull(BPA.SpezHauptvorgang, CASE AUZ.Abgetreten WHEN 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END),
               IsNull(BPA.SpezTeilvorgang,  CASE AUZ.Abgetreten WHEN 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END),
               BKA.Belegart,
               BKA.KontoNr,
               VerwPeriodeVon  = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
               VerwPeriodeBis  = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth)  END,
               PscdKennzeichen = AUZ.PscdKennzeichen
        FROM   #NettoAuszahlungen            AUZ
          INNER JOIN dbo.BgKostenart         BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID    = AUZ.BgKostenartID
          LEFT OUTER JOIN #vwBgPosition      BPO                        ON BPO.BgPositionID     = AUZ.BgPositionID
          LEFT OUTER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
        WHERE AUZ.Datum = @ValutaDatum
          AND IsNull(AUZ.BaZahlungswegID,-1) = IsNull(@BaZahlungswegID,-1)
          AND AUZ.KbAuszahlungsArtCode = @KbAuszahlungsArtCode
          AND IsNull(AUZ.ReferenzNummer,'') = IsNull(@ReferenzNummer,'')
          AND Einnahme = 0
          AND (@KbAuszahlungsArtCode <> 103 OR IsNull(AUZ.MitteilungZeile1,'') = IsNull(@MitteilungZeile1,'')) /*Mitteilungszeile1 nur bei Barauszahlung berücksichtigen */
          AND IsNull(AUZ.MitteilungZeile2,'') = IsNull(@MitteilungZeile2,'')
          AND IsNull(AUZ.MitteilungZeile3,'') = IsNull(@MitteilungZeile3,'')
          AND IsNull(AUZ.MitteilungZeile4,'') = IsNull(@MitteilungZeile4,'')

    END
    ELSE BEGIN -- Einnahme
      IF ABS(@SumBetrag) < $0.01 CONTINUE

      DECLARE @ForderungText varchar(200)
      IF( @Schuldner_BaInstitutionID IS NOT NULL ) BEGIN
        SELECT @ForderungText = Name
        FROM   dbo.BaInstitution WITH (READUNCOMMITTED) 
        WHERE  BaInstitutionID = @Schuldner_BaInstitutionID
      END
      ELSE IF( @Schuldner_BaPersonID IS NOT NULL ) BEGIN
        SELECT @ForderungText = NameVorname
        FROM   dbo.vwPerson
        WHERE  BaPersonID = @Schuldner_BaPersonID
      END

      SET @ForderungText = LEFT(IsNull('von ' + @ForderungText + IsNull('; am ' + CONVERT(varchar,@ValutaDatum,104),''),'Forderung'),200)

      INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID,
                              KbAuszahlungsArtCode, ReferenzNummer, BgBudgetID, PscdZahlwegArt, ModulID, Kostenstelle, SollKtoNr, ErstelltUserID, ErstelltDatum, Schuldner_BaPersonID, Schuldner_BaInstitutionID, FaLeistungID, Einnahme)
      VALUES(@KbPeriodeID, 1/*Budget*/, GetDate(), IsNull(@ValutaDatum,@FirstDayInMonth), -@SumBetrag, @ForderungText, @KbBuchungStatusCode, NULL,
             NULL, NULL, @BgBudgetID, NULL, 3, @Kostenstelle, @KontoNrDebitor, @UserID, GetDate(), @Schuldner_BaPersonID, @Schuldner_BaInstitutionID, @FaLeistungID, 1)

      SET @KbBuchungID = SCOPE_IDENTITY()

      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart, KontoNr, VerwPeriodeVon, VerwPeriodeBis, PscdKennzeichen)
        SELECT @KbBuchungID, AUZ.BgPositionID, AUZ.BgKostenartID, AUZ.BaPersonID_Teil, AUZ.Name, -AuszahlBetrag, NULL,
               IsNull(BPA.SpezHauptvorgang, CASE AUZ.Abgetreten WHEN 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END),
               IsNull(BPA.SpezTeilvorgang,  CASE AUZ.Abgetreten WHEN 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END),
               BKA.Belegart,
               BKA.KontoNr,
               VerwPeriodeVon  = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
               VerwPeriodeBis  = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth)  END,
               PscdKennzeichen = AUZ.PscdKennzeichen
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

  DROP TABLE #NettoAuszahlungen

/*
  -- Leere Belege löschen
--doch nicht löschen, 0er Belege brauchts z.B. zum korrekten Verarbeiten der 0er-Budgets 
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
*/
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
    ORDER BY KbBuchungID, KontoNr

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

  -- 0-er Belege werden nun nach Möglichkeit in einen anderen (nicht 0er-)Beleg mit gleicher Auszahladresse integriert
  DECLARE @KbBuchungID0er int,
          @KbAuszahlungsartCode0er int,
          @BaZahlungswegID0er int,
          @KbBuchungIDZiel int 

  SET @LastKbBuchungID = NULL

  DECLARE cNetto0er CURSOR FOR
    SELECT KbBuchungID, KbAuszahlungsartCode, BaZahlungswegID
    FROM @KbBuchung
    WHERE Betrag = 0.00

  OPEN cNetto0er
  WHILE 1=1 BEGIN
    FETCH NEXT FROM cNetto0er INTO @KbBuchungID0er, @KbAuszahlungsartCode0er, @BaZahlungswegID0er
    IF @@FETCH_STATUS < 0 BREAK

    SET @KbBuchungIDZiel = NULL

    SELECT TOP 1 @KbBuchungIDZiel = KbBuchungID
    FROM @KbBuchung
    WHERE Betrag > 0.00 AND KbAuszahlungsartCode = @KbAuszahlungsartCode0er AND BaZahlungswegID = @BaZahlungswegID0er

    IF @KbBuchungIDZiel IS NOT NULL BEGIN
      UPDATE @KbBuchungKostenart
      SET    KbBuchungID = @KbBuchungIDZiel
      WHERE  KbBuchungID = @KbBuchungID0er
      
      DELETE FROM @KbBuchung
      WHERE KbBuchungID = @KbBuchungID0er
    END
  END
  CLOSE cNetto0er
  DEALLOCATE cNetto0er

  -- Die auf 0.00 gekürzten Nettopositionenen (Einnahmen) müssen in einem Nettobeleg untergebracht werden, damit die entsprechenden Bruttobelege zu einem Nettobeleg zugeordnet werden können
  IF @KissStandard = 0 BEGIN
    DECLARE @KbBuchungIDGBL int

    SELECT TOP 1 @KbBuchungIDGBL = KBU.KbBuchungID
    FROM   @KbBuchung                KBU
      INNER JOIN @KbBuchungKostenart KBK ON KBK.KbBuchungID = KBU.KbBuchungID
    WHERE BgPositionID = @BgPositionIDGBL
    ORDER BY ValutaDatum

    IF @KbBuchungIDGBL IS NULL BEGIN
      -- Möglichkeiten:
      -- * Normales Budget -> Es existiert ein normaler GBL-Beleg
      -- * Ein einzelner Beleg -> Diesen Beleg wählen, kein Dummy-Beleg nötig
      -- * Alles aufs Ausgabekonto ohne Verrechnungen -> keine Belege vorhanden, nichts zu tun
      -- * GBL aufs Ausgabekonto, andere Ausgaben nicht -> andere Ausgabe wählen
      -- * Alles aufs Ausgabekonto mit Verrechnungen -> DummyBeleg einfügen
      SELECT TOP 1 @KbBuchungIDGBL = KbBuchungID
      FROM   @KbBuchung KBU
      WHERE HabenKtoNr = @KontoNrKreditor OR @BgPositionID_IN IS NOT NULL
      ORDER BY ValutaDatum

      SELECT @Count = COUNT(*)
      FROM #Buchungen

      IF @KbBuchungIDGBL IS NULL AND @Count > 0
        AND EXISTS (SELECT BgPositionID FROM #Buchungen WHERE ABS(BetragNetto) < $0.01 AND Einnahme = 1)
      BEGIN
        INSERT INTO @KbBuchung (KbPeriodeID, KbBuchungTypCode, BelegDatum, ValutaDatum, Betrag, [Text], KbBuchungStatusCode, BaZahlungswegID,
                                KbAuszahlungsArtCode, ReferenzNummer, BgBudgetID, PscdZahlwegArt, ModulID, Kostenstelle, HabenKtoNr, ErstelltUserID, ErstelltDatum, Schuldner_BaPersonID, Schuldner_BaInstitutionID, FaLeistungID, Einnahme)
        VALUES(@KbPeriodeID, 1/*Budget*/, GetDate(), @FirstDayInMonth, 0.00, 'Dummy 0er-Beleg', @KbBuchungStatusCode, NULL,
               NULL, NULL, @BgBudgetID, NULL, 3, @Kostenstelle, @KontoNrKreditor, @UserID, GetDate(), NULL, NULL, @FaLeistungID, 1)
        SELECT @KbBuchungIDGBL = SCOPE_IDENTITY()
      END
    END

    IF @KbBuchungIDGBL IS NOT NULL BEGIN
      -- Detailpositionen
      INSERT INTO @KbBuchungKostenart (KbBuchungID, BgPositionID, BgKostenartID, BaPersonID, Buchungstext, Betrag, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart, KontoNr, VerwPeriodeVon, VerwPeriodeBis, PscdKennzeichen)
        SELECT @KbBuchungIDGBL, BUC.BgPositionID, BUC.BgKostenartID, BUC.BaPersonID_Teil, BUC.Name, $0.00, NULL,
               BUC.Hauptvorgang,
               BUC.Teilvorgang,
               BKA.Belegart,
               BKA.KontoNr,
               VerwPeriodeVon  = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeVon, @FirstDayInMonth) END,
               VerwPeriodeBis  = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN @ValutaDatum WHEN 4 /*Entscheid*/ THEN BPO.VerwPeriodeVon ELSE IsNull(BPO.VerwPeriodeBis, @LastDayInMonth)  END,
               PscdKennzeichen = CASE WHEN BUC.VerwaltungSD = 0 AND BUC.BgKategorieCode = 1 THEN 'N' ELSE XLC.Value3 END
        FROM   #Buchungen            BUC
          INNER JOIN dbo.BgKostenart BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = BUC.BgKostenartID
          LEFT  JOIN #vwBgPosition   BPO                        ON BPO.BgPositionID  = BUC.BgPositionID
          LEFT  JOIN dbo.XLOVCode    XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgKategorie' AND XLC.Code = BUC.BgKategorieCode
        WHERE ABS(BetragNetto) < $0.01 AND Einnahme = 1
    END
/*
    SELECT *
    FROM #Buchungen
    WHERE ABS(BetragNetto) < $0.01 AND Einnahme = 1
*/
  END

  /************************************************************************************************/
  /* Maximaler Betrag einer Barauszahlung überprüfen                                              */
  /************************************************************************************************/
  DECLARE @maxBarBetrag money
  SET @maxBarBetrag = CONVERT(money, dbo.fnXConfig('System\Sozialhilfe\MaxBarBezugBetrag', GetDate()))
  IF EXISTS
  (
    SELECT KbBuchungID
    FROM @KbBuchung
    WHERE KbAuszahlungsArtCode = 103 AND Betrag > @maxBarBetrag
  ) BEGIN
    SET @msg = 'Die Erstellung eines Barbeleges ist nicht möglich. Der Maximalbetrag pro Barbeleg beträgt CHF ' + REPLACE(CONVERT(VARCHAR(40),@maxBarBetrag , 1), ',', '''') + '.'
    RAISERROR (@msg, 18, 1)
    RETURN -1
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
    [Abgetreten] [bit] NULL,
    [Einnahme] [bit] NULL,
    [PscdKennzeichen] [varchar](1) NULL
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
  [PositionImBeleg] [int] NULL,
    [GesperrtFuerWV] [bit] NOT NULL DEFAULT(0)
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

  SELECT BetragBrutto = SUM(IsNull(CAST(BruttoBetragProTermin as MONEY),BetragBrutto)), BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.Einnahme, Termin = COALESCE(BAT.Datum, POS.FaelligAm, @FirstDayInMonth), Zahlungsgrund = NULL, /*BAP.Zahlungsgrund, */BUC.VerwaltungSD, BUC.KbBuchungStatusCode, Schuldner_BaInstitutionID = POS.BaInstitutionID, Schuldner_BaPersonID = POS.DebitorBaPersonID, VerwPeriodeVon, VerwPeriodeBis, Abgetreten = BUC.VerwaltungSD, Hauptvorgang, Teilvorgang, PscdKennzeichen = CASE WHEN BUC.VerwaltungSD = 0 AND BUC.BgKategorieCode = 1 THEN 'N' ELSE XLC.Value3 END /*Spezialbehandlung für nicht abgetretene Einnahmen*/
    INTO #BruttoAuszahlungen
    FROM #Buchungen BUC
      LEFT OUTER JOIN #vwBgPosition                POS ON POS.BgPositionID         = BUC.BgPositionID
      LEFT OUTER JOIN dbo.BgAuszahlungPerson       BAP WITH (READUNCOMMITTED) ON BUC.BgPositionID         = BAP.BgPositionID AND BUC.BaPersonID_Teil = IsNull(BAP.BaPersonID, BUC.BaPersonID_Teil)
      LEFT OUTER JOIN dbo.BgAuszahlungPersonTermin BAT WITH (READUNCOMMITTED) ON BAP.BgAuszahlungPersonID = BAT.BgAuszahlungPersonID
      LEFT OUTER JOIN dbo.XLOVCode                 XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'BgKategorie' AND XLC.Code = BUC.BgKategorieCode
    WHERE ABS(BUC.BetragBrutto) > $0.00
    GROUP BY BUC.BgPositionID, BUC.BaPersonID_Teil, BUC.Kostenstelle, BUC.BgPositionsartID, BUC.Name, BUC.BgKostenartID, BUC.AuszahlGruppeID, BUC.Einnahme, COALESCE(BAT.Datum, POS.FaelligAm, @FirstDayInMonth), /*BAP.Zahlungsgrund, */BUC.VerwaltungSD, BUC.KbBuchungStatusCode, POS.BaInstitutionID, POS.DebitorBaPersonID, VerwPeriodeVon, VerwPeriodeBis, BUC.VerwaltungSD, Hauptvorgang, Teilvorgang, CASE WHEN BUC.VerwaltungSD = 0 AND BUC.BgKategorieCode = 1 THEN 'N' ELSE XLC.Value3 END
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
  SELECT '#BruttoAuszahlungen', CAST(BetragBrutto as money), *
  FROM #BruttoAuszahlungen
  --WHERE ABS(CAST(BetragBrutto as money)) % 0.05 BETWEEN 0.00001 AND 0.001
*/
--SELECT *, Betrag = CONVERT(varchar, CONVERT(float,BetragBrutto)) FROM #BruttoAuszahlungen
/*
    SELECT @KbPeriodeID, BKA.BgKostenartID, 1/*Budget*/, GetDate(), TMP.Termin, GetDate(), FLOOR((-SUM(BetragBrutto)) * 20.0 + 0.5) / 20.0, BKA.Name, TMP.KbBuchungStatusCode, @UserID, @BgBudgetID, @Kostenstelle, $0.0,
      CASE TMP.Abgetreten WHEN 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END,
      CASE TMP.Abgetreten WHEN 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END,
      BKA.Belegart
    FROM #BruttoAuszahlungen TMP
      INNER JOIN BgKostenart BKA ON BKA.BgKostenartID = TMP.BgKostenartID
    GROUP BY BKA.BgKostenartID, Termin, BKA.Name, KbBuchungStatusCode, TMP.Abgetreten, BKA.Hauptvorgang, BKA.Teilvorgang, BKA.HauptvorgangAbtretung, BKA.TeilvorgangAbtretung, BKA.Belegart
  */

  -- Buchungskopf, gruppiert nach Kostenart/Auszahltermin
  INSERT INTO @KbBuchungBrutto (KbPeriodeID, BgKostenartID, KbBuchungTypCode, BelegDatum, ValutaDatum, ErfassungsDatum, Betrag, [Text], KbBuchungStatusCode, UserID, BgBudgetID, Kostenstelle, BetragEffektiv, Hauptvorgang, Teilvorgang, Belegart, BgPositionID, FaLeistungID, BgSplittingArtCode, Weiterverrechenbar, Quoting, Abgetreten, Einnahme, PscdKennzeichen)
    SELECT @KbPeriodeID, BKA.BgKostenartID, 1/*Budget*/, GetDate(), TMP.Termin, GetDate(), FLOOR((-SUM(BetragBrutto)) * 20.0 + 0.5) / 20.0, BKA.Name, TMP.KbBuchungStatusCode, @UserID, @BgBudgetID, @Kostenstelle, $0.0,
--      CASE TMP.Abgetreten WHEN 1 THEN BKA.HauptvorgangAbtretung ELSE BKA.Hauptvorgang END,
--      CASE TMP.Abgetreten WHEN 1 THEN BKA.TeilvorgangAbtretung  ELSE BKA.Teilvorgang  END,
      TMP.Hauptvorgang,
      TMP.Teilvorgang,
      BKA.Belegart,
      CASE Einnahme WHEN 1 THEN TMP.BgPositionID END, @FaLeistungID, BKA.BgSplittingArtCode, BKA.Weiterverrechenbar, BKA.Quoting, IsNull(TMP.Abgetreten,0), TMP.Einnahme,
      TMP.PscdKennzeichen
    FROM #BruttoAuszahlungen TMP
      INNER JOIN dbo.BgKostenart BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = TMP.BgKostenartID
    GROUP BY BKA.BgKostenartID, Termin, BKA.Name, KbBuchungStatusCode, TMP.Abgetreten, TMP.Hauptvorgang, TMP.Teilvorgang, BKA.Belegart, CASE Einnahme WHEN 1 THEN TMP.BgPositionID END, BKA.BgSplittingArtCode, BKA.Weiterverrechenbar, BKA.Quoting, IsNull(TMP.Abgetreten,0), Einnahme, TMP.PscdKennzeichen

  -- Detailpositionen (mit Quoting)
  INSERT INTO @KbBuchungBruttoPerson (KbBuchungBruttoID, BgPositionID, BaPersonID, Schuldner_BaInstitutionID, Schuldner_BaPersonID, Buchungstext, Betrag, VerwPeriodeVon, VerwPeriodeBis)
    SELECT KBN.KbBuchungBruttoID, AUZ.BgPositionID, AUZ.BaPersonID_Teil, Schuldner_BaInstitutionID, Schuldner_BaPersonID, AUZ.Name, -BetragBrutto, 
      VerwPeriodeVon = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN AUZ.Termin WHEN 4 /*Entscheid*/ THEN AUZ.VerwPeriodeVon ELSE IsNull(AUZ.VerwPeriodeVon, @FirstDayInMonth) END,
      VerwPeriodeBis = CASE BKA.BgSplittingArtCode WHEN 3 /*Valuta*/ THEN AUZ.Termin WHEN 4 /*Entscheid*/ THEN AUZ.VerwPeriodeVon ELSE IsNull(AUZ.VerwPeriodeBis, @LastDayInMonth)  END
    FROM   #BruttoAuszahlungen    AUZ
      INNER JOIN dbo.BgKostenart  BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = AUZ.BgKostenartID
      INNER JOIN @KbBuchungBrutto KBN ON KBN.BgKostenartID   = AUZ.BgKostenartID
                                     AND AUZ.Termin          = KBN.ValutaDatum
                                     AND KBN.Hauptvorgang    = AUZ.Hauptvorgang
                                     AND KBN.Teilvorgang     = AUZ.Teilvorgang
                                     AND AUZ.BgPositionID    = CASE AUZ.Einnahme WHEN 1 THEN KBN.BgPositionID ELSE AUZ.BgPositionID END
                                     AND AUZ.Einnahme        = KBN.Einnahme
                                     AND AUZ.Abgetreten      = KBN.Abgetreten
                                     AND IsNull(AUZ.PscdKennzeichen,'') = IsNull(KBN.PscdKennzeichen,'')

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


  -- Auszahlungen ab LA798 haben vorerst Status K
  UPDATE @KbBuchungBruttoPerson
  SET GesperrtFuerWV = 1
  FROM @KbBuchungBruttoPerson   KBP
    INNER JOIN @KbBuchungBrutto KBB ON KBB.KBBuchungBruttoID = KBP.KBBuchungBruttoID
    INNER JOIN BgKostenart      BKA ON BKA.BgKostenartID     = KBB.BgKostenartID
  WHERE BKA.KontoNr = '798'

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
    DECLARE @IstForderung bit
    BEGIN TRY
      BEGIN TRAN spWhBudget_CreateKbBuchung

      IF EXISTS (SELECT POS2.BgPositionID
                 FROM #vwBgPosition POS2
                    INNER JOIN dbo.BgPosition POS WITH (SERIALIZABLE) ON POS.BgPositionID = POS2.BgPositionID
                 WHERE POS.BgPositionTS <> POS2.BgPositionTS)
      BEGIN
        RAISERROR('Mindestens eine Position wurde durch einen anderen Benutzer verändert!', 18, 1);
      END      

      IF @COUNT_POS_GBLAufAusgabekonto = 1 BEGIN
        UPDATE BgPosition
        SET BetragGBLAufAusgabekonto = @BetragAusgabekonto
        WHERE BgPositionID = @BgPositionID_GBLAufAusgabekonto
      END


      -- Netto
      DECLARE cKopf CURSOR FAST_FORWARD FOR
        SELECT KbBuchungID, Einnahme
        FROM   @KbBuchung

      OPEN cKopf
      WHILE 1=1 BEGIN
        FETCH NEXT FROM cKopf INTO @KbBuchungID_tmp, @IstForderung
        IF @@FETCH_STATUS <> 0 BREAK

        -- PSCD-Belegnummer lösen
        SET @PscdBelegNr = NULL
        IF @IstForderung = 0 BEGIN
          EXEC dbo.spKbGetBelegNr_out 'AA', @PscdBelegNr OUT
        END

-- TODO #4644
        -- #4644: Hat der Zalungsweg eine Bank mit einer neuen ClearingNr?
        SELECT TOP 1 
          @KreditorMehrZeilig = KRE.KreditorMehrZeilig,  
          @ClearingNr         = BNK.ClearingNr, 
          @ClearingNrNeu      = BNK.ClearingNrNeu,
          @BaZahlungswegID    = KRE.BaZahlungswegID
        FROM @KbBuchung                 BUC
          INNER JOIN dbo.vwKreditorInfo KRE ON KRE.BaZahlungswegID = BUC.BaZahlungswegID
          LEFT  JOIN dbo.BaBank         BNK ON BNK.BaBankID = BUC.BaBankID
        WHERE BUC.KbBuchungID = @KbBuchungID_tmp
     
        IF @ClearingNrNeu IS NOT NULL
        BEGIN
          CLOSE cKopf
          DEALLOCATE cKopf
          SET @Message = 'Der Zahlungsweg mit der ID %d hat eine Bank (ClearingNr %s) mit einer neuen ClearingNr.' + CHAR(13) + CHAR(10) +
                         'Kreditor:'+ CHAR(13) + CHAR(10) +
                         '%s'
          RAISERROR (@Message, 18, 1, @BaZahlungswegID, @ClearingNr, @KreditorMehrZeilig)
          RETURN -1
        END
        

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
                    [Belegart],[VerwPeriodeVon],[VerwPeriodeBis],[PscdKennzeichen])
          SELECT 	@KbBuchungID_new,[BgPositionID],[BgKostenartID],[BaPersonID],[Buchungstext],[Betrag],[KontoNr],[PositionImBeleg],[Hauptvorgang],[Teilvorgang],
                    [Belegart],[VerwPeriodeVon],[VerwPeriodeBis], [PscdKennzeichen]
          FROM @KbBuchungKostenart
          WHERE KbBuchungID = @KbBuchungID_tmp
          ORDER BY KontoNr, PositionImBeleg
          
        IF @@ROWCOUNT = 0 BEGIN
          RAISERROR('Interner Fehler: Nettobuchung ohne Detailposition erstellt!', 18, 1)
        END
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
                                     [Kostenstelle], [Hauptvorgang], [Teilvorgang], [Belegart], [FaLeistungID], BgSplittingArtCode, Weiterverrechenbar, Quoting, Abgetreten, PscdKennzeichen)
          SELECT [KbPeriodeID], [BgKostenartID], [KbBuchungTypCode], [Code], @PscdBelegNr, [BelegDatum], [ValutaDatum], [ErfassungsDatum], [TransferDatum], [Zahlungsfrist], [Betrag],
                 [BetragEffektiv], [DatumEffektiv], [Text], [KbBuchungStatusCode], [UserID], [StorniertKbBuchungBruttoID], [BgBudgetID], [PscdFehlermeldung], [ModulID],
                 [Kostenstelle], [Hauptvorgang], [Teilvorgang], [Belegart], [FaLeistungID], BgSplittingArtCode, Weiterverrechenbar, Quoting, Abgetreten, PscdKennzeichen
          FROM @KbBuchungBrutto
          WHERE KbBuchungBruttoID = @KbBuchungBruttoID_tmp

        -- 'echte' ID bestimmen
        SELECT @KbBuchungBruttoID_new = SCOPE_IDENTITY()

        -- Detailpositionen einfügen
        INSERT INTO KbBuchungBruttoPerson ([KbBuchungBruttoID], [BgPositionID], [BaPersonID], [Schuldner_BaInstitutionID], [Schuldner_BaPersonID],	[Buchungstext], [Betrag], [VerwPeriodeVon], [VerwPeriodeBis], [PositionImBeleg], [GesperrtFuerWV])
          SELECT 	@KbBuchungBruttoID_new, [BgPositionID], [BaPersonID], [Schuldner_BaInstitutionID], [Schuldner_BaPersonID],	[Buchungstext], [Betrag], [VerwPeriodeVon], [VerwPeriodeBis], [PositionImBeleg], [GesperrtFuerWV]
          FROM @KbBuchungBruttoPerson
          WHERE KbBuchungBruttoID = @KbBuchungBruttoID_tmp

        IF @@ROWCOUNT = 0 BEGIN
          RAISERROR('Interner Fehler: Bruttobuchung ohne Detailposition erstellt!', 18, 1)
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
      ROLLBACK 
      DECLARE @errormsg varchar(500)
      SET @errormsg = ERROR_MESSAGE()
      RAISERROR(@errormsg,18,1)
    END CATCH
  END

  IF @PreviewMode = 1 BEGIN
    -- Netto Preview
    SELECT
      *, 
      KbBuchungID,
      Betrag,
      --BetragEffektiv,
      ValutaDatum,
      Text,
      KbAuszahlungsArtCode,
      KbBuchungStatusCode,
      BelegNr,
      BelegDatum,
      PscdZahlwegArt,
      PscdFehlermeldung,
      Betrag      = CASE WHEN KRE.KontoNr = KBU.HabenKtoNr THEN -Betrag ELSE Betrag END,
      BetragTotal = CASE WHEN KRE.KontoNr = KBU.HabenKtoNr THEN -Betrag ELSE Betrag END,
      Zahlungsempfaenger = IsNull(ZPR.NameVorname, ZIN.Name)
    FROM   @KbBuchung KBU
           LEFT JOIN dbo.BaZahlungsweg      ZAL  WITH (READUNCOMMITTED) ON ZAL.BaZahlungswegID   = KBU.BaZahlungswegID
           LEFT JOIN dbo.vwPerson           ZPR                         ON ZPR.BaPersonID        = ZAL.BaPersonID
           LEFT JOIN dbo.vwInstitution      ZIN                         ON ZIN.BaInstitutionID   = ZAL.BaInstitutionID
           LEFT JOIN dbo.KbKonto            KRE  WITH (READUNCOMMITTED) ON KRE.KbPeriodeID       = KBU.KbPeriodeID AND ',' + KRE.KbKontoartCodes + ',' LIKE '%30%'
    SELECT BKA.*, PersonName = PRS.NameVorname
    FROM   @KbBuchungKostenart BKA
           LEFT  JOIN vwPerson    PRS ON PRS.BaPersonID  = BKA.BaPersonID
    --WHERE  ABS(Betrag) > $0.01
    ORDER BY KontoNr, PositionImBeleg

  END
  ELSE IF @PreviewMode = 2 BEGIN
    -- Brutto Preview
    SELECT *
    FROM   @KbBuchungBrutto

    SELECT BKA.*, PersonName = PRS.NameVorname
    FROM   @KbBuchungBruttoPerson  BKA
           LEFT  JOIN dbo.vwPerson PRS ON PRS.BaPersonID = BKA.BaPersonID

  END

END