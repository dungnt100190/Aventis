SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnKbGetPeriodeIDByDate;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Klientenbuchhaltung/fnKbGetPeriodeIDByDate.sql $
  $Author: Cjaeggi $
  $Modtime: 19.05.10 10:33 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a PeriodeID depending on date values.
           >> only PeriodeStatusCode = 1 (offen)
    @KbMandantID:          The MandatID to use (e.g. BSS Klibu: KbMandantID = 1)
    @PeriodDateFrom:       The first date of a valid period (KbPeriode.PeriodeVon)
    @PeriodDateTo:         The last date of a valid period (KbPeriode.PeriodeBis)
                           This value can be NULL, then the value of @PeriodDateFrom will be taken
    @IfEmptyGetNewestOpen: If no PeriodeID can be found within given date-range, the newest open
                           PeriodeID can be returned (1=give newest if none, 0=get only within range)
  -
  RETURNS: NULL if none was found of invalid, else PeriodeID
  -
  TEST:    SELECT dbo.fnKbGetPeriodeIDByDate(1, '2008-05-01', NULL, 1)
           SELECT dbo.fnKbGetPeriodeIDByDate(1, '2008-05-01', NULL, 0)
           --
           SELECT dbo.fnKbGetPeriodeIDByDate(1, '2007-05-01', NULL, 1)
           SELECT dbo.fnKbGetPeriodeIDByDate(1, '2007-05-01', NULL, 0)
           --
           SELECT dbo.fnKbGetPeriodeIDByDate(2, '2007-05-01', NULL, 1)
           SELECT dbo.fnKbGetPeriodeIDByDate(2, '2007-05-01', NULL, 0)
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Klientenbuchhaltung/fnKbGetPeriodeIDByDate.sql $
 * 
 * 1     19.05.10 10:34 Cjaeggi
 * #5478: Added new function fnKbGetPeriodeIDByDate, modified code
=================================================================================================*/

CREATE FUNCTION dbo.fnKbGetPeriodeIDByDate
(
  @KbMandantID INT,
  @PeriodDateFrom DATETIME,
  @PeriodDateTo DATETIME,
  @IfEmptyGetNewestOpen BIT
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  IF (@KbMandantID IS NULL OR @PeriodDateFrom IS NULL)
  BEGIN
    -- invalid parameters, cannot continue
    RETURN NULL;
  END;

  -- setup vars
  SET @IfEmptyGetNewestOpen = ISNULL(@IfEmptyGetNewestOpen, 0);
  SET @PeriodDateTo = ISNULL(@PeriodDateTo, @PeriodDateFrom);
  
  -- only date is important, reset time
  SET @PeriodDateFrom = dbo.fnDateOf(@PeriodDateFrom);
  SET @PeriodDateTo   = dbo.fnDateOf(@PeriodDateTo);
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @KbPeriodeID INT;
  
  -----------------------------------------------------------------------------
  -- get KbPeriodeID
  -----------------------------------------------------------------------------
  -- try to get value within range
  SELECT TOP 1 @KbPeriodeID = KbPeriodeID
  FROM dbo.KbPeriode WITH (READUNCOMMITTED) 
  WHERE KbMandantID = @KbMandantID
    AND PeriodeStatusCode = 1          -- only open periods
    AND PeriodeVon <= @PeriodDateFrom
    AND PeriodeBis >= @PeriodDateTo
  ORDER BY PeriodeVon;
  
  -- check if need to get newest open
  IF (@KbPeriodeID IS NULL AND @IfEmptyGetNewestOpen = 1)
  BEGIN
    -- Falls keine Periode in Zeitraum vorhanden --> jüngste offene Periode für Mandant
    SELECT TOP 1 
           @KbPeriodeID = KbPeriodeID
    FROM dbo.KbPeriode WITH (READUNCOMMITTED) 
    WHERE KbMandantID = @KbMandantID
      AND PeriodeStatusCode = 1        -- only open periods
    ORDER BY PeriodeVon DESC;
  END;
  
  -----------------------------------------------------------------------------
  -- done, return NULL or value found
  -----------------------------------------------------------------------------
  RETURN @KbPeriodeID;
END;
GO
