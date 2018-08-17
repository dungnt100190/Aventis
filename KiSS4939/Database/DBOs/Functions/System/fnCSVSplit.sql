SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnCSVSplit;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnCSVSplit.sql $
  $Author: Cjaeggi $
  $Modtime: 16.03.10 16:50 $
  $Revision: 3 $
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
  $Log: /KiSS4/Database/DBOs/Functions/System/fnCSVSplit.sql $
 * 
 * 3     16.03.10 16:52 Cjaeggi
 * Revised to fit guidelines
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:33 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnCSVSplit
(
  @CSV VARCHAR(8000),
  @index INT
)
RETURNS VARCHAR(8000)
AS BEGIN
  DECLARE @OUTPUT VARCHAR(8000);
  DECLARE @i INT;
  
  SELECT @OUTPUT = @CSV,
         @i      = 1;
  
  WHILE (@i < @index)
  BEGIN
    IF (@OUTPUT LIKE '%;%')
    BEGIN
      SELECT @OUTPUT = SUBSTRING(@OUTPUT, CHARINDEX(';', @OUTPUT) + 1, 8000),
             @i      = @i + 1;
    END
    ELSE
    BEGIN
      RETURN NULL;
    END;
  END;
  
  IF (@OUTPUT LIKE '%;%')
  BEGIN
    SET @OUTPUT = SUBSTRING(@OUTPUT, 1, CHARINDEX(';', @OUTPUT) - 1);
  END;
  
  RETURN @OUTPUT;
END;
GO