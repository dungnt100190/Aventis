SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetAppCodeNamedValue;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnGetAppCodeNamedValue.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 9:48 $
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
  $Log: /KiSS4/Database/DBOs/Functions/System/fnGetAppCodeNamedValue.sql $
 * 
 * 3     17.03.10 9:48 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetAppCodeNamedValue
(
  @Name VARCHAR(100),
  @AppCode VARCHAR(200)
)
RETURNS VARCHAR(100)
AS BEGIN
  IF (@Name IS NULL OR @AppCode IS NULL)
  BEGIN
    RETURN NULL;
  END;
  
  DECLARE @idx INT;
  DECLARE @Value VARCHAR(100);
  
  SET @idx = CHARINDEX('[' + @Name + '=', @AppCode);
  
  IF (@idx = 0)
  BEGIN
    RETURN NULL;
  END;
  
  SET @Value = SUBSTRING(@AppCode, @idx + LEN(@Name) + 2, 100);
  
  IF (CHARINDEX(']', @Value) = 0)
  BEGIN
    RETURN NULL;    -- syntax error
  END;
  
  RETURN SUBSTRING(@Value, 1, CHARINDEX(']', @Value) - 1);
END;
GO