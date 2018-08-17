SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetSollProMonat;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetSollProMonat.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:23 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this function to get Sollstunden per specified month.
    @UserID: The user to get data from
    @Date:   The date the soll has to be calculated to.
  -
  RETURNS: Hours of Sollstunden for the specified month
  -
  TEST:    SELECT [dbo].[fnBDEGetSollProMonat](2, '2007-2-1')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetSollProMonat.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetSollProMonat
(
  @UserID INT,
  @Date datetime
)
RETURNS money
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@Date IS NULL)
  BEGIN
    RETURN -1
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @Sollstunden money
  DECLARE @MonthOfDate INT
  DECLARE @YearOfDate INT
  DECLARE @PensumPercent INT

  SET @MonthOfDate = DatePart(MONTH, @Date)
  SET @YearOfDate = DatePart(YEAR, @Date)
  SET @PensumPercent = dbo.fnBDEGetPensumPercent(@UserID, @Date)

  -----------------------------------------------------------------------------
  -- revalidate
  -----------------------------------------------------------------------------
  IF (@PensumPercent = 0)
  BEGIN
    -- no pensum, return 0 due to no calculable value
    RETURN 0
  END

  -----------------------------------------------------------------------------
  -- get Sollstunden
  ----------------------------------------------------------------------------- 
  SELECT @Sollstunden = CASE WHEN @MonthOfDate = 1 THEN SPY.JanuarStd
                             WHEN @MonthOfDate = 2 THEN SPY.FebruarStd
                             WHEN @MonthOfDate = 3 THEN SPY.MaerzStd
                             WHEN @MonthOfDate = 4 THEN SPY.AprilStd
                             WHEN @MonthOfDate = 5 THEN SPY.MaiStd
                             WHEN @MonthOfDate = 6 THEN SPY.JuniStd
                             WHEN @MonthOfDate = 7 THEN SPY.JuliStd
                             WHEN @MonthOfDate = 8 THEN SPY.AugustStd
                             WHEN @MonthOfDate = 9 THEN SPY.SeptemberStd
                             WHEN @MonthOfDate = 10 THEN SPY.OktoberStd
                             WHEN @MonthOfDate = 11 THEN SPY.NovemberStd
                             WHEN @MonthOfDate = 12 THEN SPY.DezemberStd
                             ELSE 0
                         END
  FROM dbo.BDESollStundenProJahr_XUser SPY WITH (READUNCOMMITTED)
  WHERE SPY.UserID = @UserID AND
        SPY.Jahr = @YearOfDate

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN IsNull(@Sollstunden * @PensumPercent/100, 0)
END
GO