SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetInstStammUserORGList;
GO
/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all org units the user has access to
           - from member orgunit upwarts to root orgunit
           - and all orgunits where user is guest or leitung
           - additional: if user is admin or user has specialright "AdInstitutionenStammAlleAbteilungen" 
                         or config-flag "System\Basis\AbteilungAufInstAlsMussfeld"=0: the user can see
                         all orgunits-institutions
    @UserID: The user to get data from
  -
  RETURNS: Table containing all orgunits the user can access, useable for lov
=================================================================================================
  TEST:    SELECT * FROM dbo.fnGetInstStammUserORGList(440);
           SELECT * FROM dbo.fnGetInstStammUserORGList(2);
           SELECT * FROM dbo.fnGetInstStammUserORGList(120);
=================================================================================================*/

CREATE FUNCTION dbo.fnGetInstStammUserORGList 
(
  @UserID INT
)
RETURNS @Result TABLE
(
  OrgUnitID INT NULL UNIQUE,
  ItemName VARCHAR(100) NOT NULL
)
AS
BEGIN
  -- ---------------------------------------------------------------------------------------------
  -- check if user is admin -> can view all orgunits
  -- ---------------------------------------------------------------------------------------------
  DECLARE @IsUserAdmin BIT;
  DECLARE @HasSpecialRight BIT;
  DECLARE @OrgUnitIsMustField BIT;
  DECLARE @OrgUnitTypeFilter INT;
  DECLARE @OrgUnitTypeFilterSek INT;
  
  SET @IsUserAdmin = dbo.fnIsUserAdmin(@UserID);
  SET @HasSpecialRight = 0;
  SET @OrgUnitIsMustField = 0;
  SET @OrgUnitTypeFilter = -1;
  SET @OrgUnitTypeFilterSek = -1;
  
  -- ---------------------------------------------------------------------------------------------
  -- check if user has special rights -> can view all orgunits
  -- or
  -- check configuration if OrgUnitID on BaInstitution is allowed to be empty
  -- ---------------------------------------------------------------------------------------------
  -- special right
  IF (@IsUserAdmin = 0)
  BEGIN
    SET @HasSpecialRight = dbo.fnUserHasRight(@UserID, 'AdInstitutionenStammAlleAbteilungen');
  END;
  
  -- config value
  IF (@IsUserAdmin = 0 AND @HasSpecialRight = 0)
  BEGIN
    SET @OrgUnitIsMustField = CONVERT(BIT, ISNULL(dbo.fnXConfig('System\Basis\AbteilungAufInstAlsMussfeld', GETDATE()), 0));
  END;
  
  -- ---------------------------------------------------------------------------------------------
  -- we need to get filter for orgunits
  -- ---------------------------------------------------------------------------------------------
  SET @OrgUnitTypeFilter    = CONVERT(INT, ISNULL(dbo.fnXConfig('System\Basis\OrgEinheitTypFuerInstTypen', GETDATE()), -1));
  SET @OrgUnitTypeFilterSek = CONVERT(INT, ISNULL(dbo.fnXConfig('System\Basis\OrgEinheitTypFuerInstTypenSek', GETDATE()), -1));
  
  -- ---------------------------------------------------------------------------------------------
  -- If user is Admin or has special rights or OrgUnitID is not mustfield,
  -- he can see all org units including an empty entry
  -- ---------------------------------------------------------------------------------------------
  IF (@IsUserAdmin = 1 OR @HasSpecialRight = 1 OR @OrgUnitIsMustField = 0)
  BEGIN
    -- output
    INSERT INTO @Result
      SELECT OrgUnitID = NULL,
             ItemName = ''
      
      UNION ALL
      
      SELECT OrgUnitID = ORG.OrgUnitID,
             ItemName = ORG.ItemName
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      WHERE (@OrgUnitTypeFilter = -1 OR ISNULL(ORG.OEItemTypCode, -99) IN (@OrgUnitTypeFilter, @OrgUnitTypeFilterSek))
      ORDER BY ItemName ASC;
    
    -- done
    RETURN;
  END;
  
  -- ---------------------------------------------------------------------------------------------
  -- No special rights, get only orgunits the user is allowed to see
  -- ---------------------------------------------------------------------------------------------
  -- user is not admin and has no special rights
  DECLARE @ParentOrgUnit INT;
  
  -- declare temp table for proper sorting and parsing
  DECLARE @tmpOrgUnits TABLE
  (
    OrgUnitID INT NOT NULL,
    ParentID INT NULL
  );
    
  -- insert first entry where user is member (should be only one)
  INSERT INTO @tmpOrgUnits
    SELECT OrgUnitID = ORG.OrgUnitID,
           ParentID  = ORG.ParentID
    FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)
      INNER JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
    WHERE OUU.UserID = @UserID AND OrgUnitMemberCode = 2; -- only member
  
  -- get parentid of orgunit where user is member
  SELECT TOP 1
         @ParentOrgUnit = TMP.ParentID
  FROM @tmpOrgUnits TMP;
  
  -- get all parents available upwards from current entry
  IF (@ParentOrgUnit IS NOT NULL)
  BEGIN
    WITH CteParentOrgUnits (OrgUnitID, ParentID)
    AS 
    (
      -- anchor definition (only root element)
      SELECT OrgUnitID = ORG.OrgUnitID,
             ParentID  = ORG.ParentID
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      WHERE ORG.OrgUnitID = @ParentOrgUnit
       
      UNION ALL
      
      -- recursive member definition
      SELECT OrgUnitID = ORG.OrgUnitID,
             ParentID  = ORG.ParentID
      FROM dbo.XOrgUnit              ORG WITH (READUNCOMMITTED)
        INNER JOIN CteParentOrgUnits CTE ON CTE.ParentID = ORG.OrgUnitID
                                        AND CTE.ParentID IS NOT NULL -- breaking condition
    )
    INSERT INTO @tmpOrgUnits (OrgUnitID, ParentID)
      SELECT CTE.OrgUnitID, 
             CTE.ParentID
      FROM CteParentOrgUnits CTE;
  END;
  
  -- add org units where user is guest or leitung
  INSERT INTO @tmpOrgUnits
    SELECT OrgUnitID = ORG.OrgUnitID,
           ParentID  = ORG.ParentID
    FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)
      INNER JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
    WHERE OUU.UserID = @UserID AND OrgUnitMemberCode <> 2; -- only guests and leitung
  
  -- output
  INSERT INTO @Result
    SELECT DISTINCT 
           ORG.OrgUnitID, 
           ORG.ItemName
    FROM @tmpOrgUnits TMP
      INNER JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = TMP.OrgUnitID
                                                        AND (@OrgUnitTypeFilter = -1 OR ISNULL(ORG.OEItemTypCode, -99) IN (@OrgUnitTypeFilter, @OrgUnitTypeFilterSek))
    ORDER BY ORG.ItemName ASC;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO