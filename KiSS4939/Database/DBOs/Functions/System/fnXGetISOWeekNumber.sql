SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXGetISOWeekNumber;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnXGetISOWeekNumber.sql $
  $Author: Cjaeggi $
  $Modtime: 1.02.10 10:34 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get the ISO week number for given date (sql-server 2005 cannot handle this automatically)
           See: http://www.rmjcs.com/SQLServer/TSQLFunctions/ISOWeekNumber/tabid/207/Default.aspx
    @Date: The date used for getting the ISO week number
  -
  RETURNS: The ISO week number for given date.
  -
  TEST:    SELECT dbo.fnXGetISOWeekNumber(GETDATE());
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnXGetISOWeekNumber.sql $
 * 
 * 1     1.02.10 11:06 Cjaeggi
 * #5784: BugFix with weekday and weeknumber format
=================================================================================================*/

CREATE FUNCTION dbo.fnXGetISOWeekNumber
(
  @Date DATETIME
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@Date IS NULL)
  BEGIN
    -- empty date, return NULL
    RETURN NULL;
  END;

  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @ISOWeekdayNumber INT;
  DECLARE @DateThisThursday DATETIME;
  DECLARE @DateFirstOfThisThursdaysYear DATETIME;
  DECLARE @ISOWeekdayNumberOfFirstOfThisThursdaysYear INT;
  DECLARE @DateFirstThursdayOfYear DATETIME;
  DECLARE @ISOWeekNumber INT;
  
  -----------------------------------------------------------------------------
  -- do the calculation
  -----------------------------------------------------------------------------
  -- get the ISO week day number (Monday = 1) for our date.
  SET @ISOWeekdayNumber = (((DATEPART(dw, @Date) - 1) + (@@DATEFIRST - 1)) % 7) + 1;

  -- get the date of the Thursday in this ISO week.
  SET @DateThisThursday = DATEADD(d, (4 - @ISOWeekdayNumber), @Date);

  -- get the date of the 1st January for 'this Thursdays' year.
  SET @DateFirstOfThisThursdaysYear = CAST(CAST(YEAR(@DateThisThursday) AS CHAR(4)) + '-01-01' AS DATETIME);
  
  SET @ISOWeekdayNumberOfFirstOfThisThursdaysYear = (((DATEPART(dw, @DateFirstOfThisThursdaysYear) - 1) + (@@DATEFIRST - 1)) % 7) + 1;

  -- get the date of the first Thursday in 'this Thursdays' year.
  -- the year of which the ISO week is a part is the year of this date.
  IF (@ISOWeekdayNumberOfFirstOfThisThursdaysYear IN (1, 2, 3, 4))
  BEGIN
    SET @DateFirstThursdayOfYear = DATEADD(d, (4 - @ISOWeekdayNumberOfFirstOfThisThursdaysYear), @DateFirstOfThisThursdaysYear);
  END
  ELSE
  BEGIN
    SET @DateFirstThursdayOfYear = DATEADD(d, (4 - @ISOWeekdayNumberOfFirstOfThisThursdaysYear + 7), @DateFirstOfThisThursdaysYear);
  END;
  
  -- work out how many weeks from the first Thursday to this Thursday.
  SET @ISOWeekNumber = DATEDIFF(d, @DateFirstThursdayOfYear, @DateThisThursday) / 7 + 1;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN @ISOWeekNumber;
END;
GO
