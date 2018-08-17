/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Script für Umstellung Zahlungsweg von Papierverfügung auf el. Auszahlung
   
  Es ist vorgesehen dass dieses Script separat  (ausserhalb des Updates eines Releases) auf der INT/PROD Umgebung ausgeführt wird

=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
PRINT 'KZOL-84-001' 
-------------------------------------------------------------------------------

BEGIN TRAN

  DECLARE @lovName AS VARCHAR(100);
  SET @lovName = 'KbAuszahlungsArt';
  DECLARE @lovCode AS INTEGER
  SET @lovCode = 101;
  DECLARE @value3 AS VARCHAR(255);
  SET @value3 = 'S';
  DECLARE @text AS VARCHAR(200);
  SET @Text = 'Elektronische Auszahlung';

  IF EXISTS(SELECT TOP 1 1 
            FROM dbo.XLOVCode LOC 
            WHERE LOVName = @lovName
              AND Code = @lovCode)
  BEGIN

    PRINT 'Update ' + @lovName + ' mit  Code=' + CONVERT(VARCHAR(100),@lovCode)

    UPDATE dbo.XLOVCode 
    SET Value3 = @value3,
        IsActive = 1,
        [Text] = @Text
    WHERE 1=1
      AND LOVName = @lovName 
      AND Code = @lovCode;

  END
  ELSE
  BEGIN 

    PRINT 'Insert new ' + @lovName + ' mit  Code=' + CONVERT(VARCHAR(100),@lovCode)
  
    DECLARE @xlovid AS INTEGER
    SELECT @xlovid = XLOVID FROM dbo.XLOV LOV2  WHERE LOVName = @lovName;  

    INSERT INTO XLOVCode (  XLOVID, 
                            LOVName, 
                            Code, 
                            [Text], 
                            SortKey, 
                            ShortText, 
                            Value3, 
                            IsActive, 
                            [System])
    
    SELECT  @xlovid,
            @lovName,
            @lovCode,
            @Text,
            1,
            'elektr.',
            @value3,
            1,
            1;

  END     

  -------------------------------------------------------------------------------
  PRINT 'KZOL-84-002 - Konfigurationswerte anpassen' 
  -------------------------------------------------------------------------------

  EXECUTE dbo.spAddXConfig @KeyPath = 'System\Sozialhilfe\EZStandardAuszahlungsart', -- varchar(500)
    @DatumVon = '20151210', -- datetime - ab 10. Dezember
    @ValueVar = 101, -- sql_variant
    @ValueCode = 2, -- int
    @Description = NULL, -- varchar(1000)
    @OriginalValue = NULL, -- sql_variant
    @System = NULL -- bit

  EXECUTE dbo.spAddXConfig @KeyPath = 'System\Sozialhilfe\KlientStandardZahlungart', -- varchar(500)
    @DatumVon = '20151210', -- datetime
    @ValueVar = 101, -- sql_variant
    @ValueCode = 2, -- int
    @Description = NULL, -- varchar(1000)
    @OriginalValue = NULL, -- sql_variant
    @System = NULL -- bit

  -------------------------------------------------------------------------------
  PRINT 'KZOL-84-002 - Per Script alle Masterbudgets, die im Januar 2016 gültig sind auf elektr. Auszahlung stellen' 
  -------------------------------------------------------------------------------

  -- KbAuszahlungsArtCode von 102 -> 101 für die Positionen ab 2016

  -- Nur Monatsbudget
  UPDATE BAPu 
  SET BAPu.KbAuszahlungsArtCode = 101 -- Elektronische Auszahlung (Kreditor, direkt zur Buchhaltung)
  --SELECT  A.BgFinanzplanID, *
  FROM BgAuszahlungPerson BAPu
    INNER JOIN (SELECT BgFinanzplanID = BDG.BgFinanzplanID,
                       BgBudgetID = BPO.BgBudgetID,
                       BgAuszahlungPersonID = BAP.BgAuszahlungPersonID,
                       [Status] = CASE
                                    WHEN BDG.MasterBudget = 0 
                                      THEN
                                      CASE
                                        WHEN STA.Status IS NULL
                                          THEN
                                          CASE
                                            WHEN BPO.BgKategorieCode IN (2) AND KRE.BaZahlungswegID IS NULL AND BPO.BgSpezkontoID IS NOT NULL -- Auszahlung an Spezialkonto
                                              THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                            WHEN BPO.BgKategorieCode = 1 AND BPO.VerwaltungSD = 0 -- nicht abgetretene Einnahmen
                                              THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                            WHEN BPO.BgKategorieCode = 2 AND ((KRE.BaPersonID IS NOT NULL AND KRE.BaZahlungswegID IS NOT NULL) OR BAP.KbAuszahlungsArtCode = 103)-- Ausgaben an Klient (ohne tatsächliche Auszahlung), elektronisch oder bar (103).
                                              THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                            WHEN BPO.BgKategorieCode IN (3, 4, 6)  -- Abzahlung / Kürzung / Vorabzug
                                              THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                            WHEN BPO.BgKategorieCode IN (101)   -- Einzelzahlungen
                                              THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 14 ELSE 1 END
                                            ELSE
                                              CASE BPO.BgBewilligungStatusCode
                                                WHEN 1 THEN 1   -- grau
                                                WHEN 2 THEN 15  -- abgelehnt
                                                WHEN 3 THEN 12  -- angefragt
                                                WHEN 5 THEN 14  -- bewilligt
                                                WHEN 9 THEN 7   -- gesperrt
                                              END
                                          END
                                        ELSE STA.Status
                                      END
                                  END          
                  FROM dbo.BgPosition                 BPO
                    INNER JOIN dbo.BgAuszahlungPerson BAP ON BAP.BgPositionID = BPO.BgPositionID
                    INNER JOIN dbo.BgBudget           BDG ON BDG.BgBudgetID = BPO.BgBudgetID
                    LEFT  JOIN vwKreditor             KRE ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
                    LEFT  JOIN (SELECT BUC.BgBudgetID,
                                       BUK.BgPositionID, 
                                       [Status]     = MAX(BUC.KbBuchungStatusCode), 
                                       StatusMin    = MIN(BUC.KbBuchungStatusCode), 
                                       AnzahlBelege = COUNT(DISTINCT BUC.KbBuchungID)
                                FROM   KbBuchungKostenart BUK 
                                  LEFT JOIN KbBuchung BUC ON BUC.KbBuchungID = BUK.KbBuchungID
                                GROUP BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = BPO.BgBudgetID 
                                                                              AND STA.BgPositionID = BPO.BgPositionID
                   WHERE BAP.KbAuszahlungsArtCode = 102 -- Papierverfügung (Kreditor, über Papierverfügung zur Buchhaltung)       
                     AND BDG.Jahr >= 2016
                     AND BDG.MasterBudget = 0) A ON A.BgAuszahlungPersonID = BAPu.BgAuszahlungPersonID
   WHERE A.[Status] = 1

  -- Nur Masterbudgets
  UPDATE BAPu 
  SET BAPu.KbAuszahlungsArtCode = 101 -- Elektronische Auszahlung (Kreditor, direkt zur Buchhaltung)   
  --SELECT *
  FROM dbo.BgAuszahlungPerson BAPu
  INNER JOIN dbo.BgPosition BPO ON BPO.BgPositionID = BAPu.BgPositionID 
  INNER JOIN dbo.BgBudget BDG ON BDG.BgBudgetID = BPO.BgBudgetID
  INNER JOIN dbo.BgFinanzplan FPL ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
  WHERE BAPu.KbAuszahlungsArtCode = 102 -- Papierverfügung (Kreditor, über Papierverfügung zur Buchhaltung)    
    AND BDG.MasterBudget = 1
    AND YEAR(dbo.fnDateOf(COALESCE(FPL.DatumBis, FPL.GeplantBis, '99991231'))) >= 2016
  

COMMIT TRAN


-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO