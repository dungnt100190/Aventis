SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnSozialzentrumVomUser;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Eruiert das Sozialzentrum, in welchem der User sich befindet.
-------------------------------------------------------------------------------------------------
  SUMMARY: Eruiert das Sozialzentrum, in welchem der User sich befindet.
    @UserId: Die Userid
  -
  RETURNS: Die ID des XOrgUnits vom Sozialzentrum
=================================================================================================
  TEST:    SELECT dbo.fnSozialzentrumVomUser(…);
=================================================================================================*/

CREATE FUNCTION dbo.fnSozialzentrumVomUser
( 
  @UserId INT
)
RETURNS INT
AS 
BEGIN
  

  -----------------------------------------------------------------------------
  -- <Block>
  -----------------------------------------------------------------------------
  DECLARE @HauptOrgUnit INT;
  DECLARE @OrgUnitID_User INT;
  DECLARE @Result INT;
    
  
  SELECT @HauptOrgUnit = CONVERT(INT, dbo.fnXConfig('System\Basis\QuartiertteamsAbeilungsID', GETDATE()));
  
  SELECT @OrgUnitID_User = OUU.OrgUnitID
  FROM dbo.XOrgUnit_User OUU 
  WHERE
	OUU.UserID = @UserId
	AND OUU.OrgUnitMemberCode = 2
	
  	
  
  ;WITH CTE
  AS
  (
	 SELECT ORG.OrgUnitID, ORG.ParentID
	 FROM dbo.XOrgUnit ORG
	 WHERE ORG.OrgUnitID = @OrgUnitID_User
	 
	 UNION ALL
	 
	 SELECT ORG.OrgUnitID, ORG.ParentID
	 FROM dbo.XOrgUnit ORG
	 INNER JOIN CTE X ON X.ParentID = ORG.OrgUnitID
	 	 		 
  )
  
  SELECT 
	@Result = X.OrgUnitID
  FROM CTE X
  WHERE X.ParentID = @HauptOrgUnit;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN @Result;
END;
GO
