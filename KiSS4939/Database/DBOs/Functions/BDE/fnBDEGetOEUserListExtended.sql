SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBDEGetOEUserListExtended
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Is used to get all users within the ZLE relationship
           Info: Used from dbo.fnBDEGetOEUserList
    @UserID:         The user to get data from
    @AllowNull:      Set if an empty entry is possible
    @SetUserIsAdmin: Set if user can see data as an admin can do
  -
  RETURNS: Table containing all data in LOV style (plus additional column: IsLocked)
  -
  TEST:    SELECT * FROM dbo.fnBDEGetOEUserListExtended(2, 1, 0)
           SELECT * FROM dbo.fnBDEGetOEUserListExtended(22, 1, 1)
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetOEUserListExtended
 (
  @UserID  INT,
  @AllowNull BIT,
  @SetUserIsAdmin BIT = 0
 )
RETURNS @Result TABLE
(
  [Code] INT,
  [Text] VARCHAR(255),
  [IsLocked] BIT
)
AS BEGIN
  -- ---------------------------------------------------------------------------------------------
  -- validate vars
  -- ---------------------------------------------------------------------------------------------
  SET @SetUserIsAdmin = ISNULL(@SetUserIsAdmin, 0)
  
  -- ---------------------------------------------------------------------------------------------
  -- check if user is admin -> can view every user
  -- ---------------------------------------------------------------------------------------------
  DECLARE @IsUserAdmin BIT
  
  -- check if user has adminrights and can see more/all users
  SET @IsUserAdmin = CASE WHEN @SetUserIsAdmin = 1 THEN 1
                          ELSE dbo.fnIsUserAdmin(@UserID)
                     END
  
  -- ---------------------------------------------------------------------------------------------
  -- Check if user is chief or representativ and is allowed to view other users OR user is admin
  -- ---------------------------------------------------------------------------------------------
  IF (@IsUserAdmin = 1 OR EXISTS(SELECT TOP 1 1 FROM dbo.XOrgUnit WITH (READUNCOMMITTED) WHERE ChiefID = @UserID OR RepresentativeID = @UserID))
  BEGIN
    -- HINT 1: A user can be chief or representativ of another oe where he is not member
    -- HINT 2: A user can be chief or representativ in more than one oe
    
    -- user is chief or representativ, setup temp table
    DECLARE @tmpUsers TABLE
    (
      [Code] INT NOT NULL,
      [Text] VARCHAR(255) NULL,
      [IsLocked] BIT NOT NULL
    )
    
    -- get all users that are within same oe
    INSERT INTO @tmpUsers ([Code], [Text], [IsLocked])
      SELECT OUU.UserID,
             dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ISNULL(' (' + USR.LogonName + ')', ''),
             USR.IsLocked
      FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)
        INNER JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
        INNER JOIN dbo.XUser    USR WITH (READUNCOMMITTED) ON USR.UserID = OUU.UserID
      WHERE OUU.OrgUnitMemberCode IN (1, 2) AND -- only Leiter + Member (no Gast)
            (OUU.OrgUnitID IN (SELECT OrgUnitID
                               FROM dbo.XOrgUnit XOU WITH (READUNCOMMITTED)
                               WHERE XOU.ChiefID = @UserID OR XOU.RepresentativeID = @UserID) OR @IsUserAdmin = 1)
    
    -- check if user is already in list
    IF(NOT EXISTS(SELECT TOP 1 1 FROM @tmpUsers WHERE [Code] = @UserID))
    BEGIN
      -- user is not yet in list, append this user!
      INSERT INTO @tmpUsers ([Code], [Text], [IsLocked])
        SELECT USR.UserID,
               dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ISNULL(' (' + USR.LogonName + ')', ''),
               USR.IsLocked
        FROM dbo.XUser USR WITH (READUNCOMMITTED)
        WHERE USR.UserID = @UserID
    END
    
    -- output to result table
    INSERT INTO @Result
      SELECT [Code] = NULL, [Text] = '', [IsLocked] = 0
      WHERE 1 = @AllowNull
      
      UNION
      
      SELECT [Code], [Text], [IsLocked]
      FROM @tmpUsers
      ORDER BY [Text] ASC
  END
  ELSE
  BEGIN
    -- user is not chief or representativ, show only this user!
    INSERT INTO @Result
      SELECT [Code] = NULL, [Text] = '', [IsLocked] = 0
      WHERE 1 = @AllowNull
      
      UNION
      
      SELECT [Code] = USR.UserID,
             [Text] = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ISNULL(' (' + USR.LogonName + ')', ''),
             [IsLocked] = USR.IsLocked
      FROM dbo.XUser USR WITH (READUNCOMMITTED)
      WHERE USR.UserID = @UserID
  END
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
GO