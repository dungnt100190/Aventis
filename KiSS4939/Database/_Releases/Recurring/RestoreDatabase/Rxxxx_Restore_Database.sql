/*===============================================================================================
  $Revision: 22 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to restore and setup database. This script is called by TeamCity
           to autmatically create new release databases.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 21 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- init
-------------------------------------------------------------------------------
USE [master]
GO

-- info
PRINT ('starting script: ' + CONVERT(VARCHAR, GETDATE(), 113));
GO

-- drop database if currently restoring to prevent error on ALTER statement
IF (EXISTS (SELECT TOP 1 1 
            FROM sys.databases WITH (READUNCOMMITTED) 
            WHERE name = N'{DBName}'
              AND state_desc = N'RESTORING')) 
BEGIN
  PRINT ('Info: Database "{DBName}" is currently in RESTORE state and will be droped now to prevent error on ALTER statements.');
  DROP DATABASE [{DBName}];
END;
GO

-- set single user mode to close all open connections
IF (EXISTS (SELECT TOP 1 1 
            FROM sys.databases WITH (READUNCOMMITTED) 
            WHERE name = N'{DBName}')) 
BEGIN
  PRINT ('set singleuser: ' + CONVERT(VARCHAR, GETDATE(), 113));
  ALTER DATABASE [{DBName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
END;
GO

-- init settings vars
DECLARE @DBName NVARCHAR(100);
DECLARE @DataFolder NVARCHAR(100);
DECLARE @LogFolder NVARCHAR(100);
DECLARE @BackupFile NVARCHAR(500);
DECLARE @IsDoc BIT;
DECLARE @DBPath NVARCHAR(500);
DECLARE @IsZH BIT;
DECLARE @IsZH_OIZSERVER BIT;
DECLARE @IsZH_SCHINTI BIT;
DECLARE @IsZH_TakeBakProdVortag BIT;

-- ZH specific NSE handling
SELECT @IsZH = CASE 
                 WHEN (N';' + N'{NSExt}' + N';' LIKE N'%;ZH;%') OR
                      (N';' + N'{NSExt}' + N';' LIKE N'%;$ZH;%') THEN 1                               -- ZH
                 ELSE 0
               END,
       --
       @IsZH_OIZSERVER = CASE 
                          WHEN (N';' + N'{NSExt}' + N';' LIKE N'%;OIZSERVER;%') OR
                               (N';' + N'{NSExt}' + N';' LIKE N'%;$OIZSERVER;%') THEN 1                -- OIZSERVER
                          ELSE 0
                        END,
       --
       @IsZH_SCHINTI = CASE 
                          WHEN (N';' + N'{NSExt}' + N';' LIKE N'%;SCHINTI;%') OR
                               (N';' + N'{NSExt}' + N';' LIKE N'%;$SCHINTI;%') THEN 1                 -- SCHINTI
                          ELSE 0
                        END,
       --
       @IsZH_TakeBakProdVortag = CASE 
                                   WHEN (N';' + N'{NSExt}' + N';' LIKE N'%;SRCPRODBAK;%') OR
                                        (N';' + N'{NSExt}' + N';' LIKE N'%;$SRCPRODBAK;%') THEN 1     -- SRCPRODBAK
                                   ELSE 0
                                 END;

-------------------------------------------------------------------------------
--- settings
-------------------------------------------------------------------------------
SET @DBName     = N'{DBName}';

SELECT @BackupFile = CASE 
                       WHEN @IsZH = 1 THEN 
                         CASE 
                           WHEN @IsZH_OIZSERVER = 1 THEN
                             CASE
                               WHEN @IsZH_TakeBakProdVortag = 1 THEN N'I:\BakTrc\mssql2012\Backup\KISS_PROD\kiss_zh.bak'
                               ELSE N'I:\BakTrc\mssql2012\Backup\KissBuildDBs\' + @DBName + '.bak'
                             END
                         ELSE N'D:\KiSSDBPool\' + @DBName + '.bak'
                         END
                       -- internal
                       ELSE N'D:\KiSSDBPool\' + @DBName + '.bak'
                     END,
       @IsDoc      = 0,
       @DBPath     = N'{DBRootDirectory}\',
       @DataFolder  = CASE 
                       WHEN @IsZH_OIZSERVER = 1 THEN @DBName + '\'
                       ELSE N'DATA\'
                     END,
       @LogFolder  = CASE 
                       WHEN @IsZH_OIZSERVER = 1 THEN @DBName + '\'
                       ELSE N'LOG\'
                     END;

-- info
PRINT ('Info: Current settings are: @DBName="' + @DBName + '"; @IsDoc="' + CONVERT(VARCHAR(10), @IsDoc) + '"; @BackupFile="' + @BackupFile + '"; @DBPath="' + @DBPath + '"');

-------------------------------------------------------------------------------
-- restore preparations
-------------------------------------------------------------------------------
-- start with nocount
SET NOCOUNT ON;

-- init vars
DECLARE @sql NVARCHAR(4000);
DECLARE @PrefFileNameData NVARCHAR(500);
DECLARE @PrefFileNameLog NVARCHAR(500);
DECLARE @NL NVARCHAR(2);
DECLARE @OldDBName NVARCHAR(100);
DECLARE @FileGroup NVARCHAR(1000);
DECLARE @FileNr NVARCHAR(10);
DECLARE @MaxFileNr NVARCHAR(10);
DECLARE @NameFilegroup NVARCHAR(260);

-- setup vars
SET @NL = CHAR(13) + CHAR(10); -- New line

-- drop temp tables
IF (OBJECT_ID('TempDB.dbo.#DBFiles') IS NOT NULL)
BEGIN 
  PRINT ('Info: Dropping #DBFiles (pre restore)');
  DROP TABLE #DBFiles;
END;

IF (OBJECT_ID('TempDB.dbo.#BackupHeaderOnly') IS NOT NULL)
BEGIN 
  PRINT ('Info: Dropping #BackupHeaderOnly (pre restore)');
  DROP TABLE #BackupHeaderOnly;
END;

IF (OBJECT_ID('TempDB.dbo.#BackupFileListOnly') IS NOT NULL)
BEGIN 
  PRINT ('Info: Dropping #BackupFileListOnly (pre restore)');
  DROP TABLE #BackupFileListOnly;
END;

-- recreate temp tables
CREATE TABLE #DBFiles (
  [Name]      SYSNAME,
  [FileID]    SMALLINT,
  [FileName]  NVARCHAR(260),
  [FileGroup] NVARCHAR(100),
  [Size]      NVARCHAR(18),
  [MaxSize]   NVARCHAR(18),
  [Growth]    NVARCHAR(18),
  [Usage]     VARCHAR(9)
);

CREATE TABLE #BackupHeaderOnly (
  [BackupName]             NVARCHAR(128),
  [BackupDescription]      NVARCHAR(255),
  [BackupType]             SMALLINT,
  [ExpirationDate]         DATETIME,
  [Compressed]             TINYINT,
  [Position]               SMALLINT,
  [DeviceType]             TINYINT,
  [UserName]               NVARCHAR(128),
  [ServerName]             NVARCHAR(128),
  [DatabaseName]           NVARCHAR(128),
  [DatabaseVersion]        INT,
  [DatabaseCreationDate]   DATETIME,
  [BackupSize]             NUMERIC(20,0),
  [FirstLSN]               NUMERIC(25,0),
  [LastLSN]                NUMERIC(25,0),
  [CheckpointLSN]          NUMERIC(25,0),
  [DatabaseBackupLSN]      NUMERIC(25,0),
  [BackupStartDate]        DATETIME,
  [BackupFinishDate]       DATETIME,
  [SortOrder]              SMALLINT,
  [CodePage]               SMALLINT,
  [UnicodeLocaleId]        INT,
  [UnicodeComparisonStyle] INT,
  [CompatibilityLevel]     TINYINT,
  [SoftwareVendorId]       INT,
  [SoftwareVersionMajor]   INT,
  [SoftwareVersionMinor]   INT,
  [SoftwareVersionBuild]   INT,
  [MachineName]            NVARCHAR(128),
  [Flags]                  INT,
  [BindingID]              UNIQUEIDENTIFIER,
  [RecoveryForkID]         UNIQUEIDENTIFIER,
  [Collation]              NVARCHAR(128)
);

CREATE TABLE #BackupFileListOnly (
  [LogicalName]   NVARCHAR(128),
  [PhysicalName]  NVARCHAR(260),
  [Type]          CHAR(1),
  [FileGroupName] NVARCHAR(128),
  [Size]          NUMERIC(20,0),
  [MaxSize]       NUMERIC(20,0)
);

IF (@@VERSION LIKE '%Microsoft SQL Server 2005%') 
BEGIN
  ALTER TABLE #BackupHeaderOnly ADD
    FamilyGUID            UNIQUEIDENTIFIER,
    HasBulkLoggedData     BIT,
    IsSnapshot            BIT,
    IsReadOnly            BIT,
    IsSingleUser          BIT,
    HasBackupChecksums    BIT,
    IsDamaged             BIT,
    BeginsLogChain        BIT,
    HasIncompleteMetaData BIT,
    IsForceOffline        BIT,
    IsCopyOnly            BIT,
    FirstRecoveryForkID   UNIQUEIDENTIFIER,
    ForkPointLSN          NUMERIC(25,0),
    RecoveryModel         NVARCHAR(60),
    DifferentialBaseLSN   NUMERIC(25,0),
    DifferentialBaseGUID  UNIQUEIDENTIFIER,
    BackupTypeDescription NVARCHAR(60),
    BackupSetGUID         UNIQUEIDENTIFIER;

  ALTER TABLE #BackupFileListOnly ADD
    FileID                BIGINT,
    CreateLSN             NUMERIC(25,0),
    DropLSN               NUMERIC(25,0) NULL,
    UniqueID              UNIQUEIDENTIFIER,
    ReadOnlyLSN           NUMERIC(25,0) NULL,
    ReadWriteLSN          NUMERIC(25,0) NULL,
    BackupSizeInBytes     BIGINT,
    SourceBlockSize       INT,
    FileGroupID           INT,
    LogGroupGUID          UNIQUEIDENTIFIER NULL,
    DifferentialBaseLSN   NUMERIC(25,0) NULL,
    DifferentialBaseGUID  UNIQUEIDENTIFIER,
    IsReadOnly            BIT,
    IsPresent             BIT;
END;

IF (@@VERSION LIKE '%Microsoft SQL Server 2008%') 
BEGIN
  ALTER TABLE #BackupHeaderOnly ADD
    FamilyGUID            UNIQUEIDENTIFIER,
    HasBulkLoggedData     BIT,
    IsSnapshot            BIT,
    IsReadOnly            BIT,
    IsSingleUser          BIT,
    HasBackupChecksums    BIT,
    IsDamaged             BIT,
    BeginsLogChain        BIT,
    HasIncompleteMetaData BIT,
    IsForceOffline        BIT,
    IsCopyOnly            BIT,
    FirstRecoveryForkID   UNIQUEIDENTIFIER,
    ForkPointLSN          NUMERIC(25,0) NULL,
    RecoveryModel         NVARCHAR(60),
    DifferentialBaseLSN   NUMERIC(25,0) NULL,
    DifferentialBaseGUID  UNIQUEIDENTIFIER,
    BackupTypeDescription NVARCHAR(60),
    BackupSetGUID         UNIQUEIDENTIFIER NULL,
    CompressedBackupSize  BIGINT;
    
  ALTER TABLE #BackupFileListOnly ADD
    FileID                BIGINT,
    CreateLSN             NUMERIC(25,0),
    DropLSN               NUMERIC(25,0) NULL,
    UniqueID              UNIQUEIDENTIFIER,
    ReadOnlyLSN           NUMERIC(25,0) NULL,
    ReadWriteLSN          NUMERIC(25,0) NULL,
    BackupSizeInBytes     BIGINT,
    SourceBlockSize       INT,
    FileGroupID           INT,
    LogGroupGUID          UNIQUEIDENTIFIER NULL,
    DifferentialBaseLSN   NUMERIC(25,0) NULL,
    DifferentialBaseGUID  UNIQUEIDENTIFIER,
    IsReadOnly            BIT,
    IsPresent             BIT,
    TDEThumbprint         VARBINARY(32);
END;

IF (@@VERSION LIKE '%Microsoft SQL Server 2012%') 
BEGIN
  ALTER TABLE #BackupHeaderOnly ADD
    FamilyGUID            UNIQUEIDENTIFIER,
    HasBulkLoggedData     BIT,
    IsSnapshot            BIT,
    IsReadOnly            BIT,
    IsSingleUser          BIT,
    HasBackupChecksums    BIT,
    IsDamaged             BIT,
    BeginsLogChain        BIT,
    HasIncompleteMetaData BIT,
    IsForceOffline        BIT,
    IsCopyOnly            BIT,
    FirstRecoveryForkID   UNIQUEIDENTIFIER,
    ForkPointLSN          NUMERIC(25,0) NULL,
    RecoveryModel         NVARCHAR(60),
    DifferentialBaseLSN   NUMERIC(25,0) NULL,
    DifferentialBaseGUID  UNIQUEIDENTIFIER,
    BackupTypeDescription NVARCHAR(60),
    BackupSetGUID         UNIQUEIDENTIFIER NULL,
    CompressedBackupSize  BIGINT,
    Containment           TINYINT;
    
  ALTER TABLE #BackupFileListOnly ADD
    FileID                BIGINT,
    CreateLSN             NUMERIC(25,0),
    DropLSN               NUMERIC(25,0) NULL,
    UniqueID              UNIQUEIDENTIFIER,
    ReadOnlyLSN           NUMERIC(25,0) NULL,
    ReadWriteLSN          NUMERIC(25,0) NULL,
    BackupSizeInBytes     BIGINT,
    SourceBlockSize       INT,
    FileGroupID           INT,
    LogGroupGUID          UNIQUEIDENTIFIER NULL,
    DifferentialBaseLSN   NUMERIC(25,0) NULL,
    DifferentialBaseGUID  UNIQUEIDENTIFIER,
    IsReadOnly            BIT,
    IsPresent             BIT,
    TDEThumbprint         VARBINARY(32);
END;

IF (@@VERSION LIKE '%Microsoft SQL Server 2014%') 
BEGIN
  ALTER TABLE #BackupHeaderOnly ADD
    FamilyGUID            UNIQUEIDENTIFIER,
    HasBulkLoggedData     BIT,
    IsSnapshot            BIT,
    IsReadOnly            BIT,
    IsSingleUser          BIT,
    HasBackupChecksums    BIT,
    IsDamaged             BIT,
    BeginsLogChain        BIT,
    HasIncompleteMetaData BIT,
    IsForceOffline        BIT,
    IsCopyOnly            BIT,
    FirstRecoveryForkID   UNIQUEIDENTIFIER,
    ForkPointLSN          NUMERIC(25,0) NULL,
    RecoveryModel         NVARCHAR(60),
    DifferentialBaseLSN   NUMERIC(25,0) NULL,
    DifferentialBaseGUID  UNIQUEIDENTIFIER,
    BackupTypeDescription NVARCHAR(60),
    BackupSetGUID         UNIQUEIDENTIFIER NULL,
    CompressedBackupSize  BIGINT,
    Containment           TINYINT,
    KeyAlgorithm          NVARCHAR(32),
    EncryptorThumbprint   VARBINARY(20),
    EncryptorType         NVARCHAR(32);

  ALTER TABLE #BackupFileListOnly ADD
    FileID                BIGINT,
    CreateLSN             NUMERIC(25,0),
    DropLSN               NUMERIC(25,0) NULL,
    UniqueID              UNIQUEIDENTIFIER,
    ReadOnlyLSN           NUMERIC(25,0) NULL,
    ReadWriteLSN          NUMERIC(25,0) NULL,
    BackupSizeInBytes     BIGINT,
    SourceBlockSize       INT,
    FileGroupID           INT,
    LogGroupGUID          UNIQUEIDENTIFIER NULL,
    DifferentialBaseLSN   NUMERIC(25,0) NULL,
    DifferentialBaseGUID  UNIQUEIDENTIFIER,
    IsReadOnly            BIT,
    IsPresent             BIT,
    TDEThumbprint         VARBINARY(32);
END;

-- Generate DBName if is missing
IF (@DBName = '') 
BEGIN
  SET @DBName = SUBSTRING(@BackupFile, LEN(@BackupFile) + 2 - CHARINDEX('\', REVERSE(@BackupFile), 1), 1000);
  SET @DBName = SUBSTRING(@DBName, 1, LEN(@DBName) - CHARINDEX('.', REVERSE(@DBName), 1));
END;

-- Get DB path
IF (ISNULL(@DBPath, '') = '') 
BEGIN
  IF (EXISTS (SELECT name FROM sysdatabases WITH (READUNCOMMITTED) WHERE name = @DBName)) BEGIN
    -- if the DB already exists, set the db path to it's data folder
    SET @sql = N'USE [' + @DBName + N'];' + @NL +
               N'EXEC sp_helpfile;';
      
    INSERT INTO #DBFiles
      EXECUTE sp_executesql @sql;

    SELECT @DBPath = MAX(RTRIM(FileName)) 
    FROM #DBFiles 
    WHERE Usage = 'data only' 
      AND FileGroup = 'PRIMARY';
  END
  ELSE BEGIN
    -- set the db path to the master database's data folder
    SET @sql = N'USE [master];' + @NL +
               N'EXEC sp_helpfile;';
      
    INSERT INTO #DBFiles
      EXECUTE sp_executesql @sql;

    SELECT @DBPath = MAX(RTRIM(FileName))
    FROM #DBFiles
    WHERE Usage = 'data only' 
      AND FileGroup = 'PRIMARY';
  END;

  SET @DBPath = SUBSTRING(@DBPath, 1, LEN(@DBPath) + 1 - CHARINDEX('\', REVERSE(@DBPath), 1));
END;

-- add backslash if missing
IF (SUBSTRING(@DBPath, LEN(@DBPath), 1) <> '\') 
BEGIN
  SET @DBPath = @DBPath + '\';
END;

-- set file name prefix (path & db name)
SET @PrefFileNameData = @DBPath + @DataFolder + @DBName + '_';
SET @PrefFileNameLog = @DBPath + @LogFolder + @DBName + '_';

-------------------------------------------------------------------------------
-- backupset
-------------------------------------------------------------------------------
-- Read Backupset
PRINT ('read backupset header: ' + CONVERT(VARCHAR, GETDATE(), 113));
SET @sql = N'RESTORE HEADERONLY FROM DISK = ''' + @BackupFile + N'''';

INSERT INTO #BackupHeaderOnly
  EXECUTE sp_executesql @sql;

SELECT @OldDBName = MAX(DatabaseName),
       @FileNr = MAX(Position)
FROM #BackupHeaderOnly
WHERE BackupType = 1;

SELECT @MaxFileNr = MAX(Position)
FROM #BackupHeaderOnly
WHERE BackupType = 2
  AND Position > @FileNr;

PRINT ('read backupset filelist: ' + CONVERT(VARCHAR, GETDATE(), 113));
SET @sql = N'RESTORE FILELISTONLY FROM DISK = ''' + @BackupFile + N''' WITH FILE = ' + @FileNr;

INSERT INTO #BackupFileListOnly
  EXECUTE sp_executesql @sql;

SET @sql = '';

DECLARE cFileList CURSOR FAST_FORWARD FOR
  SELECT N' MOVE ''' + [LogicalName] + N''' TO ''' + CASE WHEN [Type] = 'L' THEN @PrefFileNameLog
                              ELSE @PrefFileNameData
                           END +
                              CASE
                                WHEN [Type] = 'D' AND [FileGroupName] = 'PRIMARY' THEN 'Primary.mdf'
                                WHEN [Type] = 'L' THEN 'Log.ldf'
                                ELSE [FileGroupName] + '.ndf'
                              END + N''', '
  FROM #BackupFileListOnly;

OPEN cFileList;
WHILE (1 = 1) BEGIN
  FETCH NEXT FROM cFileList INTO @FileGroup;
  IF (@@FETCH_STATUS < 0) BREAK;

  IF (@FileGroup IS NOT NULL) BEGIN
    SET @sql = @sql + @NL + @FileGroup;
  END;
END;
DEALLOCATE cFileList;

-------------------------------------------------------------------------------
-- do restore
-------------------------------------------------------------------------------
-- Restore Database
SET @sql = N'RESTORE DATABASE [' + @DBName + '] 
               FROM DISK = ''' + @BackupFile + N''' 
               WITH FILE = ' + @FileNr + N', ' + @sql + @NL + N' ';

IF (@MaxFileNr IS NULL) BEGIN
  SET @sql = @sql + N'REPLACE'
END
ELSE 
BEGIN
  SET @sql = @sql + N'NOUNLOAD, NORECOVERY, REPLACE'
END

-- info
PRINT ('restore database: ' + CONVERT(VARCHAR, GETDATE(), 113));
PRINT @sql

EXECUTE sp_executesql @sql

-- Restore Transaction Log
DECLARE cur_LogBackup CURSOR FOR
  SELECT Position
  FROM #BackupHeaderOnly
  WHERE BackupType = 2 AND Position > @FileNr
  ORDER BY Position

OPEN cur_LogBackup

FETCH NEXT 
FROM cur_LogBackup 
INTO @FileNr

WHILE @@FETCH_STATUS = 0
BEGIN
  SET @sql = N'
    RESTORE LOG [' + @DBName + '] 
      FROM DISK = ''' + @BackupFile + N'''
      WITH FILE = ' + @FileNr + N', ' + @NL + N' ';

  IF (@MaxFileNr = @FileNr) BEGIN
    SET @sql = @sql + N'RECOVERY'
  END
  ELSE 
  BEGIN
    SET @sql = @sql + N'NOUNLOAD, NORECOVERY'
  END;

  -- info
  PRINT ('restore transaction log: ' + CONVERT(VARCHAR, GETDATE(), 113));
  PRINT @sql;
  
  EXECUTE sp_executesql @sql;

  -- Get the next author.
  FETCH NEXT 
  FROM cur_LogBackup
  INTO @FileNr;
END;

CLOSE cur_LogBackup;
DEALLOCATE cur_LogBackup;

-------------------------------------------------------------------------------
-- sync users after restore
-------------------------------------------------------------------------------
-- info
PRINT ('resync logins: ' + CONVERT(VARCHAR, GETDATE(), 113));

-- Resync SQL Logins
SET @sql = N'
DECLARE cSQL CURSOR FAST_FORWARD FOR
  SELECT N''USE [' + @DBName + ']'' + CHAR(13) + CHAR(10) +
         N''EXEC sp_change_users_login ''''Auto_Fix'''', '''''' + name + ''''''''
  FROM [' + @DBName + ']..sysusers USR WITH (READUNCOMMITTED)
  WHERE EXISTS (SELECT TOP 1 1 
                FROM master..syslogins WITH (READUNCOMMITTED) 
                WHERE name COLLATE DATABASE_DEFAULT = USR.name COLLATE DATABASE_DEFAULT)';

EXECUTE (@sql);

OPEN cSQL
WHILE 1 = 1 BEGIN
  FETCH NEXT FROM cSQL INTO @sql
  IF (@@FETCH_STATUS != 0) BREAK

  EXECUTE sp_executesql @sql
END
CLOSE cSQL
DEALLOCATE cSQL

-------------------------------------------------------------------------------
-- filegroup handling
-------------------------------------------------------------------------------
-- info
PRINT ('add filegroups: ' + CONVERT(VARCHAR, GETDATE(), 113));

-- add missing file groups for main db
IF (@IsDoc = 0) 
BEGIN
  SET @sql = '';
  
  -- DATEN1
  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'DATEN1')) 
  BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [DATEN1]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Daten1'', FILENAME = N''' + @PrefFileNameData + N'Daten1.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [DATEN1]';
  END;
  
  -- DATEN2
  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'DATEN2')) 
  BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [DATEN2]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Daten2'', FILENAME = N''' + @PrefFileNameData + N'Daten2.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [DATEN2]';
  END;
  
  -- DATEN3
  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'DATEN3')) 
  BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [DATEN3]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Daten3'', FILENAME = N''' + @PrefFileNameData + N'Daten3.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [DATEN3]';
  END;
  
  -- SYSTEM
  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'SYSTEM')) 
  BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [SYSTEM]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_System'', FILENAME = N''' + @PrefFileNameData + N'System.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [SYSTEM]';
  END;
  
  -- LOGGING
  IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'LOGGING')) 
  BEGIN
    SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [LOGGING]' + @NL +
      'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Logging'', FILENAME = N''' + @PrefFileNameData + N'Logging.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [LOGGING]';
  END;
  
  -- ARCHIV (only ZH)
  IF (@IsZH = 1)
  BEGIN
    IF (NOT EXISTS (SELECT TOP 1 1 FROM #BackupFileListOnly WHERE FileGroupName = 'ARCHIV')) 
    BEGIN
      SET @sql = @sql + @NL + N'ALTER DATABASE [' + @DBName + '] ADD FILEGROUP [ARCHIV]' + @NL +
        'ALTER DATABASE [' + @DBName + '] ADD FILE ( NAME = N''' + @DBName + '_Archiv'', FILENAME = N''' + @PrefFileNameData + N'Archiv.ndf'' , SIZE = 1, FILEGROWTH = 256MB) TO FILEGROUP [ARCHIV]';
    END;
  END;  
  
  IF (@sql <> '') 
  BEGIN
    PRINT @sql;
    EXECUTE sp_executesql @sql;
  END;
END;

-- filegroups: naming and sizing will be done in script: Rxxxx_Apply_DatabaseSettings.sql

-------------------------------------------------------------------------------
-- done with restore process, complete with GO
-------------------------------------------------------------------------------
GO

-------------------------------------------------------------------------------
-- cleanup
-------------------------------------------------------------------------------
-- info
PRINT ('cleanup: ' + CONVERT(VARCHAR, GETDATE(), 113));

-- drop temp tables
IF (OBJECT_ID('TempDB.dbo.#DBFiles') IS NOT NULL)
BEGIN 
  PRINT ('Info: Dropping #DBFiles (post restore)');
  DROP TABLE #DBFiles;
END;

IF (OBJECT_ID('TempDB.dbo.#BackupHeaderOnly') IS NOT NULL)
BEGIN 
  PRINT ('Info: Dropping #BackupHeaderOnly (post restore)');
  DROP TABLE #BackupHeaderOnly;
END;

IF (OBJECT_ID('TempDB.dbo.#BackupFileListOnly') IS NOT NULL)
BEGIN 
  PRINT ('Info: Dropping #BackupFileListOnly (post restore)');
  DROP TABLE #BackupFileListOnly;
END;
GO

-------------------------------------------------------------------------------
-- shrink log to save space
-------------------------------------------------------------------------------
PRINT ('Info: Shrink log files: ' + CONVERT(VARCHAR, GETDATE(), 113));
USE [{DBName}];
GO

DECLARE @LogFileName NVARCHAR(255);

SELECT TOP 1 @LogFileName = DAF.name
FROM sys.database_files DAF
WHERE DAF.type_desc = 'LOG'
ORDER BY DAF.file_id;

IF (ISNULL(@LogFileName, '') <> '')
BEGIN
  PRINT ('Info: Shrinking log file "' + @LogFileName + '"');
  DBCC SHRINKFILE (@LogFileName, 0, TRUNCATEONLY);
END;
GO

-------------------------------------------------------------------------------
-- finishing
-------------------------------------------------------------------------------
-- set to multi-user
PRINT ('Info: Set multiuser: ' + CONVERT(VARCHAR, GETDATE(), 113));
USE [master];
ALTER DATABASE [{DBName}] SET MULTI_USER WITH NO_WAIT;
GO

-- use current database
PRINT ('Info: Switch to database [{DBName}] now: ' + CONVERT(VARCHAR, GETDATE(), 113));
USE [{DBName}];
GO