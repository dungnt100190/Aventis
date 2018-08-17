/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to migrate table BaPerson.
  
  TODO: add or remove columns in INSERT and SELECT statement
=================================================================================================*/

--*****************************************************************************
-- Migrate table "BaPerson"
--*****************************************************************************
PRINT ('Info: **** BaPerson **** Start');
GO

-------------------------------------------------------------------------------
-- Pre-Steps (drop dependent functions and views, etc.)
-------------------------------------------------------------------------------
-- <none>
GO

-------------------------------------------------------------------------------
-- Cleanup invalid data in BaPerson
-------------------------------------------------------------------------------
PRINT ('Info: Cleanup invalid data in table "BaPerson"');
GO

-- remove invalid entries
-- <none>

-- PRINT ('Info: Deleted "' + CONVERT(VARCHAR(20), @@ROWCOUNT) + '" entries in table "BaPerson"');
-- GO

-------------------------------------------------------------------------------
-- Drop Triggers
-------------------------------------------------------------------------------
PRINT ('Info: Delete triggers of table "BaPerson"');
GO

-- drop Triggers
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trHist_BaPerson]'))
BEGIN
  DROP TRIGGER [dbo].[trHist_BaPerson]
END;
GO

-------------------------------------------------------------------------------
-- Drop FKs on other tables
-- 
-- WARNING: This will only work for the first time and original table.
--          Here, you have no second chance for any further executions.
-------------------------------------------------------------------------------
-- info
PRINT ('Info: Auto dropping FKs of other tables pointing to table "BaPerson"');
GO

-- create temp table to keept script for recreating
IF (OBJECT_ID('tempdb..#TmpRecreateForeignFK') IS NOT NULL)
BEGIN
  DROP TABLE #TmpRecreateForeignFK;
END;
GO

CREATE TABLE #TmpRecreateForeignFK 
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  Script NVARCHAR(MAX)
);
GO

-- temp table for FK definitions
DECLARE @TmpForeignFK TABLE
(
  PKTABLE_QUALIFIER NVARCHAR(128),
  PKTABLE_OWNER NVARCHAR(128),
  PKTABLE_NAME NVARCHAR(128),
  PKCOLUMN_NAME NVARCHAR(128),
  FKTABLE_QUALIFIER NVARCHAR(128),
  FKTABLE_OWNER NVARCHAR(128),
  FKTABLE_NAME NVARCHAR(128),
  FKCOLUMN_NAME NVARCHAR(128),
  KEY_SEQ INT,
  UPDATE_RULE INT,
  DELETE_RULE INT,
  FK_NAME NVARCHAR(128),
  PK_NAME NVARCHAR(128),
  DEFERRABILITY INT,
  NO_CHECK BIT
);

-- init vars
DECLARE @Script NVARCHAR(MAX);
DECLARE @Rules VARCHAR(255);
DECLARE @UpdateRule INT;
DECLARE @DeleteRule INT;
DECLARE @NoCheck BIT;
DECLARE @CheckMode VARCHAR(10);
--
DECLARE @PKTableName NVARCHAR(128);
DECLARE @PKColumns VARCHAR(255);
DECLARE @PKColumnName VARCHAR(128);
--
DECLARE @FKName NVARCHAR(128);
DECLARE @FKTableName NVARCHAR(128);
DECLARE @FKTableOwner NVARCHAR(128);
DECLARE @FKColumns VARCHAR(255);
DECLARE @FKColumnName VARCHAR(128);

-- set vars
SET @PKTableName = 'BaPerson';

-- get FK definitions to recreate them later
INSERT @TmpForeignFK (PKTABLE_QUALIFIER, PKTABLE_OWNER, PKTABLE_NAME, PKCOLUMN_NAME, FKTABLE_QUALIFIER, FKTABLE_OWNER, FKTABLE_NAME, FKCOLUMN_NAME,
                      KEY_SEQ, UPDATE_RULE, DELETE_RULE, FK_NAME, PK_NAME, DEFERRABILITY)
  EXEC sys.sp_fkeys @pktable_name = @PKTableName;

-- get NOCHECK flag
UPDATE TMP
SET TMP.NO_CHECK = SFK.is_not_trusted
FROM @TmpForeignFK TMP
  INNER JOIN sys.foreign_keys SFK ON SFK.name = TMP.FK_NAME

-- create cursor
DECLARE curFKs CURSOR FAST_FORWARD FOR
  SELECT FK_NAME, FKTABLE_NAME, FKTABLE_OWNER
  FROM @TmpForeignFK;

OPEN curFKs;
WHILE (1 = 1)
BEGIN
  FETCH NEXT
  FROM curFKs
  INTO @FKName, @FKTableName, @FKTableOwner;

  IF (@@FETCH_STATUS != 0)
  BEGIN
    BREAK;
  END;

  -- drop FK
  SET @Script = 'ALTER TABLE ' + @FKTableOwner + '.' + @FKTableName + ' DROP CONSTRAINT [' + @FKName + '];'
  PRINT ('EXEC: ' + ISNULL(@Script, '???'));
  EXEC sp_executesql @Script;

  -- reset vars
  SET @PKColumns = '';
  SET @FKColumns = '';
  SET @Rules = '';
  SET @FKColumnName = NULL;
  SET @PKColumnName = NULL;
  SET @UpdateRule = NULL;
  SET @DeleteRule = NULL;
  SET @NoCheck = NULL;
  
  -- create a cursor to loop over all columns included in the foreign key
  DECLARE curColumns CURSOR FAST_FORWARD FOR
    SELECT FKCOLUMN_NAME, PKCOLUMN_NAME, UPDATE_RULE, DELETE_RULE, NO_CHECK
    FROM @TmpForeignFK
    WHERE FK_NAME = @FKName
    ORDER BY KEY_SEQ;
  
  OPEN curColumns;
  WHILE (1 = 1)
  BEGIN
    FETCH NEXT
    FROM curColumns
    INTO @FKColumnName, @PKColumnName, @updateRule, @DeleteRule, @NoCheck;
    
    IF (@@FETCH_STATUS != 0)
    BEGIN
      BREAK;
    END;

    -- concatenate column names
    SELECT @PKColumns = CASE 
                          WHEN LEN(@PKColumns) < 1 THEN @PKColumnName 
                          ELSE @PKColumns + ', ' + @PKColumnName 
                        END,
           @FKColumns = CASE 
                          WHEN LEN(@FKColumns) < 1 THEN @FKColumnName 
                          ELSE @FKColumns + ', ' + @FKColumnName 
                        END;
  END;
  
  CLOSE curColumns;
  DEALLOCATE curColumns;
  
  -- only FKs of other than PK tables
  IF (@FKTableName <> @PKTableName)
  BEGIN
    -- concatenate update/delete rules
    SET @Rules = CASE
                   WHEN @UpdateRule = 0 THEN @Rules + ' ON UPDATE CASCADE' 
                   ELSE @Rules 
                 END;
    SET @Rules = CASE
                   WHEN @DeleteRule = 0 THEN @Rules + ' ON DELETE CASCADE' 
                   ELSE @Rules 
                 END;

    SET @CheckMode = CASE @NoCheck 
                       WHEN 0 THEN 'CHECK'
                       ELSE 'NOCHECK'
                     END;

    -- create script
    SET @Script = 'ALTER TABLE [' + @FKTableOwner + '].[' + @FKTableName + '] WITH ' + @CheckMode +
                  ' ADD CONSTRAINT [' + @FKName + '] FOREIGN KEY (' + @FKColumns + ')' + 
                  ' REFERENCES [' + @PKTableName + '] (' + @PKColumns + ')' + @Rules;
    
    IF (@NoCheck = 0)
    BEGIN
      SET @Script = @Script + ' ALTER TABLE [' + @FKTableOwner + '].[' + @FKTableName + '] CHECK CONSTRAINT [' + @FKName + ']';
    END;
    
    INSERT #TmpRecreateForeignFK (Script)
    VALUES (@Script);
  END;
END;

CLOSE curFKs;
DEALLOCATE curFKs;
GO

-------------------------------------------------------------------------------
-- find NOCHECK FKs
-------------------------------------------------------------------------------
-- create temp table to keept script for recreating
IF (OBJECT_ID('tempdb..#TmpNoCheckFK') IS NOT NULL)
BEGIN
  DROP TABLE #TmpNoCheckFK;
END;
GO

CREATE TABLE #TmpNoCheckFK 
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  Name NVARCHAR(128) NOT NULL
);
GO

-- Save in temp table
INSERT INTO #TmpNoCheckFK (Name)
  SELECT name
  FROM sys.foreign_keys
  WHERE OBJECT_NAME(parent_object_id) = 'BaPerson'
    AND is_not_trusted = 1;

-------------------------------------------------------------------------------
-- Drop depending objects such as keys and constraints of table BaPerson
-------------------------------------------------------------------------------
PRINT ('Info: Auto dropping PK, IXs, UKs, FKs, DFs and CKs of table "BaPerson"');
GO

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @ObjectName VARCHAR(5000);
DECLARE @PKTableName NVARCHAR(128);

DECLARE @TmpOwnObjectToDrop TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  ObjectName VARCHAR(5000)
);

-- set vars
SET @PKTableName = 'BaPerson';

-- collect PK, IXs, UKs
INSERT INTO @TmpOwnObjectToDrop (ObjectName)
  SELECT IXS.name
  FROM sys.indexes IXS
  WHERE OBJECT_NAME(IXS.object_id) = @PKTableName;

-- collect FKs
INSERT INTO @TmpOwnObjectToDrop (ObjectName)
  SELECT FKS.name
  FROM sys.foreign_keys FKS
  WHERE OBJECT_NAME(FKS.parent_object_id) = @PKTableName;

-- collect DFs
INSERT INTO @TmpOwnObjectToDrop (ObjectName)
  SELECT CNT.name
  FROM sys.default_constraints CNT
  WHERE OBJECT_NAME(CNT.parent_object_id) = @PKTableName;

-- collect CKs
INSERT INTO @TmpOwnObjectToDrop (ObjectName)
  SELECT CNT.name
  FROM sys.check_constraints CNT
  WHERE OBJECT_NAME(CNT.parent_object_id) = @PKTableName;

-- init
SELECT @EntriesCount    = COUNT(1),
       @EntriesIterator = 1
FROM @TmpOwnObjectToDrop;

-- loop all entries
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @ObjectName = TMP.ObjectName
  FROM @TmpOwnObjectToDrop TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -- drop object
  EXEC dbo.spDropObject @PKTableName, @ObjectName;
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;
GO

-------------------------------------------------------------------------------
-- rename original table "BaPerson" to "_Old_BaPerson"
-------------------------------------------------------------------------------
PRINT ('Info: Rename original table "BaPerson" to "_Old_BaPerson".');
GO

-- rename table to _old_...
EXEC dbo.spDropObject _Old_BaPerson;
EXECUTE sp_rename N'BaPerson', N'_Old_BaPerson', 'OBJECT';
GO

-------------------------------------------------------------------------------
-- recreate table "BaPerson"
-------------------------------------------------------------------------------
PRINT ('Info: Recreate new table "BaPerson".');
GO

-- create new table from definition
{Include:BaPerson}
GO

-------------------------------------------------------------------------------
-- disable history-trigger
-------------------------------------------------------------------------------
PRINT ('Info: Disable history trigger on table "BaPerson".');
GO

-- disable trigger (remember to enable trigger again!!)
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trHist_BaPerson]'))
BEGIN
  DISABLE TRIGGER trHist_BaPerson ON BaPerson;
END;
GO

-------------------------------------------------------------------------------
-- disable NOCHECK-FKs
-------------------------------------------------------------------------------
PRINT ('Info: Disable NOCHECK FKs on table "BaPerson".');
GO

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @SQL NVARCHAR(255);

SELECT @EntriesCount = COUNT(1),
       @EntriesIterator = 1
FROM #TmpNoCheckFK;

WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  SELECT @SQL = 'ALTER TABLE dbo.BaPerson NOCHECK CONSTRAINT [' + TMP.name + '];'
  FROM #TmpNoCheckFK TMP
  WHERE TMP.ID = @EntriesIterator;

  PRINT ('EXEC: ' + ISNULL(@SQL, '???'));
  EXEC sp_executesql @SQL;

  SET @EntriesIterator = @EntriesIterator + 1;
END;
GO

-------------------------------------------------------------------------------
-- perform migration of data from old to new table
-------------------------------------------------------------------------------
PRINT ('Info: Start with migration of data from old to new table "BaPerson".');
GO

-- declare and init vars
DECLARE @ErrorMessage VARCHAR(MAX);
SET @ErrorMessage = NULL;

BEGIN TRY
  -- migrate data (CUSTOM)
  SET IDENTITY_INSERT dbo.BaPerson ON;
  
  -- do reimport
  IF (NOT EXISTS (SELECT TOP 1 1 
                  FROM dbo._Old_BaPerson))
  BEGIN
    PRINT ('Info: Table does not contain any data, no migration required');
  END
  ELSE
  BEGIN
    PRINT ('Info: Table contains data, starting migration...');
    
    ---------------------------------------------------------------------------
    -- do migration
    ---------------------------------------------------------------------------
    -- TODO: add or remove columns in INSERT and SELECT statement
    EXEC('
    INSERT INTO dbo.BaPerson (BaPersonID,
                              StatusPersonCode,
                              Titel,
                              Name,
                              FruehererName,
                              Vorname,
                              Vorname2,
                              Geburtsdatum,
                              Sterbedatum,
                              AHVNummer,
                              Versichertennummer,
                              HaushaltVersicherungsNummer,
                              NNummer,
                              BFFNummer,
                              ZIPNr,
                              KantonaleReferenznummer,
                              GeschlechtCode,
                              ZivilstandCode,
                              ZivilstandDatum,
                              HeimatgemeindeCode,
                              HeimatgemeindeCodes,
                              NationalitaetCode,
                              ReligionCode,
                              AuslaenderStatusCode,
                              AuslaenderStatusGueltigBis,
                              Telefon_P,
                              Telefon_G,
                              MobilTel1,
                              MobilTel2,
                              EMail,
                              SprachCode,
                              Unterstuetzt,
                              Fiktiv,
                              Bemerkung,
                              AlphaAktiv,
                              DeutschVerstehenCode,
                              WichtigerHinweisCode,
                              ZuzugKtPLZ,
                              ZuzugKtOrtCode,
                              ZuzugKtOrt,
                              ZuzugKtKanton,
                              ZuzugKtLandCode,
                              ZuzugKtDatum,
                              ZuzugKtSeitGeburt,
                              ZuzugGdePLZ,
                              ZuzugGdeOrtCode,
                              ZuzugGdeOrt,
                              ZuzugGdeKanton,
                              ZuzugGdeLandCode,
                              ZuzugGdeDatum,
                              ZuzugGdeSeitGeburt,
                              UntWohnsitzPLZ,
                              UntWohnsitzOrt,
                              UntWohnsitzKanton,
                              UntWohnsitzLandCode,
                              WegzugPLZ,
                              WegzugOrtCode,
                              WegzugOrt,
                              WegzugKanton,
                              WegzugLandCode,
                              WegzugDatum,
                              WohnsitzWieBaPersonID,
                              AufenthaltWieBaInstitutionID,
                              ErwerbssituationCode,
                              GrundTeilzeitarbeit1Code,
                              GrundTeilzeitarbeit2Code,
                              ErwerbsBrancheCode,
                              ErlernterBerufCode,
                              BerufCode,
                              HoechsteAusbildungCode,
                              AbgebrocheneAusbildungCode,
                              ArbeitSpezFaehigkeiten,
                              KbKostenstelleID,
                              InCHSeit,
                              InCHSeitGeburt,
                              PUAnzahlVerlustscheine,
                              PUKrankenkasse,
                              PraemienuebernahmeVon,
                              PraemienuebernahmeBis,
                              PersonOhneLeistung,
                              HCMCFluechtling,
                              StellensuchendCode,
                              ResoNr,
                              NEAnmeldung,
                              HeimatgemeindeBaGemeindeID,
                              AktiveKopfQuote,
                              ALK,
                              AndereSVLeistungen,
                              Anrede,
                              AusbildungCode,
                              Behinderungsart2Code,
                              BemerkungenAdresse,
                              BemerkungenSV,
                              BeruflicheMassnahmeIV,
                              Briefanrede,
                              BSVBehinderungsartCode,
                              BVGRente,
                              CAusweisDatum,
                              DebitorNr,
                              DebitorUpdate,
                              EigenerMietvertrag,
                              Einrichtpauschale,
                              EinrichtungspauschaleCode,
                              ErgaenzungsLeistungen,
                              Assistenzbeitrag,
                              DatumAssistenzbeitrag,
                              IvVerfuegteAssistenzberatung,
                              DatumIvVerfuegung,
                              ErteilungVA,
                              IstFamiliennachzug,
                              Fax,
                              HauptBehinderungsartCode,
                              HELBKeinAntrag,
                              HELBAb,
                              HELBAnmeldung,
                              HELBEntscheid,
                              HELBEntscheidCode,
                              HilfslosenEntschaedigungCode,
                              ImKantonSeit,
                              ImKantonSeitGeburt,
                              InGemeindeSeit,
                              IntensivPflegeZuschlagCode,
                              IVBerechtigungAnfangsStatusCode,
                              IVBerechtigungErsterEntscheidAb,
                              IVBerechtigungErsterEntscheidCode,
                              IVBerechtigungZweiterEntscheidAb,
                              IVBerechtigungZweiterEntscheidCode,
                              IVGrad,
                              IVHilfsmittel,
                              IVTaggeld,
                              KeinSerienbrief,
                              KonfessionCode,
                              KontoFuehrung,
                              BaPersonID_Dossiertraeger,
                              Kopfquote_BaInstitutionID,
                              KopfquoteAbDatum,
                              KopfquoteBisDatum,
                              KorrespondenzSpracheCode,
                              KTG,
                              LaufendeVollmachtErlaubnis,
                              ManuelleAnrede,
                              MedizinischeMassnahmeIV,
                              Mehrfachbehinderung,
                              MietdepotPI,
                              MigrationKA,
                              MobilTel,
                              NavigatorZusatz,
                              PassiveKopfQuote,
                              PauschaleAktualDatum,
                              PersonSichtbarSDFlag,
                              ProjNr,
                              RentenstufeCode,
                              SichtbarSDFlag,
                              Sozialhilfe,
                              Sprachpauschale,
                              Testperson,
                              UntWohnsitzOrtCode,
                              UVGRente,
                              UVGTaggeld,
                              VerstaendigungSprachCode,
                              visdat36Area,
                              visdat36ID,
                              VormundMassnahmenCode,
                              VormundPI,
                              WichtigerHinweis,
                              WittwenWittwerWaisenrente,
                              WohnstatusCode,
                              ZeigeDetails,
                              ZeigeTelGeschaeft,
                              ZeigeTelMobil,
                              ZeigeTelPrivat,
                              ZEMISNummer,
                              IstBerechnungsperson,
                              DatumAsylgesuch,
                              DatumEinbezugFaz,
                              VerID,
                              Creator,
                              Created,
                              Modifier,
                              Modified )
      SELECT BaPersonID                         = OLD.BaPersonID,
             StatusPersonCode                   = OLD.StatusPersonCode,
             Titel                              = OLD.Titel,
             Name                               = OLD.Name,
             FruehererName                      = OLD.FruehererName,
             Vorname                            = OLD.Vorname,
             Vorname2                           = OLD.Vorname2,
             Geburtsdatum                       = OLD.Geburtsdatum,
             Sterbedatum                        = OLD.Sterbedatum,
             AHVNummer                          = OLD.AHVNummer,
             Versichertennummer                 = OLD.Versichertennummer,
             HaushaltVersicherungsNummer        = OLD.HaushaltVersicherungsNummer,
             NNummer                            = OLD.NNummer,
             BFFNummer                          = OLD.BFFNummer,
             ZIPNr                              = OLD.ZIPNr,
             KantonaleReferenznummer            = OLD.KantonaleReferenznummer,
             GeschlechtCode                     = OLD.GeschlechtCode,
             ZivilstandCode                     = OLD.ZivilstandCode,
             ZivilstandDatum                    = OLD.ZivilstandDatum,
             HeimatgemeindeCode                 = OLD.HeimatgemeindeCode,
             HeimatgemeindeCodes                = OLD.HeimatgemeindeCodes,
             NationalitaetCode                  = OLD.NationalitaetCode,
             ReligionCode                       = OLD.ReligionCode,
             AuslaenderStatusCode               = OLD.AuslaenderStatusCode,
             AuslaenderStatusGueltigBis         = OLD.AuslaenderStatusGueltigBis,
             Telefon_P                          = OLD.Telefon_P,
             Telefon_G                          = OLD.Telefon_G,
             MobilTel1                          = OLD.MobilTel1,
             MobilTel2                          = OLD.MobilTel2,
             EMail                              = OLD.EMail,
             SprachCode                         = OLD.SprachCode,
             Unterstuetzt                       = OLD.Unterstuetzt,
             Fiktiv                             = OLD.Fiktiv,
             Bemerkung                          = OLD.Bemerkung,
             AlphaAktiv                         = OLD.AlphaAktiv,
             DeutschVerstehenCode               = OLD.DeutschVerstehenCode,
             WichtigerHinweisCode               = OLD.WichtigerHinweisCode,
             ZuzugKtPLZ                         = OLD.ZuzugKtPLZ,
             ZuzugKtOrtCode                     = OLD.ZuzugKtOrtCode,
             ZuzugKtOrt                         = OLD.ZuzugKtOrt,
             ZuzugKtKanton                      = OLD.ZuzugKtKanton,
             ZuzugKtLandCode                    = OLD.ZuzugKtLandCode,
             ZuzugKtDatum                       = OLD.ZuzugKtDatum,
             ZuzugKtSeitGeburt                  = OLD.ZuzugKtSeitGeburt,
             ZuzugGdePLZ                        = OLD.ZuzugGdePLZ,
             ZuzugGdeOrtCode                    = OLD.ZuzugGdeOrtCode,
             ZuzugGdeOrt                        = OLD.ZuzugGdeOrt,
             ZuzugGdeKanton                     = OLD.ZuzugGdeKanton,
             ZuzugGdeLandCode                   = OLD.ZuzugGdeLandCode,
             ZuzugGdeDatum                      = OLD.ZuzugGdeDatum,
             ZuzugGdeSeitGeburt                 = OLD.ZuzugGdeSeitGeburt,
             UntWohnsitzPLZ                     = OLD.UntWohnsitzPLZ,
             UntWohnsitzOrt                     = OLD.UntWohnsitzOrt,
             UntWohnsitzKanton                  = OLD.UntWohnsitzKanton,
             UntWohnsitzLandCode                = OLD.UntWohnsitzLandCode,
             WegzugPLZ                          = OLD.WegzugPLZ,
             WegzugOrtCode                      = OLD.WegzugOrtCode,
             WegzugOrt                          = OLD.WegzugOrt,
             WegzugKanton                       = OLD.WegzugKanton,
             WegzugLandCode                     = OLD.WegzugLandCode,
             WegzugDatum                        = OLD.WegzugDatum,
             WohnsitzWieBaPersonID              = OLD.WohnsitzWieBaPersonID,
             AufenthaltWieBaInstitutionID       = OLD.AufenthaltWieBaInstitutionID,
             ErwerbssituationCode               = OLD.ErwerbssituationCode,
             GrundTeilzeitarbeit1Code           = OLD.GrundTeilzeitarbeit1Code,
             GrundTeilzeitarbeit2Code           = OLD.GrundTeilzeitarbeit2Code,
             ErwerbsBrancheCode                 = OLD.ErwerbsBrancheCode,
             ErlernterBerufCode                 = OLD.ErlernterBerufCode,
             BerufCode                          = OLD.BerufCode,
             HoechsteAusbildungCode             = OLD.HoechsteAusbildungCode,
             AbgebrocheneAusbildungCode         = OLD.AbgebrocheneAusbildungCode,
             ArbeitSpezFaehigkeiten             = OLD.ArbeitSpezFaehigkeiten,
             KbKostenstelleID                   = OLD.KbKostenstelleID,
             InCHSeit                           = OLD.InCHSeit,
             InCHSeitGeburt                     = OLD.InCHSeitGeburt,
             PUAnzahlVerlustscheine             = OLD.PUAnzahlVerlustscheine,
             PUKrankenkasse                     = OLD.PUKrankenkasse,
             PraemienuebernahmeVon              = OLD.PraemienuebernahmeVon,
             PraemienuebernahmeBis              = OLD.PraemienuebernahmeBis,
             PersonOhneLeistung                 = OLD.PersonOhneLeistung,
             HCMCFluechtling                    = OLD.HCMCFluechtling,
             StellensuchendCode                 = OLD.StellensuchendCode,
             ResoNr                             = OLD.ResoNr,
             NEAnmeldung                        = OLD.NEAnmeldung,
             HeimatgemeindeBaGemeindeID         = OLD.HeimatgemeindeBaGemeindeID,
             AktiveKopfQuote                    = OLD.AktiveKopfQuote,
             ALK                                = OLD.ALK,
             AndereSVLeistungen                 = OLD.AndereSVLeistungen,
             Anrede                             = OLD.Anrede,
             AusbildungCode                     = OLD.AusbildungCode,
             Behinderungsart2Code               = OLD.Behinderungsart2Code,
             BemerkungenAdresse                 = OLD.BemerkungenAdresse,
             BemerkungenSV                      = OLD.BemerkungenSV,
             BeruflicheMassnahmeIV              = OLD.BeruflicheMassnahmeIV,
             Briefanrede                        = OLD.Briefanrede,
             BSVBehinderungsartCode             = OLD.BSVBehinderungsartCode,
             BVGRente                           = OLD.BVGRente,
             CAusweisDatum                      = OLD.CAusweisDatum,
             DebitorNr                          = OLD.DebitorNr,
             DebitorUpdate                      = OLD.DebitorUpdate,
             EigenerMietvertrag                 = OLD.EigenerMietvertrag,
             Einrichtpauschale                  = OLD.Einrichtpauschale,
             EinrichtungspauschaleCode          = OLD.EinrichtungspauschaleCode,
             ErgaenzungsLeistungen              = OLD.ErgaenzungsLeistungen,
             Assistenzbeitrag                   = OLD.Assistenzbeitrag,
             DatumAssistenzbeitrag              = OLD.DatumAssistenzbeitrag,
             IvVerfuegteAssistenzberatung       = OLD.IvVerfuegteAssistenzberatung,
             DatumIvVerfuegung                  = OLD.DatumIvVerfuegung,
             ErteilungVA                        = OLD.ErteilungVA,
             IstFamiliennachzug                 = OLD.IstFamiliennachzug,
             Fax                                = OLD.Fax,
             HauptBehinderungsartCode           = OLD.HauptBehinderungsartCode,
             HELBKeinAntrag                     = OLD.HELBKeinAntrag,
             HELBAb                             = OLD.HELBAb,
             HELBAnmeldung                      = OLD.HELBAnmeldung,
             HELBEntscheid                      = OLD.HELBEntscheid,
             HELBEntscheidCode                  = OLD.HELBEntscheidCode,
             HilfslosenEntschaedigungCode       = OLD.HilfslosenEntschaedigungCode,
             ImKantonSeit                       = OLD.ImKantonSeit,
             ImKantonSeitGeburt                 = OLD.ImKantonSeitGeburt,
             InGemeindeSeit                     = OLD.InGemeindeSeit,
             IntensivPflegeZuschlagCode         = OLD.IntensivPflegeZuschlagCode,
             IVBerechtigungAnfangsStatusCode    = OLD.IVBerechtigungAnfangsStatusCode,
             IVBerechtigungErsterEntscheidAb    = OLD.IVBerechtigungErsterEntscheidAb,
             IVBerechtigungErsterEntscheidCode  = OLD.IVBerechtigungErsterEntscheidCode,
             IVBerechtigungZweiterEntscheidAb   = OLD.IVBerechtigungZweiterEntscheidAb,
             IVBerechtigungZweiterEntscheidCode = OLD.IVBerechtigungZweiterEntscheidCode,
             IVGrad                             = OLD.IVGrad,
             IVHilfsmittel                      = OLD.IVHilfsmittel,
             IVTaggeld                          = OLD.IVTaggeld,
             KeinSerienbrief                    = OLD.KeinSerienbrief,
             KonfessionCode                     = OLD.KonfessionCode,
             KontoFuehrung                      = OLD.KontoFuehrung,
             BaPersonID_Dossiertraeger          = OLD.BaPersonID_Dossiertraeger,
             Kopfquote_BaInstitutionID          = OLD.Kopfquote_BaInstitutionID,
             KopfquoteAbDatum                   = OLD.KopfquoteAbDatum,
             KopfquoteBisDatum                  = OLD.KopfquoteBisDatum,
             KorrespondenzSpracheCode           = OLD.KorrespondenzSpracheCode,
             KTG                                = OLD.KTG,
             LaufendeVollmachtErlaubnis         = OLD.LaufendeVollmachtErlaubnis,
             ManuelleAnrede                     = OLD.ManuelleAnrede,
             MedizinischeMassnahmeIV            = OLD.MedizinischeMassnahmeIV,
             Mehrfachbehinderung                = OLD.Mehrfachbehinderung,
             MietdepotPI                        = OLD.MietdepotPI,
             MigrationKA                        = OLD.MigrationKA,
             MobilTel                           = OLD.MobilTel,
             NavigatorZusatz                    = OLD.NavigatorZusatz,
             PassiveKopfQuote                   = OLD.PassiveKopfQuote,
             PauschaleAktualDatum               = OLD.PauschaleAktualDatum,
             PersonSichtbarSDFlag               = OLD.PersonSichtbarSDFlag,
             ProjNr                             = OLD.ProjNr,
             RentenstufeCode                    = OLD.RentenstufeCode,
             SichtbarSDFlag                     = OLD.SichtbarSDFlag,
             Sozialhilfe                        = OLD.Sozialhilfe,
             Sprachpauschale                    = OLD.Sprachpauschale,
             Testperson                         = OLD.Testperson,
             UntWohnsitzOrtCode                 = OLD.UntWohnsitzOrtCode,
             UVGRente                           = OLD.UVGRente,
             UVGTaggeld                         = OLD.UVGTaggeld,
             VerstaendigungSprachCode           = OLD.VerstaendigungSprachCode,
             visdat36Area                       = OLD.visdat36Area,
             visdat36ID                         = OLD.visdat36ID,
             VormundMassnahmenCode              = OLD.VormundMassnahmenCode,
             VormundPI                          = OLD.VormundPI,
             WichtigerHinweis                   = OLD.WichtigerHinweis,
             WittwenWittwerWaisenrente          = OLD.WittwenWittwerWaisenrente,
             WohnstatusCode                     = OLD.WohnstatusCode,
             ZeigeDetails                       = OLD.ZeigeDetails,
             ZeigeTelGeschaeft                  = OLD.ZeigeTelGeschaeft,
             ZeigeTelMobil                      = OLD.ZeigeTelMobil,
             ZeigeTelPrivat                     = OLD.ZeigeTelPrivat,
             ZEMISNummer                        = OLD.ZEMISNummer,
             IstBerechnungsperson               = OLD.IstBerechnungsperson,
             DatumAsylgesuch                    = OLD.DatumAsylgesuch,
             DatumEinbezugFaz                   = OLD.DatumEinbezugFaz,
             VerID                              = OLD.VerID,
             Creator                            = OLD.Creator,
             Created                            = OLD.Created,
             Modifier                           = OLD.Modifier,
             Modified                           = OLD.Modified
      FROM dbo._Old_BaPerson OLD WITH (HOLDLOCK TABLOCKX);

    -- info
    PRINT (''Info: Migrated "'' + CONVERT(VARCHAR(20), @@ROWCOUNT) + ''" entries in table "BaPerson"'');
    ');
    
  END;
  
  SET IDENTITY_INSERT dbo.BaPerson OFF;
  
  -- remember to remove old table in next release!
  -- >: EXEC dbo.spDropObject _Old_BaPerson;
  
  PRINT ('Info: Done migrating data to new table "BaPerson".');
END TRY
BEGIN CATCH
  SET @ErrorMessage = ERROR_MESSAGE();
  
  -- reset identity to ensure other script will not fail
  SET IDENTITY_INSERT dbo.BaPerson OFF;
  
  RAISERROR ('Critical Error: Could not migrate data into new table "BaPerson". Database error was: %s', 18, 1, @ErrorMessage);
END CATCH;
GO

-------------------------------------------------------------------------------
-- enable history-trigger
-------------------------------------------------------------------------------
PRINT ('Info: Enable history trigger on table "BaPerson".');
GO

-- enable trigger
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trHist_BaPerson]'))
BEGIN
  ENABLE TRIGGER trHist_BaPerson ON BaPerson;
END;
GO

-------------------------------------------------------------------------------
-- Recreate FKs on other tables
-------------------------------------------------------------------------------
PRINT ('Info: Auto recreating FKs of other tables pointing to table "BaPerson"');
GO

-- init vars
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @Script NVARCHAR(MAX);

-- prepare vars for loop
SELECT @EntriesCount    = COUNT(1),
       @EntriesIterator = 1
FROM #TmpRecreateForeignFK;

-- loop all entries
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @Script = TMP.Script
  FROM #TmpRecreateForeignFK TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -- recreate FK
  PRINT ('EXEC: ' + ISNULL(@Script, '???'));
  EXEC sp_executesql @Script;
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;
GO

-------------------------------------------------------------------------------
-- Reenable NOCHECK-FKs
-------------------------------------------------------------------------------
PRINT ('Info: Reenable NOCHECK FKs on table "BaPerson".');
GO

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @SQL NVARCHAR(255);

SELECT @EntriesCount = COUNT(1),
       @EntriesIterator = 1
FROM #TmpNoCheckFK;

WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  SELECT @SQL = 'ALTER TABLE dbo.BaPerson CHECK CONSTRAINT [' + TMP.name + '];'
  FROM #TmpNoCheckFK TMP
  WHERE TMP.ID = @EntriesIterator;

  PRINT ('EXEC: ' + ISNULL(@SQL, '???'));
  EXEC sp_executesql @SQL;

  SET @EntriesIterator = @EntriesIterator + 1;
END;
GO

-- drop temp tables
DROP TABLE #TmpRecreateForeignFK;
DROP TABLE #TmpNoCheckFK;
GO

-------------------------------------------------------------------------------
-- Done
-------------------------------------------------------------------------------
PRINT ('Info: **** BaPerson **** End');
GO


--*****************************************************************************
-- Post-Steps
--*****************************************************************************
GO
