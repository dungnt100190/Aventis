SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetOrgUnitIDFromMandantenNr;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetOrgUnitIDFromMandantenNr.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:23 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get historised LohnlaufNr for Stundenlohn
    @MandantenNr: The unique MandantenNr within the orgunits
  -
  RETURNS: The orgunit id with the given MandantenNr or -1 if invalid or not found
  -
  TEST:    SELECT [dbo].[fnBDEGetOrgUnitIDFromMandantenNr](101)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetOrgUnitIDFromMandantenNr.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetOrgUnitIDFromMandantenNr
(
  @MandantenNr INT
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@MandantenNr IS NULL OR @MandantenNr < 1)
  BEGIN
    RETURN -1
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @OrgUnitID INT

  -----------------------------------------------------------------------------
  -- request value
  -----------------------------------------------------------------------------
  SELECT @OrgUnitID = ORG.OrgUnitID
  FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
  WHERE ORG.Mandantennummer = @MandantenNr

  -----------------------------------------------------------------------------
  -- check and return value
  -----------------------------------------------------------------------------
  RETURN IsNull(@OrgUnitID, -1)
END
GO