SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaGetTreeFallNavigator
GO
/*===============================================================================================
  $Revision: 8$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .

=================================================================================================*/

CREATE PROCEDURE [dbo].[spFaGetTreeFallNavigator]
 (@UserID       INT,

  @Active       BIT = 1,
  @Closed       BIT = 0,
  @Archived     BIT = 0,

  @IncludeGroup BIT = 0,
  @IncludeGuest BIT = 0,

  @OrgUnitID    INT = NULL)
AS BEGIN
  SET NOCOUNT ON

  CREATE TABLE #tree (
    ID                     VARCHAR(20) DEFAULT(''),
    ParentID               VARCHAR(20),
    Type                   VARCHAR(6) DEFAULT('P'),
    IconID                 INT DEFAULT(-1),
    Name                   VARCHAR(100),
    BaPersonID             INT DEFAULT(0),
    UserID                 INT DEFAULT(0),
    OrgUnitID              INT,
    Zusatz                 VARCHAR(100),
    Teilleistungserbringer VARCHAR(255)
    PRIMARY KEY (Type, UserID, BaPersonID, ID)
  );

  /***************************************************************************/
  /***  Mitarbeiter                                                        ***/
  /***************************************************************************/
  DECLARE @Users TABLE (UserID int PRIMARY KEY);

  -- Benutzer selbst
  INSERT @Users VALUES (@UserID);

  -- zusäzliche Benutzer (gleiche Abteilung, Abteilungs-Gastrecht)
  IF (@IncludeGroup = 1 OR @IncludeGuest = 1)
  BEGIN
    INSERT INTO @Users
      SELECT DISTINCT B.UserID
      FROM dbo.XOrgUnit_User          A WITH (READUNCOMMITTED)
        INNER JOIN dbo.XOrgUnit_User  B WITH (READUNCOMMITTED) ON B.OrgUnitID = A.OrgUnitID AND B.UserID <> @UserID
                                                              AND B.OrgUnitMemberCode = 2
      WHERE A.UserID = @UserID
        AND (    (@IncludeGroup = 1 AND A.OrgUnitMemberCode IN (1, 2))
              OR (@IncludeGuest = 1 AND A.OrgUnitMemberCode IN (3))
            );
  END;

  /***************************************************************************/
  /***  Fälle                                                              ***/
  /***************************************************************************/
  CREATE TABLE #Fall (
    UserID      INT NOT NULL,
    BaPersonID  INT NOT NULL,
    IconID      INT NOT NULL
    PRIMARY KEY (UserID, BaPersonID, IconID)
  );

  -- Fallträger / Leistungsträger, Gastrecht auf OrgUnit
  INSERT INTO #Fall
    SELECT FLE.UserID, FAL.BaPersonID,
      IconID = MIN(
        CASE
          WHEN IsNull(FAL.UserID, @UserID) = @UserID  THEN 102 -- Fallträger
          WHEN FLE.UserID = @UserID                   THEN 103 -- Leistungsträger
          ELSE 105                                             -- Gastrecht auf OrgUnit
        END)
    FROM dbo.FaLeistung                    FLE WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaFall                FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = FLE.FaFallID
      LEFT OUTER JOIN dbo.FaLeistungArchiv ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
    WHERE EXISTS (SELECT TOP 1 1 FROM @Users WHERE FLE.UserID = UserID)
      AND (    (@Active   = 1 AND FLE.DatumBis IS NULL)
            OR (@Closed   = 1 AND FLE.DatumBis IS NOT NULL AND ARC.FaLeistungID IS NULL)
            OR (@Archived = 1 AND FLE.DatumBis IS NOT NULL AND ARC.FaLeistungID IS NOT NULL)
          )
    GROUP BY FLE.UserID, FAL.BaPersonID;

  -- Gastrecht auf Leistungen
  INSERT INTO #Fall
    SELECT DISTINCT @UserID, FAL.BaPersonID, 104
    FROM dbo.FaLeistung                FLE WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaFall            FAL WITH (READUNCOMMITTED) ON FAL.FaFallID = FLE.FaFallID
      INNER JOIN dbo.FaLeistungZugriff FAZ WITH (READUNCOMMITTED) ON FAZ.FaLeistungID = FLE.FaLeistungID AND FAZ.UserID = @UserID
      LEFT OUTER JOIN dbo.FaLeistungArchiv   ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
    WHERE NOT EXISTS (SELECT TOP 1 1 FROM #Fall WHERE UserID = @UserID AND BaPersonID = FAL.BaPersonID)
      AND (    (@Active   = 1 AND FLE.DatumBis IS NULL)
            OR (@Closed   = 1 AND FLE.DatumBis IS NOT NULL AND ARC.FaLeistungID IS NULL)
            OR (@Archived = 1 AND FLE.DatumBis IS NOT NULL AND ARC.FaLeistungID IS NOT NULL)
          );

  -- zusäzliche Benutzer mit Fall-Gastrecht
  IF (@IncludeGuest = 1)
  BEGIN
    INSERT @Users
      SELECT FAL.UserID
      FROM #Fall  FAL
      WHERE NOT EXISTS (SELECT * FROM @Users WHERE UserID = FAL.UserID);
  END;

  INSERT INTO #tree (ID, ParentID, Type, BaPersonID, UserID, IconID)
    SELECT DISTINCT
      ID             = 'P' + CONVERT(VARCHAR, FAL.BaPersonID) + '_' + CONVERT(VARCHAR, FAL.UserID),
      ParentID       = 'E' + CONVERT(VARCHAR, FAL.UserID),
      Type           = 'P',
      FAL.BaPersonID,
      FAL.UserID,
      IconID         = FAL.IconID
    FROM #Fall FAL;

  DECLARE @sql_1 NVARCHAR(4000),
          @sql_2 NVARCHAR(4000);

  DECLARE cModul CURSOR FAST_FORWARD FOR
    SELECT
      SQL_1 = 'ALTER TABLE #tree ADD [' + MOD.ShortName + '] int DEFAULT(-1)',
      SQL_2 = 'UPDATE  TRE
               SET [' + MOD.ShortName + '] = ' + CONVERT(varchar, 100 * MOD.ModulID + 1000) +
              CASE
                WHEN MOD.ModulID = 1 THEN ' + 1,
                  BaPersonID = PRS.BaPersonID,
                  Name       = PRS.Name + IsNull('' '' + PRS.Vorname, '''')
               FROM #tree             TRE
                 INNER JOIN dbo.BaPerson  PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = TRE.BaPersonID
               WHERE TRE.Type = ''P'''
                ELSE ' + IsNull(TMP.OffSet, 0)
               FROM #tree                 TRE
                 LEFT  JOIN (SELECT FAL.BaPersonID,
                             OffSet = MIN(CASE
                                            WHEN ARC.FaLeistungID IS NOT NULL  THEN 3
                                            WHEN FLE.DatumBis IS NOT NULL      THEN 2
                                            ELSE 1
                                          END)
                             FROM #Fall                     TMP
                               INNER JOIN dbo.FaFall            FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = TMP.BaPersonID
                               INNER JOIN dbo.FaLeistung        FLE WITH (READUNCOMMITTED) ON FLE.FaFallID = FAL.FaFallID
                               LEFT  JOIN dbo.FaLeistungArchiv  ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
                             WHERE FLE.ModulID = ' + CONVERT(varchar, MOD.ModulID) + '
                             GROUP BY FAL.BaPersonID) TMP ON TMP.BaPersonID = TRE.BaPersonID
               WHERE TRE.Type = ''P'''
              END
    FROM dbo.XModul MOD WITH (READUNCOMMITTED)
    WHERE ModulTree = 1 AND MOD.ShortName IS NOT NULL
  ORDER BY SortKey;

  OPEN cModul;
  WHILE (1 = 1)
  BEGIN
    FETCH NEXT FROM cModul INTO @sql_1, @sql_2;
    IF (@@FETCH_STATUS < 0)
    BEGIN
      BREAK;
    END;

    EXECUTE sp_executesql @sql_1;
    EXECUTE sp_executesql @sql_2;
  END;
  CLOSE cModul;
  DEALLOCATE cModul;

  -- KES-Massnahmen in Zusatz erwähnen
  UPDATE TRE
    SET Zusatz = 'KESMx'
  FROM #Tree                  TRE
    INNER JOIN dbo.FaFall     FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = TRE.BaPersonID
    INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL.FaFallID
                                                        AND LEI.FaProzessCode = 210
                                                        AND LEI.DatumBis IS NOT NULL;
  UPDATE TRE
    SET Zusatz = 'KESM'
  FROM #Tree                  TRE
    INNER JOIN dbo.FaFall     FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = TRE.BaPersonID
    INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL.FaFallID
                                                        AND LEI.FaProzessCode = 210
                                                        AND LEI.DatumBis IS NULL;

  -- nur Teilleistungserbringer aktiv
  UPDATE TRE
    SET Teilleistungserbringer = dbo.fnLOVColumnListe('FaTeilleistungserbringer', LEI.FaTeilleistungserbringerCodes, 'Value1')
  FROM #Tree TRE
    INNER JOIN dbo.FaFall     FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = TRE.BaPersonID
    INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaFallID = FAL.FaFallID
                                                        AND LEI.FaProzessCode = 200;

  /***************************************************************************/
  /***  Organisationsstruktur                                              ***/
  /***************************************************************************/
  -- User ohne Fälle löschen
  DELETE USR
  FROM @Users USR
  WHERE USR.UserID <> @UserID
    AND NOT EXISTS (SELECT TOP 1 1 FROM #tree WHERE Type = 'P' AND UserID = USR.UserID);

  -- Employee
  INSERT INTO #tree (ID, ParentID, Type, Name, UserID, OrgUnitID, IconID)
    SELECT ID       = 'E' + CONVERT(varchar, USR.UserID),
      ParentID      = 'O' + CONVERT(varchar, ORG.OrgUnitID),
      Type          = 'E',
      Name          = USR.LastName + IsNull(', ' + USR.FirstName,''),
      UserID        = USR.UserID,
      OrgUnitID     = ORG.OrgUnitID,
      101
    FROM @Users                         U
      INNER JOIN dbo.XUser              USR WITH (READUNCOMMITTED) ON USR.UserID = U.UserID
      LEFT OUTER JOIN dbo.XOrgUnit_User ORU WITH (READUNCOMMITTED) ON ORU.UserID = USR.UserID AND ORU.OrgUnitMemberCode = 2 -- Mitglied
      LEFT OUTER JOIN dbo.XOrgUnit      ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = ORU.OrgUnitID

  -- Organisationsstrucktur
  IF (@IncludeGroup = 1 OR @IncludeGuest = 1)
  BEGIN
    DECLARE @FirstRun BIT;
    SET @FirstRun = 1;

    WHILE (@FirstRun = 1 OR @@ROWCOUNT > 0)
    BEGIN
      SET @FirstRun = 0;
      INSERT #tree (ID, ParentID, Type, Name, OrgUnitID, IconID)
        SELECT DISTINCT
          ID        = 'O' + CONVERT(varchar, ORG.OrgUnitID),
          ParentID  = 'O' + CONVERT(varchar, ORG.ParentID),
          Type      = 'O',
          Name      = ORG.ItemName,
          OrgUnitID = ORG.ParentID,
          IconID    = 100
        FROM dbo.XOrgUnit        ORG WITH (READUNCOMMITTED)
          INNER JOIN #tree T1 ON T1.Type <> 'P' AND T1.ParentID = 'O' + CONVERT(varchar, ORG.OrgUnitID)
          LEFT  JOIN #tree T2 ON T2.Type = 'O'  AND T2.ID = 'O' + CONVERT(varchar, ORG.OrgUnitID)
        WHERE T1.ParentID LIKE 'O%' AND T2.ID IS NULL;
    END;
  END;

  SELECT TRE.*,
    PersonCount = (SELECT COUNT(*) FROM #Fall)
  FROM #tree               TRE
    LEFT JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = TRE.BaPersonID
  ORDER BY
    CASE Type
      WHEN 'O' THEN 1
      WHEN 'E' THEN 2
      WHEN 'P' THEN 3
      ELSE 4
    END,
    TRE.NAME;

  DROP TABLE #Fall;
  DROP TABLE #tree;
END;
GO
