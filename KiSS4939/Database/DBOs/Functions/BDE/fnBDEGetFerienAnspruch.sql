SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetFerienAnspruch;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetFerienAnspruch.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:13 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get Feriensaldo per specified date.
    @UserID:    The user to get data from
    @Date:      The date the soll has to be calculated to.
    @OnlyYear:  1=get value only for current year, 0=get value until current year
  -
  RETURNS: (+/-) hours of Feriensaldo from the beginning to @Date
  -
  TEST:    SELECT [dbo].[fnBDEGetFerienAnspruch](2, '2007-10-11', 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetFerienAnspruch.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetFerienAnspruch
(
  @UserID INT,
  @Date datetime,
  @OnlyYear BIT
)
RETURNS money
AS BEGIN
  -----------------------------------------------------------------------------
  -- debug
  -----------------------------------------------------------------------------
  /*
  DECLARE @UserID INT
  DECLARE @Date DATETIME
  DECLARE @OnlyYear BIT

  SET @UserID = 859
  SET @Date = '2008-04-01'
  SET @OnlyYear = 1
  */

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
  DECLARE @Ferienanspruch money

  SET @YearOfDate = DatePart (YEAR, @Date)

  -----------------------------------------------------------------------------
  -- get Ferienanspruch
  -----------------------------------------------------------------------------
  IF (@OnlyYear = 1)
  BEGIN
    ---------------------------------------------------------------------------
    -- get value only for current year (mostly depending on DatumVon)
    ---------------------------------------------------------------------------
    SELECT TOP 1 @Ferienanspruch = FAN.FerienanspruchStdProJahr
    FROM dbo.BDEFerienanspruch_XUser FAN WITH (READUNCOMMITTED)
    WHERE FAN.UserID = @UserID AND 
          FAN.Jahr = @YearOfDate AND
          FAN.DatumVon <= @Date AND
         (FAN.DatumBis IS NULL OR FAN.DatumBis >= @Date)
    ORDER BY FAN.DatumVon DESC, FAN.BDEFerienanspruch_XUserID DESC
  END
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- get value until and with current year
    ---------------------------------------------------------------------------
    -- init temp table
    DECLARE @Result TABLE
    (
      Jahr INT NOT NULL,
      VergleichDatum DATETIME NOT NULL,
      FerienanspruchStdProJahr MONEY
    )

    -- fill all years to date that are to sum up
    INSERT INTO @Result (Jahr, VergleichDatum)
      SELECT DISTINCT 
             FAN.Jahr,
             CASE WHEN (FAN.Jahr < @YearOfDate) THEN CONVERT(datetime, '31.12.'+CONVERT(varchar, FAN.Jahr), 104)
                  ELSE @Date
             END
      FROM dbo.BDEFerienanspruch_XUser FAN WITH (READUNCOMMITTED)
      WHERE FAN.UserID = @UserID AND
            FAN.Jahr <= @YearOfDate

    -- update values
    UPDATE RES
    SET FerienanspruchStdProJahr = dbo.fnBDEGetFerienAnspruch(@UserID, RES.VergleichDatum, 1)
    FROM @Result RES

    -- get value
    SELECT @Ferienanspruch = SUM(RES.FerienanspruchStdProJahr)
    FROM @Result RES
  END

  -----------------------------------------------------------------------------
  -- calculate and return total saldo
  -----------------------------------------------------------------------------  
  RETURN IsNull(@Ferienanspruch, 0)
END
GO