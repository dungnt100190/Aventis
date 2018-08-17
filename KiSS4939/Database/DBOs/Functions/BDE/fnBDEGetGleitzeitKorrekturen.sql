SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetGleitzeitKorrekturen;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetGleitzeitKorrekturen.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:15 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get Gleitzeitkorrekturen within BDELeistung
    @UserID:    The user to get data from
    @Date:      The date the data has to be calculated to.
    @OnlyYear:  1=get value only for current year, 0=get value until date
  -
  RETURNS: (+/-) hours of corrections depending on given parameters
  -
  TEST:    SELECT [dbo].[fnBDEGetGleitzeitKorrekturen](515, '2008-05-31', 1)
           SELECT [dbo].[fnBDEGetGleitzeitKorrekturen](689, GETDATE(), 0)
           SELECT [dbo].[fnBDEGetGleitzeitKorrekturen](567, GETDATE(), 0)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetGleitzeitKorrekturen.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     18.09.08 11:45 Cjaeggi
 * Test-Statements eingefügt, CaseFixes
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetGleitzeitKorrekturen
(
  @UserID INT,
  @Date DATETIME,
  @OnlyYear BIT
)
RETURNS MONEY
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@Date IS NULL OR @UserID IS NULL)
  BEGIN
    RETURN 0
  END

  -- set bit value
  SET @OnlyYear = ISNULL(@OnlyYear, 0)

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @FirstDayOfYear DATETIME
  DECLARE @GleitzeitKorrekturen MONEY

  -- get first day of year
  SET @FirstDayOfYear = dbo.fnGetDateFromInts(1, 1, YEAR(@Date))

  -----------------------------------------------------------------------------
  -- get corrected entries
  -----------------------------------------------------------------------------
  IF (@OnlyYear = 1)
  BEGIN
    ---------------------------------------------------------------------------
    -- get value only for current year
    -- (1=Gleitzeitsaldo; 2=Gleitzeitkorrektur; 3=Feriensaldo, 4=Ferienkorrektur, 5=Stunden-Import)
    ---------------------------------------------------------------------------
    SELECT @GleitzeitKorrekturen = SUM(LEI.Dauer)
    FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
      INNER JOIN dbo.BDELeistungsart ART WITH (READUNCOMMITTED) ON ART.BDELeistungsartID = LEI.BDELeistungsartID AND 
                                                                   ART.LeistungsartTypCode = 2
    WHERE LEI.UserID = @UserID AND
          LEI.Datum BETWEEN @FirstDayOfYear AND @Date
  END
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- get value from past to given date
    -- (1=Gleitzeitsaldo; 2=Gleitzeitkorrektur; 3=Feriensaldo, 4=Ferienkorrektur, 5=Stunden-Import)
    ---------------------------------------------------------------------------
    SELECT @GleitzeitKorrekturen = SUM(LEI.Dauer)
    FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
      INNER JOIN dbo.BDELeistungsart ART WITH (READUNCOMMITTED) ON ART.BDELeistungsartID = LEI.BDELeistungsartID AND 
                                                                   ART.LeistungsartTypCode = 2
    WHERE LEI.UserID = @UserID AND
          LEI.Datum <= @Date
  END

  -----------------------------------------------------------------------------
  -- validate and return value
  -----------------------------------------------------------------------------  
  RETURN ISNULL(@GleitzeitKorrekturen, 0)
END
GO