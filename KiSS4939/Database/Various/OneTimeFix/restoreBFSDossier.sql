/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: BFS-Dossier und abhängige Daten (BFSDossier, BFSDossierPerson und BFSWert) aus einer
           Backup-DB auf der Prod-DB kopieren.

           @ProdDBName:   Name der Prod-DB. Wo die Daten ersetzt werden müssen.
           @BackupDBName: Name der Backup-DB. Woher die Daten kopiert werden.
           @Jahr:         Jahr für welches die Dossiers kopiert werden müssen.
=================================================================================================
  TEST: 
=================================================================================================*/

BEGIN TRAN
-- ROLLBACK
-- COMMIT

DECLARE @ProdDBName NVARCHAR(100);
DECLARE @BackupDBName NVARCHAR(100);
DECLARE @Jahr INT;

SET @ProdDBName = 'KiSS_WOR_Prod';
SET @BackupDBName = 'restore_kiss_temp';
SET @Jahr = 2011;

DECLARE @SQL NVARCHAR(MAX);
DECLARE @SQL_EXEC NVARCHAR(MAX);

SET @SQL = '
DECLARE @Jahr INT;
SET @Jahr = <Jahr>;

-- alte daten löschen
DELETE WER
--SELECT *
FROM <ProdDBName>.dbo.BFSWert WER
WHERE BFSDossierID IN (SELECT BFSDossierID
                       FROM <ProdDBName>.dbo.BFSDossier DOS
                       WHERE Jahr = @Jahr)
DELETE BDP
--SELECT *
FROM <ProdDBName>.dbo.BFSDossierPerson BDP
WHERE BFSDossierID IN (SELECT BFSDossierID
                       FROM <ProdDBName>.dbo.BFSDossier DOS
                       WHERE Jahr = @Jahr)

DELETE DOS
--SELECT *
FROM <ProdDBName>.dbo.BFSDossier DOS
WHERE Jahr = @Jahr

-- INSERT INTO BFSDossier
SET IDENTITY_INSERT <ProdDBName>.dbo.BFSDossier ON;

INSERT INTO <ProdDBName>.dbo.BFSDossier
        (BFSDossierID,
         BFSKatalogVersionID,
         FaLeistungID,
         UserID,
         LaufNr,
         ZustaendigeGemeinde,
         DatumVon,
         DatumBis,
         Jahr,
         Stichtag,
         BFSDossierStatusCode,
         BFSLeistungsartCode,
         ImportDatum,
         PlausibilisierungDatum,
         ExportDatum,
         XML)
SELECT  BFSDossierID,
        BFSKatalogVersionID,
        FaLeistungID,
        UserID,
        LaufNr,
        ZustaendigeGemeinde,
        DatumVon,
        DatumBis,
        Jahr,
        Stichtag,
        BFSDossierStatusCode,
        BFSLeistungsartCode,
        ImportDatum,
        PlausibilisierungDatum,
        ExportDatum,
        XML
FROM <BackupDBName>.dbo.BFSDossier DOS
WHERE Jahr = @Jahr

SET IDENTITY_INSERT <ProdDBName>.dbo.BFSDossier OFF;

-- INSERT INTO BFSDossierPerson
SET IDENTITY_INSERT <ProdDBName>.dbo.BFSDossierPerson ON;

INSERT INTO <ProdDBName>.dbo.BFSDossierPerson
        (BFSDossierPersonID,
         BFSDossierID,
         BFSPersonCode,
         PersonIndex,
         PersonName,
         BaPersonID)
SELECT  BFSDossierPersonID,
        BFSDossierID,
        BFSPersonCode,
        PersonIndex,
        PersonName,
        BaPersonID
FROM <BackupDBName>.dbo.BFSDossierPerson BDP
WHERE BFSDossierID IN (SELECT BFSDossierID
                       FROM <BackupDBName>.dbo.BFSDossier DOS
                       WHERE Jahr = @Jahr)

SET IDENTITY_INSERT <ProdDBName>.dbo.BFSDossierPerson OFF;

--  INSERT INTO BFSWert
SET IDENTITY_INSERT <ProdDBName>.dbo.BFSWert ON;

INSERT INTO <ProdDBName>.dbo.BFSWert
        (BFSWertID,
         BFSDossierID,
         BFSDossierPersonID,
         BFSFrageID,
         Wert,
         PlausiFehler)
SELECT  BFSWertID,
        BFSDossierID,
        BFSDossierPersonID,
        BFSFrageID,
        Wert,
        PlausiFehler
FROM <BackupDBName>.dbo.BFSWert WER
WHERE BFSDossierID IN (SELECT BFSDossierID
                       FROM <BackupDBName>.dbo.BFSDossier DOS
                       WHERE Jahr = @Jahr)

SET IDENTITY_INSERT <ProdDBName>.dbo.BFSWert OFF;
';

-- COMMIT

SET @SQL_EXEC = REPLACE(@SQL, '<ProdDBName>', @ProdDBName);
SET @SQL_EXEC = REPLACE(@SQL_EXEC, '<BackupDBName>', @BackupDBName);
SET @SQL_EXEC = REPLACE(@SQL_EXEC, '<Jahr>', @Jahr);

--PRINT @SQL_EXEC
EXEC sp_executesql @SQL_EXEC;

RETURN;

--SELECT *
--FROM <BackupDBName>.dbo.BFSDossier DOS
--WHERE Jahr = @Jahr

--SELECT *
--FROM <BackupDBName>.dbo.BFSDossierPerson BDP
--WHERE BFSDossierID IN (SELECT BFSDossierID
--                       FROM <BackupDBName>.dbo.BFSDossier DOS
--                       WHERE Jahr = @Jahr)

--SELECT *
--FROM <BackupDBName>.dbo.BFSWert WER
--WHERE BFSDossierID IN (SELECT BFSDossierID
--                       FROM <BackupDBName>.dbo.BFSDossier DOS
--                       WHERE Jahr = @Jahr)


