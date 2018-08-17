SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnMIN;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnMIN.sql $
  $Author: Cjaeggi $
  $Modtime: 18.03.10 16:36 $
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
  $Log: /KiSS4/Database/DBOs/Functions/System/fnMIN.sql $
 * 
 * 3     18.03.10 16:36 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnMIN
(
  @val1 SQL_VARIANT,
  @val2 SQL_VARIANT
)
RETURNS SQL_VARIANT
AS BEGIN
  IF (@val1 > @val2)
  BEGIN
    RETURN ISNULL(@val2, @val1);
  END;
  
  RETURN ISNULL(@val1, @val2);
END;
GO