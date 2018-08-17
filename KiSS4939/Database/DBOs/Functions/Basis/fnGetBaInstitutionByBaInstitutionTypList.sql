SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetBaInstitutionByBaInstitutionTypList;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Basis/fnGetBaInstitutionByBaInstitutionTypList.sql $
  $Author: Spsota $
  $Modtime: 5.08.10 16:25 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Returns the table BaInstitution matching a list of BaInstitutionTypID's. 
           The Institution matches either all or one of the Typ ID's.
           Depends on dbo.fnSplitStringToValues(...).
    @IdList: CSV List of the BaInstitutionTypID's
    @IsAND:  Descides if one or all Typ ID's must match
  -
  RETURNS: Table BaInstitution
  -
  TEST:    SELECT * FROM dbo.fnGetBaInstitutionByBaInstitutionTypList('5,14', 1);
           SELECT * FROM dbo.fnGetBaInstitutionByBaInstitutionTypList('5,14', 0);
           SELECT * FROM dbo.fnGetBaInstitutionByBaInstitutionTypList('', 1);
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Basis/fnGetBaInstitutionByBaInstitutionTypList.sql $
 * 
 * 4     5.08.10 16:35 Spsota
 * #4167 Korrekturen
 * 
 * 3     5.08.10 16:09 Spsota
 * 
 * 2     5.08.10 16:07 Spsota
 * #4167 Function to get BaInstitutions matching a list of
 * BaInstitutionTypID.
=================================================================================================*/

CREATE FUNCTION dbo.fnGetBaInstitutionByBaInstitutionTypList
(
  @IdList VARCHAR(255) = NULL,
  @IsAND BIT = 0
)
RETURNS @Result TABLE
(
  BaInstitutionID INT NOT NULL,
  OrgUnitID INT,
  InstitutionNr VARCHAR(20),
  BaInstitutionArtCode INT,
  Aktiv BIT,
  Debitor BIT,
  Kreditor BIT,
  KeinSerienbrief BIT,
  ManuelleAnrede BIT, 
  Anrede VARCHAR(100),
  Briefanrede VARCHAR(100),
  Titel VARCHAR(100),
  [Name] VARCHAR(500),
  Vorname VARCHAR(100),
  GeschlechtCode INT,
  Geburtsdatum DATETIME,
  Versichertennummer VARCHAR(18),
  Telefon VARCHAR(100),
  Telefon2 VARCHAR(100),
  Telefon3 VARCHAR(100),
  Fax VARCHAR(100),
  EMail VARCHAR(100),
  Homepage VARCHAR(100),
  SprachCode INT,
  Bemerkung  VARCHAR(MAX),
  Creator VARCHAR(50),
  Created DATETIME,
  Modifier VARCHAR(50),
  Modified DATETIME,
  BaInstitutionTS BINARY(8)
)
AS
BEGIN
    
  DECLARE @Counted INT;
  SET @Counted = 0;

  DECLARE @Splitted TABLE
  (
    ID INT NOT NULL,
    BaInstitutionTypID INT NOT NULL
  );

  IF (ISNULL(@IdList, '') <> '')
  BEGIN
    INSERT INTO @Splitted (ID, BaInstitutionTypID)
      SELECT ID = FCN.OccurenceID,
             BaInstitutionTypID = CONVERT(INT, FCN.SplitValue)
      FROM dbo.fnSplitStringToValues(@IdList, ',', 1) FCN;
    
    IF (@IsAND = 0)
    BEGIN
      -- OR
      SET @Counted = 1;
    END
    ELSE
    BEGIN
      -- AND
      SELECT @Counted = COUNT(1)
      FROM @Splitted;
    END;
  END;

  INSERT INTO @Result
  SELECT 
    INS.[BaInstitutionID],
    INS.[OrgUnitID],
    INS.[InstitutionNr],
    INS.[BaInstitutionArtCode],
    INS.[Aktiv],
    INS.[Debitor],
    INS.[Kreditor],
    INS.[KeinSerienbrief],
    INS.[ManuelleAnrede],
    INS.[Anrede],
    INS.[Briefanrede],
    INS.[Titel],
    INS.[Name],
    INS.[Vorname],
    INS.[GeschlechtCode],
    INS.[Geburtsdatum],
    INS.[Versichertennummer],
    INS.[Telefon],
    INS.[Telefon2],
    INS.[Telefon3],
    INS.[Fax],
    INS.[EMail],
    INS.[Homepage],
    INS.[SprachCode],
    INS.[Bemerkung],
    INS.[Creator],
    INS.[Created],
    INS.[Modifier],
    INS.[Modified],
    INS.[BaInstitutionTS]
  FROM dbo.BaInstitution INS WITH (READUNCOMMITTED)
  WHERE @Counted <= (SELECT COUNT(1)
                      FROM dbo.BaInstitution_BaInstitutionTyp ITY WITH (READUNCOMMITTED)
                        INNER JOIN @Splitted                  TMP ON TMP.BaInstitutionTypID = ITY.BaInstitutionTypID
                      WHERE ITY.BaInstitutionID = INS.BaInstitutionID);
    
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO
 