SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhKVGVVGAnpassen
GO

/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Methode kopiert KVG, VVG GBL, KVG GGB Tripel einer Person und passt es an die 
           Konfigurationswerte an, die zum gewünschten Zeitpunkt gültig sind.
           Eine ausführliche Dokumentation ist im Ticket #8096 enthalten.                   
    @BgBudgetId: Id des Budgets
    @BaPersonId: Id der Person 
    @DatumVon: Für Konfigurationswerte, welche berücksichtigt werden.
  -
  RETURNS: Kein Rückgabewert
  -
  TEST:    

DECLARE @DatumVon DATETIME;
DECLARE @BgBudgetId INT;
DECLARE @BaPersonId INT;


SET @DatumVon = '20110701';
SET @BgBudgetId = 416450;
SET @BaPersonId = 12501;


EXEC spWhKVGVVGAnpassen @BgBudgetId, @BaPersonId, @DatumVon;
=================================================================================================*/
CREATE PROCEDURE dbo.spWhKVGVVGAnpassen
(
   @BgBudgetId INT,
   @BaPersonId INT,
   @DatumVon DATETIME
)
AS 

BEGIN

  -- Validierungen
  IF (@BgBudgetId = NULL)
  BEGIN
    RAISERROR ('Anpassung schlug fehl: %s', 18, 1, '@BgBudgetId darf nicht null sein');
  END;
  
  IF (@DatumVon = NULL)
  BEGIN
    RAISERROR ('Anpassung schlug fehl: %s', 18, 1, '@DatumVon darf nicht null sein');
  END;
  
  IF (@BaPersonId = NULL)
  BEGIN
    RAISERROR ('Anpassung schlug fehl: %s', 18, 1, '@BaPersonId darf nicht null sein');
  END;
  
  -- Aktuelle  PositionId ermitteln (KGV Hauptposition).
  -- Diese Position muss zum Zeitpunkt @DatumVon gültig sein.      
  DECLARE @BgPositionId INT;
  
  SELECT @BgPositionId = BPO.BgPositionId
  FROM dbo.BgPosition             BPO
    INNER JOIN dbo.WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  WHERE BPO.BgBudgetId = @BgBudgetId
    AND BPO.BaPersonId = @BaPersonId
    AND (BPO.DatumVon IS NULL OR BPO.DatumVon <= @DatumVon)
    AND (BPO.DatumBis IS NULL OR BPO.DatumBis >=  @DatumVon)
    AND (SPT.BgPositionsartCode = 32020 OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130)
   
  IF (@BgPositionId = NULL)
  BEGIN
    RAISERROR ('Anpassung schlug fehl: %s', 18, 1, 'Es konnte keine gültige Budgetposition zum Anpassungsdatum gefunden werden');
  END;
  

  -- Tripel zum Kopieren zusammenstellen: 
  -- 1. Hauptposition KVG 
  -- 2. Neben-Position KVG (kann vom GBL abgezogen oder vom SD übernommen werden).
  -- 3. Neben-Position VVG (kann vom GBL abgezogen oder vom SD übernommen werden).
  SELECT 
    DISTINCT BgPositionID AS Pk, 
    BgPositionID_Parent   AS Parent, 
    CONVERT(int, NULL) AS KeyNew
  INTO #BgPosition
  FROM dbo.BgPosition 
  WHERE BgBudgetID = @BgBudgetId 
    AND (BgPositionID = @BgPositionID OR BgPositionID_Parent = @BgPositionID) -- Abzug GBL Kvg, Vvg.


  -- Kopie des Tripels anlegen.
  EXECUTE spXParentChildCopy '#BgPosition', -- TempTableName
                             'BgPosition',  -- TableName
                             'BgPositionID', -- PrimaryKeyName
                             'BgPositionID_Parent',  -- ParentKeyName
                             'BgPositionID_CopyOf', --FixColumnNames
                             'BgPositionID',        -- FixColumnValues
                             'OldID, BgBewilligungStatusCode' --DBDefaultNames
                             
                             
  -- Nun auch BgAuszahlungPerson und BgAuszahlungPersonTermin kopieren, sofern vorhanden.
  -- In der Regel geht es ja auf ein Spezialkonto, aber man kann im Masterbudget die Auszahlung
  -- z.b. auf elektronisch stellen.
    
  -- BgAuszahlungPerson kopieren
  SELECT 
      BgAuszahlungPersonID AS PK, 
      CONVERT(int, NULL) AS Parent, 
      CONVERT(int, NULL) AS KeyNew
  INTO #BgAuszahlungPerson
  FROM dbo.BgAuszahlungPerson    BAP
    INNER  JOIN #BgPosition  BPO ON BPO.PK = BAP.BgPositionID

  EXECUTE spXParentChildCopy '#BgAuszahlungPerson',  -- TempTableName
                              'BgAuszahlungPerson',   -- TableName
                              'BgAuszahlungPersonID', -- PrimaryKeyName
                              NULL,  -- ParentKeyName
                              'BgPositionID',   --FixColumnNames
                              '(SELECT KeyNew FROM #BgPosition WHERE PK = BgPositionID)' --DBDefaultNames
                              
  -- BgAuszahlungPersonTermin anlegen
  INSERT INTO BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum)
  SELECT 
    TMP.KeyNew, -- BgAuszahlungPersonID
    TRM.Datum   -- Valutadatum
  FROM #BgAuszahlungPerson                   TMP
    INNER JOIN dbo.BgAuszahlungPersonTermin  TRM ON TRM.BgAuszahlungPersonID = TMP.PK                              
 
                             
  -- Datum von Anpassen
  UPDATE BPO
    SET BPO.DatumVon = @DatumVon
  FROM dbo.BgPosition      BPO
    INNER JOIN #BgPosition TMP ON TMP.KeyNew = BPO.BgPositionId;
    
  -- FinanzplanId ermitteln
  DECLARE @BgFinanzplanId INT;
  
  SELECT @BgFinanzplanId = BDG.BgFinanzplanID
  FROM dbo.BgBudget BDG
  WHERE BDG.BgBudgetId = @BgBudgetId;
  
  -- Id von neu erstellter Hauptposition ermitteln 
  DECLARE @BgPositionId_NeueHauptposition INT;
  SELECT @BgPositionId_NeueHauptposition = BPO.BgPositionId
  FROM dbo.BgPosition      BPO
    INNER JOIN #BgPosition TMP ON TMP.KeyNew = BPO.BgPositionId  
  WHERE BPO.BgPositionID_Parent IS NULL;  -- Hauptposition hat kein Parent  
  
  
  -- Diverse Werte eruieren.
  DECLARE @KVGBetrag MONEY;
  DECLARE @KVGReduktion MONEY;
  DECLARE @KVGTotal MONEY;
  DECLARE @KVGLimit MONEY;
  
  DECLARE @Betrag MONEY;
  DECLARE @Reduktion MONEY;
  DECLARE @MaxBeitragSD MONEY;
  
  DECLARE @BgPositionId_KVG INT;
  DECLARE @BgPositionId_VVG INT;  
  
  DECLARE @BgPositionsartCode_KVG INT;
  DECLARE @BgPositionsartCode_VVG INT;
  DECLARE @BgPositionsartCode INT;
  
  DECLARE @VVGBetrag    MONEY;
  DECLARE @VVGReduktion MONEY;
  
      
  
  SELECT
    @KVGBetrag              = (BPO.Betrag + ISNULL(KVG.Betrag, $0.00)),
    @KVGReduktion           = (BPO.Reduktion + ISNULL(KVG.Reduktion, $0.00)),
    @KVGLimit               = CONVERT(MONEY, dbo.fnXConfig('System\Sozialhilfe\Krankenkasse\' + CONVERT(VARCHAR, SPT.BgPositionsartCode), @DatumVon)),
    @KVGTotal               = (BPO.Betrag + ISNULL(KVG.Betrag, $0.00)) - (BPO.Reduktion + ISNULL(KVG.Reduktion, $0.00)),
    @VVGBetrag              = ISNULL(VVG.Betrag, $0.00),
    @VVGReduktion           = ISNULL(VVG.Reduktion, $0.00),
    @BgPositionId_KVG       = KVG.BgPositionId,
    @BgPositionId_VVG       = VVG.BgPositionId,
    @BgPositionsartCode     = SPT.BgPositionsartCode,
    @BgPositionsartCode_KVG = SPTKGV.BgPositionsartCode,
    @BgPositionsartCode_VVG = SPTVVG.BgPositionsartCode
  FROM dbo.BgPosition             BPO
    INNER JOIN dbo.WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID   
    -- VVVG
    LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
               FROM dbo.BgPosition             BPOI
                 INNER JOIN dbo.BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
               WHERE POAI.BgPositionsartCode IN (32021, 32022)) VVG ON VVG.BgBudgetID = BPO.BgBudgetID AND VVG.BgPositionID_Parent = BPO.BgPositionID
    LEFT JOIN dbo.BgPositionsArt SPTVVG ON SPTVVG.BgPositionsartId = VVG.BgPositionsartId
    -- KGV
    LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
               FROM dbo.BgPosition BPOI
                 INNER JOIN dbo.BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
               WHERE POAI.BgPositionsartCode IN (32023, 32024)) KVG ON KVG.BgBudgetID = BPO.BgBudgetID AND KVG.BgPositionID_Parent = BPO.BgPositionID    
    LEFT JOIN dbo.BgPositionsArt SPTKGV ON SPTKGV.BgPositionsartId = KVG.BgPositionsartId     
  WHERE BPO.BgPositionId = @BgPositionId_NeueHauptposition;
  
  
  -- Betrag und KVG Total berechnen (geschäftsregeln aus CtlBgKrankenkasse kopiert, Methode before_post).   
  IF (@BgPositionsartCode = 32020) -- KVG_Krankenkassenprämie
  BEGIN
    SELECT @Betrag = @KVGBetrag;
    SELECT @MaxBeitragSD = @KVGTotal;
  END
  ELSE
  BEGIN
    SELECT @Betrag       = MIN(Y.X) FROM (SELECT  X = @KVGBetrag UNION SELECT X = @KVGLimit) AS Y;
    SELECT @MaxBeitragSD = MIN(Y.X) FROM (SELECT  X = @KVGTotal UNION SELECT X = @KVGLimit) AS Y;
  END 
    
  -- Betrag sollte MaxBetrag nicht überschreiten.
  DECLARE @MaxBetragKonfig MONEY;
  SELECT @MaxBetragKonfig = CONVERT(MONEY, dbo.fnXConfig('System\Sozialhilfe\SKOS\KVG_MaxPerPerson', @DatumVon));
  SELECT @Betrag = MIN(Y.X) FROM (SELECT  X = @MaxBetragKonfig UNION SELECT X = @Betrag) AS Y;
      
    
  -- Reduktion darf nicht grösser sein als @KVGMaxBeitrag
  SET @Reduktion = @KVGReduktion; 
  DECLARE @KVGMaxBeitrag MONEY;
  SELECT @KVGMaxBeitrag = MIN(Y.X) FROM (SELECT  X = @KVGBetrag UNION SELECT X = @KVGLimit) AS Y;
  
  IF (@Reduktion > @KVGMaxBeitrag)
  BEGIN
    SELECT  @Reduktion = @KVGMaxBeitrag;
  END;
 
         
  -- Hauptposition
  DECLARE @BgPositionsartId INT;
  SELECT @BgPositionsartId = dbo.fnShGetPositionsartIdByCode(@BgPositionsartCode, @DatumVon);
  
  UPDATE BPO
    SET BPO.BgPositionsartId = @BgPositionsartId,
        BPO.Betrag =  @Betrag,
        BPO.Reduktion = @Reduktion,
        BPO.MaxBeitragSD = @MaxBeitragSD
  FROM dbo.BgPosition BPO
  WHERE BPO.BgPositionId = @BgPositionId_NeueHauptposition;
  
  
  -- KGV GBL (KVG kann null sein) anpassen       
  DECLARE @BgPositionsartId_KVG INT;
  DECLARE @Buchungstext VARCHAR(MAX);
  
  -- Nur anpassen, wenn die KVG GBL Position existiert.
  IF (@BgPositionId_KVG IS NOT NULL)
  BEGIN
        
    DECLARE @DatumVon_KVG DATETIME;
    DECLARE @DatumBis_KVG DATETIME;
           
  
    SELECT 
       @BgPositionsartId_KVG = dbo.fnShGetPositionsartIdByCode(@BgPositionsartCode_KVG, @DatumVon),
       @Betrag = @KVGBetrag - BPO.Betrag,
       @Reduktion = @KVGReduktion - BPO.Reduktion,
       @DatumVon_KVG = BPO.DatumVon,
       @DatumBis_KVG = BPO.DatumBis
    FROM dbo.BgPosition BPO
    WHERE BPO.BgPositionId = @BgPositionId_NeueHauptposition;
   
    -- Buchungstext eruieren.   
    SELECT @Buchungstext = POA.NAME
    FROM dbo.BgPositionsart POA
    WHERE POA.BgPositionsartId = @BgPositionsartId_KVG;
    
    -- KVG GBL Updaten.
    UPDATE BPO
      SET BPO.BgPositionsartId = @BgPositionsartId_KVG,
          BPO.Betrag = @Betrag,
          BPO.Reduktion = @Reduktion,
          BPO.DatumVon = @DatumVon_KVG,
          BPO.DatumBis = @DatumBis_KVG,
          BPO.Buchungstext  = @Buchungstext    
    FROM dbo.BgPosition BPO
    WHERE BPO.BgPositionId = @BgPositionId_KVG;    
    
    
  END  -- ENDE KVG GBL
  
 
  -- VVG  GBL (VVG kann null sein)
  DECLARE @BgPositionsartId_VVG INT;
  IF (@BgPositionId_VVG IS NOT NULL)
  BEGIN
    DECLARE @DatumVon_VVG DATETIME;
    DECLARE @DatumBis_VVG DATETIME;
  
    SELECT 
      @BgPositionsartId_VVG = dbo.fnShGetPositionsartIdByCode(@BgPositionsartCode_VVG, @DatumVon),
      @DatumVon_VVG = BPO.DatumVon,
      @DatumBis_VVG = BPO.DatumBis
    FROM dbo.BgPosition BPO
    WHERE BPO.BgPositionId = @BgPositionId_NeueHauptposition;
    
    
    -- Betrag Berechnen    
    SELECT @MaxBetragKonfig = CONVERT(MONEY, dbo.fnXConfig('System\Sozialhilfe\SKOS\VVG_MaxPerPerson', @DatumVon));    
    SELECT @VVGBetrag = MIN(Y.X) FROM (SELECT  X = @MaxBetragKonfig UNION SELECT X = @VVGBetrag) AS Y;
    
    -- Reduktion darf nicht grösser sein als Betrag.
    IF (@VVGReduktion > @VVGBetrag)
    BEGIN
      SELECT @VVGReduktion =  @VVGBetrag; 
    END;
  
    -- Buchungstext eruieren.   
    SELECT @Buchungstext = POA.NAME
    FROM dbo.BgPositionsart POA
    WHERE POA.BgPositionsartId = @BgPositionsartId_VVG;      
    
  
    -- VVG GBL Position updaten.    
    UPDATE BPO
    SET BPO.Betrag = @VVGBetrag,
        BPO.Reduktion = @VVGReduktion,
        BPO.BgPositionsartId = @BgPositionsartId_VVG,
        BPO.DatumVon = @DatumVon_VVG,
        BPO.DatumBis = @DatumBis_VVG,
        BPO.Buchungstext = @Buchungstext    
    FROM dbo.BgPosition BPO
    WHERE BPO.BgPositionId = @BgPositionId_VVG;    
    
  END  -- VVG GBL Position
 
  -- Temporäre Tabellen löschen.
  DROP TABLE #BgPosition;
  DROP TABLE #BgAuszahlungPerson;
         
  ---- Haupt Position bewilligen
  EXECUTE spWhFinanzplan_Bewilligen @BgFinanzplanId, @DatumVon, @BgPositionId_NeueHauptposition;

END
GO