SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetCantonsOrgUnitsPersons;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetCantonsOrgUnitsPersons.sql $
  $Author: Cjaeggi $
  $Modtime: 18.11.09 9:36 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all clients of users KGS including guestrights on KGS
    @UserID:           The user to get data from
    @OnlyWithLeistung: Get only persons who have Leistungen
  -
  RETURNS: Table containing all clients of all orgunits of current user's canton
  -
  TEST:    SELECT * FROM dbo.fnGetCantonsOrgUnitsPersons(1007, 0, NULL)
           SELECT * FROM dbo.fnGetCantonsOrgUnitsPersons(2, 0, NULL)
=================================================================================================*/

CREATE FUNCTION dbo.fnGetCantonsOrgUnitsPersons
(
  @UserID INT,
  @OnlyWithLeistung BIT,
  @PersonNameVornameSearchString VARCHAR(255)
)
RETURNS @Result TABLE
(
  BaPersonID INT NOT NULL PRIMARY KEY
)
AS BEGIN

  IF @PersonNameVornameSearchString IS NULL
  BEGIN
    SET @PersonNameVornameSearchString = '%';
  END;
  -----------------------------------------------------------------------------
  -- check if user is admin, can see all persons (even those without FaLeistung)
  -----------------------------------------------------------------------------
  IF (dbo.fnIsUserAdmin(@UserID) = 1)
  BEGIN
    ---------------------------------------------------------------------------
    -- user is admin and can see all persons
    ---------------------------------------------------------------------------
    INSERT INTO @Result
      SELECT PRS.BaPersonID
      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      WHERE dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) like '%' + @PersonNameVornameSearchString + '%';
      
    ---------------------------------------------------------------------------
    -- done
    ---------------------------------------------------------------------------
    RETURN;
  END
  
  -----------------------------------------------------------------------------
  -- use a temporary table to have unique ids
  -----------------------------------------------------------------------------
  DECLARE @Temp TABLE
  (
    ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    BaPersonID INT NOT NULL
  );
  
  -----------------------------------------------------------------------------
  -- get all persons with items in FaLeistung of current KGS (doublicate items)
  -----------------------------------------------------------------------------
  INSERT INTO @Temp (BaPersonID)
    SELECT PRS.BaPersonID
    FROM dbo.fnGetCantonsOrgUnitsUsers(@UserID) USR
      INNER JOIN dbo.FaLeistung                 LEI WITH (READUNCOMMITTED) ON LEI.UserID = USR.UserID
      INNER JOIN dbo.BaPerson                   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
    WHERE dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) like '%' + @PersonNameVornameSearchString + '%';
  
  -----------------------------------------------------------------------------
  -- add related persons to the persons we found (only one level)
  -----------------------------------------------------------------------------
  -- check if we need to add more persons
  IF (@OnlyWithLeistung = 0)
  BEGIN
    -- person 1
    INSERT INTO @Temp (BaPersonID)
      SELECT REL.BaPersonID_1
      FROM dbo.BaPerson_Relation REL WITH (READUNCOMMITTED)
      WHERE REL.BaPersonID_2 IN (SELECT BaPersonID
                                 FROM @Temp)
        AND REL.BaPersonID_1 IS NOT NULL;
    
    -- person 2
    INSERT INTO @Temp (BaPersonID)
      SELECT REL.BaPersonID_2
      FROM dbo.BaPerson_Relation REL WITH (READUNCOMMITTED)
      WHERE REL.BaPersonID_1 IN (SELECT BaPersonID
                                 FROM @Temp)
        AND REL.BaPersonID_2 IS NOT NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- generate unique entries into result
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT DISTINCT TMP.BaPersonID
    FROM @Temp TMP;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO