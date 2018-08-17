SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetErfassteFerien;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetErfassteFerien.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:13 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get inserted holidays within database
    @UserID:   The user to get data from
    @Date:     The date the data has to be calculated to.
    @OnlyYear: 1=get value only for current year, 0=get value until date
  -
  RETURNS: (+/-) hours of inserted holidays depending on given parameters
  -
  TEST:    SELECT [dbo].[fnBDEGetErfassteFerien](2, '2008-05-31', 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetErfassteFerien.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetErfassteFerien
(
  @UserID INT,
  @Date datetime,
  @OnlyYear BIT
)
RETURNS money
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
  DECLARE @ErfassteFerien MONEY

  -- get first day of year
  SET @FirstDayOfYear = dbo.fnGetDateFromInts(1, 1, YEAR(@Date))

  -----------------------------------------------------------------------------
  -- get inserted holidays
  -----------------------------------------------------------------------------
  IF (@OnlyYear = 1)
  BEGIN
    ---------------------------------------------------------------------------
    -- get value only for current year
    -- (1=Gleitzeitsaldo; 2=Gleitzeitkorrektur; 3=Feriensaldo, 4=Ferienkorrektur, 5=Stunden-Import)
    ---------------------------------------------------------------------------
    SELECT @ErfassteFerien = SUM(LEI.Dauer)
    FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
      INNER JOIN dbo.BDELeistungsart ART WITH (READUNCOMMITTED) ON ART.BDELeistungsartID = LEI.BDELeistungsartID AND 
                                        ART.LeistungsartTypCode = 3
    WHERE LEI.UserID = @UserID AND
          LEI.Datum BETWEEN @FirstDayOfYear AND @Date
  END
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- get value from past to given date
    -- (1=Gleitzeitsaldo; 2=Gleitzeitkorrektur; 3=Feriensaldo, 4=Ferienkorrektur, 5=Stunden-Import)
    ---------------------------------------------------------------------------
    SELECT @ErfassteFerien = SUM(LEI.Dauer)
    FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
      INNER JOIN dbo.BDELeistungsart ART WITH (READUNCOMMITTED) ON ART.BDELeistungsartID = LEI.BDELeistungsartID AND 
                                        ART.LeistungsartTypCode = 3
    WHERE LEI.UserID = @UserID AND
          LEI.Datum <= @Date
  END

  -----------------------------------------------------------------------------
  -- validate and return value
  -----------------------------------------------------------------------------  
  RETURN IsNull(@ErfassteFerien, 0)
END
GO