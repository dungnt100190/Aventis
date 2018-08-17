SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFirstDayOf;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/PI/fnFirstDayOf.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 9:40 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get first day in given month and year
    @Date: The date to get first day of month and year
  -
  RETURNS: Date of first day of given month and year or NULL if invalid
  -
  TEST:    SELECT dbo.fnFirstDayOf('2008-01-31');
           SELECT dbo.fnFirstDayOf('2008-03-28');
           SELECT dbo.fnFirstDayOf('2008-02-04');
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/PI/fnFirstDayOf.sql $
 * 
 * 3     17.03.10 9:41 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnFirstDayOf
(
  @Date DATETIME
)
RETURNS DATETIME
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  IF (@Date IS NULL)
  BEGIN
    -- invalid, return null
    RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- calculate first day of month and return value
  -----------------------------------------------------------------------------
  RETURN dbo.fnDateSerial(YEAR(@Date), MONTH(@Date), 1);
END;
GO