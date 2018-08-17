SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXCompareSQL_VARIANT;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnXCompareSQL_VARIANT.sql $
  $Author: Cjaeggi $
  $Modtime: 18.03.10 17:13 $
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
  $Log: /KiSS4/Database/DBOs/Functions/System/fnXCompareSQL_VARIANT.sql $
 * 
 * 3     18.03.10 17:19 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnXCompareSQL_VARIANT
(
  @Value_A SQL_VARIANT,
  @Value_B SQL_VARIANT
)
RETURNS BIT
AS BEGIN
  IF (@Value_A IS NULL AND @Value_B IS NULL)
  BEGIN
    RETURN 1;
  END;
  
  IF (@Value_A IS NULL AND @Value_B IS NOT NULL)
  BEGIN
    RETURN 0;
  END;
  
  IF (@Value_A IS NOT NULL AND @Value_B IS NULL)
  BEGIN
    RETURN 0;
  END;
  
  IF (@Value_A = @Value_B)
  BEGIN
    RETURN 1;
  END;
  
  RETURN 0;
END;
GO