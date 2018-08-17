SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetDateFromInts;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetDateFromInts.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:37 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a date from separated values 
    @Day:      The day to use
    @Month:    The month to use
    @Year:     The year to use
  -
  RETURNS: Date created from values
  -
  TEST:    SELECT [dbo].fnGetDateFromInts(1, 2, 2008)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetDateFromInts.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:40 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetDateFromInts
(
  @Day INT,
  @Month INT,
  @Year INT
)
RETURNS datetime
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if no or invalid values are passed, do not return a date
  IF (@Day IS NULL OR @Day < 1 OR @Day > 31 OR @Month IS NULL OR @Month < 1 OR @Month > 12 OR @Year IS NULL OR @Year < 1753)
  BEGIN
    -- save value for every month
    RETURN NULL
  END

  -----------------------------------------------------------------------------
  -- create date
  -----------------------------------------------------------------------------
  RETURN CONVERT(datetime, CONVERT(varchar, @Day)+'.'+CONVERT(varchar, @Month)+'.'+CONVERT(varchar, @Year), 104)
END
GO