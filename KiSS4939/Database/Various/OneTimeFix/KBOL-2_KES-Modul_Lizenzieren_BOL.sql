/*===============================================================================================
  SUMMARY: Use this script to install the KES-module for BOL.
=================================================================================================*/

SET NOCOUNT ON;
GO

BEGIN TRAN

-- =============================================
-- KES Modul in Integrationsumgebung aktivieren
-- =============================================

-------------------------------------------------------------------------------
--Schritt 1: Kes-Modul lizenzieren
-------------------------------------------------------------------------------
UPDATE dbo.XModul
  SET ModulTree = 1, Licensed = 1
WHERE ModulID = 29
  AND Name = 'KES'; 

-------------------------------------------------------------------------------
--Schritt 2: VM PriMa löschen
-------------------------------------------------------------------------------
/*===============================================================================================
 VM PriMa löschen
=================================================================================================*/

SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- XMenuItem löschen
-------------------------------------------------------------------------------
IF (SELECT Licensed FROM XModul WHERE Name = 'KES') = 1
BEGIN

  DELETE
  FROM dbo.XMenuItem
  WHERE ClassName = 'FrmPriMa';

  DELETE
  FROM dbo.XClass
  WHERE ClassName = 'FrmPriMa';

END

SET NOCOUNT OFF;
GO

-------------------------------------------------------------------------------
-- Schritt 3: Use this script to migrate the values of VmPriMa into BaInstitution if KES is licensed.
-------------------------------------------------------------------------------
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to migrate the values of VmPriMa into BaInstitution if KES is licensed.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-- Funktion für die Anrede einfügen dass sie sicher vorhanden ist.
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetAnredeAnschriftBaPerson;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get 'Anrede' and 'Anschrift' for persons with age (depending on mode):
           - < 16: "Sehr geehrte Familie" instead of "Sehr geehrter Herr" or "Sehr geehrte Frau";
                    "Familie" instead of "Herr" or "Frau"
           - >= 16: "Sehr geehrter Herr" or "Sehr geehrte Frau" instead of "Sehr geehrte Familie";
                    "Herr" or "Frau" instead of "Familie"
   @BaPersonID: The id of the person to get data title from (can be NULL if @Age and @GenderCode is given)
   @Age: The age of the person (if NULL, either @BaPersonID or @DateOfBirth is required)
   @DateOfBirth: The date of birth (if NULL, either @BaPersonID or @Age is required)
   @DateOfDeath: The date of death used to calculate age with @DateOfBirth
   @GenderCode: The gender code of the person (if NULL, @BaPersonID is required) where 1=m, 2=f
   @LanguageCode: The language code to use for multilanguage texts
   @ReturnMode: - 'famherrfrau': return "Familie" or "Herr" or "Frau"
                  - 'geehrte': return "Sehr geehrte Familie" or "Sehr geehrter Herr" or "Sehr geehrte Frau"
   @AppendString: The string value to append if value found
  -
  RETURNS: The desired value or '' if invalid or empty value found
=================================================================================================
  TEST: SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 1, NULL, NULL, 1, 1, 'famherrfrau', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 1, 1, 'famherrfrau', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 2, 1, 'famherrfrau', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 1, NULL, NULL, 1, 1, 'geehrte', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 1, 1, 'geehrte', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 2, 1, 'geehrte', '', NULL, NULL, NULL)
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 12, NULL, NULL, 1, 2, 'famherrfrau', '', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 2, 3, 'geehrte', ', NULL, NULL, NULL')
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 16, NULL, NULL, 2, 3, 'geehrte', '__', NULL, NULL, NULL)
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(9, NULL, NULL, NULL, NULL, 1, 'geehrte', '__', NULL, NULL, NULL)
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(-1, NULL, NULL, GETDATE(), NULL, 1, 'geehrte', '__', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, GETDATE(), NULL, NULL, 1, 'geehrte', '__', NULL, NULL, NULL)
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, GETDATE(), NULL, NULL, 1, 'famherrfrau', '__', 1, 'anrede', 'briefanrede')
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, GETDATE(), NULL, NULL, 1, 'geehrte', '__', 1, 'anrede', 'briefanrede')
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(87182, NULL, NULL, NULL, NULL, 1, 'famherrfrau', '__', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(87182, NULL, NULL, NULL, NULL, 1, 'geehrte', '__', NULL, NULL, NULL)
           --
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(87182, NULL, NULL, NULL, NULL, 1, 'famherrfrau', '__', NULL, NULL, NULL)
           SELECT dbo.fnBaGetAnredeAnschriftBaPerson(87182, NULL, NULL, NULL, NULL, 1, 'geehrte', '__', 1, 'anrede', 'briefanrede')
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetAnredeAnschriftBaPerson
(
  @BaPersonID INT,
  @Age INT,
  @DateOfBirth DATETIME,
  @DateOfDeath DATETIME,
  @GenderCode INT,
  @LanguageCode INT,
  @ReturnMode VARCHAR(20),
  @AppendString VARCHAR(255),
  @ManuelleAnrede BIT,
  @Anrede VARCHAR(100),
  @Briefanrede VARCHAR(100)
)
RETURNS VARCHAR(255)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @ReturnValue VARCHAR(255);
  DECLARE @IsUnderAge BIT;
  DECLARE @ReadDataFromBaPerson BIT;
  
  -- default values
  SET @LanguageCode = ISNULL(@LanguageCode, 1); -- default is german
  SET @AppendString = ISNULL(@AppendString, ''); -- no append string if NULL given
  SET @ReadDataFromBaPerson = 0;
  
  -----------------------------------------------------------------------------
  -- if manual, we do not need any further calculations
  -----------------------------------------------------------------------------
  IF (ISNULL(@ManuelleAnrede, 0) = 0)
  BEGIN
    ---------------------------------------------------------------------------
    -- get values if only BaPersonID is given
    ---------------------------------------------------------------------------
    IF (@Age IS NULL)
    BEGIN
      IF (@DateOfBirth IS NULL)
      BEGIN
        -- get values from BaPerson
        SELECT @Age = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
               @GenderCode = PRS.GeschlechtCode,
               @ManuelleAnrede = PRS.ManuelleAnrede,
               @Anrede = PRS.Anrede,
               @Briefanrede = PRS.Briefanrede,
               @ReadDataFromBaPerson = 1
        FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
        WHERE PRS.BaPersonID = ISNULL(@BaPersonID, -1); -- no BaPersonID given, set -1 for no data
      END
      ELSE
      BEGIN
        -- calculate @Age from @DateOfBirth and @DateOfDeath
        SET @Age = dbo.fnGetAge(@DateOfBirth, ISNULL(@DateOfDeath, GETDATE()));
      END;
    END;
    
    ---------------------------------------------------------------------------
    -- get values if only BaPersonID is given and we did not read the Anrede above
    ---------------------------------------------------------------------------
    IF (@BaPersonID IS NOT NULL AND @ReadDataFromBaPerson = 0)
    BEGIN
      SELECT @ManuelleAnrede = PRS.ManuelleAnrede,
             @Anrede = PRS.Anrede,
             @Briefanrede = PRS.Briefanrede
      FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
      WHERE PRS.BaPersonID = @BaPersonID; 
    END;
    
    ---------------------------------------------------------------------------
    -- mode and age depending result
    ---------------------------------------------------------------------------
    -- set underage flag
    SET @IsUnderAge = CASE 
                        WHEN ISNULL(@Age, 99) < 16 THEN 1 -- if no age is defined, use non-underage, limit is 16 years old
                        ELSE 0
                      END;
  END;
  
  -- return value depending on mode
  IF (@ReturnMode = 'famherrfrau')
  BEGIN
    -- Anrede: "Familie/Herr/Frau" OR manual
    SET @ReturnValue = CASE 
                         WHEN @ManuelleAnrede = 1 THEN @Anrede
                         WHEN @IsUnderAge = 1 THEN dbo.fnXDbObjectMLMsg('dbGeneral', 'Familie', @LanguageCode) -- familie
                         ELSE dbo.fnGetGenderMLTitle(@GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, @LanguageCode, NULL) -- herr/frau
                       END;
  END
  ELSE IF (@ReturnMode = 'geehrte')
  BEGIN
    -- Briefanrede: "Sehr geehrte(r) Familie/Herr/Frau" OR manual
    SET @ReturnValue = CASE 
                         WHEN @ManuelleAnrede = 1 THEN @Briefanrede
                         WHEN @IsUnderAge = 1 THEN dbo.fnXDbObjectMLMsg('dbGeneral', 'SehrGeehrteFamilie', @LanguageCode) -- sehr geehrte familie
                         ELSE dbo.fnGetGenderMLTitle(@GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, @LanguageCode, NULL) -- sehr geehrte(r) herr/frau
                       END;
  END;
  
  -----------------------------------------------------------------------------
  -- done, prepare and return value
  -----------------------------------------------------------------------------
  RETURN CASE 
           WHEN ISNULL(@ReturnValue, '') = '' THEN ''
           ELSE @ReturnValue + @AppendString
         END;
END;
GO

-- Migration der Daten aus VmPrima in BaInstitution.
-- Folgende Daten gehen bei der Migration verloren:
-- + Beruf
-- + AHVNummer
-- + VerID
--
-- Wer einen passenden Behälter dafür findet kann es gerne auch umschreiben.

IF (SELECT Licensed FROM XModul WHERE Name = 'KES') = 1
BEGIN
  IF OBJECT_ID('tempdb..#VmPriMaDaten') IS NOT NULL
  BEGIN 
    DROP TABLE #VmPriMaDaten
  END

  CREATE TABLE #VmPriMaDaten(
    BaInstitutionID INT,
    VmPriMaID INT
  )

  DECLARE @VmPriMaID INT;
  DECLARE @BaInstitutionTypID INT;

  INSERT INTO #VmPriMaDaten (VmPriMaID)
  SELECT PRM.VmPriMaID 
  FROM dbo.VmPriMa PRM;

  -------------------------------------------------------------------------------
  -- Typ 'Privatperson' in 'Privatperson (PriMa)' umbennen
  -------------------------------------------------------------------------------
  DECLARE @NameNeu VARCHAR(50);
  SET @NameNeu = 'Privatperson (PriMa)';

  UPDATE BaInstitutionTyp 
  SET Name = @NameNeu
  WHERE Name LIKE '%Privatperson%';

  SET @BaInstitutionTypID = (SELECT BaInstitutionTypID 
                             FROM BaInstitutionTyp
                             WHERE Name = @NameNeu);

  -------------------------------------------------------------------------------
  -- Datensätze von VmPriMa in BaInstitution schreiben 
  -------------------------------------------------------------------------------
  DECLARE CursorPriMa CURSOR FOR
    SELECT VmPriMaID FROM #VmPriMaDaten;

  OPEN CursorPriMa;

  WHILE 1 = 1 BEGIN
  FETCH NEXT FROM CursorPriMa INTO @VmPriMaID
  IF NOT @@FETCH_STATUS = 0 BREAK

    INSERT INTO dbo.BaInstitution (OrgUnitID, InstitutionNr, BaInstitutionArtCode, Aktiv, Debitor, Kreditor, KeinSerienbrief, ManuelleAnrede, Anrede, Briefanrede, Titel, Name, Vorname, GeschlechtCode, Geburtsdatum, Versichertennummer, Telefon, Telefon2, Telefon3, Fax, EMail, Homepage, SprachCode, Bemerkung, InstitutionName, InstitutionTypCode, BaFreigabeStatusCode, DefinitivUserID, DefinitivDatum, ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum, Creator, Created, Modifier, Modified)
      SELECT 
        NULL, -- OrgUnitID - int
        NULL, -- InstitutionNr - varchar(20)
        2, -- BaInstitutionArtCode - int
        PRM.IsActive, -- Aktiv - bit
        0, -- Debitor - bit
        0, -- Kreditor - bit
        0, -- KeinSerienbrief - bit
        1, -- ManuelleAnrede - bit
        dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 50, NULL, NULL, 1, PRM.SprachCode, 'famherrfrau', '', NULL, NULL, NULL) + ', ' + 
        dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 50, NULL, NULL, 2, PRM.SprachCode, 'famherrfrau', '', NULL, NULL, NULL), -- Anrede - varchar(100)
        dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 50, NULL, NULL, 1, PRM.SprachCode, 'geehrte', '', NULL, NULL, NULL) + ', ' + 
        dbo.fnBaGetAnredeAnschriftBaPerson(NULL, 50, NULL, NULL, 2, PRM.SprachCode, 'geehrte', '', NULL, NULL, NULL), -- Briefanrede - varchar(100)
        PRM.Titel, -- Titel - varchar(100)
        PRM.Name, -- Name - varchar(500)
        PRM.Vorname, -- Vorname - varchar(100)
        NULL, -- GeschlechtCode - int
        PRM.Geburtsdatum, -- Geburtsdatum - datetime
        PRM.Versichertennummer, -- Versichertennummer - varchar(18)
        PRM.Telefon_P, -- Telefon - varchar(100)
        PRM.Telefon_G, -- Telefon2 - varchar(100)
        PRM.MobilTel, -- Telefon3 - varchar(100)
        PRM.Fax, -- Fax - varchar(100)
        PRM.EMail, -- EMail - varchar(100)
        NULL, -- Homepage - varchar(100)
        PRM.SprachCode, -- SprachCode - int
        ISNULL('Bank/PC: ' + PRM.BankName + CHAR(13) + CHAR(10), '') + ISNULL('Konto-Nr: ' + PRM.BankKontoNr + CHAR(13) + CHAR(10), '') + ISNULL(PRM.Bemerkung, ''), -- Bemerkung - varchar(max)
        NULL, -- InstitutionName - varchar(100)
        NULL, -- InstitutionTypCode - int
        NULL, -- BaFreigabeStatusCode - int
        NULL, -- DefinitivUserID - int
        GETDATE(), -- DefinitivDatum - datetime
        dbo.fnXGetSystemUserID(), -- ErstelltUserID - int
        GETDATE(), -- ErstelltDatum - datetime
        dbo.fnXGetSystemUserID(), -- MutiertUserID - int
        GETDATE(), -- MutiertDatum - datetime
        dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), -- Creator - varchar(50)
        GETDATE(), -- Created - datetime
        dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), -- Modifier - varchar(50)
        GETDATE() -- Modified - datetime
      FROM dbo.VmPriMa PRM
        LEFT JOIN #VmPriMaDaten VPR ON VPR.VmPriMaID = PRM.VmPriMaID
        LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.VmPriMaID = PRM.VmPriMaID
      WHERE PRM.VmPriMaID = @VmPriMaID;
   
      UPDATE #VmPriMaDaten
      SET BaInstitutionID = SCOPE_IDENTITY()
      WHERE VmPriMaID = @VmPriMaID;
    
  END;

  CLOSE CursorPriMa;
  DEALLOCATE CursorPriMa;

  -------------------------------------------------------------------------------
  -- Datensätze von BaAdresse von VmPriMaID nach BaInstitutionID umschreiben
  -- und einen Historyeintrag machen
  -------------------------------------------------------------------------------
  INSERT INTO dbo.HistoryVersion (AppUser) VALUES ('kiss_sys');
         
  UPDATE ADR
  SET ADR.BaInstitutionID = VPR.BaInstitutionID,
      ADR.VmPriMaID = NULL
  FROM dbo.BaAdresse ADR
    INNER JOIN #VmPriMaDaten VPR ON VPR.VmPriMaID = ADR.VmPriMaID;

  -------------------------------------------------------------------------------
  -- Erstellte BaInstitutionen typisieren
  -------------------------------------------------------------------------------
  INSERT INTO BaInstitution_BaInstitutionTyp (BaInstitutionID, BaInstitutionTypID, Creator, Created, Modifier, Modified)
    SELECT 
        VPR.BaInstitutionID,
        @BaInstitutionTypID,
        dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), -- Creator - varchar(50)
        GETDATE(), -- Created - datetime
        dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), -- Modifier - varchar(50)
        GETDATE() -- Modified - datetime
    FROM #VmPriMaDaten VPR

  -- mapping zwischen VmPrimaID und BaInstitutionID wird bei der Migration von KesMassnahmeBSS zu KesMassnahme noch verwendet 
  --IF OBJECT_ID('tempdb..#VmPriMaDaten') IS NOT NULL
  --BEGIN 
  -- DROP TABLE #VmPriMaDaten
  --END
END

-------------------------------------------------------------------------------
-- Schritt 4: V-Modul deaktivieren falls das KES-Modul lizenziert ist.
-------------------------------------------------------------------------------
/*===============================================================================================
  V-Modul deaktivieren falls das KES-Modul lizenziert ist
=================================================================================================*/

SET NOCOUNT ON;
GO

IF (SELECT Licensed FROM XModul WHERE DB_Prefix = 'Kes') = 1
BEGIN
  -- Licensed muss nicht auf 0 gesetzt werden, sonst sind die Maskenrechte den V-Masken in der Benutzerverwaltung nicht mehr sichtbar
  UPDATE dbo.XModul
  SET ModulTree = 0
  WHERE ModulID = 5;

  IF (SELECT Licensed FROM XModul WHERE ModulID = 5) = 0
  BEGIN
    -- V-Masken die im KES verwendet werden aufs KES-Modul umhängen falls das V-Modul nicht lizenziert ist
    UPDATE CLS
      SET ModulID = 29
    FROM dbo.XClass CLS 
    WHERE ClassName IN ('CtlVmBudget','CtlVmSchulden')

  END;

END;

GO

SET NOCOUNT OFF;
GO


-------------------------------------------------------------------------------
-- Schritt 5: CtlQueryVmKesKennzahlen deaktivieren.
-------------------------------------------------------------------------------
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to disable the old Abfrage CtlQueryVmKesKennzahlen.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

DECLARE @ClassName VARCHAR(255);
SET @ClassName = 'CtlQueryVmKesKennzahlen';

IF (EXISTS(SELECT 1 FROM dbo.XMenuItem WITH (READUNCOMMITTED)
           WHERE ClassName = @ClassName))
BEGIN
  UPDATE dbo.XMenuItem
  SET Visible = 0, 
      [Enabled] = 0
  WHERE ClassName = 'CtlQueryVmKesKennzahlen';
  
  PRINT('Info: Updated XMenuItem ' + @ClassName + ' - invisible and disabled.');
END
ELSE
  PRINT('Info: XMenuItem ' + @ClassName + ' not found. Can not disable the Abfrage.');

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
commit

--R4632_9465_Add_XLOVCode

/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert XLOVCode XTaskAutoGeneratedType.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- XTaskAutoGeneratedType
-------------------------------------------------------------------------------
DECLARE @LOVName VARCHAR(100);
DECLARE @XLOVID INT;
SET @LOVName = 'XTaskAutoGeneratedType';

IF (EXISTS (SELECT TOP 1 1
            FROM dbo.XLOVCode WITH (READUNCOMMITTED)
            WHERE LOVName = @LOVName))
BEGIN
  -- bestehende Werte löschen
  DELETE FROM dbo.XLOVCode
  WHERE LOVName = @LOVName
    AND Code = 13;

  -- XLOVID heraussuchen
  SELECT @XLOVID = XLOVID
  FROM dbo.XLOV WITH (READUNCOMMITTED)
  WHERE LOVName = @LOVName;

  -- neuen Wert einfügen
  INSERT INTO [XLOVCode] ([XLOVID], [LOVName], [Code], [Text], [SortKey], [ShortText], [BFSCode], [Value1], [Value2], [Value3], [Description], [LOVCodeName], [IsActive], [System]) 
                  VALUES (@XLOVID, @LOVName, 13, N'KesFrist', 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1);
  
  -- falschen Sortkey korrigieren
  UPDATE [XLOVCode] SET SortKey = 13
  WHERE LOVName = @LOVName
    AND Code = 12
    AND SortKey = 12;

  PRINT ('Info: Added Value to LOVCode ' + @LOVName + '.');
END
ELSE
  PRINT ('Info: LOVCode ' + @LOVName + ' has NOT been updated.');
GO

-------------------------------------------------------------------------------
-- TaskType
-------------------------------------------------------------------------------
DECLARE @LOVName VARCHAR(100);
DECLARE @XLOVID INT;
SET @LOVName = 'TaskType';

IF (EXISTS (SELECT TOP 1 1
            FROM dbo.XLOV WITH (READUNCOMMITTED)
            WHERE LOVName = @LOVName))
BEGIN
  -- bestehende Werte löschen
  DELETE FROM dbo.XLOVCode
  WHERE LOVName = @LOVName
    AND Code IN (41, 42, 43, 44, 45);

  -- XLOVID heraussuchen
  SELECT @XLOVID = XLOVID
  FROM dbo.XLOV WITH (READUNCOMMITTED)
  WHERE LOVName = @LOVName;

  INSERT INTO [XLOVCode] ([XLOVID], [LOVName], [Code], [Text], [SortKey], [ShortText], [BFSCode], [Value1], [Value2], [Value3], [Description], [LOVCodeName], [IsActive], [System]) 
                  VALUES (@XLOVID, @LOVName, 41, N'Fristablauf Abklärung/Auftrag Erledigung SD', 41, NULL, NULL, 'KES - Abklärung/Aufträge Erledigung SD', 'Frist für Auftragserledigung.', NULL, NULL, NULL, 1, 1);
  
  INSERT INTO [XLOVCode] ([XLOVID], [LOVName], [Code], [Text], [SortKey], [ShortText], [BFSCode], [Value1], [Value2], [Value3], [Description], [LOVCodeName], [IsActive], [System]) 
                  VALUES (@XLOVID, @LOVName, 42, N'Fristablauf Abklärung/Auftrag Erledigung', 42, NULL, NULL, 'KES - Abklärung/Aufträge', 'Frist für Auftrags- / Abklärungs-Erledigung läuft ab.', NULL, NULL, NULL, 1, 1);
  
  INSERT INTO [XLOVCode] ([XLOVID], [LOVName], [Code], [Text], [SortKey], [ShortText], [BFSCode], [Value1], [Value2], [Value3], [Description], [LOVCodeName], [IsActive], [System]) 
                  VALUES (@XLOVID, @LOVName, 43, N'Fristablauf Massnahmen - Berichts- und Rechnungsablage Versand', 43, NULL, NULL, 'KES - Massnahmen Berichts- und Rechnungsablage', 'Frist für Auftragserledigung.', NULL, NULL, NULL, 1, 1);
  
  INSERT INTO [XLOVCode] ([XLOVID], [LOVName], [Code], [Text], [SortKey], [ShortText], [BFSCode], [Value1], [Value2], [Value3], [Description], [LOVCodeName], [IsActive], [System]) 
                  VALUES (@XLOVID, @LOVName, 44, N'Fristablauf Massnahmen - Berichts- und Rechnungsablage Verfügung Kesb', 44, NULL, NULL, 'KES - Massnahmen - Berichts- und Rechnungsablage', 'Die Verfügung KESB auf den Bericht ist fällig.', NULL, NULL, NULL, 1, 1);

  INSERT INTO [XLOVCode] ([XLOVID], [LOVName], [Code], [Text], [SortKey], [ShortText], [BFSCode], [Value1], [Value2], [Value3], [Description], [LOVCodeName], [IsActive], [System]) 
                  VALUES (@XLOVID, @LOVName, 45, N'Fristablauf Massnahmen - Aufträge/Anträge Versand', 45, NULL, NULL, 'KES - Massnahmen - Abklärung/Aufträge', 'Die Verfügung KESB auf den Geschäftsbericht ist fällig.', NULL, NULL, NULL, 1, 1);

  PRINT ('Info: Added Value to LOVCode ' + @LOVName + '.');
END
ELSE
  PRINT ('Info: LOVCode ' + @LOVName + ' has NOT been updated.');
GO

-------------------------------------------------------------------------------
-- Abschlussgrund
-------------------------------------------------------------------------------
DECLARE @LOVName VARCHAR(100);
DECLARE @XLOVID INT;
SET @LOVName = 'Abschlussgrund';

IF (EXISTS (SELECT TOP 1 1
            FROM dbo.XLOV WITH (READUNCOMMITTED)
            WHERE LOVName = @LOVName))
BEGIN
  -- bestehende Werte löschen
  DELETE FROM dbo.XLOVCode
  WHERE LOVName = @LOVName
    AND Code = 50000;

  -- XLOVID heraussuchen
  SELECT TOP 1 @XLOVID = XLOVID
  FROM dbo.XLOVCode WITH (READUNCOMMITTED)
  WHERE LOVName = @LOVName;

  -- Neuen LovCode
  INSERT INTO [XLOVCode] ([XLOVID], [LOVName], [Code], [Text], [SortKey], [ShortText], [BFSCode], [Value1], [Value2], [Value3], [Description], [LOVCodeName], [IsActive], [System]) 
  SELECT @XLOVID, @LOVName, 50000, N'Übertragung in neurechtliche M-Leistung', 50000, NULL, NULL, NULL, NULL, NULL, NULL, 'UebertragungInNeurechtlicheMLeistung', 1, 1 

  PRINT ('Info: Added Value to LOVCode ' + @LOVName + '.');
END
ELSE
  PRINT ('Info: LOVCode ' + @LOVName + ' has NOT been updated.');
GO


-------------------------------------------------------------------------------
-- EroeffnungsGrund
-------------------------------------------------------------------------------
DECLARE @LOVName VARCHAR(100);
DECLARE @XLOVID INT;
SET @LOVName = 'EroeffnungsGrund';

IF (EXISTS (SELECT TOP 1 1
            FROM dbo.XLOV WITH (READUNCOMMITTED)
            WHERE LOVName = @LOVName))
BEGIN
  -- bestehende Werte löschen
  DELETE FROM dbo.XLOVCode
  WHERE LOVName = @LOVName
    AND Code in (290001, 290002, 290003);

  -- XLOVID heraussuchen
  SELECT TOP 1 @XLOVID = XLOVID
  FROM dbo.XLOVCode WITH (READUNCOMMITTED)
  WHERE LOVName = @LOVName;

 -- Neuen LovCode Abklärungsauftrag
INSERT INTO [XLOVCode] ( [XLOVID], [LOVName], [Code], [Text], [SortKey], [ShortText], [BFSCode], [Value1], [Value2], [Value3], [Description], [LOVCodeName], [IsActive], [System]) 
VALUES (@XLOVID, @LOVName, 290001, N'Abklärungsauftrag', 290001, NULL, NULL, NULL, NULL, N'M', NULL, NULL, 1, 1)

 -- Neuen LovCode Übertragung
INSERT INTO [XLOVCode] ( [XLOVID], [LOVName], [Code], [Text], [SortKey], [ShortText], [BFSCode], [Value1], [Value2], [Value3], [Description], [LOVCodeName], [IsActive], [System]) 
VALUES (@XLOVID, @LOVName, 290002, N'Übertragung', 290002, NULL, NULL, NULL, NULL, N'M', NULL, NULL, 1, 1)

 -- Neuen LovCode Übertragung von altrechtlicher V-Leistung
INSERT INTO [XLOVCode] ( [XLOVID], [LOVName], [Code], [Text], [SortKey], [ShortText], [BFSCode], [Value1], [Value2], [Value3], [Description], [LOVCodeName], [IsActive], [System]) 
VALUES (@XLOVID, @LOVName, 290003, N'Überführung von altrechtlicher V-Leistung', 290003, NULL, NULL, NULL, NULL, N'M', NULL, NULL, 1, 1)


  PRINT ('Info: Added Values to LOVCode ' + @LOVName + '.');
END
ELSE
  PRINT ('Info: LOVCode ' + @LOVName + ' has NOT been updated.');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

--R4632_9465_Mig__KesArtikel

/*===============================================================================================
  SUMMARY: Use this script to migrate KesArtikel.
=================================================================================================*/

PRINT ('Info: **** KesArtikel **** Start');
GO

-------------------------------------------------------------------------------
-- Pre-Steps (drop dependent functions and views, etc.)
-------------------------------------------------------------------------------
-- <none>
GO

-------------------------------------------------------------------------------
-- Cleanup invalid data in KesArtikel
-------------------------------------------------------------------------------
PRINT ('Info: Cleanup invalid data in table "KesArtikel"');
GO

-- remove invalid entries
-- <none>

-- PRINT ('Info: Deleted "' + CONVERT(VARCHAR(20), @@ROWCOUNT) + '" entries in table "KesArtikel"');
-- GO

-------------------------------------------------------------------------------
-- Drop Triggers
-------------------------------------------------------------------------------
PRINT ('Info: Delete triggers of table "KesArtikel"');
GO

-- drop Triggers
-- <none>
GO

-------------------------------------------------------------------------------
-- Drop FKs on other tables
-- 
-- WARNING: This will only work for the first time and original table.
-- Here, you have no second chance for any further executions.
-------------------------------------------------------------------------------
-- info
PRINT ('Info: Auto dropping FKs of other tables pointing to table "KesArtikel"');
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
DECLARE @FKColumns VARCHAR(255);
DECLARE @FKColumnName VARCHAR(128);

-- set vars
SET @PKTableName = 'KesArtikel';

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
  SELECT FK_NAME, FKTABLE_NAME
  FROM @TmpForeignFK;

OPEN curFKs;
WHILE (1 = 1)
BEGIN
  FETCH NEXT
  FROM curFKs
  INTO @FKName, @FKTableName;

  IF (@@FETCH_STATUS != 0)
  BEGIN
    BREAK;
  END;

  -- drop FK
  SET @Script = 'ALTER TABLE dbo.' + @FKTableName + ' DROP CONSTRAINT [' + @FKName + '];'
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
    SET @Script = 'ALTER TABLE [dbo].[' + @FKTableName + '] WITH ' + @CheckMode +
                  ' ADD CONSTRAINT [' + @FKName + '] FOREIGN KEY (' + @FKColumns + ')' + 
                  ' REFERENCES [' + @PKTableName + '] (' + @PKColumns + ')' + @Rules;
    
    IF (@NoCheck = 0)
    BEGIN
      SET @Script = @Script + ' ALTER TABLE [dbo].[' + @FKTableName + '] CHECK CONSTRAINT [' + @FKName + ']';
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
  WHERE OBJECT_NAME(parent_object_id) = 'KesArtikel'
    AND is_not_trusted = 1;

-------------------------------------------------------------------------------
-- Drop depending objects such as keys and constraints of table KesArtikel
-------------------------------------------------------------------------------
PRINT ('Info: Auto dropping PK, IXs, UKs, FKs, DFs and CKs of table "KesArtikel"');
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
SET @PKTableName = 'KesArtikel';

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
SELECT @EntriesCount = COUNT(1),
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
-- rename original table "KesArtikel" to "_Old_KesArtikel"
-------------------------------------------------------------------------------
PRINT ('Info: Rename original table "KesArtikel" to "_Old_KesArtikel".');
GO

-- rename table to _old_...
EXEC dbo.spDropObject _Old_KesArtikel;
EXECUTE sp_rename N'KesArtikel', N'_Old_KesArtikel', 'OBJECT';
GO

-------------------------------------------------------------------------------
-- recreate table "KesArtikel"
-------------------------------------------------------------------------------
PRINT ('Info: Recreate new table "KesArtikel".');
GO

-- create new table from definition
CREATE TABLE [dbo].[KesArtikel](
  [KesArtikelID] [int] IDENTITY(1,1) NOT NULL,
  [CodeKokes] [varchar](7) NOT NULL,
  [Artikel] [varchar](50) NOT NULL,
  [Absatz] [varchar](50) NULL,
  [Ziffer] [varchar](50) NULL,
  [Gesetz] [varchar](50) NOT NULL,
  [Bezeichnung] [varchar](max) NULL,
  [BezeichnungKurz] [varchar](max) NULL,
  [KesMassnahmeTypCode] [int] NOT NULL,
  [IsMassnahmeGebunden] [bit] NOT NULL,
  [DatumVon] [datetime] NULL,
  [DatumBis] [datetime] NULL,
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [KesArtikelTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesArtikel] PRIMARY KEY CLUSTERED 
(
  [KesArtikelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KesArtikel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'KesArtikelID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kokes Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'CodeKokes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Artikel, z.B. 134.3 ZGB' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Artikel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Absatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Absatz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ziffer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Ziffer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gesetz, z.B. ZGB oder aZGB' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Gesetz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Artikel Bezeichnung, z.B.: Neuregelung elterliche Sorge bei geschiedenen Eltern - Zuteilung gemeinsame elterliche Sorge' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Bezeichnung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kurztext der Bezeichnung für die bessere Anzeige auf den Masken' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'BezeichnungKurz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der LOV KesMassnahmeTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'KesMassnahmeTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob der Artikel ein massnahmegebundenes Geschäft beschreibt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'IsMassnahmeGebunden'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum ab wann ein Artikel für neue Massnahmen verwendet werden darf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum bis wann ein Artikel für neue Massnahmen verwendet werden darf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel', @level2type=N'COLUMN',@level2name=N'KesArtikelTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'André Wittwer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kes ZGB Artikel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesArtikel'
GO

ALTER TABLE [dbo].[KesArtikel] ADD CONSTRAINT [DF_KesArtikel_IsMassnahmeGebunden] DEFAULT ((0)) FOR [IsMassnahmeGebunden]
GO

ALTER TABLE [dbo].[KesArtikel] ADD CONSTRAINT [DF_KesArtikel_Created] DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesArtikel] ADD CONSTRAINT [DF_KesArtikel_Modified] DEFAULT (getdate()) FOR [Modified]
GO


GO

-------------------------------------------------------------------------------
-- disable history-trigger
-------------------------------------------------------------------------------
PRINT ('Info: Disable history trigger on table "KesArtikel".');
GO

-- disable trigger (remember to enable trigger again!!)
-- optional: DISABLE TRIGGER trHist_KesArtikel ON KesArtikel;
GO

-------------------------------------------------------------------------------
-- disable NOCHECK-FKs
-------------------------------------------------------------------------------
PRINT ('Info: Disable NOCHECK FKs on table "KesArtikel".');
GO

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @SQL NVARCHAR(255);

SELECT @EntriesCount = COUNT(1),
       @EntriesIterator = 1
FROM #TmpNoCheckFK;

WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  SELECT @SQL = 'ALTER TABLE dbo.KesArtikel NOCHECK CONSTRAINT [' + TMP.name + '];'
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
PRINT ('Info: Start with migration of data from old to new table "KesArtikel".');
GO

-- declare and init vars
DECLARE @ErrorMessage VARCHAR(MAX);
SET @ErrorMessage = NULL;

BEGIN TRY
  -- migrate data (CUSTOM)
  SET IDENTITY_INSERT dbo.KesArtikel ON;
  
  -- do reimport
  IF (NOT EXISTS (SELECT TOP 1 1 
                  FROM dbo._Old_KesArtikel))
  BEGIN
    PRINT ('Info: Table does not contain any data, no migration required');
  END
  ELSE
  BEGIN
    PRINT ('Info: Table contains data, starting migration...');
    
    ---------------------------------------------------------------------------
    -- do migration
    ---------------------------------------------------------------------------
    EXEC('
    INSERT INTO dbo.KesArtikel (
        KesArtikelID,
        CodeKokes,
        Artikel,
        Absatz,
        Ziffer,
        Gesetz,
        Bezeichnung,
        BezeichnungKurz,
        KesMassnahmeTypCode,
        IsMassnahmeGebunden,
        DatumVon,
        DatumBis,
        Creator,
        Created,
        Modifier,
        Modified)
      SELECT
        KesArtikelID,
        CodeKokes,
        Artikel,
        Absatz,
        Ziffer,
        Gesetz,
        Bezeichnung,
        NULL, -- BezeichnungKurz, wird in separatem Script eingefügt
        KesMassnahmeTypCode,
        IsMassnahmeGebunden,
        NULL, --DatumVon
        NULL, --DatumBis
        Creator,
        Created,
        Modifier,
        Modified
      FROM dbo._Old_KesArtikel OLD WITH (HOLDLOCK TABLOCKX);

    -- info
    PRINT (''Info: Migrated "'' + CONVERT(VARCHAR(20), @@ROWCOUNT) + ''" entries in table "KesArtikel"'');
    ');
  END;
  
  SET IDENTITY_INSERT dbo.KesArtikel OFF;
  
  -- remember to remove old table in next release!
  -- >: EXEC dbo.spDropObject _Old_KesArtikel;
  
  PRINT ('Info: Done migrating data to new table "KesArtikel".');
END TRY
BEGIN CATCH
  SET @ErrorMessage = ERROR_MESSAGE();
  
  -- reset identity to ensure other script will not fail
  SET IDENTITY_INSERT dbo.KesArtikel OFF;
  
  RAISERROR ('Critical Error: Could not migrate data into new table "KesArtikel". Database error was: %s', 18, 1, @ErrorMessage);
END CATCH;
GO

-------------------------------------------------------------------------------
-- enable history-trigger
-------------------------------------------------------------------------------
PRINT ('Info: Enable history trigger on table "KesArtikel".');
GO

-- enable trigger
-- optional: ENABLE TRIGGER trHist_KesArtikel ON KesArtikel;
GO

-------------------------------------------------------------------------------
-- Recreate FKs on other tables
-------------------------------------------------------------------------------
PRINT ('Info: Auto recreating FKs of other tables pointing to table "KesArtikel"');
GO

-- init vars
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @Script NVARCHAR(MAX);

-- prepare vars for loop
SELECT @EntriesCount = COUNT(1),
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
PRINT ('Info: Reenable NOCHECK FKs on table "KesArtikel".');
GO

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @SQL NVARCHAR(255);

SELECT @EntriesCount = COUNT(1),
       @EntriesIterator = 1
FROM #TmpNoCheckFK;

WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  SELECT @SQL = 'ALTER TABLE dbo.KesArtikel CHECK CONSTRAINT [' + TMP.name + '];'
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
PRINT ('Info: **** KesArtikel **** End');
GO


--*****************************************************************************
-- Post-Steps
--*****************************************************************************
GO

--R4632_9465_Rename_VmKasse

/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to rename the MenuItem for VmKasse.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- Rename Menuitem for VmKasse
-------------------------------------------------------------------------------
IF EXISTS(SELECT TOP 1 1 FROM dbo.XModul WHERE ModulID = 29 AND Licensed = 1)
BEGIN
  UPDATE XMenuItem SET Caption = 'KES - Kasse' WHERE ClassName='FrmVmKasse';
END
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

--R4632_9465_Translate_XLOVCode
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert the transtaltion for XLOVCode.
  
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO


-------------------------------------------------------------------------------
-- Add french translation to XLOVCode.Text
-------------------------------------------------------------------------------
BEGIN TRAN
-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @LovName VARCHAR(100);
DECLARE @Code INT;
DECLARE @TextDE VARCHAR(100);
DECLARE @TextFR VARCHAR(2000);
DECLARE @TextTID INT;
DECLARE @TextDEAktuell VARCHAR(100);


DECLARE @LovText TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  LovName VARCHAR(100),
  Code INT,
  TextDE VARCHAR(100),
  TextFR VARCHAR(2000),
  TextTID INT,
  TextDEAktuell VARCHAR(100)
);

;WITH LovCte (LovName, Code, TextDE, TextFR) AS
(
-- generiert aus T:\SE\Projekte\D10 KiSS Standard\1 Projekte\JU - APEA\4 Realisierung\5 Übersetzungen\übersetzt\Wertelisten_FR_R4632mitSql_.xlsx 
SELECT 'TaskType', 41, 'Fristablauf Abklärung/Auftrag Erledigung SD', 'Expiration du délai - Demande/Clarification - Service social' UNION ALL
SELECT 'TaskType', 42, 'Fristablauf Abklärung/Auftrag Erledigung', 'Expiration du délai - Demande/Clarification' UNION ALL
SELECT 'TaskType', 43, 'Fristablauf Massnahmen - Berichts- und Rechnungsablage Versand', 'Expiration du délai - Gestion des mesures - Rapports d''activités et comptes - Envoi' UNION ALL
SELECT 'TaskType', 44, 'Fristablauf Massnahmen - Berichts- und Rechnungsablage Verfügung Kesb', 'Expiration du délai - Gestion des mesures - Rapports d''activités et comptes - Décret APEA' UNION ALL
SELECT 'TaskType', 45, 'Fristablauf Massnahmen - Aufträge/Anträge Versand', 'Expiration du délai - Gestion des mesures - Mandats/Demandes - Envoi' 
)

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @LovText(LovName, Code, TextDE, TextFR, TextTID, TextDEAktuell)
  SELECT 
    CTE.LovName, 
    CTE.Code, 
    CTE.TextDE, 
    CTE.TextFR,
    LOC.TextTID,
    LOC.Text
  FROM LovCte CTE
    INNER JOIN dbo.XLOVCode LOC ON LOC.LOVName = CTE.LovName AND LOC.Code = CTE.Code

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT; -- needs to be done just after filling!
SET @EntriesIterator = 1; -- needs to start just at the same value as IDENTITY column on table

---- CHECK
--SELECT 
-- LOV.*,
-- LAN.Text
--FROM @LovText LOV
-- INNER JOIN dbo.XLOVCode LOC ON LOC.LOVName = LOV.LovName AND LOC.Code = LOV.Code
-- LEFT JOIN dbo.XLangText LAN WITH (READUNCOMMITTED) ON LAN.TID = LOV.TextTID AND LAN.LanguageCode = 2
--WHERE LOV.TextFR <> LAN.Text
----WHERE LOV.TextDE <> LOC.Text

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @LovName = TMP.LovName,
         @Code = TMP.Code,
         @TextDE = TMP.TextDE,
         @TextFR = TMP.TextFR,
         @TextTID = TMP.TextTID,
         @TextDEAktuell = TMP.TextDEAktuell
  FROM @LovText TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------
  IF (@TextFR = '' OR @TextFR IS NULL)
  BEGIN
    PRINT ('Info: TextFR ist leer, wurde nicht übersetzt bei "' + @LovName + '" mit Code ' + CONVERT(VARCHAR, @Code) );
  END
  ELSE
  BEGIN
    IF(@TextDE = @TextDEAktuell)
    BEGIN
      EXEC dbo.spXSetXLangText @TextTID, 2, @TextFR, NULL, NULL, NULL, NULL, @TextTID OUT
  
      UPDATE dbo.XLOVCode
        SET TextTID = @TextTID
      WHERE LOVName = @LovName
        AND Code = @Code
    END
    ELSE
    BEGIN
      PRINT ('Warning: TextFR nicht übersetzt bei "' + @LovName + '" mit Code ' + CONVERT(VARCHAR, @Code) + ' weil @TextDE: "' + @TextDE + '" <> @TextDEAktuell:"' + @TextDEAktuell + '"');
    END;
  END;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

COMMIT

GO


-------------------------------------------------------------------------------
-- Order KES LOV alphabeticatly
-------------------------------------------------------------------------------
/* TODO Sollte im Standard nicht ausgeführt werden!
;WITH LovCte AS
(
  SELECT 
    LOC.LOVName, 
    LOC.Code, 
    Text = ISNULL(LAN.Text, LOC.Text), 
    LOC.SortKey, 
    SortKeyNew = RANK() OVER(PARTITION BY LOC.LOVName ORDER BY CASE WHEN ISNULL(LAN.Text, LOC.Text) = 'Autre' THEN 1 ELSE 0 END, ISNULL(LAN.Text, LOC.Text))
  FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
    INNER JOIN dbo.XLOV LOV WITH (READUNCOMMITTED) ON LOV.LOVName = LOC.LOVName
    LEFT JOIN dbo.XLangText LAN WITH (READUNCOMMITTED) ON LAN.TID = LOC.TextTID AND LAN.LanguageCode = 2
  WHERE LOV.LOVName LIKE 'Kes%'
    AND LOV.ModulID = 29
)

UPDATE LOC 
  SET SortKey = SortKeyNew
FROM LovCte CTE
  INNER JOIN dbo.XLOVCode LOC WITH (READUNCOMMITTED) ON LOC.LOVName = CTE.LOVName AND LOC.Code = CTE.Code
*/
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

--R4632_9465_Update_XLOVCodes

/*===============================================================================================
  SUMMARY: Use this script to update som XLOVCodes.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- Add french and italian translation to XLOVCode.Text, set KokesCode in Value1 and update SortKey
-------------------------------------------------------------------------------
BEGIN TRAN
-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @LOVName VARCHAR(500);
DECLARE @XLOVID INT;
DECLARE @Code VARCHAR(500);
DECLARE @Value1 VARCHAR(2000);
DECLARE @Value3 VARCHAR(2000);
DECLARE @SortKey INT;
DECLARE @IsActive BIT;
DECLARE @LOV_Description VARCHAR(2000);
DECLARE @LOV_Expandable BIT;
DECLARE @LOV_ModulID INT;
DECLARE @LOV_NameValue3 VARCHAR(2000);
DECLARE @Action VARCHAR(1);
DECLARE @TextDE VARCHAR(2000);
DECLARE @TextFR VARCHAR(2000);
DECLARE @TextTID INT;
DECLARE @System BIT;


DECLARE @LOVCodeText TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  LOVName VARCHAR(100),
  XLOVID INT,
  Code INT,
  IsActive BIT,
  SortKey INT,
  Value1 VARCHAR(2000),
  Value3 VARCHAR(2000),
  LOV_Description VARCHAR(2000),
  LOV_Expandable BIT, 
  LOV_ModulID INT, 
  LOV_NameValue3 VARCHAR(2000),
  Action VARCHAR(1),
  TextDE VARCHAR(2000),
  TextFR VARCHAR(2000),
  TextTID INT,
  System BIT
);

;WITH LOVCodeCte (LOVName, Code, IsActive, SortKey, Value1, Value3, LOV_Description, LOV_Expandable, LOV_ModulID, LOV_NameValue3, Action, TextDE, TextFR) AS
(

SELECT 'KesAuftragAbschlussgrund', 1, 0, 1, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Abbruch', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 7, 0, 7, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Andere', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 2, 0, 6, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Aufhebung Massnahme', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 3, 0, 2, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Tod', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 4, 0, 4, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Übertragung an andere Gemeinde', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 5, 0, 5, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Übertragung an andere Institution', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 9, 0, 3, NULL, NULL, NULL, 1, 29, NULL, 'I', 'Übertragung an Dritte', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 10, 0, 4, NULL, NULL, NULL, 1, 29, NULL, 'I', 'Verfügung Massnahme', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 6, 0, 5, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Wegzug', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 8, 0, 6, NULL, NULL, NULL, 1, 29, NULL, 'I', 'Ziel erreicht', '' UNION ALL

SELECT 'KesAuftragAbschlussgrund', 11, 1, 1, NULL, NULL, NULL, 1, 29, NULL, 'I', 'Dem Antrag wurde entsprochen', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 12, 1, 2, NULL, NULL, NULL, 1, 29, NULL, 'I', 'Dem Antrag wurde teilweise entsprochen', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 13, 1, 3, NULL, NULL, NULL, 1, 29, NULL, 'I', 'Dem Antrag wurde nicht entsprochen', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 14, 1, 4, NULL, NULL, NULL, 1, 29, NULL, 'I', 'Auftrag erledigt', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 15, 1, 5, NULL, NULL, NULL, 1, 29, NULL, 'I', 'Abklärung abgeschrieben', '' UNION ALL
SELECT 'KesAuftragAbschlussgrund', 16, 1, 6, NULL, NULL, NULL, 1, 29, NULL, 'I', 'Unbekannt', '' UNION ALL


SELECT 'KesGefaehrdungsmeldungDurchES', 2, 1, 1, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Angehörige (Kinder, Ehegatte, Eltern)', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchES', 5, 1, 2, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Arbeitgeber', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchES', 6, 1, 3, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Arzt/Klinik/Spital/Heim/Spitex', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchES', 1, 1, 4, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Betroffene Person selber', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchES', 11, 1, 5, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Keine (KESB von Amtes wegen)', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchES', 9, 1, 6, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Polizei/Gericht', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchES', 3, 1, 7, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Privatperson (z.B. Nachbarn), Verwandte', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchES', 7, 1, 8, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Sozialdienst/Fachberatungsstelle', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchES', 4, 1, 9, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Vermieter', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchES', 8, 1, 10, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Weitere Amtsstellen (z.B. Betreibungsamt, Steueramt, Ausgleichskasse)', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchES', 10, 1, 11, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Andere', '' UNION ALL

SELECT 'KesGefaehrdungsmeldungDurchKS', 6, 1, 1, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Arzt/Klinik/Spital', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchKS', 1, 1, 2, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Betroffenes Kind selber', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchKS', 11, 1, 3, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Keine (KESB von Amtes wegen)', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchKS', 5, 1, 4, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Pflegeeltern, Heim, Kindertagesstätten', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchKS', 9, 1, 5, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Polizei/Gericht', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchKS', 3, 1, 6, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Privatperson (z.B. Nachbarn), Verwandte', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchKS', 4, 1, 7, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Schule (Lehrpersonen, Schulsozialarbeit, schulpsychologischer Dienst)', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchKS', 7, 1, 8, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Sozialdienst/Fachberatungsstelle', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchKS', 2, 1, 9, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Vater, Mutter', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchKS', 8, 1, 10, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Weitere Amtsstellen', '' UNION ALL
SELECT 'KesGefaehrdungsmeldungDurchKS', 10, 1, 11, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Andere', '' UNION ALL

SELECT 'KesAufhebungsgrundES', 5, 1, 5, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Anderes', '' UNION ALL

SELECT 'KesAufhebungsgrundKS', 5, 1, 1, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Aufhebung mit gleichzeitiger Neuerrichtung einer anderen Massnahme', '' UNION ALL
SELECT 'KesAufhebungsgrundKS', 4, 1, 2, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Massnahme ungeeignet', '' UNION ALL
SELECT 'KesAufhebungsgrundKS', 3, 1, 3, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Tod', '' UNION ALL
SELECT 'KesAufhebungsgrundKS', 1, 1, 4, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Volljährigkeit', '' UNION ALL
SELECT 'KesAufhebungsgrundKS', 2, 1, 5, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Wegfall Errichtungsgrund', '' UNION ALL
SELECT 'KesAufhebungsgrundKS', 6, 1, 6, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Anderes', '' UNION ALL

SELECT 'KesMassnahmeGeschaeftsart', 6, 1, 1, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Zustimmungsgeschäfte nach ZGB 416', '' UNION ALL
SELECT 'KesMassnahmeGeschaeftsart', 2, 1, 2, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Inventar', '' UNION ALL
SELECT 'KesMassnahmeGeschaeftsart', 5, 1, 3, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Wechsel Mandatsführung', '' UNION ALL
SELECT 'KesMassnahmeGeschaeftsart', 1, 1, 4, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Abänderung Massnahme', '' UNION ALL
SELECT 'KesMassnahmeGeschaeftsart', 4, 1, 5, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Vermögensanlage nach VBVV', '' UNION ALL
SELECT 'KesMassnahmeGeschaeftsart', 3, 1, 6, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Übertragung', '' UNION ALL
SELECT 'KesMassnahmeGeschaeftsart', 7, 1, 7, NULL, NULL, NULL, 1, 29, NULL, 'U', 'Andere', '' UNION ALL

SELECT 'KesDienstleistung', 6, 1, 1, NULL, '1', NULL, 1, 29, NULL, 'U', 'Bericht', '' UNION ALL
SELECT 'KesDienstleistung', 9, 1, 2, NULL, '2', NULL, 1, 29, NULL, 'U', 'Zustimmungsgeschäft nach ZGB 416', '' UNION ALL
SELECT 'KesDienstleistung', 8, 1, 3, NULL, '2', NULL, 1, 29, NULL, 'U', 'Wechsel Mandatsträger', '' UNION ALL
SELECT 'KesDienstleistung', 1, 1, 4, NULL, '1', NULL, 1, 29, NULL, 'U', 'Abklärung', '' UNION ALL
SELECT 'KesDienstleistung', 4, 1, 5, NULL, '1', NULL, 1, 29, NULL, 'U', 'Beratung', '' UNION ALL
SELECT 'KesDienstleistung', 5, 1, 6, NULL, '2', NULL, 1, 29, NULL, 'U', 'Beratung Rechnungsführung', '' UNION ALL
SELECT 'KesDienstleistung', 2, 1, 7, NULL, '2', NULL, 1, 29, NULL, 'U', 'Allgemeine Beratung', '' UNION ALL
SELECT 'KesDienstleistung', 7, 1, 8, NULL, '1', NULL, 1, 29, NULL, 'U', 'Pflegevertrag', '' UNION ALL
SELECT 'KesDienstleistung', 3, 1, 9, NULL, '1', NULL, 1, 29, NULL, 'U', 'Aufsichtsbesuch', '' UNION ALL
SELECT 'KesDienstleistung', 11, 1, 10, NULL, '1,2', NULL, 1, 29, NULL, 'I', 'Korrespondenz', '' UNION ALL
SELECT 'KesDienstleistung', 10, 1, 11, NULL, '1', NULL, 1, 29, NULL, 'U', 'Andere', '' UNION ALL


-- generiert aus 9465_Anpassungen_an_LOVs_v2.xlsx

SELECT 'KesDienstleistung', 10, 1, 11, NULL, '1,2', 'Dienstleistung (PriMa-Begleitung / Pflegekinderaufsicht)', 1, 29, NULL, 'U', 'Andere', '' UNION ALL
SELECT 'KesDienstleistung', 6, 1, 1, NULL, '1', 'Dienstleistung (PriMa-Begleitung / Pflegekinderaufsicht)', 1, 29, NULL, 'U', 'Bericht', '' UNION ALL
SELECT 'KesDokumentResultat', 1, 1, 4, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Anpassung bestehende Regelung', '' UNION ALL
SELECT 'KesDokumentResultat', 2, 1, 5, NULL, '2,8', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Auftrag erledigt', '' UNION ALL
SELECT 'KesDokumentResultat', 3, 1, 6, NULL, '3,4,6,7', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Beibehaltung Mandat', '' UNION ALL
SELECT 'KesDokumentResultat', 21, 1, 1, NULL, '1,2,3,4,5,6,7,8,9,10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'I', 'Dem Antrag wurde entsprochen', '' UNION ALL
SELECT 'KesDokumentResultat', 23, 1, 3, NULL, '1,2,3,4,5,6,7,8,9,10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'I', 'Dem Antrag wurde nicht entsprochen', '' UNION ALL
SELECT 'KesDokumentResultat', 22, 1, 2, NULL, '1,2,3,4,5,6,7,8,9,10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'I', 'Dem Antrag wurde teilweise entsprochen', '' UNION ALL
SELECT 'KesDokumentResultat', 4, 1, 7, NULL, '3,4,6,7,9', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Errichtung Mandat', '' UNION ALL
SELECT 'KesDokumentResultat', 5, 1, 8, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Gemeinsame Elterliche Sorge andere', '' UNION ALL
SELECT 'KesDokumentResultat', 6, 1, 9, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Gemeinsame Elterliche Sorge aufgehoben', '' UNION ALL
SELECT 'KesDokumentResultat', 7, 1, 10, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Gemeinsame Elterliche Sorge erteilt', '' UNION ALL
SELECT 'KesDokumentResultat', 8, 1, 11, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Gemeinsame Elterliche Sorge nicht erteilt', '' UNION ALL
SELECT 'KesDokumentResultat', 15, 1, 12, NULL, '3,4,6,7', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Kein Mandat - Abschluss', '' UNION ALL
SELECT 'KesDokumentResultat', 16, 1, 13, NULL, '3,4,6,7', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Kein Mandat - Freiwillige/präventive Beratung', '' UNION ALL
SELECT 'KesDokumentResultat', 17, 1, 14, NULL, '3,4,6,7', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Kein Mandat - Vernetzung mit anderer Stelle', '' UNION ALL
SELECT 'KesDokumentResultat', 9, 1, 15, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Keine Regelung - Ausreise der Eltern', '' UNION ALL
SELECT 'KesDokumentResultat', 10, 1, 16, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Keine Regelung - Heirat der Eltern', '' UNION ALL
SELECT 'KesDokumentResultat', 11, 1, 17, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Keine Regelung - mangelnde Leistungsfähigkeit', '' UNION ALL
SELECT 'KesDokumentResultat', 12, 1, 18, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Keine Regelung - unbekannter Aufenthalt', '' UNION ALL
SELECT 'KesDokumentResultat', 13, 1, 19, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Keine Regelung - Verzicht der Mutter', '' UNION ALL
SELECT 'KesDokumentResultat', 14, 1, 20, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Keine Regelung - weitere', '' UNION ALL
SELECT 'KesDokumentResultat', 20, 1, 21, NULL, '2,3,4,6,7,8,9', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Unbekannt', '' UNION ALL
SELECT 'KesDokumentResultat', 18, 1, 22, NULL, '9', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Validierung Vorsorgeauftrag', '' UNION ALL
SELECT 'KesDokumentResultat', 19, 1, 23, NULL, '10', 'Resultat der Abklärung', 0, 29, 'Filter aufgrund LOV KesAuftragAbklaerungsart', 'U', 'Vaterschaft und Unterhalt geregelt', '' UNION ALL
SELECT 'KesKontaktart', 1, 1, 1, NULL, NULL, 'Kontaktart (PriMa-Begleitung / Pflegekinderaufsicht)', 1, 29, NULL, 'U', 'Gespräch', '' UNION ALL
SELECT 'KesKontaktart', 5, 1, 2, NULL, NULL, 'Kontaktart (PriMa-Begleitung / Pflegekinderaufsicht)', 1, 29, NULL, 'I', 'Korrespondenz', '' UNION ALL
SELECT 'KesKontaktart', 2, 0, 3, NULL, NULL, 'Kontaktart (PriMa-Begleitung / Pflegekinderaufsicht)', 1, 29, NULL, 'U', 'Mail', '' UNION ALL
SELECT 'KesKontaktart', 3, 1, 4, NULL, NULL, 'Kontaktart (PriMa-Begleitung / Pflegekinderaufsicht)', 1, 29, NULL, 'U', 'Mail/Telefon', '' UNION ALL
SELECT 'KesKontaktart', 4, 0, 5, NULL, NULL, 'Kontaktart (PriMa-Begleitung / Pflegekinderaufsicht)', 1, 29, NULL, 'U', 'Telefon', '' UNION ALL
SELECT 'KesPraeventionsabschluss', 1, 0, 1, NULL, NULL, 'Werte fürs Abschliessen einer Prävention', 0, 29, NULL, 'U', 'Abbruch', '' UNION ALL
SELECT 'KesPraeventionsabschluss', 7, 1, 4, NULL, NULL, 'Werte fürs Abschliessen einer Prävention', 0, 29, NULL, 'U', 'Andere', '' UNION ALL
SELECT 'KesPraeventionsabschluss', 2, 0, 2, NULL, NULL, 'Werte fürs Abschliessen einer Prävention', 0, 29, NULL, 'U', 'Tod', '' UNION ALL
SELECT 'KesPraeventionsabschluss', 3, 0, 3, NULL, NULL, 'Werte fürs Abschliessen einer Prävention', 0, 29, NULL, 'U', 'Übertragung an andere Gemeinde', '' UNION ALL
SELECT 'KesPraeventionsabschluss', 4, 0, 4, NULL, NULL, 'Werte fürs Abschliessen einer Prävention', 0, 29, NULL, 'U', 'Übertragung an andere Institution', '' UNION ALL
SELECT 'KesPraeventionsabschluss', 8, 0, 5, NULL, NULL, 'Werte fürs Abschliessen einer Prävention', 0, 29, NULL, 'I', 'Übertragung an Dritte', '' UNION ALL
SELECT 'KesPraeventionsabschluss', 5, 0, 6, NULL, NULL, 'Werte fürs Abschliessen einer Prävention', 0, 29, NULL, 'U', 'Verfügung Massnahme', '' UNION ALL
SELECT 'KesPraeventionsabschluss', 6, 0, 7, NULL, NULL, 'Werte fürs Abschliessen einer Prävention', 0, 29, NULL, 'U', 'Wegzug', '' UNION ALL
SELECT 'KesPraeventionsabschluss', 9, 1, 1, NULL, NULL, 'Werte fürs Abschliessen einer Prävention', 0, 29, NULL, 'I', 'Ziel erreicht', '' UNION ALL
SELECT 'KesPraeventionsabschluss', 10, 1, 2, NULL, NULL, 'Werte fürs Abschliessen einer Prävention', 0, 29, NULL, 'I', 'Antrag KESB', '' UNION ALL
SELECT 'KesPraeventionsabschluss', 11, 1, 3, NULL, NULL, 'Werte fürs Abschliessen einer Prävention', 0, 29, NULL, 'I', 'Abklärungsauftrag', '' UNION ALL
SELECT 'KesPraeventionsart', 3, 1, 1, NULL, NULL, 'Werte für Präventionsarten', 0, 29, NULL, 'I', 'Ambulante Massnahme ES', '' UNION ALL
SELECT 'KesPraeventionsart', 4, 1, 2, NULL, NULL, 'Werte für Präventionsarten', 0, 29, NULL, 'I', 'Ambulante Massnahme KS', '' UNION ALL
SELECT 'KesPraeventionsart', 2, 1, 8, NULL, NULL, 'Werte für Präventionsarten', 0, 29, NULL, 'U', 'Andere', '' UNION ALL
SELECT 'KesPraeventionsart', 6, 1, 3, NULL, NULL, 'Werte für Präventionsarten', 0, 29, NULL, 'I', 'Beratung Sorgerecht', '' UNION ALL
SELECT 'KesPraeventionsart', 5, 1, 4, NULL, NULL, 'Werte für Präventionsarten', 0, 29, NULL, 'I', 'ES mit Lohn-/Rentenverwaltung', '' UNION ALL
SELECT 'KesPraeventionsart', 1, 0, 5, NULL, NULL, 'Werte für Präventionsarten', 0, 29, NULL, 'U', 'Freiwillige Lohn-/Rentenverwaltung', '' UNION ALL
SELECT 'KesPraeventionsart', 7, 1, 6, NULL, NULL, 'Werte für Präventionsarten', 0, 29, NULL, 'I', 'Freiwilliger ES', '' UNION ALL
SELECT 'KesPraeventionsart', 8, 1, 7, NULL, NULL, 'Werte für Präventionsarten', 0, 29, NULL, 'I', 'Freiwilliger KS', '' UNION ALL
SELECT 'FaDauer', 1, 1, 1, '15', NULL, NULL, 1, 2, NULL, 'U', '0 - 15 min', '' UNION ALL
SELECT 'FaDauer', 2, 1, 2, '30', NULL, NULL, 1, 2, NULL, 'U', '16 - 30 min', '' UNION ALL
SELECT 'FaDauer', 3, 1, 3, '45', NULL, NULL, 1, 2, NULL, 'U', '31 - 45 min', '' UNION ALL
SELECT 'FaDauer', 4, 1, 4, '60', NULL, NULL, 1, 2, NULL, 'U', '46 - 60 min', '' UNION ALL
SELECT 'FaDauer', 5, 0, 5, NULL, NULL, NULL, 1, 2, NULL, 'U', 'über 60 Minuten', '' UNION ALL
SELECT 'FaDauer', 6, 1, 6, '75', NULL, NULL, 1, 2, NULL, 'I', '1 h 01 min - 1 h 15 min', '' UNION ALL
SELECT 'FaDauer', 7, 1, 7, '90', NULL, NULL, 1, 2, NULL, 'I', '1 h 16 min - 1 h 30 min', '' UNION ALL
SELECT 'FaDauer', 8, 1, 8, '105', NULL, NULL, 1, 2, NULL, 'I', '1 h 31 min - 1 h 45 min', '' UNION ALL
SELECT 'FaDauer', 9, 1, 9, '120', NULL, NULL, 1, 2, NULL, 'I', '1 h 46 min - 2 h 00 min', '' UNION ALL
SELECT 'FaDauer', 10, 1, 10, '135', NULL, NULL, 1, 2, NULL, 'I', '2 h 01 min - 2 h 15 min', '' UNION ALL
SELECT 'FaDauer', 11, 1, 11, '150', NULL, NULL, 1, 2, NULL, 'I', '2 h 16 min - 2 h 30 min', '' UNION ALL
SELECT 'FaDauer', 12, 1, 12, '165', NULL, NULL, 1, 2, NULL, 'I', '2 h 31 min - 2 h 45 min', '' UNION ALL
SELECT 'FaDauer', 13, 1, 13, '180', NULL, NULL, 1, 2, NULL, 'I', '2 h 46 min - 3 h 00 min', '' UNION ALL
SELECT 'FaDauer', 14, 1, 14, '195', NULL, NULL, 1, 2, NULL, 'I', '3 h 01 min - 3 h 15 min', '' UNION ALL
SELECT 'FaDauer', 15, 1, 15, '210', NULL, NULL, 1, 2, NULL, 'I', '3 h 16 min - 3 h 30 min', '' UNION ALL
SELECT 'FaDauer', 16, 1, 16, '225', NULL, NULL, 1, 2, NULL, 'I', '3 h 31 min - 3 h 45 min', '' UNION ALL
SELECT 'FaDauer', 17, 1, 17, '240', NULL, NULL, 1, 2, NULL, 'I', '3 h 46 min - 4 h 00 min', '' UNION ALL
SELECT 'KesAuftragAbklaerungsart', 1, 1, 1, NULL, 'ES,KS', 'Mögliche Abklärungsarten eines Auftrags', 0, 29, NULL, 'U', 'Adoption', '' UNION ALL
SELECT 'KesAuftragAbklaerungsart', 2, 1, 2, NULL, 'ES,KS', 'Mögliche Abklärungsarten eines Auftrags', 0, 29, NULL, 'U', 'Auftrag nach Art. 392 ZGB', '' UNION ALL
SELECT 'KesAuftragAbklaerungsart', 4, 1, 3, NULL, 'KS', 'Mögliche Abklärungsarten eines Auftrags', 0, 29, NULL, 'U', 'Gefährdungsmeldung KS', '' UNION ALL
SELECT 'KesAuftragAbklaerungsart', 3, 1, 4, NULL, 'ES', 'Mögliche Abklärungsarten eines Auftrags', 0, 29, NULL, 'U', 'Gefährdungsmeldung ES', '' UNION ALL
SELECT 'KesAuftragAbklaerungsart', 5, 1, 5, NULL, 'KS', 'Mögliche Abklärungsarten eines Auftrags', 0, 29, NULL, 'U', 'Gemeinsame elterliche Sorge KS', '' UNION ALL
SELECT 'KesAuftragAbklaerungsart', 7, 1, 6, NULL, 'KS', 'Mögliche Abklärungsarten eines Auftrags', 0, 29, NULL, 'U', 'Hilfestellung KS', '' UNION ALL
SELECT 'KesAuftragAbklaerungsart', 6, 1, 7, NULL, 'ES', 'Mögliche Abklärungsarten eines Auftrags', 0, 29, NULL, 'U', 'Hilfestellung ES', '' UNION ALL
SELECT 'KesAuftragAbklaerungsart', 8, 1, 8, NULL, 'ES', 'Mögliche Abklärungsarten eines Auftrags', 0, 29, NULL, 'U', 'Schutz in Wohn- / Pflegeeinrichtung', '' UNION ALL
SELECT 'KesAuftragAbklaerungsart', 10, 1, 9, NULL, 'KS', 'Mögliche Abklärungsarten eines Auftrags', 0, 29, NULL, 'U', 'Vaterschafts- und Unterhaltsregelung', '' UNION ALL
SELECT 'KesAuftragAbklaerungsart', 9, 1, 10, NULL, 'ES', 'Mögliche Abklärungsarten eines Auftrags', 0, 29, NULL, 'U', 'Vorsorgeauftrag', '' 



)

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @LOVCodeText(LOVName, Code, XLOVID, IsActive, SortKey, Value1, Value3, LOV_Description, LOV_Expandable, LOV_ModulID, LOV_NameValue3, Action, TextDE, TextFR, TextTID, System)
  SELECT 
    CTE.LOVName, 
    CTE.Code,
    ISNULL(LOC.XLOVID, LOC_Fallback.XLOVID),
    CTE.IsActive, 
    CTE.SortKey,
    CTE.Value1,
    CTE.Value3,
    CTE.LOV_Description,
    CTE.LOV_Expandable,
    CTE.LOV_ModulID, 
    CTE.LOV_NameValue3, 
    CTE.Action,
    CTE.TextDe,
    CTE.TextFR, 
    LOC.TextTID,
    ISNULL(LOC.System, LOC_Fallback.System)
  FROM LOVCodeCte CTE
    LEFT JOIN dbo.XLOVCode LOC ON LOC.LOVName = CTE.LOVName
                               AND LOC.Code = CTE.Code
    OUTER APPLY (SELECT TOP 1 * 
                 FROM dbo.XLOVCode 
                 WHERE LOVName = CTE.LOVName) LOC_Fallback

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT; -- needs to be done just after filling!
SET @EntriesIterator = 1; -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @LOVName = TMP.LOVName,
         @XLOVID = TMP.XLOVID,
         @Code = TMP.Code,
         @IsActive = TMP.IsActive,
         @SortKey = TMP.SortKey,
         @Value1 = TMP.Value1,
         @Value3 = TMP.Value3,
         @LOV_Description = TMP.LOV_Description,
         @LOV_Expandable = TMP.LOV_Expandable,
         @LOV_ModulID = TMP.LOV_ModulID, 
         @LOV_NameValue3 = TMP.LOV_NameValue3, 
         @Action = TMP.Action,
         @TextDE = TMP.TextDE,
         @TextFR = TMP.TextFR,
         @TextTID = TMP.TextTID,
         @System = TMP.SYSTEM
  FROM @LOVCodeText TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------

  -- Deutschen Text erstellen
  EXEC dbo.spXSetXLangText @TextTID, 1, @TextDE, NULL, NULL, NULL, NULL, @TextTID OUT

  -- Französischen Text erstellen
  EXEC dbo.spXSetXLangText @TextTID, 2, @TextFR, NULL, NULL, NULL, NULL, @TextTID OUT

  --Sicherstellen, dass LOV existiert
  IF(@XLOVID IS NULL)
  BEGIN
    INSERT INTO XLOV (LOVName, Description, SYSTEM, Expandable, ModulID, NameValue3)
    VALUES (@LOVName, @LOV_Description, 0, @LOV_Expandable, @LOV_ModulID, @LOV_NameValue3);
    
  PRINT('Werteliste:' + @LOVName + ' existierte noch nicht. Erfolgreich erstellt.');
  
    SELECT @XLOVID = SCOPE_IDENTITY(), @System = 0;
    UPDATE @LOVCodeText SET XLOVID = @XLOVID, System = @System WHERE LOVName = @LOVName;
  END;

  IF(NOT EXISTS (SELECT TOP 1 1 FROM XLOVCode WHERE LOVName = @LOVName AND Code = @Code))
  BEGIN
    INSERT INTO XLOVCode (LOVName, XLOVID, Code, Text, TextTID, SortKey, Value1, Value3, IsActive, System)
    VALUES (@LOVName, @XLOVID, @Code, @TextDE, @TextTID, @SortKey, @Value1, @Value3, @IsActive, @System)
    
    PRINT('Wert ' + CONVERT(VARCHAR, @Code) + ' in Werteliste:' + @LOVName + ' erstellt');
  END
  ELSE
  BEGIN
    --TextTID, SortKey, IsActive, Value1 + Value3 setzen
    UPDATE dbo.XLOVCode
      SET Text = @TextDE,
          IsActive = @IsActive,
          Sortkey = @SortKey,
          Value1 = @Value1,
          Value3 = @Value3,
          TextTID = @TextTID
    WHERE Code = @Code
      AND LOVName = @LOVName
      
    PRINT('Wert ' + CONVERT(VARCHAR, @Code) + ' in Werteliste:' + @LOVName + ' angepasst');
  END

  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

COMMIT
-- ROLLBACK

GO
-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

-------------------------------------------------------------------------------
-- Barauszahlungen
-------------------------------------------------------------------------------
INSERT [XClass]([ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension])
values ( N'CtlVmBarauszahlungErfolgt' ,  null , 5,  N'Vormundschaftliche Massnahme / Finanzen / Barauszahlungen / erfolgt' ,  N'KiSS4.Common.KissSearchUserControl' , 2110,  null ,  N'<Object>    <Property name="Size">1114, 869</Property>    <Property name="ActiveSQLQuery">      <Reference name="qryFbBarauszahlungAuftrag" />  </Property>  </Object>' , 0,  N'Klasse um die erfolgten Barauszahlungen zu handeln' ,  null ,  null ,  null ,  null , 0,  0 ,  null ,  null ,  null )
INSERT [XClass]([ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension])
values ( N'CtlVmBarauszahlungGeplant' ,  null , 5,  N'Vormundschaftliche Massnahme / Finanzen / Barauszahlungen / geplant' ,  N'KiSS4.Common.KissSearchUserControl' , 2110,  null ,  N'<Object>    <Property name="Size">1114, 869</Property>    <Property name="ActiveSQLQuery">      <Reference name="qryFbBarauszahlungAuftrag" />  </Property>  </Object>' , 0,  N'Klasse um die geplanten Barauszahlungen zu handeln' ,  null ,  null ,  null ,  null , 0,  0 ,  null ,  null ,  null )

INSERT [XModulTree]([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [NameTID], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active])
values (290034, 290006, 29, 4, 0,  N'Barauszahlungen' ,  null ,  N'CtlVmBarauszahlungGeplant' ,  null ,  null , 1,  N'UPDATE #Tree
  SET Zusatz = NULL,
      IconID = (SELECT CASE WHEN EXISTS (SELECT TOP 1 1
                                         FROM dbo.FbBarauszahlungAuftrag FBA WITH (READUNCOMMITTED)
                                           INNER JOIN #Tree              TRE ON TRE.FaLeistungID = FBA.FaLeistungID
                                         WHERE FaProzessCode = 2900
                                         
                                         UNION ALL
                                           
                                         SELECT TOP 1 1
                                         FROM dbo.FbBarauszahlungAuftrag            FBA WITH (READUNCOMMITTED)
                                           INNER JOIN dbo.FbBarauszahlungZyklus     FBZ WITH (READUNCOMMITTED) ON FBZ.FbBarauszahlungAuftragID = FBA.FbBarauszahlungAuftragID
                                           INNER JOIN dbo.FbBarauszahlungAusbezahlt FAA WITH (READUNCOMMITTED) ON FAA.FbBarauszahlungZyklusID = FBZ.FbBarauszahlungZyklusID
                                           INNER JOIN #Tree                         TRE WITH (READUNCOMMITTED) ON TRE.FaLeistungID = FBA.FaLeistungID
                                         WHERE FaProzessCode = 2900)
                            THEN 5058
                            ELSE 5059
                       END)
WHERE ModulTreeID = @ModulTreeID' ,  1 )
INSERT [XModulTree]([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [NameTID], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active])
values (290066, 290034, 29, 1, 0,  N'geplant' ,  null ,  N'CtlVmBarauszahlungGeplant' ,  null ,  null , 1,  N'UPDATE #Tree
  SET Zusatz = NULL,
      IconID = (SELECT CASE WHEN EXISTS (SELECT TOP 1 1
                                         FROM dbo.FbBarauszahlungAuftrag FBA WITH (READUNCOMMITTED)
                                           INNER JOIN #Tree              TRE ON TRE.FaLeistungID = FBA.FaLeistungID
                                         WHERE FaProzessCode = 2900)
                            THEN 5058
                            ELSE 5059
                       END)
WHERE ModulTreeID = @ModulTreeID' ,  1 )
INSERT [XModulTree]([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [NameTID], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active])
values (290067, 290034, 29, 2, 0,  N'erfolgt' ,  null ,  N'CtlVmBarauszahlungErfolgt' ,  null ,  null , 1,  N'UPDATE #Tree
  SET Zusatz = NULL,
      IconID = (SELECT CASE WHEN EXISTS (SELECT TOP 1 1
                                         FROM dbo.FbBarauszahlungAuftrag            FBA WITH (READUNCOMMITTED)
                                           INNER JOIN dbo.FbBarauszahlungZyklus     FBZ WITH (READUNCOMMITTED) ON FBZ.FbBarauszahlungAuftragID = FBA.FbBarauszahlungAuftragID
                                           INNER JOIN dbo.FbBarauszahlungAusbezahlt FAA WITH (READUNCOMMITTED) ON FAA.FbBarauszahlungZyklusID = FBZ.FbBarauszahlungZyklusID
                                           INNER JOIN #Tree                         TRE WITH (READUNCOMMITTED) ON TRE.FaLeistungID = FBA.FaLeistungID
                                         WHERE FaProzessCode = 2900)
                            THEN 5058
                            ELSE 5059
                       END)
WHERE ModulTreeID = @ModulTreeID' ,  1 )



-------------------------------------------------------------------------------
-- Finanzen
-------------------------------------------------------------------------------

INSERT [XModulTree]([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [NameTID], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active])
values (290015, 290000, 29, 7, 0,  N'Finanzen' , 9019,  null ,  null ,  null , 1,  N'UPDATE #Tree
  SET Zusatz = NULL,
      IconID = (SELECT CASE WHEN EXISTS (SELECT TOP 1 1
                                         FROM dbo.VmKlientenbudget VKL WITH (READUNCOMMITTED)
                                           INNER JOIN #Tree        TRE WITH (READUNCOMMITTED) ON TRE.FaLeistungID = VKL.FaLeistungID
                                         WHERE FaProzessCode = 2900
                                         
                                         UNION ALL
                                         SELECT TOP 1 1
                                         FROM dbo.VmBudget  VBU WITH (READUNCOMMITTED)
                                           INNER JOIN #Tree TRE WITH (READUNCOMMITTED) ON TRE.FaLeistungID = VBU.FaLeistungID
                                         WHERE FaProzessCode = 2900
                                           AND VBU.IsDeleted = 0
                                           
                                         UNION ALL
                                         SELECT TOP 1 1
                                         FROM dbo.VmSchulden SCH WITH (READUNCOMMITTED)
                                           INNER JOIN #Tree  TRE WITH (READUNCOMMITTED) ON TRE.FaLeistungID = SCH.FaLeistungID
                                         WHERE FaProzessCode = 2900)
                            THEN 5066
                            ELSE 5067
                       END)
WHERE ModulTreeID = @ModulTreeID' ,  1 )


-------------------------------------------------------------------------------
-- CtlVmBudget erstellen
-------------------------------------------------------------------------------
DECLARE @ClassName VARCHAR(50);
SET @ClassName = 'CtlVmBudget';

IF (NOT EXISTS(SELECT TOP 1 1
               FROM dbo.XModulTree WITH (READUNCOMMITTED)
               WHERE ModulTreeID_Parent IN (SELECT ModulTreeID
                                            FROM dbo.XModulTree WITH (READUNCOMMITTED)
                                            WHERE ModulTreeID_Parent = 290000
                                              AND Name = 'Finanzen')
                 AND ClassName IN (@ClassName, 'Kiss.UI.View.Vm.VmKlientenbudgetView.xaml')))
BEGIN
  IF (NOT EXISTS(SELECT TOP 1 1
                 FROM dbo.XClass WITH (READUNCOMMITTED)
                 WHERE ClassName = @ClassName))
  BEGIN
    INSERT INTO dbo.XClass(ClassName, ModulID, MaskName, BaseType, ClassCode)
      VALUES (@ClassName, 29, 'Vormundschaftliche Massnahme / Finanzen / Budget', 'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110);
  END;

  DECLARE @ModulTreeID INT;
  SELECT @ModulTreeID = MAX(ModulTreeID) + 1
  FROM dbo.XModulTree TRE WITH (READUNCOMMITTED)
  WHERE ModulID = 29
    AND ModulTreeID_Parent < 295000

  DECLARE @ModulTreeID_Parent INT;
  SELECT @ModulTreeID_Parent = ModulTreeID
  FROM dbo.XModulTree WITH (READUNCOMMITTED)
  WHERE ModulTreeID_Parent = 290000
    AND Name = 'Finanzen'
  
  INSERT INTO dbo.XModulTree(ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active)
    VALUES  (@ModulTreeID, @ModulTreeID_Parent, 29, 1, 0, 'Budget', @ClassName, NULL, 1, 'UPDATE #Tree
  SET Zusatz = NULL,
      IconID = (SELECT CASE WHEN EXISTS (SELECT TOP 1 1
                                         FROM dbo.VmBudget  VBU WITH (READUNCOMMITTED)
                                           INNER JOIN #Tree TRE WITH (READUNCOMMITTED) ON TRE.FaLeistungID = VBU.FaLeistungID
                                         WHERE FaProzessCode = 2900
                                           AND VBU.IsDeleted = 0)
                            THEN 5050
                            ELSE 5051
                       END)
WHERE ModulTreeID = @ModulTreeID', 1)
  PRINT ('Info: ' + @ClassName + ' wurde erstellt');
END;
GO

-------------------------------------------------------------------------------
-- CtlVmSchulden erstellen
-------------------------------------------------------------------------------
DECLARE @ClassName VARCHAR(50);
SET @ClassName = 'CtlVmSchulden';

IF (NOT EXISTS(SELECT TOP 1 1
               FROM dbo.XModulTree WITH (READUNCOMMITTED)
               WHERE ModulTreeID_Parent IN (SELECT ModulTreeID
                                            FROM dbo.XModulTree WITH (READUNCOMMITTED)
                                            WHERE ModulTreeID_Parent = 290000
                                              AND Name = 'Finanzen')
                 AND ClassName IN (@ClassName)))
BEGIN
  IF (NOT EXISTS(SELECT TOP 1 1
                 FROM dbo.XClass WITH (READUNCOMMITTED)
                 WHERE ClassName = @ClassName))
  BEGIN
    INSERT INTO dbo.XClass(ClassName, ModulID, MaskName, BaseType, ClassCode)
      VALUES (@ClassName, 29, 'Vormundschaftliche Massnahme / Finanzen / Schulden', 'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110);
  END;

  DECLARE @ModulTreeID INT;
  SELECT @ModulTreeID = MAX(ModulTreeID) + 1
  FROM dbo.XModulTree TRE WITH (READUNCOMMITTED)
  WHERE ModulID = 29
    AND ModulTreeID_Parent < 295000

  DECLARE @ModulTreeID_Parent INT;
  SELECT @ModulTreeID_Parent = ModulTreeID
  FROM dbo.XModulTree WITH (READUNCOMMITTED)
  WHERE ModulTreeID_Parent = 290000
    AND Name = 'Finanzen'
  
  INSERT INTO dbo.XModulTree(ModulTreeID, ModulTreeID_Parent, ModulID, SortKey, XIconID, Name, ClassName, sqlPreExecute, ModulTreeCode, sqlInsertTreeItem, Active)
    VALUES  (@ModulTreeID, @ModulTreeID_Parent, 29, 2, 0, 'Schulden', @ClassName, NULL, 1, 'UPDATE #Tree
  SET Zusatz = NULL,
      IconID = (SELECT CASE WHEN EXISTS (SELECT TOP 1 1
                                         FROM dbo.VmSchulden SCH WITH (READUNCOMMITTED)
                                           INNER JOIN #Tree  TRE WITH (READUNCOMMITTED) ON TRE.FaLeistungID = SCH.FaLeistungID
                                         WHERE FaProzessCode = 2900)
                            THEN 5052
                            ELSE 5053
                       END)
WHERE ModulTreeID = @ModulTreeID', 1)
  PRINT ('Info: ' + @ClassName + ' wurde erstellt');
END;
GO

/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to set Kurztext on the KesArtikel records
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

  DECLARE @Creator VARCHAR(50);
  SELECT @Creator = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()); 

  UPDATE KesArtikel SET BezeichnungKurz = 'das „Erforderliche“ vorkehren, insb. Zustimmung zu Rechtsgeschäft' WHERE CodeKokes = 'MAE010';
  UPDATE KesArtikel SET BezeichnungKurz = 'Auftrag an Drittperson' WHERE CodeKokes = 'MAE020';
  UPDATE KesArtikel SET BezeichnungKurz = 'Person/Stelle mit Einblick und Auskunft' WHERE CodeKokes = 'MAE030';
  UPDATE KesArtikel SET BezeichnungKurz = 'Begleitbeistandschaft' WHERE CodeKokes = 'MAE040';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vertretungsbeistandschaft - allgemein' WHERE CodeKokes = 'MAE050';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vertretungsbeistandschaft - Einschränkung der Handlungsfähigkeit' WHERE CodeKokes = 'MAE060';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vertretungsbeistandschaft - Vermögensverwaltung' WHERE CodeKokes = 'MAE070';
  UPDATE KesArtikel SET BezeichnungKurz = 'Entziehung Zugriff Vermögenswerte/Einkommensquellen' WHERE CodeKokes = 'MAE080';
  UPDATE KesArtikel SET BezeichnungKurz = 'Entziehung Verfügung über Grundstück' WHERE CodeKokes = 'MAE090';
  UPDATE KesArtikel SET BezeichnungKurz = 'Mitwirkungsbeistandschaft' WHERE CodeKokes = 'MAE100';
  UPDATE KesArtikel SET BezeichnungKurz = 'umfassende Beistandschaft - neu angeordnet' WHERE CodeKokes = 'MAE110';
  UPDATE KesArtikel SET BezeichnungKurz = 'Bestätigung Entmündigung nach Art. 369-372 aZGB' WHERE CodeKokes = 'MAE120';
  UPDATE KesArtikel SET BezeichnungKurz = 'bis 31.12.2012: Art. 369 aZGB; Beistandschaft - von Gesetzes wegen umgewandelt' WHERE CodeKokes = 'MAE130';
  UPDATE KesArtikel SET BezeichnungKurz = 'bis 31.12.2012: Art. 369 aZGB i.V.m. 385 Abs. 3 aZGB; Beistandschaft - von Gesetzes wegen umgewandelt' WHERE CodeKokes = 'MAE140';
  UPDATE KesArtikel SET BezeichnungKurz = 'bis 31.12.2012: Art. 370 aZGB;  Beistandschaft - von Gesetzes wegen umgewandelt, bis 31.12.2012: Art. 370 aZGB' WHERE CodeKokes = 'MAE150';
  UPDATE KesArtikel SET BezeichnungKurz = 'bis 31.12.2012: Art. 370 aZGB i.V.m. 385 Abs. 3 aZGB; Beistandschaft - von Gesetzes wegen umgewandelt, ' WHERE CodeKokes = 'MAE160';
  UPDATE KesArtikel SET BezeichnungKurz = 'bis 31.12.2012: Art. 371 aZGB; Beistandschaft - von Gesetzes wegen umgewandelt, ' WHERE CodeKokes = 'MAE170';
  UPDATE KesArtikel SET BezeichnungKurz = 'bis 31.12.2012: Art. 371 aZGB i.V.m. 385 Abs. 3 aZGB; Beistandschaft - von Gesetzes wegen umgewandelt' WHERE CodeKokes = 'MAE180';
  UPDATE KesArtikel SET BezeichnungKurz = 'bis 31.12.2012: Art. 372 aZGB; Beistandschaft - von Gesetzes wegen umgewandelt' WHERE CodeKokes = 'MAE190';
  UPDATE KesArtikel SET BezeichnungKurz = 'bis 31.12.2012: Art. 372 aZGB i.V.m. 385 Abs. 3 aZGB;  Beistandschaft - von Gesetzes wegen umgewandelt' WHERE CodeKokes = 'MAE200';
  UPDATE KesArtikel SET BezeichnungKurz = 'Interessenkollision des Beistands /der Beiständin - Ersatzbeistand/Ersatzbeiständin' WHERE CodeKokes = 'MAE210';
  UPDATE KesArtikel SET BezeichnungKurz = 'Interessenkollision - KESB regelt Angelegenheit selber' WHERE CodeKokes = 'MAE220';
  UPDATE KesArtikel SET BezeichnungKurz = 'Verfahrensbeistandschaft' WHERE CodeKokes = 'MAE230';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vertretungsbeistandschaft' WHERE CodeKokes = 'MAA010';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vermögensverwaltungsbeistandschaft' WHERE CodeKokes = 'MAA020';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft auf eigenes Begehren' WHERE CodeKokes = 'MAA030';
  UPDATE KesArtikel SET BezeichnungKurz = 'Mitwirkungsbeiratschaft' WHERE CodeKokes = 'MAA040';
  UPDATE KesArtikel SET BezeichnungKurz = 'Verwaltungsbeiratschaft' WHERE CodeKokes = 'MAA050';
  UPDATE KesArtikel SET BezeichnungKurz = 'Errichtung Vertretungsbeistandschaft' WHERE CodeKokes = 'MAK010';
  UPDATE KesArtikel SET BezeichnungKurz = 'Eigenes Handeln KESB' WHERE CodeKokes = 'MAK020';
  UPDATE KesArtikel SET BezeichnungKurz = 'Weisung oder Ermahnung' WHERE CodeKokes = 'MAK030';
  UPDATE KesArtikel SET BezeichnungKurz = 'Erziehungsaufsicht: mit Einblick und Auskunft' WHERE CodeKokes = 'MAK040';
  UPDATE KesArtikel SET BezeichnungKurz = 'Erziehungsbeistandschaft: Beratung' WHERE CodeKokes = 'MAK050';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft - Unterhalt' WHERE CodeKokes = 'MAK060';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft - persönlicher Verkehr' WHERE CodeKokes = 'MAK070';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft - medizinische Behandlung/Betreuung' WHERE CodeKokes = 'MAK080';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft - Schule, Berufslehre, etc.' WHERE CodeKokes = 'MAK090';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft - Anderes' WHERE CodeKokes = 'MAK100';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft - Unterhalt' WHERE CodeKokes = 'MAK110';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft - persönlicher Verkehr' WHERE CodeKokes = 'MAK120';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft - medizinische Behandlung/Betreuung' WHERE CodeKokes = 'MAK130';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft - Schule, Berufslehre, etc.' WHERE CodeKokes = 'MAK140';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft - Anderes' WHERE CodeKokes = 'MAK150';
  UPDATE KesArtikel SET BezeichnungKurz = 'Paternitätsbeistandschaft' WHERE CodeKokes = 'MAK160';
  UPDATE KesArtikel SET BezeichnungKurz = 'Wegnahme und Unterbringung von Amtes wegen' WHERE CodeKokes = 'MAK170';
  UPDATE KesArtikel SET BezeichnungKurz = 'Unterbringung von Amtes wegen in geschl. Einrichtung oder Klinik' WHERE CodeKokes = 'MAK180';
  UPDATE KesArtikel SET BezeichnungKurz = 'Unterbringung auf Begehren des Kindes oder der Eltern' WHERE CodeKokes = 'MAK190';
  UPDATE KesArtikel SET BezeichnungKurz = 'Unterbringung in geschl. Einrichtung oder Klinik' WHERE CodeKokes = 'MAK200';
  UPDATE KesArtikel SET BezeichnungKurz = 'Verbot der Rücknahme' WHERE CodeKokes = 'MAK210';
  UPDATE KesArtikel SET BezeichnungKurz = 'Verbot der Rücknahme - Unterbringung in geschl. Einrichtung oder Klinik' WHERE CodeKokes = 'MAK220';
  UPDATE KesArtikel SET BezeichnungKurz = 'Eltern sind ausserstande' WHERE CodeKokes = 'MAK230';
  UPDATE KesArtikel SET BezeichnungKurz = 'Eltern haben Pflichten verletzt' WHERE CodeKokes = 'MAK240';
  UPDATE KesArtikel SET BezeichnungKurz = 'Entziehung der elterlichen Sorge - auf Antrag der Eltern' WHERE CodeKokes = 'MAK250';
  UPDATE KesArtikel SET BezeichnungKurz = 'Einwilligung der Eltern in Adoption' WHERE CodeKokes = 'MAK260';
  UPDATE KesArtikel SET BezeichnungKurz = 'Verfahrensbeistandschaft' WHERE CodeKokes = 'MAK270';
  UPDATE KesArtikel SET BezeichnungKurz = 'Inventar oder Verwaltung Kindesvermögen' WHERE CodeKokes = 'MAK280';
  UPDATE KesArtikel SET BezeichnungKurz = 'Kindesvermögen: Weisung Verwaltung etc.' WHERE CodeKokes = 'MAK290';
  UPDATE KesArtikel SET BezeichnungKurz = 'Kindesvermögensverwaltungsbeistandschaft, Entziehung der Verwaltung' WHERE CodeKokes = 'MAK300';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vormundschaft bei Kind ohne elterliche Sorge' WHERE CodeKokes = 'MAK310';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vertretungsbeistandschaft für das ungeborene Kind - Interessenwahrung' WHERE CodeKokes = 'MAK320';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beistandschaft' WHERE CodeKokes = 'MAK330';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vormundschaft' WHERE CodeKokes = 'MAK340';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vorsorgeauftrag - validiert/teilweise validiert' WHERE CodeKokes = 'NMGE010';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vorsorgeauftrag - nicht validiert' WHERE CodeKokes = 'NMGE020';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vorsorgeauftrag - Auslegung, Ergänzung' WHERE CodeKokes = 'NMGE030';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vorsorgeauftrag - Entschädigung' WHERE CodeKokes = 'NMGE040';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vorsorgeauftrag - Einschreiten: Weisung, Inventaranordnung, Rechnungslegung, Berichterstattung etc.' WHERE CodeKokes = 'NMGE050';
  UPDATE KesArtikel SET BezeichnungKurz = 'Patientenverfügung - Einschreiten: Weisung, Berichterstattung, Entziehung von Befugnissen, etc.' WHERE CodeKokes = 'NMGE060';
  UPDATE KesArtikel SET BezeichnungKurz = 'Zustimmung zu Vermögensverwaltungshandlung -gesetzliche Vertretung durch Ehegatte/eingetragene Partner/in' WHERE CodeKokes = 'NMGE070';
  UPDATE KesArtikel SET BezeichnungKurz = 'Einschreiten: Ausstellen Urkunde etc. - gesetzliche Vertretung durch Ehegatte/eingetragene Partner/in' WHERE CodeKokes = 'NMGE080';
  UPDATE KesArtikel SET BezeichnungKurz = 'Med.: Bestimmung der vertretungsberechtigten Person' WHERE CodeKokes = 'NMGE090';
  UPDATE KesArtikel SET BezeichnungKurz = 'Betreuung: Bestimmung der vertretungsberechtigten Person' WHERE CodeKokes = 'NMGE100';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beurteilung Beschwerde gegen bewegungseinschränkende Massnahme' WHERE CodeKokes = 'NMGE110';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beschwerde gegen Beistand oder Dritte' WHERE CodeKokes = 'NMGE120';
  UPDATE KesArtikel SET BezeichnungKurz = 'Fürsorgerische Unterbringung durch KESB' WHERE CodeKokes = 'NMGE130';
  UPDATE KesArtikel SET BezeichnungKurz = 'Entlassung durch KESB - Fürsorgerische Unterbringung' WHERE CodeKokes = 'NMGE140';
  UPDATE KesArtikel SET BezeichnungKurz = 'Zurückbehaltung freiwillig Eingetretener - Fürsorgerische Unterbringung' WHERE CodeKokes = 'NMGE150';
  UPDATE KesArtikel SET BezeichnungKurz = 'Verlängerung ärztliche Unterbringung - Fürsorgerische Unterbringung' WHERE CodeKokes = 'NMGE160';
  UPDATE KesArtikel SET BezeichnungKurz = '6 Monate nach Unterbringung - Fürsorgerische Unterbringung' WHERE CodeKokes = 'NMGE170';
  UPDATE KesArtikel SET BezeichnungKurz = '12 Monate nach Unterbringung - Fürsorgerische Unterbringung' WHERE CodeKokes = 'NMGE180';
  UPDATE KesArtikel SET BezeichnungKurz = '24 Monate, 36 Monate, etc. nach Unterbringung - Fürsorgerische Unterbringung' WHERE CodeKokes = 'NMGE190';
  UPDATE KesArtikel SET BezeichnungKurz = 'Nachbetreuung' WHERE CodeKokes = 'NMGE200';
  UPDATE KesArtikel SET BezeichnungKurz = 'ambulante Massnahmen' WHERE CodeKokes = 'NMGE210';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vernehmlassung' WHERE CodeKokes = 'NMGE220';
  UPDATE KesArtikel SET BezeichnungKurz = 'Wiedererwägung' WHERE CodeKokes = 'NMGE230';
  UPDATE KesArtikel SET BezeichnungKurz = 'Auskunft über Massnahmen' WHERE CodeKokes = 'NMGE240';
  UPDATE KesArtikel SET BezeichnungKurz = 'Zuteilung gemeinsame elterliche Sorge' WHERE CodeKokes = 'NMGK010';
  UPDATE KesArtikel SET BezeichnungKurz = 'Aufhebung gemeinsame elterliche Sorge an einen Elternteil' WHERE CodeKokes = 'NMGK020';
  UPDATE KesArtikel SET BezeichnungKurz = 'Übertragung elterliche Sorge an anderen Elternteil' WHERE CodeKokes = 'NMGK030';
  UPDATE KesArtikel SET BezeichnungKurz = 'Neuregelung des Unterhalts bei Einigkeit' WHERE CodeKokes = 'NMGK040';
  UPDATE KesArtikel SET BezeichnungKurz = 'Neuregelung persönlicher Verkehr bei geschiedenen Eltern' WHERE CodeKokes = 'NMGK050';
  UPDATE KesArtikel SET BezeichnungKurz = 'Zustimmung zur Adoption des bevormundeten Kindes' WHERE CodeKokes = 'NMGK060';
  UPDATE KesArtikel SET BezeichnungKurz = 'Entgegennahme Zustimmung der Eltern zur Adoption' WHERE CodeKokes = 'NMGK070';
  UPDATE KesArtikel SET BezeichnungKurz = 'Absehen von Zustimmung der Eltern zur Adoption' WHERE CodeKokes = 'NMGK080';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vermittlung von Kindern zur späteren Adoption' WHERE CodeKokes = 'NMGK090';
  UPDATE KesArtikel SET BezeichnungKurz = 'Weisung / Ermahnung betreffend persönlicher Verkehr' WHERE CodeKokes = 'NMGK100';
  UPDATE KesArtikel SET BezeichnungKurz = 'Entzug / Beschränkung persönlicher Verkehr' WHERE CodeKokes = 'NMGK110';
  UPDATE KesArtikel SET BezeichnungKurz = 'Anordnung betreffend persönlicher Verkehr' WHERE CodeKokes = 'NMGK120';
  UPDATE KesArtikel SET BezeichnungKurz = 'Entzug / Beschränkung auf Information und Auskunft' WHERE CodeKokes = 'NMGK130';
  UPDATE KesArtikel SET BezeichnungKurz = 'Genehmigung Abschluss eines Unterhaltsvertrags' WHERE CodeKokes = 'NMGK140';
  UPDATE KesArtikel SET BezeichnungKurz = 'Genehmigung Abänderung eines Unterhaltsvertrags' WHERE CodeKokes = 'NMGK150';
  UPDATE KesArtikel SET BezeichnungKurz = 'Genehmigung eines Unterhaltsabfindungsvertrags' WHERE CodeKokes = 'NMGK160';
  UPDATE KesArtikel SET BezeichnungKurz = 'Übertragung elterliche Sorge an Vater' WHERE CodeKokes = 'NMGK170';
  UPDATE KesArtikel SET BezeichnungKurz = 'Errichtung Vormundschaft' WHERE CodeKokes = 'NMGK180';
  UPDATE KesArtikel SET BezeichnungKurz = 'Übertragung elterliche Sorge - Mutter > Vater' WHERE CodeKokes = 'NMGK190';
  UPDATE KesArtikel SET BezeichnungKurz = 'Übertragung elterliche Sorge - Vater > Mutter' WHERE CodeKokes = 'NMGK200';
  UPDATE KesArtikel SET BezeichnungKurz = 'Übertragung gemeinsame elterliche Sorge' WHERE CodeKokes = 'NMGK210';
  UPDATE KesArtikel SET BezeichnungKurz = 'Aufhebung gemeinsame Sorge - Vater' WHERE CodeKokes = 'NMGK220';
  UPDATE KesArtikel SET BezeichnungKurz = 'Aufhebung gemeinsame Sorge - Mutter' WHERE CodeKokes = 'NMGK230';
  UPDATE KesArtikel SET BezeichnungKurz = 'Aufhebung gemeinsame Sorge - Vormund/in' WHERE CodeKokes = 'NMGK240';
  UPDATE KesArtikel SET BezeichnungKurz = 'Aufforderung der Eltern zu Mediationsversuch' WHERE CodeKokes = 'NMGK250';
  UPDATE KesArtikel SET BezeichnungKurz = 'Genehmigung des Kindesvermögensinventars' WHERE CodeKokes = 'NMGK260';
  UPDATE KesArtikel SET BezeichnungKurz = 'Bewilligung Anzehrung des Kindesvermögens' WHERE CodeKokes = 'NMGK270';
  UPDATE KesArtikel SET BezeichnungKurz = 'Beschwerde gegen Beistand' WHERE CodeKokes = 'NMGK280';
  UPDATE KesArtikel SET BezeichnungKurz = 'Vernehmlassung' WHERE CodeKokes = 'NMGK290';
  UPDATE KesArtikel SET BezeichnungKurz = 'Wiedererwägung' WHERE CodeKokes = 'NMGK300';
  UPDATE KesArtikel SET BezeichnungKurz = 'geeignete Massnahme' WHERE CodeKokes = 'MAK350';
  UPDATE KesArtikel SET BezeichnungKurz = 'Feststellung Vaterschaft' WHERE CodeKokes = 'MAK360';
  UPDATE KesArtikel SET BezeichnungKurz = 'Festellung Vaterschaft - Beschränkung elterliche Sorge' WHERE CodeKokes = 'MAK370';
  UPDATE KesArtikel SET BezeichnungKurz = 'Infolge Aufhebung Zuteilung elterliche Sorge' WHERE CodeKokes = 'NMGK310';
  UPDATE KesArtikel SET BezeichnungKurz = 'Übertragung elterliche Sorge infolge Tod' WHERE CodeKokes = 'NMGK320';
  UPDATE KesArtikel SET BezeichnungKurz = 'Errichtung Vormundschaft infolge Tod' WHERE CodeKokes = 'NMGK330';
  UPDATE KesArtikel SET BezeichnungKurz = 'Errichtung Vormundschaft in eherechtlichen Verfahren' WHERE CodeKokes = 'NMGK340';
  UPDATE KesArtikel SET BezeichnungKurz = 'Erziehungsgutschrift geregelt - Erklärung bei der KESB' WHERE CodeKokes = 'NMGK350';
  UPDATE KesArtikel SET BezeichnungKurz = 'Erziehungsgutschrift pendent - Erklärung bei der KESB' WHERE CodeKokes = 'NMGK360';
  UPDATE KesArtikel SET BezeichnungKurz = 'Erziehungsgutschrift geregelt - Erklärung beim Zivilstandsamt' WHERE CodeKokes = 'NMGK370';
  UPDATE KesArtikel SET BezeichnungKurz = 'Erziehungsgutschrift pendent - Erklärung beim Zivilstandsamt' WHERE CodeKokes = 'NMGK380';
  UPDATE KesArtikel SET BezeichnungKurz = 'Regelung Erziehungsgutschrift' WHERE CodeKokes = 'NMGK390';
  UPDATE KesArtikel SET BezeichnungKurz = 'Ablehnung eines Antrags auf gemeinsame elterliche Sorge' WHERE CodeKokes = 'NMGK400';
  UPDATE KesArtikel SET BezeichnungKurz = 'Entscheid KESB - ohne Regelung von Nebenpunkten' WHERE CodeKokes = 'NMGK410';
  UPDATE KesArtikel SET BezeichnungKurz = 'Entscheid KESB - mit Regelung von Nebenpunkten' WHERE CodeKokes = 'NMGK420';
  UPDATE KesArtikel SET BezeichnungKurz = 'minderjährige Mutter – Zuteilung elterliche Sorge an Vater' WHERE CodeKokes = 'NMGK430';
  UPDATE KesArtikel SET BezeichnungKurz = 'minderjährige Mutter – Errichtung Vormundschaft' WHERE CodeKokes = 'NMGK440';
  UPDATE KesArtikel SET BezeichnungKurz = 'Mutter mit Beistandschaft – Zuteilung elterliche Sorge an Vater' WHERE CodeKokes = 'NMGK450';
  UPDATE KesArtikel SET BezeichnungKurz = 'Mutter mit Beistandschaft – Errichtung Vormundschaft' WHERE CodeKokes = 'NMGK460';
  UPDATE KesArtikel SET BezeichnungKurz = 'Aufhebung gemeinsames Sorgerecht' WHERE CodeKokes = 'NMGK470';
  UPDATE KesArtikel SET BezeichnungKurz = 'Aufhebung alleiniges Sorgerecht' WHERE CodeKokes = 'NMGK480';
  UPDATE KesArtikel SET BezeichnungKurz = 'Übertragung alleiniges Sorgerecht' WHERE CodeKokes = 'NMGK490';
  UPDATE KesArtikel SET BezeichnungKurz = 'Nachträgliche Regelung strittiger Nebenpunkte' WHERE CodeKokes = 'NMGK500';
  UPDATE KesArtikel SET BezeichnungKurz = 'neuer Aufenthaltsort des Kindes - Zustimmung' WHERE CodeKokes = 'NMGK510';
  UPDATE KesArtikel SET BezeichnungKurz = 'neuer Aufenthaltsort des Kindes – Neuregelung ' WHERE CodeKokes = 'NMGK520';
  UPDATE KesArtikel SET BezeichnungKurz = 'Genehmigung Neuregelung Obhut' WHERE CodeKokes = 'NMGK530';
  UPDATE KesArtikel SET BezeichnungKurz = 'Neuregelung Betreuungsanteile' WHERE CodeKokes = 'NMGK540';


--LOV FbBarauszahlungPeriodizitaet nicht vorhanden
BEGIN TRAN 
if (not exists (select top 1 1 from xlov where [LOVName] ='FbBarauszahlungPeriodizitaet'))
begin 
INSERT INTO [XLOV] ( [LOVName] , [Description] , [System] , [Expandable] , [ModulID] , [LastUpdated] , [Translatable] , [NameValue1] , [NameValue2] , [NameValue3] ) VALUES ( N'FbBarauszahlungPeriodizitaet', N'Periodizität von geplanten Barauszahlungen', 1, 1, 14, NULL, 1, NULL, NULL, NULL) 
END
DECLARE @xlovid int 
select @xlovid=(select xlovid from xlov where [LOVName] ='FbBarauszahlungPeriodizitaet')
if (not exists (select top 1 1 from [XLOVCode] where [LOVName] ='FbBarauszahlungPeriodizitaet')) 
begin 
INSERT INTO [XLOVCode] ( [XLOVID] , [LOVName] , [Code] , [Text] , [SortKey] , [ShortText] , [BFSCode] , [Value1] , [Value2] , [Value3] , [Description] , [LOVCodeName] , [IsActive] , [System] ) VALUES ( @xlovid, N'FbBarauszahlungPeriodizitaet', 1, N'Jährlich', 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1) 
INSERT INTO [XLOVCode] ( [XLOVID] , [LOVName] , [Code] , [Text] , [SortKey] , [ShortText] , [BFSCode] , [Value1] , [Value2] , [Value3] , [Description] , [LOVCodeName] , [IsActive] , [System] ) VALUES ( @xlovid, N'FbBarauszahlungPeriodizitaet', 2, N'Halbjährlich', 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1) 
INSERT INTO [XLOVCode] ( [XLOVID] , [LOVName] , [Code] , [Text] , [SortKey] , [ShortText] , [BFSCode] , [Value1] , [Value2] , [Value3] , [Description] , [LOVCodeName] , [IsActive] , [System] ) VALUES ( @xlovid, N'FbBarauszahlungPeriodizitaet', 3, N'Vierteljährlich', 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1) 
INSERT INTO [XLOVCode] ( [XLOVID] , [LOVName] , [Code] , [Text] , [SortKey] , [ShortText] , [BFSCode] , [Value1] , [Value2] , [Value3] , [Description] , [LOVCodeName] , [IsActive] , [System] ) VALUES ( @xlovid, N'FbBarauszahlungPeriodizitaet', 4, N'Zweimonatlich', 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1) 
INSERT INTO [XLOVCode] ( [XLOVID] , [LOVName] , [Code] , [Text] , [SortKey] , [ShortText] , [BFSCode] , [Value1] , [Value2] , [Value3] , [Description] , [LOVCodeName] , [IsActive] , [System] ) VALUES ( @xlovid, N'FbBarauszahlungPeriodizitaet', 5, N'Monatlich', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1) 
INSERT INTO [XLOVCode] ( [XLOVID] , [LOVName] , [Code] , [Text] , [SortKey] , [ShortText] , [BFSCode] , [Value1] , [Value2] , [Value3] , [Description] , [LOVCodeName] , [IsActive] , [System] ) VALUES ( @xlovid, N'FbBarauszahlungPeriodizitaet', 6, N'2x pro Monat', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1) 
INSERT INTO [XLOVCode] ( [XLOVID] , [LOVName] , [Code] , [Text] , [SortKey] , [ShortText] , [BFSCode] , [Value1] , [Value2] , [Value3] , [Description] , [LOVCodeName] , [IsActive] , [System] ) VALUES ( @xlovid, N'FbBarauszahlungPeriodizitaet', 7, N'14 täglich', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1) 
INSERT INTO [XLOVCode] ( [XLOVID] , [LOVName] , [Code] , [Text] , [SortKey] , [ShortText] , [BFSCode] , [Value1] , [Value2] , [Value3] , [Description] , [LOVCodeName] , [IsActive] , [System] ) VALUES ( @xlovid, N'FbBarauszahlungPeriodizitaet', 8, N'Wöchentlich', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1) 
INSERT INTO [XLOVCode] ( [XLOVID] , [LOVName] , [Code] , [Text] , [SortKey] , [ShortText] , [BFSCode] , [Value1] , [Value2] , [Value3] , [Description] , [LOVCodeName] , [IsActive] , [System] ) VALUES ( @xlovid, N'FbBarauszahlungPeriodizitaet', 9, N'Einmalig', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1) 
END

COMMIT
-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

-- Xonfig aktualisieren 
UPDATE XConfig SET originalValueInt = 1000, ValueInt = 1000 
where keypath = 'System\Fibu\Barauszahlung\HabenKontoNr'
UPDATE XConfig SET originalValueInt = 3000, ValueInt = 3000 
where keypath = 'System\Fibu\Barauszahlung\SollKontoNr' 
-------------------------------------------------------------------------------
-- VM Kasse
-------------------------------------------------------------------------------
INSERT [XClass]([ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension])
values ( N'FrmVmKasse' ,  null , 5,  N'Anwendung / VM - Kasse' ,  N'KiSS4.Common.KissSearchForm' , 3110, 8721,  N'<Object>    <Property name="Size">1114, 869</Property>  </Object>' , 0,  N'Klasse um die VM-Kasse zu handeln' ,  null ,  null ,  null ,  null , 0,  0 ,  null ,  null ,  null )

INSERT [XMenuItem]([ParentMenuItemID], [ControlName], [BeginMenuGroup], [Enabled], [Visible], [Caption], [MenuTID], [ItemShortcutCtrl], [ItemShortcutShift], [ItemShortcutAlt], [ItemShortcutKey], [ImageIndex], [ImageIndexDisabled], [SortKey], [ClassName], [ShowInToolbar], [BeginToolbarGroup], [ToolbarSortKey], [System], [HideLockedItems], [Description], [OnlyBIAGAdminVisible])
values (4,  null ,  1 ,  1 ,  1 ,  N'KES - Kasse' ,  null ,  0 ,  0 ,  0 ,  null , 219, -1, 20,  N'FrmVmKasse' ,  0 ,  0 ,  null ,  0 ,  0 ,  null ,  0 )

-------------------------------------------------------------------------------
--FbBelegNr - Barauszahlung hinzufügen
-------------------------------------------------------------------------------
INSERT [XLOVCode]([XLOVID], [LOVName], [Code], [Text], [TextTID], [SortKey], [ShortText], [ShortTextTID], [BFSCode], [Value1], [Value1TID], [Value2], [Value2TID], [Value3], [Value3TID], [Description], [LOVCodeName], [IsActive], [System])
values (98,  N'FbBelegNr' , 5,  N'Barauszahlung' ,  null , 5,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  null ,  1 ,  1 )

SET NOCOUNT OFF;
GO
