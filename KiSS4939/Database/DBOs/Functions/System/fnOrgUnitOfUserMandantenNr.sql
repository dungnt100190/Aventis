SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnOrgUnitOfUserMandantenNr;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnOrgUnitOfUserMandantenNr.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:12 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get the user's member-orgunit-mandantennummer
    @UserID:  The user to get data from
  -
  RETURNS: The current mandantennummer or -1 if invalid
  -
  TEST:    SELECT [dbo].[fnOrgUnitOfUserMandantenNr](2)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnOrgUnitOfUserMandantenNr.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 17:29 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnOrgUnitOfUserMandantenNr
(
  @UserID INT
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if no user passed, invalid value
  IF (@UserID IS NULL)
  BEGIN
    RETURN -1
  END

  -----------------------------------------------------------------------------
  -- get value, validate and return value
  -----------------------------------------------------------------------------  
  RETURN IsNull(dbo.fnOrgUnitHierarchyValue(dbo.fnOrgUnitOfUser(@UserID, 1), 'mndnr'), -1)
END
GO