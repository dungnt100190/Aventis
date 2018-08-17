SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetFerienSaldo;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetFerienSaldo.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:14 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get Feriensaldo per specified date.
    @UserID:  The user to get data from
    @Date:    The date the soll has to be calculated to.
  -
  RETURNS: (+/-) hours of Feriensaldo from the beginning to @Date
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetFerienSaldo.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetFerienSaldo
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
    RETURN 0
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @FerienanspruchTotal money
  DECLARE @FerienZugabenKuerzungenTotal money
  DECLARE @ErfassteFerienTotal money
  DECLARE @FerienkorrekturenTotal money

  -----------------------------------------------------------------------------
  -- get Ferienanspruch
  ----------------------------------------------------------------------------- 
  SET @FerienanspruchTotal = IsNull(dbo.fnBDEGetFerienAnspruch(@UserID, @Date, 0), 0) -- total for all years

  -----------------------------------------------------------------------------
  -- get FerienZugabenKuerzungen
  ----------------------------------------------------------------------------- 
  SET @FerienZugabenKuerzungenTotal = IsNull(dbo.fnBDEGetFerienZugabenKuerzungen(@UserID, @Date, 0), 0) -- total for all years

  -----------------------------------------------------------------------------
  -- get erfasste Ferien 
  ----------------------------------------------------------------------------- 
  SET @ErfassteFerienTotal = IsNull(dbo.fnBDEGetErfassteFerien(@UserID, @Date, 0), 0) -- total for all years

  -----------------------------------------------------------------------------
  -- get erfasste Ferienkorrekturen
  ----------------------------------------------------------------------------- 
  SET @FerienkorrekturenTotal = IsNull(dbo.fnBDEGetFerienKorrekturen(@UserID, @Date, 0), 0) -- total for all years

  -----------------------------------------------------------------------------
  -- calculate and return total saldo
  -----------------------------------------------------------------------------  
  RETURN IsNull(@FerienanspruchTotal + @FerienZugabenKuerzungenTotal - @ErfassteFerienTotal + @FerienkorrekturenTotal, 0)
END
GO