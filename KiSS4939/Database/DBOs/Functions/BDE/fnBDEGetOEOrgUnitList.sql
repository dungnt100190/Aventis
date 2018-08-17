SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetOEOrgUnitList;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetOEOrgUnitList.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:21 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Is used to get all orgunit that are connected to users within the ZLE relationship
    @UserID:             The user to get data from
    @AllowNull:          Set if an empty entry is possible
    @OnlyUserMemberOE:  Show only the orgunits where the users are member
  -
  RETURNS: Table containing all data found in LOV style
  -
  TEST:    SELECT * FROM [dbo].[fnBDEGetOEOrgUnitList](5, 0, 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetOEOrgUnitList.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetOEOrgUnitList
(
  @UserID  INT,
  @AllowNull BIT,
  @OnlyUserMemberOE BIT
)
RETURNS @Result TABLE
(
  [Code] INT,
  [Text] varchar(255)
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- create temporary table to fill orgunits
  -----------------------------------------------------------------------------
  DECLARE @tmpOrgUnits TABLE
  (
    [Id$] INT identity(1, 1) NOT NULL PRIMARY KEY,
    [Code] INT,
    [Text] varchar(255) NULL
  )

  -----------------------------------------------------------------------------
  -- get orgunits that are used in users
  -- INFO: uses fnBDEGetOEUserList to get users and their orgunits
  -----------------------------------------------------------------------------
  INSERT INTO @tmpOrgUnits
    SELECT DISTINCT
           [Code] = ORG.OrgUnitID,
           [Text] = ORG.ItemName
    FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)
      INNER JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
      INNER JOIN dbo.fnBDEGetOEUserList(@UserID, 0) USR  ON USR.Code = OUU.UserID
    WHERE @OnlyUserMemberOE = 0 OR OUU.OrgUnitMemberCode = 2

  -----------------------------------------------------------------------------
  -- write out result to output
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT [Code] = NULL, 
           [Text] = ''
    WHERE 1 = @AllowNull
    UNION
    SELECT [Code], [Text]
    FROM @tmpOrgUnits
    ORDER BY [Text]

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
GO