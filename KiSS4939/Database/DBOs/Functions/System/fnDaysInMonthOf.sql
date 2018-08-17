SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnDaysInMonthOf;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnDaysInMonthOf.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 9:36 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get the number of days in month.
    @DateValue: The date to use for getting amount of days
  -
  RETURNS: Amount of days in given month
  -
  TEST:    SELECT dbo.fnDaysInMonthOf(GETDATE());
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnDaysInMonthOf.sql $
 * 
 * 3     17.03.10 9:37 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnDaysInMonthOf
(
  @DateValue DATETIME
)
RETURNS INT
AS BEGIN
  RETURN 1 + DATEDIFF(DAY, dbo.fnFirstDayOf(@DateValue), dbo.fnLastDayOf(@DateValue));
END;
GO