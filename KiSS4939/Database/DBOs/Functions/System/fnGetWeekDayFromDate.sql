SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetWeekDayFromDate;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetWeekDayFromDate.sql $
  $Author: Cjaeggi $
  $Modtime: 1.02.10 11:02 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a formated weekday-name for a specific date
    @Date:         The date to get weekday string from
    @LanguageCode: The language code to use for multilanguage text
    @FormatType:   The format type for output
                   - 'short' = only two chars are used for day
                   - 'long'  = the full name of the day will be returned
  -
  RETURNS: Use this function to get translateable text for database objects. if no text was found
           or invalid parameter were given, '' will be returned.
  -
  TEST:    SELECT dbo.fnGetWeekDayFromDate(GETDATE(), 1, 'short')
           SELECT dbo.fnGetWeekDayFromDate(GETDATE(), 1, 'long')
           --
           SELECT dbo.fnGetWeekDayFromDate(GETDATE(), 2, 'long')
           SELECT dbo.fnGetWeekDayFromDate(GETDATE(), 3, 'long')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetWeekDayFromDate.sql $
 * 
 * 4     1.02.10 11:06 Cjaeggi
 * #5784: BugFix with weekday and weeknumber format
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     5.03.09 13:34 Cjaeggi
 * 
 * 1     5.03.09 13:01 Cjaeggi
 * New function
=================================================================================================*/

CREATE FUNCTION dbo.fnGetWeekDayFromDate
(
  @Date DATETIME,
  @LanguageCode INT,
  @FormatType VARCHAR(10)
)
RETURNS VARCHAR(20)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@Date IS NULL OR @FormatType NOT IN ('short', 'long'))
  BEGIN
    -- invalid parameters, do not continue
    RETURN '';
  END;
  
  -- set default values
  SET @LanguageCode = ISNULL(@LanguageCode, 1);
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @DayNameEnglish VARCHAR(50);
  DECLARE @WeekDayMLMessagename VARCHAR(20);
  
  -----------------------------------------------------------------------------
  -- get weekday from date
  -----------------------------------------------------------------------------
  SET @DayNameEnglish = DATENAME(dw, @Date);
  
  -----------------------------------------------------------------------------
  -- set detail var depending on day-id
  -----------------------------------------------------------------------------
  IF (@FormatType = 'short')
  BEGIN
    -- set var for short day name message
    SET @WeekDayMLMessagename = CASE @DayNameEnglish 
                                  WHEN 'Monday'    THEN 'DayMontagShort'
                                  WHEN 'Tuesday'   THEN 'DayDienstagShort'
                                  WHEN 'Wednesday' THEN 'DayMittwochShort'
                                  WHEN 'Thursday'  THEN 'DayDonnerstagShort'
                                  WHEN 'Friday'    THEN 'DayFreitagShort'
                                  WHEN 'Saturday'  THEN 'DaySamstagShort'
                                  WHEN 'Sunday'    THEN 'DaySonntagShort'
                                END;
  END
  ELSE IF (@FormatType = 'long')
  BEGIN
    -- set var for short day name message
    SET @WeekDayMLMessagename = CASE @DayNameEnglish 
                                  WHEN 'Monday'    THEN 'DayMontagLong'
                                  WHEN 'Tuesday'   THEN 'DayDienstagLong'
                                  WHEN 'Wednesday' THEN 'DayMittwochLong'
                                  WHEN 'Thursday'  THEN 'DayDonnerstagLong'
                                  WHEN 'Friday'    THEN 'DayFreitagLong'
                                  WHEN 'Saturday'  THEN 'DaySamstagLong'
                                  WHEN 'Sunday'    THEN 'DaySonntagLong'
                                END;
  END;
  
  -----------------------------------------------------------------------------
  -- get ml-value and return it
  -----------------------------------------------------------------------------
  RETURN ISNULL(dbo.fnXDbObjectMLMsg('fnGetWeekDayFromDate', @WeekDayMLMessagename, @LanguageCode), '');
END
