SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetWeekDayFromDate;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetWeekDayFromDate.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:24 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a short weekday-name for the given date
    @Date:         The date to get weekday name in short format from
    @LanguageCode: The language code to use for multilanguage text
  -
  RETURNS: Use this function to get translateable text for database objects. if no text was found
           or invalid parameter were given, '' will be returned.
  -
  TEST:    SELECT dbo.fnBDEGetWeekDayFromDate(GETDATE(), 1)
           SELECT dbo.fnBDEGetWeekDayFromDate(GETDATE(), 2)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetWeekDayFromDate.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     5.03.09 13:00 Cjaeggi
 * Changed code to new function call dbo.fnGetWeekDayFromDate(), formating
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetWeekDayFromDate
(
  @Date datetime,
  @LanguageCode INT
)
RETURNS varchar(10)
AS BEGIN
  -----------------------------------------------------------------------------
  -- return value from other function call
  -----------------------------------------------------------------------------
  RETURN dbo.fnGetWeekDayFromDate(@Date, @LanguageCode, 'short')
END
GO