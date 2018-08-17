SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetNextExportMonth;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetNextExportMonth.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:21 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get next possible month to export data
    @MandantenNr:   The MandantenNr to use for checking
    @Schnittstelle: The type of the call: 'stunden'=Stundenlohn (default), 'leistung'=Leistungsdaten
  -
  RETURNS: The first date of the first possible month to export or NULL if error
  -
  TEST:    SELECT [dbo].[fnBDEGetNextExportMonth](1, 'stunden')
           SELECT [dbo].[fnBDEGetNextExportMonth](1, 'leistung')
           SELECT [dbo].[fnBDEGetNextExportMonth](181, 'stunden')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetNextExportMonth.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     27.08.09 13:00 Spsota
 * #4835 ZLE Performance verbesserungen
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetNextExportMonth
(
  @MandantenNr INT,
  @Schnittstelle varchar(10)
)
RETURNS datetime
AS BEGIN
  -----------------------------------------------------------------------------
  -- debug
  -----------------------------------------------------------------------------
  /*
  DECLARE @MandantenNr INT
  DECLARE @Schnittstelle varchar(10)
  SET @MandantenNr = 1
  SET @Schnittstelle = 'stunden'
  */

  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@MandantenNr IS NULL OR @Schnittstelle IS NULL)
  BEGIN
    RETURN NULL
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @StartDateZLE datetime
  DECLARE @LastUsedDate datetime
  DECLARE @FirstDateOfNextMonth datetime
  

  -- default value for start date
  SET @StartDateZLE = IsNull(@StartDateZLE, CONVERT(datetime, '1.1.2008', 104))

  -----------------------------------------------------------------------------
  -- get last used date for MandantenNr which is Verbucht
  ----------------------------------------------------------------------------- 
  IF (@Schnittstelle = 'leistung')
  BEGIN
    -----------------------------------------------------------------------------
    -- Leistungsdaten-Schnittstelle
    -----------------------------------------------------------------------------
    -- get last used date including bulk visum entries
    SELECT @LastUsedDate = MAX(LEI.Datum)
    FROM dbo.BDELeistung LEI
    WHERE LEI.Verbucht IS NOT NULL AND
          LEI.VerbuchtLD IS NOT NULL AND
          LEI.HistMandantNr = @MandantenNr
  END
  ELSE IF (@Schnittstelle = 'stunden')
  BEGIN
    -----------------------------------------------------------------------------
    -- Stundenlohn-Schnittstelle
    -----------------------------------------------------------------------------
    -- get last used date including bulk visum entries
    SELECT @LastUsedDate = MAX(LEI.Datum)
    FROM dbo.BDELeistung LEI
    WHERE LEI.Verbucht IS NOT NULL AND
          LEI.HistMandantNr = @MandantenNr
  END
  ELSE
  BEGIN
    -- unknown interface, cannot continue
    RETURN NULL
  END

  -----------------------------------------------------------------------------
  -- calculate first day of next month
  ----------------------------------------------------------------------------- 
  -- check if we have a valid date
  IF (@LastUsedDate IS NULL OR @LastUsedDate < @StartDateZLE)
  BEGIN
    -- no entries yet, use first possible date from settings
    SET @FirstDateOfNextMonth = @StartDateZLE
  END
  ELSE
  BEGIN
    -- calulate next month-first-day-date
    SET @FirstDateOfNextMonth = DateAdd(month, 1, dbo.fnGetDateFromInts(1, MONTH(@LastUsedDate), YEAR(@LastUsedDate)))
  END

  -----------------------------------------------------------------------------
  -- return value (NULL if error)
  ----------------------------------------------------------------------------- 
  --PRINT ('@FirstDateOfNextMonth='+ISNULL(CONVERT(VARCHAR(100), @FirstDateOfNextMonth), 'null'))
  RETURN @FirstDateOfNextMonth
END
GO