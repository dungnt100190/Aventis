SET QUOTED_IDENTIFIER ON;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spQRYLaufendeAbgeschlosseneDossiers;
GO
/*===============================================================================================
  $Revision: 24 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to get values for query "Laufende Dossiers" and "Abgeschlossene Dossiers"
    @LanguageCode:                The language code to use for ML values
    @OrgUnitID:                   The orgunit to use as filter for result
    @ZeitraumVon:                 The start of datespan to use (required)
    @ZeitraumBis:                 The end of datespan to use (required)
    @UserID:                      The userid to use as filter for result
    @HauptbehinderungsartCode:    The code to use for filter of persons
    @BSVBehinderungsartCode:      The code to use for filter of persons
    @IVBerechtigungsCode:         The code to use for filter of persons
    @GeburtVon:                   The start range for birthday-date to use for filter of persons
    @GeburtBis:                   The start range for birthday-date to use for filter of persons
    @ResultTable:                 The desired result table to generate
                                  - 'klient'
                                  - 'hauptbehinderung'
                                  - 'mitarbeiter'
                                  - 'kostenstelle'
    @CurrentUserID:               The userid of the user who is currently logged in and using KiSS
    @SpecialRightKostenstelleKGS: Set if the current user has a special right to see more orgunits and users
    @OpenCases:                   Set if only open or only closed cases have to be displayed (1=only open, 0=only closed)
    @OnlyWithNoFollowingFV:       Only if @OpenCases = 0: If this option is true, only data with no following FV will be taken
                                  (1=only persons with last defined FV will be displayed, 0=it doesn't matter if after @ZeitraumBis a FV exists)
  -
  RETURNS: Result depending on given search parameters and ResultTable
=================================================================================================
  TEST:    EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, NULL, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'klient', 2, 1, 1, 1, 0
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, NULL, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'mitarbeiter', 2, 1, 1, 1, 0
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, NULL, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'kostenstelle', 2, 1, 1, 1, 0
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, NULL, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'hauptbehinderung', 2, 1, 1, 1, 0
           -
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, NULL, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'klient', 2, 1, 1, 0, 0
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, NULL, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'klient', 2, 1, 1, 0, 1
           -- open cases:
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, 91, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'klient', 2, 1, 1, 1, 0  -- BS Bern-Mittelland
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, 91, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'hauptbehinderung', 2, 1, 1, 1, 0  -- BS Bern-Mittelland
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, 91, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'mitarbeiter', 2, 1, 1, 1, 0  -- BS Bern-Mittelland
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, 91, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'kostenstelle', 2, 1, 1, 1, 0  -- BS Bern-Mittelland
           -- closed cases:
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, 91, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'klient', 2, 1, 1, 0, 0  -- BS Bern-Mittelland
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, 91, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'hauptbehinderung', 2, 1, 1, 0, 0  -- BS Bern-Mittelland
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, 91, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'mitarbeiter', 2, 1, 1, 0, 0  -- BS Bern-Mittelland
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, 91, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, 'kostenstelle', 2, 1, 1, 0, 0  -- BS Bern-Mittelland
           -- closed cases with no following
           EXEC dbo.spQRYLaufendeAbgeschlosseneDossiers 1, 91, '2008-01-01', '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klient', 2, 1, 1, 0, 1  -- BS Bern-Mittelland
=================================================================================================*/

CREATE PROCEDURE dbo.spQRYLaufendeAbgeschlosseneDossiers
(
  @LanguageCode INT,
  @OrgUnitID INT,
  @ZeitraumVon DATETIME,
  @ZeitraumBis DATETIME,
  @UserID INT,
  @HauptBehinderungsartCode INT,
  @BSVBehinderungsartCode INT,
  @IVBerechtigungsCode INT,
  @GeburtVon DATETIME,
  @GeburtBis DATETIME,
  @ResultTable VARCHAR(50),
  @CurrentUserID INT,
  @SpecialRightKostenstelleHS BIT,
  @SpecialRightKostenstelleKGS BIT,
  @OpenCases BIT,
  @OnlyWithNoFollowingFV BIT
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
  SET @LanguageCode          = ISNULL(@LanguageCode, 1);
  SET @OpenCases             = ISNULL(@OpenCases, 1);
  SET @OnlyWithNoFollowingFV = ISNULL(@OnlyWithNoFollowingFV, 0);
  
  -------------------------------------------------------------------------------
  -- vars
  -------------------------------------------------------------------------------
  DECLARE @ZeitraumString VARCHAR(100);
  
  -------------------------------------------------------------------------------
  -- debug
  -------------------------------------------------------------------------------
  /*
  SET @LanguageCode = 1;
  --SET @OrgUnitID = 26; -- BS Amriswil
  SET @ZeitraumVon = '2008-01-01';
  SET @ZeitraumBis = '2008-12-31';
  --SET @UserID = 2;
  SET @ResultTable = 'klient';
  SET @CurrentUserID = 2;
  SET @SpecialRightKostenstelleHS = 1;
  SET @SpecialRightKostenstelleKGS = 1;
  SET @OpenCases = 1;
  SET @OnlyWithNoFollowingFV = 0;
  --*/
  
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (@ResultTable IS NULL OR ISNULL(YEAR(@ZeitraumVon), -1) < 2000 OR ISNULL(YEAR(@ZeitraumBis), -1) < 2000 OR @CurrentUserID IS NULL)
  BEGIN
    -- invalid data
    SELECT [Error]       = 'Error: Invalid parametes, cannot search data!',
           [BaPersonID$] = NULL;
    
    -- do not continue
    RETURN;
  END;
  
  -- set periode
  SET @ZeitraumString = dbo.fnGetZeitraumString(@ZeitraumVon, @ZeitraumBis);
  
  -------------------------------------------------------------------------------
  -- init temp table
  -------------------------------------------------------------------------------
  DECLARE @Temp TABLE
  (
    Id$ INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    BaPersonID INT NOT NULL UNIQUE,
    UserID INT,
    OrgUnitID INT,
    --
    SBHoursInDateSpan MONEY,
    CMHoursInDateSpan MONEY,
    BWHoursInDateSpan MONEY,
    EDHoursInDateSpan MONEY,
    ABHoursInDateSpan MONEY,
    TotalAllHours MONEY,
    DifferenceTotalToModule MONEY,
    --
    FaLeistungIDLastFV INT,
    FaLeistungIDLastFVFirstIntake INT,
    BaIVBerechtigungCode INT
  );
  
  -- info
  PRINT ('done init: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- fill temp table with persons
  -------------------------------------------------------------------------------
  -- get all person who fit to defined search criterias
  INSERT INTO @Temp (BaPersonID)
    SELECT DISTINCT 
           PRS.BaPersonID
    FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung LEI ON LEI.BaPersonID = PRS.BaPersonID 
                                   AND LEI.ModulID = 2                                                                                   -- only FV counts!
                                   AND LEI.DatumVon <= @ZeitraumBis                                                                      -- only active FV for given end-date
                                   AND ((@OpenCases = 1 AND ISNULL(LEI.DatumBis, '9999-12-31') >= @ZeitraumBis) OR                       -- if @OpenCases=1 then we only want those with open FV end of given timespan
                                        (@OpenCases = 0 AND ISNULL(LEI.DatumBis, '9999-12-31') BETWEEN @ZeitraumVon AND @ZeitraumBis))   -- if @OpenCases=2 then we only want those with closing FV withing timespan
    WHERE PRS.BaPersonID IN (SELECT DISTINCT 
                             PRS.BaPersonID
                         FROM dbo.vwIxBDELeistung_BDELeistungsart_AuswDLCode LEI WITH (NOEXPAND)
                           INNER JOIN dbo.BaPerson                           PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
                         WHERE (@HauptBehinderungsartCode IS NULL OR PRS.HauptBehinderungsartCode = @HauptBehinderungsartCode) 
                           AND (@BSVBehinderungsartCode IS NULL   OR PRS.BSVBehinderungsartCode = @BSVBehinderungsartCode) 
                           AND (@IVBerechtigungsCode IS NULL      OR dbo.fnBaGetIVBerechtigungStatus(PRS.BaPersonID, @ZeitraumBis, 0) = @IVBerechtigungsCode) 
                           AND (@GeburtVon IS NULL                OR PRS.Geburtsdatum >= @GeburtVon) 
                           AND (@GeburtBis IS NULL                OR PRS.Geburtsdatum <= @GeburtBis)
                        ); 
  
  -- info
  PRINT ('filled temp table with persons: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- remove data if @OpenCases=0 and @OnlyWithNoFollowingFV=1 is set
  -------------------------------------------------------------------------------
  IF (@OpenCases = 0 AND @OnlyWithNoFollowingFV = 1)
  BEGIN
    -- remove those persons who have another FV after end-date
    DELETE TMP
    FROM @Temp TMP                                            -- cool: using table alias with delete statement!
    WHERE EXISTS (SELECT TOP 1 1
                  FROM dbo.FaLeistung LEI
                  WHERE LEI.BaPersonID = TMP.BaPersonID                        -- current person
                    AND LEI.ModulID = 2                                        -- only FV
                    AND (LEI.DatumVon > @ZeitraumBis OR                        -- opened after given end-date
                         ISNULL(LEI.DatumBis, '9999-12-31') > @ZeitraumBis));  -- closed after given end-date
    
    -- info
    PRINT ('removed persons with following FV: ' + CONVERT(VARCHAR, GETDATE(), 113));
  END;
  
  -------------------------------------------------------------------------------
  -- filter by search-filter
  -------------------------------------------------------------------------------
  -- GET LAST FV-FALEISTUNGID
  UPDATE TMP
  SET TMP.FaLeistungIDLastFV = dbo.fnFaGetLastFaLeistungID(TMP.BaPersonID, 2) -- FV
  FROM @Temp TMP;
  
  -- info
  PRINT ('updated FaLeistungIDLastFV on temporary table: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- FILTER USERID:
  -- fill userid (responsible for last FV)
  UPDATE TMP
  SET UserID = (SELECT TOP 1 
                       LEI.UserID
                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                WHERE LEI.FaLeistungID = TMP.FaLeistungIDLastFV) -- FV
  FROM @Temp TMP;
  
  -- info
  PRINT ('filled userid of last responsible FV-user: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- if userid is defined, remove entries that are not for current user
  IF (@UserID IS NOT NULL)
  BEGIN
    -- remove entries where current user is not FV-responsible
    DELETE FROM @Temp
    WHERE ISNULL(UserID, -1) <> @UserID;
    
    -- info
    PRINT ('filtered userid: ' + CONVERT(VARCHAR, GETDATE(), 113));
  END;
  
  -- FILTER ORGUNIT:
  -- fill orgunit of user (last-FV-responsible-membership)
  UPDATE TMP
  SET OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(TMP.UserID, 1))
  FROM @Temp TMP;
  
  -- info
  PRINT ('updated orgunitid: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
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
  -- set hours from BDELeistung
  -------------------------------------------------------------------------------
  -- fill hours on SB/CM of current entries
  UPDATE TMP
  SET SBHoursInDateSpan = dbo.fnBDEGetZLEHoursForModule(TMP.BaPersonID, 0, @ZeitraumVon, @ZeitraumBis), -- SB
      CMHoursInDateSpan = dbo.fnBDEGetZLEHoursForModule(TMP.BaPersonID, 1, @ZeitraumVon, @ZeitraumBis), -- CM
      BWHoursInDateSpan = dbo.fnBDEGetZLEHoursForModule(TMP.BaPersonID, 2, @ZeitraumVon, @ZeitraumBis), -- BW
      EDHoursInDateSpan = dbo.fnBDEGetZLEHoursForModule(TMP.BaPersonID, 3, @ZeitraumVon, @ZeitraumBis), -- ED
      ABHoursInDateSpan = dbo.fnBDEGetZLEHoursForModule(TMP.BaPersonID, 4, @ZeitraumVon, @ZeitraumBis), -- ED
      TotalAllHours     = (SELECT SUM(ISNULL(LEI.Dauer, 0.0))
                           FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                           WHERE LEI.BaPersonID = TMP.BaPersonID
                             AND LEI.Datum BETWEEN @ZeitraumVon AND @ZeitraumBis)
  FROM @Temp TMP;
  
  -- fill total hours (SB+CM)
  UPDATE TMP
  SET DifferenceTotalToModule = ISNULL(TMP.TotalAllHours, 0.0) - (ISNULL(TMP.SBHoursInDateSpan, 0.0) + 
                                                                  ISNULL(TMP.CMHoursInDateSpan, 0.0) + 
                                                                  ISNULL(TMP.BWHoursInDateSpan, 0.0) + 
                                                                  ISNULL(TMP.EDHoursInDateSpan, 0.0) + 
                                                                  ISNULL(TMP.ABHoursInDateSpan, 0.0))
  FROM @Temp TMP;
  
  -- info
  PRINT ('calculated hours SB, CM, BW, ED and total: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  --=============================================================================
  -- OUTPUT
  --=============================================================================
  
  -------------------------------------------------------------------------------
  -- output 'klient/innen'
  -------------------------------------------------------------------------------
  IF (@ResultTable = 'klient')
  BEGIN
    -- get FaLeistungID of first intake in last FV
    UPDATE TMP
    SET TMP.FaLeistungIDLastFVFirstIntake = dbo.fnFaGetFirstIntakeOfFV(TMP.BaPersonID, TMP.FaLeistungIDLastFV)
    FROM @Temp TMP;
    
    -- info
    PRINT ('updated FaLeistungIDLastFVFirstIntake on temporary table: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
    -- get other data
    SELECT [BaPersonID$]          = PRS.BaPersonID,
           [Nr.]                  = PRS.BaPersonID,
           [Name]                 = PRS.Name,
           [Vorname]              = PRS.Vorname,
           [PLZ]                  = ADRW.PLZ,
           [Ort]                  = ADRW.Ort,
           [Bezirk]               = ADRW.Bezirk,
           [Kanton]               = ADRW.Kanton,
           [Nationalität]         = dbo.fnLandMLText(PRS.NationalitaetCode, @LanguageCode),
           [Geschlecht]           = dbo.fnGetGenderMLTitleMF(PRS.GeschlechtCode, @LanguageCode),
           [Geb.Dat.]             = PRS.Geburtsdatum,
           [Alter]                = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
           [Vers.-Nr.]            = PRS.VersichertenNummer,
           [Korrespondenz]        = dbo.fnGetLOVMLText('BaKorrespondenzSprache', PRS.KorrespondenzSpracheCode, @LanguageCode),
           [Hauptbehinderungsart] = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode),
           [BSV-Behinderungsart]  = dbo.fnGetLOVMLText('BaBSVBehinderungsart', PRS.BSVBehinderungsartCode, @LanguageCode),
           [IV Berechtigung]      = dbo.fnGetLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(TMP.BaPersonID, @ZeitraumBis, 0), @LanguageCode),
           ----
           [Kostenstelle]         = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
           [KGS]                  = dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, @ZeitraumBis, TMP.OrgUnitID, 0, 1),
           [Empfohlen von]        = dbo.fnGetLOVMLText('FaIntakeEmpfohlenVon', FAI.EmpfohlenVonCode, @LanguageCode),
           [Verantwortliche/r FV] = dbo.fnGetLastFirstName(TMP.UserID, NULL, NULL),
           ---- <specific data>
           -- FV=2
           [Eröffnung FV]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 2, @ZeitraumVon, @ZeitraumBis, 'processopenend')),
           [Abschluss FV]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 2, @ZeitraumVon, @ZeitraumBis, 'processclosed')),
           [Wiederaufnahme FV]    = CONVERT(BIT, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 2, @ZeitraumVon, @ZeitraumBis, 'reopened')),
           [Anzahl FV]            = CONVERT(INT, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 2, @ZeitraumVon, @ZeitraumBis, 'amountofprocesses')),
           -- IN=7
           [Verantwortliche/r IN] = dbo.fnFaGetProcessInfo(TMP.BaPersonID, 7, @ZeitraumVon, @ZeitraumBis, 'processuser'),
           [Eröffnung IN]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 7, @ZeitraumVon, @ZeitraumBis, 'processopenend')),
           [Abschluss IN]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 7, @ZeitraumVon, @ZeitraumBis, 'processclosed')),
           [Abschlussgrund IN]    = dbo.fnGetLOVMLText('FaIntakeAbschlussGrund', dbo.fnFaGetProcessInfo(TMP.BaPersonID, 7, @ZeitraumVon, @ZeitraumBis, 'closurereason'), @LanguageCode),
           [Anzahl IN]            = CONVERT(INT, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 7, @ZeitraumVon, @ZeitraumBis, 'amountofprocesses')),
           -- SB=3
           [Verantwortliche/r SB] = dbo.fnFaGetProcessInfo(TMP.BaPersonID, 3, @ZeitraumVon, @ZeitraumBis, 'processuser'),
           [Eröffnung SB]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 3, @ZeitraumVon, @ZeitraumBis, 'processopenend')),
           [Abschluss SB]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 3, @ZeitraumVon, @ZeitraumBis, 'processclosed')),
           [Abschlussgrund SB]    = dbo.fnGetLOVMLText('FaAbschlussgrund', dbo.fnFaGetProcessInfo(TMP.BaPersonID, 3, @ZeitraumVon, @ZeitraumBis, 'closurereason'), @LanguageCode),
           [Stunden SB]           = ISNULL(TMP.SBHoursInDateSpan, 0.0),
           [Anzahl SB]            = CONVERT(INT, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 3, @ZeitraumVon, @ZeitraumBis, 'amountofprocesses')),
           -- CM=4
           [Verantwortliche/r CM] = dbo.fnFaGetProcessInfo(TMP.BaPersonID, 4, @ZeitraumVon, @ZeitraumBis, 'processuser'),
           [Eröffnung CM]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 4, @ZeitraumVon, @ZeitraumBis, 'processopenend')),
           [Abschluss CM]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 4, @ZeitraumVon, @ZeitraumBis, 'processclosed')),
           [Abschlussgrund CM]    = dbo.fnGetLOVMLText('FaAbschlussgrund', dbo.fnFaGetProcessInfo(TMP.BaPersonID, 4, @ZeitraumVon, @ZeitraumBis, 'closurereason'), @LanguageCode),
           [Stunden CM]           = ISNULL(TMP.CMHoursInDateSpan, 0.0),
           [Anzahl CM]            = CONVERT(INT, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 4, @ZeitraumVon, @ZeitraumBis, 'amountofprocesses')),
           -- BW=5
           [Verantwortliche/r BW] = dbo.fnFaGetProcessInfo(TMP.BaPersonID, 5, @ZeitraumVon, @ZeitraumBis, 'processuser'),
           [Eröffnung BW]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 5, @ZeitraumVon, @ZeitraumBis, 'processopenend')),
           [Abschluss BW]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 5, @ZeitraumVon, @ZeitraumBis, 'processclosed')),
           [Abschlussgrund BW]    = dbo.fnGetLOVMLText('FaAbschlussgrund', dbo.fnFaGetProcessInfo(TMP.BaPersonID, 5, @ZeitraumVon, @ZeitraumBis, 'closurereason'), @LanguageCode),
           [Stunden BW]           = ISNULL(TMP.BWHoursInDateSpan, 0.0),
           [Anzahl BW]            = CONVERT(INT, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 5, @ZeitraumVon, @ZeitraumBis, 'amountofprocesses')),
           -- ED=6
           [Verantwortliche/r ED] = dbo.fnFaGetProcessInfo(TMP.BaPersonID, 6, @ZeitraumVon, @ZeitraumBis, 'processuser'),
           [Eröffnung ED]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 6, @ZeitraumVon, @ZeitraumBis, 'processopenend')),
           [Abschluss ED]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 6, @ZeitraumVon, @ZeitraumBis, 'processclosed')),
           [Abschlussgrund ED]    = dbo.fnGetLOVMLText('FaAbschlussgrund', dbo.fnFaGetProcessInfo(TMP.BaPersonID, 6, @ZeitraumVon, @ZeitraumBis, 'closurereason'), @LanguageCode),
           [Stunden ED]           = ISNULL(TMP.EDHoursInDateSpan, 0.0),
           [Anzahl ED]            = CONVERT(INT, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 6, @ZeitraumVon, @ZeitraumBis, 'amountofprocesses')),
           -- AB=8
           [Verantwortliche/r AB] = dbo.fnFaGetProcessInfo(TMP.BaPersonID, 8, @ZeitraumVon, @ZeitraumBis, 'processuser'),
           [Eröffnung AB]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 8, @ZeitraumVon, @ZeitraumBis, 'processopenend')),
           [Abschluss AB]         = CONVERT(DATETIME, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 8, @ZeitraumVon, @ZeitraumBis, 'processclosed')),
           [Abschlussgrund AB]    = dbo.fnGetLOVMLText('FaAbschlussgrund', dbo.fnFaGetProcessInfo(TMP.BaPersonID, 8, @ZeitraumVon, @ZeitraumBis, 'closurereason'), @LanguageCode),
           [Stunden AB]           = ISNULL(TMP.ABHoursInDateSpan, 0.0),
           [Anzahl AB]            = CONVERT(INT, dbo.fnFaGetProcessInfo(TMP.BaPersonID, 8, @ZeitraumVon, @ZeitraumBis, 'amountofprocesses')),
           ---- </specific data>
           [Übrige Stunden]       = ISNULL(TMP.DifferenceTotalToModule, 0.0),
           [Total Stunden]        = ISNULL(TMP.TotalAllHours, 0.0),
           [Zeitraum]             = @ZeitraumString,
           [Kein Serienbrief]     = PRS.KeinSerienbrief,
           [Anschrift]            = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'anschrift', 0, 1, 'vornach', dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede), 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Anrede]               = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'geehrte', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
           ----
           [Telefon privat]       = PRS.Telefon_P,
           [Telefon gesch.]       = PRS.Telefon_G,
           [Telefon mobil]        = PRS.MobilTel,
           [E-Mail]               = PRS.EMail,
           ----
           [VIS-Dossier]          = dbo.fnBaGetVISDossierNr(PRS.BaPersonID),
           ----
           [Rechnungsadresse ED1] = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raed1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse ED2] = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raed2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse BW1] = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'rabw1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse BW2] = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'rabw2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
    FROM @Temp                TMP
      INNER JOIN dbo.BaPerson PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
      LEFT  JOIN dbo.XOrgUnit ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = TMP.OrgUnitID
      LEFT  JOIN dbo.FaIntake FAI  WITH (READUNCOMMITTED) ON FAI.FaLeistungID = TMP.FaLeistungIDLastFVFirstIntake
      
      -- wohnsitz
      LEFT JOIN dbo.BaAdresse ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
    ORDER BY [Name], [Vorname], [BaPersonID$];
    
    -- info
    PRINT ('done output for <' + @ResultTable + '>: ' + CONVERT(VARCHAR, GETDATE(), 113));
    
    -- done
    RETURN;
  END;
  
  -------------------------------------------------------------------------------
  -- output 'hauptbehinderung'
  -------------------------------------------------------------------------------
  IF (@ResultTable = 'hauptbehinderung')
  BEGIN
    SELECT [Hauptbehinderungsart] = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode),
           --
           [Anzahl FV]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 2 -- only FV
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1)),
           --
           [Anzahl IN]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 7 -- only IN
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1)),
           --
           [Anzahl SB]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 3 -- only SB
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1)),
           [Stunden SB]           = SUM(ISNULL(TMP.SBHoursInDateSpan, 0.0)),
           --
           [Anzahl CM]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 4 -- only CM
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1)),
           [Stunden CM]           = SUM(ISNULL(TMP.CMHoursInDateSpan, 0.0)),
           --
           [Anzahl BW]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 5 -- only BW
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1)),
           [Stunden BW]           = SUM(ISNULL(TMP.BWHoursInDateSpan, 0.0)),
           --
           [Anzahl ED]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 6 -- only ED
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1)),
           [Stunden ED]           = SUM(ISNULL(TMP.EDHoursInDateSpan, 0.0)),
           --
           [Anzahl AB]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 8 -- only AB
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1)),
           [Stunden AB]           = SUM(ISNULL(TMP.ABHoursInDateSpan, 0.0)),
           --
           [Übrige Stunden]       = SUM(ISNULL(TMP.DifferenceTotalToModule, 0.0)),
           [Total Stunden]        = SUM(ISNULL(TMP.TotalAllHours, 0.0)),
           --
           [Zeitraum]             = @ZeitraumString
    FROM @Temp TMP
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
    GROUP BY dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode), PRS.HauptBehinderungsartCode
    ORDER BY [Hauptbehinderungsart];
    
    -- info
    PRINT ('done output for <' + @ResultTable + '>: ' + CONVERT(VARCHAR, GETDATE(), 113));
    
    -- done
    RETURN;
  END;

  -------------------------------------------------------------------------------
  -- output 'mitarbeiter/innen'
  -------------------------------------------------------------------------------
  IF (@ResultTable = 'mitarbeiter')
  BEGIN
    SELECT [Mitarbeiter/in]       = dbo.fnGetLastFirstName(TMP.UserID, NULL, NULL),
           [BG]                   = dbo.fnBDEGetPensumPercent(TMP.UserID, @ZeitraumBis),
           [KGS]                  = dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, @ZeitraumBis, TMP.OrgUnitID, 0, 1),
           --
           [Anzahl FV]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 2 -- only FV
                                     WHERE ISNULL(SUB.UserID, -1) = ISNULL(TMP.UserID, -1)),
           --
           [Anzahl IN]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 7 -- only IN
                                     WHERE ISNULL(SUB.UserID, -1) = ISNULL(TMP.UserID, -1)),
           --
           [Anzahl SB]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 3 -- only SB
                                     WHERE ISNULL(SUB.UserID, -1) = ISNULL(TMP.UserID, -1)),
           [Stunden SB]           = SUM(ISNULL(TMP.SBHoursInDateSpan, 0.0)),
           --
           [Anzahl CM]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 4 -- only CM
                                     WHERE ISNULL(SUB.UserID, -1) = ISNULL(TMP.UserID, -1)),
           [Stunden CM]           = SUM(ISNULL(TMP.CMHoursInDateSpan, 0.0)),
           --
           [Anzahl BW]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 5 -- only BW
                                     WHERE ISNULL(SUB.UserID, -1) = ISNULL(TMP.UserID, -1)),
           [Stunden BW]           = SUM(ISNULL(TMP.BWHoursInDateSpan, 0.0)),
           --
           [Anzahl ED]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 6 -- only ED
                                     WHERE ISNULL(SUB.UserID, -1) = ISNULL(TMP.UserID, -1)),
           [Stunden ED]           = SUM(ISNULL(TMP.EDHoursInDateSpan, 0.0)),
           --
           [Anzahl AB]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 8 -- only AB
                                     WHERE ISNULL(SUB.UserID, -1) = ISNULL(TMP.UserID, -1)),
           [Stunden AB]           = SUM(ISNULL(TMP.ABHoursInDateSpan, 0.0)),
           --
           [Anzahl neu]           = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                     WHERE ISNULL(SUB.UserID, -1) = ISNULL(TMP.UserID, -1) 
                                       AND CONVERT(BIT, dbo.fnFaGetProcessInfo(SUB.BaPersonID, 2, @ZeitraumVon, @ZeitraumBis, 'reopened')) = 0),  -- no FV before
           [Anzahl wiedereröffn.] = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                     WHERE ISNULL(SUB.UserID, -1) = ISNULL(TMP.UserID, -1) 
                                       AND CONVERT(BIT, dbo.fnFaGetProcessInfo(SUB.BaPersonID, 2, @ZeitraumVon, @ZeitraumBis, 'reopened')) = 1),  -- with FV before
           --
           [Zeitraum]             = @ZeitraumString
    FROM @Temp TMP
    GROUP BY TMP.UserID, TMP.OrgUnitID
    ORDER BY [Mitarbeiter/in], [KGS];
    
    -- info
    PRINT ('done output for <' + @ResultTable + '>: ' + CONVERT(VARCHAR, GETDATE(), 113));
    
    -- done
    RETURN;
  END;
  
  -------------------------------------------------------------------------------
  -- output 'kostenstellen'
  -------------------------------------------------------------------------------
  IF (@ResultTable = 'kostenstelle')
  BEGIN
    SELECT [Kostenstelle]         = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
           [KGS]                  = dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, @ZeitraumBis, TMP.OrgUnitID, 0, 1),
           --
           [Anzahl FV]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 2 -- only FV
                                     WHERE ISNULL(SUB.OrgUnitID, -1) = ISNULL(TMP.OrgUnitID, -1)),
           --
           [Anzahl IN]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 7 -- only IN
                                     WHERE ISNULL(SUB.OrgUnitID, -1) = ISNULL(TMP.OrgUnitID, -1)),
           --
           [Anzahl SB]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 3 -- only SB
                                     WHERE ISNULL(SUB.OrgUnitID, -1) = ISNULL(TMP.OrgUnitID, -1)),
           [Stunden SB]           = SUM(ISNULL(TMP.SBHoursInDateSpan, 0.0)),
           --
           [Anzahl CM]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 4 -- only CM
                                     WHERE ISNULL(SUB.OrgUnitID, -1) = ISNULL(TMP.OrgUnitID, -1)),
           [Stunden CM]           = SUM(ISNULL(TMP.CMHoursInDateSpan, 0.0)),
           --
           [Anzahl BW]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 5 -- only BW
                                     WHERE ISNULL(SUB.OrgUnitID, -1) = ISNULL(TMP.OrgUnitID, -1)),
           [Stunden BW]           = SUM(ISNULL(TMP.BWHoursInDateSpan, 0.0)),
           --
           [Anzahl ED]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 6 -- only ED
                                     WHERE ISNULL(SUB.OrgUnitID, -1) = ISNULL(TMP.OrgUnitID, -1)),
           [Stunden ED]           = SUM(ISNULL(TMP.EDHoursInDateSpan, 0.0)),
           --
           [Anzahl AB]            = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM @Temp SUB
                                       INNER JOIN dbo.BaPerson   SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                       INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.BaPersonID = SUB.BaPersonID 
                                                                                           AND LEI.ModulID = 8 -- only AB
                                     WHERE ISNULL(SUB.OrgUnitID, -1) = ISNULL(TMP.OrgUnitID, -1)),
           [Stunden AB]           = SUM(ISNULL(TMP.ABHoursInDateSpan, 0.0)),
           --
           [Übrige Stunden]       = SUM(ISNULL(TMP.DifferenceTotalToModule, 0.0)),
           [Total Stunden]        = SUM(ISNULL(TMP.TotalAllHours, 0.0)),
           --
           [Zeitraum]             = @ZeitraumString
    FROM @Temp TMP
      LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = TMP.OrgUnitID
    GROUP BY ORG.ItemName, TMP.OrgUnitID, ORG.Kostenstelle
    ORDER BY [Kostenstelle];
    
    -- info
    PRINT ('done output for <' + @ResultTable + '>: ' + CONVERT(VARCHAR, GETDATE(), 113));
    
    -- done
    RETURN;
  END;
END;
GO