SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnUserMayShowPersonDossier;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Check if user has right to show person's dossier
    @User       = The user to get accessible persons from
    @BaPersonID = The person to check if the user has rights on it
  -
  RETURNS: True if user can see details of persons dossier, else false
=================================================================================================
  TEST:    SELECT dbo.fnUserMayShowPersonDossier(333, 444);
           SELECT dbo.fnUserMayShowPersonDossier(2, 444);
=================================================================================================*/

CREATE FUNCTION dbo.fnUserMayShowPersonDossier
(
  @UserID INT, 
  @BaPersonID INT
)
RETURNS BIT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- Testing
  -----------------------------------------------------------------------------
  /*
  DECLARE @UserID INT;
  DECLARE @BaPersonID INT;
  SET @UserID = 1419;
  SET @BaPersonID = 1982;
  --*/
  
  -----------------------------------------------------------------------------
  -- Validate
  -----------------------------------------------------------------------------
  IF (@UserID IS NULL OR @BaPersonID IS NULL)
  BEGIN
    -- no rights as we have invalid parameters
    RETURN 0;
  END;
  
  -----------------------------------------------------------------------------
  -- check if user is admin, can access all persons
  -----------------------------------------------------------------------------
  IF (dbo.fnIsUserAdmin(@UserID) = 1)
  BEGIN
    -- user is admin
    RETURN 1;
  END;
  
  -----------------------------------------------------------------------------
  -- Users
  -----------------------------------------------------------------------------
  DECLARE @Users TABLE 
  (
    UserID INT NOT NULL PRIMARY KEY
  );
  
  -- Benutzer selbst
  INSERT @Users (UserID)
  VALUES (@UserID);
  
  -- zusäzliche Benutzer (Abteilung, Gastrecht)
  INSERT @Users
    SELECT DISTINCT 
           B.UserID
    FROM dbo.XOrgUnit_User         A WITH (READUNCOMMITTED)
      INNER JOIN dbo.XOrgUnit_User B WITH (READUNCOMMITTED) ON B.OrgUnitID = A.OrgUnitID 
                                                           AND B.UserID <> @UserID 
                                                           AND B.OrgUnitMemberCode = 2 -- member
    WHERE A.UserID = @UserID 
      AND A.OrgUnitMemberCode IN (1, 2, 3);
  
  -----------------------------------------------------------------------------
  -- Persons
  -----------------------------------------------------------------------------
  DECLARE @Persons TABLE
  (
    BaPersonID INT NOT NULL
  )
  
  -- bestimme alle zugehörigen Personen (zeige auch Personen, welche auf User abgeschlossen sind und auf anderem User offene Leistungen haben)
  INSERT @Persons (BaPersonID)
    SELECT DISTINCT 
           LEI.BaPersonID
    FROM @Users                 USR
      INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.UserID = USR.UserID
    
    UNION
    
    -- addiere alle Personen, für welche der Benutzer Gastrecht hat
    SELECT DISTINCT 
           LEI.BaPersonID
    FROM dbo.FaLeistungZugriff  LEZ WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = LEZ.FaLeistungID
    WHERE LEZ.UserID = @UserID;
  
  -- check if person is in list
  IF (EXISTS(SELECT TOP 1 1 
             FROM @Persons 
             WHERE BaPersonID = @BaPersonID))
  BEGIN
    -- user has rights on client-person
    RETURN 1;
  END;
  
  -- addiere alle Personen, welche mit derjenigen Person in Beziehung stehen (nur ohne Leistungen!)
  INSERT @Persons (BaPersonID)
    SELECT BRE.BaPersonID_1
    FROM @Persons TMP
      INNER JOIN dbo.BaPerson_Relation BRE WITH (READUNCOMMITTED) ON BRE.BaPersonID_2 = TMP.BaPersonID
                                                                 AND BRE.BaPersonID_1 = @BaPersonID       -- only if other one is searched person (we need nothing more after check below)
    WHERE NOT EXISTS (SELECT TOP 1 1
                      FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                      WHERE LEI.BaPersonID = BRE.BaPersonID_1)
    
    UNION ALL
    
    SELECT BRE.BaPersonID_2
    FROM @Persons TMP
      INNER JOIN dbo.BaPerson_Relation BRE WITH (READUNCOMMITTED) ON BRE.BaPersonID_1 = TMP.BaPersonID
                                                                 AND BRE.BaPersonID_2 = @BaPersonID       -- only if other one is searched person (we need nothing more after check below)
    WHERE NOT EXISTS (SELECT TOP 1 1
                      FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                      WHERE LEI.BaPersonID = BRE.BaPersonID_2);
  
  -- Testing
  /*
  SELECT DISTINCT 
         UserID 
  FROM @Users
  ORDER BY UserID;
  --*/

  /*
  SELECT DISTINCT 
         BaPersonID 
  FROM @Persons
  ORDER BY BaPersonID;
  --*/
  
  -- check if person is in list
  IF (EXISTS(SELECT TOP 1 1 
             FROM @Persons 
             WHERE BaPersonID = @BaPersonID))
  BEGIN
    -- user has rights on related person
    RETURN 1;
  END;
  
  -- no rights
  RETURN 0;
END;
GO