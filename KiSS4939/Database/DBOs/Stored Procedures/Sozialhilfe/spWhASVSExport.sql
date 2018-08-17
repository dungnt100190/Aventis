SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhASVSExport
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhASVSExport.sql $
  $Author: Mmarghitola $
  $Modtime: 24.09.10 13:36 $
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhASVSExport.sql $
 * 
 * 13    24.09.10 13:38 Mmarghitola
 * #6082: Korrektur zum Status-Update
 * 
 * 12    23.09.10 14:03 Mmarghitola
 * #6082: Korrekturen
 * 
 * 11    3.09.10 12:07 Mmarghitola
 * #6082: Änderungen in geschlossener Sozialhilfe, Einschränkung von
 * Export auf Sektion
 * 
 * 10    24.06.10 17:06 Mmarghitola
 * #6219: Korrekturen zum ASVS-Export
 * 
 * 9     4.06.10 9:52 Mmarghitola
 * #6219: Datums-Werte immer eintragen
 * 
 * 8     18.05.10 17:51 Mmarghitola
 * #6082: XML-Export korrigieren
 * 
 * 7     22.03.10 13:59 Mmarghitola
 * #5037: Zusätzliche Überprüfung der Sozialversicherungsnummer, Korrektur
 * UserIDErstellt
 * 
 * 6     24.02.10 10:58 Mmarghitola
 * #5037: Fehlerrückmeldung verbessern
 * 
 * 5     19.02.10 14:48 Mmarghitola
 * #5037: Auswahl Vorname angepasst
 * 
 * 4     16.02.10 11:53 Mmarghitola
 * #5037: ASVS-Korrekturen
 * 
 * 3     10.02.10 1:14 Mmarghitola
 * #5037: Verbesserte Selektionierung
 * 
 * 2     14.12.09 17:21 Mmarghitola
 * Detailkorrektur
 * 
 * 1     11.12.09 14:37 Mmarghitola
 * #5037: spWhASVSExport
 * 
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spWhASVSExport
  Branch   : 
  BuildNr  : 
  Datum    : 
*/
CREATE PROCEDURE [dbo].[spWhASVSExport]
  @ASVSExportID int,
  @UserID int,
  @OrgUnitID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
  
  IF @@TRANCOUNT = 0 BEGIN
    RAISERROR('spWhASVSExport: Keine Transaktion offen.', 18, 1)
    RETURN
  END

  INSERT INTO SstASVSExport_Eintrag (SstASVSExportID, WhASVSEintragID, ASVSExportCode, Creator, Modifier)
    SELECT
      @ASVSExportID, AEI.WhASVSEintragID,
      CASE WHEN AEI.ASVSEintragStatusCode = 2 THEN 1 -- Export
           WHEN AEI.ASVSEintragStatusCode = 4 THEN 2 END, -- Löschung
      AEI.Creator, AEI.Modifier
      
    FROM dbo.WhASVSEintrag AEI
      INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = AEI.FaLeistungID
      INNER JOIN dbo.XUser USR ON USR.UserID = LEI.UserID
      LEFT  JOIN dbo.XOrgUnit_User OUU ON OUU.UserID = USR.UserID AND OUU.OrgUnitMemberCode = 2
      LEFT  JOIN dbo.XorgUnit ORG ON ORG.OrgUnitID = OUU.OrgUnitID
    WHERE (AEI.ASVSEintragStatusCode = 2 OR AEI.ASVSEintragStatusCode = 4) -- 2 = Export pendent, 4 = Löschung pendent
      AND (ORG.OrgUnitID = @OrgUnitID OR ORG.ParentID = @OrgUnitID OR @OrgUnitID IS NULL)
  
  IF NOT EXISTS (
    SELECT SstASVSExport_EintragID
    FROM SstASVSExport_Eintrag
    WHERE SstASVSExportID = @ASVSExportID
  )
  BEGIN
    RAISERROR ('Keine Einträge zum exportieren gefunden.', 18, 1)
    RETURN -1
  END
  IF EXISTS (
    SELECT PER.BaPersonID
    FROM SstASVSExport_Eintrag SAE
      INNER JOIN WhASVSEintrag WAE ON WAE.WhASVSEintragID = SAE.WhASVSEintragID
      INNER JOIN BaPerson PER ON PER.BaPersonID = WAE.BaPersonID
    WHERE SstASVSExportID = @ASVSExportID AND PER.VersichertenNummer IS NULL
  )
  BEGIN
    RAISERROR ('Export nicht möglich: Es exisieren Einträge ohne Sozialversicherungsnummern.', 18, 1)
    RETURN -1
  END

  IF EXISTS (
    SELECT PER.BaPersonID
    FROM SstASVSExport_Eintrag SAE
      INNER JOIN WhASVSEintrag WAE ON WAE.WhASVSEintragID = SAE.WhASVSEintragID
      INNER JOIN BaPerson PER ON PER.BaPersonID = WAE.BaPersonID
    WHERE SstASVSExportID = @ASVSExportID AND
      (LEN(PER.Versichertennummer) <> 16
        OR PER.Versichertennummer NOT LIKE
          '[0123456789][0123456789][0123456789].[0123456789][0123456789][0123456789][0123456789].[0123456789][0123456789][0123456789][0123456789].[0123456789][0123456789]')
  )
  BEGIN
    RAISERROR ('Export nicht möglich: Es exisieren Einträge mit ungültiger Sozialversicherungsnummer.', 18, 1)
    RETURN -1
  END

  IF EXISTS (
    SELECT WAE.BaPersonID
    FROM SstASVSExport_Eintrag SAE
      INNER JOIN WhASVSEintrag WAE ON WAE.WhASVSEintragID = SAE.WhASVSEintragID
    WHERE SstASVSExportID = @ASVSExportID
      AND NOT EXISTS (SELECT TOP 1 ADR2.BaAdresseID FROM dbo.BaAdresse ADR2 WHERE ADR2.BaPersonID = WAE.BaPersonID AND AdresseCode = 1 AND ADR2.PLZ IS NOT NULL)
  )
  BEGIN
    RAISERROR ('Export nicht möglich: Es exisieren Einträge ohne gültige Adressen.', 18, 1)
    RETURN -1
  END

----

  DECLARE @ASVS_XML XML (ASVS_SchemaCollection)
  ;
  WITH XMLNAMESPACES('http://www.w3.org/2001/XMLSchema-instance' as xsi, Default 'http://asvs.jgk.be.ch/schemas/evok/20090708/SozialhilfeMeldungImport')

  SELECT @ASVS_XML =
  (
  SELECT 
    'http://asvs.jgk.be.ch/schemas/evok/20090703/SozialhilfeMeldungImport ../../main/xsd/SozialhilfeMeldungImport.xsd' '@xsi:schemaLocation',
  (
  SELECT
    MAX(AEI.Creator) 'UserIdErstellt',
    -- datetime HACK: use new type datetime2 after upgrade to SQLServer2008
    CONVERT(NVARCHAR(30), GETDATE(), 126) + 'Z'   'TimestampErstellt',
    (SELECT
      PER.Name    'Name',
      ISNULL(PER.Vorname, '') 'Vorname',
      ISNULL(ADR.Strasse, '') 'Strasse',
      ADR.PLZ                 'Postleitzahl',
      ISNULL(ADR.Ort, '')     'Wohnort',
      PER.VersichertenNummer 'NeueVersichertenNummer',
      replace(convert(varchar(200), PER.Geburtsdatum, 111), '/', '-') + 'Z' 'Geburtsdatum',
      replace(convert(varchar(200), AEI4.DatumVon, 111), '/', '-') + 'Z' 'BeginnSozialhilfe',
      replace(convert(varchar(200), CASE WHEN AEE2.ASVSExportCode = 1 THEN ISNULL(AEI4.DatumBis, '') ELSE AEI4.DatumVon END, 111), '/', '-') + 'Z' 'EndeSozialhilfe'
    FROM dbo.WhASVSEintrag AEI4
      LEFT JOIN dbo.SstASVSExport_Eintrag AEE2 ON AEE2.WhASVSEintragID = AEI4.WhASVSEintragID
      LEFT JOIN dbo.BaPerson PER ON PER.BaPersonID = AEI4.BaPersonID
      OUTER APPLY (SELECT TOP 1 ADR2.Strasse, ADR2.PLZ, ADR2.Ort FROM dbo.BaAdresse ADR2 WHERE ADR2.BaPersonID = PER.BaPersonID AND AdresseCode = 1 AND ADR2.PLZ IS NOT NULL ORDER BY ISNULL(DatumVon, Convert(datetime, '19000101')) DESC) ADR
    WHERE AEI4.FaLeistungID = AEI.FaLeistungID AND AEI4.ASVSEintragStatusCode IN (2, 4)
    FOR XML PATH ('Mitglieder'), TYPE)
  FROM dbo.SstASVSExport_Eintrag AEE
    LEFT JOIN dbo.WhASVSEintrag AEI ON AEI.WhASVSEintragID = AEE.WhASVSEintragID
  WHERE AEE.SstASVSExportID = @ASVSExportID
  GROUP BY AEI.FaLeistungID
  FOR XML PATH ('Sozialfall'), TYPE--ROOT('SozialfallMeldungen')--/Sozialfall
  )
  FOR XML PATH ('SozialfallMeldungen')--, ROOT('SozialfallMeldungen')--/Sozialfall
  )

----

  DECLARE @DocumentID int
  INSERT INTO dbo.XDocument (DateCreation, UserID_Creator, DateLastSave, FileBinary, DocFormatCode, FileExtension, DocReadOnly, DocTypeCode) VALUES (GetDate(), @UserID, GetDate(), CONVERT(VARBINARY(MAX), N'<?xml version="1.0" encoding="UTF-8"?>' + Convert(NVARCHAR(MAX),@ASVS_XML)), 0, 'xml', 1, 2)
  SET @DocumentID = SCOPE_IDENTITY()
  UPDATE dbo.SstASVSExport SET DocumentID = @DocumentID, DatumExport = GETDATE() WHERE SstASVSExportID = @ASVSExportID
  -- DocFormatCode 0 = unbekannt, DocTypeCode 2 = Dokument
  UPDATE WhASVSEintrag 
  SET ASVSEintragStatusCode = CASE WHEN ASVSEintragStatusCode = 2 THEN 3 WHEN ASVSEintragStatusCode = 4 THEN 5 ELSE ASVSEintragStatusCode END 
  FROM dbo.WhASVSEintrag WAE
    INNER JOIN dbo.SstAsvsExport_Eintrag SAE ON SAE.WhASVSEintragID = WAE.WhASVSEintragID
  WHERE SAE.SstASVSExportID = @ASVSExportID AND ASVSEintragStatusCode IN (2, 4)
END
