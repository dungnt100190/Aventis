/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to migrate VmPriMa to BaInstitution
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1
-------------------------------------------------------------------------------
IF (EXISTS(SELECT TOP 1 1
           FROM sys.tables WITH (READUNCOMMITTED)
           WHERE [name] = '_Mig_VmPriMa_To_BaInstitution'))
BEGIN
  PRINT ('Warning: Tabelle _Mig_VmPriMa_To_BaInstitution ist bereits vorhanden');
END
ELSE 
BEGIN
  CREATE TABLE _Mig_VmPriMa_To_BaInstitution(
    ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
    BaInstitutionID INT,
    VmPriMaID INT,
    Created DATETIME NOT NULL
  );

  ALTER TABLE [dbo].[_Mig_VmPriMa_To_BaInstitution] ADD  CONSTRAINT [DF__Mig_VmPriMa_To_BaInstitution_Created]  DEFAULT (GETDATE()) FOR [Created]
END;

DECLARE @BaInstitutionTypID INT;
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


DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @VmPriMaID INT;

INSERT INTO _Mig_VmPriMa_To_BaInstitution (VmPriMaID)
  SELECT PRM.VmPriMaID 
  FROM dbo.VmPriMa PRM;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @VmPriMaID = TMP.VmPriMaID
  FROM _Mig_VmPriMa_To_BaInstitution TMP
  WHERE TMP.ID = @EntriesIterator;

  PRINT (CONVERT(VARCHAR(MAX), @EntriesIterator) + ': VmPriMaID = ' + CONVERT(VARCHAR(MAX), @VmPriMaID));

  -- Datensätze von VmPriMa in BaInstitution schreiben 
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
      LEFT JOIN _Mig_VmPriMa_To_BaInstitution VPR ON VPR.VmPriMaID = PRM.VmPriMaID
      LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.VmPriMaID = PRM.VmPriMaID
    WHERE PRM.VmPriMaID = @VmPriMaID;
   
  UPDATE _Mig_VmPriMa_To_BaInstitution
    SET BaInstitutionID = SCOPE_IDENTITY()
  WHERE VmPriMaID = @VmPriMaID;
    
  PRINT ('    BaInstitutionID = ' + CONVERT(VARCHAR(MAX), SCOPE_IDENTITY()));

  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

PRINT ('Info: ' + CONVERT(VARCHAR(MAX), @EntriesIterator) + ' VmPriMas wurden in BaInstitution migriert');


-------------------------------------------------------------------------------
-- Datensätze von BaAdresse von VmPriMaID nach BaInstitutionID umschreiben
-- und einen Historyeintrag machen
-------------------------------------------------------------------------------
INSERT INTO dbo.HistoryVersion (AppUser) VALUES ('kiss_sys');
         
UPDATE ADR
  SET ADR.BaInstitutionID = VPR.BaInstitutionID,
      ADR.VmPriMaID = NULL
FROM dbo.BaAdresse ADR
  INNER JOIN _Mig_VmPriMa_To_BaInstitution VPR ON VPR.VmPriMaID = ADR.VmPriMaID;

PRINT ('Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Adressen wurden umgehängt');

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
  FROM _Mig_VmPriMa_To_BaInstitution VPR

PRINT ('Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' BaInstitution_BaInstitutionTyp wurden erstellt');


GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO