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
  SUMMARY: Use this function to get all OrgUnits (Standard: No filter for KGS)
    @UserID: The user to get orgunit data for
  -
  RETURNS: Table containing all orgunits
=================================================================================================
  TEST:    SELECT * FROM dbo.fnGetCantonsOrgUnits(778);
           SELECT * FROM dbo.fnGetCantonsOrgUnits(292);
           --
           SELECT * FROM dbo.fnGetCantonsOrgUnits(2);
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
  -- get all orgunits
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT [OrgUnitID] = ORG.[OrgUnitID], 
           [ItemName]  = ORG.[ItemName], 
           [Level]     = 0
    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
    ORDER BY ORG.[ItemName] ASC;  
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO
