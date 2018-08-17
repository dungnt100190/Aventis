 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject fnBgGetPositionenCount
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnBgGetPositionenCount.sql $
  $Author: Mminder $
  $Modtime: 16.12.09 13:56 $
  $Revision: 1 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnBgGetPositionenCount.sql $
 * 
 * 1     16.12.09 13:56 Mminder
 * #4915: Testfeedback 2. Runde: Es werden nicht mehr Kürzungspositionen
 * erstellt als Monate definiert sind
 * 
 * 
=================================================================================================*/

CREATE FUNCTION [dbo].[fnBgGetPositionenCount]
(
  @BgSpezkontoID      int,
  @BgBudgetID_Exclude int = NULL
)
RETURNS int
AS BEGIN
  DECLARE @Count int

  SELECT @Count = COUNT(*)
  FROM BgPosition
  WHERE BgSpezkontoID = @BgSpezkontoID
    AND (@BgBudgetID_Exclude IS NULL OR @BgBudgetID_Exclude <> BgBudgetID)

  RETURN @Count
END
GO

