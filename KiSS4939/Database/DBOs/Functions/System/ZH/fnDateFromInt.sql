SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnDateFromInt;
GO
/*===============================================================================================
  $Revision: 2 $
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

CREATE FUNCTION dbo.fnDateFromInt
(
  @Date INT
)
RETURNS DATETIME
AS
BEGIN
  DECLARE @Year INT;
  DECLARE @Month INT;
  DECLARE @Day INT;
  
  SET @Year  = CAST(@Date AS INT) / 10000;
  SET @Month = CAST(@Date AS INT) / 100 % 100;
  SET @Day   = @Date % 100;

  RETURN dbo.fnDateSerial(@Year, CASE 
                                   WHEN @Month = 0 THEN 1 
                                   ELSE @Month 
                                 END, 
                                 CASE 
                                   WHEN @Day = 0 THEN 1 
                                   ELSE @Day 
                                 END);
END;
GO