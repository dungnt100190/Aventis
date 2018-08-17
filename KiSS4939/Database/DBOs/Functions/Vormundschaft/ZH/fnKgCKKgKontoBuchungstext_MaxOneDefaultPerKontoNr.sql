SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnKgCKKgKontoBuchungstext_MaxOneDefaultPerKontoNr;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Checks if the given KbuZahlungseingangID is either NULL or UNIQUE within the table
           SstZahlungseingang.
    @@KontoNr: The KontoNr to perform the check for
  -
  RETURNS: 0 if no problems were detected or 1 if more than one Buchungstext is marked as default 
           for the given KontoNr.
=================================================================================================
  TEST:    SELECT dbo.fnKgCKKgKontoBuchungstext_MaxOneDefaultPerKontoNr(10);
=================================================================================================*/

CREATE FUNCTION dbo.fnKgCKKgKontoBuchungstext_MaxOneDefaultPerKontoNr
(
  @KontoNr VARCHAR(10)
)
RETURNS BIT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  IF (@KontoNr IS NULL)
  BEGIN
    -- invalid
    RETURN 1;
  END;

  -----------------------------------------------------------------------------
  -- check
  -----------------------------------------------------------------------------
  DECLARE @NbrDefaults INT;

  SELECT @NbrDefaults = COUNT(1)
  FROM KgKontoBuchungstext
  WHERE KontoNr = @KontoNr
    AND IsDefault = 1;

  IF (@NbrDefaults > 1)
  BEGIN 
    -- invalid
    RETURN 1;
  END;
  
  -----------------------------------------------------------------------------
  -- valid
  -----------------------------------------------------------------------------
  RETURN 0;
END;
GO
