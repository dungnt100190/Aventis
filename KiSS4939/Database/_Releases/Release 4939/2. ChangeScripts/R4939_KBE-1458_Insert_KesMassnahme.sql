/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to migrate KesMassnahmeBSS to KesMassnahme and other tables
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO



-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @MigrationDate DATETIME = GETDATE();
PRINT ('Info: @MigrationDate = ' + CONVERT(VARCHAR(10), @MigrationDate, 121));

DECLARE @Creator VARCHAR(50);
SET @Creator = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @FaLeistungID INT;
DECLARE @MassnahmeVon DATETIME;
DECLARE @MassnahmeBis DATETIME;
DECLARE @IsDeleted BIT;
DECLARE @KesMassnahmeTypCode INT;
DECLARE @KesMassnahmeBSSIDs VARCHAR(MAX);
DECLARE @KesAufgabenbereichCodes VARCHAR(MAX);
DECLARE @KesIndikationCodes VARCHAR(MAX);

DECLARE @Mig_KesMassnahmeBSS_Merge TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  Mig_KesMassnahmeBSS_MergeID INT NOT NULL,
  FaLeistungID INT NOT NULL,
  MassnahmeVon DATETIME NOT NULL,
  MassnahmeBis DATETIME NOT NULL,
  IsDeleted BIT NOT NULL,
  KesMassnahmeTypCode INT NOT NULL,
  KesArtikelIDs VARCHAR(MAX) NULL,
  KesMassnahmeBSSIDs VARCHAR(MAX) NOT NULL,
  KesAufgabenbereichCodes VARCHAR(MAX) NULL,
  KesIndikationCodes VARCHAR(MAX) NULL
);



-- Tabelle _Mig_KesMassnahmeBSS erstellen
IF (NOT EXISTS(SELECT TOP 1 1
               FROM sys.tables
               WHERE name = '_Mig_KesMassnahmeBSS'))
BEGIN
  CREATE TABLE dbo._Mig_KesMassnahmeBSS 
  (
    ID INT IDENTITY(1, 1) NOT NULL,
    KesMassnahmeBSSID INT NOT NULL,
    KesMassnahmeID INT NULL,
    KesDokumentID INT NULL,
    Step INT NULL,
    Bemerkung VARCHAR(200) NOT NULL,
    MigrationDate DATETIME NOT NULL 
  );
  ALTER TABLE dbo._Mig_KesMassnahmeBSS ADD CONSTRAINT DF__Mig_KesMassnahmeBSS_MigrationDate DEFAULT GETDATE() FOR MigrationDate;
  PRINT ('Info: Tabelle _Mig_KesMassnahmeBSS wurde erstellt');
END
ELSE
BEGIN
  PRINT ('Warning: Tabelle _Mig_KesMassnahmeBSS existiert bereits');
END;


-- Tabelle _Mig_KesMassnahmeBSS_Group erstellen
IF (NOT EXISTS(SELECT TOP 1 1
               FROM sys.tables
               WHERE name = '_Mig_KesMassnahmeBSS_Group'))
BEGIN
  CREATE TABLE dbo._Mig_KesMassnahmeBSS_Group 
  (
    ID INT IDENTITY(1, 1) NOT NULL,
    FaLeistungID INT NOT NULL,
    MassnahmeVon DATETIME NOT NULL,
    MassnahmeBis DATETIME NOT NULL,
    IsDeleted BIT NOT NULL,
    KesMassnahmeTypCode INT NOT NULL,
    KesArtikelIDs VARCHAR(MAX) NULL,
    KesMassnahmeBSSIDs VARCHAR(MAX) NOT NULL,
    KesAufgabenbereichCodes VARCHAR(MAX) NULL,
    KesIndikationCodes VARCHAR(MAX) NULL,
    AnzahlGroup INT NULL,
    MigrationDate DATETIME NOT NULL 
  );
  ALTER TABLE dbo._Mig_KesMassnahmeBSS_Group ADD CONSTRAINT DF__Mig_KesMassnahmeBSS_Group_MigrationDate DEFAULT GETDATE() FOR MigrationDate;
  PRINT ('Info: Tabelle _Mig_KesMassnahmeBSS_Group wurde erstellt');
END
ELSE
BEGIN
  PRINT ('Warning: Tabelle _Mig_KesMassnahmeBSS_Group existiert bereits');
END;



-- Tabelle _Mig_KesMassnahmeBSS_Merge erstellen
IF (NOT EXISTS(SELECT TOP 1 1
               FROM sys.tables
               WHERE name = '_Mig_KesMassnahmeBSS_Merge'))
BEGIN
  CREATE TABLE dbo._Mig_KesMassnahmeBSS_Merge
  (
    ID INT IDENTITY(1, 1) NOT NULL,
    FaLeistungID INT NOT NULL,
    MassnahmeVon DATETIME NOT NULL,
    MassnahmeBis DATETIME NOT NULL,
    IsDeleted BIT NOT NULL,
    KesMassnahmeTypCode INT NOT NULL,
    KesArtikelIDs VARCHAR(MAX) NULL,
    KesMassnahmeBSSIDs VARCHAR(MAX) NOT NULL,
    KesAufgabenbereichCodes VARCHAR(MAX) NULL,
    KesIndikationCodes VARCHAR(MAX) NULL,
    AnzahlMerge INT NULL,
    MigrationDate DATETIME NOT NULL 
  );
  ALTER TABLE dbo._Mig_KesMassnahmeBSS_Merge ADD CONSTRAINT DF__Mig_KesMassnahmeBSS_Merge_MigrationDate DEFAULT GETDATE() FOR MigrationDate;
  PRINT ('Info: Tabelle _Mig_KesMassnahmeBSS_Merge wurde erstellt');
END
ELSE
BEGIN
  PRINT ('Warning: Tabelle _Mig_KesMassnahmeBSS_Merge existiert bereits');
END;



-------------------------------------------------------------------------------
-- step 1: Migration von "Nicht massnahmegebundene Unterbringung"
-------------------------------------------------------------------------------
PRINT ('Info: 1. Migration von "Nicht massnahmegebundene Unterbringung"');

MERGE dbo.KesDokument DST
USING
(
  SELECT 
    -- für die Logs
    MAS.KesMassnahmeBSSID,
    Step                     = 1,
    Bemerkung                = 'Nicht massnahmegebundene Unterbringung',

    -- für die Migration
    KesAuftragID             = NULL, 
    FaLeistungID             = MAS.FaLeistungID, 
    UserID                   = MAS.UserID, 
    BaPersonID_Adressat      = NULL, 
    BaInstitutionID_Adressat = NULL, 
    Stichwort                = ART.Artikel + IsNull('.' + ART.Absatz, '') + IsNull('.' + ART.Ziffer, '') + ' ' + ART.Gesetz + ' ' + ART.Bezeichnung + ' / ' + ISNULL(MAS.Bemerkung, ''), 
    KesDokumentResultatCode  = NULL, 
    KesDokumentArtCode       = NULL, 
    XDocumentID_Dokument     = MAS.KESBDocumentID, 
    XDocumentID_Versand      = NULL, 
    KesDokumentTypCode       = 2, -- Massnahmenführung Dokument
    Creator                  = MAS.Creator, 
    Created                  = MAS.Created, 
    Modifier                 = MAS.Modifier, 
    Modified                 = MAS.Modified,
    IsDeleted                = MAS.IsDeleted
  FROM dbo.KesMassnahmeBSS MAS WITH (READUNCOMMITTED)
    INNER JOIN dbo.KesArtikel ART WITH (READUNCOMMITTED) ON ART.KesArtikelID = ISNULL(MAS.KesArtikelID_MassnahmegebundeneGeschaefte, MAS.KesArtikelID_NichtMassnahmegebundeneGeschaefte)
  WHERE ART.Artikel IN ('426', '427', '429', '431', '437')
) SRC ON 1=0 -- 1=0 (false) damit immer ein Insert gemacht wird
WHEN NOT MATCHED THEN 
  INSERT (KesAuftragID, FaLeistungID, UserID, BaPersonID_Adressat, BaInstitutionID_Adressat, Stichwort, KesDokumentResultatCode, KesDokumentArtCode, XDocumentID_Dokument, XDocumentID_Versand, KesDokumentTypCode, Creator, Created, Modifier, Modified, IsDeleted)
    VALUES (SRC.KesAuftragID, SRC.FaLeistungID, SRC.UserID, SRC.BaPersonID_Adressat, SRC.BaInstitutionID_Adressat, SRC.Stichwort, SRC.KesDokumentResultatCode, SRC.KesDokumentArtCode, SRC.XDocumentID_Dokument, SRC.XDocumentID_Versand, SRC.KesDokumentTypCode, SRC.Creator, SRC.Created, SRC.Modifier, SRC.Modified, SRC.IsDeleted)
OUTPUT SRC.KesMassnahmeBSSID,
       INSERTED.KesDokumentID,
       SRC.Step,
       SRC.Bemerkung
  INTO dbo._Mig_KesMassnahmeBSS (KesMassnahmeBSSID, KesDokumentID, Step, Bemerkung)
;

PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' KesMassnahmeBSS wurden in KesDokument migriert.');
PRINT ('');

-------------------------------------------------------------------------------
-- step 2: Migration von Massnahmen
-------------------------------------------------------------------------------
PRINT ('Info: 2. Migration von Massnahmen');

IF (EXISTS(SELECT TOP 1 1
           FROM dbo.KesMassnahme WITH (READUNCOMMITTED)
           WHERE 1=1))
BEGIN
  PRINT ('Warning: es sind bereits Daten in KesMassnahme vorhanden');
END;

-- Start "Päckli" machen
;WITH MassnahmeCTE AS 
(
  SELECT MassnahmeVon = ISNULL(NULLIF(COALESCE(MAS.AenderungVom, MAS.UebernahmeVom, MAS.ErrichtungVom, '17530102'), '17530101'), '17530102'), -- Das kleinste DatumVon darf nicht kleiner als 17530102 sein weil wir weiter unten ein DATEADD -1 machen
         MassnahmeBis = ISNULL(NULLIF(COALESCE(MAS.Beistandswechsel, MAS.UebertragungVom, MAS.AufhebungVom, MAS.BerichtsgenehmigungVom, '99991230'), '99991231'), '99991230'), -- Das grösste DatumBis darf nicht grösser als 99991231 sein weil wir weiter unten ein DATEADD +1 machen
         KesArtikelID = ISNULL(MAS.KesArtikelID_MassnahmegebundeneGeschaefte, MAS.KesArtikelID_NichtMassnahmegebundeneGeschaefte),
         MAS.*
  FROM dbo.KesMassnahmeBSS MAS WITH (READUNCOMMITTED)
    LEFT JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = MAS.KesMassnahmeBSSID AND MIG.MigrationDate >= @MigrationDate
  WHERE MIG.KesMassnahmeBSSID IS NULL -- Massnahmen die bereits migriert sind ignorieren
)

,MassnahmeGroupCTE AS
(
  SELECT 
    CTE.FaLeistungID, 
    CTE.MassnahmeVon, 
    CTE.MassnahmeBis, 
    CTE.IsDeleted,
    CTE.KesMassnahmeTypCode,
    KesArtikelIDs = dbo.ConcDistinctOrder(CTE.KesArtikelID), 
    KesMassnahmeBSSIDs = dbo.ConcDistinctOrder(CTE.KesMassnahmeBSSID), 
    KesAufgabenbereichCodes = dbo.ConcDistinctOrder(CTE.KesAufgabenbereichCodes),
    KesIndikationCodes = dbo.ConcDistinctOrder(CTE.KesIndikationCodes),
    AnzahlGroup = COUNT(1)
  FROM MassnahmeCTE CTE
  GROUP BY CTE.FaLeistungID, CTE.MassnahmeVon, CTE.MassnahmeBis, CTE.IsDeleted, CTE.KesMassnahmeTypCode
  --HAVING COUNT(1) > 1
  --ORDER BY CTE.FaLeistungID, CTE.MassnahmeVon, CTE.MassnahmeBis
) 

INSERT INTO dbo._Mig_KesMassnahmeBSS_Group (FaLeistungID, MassnahmeVon, MassnahmeBis, IsDeleted, KesMassnahmeTypCode, KesArtikelIDs, KesMassnahmeBSSIDs, KesAufgabenbereichCodes, KesIndikationCodes, AnzahlGroup)
  SELECT FaLeistungID, MassnahmeVon, MassnahmeBis, IsDeleted, KesMassnahmeTypCode, KesArtikelIDs, KesMassnahmeBSSIDs, KesAufgabenbereichCodes, KesIndikationCodes, AnzahlGroup
  FROM MassnahmeGroupCTE CTE 
  ORDER BY CTE.FaLeistungID, CTE.IsDeleted, CTE.KesMassnahmeTypCode, CTE.KesArtikelIDs, CTE.MassnahmeVon, CTE.MassnahmeBis

---- debug
--SELECT *
--FROM _Mig_KesMassnahmeBSS_Group
--WHERE MigrationDate >= @MigrationDate;
---- end debug


-- Start Massnahmen anhand Perioden zusammenführen
;WITH MassnahmeMergeCTE AS
(
  SELECT 
    CTE1.FaLeistungID, 
    CTE1.MassnahmeVon, 
    CTE1.MassnahmeBis,
    CTE1.IsDeleted,
    CTE1.KesMassnahmeTypCode,
    CTE1.KesArtikelIDs,
    CTE1.KesMassnahmeBSSIDs,
    CTE1.KesAufgabenbereichCodes,
    CTE1.KesIndikationCodes,
    CTE1.AnzahlGroup,
    ID = ROW_NUMBER() OVER(ORDER BY CTE1.FaLeistungID, CTE1.MassnahmeVon)
  FROM dbo._Mig_KesMassnahmeBSS_Group         CTE1
    LEFT  JOIN dbo._Mig_KesMassnahmeBSS_Group CTE2 ON CTE2.FaLeistungID = CTE1.FaLeistungID 
                                                  AND CTE2.KesArtikelIDs = CTE1.KesArtikelIDs 
                                                  AND CTE2.IsDeleted = CTE1.IsDeleted 
                                                  AND CTE2.KesMassnahmeTypCode = CTE1.KesMassnahmeTypCode
                                                  AND (DATEADD(DAY, 1, CTE2.MassnahmeBis) = CTE1.MassnahmeVon 
                                                    OR (CTE2.MassnahmeBis = CTE1.MassnahmeVon AND CTE2.MassnahmeVon <> CTE2.MassnahmeBis))
  WHERE CTE2.FaLeistungID IS NULL
  
  UNION ALL
  SELECT 
    CTE1.FaLeistungID, 
    CTE1.MassnahmeVon, 
    CTE2.MassnahmeBis,
    CTE1.IsDeleted,
    CTE1.KesMassnahmeTypCode,
    CTE1.KesArtikelIDs,
    KesMassnahmeBSSIDs      = CTE1.KesMassnahmeBSSIDs + ',' + CTE2.KesMassnahmeBSSIDs,
    KesAufgabenbereichCodes = CTE1.KesAufgabenbereichCodes + ',' + CTE2.KesAufgabenbereichCodes,
    KesIndikationCodes      = CTE1.KesIndikationCodes + ',' + CTE2.KesIndikationCodes,
    CTE1.AnzahlGroup,
    CTE1.ID
  FROM MassnahmeMergeCTE        CTE1
    INNER JOIN dbo._Mig_KesMassnahmeBSS_Group CTE2 ON CTE2.FaLeistungID = CTE1.FaLeistungID 
                                                  AND CTE2.KesArtikelIDs = CTE1.KesArtikelIDs 
                                                  AND CTE2.IsDeleted = CTE1.IsDeleted 
                                                  AND CTE2.KesMassnahmeTypCode = CTE1.KesMassnahmeTypCode
                                                  AND (DATEADD(DAY, -1, CTE2.MassnahmeVon) = CTE1.MassnahmeBis 
                                                    OR (CTE2.MassnahmeVon = CTE1.MassnahmeBis AND CTE2.MassnahmeVon <> CTE2.MassnahmeBis))
)

INSERT INTO dbo._Mig_KesMassnahmeBSS_Merge (FaLeistungID, MassnahmeVon, MassnahmeBis, IsDeleted, KesMassnahmeTypCode, KesArtikelIDs, KesMassnahmeBSSIDs, KesAufgabenbereichCodes, KesIndikationCodes, AnzahlMerge)
  SELECT 
    FaLeistungID            = CTE.FaLeistungID, 
    MassnahmeVon            = CTE.MassnahmeVon, 
    MassnahmeBis            = MAX(CTE.MassnahmeBis),
    IsDeleted               = CTE.IsDeleted, 
    KesMassnahmeTypCode     = CTE.KesMassnahmeTypCode,
    KesArtikelIDs           = CTE.KesArtikelIDs, 
    KesMassnahmeBSSIDs      = dbo.Conc(CTE.KesMassnahmeBSSIDs), 
    KesAufgabenbereichCodes = dbo.Conc(CTE.KesAufgabenbereichCodes),
    KesIndikationCodes      = dbo.Conc(CTE.KesIndikationCodes),
    AnzahlMerge             = COUNT(1)
  FROM MassnahmeMergeCTE CTE
  GROUP BY CTE.FaLeistungID, CTE.KesArtikelIDs, CTE.MassnahmeVon, CTE.ID, CTE.IsDeleted, CTE.KesMassnahmeTypCode
  ORDER BY CTE.FaLeistungID, CTE.MassnahmeVon, MAX(CTE.MassnahmeBis), CTE.IsDeleted, CTE.KesMassnahmeTypCode

---- debug
--SELECT *
--FROM dbo._Mig_KesMassnahmeBSS_Merge
--WHERE MigrationDate >= @MigrationDate
---- end debug

-- remove dupplicate IDs and Codes
UPDATE MIG
  SET KesMassnahmeBSSIDs      = STUFF((SELECT DISTINCT ',' + SplitValue
                                       FROM dbo.fnSplitStringToValues(KesMassnahmeBSSIDs, ',', 1)
                                       FOR XML PATH('')),
                                       1,
                                       1, 
                                       ''),
      KesAufgabenbereichCodes = STUFF((SELECT DISTINCT ',' + SplitValue
                                       FROM dbo.fnSplitStringToValues(KesAufgabenbereichCodes, ',', 1)
                                       FOR XML PATH('')),
                                       1,
                                       1, 
                                       ''),
      KesIndikationCodes      = STUFF((SELECT DISTINCT ',' + SplitValue
                                       FROM dbo.fnSplitStringToValues(KesIndikationCodes, ',', 1)
                                       FOR XML PATH('')),
                                       1,
                                       1, 
                                       '')
FROM dbo._Mig_KesMassnahmeBSS_Merge MIG
WHERE MigrationDate >= @MigrationDate



---- debug
--SELECT *
--FROM dbo._Mig_KesMassnahmeBSS_Merge
--WHERE MigrationDate >= @MigrationDate
---- end debug

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @Mig_KesMassnahmeBSS_Merge (Mig_KesMassnahmeBSS_MergeID, FaLeistungID, MassnahmeVon, MassnahmeBis, IsDeleted, KesMassnahmeTypCode, KesArtikelIDs, KesMassnahmeBSSIDs, KesAufgabenbereichCodes, KesIndikationCodes)
  SELECT Mig_KesMassnahmeBSS_MergeID = ID,
         FaLeistungID,
         MassnahmeVon,
         MassnahmeBis,
         IsDeleted,
         KesMassnahmeTypCode,
         KesArtikelIDs,
         KesMassnahmeBSSIDs,
         KesAufgabenbereichCodes,
         KesIndikationCodes
  FROM dbo._Mig_KesMassnahmeBSS_Merge
  WHERE MigrationDate >= @MigrationDate;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @FaLeistungID                = TMP.FaLeistungID,
         @MassnahmeVon                = TMP.MassnahmeVon,
         @MassnahmeBis                = TMP.MassnahmeBis,
         @IsDeleted                   = TMP.IsDeleted,
         @KesMassnahmeTypCode         = TMP.KesMassnahmeTypCode,
         @KesMassnahmeBSSIDs          = TMP.KesMassnahmeBSSIDs,
         @KesAufgabenbereichCodes     = TMP.KesAufgabenbereichCodes,
         @KesIndikationCodes          = TMP.KesIndikationCodes
  FROM @Mig_KesMassnahmeBSS_Merge TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------
  PRINT (CONVERT(VARCHAR(MAX), @EntriesIterator) + ' : @KesMassnahmeBSSIDs = ' + @KesMassnahmeBSSIDs);

  DECLARE @KesMassnahmeID INT;

  -----------------------------------------------------------------------------
  -- Step 2.1 Massnahme
  -----------------------------------------------------------------------------
  --SET IDENTITY_INSERT dbo.KesMassnahme ON
  INSERT  INTO dbo.KesMassnahme (/*KesMassnahmeID, */FaLeistungID, IsKS, DocumentID_Errichtungsbeschluss, DocumentID_Aufhebungsbeschluss, DatumVon, DatumBis, KesAufgabenbereichCodes, KesIndikationCodes, Auftragstext, KesElterlicheSorgeObhutCode_ElterlicheSorge, KesElterlicheSorgeObhutCode_Obhut, FuersorgerischeUnterbringung, Platzierung_BaInstitutionID, KesGrundlageCode, UebernahmeVon_Datum, UebernahmeVon_OrtschaftCode, UebernahmeVon_PLZ, UebernahmeVon_Ort, UebernahmeVon_Kanton, UebernahmeVon_KesBehoerdeID, AenderungVom_Datum, KesAenderungsgrundCode, UebertragungAn_Datum, UebertragungAn_OrtschaftCode, UebertragungAn_PLZ, UebertragungAn_Ort, UebertragungAn_Kanton, UebertragungAn_KesBehoerdeID, KesAufhebungsgrundCode, Bemerkung, Zustaendig_KesBehoerdeID, Creator, Created, Modifier, Modified, IsDeleted)
    SELECT  
      --KesMassnahmeID                              = MIN(ALT.KesMassnahmeBSSID),
      FaLeistungID                                = @FaLeistungID, 
      IsKS                                        = CASE WHEN @KesMassnahmeTypCode = 2 THEN 1 ELSE 0 END, -- 1	Erwachsenenschutz, 2	Kindesschutz
      DocumentID_Errichtungsbeschluss             = NULL, -- ALT.KESBDocumentID wird später aus dem ältesten Paket mit Änderungsgrund "Massnahmeart" oder [NULL]
      DocumentID_Aufhebungsbeschluss              = NULL, 
      DatumVon                                    = @MassnahmeVon, 
      DatumBis                                    = NULLIF(@MassnahmeBis, '99991230'), 
      KesAufgabenbereichCodes                     = @KesAufgabenbereichCodes, 
      KesIndikationCodes                          = @KesIndikationCodes, 
      Auftragstext                                = NULL, 
      KesElterlicheSorgeObhutCode_ElterlicheSorge = MIN(ALT.KesElterlicheSorgeObhutCode_ElterlicheSorge),
      KesElterlicheSorgeObhutCode_Obhut           = MIN(ALT.KesElterlicheSorgeObhutCode_Obhut),
      FuersorgerischeUnterbringung                = CONVERT(BIT, MIN(CONVERT(INT, ALT.FuersorgerischeUnterbringung))),
      Platzierung_BaInstitutionID                 = MIN(ALT.Platzierung_BaInstitutionID),
      KesGrundlageCode                            = MIN(ALT.KesGrundlageCode),
      UebernahmeVon_Datum                         = MIN(ALT.UebernahmeVom),
      UebernahmeVon_OrtschaftCode                 = NULL, 
      UebernahmeVon_PLZ                           = NULL, 
      UebernahmeVon_Ort                           = NULL, 
      UebernahmeVon_Kanton                        = NULL, 
      UebernahmeVon_KesBehoerdeID                 = NULL, 
      AenderungVom_Datum                          = MIN(ALT.AenderungVom), 
      KesAenderungsgrundCode                      = MIN(ALT.KesAenderungsgrundCode), 
      UebertragungAn_Datum                        = MIN(ALT.UebertragungVom), 
      UebertragungAn_OrtschaftCode                = MIN(ALT.OrtschaftCode), 
      UebertragungAn_PLZ                          = MIN(ALT.PLZ), 
      UebertragungAn_Ort                          = MIN(ALT.Ort), 
      UebertragungAn_Kanton                       = MIN(ALT.Kanton), 
      UebertragungAn_KesBehoerdeID                = NULL, 
      KesAufhebungsgrundCode                      = MIN(ALT.KesAufhebungsgrundCode), 
      Bemerkung                                   = dbo.ConcDistinct(ALT.Bemerkung), 
      Zustaendig_KesBehoerdeID                    = NULL, 
      Creator                                     = MIN(ALT.Creator), -- nicht ganz korrekt, aber immerhin besser als 'kiss_sys'
      Created                                     = MIN(ALT.Created), 
      Modifier                                    = MAX(ALT.Modifier),  -- nicht ganz korrekt, aber immerhin besser als 'kiss_sys'
      Modified                                    = MAX(ALT.Modified),
      IsDeleted                                   = @IsDeleted
    FROM dbo.KesMassnahmeBSS ALT WITH (READUNCOMMITTED)
    WHERE ALT.KesMassnahmeBSSID IN (SELECT TOP 1 CONVERT(INT, SplitValue)
                                    FROM dbo.fnSplitStringToValues(@KesMassnahmeBSSIDs, ',', 1)
                                    WHERE 1=1)
    GROUP BY ALT.FaLeistungID;

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Massnahme migriert');
  --SET IDENTITY_INSERT dbo.KesMassnahme OFF

  SELECT @KesMassnahmeID = SCOPE_IDENTITY();

  -- log
  INSERT INTO dbo._Mig_KesMassnahmeBSS (KesMassnahmeBSSID, KesMassnahmeID, Step, Bemerkung)
    SELECT KesMassnahmeBSSID = CONVERT(INT, SplitValue), 
           KesMassnahmeID    = @KesMassnahmeID,
           Step              = 2,
           Bemerkung         = 'Migration von Massnahmen'
    FROM dbo.fnSplitStringToValues(@KesMassnahmeBSSIDs, ',', 1)

  -- Das Dokument 'Verfügung/Auftrag KESB' mit 'Änderungsgrund' "Massnahme" oder [null] des ältesten Pakets gilt als der 'Errichtungsbeschluss'
  UPDATE MAS
    SET DocumentID_Errichtungsbeschluss = (SELECT TOP 1 ALT.KESBDocumentID
                                           FROM dbo._Mig_KesMassnahmeBSS    MIG WITH (READUNCOMMITTED) 
                                             INNER JOIN dbo.KesMassnahmeBSS ALT WITH (READUNCOMMITTED) ON ALT.KesMassnahmeBSSID = MIG.KesMassnahmeBSSID
                                           WHERE MIG.KesMassnahmeID = MAS.KesMassnahmeID
                                             AND ISNULL(ALT.KesAenderungsgrundCode, 1) = 1 -- Massnahmenart oder leer
                                             AND ALT.KESBDocumentID IS NOT NULL
                                           ORDER BY COALESCE(ALT.AenderungVom, ALT.UebernahmeVom, ALT.ErrichtungVom, '17530102'), ALT.KesMassnahmeBSSID
                                          )
  FROM dbo.KesMassnahme MAS 
  WHERE MAS.KesMassnahmeID = @KesMassnahmeID;

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' DocumentID_Errichtungsbeschluss hinzugefügt');

  -------------------------------------------------------------------------------
  -- step 2.2: Mandatsführende Person
  -------------------------------------------------------------------------------
  INSERT INTO dbo.KesMandatsfuehrendePerson ( KesMassnahmeID ,
                                              DatumMandatVon ,
                                              DatumMandatBis ,
                                              DocumentID_Ernennungsurkunde ,
                                              UserID ,
                                              BaInstitutionID ,
                                              KesBeistandsartCode ,
                                              DatumVorgeschlagenAm ,
                                              DatumRechnungsfuehrungVon ,
                                              DatumRechnungsfuehrungBis ,
                                              Creator ,
                                              Created ,
                                              Modifier ,
                                              Modified ,
                                              IsDeleted
                                            )
    SELECT 
      KesMassnahmeID               = MIG.KesMassnahmeID,
      DatumMandatVon               = MIN(ALT.ErrichtungVom),
      DatumMandatBis               = NULL,
      DocumentID_Ernennungsurkunde = MIN(ALT.DocumentID_Urkunde),
      UserID                       = ALT.UserID,
      BaInstitutionID              = CASE WHEN ALT.BaInstitutionID IS NOT NULL THEN ALT.BaInstitutionID
                                          ELSE (SELECT TOP 1 BaInstitutionID
                                                FROM dbo._Mig_VmPriMa_To_BaInstitution WITH (READUNCOMMITTED)
                                                WHERE VmPriMaID = ALT.VmPriMaID)
                                     END,
      KesBeistandsartCode          = ALT.KesBeistandsartCode,
      DatumVorgeschlagenAm         = NULL,
      DatumRechnungsfuehrungVon    = NULL,
      DatumRechnungsfuehrungBis    = NULL,
      Creator                      = MIN(ALT.Creator),
      Created                      = MIN(ALT.Created),
      Modifier                     = MIN(ALT.Modifier),
      Modified                     = MIN(ALT.Modified),
      IsDeleted                    = ALT.IsDeleted
    FROM dbo.KesMassnahmeBSS              ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
    WHERE COALESCE(ALT.UserID, ALT.VmPriMaID, ALT.BaInstitutionID) IS NOT NULL
      AND MIG.KesMassnahmeID = @KesMassnahmeID
    GROUP BY MIG.KesMassnahmeID, ALT.UserID, ALT.BaInstitutionID, ALT.VmPriMaID, ALT.KesBeistandsartCode, ALT.IsDeleted;

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Mandatsführende Person migriert');



  -------------------------------------------------------------------------------
  -- step 2.3: Artikel
  -------------------------------------------------------------------------------
  INSERT INTO dbo.KesMassnahme_KesArtikel (KesMassnahmeID, KesArtikelID, Creator, Created, Modifier, Modified)
    SELECT 
      KesMassnahmeID = MIG.KesMassnahmeID,
      KesArtikelID   = ALT.KesArtikelID_MassnahmegebundeneGeschaefte,
      Creator        = MIN(ALT.Creator),
      Created        = MIN(ALT.Created),
      Modifier       = MAX(ALT.Modifier),
      Modified       = MAX(ALT.Modified)
    FROM dbo.KesMassnahmeBSS              ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
    WHERE ALT.KesArtikelID_MassnahmegebundeneGeschaefte IS NOT NULL
      AND MIG.KesMassnahmeID = @KesMassnahmeID
    GROUP BY MIG.KesMassnahmeID, ALT.KesArtikelID_MassnahmegebundeneGeschaefte;

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Artikel (Massnahmegebundene Geschaefte) migriert');


  INSERT INTO dbo.KesMassnahme_KesArtikel (KesMassnahmeID, KesArtikelID, Creator, Created, Modifier, Modified)
    SELECT 
      KesMassnahmeID = MIG.KesMassnahmeID,
      KesArtikelID   = ALT.KesArtikelID_NichtMassnahmegebundeneGeschaefte,
      Creator        = MIN(ALT.Creator),
      Created        = MIN(ALT.Created),
      Modifier       = MAX(ALT.Modifier),
      Modified       = MAX(ALT.Modified)
    FROM dbo.KesMassnahmeBSS              ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
    WHERE ALT.KesArtikelID_NichtMassnahmegebundeneGeschaefte IS NOT NULL
      AND NOT EXISTS (SELECT TOP 1 1
                      FROM dbo.KesMassnahme_KesArtikel WITH (READUNCOMMITTED)
                      WHERE KesMassnahmeID = ALT.KesMassnahmeBSSID
                        AND KesArtikelID = ALT.KesArtikelID_NichtMassnahmegebundeneGeschaefte) --Sicherstellen, dass keine doppelten Daten existieren, falls KesArtikelID_MassnahmegebundeneGeschaefte = KesArtikelID_NichtMassnahmegebundeneGeschaefte
      AND MIG.KesMassnahmeID = @KesMassnahmeID
    GROUP BY MIG.KesMassnahmeID, ALT.KesArtikelID_NichtMassnahmegebundeneGeschaefte;

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Artikel (nicht Massnahmegebundene Geschaefte) migriert');


  -------------------------------------------------------------------------------
  -- step 2.4: Bericht: Periode aus VmBericht und DatumVerfuegungKESB aus KesMassnahmeBSS
  -------------------------------------------------------------------------------
  INSERT INTO dbo.KesMassnahmeBericht (KesMassnahmeID, KesMassnahmeBerichtsartCode, DatumVon, DatumBis, Creator, Created, Modifier, Modified, IsDeleted)
    SELECT
      KesMassnahmeID              = @KesMassnahmeID,
      KesMassnahmeBerichtsartCode = 1, --1: Ordentlicher Bericht
      DatumVon                    = ALT.BerichtsperiodeVon,
      DatumBis                    = ALT.BerichtsperiodeBis,
      Creator                     = @Creator,
      Created                     = GETDATE(),
      Modifier                    = @Creator,
      Modified                    = GETDATE(),
      IsDeleted                   = @IsDeleted
    FROM dbo.VmBericht ALT WITH (READUNCOMMITTED)
    WHERE FaLeistungID = @FaLeistungID
      AND BerichtsperiodeVon <= @MassnahmeBis
      AND BerichtsperiodeBis >= @MassnahmeVon

  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Berichte migriert');

  -- Datum "Verfügung KESB vom" an richtigem Bericht zuordnen
  ;WITH BerichtCTE AS
  (
    SELECT
      KesMassnahmeID              = MIG.KesMassnahmeID,
      DatumVerfuegungKESB         = ALT.BerichtsgenehmigungVom,
      Creator                     = ALT.Creator,
      Created                     = ALT.Created,
      Modifier                    = ALT.Modifier,
      Modified                    = ALT.Modified,
      KesMassnahmeBerichtID       = (SELECT TOP 1 BER.KesMassnahmeBerichtID
                                     FROM dbo.KesMassnahmeBericht BER WITH (READUNCOMMITTED)
                                     WHERE BER.KesMassnahmeID = @KesMassnahmeID
                                       AND BER.DatumVon <= @MassnahmeBis
                                       AND BER.DatumBis >= @MassnahmeVon
                                       AND BER.DatumBis <= ALT.BerichtsgenehmigungVom
                                     ORDER BY BER.DatumBis DESC)
    FROM dbo.KesMassnahmeBSS ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
    WHERE ALT.BerichtsgenehmigungVom IS NOT NULL
      AND MIG.KesMassnahmeID = @KesMassnahmeID
  )

  UPDATE BER
    SET DatumVerfuegungKESB         = CTE.DatumVerfuegungKESB,
        Creator                     = CTE.Creator,
        Created                     = CTE.Created,
        Modifier                    = CTE.Modifier,
        Modified                    = CTE.Modified
  FROM dbo.KesMassnahmeBericht BER
    INNER JOIN BerichtCTE CTE WITH (READUNCOMMITTED) ON CTE.KesMassnahmeBerichtID = BER.KesMassnahmeBerichtID
  WHERE BER.KesMassnahmeID = @KesMassnahmeID;
  
  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Berichte (Verfügung KESB vom) migriert');

  -- Wenn Massnahme 'Änderungsgrund' "Berichtsgenehmigung", Dok 'Verfügung/Auftrag KESB' nach 'Berichts- und Rechnungsablage' der zugehörigen Massnahme und der vorhergehenden Periode
  ;WITH BerichtCTE AS
  (
    SELECT
      KesMassnahmeID            = MIG.KesMassnahmeID,
      DocumentID_VerfuegungKESB = ALT.KESBDocumentID,
      KesMassnahmeBerichtID     = (SELECT TOP 1 BER.KesMassnahmeBerichtID
                                   FROM dbo.KesMassnahmeBericht BER WITH (READUNCOMMITTED)
                                   WHERE BER.KesMassnahmeID = @KesMassnahmeID
                                     AND BER.DatumVon <= @MassnahmeBis
                                     AND BER.DatumBis >= @MassnahmeVon
                                     AND BER.DatumBis <= COALESCE(ALT.AenderungVom, ALT.UebernahmeVom, ALT.ErrichtungVom, '17530102')
                                   ORDER BY BER.DatumBis DESC)
    FROM dbo.KesMassnahmeBSS ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
    WHERE ALT.KesAenderungsgrundCode = 12 -- Berichtsgenehmigung
      AND ALT.KESBDocumentID IS NOT NULL
      AND MIG.KesMassnahmeID = @KesMassnahmeID
  )

  UPDATE BER
    SET BER.DocumentID_VerfuegungKESB = CTE.DocumentID_VerfuegungKESB
  FROM dbo.KesMassnahmeBericht BER
    INNER JOIN BerichtCTE CTE WITH (READUNCOMMITTED) ON CTE.KesMassnahmeBerichtID = BER.KesMassnahmeBerichtID
  WHERE BER.KesMassnahmeID = @KesMassnahmeID;
  
  PRINT ('      ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' Berichte (Dokument Bericht) migriert');



  -------------------------------------------------------------------------------
  -- step 2.4: Auftrag: Wenn 'Änderungsgrund' alle anderen, dann Dokument in 'Aufträge/Anträge' zur entsprechenden Massnahme inkl. Begleittext.
  -------------------------------------------------------------------------------
  INSERT INTO dbo.KesMassnahmeAuftrag (KesMassnahmeID, DocumentID_Beschluss, Auftrag, Creator, Created, Modifier, Modified, IsDeleted)
    SELECT 
      KesMassnahmeID         = MIG.KesMassnahmeID, 
      DocumentID_Beschluss   = ALT.KESBDocumentID, 
      Auftrag                = ISNULL(ART.Artikel + IsNull('.' + ART.Absatz, '') + IsNull('.' + ART.Ziffer, '') + ' ' + ART.Gesetz + ' ' + ART.Bezeichnung + ' / ', '') + 'Änderungsgrund: ' + dbo.fnLOVText('KesAenderungsgrund', ALT.KesAenderungsgrundCode), 
      Creator                = ALT.Creator,
      Created                = ALT.Created,
      Modifier               = ALT.Modifier,
      Modified               = ALT.Modified,
      IsDeleted              = ALT.IsDeleted
    FROM dbo.KesMassnahmeBSS              ALT WITH (READUNCOMMITTED)
      INNER JOIN dbo._Mig_KesMassnahmeBSS MIG WITH (READUNCOMMITTED) ON MIG.KesMassnahmeBSSID = ALT.KesMassnahmeBSSID
      LEFT  JOIN dbo.KesArtikel           ART WITH (READUNCOMMITTED) ON ART.KesArtikelID = ISNULL(ALT.KesArtikelID_MassnahmegebundeneGeschaefte, ALT.KesArtikelID_NichtMassnahmegebundeneGeschaefte)
    WHERE ALT.KesAenderungsgrundCode IS NOT NULL
      AND ALT.KesAenderungsgrundCode NOT IN (1, 12) -- Massnahmeart, Berichtsgenehmigung
      AND ALT.KESBDocumentID IS NOT NULL
      AND MIG.KesMassnahmeID = @KesMassnahmeID
  

  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;




-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO