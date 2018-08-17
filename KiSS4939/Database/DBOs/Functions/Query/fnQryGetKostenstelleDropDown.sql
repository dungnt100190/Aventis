SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnQryGetKostenstelleDropDown;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Query/fnQryGetKostenstelleDropDown.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:30 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all Kostenstellen for given user and flags. The Kostenstellen
           will be used for DropDown within queries.
    @UserID:                The user to get data from
    @SpecialRightHauptsitz: The flag if user has special rights for Hauptsitz activated (1. prio)
    @SpecialRightKGS:       The flag if user has special rights for KGS activated (2. prio)
  -
  RETURNS: Table containing all required dropdown columns
  -
  TEST:    SELECT * FROM dbo.fnQryGetKostenstelleDropDown(333, 1, 1)
           SELECT * FROM dbo.fnQryGetKostenstelleDropDown(333, 0, 1)
           SELECT * FROM dbo.fnQryGetKostenstelleDropDown(333, 1, 0)
           SELECT * FROM dbo.fnQryGetKostenstelleDropDown(333, 0, 0)
           SELECT * FROM dbo.fnQryGetKostenstelleDropDown(2, 0, 0)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Query/fnQryGetKostenstelleDropDown.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     20.01.09 15:32 Cjaeggi
 * Modified text to function call
 * 
 * 1     7.01.09 14:10 Cjaeggi
=================================================================================================*/

CREATE FUNCTION dbo.fnQryGetKostenstelleDropDown
(
  @UserID INT,
  @SpecialRightHauptsitz BIT,
  @SpecialRightKGS BIT
)
RETURNS @Result TABLE
(
  [Code] INT UNIQUE,
  [Text] VARCHAR(255),
  [Kostenstelle$] INT
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
  
  -----------------------------------------------------------------------------
  -- check if user has special right for Hauptsitz and can see all orgunits
  -----------------------------------------------------------------------------
  IF (@SpecialRightHauptsitz = 1)
  BEGIN
    -- user is admin, select all org units
    INSERT INTO @Result
      -- empty entry
      SELECT [Code]          = NULL,
             [Text]          = '',
             [Kostenstelle$] = -1
      
      UNION ALL
      
      -- other orgunits
      SELECT [Code]          = ORG.OrgUnitID,
             [Text]          = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
             [Kostenstelle$] = ORG.Kostenstelle
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      ORDER BY Kostenstelle$ ASC, Text ASC
  END
  
  -----------------------------------------------------------------------------
  -- check if user has special right for KGS (is lower prio than Hauptsitz)
  -----------------------------------------------------------------------------
  ELSE IF (@SpecialRightKGS = 1)
  BEGIN
    -- user is admin, select all org units
    INSERT INTO @Result
      -- empty entry
      SELECT [Code]          = NULL,
             [Text]          = '',
             [Kostenstelle$] = -1
      
      UNION ALL
      
      -- other orgunits
      SELECT [Code]          = ORG.OrgUnitID,
             [Text]          = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
             [Kostenstelle$] = ORG.Kostenstelle
      FROM dbo.fnGetCantonsOrgUnits(@UserID) COU
        INNER JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = COU.OrgUnitID
      ORDER BY Kostenstelle$ ASC, Text ASC
  END
  
  -----------------------------------------------------------------------------
  -- default user, can only see Kostenstellen as defined in ZLE
  -----------------------------------------------------------------------------
  ELSE
  BEGIN
    -- user has no specialrights, select orgunits as in ZLE-function defined
    INSERT INTO @Result
      SELECT [Code],
             [Text],
             [Kostenstelle$]
      FROM dbo.fnBDEGetOEOrgUnitListZLE(@UserID, 0, 'Kostenstelle', 'Kostenstelle')
  END
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
GO 