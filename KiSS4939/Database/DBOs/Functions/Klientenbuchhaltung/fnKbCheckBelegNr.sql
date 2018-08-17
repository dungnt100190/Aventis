SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKbCheckBelegNr;
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnKbCheckBelegNr.sql $
  $Author: Cjaeggi $
  $Modtime: 11.02.10 14:32 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to validate given BelegNr.
           >> BelegNr is valid if it is unique within KbBuchung and Periode
    @KbPeriodeID:      The PeriodeID to use for validation
    @KbBelegKreisCode: The BelegKreisCode to use for validation
    @KontoNr:          The KontoNr to use for validation (optional, can be NULL)
    @BelegNr:          The BelegNr to validate with given parameters
    @KbBuchungID:      The BuchungID used to exclude given entry for validation
  -
  RETURNS: 1 = valid, 0 = invalid
  -
  TEST:    SELECT dbo.fnKbCheckBelegNr(36, 1, '1001.301', 2222, 98000)
           SELECT dbo.fnKbCheckBelegNr(40, 1, NULL, 1559855, 98000)
           SELECT dbo.fnKbCheckBelegNr(36, 4, NULL, 500002, 98000)
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnKbCheckBelegNr.sql $
 * 
 * 3     11.02.10 14:33 Cjaeggi
 * #5709: Formatting
 * 
 * 2     24.06.09 16:20 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE FUNCTION dbo.fnKbCheckBelegNr
(
  @KbPeriodeID INT,
  @KbBelegKreisCode INT,
  @KontoNr varchar(10),
  @BelegNr INT,
  @KbBuchungID INT
)
RETURNS BIT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- DEBUG
  -----------------------------------------------------------------------------
  /*
  DECLARE @KbPeriodeID INT
  DECLARE @KbBelegkreisCode INT
  DECLARE @KontoNr VARCHAR(10)
  DECLARE @BelegNr INT
  DECLARE @KbBuchungID INT  

  SET @KbPeriodeID = 36
  SET @KbBelegkreisCode = 4
  SET @KontoNr = null
  SET @BelegNr = 500011
  SET @KbBuchungID = null
  */

  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  IF (@KbPeriodeID IS NULL 
   OR @KbPeriodeID < 1
   OR @KbBelegKreisCode IS NULL
   OR @KbBelegKreisCode < 1
   OR @BelegNr IS NULL
   OR @BelegNr < 1
   OR @KbBuchungID < 1)
  BEGIN
    -- invalid parameters
    RETURN 0;
  END;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @BelegNrVon INT;
  DECLARE @BelegNrBis INT;
  
  -----------------------------------------------------------------------------
  -- validate range
  -----------------------------------------------------------------------------
  -- set vars
  SELECT @BelegNrVon = BelegNrVon,
         @BelegNrBis = BelegNrBis
  FROM dbo.KbBelegKreis WITH (READUNCOMMITTED) 
  WHERE KbPeriodeID = @KbPeriodeID 
    AND KbBelegKreisCode = @KbBelegKreisCode 
    AND (ISNULL(KontoNr, '') = ISNULL(@KontoNr, ''));

  --validate
  SET @BelegNrVon = ISNULL(@BelegNrVon, -1);
  SET @BelegNrBis = ISNULL(@BelegNrBis, -1);

  -- validate range
  IF (@BelegNr < @BelegNrVon OR @BelegNr > @BelegNrBis)
  BEGIN
    -- invalid range
    RETURN 0;
  END;
  
  -----------------------------------------------------------------------------
  -- check if already in use
  -----------------------------------------------------------------------------
  IF (EXISTS(SELECT TOP 1 1 
             FROM dbo.KbBuchung WITH (READUNCOMMITTED) 
             WHERE KbPeriodeID = @KbPeriodeID 
               AND BelegNr = @BelegNr 
               AND KbBuchungID <> IsNull(@KbBuchungID, -1)))
  BEGIN
    -- number is already in use
    RETURN 0;
  END;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN 1; -- number is valid and not in use
END;
GO