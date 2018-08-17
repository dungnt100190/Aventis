SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnOrgUnitOfUser;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get either the user's member-orgunit name or id
    @UserID:     The id of the user to get data from
    @ReturnID:   1=return the id of the user's member orgunit
                 0=return the name of the user's member orgunit
  -
  RETURNS: The user's member orgunit id/itemname (only one if many)
=================================================================================================
  TEST:    SELECT dbo.fnOrgUnitOfUser(2, 0);
           SELECT dbo.fnOrgUnitOfUser(2, 1);
=================================================================================================*/

CREATE FUNCTION dbo.fnOrgUnitOfUser
(
  @UserID INT,
  @ReturnID BIT = 0
)
RETURNS VARCHAR(100)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- get orgunit value
  -----------------------------------------------------------------------------
  IF (ISNULL(@ReturnID, 0) = 0)
  BEGIN
    ---------------------------------------------------------------------------
    -- init var
    ---------------------------------------------------------------------------
    DECLARE @ItemName VARCHAR(100);
    
    ---------------------------------------------------------------------------
    -- get value for ItemName
    ---------------------------------------------------------------------------
    SELECT TOP 1 
           @ItemName = ORG.ItemName
    FROM dbo.XOrgUnit_User   OUU WITH (READUNCOMMITTED)
      LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
    WHERE UserID = @UserID 
      AND OrgUnitMemberCode = 2 -- member only
    ORDER BY OUU.OrgUnitID;
    
    ---------------------------------------------------------------------------
    -- validate and return value
    ---------------------------------------------------------------------------
    RETURN ISNULL(@ItemName, '');
  END
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- init var
    ---------------------------------------------------------------------------
    DECLARE @OrgUnitID INT;
    
    ---------------------------------------------------------------------------
    -- get value for ItemName
    ---------------------------------------------------------------------------
    SELECT TOP 1 
           @OrgUnitID = OUU.OrgUnitID
    FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)
    WHERE UserID = @UserID 
      AND OrgUnitMemberCode = 2 -- member only
    ORDER BY OUU.OrgUnitID;
    
    ---------------------------------------------------------------------------
    -- validate and return value
    ---------------------------------------------------------------------------
    RETURN ISNULL(@OrgUnitID, -1);
  END;
  
  -----------------------------------------------------------------------------
  -- return nothing if we are here (case should not occure)
  -----------------------------------------------------------------------------
  RETURN NULL;
END;
GO