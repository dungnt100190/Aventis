SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spQRYKeinFallverlauf;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to get values for query "Kein Fallverlauf"
    @LanguageCode:                The language code to use for ML values
    @OrgUnitID:                   The orgunit to use as filter for result
    @Year:                        The year to use for checking clients (required)
    @UserID:                      The userid to use as filter for result
    @CurrentUserID:               The userid of the user who is currently logged in and using KiSS
    @SpecialRightKostenstelleHS:  Set if the current user has a special right to see more orgunits and users
    @SpecialRightKostenstelleKGS: Set if the current user has a special right to see more orgunits and users
  -
  RETURNS: Result depending on given search parameters for query
=================================================================================================
  TEST:    EXEC dbo.spQRYKeinFallverlauf 1, NULL, 2008, NULL, 2, 1, 1
           EXEC dbo.spQRYKeinFallverlauf 1, 76, 2008, NULL, 2, 1, 1  -- BS Aarau
           EXEC dbo.spQRYKeinFallverlauf 1, 91, 2008, NULL, 2, 1, 1  -- BS Bern-Mittelland
=================================================================================================*/

CREATE PROCEDURE dbo.spQRYKeinFallverlauf
(
  @LanguageCode INT,
  @OrgUnitID INT,
  @Year INT,
  @UserID INT,
  @CurrentUserID INT,
  @SpecialRightKostenstelleHS BIT,
  @SpecialRightKostenstelleKGS BIT
)
AS
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  PRINT ('start call: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- set default values
  -------------------------------------------------------------------------------
  SET @LanguageCode = ISNULL(@LanguageCode, 1);
  
  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  DECLARE @ZeitraumString VARCHAR(100);
  DECLARE @DatumVon DATETIME;
  DECLARE @DatumBis DATETIME;
  
  -------------------------------------------------------------------------------
  -- debug
  -------------------------------------------------------------------------------
  /*
  SET @LanguageCode = 1;
  --SET @OrgUnitID = 26; -- BS Amriswil
  SET @Year = 2008;
  --SET @UserID = 2;
  SET @CurrentUserID = 2;
  SET @SpecialRightKostenstelleHS = 1;
  SET @SpecialRightKostenstelleKGS = 1;
  --*/
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (ISNULL(@Year, -1) < 2000 OR ISNULL(@CurrentUserID, -1) < 1)
  BEGIN
    -- invalid data
    SELECT [Error] = 'Error: Invalid parametes, cannot search data!',
           [BaPersonID$] = NULL;
    
    -- do not continue
    RETURN;
  END;
  
  -- set date vars
  SET @DatumVon = dbo.fnGetDateFromInts(1, 1, @Year);
  SET @DatumBis = dbo.fnGetDateFromInts(31, 12, @Year);
  
  -- set periode
  SET @ZeitraumString = dbo.fnGetZeitraumString(@DatumVon, @DatumBis);
  
  -------------------------------------------------------------------------------
  -- init temp table
  -------------------------------------------------------------------------------
  -- create temp table for BDE entries
  DECLARE @Temp TABLE
  (
    ID$ INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    UserID INT NOT NULL,
    OrgUnitID INT,
    BaPersonID INT NOT NULL,
    BDELeistungsartID INT NOT NULL,
    Datum DATETIME NOT NULL,
    Dauer MONEY NOT NULL
  );
  
  -- create temporary table used to remove non-active clients
  DECLARE @TmpBaPersonIDs TABLE
  (
    BaPersonID INT NOT NULL PRIMARY KEY,
    IsActive BIT NOT NULL DEFAULT(0)
  );
  
  -- create temporary table used to get orgunit of user
  CREATE TABLE #TmpUserIDs
  (
    UserID INT NOT NULL PRIMARY KEY,
    OrgUnitID INT
  );
  
  -- create indexes on temp table
  CREATE INDEX IX_TmpUserIDs_UserIDOrgUnitID ON #TmpUserIDs (UserID, OrgUnitID);
  
  -- create temporary table used to save state if person has valid FV at given date
  CREATE TABLE #TmpFilterNonFV
  (
    ID$ INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    BaPersonID INT NOT NULL,
    Datum DATETIME NOT NULL,
    IsValid BIT NOT NULL DEFAULT(0)
  );
  
  -- create indexes on temp table
  CREATE INDEX IX_TmpFilterNonFV_BaPersonIDDatumIsValid ON #TmpFilterNonFV (BaPersonID, Datum, IsValid);
  
  -- create temp table with grouped entries
  DECLARE @TmpPreOutput TABLE
  (
    BaPersonID INT PRIMARY KEY NOT NULL,
    StundenSB MONEY,
    StundenCM MONEY,
    StundenBW MONEY,
    StundenED MONEY,
    StundenAndere MONEY,
    StundenTotal MONEY,
    FaLeistungIDLastFV INT
  );
  
  -- info
  PRINT ('done init: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- fill temp table with entries
  -------------------------------------------------------------------------------
  INSERT INTO @Temp (UserID, BaPersonID, BDELeistungsartID, Datum, Dauer)
    SELECT UserID            = BDL.UserID,
           BaPersonID        = BDL.BaPersonID,
           BDELeistungsartID = BDL.BDELeistungsartID,
           Datum             = BDL.Datum,
           Dauer             = BDL.Dauer
    FROM dbo.BDELeistung BDL WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = BDL.BaPersonID   -- for current person
                                                          AND LEI.ModulID = 2                   -- only FV
                                                          AND LEI.DatumBis IS NULL              -- open FV at the moment
    WHERE BDL.Datum BETWEEN @DatumVon AND @DatumBis       -- only for current date range
      AND ((@UserID IS NULL) OR (BDL.UserID = @UserID));  -- only for current user (if set)
  
  -- info
  PRINT ('filled temp table with persons: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- remove all persons who are not active client at end date
  -------------------------------------------------------------------------------
  -- get all persons from entries
  INSERT INTO @TmpBaPersonIDs (BaPersonID)
    SELECT DISTINCT
           TMP.BaPersonID
    FROM @Temp TMP;
  
  -- get flag if person is active at end of date range
  UPDATE TMP
  SET TMP.IsActive = ISNULL(dbo.fnFaIsPersonClientByRule(BaPersonID, @DatumBis, 0, 0), -1)  -- get active state for DatumBis
  FROM @TmpBaPersonIDs TMP;
  
  -- remove those who are not active at the moment
  DELETE TMP 
  FROM @Temp TMP
  WHERE EXISTS(SELECT TOP 1 1
               FROM @TmpBaPersonIDs PRS
               WHERE PRS.BaPersonID = TMP.BaPersonID
                 AND PRS.IsActive = 0); -- we want to delete all non active clients
  
  -- info
  PRINT ('removed non active clients: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- filter by search-filter OrgUnitID
  -------------------------------------------------------------------------------
  -- get all users from entries
  INSERT INTO #TmpUserIDs (UserID)
    SELECT DISTINCT
           TMP.UserID
    FROM @Temp TMP;
  
  -- info
  PRINT ('selected all userids: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- get all orgunits of users
  UPDATE TMP
  SET TMP.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(TMP.UserID, 1))
  FROM #TmpUserIDs TMP;
  
  -- info
  PRINT ('updated orgunitids for each userid: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- fill orgunit of user from temp-table
  UPDATE TMP
  SET TMP.OrgUnitID = USR.OrgUnitID
  FROM @Temp TMP
    INNER JOIN #TmpUserIDs USR ON USR.UserID = TMP.UserID;
  
  -- info
  PRINT ('updated orgunitid: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- remove temporary table again
  DROP TABLE #TmpUserIDs;
  
  -- if orgunitid is defined, remove entries that are not for current orgunit
  IF (@OrgUnitID IS NOT NULL)
  BEGIN
    -- remove entries that are not within current orgunit 
    DELETE FROM @Temp
    WHERE ISNULL(OrgUnitID, -1) <> @OrgUnitID;
    
    -- info
    PRINT ('filtered orgunitid: ' + CONVERT(VARCHAR, GETDATE(), 113));
  END;
  
  -------------------------------------------------------------------------------
  -- filter rights-depending users/orgunits
  -------------------------------------------------------------------------------
  -- if user has no HS-special-right, some restrictions are neccessary
  -- same filter as in CtlQueryBaAktiveKlienten_Load
  IF (@SpecialRightKostenstelleHS = 0)
  BEGIN
    IF (@SpecialRightKostenstelleKGS = 0)
    BEGIN
      -- user has NO-special-rights, filter by users
      
      -- init temporary table because of performance
      DECLARE @TmpAllowedUserIDs TABLE
      (
        UserID INT NOT NULL PRIMARY KEY
      );
      
      -- fill temporary table
      INSERT INTO @TmpAllowedUserIDs (UserID)
        SELECT USR.Code
        FROM dbo.fnQryGetMitarbeiterDropDown(@CurrentUserID, @SpecialRightKostenstelleHS, @SpecialRightKostenstelleKGS, 0) USR
        WHERE USR.Code IS NOT NULL;  -- no empty entry
      
      -- user has NO special rights
      -- delete entries from users the current user cannot see (this includes more than orgunit), same procedure as in query-gui
      DELETE FROM @Temp
      WHERE ISNULL(UserID, -1) NOT IN (SELECT USR.UserID
                                       FROM @TmpAllowedUserIDs USR);
      
      -- info
      PRINT ('filtered depending on rights no-kgs: ' + CONVERT(VARCHAR, GETDATE(), 113));
    END
    ELSE
    BEGIN
      -- user has KGS-special-right, filter by orgunit
      
      -- init temporary table because of performance
      DECLARE @TmpAllowedOrgUnitIDs TABLE
      (
        OrgUnitID INT NOT NULL PRIMARY KEY
      );
      
      -- fill temporary table
      INSERT INTO @TmpAllowedOrgUnitIDs (OrgUnitID)
        SELECT ORG.Code
        FROM dbo.fnQryGetKostenstelleDropDown(@CurrentUserID, @SpecialRightKostenstelleHS, @SpecialRightKostenstelleKGS) ORG
        WHERE ORG.Code IS NOT NULL;  -- no empty entry
      
      -- user has special rights and can see more orgunits and users
      -- delete entries from orgunits the user cannot see (this includes non KGS-users), same procedure as in query-gui
      DELETE FROM @Temp
      WHERE ISNULL(OrgUnitID, -1) NOT IN (SELECT ORG.OrgUnitID
                                          FROM @TmpAllowedOrgUnitIDs ORG);
      
      -- info
      PRINT ('filtered depending on rights kgs: ' + CONVERT(VARCHAR, GETDATE(), 113));
    END;
  END;
  
  -------------------------------------------------------------------------------
  -- remove entries that have valid FV at given date
  -------------------------------------------------------------------------------
  -- insert into temp table
  INSERT INTO #TmpFilterNonFV (BaPersonID, Datum)
    SELECT DISTINCT
           BaPersonID = TMP.BaPersonID,
           Datum      = TMP.Datum
    FROM @Temp TMP;
  
  -- info
  PRINT ('selected bapersonid and datum: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- set flags in temp table
  UPDATE TMP
  SET TMP.IsValid = CASE 
                      WHEN EXISTS(SELECT TOP 1 1
                                  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                  WHERE LEI.BaPersonID = TMP.BaPersonID                   -- current person
                                    AND LEI.ModulID = 2                                   -- only FV
                                    AND LEI.DatumVon <= TMP.Datum                         -- only those who started with or before given date
                                    AND ISNULL(LEI.DatumBis, '9999-12-31') >= TMP.Datum)  -- only those who ended after given date (if already ended)
                        THEN 1  -- valid, open FV at given date
                      ELSE 0    -- invalid, no open FV at given date
                    END
  FROM #TmpFilterNonFV TMP;
  
  -- info
  PRINT ('set flag isvalid for each bapersonid and datum: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- remove those entries of persons who have valid FV at given date
  DELETE TMP 
  FROM @Temp TMP
    INNER JOIN #TmpFilterNonFV FNF ON FNF.BaPersonID = TMP.BaPersonID     -- current person
                                  AND FNF.Datum = TMP.Datum               -- current date
                                  AND FNF.IsValid = 1;                    -- valid entry
  
  -- info
  PRINT ('removed entries with valid FV: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- remove temporary table again
  DROP TABLE #TmpFilterNonFV;
  
  -------------------------------------------------------------------------------
  -- fill temp table with grouped entries
  -------------------------------------------------------------------------------
  INSERT INTO @TmpPreOutput (BaPersonID, StundenSB, StundenCM, StundenBW, StundenED, StundenAndere)
    SELECT BaPersonID = TMP.BaPersonID,
           --
           StundenSB     = ISNULL(SUM(CASE 
                                        WHEN LAR.AuswDienstleistungCode = 0 THEN TMP.Dauer    -- only SB
                                        ELSE 0.0
                                      END), 0.0),
           StundenCM     = ISNULL(SUM(CASE 
                                        WHEN LAR.AuswDienstleistungCode = 1 THEN TMP.Dauer    -- only CM
                                        ELSE 0.0
                                      END), 0.0),
           StundenBW     = ISNULL(SUM(CASE 
                                        WHEN LAR.AuswDienstleistungCode = 2 THEN TMP.Dauer    -- only BW
                                        ELSE 0.0
                                      END), 0.0),
           StundenED     = ISNULL(SUM(CASE 
                                        WHEN LAR.AuswDienstleistungCode = 3 THEN TMP.Dauer    -- only ED
                                        ELSE 0.0
                                      END), 0.0),
           --
           StundenAndere = ISNULL(SUM(CASE 
                                        WHEN LAR.AuswDienstleistungCode IN (0, 1, 2, 3) THEN 0.0 -- only others
                                        ELSE TMP.Dauer
                                      END), 0.0)
    FROM @Temp TMP
      INNER JOIN dbo.BDELeistungsart LAR WITH (READUNCOMMITTED) ON LAR.BDELeistungsartID = TMP.BDELeistungsartID
    GROUP BY TMP.BaPersonID;
  
  -- info
  PRINT ('grouped entries to modules: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- update total hours
  -------------------------------------------------------------------------------
  UPDATE TMP
  SET TMP.StundenTotal = ISNULL(TMP.StundenSB, 0.0) + ISNULL(TMP.StundenCM, 0.0) + 
                         ISNULL(TMP.StundenBW, 0.0) + ISNULL(TMP.StundenED, 0.0) +
                         ISNULL(TMP.StundenAndere, 0.0)
  FROM @TmpPreOutput TMP;
  
  -- info
  PRINT ('updated total hours: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- get last FV entry
  -------------------------------------------------------------------------------
  UPDATE TMP
  SET TMP.FaLeistungIDLastFV = dbo.fnFaGetLastFaLeistungID(TMP.BaPersonID, 2) -- only FV
  FROM @TmpPreOutput TMP;
  
  -- info
  PRINT ('updated last FV FaLeistungID: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- done with init
  -------------------------------------------------------------------------------
  -- info
  PRINT ('done with init, do output now: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  --=============================================================================
  -- OUTPUT
  --=============================================================================
  
  -------------------------------------------------------------------------------
  -- output default
  -------------------------------------------------------------------------------
  SELECT [BaPersonID$]           = PRS.BaPersonID,
         [Nr.]                   = PRS.BaPersonID,
         [Name]                  = PRS.Name,
         [Vorname]               = PRS.Vorname,
         [Geschlecht]            = dbo.fnGetGenderMLTitleMF(PRS.GeschlechtCode, @LanguageCode),
         [Geb.Dat.]              = PRS.Geburtsdatum,
         [Vers.-Nr.]             = PRS.VersichertenNummer,
         [Ort]                   = dbo.fnGetAdressText(PRS.BaPersonID, 0, 0),
         [Land]                  = dbo.fnLandMLText(ADRW.BaLandID, @LanguageCode),
         [Nationalität]          = dbo.fnLandMLText(PRS.NationalitaetCode, @LanguageCode),
         [Hauptbehinderungsart]  = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode),
         [IV Berechtigung]       = dbo.fnGetLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(PRS.BaPersonID, @DatumBis, 0), @LanguageCode), -- search by final date of period
         --
         [Kostenstelle]          = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),         -- of user who is responsible for last FV
         [Verantwortliche/r FV]  = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),                          -- user who is responsible for last FV
         --
         [Eröffnung FV]          = CASE 
                                     WHEN LEI.DatumVon < @DatumVon OR LEI.DatumVon > @DatumBis THEN NULL -- show only if within current date range
                                     ELSE LEI.DatumVon
                                   END,
         [Abschluss FV]          = CASE 
                                     WHEN ISNULL(LEI.DatumBis, '9999-12-31') < @DatumVon OR ISNULL(LEI.DatumBis, '9999-12-31') > @DatumBis THEN NULL -- show only if within current date range
                                     ELSE LEI.DatumBis
                                   END,
         --
         [Stunden SB]            = TMP.StundenSB,
         [Stunden CM]            = TMP.StundenCM,
         [Stunden BW]            = TMP.StundenBW,
         [Stunden ED]            = TMP.StundenED,
         [Total Stunden]         = TMP.StundenTotal,
         --
         [Zeitraum]              = @ZeitraumString
  FROM @TmpPreOutput          TMP
    INNER JOIN dbo.BaPerson   PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
    INNER JOIN dbo.FaLeistung LEI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TMP.FaLeistungIDLastFV
    LEFT  JOIN dbo.XOrgUnit   ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(LEI.UserID, 1))
    
    -- wohnsitz
    LEFT JOIN dbo.BaAdresse   ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
  ORDER BY [Name], [Vorname], [BaPersonID$];
  
  -- info
  PRINT ('done output: ' + CONVERT(VARCHAR, GETDATE(), 113));
END;
GO
