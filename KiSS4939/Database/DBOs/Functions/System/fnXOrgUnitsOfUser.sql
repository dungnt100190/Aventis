SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXOrgUnitsOfUser;
GO
/*===============================================================================================
  $Author: Claude Glauser
  $Revision: 1 $
=================================================================================================
  Holt alle Abteilungen, wo ein User Mitglied ist. Die Überabteilungen sind auch 
  enthalten. Die Memberships jeder Art werden im Resultat enthalten sein, also auch "Gast". 
-------------------------------------------------------------------------------------------------
  SUMMARY:   Holt alle Abteilungen, wo ein User Mitglied ist. Die Überabteilungen sind auch 
             enthalten. Die Memberships jeder Art werden im Resultat enthalten sein, also auch "Gast". 
    @Param1: Die Id des Users.
  -
  RETURNS: Eien Tabelle mit den Ids der Abteilungen (OrgUnitID von XOrgUnit). 
  -
  TEST:    SELECT OrgUnitID FROM dbo.fnXOrgUnitsOfUser(2574); 
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE FUNCTION dbo.fnXOrgUnitsOfUser
(
  @UserID INT
)
RETURNS @Result TABLE
(
  [OrgUnitID] INT NOT NULL 
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
  -- Rekursives query von unten nach oben (von den Nebenabteilungen
  -- zu den Hauptabteilungen).
  -----------------------------------------------------------------------------  
 ;WITH Abteilung (Id, ParentId, LEVEL)
 AS
 (
    -- Anchor 
    SELECT ORG.OrgUnitID, ORG.ParentId, 0
    FROM dbo.XOrgUnit ORG
    INNER JOIN dbo.XOrgUnit_User USR ON USR.OrgUnitID = ORG.OrgUnitID
    WHERE USR.UserID = @UserID
        
 
    UNION ALL
 
    -- Recursion
    SELECT ORG.OrgUnitID, ORG.ParentId, LEVEL + 1
    FROM dbo.XOrgUnit ORG
    INNER JOIN Abteilung ABT ON ABT.ParentID  = ORG.OrgUnitId
           
 )

 INSERT INTO @Result
 SELECT DISTINCT ABT.Id FROM Abteilung ABT;      
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO
