SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spWhKVGVVGBewilligen;
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Diese Funktion bewilligt die drei Positionen KVG, KVG-Übermax und VVG und ist ein Workaround:
  Wenn Positionen mit Betrag 0 bewilligt werden, gibt es mit der Auszahlungsart Probleme.
  Die komische Funktion ist spWhFinanzplan_Bewilligen. Im Falle eines Betrages von 0 würde trotzdem
  ein Eintrag in AuszahlungPerson erstellt.
  
-------------------------------------------------------------------------------------------------
  SUMMARY:  
    @BgFinanzplanId: Id des Finanzplans.
    @DatumVon: Bewilligung ab 
    @BgPositionIdHauptposition: Id der Hauptposition KVG.
  -
  RETURNS: -
=================================================================================================
  TEST:    EXEC dbo.spWhKVGVVGBewilligen ...;
=================================================================================================*/

CREATE PROCEDURE dbo.spWhKVGVVGBewilligen
(
  @BgFinanzplanId INT, 
  @DatumVon DATETIME, 
  @BgPositionIdHauptposition INT
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- 
  -----------------------------------------------------------------------------
  DECLARE @BgPositionId_KVG INT;
  DECLARE @BgPositionId_VVG INT;
  DECLARE @KVGBetrag MONEY;
  DECLARE @VVGBetrag MONEY;
  
  SELECT   
    @BgPositionId_KVG = KVG.BgPositionId,    
    @BgPositionId_VVG = VVG.BgPositionId,
    @KVGBetrag = KVG.Betrag,
    @VVGBetrag = VVG.Betrag
                                      
  FROM BgPosition              BPO
    
    -- VVVG
    LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode IN (32021, 32022)) VVG ON VVG.BgBudgetID = BPO.BgBudgetID AND VVG.BgPositionID_Parent = BPO.BgPositionID
    LEFT JOIN BgPositionsArt SPTVVG ON SPTVVG.BgPositionsartId = VVG.BgPositionsartId
           
    -- KGV        
    LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode IN (32023, 32024)) KVG ON KVG.BgBudgetID = BPO.BgBudgetID AND KVG.BgPositionID_Parent = BPO.BgPositionID    
    LEFT JOIN BgPositionsArt SPTKGV ON SPTKGV.BgPositionsartId = KVG.BgPositionsartId     
        
  WHERE BPO.BgPositionId = @BgPositionIdHauptposition; 
  
  IF @KVGBetrag = 0
  BEGIN
	UPDATE BPO
    SET 
      Betrag = 1 
    FROM BgPosition BPO
    WHERE BPO.BgPositionId = @BgPositionId_KVG;   
  END
 
  IF @VVGBetrag = 0
  BEGIN
 
    UPDATE BPO
    SET 
      Betrag = 1    
    FROM BgPosition BPO
    WHERE BPO.BgPositionId = @BgPositionId_VVG;  
  END
  
  
  EXECUTE spWhFinanzplan_Bewilligen @BgFinanzplanId, @DatumVon, @BgPositionIdHauptposition;
  
  IF @KVGBetrag = 0
   BEGIN
	UPDATE BPO
    SET 
      Betrag = 0 
    FROM BgPosition BPO
    WHERE BPO.BgPositionId = @BgPositionId_KVG;   
  END
 
  IF @VVGBetrag = 0
  BEGIN
 
    UPDATE BPO
    SET 
      Betrag = 0    
    FROM BgPosition BPO
    WHERE BPO.BgPositionId = @BgPositionId_VVG;  
  END
  
  EXECUTE spWhFinanzplan_Bewilligen @BgFinanzplanId, @DatumVon, @BgPositionIdHauptposition;
  
END;
GO
