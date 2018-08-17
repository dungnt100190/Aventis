SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetBaInstitutionTypen;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get all assigned BaInstitutionTyp-s of the given BaInstitutionID either as codes or
           text in given language
    @BaInstitutionID: The id of the BaInstitution record
    @ReturnIDs:       Flag if IDs have to be returned (BaInstitutionTypIDs) or the names of the
                      assigned types
                      - 0: Return names in given language
                      - 1: Return ids
    @Delimiter:       The delimiter to use for combining values
    @UserID:          The id of the user who wants to get the types (restricted rights)
    @LanguageCode:    The language code to use when returning type names
  -
  RETURNS: Return combined types separated with given delimiter or 
           NULL if nothing found/no types are assigend
=================================================================================================
  TEST:    SELECT dbo.fnBaGetBaInstitutionTypen(3, 0, '; ', 2, 1);
           SELECT dbo.fnBaGetBaInstitutionTypen(15855, 1, ';', 2, 1);
           SELECT dbo.fnBaGetBaInstitutionTypen(15855, 0, ';', 2, 1);
           SELECT dbo.fnBaGetBaInstitutionTypen(3, 1, ',', 2, 1);
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetBaInstitutionTypen
(
  @BaInstitutionID INT = -1,
  @ReturnIDs BIT = 0,
  @Delimiter VARCHAR(10) = ',',
  @UserID INT,
  @LanguageCode INT = 1
)
RETURNS VARCHAR(8000)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @Output VARCHAR(4000);
  DECLARE @OrgUnitIsMustField BIT;
  
  DECLARE @Types TABLE
  (
    BaInstitutionTypID INT NOT NULL PRIMARY KEY,
    OrgUnitID INT NULL,
    Name VARCHAR(255) NOT NULL,
    NameTID INT NULL
  )
  
  SET @OrgUnitIsMustField = CONVERT(BIT, ISNULL(dbo.fnXConfig('System\Basis\AbteilungAufInstAlsMussfeld', GETDATE()), 0));
  
  -----------------------------------------------------------------------------
  -- get data
  -----------------------------------------------------------------------------
  INSERT INTO @Types (BaInstitutionTypID, OrgUnitID, Name, NameTID)
    SELECT BaInstitutionTypID = ITY.BaInstitutionTypID,
           OrgUnitID          = ITY.OrgUnitID,
           Name               = ITY.Name, 
           NameTID            = ITY.NameTID
    FROM dbo.BaInstitution_BaInstitutionTyp             BTY WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaInstitutionTyp                   ITY WITH (READUNCOMMITTED) ON ITY.BaInstitutionTypID = BTY.BaInstitutionTypID
                                                                                  AND ITY.Aktiv = 1     -- only active types!
    WHERE BTY.BaInstitutionID = @BaInstitutionID;
  
  -----------------------------------------------------------------------------
  -- get items depending on type with OrgUnitID filter
  -- > in fnGetInstStammUserORGList the flag @OrgUnitIsMustField is evaluated
  --   if the flag is 0, all orgunits can be seen and therefore the filter is
  --   not neccessary. we are a lot faster without filtering - if not needed.
  -----------------------------------------------------------------------------
  IF (@OrgUnitIsMustField = 1)
  BEGIN
    -- with orgunit filter
    IF (@ReturnIDs = 0)
    BEGIN
      -- get output by name-text
      SELECT @Output = STUFF((SELECT CONVERT(VARCHAR(4000), SUB.[Name])
                              FROM (SELECT [Name] = @Delimiter + dbo.fnGetMLTextByDefault(TMP.NameTID, @LanguageCode, TMP.Name)
                                    FROM @Types TMP
                                    WHERE (TMP.OrgUnitID IS NULL OR TMP.OrgUnitID IN (SELECT ORG.OrgUnitID
                                                                                      FROM dbo.fnGetInstStammUserORGList(@UserID) ORG)) -- only types the user is allowed to see
                                   ) AS SUB
                              ORDER BY SUB.[Name]
                              FOR XML PATH('')), 1, LEN(@Delimiter), '');
    END
    ELSE
    BEGIN
      -- get output by ids
      SELECT @Output = STUFF((SELECT CONVERT(VARCHAR(4000), SUB.[Code])
                              FROM (SELECT [Code] = @Delimiter + CONVERT(VARCHAR(20), TMP.BaInstitutionTypID)
                                    FROM @Types TMP
                                    WHERE (TMP.OrgUnitID IS NULL OR TMP.OrgUnitID IN (SELECT ORG.OrgUnitID
                                                                                      FROM dbo.fnGetInstStammUserORGList(@UserID) ORG)) -- only types the user is allowed to see
                                   ) AS SUB
                              FOR XML PATH('')), 1, LEN(@Delimiter), '');
    END;
  END;
  ELSE
  BEGIN
    -- without orgunit filter
    IF (@ReturnIDs = 0)
    BEGIN
      -- get output by name-text
      SELECT @Output = STUFF((SELECT CONVERT(VARCHAR(4000), SUB.[Name])
                              FROM (SELECT [Name] = @Delimiter + dbo.fnGetMLTextByDefault(TMP.NameTID, @LanguageCode, TMP.Name)
                                    FROM @Types TMP) AS SUB
                              ORDER BY SUB.[Name]
                              FOR XML PATH('')), 1, LEN(@Delimiter), '');
    END
    ELSE
    BEGIN
      -- get output by ids
      SELECT @Output = STUFF((SELECT CONVERT(VARCHAR(4000), SUB.[Code])
                              FROM (SELECT [Code] = @Delimiter + CONVERT(VARCHAR(20), TMP.BaInstitutionTypID)
                                    FROM @Types TMP) AS SUB
                              FOR XML PATH('')), 1, LEN(@Delimiter), '');
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN LTRIM(RTRIM(@Output));
END;
GO