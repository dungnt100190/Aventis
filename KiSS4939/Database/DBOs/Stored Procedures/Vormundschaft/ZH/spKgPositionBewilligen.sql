SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgPositionBewilligen
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
  Bewilligt eine einzelne Masterbudget-Position. 
  Falls das Masterbudget selber schon bewilligt war, und es bereits Monatsbudgets gibt, die in den
  Gültigkeitsraum der zu bewilligenden Position fallen, müssen für diese Monatsbudgets die ent-
  sprechenden Budget-Positionen nacherfasst und grüngestellt werden.
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spKgPositionBewilligen
(
  @KgPositionID int,    -- Masterbudget-Position, die bewilligt werden soll
  @UserID int   
)
AS BEGIN

DECLARE @MasterBudgetID int,
        @KgBudgetID int,
        @DatumVon datetime,
        @DatumBis datetime
        
-- Hole ein paar Daten der MasterBudget-Position, die bewilligt werden soll        
SELECT @MasterBudgetID = KgBudgetID, @DatumVon = DatumVon, @DatumBis = DatumBis FROM KgPosition WHERE KgPositionID = @KgPositionID

-- Setze den Bewilligungs-Status der MasterBudget-Position
UPDATE KgPosition
SET KgBewilligungCode = 5	-- 5 = bewilligt
WHERE KgPositionID = @KgPositionID

-- Hole einen Cursur über alle Monatsbudgets des Masterbudgets dieser Masterbudget-Position, die innerhalb der Gültigkeitsperiode der Masterbudget-Position liegen
DECLARE C CURSOR FOR
SELECT	KgBudgetID FROM KgBudget BUD
		WHERE BUD.KgMasterBudgetID = @MasterBudgetID 
		    AND CONVERT(datetime, CONVERT(varchar, BUD.Jahr) + '-' + CONVERT(varchar, BUD.Monat)  + '-15') BETWEEN IsNull(@DatumVon, CONVERT(datetime, '1900-01-01')) AND IsNull(@DatumBis, CONVERT(datetime, '2999-12-31'))

-- Nun erstelle die neuen Monatsbudget-Positionen für alle selektierten Monatsbudgets
OPEN C
FETCH NEXT FROM C INTO @KgBudgetID
WHILE @@fetch_status = 0 BEGIN
  EXEC spKgBudget_CreatePosition @KgPositionID, @KgBudgetID, @UserID  -- Kreiere neue Monatsbudget-Position
  FETCH NEXT FROM C INTO @KgBudgetID  
END
CLOSE C
DEALLOCATE C

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
