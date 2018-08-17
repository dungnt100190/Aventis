SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetGleitzeitSaldo;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get Gleitzeitsaldo per specified date.
    @UserID:  The user to get data from
    @Date:    The date the Saldo has to be calculated to.
  -
  RETURNS: (+/-) hours of Gleitzeitsaldo from the beginning to @Date / XUser.Austrittsdatum
  -
  TEST:    SELECT dbo.[fnBDEGetGleitzeitSaldo](2, '2007-02-01')
=================================================================================================
*/

CREATE FUNCTION dbo.fnBDEGetGleitzeitSaldo
(
  @UserID INT,
  @Date DATETIME
)
RETURNS MONEY
AS BEGIN
  -----------------------------------------------------------------------------
  -- DEBUG
  -----------------------------------------------------------------------------
  /*
  DECLARE @UserID INT
  DECLARE @Date DATETIME
  SET @UserID = 2
  SET @Date = CONVERT(DATETIME, '01.12.2006', 104)
  */

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @StartDateZLE DATETIME;
  DECLARE @LeistungenTotal MONEY;
  DECLARE @SollProMonat MONEY;
  DECLARE @SollProMonatSumme MONEY;
  DECLARE @Year INT;
  DECLARE @Month INT;
  DECLARE @LastDateOfMonth DATETIME;
  DECLARE @AusbezahlteUeberzeitTotal MONEY;
  DECLARE @Austrittsdatum DATETIME;
  DECLARE @DateSollzeit DATETIME;
  -----------------------------------------------------------------------------
  -- calculate and setup date vars
  -----------------------------------------------------------------------------  
  -- get config value
  SELECT TOP 1 @StartDateZLE = CON.ValueDateTime
  FROM dbo.XConfig CON WITH (READUNCOMMITTED)
  WHERE CON.KeyPath = 'System\ZLE\StartdatumFuerBerechnungen'
  ORDER BY CON.DatumVon DESC;

  -- default value for start date
  SET @StartDateZLE = ISNULL(@StartDateZLE, CONVERT(DATETIME, '1.1.2008', 104));

  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@Date IS NULL OR @Date < @StartDateZLE)
  BEGIN
    RETURN 0;
    --DEBUG: PRINT('error date')
  END;

  -- get values
  SET @Year = YEAR(@StartDateZLE);
  SET @Month = MONTH(@StartDateZLE);

  -- correct date to last day of month
  SET @Date = dbo.fnLastDayOf(@Date);

  -- Grundsätzlich soll die Sollzeit auch bis zum aktuellen Datum berücksichtigt werden
  SET @DateSollzeit = @Date;

  -- ausser: wenn das Austrittsdatum bereits vergangen ist
  SELECT @Austrittsdatum = Austrittsdatum
  FROM dbo.XUser WITH(READUNCOMMITTED)
  WHERE UserID = @UserID;

  IF (@Austrittsdatum IS NOT NULL AND @Austrittsdatum < @Date)
  BEGIN
    SET @DateSollzeit = dbo.fnLastDayOf(@Austrittsdatum);
  END;

  -- setup default values
  SET @SollProMonatSumme = 0;

  -----------------------------------------------------------------------------
  -- get sum of Leistungen until end of month of given date
  -- (1=Gleitzeitsaldo; 2=Gleitzeitkorrektur; 3=Feriensaldo, 4=Ferienkorrektur, 5=Stunden-Import)
  -----------------------------------------------------------------------------
  SELECT @LeistungenTotal = SUM(LEI.Dauer)
  FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
    INNER JOIN dbo.BDELeistungsart ART WITH (READUNCOMMITTED) ON ART.BDELeistungsartID = LEI.BDELeistungsartID AND 
                                                                 ART.LeistungsartTypCode IN (1, 2, 3, 5)
  WHERE LEI.UserID = @UserID
    AND LEI.Datum <= @Date
    AND ISNULL(LohnartCode, -1) < 0  -- only where we have monatslohn

  -- validate
  SET @LeistungenTotal = ISNULL(@LeistungenTotal, 0);

  -----------------------------------------------------------------------------
  -- get ausbezahlte Ueberzeit total for all years and till current date
  -----------------------------------------------------------------------------
  SET @AusbezahlteUeberzeitTotal = dbo.fnBDEGetAusbezahlteUeberstunden(@UserID, @Date, 0);

  -----------------------------------------------------------------------------
  -- get Gleitzeitsaldo
  -----------------------------------------------------------------------------
  -- loop year and month until we reach date given
  WHILE (1 = 1)
  BEGIN
    -- calculate last-day-of-month-date of current month
    SET @LastDateOfMonth = dbo.fnLastDayOf(dbo.fnGetDateFromInts(1, @Month, @Year));

    -- check if we need to stop here (only calculate sollzeit while LastDateOfMonth <= DateSollzeit)
    IF (@LastDateOfMonth > @DateSollzeit)
    BEGIN
      -- do not continue, we are in month above month of @Date
      BREAK;
    END;

    -- get soll pro monat of current month
    SET @SollProMonat = dbo.fnBDEGetSollProMonat(@UserID, @LastDateOfMonth);
  --DEBUG: PRINT('@SollProMonat='+ISNULL(CONVERT(VARCHAR, @SollProMonat), 'err'))

    -- validate values
    IF (@SollProMonat IS NOT NULL)
    BEGIN
      -- valid values, calculate values
      SET @SollProMonatSumme = @SollProMonatSumme + @SollProMonat;
    END;

    -- count up month and year
    SET @Month = @Month + 1;
    
    -- check if end of year
    IF (@Month > 12)
    BEGIN
      -- reached end of year, goto new year
      SET @Month = 1;
      SET @Year = @Year + 1;
    END;
  END;

  -----------------------------------------------------------------------------
  -- validate and return total saldo
  -----------------------------------------------------------------------------  
  RETURN ISNULL(@LeistungenTotal - @SollProMonatSumme - @AusbezahlteUeberzeitTotal, 0);
  --DEBUG: PRINT('output='+CONVERT(VARCHAR(50), ISNULL(@LeistungenTotal - @SollProMonatSumme - @AusbezahlteUeberzeitTotal, 0)))
END
GO