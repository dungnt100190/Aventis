SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetSecondsFromDateTime;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetSecondsFromDateTime.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:41 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Convert the given time date-independently to seconds
    @TimeToConvert: The time to convert to seconds within given date (date is not important)
  -
  RETURNS: The seconds of the given time
  -
  TEST:    SELECT dbo.fnGetSecondsFromDateTime('2008-12-18 00:00:00')
           SELECT dbo.fnGetSecondsFromDateTime('2008-12-18 01:00:00')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetSecondsFromDateTime.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     18.12.08 13:08 Cjaeggi
 * First version
=================================================================================================*/

CREATE FUNCTION dbo.fnGetSecondsFromDateTime
(
  @TimeToConvert DATETIME
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if no text is passed, return null
  IF (@TimeToConvert IS NULL)
  BEGIN
    -- invalid value
    RETURN NULL
  END
  
  -----------------------------------------------------------------------------
  -- convert to seconds
  -----------------------------------------------------------------------------
  RETURN (DATEPART(hh, @TimeToConvert) * 3600 + DATEPART(n, @TimeToConvert) * 60 + DATEPART(s, @TimeToConvert))
END
GO 