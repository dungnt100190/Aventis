SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnLOVText;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnLOVText.sql $
  $Author: Cjaeggi $
  $Modtime: 18.03.10 16:31 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: returns fnLOVMLText with languageCode = 1
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnLOVText.sql $
 * 
 * 3     18.03.10 16:31 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnLOVText
(
  @LOVName VARCHAR(100),
  @Code INT
)
RETURNS VARCHAR(200)
AS BEGIN
  RETURN dbo.fnLOVMLText(@LOVName, @Code, 1);
END;
GO