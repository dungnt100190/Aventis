SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetNumberOfDaysInMonth;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetNumberOfDaysInMonth.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:40 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get the amount of days in month
    @Date: The date the amount has to be calculated
  -
  RETURNS: Amount of days in selected month
  -
  TEST:    SELECT [dbo].[fnGetNumberOfDaysInMonth]('2008-2-1')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetNumberOfDaysInMonth.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     1.12.08 14:45 Cjaeggi
 * Fixed to VSS-Mode
=================================================================================================*/

CREATE FUNCTION dbo.fnGetNumberOfDaysInMonth
(
  @Date DATETIME
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@Date IS NULL)
  BEGIN
    -- save value for every month
    RETURN 1
  END
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @Month INT
  DECLARE @Year INT
  DECLARE @AmountOfDays INT
  
  SET @Month = MONTH(@Date)
  SET @Year = YEAR(@Date)
  
  -----------------------------------------------------------------------------
  -- get value
  ----------------------------------------------------------------------------- 
  SET @AmountOfDays = CASE WHEN @Month IN (1, 3, 5, 7, 8, 10, 12) THEN 31
                           WHEN @Month IN (4, 6, 9, 11) THEN 30
                           WHEN @Month = 2 THEN CASE WHEN (@Year % 4 = 0 AND @Year % 100 <> 0) OR @Year % 400 = 0 THEN 29
                                                     ELSE 28
                                                END
                      END
  
  -----------------------------------------------------------------------------
  -- done, return value
  ----------------------------------------------------------------------------- 
  RETURN ISNULL(@AmountOfDays, -1)
END
GO