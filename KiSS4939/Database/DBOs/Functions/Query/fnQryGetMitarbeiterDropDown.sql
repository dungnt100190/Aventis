SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnQryGetMitarbeiterDropDown;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Query/fnQryGetMitarbeiterDropDown.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:31 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all Kostenstellen for given user and flags. The Kostenstellen
           will be used for DropDown within queries.
    @UserID:                The user to get data from
    @SpecialRightHauptsitz: The flag if user has special rights for Hauptsitz activated (1. prio)
    @SpecialRightKGS:       The flag if user has special rights for KGS activated (2. prio)
    @AllowNull:             The flag if an empty entry is available for chief/representative default users
  -
  RETURNS: Table containing all required dropdown columns
  -
  TEST:    SELECT * FROM dbo.fnQryGetMitarbeiterDropDown(333, 1, 1, 0)
           SELECT * FROM dbo.fnQryGetMitarbeiterDropDown(333, 0, 1, 1)
           SELECT * FROM dbo.fnQryGetMitarbeiterDropDown(333, 1, 0, 0)
           SELECT * FROM dbo.fnQryGetMitarbeiterDropDown(333, 0, 0, 1)
           SELECT * FROM dbo.fnQryGetMitarbeiterDropDown(333, 0, 0, 0)
           SELECT * FROM dbo.fnQryGetMitarbeiterDropDown(2, 0, 0, 1)
           SELECT * FROM dbo.fnQryGetMitarbeiterDropDown(2, 0, 0, 0)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Query/fnQryGetMitarbeiterDropDown.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     7.01.09 15:28 Cjaeggi
 * First version
=================================================================================================*/

CREATE FUNCTION dbo.fnQryGetMitarbeiterDropDown
(
  @UserID INT,
  @SpecialRightHauptsitz BIT,
  @SpecialRightKGS BIT,
  @AllowNull BIT
)
RETURNS @Result TABLE
(
  [Code] INT UNIQUE,
  [Text] VARCHAR(255)
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@UserID IS NULL)
  BEGIN
    -- invalid data
    RETURN
  END
  
  -- init bits
  SET @SpecialRightHauptsitz = ISNULL(@SpecialRightHauptsitz, 0)
  SET @SpecialRightKGS = ISNULL(@SpecialRightKGS, 0)
  SET @AllowNull = ISNULL(@AllowNull, 0)
  
  -----------------------------------------------------------------------------
  -- check if user has special right for Hauptsitz and can see all users
  -----------------------------------------------------------------------------
  IF (@SpecialRightHauptsitz = 1)
  BEGIN
    -- user is admin, select all org units
    INSERT INTO @Result
      -- empty entry
      SELECT [Code] = NULL,
             [Text] = ''
      
      UNION
      
      -- other orgunits
      SELECT [Code] = USR.UserID,
             [Text] = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName) + ISNULL(' (' + LogonName + ')', '')  -- display as in function
      FROM dbo.XUser USR WITH (READUNCOMMITTED)
      ORDER BY [Text] ASC
  END
  
  -----------------------------------------------------------------------------
  -- check if user has special right for KGS (is lower prio than Hauptsitz)
  -----------------------------------------------------------------------------
  ELSE IF (@SpecialRightKGS = 1)
  BEGIN
    -- user is admin, select all org units
    INSERT INTO @Result
      -- empty entry
      SELECT [Code] = NULL,
             [Text] = ''
      
      UNION
      
      -- other users
      SELECT [Code] = USR.UserID,
             [Text] = USR.Name + ISNULL(' (' + USR.LogonName + ')', '')
      FROM dbo.fnGetCantonsOrgUnitsUsers(@UserID) USR
      ORDER BY [Text] ASC
  END
  
  -----------------------------------------------------------------------------
  -- default user, can only see users as defined in ZLE
  -----------------------------------------------------------------------------
  ELSE
  BEGIN
    -- user has no specialrights, select users as in ZLE-function defined
    INSERT INTO @Result
      SELECT [Code],
             [Text]
      FROM dbo.fnBDEGetOEUserList(@UserID, @AllowNull)
  END
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
GO  