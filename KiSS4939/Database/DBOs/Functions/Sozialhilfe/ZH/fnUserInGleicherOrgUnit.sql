SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnUserInGleicherOrgUnit;
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Überprüft, ob zwei User in derselben Organisationseinheit sind.
    @UserID1: Id des ersten USERS
    @UserID2: Id des zweiten USERS
  -
  RETURNS: 1 wenn beide in derselben XOrgUnit sind.
=================================================================================================
  TEST:    SELECT dbo.fnUserInGleicherOrgUnit(…);
=================================================================================================*/

CREATE FUNCTION dbo.fnUserInGleicherOrgUnit
(
  @UserID1 INT,
  @UserID2 INT
)
RETURNS BIT
AS 
BEGIN
  
  -----------------------------------------------------------------------------
  -- <Block>
  -----------------------------------------------------------------------------
  DECLARE @Result BIT;
  
  IF EXISTS (
	  SELECT USR.UserID
	  FROM dbo.XUser USR
	   INNER JOIN dbo.XOrgUnit_User OUU ON OUU.UserID = USR.UserID AND OUU.OrgUnitMemberCode = 2
	   INNER JOIN dbo.XOrgUnit_User OUU2 ON OUU2.OrgUnitID = OUU.OrgUnitID AND OUU.OrgUnitMemberCode = 2
	  WHERE 
		USR.UserID = @UserID1
	    AND OUU2.UserID = @UserID2
	 
  ) RETURN 1;
  
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------  
  RETURN 0;
END;
GO
