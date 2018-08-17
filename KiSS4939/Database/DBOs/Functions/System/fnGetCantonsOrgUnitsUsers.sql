SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetCantonsOrgUnitsUsers;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetCantonsOrgUnitsUsers.sql $
  $Author: Cjaeggi $
  $Modtime: 18.11.09 9:38 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all users of user's KGS and guestrights KGS
    @UserID:  The user to get data from
  -
  RETURNS: Table containing all users of all orgunits of current user's canton
  -
  TEST:    SELECT * FROM dbo.fnGetCantonsOrgUnitsUsers(1318)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetCantonsOrgUnitsUsers.sql $
 * 
 * 3     18.11.09 9:38 Cjaeggi
 * #3812: Added PrimaryKey to result
 * 
 * 2     18.11.09 8:46 Cjaeggi
 * #3812: Refactoring and fixing comment
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:40 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetCantonsOrgUnitsUsers
(
  @UserID INT
)
RETURNS @Result TABLE
(
  [UserID] INT NOT NULL PRIMARY KEY,
  [Name] VARCHAR(255) NOT NULL,
  [Kürzel] VARCHAR(10),
  [LogonName] VARCHAR(200) NOT NULL,
  [Abteilung] VARCHAR(255) NOT NULL
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- get all users of all org units we found
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT DISTINCT
           USR.UserID,
           dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName),
           USR.ShortName,
           USR.LogonName,
           dbo.fnOrgUnitOfUser(USR.UserID, 0)
    FROM dbo.fnGetCantonsOrgUnits(@UserID) ORG
      INNER JOIN dbo.XOrgUnit_User         OUU WITH (READUNCOMMITTED) ON OUU.OrgUnitID = ORG.OrgUnitID 
                                                                     AND OUU.OrgUnitMemberCode IN (1, 2, 3) -- leitung, member, gast
      INNER JOIN dbo.XUser                 USR WITH (READUNCOMMITTED) ON USR.UserID = OUU.UserID;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO