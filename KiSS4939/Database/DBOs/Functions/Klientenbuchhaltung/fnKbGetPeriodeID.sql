SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnKbGetPeriodeID;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Klientenbuchhaltung/fnKbGetPeriodeID.sql $
  $Author: Cjaeggi $
  $Modtime: 19.05.10 10:32 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a PeriodeID depending on budget values.
           >> only PeriodeStatusCode = 1 (offen)
    @KbMandantID:          The MandatID to use (e.g. BSS Klibu: KbMandantID = 1)
    @BgBudgetID:           The budgetid to use if no BgJahr and BgMonat is given
    @BgJahr:               The year to use for Periode (if NULL, BgBudgetID has to be given)
    @BgMonat:              The month to use for Periode (if NULL, BgBudgetID has to be given)
    @IfEmptyGetNewestOpen: If no PeriodeID can be found within given date-range, the newest open
                           PeriodeID can be returned (1=give newest if none, 0=get only within range)
  -
  RETURNS: NULL if none was found of invalid, else PeriodeID
  -
  TEST:    SELECT dbo.fnKbGetPeriodeID(1, NULL, 2006, 10, 1)
           SELECT dbo.fnKbGetPeriodeID(1, NULL, 2008, 10, 0)
           --
           SELECT dbo.fnKbGetPeriodeID(2, NULL, 2008, 10, 0)
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Klientenbuchhaltung/fnKbGetPeriodeID.sql $
 * 
 * 4     19.05.10 10:34 Cjaeggi
 * #5478: Added new function fnKbGetPeriodeIDByDate, modified code
 * 
 * 3     24.06.09 16:22 Ckaeser
 * Alter2Create
 * 
 * 2     13.01.09 16:13 Ckaeser
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE FUNCTION dbo.fnKbGetPeriodeID
(
  @KbMandantID INT,
  @BgBudgetID INT,
  @BgJahr INT,
  @BgMonat INT,
  @IfEmptyGetNewestOpen BIT
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  IF ((@KbMandantID IS NULL) OR
      (@BgBudgetID IS NULL AND (@BgJahr IS NULL OR @BgMonat IS NULL)))
  BEGIN
    -- invalid parameters, cannot continue
    RETURN NULL;
  END;

  -- NULL is 0 for bit
  SET @IfEmptyGetNewestOpen = ISNULL(@IfEmptyGetNewestOpen, 0);

  -----------------------------------------------------------------------------
  -- get range from BgBudgetID if neccessary
  -----------------------------------------------------------------------------
  IF (@BgJahr IS NULL OR @BgMonat IS NULL)
  BEGIN
    -- get value from BgBudgetID
    SELECT @BgJahr = Jahr, 
           @BgMonat = Monat
    FROM dbo.BgBudget WITH (READUNCOMMITTED) 
    WHERE BgBudgetID = ISNULL(@BgBudgetID, -1);
  END;
  
  -----------------------------------------------------------------------------
  -- revalidate, BgJahr and BgMonat are required
  -----------------------------------------------------------------------------
  IF (@BgJahr IS NULL OR @BgMonat IS NULL)
  BEGIN
    -- could not determine required values, cannot continue
    RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------  
  DECLARE @BgBudgetDate DATETIME;
  SET @BgBudgetDate = dbo.fnDateSerial(@BgJahr, @BgMonat, 1);
  
  -----------------------------------------------------------------------------
  -- return KbPeriodeID for given parameters
  -----------------------------------------------------------------------------
  RETURN dbo.fnKbGetPeriodeIDByDate(@KbMandantID, 
                                    @BgBudgetDate, 
                                    dbo.fnLastDayOf(@BgBudgetDate), 
                                    @IfEmptyGetNewestOpen);
END;
GO