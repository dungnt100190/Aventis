SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBDEGetFerienZugabenKuerzungen;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetFerienZugabenKuerzungen.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:14 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get Ferienzugaben/Kuerzungen per specified date.
    @UserID:   The user to get data from
    @Date:     The date the date has to be calculated to.
    @OnlyYear: 1=get value only for current year, 0=get value until current year
  -
  RETURNS: (+/-) hours of Feriensaldo from the beginning to @Date
  -
  TEST:    SELECT dbo.[fnBDEGetFerienZugabenKuerzungen](1137, '2009-02-01', 0)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetFerienZugabenKuerzungen.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     18.09.08 11:42 Cjaeggi
 * Test-Statement hinzugefügt, case-fixing...
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetFerienZugabenKuerzungen
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
  IF (@Date IS NULL)
  BEGIN
    RETURN 0
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @YearOfDate INT
  DECLARE @FerienZugabenKuerzungen MONEY

  SET @YearOfDate = DATEPART(YEAR, @Date)

  -----------------------------------------------------------------------------
  -- get FerienZugabenKuerzungen
  -----------------------------------------------------------------------------
  IF (@OnlyYear = 1)
  BEGIN
    -- get value only for current year
    SELECT @FerienZugabenKuerzungen = SUM(FEK.FerienkuerzungStd)
    FROM dbo.BDEFerienkuerzungen_XUser FEK WITH (READUNCOMMITTED)
    WHERE FEK.UserID = @UserID AND
          FEK.Jahr = @YearOfDate
  END
  ELSE
  BEGIN
    -- get value until and with current year
    SELECT @FerienZugabenKuerzungen = SUM(FEK.FerienkuerzungStd)
    FROM dbo.BDEFerienkuerzungen_XUser FEK WITH (READUNCOMMITTED)
    WHERE FEK.UserID = @UserID AND
          FEK.Jahr <= @YearOfDate
  END

  -----------------------------------------------------------------------------
  -- calculate and return total value
  -----------------------------------------------------------------------------  
  RETURN ISNULL(@FerienZugabenKuerzungen, 0)
END
GO