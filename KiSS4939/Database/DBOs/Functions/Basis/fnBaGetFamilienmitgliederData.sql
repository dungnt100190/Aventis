SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetFamilienmitgliederData;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Basis/fnBaGetFamilienmitgliederData.sql $
  $Author: Cjaeggi $
  $Modtime: 19.08.10 20:44 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get data about family related persons depending on age and home
   @BaPersonID:   The id of the person to use to get relation data
   @ReturnMode    The mode to use for getting specific data
                  - 'elternteil1': if age of BaPersonID < 18 it's monther if existing otherwise father
                                   else it's the man of a woman or woman of a man
                  - 'elternteil2': if age of BaPersonID < 18 it's the father (if having a mother)
                                   else ''
                  - 'kind1':       if age of BaPersonID < 18 it's the oldest brother/sister
                                   else the oldest child
                  - 'kind2', 'kind3', 'kind4', kind5', kind6': the younger siblings ASC or children ASC
   @LanguageCode: The id of the person to use to get relation data
  -
  RETURNS: The output depending on returnmode as "Name, FirstName, AgeGroup
  -
  TEST:    SELECT dbo.fnBaGetFamilienmitgliederData(58866, 'elternteil1', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(58866, 'elternteil2', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(58866, 'kind1', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(58866, 'kind2', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(58866, 'kind3', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(58866, 'kind4', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(58866, 'kind5', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(58866, 'kind6', 1)
           --
           SELECT dbo.fnBaGetFamilienmitgliederData(87179, 'elternteil1', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(87179, 'elternteil2', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(87179, 'kind1', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(87179, 'kind2', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(87179, 'kind3', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(87179, 'kind4', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(87179, 'kind5', 1)
           SELECT dbo.fnBaGetFamilienmitgliederData(87179, 'kind6', 1)
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Basis/fnBaGetFamilienmitgliederData.sql $
 * 
 * 3     19.08.10 20:45 Cjaeggi
 * #6109: Fixed after changes of Gleicher Haushalt
 * 
 * 2     7.01.10 9:07 Lloreggia
 * 
 * 1     6.10.09 10:00 Cjaeggi
 * #4796: Added new function for new bookmarks
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetFamilienmitgliederData
(
  @BaPersonID INT,
  @ReturnMode VARCHAR(20),
  @LanguageCode INT
)
RETURNS VARCHAR(255)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@BaPersonID, -1) < 1 OR ISNULL(@ReturnMode, '') = '')
  BEGIN
    -- invalid data, do not continue
    RETURN '';
  END;
  
  -----------------------------------------------------------------------------
  -- set defaults
  -----------------------------------------------------------------------------
  SET @LanguageCode = ISNULL(@LanguageCode, 1);    -- default is german
  
  -----------------------------------------------------------------------------
  -- init underage var
  -----------------------------------------------------------------------------
  -- declare var
  DECLARE @IsUnderAge BIT;
  DECLARE @GenderCode INT;
  
  -- set default value
  SET @IsUnderAge = NULL;
  SET @GenderCode = NULL;    -- 1=m, 2=w
  
  -- set underage var (if no birthday: is treated as major)
  SELECT @IsUnderAge = CASE 
                         WHEN ISNULL(dbo.fnDateOf(PRS.Geburtsdatum), '1753-01-01') <= DATEADD(year, -18, GETDATE()) THEN 0
                         ELSE 1 -- under age
                       END,
         @GenderCode = PRS.GeschlechtCode
  FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
  WHERE PRS.BaPersonID = @BaPersonID;
  
  -- validate
  IF (@IsUnderAge IS NULL)
  BEGIN
    -- person not found, do not continue
    RETURN '';
  END;
  
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  -- init return value
  DECLARE @ReturnValue VARCHAR(255);
  SET @ReturnValue = NULL;
  
  -- init temp table
  DECLARE @TmpRelations TABLE
  (
    ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    BaRelationID INT NOT NULL,
    KissRelationID INT NOT NULL,
    BaPersonID INT NOT NULL,
    NameVornameJahrgang VARCHAR(255) NOT NULL,
    GeschlechtCode INT,
    Geburtsdatum DATETIME
  );
  
  -----------------------------------------------------------------------------
  -- collect data for all required relations
  -----------------------------------------------------------------------------
  INSERT INTO @TmpRelations(BaRelationID, KissRelationID, BaPersonID, NameVornameJahrgang, GeschlechtCode, Geburtsdatum)
    SELECT BaRelationID        = BRL.BaRelationID,
           KissRelationID      = BRL.BaRelationID +
                                 CASE 
                                   WHEN BRE.BaPersonID_1 = @BaPersonID AND (BRL.NameWeiblich1 <> BRL.NameWeiblich2 OR BRL.NameMaennlich1 <> BRL.NameMaennlich2)
                                   THEN 1000
                                   ELSE 0
                                 END +
                                 CASE PRS.GeschlechtCode 
                                   WHEN 1 THEN 100
                                   WHEN 2 THEN 200
                                   ELSE 0
                                 END,
           BaPersonID          = PRS.BaPersonID,
           NameVornameJahrgang = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + ISNULL(', ' + CONVERT(VARCHAR, YEAR(PRS.Geburtsdatum)), ''),
           GeschlechtCode      = PRS.GeschlechtCode,
           Geburtsdatum        = ISNULL(PRS.Geburtsdatum, '9999-12-31')           -- max datum, to have those without at last of order
  FROM dbo.BaPerson_Relation  BRE WITH (READUNCOMMITTED)
    INNER JOIN dbo.BaPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID IN (BRE.BaPersonID_1, BRE.BaPersonID_2)
    LEFT  JOIN dbo.BaRelation BRL WITH (READUNCOMMITTED) ON BRL.BaRelationID = BRE.BaRelationID
  WHERE dbo.fnBaGleicheAdresse(@BaPersonID, PRS.BaPersonID, 1, NULL) = 1          -- required to have persons within same home (wohnsitz)
    AND BRL.BaRelationID IN (1, 3, 7)                                             -- 1=Ehemann/Ehefrau, 3=Vater/Mutter/Sohn/Tochter, 7=Bruder/Schwester
    AND (BRE.BaPersonID_1 = @BaPersonID OR BRE.BaPersonID_2 = @BaPersonID)
    AND PRS.BaPersonID != @BaPersonID
  ORDER BY Geburtsdatum ASC, NameVornameJahrgang ASC;
  
  -----------------------------------------------------------------------------
  -- get output depending on given resultmode
  -----------------------------------------------------------------------------
  IF (@ReturnMode = 'elternteil1')
  BEGIN
    ---------------------------------------------------------------------------
    -- if person is underage: first priority is the mother, otherwise the father
    -- if person is major:    the wife if person is a man, otherwise the husband
    ---------------------------------------------------------------------------
    SELECT TOP 1 
           @ReturnValue = TMP.NameVornameJahrgang
    FROM @TmpRelations TMP
    WHERE (@IsUnderAge = 1 AND TMP.KissRelationID IN (3, 103, 203))                      -- underage: show 3=vater/mutter;103=vater;203=mutter
       OR (@IsUnderAge = 0 AND TMP.KissRelationID IN (1, 101, 201))                      -- major:    show 1=ehepartner/in;101=ehemann;201=ehefrau
    --
    ORDER BY CASE 
               WHEN @IsUnderAge = 1 THEN CASE 
                                           WHEN TMP.KissRelationID = 203 THEN 1          -- underage: first prio=mutter
                                           WHEN TMP.KissRelationID = 103 THEN 2          -- underage: second prio=vater
                                           WHEN TMP.KissRelationID =   3 THEN 3          -- underage: third prio=vater/mutter
                                           ELSE 4                                        -- underage: anything else
                                         END
               ELSE CASE 
                      WHEN @GenderCode = 1 THEN CASE 
                                                  WHEN TMP.KissRelationID = 201 THEN 1   -- major man: first prio=wife
                                                  ELSE 2                                 -- major man: anything else
                                                  END
                      WHEN @GenderCode = 2 THEN CASE 
                                                  WHEN TMP.KissRelationID = 101 THEN 1   -- major woman: first prio=man
                                                  ELSE 2                                 -- major woman: anything else
                                                END
                      ELSE CASE 
                             WHEN TMP.KissRelationID = 1 THEN 1                          -- major unknown: first prio=ehepartner/in
                             ELSE 2                                                      -- major unknown: anything else
                           END
                    END -- [@GenderCode]
             END; -- [@IsUnderAge1]
    ---------------------------------------------------------------------------
  END
  ELSE IF (@ReturnMode = 'elternteil2')
  BEGIN
    ---------------------------------------------------------------------------
    -- if person is underage: the father if having a mother
    -- if person is major:    ''
    ---------------------------------------------------------------------------
    IF (@IsUnderAge = 1)
    BEGIN
      SELECT TOP 1 
             @ReturnValue = TMP.NameVornameJahrgang
      FROM @TmpRelations TMP
      WHERE TMP.KissRelationID = 103 AND -- vater only
            EXISTS (SELECT TOP 1 1
                    FROM @TmpRelations SUB
                    WHERE SUB.KissRelationID = 203); -- mutter
    END
    ---------------------------------------------------------------------------
  END
  ELSE IF (@ReturnMode IN ('kind1', 'kind2', 'kind3', 'kind4', 'kind5', 'kind6'))
  BEGIN
    ---------------------------------------------------------------------------
    -- if person is underage: the siblings (oldest first)
    -- if person is major:    the children (oldest first)
    ---------------------------------------------------------------------------
    SELECT TOP 1 
           @ReturnValue = RES.NameVornameJahrgang
    FROM (SELECT RankNo = RANK() OVER (ORDER BY TMP.Geburtsdatum ASC, TMP.NameVornameJahrgang),   -- do ordering here (oldest first)
                 TMP.Geburtsdatum,
                 TMP.NameVornameJahrgang
          FROM @TmpRelations TMP
          WHERE (@IsUnderAge = 1 AND TMP.KissRelationID IN (7, 107, 207)) OR       -- underage: show 7=bruder/schwester;107=bruder;207=schwester
                (@IsUnderAge = 0 AND TMP.KissRelationID IN (1003, 1103, 1203))     -- major:    show 1003=kind;1103=sohn;1203=tochter
          ) RES
    WHERE RES.RankNo = CASE 
                         WHEN @ReturnMode = 'kind1' THEN 1
                         WHEN @ReturnMode = 'kind2' THEN 2
                         WHEN @ReturnMode = 'kind3' THEN 3
                         WHEN @ReturnMode = 'kind4' THEN 4
                         WHEN @ReturnMode = 'kind5' THEN 5
                         WHEN @ReturnMode = 'kind6' THEN 6
                         ELSE -1
                       END;
    ---------------------------------------------------------------------------
  END;
  
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN ISNULL(@ReturnValue, '');
END
