SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhAlleKVGVVGAnpassen
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================

  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Methode kopiert KVG, VVG GBL, KVG GGB Tripel aller Personen im Finanzplan und passt es an die 
           Konfigurationswerte an, die zum gewünschten Zeitpunkt gültig sind.
    @BgBudgetId: Id des Budgets    
    @DatumVon: Konfigurationswerte, welche berücksichtigt werden.
  -
  RETURNS: Kein Rückgabewert
  -
  TEST:    
     DECLARE @DatumVon DATETIME;
     DECLARE @BgBudgetId INT;

     SET @DatumVon = '20110701';
     SET @BgBudgetId = 416450;


     EXEC spWhAlleKVGVVGAnpassen @BgBudgetId, @DatumVon;

=================================================================================================
=================================================================================================*/
CREATE PROCEDURE [dbo].[spWhAlleKVGVVGAnpassen]
(
   @BgBudgetId INT,
   @DatumVon DATETIME
)
AS 

BEGIN
BEGIN TRANSACTION;
BEGIN TRY
  
  DECLARE @BaPersonen TABLE 
  ( 
    ID           INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
    BaPersonId   INT    
  ); 
  
  DECLARE @EntriesCount INT;
  
  -- Alle Personen suchen, die im Finanzplan KVG haben.
  INSERT INTO @BaPersonen (BaPersonId)
  SELECT DISTINCT BPO.BaPersonId
  FROM BgPosition BPO
     INNER JOIN WhPositionsart  SPT  ON SPT.BgPositionsartID = BPO.BgPositionsartID
  WHERE 
    BPO.BgBudgetId = @BgBudgetId
    AND (SPT.BgPositionsartCode = 32020 OR SPT.BgPositionsartCode BETWEEN 32121 AND 32130)
    AND BaPersonId IS NOT NULL; 
    
  SET @EntriesCount = @@ROWCOUNT;     
    
  DECLARE @Counter INT;
  SET @Counter = 1;
  
  DECLARE @BaPersonId INT;
  
  
  -- Über alle Personen iterieren
  WHILE @Counter <= @EntriesCount
  BEGIN
    
    SELECT @BaPersonId = LIST.BaPersonId
    FROM @BaPersonen LIST
    WHERE LIST.ID = @Counter;
    
    -- PRINT 'BaPersonId: ' + CONVERT(VARCHAR, @BaPersonId);
    EXECUTE dbo.spWhKVGVVGAnpassen @BgBudgetId,  @BaPersonId, @DatumVon;
    
    SET @Counter =  @Counter + 1;
  END      
                               
  COMMIT TRANSACTION;
  PRINT ('Info: Successfully completed data handling and committed transaction.');
END TRY

BEGIN CATCH

  DECLARE @ErrorMessage VARCHAR(MAX);
  SET @ErrorMessage = NULL;
  
  -- set error part
  SET @ErrorMessage = ERROR_MESSAGE();
  
  -- do rollback!
  ROLLBACK TRANSACTION;
  
  -- do not continue
  RAISERROR ('Error: Anpassung schlug fehl: %s', 18, 1, @ErrorMessage);
  RETURN;
END CATCH
END

GO
