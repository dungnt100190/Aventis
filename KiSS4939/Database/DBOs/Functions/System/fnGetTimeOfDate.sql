SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetTimeOfDate;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetTimeOfDate.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:43 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get hours and minutes from given date
   @Date:       The date to get hours and minutes from as HH:MM
   @AppendZero: 1=even an hour < 10 will be two digits
                0=hours within 0-9 will be one digit, otherwise two digits
  -
  RETURNS: Hours and minutes from given date
  -
  TEST:    SELECT [dbo].[fnGetTimeOfDate](GETDATE(), 0)
           SELECT [dbo].[fnGetTimeOfDate](GETDATE(), 1)
           --
           SELECT [dbo].[fnGetTimeOfDate]('2009-01-01 01:01:00.222', 0)
           SELECT [dbo].[fnGetTimeOfDate]('2009-01-01 01:01:00.222', 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetTimeOfDate.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     5.03.09 13:33 Cjaeggi
 * New function
=================================================================================================*/

CREATE FUNCTION dbo.fnGetTimeOfDate
(
  @Date DATETIME,
  @AppendZero BIT
)
RETURNS VARCHAR(5)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@Date IS NULL)
  BEGIN
    -- invalid date, cannot return valid date
    RETURN ''
  END
  
  -- set bit default
  SET @AppendZero = ISNULL(@AppendZero, 1) -- by default, append zero
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @Hours INT
  DECLARE @Minutes INT
  
  DECLARE @HoursVarchar VARCHAR(2)
  DECLARE @MinutesVarchar VARCHAR(2)  
  
  -----------------------------------------------------------------------------
  -- get hours and minutes and setup vars
  -----------------------------------------------------------------------------
  -- get hours and minutes
  SET @Hours = DATEPART(hh, @Date)
  SET @Minutes = DATEPART(mi, @Date)
  
  -- set hours depending on @AppendZero
  SET @HoursVarchar = CASE WHEN @AppendZero = 1 AND @Hours < 10 THEN '0' + CONVERT(VARCHAR, @Hours)
                           ELSE CONVERT(VARCHAR, @Hours)
                      END
                      
  -- set minutes (always to digits)
  SET @MinutesVarchar = CASE WHEN @Minutes < 10 THEN '0' + CONVERT(VARCHAR, @Minutes)
                             ELSE CONVERT(VARCHAR, @Minutes)
                        END
  
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN ISNULL(@HoursVarchar + ':' + @MinutesVarchar, '')
END
