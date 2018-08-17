SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnOrgUnitsOfUser;
GO
/*  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: 
    @UserID: The user to get orgunit data for
=================================================================================================*/

CREATE FUNCTION dbo.fnOrgUnitsOfUser
(
  @UserID INT
)
RETURNS @Result TABLE
(
  [OrgUnitID] INT NOT NULL 
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@UserID IS NULL)
  BEGIN
    -- invalid data
    RETURN;
  END;
  
 ;WITH Abteilung (Id, ParentId, LEVEL)
 AS
 (
    -- Anchor 
    SELECT ORG.OrgUnitID, ORG.ParentId, 0
    FROM dbo.XOrgUnit ORG
    INNER JOIN dbo.XOrgUnit_User USR ON USR.OrgUnitID = ORG.OrgUnitID
    WHERE USR.UserID = @UserID
        
 
    UNION ALL
 
    -- Recursion
    SELECT ORG.OrgUnitID, ORG.ParentId, LEVEL + 1
    FROM dbo.XOrgUnit ORG
    INNER JOIN Abteilung ABT ON ABT.ParentID  = ORG.OrgUnitId
           
 )

 INSERT INTO @Result
 SELECT ABT.Id FROM Abteilung ABT;      
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO
