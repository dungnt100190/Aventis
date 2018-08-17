SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEIsMonatFreigegeben;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEIsMonatFreigegeben.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:25 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to check if month is already freigegeben
    @UserID: The user to get data from
    @Date:   The date to check month from
  -
  RETURNS: True if month is already freigegeben
  -
  TEST:    SELECT [dbo].[fnBDEIsMonatFreigegeben](2, '2007-11-6')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEIsMonatFreigegeben.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEIsMonatFreigegeben
(
  @UserID INT,
  @Date datetime
)
RETURNS BIT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@UserID IS NULL OR @Date IS NULL)
  BEGIN
    RETURN 0
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @MonthOfDate INT
  DECLARE @YearOfDate INT
  DECLARE @Counts INT

  SET @MonthOfDate = MONTH(@Date)
  SET @YearOfDate = YEAR(@Date)

  -----------------------------------------------------------------------------
  -- get value
  ----------------------------------------------------------------------------- 
  SELECT @Counts = COUNT(1)
  FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
  WHERE LEI.UserID = @UserID AND
		LEI.Freigegeben = 1 AND
		LEI.Datum >= dbo.fnGetDateFromInts(1, @MonthOfDate, @YearOfDate) AND
		LEI.Datum <= dbo.fnGetDateFromInts(dbo.fnGetNumberOfDaysInMonth(@Date), @MonthOfDate, @YearOfDate)

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN CASE WHEN IsNull(@Counts, 0) > 0 THEN 1 ELSE 0 END
END
GO