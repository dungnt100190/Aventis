SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKbCheckBelegDatum
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnKbCheckBelegDatum.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 15:59 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnKbCheckBelegDatum.sql $
 * 
 * 3     24.06.09 16:20 Ckaeser
 * Alter2Create
 * 
 * 2     4.11.08 19:22 dmast
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnKbCheckBelegDatum
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:57
*/
-------------------------------------------------------------------------------
-- CALL:              Use this function to validate given BelegDatum.
--                    >> BelegDatum is valid if it is within specified date range of Periode and
--                       Periode has to be active
--   KbPeriodeID:       The PeriodeID to use for validation of BelegDatum
--   BelegDatum:        The BelegDatum to validate with given PeriodeID
-- RETURNS:           1 = valid, 0 = invalid
-- 
-- TEST: SELECT dbo.fnKbCheckBelegDatum](36, '2008-01-01')
--       SELECT dbo.fnKbCheckBelegDatum](36, '2008-04-01')
--       SELECT dbo.fnKbCheckBelegDatum](36, '2008-12-31')
--       SELECT dbo.fnKbCheckBelegDatum](36, '2009-01-01')
-------------------------------------------------------------------------------
CREATE FUNCTION dbo.fnKbCheckBelegDatum
(
  @KbPeriodeID INT,
  @BelegDatum datetime
)
RETURNS BIT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  IF (@KbPeriodeID IS NULL OR @BelegDatum IS NULL)
  BEGIN
    -- invalid parameters
    RETURN 0
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @DateCheckBegin datetime
  DECLARE @DateCheckEnd datetime

  -----------------------------------------------------------------------------
  -- get check dates
  -----------------------------------------------------------------------------
  SELECT @DateCheckBegin = IsNull(VerbuchtBis, PeriodeVon), -- if VerbuchtBis is set, take this date for begin
         @DateCheckEnd = PeriodeBis
  FROM dbo.KbPeriode WITH (READUNCOMMITTED) 
  WHERE KbPeriodeID = @KbPeriodeID AND
        PeriodeStatusCode = 1 -- aktiv

  -- validate vars
  IF (@DateCheckBegin IS NULL OR @DateCheckEnd IS NULL)
  BEGIN
    -- check dates cannot be null
    RETURN 0
  END

  -----------------------------------------------------------------------------
  -- check if date is valid
  -----------------------------------------------------------------------------
  IF (@BelegDatum NOT BETWEEN @DateCheckBegin AND @DateCheckEnd)
  BEGIN
    -- BelegDatum is not within given range or periode is not active and therefore BelegDatum is not valid
    RETURN 0
  END

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN 1 -- date is valid for given periode
END
GO