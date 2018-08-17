SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spQRYAktiveNeueDossiers;
GO

-------------------------------------------------------------------------------
-- setup properties because of indexed view usage
-------------------------------------------------------------------------------
SET QUOTED_IDENTIFIER ON;
GO

/*===============================================================================================
  $Revision: 55 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to get values for query "Aktive Dossiers BSV"
    @LanguageCode:                The language code to use for ML values
    @OrgUnitID:                   The orgunit to use as filter for result
    @ZeitraumBis:                 The end of date to use (required)
    @UserID:                      The userid to use as filter for result
    @HauptbehinderungsartCode:    The code to use for filter of persons
    @BSVBehinderungsartCode:      The code to use for filter of persons
    @IVBerechtigungsCode:         The code to use for filter of persons
    @GeburtVon:                   The start range for birthday-date to use for filter of persons
    @GeburtBis:                   The start range for birthday-date to use for filter of persons
    @NurSozialberatung            Flag: 1=active client will be determined by SB/CM or 0=active client will be SB/CM/BW/ED
    @ResultTable:                 The desired result table to generate
                                  - 'klient'*
                                  - 'klientsozdaten'*   (used for 'Aktive Dossiers Sozialdaten')
                                  - 'klientsozdatened'  (used for 'Aktive Dossiers ED')
                                  - 'klientsozdatenbw'  (used for 'Aktive Dossiers BW')
                                  - 'klientsozdatenab'  (used for 'Aktive Dossiers AB')
                                  - 'mitarbeiter'*
                                  - 'kostenstelle'*
                                  - 'hauptbehinderung'*
                                  - 'bsv-behinderung'*
                                  - 'iv-berechtigung'*
                                  --> the ones with "*" can be ";"-separated and therefore you can get multiple result-sets.
                                      but the resultsets are not in correct order, you get a column with your resulttable-name to identify those
                                      as [ResultTable_<ResultTableName>$]
    @CurrentUserID:               The userid of the user who is currently logged in and using KiSS
    @SpecialRightKostenstelleKGS: Set if the current user has a special right to see more orgunits and users
    @OnlyNewClients:              Set if only new clients have to be displayed (1=only new, 0=active ones)
  -
  RETURNS: Result depending on given search parameters and ResultTable
=================================================================================================
  TEST:    EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klient', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klientsozdaten', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'mitarbeiter', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'kostenstelle', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'hauptbehinderung', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'bsv-behinderung', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'iv-berechtigung', 2, 1, 1, 0
           --
           EXEC dbo.spQRYAktiveNeueDossiers 1, 26, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klient', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, 26, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klientsozdaten', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, 1, '2009-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klientsozdaten', 2, 1, 1, 0
           --
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klient', 2, 1, 1, 1
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klientsozdaten', 2, 1, 1, 1
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'mitarbeiter', 2, 1, 1, 1
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'kostenstelle', 2, 1, 1, 1
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'hauptbehinderung', 2, 1, 1, 1
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'bsv-behinderung', 2, 1, 1, 1
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'iv-berechtigung', 2, 1, 1, 1
           --
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2009-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klientsozdatened', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2010-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klientsozdatened', 2, 1, 1, 0
           --
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2009-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klientsozdatenbw', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2010-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klientsozdatenbw', 2, 1, 1, 0
           --
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2009-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klientsozdatenab', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2010-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klientsozdatenab', 2, 1, 1, 0
           --
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'klient;mitarbeiter;kostenstelle;hauptbehinderung;bsv-behinderung;iv-berechtigung', 2, 1, 1, 0
           EXEC dbo.spQRYAktiveNeueDossiers 1, NULL, '2008-12-31', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'abc;xyz', 2, 1, 1, 0
=================================================================================================*/

CREATE PROCEDURE dbo.spQRYAktiveNeueDossiers
(
  @LanguageCode INT,
  @OrgUnitID INT,
  @ZeitraumBis DATETIME,
  @UserID INT,
  @HauptBehinderungsartCode INT,
  @BSVBehinderungsartCode INT,
  @IVBerechtigungsCode INT,
  @GeburtVon DATETIME,
  @GeburtBis DATETIME,
  @NurSozialberatung BIT,
  @ResultTable VARCHAR(1000),
  @CurrentUserID INT,
  @SpecialRightKostenstelleHS BIT,
  @SpecialRightKostenstelleKGS BIT,
  @OnlyNewClients BIT
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -- init start
  DECLARE @StartTimeOfCode DATETIME;
  SET @StartTimeOfCode = GETDATE();
  
  PRINT ('start call: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -----------------------------------------------------------------------------
  -- set default values
  -----------------------------------------------------------------------------
  SET @LanguageCode = ISNULL(@LanguageCode, 1);
  SET @NurSozialberatung = ISNULL(@NurSozialberatung, 0);
  SET @SpecialRightKostenstelleHS = ISNULL(@SpecialRightKostenstelleHS, 0);
  SET @SpecialRightKostenstelleKGS = ISNULL(@SpecialRightKostenstelleKGS, 0);
  SET @OnlyNewClients = ISNULL(@OnlyNewClients, 0);
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @ZeitraumVon DATETIME;
  DECLARE @ZeitraumString VARCHAR(100);
  DECLARE @CheckAdditionModules BIT;
  --
  DECLARE @UserIDZustaendigModule INT;  -- value used for filtering query specific users only
  --
  DECLARE @DataOutputHappend BIT;
  DECLARE @ResultTablesCount INT;
  --
  DECLARE @ResultTables TABLE
  (
    ResultTable VARCHAR(50) NOT NULL UNIQUE
  );
  
  -----------------------------------------------------------------------------
  -- debug
  -----------------------------------------------------------------------------
  /*
  SET @LanguageCode = 1
  --SET @OrgUnitID = 26 -- BS Amriswil
  SET @ZeitraumBis = '2008-12-31'
  --SET @UserID = 2
  SET @HauptBehinderungsartCode = NULL
  SET @BSVBehinderungsartCode = NULL
  SET @IVBerechtigungsCode = NULL
  SET @GeburtVon = NULL
  SET @GeburtBis = NULL
  SET @NurSozialberatung = 0
  SET @ResultTable = 'klient'
  SET @CurrentUserID = 2
  SET @SpecialRightKostenstelleHS = 1
  SET @SpecialRightKostenstelleKGS = 1
  SET @OnlyNewClients = 0
  --*/
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@ResultTable IS NULL OR ISNULL(YEAR(@ZeitraumBis), -1) < 2008 OR @CurrentUserID IS NULL)
  BEGIN
    -- invalid data
    SELECT [Error]       = 'Error: Invalid parametes, cannot search data!',
           [BaPersonID$] = NULL;
    
    -- do not continue
    RETURN;
  END;
  
  -- setup DatumVon
  SET @ZeitraumVon = dbo.fnGetDateFromInts(1, 1, YEAR(@ZeitraumBis));
  
  -- set periode
  SET @ZeitraumString = dbo.fnGetZeitraumString(@ZeitraumVon, @ZeitraumBis);
  
  -- set CheckAdditionModules
  SET @CheckAdditionModules = CASE 
                                WHEN @NurSozialberatung = 1 THEN 0
                                ELSE 1
                              END;
  
  -- setup module specific handling of user filter
  SET @UserIDZustaendigModule = CASE
                                  WHEN @ResultTable IN ('klientsozdatened', 'klientsozdatenbw', 'klientsozdatenab') 
                                   AND @UserID IS NOT NULL THEN @UserID
                                  ELSE NULL
                                END;
  
  IF (@UserIDZustaendigModule IS NOT NULL)
  BEGIN
    -- if we filter for specific user within module, so we need to reset global userid of FV filter
    SET @UserID = NULL;
  END;
  
  -- fill result-tables (works even with one value only)
  INSERT INTO @ResultTables (ResultTable)
    SELECT FCN.SplitValue
    FROM dbo.fnSplitStringToValues(@ResultTable, ';', 1) FCN
  
  -- init vars
  SET @ResultTablesCount = @@ROWCOUNT;  -- need to be done just after fill of temp-table!
  SET @DataOutputHappend = 0;
  
  -----------------------------------------------------------------------------
  -- init temp table
  -----------------------------------------------------------------------------
  -- check if temporary table already exists
  IF (OBJECT_ID('tempdb..#Temp') IS NOT NULL)
  BEGIN
    DROP TABLE #Temp;
  END;
  
  CREATE TABLE #Temp
  (
    BaPersonID INT NOT NULL PRIMARY KEY CLUSTERED,
    UserID INT NOT NULL,
    OrgUnitID INT NOT NULL,
    --
    SBHoursOnMAAndOrgUnit MONEY,
    CMHoursOnMAAndOrgUnit MONEY,
    BWHoursOnMAAndOrgUnit MONEY,
    EDHoursOnMAAndOrgUnit MONEY,
    ABHoursOnMAAndOrgUnit MONEY,
    IEBIHoursOnMAAndOrgUnit MONEY,
    TotalHours MONEY,
    --
    BaIVBerechtigungCode INT,
    AnzahlEinsaetzeBW INT,
    AnzahlEinsaetzeED INT,
    AnzahlEinsaetzeAB INT,
    --
    FaLeistungIDFirstIntake INT,
    FaLeistungIDLastBW INT,
    FaLeistungIDLastED INT,
    FaLeistungIDLastAB INT,
    --
    BWHoursReduzierteFaktura MONEY,
    BWHoursVollkosten MONEY
  );
  
  -- info
  PRINT ('done init: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -----------------------------------------------------------------------------
  -- fill temp table with persons
  -----------------------------------------------------------------------------
  -- get all person who fit to defined search criterias,
  -- get user who is responsible for FV,
  -- get orgunit of user who is responsible for FV
  INSERT INTO #Temp (BaPersonID, UserID, OrgUnitID)
    SELECT BaPersonID = RES.BaPersonID,
           UserID     = RES.UserID,
           OrgUnitID  = RES.OrgUnitID
    FROM (-- get orgunit of user
          SELECT BaPersonID = SPLE.BaPersonID,
                 UserID     = ISNULL(SPLE.UserID, -1),
                 OrgUnitID  = CASE 
                                WHEN SPLE.UserID IS NULL THEN -1
                                ELSE ISNULL(CONVERT(INT, dbo.fnOrgUnitOfUser(SPLE.UserID, 1)), -1)
                              END
          FROM (-- get userid of remaining persons
                SELECT BaPersonID = SPRS.BaPersonID, 
                       UserID     = (SELECT LEI.UserID
                                     FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                     WHERE LEI.FaLeistungID = dbo.fnFaGetLastFaLeistungID(SPRS.BaPersonID, 2)) -- FV
                FROM (-- get unique persons
                      SELECT DISTINCT 
                             PRS.BaPersonID
                      FROM dbo.vwIxBDELeistung_BDELeistungsart_AuswDLCode LEI WITH (NOEXPAND)
                        INNER JOIN dbo.BaPerson                           PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
                      WHERE (@HauptBehinderungsartCode IS NULL OR PRS.HauptBehinderungsartCode = @HauptBehinderungsartCode) 
                        AND (@BSVBehinderungsartCode IS NULL   OR PRS.BSVBehinderungsartCode = @BSVBehinderungsartCode) 
                        AND (@IVBerechtigungsCode IS NULL      OR dbo.fnBaGetIVBerechtigungStatus(PRS.BaPersonID, @ZeitraumBis, 0) = @IVBerechtigungsCode) 
                        AND (@GeburtVon IS NULL                OR PRS.Geburtsdatum >= @GeburtVon) 
                        AND (@GeburtBis IS NULL                OR PRS.Geburtsdatum <= @GeburtBis)
                     ) SPRS
               ) SPLE
         ) RES
    WHERE (@UserID IS NULL OR RES.UserID = @UserID)           -- filter userid
      AND (@OrgUnitID IS NULL OR RES.OrgUnitID = @OrgUnitID); -- filter orgunitid
  
  -- info
  PRINT ('filled filtered temp table with persons, userid of FV, orgunitid of userid: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -----------------------------------------------------------------------------
  -- create indexes on temp table
  -----------------------------------------------------------------------------
  CREATE NONCLUSTERED INDEX [IX_#Temp_UserID] ON #Temp 
  (
    [UserID] ASC
  );
  
  CREATE NONCLUSTERED INDEX [IX_#Temp_OrgUnitID] ON #Temp 
  (
    [OrgUnitID] ASC
  );
  
  CREATE NONCLUSTERED INDEX [IX_#Temp_BaPersonID_SBHoursOnMAAndOrgUnit] ON #Temp 
  (
    [BaPersonID] ASC,
    [SBHoursOnMAAndOrgUnit] ASC
  );
  
  CREATE NONCLUSTERED INDEX [IX_#Temp_BaPersonID_CMHoursOnMAAndOrgUnit] ON #Temp 
  (
    [BaPersonID] ASC,
    [CMHoursOnMAAndOrgUnit] ASC
  );
  
  CREATE NONCLUSTERED INDEX [IX_#Temp_BaPersonID_BWHoursOnMAAndOrgUnit] ON #Temp 
  (
    [BaPersonID] ASC,
    [BWHoursOnMAAndOrgUnit] ASC
  );
  
  CREATE NONCLUSTERED INDEX [IX_#Temp_BaPersonID_EDHoursOnMAAndOrgUnit] ON #Temp 
  (
    [BaPersonID] ASC,
    [EDHoursOnMAAndOrgUnit] ASC
  );
  
  CREATE NONCLUSTERED INDEX [IX_#Temp_BaPersonID_ABHoursOnMAAndOrgUnit] ON #Temp 
  (
    [BaPersonID] ASC,
    [ABHoursOnMAAndOrgUnit] ASC
  );
  
  CREATE NONCLUSTERED INDEX [IX_#Temp_BaPersonID_IEBIHoursOnMAAndOrgUnit] ON #Temp 
  (
    [BaPersonID] ASC,
    [IEBIHoursOnMAAndOrgUnit] ASC
  );
    
  -- info
  PRINT ('created indexes on temporary table: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -----------------------------------------------------------------------------
  -- filter rights-depending users/orgunits
  -----------------------------------------------------------------------------
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
      DELETE TMP
      FROM #Temp TMP
      WHERE TMP.UserID NOT IN (SELECT USR.UserID
                               FROM @TmpAllowedUserIDs USR);
                                       
      -- info
      PRINT ('filtered depending on rights no-kgs: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
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
      DELETE TMP
      FROM #Temp TMP
      WHERE TMP.OrgUnitID NOT IN (SELECT ORG.OrgUnitID
                                  FROM @TmpAllowedOrgUnitIDs ORG);
      
      -- info
      PRINT ('filtered depending on rights kgs: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- filter active clients (only active clients will be displayed)
  -----------------------------------------------------------------------------
  -- remove all persons who are not active-clients/not new-clients by definition within date-range
  DELETE TMP
  FROM #Temp TMP
  WHERE ISNULL(dbo.fnFaIsPersonClientByRule(TMP.BaPersonID, @ZeitraumBis, @OnlyNewClients, @CheckAdditionModules), 0) = 0;
                                                                      
  -- info
  PRINT ('filtered non-active clients: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -----------------------------------------------------------------------------
  -- set hours from BDELeistung
  -----------------------------------------------------------------------------
  -- fill hours on SB/CM/BW/ED/AB of current entries
  UPDATE TMP
  SET TMP.SBHoursOnMAAndOrgUnit   = SUB.SBHoursOnMAAndOrgUnit,
      TMP.CMHoursOnMAAndOrgUnit   = SUB.CMHoursOnMAAndOrgUnit,
      TMP.BWHoursOnMAAndOrgUnit   = SUB.BWHoursOnMAAndOrgUnit,
      TMP.EDHoursOnMAAndOrgUnit   = SUB.EDHoursOnMAAndOrgUnit,
      TMP.ABHoursOnMAAndOrgUnit   = SUB.ABHoursOnMAAndOrgUnit,
      --
      TMP.IEBIHoursOnMAAndOrgUnit = SUB.IEBIHoursOnMAAndOrgUnit,
      --
      TMP.TotalHours              = SUB.SBHoursOnMAAndOrgUnit + 
                                    SUB.CMHoursOnMAAndOrgUnit + 
                                    SUB.BWHoursOnMAAndOrgUnit + 
                                    SUB.EDHoursOnMAAndOrgUnit +
                                    SUB.ABHoursOnMAAndOrgUnit +
                                    SUB.IEBIHoursOnMAAndOrgUnit
  FROM #Temp TMP
    INNER JOIN (SELECT BaPersonID              = STMP.BaPersonID,
                       SBHoursOnMAAndOrgUnit   = ISNULL(dbo.fnBDEGetZLEHoursForModule(STMP.BaPersonID, 0, @ZeitraumVon, @ZeitraumBis), 0.0),     -- SB
                       CMHoursOnMAAndOrgUnit   = ISNULL(dbo.fnBDEGetZLEHoursForModule(STMP.BaPersonID, 1, @ZeitraumVon, @ZeitraumBis), 0.0),     -- CM
                       BWHoursOnMAAndOrgUnit   = ISNULL(dbo.fnBDEGetZLEHoursForModule(STMP.BaPersonID, 2, @ZeitraumVon, @ZeitraumBis), 0.0),     -- BW
                       EDHoursOnMAAndOrgUnit   = ISNULL(dbo.fnBDEGetZLEHoursForModule(STMP.BaPersonID, 3, @ZeitraumVon, @ZeitraumBis), 0.0),     -- ED
                       ABHoursOnMAAndOrgUnit   = ISNULL(dbo.fnBDEGetZLEHoursForModule(STMP.BaPersonID, 25, @ZeitraumVon, @ZeitraumBis), 0.0),     -- AB
                       --
                       IEBIHoursOnMAAndOrgUnit = ISNULL(dbo.fnBDEGetZLEHoursForPIAuftrag(STMP.BaPersonID, 14, @ZeitraumVon, @ZeitraumBis), 0.0)  -- IEBI
                FROM #Temp STMP) SUB ON SUB.BaPersonID = TMP.BaPersonID;
  
  -- info
  PRINT ('calculated hours SB, CM, BW, ED, AB, IEBI and total: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  PRINT ('done, ready for output: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  --===========================================================================
  -- OUTPUT
  --===========================================================================
  
  -----------------------------------------------------------------------------
  -- output 'klient/innen'
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1
              FROM @ResultTables
              WHERE ResultTable = 'klient'))
  BEGIN
    SELECT [ResultTable_klient$]  = 'klient',
           --
           [BaPersonID$]          = PRS.BaPersonID,
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
           [IV Status]            = dbo.fnGetLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(TMP.BaPersonID, @ZeitraumBis, 1), @LanguageCode),
           --
           [Kostenstelle]         = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
           [KGS]                  = dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, @ZeitraumBis, TMP.OrgUnitID, 0, 1),
           [Verantwortliche/r FV] = dbo.fnGetLastFirstName(TMP.UserID, NULL, NULL),
           [BG]                   = dbo.fnBDEGetPensumPercent(TMP.UserID, @ZeitraumBis),
           --
           [Aktiv SB]             = CASE 
                                      WHEN @NurSozialberatung = 1 THEN 1  -- performance, if only SB, this will be handled anyway above
                                      ELSE CONVERT(BIT, ISNULL(dbo.fnFaIsPersonClientByRule(TMP.BaPersonID, @ZeitraumBis, @OnlyNewClients, 0), 0))  -- only SB or SB and others
                                    END,
           [SB]                   = TMP.SBHoursOnMAAndOrgUnit,
           [CM]                   = TMP.CMHoursOnMAAndOrgUnit,
           [BW]                   = TMP.BWHoursOnMAAndOrgUnit,
           [ED]                   = TMP.EDHoursOnMAAndOrgUnit,
           [AB]                   = TMP.ABHoursOnMAAndOrgUnit,
           [IEBI]                 = TMP.IEBIHoursOnMAAndOrgUnit,
           [Total]                = TMP.TotalHours,
           --
           [Zeitraum]             = @ZeitraumString,
           [Kein Serienbrief]     = PRS.KeinSerienbrief,
           [Anschrift]            = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'anschrift', 0, 1, 'vornach', dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede), 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Anrede]               = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'geehrte', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
           --
           [E-Mail]               = PRS.EMail
    FROM #Temp                TMP
      INNER JOIN dbo.BaPerson PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
      LEFT  JOIN dbo.XOrgUnit ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = TMP.OrgUnitID
      
      -- wohnsitz
      LEFT JOIN dbo.BaAdresse ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
    ORDER BY [Name], [Vorname], [BaPersonID$];
    
    -- info
    PRINT ('done output for <klient>: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- set flag
    SET @DataOutputHappend = 1;
    
    -- check if we need to continue
    IF (ISNULL(@ResultTablesCount, 0) = 1)
    BEGIN
      -- done
      GOTO DONE;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- output 'klient/innen' for Sozialdaten
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1
              FROM @ResultTables
              WHERE ResultTable = 'klientsozdaten'))
  BEGIN
    -- first update missing columns due to performance
    UPDATE TMP
    SET TMP.AnzahlEinsaetzeBW       = (SELECT SUM(ISNULL(LEI.Anzahl, 0))
                                       FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                         INNER JOIN dbo.BDELeistungsart LAR WITH (READUNCOMMITTED) ON LAR.BDELeistungsartID = LEI.BDELeistungsartID AND
                                                                                                      LAR.AuswDienstleistungCode = 2 -- filter by module BW
                                       WHERE LEI.BaPersonID = TMP.BaPersonID AND
                                             LEI.Datum BETWEEN @ZeitraumVon AND @ZeitraumBis),
        TMP.AnzahlEinsaetzeED       = (SELECT SUM(ISNULL(LEI.Anzahl, 0))
                                       FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                         INNER JOIN dbo.BDELeistungsart LAR WITH (READUNCOMMITTED) ON LAR.BDELeistungsartID = LEI.BDELeistungsartID AND
                                                                                                      LAR.AuswDienstleistungCode = 3 -- filter by module ED
                                       WHERE LEI.BaPersonID = TMP.BaPersonID AND
                                             LEI.Datum BETWEEN @ZeitraumVon AND @ZeitraumBis),
        TMP.AnzahlEinsaetzeAB       = (SELECT SUM(ISNULL(LEI.Anzahl, 0))
                                       FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                         INNER JOIN dbo.BDELeistungsart LAR WITH (READUNCOMMITTED) ON LAR.BDELeistungsartID = LEI.BDELeistungsartID AND
                                                                                                      LAR.AuswDienstleistungCode = 25 -- filter by module AB (LOV BDELeistungsartAuswDienstleistung)
                                       WHERE LEI.BaPersonID = TMP.BaPersonID AND
                                             LEI.Datum BETWEEN @ZeitraumVon AND @ZeitraumBis),
        --
        TMP.FaLeistungIDFirstIntake = dbo.fnFaGetFirstIntakeOfFV(TMP.BaPersonID, NULL), -- get first FaLeistungID of IN of last FV 
        TMP.FaLeistungIDLastBW      = dbo.fnFaGetLastFaLeistungID(TMP.BaPersonID, 5),   -- get last FaLeistungID of BW=5
        TMP.FaLeistungIDLastED      = dbo.fnFaGetLastFaLeistungID(TMP.BaPersonID, 6),   -- get last FaLeistungID of ED=6
        TMP.FaLeistungIDLastAB      = dbo.fnFaGetLastFaLeistungID(TMP.BaPersonID, 8)    -- get last FaLeistungID of AB=8 (ModulID)
    FROM #Temp TMP;
    
    -- info
    PRINT ('updated missing columns data on temporary table: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- get data
    SELECT [ResultTable_klientsozdaten$] = 'klientsozdaten',
           --
           [BaPersonID$]               = PRS.BaPersonID,
           [Nr.]                       = PRS.BaPersonID,
           [Name]                      = PRS.Name,
           [Vorname]                   = PRS.Vorname,
           [PLZ]                       = ADRW.PLZ,
           [Ort]                       = ADRW.Ort,
           [Bezirk]                    = ADRW.Bezirk,
           [Kanton]                    = ADRW.Kanton,
           [Nationalität]              = dbo.fnLandMLText(PRS.NationalitaetCode, @LanguageCode),
           [Geschlecht]                = dbo.fnGetGenderMLTitleMF(PRS.GeschlechtCode, @LanguageCode),
           [Geb.Dat.]                  = PRS.Geburtsdatum,
           [Alter]                     = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
           [Vers.-Nr.]                 = PRS.VersichertenNummer,
           [Korrespondenz]             = dbo.fnGetLOVMLText('BaKorrespondenzSprache', PRS.KorrespondenzSpracheCode, @LanguageCode),
           [Hauptbehinderungsart]      = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode),
           [BSV-Behinderungsart]       = dbo.fnGetLOVMLText('BaBSVBehinderungsart', PRS.BSVBehinderungsartCode, @LanguageCode),
           [IV Berechtigung]           = dbo.fnGetLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(TMP.BaPersonID, @ZeitraumBis, 0), @LanguageCode),
           --
           [Kostenstelle]              = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
           [KGS]                       = dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, @ZeitraumBis, TMP.OrgUnitID, 0, 1),
           [Verantwortliche/r FV]      = dbo.fnGetLastFirstName(TMP.UserID, NULL, NULL),
           [Aktiv SB]                  = CASE 
                                           WHEN @NurSozialberatung = 1 THEN 1  -- performance, if only SB, this will be handled anyway above
                                           ELSE CONVERT(BIT, ISNULL(dbo.fnFaIsPersonClientByRule(TMP.BaPersonID, @ZeitraumBis, @OnlyNewClients, 0), 0))  -- only SB or SB and others
                                         END,
           --
           [SB]                        = TMP.SBHoursOnMAAndOrgUnit,
           [CM]                        = TMP.CMHoursOnMAAndOrgUnit,
           [BW]                        = TMP.BWHoursOnMAAndOrgUnit,
           [Anzahl Einsätze BW]        = ISNULL(TMP.AnzahlEinsaetzeBW, 0),
           [ED]                        = TMP.EDHoursOnMAAndOrgUnit,
           [Anzahl Einsätze ED]        = ISNULL(TMP.AnzahlEinsaetzeED, 0),
           [AB]                        = TMP.ABHoursOnMAAndOrgUnit,
           [Anzahl Einsätze AB]        = ISNULL(TMP.AnzahlEinsaetzeAB, 0),
           [IEBI]                      = TMP.IEBIHoursOnMAAndOrgUnit,
           [Total]                     = TMP.TotalHours,
           --
           [Neu]                       = CASE 
                                           WHEN @OnlyNewClients = 1 THEN 1     -- performance, if only new ones, we already have filtered
                                           ELSE dbo.fnFaIsPersonClientByRule(PRS.BaPersonID, @ZeitraumBis, 1, @CheckAdditionModules)
                                         END,
           [Empfohlen von]             = dbo.fnGetLOVMLText('FaIntakeEmpfohlenVon', FAI.EmpfohlenVonCode, @LanguageCode),
           --
           [Zivilstand]                = dbo.fnGetLOVMLText('Zivilstand', PRS.ZivilstandCode, @LanguageCode),
           [Mehrfachbehinderung]       = PRS.Mehrfachbehinderung,
           [Betroffene Lebensbereiche] = dbo.fnLOVMLColumnListe('FaLebensbereich', FAI.AnlassthemenCodes, NULL, @LanguageCode),
           [Wohnstatus]                = dbo.fnGetLOVMLText('BaWohnstatus', PRS.WohnstatusCode, @LanguageCode),
           [Ausländerstatus]           = dbo.fnGetLOVMLText('BaAuslaenderAufenthaltStatus', PRS.AuslaenderStatusCode, @LanguageCode),
           [In der CH seit]            = PRS.InCHSeit,
           [Erwerbssituation]          = dbo.fnGetLOVMLText('BaErwerbssituation', PRS.ErwerbssituationCode, @LanguageCode),
           [Ausbildung]                = dbo.fnGetLOVMLText('BaAusbildungCode', PRS.AusbildungCode, @LanguageCode),
           [Wohnsituation]             = dbo.fnGetLOVMLText('EdWohnsituation', EDA.WohnsituationCode, @LanguageCode),
           [Eigener Mietvertrag]       = PRS.EigenerMietvertrag,
           --
           [Rentenstufe]               = dbo.fnGetLOVMLText('BaRentenstufe', PRS.RentenstufeCode, @LanguageCode),
           [IV-Grad]                   = PRS.IVGrad,
           [Hilfslosenentschädigung]   = dbo.fnGetLOVMLText('BaHilfslosenEntschaedigung', PRS.HilfslosenEntschaedigungCode, @LanguageCode),
           [HELB Kein Antrag]          = PRS.HELBKeinAntrag,
           [HELB Datum Anmeldung]      = PRS.HELBAnmeldung,
           [HELB Datum Entscheid]      = PRS.HELBEntscheid,
           [HELB Entscheid]            = dbo.fnGetLOVMLText('BaHELBEntscheid', PRS.HELBEntscheidCode, @LanguageCode),
           [HELB ab wann]              = PRS.HELBAb,
           --
           [Intensivpflegezuschlag]    = dbo.fnGetLOVMLText('BaIntensivpflegeZuschlag', PRS.IntensivPflegeZuschlagCode, @LanguageCode),
           [IV-Taggeld]                = PRS.IVTaggeld,
           [Berufl. Massnahmen IV]     = PRS.BeruflicheMassnahmeIV,
           [Medizin. Massnahmen IV]    = PRS.MedizinischeMassnahmeIV,
           [IV-Hilfsmittel]            = PRS.IVHilfsmittel,
           [BVG-Rente]                 = PRS.BVGRente,
           [UVG-Rente]                 = PRS.UVGRente,
           [UVG-Taggeld]               = PRS.UVGTaggeld,
           [Sozialhilfe]               = PRS.Sozialhilfe,
           [ALK]                       = PRS.ALK,
           [KTG]                       = PRS.KTG,
           [Ergänzungsleistungen]      = PRS.ErgaenzungsLeistungen,
           --
           [Kantonale Zuschüsse]       = dbo.fnQryGetKantZuschuesseForBaPerson(PRS.BaPersonID, @LanguageCode),
           [Andere Sozialversicherungsleistungen] = PRS.AndereSVLeistungen,
           --
           [Anlass ED]                 = dbo.fnGetLOVMLText('EdAnlass', EDE.AnlassCode, @LanguageCode),
           [Familiensituation]         = dbo.fnGetLOVMLText('EdFamiliensituation', EDA.FamiliensituationCode, @LanguageCode),
           [Betreuung]                 = dbo.fnGetLOVMLText('EdBetreuung', EDA.BetreuungCode, @LanguageCode),
           [Anzahl Geschwister]        = EDA.AnzahlGeschwister,
           [Leistungen Dritter]        = dbo.fnLOVMLColumnListe('EdLeistungDritter', EDA.LeistungenDritterCodes, NULL, @LanguageCode),
           [Finanzielle Ressourcen]    = EDA.FinanzielleRessourcen,
           [Finanzierung durch FLB]    = CONVERT(BIT, ISNULL(EDA.FinanzierungDurchFLB, 0)),
           [Letzte Standordbestimmung] = EDA.LetzteStandortbestimmung,
           --
           [Erster Einsatz BW am]      = BWE.ErsterEinsatzAm,
           [Eintritt von]              = dbo.fnGetLOVMLText('BwEintrittVon', BAO.BwEintrittVonCode, @LanguageCode),
           [Austritt nach]             = dbo.fnGetLOVMLText('BwAustrittNach', BAO.BwAustrittNachCode, @LanguageCode),
           [Anz. (BW) Abw.wochen]      = BAO.AbwesenheitKlient,
           --
           [Zeitraum]                  = @ZeitraumString,
           [Kein Serienbrief]          = PRS.KeinSerienbrief,
           [Anschrift]                 = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'anschrift', 0, 1, 'vornach', dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede), 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Anrede]                    = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'geehrte', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
           --
           [E-Mail]                    = PRS.EMail,
           --
           [Rechnungsadresse ED1]      = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raed1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse ED2]      = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raed2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse BW1]      = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'rabw1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse BW2]      = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'rabw2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse AB1]      = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raab1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse AB2]      = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raab2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse AB3]      = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raab3', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           --
           [Mitglied insieme]          = dbo.fnEdHasClientReduction(EDE.EdEinsatzvereinbarungID, 'insieme'),
           [Mitglied cerebral]         = dbo.fnEdHasClientReduction(EDE.EdEinsatzvereinbarungID, 'cerebral'),
           [Reduktion Brantomy]        = dbo.fnEdHasClientReduction(EDE.EdEinsatzvereinbarungID, 'brantomy')
    FROM #Temp                                TMP
      INNER JOIN dbo.BaPerson                 PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
      LEFT  JOIN dbo.XOrgUnit                 ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = TMP.OrgUnitID
      --
      LEFT  JOIN dbo.FaIntake                 FAI  WITH (READUNCOMMITTED) ON FAI.FaLeistungID = TMP.FaLeistungIDFirstIntake
      --
      LEFT  JOIN dbo.EdAuswertungsdaten       EDA  WITH (READUNCOMMITTED) ON EDA.FaLeistungID = TMP.FaLeistungIDLastED
      LEFT  JOIN dbo.EdEinsatzvereinbarung    EDE  WITH (READUNCOMMITTED) ON EDE.FaLeistungID = TMP.FaLeistungIDLastED
      --
      LEFT  JOIN dbo.BwEinsatzvereinbarung    BWE  WITH (READUNCOMMITTED) ON BWE.FaLeistungID = TMP.FaLeistungIDLastBW
      LEFT  JOIN dbo.BwAuswertungOrganisation BAO  WITH (READUNCOMMITTED) ON BAO.FaLeistungID = TMP.FaLeistungIDLastBW
      --
      -- wohnsitz
      LEFT JOIN dbo.BaAdresse                 ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
    ORDER BY [Name], [Vorname], [BaPersonID$];
    
    -- info
    PRINT ('done output for <klientsozdaten>: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- set flag
    SET @DataOutputHappend = 1;
    
    -- check if we need to continue
    IF (ISNULL(@ResultTablesCount, 0) = 1)
    BEGIN
      -- done
      GOTO DONE;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- output 'klient/innen' for Aktive Dossiers ED
  -- --> does not support multiple outputs due to delete in temp-table
  -----------------------------------------------------------------------------
  IF (@ResultTable = 'klientsozdatened')
  BEGIN
    -- remove all entries that do not have any time on ED
    DELETE TMP
    FROM #Temp TMP
    WHERE TMP.EDHoursOnMAAndOrgUnit = 0.0;
    
    -- info
    PRINT ('removed entries without any time on ED: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
    -- first update missing columns due to performance
    UPDATE TMP
    SET TMP.AnzahlEinsaetzeED  = (SELECT SUM(ISNULL(LEI.Anzahl, 0))
                                  FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                    INNER JOIN dbo.BDELeistungsart LAR WITH (READUNCOMMITTED) ON LAR.BDELeistungsartID = LEI.BDELeistungsartID 
                                                                                             AND LAR.AuswDienstleistungCode = 3 -- filter by module ED
                                  WHERE LEI.BaPersonID = TMP.BaPersonID 
                                    AND LEI.Datum BETWEEN @ZeitraumVon AND @ZeitraumBis),
        TMP.FaLeistungIDLastED = dbo.fnFaGetLastFaLeistungID(TMP.BaPersonID, 6)    -- get last FaLeistungID of ED=6
    FROM #Temp TMP;
    
    -- info
    PRINT ('updated missing columns data on temporary table: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- check if we need to filter userid
    IF (@UserIDZustaendigModule IS NOT NULL)
    BEGIN
      -- remove those entries where userid of last ED does not match with given module-userid of filter
      DELETE TMP
      FROM #Temp                 TMP
        LEFT JOIN dbo.FaLeistung LEI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TMP.FaLeistungIDLastED
      WHERE ISNULL(LEI.UserID, -1) <> @UserIDZustaendigModule;
      
      -- info
      PRINT ('filtered data for module specific userid: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    END;
    
    -- get data
    SELECT [ResultTable_klientsozdatened$] = 'klientsozdatened',
           --
           [BaPersonID$]               = PRS.BaPersonID,
           [Nr.]                       = PRS.BaPersonID,
           [Name]                      = PRS.Name,
           [Vorname]                   = PRS.Vorname,
           [PLZ]                       = ADRW.PLZ,
           [Ort]                       = ADRW.Ort,
           [Bezirk]                    = ADRW.Bezirk,
           [Kanton]                    = ADRW.Kanton,
           [Nationalität]              = dbo.fnLandMLText(PRS.NationalitaetCode, @LanguageCode),
           [Geschlecht]                = dbo.fnGetGenderMLTitleMF(PRS.GeschlechtCode, @LanguageCode),
           [Geb.Dat.]                  = PRS.Geburtsdatum,
           [Alter]                     = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
           [Vers.-Nr.]                 = PRS.VersichertenNummer,
           [Hauptbehinderungsart]      = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode),
           [BSV-Behinderungsart]       = dbo.fnGetLOVMLText('BaBSVBehinderungsart', PRS.BSVBehinderungsartCode, @LanguageCode),
           [IV Berechtigung]           = dbo.fnGetLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(TMP.BaPersonID, @ZeitraumBis, 0), @LanguageCode),
           --
           [Kostenstelle]              = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
           [KGS]                       = dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, @ZeitraumBis, TMP.OrgUnitID, 0, 1),
           --
           [Zuständig ED]                   = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
           [Erstellung Einsatzvereinbarung] = EDE.ErstellungEV,
           [Erster Einsatz am]              = EDE.ErsterEinsatzAm,
           [Anzahl Entlastungsstunden]      = TMP.EDHoursOnMAAndOrgUnit,
           [Anzahl Einsätze ED]             = TMP.AnzahlEinsaetzeED,
           [Letzte Standortbestimmung]      = EDA.LetzteStandortbestimmung,
           --
           [Zeitraum]                  = @ZeitraumString,
           [Kein Serienbrief]          = PRS.KeinSerienbrief,
           [Anschrift]                 = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'anschrift', 0, 1, 'vornach', dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede), 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Anrede]                    = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'geehrte', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
           --
           [E-Mail]                    = PRS.EMail,
           --
           [Rechnungsadresse ED1]      = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raed1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse ED2]      = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raed2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
    FROM #Temp                             TMP
      INNER JOIN dbo.BaPerson              PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
      LEFT  JOIN dbo.XOrgUnit              ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = TMP.OrgUnitID
      --
      LEFT  JOIN dbo.FaLeistung            LEI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TMP.FaLeistungIDLastED
      LEFT  JOIN dbo.EdAuswertungsdaten    EDA  WITH (READUNCOMMITTED) ON EDA.FaLeistungID = TMP.FaLeistungIDLastED
      LEFT  JOIN dbo.EdEinsatzvereinbarung EDE  WITH (READUNCOMMITTED) ON EDE.FaLeistungID = TMP.FaLeistungIDLastED
      --
      -- wohnsitz
      LEFT JOIN dbo.BaAdresse              ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
    ORDER BY [Name], [Vorname], [BaPersonID$];
    
    -- info
    PRINT ('done output for <klientsozdatened>: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- set flag
    SET @DataOutputHappend = 1;
    
    -- done
    GOTO DONE;
  END;
  
  -----------------------------------------------------------------------------
  -- output 'klient/innen' for Aktive Dossiers BW
  -- --> does not support multiple outputs due to delete in temp-table
  -----------------------------------------------------------------------------
  IF (@ResultTable = 'klientsozdatenbw')
  BEGIN
    -- remove all entries that do not have any time on BW
    DELETE TMP
    FROM #Temp TMP
    WHERE TMP.BWHoursOnMAAndOrgUnit = 0.0;
    
    -- info
    PRINT ('removed entries without any time on BW: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- first update missing columns due to performance
    UPDATE TMP
    SET TMP.BWHoursReduzierteFaktura = ISNULL((SELECT SUM(ISNULL(LEI.Dauer, 0.0))
                                               FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                                 INNER JOIN dbo.BDELeistungsart LAR WITH (READUNCOMMITTED) ON LAR.BDELeistungsartID = LEI.BDELeistungsartID 
                                                                                                          AND LAR.AuswDienstleistungCode = 2 -- filter by module BW
                                                                                                          AND LAR.AuswPIAuftragCode = 13     -- filter by "BW Reduzierte Faktura"
                                               WHERE LEI.BaPersonID = TMP.BaPersonID 
                                                 AND LEI.Datum BETWEEN @ZeitraumVon AND @ZeitraumBis), 0.0),
        TMP.BWHoursVollkosten        = ISNULL((SELECT SUM(ISNULL(LEI.Dauer, 0.0))
                                               FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                                 INNER JOIN dbo.BDELeistungsart LAR WITH (READUNCOMMITTED) ON LAR.BDELeistungsartID = LEI.BDELeistungsartID 
                                                                                                          AND LAR.AuswDienstleistungCode = 2 -- filter by module BW
                                                                                                          AND LAR.AuswPIAuftragCode = 12     -- filter by "BW Faktura Vollkosten"
                                               WHERE LEI.BaPersonID = TMP.BaPersonID 
                                                 AND LEI.Datum BETWEEN @ZeitraumVon AND @ZeitraumBis), 0.0),
        --
        TMP.AnzahlEinsaetzeBW  = (SELECT SUM(ISNULL(LEI.Anzahl, 0))
                                  FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                    INNER JOIN dbo.BDELeistungsart LAR WITH (READUNCOMMITTED) ON LAR.BDELeistungsartID = LEI.BDELeistungsartID 
                                                                                             AND LAR.AuswDienstleistungCode = 2 -- filter by module BW
                                  WHERE LEI.BaPersonID = TMP.BaPersonID 
                                    AND LEI.Datum BETWEEN @ZeitraumVon AND @ZeitraumBis),
        TMP.FaLeistungIDLastBW = dbo.fnFaGetLastFaLeistungID(TMP.BaPersonID, 5)    -- get last FaLeistungID of BW=5
    FROM #Temp TMP;
    
    -- info
    PRINT ('updated missing columns data on temporary table: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- check if we need to filter userid
    IF (@UserIDZustaendigModule IS NOT NULL)
    BEGIN
      -- remove those entries where userid of last BW does not match with given module-userid of filter
      DELETE TMP
      FROM #Temp                 TMP
        LEFT JOIN dbo.FaLeistung LEI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TMP.FaLeistungIDLastBW
      WHERE ISNULL(LEI.UserID, -1) <> @UserIDZustaendigModule;
      
      -- info
      PRINT ('filtered data for module specific userid: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    END;
    
    -- init vars used for ML texts
    DECLARE @BefristetML VARCHAR(100);
    DECLARE @UnbefristetML VARCHAR(100);
    
    SELECT @BefristetML   = dbo.fnXDbObjectMLMsg('spQRYAktiveNeueDossiers', 'Befristet', @LanguageCode),
           @UnbefristetML = dbo.fnXDbObjectMLMsg('spQRYAktiveNeueDossiers', 'Unbefristet', @LanguageCode);
    
    -- get data
    SELECT [ResultTable_klientsozdatenbw$] = 'klientsozdatenbw',
           --
           [BaPersonID$]               = PRS.BaPersonID,
           [Nr.]                       = PRS.BaPersonID,
           [Name]                      = PRS.Name,
           [Vorname]                   = PRS.Vorname,
           [PLZ]                       = ADRW.PLZ,
           [Ort]                       = ADRW.Ort,
           [Bezirk]                    = ADRW.Bezirk,
           [Kanton]                    = ADRW.Kanton,
           [Nationalität]              = dbo.fnLandMLText(PRS.NationalitaetCode, @LanguageCode),
           [Geschlecht]                = dbo.fnGetGenderMLTitleMF(PRS.GeschlechtCode, @LanguageCode),
           [Geb.Dat.]                  = PRS.Geburtsdatum,
           [Alter]                     = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
           [Vers.-Nr.]                 = PRS.VersichertenNummer,
           [Hauptbehinderungsart]      = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode),
           [BSV-Behinderungsart]       = dbo.fnGetLOVMLText('BaBSVBehinderungsart', PRS.BSVBehinderungsartCode, @LanguageCode),
           [IV Berechtigung]           = dbo.fnGetLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(TMP.BaPersonID, @ZeitraumBis, 0), @LanguageCode),
           --
           [Kostenstelle]              = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
           [KGS]                       = dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, @ZeitraumBis, TMP.OrgUnitID, 0, 1),
           --
           [Zuständig BW]              = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
           [HELB Kein Antrag]          = PRS.HELBKeinAntrag,
           [HELB Datum Anmeldung]      = PRS.HELBAnmeldung,
           [HELB Datum Entscheid]      = PRS.HELBEntscheid,
           [HELB Entscheid]            = dbo.fnGetLOVMLText('BaHELBEntscheid', PRS.HELBEntscheidCode, @LanguageCode),
           [HELB ab wann]              = PRS.HELBAb,
           --
           [Erstellung Einsatzvereinbarung] = BEV.ErstellungEV,
           [Befristung]                     = CASE
                                                WHEN AWO.LeistungIstBefristet = 1 THEN @BefristetML
                                                ELSE @UnbefristetML
                                              END,
           [Befristed bis]                  = AWO.BefristetBis,
           [Erster Einsatz am]              = BEV.ErsterEinsatzAm,
           [Eintritt von]                   = dbo.fnGetLOVMLText('BwEintrittVon', AWO.BwEintrittVonCode, @LanguageCode),
           [Austritt nach]                  = dbo.fnGetLOVMLText('BwAustrittNach', AWO.BwAustrittNachCode, @LanguageCode),
           --
           [Anz. Stunden BW reduzierte Faktura] = TMP.BWHoursReduzierteFaktura,
           [Anz. Stunden BW Faktura Vollkosten] = TMP.BWHoursVollkosten,
           [Anz. Stunden Summe]                 = TMP.BWHoursReduzierteFaktura + TMP.BWHoursVollkosten,
           --
           [Anzahl Einsätze BW]        = TMP.AnzahlEinsaetzeBW,
           [Anzahl Abwesenheitswochen] = AWO.AbwesenheitKlient,
           [Abschluss BW]              = LEI.DatumBis,
           --
           [Zeitraum]                  = @ZeitraumString,
           [Kein Serienbrief]          = PRS.KeinSerienbrief,
           [Anschrift]                 = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'anschrift', 0, 1, 'vornach', dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede), 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Anrede]                    = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'geehrte', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
           --
           [E-Mail]                    = PRS.EMail,
           --
           [Rechnungsadresse BW1]      = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'rabw1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse BW2]      = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'rabw2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
    FROM #Temp                                TMP
      INNER JOIN dbo.BaPerson                 PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
      LEFT  JOIN dbo.XOrgUnit                 ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = TMP.OrgUnitID
      --
      LEFT  JOIN dbo.FaLeistung               LEI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TMP.FaLeistungIDLastBW
      LEFT  JOIN dbo.BwAuswertungOrganisation AWO  WITH (READUNCOMMITTED) ON AWO.FaLeistungID = TMP.FaLeistungIDLastBW
      LEFT  JOIN dbo.BwEinsatzvereinbarung    BEV  WITH (READUNCOMMITTED) ON BEV.FaLeistungID = TMP.FaLeistungIDLastBW
      --
      -- wohnsitz
      LEFT JOIN dbo.BaAdresse                 ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
    ORDER BY [Name], [Vorname], [BaPersonID$];
    
    -- info
    PRINT ('done output for <klientsozdatenbw>: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- set flag
    SET @DataOutputHappend = 1;
    
    -- done
    GOTO DONE;
  END;
  
  -----------------------------------------------------------------------------
  -- output 'klient/innen' for Aktive Dossiers AB
  -- --> does not support multiple outputs due to delete in temp-table
  -----------------------------------------------------------------------------
  IF (@ResultTable = 'klientsozdatenab')
  BEGIN
    -- remove all entries that do not have any time on AB
    DELETE TMP
    FROM #Temp TMP
    WHERE TMP.ABHoursOnMAAndOrgUnit = 0.0;
    
    -- info
    PRINT ('removed entries without any time on AB: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
    -- first update missing columns due to performance
    UPDATE TMP
    SET TMP.AnzahlEinsaetzeAB  = (SELECT SUM(ISNULL(LEI.Anzahl, 0))
                                  FROM dbo.BDELeistung LEI WITH (READUNCOMMITTED)
                                    INNER JOIN dbo.BDELeistungsart LAR WITH (READUNCOMMITTED) ON LAR.BDELeistungsartID = LEI.BDELeistungsartID 
                                                                                             AND LAR.AuswDienstleistungCode = 25 -- filter by module AB
                                  WHERE LEI.BaPersonID = TMP.BaPersonID 
                                    AND LEI.Datum BETWEEN @ZeitraumVon AND @ZeitraumBis),
        TMP.FaLeistungIDLastAB = dbo.fnFaGetLastFaLeistungID(TMP.BaPersonID, 8)    -- get last FaLeistungID of AB=8
    FROM #Temp TMP;
    
    -- info
    PRINT ('updated missing columns data on temporary table: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- check if we need to filter userid
    IF (@UserIDZustaendigModule IS NOT NULL)
    BEGIN
      -- remove those entries where userid of last AB does not match with given module-userid of filter
      DELETE TMP
      FROM #Temp                 TMP
        LEFT JOIN dbo.FaLeistung LEI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TMP.FaLeistungIDLastAB
      WHERE ISNULL(LEI.UserID, -1) <> @UserIDZustaendigModule;
      
      -- info
      PRINT ('filtered data for module specific userid: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    END;
    
    -- get data
    SELECT [ResultTable_klientsozdatenab$] = 'klientsozdatenab',
           --
           [BaPersonID$]          = PRS.BaPersonID,
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
           [IV Status]            = dbo.fnGetLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(TMP.BaPersonID, @ZeitraumBis, 1), @LanguageCode),
           --                     
           [Kostenstelle]         = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
           [KGS]                  = dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, @ZeitraumBis, TMP.OrgUnitID, 0, 1),
           --
           [Zuständig AB]                = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
           [Assistenzbeitrag]            = PRS.Assistenzbeitrag,
           [Datum Verfügung Ass.beitrag] = PRS.DatumAssistenzbeitrag,
           [IV verfügte Std. AB]         = PRS.IvVerfuegteAssistenzberatung,
           [Datum Verfügung AB]          = PRS.DatumIvVerfuegung,
           [Hilfslosenentschädigung]     = dbo.fnGetLOVMLText('BaHilfslosenEntschaedigung', PRS.HilfslosenEntschaedigungCode, @LanguageCode),
           [Ergänzungsleistungen]        = PRS.ErgaenzungsLeistungen,
           [Stunden AB]                  = TMP.ABHoursOnMAAndOrgUnit,
           [Eröffnung AB]                = LEI.DatumVon,
           [Abschluss AB]                = LEI.DatumBis,
           --
           [Zeitraum]             = @ZeitraumString,
           [Kein Serienbrief]     = PRS.KeinSerienbrief,
           [Anschrift]            = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'anschrift', 0, 1, 'vornach', dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede), 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Anrede]               = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, @LanguageCode, 'geehrte', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
           --
           [E-Mail]               = PRS.EMail,
           --                     
           [Rechnungsadresse AB1] = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raab1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse AB2] = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raab2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
           [Rechnungsadresse AB3] = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, @LanguageCode, 1, 'raab3', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
    FROM #Temp                             TMP
      INNER JOIN dbo.BaPerson              PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
      LEFT  JOIN dbo.XOrgUnit              ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = TMP.OrgUnitID
      --
      LEFT  JOIN dbo.FaLeistung            LEI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TMP.FaLeistungIDLastAB
      --
      -- Wohnsitz
      LEFT JOIN dbo.BaAdresse              ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
    ORDER BY [Name], [Vorname], [BaPersonID$];
    
    -- info
    PRINT ('done output for <klientsozdatenab>: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- set flag
    SET @DataOutputHappend = 1;
    
    -- done
    GOTO DONE;
  END;
  
  -----------------------------------------------------------------------------
  -- output 'mitarbeiter/innen'
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1
              FROM @ResultTables
              WHERE ResultTable = 'mitarbeiter'))
  BEGIN
    SELECT [ResultTable_mitarbeiter$] = 'mitarbeiter',
           --
           [Mitarbeiter/in]       = dbo.fnGetLastFirstName(TMP.UserID, NULL, NULL),
           [BG]                   = dbo.fnBDEGetPensumPercent(TMP.UserID, @ZeitraumBis),
           [KGS]                  = dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, @ZeitraumBis, TMP.OrgUnitID, 0, 1),
           --
           [SB]                   = SUM(TMP.SBHoursOnMAAndOrgUnit),
           [Kl. SB]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.UserID = TMP.UserID
                                       AND SUB.SBHoursOnMAAndOrgUnit > 0.0),
           --
           [CM]                   = SUM(TMP.CMHoursOnMAAndOrgUnit),
           [Kl. CM]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.UserID = TMP.UserID
                                       AND SUB.CMHoursOnMAAndOrgUnit > 0.0),
           --
           [BW]                   = SUM(TMP.BWHoursOnMAAndOrgUnit),
           [Kl. BW]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.UserID = TMP.UserID
                                       AND SUB.BWHoursOnMAAndOrgUnit > 0.0),
           --
           [ED]                   = SUM(TMP.EDHoursOnMAAndOrgUnit),
           [Kl. ED]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.UserID = TMP.UserID
                                       AND SUB.EDHoursOnMAAndOrgUnit > 0.0),
           --
           [AB]                   = SUM(TMP.ABHoursOnMAAndOrgUnit),
           [Kl. AB]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.UserID = TMP.UserID
                                       AND SUB.ABHoursOnMAAndOrgUnit > 0.0),
           --
           [IEBI]                 = SUM(TMP.IEBIHoursOnMAAndOrgUnit),
           [Kl. IEBI]             = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.UserID = TMP.UserID
                                       AND SUB.IEBIHoursOnMAAndOrgUnit > 0.0),
           --
           [Total]        = SUM(TMP.TotalHours),
           [Zeitraum]     = @ZeitraumString
    FROM #Temp TMP
    GROUP BY TMP.UserID, TMP.OrgUnitID
    ORDER BY [Mitarbeiter/in], [KGS];
    
    -- info
    PRINT ('done output for <mitarbeiter>: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- set flag
    SET @DataOutputHappend = 1;
    
    -- check if we need to continue
    IF (ISNULL(@ResultTablesCount, 0) = 1)
    BEGIN
      -- done
      GOTO DONE;
    END;
  END;

  -----------------------------------------------------------------------------
  -- output 'kostenstellen'
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1
              FROM @ResultTables
              WHERE ResultTable = 'kostenstelle'))
  BEGIN
    SELECT [ResultTable_kostenstelle$] = 'kostenstelle',
           --
           [Kostenstelle] = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
           [KGS]          = dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, @ZeitraumBis, TMP.OrgUnitID, 0, 1),
           --
           [SB]           = SUM(TMP.SBHoursOnMAAndOrgUnit),
           [Kl. SB]       = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                             FROM #Temp SUB
                             WHERE SUB.OrgUnitID = TMP.OrgUnitID 
                               AND SUB.SBHoursOnMAAndOrgUnit > 0.0),
           --
           [CM]           = SUM(TMP.CMHoursOnMAAndOrgUnit),
           [Kl. CM]       = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                             FROM #Temp SUB
                             WHERE SUB.OrgUnitID = TMP.OrgUnitID 
                               AND SUB.CMHoursOnMAAndOrgUnit > 0.0),
           --
           [BW]           = SUM(TMP.BWHoursOnMAAndOrgUnit),
           [Kl. BW]       = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                             FROM #Temp SUB
                             WHERE SUB.OrgUnitID = TMP.OrgUnitID 
                               AND SUB.BWHoursOnMAAndOrgUnit > 0.0),
           --
           [ED]           = SUM(TMP.EDHoursOnMAAndOrgUnit),
           [Kl. ED]       = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                             FROM #Temp SUB
                             WHERE SUB.OrgUnitID = TMP.OrgUnitID 
                               AND SUB.EDHoursOnMAAndOrgUnit > 0.0),
           --
           [AB]           = SUM(TMP.ABHoursOnMAAndOrgUnit),
           [Kl. AB]       = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                             FROM #Temp SUB
                             WHERE SUB.OrgUnitID = TMP.OrgUnitID 
                               AND SUB.ABHoursOnMAAndOrgUnit > 0.0),
           --
           [IEBI]         = SUM(TMP.IEBIHoursOnMAAndOrgUnit),
           [Kl. IEBI]     = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                             FROM #Temp SUB
                             WHERE SUB.OrgUnitID = TMP.OrgUnitID 
                               AND SUB.IEBIHoursOnMAAndOrgUnit > 0.0),
           --
           [Total]        = SUM(TMP.TotalHours),
           [Zeitraum]     = @ZeitraumString
    FROM #Temp TMP
      LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = TMP.OrgUnitID
    GROUP BY ORG.ItemName, TMP.OrgUnitID, ORG.Kostenstelle
    ORDER BY [Kostenstelle];
    
    -- info
    PRINT ('done output for <kostenstelle>: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- set flag
    SET @DataOutputHappend = 1;
    
    -- check if we need to continue
    IF (ISNULL(@ResultTablesCount, 0) = 1)
    BEGIN
      -- done
      GOTO DONE;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- output 'hauptbehinderung'
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1
              FROM @ResultTables
              WHERE ResultTable = 'hauptbehinderung'))
  BEGIN
    SELECT [ResultTable_hauptbehinderung$] = 'hauptbehinderung',
           --
           [Hauptbehinderungsart] = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode),
           --
           [SB]                   = SUM(TMP.SBHoursOnMAAndOrgUnit),
           [Kl. SB]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1) AND
                                           SUB.SBHoursOnMAAndOrgUnit > 0.0),
           --
           [CM]                   = SUM(TMP.CMHoursOnMAAndOrgUnit),
           [Kl. CM]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1) AND
                                           SUB.CMHoursOnMAAndOrgUnit > 0.0),
           --
           [BW]                   = SUM(TMP.BWHoursOnMAAndOrgUnit),
           [Kl. BW]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1) AND
                                           SUB.BWHoursOnMAAndOrgUnit > 0.0),
           --
           [ED]                   = SUM(TMP.EDHoursOnMAAndOrgUnit),
           [Kl. ED]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1) AND
                                           SUB.EDHoursOnMAAndOrgUnit > 0.0),
           --
           [AB]                   = SUM(TMP.ABHoursOnMAAndOrgUnit),
           [Kl. AB]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1) AND
                                           SUB.ABHoursOnMAAndOrgUnit > 0.0),
           --
           [IEBI]                 = SUM(TMP.IEBIHoursOnMAAndOrgUnit),
           [Kl. IEBI]             = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.HauptBehinderungsartCode, -1) = ISNULL(PRS.HauptBehinderungsartCode, -1) AND
                                           SUB.IEBIHoursOnMAAndOrgUnit > 0.0),
           --
           [Total]                = SUM(TMP.TotalHours),
           [Zeitraum]             = @ZeitraumString
    FROM #Temp TMP
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
    GROUP BY dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode), PRS.HauptBehinderungsartCode
    ORDER BY [Hauptbehinderungsart];
    
    -- info
    PRINT ('done output for <hauptbehinderung>: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- set flag
    SET @DataOutputHappend = 1;
    
    -- check if we need to continue
    IF (ISNULL(@ResultTablesCount, 0) = 1)
    BEGIN
      -- done
      GOTO DONE;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- output 'bsv-behinderung'
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1
              FROM @ResultTables
              WHERE ResultTable = 'bsv-behinderung'))
  BEGIN
    SELECT [ResultTable_bsv-behinderung$] = 'bsv-behinderung',
           --
           [BSV-Behinderungsart]  = dbo.fnGetLOVMLText('BaBSVBehinderungsart', PRS.BSVBehinderungsartCode, @LanguageCode),
           --
           [SB]                   = SUM(TMP.SBHoursOnMAAndOrgUnit),
           [Kl. SB]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.BSVBehinderungsartCode, -1) = ISNULL(PRS.BSVBehinderungsartCode, -1) AND
                                           SUB.SBHoursOnMAAndOrgUnit > 0.0),
           --
           [CM]                   = SUM(TMP.CMHoursOnMAAndOrgUnit),
           [Kl. CM]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.BSVBehinderungsartCode, -1) = ISNULL(PRS.BSVBehinderungsartCode, -1) AND
                                           SUB.CMHoursOnMAAndOrgUnit > 0.0),
           --
           [BW]                   = SUM(TMP.BWHoursOnMAAndOrgUnit),
           [Kl. BW]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.BSVBehinderungsartCode, -1) = ISNULL(PRS.BSVBehinderungsartCode, -1) AND
                                           SUB.BWHoursOnMAAndOrgUnit > 0.0),
           --
           [ED]                   = SUM(TMP.EDHoursOnMAAndOrgUnit),
           [Kl. ED]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.BSVBehinderungsartCode, -1) = ISNULL(PRS.BSVBehinderungsartCode, -1) AND
                                           SUB.EDHoursOnMAAndOrgUnit > 0.0),
           --
           [AB]                   = SUM(TMP.ABHoursOnMAAndOrgUnit),
           [Kl. AB]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.BSVBehinderungsartCode, -1) = ISNULL(PRS.BSVBehinderungsartCode, -1) AND
                                           SUB.ABHoursOnMAAndOrgUnit > 0.0),
           --
           [IEBI]                 = SUM(TMP.IEBIHoursOnMAAndOrgUnit),
           [Kl. IEBI]             = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                       INNER JOIN dbo.BaPerson SPR WITH (READUNCOMMITTED) ON SPR.BaPersonID = SUB.BaPersonID
                                     WHERE ISNULL(SPR.BSVBehinderungsartCode, -1) = ISNULL(PRS.BSVBehinderungsartCode, -1) AND
                                           SUB.IEBIHoursOnMAAndOrgUnit > 0.0),
           --
           [Total]                = SUM(TMP.TotalHours),
           [Zeitraum]             = @ZeitraumString
    FROM #Temp TMP
      INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
    GROUP BY dbo.fnGetLOVMLText('BaBSVBehinderungsart', PRS.BSVBehinderungsartCode, @LanguageCode), PRS.BSVBehinderungsartCode
    ORDER BY [BSV-Behinderungsart];
    
    -- info
    PRINT ('done output for <bsv-behinderung>: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- set flag
    SET @DataOutputHappend = 1;
    
    -- check if we need to continue
    IF (ISNULL(@ResultTablesCount, 0) = 1)
    BEGIN
      -- done
      GOTO DONE;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- output 'iv-berechtigung'
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1
              FROM @ResultTables
              WHERE ResultTable = 'iv-berechtigung'))
  BEGIN
    -- first update iv-berechtigung, otherwise performance will be pretty low
    UPDATE TMP
    SET TMP.BaIVBerechtigungCode = ISNULL(dbo.fnBaGetIVBerechtigungStatus(TMP.BaPersonID, @ZeitraumBis, 0), -1)
    FROM #Temp TMP
    
    -- info
    PRINT ('updated BaIVBerechtigungCode on temporary table: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114))
    
    -- get other data   
    SELECT [ResultTable_iv-berechtigung$] = 'iv-berechtigung',
           --
           [IV Berechtigung]      = dbo.fnGetLOVMLText('BaIVBerechtigung', TMP.BaIVBerechtigungCode, @LanguageCode),
           --
           [SB]                   = SUM(TMP.SBHoursOnMAAndOrgUnit),
           [Kl. SB]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.BaIVBerechtigungCode = TMP.BaIVBerechtigungCode AND
                                           SUB.SBHoursOnMAAndOrgUnit > 0.0),
           --
           [CM]                   = SUM(TMP.CMHoursOnMAAndOrgUnit),
           [Kl. CM]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.BaIVBerechtigungCode = TMP.BaIVBerechtigungCode AND
                                           SUB.CMHoursOnMAAndOrgUnit > 0.0),
           --
           [BW]                   = SUM(TMP.BWHoursOnMAAndOrgUnit),
           [Kl. BW]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.BaIVBerechtigungCode = TMP.BaIVBerechtigungCode AND
                                           SUB.BWHoursOnMAAndOrgUnit > 0.0),
           --
           [ED]                   = SUM(TMP.EDHoursOnMAAndOrgUnit),
           [Kl. ED]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.BaIVBerechtigungCode = TMP.BaIVBerechtigungCode AND
                                           SUB.EDHoursOnMAAndOrgUnit > 0.0),
           --
           [AB]                   = SUM(TMP.ABHoursOnMAAndOrgUnit),
           [Kl. AB]               = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.BaIVBerechtigungCode = TMP.BaIVBerechtigungCode AND
                                           SUB.ABHoursOnMAAndOrgUnit > 0.0),
           --
           [IEBI]                 = SUM(TMP.IEBIHoursOnMAAndOrgUnit),
           [Kl. IEBI]             = (SELECT COUNT(DISTINCT SUB.BaPersonID)
                                     FROM #Temp SUB
                                     WHERE SUB.BaIVBerechtigungCode = TMP.BaIVBerechtigungCode AND
                                           SUB.IEBIHoursOnMAAndOrgUnit > 0.0),
           --
           [Total]                = SUM(TMP.TotalHours),
           [Zeitraum]             = @ZeitraumString
    FROM #Temp TMP
    GROUP BY TMP.BaIVBerechtigungCode
    ORDER BY [IV Berechtigung];
    
    -- info
    PRINT ('done output for <iv-berechtigung>: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    
    -- set flag
    SET @DataOutputHappend = 1;
    
    -- check if we need to continue
    IF (ISNULL(@ResultTablesCount, 0) = 1)
    BEGIN
      -- done
      GOTO DONE;
    END;
  END;
  
  -----------------------------------------------------------------------------
  -- check if we have any output given
  -----------------------------------------------------------------------------
  IF (ISNULL(@DataOutputHappend, 0) = 0)
  BEGIN
    -- invalid result table
    SELECT [Error]       = 'Error: Invalid parametes for result table(s) "' + ISNULL(@ResultTable, '<NULL>') + '", cannot display proper data!',
           [BaPersonID$] = NULL;
  END;
  
  -- done
  GOTO DONE;
  
-- ****************************************************************************
-- FINAL STUFF
-- ****************************************************************************
DONE:
  -- remove temporary table
  DROP TABLE #Temp;
  
  -- info
  PRINT ('cleanup of temporary table succeeded: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
END;
GO