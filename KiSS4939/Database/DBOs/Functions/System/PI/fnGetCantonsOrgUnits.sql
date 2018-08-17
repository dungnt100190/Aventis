SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetCantonsOrgUnits;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnGetCantonsOrgUnits.sql $
  $Author: Cjaeggi $
  $Modtime: 13.08.10 10:59 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all OrgUnits of canton of current user including guestrights
           to other cantons.
    @UserID: The user to get orgunit data for
  -
  RETURNS: Table containing all orgunits of current user's canton
  -
  TEST:    SELECT * FROM dbo.fnGetCantonsOrgUnits(778);
           SELECT * FROM dbo.fnGetCantonsOrgUnits(292);
           --
           SELECT * FROM dbo.fnGetCantonsOrgUnits(2);
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnGetCantonsOrgUnits.sql $
 * 
 * 6     13.08.10 11:00 Cjaeggi
 * #4167: Removed cursor for performance optimization
 * 
 * 5     18.11.09 9:40 Cjaeggi
 * #3812: Added PrimaryKey to result
 * 
 * 4     18.11.09 8:41 Cjaeggi
 * #5185: Refactoring, fixing comment
 * 
 * 3     1.10.09 13:37 Cjaeggi
 * #4394: BIAGAdmin has admin rights, use function call
 * 
 * 2     17.09.08 12:29 Cjaeggi
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:40 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetCantonsOrgUnits
(
  @UserID INT
)
RETURNS @Result TABLE
(
  [OrgUnitID] INT NOT NULL PRIMARY KEY,
  [ItemName] VARCHAR(100) NOT NULL,
  [Level] INT NOT NULL
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
  
  -----------------------------------------------------------------------------
  -- check if user is admin, can see all orgunits
  -----------------------------------------------------------------------------
  IF (dbo.fnIsUserAdmin(@UserID) = 1)
  BEGIN
    -- user is admin, select all org units
    INSERT INTO @Result
      SELECT [OrgUnitID] = ORG.[OrgUnitID], 
             [ItemName]  = ORG.[ItemName], 
             [Level]     = 0
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      ORDER BY ORG.[ItemName] ASC;
    
    -- done
    RETURN;
    ---------------------------------------------------------------------------
  END;
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  -- statics
  DECLARE @HeadQuartersFlag INT;  -- Hauptsitz = 1
  DECLARE @CantoneFlag INT;       -- Kantonale Geschäftsstelle = 4
  
  SET @HeadQuartersFlag = 1;
  SET @CantoneFlag = 4;
  
  -- fields
  DECLARE @OrgUnitIDMeGuLeOfUser INT;
  DECLARE @KGSOrgUnitID INT;
  DECLARE @Level INT;
  DECLARE @ParentID INT;
  
  -- cursor replacement
  DECLARE @ID INT;
  
  DECLARE @OrgUnits TABLE
  (
    ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    OrgUnitIDMeGuLeOfUser INT
  );
  
  -----------------------------------------------------------------------------
  -- insert entries into temp table
  -----------------------------------------------------------------------------
  INSERT INTO @OrgUnits (OrgUnitIDMeGuLeOfUser)
    SELECT OUU.OrgUnitID
    FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)   -- get all orgunits where user is assigned including guest, etc.
    WHERE OUU.UserID = @UserID;  
  
  -----------------------------------------------------------------------------
  -- loop all entries
  -- get OrgUnitID of users member/guest/leader orgunit
  -----------------------------------------------------------------------------
  WHILE ((SELECT COUNT(1) 
          FROM @OrgUnits) > 0)
  BEGIN
    -- get current entry
    SELECT TOP 1 
           @ID                    = TMP.ID,
           @OrgUnitIDMeGuLeOfUser = TMP.OrgUnitIDMeGuLeOfUser
    FROM @OrgUnits TMP
    ORDER BY TMP.ID ASC;
    
    ---------------------------------------------------------------------------
    -- do it
    ---------------------------------------------------------------------------
    -- validate value
    IF (@OrgUnitIDMeGuLeOfUser IS NOT NULL)
    BEGIN
      -- we have a valid orgunitid
      
      -- setup start parent for looping
      SET @ParentID = @OrgUnitIDMeGuLeOfUser;
      SET @KGSOrgUnitID = NULL;
      
      -------------------------------------------------------------------------
      -- get KGS OrgUnitID
      -------------------------------------------------------------------------
      WHILE (@KGSOrgUnitID IS NULL OR @ParentID IS NULL)
      BEGIN
        -- check if parent id exists
        IF (NOT EXISTS(SELECT TOP 1 1 
                       FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED) 
                       WHERE ORG.OrgUnitID = @ParentID))
        BEGIN
          -- value not found, do not continue with this item
          SET @KGSOrgUnitID = NULL;
          BREAK;  -- cancel while
        END;
        
        -- check if parent is KGS
        IF (EXISTS(SELECT TOP 1 1 
                   FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED) 
                   WHERE ORG.OrgUnitID = @ParentID 
                     AND ORG.OEItemTypCode IN (@CantoneFlag)))
        BEGIN
          -- we found value, apply
          SET @KGSOrgUnitID = @ParentID;
          SET @ParentID = NULL;
          BREAK;
        END;
        
        -- get parent of current value if KGS not found yet
        SELECT @ParentID = ORG.ParentID
        FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
        WHERE ORG.OrgUnitID = @ParentID;
      END; -- [WHILE kgs-loop]
      
      -------------------------------------------------------------------------
      -- add KGS to result
      -------------------------------------------------------------------------
      -- validate paramter we found for current KGS
      IF (@KGSOrgUnitID IS NOT NULL AND NOT EXISTS(SELECT TOP 1 1 
                                                   FROM @Result RES
                                                   WHERE RES.OrgUnitID = @KGSOrgUnitID))
      BEGIN
        -- add unique KGS id to result for later parsing
          INSERT INTO @Result
            SELECT [OrgUnitID] = ORG.[OrgUnitID],
                   [ItemName]  = ORG.[ItemName], 
                   [Level]     = 0
            FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
            WHERE ORG.[OrgUnitID] = @KGSOrgUnitID;
      END; -- [IF valid 2]
    END; -- [IF valid 1]
    -----------------------------------------------------------------------------
    
    -- remove current entry from table to prepare for next
    DELETE TMP
    FROM @OrgUnits TMP 
    WHERE TMP.ID = @ID;
  END;
  
  -----------------------------------------------------------------------------
  -- validate if we found any kgs
  -----------------------------------------------------------------------------
  IF (NOT EXISTS(SELECT TOP 1 1 
                 FROM @Result))
  BEGIN
    -- we did not find any KGS in hierarchy, return only orgunit where user is member
    -- insert value of user's orgunit into result
    INSERT INTO @Result
      SELECT [OrgUnitID] = ORG.[OrgUnitID],
             [ItemName]  = ORG.[ItemName], 
             [Level]     = 0
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      WHERE ORG.[OrgUnitID] = dbo.fnOrgUnitOfUser(@UserID, 1);
    
    -- done
    RETURN;
    ---------------------------------------------------------------------------
  END;
  
  -----------------------------------------------------------------------------
  -- continue getting all orgunits under kgs
  -----------------------------------------------------------------------------
  -- init values for loop
  SET @Level = 0;
  
  -- loop until we have no more org units under current level
  WHILE (@@ROWCOUNT > 0)
  BEGIN
    -- count up level
    SET @Level = @Level + 1;
    
    -- insert values
    INSERT INTO @Result
      SELECT [OrgUnitID] = ORG.OrgUnitID, 
             [ItemName]  = ORG.ItemName, 
             [Level]     = @Level
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      WHERE ORG.[ParentID] IN (SELECT SUB.[OrgUnitID]
                               FROM @Result SUB
                               WHERE SUB.[Level] = (@Level-1));
  END;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO
