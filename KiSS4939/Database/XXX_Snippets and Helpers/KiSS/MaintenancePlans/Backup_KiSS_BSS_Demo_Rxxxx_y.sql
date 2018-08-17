/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to backup latest KiSS_BSS_Demo_Rxxxx including DOC databases.
           This script is used in backup job of CHBEHVS004.Backup_KiSS
=================================================================================================
  $Log: $
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------
-- declare vars
DECLARE @BackupPath NVARCHAR(1000);
DECLARE @DatabaseName NVARCHAR(255);
DECLARE @SQLStatement NVARCHAR(MAX);
DECLARE @BackupSetId AS INT;
DECLARE @BackupPathFile AS VARCHAR(1255);
--
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;

-- init temp table
DECLARE @Databases TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  DatabaseName VARCHAR(255)
);

-- set vars
SET @BackupPath = N'\\CHBEHVS005\Backup\2005\KiSS\KiSS_BSS_Demo_Rxxxx\';

-------------------------------------------------------------------------------
-- 
-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
-- ==== KiSS_BSS_Demo_Rxxxx ====
-- get latest demo database
SELECT TOP 1 
       @DatabaseName = DBS.name
FROM sys.databases DBS
WHERE DBS.name LIKE 'KiSS\_BSS\_Demo\_R%' ESCAPE '\'
  AND DBS.name NOT LIKE 'KiSS\_BSS\_Demo\_R____\_DOC' ESCAPE '\'
ORDER BY DBS.name DESC;

-- validate
IF (ISNULL(@DatabaseName, '') = '')
BEGIN
  RAISERROR(N'Backup failed. No database found matching pattern "KiSS_BSS_Demo_Rxxxx".', 16, 1);
  RETURN;
END;

-- insert entry into temp-table
INSERT INTO @Databases (DatabaseName)
VALUES (@DatabaseName);

-- ==== KiSS_BSS_Demo_Rxxxx_DOC ====
/*
-- reset var
SET @DatabaseName = NULL;

-- get latest demo_doc database
SELECT TOP 1 
       @DatabaseName = DBS.name
FROM sys.databases DBS
WHERE DBS.name LIKE 'KiSS\_BSS\_Demo\_R____\_DOC' ESCAPE '\'
ORDER BY DBS.name DESC;

-- validate
IF (ISNULL(@DatabaseName, '') = '')
BEGIN
  RAISERROR(N'Backup failed. No database found matching pattern "KiSS_BSS_Demo_Rxxxx_DOC".', 16, 1);
  RETURN;
END;

-- insert entry into temp-table
INSERT INTO @Databases (DatabaseName)
VALUES (@DatabaseName);
*/

-------------------------------------------------------------------------------
-- prepare vars for loop
-------------------------------------------------------------------------------
SELECT @EntriesCount = COUNT(1) FROM @Databases;
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @DatabaseName = TMP.DatabaseName
  FROM @Databases TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- set backup path file
  -----------------------------------------------------------------------------
  SET @BackupPathFile = @BackupPath + @DatabaseName + N'_FullBackup.bak';
  
  -------------------------------------------------------------------------------
  -- create backup
  -------------------------------------------------------------------------------
  -- info
  PRINT ('');
  PRINT ('Info: Starting backup of "' + @DatabaseName + '" to "' + @BackupPathFile + '": ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- set sql statement
  SET @SQLStatement = 
  N'
    BACKUP DATABASE [' + @DatabaseName + N']
    TO DISK = N''' + @BackupPathFile + ''' 
    WITH NOFORMAT, INIT, NAME = N''' + @DatabaseName + N'-Full Database Backup'', 
    SKIP, NOREWIND, NOUNLOAD, STATS = 10;
  ';
  
  /*
  -- debug
  PRINT (@SQLStatement);
  GOTO NEXTWHILE;
  --*/

  -- execute backup
  EXEC sp_executesql @SQLStatement;
  
  -------------------------------------------------------------------------------
  -- verify backup
  -------------------------------------------------------------------------------
  -- get backup set id
  SELECT @BackupSetId = position 
  FROM msdb..backupset 
  WHERE database_name = @DatabaseName 
    AND backup_set_id = (SELECT MAX(backup_set_id) 
                         FROM msdb..backupset 
                         WHERE database_name = @DatabaseName);
  
  -- validate
  IF (@BackupSetId IS NULL)
  BEGIN 
    RAISERROR(N'Verify failed. Backup information for database "%s" not found.', 16, 1, @DatabaseName);
  END;
  
  -- info
  PRINT ('');
  PRINT ('Info: Starting verify backup of "' + @DatabaseName + '" from "' + @BackupPathFile + '": ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -- verify backup
  RESTORE VERIFYONLY 
  FROM DISK = @BackupPathFile
  WITH FILE = @BackupSetId, NOUNLOAD, NOREWIND;
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
NEXTWHILE:
  SET @EntriesIterator = @EntriesIterator + 1;
END;
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO