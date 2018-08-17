SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnLastDayOf;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnLastDayOf.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:44 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get last day in month
    @ Date:      The date to get last day of its month
  -
  RETURNS: Date of last day of given month and year or NULL if invalid
  -
  TEST:    SELECT [dbo].[fnLastDayOf]('2008-01-01')
           SELECT [dbo].[fnLastDayOf]('2008-02-04')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnLastDayOf.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:41 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnLastDayOf
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
    RETURN NULL
  END

  -----------------------------------------------------------------------------
  -- calculate and return value
  -----------------------------------------------------------------------------
  RETURN (DATEADD(d, -1, DATEADD(m, 1, dbo.fnFirstDayOf(@Date))))
END
GO