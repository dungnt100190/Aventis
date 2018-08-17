SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spQRYOffeneMussfelder;
GO
/*===============================================================================================
  $Revision: 14 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to get values for query "Offene Mussfelder"
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
  TEST:    EXEC dbo.spQRYOffeneMussfelder 1, NULL, 2008, NULL, 2, 1, 1
           EXEC dbo.spQRYOffeneMussfelder 1, 76, 2008, NULL, 2, 1, 1  -- BS Aarau
=================================================================================================*/

CREATE PROCEDURE dbo.spQRYOffeneMussfelder
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
  
  -- init start
  DECLARE @StartTimeOfCode DATETIME;
  SET @StartTimeOfCode = GETDATE();
  
  PRINT ('start call: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
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
  DECLARE @BirthdayDateML VARCHAR(100);
  DECLARE @IdentityML VARCHAR(100);
  
  SELECT @BirthdayDateML = dbo.fnXDbObjectMLMsg('dbGeneral', 'Geburtsdatum', @LanguageCode),
         @IdentityML     = dbo.fnXDbObjectMLMsg('dbGeneral', 'ID', @LanguageCode);
  
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
    SELECT [Error]          = 'Error: Invalid parametes, cannot search data!',
           [BaPersonID$]    = NULL,
           [NameVornameID$] = NULL;
    
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
  DECLARE @Temp TABLE
  (
    ID$ INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    BaPersonID INT NOT NULL UNIQUE,
    BaLandID_Wohnsitz INT,
    FaLeistungIDLastFV INT NOT NULL,
    UserID INT,
    OrgUnitID INT
  );
  
  -- info
  PRINT ('done init: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -------------------------------------------------------------------------------
  -- fill temp table with persons
  -------------------------------------------------------------------------------
  INSERT INTO @Temp (BaPersonID, BaLandID_Wohnsitz, FaLeistungIDLastFV, UserID)
    SELECT BaPersonID         = PRS.BaPersonID,
           BaLandID_Wohnsitz  = ADRW.BaLandID,
           FaLeistungIDLastFV = LEI.FaLeistungID,
           UserID             = LEI.UserID
    FROM dbo.BaPerson           PRS WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung LEI  WITH (READUNCOMMITTED) ON LEI.BaPersonID = PRS.BaPersonID  
                                                           AND LEI.ModulID = 2  -- only FV
                                                           AND LEI.FaLeistungID = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 2) -- only last FV
      -- wohnsitz
      LEFT JOIN dbo.BaAdresse   ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
    WHERE (-- gesetzlicher wohnsitz
           ISNULL(PRS.Name, '') = '' OR
           ISNULL(PRS.Vorname, '') = '' OR
           ISNULL(ADRW.Ort, '') = '' OR
           
           -- others
           PRS.HauptBehinderungsartCode IS NULL OR
           PRS.BSVBehinderungsartCode IS NULL OR                                              -- we also need to have BSVBehinderungsartCode (depends on HautBehinderungsartCode)!
           PRS.Geburtsdatum IS NULL OR
           PRS.GeschlechtCode IS NULL OR
           ISNULL(PRS.VersichertenNummer, '') = '' OR
           PRS.AusbildungCode IS NULL OR
           PRS.ErwerbssituationCode IS NULL OR
           PRS.RentenstufeCode IS NULL OR
           
           -- validate WohnsitzLandCode (has to be active)
           NOT EXISTS(SELECT TOP 1 1
                      FROM dbo.BaLand LAN WITH (READUNCOMMITTED)
                      WHERE LAN.BaLandID = ISNULL(ADRW.BaLandID, -1) AND                     -- matching entry
                            LAN.DatumVon <= @DatumVon AND
                            ISNULL(LAN.DatumBis, '9999-12-31') >= @DatumBis) OR              -- entry has to be active
           
           -- iv-berechtigung
           NOT EXISTS(SELECT TOP 1 1 
                      FROM dbo.BaIVBerechtigung BIB WITH (READUNCOMMITTED) 
                      WHERE BIB.BaPersonID = PRS.BaPersonID AND                               -- same person
                            BIB.DatumVon <= @DatumBis) OR                                     -- has entry before or equal to current date
           
           -- validate NationalitaetCode (has to be active)
           NOT EXISTS(SELECT TOP 1 1
                      FROM dbo.BaLand LAN WITH (READUNCOMMITTED)
                      WHERE LAN.BaLandID = ISNULL(PRS.NationalitaetCode, -1) AND              -- matching entry
                            LAN.DatumVon <= @DatumVon AND
                            ISNULL(LAN.DatumBis, '9999-12-31') >= @DatumBis) OR               -- entry has to be active
                      
           -- ZugewiesenDurch (of first Intake of last FV has to be given)
           NOT EXISTS(SELECT TOP 1 1
                      FROM dbo.FaIntake FAI WITH (READUNCOMMITTED)
                      WHERE FAI.FaLeistungID = dbo.fnFaGetFirstIntakeOfFV(PRS.BaPersonID, LEI.FaLeistungID) AND
                            FAI.EmpfohlenVonCode IS NOT NULL)
          ); -- filtering by non defined but required fields
  
  -- info
  PRINT ('filled temp table with persons: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -------------------------------------------------------------------------------
  -- filter by search-filter
  -------------------------------------------------------------------------------
  -- if userid is defined, remove entries that are not for current user
  IF (@UserID IS NOT NULL)
  BEGIN
    -- remove entries where current user is not FV-responsible
    DELETE TMP
    FROM @Temp TMP
    WHERE ISNULL(TMP.UserID, -1) <> @UserID;
    
    -- info
    PRINT ('filtered userid: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  END;
  
  -- FILTER ORGUNIT:
  -- fill orgunit of user (last-FV-responsible-membership)
  UPDATE TMP
  SET TMP.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(TMP.UserID, 1))
  FROM @Temp TMP;
  
  -- info
  PRINT ('updated orgunitid: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -- if orgunitid is defined, remove entries that are not for current orgunit
  IF (@OrgUnitID IS NOT NULL)
  BEGIN
    -- remove entries that are not within current orgunit 
    DELETE TMP
    FROM @Temp TMP
    WHERE ISNULL(TMP.OrgUnitID, -1) <> @OrgUnitID;
    
    -- info
    PRINT ('filtered orgunitid: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
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
      DELETE FROM @Temp
      WHERE ISNULL(OrgUnitID, -1) NOT IN (SELECT ORG.OrgUnitID
                                          FROM @TmpAllowedOrgUnitIDs ORG);
      
      -- info
      PRINT ('filtered depending on rights kgs: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
    END;
  END;
  
  -- info
  PRINT ('done with filtering of UserID and OrgUnitID: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  -------------------------------------------------------------------------------
  -- remove all persons who are not active client at end date
  -------------------------------------------------------------------------------
  DELETE TMP
  FROM @Temp TMP
  WHERE ISNULL(dbo.fnFaIsPersonClientByRule(TMP.BaPersonID, @DatumBis, 0, 0), -1) <> 1; -- we want to delete all non active clients for DatumBis
  
  -- info
  PRINT ('removed non active clients: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  PRINT ('done with init, do output now: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
  
  --=============================================================================
  -- OUTPUT
  --=============================================================================
  
  -------------------------------------------------------------------------------
  -- output default
  -------------------------------------------------------------------------------
  SELECT [BaPersonID$]          = PRS.BaPersonID,
         [NameVornameID$]       = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname) + 
                                  ISNULL(' - ' + @BirthdayDateML + ': ' + CONVERT(VARCHAR(50), PRS.Geburtsdatum, 104), '') + 
                                  ' (' + @IdentityML + ': ' + CONVERT(VARCHAR(50), PRS.BaPersonID) + ')',
         [Nr.]                  = PRS.BaPersonID,
         [Name]                 = PRS.Name,
         [Vorname]              = PRS.Vorname,
         --
         [Verantwortliche/r FV] = dbo.fnGetLastFirstName(TMP.UserID, NULL, NULL),
         [Kostenstelle]         = dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName),
         --
         [Geschlecht]           = dbo.fnGetGenderMLTitleMF(PRS.GeschlechtCode, @LanguageCode),
         [Geb.Dat.]             = PRS.Geburtsdatum,
         --
         [Hauptbehinderungsart] = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, @LanguageCode),
         [IV Berechtigung]      = CASE 
                                    WHEN EXISTS(SELECT TOP 1 1 
                                                FROM dbo.BaIVBerechtigung BIB WITH (READUNCOMMITTED) 
                                                WHERE BIB.BaPersonID = PRS.BaPersonID 
                                                  AND BIB.DatumVon <= @DatumBis) 
                                      THEN dbo.fnGetLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(PRS.BaPersonID, @DatumBis, 0), @LanguageCode) -- search by final date of period
                                    ELSE NULL
                                  END,
         [Vers.-Nr.]            = PRS.VersichertenNummer,
         --
         [Ort]                  = dbo.fnGetAdressText(PRS.BaPersonID, 0, 0),
         [Land]                 = dbo.fnLandMLText(TMP.BaLandID_Wohnsitz, @LanguageCode),
         [Nationalität]         = dbo.fnLandMLText(PRS.NationalitaetCode, @LanguageCode),
         --
         [Erwerbssituation]     = dbo.fnGetLOVMLText('BaErwerbssituation', PRS.ErwerbssituationCode, @LanguageCode),
         [Ausbildung]           = dbo.fnGetLOVMLText('BaAusbildungCode', PRS.AusbildungCode, @LanguageCode),
         [Rentenstufe]          = dbo.fnGetLOVMLText('BaRentenstufe', PRS.RentenstufeCode, @LanguageCode),
         [Empfohlen von]        = dbo.fnGetLOVMLText('FaIntakeEmpfohlenVon', FAI.EmpfohlenVonCode, @LanguageCode),
         --
         [Zeitraum]             = @ZeitraumString
  FROM @Temp                TMP
    INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = TMP.BaPersonID
    LEFT  JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = TMP.OrgUnitID
    LEFT  JOIN dbo.FaIntake FAI WITH (READUNCOMMITTED) ON FAI.FaLeistungID = dbo.fnFaGetFirstIntakeOfFV(TMP.BaPersonID, TMP.FaLeistungIDLastFV)
  ORDER BY [Name], [Vorname], [BaPersonID$];
  
  -- info
  PRINT ('done output: ' + CONVERT(VARCHAR(50), (GETDATE() - @StartTimeOfCode), 114));
END;
GO