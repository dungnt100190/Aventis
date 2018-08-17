SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetAllKGSOfUser
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetAllKGSOfUser.sql $
  $Author: Cjaeggi $
  $Modtime: 1.10.09 13:29 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all KGS orgunits where the user is member (or guestrights)
    @UserID:            The user to get data from
    @AllowNull:         Set if an empty entry is possible
    @OnlyUserMemberKGS: Show only the KGS where the user is member
  -
  RETURNS: Table containing all data found in LOV style
  -
  TEST:    SELECT * FROM dbo.fnGetAllKGSOfUser(8, 0, 0)
           SELECT * FROM dbo.fnGetAllKGSOfUser(2, 0, 0)
           SELECT * FROM dbo.fnGetAllKGSOfUser(8, 1, 0)
           SELECT * FROM dbo.fnGetAllKGSOfUser(8, 1, 1)
           SELECT * FROM dbo.fnGetAllKGSOfUser(333, 1, 1)
           SELECT * FROM dbo.fnGetAllKGSOfUser(333, 0, 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetAllKGSOfUser.sql $
 * 
 * 6     1.10.09 13:31 Cjaeggi
 * #4394: BIAGAdmin has admin rights, use function call
 * 
 * 5     20.02.09 9:38 Cjaeggi
 * Changed because of new parameter in dbo.fnGetHistKGSOfUserOrOrgUnit
 * 
 * 4     28.01.09 15:49 Cjaeggi
 * Changed header
 * 
 * 3     28.01.09 14:05 Cjaeggi
 * Added: Admin can see all KGSs
 * 
 * 2     28.01.09 11:31 Cjaeggi
 * Fixed comment
 * 
 * 1     28.01.09 11:23 Cjaeggi
 * New function
=================================================================================================*/

CREATE FUNCTION dbo.fnGetAllKGSOfUser
(
  @UserID  INT,
  @AllowNull BIT,
  @OnlyUserMemberKGS BIT
)
RETURNS @Result TABLE
(
  [Code] INT,
  [Text] VARCHAR(255)
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@UserID IS NULL)
  BEGIN
    -- invalid userid, do not continue
    RETURN
  END
  
  -- set flags
  SET @AllowNull = ISNULL(@AllowNull, 0)
  SET @OnlyUserMemberKGS = ISNULL(@OnlyUserMemberKGS, 0)
  
  -----------------------------------------------------------------------------
  -- check if only member, use other function here
  -----------------------------------------------------------------------------
  IF (@OnlyUserMemberKGS = 1)
  BEGIN 
    -- insert only the KGS where the user is member by now
    INSERT INTO @Result
      SELECT [Code] = NULL, 
             [Text] = ''
      WHERE 1 = @AllowNull
      
      UNION
      
      SELECT [Code] = ORG.OrgUnitID,
             [Text] = ORG.ItemName
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      WHERE ORG.OrgUnitID = CONVERT(INT, dbo.fnGetHistKGSOfUserOrOrgUnit(@UserID, GETDATE(), NULL, 1, 0))
      ORDER BY [Text]
      
    -- done
    RETURN
  END
  
  -----------------------------------------------------------------------------
  -- create temporary table to fill orgunits
  -----------------------------------------------------------------------------
  DECLARE @tmpOrgUnitsKGS TABLE
  (
    Id$          INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    OrgUnitIDKGS INT
  )
  
  -----------------------------------------------------------------------------
  -- check if user is admin, can see all KGSs
  -----------------------------------------------------------------------------
  IF (dbo.fnIsUserAdmin(@UserID) = 1)
  BEGIN
    -- user is admin, select all KGS-orgunits
    INSERT INTO @tmpOrgUnitsKGS
      SELECT OrgUnitIDKGS = ORG.OrgUnitID
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      WHERE ORG.OEItemTypCode = 4  -- OrganisationsEinheitTyp: 4=Kantonale Geschäftsstelle
  END
  -----------------------------------------------------------------------------
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- get all KGS where the user is member or guest by now
    -- INFO: uses fnGetHistKGSOfUserOrOrgUnit to get KGS of orgunit
    ---------------------------------------------------------------------------
    INSERT INTO @tmpOrgUnitsKGS (OrgUnitIDKGS)
      SELECT DISTINCT
             OrgUnitIDKGS = CONVERT(INT, dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, GETDATE(), OUU.OrgUnitID, 1, 0)) -- get KGS of given orgunit
      FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)
      WHERE OUU.UserID = @UserID
  END
  
  -----------------------------------------------------------------------------
  -- write out result to output
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT [Code] = NULL, 
           [Text] = ''
    WHERE 1 = @AllowNull
    
    UNION
    
    SELECT DISTINCT 
           [Code] = TMP.OrgUnitIDKGS, 
           [Text] = ORG.ItemName
    FROM @tmpOrgUnitsKGS TMP
      INNER JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = TMP.OrgUnitIDKGS
    ORDER BY [Text]
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
